Imports System.Text

Public Structure SimulationForces
    Public Enabled As Boolean
    Public Gravity As Boolean
    Public ElectroStatic As SimulationElectroStatic
    Public Field As SimulationField
    Public Drag As SimulationDrag
    Public Sub Clear()
        Enabled = False
        Gravity = False
        ElectroStatic.Clear()
        Field.Clear()
        Drag.Clear()
    End Sub
    Public Overloads Sub ToString(stringBuilder As StringBuilder)
        stringBuilder.AppendLine("<Gravity>")
        stringBuilder.Append(Gravity.ToString)
        stringBuilder.Append("</Gravity>")

        stringBuilder.AppendLine("<Enabled>")
        stringBuilder.Append(Enabled.ToString)
        stringBuilder.Append("</Enabled>")

        stringBuilder.AppendLine("<Drag>")
        Drag.ToString(stringBuilder)
        stringBuilder.Append("</Drag>")

        stringBuilder.AppendLine("<ElectroStatic>")
        ElectroStatic.ToString(stringBuilder)
        stringBuilder.Append("</ElectroStatic>")

        stringBuilder.AppendLine("<Field>")
        Field.ToString(stringBuilder)
        stringBuilder.Append("</Field>")
    End Sub

    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder)
        Return stringBuilder.ToString
    End Function
    Public Sub Load(ByRef intext As String)
        Dim Result As String
        Result = GetValue(intext, "Gravity")
        If Result <> "" Then
            Gravity = ToBoolean(Result)
        Else
            Gravity = False
        End If

        Result = GetValue(intext, "Enabled")
        If Result <> "" Then
            Enabled = ToBoolean(Result)
        Else
            Enabled = False
        End If

        Result = GetValue(intext, "Drag")
        If Result <> "" Then
            Drag.Load(Result)
        Else
            Drag.Clear()
        End If

        Result = GetValue(intext, "ElectroStatic")
        If Result <> "" Then
            ElectroStatic.Load(Result)
        Else
            ElectroStatic.Clear()
        End If

        Result = GetValue(intext, "Field")
        If Result <> "" Then
            Field.Load(Result)
        Else
            Field.Clear()
        End If
    End Sub
    Public Sub Copy(ByRef Other As SimulationForces)
        Enabled = Other.Enabled
        Gravity = Other.Gravity
        ElectroStatic.Copy(Other.ElectroStatic)
        Field.Copy(Other.Field)
        Drag.Copy(Other.Drag)
    End Sub
End Structure