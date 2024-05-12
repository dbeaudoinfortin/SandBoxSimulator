Imports SharpDX.Direct3D9

Public Structure SimulationRender
    Public Parameters As PresentParameters
    Public Device As Device
    Public Direct3D As Direct3D
    Public UsingTransparency As Boolean
    Public UsingNonDirectionalLights As Boolean
    Public SphereSecondaryComplexity As Integer
    Public Shared ReadOnly RenderLock As New ReaderWriterLockSlim
    Public Sub Clear()
        Device = Nothing
        Direct3D = Nothing
        Parameters = Nothing
        UsingTransparency = False
        UsingNonDirectionalLights = False
        SphereSecondaryComplexity = 0 'Calculated when the renderer is initialized
    End Sub
    Public Sub Copy(ByRef Other As SimulationRender)
        Device = Nothing
        Direct3D = Nothing
        Parameters = Nothing
        SphereSecondaryComplexity = Other.SphereSecondaryComplexity
        UsingTransparency = Other.UsingTransparency
        UsingNonDirectionalLights = Other.UsingNonDirectionalLights
    End Sub
End Structure
