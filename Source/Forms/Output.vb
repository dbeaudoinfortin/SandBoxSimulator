
Imports System.Windows.Forms

Public Class Output
    Private Sub Output_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If ControlPanel.cmdStart.Text = "&End Simulation" Then
            ControlPanel.cmdStart.PerformClick()
        End If
    End Sub
    Private Sub Output_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.W
                Simulation.Camera.MoveUp = True
            Case Keys.S
                Simulation.Camera.MoveDown = True
            Case Keys.D
                Simulation.Camera.MoveRight = True
            Case Keys.A
                Simulation.Camera.MoveLeft = True
            Case Keys.Up
                Simulation.Camera.MoveBack = True
            Case Keys.Down
                Simulation.Camera.MoveFront = True
        End Select
    End Sub
    Private Sub Output_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.W
                Simulation.Camera.MoveUp = False
            Case Keys.S
                Simulation.Camera.MoveDown = False
            Case Keys.D
                Simulation.Camera.MoveRight = False
            Case Keys.A
                Simulation.Camera.MoveLeft = False
            Case Keys.Up
                Simulation.Camera.MoveBack = False
            Case Keys.Down
                Simulation.Camera.MoveFront = False

            Case Keys.Space
                If Not Simulation.isPaused Then
                    Simulation.PauseSimulation()
                Else
                    Simulation.ResumeSimulation()
                End If
        End Select
    End Sub
    Private Sub CameraUpdate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CameraUpdate.Tick
        'Check for any changes with the camera
        Simulation.Camera.Move()
    End Sub
End Class