Imports System.Windows.Forms

Public Class SimulationRuntime

#Region "Attributes"
    'Mutexes/Locks
    Private ReadOnly LockRayData As New Object
    Private ReadOnly LockRayMulti As New Object
    Private ReadOnly LockDXRender As New Object

    'Threading
    Private ComputingThread As Thread
    Private RenderThread() As Thread

    'Run State
    Private StartTime As Long
    Public Running As Boolean
    Private Paused As Boolean

    'Counters
    Public CalcCounter As CalculationCounter
    Public RenderCounter As CalculationCounter

    'Forces
    Private Ec As Double

    'Camera
    Public Camera As SimulationCamera

    'Render
    Public Render As SimulationRender

    'Simulation Objects
    Private ObjectCount As Integer
    Private Objects() As SimulationObject

    'Random Generator
    Private ReadOnly RandMaker As RandNumber

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
        For GroupIndex As Integer = 0 To Config.GroupCount - 1
            Dim Group As SimulationConfigObjectGroup = Config.Groups(GroupIndex)

            'Determine the number of objects
            NewObjectCount = Group.Number.CalculateEffectiveValue(RandMaker, GroupIndex, Config.GroupCount)
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
                    .Mass = Group.Mass.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount),
                    .Charge = Group.Charge.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount),
                    .Position = Group.Position.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount),
                    .Velocity = Group.Velocity.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount),
                    .Transparency = Min(Group.Transparency.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount), 255), 'byte between 0 and 255
                    .HighlightColor = Group.Highlight.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount),
                    .HighlightSharpness = Min(Group.Sharpness.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount), 200), 'double between 0 and 200
                    .Reflectivity = Min(Group.Reflectivity.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount), 100), 'percentage between 0 and 100
                    .RefractiveIndex = Group.RefractiveIndex.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount)
                }

                If Group.Type = ObjectType.Box Then
                    Objects(ObjectCount).Size = Group.Size.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount)
                    Objects(ObjectCount).Rotation = Group.Rotation.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount)
                ElseIf Group.Type = ObjectType.Sphere Then
                    Objects(ObjectCount).Radius = Group.Radius.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount)
                ElseIf Group.Type = ObjectType.InfinitePlane Then
                    'Always make the normal vector a unit vector to simplify later calculations
                    Objects(ObjectCount).Normal = Group.Normal.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount).MakeMeUnit()

                    'ROTATION - Calculate rotation based on the normal vector
                    If Objects(ObjectCount).Normal = New XYZ(0, 1, 0) Then
                        Objects(ObjectCount).Rotation = New XYZ
                    Else
                        'TODO finish calculation the roation of infite planes
                        'Debug.Print(Acos(Objects(ObjectCount).Normal.Dot(New XYZ(0, 0, 1))).ToString)
                        'Objects(ObjectCount).Rotation = New XYZ(Acos(Objects(ObjectCount).Normal.Dot(New XYZ(0, 1, 0))), Acos(Objects(ObjectCount).Normal.Dot(New XYZ(0, 0, 1))), Acos(Objects(ObjectCount).Normal.Dot(New XYZ(1, 0, 0))))
                    End If
                End If

                'COLOR - Applies to all Object Types
                'Apply the object colour based on the base colour and the transparency
                Dim ObjectColor As Color = Group.Color.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount)
                Objects(ObjectCount).Color = Color.FromArgb(ToByte(Objects(ObjectCount).Transparency), ObjectColor.R, ObjectColor.G, ObjectColor.B)

                'Total number of objects created 
                ObjectCount += 1
            Next
        Next
    End Sub
    Public Sub RunSimulation()
        'Clear flags
        Paused = False
        Running = True

        'Reinitialize the random number generator
        RandMaker.Seed = Config.GetUniqueSeed()
        RandMaker.Restart()

        ConvertGroupstoObjects()

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
        Dim CompNumber As Integer
        If NeedCompute() = True Then
            CompNumber = 1
        Else
            CompNumber = 0
        End If

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
        SetThreads(CompNumber, RenderNumber)
    End Sub
    Public Function IsPaused() As Boolean
        Return Paused
    End Function
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

