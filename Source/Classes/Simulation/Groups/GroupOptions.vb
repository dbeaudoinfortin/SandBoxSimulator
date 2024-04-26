Imports System.Text

Public MustInherit Class GroupOptions(Of t)
    Public UseFunction As Boolean
    Public Even As Boolean
    Public Normal As Boolean
    Public Random As Boolean
    Public Polynomial As Boolean

    Public EvenMin As t
    Public EvenMax As t
    Public NormalMin As t
    Public NormalMax As t
    Public NormalAvg As t
    Public RandomMin As t
    Public RandomMax As t
    Public PolynomialA As t
    Public PolynomialB As t
    Public PolynomialC As t
    Public Value As t
    Public Overloads Sub ToString(stringBuilder As StringBuilder)

        stringBuilder.AppendLine("<UseFunction>")
        stringBuilder.Append(UseFunction.ToString())
        stringBuilder.Append("</UseFunction>")

        stringBuilder.AppendLine("<Value>")
        stringBuilder.Append(Value.ToString())
        stringBuilder.Append("</Value>")

        stringBuilder.AppendLine("<Even>")
        stringBuilder.Append(Even.ToString())
        stringBuilder.Append("</Even>")

        stringBuilder.AppendLine("<EvenMax>")
        stringBuilder.Append(EvenMax.ToString())
        stringBuilder.Append("</EvenMax>")

        stringBuilder.AppendLine("<EvenMin>")
        stringBuilder.Append(EvenMin.ToString())
        stringBuilder.Append("</EvenMin>")

        stringBuilder.AppendLine("<Normal>")
        stringBuilder.Append(Normal.ToString())
        stringBuilder.Append("</Normal>")

        stringBuilder.AppendLine("<NormalMax>")
        stringBuilder.Append(NormalMax.ToString())
        stringBuilder.Append("</NormalMax>")

        stringBuilder.AppendLine("<NormalAvg>")
        stringBuilder.Append(NormalAvg.ToString())
        stringBuilder.Append("</NormalAvg>")

        stringBuilder.AppendLine("<NormalMin>")
        stringBuilder.Append(NormalMin.ToString())
        stringBuilder.Append("</NormalMin>")

        stringBuilder.AppendLine("<Random>")
        stringBuilder.Append(Random.ToString())
        stringBuilder.Append("</Random>")

        stringBuilder.AppendLine("<RandomMax>")
        stringBuilder.Append(RandomMax.ToString())
        stringBuilder.Append("</RandomMax>")

        stringBuilder.AppendLine("<RandomMin>")
        stringBuilder.Append(RandomMin.ToString())
        stringBuilder.Append("</RandomMin>")

        stringBuilder.AppendLine("<Polynomial>")
        stringBuilder.Append(Polynomial.ToString())
        stringBuilder.Append("</Polynomial>")

        stringBuilder.AppendLine("<PolynomialA>")
        stringBuilder.Append(PolynomialA.ToString())
        stringBuilder.Append("</PolynomialA>")

        stringBuilder.AppendLine("<PolynomialB>")
        stringBuilder.Append(PolynomialB.ToString())
        stringBuilder.Append("</PolynomialB>")

        stringBuilder.AppendLine("<PolynomialC>")
        stringBuilder.Append(PolynomialC.ToString())
        stringBuilder.Append("</PolynomialC>")

    End Sub

    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder)
        Return stringBuilder.ToString
    End Function

    Public Sub Copy(ByRef Other As GroupOptions(Of t))
        UseFunction = Other.UseFunction
        Even = Other.Even
        Normal = Other.Normal
        Random = Other.Random
        Polynomial = Other.Polynomial
        EvenMin = Other.EvenMin
        EvenMax = Other.EvenMax
        NormalMin = Other.NormalMin
        NormalMax = Other.NormalMax
        NormalAvg = Other.NormalAvg
        RandomMin = Other.RandomMin
        RandomMax = Other.RandomMax
        PolynomialA = Other.PolynomialA
        PolynomialB = Other.PolynomialB
        PolynomialC = Other.PolynomialC
        Value = Other.Value
    End Sub

    Public Overridable Sub Load(ByRef intext As String)
        Dim Result As String

        Result = GetValue(intext, "UseFunction")
        If Result <> "" Then
            UseFunction = ToBoolean(Result)
        Else
            UseFunction = False
        End If

        Result = GetValue(intext, "Even")
        If Result <> "" Then
            Even = ToBoolean(Result)
        Else
            Even = False
        End If

        Result = GetValue(intext, "Normal")
        If Result <> "" Then
            Normal = ToBoolean(Result)
        Else
            Normal = False
        End If

        Result = GetValue(intext, "Random")
        If Result <> "" Then
            Random = ToBoolean(Result)
        Else
            Random = True
        End If

        Result = GetValue(intext, "Polynomial")
        If Result <> "" Then
            Polynomial = ToBoolean(Result)
        Else
            Polynomial = False
        End If
    End Sub

    Public Sub SendToDistribution()
        Distribution.rbEven.Checked = Even
        Distribution.rbNormal.Checked = Normal
        Distribution.rbPolynomial.Checked = Polynomial
        Distribution.rbRandom.Checked = Random
        If Distribution.Type = TargetType.Text Or Distribution.Type = TargetType.Number Then
            Distribution.txtEvenMax.Text = EvenMax.ToString
            Distribution.txtEvenMin.Text = EvenMin.ToString
            Distribution.txtRandomMax.Text = RandomMax.ToString
            Distribution.txtRandomMin.Text = RandomMin.ToString
            Distribution.txtNormalMax.Text = NormalMax.ToString
            Distribution.txtNormalMin.Text = NormalMin.ToString
            Distribution.txtNormalAvg.Text = NormalAvg.ToString
            Distribution.txtPolynomialA.Text = PolynomialA.ToString
            Distribution.txtPolynomialB.Text = PolynomialB.ToString
            Distribution.txtPolynomialC.Text = PolynomialC.ToString
        ElseIf Distribution.Type = TargetType.TrackBar Then
            Distribution.tbEvenMax.Value = ToInt32(EvenMax)
            Distribution.tbEvenMin.Value = ToInt32(EvenMin)
            Distribution.tbRandomMax.Value = ToInt32(RandomMax)
            Distribution.tbRandomMin.Value = ToInt32(RandomMin)
            Distribution.tbNormalMax.Value = ToInt32(NormalMax)
            Distribution.tbNormalMin.Value = ToInt32(NormalMin)
            Distribution.tbNormalAvg.Value = ToInt32(NormalAvg)
            Distribution.tbPolynomialA.Value = ToInt32(PolynomialA)
            Distribution.tbPolynomialB.Value = ToInt32(PolynomialB)
            Distribution.tbPolynomialC.Value = ToInt32(PolynomialC)
        End If
    End Sub
    Public Overridable Sub LoadFromDistribution()
        Even = Distribution.rbEven.Checked
        Normal = Distribution.rbNormal.Checked
        Polynomial = Distribution.rbPolynomial.Checked
        Random = Distribution.rbRandom.Checked
    End Sub

    Public Overridable Sub Clear()
        UseFunction = False
        Even = False
        Normal = False
        Random = True
        Polynomial = False
    End Sub

End Class
