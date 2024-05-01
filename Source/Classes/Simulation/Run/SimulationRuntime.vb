Imports System.Windows.Forms

Public Class SimulationRuntime

#Region "Attributes"
    'Threading
    Private ComputingThread As Thread
    Private RenderThread() As Thread

    'Run State
    Private StartTime As Long
    Public Running As Boolean
    Public Paused As Boolean

    'Counters
    Public CalcCounter As CalculationCounter
    Public RenderCounter As CalculationCounter

    'Camera
    Public Camera As SimulationCamera

    'Render
    Public Render As SimulationRender

    'Simulation Objects
    Public ObjectCount As Integer
    Public Objects() As SimulationObject

    'Simulation Lights
    Public LightCount As Integer
    Public Lights() As SimulationLight

    'Random Generator
    Public ReadOnly RandMaker As RandNumber

    'The configuration of the simulation
    Public Config As SimulationBaseConfig
#End Region

#Region "Basic Class Methods"
    Public Sub New()
        'Threading
        ComputingThread = Nothing
        RenderThread = Nothing

        Running = False
        Paused = False

        'Counters
        CalcCounter.Clear()
        RenderCounter.Clear()

        StartTime = 0

        'Rendering
        Config.Clear()

        'Objects
        ObjectCount = 0
        ReDim Objects(-1)

        'Random
        RandMaker = New RandNumber
    End Sub
    Public Function Copy(ByRef Other As SimulationRuntime) As Boolean
        '----DEEP COPY----
        If Running = True Or Other.Running = True Then
            Return False
        End If

        'Threads
        ComputingThread = Nothing
        RenderThread = Nothing

        Running = False
        Paused = False

        'Counters
        CalcCounter.Copy(Other.CalcCounter)
        RenderCounter.Copy(Other.RenderCounter)
        StartTime = Other.StartTime

        'Settings
        Config.Copy(Other.Config)

        'Objects
        ObjectCount = Other.ObjectCount
        ReDim Objects(ObjectCount - 1)
        For i As Integer = 0 To ObjectCount - 1
            Objects(i) = New SimulationObject(Other.Objects(i))
        Next

        Return True
    End Function
#End Region

