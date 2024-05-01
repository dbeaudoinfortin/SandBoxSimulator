Public MustInherit Class RenderBase
    'Render limiter constants
    Private ReadOnly RenderCounterFrequency As Long
    Private ReadOnly CounterTicks1ms As Long 'The counter frequency in ticks per second
    Private ReadOnly RenderSleepLimit As Long 'Maximum number of ticks willing to sleep, 2 milliseconds

    'Calculation limiter variables
    Private RenderLimitEnabled As Boolean
    Private RenderLimitStart As Long 'Counter at the start of the calculation
    Private RenderLimitStop As Long 'Counter at the end of the calculation
    Private RenderLimitDiff As Long 'Remaining ticks
    Private RenderTimeLimit As Long 'How many ticks we are allowed per loop
    Private RenderSleepTimeMs As Integer

    Protected ReadOnly Sim As SimulationRuntime

    Public Sub New(ByRef simulationRuntime As SimulationRuntime)
        Sim = simulationRuntime

        'Initialize calulation limiter
        QueryPerformanceFrequency(RenderCounterFrequency)
        CounterTicks1ms = RenderCounterFrequency \ 1000
        RenderSleepLimit = CounterTicks1ms * 10 '10 millisecond
    End Sub

    Protected Sub RenderControl()
        Sim.RenderCounter.FullCount += 1
        If RenderLimitEnabled Then

            QueryPerformanceCounter(RenderLimitStop)

            'Calculate how many ticks are remaining
            RenderLimitDiff = RenderTimeLimit - (RenderLimitStop - RenderLimitStart)

            If RenderLimitDiff >= RenderSleepLimit Then
                'Subtract 5ms to discourage oversleeping
                RenderSleepTimeMs = ToInt32((RenderLimitDiff \ CounterTicks1ms) - 5)
                If (RenderSleepTimeMs > 0) Then Thread.Sleep(RenderSleepTimeMs)

                'There may still be a bit of time left over
                QueryPerformanceCounter(RenderLimitStop)
                RenderLimitDiff = RenderTimeLimit - (RenderLimitStop - RenderLimitStart)
            End If

            If RenderLimitDiff > 10 Then 'Less than 10 isn't worth spinning
                Do ' Spin
                    QueryPerformanceCounter(RenderLimitStop)
                    RenderLimitDiff = RenderTimeLimit - (RenderLimitStop - RenderLimitStart)
                Loop While (RenderLimitDiff > 10)
            End If

            'Reset the calulation start for the next round
            RenderLimitStart = RenderLimitStop
        End If

    End Sub

    Protected Sub InitRenderControl()
        'Initialize the render limiter.
        'Check if the limiter is enabled and if we even have enought precision
        Dim RenderLimitNeeded As Boolean = Sim.Config.Render.MaxFPS <> 0 And ((Sim.Config.Render.Mode = 2) Or (Not Sim.Config.Render.VSync))

        'Note: use the actual number of threads allocated, not the number of threads requested
        RenderTimeLimit = If(RenderLimitNeeded, ToInt64((RenderCounterFrequency * Sim.GetRenderThreadCount()) / Sim.Config.Render.MaxFPS), 0)
        RenderLimitEnabled = RenderTimeLimit > 0
        If RenderLimitEnabled Then
            QueryPerformanceCounter(RenderLimitStart)
        End If
    End Sub
End Class
