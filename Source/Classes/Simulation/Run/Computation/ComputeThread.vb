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

                DoCollisions() 'Collisions must be after
                ComputationControl()
            Loop
        ElseIf Sim.Config.Collisions.Enabled Then
            'Collisions but not interpolation
            Do While Sim.Running
                DoCollisions()

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

                DoCollisions()
                ComputationControl()
            Loop
        ElseIf Sim.Config.Collisions.Enabled Then
            DoForces() 'Initial forces
            Do While Sim.Running
                DoCollisions()

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
                DoCollisions()
                ComputationControl()
            Loop
        ElseIf Sim.Config.Collisions.Enabled Then
            Do While Sim.Running
                DoCollisions()

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
                DoCollisions()
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
                DoCollisions()
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
#Region "Collisions"
    Private Sub DoSphereInfinitePlaneCollision(ByRef Sphere As SimulationObject, ByRef Plane As SimulationObject)
        Dim ObjDistance As Double

        'Calculate the distance between the sphere center and the closest point on the (infinite) plane
        ObjDistance = Plane.Normal.Dot(Sphere.Position) - Plane.Normal.Dot(Plane.Position)
        If Math.Abs(ObjDistance) > Sphere.Radius Then Return  ' Sphere is completely outside the plane

        'System.Console.Beep()
    End Sub

    Private Sub DoBoxBoxCollision(ByRef Box1 As SimulationObject, ByRef Box2 As SimulationObject)
        'TODO
    End Sub

    Private Sub DoSpherePlaneCollision(ByRef Sphere As SimulationObject, ByRef Plane As SimulationObject)
        'TODO: Finite plane object with sphere
        'DoSpherePlaneCollision(Sphere, Plane.Normal, Plane.Position, Plane.HalfSize, Plane.)

    End Sub
    Private Sub DoSpherePlaneCollision(ByRef Sphere As SimulationObject, ByRef PlaneNormal As XYZ, ByRef PlaneCenter As XYZ, ByRef PlaneLimits As XYZ, rotationMatrixTranpose As Matrix3x3)

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        '----- CHECK IF COMPLETELY OUTSIDE THE INFITE PLANE -----
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        'Calculate the distance between the sphere center and the closest point on the (infinite) plane
        Dim ObjDistance As Double = PlaneNormal.Dot(Sphere.Position) - PlaneNormal.Dot(PlaneCenter)
        If Math.Abs(ObjDistance) > Sphere.Radius Then Return  ' Sphere is completely outside the plane

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        '----- CHECK IF THE SPHERE CENTER IS INSIDE THE PLANE -----
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        ' Project the sphere center onto the plane to find the closest point
        Dim closestPoint As XYZ = Sphere.Position - (PlaneNormal * ObjDistance)

        'Calculate the distance from the closest point to the plane's center
        'Note that the plane's center positions is already rotated
        Dim projectionFromPlaneCenter As XYZ = (closestPoint - PlaneCenter)

        'We need to counter rotate the projection vector back to the reference coordinate system
        'so we can check it against the 2D bounds of the plane
        projectionFromPlaneCenter.Rotate(rotationMatrixTranpose)

        'The plane in symetrical in both axis
        projectionFromPlaneCenter.MakeMeAbs()

        'Now check if this point is within the plane's bounds
        If Not (projectionFromPlaneCenter <= PlaneLimits) Then
            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            '----- CHECK IF THE SPHERE IS ON AN EDGE              -----
            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            'TODO: FINSIH ME
            Return
        End If

        'WE DID Collide

        ' System.Console.Beep()
    End Sub

    Private Sub DoSphereBoxCollision(ByRef Sphere As SimulationObject, ByRef Box As SimulationObject)
        DoSpherePlaneCollision(Sphere, Box.BoxCollisionData.FrontPlaneNormalRotated, Box.Position + Box.BoxCollisionData.FrontPlaneCenterRotated, Box.BoxCollisionData.FrontPlaneLimits, Box.BoxCollisionData.RotationMatrixTranpose)
        DoSpherePlaneCollision(Sphere, Box.BoxCollisionData.BackPlaneNormalRotated, Box.Position + Box.BoxCollisionData.BackPlaneCenterRotated, Box.BoxCollisionData.BackPlaneLimits, Box.BoxCollisionData.RotationMatrixTranpose)
        DoSpherePlaneCollision(Sphere, Box.BoxCollisionData.TopPlaneNormalRotated, Box.Position + Box.BoxCollisionData.TopPlaneCenterRotated, Box.BoxCollisionData.TopPlaneLimits, Box.BoxCollisionData.RotationMatrixTranpose)
        DoSpherePlaneCollision(Sphere, Box.BoxCollisionData.BottomPlaneNormalRotated, Box.Position + Box.BoxCollisionData.BottomPlaneCenterRotated, Box.BoxCollisionData.BottomPlaneLimits, Box.BoxCollisionData.RotationMatrixTranpose)
        DoSpherePlaneCollision(Sphere, Box.BoxCollisionData.LeftPlaneNormalRotated, Box.Position + Box.BoxCollisionData.LeftPlaneCenterRotated, Box.BoxCollisionData.LeftPlaneLimits, Box.BoxCollisionData.RotationMatrixTranpose)
        DoSpherePlaneCollision(Sphere, Box.BoxCollisionData.RightPlaneNormalRotated, Box.Position + Box.BoxCollisionData.RightPlaneCenterRotated, Box.BoxCollisionData.RightPlaneLimits, Box.BoxCollisionData.RotationMatrixTranpose)
    End Sub


    Private Sub DoSphereSphereCollision(ByRef Sphere1 As SimulationObject, ByRef Sphere2 As SimulationObject)
        Dim ObjPosistionDiff As XYZ
        Dim ObjDistanceSqd As Double
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

        SumofRadius = Sphere1.Radius + Sphere2.Radius
        ObjPosistionDiff = Sphere2.Position - Sphere1.Position

        If Sim.Config.Collisions.Interpolate Then
            'Find the values for the quadratic describing the path of intersection of the objects
            QtoIOldPosistion = Sphere1.OldPosition - Sphere2.OldPosition
            OldToNewPosition = -(ObjPosistionDiff + QtoIOldPosistion)
            A = (OldToNewPosition.X * OldToNewPosition.X) + (OldToNewPosition.Y * OldToNewPosition.Y) + (OldToNewPosition.Z * OldToNewPosition.Z)
            B = -2 * ((OldToNewPosition.X * QtoIOldPosistion.X) + (OldToNewPosition.Y * QtoIOldPosistion.Y) + (OldToNewPosition.Z * QtoIOldPosistion.Z))
            C = (QtoIOldPosistion.X * QtoIOldPosistion.X) + (QtoIOldPosistion.Y * QtoIOldPosistion.Y) + (QtoIOldPosistion.Z * QtoIOldPosistion.Z) - (SumofRadius * SumofRadius)

            'Reset the collision flag
            DidCollide = False

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
            If Not DidCollide Then Return 'No Collision Occured

            'Move the objects back to where they would have been at the time of the collision
            SimulationRender.RenderLock.EnterWriteLock()
            Sphere1.Position = ((Sphere1.Position - Sphere1.OldPosition) * CollisionTime) + Sphere1.OldPosition
            Sphere2.Position = ((Sphere2.Position - Sphere2.OldPosition) * CollisionTime) + Sphere2.OldPosition
            SimulationRender.RenderLock.ExitWriteLock()

            'Recalculate thier seperation
            ObjPosistionDiff = Sphere2.Position - Sphere1.Position
            ObjDistanceSqd = ObjPosistionDiff.MagnitudeSquared
            DotProductI = Sphere1.Velocity.Dot(ObjPosistionDiff)
            DotProductQ = Sphere2.Velocity.Dot(ObjPosistionDiff)

        Else 'No interpolation
            ObjDistanceSqd = ObjPosistionDiff.MagnitudeSquared
            If ObjDistanceSqd > SumofRadius * SumofRadius Then Return 'Check that they are touching
            DotProductI = Sphere1.Velocity.Dot(ObjPosistionDiff)
            DotProductQ = Sphere2.Velocity.Dot(ObjPosistionDiff)
            If DotProductQ - DotProductI >= 0 Then Return 'Check that the are coming together
        End If


        DotProductMagI = DotProductI / ObjDistanceSqd
        DotProductMagQ = DotProductQ / ObjDistanceSqd
        VI = DotProductMagI * ObjPosistionDiff
        VQ = DotProductMagQ * ObjPosistionDiff

        'Handle object bounce
        SumofMasses = Sphere1.Mass + Sphere2.Mass
        If Sim.Config.Collisions.CoR = 0 Then '~~~~~~~~~~~PLASTIC OBJECT OBJECT COLLISION~~~~~~~~~~~
            NewVI = ((Sphere2.Mass * VQ) + (VI * Sphere1.Mass)) / SumofMasses
            Sphere1.Velocity.Copy(NewVI + (Sphere1.Velocity - VI))
            Sphere2.Velocity.Copy(NewVI + (Sphere2.Velocity - VQ))
        ElseIf Sim.Config.Collisions.CoR = 1 Then  '~~~~~~ELASTIC OBJECT OBJECT COLLISION~~~~~~~~~~~
            TempDouble4 = Sphere1.Mass / SumofMasses
            TempDouble5 = Sphere2.Mass / SumofMasses
            TempDouble = TempDouble4 - TempDouble5
            Sphere1.Velocity += ((TempDouble5 + TempDouble5) * VQ) + (VI * (TempDouble - 1))
            Sphere2.Velocity += ((TempDouble4 + TempDouble4) * VI) - (VQ * (TempDouble + 1))
        Else '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~PARTIAL OBJECT OBJECT COLLISION~~~~~~~~~~~
            TempDouble4 = Sphere1.Mass / SumofMasses
            TempDouble5 = Sphere2.Mass / SumofMasses
            TempDouble3 = Sim.Config.Collisions.CoR + 1
            Sphere1.Velocity += (TempDouble3 * TempDouble5 * VQ) + (VI * (TempDouble4 - (Sim.Config.Collisions.CoR * TempDouble5) - 1))
            Sphere2.Velocity += (TempDouble3 * TempDouble4 * VI) + (VQ * (TempDouble5 - (Sim.Config.Collisions.CoR * TempDouble4) - 1))
        End If

        If Sim.Config.Collisions.Interpolate Then
            'Move the objects forward by the remaining time
            SimulationRender.RenderLock.EnterWriteLock()
            Sphere1.Position += Sphere1.Velocity * (Sim.Config.Settings.TimeStep * (1 - CollisionTime))
            Sphere2.Position += Sphere2.Velocity * (Sim.Config.Settings.TimeStep * (1 - CollisionTime))
            SimulationRender.RenderLock.ExitWriteLock()
        End If

        '~~~~~~~~~~~~~~BREAKABLE OBJECT OBJECT COLLISION~~~~~~~~~~~~
        If Not Sim.Config.Collisions.Breakable Or Sim.ObjectCount >= Sim.Config.Settings.MaxObjects Or Sim.Config.Collisions.CoR = 1 Then Return

        DeltaKineticI = Math.Abs(VI.MagnitudeSquared + VQ.MagnitudeSquared - Sphere1.Velocity.MagnitudeSquared - Sphere2.Velocity.MagnitudeSquared)
        DeltaKineticQ = DeltaKineticI
        DeltaKineticI *= Sphere1.Mass
        DeltaKineticQ *= Sphere2.Mass

        'Determine if Sphere2 will break
        If DeltaKineticQ >= Sim.Config.Collisions.BreakMax Then
            DoBreak(Sphere1)
        ElseIf DeltaKineticQ >= Sim.Config.Collisions.BreakMin Then
            If DeltaKineticQ = Sim.Config.Collisions.BreakAvg Then
                If Sim.RandMaker.GetNext() > 0.5 Then DoBreak(Sphere2)
            Else
                If Sim.RandMaker.GetNext < Sim.RandMaker.GetProbibility(DeltaKineticQ, Sim.Config.Collisions.BreakAvg, Sim.Config.Collisions.BreakMin, Sim.Config.Collisions.BreakMax) Then DoBreak(Sphere2) 'Get probibility and compare it to a random number
            End If
        End If

        'Determine if Sphere1 will break
        If Sim.ObjectCount >= Sim.Config.Settings.MaxObjects Then Return

        If DeltaKineticI >= Sim.Config.Collisions.BreakMax Then
            DoBreak(Sphere1)
        ElseIf DeltaKineticI >= Sim.Config.Collisions.BreakMin Then
            If DeltaKineticI = Sim.Config.Collisions.BreakAvg Then
                If Sim.RandMaker.GetNext() > 0.5 Then DoBreak(Sphere1)
            Else
                If Sim.RandMaker.GetNext < Sim.RandMaker.GetProbibility(DeltaKineticI, Sim.Config.Collisions.BreakAvg, Sim.Config.Collisions.BreakMin, Sim.Config.Collisions.BreakMax) Then DoBreak(Sphere1) 'Get probibility and compare it to a random number
            End If
        End If
    End Sub
    Private Sub DoCollisions()
        Dim second As Integer

        '~~~~~~~~~~~~~OBJECT OBJECT COLLISION~~~~~~~~~~~~
        'Check every object against every other object
        'TODO: this would benefit greatly from a bounding volume hierarchy
        For first = 0 To Sim.ObjectCount - 2
            For second = first + 1 To Sim.ObjectCount - 1

                'If both objects cannot be affected by other objects then ignore collisions
                'If both objects cannot be affect other objects then ignore collisions
                If (Not Sim.Objects(first).Affected AndAlso Not Sim.Objects(second).Affected) OrElse (Not Sim.Objects(first).Affects AndAlso Not Sim.Objects(second).Affects) Then Continue For

                'TODO: More object type permutations
                If Sim.Objects(first).Type = ObjectType.Sphere Then
                    If Sim.Objects(second).Type = ObjectType.Sphere Then
                        DoSphereSphereCollision(Sim.Objects(first), Sim.Objects(second))
                    ElseIf Sim.Objects(second).Type = ObjectType.Box Then
                        DoSphereBoxCollision(Sim.Objects(first), Sim.Objects(second))
                    ElseIf Sim.Objects(second).Type = ObjectType.InfinitePlane Then
                        DoSphereInfinitePlaneCollision(Sim.Objects(first), Sim.Objects(second))
                    End If

                ElseIf Sim.Objects(first).Type = ObjectType.Box Then
                    If Sim.Objects(second).Type = ObjectType.Sphere Then
                        DoSphereBoxCollision(Sim.Objects(second), Sim.Objects(first))
                    ElseIf Sim.Objects(second).Type = ObjectType.Box Then
                        DoBoxBoxCollision(Sim.Objects(first), Sim.Objects(second))
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

