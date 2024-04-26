
Public Class GroupOptionsInt
    Inherits GroupOptions(Of Integer)

    Public Overrides Sub Load(ByRef intext As String)
        MyBase.Load(intext)

        Dim Result As String
        Result = GetValue(intext, "EvenMin")
        If Result <> "" And IsNumeric(Result) Then
            EvenMin = ToInt32(Result)
        Else
            EvenMin = 0
        End If

        Result = GetValue(intext, "EvenMax")
        If Result <> "" And IsNumeric(Result) Then
            EvenMax = ToInt32(Result)
        Else
            EvenMax = 0
        End If

        Result = GetValue(intext, "NormalMin")
        If Result <> "" And IsNumeric(Result) Then
            NormalMin = ToInt32(Result)
        Else
            NormalMin = 0
        End If

        Result = GetValue(intext, "NormalMax")
        If Result <> "" And IsNumeric(Result) Then
            NormalMax = ToInt32(Result)
        Else
            NormalMax = 0
        End If

        Result = GetValue(intext, "NormalAvg")
        If Result <> "" And IsNumeric(Result) Then
            NormalAvg = ToInt32(Result)
        Else
            NormalAvg = 0
        End If

        Result = GetValue(intext, "RandomMin")
        If Result <> "" And IsNumeric(Result) Then
            RandomMin = ToInt32(Result)
        Else
            RandomMin = 0
        End If

        Result = GetValue(intext, "RandomMax")
        If Result <> "" And IsNumeric(Result) Then
            RandomMax = ToInt32(Result)
        Else
            RandomMax = 0
        End If

        Result = GetValue(intext, "PolynomialA")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialA = ToInt32(Result)
        Else
            PolynomialA = 0
        End If

        Result = GetValue(intext, "PolynomialB")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialB = ToInt32(Result)
        Else
            PolynomialB = 0
        End If

        Result = GetValue(intext, "PolynomialC")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialC = ToInt32(Result)
        Else
            PolynomialC = 0
        End If

        Result = GetValue(intext, "Value")
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
End Class
