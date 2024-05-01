Public Class RayRender
    Inherits RenderBase

    Public Sub New(ByRef Sim As SimulationRuntime)
        MyBase.New(Sim)
    End Sub

    Private Shared ReadOnly LockRayMulti As New Object

    Public Sub DoRayRender()
        'Data loaded from Simulation - Constant
        Dim RenderHeight As Integer = Sim.Config.Render.Height
        Dim RenderWidth As Integer = Sim.Config.Render.Width
        Dim HalfRenderWidth As Double = RenderWidth / 2
        Dim HalfRenderHeight As Double = RenderWidth / 2

        Dim BackgroundColorR As Byte = Sim.Config.Render.BackgroundColor.R
        Dim BackgroundColorG As Byte = Sim.Config.Render.BackgroundColor.G
        Dim BackgroundColorB As Byte = Sim.Config.Render.BackgroundColor.B
        Dim BackgroundColorA As Byte = Sim.Config.Render.BackgroundColor.A

        'Data loaded from Simulation - Dynamic (changes during runtime)
        Dim CameraScreenHunit As New XYZ(Sim.Camera.ScreenHeightUnit)
        Dim CameraScreenWUnit As New XYZ(Sim.Camera.ScreenWidthUnit)
        Dim OldCameraPosition As New XYZ(Sim.Camera.Position)
        Dim CameraPosition As New XYZ(Sim.Camera.Position)
        Dim CameraMoved As Boolean

        Dim CurrentObjectCount As Integer
        Dim ObjectRadius() As Double
        Dim ObjectRadiusSqrd() As Double
        Dim ObjectPosition() As XYZ
        Dim ObjectColor() As SimpleColor

        'Calculated - Used to Trace Rays
        Dim RayDirection As New XYZ ' Dim RayDirection As XYZ 
        Dim CameraToObjectDistance() As XYZ
        Dim CameraToObjectMagSqrd() As Double
        Dim CameraPositionToCameraTarget = Sim.Camera.Target - CameraPosition

        'DirectX Display Objects
        Dim Texture As New Texture(Sim.Render.Device, RenderWidth, RenderHeight, 1, Usage.None, Format.A8R8G8B8, Pool.Managed)
        Dim Sprite As New Sprite(Sim.Render.Device)
        Dim Size As New SizeF(RenderWidth, RenderHeight)
        Dim Point As New PointF(0, 0)
        Dim Rect As New Rectangle(0, 0, RenderWidth, RenderHeight)
        Dim Pitch As Integer = RenderWidth * RenderHeight * 4
        Dim Stream As GraphicsStream

        '2D Pixel Array Raw Data
        Dim PixelData((RenderWidth * RenderHeight * 4) - 1) As Byte
        Dim CurrentPixel As Integer

        'Used in iterarting through each pixel and tracing each ray
        Dim Ray_ObjectDistance As Double
        Dim Ray_ClosestObjectDistance As Double
        Dim Ray_ClosestObject As Integer
        Dim Ray_PointNormal As XYZ
        Dim Ray_tca As Double
        Dim Ray_thc As Double
        Dim Ray_OutsideObject As Boolean
        Dim Ray_ShadowDirection As XYZ
        Dim Ray_ShadowOrigin As XYZ
        Dim Ray_ShadowLength As Double
        Dim Ray_isinShadow As Boolean
        Dim Ray_LdotN As Double
        Dim Ray_attn As Double
        Dim Ray_spot As Double
        Dim Ray_rho As Double
        Dim Ray_cosin As Double
        Dim Ray_cosout As Double
        Dim Ray_PointtoObject As XYZ
        Dim Ray_PointtoObjectMagSqrd As Double

        'Ray color for each pixel
        Dim Ray_colorR As Double
        Dim Ray_colorG As Double
        Dim Ray_colorB As Double

        'Used for temp calulations
        Dim Ray_Temp_XYZ As XYZ
        Dim Mag_temp As Double ' Used to calculate the magnitude of a vector

        'Box
        Dim Ray_ColorUsed As SimpleColor

        'Indicates the number of objects changed since the last loop
        Dim ObjectCountChanged As Boolean = False

        'Load initial object values that otherwise only get loaded if a change is made to the objects
        'TODO: Replace this with a read-write lock. Don't lock with other render threads only the simulation thread
        Sim.Render.RenderLock.EnterReadLock()
        CurrentObjectCount = Sim.ObjectCount
        ReDim ObjectRadius(CurrentObjectCount - 1)
        ReDim ObjectColor(CurrentObjectCount - 1)
        For i = 0 To CurrentObjectCount - 1
            ObjectRadius(i) = Sim.Objects(i).Radius * Sim.Config.Render.WorldScale
            ObjectColor(i).FromColor(Sim.Objects(i).Color)
        Next
        Sim.Render.RenderLock.ExitReadLock()

        'Pre-dimension our arrays
        'Do it outside the Lock for better efficiency
        ReDim CameraToObjectDistance(CurrentObjectCount - 1)
        ReDim CameraToObjectMagSqrd(CurrentObjectCount - 1)
        ReDim ObjectRadiusSqrd(CurrentObjectCount - 1)
        ReDim ObjectPosition(CurrentObjectCount - 1)
        For i = 0 To CurrentObjectCount - 1
            ObjectRadiusSqrd(i) = ObjectRadius(i) * ObjectRadius(i)
        Next

        'Make the Background Transparent so we can trace the object path
        If Sim.Config.Render.TraceObjects = True Then BackgroundColorA = 0

        InitRenderControl()

        Do While Sim.Running

            'Update the camera changes
            CameraMoved = False
            SimulationCamera.CameraLock.EnterReadLock()
            CameraPosition = Sim.Camera.Position
            If CameraPosition <> OldCameraPosition Then
                CameraMoved = True
                CameraScreenHunit = Sim.Camera.ScreenHeightUnit
                CameraScreenWUnit = Sim.Camera.ScreenWidthUnit
            End If
            SimulationCamera.CameraLock.ExitReadLock()
            'Minimize time spent in the lock
            If (CameraMoved) Then
                OldCameraPosition = CameraPosition
                CameraPositionToCameraTarget = Sim.Camera.Target - CameraPosition
            End If

            'Load updated object values
            Sim.Render.RenderLock.EnterReadLock()

            'If the number of objects didn't change then only update their position
            'TODO: This assumes objects are only ever added
            If CurrentObjectCount <> Sim.ObjectCount Then
                CurrentObjectCount = Sim.ObjectCount
                ObjectCountChanged = True
                ReDim ObjectRadius(CurrentObjectCount - 1)
                ReDim ObjectColor(CurrentObjectCount - 1)
                ReDim ObjectPosition(CurrentObjectCount - 1)
                For i = 0 To CurrentObjectCount - 1
                    ObjectRadius(i) = Sim.Objects(i).Radius * Sim.Config.Render.WorldScale
                    ObjectColor(i).FromColor(Sim.Objects(i).Color)
                Next
            End If

            'Always update the Object positions, regardless of object count
            For i = 0 To CurrentObjectCount - 1
                'Note, assign the raw values
                ObjectPosition(i).X = Sim.Objects(i).Position.X
                ObjectPosition(i).Y = Sim.Objects(i).Position.Y
                ObjectPosition(i).Z = Sim.Objects(i).Position.Z
            Next
            Sim.Render.RenderLock.ExitReadLock()

            'Re-dimension our arrays
            'Do it outside the Lock for better efficiency
            If (ObjectCountChanged) Then
                ObjectCountChanged = False
                ReDim ObjectRadiusSqrd(CurrentObjectCount - 1)
                ReDim CameraToObjectDistance(CurrentObjectCount - 1)
                ReDim CameraToObjectMagSqrd(CurrentObjectCount - 1)
                For i = 0 To CurrentObjectCount - 1
                    ObjectRadiusSqrd(i) = ObjectRadius(i) * ObjectRadius(i)
                    CameraToObjectDistance(i) = ObjectPosition(i) - CameraPosition
                    CameraToObjectMagSqrd(i) = CameraToObjectDistance(i).MagnitudeSquared
                Next
            End If

            'Calculate new values based on camera movement and object movement
            'Do it outside the Lock for better efficiency
            If Sim.Config.Render.WorldScale = 1 Then
                For i = 0 To CurrentObjectCount - 1
                    CameraToObjectDistance(i).X = ObjectPosition(i).X - CameraPosition.X
                    CameraToObjectDistance(i).Y = ObjectPosition(i).Y - CameraPosition.Y
                    CameraToObjectDistance(i).Z = ObjectPosition(i).Z - CameraPosition.Z
                    CameraToObjectMagSqrd(i) = CameraToObjectDistance(i).MagnitudeSquared
                Next
            Else
                For i = 0 To CurrentObjectCount - 1
                    ObjectPosition(i).X = ObjectPosition(i).X * Sim.Config.Render.WorldScale
                    ObjectPosition(i).Y = ObjectPosition(i).Y * Sim.Config.Render.WorldScale
                    ObjectPosition(i).Z = ObjectPosition(i).Z * Sim.Config.Render.WorldScale
                    CameraToObjectDistance(i).X = ObjectPosition(i).X - CameraPosition.X
                    CameraToObjectDistance(i).Y = ObjectPosition(i).Y - CameraPosition.Y
                    CameraToObjectDistance(i).Z = ObjectPosition(i).Z - CameraPosition.Z
                    CameraToObjectDistance(i) = ObjectPosition(i) - CameraPosition
                    CameraToObjectMagSqrd(i) = CameraToObjectDistance(i).MagnitudeSquared
                Next
            End If

            'Reset the current pixel counter
            CurrentPixel = 0

            'For each pixel
            For YPixel = 0 To RenderHeight - 1
                Ray_Temp_XYZ.X = ((HalfRenderHeight - YPixel) * CameraScreenHunit.X) + CameraPositionToCameraTarget.X
                Ray_Temp_XYZ.Y = ((HalfRenderHeight - YPixel) * CameraScreenHunit.Y) + CameraPositionToCameraTarget.Y
                Ray_Temp_XYZ.Z = ((HalfRenderHeight - YPixel) * CameraScreenHunit.Z) + CameraPositionToCameraTarget.Z
                For XPixel = 0 To Sim.Config.Render.Width - 1
                    'Calculate the direction of the primary ray
                    RayDirection.X = ((HalfRenderWidth - XPixel) * CameraScreenWUnit.X) + Ray_Temp_XYZ.X
                    RayDirection.Y = ((HalfRenderWidth - XPixel) * CameraScreenWUnit.Y) + Ray_Temp_XYZ.Y
                    RayDirection.Z = ((HalfRenderWidth - XPixel) * CameraScreenWUnit.Z) + Ray_Temp_XYZ.Z

                    'Make RayDirection a unit vector
                    Mag_temp = 1 / Sqrt((RayDirection.X * RayDirection.X) + (RayDirection.Y * RayDirection.Y) + (RayDirection.Z * RayDirection.Z))
                    RayDirection.X *= Mag_temp
                    RayDirection.Y *= Mag_temp
                    RayDirection.Z *= Mag_temp

                    'Reset object flags
                    Ray_ClosestObjectDistance = Double.PositiveInfinity
                    Ray_ClosestObject = -1

                    'For each object check for intersection
                    For i = 0 To CurrentObjectCount - 1
                        Ray_tca = CameraToObjectDistance(i).Dot(RayDirection)
                        Ray_OutsideObject = CameraToObjectMagSqrd(i) > ObjectRadiusSqrd(i)
                        If Ray_tca >= 0 Or Not Ray_OutsideObject Then  'There might be an intersection
                            Ray_thc = ObjectRadiusSqrd(i) - CameraToObjectMagSqrd(i) + (Ray_tca * Ray_tca)
                            If Ray_thc >= 0 Then
                                If Ray_OutsideObject Then
                                    Ray_ObjectDistance = Ray_tca - Sqrt(Ray_thc)
                                Else
                                    Ray_ObjectDistance = Ray_tca + Sqrt(Ray_thc)
                                End If
                                If Ray_ObjectDistance > 0 And Ray_ObjectDistance < Ray_ClosestObjectDistance Then
                                    Ray_ClosestObjectDistance = Ray_ObjectDistance
                                    Ray_ClosestObject = i
                                End If
                            End If
                        End If
                    Next

                    If Ray_ClosestObject = -1 Then 'If no object was found return the background
                        'Write the pixel to the pixel array
                        PixelData(CurrentPixel) = BackgroundColorB
                        PixelData(CurrentPixel + 1) = BackgroundColorG
                        PixelData(CurrentPixel + 2) = BackgroundColorR
                        PixelData(CurrentPixel + 3) = BackgroundColorA
                        CurrentPixel += 4
                    Else
                        Ray_ShadowOrigin.X = CameraPosition.X + (RayDirection.X * Ray_ClosestObjectDistance)
                        Ray_ShadowOrigin.Y = CameraPosition.Y + (RayDirection.Y * Ray_ClosestObjectDistance)
                        Ray_ShadowOrigin.Z = CameraPosition.Z + (RayDirection.Z * Ray_ClosestObjectDistance)

                        If Ray_ClosestObject <> -2 Then
                            Ray_PointNormal.X = Ray_ShadowOrigin.X - ObjectPosition(Ray_ClosestObject).X
                            Ray_PointNormal.Y = Ray_ShadowOrigin.Y - ObjectPosition(Ray_ClosestObject).Y
                            Ray_PointNormal.Z = Ray_ShadowOrigin.Z - ObjectPosition(Ray_ClosestObject).Z

                            'Make Ray_PointNormal a unit vector
                            Mag_temp = 1 / Sqrt((Ray_PointNormal.X * Ray_PointNormal.X) + (Ray_PointNormal.Y * Ray_PointNormal.Y) + (Ray_PointNormal.Z * Ray_PointNormal.Z))
                            Ray_PointNormal.X *= Mag_temp
                            Ray_PointNormal.Y *= Mag_temp
                            Ray_PointNormal.Z *= Mag_temp
                        Else
                            'TODO: This is supposed to be for a BOX
                            Ray_PointNormal = New XYZ
                        End If

                        'Reset the ray color before calulating all the lighting
                        Ray_colorR = 0
                        Ray_colorG = 0
                        Ray_colorB = 0

                        'For each light in the scene
                        For l = 0 To Sim.LightCount - 1
                            If Sim.Lights(l).Type = LightType.Directional Then
                                'Directional lights always cast shadows in a single direction
                                Ray_ShadowDirection.X = -Sim.Lights(l).Direction.X
                                Ray_ShadowDirection.Y = -Sim.Lights(l).Direction.Y
                                Ray_ShadowDirection.Z = -Sim.Lights(l).Direction.Z
                            Else
                                Ray_ShadowDirection.X = Sim.Lights(l).Position.X - Ray_ShadowOrigin.X
                                Ray_ShadowDirection.Y = Sim.Lights(l).Position.Y - Ray_ShadowOrigin.Y
                                Ray_ShadowDirection.Z = Sim.Lights(l).Position.Z - Ray_ShadowOrigin.Z
                            End If

                            Ray_ShadowLength = Sqrt((Ray_ShadowDirection.X * Ray_ShadowDirection.X) + (Ray_ShadowDirection.Y * Ray_ShadowDirection.Y) + (Ray_ShadowDirection.Z * Ray_ShadowDirection.Z))
                            'Make Ray_ShadowDirection a unit vector 
                            Mag_temp = 1 / Ray_ShadowLength
                            Ray_ShadowDirection.X *= Mag_temp
                            Ray_ShadowDirection.Y *= Mag_temp
                            Ray_ShadowDirection.Z *= Mag_temp

                            Ray_LdotN = Ray_ShadowDirection.Dot(Ray_PointNormal)

                            If Ray_LdotN < 0 Then 'Self shadowing
                                Ray_isinShadow = True
                            Else
                                Ray_isinShadow = False
                                'For each object check for intersection
                                For i = 0 To CurrentObjectCount - 1
                                    Ray_PointtoObject.X = ObjectPosition(i).X - Ray_ShadowOrigin.X
                                    Ray_PointtoObject.Y = ObjectPosition(i).Y - Ray_ShadowOrigin.Y
                                    Ray_PointtoObject.Z = ObjectPosition(i).Z - Ray_ShadowOrigin.Z
                                    Ray_tca = Ray_PointtoObject.Dot(Ray_ShadowDirection)
                                    If Ray_tca > 0 Then  'There might be an intersection
                                        Ray_PointtoObjectMagSqrd = Ray_PointtoObject.MagnitudeSquared
                                        Ray_thc = ObjectRadiusSqrd(i) - Ray_PointtoObjectMagSqrd + (Ray_tca * Ray_tca)
                                        If Ray_thc >= 0 Then
                                            If Ray_tca - Sqrt(Ray_thc) > 0 Then
                                                Ray_isinShadow = True
                                                Exit For
                                            End If
                                        End If
                                    End If
                                Next
                            End If

                            If Ray_ClosestObject = -2 Then
                                'ColorUsed = Settings.Box.Color
                            Else
                                Ray_ColorUsed = ObjectColor(Ray_ClosestObject)
                            End If

                            'Add Ambient Lighting for this light
                            Ray_colorR += Sim.Lights(l).AmbientColor.R * (Ray_ColorUsed.R * Byth)
                            Ray_colorG += Sim.Lights(l).AmbientColor.G * (Ray_ColorUsed.G * Byth)
                            Ray_colorB += Sim.Lights(l).AmbientColor.B * (Ray_ColorUsed.B * Byth)

                            If Not Ray_isinShadow Then
                                'Add direct lighting for this light

                                If Sim.Lights(l).Type = LightType.Point Then
                                    Ray_attn = 1 / (Sim.Lights(l).AttenuationA + (Ray_ShadowLength * (Sim.Lights(l).AttenuationB + (Sim.Lights(l).AttenuationC * Ray_ShadowLength))))
                                    Ray_spot = 1
                                ElseIf Sim.Lights(l).Type = LightType.Spot Then
                                    Ray_attn = 1 / (Sim.Lights(l).AttenuationA + (Ray_ShadowLength * (Sim.Lights(l).AttenuationB + (Sim.Lights(l).AttenuationC * Ray_ShadowLength))))
                                    Ray_rho = Sim.Lights(l).Direction.Dot(-Ray_ShadowDirection)
                                    Ray_cosout = Cos(Sim.Lights(l).OuterCone * 0.5)
                                    Ray_cosin = Cos(Sim.Lights(l).InnerCone * 0.5)
                                    If Ray_rho > Ray_cosin Then
                                        Ray_spot = 1
                                    ElseIf (Ray_rho <= Ray_cosout) Then
                                        Ray_spot = 0
                                    Else
                                        Ray_spot = ((Ray_rho - Ray_cosout) / (Ray_cosin - Ray_cosout)) ^ Sim.Lights(l).Falloff
                                    End If
                                Else
                                    Ray_attn = 1
                                    Ray_spot = 1
                                End If
                                Ray_attn *= Byth * Ray_LdotN * Ray_spot
                                Ray_colorR += (Ray_attn * Ray_ColorUsed.R) * Sim.Lights(l).Color.R
                                Ray_colorG += (Ray_attn * Ray_ColorUsed.G) * Sim.Lights(l).Color.G
                                Ray_colorB += (Ray_attn * Ray_ColorUsed.B) * Sim.Lights(l).Color.B
                            End If
                        Next

                        'Write the pixel to the pixel array
                        PixelData(CurrentPixel) = ToByte(Min(Ray_colorB, MaxByteD)) 'Cap the components at 255
                        PixelData(CurrentPixel + 1) = ToByte(Min(Ray_colorG, MaxByteD))
                        PixelData(CurrentPixel + 2) = ToByte(Min(Ray_colorR, MaxByteD))
                        PixelData(CurrentPixel + 3) = 255
                        CurrentPixel += 4
                    End If
                Next
            Next

            'Draw the pixel array to the texture
            Stream = Texture.LockRectangle(0, Rect, LockFlags.None, Pitch)
            Stream.Write(PixelData, 0, PixelData.Length)
            Texture.UnlockRectangle(0)

            'Draw the texture to the  screen
            SyncLock LockRayMulti 'Make sure only one thread is using the device 
                Sim.Render.Device.BeginScene()
                If CameraMoved Then Sim.Render.Device.Clear(ClearFlags.Target, Sim.Config.Render.BackgroundColor, 1, 0)
                Sprite.Begin(SpriteFlags.AlphaBlend)
                Sprite.Draw2D(Texture, Rect, Size, Point, Color.White)
                Sprite.End()
                Sim.Render.Device.EndScene()
                Sim.Render.Device.Present()
            End SyncLock
            RenderControl()
        Loop

        'Reset the background color in case path tracing was used
        Sim.Config.Render.BackgroundColor = Color.FromArgb(255, Sim.Config.Render.BackgroundColor.R, Sim.Config.Render.BackgroundColor.G, Sim.Config.Render.BackgroundColor.B)
    End Sub

End Class
