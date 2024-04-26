Imports System.Text

Public Structure SimulationCamera
    Private TargetToPosition As XYZ

    'Spherical Coordinates
    Private Latitude As Double
    Private Longitude As Double
    Public Radius As Double

    'Flags
    Public MoveBack As Boolean
    Public MoveFront As Boolean
    Public MoveUp As Boolean
    Public MoveDown As Boolean
    Public MoveLeft As Boolean
    Public MoveRight As Boolean
    Public DidMove As Boolean

    'Cartesan Coordinates
    Public Target As XYZ
    Public Position As XYZ

    'Rotation Vectors
    Public U As XYZ     'Up Vector
    Private V As XYZ    'Left Vector
    Private N As XYZ    'Target vector

    'Movement
    Public MoveSpeed As Double
    Private FSpeed As Double
    Private Bspeed As Double
    Private MinDistance As Double
    Private MaxDistance As Double

    'Ray Tracing
    Public Raytraced As Boolean
    Public ScreenHeightUnit As XYZ      'Only used in Raytracing
    Public ScreenWidthUnit As XYZ       'Only used in Raytracing
    Private ScreenTempW As Double           'Only used in Raytracing
    Private ScreenTempH As Double           'Only used in Raytracing

    'Field of View
    Public VFov As Single               'Only used in Raytracing
    Public HFov As Single

    'Use default values
    Public AllowModification As Boolean
    Public Sub Move()
        'Reset camera movement flag
        DidMove = False

        'Forward or backwards
        If MoveBack Xor MoveFront Then
            If MoveFront Then
                Radius *= FSpeed
                If Radius > MaxDistance Then
                    Radius = MaxDistance
                End If
            Else
                Radius *= Bspeed
                If Radius < MinDistance Then
                    Radius = MinDistance
                End If
            End If
            DidMove = True
        End If

        If MoveUp Xor MoveDown Then
            If MoveDown = True Then
                N -= U * MoveSpeed
            Else
                N += U * MoveSpeed
            End If
            DidMove = True
        End If

        If MoveLeft Xor MoveRight Then
            If MoveLeft = True Then
                N += V * MoveSpeed
            Else
                N -= V * MoveSpeed
            End If
            DidMove = True
        End If

        'If there were any changes
        If DidMove = True Then
            V = U.Cross(N)
            U = N.Cross(V)
            N.makeUnit()
            U.makeUnit()
            V.makeUnit()
            'Calculate the camera posistion relative to the center of the sphere
            TargetToPosition = N * Radius
            'Make the camera position relative to the world cooridinate system
            Position = Target + TargetToPosition
            If Raytraced Then  'Using Raytracing
                ScreenWidthUnit = (ScreenTempW * Radius) * V
                ScreenHeightUnit = (ScreenTempH * Radius) * U
            End If
        End If
    End Sub
    Public Sub Intitialize(ByRef ScreenWidth As Integer, ByRef ScreenHeight As Integer, ByRef Scale As Single)
        'Calculate the initial vector from the camera position to its target
        TargetToPosition = Position - Target

        'Speed and travel distance
        MaxDistance = 1000
        MinDistance = 0.0005
        FSpeed = 1 + (0.1 * MoveSpeed)
        Bspeed = 1 - (0.1 * MoveSpeed)

        'Find the coordinate system that defines the sphere of movement
        U.makeUnit()
        N = TargetToPosition.getUnit()
        V = U.Cross(N)

        'Find current position in spherical coordinates by projecting PositionToTarget vector onto the
        'coordinate system and using trig to solve for the angles.
        Radius = TargetToPosition.Magnitude
        Latitude = Acos(TargetToPosition.Dot(U) / Radius) - (PI / 2)
        Longitude = Atan2(-TargetToPosition.Dot(N), -TargetToPosition.Dot(V))

        'Reset the movements flags
        MoveBack = False
        MoveFront = False
        MoveUp = False
        MoveDown = False
        MoveRight = False
        MoveLeft = False

        ScreenTempW = (Tan(HFov * 0.5) * 2) / ScreenWidth
        ScreenTempH = (Tan(VFov * 0.5) * 2) / ScreenHeight
        ScreenWidthUnit = (ScreenTempW * Radius) * V
        ScreenHeightUnit = (ScreenTempH * Radius) * U
    End Sub
    Public Overloads Sub ToString(stringBuilder As StringBuilder)

        stringBuilder.AppendLine("<Position>")
        Position.ToString(stringBuilder)
        stringBuilder.Append("</Position>")

        stringBuilder.AppendLine("<Target>")
        Target.ToString(stringBuilder)
        stringBuilder.Append("</Target>")

        stringBuilder.AppendLine("<Up>")
        U.ToString(stringBuilder)
        stringBuilder.Append("</Up>")

        stringBuilder.AppendLine("<HFov>")
        stringBuilder.Append(HFov.ToString)
        stringBuilder.Append("</HFov>")

        stringBuilder.AppendLine("<VFov>")
        stringBuilder.Append(VFov.ToString)
        stringBuilder.Append("</VFov>")

        stringBuilder.AppendLine("<MoveSpeed>")
        stringBuilder.Append(MoveSpeed.ToString())
        stringBuilder.Append("</MoveSpeed>")

        stringBuilder.AppendLine("<AllowModification>")
        stringBuilder.Append(AllowModification.ToString())
        stringBuilder.Append("</AllowModification>")

    End Sub

    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder)
        Return stringBuilder.ToString
    End Function

    Public Sub Load(ByRef intext As String)
        Dim Result As String

        Result = GetValue(intext, "HFov")
        If Result <> "" And IsNumeric(Result) Then
            HFov = ToSingle(Result)
        Else
            HFov = PI / 4
        End If

        Result = GetValue(intext, "VFov")
        If Result <> "" And IsNumeric(Result) Then
            VFov = ToSingle(Result)
        Else
            VFov = PI / 4
        End If

        Result = GetValue(intext, "MoveSpeed")
        If Result <> "" And IsNumeric(Result) Then
            MoveSpeed = ToDouble(Result)
        Else
            MoveSpeed = 0.2
        End If

        Result = GetValue(intext, "AllowModification")
        If Result <> "" Then
            AllowModification = ToBoolean(Result)
        Else
            AllowModification = False
        End If

        Result = GetValue(intext, "Position")
        If Result <> "" Then
            Position.Load(Result)
        Else
            Position = New XYZ(0, 0, 0)
        End If

        Result = GetValue(intext, "Target")
        If Result <> "" Then
            Target.Load(Result)
        Else
            Target = New XYZ(0, 0, 0)
        End If

        Result = GetValue(intext, "Up")
        If Result <> "" Then
            U.Load(Result)
        Else
            U = New XYZ(0, 1, 0)
        End If
    End Sub
    Public Sub Clear()
        AllowModification = False
        MoveSpeed = 0.2
        HFov = PI / 4
        VFov = PI / 4
        U = New XYZ(0, 1, 0)
        Position = New XYZ(0, 0, -10)
        Target = New XYZ(0, 0, 0)
        Raytraced = False
    End Sub
    Public Sub Copy(ByRef Other As SimulationCamera)
        Radius = Other.Radius
        MoveBack = Other.MoveBack
        MoveFront = Other.MoveFront
        MoveUp = Other.MoveUp
        MoveDown = Other.MoveDown
        MoveLeft = Other.MoveLeft
        MoveRight = Other.MoveRight
        DidMove = Other.DidMove
        Target.Copy(Other.Target)
        Position.Copy(Other.Position)
        U.Copy(Other.U)
        MoveSpeed = Other.MoveSpeed
        Raytraced = Other.Raytraced
        ScreenHeightUnit = Other.ScreenHeightUnit
        ScreenWidthUnit = Other.ScreenWidthUnit
        VFov = Other.VFov
        HFov = Other.HFov
        AllowModification = Other.AllowModification
    End Sub
End Structure
