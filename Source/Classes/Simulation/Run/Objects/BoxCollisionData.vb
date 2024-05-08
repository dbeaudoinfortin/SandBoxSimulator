Public Class BoxCollisionData
    Inherits ObjectCollisionData

    Public Shared ReadOnly FrontPlaneNormal As New XYZ(0, 0, -1)
    Public Shared ReadOnly BackPlaneNormal As New XYZ(0, 0, 1)
    Public Shared ReadOnly TopPlaneNormal As New XYZ(0, 1, 0)
    Public Shared ReadOnly BottomPlaneNormal As New XYZ(0, -1, 0)
    Public Shared ReadOnly LeftPlaneNormal As New XYZ(-1, 0, 0)
    Public Shared ReadOnly RightPlaneNormal As New XYZ(1, 0, 0)

    Public ReadOnly FrontPlaneNormalRotated As XYZ
    Public ReadOnly BackPlaneNormalRotated As XYZ
    Public ReadOnly TopPlaneNormalRotated As XYZ
    Public ReadOnly BottomPlaneNormalRotated As XYZ
    Public ReadOnly LeftPlaneNormalRotated As XYZ
    Public ReadOnly RightPlaneNormalRotated As XYZ

    Public ReadOnly FrontPlaneCenterRotated As XYZ
    Public ReadOnly BackPlaneCenterRotated As XYZ
    Public ReadOnly TopPlaneCenterRotated As XYZ
    Public ReadOnly BottomPlaneCenterRotated As XYZ
    Public ReadOnly LeftPlaneCenterRotated As XYZ
    Public ReadOnly RightPlaneCenterRotated As XYZ

    Public ReadOnly FrontPlaneLimits As XYZ
    Public ReadOnly BackPlaneLimits As XYZ
    Public ReadOnly TopPlaneLimits As XYZ
    Public ReadOnly BottomPlaneLimits As XYZ
    Public ReadOnly LeftPlaneLimits As XYZ
    Public ReadOnly RightPlaneLimits As XYZ

    Public Sub New(ByRef Rotation As XYZ, ByRef HalfSize As XYZ)
        MyBase.New(Rotation)

        'First treat the box as aligned with the coordinate system
        'Then Rotate the plane to the correct orientation
        TopPlaneNormalRotated = TopPlaneNormal.NewRotated(RotationMatrix)
        BottomPlaneNormalRotated = BottomPlaneNormal.NewRotated(RotationMatrix)

        FrontPlaneNormalRotated = FrontPlaneNormal.NewRotated(RotationMatrix)
        BackPlaneNormalRotated = BackPlaneNormal.NewRotated(RotationMatrix)

        LeftPlaneNormalRotated = LeftPlaneNormal.NewRotated(RotationMatrix)
        RightPlaneNormalRotated = RightPlaneNormal.NewRotated(RotationMatrix)

        FrontPlaneCenterRotated = (FrontPlaneNormal * HalfSize).NewRotated(RotationMatrix)
        BackPlaneCenterRotated = (BackPlaneNormal * HalfSize).NewRotated(RotationMatrix)

        TopPlaneCenterRotated = (TopPlaneNormal * HalfSize).NewRotated(RotationMatrix)
        BottomPlaneCenterRotated = (BottomPlaneNormal * HalfSize).NewRotated(RotationMatrix)

        LeftPlaneCenterRotated = (LeftPlaneNormal * HalfSize).NewRotated(RotationMatrix)
        RightPlaneCenterRotated = (RightPlaneNormal * HalfSize).NewRotated(RotationMatrix)

        FrontPlaneLimits = New XYZ(HalfSize.X, HalfSize.Y, Double.MaxValue)
        BackPlaneLimits = FrontPlaneLimits

        TopPlaneLimits = New XYZ(HalfSize.X, Double.MaxValue, HalfSize.Z)
        BottomPlaneLimits = TopPlaneLimits

        LeftPlaneLimits = New XYZ(Double.MaxValue, HalfSize.Y, HalfSize.Z)
        RightPlaneLimits = LeftPlaneLimits
    End Sub


End Class
