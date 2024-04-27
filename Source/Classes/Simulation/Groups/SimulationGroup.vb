Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class SimulationGroup 'USED AT DESIGN TIME ONLY
    Public Type As ObjectType
    Public Name As String

    Public Number As GroupOptions(Of Integer) = New GroupOptionsInt
    Public Mass As GroupOptions(Of Double) = New GroupOptionsDouble
    Public Charge As GroupOptions(Of Double) = New GroupOptionsDouble
    Public Radius As GroupOptions(Of Double) = New GroupOptionsDouble

    Public Size As New GroupOptionsXYZ
    Public Normal As New GroupOptionsXYZ
    Public Rotation As New GroupOptionsXYZ
    Public Position As New GroupOptionsXYZ
    Public Velocity As New GroupOptionsXYZ

    Public Sharpness As GroupOptions(Of Single) = New GroupOptionsSingle
    Public Color As GroupOptions(Of Color) = New GroupOptionsColor
    Public Highlight As GroupOptions(Of Color) = New GroupOptionsColor
    Public Reflectivity As GroupOptions(Of Double) = New GroupOptionsDouble
    Public Transparency As GroupOptions(Of Double) = New GroupOptionsDouble
    Public RefractiveIndex As GroupOptions(Of Double) = New GroupOptionsDouble

    Public Affected As Boolean
    Public Affects As Boolean
    Public Wireframe As Boolean
    Public Overloads Sub ToString(stringBuilder As StringBuilder, tabs As String)

        Dim tabsPlusOne As String = tabs & Constants.vbTab

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Name>")
        stringBuilder.Append(Name.ToString)
        stringBuilder.AppendLine("</Name>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Affected>")
        stringBuilder.Append(Affected.ToString)
        stringBuilder.AppendLine("</Affected>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Affects>")
        stringBuilder.Append(Affects.ToString)
        stringBuilder.AppendLine("</Affects>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Wireframe>")
        stringBuilder.Append(Wireframe.ToString)
        stringBuilder.AppendLine("</Wireframe>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<Type>")
        stringBuilder.Append(Type.ToString)
        stringBuilder.AppendLine("</Type>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Number>")
        Number.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Number>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Mass>")
        Mass.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Mass>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Charge>")
        Charge.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Charge>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Size>")
        Size.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Size>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Radius>")
        Radius.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Radius>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<ObjectNormal>")
        Normal.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</ObjectNormal>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Position>")
        Position.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Position>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Velocity>")
        Velocity.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Velocity>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Color>")
        Color.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Color>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Highlight>")
        Highlight.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Highlight>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Sharpness>")
        Sharpness.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Sharpness>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Reflectivity>")
        Reflectivity.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Reflectivity>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Transparency>")
        Transparency.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Transparency>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Rotation>")
        Rotation.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Rotation>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<RefractiveIndex>")
        RefractiveIndex.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</RefractiveIndex>")

    End Sub
    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder, "")
        Return stringBuilder.ToString
    End Function
    Public Sub New(ByRef Other As SimulationGroup)
        Copy(Other)
    End Sub
    Public Sub Copy(ByRef Other As SimulationGroup)
        Name = Other.Name
        Type = Other.Type
        Affected = Other.Affected
        Affects = Other.Affects
        Wireframe = Other.Wireframe
        Number.Copy(Other.Number)
        Mass.Copy(Other.Mass)
        Charge.Copy(Other.Charge)
        Size.Copy(Other.Size)
        Radius.Copy(Other.Radius)
        Normal.Copy(Other.Normal)
        Rotation.Copy(Other.Rotation)
        Position.Copy(Other.Position)
        Velocity.Copy(Other.Velocity)
        Color.Copy(Other.Color)
        Highlight.Copy(Other.Highlight)
        Sharpness.Copy(Other.Sharpness)
        Reflectivity.Copy(Other.Reflectivity)
        Transparency.Copy(Other.Transparency)
        RefractiveIndex.Copy(Other.RefractiveIndex)
    End Sub
    Public Sub New()
        Type = ObjectType.Sphere
        Name = "Default"
        Affects = True
        Affected = True
        Wireframe = False
        Number.Clear()
        Mass.Clear()
        Charge.Clear()
        Charge.Value = 0
        Size.Clear()
        Radius.Clear()
        Rotation.Clear()
        Rotation.X.Value = 0
        Rotation.Y.Value = 0
        Rotation.Z.Value = 0
        Normal.Clear()
        Normal.X.Value = 0
        Normal.Z.Value = 0
        Position.Clear()
        Position.X.Value = 0
        Position.Y.Value = 0
        Position.Z.Value = 0
        Velocity.Clear()
        Velocity.X.Value = 0
        Velocity.Y.Value = 0
        Velocity.Z.Value = 0
        Color.Clear()
        Highlight.Clear()
        Highlight.Value = Drawing.Color.White
        Sharpness.Clear()
        Sharpness.Value = 50
        Reflectivity.Clear()
        Reflectivity.Value = 0
        Transparency.Clear()
        Transparency.Value = 255
        RefractiveIndex.Clear()
    End Sub
    Public Sub Load(ByRef intext As String)
        Dim Result As String
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Name~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Name")
        If Result <> "" Then
            Name = Result
        Else
            Name = "Default Object"
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Interaction~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Affected")
        If Result <> "" Then
            Affected = ToBoolean(Result)
        Else
            Affected = True
        End If

        Result = GetValue(intext, "Affects")
        If Result <> "" Then
            Affects = ToBoolean(Result)
        Else
            Affects = True
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Display~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Wireframe")
        If Result <> "" Then
            Wireframe = ToBoolean(Result)
        Else
            Wireframe = False
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Type~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Type")
        If Result <> "" Then
            If Result = "Sphere" Then
                Type = ObjectType.Sphere
            ElseIf Result = "Box" Then
                Type = ObjectType.Box
            ElseIf Result = "InfinitePlane" Then
                Type = ObjectType.InfinitePlane
            Else
                Type = ObjectType.Sphere
            End If
        Else
            Type = ObjectType.Sphere
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Number~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Number")
        If Result <> "" Then
            Number.Load(Result)
        Else
            Number.Clear()
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Size~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Size")
        If Result <> "" Then
            Size.Load(Result)
        Else
            Size.Clear()
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Sharpness~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Sharpness")
        If Result <> "" Then
            Sharpness.Load(Result)
        Else
            Sharpness.Clear()
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Color~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Color")
        If Result <> "" Then
            Color.Load(Result)
        Else
            Color.Clear()
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Highlight~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Highlight")
        If Result <> "" Then
            Highlight.Load(Result)
        Else
            Highlight.Clear()
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Mass~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Mass")
        If Result <> "" Then
            Mass.Load(Result)
        Else
            Mass.Clear()
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Charge~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Charge")
        If Result <> "" Then
            Charge.Load(Result)
        Else
            Charge.Clear()
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Radius~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Radius")
        If Result <> "" Then
            Radius.Load(Result)
        Else
            Radius.Clear()
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Normal~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "ObjectNormal")
        If Result <> "" Then
            Normal.Load(Result)
        Else
            Normal.Clear()
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Rotation~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Rotation")
        If Result <> "" Then
            Rotation.Load(Result)
        Else
            Rotation.Clear()
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Position~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Position")
        If Result <> "" Then
            Position.Load(Result)
        Else
            Position.Clear()
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Veclocity~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Velocity")
        If Result <> "" Then
            Velocity.Load(Result)
        Else
            Velocity.Clear()
        End If


        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Reflectivity~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Reflectivity")
        If Result <> "" Then
            Reflectivity.Load(Result)
        Else
            Reflectivity.Clear()
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Transparency~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "Transparency")
        If Result <> "" Then
            Transparency.Load(Result)
        Else
            Transparency.Clear()
        End If

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~RefractiveIndex~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Result = GetValue(intext, "RefractiveIndex")
        If Result <> "" Then
            RefractiveIndex.Load(Result)
        Else
            RefractiveIndex.Clear()
        End If

    End Sub
End Class
