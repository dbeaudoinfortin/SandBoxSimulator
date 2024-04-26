Imports System.Text

Public Class GroupOptionsXYZ
    Public X As GroupOptions(Of Double) = New GroupOptionsDouble
    Public Y As GroupOptions(Of Double) = New GroupOptionsDouble
    Public Z As GroupOptions(Of Double) = New GroupOptionsDouble
    Public Overloads Sub ToString(stringBuilder As StringBuilder)

        stringBuilder.AppendLine("<X>")
        X.ToString(stringBuilder)
        stringBuilder.Append("</X>")

        stringBuilder.AppendLine("<Y>")
        Y.ToString(stringBuilder)
        stringBuilder.Append("</Y>")

        stringBuilder.AppendLine("<Z>")
        Z.ToString(stringBuilder)
        stringBuilder.Append("</Z>")
    End Sub

    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder)
        Return stringBuilder.ToString
    End Function

    Public Sub Copy(ByRef Other As GroupOptionsXYZ)
        X.Copy(Other.X)
        Y.Copy(Other.Y)
        Z.Copy(Other.Z)
    End Sub

    Public Sub Load(ByRef intext As String)
        Dim Result As String

        Result = GetValue(intext, "X")
        If Result <> "" Then
            X.Load(Result)
        Else
            X = New GroupOptionsDouble
        End If

        Result = GetValue(intext, "Y")
        If Result <> "" Then
            Y.Load(Result)
        Else
            Y = New GroupOptionsDouble
        End If

        Result = GetValue(intext, "Z")
        If Result <> "" Then
            Z.Load(Result)
        Else
            Z = New GroupOptionsDouble
        End If
    End Sub
    Public Sub Clear()
        X.Clear()
        Y.Clear()
        Z.Clear()
    End Sub
End Class