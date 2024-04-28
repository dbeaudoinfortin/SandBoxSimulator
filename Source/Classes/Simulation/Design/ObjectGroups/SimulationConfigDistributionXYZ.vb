Imports System.Text

Public Class SimulationConfigDistributionXYZ
    Public X As SimulationConfigDistribution(Of Double) = New SimulationConfigDistributionDouble
    Public Y As SimulationConfigDistribution(Of Double) = New SimulationConfigDistributionDouble
    Public Z As SimulationConfigDistribution(Of Double) = New SimulationConfigDistributionDouble
    Public Overloads Sub ToString(stringBuilder As StringBuilder, tabs As String)

        Dim tabsPlusOne As String = tabs & Constants.vbTab

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<X>")
        X.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</X>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Y>")
        Y.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Y>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Z>")
        Z.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Z>")
    End Sub

    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder, "")
        Return stringBuilder.ToString
    End Function

    Public Sub Copy(ByRef Other As SimulationConfigDistributionXYZ)
        X.Copy(Other.X)
        Y.Copy(Other.Y)
        Z.Copy(Other.Z)
    End Sub

    Public Sub Load(ByRef intext As String)
        Dim Result As String

        Result = GetXMLNodeValue(intext, "X")
        If Result <> "" Then
            X.Load(Result)
        Else
            X = New SimulationConfigDistributionDouble
        End If

        Result = GetXMLNodeValue(intext, "Y")
        If Result <> "" Then
            Y.Load(Result)
        Else
            Y = New SimulationConfigDistributionDouble
        End If

        Result = GetXMLNodeValue(intext, "Z")
        If Result <> "" Then
            Z.Load(Result)
        Else
            Z = New SimulationConfigDistributionDouble
        End If
    End Sub
    Public Sub Clear()
        X.Clear()
        Y.Clear()
        Z.Clear()
    End Sub

    Public Function CalculateEffectiveValue(RandMaker As RandNumber, ObjectIndex As Integer, ObjectCount As Integer) As XYZ
        Return New XYZ(X.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount),
                       Y.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount),
                       Z.CalculateEffectiveValue(RandMaker, ObjectIndex, ObjectCount))
    End Function

End Class