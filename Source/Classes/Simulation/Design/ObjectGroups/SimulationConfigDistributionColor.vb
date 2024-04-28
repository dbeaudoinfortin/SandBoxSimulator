Public Class SimulationConfigDistributionColor
    Inherits SimulationConfigDistribution(Of Color)

    Public Overrides Function AttributeAsString(attribute As Color) As String
        Return attribute.ToArgb.ToString()
    End Function

    Public Overrides Sub Load(ByRef intext As String)
        MyBase.Load(intext)

        Dim Result As String
        Result = GetXMLNodeValue(intext, "EvenMin")
        If Result <> "" And IsNumeric(Result) Then
            EvenMin = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            EvenMin = Drawing.Color.White
        End If

        Result = GetXMLNodeValue(intext, "EvenMax")
        If Result <> "" And IsNumeric(Result) Then
            EvenMax = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            EvenMax = Drawing.Color.White
        End If

        Result = GetXMLNodeValue(intext, "NormalMin")
        If Result <> "" And IsNumeric(Result) Then
            NormalMin = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            NormalMin = Drawing.Color.White
        End If

        Result = GetXMLNodeValue(intext, "NormalMax")
        If Result <> "" And IsNumeric(Result) Then
            NormalMax = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            NormalMax = Drawing.Color.White
        End If

        Result = GetXMLNodeValue(intext, "NormalAvg")
        If Result <> "" And IsNumeric(Result) Then
            NormalAvg = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            NormalAvg = Drawing.Color.White
        End If

        Result = GetXMLNodeValue(intext, "RandomMin")
        If Result <> "" And IsNumeric(Result) Then
            RandomMin = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            RandomMin = Drawing.Color.White
        End If

        Result = GetXMLNodeValue(intext, "RandomMax")
        If Result <> "" And IsNumeric(Result) Then
            RandomMax = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            RandomMax = Drawing.Color.White
        End If

        Result = GetXMLNodeValue(intext, "PolynomialA")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialA = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            PolynomialA = Drawing.Color.White
        End If

        Result = GetXMLNodeValue(intext, "PolynomialB")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialB = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            PolynomialB = Drawing.Color.White
        End If

        Result = GetXMLNodeValue(intext, "PolynomialC")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialC = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            PolynomialC = Drawing.Color.White
        End If

        Result = GetXMLNodeValue(intext, "Value")
        If Result <> "" And IsNumeric(Result) Then
            Value = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            Value = Drawing.Color.White
        End If
    End Sub

    Public Overrides Sub LoadFromDistribution()
        MyBase.LoadFromDistribution()
        EvenMax = Distribution.plEvenMax.BackColor
        EvenMin = Distribution.plEvenMin.BackColor
        RandomMax = Distribution.plRandomMax.BackColor
        RandomMin = Distribution.plRandomMin.BackColor
        NormalMax = Distribution.plNormalMax.BackColor
        NormalMin = Distribution.plNormalMin.BackColor
        NormalAvg = Distribution.plNormalAvg.BackColor
        PolynomialA = Distribution.plPolynomialA.BackColor
        PolynomialB = Distribution.plPolynomialB.BackColor
        PolynomialC = Distribution.plPolynomialC.BackColor
    End Sub
    Public Overrides Sub Clear()
        MyBase.Clear()

        EvenMin = Drawing.Color.FromArgb(255, 230, 203, 115)
        EvenMax = Drawing.Color.FromArgb(255, 128, 102, 64)
        NormalMin = Drawing.Color.FromArgb(255, 230, 203, 115)
        NormalMax = Drawing.Color.FromArgb(255, 128, 102, 64)
        NormalAvg = Drawing.Color.FromArgb(255, 191, 111, 48)
        RandomMin = Drawing.Color.FromArgb(255, 230, 203, 115)
        RandomMax = Drawing.Color.FromArgb(255, 128, 102, 64)
        PolynomialA = Drawing.Color.FromArgb(255, 230, 203, 115)
        PolynomialB = Drawing.Color.FromArgb(255, 191, 111, 48)
        PolynomialC = Drawing.Color.FromArgb(255, 128, 102, 64)
        Value = Drawing.Color.FromArgb(255, 255, 192, 128)
    End Sub

    Public Overrides Function CalculateEffectiveValue(RandMaker As RandNumber, ObjectIndex As Integer, ObjectCount As Integer) As Color
        If Not UseFunction Then
            'Not using a function (not parametric), return the set value
            Return Value
        End If

        If Normal Then
            Return GetNormalColor(RandMaker, NormalMin, NormalAvg, NormalMax)
        ElseIf Random Then
            Return BlendColors(RandomMin, RandomMax, RandMaker.GetNext)
        ElseIf Even Then
            Return BlendColors(EvenMax, EvenMin, (ObjectIndex / (ObjectCount - 1)))
        ElseIf Polynomial Then
            Return GetPolyColor(PolynomialA, PolynomialB, PolynomialC, ObjectIndex)
        End If

        'Should never happen!
        Return Color.Thistle
    End Function

    Private Function GetNormalColor(RandMaker As RandNumber, ByRef ColorMin As Color, ByRef ColorAvg As Color, ByRef ColorMax As Color) As Color
        Dim ran As Double
        ran = RandMaker.GetNext
        If ran = 0.5 Then
            Return ColorAvg
        ElseIf ran < 0.5 Then
            Return BlendColors(ColorMin, ColorAvg, RandMaker.GetNextNormal() / 2)
        Else
            Return BlendColors(ColorMax, ColorAvg, RandMaker.GetNextNormal() / 2)
        End If
    End Function

    Private Function GetPolyColor(ByRef ColorA As Color, ByRef ColorB As Color, ByRef ColorC As Color, ByRef Current As Integer) As Color
        Dim F1, F2, Tot As Double
        If Current = 0 Then
            Return ColorC
        Else
            F1 = Current * Current
            F2 = Current
            Tot = F1 + F2 + 1
            F1 /= Tot
            F2 /= Tot
            Return BlendColors(BlendColors(ColorA, ColorB, F1 / (F1 + F2)), ColorC, F1 + F2)
        End If
    End Function

End Class
