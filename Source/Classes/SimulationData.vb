Imports System.Text
Imports System.Windows.Forms

Public Class SimulationData

#Region "Attributes"
    'Threading
    Private LockRayData As New Object
    Private LockRayMulti As New Object
    Private LockDX As New Object
    Public ComputingThread As Thread
    Public RenderThread() As Thread
    Public Running As Boolean
    Private Paused As Boolean

    'Counters
    Public CalcCounter As CalculationCounter
    Public RenderCounter As CalculationCounter
    Public StartTime As Long

    'Rendering
    Public Render As SimulationRender

    'Forces
    Public Forces As SimulationForces
    Private Ec As Double

    'Collisions
    Public Collisions As SimulationCollision

    'Camera
    Public Camera As SimulationCamera

    'Settings
    Public Settings As SimulationSettings

    'Simulation Objects
    Public ObjectCount As Integer
    Public Objects() As SimulationObject

    'Simulation Groups
    Public GroupCount As Integer
    Public Groups() As SimulationGroup

    'Simulation Lights
    Public LightCount As Integer
    Public Lights() As SimulationLight

    ' Random Generator
    Private RandMaker As RandNumber
#End Region

#Region "ObjectStuff"
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
        Render.Clear()

        'Forces
        Forces.Clear()

        'Collisions
        Collisions.Clear()

        'Camera
        Camera.Clear()

        'Settings
        Settings.Clear()

        'Objects
        ObjectCount = 0
        ReDim Objects(ObjectCount - 1)
        For i As Integer = 0 To ObjectCount - 1
            Objects(i) = New SimulationObject
        Next

        'Groups
        GroupCount = 1
        ReDim Groups(GroupCount - 1)
        For i As Integer = 0 To GroupCount - 1
            Groups(i) = New SimulationGroup
        Next

        'Lights
        LightCount = 1
        ReDim Lights(LightCount - 1)
        For i As Integer = 0 To LightCount - 1
            Lights(i) = New SimulationLight
        Next

        'Random
        RandMaker = New RandNumber
    End Sub
    Public Function Copy(ByRef Other As SimulationData) As Boolean
        '----DEEP COPY----
        If Running = True Or Other.Running = True Then
            Return False
        End If

        Try
            'Threads
            ComputingThread = Nothing
            RenderThread = Nothing

            Running = False
            Paused = False

            'Counters
            CalcCounter.Copy(Other.CalcCounter)
            RenderCounter.Copy(Other.RenderCounter)
            StartTime = Other.StartTime

            'Rendering
            Render.Copy(Other.Render)

            'Forces
            Forces.Copy(Other.Forces)

            'Collisions
            Collisions.Copy(Other.Collisions)

            'Camera
            Camera.Copy(Other.Camera)

            'Settings
            Settings.Copy(Other.Settings)

            'Objects
            ObjectCount = Other.ObjectCount
            ReDim Objects(ObjectCount - 1)
            For i As Integer = 0 To ObjectCount - 1
                Objects(i) = New SimulationObject(Other.Objects(i))
            Next

            'Groups
            GroupCount = Other.GroupCount
            ReDim Groups(GroupCount - 1)
            For i As Integer = 0 To GroupCount - 1
                Groups(i) = New SimulationGroup(Other.Groups(i))
            Next

            'Lights
            LightCount = Other.LightCount
            ReDim Lights(LightCount - 1)
            For i As Integer = 0 To LightCount - 1
                Lights(i) = New SimulationLight(Other.Lights(i))
            Next

            Return True
        Catch
            Return False
        End Try
    End Function
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
    Private Function GetUnique() As Double
        Dim Sum As String
        Dim r As Integer
        Sum = ""

        For r = 0 To GroupCount - 1
            Sum += Groups(r).Affected.ToString
            Sum += Groups(r).Affects.ToString
            Sum += Groups(r).Type.ToString
            If Groups(r).Number.UseFunction Then
                If Groups(r).Number.Even Then
                    Sum += Groups(r).Number.EvenMin.ToString
                    Sum += Groups(r).Number.EvenMax.ToString
                ElseIf Groups(r).Number.Normal Then
                    Sum += Groups(r).Number.NormalMin.ToString
                    Sum += Groups(r).Number.NormalAvg.ToString
                    Sum += Groups(r).Number.NormalMax.ToString
                ElseIf Groups(r).Number.Polynomial Then
                    Sum += Groups(r).Number.PolynomialA.ToString
                    Sum += Groups(r).Number.PolynomialB.ToString
                    Sum += Groups(r).Number.PolynomialC.ToString
                Else
                    Sum += Groups(r).Number.RandomMin.ToString
                    Sum += Groups(r).Number.RandomMax.ToString
                End If
            Else
                Sum += Groups(r).Number.Value.ToString
            End If

            If Collisions.Enabled Or (Forces.Enabled And (Forces.Drag.Enabled Or Forces.ElectroStatic.Enabled Or Forces.Field.Enabled Or Forces.Gravity)) Then
                If Groups(r).Mass.UseFunction Then
                    If Groups(r).Mass.Even Then
                        Sum += Groups(r).Mass.EvenMin.ToString
                        Sum += Groups(r).Mass.EvenMax.ToString
                    ElseIf Groups(r).Mass.Normal Then
                        Sum += Groups(r).Mass.NormalMin.ToString
                        Sum += Groups(r).Mass.NormalAvg.ToString
                        Sum += Groups(r).Mass.NormalMax.ToString
                    ElseIf Groups(r).Mass.Polynomial Then
                        Sum += Groups(r).Mass.PolynomialA.ToString
                        Sum += Groups(r).Mass.PolynomialB.ToString
                        Sum += Groups(r).Mass.PolynomialC.ToString
                    Else
                        Sum += Groups(r).Mass.RandomMin.ToString
                        Sum += Groups(r).Mass.RandomMax.ToString
                    End If
                Else
                    Sum += Groups(r).Mass.Value.ToString
                End If
            End If

            If Forces.Enabled And Forces.ElectroStatic.Enabled Then
                If Groups(r).Charge.UseFunction Then
                    If Groups(r).Charge.Even Then
                        Sum += Groups(r).Charge.EvenMin.ToString
                        Sum += Groups(r).Charge.EvenMax.ToString
                    ElseIf Groups(r).Charge.Normal Then
                        Sum += Groups(r).Charge.NormalMin.ToString
                        Sum += Groups(r).Charge.NormalAvg.ToString
                        Sum += Groups(r).Charge.NormalMax.ToString
                    ElseIf Groups(r).Charge.Polynomial Then
                        Sum += Groups(r).Charge.PolynomialA.ToString
                        Sum += Groups(r).Charge.PolynomialB.ToString
                        Sum += Groups(r).Charge.PolynomialC.ToString
                    Else
                        Sum += Groups(r).Charge.RandomMin.ToString
                        Sum += Groups(r).Charge.RandomMax.ToString
                    End If
                Else
                    Sum += Groups(r).Charge.Value.ToString
                End If
            End If

            If Groups(r).Type = ObjectType.Sphere Then
                If Groups(r).Radius.UseFunction Then
                    If Groups(r).Radius.Even Then
                        Sum += Groups(r).Radius.EvenMin.ToString
                        Sum += Groups(r).Radius.EvenMax.ToString
                    ElseIf Groups(r).Radius.Normal Then
                        Sum += Groups(r).Radius.NormalMin.ToString
                        Sum += Groups(r).Radius.NormalAvg.ToString
                        Sum += Groups(r).Radius.NormalMax.ToString
                    ElseIf Groups(r).Radius.Polynomial Then
                        Sum += Groups(r).Radius.PolynomialA.ToString
                        Sum += Groups(r).Radius.PolynomialB.ToString
                        Sum += Groups(r).Radius.PolynomialC.ToString
                    Else
                        Sum += Groups(r).Radius.RandomMin.ToString
                        Sum += Groups(r).Radius.RandomMax.ToString
                    End If
                Else
                    Sum += Groups(r).Radius.Value.ToString
                End If
            ElseIf Groups(r).Type = ObjectType.Box Then
                If Groups(r).Size.X.UseFunction Then
                    If Groups(r).Size.X.Even Then
                        Sum += Groups(r).Size.X.EvenMin.ToString
                        Sum += Groups(r).Size.X.EvenMax.ToString
                    ElseIf Groups(r).Size.X.Normal Then
                        Sum += Groups(r).Size.X.NormalMin.ToString
                        Sum += Groups(r).Size.X.NormalAvg.ToString
                        Sum += Groups(r).Size.X.NormalMax.ToString
                    ElseIf Groups(r).Size.X.Polynomial Then
                        Sum += Groups(r).Size.X.PolynomialA.ToString
                        Sum += Groups(r).Size.X.PolynomialB.ToString
                        Sum += Groups(r).Size.X.PolynomialC.ToString
                    Else
                        Sum += Groups(r).Size.X.RandomMin.ToString
                        Sum += Groups(r).Size.X.RandomMax.ToString
                    End If
                Else
                    Sum += Groups(r).Size.X.Value.ToString
                End If
                If Groups(r).Size.Y.UseFunction Then
                    If Groups(r).Size.Y.Even Then
                        Sum += Groups(r).Size.Y.EvenMin.ToString
                        Sum += Groups(r).Size.Y.EvenMax.ToString
                    ElseIf Groups(r).Size.Y.Normal Then
                        Sum += Groups(r).Size.Y.NormalMin.ToString
                        Sum += Groups(r).Size.Y.NormalAvg.ToString
                        Sum += Groups(r).Size.Y.NormalMax.ToString
                    ElseIf Groups(r).Size.Y.Polynomial Then
                        Sum += Groups(r).Size.Y.PolynomialA.ToString
                        Sum += Groups(r).Size.Y.PolynomialB.ToString
                        Sum += Groups(r).Size.Y.PolynomialC.ToString
                    Else
                        Sum += Groups(r).Size.Y.RandomMin.ToString
                        Sum += Groups(r).Size.Y.RandomMax.ToString
                    End If
                Else
                    Sum += Groups(r).Size.Y.Value.ToString
                End If
                If Groups(r).Size.Z.UseFunction Then
                    If Groups(r).Size.Z.Even Then
                        Sum += Groups(r).Size.Z.EvenMin.ToString
                        Sum += Groups(r).Size.Z.EvenMax.ToString
                    ElseIf Groups(r).Size.Z.Normal Then
                        Sum += Groups(r).Size.Z.NormalMin.ToString
                        Sum += Groups(r).Size.Z.NormalAvg.ToString
                        Sum += Groups(r).Size.Z.NormalMax.ToString
                    ElseIf Groups(r).Size.Z.Polynomial Then
                        Sum += Groups(r).Size.Z.PolynomialA.ToString
                        Sum += Groups(r).Size.Z.PolynomialB.ToString
                        Sum += Groups(r).Size.Z.PolynomialC.ToString
                    Else
                        Sum += Groups(r).Size.Z.RandomMin.ToString
                        Sum += Groups(r).Size.Z.RandomMax.ToString
                    End If
                Else
                    Sum += Groups(r).Size.Z.Value.ToString
                End If
                If Groups(r).Rotation.Z.UseFunction Then
                    If Groups(r).Rotation.Z.Even Then
                        Sum += Groups(r).Rotation.Z.EvenMin.ToString
                        Sum += Groups(r).Rotation.Z.EvenMax.ToString
                    ElseIf Groups(r).Rotation.Z.Normal Then
                        Sum += Groups(r).Rotation.Z.NormalMin.ToString
                        Sum += Groups(r).Rotation.Z.NormalAvg.ToString
                        Sum += Groups(r).Rotation.Z.NormalMax.ToString
                    ElseIf Groups(r).Rotation.Z.Polynomial Then
                        Sum += Groups(r).Rotation.Z.PolynomialA.ToString
                        Sum += Groups(r).Rotation.Z.PolynomialB.ToString
                        Sum += Groups(r).Rotation.Z.PolynomialC.ToString
                    Else
                        Sum += Groups(r).Rotation.Z.RandomMin.ToString
                        Sum += Groups(r).Rotation.Z.RandomMax.ToString
                    End If
                Else
                    Sum += Groups(r).Rotation.Z.Value.ToString
                End If
                If Groups(r).Rotation.Y.UseFunction Then
                    If Groups(r).Rotation.Y.Even Then
                        Sum += Groups(r).Rotation.Y.EvenMin.ToString
                        Sum += Groups(r).Rotation.Y.EvenMax.ToString
                    ElseIf Groups(r).Rotation.Y.Normal Then
                        Sum += Groups(r).Rotation.Y.NormalMin.ToString
                        Sum += Groups(r).Rotation.Y.NormalAvg.ToString
                        Sum += Groups(r).Rotation.Y.NormalMax.ToString
                    ElseIf Groups(r).Rotation.Y.Polynomial Then
                        Sum += Groups(r).Rotation.Y.PolynomialA.ToString
                        Sum += Groups(r).Rotation.Y.PolynomialB.ToString
                        Sum += Groups(r).Rotation.Y.PolynomialC.ToString
                    Else
                        Sum += Groups(r).Rotation.Y.RandomMin.ToString
                        Sum += Groups(r).Rotation.Y.RandomMax.ToString
                    End If
                Else
                    Sum += Groups(r).Rotation.Y.Value.ToString
                End If
                If Groups(r).Rotation.X.UseFunction Then
                    If Groups(r).Rotation.X.Even Then
                        Sum += Groups(r).Rotation.X.EvenMin.ToString
                        Sum += Groups(r).Rotation.X.EvenMax.ToString
                    ElseIf Groups(r).Rotation.X.Normal Then
                        Sum += Groups(r).Rotation.X.NormalMin.ToString
                        Sum += Groups(r).Rotation.X.NormalAvg.ToString
                        Sum += Groups(r).Rotation.X.NormalMax.ToString
                    ElseIf Groups(r).Rotation.X.Polynomial Then
                        Sum += Groups(r).Rotation.X.PolynomialA.ToString
                        Sum += Groups(r).Rotation.X.PolynomialB.ToString
                        Sum += Groups(r).Rotation.X.PolynomialC.ToString
                    Else
                        Sum += Groups(r).Rotation.X.RandomMin.ToString
                        Sum += Groups(r).Rotation.X.RandomMax.ToString
                    End If
                Else
                    Sum += Groups(r).Rotation.X.Value.ToString
                End If
            Else
                If Groups(r).Normal.Z.UseFunction Then
                    If Groups(r).Normal.Z.Even Then
                        Sum += Groups(r).Normal.Z.EvenMin.ToString
                        Sum += Groups(r).Normal.Z.EvenMax.ToString
                    ElseIf Groups(r).Normal.Z.Normal Then
                        Sum += Groups(r).Normal.Z.NormalMin.ToString
                        Sum += Groups(r).Normal.Z.NormalAvg.ToString
                        Sum += Groups(r).Normal.Z.NormalMax.ToString
                    ElseIf Groups(r).Normal.Z.Polynomial Then
                        Sum += Groups(r).Normal.Z.PolynomialA.ToString
                        Sum += Groups(r).Normal.Z.PolynomialB.ToString
                        Sum += Groups(r).Normal.Z.PolynomialC.ToString
                    Else
                        Sum += Groups(r).Normal.Z.RandomMin.ToString
                        Sum += Groups(r).Normal.Z.RandomMax.ToString
                    End If
                Else
                    Sum += Groups(r).Normal.Z.Value.ToString
                End If
                If Groups(r).Normal.Y.UseFunction Then
                    If Groups(r).Normal.Y.Even Then
                        Sum += Groups(r).Normal.Y.EvenMin.ToString
                        Sum += Groups(r).Normal.Y.EvenMax.ToString
                    ElseIf Groups(r).Normal.Y.Normal Then
                        Sum += Groups(r).Normal.Y.NormalMin.ToString
                        Sum += Groups(r).Normal.Y.NormalAvg.ToString
                        Sum += Groups(r).Normal.Y.NormalMax.ToString
                    ElseIf Groups(r).Normal.Y.Polynomial Then
                        Sum += Groups(r).Normal.Y.PolynomialA.ToString
                        Sum += Groups(r).Normal.Y.PolynomialB.ToString
                        Sum += Groups(r).Normal.Y.PolynomialC.ToString
                    Else
                        Sum += Groups(r).Normal.Y.RandomMin.ToString
                        Sum += Groups(r).Normal.Y.RandomMax.ToString
                    End If
                Else
                    Sum += Groups(r).Normal.Y.Value.ToString
                End If
                If Groups(r).Normal.X.UseFunction Then
                    If Groups(r).Normal.X.Even Then
                        Sum += Groups(r).Normal.X.EvenMin.ToString
                        Sum += Groups(r).Normal.X.EvenMax.ToString
                    ElseIf Groups(r).Normal.X.Normal Then
                        Sum += Groups(r).Normal.X.NormalMin.ToString
                        Sum += Groups(r).Normal.X.NormalAvg.ToString
                        Sum += Groups(r).Normal.X.NormalMax.ToString
                    ElseIf Groups(r).Normal.X.Polynomial Then
                        Sum += Groups(r).Normal.X.PolynomialA.ToString
                        Sum += Groups(r).Normal.X.PolynomialB.ToString
                        Sum += Groups(r).Normal.X.PolynomialC.ToString
                    Else
                        Sum += Groups(r).Normal.X.RandomMin.ToString
                        Sum += Groups(r).Normal.X.RandomMax.ToString
                    End If
                Else
                    Sum += Groups(r).Normal.X.Value.ToString
                End If
            End If


            If Groups(r).Position.X.UseFunction Then
                If Groups(r).Position.X.Even Then
                    Sum += Groups(r).Position.X.EvenMin.ToString
                    Sum += Groups(r).Position.X.EvenMax.ToString
                ElseIf Groups(r).Position.X.Normal Then
                    Sum += Groups(r).Position.X.NormalMin.ToString
                    Sum += Groups(r).Position.X.NormalAvg.ToString
                    Sum += Groups(r).Position.X.NormalMax.ToString
                ElseIf Groups(r).Position.X.Polynomial Then
                    Sum += Groups(r).Position.X.PolynomialA.ToString
                    Sum += Groups(r).Position.X.PolynomialB.ToString
                    Sum += Groups(r).Position.X.PolynomialC.ToString
                Else
                    Sum += Groups(r).Position.X.RandomMin.ToString
                    Sum += Groups(r).Position.X.RandomMax.ToString
                End If
            Else
                Sum += Groups(r).Position.X.Value.ToString
            End If

            If Groups(r).Position.Y.UseFunction Then
                If Groups(r).Position.Y.Even Then
                    Sum += Groups(r).Position.Y.EvenMin.ToString
                    Sum += Groups(r).Position.Y.EvenMax.ToString
                ElseIf Groups(r).Position.Y.Normal Then
                    Sum += Groups(r).Position.Y.NormalMin.ToString
                    Sum += Groups(r).Position.Y.NormalAvg.ToString
                    Sum += Groups(r).Position.Y.NormalMax.ToString
                ElseIf Groups(r).Position.Y.Polynomial Then
                    Sum += Groups(r).Position.Y.PolynomialA.ToString
                    Sum += Groups(r).Position.Y.PolynomialB.ToString
                    Sum += Groups(r).Position.Y.PolynomialC.ToString
                Else
                    Sum += Groups(r).Position.Y.RandomMin.ToString
                    Sum += Groups(r).Position.Y.RandomMax.ToString
                End If
            Else
                Sum += Groups(r).Position.Y.Value.ToString
            End If

            If Groups(r).Position.Z.UseFunction Then
                If Groups(r).Position.Z.Even Then
                    Sum += Groups(r).Position.Z.EvenMin.ToString
                    Sum += Groups(r).Position.Z.EvenMax.ToString
                ElseIf Groups(r).Position.Z.Normal Then
                    Sum += Groups(r).Position.Z.NormalMin.ToString
                    Sum += Groups(r).Position.Z.NormalAvg.ToString
                    Sum += Groups(r).Position.Z.NormalMax.ToString
                ElseIf Groups(r).Position.Z.Polynomial Then
                    Sum += Groups(r).Position.Z.PolynomialA.ToString
                    Sum += Groups(r).Position.Z.PolynomialB.ToString
                    Sum += Groups(r).Position.Z.PolynomialC.ToString
                Else
                    Sum += Groups(r).Position.Z.RandomMin.ToString
                    Sum += Groups(r).Position.Z.RandomMax.ToString
                End If
            Else
                Sum += Groups(r).Position.Z.Value.ToString
            End If

            If Groups(r).Velocity.X.UseFunction Then
                If Groups(r).Velocity.X.Even Then
                    Sum += Groups(r).Velocity.X.EvenMin.ToString
                    Sum += Groups(r).Velocity.X.EvenMax.ToString
                ElseIf Groups(r).Velocity.X.Normal Then
                    Sum += Groups(r).Velocity.X.NormalMin.ToString
                    Sum += Groups(r).Velocity.X.NormalAvg.ToString
                    Sum += Groups(r).Velocity.X.NormalMax.ToString
                ElseIf Groups(r).Velocity.X.Polynomial Then
                    Sum += Groups(r).Velocity.X.PolynomialA.ToString
                    Sum += Groups(r).Velocity.X.PolynomialB.ToString
                    Sum += Groups(r).Velocity.X.PolynomialC.ToString
                Else
                    Sum += Groups(r).Velocity.X.RandomMin.ToString
                    Sum += Groups(r).Velocity.X.RandomMax.ToString
                End If
            Else
                Sum += Groups(r).Velocity.X.Value.ToString
            End If

            If Groups(r).Velocity.Y.UseFunction Then
                If Groups(r).Velocity.Y.Even Then
                    Sum += Groups(r).Velocity.Y.EvenMin.ToString
                    Sum += Groups(r).Velocity.Y.EvenMax.ToString
                ElseIf Groups(r).Velocity.Y.Normal Then
                    Sum += Groups(r).Velocity.Y.NormalMin.ToString
                    Sum += Groups(r).Velocity.Y.NormalAvg.ToString
                    Sum += Groups(r).Velocity.Y.NormalMax.ToString
                ElseIf Groups(r).Velocity.Y.Polynomial Then
                    Sum += Groups(r).Velocity.Y.PolynomialA.ToString
                    Sum += Groups(r).Velocity.Y.PolynomialB.ToString
                    Sum += Groups(r).Velocity.Y.PolynomialC.ToString
                Else
                    Sum += Groups(r).Velocity.Y.RandomMin.ToString
                    Sum += Groups(r).Velocity.Y.RandomMax.ToString
                End If
            Else
                Sum += Groups(r).Velocity.Y.Value.ToString
            End If

            If Groups(r).Velocity.Z.UseFunction Then
                If Groups(r).Velocity.Z.Even Then
                    Sum += Groups(r).Velocity.Z.EvenMin.ToString
                    Sum += Groups(r).Velocity.Z.EvenMax.ToString
                ElseIf Groups(r).Velocity.Z.Normal Then
                    Sum += Groups(r).Velocity.Z.NormalMin.ToString
                    Sum += Groups(r).Velocity.Z.NormalAvg.ToString
                    Sum += Groups(r).Velocity.Z.NormalMax.ToString
                ElseIf Groups(r).Velocity.Z.Polynomial Then
                    Sum += Groups(r).Velocity.Z.PolynomialA.ToString
                    Sum += Groups(r).Velocity.Z.PolynomialB.ToString
                    Sum += Groups(r).Velocity.Z.PolynomialC.ToString
                Else
                    Sum += Groups(r).Velocity.Z.RandomMin.ToString
                    Sum += Groups(r).Velocity.Z.RandomMax.ToString
                End If
            Else
                Sum += Groups(r).Velocity.Z.Value.ToString
            End If
        Next
        If Forces.Enabled Then
            If Forces.Field.Enabled = True Then
                Sum += Forces.Field.Acceleration.X.ToString
                Sum += Forces.Field.Acceleration.Y.ToString
                Sum += Forces.Field.Acceleration.Z.ToString
            End If
            If Forces.Drag.Enabled Then
                Sum += Forces.Drag.Density.ToString
                Sum += Forces.Drag.Viscosity.ToString
                Sum += Forces.Drag.DragCoeff.ToString
            End If
            If Forces.ElectroStatic.Enabled Then
                Sum += Forces.ElectroStatic.Permittivity.ToString
            End If
        End If
        If Collisions.Enabled Then
            Sum += Collisions.CoR.ToString
            If Collisions.Breakable Then
                Sum += Collisions.AddAvg.ToString
                Sum += Collisions.AddMin.ToString
                Sum += Collisions.AddMax.ToString
                Sum += Collisions.BreakAvg.ToString
                Sum += Collisions.BreakMin.ToString
                Sum += Collisions.BreakMax.ToString
            End If
        End If

        Return Math.Abs(Sum.GetHashCode)
    End Function
    Private Sub ConvertGroupstoObjects()
        Dim i, j As Integer
        Dim ObjectNumber As Integer
        Dim SkewDirection As Double

        'Add new objects from the groups
        For i = 0 To GroupCount - 1

            'Determine the number of objects
            If Groups(i).Number.UseFunction Then
                If Groups(i).Number.Normal Then
                    'Determine what distribution curve will be used
                    SkewDirection = RandMaker.GetNext
                    If SkewDirection = 0.5 Then
                        ObjectNumber = Groups(i).Number.NormalAvg
                    ElseIf SkewDirection < 0.5 Then
                        ObjectNumber = ToInt32(RandMaker.GetNextSkewed(Groups(i).Number.NormalAvg, Groups(i).Number.NormalMin))
                    Else
                        ObjectNumber = ToInt32(RandMaker.GetNextSkewed(Groups(i).Number.NormalAvg, Groups(i).Number.NormalMax))
                    End If
                    'Verify reasonable results
                    If ObjectNumber < Groups(i).Number.NormalMin Then
                        ObjectNumber = Groups(i).Number.NormalMin
                    ElseIf ObjectNumber > Groups(i).Number.NormalMax Then
                        ObjectNumber = Groups(i).Number.NormalMax
                    End If
                Else
                    ObjectNumber = ToInt32(Groups(i).Number.RandomMin + ((Groups(i).Number.RandomMax - Groups(i).Number.RandomMin) * RandMaker.GetNext))
                End If
            Else
                ObjectNumber = Groups(i).Number.Value
            End If

            If ObjectNumber < 1 Then
                ObjectNumber = 1
            End If

            'Resize the array
            Array.Resize(Me.Objects, Objects.Length + ObjectNumber)

            'Create the objects
            For j = 0 To ObjectNumber - 1
                Objects(ObjectCount) = New SimulationObject()
                Objects(ObjectCount).Affected = Groups(i).Affected
                Objects(ObjectCount).Affects = Groups(i).Affects
                Objects(ObjectCount).Wireframe = Groups(i).Wireframe
                Objects(ObjectCount).Type = Groups(i).Type

                'MASS
                If Groups(i).Mass.UseFunction Then
                    If Groups(i).Mass.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Mass = Groups(i).Mass.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Mass = RandMaker.GetNextSkewed(Groups(i).Mass.NormalAvg, Groups(i).Mass.NormalMin)
                        Else
                            Objects(ObjectCount).Mass = RandMaker.GetNextSkewed(Groups(i).Mass.NormalAvg, Groups(i).Mass.NormalMax)
                        End If
                        If Objects(ObjectCount).Mass < Groups(i).Mass.NormalMin Then
                            Objects(ObjectCount).Mass = Groups(i).Mass.NormalMin
                        ElseIf Objects(ObjectCount).Mass > Groups(i).Mass.NormalMax Then
                            Objects(ObjectCount).Mass = Groups(i).Mass.NormalMax
                        End If
                    ElseIf Groups(i).Mass.Random Then
                        Objects(ObjectCount).Mass = Groups(i).Mass.RandomMin + ((Groups(i).Mass.RandomMax - Groups(i).Mass.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).Mass.Even Then
                        Objects(ObjectCount).Mass = Groups(i).Mass.EvenMin + ((Groups(i).Mass.EvenMax - Groups(i).Mass.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Mass.Polynomial Then
                        Objects(ObjectCount).Mass = Groups(i).Mass.PolynomialC + (j * Groups(i).Mass.PolynomialB) + (j * j * Groups(i).Mass.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Mass = Groups(i).Mass.Value
                End If

                'CHARGE
                If Groups(i).Charge.UseFunction Then
                    If Groups(i).Charge.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Charge = Groups(i).Charge.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Charge = RandMaker.GetNextSkewed(Groups(i).Charge.NormalAvg, Groups(i).Charge.NormalMin)
                        Else
                            Objects(ObjectCount).Charge = RandMaker.GetNextSkewed(Groups(i).Charge.NormalAvg, Groups(i).Charge.NormalMax)
                        End If
                        If Objects(ObjectCount).Charge < Groups(i).Charge.NormalMin Then
                            Objects(ObjectCount).Charge = Groups(i).Charge.NormalMin
                        ElseIf Objects(ObjectCount).Charge > Groups(i).Charge.NormalMax Then
                            Objects(ObjectCount).Charge = Groups(i).Charge.NormalMax
                        End If
                    ElseIf Groups(i).Charge.Random Then
                        Objects(ObjectCount).Charge = Groups(i).Charge.RandomMin + ((Groups(i).Charge.RandomMax - Groups(i).Charge.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).Charge.Even Then
                        Objects(ObjectCount).Charge = Groups(i).Charge.EvenMin + ((Groups(i).Charge.EvenMax - Groups(i).Charge.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Charge.Polynomial Then
                        Objects(ObjectCount).Charge = Groups(i).Charge.PolynomialC + (j * Groups(i).Charge.PolynomialB) + (j * j * Groups(i).Charge.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Charge = Groups(i).Charge.Value
                End If

                'SIZE
                If Groups(i).Size.X.UseFunction Then
                    If Groups(i).Size.X.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Size.X = Groups(i).Size.X.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Size.X = RandMaker.GetNextSkewed(Groups(i).Size.X.NormalAvg, Groups(i).Size.X.NormalMin)
                        Else
                            Objects(ObjectCount).Size.X = RandMaker.GetNextSkewed(Groups(i).Size.X.NormalAvg, Groups(i).Size.X.NormalMax)
                        End If
                        If Objects(ObjectCount).Size.X < Groups(i).Size.X.NormalMin Then
                            Objects(ObjectCount).Size.X = Groups(i).Size.X.NormalMin
                        ElseIf Objects(ObjectCount).Size.X > Groups(i).Size.X.NormalMax Then
                            Objects(ObjectCount).Size.X = Groups(i).Size.X.NormalMax
                        End If
                    ElseIf Groups(i).Size.X.Random Then
                        Objects(ObjectCount).Size.X = Groups(i).Size.X.RandomMin + ((Groups(i).Size.X.RandomMax - Groups(i).Size.X.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).Size.X.Even Then
                        Objects(ObjectCount).Size.X = Groups(i).Size.X.EvenMin + ((Groups(i).Size.X.EvenMax - Groups(i).Size.X.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Size.X.Polynomial Then
                        Objects(ObjectCount).Size.X = Groups(i).Size.X.PolynomialC + (j * Groups(i).Size.X.PolynomialB) + (j * j * Groups(i).Size.X.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Size.X = Groups(i).Size.X.Value
                End If

                If Groups(i).Size.Y.UseFunction Then
                    If Groups(i).Size.Y.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Size.Y = Groups(i).Size.Y.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Size.Y = RandMaker.GetNextSkewed(Groups(i).Size.Y.NormalAvg, Groups(i).Size.Y.NormalMin)
                        Else
                            Objects(ObjectCount).Size.Y = RandMaker.GetNextSkewed(Groups(i).Size.Y.NormalAvg, Groups(i).Size.Y.NormalMax)
                        End If
                        If Objects(ObjectCount).Size.Y < Groups(i).Size.Y.NormalMin Then
                            Objects(ObjectCount).Size.Y = Groups(i).Size.Y.NormalMin
                        ElseIf Objects(ObjectCount).Size.Y > Groups(i).Size.Y.NormalMax Then
                            Objects(ObjectCount).Size.Y = Groups(i).Size.Y.NormalMax
                        End If
                    ElseIf Groups(i).Size.Y.Random Then
                        Objects(ObjectCount).Size.Y = Groups(i).Size.Y.RandomMin + ((Groups(i).Size.Y.RandomMax - Groups(i).Size.Y.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).Size.Y.Even Then
                        Objects(ObjectCount).Size.Y = Groups(i).Size.Y.EvenMin + ((Groups(i).Size.Y.EvenMax - Groups(i).Size.Y.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Size.Y.Polynomial Then
                        Objects(ObjectCount).Size.Y = Groups(i).Size.Y.PolynomialC + (j * Groups(i).Size.Y.PolynomialB) + (j * j * Groups(i).Size.Y.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Size.Y = Groups(i).Size.Y.Value
                End If

                If Groups(i).Size.Z.UseFunction Then
                    If Groups(i).Size.Z.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Size.Z = Groups(i).Size.Z.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Size.Z = RandMaker.GetNextSkewed(Groups(i).Size.Z.NormalAvg, Groups(i).Size.Z.NormalMin)
                        Else
                            Objects(ObjectCount).Size.Z = RandMaker.GetNextSkewed(Groups(i).Size.Z.NormalAvg, Groups(i).Size.Z.NormalMax)
                        End If
                        If Objects(ObjectCount).Size.Z < Groups(i).Size.Z.NormalMin Then
                            Objects(ObjectCount).Size.Z = Groups(i).Size.Z.NormalMin
                        ElseIf Objects(ObjectCount).Size.Z > Groups(i).Size.Z.NormalMax Then
                            Objects(ObjectCount).Size.Z = Groups(i).Size.Z.NormalMax
                        End If
                    ElseIf Groups(i).Size.Z.Random Then
                        Objects(ObjectCount).Size.Z = Groups(i).Size.Z.RandomMin + ((Groups(i).Size.Z.RandomMax - Groups(i).Size.Z.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).Size.Z.Even Then
                        Objects(ObjectCount).Size.Z = Groups(i).Size.Z.EvenMin + ((Groups(i).Size.Z.EvenMax - Groups(i).Size.Z.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Size.Z.Polynomial Then
                        Objects(ObjectCount).Size.Z = Groups(i).Size.Z.PolynomialC + (j * Groups(i).Size.Z.PolynomialB) + (j * j * Groups(i).Size.Z.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Size.Z = Groups(i).Size.Z.Value
                End If

                'RADIUS
                If Groups(i).Radius.UseFunction Then
                    If Groups(i).Radius.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Radius = Groups(i).Radius.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Radius = RandMaker.GetNextSkewed(Groups(i).Radius.NormalAvg, Groups(i).Radius.NormalMin)
                        Else
                            Objects(ObjectCount).Radius = RandMaker.GetNextSkewed(Groups(i).Radius.NormalAvg, Groups(i).Radius.NormalMax)
                        End If
                        If Objects(ObjectCount).Radius < Groups(i).Radius.NormalMin Then
                            Objects(ObjectCount).Radius = Groups(i).Radius.NormalMin
                        ElseIf Objects(ObjectCount).Radius > Groups(i).Radius.NormalMax Then
                            Objects(ObjectCount).Radius = Groups(i).Radius.NormalMax
                        End If
                    ElseIf Groups(i).Radius.Random Then
                        Objects(ObjectCount).Radius = Groups(i).Radius.RandomMin + ((Groups(i).Radius.RandomMax - Groups(i).Radius.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).Radius.Even Then
                        Objects(ObjectCount).Radius = Groups(i).Radius.EvenMin + ((Groups(i).Radius.EvenMax - Groups(i).Radius.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Radius.Polynomial Then
                        Objects(ObjectCount).Radius = Groups(i).Radius.PolynomialC + (j * Groups(i).Radius.PolynomialB) + (j * j * Groups(i).Radius.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Radius = Groups(i).Radius.Value
                End If

                'NORMAL
                If Groups(i).Type = ObjectType.InfinitePlane Then
                    If Groups(i).Normal.X.UseFunction Then
                        If Groups(i).Normal.X.Normal Then
                            SkewDirection = RandMaker.GetNext
                            If SkewDirection = 0.5 Then
                                Objects(ObjectCount).Normal.X = Groups(i).Normal.X.NormalAvg
                            ElseIf SkewDirection < 0.5 Then
                                Objects(ObjectCount).Normal.X = RandMaker.GetNextSkewed(Groups(i).Normal.X.NormalAvg, Groups(i).Normal.X.NormalMin)
                            Else
                                Objects(ObjectCount).Normal.X = RandMaker.GetNextSkewed(Groups(i).Normal.X.NormalAvg, Groups(i).Normal.X.NormalMax)
                            End If
                            If Objects(ObjectCount).Normal.X < Groups(i).Normal.X.NormalMin Then
                                Objects(ObjectCount).Normal.X = Groups(i).Normal.X.NormalMin
                            ElseIf Objects(ObjectCount).Normal.X > Groups(i).Normal.X.NormalMax Then
                                Objects(ObjectCount).Normal.X = Groups(i).Normal.X.NormalMax
                            End If
                        ElseIf Groups(i).Normal.X.Random Then
                            Objects(ObjectCount).Normal.X = Groups(i).Normal.X.RandomMin + ((Groups(i).Normal.X.RandomMax - Groups(i).Normal.X.RandomMin) * RandMaker.GetNext)
                        ElseIf Groups(i).Normal.X.Even Then
                            Objects(ObjectCount).Normal.X = Groups(i).Normal.X.EvenMin + ((Groups(i).Normal.X.EvenMax - Groups(i).Normal.X.EvenMin) / (ObjectNumber - 1)) * j
                        ElseIf Groups(i).Normal.X.Polynomial Then
                            Objects(ObjectCount).Normal.X = Groups(i).Normal.X.PolynomialC + (j * Groups(i).Normal.X.PolynomialB) + (j * j * Groups(i).Normal.X.PolynomialA)
                        End If
                    Else
                        Objects(ObjectCount).Normal.X = Groups(i).Normal.X.Value
                    End If

                    If Groups(i).Normal.Y.UseFunction Then
                        If Groups(i).Normal.Y.Normal Then
                            SkewDirection = RandMaker.GetNext
                            If SkewDirection = 0.5 Then
                                Objects(ObjectCount).Normal.Y = Groups(i).Normal.Y.NormalAvg
                            ElseIf SkewDirection < 0.5 Then
                                Objects(ObjectCount).Normal.Y = RandMaker.GetNextSkewed(Groups(i).Normal.Y.NormalAvg, Groups(i).Normal.Y.NormalMin)
                            Else
                                Objects(ObjectCount).Normal.Y = RandMaker.GetNextSkewed(Groups(i).Normal.Y.NormalAvg, Groups(i).Normal.Y.NormalMax)
                            End If
                            If Objects(ObjectCount).Normal.Y < Groups(i).Normal.Y.NormalMin Then
                                Objects(ObjectCount).Normal.Y = Groups(i).Normal.Y.NormalMin
                            ElseIf Objects(ObjectCount).Normal.Y > Groups(i).Normal.Y.NormalMax Then
                                Objects(ObjectCount).Normal.Y = Groups(i).Normal.Y.NormalMax
                            End If
                        ElseIf Groups(i).Normal.Y.Random Then
                            Objects(ObjectCount).Normal.Y = Groups(i).Normal.Y.RandomMin + ((Groups(i).Normal.Y.RandomMax - Groups(i).Normal.Y.RandomMin) * RandMaker.GetNext)
                        ElseIf Groups(i).Normal.Y.Even Then
                            Objects(ObjectCount).Normal.Y = Groups(i).Normal.Y.EvenMin + ((Groups(i).Normal.Y.EvenMax - Groups(i).Normal.Y.EvenMin) / (ObjectNumber - 1)) * j
                        ElseIf Groups(i).Normal.Y.Polynomial Then
                            Objects(ObjectCount).Normal.Y = Groups(i).Normal.Y.PolynomialC + (j * Groups(i).Normal.Y.PolynomialB) + (j * j * Groups(i).Normal.Y.PolynomialA)
                        End If
                    Else
                        Objects(ObjectCount).Normal.Y = Groups(i).Normal.Y.Value
                    End If

                    If Groups(i).Normal.Z.UseFunction Then
                        If Groups(i).Normal.Z.Normal Then
                            SkewDirection = RandMaker.GetNext
                            If SkewDirection = 0.5 Then
                                Objects(ObjectCount).Normal.Z = Groups(i).Normal.Z.NormalAvg
                            ElseIf SkewDirection < 0.5 Then
                                Objects(ObjectCount).Normal.Z = RandMaker.GetNextSkewed(Groups(i).Normal.Z.NormalAvg, Groups(i).Normal.Z.NormalMin)
                            Else
                                Objects(ObjectCount).Normal.Z = RandMaker.GetNextSkewed(Groups(i).Normal.Z.NormalAvg, Groups(i).Normal.Z.NormalMax)
                            End If
                            If Objects(ObjectCount).Normal.Z < Groups(i).Normal.Z.NormalMin Then
                                Objects(ObjectCount).Normal.Z = Groups(i).Normal.Z.NormalMin
                            ElseIf Objects(ObjectCount).Normal.Z > Groups(i).Normal.Z.NormalMax Then
                                Objects(ObjectCount).Normal.Z = Groups(i).Normal.Z.NormalMax
                            End If
                        ElseIf Groups(i).Normal.Z.Random Then
                            Objects(ObjectCount).Normal.Z = Groups(i).Normal.Z.RandomMin + ((Groups(i).Normal.Z.RandomMax - Groups(i).Normal.Z.RandomMin) * RandMaker.GetNext)
                        ElseIf Groups(i).Normal.Z.Even Then
                            Objects(ObjectCount).Normal.Z = Groups(i).Normal.Z.EvenMin + ((Groups(i).Normal.Z.EvenMax - Groups(i).Normal.Z.EvenMin) / (ObjectNumber - 1)) * j
                        ElseIf Groups(i).Normal.Z.Polynomial Then
                            Objects(ObjectCount).Normal.Z = Groups(i).Normal.Z.PolynomialC + (j * Groups(i).Normal.Z.PolynomialB) + (j * j * Groups(i).Normal.Z.PolynomialA)
                        End If
                    Else
                        Objects(ObjectCount).Normal.Z = Groups(i).Normal.Z.Value
                    End If
                End If
                'Always make the normal vector a unit vector to simplify later calculations
                Objects(ObjectCount).Normal.makeUnit()

                'ROTATION
                If Groups(i).Type = ObjectType.InfinitePlane Then
                    'Calculate rotation based on the normal vector
                    If Objects(ObjectCount).Normal = New XYZ(0, 1, 0) Then
                        Objects(ObjectCount).Rotation = New XYZ
                    Else
                        'Debug.Print(Acos(Objects(ObjectCount).Normal.Dot(New XYZ(0, 0, 1))).ToString)
                        'Objects(ObjectCount).Rotation = New XYZ(Acos(Objects(ObjectCount).Normal.Dot(New XYZ(0, 1, 0))), Acos(Objects(ObjectCount).Normal.Dot(New XYZ(0, 0, 1))), Acos(Objects(ObjectCount).Normal.Dot(New XYZ(1, 0, 0))))
                    End If

                ElseIf Groups(i).Type = ObjectType.Box Then
                    If Groups(i).Rotation.X.UseFunction Then
                        If Groups(i).Rotation.X.Normal Then
                            SkewDirection = RandMaker.GetNext
                            If SkewDirection = 0.5 Then
                                Objects(ObjectCount).Rotation.X = Groups(i).Rotation.X.NormalAvg
                            ElseIf SkewDirection < 0.5 Then
                                Objects(ObjectCount).Rotation.X = RandMaker.GetNextSkewed(Groups(i).Rotation.X.NormalAvg, Groups(i).Rotation.X.NormalMin)
                            Else
                                Objects(ObjectCount).Rotation.X = RandMaker.GetNextSkewed(Groups(i).Rotation.X.NormalAvg, Groups(i).Rotation.X.NormalMax)
                            End If
                            If Objects(ObjectCount).Rotation.X < Groups(i).Rotation.X.NormalMin Then
                                Objects(ObjectCount).Rotation.X = Groups(i).Rotation.X.NormalMin
                            ElseIf Objects(ObjectCount).Rotation.X > Groups(i).Rotation.X.NormalMax Then
                                Objects(ObjectCount).Rotation.X = Groups(i).Rotation.X.NormalMax
                            End If
                        ElseIf Groups(i).Rotation.X.Random Then
                            Objects(ObjectCount).Rotation.X = Groups(i).Rotation.X.RandomMin + ((Groups(i).Rotation.X.RandomMax - Groups(i).Rotation.X.RandomMin) * RandMaker.GetNext)
                        ElseIf Groups(i).Rotation.X.Even Then
                            Objects(ObjectCount).Rotation.X = Groups(i).Rotation.X.EvenMin + ((Groups(i).Rotation.X.EvenMax - Groups(i).Rotation.X.EvenMin) / (ObjectNumber - 1)) * j
                        ElseIf Groups(i).Rotation.X.Polynomial Then
                            Objects(ObjectCount).Rotation.X = Groups(i).Rotation.X.PolynomialC + (j * Groups(i).Rotation.X.PolynomialB) + (j * j * Groups(i).Rotation.X.PolynomialA)
                        End If
                    Else
                        Objects(ObjectCount).Rotation.X = Groups(i).Rotation.X.Value
                    End If

                    If Groups(i).Rotation.Y.UseFunction Then
                        If Groups(i).Rotation.Y.Normal Then
                            SkewDirection = RandMaker.GetNext
                            If SkewDirection = 0.5 Then
                                Objects(ObjectCount).Rotation.Y = Groups(i).Rotation.Y.NormalAvg
                            ElseIf SkewDirection < 0.5 Then
                                Objects(ObjectCount).Rotation.Y = RandMaker.GetNextSkewed(Groups(i).Rotation.Y.NormalAvg, Groups(i).Rotation.Y.NormalMin)
                            Else
                                Objects(ObjectCount).Rotation.Y = RandMaker.GetNextSkewed(Groups(i).Rotation.Y.NormalAvg, Groups(i).Rotation.Y.NormalMax)
                            End If
                            If Objects(ObjectCount).Rotation.Y < Groups(i).Rotation.Y.NormalMin Then
                                Objects(ObjectCount).Rotation.Y = Groups(i).Rotation.Y.NormalMin
                            ElseIf Objects(ObjectCount).Rotation.Y > Groups(i).Rotation.Y.NormalMax Then
                                Objects(ObjectCount).Rotation.Y = Groups(i).Rotation.Y.NormalMax
                            End If
                        ElseIf Groups(i).Rotation.Y.Random Then
                            Objects(ObjectCount).Rotation.Y = Groups(i).Rotation.Y.RandomMin + ((Groups(i).Rotation.Y.RandomMax - Groups(i).Rotation.Y.RandomMin) * RandMaker.GetNext)
                        ElseIf Groups(i).Rotation.Y.Even Then
                            Objects(ObjectCount).Rotation.Y = Groups(i).Rotation.Y.EvenMin + ((Groups(i).Rotation.Y.EvenMax - Groups(i).Rotation.Y.EvenMin) / (ObjectNumber - 1)) * j
                        ElseIf Groups(i).Rotation.Y.Polynomial Then
                            Objects(ObjectCount).Rotation.Y = Groups(i).Rotation.Y.PolynomialC + (j * Groups(i).Rotation.Y.PolynomialB) + (j * j * Groups(i).Rotation.Y.PolynomialA)
                        End If
                    Else
                        Objects(ObjectCount).Rotation.Y = Groups(i).Rotation.Y.Value
                    End If

                    If Groups(i).Rotation.Z.UseFunction Then
                        If Groups(i).Rotation.Z.Normal Then
                            SkewDirection = RandMaker.GetNext
                            If SkewDirection = 0.5 Then
                                Objects(ObjectCount).Rotation.Z = Groups(i).Rotation.Z.NormalAvg
                            ElseIf SkewDirection < 0.5 Then
                                Objects(ObjectCount).Rotation.Z = RandMaker.GetNextSkewed(Groups(i).Rotation.Z.NormalAvg, Groups(i).Rotation.Z.NormalMin)
                            Else
                                Objects(ObjectCount).Rotation.Z = RandMaker.GetNextSkewed(Groups(i).Rotation.Z.NormalAvg, Groups(i).Rotation.Z.NormalMax)
                            End If
                            If Objects(ObjectCount).Rotation.Z < Groups(i).Rotation.Z.NormalMin Then
                                Objects(ObjectCount).Rotation.Z = Groups(i).Rotation.Z.NormalMin
                            ElseIf Objects(ObjectCount).Rotation.Z > Groups(i).Rotation.Z.NormalMax Then
                                Objects(ObjectCount).Rotation.Z = Groups(i).Rotation.Z.NormalMax
                            End If
                        ElseIf Groups(i).Rotation.Z.Random Then
                            Objects(ObjectCount).Rotation.Z = Groups(i).Rotation.Z.RandomMin + ((Groups(i).Rotation.Z.RandomMax - Groups(i).Rotation.Z.RandomMin) * RandMaker.GetNext)
                        ElseIf Groups(i).Rotation.Z.Even Then
                            Objects(ObjectCount).Rotation.Z = Groups(i).Rotation.Z.EvenMin + ((Groups(i).Rotation.Z.EvenMax - Groups(i).Rotation.Z.EvenMin) / (ObjectNumber - 1)) * j
                        ElseIf Groups(i).Rotation.Z.Polynomial Then
                            Objects(ObjectCount).Rotation.Z = Groups(i).Rotation.Z.PolynomialC + (j * Groups(i).Rotation.Z.PolynomialB) + (j * j * Groups(i).Rotation.Z.PolynomialA)
                        End If
                    Else
                        Objects(ObjectCount).Rotation.Z = Groups(i).Rotation.Z.Value
                    End If
                Else
                    Objects(ObjectCount).Rotation = New XYZ
                End If

                'POSITION
                If Groups(i).Position.X.UseFunction Then
                    If Groups(i).Position.X.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Position.X = Groups(i).Position.X.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Position.X = RandMaker.GetNextSkewed(Groups(i).Position.X.NormalAvg, Groups(i).Position.X.NormalMin)
                        Else
                            Objects(ObjectCount).Position.X = RandMaker.GetNextSkewed(Groups(i).Position.X.NormalAvg, Groups(i).Position.X.NormalMax)
                        End If
                        If Objects(ObjectCount).Position.X < Groups(i).Position.X.NormalMin Then
                            Objects(ObjectCount).Position.X = Groups(i).Position.X.NormalMin
                        ElseIf Objects(ObjectCount).Position.X > Groups(i).Position.X.NormalMax Then
                            Objects(ObjectCount).Position.X = Groups(i).Position.X.NormalMax
                        End If
                    ElseIf Groups(i).Position.X.Random Then
                        Objects(ObjectCount).Position.X = Groups(i).Position.X.RandomMin + ((Groups(i).Position.X.RandomMax - Groups(i).Position.X.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).Position.X.Even Then
                        Objects(ObjectCount).Position.X = Groups(i).Position.X.EvenMin + ((Groups(i).Position.X.EvenMax - Groups(i).Position.X.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Position.X.Polynomial Then
                        Objects(ObjectCount).Position.X = Groups(i).Position.X.PolynomialC + (j * Groups(i).Position.X.PolynomialB) + (j * j * Groups(i).Position.X.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Position.X = Groups(i).Position.X.Value
                End If

                If Groups(i).Position.Y.UseFunction Then
                    If Groups(i).Position.Y.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Position.Y = Groups(i).Position.Y.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Position.Y = RandMaker.GetNextSkewed(Groups(i).Position.Y.NormalAvg, Groups(i).Position.Y.NormalMin)
                        Else
                            Objects(ObjectCount).Position.Y = RandMaker.GetNextSkewed(Groups(i).Position.Y.NormalAvg, Groups(i).Position.Y.NormalMax)
                        End If
                        If Objects(ObjectCount).Position.Y < Groups(i).Position.Y.NormalMin Then
                            Objects(ObjectCount).Position.Y = Groups(i).Position.Y.NormalMin
                        ElseIf Objects(ObjectCount).Position.Y > Groups(i).Position.Y.NormalMax Then
                            Objects(ObjectCount).Position.Y = Groups(i).Position.Y.NormalMax
                        End If
                    ElseIf Groups(i).Position.Y.Random Then
                        Objects(ObjectCount).Position.Y = Groups(i).Position.Y.RandomMin + ((Groups(i).Position.Y.RandomMax - Groups(i).Position.Y.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).Position.Y.Even Then
                        Objects(ObjectCount).Position.Y = Groups(i).Position.Y.EvenMin + ((Groups(i).Position.Y.EvenMax - Groups(i).Position.Y.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Position.Y.Polynomial Then
                        Objects(ObjectCount).Position.Y = Groups(i).Position.Y.PolynomialC + (j * Groups(i).Position.Y.PolynomialB) + (j * j * Groups(i).Position.Y.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Position.Y = Groups(i).Position.Y.Value
                End If

                If Groups(i).Position.Z.UseFunction Then
                    If Groups(i).Position.Z.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Position.Z = Groups(i).Position.Z.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Position.Z = RandMaker.GetNextSkewed(Groups(i).Position.Z.NormalAvg, Groups(i).Position.Z.NormalMin)
                        Else
                            Objects(ObjectCount).Position.Z = RandMaker.GetNextSkewed(Groups(i).Position.Z.NormalAvg, Groups(i).Position.Z.NormalMax)
                        End If
                        If Objects(ObjectCount).Position.Z < Groups(i).Position.Z.NormalMin Then
                            Objects(ObjectCount).Position.Z = Groups(i).Position.Z.NormalMin
                        ElseIf Objects(ObjectCount).Position.Z > Groups(i).Position.Z.NormalMax Then
                            Objects(ObjectCount).Position.Z = Groups(i).Position.Z.NormalMax
                        End If
                    ElseIf Groups(i).Position.Z.Random Then
                        Objects(ObjectCount).Position.Z = Groups(i).Position.Z.RandomMin + ((Groups(i).Position.Z.RandomMax - Groups(i).Position.Z.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).Position.Z.Even Then
                        Objects(ObjectCount).Position.Z = Groups(i).Position.Z.EvenMin + ((Groups(i).Position.Z.EvenMax - Groups(i).Position.Z.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Position.Z.Polynomial Then
                        Objects(ObjectCount).Position.Z = Groups(i).Position.Z.PolynomialC + (j * Groups(i).Position.Z.PolynomialB) + (j * j * Groups(i).Position.Z.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Position.Z = Groups(i).Position.Z.Value
                End If

                'VELOCITY
                If Groups(i).Velocity.X.UseFunction Then
                    If Groups(i).Velocity.X.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Velocity.X = Groups(i).Velocity.X.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Velocity.X = RandMaker.GetNextSkewed(Groups(i).Velocity.X.NormalAvg, Groups(i).Velocity.X.NormalMin)
                        Else
                            Objects(ObjectCount).Velocity.X = RandMaker.GetNextSkewed(Groups(i).Velocity.X.NormalAvg, Groups(i).Velocity.X.NormalMax)
                        End If
                        If Objects(ObjectCount).Velocity.X < Groups(i).Velocity.X.NormalMin Then
                            Objects(ObjectCount).Velocity.X = Groups(i).Velocity.X.NormalMin
                        ElseIf Objects(ObjectCount).Velocity.X > Groups(i).Velocity.X.NormalMax Then
                            Objects(ObjectCount).Velocity.X = Groups(i).Velocity.X.NormalMax
                        End If
                    ElseIf Groups(i).Velocity.X.Random Then
                        Objects(ObjectCount).Velocity.X = Groups(i).Velocity.X.RandomMin + ((Groups(i).Velocity.X.RandomMax - Groups(i).Velocity.X.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).Velocity.X.Even Then
                        Objects(ObjectCount).Velocity.X = Groups(i).Velocity.X.EvenMin + ((Groups(i).Velocity.X.EvenMax - Groups(i).Velocity.X.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Velocity.X.Polynomial Then
                        Objects(ObjectCount).Velocity.X = Groups(i).Velocity.X.PolynomialC + (j * Groups(i).Velocity.X.PolynomialB) + (j * j * Groups(i).Velocity.X.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Velocity.X = Groups(i).Velocity.X.Value
                End If

                If Groups(i).Velocity.Y.UseFunction Then
                    If Groups(i).Velocity.Y.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Velocity.Y = Groups(i).Velocity.Y.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Velocity.Y = RandMaker.GetNextSkewed(Groups(i).Velocity.Y.NormalAvg, Groups(i).Velocity.Y.NormalMin)
                        Else
                            Objects(ObjectCount).Velocity.Y = RandMaker.GetNextSkewed(Groups(i).Velocity.Y.NormalAvg, Groups(i).Velocity.Y.NormalMax)
                        End If
                        If Objects(ObjectCount).Velocity.Y < Groups(i).Velocity.Y.NormalMin Then
                            Objects(ObjectCount).Velocity.Y = Groups(i).Velocity.Y.NormalMin
                        ElseIf Objects(ObjectCount).Velocity.Y > Groups(i).Velocity.Y.NormalMax Then
                            Objects(ObjectCount).Velocity.Y = Groups(i).Velocity.Y.NormalMax
                        End If
                    ElseIf Groups(i).Velocity.Y.Random Then
                        Objects(ObjectCount).Velocity.Y = Groups(i).Velocity.Y.RandomMin + ((Groups(i).Velocity.Y.RandomMax - Groups(i).Velocity.Y.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).Velocity.Y.Even Then
                        Objects(ObjectCount).Velocity.Y = Groups(i).Velocity.Y.EvenMin + ((Groups(i).Velocity.Y.EvenMax - Groups(i).Velocity.Y.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Velocity.Y.Polynomial Then
                        Objects(ObjectCount).Velocity.Y = Groups(i).Velocity.Y.PolynomialC + (j * Groups(i).Velocity.Y.PolynomialB) + (j * j * Groups(i).Velocity.Y.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Velocity.Y = Groups(i).Velocity.Y.Value
                End If

                If Groups(i).Velocity.Z.UseFunction Then
                    If Groups(i).Velocity.Z.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Velocity.Z = Groups(i).Velocity.Z.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Velocity.Z = RandMaker.GetNextSkewed(Groups(i).Velocity.Z.NormalAvg, Groups(i).Velocity.Z.NormalMin)
                        Else
                            Objects(ObjectCount).Velocity.Z = RandMaker.GetNextSkewed(Groups(i).Velocity.Z.NormalAvg, Groups(i).Velocity.Z.NormalMax)
                        End If
                        If Objects(ObjectCount).Velocity.Z < Groups(i).Velocity.Z.NormalMin Then
                            Objects(ObjectCount).Velocity.Z = Groups(i).Velocity.Z.NormalMin
                        ElseIf Objects(ObjectCount).Velocity.Z > Groups(i).Velocity.Z.NormalMax Then
                            Objects(ObjectCount).Velocity.Z = Groups(i).Velocity.Z.NormalMax
                        End If
                    ElseIf Groups(i).Velocity.Z.Random Then
                        Objects(ObjectCount).Velocity.Z = Groups(i).Velocity.Z.RandomMin + ((Groups(i).Velocity.Z.RandomMax - Groups(i).Velocity.Z.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).Velocity.Z.Even Then
                        Objects(ObjectCount).Velocity.Z = Groups(i).Velocity.Z.EvenMin + ((Groups(i).Velocity.Z.EvenMax - Groups(i).Velocity.Z.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Velocity.Z.Polynomial Then
                        Objects(ObjectCount).Velocity.Z = Groups(i).Velocity.Z.PolynomialC + (j * Groups(i).Velocity.Z.PolynomialB) + (j * j * Groups(i).Velocity.Z.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Velocity.Z = Groups(i).Velocity.Z.Value
                End If

                'COLOR
                If Groups(i).Color.UseFunction Then
                    If Groups(i).Color.Normal Then
                        Objects(ObjectCount).Color = GetNormalColor(Groups(i).Color.NormalMin, Groups(i).Color.NormalAvg, Groups(i).Color.NormalMax)
                    ElseIf Groups(i).Color.Random Then
                        Objects(ObjectCount).Color = BlendColors(Groups(i).Color.RandomMin, Groups(i).Color.RandomMax, RandMaker.GetNext)
                    ElseIf Groups(i).Color.Even Then
                        Objects(ObjectCount).Color = BlendColors(Groups(i).Color.EvenMax, Groups(i).Color.EvenMin, (j / (ObjectNumber - 1)))
                    ElseIf Groups(i).Color.Polynomial Then
                        Objects(ObjectCount).Color = GetPolyColor(Groups(i).Color.PolynomialA, Groups(i).Color.PolynomialB, Groups(i).Color.PolynomialC, j)
                    End If
                Else
                    Objects(ObjectCount).Color = Groups(i).Color.Value
                End If

                'HIGHLIGHT COLOR
                If Groups(i).Highlight.UseFunction Then
                    If Groups(i).Highlight.Normal Then
                        Objects(ObjectCount).HighlightColor = GetNormalColor(Groups(i).Highlight.NormalMin, Groups(i).Highlight.NormalAvg, Groups(i).Highlight.NormalMax)
                    ElseIf Groups(i).Highlight.Random Then
                        Objects(ObjectCount).HighlightColor = BlendColors(Groups(i).Highlight.RandomMin, Groups(i).Highlight.RandomMax, RandMaker.GetNext)
                    ElseIf Groups(i).Highlight.Even Then
                        Objects(ObjectCount).HighlightColor = BlendColors(Groups(i).Highlight.EvenMax, Groups(i).Highlight.EvenMin, (j / (ObjectNumber - 1)))
                    ElseIf Groups(i).Highlight.Polynomial Then
                        Objects(ObjectCount).HighlightColor = GetPolyColor(Groups(i).Highlight.PolynomialA, Groups(i).Highlight.PolynomialB, Groups(i).Highlight.PolynomialC, j)
                    End If
                Else
                    Objects(ObjectCount).HighlightColor = Groups(i).Highlight.Value
                End If
                'HIGHLIGHT SHARPNESS
                If Groups(i).Sharpness.UseFunction Then
                    If Groups(i).Sharpness.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).HighlightSharpness = Groups(i).Sharpness.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).HighlightSharpness = ToSingle(RandMaker.GetNextSkewed(ToDouble(Groups(i).Sharpness.NormalAvg), ToDouble(Groups(i).Sharpness.NormalMin)))
                        Else
                            Objects(ObjectCount).HighlightSharpness = ToSingle(RandMaker.GetNextSkewed(ToDouble(Groups(i).Sharpness.NormalAvg), ToDouble(Groups(i).Sharpness.NormalMax)))
                        End If
                        If Objects(ObjectCount).HighlightSharpness < Groups(i).Sharpness.NormalMin Then
                            Objects(ObjectCount).HighlightSharpness = Groups(i).Sharpness.NormalMin
                        ElseIf Objects(ObjectCount).HighlightSharpness > Groups(i).Sharpness.NormalMax Then
                            Objects(ObjectCount).HighlightSharpness = Groups(i).Sharpness.NormalMax
                        End If
                    ElseIf Groups(i).Sharpness.Random Then
                        Objects(ObjectCount).HighlightSharpness = Groups(i).Sharpness.RandomMin + ToSingle((Groups(i).Sharpness.RandomMax - Groups(i).Sharpness.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).Sharpness.Even Then
                        Objects(ObjectCount).HighlightSharpness = Groups(i).Sharpness.EvenMin + ((Groups(i).Sharpness.EvenMax - Groups(i).Sharpness.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Sharpness.Polynomial Then
                        Objects(ObjectCount).HighlightSharpness = Groups(i).Sharpness.PolynomialC + (j * Groups(i).Sharpness.PolynomialB) + (j * j * Groups(i).Sharpness.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).HighlightSharpness = Groups(i).Sharpness.Value
                End If

                If Objects(ObjectCount).HighlightSharpness > 200 Then
                    Objects(ObjectCount).HighlightSharpness = 200
                End If

                'REFLECTIVITY
                If Groups(i).Reflectivity.UseFunction Then
                    If Groups(i).Reflectivity.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Reflectivity = Groups(i).Reflectivity.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Reflectivity = RandMaker.GetNextSkewed(Groups(i).Reflectivity.NormalAvg, Groups(i).Reflectivity.NormalMin)
                        Else
                            Objects(ObjectCount).Reflectivity = RandMaker.GetNextSkewed(Groups(i).Reflectivity.NormalAvg, Groups(i).Reflectivity.NormalMax)
                        End If
                        If Objects(ObjectCount).Reflectivity < Groups(i).Reflectivity.NormalMin Then
                            Objects(ObjectCount).Reflectivity = Groups(i).Reflectivity.NormalMin
                        ElseIf Objects(ObjectCount).Reflectivity > Groups(i).Reflectivity.NormalMax Then
                            Objects(ObjectCount).Reflectivity = Groups(i).Reflectivity.NormalMax
                        End If
                    ElseIf Groups(i).Reflectivity.Random Then
                        Objects(ObjectCount).Reflectivity = Groups(i).Reflectivity.RandomMin + (Groups(i).Reflectivity.RandomMax - Groups(i).Reflectivity.RandomMin) * RandMaker.GetNext
                    ElseIf Groups(i).Reflectivity.Even Then
                        Objects(ObjectCount).Reflectivity = Groups(i).Reflectivity.EvenMin + ((Groups(i).Reflectivity.EvenMax - Groups(i).Reflectivity.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Reflectivity.Polynomial Then
                        Objects(ObjectCount).Reflectivity = Groups(i).Reflectivity.PolynomialC + (j * Groups(i).Reflectivity.PolynomialB) + (j * j * Groups(i).Reflectivity.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Reflectivity = Groups(i).Reflectivity.Value
                End If

                If Objects(ObjectCount).Reflectivity > 100 Then
                    Objects(ObjectCount).Reflectivity = 100
                End If

                'TRANSPARENCY

                If Groups(i).Transparency.UseFunction Then
                    If Groups(i).Transparency.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).Transparency = Groups(i).Transparency.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).Transparency = RandMaker.GetNextSkewed(Groups(i).Transparency.NormalAvg, Groups(i).Transparency.NormalMin)
                        Else
                            Objects(ObjectCount).Transparency = RandMaker.GetNextSkewed(Groups(i).Transparency.NormalAvg, Groups(i).Transparency.NormalMax)
                        End If
                        If Objects(ObjectCount).Transparency < Groups(i).Transparency.NormalMin Then
                            Objects(ObjectCount).Transparency = Groups(i).Transparency.NormalMin
                        ElseIf Objects(ObjectCount).Transparency > Groups(i).Transparency.NormalMax Then
                            Objects(ObjectCount).Transparency = Groups(i).Transparency.NormalMax
                        End If
                    ElseIf Groups(i).Transparency.Random Then
                        Objects(ObjectCount).Transparency = Groups(i).Transparency.RandomMin + (Groups(i).Transparency.RandomMax - Groups(i).Transparency.RandomMin) * RandMaker.GetNext
                    ElseIf Groups(i).Transparency.Even Then
                        Objects(ObjectCount).Transparency = Groups(i).Transparency.EvenMin + ((Groups(i).Transparency.EvenMax - Groups(i).Transparency.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).Transparency.Polynomial Then
                        Objects(ObjectCount).Transparency = Groups(i).Transparency.PolynomialC + (j * Groups(i).Transparency.PolynomialB) + (j * j * Groups(i).Transparency.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).Transparency = Groups(i).Transparency.Value
                End If
                If Objects(ObjectCount).Transparency > 255 Then
                    Objects(ObjectCount).Transparency = 255
                End If
                Objects(ObjectCount).Color = Color.FromArgb(ToByte(Objects(ObjectCount).Transparency), Objects(ObjectCount).Color.R, Objects(ObjectCount).Color.G, Objects(ObjectCount).Color.B)

                'REFRACTIVE INDEX
                If Groups(i).RefractiveIndex.UseFunction Then
                    If Groups(i).RefractiveIndex.Normal Then
                        SkewDirection = RandMaker.GetNext
                        If SkewDirection = 0.5 Then
                            Objects(ObjectCount).RefractiveIndex = Groups(i).RefractiveIndex.NormalAvg
                        ElseIf SkewDirection < 0.5 Then
                            Objects(ObjectCount).RefractiveIndex = RandMaker.GetNextSkewed(Groups(i).RefractiveIndex.NormalAvg, Groups(i).RefractiveIndex.NormalMin)
                        Else
                            Objects(ObjectCount).RefractiveIndex = RandMaker.GetNextSkewed(Groups(i).RefractiveIndex.NormalAvg, Groups(i).RefractiveIndex.NormalMax)
                        End If
                        If Objects(ObjectCount).RefractiveIndex < Groups(i).RefractiveIndex.NormalMin Then
                            Objects(ObjectCount).RefractiveIndex = Groups(i).RefractiveIndex.NormalMin
                        ElseIf Objects(ObjectCount).RefractiveIndex > Groups(i).RefractiveIndex.NormalMax Then
                            Objects(ObjectCount).RefractiveIndex = Groups(i).RefractiveIndex.NormalMax
                        End If
                    ElseIf Groups(i).RefractiveIndex.Random Then
                        Objects(ObjectCount).RefractiveIndex = Groups(i).RefractiveIndex.RandomMin + ((Groups(i).RefractiveIndex.RandomMax - Groups(i).RefractiveIndex.RandomMin) * RandMaker.GetNext)
                    ElseIf Groups(i).RefractiveIndex.Even Then
                        Objects(ObjectCount).RefractiveIndex = Groups(i).RefractiveIndex.EvenMin + ((Groups(i).RefractiveIndex.EvenMax - Groups(i).RefractiveIndex.EvenMin) / (ObjectNumber - 1)) * j
                    ElseIf Groups(i).RefractiveIndex.Polynomial Then
                        Objects(ObjectCount).RefractiveIndex = Groups(i).RefractiveIndex.PolynomialC + (j * Groups(i).RefractiveIndex.PolynomialB) + (j * j * Groups(i).RefractiveIndex.PolynomialA)
                    End If
                Else
                    Objects(ObjectCount).RefractiveIndex = Groups(i).RefractiveIndex.Value
                End If

                ObjectCount += 1
            Next
        Next
    End Sub
    Public Sub RunSimulation()
        'Clear flags
        Paused = False
        Running = True

        'Reinitialize the random number generator
        RandMaker.Seed = GetUnique()
        RandMaker.Restart()

        ConvertGroupstoObjects()

        'Resize the output display
        Output.ClientSize = New Size(Render.Width, Render.Height)

        'Initialize the Camera
        If Render.Mode < 2 Then
            Camera.Raytraced = False
        Else
            Camera.Raytraced = True
        End If
        Camera.Intitialize(Render.Width, Render.Height, Render.Scale)

        'Calculate Permitivity value
        Ec = 1 / (4 * PI * Eo * Forces.ElectroStatic.Permittivity)

        'Initialize render engine
        If InitializeRender() = False Then
            MsgBox("Unable to initialize graphics. Verify that Render Mode has been set correctly.", MsgBoxStyle.Critical, "Error")
            StopSimulation()
            Exit Sub
        End If

        'If breakages might happen then make room for additial objects that might be needed
        If Collisions.Breakable Then
            Array.Resize(Me.Objects, Settings.MaxObjects)
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

        Dim CompNumber As Integer
        If NeedCompute() = True Then
            CompNumber = 1
        Else
            CompNumber = 0
        End If

        Dim RenderNumber As Integer
        If Render.RenderThreads = -1 Then
            RenderNumber = CPUNumber - CompNumber
        Else
            RenderNumber = Render.RenderThreads
        End If

        If RenderNumber < 1 Then
            RenderNumber = 1
        End If
        SetThreads(CompNumber, RenderNumber)
    End Sub
    Public Function isPaused() As Boolean
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

        If Render.Mode < 2 Then
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

    Public Overloads Sub ToString(stringBuilder As StringBuilder)
        stringBuilder.AppendLine("<PR4-File>")

        stringBuilder.AppendLine("<LightCount>")
        stringBuilder.Append(LightCount.ToString())
        stringBuilder.Append("</LightCount>")

        stringBuilder.AppendLine("<GroupCount>")
        stringBuilder.Append(GroupCount.ToString())
        stringBuilder.Append("</GroupCount>")

        stringBuilder.AppendLine("<Camera>")
        Camera.ToString(stringBuilder)
        stringBuilder.Append("</Camera>")

        stringBuilder.AppendLine("<Collisions>")
        Collisions.ToString(stringBuilder)
        stringBuilder.Append("</Collisions>")

        stringBuilder.AppendLine("<Forces>")
        Forces.ToString(stringBuilder)
        stringBuilder.Append("</Forces>")

        stringBuilder.AppendLine("<Settings>")
        Settings.ToString(stringBuilder)
        stringBuilder.Append("</Settings>")

        stringBuilder.AppendLine("<Render>")
        Render.ToString(stringBuilder)
        stringBuilder.Append("</Render>")

        For i = 0 To GroupCount - 1
            stringBuilder.AppendLine("<Group>")
            Groups(i).ToString(stringBuilder)
            stringBuilder.AppendLine("</Group>")
        Next
        For i = 0 To LightCount - 1
            stringBuilder.AppendLine("<Light>")
            Lights(i).ToString(stringBuilder)
            stringBuilder.AppendLine("</Light>")
        Next
        stringBuilder.AppendLine("</PR4-File>")
    End Sub

    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder)
        Return stringBuilder.ToString
    End Function
    Public Sub EnlargeGroups()
        GroupCount += 1
        Array.Resize(Groups, GroupCount)
        Groups(GroupCount - 1) = New SimulationGroup
    End Sub
    Public Sub EnlargeLights()
        LightCount += 1
        Array.Resize(Lights, LightCount)
        Lights(LightCount - 1) = New SimulationLight
    End Sub
    Public Sub RemoveGroup(ByVal i As Integer)
        For q = i To GroupCount - 2
            Groups(q).Copy(Groups(q + 1))
        Next
        GroupCount -= 1
        Array.Resize(Groups, GroupCount)
    End Sub
    Public Sub RemoveLight(ByVal i As Integer)
        For q = i To LightCount - 2
            Lights(q).Copy(Lights(q + 1))
        Next
        LightCount -= 1
        Array.Resize(Lights, LightCount)
    End Sub
    Public Sub Load(ByRef intext As String)
        Dim StartPos As Integer
        Dim EnQtoIPosistion As Integer
        Dim q As Integer
        Dim Result As String

        Result = GetValue(intext, "LightCount")
        If Result <> "" And IsNumeric(Result) Then
            LightCount = ToInt32(Result)
        Else
            LightCount = 1
        End If

        Result = GetValue(intext, "GroupCount")
        If Result <> "" And IsNumeric(Result) Then
            GroupCount = ToInt32(Result)
        Else
            GroupCount = 1
        End If

        Result = GetValue(intext, "Camera")
        If Result <> "" Then
            Camera.Load(Result)
        Else
            Camera.Clear()
        End If

        Result = GetValue(intext, "Collisions")
        If Result <> "" Then
            Collisions.Load(Result)
        Else
            Collisions.Clear()
        End If

        Result = GetValue(intext, "Forces")
        If Result <> "" Then
            Forces.Load(Result)
        Else
            Forces.Clear()
        End If

        Result = GetValue(intext, "Settings")
        If Result <> "" Then
            Settings.Load(Result)
        Else
            Settings.Clear()
        End If

        Result = GetValue(intext, "Render")
        If Result <> "" Then
            Render.Load(Result)
        Else
            Render.Clear()
        End If

        'Create new Groups
        ReDim Groups(GroupCount - 1)
        For i = 0 To GroupCount - 1
            Groups(i) = New SimulationGroup
        Next

        'Load Groups
        For i = 1 To Len(intext)
            If UCase(Mid(intext, i, Len("<Group>"))) = UCase("<Group>") Then
                StartPos = i + Len("<Group>") - 1
            ElseIf UCase(Mid(intext, i, Len("</Group>"))) = UCase("</Group>") Then
                EnQtoIPosistion = i - 1
                Groups(q).Load(Mid(intext, StartPos, EnQtoIPosistion - StartPos + 1))
                q = q + 1
                If q > GroupCount Then Exit For
            End If
        Next

        'Reset Flags
        StartPos = 0
        EnQtoIPosistion = 0
        q = 0

        'Create new Lights
        ReDim Lights(LightCount - 1)
        For i = 0 To LightCount - 1
            Lights(i) = New SimulationLight
        Next

        'Load Lights
        For i = 1 To Len(intext)
            If UCase(Mid(intext, i, Len("<Light>"))) = UCase("<Light>") Then
                StartPos = i + Len("<Light>") - 1
            ElseIf UCase(Mid(intext, i, Len("</Light>"))) = UCase("</Light>") Then
                EnQtoIPosistion = i - 1
                Lights(q).Load(Mid(intext, StartPos, EnQtoIPosistion - StartPos + 1))
                q = q + 1
                If q > LightCount Then Exit For
            End If
        Next
    End Sub
#End Region
#Region "Breaking"
    Private Sub DoBreak(ByRef Index As Integer)
        'Variables used in the breaking
        Dim SkewDirection As Double  ' Determines the direction of the distribution curve
        Dim BreakNumber As Integer 'Determines the number of resulting objects
        Dim NewObjects(Collisions.AddMax) As SimulationObject 'Temporarily holds the objects while they are being created
        Dim MassAssigned(Collisions.AddMax) As Double 'A random amount of mass that is assigned to each object
        Dim VolumeAssigned(Collisions.AddMax) As Double 'A random amount of volume that is assigned to each object
        Dim VelocityComponents(Collisions.AddMax) As XYZ 'The random distribution of the velocity acroos all three components
        Dim VelocityMagnitude(Collisions.AddMax) As Double 'The magnitude of the velocity in all three components
        Dim TotalMass As Double 'The total amount of mass that has been assigned to the new objects
        Dim TotalVelocityMagnitude As Double 'The total amount of velocity that has been assigned to each component
        Dim VelocityMagnitudeI As Double
        Dim VelocityI As New XYZ
        Dim VelocityJ As New XYZ
        Dim VelocityK As New XYZ
        Dim RadiusTemp As Double
        Dim TessNumber As Integer
        Dim TessBox As New SimulationObject
        Dim OldVolume As Double

        'Make sure there is room for more objects
        If ObjectCount >= Settings.MaxObjects Then Exit Sub

        'Determine what distribution curve will be used
        SkewDirection = RandMaker.GetNext
        If SkewDirection = 0.5 Then
            BreakNumber = Collisions.AddAvg
        ElseIf SkewDirection < 0.5 Then
            BreakNumber = ToInt32(RandMaker.GetNextSkewed(Collisions.AddAvg, Collisions.AddMin))
        Else
            BreakNumber = ToInt32(RandMaker.GetNextSkewed(Collisions.AddAvg, Collisions.AddMax))
        End If

        'Verify reasonable results
        If BreakNumber < Collisions.AddMin Then
            BreakNumber = Collisions.AddMin
        ElseIf BreakNumber > Collisions.AddMax Then
            BreakNumber = Collisions.AddMax
        End If
        If ObjectCount - 1 + BreakNumber > Settings.MaxObjects Then
            BreakNumber = Settings.MaxObjects - ObjectCount + 1
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
            NewObjects(Z).Velocity.makeUnit()
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
            If Forces.ElectroStatic.Enabled Then
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
                NewObjects(Z).Position = Objects(Index).Position + (RadiusTemp * NewObjects(Z).Velocity.getUnit)
            Next

            'ASSIGN CHARGE BASED ON MASS
            If Forces.ElectroStatic.Enabled Then
                For Z = 0 To BreakNumber - 1
                    NewObjects(Z).Charge = MassAssigned(Z) * Objects(Index).Charge 'Assign the charge to the final objects
                Next
            End If
        End If



        'COPY THE NEW OBJECTS OVER
        SyncLock LockRayData ' Make sure Raytracing isn't loading the data 
            SyncLock LockDX ' Make sure Direct X isn't displaying the data
                'Copy over the new objects into the simulation
                Objects(Index).Copy(NewObjects(0))
                For Z = 1 To BreakNumber - 1
                    Objects(ObjectCount) = New SimulationObject
                    Objects(ObjectCount).Copy(NewObjects(Z))
                    ObjectCount += 1
                Next
            End SyncLock
        End SyncLock
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
        If Not Forces.Enabled Then
            Return False
        Else
            'Gravity
            If Forces.Gravity Then
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
            If Forces.Drag.Enabled = True Then
                For i As Integer = 0 To ObjectCount - 1 'Check that the objects allow interaction
                    If Objects(i).Affected Then 'If one object can be affected by drag
                        If Not Objects(i).Velocity.isZero Then 'If that object has a velocity
                            Return True
                        End If
                    End If
                Next
            End If

            'Uniform field
            If Forces.Field.Enabled Then
                If Not Forces.Field.Acceleration.isZero Then ' Field isn't null
                    For i As Integer = 0 To ObjectCount - 1 'Check that the objects allow interaction
                        If Objects(i).Affected Then 'If one object can be affected by the field
                            Return True
                        End If
                    Next
                End If
            End If

            'Electrostatic
            If Forces.ElectroStatic.Enabled Then
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
    Private Sub DoCompute()
        Dim T As Double = Settings.TimeStep
        Dim HalfT As Double = 0.5 * T
        Dim HalfTSqd As Double = HalfT * T
        Dim i As Integer

        '~~~~~NO INTEGRATION~~~~~~~
        If Not NeedIntegration() Then
            If Collisions.Enabled And Collisions.Interpolate Then
                Do While Running
                    SyncLock LockRayData
                        For i = 0 To ObjectCount - 1
                            Objects(i).OldPosition.Copy(Objects(i).Position)
                            Objects(i).Position += Objects(i).Velocity * T
                        Next
                    End SyncLock
                    DoCollisions()
                    ComputationControl()
                Loop
            Else
                Do While Running
                    If Collisions.Enabled Then DoCollisions()
                    SyncLock LockRayData
                        For i = 0 To ObjectCount - 1
                            Objects(i).Position += Objects(i).Velocity * T
                        Next
                    End SyncLock
                    ComputationControl()
                Loop
            End If
        Else
            '~~~~~EULER~~~~~~~
            If Settings.IntegrationMethod = 0 Then
                If Collisions.Enabled And Collisions.Interpolate Then
                    Do While Running
                        DoForces()
                        SyncLock LockRayData
                            For i = 0 To ObjectCount - 1
                                Objects(i).OldPosition.Copy(Objects(i).Position)
                                Objects(i).Velocity += Objects(i).Acceleration * T
                                Objects(i).Position += Objects(i).Velocity * T
                            Next
                        End SyncLock
                        DoCollisions()
                        ComputationControl()
                    Loop
                Else
                    Do While Running
                        If Collisions.Enabled Then DoCollisions()
                        DoForces()
                        SyncLock LockRayData
                            For i = 0 To ObjectCount - 1
                                Objects(i).Velocity += Objects(i).Acceleration * T
                                Objects(i).Position += Objects(i).Velocity * T
                            Next
                        End SyncLock
                        ComputationControl()
                    Loop
                End If
                '~~~~~VERLET~~~~~~~~~
            ElseIf Settings.IntegrationMethod = 1 Then
                If Collisions.Enabled And Collisions.Interpolate Then
                    DoForces() 'Initial forces
                    Do While Running
                        SyncLock LockRayData
                            For i = 0 To ObjectCount - 1
                                Objects(i).OldPosition.Copy(Objects(i).Position)
                                Objects(i).Position += (Objects(i).Velocity * T) + (HalfTSqd * Objects(i).Acceleration)
                                Objects(i).Velocity += HalfT * Objects(i).Acceleration
                            Next
                        End SyncLock
                        DoForces()
                        For i = 0 To ObjectCount - 1
                            Objects(i).Velocity += Objects(i).Acceleration * HalfT
                        Next
                        DoCollisions()
                        ComputationControl()
                    Loop
                Else
                    DoForces() 'Initial forces
                    Do While Running
                        If Collisions.Enabled Then DoCollisions()
                        SyncLock LockRayData
                            For i = 0 To ObjectCount - 1
                                Objects(i).Position += (Objects(i).Velocity * T) + (HalfTSqd * Objects(i).Acceleration)
                                Objects(i).Velocity += HalfT * Objects(i).Acceleration
                            Next
                        End SyncLock
                        DoForces()
                        For i = 0 To ObjectCount - 1
                            Objects(i).Velocity += Objects(i).Acceleration * HalfT
                        Next
                        ComputationControl()
                    Loop
                End If
                '~~~~~4th order Symplectic~~~~~~~
            ElseIf Settings.IntegrationMethod = 2 Then
                Const b As Double = 2 ^ (1 / 3)
                Const a As Double = 2 - b
                Const x0 As Double = -b / a
                Const x1 As Double = 1 / a
                Dim d() As Double = {T * x1, T * x0, T * x1}
                Dim c() As Double = {x1 * HalfT, (x0 + x1) * HalfT, (x0 + x1) * HalfT, x1 * HalfT}
                If Collisions.Enabled And Collisions.Interpolate Then
                    Do While Running
                        For i = 0 To ObjectCount - 1
                            Objects(i).OldPosition.Copy(Objects(i).Position)
                        Next
                        For j = 0 To 2
                            SyncLock LockRayData
                                For i = 0 To ObjectCount - 1
                                    Objects(i).Position += c(j) * Objects(i).Velocity
                                Next
                            End SyncLock
                            DoForces()
                            For i = 0 To ObjectCount - 1
                                Objects(i).Velocity += d(j) * Objects(i).Acceleration
                            Next
                        Next
                        SyncLock LockRayData
                            For i = 0 To ObjectCount - 1
                                Objects(i).Position += c(3) * Objects(i).Velocity
                            Next
                        End SyncLock
                        DoCollisions()
                        ComputationControl()
                    Loop
                Else
                    Do While Running
                        If Collisions.Enabled Then DoCollisions()
                        For j = 0 To 2
                            SyncLock LockRayData
                                For i = 0 To ObjectCount - 1
                                    Objects(i).Position += c(j) * Objects(i).Velocity
                                Next
                            End SyncLock
                            DoForces()
                            For i = 0 To ObjectCount - 1
                                Objects(i).Velocity += d(j) * Objects(i).Acceleration
                            Next
                        Next
                        SyncLock LockRayData
                            For i = 0 To ObjectCount - 1
                                Objects(i).Position += c(3) * Objects(i).Velocity
                            Next
                        End SyncLock
                        ComputationControl()
                    Loop
                End If

                '~~~~~6th order Symplectic~~~~~~~
            ElseIf Settings.IntegrationMethod = 3 Then
                Const w1 As Double = -1.17767998417887
                Const w2 As Double = 0.235573213359357
                Const w3 As Double = 0.78451361047756
                Const w0 As Double = 1 - (2 * (w1 + w2 + w3))
                Dim d() As Double = {T * w3, T * w2, T * w1, T * w0, T * w1, T * w2, T * w3}
                Dim c() As Double = {w3 * HalfT, (w3 + w2) * HalfT, (w2 + w1) * HalfT, (w1 + w0) * HalfT, (w1 + w0) * HalfT, (w2 + w1) * HalfT, (w3 + w2) * HalfT, w3 * HalfT}
                If Collisions.Enabled And Collisions.Interpolate Then
                    Do While Running
                        For i = 0 To ObjectCount - 1
                            Objects(i).OldPosition.Copy(Objects(i).Position)
                        Next
                        For j = 0 To 6
                            SyncLock LockRayData
                                For i = 0 To ObjectCount - 1
                                    Objects(i).Position += c(j) * Objects(i).Velocity
                                Next
                            End SyncLock
                            DoForces()
                            For i = 0 To ObjectCount - 1
                                Objects(i).Velocity += d(j) * Objects(i).Acceleration
                            Next
                        Next
                        SyncLock LockRayData
                            For i = 0 To ObjectCount - 1
                                Objects(i).Position += c(7) * Objects(i).Velocity
                            Next
                        End SyncLock
                        DoCollisions()
                        ComputationControl()
                    Loop
                Else
                    Do While Running
                        For j = 0 To 6
                            SyncLock LockRayData
                                For i = 0 To ObjectCount - 1
                                    Objects(i).Position += c(j) * Objects(i).Velocity
                                Next
                            End SyncLock
                            DoForces()
                            For i = 0 To ObjectCount - 1
                                Objects(i).Velocity += d(j) * Objects(i).Acceleration
                            Next
                        Next
                        SyncLock LockRayData
                            For i = 0 To ObjectCount - 1
                                Objects(i).Position += c(7) * Objects(i).Velocity
                            Next
                        End SyncLock
                        If Collisions.Enabled Then DoCollisions()
                        ComputationControl()
                    Loop
                End If
            End If
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
        If Forces.Field.Enabled Then
            'Apply field
            For I = 0 To ObjectCount - 1
                If Objects(I).Affected Then
                    Objects(I).Acceleration.Copy(Forces.Field.Acceleration)
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
        If Forces.Drag.Enabled Then
            For I = 0 To ObjectCount - 1
                If Objects(I).Affected Then
                    ReynoldsMultiplier = (Forces.Drag.Density * Objects(I).Radius * 2) / Forces.Drag.Viscosity
                    StokesDragConst = (6 * PI * Forces.Drag.Viscosity * Objects(I).Radius) / Objects(I).Mass
                    DragMultiplier = (0.5 * Forces.Drag.Density * Forces.Drag.DragCoeff * Math.PI * Objects(I).Radius * Objects(I).Radius) / Objects(I).Mass
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

        If Forces.Gravity Or Forces.ElectroStatic.Enabled Then
            '~~~~~~~~~~~~~OBJECT OBJECT FORCES~~~~~~~~~~~~~~
            For I = 0 To ObjectCount - 2
                For Q = I + 1 To ObjectCount - 1
                    If (Objects(I).Affected And Objects(Q).Affects) Or (Objects(Q).Affected And Objects(I).Affects) Then 'If the objects are allowed to interact

                        QtoIPosistion = (Objects(Q).Position - Objects(I).Position)
                        QtoIDistanceSqd = QtoIPosistion.MagnitudeSquared
                        QtoIDistance = Math.Sqrt(QtoIDistanceSqd)
                        Coeff = QtoIPosistion / QtoIDistance

                        '~~~~~~~~~~~~~NEWTONIAN GRAVITY~~~~~~~~~~~~~~
                        If Forces.Gravity Then
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
                        If Forces.ElectroStatic.Enabled Then
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
        If Settings.MaxCPS <> 0 Then
            QueryPerformanceCounter(CalcCounter.LimitStart)
            Do
                QueryPerformanceCounter(CalcCounter.LimitStop)
            Loop Until (CalcCounter.Frequency / (CalcCounter.LimitStop - CalcCounter.LimitStart)) < Settings.MaxCPS
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

                If Collisions.Interpolate Then

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
                        SyncLock LockRayData
                            Objects(i).Position = ((Objects(i).Position - Objects(i).OldPosition) * CollisionTime) + Objects(i).OldPosition
                            Objects(Q).Position = ((Objects(Q).Position - Objects(Q).OldPosition) * CollisionTime) + Objects(Q).OldPosition
                        End SyncLock
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
                If Collisions.CoR = 0 Then '~~~~~~~~~~~PLASTIC OBJECT OBJECT COLLISION~~~~~~~~~~~
                    NewVI = ((Objects(Q).Mass * VQ) + (VI * Objects(i).Mass)) / SumofMasses
                    Objects(i).Velocity.Copy(NewVI + (Objects(i).Velocity - VI))
                    Objects(Q).Velocity.Copy(NewVI + (Objects(Q).Velocity - VQ))
                ElseIf Collisions.CoR = 1 Then  '~~~~~~ELASTIC OBJECT OBJECT COLLISION~~~~~~~~~~~
                    TempDouble4 = Objects(i).Mass / SumofMasses
                    TempDouble5 = Objects(Q).Mass / SumofMasses
                    TempDouble = TempDouble4 - TempDouble5
                    Objects(i).Velocity += ((TempDouble5 + TempDouble5) * VQ) + (VI * (TempDouble - 1))
                    Objects(Q).Velocity += ((TempDouble4 + TempDouble4) * VI) - (VQ * (TempDouble + 1))
                Else '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~PARTIAL OBJECT OBJECT COLLISION~~~~~~~~~~~
                    TempDouble4 = Objects(i).Mass / SumofMasses
                    TempDouble5 = Objects(Q).Mass / SumofMasses
                    TempDouble3 = Collisions.CoR + 1
                    Objects(i).Velocity += (TempDouble3 * TempDouble5 * VQ) + (VI * (TempDouble4 - (Collisions.CoR * TempDouble5) - 1))
                    Objects(Q).Velocity += (TempDouble3 * TempDouble4 * VI) + (VQ * (TempDouble5 - (Collisions.CoR * TempDouble4) - 1))
                End If

                If Collisions.Interpolate Then
                    'Move the objects forward by the remaining time
                    SyncLock LockRayData
                        Objects(i).Position += Objects(i).Velocity * (Settings.TimeStep * (1 - CollisionTime))
                        Objects(Q).Position += Objects(Q).Velocity * (Settings.TimeStep * (1 - CollisionTime))
                    End SyncLock
                End If

                '~~~~~~~~~~~~~~BREAKABLE OBJECT OBJECT COLLISION~~~~~~~~~~~~
                If Not Collisions.Breakable Or ObjectCount >= Settings.MaxObjects Or Collisions.CoR = 1 Then Continue For

                DeltaKineticI = Math.Abs(VI.MagnitudeSquared + VQ.MagnitudeSquared - Objects(i).Velocity.MagnitudeSquared - Objects(Q).Velocity.MagnitudeSquared)
                DeltaKineticQ = DeltaKineticI
                DeltaKineticI *= Objects(i).Mass
                DeltaKineticQ *= Objects(Q).Mass

                'Determine if Q will break
                If DeltaKineticQ >= Collisions.BreakMax Then
                    DoBreak(Q)
                ElseIf DeltaKineticQ >= Collisions.BreakMin Then
                    If DeltaKineticQ = Collisions.BreakAvg Then
                        If RandMaker.GetNext() > 0.5 Then DoBreak(Q)
                    Else
                        If RandMaker.GetNext < RandMaker.GetProbibility(DeltaKineticQ, Collisions.BreakAvg, Collisions.BreakMin, Collisions.BreakMax) Then DoBreak(Q) 'Get probibility and compare it to a random number
                    End If
                End If

                'Determine if I will break
                If ObjectCount >= Settings.MaxObjects Then Continue For

                If DeltaKineticI >= Collisions.BreakMax Then
                    DoBreak(i)
                ElseIf DeltaKineticI >= Collisions.BreakMin Then
                    If DeltaKineticI = Collisions.BreakAvg Then
                        If RandMaker.GetNext() > 0.5 Then DoBreak(i)
                    Else
                        If RandMaker.GetNext < RandMaker.GetProbibility(DeltaKineticI, Collisions.BreakAvg, Collisions.BreakMin, Collisions.BreakMax) Then DoBreak(i) 'Get probibility and compare it to a random number
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub SetThreads(ByRef ComputeThreads As Integer, ByRef RenderThreads As Integer)
        If ComputeThreads > 0 Then
            ComputingThread = New Thread(AddressOf DoCompute)
            ComputingThread.IsBackground = True
            ComputingThread.Start()
        End If


        If Render.Mode < 2 Then
            ReDim RenderThread(0)
            RenderThread(0) = New Thread(AddressOf DoDXRender)
            RenderThread(0).IsBackground = True
            RenderThread(0).Start()
        Else
            ReDim RenderThread(RenderThreads - 1)
            For i = 0 To RenderThreads - 1
                RenderThread(i) = New Thread(AddressOf DoRayRender)
                RenderThread(i).IsBackground = True
                RenderThread(i).Start()
            Next
        End If
    End Sub
#End Region
#Region "Render"
    Private Sub RenderControl()
        RenderCounter.FullCount += 1
        'Limit the frame rate
        If Render.MaxFPS <> 0 And ((Render.Mode = 2) Or (Not Render.VSync)) Then
            QueryPerformanceCounter(RenderCounter.LimitStart)
            Do
                'TODO: Don't spin here, wait!
                QueryPerformanceCounter(RenderCounter.LimitStop)
            Loop Until (RenderCounter.Frequency / (RenderCounter.LimitStop - RenderCounter.LimitStart)) < Render.MaxFPS
        End If
    End Sub
    Private Function InitializeRender() As Boolean
        'Create the render device parameters
        Render.Parameters = New PresentParameters
        Render.Parameters.Windowed = True
        Render.Parameters.SwapEffect = SwapEffect.Discard
        Render.Parameters.EnableAutoDepthStencil = True
        Render.Parameters.AutoDepthStencilFormat = DepthFormat.D16

        'Set VSync
        If Render.Mode < 2 And Render.VSync Then
            Render.Parameters.PresentationInterval = PresentInterval.Default
        Else
            Render.Parameters.PresentationInterval = PresentInterval.Immediate
        End If

        'Create the Device
        If Render.Mode = 0 Then 'Hardware DirectX 9
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
        ElseIf Render.Mode = 1 Then 'Software DirectX 9
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

        If Render.Mode < 2 Then ' Using DirectX, not Raytracing
            'Initialize render settings
            Render.Device.RenderState.PointSize = 4
            Render.Device.RenderState.FillMode = FillMode.Solid
            Render.Device.RenderState.ZBufferEnable = True
            Render.Device.RenderState.FogEnable = False
            Render.Device.RenderState.CullMode = Cull.CounterClockwise
            Render.Device.RenderState.ShadeMode = Render.Shading

            Render.Device.RenderState.Lighting = True
            If Render.EnableLighting Then
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
                Render.Device.RenderState.SourceBlend = Microsoft.DirectX.Direct3D.Blend.SourceAlpha
                Render.Device.RenderState.DestinationBlend = Microsoft.DirectX.Direct3D.Blend.InvSourceAlpha
                Render.Device.RenderState.AlphaBlendEnable = True
            End If

            'Clear the device and paint the background
            Render.Device.Clear(Microsoft.DirectX.Direct3D.ClearFlags.ZBuffer, Render.BackgroundColor, 1, 0)
            Render.Device.Clear(Microsoft.DirectX.Direct3D.ClearFlags.Target, Render.BackgroundColor, 1, 0)

            'Calculate Sphere complexity
            Render.SphereComplexity2 = ToInt32((Render.SphereComplexity1 * 0.5) + 0.5)

            'Setup the view port
            Render.Device.Transform.Projection = Matrix.PerspectiveFovLH(Camera.HFov, Render.AspectRatio, 1 / (Render.Scale * 10), Render.Scale * 2000)
            Render.Device.Transform.View = Matrix.LookAtLH(Camera.Position.toVector3, Camera.Target.toVector3, Camera.U.toVector3)

            'Create object meshes and materials
            For i = 0 To ObjectCount - 1
                Objects(i).CreateMesh(Render.Device, Render.Scale, Render.SphereComplexity1, Render.SphereComplexity2)
                Objects(i).CreateMaterial()
            Next

            'Create the lights
            If Render.EnableLighting = True Then
                For i = 0 To LightCount - 1
                    Render.Device.Lights(i).Type = Lights(i).Type
                    Render.Device.Lights(i).Ambient = Lights(i).AmbientColor
                    Render.Device.Lights(i).Attenuation0 = Lights(i).AttenuationA
                    Render.Device.Lights(i).Attenuation1 = Lights(i).AttenuationB
                    Render.Device.Lights(i).Attenuation2 = Lights(i).AttenuationC
                    Render.Device.Lights(i).Falloff = Lights(i).Falloff
                    Render.Device.Lights(i).Diffuse = Lights(i).Color
                    Render.Device.Lights(i).Direction = Lights(i).Direction.toVector3
                    Render.Device.Lights(i).InnerConeAngle = Lights(i).InnerCone
                    Render.Device.Lights(i).OuterConeAngle = Lights(i).OuterCone
                    Render.Device.Lights(i).Range = Render.Scale * Lights(i).Range
                    Render.Device.Lights(i).Specular = Lights(i).SpecularColor
                    Render.Device.Lights(i).Position = (Render.Scale * Lights(i).Position).toVector3
                    Render.Device.Lights(i).Update()
                    Render.Device.Lights(i).Enabled = True
                Next
            End If
        Else ' Raytracing
            Render.Device.RenderState.SourceBlend = Microsoft.DirectX.Direct3D.Blend.SourceAlpha
            Render.Device.RenderState.DestinationBlend = Microsoft.DirectX.Direct3D.Blend.InvSourceAlpha
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
            Render.Device.Clear(Microsoft.DirectX.Direct3D.ClearFlags.ZBuffer, Render.BackgroundColor, 1, 0)

            If Camera.DidMove Then
                'Clear Traces regardless of Trace Display setting
                Render.Device.Clear(Microsoft.DirectX.Direct3D.ClearFlags.Target, Render.BackgroundColor, 1, 0)

                'Change the view port
                Render.Device.Transform.View = Matrix.LookAtLH(Camera.Position.toVector3, Camera.Target.toVector3, Camera.U.toVector3)
            Else
                'Clear Traces
                If Not Render.TraceObjects Then
                    Render.Device.Clear(Microsoft.DirectX.Direct3D.ClearFlags.Target, Render.BackgroundColor, 1, 0)
                End If
            End If

            SyncLock LockDX
                For i = 0 To ObjectCount - 1

                    'If the object doesn't exist create it on the fly
                    If Objects(i).Mesh = Nothing Then
                        Objects(i).CreateMesh(Render.Device, Render.Scale, Render.SphereComplexity1, Render.SphereComplexity2)
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
                            Render.Device.RenderState.CullMode = Microsoft.DirectX.Direct3D.Cull.Clockwise
                        Else
                            Render.Device.RenderState.CullMode = Microsoft.DirectX.Direct3D.Cull.CounterClockwise
                        End If
                    End If

                    'Draw the object in its place
                    Render.Device.Transform.World = Matrix.RotationX(ToSingle(Objects(i).Rotation.X)) * Matrix.RotationY(ToSingle(Objects(i).Rotation.Y)) * Matrix.RotationZ(ToSingle(Objects(i).Rotation.Z)) * Matrix.Translation(ToSingle(Render.Scale * Objects(i).Position.X), ToSingle(Render.Scale * Objects(i).Position.Y), ToSingle(Render.Scale * Objects(i).Position.Z))

                    Render.Device.Material = Objects(i).Material
                    Objects(i).Mesh.DrawSubset(0)
                Next
            End SyncLock

            'End the scene
            Render.Device.EndScene()
            Render.Device.Present()

            RenderControl()
        Loop
    End Sub
    Private Sub DoRayRender()
        'Data loaded from Simulation - static
        Dim RenderHeight As Integer = Render.Height
        Dim RenderWidth As Integer = Render.Width
        Dim CameraTarget As New XYZ(Camera.Target)
        Dim BackColor As Color = Render.BackgroundColor

        'Data loaded from Simulation - Dynamic
        Dim CameraScreenHunit As New XYZ
        Dim CameraScreenWUnit As New XYZ
        Dim CurrentObjectCount As Integer = 0
        Dim ObjectRadiusSqrd() As Double
        Dim ObjectPosition() As XYZ
        Dim ObjectColor() As Color
        Dim CameraPosition As New XYZ

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
        Dim PixelColor As New Color

        'Used in iterarting through each pixel
        Dim TargetPixel As New XYZ
        Dim CameraPositionToTarget As New XYZ
        Dim HalfRenderWidth As Double = RenderWidth / 2
        Dim HalfRenderHeight As Double = RenderWidth / 2
        Dim Temp As New XYZ

        'Load initial object values that otherwise only get loaded if a change is made to the objects
        SyncLock LockRayData
            CurrentObjectCount = ObjectCount
            ReDim CameratoObject(CurrentObjectCount - 1)
            ReDim CameratoObjectMagSqrd(CurrentObjectCount - 1)
            ReDim ObjectRadiusSqrd(CurrentObjectCount - 1)
            ReDim ObjectPosition(CurrentObjectCount - 1)
            ReDim ObjectColor(CurrentObjectCount - 1)
            For i = 0 To CurrentObjectCount - 1
                ObjectRadiusSqrd(i) = Objects(i).Radius * Objects(i).Radius
                ObjectColor(i) = Objects(i).Color
            Next
        End SyncLock

        'Make the Background Transparent so we can trace the object path
        If Render.TraceObjects = True Then
            Render.BackgroundColor = Color.FromArgb(0, Render.BackgroundColor.R, Render.BackgroundColor.G, Render.BackgroundColor.B)
        End If

        Do While Running

            'Load updated Values
            SyncLock LockRayData
                'Update the camera changes
                CameraScreenHunit = Camera.ScreenHeightUnit
                CameraScreenWUnit = Camera.ScreenWidthUnit
                CameraPosition = Camera.Position
                CameraPositionToTarget = Camera.Target - CameraPosition

                'If the objects didn't change then only update their position
                If CurrentObjectCount = ObjectCount Then
                    For i = 0 To CurrentObjectCount - 1
                        ObjectPosition(i) = Objects(i).Position
                        CameratoObject(i) = ObjectPosition(i) - CameraPosition
                        CameratoObjectMagSqrd(i) = CameratoObject(i).MagnitudeSquared
                    Next
                Else
                    CurrentObjectCount = ObjectCount
                    ReDim ObjectRadiusSqrd(CurrentObjectCount - 1)
                    ReDim ObjectPosition(CurrentObjectCount - 1)
                    ReDim ObjectColor(CurrentObjectCount - 1)
                    ReDim CameratoObject(CurrentObjectCount - 1)
                    ReDim CameratoObjectMagSqrd(CurrentObjectCount - 1)
                    For i = 0 To CurrentObjectCount - 1
                        ObjectPosition(i) = New XYZ(Objects(i).Position)
                        CameratoObject(i) = ObjectPosition(i) - CameraPosition
                        CameratoObjectMagSqrd(i) = CameratoObject(i).MagnitudeSquared
                        ObjectRadiusSqrd(i) = Objects(i).Radius * Objects(i).Radius
                        ObjectColor(i) = Objects(i).Color
                    Next
                End If
            End SyncLock

            'Reset the current pixel counter
            CurrentPixel = 0

            'For each pixel
            For Y = 0 To RenderHeight - 1
                Temp = ((HalfRenderHeight - Y) * CameraScreenHunit) + CameraPositionToTarget
                For X = 0 To Render.Width - 1
                    'Calculate the direction of the primary ray
                    RayDirection = ((HalfRenderWidth - X) * CameraScreenWUnit) + Temp
                    RayDirection.makeUnit()

                    'Get the color at the current pixel
                    PixelColor = TraceRay(CameraPosition, RayDirection, CurrentObjectCount, ObjectPosition, ObjectColor, CameratoObject, ObjectRadiusSqrd, CameratoObjectMagSqrd)

                    'Write the pixel to the pixel array
                    PixelData(CurrentPixel) = PixelColor.B
                    PixelData(CurrentPixel + 1) = PixelColor.G
                    PixelData(CurrentPixel + 2) = PixelColor.R
                    PixelData(CurrentPixel + 3) = PixelColor.A
                    CurrentPixel += 4
                Next
            Next

            'Draw the pixel array to the screen
            Stream = Texture.LockRectangle(0, Rect, LockFlags.None, Pitch)
            Stream.Write(PixelData, 0, PixelData.Length)
            Texture.UnlockRectangle(0)

            SyncLock LockRayMulti 'Make sure only one thread is using the device 
                Render.Device.BeginScene()
                If Camera.DidMove Then
                    Render.Device.Clear(ClearFlags.Target, BackColor, 1, 0)
                End If
                Sprite.Begin(SpriteFlags.AlphaBlend)
                Sprite.Draw2D(Texture, Rect, Size, Point, Color.White)
                Sprite.End()
                Render.Device.EndScene()
                Render.Device.Present()
            End SyncLock
            RenderControl()
        Loop

        'Reset the background color in case path tracing was used
        Render.BackgroundColor = Color.FromArgb(255, Render.BackgroundColor.R, Render.BackgroundColor.G, Render.BackgroundColor.B)
    End Sub
    Private Function TraceRay(ByRef RayPoint As XYZ, ByRef RayDirection As XYZ, ByRef CurrentObjectCount As Integer, ByRef ObjectPosition() As XYZ, ByRef ObjectColor() As Color, ByRef CameratoObject() As XYZ, ByRef ObjectRadiusSqrd() As Double, ByRef CameratoObjectMagSqrd() As Double) As Color
        Dim Ray_ObjectDistance As Double
        Dim Ray_ClosestObjectDistance As Double = Double.PositiveInfinity
        Dim Ray_ClosestObject As Integer = -1
        Dim Ray_PointNormal As New XYZ
        Dim Ray_tca As Double
        Dim Ray_thc As Double
        Dim Ray_OutsideObject As Boolean
        Dim Ray_ShadowDirection As XYZ
        Dim Ray_ShadowOrigin As XYZ
        Dim Ray_ShadowLength As Double
        Dim Ray_isinShadow As Boolean
        Dim Ray_LdotN As Double
        Dim Ray_Bias As Double = 0.001 * Render.Scale
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
            Return Render.BackgroundColor
        Else

            Ray_ShadowOrigin = RayPoint + (RayDirection * Ray_ClosestObjectDistance)
            If Ray_ClosestObject <> -2 Then
                Ray_PointNormal = Ray_ShadowOrigin - ObjectPosition(Ray_ClosestObject)
                Ray_PointNormal.makeUnit()
            End If


            'For each light in the scene
            For l = 0 To LightCount - 1
                If Lights(l).Type = LightType.Directional Then
                    Ray_ShadowDirection = -Lights(l).Direction
                Else
                    Ray_ShadowDirection = Lights(l).Position - Ray_ShadowOrigin
                End If

                Ray_ShadowLength = Ray_ShadowDirection.Magnitude
                Ray_ShadowDirection.makeUnit()
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
                Ray_colorR += Lights(l).AmbientColor.R * (Ray_ColorUsed.R * Byth)
                Ray_colorG += Lights(l).AmbientColor.G * (Ray_ColorUsed.G * Byth)
                Ray_colorB += Lights(l).AmbientColor.B * (Ray_ColorUsed.B * Byth)

                If Not Ray_isinShadow Then
                    'Add direct lighting for this light

                    If Lights(l).Type = LightType.Point Then
                        Ray_attn = 1 / (Lights(l).AttenuationA + (Ray_ShadowLength * (Lights(l).AttenuationB + (Lights(l).AttenuationC * Ray_ShadowLength))))
                        Ray_spot = 1
                    ElseIf Lights(l).Type = LightType.Spot Then
                        Ray_attn = 1 / (Lights(l).AttenuationA + (Ray_ShadowLength * (Lights(l).AttenuationB + (Lights(l).AttenuationC * Ray_ShadowLength))))
                        Ray_rho = Lights(l).Direction.Dot(-Ray_ShadowDirection)
                        Ray_cosout = Cos(Lights(l).OuterCone * 0.5)
                        Ray_cosin = Cos(Lights(l).InnerCone * 0.5)
                        If Ray_rho > Ray_cosin Then
                            Ray_spot = 1
                        ElseIf (Ray_rho <= Ray_cosout) Then
                            Ray_spot = 0
                        Else
                            Ray_spot = ((Ray_rho - Ray_cosout) / (Ray_cosin - Ray_cosout)) ^ Lights(l).Falloff
                        End If
                    Else
                        Ray_attn = 1
                        Ray_spot = 1
                    End If
                    Ray_attn *= Byth * Ray_LdotN * Ray_spot
                    Ray_colorR += (Ray_attn * Ray_ColorUsed.R) * Lights(l).Color.R
                    Ray_colorG += (Ray_attn * Ray_ColorUsed.G) * Lights(l).Color.G
                    Ray_colorB += (Ray_attn * Ray_ColorUsed.B) * Lights(l).Color.B
                End If
            Next

            'Cap the components at 255
            Return Color.FromArgb(255, Min(ToInt32(Ray_colorR), 255), Min(ToInt32(Ray_colorG), 255), Min(ToInt32(Ray_colorB), 255))

        End If
    End Function
    Private Function GetNormalColor(ByRef ColorMin As Color, ByRef ColorAvg As Color, ByRef ColorMax As Color) As Color
        Dim ran As Double
        ran = RandMaker.GetNext
        If ran = 0.5 Then
            Return ColorAvg
        ElseIf ran < 0.5 Then
            Return BlendColors(ColorMin, ColorAvg, RandMaker.GetNextNormal() / 2)
        Else
            Return BlendColors(ColorMax, ColorAvg, RandMaker.GetNextNormal() / 2)
        End If
    End Function
    Private Function BlendColors(ByRef Color1 As Color, ByRef Color2 As Color, ByVal Factor As Double) As Color
        'Factor is the percentage of the first color that is used in the blend
        If Factor < 0 Then Factor = 0 - Factor
        If Factor > 1 Then Factor = 1
        Return Color.FromArgb(ToByte((Color1.A * Factor) + ((1 - Factor) * Color2.R)), ToByte((Color1.R * Factor) + ((1 - Factor) * Color2.R)), ToByte((Color1.G * Factor) + ((1 - Factor) * Color2.G)), ToByte((Color1.B * Factor) + ((1 - Factor) * Color2.B)))
    End Function
    Private Function GetPolyColor(ByRef ColorA As Color, ByRef ColorB As Color, ByRef ColorC As Color, ByRef Current As Integer) As Color
        Dim F1, F2, Tot As Double
        If Current = 0 Then
            Return ColorC
        Else
            F1 = Current * Current
            F2 = Current
            Tot = F1 + F2 + 1
            F1 /= Tot
            F2 /= Tot
            Return BlendColors(BlendColors(ColorA, ColorB, F1 / (F1 + F2)), ColorC, F1 + F2)
        End If
    End Function
#End Region


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
