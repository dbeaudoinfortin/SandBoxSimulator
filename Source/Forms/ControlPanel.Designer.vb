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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlPanel))
        cmdStart = New System.Windows.Forms.Button()
        ColorDialog = New System.Windows.Forms.ColorDialog()
        Stats = New System.Windows.Forms.StatusStrip()
        lblStat = New System.Windows.Forms.ToolStripStatusLabel()
        SaveDialog = New System.Windows.Forms.SaveFileDialog()
        OpenDialog = New System.Windows.Forms.OpenFileDialog()
        StatusUpdate = New System.Windows.Forms.Timer(components)
        TabGroups = New System.Windows.Forms.TabPage()
        TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel()
        cmdGroupReplace = New System.Windows.Forms.Button()
        cmdGroupRemove = New System.Windows.Forms.Button()
        gbObjects = New System.Windows.Forms.GroupBox()
        listGroups = New System.Windows.Forms.ListBox()
        Panel2 = New System.Windows.Forms.Panel()
        tblOrientation = New System.Windows.Forms.TableLayoutPanel()
        txtObjectNormalX = New System.Windows.Forms.TextBox()
        txtObjectNormalY = New System.Windows.Forms.TextBox()
        txtObjectNormalZ = New System.Windows.Forms.TextBox()
        cmdObjectNormalX = New System.Windows.Forms.Button()
        cmdObjectNormalZ = New System.Windows.Forms.Button()
        cmdObjectNormalY = New System.Windows.Forms.Button()
        tblVelocity = New System.Windows.Forms.TableLayoutPanel()
        txtObjectVelocityX = New System.Windows.Forms.TextBox()
        txtObjectVelocityY = New System.Windows.Forms.TextBox()
        txtObjectVelocityZ = New System.Windows.Forms.TextBox()
        cmdObjectVelocityZ = New System.Windows.Forms.Button()
        cmdObjectVelocityY = New System.Windows.Forms.Button()
        cmdObjectVelocityX = New System.Windows.Forms.Button()
        tblPosition = New System.Windows.Forms.TableLayoutPanel()
        txtObjectPositionX = New System.Windows.Forms.TextBox()
        txtObjectPositionY = New System.Windows.Forms.TextBox()
        txtObjectPositionZ = New System.Windows.Forms.TextBox()
        cmdObjectPositionZ = New System.Windows.Forms.Button()
        cmdObjectPositionY = New System.Windows.Forms.Button()
        cmdObjectPositionX = New System.Windows.Forms.Button()
        TableLayoutPanel15 = New System.Windows.Forms.TableLayoutPanel()
        txtObjectRotationX = New System.Windows.Forms.TextBox()
        txtObjectRotationY = New System.Windows.Forms.TextBox()
        txtObjectRotationZ = New System.Windows.Forms.TextBox()
        cmdObjectRotationY = New System.Windows.Forms.Button()
        cmdObjectRotationZ = New System.Windows.Forms.Button()
        cmdObjectRotationX = New System.Windows.Forms.Button()
        txtObjectRefractiveIndex = New System.Windows.Forms.TextBox()
        tbObjectTransparency = New System.Windows.Forms.TrackBar()
        tbObjectReflectivity = New System.Windows.Forms.TrackBar()
        tblSize = New System.Windows.Forms.TableLayoutPanel()
        txtObjectSizeX = New System.Windows.Forms.TextBox()
        txtObjectSizeY = New System.Windows.Forms.TextBox()
        txtObjectSizeZ = New System.Windows.Forms.TextBox()
        cmdObjectSizeZ = New System.Windows.Forms.Button()
        cmdObjectSizeX = New System.Windows.Forms.Button()
        cmdObjectSizeY = New System.Windows.Forms.Button()
        plObjectHighlightColor = New System.Windows.Forms.Button()
        plObjectColor = New System.Windows.Forms.Button()
        cmdObjectRefractiveIndex = New System.Windows.Forms.Button()
        txtObjectRadius = New System.Windows.Forms.TextBox()
        lblObjectRefractiveIndex = New System.Windows.Forms.Label()
        lblObjectReflectivity = New System.Windows.Forms.Label()
        cmdObjectReflectivity = New System.Windows.Forms.Button()
        lblObjectType = New System.Windows.Forms.Label()
        lblObjectNormal = New System.Windows.Forms.Label()
        cbObjectType = New System.Windows.Forms.ComboBox()
        lblObjectRotation = New System.Windows.Forms.Label()
        chObjectWireframe = New System.Windows.Forms.CheckBox()
        chObjectAffected = New System.Windows.Forms.CheckBox()
        chObjectAffects = New System.Windows.Forms.CheckBox()
        cmdObjectNumber = New System.Windows.Forms.Button()
        lblObjectNumber = New System.Windows.Forms.Label()
        lblObjectRadius = New System.Windows.Forms.Label()
        cmdObjectRadius = New System.Windows.Forms.Button()
        cmdObjectTransparency = New System.Windows.Forms.Button()
        cmdObjectHighlightSharpness = New System.Windows.Forms.Button()
        lblObjectSize = New System.Windows.Forms.Label()
        cmdObjectHighlightColor = New System.Windows.Forms.Button()
        cmdObjectColor = New System.Windows.Forms.Button()
        tbObjectHighlightSharpness = New System.Windows.Forms.TrackBar()
        cmdObjectCharge = New System.Windows.Forms.Button()
        cmdObjectMass = New System.Windows.Forms.Button()
        txtObjectNumber = New System.Windows.Forms.TextBox()
        lblObjectHighlightColor = New System.Windows.Forms.Label()
        txtObjectCharge = New System.Windows.Forms.TextBox()
        lblObjectName = New System.Windows.Forms.Label()
        txtObjectMass = New System.Windows.Forms.TextBox()
        lblObjectTransparency = New System.Windows.Forms.Label()
        txtObjectName = New System.Windows.Forms.TextBox()
        lblObjectMass = New System.Windows.Forms.Label()
        lblObjectCharge = New System.Windows.Forms.Label()
        lblObjectHighlightSharpness = New System.Windows.Forms.Label()
        lblObjectColor = New System.Windows.Forms.Label()
        lblObjectVelocity = New System.Windows.Forms.Label()
        lblObjectPosition = New System.Windows.Forms.Label()
        cmdGroupAdd = New System.Windows.Forms.Button()
        TabLights = New System.Windows.Forms.TabPage()
        TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        cmdLightRemove = New System.Windows.Forms.Button()
        cmdLightReplace = New System.Windows.Forms.Button()
        gbLights = New System.Windows.Forms.GroupBox()
        Panel1 = New System.Windows.Forms.Panel()
        TableLayoutPanel12 = New System.Windows.Forms.TableLayoutPanel()
        txtLightAngleInner = New System.Windows.Forms.TextBox()
        txtLightAngleOuter = New System.Windows.Forms.TextBox()
        TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel()
        txtLightAttenuationA = New System.Windows.Forms.TextBox()
        txtLightAttenuationB = New System.Windows.Forms.TextBox()
        txtLightAttenuationC = New System.Windows.Forms.TextBox()
        txtLightRange = New System.Windows.Forms.TextBox()
        tbLightAmbient = New System.Windows.Forms.TrackBar()
        TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        txtLightDirectionX = New System.Windows.Forms.TextBox()
        txtLightDirectionY = New System.Windows.Forms.TextBox()
        txtLightDirectionZ = New System.Windows.Forms.TextBox()
        TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        txtLightPositionX = New System.Windows.Forms.TextBox()
        txtLightPositionY = New System.Windows.Forms.TextBox()
        txtLightPositionZ = New System.Windows.Forms.TextBox()
        plLightColor = New System.Windows.Forms.Button()
        cbLightType = New System.Windows.Forms.ComboBox()
        tbLightHighlight = New System.Windows.Forms.TrackBar()
        lblLightColor = New System.Windows.Forms.Label()
        lblLightAttenuation = New System.Windows.Forms.Label()
        lblLightDirection = New System.Windows.Forms.Label()
        lblLightRange = New System.Windows.Forms.Label()
        lblLightName = New System.Windows.Forms.Label()
        lblLightFalloff = New System.Windows.Forms.Label()
        txtLightName = New System.Windows.Forms.TextBox()
        txtLightFalloff = New System.Windows.Forms.TextBox()
        lblLightAngle = New System.Windows.Forms.Label()
        lblLightPosition = New System.Windows.Forms.Label()
        lblLightAmbient = New System.Windows.Forms.Label()
        lblLightHighlight = New System.Windows.Forms.Label()
        lblLightType = New System.Windows.Forms.Label()
        listLights = New System.Windows.Forms.ListBox()
        chLightsEnable = New System.Windows.Forms.CheckBox()
        cmdLightAdd = New System.Windows.Forms.Button()
        TabDisplay = New System.Windows.Forms.TabPage()
        spRendering = New System.Windows.Forms.SplitContainer()
        gbRendering = New System.Windows.Forms.GroupBox()
        pRender = New System.Windows.Forms.Panel()
        chVSync = New System.Windows.Forms.CheckBox()
        TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        txtWindowX = New System.Windows.Forms.TextBox()
        txtWindowY = New System.Windows.Forms.TextBox()
        Label45 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label30 = New System.Windows.Forms.Label()
        tbPolys = New System.Windows.Forms.TrackBar()
        Label12 = New System.Windows.Forms.Label()
        txtRenderThreads = New System.Windows.Forms.TextBox()
        cbShading = New System.Windows.Forms.ComboBox()
        Label18 = New System.Windows.Forms.Label()
        Label46 = New System.Windows.Forms.Label()
        Label43 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        txtHFoV = New System.Windows.Forms.TextBox()
        txtVFoV = New System.Windows.Forms.TextBox()
        txtMaxFPS = New System.Windows.Forms.TextBox()
        chTrace = New System.Windows.Forms.CheckBox()
        Label44 = New System.Windows.Forms.Label()
        plRenderBackColor = New System.Windows.Forms.Button()
        cbRender = New System.Windows.Forms.ComboBox()
        gbCamera = New System.Windows.Forms.GroupBox()
        pCamera = New System.Windows.Forms.Panel()
        TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        txtCOrientX = New System.Windows.Forms.TextBox()
        txtCOrientY = New System.Windows.Forms.TextBox()
        txtCOrientZ = New System.Windows.Forms.TextBox()
        TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        txtCTargetX = New System.Windows.Forms.TextBox()
        txtCTargetY = New System.Windows.Forms.TextBox()
        txtCTargetZ = New System.Windows.Forms.TextBox()
        TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        txtCPosX = New System.Windows.Forms.TextBox()
        txtCPosY = New System.Windows.Forms.TextBox()
        txtCPosZ = New System.Windows.Forms.TextBox()
        Label47 = New System.Windows.Forms.Label()
        chCamera = New System.Windows.Forms.CheckBox()
        tbCameraSpeed = New System.Windows.Forms.TrackBar()
        Label17 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label16 = New System.Windows.Forms.Label()
        CmdSaveOut = New System.Windows.Forms.Button()
        TabForces = New System.Windows.Forms.TabPage()
        spForces = New System.Windows.Forms.SplitContainer()
        gbForces = New System.Windows.Forms.GroupBox()
        pForces = New System.Windows.Forms.Panel()
        tlpAccelForce = New System.Windows.Forms.TableLayoutPanel()
        txtFieldX = New System.Windows.Forms.TextBox()
        txtFieldY = New System.Windows.Forms.TextBox()
        txtFieldZ = New System.Windows.Forms.TextBox()
        txtPermittivity = New System.Windows.Forms.TextBox()
        chForces = New System.Windows.Forms.CheckBox()
        Label48 = New System.Windows.Forms.Label()
        Label26 = New System.Windows.Forms.Label()
        txtFluidViscosity = New System.Windows.Forms.TextBox()
        Label28 = New System.Windows.Forms.Label()
        Label29 = New System.Windows.Forms.Label()
        chDrag = New System.Windows.Forms.CheckBox()
        txtDragCoeff = New System.Windows.Forms.TextBox()
        Label22 = New System.Windows.Forms.Label()
        txtFluidDensity = New System.Windows.Forms.TextBox()
        chField = New System.Windows.Forms.CheckBox()
        chElectrostatic = New System.Windows.Forms.CheckBox()
        chGravity = New System.Windows.Forms.CheckBox()
        gbCollisions = New System.Windows.Forms.GroupBox()
        pCollisions = New System.Windows.Forms.Panel()
        TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        txtAddMin = New System.Windows.Forms.TextBox()
        txtAddAvg = New System.Windows.Forms.TextBox()
        txtAddMax = New System.Windows.Forms.TextBox()
        TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        txtBreakMax = New System.Windows.Forms.TextBox()
        txtBreakAvg = New System.Windows.Forms.TextBox()
        txtBreakMin = New System.Windows.Forms.TextBox()
        chInterpolate = New System.Windows.Forms.CheckBox()
        chCollision = New System.Windows.Forms.CheckBox()
        Label20 = New System.Windows.Forms.Label()
        txtCoR = New System.Windows.Forms.TextBox()
        chbreakable = New System.Windows.Forms.CheckBox()
        lblResulting = New System.Windows.Forms.Label()
        Label25 = New System.Windows.Forms.Label()
        TabSimulation = New System.Windows.Forms.TabPage()
        spSaveAndLoad = New System.Windows.Forms.SplitContainer()
        cmdSave = New System.Windows.Forms.Button()
        cmdLoad = New System.Windows.Forms.Button()
        gbSimulation = New System.Windows.Forms.GroupBox()
        pSimulation = New System.Windows.Forms.Panel()
        Label1 = New System.Windows.Forms.Label()
        txtLimitObjects = New System.Windows.Forms.TextBox()
        Label4 = New System.Windows.Forms.Label()
        Label14 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label24 = New System.Windows.Forms.Label()
        txtLimitCalc = New System.Windows.Forms.TextBox()
        cbIntegration = New System.Windows.Forms.ComboBox()
        txtScale = New System.Windows.Forms.TextBox()
        txtTimeStep = New System.Windows.Forms.TextBox()
        Tabs = New System.Windows.Forms.TabControl()
        TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        TableLayoutPanel16 = New System.Windows.Forms.TableLayoutPanel()
        tblRotation = New System.Windows.Forms.TableLayoutPanel()
        Stats.SuspendLayout()
        TabGroups.SuspendLayout()
        TableLayoutPanel13.SuspendLayout()
        gbObjects.SuspendLayout()
        Panel2.SuspendLayout()
        tblOrientation.SuspendLayout()
        tblVelocity.SuspendLayout()
        tblPosition.SuspendLayout()
        TableLayoutPanel15.SuspendLayout()
        CType(tbObjectTransparency, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbObjectReflectivity, ComponentModel.ISupportInitialize).BeginInit()
        tblSize.SuspendLayout()
        CType(tbObjectHighlightSharpness, ComponentModel.ISupportInitialize).BeginInit()
        TabLights.SuspendLayout()
        TableLayoutPanel8.SuspendLayout()
        gbLights.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel12.SuspendLayout()
        TableLayoutPanel11.SuspendLayout()
        CType(tbLightAmbient, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel10.SuspendLayout()
        TableLayoutPanel9.SuspendLayout()
        CType(tbLightHighlight, ComponentModel.ISupportInitialize).BeginInit()
        TabDisplay.SuspendLayout()
        CType(spRendering, ComponentModel.ISupportInitialize).BeginInit()
        spRendering.Panel1.SuspendLayout()
        spRendering.Panel2.SuspendLayout()
        spRendering.SuspendLayout()
        gbRendering.SuspendLayout()
        pRender.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        CType(tbPolys, ComponentModel.ISupportInitialize).BeginInit()
        gbCamera.SuspendLayout()
        pCamera.SuspendLayout()
        TableLayoutPanel7.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        CType(tbCameraSpeed, ComponentModel.ISupportInitialize).BeginInit()
        TabForces.SuspendLayout()
        CType(spForces, ComponentModel.ISupportInitialize).BeginInit()
        spForces.Panel1.SuspendLayout()
        spForces.Panel2.SuspendLayout()
        spForces.SuspendLayout()
        gbForces.SuspendLayout()
        pForces.SuspendLayout()
        tlpAccelForce.SuspendLayout()
        gbCollisions.SuspendLayout()
        pCollisions.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TabSimulation.SuspendLayout()
        CType(spSaveAndLoad, ComponentModel.ISupportInitialize).BeginInit()
        spSaveAndLoad.Panel1.SuspendLayout()
        spSaveAndLoad.Panel2.SuspendLayout()
        spSaveAndLoad.SuspendLayout()
        gbSimulation.SuspendLayout()
        pSimulation.SuspendLayout()
        Tabs.SuspendLayout()
        SuspendLayout()
        ' 
        ' cmdStart
        ' 
        cmdStart.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cmdStart.BackColor = SystemColors.Control
        cmdStart.FlatAppearance.BorderColor = Color.Black
        cmdStart.FlatAppearance.BorderSize = 0
        cmdStart.FlatStyle = System.Windows.Forms.FlatStyle.System
        cmdStart.Font = New Font("Arial", 11.25F, FontStyle.Bold)
        cmdStart.ForeColor = Color.Black
        cmdStart.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdStart.Location = New Point(12, 5)
        cmdStart.Name = "cmdStart"
        cmdStart.Size = New Size(957, 62)
        cmdStart.TabIndex = 0
        cmdStart.Text = "&Start Simulation"
        cmdStart.UseVisualStyleBackColor = False
        ' 
        ' ColorDialog
        ' 
        ColorDialog.AnyColor = True
        ColorDialog.Color = SystemColors.ActiveCaption
        ColorDialog.FullOpen = True
        ' 
        ' Stats
        ' 
        Stats.AutoSize = False
        Stats.ImageScalingSize = New Size(32, 32)
        Stats.Items.AddRange(New System.Windows.Forms.ToolStripItem() {lblStat})
        Stats.Location = New Point(0, 1437)
        Stats.Name = "Stats"
        Stats.Size = New Size(981, 42)
        Stats.SizingGrip = False
        Stats.TabIndex = 22
        ' 
        ' lblStat
        ' 
        lblStat.BackColor = SystemColors.Control
        lblStat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        lblStat.Font = New Font("Arial", 8.25F)
        lblStat.ForeColor = SystemColors.ControlText
        lblStat.LinkColor = Color.White
        lblStat.Name = "lblStat"
        lblStat.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        lblStat.Size = New Size(966, 32)
        lblStat.Spring = True
        lblStat.Text = "Frames : 0  |  FPS : 0  |  Calculations : 0  |  CPS : 0"
        ' 
        ' StatusUpdate
        ' 
        StatusUpdate.Interval = 150
        ' 
        ' TabGroups
        ' 
        TabGroups.BackColor = SystemColors.Control
        TabGroups.Controls.Add(TableLayoutPanel13)
        TabGroups.Controls.Add(gbObjects)
        TabGroups.Controls.Add(cmdGroupAdd)
        TabGroups.Location = New Point(4, 39)
        TabGroups.Name = "TabGroups"
        TabGroups.Padding = New System.Windows.Forms.Padding(3)
        TabGroups.Size = New Size(973, 1321)
        TabGroups.TabIndex = 7
        TabGroups.Text = "Objects"
        TabGroups.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel13
        ' 
        TableLayoutPanel13.ColumnCount = 2
        TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        TableLayoutPanel13.Controls.Add(cmdGroupReplace, 0, 0)
        TableLayoutPanel13.Controls.Add(cmdGroupRemove, 1, 0)
        TableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Bottom
        TableLayoutPanel13.Location = New Point(3, 1250)
        TableLayoutPanel13.Name = "TableLayoutPanel13"
        TableLayoutPanel13.RowCount = 1
        TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F))
        TableLayoutPanel13.Size = New Size(967, 68)
        TableLayoutPanel13.TabIndex = 71
        ' 
        ' cmdGroupReplace
        ' 
        cmdGroupReplace.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cmdGroupReplace.Enabled = False
        cmdGroupReplace.FlatAppearance.BorderColor = Color.Black
        cmdGroupReplace.FlatStyle = System.Windows.Forms.FlatStyle.System
        cmdGroupReplace.ForeColor = SystemColors.ControlText
        cmdGroupReplace.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdGroupReplace.Location = New Point(3, 3)
        cmdGroupReplace.Name = "cmdGroupReplace"
        cmdGroupReplace.Size = New Size(477, 62)
        cmdGroupReplace.TabIndex = 1
        cmdGroupReplace.Text = "Replace Objects"
        cmdGroupReplace.UseVisualStyleBackColor = True
        ' 
        ' cmdGroupRemove
        ' 
        cmdGroupRemove.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cmdGroupRemove.Enabled = False
        cmdGroupRemove.FlatAppearance.BorderColor = Color.Black
        cmdGroupRemove.FlatStyle = System.Windows.Forms.FlatStyle.System
        cmdGroupRemove.ForeColor = SystemColors.ControlText
        cmdGroupRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdGroupRemove.Location = New Point(486, 3)
        cmdGroupRemove.Name = "cmdGroupRemove"
        cmdGroupRemove.Size = New Size(478, 62)
        cmdGroupRemove.TabIndex = 2
        cmdGroupRemove.Text = "Remove Objects"
        cmdGroupRemove.UseVisualStyleBackColor = True
        ' 
        ' gbObjects
        ' 
        gbObjects.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        gbObjects.Controls.Add(listGroups)
        gbObjects.Controls.Add(Panel2)
        gbObjects.Location = New Point(6, 6)
        gbObjects.Name = "gbObjects"
        gbObjects.Size = New Size(959, 1176)
        gbObjects.TabIndex = 70
        gbObjects.TabStop = False
        gbObjects.Text = "Objects"
        ' 
        ' listGroups
        ' 
        listGroups.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        listGroups.Font = New Font("Arial", 9F)
        listGroups.ForeColor = SystemColors.ControlText
        listGroups.ItemHeight = 27
        listGroups.Location = New Point(6, 34)
        listGroups.Name = "listGroups"
        listGroups.Size = New Size(942, 166)
        listGroups.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Panel2.AutoScroll = True
        Panel2.Controls.Add(tblOrientation)
        Panel2.Controls.Add(tblVelocity)
        Panel2.Controls.Add(tblPosition)
        Panel2.Controls.Add(TableLayoutPanel15)
        Panel2.Controls.Add(txtObjectRefractiveIndex)
        Panel2.Controls.Add(tbObjectTransparency)
        Panel2.Controls.Add(tbObjectReflectivity)
        Panel2.Controls.Add(tblSize)
        Panel2.Controls.Add(plObjectHighlightColor)
        Panel2.Controls.Add(plObjectColor)
        Panel2.Controls.Add(cmdObjectRefractiveIndex)
        Panel2.Controls.Add(txtObjectRadius)
        Panel2.Controls.Add(lblObjectRefractiveIndex)
        Panel2.Controls.Add(lblObjectReflectivity)
        Panel2.Controls.Add(cmdObjectReflectivity)
        Panel2.Controls.Add(lblObjectType)
        Panel2.Controls.Add(lblObjectNormal)
        Panel2.Controls.Add(cbObjectType)
        Panel2.Controls.Add(lblObjectRotation)
        Panel2.Controls.Add(chObjectWireframe)
        Panel2.Controls.Add(chObjectAffected)
        Panel2.Controls.Add(chObjectAffects)
        Panel2.Controls.Add(cmdObjectNumber)
        Panel2.Controls.Add(lblObjectNumber)
        Panel2.Controls.Add(lblObjectRadius)
        Panel2.Controls.Add(cmdObjectRadius)
        Panel2.Controls.Add(cmdObjectTransparency)
        Panel2.Controls.Add(cmdObjectHighlightSharpness)
        Panel2.Controls.Add(lblObjectSize)
        Panel2.Controls.Add(cmdObjectHighlightColor)
        Panel2.Controls.Add(cmdObjectColor)
        Panel2.Controls.Add(tbObjectHighlightSharpness)
        Panel2.Controls.Add(cmdObjectCharge)
        Panel2.Controls.Add(cmdObjectMass)
        Panel2.Controls.Add(txtObjectNumber)
        Panel2.Controls.Add(lblObjectHighlightColor)
        Panel2.Controls.Add(txtObjectCharge)
        Panel2.Controls.Add(lblObjectName)
        Panel2.Controls.Add(txtObjectMass)
        Panel2.Controls.Add(lblObjectTransparency)
        Panel2.Controls.Add(txtObjectName)
        Panel2.Controls.Add(lblObjectMass)
        Panel2.Controls.Add(lblObjectCharge)
        Panel2.Controls.Add(lblObjectHighlightSharpness)
        Panel2.Controls.Add(lblObjectColor)
        Panel2.Controls.Add(lblObjectVelocity)
        Panel2.Controls.Add(lblObjectPosition)
        Panel2.Location = New Point(6, 206)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(947, 964)
        Panel2.TabIndex = 240
        ' 
        ' tblOrientation
        ' 
        tblOrientation.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        tblOrientation.ColumnCount = 6
        tblOrientation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblOrientation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblOrientation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblOrientation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblOrientation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblOrientation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblOrientation.Controls.Add(txtObjectNormalX, 1, 0)
        tblOrientation.Controls.Add(txtObjectNormalY, 3, 0)
        tblOrientation.Controls.Add(txtObjectNormalZ, 5, 0)
        tblOrientation.Controls.Add(cmdObjectNormalX, 0, 0)
        tblOrientation.Controls.Add(cmdObjectNormalZ, 4, 0)
        tblOrientation.Controls.Add(cmdObjectNormalY, 2, 0)
        tblOrientation.Location = New Point(271, 291)
        tblOrientation.Name = "tblOrientation"
        tblOrientation.RowCount = 1
        tblOrientation.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblOrientation.Size = New Size(668, 43)
        tblOrientation.TabIndex = 243
        ' 
        ' txtObjectNormalX
        ' 
        txtObjectNormalX.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectNormalX.Enabled = False
        txtObjectNormalX.ForeColor = SystemColors.ControlText
        txtObjectNormalX.Location = New Point(40, 3)
        txtObjectNormalX.Name = "txtObjectNormalX"
        txtObjectNormalX.Size = New Size(179, 35)
        txtObjectNormalX.TabIndex = 16
        txtObjectNormalX.Text = "5"
        txtObjectNormalX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtObjectNormalY
        ' 
        txtObjectNormalY.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectNormalY.Enabled = False
        txtObjectNormalY.ForeColor = SystemColors.ControlText
        txtObjectNormalY.Location = New Point(262, 3)
        txtObjectNormalY.Name = "txtObjectNormalY"
        txtObjectNormalY.Size = New Size(179, 35)
        txtObjectNormalY.TabIndex = 18
        txtObjectNormalY.Text = "5"
        txtObjectNormalY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtObjectNormalZ
        ' 
        txtObjectNormalZ.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectNormalZ.Enabled = False
        txtObjectNormalZ.ForeColor = SystemColors.ControlText
        txtObjectNormalZ.Location = New Point(484, 3)
        txtObjectNormalZ.Name = "txtObjectNormalZ"
        txtObjectNormalZ.Size = New Size(181, 35)
        txtObjectNormalZ.TabIndex = 21
        txtObjectNormalZ.Text = "5"
        txtObjectNormalZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' cmdObjectNormalX
        ' 
        cmdObjectNormalX.FlatAppearance.BorderSize = 0
        cmdObjectNormalX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectNormalX.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectNormalX.ForeColor = Color.Black
        cmdObjectNormalX.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectNormalX.Location = New Point(3, 3)
        cmdObjectNormalX.Name = "cmdObjectNormalX"
        cmdObjectNormalX.Size = New Size(31, 35)
        cmdObjectNormalX.TabIndex = 231
        cmdObjectNormalX.Text = "ƒ"
        cmdObjectNormalX.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectNormalZ
        ' 
        cmdObjectNormalZ.FlatAppearance.BorderSize = 0
        cmdObjectNormalZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectNormalZ.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectNormalZ.ForeColor = Color.Black
        cmdObjectNormalZ.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectNormalZ.Location = New Point(447, 3)
        cmdObjectNormalZ.Name = "cmdObjectNormalZ"
        cmdObjectNormalZ.Size = New Size(31, 35)
        cmdObjectNormalZ.TabIndex = 239
        cmdObjectNormalZ.Text = "ƒ"
        cmdObjectNormalZ.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectNormalY
        ' 
        cmdObjectNormalY.FlatAppearance.BorderSize = 0
        cmdObjectNormalY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectNormalY.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectNormalY.ForeColor = Color.Black
        cmdObjectNormalY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectNormalY.Location = New Point(225, 3)
        cmdObjectNormalY.Name = "cmdObjectNormalY"
        cmdObjectNormalY.Size = New Size(31, 35)
        cmdObjectNormalY.TabIndex = 238
        cmdObjectNormalY.Text = "ƒ"
        cmdObjectNormalY.UseVisualStyleBackColor = False
        ' 
        ' tblVelocity
        ' 
        tblVelocity.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        tblVelocity.ColumnCount = 6
        tblVelocity.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblVelocity.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblVelocity.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblVelocity.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblVelocity.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblVelocity.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblVelocity.Controls.Add(txtObjectVelocityX, 1, 0)
        tblVelocity.Controls.Add(txtObjectVelocityY, 3, 0)
        tblVelocity.Controls.Add(txtObjectVelocityZ, 5, 0)
        tblVelocity.Controls.Add(cmdObjectVelocityZ, 4, 0)
        tblVelocity.Controls.Add(cmdObjectVelocityY, 2, 0)
        tblVelocity.Controls.Add(cmdObjectVelocityX, 0, 0)
        tblVelocity.Location = New Point(271, 389)
        tblVelocity.Name = "tblVelocity"
        tblVelocity.RowCount = 1
        tblVelocity.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblVelocity.Size = New Size(671, 43)
        tblVelocity.TabIndex = 244
        ' 
        ' txtObjectVelocityX
        ' 
        txtObjectVelocityX.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectVelocityX.ForeColor = SystemColors.ControlText
        txtObjectVelocityX.Location = New Point(40, 3)
        txtObjectVelocityX.Name = "txtObjectVelocityX"
        txtObjectVelocityX.Size = New Size(180, 35)
        txtObjectVelocityX.TabIndex = 30
        txtObjectVelocityX.Text = "0"
        txtObjectVelocityX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtObjectVelocityY
        ' 
        txtObjectVelocityY.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectVelocityY.ForeColor = SystemColors.ControlText
        txtObjectVelocityY.Location = New Point(263, 3)
        txtObjectVelocityY.Name = "txtObjectVelocityY"
        txtObjectVelocityY.Size = New Size(180, 35)
        txtObjectVelocityY.TabIndex = 32
        txtObjectVelocityY.Text = "0"
        txtObjectVelocityY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtObjectVelocityZ
        ' 
        txtObjectVelocityZ.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectVelocityZ.ForeColor = SystemColors.ControlText
        txtObjectVelocityZ.Location = New Point(486, 3)
        txtObjectVelocityZ.Name = "txtObjectVelocityZ"
        txtObjectVelocityZ.Size = New Size(182, 35)
        txtObjectVelocityZ.TabIndex = 34
        txtObjectVelocityZ.Text = "0"
        txtObjectVelocityZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' cmdObjectVelocityZ
        ' 
        cmdObjectVelocityZ.FlatAppearance.BorderSize = 0
        cmdObjectVelocityZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectVelocityZ.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectVelocityZ.ForeColor = Color.Black
        cmdObjectVelocityZ.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectVelocityZ.Location = New Point(449, 3)
        cmdObjectVelocityZ.Name = "cmdObjectVelocityZ"
        cmdObjectVelocityZ.Size = New Size(31, 35)
        cmdObjectVelocityZ.TabIndex = 33
        cmdObjectVelocityZ.Text = "ƒ"
        cmdObjectVelocityZ.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectVelocityY
        ' 
        cmdObjectVelocityY.FlatAppearance.BorderSize = 0
        cmdObjectVelocityY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectVelocityY.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectVelocityY.ForeColor = Color.Black
        cmdObjectVelocityY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectVelocityY.Location = New Point(226, 3)
        cmdObjectVelocityY.Name = "cmdObjectVelocityY"
        cmdObjectVelocityY.Size = New Size(31, 35)
        cmdObjectVelocityY.TabIndex = 31
        cmdObjectVelocityY.Text = "ƒ"
        cmdObjectVelocityY.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectVelocityX
        ' 
        cmdObjectVelocityX.FlatAppearance.BorderSize = 0
        cmdObjectVelocityX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectVelocityX.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectVelocityX.ForeColor = Color.Black
        cmdObjectVelocityX.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectVelocityX.Location = New Point(3, 3)
        cmdObjectVelocityX.Name = "cmdObjectVelocityX"
        cmdObjectVelocityX.Size = New Size(31, 35)
        cmdObjectVelocityX.TabIndex = 29
        cmdObjectVelocityX.Text = "ƒ"
        cmdObjectVelocityX.UseVisualStyleBackColor = False
        ' 
        ' tblPosition
        ' 
        tblPosition.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        tblPosition.ColumnCount = 6
        tblPosition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblPosition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblPosition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblPosition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblPosition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblPosition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblPosition.Controls.Add(txtObjectPositionX, 1, 0)
        tblPosition.Controls.Add(txtObjectPositionY, 3, 0)
        tblPosition.Controls.Add(txtObjectPositionZ, 5, 0)
        tblPosition.Controls.Add(cmdObjectPositionZ, 4, 0)
        tblPosition.Controls.Add(cmdObjectPositionY, 2, 0)
        tblPosition.Controls.Add(cmdObjectPositionX, 0, 0)
        tblPosition.Location = New Point(271, 340)
        tblPosition.Name = "tblPosition"
        tblPosition.RowCount = 1
        tblPosition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblPosition.Size = New Size(671, 43)
        tblPosition.TabIndex = 242
        ' 
        ' txtObjectPositionX
        ' 
        txtObjectPositionX.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectPositionX.ForeColor = SystemColors.ControlText
        txtObjectPositionX.Location = New Point(40, 3)
        txtObjectPositionX.Name = "txtObjectPositionX"
        txtObjectPositionX.Size = New Size(180, 35)
        txtObjectPositionX.TabIndex = 24
        txtObjectPositionX.Text = "0"
        txtObjectPositionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtObjectPositionY
        ' 
        txtObjectPositionY.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectPositionY.ForeColor = SystemColors.ControlText
        txtObjectPositionY.Location = New Point(263, 3)
        txtObjectPositionY.Name = "txtObjectPositionY"
        txtObjectPositionY.Size = New Size(180, 35)
        txtObjectPositionY.TabIndex = 26
        txtObjectPositionY.Text = "0"
        txtObjectPositionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtObjectPositionZ
        ' 
        txtObjectPositionZ.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectPositionZ.ForeColor = SystemColors.ControlText
        txtObjectPositionZ.Location = New Point(486, 3)
        txtObjectPositionZ.Name = "txtObjectPositionZ"
        txtObjectPositionZ.Size = New Size(182, 35)
        txtObjectPositionZ.TabIndex = 28
        txtObjectPositionZ.Text = "0"
        txtObjectPositionZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' cmdObjectPositionZ
        ' 
        cmdObjectPositionZ.FlatAppearance.BorderSize = 0
        cmdObjectPositionZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectPositionZ.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectPositionZ.ForeColor = Color.Black
        cmdObjectPositionZ.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectPositionZ.Location = New Point(449, 3)
        cmdObjectPositionZ.Name = "cmdObjectPositionZ"
        cmdObjectPositionZ.Size = New Size(31, 35)
        cmdObjectPositionZ.TabIndex = 27
        cmdObjectPositionZ.Text = "ƒ"
        cmdObjectPositionZ.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectPositionY
        ' 
        cmdObjectPositionY.FlatAppearance.BorderSize = 0
        cmdObjectPositionY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectPositionY.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectPositionY.ForeColor = Color.Black
        cmdObjectPositionY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectPositionY.Location = New Point(226, 3)
        cmdObjectPositionY.Name = "cmdObjectPositionY"
        cmdObjectPositionY.Size = New Size(31, 35)
        cmdObjectPositionY.TabIndex = 25
        cmdObjectPositionY.Text = "ƒ"
        cmdObjectPositionY.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectPositionX
        ' 
        cmdObjectPositionX.FlatAppearance.BorderSize = 0
        cmdObjectPositionX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectPositionX.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectPositionX.ForeColor = Color.Black
        cmdObjectPositionX.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectPositionX.Location = New Point(3, 3)
        cmdObjectPositionX.Name = "cmdObjectPositionX"
        cmdObjectPositionX.Size = New Size(31, 35)
        cmdObjectPositionX.TabIndex = 23
        cmdObjectPositionX.Text = "ƒ"
        cmdObjectPositionX.UseVisualStyleBackColor = False
        ' 
        ' TableLayoutPanel15
        ' 
        TableLayoutPanel15.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel15.ColumnCount = 6
        TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel15.Controls.Add(txtObjectRotationX, 1, 0)
        TableLayoutPanel15.Controls.Add(txtObjectRotationY, 3, 0)
        TableLayoutPanel15.Controls.Add(txtObjectRotationZ, 5, 0)
        TableLayoutPanel15.Controls.Add(cmdObjectRotationY, 2, 0)
        TableLayoutPanel15.Controls.Add(cmdObjectRotationZ, 4, 0)
        TableLayoutPanel15.Controls.Add(cmdObjectRotationX, 0, 0)
        TableLayoutPanel15.Location = New Point(271, 291)
        TableLayoutPanel15.Name = "TableLayoutPanel15"
        TableLayoutPanel15.RowCount = 1
        TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        TableLayoutPanel15.Size = New Size(671, 43)
        TableLayoutPanel15.TabIndex = 241
        ' 
        ' txtObjectRotationX
        ' 
        txtObjectRotationX.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectRotationX.Enabled = False
        txtObjectRotationX.ForeColor = SystemColors.ControlText
        txtObjectRotationX.Location = New Point(40, 3)
        txtObjectRotationX.Name = "txtObjectRotationX"
        txtObjectRotationX.Size = New Size(180, 35)
        txtObjectRotationX.TabIndex = 221
        txtObjectRotationX.Text = "5"
        txtObjectRotationX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtObjectRotationY
        ' 
        txtObjectRotationY.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectRotationY.Enabled = False
        txtObjectRotationY.ForeColor = SystemColors.ControlText
        txtObjectRotationY.Location = New Point(263, 3)
        txtObjectRotationY.Name = "txtObjectRotationY"
        txtObjectRotationY.Size = New Size(180, 35)
        txtObjectRotationY.TabIndex = 222
        txtObjectRotationY.Text = "5"
        txtObjectRotationY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtObjectRotationZ
        ' 
        txtObjectRotationZ.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectRotationZ.Enabled = False
        txtObjectRotationZ.ForeColor = SystemColors.ControlText
        txtObjectRotationZ.Location = New Point(486, 3)
        txtObjectRotationZ.Name = "txtObjectRotationZ"
        txtObjectRotationZ.Size = New Size(182, 35)
        txtObjectRotationZ.TabIndex = 223
        txtObjectRotationZ.Text = "5"
        txtObjectRotationZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' cmdObjectRotationY
        ' 
        cmdObjectRotationY.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cmdObjectRotationY.FlatAppearance.BorderSize = 0
        cmdObjectRotationY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectRotationY.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectRotationY.ForeColor = Color.Black
        cmdObjectRotationY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectRotationY.Location = New Point(226, 3)
        cmdObjectRotationY.Name = "cmdObjectRotationY"
        cmdObjectRotationY.Size = New Size(31, 35)
        cmdObjectRotationY.TabIndex = 17
        cmdObjectRotationY.Text = "ƒ"
        cmdObjectRotationY.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectRotationZ
        ' 
        cmdObjectRotationZ.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cmdObjectRotationZ.FlatAppearance.BorderSize = 0
        cmdObjectRotationZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectRotationZ.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectRotationZ.ForeColor = Color.Black
        cmdObjectRotationZ.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectRotationZ.Location = New Point(449, 3)
        cmdObjectRotationZ.Name = "cmdObjectRotationZ"
        cmdObjectRotationZ.Size = New Size(31, 35)
        cmdObjectRotationZ.TabIndex = 22
        cmdObjectRotationZ.Text = "ƒ"
        cmdObjectRotationZ.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectRotationX
        ' 
        cmdObjectRotationX.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cmdObjectRotationX.FlatAppearance.BorderSize = 0
        cmdObjectRotationX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectRotationX.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectRotationX.ForeColor = Color.Black
        cmdObjectRotationX.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectRotationX.Location = New Point(3, 3)
        cmdObjectRotationX.Name = "cmdObjectRotationX"
        cmdObjectRotationX.Size = New Size(31, 35)
        cmdObjectRotationX.TabIndex = 15
        cmdObjectRotationX.Text = "ƒ"
        cmdObjectRotationX.UseVisualStyleBackColor = False
        ' 
        ' txtObjectRefractiveIndex
        ' 
        txtObjectRefractiveIndex.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectRefractiveIndex.ForeColor = SystemColors.ControlText
        txtObjectRefractiveIndex.Location = New Point(314, 677)
        txtObjectRefractiveIndex.Name = "txtObjectRefractiveIndex"
        txtObjectRefractiveIndex.Size = New Size(628, 35)
        txtObjectRefractiveIndex.TabIndex = 46
        txtObjectRefractiveIndex.Text = "1"
        txtObjectRefractiveIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' tbObjectTransparency
        ' 
        tbObjectTransparency.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        tbObjectTransparency.BackColor = SystemColors.Control
        tbObjectTransparency.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbObjectTransparency.LargeChange = 15
        tbObjectTransparency.Location = New Point(314, 634)
        tbObjectTransparency.Maximum = 255
        tbObjectTransparency.Name = "tbObjectTransparency"
        tbObjectTransparency.Size = New Size(625, 90)
        tbObjectTransparency.SmallChange = 15
        tbObjectTransparency.TabIndex = 44
        tbObjectTransparency.TickFrequency = 5
        tbObjectTransparency.TickStyle = System.Windows.Forms.TickStyle.None
        tbObjectTransparency.Value = 255
        ' 
        ' tbObjectReflectivity
        ' 
        tbObjectReflectivity.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        tbObjectReflectivity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbObjectReflectivity.LargeChange = 10
        tbObjectReflectivity.Location = New Point(314, 577)
        tbObjectReflectivity.Maximum = 100
        tbObjectReflectivity.Name = "tbObjectReflectivity"
        tbObjectReflectivity.Size = New Size(628, 90)
        tbObjectReflectivity.TabIndex = 42
        tbObjectReflectivity.TickFrequency = 5
        tbObjectReflectivity.TickStyle = System.Windows.Forms.TickStyle.None
        ' 
        ' tblSize
        ' 
        tblSize.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        tblSize.ColumnCount = 6
        tblSize.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblSize.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblSize.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblSize.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblSize.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblSize.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblSize.Controls.Add(txtObjectSizeX, 1, 0)
        tblSize.Controls.Add(txtObjectSizeY, 3, 0)
        tblSize.Controls.Add(txtObjectSizeZ, 5, 0)
        tblSize.Controls.Add(cmdObjectSizeZ, 4, 0)
        tblSize.Controls.Add(cmdObjectSizeX, 0, 0)
        tblSize.Controls.Add(cmdObjectSizeY, 2, 0)
        tblSize.Location = New Point(271, 247)
        tblSize.Name = "tblSize"
        tblSize.RowCount = 1
        tblSize.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblSize.Size = New Size(671, 43)
        tblSize.TabIndex = 240
        ' 
        ' txtObjectSizeX
        ' 
        txtObjectSizeX.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectSizeX.Enabled = False
        txtObjectSizeX.ForeColor = SystemColors.ControlText
        txtObjectSizeX.Location = New Point(40, 3)
        txtObjectSizeX.Name = "txtObjectSizeX"
        txtObjectSizeX.Size = New Size(180, 35)
        txtObjectSizeX.TabIndex = 10
        txtObjectSizeX.Text = "5"
        txtObjectSizeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtObjectSizeY
        ' 
        txtObjectSizeY.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectSizeY.Enabled = False
        txtObjectSizeY.ForeColor = SystemColors.ControlText
        txtObjectSizeY.Location = New Point(263, 3)
        txtObjectSizeY.Name = "txtObjectSizeY"
        txtObjectSizeY.Size = New Size(180, 35)
        txtObjectSizeY.TabIndex = 12
        txtObjectSizeY.Text = "5"
        txtObjectSizeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtObjectSizeZ
        ' 
        txtObjectSizeZ.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectSizeZ.Enabled = False
        txtObjectSizeZ.ForeColor = SystemColors.ControlText
        txtObjectSizeZ.Location = New Point(486, 3)
        txtObjectSizeZ.Name = "txtObjectSizeZ"
        txtObjectSizeZ.Size = New Size(182, 35)
        txtObjectSizeZ.TabIndex = 14
        txtObjectSizeZ.Text = "5"
        txtObjectSizeZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' cmdObjectSizeZ
        ' 
        cmdObjectSizeZ.FlatAppearance.BorderSize = 0
        cmdObjectSizeZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectSizeZ.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectSizeZ.ForeColor = Color.Black
        cmdObjectSizeZ.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectSizeZ.Location = New Point(449, 3)
        cmdObjectSizeZ.Name = "cmdObjectSizeZ"
        cmdObjectSizeZ.Size = New Size(31, 35)
        cmdObjectSizeZ.TabIndex = 13
        cmdObjectSizeZ.Text = "ƒ"
        cmdObjectSizeZ.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectSizeX
        ' 
        cmdObjectSizeX.FlatAppearance.BorderSize = 0
        cmdObjectSizeX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectSizeX.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectSizeX.ForeColor = Color.Black
        cmdObjectSizeX.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectSizeX.Location = New Point(3, 3)
        cmdObjectSizeX.Name = "cmdObjectSizeX"
        cmdObjectSizeX.Size = New Size(31, 35)
        cmdObjectSizeX.TabIndex = 168
        cmdObjectSizeX.Text = "ƒ"
        cmdObjectSizeX.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectSizeY
        ' 
        cmdObjectSizeY.FlatAppearance.BorderSize = 0
        cmdObjectSizeY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectSizeY.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectSizeY.ForeColor = Color.Black
        cmdObjectSizeY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectSizeY.Location = New Point(226, 3)
        cmdObjectSizeY.Name = "cmdObjectSizeY"
        cmdObjectSizeY.Size = New Size(31, 35)
        cmdObjectSizeY.TabIndex = 11
        cmdObjectSizeY.Text = "ƒ"
        cmdObjectSizeY.UseVisualStyleBackColor = False
        ' 
        ' plObjectHighlightColor
        ' 
        plObjectHighlightColor.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        plObjectHighlightColor.BackColor = Color.White
        plObjectHighlightColor.FlatAppearance.BorderColor = Color.Black
        plObjectHighlightColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plObjectHighlightColor.ForeColor = Color.White
        plObjectHighlightColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plObjectHighlightColor.Location = New Point(314, 478)
        plObjectHighlightColor.Name = "plObjectHighlightColor"
        plObjectHighlightColor.Size = New Size(630, 32)
        plObjectHighlightColor.TabIndex = 38
        plObjectHighlightColor.UseVisualStyleBackColor = False
        ' 
        ' plObjectColor
        ' 
        plObjectColor.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        plObjectColor.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(128))
        plObjectColor.FlatAppearance.BorderColor = Color.Black
        plObjectColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plObjectColor.ForeColor = Color.FromArgb(CByte(255), CByte(192), CByte(128))
        plObjectColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plObjectColor.Location = New Point(314, 438)
        plObjectColor.Name = "plObjectColor"
        plObjectColor.Size = New Size(630, 32)
        plObjectColor.TabIndex = 36
        plObjectColor.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectRefractiveIndex
        ' 
        cmdObjectRefractiveIndex.FlatAppearance.BorderSize = 0
        cmdObjectRefractiveIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectRefractiveIndex.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectRefractiveIndex.ForeColor = Color.Black
        cmdObjectRefractiveIndex.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectRefractiveIndex.Location = New Point(271, 676)
        cmdObjectRefractiveIndex.Name = "cmdObjectRefractiveIndex"
        cmdObjectRefractiveIndex.Size = New Size(35, 35)
        cmdObjectRefractiveIndex.TabIndex = 45
        cmdObjectRefractiveIndex.Text = "ƒ"
        cmdObjectRefractiveIndex.UseVisualStyleBackColor = False
        ' 
        ' txtObjectRadius
        ' 
        txtObjectRadius.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectRadius.ForeColor = SystemColors.ControlText
        txtObjectRadius.Location = New Point(312, 246)
        txtObjectRadius.Name = "txtObjectRadius"
        txtObjectRadius.Size = New Size(630, 35)
        txtObjectRadius.TabIndex = 151
        txtObjectRadius.Text = "0"
        txtObjectRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' lblObjectRefractiveIndex
        ' 
        lblObjectRefractiveIndex.AutoEllipsis = True
        lblObjectRefractiveIndex.ForeColor = SystemColors.ControlText
        lblObjectRefractiveIndex.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectRefractiveIndex.Location = New Point(11, 677)
        lblObjectRefractiveIndex.Name = "lblObjectRefractiveIndex"
        lblObjectRefractiveIndex.Size = New Size(210, 35)
        lblObjectRefractiveIndex.TabIndex = 233
        lblObjectRefractiveIndex.Text = "Refractive Index: "
        lblObjectRefractiveIndex.TextAlign = ContentAlignment.MiddleLeft
        lblObjectRefractiveIndex.UseMnemonic = False
        ' 
        ' lblObjectReflectivity
        ' 
        lblObjectReflectivity.AutoEllipsis = True
        lblObjectReflectivity.ForeColor = SystemColors.ControlText
        lblObjectReflectivity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectReflectivity.Location = New Point(11, 577)
        lblObjectReflectivity.Name = "lblObjectReflectivity"
        lblObjectReflectivity.Size = New Size(191, 35)
        lblObjectReflectivity.TabIndex = 230
        lblObjectReflectivity.Text = "Reflectivity: "
        lblObjectReflectivity.TextAlign = ContentAlignment.MiddleLeft
        lblObjectReflectivity.UseMnemonic = False
        ' 
        ' cmdObjectReflectivity
        ' 
        cmdObjectReflectivity.FlatAppearance.BorderSize = 0
        cmdObjectReflectivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectReflectivity.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectReflectivity.ForeColor = Color.Black
        cmdObjectReflectivity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectReflectivity.Location = New Point(271, 577)
        cmdObjectReflectivity.Name = "cmdObjectReflectivity"
        cmdObjectReflectivity.Size = New Size(35, 35)
        cmdObjectReflectivity.TabIndex = 41
        cmdObjectReflectivity.Text = "ƒ"
        cmdObjectReflectivity.UseVisualStyleBackColor = False
        ' 
        ' lblObjectType
        ' 
        lblObjectType.AutoEllipsis = True
        lblObjectType.ForeColor = SystemColors.ControlText
        lblObjectType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectType.Location = New Point(9, 65)
        lblObjectType.Name = "lblObjectType"
        lblObjectType.Size = New Size(250, 35)
        lblObjectType.TabIndex = 213
        lblObjectType.Text = "Type of Objects: "
        lblObjectType.TextAlign = ContentAlignment.MiddleLeft
        lblObjectType.UseMnemonic = False
        ' 
        ' lblObjectNormal
        ' 
        lblObjectNormal.AutoEllipsis = True
        lblObjectNormal.ForeColor = SystemColors.ControlText
        lblObjectNormal.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectNormal.Location = New Point(9, 295)
        lblObjectNormal.Name = "lblObjectNormal"
        lblObjectNormal.Size = New Size(238, 35)
        lblObjectNormal.TabIndex = 228
        lblObjectNormal.Text = "Orientation X, Y, Z:"
        lblObjectNormal.TextAlign = ContentAlignment.MiddleLeft
        lblObjectNormal.UseMnemonic = False
        ' 
        ' cbObjectType
        ' 
        cbObjectType.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cbObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cbObjectType.FormattingEnabled = True
        cbObjectType.Items.AddRange(New Object() {"Sphere", "Box", "Plane", "Infinite Plane"})
        cbObjectType.Location = New Point(312, 66)
        cbObjectType.Name = "cbObjectType"
        cbObjectType.Size = New Size(630, 35)
        cbObjectType.TabIndex = 2
        ' 
        ' lblObjectRotation
        ' 
        lblObjectRotation.AutoEllipsis = True
        lblObjectRotation.ForeColor = SystemColors.ControlText
        lblObjectRotation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectRotation.Location = New Point(9, 290)
        lblObjectRotation.Name = "lblObjectRotation"
        lblObjectRotation.Size = New Size(274, 35)
        lblObjectRotation.TabIndex = 224
        lblObjectRotation.Text = "Rotation Y, P, R  (rad):"
        lblObjectRotation.TextAlign = ContentAlignment.MiddleLeft
        lblObjectRotation.UseMnemonic = False
        ' 
        ' chObjectWireframe
        ' 
        chObjectWireframe.AutoEllipsis = True
        chObjectWireframe.Enabled = False
        chObjectWireframe.FlatStyle = System.Windows.Forms.FlatStyle.System
        chObjectWireframe.ForeColor = SystemColors.ControlText
        chObjectWireframe.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chObjectWireframe.Location = New Point(11, 777)
        chObjectWireframe.Name = "chObjectWireframe"
        chObjectWireframe.Size = New Size(320, 35)
        chObjectWireframe.TabIndex = 49
        chObjectWireframe.Text = "Render as Wireframe"
        chObjectWireframe.UseMnemonic = False
        chObjectWireframe.UseVisualStyleBackColor = True
        ' 
        ' chObjectAffected
        ' 
        chObjectAffected.AutoSize = True
        chObjectAffected.Checked = True
        chObjectAffected.CheckState = System.Windows.Forms.CheckState.Checked
        chObjectAffected.Font = New Font("Arial", 9F)
        chObjectAffected.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chObjectAffected.Location = New Point(229, 731)
        chObjectAffected.Name = "chObjectAffected"
        chObjectAffected.Size = New Size(245, 31)
        chObjectAffected.TabIndex = 48
        chObjectAffected.Text = "Affected by Others"
        chObjectAffected.UseVisualStyleBackColor = True
        ' 
        ' chObjectAffects
        ' 
        chObjectAffects.AutoSize = True
        chObjectAffects.Checked = True
        chObjectAffects.CheckState = System.Windows.Forms.CheckState.Checked
        chObjectAffects.Font = New Font("Arial", 9F)
        chObjectAffects.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chObjectAffects.Location = New Point(11, 731)
        chObjectAffects.Name = "chObjectAffects"
        chObjectAffects.Size = New Size(197, 31)
        chObjectAffects.TabIndex = 47
        chObjectAffects.Text = "Affects Others"
        chObjectAffects.UseVisualStyleBackColor = True
        ' 
        ' cmdObjectNumber
        ' 
        cmdObjectNumber.BackColor = SystemColors.Control
        cmdObjectNumber.FlatAppearance.BorderSize = 0
        cmdObjectNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectNumber.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectNumber.ForeColor = Color.Black
        cmdObjectNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectNumber.Location = New Point(271, 111)
        cmdObjectNumber.Name = "cmdObjectNumber"
        cmdObjectNumber.Size = New Size(35, 35)
        cmdObjectNumber.TabIndex = 3
        cmdObjectNumber.Text = "ƒ"
        cmdObjectNumber.UseVisualStyleBackColor = False
        ' 
        ' lblObjectNumber
        ' 
        lblObjectNumber.AutoEllipsis = True
        lblObjectNumber.ForeColor = SystemColors.ControlText
        lblObjectNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectNumber.Location = New Point(9, 110)
        lblObjectNumber.Name = "lblObjectNumber"
        lblObjectNumber.Size = New Size(250, 35)
        lblObjectNumber.TabIndex = 205
        lblObjectNumber.Text = "Number of Objects:"
        lblObjectNumber.TextAlign = ContentAlignment.MiddleLeft
        lblObjectNumber.UseMnemonic = False
        ' 
        ' lblObjectRadius
        ' 
        lblObjectRadius.AutoEllipsis = True
        lblObjectRadius.ForeColor = SystemColors.ControlText
        lblObjectRadius.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectRadius.Location = New Point(9, 251)
        lblObjectRadius.Name = "lblObjectRadius"
        lblObjectRadius.Size = New Size(250, 35)
        lblObjectRadius.TabIndex = 143
        lblObjectRadius.Text = "Radius (m):"
        lblObjectRadius.TextAlign = ContentAlignment.MiddleLeft
        lblObjectRadius.UseMnemonic = False
        ' 
        ' cmdObjectRadius
        ' 
        cmdObjectRadius.FlatAppearance.BorderSize = 0
        cmdObjectRadius.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectRadius.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectRadius.ForeColor = Color.Black
        cmdObjectRadius.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectRadius.Location = New Point(271, 246)
        cmdObjectRadius.Name = "cmdObjectRadius"
        cmdObjectRadius.Size = New Size(35, 35)
        cmdObjectRadius.TabIndex = 9
        cmdObjectRadius.Text = "ƒ"
        cmdObjectRadius.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectTransparency
        ' 
        cmdObjectTransparency.FlatAppearance.BorderSize = 0
        cmdObjectTransparency.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectTransparency.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectTransparency.ForeColor = Color.Black
        cmdObjectTransparency.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectTransparency.Location = New Point(271, 632)
        cmdObjectTransparency.Name = "cmdObjectTransparency"
        cmdObjectTransparency.Size = New Size(35, 35)
        cmdObjectTransparency.TabIndex = 43
        cmdObjectTransparency.Text = "ƒ"
        cmdObjectTransparency.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectHighlightSharpness
        ' 
        cmdObjectHighlightSharpness.FlatAppearance.BorderSize = 0
        cmdObjectHighlightSharpness.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectHighlightSharpness.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectHighlightSharpness.ForeColor = Color.Black
        cmdObjectHighlightSharpness.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectHighlightSharpness.Location = New Point(271, 519)
        cmdObjectHighlightSharpness.Name = "cmdObjectHighlightSharpness"
        cmdObjectHighlightSharpness.Size = New Size(35, 35)
        cmdObjectHighlightSharpness.TabIndex = 39
        cmdObjectHighlightSharpness.Text = "ƒ"
        cmdObjectHighlightSharpness.UseVisualStyleBackColor = False
        ' 
        ' lblObjectSize
        ' 
        lblObjectSize.AutoEllipsis = True
        lblObjectSize.ForeColor = SystemColors.ControlText
        lblObjectSize.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectSize.Location = New Point(9, 251)
        lblObjectSize.Name = "lblObjectSize"
        lblObjectSize.Size = New Size(229, 35)
        lblObjectSize.TabIndex = 218
        lblObjectSize.Text = "Size X, Y, Z (m): "
        lblObjectSize.TextAlign = ContentAlignment.MiddleLeft
        lblObjectSize.UseMnemonic = False
        ' 
        ' cmdObjectHighlightColor
        ' 
        cmdObjectHighlightColor.FlatAppearance.BorderSize = 0
        cmdObjectHighlightColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectHighlightColor.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectHighlightColor.ForeColor = Color.Black
        cmdObjectHighlightColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectHighlightColor.Location = New Point(271, 477)
        cmdObjectHighlightColor.Name = "cmdObjectHighlightColor"
        cmdObjectHighlightColor.Size = New Size(35, 35)
        cmdObjectHighlightColor.TabIndex = 37
        cmdObjectHighlightColor.Text = "ƒ"
        cmdObjectHighlightColor.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectColor
        ' 
        cmdObjectColor.FlatAppearance.BorderSize = 0
        cmdObjectColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectColor.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectColor.ForeColor = Color.Black
        cmdObjectColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectColor.Location = New Point(271, 434)
        cmdObjectColor.Name = "cmdObjectColor"
        cmdObjectColor.Size = New Size(35, 35)
        cmdObjectColor.TabIndex = 35
        cmdObjectColor.Text = "ƒ"
        cmdObjectColor.UseVisualStyleBackColor = False
        ' 
        ' tbObjectHighlightSharpness
        ' 
        tbObjectHighlightSharpness.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        tbObjectHighlightSharpness.BackColor = SystemColors.Control
        tbObjectHighlightSharpness.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbObjectHighlightSharpness.LargeChange = 20
        tbObjectHighlightSharpness.Location = New Point(314, 519)
        tbObjectHighlightSharpness.Maximum = 200
        tbObjectHighlightSharpness.Name = "tbObjectHighlightSharpness"
        tbObjectHighlightSharpness.Size = New Size(628, 90)
        tbObjectHighlightSharpness.SmallChange = 10
        tbObjectHighlightSharpness.TabIndex = 40
        tbObjectHighlightSharpness.TickFrequency = 5
        tbObjectHighlightSharpness.TickStyle = System.Windows.Forms.TickStyle.None
        tbObjectHighlightSharpness.Value = 50
        ' 
        ' cmdObjectCharge
        ' 
        cmdObjectCharge.FlatAppearance.BorderSize = 0
        cmdObjectCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectCharge.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectCharge.ForeColor = Color.Black
        cmdObjectCharge.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectCharge.Location = New Point(271, 201)
        cmdObjectCharge.Name = "cmdObjectCharge"
        cmdObjectCharge.Size = New Size(35, 35)
        cmdObjectCharge.TabIndex = 7
        cmdObjectCharge.Text = "ƒ"
        cmdObjectCharge.UseVisualStyleBackColor = False
        ' 
        ' cmdObjectMass
        ' 
        cmdObjectMass.FlatAppearance.BorderSize = 0
        cmdObjectMass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmdObjectMass.Font = New Font("Arial", 8.25F, FontStyle.Bold)
        cmdObjectMass.ForeColor = Color.Black
        cmdObjectMass.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdObjectMass.Location = New Point(271, 156)
        cmdObjectMass.Name = "cmdObjectMass"
        cmdObjectMass.Size = New Size(35, 35)
        cmdObjectMass.TabIndex = 5
        cmdObjectMass.Text = "ƒ"
        cmdObjectMass.UseVisualStyleBackColor = False
        ' 
        ' txtObjectNumber
        ' 
        txtObjectNumber.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectNumber.Enabled = False
        txtObjectNumber.ForeColor = SystemColors.ControlText
        txtObjectNumber.Location = New Point(312, 111)
        txtObjectNumber.Name = "txtObjectNumber"
        txtObjectNumber.Size = New Size(630, 35)
        txtObjectNumber.TabIndex = 4
        txtObjectNumber.Text = "0"
        txtObjectNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' lblObjectHighlightColor
        ' 
        lblObjectHighlightColor.AutoEllipsis = True
        lblObjectHighlightColor.ForeColor = SystemColors.ControlText
        lblObjectHighlightColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectHighlightColor.Location = New Point(11, 477)
        lblObjectHighlightColor.Name = "lblObjectHighlightColor"
        lblObjectHighlightColor.Size = New Size(250, 35)
        lblObjectHighlightColor.TabIndex = 161
        lblObjectHighlightColor.Text = "Highlight Color: "
        lblObjectHighlightColor.TextAlign = ContentAlignment.MiddleLeft
        lblObjectHighlightColor.UseMnemonic = False
        ' 
        ' txtObjectCharge
        ' 
        txtObjectCharge.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectCharge.ForeColor = SystemColors.ControlText
        txtObjectCharge.Location = New Point(312, 201)
        txtObjectCharge.Name = "txtObjectCharge"
        txtObjectCharge.Size = New Size(630, 35)
        txtObjectCharge.TabIndex = 8
        txtObjectCharge.Text = "0"
        txtObjectCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' lblObjectName
        ' 
        lblObjectName.AutoEllipsis = True
        lblObjectName.ForeColor = SystemColors.ControlText
        lblObjectName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectName.Location = New Point(9, 20)
        lblObjectName.Name = "lblObjectName"
        lblObjectName.Size = New Size(250, 35)
        lblObjectName.TabIndex = 140
        lblObjectName.Text = "Name of Objects: "
        lblObjectName.TextAlign = ContentAlignment.MiddleLeft
        lblObjectName.UseMnemonic = False
        ' 
        ' txtObjectMass
        ' 
        txtObjectMass.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectMass.ForeColor = SystemColors.ControlText
        txtObjectMass.Location = New Point(312, 156)
        txtObjectMass.Name = "txtObjectMass"
        txtObjectMass.Size = New Size(630, 35)
        txtObjectMass.TabIndex = 6
        txtObjectMass.Text = "0"
        txtObjectMass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' lblObjectTransparency
        ' 
        lblObjectTransparency.AutoEllipsis = True
        lblObjectTransparency.ForeColor = SystemColors.ControlText
        lblObjectTransparency.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectTransparency.Location = New Point(11, 627)
        lblObjectTransparency.Name = "lblObjectTransparency"
        lblObjectTransparency.Size = New Size(238, 35)
        lblObjectTransparency.TabIndex = 149
        lblObjectTransparency.Text = "Transparency:"
        lblObjectTransparency.TextAlign = ContentAlignment.MiddleLeft
        lblObjectTransparency.UseMnemonic = False
        ' 
        ' txtObjectName
        ' 
        txtObjectName.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtObjectName.ForeColor = SystemColors.ControlText
        txtObjectName.Location = New Point(312, 21)
        txtObjectName.Name = "txtObjectName"
        txtObjectName.Size = New Size(630, 35)
        txtObjectName.TabIndex = 1
        txtObjectName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' lblObjectMass
        ' 
        lblObjectMass.AutoEllipsis = True
        lblObjectMass.ForeColor = SystemColors.ControlText
        lblObjectMass.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectMass.Location = New Point(9, 155)
        lblObjectMass.Name = "lblObjectMass"
        lblObjectMass.Size = New Size(238, 35)
        lblObjectMass.TabIndex = 141
        lblObjectMass.Text = "Mass (kg): "
        lblObjectMass.TextAlign = ContentAlignment.MiddleLeft
        lblObjectMass.UseMnemonic = False
        ' 
        ' lblObjectCharge
        ' 
        lblObjectCharge.AutoEllipsis = True
        lblObjectCharge.ForeColor = SystemColors.ControlText
        lblObjectCharge.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectCharge.Location = New Point(9, 200)
        lblObjectCharge.Name = "lblObjectCharge"
        lblObjectCharge.Size = New Size(238, 35)
        lblObjectCharge.TabIndex = 142
        lblObjectCharge.Text = "Charge (C): "
        lblObjectCharge.TextAlign = ContentAlignment.MiddleLeft
        lblObjectCharge.UseMnemonic = False
        ' 
        ' lblObjectHighlightSharpness
        ' 
        lblObjectHighlightSharpness.AutoEllipsis = True
        lblObjectHighlightSharpness.ForeColor = SystemColors.ControlText
        lblObjectHighlightSharpness.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectHighlightSharpness.Location = New Point(11, 527)
        lblObjectHighlightSharpness.Name = "lblObjectHighlightSharpness"
        lblObjectHighlightSharpness.Size = New Size(250, 35)
        lblObjectHighlightSharpness.TabIndex = 164
        lblObjectHighlightSharpness.Text = "Highlight Sharpness: "
        lblObjectHighlightSharpness.TextAlign = ContentAlignment.MiddleLeft
        lblObjectHighlightSharpness.UseMnemonic = False
        ' 
        ' lblObjectColor
        ' 
        lblObjectColor.AutoEllipsis = True
        lblObjectColor.ForeColor = SystemColors.ControlText
        lblObjectColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectColor.Location = New Point(11, 437)
        lblObjectColor.Name = "lblObjectColor"
        lblObjectColor.Size = New Size(229, 35)
        lblObjectColor.TabIndex = 146
        lblObjectColor.Text = "Color: "
        lblObjectColor.TextAlign = ContentAlignment.MiddleLeft
        lblObjectColor.UseMnemonic = False
        ' 
        ' lblObjectVelocity
        ' 
        lblObjectVelocity.AutoEllipsis = True
        lblObjectVelocity.ForeColor = SystemColors.ControlText
        lblObjectVelocity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectVelocity.Location = New Point(9, 392)
        lblObjectVelocity.Name = "lblObjectVelocity"
        lblObjectVelocity.Size = New Size(250, 35)
        lblObjectVelocity.TabIndex = 145
        lblObjectVelocity.Text = "Velocity X,Y,Z (m/s): "
        lblObjectVelocity.TextAlign = ContentAlignment.MiddleLeft
        lblObjectVelocity.UseMnemonic = False
        ' 
        ' lblObjectPosition
        ' 
        lblObjectPosition.AutoEllipsis = True
        lblObjectPosition.ForeColor = SystemColors.ControlText
        lblObjectPosition.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblObjectPosition.Location = New Point(9, 343)
        lblObjectPosition.Name = "lblObjectPosition"
        lblObjectPosition.Size = New Size(239, 35)
        lblObjectPosition.TabIndex = 144
        lblObjectPosition.Text = "Position X,Y,Z  (m):"
        lblObjectPosition.TextAlign = ContentAlignment.MiddleLeft
        lblObjectPosition.UseMnemonic = False
        ' 
        ' cmdGroupAdd
        ' 
        cmdGroupAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cmdGroupAdd.FlatAppearance.BorderColor = Color.Black
        cmdGroupAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        cmdGroupAdd.ForeColor = SystemColors.ControlText
        cmdGroupAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdGroupAdd.Location = New Point(3, 1188)
        cmdGroupAdd.Name = "cmdGroupAdd"
        cmdGroupAdd.Size = New Size(964, 62)
        cmdGroupAdd.TabIndex = 0
        cmdGroupAdd.Text = "Add Objects"
        cmdGroupAdd.UseVisualStyleBackColor = True
        ' 
        ' TabLights
        ' 
        TabLights.BackColor = SystemColors.Control
        TabLights.Controls.Add(TableLayoutPanel8)
        TabLights.Controls.Add(gbLights)
        TabLights.Controls.Add(cmdLightAdd)
        TabLights.Location = New Point(4, 39)
        TabLights.Name = "TabLights"
        TabLights.Size = New Size(973, 1321)
        TabLights.TabIndex = 2
        TabLights.Text = "Lighting"
        TabLights.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel8
        ' 
        TableLayoutPanel8.ColumnCount = 2
        TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        TableLayoutPanel8.Controls.Add(cmdLightRemove, 1, 0)
        TableLayoutPanel8.Controls.Add(cmdLightReplace, 0, 0)
        TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Bottom
        TableLayoutPanel8.Location = New Point(0, 1253)
        TableLayoutPanel8.Name = "TableLayoutPanel8"
        TableLayoutPanel8.RowCount = 1
        TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        TableLayoutPanel8.Size = New Size(973, 68)
        TableLayoutPanel8.TabIndex = 66
        ' 
        ' cmdLightRemove
        ' 
        cmdLightRemove.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cmdLightRemove.BackColor = Color.FromArgb(CByte(235), CByte(235), CByte(235))
        cmdLightRemove.Enabled = False
        cmdLightRemove.FlatAppearance.BorderColor = Color.Black
        cmdLightRemove.FlatStyle = System.Windows.Forms.FlatStyle.System
        cmdLightRemove.ForeColor = SystemColors.ControlText
        cmdLightRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdLightRemove.Location = New Point(489, 3)
        cmdLightRemove.Name = "cmdLightRemove"
        cmdLightRemove.Size = New Size(481, 62)
        cmdLightRemove.TabIndex = 2
        cmdLightRemove.Text = "Remove Light"
        cmdLightRemove.UseVisualStyleBackColor = False
        ' 
        ' cmdLightReplace
        ' 
        cmdLightReplace.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cmdLightReplace.BackColor = Color.FromArgb(CByte(235), CByte(235), CByte(235))
        cmdLightReplace.Enabled = False
        cmdLightReplace.FlatAppearance.BorderColor = Color.Black
        cmdLightReplace.FlatStyle = System.Windows.Forms.FlatStyle.System
        cmdLightReplace.ForeColor = SystemColors.ControlText
        cmdLightReplace.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdLightReplace.Location = New Point(3, 3)
        cmdLightReplace.Name = "cmdLightReplace"
        cmdLightReplace.Size = New Size(480, 62)
        cmdLightReplace.TabIndex = 1
        cmdLightReplace.Text = "Replace Light"
        cmdLightReplace.UseVisualStyleBackColor = False
        ' 
        ' gbLights
        ' 
        gbLights.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        gbLights.Controls.Add(Panel1)
        gbLights.Controls.Add(listLights)
        gbLights.Controls.Add(chLightsEnable)
        gbLights.Location = New Point(6, 3)
        gbLights.Name = "gbLights"
        gbLights.Size = New Size(961, 1179)
        gbLights.TabIndex = 65
        gbLights.TabStop = False
        gbLights.Text = "Lights"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Panel1.AutoScroll = True
        Panel1.Controls.Add(TableLayoutPanel12)
        Panel1.Controls.Add(TableLayoutPanel11)
        Panel1.Controls.Add(txtLightRange)
        Panel1.Controls.Add(tbLightAmbient)
        Panel1.Controls.Add(TableLayoutPanel10)
        Panel1.Controls.Add(TableLayoutPanel9)
        Panel1.Controls.Add(plLightColor)
        Panel1.Controls.Add(cbLightType)
        Panel1.Controls.Add(tbLightHighlight)
        Panel1.Controls.Add(lblLightColor)
        Panel1.Controls.Add(lblLightAttenuation)
        Panel1.Controls.Add(lblLightDirection)
        Panel1.Controls.Add(lblLightRange)
        Panel1.Controls.Add(lblLightName)
        Panel1.Controls.Add(lblLightFalloff)
        Panel1.Controls.Add(txtLightName)
        Panel1.Controls.Add(txtLightFalloff)
        Panel1.Controls.Add(lblLightAngle)
        Panel1.Controls.Add(lblLightPosition)
        Panel1.Controls.Add(lblLightAmbient)
        Panel1.Controls.Add(lblLightHighlight)
        Panel1.Controls.Add(lblLightType)
        Panel1.Location = New Point(0, 247)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(958, 926)
        Panel1.TabIndex = 115
        ' 
        ' TableLayoutPanel12
        ' 
        TableLayoutPanel12.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel12.ColumnCount = 2
        TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel12.Controls.Add(txtLightAngleInner, 0, 0)
        TableLayoutPanel12.Controls.Add(txtLightAngleOuter, 1, 0)
        TableLayoutPanel12.Location = New Point(325, 459)
        TableLayoutPanel12.Name = "TableLayoutPanel12"
        TableLayoutPanel12.RowCount = 1
        TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        TableLayoutPanel12.Size = New Size(620, 46)
        TableLayoutPanel12.TabIndex = 118
        ' 
        ' txtLightAngleInner
        ' 
        txtLightAngleInner.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightAngleInner.ForeColor = SystemColors.ControlText
        txtLightAngleInner.Location = New Point(3, 3)
        txtLightAngleInner.Name = "txtLightAngleInner"
        txtLightAngleInner.Size = New Size(304, 35)
        txtLightAngleInner.TabIndex = 17
        txtLightAngleInner.Text = "45"
        txtLightAngleInner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtLightAngleOuter
        ' 
        txtLightAngleOuter.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightAngleOuter.ForeColor = SystemColors.ControlText
        txtLightAngleOuter.Location = New Point(313, 3)
        txtLightAngleOuter.Name = "txtLightAngleOuter"
        txtLightAngleOuter.Size = New Size(304, 35)
        txtLightAngleOuter.TabIndex = 18
        txtLightAngleOuter.Text = "45"
        txtLightAngleOuter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' TableLayoutPanel11
        ' 
        TableLayoutPanel11.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel11.ColumnCount = 3
        TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel11.Controls.Add(txtLightAttenuationA, 0, 0)
        TableLayoutPanel11.Controls.Add(txtLightAttenuationB, 1, 0)
        TableLayoutPanel11.Controls.Add(txtLightAttenuationC, 2, 0)
        TableLayoutPanel11.Location = New Point(325, 404)
        TableLayoutPanel11.Name = "TableLayoutPanel11"
        TableLayoutPanel11.RowCount = 1
        TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        TableLayoutPanel11.Size = New Size(620, 49)
        TableLayoutPanel11.TabIndex = 117
        ' 
        ' txtLightAttenuationA
        ' 
        txtLightAttenuationA.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightAttenuationA.ForeColor = SystemColors.ControlText
        txtLightAttenuationA.Location = New Point(3, 3)
        txtLightAttenuationA.Name = "txtLightAttenuationA"
        txtLightAttenuationA.Size = New Size(200, 35)
        txtLightAttenuationA.TabIndex = 14
        txtLightAttenuationA.Text = "0"
        txtLightAttenuationA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtLightAttenuationB
        ' 
        txtLightAttenuationB.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightAttenuationB.ForeColor = SystemColors.ControlText
        txtLightAttenuationB.Location = New Point(209, 3)
        txtLightAttenuationB.Name = "txtLightAttenuationB"
        txtLightAttenuationB.Size = New Size(200, 35)
        txtLightAttenuationB.TabIndex = 15
        txtLightAttenuationB.Text = "0"
        txtLightAttenuationB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtLightAttenuationC
        ' 
        txtLightAttenuationC.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightAttenuationC.ForeColor = SystemColors.ControlText
        txtLightAttenuationC.Location = New Point(415, 3)
        txtLightAttenuationC.Name = "txtLightAttenuationC"
        txtLightAttenuationC.Size = New Size(202, 35)
        txtLightAttenuationC.TabIndex = 16
        txtLightAttenuationC.Text = "0"
        txtLightAttenuationC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtLightRange
        ' 
        txtLightRange.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightRange.ForeColor = SystemColors.ControlText
        txtLightRange.Location = New Point(325, 360)
        txtLightRange.Name = "txtLightRange"
        txtLightRange.Size = New Size(620, 35)
        txtLightRange.TabIndex = 13
        txtLightRange.Text = "45"
        txtLightRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' tbLightAmbient
        ' 
        tbLightAmbient.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        tbLightAmbient.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbLightAmbient.LargeChange = 15
        tbLightAmbient.Location = New Point(325, 299)
        tbLightAmbient.Maximum = 100
        tbLightAmbient.Name = "tbLightAmbient"
        tbLightAmbient.Size = New Size(620, 90)
        tbLightAmbient.SmallChange = 15
        tbLightAmbient.TabIndex = 12
        tbLightAmbient.TickFrequency = 5
        tbLightAmbient.TickStyle = System.Windows.Forms.TickStyle.None
        tbLightAmbient.Value = 10
        ' 
        ' TableLayoutPanel10
        ' 
        TableLayoutPanel10.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel10.ColumnCount = 3
        TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel10.Controls.Add(txtLightDirectionX, 0, 0)
        TableLayoutPanel10.Controls.Add(txtLightDirectionY, 1, 0)
        TableLayoutPanel10.Controls.Add(txtLightDirectionZ, 2, 0)
        TableLayoutPanel10.Location = New Point(325, 157)
        TableLayoutPanel10.Name = "TableLayoutPanel10"
        TableLayoutPanel10.RowCount = 1
        TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        TableLayoutPanel10.Size = New Size(620, 47)
        TableLayoutPanel10.TabIndex = 116
        ' 
        ' txtLightDirectionX
        ' 
        txtLightDirectionX.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightDirectionX.ForeColor = SystemColors.ControlText
        txtLightDirectionX.Location = New Point(3, 3)
        txtLightDirectionX.Name = "txtLightDirectionX"
        txtLightDirectionX.Size = New Size(200, 35)
        txtLightDirectionX.TabIndex = 7
        txtLightDirectionX.Text = "0"
        txtLightDirectionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtLightDirectionY
        ' 
        txtLightDirectionY.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightDirectionY.ForeColor = SystemColors.ControlText
        txtLightDirectionY.Location = New Point(209, 3)
        txtLightDirectionY.Name = "txtLightDirectionY"
        txtLightDirectionY.Size = New Size(200, 35)
        txtLightDirectionY.TabIndex = 8
        txtLightDirectionY.Text = "0"
        txtLightDirectionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtLightDirectionZ
        ' 
        txtLightDirectionZ.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightDirectionZ.ForeColor = SystemColors.ControlText
        txtLightDirectionZ.Location = New Point(415, 3)
        txtLightDirectionZ.Name = "txtLightDirectionZ"
        txtLightDirectionZ.Size = New Size(202, 35)
        txtLightDirectionZ.TabIndex = 9
        txtLightDirectionZ.Text = "0"
        txtLightDirectionZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' TableLayoutPanel9
        ' 
        TableLayoutPanel9.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel9.ColumnCount = 3
        TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel9.Controls.Add(txtLightPositionX, 0, 0)
        TableLayoutPanel9.Controls.Add(txtLightPositionY, 1, 0)
        TableLayoutPanel9.Controls.Add(txtLightPositionZ, 2, 0)
        TableLayoutPanel9.Location = New Point(325, 104)
        TableLayoutPanel9.Name = "TableLayoutPanel9"
        TableLayoutPanel9.RowCount = 1
        TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        TableLayoutPanel9.Size = New Size(620, 47)
        TableLayoutPanel9.TabIndex = 115
        ' 
        ' txtLightPositionX
        ' 
        txtLightPositionX.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightPositionX.ForeColor = SystemColors.ControlText
        txtLightPositionX.Location = New Point(3, 3)
        txtLightPositionX.Name = "txtLightPositionX"
        txtLightPositionX.Size = New Size(200, 35)
        txtLightPositionX.TabIndex = 4
        txtLightPositionX.Text = "0"
        txtLightPositionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtLightPositionY
        ' 
        txtLightPositionY.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightPositionY.ForeColor = SystemColors.ControlText
        txtLightPositionY.Location = New Point(209, 3)
        txtLightPositionY.Name = "txtLightPositionY"
        txtLightPositionY.Size = New Size(200, 35)
        txtLightPositionY.TabIndex = 5
        txtLightPositionY.Text = "0"
        txtLightPositionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtLightPositionZ
        ' 
        txtLightPositionZ.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightPositionZ.ForeColor = SystemColors.ControlText
        txtLightPositionZ.Location = New Point(415, 3)
        txtLightPositionZ.Name = "txtLightPositionZ"
        txtLightPositionZ.Size = New Size(202, 35)
        txtLightPositionZ.TabIndex = 6
        txtLightPositionZ.Text = "0"
        txtLightPositionZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' plLightColor
        ' 
        plLightColor.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        plLightColor.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plLightColor.FlatAppearance.BorderColor = Color.Black
        plLightColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plLightColor.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        plLightColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plLightColor.Location = New Point(325, 210)
        plLightColor.Name = "plLightColor"
        plLightColor.Size = New Size(620, 32)
        plLightColor.TabIndex = 10
        plLightColor.UseVisualStyleBackColor = False
        ' 
        ' cbLightType
        ' 
        cbLightType.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cbLightType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cbLightType.FormattingEnabled = True
        cbLightType.Items.AddRange(New Object() {"Directional", "Point", "Spot"})
        cbLightType.Location = New Point(325, 61)
        cbLightType.Name = "cbLightType"
        cbLightType.Size = New Size(620, 35)
        cbLightType.TabIndex = 3
        ' 
        ' tbLightHighlight
        ' 
        tbLightHighlight.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        tbLightHighlight.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbLightHighlight.LargeChange = 15
        tbLightHighlight.Location = New Point(325, 257)
        tbLightHighlight.Maximum = 255
        tbLightHighlight.Name = "tbLightHighlight"
        tbLightHighlight.Size = New Size(620, 90)
        tbLightHighlight.SmallChange = 5
        tbLightHighlight.TabIndex = 11
        tbLightHighlight.TickFrequency = 5
        tbLightHighlight.TickStyle = System.Windows.Forms.TickStyle.None
        tbLightHighlight.Value = 50
        ' 
        ' lblLightColor
        ' 
        lblLightColor.AutoEllipsis = True
        lblLightColor.ForeColor = SystemColors.ControlText
        lblLightColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblLightColor.Location = New Point(12, 207)
        lblLightColor.Name = "lblLightColor"
        lblLightColor.Size = New Size(307, 35)
        lblLightColor.TabIndex = 89
        lblLightColor.Text = "Color: "
        lblLightColor.TextAlign = ContentAlignment.MiddleLeft
        lblLightColor.UseMnemonic = False
        ' 
        ' lblLightAttenuation
        ' 
        lblLightAttenuation.AutoEllipsis = True
        lblLightAttenuation.ForeColor = SystemColors.ControlText
        lblLightAttenuation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblLightAttenuation.Location = New Point(12, 408)
        lblLightAttenuation.Name = "lblLightAttenuation"
        lblLightAttenuation.Size = New Size(307, 35)
        lblLightAttenuation.TabIndex = 114
        lblLightAttenuation.Text = "Attenuation A, B, C:"
        lblLightAttenuation.TextAlign = ContentAlignment.MiddleLeft
        lblLightAttenuation.UseMnemonic = False
        ' 
        ' lblLightDirection
        ' 
        lblLightDirection.AutoEllipsis = True
        lblLightDirection.ForeColor = SystemColors.ControlText
        lblLightDirection.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblLightDirection.Location = New Point(12, 160)
        lblLightDirection.Name = "lblLightDirection"
        lblLightDirection.Size = New Size(307, 35)
        lblLightDirection.TabIndex = 88
        lblLightDirection.Text = "Direction X,Y,Z:"
        lblLightDirection.TextAlign = ContentAlignment.MiddleLeft
        lblLightDirection.UseMnemonic = False
        ' 
        ' lblLightRange
        ' 
        lblLightRange.AutoEllipsis = True
        lblLightRange.ForeColor = SystemColors.ControlText
        lblLightRange.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblLightRange.Location = New Point(12, 360)
        lblLightRange.Name = "lblLightRange"
        lblLightRange.Size = New Size(307, 35)
        lblLightRange.TabIndex = 112
        lblLightRange.Text = "Range (m): "
        lblLightRange.TextAlign = ContentAlignment.MiddleLeft
        lblLightRange.UseMnemonic = False
        ' 
        ' lblLightName
        ' 
        lblLightName.AutoEllipsis = True
        lblLightName.BackColor = Color.Transparent
        lblLightName.ForeColor = SystemColors.ControlText
        lblLightName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblLightName.Location = New Point(12, 18)
        lblLightName.Name = "lblLightName"
        lblLightName.Size = New Size(307, 35)
        lblLightName.TabIndex = 87
        lblLightName.Text = "Name: "
        lblLightName.TextAlign = ContentAlignment.MiddleLeft
        lblLightName.UseMnemonic = False
        ' 
        ' lblLightFalloff
        ' 
        lblLightFalloff.AutoEllipsis = True
        lblLightFalloff.ForeColor = SystemColors.ControlText
        lblLightFalloff.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblLightFalloff.Location = New Point(12, 511)
        lblLightFalloff.Name = "lblLightFalloff"
        lblLightFalloff.Size = New Size(307, 35)
        lblLightFalloff.TabIndex = 110
        lblLightFalloff.Text = "Inner to Outer Falloff: "
        lblLightFalloff.TextAlign = ContentAlignment.MiddleLeft
        lblLightFalloff.UseMnemonic = False
        ' 
        ' txtLightName
        ' 
        txtLightName.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightName.ForeColor = SystemColors.ControlText
        txtLightName.Location = New Point(325, 12)
        txtLightName.Name = "txtLightName"
        txtLightName.Size = New Size(620, 35)
        txtLightName.TabIndex = 2
        txtLightName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtLightFalloff
        ' 
        txtLightFalloff.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLightFalloff.ForeColor = SystemColors.ControlText
        txtLightFalloff.Location = New Point(325, 506)
        txtLightFalloff.Name = "txtLightFalloff"
        txtLightFalloff.Size = New Size(620, 35)
        txtLightFalloff.TabIndex = 19
        txtLightFalloff.Text = "1"
        txtLightFalloff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' lblLightAngle
        ' 
        lblLightAngle.AutoEllipsis = True
        lblLightAngle.ForeColor = SystemColors.ControlText
        lblLightAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblLightAngle.Location = New Point(12, 462)
        lblLightAngle.Name = "lblLightAngle"
        lblLightAngle.Size = New Size(307, 35)
        lblLightAngle.TabIndex = 108
        lblLightAngle.Text = "Inner, Outer Angle (°): "
        lblLightAngle.TextAlign = ContentAlignment.MiddleLeft
        lblLightAngle.UseMnemonic = False
        ' 
        ' lblLightPosition
        ' 
        lblLightPosition.AutoEllipsis = True
        lblLightPosition.ForeColor = SystemColors.ControlText
        lblLightPosition.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblLightPosition.Location = New Point(12, 107)
        lblLightPosition.Name = "lblLightPosition"
        lblLightPosition.Size = New Size(307, 35)
        lblLightPosition.TabIndex = 97
        lblLightPosition.Text = "Position X,Y,Z  (m):"
        lblLightPosition.TextAlign = ContentAlignment.MiddleLeft
        lblLightPosition.UseMnemonic = False
        ' 
        ' lblLightAmbient
        ' 
        lblLightAmbient.AutoEllipsis = True
        lblLightAmbient.ForeColor = SystemColors.ControlText
        lblLightAmbient.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblLightAmbient.Location = New Point(12, 309)
        lblLightAmbient.Name = "lblLightAmbient"
        lblLightAmbient.Size = New Size(307, 35)
        lblLightAmbient.TabIndex = 103
        lblLightAmbient.Text = "Ambient Lighting: "
        lblLightAmbient.TextAlign = ContentAlignment.MiddleLeft
        lblLightAmbient.UseMnemonic = False
        ' 
        ' lblLightHighlight
        ' 
        lblLightHighlight.AutoEllipsis = True
        lblLightHighlight.ForeColor = SystemColors.ControlText
        lblLightHighlight.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblLightHighlight.Location = New Point(12, 257)
        lblLightHighlight.Name = "lblLightHighlight"
        lblLightHighlight.Size = New Size(307, 35)
        lblLightHighlight.TabIndex = 105
        lblLightHighlight.Text = "Highlight Intensity: "
        lblLightHighlight.TextAlign = ContentAlignment.MiddleLeft
        lblLightHighlight.UseMnemonic = False
        ' 
        ' lblLightType
        ' 
        lblLightType.AutoEllipsis = True
        lblLightType.ForeColor = SystemColors.ControlText
        lblLightType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblLightType.Location = New Point(12, 60)
        lblLightType.Name = "lblLightType"
        lblLightType.Size = New Size(307, 35)
        lblLightType.TabIndex = 101
        lblLightType.Text = "Type of Light: "
        lblLightType.TextAlign = ContentAlignment.MiddleLeft
        lblLightType.UseMnemonic = False
        ' 
        ' listLights
        ' 
        listLights.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        listLights.Font = New Font("Arial", 9F)
        listLights.ForeColor = SystemColors.ControlText
        listLights.ItemHeight = 27
        listLights.Location = New Point(12, 75)
        listLights.MinimumSize = New Size(0, 120)
        listLights.Name = "listLights"
        listLights.Size = New Size(933, 166)
        listLights.TabIndex = 1
        ' 
        ' chLightsEnable
        ' 
        chLightsEnable.AutoEllipsis = True
        chLightsEnable.CheckAlign = ContentAlignment.MiddleCenter
        chLightsEnable.Checked = True
        chLightsEnable.CheckState = System.Windows.Forms.CheckState.Checked
        chLightsEnable.FlatStyle = System.Windows.Forms.FlatStyle.System
        chLightsEnable.ForeColor = SystemColors.ControlText
        chLightsEnable.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chLightsEnable.Location = New Point(12, 34)
        chLightsEnable.Name = "chLightsEnable"
        chLightsEnable.Size = New Size(347, 35)
        chLightsEnable.TabIndex = 0
        chLightsEnable.Text = "Enable Lighting"
        chLightsEnable.UseMnemonic = False
        chLightsEnable.UseVisualStyleBackColor = True
        ' 
        ' cmdLightAdd
        ' 
        cmdLightAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cmdLightAdd.BackColor = Color.FromArgb(CByte(235), CByte(235), CByte(235))
        cmdLightAdd.FlatAppearance.BorderColor = Color.Black
        cmdLightAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        cmdLightAdd.ForeColor = SystemColors.ControlText
        cmdLightAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdLightAdd.Location = New Point(3, 1188)
        cmdLightAdd.Name = "cmdLightAdd"
        cmdLightAdd.Size = New Size(967, 62)
        cmdLightAdd.TabIndex = 0
        cmdLightAdd.Text = "Add Light"
        cmdLightAdd.UseVisualStyleBackColor = False
        ' 
        ' TabDisplay
        ' 
        TabDisplay.BackColor = SystemColors.Control
        TabDisplay.Controls.Add(spRendering)
        TabDisplay.Controls.Add(CmdSaveOut)
        TabDisplay.Location = New Point(4, 39)
        TabDisplay.Name = "TabDisplay"
        TabDisplay.Size = New Size(973, 1321)
        TabDisplay.TabIndex = 6
        TabDisplay.Text = "Rendering"
        TabDisplay.UseVisualStyleBackColor = True
        ' 
        ' spRendering
        ' 
        spRendering.Dock = System.Windows.Forms.DockStyle.Fill
        spRendering.Location = New Point(0, 0)
        spRendering.Name = "spRendering"
        spRendering.Orientation = System.Windows.Forms.Orientation.Horizontal
        ' 
        ' spRendering.Panel1
        ' 
        spRendering.Panel1.Controls.Add(gbRendering)
        ' 
        ' spRendering.Panel2
        ' 
        spRendering.Panel2.Controls.Add(gbCamera)
        spRendering.Size = New Size(973, 1259)
        spRendering.SplitterDistance = 740
        spRendering.TabIndex = 92
        ' 
        ' gbRendering
        ' 
        gbRendering.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        gbRendering.Controls.Add(pRender)
        gbRendering.Location = New Point(3, 3)
        gbRendering.Name = "gbRendering"
        gbRendering.Size = New Size(967, 732)
        gbRendering.TabIndex = 90
        gbRendering.TabStop = False
        gbRendering.Text = "Render"
        ' 
        ' pRender
        ' 
        pRender.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        pRender.AutoScroll = True
        pRender.Controls.Add(chVSync)
        pRender.Controls.Add(TableLayoutPanel3)
        pRender.Controls.Add(Label45)
        pRender.Controls.Add(Label3)
        pRender.Controls.Add(Label30)
        pRender.Controls.Add(tbPolys)
        pRender.Controls.Add(Label12)
        pRender.Controls.Add(txtRenderThreads)
        pRender.Controls.Add(cbShading)
        pRender.Controls.Add(Label18)
        pRender.Controls.Add(Label46)
        pRender.Controls.Add(Label43)
        pRender.Controls.Add(Label13)
        pRender.Controls.Add(txtHFoV)
        pRender.Controls.Add(txtVFoV)
        pRender.Controls.Add(txtMaxFPS)
        pRender.Controls.Add(chTrace)
        pRender.Controls.Add(Label44)
        pRender.Controls.Add(plRenderBackColor)
        pRender.Controls.Add(cbRender)
        pRender.Location = New Point(6, 29)
        pRender.Name = "pRender"
        pRender.Size = New Size(955, 695)
        pRender.TabIndex = 0
        ' 
        ' chVSync
        ' 
        chVSync.AutoEllipsis = True
        chVSync.FlatStyle = System.Windows.Forms.FlatStyle.System
        chVSync.ForeColor = SystemColors.ControlText
        chVSync.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chVSync.Location = New Point(9, 442)
        chVSync.Name = "chVSync"
        chVSync.Size = New Size(548, 35)
        chVSync.TabIndex = 10
        chVSync.Text = "Synchronize Frame Rate to Monitor (vsync)"
        chVSync.UseMnemonic = False
        chVSync.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel3.ColumnCount = 2
        TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        TableLayoutPanel3.Controls.Add(txtWindowX, 0, 0)
        TableLayoutPanel3.Controls.Add(txtWindowY, 1, 0)
        TableLayoutPanel3.Location = New Point(376, 103)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        TableLayoutPanel3.Size = New Size(573, 44)
        TableLayoutPanel3.TabIndex = 246
        ' 
        ' txtWindowX
        ' 
        txtWindowX.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtWindowX.ForeColor = SystemColors.ControlText
        txtWindowX.Location = New Point(3, 3)
        txtWindowX.Name = "txtWindowX"
        txtWindowX.Size = New Size(280, 35)
        txtWindowX.TabIndex = 2
        txtWindowX.Text = "500"
        txtWindowX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtWindowY
        ' 
        txtWindowY.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtWindowY.ForeColor = SystemColors.ControlText
        txtWindowY.Location = New Point(289, 3)
        txtWindowY.Name = "txtWindowY"
        txtWindowY.Size = New Size(281, 35)
        txtWindowY.TabIndex = 3
        txtWindowY.Text = "500"
        txtWindowY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' Label45
        ' 
        Label45.AutoEllipsis = True
        Label45.ForeColor = SystemColors.ControlText
        Label45.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label45.Location = New Point(9, 13)
        Label45.Name = "Label45"
        Label45.Size = New Size(345, 35)
        Label45.TabIndex = 126
        Label45.Text = "Render Mode: "
        Label45.TextAlign = ContentAlignment.MiddleLeft
        Label45.UseMnemonic = False
        ' 
        ' Label3
        ' 
        Label3.AutoEllipsis = True
        Label3.ForeColor = SystemColors.ControlText
        Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label3.Location = New Point(9, 58)
        Label3.Name = "Label3"
        Label3.Size = New Size(348, 35)
        Label3.TabIndex = 245
        Label3.Text = "Render Thread Count: "
        Label3.TextAlign = ContentAlignment.MiddleLeft
        Label3.UseMnemonic = False
        ' 
        ' Label30
        ' 
        Label30.AutoEllipsis = True
        Label30.ForeColor = SystemColors.ControlText
        Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label30.Location = New Point(9, 345)
        Label30.Name = "Label30"
        Label30.Size = New Size(305, 35)
        Label30.TabIndex = 117
        Label30.Text = "Sphere Polygon Count: "
        Label30.TextAlign = ContentAlignment.MiddleLeft
        Label30.UseMnemonic = False
        ' 
        ' tbPolys
        ' 
        tbPolys.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        tbPolys.BackColor = SystemColors.Control
        tbPolys.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbPolys.LargeChange = 10
        tbPolys.Location = New Point(376, 346)
        tbPolys.Maximum = 100
        tbPolys.Minimum = 2
        tbPolys.Name = "tbPolys"
        tbPolys.Size = New Size(570, 90)
        tbPolys.TabIndex = 8
        tbPolys.TickFrequency = 5
        tbPolys.TickStyle = System.Windows.Forms.TickStyle.None
        tbPolys.Value = 40
        ' 
        ' Label12
        ' 
        Label12.AutoEllipsis = True
        Label12.ForeColor = SystemColors.ControlText
        Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label12.Location = New Point(9, 102)
        Label12.Name = "Label12"
        Label12.Size = New Size(348, 35)
        Label12.TabIndex = 115
        Label12.Text = "Window Size X,Y (px): "
        Label12.TextAlign = ContentAlignment.MiddleLeft
        Label12.UseMnemonic = False
        ' 
        ' txtRenderThreads
        ' 
        txtRenderThreads.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtRenderThreads.Enabled = False
        txtRenderThreads.ForeColor = SystemColors.ControlText
        txtRenderThreads.Location = New Point(376, 59)
        txtRenderThreads.MaxLength = 4
        txtRenderThreads.Name = "txtRenderThreads"
        txtRenderThreads.Size = New Size(573, 35)
        txtRenderThreads.TabIndex = 1
        txtRenderThreads.Text = "1"
        txtRenderThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' cbShading
        ' 
        cbShading.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cbShading.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cbShading.FormattingEnabled = True
        cbShading.Items.AddRange(New Object() {"Flat", "Gouraud"})
        cbShading.Location = New Point(376, 298)
        cbShading.Name = "cbShading"
        cbShading.Size = New Size(573, 35)
        cbShading.TabIndex = 7
        ' 
        ' Label18
        ' 
        Label18.AutoEllipsis = True
        Label18.ForeColor = SystemColors.ControlText
        Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label18.Location = New Point(9, 155)
        Label18.Name = "Label18"
        Label18.Size = New Size(348, 35)
        Label18.TabIndex = 116
        Label18.Text = "Horizontal Field of View (°): "
        Label18.TextAlign = ContentAlignment.MiddleLeft
        Label18.UseMnemonic = False
        ' 
        ' Label46
        ' 
        Label46.AutoEllipsis = True
        Label46.ForeColor = SystemColors.ControlText
        Label46.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label46.Location = New Point(9, 204)
        Label46.Name = "Label46"
        Label46.Size = New Size(348, 35)
        Label46.TabIndex = 129
        Label46.Text = "Vertical Field of View (°): "
        Label46.TextAlign = ContentAlignment.MiddleLeft
        Label46.UseMnemonic = False
        ' 
        ' Label43
        ' 
        Label43.AutoEllipsis = True
        Label43.ForeColor = SystemColors.ControlText
        Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label43.Location = New Point(9, 296)
        Label43.Name = "Label43"
        Label43.Size = New Size(348, 35)
        Label43.TabIndex = 120
        Label43.Text = "Light Shading Mode: "
        Label43.TextAlign = ContentAlignment.MiddleLeft
        Label43.UseMnemonic = False
        ' 
        ' Label13
        ' 
        Label13.AutoEllipsis = True
        Label13.ForeColor = SystemColors.ControlText
        Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label13.Location = New Point(9, 250)
        Label13.Name = "Label13"
        Label13.Size = New Size(348, 35)
        Label13.TabIndex = 114
        Label13.Text = "Background Color: "
        Label13.TextAlign = ContentAlignment.MiddleLeft
        Label13.UseMnemonic = False
        ' 
        ' txtHFoV
        ' 
        txtHFoV.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtHFoV.ForeColor = SystemColors.ControlText
        txtHFoV.Location = New Point(376, 157)
        txtHFoV.Name = "txtHFoV"
        txtHFoV.Size = New Size(573, 35)
        txtHFoV.TabIndex = 4
        txtHFoV.Text = "45"
        txtHFoV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtVFoV
        ' 
        txtVFoV.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtVFoV.ForeColor = SystemColors.ControlText
        txtVFoV.Location = New Point(376, 206)
        txtVFoV.Name = "txtVFoV"
        txtVFoV.Size = New Size(573, 35)
        txtVFoV.TabIndex = 5
        txtVFoV.Text = "45"
        txtVFoV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtMaxFPS
        ' 
        txtMaxFPS.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtMaxFPS.ForeColor = SystemColors.ControlText
        txtMaxFPS.Location = New Point(376, 495)
        txtMaxFPS.Name = "txtMaxFPS"
        txtMaxFPS.Size = New Size(570, 35)
        txtMaxFPS.TabIndex = 11
        txtMaxFPS.Text = "45"
        txtMaxFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' chTrace
        ' 
        chTrace.AutoEllipsis = True
        chTrace.FlatStyle = System.Windows.Forms.FlatStyle.System
        chTrace.ForeColor = SystemColors.ControlText
        chTrace.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chTrace.Location = New Point(9, 391)
        chTrace.Name = "chTrace"
        chTrace.Size = New Size(345, 35)
        chTrace.TabIndex = 9
        chTrace.Text = "Trace Object Paths"
        chTrace.UseMnemonic = False
        chTrace.UseVisualStyleBackColor = True
        ' 
        ' Label44
        ' 
        Label44.AutoEllipsis = True
        Label44.ForeColor = SystemColors.ControlText
        Label44.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label44.Location = New Point(40, 493)
        Label44.Name = "Label44"
        Label44.Size = New Size(322, 35)
        Label44.TabIndex = 124
        Label44.Text = "Maximum Frame Rate (F/s): "
        Label44.TextAlign = ContentAlignment.MiddleLeft
        Label44.UseMnemonic = False
        ' 
        ' plRenderBackColor
        ' 
        plRenderBackColor.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        plRenderBackColor.BackColor = Color.Black
        plRenderBackColor.FlatAppearance.BorderColor = Color.Black
        plRenderBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        plRenderBackColor.ForeColor = Color.Black
        plRenderBackColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        plRenderBackColor.Location = New Point(376, 252)
        plRenderBackColor.Name = "plRenderBackColor"
        plRenderBackColor.Size = New Size(570, 32)
        plRenderBackColor.TabIndex = 6
        plRenderBackColor.UseVisualStyleBackColor = False
        ' 
        ' cbRender
        ' 
        cbRender.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cbRender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cbRender.FormattingEnabled = True
        cbRender.Items.AddRange(New Object() {"DirectX 9 (Hardware)", "DirectX 9 (Software)", "Raytracing (Software)"})
        cbRender.Location = New Point(376, 14)
        cbRender.Name = "cbRender"
        cbRender.Size = New Size(573, 35)
        cbRender.TabIndex = 0
        ' 
        ' gbCamera
        ' 
        gbCamera.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        gbCamera.Controls.Add(pCamera)
        gbCamera.Location = New Point(3, 3)
        gbCamera.Name = "gbCamera"
        gbCamera.Size = New Size(967, 506)
        gbCamera.TabIndex = 91
        gbCamera.TabStop = False
        gbCamera.Text = "Camera"
        ' 
        ' pCamera
        ' 
        pCamera.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        pCamera.AutoScroll = True
        pCamera.Controls.Add(TableLayoutPanel7)
        pCamera.Controls.Add(TableLayoutPanel5)
        pCamera.Controls.Add(TableLayoutPanel4)
        pCamera.Controls.Add(Label47)
        pCamera.Controls.Add(chCamera)
        pCamera.Controls.Add(tbCameraSpeed)
        pCamera.Controls.Add(Label17)
        pCamera.Controls.Add(Label11)
        pCamera.Controls.Add(Label16)
        pCamera.Location = New Point(6, 33)
        pCamera.Name = "pCamera"
        pCamera.Size = New Size(955, 464)
        pCamera.TabIndex = 0
        ' 
        ' TableLayoutPanel7
        ' 
        TableLayoutPanel7.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel7.ColumnCount = 3
        TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel7.Controls.Add(txtCOrientX, 0, 0)
        TableLayoutPanel7.Controls.Add(txtCOrientY, 1, 0)
        TableLayoutPanel7.Controls.Add(txtCOrientZ, 2, 0)
        TableLayoutPanel7.Location = New Point(376, 162)
        TableLayoutPanel7.Name = "TableLayoutPanel7"
        TableLayoutPanel7.RowCount = 1
        TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        TableLayoutPanel7.Size = New Size(576, 47)
        TableLayoutPanel7.TabIndex = 106
        ' 
        ' txtCOrientX
        ' 
        txtCOrientX.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtCOrientX.Enabled = False
        txtCOrientX.ForeColor = SystemColors.ControlText
        txtCOrientX.Location = New Point(3, 3)
        txtCOrientX.Name = "txtCOrientX"
        txtCOrientX.Size = New Size(186, 35)
        txtCOrientX.TabIndex = 6
        txtCOrientX.Text = "0"
        txtCOrientX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtCOrientY
        ' 
        txtCOrientY.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtCOrientY.Enabled = False
        txtCOrientY.ForeColor = SystemColors.ControlText
        txtCOrientY.Location = New Point(195, 3)
        txtCOrientY.Name = "txtCOrientY"
        txtCOrientY.Size = New Size(186, 35)
        txtCOrientY.TabIndex = 7
        txtCOrientY.Text = "1"
        txtCOrientY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtCOrientZ
        ' 
        txtCOrientZ.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtCOrientZ.Enabled = False
        txtCOrientZ.ForeColor = SystemColors.ControlText
        txtCOrientZ.Location = New Point(387, 3)
        txtCOrientZ.Name = "txtCOrientZ"
        txtCOrientZ.Size = New Size(186, 35)
        txtCOrientZ.TabIndex = 8
        txtCOrientZ.Text = "0"
        txtCOrientZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' TableLayoutPanel5
        ' 
        TableLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel5.ColumnCount = 3
        TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel5.Controls.Add(txtCTargetX, 0, 0)
        TableLayoutPanel5.Controls.Add(txtCTargetY, 1, 0)
        TableLayoutPanel5.Controls.Add(txtCTargetZ, 2, 0)
        TableLayoutPanel5.Location = New Point(376, 110)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 1
        TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        TableLayoutPanel5.Size = New Size(576, 43)
        TableLayoutPanel5.TabIndex = 105
        ' 
        ' txtCTargetX
        ' 
        txtCTargetX.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtCTargetX.Enabled = False
        txtCTargetX.ForeColor = SystemColors.ControlText
        txtCTargetX.Location = New Point(3, 3)
        txtCTargetX.Name = "txtCTargetX"
        txtCTargetX.Size = New Size(186, 35)
        txtCTargetX.TabIndex = 3
        txtCTargetX.Text = "0"
        txtCTargetX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtCTargetY
        ' 
        txtCTargetY.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtCTargetY.Enabled = False
        txtCTargetY.ForeColor = SystemColors.ControlText
        txtCTargetY.Location = New Point(195, 3)
        txtCTargetY.Name = "txtCTargetY"
        txtCTargetY.Size = New Size(186, 35)
        txtCTargetY.TabIndex = 4
        txtCTargetY.Text = "0"
        txtCTargetY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtCTargetZ
        ' 
        txtCTargetZ.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtCTargetZ.Enabled = False
        txtCTargetZ.ForeColor = SystemColors.ControlText
        txtCTargetZ.Location = New Point(387, 3)
        txtCTargetZ.Name = "txtCTargetZ"
        txtCTargetZ.Size = New Size(186, 35)
        txtCTargetZ.TabIndex = 5
        txtCTargetZ.Text = "0"
        txtCTargetZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel4.ColumnCount = 3
        TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel4.Controls.Add(txtCPosX, 0, 0)
        TableLayoutPanel4.Controls.Add(txtCPosY, 1, 0)
        TableLayoutPanel4.Controls.Add(txtCPosZ, 2, 0)
        TableLayoutPanel4.Location = New Point(376, 59)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 1
        TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        TableLayoutPanel4.Size = New Size(576, 45)
        TableLayoutPanel4.TabIndex = 104
        ' 
        ' txtCPosX
        ' 
        txtCPosX.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtCPosX.Enabled = False
        txtCPosX.ForeColor = SystemColors.ControlText
        txtCPosX.Location = New Point(3, 3)
        txtCPosX.Name = "txtCPosX"
        txtCPosX.Size = New Size(186, 35)
        txtCPosX.TabIndex = 0
        txtCPosX.Text = "0"
        txtCPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtCPosY
        ' 
        txtCPosY.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtCPosY.Enabled = False
        txtCPosY.ForeColor = SystemColors.ControlText
        txtCPosY.Location = New Point(195, 3)
        txtCPosY.Name = "txtCPosY"
        txtCPosY.Size = New Size(186, 35)
        txtCPosY.TabIndex = 1
        txtCPosY.Text = "0"
        txtCPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtCPosZ
        ' 
        txtCPosZ.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtCPosZ.Enabled = False
        txtCPosZ.ForeColor = SystemColors.ControlText
        txtCPosZ.Location = New Point(387, 3)
        txtCPosZ.Name = "txtCPosZ"
        txtCPosZ.Size = New Size(186, 35)
        txtCPosZ.TabIndex = 2
        txtCPosZ.Text = "-10"
        txtCPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' Label47
        ' 
        Label47.AutoEllipsis = True
        Label47.ForeColor = SystemColors.ControlText
        Label47.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label47.Location = New Point(37, 220)
        Label47.Name = "Label47"
        Label47.Size = New Size(336, 35)
        Label47.TabIndex = 103
        Label47.Text = "Camera Movement Speed: "
        Label47.TextAlign = ContentAlignment.MiddleLeft
        Label47.UseMnemonic = False
        ' 
        ' chCamera
        ' 
        chCamera.AutoEllipsis = True
        chCamera.FlatStyle = System.Windows.Forms.FlatStyle.System
        chCamera.ForeColor = SystemColors.ControlText
        chCamera.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chCamera.Location = New Point(9, 18)
        chCamera.Name = "chCamera"
        chCamera.Size = New Size(406, 35)
        chCamera.TabIndex = 42
        chCamera.Text = "Modify Default Camera Settings"
        chCamera.UseMnemonic = False
        chCamera.UseVisualStyleBackColor = True
        ' 
        ' tbCameraSpeed
        ' 
        tbCameraSpeed.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        tbCameraSpeed.BackColor = SystemColors.Control
        tbCameraSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl
        tbCameraSpeed.LargeChange = 10
        tbCameraSpeed.Location = New Point(376, 220)
        tbCameraSpeed.Maximum = 40
        tbCameraSpeed.Minimum = 10
        tbCameraSpeed.Name = "tbCameraSpeed"
        tbCameraSpeed.Size = New Size(573, 90)
        tbCameraSpeed.TabIndex = 9
        tbCameraSpeed.TickFrequency = 5
        tbCameraSpeed.TickStyle = System.Windows.Forms.TickStyle.None
        tbCameraSpeed.Value = 23
        ' 
        ' Label17
        ' 
        Label17.AutoEllipsis = True
        Label17.ForeColor = SystemColors.ControlText
        Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label17.Location = New Point(40, 164)
        Label17.Name = "Label17"
        Label17.Size = New Size(348, 35)
        Label17.TabIndex = 102
        Label17.Text = "Camera Up Orientation X,Y,Z: "
        Label17.TextAlign = ContentAlignment.MiddleLeft
        Label17.UseMnemonic = False
        ' 
        ' Label11
        ' 
        Label11.AutoEllipsis = True
        Label11.ForeColor = SystemColors.ControlText
        Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label11.Location = New Point(37, 63)
        Label11.Name = "Label11"
        Label11.Size = New Size(325, 35)
        Label11.TabIndex = 100
        Label11.Text = "Camera Position X,Y,Z (m): "
        Label11.TextAlign = ContentAlignment.MiddleLeft
        Label11.UseMnemonic = False
        ' 
        ' Label16
        ' 
        Label16.AutoEllipsis = True
        Label16.ForeColor = SystemColors.ControlText
        Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label16.Location = New Point(40, 113)
        Label16.Name = "Label16"
        Label16.Size = New Size(317, 35)
        Label16.TabIndex = 101
        Label16.Text = "Camera Target X,Y,Z: "
        Label16.TextAlign = ContentAlignment.MiddleLeft
        Label16.UseMnemonic = False
        ' 
        ' CmdSaveOut
        ' 
        CmdSaveOut.Dock = System.Windows.Forms.DockStyle.Bottom
        CmdSaveOut.Enabled = False
        CmdSaveOut.FlatAppearance.BorderColor = Color.Black
        CmdSaveOut.FlatStyle = System.Windows.Forms.FlatStyle.System
        CmdSaveOut.ForeColor = SystemColors.ControlText
        CmdSaveOut.ImeMode = System.Windows.Forms.ImeMode.NoControl
        CmdSaveOut.Location = New Point(0, 1259)
        CmdSaveOut.Name = "CmdSaveOut"
        CmdSaveOut.Size = New Size(973, 62)
        CmdSaveOut.TabIndex = 0
        CmdSaveOut.Text = "Save Image"
        CmdSaveOut.UseVisualStyleBackColor = True
        ' 
        ' TabForces
        ' 
        TabForces.BackColor = SystemColors.Control
        TabForces.Controls.Add(spForces)
        TabForces.Location = New Point(4, 39)
        TabForces.Name = "TabForces"
        TabForces.Size = New Size(973, 1321)
        TabForces.TabIndex = 3
        TabForces.Text = "Forces & Collisions"
        TabForces.UseVisualStyleBackColor = True
        ' 
        ' spForces
        ' 
        spForces.Dock = System.Windows.Forms.DockStyle.Fill
        spForces.Location = New Point(0, 0)
        spForces.Name = "spForces"
        spForces.Orientation = System.Windows.Forms.Orientation.Horizontal
        ' 
        ' spForces.Panel1
        ' 
        spForces.Panel1.Controls.Add(gbForces)
        ' 
        ' spForces.Panel2
        ' 
        spForces.Panel2.Controls.Add(gbCollisions)
        spForces.Size = New Size(973, 1321)
        spForces.SplitterDistance = 655
        spForces.TabIndex = 80
        ' 
        ' gbForces
        ' 
        gbForces.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        gbForces.Controls.Add(pForces)
        gbForces.Location = New Point(3, 3)
        gbForces.Name = "gbForces"
        gbForces.Size = New Size(967, 646)
        gbForces.TabIndex = 0
        gbForces.TabStop = False
        gbForces.Text = "Forces"
        ' 
        ' pForces
        ' 
        pForces.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        pForces.AutoScroll = True
        pForces.Controls.Add(tlpAccelForce)
        pForces.Controls.Add(txtPermittivity)
        pForces.Controls.Add(chForces)
        pForces.Controls.Add(Label48)
        pForces.Controls.Add(Label26)
        pForces.Controls.Add(txtFluidViscosity)
        pForces.Controls.Add(Label28)
        pForces.Controls.Add(Label29)
        pForces.Controls.Add(chDrag)
        pForces.Controls.Add(txtDragCoeff)
        pForces.Controls.Add(Label22)
        pForces.Controls.Add(txtFluidDensity)
        pForces.Controls.Add(chField)
        pForces.Controls.Add(chElectrostatic)
        pForces.Controls.Add(chGravity)
        pForces.Location = New Point(6, 34)
        pForces.Name = "pForces"
        pForces.Size = New Size(955, 594)
        pForces.TabIndex = 1
        ' 
        ' tlpAccelForce
        ' 
        tlpAccelForce.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        tlpAccelForce.ColumnCount = 3
        tlpAccelForce.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tlpAccelForce.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tlpAccelForce.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tlpAccelForce.Controls.Add(txtFieldX, 0, 0)
        tlpAccelForce.Controls.Add(txtFieldY, 1, 0)
        tlpAccelForce.Controls.Add(txtFieldZ, 2, 0)
        tlpAccelForce.Location = New Point(402, 214)
        tlpAccelForce.Name = "tlpAccelForce"
        tlpAccelForce.RowCount = 1
        tlpAccelForce.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        tlpAccelForce.Size = New Size(550, 45)
        tlpAccelForce.TabIndex = 70
        ' 
        ' txtFieldX
        ' 
        txtFieldX.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtFieldX.Enabled = False
        txtFieldX.ForeColor = SystemColors.ControlText
        txtFieldX.Location = New Point(3, 3)
        txtFieldX.Name = "txtFieldX"
        txtFieldX.Size = New Size(177, 35)
        txtFieldX.TabIndex = 5
        txtFieldX.Text = "0"
        txtFieldX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtFieldY
        ' 
        txtFieldY.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtFieldY.Enabled = False
        txtFieldY.ForeColor = SystemColors.ControlText
        txtFieldY.Location = New Point(186, 3)
        txtFieldY.Name = "txtFieldY"
        txtFieldY.Size = New Size(177, 35)
        txtFieldY.TabIndex = 6
        txtFieldY.Text = "0"
        txtFieldY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtFieldZ
        ' 
        txtFieldZ.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtFieldZ.Enabled = False
        txtFieldZ.ForeColor = SystemColors.ControlText
        txtFieldZ.Location = New Point(369, 3)
        txtFieldZ.Name = "txtFieldZ"
        txtFieldZ.Size = New Size(178, 35)
        txtFieldZ.TabIndex = 7
        txtFieldZ.Text = "0"
        txtFieldZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtPermittivity
        ' 
        txtPermittivity.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtPermittivity.Enabled = False
        txtPermittivity.ForeColor = SystemColors.ControlText
        txtPermittivity.Location = New Point(402, 133)
        txtPermittivity.Name = "txtPermittivity"
        txtPermittivity.Size = New Size(550, 35)
        txtPermittivity.TabIndex = 3
        txtPermittivity.Text = "1.0006"
        txtPermittivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' chForces
        ' 
        chForces.AutoEllipsis = True
        chForces.CheckAlign = ContentAlignment.MiddleCenter
        chForces.FlatStyle = System.Windows.Forms.FlatStyle.System
        chForces.ForeColor = SystemColors.ControlText
        chForces.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chForces.Location = New Point(19, 13)
        chForces.Name = "chForces"
        chForces.Size = New Size(347, 35)
        chForces.TabIndex = 0
        chForces.Text = "Enable Forces"
        chForces.UseMnemonic = False
        chForces.UseVisualStyleBackColor = True
        ' 
        ' Label48
        ' 
        Label48.AutoEllipsis = True
        Label48.ForeColor = SystemColors.ControlText
        Label48.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label48.Location = New Point(49, 133)
        Label48.Name = "Label48"
        Label48.Size = New Size(347, 36)
        Label48.TabIndex = 95
        Label48.Text = "Relative Permittivity of Medium:"
        Label48.TextAlign = ContentAlignment.MiddleLeft
        Label48.UseMnemonic = False
        ' 
        ' Label26
        ' 
        Label26.AutoEllipsis = True
        Label26.ForeColor = SystemColors.ControlText
        Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label26.Location = New Point(49, 297)
        Label26.Name = "Label26"
        Label26.Size = New Size(347, 35)
        Label26.TabIndex = 90
        Label26.Text = "Fluid Density (kg/m^3):"
        Label26.TextAlign = ContentAlignment.MiddleLeft
        Label26.UseMnemonic = False
        ' 
        ' txtFluidViscosity
        ' 
        txtFluidViscosity.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtFluidViscosity.Enabled = False
        txtFluidViscosity.ForeColor = SystemColors.ControlText
        txtFluidViscosity.Location = New Point(402, 339)
        txtFluidViscosity.Name = "txtFluidViscosity"
        txtFluidViscosity.Size = New Size(550, 35)
        txtFluidViscosity.TabIndex = 10
        txtFluidViscosity.Text = "1.78E-5"
        txtFluidViscosity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' Label28
        ' 
        Label28.AutoEllipsis = True
        Label28.ForeColor = SystemColors.ControlText
        Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label28.Location = New Point(49, 380)
        Label28.Name = "Label28"
        Label28.Size = New Size(347, 35)
        Label28.TabIndex = 91
        Label28.Text = "Drag Coefficient:"
        Label28.TextAlign = ContentAlignment.MiddleLeft
        Label28.UseMnemonic = False
        ' 
        ' Label29
        ' 
        Label29.AutoEllipsis = True
        Label29.ForeColor = SystemColors.ControlText
        Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label29.Location = New Point(49, 339)
        Label29.Name = "Label29"
        Label29.Size = New Size(347, 35)
        Label29.TabIndex = 93
        Label29.Text = "Fluid Viscosity (kg/ms):"
        Label29.TextAlign = ContentAlignment.MiddleLeft
        Label29.UseMnemonic = False
        ' 
        ' chDrag
        ' 
        chDrag.AutoEllipsis = True
        chDrag.Enabled = False
        chDrag.FlatStyle = System.Windows.Forms.FlatStyle.System
        chDrag.ForeColor = SystemColors.ControlText
        chDrag.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chDrag.Location = New Point(19, 259)
        chDrag.Name = "chDrag"
        chDrag.Size = New Size(262, 35)
        chDrag.TabIndex = 8
        chDrag.Text = "Uniform Drag"
        chDrag.UseMnemonic = False
        chDrag.UseVisualStyleBackColor = True
        ' 
        ' txtDragCoeff
        ' 
        txtDragCoeff.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtDragCoeff.Enabled = False
        txtDragCoeff.ForeColor = SystemColors.ControlText
        txtDragCoeff.Location = New Point(402, 380)
        txtDragCoeff.Name = "txtDragCoeff"
        txtDragCoeff.Size = New Size(550, 35)
        txtDragCoeff.TabIndex = 11
        txtDragCoeff.Text = "0.1"
        txtDragCoeff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' Label22
        ' 
        Label22.AutoEllipsis = True
        Label22.ForeColor = SystemColors.ControlText
        Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label22.Location = New Point(49, 216)
        Label22.Name = "Label22"
        Label22.Size = New Size(347, 35)
        Label22.TabIndex = 89
        Label22.Text = "Acceleration (m/s^2) X,Y,Z:"
        Label22.TextAlign = ContentAlignment.MiddleLeft
        Label22.UseMnemonic = False
        ' 
        ' txtFluidDensity
        ' 
        txtFluidDensity.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtFluidDensity.Enabled = False
        txtFluidDensity.ForeColor = SystemColors.ControlText
        txtFluidDensity.Location = New Point(402, 298)
        txtFluidDensity.Name = "txtFluidDensity"
        txtFluidDensity.Size = New Size(550, 35)
        txtFluidDensity.TabIndex = 9
        txtFluidDensity.Text = "1.225"
        txtFluidDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' chField
        ' 
        chField.AutoEllipsis = True
        chField.Enabled = False
        chField.FlatStyle = System.Windows.Forms.FlatStyle.System
        chField.ForeColor = SystemColors.ControlText
        chField.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chField.Location = New Point(19, 178)
        chField.Name = "chField"
        chField.Size = New Size(347, 35)
        chField.TabIndex = 4
        chField.Text = "Uniform Field"
        chField.UseMnemonic = False
        chField.UseVisualStyleBackColor = True
        ' 
        ' chElectrostatic
        ' 
        chElectrostatic.AutoEllipsis = True
        chElectrostatic.Enabled = False
        chElectrostatic.FlatStyle = System.Windows.Forms.FlatStyle.System
        chElectrostatic.Font = New Font("Arial", 9F)
        chElectrostatic.ForeColor = SystemColors.ControlText
        chElectrostatic.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chElectrostatic.Location = New Point(19, 95)
        chElectrostatic.Name = "chElectrostatic"
        chElectrostatic.Size = New Size(347, 35)
        chElectrostatic.TabIndex = 2
        chElectrostatic.Text = "Electrostatic Force"
        chElectrostatic.UseMnemonic = False
        chElectrostatic.UseVisualStyleBackColor = True
        ' 
        ' chGravity
        ' 
        chGravity.AutoEllipsis = True
        chGravity.Enabled = False
        chGravity.FlatStyle = System.Windows.Forms.FlatStyle.System
        chGravity.ForeColor = SystemColors.ControlText
        chGravity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chGravity.Location = New Point(19, 54)
        chGravity.Name = "chGravity"
        chGravity.Size = New Size(347, 35)
        chGravity.TabIndex = 1
        chGravity.Text = "Newtonian Gravity"
        chGravity.UseMnemonic = False
        chGravity.UseVisualStyleBackColor = True
        ' 
        ' gbCollisions
        ' 
        gbCollisions.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        gbCollisions.Controls.Add(pCollisions)
        gbCollisions.Location = New Point(3, 3)
        gbCollisions.Name = "gbCollisions"
        gbCollisions.Size = New Size(967, 654)
        gbCollisions.TabIndex = 79
        gbCollisions.TabStop = False
        gbCollisions.Text = "Collisions"
        ' 
        ' pCollisions
        ' 
        pCollisions.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        pCollisions.AutoScroll = True
        pCollisions.Controls.Add(TableLayoutPanel2)
        pCollisions.Controls.Add(TableLayoutPanel1)
        pCollisions.Controls.Add(chInterpolate)
        pCollisions.Controls.Add(chCollision)
        pCollisions.Controls.Add(Label20)
        pCollisions.Controls.Add(txtCoR)
        pCollisions.Controls.Add(chbreakable)
        pCollisions.Controls.Add(lblResulting)
        pCollisions.Controls.Add(Label25)
        pCollisions.Location = New Point(6, 34)
        pCollisions.Name = "pCollisions"
        pCollisions.Size = New Size(955, 612)
        pCollisions.TabIndex = 80
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.Controls.Add(txtAddMin, 0, 0)
        TableLayoutPanel2.Controls.Add(txtAddAvg, 1, 0)
        TableLayoutPanel2.Controls.Add(txtAddMax, 2, 0)
        TableLayoutPanel2.Location = New Point(402, 246)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(550, 52)
        TableLayoutPanel2.TabIndex = 72
        ' 
        ' txtAddMin
        ' 
        txtAddMin.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtAddMin.Enabled = False
        txtAddMin.ForeColor = SystemColors.ControlText
        txtAddMin.Location = New Point(3, 3)
        txtAddMin.Name = "txtAddMin"
        txtAddMin.Size = New Size(177, 35)
        txtAddMin.TabIndex = 7
        txtAddMin.Text = "2"
        txtAddMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtAddAvg
        ' 
        txtAddAvg.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtAddAvg.Enabled = False
        txtAddAvg.ForeColor = SystemColors.ControlText
        txtAddAvg.Location = New Point(186, 3)
        txtAddAvg.Name = "txtAddAvg"
        txtAddAvg.Size = New Size(177, 35)
        txtAddAvg.TabIndex = 8
        txtAddAvg.Text = "3"
        txtAddAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtAddMax
        ' 
        txtAddMax.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtAddMax.Enabled = False
        txtAddMax.ForeColor = SystemColors.ControlText
        txtAddMax.Location = New Point(369, 3)
        txtAddMax.Name = "txtAddMax"
        txtAddMax.Size = New Size(178, 35)
        txtAddMax.TabIndex = 9
        txtAddMax.Text = "8"
        txtAddMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.Controls.Add(txtBreakMax, 2, 0)
        TableLayoutPanel1.Controls.Add(txtBreakAvg, 1, 0)
        TableLayoutPanel1.Controls.Add(txtBreakMin, 0, 0)
        TableLayoutPanel1.Location = New Point(402, 187)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(547, 45)
        TableLayoutPanel1.TabIndex = 71
        ' 
        ' txtBreakMax
        ' 
        txtBreakMax.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtBreakMax.Enabled = False
        txtBreakMax.ForeColor = SystemColors.ControlText
        txtBreakMax.Location = New Point(367, 3)
        txtBreakMax.Name = "txtBreakMax"
        txtBreakMax.Size = New Size(177, 35)
        txtBreakMax.TabIndex = 6
        txtBreakMax.Text = "500"
        txtBreakMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtBreakAvg
        ' 
        txtBreakAvg.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtBreakAvg.Enabled = False
        txtBreakAvg.ForeColor = SystemColors.ControlText
        txtBreakAvg.Location = New Point(185, 3)
        txtBreakAvg.Name = "txtBreakAvg"
        txtBreakAvg.Size = New Size(176, 35)
        txtBreakAvg.TabIndex = 5
        txtBreakAvg.Text = "100"
        txtBreakAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtBreakMin
        ' 
        txtBreakMin.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtBreakMin.Enabled = False
        txtBreakMin.ForeColor = SystemColors.ControlText
        txtBreakMin.Location = New Point(3, 3)
        txtBreakMin.Name = "txtBreakMin"
        txtBreakMin.Size = New Size(176, 35)
        txtBreakMin.TabIndex = 4
        txtBreakMin.Text = "50"
        txtBreakMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' chInterpolate
        ' 
        chInterpolate.AutoSize = True
        chInterpolate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chInterpolate.Location = New Point(49, 111)
        chInterpolate.Name = "chInterpolate"
        chInterpolate.Size = New Size(385, 31)
        chInterpolate.TabIndex = 2
        chInterpolate.Text = "Interpolate Between Time Steps"
        chInterpolate.UseVisualStyleBackColor = True
        ' 
        ' chCollision
        ' 
        chCollision.AutoEllipsis = True
        chCollision.CheckAlign = ContentAlignment.MiddleCenter
        chCollision.FlatStyle = System.Windows.Forms.FlatStyle.System
        chCollision.ForeColor = SystemColors.ControlText
        chCollision.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chCollision.Location = New Point(19, 18)
        chCollision.Name = "chCollision"
        chCollision.Size = New Size(347, 35)
        chCollision.TabIndex = 0
        chCollision.Text = "Enable Collisions"
        chCollision.UseMnemonic = False
        chCollision.UseVisualStyleBackColor = True
        ' 
        ' Label20
        ' 
        Label20.AutoEllipsis = True
        Label20.ForeColor = SystemColors.ControlText
        Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label20.Location = New Point(49, 56)
        Label20.Name = "Label20"
        Label20.Size = New Size(333, 35)
        Label20.TabIndex = 66
        Label20.Text = "Coeff. of Restitution:"
        Label20.TextAlign = ContentAlignment.MiddleLeft
        Label20.UseMnemonic = False
        ' 
        ' txtCoR
        ' 
        txtCoR.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtCoR.Enabled = False
        txtCoR.ForeColor = SystemColors.ControlText
        txtCoR.Location = New Point(402, 56)
        txtCoR.Name = "txtCoR"
        txtCoR.Size = New Size(547, 35)
        txtCoR.TabIndex = 1
        txtCoR.Text = "0.5"
        txtCoR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' chbreakable
        ' 
        chbreakable.AutoEllipsis = True
        chbreakable.CheckAlign = ContentAlignment.MiddleCenter
        chbreakable.Enabled = False
        chbreakable.FlatStyle = System.Windows.Forms.FlatStyle.System
        chbreakable.ForeColor = SystemColors.ControlText
        chbreakable.ImeMode = System.Windows.Forms.ImeMode.NoControl
        chbreakable.Location = New Point(49, 150)
        chbreakable.Name = "chbreakable"
        chbreakable.Size = New Size(333, 35)
        chbreakable.TabIndex = 3
        chbreakable.Text = "Breakable Collisions"
        chbreakable.UseMnemonic = False
        chbreakable.UseVisualStyleBackColor = True
        ' 
        ' lblResulting
        ' 
        lblResulting.AutoEllipsis = True
        lblResulting.ForeColor = SystemColors.ControlText
        lblResulting.ImeMode = System.Windows.Forms.ImeMode.NoControl
        lblResulting.Location = New Point(79, 234)
        lblResulting.Name = "lblResulting"
        lblResulting.Size = New Size(217, 65)
        lblResulting.TabIndex = 67
        lblResulting.Text = "Resulting Objects Min, Avg, Max:"
        lblResulting.TextAlign = ContentAlignment.MiddleLeft
        lblResulting.UseMnemonic = False
        ' 
        ' Label25
        ' 
        Label25.AutoEllipsis = True
        Label25.ForeColor = SystemColors.ControlText
        Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label25.Location = New Point(79, 190)
        Label25.Name = "Label25"
        Label25.Size = New Size(303, 35)
        Label25.TabIndex = 68
        Label25.Text = "Endurance Min, Avg, Max:"
        Label25.TextAlign = ContentAlignment.MiddleLeft
        Label25.UseMnemonic = False
        ' 
        ' TabSimulation
        ' 
        TabSimulation.BackColor = SystemColors.Control
        TabSimulation.Controls.Add(spSaveAndLoad)
        TabSimulation.Controls.Add(gbSimulation)
        TabSimulation.Location = New Point(4, 39)
        TabSimulation.Name = "TabSimulation"
        TabSimulation.Padding = New System.Windows.Forms.Padding(3)
        TabSimulation.Size = New Size(973, 1321)
        TabSimulation.TabIndex = 0
        TabSimulation.Text = "Simulation"
        TabSimulation.UseVisualStyleBackColor = True
        ' 
        ' spSaveAndLoad
        ' 
        spSaveAndLoad.Dock = System.Windows.Forms.DockStyle.Bottom
        spSaveAndLoad.IsSplitterFixed = True
        spSaveAndLoad.Location = New Point(3, 1256)
        spSaveAndLoad.Name = "spSaveAndLoad"
        ' 
        ' spSaveAndLoad.Panel1
        ' 
        spSaveAndLoad.Panel1.Controls.Add(cmdSave)
        ' 
        ' spSaveAndLoad.Panel2
        ' 
        spSaveAndLoad.Panel2.Controls.Add(cmdLoad)
        spSaveAndLoad.Size = New Size(967, 62)
        spSaveAndLoad.SplitterDistance = 483
        spSaveAndLoad.TabIndex = 90
        ' 
        ' cmdSave
        ' 
        cmdSave.AutoSize = True
        cmdSave.Dock = System.Windows.Forms.DockStyle.Fill
        cmdSave.FlatAppearance.BorderColor = Color.Black
        cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        cmdSave.ForeColor = SystemColors.ControlText
        cmdSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdSave.Location = New Point(0, 0)
        cmdSave.Name = "cmdSave"
        cmdSave.Size = New Size(483, 62)
        cmdSave.TabIndex = 0
        cmdSave.Text = "Save Simulation"
        cmdSave.UseVisualStyleBackColor = True
        ' 
        ' cmdLoad
        ' 
        cmdLoad.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cmdLoad.FlatAppearance.BorderColor = Color.Black
        cmdLoad.FlatStyle = System.Windows.Forms.FlatStyle.System
        cmdLoad.ForeColor = SystemColors.ControlText
        cmdLoad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        cmdLoad.Location = New Point(0, 0)
        cmdLoad.Name = "cmdLoad"
        cmdLoad.Size = New Size(477, 62)
        cmdLoad.TabIndex = 1
        cmdLoad.Text = "Load Simulation"
        cmdLoad.UseVisualStyleBackColor = True
        ' 
        ' gbSimulation
        ' 
        gbSimulation.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        gbSimulation.Controls.Add(pSimulation)
        gbSimulation.Location = New Point(6, 6)
        gbSimulation.Name = "gbSimulation"
        gbSimulation.Size = New Size(959, 1244)
        gbSimulation.TabIndex = 89
        gbSimulation.TabStop = False
        gbSimulation.Text = "Simulation"
        ' 
        ' pSimulation
        ' 
        pSimulation.AutoScroll = True
        pSimulation.Controls.Add(Label1)
        pSimulation.Controls.Add(txtLimitObjects)
        pSimulation.Controls.Add(Label4)
        pSimulation.Controls.Add(Label14)
        pSimulation.Controls.Add(Label2)
        pSimulation.Controls.Add(Label24)
        pSimulation.Controls.Add(txtLimitCalc)
        pSimulation.Controls.Add(cbIntegration)
        pSimulation.Controls.Add(txtScale)
        pSimulation.Controls.Add(txtTimeStep)
        pSimulation.Dock = System.Windows.Forms.DockStyle.Fill
        pSimulation.Location = New Point(3, 31)
        pSimulation.Name = "pSimulation"
        pSimulation.Size = New Size(953, 1210)
        pSimulation.TabIndex = 32
        ' 
        ' Label1
        ' 
        Label1.AutoEllipsis = True
        Label1.ForeColor = SystemColors.ControlText
        Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label1.Location = New Point(22, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(297, 34)
        Label1.TabIndex = 9
        Label1.Text = "Time Step (s):"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        Label1.UseMnemonic = False
        ' 
        ' txtLimitObjects
        ' 
        txtLimitObjects.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLimitObjects.ForeColor = SystemColors.ControlText
        txtLimitObjects.Location = New Point(328, 121)
        txtLimitObjects.Name = "txtLimitObjects"
        txtLimitObjects.Size = New Size(619, 35)
        txtLimitObjects.TabIndex = 2
        txtLimitObjects.Text = "200"
        txtLimitObjects.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' Label4
        ' 
        Label4.AutoEllipsis = True
        Label4.ForeColor = SystemColors.ControlText
        Label4.ImageAlign = ContentAlignment.MiddleRight
        Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label4.Location = New Point(22, 70)
        Label4.Name = "Label4"
        Label4.Size = New Size(300, 35)
        Label4.TabIndex = 12
        Label4.Text = "Limit Calculations (C/s):"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        Label4.UseMnemonic = False
        ' 
        ' Label14
        ' 
        Label14.AutoEllipsis = True
        Label14.ForeColor = SystemColors.ControlText
        Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label14.Location = New Point(22, 223)
        Label14.Name = "Label14"
        Label14.Size = New Size(300, 35)
        Label14.TabIndex = 28
        Label14.Text = "Method of Integration:"
        Label14.TextAlign = ContentAlignment.MiddleLeft
        Label14.UseMnemonic = False
        ' 
        ' Label2
        ' 
        Label2.AutoEllipsis = True
        Label2.ForeColor = SystemColors.ControlText
        Label2.ImageAlign = ContentAlignment.MiddleRight
        Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label2.Location = New Point(22, 173)
        Label2.Name = "Label2"
        Label2.Size = New Size(300, 35)
        Label2.TabIndex = 31
        Label2.Text = "World Scale:"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        Label2.UseMnemonic = False
        ' 
        ' Label24
        ' 
        Label24.AutoEllipsis = True
        Label24.ForeColor = SystemColors.ControlText
        Label24.ImageAlign = ContentAlignment.MiddleRight
        Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Label24.Location = New Point(22, 115)
        Label24.Name = "Label24"
        Label24.Size = New Size(300, 41)
        Label24.TabIndex = 26
        Label24.Text = "Limit Objects:"
        Label24.TextAlign = ContentAlignment.MiddleLeft
        Label24.UseMnemonic = False
        ' 
        ' txtLimitCalc
        ' 
        txtLimitCalc.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtLimitCalc.ForeColor = SystemColors.ControlText
        txtLimitCalc.Location = New Point(328, 70)
        txtLimitCalc.Name = "txtLimitCalc"
        txtLimitCalc.Size = New Size(619, 35)
        txtLimitCalc.TabIndex = 1
        txtLimitCalc.Text = "1000"
        txtLimitCalc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' cbIntegration
        ' 
        cbIntegration.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        cbIntegration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cbIntegration.Enabled = False
        cbIntegration.FormattingEnabled = True
        cbIntegration.Items.AddRange(New Object() {"1st order - Euler", "2nd order - Verlet", "4th order - Symplectic", "6th order - Symplectic"})
        cbIntegration.Location = New Point(328, 223)
        cbIntegration.Name = "cbIntegration"
        cbIntegration.Size = New Size(619, 35)
        cbIntegration.TabIndex = 4
        ' 
        ' txtScale
        ' 
        txtScale.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtScale.ForeColor = SystemColors.ControlText
        txtScale.Location = New Point(328, 173)
        txtScale.Name = "txtScale"
        txtScale.Size = New Size(619, 35)
        txtScale.TabIndex = 3
        txtScale.Text = "1"
        txtScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' txtTimeStep
        ' 
        txtTimeStep.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        txtTimeStep.ForeColor = SystemColors.ControlText
        txtTimeStep.Location = New Point(325, 18)
        txtTimeStep.Name = "txtTimeStep"
        txtTimeStep.Size = New Size(622, 35)
        txtTimeStep.TabIndex = 0
        txtTimeStep.Text = "0.001"
        txtTimeStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        ' 
        ' Tabs
        ' 
        Tabs.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Tabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Tabs.Controls.Add(TabSimulation)
        Tabs.Controls.Add(TabForces)
        Tabs.Controls.Add(TabDisplay)
        Tabs.Controls.Add(TabLights)
        Tabs.Controls.Add(TabGroups)
        Tabs.Location = New Point(0, 73)
        Tabs.Name = "Tabs"
        Tabs.SelectedIndex = 0
        Tabs.Size = New Size(981, 1364)
        Tabs.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Tabs.TabIndex = 1
        ' 
        ' TableLayoutPanel6
        ' 
        TableLayoutPanel6.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel6.ColumnCount = 3
        TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F))
        TableLayoutPanel6.Location = New Point(0, 0)
        TableLayoutPanel6.Name = "TableLayoutPanel6"
        TableLayoutPanel6.RowCount = 1
        TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F))
        TableLayoutPanel6.Size = New Size(200, 100)
        TableLayoutPanel6.TabIndex = 0
        ' 
        ' TableLayoutPanel16
        ' 
        TableLayoutPanel16.ColumnCount = 3
        TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F))
        TableLayoutPanel16.Location = New Point(0, 0)
        TableLayoutPanel16.Name = "TableLayoutPanel16"
        TableLayoutPanel16.RowCount = 1
        TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F))
        TableLayoutPanel16.Size = New Size(200, 100)
        TableLayoutPanel16.TabIndex = 0
        ' 
        ' tblRotation
        ' 
        tblRotation.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        tblRotation.ColumnCount = 6
        tblRotation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblRotation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblRotation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblRotation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F))
        tblRotation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F))
        tblRotation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F))
        tblRotation.Location = New Point(0, 0)
        tblRotation.Name = "tblRotation"
        tblRotation.RowCount = 1
        tblRotation.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F))
        tblRotation.Size = New Size(200, 100)
        tblRotation.TabIndex = 0
        ' 
        ' ControlPanel
        ' 
        AutoScaleDimensions = New SizeF(192F, 192F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        BackColor = SystemColors.Control
        ClientSize = New Size(981, 1479)
        Controls.Add(Tabs)
        Controls.Add(Stats)
        Controls.Add(cmdStart)
        DoubleBuffered = True
        Font = New Font("Arial", 9F)
        ForeColor = SystemColors.ControlText
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(700, 700)
        Name = "ControlPanel"
        SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Text = "SandBox Simulator -  Control Panel"
        TransparencyKey = Color.FromArgb(CByte(255), CByte(192), CByte(192))
        Stats.ResumeLayout(False)
        Stats.PerformLayout()
        TabGroups.ResumeLayout(False)
        TableLayoutPanel13.ResumeLayout(False)
        gbObjects.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        tblOrientation.ResumeLayout(False)
        tblOrientation.PerformLayout()
        tblVelocity.ResumeLayout(False)
        tblVelocity.PerformLayout()
        tblPosition.ResumeLayout(False)
        tblPosition.PerformLayout()
        TableLayoutPanel15.ResumeLayout(False)
        TableLayoutPanel15.PerformLayout()
        CType(tbObjectTransparency, ComponentModel.ISupportInitialize).EndInit()
        CType(tbObjectReflectivity, ComponentModel.ISupportInitialize).EndInit()
        tblSize.ResumeLayout(False)
        tblSize.PerformLayout()
        CType(tbObjectHighlightSharpness, ComponentModel.ISupportInitialize).EndInit()
        TabLights.ResumeLayout(False)
        TableLayoutPanel8.ResumeLayout(False)
        gbLights.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TableLayoutPanel12.ResumeLayout(False)
        TableLayoutPanel12.PerformLayout()
        TableLayoutPanel11.ResumeLayout(False)
        TableLayoutPanel11.PerformLayout()
        CType(tbLightAmbient, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel10.ResumeLayout(False)
        TableLayoutPanel10.PerformLayout()
        TableLayoutPanel9.ResumeLayout(False)
        TableLayoutPanel9.PerformLayout()
        CType(tbLightHighlight, ComponentModel.ISupportInitialize).EndInit()
        TabDisplay.ResumeLayout(False)
        spRendering.Panel1.ResumeLayout(False)
        spRendering.Panel2.ResumeLayout(False)
        CType(spRendering, ComponentModel.ISupportInitialize).EndInit()
        spRendering.ResumeLayout(False)
        gbRendering.ResumeLayout(False)
        pRender.ResumeLayout(False)
        pRender.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        CType(tbPolys, ComponentModel.ISupportInitialize).EndInit()
        gbCamera.ResumeLayout(False)
        pCamera.ResumeLayout(False)
        pCamera.PerformLayout()
        TableLayoutPanel7.ResumeLayout(False)
        TableLayoutPanel7.PerformLayout()
        TableLayoutPanel5.ResumeLayout(False)
        TableLayoutPanel5.PerformLayout()
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel4.PerformLayout()
        CType(tbCameraSpeed, ComponentModel.ISupportInitialize).EndInit()
        TabForces.ResumeLayout(False)
        spForces.Panel1.ResumeLayout(False)
        spForces.Panel2.ResumeLayout(False)
        CType(spForces, ComponentModel.ISupportInitialize).EndInit()
        spForces.ResumeLayout(False)
        gbForces.ResumeLayout(False)
        pForces.ResumeLayout(False)
        pForces.PerformLayout()
        tlpAccelForce.ResumeLayout(False)
        tlpAccelForce.PerformLayout()
        gbCollisions.ResumeLayout(False)
        pCollisions.ResumeLayout(False)
        pCollisions.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TabSimulation.ResumeLayout(False)
        spSaveAndLoad.Panel1.ResumeLayout(False)
        spSaveAndLoad.Panel1.PerformLayout()
        spSaveAndLoad.Panel2.ResumeLayout(False)
        CType(spSaveAndLoad, ComponentModel.ISupportInitialize).EndInit()
        spSaveAndLoad.ResumeLayout(False)
        gbSimulation.ResumeLayout(False)
        pSimulation.ResumeLayout(False)
        pSimulation.PerformLayout()
        Tabs.ResumeLayout(False)
        ResumeLayout(False)

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
    Friend WithEvents gbCamera As System.Windows.Forms.GroupBox
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
    Friend WithEvents gbRendering As System.Windows.Forms.GroupBox
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
    Friend WithEvents gbForces As System.Windows.Forms.GroupBox
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
    Friend WithEvents gbCollisions As System.Windows.Forms.GroupBox
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
    Friend WithEvents gbSimulation As System.Windows.Forms.GroupBox
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRenderThreads As System.Windows.Forms.TextBox
    Friend WithEvents spSaveAndLoad As System.Windows.Forms.SplitContainer
    Friend WithEvents pSimulation As System.Windows.Forms.Panel
    Friend WithEvents spForces As System.Windows.Forms.SplitContainer
    Friend WithEvents pForces As System.Windows.Forms.Panel
    Friend WithEvents pCollisions As System.Windows.Forms.Panel
    Friend WithEvents tlpAccelForce As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents spRendering As System.Windows.Forms.SplitContainer
    Friend WithEvents pRender As System.Windows.Forms.Panel
    Friend WithEvents pCamera As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel12 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel11 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel13 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tblSize As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel16 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblVelocity As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblOrientation As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtObjectNormalZ As System.Windows.Forms.TextBox
    Friend WithEvents tblPosition As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel15 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblRotation As System.Windows.Forms.TableLayoutPanel
End Class
