Imports System.Text

Public Structure SimulationCamera
    Private TargetToPosition As XYZ

    'Spherical Coordinates
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
            N.MakeUnit()
            U.MakeUnit()
            V.MakeUnit()
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
    Public Sub Intitialize(ByRef Config As SimulationConfigCamera, ByRef ScreenWidth As Integer, ByRef ScreenHeight As Integer, isRaytraced As Boolean)

        Raytraced = isRaytraced

        'Calculate the initial vector from the camera position to its target
        Target = New XYZ(Config.Target)
        Position = New XYZ(Config.Position)
        TargetToPosition = Position - Target

        'Speed and travel distance
        MoveSpeed = Config.MoveSpeed
        MaxDistance = 1000
        MinDistance = 0.0005
        FSpeed = 1 + (0.1 * MoveSpeed)
        Bspeed = 1 - (0.1 * MoveSpeed)

        'Find the coordinate system that defines the sphere of movement
        U = Config.UpVector.GetNewUnit()
        N = TargetToPosition.GetNewUnit()
        V = U.Cross(N)

        Radius = TargetToPosition.Magnitude

        'Reset the movements flags
        MoveBack = False
        MoveFront = False
        MoveUp = False
        MoveDown = False
        MoveRight = False
        MoveLeft = False

        ScreenTempW = (Tan(Config.HFov * 0.5) * 2) / ScreenWidth
        ScreenTempH = (Tan(Config.VFov * 0.5) * 2) / ScreenHeight
        ScreenWidthUnit = (ScreenTempW * Radius) * V
        ScreenHeightUnit = (ScreenTempH * Radius) * U
    End Sub
End Structure
