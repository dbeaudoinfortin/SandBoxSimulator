<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ControlPanel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlPanel))
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.ColorDialog = New System.Windows.Forms.ColorDialog()
        Me.Stats = New System.Windows.Forms.StatusStrip()
        Me.lblStat = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.StatusUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.TabGroups = New System.Windows.Forms.TabPage()
        Me.gbObjects = New System.Windows.Forms.GroupBox()
        Me.plObjectHighlightColor = New System.Windows.Forms.Button()
        Me.plObjectColor = New System.Windows.Forms.Button()
        Me.cmdObjectRefractiveIndex = New System.Windows.Forms.Button()
        Me.txtObjectRefractiveIndex = New System.Windows.Forms.TextBox()
        Me.lblObjectRefractiveIndex = New System.Windows.Forms.Label()
        Me.lblObjectReflectivity = New System.Windows.Forms.Label()
        Me.cmdObjectReflectivity = New System.Windows.Forms.Button()
        Me.lblObjectType = New System.Windows.Forms.Label()
        Me.cbObjectType = New System.Windows.Forms.ComboBox()
        Me.chObjectWireframe = New System.Windows.Forms.CheckBox()
        Me.chObjectAffected = New System.Windows.Forms.CheckBox()
        Me.chObjectAffects = New System.Windows.Forms.CheckBox()
        Me.cmdObjectNumber = New System.Windows.Forms.Button()
        Me.lblObjectNumber = New System.Windows.Forms.Label()
        Me.listGroups = New System.Windows.Forms.ListBox()
        Me.cmdObjectVelocityZ = New System.Windows.Forms.Button()
        Me.cmdObjectVelocityY = New System.Windows.Forms.Button()
        Me.cmdObjectTransparency = New System.Windows.Forms.Button()
        Me.cmdObjectHighlightSharpness = New System.Windows.Forms.Button()
        Me.cmdObjectPositionZ = New System.Windows.Forms.Button()
        Me.cmdObjectPositionY = New System.Windows.Forms.Button()
        Me.cmdObjectHighlightColor = New System.Windows.Forms.Button()
        Me.cmdObjectColor = New System.Windows.Forms.Button()
        Me.cmdObjectVelocityX = New System.Windows.Forms.Button()
        Me.cmdObjectPositionX = New System.Windows.Forms.Button()
        Me.cmdObjectCharge = New System.Windows.Forms.Button()
        Me.cmdObjectMass = New System.Windows.Forms.Button()
        Me.lblObjectHighlightColor = New System.Windows.Forms.Label()
        Me.lblObjectName = New System.Windows.Forms.Label()
        Me.lblObjectTransparency = New System.Windows.Forms.Label()
        Me.txtObjectVelocityZ = New System.Windows.Forms.TextBox()
        Me.txtObjectName = New System.Windows.Forms.TextBox()
        Me.txtObjectVelocityY = New System.Windows.Forms.TextBox()
        Me.lblObjectMass = New System.Windows.Forms.Label()
        Me.lblObjectCharge = New System.Windows.Forms.Label()
        Me.lblObjectColor = New System.Windows.Forms.Label()
        Me.lblObjectPosition = New System.Windows.Forms.Label()
        Me.lblObjectVelocity = New System.Windows.Forms.Label()
        Me.lblObjectHighlightSharpness = New System.Windows.Forms.Label()
        Me.tbObjectTransparency = New System.Windows.Forms.TrackBar()
        Me.txtObjectPositionZ = New System.Windows.Forms.TextBox()
        Me.txtObjectPositionX = New System.Windows.Forms.TextBox()
        Me.txtObjectPositionY = New System.Windows.Forms.TextBox()
        Me.txtObjectVelocityX = New System.Windows.Forms.TextBox()
        Me.txtObjectMass = New System.Windows.Forms.TextBox()
        Me.txtObjectCharge = New System.Windows.Forms.TextBox()
        Me.txtObjectNumber = New System.Windows.Forms.TextBox()
        Me.tbObjectReflectivity = New System.Windows.Forms.TrackBar()
        Me.tbObjectHighlightSharpness = New System.Windows.Forms.TrackBar()
        Me.txtObjectSizeX = New System.Windows.Forms.TextBox()
        Me.txtObjectSizeY = New System.Windows.Forms.TextBox()
        Me.txtObjectSizeZ = New System.Windows.Forms.TextBox()
        Me.lblObjectSize = New System.Windows.Forms.Label()
        Me.txtObjectNormalZ = New System.Windows.Forms.TextBox()
        Me.txtObjectNormalY = New System.Windows.Forms.TextBox()
        Me.txtObjectNormalX = New System.Windows.Forms.TextBox()
        Me.cmdObjectRadius = New System.Windows.Forms.Button()
        Me.lblObjectRadius = New System.Windows.Forms.Label()
        Me.txtObjectRotationZ = New System.Windows.Forms.TextBox()
        Me.cmdObjectRotationZ = New System.Windows.Forms.Button()
        Me.txtObjectRotationY = New System.Windows.Forms.TextBox()
        Me.cmdObjectRotationY = New System.Windows.Forms.Button()
        Me.txtObjectRotationX = New System.Windows.Forms.TextBox()
        Me.cmdObjectRotationX = New System.Windows.Forms.Button()
        Me.lblObjectRotation = New System.Windows.Forms.Label()
        Me.lblObjectNormal = New System.Windows.Forms.Label()
        Me.cmdObjectSizeX = New System.Windows.Forms.Button()
        Me.cmdObjectSizeY = New System.Windows.Forms.Button()
        Me.cmdObjectSizeZ = New System.Windows.Forms.Button()
        Me.txtObjectRadius = New System.Windows.Forms.TextBox()
        Me.cmdObjectNormalX = New System.Windows.Forms.Button()
        Me.cmdObjectNormalY = New System.Windows.Forms.Button()
        Me.cmdObjectNormalZ = New System.Windows.Forms.Button()
        Me.cmdGroupAdd = New System.Windows.Forms.Button()
        Me.cmdGroupRemove = New System.Windows.Forms.Button()
        Me.cmdGroupReplace = New System.Windows.Forms.Button()
        Me.TabLights = New System.Windows.Forms.TabPage()
        Me.gbLights = New System.Windows.Forms.GroupBox()
        Me.plLightColor = New System.Windows.Forms.Button()
        Me.txtLightAttenuationC = New System.Windows.Forms.TextBox()
        Me.txtLightAttenuationB = New System.Windows.Forms.TextBox()
        Me.txtLightAttenuationA = New System.Windows.Forms.TextBox()
        Me.lblLightAttenuation = New System.Windows.Forms.Label()
        Me.txtLightAngleOuter = New System.Windows.Forms.TextBox()
        Me.lblLightRange = New System.Windows.Forms.Label()
        Me.txtLightRange = New System.Windows.Forms.TextBox()
        Me.lblLightFalloff = New System.Windows.Forms.Label()
        Me.txtLightFalloff = New System.Windows.Forms.TextBox()
        Me.lblLightAngle = New System.Windows.Forms.Label()
        Me.txtLightAngleInner = New System.Windows.Forms.TextBox()
        Me.tbLightAmbient = New System.Windows.Forms.TrackBar()
        Me.lblLightAmbient = New System.Windows.Forms.Label()
        Me.lblLightHighlight = New System.Windows.Forms.Label()
        Me.lblLightType = New System.Windows.Forms.Label()
        Me.txtLightPositionZ = New System.Windows.Forms.TextBox()
        Me.txtLightPositionY = New System.Windows.Forms.TextBox()
        Me.txtLightPositionX = New System.Windows.Forms.TextBox()
        Me.lblLightPosition = New System.Windows.Forms.Label()
        Me.chLightsEnable = New System.Windows.Forms.CheckBox()
        Me.listLights = New System.Windows.Forms.ListBox()
        Me.txtLightName = New System.Windows.Forms.TextBox()
        Me.lblLightName = New System.Windows.Forms.Label()
        Me.txtLightDirectionZ = New System.Windows.Forms.TextBox()
        Me.lblLightDirection = New System.Windows.Forms.Label()
        Me.txtLightDirectionY = New System.Windows.Forms.TextBox()
        Me.txtLightDirectionX = New System.Windows.Forms.TextBox()
        Me.lblLightColor = New System.Windows.Forms.Label()
        Me.tbLightHighlight = New System.Windows.Forms.TrackBar()
        Me.cbLightType = New System.Windows.Forms.ComboBox()
        Me.cmdLightAdd = New System.Windows.Forms.Button()
        Me.cmdLightRemove = New System.Windows.Forms.Button()
        Me.cmdLightReplace = New System.Windows.Forms.Button()
        Me.TabDisplay = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.chCamera = New System.Windows.Forms.CheckBox()
        Me.txtCPosZ = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCOrientZ = New System.Windows.Forms.TextBox()
        Me.txtCTargetY = New System.Windows.Forms.TextBox()
        Me.txtCPosX = New System.Windows.Forms.TextBox()
        Me.txtCTargetZ = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCTargetX = New System.Windows.Forms.TextBox()
        Me.txtCPosY = New System.Windows.Forms.TextBox()
        Me.txtCOrientX = New System.Windows.Forms.TextBox()
        Me.txtCOrientY = New System.Windows.Forms.TextBox()
        Me.tbCameraSpeed = New System.Windows.Forms.TrackBar()
        Me.Rendering = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRenderThreads = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtVFoV = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cbRender = New System.Windows.Forms.ComboBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtMaxFPS = New System.Windows.Forms.TextBox()
        Me.chVSync = New System.Windows.Forms.CheckBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.cbShading = New System.Windows.Forms.ComboBox()
        Me.tbPolys = New System.Windows.Forms.TrackBar()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtWindowX = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtHFoV = New System.Windows.Forms.TextBox()
        Me.chTrace = New System.Windows.Forms.CheckBox()
        Me.txtWindowY = New System.Windows.Forms.TextBox()
        Me.plRenderBackColor = New System.Windows.Forms.Button()
        Me.CmdSaveOut = New System.Windows.Forms.Button()
        Me.TabForces = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtPermittivity = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.txtFluidViscosity = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtDragCoeff = New System.Windows.Forms.TextBox()
        Me.chForces = New System.Windows.Forms.CheckBox()
        Me.txtFluidDensity = New System.Windows.Forms.TextBox()
        Me.chElectrostatic = New System.Windows.Forms.CheckBox()
        Me.txtFieldZ = New System.Windows.Forms.TextBox()
        Me.chGravity = New System.Windows.Forms.CheckBox()
        Me.txtFieldY = New System.Windows.Forms.TextBox()
        Me.chField = New System.Windows.Forms.CheckBox()
        Me.txtFieldX = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.chDrag = New System.Windows.Forms.CheckBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chInterpolate = New System.Windows.Forms.CheckBox()
        Me.chCollision = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCoR = New System.Windows.Forms.TextBox()
        Me.chbreakable = New System.Windows.Forms.CheckBox()
        Me.lblResulting = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtAddMax = New System.Windows.Forms.TextBox()
        Me.txtBreakMin = New System.Windows.Forms.TextBox()
        Me.txtAddAvg = New System.Windows.Forms.TextBox()
        Me.txtBreakAvg = New System.Windows.Forms.TextBox()
        Me.txtAddMin = New System.Windows.Forms.TextBox()
        Me.txtBreakMax = New System.Windows.Forms.TextBox()
        Me.TabSimulation = New System.Windows.Forms.TabPage()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLimitCalc = New System.Windows.Forms.TextBox()
        Me.txtScale = New System.Windows.Forms.TextBox()
        Me.txtTimeStep = New System.Windows.Forms.TextBox()
        Me.cbIntegration = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtLimitObjects = New System.Windows.Forms.TextBox()
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.Stats.SuspendLayout()
        Me.TabGroups.SuspendLayout()
        Me.gbObjects.SuspendLayout()
        CType(Me.tbObjectTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbObjectReflectivity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbObjectHighlightSharpness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabLights.SuspendLayout()
        Me.gbLights.SuspendLayout()
        CType(Me.tbLightAmbient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLightHighlight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDisplay.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tbCameraSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Rendering.SuspendLayout()
        CType(Me.tbPolys, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabForces.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabSimulation.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Tabs.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdStart
        '
        Me.cmdStart.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStart.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdStart.FlatAppearance.BorderSize = 0
        Me.cmdStart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdStart.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmdStart.ForeColor = System.Drawing.Color.Black
        Me.cmdStart.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdStart.Location = New System.Drawing.Point(6, 5)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(451, 39)
        Me.cmdStart.TabIndex = 0
        Me.cmdStart.Text = "&Start Simulation"
        Me.cmdStart.UseVisualStyleBackColor = False
        '
        'ColorDialog
        '
        Me.ColorDialog.AnyColor = True
        Me.ColorDialog.Color = System.Drawing.SystemColors.ActiveCaption
        Me.ColorDialog.FullOpen = True
        '
        'Stats
        '
        Me.Stats.AutoSize = False
        Me.Stats.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Stats.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStat})
        Me.Stats.Location = New System.Drawing.Point(0, 677)
        Me.Stats.Name = "Stats"
        Me.Stats.Size = New System.Drawing.Size(461, 22)
        Me.Stats.SizingGrip = False
        Me.Stats.TabIndex = 22
        '
        'lblStat
        '
        Me.lblStat.BackColor = System.Drawing.SystemColors.Control
        Me.lblStat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lblStat.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblStat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStat.LinkColor = System.Drawing.Color.White
        Me.lblStat.Name = "lblStat"
        Me.lblStat.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.lblStat.Size = New System.Drawing.Size(446, 17)
        Me.lblStat.Spring = True
        Me.lblStat.Text = "Frames : 0  |  FPS : 0  |  Calculations : 0  |  CPS : 0"
        '
        'StatusUpdate
        '
        Me.StatusUpdate.Interval = 150
        '
        'TabGroups
        '
        Me.TabGroups.BackColor = System.Drawing.SystemColors.Control
        Me.TabGroups.Controls.Add(Me.gbObjects)
        Me.TabGroups.Controls.Add(Me.cmdGroupAdd)
        Me.TabGroups.Controls.Add(Me.cmdGroupRemove)
        Me.TabGroups.Controls.Add(Me.cmdGroupReplace)
        Me.TabGroups.Location = New System.Drawing.Point(4, 37)
        Me.TabGroups.Name = "TabGroups"
        Me.TabGroups.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGroups.Size = New System.Drawing.Size(451, 583)
        Me.TabGroups.TabIndex = 7
        Me.TabGroups.Text = "Objects"
        Me.TabGroups.UseVisualStyleBackColor = True
        '
        'gbObjects
        '
        Me.gbObjects.Controls.Add(Me.plObjectHighlightColor)
        Me.gbObjects.Controls.Add(Me.plObjectColor)
        Me.gbObjects.Controls.Add(Me.cmdObjectRefractiveIndex)
        Me.gbObjects.Controls.Add(Me.txtObjectRefractiveIndex)
        Me.gbObjects.Controls.Add(Me.lblObjectRefractiveIndex)
        Me.gbObjects.Controls.Add(Me.lblObjectReflectivity)
        Me.gbObjects.Controls.Add(Me.cmdObjectReflectivity)
        Me.gbObjects.Controls.Add(Me.lblObjectType)
        Me.gbObjects.Controls.Add(Me.cbObjectType)
        Me.gbObjects.Controls.Add(Me.chObjectWireframe)
        Me.gbObjects.Controls.Add(Me.chObjectAffected)
        Me.gbObjects.Controls.Add(Me.chObjectAffects)
        Me.gbObjects.Controls.Add(Me.cmdObjectNumber)
        Me.gbObjects.Controls.Add(Me.lblObjectNumber)
        Me.gbObjects.Controls.Add(Me.listGroups)
        Me.gbObjects.Controls.Add(Me.cmdObjectVelocityZ)
        Me.gbObjects.Controls.Add(Me.cmdObjectVelocityY)
        Me.gbObjects.Controls.Add(Me.cmdObjectTransparency)
        Me.gbObjects.Controls.Add(Me.cmdObjectHighlightSharpness)
        Me.gbObjects.Controls.Add(Me.cmdObjectPositionZ)
        Me.gbObjects.Controls.Add(Me.cmdObjectPositionY)
        Me.gbObjects.Controls.Add(Me.cmdObjectHighlightColor)
        Me.gbObjects.Controls.Add(Me.cmdObjectColor)
        Me.gbObjects.Controls.Add(Me.cmdObjectVelocityX)
        Me.gbObjects.Controls.Add(Me.cmdObjectPositionX)
        Me.gbObjects.Controls.Add(Me.cmdObjectCharge)
        Me.gbObjects.Controls.Add(Me.cmdObjectMass)
        Me.gbObjects.Controls.Add(Me.lblObjectHighlightColor)
        Me.gbObjects.Controls.Add(Me.lblObjectName)
        Me.gbObjects.Controls.Add(Me.lblObjectTransparency)
        Me.gbObjects.Controls.Add(Me.txtObjectVelocityZ)
        Me.gbObjects.Controls.Add(Me.txtObjectName)
        Me.gbObjects.Controls.Add(Me.txtObjectVelocityY)
        Me.gbObjects.Controls.Add(Me.lblObjectMass)
        Me.gbObjects.Controls.Add(Me.lblObjectCharge)
        Me.gbObjects.Controls.Add(Me.lblObjectColor)
        Me.gbObjects.Controls.Add(Me.lblObjectPosition)
        Me.gbObjects.Controls.Add(Me.lblObjectVelocity)
        Me.gbObjects.Controls.Add(Me.lblObjectHighlightSharpness)
        Me.gbObjects.Controls.Add(Me.tbObjectTransparency)
        Me.gbObjects.Controls.Add(Me.txtObjectPositionZ)
        Me.gbObjects.Controls.Add(Me.txtObjectPositionX)
        Me.gbObjects.Controls.Add(Me.txtObjectPositionY)
        Me.gbObjects.Controls.Add(Me.txtObjectVelocityX)
        Me.gbObjects.Controls.Add(Me.txtObjectMass)
        Me.gbObjects.Controls.Add(Me.txtObjectCharge)
        Me.gbObjects.Controls.Add(Me.txtObjectNumber)
        Me.gbObjects.Controls.Add(Me.tbObjectReflectivity)
        Me.gbObjects.Controls.Add(Me.tbObjectHighlightSharpness)
        Me.gbObjects.Controls.Add(Me.txtObjectSizeX)
        Me.gbObjects.Controls.Add(Me.txtObjectSizeY)
        Me.gbObjects.Controls.Add(Me.txtObjectSizeZ)
        Me.gbObjects.Controls.Add(Me.lblObjectSize)
        Me.gbObjects.Controls.Add(Me.txtObjectNormalZ)
        Me.gbObjects.Controls.Add(Me.txtObjectNormalY)
        Me.gbObjects.Controls.Add(Me.txtObjectNormalX)
        Me.gbObjects.Controls.Add(Me.cmdObjectRadius)
        Me.gbObjects.Controls.Add(Me.lblObjectRadius)
        Me.gbObjects.Controls.Add(Me.txtObjectRotationZ)
        Me.gbObjects.Controls.Add(Me.cmdObjectRotationZ)
        Me.gbObjects.Controls.Add(Me.txtObjectRotationY)
        Me.gbObjects.Controls.Add(Me.cmdObjectRotationY)
        Me.gbObjects.Controls.Add(Me.txtObjectRotationX)
        Me.gbObjects.Controls.Add(Me.cmdObjectRotationX)
        Me.gbObjects.Controls.Add(Me.lblObjectRotation)
        Me.gbObjects.Controls.Add(Me.lblObjectNormal)
        Me.gbObjects.Controls.Add(Me.cmdObjectSizeX)
        Me.gbObjects.Controls.Add(Me.cmdObjectSizeY)
        Me.gbObjects.Controls.Add(Me.cmdObjectSizeZ)
        Me.gbObjects.Controls.Add(Me.txtObjectRadius)
        Me.gbObjects.Controls.Add(Me.cmdObjectNormalX)
        Me.gbObjects.Controls.Add(Me.cmdObjectNormalY)
        Me.gbObjects.Controls.Add(Me.cmdObjectNormalZ)
        Me.gbObjects.Location = New System.Drawing.Point(0, 0)
        Me.gbObjects.Name = "gbObjects"
        Me.gbObjects.Size = New System.Drawing.Size(451, 528)
        Me.gbObjects.TabIndex = 70
        Me.gbObjects.TabStop = False
        Me.gbObjects.Text = "Objects"
        '
        'plObjectHighlightColor
        '
        Me.plObjectHighlightColor.BackColor = System.Drawing.Color.White
        Me.plObjectHighlightColor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plObjectHighlightColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plObjectHighlightColor.ForeColor = System.Drawing.Color.White
        Me.plObjectHighlightColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plObjectHighlightColor.Location = New System.Drawing.Point(151, 377)
        Me.plObjectHighlightColor.Name = "plObjectHighlightColor"
        Me.plObjectHighlightColor.Size = New System.Drawing.Size(292, 21)
        Me.plObjectHighlightColor.TabIndex = 38
        Me.plObjectHighlightColor.UseVisualStyleBackColor = False
        '
        'plObjectColor
        '
        Me.plObjectColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.plObjectColor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plObjectColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plObjectColor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.plObjectColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plObjectColor.Location = New System.Drawing.Point(151, 348)
        Me.plObjectColor.Name = "plObjectColor"
        Me.plObjectColor.Size = New System.Drawing.Size(292, 21)
        Me.plObjectColor.TabIndex = 36
        Me.plObjectColor.UseVisualStyleBackColor = False
        '
        'cmdObjectRefractiveIndex
        '
        Me.cmdObjectRefractiveIndex.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectRefractiveIndex.FlatAppearance.BorderSize = 0
        Me.cmdObjectRefractiveIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectRefractiveIndex.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectRefractiveIndex.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectRefractiveIndex.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectRefractiveIndex.Location = New System.Drawing.Point(128, 475)
        Me.cmdObjectRefractiveIndex.Name = "cmdObjectRefractiveIndex"
        Me.cmdObjectRefractiveIndex.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectRefractiveIndex.TabIndex = 45
        Me.cmdObjectRefractiveIndex.Text = "ƒ"
        Me.cmdObjectRefractiveIndex.UseVisualStyleBackColor = False
        '
        'txtObjectRefractiveIndex
        '
        Me.txtObjectRefractiveIndex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectRefractiveIndex.Location = New System.Drawing.Point(151, 475)
        Me.txtObjectRefractiveIndex.Name = "txtObjectRefractiveIndex"
        Me.txtObjectRefractiveIndex.Size = New System.Drawing.Size(292, 35)
        Me.txtObjectRefractiveIndex.TabIndex = 46
        Me.txtObjectRefractiveIndex.Text = "1"
        Me.txtObjectRefractiveIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblObjectRefractiveIndex
        '
        Me.lblObjectRefractiveIndex.AutoEllipsis = True
        Me.lblObjectRefractiveIndex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectRefractiveIndex.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectRefractiveIndex.Location = New System.Drawing.Point(3, 475)
        Me.lblObjectRefractiveIndex.Name = "lblObjectRefractiveIndex"
        Me.lblObjectRefractiveIndex.Size = New System.Drawing.Size(117, 21)
        Me.lblObjectRefractiveIndex.TabIndex = 233
        Me.lblObjectRefractiveIndex.Text = "Refractive Index: "
        Me.lblObjectRefractiveIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectRefractiveIndex.UseMnemonic = False
        '
        'lblObjectReflectivity
        '
        Me.lblObjectReflectivity.AutoEllipsis = True
        Me.lblObjectReflectivity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectReflectivity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectReflectivity.Location = New System.Drawing.Point(3, 424)
        Me.lblObjectReflectivity.Name = "lblObjectReflectivity"
        Me.lblObjectReflectivity.Size = New System.Drawing.Size(117, 21)
        Me.lblObjectReflectivity.TabIndex = 230
        Me.lblObjectReflectivity.Text = "Reflectivity: "
        Me.lblObjectReflectivity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectReflectivity.UseMnemonic = False
        '
        'cmdObjectReflectivity
        '
        Me.cmdObjectReflectivity.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectReflectivity.FlatAppearance.BorderSize = 0
        Me.cmdObjectReflectivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectReflectivity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectReflectivity.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectReflectivity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectReflectivity.Location = New System.Drawing.Point(128, 424)
        Me.cmdObjectReflectivity.Name = "cmdObjectReflectivity"
        Me.cmdObjectReflectivity.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectReflectivity.TabIndex = 41
        Me.cmdObjectReflectivity.Text = "ƒ"
        Me.cmdObjectReflectivity.UseVisualStyleBackColor = False
        '
        'lblObjectType
        '
        Me.lblObjectType.AutoEllipsis = True
        Me.lblObjectType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectType.Location = New System.Drawing.Point(3, 124)
        Me.lblObjectType.Name = "lblObjectType"
        Me.lblObjectType.Size = New System.Drawing.Size(118, 23)
        Me.lblObjectType.TabIndex = 213
        Me.lblObjectType.Text = "Type of Objects: "
        Me.lblObjectType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectType.UseMnemonic = False
        '
        'cbObjectType
        '
        Me.cbObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbObjectType.FormattingEnabled = True
        Me.cbObjectType.Items.AddRange(New Object() {"Sphere", "Box", "Plane", "Infinite Plane"})
        Me.cbObjectType.Location = New System.Drawing.Point(151, 124)
        Me.cbObjectType.Name = "cbObjectType"
        Me.cbObjectType.Size = New System.Drawing.Size(292, 35)
        Me.cbObjectType.TabIndex = 2

        '
        'chObjectWireframe
        '
        Me.chObjectWireframe.AutoEllipsis = True
        Me.chObjectWireframe.Enabled = False
        Me.chObjectWireframe.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chObjectWireframe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chObjectWireframe.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chObjectWireframe.Location = New System.Drawing.Point(244, 502)
        Me.chObjectWireframe.Name = "chObjectWireframe"
        Me.chObjectWireframe.Size = New System.Drawing.Size(152, 19)
        Me.chObjectWireframe.TabIndex = 49
        Me.chObjectWireframe.Text = "Render as Wireframe"
        Me.chObjectWireframe.UseMnemonic = False
        Me.chObjectWireframe.UseVisualStyleBackColor = True
        '
        'chObjectAffected
        '
        Me.chObjectAffected.AutoSize = True
        Me.chObjectAffected.Checked = True
        Me.chObjectAffected.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chObjectAffected.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.chObjectAffected.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chObjectAffected.Location = New System.Drawing.Point(114, 503)
        Me.chObjectAffected.Name = "chObjectAffected"
        Me.chObjectAffected.Size = New System.Drawing.Size(245, 31)
        Me.chObjectAffected.TabIndex = 48
        Me.chObjectAffected.Text = "Affected by Others"
        Me.chObjectAffected.UseVisualStyleBackColor = True
        '
        'chObjectAffects
        '
        Me.chObjectAffects.AutoSize = True
        Me.chObjectAffects.Checked = True
        Me.chObjectAffects.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chObjectAffects.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.chObjectAffects.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chObjectAffects.Location = New System.Drawing.Point(6, 503)
        Me.chObjectAffects.Name = "chObjectAffects"
        Me.chObjectAffects.Size = New System.Drawing.Size(197, 31)
        Me.chObjectAffects.TabIndex = 47
        Me.chObjectAffects.Text = "Affects Others"
        Me.chObjectAffects.UseVisualStyleBackColor = True
        '
        'cmdObjectNumber
        '
        Me.cmdObjectNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectNumber.BackColor = System.Drawing.SystemColors.Control
        Me.cmdObjectNumber.FlatAppearance.BorderSize = 0
        Me.cmdObjectNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectNumber.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectNumber.Location = New System.Drawing.Point(128, 153)
        Me.cmdObjectNumber.Name = "cmdObjectNumber"
        Me.cmdObjectNumber.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectNumber.TabIndex = 3
        Me.cmdObjectNumber.Text = "ƒ"
        Me.cmdObjectNumber.UseVisualStyleBackColor = False
        '
        'lblObjectNumber
        '
        Me.lblObjectNumber.AutoEllipsis = True
        Me.lblObjectNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectNumber.Location = New System.Drawing.Point(3, 153)
        Me.lblObjectNumber.Name = "lblObjectNumber"
        Me.lblObjectNumber.Size = New System.Drawing.Size(126, 21)
        Me.lblObjectNumber.TabIndex = 205
        Me.lblObjectNumber.Text = "Number of Objects:"
        Me.lblObjectNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectNumber.UseMnemonic = False
        '
        'listGroups
        '
        Me.listGroups.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.listGroups.ForeColor = System.Drawing.SystemColors.ControlText
        Me.listGroups.IntegralHeight = False
        Me.listGroups.ItemHeight = 27
        Me.listGroups.Location = New System.Drawing.Point(6, 20)
        Me.listGroups.Name = "listGroups"
        Me.listGroups.Size = New System.Drawing.Size(437, 74)
        Me.listGroups.TabIndex = 0
        '
        'cmdObjectVelocityZ
        '
        Me.cmdObjectVelocityZ.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectVelocityZ.FlatAppearance.BorderSize = 0
        Me.cmdObjectVelocityZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectVelocityZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectVelocityZ.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectVelocityZ.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectVelocityZ.Location = New System.Drawing.Point(339, 321)
        Me.cmdObjectVelocityZ.Name = "cmdObjectVelocityZ"
        Me.cmdObjectVelocityZ.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectVelocityZ.TabIndex = 33
        Me.cmdObjectVelocityZ.Text = "ƒ"
        Me.cmdObjectVelocityZ.UseVisualStyleBackColor = False
        '
        'cmdObjectVelocityY
        '
        Me.cmdObjectVelocityY.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectVelocityY.FlatAppearance.BorderSize = 0
        Me.cmdObjectVelocityY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectVelocityY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectVelocityY.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectVelocityY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectVelocityY.Location = New System.Drawing.Point(234, 321)
        Me.cmdObjectVelocityY.Name = "cmdObjectVelocityY"
        Me.cmdObjectVelocityY.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectVelocityY.TabIndex = 31
        Me.cmdObjectVelocityY.Text = "ƒ"
        Me.cmdObjectVelocityY.UseVisualStyleBackColor = False
        '
        'cmdObjectTransparency
        '
        Me.cmdObjectTransparency.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectTransparency.FlatAppearance.BorderSize = 0
        Me.cmdObjectTransparency.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectTransparency.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectTransparency.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectTransparency.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectTransparency.Location = New System.Drawing.Point(128, 448)
        Me.cmdObjectTransparency.Name = "cmdObjectTransparency"
        Me.cmdObjectTransparency.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectTransparency.TabIndex = 43
        Me.cmdObjectTransparency.Text = "ƒ"
        Me.cmdObjectTransparency.UseVisualStyleBackColor = False
        '
        'cmdObjectHighlightSharpness
        '
        Me.cmdObjectHighlightSharpness.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectHighlightSharpness.FlatAppearance.BorderSize = 0
        Me.cmdObjectHighlightSharpness.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectHighlightSharpness.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectHighlightSharpness.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectHighlightSharpness.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectHighlightSharpness.Location = New System.Drawing.Point(128, 401)
        Me.cmdObjectHighlightSharpness.Name = "cmdObjectHighlightSharpness"
        Me.cmdObjectHighlightSharpness.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectHighlightSharpness.TabIndex = 39
        Me.cmdObjectHighlightSharpness.Text = "ƒ"
        Me.cmdObjectHighlightSharpness.UseVisualStyleBackColor = False
        '
        'cmdObjectPositionZ
        '
        Me.cmdObjectPositionZ.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectPositionZ.FlatAppearance.BorderSize = 0
        Me.cmdObjectPositionZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectPositionZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectPositionZ.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectPositionZ.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectPositionZ.Location = New System.Drawing.Point(339, 292)
        Me.cmdObjectPositionZ.Name = "cmdObjectPositionZ"
        Me.cmdObjectPositionZ.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectPositionZ.TabIndex = 27
        Me.cmdObjectPositionZ.Text = "ƒ"
        Me.cmdObjectPositionZ.UseVisualStyleBackColor = False
        '
        'cmdObjectPositionY
        '
        Me.cmdObjectPositionY.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectPositionY.FlatAppearance.BorderSize = 0
        Me.cmdObjectPositionY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectPositionY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectPositionY.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectPositionY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectPositionY.Location = New System.Drawing.Point(234, 292)
        Me.cmdObjectPositionY.Name = "cmdObjectPositionY"
        Me.cmdObjectPositionY.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectPositionY.TabIndex = 25
        Me.cmdObjectPositionY.Text = "ƒ"
        Me.cmdObjectPositionY.UseVisualStyleBackColor = False
        '
        'cmdObjectHighlightColor
        '
        Me.cmdObjectHighlightColor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectHighlightColor.FlatAppearance.BorderSize = 0
        Me.cmdObjectHighlightColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectHighlightColor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectHighlightColor.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectHighlightColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectHighlightColor.Location = New System.Drawing.Point(128, 377)
        Me.cmdObjectHighlightColor.Name = "cmdObjectHighlightColor"
        Me.cmdObjectHighlightColor.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectHighlightColor.TabIndex = 37
        Me.cmdObjectHighlightColor.Text = "ƒ"
        Me.cmdObjectHighlightColor.UseVisualStyleBackColor = False
        '
        'cmdObjectColor
        '
        Me.cmdObjectColor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectColor.FlatAppearance.BorderSize = 0
        Me.cmdObjectColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectColor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectColor.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectColor.Location = New System.Drawing.Point(128, 348)
        Me.cmdObjectColor.Name = "cmdObjectColor"
        Me.cmdObjectColor.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectColor.TabIndex = 35
        Me.cmdObjectColor.Text = "ƒ"
        Me.cmdObjectColor.UseVisualStyleBackColor = False
        '
        'cmdObjectVelocityX
        '
        Me.cmdObjectVelocityX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectVelocityX.FlatAppearance.BorderSize = 0
        Me.cmdObjectVelocityX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectVelocityX.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectVelocityX.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectVelocityX.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectVelocityX.Location = New System.Drawing.Point(128, 321)
        Me.cmdObjectVelocityX.Name = "cmdObjectVelocityX"
        Me.cmdObjectVelocityX.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectVelocityX.TabIndex = 29
        Me.cmdObjectVelocityX.Text = "ƒ"
        Me.cmdObjectVelocityX.UseVisualStyleBackColor = False
        '
        'cmdObjectPositionX
        '
        Me.cmdObjectPositionX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectPositionX.FlatAppearance.BorderSize = 0
        Me.cmdObjectPositionX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectPositionX.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectPositionX.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectPositionX.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectPositionX.Location = New System.Drawing.Point(128, 292)
        Me.cmdObjectPositionX.Name = "cmdObjectPositionX"
        Me.cmdObjectPositionX.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectPositionX.TabIndex = 23
        Me.cmdObjectPositionX.Text = "ƒ"
        Me.cmdObjectPositionX.UseVisualStyleBackColor = False
        '
        'cmdObjectCharge
        '
        Me.cmdObjectCharge.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectCharge.FlatAppearance.BorderSize = 0
        Me.cmdObjectCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectCharge.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectCharge.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectCharge.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectCharge.Location = New System.Drawing.Point(128, 209)
        Me.cmdObjectCharge.Name = "cmdObjectCharge"
        Me.cmdObjectCharge.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectCharge.TabIndex = 7
        Me.cmdObjectCharge.Text = "ƒ"
        Me.cmdObjectCharge.UseVisualStyleBackColor = False
        '
        'cmdObjectMass
        '
        Me.cmdObjectMass.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectMass.FlatAppearance.BorderSize = 0
        Me.cmdObjectMass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectMass.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectMass.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectMass.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectMass.Location = New System.Drawing.Point(128, 180)
        Me.cmdObjectMass.Name = "cmdObjectMass"
        Me.cmdObjectMass.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectMass.TabIndex = 5
        Me.cmdObjectMass.Text = "ƒ"
        Me.cmdObjectMass.UseVisualStyleBackColor = False
        '
        'lblObjectHighlightColor
        '
        Me.lblObjectHighlightColor.AutoEllipsis = True
        Me.lblObjectHighlightColor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectHighlightColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectHighlightColor.Location = New System.Drawing.Point(3, 377)
        Me.lblObjectHighlightColor.Name = "lblObjectHighlightColor"
        Me.lblObjectHighlightColor.Size = New System.Drawing.Size(126, 21)
        Me.lblObjectHighlightColor.TabIndex = 161
        Me.lblObjectHighlightColor.Text = "Highlight Color: "
        Me.lblObjectHighlightColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectHighlightColor.UseMnemonic = False
        '
        'lblObjectName
        '
        Me.lblObjectName.AutoEllipsis = True
        Me.lblObjectName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectName.Location = New System.Drawing.Point(3, 97)
        Me.lblObjectName.Name = "lblObjectName"
        Me.lblObjectName.Size = New System.Drawing.Size(146, 21)
        Me.lblObjectName.TabIndex = 140
        Me.lblObjectName.Text = "Name of Objects: "
        Me.lblObjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectName.UseMnemonic = False
        '
        'lblObjectTransparency
        '
        Me.lblObjectTransparency.AutoEllipsis = True
        Me.lblObjectTransparency.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectTransparency.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectTransparency.Location = New System.Drawing.Point(3, 448)
        Me.lblObjectTransparency.Name = "lblObjectTransparency"
        Me.lblObjectTransparency.Size = New System.Drawing.Size(127, 21)
        Me.lblObjectTransparency.TabIndex = 149
        Me.lblObjectTransparency.Text = "Transparency:"
        Me.lblObjectTransparency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectTransparency.UseMnemonic = False
        '
        'txtObjectVelocityZ
        '
        Me.txtObjectVelocityZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectVelocityZ.Location = New System.Drawing.Point(361, 321)
        Me.txtObjectVelocityZ.Name = "txtObjectVelocityZ"
        Me.txtObjectVelocityZ.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectVelocityZ.TabIndex = 34
        Me.txtObjectVelocityZ.Text = "0"
        Me.txtObjectVelocityZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObjectName
        '
        Me.txtObjectName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectName.Location = New System.Drawing.Point(151, 97)
        Me.txtObjectName.Name = "txtObjectName"
        Me.txtObjectName.Size = New System.Drawing.Size(292, 35)
        Me.txtObjectName.TabIndex = 1
        Me.txtObjectName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObjectVelocityY
        '
        Me.txtObjectVelocityY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectVelocityY.Location = New System.Drawing.Point(256, 321)
        Me.txtObjectVelocityY.Name = "txtObjectVelocityY"
        Me.txtObjectVelocityY.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectVelocityY.TabIndex = 32
        Me.txtObjectVelocityY.Text = "0"
        Me.txtObjectVelocityY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblObjectMass
        '
        Me.lblObjectMass.AutoEllipsis = True
        Me.lblObjectMass.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectMass.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectMass.Location = New System.Drawing.Point(3, 180)
        Me.lblObjectMass.Name = "lblObjectMass"
        Me.lblObjectMass.Size = New System.Drawing.Size(126, 21)
        Me.lblObjectMass.TabIndex = 141
        Me.lblObjectMass.Text = "Mass (kg): "
        Me.lblObjectMass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectMass.UseMnemonic = False
        '
        'lblObjectCharge
        '
        Me.lblObjectCharge.AutoEllipsis = True
        Me.lblObjectCharge.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectCharge.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectCharge.Location = New System.Drawing.Point(3, 209)
        Me.lblObjectCharge.Name = "lblObjectCharge"
        Me.lblObjectCharge.Size = New System.Drawing.Size(126, 21)
        Me.lblObjectCharge.TabIndex = 142
        Me.lblObjectCharge.Text = "Charge (C): "
        Me.lblObjectCharge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectCharge.UseMnemonic = False
        '
        'lblObjectColor
        '
        Me.lblObjectColor.AutoEllipsis = True
        Me.lblObjectColor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectColor.Location = New System.Drawing.Point(3, 348)
        Me.lblObjectColor.Name = "lblObjectColor"
        Me.lblObjectColor.Size = New System.Drawing.Size(126, 21)
        Me.lblObjectColor.TabIndex = 146
        Me.lblObjectColor.Text = "Color: "
        Me.lblObjectColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectColor.UseMnemonic = False
        '
        'lblObjectPosition
        '
        Me.lblObjectPosition.AutoEllipsis = True
        Me.lblObjectPosition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectPosition.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectPosition.Location = New System.Drawing.Point(3, 292)
        Me.lblObjectPosition.Name = "lblObjectPosition"
        Me.lblObjectPosition.Size = New System.Drawing.Size(126, 21)
        Me.lblObjectPosition.TabIndex = 144
        Me.lblObjectPosition.Text = "Position X,Y,Z  (m):"
        Me.lblObjectPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectPosition.UseMnemonic = False
        '
        'lblObjectVelocity
        '
        Me.lblObjectVelocity.AutoEllipsis = True
        Me.lblObjectVelocity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectVelocity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectVelocity.Location = New System.Drawing.Point(3, 321)
        Me.lblObjectVelocity.Name = "lblObjectVelocity"
        Me.lblObjectVelocity.Size = New System.Drawing.Size(126, 21)
        Me.lblObjectVelocity.TabIndex = 145
        Me.lblObjectVelocity.Text = "Velocity X,Y,Z (m/s): "
        Me.lblObjectVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectVelocity.UseMnemonic = False
        '
        'lblObjectHighlightSharpness
        '
        Me.lblObjectHighlightSharpness.AutoEllipsis = True
        Me.lblObjectHighlightSharpness.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectHighlightSharpness.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectHighlightSharpness.Location = New System.Drawing.Point(3, 401)
        Me.lblObjectHighlightSharpness.Name = "lblObjectHighlightSharpness"
        Me.lblObjectHighlightSharpness.Size = New System.Drawing.Size(126, 21)
        Me.lblObjectHighlightSharpness.TabIndex = 164
        Me.lblObjectHighlightSharpness.Text = "Highlight Sharpness: "
        Me.lblObjectHighlightSharpness.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectHighlightSharpness.UseMnemonic = False
        '
        'tbObjectTransparency
        '
        Me.tbObjectTransparency.BackColor = System.Drawing.SystemColors.Control
        Me.tbObjectTransparency.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbObjectTransparency.LargeChange = 15
        Me.tbObjectTransparency.Location = New System.Drawing.Point(151, 448)
        Me.tbObjectTransparency.Maximum = 255
        Me.tbObjectTransparency.Name = "tbObjectTransparency"
        Me.tbObjectTransparency.Size = New System.Drawing.Size(292, 90)
        Me.tbObjectTransparency.SmallChange = 15
        Me.tbObjectTransparency.TabIndex = 44
        Me.tbObjectTransparency.TickFrequency = 5
        Me.tbObjectTransparency.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbObjectTransparency.Value = 255
        '
        'txtObjectPositionZ
        '
        Me.txtObjectPositionZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectPositionZ.Location = New System.Drawing.Point(361, 292)
        Me.txtObjectPositionZ.Name = "txtObjectPositionZ"
        Me.txtObjectPositionZ.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectPositionZ.TabIndex = 28
        Me.txtObjectPositionZ.Text = "0"
        Me.txtObjectPositionZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObjectPositionX
        '
        Me.txtObjectPositionX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectPositionX.Location = New System.Drawing.Point(151, 292)
        Me.txtObjectPositionX.Name = "txtObjectPositionX"
        Me.txtObjectPositionX.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectPositionX.TabIndex = 24
        Me.txtObjectPositionX.Text = "0"
        Me.txtObjectPositionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObjectPositionY
        '
        Me.txtObjectPositionY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectPositionY.Location = New System.Drawing.Point(256, 292)
        Me.txtObjectPositionY.Name = "txtObjectPositionY"
        Me.txtObjectPositionY.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectPositionY.TabIndex = 26
        Me.txtObjectPositionY.Text = "0"
        Me.txtObjectPositionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObjectVelocityX
        '
        Me.txtObjectVelocityX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectVelocityX.Location = New System.Drawing.Point(151, 321)
        Me.txtObjectVelocityX.Name = "txtObjectVelocityX"
        Me.txtObjectVelocityX.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectVelocityX.TabIndex = 30
        Me.txtObjectVelocityX.Text = "0"
        Me.txtObjectVelocityX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObjectMass
        '
        Me.txtObjectMass.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectMass.Location = New System.Drawing.Point(151, 180)
        Me.txtObjectMass.Name = "txtObjectMass"
        Me.txtObjectMass.Size = New System.Drawing.Size(292, 35)
        Me.txtObjectMass.TabIndex = 6
        Me.txtObjectMass.Text = "0"
        Me.txtObjectMass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObjectCharge
        '
        Me.txtObjectCharge.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectCharge.Location = New System.Drawing.Point(151, 209)
        Me.txtObjectCharge.Name = "txtObjectCharge"
        Me.txtObjectCharge.Size = New System.Drawing.Size(292, 35)
        Me.txtObjectCharge.TabIndex = 8
        Me.txtObjectCharge.Text = "0"
        Me.txtObjectCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObjectNumber
        '
        Me.txtObjectNumber.Enabled = False
        Me.txtObjectNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectNumber.Location = New System.Drawing.Point(151, 153)
        Me.txtObjectNumber.Name = "txtObjectNumber"
        Me.txtObjectNumber.Size = New System.Drawing.Size(292, 35)
        Me.txtObjectNumber.TabIndex = 4
        Me.txtObjectNumber.Text = "0"
        Me.txtObjectNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbObjectReflectivity
        '
        Me.tbObjectReflectivity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbObjectReflectivity.LargeChange = 10
        Me.tbObjectReflectivity.Location = New System.Drawing.Point(151, 424)
        Me.tbObjectReflectivity.Maximum = 100
        Me.tbObjectReflectivity.Name = "tbObjectReflectivity"
        Me.tbObjectReflectivity.Size = New System.Drawing.Size(292, 90)
        Me.tbObjectReflectivity.TabIndex = 42
        Me.tbObjectReflectivity.TickFrequency = 5
        Me.tbObjectReflectivity.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbObjectHighlightSharpness
        '
        Me.tbObjectHighlightSharpness.BackColor = System.Drawing.SystemColors.Control
        Me.tbObjectHighlightSharpness.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbObjectHighlightSharpness.LargeChange = 20
        Me.tbObjectHighlightSharpness.Location = New System.Drawing.Point(151, 400)
        Me.tbObjectHighlightSharpness.Maximum = 200
        Me.tbObjectHighlightSharpness.Name = "tbObjectHighlightSharpness"
        Me.tbObjectHighlightSharpness.Size = New System.Drawing.Size(292, 90)
        Me.tbObjectHighlightSharpness.SmallChange = 10
        Me.tbObjectHighlightSharpness.TabIndex = 40
        Me.tbObjectHighlightSharpness.TickFrequency = 5
        Me.tbObjectHighlightSharpness.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbObjectHighlightSharpness.Value = 50
        '
        'txtObjectSizeX
        '
        Me.txtObjectSizeX.Enabled = False
        Me.txtObjectSizeX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectSizeX.Location = New System.Drawing.Point(151, 238)
        Me.txtObjectSizeX.Name = "txtObjectSizeX"
        Me.txtObjectSizeX.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectSizeX.TabIndex = 10
        Me.txtObjectSizeX.Text = "5"
        Me.txtObjectSizeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObjectSizeY
        '
        Me.txtObjectSizeY.Enabled = False
        Me.txtObjectSizeY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectSizeY.Location = New System.Drawing.Point(256, 238)
        Me.txtObjectSizeY.Name = "txtObjectSizeY"
        Me.txtObjectSizeY.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectSizeY.TabIndex = 12
        Me.txtObjectSizeY.Text = "5"
        Me.txtObjectSizeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObjectSizeZ
        '
        Me.txtObjectSizeZ.Enabled = False
        Me.txtObjectSizeZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectSizeZ.Location = New System.Drawing.Point(361, 238)
        Me.txtObjectSizeZ.Name = "txtObjectSizeZ"
        Me.txtObjectSizeZ.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectSizeZ.TabIndex = 14
        Me.txtObjectSizeZ.Text = "5"
        Me.txtObjectSizeZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblObjectSize
        '
        Me.lblObjectSize.AutoEllipsis = True
        Me.lblObjectSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectSize.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectSize.Location = New System.Drawing.Point(3, 238)
        Me.lblObjectSize.Name = "lblObjectSize"
        Me.lblObjectSize.Size = New System.Drawing.Size(117, 21)
        Me.lblObjectSize.TabIndex = 218
        Me.lblObjectSize.Text = "Size X, Y, Z (m): "
        Me.lblObjectSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectSize.UseMnemonic = False
        '
        'txtObjectNormalZ
        '
        Me.txtObjectNormalZ.Enabled = False
        Me.txtObjectNormalZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectNormalZ.Location = New System.Drawing.Point(361, 265)
        Me.txtObjectNormalZ.Name = "txtObjectNormalZ"
        Me.txtObjectNormalZ.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectNormalZ.TabIndex = 21
        Me.txtObjectNormalZ.Text = "5"
        Me.txtObjectNormalZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObjectNormalY
        '
        Me.txtObjectNormalY.Enabled = False
        Me.txtObjectNormalY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectNormalY.Location = New System.Drawing.Point(256, 265)
        Me.txtObjectNormalY.Name = "txtObjectNormalY"
        Me.txtObjectNormalY.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectNormalY.TabIndex = 18
        Me.txtObjectNormalY.Text = "5"
        Me.txtObjectNormalY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObjectNormalX
        '
        Me.txtObjectNormalX.Enabled = False
        Me.txtObjectNormalX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectNormalX.Location = New System.Drawing.Point(151, 265)
        Me.txtObjectNormalX.Name = "txtObjectNormalX"
        Me.txtObjectNormalX.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectNormalX.TabIndex = 16
        Me.txtObjectNormalX.Text = "5"
        Me.txtObjectNormalX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdObjectRadius
        '
        Me.cmdObjectRadius.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectRadius.FlatAppearance.BorderSize = 0
        Me.cmdObjectRadius.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectRadius.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectRadius.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectRadius.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectRadius.Location = New System.Drawing.Point(128, 238)
        Me.cmdObjectRadius.Name = "cmdObjectRadius"
        Me.cmdObjectRadius.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectRadius.TabIndex = 9
        Me.cmdObjectRadius.Text = "ƒ"
        Me.cmdObjectRadius.UseVisualStyleBackColor = False
        '
        'lblObjectRadius
        '
        Me.lblObjectRadius.AutoEllipsis = True
        Me.lblObjectRadius.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectRadius.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectRadius.Location = New System.Drawing.Point(3, 238)
        Me.lblObjectRadius.Name = "lblObjectRadius"
        Me.lblObjectRadius.Size = New System.Drawing.Size(118, 21)
        Me.lblObjectRadius.TabIndex = 143
        Me.lblObjectRadius.Text = "Radius (m): "
        Me.lblObjectRadius.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectRadius.UseMnemonic = False
        '
        'txtObjectRotationZ
        '
        Me.txtObjectRotationZ.Enabled = False
        Me.txtObjectRotationZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectRotationZ.Location = New System.Drawing.Point(361, 265)
        Me.txtObjectRotationZ.Name = "txtObjectRotationZ"
        Me.txtObjectRotationZ.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectRotationZ.TabIndex = 223
        Me.txtObjectRotationZ.Text = "5"
        Me.txtObjectRotationZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdObjectRotationZ
        '
        Me.cmdObjectRotationZ.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectRotationZ.FlatAppearance.BorderSize = 0
        Me.cmdObjectRotationZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectRotationZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectRotationZ.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectRotationZ.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectRotationZ.Location = New System.Drawing.Point(339, 265)
        Me.cmdObjectRotationZ.Name = "cmdObjectRotationZ"
        Me.cmdObjectRotationZ.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectRotationZ.TabIndex = 22
        Me.cmdObjectRotationZ.Text = "ƒ"
        Me.cmdObjectRotationZ.UseVisualStyleBackColor = False
        '
        'txtObjectRotationY
        '
        Me.txtObjectRotationY.Enabled = False
        Me.txtObjectRotationY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectRotationY.Location = New System.Drawing.Point(256, 265)
        Me.txtObjectRotationY.Name = "txtObjectRotationY"
        Me.txtObjectRotationY.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectRotationY.TabIndex = 222
        Me.txtObjectRotationY.Text = "5"
        Me.txtObjectRotationY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdObjectRotationY
        '
        Me.cmdObjectRotationY.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectRotationY.FlatAppearance.BorderSize = 0
        Me.cmdObjectRotationY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectRotationY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectRotationY.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectRotationY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectRotationY.Location = New System.Drawing.Point(234, 265)
        Me.cmdObjectRotationY.Name = "cmdObjectRotationY"
        Me.cmdObjectRotationY.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectRotationY.TabIndex = 17
        Me.cmdObjectRotationY.Text = "ƒ"
        Me.cmdObjectRotationY.UseVisualStyleBackColor = False
        '
        'txtObjectRotationX
        '
        Me.txtObjectRotationX.Enabled = False
        Me.txtObjectRotationX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectRotationX.Location = New System.Drawing.Point(151, 265)
        Me.txtObjectRotationX.Name = "txtObjectRotationX"
        Me.txtObjectRotationX.Size = New System.Drawing.Size(82, 35)
        Me.txtObjectRotationX.TabIndex = 221
        Me.txtObjectRotationX.Text = "5"
        Me.txtObjectRotationX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdObjectRotationX
        '
        Me.cmdObjectRotationX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectRotationX.FlatAppearance.BorderSize = 0
        Me.cmdObjectRotationX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectRotationX.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectRotationX.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectRotationX.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectRotationX.Location = New System.Drawing.Point(128, 265)
        Me.cmdObjectRotationX.Name = "cmdObjectRotationX"
        Me.cmdObjectRotationX.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectRotationX.TabIndex = 15
        Me.cmdObjectRotationX.Text = "ƒ"
        Me.cmdObjectRotationX.UseVisualStyleBackColor = False
        '
        'lblObjectRotation
        '
        Me.lblObjectRotation.AutoEllipsis = True
        Me.lblObjectRotation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectRotation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectRotation.Location = New System.Drawing.Point(3, 265)
        Me.lblObjectRotation.Name = "lblObjectRotation"
        Me.lblObjectRotation.Size = New System.Drawing.Size(127, 21)
        Me.lblObjectRotation.TabIndex = 224
        Me.lblObjectRotation.Text = "Rotation P, Y, R  (rad):"
        Me.lblObjectRotation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectRotation.UseMnemonic = False
        '
        'lblObjectNormal
        '
        Me.lblObjectNormal.AutoEllipsis = True
        Me.lblObjectNormal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblObjectNormal.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObjectNormal.Location = New System.Drawing.Point(3, 265)
        Me.lblObjectNormal.Name = "lblObjectNormal"
        Me.lblObjectNormal.Size = New System.Drawing.Size(117, 21)
        Me.lblObjectNormal.TabIndex = 228
        Me.lblObjectNormal.Text = "Orientation X, Y, Z:"
        Me.lblObjectNormal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblObjectNormal.UseMnemonic = False
        '
        'cmdObjectSizeX
        '
        Me.cmdObjectSizeX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectSizeX.FlatAppearance.BorderSize = 0
        Me.cmdObjectSizeX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectSizeX.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectSizeX.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectSizeX.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectSizeX.Location = New System.Drawing.Point(128, 238)
        Me.cmdObjectSizeX.Name = "cmdObjectSizeX"
        Me.cmdObjectSizeX.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectSizeX.TabIndex = 168
        Me.cmdObjectSizeX.Text = "ƒ"
        Me.cmdObjectSizeX.UseVisualStyleBackColor = False
        '
        'cmdObjectSizeY
        '
        Me.cmdObjectSizeY.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectSizeY.FlatAppearance.BorderSize = 0
        Me.cmdObjectSizeY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectSizeY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectSizeY.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectSizeY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectSizeY.Location = New System.Drawing.Point(234, 238)
        Me.cmdObjectSizeY.Name = "cmdObjectSizeY"
        Me.cmdObjectSizeY.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectSizeY.TabIndex = 11
        Me.cmdObjectSizeY.Text = "ƒ"
        Me.cmdObjectSizeY.UseVisualStyleBackColor = False
        '
        'cmdObjectSizeZ
        '
        Me.cmdObjectSizeZ.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectSizeZ.FlatAppearance.BorderSize = 0
        Me.cmdObjectSizeZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectSizeZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectSizeZ.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectSizeZ.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectSizeZ.Location = New System.Drawing.Point(339, 238)
        Me.cmdObjectSizeZ.Name = "cmdObjectSizeZ"
        Me.cmdObjectSizeZ.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectSizeZ.TabIndex = 13
        Me.cmdObjectSizeZ.Text = "ƒ"
        Me.cmdObjectSizeZ.UseVisualStyleBackColor = False
        '
        'txtObjectRadius
        '
        Me.txtObjectRadius.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectRadius.Location = New System.Drawing.Point(151, 238)
        Me.txtObjectRadius.Name = "txtObjectRadius"
        Me.txtObjectRadius.Size = New System.Drawing.Size(292, 35)
        Me.txtObjectRadius.TabIndex = 151
        Me.txtObjectRadius.Text = "0"
        Me.txtObjectRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdObjectNormalX
        '
        Me.cmdObjectNormalX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectNormalX.FlatAppearance.BorderSize = 0
        Me.cmdObjectNormalX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectNormalX.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectNormalX.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectNormalX.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectNormalX.Location = New System.Drawing.Point(128, 265)
        Me.cmdObjectNormalX.Name = "cmdObjectNormalX"
        Me.cmdObjectNormalX.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectNormalX.TabIndex = 231
        Me.cmdObjectNormalX.Text = "ƒ"
        Me.cmdObjectNormalX.UseVisualStyleBackColor = False
        '
        'cmdObjectNormalY
        '
        Me.cmdObjectNormalY.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectNormalY.FlatAppearance.BorderSize = 0
        Me.cmdObjectNormalY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectNormalY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectNormalY.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectNormalY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectNormalY.Location = New System.Drawing.Point(234, 265)
        Me.cmdObjectNormalY.Name = "cmdObjectNormalY"
        Me.cmdObjectNormalY.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectNormalY.TabIndex = 238
        Me.cmdObjectNormalY.Text = "ƒ"
        Me.cmdObjectNormalY.UseVisualStyleBackColor = False
        '
        'cmdObjectNormalZ
        '
        Me.cmdObjectNormalZ.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdObjectNormalZ.FlatAppearance.BorderSize = 0
        Me.cmdObjectNormalZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdObjectNormalZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdObjectNormalZ.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectNormalZ.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdObjectNormalZ.Location = New System.Drawing.Point(339, 265)
        Me.cmdObjectNormalZ.Name = "cmdObjectNormalZ"
        Me.cmdObjectNormalZ.Size = New System.Drawing.Size(21, 21)
        Me.cmdObjectNormalZ.TabIndex = 239
        Me.cmdObjectNormalZ.Text = "ƒ"
        Me.cmdObjectNormalZ.UseVisualStyleBackColor = False
        '
        'cmdGroupAdd
        '
        Me.cmdGroupAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdGroupAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdGroupAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGroupAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdGroupAdd.Location = New System.Drawing.Point(0, 534)
        Me.cmdGroupAdd.Name = "cmdGroupAdd"
        Me.cmdGroupAdd.Size = New System.Drawing.Size(451, 30)
        Me.cmdGroupAdd.TabIndex = 0
        Me.cmdGroupAdd.Text = "Add Objects"
        Me.cmdGroupAdd.UseVisualStyleBackColor = True
        '
        'cmdGroupRemove
        '
        Me.cmdGroupRemove.Enabled = False
        Me.cmdGroupRemove.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdGroupRemove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdGroupRemove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGroupRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdGroupRemove.Location = New System.Drawing.Point(227, 563)
        Me.cmdGroupRemove.Name = "cmdGroupRemove"
        Me.cmdGroupRemove.Size = New System.Drawing.Size(224, 30)
        Me.cmdGroupRemove.TabIndex = 2
        Me.cmdGroupRemove.Text = "Remove Objects"
        Me.cmdGroupRemove.UseVisualStyleBackColor = True
        '
        'cmdGroupReplace
        '
        Me.cmdGroupReplace.Enabled = False
        Me.cmdGroupReplace.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdGroupReplace.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdGroupReplace.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGroupReplace.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdGroupReplace.Location = New System.Drawing.Point(0, 563)
        Me.cmdGroupReplace.Name = "cmdGroupReplace"
        Me.cmdGroupReplace.Size = New System.Drawing.Size(228, 30)
        Me.cmdGroupReplace.TabIndex = 1
        Me.cmdGroupReplace.Text = "Replace Objects"
        Me.cmdGroupReplace.UseVisualStyleBackColor = True
        '
        'TabLights
        '
        Me.TabLights.BackColor = System.Drawing.SystemColors.Control
        Me.TabLights.Controls.Add(Me.gbLights)
        Me.TabLights.Controls.Add(Me.cmdLightAdd)
        Me.TabLights.Controls.Add(Me.cmdLightRemove)
        Me.TabLights.Controls.Add(Me.cmdLightReplace)
        Me.TabLights.Location = New System.Drawing.Point(4, 39)
        Me.TabLights.Name = "TabLights"
        Me.TabLights.Size = New System.Drawing.Size(451, 581)
        Me.TabLights.TabIndex = 2
        Me.TabLights.Text = "Lighting"
        Me.TabLights.UseVisualStyleBackColor = True
        '
        'gbLights
        '
        Me.gbLights.Controls.Add(Me.plLightColor)
        Me.gbLights.Controls.Add(Me.txtLightAttenuationC)
        Me.gbLights.Controls.Add(Me.txtLightAttenuationB)
        Me.gbLights.Controls.Add(Me.txtLightAttenuationA)
        Me.gbLights.Controls.Add(Me.lblLightAttenuation)
        Me.gbLights.Controls.Add(Me.txtLightAngleOuter)
        Me.gbLights.Controls.Add(Me.lblLightRange)
        Me.gbLights.Controls.Add(Me.txtLightRange)
        Me.gbLights.Controls.Add(Me.lblLightFalloff)
        Me.gbLights.Controls.Add(Me.txtLightFalloff)
        Me.gbLights.Controls.Add(Me.lblLightAngle)
        Me.gbLights.Controls.Add(Me.txtLightAngleInner)
        Me.gbLights.Controls.Add(Me.tbLightAmbient)
        Me.gbLights.Controls.Add(Me.lblLightAmbient)
        Me.gbLights.Controls.Add(Me.lblLightHighlight)
        Me.gbLights.Controls.Add(Me.lblLightType)
        Me.gbLights.Controls.Add(Me.txtLightPositionZ)
        Me.gbLights.Controls.Add(Me.txtLightPositionY)
        Me.gbLights.Controls.Add(Me.txtLightPositionX)
        Me.gbLights.Controls.Add(Me.lblLightPosition)
        Me.gbLights.Controls.Add(Me.chLightsEnable)
        Me.gbLights.Controls.Add(Me.listLights)
        Me.gbLights.Controls.Add(Me.txtLightName)
        Me.gbLights.Controls.Add(Me.lblLightName)
        Me.gbLights.Controls.Add(Me.txtLightDirectionZ)
        Me.gbLights.Controls.Add(Me.lblLightDirection)
        Me.gbLights.Controls.Add(Me.txtLightDirectionY)
        Me.gbLights.Controls.Add(Me.txtLightDirectionX)
        Me.gbLights.Controls.Add(Me.lblLightColor)
        Me.gbLights.Controls.Add(Me.tbLightHighlight)
        Me.gbLights.Controls.Add(Me.cbLightType)
        Me.gbLights.Location = New System.Drawing.Point(0, 0)
        Me.gbLights.Name = "gbLights"
        Me.gbLights.Size = New System.Drawing.Size(451, 528)
        Me.gbLights.TabIndex = 65
        Me.gbLights.TabStop = False
        Me.gbLights.Text = "Lights"
        '
        'plLightColor
        '
        Me.plLightColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plLightColor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plLightColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plLightColor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plLightColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plLightColor.Location = New System.Drawing.Point(151, 326)
        Me.plLightColor.Name = "plLightColor"
        Me.plLightColor.Size = New System.Drawing.Size(292, 21)
        Me.plLightColor.TabIndex = 10
        Me.plLightColor.UseVisualStyleBackColor = False
        '
        'txtLightAttenuationC
        '
        Me.txtLightAttenuationC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightAttenuationC.Location = New System.Drawing.Point(346, 447)
        Me.txtLightAttenuationC.Name = "txtLightAttenuationC"
        Me.txtLightAttenuationC.Size = New System.Drawing.Size(97, 35)
        Me.txtLightAttenuationC.TabIndex = 16
        Me.txtLightAttenuationC.Text = "0"
        Me.txtLightAttenuationC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLightAttenuationB
        '
        Me.txtLightAttenuationB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightAttenuationB.Location = New System.Drawing.Point(248, 447)
        Me.txtLightAttenuationB.Name = "txtLightAttenuationB"
        Me.txtLightAttenuationB.Size = New System.Drawing.Size(98, 35)
        Me.txtLightAttenuationB.TabIndex = 15
        Me.txtLightAttenuationB.Text = "0"
        Me.txtLightAttenuationB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLightAttenuationA
        '
        Me.txtLightAttenuationA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightAttenuationA.Location = New System.Drawing.Point(151, 447)
        Me.txtLightAttenuationA.Name = "txtLightAttenuationA"
        Me.txtLightAttenuationA.Size = New System.Drawing.Size(97, 35)
        Me.txtLightAttenuationA.TabIndex = 14
        Me.txtLightAttenuationA.Text = "0"
        Me.txtLightAttenuationA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLightAttenuation
        '
        Me.lblLightAttenuation.AutoEllipsis = True
        Me.lblLightAttenuation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLightAttenuation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLightAttenuation.Location = New System.Drawing.Point(3, 445)
        Me.lblLightAttenuation.Name = "lblLightAttenuation"
        Me.lblLightAttenuation.Size = New System.Drawing.Size(135, 25)
        Me.lblLightAttenuation.TabIndex = 114
        Me.lblLightAttenuation.Text = "Attenuation A, B, C:"
        Me.lblLightAttenuation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLightAttenuation.UseMnemonic = False
        '
        'txtLightAngleOuter
        '
        Me.txtLightAngleOuter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightAngleOuter.Location = New System.Drawing.Point(297, 474)
        Me.txtLightAngleOuter.Name = "txtLightAngleOuter"
        Me.txtLightAngleOuter.Size = New System.Drawing.Size(146, 35)
        Me.txtLightAngleOuter.TabIndex = 18
        Me.txtLightAngleOuter.Text = "45"
        Me.txtLightAngleOuter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLightRange
        '
        Me.lblLightRange.AutoEllipsis = True
        Me.lblLightRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLightRange.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLightRange.Location = New System.Drawing.Point(3, 417)
        Me.lblLightRange.Name = "lblLightRange"
        Me.lblLightRange.Size = New System.Drawing.Size(114, 25)
        Me.lblLightRange.TabIndex = 112
        Me.lblLightRange.Text = "Range (m): "
        Me.lblLightRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLightRange.UseMnemonic = False
        '
        'txtLightRange
        '
        Me.txtLightRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightRange.Location = New System.Drawing.Point(151, 419)
        Me.txtLightRange.Name = "txtLightRange"
        Me.txtLightRange.Size = New System.Drawing.Size(292, 35)
        Me.txtLightRange.TabIndex = 13
        Me.txtLightRange.Text = "45"
        Me.txtLightRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLightFalloff
        '
        Me.lblLightFalloff.AutoEllipsis = True
        Me.lblLightFalloff.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLightFalloff.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLightFalloff.Location = New System.Drawing.Point(3, 499)
        Me.lblLightFalloff.Name = "lblLightFalloff"
        Me.lblLightFalloff.Size = New System.Drawing.Size(135, 25)
        Me.lblLightFalloff.TabIndex = 110
        Me.lblLightFalloff.Text = "Inner to Outer Falloff: "
        Me.lblLightFalloff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLightFalloff.UseMnemonic = False
        '
        'txtLightFalloff
        '
        Me.txtLightFalloff.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightFalloff.Location = New System.Drawing.Point(151, 501)
        Me.txtLightFalloff.Name = "txtLightFalloff"
        Me.txtLightFalloff.Size = New System.Drawing.Size(292, 35)
        Me.txtLightFalloff.TabIndex = 19
        Me.txtLightFalloff.Text = "1"
        Me.txtLightFalloff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLightAngle
        '
        Me.lblLightAngle.AutoEllipsis = True
        Me.lblLightAngle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLightAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLightAngle.Location = New System.Drawing.Point(3, 472)
        Me.lblLightAngle.Name = "lblLightAngle"
        Me.lblLightAngle.Size = New System.Drawing.Size(135, 25)
        Me.lblLightAngle.TabIndex = 108
        Me.lblLightAngle.Text = "Inner, Outer Angle (°): "
        Me.lblLightAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLightAngle.UseMnemonic = False
        '
        'txtLightAngleInner
        '
        Me.txtLightAngleInner.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightAngleInner.Location = New System.Drawing.Point(151, 474)
        Me.txtLightAngleInner.Name = "txtLightAngleInner"
        Me.txtLightAngleInner.Size = New System.Drawing.Size(146, 35)
        Me.txtLightAngleInner.TabIndex = 17
        Me.txtLightAngleInner.Text = "45"
        Me.txtLightAngleInner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbLightAmbient
        '
        Me.tbLightAmbient.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbLightAmbient.LargeChange = 15
        Me.tbLightAmbient.Location = New System.Drawing.Point(151, 386)
        Me.tbLightAmbient.Maximum = 100
        Me.tbLightAmbient.Name = "tbLightAmbient"
        Me.tbLightAmbient.Size = New System.Drawing.Size(292, 90)
        Me.tbLightAmbient.SmallChange = 15
        Me.tbLightAmbient.TabIndex = 12
        Me.tbLightAmbient.TickFrequency = 5
        Me.tbLightAmbient.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbLightAmbient.Value = 10
        '
        'lblLightAmbient
        '
        Me.lblLightAmbient.AutoEllipsis = True
        Me.lblLightAmbient.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLightAmbient.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLightAmbient.Location = New System.Drawing.Point(3, 386)
        Me.lblLightAmbient.Name = "lblLightAmbient"
        Me.lblLightAmbient.Size = New System.Drawing.Size(122, 17)
        Me.lblLightAmbient.TabIndex = 103
        Me.lblLightAmbient.Text = "Ambient Lighting: "
        Me.lblLightAmbient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLightAmbient.UseMnemonic = False
        '
        'lblLightHighlight
        '
        Me.lblLightHighlight.AutoEllipsis = True
        Me.lblLightHighlight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLightHighlight.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLightHighlight.Location = New System.Drawing.Point(3, 354)
        Me.lblLightHighlight.Name = "lblLightHighlight"
        Me.lblLightHighlight.Size = New System.Drawing.Size(135, 17)
        Me.lblLightHighlight.TabIndex = 105
        Me.lblLightHighlight.Text = "Highlight Intensity: "
        Me.lblLightHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLightHighlight.UseMnemonic = False
        '
        'lblLightType
        '
        Me.lblLightType.AutoEllipsis = True
        Me.lblLightType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLightType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLightType.Location = New System.Drawing.Point(3, 242)
        Me.lblLightType.Name = "lblLightType"
        Me.lblLightType.Size = New System.Drawing.Size(114, 23)
        Me.lblLightType.TabIndex = 101
        Me.lblLightType.Text = "Type of Light: "
        Me.lblLightType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLightType.UseMnemonic = False
        '
        'txtLightPositionZ
        '
        Me.txtLightPositionZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightPositionZ.Location = New System.Drawing.Point(346, 271)
        Me.txtLightPositionZ.Name = "txtLightPositionZ"
        Me.txtLightPositionZ.Size = New System.Drawing.Size(97, 35)
        Me.txtLightPositionZ.TabIndex = 6
        Me.txtLightPositionZ.Text = "0"
        Me.txtLightPositionZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLightPositionY
        '
        Me.txtLightPositionY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightPositionY.Location = New System.Drawing.Point(248, 271)
        Me.txtLightPositionY.Name = "txtLightPositionY"
        Me.txtLightPositionY.Size = New System.Drawing.Size(98, 35)
        Me.txtLightPositionY.TabIndex = 5
        Me.txtLightPositionY.Text = "0"
        Me.txtLightPositionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLightPositionX
        '
        Me.txtLightPositionX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightPositionX.Location = New System.Drawing.Point(151, 271)
        Me.txtLightPositionX.Name = "txtLightPositionX"
        Me.txtLightPositionX.Size = New System.Drawing.Size(97, 35)
        Me.txtLightPositionX.TabIndex = 4
        Me.txtLightPositionX.Text = "0"
        Me.txtLightPositionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLightPosition
        '
        Me.lblLightPosition.AutoEllipsis = True
        Me.lblLightPosition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLightPosition.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLightPosition.Location = New System.Drawing.Point(3, 271)
        Me.lblLightPosition.Name = "lblLightPosition"
        Me.lblLightPosition.Size = New System.Drawing.Size(122, 21)
        Me.lblLightPosition.TabIndex = 97
        Me.lblLightPosition.Text = "Position X,Y,Z  (m):"
        Me.lblLightPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLightPosition.UseMnemonic = False
        '
        'chLightsEnable
        '
        Me.chLightsEnable.AutoEllipsis = True
        Me.chLightsEnable.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chLightsEnable.Checked = True
        Me.chLightsEnable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chLightsEnable.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chLightsEnable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chLightsEnable.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chLightsEnable.Location = New System.Drawing.Point(6, 20)
        Me.chLightsEnable.Name = "chLightsEnable"
        Me.chLightsEnable.Size = New System.Drawing.Size(347, 22)
        Me.chLightsEnable.TabIndex = 0
        Me.chLightsEnable.Text = "Enable Lighting"
        Me.chLightsEnable.UseMnemonic = False
        Me.chLightsEnable.UseVisualStyleBackColor = True
        '
        'listLights
        '
        Me.listLights.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.listLights.ForeColor = System.Drawing.SystemColors.ControlText
        Me.listLights.IntegralHeight = False
        Me.listLights.ItemHeight = 27
        Me.listLights.Location = New System.Drawing.Point(6, 48)
        Me.listLights.Name = "listLights"
        Me.listLights.Size = New System.Drawing.Size(437, 159)
        Me.listLights.TabIndex = 1
        '
        'txtLightName
        '
        Me.txtLightName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightName.Location = New System.Drawing.Point(151, 213)
        Me.txtLightName.Name = "txtLightName"
        Me.txtLightName.Size = New System.Drawing.Size(292, 35)
        Me.txtLightName.TabIndex = 2
        Me.txtLightName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLightName
        '
        Me.lblLightName.AutoEllipsis = True
        Me.lblLightName.BackColor = System.Drawing.Color.Transparent
        Me.lblLightName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLightName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLightName.Location = New System.Drawing.Point(3, 213)
        Me.lblLightName.Name = "lblLightName"
        Me.lblLightName.Size = New System.Drawing.Size(122, 21)
        Me.lblLightName.TabIndex = 87
        Me.lblLightName.Text = "Name: "
        Me.lblLightName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLightName.UseMnemonic = False
        '
        'txtLightDirectionZ
        '
        Me.txtLightDirectionZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightDirectionZ.Location = New System.Drawing.Point(346, 298)
        Me.txtLightDirectionZ.Name = "txtLightDirectionZ"
        Me.txtLightDirectionZ.Size = New System.Drawing.Size(97, 35)
        Me.txtLightDirectionZ.TabIndex = 9
        Me.txtLightDirectionZ.Text = "0"
        Me.txtLightDirectionZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLightDirection
        '
        Me.lblLightDirection.AutoEllipsis = True
        Me.lblLightDirection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLightDirection.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLightDirection.Location = New System.Drawing.Point(3, 298)
        Me.lblLightDirection.Name = "lblLightDirection"
        Me.lblLightDirection.Size = New System.Drawing.Size(135, 21)
        Me.lblLightDirection.TabIndex = 88
        Me.lblLightDirection.Text = "Direction X,Y,Z:"
        Me.lblLightDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLightDirection.UseMnemonic = False
        '
        'txtLightDirectionY
        '
        Me.txtLightDirectionY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightDirectionY.Location = New System.Drawing.Point(248, 298)
        Me.txtLightDirectionY.Name = "txtLightDirectionY"
        Me.txtLightDirectionY.Size = New System.Drawing.Size(98, 35)
        Me.txtLightDirectionY.TabIndex = 8
        Me.txtLightDirectionY.Text = "0"
        Me.txtLightDirectionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLightDirectionX
        '
        Me.txtLightDirectionX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLightDirectionX.Location = New System.Drawing.Point(151, 298)
        Me.txtLightDirectionX.Name = "txtLightDirectionX"
        Me.txtLightDirectionX.Size = New System.Drawing.Size(97, 35)
        Me.txtLightDirectionX.TabIndex = 7
        Me.txtLightDirectionX.Text = "0"
        Me.txtLightDirectionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLightColor
        '
        Me.lblLightColor.AutoEllipsis = True
        Me.lblLightColor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLightColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLightColor.Location = New System.Drawing.Point(3, 325)
        Me.lblLightColor.Name = "lblLightColor"
        Me.lblLightColor.Size = New System.Drawing.Size(122, 23)
        Me.lblLightColor.TabIndex = 89
        Me.lblLightColor.Text = "Color: "
        Me.lblLightColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLightColor.UseMnemonic = False
        '
        'tbLightHighlight
        '
        Me.tbLightHighlight.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbLightHighlight.LargeChange = 15
        Me.tbLightHighlight.Location = New System.Drawing.Point(151, 354)
        Me.tbLightHighlight.Maximum = 255
        Me.tbLightHighlight.Name = "tbLightHighlight"
        Me.tbLightHighlight.Size = New System.Drawing.Size(292, 90)
        Me.tbLightHighlight.SmallChange = 5
        Me.tbLightHighlight.TabIndex = 11
        Me.tbLightHighlight.TickFrequency = 5
        Me.tbLightHighlight.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbLightHighlight.Value = 50
        '
        'cbLightType
        '
        Me.cbLightType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLightType.FormattingEnabled = True
        Me.cbLightType.Items.AddRange(New Object() {"Directional", "Point", "Spot"})
        Me.cbLightType.Location = New System.Drawing.Point(151, 242)
        Me.cbLightType.Name = "cbLightType"
        Me.cbLightType.Size = New System.Drawing.Size(292, 35)
        Me.cbLightType.TabIndex = 3
        '
        'cmdLightAdd
        '
        Me.cmdLightAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmdLightAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdLightAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLightAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLightAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdLightAdd.Location = New System.Drawing.Point(0, 534)
        Me.cmdLightAdd.Name = "cmdLightAdd"
        Me.cmdLightAdd.Size = New System.Drawing.Size(451, 30)
        Me.cmdLightAdd.TabIndex = 0
        Me.cmdLightAdd.Text = "Add Light"
        Me.cmdLightAdd.UseVisualStyleBackColor = False
        '
        'cmdLightRemove
        '
        Me.cmdLightRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmdLightRemove.Enabled = False
        Me.cmdLightRemove.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdLightRemove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLightRemove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLightRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdLightRemove.Location = New System.Drawing.Point(227, 563)
        Me.cmdLightRemove.Name = "cmdLightRemove"
        Me.cmdLightRemove.Size = New System.Drawing.Size(224, 30)
        Me.cmdLightRemove.TabIndex = 2
        Me.cmdLightRemove.Text = "Remove Light"
        Me.cmdLightRemove.UseVisualStyleBackColor = False
        '
        'cmdLightReplace
        '
        Me.cmdLightReplace.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmdLightReplace.Enabled = False
        Me.cmdLightReplace.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdLightReplace.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLightReplace.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLightReplace.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdLightReplace.Location = New System.Drawing.Point(0, 563)
        Me.cmdLightReplace.Name = "cmdLightReplace"
        Me.cmdLightReplace.Size = New System.Drawing.Size(228, 30)
        Me.cmdLightReplace.TabIndex = 1
        Me.cmdLightReplace.Text = "Replace Light"
        Me.cmdLightReplace.UseVisualStyleBackColor = False
        '
        'TabDisplay
        '
        Me.TabDisplay.BackColor = System.Drawing.SystemColors.Control
        Me.TabDisplay.Controls.Add(Me.GroupBox1)
        Me.TabDisplay.Controls.Add(Me.Rendering)
        Me.TabDisplay.Controls.Add(Me.CmdSaveOut)
        Me.TabDisplay.Location = New System.Drawing.Point(4, 37)
        Me.TabDisplay.Name = "TabDisplay"
        Me.TabDisplay.Size = New System.Drawing.Size(451, 583)
        Me.TabDisplay.TabIndex = 6
        Me.TabDisplay.Text = "Rendering"
        Me.TabDisplay.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label47)
        Me.GroupBox1.Controls.Add(Me.chCamera)
        Me.GroupBox1.Controls.Add(Me.txtCPosZ)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtCOrientZ)
        Me.GroupBox1.Controls.Add(Me.txtCTargetY)
        Me.GroupBox1.Controls.Add(Me.txtCPosX)
        Me.GroupBox1.Controls.Add(Me.txtCTargetZ)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtCTargetX)
        Me.GroupBox1.Controls.Add(Me.txtCPosY)
        Me.GroupBox1.Controls.Add(Me.txtCOrientX)
        Me.GroupBox1.Controls.Add(Me.txtCOrientY)
        Me.GroupBox1.Controls.Add(Me.tbCameraSpeed)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 328)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(451, 173)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Camera"
        '
        'Label47
        '
        Me.Label47.AutoEllipsis = True
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label47.Location = New System.Drawing.Point(2, 124)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(178, 21)
        Me.Label47.TabIndex = 103
        Me.Label47.Text = "Camera Movement Speed: "
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label47.UseMnemonic = False
        '
        'chCamera
        '
        Me.chCamera.AutoEllipsis = True
        Me.chCamera.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chCamera.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chCamera.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chCamera.Location = New System.Drawing.Point(5, 20)
        Me.chCamera.Name = "chCamera"
        Me.chCamera.Size = New System.Drawing.Size(310, 27)
        Me.chCamera.TabIndex = 42
        Me.chCamera.Text = "Modify Default Camera Settings"
        Me.chCamera.UseMnemonic = False
        Me.chCamera.UseVisualStyleBackColor = True
        '
        'txtCPosZ
        '
        Me.txtCPosZ.Enabled = False
        Me.txtCPosZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCPosZ.Location = New System.Drawing.Point(370, 50)
        Me.txtCPosZ.Name = "txtCPosZ"
        Me.txtCPosZ.Size = New System.Drawing.Size(73, 35)
        Me.txtCPosZ.TabIndex = 2
        Me.txtCPosZ.Text = "-10"
        Me.txtCPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoEllipsis = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(2, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(188, 22)
        Me.Label11.TabIndex = 100
        Me.Label11.Text = "Camera Position X,Y,Z (m): "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.UseMnemonic = False
        '
        'Label16
        '
        Me.Label16.AutoEllipsis = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(2, 73)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(188, 23)
        Me.Label16.TabIndex = 101
        Me.Label16.Text = "Camera Target X,Y,Z: "
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.UseMnemonic = False
        '
        'txtCOrientZ
        '
        Me.txtCOrientZ.Enabled = False
        Me.txtCOrientZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCOrientZ.Location = New System.Drawing.Point(370, 97)
        Me.txtCOrientZ.Name = "txtCOrientZ"
        Me.txtCOrientZ.Size = New System.Drawing.Size(73, 35)
        Me.txtCOrientZ.TabIndex = 8
        Me.txtCOrientZ.Text = "0"
        Me.txtCOrientZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCTargetY
        '
        Me.txtCTargetY.Enabled = False
        Me.txtCTargetY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCTargetY.Location = New System.Drawing.Point(297, 74)
        Me.txtCTargetY.Name = "txtCTargetY"
        Me.txtCTargetY.Size = New System.Drawing.Size(73, 35)
        Me.txtCTargetY.TabIndex = 4
        Me.txtCTargetY.Text = "0"
        Me.txtCTargetY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCPosX
        '
        Me.txtCPosX.Enabled = False
        Me.txtCPosX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCPosX.Location = New System.Drawing.Point(225, 50)
        Me.txtCPosX.Name = "txtCPosX"
        Me.txtCPosX.Size = New System.Drawing.Size(72, 35)
        Me.txtCPosX.TabIndex = 0
        Me.txtCPosX.Text = "0"
        Me.txtCPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCTargetZ
        '
        Me.txtCTargetZ.Enabled = False
        Me.txtCTargetZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCTargetZ.Location = New System.Drawing.Point(370, 74)
        Me.txtCTargetZ.Name = "txtCTargetZ"
        Me.txtCTargetZ.Size = New System.Drawing.Size(73, 35)
        Me.txtCTargetZ.TabIndex = 5
        Me.txtCTargetZ.Text = "0"
        Me.txtCTargetZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoEllipsis = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(2, 97)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(188, 21)
        Me.Label17.TabIndex = 102
        Me.Label17.Text = "Camera Up Orientation X,Y,Z: "
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label17.UseMnemonic = False
        '
        'txtCTargetX
        '
        Me.txtCTargetX.Enabled = False
        Me.txtCTargetX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCTargetX.Location = New System.Drawing.Point(225, 74)
        Me.txtCTargetX.Name = "txtCTargetX"
        Me.txtCTargetX.Size = New System.Drawing.Size(72, 35)
        Me.txtCTargetX.TabIndex = 3
        Me.txtCTargetX.Text = "0"
        Me.txtCTargetX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCPosY
        '
        Me.txtCPosY.Enabled = False
        Me.txtCPosY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCPosY.Location = New System.Drawing.Point(297, 50)
        Me.txtCPosY.Name = "txtCPosY"
        Me.txtCPosY.Size = New System.Drawing.Size(73, 35)
        Me.txtCPosY.TabIndex = 1
        Me.txtCPosY.Text = "0"
        Me.txtCPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCOrientX
        '
        Me.txtCOrientX.Enabled = False
        Me.txtCOrientX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCOrientX.Location = New System.Drawing.Point(225, 97)
        Me.txtCOrientX.Name = "txtCOrientX"
        Me.txtCOrientX.Size = New System.Drawing.Size(72, 35)
        Me.txtCOrientX.TabIndex = 6
        Me.txtCOrientX.Text = "0"
        Me.txtCOrientX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCOrientY
        '
        Me.txtCOrientY.Enabled = False
        Me.txtCOrientY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCOrientY.Location = New System.Drawing.Point(297, 97)
        Me.txtCOrientY.Name = "txtCOrientY"
        Me.txtCOrientY.Size = New System.Drawing.Size(73, 35)
        Me.txtCOrientY.TabIndex = 7
        Me.txtCOrientY.Text = "1"
        Me.txtCOrientY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbCameraSpeed
        '
        Me.tbCameraSpeed.BackColor = System.Drawing.SystemColors.Control
        Me.tbCameraSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbCameraSpeed.LargeChange = 10
        Me.tbCameraSpeed.Location = New System.Drawing.Point(225, 126)
        Me.tbCameraSpeed.Maximum = 40
        Me.tbCameraSpeed.Minimum = 10
        Me.tbCameraSpeed.Name = "tbCameraSpeed"
        Me.tbCameraSpeed.Size = New System.Drawing.Size(218, 90)
        Me.tbCameraSpeed.TabIndex = 9
        Me.tbCameraSpeed.TickFrequency = 5
        Me.tbCameraSpeed.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbCameraSpeed.Value = 23
        '
        'Rendering
        '
        Me.Rendering.Controls.Add(Me.Label3)
        Me.Rendering.Controls.Add(Me.txtRenderThreads)
        Me.Rendering.Controls.Add(Me.Label46)
        Me.Rendering.Controls.Add(Me.txtVFoV)
        Me.Rendering.Controls.Add(Me.Label45)
        Me.Rendering.Controls.Add(Me.cbRender)
        Me.Rendering.Controls.Add(Me.Label44)
        Me.Rendering.Controls.Add(Me.txtMaxFPS)
        Me.Rendering.Controls.Add(Me.chVSync)
        Me.Rendering.Controls.Add(Me.Label43)
        Me.Rendering.Controls.Add(Me.cbShading)
        Me.Rendering.Controls.Add(Me.tbPolys)
        Me.Rendering.Controls.Add(Me.Label30)
        Me.Rendering.Controls.Add(Me.txtWindowX)
        Me.Rendering.Controls.Add(Me.Label12)
        Me.Rendering.Controls.Add(Me.Label18)
        Me.Rendering.Controls.Add(Me.Label13)
        Me.Rendering.Controls.Add(Me.txtHFoV)
        Me.Rendering.Controls.Add(Me.chTrace)
        Me.Rendering.Controls.Add(Me.txtWindowY)
        Me.Rendering.Controls.Add(Me.plRenderBackColor)
        Me.Rendering.Location = New System.Drawing.Point(0, 0)
        Me.Rendering.Name = "Rendering"
        Me.Rendering.Size = New System.Drawing.Size(451, 322)
        Me.Rendering.TabIndex = 90
        Me.Rendering.TabStop = False
        Me.Rendering.Text = "Render"
        '
        'Label3
        '
        Me.Label3.AutoEllipsis = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(2, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(182, 25)
        Me.Label3.TabIndex = 245
        Me.Label3.Text = "Render Thread Count: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.UseMnemonic = False
        '
        'txtRenderThreads
        '
        Me.txtRenderThreads.Enabled = False
        Me.txtRenderThreads.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtRenderThreads.Location = New System.Drawing.Point(225, 46)
        Me.txtRenderThreads.MaxLength = 4
        Me.txtRenderThreads.Name = "txtRenderThreads"
        Me.txtRenderThreads.Size = New System.Drawing.Size(218, 35)
        Me.txtRenderThreads.TabIndex = 1
        Me.txtRenderThreads.Text = "1"
        Me.txtRenderThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label46
        '
        Me.Label46.AutoEllipsis = True
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label46.Location = New System.Drawing.Point(2, 126)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(182, 25)
        Me.Label46.TabIndex = 129
        Me.Label46.Text = "Vertical Field of View (°): "
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label46.UseMnemonic = False
        '
        'txtVFoV
        '
        Me.txtVFoV.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtVFoV.Location = New System.Drawing.Point(225, 128)
        Me.txtVFoV.Name = "txtVFoV"
        Me.txtVFoV.Size = New System.Drawing.Size(218, 35)
        Me.txtVFoV.TabIndex = 5
        Me.txtVFoV.Text = "45"
        Me.txtVFoV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label45
        '
        Me.Label45.AutoEllipsis = True
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label45.Location = New System.Drawing.Point(2, 17)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(174, 21)
        Me.Label45.TabIndex = 126
        Me.Label45.Text = "Render Mode: "
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label45.UseMnemonic = False
        '
        'cbRender
        '
        Me.cbRender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRender.FormattingEnabled = True
        Me.cbRender.Items.AddRange(New Object() {"DirectX 9 (Hardware)", "DirectX 9 (Software)", "Raytracing (Software)"})
        Me.cbRender.Location = New System.Drawing.Point(225, 17)
        Me.cbRender.Name = "cbRender"
        Me.cbRender.Size = New System.Drawing.Size(218, 35)
        Me.cbRender.TabIndex = 0
        '
        'Label44
        '
        Me.Label44.AutoEllipsis = True
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label44.Location = New System.Drawing.Point(2, 286)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(182, 25)
        Me.Label44.TabIndex = 124
        Me.Label44.Text = "Maximum Frame Rate (F/s): "
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label44.UseMnemonic = False
        '
        'txtMaxFPS
        '
        Me.txtMaxFPS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMaxFPS.Location = New System.Drawing.Point(225, 288)
        Me.txtMaxFPS.Name = "txtMaxFPS"
        Me.txtMaxFPS.Size = New System.Drawing.Size(218, 35)
        Me.txtMaxFPS.TabIndex = 11
        Me.txtMaxFPS.Text = "45"
        Me.txtMaxFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chVSync
        '
        Me.chVSync.AutoEllipsis = True
        Me.chVSync.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chVSync.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chVSync.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chVSync.Location = New System.Drawing.Point(5, 264)
        Me.chVSync.Name = "chVSync"
        Me.chVSync.Size = New System.Drawing.Size(316, 19)
        Me.chVSync.TabIndex = 10
        Me.chVSync.Text = "Synchronize Frame Rate to Monitor (vsync)"
        Me.chVSync.UseMnemonic = False
        Me.chVSync.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.AutoEllipsis = True
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(2, 184)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(174, 21)
        Me.Label43.TabIndex = 120
        Me.Label43.Text = "Light Shading Mode: "
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label43.UseMnemonic = False
        '
        'cbShading
        '
        Me.cbShading.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbShading.FormattingEnabled = True
        Me.cbShading.Items.AddRange(New Object() {"Flat", "Gouraud"})
        Me.cbShading.Location = New System.Drawing.Point(225, 184)
        Me.cbShading.Name = "cbShading"
        Me.cbShading.Size = New System.Drawing.Size(218, 35)
        Me.cbShading.TabIndex = 7
        '
        'tbPolys
        '
        Me.tbPolys.BackColor = System.Drawing.SystemColors.Control
        Me.tbPolys.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbPolys.LargeChange = 10
        Me.tbPolys.Location = New System.Drawing.Point(225, 213)
        Me.tbPolys.Maximum = 100
        Me.tbPolys.Minimum = 2
        Me.tbPolys.Name = "tbPolys"
        Me.tbPolys.Size = New System.Drawing.Size(218, 90)
        Me.tbPolys.TabIndex = 8
        Me.tbPolys.TickFrequency = 5
        Me.tbPolys.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPolys.Value = 40
        '
        'Label30
        '
        Me.Label30.AutoEllipsis = True
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(2, 213)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(178, 21)
        Me.Label30.TabIndex = 117
        Me.Label30.Text = "Sphere Polygon Count: "
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label30.UseMnemonic = False
        '
        'txtWindowX
        '
        Me.txtWindowX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtWindowX.Location = New System.Drawing.Point(225, 74)
        Me.txtWindowX.Name = "txtWindowX"
        Me.txtWindowX.Size = New System.Drawing.Size(109, 35)
        Me.txtWindowX.TabIndex = 2
        Me.txtWindowX.Text = "500"
        Me.txtWindowX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoEllipsis = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(2, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(183, 25)
        Me.Label12.TabIndex = 115
        Me.Label12.Text = "Window Size X,Y (px): "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label12.UseMnemonic = False
        '
        'Label18
        '
        Me.Label18.AutoEllipsis = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(2, 99)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(182, 25)
        Me.Label18.TabIndex = 116
        Me.Label18.Text = "Horizontal Field of View (°): "
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label18.UseMnemonic = False
        '
        'Label13
        '
        Me.Label13.AutoEllipsis = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(2, 155)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(177, 23)
        Me.Label13.TabIndex = 114
        Me.Label13.Text = "Background Color: "
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label13.UseMnemonic = False
        '
        'txtHFoV
        '
        Me.txtHFoV.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtHFoV.Location = New System.Drawing.Point(225, 101)
        Me.txtHFoV.Name = "txtHFoV"
        Me.txtHFoV.Size = New System.Drawing.Size(218, 35)
        Me.txtHFoV.TabIndex = 4
        Me.txtHFoV.Text = "45"
        Me.txtHFoV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chTrace
        '
        Me.chTrace.AutoEllipsis = True
        Me.chTrace.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chTrace.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chTrace.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chTrace.Location = New System.Drawing.Point(5, 237)
        Me.chTrace.Name = "chTrace"
        Me.chTrace.Size = New System.Drawing.Size(345, 24)
        Me.chTrace.TabIndex = 9
        Me.chTrace.Text = "Trace Object Paths"
        Me.chTrace.UseMnemonic = False
        Me.chTrace.UseVisualStyleBackColor = True
        '
        'txtWindowY
        '
        Me.txtWindowY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtWindowY.Location = New System.Drawing.Point(334, 74)
        Me.txtWindowY.Name = "txtWindowY"
        Me.txtWindowY.Size = New System.Drawing.Size(109, 35)
        Me.txtWindowY.TabIndex = 3
        Me.txtWindowY.Text = "500"
        Me.txtWindowY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'plRenderBackColor
        '
        Me.plRenderBackColor.BackColor = System.Drawing.Color.Black
        Me.plRenderBackColor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.plRenderBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.plRenderBackColor.ForeColor = System.Drawing.Color.Black
        Me.plRenderBackColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.plRenderBackColor.Location = New System.Drawing.Point(225, 155)
        Me.plRenderBackColor.Name = "plRenderBackColor"
        Me.plRenderBackColor.Size = New System.Drawing.Size(218, 21)
        Me.plRenderBackColor.TabIndex = 6
        Me.plRenderBackColor.UseVisualStyleBackColor = False
        '
        'CmdSaveOut
        '
        Me.CmdSaveOut.Enabled = False
        Me.CmdSaveOut.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.CmdSaveOut.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdSaveOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdSaveOut.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CmdSaveOut.Location = New System.Drawing.Point(0, 563)
        Me.CmdSaveOut.Name = "CmdSaveOut"
        Me.CmdSaveOut.Size = New System.Drawing.Size(451, 30)
        Me.CmdSaveOut.TabIndex = 0
        Me.CmdSaveOut.Text = "Save Image"
        Me.CmdSaveOut.UseVisualStyleBackColor = True
        '
        'TabForces
        '
        Me.TabForces.BackColor = System.Drawing.SystemColors.Control
        Me.TabForces.Controls.Add(Me.GroupBox5)
        Me.TabForces.Controls.Add(Me.GroupBox4)
        Me.TabForces.Location = New System.Drawing.Point(4, 37)
        Me.TabForces.Name = "TabForces"
        Me.TabForces.Size = New System.Drawing.Size(451, 583)
        Me.TabForces.TabIndex = 3
        Me.TabForces.Text = "Forces & Collisions"
        Me.TabForces.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtPermittivity)
        Me.GroupBox5.Controls.Add(Me.Label48)
        Me.GroupBox5.Controls.Add(Me.txtFluidViscosity)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.txtDragCoeff)
        Me.GroupBox5.Controls.Add(Me.chForces)
        Me.GroupBox5.Controls.Add(Me.txtFluidDensity)
        Me.GroupBox5.Controls.Add(Me.chElectrostatic)
        Me.GroupBox5.Controls.Add(Me.txtFieldZ)
        Me.GroupBox5.Controls.Add(Me.chGravity)
        Me.GroupBox5.Controls.Add(Me.txtFieldY)
        Me.GroupBox5.Controls.Add(Me.chField)
        Me.GroupBox5.Controls.Add(Me.txtFieldX)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.chDrag)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.Label26)
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(451, 292)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Forces"
        '
        'txtPermittivity
        '
        Me.txtPermittivity.Enabled = False
        Me.txtPermittivity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPermittivity.Location = New System.Drawing.Point(225, 101)
        Me.txtPermittivity.Name = "txtPermittivity"
        Me.txtPermittivity.Size = New System.Drawing.Size(218, 35)
        Me.txtPermittivity.TabIndex = 3
        Me.txtPermittivity.Text = "1.0006"
        Me.txtPermittivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label48
        '
        Me.Label48.AutoEllipsis = True
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label48.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label48.Location = New System.Drawing.Point(2, 101)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(180, 21)
        Me.Label48.TabIndex = 95
        Me.Label48.Text = "Relative Permittivity of Medium:"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label48.UseMnemonic = False
        '
        'txtFluidViscosity
        '
        Me.txtFluidViscosity.Enabled = False
        Me.txtFluidViscosity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFluidViscosity.Location = New System.Drawing.Point(225, 229)
        Me.txtFluidViscosity.Name = "txtFluidViscosity"
        Me.txtFluidViscosity.Size = New System.Drawing.Size(218, 35)
        Me.txtFluidViscosity.TabIndex = 10
        Me.txtFluidViscosity.Text = "1.78E-5"
        Me.txtFluidViscosity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.AutoEllipsis = True
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(2, 229)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(180, 21)
        Me.Label29.TabIndex = 93
        Me.Label29.Text = "Fluid Viscosity (kg/ms):"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label29.UseMnemonic = False
        '
        'txtDragCoeff
        '
        Me.txtDragCoeff.Enabled = False
        Me.txtDragCoeff.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDragCoeff.Location = New System.Drawing.Point(225, 256)
        Me.txtDragCoeff.Name = "txtDragCoeff"
        Me.txtDragCoeff.Size = New System.Drawing.Size(218, 35)
        Me.txtDragCoeff.TabIndex = 11
        Me.txtDragCoeff.Text = "0.1"
        Me.txtDragCoeff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chForces
        '
        Me.chForces.AutoEllipsis = True
        Me.chForces.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chForces.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chForces.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chForces.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chForces.Location = New System.Drawing.Point(5, 20)
        Me.chForces.Name = "chForces"
        Me.chForces.Size = New System.Drawing.Size(347, 22)
        Me.chForces.TabIndex = 0
        Me.chForces.Text = "Enable Forces"
        Me.chForces.UseMnemonic = False
        Me.chForces.UseVisualStyleBackColor = True
        '
        'txtFluidDensity
        '
        Me.txtFluidDensity.Enabled = False
        Me.txtFluidDensity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFluidDensity.Location = New System.Drawing.Point(225, 202)
        Me.txtFluidDensity.Name = "txtFluidDensity"
        Me.txtFluidDensity.Size = New System.Drawing.Size(218, 35)
        Me.txtFluidDensity.TabIndex = 9
        Me.txtFluidDensity.Text = "1.225"
        Me.txtFluidDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chElectrostatic
        '
        Me.chElectrostatic.AutoEllipsis = True
        Me.chElectrostatic.Enabled = False
        Me.chElectrostatic.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chElectrostatic.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.chElectrostatic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chElectrostatic.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chElectrostatic.Location = New System.Drawing.Point(5, 76)
        Me.chElectrostatic.Name = "chElectrostatic"
        Me.chElectrostatic.Size = New System.Drawing.Size(347, 22)
        Me.chElectrostatic.TabIndex = 2
        Me.chElectrostatic.Text = "Electrostatic Force"
        Me.chElectrostatic.UseMnemonic = False
        Me.chElectrostatic.UseVisualStyleBackColor = True
        '
        'txtFieldZ
        '
        Me.txtFieldZ.Enabled = False
        Me.txtFieldZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFieldZ.Location = New System.Drawing.Point(370, 153)
        Me.txtFieldZ.Name = "txtFieldZ"
        Me.txtFieldZ.Size = New System.Drawing.Size(73, 35)
        Me.txtFieldZ.TabIndex = 7
        Me.txtFieldZ.Text = "0"
        Me.txtFieldZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chGravity
        '
        Me.chGravity.AutoEllipsis = True
        Me.chGravity.Enabled = False
        Me.chGravity.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chGravity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chGravity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chGravity.Location = New System.Drawing.Point(5, 48)
        Me.chGravity.Name = "chGravity"
        Me.chGravity.Size = New System.Drawing.Size(347, 22)
        Me.chGravity.TabIndex = 1
        Me.chGravity.Text = "Newtonian Gravity"
        Me.chGravity.UseMnemonic = False
        Me.chGravity.UseVisualStyleBackColor = True
        '
        'txtFieldY
        '
        Me.txtFieldY.Enabled = False
        Me.txtFieldY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFieldY.Location = New System.Drawing.Point(297, 153)
        Me.txtFieldY.Name = "txtFieldY"
        Me.txtFieldY.Size = New System.Drawing.Size(73, 35)
        Me.txtFieldY.TabIndex = 6
        Me.txtFieldY.Text = "0"
        Me.txtFieldY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chField
        '
        Me.chField.AutoEllipsis = True
        Me.chField.Enabled = False
        Me.chField.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chField.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chField.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chField.Location = New System.Drawing.Point(5, 128)
        Me.chField.Name = "chField"
        Me.chField.Size = New System.Drawing.Size(347, 22)
        Me.chField.TabIndex = 4
        Me.chField.Text = "Uniform Field"
        Me.chField.UseMnemonic = False
        Me.chField.UseVisualStyleBackColor = True
        '
        'txtFieldX
        '
        Me.txtFieldX.Enabled = False
        Me.txtFieldX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFieldX.Location = New System.Drawing.Point(225, 153)
        Me.txtFieldX.Name = "txtFieldX"
        Me.txtFieldX.Size = New System.Drawing.Size(72, 35)
        Me.txtFieldX.TabIndex = 5
        Me.txtFieldX.Text = "0"
        Me.txtFieldX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoEllipsis = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(2, 153)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(180, 21)
        Me.Label22.TabIndex = 89
        Me.Label22.Text = "Acceleration (m/s^2) X,Y,Z: "
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label22.UseMnemonic = False
        '
        'chDrag
        '
        Me.chDrag.AutoEllipsis = True
        Me.chDrag.Enabled = False
        Me.chDrag.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chDrag.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chDrag.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chDrag.Location = New System.Drawing.Point(5, 177)
        Me.chDrag.Name = "chDrag"
        Me.chDrag.Size = New System.Drawing.Size(166, 22)
        Me.chDrag.TabIndex = 8
        Me.chDrag.Text = "Uniform Drag"
        Me.chDrag.UseMnemonic = False
        Me.chDrag.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoEllipsis = True
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label28.Location = New System.Drawing.Point(2, 256)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(180, 21)
        Me.Label28.TabIndex = 91
        Me.Label28.Text = "Drag Coefficient:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label28.UseMnemonic = False
        '
        'Label26
        '
        Me.Label26.AutoEllipsis = True
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(2, 202)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(180, 21)
        Me.Label26.TabIndex = 90
        Me.Label26.Text = "Fluid Density (kg/m^3):"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label26.UseMnemonic = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chInterpolate)
        Me.GroupBox4.Controls.Add(Me.chCollision)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.txtCoR)
        Me.GroupBox4.Controls.Add(Me.chbreakable)
        Me.GroupBox4.Controls.Add(Me.lblResulting)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.txtAddMax)
        Me.GroupBox4.Controls.Add(Me.txtBreakMin)
        Me.GroupBox4.Controls.Add(Me.txtAddAvg)
        Me.GroupBox4.Controls.Add(Me.txtBreakAvg)
        Me.GroupBox4.Controls.Add(Me.txtAddMin)
        Me.GroupBox4.Controls.Add(Me.txtBreakMax)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 298)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(451, 188)
        Me.GroupBox4.TabIndex = 79
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Collisions"
        '
        'chInterpolate
        '
        Me.chInterpolate.AutoSize = True
        Me.chInterpolate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chInterpolate.Location = New System.Drawing.Point(5, 70)
        Me.chInterpolate.Name = "chInterpolate"
        Me.chInterpolate.Size = New System.Drawing.Size(385, 31)
        Me.chInterpolate.TabIndex = 2
        Me.chInterpolate.Text = "Interpolate Between Time Steps"
        Me.chInterpolate.UseVisualStyleBackColor = True
        '
        'chCollision
        '
        Me.chCollision.AutoEllipsis = True
        Me.chCollision.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chCollision.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chCollision.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chCollision.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chCollision.Location = New System.Drawing.Point(5, 20)
        Me.chCollision.Name = "chCollision"
        Me.chCollision.Size = New System.Drawing.Size(347, 22)
        Me.chCollision.TabIndex = 0
        Me.chCollision.Text = "Enable Collisions"
        Me.chCollision.UseMnemonic = False
        Me.chCollision.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoEllipsis = True
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(2, 43)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(176, 22)
        Me.Label20.TabIndex = 66
        Me.Label20.Text = "Coeff. of Restitution:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label20.UseMnemonic = False
        '
        'txtCoR
        '
        Me.txtCoR.Enabled = False
        Me.txtCoR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCoR.Location = New System.Drawing.Point(225, 46)
        Me.txtCoR.Name = "txtCoR"
        Me.txtCoR.Size = New System.Drawing.Size(218, 35)
        Me.txtCoR.TabIndex = 1
        Me.txtCoR.Text = "0.5"
        Me.txtCoR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chbreakable
        '
        Me.chbreakable.AutoEllipsis = True
        Me.chbreakable.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chbreakable.Enabled = False
        Me.chbreakable.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chbreakable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chbreakable.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbreakable.Location = New System.Drawing.Point(5, 95)
        Me.chbreakable.Name = "chbreakable"
        Me.chbreakable.Size = New System.Drawing.Size(347, 22)
        Me.chbreakable.TabIndex = 3
        Me.chbreakable.Text = "Breakable Collisions"
        Me.chbreakable.UseMnemonic = False
        Me.chbreakable.UseVisualStyleBackColor = True
        '
        'lblResulting
        '
        Me.lblResulting.AutoEllipsis = True
        Me.lblResulting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblResulting.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblResulting.Location = New System.Drawing.Point(2, 148)
        Me.lblResulting.Name = "lblResulting"
        Me.lblResulting.Size = New System.Drawing.Size(197, 22)
        Me.lblResulting.TabIndex = 67
        Me.lblResulting.Text = "Resulting Objects Min, Avg, Max:"
        Me.lblResulting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblResulting.UseMnemonic = False
        '
        'Label25
        '
        Me.Label25.AutoEllipsis = True
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(2, 120)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(175, 25)
        Me.Label25.TabIndex = 68
        Me.Label25.Text = "Endurance Min, Avg, Max:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label25.UseMnemonic = False
        '
        'txtAddMax
        '
        Me.txtAddMax.Enabled = False
        Me.txtAddMax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAddMax.Location = New System.Drawing.Point(370, 149)
        Me.txtAddMax.Name = "txtAddMax"
        Me.txtAddMax.Size = New System.Drawing.Size(73, 35)
        Me.txtAddMax.TabIndex = 9
        Me.txtAddMax.Text = "8"
        Me.txtAddMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBreakMin
        '
        Me.txtBreakMin.Enabled = False
        Me.txtBreakMin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBreakMin.Location = New System.Drawing.Point(225, 122)
        Me.txtBreakMin.Name = "txtBreakMin"
        Me.txtBreakMin.Size = New System.Drawing.Size(72, 35)
        Me.txtBreakMin.TabIndex = 4
        Me.txtBreakMin.Text = "50"
        Me.txtBreakMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAddAvg
        '
        Me.txtAddAvg.Enabled = False
        Me.txtAddAvg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAddAvg.Location = New System.Drawing.Point(297, 149)
        Me.txtAddAvg.Name = "txtAddAvg"
        Me.txtAddAvg.Size = New System.Drawing.Size(73, 35)
        Me.txtAddAvg.TabIndex = 8
        Me.txtAddAvg.Text = "3"
        Me.txtAddAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBreakAvg
        '
        Me.txtBreakAvg.Enabled = False
        Me.txtBreakAvg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBreakAvg.Location = New System.Drawing.Point(297, 122)
        Me.txtBreakAvg.Name = "txtBreakAvg"
        Me.txtBreakAvg.Size = New System.Drawing.Size(73, 35)
        Me.txtBreakAvg.TabIndex = 5
        Me.txtBreakAvg.Text = "100"
        Me.txtBreakAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAddMin
        '
        Me.txtAddMin.Enabled = False
        Me.txtAddMin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAddMin.Location = New System.Drawing.Point(224, 149)
        Me.txtAddMin.Name = "txtAddMin"
        Me.txtAddMin.Size = New System.Drawing.Size(72, 35)
        Me.txtAddMin.TabIndex = 7
        Me.txtAddMin.Text = "2"
        Me.txtAddMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBreakMax
        '
        Me.txtBreakMax.Enabled = False
        Me.txtBreakMax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBreakMax.Location = New System.Drawing.Point(370, 122)
        Me.txtBreakMax.Name = "txtBreakMax"
        Me.txtBreakMax.Size = New System.Drawing.Size(73, 35)
        Me.txtBreakMax.TabIndex = 6
        Me.txtBreakMax.Text = "500"
        Me.txtBreakMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabSimulation
        '
        Me.TabSimulation.BackColor = System.Drawing.SystemColors.Control
        Me.TabSimulation.Controls.Add(Me.cmdLoad)
        Me.TabSimulation.Controls.Add(Me.cmdSave)
        Me.TabSimulation.Controls.Add(Me.GroupBox3)
        Me.TabSimulation.Location = New System.Drawing.Point(4, 39)
        Me.TabSimulation.Name = "TabSimulation"
        Me.TabSimulation.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSimulation.Size = New System.Drawing.Size(451, 581)
        Me.TabSimulation.TabIndex = 0
        Me.TabSimulation.Text = "Simulation"
        Me.TabSimulation.UseVisualStyleBackColor = True
        '
        'cmdLoad
        '
        Me.cmdLoad.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdLoad.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLoad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdLoad.Location = New System.Drawing.Point(225, 563)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(226, 30)
        Me.cmdLoad.TabIndex = 1
        Me.cmdLoad.Text = "Load Simulation"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSave.Location = New System.Drawing.Point(0, 563)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(226, 30)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Text = "Save Simulation"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtLimitCalc)
        Me.GroupBox3.Controls.Add(Me.txtScale)
        Me.GroupBox3.Controls.Add(Me.txtTimeStep)
        Me.GroupBox3.Controls.Add(Me.cbIntegration)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtLimitObjects)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(451, 159)
        Me.GroupBox3.TabIndex = 89
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Simulation"
        '
        'Label1
        '
        Me.Label1.AutoEllipsis = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(2, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 21)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Time Step (s): "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.UseMnemonic = False
        '
        'Label4
        '
        Me.Label4.AutoEllipsis = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(2, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 21)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Limit Calculations (C/s): "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.UseMnemonic = False
        '
        'Label2
        '
        Me.Label2.AutoEllipsis = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(2, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 25)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "World Scale:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.UseMnemonic = False
        '
        'txtLimitCalc
        '
        Me.txtLimitCalc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLimitCalc.Location = New System.Drawing.Point(224, 44)
        Me.txtLimitCalc.Name = "txtLimitCalc"
        Me.txtLimitCalc.Size = New System.Drawing.Size(218, 35)
        Me.txtLimitCalc.TabIndex = 1
        Me.txtLimitCalc.Text = "1000"
        Me.txtLimitCalc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtScale
        '
        Me.txtScale.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtScale.Location = New System.Drawing.Point(224, 98)
        Me.txtScale.Name = "txtScale"
        Me.txtScale.Size = New System.Drawing.Size(218, 35)
        Me.txtScale.TabIndex = 3
        Me.txtScale.Text = "1"
        Me.txtScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTimeStep
        '
        Me.txtTimeStep.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTimeStep.Location = New System.Drawing.Point(224, 17)
        Me.txtTimeStep.Name = "txtTimeStep"
        Me.txtTimeStep.Size = New System.Drawing.Size(218, 35)
        Me.txtTimeStep.TabIndex = 0
        Me.txtTimeStep.Text = "0.001"
        Me.txtTimeStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbIntegration
        '
        Me.cbIntegration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbIntegration.Enabled = False
        Me.cbIntegration.FormattingEnabled = True
        Me.cbIntegration.Items.AddRange(New Object() {"1st order - Euler", "2nd order - Verlet", "4th order - Symplectic", "6th order - Symplectic"})
        Me.cbIntegration.Location = New System.Drawing.Point(224, 125)
        Me.cbIntegration.Name = "cbIntegration"
        Me.cbIntegration.Size = New System.Drawing.Size(218, 35)
        Me.cbIntegration.TabIndex = 4
        '
        'Label24
        '
        Me.Label24.AutoEllipsis = True
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(2, 71)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(161, 21)
        Me.Label24.TabIndex = 26
        Me.Label24.Text = "Limit Objects: "
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label24.UseMnemonic = False
        '
        'Label14
        '
        Me.Label14.AutoEllipsis = True
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(2, 127)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(161, 21)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Method of Integration : "
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label14.UseMnemonic = False
        '
        'txtLimitObjects
        '
        Me.txtLimitObjects.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLimitObjects.Location = New System.Drawing.Point(224, 71)
        Me.txtLimitObjects.Name = "txtLimitObjects"
        Me.txtLimitObjects.Size = New System.Drawing.Size(218, 35)
        Me.txtLimitObjects.TabIndex = 2
        Me.txtLimitObjects.Text = "200"
        Me.txtLimitObjects.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tabs
        '
        Me.Tabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.Tabs.Controls.Add(Me.TabSimulation)
        Me.Tabs.Controls.Add(Me.TabForces)
        Me.Tabs.Controls.Add(Me.TabDisplay)
        Me.Tabs.Controls.Add(Me.TabLights)
        Me.Tabs.Controls.Add(Me.TabGroups)
        Me.Tabs.Location = New System.Drawing.Point(2, 50)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(459, 624)
        Me.Tabs.TabIndex = 1
        '
        'ControlPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(461, 699)
        Me.Controls.Add(Me.Tabs)
        Me.Controls.Add(Me.Stats)
        Me.Controls.Add(Me.cmdStart)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ControlPanel"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SandBox Simulator -  Control Panel"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Stats.ResumeLayout(False)
        Me.Stats.PerformLayout()
        Me.TabGroups.ResumeLayout(False)
        Me.gbObjects.ResumeLayout(False)
        Me.gbObjects.PerformLayout()
        CType(Me.tbObjectTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbObjectReflectivity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbObjectHighlightSharpness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabLights.ResumeLayout(False)
        Me.gbLights.ResumeLayout(False)
        Me.gbLights.PerformLayout()
        CType(Me.tbLightAmbient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLightHighlight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDisplay.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tbCameraSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Rendering.ResumeLayout(False)
        Me.Rendering.PerformLayout()
        CType(Me.tbPolys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabForces.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabSimulation.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Tabs.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents ColorDialog As System.Windows.Forms.ColorDialog
    Friend WithEvents Stats As System.Windows.Forms.StatusStrip
    Friend WithEvents SaveDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblStat As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusUpdate As System.Windows.Forms.Timer
    Friend WithEvents TabGroups As System.Windows.Forms.TabPage
    Friend WithEvents gbObjects As System.Windows.Forms.GroupBox
    Friend WithEvents cmdObjectNormalZ As System.Windows.Forms.Button
    Friend WithEvents cmdObjectNormalY As System.Windows.Forms.Button
    Friend WithEvents cmdObjectSizeZ As System.Windows.Forms.Button
    Friend WithEvents cmdObjectSizeY As System.Windows.Forms.Button
    Friend WithEvents cmdObjectRefractiveIndex As System.Windows.Forms.Button
    Friend WithEvents txtObjectRefractiveIndex As System.Windows.Forms.TextBox
    Friend WithEvents lblObjectRefractiveIndex As System.Windows.Forms.Label
    Friend WithEvents lblObjectReflectivity As System.Windows.Forms.Label
    Friend WithEvents cmdObjectReflectivity As System.Windows.Forms.Button
    Friend WithEvents lblObjectType As System.Windows.Forms.Label
    Friend WithEvents cbObjectType As System.Windows.Forms.ComboBox
    Friend WithEvents chObjectWireframe As System.Windows.Forms.CheckBox
    Friend WithEvents chObjectAffected As System.Windows.Forms.CheckBox
    Friend WithEvents chObjectAffects As System.Windows.Forms.CheckBox
    Friend WithEvents cmdObjectNumber As System.Windows.Forms.Button
    Friend WithEvents lblObjectNumber As System.Windows.Forms.Label
    Friend WithEvents listGroups As System.Windows.Forms.ListBox
    Friend WithEvents cmdObjectVelocityZ As System.Windows.Forms.Button
    Friend WithEvents cmdObjectVelocityY As System.Windows.Forms.Button
    Friend WithEvents cmdObjectTransparency As System.Windows.Forms.Button
    Friend WithEvents cmdObjectHighlightSharpness As System.Windows.Forms.Button
    Friend WithEvents cmdObjectPositionZ As System.Windows.Forms.Button
    Friend WithEvents cmdObjectPositionY As System.Windows.Forms.Button
    Friend WithEvents cmdObjectHighlightColor As System.Windows.Forms.Button
    Friend WithEvents cmdObjectColor As System.Windows.Forms.Button
    Friend WithEvents cmdObjectVelocityX As System.Windows.Forms.Button
    Friend WithEvents cmdObjectPositionX As System.Windows.Forms.Button
    Friend WithEvents cmdObjectCharge As System.Windows.Forms.Button
    Friend WithEvents cmdObjectMass As System.Windows.Forms.Button
    Friend WithEvents lblObjectHighlightColor As System.Windows.Forms.Label
    Friend WithEvents lblObjectName As System.Windows.Forms.Label
    Friend WithEvents lblObjectTransparency As System.Windows.Forms.Label
    Friend WithEvents txtObjectVelocityZ As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectName As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectVelocityY As System.Windows.Forms.TextBox
    Friend WithEvents lblObjectMass As System.Windows.Forms.Label
    Friend WithEvents lblObjectCharge As System.Windows.Forms.Label
    Friend WithEvents lblObjectColor As System.Windows.Forms.Label
    Friend WithEvents lblObjectPosition As System.Windows.Forms.Label
    Friend WithEvents lblObjectVelocity As System.Windows.Forms.Label
    Friend WithEvents lblObjectHighlightSharpness As System.Windows.Forms.Label
    Friend WithEvents tbObjectTransparency As System.Windows.Forms.TrackBar
    Friend WithEvents txtObjectPositionZ As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectPositionX As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectPositionY As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectVelocityX As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectMass As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectCharge As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectNumber As System.Windows.Forms.TextBox
    Friend WithEvents tbObjectReflectivity As System.Windows.Forms.TrackBar
    Friend WithEvents tbObjectHighlightSharpness As System.Windows.Forms.TrackBar
    Friend WithEvents txtObjectSizeX As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectSizeY As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectSizeZ As System.Windows.Forms.TextBox
    Friend WithEvents cmdObjectSizeX As System.Windows.Forms.Button
    Friend WithEvents lblObjectSize As System.Windows.Forms.Label
    Friend WithEvents lblObjectNormal As System.Windows.Forms.Label
    Friend WithEvents txtObjectNormalZ As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectNormalY As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectNormalX As System.Windows.Forms.TextBox
    Friend WithEvents cmdObjectNormalX As System.Windows.Forms.Button
    Friend WithEvents txtObjectRadius As System.Windows.Forms.TextBox
    Friend WithEvents cmdObjectRadius As System.Windows.Forms.Button
    Friend WithEvents lblObjectRadius As System.Windows.Forms.Label
    Friend WithEvents txtObjectRotationZ As System.Windows.Forms.TextBox
    Friend WithEvents cmdObjectRotationZ As System.Windows.Forms.Button
    Friend WithEvents txtObjectRotationY As System.Windows.Forms.TextBox
    Friend WithEvents cmdObjectRotationY As System.Windows.Forms.Button
    Friend WithEvents txtObjectRotationX As System.Windows.Forms.TextBox
    Friend WithEvents cmdObjectRotationX As System.Windows.Forms.Button
    Friend WithEvents lblObjectRotation As System.Windows.Forms.Label
    Friend WithEvents cmdGroupAdd As System.Windows.Forms.Button
    Friend WithEvents cmdGroupRemove As System.Windows.Forms.Button
    Friend WithEvents cmdGroupReplace As System.Windows.Forms.Button
    Friend WithEvents TabLights As System.Windows.Forms.TabPage
    Friend WithEvents gbLights As System.Windows.Forms.GroupBox
    Friend WithEvents txtLightAttenuationC As System.Windows.Forms.TextBox
    Friend WithEvents txtLightAttenuationB As System.Windows.Forms.TextBox
    Friend WithEvents txtLightAttenuationA As System.Windows.Forms.TextBox
    Friend WithEvents lblLightAttenuation As System.Windows.Forms.Label
    Friend WithEvents txtLightAngleOuter As System.Windows.Forms.TextBox
    Friend WithEvents lblLightRange As System.Windows.Forms.Label
    Friend WithEvents txtLightRange As System.Windows.Forms.TextBox
    Friend WithEvents lblLightFalloff As System.Windows.Forms.Label
    Friend WithEvents txtLightFalloff As System.Windows.Forms.TextBox
    Friend WithEvents lblLightAngle As System.Windows.Forms.Label
    Friend WithEvents txtLightAngleInner As System.Windows.Forms.TextBox
    Friend WithEvents tbLightAmbient As System.Windows.Forms.TrackBar
    Friend WithEvents lblLightAmbient As System.Windows.Forms.Label
    Friend WithEvents lblLightHighlight As System.Windows.Forms.Label
    Friend WithEvents lblLightType As System.Windows.Forms.Label
    Friend WithEvents txtLightPositionZ As System.Windows.Forms.TextBox
    Friend WithEvents txtLightPositionY As System.Windows.Forms.TextBox
    Friend WithEvents txtLightPositionX As System.Windows.Forms.TextBox
    Friend WithEvents lblLightPosition As System.Windows.Forms.Label
    Friend WithEvents chLightsEnable As System.Windows.Forms.CheckBox
    Friend WithEvents listLights As System.Windows.Forms.ListBox
    Friend WithEvents txtLightName As System.Windows.Forms.TextBox
    Friend WithEvents lblLightName As System.Windows.Forms.Label
    Friend WithEvents txtLightDirectionZ As System.Windows.Forms.TextBox
    Friend WithEvents lblLightDirection As System.Windows.Forms.Label
    Friend WithEvents txtLightDirectionY As System.Windows.Forms.TextBox
    Friend WithEvents txtLightDirectionX As System.Windows.Forms.TextBox
    Friend WithEvents lblLightColor As System.Windows.Forms.Label
    Friend WithEvents tbLightHighlight As System.Windows.Forms.TrackBar
    Friend WithEvents cbLightType As System.Windows.Forms.ComboBox
    Friend WithEvents cmdLightAdd As System.Windows.Forms.Button
    Friend WithEvents cmdLightRemove As System.Windows.Forms.Button
    Friend WithEvents cmdLightReplace As System.Windows.Forms.Button
    Friend WithEvents TabDisplay As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents chCamera As System.Windows.Forms.CheckBox
    Friend WithEvents txtCPosZ As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCOrientZ As System.Windows.Forms.TextBox
    Friend WithEvents txtCTargetY As System.Windows.Forms.TextBox
    Friend WithEvents txtCPosX As System.Windows.Forms.TextBox
    Friend WithEvents txtCTargetZ As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCTargetX As System.Windows.Forms.TextBox
    Friend WithEvents txtCPosY As System.Windows.Forms.TextBox
    Friend WithEvents txtCOrientX As System.Windows.Forms.TextBox
    Friend WithEvents txtCOrientY As System.Windows.Forms.TextBox
    Friend WithEvents tbCameraSpeed As System.Windows.Forms.TrackBar
    Friend WithEvents Rendering As System.Windows.Forms.GroupBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtVFoV As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cbRender As System.Windows.Forms.ComboBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtMaxFPS As System.Windows.Forms.TextBox
    Friend WithEvents chVSync As System.Windows.Forms.CheckBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents cbShading As System.Windows.Forms.ComboBox
    Friend WithEvents tbPolys As System.Windows.Forms.TrackBar
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtWindowX As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtHFoV As System.Windows.Forms.TextBox
    Friend WithEvents chTrace As System.Windows.Forms.CheckBox
    Friend WithEvents txtWindowY As System.Windows.Forms.TextBox
    Friend WithEvents CmdSaveOut As System.Windows.Forms.Button
    Friend WithEvents TabForces As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPermittivity As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtFluidViscosity As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtDragCoeff As System.Windows.Forms.TextBox
    Friend WithEvents chForces As System.Windows.Forms.CheckBox
    Friend WithEvents txtFluidDensity As System.Windows.Forms.TextBox
    Friend WithEvents chElectrostatic As System.Windows.Forms.CheckBox
    Friend WithEvents txtFieldZ As System.Windows.Forms.TextBox
    Friend WithEvents chGravity As System.Windows.Forms.CheckBox
    Friend WithEvents txtFieldY As System.Windows.Forms.TextBox
    Friend WithEvents chField As System.Windows.Forms.CheckBox
    Friend WithEvents txtFieldX As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents chDrag As System.Windows.Forms.CheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chInterpolate As System.Windows.Forms.CheckBox
    Friend WithEvents chCollision As System.Windows.Forms.CheckBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCoR As System.Windows.Forms.TextBox
    Friend WithEvents chbreakable As System.Windows.Forms.CheckBox
    Friend WithEvents lblResulting As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtAddMax As System.Windows.Forms.TextBox
    Friend WithEvents txtBreakMin As System.Windows.Forms.TextBox
    Friend WithEvents txtAddAvg As System.Windows.Forms.TextBox
    Friend WithEvents txtBreakAvg As System.Windows.Forms.TextBox
    Friend WithEvents txtAddMin As System.Windows.Forms.TextBox
    Friend WithEvents txtBreakMax As System.Windows.Forms.TextBox
    Friend WithEvents TabSimulation As System.Windows.Forms.TabPage
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLimitCalc As System.Windows.Forms.TextBox
    Friend WithEvents txtScale As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeStep As System.Windows.Forms.TextBox
    Friend WithEvents cbIntegration As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtLimitObjects As System.Windows.Forms.TextBox
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents plObjectColor As System.Windows.Forms.Button
    Friend WithEvents plObjectHighlightColor As System.Windows.Forms.Button
    Friend WithEvents plLightColor As System.Windows.Forms.Button
    Friend WithEvents plRenderBackColor As System.Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txtRenderThreads As Windows.Forms.TextBox
End Class
