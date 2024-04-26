Imports System.Text

Public Structure SimulationElectroStatic
    Public Enabled As Boolean
    Public Permittivity As Double
    Public Overloads Sub ToString(stringBuilder As StringBuilder)
        stringBuilder.AppendLine("<Enabled>")
        stringBuilder.Append(Enabled.ToString())
        stringBuilder.Append("</Enabled>")

        stringBuilder.AppendLine("<Permittivity>")
        stringBuilder.Append(Permittivity.ToString())
        stringBuilder.Append("</Permittivity>")
    End Sub

    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder)
        Return stringBuilder.ToString
    End Function

    Public Sub Load(ByRef intext As String)
        Dim Result As String
        Result = GetValue(intext, "Enabled")
        If Result <> "" Then
            Enabled = ToBoolean(Result)
        Else
            Enabled = False
        End If

        Result = GetValue(intext, "Permittivity")
        If Result <> "" And IsNumeric(Result) Then
            Permittivity = ToDouble(Result)
        Else
            Permittivity = 1.0006
        End If
    End Sub
    Public Sub Clear()
        Enabled = False
        Permittivity = 1.0006
    End Sub
    Public Sub Copy(ByRef Other As SimulationElectroStatic)
        Enabled = Other.Enabled
        Permittivity = Other.Permittivity
    End Sub
End Structure
