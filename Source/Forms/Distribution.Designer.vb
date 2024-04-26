<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Distribution
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Distribution))
        Me.rbEven = New System.Windows.Forms.RadioButton()
        Me.rbNormal = New System.Windows.Forms.RadioButton()
        Me.rbRandom = New System.Windows.Forms.RadioButton()
        Me.rbPolynomial = New System.Windows.Forms.RadioButton()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtEvenMin = New System.Windows.Forms.TextBox()
        Me.txtEvenMax = New System.Windows.Forms.TextBox()
        Me.lblEven = New System.Windows.Forms.Label()
        Me.txtNormalMax = New System.Windows.Forms.TextBox()
        Me.txtNormalMin = New System.Windows.Forms.TextBox()
        Me.txtNormalAvg = New System.Windows.Forms.TextBox()
        Me.lblNormal = New System.Windows.Forms.Label()
        Me.txtRandomMax = New System.Windows.Forms.TextBox()
        Me.txtRandomMin = New System.Windows.Forms.TextBox()
        Me.lblRandom = New System.Windows.Forms.Label()
        Me.txtPolynomialB = New System.Windows.Forms.TextBox()
        Me.txtPolynomialC = New System.Windows.Forms.TextBox()
        Me.txtPolynomialA = New System.Windows.Forms.TextBox()
        Me.lblPoly = New System.Windows.Forms.Label()
        Me.tbEvenMin = New System.Windows.Forms.TrackBar()
        Me.tbEvenMax = New System.Windows.Forms.TrackBar()
        Me.tbRandomMin = New System.Windows.Forms.TrackBar()
        Me.tbRandomMax = New System.Windows.Forms.TrackBar()
        Me.tbNormalMin = New System.Windows.Forms.TrackBar()
        Me.tbNormalAvg = New System.Windows.Forms.TrackBar()
        Me.tbNormalMax = New System.Windows.Forms.TrackBar()
        Me.tbPolynomialA = New System.Windows.Forms.TrackBar()
        Me.tbPolynomialB = New System.Windows.Forms.TrackBar()
        Me.tbPolynomialC = New System.Windows.Forms.TrackBar()
        Me.plRandomMax = New System.Windows.Forms.Button()
        Me.plEvenMax = New System.Windows.Forms.Button()
        Me.plRandomMin = New System.Windows.Forms.Button()
        Me.plEvenMin = New System.Windows.Forms.Button()
        Me.plNormalMin = New System.Windows.Forms.Button()
        Me.plNormalAvg = New System.Windows.Forms.Button()
        Me.plNormalMax = New System.Windows.Forms.Button()
        Me.plPolynomialC = New System.Windows.Forms.Button()
        Me.plPolynomialB = New System.Windows.Forms.Button()
        Me.plPolynomialA = New System.Windows.Forms.Button()
        CType(Me.tbEvenMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEvenMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbRandomMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbRandomMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNormalMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNormalAvg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNormalMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPolynomialA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPolynomialB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPolynomialC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbEven
        '
        Me.rbEven.AutoSize = True
        Me.rbEven.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEven.Location = New System.Drawing.Point(3, 12)
        Me.rbEven.Name = "rbEven"
        Me.rbEven.Size = New System.Drawing.Size(225, 31)
        Me.rbEven.TabIndex = 0
        Me.rbEven.Text = "Even Distribution"
        Me.rbEven.UseVisualStyleBackColor = True
        '
        'rbNormal
        '
        Me.rbNormal.AutoSize = True
        Me.rbNormal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNormal.Location = New System.Drawing.Point(3, 61)
        Me.rbNormal.Name = "rbNormal"
        Me.rbNormal.Size = New System.Drawing.Size(273, 31)
        Me.rbNormal.TabIndex = 7
        Me.rbNormal.Text = "Gaussian Distribution"
        Me.rbNormal.UseVisualStyleBackColor = True
        '
        'rbRandom
        '
        Me.rbRandom.AutoSize = True
        Me.rbRandom.Checked = True
        Me.rbRandom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRandom.Location = New System.Drawing.Point(3, 110)
        Me.rbRandom.Name = "rbRandom"
        Me.rbRandom.Size = New System.Drawing.Size(262, 31)
        Me.rbRandom.TabIndex = 17
        Me.rbRandom.TabStop = True
        Me.rbRandom.Text = "Random Distribution"
        Me.rbRandom.UseVisualStyleBackColor = True
        '
        'rbPolynomial
        '
        Me.rbPolynomial.AutoSize = True
        Me.rbPolynomial.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPolynomial.Location = New System.Drawing.Point(3, 156)
        Me.rbPolynomial.Name = "rbPolynomial"
        Me.rbPolynomial.Size = New System.Drawing.Size(289, 31)
        Me.rbPolynomial.TabIndex = 24
        Me.rbPolynomial.Text = "Polynomial Distribution"
        Me.rbPolynomial.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(3, 211)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(186, 30)
        Me.cmdOK.TabIndex = 34
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(188, 211)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(203, 30)
        Me.cmdCancel.TabIndex = 35
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtEvenMin
        '
        Me.txtEvenMin.Enabled = False
        Me.txtEvenMin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEvenMin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtEvenMin.Location = New System.Drawing.Point(161, 37)
        Me.txtEvenMin.Name = "txtEvenMin"
        Me.txtEvenMin.Size = New System.Drawing.Size(115, 35)
        Me.txtEvenMin.TabIndex = 3
        Me.txtEvenMin.Text = "0"
        Me.txtEvenMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEvenMax
        '
        Me.txtEvenMax.Enabled = False
        Me.txtEvenMax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEvenMax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtEvenMax.Location = New System.Drawing.Point(276, 37)
        Me.txtEvenMax.Name = "txtEvenMax"
        Me.txtEvenMax.Size = New System.Drawing.Size(115, 35)
        Me.txtEvenMax.TabIndex = 4
        Me.txtEvenMax.Text = "1"
        Me.txtEvenMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEven
        '
        Me.lblEven.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEven.Location = New System.Drawing.Point(3, 37)
        Me.lblEven.Name = "lblEven"
        Me.lblEven.Size = New System.Drawing.Size(152, 21)
        Me.lblEven.TabIndex = 20
        Me.lblEven.Text = "Min, Max:"
        Me.lblEven.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNormalMax
        '
        Me.txtNormalMax.Enabled = False
        Me.txtNormalMax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNormalMax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNormalMax.Location = New System.Drawing.Point(314, 86)
        Me.txtNormalMax.Name = "txtNormalMax"
        Me.txtNormalMax.Size = New System.Drawing.Size(77, 35)
        Me.txtNormalMax.TabIndex = 13
        Me.txtNormalMax.Text = "1"
        Me.txtNormalMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNormalMin
        '
        Me.txtNormalMin.Enabled = False
        Me.txtNormalMin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNormalMin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNormalMin.Location = New System.Drawing.Point(161, 86)
        Me.txtNormalMin.Name = "txtNormalMin"
        Me.txtNormalMin.Size = New System.Drawing.Size(77, 35)
        Me.txtNormalMin.TabIndex = 11
        Me.txtNormalMin.Text = "0"
        Me.txtNormalMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNormalAvg
        '
        Me.txtNormalAvg.Enabled = False
        Me.txtNormalAvg.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNormalAvg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNormalAvg.Location = New System.Drawing.Point(238, 86)
        Me.txtNormalAvg.Name = "txtNormalAvg"
        Me.txtNormalAvg.Size = New System.Drawing.Size(76, 35)
        Me.txtNormalAvg.TabIndex = 12
        Me.txtNormalAvg.Text = "0.5"
        Me.txtNormalAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNormal
        '
        Me.lblNormal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNormal.Location = New System.Drawing.Point(3, 86)
        Me.lblNormal.Name = "lblNormal"
        Me.lblNormal.Size = New System.Drawing.Size(152, 21)
        Me.lblNormal.TabIndex = 24
        Me.lblNormal.Text = "Min, Avg, Max:"
        Me.lblNormal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRandomMax
        '
        Me.txtRandomMax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRandomMax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtRandomMax.Location = New System.Drawing.Point(276, 132)
        Me.txtRandomMax.Name = "txtRandomMax"
        Me.txtRandomMax.Size = New System.Drawing.Size(115, 35)
        Me.txtRandomMax.TabIndex = 21
        Me.txtRandomMax.Text = "1"
        Me.txtRandomMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRandomMin
        '
        Me.txtRandomMin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRandomMin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtRandomMin.Location = New System.Drawing.Point(161, 132)
        Me.txtRandomMin.Name = "txtRandomMin"
        Me.txtRandomMin.Size = New System.Drawing.Size(115, 35)
        Me.txtRandomMin.TabIndex = 20
        Me.txtRandomMin.Text = "0"
        Me.txtRandomMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRandom
        '
        Me.lblRandom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRandom.Location = New System.Drawing.Point(3, 132)
        Me.lblRandom.Name = "lblRandom"
        Me.lblRandom.Size = New System.Drawing.Size(152, 21)
        Me.lblRandom.TabIndex = 27
        Me.lblRandom.Text = "Min, Max:"
        Me.lblRandom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPolynomialB
        '
        Me.txtPolynomialB.Enabled = False
        Me.txtPolynomialB.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolynomialB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPolynomialB.Location = New System.Drawing.Point(238, 181)
        Me.txtPolynomialB.Name = "txtPolynomialB"
        Me.txtPolynomialB.Size = New System.Drawing.Size(76, 35)
        Me.txtPolynomialB.TabIndex = 29
        Me.txtPolynomialB.Text = "1"
        Me.txtPolynomialB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPolynomialC
        '
        Me.txtPolynomialC.Enabled = False
        Me.txtPolynomialC.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolynomialC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPolynomialC.Location = New System.Drawing.Point(314, 181)
        Me.txtPolynomialC.Name = "txtPolynomialC"
        Me.txtPolynomialC.Size = New System.Drawing.Size(77, 35)
        Me.txtPolynomialC.TabIndex = 30
        Me.txtPolynomialC.Text = "0"
        Me.txtPolynomialC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPolynomialA
        '
        Me.txtPolynomialA.Enabled = False
        Me.txtPolynomialA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolynomialA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPolynomialA.Location = New System.Drawing.Point(161, 181)
        Me.txtPolynomialA.Name = "txtPolynomialA"
        Me.txtPolynomialA.Size = New System.Drawing.Size(77, 35)
        Me.txtPolynomialA.TabIndex = 28
        Me.txtPolynomialA.Text = "0"
        Me.txtPolynomialA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPoly
        '
        Me.lblPoly.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoly.Location = New System.Drawing.Point(3, 181)
        Me.lblPoly.Name = "lblPoly"
        Me.lblPoly.Size = New System.Drawing.Size(152, 21)
        Me.lblPoly.TabIndex = 31
        Me.lblPoly.Text = "An² + Bn + C:"
        Me.lblPoly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbEvenMin
        '
        Me.tbEvenMin.BackColor = System.Drawing.SystemColors.Control
        Me.tbEvenMin.Enabled = False
        Me.tbEvenMin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbEvenMin.LargeChange = 20
        Me.tbEvenMin.Location = New System.Drawing.Point(161, 37)
        Me.tbEvenMin.Maximum = 200
        Me.tbEvenMin.Name = "tbEvenMin"
        Me.tbEvenMin.Size = New System.Drawing.Size(115, 90)
        Me.tbEvenMin.SmallChange = 10
        Me.tbEvenMin.TabIndex = 5
        Me.tbEvenMin.TickFrequency = 5
        Me.tbEvenMin.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbEvenMin.Value = 50
        '
        'tbEvenMax
        '
        Me.tbEvenMax.BackColor = System.Drawing.SystemColors.Control
        Me.tbEvenMax.Enabled = False
        Me.tbEvenMax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbEvenMax.LargeChange = 20
        Me.tbEvenMax.Location = New System.Drawing.Point(276, 37)
        Me.tbEvenMax.Maximum = 200
        Me.tbEvenMax.Name = "tbEvenMax"
        Me.tbEvenMax.Size = New System.Drawing.Size(115, 90)
        Me.tbEvenMax.SmallChange = 10
        Me.tbEvenMax.TabIndex = 6
        Me.tbEvenMax.TickFrequency = 5
        Me.tbEvenMax.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbEvenMax.Value = 50
        '
        'tbRandomMin
        '
        Me.tbRandomMin.BackColor = System.Drawing.SystemColors.Control
        Me.tbRandomMin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbRandomMin.LargeChange = 20
        Me.tbRandomMin.Location = New System.Drawing.Point(161, 132)
        Me.tbRandomMin.Maximum = 200
        Me.tbRandomMin.Name = "tbRandomMin"
        Me.tbRandomMin.Size = New System.Drawing.Size(115, 90)
        Me.tbRandomMin.SmallChange = 10
        Me.tbRandomMin.TabIndex = 22
        Me.tbRandomMin.TickFrequency = 5
        Me.tbRandomMin.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbRandomMin.Value = 50
        '
        'tbRandomMax
        '
        Me.tbRandomMax.BackColor = System.Drawing.SystemColors.Control
        Me.tbRandomMax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbRandomMax.LargeChange = 20
        Me.tbRandomMax.Location = New System.Drawing.Point(276, 132)
        Me.tbRandomMax.Maximum = 200
        Me.tbRandomMax.Name = "tbRandomMax"
        Me.tbRandomMax.Size = New System.Drawing.Size(115, 90)
        Me.tbRandomMax.SmallChange = 10
        Me.tbRandomMax.TabIndex = 23
        Me.tbRandomMax.TickFrequency = 5
        Me.tbRandomMax.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbRandomMax.Value = 50
        '
        'tbNormalMin
        '
        Me.tbNormalMin.BackColor = System.Drawing.SystemColors.Control
        Me.tbNormalMin.Enabled = False
        Me.tbNormalMin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbNormalMin.LargeChange = 20
        Me.tbNormalMin.Location = New System.Drawing.Point(161, 86)
        Me.tbNormalMin.Maximum = 200
        Me.tbNormalMin.Name = "tbNormalMin"
        Me.tbNormalMin.Size = New System.Drawing.Size(77, 90)
        Me.tbNormalMin.SmallChange = 10
        Me.tbNormalMin.TabIndex = 14
        Me.tbNormalMin.TickFrequency = 5
        Me.tbNormalMin.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbNormalMin.Value = 50
        '
        'tbNormalAvg
        '
        Me.tbNormalAvg.BackColor = System.Drawing.SystemColors.Control
        Me.tbNormalAvg.Enabled = False
        Me.tbNormalAvg.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbNormalAvg.LargeChange = 20
        Me.tbNormalAvg.Location = New System.Drawing.Point(238, 86)
        Me.tbNormalAvg.Maximum = 200
        Me.tbNormalAvg.Name = "tbNormalAvg"
        Me.tbNormalAvg.Size = New System.Drawing.Size(76, 90)
        Me.tbNormalAvg.SmallChange = 10
        Me.tbNormalAvg.TabIndex = 15
        Me.tbNormalAvg.TickFrequency = 5
        Me.tbNormalAvg.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbNormalAvg.Value = 50
        '
        'tbNormalMax
        '
        Me.tbNormalMax.BackColor = System.Drawing.SystemColors.Control
        Me.tbNormalMax.Enabled = False
        Me.tbNormalMax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbNormalMax.LargeChange = 20
        Me.tbNormalMax.Location = New System.Drawing.Point(314, 86)
        Me.tbNormalMax.Maximum = 200
        Me.tbNormalMax.Name = "tbNormalMax"
        Me.tbNormalMax.Size = New System.Drawing.Size(77, 90)
        Me.tbNormalMax.SmallChange = 10
        Me.tbNormalMax.TabIndex = 16
        Me.tbNormalMax.TickFrequency = 5
        Me.tbNormalMax.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbNormalMax.Value = 50
        '
        'tbPolynomialA
        '
        Me.tbPolynomialA.BackColor = System.Drawing.SystemColors.Control
        Me.tbPolynomialA.Enabled = False
        Me.tbPolynomialA.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbPolynomialA.LargeChange = 20
        Me.tbPolynomialA.Location = New System.Drawing.Point(161, 181)
        Me.tbPolynomialA.Maximum = 200
        Me.tbPolynomialA.Name = "tbPolynomialA"
        Me.tbPolynomialA.Size = New System.Drawing.Size(77, 90)
        Me.tbPolynomialA.SmallChange = 10
        Me.tbPolynomialA.TabIndex = 31
        Me.tbPolynomialA.TickFrequency = 5
        Me.tbPolynomialA.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPolynomialA.Value = 50
        '
        'tbPolynomialB
        '
        Me.tbPolynomialB.BackColor = System.Drawing.SystemColors.Control
        Me.tbPolynomialB.Enabled = False
        Me.tbPolynomialB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbPolynomialB.LargeChange = 20
        Me.tbPolynomialB.Location = New System.Drawing.Point(238, 181)
        Me.tbPolynomialB.Maximum = 200
        Me.tbPolynomialB.Name = "tbPolynomialB"
        Me.tbPolynomialB.Size = New System.Drawing.Size(76, 90)
        Me.tbPolynomialB.SmallChange = 10
        Me.tbPolynomialB.TabIndex = 32
        Me.tbPolynomialB.TickFrequency = 5
        Me.tbPolynomialB.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPolynomialB.Value = 50
        '
        'tbPolynomialC
        '
        Me.tbPolynomialC.BackColor = System.Drawing.SystemColors.Control
        Me.tbPolynomialC.Enabled = False
        Me.tbPolynomialC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbPolynomialC.LargeChange = 20
        Me.tbPolynomialC.Location = New System.Drawing.Point(314, 181)
        Me.tbPolynomialC.Maximum = 200
        Me.tbPolynomialC.Name = "tbPolynomialC"
        Me.tbPolynomialC.Size = New System.Drawing.Size(77, 90)
        Me.tbPolynomialC.SmallChange = 10
        Me.tbPolynomialC.TabIndex = 33
        Me.tbPolynomialC.TickFrequency = 5
        Me.tbPolynomialC.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPolynomialC.Value = 50
        '
        'plRandomMax
        '
        Me.plRandomMax.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plRandomMax.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plRandomMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plRandomMax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plRandomMax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plRandomMax.Location = New System.Drawing.Point(276, 132)
        Me.plRandomMax.Name = "plRandomMax"
        Me.plRandomMax.Size = New System.Drawing.Size(115, 21)
        Me.plRandomMax.TabIndex = 245
        Me.plRandomMax.UseVisualStyleBackColor = False
        '
        'plEvenMax
        '
        Me.plEvenMax.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plEvenMax.Enabled = False
        Me.plEvenMax.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plEvenMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plEvenMax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plEvenMax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plEvenMax.Location = New System.Drawing.Point(276, 37)
        Me.plEvenMax.Name = "plEvenMax"
        Me.plEvenMax.Size = New System.Drawing.Size(115, 21)
        Me.plEvenMax.TabIndex = 246
        Me.plEvenMax.UseVisualStyleBackColor = False
        '
        'plRandomMin
        '
        Me.plRandomMin.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plRandomMin.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plRandomMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plRandomMin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plRandomMin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plRandomMin.Location = New System.Drawing.Point(161, 132)
        Me.plRandomMin.Name = "plRandomMin"
        Me.plRandomMin.Size = New System.Drawing.Size(115, 21)
        Me.plRandomMin.TabIndex = 247
        Me.plRandomMin.UseVisualStyleBackColor = False
        '
        'plEvenMin
        '
        Me.plEvenMin.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plEvenMin.Enabled = False
        Me.plEvenMin.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plEvenMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plEvenMin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plEvenMin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plEvenMin.Location = New System.Drawing.Point(161, 37)
        Me.plEvenMin.Name = "plEvenMin"
        Me.plEvenMin.Size = New System.Drawing.Size(115, 21)
        Me.plEvenMin.TabIndex = 248
        Me.plEvenMin.UseVisualStyleBackColor = False
        '
        'plNormalMin
        '
        Me.plNormalMin.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plNormalMin.Enabled = False
        Me.plNormalMin.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plNormalMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plNormalMin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plNormalMin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plNormalMin.Location = New System.Drawing.Point(161, 86)
        Me.plNormalMin.Name = "plNormalMin"
        Me.plNormalMin.Size = New System.Drawing.Size(77, 21)
        Me.plNormalMin.TabIndex = 249
        Me.plNormalMin.UseVisualStyleBackColor = False
        '
        'plNormalAvg
        '
        Me.plNormalAvg.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plNormalAvg.Enabled = False
        Me.plNormalAvg.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plNormalAvg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plNormalAvg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plNormalAvg.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plNormalAvg.Location = New System.Drawing.Point(238, 86)
        Me.plNormalAvg.Name = "plNormalAvg"
        Me.plNormalAvg.Size = New System.Drawing.Size(76, 21)
        Me.plNormalAvg.TabIndex = 250
        Me.plNormalAvg.UseVisualStyleBackColor = False
        '
        'plNormalMax
        '
        Me.plNormalMax.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plNormalMax.Enabled = False
        Me.plNormalMax.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plNormalMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plNormalMax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plNormalMax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plNormalMax.Location = New System.Drawing.Point(314, 86)
        Me.plNormalMax.Name = "plNormalMax"
        Me.plNormalMax.Size = New System.Drawing.Size(77, 21)
        Me.plNormalMax.TabIndex = 251
        Me.plNormalMax.UseVisualStyleBackColor = False
        '
        'plPolynomialC
        '
        Me.plPolynomialC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plPolynomialC.Enabled = False
        Me.plPolynomialC.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plPolynomialC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plPolynomialC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plPolynomialC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plPolynomialC.Location = New System.Drawing.Point(314, 181)
        Me.plPolynomialC.Name = "plPolynomialC"
        Me.plPolynomialC.Size = New System.Drawing.Size(77, 21)
        Me.plPolynomialC.TabIndex = 254
        Me.plPolynomialC.UseVisualStyleBackColor = False
        '
        'plPolynomialB
        '
        Me.plPolynomialB.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plPolynomialB.Enabled = False
        Me.plPolynomialB.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plPolynomialB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plPolynomialB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plPolynomialB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plPolynomialB.Location = New System.Drawing.Point(238, 181)
        Me.plPolynomialB.Name = "plPolynomialB"
        Me.plPolynomialB.Size = New System.Drawing.Size(76, 21)
        Me.plPolynomialB.TabIndex = 253
        Me.plPolynomialB.UseVisualStyleBackColor = False
        '
        'plPolynomialA
        '
        Me.plPolynomialA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plPolynomialA.Enabled = False
        Me.plPolynomialA.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plPolynomialA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plPolynomialA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plPolynomialA.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plPolynomialA.Location = New System.Drawing.Point(161, 181)
        Me.plPolynomialA.Name = "plPolynomialA"
        Me.plPolynomialA.Size = New System.Drawing.Size(77, 21)
        Me.plPolynomialA.TabIndex = 252
        Me.plPolynomialA.UseVisualStyleBackColor = False
        '
        'Distribution
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(394, 243)
        Me.Controls.Add(Me.plPolynomialC)
        Me.Controls.Add(Me.plPolynomialB)
        Me.Controls.Add(Me.plPolynomialA)
        Me.Controls.Add(Me.plNormalMax)
        Me.Controls.Add(Me.plNormalAvg)
        Me.Controls.Add(Me.plNormalMin)
        Me.Controls.Add(Me.plEvenMin)
        Me.Controls.Add(Me.plRandomMin)
        Me.Controls.Add(Me.plEvenMax)
        Me.Controls.Add(Me.plRandomMax)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblPoly)
        Me.Controls.Add(Me.lblRandom)
        Me.Controls.Add(Me.lblNormal)
        Me.Controls.Add(Me.lblEven)
        Me.Controls.Add(Me.rbPolynomial)
        Me.Controls.Add(Me.rbRandom)
        Me.Controls.Add(Me.rbNormal)
        Me.Controls.Add(Me.rbEven)
        Me.Controls.Add(Me.txtEvenMin)
        Me.Controls.Add(Me.txtEvenMax)
        Me.Controls.Add(Me.tbEvenMin)
        Me.Controls.Add(Me.tbEvenMax)
        Me.Controls.Add(Me.txtNormalMin)
        Me.Controls.Add(Me.txtNormalAvg)
        Me.Controls.Add(Me.txtNormalMax)
        Me.Controls.Add(Me.tbNormalMin)
        Me.Controls.Add(Me.tbNormalAvg)
        Me.Controls.Add(Me.tbNormalMax)
        Me.Controls.Add(Me.txtRandomMin)
        Me.Controls.Add(Me.txtRandomMax)
        Me.Controls.Add(Me.tbRandomMin)
        Me.Controls.Add(Me.tbRandomMax)
        Me.Controls.Add(Me.txtPolynomialA)
        Me.Controls.Add(Me.txtPolynomialB)
        Me.Controls.Add(Me.txtPolynomialC)
        Me.Controls.Add(Me.tbPolynomialA)
        Me.Controls.Add(Me.tbPolynomialB)
        Me.Controls.Add(Me.tbPolynomialC)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Distribution"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SandBox Simulator - Distribution"
        Me.TopMost = True
        CType(Me.tbEvenMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEvenMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbRandomMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbRandomMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNormalMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNormalAvg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNormalMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPolynomialA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPolynomialB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPolynomialC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbEven As System.Windows.Forms.RadioButton
    Friend WithEvents rbNormal As System.Windows.Forms.RadioButton
    Friend WithEvents rbRandom As System.Windows.Forms.RadioButton
    Friend WithEvents rbPolynomial As System.Windows.Forms.RadioButton
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtEvenMin As System.Windows.Forms.TextBox
    Friend WithEvents txtEvenMax As System.Windows.Forms.TextBox
    Friend WithEvents lblEven As System.Windows.Forms.Label
    Friend WithEvents txtNormalMax As System.Windows.Forms.TextBox
    Friend WithEvents txtNormalMin As System.Windows.Forms.TextBox
    Friend WithEvents txtNormalAvg As System.Windows.Forms.TextBox
    Friend WithEvents lblNormal As System.Windows.Forms.Label
    Friend WithEvents txtRandomMax As System.Windows.Forms.TextBox
    Friend WithEvents txtRandomMin As System.Windows.Forms.TextBox
    Friend WithEvents lblRandom As System.Windows.Forms.Label
    Friend WithEvents txtPolynomialB As System.Windows.Forms.TextBox
    Friend WithEvents txtPolynomialC As System.Windows.Forms.TextBox
    Friend WithEvents txtPolynomialA As System.Windows.Forms.TextBox
    Friend WithEvents lblPoly As System.Windows.Forms.Label
    Friend WithEvents tbEvenMin As System.Windows.Forms.TrackBar
    Friend WithEvents tbEvenMax As System.Windows.Forms.TrackBar
    Friend WithEvents tbRandomMin As System.Windows.Forms.TrackBar
    Friend WithEvents tbRandomMax As System.Windows.Forms.TrackBar
    Friend WithEvents tbNormalMin As System.Windows.Forms.TrackBar
    Friend WithEvents tbNormalAvg As System.Windows.Forms.TrackBar
    Friend WithEvents tbNormalMax As System.Windows.Forms.TrackBar
    Friend WithEvents tbPolynomialA As System.Windows.Forms.TrackBar
    Friend WithEvents tbPolynomialB As System.Windows.Forms.TrackBar
    Friend WithEvents tbPolynomialC As System.Windows.Forms.TrackBar
    Friend WithEvents plRandomMax As System.Windows.Forms.Button
    Friend WithEvents plEvenMax As System.Windows.Forms.Button
    Friend WithEvents plRandomMin As System.Windows.Forms.Button
    Friend WithEvents plEvenMin As System.Windows.Forms.Button
    Friend WithEvents plNormalMin As System.Windows.Forms.Button
    Friend WithEvents plNormalAvg As System.Windows.Forms.Button
    Friend WithEvents plNormalMax As System.Windows.Forms.Button
    Friend WithEvents plPolynomialC As System.Windows.Forms.Button
    Friend WithEvents plPolynomialB As System.Windows.Forms.Button
    Friend WithEvents plPolynomialA As System.Windows.Forms.Button
End Class
