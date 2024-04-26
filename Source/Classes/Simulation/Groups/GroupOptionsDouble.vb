
Public Class GroupOptionsDouble
    Inherits GroupOptions(Of Double)
    Public Overrides Sub Load(ByRef intext As String)
        MyBase.Load(intext)

        Dim Result As String
        Result = GetValue(intext, "EvenMin")
        If Result <> "" And IsNumeric(Result) Then
            EvenMin = ToDouble(Result)
        Else
            EvenMin = 0
        End If

        Result = GetValue(intext, "EvenMax")
        If Result <> "" And IsNumeric(Result) Then
            EvenMax = ToDouble(Result)
        Else
            EvenMax = 0
        End If

        Result = GetValue(intext, "NormalMin")
        If Result <> "" And IsNumeric(Result) Then
            NormalMin = ToDouble(Result)
        Else
            NormalMin = 0
        End If

        Result = GetValue(intext, "NormalMax")
        If Result <> "" And IsNumeric(Result) Then
            NormalMax = ToDouble(Result)
        Else
            NormalMax = 0
        End If

        Result = GetValue(intext, "NormalAvg")
        If Result <> "" And IsNumeric(Result) Then
            NormalAvg = ToDouble(Result)
        Else
            NormalAvg = 0
        End If

        Result = GetValue(intext, "RandomMin")
        If Result <> "" And IsNumeric(Result) Then
            RandomMin = ToDouble(Result)
        Else
            RandomMin = 0
        End If

        Result = GetValue(intext, "RandomMax")
        If Result <> "" And IsNumeric(Result) Then
            RandomMax = ToDouble(Result)
        Else
            RandomMax = 0
        End If

        Result = GetValue(intext, "PolynomialA")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialA = ToDouble(Result)
        Else
            PolynomialA = 0
        End If

        Result = GetValue(intext, "PolynomialB")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialB = ToDouble(Result)
        Else
            PolynomialB = 0
        End If

        Result = GetValue(intext, "PolynomialC")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialC = ToDouble(Result)
        Else
            PolynomialC = 0
        End If

        Result = GetValue(intext, "Value")
        If Result <> "" And IsNumeric(Result) Then
            Value = ToDouble(Result)
        Else
            Value = 0
        End If
    End Sub

    Public Overrides Sub LoadFromDistribution()
        MyBase.LoadFromDistribution()

        If Distribution.Type = TargetType.Text Or Distribution.Type = TargetType.Number Then
            EvenMax = ToDouble(Distribution.txtEvenMax.Text)
            EvenMin = ToDouble(Distribution.txtEvenMin.Text)
            RandomMax = ToDouble(Distribution.txtRandomMax.Text)
            RandomMin = ToDouble(Distribution.txtRandomMin.Text)
            NormalMax = ToDouble(Distribution.txtNormalMax.Text)
            NormalMin = ToDouble(Distribution.txtNormalMin.Text)
            NormalAvg = ToDouble(Distribution.txtNormalAvg.Text)
            PolynomialA = ToDouble(Distribution.txtPolynomialA.Text)
            PolynomialB = ToDouble(Distribution.txtPolynomialB.Text)
            PolynomialC = ToDouble(Distribution.txtPolynomialC.Text)
        ElseIf Distribution.Type = TargetType.TrackBar Then
            EvenMax = ToDouble(Distribution.tbEvenMax.Value)
            EvenMin = ToDouble(Distribution.tbEvenMin.Value)
            RandomMax = ToDouble(Distribution.tbRandomMax.Value)
            RandomMin = ToDouble(Distribution.tbRandomMin.Value)
            NormalMax = ToDouble(Distribution.tbNormalMax.Value)
            NormalMin = ToDouble(Distribution.tbNormalMin.Value)
            NormalAvg = ToDouble(Distribution.tbNormalAvg.Value)
            PolynomialA = ToDouble(Distribution.tbPolynomialA.Value)
            PolynomialB = ToDouble(Distribution.tbPolynomialB.Value)
            PolynomialC = ToDouble(Distribution.tbPolynomialC.Value)
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
End Class