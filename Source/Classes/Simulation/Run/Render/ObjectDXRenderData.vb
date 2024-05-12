Imports System.Runtime.InteropServices
Imports CSCompatibilityLayer
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
            Return CSCompat.CreateSphere(device, ToSingle(Scale * SimObject.Radius), Complexity1, Complexity2)
        ElseIf SimObject.Type = ObjectType.Box Then
            Dim boxMesh = CSCompat.CreateBox(device, ToSingle(Scale * SimObject.Size.X), ToSingle(Scale * SimObject.Size.Y), ToSingle(Scale * SimObject.Size.Z))
            Return TessellateMesh(device, boxMesh)
        ElseIf SimObject.Type = ObjectType.Plane Then
            Return CSCompat.CreateBox(device, ToSingle(Scale * SimObject.Size.X), ToSingle(Scale * SimObject.Size.Y), ToSingle(Scale * 0.0001))
        ElseIf SimObject.Type = ObjectType.InfinitePlane Then
            Return CSCompat.CreateBox(device, Scale * 2000, ToSingle(Scale * 0.0001), Scale * 2000)
        End If
        Return Nothing
    End Function

    Private Shared ReadOnly MESH_VERTEX_SIZE As Integer = 6 * 4 '3 floats (32bits=4bytes) for position, 3 floats for normal
    Private Shared ReadOnly MESH_INDEX_SIZE As Integer = 2 '16bit per index = 2 bytes

    <StructLayout(LayoutKind.Sequential)>
    Private Structure MeshVertex
        Public Position As Vector3
        Public Normal As Vector3

        Public Sub New(pos As Vector3, norm As Vector3)
            Position = pos
            Normal = norm
        End Sub
    End Structure

    Private Shared Function TessellateMesh(ByRef device As Device, ByRef oldMesh As Mesh) As Mesh

        'Lock and read existing data
        Dim oldVertexBuffer As VertexBuffer = oldMesh.VertexBuffer
        Dim oldIndexBuffer As IndexBuffer = oldMesh.IndexBuffer

        Dim oldVertexCount As Int16 = ToInt16(oldVertexBuffer.Description.SizeInBytes \ MESH_VERTEX_SIZE)
        Dim oldIndexCount As Integer = oldIndexBuffer.Description.Size \ MESH_INDEX_SIZE

        'Lock the entire buffer starting from zero in read-only mode
        Dim oldVertexData As DataStream = oldVertexBuffer.Lock(0, oldVertexBuffer.Description.SizeInBytes, LockFlags.ReadOnly)
        Dim oldIndexData As DataStream = oldIndexBuffer.Lock(0, oldIndexBuffer.Description.Size, LockFlags.ReadOnly)

        'Create an array of vertices
        Dim oldVertices(oldVertexCount - 1) As MeshVertex
        For i As Integer = 0 To oldVertexCount - 1
            oldVertices(i) = oldVertexData.Read(Of MeshVertex)()
        Next

        'Create an array of indices
        Dim oldIndices(oldIndexCount - 1) As Int16
        For i As Integer = 0 To oldIndexCount - 1
            oldIndices(i) = oldIndexData.Read(Of Int16)()
        Next

        'Unlock the old buffers
        oldVertexBuffer.Unlock()
        oldIndexBuffer.Unlock()

        'Calculate the size of the buffers for the new mesh
        'Each triangle will be split into two, doubling the index count
        'We are adding 1 midpoint vertex for each triangle and sharing the other triangles 
        Dim newVertexCount As Integer = oldVertexCount + (oldIndexCount \ 3)
        Dim newIndexCount As Integer = oldIndexCount * 2

        'Create the new buffers
        Dim newVertices(newVertexCount - 1) As MeshVertex
        Dim newIndices(newIndexCount - 1) As Int16

        'Don't change any of the existing triangles
        Array.Copy(oldVertices, newVertices, oldVertexCount)

        'Start inserting new vertices and the end of the existing ones
        Dim newMidABIndex As Int16 = oldVertexCount

        'Loop for each triangle (3 indices per triangle)
        For i As Integer = 0 To oldIndexCount - 1 Step 3

            Dim indexA As Int16 = oldIndices(i)
            Dim indexB As Int16 = oldIndices(i + 1)
            Dim indexC As Int16 = oldIndices(i + 2)

            Dim A As MeshVertex = oldVertices(indexA)
            Dim B As MeshVertex = oldVertices(indexB)

            'Calculate the midpoint of A and B
            Dim midAB As Vector3 = (A.Position + B.Position) / 2
            Dim midABNormal As Vector3 = (A.Normal + B.Normal) / 2
            midABNormal.Normalize()

            newVertices(newMidABIndex) = New MeshVertex(midAB, midABNormal)

            'First triangle uses A, midAB & C and midAB, B, C
            newIndices(i * 2) = indexA
            newIndices(i * 2 + 1) = newMidABIndex
            newIndices(i * 2 + 2) = indexC

            'Second triangle uses midAB, B, C
            newIndices(i * 2 + 3) = newMidABIndex
            newIndices(i * 2 + 4) = indexB
            newIndices(i * 2 + 5) = indexC

            newMidABIndex += 1S
        Next

        ' Create new buffers and mesh
        Dim newMesh = CSCompat.CreateMeshFVF(device, newIndexCount \ 3, newVertexCount, MeshFlags.Managed, VertexFormat.Position Or VertexFormat.Normal)

        'Dim newVertexBuffer As New VertexBuffer(device, newVertexCount * MESH_VERTEX_SIZE, Usage.WriteOnly, VertexFormat.Position Or VertexFormat.Normal, Pool.Default)
        'Dim newIndexBuffer As New IndexBuffer(device, newIndexCount * MESH_INDEX_SIZE, Usage.WriteOnly, Pool.Default, True) 'Make sure 16bit is set to true

        ' Lock and write new data
        Dim newVertexData As DataStream = newMesh.VertexBuffer.Lock(0, newVertexCount * MESH_VERTEX_SIZE, LockFlags.None)
        Dim newIndexData As DataStream = newMesh.IndexBuffer.Lock(0, newIndexCount * MESH_INDEX_SIZE, LockFlags.None)

        For Each vertex As MeshVertex In newVertices
            newVertexData.Write(vertex)
        Next

        For Each index As Int16 In newIndices
            newIndexData.Write(index)
        Next

        newMesh.VertexBuffer.Unlock()
        newMesh.IndexBuffer.Unlock()
        oldMesh.Dispose()

        Return newMesh
    End Function
End Class
