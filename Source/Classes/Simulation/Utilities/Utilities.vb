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
    Plane
    InfinitePlane
End Enum
Public Enum TargetType
    Numeric
    Color
    TrackBar
    ObjectCount
End Enum

Public Class Matrix3x3
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

    Public Shared Function CreateFromYawPitchRoll(yaw As Double, pitch As Double, roll As Double) As Matrix3x3
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
End Class
