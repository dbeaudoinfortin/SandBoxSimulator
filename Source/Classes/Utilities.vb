Imports System.Windows.Forms

Public Enum ObjectType
    Sphere
    Box
    InfinitePlane
End Enum
Public Enum TargetType
    Text
    Color
    TrackBar
    Number
End Enum

Module Utilities
    Public Function GetValue(ByVal InText As String, ByVal CheckText As String) As String
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
        If Value = True Then
            pl.Enabled = True
            pl.BackColor = Color.FromArgb(255, pl.BackColor.R, pl.BackColor.G, pl.BackColor.B)
        ElseIf Value = False Then
            pl.Enabled = False
            pl.BackColor = Color.FromArgb(75, pl.BackColor.R, pl.BackColor.G, pl.BackColor.B)
        End If
    End Sub
    'Performance Counter
    Public Declare Function QueryPerformanceCounter Lib "Kernel32" (ByRef X As Long) As Short
    Public Declare Function QueryPerformanceFrequency Lib "Kernel32" (ByRef X As Long) As Short

    'Globlal Constants
    Public Const G As Double = 6.67428 * (10 ^ -11)
    Public Const Eo As Double = 8.854187817 * (10 ^ -12)
    Public Const Byth As Double = 1 / 255
    Public Const Byth2 As Double = 1 / (255 * 255)


    'Global Simulation Object and flags
    Public Simulation As SimulationData
    Public Backup As SimulationData
    Public ConfigModified As Boolean = False

    'Global CPU properties
    Public BeenWarned As Boolean = False
    Public CPUNumber As Integer

End Module
