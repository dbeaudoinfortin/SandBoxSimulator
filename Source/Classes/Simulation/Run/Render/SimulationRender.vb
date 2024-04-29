Public Structure SimulationRender
    Public Parameters As PresentParameters
    Public Device As Device
    Public Transparency As Boolean
    Public SphereSecondaryComplexity As Integer
    Public Sub Clear()
        Device = Nothing
        Parameters = Nothing
        Transparency = False
        SphereSecondaryComplexity = 0 'Calculated when the renderer is initialized
    End Sub
    Public Sub Copy(ByRef Other As SimulationRender)
        Device = Nothing
        Parameters = Nothing
        SphereSecondaryComplexity = Other.SphereSecondaryComplexity
        Transparency = Other.Transparency
    End Sub
End Structure
