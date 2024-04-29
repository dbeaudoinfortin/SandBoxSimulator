Imports System.Windows.Forms



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


    'Global Simulation Object and flags
    Public Simulation As SimulationRuntime
    Public Backup As SimulationRuntime
    Public ConfigModified As Boolean = False

    'Global CPU properties
    Public BeenWarned As Boolean = False
    Public CPUNumber As Integer

    Public Function GetXMLNodeValue(ByVal InText As String, ByVal CheckText As String) As String
        Try
            Dim i As Integer
            Dim StartPos As Integer
            Dim EnQtoIPosistion As Integer

            For i = 1 To Len(InText)
                If UCase(Mid(InText, i, Len("<" & CheckText & ">"))) = UCase("<" & CheckText & ">") Then
                    StartPos = i + Len("<" & CheckText & ">")
                ElseIf UCase(Mid(InText, i, Len("</" & CheckText & ">"))) = UCase("</" & CheckText & ">") Then
                    EnQtoIPosistion = i - 1
                    Return Mid(InText, StartPos, EnQtoIPosistion - StartPos + 1)
                End If
            Next
        Catch
            Return ""
        End Try
        Return ""

    End Function
    Public Sub EnableColorBox(ByRef pl As Button, ByRef Value As Boolean)
        pl.Enabled = Value
        If Value Then
            pl.BackColor = Color.FromArgb(255, pl.BackColor.R, pl.BackColor.G, pl.BackColor.B)
        Else
            pl.BackColor = Color.FromArgb(75, pl.BackColor.R, pl.BackColor.G, pl.BackColor.B)
        End If
    End Sub
    Public Function BlendColors(ByRef Color1 As Color, ByRef Color2 As Color, ByVal Factor As Double) As Color
        'Factor is the percentage of the first color that is used in the blend
        If Factor < 0 Then Factor = 0 - Factor
        If Factor > 1 Then Factor = 1
        Return Color.FromArgb(ToByte((Color1.A * Factor) + ((1 - Factor) * Color2.R)), ToByte((Color1.R * Factor) + ((1 - Factor) * Color2.R)), ToByte((Color1.G * Factor) + ((1 - Factor) * Color2.G)), ToByte((Color1.B * Factor) + ((1 - Factor) * Color2.B)))
    End Function

End Module
Public Enum ObjectType
    Sphere
    Box
    InfinitePlane
End Enum
Public Enum TargetType
    Numeric
    Color
    TrackBar
    ObjectCount
End Enum