#Region "Simulation Control"
    Private Sub ConvertGroupstoObjects()
        Dim NewObjectCount As Integer

        'Add new objects from the groups
        For GroupIndex As Integer = 0 To Config.ObjectGroupCount - 1
            Dim Group As SimulationConfigObjectGroup = Config.ObjectGroups(GroupIndex)

            'Determine the number of objects
            NewObjectCount = Group.Number.CalculateEffectiveValue(RandMaker, GroupIndex, Config.ObjectGroupCount)
            If NewObjectCount < 1 Then NewObjectCount = 1 'Sanity check! 

            'Resize the object array
            Array.Resize(Objects, Objects.Length + NewObjectCount)

            'Create the objects
            For ObjectIndex As Integer = 0 To NewObjectCount - 1

                Objects(ObjectCount) = New SimulationObject With {
                    .Affected = Group.Affected,
                    .Affects = Group.Affects,
                    .Wireframe = Group.Wireframe,
                    .Type = Group.Type,
                    .Mass = Group.Mass.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount),
                    .Charge = Group.Charge.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount),
                    .Position = Group.Position.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount),
                    .Velocity = Group.Velocity.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount),
                    .HighlightSharpness = Min(Group.Sharpness.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount), 200), 'double between 0 and 200
                    .Reflectivity = Min(Group.Reflectivity.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount), 100), 'percentage between 0 and 100
                    .RefractiveIndex = Group.RefractiveIndex.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount)
                }

                If Group.Type = ObjectType.Box Then
                    Objects(ObjectCount).Size = Group.Size.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount)
                    Objects(ObjectCount).Rotation = Group.Rotation.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount)
                ElseIf Group.Type = ObjectType.Sphere Then
                    Objects(ObjectCount).Radius = Group.Radius.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount)
                ElseIf Group.Type = ObjectType.InfinitePlane Then
                    'Always make the normal vector a unit vector to simplify later calculations
                    Objects(ObjectCount).Normal = Group.Normal.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount).MakeMeUnit()

                    'ROTATION - Calculate rotation based on the normal vector
                    If Objects(ObjectCount).Normal = New XYZ(0, 1, 0) Then
                        Objects(ObjectCount).Rotation = New XYZ
                    Else
                        'TODO finish calculation the roation of infite planes
                        'Debug.Print(Acos(Objects(ObjectCount).Normal.Dot(New XYZ(0, 0, 1))).ToString)
                        'Objects(ObjectCount).Rotation = New XYZ(Acos(Objects(ObjectCount).Normal.Dot(New XYZ(0, 1, 0))), Acos(Objects(ObjectCount).Normal.Dot(New XYZ(0, 0, 1))), Acos(Objects(ObjectCount).Normal.Dot(New XYZ(1, 0, 0))))
                    End If
                End If

                'Transparency
                Dim Transparency As Byte = ToByte(Min(Group.Transparency.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount), 255))
                Objects(ObjectCount).Transparency = Transparency
                Render.Transparency = Render.Transparency Or (Transparency) < 255

                'COLOR - Applies to all Object Types
                'Apply the object colour based on the base colour and the transparency
                Dim ObjectColor As Color = Group.Color.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount)
                Objects(ObjectCount).Color = Color.FromArgb(Transparency, ObjectColor.R, ObjectColor.G, ObjectColor.B)

                Dim HighlightColor As Color = Group.Highlight.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount)
                Objects(ObjectCount).HighlightColor = Color.FromArgb(Transparency, HighlightColor.R, HighlightColor.G, HighlightColor.B)

                'Total number of objects created 
                ObjectCount += 1
            Next

        Next
    End Sub
    Private Sub ConvertLightConfigstoLights()
        If (Config.Render.EnableLighting) Then
            LightCount = Config.LightConfigCount
            ReDim Lights(LightCount)
            For index As Integer = 0 To LightCount - 1
                Lights(index).Copy(Config.LightConfigs(index))
                Lights(index).Position = Lights(index).Position * Config.Render.WorldScale
                Lights(index).Range = Lights(index).Range * Config.Render.WorldScale
            Next
        Else
            'Won't be needing any lights!
            LightCount = 0
            ReDim Lights(0)
        End If
    End Sub

    Public Sub RunSimulation()
        'Clear flags
        Paused = False
        Running = True

        'Reinitialize the random number generator
        RandMaker.Seed = Config.GetUniqueSeed()
        RandMaker.Restart()

        ConvertGroupstoObjects()
        ConvertLightConfigstoLights()

        'Resize the output display
        Output.ClientSize = New Size(Config.Render.Width, Config.Render.Height)

        'Set the camera's initial state based on the configuration 
        Camera.Intitialize(Config.Camera, Config.Render.Width, Config.Render.Height, Config.Render.Mode = 2)

        'Create a lock object
        Render.RenderLock = New ReaderWriterLockSlim

        'Initialize render engine
        If InitializeRender() = False Then
            MsgBox("Unable to initialize graphics. Verify that Render Mode has been set correctly.", MsgBoxStyle.Critical, "Error")
            StopSimulation()
            Exit Sub
        End If

        'Determine the number of threads that will be needed
        Dim DoIntegration As Boolean = NeedIntegration()
        Dim CompNumber As Integer = If(DoIntegration Or NeedBasicCompute() = True, 1, 0)
        Dim RenderNumber As Integer

        If Config.Render.RenderThreads = -1 Then
            RenderNumber = CPUNumber - CompNumber
        Else
            RenderNumber = Config.Render.RenderThreads
        End If

        If RenderNumber < 1 Then
            RenderNumber = 1
        End If

        'Show and update the window
        Output.Show()
        Output.BringToFront()
        Application.DoEvents()

        'Start the timers
        ControlPanel.StatusUpdateCount = 0
        QueryPerformanceCounter(RenderCounter.StartValue)
        CalcCounter.StartValue = RenderCounter.StartValue
        ControlPanel.StatusUpdate.Enabled = True
        Output.CameraUpdate.Enabled = True

        'Launch the threads
        SetThreads(CompNumber, RenderNumber, DoIntegration)
    End Sub
    Public Sub StopSimulation()
        Running = False

        ControlPanel.StatusUpdate.Enabled = False
        Output.CameraUpdate.Enabled = False

        'If Render is paused, restart it
        If Paused = True Then
            ResumeSimulation()
        End If

        'Wait until the threads have finished
        If Not IsNothing(ComputingThread) Then
            While (ComputingThread.IsAlive)
                Application.DoEvents()
            End While
            ComputingThread = Nothing
        End If

        For Each thread As Thread In RenderThread
            If Not IsNothing(thread) Then
                While (thread.IsAlive)
                    Application.DoEvents()
                End While
                thread = Nothing
            End If
        Next

        If Config.Render.Mode < 2 Then 'DirectX mode
            'TODO BOX support
            ''Trash Box
            'Settings.Box.Material = Nothing
            'If Not IsNothing(Settings.Box.Mesh) Then
            '    Settings.Box.Mesh.Dispose()
            '    While (Not Settings.Box.Mesh.Disposed)
            '        Application.DoEvents()
            '    End While
            '    Settings.Box.Mesh = Nothing
            'End If

            'Trash all objects
            For i = 0 To ObjectCount - 1
                If Not IsNothing(Objects(i).Mesh) Then
                    Objects(i).Mesh.Dispose()
                    While (Not Objects(i).Mesh.Disposed)
                        Application.DoEvents()
                    End While
                    Objects(i).Mesh = Nothing
                End If
                Objects(i).Material = Nothing
            Next
        Else

        End If

        'Trash the device
        If Not IsNothing(Render.Device) Then
            Render.Device.Dispose()
            While (Not Render.Device.Disposed)
                Application.DoEvents()
            End While
            Render.Device = Nothing
        End If
    End Sub
    Public Sub PauseSimulation()
        Paused = True
    End Sub
    Public Sub ResumeSimulation()
        Paused = False
    End Sub
