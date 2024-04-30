Imports System.Text
Public Structure SimulationConfigRender
    Public Height As Integer
    Public Width As Integer
    Public AspectRatio As Single
    Public BackgroundColor As Color
    Public TraceObjects As Boolean
    Public WorldScale As Single
    Public SphereComplexity As Integer
    Public EnableLighting As Boolean
    Public Shading As ShadeMode
    Public VSync As Boolean
    Public MaxFPS As Double
    Public RenderThreads As Integer
    Public Mode As Byte
    Public Sub Clear()
        AspectRatio = 1
        BackgroundColor = Color.Black
        EnableLighting = True
        Height = 1000
        Width = 1000
        MaxFPS = 45
        RenderThreads = 1
        Mode = 0
        WorldScale = 1
        Shading = ShadeMode.Gouraud
        SphereComplexity = 40

        TraceObjects = False
        VSync = True
    End Sub
    Public Overloads Sub ToString(stringBuilder As StringBuilder, tabs As String)
        stringBuilder.Append(tabs)
        stringBuilder.Append("<AspectRatio>")
        stringBuilder.Append(AspectRatio.ToString())
        stringBuilder.AppendLine("</AspectRatio>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<EnableLighting>")
        stringBuilder.Append(EnableLighting.ToString())
        stringBuilder.AppendLine("</EnableLighting>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Height>")
        stringBuilder.Append(Height.ToString())
        stringBuilder.AppendLine("</Height>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<MaxFPS>")
        stringBuilder.Append(MaxFPS.ToString())
        stringBuilder.AppendLine("</MaxFPS>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<RenderThreads>")
        stringBuilder.Append(RenderThreads.ToString())
        stringBuilder.AppendLine("</RenderThreads>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Mode>")
        stringBuilder.Append(Mode.ToString())
        stringBuilder.AppendLine("</Mode>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Scale>")
        stringBuilder.Append(WorldScale.ToString())
        stringBuilder.AppendLine("</Scale>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Shading>")
        stringBuilder.Append(Shading.ToString())
        stringBuilder.AppendLine("</Shading>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<SphereComplexity>")
        stringBuilder.Append(SphereComplexity.ToString())
        stringBuilder.AppendLine("</SphereComplexity>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<TraceObjects>")
        stringBuilder.Append(TraceObjects.ToString())
        stringBuilder.AppendLine("</TraceObjects>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<VSync>")
        stringBuilder.Append(VSync.ToString())
        stringBuilder.AppendLine("</VSync>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Width>")
        stringBuilder.Append(Width.ToString())
        stringBuilder.AppendLine("</Width>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<BackgroundColor>")
        stringBuilder.Append(BackgroundColor.ToArgb.ToString())
        stringBuilder.AppendLine("</BackgroundColor>")

    End Sub
    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder, "")
        Return stringBuilder.ToString
    End Function

    Public Sub Load(ByRef intext As String)
        Dim Result As String

        Result = GetXMLNodeValue(intext, "AspectRatio")
        If Result <> "" And IsNumeric(Result) Then
            AspectRatio = ToSingle(Result)
        Else
            AspectRatio = 1
        End If

        Result = GetXMLNodeValue(intext, "EnableLighting")
        If Result <> "" Then
            EnableLighting = ToBoolean(Result)
        Else
            EnableLighting = True
        End If

        Result = GetXMLNodeValue(intext, "Height")
        If Result <> "" And IsNumeric(Result) Then
            Height = ToInt32(Result)
        Else
            Height = 1000
        End If

        Result = GetXMLNodeValue(intext, "MaxFPS")
        If Result <> "" And IsNumeric(Result) Then
            MaxFPS = ToDouble(Result)
        Else
            MaxFPS = 45
        End If

        Result = GetXMLNodeValue(intext, "RenderThreads")
        If Result <> "" And IsNumeric(Result) Then
            RenderThreads = ToInt32(Result)
        Else
            RenderThreads = 1
        End If

        Result = GetXMLNodeValue(intext, "Mode")
        If Result <> "" And IsNumeric(Result) Then
            Mode = ToByte(Result)
        Else
            Mode = 0
        End If

        Result = GetXMLNodeValue(intext, "Scale")
        If Result <> "" And IsNumeric(Result) Then
            WorldScale = ToSingle(Result)
        Else
            WorldScale = 1
        End If

        Result = GetXMLNodeValue(intext, "Shading")
        If Result <> "" Then
            If Result = "Flat" Then
                Shading = ShadeMode.Flat
            Else
                Shading = ShadeMode.Gouraud
            End If
        Else
            Shading = ShadeMode.Gouraud
        End If

        Result = GetXMLNodeValue(intext, "SphereComplexity")
        If Result <> "" And IsNumeric(Result) Then
            SphereComplexity = ToInt32(Result)
        Else
            SphereComplexity = 40
        End If

        Result = GetXMLNodeValue(intext, "TraceObjects")
        If Result <> "" Then
            TraceObjects = ToBoolean(Result)
        Else
            TraceObjects = False
        End If

        Result = GetXMLNodeValue(intext, "VSync")
        If Result <> "" Then
            VSync = ToBoolean(Result)
        Else
            VSync = True
        End If

        Result = GetXMLNodeValue(intext, "Width")
        If Result <> "" And IsNumeric(Result) Then
            Width = ToInt32(Result)
        Else
            Width = 1000
        End If

        Result = GetXMLNodeValue(intext, "BackgroundColor")
        If Result <> "" And IsNumeric(Result) Then
            BackgroundColor = Color.FromArgb(ToInt32(Result))
        Else
            BackgroundColor = Color.Black
        End If
    End Sub
    Public Sub Copy(ByRef Other As SimulationConfigRender)
        AspectRatio = Other.AspectRatio
        BackgroundColor = Other.BackgroundColor
        EnableLighting = Other.EnableLighting
        Height = Other.Height
        MaxFPS = Other.MaxFPS
        RenderThreads = Other.RenderThreads
        Mode = Other.Mode
        WorldScale = Other.WorldScale
        Shading = Other.Shading
        SphereComplexity = Other.SphereComplexity
        TraceObjects = Other.TraceObjects
        VSync = Other.VSync
        Width = Other.Width
    End Sub
End Structure
