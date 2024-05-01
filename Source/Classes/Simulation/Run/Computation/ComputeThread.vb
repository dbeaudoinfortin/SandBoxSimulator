Public Class ComputeThread
    'Calculation limiter constants
    Private ReadOnly CalcCounterFrequency As Long
    Private ReadOnly CounterTicks1ms As Long 'The counter frequency in ticks per second
    Private ReadOnly CalcSleepLimit As Long 'Maximum number of ticks willing to sleep, 2 milliseconds

    'Calculation limiter variables
    Private CalcLimitEnabled As Boolean
    Private CalcLimitStart As Long 'Counter at the start of the calculation
    Private CalcLimitStop As Long 'Counter at the end of the calculation
    Private CalcLimitDiff As Long 'Remaining ticks
    Private CalcTimeLimit As Long 'How many ticks we are allowed per loop
    Private CalcSleepTimeMs As Integer

    'Calculated once before looping
    Private Ec As Double

    Private ReadOnly Sim As SimulationRuntime
    Private ReadOnly DoIntegration As Boolean

    Public Sub New(ByRef simulationRuntime As SimulationRuntime, ByRef DoIntegration As Boolean)
        Sim = simulationRuntime
        Me.DoIntegration = DoIntegration

        'Initialize calulation limiter
        QueryPerformanceFrequency(CalcCounterFrequency)
        CounterTicks1ms = CalcCounterFrequency \ 1000
        CalcSleepLimit = CounterTicks1ms * 10 '10 millisecond
    End Sub

