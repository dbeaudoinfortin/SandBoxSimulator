Imports System.Windows.Forms
Imports SharpDX.Direct3D9

Public Class SimulationRuntime

#Region "Attributes"
    'Threading
    Private ComputingThread As Thread
    Private RenderThreads() As Thread

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
        RenderThreads = Nothing

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
    Public Function Copy(ByRef other As SimulationRuntime) As Boolean
        '----DEEP COPY----
        If Running = True Or other.Running = True Then
            Return False
        End If

        'Threads
        ComputingThread = Nothing
        RenderThreads = Nothing

        Running = False
        Paused = False

        'Counters
        CalcCounter.Copy(other.CalcCounter)
        RenderCounter.Copy(other.RenderCounter)
        StartTime = other.StartTime

        'Settings
        Config.Copy(other.Config)

        'Objects
        ObjectCount = other.ObjectCount
        ReDim Objects(ObjectCount - 1)
        For i As Integer = 0 To ObjectCount - 1
            Objects(i) = New SimulationObject(other.Objects(i))
        Next

        Return True
    End Function
#End Region

#Region "Simulation Control"
    Private Sub ConvertGroupstoObjects()
        Dim NewObjectCount As Integer

        'Add new objects from the groups
        For GroupIndex As Integer = 0 To Config.ObjectGroups.Count - 1
            Dim Group As SimulationConfigObjectGroup = Config.ObjectGroups(GroupIndex)

            'Determine the number of objects
            NewObjectCount = Group.Number.CalculateEffectiveValue(RandMaker, GroupIndex, Config.ObjectGroups.Count)
            If NewObjectCount < 1 Then NewObjectCount = 1 'Sanity check! 

            'Resize the object array
            Array.Resize(Objects, Objects.Length + NewObjectCount)

            'Create the objects
            For ObjectIndex As Integer = 0 To NewObjectCount - 1

                Objects(ObjectCount) = New SimulationObject With {
                    .Affected = Group.Affected,
                    .Affects = Group.Affects,
                    .Type = Group.Type,
                    .Mass = Group.Mass.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount),
                    .Charge = Group.Charge.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount),
                    .Position = Group.Position.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount),
                    .Velocity = Group.Velocity.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount),
                    .HighlightSharpness = Min(Group.Sharpness.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount), 200), 'double between 0 and 200
                    .Reflectivity = Min(Group.Reflectivity.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount), 100), 'percentage between 0 and 100
                    .RefractiveIndex = Group.RefractiveIndex.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount)
                }

                If Group.Wireframe Then
                    Objects(ObjectCount).DXRenderType = RenderType.Wireframe
                ElseIf Group.Points Then
                    Objects(ObjectCount).DXRenderType = RenderType.Points
                Else
                    Objects(ObjectCount).DXRenderType = RenderType.Solid
                End If

                If Group.Type = ObjectType.Box Or Group.Type = ObjectType.Plane Then
                    Objects(ObjectCount).Size = Group.Size.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount)
                    Objects(ObjectCount).HalfSize = Objects(ObjectCount).Size * 0.5
                    Objects(ObjectCount).Rotation = Group.Rotation.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount)

                    If Config.Collisions.Enabled Then
                        'Precompute a bunch of data that will be useful in collision detection
                        If Group.Type = ObjectType.Box Then
                            Objects(ObjectCount).CollisionData = New BoxCollisionData(Objects(ObjectCount).Rotation, Objects(ObjectCount).HalfSize)
                        Else
                            Objects(ObjectCount).CollisionData = New PlaneCollisionData(Objects(ObjectCount).Rotation, Objects(ObjectCount).HalfSize)
                        End If
                    End If
                ElseIf Group.Type = ObjectType.Sphere Then
                    Objects(ObjectCount).Radius = Group.Radius.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount)
                ElseIf Group.Type = ObjectType.InfinitePlane Then
                    'Always make the normal vector a unit vector to simplify later calculations
                    Objects(ObjectCount).Normal = Group.Normal.CalculateEffectiveValue(RandMaker, ObjectIndex, NewObjectCount).MakeMeUnit()
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
            LightCount = Config.LightConfigs.Count
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
        'The idea is to always produce the same seed on every run so that we have consistent, predicatable results
        RandMaker.Seed = Config.GetUniqueSeed()
        RandMaker.Restart()

        ConvertGroupstoObjects()
        ConvertLightConfigstoLights()

        'Resize the output display
        Output.ClientSize = New Size(Config.Render.Width, Config.Render.Height)

        'Set the camera's initial state based on the configuration 
        Camera.Intitialize(Config.Camera, Config.Render.Width, Config.Render.Height, Config.Render.Mode = 2)

        'Determine the number of threads that will be needed
        Dim doIntegration As Boolean = NeedIntegration()
        Dim compNumber As Integer = If(doIntegration Or NeedBasicCompute() = True, 1, 0)
        Dim renderThreadCount As Integer

        If Config.Render.RenderThreads = -1 Then
            renderThreadCount = CPUNumber - compNumber
        Else
            renderThreadCount = Config.Render.RenderThreads
        End If

        If renderThreadCount < 1 Then
            renderThreadCount = 1
        End If

        'Initialize render output and create all the DirectX objects
        'Note: this must be done after the number of render threads is calculated
        If InitializeRender(renderThreadCount) = False Then
            MsgBox("Unable to initialize Render output. Verify that Render Mode has been set correctly.", MsgBoxStyle.Critical, "Error")
            StopSimulation()
            ControlPanel.EndSimulationForm() ' May need to reset the form
            Exit Sub
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
        SetThreads(compNumber, renderThreadCount, doIntegration)
    End Sub
    Public Sub StopSimulation()
        Running = False
        Paused = False

        ControlPanel.StatusUpdate.Enabled = False
        Output.CameraUpdate.Enabled = False

        'Wait until the threads have finished
        'TODO: more forcefully end the threads, especially the raytracing
        If Not IsNothing(ComputingThread) Then
            While (ComputingThread.IsAlive)
                Thread.Sleep(10)
            End While
            ComputingThread = Nothing
        End If

        If Not IsNothing(RenderThreads) Then
            For Each RenderThread As Thread In RenderThreads
                If Not IsNothing(RenderThread) Then
                    While (RenderThread.IsAlive)
                        Thread.Sleep(10)
                    End While
                End If
            Next
            ReDim RenderThreads(0)
        End If

        'Delete all the DirectX objects
        TearDownRender()
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
            ReDim Me.RenderThreads(0)
            Me.RenderThreads(0) = New Thread(AddressOf (New DXRender(Me)).DoDXRender) With {
                .Name = "DXRender",
                .IsBackground = True
            }

            Me.RenderThreads(0).Start()
        Else
            ReDim Me.RenderThreads(RenderThreads - 1)
            For i = 0 To RenderThreads - 1
                Me.RenderThreads(i) = New Thread(AddressOf (New RayRender(Me)).DoRayRender) With {
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
                Me.RenderThreads(i).Start()
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

    Private Sub TearDownRender()
        If Config.Render.Mode < 2 Then 'DirectX mode
            'Trash all objects
            For i = 0 To ObjectCount - 1
                If Not IsNothing(Objects(i).DXRenderData) Then
                    If Not IsNothing(Objects(i).DXRenderData.Mesh) Then
                        Objects(i).DXRenderData.Mesh.Dispose()
                    End If
                    Objects(i).DXRenderData.Material = Nothing
                    Objects(i).DXRenderData.RotationMatrix = Nothing
                End If
            Next
        End If

        'Trash the device
        If Not IsNothing(Render.Device) Then
            Render.Device.Dispose()
            Render.Device = Nothing
        End If

        'Trash the Direct3D object
        If Not IsNothing(Render.Direct3D) Then
            Render.Direct3D.Dispose()
            Render.Direct3D = Nothing
        End If
    End Sub
    Private Function InitializeRender(renderThreadCount As Integer) As Boolean
        Render.Direct3D = New Direct3D

        'Create the render device parameters
        Render.Parameters = New PresentParameters With {
            .Windowed = True,
            .SwapEffect = SwapEffect.Discard,
            .EnableAutoDepthStencil = True,
            .AutoDepthStencilFormat = Format.D16
        }

        'Set VSync - DirectX only
        If Config.Render.Mode < 2 AndAlso Config.Render.VSync Then
            Render.Parameters.PresentationInterval = PresentInterval.Default
        Else
            Render.Parameters.PresentationInterval = PresentInterval.Immediate
        End If

        Dim deviceType As DeviceType
        Dim deviceCreateFlags As CreateFlags
        If Config.Render.Mode = 1 Then
            deviceType = DeviceType.Reference
            deviceCreateFlags = CreateFlags.SoftwareVertexProcessing
        Else
            deviceType = DeviceType.Hardware
            deviceCreateFlags = CreateFlags.HardwareVertexProcessing
        End If

        deviceCreateFlags = deviceCreateFlags Or CreateFlags.FpuPreserve

        'Multi-Threaded Raytracing
        If Config.Render.Mode = 2 AndAlso renderThreadCount > 1 Then
            deviceCreateFlags = deviceCreateFlags Or CreateFlags.Multithreaded
        End If

        'Create the Device
        Try
            Render.Device = New Device(Render.Direct3D, 0, deviceType, Output.Handle, deviceCreateFlags, Render.Parameters)
        Catch e As Exception
            MsgBox("Unable to initialize DirectX 9 device: " & e.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try

        If Config.Render.Mode < 2 Then ' Using DirectX, not Raytracing
            DXRender.InitializeDXRender(Me)
        Else ' Raytracing
            RayRender.InitializeRayRender(Me)
        End If

        'Trash the parameters
        Render.Parameters = Nothing

        Return True
    End Function

    Public Function GetRenderThreadCount() As Integer
        Return RenderThreads.Length
    End Function
#End Region

End Class
