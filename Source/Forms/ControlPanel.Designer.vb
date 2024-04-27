<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlPanel
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
        resources.ApplyResources(Me.cmdStart, "cmdStart")
        Me.cmdStart.ForeColor = System.Drawing.Color.Black
        Me.cmdStart.Name = "cmdStart"
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
        resources.ApplyResources(Me.Stats, "Stats")
        Me.Stats.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Stats.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStat})
        Me.Stats.Name = "Stats"
        Me.Stats.SizingGrip = False
        '
        'lblStat
        '
        Me.lblStat.BackColor = System.Drawing.SystemColors.Control
        Me.lblStat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.lblStat, "lblStat")
        Me.lblStat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStat.LinkColor = System.Drawing.Color.White
        Me.lblStat.Name = "lblStat"
        Me.lblStat.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.lblStat.Spring = True
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
        resources.ApplyResources(Me.TabGroups, "TabGroups")
        Me.TabGroups.Name = "TabGroups"
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
        resources.ApplyResources(Me.gbObjects, "gbObjects")
        Me.gbObjects.Name = "gbObjects"
        Me.gbObjects.TabStop = False
        '
        'plObjectHighlightColor
        '
        Me.plObjectHighlightColor.BackColor = System.Drawing.Color.White
        Me.plObjectHighlightColor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.plObjectHighlightColor, "plObjectHighlightColor")
        Me.plObjectHighlightColor.ForeColor = System.Drawing.Color.White
        Me.plObjectHighlightColor.Name = "plObjectHighlightColor"
        Me.plObjectHighlightColor.UseVisualStyleBackColor = False
        '
        'plObjectColor
        '
        Me.plObjectColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.plObjectColor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.plObjectColor, "plObjectColor")
        Me.plObjectColor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.plObjectColor.Name = "plObjectColor"
        Me.plObjectColor.UseVisualStyleBackColor = False
        '
        'cmdObjectRefractiveIndex
        '
        resources.ApplyResources(Me.cmdObjectRefractiveIndex, "cmdObjectRefractiveIndex")
        Me.cmdObjectRefractiveIndex.FlatAppearance.BorderSize = 0
        Me.cmdObjectRefractiveIndex.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectRefractiveIndex.Name = "cmdObjectRefractiveIndex"
        Me.cmdObjectRefractiveIndex.UseVisualStyleBackColor = False
        '
        'txtObjectRefractiveIndex
        '
        Me.txtObjectRefractiveIndex.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtObjectRefractiveIndex, "txtObjectRefractiveIndex")
        Me.txtObjectRefractiveIndex.Name = "txtObjectRefractiveIndex"
        '
        'lblObjectRefractiveIndex
        '
        Me.lblObjectRefractiveIndex.AutoEllipsis = True
        Me.lblObjectRefractiveIndex.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectRefractiveIndex, "lblObjectRefractiveIndex")
        Me.lblObjectRefractiveIndex.Name = "lblObjectRefractiveIndex"
        Me.lblObjectRefractiveIndex.UseMnemonic = False
        '
        'lblObjectReflectivity
        '
        Me.lblObjectReflectivity.AutoEllipsis = True
        Me.lblObjectReflectivity.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectReflectivity, "lblObjectReflectivity")
        Me.lblObjectReflectivity.Name = "lblObjectReflectivity"
        Me.lblObjectReflectivity.UseMnemonic = False
        '
        'cmdObjectReflectivity
        '
        resources.ApplyResources(Me.cmdObjectReflectivity, "cmdObjectReflectivity")
        Me.cmdObjectReflectivity.FlatAppearance.BorderSize = 0
        Me.cmdObjectReflectivity.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectReflectivity.Name = "cmdObjectReflectivity"
        Me.cmdObjectReflectivity.UseVisualStyleBackColor = False
        '
        'lblObjectType
        '
        Me.lblObjectType.AutoEllipsis = True
        Me.lblObjectType.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectType, "lblObjectType")
        Me.lblObjectType.Name = "lblObjectType"
        Me.lblObjectType.UseMnemonic = False
        '
        'cbObjectType
        '
        Me.cbObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbObjectType.FormattingEnabled = True
        Me.cbObjectType.Items.AddRange(New Object() {resources.GetString("cbObjectType.Items")})
        resources.ApplyResources(Me.cbObjectType, "cbObjectType")
        Me.cbObjectType.Name = "cbObjectType"
        '
        'chObjectWireframe
        '
        Me.chObjectWireframe.AutoEllipsis = True
        resources.ApplyResources(Me.chObjectWireframe, "chObjectWireframe")
        Me.chObjectWireframe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chObjectWireframe.Name = "chObjectWireframe"
        Me.chObjectWireframe.UseMnemonic = False
        Me.chObjectWireframe.UseVisualStyleBackColor = True
        '
        'chObjectAffected
        '
        resources.ApplyResources(Me.chObjectAffected, "chObjectAffected")
        Me.chObjectAffected.Checked = True
        Me.chObjectAffected.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chObjectAffected.Name = "chObjectAffected"
        Me.chObjectAffected.UseVisualStyleBackColor = True
        '
        'chObjectAffects
        '
        resources.ApplyResources(Me.chObjectAffects, "chObjectAffects")
        Me.chObjectAffects.Checked = True
        Me.chObjectAffects.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chObjectAffects.Name = "chObjectAffects"
        Me.chObjectAffects.UseVisualStyleBackColor = True
        '
        'cmdObjectNumber
        '
        resources.ApplyResources(Me.cmdObjectNumber, "cmdObjectNumber")
        Me.cmdObjectNumber.BackColor = System.Drawing.SystemColors.Control
        Me.cmdObjectNumber.FlatAppearance.BorderSize = 0
        Me.cmdObjectNumber.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectNumber.Name = "cmdObjectNumber"
        Me.cmdObjectNumber.UseVisualStyleBackColor = False
        '
        'lblObjectNumber
        '
        Me.lblObjectNumber.AutoEllipsis = True
        Me.lblObjectNumber.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectNumber, "lblObjectNumber")
        Me.lblObjectNumber.Name = "lblObjectNumber"
        Me.lblObjectNumber.UseMnemonic = False
        '
        'listGroups
        '
        resources.ApplyResources(Me.listGroups, "listGroups")
        Me.listGroups.ForeColor = System.Drawing.SystemColors.ControlText
        Me.listGroups.Name = "listGroups"
        '
        'cmdObjectVelocityZ
        '
        resources.ApplyResources(Me.cmdObjectVelocityZ, "cmdObjectVelocityZ")
        Me.cmdObjectVelocityZ.FlatAppearance.BorderSize = 0
        Me.cmdObjectVelocityZ.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectVelocityZ.Name = "cmdObjectVelocityZ"
        Me.cmdObjectVelocityZ.UseVisualStyleBackColor = False
        '
        'cmdObjectVelocityY
        '
        resources.ApplyResources(Me.cmdObjectVelocityY, "cmdObjectVelocityY")
        Me.cmdObjectVelocityY.FlatAppearance.BorderSize = 0
        Me.cmdObjectVelocityY.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectVelocityY.Name = "cmdObjectVelocityY"
        Me.cmdObjectVelocityY.UseVisualStyleBackColor = False
        '
        'cmdObjectTransparency
        '
        resources.ApplyResources(Me.cmdObjectTransparency, "cmdObjectTransparency")
        Me.cmdObjectTransparency.FlatAppearance.BorderSize = 0
        Me.cmdObjectTransparency.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectTransparency.Name = "cmdObjectTransparency"
        Me.cmdObjectTransparency.UseVisualStyleBackColor = False
        '
        'cmdObjectHighlightSharpness
        '
        resources.ApplyResources(Me.cmdObjectHighlightSharpness, "cmdObjectHighlightSharpness")
        Me.cmdObjectHighlightSharpness.FlatAppearance.BorderSize = 0
        Me.cmdObjectHighlightSharpness.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectHighlightSharpness.Name = "cmdObjectHighlightSharpness"
        Me.cmdObjectHighlightSharpness.UseVisualStyleBackColor = False
        '
        'cmdObjectPositionZ
        '
        resources.ApplyResources(Me.cmdObjectPositionZ, "cmdObjectPositionZ")
        Me.cmdObjectPositionZ.FlatAppearance.BorderSize = 0
        Me.cmdObjectPositionZ.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectPositionZ.Name = "cmdObjectPositionZ"
        Me.cmdObjectPositionZ.UseVisualStyleBackColor = False
        '
        'cmdObjectPositionY
        '
        resources.ApplyResources(Me.cmdObjectPositionY, "cmdObjectPositionY")
        Me.cmdObjectPositionY.FlatAppearance.BorderSize = 0
        Me.cmdObjectPositionY.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectPositionY.Name = "cmdObjectPositionY"
        Me.cmdObjectPositionY.UseVisualStyleBackColor = False
        '
        'cmdObjectHighlightColor
        '
        resources.ApplyResources(Me.cmdObjectHighlightColor, "cmdObjectHighlightColor")
        Me.cmdObjectHighlightColor.FlatAppearance.BorderSize = 0
        Me.cmdObjectHighlightColor.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectHighlightColor.Name = "cmdObjectHighlightColor"
        Me.cmdObjectHighlightColor.UseVisualStyleBackColor = False
        '
        'cmdObjectColor
        '
        resources.ApplyResources(Me.cmdObjectColor, "cmdObjectColor")
        Me.cmdObjectColor.FlatAppearance.BorderSize = 0
        Me.cmdObjectColor.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectColor.Name = "cmdObjectColor"
        Me.cmdObjectColor.UseVisualStyleBackColor = False
        '
        'cmdObjectVelocityX
        '
        resources.ApplyResources(Me.cmdObjectVelocityX, "cmdObjectVelocityX")
        Me.cmdObjectVelocityX.FlatAppearance.BorderSize = 0
        Me.cmdObjectVelocityX.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectVelocityX.Name = "cmdObjectVelocityX"
        Me.cmdObjectVelocityX.UseVisualStyleBackColor = False
        '
        'cmdObjectPositionX
        '
        resources.ApplyResources(Me.cmdObjectPositionX, "cmdObjectPositionX")
        Me.cmdObjectPositionX.FlatAppearance.BorderSize = 0
        Me.cmdObjectPositionX.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectPositionX.Name = "cmdObjectPositionX"
        Me.cmdObjectPositionX.UseVisualStyleBackColor = False
        '
        'cmdObjectCharge
        '
        resources.ApplyResources(Me.cmdObjectCharge, "cmdObjectCharge")
        Me.cmdObjectCharge.FlatAppearance.BorderSize = 0
        Me.cmdObjectCharge.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectCharge.Name = "cmdObjectCharge"
        Me.cmdObjectCharge.UseVisualStyleBackColor = False
        '
        'cmdObjectMass
        '
        resources.ApplyResources(Me.cmdObjectMass, "cmdObjectMass")
        Me.cmdObjectMass.FlatAppearance.BorderSize = 0
        Me.cmdObjectMass.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectMass.Name = "cmdObjectMass"
        Me.cmdObjectMass.UseVisualStyleBackColor = False
        '
        'lblObjectHighlightColor
        '
        Me.lblObjectHighlightColor.AutoEllipsis = True
        Me.lblObjectHighlightColor.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectHighlightColor, "lblObjectHighlightColor")
        Me.lblObjectHighlightColor.Name = "lblObjectHighlightColor"
        Me.lblObjectHighlightColor.UseMnemonic = False
        '
        'lblObjectName
        '
        Me.lblObjectName.AutoEllipsis = True
        Me.lblObjectName.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectName, "lblObjectName")
        Me.lblObjectName.Name = "lblObjectName"
        Me.lblObjectName.UseMnemonic = False
        '
        'lblObjectTransparency
        '
        Me.lblObjectTransparency.AutoEllipsis = True
        Me.lblObjectTransparency.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectTransparency, "lblObjectTransparency")
        Me.lblObjectTransparency.Name = "lblObjectTransparency"
        Me.lblObjectTransparency.UseMnemonic = False
        '
        'txtObjectVelocityZ
        '
        Me.txtObjectVelocityZ.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtObjectVelocityZ, "txtObjectVelocityZ")
        Me.txtObjectVelocityZ.Name = "txtObjectVelocityZ"
        '
        'txtObjectName
        '
        Me.txtObjectName.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtObjectName, "txtObjectName")
        Me.txtObjectName.Name = "txtObjectName"
        '
        'txtObjectVelocityY
        '
        Me.txtObjectVelocityY.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtObjectVelocityY, "txtObjectVelocityY")
        Me.txtObjectVelocityY.Name = "txtObjectVelocityY"
        '
        'lblObjectMass
        '
        Me.lblObjectMass.AutoEllipsis = True
        Me.lblObjectMass.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectMass, "lblObjectMass")
        Me.lblObjectMass.Name = "lblObjectMass"
        Me.lblObjectMass.UseMnemonic = False
        '
        'lblObjectCharge
        '
        Me.lblObjectCharge.AutoEllipsis = True
        Me.lblObjectCharge.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectCharge, "lblObjectCharge")
        Me.lblObjectCharge.Name = "lblObjectCharge"
        Me.lblObjectCharge.UseMnemonic = False
        '
        'lblObjectColor
        '
        Me.lblObjectColor.AutoEllipsis = True
        Me.lblObjectColor.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectColor, "lblObjectColor")
        Me.lblObjectColor.Name = "lblObjectColor"
        Me.lblObjectColor.UseMnemonic = False
        '
        'lblObjectPosition
        '
        Me.lblObjectPosition.AutoEllipsis = True
        Me.lblObjectPosition.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectPosition, "lblObjectPosition")
        Me.lblObjectPosition.Name = "lblObjectPosition"
        Me.lblObjectPosition.UseMnemonic = False
        '
        'lblObjectVelocity
        '
        Me.lblObjectVelocity.AutoEllipsis = True
        Me.lblObjectVelocity.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectVelocity, "lblObjectVelocity")
        Me.lblObjectVelocity.Name = "lblObjectVelocity"
        Me.lblObjectVelocity.UseMnemonic = False
        '
        'lblObjectHighlightSharpness
        '
        Me.lblObjectHighlightSharpness.AutoEllipsis = True
        Me.lblObjectHighlightSharpness.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectHighlightSharpness, "lblObjectHighlightSharpness")
        Me.lblObjectHighlightSharpness.Name = "lblObjectHighlightSharpness"
        Me.lblObjectHighlightSharpness.UseMnemonic = False
        '
        'tbObjectTransparency
        '
        Me.tbObjectTransparency.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.tbObjectTransparency, "tbObjectTransparency")
        Me.tbObjectTransparency.LargeChange = 15
        Me.tbObjectTransparency.Maximum = 255
        Me.tbObjectTransparency.Name = "tbObjectTransparency"
        Me.tbObjectTransparency.SmallChange = 15
        Me.tbObjectTransparency.TickFrequency = 5
        Me.tbObjectTransparency.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbObjectTransparency.Value = 255
        '
        'txtObjectPositionZ
        '
        Me.txtObjectPositionZ.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtObjectPositionZ, "txtObjectPositionZ")
        Me.txtObjectPositionZ.Name = "txtObjectPositionZ"
        '
        'txtObjectPositionX
        '
        Me.txtObjectPositionX.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtObjectPositionX, "txtObjectPositionX")
        Me.txtObjectPositionX.Name = "txtObjectPositionX"
        '
        'txtObjectPositionY
        '
        Me.txtObjectPositionY.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtObjectPositionY, "txtObjectPositionY")
        Me.txtObjectPositionY.Name = "txtObjectPositionY"
        '
        'txtObjectVelocityX
        '
        Me.txtObjectVelocityX.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtObjectVelocityX, "txtObjectVelocityX")
        Me.txtObjectVelocityX.Name = "txtObjectVelocityX"
        '
        'txtObjectMass
        '
        Me.txtObjectMass.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtObjectMass, "txtObjectMass")
        Me.txtObjectMass.Name = "txtObjectMass"
        '
        'txtObjectCharge
        '
        Me.txtObjectCharge.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtObjectCharge, "txtObjectCharge")
        Me.txtObjectCharge.Name = "txtObjectCharge"
        '
        'txtObjectNumber
        '
        resources.ApplyResources(Me.txtObjectNumber, "txtObjectNumber")
        Me.txtObjectNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectNumber.Name = "txtObjectNumber"
        '
        'tbObjectReflectivity
        '
        resources.ApplyResources(Me.tbObjectReflectivity, "tbObjectReflectivity")
        Me.tbObjectReflectivity.LargeChange = 10
        Me.tbObjectReflectivity.Maximum = 100
        Me.tbObjectReflectivity.Name = "tbObjectReflectivity"
        Me.tbObjectReflectivity.TickFrequency = 5
        Me.tbObjectReflectivity.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbObjectHighlightSharpness
        '
        Me.tbObjectHighlightSharpness.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.tbObjectHighlightSharpness, "tbObjectHighlightSharpness")
        Me.tbObjectHighlightSharpness.LargeChange = 20
        Me.tbObjectHighlightSharpness.Maximum = 200
        Me.tbObjectHighlightSharpness.Name = "tbObjectHighlightSharpness"
        Me.tbObjectHighlightSharpness.SmallChange = 10
        Me.tbObjectHighlightSharpness.TickFrequency = 5
        Me.tbObjectHighlightSharpness.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbObjectHighlightSharpness.Value = 50
        '
        'txtObjectSizeX
        '
        resources.ApplyResources(Me.txtObjectSizeX, "txtObjectSizeX")
        Me.txtObjectSizeX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectSizeX.Name = "txtObjectSizeX"
        '
        'txtObjectSizeY
        '
        resources.ApplyResources(Me.txtObjectSizeY, "txtObjectSizeY")
        Me.txtObjectSizeY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectSizeY.Name = "txtObjectSizeY"
        '
        'txtObjectSizeZ
        '
        resources.ApplyResources(Me.txtObjectSizeZ, "txtObjectSizeZ")
        Me.txtObjectSizeZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectSizeZ.Name = "txtObjectSizeZ"
        '
        'lblObjectSize
        '
        Me.lblObjectSize.AutoEllipsis = True
        Me.lblObjectSize.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectSize, "lblObjectSize")
        Me.lblObjectSize.Name = "lblObjectSize"
        Me.lblObjectSize.UseMnemonic = False
        '
        'txtObjectNormalZ
        '
        resources.ApplyResources(Me.txtObjectNormalZ, "txtObjectNormalZ")
        Me.txtObjectNormalZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectNormalZ.Name = "txtObjectNormalZ"
        '
        'txtObjectNormalY
        '
        resources.ApplyResources(Me.txtObjectNormalY, "txtObjectNormalY")
        Me.txtObjectNormalY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectNormalY.Name = "txtObjectNormalY"
        '
        'txtObjectNormalX
        '
        resources.ApplyResources(Me.txtObjectNormalX, "txtObjectNormalX")
        Me.txtObjectNormalX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectNormalX.Name = "txtObjectNormalX"
        '
        'cmdObjectRadius
        '
        resources.ApplyResources(Me.cmdObjectRadius, "cmdObjectRadius")
        Me.cmdObjectRadius.FlatAppearance.BorderSize = 0
        Me.cmdObjectRadius.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectRadius.Name = "cmdObjectRadius"
        Me.cmdObjectRadius.UseVisualStyleBackColor = False
        '
        'lblObjectRadius
        '
        Me.lblObjectRadius.AutoEllipsis = True
        Me.lblObjectRadius.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectRadius, "lblObjectRadius")
        Me.lblObjectRadius.Name = "lblObjectRadius"
        Me.lblObjectRadius.UseMnemonic = False
        '
        'txtObjectRotationZ
        '
        resources.ApplyResources(Me.txtObjectRotationZ, "txtObjectRotationZ")
        Me.txtObjectRotationZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectRotationZ.Name = "txtObjectRotationZ"
        '
        'cmdObjectRotationZ
        '
        resources.ApplyResources(Me.cmdObjectRotationZ, "cmdObjectRotationZ")
        Me.cmdObjectRotationZ.FlatAppearance.BorderSize = 0
        Me.cmdObjectRotationZ.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectRotationZ.Name = "cmdObjectRotationZ"
        Me.cmdObjectRotationZ.UseVisualStyleBackColor = False
        '
        'txtObjectRotationY
        '
        resources.ApplyResources(Me.txtObjectRotationY, "txtObjectRotationY")
        Me.txtObjectRotationY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectRotationY.Name = "txtObjectRotationY"
        '
        'cmdObjectRotationY
        '
        resources.ApplyResources(Me.cmdObjectRotationY, "cmdObjectRotationY")
        Me.cmdObjectRotationY.FlatAppearance.BorderSize = 0
        Me.cmdObjectRotationY.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectRotationY.Name = "cmdObjectRotationY"
        Me.cmdObjectRotationY.UseVisualStyleBackColor = False
        '
        'txtObjectRotationX
        '
        resources.ApplyResources(Me.txtObjectRotationX, "txtObjectRotationX")
        Me.txtObjectRotationX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtObjectRotationX.Name = "txtObjectRotationX"
        '
        'cmdObjectRotationX
        '
        resources.ApplyResources(Me.cmdObjectRotationX, "cmdObjectRotationX")
        Me.cmdObjectRotationX.FlatAppearance.BorderSize = 0
        Me.cmdObjectRotationX.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectRotationX.Name = "cmdObjectRotationX"
        Me.cmdObjectRotationX.UseVisualStyleBackColor = False
        '
        'lblObjectRotation
        '
        Me.lblObjectRotation.AutoEllipsis = True
        Me.lblObjectRotation.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectRotation, "lblObjectRotation")
        Me.lblObjectRotation.Name = "lblObjectRotation"
        Me.lblObjectRotation.UseMnemonic = False
        '
        'lblObjectNormal
        '
        Me.lblObjectNormal.AutoEllipsis = True
        Me.lblObjectNormal.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblObjectNormal, "lblObjectNormal")
        Me.lblObjectNormal.Name = "lblObjectNormal"
        Me.lblObjectNormal.UseMnemonic = False
        '
        'cmdObjectSizeX
        '
        resources.ApplyResources(Me.cmdObjectSizeX, "cmdObjectSizeX")
        Me.cmdObjectSizeX.FlatAppearance.BorderSize = 0
        Me.cmdObjectSizeX.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectSizeX.Name = "cmdObjectSizeX"
        Me.cmdObjectSizeX.UseVisualStyleBackColor = False
        '
        'cmdObjectSizeY
        '
        resources.ApplyResources(Me.cmdObjectSizeY, "cmdObjectSizeY")
        Me.cmdObjectSizeY.FlatAppearance.BorderSize = 0
        Me.cmdObjectSizeY.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectSizeY.Name = "cmdObjectSizeY"
        Me.cmdObjectSizeY.UseVisualStyleBackColor = False
        '
        'cmdObjectSizeZ
        '
        resources.ApplyResources(Me.cmdObjectSizeZ, "cmdObjectSizeZ")
        Me.cmdObjectSizeZ.FlatAppearance.BorderSize = 0
        Me.cmdObjectSizeZ.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectSizeZ.Name = "cmdObjectSizeZ"
        Me.cmdObjectSizeZ.UseVisualStyleBackColor = False
        '
        'txtObjectRadius
        '
        Me.txtObjectRadius.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtObjectRadius, "txtObjectRadius")
        Me.txtObjectRadius.Name = "txtObjectRadius"
        '
        'cmdObjectNormalX
        '
        resources.ApplyResources(Me.cmdObjectNormalX, "cmdObjectNormalX")
        Me.cmdObjectNormalX.FlatAppearance.BorderSize = 0
        Me.cmdObjectNormalX.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectNormalX.Name = "cmdObjectNormalX"
        Me.cmdObjectNormalX.UseVisualStyleBackColor = False
        '
        'cmdObjectNormalY
        '
        resources.ApplyResources(Me.cmdObjectNormalY, "cmdObjectNormalY")
        Me.cmdObjectNormalY.FlatAppearance.BorderSize = 0
        Me.cmdObjectNormalY.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectNormalY.Name = "cmdObjectNormalY"
        Me.cmdObjectNormalY.UseVisualStyleBackColor = False
        '
        'cmdObjectNormalZ
        '
        resources.ApplyResources(Me.cmdObjectNormalZ, "cmdObjectNormalZ")
        Me.cmdObjectNormalZ.FlatAppearance.BorderSize = 0
        Me.cmdObjectNormalZ.ForeColor = System.Drawing.Color.Black
        Me.cmdObjectNormalZ.Name = "cmdObjectNormalZ"
        Me.cmdObjectNormalZ.UseVisualStyleBackColor = False
        '
        'cmdGroupAdd
        '
        Me.cmdGroupAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.cmdGroupAdd, "cmdGroupAdd")
        Me.cmdGroupAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGroupAdd.Name = "cmdGroupAdd"
        Me.cmdGroupAdd.UseVisualStyleBackColor = True
        '
        'cmdGroupRemove
        '
        resources.ApplyResources(Me.cmdGroupRemove, "cmdGroupRemove")
        Me.cmdGroupRemove.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdGroupRemove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGroupRemove.Name = "cmdGroupRemove"
        Me.cmdGroupRemove.UseVisualStyleBackColor = True
        '
        'cmdGroupReplace
        '
        resources.ApplyResources(Me.cmdGroupReplace, "cmdGroupReplace")
        Me.cmdGroupReplace.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdGroupReplace.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGroupReplace.Name = "cmdGroupReplace"
        Me.cmdGroupReplace.UseVisualStyleBackColor = True
        '
        'TabLights
        '
        Me.TabLights.BackColor = System.Drawing.SystemColors.Control
        Me.TabLights.Controls.Add(Me.gbLights)
        Me.TabLights.Controls.Add(Me.cmdLightAdd)
        Me.TabLights.Controls.Add(Me.cmdLightRemove)
        Me.TabLights.Controls.Add(Me.cmdLightReplace)
        resources.ApplyResources(Me.TabLights, "TabLights")
        Me.TabLights.Name = "TabLights"
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
        resources.ApplyResources(Me.gbLights, "gbLights")
        Me.gbLights.Name = "gbLights"
        Me.gbLights.TabStop = False
        '
        'plLightColor
        '
        Me.plLightColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plLightColor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.plLightColor, "plLightColor")
        Me.plLightColor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.plLightColor.Name = "plLightColor"
        Me.plLightColor.UseVisualStyleBackColor = False
        '
        'txtLightAttenuationC
        '
        Me.txtLightAttenuationC.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightAttenuationC, "txtLightAttenuationC")
        Me.txtLightAttenuationC.Name = "txtLightAttenuationC"
        '
        'txtLightAttenuationB
        '
        Me.txtLightAttenuationB.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightAttenuationB, "txtLightAttenuationB")
        Me.txtLightAttenuationB.Name = "txtLightAttenuationB"
        '
        'txtLightAttenuationA
        '
        Me.txtLightAttenuationA.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightAttenuationA, "txtLightAttenuationA")
        Me.txtLightAttenuationA.Name = "txtLightAttenuationA"
        '
        'lblLightAttenuation
        '
        Me.lblLightAttenuation.AutoEllipsis = True
        Me.lblLightAttenuation.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblLightAttenuation, "lblLightAttenuation")
        Me.lblLightAttenuation.Name = "lblLightAttenuation"
        Me.lblLightAttenuation.UseMnemonic = False
        '
        'txtLightAngleOuter
        '
        Me.txtLightAngleOuter.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightAngleOuter, "txtLightAngleOuter")
        Me.txtLightAngleOuter.Name = "txtLightAngleOuter"
        '
        'lblLightRange
        '
        Me.lblLightRange.AutoEllipsis = True
        Me.lblLightRange.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblLightRange, "lblLightRange")
        Me.lblLightRange.Name = "lblLightRange"
        Me.lblLightRange.UseMnemonic = False
        '
        'txtLightRange
        '
        Me.txtLightRange.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightRange, "txtLightRange")
        Me.txtLightRange.Name = "txtLightRange"
        '
        'lblLightFalloff
        '
        Me.lblLightFalloff.AutoEllipsis = True
        Me.lblLightFalloff.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblLightFalloff, "lblLightFalloff")
        Me.lblLightFalloff.Name = "lblLightFalloff"
        Me.lblLightFalloff.UseMnemonic = False
        '
        'txtLightFalloff
        '
        Me.txtLightFalloff.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightFalloff, "txtLightFalloff")
        Me.txtLightFalloff.Name = "txtLightFalloff"
        '
        'lblLightAngle
        '
        Me.lblLightAngle.AutoEllipsis = True
        Me.lblLightAngle.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblLightAngle, "lblLightAngle")
        Me.lblLightAngle.Name = "lblLightAngle"
        Me.lblLightAngle.UseMnemonic = False
        '
        'txtLightAngleInner
        '
        Me.txtLightAngleInner.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightAngleInner, "txtLightAngleInner")
        Me.txtLightAngleInner.Name = "txtLightAngleInner"
        '
        'tbLightAmbient
        '
        resources.ApplyResources(Me.tbLightAmbient, "tbLightAmbient")
        Me.tbLightAmbient.LargeChange = 15
        Me.tbLightAmbient.Maximum = 100
        Me.tbLightAmbient.Name = "tbLightAmbient"
        Me.tbLightAmbient.SmallChange = 15
        Me.tbLightAmbient.TickFrequency = 5
        Me.tbLightAmbient.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbLightAmbient.Value = 10
        '
        'lblLightAmbient
        '
        Me.lblLightAmbient.AutoEllipsis = True
        Me.lblLightAmbient.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblLightAmbient, "lblLightAmbient")
        Me.lblLightAmbient.Name = "lblLightAmbient"
        Me.lblLightAmbient.UseMnemonic = False
        '
        'lblLightHighlight
        '
        Me.lblLightHighlight.AutoEllipsis = True
        Me.lblLightHighlight.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblLightHighlight, "lblLightHighlight")
        Me.lblLightHighlight.Name = "lblLightHighlight"
        Me.lblLightHighlight.UseMnemonic = False
        '
        'lblLightType
        '
        Me.lblLightType.AutoEllipsis = True
        Me.lblLightType.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblLightType, "lblLightType")
        Me.lblLightType.Name = "lblLightType"
        Me.lblLightType.UseMnemonic = False
        '
        'txtLightPositionZ
        '
        Me.txtLightPositionZ.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightPositionZ, "txtLightPositionZ")
        Me.txtLightPositionZ.Name = "txtLightPositionZ"
        '
        'txtLightPositionY
        '
        Me.txtLightPositionY.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightPositionY, "txtLightPositionY")
        Me.txtLightPositionY.Name = "txtLightPositionY"
        '
        'txtLightPositionX
        '
        Me.txtLightPositionX.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightPositionX, "txtLightPositionX")
        Me.txtLightPositionX.Name = "txtLightPositionX"
        '
        'lblLightPosition
        '
        Me.lblLightPosition.AutoEllipsis = True
        Me.lblLightPosition.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblLightPosition, "lblLightPosition")
        Me.lblLightPosition.Name = "lblLightPosition"
        Me.lblLightPosition.UseMnemonic = False
        '
        'chLightsEnable
        '
        Me.chLightsEnable.AutoEllipsis = True
        resources.ApplyResources(Me.chLightsEnable, "chLightsEnable")
        Me.chLightsEnable.Checked = True
        Me.chLightsEnable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chLightsEnable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chLightsEnable.Name = "chLightsEnable"
        Me.chLightsEnable.UseMnemonic = False
        Me.chLightsEnable.UseVisualStyleBackColor = True
        '
        'listLights
        '
        resources.ApplyResources(Me.listLights, "listLights")
        Me.listLights.ForeColor = System.Drawing.SystemColors.ControlText
        Me.listLights.Name = "listLights"
        '
        'txtLightName
        '
        Me.txtLightName.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightName, "txtLightName")
        Me.txtLightName.Name = "txtLightName"
        '
        'lblLightName
        '
        Me.lblLightName.AutoEllipsis = True
        Me.lblLightName.BackColor = System.Drawing.Color.Transparent
        Me.lblLightName.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblLightName, "lblLightName")
        Me.lblLightName.Name = "lblLightName"
        Me.lblLightName.UseMnemonic = False
        '
        'txtLightDirectionZ
        '
        Me.txtLightDirectionZ.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightDirectionZ, "txtLightDirectionZ")
        Me.txtLightDirectionZ.Name = "txtLightDirectionZ"
        '
        'lblLightDirection
        '
        Me.lblLightDirection.AutoEllipsis = True
        Me.lblLightDirection.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblLightDirection, "lblLightDirection")
        Me.lblLightDirection.Name = "lblLightDirection"
        Me.lblLightDirection.UseMnemonic = False
        '
        'txtLightDirectionY
        '
        Me.txtLightDirectionY.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightDirectionY, "txtLightDirectionY")
        Me.txtLightDirectionY.Name = "txtLightDirectionY"
        '
        'txtLightDirectionX
        '
        Me.txtLightDirectionX.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLightDirectionX, "txtLightDirectionX")
        Me.txtLightDirectionX.Name = "txtLightDirectionX"
        '
        'lblLightColor
        '
        Me.lblLightColor.AutoEllipsis = True
        Me.lblLightColor.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblLightColor, "lblLightColor")
        Me.lblLightColor.Name = "lblLightColor"
        Me.lblLightColor.UseMnemonic = False
        '
        'tbLightHighlight
        '
        resources.ApplyResources(Me.tbLightHighlight, "tbLightHighlight")
        Me.tbLightHighlight.LargeChange = 15
        Me.tbLightHighlight.Maximum = 255
        Me.tbLightHighlight.Name = "tbLightHighlight"
        Me.tbLightHighlight.SmallChange = 5
        Me.tbLightHighlight.TickFrequency = 5
        Me.tbLightHighlight.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbLightHighlight.Value = 50
        '
        'cbLightType
        '
        Me.cbLightType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLightType.FormattingEnabled = True
        Me.cbLightType.Items.AddRange(New Object() {resources.GetString("cbLightType.Items"), resources.GetString("cbLightType.Items1"), resources.GetString("cbLightType.Items2")})
        resources.ApplyResources(Me.cbLightType, "cbLightType")
        Me.cbLightType.Name = "cbLightType"
        '
        'cmdLightAdd
        '
        Me.cmdLightAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cmdLightAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.cmdLightAdd, "cmdLightAdd")
        Me.cmdLightAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLightAdd.Name = "cmdLightAdd"
        Me.cmdLightAdd.UseVisualStyleBackColor = False
        '
        'cmdLightRemove
        '
        Me.cmdLightRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        resources.ApplyResources(Me.cmdLightRemove, "cmdLightRemove")
        Me.cmdLightRemove.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdLightRemove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLightRemove.Name = "cmdLightRemove"
        Me.cmdLightRemove.UseVisualStyleBackColor = False
        '
        'cmdLightReplace
        '
        Me.cmdLightReplace.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        resources.ApplyResources(Me.cmdLightReplace, "cmdLightReplace")
        Me.cmdLightReplace.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdLightReplace.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLightReplace.Name = "cmdLightReplace"
        Me.cmdLightReplace.UseVisualStyleBackColor = False
        '
        'TabDisplay
        '
        Me.TabDisplay.BackColor = System.Drawing.SystemColors.Control
        Me.TabDisplay.Controls.Add(Me.GroupBox1)
        Me.TabDisplay.Controls.Add(Me.Rendering)
        Me.TabDisplay.Controls.Add(Me.CmdSaveOut)
        resources.ApplyResources(Me.TabDisplay, "TabDisplay")
        Me.TabDisplay.Name = "TabDisplay"
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
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Label47
        '
        Me.Label47.AutoEllipsis = True
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label47, "Label47")
        Me.Label47.Name = "Label47"
        Me.Label47.UseMnemonic = False
        '
        'chCamera
        '
        Me.chCamera.AutoEllipsis = True
        resources.ApplyResources(Me.chCamera, "chCamera")
        Me.chCamera.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chCamera.Name = "chCamera"
        Me.chCamera.UseMnemonic = False
        Me.chCamera.UseVisualStyleBackColor = True
        '
        'txtCPosZ
        '
        resources.ApplyResources(Me.txtCPosZ, "txtCPosZ")
        Me.txtCPosZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCPosZ.Name = "txtCPosZ"
        '
        'Label11
        '
        Me.Label11.AutoEllipsis = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        Me.Label11.UseMnemonic = False
        '
        'Label16
        '
        Me.Label16.AutoEllipsis = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        Me.Label16.UseMnemonic = False
        '
        'txtCOrientZ
        '
        resources.ApplyResources(Me.txtCOrientZ, "txtCOrientZ")
        Me.txtCOrientZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCOrientZ.Name = "txtCOrientZ"
        '
        'txtCTargetY
        '
        resources.ApplyResources(Me.txtCTargetY, "txtCTargetY")
        Me.txtCTargetY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCTargetY.Name = "txtCTargetY"
        '
        'txtCPosX
        '
        resources.ApplyResources(Me.txtCPosX, "txtCPosX")
        Me.txtCPosX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCPosX.Name = "txtCPosX"
        '
        'txtCTargetZ
        '
        resources.ApplyResources(Me.txtCTargetZ, "txtCTargetZ")
        Me.txtCTargetZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCTargetZ.Name = "txtCTargetZ"
        '
        'Label17
        '
        Me.Label17.AutoEllipsis = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        Me.Label17.UseMnemonic = False
        '
        'txtCTargetX
        '
        resources.ApplyResources(Me.txtCTargetX, "txtCTargetX")
        Me.txtCTargetX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCTargetX.Name = "txtCTargetX"
        '
        'txtCPosY
        '
        resources.ApplyResources(Me.txtCPosY, "txtCPosY")
        Me.txtCPosY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCPosY.Name = "txtCPosY"
        '
        'txtCOrientX
        '
        resources.ApplyResources(Me.txtCOrientX, "txtCOrientX")
        Me.txtCOrientX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCOrientX.Name = "txtCOrientX"
        '
        'txtCOrientY
        '
        resources.ApplyResources(Me.txtCOrientY, "txtCOrientY")
        Me.txtCOrientY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCOrientY.Name = "txtCOrientY"
        '
        'tbCameraSpeed
        '
        Me.tbCameraSpeed.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.tbCameraSpeed, "tbCameraSpeed")
        Me.tbCameraSpeed.LargeChange = 10
        Me.tbCameraSpeed.Maximum = 40
        Me.tbCameraSpeed.Minimum = 10
        Me.tbCameraSpeed.Name = "tbCameraSpeed"
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
        resources.ApplyResources(Me.Rendering, "Rendering")
        Me.Rendering.Name = "Rendering"
        Me.Rendering.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoEllipsis = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        Me.Label3.UseMnemonic = False
        '
        'txtRenderThreads
        '
        resources.ApplyResources(Me.txtRenderThreads, "txtRenderThreads")
        Me.txtRenderThreads.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtRenderThreads.Name = "txtRenderThreads"
        '
        'Label46
        '
        Me.Label46.AutoEllipsis = True
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label46, "Label46")
        Me.Label46.Name = "Label46"
        Me.Label46.UseMnemonic = False
        '
        'txtVFoV
        '
        Me.txtVFoV.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtVFoV, "txtVFoV")
        Me.txtVFoV.Name = "txtVFoV"
        '
        'Label45
        '
        Me.Label45.AutoEllipsis = True
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label45, "Label45")
        Me.Label45.Name = "Label45"
        Me.Label45.UseMnemonic = False
        '
        'cbRender
        '
        Me.cbRender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRender.FormattingEnabled = True
        Me.cbRender.Items.AddRange(New Object() {resources.GetString("cbRender.Items"), resources.GetString("cbRender.Items1"), resources.GetString("cbRender.Items2")})
        resources.ApplyResources(Me.cbRender, "cbRender")
        Me.cbRender.Name = "cbRender"
        '
        'Label44
        '
        Me.Label44.AutoEllipsis = True
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label44, "Label44")
        Me.Label44.Name = "Label44"
        Me.Label44.UseMnemonic = False
        '
        'txtMaxFPS
        '
        Me.txtMaxFPS.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtMaxFPS, "txtMaxFPS")
        Me.txtMaxFPS.Name = "txtMaxFPS"
        '
        'chVSync
        '
        Me.chVSync.AutoEllipsis = True
        resources.ApplyResources(Me.chVSync, "chVSync")
        Me.chVSync.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chVSync.Name = "chVSync"
        Me.chVSync.UseMnemonic = False
        Me.chVSync.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.AutoEllipsis = True
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label43, "Label43")
        Me.Label43.Name = "Label43"
        Me.Label43.UseMnemonic = False
        '
        'cbShading
        '
        Me.cbShading.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbShading.FormattingEnabled = True
        Me.cbShading.Items.AddRange(New Object() {resources.GetString("cbShading.Items"), resources.GetString("cbShading.Items1")})
        resources.ApplyResources(Me.cbShading, "cbShading")
        Me.cbShading.Name = "cbShading"
        '
        'tbPolys
        '
        Me.tbPolys.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.tbPolys, "tbPolys")
        Me.tbPolys.LargeChange = 10
        Me.tbPolys.Maximum = 100
        Me.tbPolys.Minimum = 2
        Me.tbPolys.Name = "tbPolys"
        Me.tbPolys.TickFrequency = 5
        Me.tbPolys.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPolys.Value = 40
        '
        'Label30
        '
        Me.Label30.AutoEllipsis = True
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label30, "Label30")
        Me.Label30.Name = "Label30"
        Me.Label30.UseMnemonic = False
        '
        'txtWindowX
        '
        Me.txtWindowX.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtWindowX, "txtWindowX")
        Me.txtWindowX.Name = "txtWindowX"
        '
        'Label12
        '
        Me.Label12.AutoEllipsis = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        Me.Label12.UseMnemonic = False
        '
        'Label18
        '
        Me.Label18.AutoEllipsis = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.Name = "Label18"
        Me.Label18.UseMnemonic = False
        '
        'Label13
        '
        Me.Label13.AutoEllipsis = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        Me.Label13.UseMnemonic = False
        '
        'txtHFoV
        '
        Me.txtHFoV.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtHFoV, "txtHFoV")
        Me.txtHFoV.Name = "txtHFoV"
        '
        'chTrace
        '
        Me.chTrace.AutoEllipsis = True
        resources.ApplyResources(Me.chTrace, "chTrace")
        Me.chTrace.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chTrace.Name = "chTrace"
        Me.chTrace.UseMnemonic = False
        Me.chTrace.UseVisualStyleBackColor = True
        '
        'txtWindowY
        '
        Me.txtWindowY.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtWindowY, "txtWindowY")
        Me.txtWindowY.Name = "txtWindowY"
        '
        'plRenderBackColor
        '
        Me.plRenderBackColor.BackColor = System.Drawing.Color.Black
        Me.plRenderBackColor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.plRenderBackColor, "plRenderBackColor")
        Me.plRenderBackColor.ForeColor = System.Drawing.Color.Black
        Me.plRenderBackColor.Name = "plRenderBackColor"
        Me.plRenderBackColor.UseVisualStyleBackColor = False
        '
        'CmdSaveOut
        '
        resources.ApplyResources(Me.CmdSaveOut, "CmdSaveOut")
        Me.CmdSaveOut.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.CmdSaveOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdSaveOut.Name = "CmdSaveOut"
        Me.CmdSaveOut.UseVisualStyleBackColor = True
        '
        'TabForces
        '
        Me.TabForces.BackColor = System.Drawing.SystemColors.Control
        Me.TabForces.Controls.Add(Me.GroupBox5)
        Me.TabForces.Controls.Add(Me.GroupBox4)
        resources.ApplyResources(Me.TabForces, "TabForces")
        Me.TabForces.Name = "TabForces"
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
        resources.ApplyResources(Me.GroupBox5, "GroupBox5")
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.TabStop = False
        '
        'txtPermittivity
        '
        resources.ApplyResources(Me.txtPermittivity, "txtPermittivity")
        Me.txtPermittivity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPermittivity.Name = "txtPermittivity"
        '
        'Label48
        '
        Me.Label48.AutoEllipsis = True
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label48, "Label48")
        Me.Label48.Name = "Label48"
        Me.Label48.UseMnemonic = False
        '
        'txtFluidViscosity
        '
        resources.ApplyResources(Me.txtFluidViscosity, "txtFluidViscosity")
        Me.txtFluidViscosity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFluidViscosity.Name = "txtFluidViscosity"
        '
        'Label29
        '
        Me.Label29.AutoEllipsis = True
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label29, "Label29")
        Me.Label29.Name = "Label29"
        Me.Label29.UseMnemonic = False
        '
        'txtDragCoeff
        '
        resources.ApplyResources(Me.txtDragCoeff, "txtDragCoeff")
        Me.txtDragCoeff.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDragCoeff.Name = "txtDragCoeff"
        '
        'chForces
        '
        Me.chForces.AutoEllipsis = True
        resources.ApplyResources(Me.chForces, "chForces")
        Me.chForces.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chForces.Name = "chForces"
        Me.chForces.UseMnemonic = False
        Me.chForces.UseVisualStyleBackColor = True
        '
        'txtFluidDensity
        '
        resources.ApplyResources(Me.txtFluidDensity, "txtFluidDensity")
        Me.txtFluidDensity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFluidDensity.Name = "txtFluidDensity"
        '
        'chElectrostatic
        '
        Me.chElectrostatic.AutoEllipsis = True
        resources.ApplyResources(Me.chElectrostatic, "chElectrostatic")
        Me.chElectrostatic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chElectrostatic.Name = "chElectrostatic"
        Me.chElectrostatic.UseMnemonic = False
        Me.chElectrostatic.UseVisualStyleBackColor = True
        '
        'txtFieldZ
        '
        resources.ApplyResources(Me.txtFieldZ, "txtFieldZ")
        Me.txtFieldZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFieldZ.Name = "txtFieldZ"
        '
        'chGravity
        '
        Me.chGravity.AutoEllipsis = True
        resources.ApplyResources(Me.chGravity, "chGravity")
        Me.chGravity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chGravity.Name = "chGravity"
        Me.chGravity.UseMnemonic = False
        Me.chGravity.UseVisualStyleBackColor = True
        '
        'txtFieldY
        '
        resources.ApplyResources(Me.txtFieldY, "txtFieldY")
        Me.txtFieldY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFieldY.Name = "txtFieldY"
        '
        'chField
        '
        Me.chField.AutoEllipsis = True
        resources.ApplyResources(Me.chField, "chField")
        Me.chField.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chField.Name = "chField"
        Me.chField.UseMnemonic = False
        Me.chField.UseVisualStyleBackColor = True
        '
        'txtFieldX
        '
        resources.ApplyResources(Me.txtFieldX, "txtFieldX")
        Me.txtFieldX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFieldX.Name = "txtFieldX"
        '
        'Label22
        '
        Me.Label22.AutoEllipsis = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.Name = "Label22"
        Me.Label22.UseMnemonic = False
        '
        'chDrag
        '
        Me.chDrag.AutoEllipsis = True
        resources.ApplyResources(Me.chDrag, "chDrag")
        Me.chDrag.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chDrag.Name = "chDrag"
        Me.chDrag.UseMnemonic = False
        Me.chDrag.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoEllipsis = True
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label28, "Label28")
        Me.Label28.Name = "Label28"
        Me.Label28.UseMnemonic = False
        '
        'Label26
        '
        Me.Label26.AutoEllipsis = True
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.Name = "Label26"
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
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        '
        'chInterpolate
        '
        resources.ApplyResources(Me.chInterpolate, "chInterpolate")
        Me.chInterpolate.Name = "chInterpolate"
        Me.chInterpolate.UseVisualStyleBackColor = True
        '
        'chCollision
        '
        Me.chCollision.AutoEllipsis = True
        resources.ApplyResources(Me.chCollision, "chCollision")
        Me.chCollision.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chCollision.Name = "chCollision"
        Me.chCollision.UseMnemonic = False
        Me.chCollision.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoEllipsis = True
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.Name = "Label20"
        Me.Label20.UseMnemonic = False
        '
        'txtCoR
        '
        resources.ApplyResources(Me.txtCoR, "txtCoR")
        Me.txtCoR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCoR.Name = "txtCoR"
        '
        'chbreakable
        '
        Me.chbreakable.AutoEllipsis = True
        resources.ApplyResources(Me.chbreakable, "chbreakable")
        Me.chbreakable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chbreakable.Name = "chbreakable"
        Me.chbreakable.UseMnemonic = False
        Me.chbreakable.UseVisualStyleBackColor = True
        '
        'lblResulting
        '
        Me.lblResulting.AutoEllipsis = True
        Me.lblResulting.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.lblResulting, "lblResulting")
        Me.lblResulting.Name = "lblResulting"
        Me.lblResulting.UseMnemonic = False
        '
        'Label25
        '
        Me.Label25.AutoEllipsis = True
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.Name = "Label25"
        Me.Label25.UseMnemonic = False
        '
        'txtAddMax
        '
        resources.ApplyResources(Me.txtAddMax, "txtAddMax")
        Me.txtAddMax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAddMax.Name = "txtAddMax"
        '
        'txtBreakMin
        '
        resources.ApplyResources(Me.txtBreakMin, "txtBreakMin")
        Me.txtBreakMin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBreakMin.Name = "txtBreakMin"
        '
        'txtAddAvg
        '
        resources.ApplyResources(Me.txtAddAvg, "txtAddAvg")
        Me.txtAddAvg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAddAvg.Name = "txtAddAvg"
        '
        'txtBreakAvg
        '
        resources.ApplyResources(Me.txtBreakAvg, "txtBreakAvg")
        Me.txtBreakAvg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBreakAvg.Name = "txtBreakAvg"
        '
        'txtAddMin
        '
        resources.ApplyResources(Me.txtAddMin, "txtAddMin")
        Me.txtAddMin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAddMin.Name = "txtAddMin"
        '
        'txtBreakMax
        '
        resources.ApplyResources(Me.txtBreakMax, "txtBreakMax")
        Me.txtBreakMax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBreakMax.Name = "txtBreakMax"
        '
        'TabSimulation
        '
        Me.TabSimulation.BackColor = System.Drawing.SystemColors.Control
        Me.TabSimulation.Controls.Add(Me.cmdLoad)
        Me.TabSimulation.Controls.Add(Me.cmdSave)
        Me.TabSimulation.Controls.Add(Me.GroupBox3)
        resources.ApplyResources(Me.TabSimulation, "TabSimulation")
        Me.TabSimulation.Name = "TabSimulation"
        Me.TabSimulation.UseVisualStyleBackColor = True
        '
        'cmdLoad
        '
        Me.cmdLoad.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.cmdLoad, "cmdLoad")
        Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.cmdSave, "cmdSave")
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Name = "cmdSave"
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
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoEllipsis = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.Label1.UseMnemonic = False
        '
        'Label4
        '
        Me.Label4.AutoEllipsis = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        Me.Label4.UseMnemonic = False
        '
        'Label2
        '
        Me.Label2.AutoEllipsis = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        Me.Label2.UseMnemonic = False
        '
        'txtLimitCalc
        '
        Me.txtLimitCalc.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLimitCalc, "txtLimitCalc")
        Me.txtLimitCalc.Name = "txtLimitCalc"
        '
        'txtScale
        '
        Me.txtScale.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtScale, "txtScale")
        Me.txtScale.Name = "txtScale"
        '
        'txtTimeStep
        '
        Me.txtTimeStep.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtTimeStep, "txtTimeStep")
        Me.txtTimeStep.Name = "txtTimeStep"
        '
        'cbIntegration
        '
        Me.cbIntegration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cbIntegration, "cbIntegration")
        Me.cbIntegration.FormattingEnabled = True
        Me.cbIntegration.Items.AddRange(New Object() {resources.GetString("cbIntegration.Items"), resources.GetString("cbIntegration.Items1"), resources.GetString("cbIntegration.Items2"), resources.GetString("cbIntegration.Items3")})
        Me.cbIntegration.Name = "cbIntegration"
        AddHandler Me.cbIntegration.SelectedIndexChanged, AddressOf Me.cbIntegration_SelectedIndexChanged_1
        '
        'Label24
        '
        Me.Label24.AutoEllipsis = True
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.Name = "Label24"
        Me.Label24.UseMnemonic = False
        '
        'Label14
        '
        Me.Label14.AutoEllipsis = True
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        Me.Label14.UseMnemonic = False
        '
        'txtLimitObjects
        '
        Me.txtLimitObjects.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.txtLimitObjects, "txtLimitObjects")
        Me.txtLimitObjects.Name = "txtLimitObjects"
        '
        'Tabs
        '
        resources.ApplyResources(Me.Tabs, "Tabs")
        Me.Tabs.Controls.Add(Me.TabSimulation)
        Me.Tabs.Controls.Add(Me.TabForces)
        Me.Tabs.Controls.Add(Me.TabDisplay)
        Me.Tabs.Controls.Add(Me.TabLights)
        Me.Tabs.Controls.Add(Me.TabGroups)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        '
        'ControlPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.Tabs)
        Me.Controls.Add(Me.Stats)
        Me.Controls.Add(Me.cmdStart)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ControlPanel"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
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