#Region "Main Computation"
    Private Sub ComputationControl()
        Sim.CalcCounter.FullCount += 1

        If Sim.Paused Then
            Do While (Sim.Paused)
                Thread.Sleep(100)
            Loop

            'Reset the calulation start after being paused
            QueryPerformanceCounter(CalcLimitStart)
        ElseIf CalcLimitEnabled Then

            QueryPerformanceCounter(CalcLimitStop)

            'Calculate how many ticks are remaining
            CalcLimitDiff = CalcTimeLimit - (CalcLimitStop - CalcLimitStart)

            If CalcLimitDiff >= CalcSleepLimit Then
                'Subtract 5ms to discourage oversleeping
                CalcSleepTimeMs = ToInt32((CalcLimitDiff \ CounterTicks1ms) - 5)
                If (CalcSleepTimeMs > 0) Then Thread.Sleep(CalcSleepTimeMs)

                'There may still be a bit of time left over
                QueryPerformanceCounter(CalcLimitStop)
                CalcLimitDiff = CalcTimeLimit - (CalcLimitStop - CalcLimitStart)
            End If

            If CalcLimitDiff > 10 Then 'Less than 10 isn't worth spinning
                Do ' Spin
                    QueryPerformanceCounter(CalcLimitStop)
                    CalcLimitDiff = CalcTimeLimit - (CalcLimitStop - CalcLimitStart)
                Loop While (CalcLimitDiff > 10)
            End If

            'Reset the calulation start for the next round
            CalcLimitStart = CalcLimitStop
        End If
    End Sub
    Private Sub DoComputeNoIntegration(timeStep As Double)
        If Sim.Config.Collisions.Enabled And Sim.Config.Collisions.Interpolate Then
            'Collisions with interpolation
            Do While Sim.Running
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).OldPosition.Copy(Sim.Objects(i).Position)
                Next

                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += Sim.Objects(i).Velocity * timeStep
                Next
                Sim.Render.RenderLock.ExitWriteLock()

                DoCollisions() 'Collisions must be after
                ComputationControl()
            Loop
        ElseIf Sim.Config.Collisions.Enabled Then
            'Collisions but not interpolation
            Do While Sim.Running
                DoCollisions()

                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += Sim.Objects(i).Velocity * timeStep
                Next
                Sim.Render.RenderLock.ExitWriteLock()

                ComputationControl()
            Loop
        Else
            'No collisions at all
            Do While Sim.Running
                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += Sim.Objects(i).Velocity * timeStep
                Next
                Sim.Render.RenderLock.ExitWriteLock()
                ComputationControl()
            Loop
        End If
    End Sub
    Private Sub DoComputeEuler(timeStep As Double)
        If Sim.Config.Collisions.Enabled And Sim.Config.Collisions.Interpolate Then
            Do While Sim.Running
                DoForces()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).OldPosition.Copy(Sim.Objects(i).Position)
                    Sim.Objects(i).Velocity += Sim.Objects(i).Acceleration * timeStep
                Next

                'Only the position of the objects actually needs to be locked
                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += Sim.Objects(i).Velocity * timeStep
                Next
                Sim.Render.RenderLock.ExitWriteLock()

                DoCollisions()
                ComputationControl()
            Loop
        ElseIf Sim.Config.Collisions.Enabled Then
            Do While Sim.Running
                DoCollisions()
                DoForces()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Velocity += Sim.Objects(i).Acceleration * timeStep
                Next

                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += Sim.Objects(i).Velocity * timeStep
                Next
                Sim.Render.RenderLock.ExitWriteLock()

                ComputationControl()
            Loop
        Else
            Do While Sim.Running
                DoForces()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Velocity += Sim.Objects(i).Acceleration * timeStep
                Next

                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += Sim.Objects(i).Velocity * timeStep
                Next
                Sim.Render.RenderLock.ExitWriteLock()

                ComputationControl()
            Loop
        End If
    End Sub
    Private Sub DoComputeVerlet(timeStep As Double)
        Dim HalfT As Double = 0.5 * timeStep
        Dim HalfTSqd As Double = HalfT * timeStep

        If Sim.Config.Collisions.Enabled And Sim.Config.Collisions.Interpolate Then
            DoForces() 'Initial forces

            Do While Sim.Running

                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).OldPosition.Copy(Sim.Objects(i).Position)
                Next

                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += (Sim.Objects(i).Velocity * timeStep) + (HalfTSqd * Sim.Objects(i).Acceleration)
                Next
                Sim.Render.RenderLock.ExitWriteLock()

                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Velocity += HalfT * Sim.Objects(i).Acceleration
                Next

                DoForces()

                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Velocity += Sim.Objects(i).Acceleration * HalfT
                Next

                DoCollisions()
                ComputationControl()
            Loop
        ElseIf Sim.Config.Collisions.Enabled Then
            DoForces() 'Initial forces
            Do While Sim.Running
                DoCollisions()

                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += (Sim.Objects(i).Velocity * timeStep) + (HalfTSqd * Sim.Objects(i).Acceleration)
                Next
                Sim.Render.RenderLock.ExitWriteLock()

                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Velocity += HalfT * Sim.Objects(i).Acceleration
                Next

                DoForces()

                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Velocity += Sim.Objects(i).Acceleration * HalfT
                Next

                ComputationControl()
            Loop
        Else
            DoForces() 'Initial forces
            Do While Sim.Running

                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += (Sim.Objects(i).Velocity * timeStep) + (HalfTSqd * Sim.Objects(i).Acceleration)

                Next
                Sim.Render.RenderLock.ExitWriteLock()

                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Velocity += HalfT * Sim.Objects(i).Acceleration
                Next

                DoForces()

                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Velocity += Sim.Objects(i).Acceleration * HalfT
                Next

                ComputationControl()
            Loop
        End If
    End Sub

    Private Sub DoCompute4thSymplectic(ByRef timeStep As Double)
        Const b As Double = 2 ^ (1 / 3)
        Const a As Double = 2 - b
        Const x0 As Double = -b / a
        Const x1 As Double = 1 / a

        Dim HalfT As Double = 0.5 * timeStep
        Dim d() As Double = {timeStep * x1, timeStep * x0, timeStep * x1}
        Dim c() As Double = {x1 * HalfT, (x0 + x1) * HalfT, (x0 + x1) * HalfT, x1 * HalfT}

        If Sim.Config.Collisions.Enabled And Sim.Config.Collisions.Interpolate Then
            Do While Sim.Running

                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).OldPosition.Copy(Sim.Objects(i).Position)
                Next

                For j = 0 To 2
                    Sim.Render.RenderLock.EnterWriteLock()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Position += c(j) * Sim.Objects(i).Velocity
                    Next
                    Sim.Render.RenderLock.ExitWriteLock()

                    DoForces()

                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Velocity += d(j) * Sim.Objects(i).Acceleration
                    Next
                Next
                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += c(3) * Sim.Objects(i).Velocity
                Next
                Sim.Render.RenderLock.ExitWriteLock()
                DoCollisions()
                ComputationControl()
            Loop
        ElseIf Sim.Config.Collisions.Enabled Then
            Do While Sim.Running
                DoCollisions()

                For j = 0 To 2
                    Sim.Render.RenderLock.EnterWriteLock()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Position += c(j) * Sim.Objects(i).Velocity
                    Next
                    Sim.Render.RenderLock.ExitWriteLock()
                    DoForces()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Velocity += d(j) * Sim.Objects(i).Acceleration
                    Next
                Next
                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += c(3) * Sim.Objects(i).Velocity
                Next
                Sim.Render.RenderLock.ExitWriteLock()
                ComputationControl()
            Loop
        Else

            Do While Sim.Running
                For j = 0 To 2
                    Sim.Render.RenderLock.EnterWriteLock()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Position += c(j) * Sim.Objects(i).Velocity
                    Next
                    Sim.Render.RenderLock.ExitWriteLock()

                    DoForces()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Velocity += d(j) * Sim.Objects(i).Acceleration
                    Next
                Next

                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += c(3) * Sim.Objects(i).Velocity
                Next
                Sim.Render.RenderLock.ExitWriteLock()
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

        If Sim.Config.Collisions.Enabled And Sim.Config.Collisions.Interpolate Then
            Do While Sim.Running
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).OldPosition.Copy(Sim.Objects(i).Position)
                Next
                For j = 0 To 6
                    Sim.Render.RenderLock.EnterWriteLock()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Position += c(j) * Sim.Objects(i).Velocity
                    Next
                    Sim.Render.RenderLock.ExitWriteLock()
                    DoForces()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Velocity += d(j) * Sim.Objects(i).Acceleration
                    Next
                Next
                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += c(7) * Sim.Objects(i).Velocity
                Next
                Sim.Render.RenderLock.ExitWriteLock()
                DoCollisions()
                ComputationControl()
            Loop
        ElseIf Sim.Config.Collisions.Enabled Then

            Do While Sim.Running
                For j = 0 To 6
                    Sim.Render.RenderLock.EnterWriteLock()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Position += c(j) * Sim.Objects(i).Velocity
                    Next
                    Sim.Render.RenderLock.ExitWriteLock()
                    DoForces()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Velocity += d(j) * Sim.Objects(i).Acceleration
                    Next
                Next
                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += c(7) * Sim.Objects(i).Velocity
                Next
                Sim.Render.RenderLock.ExitWriteLock()
                DoCollisions()
                ComputationControl()
            Loop
        Else
            Do While Sim.Running

                For j = 0 To 6

                    Sim.Render.RenderLock.EnterWriteLock()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Position += c(j) * Sim.Objects(i).Velocity
                    Next
                    Sim.Render.RenderLock.ExitWriteLock()

                    DoForces()

                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Velocity += d(j) * Sim.Objects(i).Acceleration
                    Next
                Next

                Sim.Render.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += c(7) * Sim.Objects(i).Velocity
                Next
                Sim.Render.RenderLock.ExitWriteLock()

                ComputationControl()
            Loop
        End If
    End Sub
    Public Sub DoCompute()
        'If breakages might happen then make room for additial objects that might be needed
        If Sim.Config.Collisions.Breakable Then
            Array.Resize(Sim.Objects, Sim.Config.Settings.MaxObjects)
        End If

        'Pre-calculate Permitivity value
        Ec = 1 / (4 * PI * Eo * Sim.Config.Forces.ElectroStatic.Permittivity)

        'Initialize the calculation limiter.
        'Check if the limiter is enabled and if we even have enought precision
        CalcTimeLimit = If(Sim.Config.Settings.MaxCPS > 0, ToInt64(CalcCounterFrequency / Sim.Config.Settings.MaxCPS), 0)
        CalcLimitEnabled = CalcTimeLimit > 0
        If CalcLimitEnabled Then
            QueryPerformanceCounter(CalcLimitStart)
        End If

        If Not DoIntegration Then
            DoComputeNoIntegration(Sim.Config.Settings.TimeStep)
            Return
        End If

        If Sim.Config.Settings.IntegrationMethod = 0 Then
            DoComputeEuler(Sim.Config.Settings.TimeStep)
        ElseIf Sim.Config.Settings.IntegrationMethod = 1 Then
            DoComputeVerlet(Sim.Config.Settings.TimeStep)
        ElseIf Sim.Config.Settings.IntegrationMethod = 2 Then
            DoCompute4thSymplectic(Sim.Config.Settings.TimeStep)
        ElseIf Sim.Config.Settings.IntegrationMethod = 3 Then
            DoCompute6thSymplectic(Sim.Config.Settings.TimeStep)
        End If
    End Sub

