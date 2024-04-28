Public Class RandNumber
    Public Seed As Double
    Private Current As Double
    Private Const A As Double = 427419669081
    Private Const M As Double = (10 ^ 12) - 11
    Private Const B As Double = 0
    Private Const D As Double = 1 / (M + 1)
    Private Const DefaultSeed As Double = 1
    Private RemainingSkewed As Boolean = False
    Private RemainingNormal As Boolean = False
    Private Out As Double
    Private S As Double
    Private U As Double
    Private V As Double
    Private Temp As Double
    Private ERFX As Double
    Private ERFX2 As Double
    Private ERFX3 As Double
    Private ERFX5 As Double
    Private ERFX7 As Double
    Private ERFX9 As Double
    Private ERFX11 As Double
    Private ERFX13 As Double
    Private ERFX15 As Double
    Private ERFX17 As Double
    Private ERFX19 As Double
    Private ERFX21 As Double
    Private Result As Double
    Public Sub New()
        Seed = DefaultSeed
        Restart()
    End Sub
    Public Sub New(ByRef Seed As Double)
        Me.Seed = Seed
        Restart()
    End Sub
    Public Sub Restart()
        Current = Seed
        Out = 0
        RemainingSkewed = False
        RemainingNormal = False
    End Sub
    Public Function GetNext() As Double
        Current = ((A * Current) + B) Mod M
        Out = Current * D
        Return Out
    End Function
    Public Function GetNextNormal() As Double
        If RemainingNormal = False Then
            Do
                U = GetNext()
                V = GetNext()
                S = (U * U) + (V * V)
                If S > 0 And S <= 1 Then
                    Exit Do
                End If
            Loop
            Temp = Math.Sqrt((-2 * Math.Log(S)) / S)
            U *= Temp
            V *= Temp
            RemainingNormal = True
            Return U
        ElseIf RemainingNormal = True Then
            RemainingNormal = False
            Return V
        End If
    End Function
    Public Function GetNextSkewed(ByVal Mean As Double, ByVal Second As Double) As Double
        Do
            U = GetNext()
            V = GetNext()
            S = (U * U) + (V * V)
            If S > 0 And S <= 1 Then
                Exit Do
            End If
        Loop
        Temp = Math.Sqrt((-Math.Log(S)) / S) * (Second - Mean) * 0.70710678118654757
        U = (U * Temp) + Mean
        'V = (V * Temp) + Mean

        Return U
    End Function
    Public Function GetProbibility(ByVal Value As Double, ByVal Mean As Double, ByVal Min As Double, ByVal Max As Double) As Double
        If Value = Mean Then
            Return 0.5
        ElseIf Value < Mean Then
            ERFX = (Value - Mean) / ((Mean - Min) * 0.70710678118654757)
        ElseIf Value > Mean Then
            ERFX = (Value - Mean) / ((Max - Mean) * 0.70710678118654757)
        End If
        ERFX2 = ERFX * ERFX
        ERFX3 = ERFX * ERFX2
        ERFX5 = ERFX3 * ERFX2
        ERFX7 = ERFX5 * ERFX2
        ERFX9 = ERFX7 * ERFX2
        ERFX11 = ERFX9 * ERFX2
        ERFX13 = ERFX11 * ERFX2
        ERFX15 = ERFX13 * ERFX2
        ERFX17 = ERFX15 * ERFX2
        ERFX19 = ERFX17 * ERFX2
        ERFX21 = ERFX19 * ERFX2
        Result = 0.5 + (0.564189583 * ERFX) - (ERFX3 * 0.18806319433333332) + (ERFX5 * 0.0564189583) - (ERFX7 * 0.013433085309523808) + (ERFX9 * 0.002611988810185185) - (ERFX11 * 0.00042741635075757578) + (ERFX13 * 0.000060276664850427354) - (ERFX15 * 0.0000074628251719576723) + (ERFX17 * 0.00000082310571749533152) - (ERFX19 * 0.000000081829223376728861) + (ERFX21 * 0.0000000074035964007516591)
        If Result < 0 Then
            Return 0
        ElseIf Result > 1 Then
            Return 1
        Else
            Return Result
        End If
    End Function
End Class
