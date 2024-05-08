Imports System.ComponentModel
Imports System.Windows.Forms.DataFormats

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
        If Sim.Config.Collisions.Enabled AndAlso Sim.Config.Collisions.Interpolate Then
            'Collisions with interpolation
            Do While Sim.Running
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).OldPosition.Copy(Sim.Objects(i).Position)
                Next

                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += Sim.Objects(i).Velocity * timeStep
                Next
                SimulationRender.RenderLock.ExitWriteLock()

                DoCollisions(Sim) 'Collisions must be after
                ComputationControl()
            Loop
        ElseIf Sim.Config.Collisions.Enabled Then
            'Collisions but not interpolation
            Do While Sim.Running
                DoCollisions(Sim)

                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += Sim.Objects(i).Velocity * timeStep
                Next
                SimulationRender.RenderLock.ExitWriteLock()

                ComputationControl()
            Loop
        Else
            'No collisions at all
            Do While Sim.Running
                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += Sim.Objects(i).Velocity * timeStep
                Next
                SimulationRender.RenderLock.ExitWriteLock()
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
                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += Sim.Objects(i).Velocity * timeStep
                Next
                SimulationRender.RenderLock.ExitWriteLock()

                DoCollisions(Sim)
                ComputationControl()
            Loop
        ElseIf Sim.Config.Collisions.Enabled Then
            Do While Sim.Running
                DoCollisions(Sim)
                DoForces()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Velocity += Sim.Objects(i).Acceleration * timeStep
                Next

                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += Sim.Objects(i).Velocity * timeStep
                Next
                SimulationRender.RenderLock.ExitWriteLock()

                ComputationControl()
            Loop
        Else
            Do While Sim.Running
                DoForces()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Velocity += Sim.Objects(i).Acceleration * timeStep
                Next

                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += Sim.Objects(i).Velocity * timeStep
                Next
                SimulationRender.RenderLock.ExitWriteLock()

                ComputationControl()
            Loop
        End If
    End Sub
    Private Sub DoComputeVerlet(timeStep As Double)
        Dim HalfT As Double = 0.5 * timeStep
        Dim HalfTSqd As Double = HalfT * timeStep

        If Sim.Config.Collisions.Enabled AndAlso Sim.Config.Collisions.Interpolate Then
            DoForces() 'Initial forces

            Do While Sim.Running

                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).OldPosition.Copy(Sim.Objects(i).Position)
                Next

                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += (Sim.Objects(i).Velocity * timeStep) + (HalfTSqd * Sim.Objects(i).Acceleration)
                Next
                SimulationRender.RenderLock.ExitWriteLock()

                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Velocity += HalfT * Sim.Objects(i).Acceleration
                Next

                DoForces()

                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Velocity += Sim.Objects(i).Acceleration * HalfT
                Next

                DoCollisions(Sim)
                ComputationControl()
            Loop
        ElseIf Sim.Config.Collisions.Enabled Then
            DoForces() 'Initial forces
            Do While Sim.Running
                DoCollisions(Sim)

                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += (Sim.Objects(i).Velocity * timeStep) + (HalfTSqd * Sim.Objects(i).Acceleration)
                Next
                SimulationRender.RenderLock.ExitWriteLock()

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

                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += (Sim.Objects(i).Velocity * timeStep) + (HalfTSqd * Sim.Objects(i).Acceleration)

                Next
                SimulationRender.RenderLock.ExitWriteLock()

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

        If Sim.Config.Collisions.Enabled AndAlso Sim.Config.Collisions.Interpolate Then
            Do While Sim.Running

                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).OldPosition.Copy(Sim.Objects(i).Position)
                Next

                For j = 0 To 2
                    SimulationRender.RenderLock.EnterWriteLock()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Position += c(j) * Sim.Objects(i).Velocity
                    Next
                    SimulationRender.RenderLock.ExitWriteLock()

                    DoForces()

                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Velocity += d(j) * Sim.Objects(i).Acceleration
                    Next
                Next
                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += c(3) * Sim.Objects(i).Velocity
                Next
                SimulationRender.RenderLock.ExitWriteLock()
                DoCollisions(Sim)
                ComputationControl()
            Loop
        ElseIf Sim.Config.Collisions.Enabled Then
            Do While Sim.Running
                DoCollisions(Sim)

                For j = 0 To 2
                    SimulationRender.RenderLock.EnterWriteLock()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Position += c(j) * Sim.Objects(i).Velocity
                    Next
                    SimulationRender.RenderLock.ExitWriteLock()
                    DoForces()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Velocity += d(j) * Sim.Objects(i).Acceleration
                    Next
                Next
                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += c(3) * Sim.Objects(i).Velocity
                Next
                SimulationRender.RenderLock.ExitWriteLock()
                ComputationControl()
            Loop
        Else

            Do While Sim.Running
                For j = 0 To 2
                    SimulationRender.RenderLock.EnterWriteLock()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Position += c(j) * Sim.Objects(i).Velocity
                    Next
                    SimulationRender.RenderLock.ExitWriteLock()

                    DoForces()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Velocity += d(j) * Sim.Objects(i).Acceleration
                    Next
                Next

                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += c(3) * Sim.Objects(i).Velocity
                Next
                SimulationRender.RenderLock.ExitWriteLock()
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

        If Sim.Config.Collisions.Enabled AndAlso Sim.Config.Collisions.Interpolate Then
            Do While Sim.Running
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).OldPosition.Copy(Sim.Objects(i).Position)
                Next
                For j = 0 To 6
                    SimulationRender.RenderLock.EnterWriteLock()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Position += c(j) * Sim.Objects(i).Velocity
                    Next
                    SimulationRender.RenderLock.ExitWriteLock()
                    DoForces()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Velocity += d(j) * Sim.Objects(i).Acceleration
                    Next
                Next
                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += c(7) * Sim.Objects(i).Velocity
                Next
                SimulationRender.RenderLock.ExitWriteLock()
                DoCollisions(Sim)
                ComputationControl()
            Loop
        ElseIf Sim.Config.Collisions.Enabled Then

            Do While Sim.Running
                For j = 0 To 6
                    SimulationRender.RenderLock.EnterWriteLock()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Position += c(j) * Sim.Objects(i).Velocity
                    Next
                    SimulationRender.RenderLock.ExitWriteLock()
                    DoForces()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Velocity += d(j) * Sim.Objects(i).Acceleration
                    Next
                Next
                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += c(7) * Sim.Objects(i).Velocity
                Next
                SimulationRender.RenderLock.ExitWriteLock()
                DoCollisions(Sim)
                ComputationControl()
            Loop
        Else
            Do While Sim.Running

                For j = 0 To 6

                    SimulationRender.RenderLock.EnterWriteLock()
                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Position += c(j) * Sim.Objects(i).Velocity
                    Next
                    SimulationRender.RenderLock.ExitWriteLock()

                    DoForces()

                    For i = 0 To Sim.ObjectCount - 1
                        Sim.Objects(i).Velocity += d(j) * Sim.Objects(i).Acceleration
                    Next
                Next

                SimulationRender.RenderLock.EnterWriteLock()
                For i = 0 To Sim.ObjectCount - 1
                    Sim.Objects(i).Position += c(7) * Sim.Objects(i).Velocity
                Next
                SimulationRender.RenderLock.ExitWriteLock()

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

