Public Class DXRender
    Inherits RenderBase

    Public Sub New(ByRef Sim As SimulationRuntime)
        MyBase.New(Sim)
    End Sub

    Public Sub DoDXRender()
        Dim CameraTargetV3 As Vector3 = Sim.Camera.Target.ToVector3
        Dim CameraUpVector As XYZ
        Dim OldCameraPosition As XYZ
        Dim CameraPosition As XYZ

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

                'Change the view port
                Sim.Render.Device.Transform.View = Matrix.LookAtLH(CameraPosition.ToVector3, CameraTargetV3, CameraUpVector.ToVector3)
            ElseIf Not Sim.Config.Render.TraceObjects Then
                'Clear Traces
                Sim.Render.Device.Clear(ClearFlags.Target, Sim.Config.Render.BackgroundColor, 1, 0)
            End If

            'TODO: Not everything here needs to be locked with the simulation
            Sim.Render.RenderLock.EnterReadLock()
            For i = 0 To Sim.ObjectCount - 1
                'If the object doesn't exist create it on the fly
                If Sim.Objects(i).Mesh = Nothing Then
                    Sim.Objects(i).CreateMesh(Sim.Render.Device, Sim.Config.Render.WorldScale, Sim.Config.Render.SphereComplexity, Sim.Render.SphereSecondaryComplexity)
                    Sim.Objects(i).CreateMaterial()
                End If

                'Change WireFrame settings
                If Sim.Objects(i).Wireframe = True Then
                    Sim.Render.Device.RenderState.FillMode = FillMode.WireFrame
                    Sim.Render.Device.RenderState.CullMode = Cull.None
                Else
                    Sim.Render.Device.RenderState.FillMode = FillMode.Solid
                    'Inside the current box
                    If _
                             CameraPosition.X < Sim.Objects(i).LimitPositive.X _
                         And CameraPosition.X > Sim.Objects(i).LimitNegative.X _
                         And CameraPosition.Y < Sim.Objects(i).LimitPositive.Y _
                         And CameraPosition.Y > Sim.Objects(i).LimitNegative.Y _
                         And CameraPosition.Z < Sim.Objects(i).LimitPositive.Z _
                         And CameraPosition.Z > Sim.Objects(i).LimitNegative.Z _
                    Then 'Inside box
                        Sim.Render.Device.RenderState.CullMode = Cull.Clockwise
                    Else
                        Sim.Render.Device.RenderState.CullMode = Cull.CounterClockwise
                    End If
                End If

                'Draw the object in its place
                Sim.Render.Device.Transform.World =
                          Matrix.RotationX(ToSingle(Sim.Objects(i).Rotation.X)) _
                        * Matrix.RotationY(ToSingle(Sim.Objects(i).Rotation.Y)) _
                        * Matrix.RotationZ(ToSingle(Sim.Objects(i).Rotation.Z)) _
                        * Matrix.Translation(
                            ToSingle(Sim.Objects(i).Position.X * Sim.Config.Render.WorldScale),
                            ToSingle(Sim.Objects(i).Position.Y * Sim.Config.Render.WorldScale),
                            ToSingle(Sim.Objects(i).Position.Z * Sim.Config.Render.WorldScale))

                Sim.Render.Device.Material = Sim.Objects(i).Material
                Sim.Objects(i).Mesh.DrawSubset(0)
            Next
            Sim.Render.RenderLock.ExitReadLock()

            'End the scene
            Sim.Render.Device.EndScene()
            Sim.Render.Device.Present()

            RenderControl()
        Loop
    End Sub

    Public Shared Sub InitializeDXRender(Sim As SimulationRuntime)

        'Initialize render settings
        Sim.Render.Device.RenderState.PointSize = 4
        Sim.Render.Device.RenderState.FillMode = FillMode.Solid
        Sim.Render.Device.RenderState.ZBufferEnable = True
        Sim.Render.Device.RenderState.FogEnable = False
        Sim.Render.Device.RenderState.CullMode = Cull.CounterClockwise
        Sim.Render.Device.RenderState.ShadeMode = Sim.Config.Render.Shading

        Sim.Render.Device.RenderState.Lighting = True
        If Sim.Config.Render.EnableLighting Then
            Sim.Render.Device.RenderState.Ambient = Color.Black
            Sim.Render.Device.RenderState.AmbientMaterialSource = ColorSource.Material
            Sim.Render.Device.RenderState.DiffuseMaterialSource = ColorSource.Material
            Sim.Render.Device.RenderState.SpecularMaterialSource = ColorSource.Material
            Sim.Render.Device.RenderState.EmissiveMaterialSource = ColorSource.Material
            Sim.Render.Device.RenderState.SpecularEnable = True
        Else
            Sim.Render.Device.RenderState.SpecularEnable = False
            Sim.Render.Device.RenderState.AmbientMaterialSource = ColorSource.Material
            Sim.Render.Device.RenderState.Ambient = Color.White
        End If

        'Initialize transparency settings
        If Sim.Render.Transparency Then
            Sim.Render.Device.RenderState.SourceBlend = Blend.SourceAlpha
            Sim.Render.Device.RenderState.DestinationBlend = Blend.InvSourceAlpha
            Sim.Render.Device.RenderState.AlphaBlendEnable = True
        End If

        'Clear the device and paint the background
        Sim.Render.Device.Clear(ClearFlags.ZBuffer, Sim.Config.Render.BackgroundColor, 1, 0)
        Sim.Render.Device.Clear(ClearFlags.Target, Sim.Config.Render.BackgroundColor, 1, 0)

        'Setup the view port
        Sim.Render.Device.Transform.Projection = Matrix.PerspectiveFovLH(Sim.Config.Camera.HFov, Sim.Config.Render.AspectRatio, 1 / (Sim.Config.Render.WorldScale * 10), Sim.Config.Render.WorldScale * 2000)
        Sim.Render.Device.Transform.View = Matrix.LookAtLH(Sim.Camera.Position.ToVector3, Sim.Camera.Target.ToVector3, Sim.Camera.N.ToVector3)

        'Calculate Sphere complexity
        Sim.Render.SphereSecondaryComplexity = ToInt32((Sim.Config.Render.SphereComplexity * 0.5) + 0.5)

        'Create object meshes and materials
        For i = 0 To Sim.ObjectCount - 1
            Sim.Objects(i).CreateMesh(Sim.Render.Device, Sim.Config.Render.WorldScale, Sim.Config.Render.SphereComplexity, Sim.Render.SphereSecondaryComplexity)
            Sim.Objects(i).CreateMaterial()
        Next

        'Create the lights
        If Sim.Config.Render.EnableLighting = True Then
            For i = 0 To Sim.LightCount - 1
                Sim.Render.Device.Lights(i).Type = Sim.Lights(i).Type
                Sim.Render.Device.Lights(i).Ambient = Sim.Lights(i).AmbientColor.ToColor
                Sim.Render.Device.Lights(i).Attenuation0 = Sim.Lights(i).AttenuationA
                Sim.Render.Device.Lights(i).Attenuation1 = Sim.Lights(i).AttenuationB
                Sim.Render.Device.Lights(i).Attenuation2 = Sim.Lights(i).AttenuationC
                Sim.Render.Device.Lights(i).Falloff = Sim.Lights(i).Falloff
                Sim.Render.Device.Lights(i).Diffuse = Sim.Lights(i).Color.ToColor
                Sim.Render.Device.Lights(i).Direction = Sim.Lights(i).Direction.ToVector3
                Sim.Render.Device.Lights(i).InnerConeAngle = Sim.Lights(i).InnerCone
                Sim.Render.Device.Lights(i).OuterConeAngle = Sim.Lights(i).OuterCone
                Sim.Render.Device.Lights(i).Range = Sim.Lights(i).Range
                Sim.Render.Device.Lights(i).Specular = Sim.Lights(i).SpecularColor.ToColor
                Sim.Render.Device.Lights(i).Position = Sim.Lights(i).Position.ToVector3
                Sim.Render.Device.Lights(i).Update()
                Sim.Render.Device.Lights(i).Enabled = True
            Next
        End If

    End Sub
End Class
