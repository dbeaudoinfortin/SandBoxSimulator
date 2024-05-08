Public Class PlaneCollisionData
    Inherits ObjectCollisionData

    Public Shared ReadOnly Normal As New XYZ(0, 0, -1)
    Public ReadOnly NormalRotated As XYZ
    Public ReadOnly CenterRotated As XYZ
    Public ReadOnly Limits As XYZ

    Public Sub New(ByRef Rotation As XYZ, ByRef HalfSize As XYZ)
        MyBase.New(Rotation)
        NormalRotated = Normal.NewRotated(RotationMatrix)
        CenterRotated = (Normal * HalfSize).NewRotated(RotationMatrix)
        Limits = New XYZ(HalfSize.X, Double.MaxValue, HalfSize.Z)
    End Sub
End Class
