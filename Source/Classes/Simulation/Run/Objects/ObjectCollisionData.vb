Public Class ObjectCollisionData
    'Pre-calculated object collision data
    Public ReadOnly RotationMatrix As Matrix3x3
    Public ReadOnly RotationMatrixTranpose As Matrix3x3
    Public Sub New(ByRef Rotation As XYZ)
        ' Calculate rotation matrix of the object
        RotationMatrix = Matrix3x3.CreateFromYawPitchRoll(Rotation)
        RotationMatrixTranpose = RotationMatrix.Transpose
    End Sub
End Class
