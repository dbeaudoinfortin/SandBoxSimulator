
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
                SyncLock SimulationCamera.CameraMoveLock
                    Simulation.Camera.MoveUp = True
                End SyncLock
            Case Keys.S
                SyncLock SimulationCamera.CameraMoveLock
                    Simulation.Camera.MoveDown = True
                End SyncLock
            Case Keys.D
                SyncLock SimulationCamera.CameraMoveLock
                    Simulation.Camera.MoveRight = True
                End SyncLock
            Case Keys.A
                SyncLock SimulationCamera.CameraMoveLock
                    Simulation.Camera.MoveLeft = True
                End SyncLock
            Case Keys.Up
                SyncLock SimulationCamera.CameraMoveLock
                    Simulation.Camera.MoveBack = True
                End SyncLock
            Case Keys.Down
                SyncLock SimulationCamera.CameraMoveLock
                    Simulation.Camera.MoveFront = True
                End SyncLock
        End Select
    End Sub
    Private Sub Output_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.W
                SyncLock SimulationCamera.CameraMoveLock
                    Simulation.Camera.MoveUp = False
                End SyncLock
            Case Keys.S
                SyncLock SimulationCamera.CameraMoveLock
                    Simulation.Camera.MoveDown = False
                End SyncLock
            Case Keys.D
                SyncLock SimulationCamera.CameraMoveLock
                    Simulation.Camera.MoveRight = False
                End SyncLock
            Case Keys.A
                SyncLock SimulationCamera.CameraMoveLock
                    Simulation.Camera.MoveLeft = False
                End SyncLock
            Case Keys.Up
                SyncLock SimulationCamera.CameraMoveLock
                    Simulation.Camera.MoveBack = False
                End SyncLock
            Case Keys.Down
                SyncLock SimulationCamera.CameraMoveLock
                    Simulation.Camera.MoveFront = False
                End SyncLock

            Case Keys.Space
                If Not Simulation.Paused Then
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

    Private Sub Output_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        SyncLock SimulationCamera.CameraMoveLock
            Simulation.Camera.MoveUp = False
            Simulation.Camera.MoveDown = False
            Simulation.Camera.MoveRight = False
            Simulation.Camera.MoveLeft = False
            Simulation.Camera.MoveBack = False
            Simulation.Camera.MoveFront = False
        End SyncLock
    End Sub
End Class