Imports System.Text

Public MustInherit Class SimulationConfigDistribution(Of t)
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

    Public Overridable Function AttributeAsString(attribute As t) As String
        Return attribute.ToString()
    End Function

    Public Overloads Sub ToString(stringBuilder As StringBuilder, tabs As String)

        stringBuilder.Append(tabs)
        stringBuilder.Append("<UseFunction>")
        stringBuilder.Append(UseFunction)
        stringBuilder.AppendLine("</UseFunction>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Value>")
        stringBuilder.Append(AttributeAsString(Value))
        stringBuilder.AppendLine("</Value>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Even>")
        stringBuilder.Append(Even)
        stringBuilder.AppendLine("</Even>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<EvenMax>")
        stringBuilder.Append(AttributeAsString(EvenMax))
        stringBuilder.AppendLine("</EvenMax>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<EvenMin>")
        stringBuilder.Append(AttributeAsString(EvenMin))
        stringBuilder.AppendLine("</EvenMin>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Normal>")
        stringBuilder.Append(Normal)
        stringBuilder.AppendLine("</Normal>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<NormalMax>")
        stringBuilder.Append(AttributeAsString(NormalMax))
        stringBuilder.AppendLine("</NormalMax>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<NormalAvg>")
        stringBuilder.Append(AttributeAsString(NormalAvg))
        stringBuilder.AppendLine("</NormalAvg>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<NormalMin>")
        stringBuilder.Append(AttributeAsString(NormalMin))
        stringBuilder.AppendLine("</NormalMin>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Random>")
        stringBuilder.Append(Random)
        stringBuilder.AppendLine("</Random>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<RandomMax>")
        stringBuilder.Append(AttributeAsString(RandomMax))
        stringBuilder.AppendLine("</RandomMax>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<RandomMin>")
        stringBuilder.Append(AttributeAsString(RandomMin))
        stringBuilder.AppendLine("</RandomMin>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Polynomial>")
        stringBuilder.Append(Polynomial)
        stringBuilder.AppendLine("</Polynomial>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<PolynomialA>")
        stringBuilder.Append(AttributeAsString(PolynomialA))
        stringBuilder.AppendLine("</PolynomialA>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<PolynomialB>")
        stringBuilder.Append(AttributeAsString(PolynomialB))
        stringBuilder.AppendLine("</PolynomialB>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<PolynomialC>")
        stringBuilder.Append(AttributeAsString(PolynomialC))
        stringBuilder.AppendLine("</PolynomialC>")

    End Sub

    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder, "")
        Return stringBuilder.ToString
    End Function

    Public Sub Copy(ByRef Other As SimulationConfigDistribution(Of t))
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

        Result = GetXMLNodeValue(intext, "UseFunction")
        If Result <> "" Then
            UseFunction = ToBoolean(Result)
        Else
            UseFunction = False
        End If

        Result = GetXMLNodeValue(intext, "Even")
        If Result <> "" Then
            Even = ToBoolean(Result)
        Else
            Even = False
        End If

        Result = GetXMLNodeValue(intext, "Normal")
        If Result <> "" Then
            Normal = ToBoolean(Result)
        Else
            Normal = False
        End If

        Result = GetXMLNodeValue(intext, "Random")
        If Result <> "" Then
            Random = ToBoolean(Result)
        Else
            Random = True
        End If

        Result = GetXMLNodeValue(intext, "Polynomial")
        If Result <> "" Then
            Polynomial = ToBoolean(Result)
        Else
            Polynomial = False
        End If
    End Sub

    Public Overridable Sub SendToDistributionForm()
        Distribution.rbEven.Checked = Even
        Distribution.rbNormal.Checked = Normal
        Distribution.rbPolynomial.Checked = Polynomial
        Distribution.rbRandom.Checked = Random
        Distribution.rbNone.Checked = Not UseFunction

        'Reload the values for every type of distribution regardless of what is selected
        If Distribution.Type = TargetType.Numeric Or Distribution.Type = TargetType.ObjectCount Then
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

            Distribution.lbEvenMax.Text = EvenMax.ToString
            Distribution.lbEvenMin.Text = EvenMin.ToString
            Distribution.lbRandomMax.Text = RandomMax.ToString
            Distribution.lbRandomMin.Text = RandomMin.ToString
            Distribution.lbNormalMax.Text = NormalMax.ToString
            Distribution.lbNormalMin.Text = NormalMin.ToString
            Distribution.lbNormalAvg.Text = NormalAvg.ToString
            Distribution.lbPolynomialA.Text = PolynomialA.ToString
            Distribution.lbPolynomialB.Text = PolynomialB.ToString
            Distribution.lbPolynomialC.Text = PolynomialC.ToString
        End If
    End Sub
    Public Overridable Sub LoadFromDistributionForm()
        Even = Distribution.rbEven.Checked
        Normal = Distribution.rbNormal.Checked
        Polynomial = Distribution.rbPolynomial.Checked
        Random = Distribution.rbRandom.Checked
        UseFunction = Not Distribution.rbNone.Checked
    End Sub

    Public Overridable Sub Clear()
        UseFunction = False
        Even = False
        Normal = False
        Random = True
        Polynomial = False
    End Sub

    Public Sub AddUniqueString(stingBuilder As StringBuilder)
        'Generate a unique string that can be used as a seed for a random number generator
        'This only includes physical changes that affect the simulation, not cosmetic changes
        'such as object colour, lighting and material properties

        If UseFunction Then
            If Even Then
                stingBuilder.Append(EvenMin.ToString)
                stingBuilder.Append(EvenMax.ToString)
            ElseIf Normal Then
                stingBuilder.Append(NormalMin.ToString)
                stingBuilder.Append(NormalAvg.ToString)
                stingBuilder.Append(NormalMax.ToString)
            ElseIf Polynomial Then
                stingBuilder.Append(PolynomialA.ToString)
                stingBuilder.Append(PolynomialB.ToString)
                stingBuilder.Append(PolynomialC.ToString)
            ElseIf Random Then
                stingBuilder.Append(RandomMin.ToString)
                stingBuilder.Append(RandomMax.ToString)
            End If
        Else
            stingBuilder.Append(Value.ToString)
        End If
    End Sub
    Public MustOverride Function CalculateEffectiveValue(RandMaker As RandNumber, ObjectIndex As Integer, ObjectCount As Integer) As t
End Class
