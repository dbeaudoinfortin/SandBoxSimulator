Imports System.Text

Public Class SimulationConfigLight 'USED AT RUNTIME AND DESIGN TIME
    Public Name As String
    Public Color As Color
    Public Direction As XYZ
    Public Type As LightType
    Public Position As XYZ
    Public SpecularColor As Color
    Public AmbientColor As Color
    Public AmbientRatio As Integer
    Public Range As Single
    Public AttenuationA As Single
    Public AttenuationB As Single
    Public AttenuationC As Single
    Public InnerCone As Single
    Public OuterCone As Single
    Public Falloff As Single
    Public Sub New(ByRef Other As SimulationConfigLight)
        Copy(Other)
    End Sub
    Public Sub Copy(ByRef Other As SimulationConfigLight)
        Name = Other.Name
        Color = Other.Color
        Direction = New XYZ(Other.Direction)
        Type = Other.Type
        Position = New XYZ(Other.Position)
        SpecularColor = Other.SpecularColor
        AmbientColor = Other.AmbientColor
        AmbientRatio = Other.AmbientRatio
        Range = Other.Range
        AttenuationA = Other.AttenuationA
        AttenuationB = Other.AttenuationB
        AttenuationC = Other.AttenuationC
        InnerCone = Other.InnerCone
        OuterCone = Other.OuterCone
        Falloff = Other.Falloff
    End Sub
    Public Sub New()
        Color = Color.FromArgb(255, 255, 255, 192)
        Name = "Default Light"
        Direction = New XYZ(0, 0, 1)
        Position = New XYZ(0, 0, -2)
        Type = LightType.Directional
        SpecularColor = Color.FromArgb(255, 50, 50, 50)
        AmbientRatio = 10
        AmbientColor = Color.FromArgb(255, ToInt32(Color.R * (AmbientRatio / 100)), ToInt32(Color.G * (AmbientRatio / 100)), ToInt32(Color.B * (AmbientRatio / 100)))
        Range = 50
        AttenuationA = 0
        AttenuationB = 1
        AttenuationC = 0
        InnerCone = PI / 6
        OuterCone = PI / 4
        Falloff = 1
    End Sub
    Public Overloads Sub ToString(stringBuilder As StringBuilder, tabs As String)
        Dim tabsPlusOne As String = tabs & Constants.vbTab

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Name>")
        stringBuilder.Append(Name.ToString())
        stringBuilder.AppendLine("</Name>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Type>")
        stringBuilder.Append(Type.ToString())
        stringBuilder.AppendLine("</Type>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Range>")
        stringBuilder.Append(Range.ToString())
        stringBuilder.AppendLine("</Range>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<AttenuationA>")
        stringBuilder.Append(AttenuationA.ToString())
        stringBuilder.AppendLine("</AttenuationA>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<AttenuationB>")
        stringBuilder.Append(AttenuationB.ToString())
        stringBuilder.AppendLine("</AttenuationB>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<AttenuationC>")
        stringBuilder.Append(AttenuationC.ToString())
        stringBuilder.AppendLine("</AttenuationC>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<InnerCone>")
        stringBuilder.Append(InnerCone.ToString())
        stringBuilder.AppendLine("</InnerCone>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<OuterCone>")
        stringBuilder.Append(OuterCone.ToString())
        stringBuilder.AppendLine("</OuterCone>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Falloff>")
        stringBuilder.Append(Falloff.ToString())
        stringBuilder.AppendLine("</Falloff>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<AmbientRatio>")
        stringBuilder.Append(AmbientRatio.ToString())
        stringBuilder.AppendLine("</AmbientRatio>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Color>")
        stringBuilder.Append(Color.ToArgb.ToString())
        stringBuilder.AppendLine("</Color>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<SpecularColor>")
        stringBuilder.Append(SpecularColor.ToArgb.ToString())
        stringBuilder.AppendLine("</SpecularColor>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<AmbientColor>")
        stringBuilder.Append(AmbientColor.ToArgb.ToString())
        stringBuilder.AppendLine("</AmbientColor>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Position>")
        Position.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Position>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Direction>")
        Direction.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Direction>")
    End Sub
    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder, "")
        Return stringBuilder.ToString
    End Function
    Public Sub Load(ByRef intext As String)
        Dim Result As String

        Result = GetXMLNodeValue(intext, "Name")
        If Result <> "" Then
            Name = Result
        Else
            Name = "Default Light"
        End If

        Result = GetXMLNodeValue(intext, "Type")
        If Result <> "" Then
            If Result = "Directional" Then
                Type = Microsoft.DirectX.Direct3D.LightType.Directional
            ElseIf Result = "Spot" Then
                Type = Microsoft.DirectX.Direct3D.LightType.Spot
            ElseIf Result = "Point" Then
                Type = Microsoft.DirectX.Direct3D.LightType.Point
            Else
                Type = Microsoft.DirectX.Direct3D.LightType.Directional
            End If
        Else
            Type = Microsoft.DirectX.Direct3D.LightType.Directional
        End If

        Result = GetXMLNodeValue(intext, "Direction")
        If Result <> "" Then
            Direction.Load(Result)
        Else
            Direction = New XYZ(0, 0, 1)
        End If

        Result = GetXMLNodeValue(intext, "Position")
        If Result <> "" Then
            Position.Load(Result)
        Else
            Position = New XYZ(0, 0, -2)
        End If

        Result = GetXMLNodeValue(intext, "AmbientRatio")
        If Result <> "" And IsNumeric(Result) Then
            AmbientRatio = ToInt32(Result)
        Else
            AmbientRatio = 10
        End If

        Result = GetXMLNodeValue(intext, "Range")
        If Result <> "" And IsNumeric(Result) Then
            Range = ToSingle(Result)
        Else
            Range = 50
        End If

        Result = GetXMLNodeValue(intext, "AttenuationA")
        If Result <> "" And IsNumeric(Result) Then
            AttenuationA = ToSingle(Result)
        Else
            AttenuationA = 0
        End If

        Result = GetXMLNodeValue(intext, "AttenuationB")
        If Result <> "" And IsNumeric(Result) Then
            AttenuationB = ToSingle(Result)
        Else
            AttenuationB = 1
        End If

        Result = GetXMLNodeValue(intext, "AttenuationC")
        If Result <> "" And IsNumeric(Result) Then
            AttenuationC = ToSingle(Result)
        Else
            AttenuationC = 0
        End If

        Result = GetXMLNodeValue(intext, "InnerCone")
        If Result <> "" And IsNumeric(Result) Then
            InnerCone = ToSingle(Result)
        Else
            InnerCone = Math.PI / 6
        End If

        Result = GetXMLNodeValue(intext, "OuterCone")
        If Result <> "" And IsNumeric(Result) Then
            OuterCone = ToSingle(Result)
        Else
            OuterCone = Math.PI / 4
        End If

        Result = GetXMLNodeValue(intext, "Falloff")
        If Result <> "" And IsNumeric(Result) Then
            Falloff = ToSingle(Result)
        Else
            Falloff = 1
        End If

        Result = GetXMLNodeValue(intext, "Color")
        If Result <> "" And IsNumeric(Result) Then
            Color = Color.FromArgb(ToInt32(Result))
        Else
            Color = Color.FromArgb(255, 255, 255, 192)
        End If

        Result = GetXMLNodeValue(intext, "SpecularColor")
        If Result <> "" And IsNumeric(Result) Then
            SpecularColor = Color.FromArgb(ToInt32(Result))
        Else
            SpecularColor = Color.FromArgb(255, 50, 50, 50)
        End If

        Result = GetXMLNodeValue(intext, "AmbientColor")
        If Result <> "" And IsNumeric(Result) Then
            AmbientColor = Color.FromArgb(ToInt32(Result))
        Else
            AmbientColor = Color.FromArgb(255, ToInt32(Color.R * (AmbientRatio / 100)), ToInt32(Color.G * (AmbientRatio / 100)), ToInt32(Color.B * (AmbientRatio / 100)))
        End If
    End Sub
End Class