#End Region

#Region "Computation"
    Private Sub SetThreads(ByRef ComputeThreads As Integer, ByRef RenderThreads As Integer, ByRef DoIntegration As Boolean)
        If ComputeThreads > 0 Then
            ComputingThread = New Thread(AddressOf (New ComputeThread(Me, DoIntegration)).DoCompute) With {
                .Name = "Compute",
                .IsBackground = True
            }
            ComputingThread.Start()
        End If

        If Config.Render.Mode < 2 Then
            ReDim RenderThread(0)
            RenderThread(0) = New Thread(AddressOf (New DXRender(Me)).DoDXRender) With {
                .Name = "DXRender",
                .IsBackground = True
            }

            RenderThread(0).Start()
        Else
            ReDim RenderThread(RenderThreads - 1)
            For i = 0 To RenderThreads - 1
                RenderThread(i) = New Thread(AddressOf (New RayRender(Me)).DoRayRender) With {
                    .Name = "RayRender" & i,
                    .IsBackground = True
                }
            Next

            Dim sleepTime As Integer = 1000 \ RenderThreads
            For i = 0 To RenderThreads - 1
                If i <> 0 Then
                    'Space out the threads to reduce contention
                    Thread.Sleep(sleepTime)
                End If
                RenderThread(i).Start()
            Next
        End If
    End Sub
    Private Function NeedBasicCompute() As Boolean
        'Check if any of the objects have a velocity.
        For i As Integer = 0 To ObjectCount - 1
            If Not Objects(i).Velocity.IsZero Then Return True
        Next

        Return False
    End Function
    Private Function NeedIntegration() As Boolean
        'Check the forces applied on the objects
        If Not Config.Forces.Enabled Then
            Return False
        Else
            'Gravity
            If Config.Forces.Gravity Then
                If ObjectCount >= 2 Then 'There are at least two objects to interact
                    For i As Integer = 0 To ObjectCount - 1 'Check that the objects allow interaction
                        If Objects(i).Affected Then 'If one object can be affected by forces
                            For j As Integer = 0 To ObjectCount - 1 'Check that at least one object can influence
                                If Objects(j).Affects Then
                                    Return True
                                End If
                            Next
                        End If
                    Next
                End If
            End If

            'Drag
            If Config.Forces.Drag.Enabled = True Then
                For i As Integer = 0 To ObjectCount - 1 'Check that the objects allow interaction
                    If Objects(i).Affected Then 'If one object can be affected by drag
                        If Not Objects(i).Velocity.IsZero Then 'If that object has a velocity
                            Return True
                        End If
                    End If
                Next
            End If

            'Uniform field
            If Config.Forces.Field.Enabled Then
                If Not Config.Forces.Field.Acceleration.IsZero Then ' Field isn't null
                    For i As Integer = 0 To ObjectCount - 1 'Check that the objects allow interaction
                        If Objects(i).Affected Then 'If one object can be affected by the field
                            Return True
                        End If
                    Next
                End If
            End If

            'Electrostatic
            If Config.Forces.ElectroStatic.Enabled Then
                If ObjectCount >= 2 Then
                    For i As Integer = 0 To ObjectCount - 1 'Check that the objects allow interaction
                        If Objects(i).Affected And Objects(i).Charge <> 0 Then 'If one object can be affected by forces and doesn't have a null charge
                            For j As Integer = 0 To ObjectCount - 1 'Check that at least one object can influence
                                If Objects(j).Affects And Objects(j).Charge <> 0 Then
                                    Return True
                                End If
                            Next
                        End If
                    Next
                End If
            End If
        End If
        Return False
    End Function
