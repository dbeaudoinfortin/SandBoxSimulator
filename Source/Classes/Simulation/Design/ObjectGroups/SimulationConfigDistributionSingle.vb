
Public Class SimulationConfigDistributionSingle
    Inherits SimulationConfigDistribution(Of Single)
    Public Overrides Sub Load(ByRef intext As String)
        MyBase.Load(intext)

        Dim Result As String
        Result = GetXMLNodeValue(intext, "EvenMin")
        If Result <> "" And IsNumeric(Result) Then
            EvenMin = ToSingle(Result)
        Else
            EvenMin = 0
        End If

        Result = GetXMLNodeValue(intext, "EvenMax")
        If Result <> "" And IsNumeric(Result) Then
            EvenMax = ToSingle(Result)
        Else
            EvenMax = 0
        End If

        Result = GetXMLNodeValue(intext, "NormalMin")
        If Result <> "" And IsNumeric(Result) Then
            NormalMin = ToSingle(Result)
        Else
            NormalMin = 0
        End If

        Result = GetXMLNodeValue(intext, "NormalMax")
        If Result <> "" And IsNumeric(Result) Then
            NormalMax = ToSingle(Result)
        Else
            NormalMax = 0
        End If

        Result = GetXMLNodeValue(intext, "NormalAvg")
        If Result <> "" And IsNumeric(Result) Then
            NormalAvg = ToSingle(Result)
        Else
            NormalAvg = 0
        End If

        Result = GetXMLNodeValue(intext, "RandomMin")
        If Result <> "" And IsNumeric(Result) Then
            RandomMin = ToSingle(Result)
        Else
            RandomMin = 0
        End If

        Result = GetXMLNodeValue(intext, "RandomMax")
        If Result <> "" And IsNumeric(Result) Then
            RandomMax = ToSingle(Result)
        Else
            RandomMax = 0
        End If

        Result = GetXMLNodeValue(intext, "PolynomialA")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialA = ToSingle(Result)
        Else
            PolynomialA = 0
        End If

        Result = GetXMLNodeValue(intext, "PolynomialB")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialB = ToSingle(Result)
        Else
            PolynomialB = 0
        End If

        Result = GetXMLNodeValue(intext, "PolynomialC")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialC = ToSingle(Result)
        Else
            PolynomialC = 0
        End If

        Result = GetXMLNodeValue(intext, "Value")
        If Result <> "" And IsNumeric(Result) Then
            Value = ToSingle(Result)
        Else
            Value = 0
        End If
    End Sub

    Public Overrides Sub LoadFromDistribution()
        MyBase.LoadFromDistribution()

        If Distribution.Type = TargetType.Text Or Distribution.Type = TargetType.Number Then
            EvenMax = ToSingle(Distribution.txtEvenMax.Text)
            EvenMin = ToSingle(Distribution.txtEvenMin.Text)
            RandomMax = ToSingle(Distribution.txtRandomMax.Text)
            RandomMin = ToSingle(Distribution.txtRandomMin.Text)
            NormalMax = ToSingle(Distribution.txtNormalMax.Text)
            NormalMin = ToSingle(Distribution.txtNormalMin.Text)
            NormalAvg = ToSingle(Distribution.txtNormalAvg.Text)
            PolynomialA = ToSingle(Distribution.txtPolynomialA.Text)
            PolynomialB = ToSingle(Distribution.txtPolynomialB.Text)
            PolynomialC = ToSingle(Distribution.txtPolynomialC.Text)
        ElseIf Distribution.Type = TargetType.TrackBar Then
            EvenMax = ToSingle(Distribution.tbEvenMax.Value)
            EvenMin = ToSingle(Distribution.tbEvenMin.Value)
            RandomMax = ToSingle(Distribution.tbRandomMax.Value)
            RandomMin = ToSingle(Distribution.tbRandomMin.Value)
            NormalMax = ToSingle(Distribution.tbNormalMax.Value)
            NormalMin = ToSingle(Distribution.tbNormalMin.Value)
            NormalAvg = ToSingle(Distribution.tbNormalAvg.Value)
            PolynomialA = ToSingle(Distribution.tbPolynomialA.Value)
            PolynomialB = ToSingle(Distribution.tbPolynomialB.Value)
            PolynomialC = ToSingle(Distribution.tbPolynomialC.Value)
        End If
    End Sub
    Public Overrides Sub Clear()
        MyBase.Clear()
        EvenMin = 1
        EvenMax = 1.5
        NormalMin = 1
        NormalMax = 1.5
        NormalAvg = 1.2
        RandomMin = 1
        RandomMax = 1.5
        PolynomialA = 0
        PolynomialB = 0.05
        PolynomialC = 1
        Value = 1
    End Sub
    Public Overrides Function CalculateEffectiveValue(RandMaker As RandNumber, ObjectIndex As Integer, ObjectCount As Integer) As Single
        If Not UseFunction Then
            'Not using a function (not parametric), return the set value
            Return Value
        End If

        Dim effectiveValue As Single
        If Normal Then 'Calulate using the normal distribution function
            Dim SkewDirection As Double = RandMaker.GetNext
            'Determine what distribution curve will be used
            If SkewDirection = 0.5 Then
                effectiveValue = NormalAvg
            ElseIf SkewDirection < 0.5 Then
                effectiveValue = ToSingle(RandMaker.GetNextSkewed(NormalAvg, NormalMin))
            Else
                effectiveValue = ToSingle(RandMaker.GetNextSkewed(NormalAvg, NormalMax))
            End If

            'Verify reasonable results
            If effectiveValue < NormalMin Then
                effectiveValue = NormalMin
            ElseIf effectiveValue > NormalMax Then
                effectiveValue = NormalMax
            End If

        ElseIf Random Then
            effectiveValue = RandomMin + ToSingle(((RandomMax - RandomMin) * RandMaker.GetNext))
        ElseIf Even Then
            effectiveValue = EvenMin + ((EvenMax - EvenMin) / (ObjectCount - 1)) * ObjectIndex
        ElseIf Polynomial Then
            effectiveValue = PolynomialC + (ObjectIndex * PolynomialB) + (ObjectIndex * ObjectIndex * PolynomialA)
        End If
        Return effectiveValue
    End Function


End Class
