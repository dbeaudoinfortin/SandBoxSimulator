Public Module Collisions
    Private Sub DoSphereInfinitePlaneCollision(ByRef sim As SimulationRuntime, ByRef sphere As SimulationObject, ByRef plane As SimulationObject)

        'Determine if the two objects are moving together or apart. We only want to bounce the sphere if it is moving towards from the plane.
        Dim velocityDiff As XYZ = sphere.Velocity - plane.Velocity
        If velocityDiff.Dot(plane.Normal) >= 0 Then Return 'Objects are not colliding

        'Calculate the distance between the sphere center and the closest point on the (infinite) plane
        Dim ObjDistance As Double = plane.Normal.Dot(sphere.Position) - plane.Normal.Dot(plane.Position)
        If Math.Abs(ObjDistance) > sphere.Radius Then Return  ' Sphere is completely outside the plane

        'TODO: Support time step interpolation - Need to move the objects back to where they would have
        'been at the time of the collision

        'We have collided. Bounce the sphere back. Since the plane is only a 2D object, it has no mass and is thus unaffected by the sphere.
        Dim velocityDotNormalxCor As Double = sphere.Velocity.Dot(plane.Normal) * (1 + sim.Config.Collisions.CoR)
        Dim sphereOldVelocity = New XYZ(sphere.Velocity)
        sphere.Velocity -= (velocityDotNormalxCor * plane.Normal)

        'Handle breaking
        'Are breakable collisions enabled, is it a non-elastic collision and do we even have room for more objects?
        If Not sim.Config.Collisions.Breakable OrElse sim.Config.Collisions.CoR = 1 OrElse sim.ObjectCount >= sim.Config.Settings.MaxObjects Then Return

        'Calculate the kinetic energy consumed
        'The assumption here is that the sphere absorbs all of the impact energy since the plane is unaffected by the sphere.
        '½M(V₁² - V₂²))
        Dim energyConsumed As Double = (sphere.Mass * 0.5) * (sphereOldVelocity.MagnitudeSquared - sphere.Velocity.MagnitudeSquared)

        DoBreak(sim, sphere, energyConsumed)
    End Sub

    Private Sub DoBoxBoxCollision(ByRef box1 As SimulationObject, ByRef box2 As SimulationObject)
        'TODO
    End Sub

    Private Sub DoSpherePlaneCollision(ByRef sim As SimulationRuntime, ByRef sphere As SimulationObject, ByRef plane As SimulationObject)
        DoSpherePlaneCollision(sim, sphere, plane.Velocity, DirectCast(plane.CollisionData, PlaneCollisionData).NormalRotated, plane.Position, plane.HalfSize, plane.CollisionData.RotationMatrixTranpose)
    End Sub
    Private Function DoSpherePlaneCollision(ByRef sim As SimulationRuntime, ByRef sphere As SimulationObject, ByRef planeVelocity As XYZ, ByVal planeNormal As XYZ, ByRef planeCenter As XYZ, ByRef planeLimits As XYZ, rotationMatrixTranpose As Matrix3x3) As Boolean

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        '----- CHECK IF THE OBJECTS ARE MOVING APART -----
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        'Calculate the distance between the sphere center and the closest point on the (infinite) plane
        Dim ObjDistance As Double = planeNormal.Dot(sphere.Position) - planeNormal.Dot(planeCenter)

        'May need to adjust the normal vector of the plane to point towards the sphere
        If ObjDistance < 0 Then
            ' Reverse the normal vector since it points away from the sphere
            planeNormal = -planeNormal
        End If

        'Determine if the two objects are moving together or apart. We only want to bounce the sphere if it is moving towards from the plane.
        Dim velocityDotNormal As Double = (sphere.Velocity - planeVelocity).Dot(planeNormal)
        If velocityDotNormal >= 0 Then Return False 'Objects are not colliding

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        '----- CHECK IF COMPLETELY OUTSIDE THE INFITE PLANE -----
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        If Math.Abs(ObjDistance) > sphere.Radius Then Return False  ' Sphere is completely outside the plane

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        '----- CHECK IF THE SPHERE CENTER IS INSIDE THE PLANE -----
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        ' Project the sphere center onto the plane to find the closest point
        Dim closestPoint As XYZ = sphere.Position - (planeNormal * ObjDistance)

        'Calculate the distance from the closest point to the plane's center
        'Note that the plane's center positions is already rotated
        Dim projectionFromPlaneCenter As XYZ = (closestPoint - planeCenter)

        'We need to counter rotate the projection vector back to the reference coordinate system
        'so we can check it against the 2D bounds of the plane
        projectionFromPlaneCenter.Rotate(rotationMatrixTranpose)

        'The plane in symetrical in both axis
        projectionFromPlaneCenter.MakeMeAbs()

        'Now check if this point is within the plane's bounds
        If Not (projectionFromPlaneCenter <= planeLimits) Then
            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            '----- CHECK IF THE SPHERE IS ON AN EDGE              -----
            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            'TODO: FINSIH ME
            Return False
        End If

        'TODO: Support time step interpolation - Need to move the objects back to where they would have
        'been at the time of the collision

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        '----- BOUNCE THE SPHERE OFF OF THE PLANE             -----
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        'We have collided. Bounce the sphere back. Since the plane is only a 2D object, it has no mass and is thus unaffected by the sphere.
        Dim velocityDotNormalxCor As Double = sphere.Velocity.Dot(planeNormal) * (1 + sim.Config.Collisions.CoR)
        Dim sphereOldVelocity = New XYZ(sphere.Velocity)
        sphere.Velocity -= (velocityDotNormalxCor * planeNormal)

        'Handle breaking
        'Are breakable collisions enabled, is it a non-elastic collision and do we even have room for more objects?
        If Not sim.Config.Collisions.Breakable OrElse sim.Config.Collisions.CoR = 1 OrElse sim.ObjectCount >= sim.Config.Settings.MaxObjects Then Return True

        'Calculate the kinetic energy consumed
        'The assumption here is that the sphere absorbs all of the impact energy since the plane is unaffected by the sphere.
        '½M(V₁² - V₂²))
        Dim energyConsumed As Double = (sphere.Mass * 0.5) * (sphereOldVelocity.MagnitudeSquared - sphere.Velocity.MagnitudeSquared)

        DoBreak(sim, sphere, energyConsumed)
        Return True
    End Function

    Private Sub DoSphereBoxCollision(ByRef sim As SimulationRuntime, ByRef sphere As SimulationObject, ByRef box As SimulationObject)
        'I suppose a sphere could perfectly collide with the edge of multiple planes at once but we will ignore this for the sake of simplicity
        'Don't check other planes once we have detected a collision
        Dim collisionData As BoxCollisionData = DirectCast(box.CollisionData, BoxCollisionData)
        If DoSpherePlaneCollision(sim, sphere, box.Velocity, collisionData.FrontPlaneNormalRotated, box.Position + collisionData.FrontPlaneCenterRotated, collisionData.FrontPlaneLimits, collisionData.RotationMatrixTranpose) Then Return
        If DoSpherePlaneCollision(sim, sphere, box.Velocity, collisionData.BackPlaneNormalRotated, box.Position + collisionData.BackPlaneCenterRotated, collisionData.BackPlaneLimits, collisionData.RotationMatrixTranpose) Then Return
        If DoSpherePlaneCollision(sim, sphere, box.Velocity, collisionData.TopPlaneNormalRotated, box.Position + collisionData.TopPlaneCenterRotated, collisionData.TopPlaneLimits, collisionData.RotationMatrixTranpose) Then Return
        If DoSpherePlaneCollision(sim, sphere, box.Velocity, collisionData.BottomPlaneNormalRotated, box.Position + collisionData.BottomPlaneCenterRotated, collisionData.BottomPlaneLimits, collisionData.RotationMatrixTranpose) Then Return
        If DoSpherePlaneCollision(sim, sphere, box.Velocity, collisionData.LeftPlaneNormalRotated, box.Position + collisionData.LeftPlaneCenterRotated, collisionData.LeftPlaneLimits, collisionData.RotationMatrixTranpose) Then Return
        DoSpherePlaneCollision(sim, sphere, box.Velocity, collisionData.RightPlaneNormalRotated, box.Position + collisionData.RightPlaneCenterRotated, collisionData.RightPlaneLimits, collisionData.RotationMatrixTranpose)
    End Sub

    Private Sub DoSphereSphereCollision(ByRef sim As SimulationRuntime, ByRef sphere1 As SimulationObject, ByRef sphere2 As SimulationObject)

        Dim objDistanceSqd As Double
        Dim collisionTime As Double
        Dim dotProductSphere1 As Double
        Dim dotProductSphere2 As Double
        Dim sumofRadius As Double = sphere1.Radius + sphere2.Radius
        Dim objPosistionDiff As XYZ = sphere2.Position - sphere1.Position

        If sim.Config.Collisions.Interpolate Then 'Interpolation
            'Find the values for the quadratic describing the path of intersection of the objects
            Dim sphere1ToSphere2OldPosistion As XYZ = sphere1.OldPosition - sphere2.OldPosition
            Dim oldToNewPosition As XYZ = -(objPosistionDiff + sphere1ToSphere2OldPosistion)
            Dim a As Double = (oldToNewPosition.X * oldToNewPosition.X) + (oldToNewPosition.Y * oldToNewPosition.Y) + (oldToNewPosition.Z * oldToNewPosition.Z) 'TODO: this is the dot product
            Dim b As Double = -2 * ((oldToNewPosition.X * sphere1ToSphere2OldPosistion.X) + (oldToNewPosition.Y * sphere1ToSphere2OldPosistion.Y) + (oldToNewPosition.Z * sphere1ToSphere2OldPosistion.Z)) 'TODO: this is also the dot product
            Dim c As Double = (sphere1ToSphere2OldPosistion.X * sphere1ToSphere2OldPosistion.X) + (sphere1ToSphere2OldPosistion.Y * sphere1ToSphere2OldPosistion.Y) + (sphere1ToSphere2OldPosistion.Z * sphere1ToSphere2OldPosistion.Z) - (sumofRadius * sumofRadius) 'TODO: yup - dot product

            'Reset the collision flag
            Dim didCollide As Boolean = False

            'Solve the quadratic equation
            Dim discriminant As Double = (b * b) - (4 * a * c)
            If discriminant = 0 Then 'Glancing collision
                collisionTime = b / (2 * a)
                If collisionTime >= 0 And collisionTime <= 1 Then didCollide = True
            ElseIf discriminant > 0 Then ' They interpenetrated
                Dim tempDouble As Double = 1 / (2 * a)
                Dim time1 As Double = (b - Sqrt(discriminant)) * tempDouble
                Dim time2 As Double = (b + Sqrt(discriminant)) * tempDouble
                If time1 >= 0 And time1 <= 1 Then
                    If time2 >= 0 And time2 <= 1 Then
                        If time1 < time2 Then
                            collisionTime = time1
                            didCollide = True
                        Else
                            collisionTime = time2
                            didCollide = True
                        End If
                    Else
                        collisionTime = time1
                        didCollide = True
                    End If
                Else
                    If time2 >= 0 And time2 <= 1 Then
                        collisionTime = time2
                        didCollide = True
                    End If
                End If
            End If
            If Not didCollide Then Return 'No Collision Occured

            'Move the objects back to where they would have been at the time of the collision
            SimulationRender.RenderLock.EnterWriteLock()
            sphere1.Position = ((sphere1.Position - sphere1.OldPosition) * collisionTime) + sphere1.OldPosition
            sphere2.Position = ((sphere2.Position - sphere2.OldPosition) * collisionTime) + sphere2.OldPosition
            SimulationRender.RenderLock.ExitWriteLock()

            'Recalculate thier seperation
            objPosistionDiff = sphere2.Position - sphere1.Position
            objDistanceSqd = objPosistionDiff.MagnitudeSquared
            dotProductSphere1 = sphere1.Velocity.Dot(objPosistionDiff)
            dotProductSphere2 = sphere2.Velocity.Dot(objPosistionDiff)

        Else 'No interpolation
            objDistanceSqd = objPosistionDiff.MagnitudeSquared
            If objDistanceSqd > sumofRadius * sumofRadius Then Return 'Check that they are touching
            dotProductSphere1 = sphere1.Velocity.Dot(objPosistionDiff)
            dotProductSphere2 = sphere2.Velocity.Dot(objPosistionDiff)
            If dotProductSphere2 - dotProductSphere1 >= 0 Then Return 'Check that the are coming together
        End If

        Dim VI As XYZ = (dotProductSphere1 / objDistanceSqd) * objPosistionDiff
        Dim VQ As XYZ = (dotProductSphere2 / objDistanceSqd) * objPosistionDiff

        'Handle object bounce
        Dim sumofMasses As Double = sphere1.Mass + sphere2.Mass
        If sim.Config.Collisions.CoR = 0 Then '~~~~~~~~~~~PLASTIC OBJECT OBJECT COLLISION~~~~~~~~~~~
            Dim newVI As XYZ = ((sphere2.Mass * VQ) + (VI * sphere1.Mass)) / sumofMasses
            sphere1.Velocity.Copy(newVI + (sphere1.Velocity - VI))
            sphere2.Velocity.Copy(newVI + (sphere2.Velocity - VQ))
        ElseIf sim.Config.Collisions.CoR = 1 Then  '~~~~~~ELASTIC OBJECT OBJECT COLLISION~~~~~~~~~~~
            Dim sphere1MassFraction As Double = sphere1.Mass / sumofMasses
            Dim sphere2MassFraction As Double = sphere2.Mass / sumofMasses
            Dim tempDouble As Double = sphere1MassFraction - sphere2MassFraction
            sphere1.Velocity += ((sphere2MassFraction + sphere2MassFraction) * VQ) + (VI * (tempDouble - 1))
            sphere2.Velocity += ((sphere1MassFraction + sphere1MassFraction) * VI) - (VQ * (tempDouble + 1))
        Else '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~PARTIAL OBJECT OBJECT COLLISION~~~~~~~~~~~
            Dim sphere1MassFraction As Double = sphere1.Mass / sumofMasses
            Dim sphere2MassFraction As Double = sphere2.Mass / sumofMasses
            Dim tempDouble3 As Double = sim.Config.Collisions.CoR + 1
            sphere1.Velocity += (tempDouble3 * sphere2MassFraction * VQ) + (VI * (sphere1MassFraction - (sim.Config.Collisions.CoR * sphere2MassFraction) - 1))
            sphere2.Velocity += (tempDouble3 * sphere1MassFraction * VI) + (VQ * (sphere2MassFraction - (sim.Config.Collisions.CoR * sphere1MassFraction) - 1))
        End If

        If sim.Config.Collisions.Interpolate Then
            'Move the objects forward by the remaining time
            SimulationRender.RenderLock.EnterWriteLock()
            sphere1.Position += sphere1.Velocity * (sim.Config.Settings.TimeStep * (1 - collisionTime))
            sphere2.Position += sphere2.Velocity * (sim.Config.Settings.TimeStep * (1 - collisionTime))
            SimulationRender.RenderLock.ExitWriteLock()
        End If

        '~~~~~~~~~~~~~~BREAKABLE OBJECT OBJECT COLLISION~~~~~~~~~~~~
        'Are breakable collisions enabled, is it a non-elastic collision and do we even have room for more objects?
        If Not sim.Config.Collisions.Breakable OrElse sim.Config.Collisions.CoR = 1 OrElse sim.ObjectCount >= sim.Config.Settings.MaxObjects Then Return

        'Kinetic energy is ½M(V₁² - V₂²))
        Dim deltaKineticI As Double = (VI.MagnitudeSquared + VQ.MagnitudeSquared - sphere1.Velocity.MagnitudeSquared - sphere2.Velocity.MagnitudeSquared) * 0.5
        Dim deltaKineticQ As Double = deltaKineticI
        deltaKineticI *= sphere1.Mass
        deltaKineticQ *= sphere2.Mass

        DoBreak(sim, sphere1, deltaKineticI)
        DoBreak(sim, sphere2, deltaKineticQ)
    End Sub
    Public Sub DoCollisions(ByRef sim As SimulationRuntime)
        Dim second As Integer

        '~~~~~~~~~~~~~OBJECT OBJECT COLLISION~~~~~~~~~~~~
        'Check every object against every other object
        'TODO: this would benefit greatly from a bounding volume hierarchy
        For first = 0 To sim.ObjectCount - 2
            For second = first + 1 To sim.ObjectCount - 1

                'If both objects cannot be affected by other objects then ignore collisions
                'If both objects cannot be affect other objects then ignore collisions
                'If either object cannot be both affected and affect others then ignore collisions
                If (Not sim.Objects(first).Affected AndAlso Not sim.Objects(first).Affects) _
                    OrElse (Not sim.Objects(second).Affected AndAlso Not sim.Objects(second).Affects) _
                    OrElse (Not sim.Objects(first).Affected AndAlso Not sim.Objects(second).Affected) _
                    OrElse (Not sim.Objects(first).Affects AndAlso Not sim.Objects(second).Affects) Then Continue For

                'TODO: More object type permutations
                If sim.Objects(first).Type = ObjectType.Sphere Then
                    If sim.Objects(second).Type = ObjectType.Sphere Then
                        DoSphereSphereCollision(sim, sim.Objects(first), sim.Objects(second))
                    ElseIf sim.Objects(second).Type = ObjectType.Box Then
                        DoSphereBoxCollision(sim, sim.Objects(first), sim.Objects(second))
                    ElseIf sim.Objects(second).Type = ObjectType.InfinitePlane Then
                        DoSphereInfinitePlaneCollision(sim, sim.Objects(first), sim.Objects(second))
                    ElseIf sim.Objects(second).Type = ObjectType.Plane Then
                        DoSpherePlaneCollision(sim, sim.Objects(first), sim.Objects(second))
                    End If
                ElseIf sim.Objects(first).Type = ObjectType.Box Then
                    If sim.Objects(second).Type = ObjectType.Sphere Then
                        DoSphereBoxCollision(sim, sim.Objects(second), sim.Objects(first))
                    ElseIf sim.Objects(second).Type = ObjectType.Box Then
                        DoBoxBoxCollision(sim.Objects(first), sim.Objects(second))
                    End If

                    'TODO: BOX and Plane & BOX and Infitite Plane collisions
                ElseIf sim.Objects(first).Type = ObjectType.Plane Then
                    If sim.Objects(second).Type = ObjectType.Sphere Then
                        DoSpherePlaneCollision(sim, sim.Objects(second), sim.Objects(first))
                    End If
                    'TODO: Plane and BOX collisions

                ElseIf sim.Objects(first).Type = ObjectType.InfinitePlane Then
                    If sim.Objects(second).Type = ObjectType.Sphere Then
                        DoSphereInfinitePlaneCollision(sim, sim.Objects(second), sim.Objects(first))
                    End If
                    'TODO: Infinite Plane and BOX collisions
                End If
            Next
        Next
    End Sub

