Imports System.Text

Public Structure SimulationDrag
    Public Enabled As Boolean
    Public DragCoeff As Double
    Public Density As Double
    Public Viscosity As Double
    Public Overloads Sub ToString(stringBuilder As StringBuilder)
        stringBuilder.AppendLine("<Density>")
        stringBuilder.Append(Density.ToString())
        stringBuilder.Append("</Density>")

        stringBuilder.AppendLine("<DragCoeff>")
        stringBuilder.Append(DragCoeff.ToString())
        stringBuilder.Append("</DragCoeff>")

        stringBuilder.AppendLine("<Enabled>")
        stringBuilder.Append(Enabled.ToString())
        stringBuilder.Append("</Enabled>")

        stringBuilder.AppendLine("<Viscosity>")
        stringBuilder.Append(Viscosity.ToString())
        stringBuilder.Append("</Viscosity>")
    End Sub

    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder)
        Return stringBuilder.ToString
    End Function

    Public Sub Load(ByRef intext As String)
        Dim Result As String
        Result = GetValue(intext, "Density")
        If Result <> "" And IsNumeric(Result) Then
            Density = ToDouble(Result)
        Else
            Density = 1.225
        End If

        Result = GetValue(intext, "DragCoeff")
        If Result <> "" And IsNumeric(Result) Then
            DragCoeff = ToDouble(Result)
        Else
            DragCoeff = 0.1
        End If

        Result = GetValue(intext, "Enabled")
        If Result <> "" Then
            Enabled = ToBoolean(Result)
        Else
            Enabled = False
        End If

        Result = GetValue(intext, "Viscosity")
        If Result <> "" And IsNumeric(Result) Then
            Viscosity = ToDouble(Result)
        Else
            Viscosity = 0.0000178
        End If
    End Sub
    Public Sub Clear()
        Enabled = False
        DragCoeff = 0.1
        Density = 1.225
        Viscosity = 0.0000178
    End Sub
    Public Sub Copy(ByRef Other As SimulationDrag)
        Enabled = Other.Enabled
        DragCoeff = Other.DragCoeff
        Density = Other.Density
        Viscosity = Other.Viscosity
    End Sub
End Structure