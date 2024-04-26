Imports System.Text

Public Class SimulationLight 'USED AT RUNTIME AND DESIGN TIME
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
    Public Sub New(ByRef Other As SimulationLight)
        Copy(Other)
    End Sub
    Public Sub Copy(ByRef Other As SimulationLight)
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
    Public Overloads Sub ToString(stringBuilder As StringBuilder)
        stringBuilder.AppendLine("<Name>")
        stringBuilder.Append(Name.ToString())
        stringBuilder.Append("</Name>")

        stringBuilder.AppendLine("<Type>")
        stringBuilder.Append(Type.ToString())
        stringBuilder.Append("</Type>")

        stringBuilder.AppendLine("<Range>")
        stringBuilder.Append(Range.ToString())
        stringBuilder.Append("</Range>")

        stringBuilder.AppendLine("<AttenuationA>")
        stringBuilder.Append(AttenuationA.ToString())
        stringBuilder.Append("</AttenuationA>")

        stringBuilder.AppendLine("<AttenuationB>")
        stringBuilder.Append(AttenuationB.ToString())
        stringBuilder.Append("</AttenuationB>")

        stringBuilder.AppendLine("<AttenuationC>")
        stringBuilder.Append(AttenuationC.ToString())
        stringBuilder.Append("</AttenuationC>")

        stringBuilder.AppendLine("<InnerCone>")
        stringBuilder.Append(InnerCone.ToString())
        stringBuilder.Append("</InnerCone>")

        stringBuilder.AppendLine("<OuterCone>")
        stringBuilder.Append(OuterCone.ToString())
        stringBuilder.Append("</OuterCone>")

        stringBuilder.AppendLine("<Falloff>")
        stringBuilder.Append(Falloff.ToString())
        stringBuilder.Append("</Falloff>")

        stringBuilder.AppendLine("<AmbientRatio>")
        stringBuilder.Append(AmbientRatio.ToString())
        stringBuilder.Append("</AmbientRatio>")

        stringBuilder.AppendLine("<Color>")
        stringBuilder.Append(Color.ToArgb.ToString())
        stringBuilder.Append("</Color>")

        stringBuilder.AppendLine("<SpecularColor>")
        stringBuilder.Append(SpecularColor.ToArgb.ToString())
        stringBuilder.Append("</SpecularColor>")

        stringBuilder.AppendLine("<AmbientColor>")
        stringBuilder.Append(AmbientColor.ToArgb.ToString())
        stringBuilder.Append("</AmbientColor>")

        stringBuilder.AppendLine("<Position>")
        Position.ToString(stringBuilder)
        stringBuilder.Append("</Position>")

        stringBuilder.AppendLine("<Direction>")
        Direction.ToString(stringBuilder)
        stringBuilder.Append("</Direction>")
    End Sub
    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder)
        Return stringBuilder.ToString
    End Function
    Public Sub Load(ByRef intext As String)
        Dim Result As String

        Result = GetValue(intext, "Name")
        If Result <> "" Then
            Name = Result
        Else
            Name = "Default Light"
        End If

        Result = GetValue(intext, "Type")
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

        Result = GetValue(intext, "Direction")
        If Result <> "" Then
            Direction.Load(Result)
        Else
            Direction = New XYZ(0, 0, 1)
        End If

        Result = GetValue(intext, "Position")
        If Result <> "" Then
            Position.Load(Result)
        Else
            Position = New XYZ(0, 0, -2)
        End If

        Result = GetValue(intext, "AmbientRatio")
        If Result <> "" And IsNumeric(Result) Then
            AmbientRatio = ToInt32(Result)
        Else
            AmbientRatio = 10
        End If

        Result = GetValue(intext, "Range")
        If Result <> "" And IsNumeric(Result) Then
            Range = ToSingle(Result)
        Else
            Range = 50
        End If

        Result = GetValue(intext, "AttenuationA")
        If Result <> "" And IsNumeric(Result) Then
            AttenuationA = ToSingle(Result)
        Else
            AttenuationA = 0
        End If

        Result = GetValue(intext, "AttenuationB")
        If Result <> "" And IsNumeric(Result) Then
            AttenuationB = ToSingle(Result)
        Else
            AttenuationB = 1
        End If

        Result = GetValue(intext, "AttenuationC")
        If Result <> "" And IsNumeric(Result) Then
            AttenuationC = ToSingle(Result)
        Else
            AttenuationC = 0
        End If

        Result = GetValue(intext, "InnerCone")
        If Result <> "" And IsNumeric(Result) Then
            InnerCone = ToSingle(Result)
        Else
            InnerCone = Math.PI / 6
        End If

        Result = GetValue(intext, "OuterCone")
        If Result <> "" And IsNumeric(Result) Then
            OuterCone = ToSingle(Result)
        Else
            OuterCone = Math.PI / 4
        End If

        Result = GetValue(intext, "Falloff")
        If Result <> "" And IsNumeric(Result) Then
            Falloff = ToSingle(Result)
        Else
            Falloff = 1
        End If

        Result = GetValue(intext, "Color")
        If Result <> "" And IsNumeric(Result) Then
            Color = Color.FromArgb(ToInt32(Result))
        Else
            Color = Color.FromArgb(255, 255, 255, 192)
        End If

        Result = GetValue(intext, "SpecularColor")
        If Result <> "" And IsNumeric(Result) Then
            SpecularColor = Color.FromArgb(ToInt32(Result))
        Else
            SpecularColor = Color.FromArgb(255, 50, 50, 50)
        End If

        Result = GetValue(intext, "AmbientColor")
        If Result <> "" And IsNumeric(Result) Then
            AmbientColor = Color.FromArgb(ToInt32(Result))
        Else
            AmbientColor = Color.FromArgb(255, ToInt32(Color.R * (AmbientRatio / 100)), ToInt32(Color.G * (AmbientRatio / 100)), ToInt32(Color.B * (AmbientRatio / 100)))
        End If
    End Sub
End Class

