Imports SharpDX.Direct3D9

Public Structure SimulationRender
    Public Parameters As PresentParameters
    Public Device As Device
    Public Direct3D As Direct3D
    Public Transparency As Boolean
    Public SphereSecondaryComplexity As Integer
    Public Shared RenderLock As New ReaderWriterLockSlim
    Public Sub Clear()
        Device = Nothing
        Direct3D = Nothing
        Parameters = Nothing
        Transparency = False
        SphereSecondaryComplexity = 0 'Calculated when the renderer is initialized
    End Sub
    Public Sub Copy(ByRef Other As SimulationRender)
        Device = Nothing
        Direct3D = Nothing
        Parameters = Nothing
        SphereSecondaryComplexity = Other.SphereSecondaryComplexity
        Transparency = Other.Transparency
    End Sub
End Structure
