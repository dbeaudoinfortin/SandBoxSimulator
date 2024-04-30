Public Class SimulationObject 'USED AT RUNTIME ONLY, DISECTION OF SIMULATION GROUP

    Public Type As ObjectType
    Public Color As Color
    Public HighlightColor As Color
    Public HighlightSharpness As Single
    Public Position As XYZ
    Public Velocity As XYZ
    Public Acceleration As XYZ
    Public OldPosition As XYZ 'Used in interpolation
    Public CameraDistance As Double ' Used in DX transparency
    Public Mesh As Mesh 'DX only
    Public Material As Material 'DX only
    Public Affected As Boolean
    Public Affects As Boolean
    Public RefractiveIndex As Double
    Public Reflectivity As Double
    Public Mass As Double
    Public Charge As Double
    Public Radius As Double
    Public Wireframe As Boolean
    Public Transparency As Double
    Public Size As XYZ 'Used for Box
    Public LimitPositive As XYZ 'Used for Box
    Public LimitNegative As XYZ 'Used for Box
    Public Rotation As XYZ ' Used for Box
    Public Normal As XYZ 'Used for Plane
    Public Sub CreateMaterial()
        Material.Ambient = Color
        Material.Diffuse = Color
        Material.Specular = HighlightColor
        Material.SpecularSharpness = HighlightSharpness
    End Sub
    Public Sub CreateMesh(ByRef Location As Device, ByRef Scale As Single, ByRef Complexity1 As Integer, ByRef Complexity2 As Integer)
        If Type = ObjectType.Sphere Then
            Mesh = Mesh.Sphere(Location, ToSingle(Scale * Radius), Complexity1, Complexity2)
        ElseIf Type = ObjectType.Box Then
            Mesh = Mesh.Box(Location, ToSingle(Scale * Size.X), ToSingle(Scale * Size.Y), ToSingle(Scale * Size.Z))
        ElseIf Type = ObjectType.InfinitePlane Then
            Mesh = Mesh.Box(Location, Scale * 2000, ToSingle(Scale * 0.0001), Scale * 2000)
        End If
    End Sub
    Public Sub Copy(ByRef Other As SimulationObject)
        CameraDistance = Other.CameraDistance
        Type = Other.Type
        RefractiveIndex = Other.RefractiveIndex
        Reflectivity = Other.Reflectivity
        LimitPositive.Copy(Other.LimitPositive)
        LimitNegative.Copy(Other.LimitNegative)
        Rotation.Copy(Other.Rotation)
        Size.Copy(Other.Size)
        Normal.Copy(Other.Normal)
        Acceleration.Copy(Other.Acceleration)
        OldPosition.Copy(Other.OldPosition)
        Wireframe = Other.Wireframe
        Charge = Other.Charge
        Affected = Other.Affected
        Affects = Other.Affects
        Color = Other.Color
        HighlightColor = Other.HighlightColor
        HighlightSharpness = Other.HighlightSharpness
        Mass = Other.Mass
        Position.Copy(Other.Position)
        Radius = Other.Radius
        Velocity.Copy(Other.Velocity)
        Mesh = Nothing
        Material = Nothing
        Transparency = Other.Transparency
    End Sub
    Public Sub New(ByRef Other As SimulationObject)
        Copy(Other)
    End Sub
    Public Sub New()
        RefractiveIndex = 1
        Reflectivity = 0
        LimitPositive = New XYZ(0, 0, 0)
        LimitNegative = New XYZ(0, 0, 0)
        Rotation = New XYZ(0, 0, 0)
        Size = New XYZ(1, 1, 1)
        Normal = New XYZ(0, 1, 0)
        Acceleration = New XYZ(0, 0, 0)
        OldPosition = New XYZ(0, 0, 0)
        Wireframe = False
        Charge = 0
        Affected = True
        Affects = True
        Color = Color.FromArgb(255, 255, 192, 128)
        HighlightColor = Color.White
        HighlightSharpness = 50
        Mass = 1
        Position = New XYZ(0, 0, 0)
        Radius = 1
        Velocity = New XYZ(0, 0, 0)
        Mesh = Nothing
        Material = Nothing
        Transparency = 255
    End Sub
End Class
