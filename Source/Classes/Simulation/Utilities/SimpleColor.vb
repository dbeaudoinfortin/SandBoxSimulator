'A simpler version of System.Drawing.color that avoid type conversions
Public Structure SimpleColor
    Public A As Byte
    Public R As Byte
    Public G As Byte
    Public B As Byte

    Public Sub FromArgb(A As Byte, R As Byte, G As Byte, B As Byte)
        Me.A = A
        Me.R = R
        Me.G = G
        Me.B = B
    End Sub

    Public Sub FromColor(color As Color)
        Me.A = color.A
        Me.R = color.R
        Me.G = color.G
        Me.B = color.B
    End Sub

End Structure
