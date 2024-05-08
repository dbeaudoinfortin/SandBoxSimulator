'DAVE NOTE: Testing shows this does not perform faster as a structure
Public Class SimulationObject 'USED AT RUNTIME ONLY, DISECTION OF SIMULATION GROUP
    Implements IComparable(Of SimulationObject)

    Public Type As ObjectType
    Public Color As Color
    Public HighlightColor As Color
    Public HighlightSharpness As Single
    Public Position As XYZ
    Public Velocity As XYZ
    Public Acceleration As XYZ
    Public OldPosition As XYZ 'Used in interpolation
    Public CameraDistance As Double ' Used in DX transparency
    Public Affected As Boolean
    Public Affects As Boolean
    Public RefractiveIndex As Double
    Public Reflectivity As Double
    Public Mass As Double
    Public Charge As Double
    Public Radius As Double
    Public Transparency As Byte
    Public Size As XYZ 'Used for Box and Finite Plane (X & Y only)
    Public HalfSize As XYZ
    Public Rotation As XYZ ' Used for Box and Finite Plane
    Public Normal As XYZ 'Used for Infinite Plane
    Public CollisionData As ObjectCollisionData 'Used only in collisions
    Public DXRenderData As ObjectDXRenderData
    Public DXRenderType As RenderType

    Public Sub Copy(ByRef other As SimulationObject)
        CameraDistance = other.CameraDistance
        Type = other.Type
        RefractiveIndex = other.RefractiveIndex
        Reflectivity = other.Reflectivity
        Rotation.Copy(other.Rotation)
        Size.Copy(other.Size)
        HalfSize.Copy(other.HalfSize)
        Normal.Copy(other.Normal)
        Acceleration.Copy(other.Acceleration)
        OldPosition.Copy(other.OldPosition)
        Charge = other.Charge
        Affected = other.Affected
        Affects = other.Affects
        Color = other.Color
        HighlightColor = other.HighlightColor
        HighlightSharpness = other.HighlightSharpness
        Mass = other.Mass
        Position.Copy(other.Position)
        Radius = other.Radius
        Velocity.Copy(other.Velocity)
        Transparency = other.Transparency
        CollisionData = Nothing
        DXRenderData = Nothing
        DXRenderType = other.DXRenderType
    End Sub
    Public Sub New(ByRef Other As SimulationObject)
        Copy(Other)
    End Sub

    Public Sub New()
        RefractiveIndex = 1
        Reflectivity = 0
        Rotation = New XYZ(0, 0, 0)
        Size = New XYZ(1, 1, 1)
        HalfSize = (Size * 0.5)
        Normal = New XYZ(0, 1, 0)
        Acceleration = New XYZ(0, 0, 0)
        OldPosition = New XYZ(0, 0, 0)
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
        Transparency = 255
        CollisionData = Nothing
        DXRenderData = Nothing
        DXRenderType = RenderType.Solid
    End Sub

    Public Function CompareTo(other As SimulationObject) As Integer Implements IComparable(Of SimulationObject).CompareTo
        Return other.CameraDistance.CompareTo(CameraDistance)
    End Function
End Class
