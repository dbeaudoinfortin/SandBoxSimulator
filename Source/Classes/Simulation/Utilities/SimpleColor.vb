'A simpler version of System.Drawing.color that avoid type conversions
Imports SharpDX.Mathematics.Interop

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

    Public Function ToColor() As Color
        Return Color.FromArgb(A, R, G, B)
    End Function

    Public Function ToRawColor4() As RawColor4
        Return New RawColor4(R * BythSingle, G * BythSingle, B * BythSingle, A * BythSingle)
    End Function
End Structure