#End Region
#Region "Collisions"
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
        Dim VI As XYZ
        Dim VQ As XYZ
        Dim NewVI As XYZ
        Dim DotProductI As Double
        Dim DotProductQ As Double
        Dim DotProductMagI As Double
        Dim DotProductMagQ As Double
        Dim DeltaKineticQ As Double
        Dim DeltaKineticI As Double
        Dim i As Integer

        '~~~~~~~~~~~~~OBJECT OBJECT COLLISION~~~~~~~~~~~~
        For i = 0 To Sim.ObjectCount - 2
            For Q = i + 1 To Sim.ObjectCount - 1

                If Not Sim.Objects(i).Affected Or Not Sim.Objects(i).Affects Or Not Sim.Objects(Q).Affected Or Not Sim.Objects(Q).Affects Then Continue For

                SumofRadius = Sim.Objects(i).Radius + Sim.Objects(Q).Radius
                QtoIPosistion = Sim.Objects(Q).Position - Sim.Objects(i).Position
                DidCollide = False

                If Sim.Config.Collisions.Interpolate Then

                    'Find the values for the quadratic describing the path of intersection of the objects
                    QtoIOldPosistion = Sim.Objects(i).OldPosition - Sim.Objects(Q).OldPosition
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
                        Sim.Render.RenderLock.EnterWriteLock()
                        Sim.Objects(i).Position = ((Sim.Objects(i).Position - Sim.Objects(i).OldPosition) * CollisionTime) + Sim.Objects(i).OldPosition
                        Sim.Objects(Q).Position = ((Sim.Objects(Q).Position - Sim.Objects(Q).OldPosition) * CollisionTime) + Sim.Objects(Q).OldPosition
                        Sim.Render.RenderLock.ExitWriteLock()
                        'Recalculate thier seperation
                        QtoIPosistion = Sim.Objects(Q).Position - Sim.Objects(i).Position
                        QtoIDistanceSqd = QtoIPosistion.MagnitudeSquared
                        DotProductI = Sim.Objects(i).Velocity.Dot(QtoIPosistion)
                        DotProductQ = Sim.Objects(Q).Velocity.Dot(QtoIPosistion)
                    Else
                        'No Collision Occured
                        Continue For
                    End If
                Else
                    'No interpolation
                    QtoIDistanceSqd = QtoIPosistion.MagnitudeSquared
                    If QtoIDistanceSqd > SumofRadius * SumofRadius Then Continue For 'Check that they are touching
                    DotProductI = Sim.Objects(i).Velocity.Dot(QtoIPosistion)
                    DotProductQ = Sim.Objects(Q).Velocity.Dot(QtoIPosistion)
                    If DotProductQ - DotProductI >= 0 Then Continue For 'Check that the are coming together
                End If

                SumofMasses = Sim.Objects(i).Mass + Sim.Objects(Q).Mass
                DotProductMagI = DotProductI / QtoIDistanceSqd
                DotProductMagQ = DotProductQ / QtoIDistanceSqd
                VI = DotProductMagI * QtoIPosistion
                VQ = DotProductMagQ * QtoIPosistion
                If Sim.Config.Collisions.CoR = 0 Then '~~~~~~~~~~~PLASTIC OBJECT OBJECT COLLISION~~~~~~~~~~~
                    NewVI = ((Sim.Objects(Q).Mass * VQ) + (VI * Sim.Objects(i).Mass)) / SumofMasses
                    Sim.Objects(i).Velocity.Copy(NewVI + (Sim.Objects(i).Velocity - VI))
                    Sim.Objects(Q).Velocity.Copy(NewVI + (Sim.Objects(Q).Velocity - VQ))
                ElseIf Sim.Config.Collisions.CoR = 1 Then  '~~~~~~ELASTIC OBJECT OBJECT COLLISION~~~~~~~~~~~
                    TempDouble4 = Sim.Objects(i).Mass / SumofMasses
                    TempDouble5 = Sim.Objects(Q).Mass / SumofMasses
                    TempDouble = TempDouble4 - TempDouble5
                    Sim.Objects(i).Velocity += ((TempDouble5 + TempDouble5) * VQ) + (VI * (TempDouble - 1))
                    Sim.Objects(Q).Velocity += ((TempDouble4 + TempDouble4) * VI) - (VQ * (TempDouble + 1))
                Else '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~PARTIAL OBJECT OBJECT COLLISION~~~~~~~~~~~
                    TempDouble4 = Sim.Objects(i).Mass / SumofMasses
                    TempDouble5 = Sim.Objects(Q).Mass / SumofMasses
                    TempDouble3 = Sim.Config.Collisions.CoR + 1
                    Sim.Objects(i).Velocity += (TempDouble3 * TempDouble5 * VQ) + (VI * (TempDouble4 - (Sim.Config.Collisions.CoR * TempDouble5) - 1))
                    Sim.Objects(Q).Velocity += (TempDouble3 * TempDouble4 * VI) + (VQ * (TempDouble5 - (Sim.Config.Collisions.CoR * TempDouble4) - 1))
                End If

                If Sim.Config.Collisions.Interpolate Then
                    'Move the objects forward by the remaining time
                    Sim.Render.RenderLock.EnterWriteLock()
                    Sim.Objects(i).Position += Sim.Objects(i).Velocity * (Sim.Config.Settings.TimeStep * (1 - CollisionTime))
                    Sim.Objects(Q).Position += Sim.Objects(Q).Velocity * (Sim.Config.Settings.TimeStep * (1 - CollisionTime))
                    Sim.Render.RenderLock.ExitWriteLock()
                End If

                '~~~~~~~~~~~~~~BREAKABLE OBJECT OBJECT COLLISION~~~~~~~~~~~~
                If Not Sim.Config.Collisions.Breakable Or Sim.ObjectCount >= Sim.Config.Settings.MaxObjects Or Sim.Config.Collisions.CoR = 1 Then Continue For

                DeltaKineticI = Math.Abs(VI.MagnitudeSquared + VQ.MagnitudeSquared - Sim.Objects(i).Velocity.MagnitudeSquared - Sim.Objects(Q).Velocity.MagnitudeSquared)
                DeltaKineticQ = DeltaKineticI
                DeltaKineticI *= Sim.Objects(i).Mass
                DeltaKineticQ *= Sim.Objects(Q).Mass

                'Determine if Q will break
                If DeltaKineticQ >= Sim.Config.Collisions.BreakMax Then
                    DoBreak(Q)
                ElseIf DeltaKineticQ >= Sim.Config.Collisions.BreakMin Then
                    If DeltaKineticQ = Sim.Config.Collisions.BreakAvg Then
                        If Sim.RandMaker.GetNext() > 0.5 Then DoBreak(Q)
                    Else
                        If Sim.RandMaker.GetNext < Sim.RandMaker.GetProbibility(DeltaKineticQ, Sim.Config.Collisions.BreakAvg, Sim.Config.Collisions.BreakMin, Sim.Config.Collisions.BreakMax) Then DoBreak(Q) 'Get probibility and compare it to a random number
                    End If
                End If

                'Determine if I will break
                If Sim.ObjectCount >= Sim.Config.Settings.MaxObjects Then Continue For

                If DeltaKineticI >= Sim.Config.Collisions.BreakMax Then
                    DoBreak(i)
                ElseIf DeltaKineticI >= Sim.Config.Collisions.BreakMin Then
                    If DeltaKineticI = Sim.Config.Collisions.BreakAvg Then
                        If Sim.RandMaker.GetNext() > 0.5 Then DoBreak(i)
                    Else
                        If Sim.RandMaker.GetNext < Sim.RandMaker.GetProbibility(DeltaKineticI, Sim.Config.Collisions.BreakAvg, Sim.Config.Collisions.BreakMin, Sim.Config.Collisions.BreakMax) Then DoBreak(i) 'Get probibility and compare it to a random number
                    End If
                End If
            Next
        Next
    End Sub

