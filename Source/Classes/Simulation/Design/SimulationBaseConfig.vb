Imports System.Text
Imports System.Windows.Forms

Public Structure SimulationBaseConfig

    'Structures - Settings
    Public Render As SimulationConfigRender
    Public Forces As SimulationConfigForces
    Public Collisions As SimulationConfigCollision
    Public Camera As SimulationConfigCamera
    Public Settings As SimulationSettings

    'Simulation Groups
    Public GroupCount As Integer
    Public Groups() As SimulationConfigObjectGroup

    'Simulation Lights
    Public LightCount As Integer
    Public Lights() As SimulationConfigLight

    Public Sub Clear()
        Render.Clear()
        Forces.Clear()
        Collisions.Clear()
        Camera.Clear()
        Settings.Clear()

        'Groups
        GroupCount = 1
        ReDim Groups(0)
        Groups(0) = New SimulationConfigObjectGroup

        'Lights
        LightCount = 1
        ReDim Lights(0)
        Lights(0) = New SimulationConfigLight
    End Sub
    Public Sub Copy(ByRef Other As SimulationBaseConfig)

        Render.Copy(Other.Render)
        Forces.Copy(Other.Forces)
        Collisions.Copy(Other.Collisions)
        Camera.Copy(Other.Camera)
        Settings.Copy(Other.Settings)

        'Groups
        GroupCount = Other.GroupCount
        ReDim Groups(GroupCount - 1)
        For i As Integer = 0 To GroupCount - 1
            Groups(i) = New SimulationConfigObjectGroup(Other.Groups(i))
        Next

        'Lights
        LightCount = Other.LightCount
        ReDim Lights(LightCount - 1)
        For i As Integer = 0 To LightCount - 1
            Lights(i) = New SimulationConfigLight(Other.Lights(i))
        Next

    End Sub
    Public Function GetUniqueSeed() As Double
        'Calculates a unique value that can be used as a seed for a random number generator
        'This only includes physical changes that affect the simulation, not cosmetic changes
        'such as object colour, lighting and material properties.
        'The idea is the ensure that if you run the simulation a second time you will get back
        'the exact same results.

        Dim stingBuilder As New StringBuilder

        'Collisions - Global Settings
        If Collisions.Enabled Then
            stingBuilder.Append(Collisions.CoR.ToString)
            If Collisions.Breakable Then
                stingBuilder.Append(Collisions.AddAvg.ToString)
                stingBuilder.Append(Collisions.AddMin.ToString)
                stingBuilder.Append(Collisions.AddMax.ToString)
                stingBuilder.Append(Collisions.BreakAvg.ToString)
                stingBuilder.Append(Collisions.BreakMin.ToString)
                stingBuilder.Append(Collisions.BreakMax.ToString)
            End If
        End If

        'Forces - Global Settings
        If Forces.Enabled Then
            If Forces.ElectroStatic.Enabled Then
                'Charge is only relevant when the electrostatic force is enabled
                stingBuilder.Append(Forces.ElectroStatic.Permittivity.ToString)
            End If

            If Forces.Field.Enabled = True Then
                stingBuilder.Append(Forces.Field.Acceleration.X.ToString)
                stingBuilder.Append(Forces.Field.Acceleration.Y.ToString)
                stingBuilder.Append(Forces.Field.Acceleration.Z.ToString)
            End If

            If Forces.Drag.Enabled Then
                stingBuilder.Append(Forces.Drag.Density.ToString)
                stingBuilder.Append(Forces.Drag.Viscosity.ToString)
                stingBuilder.Append(Forces.Drag.DragCoeff.ToString)
            End If
        End If

        'Per Object Settings
        For r As Integer = 0 To GroupCount - 1
            stingBuilder.Append(Groups(r).Affected.ToString)
            stingBuilder.Append(Groups(r).Affects.ToString)
            stingBuilder.Append(Groups(r).Type.ToString)

            Groups(r).Number.AddUniqueString(stingBuilder)

            'Mass is only relevant when forces and/or collisions are enabled
            If Collisions.Enabled Or (Forces.Enabled And (Forces.Drag.Enabled Or Forces.ElectroStatic.Enabled Or Forces.Field.Enabled Or Forces.Gravity)) Then
                Groups(r).Mass.AddUniqueString(stingBuilder)
            End If


            'Forces
            If Forces.Enabled And Forces.ElectroStatic.Enabled Then
                'Charge is only relevant when the electrostatic force is enabled
                Groups(r).Charge.AddUniqueString(stingBuilder)
            End If

            'Position applies to all object types
            Groups(r).Position.X.AddUniqueString(stingBuilder)
            Groups(r).Position.Y.AddUniqueString(stingBuilder)
            Groups(r).Position.Z.AddUniqueString(stingBuilder)

            'Velocity applies to all object types
            Groups(r).Velocity.X.AddUniqueString(stingBuilder)
            Groups(r).Velocity.Y.AddUniqueString(stingBuilder)
            Groups(r).Velocity.Z.AddUniqueString(stingBuilder)

            'Specific To Certain Object Types
            If Groups(r).Type = ObjectType.Sphere Then
                Groups(r).Radius.AddUniqueString(stingBuilder)
            ElseIf Groups(r).Type = ObjectType.Box Then
                Groups(r).Size.X.AddUniqueString(stingBuilder)
                Groups(r).Size.Y.AddUniqueString(stingBuilder)
                Groups(r).Size.Z.AddUniqueString(stingBuilder)
                Groups(r).Rotation.X.AddUniqueString(stingBuilder)
                Groups(r).Rotation.Y.AddUniqueString(stingBuilder)
                Groups(r).Rotation.Z.AddUniqueString(stingBuilder)
            ElseIf Groups(r).Type = ObjectType.InfinitePlane Then
                Groups(r).Normal.X.AddUniqueString(stingBuilder)
                Groups(r).Normal.Y.AddUniqueString(stingBuilder)
                Groups(r).Normal.Z.AddUniqueString(stingBuilder)
            End If
        Next

        Return Math.Abs(stingBuilder.ToString.GetHashCode)
    End Function
    Public Overloads Sub ToString(stringBuilder As StringBuilder)

        Dim tabs As String = Constants.vbTab
        Dim tabsPlusOne As String = tabs & Constants.vbTab

        stringBuilder.AppendLine("<PR4-File>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<LightCount>")
        stringBuilder.Append(LightCount.ToString())
        stringBuilder.AppendLine("</LightCount>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<GroupCount>")
        stringBuilder.Append(GroupCount.ToString())
        stringBuilder.AppendLine("</GroupCount>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Camera>")
        Camera.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Camera>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Collisions>")
        Collisions.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Collisions>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Forces>")
        Forces.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Forces>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Settings>")
        Settings.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Settings>")

        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("<Render>")
        Render.ToString(stringBuilder, tabsPlusOne)
        stringBuilder.Append(tabs)
        stringBuilder.AppendLine("</Render>")

        For i = 0 To GroupCount - 1
            stringBuilder.Append(tabs)
            stringBuilder.AppendLine("<Group>")
            Groups(i).ToString(stringBuilder, tabsPlusOne)
            stringBuilder.AppendLine("</Group>")
        Next

        For i = 0 To LightCount - 1
            stringBuilder.Append(tabs)
            stringBuilder.AppendLine("<Light>")
            Lights(i).ToString(stringBuilder, tabsPlusOne)
            stringBuilder.Append(tabs)
            stringBuilder.AppendLine("</Light>")
        Next
        stringBuilder.Append("</PR4-File>")
    End Sub
    Public Overrides Function ToString() As String
        Dim stringBuilder As New StringBuilder
        ToString(stringBuilder)
        Return stringBuilder.ToString
    End Function
    Public Sub EnlargeGroups()
        GroupCount += 1
        Array.Resize(Groups, GroupCount)
        Groups(GroupCount - 1) = New SimulationConfigObjectGroup
    End Sub
    Public Sub EnlargeLights()
        LightCount += 1
        Array.Resize(Lights, LightCount)
        Lights(LightCount - 1) = New SimulationConfigLight
    End Sub
    Public Sub RemoveGroup(ByVal i As Integer)
        For q = i To GroupCount - 2
            Groups(q).Copy(Groups(q + 1))
        Next
        GroupCount -= 1
        Array.Resize(Groups, GroupCount)
    End Sub
    Public Sub RemoveLight(ByVal i As Integer)
        For q = i To LightCount - 2
            Lights(q).Copy(Lights(q + 1))
        Next
        LightCount -= 1
        Array.Resize(Lights, LightCount)
    End Sub
    Public Sub Load(ByRef intext As String)
        Dim StartPos As Integer
        Dim EnQtoIPosistion As Integer
        Dim q As Integer
        Dim Result As String

        Result = GetXMLNodeValue(intext, "LightCount")
        If Result <> "" And IsNumeric(Result) Then
            LightCount = ToInt32(Result)
        Else
            LightCount = 1
        End If

        Result = GetXMLNodeValue(intext, "GroupCount")
        If Result <> "" And IsNumeric(Result) Then
            GroupCount = ToInt32(Result)
        Else
            GroupCount = 1
        End If

        Result = GetXMLNodeValue(intext, "Camera")
        If Result <> "" Then
            Camera.Load(Result)
        Else
            Camera.Clear()
        End If

        Result = GetXMLNodeValue(intext, "Collisions")
        If Result <> "" Then
            Collisions.Load(Result)
        Else
            Collisions.Clear()
        End If

        Result = GetXMLNodeValue(intext, "Forces")
        If Result <> "" Then
            Forces.Load(Result)
        Else
            Forces.Clear()
        End If

        Result = GetXMLNodeValue(intext, "Settings")
        If Result <> "" Then
            Settings.Load(Result)
        Else
            Settings.Clear()
        End If

        Result = GetXMLNodeValue(intext, "Render")
        If Result <> "" Then
            Render.Load(Result)
        Else
            Render.Clear()
        End If

        'Create new Groups
        ReDim Groups(GroupCount - 1)
        For i = 0 To GroupCount - 1
            Groups(i) = New SimulationConfigObjectGroup
        Next

        'Load Groups
        For i = 1 To Len(intext)
            If UCase(Mid(intext, i, Len("<Group>"))) = UCase("<Group>") Then
                StartPos = i + Len("<Group>") - 1
            ElseIf UCase(Mid(intext, i, Len("</Group>"))) = UCase("</Group>") Then
                EnQtoIPosistion = i - 1
                Groups(q).Load(Mid(intext, StartPos, EnQtoIPosistion - StartPos + 1))
                q = q + 1
                If q > GroupCount Then Exit For
            End If
        Next

        'Reset Flags
        StartPos = 0
        EnQtoIPosistion = 0
        q = 0

        'Create new Lights
        ReDim Lights(LightCount - 1)
        For i = 0 To LightCount - 1
            Lights(i) = New SimulationConfigLight
        Next

        'Load Lights
        For i = 1 To Len(intext)
            If UCase(Mid(intext, i, Len("<Light>"))) = UCase("<Light>") Then
                StartPos = i + Len("<Light>") - 1
            ElseIf UCase(Mid(intext, i, Len("</Light>"))) = UCase("</Light>") Then
                EnQtoIPosistion = i - 1
                Lights(q).Load(Mid(intext, StartPos, EnQtoIPosistion - StartPos + 1))
                q = q + 1
                If q > LightCount Then Exit For
            End If
        Next
    End Sub
End Structure
