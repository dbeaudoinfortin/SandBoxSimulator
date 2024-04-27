Public Class GroupOptionsColor
    Inherits GroupOptions(Of Color)

    Public Overrides Function AttributeAsString(attribute As Color) As String
        Return attribute.ToArgb.ToString()
    End Function

    Public Overrides Sub Load(ByRef intext As String)
        MyBase.Load(intext)

        Dim Result As String
        Result = GetValue(intext, "EvenMin")
        If Result <> "" And IsNumeric(Result) Then
            EvenMin = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            EvenMin = Drawing.Color.White
        End If

        Result = GetValue(intext, "EvenMax")
        If Result <> "" And IsNumeric(Result) Then
            EvenMax = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            EvenMax = Drawing.Color.White
        End If

        Result = GetValue(intext, "NormalMin")
        If Result <> "" And IsNumeric(Result) Then
            NormalMin = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            NormalMin = Drawing.Color.White
        End If

        Result = GetValue(intext, "NormalMax")
        If Result <> "" And IsNumeric(Result) Then
            NormalMax = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            NormalMax = Drawing.Color.White
        End If

        Result = GetValue(intext, "NormalAvg")
        If Result <> "" And IsNumeric(Result) Then
            NormalAvg = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            NormalAvg = Drawing.Color.White
        End If

        Result = GetValue(intext, "RandomMin")
        If Result <> "" And IsNumeric(Result) Then
            RandomMin = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            RandomMin = Drawing.Color.White
        End If

        Result = GetValue(intext, "RandomMax")
        If Result <> "" And IsNumeric(Result) Then
            RandomMax = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            RandomMax = Drawing.Color.White
        End If

        Result = GetValue(intext, "PolynomialA")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialA = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            PolynomialA = Drawing.Color.White
        End If

        Result = GetValue(intext, "PolynomialB")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialB = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            PolynomialB = Drawing.Color.White
        End If

        Result = GetValue(intext, "PolynomialC")
        If Result <> "" And IsNumeric(Result) Then
            PolynomialC = Drawing.Color.FromArgb(ToInt32(Result))
        Else
            PolynomialC = Drawing.Color.White
        End If

        Result = GetValue(intext, "Value")
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
End Class
