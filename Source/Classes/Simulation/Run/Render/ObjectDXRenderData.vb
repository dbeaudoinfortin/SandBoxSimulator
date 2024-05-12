Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports CSCompatibilityLayer
Imports SharpDX
Imports SharpDX.Direct3D9

Public Class ObjectDXRenderData
    Private Shared ObjectMeshCache As New Dictionary(Of String, Mesh)

    Public Mesh As Mesh
    Public Material As Material
    Public RotationMatrix As SharpDX.Matrix

    Public Sub New(ByRef Mesh As Mesh, ByRef Material As Material, ByRef RotationMatrix As SharpDX.Matrix)
        Me.Mesh = Mesh
        Me.Material = Material
        Me.RotationMatrix = RotationMatrix
    End Sub

    Public Sub Clear()
        'Shouldn't happen since the ObjectCache gets cleared first
        Mesh?.Dispose()
        Mesh = Nothing
        Material = Nothing
        RotationMatrix = Nothing
    End Sub

    Public Shared Function Build(ByRef SimObject As SimulationObject, ByRef DXDevice As Device, ByRef Scale As Single, ByRef Complexity1 As Integer, ByRef Complexity2 As Integer, UsingNonDirectionalLights As Boolean) As ObjectDXRenderData
        Return New ObjectDXRenderData(
            CreateMesh(SimObject, DXDevice, Scale, Complexity1, Complexity2, UsingNonDirectionalLights),
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

    Private Shared ReadOnly TESSELATION_ROUNDS As Integer = 2
    Public Shared Function CreateMesh(ByRef SimObject As SimulationObject, ByRef device As Device, ByRef Scale As Single, ByRef Complexity1 As Integer, ByRef Complexity2 As Integer, UsingNonDirectionalLights As Boolean) As Mesh
        'We cache the meshes so that we don't create a unique mesh for every object
        Dim key As String = GetMeshCacheKey(SimObject)
        Dim objectMesh As Mesh
        If Not ObjectMeshCache.TryGetValue(key, objectMesh) Then
            If SimObject.Type = ObjectType.Sphere Then
                objectMesh = CSCompat.CreateSphere(device, ToSingle(Scale * SimObject.Radius), Complexity1, Complexity2)
            ElseIf SimObject.Type = ObjectType.Box Then
                objectMesh = CSCompat.CreateBox(device, ToSingle(Scale * SimObject.Size.X), ToSingle(Scale * SimObject.Size.Y), ToSingle(Scale * SimObject.Size.Z))
            ElseIf SimObject.Type = ObjectType.Plane Then
                objectMesh = CSCompat.CreateBox(device, ToSingle(Scale * SimObject.Size.X), ToSingle(Scale * SimObject.Size.Y), ToSingle(Scale * 0.0001))
            ElseIf SimObject.Type = ObjectType.InfinitePlane Then
                objectMesh = CSCompat.CreateBox(device, Scale * 2000, ToSingle(Scale * 0.0001), Scale * 2000)
            End If

            'Since we are using fixed-function vertex lighting (instead of pixel shaders), we need a more complicated mesh for the lights to shine properly.
            If Not SimObject.Type = ObjectType.Sphere And UsingNonDirectionalLights Then
                'Not the most efficient way to do this, an more intelligent tessellator would be better 
                For i = 1 To TESSELATION_ROUNDS
                    Dim newObjectMesh = TessellateMesh(device, objectMesh)
                    objectMesh.Dispose() 'Won't be needing this anymore!
                    objectMesh = newObjectMesh
                Next
            End If

            ObjectMeshCache.Add(key, objectMesh)
        End If

        Return objectMesh
    End Function

    Private Shared Function GetMeshCacheKey(ByRef SimObject As SimulationObject) As String
        Dim key As String = SimObject.Type.ToString

        'Don't bother with a string builder, not enough concatenations
        If SimObject.Type = ObjectType.Sphere Then
            key &= SimObject.Radius
        ElseIf SimObject.Type = ObjectType.Box Or SimObject.Type = ObjectType.Plane Then
            key &= SimObject.Size.ToString
        End If

        Return key
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
        'This function will divide each triangle of the mesh into 4 triangles
        'The old mesh will not be distroyed

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
        'Each triangle will be split into four, doubling the index count
        'We are adding 3 midpoint vertices for each triangle and sharing the other vertices 
        Dim newVertexCount As Integer = oldVertexCount + oldIndexCount
        Dim newIndexCount As Integer = oldIndexCount * 4

        'Create the new buffers
        Dim newVertices(newVertexCount - 1) As MeshVertex
        Dim newIndices(newIndexCount - 1) As Int16

        'Don't change any of the existing triangles
        Array.Copy(oldVertices, newVertices, oldVertexCount)

        'Start inserting new vertices and the end of the existing ones
        Dim newVertexIndex As Int16 = oldVertexCount

        'Loop for each existing triangle (3 indices per triangle)
        For i As Integer = 0 To oldIndexCount - 1 Step 3

            Dim indexA As Int16 = oldIndices(i)
            Dim indexB As Int16 = oldIndices(i + 1)
            Dim indexC As Int16 = oldIndices(i + 2)

            Dim A As MeshVertex = oldVertices(indexA)
            Dim B As MeshVertex = oldVertices(indexB)
            Dim C As MeshVertex = oldVertices(indexC)

            'Calculate the midpoint of A and B
            Dim indexMidAB As Int16 = newVertexIndex
            Dim midAB As Vector3 = (A.Position + B.Position) / 2
            Dim midABNormal As Vector3 = (A.Normal + B.Normal) / 2
            midABNormal.Normalize()

            'Calculate the midpoint of A and C
            Dim indexMidAC As Int16 = newVertexIndex + 1S
            Dim midAC As Vector3 = (A.Position + C.Position) / 2
            Dim midACNormal As Vector3 = (A.Normal + C.Normal) / 2
            midACNormal.Normalize()

            'Calculate the midpoint of B and C
            Dim indexMidBC As Int16 = newVertexIndex + 2S
            Dim midBC As Vector3 = (B.Position + C.Position) / 2
            Dim midBCNormal As Vector3 = (B.Normal + C.Normal) / 2
            midBCNormal.Normalize()

            newVertices(indexMidAB) = New MeshVertex(midAB, midABNormal)
            newVertices(indexMidAC) = New MeshVertex(midAC, midACNormal)
            newVertices(indexMidBC) = New MeshVertex(midBC, midBCNormal)

            Dim indexOffset = i * 4 'Create 4 new indices on ever loop

            'Triangles are wound counter-clockwise by default
            'First triangle uses A, midAB & midAC 
            newIndices(indexOffset) = indexA
            newIndices(indexOffset + 1) = indexMidAB
            newIndices(indexOffset + 2) = indexMidAC

            'Second triangle uses midAC, midBC, C
            newIndices(indexOffset + 3) = indexMidAC
            newIndices(indexOffset + 4) = indexMidBC
            newIndices(indexOffset + 5) = indexC

            'Third triangle uses midAB, B, midBC
            newIndices(indexOffset + 6) = indexMidAB
            newIndices(indexOffset + 7) = indexB
            newIndices(indexOffset + 8) = indexMidBC

            'Fourth triangle uses midAB, midBC, midAC
            newIndices(indexOffset + 9) = indexMidAB
            newIndices(indexOffset + 10) = indexMidBC
            newIndices(indexOffset + 11) = indexMidAC

            newVertexIndex += 3S 'We added 3 new vertices, increment by 3
        Next

        ' Create new buffers and mesh
        Dim newMesh = CSCompat.CreateMeshFVF(device, newIndexCount \ 3, newVertexCount, MeshFlags.Managed, VertexFormat.Position Or VertexFormat.Normal)

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
        Return newMesh
    End Function

    Public Shared Sub ClearMeshCache()
        'Trash all objects
        For Each objectMesh As Mesh In ObjectMeshCache.Values
            If Not IsNothing(objectMesh) Then
                objectMesh.Dispose()
            End If
        Next
        ObjectMeshCache.Clear()
    End Sub
End Class
