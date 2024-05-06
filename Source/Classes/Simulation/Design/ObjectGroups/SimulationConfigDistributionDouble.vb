
Public Class SimulationConfigDistributionDouble
    Inherits SimulationConfigDistribution(Of Double)
    Public Overrides Sub Load(ByRef intext As String)
        MyBase.Load(intext)

        Dim Result As String
        Result = GetXMLNodeValue(intext, "EvenMin")
        If Result <> "" And IsNumeric(Result) Then
            EvenMin = ToDouble(Result)
        Else
            EvenMin = 0
        End If

        Result = GetXMLNodeValue(intext, "EvenMax")
        If Result <> "" And IsNumeric(Result) Then
            EvenMax = ToDouble(Result)
        Else
            EvenMax = 0
        End If

        Result = GetXMLNodeValue(intext, "NormalMin")
        If Result <> "" And IsNumeric(Result) Then
            NormalMin = ToDouble(Result)
        Else
            NormalMin = 0
        End If

        Result = GetXMLNodeValue(intext, "NormalMax")
        If Result <> "" And IsNumeric(Result) Then
            NormalMax = ToDouble(Result)
        Else
            NormalMax = 0
        End If

        Result = GetXMLNodeValue(intext, "NormalAvg")
        If Result <> "" And IsNumeric(Result) Then
            NormalAvg = ToDouble(Result)
        Else
            NormalAvg = 0
        End If

        Result = GetXMLNodeValue(intext, "RandomMin")
        If Result <> "" And IsNumeric(Result) Then
            RandomMin = ToDouble(Result)
        Else
            RandomMin = 0
        End If

        Result = GetXMLNodeValue(intext, "RandomMax")
        If Result <> "" And IsNumeric(Result) Then
            RandomMax = ToDouble(Result)
        Else
            RandomMax = 0
        End If

        Result = GetXMLNodeValue(intext, "PolynomialA")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialA = ToDouble(Result)
        Else
            PolynomialA = 0
        End If

        Result = GetXMLNodeValue(intext, "PolynomialB")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialB = ToDouble(Result)
        Else
            PolynomialB = 0
        End If

        Result = GetXMLNodeValue(intext, "PolynomialC")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialC = ToDouble(Result)
        Else
            PolynomialC = 0
        End If

        Result = GetXMLNodeValue(intext, "Value")
        If Result <> "" And IsNumeric(Result) Then
            Value = ToDouble(Result)
        Else
            Value = 0
        End If
    End Sub

    Public Overrides Sub LoadFromDistributionForm()
        MyBase.LoadFromDistributionForm()

        If Distribution.Type = TargetType.Numeric Or Distribution.Type = TargetType.ObjectCount Then
            If Even Then
                EvenMax = ToDouble(Distribution.txtEvenMax.Text)
                EvenMin = ToDouble(Distribution.txtEvenMin.Text)
            ElseIf Random Then
                RandomMax = ToDouble(Distribution.txtRandomMax.Text)
                RandomMin = ToDouble(Distribution.txtRandomMin.Text)
            ElseIf Normal Then
                NormalMax = ToDouble(Distribution.txtNormalMax.Text)
                NormalMin = ToDouble(Distribution.txtNormalMin.Text)
                NormalAvg = ToDouble(Distribution.txtNormalAvg.Text)
            ElseIf Polynomial Then
                PolynomialA = ToDouble(Distribution.txtPolynomialA.Text)
                PolynomialB = ToDouble(Distribution.txtPolynomialB.Text)
                PolynomialC = ToDouble(Distribution.txtPolynomialC.Text)
            End If
        ElseIf Distribution.Type = TargetType.TrackBar Then
            If Even Then
                EvenMax = ToDouble(Distribution.tbEvenMax.Value)
                EvenMin = ToDouble(Distribution.tbEvenMin.Value)
            ElseIf Random Then
                RandomMax = ToDouble(Distribution.tbRandomMax.Value)
                RandomMin = ToDouble(Distribution.tbRandomMin.Value)
            ElseIf Normal Then
                NormalMax = ToDouble(Distribution.tbNormalMax.Value)
                NormalMin = ToDouble(Distribution.tbNormalMin.Value)
                NormalAvg = ToDouble(Distribution.tbNormalAvg.Value)
            ElseIf Polynomial Then
                PolynomialA = ToDouble(Distribution.tbPolynomialA.Value)
                PolynomialB = ToDouble(Distribution.tbPolynomialB.Value)
                PolynomialC = ToDouble(Distribution.tbPolynomialC.Value)
            End If
        End If
    End Sub
    Public Overrides Sub Clear()
        MyBase.Clear()

        EvenMin = 1
        EvenMax = 50
        NormalMin = 1
        NormalMax = 50
        NormalAvg = 20
        RandomMin = 1
        RandomMax = 50
        PolynomialA = 0
        PolynomialB = 5
        PolynomialC = 50
        Value = 1
    End Sub
    Public Overrides Function CalculateEffectiveValue(RandMaker As RandNumber, ObjectIndex As Integer, ObjectCount As Integer) As Double
        If Not UseFunction Then
            'Not using a function (not parametric), return the set value
            Return Value
        End If

        Dim effectiveValue As Double
        If Normal Then 'Calulate using the normal distribution function
            Dim SkewDirection As Double = RandMaker.GetNext
            'Determine what distribution curve will be used
            If SkewDirection = 0.5 Then
                effectiveValue = NormalAvg
            ElseIf SkewDirection < 0.5 Then
                effectiveValue = RandMaker.GetNextSkewed(NormalAvg, NormalMin)
            Else
                effectiveValue = RandMaker.GetNextSkewed(NormalAvg, NormalMax)
            End If

            'Verify reasonable results
            If effectiveValue < NormalMin Then
                effectiveValue = NormalMin
            ElseIf effectiveValue > NormalMax Then
                effectiveValue = NormalMax
            End If

        ElseIf Random Then
            effectiveValue = RandomMin + ((RandomMax - RandomMin) * RandMaker.GetNext)
        ElseIf Even Then
            effectiveValue = EvenMin + ((EvenMax - EvenMin) / (ObjectCount - 1)) * ObjectIndex
        ElseIf Polynomial Then
            effectiveValue = PolynomialC + (ObjectIndex * PolynomialB) + (ObjectIndex * ObjectIndex * PolynomialA)
        End If
        Return effectiveValue
    End Function
End Class