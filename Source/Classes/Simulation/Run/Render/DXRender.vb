Imports System.Drawing.Drawing2D
Imports SharpDX
Imports SharpDX.Direct3D9
Imports CSCompatibilityLayer
Imports FillMode = SharpDX.Direct3D9.FillMode

Public Class DXRender
    Inherits RenderBase

    Public Sub New(ByRef sim As SimulationRuntime)
        MyBase.New(sim)
    End Sub

    Public Sub DoDXRender()
        Dim CameraTargetV3 As Vector3 = Sim.Camera.Target.ToVector3
        Dim CameraUpVector As XYZ
        Dim OldCameraPosition As XYZ
        Dim CameraPosition As XYZ = Sim.Camera.Position
        Dim RenderObjects() As SimulationObject 'Need to store our own copy since our array need to be sorted

        ReDim RenderObjects(Sim.ObjectCount - 1)
        For i = 0 To Sim.ObjectCount - 1
            RenderObjects(i) = Sim.Objects(i)
        Next

        If Sim.Render.Transparency Then
            SortObjectsByDepth(RenderObjects, CameraPosition)
        End If

        InitRenderControl()

        Do While Sim.Running
            'Start the scene
            Sim.Render.Device.BeginScene()

            'Clear the Z buffer
            Sim.Render.Device.Clear(ClearFlags.ZBuffer, Sim.Config.Render.BackgroundColor, 1, 0)

            'Update the camera position safely
            SimulationCamera.CameraLock.EnterReadLock()
            CameraPosition = Sim.Camera.Position
            CameraUpVector = Sim.Camera.U
            SimulationCamera.CameraLock.ExitReadLock()

            If CameraPosition <> OldCameraPosition Then
                OldCameraPosition = CameraPosition

                'Clear Traces regardless of Trace Display setting
                Sim.Render.Device.Clear(ClearFlags.Target, Sim.Config.Render.BackgroundColor, 1, 0)

                Dim viewMatrix As SharpDX.Matrix = SharpDX.Matrix.LookAtLH(Sim.Camera.Position.ToVector3, Sim.Camera.Target.ToVector3, Sim.Camera.N.ToVector3)
                'Change the view port
                CSCompat.SetTransformation(Sim.Render.Device, TransformState.View, viewMatrix)
            ElseIf Not Sim.Config.Render.TraceObjects Then
                'Clear Traces
                Sim.Render.Device.Clear(ClearFlags.Target, Sim.Config.Render.BackgroundColor, 1, 0)
            End If

            'TODO: Not everything here needs to be locked with the simulation
            SimulationRender.RenderLock.EnterReadLock()

            'Objects may have been added
            If (Sim.ObjectCount <> RenderObjects.Length) Then
                ReDim RenderObjects(Sim.ObjectCount - 1)
                For i = 0 To Sim.ObjectCount - 1
                    RenderObjects(i) = Sim.Objects(i)
                Next
            End If

            If Sim.Render.Transparency Then
                'Need to sort objects by depth, always, objects may have moved
                SortObjectsByDepth(RenderObjects, CameraPosition)
            End If

            For i = 0 To Sim.ObjectCount - 1
                'If the object doesn't exist create it on the fly
                If RenderObjects(i).DXRenderData Is Nothing Then
                    Sim.Objects(i).DXRenderData = ObjectDXRenderData.Build(Sim.Objects(i), Sim.Render.Device, Sim.Config.Render.WorldScale, Sim.Config.Render.SphereComplexity, Sim.Render.SphereSecondaryComplexity)
                End If

                'Change WireFrame settings
                If RenderObjects(i).Wireframe = True Then
                    Sim.Render.Device.SetRenderState(RenderState.FillMode, FillMode.Wireframe)
                    Sim.Render.Device.SetRenderState(RenderState.CullMode, Cull.None)
                Else
                    Sim.Render.Device.SetRenderState(RenderState.FillMode, FillMode.Solid)
                    'TODO: revist this, need to take into account box rotation
                    'Need to calculate if the point represented by the camera is inside the box
                    'This is similar to the collision of a sphere and box but the sphere has a radius of zero
                    'Inside the current box
                    'If __                    Then 'Inside box
                    'Sim.Render.Device.RenderState.CullMode = Cull.Clockwise
                    'Else
                    Sim.Render.Device.SetRenderState(RenderState.CullMode, Cull.Counterclockwise)
                    'End If
                End If

                'Draw the object in its place
                'Calculate the translation matrix of the object
                Dim translationMatrix As SharpDX.Matrix = SharpDX.Matrix.Translation(
                            ToSingle(RenderObjects(i).Position.X * Sim.Config.Render.WorldScale),
                            ToSingle(RenderObjects(i).Position.Y * Sim.Config.Render.WorldScale),
                            ToSingle(RenderObjects(i).Position.Z * Sim.Config.Render.WorldScale))

                'The TransformMatrix is simply the multiplication of both matricies
                CSCompat.SetTransformation(Sim.Render.Device, TransformState.World, RenderObjects(i).DXRenderData.RotationMatrix * translationMatrix)
                Sim.Render.Device.Material = RenderObjects(i).DXRenderData.Material
                RenderObjects(i).DXRenderData.Mesh.DrawSubset(0)
            Next
            SimulationRender.RenderLock.ExitReadLock()

            'End the scene
            Sim.Render.Device.EndScene()
            Sim.Render.Device.Present()

            RenderControl()
        Loop
    End Sub

    Public Sub SortObjectsByDepth(ByRef renderObjects() As SimulationObject, ByRef cameraPosition As XYZ)
        For i = 0 To Sim.ObjectCount - 1
            'TODO: this is a lot of square roots, very expensive
            'TODO: this doesn't work for boxes! Need to know size and rotation
            'TODO: this doesn't work for planes
            renderObjects(i).CameraDistance = (renderObjects(i).Position - cameraPosition).Magnitude - renderObjects(i).Radius
        Next
        Array.Sort(renderObjects)
    End Sub

    Public Shared Sub InitializeDXRender(sim As SimulationRuntime)

        'Initialize render settings
        sim.Render.Device.SetRenderState(RenderState.PointSize, 4)
        sim.Render.Device.SetRenderState(RenderState.FillMode, FillMode.Solid)
        sim.Render.Device.SetRenderState(RenderState.ZEnable, True)
        sim.Render.Device.SetRenderState(RenderState.FogEnable, False)
        sim.Render.Device.SetRenderState(RenderState.CullMode, Cull.Counterclockwise)
        sim.Render.Device.SetRenderState(RenderState.ShadeMode, sim.Config.Render.Shading)

        sim.Render.Device.SetRenderState(RenderState.Lighting, True)
        If sim.Config.Render.EnableLighting Then
            sim.Render.Device.SetRenderState(RenderState.Ambient, System.Drawing.Color.Black.ToArgb) 'TODO: is this BGRA or ARGB ?
            sim.Render.Device.SetRenderState(RenderState.AmbientMaterialSource, ColorSource.Material)
            sim.Render.Device.SetRenderState(RenderState.DiffuseMaterialSource, ColorSource.Material)
            sim.Render.Device.SetRenderState(RenderState.SpecularMaterialSource, ColorSource.Material)
            sim.Render.Device.SetRenderState(RenderState.EmissiveMaterialSource, ColorSource.Material)
            sim.Render.Device.SetRenderState(RenderState.SpecularEnable, True)
        Else
            sim.Render.Device.SetRenderState(RenderState.SpecularEnable, False)
            sim.Render.Device.SetRenderState(RenderState.AmbientMaterialSource, ColorSource.Material)
            sim.Render.Device.SetRenderState(RenderState.Ambient, System.Drawing.Color.White.ToArgb)
        End If

        'Initialize transparency settings
        If sim.Render.Transparency Then
            sim.Render.Device.SetRenderState(RenderState.AlphaBlendEnable, True)
            sim.Render.Device.SetRenderState(RenderState.SourceBlend, SharpDX.Direct3D9.Blend.SourceAlpha)
            sim.Render.Device.SetRenderState(RenderState.DestinationBlend, SharpDX.Direct3D9.Blend.InverseSourceAlpha)
        End If

        'Clear the device and paint the background
        sim.Render.Device.Clear(ClearFlags.ZBuffer, sim.Config.Render.BackgroundColor, 1, 0)
        sim.Render.Device.Clear(ClearFlags.Target, sim.Config.Render.BackgroundColor, 1, 0)

        'Setup the view port
        ' Setting the Projection Matrix
        Dim nearPlane As Single = 1 / (sim.Config.Render.WorldScale * 10)
        Dim farPlane As Single = sim.Config.Render.WorldScale * 2000
        CSCompat.SetTransformation(sim.Render.Device, TransformState.Projection, SharpDX.Matrix.PerspectiveFovLH(sim.Config.Camera.HFov, sim.Config.Render.AspectRatio, nearPlane, farPlane))

        ' Setting the View Matrix
        CSCompat.SetTransformation(sim.Render.Device, TransformState.View, SharpDX.Matrix.LookAtLH(sim.Camera.Position.ToVector3, sim.Camera.Target.ToVector3, sim.Camera.N.ToVector3))

        'Calculate Sphere complexity
        sim.Render.SphereSecondaryComplexity = ToInt32((sim.Config.Render.SphereComplexity * 0.5) + 0.5)

        'Create object meshes and materials
        For i = 0 To sim.ObjectCount - 1
            sim.Objects(i).DXRenderData = ObjectDXRenderData.Build(sim.Objects(i), sim.Render.Device, sim.Config.Render.WorldScale, sim.Config.Render.SphereComplexity, sim.Render.SphereSecondaryComplexity)
        Next

        'Create the lights
        If sim.Config.Render.EnableLighting = True Then
            For i = 0 To sim.LightCount - 1
                Dim light As New Light With {
                    .Type = sim.Lights(i).Type,
                    .Ambient = sim.Lights(i).AmbientColor.ToRawColor4,
                    .Attenuation0 = sim.Lights(i).AttenuationA,
                    .Attenuation1 = sim.Lights(i).AttenuationB,
                    .Attenuation2 = sim.Lights(i).AttenuationC,
                    .Falloff = sim.Lights(i).Falloff,
                    .Diffuse = sim.Lights(i).Color.ToRawColor4,
                    .Direction = sim.Lights(i).Direction.ToVector3,
                    .Range = sim.Lights(i).Range,
                    .Specular = sim.Lights(i).SpecularColor.ToRawColor4,
                    .Position = sim.Lights(i).Position.ToVector3,
                    .Theta = sim.Lights(i).InnerCone,
                    .Phi = sim.Lights(i).OuterCone
                }
                sim.Render.Device.SetLight(i, light)
                sim.Render.Device.EnableLight(i, True)
            Next
        End If

    End Sub
End Class
