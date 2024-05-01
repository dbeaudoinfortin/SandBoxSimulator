Public Structure SimulationLight
    Public Type As LightType

    Public Color As SimpleColor
    Public Direction As XYZ

    Public Position As XYZ
    Public SpecularColor As SimpleColor
    Public AmbientColor As SimpleColor
    Public AmbientRatio As Integer
    Public Range As Single

    Public AttenuationA As Single
    Public AttenuationB As Single
    Public AttenuationC As Single

    Public InnerCone As Single
    Public OuterCone As Single
    Public Falloff As Single

    Public Sub Copy(ByRef Other As SimulationConfigLight)
        Type = Other.Type
        Color.FromColor(Other.Color)
        SpecularColor.FromColor(Other.SpecularColor)
        AmbientColor.FromColor(Other.AmbientColor)
        Direction = New XYZ(Other.Direction)
        Position = New XYZ(Other.Position)
        AmbientRatio = Other.AmbientRatio
        AttenuationA = Other.AttenuationA
        AttenuationB = Other.AttenuationB
        AttenuationC = Other.AttenuationC
        InnerCone = Other.InnerCone
        OuterCone = Other.OuterCone
        Falloff = Other.Falloff
        Range = Other.Range
    End Sub
End Structure
