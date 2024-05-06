Public Class Distribution
    Public Type As TargetType
    Private Sub RbEven_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbEven.CheckedChanged
        CheckConditionals()
    End Sub
    Private Sub RbNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNormal.CheckedChanged
        CheckConditionals()
    End Sub
    Private Sub RbRandom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRandom.CheckedChanged
        CheckConditionals()
    End Sub
    Private Sub RbPoly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPolynomial.CheckedChanged
        CheckConditionals()
    End Sub
    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Hide()
    End Sub
    Private Sub CmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If ValidateTextBoxes() Then
            DialogResult = DialogResult.OK
            Me.Hide()
        Else
            DialogResult = DialogResult.None
        End If
    End Sub
    Private Sub PlEvenMin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plEvenMin.Click
        ControlPanel.ColorDialog.Color = plEvenMin.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plEvenMin.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub PlEvenMax_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plEvenMax.Click
        ControlPanel.ColorDialog.Color = plEvenMax.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plEvenMax.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub PlNormalMin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plNormalMin.Click
        ControlPanel.ColorDialog.Color = plNormalMin.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plNormalMin.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub PlNormalAvg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plNormalAvg.Click
        ControlPanel.ColorDialog.Color = plNormalAvg.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plNormalAvg.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub PlNormalMax_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plNormalMax.Click
        ControlPanel.ColorDialog.Color = plNormalMax.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plNormalMax.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub PlRandomMin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plRandomMin.Click
        ControlPanel.ColorDialog.Color = plRandomMin.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plRandomMin.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub PlRandomMax_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plRandomMax.Click
        ControlPanel.ColorDialog.Color = plRandomMax.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plRandomMax.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub PlPolynomialA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plPolynomialA.Click
        ControlPanel.ColorDialog.Color = plPolynomialA.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plPolynomialA.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub PlPolynomialB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plPolynomialB.Click
        ControlPanel.ColorDialog.Color = plPolynomialB.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plPolynomialB.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub PlPolynomialC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plPolynomialC.Click
        ControlPanel.ColorDialog.Color = plPolynomialC.BackColor
        ControlPanel.ColorDialog.ShowDialog()
        plPolynomialC.BackColor = ControlPanel.ColorDialog.Color
    End Sub
    Private Sub CheckConditionals()
        Dim isTrackBar As Boolean = (Type = TargetType.TrackBar)
        Dim isColor As Boolean = (Type = TargetType.Color)
        Dim isCount As Boolean = (Type = TargetType.ObjectCount)
        Dim isNumeric As Boolean = (Type = TargetType.Numeric)

        Dim isEven As Boolean = rbEven.Checked
        Dim isNormal As Boolean = rbNormal.Checked
        Dim isRandom As Boolean = rbRandom.Checked
        Dim isPol As Boolean = rbPolynomial.Checked

        'Doesn't apply to object count
        'TODO: Could work with group index but would need ability to reorg groups
        rbEven.Enabled = Not isCount
        rbPolynomial.Enabled = Not isCount

        'Trackbar Enabled
        tbPolynomialA.Enabled = isTrackBar And isPol
        tbPolynomialB.Enabled = isTrackBar And isPol
        tbPolynomialC.Enabled = isTrackBar And isPol
        tbRandomMin.Enabled = isTrackBar And isRandom
        tbRandomMax.Enabled = isTrackBar And isRandom
        tbNormalAvg.Enabled = isTrackBar And isNormal
        tbNormalMax.Enabled = isTrackBar And isNormal
        tbNormalMin.Enabled = isTrackBar And isNormal
        tbEvenMin.Enabled = isTrackBar And isEven
        tbEvenMax.Enabled = isTrackBar And isEven

        'Trackbar Visibility
        tbEvenMin.Visible = isTrackBar
        tbEvenMax.Visible = isTrackBar
        tbNormalAvg.Visible = isTrackBar
        tbNormalMax.Visible = isTrackBar
        tbNormalMin.Visible = isTrackBar
        tbRandomMin.Visible = isTrackBar
        tbRandomMax.Visible = isTrackBar
        tbPolynomialA.Visible = isTrackBar
        tbPolynomialB.Visible = isTrackBar
        tbPolynomialC.Visible = isTrackBar

        'Trackbar Label Visibility
        lbEvenMin.Visible = isTrackBar
        lbEvenMax.Visible = isTrackBar
        lbNormalAvg.Visible = isTrackBar
        lbNormalMax.Visible = isTrackBar
        lbNormalMin.Visible = isTrackBar
        lbRandomMin.Visible = isTrackBar
        lbRandomMax.Visible = isTrackBar
        lbPolynomialA.Visible = isTrackBar
        lbPolynomialB.Visible = isTrackBar
        lbPolynomialC.Visible = isTrackBar

        'Color Picker Enabled
        EnableColorBox(plPolynomialA, isColor And isPol)
        EnableColorBox(plPolynomialB, isColor And isPol)
        EnableColorBox(plPolynomialC, isColor And isPol)
        EnableColorBox(plRandomMin, isColor And isRandom)
        EnableColorBox(plRandomMax, isColor And isRandom)
        EnableColorBox(plNormalAvg, isColor And isNormal)
        EnableColorBox(plNormalMax, isColor And isNormal)
        EnableColorBox(plNormalMin, isColor And isNormal)
        EnableColorBox(plEvenMin, isColor And isEven)
        EnableColorBox(plEvenMax, isColor And isEven)

        'Colour Picker Visibility
        plEvenMin.Visible = isColor
        plEvenMax.Visible = isColor
        plNormalAvg.Visible = isColor
        plNormalMax.Visible = isColor
        plNormalMin.Visible = isColor
        plRandomMin.Visible = isColor
        plRandomMax.Visible = isColor
        plPolynomialA.Visible = isColor
        plPolynomialB.Visible = isColor
        plPolynomialC.Visible = isColor

        'TextBox enabled
        txtPolynomialA.Enabled = (isCount Or isNumeric) And isPol
        txtPolynomialB.Enabled = (isCount Or isNumeric) And isPol
        txtPolynomialC.Enabled = (isCount Or isNumeric) And isPol

        txtRandomMin.Enabled = (isCount Or isNumeric) And isRandom
        txtRandomMax.Enabled = (isCount Or isNumeric) And isRandom

        txtNormalAvg.Enabled = (isCount Or isNumeric) And isNormal
        txtNormalMax.Enabled = (isCount Or isNumeric) And isNormal
        txtNormalMin.Enabled = (isCount Or isNumeric) And isNormal

        txtEvenMin.Enabled = (isCount Or isNumeric) And isEven
        txtEvenMax.Enabled = (isCount Or isNumeric) And isEven

        'TextBox Visibility
        txtEvenMin.Visible = isCount Or isNumeric
        txtEvenMax.Visible = isCount Or isNumeric
        txtNormalAvg.Visible = isCount Or isNumeric
        txtNormalMax.Visible = isCount Or isNumeric
        txtNormalMin.Visible = isCount Or isNumeric
        txtRandomMin.Visible = isCount Or isNumeric
        txtRandomMax.Visible = isCount Or isNumeric
        txtPolynomialA.Visible = isCount Or isNumeric
        txtPolynomialB.Visible = isCount Or isNumeric
        txtPolynomialC.Visible = isCount Or isNumeric
    End Sub
    Private Sub Distribution_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        CheckConditionals()
    End Sub
    Private Function ValidateTextBoxes() As Boolean
        'Sliders and Color Pickers don't need validation
        If Type = TargetType.ObjectCount Or Type = TargetType.Numeric Then
            If rbEven.Checked And Type = TargetType.Numeric Then
                Return ValidateEvenTextBoxes()
            ElseIf rbNormal.Checked Then
                Return ValidateNormalTextBoxes(Type = TargetType.ObjectCount)
            ElseIf rbRandom.Checked Then
                Return ValidateRandomTextBoxes(Type = TargetType.ObjectCount)
            ElseIf rbPolynomial.Checked And Type = TargetType.Numeric Then
                Return ValidatePolyTextBoxes()
            End If
        End If
        Return True
    End Function
    Private Function ValidateEvenTextBoxes() As Boolean
        If Not IsNumeric(txtEvenMin.Text) Then
            MsgBox("Even Distribution Minimum must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtEvenMax.Text) Then
            MsgBox("Even Distribution Maximum must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToDouble(txtEvenMin.Text) > ToDouble(txtEvenMax.Text) Then
            MsgBox("Even Distribution Minimum cannot be greater than Even Distribution Maximum", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        Return True
    End Function
    Private Function ValidatePolyTextBoxes() As Boolean
        If Not IsNumeric(txtPolynomialA.Text) Then
            MsgBox("Polynomial Distribution A must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtPolynomialB.Text) Then
            MsgBox("Polynomial Distribution B must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtPolynomialC.Text) Then
            MsgBox("Polynomial Distribution C must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        Return True
    End Function
    Private Function ValidateNormalTextBoxes(isObjectcount As Boolean) As Boolean
        If Not IsNumeric(txtNormalMin.Text) Then
            MsgBox("Gaussian Distribution Minimum must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If Not IsNumeric(txtNormalAvg.Text) Then
            MsgBox("Gaussian Distribution Average must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If Not IsNumeric(txtNormalMax.Text) Then
            MsgBox("Gaussian Distribution Maximum must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If isObjectcount Then
            If ToDouble(txtNormalMin.Text) <> Int(ToDouble(txtNormalMin.Text)) Then
                MsgBox("Gaussian Distribution Minimum must be of integer value.", MsgBoxStyle.Critical, "Error")
                Return False
            End If
            If ToDouble(txtNormalMax.Text) <> Int(ToDouble(txtNormalMax.Text)) Then
                MsgBox("Gaussian Distribution Maximum must be of integer value.", MsgBoxStyle.Critical, "Error")
                Return False
            End If

            If ToInt32(txtNormalMin.Text) < 1 Then
                MsgBox("Gaussian Distribution Minimum must be greater than or equal to one.", MsgBoxStyle.Critical, "Error")
                Return False
            End If
        End If

        If ToDouble(txtNormalMin.Text) > ToDouble(txtNormalAvg.Text) Then
            MsgBox("Gaussian Distribution Minimum cannot be greater than Gaussian Distribution Average", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToDouble(txtNormalAvg.Text) > ToDouble(txtNormalMax.Text) Then
            MsgBox("Gaussian Distribution Average cannot be greater than Gaussian Distribution Maximum", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        Return True
    End Function
    Private Function ValidateRandomTextBoxes(isObjectcount As Boolean) As Boolean
        If Not IsNumeric(txtRandomMin.Text) Then
            MsgBox("Random Distribution Minimum must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If Not IsNumeric(txtRandomMax.Text) Then
            MsgBox("Random Distribution Maximum must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If isObjectcount Then
            If ToDouble(txtRandomMin.Text) <> Int(ToDouble(txtRandomMin.Text)) Then
                MsgBox("Random Distribution Minimum must be of integer value.", MsgBoxStyle.Critical, "Error")
                Return False
            End If
            If ToDouble(txtRandomMax.Text) <> Int(ToDouble(txtRandomMax.Text)) Then
                MsgBox("Random Distribution Maximum must be of integer value.", MsgBoxStyle.Critical, "Error")
                Return False
            End If
            If ToInt32(txtRandomMin.Text) < 1 Then
                MsgBox("Random Distribution Minimum must be greater than or equal to one.", MsgBoxStyle.Critical, "Error")
                Return False
            End If
        End If

        If ToDouble(txtRandomMin.Text) > ToDouble(txtRandomMax.Text) Then
            MsgBox("Random Distribution Minimum cannot be greater than Random Maximum.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        Return True
    End Function

    Private Sub tbRandomMin_Scroll(sender As Object, e As EventArgs) Handles tbRandomMin.Scroll
        If tbRandomMin.Value > tbRandomMax.Value Then
            tbRandomMin.Value = tbRandomMax.Value
        End If
        lbRandomMin.Text = tbRandomMin.Value.ToString
    End Sub

    Private Sub tbRandomMax_Scroll(sender As Object, e As EventArgs) Handles tbRandomMax.Scroll
        If tbRandomMax.Value < tbRandomMin.Value Then
            tbRandomMax.Value = tbRandomMin.Value
        End If
        lbRandomMax.Text = tbRandomMax.Value.ToString
    End Sub

    Private Sub tbEvenMin_Scroll(sender As Object, e As EventArgs) Handles tbEvenMin.Scroll
        If tbEvenMin.Value > tbEvenMax.Value Then
            tbEvenMin.Value = tbEvenMax.Value
        End If
        lbEvenMin.Text = tbEvenMin.Value.ToString
    End Sub

    Private Sub tbEvenMax_Scroll(sender As Object, e As EventArgs) Handles tbEvenMax.Scroll
        If tbEvenMax.Value < tbEvenMin.Value Then
            tbEvenMax.Value = tbEvenMin.Value
        End If
        lbEvenMax.Text = tbEvenMax.Value.ToString
    End Sub

    Private Sub tbNormalMin_Scroll(sender As Object, e As EventArgs) Handles tbNormalMin.Scroll
        If tbNormalMin.Value > tbNormalAvg.Value Then
            tbNormalMin.Value = tbNormalAvg.Value
        End If
        lbNormalMin.Text = tbNormalMin.Value.ToString
    End Sub

    Private Sub tbNormalMax_Scroll(sender As Object, e As EventArgs) Handles tbNormalMax.Scroll
        If tbNormalMax.Value < tbNormalAvg.Value Then
            tbNormalMax.Value = tbNormalAvg.Value
        End If
        lbNormalMax.Text = tbNormalMax.Value.ToString
    End Sub

    Private Sub tbNormalAvg_Scroll(sender As Object, e As EventArgs) Handles tbNormalAvg.Scroll
        If tbNormalAvg.Value > tbNormalMax.Value Then
            tbNormalAvg.Value = tbNormalMax.Value
        End If
        If tbNormalAvg.Value < tbNormalMin.Value Then
            tbNormalAvg.Value = tbNormalMin.Value
        End If
        lbNormalAvg.Text = tbNormalAvg.Value.ToString
    End Sub

    Private Sub tbPolynomialC_Scroll(sender As Object, e As EventArgs) Handles tbPolynomialC.Scroll
        lbPolynomialC.Text = tbPolynomialC.Value.ToString
    End Sub

    Private Sub tbPolynomialB_Scroll(sender As Object, e As EventArgs) Handles tbPolynomialB.Scroll
        lbPolynomialB.Text = tbPolynomialB.Value.ToString
    End Sub

    Private Sub tbPolynomialA_Scroll(sender As Object, e As EventArgs) Handles tbPolynomialA.Scroll
        lbPolynomialA.Text = tbPolynomialA.Value.ToString
    End Sub


End Class