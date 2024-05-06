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
        rbEven = New System.Windows.Forms.RadioButton()
        rbNormal = New System.Windows.Forms.RadioButton()
        rbRandom = New System.Windows.Forms.RadioButton()
        rbPolynomial = New System.Windows.Forms.RadioButton()
        cmdOK = New System.Windows.Forms.Button()
        cmdCancel = New System.Windows.Forms.Button()
        txtEvenMin = New System.Windows.Forms.TextBox()
        txtEvenMax = New System.Windows.Forms.TextBox()
        lblEven = New System.Windows.Forms.Label()
        txtNormalMax = New System.Windows.Forms.TextBox()
        txtNormalMin = New System.Windows.Forms.TextBox()
        txtNormalAvg = New System.Windows.Forms.TextBox()
        lblNormal = New System.Windows.Forms.Label()
        txtRandomMax = New System.Windows.Forms.TextBox()
        txtRandomMin = New System.Windows.Forms.TextBox()
        lblRandom = New System.Windows.Forms.Label()
        txtPolynomialB = New System.Windows.Forms.TextBox()
        txtPolynomialC = New System.Windows.Forms.TextBox()
        txtPolynomialA = New System.Windows.Forms.TextBox()
        lblPoly = New System.Windows.Forms.Label()
        tbEvenMin = New System.Windows.Forms.TrackBar()
        tbEvenMax = New System.Windows.Forms.TrackBar()
        tbRandomMin = New System.Windows.Forms.TrackBar()
        tbRandomMax = New System.Windows.Forms.TrackBar()
        tbNormalMin = New System.Windows.Forms.TrackBar()
        tbNormalAvg = New System.Windows.Forms.TrackBar()
        tbNormalMax = New System.Windows.Forms.TrackBar()
        tbPolynomialA = New System.Windows.Forms.TrackBar()
        tbPolynomialB = New System.Windows.Forms.TrackBar()
        tbPolynomialC = New System.Windows.Forms.TrackBar()
        plRandomMax = New System.Windows.Forms.Button()
        plEvenMax = New System.Windows.Forms.Button()
        plRandomMin = New System.Windows.Forms.Button()
        plEvenMin = New System.Windows.Forms.Button()
        plNormalMin = New System.Windows.Forms.Button()
        plNormalAvg = New System.Windows.Forms.Button()
        plNormalMax = New System.Windows.Forms.Button()
        plPolynomialC = New System.Windows.Forms.Button()
        plPolynomialB = New System.Windows.Forms.Button()
        plPolynomialA = New System.Windows.Forms.Button()
        rbNone = New System.Windows.Forms.RadioButton()
        lbEvenMin = New System.Windows.Forms.Label()
        lbEvenMax = New System.Windows.Forms.Label()
        lbRandomMax = New System.Windows.Forms.Label()
        lbRandomMin = New System.Windows.Forms.Label()
        lbNormalMax = New System.Windows.Forms.Label()
        lbNormalMin = New System.Windows.Forms.Label()
        lbNormalAvg = New System.Windows.Forms.Label()
        lbPolynomialB = New System.Windows.Forms.Label()
        lbPolynomialA = New System.Windows.Forms.Label()
        lbPolynomialC = New System.Windows.Forms.Label()
        CType(tbEvenMin, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbEvenMax, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbRandomMin, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbRandomMax, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbNormalMin, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbNormalAvg, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbNormalMax, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbPolynomialA, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbPolynomialB, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbPolynomialC, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' rbEven
        ' 
        rbEven.AutoSize = True
        rbEven.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rbEven.Location = New Point(6, 15)
        rbEven.Margin = New System.Windows.Forms.Padding(6)
        rbEven.Name = "rbEven"
        rbEven.Size = New Size(225, 31)
        rbEven.TabIndex = 0
        rbEven.Text = "Even Distribution"
        rbEven.UseVisualStyleBackColor = True
        ' 
        ' rbNormal
        ' 
        rbNormal.AutoSize = True
        rbNormal.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rbNormal.Location = New Point(6, 100)
        rbNormal.Margin = New System.Windows.Forms.Padding(6)
        rbNormal.Name = "rbNormal"
        rbNormal.Size = New Size(273, 31)
        rbNormal.TabIndex = 7
        rbNormal.Text = "Gaussian Distribution"
        rbNormal.UseVisualStyleBackColor = True
        ' 
        ' rbRandom
        ' 
        rbRandom.AutoSize = True
        rbRandom.Checked = True
        rbRandom.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rbRandom.Location = New Point(6, 185)
        rbRandom.Margin = New System.Windows.Forms.Padding(6)
        rbRandom.Name = "rbRandom"
        rbRandom.Size = New Size(262, 31)
        rbRandom.TabIndex = 17
        rbRandom.TabStop = True
        rbRandom.Text = "Random Distribution"
        rbRandom.UseVisualStyleBackColor = True
        ' 
        ' rbPolynomial
        ' 
        rbPolynomial.AutoSize = True
        rbPolynomial.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rbPolynomial.Location = New Point(6, 270)
        rbPolynomial.Margin = New System.Windows.Forms.Padding(6)
        rbPolynomial.Name = "rbPolynomial"
        rbPolynomial.Size = New Size(289, 31)
        rbPolynomial.TabIndex = 24
        rbPolynomial.Text = "Polynomial Distribution"
        rbPolynomial.UseVisualStyleBackColor = True
        ' 
        ' cmdOK
        ' 
        cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        cmdOK.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmdOK.Location = New Point(6, 398)
        cmdOK.Margin = New System.Windows.Forms.Padding(6)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New Size(392, 51)
        cmdOK.TabIndex = 34
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        ' 
        ' cmdCancel
        ' 
        cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        cmdCancel.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmdCancel.Location = New Point(400, 398)
        cmdCancel.Margin = New System.Windows.Forms.Padding(6)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New Size(390, 51)
        cmdCancel.TabIndex = 35
        cmdCancel.Text = "Cancel"
        cmdCancel.UseVisualStyleBackColor = True
        ' 
        ' txtEvenMin
        ' 
        txtEvenMin.Enabled = False
        txtEvenMin.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEvenMin.ForeColor = SystemColors.ControlText
        txtEvenMin.Location = New Point(331, 57)
        txtEvenMin.Margin = New System.Windows.Forms.Padding(6)
        txtEvenMin.Name = "txtEvenMin"
        txtEvenMin.Size = New Size(226, 35)
        txtEvenMin.TabIndex = 3
        txtEvenMin.Text = "0"
        txtEvenMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtEvenMax
        ' 
        txtEvenMax.Enabled = False
        txtEvenMax.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEvenMax.ForeColor = SystemColors.ControlText
        txtEvenMax.Location = New Point(564, 57)
        txtEvenMax.Margin = New System.Windows.Forms.Padding(6)
        txtEvenMax.Name = "txtEvenMax"
        txtEvenMax.Size = New Size(226, 35)
        txtEvenMax.TabIndex = 4
        txtEvenMax.Text = "1"
        txtEvenMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' lblEven
        ' 
        lblEven.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEven.Location = New Point(15, 52)
        lblEven.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        lblEven.Name = "lblEven"
        lblEven.Size = New Size(304, 42)
        lblEven.TabIndex = 20
        lblEven.Text = "Min, Max:"
        lblEven.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' txtNormalMax
        ' 
        txtNormalMax.Enabled = False
        txtNormalMax.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtNormalMax.ForeColor = SystemColors.ControlText
        txtNormalMax.Location = New Point(641, 142)
        txtNormalMax.Margin = New System.Windows.Forms.Padding(6)
        txtNormalMax.Name = "txtNormalMax"
        txtNormalMax.Size = New Size(150, 35)
        txtNormalMax.TabIndex = 13
        txtNormalMax.Text = "1"
        txtNormalMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtNormalMin
        ' 
        txtNormalMin.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtNormalMin.ForeColor = SystemColors.ControlText
        txtNormalMin.Location = New Point(331, 142)
        txtNormalMin.Margin = New System.Windows.Forms.Padding(6)
        txtNormalMin.Name = "txtNormalMin"
        txtNormalMin.Size = New Size(150, 35)
        txtNormalMin.TabIndex = 11
        txtNormalMin.Text = "0"
        txtNormalMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtNormalAvg
        ' 
        txtNormalAvg.Enabled = False
        txtNormalAvg.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtNormalAvg.ForeColor = SystemColors.ControlText
        txtNormalAvg.Location = New Point(485, 142)
        txtNormalAvg.Margin = New System.Windows.Forms.Padding(6)
        txtNormalAvg.Name = "txtNormalAvg"
        txtNormalAvg.Size = New Size(148, 35)
        txtNormalAvg.TabIndex = 12
        txtNormalAvg.Text = "0.5"
        txtNormalAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' lblNormal
        ' 
        lblNormal.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNormal.Location = New Point(15, 137)
        lblNormal.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        lblNormal.Name = "lblNormal"
        lblNormal.Size = New Size(304, 42)
        lblNormal.TabIndex = 24
        lblNormal.Text = "Min, Avg, Max:"
        lblNormal.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' txtRandomMax
        ' 
        txtRandomMax.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtRandomMax.ForeColor = SystemColors.ControlText
        txtRandomMax.Location = New Point(564, 227)
        txtRandomMax.Margin = New System.Windows.Forms.Padding(6)
        txtRandomMax.Name = "txtRandomMax"
        txtRandomMax.Size = New Size(226, 35)
        txtRandomMax.TabIndex = 21
        txtRandomMax.Text = "1"
        txtRandomMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtRandomMin
        ' 
        txtRandomMin.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtRandomMin.ForeColor = SystemColors.ControlText
        txtRandomMin.Location = New Point(331, 227)
        txtRandomMin.Margin = New System.Windows.Forms.Padding(6)
        txtRandomMin.Name = "txtRandomMin"
        txtRandomMin.Size = New Size(226, 35)
        txtRandomMin.TabIndex = 20
        txtRandomMin.Text = "0"
        txtRandomMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' lblRandom
        ' 
        lblRandom.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRandom.Location = New Point(15, 222)
        lblRandom.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        lblRandom.Name = "lblRandom"
        lblRandom.Size = New Size(304, 42)
        lblRandom.TabIndex = 27
        lblRandom.Text = "Min, Max:"
        lblRandom.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' txtPolynomialB
        ' 
        txtPolynomialB.Enabled = False
        txtPolynomialB.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPolynomialB.ForeColor = SystemColors.ControlText
        txtPolynomialB.Location = New Point(485, 312)
        txtPolynomialB.Margin = New System.Windows.Forms.Padding(6)
        txtPolynomialB.Name = "txtPolynomialB"
        txtPolynomialB.Size = New Size(148, 35)
        txtPolynomialB.TabIndex = 29
        txtPolynomialB.Text = "1"
        txtPolynomialB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtPolynomialC
        ' 
        txtPolynomialC.Enabled = False
        txtPolynomialC.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPolynomialC.ForeColor = SystemColors.ControlText
        txtPolynomialC.Location = New Point(641, 312)
        txtPolynomialC.Margin = New System.Windows.Forms.Padding(6)
        txtPolynomialC.Name = "txtPolynomialC"
        txtPolynomialC.Size = New Size(150, 35)
        txtPolynomialC.TabIndex = 30
        txtPolynomialC.Text = "0"
        txtPolynomialC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtPolynomialA
        ' 
        txtPolynomialA.Enabled = False
        txtPolynomialA.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPolynomialA.ForeColor = SystemColors.ControlText
        txtPolynomialA.Location = New Point(331, 312)
        txtPolynomialA.Margin = New System.Windows.Forms.Padding(6)
        txtPolynomialA.Name = "txtPolynomialA"
        txtPolynomialA.Size = New Size(150, 35)
        txtPolynomialA.TabIndex = 28
        txtPolynomialA.Text = "0"
        txtPolynomialA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' lblPoly
        ' 
        lblPoly.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPoly.Location = New Point(15, 307)
        lblPoly.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        lblPoly.Name = "lblPoly"
        lblPoly.Size = New Size(304, 42)
        lblPoly.TabIndex = 31
        lblPoly.Text = "An² + Bn + C:"
        lblPoly.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' tbEvenMin
        ' 
        tbEvenMin.BackColor = SystemColors.Control
        tbEvenMin.Enabled = False
        tbEvenMin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbEvenMin.LargeChange = 20
        tbEvenMin.Location = New Point(331, 52)
        tbEvenMin.Margin = New System.Windows.Forms.Padding(6)
        tbEvenMin.Maximum = 200
        tbEvenMin.Name = "tbEvenMin"
        tbEvenMin.Size = New Size(230, 90)
        tbEvenMin.SmallChange = 10
        tbEvenMin.TabIndex = 5
        tbEvenMin.TickFrequency = 5
        tbEvenMin.TickStyle = System.Windows.Forms.TickStyle.None
        tbEvenMin.Value = 50
        ' 
        ' tbEvenMax
        ' 
        tbEvenMax.BackColor = SystemColors.Control
        tbEvenMax.Enabled = False
        tbEvenMax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbEvenMax.LargeChange = 20
        tbEvenMax.Location = New Point(561, 52)
        tbEvenMax.Margin = New System.Windows.Forms.Padding(6)
        tbEvenMax.Maximum = 200
        tbEvenMax.Name = "tbEvenMax"
        tbEvenMax.Size = New Size(230, 90)
        tbEvenMax.SmallChange = 10
        tbEvenMax.TabIndex = 6
        tbEvenMax.TickFrequency = 5
        tbEvenMax.TickStyle = System.Windows.Forms.TickStyle.None
        tbEvenMax.Value = 50
        ' 
        ' tbRandomMin
        ' 
        tbRandomMin.BackColor = SystemColors.Control
        tbRandomMin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbRandomMin.LargeChange = 20
        tbRandomMin.Location = New Point(331, 222)
        tbRandomMin.Margin = New System.Windows.Forms.Padding(6)
        tbRandomMin.Maximum = 200
        tbRandomMin.Name = "tbRandomMin"
        tbRandomMin.Size = New Size(230, 90)
        tbRandomMin.SmallChange = 10
        tbRandomMin.TabIndex = 22
        tbRandomMin.TickFrequency = 5
        tbRandomMin.TickStyle = System.Windows.Forms.TickStyle.None
        tbRandomMin.Value = 50
        ' 
        ' tbRandomMax
        ' 
        tbRandomMax.BackColor = SystemColors.Control
        tbRandomMax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbRandomMax.LargeChange = 20
        tbRandomMax.Location = New Point(561, 222)
        tbRandomMax.Margin = New System.Windows.Forms.Padding(6)
        tbRandomMax.Maximum = 200
        tbRandomMax.Name = "tbRandomMax"
        tbRandomMax.Size = New Size(230, 90)
        tbRandomMax.SmallChange = 10
        tbRandomMax.TabIndex = 23
        tbRandomMax.TickFrequency = 5
        tbRandomMax.TickStyle = System.Windows.Forms.TickStyle.None
        tbRandomMax.Value = 50
        ' 
        ' tbNormalMin
        ' 
        tbNormalMin.BackColor = SystemColors.Control
        tbNormalMin.Enabled = False
        tbNormalMin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbNormalMin.LargeChange = 20
        tbNormalMin.Location = New Point(331, 137)
        tbNormalMin.Margin = New System.Windows.Forms.Padding(6)
        tbNormalMin.Maximum = 200
        tbNormalMin.Name = "tbNormalMin"
        tbNormalMin.Size = New Size(154, 90)
        tbNormalMin.SmallChange = 10
        tbNormalMin.TabIndex = 14
        tbNormalMin.TickFrequency = 5
        tbNormalMin.TickStyle = System.Windows.Forms.TickStyle.None
        tbNormalMin.Value = 50
        ' 
        ' tbNormalAvg
        ' 
        tbNormalAvg.BackColor = SystemColors.Control
        tbNormalAvg.Enabled = False
        tbNormalAvg.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbNormalAvg.LargeChange = 20
        tbNormalAvg.Location = New Point(485, 137)
        tbNormalAvg.Margin = New System.Windows.Forms.Padding(6)
        tbNormalAvg.Maximum = 200
        tbNormalAvg.Name = "tbNormalAvg"
        tbNormalAvg.Size = New Size(152, 90)
        tbNormalAvg.SmallChange = 10
        tbNormalAvg.TabIndex = 15
        tbNormalAvg.TickFrequency = 5
        tbNormalAvg.TickStyle = System.Windows.Forms.TickStyle.None
        tbNormalAvg.Value = 50
        ' 
        ' tbNormalMax
        ' 
        tbNormalMax.BackColor = SystemColors.Control
        tbNormalMax.Enabled = False
        tbNormalMax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbNormalMax.LargeChange = 20
        tbNormalMax.Location = New Point(637, 137)
        tbNormalMax.Margin = New System.Windows.Forms.Padding(6)
        tbNormalMax.Maximum = 200
        tbNormalMax.Name = "tbNormalMax"
        tbNormalMax.Size = New Size(154, 90)
        tbNormalMax.SmallChange = 10
        tbNormalMax.TabIndex = 16
        tbNormalMax.TickFrequency = 5
        tbNormalMax.TickStyle = System.Windows.Forms.TickStyle.None
        tbNormalMax.Value = 50
        ' 
        ' tbPolynomialA
        ' 
        tbPolynomialA.BackColor = SystemColors.Control
        tbPolynomialA.Enabled = False
        tbPolynomialA.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbPolynomialA.LargeChange = 20
        tbPolynomialA.Location = New Point(331, 307)
        tbPolynomialA.Margin = New System.Windows.Forms.Padding(6)
        tbPolynomialA.Maximum = 200
        tbPolynomialA.Name = "tbPolynomialA"
        tbPolynomialA.Size = New Size(154, 90)
        tbPolynomialA.SmallChange = 10
        tbPolynomialA.TabIndex = 31
        tbPolynomialA.TickFrequency = 5
        tbPolynomialA.TickStyle = System.Windows.Forms.TickStyle.None
        tbPolynomialA.Value = 50
        ' 
        ' tbPolynomialB
        ' 
        tbPolynomialB.BackColor = SystemColors.Control
        tbPolynomialB.Enabled = False
        tbPolynomialB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbPolynomialB.LargeChange = 20
        tbPolynomialB.Location = New Point(485, 307)
        tbPolynomialB.Margin = New System.Windows.Forms.Padding(6)
        tbPolynomialB.Maximum = 200
        tbPolynomialB.Name = "tbPolynomialB"
        tbPolynomialB.Size = New Size(152, 90)
        tbPolynomialB.SmallChange = 10
        tbPolynomialB.TabIndex = 32
        tbPolynomialB.TickFrequency = 5
        tbPolynomialB.TickStyle = System.Windows.Forms.TickStyle.None
        tbPolynomialB.Value = 50
        ' 
        ' tbPolynomialC
        ' 
        tbPolynomialC.BackColor = SystemColors.Control
        tbPolynomialC.Enabled = False
        tbPolynomialC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbPolynomialC.LargeChange = 20
        tbPolynomialC.Location = New Point(637, 307)
        tbPolynomialC.Margin = New System.Windows.Forms.Padding(6)
        tbPolynomialC.Maximum = 200
        tbPolynomialC.Name = "tbPolynomialC"
        tbPolynomialC.Size = New Size(154, 90)
        tbPolynomialC.SmallChange = 10
        tbPolynomialC.TabIndex = 33
        tbPolynomialC.TickFrequency = 5
        tbPolynomialC.TickStyle = System.Windows.Forms.TickStyle.None
        tbPolynomialC.Value = 50
        ' 
        ' plRandomMax
        ' 
        plRandomMax.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plRandomMax.FlatAppearance.BorderColor = Color.Black
        plRandomMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plRandomMax.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plRandomMax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plRandomMax.Location = New Point(561, 222)
        plRandomMax.Margin = New System.Windows.Forms.Padding(6)
        plRandomMax.Name = "plRandomMax"
        plRandomMax.Size = New Size(230, 42)
        plRandomMax.TabIndex = 245
        plRandomMax.UseVisualStyleBackColor = False
        ' 
        ' plEvenMax
        ' 
        plEvenMax.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plEvenMax.Enabled = False
        plEvenMax.FlatAppearance.BorderColor = Color.Black
        plEvenMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plEvenMax.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plEvenMax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plEvenMax.Location = New Point(561, 52)
        plEvenMax.Margin = New System.Windows.Forms.Padding(6)
        plEvenMax.Name = "plEvenMax"
        plEvenMax.Size = New Size(230, 42)
        plEvenMax.TabIndex = 246
        plEvenMax.UseVisualStyleBackColor = False
        ' 
        ' plRandomMin
        ' 
        plRandomMin.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plRandomMin.FlatAppearance.BorderColor = Color.Black
        plRandomMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plRandomMin.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plRandomMin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plRandomMin.Location = New Point(331, 222)
        plRandomMin.Margin = New System.Windows.Forms.Padding(6)
        plRandomMin.Name = "plRandomMin"
        plRandomMin.Size = New Size(230, 42)
        plRandomMin.TabIndex = 247
        plRandomMin.UseVisualStyleBackColor = False
        ' 
        ' plEvenMin
        ' 
        plEvenMin.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plEvenMin.Enabled = False
        plEvenMin.FlatAppearance.BorderColor = Color.Black
        plEvenMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plEvenMin.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plEvenMin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plEvenMin.Location = New Point(331, 52)
        plEvenMin.Margin = New System.Windows.Forms.Padding(6)
        plEvenMin.Name = "plEvenMin"
        plEvenMin.Size = New Size(230, 42)
        plEvenMin.TabIndex = 248
        plEvenMin.UseVisualStyleBackColor = False
        ' 
        ' plNormalMin
        ' 
        plNormalMin.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plNormalMin.Enabled = False
        plNormalMin.FlatAppearance.BorderColor = Color.Black
        plNormalMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plNormalMin.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plNormalMin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plNormalMin.Location = New Point(331, 137)
        plNormalMin.Margin = New System.Windows.Forms.Padding(6)
        plNormalMin.Name = "plNormalMin"
        plNormalMin.Size = New Size(154, 42)
        plNormalMin.TabIndex = 249
        plNormalMin.UseVisualStyleBackColor = False
        ' 
        ' plNormalAvg
        ' 
        plNormalAvg.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plNormalAvg.Enabled = False
        plNormalAvg.FlatAppearance.BorderColor = Color.Black
        plNormalAvg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plNormalAvg.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plNormalAvg.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plNormalAvg.Location = New Point(485, 137)
        plNormalAvg.Margin = New System.Windows.Forms.Padding(6)
        plNormalAvg.Name = "plNormalAvg"
        plNormalAvg.Size = New Size(152, 42)
        plNormalAvg.TabIndex = 250
        plNormalAvg.UseVisualStyleBackColor = False
        ' 
        ' plNormalMax
        ' 
        plNormalMax.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plNormalMax.Enabled = False
        plNormalMax.FlatAppearance.BorderColor = Color.Black
        plNormalMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plNormalMax.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plNormalMax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plNormalMax.Location = New Point(637, 137)
        plNormalMax.Margin = New System.Windows.Forms.Padding(6)
        plNormalMax.Name = "plNormalMax"
        plNormalMax.Size = New Size(154, 42)
        plNormalMax.TabIndex = 251
        plNormalMax.UseVisualStyleBackColor = False
        ' 
        ' plPolynomialC
        ' 
        plPolynomialC.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plPolynomialC.Enabled = False
        plPolynomialC.FlatAppearance.BorderColor = Color.Black
        plPolynomialC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plPolynomialC.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plPolynomialC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plPolynomialC.Location = New Point(637, 307)
        plPolynomialC.Margin = New System.Windows.Forms.Padding(6)
        plPolynomialC.Name = "plPolynomialC"
        plPolynomialC.Size = New Size(154, 42)
        plPolynomialC.TabIndex = 254
        plPolynomialC.UseVisualStyleBackColor = False
        ' 
        ' plPolynomialB
        ' 
        plPolynomialB.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plPolynomialB.Enabled = False
        plPolynomialB.FlatAppearance.BorderColor = Color.Black
        plPolynomialB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plPolynomialB.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plPolynomialB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plPolynomialB.Location = New Point(485, 307)
        plPolynomialB.Margin = New System.Windows.Forms.Padding(6)
        plPolynomialB.Name = "plPolynomialB"
        plPolynomialB.Size = New Size(152, 42)
        plPolynomialB.TabIndex = 253
        plPolynomialB.UseVisualStyleBackColor = False
        ' 
        ' plPolynomialA
        ' 
        plPolynomialA.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plPolynomialA.Enabled = False
        plPolynomialA.FlatAppearance.BorderColor = Color.Black
        plPolynomialA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plPolynomialA.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plPolynomialA.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plPolynomialA.Location = New Point(331, 307)
        plPolynomialA.Margin = New System.Windows.Forms.Padding(6)
        plPolynomialA.Name = "plPolynomialA"
        plPolynomialA.Size = New Size(154, 42)
        plPolynomialA.TabIndex = 252
        plPolynomialA.UseVisualStyleBackColor = False
        ' 
        ' rbNone
        ' 
        rbNone.AutoSize = True
        rbNone.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rbNone.Location = New Point(6, 355)
        rbNone.Margin = New System.Windows.Forms.Padding(6)
        rbNone.Name = "rbNone"
        rbNone.Size = New Size(100, 31)
        rbNone.TabIndex = 255
        rbNone.Text = "None"
        rbNone.UseVisualStyleBackColor = True
        ' 
        ' lbEvenMin
        ' 
        lbEvenMin.Location = New Point(331, 98)
        lbEvenMin.Name = "lbEvenMin"
        lbEvenMin.Size = New Size(230, 33)
        lbEvenMin.TabIndex = 256
        lbEvenMin.Text = "50"
        lbEvenMin.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lbEvenMax
        ' 
        lbEvenMax.Location = New Point(554, 98)
        lbEvenMax.Name = "lbEvenMax"
        lbEvenMax.Size = New Size(230, 33)
        lbEvenMax.TabIndex = 257
        lbEvenMax.Text = "50"
        lbEvenMax.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lbRandomMax
        ' 
        lbRandomMax.Location = New Point(554, 268)
        lbRandomMax.Name = "lbRandomMax"
        lbRandomMax.Size = New Size(230, 33)
        lbRandomMax.TabIndex = 259
        lbRandomMax.Text = "50"
        lbRandomMax.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lbRandomMin
        ' 
        lbRandomMin.Location = New Point(331, 268)
        lbRandomMin.Name = "lbRandomMin"
        lbRandomMin.Size = New Size(230, 33)
        lbRandomMin.TabIndex = 258
        lbRandomMin.Text = "50"
        lbRandomMin.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lbNormalMax
        ' 
        lbNormalMax.Location = New Point(646, 183)
        lbNormalMax.Name = "lbNormalMax"
        lbNormalMax.Size = New Size(138, 33)
        lbNormalMax.TabIndex = 260
        lbNormalMax.Text = "50"
        lbNormalMax.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lbNormalMin
        ' 
        lbNormalMin.Location = New Point(331, 183)
        lbNormalMin.Name = "lbNormalMin"
        lbNormalMin.Size = New Size(150, 33)
        lbNormalMin.TabIndex = 261
        lbNormalMin.Text = "50"
        lbNormalMin.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lbNormalAvg
        ' 
        lbNormalAvg.Location = New Point(494, 183)
        lbNormalAvg.Name = "lbNormalAvg"
        lbNormalAvg.Size = New Size(134, 33)
        lbNormalAvg.TabIndex = 262
        lbNormalAvg.Text = "50"
        lbNormalAvg.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lbPolynomialB
        ' 
        lbPolynomialB.Location = New Point(494, 353)
        lbPolynomialB.Name = "lbPolynomialB"
        lbPolynomialB.Size = New Size(134, 33)
        lbPolynomialB.TabIndex = 265
        lbPolynomialB.Text = "50"
        lbPolynomialB.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lbPolynomialA
        ' 
        lbPolynomialA.Location = New Point(331, 353)
        lbPolynomialA.Name = "lbPolynomialA"
        lbPolynomialA.Size = New Size(150, 33)
        lbPolynomialA.TabIndex = 264
        lbPolynomialA.Text = "50"
        lbPolynomialA.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lbPolynomialC
        ' 
        lbPolynomialC.Location = New Point(646, 353)
        lbPolynomialC.Name = "lbPolynomialC"
        lbPolynomialC.Size = New Size(138, 33)
        lbPolynomialC.TabIndex = 263
        lbPolynomialC.Text = "50"
        lbPolynomialC.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Distribution
        ' 
        AutoScaleDimensions = New SizeF(192F, 192F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        ClientSize = New Size(796, 457)
        Controls.Add(lbPolynomialB)
        Controls.Add(lbPolynomialA)
        Controls.Add(lbPolynomialC)
        Controls.Add(lbNormalAvg)
        Controls.Add(lbNormalMin)
        Controls.Add(lbNormalMax)
        Controls.Add(lbRandomMax)
        Controls.Add(lbRandomMin)
        Controls.Add(lbEvenMax)
        Controls.Add(lbEvenMin)
        Controls.Add(tbPolynomialB)
        Controls.Add(tbPolynomialC)
        Controls.Add(tbPolynomialA)
        Controls.Add(tbRandomMin)
        Controls.Add(tbRandomMax)
        Controls.Add(tbNormalMin)
        Controls.Add(tbNormalAvg)
        Controls.Add(tbNormalMax)
        Controls.Add(tbEvenMax)
        Controls.Add(tbEvenMin)
        Controls.Add(rbNone)
        Controls.Add(cmdCancel)
        Controls.Add(cmdOK)
        Controls.Add(lblPoly)
        Controls.Add(lblRandom)
        Controls.Add(lblNormal)
        Controls.Add(lblEven)
        Controls.Add(rbPolynomial)
        Controls.Add(rbRandom)
        Controls.Add(rbNormal)
        Controls.Add(rbEven)
        Controls.Add(txtEvenMin)
        Controls.Add(txtEvenMax)
        Controls.Add(txtNormalMin)
        Controls.Add(txtNormalAvg)
        Controls.Add(txtNormalMax)
        Controls.Add(txtRandomMin)
        Controls.Add(txtRandomMax)
        Controls.Add(txtPolynomialA)
        Controls.Add(txtPolynomialB)
        Controls.Add(txtPolynomialC)
        Controls.Add(plEvenMax)
        Controls.Add(plEvenMin)
        Controls.Add(plNormalMax)
        Controls.Add(plNormalAvg)
        Controls.Add(plNormalMin)
        Controls.Add(plRandomMin)
        Controls.Add(plRandomMax)
        Controls.Add(plPolynomialC)
        Controls.Add(plPolynomialB)
        Controls.Add(plPolynomialA)
        Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New System.Windows.Forms.Padding(6)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Distribution"
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Text = "SandBox Simulator - Distribution"
        TopMost = True
        CType(tbEvenMin, ComponentModel.ISupportInitialize).EndInit()
        CType(tbEvenMax, ComponentModel.ISupportInitialize).EndInit()
        CType(tbRandomMin, ComponentModel.ISupportInitialize).EndInit()
        CType(tbRandomMax, ComponentModel.ISupportInitialize).EndInit()
        CType(tbNormalMin, ComponentModel.ISupportInitialize).EndInit()
        CType(tbNormalAvg, ComponentModel.ISupportInitialize).EndInit()
        CType(tbNormalMax, ComponentModel.ISupportInitialize).EndInit()
        CType(tbPolynomialA, ComponentModel.ISupportInitialize).EndInit()
        CType(tbPolynomialB, ComponentModel.ISupportInitialize).EndInit()
        CType(tbPolynomialC, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

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
    Friend WithEvents rbNone As System.Windows.Forms.RadioButton
    Friend WithEvents lbEvenMin As System.Windows.Forms.Label
    Friend WithEvents lbEvenMax As System.Windows.Forms.Label
    Friend WithEvents lbRandomMax As System.Windows.Forms.Label
    Friend WithEvents lbRandomMin As System.Windows.Forms.Label
    Friend WithEvents lbNormalMax As System.Windows.Forms.Label
    Friend WithEvents lbNormalMin As System.Windows.Forms.Label
    Friend WithEvents lbNormalAvg As System.Windows.Forms.Label
    Friend WithEvents lbPolynomialB As System.Windows.Forms.Label
    Friend WithEvents lbPolynomialA As System.Windows.Forms.Label
    Friend WithEvents lbPolynomialC As System.Windows.Forms.Label
End Class
