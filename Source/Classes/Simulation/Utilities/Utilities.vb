Imports System.Windows.Forms
Imports SharpDX.Mathematics.Interop

Module Utilities
    'Performance Counter
    Public Declare Function QueryPerformanceCounter Lib "Kernel32" (ByRef X As Long) As Short
    Public Declare Function QueryPerformanceFrequency Lib "Kernel32" (ByRef X As Long) As Short

    'Globlal Constants
    Public Const G As Double = 6.67428 * (10 ^ -11)
    Public Const Eo As Double = 8.854187817 * (10 ^ -12)

    Public Const MaxByte As Byte = 255
    Public Const MaxByteD As Double = 255D

    Public Const Byth As Double = 1D / MaxByteD
    Public Const Byth2 As Double = 1D / (MaxByteD * MaxByteD)
    Public Const BythSingle As Single = 1.0F / MaxByte

    'Global Simulation Object and flags
    Public Simulation As SimulationRuntime
    Public Backup As SimulationRuntime
    Public ConfigModified As Boolean = False

    'Global CPU properties
    Public CPUNumber As Integer

    Public Function GetXMLNodeValue(ByVal inText As String, ByVal checkText As String) As String
        Try
            Dim i As Integer
            Dim StartPos As Integer
            Dim EnQtoIPosistion As Integer

            For i = 1 To Len(inText)
                If UCase(Mid(inText, i, Len("<" & checkText & ">"))) = UCase("<" & checkText & ">") Then
                    StartPos = i + Len("<" & checkText & ">")
                ElseIf UCase(Mid(inText, i, Len("</" & checkText & ">"))) = UCase("</" & checkText & ">") Then
                    EnQtoIPosistion = i - 1
                    Return Mid(inText, StartPos, EnQtoIPosistion - StartPos + 1)
                End If
            Next
        Catch
            Return ""
        End Try
        Return ""

    End Function
    Public Sub EnableColorBox(ByRef pl As Button, ByRef value As Boolean)
        pl.Enabled = value
        If value Then
            pl.BackColor = Color.FromArgb(255, pl.BackColor.R, pl.BackColor.G, pl.BackColor.B)
        Else
            pl.BackColor = Color.FromArgb(75, pl.BackColor.R, pl.BackColor.G, pl.BackColor.B)
        End If
    End Sub
    Public Function BlendColors(ByRef color1 As Color, ByRef color2 As Color, ByVal factor As Double) As Color
        'Factor is the percentage of the first color that is used in the blend
        If factor < 0 Then factor = 0 - factor
        If factor > 1 Then factor = 1
        Return Color.FromArgb(ToByte((color1.A * factor) + ((1 - factor) * color2.R)), ToByte((color1.R * factor) + ((1 - factor) * color2.R)), ToByte((color1.G * factor) + ((1 - factor) * color2.G)), ToByte((color1.B * factor) + ((1 - factor) * color2.B)))
    End Function

    Public Function ConvertColorToRawColorBGRA(color As Color) As RawColorBGRA
        Return New RawColorBGRA(color.B, color.G, color.R, color.A)
    End Function

    Public Function ConvertColorToRawColor4(color As Color) As RawColor4
        Return New RawColor4(color.R * BythSingle, color.G * BythSingle, color.B * BythSingle, color.A * BythSingle)
    End Function

    Public Function ConvertRawColorBGRAToColor(bgraColor As RawColorBGRA) As Color
        Return Color.FromArgb(bgraColor.A, bgraColor.R, bgraColor.G, bgraColor.B)
    End Function

End Module
Public Enum ObjectType
    Sphere
    Box
    Plane
    InfinitePlane
End Enum
Public Enum TargetType
    Numeric
    Color
    TrackBar
    ObjectCount
End Enum