#Region "Object Breaking"
    Private Sub DoBreak(ByRef sim As SimulationRuntime, ByRef SimObject As SimulationObject, ByRef kineticEnergy As Double)
        'Make sure there is room for more objects
        If sim.ObjectCount >= sim.Config.Settings.MaxObjects Then Exit Sub

        'Determine if we have enough kinetic energy to break
        If kineticEnergy < sim.Config.Collisions.BreakMax Then
            If kineticEnergy < sim.Config.Collisions.BreakMin Then Return
            If kineticEnergy = sim.Config.Collisions.BreakAvg Then
                If sim.RandMaker.GetNext() <= 0.5 Then Return '50-50 chance of breaking!
            Else
                'Get probibility and compare it to a random number
                Dim probability = sim.RandMaker.GetProbibility(kineticEnergy, sim.Config.Collisions.BreakAvg, sim.Config.Collisions.BreakMin, sim.Config.Collisions.BreakMax)
                If sim.RandMaker.GetNext >= probability Then Return
            End If
        End If

        Dim BreakNumber As Integer 'Determines the number of resulting objects
        Dim SkewDirection As Double = sim.RandMaker.GetNext ' Determines the direction of the distribution curve

        'Determine what distribution curve will be used
        If SkewDirection = 0.5 Then
            BreakNumber = sim.Config.Collisions.AddAvg
        ElseIf SkewDirection < 0.5 Then
            BreakNumber = ToInt32(sim.RandMaker.GetNextSkewed(sim.Config.Collisions.AddAvg, sim.Config.Collisions.AddMin))
        Else
            BreakNumber = ToInt32(sim.RandMaker.GetNextSkewed(sim.Config.Collisions.AddAvg, sim.Config.Collisions.AddMax))
        End If

        'Verify reasonable results
        If BreakNumber < sim.Config.Collisions.AddMin Then
            BreakNumber = sim.Config.Collisions.AddMin
        ElseIf BreakNumber > sim.Config.Collisions.AddMax Then
            BreakNumber = sim.Config.Collisions.AddMax
        End If
        If sim.ObjectCount - 1 + BreakNumber > sim.Config.Settings.MaxObjects Then
            BreakNumber = sim.Config.Settings.MaxObjects - sim.ObjectCount + 1
        End If

        'Calculate 3 perpendicular unit vectors
        Dim VelocityI As XYZ = SimObject.Velocity
        Dim VelocityMagnitudeI As Double = VelocityI.Magnitude
        VelocityI /= VelocityMagnitudeI
        Dim VelocityJ As XYZ = VelocityI.Perpendicular
        Dim VelocityK As XYZ = VelocityI.Cross(VelocityJ)
        VelocityMagnitudeI *= BreakNumber

        Dim NewObjects(sim.Config.Collisions.AddMax) As SimulationObject 'Temporarily holds the objects while they are being created
        Dim MassAssigned(sim.Config.Collisions.AddMax) As Double 'A random amount of mass that is assigned to each object
        Dim VelocityComponents(sim.Config.Collisions.AddMax) As XYZ 'The random distribution of the velocity across all three components
        Dim VelocityMagnitude(sim.Config.Collisions.AddMax) As Double 'The magnitude of the velocity in all three components
        Dim TotalVelocityMagnitude As Double 'The total amount of velocity that has been assigned to each component

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
            NewObjects(z).DXRenderType = SimObject.DXRenderType
            NewObjects(z).Type = SimObject.Type
            NewObjects(z).Color = SimObject.Color
            NewObjects(z).Rotation.Copy(SimObject.Rotation)
            VelocityMagnitude(z) = sim.RandMaker.GetNext 'Assign a random amount of velocity
            TotalVelocityMagnitude += VelocityMagnitude(z)
            VelocityComponents(z) = New XYZ(sim.RandMaker.GetNext, sim.RandMaker.GetNext, sim.RandMaker.GetNext) 'Assign a random direction to the velocity
            If sim.RandMaker.GetNext > 0.5 Then VelocityComponents(z).Y = -VelocityComponents(z).Y
            If sim.RandMaker.GetNext > 0.5 Then VelocityComponents(z).Z = -VelocityComponents(z).Z
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

        'ASSIGN SIZE, MASS AND POSITION
        If SimObject.Type = ObjectType.Box Then 'The object is a Box

            Dim TessNumber As Integer
            Dim TessBox As New SimulationObject

            'Tesselation of the original box.
            For i = 0 To BreakNumber - 2 'I is the cut number, always 1 less than breaknumber
                If i = 0 Then 'First cut
                    TessellateBox(sim, NewObjects(0), NewObjects(1), SimObject)
                Else
                    TessNumber = ToInt32(i * sim.RandMaker.GetNext) 'Get a random box
                    TessBox.Copy(NewObjects(TessNumber)) 'Copy that box 
                    TessellateBox(sim, NewObjects(TessNumber), NewObjects(i + 1), TessBox)
                End If
            Next

            'Assign mass to each new box based on thier volume
            Dim OldVolume As Double = 1 / (SimObject.Size.X * SimObject.Size.Y * SimObject.Size.Z)
            For r = 0 To BreakNumber - 1
                MassAssigned(r) = (NewObjects(r).Size.X * NewObjects(r).Size.Y * NewObjects(r).Size.Z) * OldVolume 'Fraction of the old volume that each new box will get
                NewObjects(r).Mass = MassAssigned(r) * SimObject.Mass
            Next

            'ASSIGN CHARGE BASED ON MASS
            If sim.Config.Forces.ElectroStatic.Enabled Then
                For Z = 0 To BreakNumber - 1
                    NewObjects(Z).Charge = MassAssigned(Z) * SimObject.Charge 'Assign the charge to the final objects
                Next
            End If
        Else 'The object is a Sphere

            'ASSIGN MASS to each objects
            Dim TotalMass As Double = 0 'The total amount of mass that has been assigned to the new objects
            For z = 0 To BreakNumber - 1
                MassAssigned(z) = sim.RandMaker.GetNext
                TotalMass += MassAssigned(z)
            Next

            Dim RadiusTemp As Double

            'Apply mass and position
            For Z = 0 To BreakNumber - 1
                MassAssigned(Z) /= TotalMass 'Find each object's fraction of the total mass
                NewObjects(Z).Mass = MassAssigned(Z) * SimObject.Mass 'Assign the masses to the final object
                NewObjects(Z).Radius = (MassAssigned(Z) ^ 0.33333333333333331) * SimObject.Radius
                RadiusTemp = SimObject.Radius - NewObjects(Z).Radius
                If sim.RandMaker.GetNext() > 0.5 Then RadiusTemp = -RadiusTemp
                NewObjects(Z).Position = SimObject.Position + (RadiusTemp * NewObjects(Z).Velocity.GetNewUnit)
            Next

            'ASSIGN CHARGE BASED ON MASS
            If sim.Config.Forces.ElectroStatic.Enabled Then
                For Z = 0 To BreakNumber - 1
                    NewObjects(Z).Charge = MassAssigned(Z) * SimObject.Charge 'Assign the charge to the final objects
                Next
            End If
        End If

        'COPY THE NEW OBJECTS OVER
        SimulationRender.RenderLock.EnterWriteLock() ' Make sure the Renderer isn't loading the data 
        SimObject.Copy(NewObjects(0)) 'Copy over the new objects into the simulation
        For Z = 1 To BreakNumber - 1
            sim.Objects(sim.ObjectCount) = New SimulationObject
            sim.Objects(sim.ObjectCount).Copy(NewObjects(Z))
            sim.ObjectCount += 1
        Next
        SimulationRender.RenderLock.ExitWriteLock()
    End Sub
    Private Sub TessellateBox(ByRef sim As SimulationRuntime, ByRef NewObject1 As SimulationObject, ByRef NewObject2 As SimulationObject, ByRef OldObject As SimulationObject)
        Dim TessX As Double = sim.RandMaker.GetNext
        Dim TessY As Double = sim.RandMaker.GetNext
        Dim TessZ As Double = sim.RandMaker.GetNext
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
End Module