#End Region
#Region "Forces"
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
        If Sim.Config.Forces.Field.Enabled Then
            'Apply field
            For I = 0 To Sim.ObjectCount - 1
                If Sim.Objects(I).Affected Then
                    Sim.Objects(I).Acceleration.Copy(Sim.Config.Forces.Field.Acceleration)
                Else
                    Sim.Objects(I).Acceleration.MakeZero()
                End If
            Next
        Else
            'Reset acceleration to zero
            For I = 0 To Sim.ObjectCount - 1
                Sim.Objects(I).Acceleration.MakeZero()
            Next
        End If
        '~~~~~~~~~~~~~OBJECT ENVIRONMENT FORCES~~~~~~~~~~~~~~
        If Sim.Config.Forces.Drag.Enabled Then
            For I = 0 To Sim.ObjectCount - 1
                If Sim.Objects(I).Affected Then
                    ReynoldsMultiplier = (Sim.Config.Forces.Drag.Density * Sim.Objects(I).Radius * 2) / Sim.Config.Forces.Drag.Viscosity
                    StokesDragConst = (6 * PI * Sim.Config.Forces.Drag.Viscosity * Sim.Objects(I).Radius) / Sim.Objects(I).Mass
                    DragMultiplier = (0.5 * Sim.Config.Forces.Drag.Density * Sim.Config.Forces.Drag.DragCoeff * Math.PI * Sim.Objects(I).Radius * Sim.Objects(I).Radius) / Sim.Objects(I).Mass
                    ReynoldsNumber = ReynoldsMultiplier * Sim.Objects(I).Velocity.Abs
                    If ReynoldsNumber.X < 30 Then
                        Sim.Objects(I).Acceleration.X -= StokesDragConst * Sim.Objects(I).Velocity.X
                    Else
                        Sim.Objects(I).Acceleration.X -= DragMultiplier * Sim.Objects(I).Velocity.X * Math.Abs(Sim.Objects(I).Velocity.X)
                    End If
                    If ReynoldsNumber.Y < 30 Then
                        Sim.Objects(I).Acceleration.Y -= StokesDragConst * Sim.Objects(I).Velocity.Y
                    Else
                        Sim.Objects(I).Acceleration.Y -= DragMultiplier * Sim.Objects(I).Velocity.Y * Math.Abs(Sim.Objects(I).Velocity.Y)
                    End If
                    If ReynoldsNumber.Z < 30 Then
                        Sim.Objects(I).Acceleration.Z -= StokesDragConst * Sim.Objects(I).Velocity.Z
                    Else
                        Sim.Objects(I).Acceleration.Z -= DragMultiplier * Sim.Objects(I).Velocity.Z * Math.Abs(Sim.Objects(I).Velocity.Z)
                    End If
                End If
            Next
        End If

        If Sim.Config.Forces.Gravity Or Sim.Config.Forces.ElectroStatic.Enabled Then
            '~~~~~~~~~~~~~OBJECT OBJECT FORCES~~~~~~~~~~~~~~
            For I = 0 To Sim.ObjectCount - 2
                For Q = I + 1 To Sim.ObjectCount - 1
                    If (Sim.Objects(I).Affected And Sim.Objects(Q).Affects) Or (Sim.Objects(Q).Affected And Sim.Objects(I).Affects) Then 'If the objects are allowed to interact

                        QtoIPosistion = (Sim.Objects(Q).Position - Sim.Objects(I).Position)
                        QtoIDistanceSqd = QtoIPosistion.MagnitudeSquared
                        QtoIDistance = Math.Sqrt(QtoIDistanceSqd)
                        Coeff = QtoIPosistion / QtoIDistance

                        '~~~~~~~~~~~~~NEWTONIAN GRAVITY~~~~~~~~~~~~~~
                        If Sim.Config.Forces.Gravity Then
                            AccMagi = (G * Sim.Objects(Q).Mass) / (QtoIDistanceSqd)
                            AccMagq = (-G * Sim.Objects(I).Mass) / (QtoIDistanceSqd)
                            If Sim.Objects(I).Affected And Sim.Objects(Q).Affects Then
                                Sim.Objects(I).Acceleration += AccMagi * Coeff
                            End If
                            If Sim.Objects(Q).Affected And Sim.Objects(I).Affects Then
                                Sim.Objects(Q).Acceleration += AccMagq * Coeff
                            End If
                        End If
                        '~~~~~~~~~~~~~ELECTRONMAGNATISM~~~~~~~~~~~~~~
                        If Sim.Config.Forces.ElectroStatic.Enabled Then
                            Ectemp = (Ec * Sim.Objects(Q).Charge * Sim.Objects(I).Charge)
                            AccMagi = -(Ectemp / (QtoIDistanceSqd * Sim.Objects(I).Mass))
                            AccMagq = (Ectemp / (QtoIDistanceSqd * Sim.Objects(Q).Mass))
                            If Sim.Objects(I).Affected And Sim.Objects(Q).Affects Then
                                Sim.Objects(I).Acceleration += AccMagi * Coeff
                            End If
                            If Sim.Objects(Q).Affected And Sim.Objects(I).Affects Then
                                Sim.Objects(Q).Acceleration += AccMagq * Coeff
                            End If
                        End If
                    End If
                Next
            Next
        End If
    End Sub