#End Region

#Region "Render"
    Private Function InitializeRender() As Boolean
        'Create the render device parameters
        Render.Parameters = New PresentParameters With {
            .Windowed = True,
            .SwapEffect = SwapEffect.Discard,
            .EnableAutoDepthStencil = True,
            .AutoDepthStencilFormat = DepthFormat.D16
        }

        'Set VSync
        If Config.Render.Mode < 2 And Config.Render.VSync Then
            Render.Parameters.PresentationInterval = PresentInterval.Default
        Else
            Render.Parameters.PresentationInterval = PresentInterval.Immediate
        End If

        'Create the Device
        If Config.Render.Mode = 0 Then 'Hardware DirectX 9
            Try
                Render.Device = New Device(0, DeviceType.Hardware, Output.Handle, (CreateFlags.HardwareVertexProcessing Or CreateFlags.FpuPreserve), Render.Parameters)
            Catch
                If BeenWarned = False Then
                    MsgBox("Unable to initialize hardware vertex processing, PointMass Simulator will attempt to continue. For best performance please ensure to have a proper graphics accelerator card.", MsgBoxStyle.Critical, "Error")
                    BeenWarned = True
                End If
                Try
                    Render.Device = New Device(0, DeviceType.Hardware, Output.Handle, CreateFlags.SoftwareVertexProcessing Or CreateFlags.FpuPreserve, Render.Parameters)
                Catch
                    Return False
                End Try
            End Try
        ElseIf Config.Render.Mode = 1 Then 'Software DirectX 9
            Try
                Render.Device = New Device(0, DeviceType.Reference, Output.Handle, CreateFlags.HardwareVertexProcessing Or CreateFlags.FpuPreserve, Render.Parameters)
            Catch
                Try
                    Render.Device = New Device(0, DeviceType.Reference, Output.Handle, CreateFlags.SoftwareVertexProcessing Or CreateFlags.FpuPreserve, Render.Parameters)
                Catch
                    Return False
                End Try
            End Try
        Else 'Raytracing
            Try
                Render.Device = New Device(0, DeviceType.Hardware, Output.Handle, CreateFlags.HardwareVertexProcessing Or CreateFlags.FpuPreserve, Render.Parameters)
            Catch
                Try
                    Render.Device = New Device(0, DeviceType.Hardware, Output.Handle, CreateFlags.SoftwareVertexProcessing Or CreateFlags.FpuPreserve, Render.Parameters)
                Catch
                    Try
                        Render.Device = New Device(0, DeviceType.Reference, Output.Handle, CreateFlags.HardwareVertexProcessing Or CreateFlags.FpuPreserve, Render.Parameters)
                    Catch
                        Try
                            Render.Device = New Device(0, DeviceType.Reference, Output.Handle, CreateFlags.SoftwareVertexProcessing Or CreateFlags.FpuPreserve, Render.Parameters)
                        Catch
                            Return False
                        End Try
                    End Try
                End Try
            End Try
        End If

        If Config.Render.Mode < 2 Then ' Using DirectX, not Raytracing
            DXRender.InitializeDXRender(Me)
        Else ' Raytracing
            Render.Device.RenderState.SourceBlend = Blend.SourceAlpha
            Render.Device.RenderState.DestinationBlend = Blend.InvSourceAlpha
            Render.Device.RenderState.AlphaBlendEnable = True
        End If

        'Trash the parameters
        Render.Parameters = Nothing

        Return True
    End Function

    Public Function GetRenderThreadCount() As Integer
        Return RenderThread.Length
    End Function
#End Region

End Class
