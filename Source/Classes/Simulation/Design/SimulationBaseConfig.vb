Imports System.Security.Cryptography
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
    Public ObjectGroupCount As Integer
    Public ObjectGroups() As SimulationConfigObjectGroup

    'Simulation Lights
    Public LightConfigCount As Integer
    Public LightConfigs() As SimulationConfigLight

    Public Sub Clear()
        Render.Clear()
        Forces.Clear()
        Collisions.Clear()
        Camera.Clear()
        Settings.Clear()

        'Groups
        ObjectGroupCount = 1
        ReDim ObjectGroups(0)
        ObjectGroups(0) = New SimulationConfigObjectGroup

        'Lights
        LightConfigCount = 1
        ReDim LightConfigs(0)
        LightConfigs(0) = New SimulationConfigLight
    End Sub
    Public Sub Copy(ByRef Other As SimulationBaseConfig)

        Render.Copy(Other.Render)
        Forces.Copy(Other.Forces)
        Collisions.Copy(Other.Collisions)
        Camera.Copy(Other.Camera)
        Settings.Copy(Other.Settings)

        'Groups
        ObjectGroupCount = Other.ObjectGroupCount
        ReDim ObjectGroups(ObjectGroupCount - 1)
        For i As Integer = 0 To ObjectGroupCount - 1
            ObjectGroups(i) = New SimulationConfigObjectGroup(Other.ObjectGroups(i))
        Next

        'Lights
        LightConfigCount = Other.LightConfigCount
        ReDim LightConfigs(LightConfigCount - 1)
        For i As Integer = 0 To LightConfigCount - 1
            LightConfigs(i) = New SimulationConfigLight(Other.LightConfigs(i))
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
        For r As Integer = 0 To ObjectGroupCount - 1
            stingBuilder.Append(ObjectGroups(r).Affected.ToString)
            stingBuilder.Append(ObjectGroups(r).Affects.ToString)
            stingBuilder.Append(ObjectGroups(r).Type.ToString)

            ObjectGroups(r).Number.AddUniqueString(stingBuilder)

            'Mass is only relevant when forces and/or collisions are enabled
            If Collisions.Enabled Or (Forces.Enabled And (Forces.Drag.Enabled Or Forces.ElectroStatic.Enabled Or Forces.Field.Enabled Or Forces.Gravity)) Then
                ObjectGroups(r).Mass.AddUniqueString(stingBuilder)
            End If


            'Forces
            If Forces.Enabled And Forces.ElectroStatic.Enabled Then
                'Charge is only relevant when the electrostatic force is enabled
                ObjectGroups(r).Charge.AddUniqueString(stingBuilder)
            End If

            'Position applies to all object types
            ObjectGroups(r).Position.X.AddUniqueString(stingBuilder)
            ObjectGroups(r).Position.Y.AddUniqueString(stingBuilder)
            ObjectGroups(r).Position.Z.AddUniqueString(stingBuilder)

            'Velocity applies to all object types
            ObjectGroups(r).Velocity.X.AddUniqueString(stingBuilder)
            ObjectGroups(r).Velocity.Y.AddUniqueString(stingBuilder)
            ObjectGroups(r).Velocity.Z.AddUniqueString(stingBuilder)

            'Specific To Certain Object Types
            If ObjectGroups(r).Type = ObjectType.Sphere Then
                ObjectGroups(r).Radius.AddUniqueString(stingBuilder)
            ElseIf ObjectGroups(r).Type = ObjectType.Box Or ObjectGroups(r).Type = ObjectType.Plane Then
                ObjectGroups(r).Size.X.AddUniqueString(stingBuilder)
                ObjectGroups(r).Size.Y.AddUniqueString(stingBuilder)
                ObjectGroups(r).Size.Z.AddUniqueString(stingBuilder)
                ObjectGroups(r).Rotation.X.AddUniqueString(stingBuilder)
                ObjectGroups(r).Rotation.Y.AddUniqueString(stingBuilder)
                ObjectGroups(r).Rotation.Z.AddUniqueString(stingBuilder)
            ElseIf ObjectGroups(r).Type = ObjectType.InfinitePlane Then
                ObjectGroups(r).Normal.X.AddUniqueString(stingBuilder)
                ObjectGroups(r).Normal.Y.AddUniqueString(stingBuilder)
                ObjectGroups(r).Normal.Z.AddUniqueString(stingBuilder)
            End If
        Next

        'In more recent .net versions, ToString.GetHashCode functions has a randomized component
        'Instead, I use the MD5 hash, which won't change between builds

        Return Math.Abs(ComputeMd5Hash(stingBuilder.ToString))
    End Function
    Private Function ComputeMd5Hash(ByVal inputString As String) As Double
        Using hasher As MD5 = MD5.Create()
            Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(inputString)
            Return ToDouble(BitConverter.ToInt32(hasher.ComputeHash(inputBytes)))
        End Using
    End Function

    Public Overloads Sub ToString(stringBuilder As StringBuilder)

        Dim tabs As String = Constants.vbTab
        Dim tabsPlusOne As String = tabs & Constants.vbTab

        stringBuilder.AppendLine("<PR4-File>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<LightCount>")
        stringBuilder.Append(LightConfigCount.ToString())
        stringBuilder.AppendLine("</LightCount>")

        stringBuilder.Append(tabs)
        stringBuilder.Append("<GroupCount>")
        stringBuilder.Append(ObjectGroupCount.ToString())
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

        For i = 0 To ObjectGroupCount - 1
            stringBuilder.Append(tabs)
            stringBuilder.AppendLine("<Group>")
            ObjectGroups(i).ToString(stringBuilder, tabsPlusOne)
            stringBuilder.AppendLine("</Group>")
        Next

        For i = 0 To LightConfigCount - 1
            stringBuilder.Append(tabs)
            stringBuilder.AppendLine("<Light>")
            LightConfigs(i).ToString(stringBuilder, tabsPlusOne)
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
        ObjectGroupCount += 1
        Array.Resize(ObjectGroups, ObjectGroupCount)
        ObjectGroups(ObjectGroupCount - 1) = New SimulationConfigObjectGroup
    End Sub
    Public Sub EnlargeLights()
        LightConfigCount += 1
        Array.Resize(LightConfigs, LightConfigCount)
        LightConfigs(LightConfigCount - 1) = New SimulationConfigLight
    End Sub
    Public Sub RemoveGroup(ByVal i As Integer)
        For q = i To ObjectGroupCount - 2
            ObjectGroups(q).Copy(ObjectGroups(q + 1))
        Next
        ObjectGroupCount -= 1
        Array.Resize(ObjectGroups, ObjectGroupCount)
    End Sub
    Public Sub RemoveLight(ByVal i As Integer)
        For q = i To LightConfigCount - 2
            LightConfigs(q).Copy(LightConfigs(q + 1))
        Next
        LightConfigCount -= 1
        Array.Resize(LightConfigs, LightConfigCount)
    End Sub
    Public Sub Load(ByRef intext As String)
        Dim StartPos As Integer
        Dim EnQtoIPosistion As Integer
        Dim q As Integer
        Dim Result As String

        Result = GetXMLNodeValue(intext, "LightCount")
        If Result <> "" And IsNumeric(Result) Then
            LightConfigCount = ToInt32(Result)
        Else
            LightConfigCount = 1
        End If

        Result = GetXMLNodeValue(intext, "GroupCount")
        If Result <> "" And IsNumeric(Result) Then
            ObjectGroupCount = ToInt32(Result)
        Else
            ObjectGroupCount = 1
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
        ReDim ObjectGroups(ObjectGroupCount - 1)
        For i = 0 To ObjectGroupCount - 1
            ObjectGroups(i) = New SimulationConfigObjectGroup
        Next

        'Load Groups
        For i = 1 To Len(intext)
            If UCase(Mid(intext, i, Len("<Group>"))) = UCase("<Group>") Then
                StartPos = i + Len("<Group>") - 1
            ElseIf UCase(Mid(intext, i, Len("</Group>"))) = UCase("</Group>") Then
                EnQtoIPosistion = i - 1
                ObjectGroups(q).Load(Mid(intext, StartPos, EnQtoIPosistion - StartPos + 1))
                q = q + 1
                If q > ObjectGroupCount Then Exit For
            End If
        Next

        'Reset Flags
        StartPos = 0
        EnQtoIPosistion = 0
        q = 0

        'Create new Lights
        ReDim LightConfigs(LightConfigCount - 1)
        For i = 0 To LightConfigCount - 1
            LightConfigs(i) = New SimulationConfigLight
        Next

        'Load Lights
        For i = 1 To Len(intext)
            If UCase(Mid(intext, i, Len("<Light>"))) = UCase("<Light>") Then
                StartPos = i + Len("<Light>") - 1
            ElseIf UCase(Mid(intext, i, Len("</Light>"))) = UCase("</Light>") Then
                EnQtoIPosistion = i - 1
                LightConfigs(q).Load(Mid(intext, StartPos, EnQtoIPosistion - StartPos + 1))
                q = q + 1
                If q > LightConfigCount Then Exit For
            End If
        Next
    End Sub
End Structure
