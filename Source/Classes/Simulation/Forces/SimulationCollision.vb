Imports System.Text

Public Structure SimulationCollision
    Public Enabled As Boolean
    Public Breakable As Boolean
    Public CoR As Double
    Public BreakMax As Double
    Public BreakMin As Double
    Public BreakAvg As Double
    Public AddMin As Integer
    Public AddMax As Integer
    Public AddAvg As Integer
    Public Interpolate As Boolean
    Public Overloads Sub ToString(stringBuilder As StringBuilder)
        stringBuilder.AppendLine("<AddAvg>")
        stringBuilder.Append(AddAvg.ToString())
        stringBuilder.Append("</AddAvg>")

        stringBuilder.AppendLine("<AddMax>")
        stringBuilder.Append(AddMax.ToString())
        stringBuilder.Append("</AddMax>")

        stringBuilder.AppendLine("<AddMin>")
        stringBuilder.Append(AddMin.ToString())
        stringBuilder.Append("</AddMin>")

        stringBuilder.AppendLine("<Breakable>")
        stringBuilder.Append(Breakable.ToString())
        stringBuilder.Append("</Breakable>")

        stringBuilder.AppendLine("<BreakAvg>")
        stringBuilder.Append(BreakAvg.ToString())
        stringBuilder.Append("</BreakAvg>")

        stringBuilder.AppendLine("<BreakMax>")
        stringBuilder.Append(BreakMax.ToString())
        stringBuilder.Append("</BreakMax>")

        stringBuilder.AppendLine("<BreakMin>")
        stringBuilder.Append(BreakMin.ToString())
        stringBuilder.Append("</BreakMin>")

        stringBuilder.AppendLine("<CoR>")
        stringBuilder.Append(CoR.ToString())
        stringBuilder.Append("</CoR>")

        stringBuilder.AppendLine("<Enabled>")
        stringBuilder.Append(Enabled.ToString())
        stringBuilder.Append("</Enabled>")

        stringBuilder.AppendLine("<Interpolate>")
        stringBuilder.Append(Interpolate.ToString())
        stringBuilder.Append("</Interpolate>")
    End Sub

    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder)
        Return stringBuilder.ToString
    End Function

    Public Sub Load(ByRef intext As String)
        Dim Result As String
        Result = GetValue(intext, "AddAvg")
        If Result <> "" And IsNumeric(Result) Then
            AddAvg = ToInt32(Result)
        Else
            AddAvg = 3
        End If

        Result = GetValue(intext, "AddMax")
        If Result <> "" And IsNumeric(Result) Then
            AddMax = ToInt32(Result)
        Else
            AddMax = 8
        End If

        Result = GetValue(intext, "AddMin")
        If Result <> "" And IsNumeric(Result) Then
            AddMin = ToInt32(Result)
        Else
            AddMin = 2
        End If

        Result = GetValue(intext, "Breakable")
        If Result <> "" Then
            Breakable = ToBoolean(Result)
        Else
            Breakable = False
        End If

        Result = GetValue(intext, "BreakAvg")
        If Result <> "" And IsNumeric(Result) Then
            BreakAvg = ToDouble(Result)
        Else
            BreakAvg = 100
        End If

        Result = GetValue(intext, "BreakMax")
        If Result <> "" And IsNumeric(Result) Then
            BreakMax = ToDouble(Result)
        Else
            BreakMax = 500
        End If

        Result = GetValue(intext, "BreakMin")
        If Result <> "" And IsNumeric(Result) Then
            BreakMin = ToDouble(Result)
        Else
            BreakMin = 50
        End If

        Result = GetValue(intext, "CoR")
        If Result <> "" And IsNumeric(Result) Then
            CoR = ToDouble(Result)
        Else
            CoR = 5
        End If

        Result = GetValue(intext, "Enabled")
        If Result <> "" Then
            Enabled = ToBoolean(Result)
        Else
            Enabled = False
        End If

        Result = GetValue(intext, "Interpolate")
        If Result <> "" Then
            Interpolate = ToBoolean(Result)
        Else
            Interpolate = False
        End If
    End Sub
    Public Sub Clear()
        Enabled = False
        Breakable = False
        CoR = 0.5
        BreakMax = 500
        BreakMin = 50
        BreakAvg = 100
        AddMin = 2
        AddMax = 8
        AddAvg = 3
        Interpolate = False
    End Sub
    Public Sub Copy(ByRef Other As SimulationCollision)
        Enabled = Other.Enabled
        Breakable = Other.Breakable
        CoR = Other.CoR
        BreakMax = Other.BreakMax
        BreakMin = Other.BreakMin
        BreakAvg = Other.BreakAvg
        AddMin = Other.AddMin
        AddMax = Other.AddMax
        AddAvg = Other.AddAvg
        Interpolate = Other.Interpolate
    End Sub
End Structure