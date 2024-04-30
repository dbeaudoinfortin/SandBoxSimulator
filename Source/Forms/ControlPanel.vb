Imports System.Windows.Forms

Public Class ControlPanel
    Public StatusUpdateCount As Integer
    Public ObjectNumber As SimulationConfigDistribution(Of Integer) = New SimulationConfigDistributionInt
    Public ObjectMass As SimulationConfigDistribution(Of Double) = New SimulationConfigDistributionDouble
    Public ObjectCharge As SimulationConfigDistribution(Of Double) = New SimulationConfigDistributionDouble
    Public ObjectSize As New SimulationConfigDistributionXYZ
    Public ObjectRotation As New SimulationConfigDistributionXYZ
    Public ObjectRadius As SimulationConfigDistribution(Of Double) = New SimulationConfigDistributionDouble
    Public ObjectNormal As New SimulationConfigDistributionXYZ
    Public ObjectPosition As New SimulationConfigDistributionXYZ
    Public ObjectVelocity As New SimulationConfigDistributionXYZ
    Public ObjectColor As SimulationConfigDistribution(Of Color) = New SimulationConfigDistributionColor
    Public ObjectHighlight As SimulationConfigDistribution(Of Color) = New SimulationConfigDistributionColor
    Public ObjectSharpness As SimulationConfigDistribution(Of Single) = New SimulationConfigDistributionSingle
    Public ObjectReflectivity As SimulationConfigDistribution(Of Double) = New SimulationConfigDistributionDouble
    Public ObjectTransparency As SimulationConfigDistribution(Of Double) = New SimulationConfigDistributionDouble
    Public ObjectRefractiveIndex As SimulationConfigDistribution(Of Double) = New SimulationConfigDistributionDouble

    Private hasLoaded As Boolean = False 'Used to avoid form checks during component initialization
    Private Function GetFileContents(ByVal FullPath As String, Optional ByRef ErrInfo As String = "") As String
        Dim strContents As String
        Dim objReader As System.IO.StreamReader
        Try
            objReader = New System.IO.StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Return strContents
        Catch Ex As Exception
            ErrInfo = Ex.Message
            Return ""
        End Try
    End Function
    Private Function SaveTextToFile(ByVal strData As String, ByVal FullPath As String, Optional ByVal ErrInfo As String = "") As Boolean
        Dim bAns As Boolean = False
        Dim objReader As System.IO.StreamWriter
        Try
            objReader = New System.IO.StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return bAns
    End Function
    Private Function IsValidSets() As Boolean
        If Not isValidMaxObjects() Then Return False

        If Not IsNumeric(txtTimeStep.Text) Then
            MsgBox("Time Step must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToDouble(txtTimeStep.Text) <= 0 Then
            MsgBox("Time Step must be greater than zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtLimitCalc.Text) Then
            MsgBox("Limit Calculations must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtLimitCalc.Text) < 0 Or ToDouble(txtLimitCalc.Text) > 500000 Then
            MsgBox("Limit Calculations must be equal to or greater than zero and less than or equal to 500 000.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        'TODO: Should sum up the count of all the objects of all the groups
        If ToInt32(txtLimitObjects.Text) < Simulation.Config.GroupCount Then
            MsgBox("The number of Objects must not be greater than Max Objects.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtScale.Text) Then
            MsgBox("World Scale must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtScale.Text) <= 0 Then
            MsgBox("World Scale must be greater than zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtFieldX.Text) Then
            MsgBox("Field Acceleration X must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If Not IsNumeric(txtFieldY.Text) Then
            MsgBox("Field Acceleration Y must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If Not IsNumeric(txtFieldZ.Text) Then
            MsgBox("Field Acceleration Z must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtFluidDensity.Text) Then
            MsgBox("Fluid Density must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtFluidDensity.Text) <= 0 Then
            MsgBox("Fluid Density must be greater than zero", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtFluidViscosity.Text) Then
            MsgBox("Fluid Viscosity must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtFluidViscosity.Text) <= 0 Then
            MsgBox("Fluid Viscosity must be greater than zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtDragCoeff.Text) Then
            MsgBox("Drag Coefficent must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtDragCoeff.Text) <= 0 Then
            MsgBox("Drag Coefficent must be greater than zero", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtCoR.Text) Then
            MsgBox("Coefficient of Restitution must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtCoR.Text) < 0 Then
            MsgBox("Coefficient of Restitution must be greater than or equal to zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtBreakMin.Text) Then
            MsgBox("Min Endurance must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtBreakAvg.Text) Then
            MsgBox("Average Endurance must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtBreakMax.Text) Then
            MsgBox("Max Endurance must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToDouble(txtBreakMin.Text) < 0 Then
            MsgBox("Min Endurance must be greater than or equal to zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToDouble(txtBreakMin.Text) > ToDouble(txtBreakAvg.Text) Then
            MsgBox("Min Endurance must be less than or equal to Average Endurance.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToDouble(txtBreakAvg.Text) > ToDouble(txtBreakMax.Text) Then
            MsgBox("Average Endurance must be less than or equal to Max Endurance.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtAddAvg.Text) Then
            MsgBox("Average Resulting Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtAddMax.Text) Then
            MsgBox("Max Resulting Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtAddMin.Text) Then
            MsgBox("Min Resulting Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToDouble(txtAddAvg.Text) <> Int(ToDouble(txtAddAvg.Text)) Then
            MsgBox("Average Resulting Objects must be of integer value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToDouble(txtAddMax.Text) <> Int(ToDouble(txtAddMax.Text)) Then
            MsgBox("Max Resulting Objects must be of integer value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToDouble(txtAddMin.Text) <> Int(ToDouble(txtAddMin.Text)) Then
            MsgBox("Min Resulting Objects must be of integer value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToInt32(txtAddMin.Text) < 1 Then
            MsgBox("Min Resulting Objects must be greater than one.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToInt32(txtAddMin.Text) > ToInt32(txtAddAvg.Text) Then
            MsgBox("Min Resulting Objects must be less than or equal to Average Resulting Objects", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToInt32(txtAddAvg.Text) > ToInt32(txtAddMax.Text) Then
            MsgBox("Average Resulting Objects must be less than or equal to Max Resulting Objects", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtWindowX.Text) Then
            MsgBox("Window Size X must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtWindowX.Text) < 1 Then
            MsgBox("Window Size X must be one or greater.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtWindowY.Text) Then
            MsgBox("Window Size Y must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtWindowY.Text) < 1 Then
            MsgBox("Window Size Y must be one or greater.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtHFoV.Text) Then
            MsgBox("Horizontal Field of View must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtHFoV.Text) <= 0 Or ToDouble(txtHFoV.Text) >= 180 Then
            MsgBox("Horizontal Field of View must be greater than zero and less than 180.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtHFoV.Text) <> Int(ToDouble(txtHFoV.Text)) Then
            MsgBox("Horizontal Field of View must be of integer value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtVFoV.Text) Then
            MsgBox("Vertical Field of View must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtVFoV.Text) <= 0 Or ToDouble(txtVFoV.Text) >= 180 Then
            MsgBox("Vertical Field of View must be greater than zero and less than 180.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtVFoV.Text) <> Int(ToDouble(txtVFoV.Text)) Then
            MsgBox("Vertical Field of View must be of integer value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtMaxFPS.Text) Then
            MsgBox("Maximum Frame Rate must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtMaxFPS.Text) < 0 Or ToDouble(txtMaxFPS.Text) > 50000 Then
            MsgBox("Maximum Frame Rate must be equal to or greater than zero and less than or equal to 50 000.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtRenderThreads.Text) Then
            MsgBox("Render Thread Count must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        Dim threadCount As Int32 = ToInt32(txtRenderThreads.Text)
        If threadCount <> -1 And (threadCount < 1 Or threadCount > 1000) Then
            MsgBox("Render Thread Count must be between 1 and 1000.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtCPosX.Text) Then
            MsgBox("Camera Position X must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtCPosY.Text) Then
            MsgBox("Camera Position Y must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtCPosZ.Text) Then
            MsgBox("Camera Position Z must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtCTargetX.Text) Then
            MsgBox("Camera Target X must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtCTargetY.Text) Then
            MsgBox("Camera Target Y must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtCTargetZ.Text) Then
            MsgBox("Camera Target Z must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtCOrientX.Text) Then
            MsgBox("Camera Orientation X must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtCOrientY.Text) Then
            MsgBox("Camera Orientation Y must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtCOrientZ.Text) Then
            MsgBox("Camera Orientation Z must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If txtCPosX.Text = txtCTargetX.Text And txtCPosY.Text = txtCTargetY.Text And txtCPosZ.Text = txtCTargetZ.Text Then
            MsgBox("Camera Target and Camera Position can not be be the same.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToDouble(txtCOrientX.Text) = 0 And ToDouble(txtCOrientY.Text) = 0 And ToDouble(txtCOrientZ.Text) = 0 Then
            MsgBox("At least one component of Camera Orientation must be non-zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If New XYZ(ToDouble(txtCPosX.Text) - ToDouble(txtCTargetX.Text), ToDouble(txtCPosY.Text) - ToDouble(txtCTargetY.Text), ToDouble(txtCPosZ.Text) - ToDouble(txtCTargetZ.Text)).Dot(New XYZ(ToDouble(txtCOrientX.Text), ToDouble(txtCOrientY.Text), ToDouble(txtCOrientZ.Text))) <> 0 Then
            MsgBox("Camera Orientation must perpendicular to the direction of the camera (Camera Target - Camera Position).", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Not IsNumeric(txtPermittivity.Text) Then
            MsgBox("Relative Permittivity of Medium must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If ToDouble(txtPermittivity.Text) < 1 Then
            MsgBox("Relative Permittivity of Medium must be greater of equal to one.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        Return True
    End Function
    Private Function IsValidGroup() As Boolean

        'NAME
        If txtObjectName.Text = "" Then
            MsgBox("The objects must have a name.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        'NUMBER OF OBJECTS
        If Not IsNumeric(txtObjectNumber.Text) Then
            MsgBox("Number of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtObjectNumber.Text) <> Int(ToDouble(txtObjectNumber.Text)) Then
            MsgBox("Number of Objects must be of integer value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtObjectNumber.Text) < 1 Then
            MsgBox("Number of Objects must be greater than or equal to one.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        'MASSES
        If IsNumeric(txtObjectMass.Text) = False Then
            MsgBox("Mass of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtObjectMass.Text) = 0 Then
            MsgBox("Mass of Objects can not be zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If


        'CHARGES
        If IsNumeric(txtObjectCharge.Text) = False Then
            MsgBox("Charge of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If


        'RADIUS
        If IsNumeric(txtObjectRadius.Text) = False Then
            MsgBox("Radius of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtObjectRadius.Text) <= 0 Then
            MsgBox("Radius of Objects must be greater than zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        'SIZE
        If IsNumeric(txtObjectSizeX.Text) = False Then
            MsgBox("Size X of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtObjectSizeX.Text) <= 0 Then
            MsgBox("Size X of Objects must be greater than zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtObjectSizeY.Text) = False Then
            MsgBox("Size Y of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtObjectSizeY.Text) <= 0 Then
            MsgBox("Size Y of Objects must be greater than zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtObjectPositionZ.Text) = False Then
            MsgBox("Size Z of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtObjectSizeZ.Text) <= 0 Then
            MsgBox("Size Z of Objects must be greater than zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        'POSITION
        If IsNumeric(txtObjectPositionX.Text) = False Then
            MsgBox("Position X of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtObjectPositionY.Text) = False Then
            MsgBox("Position Y of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtObjectPositionZ.Text) = False Then
            MsgBox("Position Z of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        'ROTATION
        If IsNumeric(txtObjectRotationX.Text) = False Then
            MsgBox("Rotation X of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtObjectRotationY.Text) = False Then
            MsgBox("Rotation Y of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtObjectRotationZ.Text) = False Then
            MsgBox("Rotation Z of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        'NORMAL
        If IsNumeric(txtObjectNormalX.Text) = False Then
            MsgBox("Normal X of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtObjectNormalY.Text) = False Then
            MsgBox("Normal Y of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtObjectNormalZ.Text) = False Then
            MsgBox("Normal Z of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtObjectNormalX.Text) = 0 And ToDouble(txtObjectNormalY.Text) = 0 And ToDouble(txtObjectNormalZ.Text) = 0 Then
            MsgBox("The normal vector of the objects can not be zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        'VELOCITY
        If IsNumeric(txtObjectVelocityX.Text) = False Then
            MsgBox("Velocity X of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtObjectVelocityY.Text) = False Then
            MsgBox("Velocity Y of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtObjectVelocityZ.Text) = False Then
            MsgBox("Velocity Z of Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        'REFRACTIVE INDEX
        If ToDouble(txtObjectRefractiveIndex.Text) = 0 Then
            MsgBox("Refractive Index of Objects can not be zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        Return True
    End Function
    Private Function IsValidLight() As Boolean
        If txtLightName.Text = "" Then
            MsgBox("The light must have a name.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtLightRange.Text) = False Then
            MsgBox("The range of the light must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToSingle(txtLightRange.Text) <= 0 Then
            MsgBox("The range of the light must be greater than zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If IsNumeric(txtLightAttenuationA.Text) = False Then
            MsgBox("The A attenuation of the light must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToSingle(txtLightAttenuationA.Text) < 0 Then
            MsgBox("The A attenuation of the light must be positive.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtLightAttenuationB.Text) = False Then
            MsgBox("The B attenuation of the light must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToSingle(txtLightAttenuationB.Text) < 0 Then
            MsgBox("The B attenuation of the light must be positive.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtLightAttenuationC.Text) = False Then
            MsgBox("The C attenuation of the light must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToSingle(txtLightAttenuationC.Text) < 0 Then
            MsgBox("The C attenuation of the light must be positive.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If IsNumeric(txtLightAngleInner.Text) = False Then
            MsgBox("The inner cone angle of the light must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToSingle(txtLightAngleInner.Text) <= 0 Or ToSingle(txtLightAngleInner.Text) >= 180 Then
            MsgBox("The inner cone angle of the light must be greater than zero and less than 180.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtLightAngleInner.Text) <> Int(ToDouble(txtLightAngleInner.Text)) Then
            MsgBox("The inner cone angle of the light must be of integer value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtLightAngleOuter.Text) = False Then
            MsgBox("The outer cone angle of the light must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToSingle(txtLightAngleOuter.Text) <= 0 Or ToSingle(txtLightAngleOuter.Text) >= 180 Then
            MsgBox("The outer cone angle of the light must be greater than zero and less than 180.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToSingle(txtLightAngleOuter.Text) <= ToSingle(txtLightAngleInner.Text) Then
            MsgBox("The outer cone angle of the light must be greater than the inner cone angle of the light", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtLightAngleOuter.Text) <> Int(ToDouble(txtLightAngleOuter.Text)) Then
            MsgBox("The outer cone angle of the light must be of integer value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtLightFalloff.Text) = False Then
            MsgBox("The falloff of the light must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToSingle(txtLightFalloff.Text) <= 0 Then
            MsgBox("The falloff of the light must be greater than zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtLightPositionX.Text) = False Then
            MsgBox("The X position of the light must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtLightPositionY.Text) = False Then
            MsgBox("The Y position of the light must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtLightPositionZ.Text) = False Then
            MsgBox("The Z position of the light must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtLightDirectionX.Text) = False Then
            MsgBox("The X direction of the light must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtLightDirectionY.Text) = False Then
            MsgBox("The Y direction of the light must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If IsNumeric(txtLightDirectionZ.Text) = False Then
            MsgBox("The Z direction of the light must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtLightDirectionX.Text) = 0 And ToDouble(txtLightDirectionY.Text) = 0 And ToDouble(txtLightDirectionZ.Text) = 0 Then
            MsgBox("At least one component of Light Direction must be non-zero.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        Return True
    End Function
    Private Function IsValidDistribution() As Boolean
        Return True
    End Function
    Private Sub SetAllEnabled(ByVal State As Boolean)

        'SIMULATION
        txtTimeStep.Enabled = State
        txtLimitCalc.Enabled = State
        txtLimitObjects.Enabled = State
        txtScale.Enabled = State
        cmdSave.Enabled = State
        cmdLoad.Enabled = State

        'RENDER
        cbRender.Enabled = State
        chTrace.Enabled = State
        EnableColorBox(plRenderBackColor, State)
        txtHFoV.Enabled = State
        txtWindowX.Enabled = State
        txtWindowY.Enabled = State

        'CAMERA
        chCamera.Enabled = State

        'LIGHTS
        chLightsEnable.Enabled = State

        'FORCES
        chForces.Enabled = State

        'COLLISIONS
        chCollision.Enabled = State

        'OBJECTS
        listGroups.Enabled = State
        cbObjectType.Enabled = State
        txtObjectName.Enabled = State
        cmdObjectNumber.Enabled = State

        'position
        cmdObjectPositionX.Enabled = State
        cmdObjectPositionY.Enabled = State
        cmdObjectPositionZ.Enabled = State

        'velocity
        cmdObjectVelocityX.Enabled = State
        cmdObjectVelocityY.Enabled = State
        cmdObjectVelocityZ.Enabled = State

        cmdObjectColor.Enabled = State

        'transparency
        cmdObjectTransparency.Enabled = State

        chObjectAffected.Enabled = State
        chObjectAffects.Enabled = State
        chObjectWireframe.Enabled = State

        cmdGroupAdd.Enabled = State

        If State = False Then
            'SIMULATION
            cbIntegration.Enabled = State

            'FORCES
            chGravity.Enabled = State
            chElectrostatic.Enabled = State
            txtPermittivity.Enabled = State
            chField.Enabled = State
            txtFieldX.Enabled = State
            txtFieldY.Enabled = State
            txtFieldZ.Enabled = State
            chDrag.Enabled = State
            txtFluidDensity.Enabled = State
            txtFluidViscosity.Enabled = State
            txtDragCoeff.Enabled = State

            'COLLISIONS
            txtCoR.Enabled = State
            chInterpolate.Enabled = State
            chbreakable.Enabled = State
            txtBreakMin.Enabled = State
            txtBreakAvg.Enabled = State
            txtBreakMax.Enabled = State
            txtAddMin.Enabled = State
            txtAddAvg.Enabled = State
            txtAddMax.Enabled = State

            'RENDER
            txtVFoV.Enabled = State
            cbShading.Enabled = State
            tbPolys.Enabled = State
            chVSync.Enabled = State
            txtMaxFPS.Enabled = State
            txtRenderThreads.Enabled = State

            'CAMERA
            txtCPosX.Enabled = State
            txtCPosY.Enabled = State
            txtCPosZ.Enabled = State
            txtCTargetX.Enabled = State
            txtCTargetY.Enabled = State
            txtCTargetZ.Enabled = State
            txtCOrientX.Enabled = State
            txtCOrientY.Enabled = State
            txtCOrientZ.Enabled = State
            tbCameraSpeed.Enabled = State

            'LIGHTS
            listLights.Enabled = State
            txtLightName.Enabled = State
            cbLightType.Enabled = State
            txtLightPositionX.Enabled = State
            txtLightPositionY.Enabled = State
            txtLightPositionZ.Enabled = State
            txtLightDirectionX.Enabled = State
            txtLightDirectionY.Enabled = State
            txtLightDirectionZ.Enabled = State
            EnableColorBox(plLightColor, State)
            tbLightHighlight.Enabled = State
            tbLightAmbient.Enabled = State
            txtLightRange.Enabled = State
            txtLightAttenuationA.Enabled = State
            txtLightAttenuationB.Enabled = State
            txtLightAttenuationC.Enabled = State
            txtLightAngleInner.Enabled = State
            txtLightAngleOuter.Enabled = State
            txtLightFalloff.Enabled = State
            cmdLightAdd.Enabled = State
            cmdLightRemove.Enabled = State
            cmdLightReplace.Enabled = State

            'OBJECTS
            txtObjectMass.Enabled = State
            txtObjectCharge.Enabled = State

            cmdObjectRotationX.Enabled = State
            cmdObjectRotationY.Enabled = State
            cmdObjectRotationZ.Enabled = State

            txtObjectRotationX.Enabled = State
            txtObjectRotationY.Enabled = State
            txtObjectRotationZ.Enabled = State

            cmdObjectNormalX.Enabled = State
            cmdObjectNormalY.Enabled = State
            cmdObjectNormalZ.Enabled = State

            txtObjectNormalX.Enabled = State
            txtObjectNormalY.Enabled = State
            txtObjectNormalZ.Enabled = State

            cmdObjectRadius.Enabled = State
            txtObjectRadius.Enabled = State

            cmdObjectSizeX.Enabled = State
            cmdObjectSizeY.Enabled = State
            cmdObjectSizeZ.Enabled = State

            txtObjectSizeX.Enabled = State
            txtObjectSizeY.Enabled = State
            txtObjectSizeZ.Enabled = State

            txtObjectPositionX.Enabled = State
            txtObjectPositionY.Enabled = State
            txtObjectPositionZ.Enabled = State

            txtObjectVelocityX.Enabled = State
            txtObjectVelocityY.Enabled = State
            txtObjectVelocityZ.Enabled = State

            EnableColorBox(plObjectColor, State)
            EnableColorBox(plObjectHighlightColor, State)

            tbObjectHighlightSharpness.Enabled = State
            tbObjectReflectivity.Enabled = State
            tbObjectTransparency.Enabled = State

            txtObjectRefractiveIndex.Enabled = State

            cmdGroupReplace.Enabled = State
            cmdGroupRemove.Enabled = State

            cmdObjectNumber.Enabled = State
            cmdObjectMass.Enabled = State
            cmdObjectCharge.Enabled = State
            cmdObjectHighlightColor.Enabled = State
            cmdObjectHighlightSharpness.Enabled = State
            cmdObjectReflectivity.Enabled = State
            cmdObjectRefractiveIndex.Enabled = State
        Else
            CheckConditionals()
        End If
    End Sub
    Private Sub CheckConditionals()
        'Don't do this during loading
        If Not hasLoaded Then Return

        'TODO: Let's simply this
        'RENDER
        If cbRender.SelectedIndex < 2 Then 'Using Direct X
            txtRenderThreads.Enabled = False
            txtRenderThreads.Text = "1"

            tbPolys.Enabled = True
            chVSync.Enabled = True
            txtVFoV.Enabled = False
            If chVSync.Checked Then 'Using Vsync
                txtMaxFPS.Enabled = False
            Else
                txtMaxFPS.Enabled = True
            End If
            If chLightsEnable.Checked Then
                cbShading.Enabled = True
            Else
                cbShading.Enabled = False
            End If
        Else 'Ray
            cbShading.Enabled = False
            tbPolys.Enabled = False
            chVSync.Enabled = False
            txtVFoV.Enabled = True
            txtMaxFPS.Enabled = True
            txtRenderThreads.Enabled = True
        End If

        'CAMERA
        If chCamera.Checked Then 'Modify camera
            tbCameraSpeed.Enabled = True
            txtCPosX.Enabled = True
            txtCPosY.Enabled = True
            txtCPosZ.Enabled = True
            txtCTargetX.Enabled = True
            txtCTargetY.Enabled = True
            txtCTargetZ.Enabled = True
            txtCOrientX.Enabled = True
            txtCOrientY.Enabled = True
            txtCOrientZ.Enabled = True
        Else
            tbCameraSpeed.Enabled = False
            txtCPosX.Enabled = False
            txtCPosY.Enabled = False
            txtCPosZ.Enabled = False
            txtCTargetX.Enabled = False
            txtCTargetY.Enabled = False
            txtCTargetZ.Enabled = False
            txtCOrientX.Enabled = False
            txtCOrientY.Enabled = False
            txtCOrientZ.Enabled = False
        End If


        'LIGHTS
        If chLightsEnable.Checked Then
            cmdLightAdd.Enabled = True
            tbLightAmbient.Enabled = True
            txtLightName.Enabled = True
            EnableColorBox(plLightColor, True)
            If cbRender.SelectedIndex < 2 Then 'Using Direct X
                tbLightHighlight.Enabled = True
            Else
                tbLightHighlight.Enabled = False
            End If
            listLights.Enabled = True
            If listLights.SelectedIndex <> -1 Then 'Light is selected
                cmdLightReplace.Enabled = True
                cmdLightRemove.Enabled = True
            Else
                cmdLightReplace.Enabled = False
                cmdLightRemove.Enabled = False
            End If

            'Light Type
            cbLightType.Enabled = True
            If cbLightType.SelectedIndex = 0 Then   'Directional
                txtLightDirectionX.Enabled = True
                txtLightDirectionY.Enabled = True
                txtLightDirectionZ.Enabled = True
                txtLightPositionX.Enabled = False
                txtLightPositionY.Enabled = False
                txtLightPositionZ.Enabled = False
                txtLightAttenuationA.Enabled = False
                txtLightAttenuationB.Enabled = False
                txtLightAttenuationC.Enabled = False
                txtLightAngleInner.Enabled = False
                txtLightAngleOuter.Enabled = False
                txtLightFalloff.Enabled = False
                txtLightRange.Enabled = False
            ElseIf cbLightType.SelectedIndex = 1 Then   'Point
                txtLightDirectionX.Enabled = False
                txtLightDirectionY.Enabled = False
                txtLightDirectionZ.Enabled = False
                txtLightPositionX.Enabled = True
                txtLightPositionY.Enabled = True
                txtLightPositionZ.Enabled = True
                txtLightAttenuationA.Enabled = True
                txtLightAttenuationB.Enabled = True
                txtLightAttenuationC.Enabled = True
                txtLightAngleInner.Enabled = False
                txtLightAngleOuter.Enabled = False
                txtLightFalloff.Enabled = False
                If cbRender.SelectedIndex < 2 Then 'Using Direct X
                    txtLightRange.Enabled = True
                Else
                    txtLightRange.Enabled = False
                End If
            Else    'Spot
                txtLightDirectionX.Enabled = True
                txtLightDirectionY.Enabled = True
                txtLightDirectionZ.Enabled = True
                txtLightPositionX.Enabled = True
                txtLightPositionY.Enabled = True
                txtLightPositionZ.Enabled = True
                txtLightAttenuationA.Enabled = True
                txtLightAttenuationB.Enabled = True
                txtLightAttenuationC.Enabled = True
                txtLightAngleInner.Enabled = True
                txtLightAngleOuter.Enabled = True
                txtLightFalloff.Enabled = True
                If cbRender.SelectedIndex < 2 Then 'Using Direct X
                    txtLightRange.Enabled = True
                Else
                    txtLightRange.Enabled = False
                End If
            End If
        Else
            cbLightType.Enabled = False
            listLights.Enabled = False
            cmdLightAdd.Enabled = False
            tbLightAmbient.Enabled = False
            txtLightName.Enabled = False
            EnableColorBox(plLightColor, False)
            tbLightHighlight.Enabled = False
            cmdLightReplace.Enabled = False
            cmdLightRemove.Enabled = False
            txtLightDirectionX.Enabled = False
            txtLightDirectionY.Enabled = False
            txtLightDirectionZ.Enabled = False
            txtLightPositionX.Enabled = False
            txtLightPositionY.Enabled = False
            txtLightPositionZ.Enabled = False
            txtLightAttenuationA.Enabled = False
            txtLightAttenuationB.Enabled = False
            txtLightAttenuationC.Enabled = False
            txtLightAngleInner.Enabled = False
            txtLightAngleOuter.Enabled = False
            txtLightFalloff.Enabled = False
            txtLightRange.Enabled = False
        End If

        'FORCES
        If chForces.Checked Then
            chGravity.Enabled = True
            chField.Enabled = True
            chElectrostatic.Enabled = True
            chDrag.Enabled = True
            If chGravity.Checked Or chElectrostatic.Checked Or chField.Checked Or chDrag.Checked Then
                cbIntegration.Enabled = True
            Else
                cbIntegration.Enabled = False
            End If
            If chElectrostatic.Checked Then
                txtPermittivity.Enabled = True
            Else
                txtPermittivity.Enabled = False
            End If
            If chField.Checked Then
                txtFieldX.Enabled = True
                txtFieldY.Enabled = True
                txtFieldZ.Enabled = True
            Else
                txtFieldX.Enabled = False
                txtFieldY.Enabled = False
                txtFieldZ.Enabled = False
            End If
            If chDrag.Checked Then
                txtDragCoeff.Enabled = True
                txtFluidDensity.Enabled = True
                txtFluidViscosity.Enabled = True
            Else
                txtDragCoeff.Enabled = False
                txtFluidDensity.Enabled = False
                txtFluidViscosity.Enabled = False
            End If
        Else
            txtPermittivity.Enabled = False
            chGravity.Enabled = False
            chField.Enabled = False
            chElectrostatic.Enabled = False
            chDrag.Enabled = False
            txtFieldX.Enabled = False
            txtFieldY.Enabled = False
            txtFieldZ.Enabled = False
            txtDragCoeff.Enabled = False
            txtFluidDensity.Enabled = False
            txtFluidViscosity.Enabled = False
            cbIntegration.Enabled = False
        End If

        'COLLISIONS
        If chCollision.Checked Then
            txtCoR.Enabled = True
            chInterpolate.Enabled = True
            chbreakable.Enabled = True
            If chbreakable.Checked Then
                txtAddAvg.Enabled = True
                txtAddMax.Enabled = True
                txtAddMin.Enabled = True
                txtBreakAvg.Enabled = True
                txtBreakMin.Enabled = True
                txtBreakMax.Enabled = True
            Else
                txtAddAvg.Enabled = False
                txtAddMax.Enabled = False
                txtAddMin.Enabled = False
                txtBreakAvg.Enabled = False
                txtBreakMin.Enabled = False
                txtBreakMax.Enabled = False
            End If
        Else
            txtCoR.Enabled = False
            chInterpolate.Enabled = False
            chbreakable.Enabled = False
            txtAddAvg.Enabled = False
            txtAddMax.Enabled = False
            txtAddMin.Enabled = False
            txtBreakAvg.Enabled = False
            txtBreakMin.Enabled = False
            txtBreakMax.Enabled = False
        End If


        'OBJECTS

        'number
        If cmdObjectNumber.ForeColor = Color.Black Then
            txtObjectNumber.Enabled = True
        Else
            txtObjectNumber.Enabled = False
        End If

        'mass
        If (chObjectAffected.Checked Or chObjectAffects.Checked) And ((chForces.Checked And (chGravity.Checked Or chElectrostatic.Checked Or chField.Checked Or chDrag.Checked)) Or chCollision.Checked) Then
            cmdObjectMass.Enabled = True
            If cmdObjectMass.ForeColor = Color.Black Then
                txtObjectMass.Enabled = True
            Else
                txtObjectMass.Enabled = False
            End If
        Else
            cmdObjectMass.Enabled = False
            txtObjectMass.Enabled = False
        End If

        'charge
        If chForces.Checked And chElectrostatic.Checked And (chObjectAffected.Checked Or chObjectAffects.Checked) Then
            cmdObjectCharge.Enabled = True
            If cmdObjectCharge.ForeColor = Color.Black Then
                txtObjectCharge.Enabled = True
            Else
                txtObjectCharge.Enabled = False
            End If
        Else
            txtObjectCharge.Enabled = False
            cmdObjectCharge.Enabled = False
        End If

        'radius/size - rotation/normal
        If cbObjectType.SelectedIndex = 0 Then 'Sphere
            lblObjectRotation.Visible = True
            cmdObjectRotationX.Visible = True
            cmdObjectRotationY.Visible = True
            cmdObjectRotationZ.Visible = True
            txtObjectRotationX.Visible = True
            txtObjectRotationY.Visible = True
            txtObjectRotationZ.Visible = True

            cmdObjectRotationX.Enabled = False
            cmdObjectRotationY.Enabled = False
            cmdObjectRotationZ.Enabled = False
            txtObjectRotationX.Enabled = False
            txtObjectRotationY.Enabled = False
            txtObjectRotationZ.Enabled = False

            lblObjectNormal.Visible = False
            cmdObjectNormalX.Visible = False
            cmdObjectNormalY.Visible = False
            cmdObjectNormalZ.Visible = False
            txtObjectNormalX.Visible = False
            txtObjectNormalY.Visible = False
            txtObjectNormalZ.Visible = False

            cmdObjectNormalX.Enabled = False
            cmdObjectNormalY.Enabled = False
            cmdObjectNormalZ.Enabled = False
            txtObjectNormalX.Enabled = False
            txtObjectNormalY.Enabled = False
            txtObjectNormalZ.Enabled = False

            lblObjectRadius.Visible = True
            cmdObjectRadius.Visible = True
            txtObjectRadius.Visible = True

            cmdObjectRadius.Enabled = True
            If cmdObjectRadius.ForeColor = Color.Black Then
                txtObjectRadius.Enabled = True
            Else
                txtObjectRadius.Enabled = False
            End If

            lblObjectSize.Visible = False
            cmdObjectSizeX.Visible = False
            cmdObjectSizeY.Visible = False
            cmdObjectSizeZ.Visible = False
            txtObjectSizeX.Visible = False
            txtObjectSizeY.Visible = False
            txtObjectSizeZ.Visible = False

            cmdObjectSizeX.Enabled = False
            cmdObjectSizeY.Enabled = False
            cmdObjectSizeZ.Enabled = False
            txtObjectSizeX.Enabled = False
            txtObjectSizeY.Enabled = False
            txtObjectSizeZ.Enabled = False
        ElseIf cbObjectType.SelectedIndex = 1 Then 'Box
            lblObjectRotation.Visible = True
            cmdObjectRotationX.Visible = True
            cmdObjectRotationY.Visible = True
            cmdObjectRotationZ.Visible = True
            txtObjectRotationX.Visible = True
            txtObjectRotationY.Visible = True
            txtObjectRotationZ.Visible = True

            cmdObjectRotationX.Enabled = True
            cmdObjectRotationY.Enabled = True
            cmdObjectRotationZ.Enabled = True

            If cmdObjectRotationX.ForeColor = Color.Black Then
                txtObjectRotationX.Enabled = True
            Else
                txtObjectRotationX.Enabled = False
            End If
            If cmdObjectRotationY.ForeColor = Color.Black Then
                txtObjectRotationY.Enabled = True
            Else
                txtObjectRotationY.Enabled = False
            End If
            If cmdObjectRotationZ.ForeColor = Color.Black Then
                txtObjectRotationZ.Enabled = True
            Else
                txtObjectRotationZ.Enabled = False
            End If

            lblObjectNormal.Visible = False
            cmdObjectNormalX.Visible = False
            cmdObjectNormalY.Visible = False
            cmdObjectNormalZ.Visible = False
            txtObjectNormalX.Visible = False
            txtObjectNormalY.Visible = False
            txtObjectNormalZ.Visible = False

            cmdObjectNormalX.Enabled = False
            cmdObjectNormalY.Enabled = False
            cmdObjectNormalZ.Enabled = False
            txtObjectNormalX.Enabled = False
            txtObjectNormalY.Enabled = False
            txtObjectNormalZ.Enabled = False

            lblObjectRadius.Visible = False
            cmdObjectRadius.Visible = False
            txtObjectRadius.Visible = False

            cmdObjectRadius.Enabled = False
            txtObjectRadius.Enabled = False

            lblObjectSize.Visible = True
            cmdObjectSizeX.Visible = True
            cmdObjectSizeY.Visible = True
            cmdObjectSizeZ.Visible = True
            txtObjectSizeX.Visible = True
            txtObjectSizeY.Visible = True
            txtObjectSizeZ.Visible = True

            cmdObjectSizeX.Enabled = True
            cmdObjectSizeY.Enabled = True
            cmdObjectSizeZ.Enabled = True

            If cmdObjectSizeX.ForeColor = Color.Black Then
                txtObjectSizeX.Enabled = True
            Else
                txtObjectSizeX.Enabled = False
            End If
            If cmdObjectSizeY.ForeColor = Color.Black Then
                txtObjectSizeY.Enabled = True
            Else
                txtObjectSizeY.Enabled = False
            End If
            If cmdObjectSizeZ.ForeColor = Color.Black Then
                txtObjectSizeZ.Enabled = True
            Else
                txtObjectSizeZ.Enabled = False
            End If

        ElseIf cbObjectType.SelectedIndex = 2 Then 'Plane
            lblObjectRotation.Visible = False
            cmdObjectRotationX.Visible = False
            cmdObjectRotationY.Visible = False
            cmdObjectRotationZ.Visible = False
            txtObjectRotationX.Visible = False
            txtObjectRotationY.Visible = False
            txtObjectRotationZ.Visible = False

            cmdObjectRotationX.Enabled = False
            cmdObjectRotationY.Enabled = False
            cmdObjectRotationZ.Enabled = False
            txtObjectRotationX.Enabled = False
            txtObjectRotationY.Enabled = False
            txtObjectRotationZ.Enabled = False

            lblObjectNormal.Visible = True
            cmdObjectNormalX.Visible = True
            cmdObjectNormalY.Visible = True
            cmdObjectNormalZ.Visible = True
            txtObjectNormalX.Visible = True
            txtObjectNormalY.Visible = True
            txtObjectNormalZ.Visible = True

            cmdObjectNormalX.Enabled = True
            cmdObjectNormalY.Enabled = True
            cmdObjectNormalZ.Enabled = True

            If cmdObjectNormalX.ForeColor = Color.Black Then
                txtObjectNormalX.Enabled = True
            Else
                txtObjectNormalX.Enabled = False
            End If
            If cmdObjectNormalY.ForeColor = Color.Black Then
                txtObjectNormalY.Enabled = True
            Else
                txtObjectNormalY.Enabled = False
            End If
            If cmdObjectNormalZ.ForeColor = Color.Black Then
                txtObjectNormalZ.Enabled = True
            Else
                txtObjectNormalZ.Enabled = False
            End If

            lblObjectRadius.Visible = False
            cmdObjectRadius.Visible = False
            txtObjectRadius.Visible = False

            cmdObjectRadius.Enabled = False
            txtObjectRadius.Enabled = False

            lblObjectSize.Visible = True
            cmdObjectSizeX.Visible = True
            cmdObjectSizeY.Visible = True
            cmdObjectSizeZ.Visible = True
            txtObjectSizeX.Visible = True
            txtObjectSizeY.Visible = True
            txtObjectSizeZ.Visible = True

            cmdObjectSizeX.Enabled = False
            cmdObjectSizeY.Enabled = False
            cmdObjectSizeZ.Enabled = False
            txtObjectSizeX.Enabled = False
            txtObjectSizeY.Enabled = False
            txtObjectSizeZ.Enabled = False
        End If

        'position
        If cmdObjectPositionX.ForeColor = Color.Black Then
            txtObjectPositionX.Enabled = True
        Else
            txtObjectPositionX.Enabled = False
        End If
        If cmdObjectPositionY.ForeColor = Color.Black Then
            txtObjectPositionY.Enabled = True
        Else
            txtObjectPositionY.Enabled = False
        End If
        If cmdObjectPositionZ.ForeColor = Color.Black Then
            txtObjectPositionZ.Enabled = True
        Else
            txtObjectPositionZ.Enabled = False
        End If

        'velocity
        If cmdObjectVelocityX.ForeColor = Color.Black Then
            txtObjectVelocityX.Enabled = True
        Else
            txtObjectVelocityX.Enabled = False
        End If
        If cmdObjectVelocityY.ForeColor = Color.Black Then
            txtObjectVelocityY.Enabled = True
        Else
            txtObjectVelocityY.Enabled = False
        End If
        If cmdObjectVelocityZ.ForeColor = Color.Black Then
            txtObjectVelocityZ.Enabled = True
        Else
            txtObjectVelocityZ.Enabled = False
        End If

        'color
        If cmdObjectColor.ForeColor = Color.Black Then
            EnableColorBox(plObjectColor, True)
        Else
            EnableColorBox(plObjectColor, False)
        End If

        'highlight color & sharpness
        If chLightsEnable.Checked And cbRender.SelectedIndex < 2 Then
            cmdObjectHighlightColor.Enabled = True
            If cmdObjectHighlightColor.ForeColor = Color.Black Then
                EnableColorBox(plObjectHighlightColor, True)
            Else
                EnableColorBox(plObjectHighlightColor, False)
            End If
            cmdObjectHighlightSharpness.Enabled = True
            If cmdObjectHighlightSharpness.ForeColor = Color.Black Then
                tbObjectHighlightSharpness.Enabled = True
            Else
                tbObjectHighlightSharpness.Enabled = False
            End If
        Else
            EnableColorBox(plObjectHighlightColor, False)
            cmdObjectHighlightColor.Enabled = False
            tbObjectHighlightSharpness.Enabled = False
            cmdObjectHighlightSharpness.Enabled = False
        End If

        'reflectivity
        If chLightsEnable.Checked And cbRender.SelectedIndex = 2 Then
            cmdObjectReflectivity.Enabled = True
            If cmdObjectReflectivity.ForeColor = Color.Black Then
                tbObjectReflectivity.Enabled = True
            Else
                tbObjectReflectivity.Enabled = False
            End If
        Else
            cmdObjectReflectivity.Enabled = False
            tbObjectReflectivity.Enabled = False
        End If

        'transparency
        cmdObjectTransparency.Enabled = True
        If cmdObjectTransparency.ForeColor = Color.Black Then
            tbObjectTransparency.Enabled = True
        Else
            tbObjectTransparency.Enabled = False
        End If

        'refractive index
        If chLightsEnable.Checked And cbRender.SelectedIndex = 2 Then
            cmdObjectRefractiveIndex.Enabled = True
            If cmdObjectRefractiveIndex.ForeColor = Color.Black Then
                txtObjectRefractiveIndex.Enabled = True
            Else
                txtObjectRefractiveIndex.Enabled = False
            End If
        Else
            cmdObjectRefractiveIndex.Enabled = False
            txtObjectRefractiveIndex.Enabled = False
        End If

        If listGroups.SelectedIndex <> -1 Then
            cmdGroupRemove.Enabled = True
            cmdGroupReplace.Enabled = True
        Else
            cmdGroupRemove.Enabled = False
            cmdGroupReplace.Enabled = False
        End If
    End Sub
    Private Sub UpdateSimulation()
        Simulation.Config.Render.Mode = ToByte(cbRender.SelectedIndex)
        Simulation.Config.Settings.MaxObjects = ToInt32(txtLimitObjects.Text)
        Simulation.Config.Settings.TimeStep = ToDouble(txtTimeStep.Text)
        Simulation.Config.Render.WorldScale = ToSingle(txtScale.Text)
        Simulation.Config.Settings.MaxCPS = ToDouble(txtLimitCalc.Text)
        Simulation.Config.Render.BackgroundColor = plRenderBackColor.ForeColor
        Simulation.Config.Forces.Gravity = chGravity.Checked
        Simulation.Config.Forces.ElectroStatic.Enabled = chElectrostatic.Checked
        Simulation.Config.Forces.ElectroStatic.Permittivity = ToDouble(txtPermittivity.Text)
        Simulation.Config.Render.TraceObjects = chTrace.Checked
        Simulation.Config.Collisions.Enabled = chCollision.Checked
        Simulation.Config.Collisions.Breakable = chbreakable.Checked
        Simulation.Config.Collisions.Interpolate = chInterpolate.Checked
        Simulation.Config.Camera.HFov = ToSingle(ToDouble(txtHFoV.Text) * (Math.PI / 180))
        Simulation.Config.Camera.VFov = ToSingle(ToDouble(txtVFoV.Text) * (Math.PI / 180))
        Simulation.Config.Camera.AllowModification = chCamera.Checked
        Simulation.Config.Render.SphereComplexity = tbPolys.Value
        Simulation.Config.Forces.Drag.Viscosity = ToDouble(txtFluidViscosity.Text)
        If Simulation.Config.Camera.AllowModification Then
            Simulation.Config.Camera.UpVector.X = ToSingle(txtCOrientX.Text)
            Simulation.Config.Camera.UpVector.Y = ToSingle(txtCOrientY.Text)
            Simulation.Config.Camera.UpVector.Z = ToSingle(txtCOrientZ.Text)
            Simulation.Config.Camera.Position.X = ToSingle(txtCPosX.Text)
            Simulation.Config.Camera.Position.Y = ToSingle(txtCPosY.Text)
            Simulation.Config.Camera.Position.Z = ToSingle(txtCPosZ.Text)
            Simulation.Config.Camera.Target.X = ToSingle(txtCTargetX.Text)
            Simulation.Config.Camera.Target.Y = ToSingle(txtCTargetY.Text)
            Simulation.Config.Camera.Target.Z = ToSingle(txtCTargetZ.Text)
            Simulation.Config.Camera.MoveSpeed = 10 ^ ((0.1 * tbCameraSpeed.Value) - 3)
        Else
            Simulation.Config.Camera.MoveSpeed = 0.2
            Simulation.Config.Camera.UpVector.X = 0
            Simulation.Config.Camera.UpVector.Y = 1
            Simulation.Config.Camera.UpVector.Z = 0
            Simulation.Config.Camera.Position.X = 0
            Simulation.Config.Camera.Position.Y = 0
            Simulation.Config.Camera.Position.Z = -10
            Simulation.Config.Camera.Target.X = 0
            Simulation.Config.Camera.Target.Y = 0
            Simulation.Config.Camera.Target.Z = 0
        End If
        Simulation.Config.Render.Height = ToInt32(txtWindowY.Text)
        Simulation.Config.Render.Width = ToInt32(txtWindowX.Text)
        Simulation.Config.Camera.AllowModification = chCamera.Checked
        Simulation.Config.Render.AspectRatio = ToSingle(Simulation.Config.Render.Width / Simulation.Config.Render.Height)
        Simulation.Config.Collisions.CoR = ToDouble(txtCoR.Text)
        Simulation.Config.Collisions.AddAvg = ToInt32(txtAddAvg.Text)
        Simulation.Config.Collisions.AddMin = ToInt32(txtAddMin.Text)
        Simulation.Config.Collisions.AddMax = ToInt32(txtAddMax.Text)
        Simulation.Config.Collisions.BreakAvg = ToDouble(txtBreakAvg.Text)
        Simulation.Config.Collisions.BreakMin = ToDouble(txtBreakMin.Text)
        Simulation.Config.Collisions.BreakMax = ToDouble(txtBreakMax.Text)
        Simulation.Config.Forces.Drag.Enabled = chDrag.Checked
        Simulation.Config.Forces.Drag.DragCoeff = ToDouble(txtDragCoeff.Text)
        Simulation.Config.Forces.Enabled = chForces.Checked
        Simulation.Config.Forces.Field.Enabled = chField.Checked
        Simulation.Config.Forces.Field.Acceleration.X = ToDouble(txtFieldX.Text)
        Simulation.Config.Forces.Field.Acceleration.Y = ToDouble(txtFieldY.Text)
        Simulation.Config.Forces.Field.Acceleration.Z = ToDouble(txtFieldZ.Text)
        Simulation.Config.Forces.Drag.Density = ToDouble(txtFluidDensity.Text)
        Simulation.Config.Settings.IntegrationMethod = ToByte(cbIntegration.SelectedIndex)
        Simulation.Config.Render.EnableLighting = chLightsEnable.Checked
        Simulation.Config.Render.VSync = chVSync.Checked
        Simulation.Config.Render.MaxFPS = ToDouble(txtMaxFPS.Text)
        Simulation.Config.Render.RenderThreads = ToInt32(txtRenderThreads.Text)
        If cbShading.SelectedIndex = 0 Then
            Simulation.Config.Render.Shading = Microsoft.DirectX.Direct3D.ShadeMode.Flat
        Else
            Simulation.Config.Render.Shading = Microsoft.DirectX.Direct3D.ShadeMode.Gouraud
        End If
    End Sub
    Private Sub UpdateForm()
        '----SIMULATION----
        cbIntegration.SelectedIndex = Simulation.Config.Settings.IntegrationMethod
        txtLimitObjects.Text = Simulation.Config.Settings.MaxObjects.ToString
        txtTimeStep.Text = Simulation.Config.Settings.TimeStep.ToString
        txtScale.Text = Simulation.Config.Render.WorldScale.ToString
        txtLimitCalc.Text = Simulation.Config.Settings.MaxCPS.ToString
        plRenderBackColor.BackColor = Simulation.Config.Render.BackgroundColor

        '----FORCES----
        chGravity.Checked = Simulation.Config.Forces.Gravity
        chElectrostatic.Checked = Simulation.Config.Forces.ElectroStatic.Enabled
        txtPermittivity.Text = Simulation.Config.Forces.ElectroStatic.Permittivity.ToString
        chForces.Checked = Simulation.Config.Forces.Enabled
        chDrag.Checked = Simulation.Config.Forces.Drag.Enabled
        chField.Checked = Simulation.Config.Forces.Field.Enabled
        txtFieldX.Text = Simulation.Config.Forces.Field.Acceleration.X.ToString
        txtFieldY.Text = Simulation.Config.Forces.Field.Acceleration.Y.ToString
        txtFieldZ.Text = Simulation.Config.Forces.Field.Acceleration.Z.ToString
        txtDragCoeff.Text = Simulation.Config.Forces.Drag.DragCoeff.ToString
        txtFluidDensity.Text = Simulation.Config.Forces.Drag.Density.ToString
        txtFluidViscosity.Text = Simulation.Config.Forces.Drag.Viscosity.ToString

        '----COLLISIONS----
        chCollision.Checked = Simulation.Config.Collisions.Enabled
        chInterpolate.Checked = Simulation.Config.Collisions.Interpolate
        chbreakable.Checked = Simulation.Config.Collisions.Breakable
        txtCoR.Text = Simulation.Config.Collisions.CoR.ToString
        txtBreakMin.Text = Simulation.Config.Collisions.BreakMin.ToString
        txtBreakAvg.Text = Simulation.Config.Collisions.BreakAvg.ToString
        txtBreakMax.Text = Simulation.Config.Collisions.BreakMax.ToString
        txtAddMin.Text = Simulation.Config.Collisions.AddMin.ToString
        txtAddAvg.Text = Simulation.Config.Collisions.AddAvg.ToString
        txtAddMax.Text = Simulation.Config.Collisions.AddMax.ToString

        '----DISPLAY----
        chVSync.Checked = Simulation.Config.Render.VSync
        txtMaxFPS.Text = Simulation.Config.Render.MaxFPS.ToString
        txtRenderThreads.Text = Simulation.Config.Render.RenderThreads.ToString

        If Simulation.Config.Render.Shading = Microsoft.DirectX.Direct3D.ShadeMode.Flat Then
            cbShading.SelectedIndex = 0
        Else
            cbShading.SelectedIndex = 1
        End If

        CmdSaveOut.Enabled = False
        chCamera.Checked = Simulation.Config.Camera.AllowModification
        chTrace.Checked = Simulation.Config.Render.TraceObjects

        txtVFoV.Text = Int((Simulation.Config.Camera.VFov / Math.PI) * 180).ToString
        txtHFoV.Text = Int((Simulation.Config.Camera.HFov / Math.PI) * 180).ToString

        txtWindowX.Text = Simulation.Config.Render.Width.ToString
        txtWindowY.Text = Simulation.Config.Render.Height.ToString

        txtCPosX.Text = Simulation.Config.Camera.Position.X.ToString
        txtCPosY.Text = Simulation.Config.Camera.Position.Y.ToString
        txtCPosZ.Text = Simulation.Config.Camera.Position.Z.ToString

        txtCOrientX.Text = Simulation.Config.Camera.UpVector.X.ToString
        txtCOrientY.Text = Simulation.Config.Camera.UpVector.Y.ToString
        txtCOrientZ.Text = Simulation.Config.Camera.UpVector.Z.ToString

        txtCTargetX.Text = Simulation.Config.Camera.Target.X.ToString
        txtCTargetY.Text = Simulation.Config.Camera.Target.Y.ToString
        txtCTargetZ.Text = Simulation.Config.Camera.Target.Z.ToString

        cbRender.SelectedIndex = Simulation.Config.Render.Mode

        tbCameraSpeed.Value = ToInt32((10 * Math.Log10(Simulation.Config.Camera.MoveSpeed)) + 30)
        tbPolys.Value = Simulation.Config.Render.SphereComplexity

        Dim i As Integer

        '----LIGHTS----
        listLights.Items.Clear()
        For i = 0 To Simulation.Config.LightCount - 1
            listLights.Items.Insert(listLights.Items.Count, Simulation.Config.Lights(i).Name)
        Next
        listLights.ClearSelected()
        ClearLightForm()

        '----OBJECTS----
        listGroups.Items.Clear()
        For i = 0 To Simulation.Config.GroupCount - 1
            listGroups.Items.Insert(listGroups.Items.Count, Simulation.Config.Groups(i).Name)
        Next
        listGroups.ClearSelected()
        ClearObjectForm()

    End Sub
    Private Sub ClearLightForm()
        cmdLightRemove.Enabled = False
        cmdLightReplace.Enabled = False
        txtLightName.Text = ""
        txtLightDirectionX.Text = "0"
        txtLightDirectionY.Text = "0"
        txtLightDirectionZ.Text = "1"
        chLightsEnable.Checked = Simulation.Config.Render.EnableLighting
        plLightColor.BackColor = plLightColor.ForeColor
        cbLightType.SelectedIndex = 0
        txtLightPositionX.Text = "0"
        txtLightPositionY.Text = "0"
        txtLightPositionZ.Text = "-2"
        tbLightAmbient.Value = tbLightAmbient.Minimum
        txtLightRange.Text = "50"
        txtLightAttenuationA.Text = "0"
        txtLightAttenuationB.Text = "1"
        txtLightAttenuationC.Text = "0"
        txtLightAngleInner.Text = "30"
        txtLightAngleOuter.Text = "45"
        txtLightFalloff.Text = "1"
    End Sub
    Private Sub ControlPanel_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Simulation.Running = True Then
            Simulation.StopSimulation()
        End If
        Application.DoEvents()
        End
    End Sub
    Private Sub ControlPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Simulation = New SimulationRuntime
        Backup = New SimulationRuntime
        CPUNumber = Environment.ProcessorCount
        OpenDialog.InitialDirectory = Application.StartupPath
        SaveDialog.InitialDirectory = Application.StartupPath
        If QueryPerformanceFrequency(Simulation.CalcCounter.Frequency) = 0 Then
            MsgBox("Unable To Query the Performance Count)", MsgBoxStyle.Critical, "Error")
            End
        Else
            Simulation.RenderCounter.Frequency = Simulation.CalcCounter.Frequency
        End If
        UpdateForm()
        SetAllEnabled(True)
        hasLoaded = True
        CheckConditionals()
        ConfigModified = False
    End Sub
    Private Sub CmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        If cmdStart.Text = "&Start Simulation" Then
            If Not IsValidSets() Then Exit Sub
            If ObjectRoomLeft() < 0 Then
                MsgBox("The number Of objects In the simulation surpasses the maximum number of objects", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
            If Simulation.Config.GroupCount <= 0 Then
                MsgBox("At least one Object Is required To begin the simulation.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
            cmdStart.Text = "&End Simulation"
            SetAllEnabled(False)
            UpdateSimulation()
            Backup.Copy(Simulation)
            Simulation.RenderCounter.FullCount = 0
            Simulation.CalcCounter.FullCount = 0
            CmdSaveOut.Enabled = True
            Simulation.RunSimulation()
        Else
            If Output.Visible Then
                Output.Hide()
            End If
            Simulation.StopSimulation()

            Simulation.Copy(Backup)
            SetAllEnabled(True)
            CmdSaveOut.Enabled = False
            cmdStart.Text = "&Start Simulation"
        End If
    End Sub
    Private Sub CmdSaveOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSaveOut.Click
        SaveDialog.FileName = ""
        SaveDialog.DefaultExt = "bmp"
        SaveDialog.Title = "Save Output Image"
        SaveDialog.Filter = "Bitmap (*.bmp)|*.bmp"
        SaveDialog.ShowDialog()
        If SaveDialog.FileName <> "" Then
            Dim BackBuffer As Microsoft.DirectX.Direct3D.Surface
            BackBuffer = Simulation.Render.Device.GetBackBuffer(0, 0, 0)
            Microsoft.DirectX.Direct3D.SurfaceLoader.Save(SaveDialog.FileName, Microsoft.DirectX.Direct3D.ImageFileFormat.Bmp, BackBuffer)
            BackBuffer.Dispose()
        End If
    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If IsValidSets() = True Then
            SaveDialog.FileName = ""
            SaveDialog.DefaultExt = "PR4"
            SaveDialog.Title = "Save Simulation"
            SaveDialog.Filter = "PR4 File (*.PR4)|*.PR4"
            SaveDialog.ShowDialog()
            If SaveDialog.FileName <> "" Then
                Try
                    UpdateSimulation()
                    Dim Err As String = ""
                    If SaveTextToFile(Simulation.ToString(), SaveDialog.FileName, Err) = False Then
                        MsgBox("Unable To save simulation: '" & Err & "'.", MsgBoxStyle.Critical, "Error")
                    Else
                        ConfigModified = False
                    End If
                Catch
                    MsgBox("Unable to save the simulation.", MsgBoxStyle.Critical, "Error")
                End Try
            End If
        End If
    End Sub
    Private Sub CmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        If ConfigModified = True Then
            If MsgBox("Loading a new file will replace your current configuration." & Chr(13) & "Are you sure you want to proceed?", MsgBoxStyle.YesNo, "Loading...") = vbNo Then
                Exit Sub
            End If
        End If

        Dim InText As String
        Backup.Copy(Simulation)

        OpenDialog.FileName = ""
        OpenDialog.DefaultExt = "PR4"
        OpenDialog.Title = "Load Simulation"
        OpenDialog.Filter = "PR4 file (*.PR4)|*.PR4"
        OpenDialog.ShowDialog()
        If OpenDialog.FileName <> "" Then
            Dim xErr As String = ""
            Try
                InText = GetFileContents(OpenDialog.FileName, xErr)
                Simulation.Config.Load(InText)
            Catch
                MsgBox("Unable to load the simulation.", MsgBoxStyle.Critical, "Error")
                Simulation.Copy(Backup)
            End Try
            UpdateForm()
            CheckConditionals()
            ConfigModified = False
        End If
    End Sub
    Private Sub PlRenderBackColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plRenderBackColor.Click
        ColorDialog.Color = plRenderBackColor.BackColor
        ColorDialog.ShowDialog()
        plRenderBackColor.BackColor = ColorDialog.Color
        ConfigModified = True
    End Sub
    Private Sub ChCamera_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chCamera.CheckedChanged
        CheckConditionals()
        ConfigModified = True
    End Sub
    Private Sub PlLightColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plLightColor.Click
        ColorDialog.Color = plLightColor.BackColor
        ColorDialog.ShowDialog()
        plLightColor.BackColor = ColorDialog.Color
        ConfigModified = True
    End Sub
    Private Sub ListLights_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listLights.SelectedIndexChanged
        If listLights.SelectedIndex <> -1 Then
            txtLightName.Text = Simulation.Config.Lights(listLights.SelectedIndex).Name
            plLightColor.BackColor = Simulation.Config.Lights(listLights.SelectedIndex).Color
            txtLightDirectionX.Text = Simulation.Config.Lights(listLights.SelectedIndex).Direction.X.ToString
            txtLightDirectionY.Text = Simulation.Config.Lights(listLights.SelectedIndex).Direction.Y.ToString
            txtLightDirectionZ.Text = Simulation.Config.Lights(listLights.SelectedIndex).Direction.Z.ToString
            If Simulation.Config.Lights(listLights.SelectedIndex).Type = Microsoft.DirectX.Direct3D.LightType.Spot Then
                cbLightType.SelectedIndex = 2
            ElseIf Simulation.Config.Lights(listLights.SelectedIndex).Type = Microsoft.DirectX.Direct3D.LightType.Point Then
                cbLightType.SelectedIndex = 1
            Else
                cbLightType.SelectedIndex = 0
            End If
            txtLightPositionX.Text = Simulation.Config.Lights(listLights.SelectedIndex).Position.X.ToString
            txtLightPositionY.Text = Simulation.Config.Lights(listLights.SelectedIndex).Position.Y.ToString
            txtLightPositionZ.Text = Simulation.Config.Lights(listLights.SelectedIndex).Position.Z.ToString
            tbLightHighlight.Value = Simulation.Config.Lights(listLights.SelectedIndex).SpecularColor.R
            tbLightAmbient.Value = Simulation.Config.Lights(listLights.SelectedIndex).AmbientRatio
            txtLightRange.Text = Simulation.Config.Lights(listLights.SelectedIndex).Range.ToString
            txtLightAttenuationA.Text = Simulation.Config.Lights(listLights.SelectedIndex).AttenuationA.ToString
            txtLightAttenuationB.Text = Simulation.Config.Lights(listLights.SelectedIndex).AttenuationB.ToString
            txtLightAttenuationC.Text = Simulation.Config.Lights(listLights.SelectedIndex).AttenuationC.ToString
            txtLightAngleInner.Text = ToInt32((Simulation.Config.Lights(listLights.SelectedIndex).InnerCone / PI) * 180).ToString
            txtLightAngleOuter.Text = ToInt32((Simulation.Config.Lights(listLights.SelectedIndex).OuterCone / PI) * 180).ToString
            txtLightFalloff.Text = Simulation.Config.Lights(listLights.SelectedIndex).Falloff.ToString
        Else
            ClearLightForm()
        End If
        CheckConditionals()
    End Sub
    Private Sub CmdAddLight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLightAdd.Click
        If Not IsValidLight() = True Then Exit Sub
        Simulation.Config.EnlargeLights()
        InsertLight(Simulation.Config.LightCount - 1)
        listLights.Items.Insert(listLights.Items.Count, Simulation.Config.Lights(Simulation.Config.LightCount - 1).Name)
        listLights.ClearSelected()
        ConfigModified = True
    End Sub
    Private Sub InsertLight(ByRef i As Integer)
        If cbLightType.SelectedIndex = 2 Then
            Simulation.Config.Lights(i).Type = Microsoft.DirectX.Direct3D.LightType.Spot
        ElseIf cbLightType.SelectedIndex = 1 Then
            Simulation.Config.Lights(i).Type = Microsoft.DirectX.Direct3D.LightType.Point
        Else
            Simulation.Config.Lights(i).Type = Microsoft.DirectX.Direct3D.LightType.Directional
        End If
        Simulation.Config.Lights(i).Name = txtLightName.Text
        Simulation.Config.Lights(i).Color = plLightColor.BackColor
        Simulation.Config.Lights(i).Direction.X = ToSingle(txtLightDirectionX.Text)
        Simulation.Config.Lights(i).Direction.Y = ToSingle(txtLightDirectionY.Text)
        Simulation.Config.Lights(i).Direction.Z = ToSingle(txtLightDirectionZ.Text)
        Simulation.Config.Lights(i).Position.X = ToSingle(txtLightPositionX.Text)
        Simulation.Config.Lights(i).Position.Y = ToSingle(txtLightPositionY.Text)
        Simulation.Config.Lights(i).Position.Z = ToSingle(txtLightPositionZ.Text)
        Simulation.Config.Lights(i).SpecularColor = Color.FromArgb(255, tbLightHighlight.Value, tbLightHighlight.Value, tbLightHighlight.Value)
        Simulation.Config.Lights(i).AmbientRatio = tbLightAmbient.Value
        Simulation.Config.Lights(i).AmbientColor = Color.FromArgb(255, ToByte(plLightColor.BackColor.R * (tbLightAmbient.Value / 100)), ToByte(plLightColor.BackColor.G * (tbLightAmbient.Value / 100)), ToByte(plLightColor.BackColor.B * (tbLightAmbient.Value / 100)))
        Simulation.Config.Lights(i).Range = ToSingle(txtLightRange.Text)
        Simulation.Config.Lights(i).AttenuationA = ToSingle(txtLightAttenuationA.Text)
        Simulation.Config.Lights(i).AttenuationB = ToSingle(txtLightAttenuationB.Text)
        Simulation.Config.Lights(i).AttenuationC = ToSingle(txtLightAttenuationC.Text)
        Simulation.Config.Lights(i).InnerCone = ToSingle(ToDouble(txtLightAngleInner.Text) * (Math.PI / 180))
        Simulation.Config.Lights(i).OuterCone = ToSingle(ToDouble(txtLightAngleOuter.Text) * (Math.PI / 180))
        Simulation.Config.Lights(i).Falloff = ToSingle(txtLightFalloff.Text)
    End Sub
    Private Sub CmdReplaceLight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLightReplace.Click
        If IsValidLight() = True Then
            Dim index As Integer
            index = listLights.SelectedIndex
            Simulation.Config.Lights(index).Color = plLightColor.BackColor
            Simulation.Config.Lights(index).Direction.X = ToSingle(txtLightDirectionX.Text)
            Simulation.Config.Lights(index).Direction.Y = ToSingle(txtLightDirectionY.Text)
            Simulation.Config.Lights(index).Direction.Z = ToSingle(txtLightDirectionZ.Text)
            Simulation.Config.Lights(index).Name = txtLightName.Text
            If cbLightType.SelectedIndex = 2 Then
                Simulation.Config.Lights(index).Type = Microsoft.DirectX.Direct3D.LightType.Spot
            ElseIf cbLightType.SelectedIndex = 1 Then
                Simulation.Config.Lights(index).Type = Microsoft.DirectX.Direct3D.LightType.Point
            Else
                Simulation.Config.Lights(index).Type = Microsoft.DirectX.Direct3D.LightType.Directional
            End If
            Simulation.Config.Lights(index).Position.X = ToSingle(txtLightPositionX.Text)
            Simulation.Config.Lights(index).Position.Y = ToSingle(txtLightPositionY.Text)
            Simulation.Config.Lights(index).Position.Z = ToSingle(txtLightPositionZ.Text)
            Simulation.Config.Lights(index).SpecularColor = Color.FromArgb(255, tbLightHighlight.Value, tbLightHighlight.Value, tbLightHighlight.Value)
            Simulation.Config.Lights(index).AmbientRatio = tbLightAmbient.Value
            Simulation.Config.Lights(index).AmbientColor = Color.FromArgb(255, ToByte(plLightColor.BackColor.R * (tbLightAmbient.Value / 100)), ToByte(plLightColor.BackColor.G * (tbLightAmbient.Value / 100)), ToByte(plLightColor.BackColor.B * (tbLightAmbient.Value / 100)))
            Simulation.Config.Lights(index).Range = ToSingle(txtLightRange.Text)
            Simulation.Config.Lights(index).AttenuationA = ToSingle(txtLightAttenuationA.Text)
            Simulation.Config.Lights(index).AttenuationB = ToSingle(txtLightAttenuationB.Text)
            Simulation.Config.Lights(index).AttenuationC = ToSingle(txtLightAttenuationC.Text)
            Simulation.Config.Lights(index).InnerCone = ToSingle(ToDouble(txtLightAngleInner.Text) * (Math.PI / 180))
            Simulation.Config.Lights(index).OuterCone = ToSingle(ToDouble(txtLightAngleOuter.Text) * (Math.PI / 180))
            Simulation.Config.Lights(index).Falloff = ToSingle(txtLightFalloff.Text)
            listLights.Items.RemoveAt(index)
            listLights.Items.Insert(index, Simulation.Config.Lights(index).Name)
            listLights.ClearSelected()
            ConfigModified = True
        End If
    End Sub
    Private Sub CmdRemoveLight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLightRemove.Click
        If MsgBox("Are you sure you want to remove the selected light?", MsgBoxStyle.YesNo, "Remove?") = vbYes Then
            Simulation.Config.RemoveLight(listLights.SelectedIndex)
            listLights.Items.RemoveAt(listLights.SelectedIndex)
            listLights.ClearSelected()
            ConfigModified = True
        End If
    End Sub
    Private Sub ChForces_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chForces.CheckedChanged
        CheckConditionals()
        ConfigModified = True
    End Sub
    Private Sub ChField_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chField.CheckedChanged
        CheckConditionals()
        ConfigModified = True
    End Sub
    Private Sub ChDrag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chDrag.CheckedChanged
        CheckConditionals()
        ConfigModified = True
    End Sub
    Private Sub StatusUpdate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusUpdate.Tick
        Try
            StatusUpdateCount += 1
            QueryPerformanceCounter(Simulation.RenderCounter.StopValue)
            Simulation.CalcCounter.StopValue = Simulation.RenderCounter.StopValue
            lblStat.Text = "Frames : " & Simulation.RenderCounter.FullCount & "  |  FPS : " & Int((Simulation.RenderCounter.FullCount - Simulation.RenderCounter.LastCount) / ((Simulation.RenderCounter.StopValue - Simulation.RenderCounter.StartValue) / Simulation.RenderCounter.Frequency)) & "  |  Calculations : " & Simulation.CalcCounter.FullCount & "  |  CPS : " & Int((Simulation.CalcCounter.FullCount - Simulation.CalcCounter.LastCount) / ((Simulation.CalcCounter.StopValue - Simulation.CalcCounter.StartValue) / Simulation.CalcCounter.Frequency))
            If StatusUpdateCount = 40 Then
                Simulation.CalcCounter.LastCount = Simulation.CalcCounter.FullCount
                Simulation.RenderCounter.LastCount = Simulation.RenderCounter.FullCount
                Simulation.CalcCounter.StartValue = Simulation.CalcCounter.StopValue
                Simulation.RenderCounter.StartValue = Simulation.RenderCounter.StopValue
                StatusUpdateCount = 0
            End If
        Catch ex As Exception
            lblStat.Text = ex.Message
        End Try
    End Sub
    Private Sub ChCollision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chCollision.CheckedChanged
        CheckConditionals()
        ConfigModified = True
    End Sub
    Private Sub Chbreakable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbreakable.CheckedChanged
        CheckConditionals()
        ConfigModified = True
    End Sub
    Private Sub TxtTimeStep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTimeStep.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtMaxCPS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLimitCalc.TextChanged
        ConfigModified = True
    End Sub
    Private Sub Txtmaxobjects_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLimitObjects.TextChanged
        ConfigModified = True
    End Sub
    Private Sub ChGravity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chGravity.CheckedChanged
        CheckConditionals()
        ConfigModified = True
    End Sub
    Private Sub ChElectrostatic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chElectrostatic.CheckedChanged
        CheckConditionals()
        ConfigModified = True
    End Sub
    Private Sub TxtFieldX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFieldX.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtFieldY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFieldY.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtFieldZ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFieldZ.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtFluidDensity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFluidDensity.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtFluidViscosity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFluidViscosity.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtDragCoeff_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDragCoeff.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtCoR_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoR.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtBreakMin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBreakMin.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtBreakAvg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBreakAvg.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtBreakMax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBreakMax.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtAddMin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddMin.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtAddAvg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddAvg.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtAddMax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddMax.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtWindowX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWindowX.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtWindowY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWindowY.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtScale_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScale.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtHFoV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHFoV.TextChanged
        ConfigModified = True
    End Sub
    Private Sub ChTrace_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chTrace.CheckedChanged
        ConfigModified = True
    End Sub
    Private Sub TxtCPosX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCPosX.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtCPosY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCPosY.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtCPosZ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCPosZ.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtCTargetX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCTargetX.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtCTargetY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCTargetY.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtCTargetZ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCTargetZ.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtCOrientX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCOrientX.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtCOrientY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCOrientY.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtCOrientZ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCOrientZ.TextChanged
        ConfigModified = True
    End Sub
    Private Sub CbIntegration_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbIntegration.SelectedIndexChanged
        ConfigModified = True
    End Sub
    Private Sub ChLights_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chLightsEnable.CheckedChanged
        CheckConditionals()
        ConfigModified = True
    End Sub
    Private Sub CbLightType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLightType.SelectedIndexChanged
        CheckConditionals()
    End Sub
    Private Sub ChVSync_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chVSync.CheckedChanged
        CheckConditionals()
        ConfigModified = True
    End Sub
    Private Sub TxtMaxFPS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaxFPS.TextChanged
        ConfigModified = True
    End Sub
    Private Sub CbShading_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbShading.SelectedIndexChanged
        ConfigModified = True
    End Sub
    Private Sub CbRender_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRender.SelectedIndexChanged
        CheckConditionals()
        ConfigModified = True
    End Sub
    Private Sub TxtVFoV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVFoV.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TbCameraSpeed_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCameraSpeed.Scroll
        ConfigModified = True
    End Sub
    Private Sub TxtPermittivity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPermittivity.TextChanged
        ConfigModified = True
    End Sub
    Private Sub CmdObjectMass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectMass.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectMass, cmdObjectMass, DirectCast(txtObjectMass, Control))
    End Sub

    Private Sub CmdObjectCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectCharge.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectCharge, cmdObjectCharge, DirectCast(txtObjectCharge, Control))
    End Sub
    Private Sub CmdObjectSizeX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectSizeX.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectSize.X, cmdObjectSizeX, DirectCast(txtObjectSizeX, Control))
    End Sub
    Private Sub CmdObjectPositionX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectPositionX.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectPosition.X, cmdObjectPositionX, DirectCast(txtObjectPositionX, Control))
    End Sub
    Private Sub CmdObjectPositionY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectPositionY.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectPosition.Y, cmdObjectPositionY, DirectCast(txtObjectPositionY, Control))
    End Sub
    Private Sub CmdObjectPositionZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectPositionZ.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectPosition.Z, cmdObjectPositionZ, DirectCast(txtObjectPositionZ, Control))
    End Sub
    Private Sub CmdObjectVelocityX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectVelocityX.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectVelocity.X, cmdObjectVelocityX, DirectCast(txtObjectVelocityX, Control))
    End Sub
    Private Sub CmdObjectVelocityY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectVelocityY.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectVelocity.Y, cmdObjectVelocityY, DirectCast(txtObjectVelocityY, Control))
    End Sub
    Private Sub CmdObjectVelocityZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectVelocityZ.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectVelocity.Z, cmdObjectVelocityZ, DirectCast(txtObjectVelocityZ, Control))
    End Sub
    Private Sub CmdObjectColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectColor.Click
        HandleDistributionFunctionClick(TargetType.Color, ObjectColor, cmdObjectColor, DirectCast(plObjectColor, Control))
    End Sub
    Private Sub CmdObjectHighlightColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectHighlightColor.Click
        HandleDistributionFunctionClick(TargetType.Color, ObjectHighlight, cmdObjectHighlightColor, DirectCast(plObjectHighlightColor, Control))
    End Sub
    Private Sub CmdObjectHighlightSharpness_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectHighlightSharpness.Click
        HandleDistributionFunctionClick(TargetType.TrackBar, ObjectSharpness, cmdObjectHighlightSharpness, DirectCast(tbObjectHighlightSharpness, Control))
    End Sub
    Private Sub CmdObjectTransparency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectTransparency.Click
        HandleDistributionFunctionClick(TargetType.TrackBar, ObjectTransparency, cmdObjectTransparency, DirectCast(tbObjectTransparency, Control))
    End Sub
    Private Sub CmdObjectNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectNumber.Click
        HandleDistributionFunctionClick(TargetType.ObjectCount, ObjectNumber, cmdObjectNumber, DirectCast(txtObjectNumber, Control))
    End Sub
    Private Sub PlObjectColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plObjectColor.Click
        ColorDialog.Color = plObjectColor.BackColor
        ColorDialog.ShowDialog()
        plObjectColor.BackColor = ColorDialog.Color
    End Sub
    Private Sub ListObjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listGroups.SelectedIndexChanged
        If listGroups.SelectedIndex <> -1 Then
            Dim index As Integer = listGroups.SelectedIndex
            chObjectAffected.Checked = Simulation.Config.Groups(index).Affected
            chObjectAffects.Checked = Simulation.Config.Groups(index).Affects
            chObjectWireframe.Checked = Simulation.Config.Groups(index).Wireframe
            cbObjectType.SelectedIndex = Simulation.Config.Groups(index).Type
            txtObjectName.Text = Simulation.Config.Groups(index).Name

            'NUMBER 
            ObjectNumber.Copy(Simulation.Config.Groups(index).Number)
            txtObjectNumber.Text = ObjectNumber.Value.ToString
            If ObjectNumber.UseFunction Then
                cmdObjectNumber.ForeColor = Color.RoyalBlue
            Else
                cmdObjectNumber.ForeColor = Color.Black
            End If

            'MASS
            ObjectMass.Copy(Simulation.Config.Groups(index).Mass)
            txtObjectMass.Text = ObjectMass.Value.ToString
            If ObjectMass.UseFunction Then
                cmdObjectMass.ForeColor = Color.RoyalBlue
            Else
                cmdObjectMass.ForeColor = Color.Black
            End If

            'CHARGE
            ObjectCharge.Copy(Simulation.Config.Groups(index).Charge)
            txtObjectCharge.Text = ObjectCharge.Value.ToString
            If ObjectCharge.UseFunction Then
                cmdObjectCharge.ForeColor = Color.RoyalBlue
            Else
                cmdObjectCharge.ForeColor = Color.Black
            End If

            'RADIUS
            ObjectRadius.Copy(Simulation.Config.Groups(index).Radius)
            txtObjectRadius.Text = ObjectRadius.Value.ToString
            If ObjectRadius.UseFunction Then
                cmdObjectRadius.ForeColor = Color.RoyalBlue
            Else
                cmdObjectRadius.ForeColor = Color.Black
            End If

            'SIZE
            ObjectSize.Copy(Simulation.Config.Groups(index).Size)
            txtObjectSizeX.Text = ObjectSize.X.Value.ToString
            If ObjectSize.X.UseFunction Then
                cmdObjectSizeX.ForeColor = Color.RoyalBlue
            Else
                cmdObjectSizeX.ForeColor = Color.Black
            End If
            txtObjectSizeY.Text = ObjectSize.Y.Value.ToString
            If ObjectSize.Y.UseFunction Then
                cmdObjectSizeY.ForeColor = Color.RoyalBlue
            Else
                cmdObjectSizeY.ForeColor = Color.Black
            End If
            txtObjectSizeZ.Text = ObjectSize.Z.Value.ToString
            If ObjectSize.Z.UseFunction Then
                cmdObjectSizeZ.ForeColor = Color.RoyalBlue
            Else
                cmdObjectSizeZ.ForeColor = Color.Black
            End If

            'ROTATION
            ObjectRotation.Copy(Simulation.Config.Groups(index).Rotation)
            txtObjectRotationX.Text = ObjectRotation.X.Value.ToString
            If ObjectRotation.X.UseFunction Then
                cmdObjectRotationX.ForeColor = Color.RoyalBlue
            Else
                cmdObjectRotationX.ForeColor = Color.Black
            End If
            txtObjectRotationY.Text = ObjectRotation.Y.Value.ToString
            If ObjectRotation.Y.UseFunction Then
                cmdObjectRotationY.ForeColor = Color.RoyalBlue
            Else
                cmdObjectRotationY.ForeColor = Color.Black
            End If
            txtObjectRotationZ.Text = ObjectRotation.Z.Value.ToString
            If ObjectRotation.Z.UseFunction Then
                cmdObjectRotationZ.ForeColor = Color.RoyalBlue
            Else
                cmdObjectRotationZ.ForeColor = Color.Black
            End If

            'NORMAL
            ObjectNormal.Copy(Simulation.Config.Groups(index).Normal)
            txtObjectNormalX.Text = ObjectNormal.X.Value.ToString
            If ObjectNormal.X.UseFunction Then
                cmdObjectNormalX.ForeColor = Color.RoyalBlue
            Else
                cmdObjectNormalX.ForeColor = Color.Black
            End If
            txtObjectNormalY.Text = ObjectNormal.Y.Value.ToString
            If ObjectNormal.Y.UseFunction Then
                cmdObjectNormalY.ForeColor = Color.RoyalBlue
            Else
                cmdObjectNormalY.ForeColor = Color.Black
            End If
            txtObjectNormalZ.Text = ObjectNormal.Z.Value.ToString
            If ObjectNormal.Z.UseFunction Then
                cmdObjectNormalZ.ForeColor = Color.RoyalBlue
            Else
                cmdObjectNormalZ.ForeColor = Color.Black
            End If

            'POSITION
            ObjectPosition.Copy(Simulation.Config.Groups(index).Position)
            txtObjectPositionX.Text = ObjectPosition.X.Value.ToString
            If ObjectPosition.X.UseFunction Then
                cmdObjectPositionX.ForeColor = Color.RoyalBlue
            Else
                cmdObjectPositionX.ForeColor = Color.Black
            End If
            txtObjectPositionY.Text = ObjectPosition.Y.Value.ToString
            If ObjectPosition.Y.UseFunction Then
                cmdObjectPositionY.ForeColor = Color.RoyalBlue
            Else
                cmdObjectPositionY.ForeColor = Color.Black
            End If
            txtObjectPositionZ.Text = ObjectPosition.Z.Value.ToString
            If ObjectPosition.Z.UseFunction Then
                cmdObjectPositionZ.ForeColor = Color.RoyalBlue
            Else
                cmdObjectPositionZ.ForeColor = Color.Black
            End If

            'VELOCITY
            ObjectVelocity.Copy(Simulation.Config.Groups(index).Velocity)
            txtObjectVelocityX.Text = ObjectVelocity.X.Value.ToString
            If ObjectVelocity.X.UseFunction Then
                cmdObjectVelocityX.ForeColor = Color.RoyalBlue
            Else
                cmdObjectVelocityX.ForeColor = Color.Black
            End If
            txtObjectVelocityY.Text = ObjectVelocity.Y.Value.ToString
            If ObjectVelocity.Y.UseFunction Then
                cmdObjectVelocityY.ForeColor = Color.RoyalBlue
            Else
                cmdObjectVelocityY.ForeColor = Color.Black
            End If
            txtObjectVelocityZ.Text = ObjectVelocity.Z.Value.ToString
            If ObjectVelocity.Z.UseFunction Then
                cmdObjectVelocityZ.ForeColor = Color.RoyalBlue
            Else
                cmdObjectVelocityZ.ForeColor = Color.Black
            End If

            'COLOR
            ObjectColor.Copy(Simulation.Config.Groups(index).Color)
            plObjectColor.BackColor = ObjectColor.Value
            If ObjectColor.UseFunction Then
                cmdObjectColor.ForeColor = Color.RoyalBlue
            Else
                cmdObjectColor.ForeColor = Color.Black
            End If

            'HIGHLIGHT
            ObjectHighlight.Copy(Simulation.Config.Groups(index).Highlight)
            plObjectHighlightColor.BackColor = ObjectHighlight.Value
            If ObjectHighlight.UseFunction Then
                cmdObjectHighlightColor.ForeColor = Color.RoyalBlue
            Else
                cmdObjectHighlightColor.ForeColor = Color.Black
            End If

            'SHARPNESS
            ObjectSharpness.Copy(Simulation.Config.Groups(index).Sharpness)
            tbObjectHighlightSharpness.Value = ToInt32(ObjectSharpness.Value)
            If ObjectSharpness.UseFunction Then
                cmdObjectHighlightSharpness.ForeColor = Color.RoyalBlue
            Else
                cmdObjectHighlightSharpness.ForeColor = Color.Black
            End If

            'REFLECTIVITY
            ObjectReflectivity.Copy(Simulation.Config.Groups(index).Reflectivity)
            tbObjectReflectivity.Value = ToInt32(ObjectReflectivity.Value)
            If ObjectReflectivity.UseFunction Then
                cmdObjectReflectivity.ForeColor = Color.RoyalBlue
            Else
                cmdObjectReflectivity.ForeColor = Color.Black
            End If

            'TRANSPARENCY
            ObjectTransparency.Copy(Simulation.Config.Groups(index).Transparency)
            tbObjectTransparency.Value = ToInt32(ObjectTransparency.Value)
            If ObjectTransparency.UseFunction Then
                cmdObjectTransparency.ForeColor = Color.RoyalBlue
            Else
                cmdObjectTransparency.ForeColor = Color.Black
            End If

            'REFRACTIVE INDEX
            ObjectRefractiveIndex.Copy(Simulation.Config.Groups(index).RefractiveIndex)
            txtObjectRefractiveIndex.Text = ObjectRefractiveIndex.Value.ToString
            If ObjectRefractiveIndex.UseFunction Then
                cmdObjectRefractiveIndex.ForeColor = Color.RoyalBlue
            Else
                cmdObjectRefractiveIndex.ForeColor = Color.Black
            End If
        Else
            ClearObjectForm()
        End If
        CheckConditionals()
    End Sub
    Private Sub ClearObjectForm()
        'Clear all Distribution Values
        ObjectNumber.Clear()
        ObjectMass.Clear()
        ObjectCharge.Clear()
        ObjectSize.Clear()
        ObjectRadius.Clear()
        ObjectRotation.Clear()
        ObjectNormal.Clear()
        ObjectPosition.Clear()
        ObjectVelocity.Clear()
        ObjectColor.Clear()
        ObjectHighlight.Clear()
        ObjectSharpness.Clear()
        ObjectReflectivity.Clear()
        ObjectTransparency.Clear()
        ObjectRefractiveIndex.Clear()

        'Reset the checkboxes
        chObjectAffected.Checked = True
        chObjectAffects.Checked = True
        chObjectWireframe.Checked = False

        'Clear the form's textbox values
        txtObjectName.Text = ""
        txtObjectNumber.Text = "1"
        txtObjectMass.Text = "1"
        txtObjectCharge.Text = "0"
        txtObjectRadius.Text = "1"
        txtObjectSizeX.Text = "5"
        txtObjectSizeY.Text = "5"
        txtObjectSizeZ.Text = "5"
        txtObjectRotationX.Text = "0"
        txtObjectRotationY.Text = "0"
        txtObjectRotationZ.Text = "0"
        txtObjectNormalX.Text = "0"
        txtObjectNormalY.Text = "1"
        txtObjectNormalZ.Text = "0"
        txtObjectPositionX.Text = "0"
        txtObjectPositionY.Text = "0"
        txtObjectPositionZ.Text = "0"
        txtObjectVelocityX.Text = "0"
        txtObjectVelocityY.Text = "0"
        txtObjectVelocityZ.Text = "0"
        txtObjectRefractiveIndex.Text = "1"

        'Reset the object type to default
        cbObjectType.SelectedIndex = 0

        'Reset the colors
        plObjectHighlightColor.BackColor = plObjectHighlightColor.ForeColor
        plObjectColor.BackColor = plObjectColor.ForeColor

        'Reset the trackbars
        tbObjectHighlightSharpness.Value = 50
        tbObjectTransparency.Value = 255
        tbObjectReflectivity.Value = 0

        'Reset the distribution buttons
        cmdObjectNumber.ForeColor = Color.Black
        cmdObjectMass.ForeColor = Color.Black
        cmdObjectCharge.ForeColor = Color.Black
        cmdObjectSizeX.ForeColor = Color.Black
        cmdObjectSizeY.ForeColor = Color.Black
        cmdObjectSizeZ.ForeColor = Color.Black
        cmdObjectRadius.ForeColor = Color.Black
        cmdObjectRotationX.ForeColor = Color.Black
        cmdObjectRotationY.ForeColor = Color.Black
        cmdObjectRotationZ.ForeColor = Color.Black
        cmdObjectNormalX.ForeColor = Color.Black
        cmdObjectNormalY.ForeColor = Color.Black
        cmdObjectNormalZ.ForeColor = Color.Black
        cmdObjectPositionX.ForeColor = Color.Black
        cmdObjectPositionY.ForeColor = Color.Black
        cmdObjectPositionZ.ForeColor = Color.Black
        cmdObjectVelocityX.ForeColor = Color.Black
        cmdObjectVelocityY.ForeColor = Color.Black
        cmdObjectVelocityZ.ForeColor = Color.Black
        cmdObjectColor.ForeColor = Color.Black
        cmdObjectHighlightColor.ForeColor = Color.Black
        cmdObjectHighlightSharpness.ForeColor = Color.Black
        cmdObjectTransparency.ForeColor = Color.Black
        cmdObjectReflectivity.ForeColor = Color.Black
        cmdObjectRefractiveIndex.ForeColor = Color.Black
    End Sub
    Private Function ObjectRoomLeft() As Integer
        Dim CurrentObjects As Integer = 0
        'TODO move this the distribution object
        For i = 0 To Simulation.Config.GroupCount - 1
            If Simulation.Config.Groups(i).Number.UseFunction Then
                If Simulation.Config.Groups(i).Number.Random Then
                    CurrentObjects += Simulation.Config.Groups(i).Number.RandomMax
                Else
                    CurrentObjects += Simulation.Config.Groups(i).Number.NormalMax
                End If
                'TODO: Figure out Polynomial & Even distribution max
            Else
                CurrentObjects += Simulation.Config.Groups(i).Number.Value
            End If
        Next
        Return ToInt32(txtLimitObjects.Text) - CurrentObjects
    End Function
    Private Sub CmdObjectAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGroupAdd.Click
        If Not IsValidGroup() Or Not IsValidMaxObjects() Then Exit Sub

        Dim CurrentObjects As Integer
        If cmdObjectNumber.ForeColor = Color.Black Then
            CurrentObjects = ToInt32(txtObjectNumber.Text)
        Else
            If ObjectNumber.Random Then
                CurrentObjects = ObjectNumber.RandomMax
            Else
                CurrentObjects = ObjectNumber.NormalMax
            End If
        End If

        If CurrentObjects > ObjectRoomLeft() Then
            MsgBox("Objects are currently limited to " & ToInt32(txtLimitObjects.Text) & ".", MsgBoxStyle.Exclamation, "Warning")
            Exit Sub
        End If

        Simulation.Config.EnlargeGroups()
        InsertGroup(Simulation.Config.GroupCount - 1)
        listGroups.Items.Insert(listGroups.Items.Count, Simulation.Config.Groups(Simulation.Config.GroupCount - 1).Name)
        listGroups.ClearSelected()
        ConfigModified = True
    End Sub
    Private Sub InsertGroup(ByRef i As Integer)

        Simulation.Config.Groups(i).Name = txtObjectName.Text
        Simulation.Config.Groups(i).Affected = chObjectAffected.Checked
        Simulation.Config.Groups(i).Affects = chObjectAffects.Checked
        Simulation.Config.Groups(i).Wireframe = chObjectWireframe.Checked
        If cbObjectType.SelectedIndex = 0 Then
            Simulation.Config.Groups(i).Type = ObjectType.Sphere
        ElseIf cbObjectType.SelectedIndex = 1 Then
            Simulation.Config.Groups(i).Type = ObjectType.Box
        Else
            Simulation.Config.Groups(i).Type = ObjectType.InfinitePlane
        End If

        ObjectNumber.Value = ToInt32(txtObjectNumber.Text)
        Simulation.Config.Groups(i).Number.Copy(ObjectNumber)

        ObjectMass.Value = ToDouble(txtObjectMass.Text)
        Simulation.Config.Groups(i).Mass.Copy(ObjectMass)

        ObjectCharge.Value = ToDouble(txtObjectCharge.Text)
        Simulation.Config.Groups(i).Charge.Copy(ObjectCharge)

        ObjectSize.X.Value = ToDouble(txtObjectSizeX.Text)
        ObjectSize.Y.Value = ToDouble(txtObjectSizeY.Text)
        ObjectSize.Z.Value = ToDouble(txtObjectSizeZ.Text)
        Simulation.Config.Groups(i).Size.Copy(ObjectSize)

        ObjectRadius.Value = ToDouble(txtObjectRadius.Text)
        Simulation.Config.Groups(i).Radius.Copy(ObjectRadius)

        ObjectRotation.X.Value = ToDouble(txtObjectRotationX.Text)
        ObjectRotation.Y.Value = ToDouble(txtObjectRotationY.Text)
        ObjectRotation.Z.Value = ToDouble(txtObjectRotationZ.Text)
        Simulation.Config.Groups(i).Rotation.Copy(ObjectRotation)

        ObjectNormal.X.Value = ToDouble(txtObjectNormalX.Text)
        ObjectNormal.Y.Value = ToDouble(txtObjectNormalY.Text)
        ObjectNormal.Z.Value = ToDouble(txtObjectNormalZ.Text)
        Simulation.Config.Groups(i).Normal.Copy(ObjectNormal)

        ObjectPosition.X.Value = ToDouble(txtObjectPositionX.Text)
        ObjectPosition.Y.Value = ToDouble(txtObjectPositionY.Text)
        ObjectPosition.Z.Value = ToDouble(txtObjectPositionZ.Text)
        Simulation.Config.Groups(i).Position.Copy(ObjectPosition)

        ObjectVelocity.X.Value = ToDouble(txtObjectVelocityX.Text)
        ObjectVelocity.Y.Value = ToDouble(txtObjectVelocityY.Text)
        ObjectVelocity.Z.Value = ToDouble(txtObjectVelocityZ.Text)
        Simulation.Config.Groups(i).Velocity.Copy(ObjectVelocity)

        ObjectColor.Value = plObjectColor.BackColor
        Simulation.Config.Groups(i).Color.Copy(ObjectColor)

        ObjectHighlight.Value = plObjectHighlightColor.BackColor
        Simulation.Config.Groups(i).Highlight.Copy(ObjectHighlight)

        ObjectRefractiveIndex.Value = ToDouble(txtObjectRefractiveIndex.Text)
        Simulation.Config.Groups(i).RefractiveIndex.Copy(ObjectRefractiveIndex)

        ObjectTransparency.Value = ToDouble(tbObjectTransparency.Value)
        Simulation.Config.Groups(i).Transparency.Copy(ObjectTransparency)

        ObjectSharpness.Value = ToSingle(tbObjectHighlightSharpness.Value)
        Simulation.Config.Groups(i).Sharpness.Copy(ObjectSharpness)

        ObjectReflectivity.Value = ToSingle(tbObjectReflectivity.Value)
        Simulation.Config.Groups(i).Reflectivity.Copy(ObjectReflectivity)
    End Sub
    Private Function IsValidMaxObjects() As Boolean
        If Not IsNumeric(txtLimitObjects.Text) Then
            MsgBox("Max Objects must have a numeric value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtLimitObjects.Text) <> Int(ToDouble(txtLimitObjects.Text)) Then
            MsgBox("Max Objects must be of integer value.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        If ToDouble(txtLimitObjects.Text) < 0 Then
            MsgBox("Max Objects must be greater than or equal to one.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
        Return True
    End Function
    Private Sub CmdGroupReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGroupReplace.Click
        If Not IsValidGroup() Or Not IsValidMaxObjects() Then Exit Sub
        Dim index As Integer
        index = listGroups.SelectedIndex
        Dim CurrentObjects As Integer
        If cmdObjectNumber.ForeColor = Color.Black Then
            CurrentObjects = ToInt32(txtObjectNumber.Text)
        Else
            If ObjectNumber.Random Then
                CurrentObjects = ObjectNumber.RandomMax
            Else
                CurrentObjects = ObjectNumber.NormalMax
            End If
        End If
        If Simulation.Config.Groups(index).Number.UseFunction Then
            If ObjectNumber.Random Then
                CurrentObjects -= Simulation.Config.Groups(index).Number.RandomMax
            Else
                CurrentObjects -= Simulation.Config.Groups(index).Number.NormalMax
            End If
        Else
            CurrentObjects -= Simulation.Config.Groups(index).Number.Value
        End If
        If CurrentObjects > ObjectRoomLeft() Then
            MsgBox("Objects are currently limited to " & ToInt32(txtLimitObjects.Text) & ".", MsgBoxStyle.Exclamation, "Warning")
            Exit Sub
        End If

        InsertGroup(index)
        listGroups.Items.RemoveAt(index)
        listGroups.Items.Insert(index, Simulation.Config.Groups(index).Name)
        listGroups.ClearSelected()
        ConfigModified = True
    End Sub
    Private Sub CmdRemoveGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGroupRemove.Click
        If MsgBox("Are you sure you want to remove the selected group?", MsgBoxStyle.YesNo, "Remove?") = MsgBoxResult.No Then Exit Sub
        Simulation.Config.RemoveGroup(listGroups.SelectedIndex)
        listGroups.Items.RemoveAt(listGroups.SelectedIndex)
        listGroups.ClearSelected()

        ConfigModified = True
    End Sub
    Private Sub PlObjectHighlightColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plObjectHighlightColor.Click
        ColorDialog.Color = plObjectHighlightColor.BackColor
        ColorDialog.ShowDialog()
        plObjectHighlightColor.BackColor = ColorDialog.Color
    End Sub

    Private Sub ChobjectAffected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chObjectAffected.CheckedChanged
        CheckConditionals()
    End Sub
    Private Sub ChobjectAffects_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chObjectAffects.CheckedChanged
        CheckConditionals()
    End Sub
    Private Sub CbObjectType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbObjectType.SelectedIndexChanged
        CheckConditionals()
    End Sub
    Private Sub CmdObjectSizeY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectSizeY.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectSize.Y, cmdObjectSizeY, DirectCast(txtObjectSizeY, Control))
    End Sub
    Private Sub CmdObjectSizeZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectSizeZ.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectSize.Z, cmdObjectSizeZ, DirectCast(txtObjectSizeZ, Control))
    End Sub
    Private Sub CmdObjectRadius_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectRadius.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectRadius, cmdObjectRadius, DirectCast(txtObjectRadius, Control))
    End Sub
    Private Sub CmdObjectNormalX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectNormalX.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectNormal.X, cmdObjectNormalX, DirectCast(txtObjectNormalX, Control))
    End Sub
    Private Sub CmdObjectNormalY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectNormalY.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectNormal.Y, cmdObjectNormalY, DirectCast(txtObjectNormalY, Control))
    End Sub
    Private Sub CmdObjectNormalZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectNormalZ.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectNormal.Z, cmdObjectNormalZ, DirectCast(txtObjectNormalZ, Control))
    End Sub
    Private Sub CmdObjectRotationX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectRotationX.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectRotation.X, cmdObjectRotationX, DirectCast(txtObjectRotationX, Control))
    End Sub
    Private Sub CmdObjectRotationY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectRotationY.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectRotation.Y, cmdObjectRotationY, DirectCast(txtObjectRotationY, Control))
    End Sub
    Private Sub CmdObjectRotationZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectRotationZ.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectRotation.Z, cmdObjectRotationZ, DirectCast(txtObjectRotationZ, Control))
    End Sub
    Private Sub CmdObjectReflectivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectReflectivity.Click
        HandleDistributionFunctionClick(TargetType.TrackBar, ObjectReflectivity, cmdObjectReflectivity, DirectCast(tbObjectReflectivity, Control))
    End Sub
    Private Sub CmdObjectRefractiveIndex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObjectRefractiveIndex.Click
        HandleDistributionFunctionClick(TargetType.Numeric, ObjectRefractiveIndex, cmdObjectRefractiveIndex, DirectCast(txtObjectRefractiveIndex, Control))
    End Sub

    Private Sub HandleDistributionFunctionClick(Of t)(ByRef type As TargetType, ByRef distConf As SimulationConfigDistribution(Of t), ByRef cmdButton As Button, ByRef control As Control)
        Distribution.Type = type
        distConf.SendToDistributionForm()
        If ShowDistribution() = True Then ' Did not Cancel
            distConf.LoadFromDistributionForm()
            cmdButton.ForeColor = If(distConf.UseFunction, Color.RoyalBlue, Color.Black)

            If (TypeOf control Is Button) Then
                EnableColorBox(DirectCast(control, Button), Not distConf.UseFunction)
            Else
                control.Enabled = Not distConf.UseFunction
            End If
        End If
    End Sub
    Private Function ShowDistribution() As Boolean
        If Distribution.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return True
        End If
        Return False
    End Function
    Private Sub TbPolys_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPolys.Scroll
        ConfigModified = True
    End Sub

    Private Sub TxtRenderThreads_TextChanged(sender As Object, e As EventArgs) Handles txtRenderThreads.TextChanged
        ConfigModified = True
    End Sub

End Class
