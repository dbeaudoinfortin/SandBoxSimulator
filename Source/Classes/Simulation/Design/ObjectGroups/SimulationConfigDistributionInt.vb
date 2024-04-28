
Public Class SimulationConfigDistributionInt
    Inherits SimulationConfigDistribution(Of Integer)

    Public Overrides Sub Load(ByRef intext As String)
        MyBase.Load(intext)

        Dim Result As String
        Result = GetXMLNodeValue(intext, "EvenMin")
        If Result <> "" And IsNumeric(Result) Then
            EvenMin = ToInt32(Result)
        Else
            EvenMin = 0
        End If

        Result = GetXMLNodeValue(intext, "EvenMax")
        If Result <> "" And IsNumeric(Result) Then
            EvenMax = ToInt32(Result)
        Else
            EvenMax = 0
        End If

        Result = GetXMLNodeValue(intext, "NormalMin")
        If Result <> "" And IsNumeric(Result) Then
            NormalMin = ToInt32(Result)
        Else
            NormalMin = 0
        End If

        Result = GetXMLNodeValue(intext, "NormalMax")
        If Result <> "" And IsNumeric(Result) Then
            NormalMax = ToInt32(Result)
        Else
            NormalMax = 0
        End If

        Result = GetXMLNodeValue(intext, "NormalAvg")
        If Result <> "" And IsNumeric(Result) Then
            NormalAvg = ToInt32(Result)
        Else
            NormalAvg = 0
        End If

        Result = GetXMLNodeValue(intext, "RandomMin")
        If Result <> "" And IsNumeric(Result) Then
            RandomMin = ToInt32(Result)
        Else
            RandomMin = 0
        End If

        Result = GetXMLNodeValue(intext, "RandomMax")
        If Result <> "" And IsNumeric(Result) Then
            RandomMax = ToInt32(Result)
        Else
            RandomMax = 0
        End If

        Result = GetXMLNodeValue(intext, "PolynomialA")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialA = ToInt32(Result)
        Else
            PolynomialA = 0
        End If

        Result = GetXMLNodeValue(intext, "PolynomialB")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialB = ToInt32(Result)
        Else
            PolynomialB = 0
        End If

        Result = GetXMLNodeValue(intext, "PolynomialC")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialC = ToInt32(Result)
        Else
            PolynomialC = 0
        End If

        Result = GetXMLNodeValue(intext, "Value")
        If Result <> "" And IsNumeric(Result) Then
            Value = ToInt32(Result)
        Else
            Value = 0
        End If
    End Sub

    Public Overrides Sub LoadFromDistribution()
        MyBase.LoadFromDistribution()

        If Distribution.Type = TargetType.Text Or Distribution.Type = TargetType.Number Then
            EvenMax = ToInt32(Distribution.txtEvenMax.Text)
            EvenMin = ToInt32(Distribution.txtEvenMin.Text)
            RandomMax = ToInt32(Distribution.txtRandomMax.Text)
            RandomMin = ToInt32(Distribution.txtRandomMin.Text)
            NormalMax = ToInt32(Distribution.txtNormalMax.Text)
            NormalMin = ToInt32(Distribution.txtNormalMin.Text)
            NormalAvg = ToInt32(Distribution.txtNormalAvg.Text)
            PolynomialA = ToInt32(Distribution.txtPolynomialA.Text)
            PolynomialB = ToInt32(Distribution.txtPolynomialB.Text)
            PolynomialC = ToInt32(Distribution.txtPolynomialC.Text)
        ElseIf Distribution.Type = TargetType.TrackBar Then
            EvenMax = Distribution.tbEvenMax.Value
            EvenMin = Distribution.tbEvenMin.Value
            RandomMax = Distribution.tbRandomMax.Value
            RandomMin = Distribution.tbRandomMin.Value
            NormalMax = Distribution.tbNormalMax.Value
            NormalMin = Distribution.tbNormalMin.Value
            NormalAvg = Distribution.tbNormalAvg.Value
            PolynomialA = Distribution.tbPolynomialA.Value
            PolynomialB = Distribution.tbPolynomialB.Value
            PolynomialC = Distribution.tbPolynomialC.Value
        End If
    End Sub
    Public Overrides Sub Clear()
        MyBase.Clear()

        EvenMin = 1
        EvenMax = 3
        NormalMin = 1
        NormalMax = 3
        NormalAvg = 2
        RandomMin = 1
        RandomMax = 3
        PolynomialA = 0
        PolynomialB = 0
        PolynomialC = 1
        Value = 1
    End Sub

    Public Overrides Function CalculateEffectiveValue(RandMaker As RandNumber, ObjectIndex As Integer, ObjectCount As Integer) As Integer
        If Not UseFunction Then
            'Not using a function (not parametric), return the set value
            Return Value
        End If

        Dim effectiveValue As Integer
        If Normal Then 'Calulate using the normal distribution function
            Dim SkewDirection As Double = RandMaker.GetNext
            'Determine what distribution curve will be used
            If SkewDirection = 0.5 Then
                effectiveValue = NormalAvg
            ElseIf SkewDirection < 0.5 Then
                effectiveValue = ToInt32(RandMaker.GetNextSkewed(NormalAvg, NormalMin))
            Else
                effectiveValue = ToInt32(RandMaker.GetNextSkewed(NormalAvg, NormalMax))
            End If

            'Verify reasonable results
            If effectiveValue < NormalMin Then
                effectiveValue = NormalMin
            ElseIf effectiveValue > NormalMax Then
                effectiveValue = NormalMax
            End If

        ElseIf Random Then
            effectiveValue = ToInt32(RandomMin + ((RandomMax - RandomMin) * RandMaker.GetNext))
        ElseIf Even Then
            effectiveValue = ToInt32(EvenMin + ((EvenMax - EvenMin) / (ObjectCount - 1)) * ObjectIndex)
        ElseIf Polynomial Then
            effectiveValue = ToInt32(PolynomialC + (ObjectIndex * PolynomialB) + (ObjectIndex * ObjectIndex * PolynomialA))
        End If
        Return effectiveValue
    End Function
End Class
