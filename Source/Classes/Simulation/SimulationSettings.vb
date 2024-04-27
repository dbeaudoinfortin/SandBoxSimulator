

Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Structure SimulationSettings
    Public TimeStep As Double
    Public MaxObjects As Integer
    Public MaxCPS As Double
    Public IntegrationMethod As Byte
    Public Overloads Sub ToString(stringBuilder As StringBuilder, tabs As String)
        stringBuilder.Append(tabs)
        stringBuilder.Append("<IntegrationMethod>")
        stringBuilder.Append(IntegrationMethod.ToString())
        stringBuilder.AppendLine("</IntegrationMethod>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<MaxCPS>")
        stringBuilder.Append(MaxCPS.ToString())
        stringBuilder.AppendLine("</MaxCPS>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<MaxObjects>")
        stringBuilder.Append(MaxObjects.ToString())
        stringBuilder.AppendLine("</MaxObjects>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<TimeStep>")
        stringBuilder.Append(TimeStep.ToString())
        stringBuilder.AppendLine("</TimeStep>")
    End Sub
    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder, "")
        Return stringBuilder.ToString
    End Function

    Public Sub Load(ByRef intext As String)
        Dim Result As String
        Result = GetValue(intext, "IntegrationMethod")
        If Result <> "" And IsNumeric(Result) Then
            IntegrationMethod = ToByte(Result)
        Else
            IntegrationMethod = 2
        End If

        Result = GetValue(intext, "MaxCPS")
        If Result <> "" And IsNumeric(Result) Then
            MaxCPS = ToDouble(Result)
        Else
            MaxCPS = 1000
        End If

        Result = GetValue(intext, "MaxObjects")
        If Result <> "" And IsNumeric(Result) Then
            MaxObjects = ToInt32(Result)
        Else
            MaxObjects = 200
        End If

        Result = GetValue(intext, "TimeStep")
        If Result <> "" And IsNumeric(Result) Then
            TimeStep = ToDouble(Result)
        Else
            TimeStep = 0.001
        End If
    End Sub
    Public Sub Clear()
        TimeStep = 0.001
        MaxObjects = 200
        MaxCPS = 1000
        IntegrationMethod = 2
    End Sub
    Public Sub Copy(ByRef Other As SimulationSettings)
        TimeStep = Other.TimeStep
        MaxObjects = Other.MaxObjects
        MaxCPS = Other.MaxCPS
        IntegrationMethod = Other.IntegrationMethod
    End Sub
End Structure
