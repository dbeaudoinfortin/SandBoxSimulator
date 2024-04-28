Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Structure SimulationConfigElectroStatic
    Public Enabled As Boolean
    Public Permittivity As Double
    Public Overloads Sub ToString(stringBuilder As StringBuilder, tabs As String)
        stringBuilder.Append(tabs)
        stringBuilder.Append("<Enabled>")
        stringBuilder.Append(Enabled.ToString())
        stringBuilder.AppendLine("</Enabled>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Permittivity>")
        stringBuilder.Append(Permittivity.ToString())
        stringBuilder.AppendLine("</Permittivity>")
    End Sub

    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder, "")
        Return stringBuilder.ToString
    End Function

    Public Sub Load(ByRef intext As String)
        Dim Result As String
        Result = GetXMLNodeValue(intext, "Enabled")
        If Result <> "" Then
            Enabled = ToBoolean(Result)
        Else
            Enabled = False
        End If

        Result = GetXMLNodeValue(intext, "Permittivity")
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
    Public Sub Copy(ByRef Other As SimulationConfigElectroStatic)
        Enabled = Other.Enabled
        Permittivity = Other.Permittivity
    End Sub
End Structure