#Region "Object Breaking"
    Private Sub DoBreak(ByRef Index As Integer)
        'Variables used in the breaking
        Dim SkewDirection As Double  ' Determines the direction of the distribution curve
        Dim BreakNumber As Integer 'Determines the number of resulting objects
        Dim NewObjects(Config.Collisions.AddMax) As SimulationObject 'Temporarily holds the objects while they are being created
        Dim MassAssigned(Config.Collisions.AddMax) As Double 'A random amount of mass that is assigned to each object
        Dim VolumeAssigned(Config.Collisions.AddMax) As Double 'A random amount of volume that is assigned to each object
        Dim VelocityComponents(Config.Collisions.AddMax) As XYZ 'The random distribution of the velocity acroos all three components
        Dim VelocityMagnitude(Config.Collisions.AddMax) As Double 'The magnitude of the velocity in all three components
        Dim TotalMass As Double 'The total amount of mass that has been assigned to the new objects
        Dim TotalVelocityMagnitude As Double 'The total amount of velocity that has been assigned to each component
        Dim VelocityMagnitudeI As Double
        Dim VelocityI As XYZ
        Dim VelocityJ As XYZ
        Dim VelocityK As XYZ
        Dim RadiusTemp As Double
        Dim TessNumber As Integer
        Dim TessBox As New SimulationObject
        Dim OldVolume As Double

        'Make sure there is room for more objects
        If ObjectCount >= Config.Settings.MaxObjects Then Exit Sub

        'Determine what distribution curve will be used
        SkewDirection = RandMaker.GetNext
        If SkewDirection = 0.5 Then
            BreakNumber = Config.Collisions.AddAvg
        ElseIf SkewDirection < 0.5 Then
            BreakNumber = ToInt32(RandMaker.GetNextSkewed(Config.Collisions.AddAvg, Config.Collisions.AddMin))
        Else
            BreakNumber = ToInt32(RandMaker.GetNextSkewed(Config.Collisions.AddAvg, Config.Collisions.AddMax))
        End If

        'Verify reasonable results
        If BreakNumber < Config.Collisions.AddMin Then
            BreakNumber = Config.Collisions.AddMin
        ElseIf BreakNumber > Config.Collisions.AddMax Then
            BreakNumber = Config.Collisions.AddMax
        End If
        If ObjectCount - 1 + BreakNumber > Config.Settings.MaxObjects Then
            BreakNumber = Config.Settings.MaxObjects - ObjectCount + 1
        End If

        'Calculate 3 perpendicular unit vectors
        VelocityI = Objects(Index).Velocity
        VelocityMagnitudeI = VelocityI.Magnitude
        VelocityI /= VelocityMagnitudeI
        VelocityJ = VelocityI.Perpendicular
        VelocityK = VelocityI.Cross(VelocityJ)
        VelocityMagnitudeI *= BreakNumber

        'CREATE NEW OBJECTS AND ASSIGN NON-RANDOM PARAMETERS
        For z = 0 To BreakNumber - 1
            NewObjects(z) = New SimulationObject
            NewObjects(z).Affected = Objects(Index).Affected
            NewObjects(z).Affects = Objects(Index).Affects
            NewObjects(z).HighlightColor = Objects(Index).HighlightColor
            NewObjects(z).HighlightSharpness = Objects(Index).HighlightSharpness
            NewObjects(z).Reflectivity = Objects(Index).Reflectivity
            NewObjects(z).RefractiveIndex = Objects(Index).RefractiveIndex
            NewObjects(z).Transparency = Objects(Index).Transparency
            NewObjects(z).Wireframe = Objects(Index).Wireframe
            NewObjects(z).Type = Objects(Index).Type
            NewObjects(z).Color = Objects(Index).Color
            NewObjects(z).Rotation.Copy(Objects(Index).Rotation)
            VelocityMagnitude(z) = RandMaker.GetNext 'Assign a random amount of velocity
            TotalVelocityMagnitude += VelocityMagnitude(z)
            VelocityComponents(z) = New XYZ(RandMaker.GetNext, RandMaker.GetNext, RandMaker.GetNext) 'Assign a random direction to the velocity
            If RandMaker.GetNext > 0.5 Then VelocityComponents(z).Y = -VelocityComponents(z).Y
            If RandMaker.GetNext > 0.5 Then VelocityComponents(z).Z = -VelocityComponents(z).Z
        Next

        'ASSIGN VELOCITY
        For Z = 0 To BreakNumber - 1
            VelocityMagnitude(Z) /= TotalVelocityMagnitude 'Find each object's fraction of the total velocity assign
            VelocityMagnitude(Z) *= VelocityMagnitudeI 'Multiply the fraction by the velocity of the original object
            NewObjects(Z).Velocity.X = (VelocityComponents(Z).X * VelocityI.X) + (VelocityComponents(Z).Y * VelocityJ.X) + (VelocityComponents(Z).Z * VelocityK.X)
            NewObjects(Z).Velocity.Y = (VelocityComponents(Z).X * VelocityI.Y) + (VelocityComponents(Z).Y * VelocityJ.Y) + (VelocityComponents(Z).Z * VelocityK.Y)
            NewObjects(Z).Velocity.Z = (VelocityComponents(Z).X * VelocityI.Z) + (VelocityComponents(Z).Y * VelocityJ.Z) + (VelocityComponents(Z).Z * VelocityK.Z)
            NewObjects(Z).Velocity.MakeUnit()
            NewObjects(Z).Velocity *= VelocityMagnitude(Z)
        Next

        'ASSIGN SIZE, POSITION AND MASS
        If Objects(Index).Type = ObjectType.Box Then 'The object is a Box

            'Tesselation of the original box.
            For i = 0 To BreakNumber - 2 'I is the cut number, always 1 less than breaknumber
                If i = 0 Then 'First cut
                    TessellateBox(NewObjects(0), NewObjects(1), Objects(Index))
                Else
                    TessNumber = ToInt32(i * RandMaker.GetNext) 'Get a random box
                    TessBox.Copy(NewObjects(TessNumber)) 'Copy that box 
                    TessellateBox(NewObjects(TessNumber), NewObjects(i + 1), TessBox)
                End If
            Next

            'Assign mass to each new box based on thier volume
            OldVolume = 1 / (Objects(Index).Size.X * Objects(Index).Size.Y * Objects(Index).Size.Z)
            For r = 0 To BreakNumber - 1
                MassAssigned(r) = (NewObjects(r).Size.X * NewObjects(r).Size.Y * NewObjects(r).Size.Z) * OldVolume 'Fraction of the old mass that each new box will get
                NewObjects(r).Mass = MassAssigned(r) * Objects(Index).Mass
            Next

            'ASSIGN CHARGE BASED ON MASS
            If Config.Forces.ElectroStatic.Enabled Then
                For Z = 0 To BreakNumber - 1
                    NewObjects(Z).Charge = MassAssigned(Z) * Objects(Index).Charge 'Assign the charge to the final objects
                Next
            End If
        Else 'The object is a Sphere
            'Assign mass to each objects
            TotalMass = 0
            For z = 0 To BreakNumber - 1
                MassAssigned(z) = RandMaker.GetNext
                TotalMass += MassAssigned(z)
            Next

            'Apply mass and position
            For Z = 0 To BreakNumber - 1
                MassAssigned(Z) /= TotalMass 'Find each object's fraction of the total mass
                NewObjects(Z).Mass = MassAssigned(Z) * Objects(Index).Mass 'Assign the masses to the final object
                NewObjects(Z).Radius = (MassAssigned(Z) ^ 0.33333333333333331) * Objects(Index).Radius
                RadiusTemp = Objects(Index).Radius - NewObjects(Z).Radius
                If RandMaker.GetNext() > 0.5 Then RadiusTemp = -RadiusTemp
                NewObjects(Z).Position = Objects(Index).Position + (RadiusTemp * NewObjects(Z).Velocity.GetNewUnit)
            Next

            'ASSIGN CHARGE BASED ON MASS
            If Config.Forces.ElectroStatic.Enabled Then
                For Z = 0 To BreakNumber - 1
                    NewObjects(Z).Charge = MassAssigned(Z) * Objects(Index).Charge 'Assign the charge to the final objects
                Next
            End If
        End If



        'COPY THE NEW OBJECTS OVER
        Render.RenderLock.EnterWriteLock() ' Make sure the Renderer isn't loading the data 
        Objects(Index).Copy(NewObjects(0)) 'Copy over the new objects into the simulation
        For Z = 1 To BreakNumber - 1
            Objects(ObjectCount) = New SimulationObject
            Objects(ObjectCount).Copy(NewObjects(Z))
            ObjectCount += 1
        Next
        Render.RenderLock.ExitWriteLock()
    End Sub
    Private Sub TessellateBox(ByRef NewObject1 As SimulationObject, ByRef NewObject2 As SimulationObject, ByRef OldObject As SimulationObject)
        Dim TessX As Double = RandMaker.GetNext
        Dim TessY As Double = RandMaker.GetNext
        Dim TessZ As Double = RandMaker.GetNext
        If TessX >= TessY And TessX >= TessZ Then ' X is biggest
            NewObject1.Size.X = OldObject.Size.X * TessX
            NewObject2.Size.X = OldObject.Size.X * (1 - TessX)
            NewObject1.Size.Y = OldObject.Size.Y
            NewObject2.Size.Y = OldObject.Size.Y
            NewObject1.Size.Z = OldObject.Size.Z
            NewObject2.Size.Z = OldObject.Size.Z
            NewObject1.Position.X = OldObject.Position.X + 0.5 * (NewObject1.Size.X - OldObject.Size.X)
            NewObject2.Position.X = OldObject.Position.X + 0.5 * (NewObject2.Size.X + OldObject.Size.X)
            NewObject1.Position.Y = OldObject.Position.Y
            NewObject2.Position.Y = OldObject.Position.Y
            NewObject1.Position.Z = OldObject.Position.Z
            NewObject2.Position.Z = OldObject.Position.Z
        ElseIf TessY >= TessX And TessY >= TessZ Then 'Y is biggest
            NewObject1.Size.X = OldObject.Size.X
            NewObject2.Size.X = OldObject.Size.X
            NewObject1.Size.Y = OldObject.Size.Y * TessY
            NewObject2.Size.Y = OldObject.Size.Y * (1 - TessY)
            NewObject1.Size.Z = OldObject.Size.Z
            NewObject2.Size.Z = OldObject.Size.Z
            NewObject1.Position.X = OldObject.Position.X
            NewObject2.Position.X = OldObject.Position.X
            NewObject1.Position.Y = OldObject.Position.Y + 0.5 * (NewObject1.Size.Y - OldObject.Size.Y)
            NewObject2.Position.Y = OldObject.Position.Y + 0.5 * (NewObject2.Size.Y + OldObject.Size.Y)
            NewObject1.Position.Z = OldObject.Position.Z
            NewObject2.Position.Z = OldObject.Position.Z
        Else 'Z is biggest
            NewObject1.Size.X = OldObject.Size.X
            NewObject2.Size.X = OldObject.Size.X
            NewObject1.Size.Y = OldObject.Size.Y
            NewObject2.Size.Y = OldObject.Size.Y
            NewObject1.Size.Z = OldObject.Size.Z * TessZ
            NewObject2.Size.Z = OldObject.Size.Z * (1 - TessZ)
            NewObject1.Position.X = OldObject.Position.X
            NewObject2.Position.X = OldObject.Position.X
            NewObject1.Position.Y = OldObject.Position.Y
            NewObject2.Position.Y = OldObject.Position.Y
            NewObject1.Position.Z = OldObject.Position.Z + 0.5 * (NewObject1.Size.Z - OldObject.Size.Z)
            NewObject2.Position.Z = OldObject.Position.Z + 0.5 * (NewObject2.Size.Z + OldObject.Size.Z)
        End If
    End Sub
#End Region

