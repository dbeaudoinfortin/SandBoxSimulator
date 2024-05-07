Imports SharpDX
Imports SharpDX.Direct3D9
Public Class ObjectDXRenderData
    Public Mesh As Mesh
    Public Material As Material
    Public RotationMatrix As SharpDX.Matrix

    Public Sub New(ByRef Mesh As Mesh, ByRef Material As Material, ByRef RotationMatrix As SharpDX.Matrix)
        Me.Mesh = Mesh
        Me.Material = Material
        Me.RotationMatrix = RotationMatrix
    End Sub

    Public Shared Function Build(ByRef SimObject As SimulationObject, ByRef DXDevice As Device, ByRef Scale As Single, ByRef Complexity1 As Integer, ByRef Complexity2 As Integer) As ObjectDXRenderData
        Return New ObjectDXRenderData(
            CreateMesh(SimObject, DXDevice, Scale, Complexity1, Complexity2),
            CreateMaterial(SimObject),
            CreateRotationMatrix(SimObject)
            )
    End Function
    Public Shared Function CreateRotationMatrix(ByRef SimObject As SimulationObject) As SharpDX.Matrix
        'Caluclate the roation matrix of the object
        Return SharpDX.Matrix.RotationYawPitchRoll(ToSingle(SimObject.Rotation.X), ToSingle(SimObject.Rotation.Y), ToSingle(SimObject.Rotation.Z))
    End Function
    Public Shared Function CreateMaterial(ByRef SimObject As SimulationObject) As Material
        Return New Material With {
            .Ambient = ConvertColorToRawColor4(SimObject.Color),
            .Diffuse = ConvertColorToRawColor4(SimObject.Color),
            .Specular = ConvertColorToRawColor4(SimObject.HighlightColor),
            .Power = SimObject.HighlightSharpness
        }
    End Function
    Public Shared Function CreateMesh(ByRef SimObject As SimulationObject, ByRef device As Device, ByRef Scale As Single, ByRef Complexity1 As Integer, ByRef Complexity2 As Integer) As Mesh
        If SimObject.Type = ObjectType.Sphere Then
            Return CSCompatibilityLayer.CSCompat.CreateSphere(device, ToSingle(Scale * SimObject.Radius), Complexity1, Complexity2)
        ElseIf SimObject.Type = ObjectType.Box Then
            Return CSCompatibilityLayer.CSCompat.CreateBox(device, ToSingle(Scale * SimObject.Size.X), ToSingle(Scale * SimObject.Size.Y), ToSingle(Scale * SimObject.Size.Z))
        ElseIf SimObject.Type = ObjectType.Plane Then
            Return CSCompatibilityLayer.CSCompat.CreateBox(device, ToSingle(Scale * SimObject.Size.X), ToSingle(Scale * SimObject.Size.Y), ToSingle(Scale * 0.0001))
        ElseIf SimObject.Type = ObjectType.InfinitePlane Then
            Return CSCompatibilityLayer.CSCompat.CreateBox(device, Scale * 2000, ToSingle(Scale * 0.0001), Scale * 2000)
        End If
        Return Nothing
    End Function
End Class