#Region "Forces"
    Private Sub DoForces()
        Dim QtoIDistance As Double
        Dim AccMagi As Double
        Dim AccMagq As Double
        Dim Coeff As XYZ
        Dim DragMultiplier As Double
        Dim ReynoldsNumber As XYZ
        Dim ReynoldsMultiplier As Double
        Dim StokesDragConst As Double
        Dim QtoIPosistion As XYZ
        Dim QtoIDistanceSqd As Double
        Dim Ectemp As Double
        Dim firstObjIdx As Integer
        Dim secondObjIdx As Integer
        '~~~~~~~~~~~~~~~~~~~GLOBAL FORCES~~~~~~~~~~~~~~~~~
        If Sim.Config.Forces.Field.Enabled Then
            'Apply field
            For firstObjIdx = 0 To Sim.ObjectCount - 1
                If Sim.Objects(firstObjIdx).Affected Then
                    Sim.Objects(firstObjIdx).Acceleration.Copy(Sim.Config.Forces.Field.Acceleration)
                Else
                    Sim.Objects(firstObjIdx).Acceleration.MakeZero()
                End If
            Next
        Else
            'Reset acceleration to zero
            For firstObjIdx = 0 To Sim.ObjectCount - 1
                Sim.Objects(firstObjIdx).Acceleration.MakeZero()
            Next
        End If
        '~~~~~~~~~~~~~OBJECT ENVIRONMENT FORCES~~~~~~~~~~~~~~
        If Sim.Config.Forces.Drag.Enabled Then
            For firstObjIdx = 0 To Sim.ObjectCount - 1
                If Sim.Objects(firstObjIdx).Affected Then
                    ReynoldsMultiplier = (Sim.Config.Forces.Drag.Density * Sim.Objects(firstObjIdx).Radius * 2) / Sim.Config.Forces.Drag.Viscosity
                    StokesDragConst = (6 * PI * Sim.Config.Forces.Drag.Viscosity * Sim.Objects(firstObjIdx).Radius) / Sim.Objects(firstObjIdx).Mass
                    DragMultiplier = (0.5 * Sim.Config.Forces.Drag.Density * Sim.Config.Forces.Drag.DragCoeff * Math.PI * Sim.Objects(firstObjIdx).Radius * Sim.Objects(firstObjIdx).Radius) / Sim.Objects(firstObjIdx).Mass
                    ReynoldsNumber = ReynoldsMultiplier * Sim.Objects(firstObjIdx).Velocity.Abs
                    If ReynoldsNumber.X < 30 Then
                        Sim.Objects(firstObjIdx).Acceleration.X -= StokesDragConst * Sim.Objects(firstObjIdx).Velocity.X
                    Else
                        Sim.Objects(firstObjIdx).Acceleration.X -= DragMultiplier * Sim.Objects(firstObjIdx).Velocity.X * Math.Abs(Sim.Objects(firstObjIdx).Velocity.X)
                    End If
                    If ReynoldsNumber.Y < 30 Then
                        Sim.Objects(firstObjIdx).Acceleration.Y -= StokesDragConst * Sim.Objects(firstObjIdx).Velocity.Y
                    Else
                        Sim.Objects(firstObjIdx).Acceleration.Y -= DragMultiplier * Sim.Objects(firstObjIdx).Velocity.Y * Math.Abs(Sim.Objects(firstObjIdx).Velocity.Y)
                    End If
                    If ReynoldsNumber.Z < 30 Then
                        Sim.Objects(firstObjIdx).Acceleration.Z -= StokesDragConst * Sim.Objects(firstObjIdx).Velocity.Z
                    Else
                        Sim.Objects(firstObjIdx).Acceleration.Z -= DragMultiplier * Sim.Objects(firstObjIdx).Velocity.Z * Math.Abs(Sim.Objects(firstObjIdx).Velocity.Z)
                    End If
                End If
            Next
        End If

        If Sim.Config.Forces.Gravity Or Sim.Config.Forces.ElectroStatic.Enabled Then
            '~~~~~~~~~~~~~OBJECT OBJECT FORCES~~~~~~~~~~~~~~
            For firstObjIdx = 0 To Sim.ObjectCount - 2
                For secondObjIdx = firstObjIdx + 1 To Sim.ObjectCount - 1
                    If (Sim.Objects(firstObjIdx).Affected AndAlso Sim.Objects(secondObjIdx).Affects) OrElse (Sim.Objects(secondObjIdx).Affected AndAlso Sim.Objects(firstObjIdx).Affects) Then 'If the objects are allowed to interact

                        QtoIPosistion = (Sim.Objects(secondObjIdx).Position - Sim.Objects(firstObjIdx).Position)
                        QtoIDistanceSqd = QtoIPosistion.MagnitudeSquared
                        QtoIDistance = Math.Sqrt(QtoIDistanceSqd)
                        Coeff = QtoIPosistion / QtoIDistance

                        '~~~~~~~~~~~~~NEWTONIAN GRAVITY~~~~~~~~~~~~~~
                        If Sim.Config.Forces.Gravity Then
                            AccMagi = (G * Sim.Objects(secondObjIdx).Mass) / (QtoIDistanceSqd)
                            AccMagq = (-G * Sim.Objects(firstObjIdx).Mass) / (QtoIDistanceSqd)
                            If Sim.Objects(firstObjIdx).Affected And Sim.Objects(secondObjIdx).Affects Then
                                Sim.Objects(firstObjIdx).Acceleration += AccMagi * Coeff
                            End If
                            If Sim.Objects(secondObjIdx).Affected And Sim.Objects(firstObjIdx).Affects Then
                                Sim.Objects(secondObjIdx).Acceleration += AccMagq * Coeff
                            End If
                        End If
                        '~~~~~~~~~~~~~ELECTRONMAGNATISM~~~~~~~~~~~~~~
                        If Sim.Config.Forces.ElectroStatic.Enabled Then
                            Ectemp = (Ec * Sim.Objects(secondObjIdx).Charge * Sim.Objects(firstObjIdx).Charge)
                            AccMagi = -(Ectemp / (QtoIDistanceSqd * Sim.Objects(firstObjIdx).Mass))
                            AccMagq = (Ectemp / (QtoIDistanceSqd * Sim.Objects(secondObjIdx).Mass))
                            If Sim.Objects(firstObjIdx).Affected And Sim.Objects(secondObjIdx).Affects Then
                                Sim.Objects(firstObjIdx).Acceleration += AccMagi * Coeff
                            End If
                            If Sim.Objects(secondObjIdx).Affected And Sim.Objects(firstObjIdx).Affects Then
                                Sim.Objects(secondObjIdx).Acceleration += AccMagq * Coeff
                            End If
                        End If
                    End If
                Next
            Next
        End If
    End Sub
#End Region


End Class
