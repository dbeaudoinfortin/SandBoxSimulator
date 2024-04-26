
Public Class GroupOptionsSingle
    Inherits GroupOptions(Of Single)

    Public Overrides Sub Load(ByRef intext As String)
        MyBase.Load(intext)

        Dim Result As String
        Result = GetValue(intext, "EvenMin")
        If Result <> "" And IsNumeric(Result) Then
            EvenMin = ToSingle(Result)
        Else
            EvenMin = 0
        End If

        Result = GetValue(intext, "EvenMax")
        If Result <> "" And IsNumeric(Result) Then
            EvenMax = ToSingle(Result)
        Else
            EvenMax = 0
        End If

        Result = GetValue(intext, "NormalMin")
        If Result <> "" And IsNumeric(Result) Then
            NormalMin = ToSingle(Result)
        Else
            NormalMin = 0
        End If

        Result = GetValue(intext, "NormalMax")
        If Result <> "" And IsNumeric(Result) Then
            NormalMax = ToSingle(Result)
        Else
            NormalMax = 0
        End If

        Result = GetValue(intext, "NormalAvg")
        If Result <> "" And IsNumeric(Result) Then
            NormalAvg = ToSingle(Result)
        Else
            NormalAvg = 0
        End If

        Result = GetValue(intext, "RandomMin")
        If Result <> "" And IsNumeric(Result) Then
            RandomMin = ToSingle(Result)
        Else
            RandomMin = 0
        End If

        Result = GetValue(intext, "RandomMax")
        If Result <> "" And IsNumeric(Result) Then
            RandomMax = ToSingle(Result)
        Else
            RandomMax = 0
        End If

        Result = GetValue(intext, "PolynomialA")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialA = ToSingle(Result)
        Else
            PolynomialA = 0
        End If

        Result = GetValue(intext, "PolynomialB")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialB = ToSingle(Result)
        Else
            PolynomialB = 0
        End If

        Result = GetValue(intext, "PolynomialC")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialC = ToSingle(Result)
        Else
            PolynomialC = 0
        End If

        Result = GetValue(intext, "Value")
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
End Class