#Region "Object Breaking"
    Private Sub DoBreak(ByRef SimObject As SimulationObject)
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
        VelocityI = SimObject.Velocity
        VelocityMagnitudeI = VelocityI.Magnitude
        VelocityI /= VelocityMagnitudeI
        VelocityJ = VelocityI.Perpendicular
        VelocityK = VelocityI.Cross(VelocityJ)
        VelocityMagnitudeI *= BreakNumber

        'CREATE NEW OBJECTS AND ASSIGN NON-RANDOM PARAMETERS
        For z = 0 To BreakNumber - 1
            NewObjects(z) = New SimulationObject
            NewObjects(z).Affected = SimObject.Affected
            NewObjects(z).Affects = SimObject.Affects
            NewObjects(z).HighlightColor = SimObject.HighlightColor
            NewObjects(z).HighlightSharpness = SimObject.HighlightSharpness
            NewObjects(z).Reflectivity = SimObject.Reflectivity
            NewObjects(z).RefractiveIndex = SimObject.RefractiveIndex
            NewObjects(z).Transparency = SimObject.Transparency
            NewObjects(z).Wireframe = SimObject.Wireframe
            NewObjects(z).Type = SimObject.Type
            NewObjects(z).Color = SimObject.Color
            NewObjects(z).Rotation.Copy(SimObject.Rotation)
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
        If SimObject.Type = ObjectType.Box Then 'The object is a Box

            'Tesselation of the original box.
            For i = 0 To BreakNumber - 2 'I is the cut number, always 1 less than breaknumber
                If i = 0 Then 'First cut
                    TessellateBox(NewObjects(0), NewObjects(1), SimObject)
                Else
                    TessNumber = ToInt32(i * Sim.RandMaker.GetNext) 'Get a random box
                    TessBox.Copy(NewObjects(TessNumber)) 'Copy that box 
                    TessellateBox(NewObjects(TessNumber), NewObjects(i + 1), TessBox)
                End If
            Next

            'Assign mass to each new box based on thier volume
            OldVolume = 1 / (SimObject.Size.X * SimObject.Size.Y * SimObject.Size.Z)
            For r = 0 To BreakNumber - 1
                MassAssigned(r) = (NewObjects(r).Size.X * NewObjects(r).Size.Y * NewObjects(r).Size.Z) * OldVolume 'Fraction of the old mass that each new box will get
                NewObjects(r).Mass = MassAssigned(r) * SimObject.Mass
            Next

            'ASSIGN CHARGE BASED ON MASS
            If Sim.Config.Forces.ElectroStatic.Enabled Then
                For Z = 0 To BreakNumber - 1
                    NewObjects(Z).Charge = MassAssigned(Z) * SimObject.Charge 'Assign the charge to the final objects
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
                NewObjects(Z).Mass = MassAssigned(Z) * SimObject.Mass 'Assign the masses to the final object
                NewObjects(Z).Radius = (MassAssigned(Z) ^ 0.33333333333333331) * SimObject.Radius
                RadiusTemp = SimObject.Radius - NewObjects(Z).Radius
                If Sim.RandMaker.GetNext() > 0.5 Then RadiusTemp = -RadiusTemp
                NewObjects(Z).Position = SimObject.Position + (RadiusTemp * NewObjects(Z).Velocity.GetNewUnit)
            Next

            'ASSIGN CHARGE BASED ON MASS
            If Sim.Config.Forces.ElectroStatic.Enabled Then
                For Z = 0 To BreakNumber - 1
                    NewObjects(Z).Charge = MassAssigned(Z) * SimObject.Charge 'Assign the charge to the final objects
                Next
            End If
        End If



        'COPY THE NEW OBJECTS OVER
        SimulationRender.RenderLock.EnterWriteLock() ' Make sure the Renderer isn't loading the data 
        SimObject.Copy(NewObjects(0)) 'Copy over the new objects into the simulation
        For Z = 1 To BreakNumber - 1
            Sim.Objects(Sim.ObjectCount) = New SimulationObject
            Sim.Objects(Sim.ObjectCount).Copy(NewObjects(Z))
            Sim.ObjectCount += 1
        Next
        SimulationRender.RenderLock.ExitWriteLock()
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