#Region "Computation"
    Private Function GetFarthestObject() As Integer
        Dim Current As Integer
        For i As Integer = 1 To ObjectCount - 1
            If Objects(i).CameraDistance >= Objects(Current).CameraDistance Then
                Current = i
            End If
        Next
        Objects(Current).CameraDistance = 0
        Return Current
    End Function

    Private Function NeedCompute() As Boolean
        'Check if integration is needed
        If NeedIntegration() Then Return True

        'Check if any of the objects have a velocity.
        For i As Integer = 0 To ObjectCount - 1
            If Not Objects(i).Velocity.isZero Then Return True
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
                        If Not Objects(i).Velocity.isZero Then 'If that object has a velocity
                            Return True
                        End If
                    End If
                Next
            End If

            'Uniform field
            If Config.Forces.Field.Enabled Then
                If Not Config.Forces.Field.Acceleration.isZero Then ' Field isn't null
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
    Private Function NeedTransparency() As Boolean
        For i = 0 To ObjectCount - 1
            If Objects(i).Transparency <> 255 Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub DoComputeNoIntegration(timeStep As Double)
        If Config.Collisions.Enabled Then
            If Config.Collisions.Interpolate Then
                Do While Running
                    For i = 0 To ObjectCount - 1
                        Objects(i).OldPosition.Copy(Objects(i).Position)
                    Next

                    Render.RenderLock.EnterWriteLock()
                    For i = 0 To ObjectCount - 1
                        'TODO: Is is even marginally faster to do the multiplation outside the lock?
                        Objects(i).Position += Objects(i).Velocity * timeStep
                    Next
                    Render.RenderLock.ExitWriteLock()

                    DoCollisions() 'Collisions must be after
                    ComputationControl()
                Loop
            Else
                'Collisions but not interpolation
                Do While Running
                    DoCollisions()
                    Render.RenderLock.EnterWriteLock()
                    For i = 0 To ObjectCount - 1
                        Objects(i).Position += Objects(i).Velocity * timeStep
                    Next
                    Render.RenderLock.ExitWriteLock()
                    ComputationControl()
                Loop
            End If
        Else
            'No collisions at all
            Do While Running
                Render.RenderLock.EnterWriteLock()
                For i = 0 To ObjectCount - 1
                    Objects(i).Position += Objects(i).Velocity * timeStep
                Next
                Render.RenderLock.ExitWriteLock()
                ComputationControl()
            Loop
        End If
    End Sub
    Private Sub DoComputeEuler(timeStep As Double)
        If Config.Collisions.Enabled And Config.Collisions.Interpolate Then
            Do While Running
                DoForces()
                For i = 0 To ObjectCount - 1
                    Objects(i).OldPosition.Copy(Objects(i).Position)
                    Objects(i).Velocity += Objects(i).Acceleration * timeStep
                Next

                'Only the position of the objects actually needs to be locked
                Render.RenderLock.EnterWriteLock()
                For i = 0 To ObjectCount - 1
                    Objects(i).Position += Objects(i).Velocity * timeStep
                Next
                Render.RenderLock.ExitWriteLock()

                DoCollisions()
                ComputationControl()
            Loop
        ElseIf Config.Collisions.Enabled Then
            Do While Running
                DoCollisions()
                DoForces()
                For i = 0 To ObjectCount - 1
                    Objects(i).Velocity += Objects(i).Acceleration * timeStep
                Next

                Render.RenderLock.EnterWriteLock()
                For i = 0 To ObjectCount - 1
                    Objects(i).Position += Objects(i).Velocity * timeStep
                Next
                Render.RenderLock.ExitWriteLock()

                ComputationControl()
            Loop
        Else
            Do While Running
                DoForces()
                For i = 0 To ObjectCount - 1
                    Objects(i).Velocity += Objects(i).Acceleration * timeStep
                Next

                Render.RenderLock.EnterWriteLock()
                For i = 0 To ObjectCount - 1
                    Objects(i).Position += Objects(i).Velocity * timeStep
                Next
                Render.RenderLock.ExitWriteLock()

                ComputationControl()
            Loop
        End If
    End Sub

    Private Sub DoComputeVerlet(timeStep As Double)
        Dim HalfT As Double = 0.5 * timeStep
        Dim HalfTSqd As Double = HalfT * timeStep

        If Config.Collisions.Enabled And Config.Collisions.Interpolate Then
            DoForces() 'Initial forces

            Do While Running

                For i = 0 To ObjectCount - 1
                    Objects(i).OldPosition.Copy(Objects(i).Position)
                Next

                Render.RenderLock.EnterWriteLock()
                For i = 0 To ObjectCount - 1
                    Objects(i).Position += (Objects(i).Velocity * timeStep) + (HalfTSqd * Objects(i).Acceleration)
                Next
                Render.RenderLock.ExitWriteLock()

                For i = 0 To ObjectCount - 1
                    Objects(i).Velocity += HalfT * Objects(i).Acceleration
                Next

                DoForces()

                For i = 0 To ObjectCount - 1
                    Objects(i).Velocity += Objects(i).Acceleration * HalfT
                Next

                DoCollisions()
                ComputationControl()
            Loop
        ElseIf Config.Collisions.Enabled Then
            DoForces() 'Initial forces
            Do While Running
                DoCollisions()

                Render.RenderLock.EnterWriteLock()
                For i = 0 To ObjectCount - 1
                    Objects(i).Position += (Objects(i).Velocity * timeStep) + (HalfTSqd * Objects(i).Acceleration)
                Next
                Render.RenderLock.ExitWriteLock()

                For i = 0 To ObjectCount - 1
                    Objects(i).Velocity += HalfT * Objects(i).Acceleration
                Next

                DoForces()

                For i = 0 To ObjectCount - 1
                    Objects(i).Velocity += Objects(i).Acceleration * HalfT
                Next

                ComputationControl()
            Loop
        Else
            DoForces() 'Initial forces
            Do While Running

                Render.RenderLock.EnterWriteLock()
                For i = 0 To ObjectCount - 1
                    Objects(i).Position += (Objects(i).Velocity * timeStep) + (HalfTSqd * Objects(i).Acceleration)

                Next
                Render.RenderLock.ExitWriteLock()

                For i = 0 To ObjectCount - 1
                    Objects(i).Velocity += HalfT * Objects(i).Acceleration
                Next

                DoForces()

                For i = 0 To ObjectCount - 1
                    Objects(i).Velocity += Objects(i).Acceleration * HalfT
                Next

                ComputationControl()
            Loop
        End If
    End Sub

    Private Sub DoCompute4thSymplectic(timeStep As Double)
        Const b As Double = 2 ^ (1 / 3)
        Const a As Double = 2 - b
        Const x0 As Double = -b / a
        Const x1 As Double = 1 / a

        Dim HalfT As Double = 0.5 * timeStep
        Dim d() As Double = {timeStep * x1, timeStep * x0, timeStep * x1}
        Dim c() As Double = {x1 * HalfT, (x0 + x1) * HalfT, (x0 + x1) * HalfT, x1 * HalfT}

        If Config.Collisions.Enabled And Config.Collisions.Interpolate Then
            Do While Running
                For i = 0 To ObjectCount - 1
                    Objects(i).OldPosition.Copy(Objects(i).Position)
                Next
                For j = 0 To 2
                    Render.RenderLock.EnterWriteLock()
                    For i = 0 To ObjectCount - 1
                        Objects(i).Position += c(j) * Objects(i).Velocity
                    Next
                    Render.RenderLock.ExitWriteLock()
                    DoForces()
                    For i = 0 To ObjectCount - 1
                        Objects(i).Velocity += d(j) * Objects(i).Acceleration
                    Next
                Next
                Render.RenderLock.EnterWriteLock()
                For i = 0 To ObjectCount - 1
                    Objects(i).Position += c(3) * Objects(i).Velocity
                Next
                Render.RenderLock.ExitWriteLock()
                DoCollisions()
                ComputationControl()
            Loop
        ElseIf Config.Collisions.Enabled Then
            DoCollisions()
            For j = 0 To 2
                Render.RenderLock.EnterWriteLock()
                For i = 0 To ObjectCount - 1
                    Objects(i).Position += c(j) * Objects(i).Velocity
                Next
                Render.RenderLock.ExitWriteLock()
                DoForces()
                For i = 0 To ObjectCount - 1
                    Objects(i).Velocity += d(j) * Objects(i).Acceleration
                Next
            Next
            Render.RenderLock.EnterWriteLock()
            For i = 0 To ObjectCount - 1
                Objects(i).Position += c(3) * Objects(i).Velocity
            Next
            Render.RenderLock.ExitWriteLock()
            ComputationControl()
        Else
            Do While Running
                For j = 0 To 2
                    Render.RenderLock.EnterWriteLock()
                    For i = 0 To ObjectCount - 1
                        Objects(i).Position += c(j) * Objects(i).Velocity
                    Next
                    Render.RenderLock.ExitWriteLock()

                    DoForces()
                    For i = 0 To ObjectCount - 1
                        Objects(i).Velocity += d(j) * Objects(i).Acceleration
                    Next
                Next

                Render.RenderLock.EnterWriteLock()
                For i = 0 To ObjectCount - 1
                    Objects(i).Position += c(3) * Objects(i).Velocity
                Next
                Render.RenderLock.ExitWriteLock()
                ComputationControl()
            Loop
        End If
    End Sub
    Private Sub DoCompute6thSymplectic(timeStep As Double)

        Const w1 As Double = -1.17767998417887
        Const w2 As Double = 0.235573213359357
        Const w3 As Double = 0.78451361047756
        Const w0 As Double = 1 - (2 * (w1 + w2 + w3))

        Dim HalfT As Double = 0.5 * timeStep
        Dim d() As Double = {timeStep * w3, timeStep * w2, timeStep * w1, timeStep * w0, timeStep * w1, timeStep * w2, timeStep * w3}
        Dim c() As Double = {w3 * HalfT, (w3 + w2) * HalfT, (w2 + w1) * HalfT, (w1 + w0) * HalfT, (w1 + w0) * HalfT, (w2 + w1) * HalfT, (w3 + w2) * HalfT, w3 * HalfT}

        If Config.Collisions.Enabled And Config.Collisions.Interpolate Then
            Do While Running
                For i = 0 To ObjectCount - 1
                    Objects(i).OldPosition.Copy(Objects(i).Position)
                Next
                For j = 0 To 6
                    Render.RenderLock.EnterWriteLock()
                    For i = 0 To ObjectCount - 1
                        Objects(i).Position += c(j) * Objects(i).Velocity
                    Next
                    Render.RenderLock.ExitWriteLock()
                    DoForces()
                    For i = 0 To ObjectCount - 1
                        Objects(i).Velocity += d(j) * Objects(i).Acceleration
                    Next
                Next
                Render.RenderLock.EnterWriteLock()
                For i = 0 To ObjectCount - 1
                    Objects(i).Position += c(7) * Objects(i).Velocity
                Next
                Render.RenderLock.ExitWriteLock()
                DoCollisions()
                ComputationControl()
            Loop
        Else
            Do While Running
                For j = 0 To 6
                    Render.RenderLock.EnterWriteLock()
                    For i = 0 To ObjectCount - 1
                        Objects(i).Position += c(j) * Objects(i).Velocity
                    Next
                    Render.RenderLock.ExitWriteLock()
                    DoForces()
                    For i = 0 To ObjectCount - 1
                        Objects(i).Velocity += d(j) * Objects(i).Acceleration
                    Next
                Next
                Render.RenderLock.EnterWriteLock()
                For i = 0 To ObjectCount - 1
                    Objects(i).Position += c(7) * Objects(i).Velocity
                Next
                Render.RenderLock.ExitWriteLock()
                If Config.Collisions.Enabled Then DoCollisions()
                ComputationControl()
            Loop
        End If
    End Sub
    Private Sub DoCompute()
        'If breakages might happen then make room for additial objects that might be needed
        If Config.Collisions.Breakable Then
            Array.Resize(Me.Objects, Config.Settings.MaxObjects)
        End If

        'Pre-calculate Permitivity value
        Ec = 1 / (4 * PI * Eo * Config.Forces.ElectroStatic.Permittivity)

        If Not NeedIntegration() Then
            DoComputeNoIntegration(Config.Settings.TimeStep)
            Return
        End If

        If Config.Settings.IntegrationMethod = 0 Then
            DoComputeEuler(Config.Settings.TimeStep)
        ElseIf Config.Settings.IntegrationMethod = 1 Then
            DoComputeVerlet(Config.Settings.TimeStep)
        ElseIf Config.Settings.IntegrationMethod = 2 Then
            DoCompute4thSymplectic(Config.Settings.TimeStep)
        ElseIf Config.Settings.IntegrationMethod = 3 Then
            DoCompute6thSymplectic(Config.Settings.TimeStep)
        End If
    End Sub
    Private Sub DoForces()
        Dim QtoIDistance As Double
        Dim AccMagi As Double
        Dim AccMagq As Double
        Dim Coeff As New XYZ
        Dim DragMultiplier As Double
        Dim ReynoldsNumber As New XYZ
        Dim ReynoldsMultiplier As Double
        Dim StokesDragConst As Double
        Dim QtoIPosistion As New XYZ
        Dim QtoIDistanceSqd As Double
        Dim Ectemp As Double
        Dim I As Integer
        Dim Q As Integer
        '~~~~~~~~~~~~~~~~~~~GLOBAL FORCES~~~~~~~~~~~~~~~~~
        If Config.Forces.Field.Enabled Then
            'Apply field
            For I = 0 To ObjectCount - 1
                If Objects(I).Affected Then
                    Objects(I).Acceleration.Copy(Config.Forces.Field.Acceleration)
                Else
                    Objects(I).Acceleration.makeZero()
                End If
            Next
        Else
            'Reset acceleration to zero
            For I = 0 To ObjectCount - 1
                Objects(I).Acceleration.makeZero()
            Next
        End If
        '~~~~~~~~~~~~~OBJECT ENVIRONMENT FORCES~~~~~~~~~~~~~~
        If Config.Forces.Drag.Enabled Then
            For I = 0 To ObjectCount - 1
                If Objects(I).Affected Then
                    ReynoldsMultiplier = (Config.Forces.Drag.Density * Objects(I).Radius * 2) / Config.Forces.Drag.Viscosity
                    StokesDragConst = (6 * PI * Config.Forces.Drag.Viscosity * Objects(I).Radius) / Objects(I).Mass
                    DragMultiplier = (0.5 * Config.Forces.Drag.Density * Config.Forces.Drag.DragCoeff * Math.PI * Objects(I).Radius * Objects(I).Radius) / Objects(I).Mass
                    ReynoldsNumber = ReynoldsMultiplier * Objects(I).Velocity.Abs
                    If ReynoldsNumber.X < 30 Then
                        Objects(I).Acceleration.X -= StokesDragConst * Objects(I).Velocity.X
                    Else
                        Objects(I).Acceleration.X -= DragMultiplier * Objects(I).Velocity.X * Math.Abs(Objects(I).Velocity.X)
                    End If
                    If ReynoldsNumber.Y < 30 Then
                        Objects(I).Acceleration.Y -= StokesDragConst * Objects(I).Velocity.Y
                    Else
                        Objects(I).Acceleration.Y -= DragMultiplier * Objects(I).Velocity.Y * Math.Abs(Objects(I).Velocity.Y)
                    End If
                    If ReynoldsNumber.Z < 30 Then
                        Objects(I).Acceleration.Z -= StokesDragConst * Objects(I).Velocity.Z
                    Else
                        Objects(I).Acceleration.Z -= DragMultiplier * Objects(I).Velocity.Z * Math.Abs(Objects(I).Velocity.Z)
                    End If
                End If
            Next
        End If

        If Config.Forces.Gravity Or Config.Forces.ElectroStatic.Enabled Then
            '~~~~~~~~~~~~~OBJECT OBJECT FORCES~~~~~~~~~~~~~~
            For I = 0 To ObjectCount - 2
                For Q = I + 1 To ObjectCount - 1
                    If (Objects(I).Affected And Objects(Q).Affects) Or (Objects(Q).Affected And Objects(I).Affects) Then 'If the objects are allowed to interact

                        QtoIPosistion = (Objects(Q).Position - Objects(I).Position)
                        QtoIDistanceSqd = QtoIPosistion.MagnitudeSquared
                        QtoIDistance = Math.Sqrt(QtoIDistanceSqd)
                        Coeff = QtoIPosistion / QtoIDistance

                        '~~~~~~~~~~~~~NEWTONIAN GRAVITY~~~~~~~~~~~~~~
                        If Config.Forces.Gravity Then
                            AccMagi = (G * Objects(Q).Mass) / (QtoIDistanceSqd)
                            AccMagq = (-G * Objects(I).Mass) / (QtoIDistanceSqd)
                            If Objects(I).Affected And Objects(Q).Affects Then
                                Objects(I).Acceleration += AccMagi * Coeff
                            End If
                            If Objects(Q).Affected And Objects(I).Affects Then
                                Objects(Q).Acceleration += AccMagq * Coeff
                            End If
                        End If
                        '~~~~~~~~~~~~~ELECTRONMAGNATISM~~~~~~~~~~~~~~
                        If Config.Forces.ElectroStatic.Enabled Then
                            Ectemp = (Ec * Objects(Q).Charge * Objects(I).Charge)
                            AccMagi = -(Ectemp / (QtoIDistanceSqd * Objects(I).Mass))
                            AccMagq = (Ectemp / (QtoIDistanceSqd * Objects(Q).Mass))
                            If Objects(I).Affected And Objects(Q).Affects Then
                                Objects(I).Acceleration += AccMagi * Coeff
                            End If
                            If Objects(Q).Affected And Objects(I).Affects Then
                                Objects(Q).Acceleration += AccMagq * Coeff
                            End If
                        End If
                    End If
                Next
            Next
        End If
    End Sub
    Private Sub ComputationControl()
        CalcCounter.FullCount += 1
        If Config.Settings.MaxCPS <> 0 Then
            QueryPerformanceCounter(CalcCounter.LimitStart)
            Do
                QueryPerformanceCounter(CalcCounter.LimitStop)
                'TODO this sucks. The frequency can be variable and we should sleep to save power
            Loop Until (CalcCounter.Frequency / (CalcCounter.LimitStop - CalcCounter.LimitStart)) < Config.Settings.MaxCPS
        End If
        If Paused Then
            Do While (Paused)
                Application.DoEvents()
            Loop
        End If
    End Sub
    Private Sub DoCollisions()

        'Interpolation
        Dim QtoIOldPosistion As XYZ
        Dim OldToNewPosition As XYZ
        Dim A As Double
        Dim B As Double
        Dim C As Double
        Dim Discriminant As Double
        Dim Time1 As Double
        Dim Time2 As Double
        Dim CollisionTime As Double
        Dim DidCollide As Boolean

        'Object object
        Dim Q As Integer
        Dim QtoIPosistion As New XYZ
        Dim QtoIDistanceSqd As Double
        Dim TempDouble As Double
        Dim TempDouble3 As Double
        Dim TempDouble4 As Double
        Dim TempDouble5 As Double
        Dim SumofMasses As Double
        Dim SumofRadius As Double
        Dim VI As New XYZ
        Dim VQ As New XYZ
        Dim NewVI As New XYZ
        Dim NewVQ As New XYZ
        Dim DotProductI As Double
        Dim DotProductQ As Double
        Dim DotProductMagI As Double
        Dim DotProductMagQ As Double
        Dim DeltaKineticQ As Double
        Dim DeltaKineticI As Double
        Dim i As Integer

        '~~~~~~~~~~~~~OBJECT OBJECT COLLISION~~~~~~~~~~~~
        For i = 0 To ObjectCount - 2
            For Q = i + 1 To ObjectCount - 1

                If Not Objects(i).Affected Or Not Objects(i).Affects Or Not Objects(Q).Affected Or Not Objects(Q).Affects Then Continue For

                SumofRadius = Objects(i).Radius + Objects(Q).Radius
                QtoIPosistion = Objects(Q).Position - Objects(i).Position
                DidCollide = False

                If Config.Collisions.Interpolate Then

                    'Find the values for the quadratic describing the path of intersection of the objects
                    QtoIOldPosistion = Objects(i).OldPosition - Objects(Q).OldPosition
                    OldToNewPosition = -(QtoIPosistion + QtoIOldPosistion)
                    A = (OldToNewPosition.X * OldToNewPosition.X) + (OldToNewPosition.Y * OldToNewPosition.Y) + (OldToNewPosition.Z * OldToNewPosition.Z)
                    B = -2 * ((OldToNewPosition.X * QtoIOldPosistion.X) + (OldToNewPosition.Y * QtoIOldPosistion.Y) + (OldToNewPosition.Z * QtoIOldPosistion.Z))
                    C = (QtoIOldPosistion.X * QtoIOldPosistion.X) + (QtoIOldPosistion.Y * QtoIOldPosistion.Y) + (QtoIOldPosistion.Z * QtoIOldPosistion.Z) - (SumofRadius * SumofRadius)

                    'Solve the quadratic equation
                    Discriminant = (B * B) - (4 * A * C)
                    If Discriminant = 0 Then 'Glancing collision
                        CollisionTime = B / (2 * A)
                        If CollisionTime >= 0 And CollisionTime <= 1 Then DidCollide = True
                    ElseIf Discriminant > 0 Then ' They interpenetrated
                        TempDouble = 1 / (2 * A)
                        Time1 = (B - Sqrt(Discriminant)) * TempDouble
                        Time2 = (B + Sqrt(Discriminant)) * TempDouble
                        If Time1 >= 0 And Time1 <= 1 Then
                            If Time2 >= 0 And Time2 <= 1 Then
                                If Time1 < Time2 Then
                                    CollisionTime = Time1
                                    DidCollide = True
                                Else
                                    CollisionTime = Time2
                                    DidCollide = True
                                End If
                            Else
                                CollisionTime = Time1
                                DidCollide = True
                            End If
                        Else
                            If Time2 >= 0 And Time2 <= 1 Then
                                CollisionTime = Time2
                                DidCollide = True
                            End If
                        End If
                    End If
                    If DidCollide Then
                        'Move the objects back to where they would have been at the time of the collision
                        Render.RenderLock.EnterWriteLock()
                        Objects(i).Position = ((Objects(i).Position - Objects(i).OldPosition) * CollisionTime) + Objects(i).OldPosition
                        Objects(Q).Position = ((Objects(Q).Position - Objects(Q).OldPosition) * CollisionTime) + Objects(Q).OldPosition
                        Render.RenderLock.ExitWriteLock()
                        'Recalculate thier seperation
                        QtoIPosistion = Objects(Q).Position - Objects(i).Position
                        QtoIDistanceSqd = QtoIPosistion.MagnitudeSquared
                        DotProductI = Objects(i).Velocity.Dot(QtoIPosistion)
                        DotProductQ = Objects(Q).Velocity.Dot(QtoIPosistion)
                    Else
                        'No Collision Occured
                        Continue For
                    End If
                Else
                    'No interpolation
                    QtoIDistanceSqd = QtoIPosistion.MagnitudeSquared
                    If QtoIDistanceSqd > SumofRadius * SumofRadius Then Continue For 'Check that they are touching
                    DotProductI = Objects(i).Velocity.Dot(QtoIPosistion)
                    DotProductQ = Objects(Q).Velocity.Dot(QtoIPosistion)
                    If DotProductQ - DotProductI >= 0 Then Continue For 'Check that the are coming together
                End If

                SumofMasses = Objects(i).Mass + Objects(Q).Mass
                DotProductMagI = DotProductI / QtoIDistanceSqd
                DotProductMagQ = DotProductQ / QtoIDistanceSqd
                VI = DotProductMagI * QtoIPosistion
                VQ = DotProductMagQ * QtoIPosistion
                If Config.Collisions.CoR = 0 Then '~~~~~~~~~~~PLASTIC OBJECT OBJECT COLLISION~~~~~~~~~~~
                    NewVI = ((Objects(Q).Mass * VQ) + (VI * Objects(i).Mass)) / SumofMasses
                    Objects(i).Velocity.Copy(NewVI + (Objects(i).Velocity - VI))
                    Objects(Q).Velocity.Copy(NewVI + (Objects(Q).Velocity - VQ))
                ElseIf Config.Collisions.CoR = 1 Then  '~~~~~~ELASTIC OBJECT OBJECT COLLISION~~~~~~~~~~~
                    TempDouble4 = Objects(i).Mass / SumofMasses
                    TempDouble5 = Objects(Q).Mass / SumofMasses
                    TempDouble = TempDouble4 - TempDouble5
                    Objects(i).Velocity += ((TempDouble5 + TempDouble5) * VQ) + (VI * (TempDouble - 1))
                    Objects(Q).Velocity += ((TempDouble4 + TempDouble4) * VI) - (VQ * (TempDouble + 1))
                Else '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~PARTIAL OBJECT OBJECT COLLISION~~~~~~~~~~~
                    TempDouble4 = Objects(i).Mass / SumofMasses
                    TempDouble5 = Objects(Q).Mass / SumofMasses
                    TempDouble3 = Config.Collisions.CoR + 1
                    Objects(i).Velocity += (TempDouble3 * TempDouble5 * VQ) + (VI * (TempDouble4 - (Config.Collisions.CoR * TempDouble5) - 1))
                    Objects(Q).Velocity += (TempDouble3 * TempDouble4 * VI) + (VQ * (TempDouble5 - (Config.Collisions.CoR * TempDouble4) - 1))
                End If

                If Config.Collisions.Interpolate Then
                    'Move the objects forward by the remaining time
                    Render.RenderLock.EnterWriteLock()
                    Objects(i).Position += Objects(i).Velocity * (Config.Settings.TimeStep * (1 - CollisionTime))
                    Objects(Q).Position += Objects(Q).Velocity * (Config.Settings.TimeStep * (1 - CollisionTime))
                    Render.RenderLock.ExitWriteLock()
                End If

                '~~~~~~~~~~~~~~BREAKABLE OBJECT OBJECT COLLISION~~~~~~~~~~~~
                If Not Config.Collisions.Breakable Or ObjectCount >= Config.Settings.MaxObjects Or Config.Collisions.CoR = 1 Then Continue For

                DeltaKineticI = Math.Abs(VI.MagnitudeSquared + VQ.MagnitudeSquared - Objects(i).Velocity.MagnitudeSquared - Objects(Q).Velocity.MagnitudeSquared)
                DeltaKineticQ = DeltaKineticI
                DeltaKineticI *= Objects(i).Mass
                DeltaKineticQ *= Objects(Q).Mass

                'Determine if Q will break
                If DeltaKineticQ >= Config.Collisions.BreakMax Then
                    DoBreak(Q)
                ElseIf DeltaKineticQ >= Config.Collisions.BreakMin Then
                    If DeltaKineticQ = Config.Collisions.BreakAvg Then
                        If RandMaker.GetNext() > 0.5 Then DoBreak(Q)
                    Else
                        If RandMaker.GetNext < RandMaker.GetProbibility(DeltaKineticQ, Config.Collisions.BreakAvg, Config.Collisions.BreakMin, Config.Collisions.BreakMax) Then DoBreak(Q) 'Get probibility and compare it to a random number
                    End If
                End If

                'Determine if I will break
                If ObjectCount >= Config.Settings.MaxObjects Then Continue For

                If DeltaKineticI >= Config.Collisions.BreakMax Then
                    DoBreak(i)
                ElseIf DeltaKineticI >= Config.Collisions.BreakMin Then
                    If DeltaKineticI = Config.Collisions.BreakAvg Then
                        If RandMaker.GetNext() > 0.5 Then DoBreak(i)
                    Else
                        If RandMaker.GetNext < RandMaker.GetProbibility(DeltaKineticI, Config.Collisions.BreakAvg, Config.Collisions.BreakMin, Config.Collisions.BreakMax) Then DoBreak(i) 'Get probibility and compare it to a random number
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub SetThreads(ByRef ComputeThreads As Integer, ByRef RenderThreads As Integer)
        If ComputeThreads > 0 Then
            ComputingThread = New Thread(AddressOf DoCompute) With {
                .Name = "Compute",
                .IsBackground = True
            }
            ComputingThread.Start()
        End If


        If Config.Render.Mode < 2 Then
            ReDim RenderThread(0)
            RenderThread(0) = New Thread(AddressOf DoDXRender) With {
                .Name = "DXRender",
                .IsBackground = True
            }

            RenderThread(0).Start()
        Else
            ReDim RenderThread(RenderThreads - 1)
            For i = 0 To RenderThreads - 1
                RenderThread(i) = New Thread(AddressOf DoRayRender) With {
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
#End Region

#Region "Render"
    Private Sub RenderControl()

        RenderCounter.FullCount += 1
        'Limit the frame rate 'TODO This doesn't work at all
        If Config.Render.MaxFPS <> 0 And ((Config.Render.Mode = 2) Or (Not Config.Render.VSync)) Then
            QueryPerformanceCounter(RenderCounter.LimitStart)
            Do
                'TODO: Don't spin here, wait!
                QueryPerformanceCounter(RenderCounter.LimitStop)
            Loop Until (RenderCounter.Frequency / (RenderCounter.LimitStop - RenderCounter.LimitStart)) < Config.Render.MaxFPS
        End If
    End Sub
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
            'Initialize render settings
            Render.Device.RenderState.PointSize = 4
            Render.Device.RenderState.FillMode = FillMode.Solid
            Render.Device.RenderState.ZBufferEnable = True
            Render.Device.RenderState.FogEnable = False
            Render.Device.RenderState.CullMode = Cull.CounterClockwise
            Render.Device.RenderState.ShadeMode = Config.Render.Shading

            Render.Device.RenderState.Lighting = True
            If Config.Render.EnableLighting Then
                Render.Device.RenderState.Ambient = Color.Black
                Render.Device.RenderState.AmbientMaterialSource = ColorSource.Material
                Render.Device.RenderState.DiffuseMaterialSource = ColorSource.Material
                Render.Device.RenderState.SpecularMaterialSource = ColorSource.Material
                Render.Device.RenderState.EmissiveMaterialSource = ColorSource.Material
                Render.Device.RenderState.SpecularEnable = True
            Else
                Render.Device.RenderState.SpecularEnable = False
                Render.Device.RenderState.AmbientMaterialSource = ColorSource.Material
                Render.Device.RenderState.Ambient = Color.White
            End If

            'Initialize transparency settings
            If Render.Transparency Then
                Render.Device.RenderState.SourceBlend = Blend.SourceAlpha
                Render.Device.RenderState.DestinationBlend = Blend.InvSourceAlpha
                Render.Device.RenderState.AlphaBlendEnable = True
            End If

            'Clear the device and paint the background
            Render.Device.Clear(ClearFlags.ZBuffer, Config.Render.BackgroundColor, 1, 0)
            Render.Device.Clear(ClearFlags.Target, Config.Render.BackgroundColor, 1, 0)

            'Setup the view port
            Render.Device.Transform.Projection = Matrix.PerspectiveFovLH(Config.Camera.HFov, Config.Render.AspectRatio, 1 / (Config.Render.Scale * 10), Config.Render.Scale * 2000)
            Render.Device.Transform.View = Matrix.LookAtLH(Camera.Position.ToVector3, Camera.Target.ToVector3, Config.Camera.UpVector.ToVector3)

            'Calculate Sphere complexity
            Render.SphereSecondaryComplexity = ToInt32((Config.Render.SphereComplexity * 0.5) + 0.5)

            'Create object meshes and materials
            For i = 0 To ObjectCount - 1
                Objects(i).CreateMesh(Render.Device, Config.Render.Scale, Config.Render.SphereComplexity, Render.SphereSecondaryComplexity)
                Objects(i).CreateMaterial()
            Next

            'Create the lights
            If Config.Render.EnableLighting = True Then
                For i = 0 To Config.LightCount - 1
                    Render.Device.Lights(i).Type = Config.Lights(i).Type
                    Render.Device.Lights(i).Ambient = Config.Lights(i).AmbientColor
                    Render.Device.Lights(i).Attenuation0 = Config.Lights(i).AttenuationA
                    Render.Device.Lights(i).Attenuation1 = Config.Lights(i).AttenuationB
                    Render.Device.Lights(i).Attenuation2 = Config.Lights(i).AttenuationC
                    Render.Device.Lights(i).Falloff = Config.Lights(i).Falloff
                    Render.Device.Lights(i).Diffuse = Config.Lights(i).Color
                    Render.Device.Lights(i).Direction = Config.Lights(i).Direction.ToVector3
                    Render.Device.Lights(i).InnerConeAngle = Config.Lights(i).InnerCone
                    Render.Device.Lights(i).OuterConeAngle = Config.Lights(i).OuterCone
                    Render.Device.Lights(i).Range = Config.Render.Scale * Config.Lights(i).Range
                    Render.Device.Lights(i).Specular = Config.Lights(i).SpecularColor
                    Render.Device.Lights(i).Position = (Config.Render.Scale * Config.Lights(i).Position).ToVector3
                    Render.Device.Lights(i).Update()
                    Render.Device.Lights(i).Enabled = True
                Next
            End If
        Else ' Raytracing
            Render.Device.RenderState.SourceBlend = Blend.SourceAlpha
            Render.Device.RenderState.DestinationBlend = Blend.InvSourceAlpha
            Render.Device.RenderState.AlphaBlendEnable = True
        End If

        'Trash the parameters
        Render.Parameters = Nothing

        Return True
    End Function
    Private Sub DoDXRender()


        Do While Running
            'Start the scene
            Render.Device.BeginScene()

            'Clear the Z buffer
            Render.Device.Clear(ClearFlags.ZBuffer, Config.Render.BackgroundColor, 1, 0)

            If Camera.DidMove Then
                'Clear Traces regardless of Trace Display setting
                Render.Device.Clear(ClearFlags.Target, Config.Render.BackgroundColor, 1, 0)

                'Change the view port
                Render.Device.Transform.View = Matrix.LookAtLH(Camera.Position.ToVector3, Camera.Target.ToVector3, Config.Camera.UpVector.ToVector3)
            Else
                'Clear Traces
                If Not Config.Render.TraceObjects Then
                    Render.Device.Clear(ClearFlags.Target, Config.Render.BackgroundColor, 1, 0)
                End If
            End If

            'TODO: Not everything here needs to be locked with the simulation
            Render.RenderLock.EnterReadLock()
            For i = 0 To ObjectCount - 1
                'If the object doesn't exist create it on the fly
                If Objects(i).Mesh = Nothing Then
                    Objects(i).CreateMesh(Render.Device, Config.Render.Scale, Config.Render.SphereComplexity, Render.SphereSecondaryComplexity)
                    Objects(i).CreateMaterial()
                End If

                'Change WireFrame settings
                If Objects(i).Wireframe = True Then
                    Render.Device.RenderState.FillMode = FillMode.WireFrame
                    Render.Device.RenderState.CullMode = Cull.None
                Else
                    Render.Device.RenderState.FillMode = FillMode.Solid
                    'Inside the current box
                    If Camera.Position.X < Objects(i).LimitPositive.X And Camera.Position.X > Objects(i).LimitNegative.X And Camera.Position.Y < Objects(i).LimitPositive.Y And Camera.Position.Y > Objects(i).LimitNegative.Y And Camera.Position.Z < Objects(i).LimitPositive.Z And Camera.Position.Z > Objects(i).LimitNegative.Z Then 'Inside box
                        Render.Device.RenderState.CullMode = Cull.Clockwise
                    Else
                        Render.Device.RenderState.CullMode = Cull.CounterClockwise
                    End If
                End If

                'Draw the object in its place
                Render.Device.Transform.World = Matrix.RotationX(ToSingle(Objects(i).Rotation.X)) * Matrix.RotationY(ToSingle(Objects(i).Rotation.Y)) * Matrix.RotationZ(ToSingle(Objects(i).Rotation.Z)) * Matrix.Translation(ToSingle(Config.Render.Scale * Objects(i).Position.X), ToSingle(Config.Render.Scale * Objects(i).Position.Y), ToSingle(Config.Render.Scale * Objects(i).Position.Z))

                Render.Device.Material = Objects(i).Material
                Objects(i).Mesh.DrawSubset(0)
            Next
            Render.RenderLock.ExitReadLock()

            'End the scene
            Render.Device.EndScene()
            Render.Device.Present()

            RenderControl()
        Loop
    End Sub
    Private Sub DoRayRender()
        'Data loaded from Simulation - static
        Dim RenderHeight As Integer = Config.Render.Height
        Dim RenderWidth As Integer = Config.Render.Width

        'Data loaded from Simulation - Dynamic
        Dim CameraScreenHunit As XYZ
        Dim CameraScreenWUnit As XYZ
        Dim CurrentObjectCount As Integer
        Dim ObjectRadius() As Double
        Dim ObjectRadiusSqrd() As Double
        Dim ObjectPosition() As XYZ
        Dim ObjectColor() As Color
        Dim CameraPosition As XYZ

        'Calculated - used in TraceRay
        Dim RayDirection As New XYZ
        Dim CameratoObject() As XYZ
        Dim CameratoObjectMagSqrd() As Double

        'Direct X display
        Dim Texture As New Texture(Render.Device, RenderWidth, RenderHeight, 1, Usage.None, Format.A8R8G8B8, Pool.Managed)
        Dim Sprite As New Sprite(Render.Device)
        Dim Size As New SizeF(RenderWidth, RenderHeight)
        Dim Point As New PointF(0, 0)
        Dim Rect As New Rectangle(0, 0, RenderWidth, RenderHeight)
        Dim Pitch As Integer = RenderWidth * RenderHeight * 4
        Dim Stream As GraphicsStream

        '2D Pixel array
        Dim PixelData((RenderWidth * RenderHeight * 4) - 1) As Byte
        Dim CurrentPixel As Integer

        'Used in iterarting through each pixel
        Dim TargetPixel As New XYZ
        Dim CameraPositionToTarget As XYZ
        Dim HalfRenderWidth As Double = RenderWidth / 2
        Dim HalfRenderHeight As Double = RenderWidth / 2
        Dim Ray_Temp_XYZ As XYZ

        'Used to trace each ray
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
        Dim Ray_Bias As Double = 0.001 * Config.Render.Scale
        Dim Ray_colorR As Double
        Dim Ray_colorG As Double
        Dim Ray_colorB As Double
        Dim Ray_attn As Double
        Dim Ray_spot As Double
        Dim Ray_rho As Double
        Dim Ray_cosin As Double
        Dim Ray_cosout As Double
        Dim Ray_PointtoObject As XYZ
        Dim Ray_PointtoObjectMagSqrd As Double

        'Box
        Dim Ray_ColorUsed As Color

        'Indicates the number of objects changed since the last loop
        Dim ObjectCountChanged As Boolean = False

        'Load initial object values that otherwise only get loaded if a change is made to the objects
        'TODO: Replace this with a read-write lock. Don't lock with other render threads only the simulation thread
        Render.RenderLock.EnterReadLock()
        CurrentObjectCount = ObjectCount
        ReDim ObjectRadius(CurrentObjectCount - 1)
        ReDim ObjectColor(CurrentObjectCount - 1)
        For i = 0 To CurrentObjectCount - 1
            ObjectRadius(i) = Objects(i).Radius
            ObjectColor(i) = Objects(i).Color
        Next
        Render.RenderLock.ExitReadLock()

        'Pre-dimension our arrays
        'Do it outside the Lock for better efficiency
        ReDim CameratoObject(CurrentObjectCount - 1)
        ReDim CameratoObjectMagSqrd(CurrentObjectCount - 1)
        ReDim ObjectRadiusSqrd(CurrentObjectCount - 1)
        ReDim ObjectPosition(CurrentObjectCount - 1)
        For i = 0 To CurrentObjectCount - 1
            ObjectRadiusSqrd(i) = ObjectRadius(i) * ObjectRadius(i)
        Next

        'Make the Background Transparent so we can trace the object path
        If Config.Render.TraceObjects = True Then
            Config.Render.BackgroundColor = Color.FromArgb(0, Config.Render.BackgroundColor.R, Config.Render.BackgroundColor.G, Config.Render.BackgroundColor.B)
        End If

        Do While Running

            'Load updated Values
            'TODO: Replace this with a read-write lock. Don't lock with other render threads only the simulation thread
            Render.RenderLock.EnterReadLock()
            'Update the camera changes
            CameraScreenHunit = Camera.ScreenHeightUnit
            CameraScreenWUnit = Camera.ScreenWidthUnit
            CameraPosition = Camera.Position
            CameraPositionToTarget = Camera.Target - CameraPosition

            'If the objects didn't change then only update their position
            'TODO: This assumes objects are only ever added
            If CurrentObjectCount <> ObjectCount Then
                CurrentObjectCount = ObjectCount
                ObjectCountChanged = True
                ReDim ObjectRadius(CurrentObjectCount - 1)
                ReDim ObjectColor(CurrentObjectCount - 1)
                ReDim ObjectPosition(CurrentObjectCount - 1)
                For i = 0 To CurrentObjectCount - 1
                    ObjectRadius(i) = Objects(i).Radius
                    ObjectColor(i) = Objects(i).Color
                Next
            End If

            'Always update the Object positions, regardless of object count
            For i = 0 To CurrentObjectCount - 1
                ObjectPosition(i) = Objects(i).Position
            Next
            Render.RenderLock.ExitReadLock()

            'Re-dimension our arrays
            'Do it outside the Lock for better efficiency
            If (ObjectCountChanged) Then
                ObjectCountChanged = False
                ReDim ObjectRadiusSqrd(CurrentObjectCount - 1)
                ReDim CameratoObject(CurrentObjectCount - 1)
                ReDim CameratoObjectMagSqrd(CurrentObjectCount - 1)
                For i = 0 To CurrentObjectCount - 1
                    ObjectRadiusSqrd(i) = ObjectRadius(i) * ObjectRadius(i)
                    CameratoObject(i) = ObjectPosition(i) - CameraPosition
                    CameratoObjectMagSqrd(i) = CameratoObject(i).MagnitudeSquared
                Next
            End If

            'Calculate new values based on camera movement and object movement
            'Do it outside the Lock for better efficiency
            For i = 0 To CurrentObjectCount - 1
                CameratoObject(i) = ObjectPosition(i) - CameraPosition
                CameratoObjectMagSqrd(i) = CameratoObject(i).MagnitudeSquared
            Next


            'Reset the current pixel counter
            CurrentPixel = 0

            'For each pixel
            For Y = 0 To RenderHeight - 1
                Ray_Temp_XYZ = ((HalfRenderHeight - Y) * CameraScreenHunit) + CameraPositionToTarget
                For X = 0 To Config.Render.Width - 1
                    'Calculate the direction of the primary ray
                    RayDirection = ((HalfRenderWidth - X) * CameraScreenWUnit) + Ray_Temp_XYZ
                    RayDirection.MakeUnit()

                    'Reset object flags
                    Ray_ClosestObjectDistance = Double.PositiveInfinity
                    Ray_ClosestObject = -1

                    'For each object check for intersection
                    For i = 0 To CurrentObjectCount - 1
                        Ray_tca = CameratoObject(i).Dot(RayDirection)
                        Ray_OutsideObject = CameratoObjectMagSqrd(i) > ObjectRadiusSqrd(i)
                        If Ray_tca >= 0 Or Not Ray_OutsideObject Then  'There might be an intersection
                            Ray_thc = ObjectRadiusSqrd(i) - CameratoObjectMagSqrd(i) + (Ray_tca * Ray_tca)
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
                        PixelData(CurrentPixel) = Config.Render.BackgroundColor.B
                        PixelData(CurrentPixel + 1) = Config.Render.BackgroundColor.G
                        PixelData(CurrentPixel + 2) = Config.Render.BackgroundColor.R
                        PixelData(CurrentPixel + 3) = Config.Render.BackgroundColor.A
                        CurrentPixel += 4
                    Else

                        Ray_ShadowOrigin = CameraPosition + (RayDirection * Ray_ClosestObjectDistance)
                        If Ray_ClosestObject <> -2 Then
                            Ray_PointNormal = Ray_ShadowOrigin - ObjectPosition(Ray_ClosestObject)
                            Ray_PointNormal.MakeUnit()
                        Else
                            'TODO: This is supposed to be for a BOX
                            Ray_PointNormal = New XYZ
                        End If

                        'Reset the ray color before calulating all the lighting
                        Ray_colorR = 0
                        Ray_colorG = 0
                        Ray_colorB = 0

                        'For each light in the scene
                        For l = 0 To Config.LightCount - 1
                            If Config.Lights(l).Type = LightType.Directional Then
                                'Directional lights always cast shadows in a single direction
                                Ray_ShadowDirection = -Config.Lights(l).Direction
                            Else
                                Ray_ShadowDirection = Config.Lights(l).Position - Ray_ShadowOrigin
                            End If

                            Ray_ShadowLength = Ray_ShadowDirection.Magnitude
                            Ray_ShadowDirection.MakeUnit()
                            Ray_LdotN = Ray_ShadowDirection.Dot(Ray_PointNormal)

                            If Ray_LdotN < 0 Then 'Self shadowing
                                Ray_isinShadow = True
                            Else
                                Ray_isinShadow = False
                                'For each object check for intersection
                                For i = 0 To CurrentObjectCount - 1
                                    Ray_PointtoObject = ObjectPosition(i) - Ray_ShadowOrigin
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
                            Ray_colorR += Config.Lights(l).AmbientColor.R * (Ray_ColorUsed.R * Byth)
                            Ray_colorG += Config.Lights(l).AmbientColor.G * (Ray_ColorUsed.G * Byth)
                            Ray_colorB += Config.Lights(l).AmbientColor.B * (Ray_ColorUsed.B * Byth)

                            If Not Ray_isinShadow Then
                                'Add direct lighting for this light

                                If Config.Lights(l).Type = LightType.Point Then
                                    Ray_attn = 1 / (Config.Lights(l).AttenuationA + (Ray_ShadowLength * (Config.Lights(l).AttenuationB + (Config.Lights(l).AttenuationC * Ray_ShadowLength))))
                                    Ray_spot = 1
                                ElseIf Config.Lights(l).Type = LightType.Spot Then
                                    Ray_attn = 1 / (Config.Lights(l).AttenuationA + (Ray_ShadowLength * (Config.Lights(l).AttenuationB + (Config.Lights(l).AttenuationC * Ray_ShadowLength))))
                                    Ray_rho = Config.Lights(l).Direction.Dot(-Ray_ShadowDirection)
                                    Ray_cosout = Cos(Config.Lights(l).OuterCone * 0.5)
                                    Ray_cosin = Cos(Config.Lights(l).InnerCone * 0.5)
                                    If Ray_rho > Ray_cosin Then
                                        Ray_spot = 1
                                    ElseIf (Ray_rho <= Ray_cosout) Then
                                        Ray_spot = 0
                                    Else
                                        Ray_spot = ((Ray_rho - Ray_cosout) / (Ray_cosin - Ray_cosout)) ^ Config.Lights(l).Falloff
                                    End If
                                Else
                                    Ray_attn = 1
                                    Ray_spot = 1
                                End If
                                Ray_attn *= Byth * Ray_LdotN * Ray_spot
                                Ray_colorR += (Ray_attn * Ray_ColorUsed.R) * Config.Lights(l).Color.R
                                Ray_colorG += (Ray_attn * Ray_ColorUsed.G) * Config.Lights(l).Color.G
                                Ray_colorB += (Ray_attn * Ray_ColorUsed.B) * Config.Lights(l).Color.B
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

            'Draw the pixel array to the screen
            Stream = Texture.LockRectangle(0, Rect, LockFlags.None, Pitch)
            Stream.Write(PixelData, 0, PixelData.Length)
            Texture.UnlockRectangle(0)

            SyncLock LockRayMulti 'Make sure only one thread is using the device 
                Render.Device.BeginScene()
                If Camera.DidMove Then
                    Render.Device.Clear(ClearFlags.Target, Config.Render.BackgroundColor, 1, 0)
                End If
                Sprite.Begin(SpriteFlags.AlphaBlend)
                Sprite.Draw2D(Texture, Rect, Size, Point, Color.White)
                Sprite.End()
                Render.Device.EndScene()
                Render.Device.Present()
            End SyncLock
            RenderControl() 'TODO: Check the need to make this call here
        Loop

        'Reset the background color in case path tracing was used
        Config.Render.BackgroundColor = Color.FromArgb(255, Config.Render.BackgroundColor.R, Config.Render.BackgroundColor.G, Config.Render.BackgroundColor.B)
    End Sub
#End Region

End Class
