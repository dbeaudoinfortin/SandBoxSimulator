Imports System.Text

Public Structure SimulationField
    Public Enabled As Boolean
    Public Acceleration As XYZ
    Public Overloads Sub ToString(stringBuilder As StringBuilder, tabs As String)
        stringBuilder.Append(tabs)
        stringBuilder.Append("<Enabled>")
        stringBuilder.Append(Enabled.ToString())
        stringBuilder.AppendLine("</Enabled>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Acceleration>")
        Acceleration.ToString(stringBuilder, tabs & Constants.vbTab)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Acceleration>")
    End Sub

    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder, "")
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

        Result = GetValue(intext, "Acceleration")
        If Result <> "" Then
            Acceleration.Load(Result)
        Else
            Acceleration = New XYZ(0, 0, 0)
        End If
    End Sub
    Public Sub Clear()
        Enabled = False
        Acceleration = New XYZ(0, 0, 0)
    End Sub
    Public Sub Copy(ByRef Other As SimulationField)
        Enabled = Other.Enabled
        Acceleration.Copy(Other.Acceleration)
    End Sub
End Structure