#End Region

#Region "Object Breaking"
    Private Sub DoBreak(ByRef Index As Integer)
        'Variables used in the breaking
        Dim SkewDirection As Double  ' Determines the direction of the distribution curve
        Dim BreakNumber As Integer 'Determines the number of resulting objects
        Dim NewObjects(Sim.Config.Collisions.AddMax) As SimulationObject 'Temporarily holds the objects while they are being created
        Dim MassAssigned(Sim.Config.Collisions.AddMax) As Double 'A random amount of mass that is assigned to each object
        Dim VolumeAssigned(Sim.Config.Collisions.AddMax) As Double 'A random amount of volume that is assigned to each object
        Dim VelocityComponents(Sim.Config.Collisions.AddMax) As XYZ 'The random distribution of the velocity acroos all three components
        Dim VelocityMagnitude(Sim.Config.Collisions.AddMax) As Double 'The magnitude of the velocity in all three components
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
        If Sim.ObjectCount >= Sim.Config.Settings.MaxObjects Then Exit Sub

        'Determine what distribution curve will be used
        SkewDirection = Sim.RandMaker.GetNext
        If SkewDirection = 0.5 Then
            BreakNumber = Sim.Config.Collisions.AddAvg
        ElseIf SkewDirection < 0.5 Then
            BreakNumber = ToInt32(Sim.RandMaker.GetNextSkewed(Sim.Config.Collisions.AddAvg, Sim.Config.Collisions.AddMin))
        Else
            BreakNumber = ToInt32(Sim.RandMaker.GetNextSkewed(Sim.Config.Collisions.AddAvg, Sim.Config.Collisions.AddMax))
        End If

        'Verify reasonable results
        If BreakNumber < Sim.Config.Collisions.AddMin Then
            BreakNumber = Sim.Config.Collisions.AddMin
        ElseIf BreakNumber > Sim.Config.Collisions.AddMax Then
            BreakNumber = Sim.Config.Collisions.AddMax
        End If
        If Sim.ObjectCount - 1 + BreakNumber > Sim.Config.Settings.MaxObjects Then
            BreakNumber = Sim.Config.Settings.MaxObjects - Sim.ObjectCount + 1
        End If

        'Calculate 3 perpendicular unit vectors
        VelocityI = Sim.Objects(Index).Velocity
        VelocityMagnitudeI = VelocityI.Magnitude
        VelocityI /= VelocityMagnitudeI
        VelocityJ = VelocityI.Perpendicular
        VelocityK = VelocityI.Cross(VelocityJ)
        VelocityMagnitudeI *= BreakNumber

        'CREATE NEW OBJECTS AND ASSIGN NON-RANDOM PARAMETERS
        For z = 0 To BreakNumber - 1
            NewObjects(z) = New SimulationObject
            NewObjects(z).Affected = Sim.Objects(Index).Affected
            NewObjects(z).Affects = Sim.Objects(Index).Affects
            NewObjects(z).HighlightColor = Sim.Objects(Index).HighlightColor
            NewObjects(z).HighlightSharpness = Sim.Objects(Index).HighlightSharpness
            NewObjects(z).Reflectivity = Sim.Objects(Index).Reflectivity
            NewObjects(z).RefractiveIndex = Sim.Objects(Index).RefractiveIndex
            NewObjects(z).Transparency = Sim.Objects(Index).Transparency
            NewObjects(z).Wireframe = Sim.Objects(Index).Wireframe
            NewObjects(z).Type = Sim.Objects(Index).Type
            NewObjects(z).Color = Sim.Objects(Index).Color
            NewObjects(z).Rotation.Copy(Sim.Objects(Index).Rotation)
            VelocityMagnitude(z) = Sim.RandMaker.GetNext 'Assign a random amount of velocity
            TotalVelocityMagnitude += VelocityMagnitude(z)
            VelocityComponents(z) = New XYZ(Sim.RandMaker.GetNext, Sim.RandMaker.GetNext, Sim.RandMaker.GetNext) 'Assign a random direction to the velocity
            If Sim.RandMaker.GetNext > 0.5 Then VelocityComponents(z).Y = -VelocityComponents(z).Y
            If Sim.RandMaker.GetNext > 0.5 Then VelocityComponents(z).Z = -VelocityComponents(z).Z
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
        If Sim.Objects(Index).Type = ObjectType.Box Then 'The object is a Box

            'Tesselation of the original box.
            For i = 0 To BreakNumber - 2 'I is the cut number, always 1 less than breaknumber
                If i = 0 Then 'First cut
                    TessellateBox(NewObjects(0), NewObjects(1), Sim.Objects(Index))
                Else
                    TessNumber = ToInt32(i * Sim.RandMaker.GetNext) 'Get a random box
                    TessBox.Copy(NewObjects(TessNumber)) 'Copy that box 
                    TessellateBox(NewObjects(TessNumber), NewObjects(i + 1), TessBox)
                End If
            Next

            'Assign mass to each new box based on thier volume
            OldVolume = 1 / (Sim.Objects(Index).Size.X * Sim.Objects(Index).Size.Y * Sim.Objects(Index).Size.Z)
            For r = 0 To BreakNumber - 1
                MassAssigned(r) = (NewObjects(r).Size.X * NewObjects(r).Size.Y * NewObjects(r).Size.Z) * OldVolume 'Fraction of the old mass that each new box will get
                NewObjects(r).Mass = MassAssigned(r) * Sim.Objects(Index).Mass
            Next

            'ASSIGN CHARGE BASED ON MASS
            If Sim.Config.Forces.ElectroStatic.Enabled Then
                For Z = 0 To BreakNumber - 1
                    NewObjects(Z).Charge = MassAssigned(Z) * Sim.Objects(Index).Charge 'Assign the charge to the final objects
                Next
            End If
        Else 'The object is a Sphere
            'Assign mass to each objects
            TotalMass = 0
            For z = 0 To BreakNumber - 1
                MassAssigned(z) = Sim.RandMaker.GetNext
                TotalMass += MassAssigned(z)
            Next

            'Apply mass and position
            For Z = 0 To BreakNumber - 1
                MassAssigned(Z) /= TotalMass 'Find each object's fraction of the total mass
                NewObjects(Z).Mass = MassAssigned(Z) * Sim.Objects(Index).Mass 'Assign the masses to the final object
                NewObjects(Z).Radius = (MassAssigned(Z) ^ 0.33333333333333331) * Sim.Objects(Index).Radius
                RadiusTemp = Sim.Objects(Index).Radius - NewObjects(Z).Radius
                If Sim.RandMaker.GetNext() > 0.5 Then RadiusTemp = -RadiusTemp
                NewObjects(Z).Position = Sim.Objects(Index).Position + (RadiusTemp * NewObjects(Z).Velocity.GetNewUnit)
            Next

            'ASSIGN CHARGE BASED ON MASS
            If Sim.Config.Forces.ElectroStatic.Enabled Then
                For Z = 0 To BreakNumber - 1
                    NewObjects(Z).Charge = MassAssigned(Z) * Sim.Objects(Index).Charge 'Assign the charge to the final objects
                Next
            End If
        End If



        'COPY THE NEW OBJECTS OVER
        Sim.Render.RenderLock.EnterWriteLock() ' Make sure the Renderer isn't loading the data 
        Sim.Objects(Index).Copy(NewObjects(0)) 'Copy over the new objects into the simulation
        For Z = 1 To BreakNumber - 1
            Sim.Objects(Sim.ObjectCount) = New SimulationObject
            Sim.Objects(Sim.ObjectCount).Copy(NewObjects(Z))
            Sim.ObjectCount += 1
        Next
        Sim.Render.RenderLock.ExitWriteLock()
    End Sub
    Private Sub TessellateBox(ByRef NewObject1 As SimulationObject, ByRef NewObject2 As SimulationObject, ByRef OldObject As SimulationObject)
        Dim TessX As Double = Sim.RandMaker.GetNext
        Dim TessY As Double = Sim.RandMaker.GetNext
        Dim TessZ As Double = Sim.RandMaker.GetNext
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
End Class
