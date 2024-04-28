Imports System.Text

Public Structure SimulationConfigCamera
    'Cartesan Coordinates
    Public Target As XYZ
    Public Position As XYZ

    'Rotation Vectors
    Public UpVector As XYZ     'Up Vector

    'Movement
    Public MoveSpeed As Double

    'Field of View
    Public VFov As Single               'Only used in Raytracing
    Public HFov As Single

    'Use default values
    Public AllowModification As Boolean

    Public Overloads Sub ToString(stringBuilder As StringBuilder, tabs As String)
        Dim tabsPlusOne As String = tabs & Constants.vbTab

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Position>")
        Position.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Position>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Target>")
        Target.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Target>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Up>")
        UpVector.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Up>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<HFov>")
        stringBuilder.Append(HFov.ToString)
        stringBuilder.AppendLine("</HFov>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<VFov>")
        stringBuilder.Append(VFov.ToString)
        stringBuilder.AppendLine("</VFov>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<MoveSpeed>")
        stringBuilder.Append(MoveSpeed.ToString())
        stringBuilder.AppendLine("</MoveSpeed>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<AllowModification>")
        stringBuilder.Append(AllowModification.ToString())
        stringBuilder.AppendLine("</AllowModification>")

    End Sub

    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder, "")
        Return stringBuilder.ToString
    End Function

    Public Sub Load(ByRef intext As String)
        Dim Result As String

        Result = GetXMLNodeValue(intext, "HFov")
        If Result <> "" And IsNumeric(Result) Then
            HFov = ToSingle(Result)
        Else
            HFov = PI / 4
        End If

        Result = GetXMLNodeValue(intext, "VFov")
        If Result <> "" And IsNumeric(Result) Then
            VFov = ToSingle(Result)
        Else
            VFov = PI / 4
        End If

        Result = GetXMLNodeValue(intext, "MoveSpeed")
        If Result <> "" And IsNumeric(Result) Then
            MoveSpeed = ToDouble(Result)
        Else
            MoveSpeed = 0.2
        End If

        Result = GetXMLNodeValue(intext, "AllowModification")
        If Result <> "" Then
            AllowModification = ToBoolean(Result)
        Else
            AllowModification = False
        End If

        Result = GetXMLNodeValue(intext, "Position")
        If Result <> "" Then
            Position.Load(Result)
        Else
            Position = New XYZ(0, 0, 0)
        End If

        Result = GetXMLNodeValue(intext, "Target")
        If Result <> "" Then
            Target.Load(Result)
        Else
            Target = New XYZ(0, 0, 0)
        End If

        Result = GetXMLNodeValue(intext, "Up")
        If Result <> "" Then
            UpVector.Load(Result)
        Else
            UpVector = New XYZ(0, 1, 0)
        End If
    End Sub
    Public Sub Clear()
        AllowModification = False
        MoveSpeed = 0.2
        HFov = PI / 4
        VFov = PI / 4
        UpVector = New XYZ(0, 1, 0)
        Position = New XYZ(0, 0, -10)
        Target = New XYZ(0, 0, 0)

    End Sub
    Public Sub Copy(ByRef Other As SimulationConfigCamera)
        Target.Copy(Other.Target)
        Position.Copy(Other.Position)
        UpVector.Copy(Other.UpVector)
        MoveSpeed = Other.MoveSpeed
        VFov = Other.VFov
        HFov = Other.HFov
        AllowModification = Other.AllowModification
    End Sub
End Structure
