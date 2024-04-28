Public Structure CalculationCounter
    Public StartValue As Long
    Public StopValue As Long
    Public LimitStart As Long
    Public LimitStop As Long
    Public Frequency As Long
    Public FullCount As Long
    Public LastCount As Long
    Public Sub Clear()
        FullCount = 0
        LastCount = 0
        StartValue = 0
        StopValue = 0
        Frequency = 0
    End Sub
    Public Sub Copy(ByRef Other As CalculationCounter)
        StartValue = Other.StartValue
        StopValue = Other.StopValue
        LimitStart = Other.LimitStart
        LimitStop = Other.LimitStop
        Frequency = Other.Frequency
        FullCount = Other.FullCount
        LastCount = Other.LastCount
    End Sub
End Structure