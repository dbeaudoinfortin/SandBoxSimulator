Imports System.Text

Public Structure SimulationRender
    Public Height As Integer
    Public Width As Integer
    Public AspectRatio As Single
    Public BackgroundColor As Color
    Public TraceObjects As Boolean
    Public Parameters As PresentParameters 'Only used at runtime
    Public Device As Device 'Only used at runtime
    Public Scale As Single
    Public Transparency As Boolean 'Only used at runtime
    Public SphereComplexity1 As Integer
    Public SphereComplexity2 As Integer 'Only used at runtime
    Public EnableLighting As Boolean
    Public Shading As ShadeMode
    Public VSync As Boolean
    Public MaxFPS As Double
    Public RenderThreads As Integer
    Public Mode As Byte
    Public Sub Clear()
        AspectRatio = 1
        BackgroundColor = Color.Black
        Device = Nothing
        EnableLighting = True
        Height = 1000
        Width = 1000
        MaxFPS = 45
        RenderThreads = 1
        Mode = 0
        Parameters = Nothing
        Scale = 1
        Shading = ShadeMode.Gouraud
        SphereComplexity1 = 40
        SphereComplexity2 = ToInt32((SphereComplexity1 * 0.5) + 0.5)
        TraceObjects = False
        Transparency = False
        VSync = True
    End Sub
    Public Overloads Sub ToString(stringBuilder As StringBuilder)
        stringBuilder.AppendLine("<AspectRatio>")
        stringBuilder.Append(AspectRatio.ToString())
        stringBuilder.Append("</AspectRatio>")

        stringBuilder.AppendLine("<EnableLighting>")
        stringBuilder.Append(EnableLighting.ToString())
        stringBuilder.Append("</EnableLighting>")

        stringBuilder.AppendLine("<Height>")
        stringBuilder.Append(Height.ToString())
        stringBuilder.Append("</Height>")

        stringBuilder.AppendLine("<MaxFPS>")
        stringBuilder.Append(MaxFPS.ToString())
        stringBuilder.Append("</MaxFPS>")

        stringBuilder.AppendLine("<RenderThreads>")
        stringBuilder.Append(RenderThreads.ToString())
        stringBuilder.Append("</RenderThreads>")

        stringBuilder.AppendLine("<Mode>")
        stringBuilder.Append(Mode.ToString())
        stringBuilder.Append("</Mode>")

        stringBuilder.AppendLine("<Scale>")
        stringBuilder.Append(Scale.ToString())
        stringBuilder.Append("</Scale>")

        stringBuilder.AppendLine("<Shading>")
        stringBuilder.Append(Shading.ToString())
        stringBuilder.Append("</Shading>")

        stringBuilder.AppendLine("<SphereComplexity>")
        stringBuilder.Append(SphereComplexity1.ToString())
        stringBuilder.Append("</SphereComplexity>")

        stringBuilder.AppendLine("<TraceObjects>")
        stringBuilder.Append(TraceObjects.ToString())
        stringBuilder.Append("</TraceObjects>")

        stringBuilder.AppendLine("<VSync>")
        stringBuilder.Append(VSync.ToString())
        stringBuilder.Append("</VSync>")

        stringBuilder.AppendLine("<Width>")
        stringBuilder.Append(Width.ToString())
        stringBuilder.Append("</Width>")

        stringBuilder.AppendLine("<BackgroundColor>")
        stringBuilder.Append(BackgroundColor.ToArgb.ToString())
        stringBuilder.Append("</BackgroundColor>")

    End Sub
    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder)
        Return stringBuilder.ToString
    End Function

    Public Sub Load(ByRef intext As String)
        Dim Result As String

        Result = GetValue(intext, "AspectRatio")
        If Result <> "" And IsNumeric(Result) Then
            AspectRatio = ToSingle(Result)
        Else
            AspectRatio = 1
        End If

        Result = GetValue(intext, "EnableLighting")
        If Result <> "" Then
            EnableLighting = ToBoolean(Result)
        Else
            EnableLighting = True
        End If

        Result = GetValue(intext, "Height")
        If Result <> "" And IsNumeric(Result) Then
            Height = ToInt32(Result)
        Else
            Height = 1000
        End If

        Result = GetValue(intext, "MaxFPS")
        If Result <> "" And IsNumeric(Result) Then
            MaxFPS = ToDouble(Result)
        Else
            MaxFPS = 45
        End If

        Result = GetValue(intext, "RenderThreads")
        If Result <> "" And IsNumeric(Result) Then
            RenderThreads = ToInt32(Result)
        Else
            RenderThreads = 1
        End If

        Result = GetValue(intext, "Mode")
        If Result <> "" And IsNumeric(Result) Then
            Mode = ToByte(Result)
        Else
            Mode = 0
        End If

        Result = GetValue(intext, "Scale")
        If Result <> "" And IsNumeric(Result) Then
            Scale = ToSingle(Result)
        Else
            Scale = 1
        End If

        Result = GetValue(intext, "Shading")
        If Result <> "" Then
            If Result = "Flat" Then
                Shading = ShadeMode.Flat
            Else
                Shading = ShadeMode.Gouraud
            End If
        Else
            Shading = ShadeMode.Gouraud
        End If

        Result = GetValue(intext, "SphereComplexity")
        If Result <> "" And IsNumeric(Result) Then
            SphereComplexity1 = ToInt32(Result)
        Else
            SphereComplexity1 = 40
        End If
        SphereComplexity2 = ToInt32((SphereComplexity1 * 0.5) + 0.5)

        Result = GetValue(intext, "TraceObjects")
        If Result <> "" Then
            TraceObjects = ToBoolean(Result)
        Else
            TraceObjects = False
        End If

        Result = GetValue(intext, "VSync")
        If Result <> "" Then
            VSync = ToBoolean(Result)
        Else
            VSync = True
        End If

        Result = GetValue(intext, "Width")
        If Result <> "" And IsNumeric(Result) Then
            Width = ToInt32(Result)
        Else
            Width = 1000
        End If

        Result = GetValue(intext, "BackgroundColor")
        If Result <> "" And IsNumeric(Result) Then
            BackgroundColor = Color.FromArgb(ToInt32(Result))
        Else
            BackgroundColor = Color.Black
        End If
    End Sub
    Public Sub Copy(ByRef Other As SimulationRender)
        AspectRatio = Other.AspectRatio
        BackgroundColor = Other.BackgroundColor
        Device = Nothing
        EnableLighting = Other.EnableLighting
        Height = Other.Height
        MaxFPS = Other.MaxFPS
        RenderThreads = Other.RenderThreads
        Mode = Other.Mode
        Parameters = Nothing
        Scale = Other.Scale
        Shading = Other.Shading
        SphereComplexity1 = Other.SphereComplexity1
        SphereComplexity2 = Other.SphereComplexity2
        TraceObjects = Other.TraceObjects
        Transparency = Other.Transparency
        VSync = Other.VSync
        Width = Other.Width
    End Sub
End Structure
