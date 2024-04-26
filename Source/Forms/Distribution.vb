Public Class Distribution
    Public Type As TargetType

    Public Even As Boolean
    Public Normal As Boolean
    Public Random As Boolean
    Public Polynomial As Boolean

    Public EvenMin As String
    Public EvenMax As String
    Public NormalMin As String
    Public NormalMax As String
    Public NormalAvg As String
    Public RandomMin As String
    Public RandomMax As String
    Public PolynomialA As String
    Public PolynomialB As String
    Public PolynomialC As String
    Private Sub rbEven_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbEven.CheckedChanged
        Even = rbEven.Checked
        CheckConditionals()
    End Sub
    Private Sub rbNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNormal.CheckedChanged
        Normal = rbNormal.Checked
        CheckConditionals()
    End Sub
    Private Sub rbRandom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRandom.CheckedChanged
        Random = rbRandom.Checked
        CheckConditionals()
    End Sub
    Private Sub rbPoly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPolynomial.CheckedChanged
        Polynomial = rbPolynomial.Checked
        CheckConditionals()
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Hide()
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.Hide()
    End Sub
    Private Sub plEvenMin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plEvenMin.Click
        ControlPanel.ColorDialog.Color = plEvenMin.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plEvenMin.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub plEvenMax_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plEvenMax.Click
        ControlPanel.ColorDialog.Color = plEvenMax.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plEvenMax.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub plNormalMin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plNormalMin.Click
        ControlPanel.ColorDialog.Color = plNormalMin.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plNormalMin.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub plNormalAvg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plNormalAvg.Click
        ControlPanel.ColorDialog.Color = plNormalAvg.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plNormalAvg.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub plNormalMax_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plNormalMax.Click
        ControlPanel.ColorDialog.Color = plNormalMax.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plNormalMax.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub plRandomMin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plRandomMin.Click
        ControlPanel.ColorDialog.Color = plRandomMin.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plRandomMin.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub plRandomMax_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plRandomMax.Click
        ControlPanel.ColorDialog.Color = plRandomMax.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plRandomMax.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub plPolynomialA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plPolynomialA.Click
        ControlPanel.ColorDialog.Color = plPolynomialA.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plPolynomialA.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub plPolynomialB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plPolynomialB.Click
        ControlPanel.ColorDialog.Color = plPolynomialB.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plPolynomialB.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub plPolynomialC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plPolynomialC.Click
        ControlPanel.ColorDialog.Color = plPolynomialC.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plPolynomialC.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub CheckConditionals()
        If Type = TargetType.Color Then
            rbEven.Enabled = True
            rbPolynomial.Enabled = True
            rbRandom.Enabled = True
            rbNormal.Enabled = True

            txtPolynomialA.Enabled = False
            txtPolynomialB.Enabled = False
            txtPolynomialC.Enabled = False
            txtRandomMin.Enabled = False
            txtRandomMax.Enabled = False
            txtNormalAvg.Enabled = False
            txtNormalMax.Enabled = False
            txtNormalMin.Enabled = False
            txtEvenMin.Enabled = False
            txtEvenMax.Enabled = False

            txtEvenMin.Visible = False
            txtEvenMax.Visible = False
            txtNormalAvg.Visible = False
            txtNormalMax.Visible = False
            txtNormalMin.Visible = False
            txtRandomMin.Visible = False
            txtRandomMax.Visible = False
            txtPolynomialA.Visible = False
            txtPolynomialB.Visible = False
            txtPolynomialC.Visible = False

            If rbPolynomial.Checked Then
                EnableColorBox(plPolynomialA, True)
                EnableColorBox(plPolynomialB, True)
                EnableColorBox(plPolynomialC, True)
            Else
                EnableColorBox(plPolynomialA, False)
                EnableColorBox(plPolynomialB, False)
                EnableColorBox(plPolynomialC, False)
            End If
            If rbRandom.Checked Then
                EnableColorBox(plRandomMin, True)
                EnableColorBox(plRandomMax, True)
            Else
                EnableColorBox(plRandomMin, False)
                EnableColorBox(plRandomMax, False)
            End If
            If rbNormal.Checked Then
                EnableColorBox(plNormalAvg, True)
                EnableColorBox(plNormalMax, True)
                EnableColorBox(plNormalMin, True)
            Else
                EnableColorBox(plNormalAvg, False)
                EnableColorBox(plNormalMax, False)
                EnableColorBox(plNormalMin, False)
            End If
            If rbEven.Checked Then
                EnableColorBox(plEvenMin, True)
                EnableColorBox(plEvenMax, True)
            Else
                EnableColorBox(plEvenMin, False)
                EnableColorBox(plEvenMax, False)
            End If

            plEvenMin.Visible = True
            plEvenMax.Visible = True
            plNormalAvg.Visible = True
            plNormalMax.Visible = True
            plNormalMin.Visible = True
            plRandomMin.Visible = True
            plRandomMax.Visible = True
            plPolynomialA.Visible = True
            plPolynomialB.Visible = True
            plPolynomialC.Visible = True

            tbPolynomialA.Enabled = False
            tbPolynomialB.Enabled = False
            tbPolynomialC.Enabled = False
            tbRandomMin.Enabled = False
            tbRandomMax.Enabled = False
            tbNormalAvg.Enabled = False
            tbNormalMax.Enabled = False
            tbNormalMin.Enabled = False
            tbEvenMin.Enabled = False
            tbEvenMax.Enabled = False

            tbEvenMin.Visible = False
            tbEvenMax.Visible = False
            tbNormalAvg.Visible = False
            tbNormalMax.Visible = False
            tbNormalMin.Visible = False
            tbRandomMin.Visible = False
            tbRandomMax.Visible = False
            tbPolynomialA.Visible = False
            tbPolynomialB.Visible = False
            tbPolynomialC.Visible = False

        ElseIf Type = TargetType.Number Then
            rbEven.Enabled = False
            rbPolynomial.Enabled = False
            rbRandom.Enabled = True
            rbNormal.Enabled = True


            If rbRandom.Checked Then
                txtRandomMin.Enabled = True
                txtRandomMax.Enabled = True
            Else
                txtRandomMin.Enabled = False
                txtRandomMax.Enabled = False
            End If
            If rbNormal.Checked Then
                txtNormalAvg.Enabled = True
                txtNormalMax.Enabled = True
                txtNormalMin.Enabled = True
            Else
                txtNormalAvg.Enabled = False
                txtNormalMax.Enabled = False
                txtNormalMin.Enabled = False
            End If

            txtPolynomialA.Enabled = False
            txtPolynomialB.Enabled = False
            txtPolynomialC.Enabled = False
            txtEvenMin.Enabled = False
            txtEvenMax.Enabled = False

            txtEvenMin.Visible = True
            txtEvenMax.Visible = True
            txtNormalAvg.Visible = True
            txtNormalMax.Visible = True
            txtNormalMin.Visible = True
            txtRandomMin.Visible = True
            txtRandomMax.Visible = True
            txtPolynomialA.Visible = True
            txtPolynomialB.Visible = True
            txtPolynomialC.Visible = True

            EnableColorBox(plPolynomialA, False)
            EnableColorBox(plPolynomialB, False)
            EnableColorBox(plPolynomialC, False)
            EnableColorBox(plRandomMin, False)
            EnableColorBox(plRandomMax, False)
            EnableColorBox(plNormalAvg, False)
            EnableColorBox(plNormalMax, False)
            EnableColorBox(plNormalMin, False)
            EnableColorBox(plEvenMin, False)
            EnableColorBox(plEvenMax, False)

            plEvenMin.Visible = False
            plEvenMax.Visible = False
            plNormalAvg.Visible = False
            plNormalMax.Visible = False
            plNormalMin.Visible = False
            plRandomMin.Visible = False
            plRandomMax.Visible = False
            plPolynomialA.Visible = False
            plPolynomialB.Visible = False
            plPolynomialC.Visible = False

            tbPolynomialA.Enabled = False
            tbPolynomialB.Enabled = False
            tbPolynomialC.Enabled = False
            tbRandomMin.Enabled = False
            tbRandomMax.Enabled = False
            tbNormalAvg.Enabled = False
            tbNormalMax.Enabled = False
            tbNormalMin.Enabled = False
            tbEvenMin.Enabled = False
            tbEvenMax.Enabled = False

            tbEvenMin.Visible = False
            tbEvenMax.Visible = False
            tbNormalAvg.Visible = False
            tbNormalMax.Visible = False
            tbNormalMin.Visible = False
            tbRandomMin.Visible = False
            tbRandomMax.Visible = False
            tbPolynomialA.Visible = False
            tbPolynomialB.Visible = False
            tbPolynomialC.Visible = False

        ElseIf Type = TargetType.Text Then
            rbEven.Enabled = True
            rbPolynomial.Enabled = True
            rbRandom.Enabled = True
            rbNormal.Enabled = True

            If rbPolynomial.Checked Then
                txtPolynomialA.Enabled = True
                txtPolynomialB.Enabled = True
                txtPolynomialC.Enabled = True
            Else
                txtPolynomialA.Enabled = False
                txtPolynomialB.Enabled = False
                txtPolynomialC.Enabled = False
            End If
            If rbRandom.Checked Then
                txtRandomMin.Enabled = True
                txtRandomMax.Enabled = True
            Else
                txtRandomMin.Enabled = False
                txtRandomMax.Enabled = False
            End If
            If rbNormal.Checked Then
                txtNormalAvg.Enabled = True
                txtNormalMax.Enabled = True
                txtNormalMin.Enabled = True
            Else
                txtNormalAvg.Enabled = False
                txtNormalMax.Enabled = False
                txtNormalMin.Enabled = False
            End If
            If rbEven.Checked Then
                txtEvenMin.Enabled = True
                txtEvenMax.Enabled = True
            Else
                txtEvenMin.Enabled = False
                txtEvenMax.Enabled = False
            End If

            txtEvenMin.Visible = True
            txtEvenMax.Visible = True
            txtNormalAvg.Visible = True
            txtNormalMax.Visible = True
            txtNormalMin.Visible = True
            txtRandomMin.Visible = True
            txtRandomMax.Visible = True
            txtPolynomialA.Visible = True
            txtPolynomialB.Visible = True
            txtPolynomialC.Visible = True

            EnableColorBox(plPolynomialA, False)
            EnableColorBox(plPolynomialB, False)
            EnableColorBox(plPolynomialC, False)
            EnableColorBox(plRandomMin, False)
            EnableColorBox(plRandomMax, False)
            EnableColorBox(plNormalAvg, False)
            EnableColorBox(plNormalMax, False)
            EnableColorBox(plNormalMin, False)
            EnableColorBox(plEvenMin, False)
            EnableColorBox(plEvenMax, False)

            plEvenMin.Visible = False
            plEvenMax.Visible = False
            plNormalAvg.Visible = False
            plNormalMax.Visible = False
            plNormalMin.Visible = False
            plRandomMin.Visible = False
            plRandomMax.Visible = False
            plPolynomialA.Visible = False
            plPolynomialB.Visible = False
            plPolynomialC.Visible = False

            tbPolynomialA.Enabled = False
            tbPolynomialB.Enabled = False
            tbPolynomialC.Enabled = False
            tbRandomMin.Enabled = False
            tbRandomMax.Enabled = False
            tbNormalAvg.Enabled = False
            tbNormalMax.Enabled = False
            tbNormalMin.Enabled = False
            tbEvenMin.Enabled = False
            tbEvenMax.Enabled = False

            tbEvenMin.Visible = False
            tbEvenMax.Visible = False
            tbNormalAvg.Visible = False
            tbNormalMax.Visible = False
            tbNormalMin.Visible = False
            tbRandomMin.Visible = False
            tbRandomMax.Visible = False
            tbPolynomialA.Visible = False
            tbPolynomialB.Visible = False
            tbPolynomialC.Visible = False
        ElseIf Type = TargetType.TrackBar Then
            rbEven.Enabled = True
            rbPolynomial.Enabled = True
            rbRandom.Enabled = True
            rbNormal.Enabled = True

            txtPolynomialA.Enabled = False
            txtPolynomialB.Enabled = False
            txtPolynomialC.Enabled = False
            txtRandomMin.Enabled = False
            txtRandomMax.Enabled = False
            txtNormalAvg.Enabled = False
            txtNormalMax.Enabled = False
            txtNormalMin.Enabled = False
            txtEvenMin.Enabled = False
            txtEvenMax.Enabled = False

            txtEvenMin.Visible = False
            txtEvenMax.Visible = False
            txtNormalAvg.Visible = False
            txtNormalMax.Visible = False
            txtNormalMin.Visible = False
            txtRandomMin.Visible = False
            txtRandomMax.Visible = False
            txtPolynomialA.Visible = False
            txtPolynomialB.Visible = False
            txtPolynomialC.Visible = False

            EnableColorBox(plPolynomialA, False)
            EnableColorBox(plPolynomialB, False)
            EnableColorBox(plPolynomialC, False)
            EnableColorBox(plRandomMin, False)
            EnableColorBox(plRandomMax, False)
            EnableColorBox(plNormalAvg, False)
            EnableColorBox(plNormalMax, False)
            EnableColorBox(plNormalMin, False)
            EnableColorBox(plEvenMin, False)
            EnableColorBox(plEvenMax, False)

            plEvenMin.Visible = False
            plEvenMax.Visible = False
            plNormalAvg.Visible = False
            plNormalMax.Visible = False
            plNormalMin.Visible = False
            plRandomMin.Visible = False
            plRandomMax.Visible = False
            plPolynomialA.Visible = False
            plPolynomialB.Visible = False
            plPolynomialC.Visible = False

            If rbPolynomial.Checked Then
                tbPolynomialA.Enabled = True
                tbPolynomialB.Enabled = True
                tbPolynomialC.Enabled = True
            Else
                tbPolynomialA.Enabled = False
                tbPolynomialB.Enabled = False
                tbPolynomialC.Enabled = False
            End If
            If rbRandom.Checked Then
                tbRandomMin.Enabled = True
                tbRandomMax.Enabled = True
            Else
                tbRandomMin.Enabled = False
                tbRandomMax.Enabled = False
            End If
            If rbNormal.Checked Then
                tbNormalAvg.Enabled = True
                tbNormalMax.Enabled = True
                tbNormalMin.Enabled = True
            Else
                tbNormalAvg.Enabled = False
                tbNormalMax.Enabled = False
                tbNormalMin.Enabled = False
            End If
            If rbEven.Checked Then
                tbEvenMin.Enabled = True
                tbEvenMax.Enabled = True
            Else
                tbEvenMin.Enabled = False
                tbEvenMax.Enabled = False
            End If
            tbEvenMin.Visible = True
            tbEvenMax.Visible = True
            tbNormalAvg.Visible = True
            tbNormalMax.Visible = True
            tbNormalMin.Visible = True
            tbRandomMin.Visible = True
            tbRandomMax.Visible = True
            tbPolynomialA.Visible = True
            tbPolynomialB.Visible = True
            tbPolynomialC.Visible = True
        End If
    End Sub
    Private Sub Distribution_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        CheckConditionals()
    End Sub

    Private Sub Distribution_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class