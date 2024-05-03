Public Structure Matrix3x3
    Public M11, M12, M13 As Double
    Public M21, M22, M23 As Double
    Public M31, M32, M33 As Double

    Public Sub New(m11 As Double, m12 As Double, m13 As Double, m21 As Double, m22 As Double, m23 As Double, m31 As Double, m32 As Double, m33 As Double)
        Me.M11 = m11
        Me.M12 = m12
        Me.M13 = m13
        Me.M21 = m21
        Me.M22 = m22
        Me.M23 = m23
        Me.M31 = m31
        Me.M32 = m32
        Me.M33 = m33
    End Sub

    Public Shared Function CreateFromYawPitchRoll(ByRef Rotation As XYZ) As Matrix3x3
        Return CreateFromYawPitchRoll(Rotation.X, Rotation.Y, Rotation.Z)
    End Function
    Public Shared Function CreateFromYawPitchRoll(ByRef yaw As Double, ByRef pitch As Double, ByRef roll As Double) As Matrix3x3
        Dim cYaw As Double = Math.Cos(yaw)
        Dim sYaw As Double = Math.Sin(yaw)
        Dim cPitch As Double = Math.Cos(pitch)
        Dim sPitch As Double = Math.Sin(pitch)
        Dim cRoll As Double = Math.Cos(roll)
        Dim sRoll As Double = Math.Sin(roll)


        Dim m11 As Double = cYaw * cRoll + sYaw * sPitch * sRoll
        Dim m12 As Double = sRoll * cPitch
        Dim m13 As Double = -sYaw * cRoll + cYaw * sPitch * sRoll

        Dim m21 As Double = -cYaw * sRoll + sYaw * sPitch * cRoll
        Dim m22 As Double = cRoll * cPitch
        Dim m23 As Double = sRoll * sYaw + cYaw * sPitch * cRoll

        Dim m31 As Double = sYaw * cPitch
        Dim m32 As Double = -sPitch
        Dim m33 As Double = cYaw * cPitch

        Return New Matrix3x3(m11, m12, m13, m21, m22, m23, m31, m32, m33)
    End Function

    Public Function Transpose() As Matrix3x3
        ' Swap rows and columns
        Return New Matrix3x3(M11, M21, M31, M12, M22, M32, M13, M23, M33)
    End Function
End Structure
