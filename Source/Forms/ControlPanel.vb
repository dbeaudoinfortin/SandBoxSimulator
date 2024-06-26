﻿Imports System.IO
Imports System.Windows.Forms
Imports System.Windows.Forms.AxHost
Imports SharpDX.Direct3D9

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
    Private Function SaveTextToFile(ByVal strData As String, ByVal FullPath As String, Optional ByRef ErrInfo As String = "") As Boolean
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
    Private Function IsValidSettings() As Boolean
        If Not IsValidMaxObjects() Then Return False

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
        If ToDouble(txtLimitCalc.Text) < 0 Or ToDouble(txtLimitCalc.Text) > 1000000 Then
            MsgBox("Limit Calculations must be equal to or greater than zero and less than or equal to 1 million.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        'TODO: Should sum up the count of all the objects of all the groups
        If ToInt32(txtLimitObjects.Text) < Simulation.Config.ObjectGroups.Count Then
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
    Private Function IsValidObjectGroup() As Boolean

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

        Dim isDirectionalLight As Boolean = (cbLightType.SelectedIndex = 0)
        Dim isPointLight As Boolean = (cbLightType.SelectedIndex = 1)
        Dim isSpotLight As Boolean = (cbLightType.SelectedIndex = 2)

        If txtLightName.Text = "" Then
            MsgBox("The light must have a name.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If isDirectionalLight Or isSpotLight Then
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
        End If

        If (isSpotLight Or isPointLight) Then
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
        End If

        If (isSpotLight) Then
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
        End If
        Return True
    End Function
    Private Function IsValidDistribution() As Boolean
        Return True
    End Function
    Private Sub SetAllEnabled(ByVal State As Boolean)
        'Paint the controls only at the end
        Me.SuspendLayout()

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

        'position - Applies to all
        cmdObjectPositionX.Enabled = State
        cmdObjectPositionY.Enabled = State
        cmdObjectPositionZ.Enabled = State

        'velocity - Applies to all
        cmdObjectVelocityX.Enabled = State
        cmdObjectVelocityY.Enabled = State
        cmdObjectVelocityZ.Enabled = State

        'colour - Applies to all
        cmdObjectColor.Enabled = State

        'transparency - Applies to all
        cmdObjectTransparency.Enabled = State
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
            cbShading.Enabled = State
            tbPolys.Enabled = State
            chVSync.Enabled = State
            txtMaxFPS.Enabled = State
            txtRenderThreads.Enabled = State
            chObjectWireframe.Enabled = State
            chObjectPoints.Enabled = State

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

            chObjectAffected.Enabled = State
            chObjectAffects.Enabled = State
        Else
            CheckConditionals()
        End If

        'Paint the controls only at the end
        Me.ResumeLayout()
    End Sub
    Private Sub CheckConditionals()
        'Don't do this during loading
        If Not hasLoaded Then Return

        'Paint the controls only at the end
        Me.SuspendLayout()

        'TODO: Let's simply this
        'RENDER
        Dim isDXRender As Boolean = cbRender.SelectedIndex < 2 'Using Direct X
        Dim isLightsEnabled As Boolean = chLightsEnable.Checked
        Dim isFancyDXLights As Boolean = isDXRender And isLightsEnabled
        Dim isRayTraceLights As Boolean = (Not isDXRender) And isLightsEnabled

        txtRenderThreads.Enabled = Not isDXRender
        tbPolys.Enabled = isDXRender
        chVSync.Enabled = isDXRender
        cbShading.Enabled = isFancyDXLights

        chObjectWireframe.Enabled = isDXRender
        chObjectPoints.Enabled = isDXRender

        If isDXRender Then 'Using Direct X
            txtRenderThreads.Text = "1"
            txtMaxFPS.Enabled = Not chVSync.Checked 'Using Vsync
        Else 'Ray
            txtMaxFPS.Enabled = True
        End If

        'CAMERA
        tbCameraSpeed.Enabled = chCamera.Checked
        txtCPosX.Enabled = chCamera.Checked
        txtCPosY.Enabled = chCamera.Checked
        txtCPosZ.Enabled = chCamera.Checked
        txtCTargetX.Enabled = chCamera.Checked
        txtCTargetY.Enabled = chCamera.Checked
        txtCTargetZ.Enabled = chCamera.Checked
        txtCOrientX.Enabled = chCamera.Checked
        txtCOrientY.Enabled = chCamera.Checked
        txtCOrientZ.Enabled = chCamera.Checked

        Dim isDirectionalLight As Boolean = (cbLightType.SelectedIndex = 0)
        Dim isPointLight As Boolean = (cbLightType.SelectedIndex = 1)
        Dim isSpotLight As Boolean = (cbLightType.SelectedIndex = 2)

        'LIGHTS
        cbLightType.Enabled = isLightsEnabled
        txtLightDirectionX.Enabled = isLightsEnabled And (isDirectionalLight Or isSpotLight)
        txtLightDirectionY.Enabled = isLightsEnabled And (isDirectionalLight Or isSpotLight)
        txtLightDirectionZ.Enabled = isLightsEnabled And (isDirectionalLight Or isSpotLight)
        txtLightPositionX.Enabled = isLightsEnabled And (isSpotLight Or isPointLight)
        txtLightPositionY.Enabled = isLightsEnabled And (isSpotLight Or isPointLight)
        txtLightPositionZ.Enabled = isLightsEnabled And (isSpotLight Or isPointLight)
        txtLightAttenuationA.Enabled = isLightsEnabled And (isSpotLight Or isPointLight)
        txtLightAttenuationB.Enabled = isLightsEnabled And (isSpotLight Or isPointLight)
        txtLightAttenuationC.Enabled = isLightsEnabled And (isSpotLight Or isPointLight)
        txtLightAngleInner.Enabled = isLightsEnabled And isSpotLight
        txtLightAngleOuter.Enabled = isLightsEnabled And isSpotLight
        txtLightFalloff.Enabled = isLightsEnabled And isSpotLight
        txtLightRange.Enabled = isFancyDXLights And (Not isDirectionalLight)

        listLights.Enabled = isLightsEnabled
        cmdLightAdd.Enabled = isLightsEnabled
        tbLightAmbient.Enabled = isLightsEnabled
        txtLightName.Enabled = isLightsEnabled
        EnableColorBox(plLightColor, isLightsEnabled)
        tbLightHighlight.Enabled = isFancyDXLights

        cmdLightReplace.Enabled = isLightsEnabled And (listLights.SelectedIndex <> -1)  'Light is selected
        cmdLightRemove.Enabled = isLightsEnabled And (listLights.SelectedIndex <> -1)  'Light is selected

        'FORCES
        Dim isForcesEnabled As Boolean = chForces.Checked
        Dim isAnyForceEnabled As Boolean = isForcesEnabled And (chGravity.Checked Or chElectrostatic.Checked Or chField.Checked Or chDrag.Checked)
        chGravity.Enabled = isForcesEnabled
        chField.Enabled = isForcesEnabled
        chElectrostatic.Enabled = isForcesEnabled
        chDrag.Enabled = isForcesEnabled
        cbIntegration.Enabled = isAnyForceEnabled
        txtPermittivity.Enabled = isForcesEnabled And chElectrostatic.Checked
        txtFieldX.Enabled = isForcesEnabled And chField.Checked
        txtFieldY.Enabled = isForcesEnabled And chField.Checked
        txtFieldZ.Enabled = isForcesEnabled And chField.Checked
        txtDragCoeff.Enabled = isForcesEnabled And chDrag.Checked
        txtFluidDensity.Enabled = isForcesEnabled And chDrag.Checked
        txtFluidViscosity.Enabled = isForcesEnabled And chDrag.Checked

        'COLLISIONS
        Dim isCollisionsEnabled As Boolean = chCollision.Checked
        txtCoR.Enabled = isCollisionsEnabled
        chInterpolate.Enabled = isCollisionsEnabled
        chbreakable.Enabled = isCollisionsEnabled
        txtAddAvg.Enabled = isCollisionsEnabled And chbreakable.Checked
        txtAddMax.Enabled = isCollisionsEnabled And chbreakable.Checked
        txtAddMin.Enabled = isCollisionsEnabled And chbreakable.Checked
        txtBreakAvg.Enabled = isCollisionsEnabled And chbreakable.Checked
        txtBreakMin.Enabled = isCollisionsEnabled And chbreakable.Checked
        txtBreakMax.Enabled = isCollisionsEnabled And chbreakable.Checked

        'OBJECTS
        cmdGroupRemove.Enabled = (listGroups.SelectedIndex <> -1) 'An object group is selected
        cmdGroupReplace.Enabled = (listGroups.SelectedIndex <> -1) 'An object group is selected
        txtObjectNumber.Enabled = (cmdObjectNumber.ForeColor = Color.Black) 'number

        Dim isObjectSphere As Boolean = (cbObjectType.SelectedIndex = 0)
        Dim isObjectBox As Boolean = (cbObjectType.SelectedIndex = 1)
        Dim isObjectPlane As Boolean = (cbObjectType.SelectedIndex = 2)
        Dim isObjectInfinitePlane As Boolean = (cbObjectType.SelectedIndex = 3)

        'affected - does not apply to planes
        chObjectAffected.Enabled = (isObjectSphere Or isObjectBox) And (isAnyForceEnabled Or isCollisionsEnabled)
        chObjectAffects.Enabled = (isAnyForceEnabled Or isCollisionsEnabled)

        'charge
        Dim isObjectChargeEnabled As Boolean = isForcesEnabled And chElectrostatic.Checked And (chObjectAffected.Checked Or chObjectAffects.Checked)
        cmdObjectCharge.Enabled = isObjectChargeEnabled
        txtObjectCharge.Enabled = isObjectChargeEnabled And (cmdObjectCharge.ForeColor = Color.Black)

        'mass
        Dim isObjectMassEnabled As Boolean = (isObjectSphere Or isObjectBox) And (chObjectAffected.Checked Or chObjectAffects.Checked) And (isAnyForceEnabled Or isCollisionsEnabled)
        cmdObjectMass.Enabled = isObjectMassEnabled
        txtObjectMass.Enabled = isObjectMassEnabled And (cmdObjectMass.ForeColor = Color.Black)

        'rotation, infinite plane has this replaced with a normal vector
        lblObjectRotation.Visible = Not isObjectInfinitePlane
        cmdObjectRotationX.Visible = Not isObjectInfinitePlane
        cmdObjectRotationY.Visible = Not isObjectInfinitePlane
        cmdObjectRotationZ.Visible = Not isObjectInfinitePlane
        txtObjectRotationX.Visible = Not isObjectInfinitePlane
        txtObjectRotationY.Visible = Not isObjectInfinitePlane
        txtObjectRotationZ.Visible = Not isObjectInfinitePlane
        tblRotation.Visible = Not isObjectInfinitePlane

        cmdObjectRotationX.Enabled = isObjectBox Or isObjectPlane
        cmdObjectRotationY.Enabled = isObjectBox Or isObjectPlane
        cmdObjectRotationZ.Enabled = isObjectBox Or isObjectPlane
        txtObjectRotationX.Enabled = (isObjectBox Or isObjectPlane) And (cmdObjectRotationX.ForeColor = Color.Black)
        txtObjectRotationY.Enabled = (isObjectBox Or isObjectPlane) And (cmdObjectRotationY.ForeColor = Color.Black)
        txtObjectRotationZ.Enabled = (isObjectBox Or isObjectPlane) And (cmdObjectRotationZ.ForeColor = Color.Black)

        'orientation
        lblObjectNormal.Visible = isObjectInfinitePlane
        cmdObjectNormalX.Visible = isObjectInfinitePlane
        cmdObjectNormalY.Visible = isObjectInfinitePlane
        cmdObjectNormalZ.Visible = isObjectInfinitePlane
        txtObjectNormalX.Visible = isObjectInfinitePlane
        txtObjectNormalY.Visible = isObjectInfinitePlane
        txtObjectNormalZ.Visible = isObjectInfinitePlane
        tblOrientation.Visible = isObjectInfinitePlane

        cmdObjectNormalX.Enabled = isObjectInfinitePlane
        cmdObjectNormalY.Enabled = isObjectInfinitePlane
        cmdObjectNormalZ.Enabled = isObjectInfinitePlane
        txtObjectNormalX.Enabled = isObjectInfinitePlane And (cmdObjectNormalX.ForeColor = Color.Black)
        txtObjectNormalY.Enabled = isObjectInfinitePlane And (cmdObjectNormalY.ForeColor = Color.Black)
        txtObjectNormalZ.Enabled = isObjectInfinitePlane And (cmdObjectNormalZ.ForeColor = Color.Black)

        'radius
        lblObjectRadius.Visible = isObjectSphere
        cmdObjectRadius.Visible = isObjectSphere
        txtObjectRadius.Visible = isObjectSphere
        cmdObjectRadius.Enabled = isObjectSphere
        txtObjectRadius.Enabled = isObjectSphere And (cmdObjectRadius.ForeColor = Color.Black)

        'size
        lblObjectSize.Visible = Not isObjectSphere
        cmdObjectSizeX.Visible = Not isObjectSphere
        cmdObjectSizeY.Visible = Not isObjectSphere
        cmdObjectSizeZ.Visible = Not isObjectSphere
        txtObjectSizeX.Visible = Not isObjectSphere
        txtObjectSizeY.Visible = Not isObjectSphere
        txtObjectSizeZ.Visible = Not isObjectSphere
        tblSize.Visible = Not isObjectSphere

        cmdObjectSizeX.Enabled = isObjectBox Or isObjectPlane
        cmdObjectSizeY.Enabled = isObjectBox Or isObjectPlane
        cmdObjectSizeZ.Enabled = isObjectBox 'Planes are 2 dimensional objects
        txtObjectSizeX.Enabled = (isObjectBox Or isObjectPlane) And (cmdObjectSizeX.ForeColor = Color.Black)
        txtObjectSizeY.Enabled = (isObjectBox Or isObjectPlane) And (cmdObjectSizeY.ForeColor = Color.Black)
        txtObjectSizeZ.Enabled = isObjectBox And (cmdObjectSizeZ.ForeColor = Color.Black)

        'position
        txtObjectPositionX.Enabled = (cmdObjectPositionX.ForeColor = Color.Black)
        txtObjectPositionY.Enabled = (cmdObjectPositionY.ForeColor = Color.Black)
        txtObjectPositionZ.Enabled = (cmdObjectPositionZ.ForeColor = Color.Black)

        'velocity
        txtObjectVelocityX.Enabled = (cmdObjectVelocityX.ForeColor = Color.Black)
        txtObjectVelocityY.Enabled = (cmdObjectVelocityY.ForeColor = Color.Black)
        txtObjectVelocityZ.Enabled = (cmdObjectVelocityZ.ForeColor = Color.Black)

        'color
        EnableColorBox(plObjectColor, cmdObjectColor.ForeColor = Color.Black)

        'highlight color
        cmdObjectHighlightColor.Enabled = isFancyDXLights
        EnableColorBox(plObjectHighlightColor, isFancyDXLights And (cmdObjectHighlightColor.ForeColor = Color.Black))

        'highlight sharpness
        cmdObjectHighlightSharpness.Enabled = isFancyDXLights
        tbObjectHighlightSharpness.Enabled = isFancyDXLights And (cmdObjectHighlightSharpness.ForeColor = Color.Black)

        'reflectivity
        cmdObjectReflectivity.Enabled = isFancyDXLights
        tbObjectReflectivity.Enabled = isFancyDXLights And (cmdObjectReflectivity.ForeColor = Color.Black)

        'transparency
        cmdObjectTransparency.Enabled = True
        tbObjectTransparency.Enabled = (cmdObjectTransparency.ForeColor = Color.Black)

        'refractive index
        cmdObjectRefractiveIndex.Enabled = isRayTraceLights
        txtObjectRefractiveIndex.Enabled = isRayTraceLights And (cmdObjectRefractiveIndex.ForeColor = Color.Black)

        'Paint the controls only at the end
        Me.ResumeLayout()
    End Sub
    Private Sub UpdateSimulation()
        Simulation.Config.Render.Mode = ToByte(cbRender.SelectedIndex)
        Simulation.Config.Settings.MaxObjects = ToInt32(txtLimitObjects.Text)
        Simulation.Config.Settings.TimeStep = ToDouble(txtTimeStep.Text)
        Simulation.Config.Render.WorldScale = ToSingle(txtScale.Text)
        Simulation.Config.Settings.MaxCPS = ToDouble(txtLimitCalc.Text)
        Simulation.Config.Render.BackgroundColor = ConvertColorToRawColorBGRA(plRenderBackColor.BackColor)
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
            Simulation.Config.Render.Shading = SharpDX.Direct3D9.ShadeMode.Flat
        Else
            Simulation.Config.Render.Shading = SharpDX.Direct3D9.ShadeMode.Gouraud
        End If
    End Sub
    Private Sub UpdateForm()

        'Paint the controls only at the end
        Me.SuspendLayout()

        '----SIMULATION----
        cbIntegration.SelectedIndex = Simulation.Config.Settings.IntegrationMethod
        txtLimitObjects.Text = Simulation.Config.Settings.MaxObjects.ToString
        txtTimeStep.Text = Simulation.Config.Settings.TimeStep.ToString
        txtScale.Text = Simulation.Config.Render.WorldScale.ToString
        txtLimitCalc.Text = Simulation.Config.Settings.MaxCPS.ToString
        plRenderBackColor.BackColor = ConvertRawColorBGRAToColor(Simulation.Config.Render.BackgroundColor)

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

        If Simulation.Config.Render.Shading = ShadeMode.Flat Then
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
        For i = 0 To Simulation.Config.LightConfigs.Count - 1
            listLights.Items.Insert(listLights.Items.Count, Simulation.Config.LightConfigs(i).Name)
        Next
        listLights.ClearSelected()
        ClearLightForm()

        '----OBJECTS----
        listGroups.Items.Clear()
        For i = 0 To Simulation.Config.ObjectGroups.Count - 1
            listGroups.Items.Insert(listGroups.Items.Count, Simulation.Config.ObjectGroups(i).Name)
        Next
        listGroups.ClearSelected()
        ClearObjectForm()

        'Paint the controls only at the end
        Me.ResumeLayout()

    End Sub
    Private Sub ClearLightForm()
        'Paint the controls only at the end
        Me.SuspendLayout()

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

        'Paint the controls only at the end
        Me.ResumeLayout()
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
            MsgBox("Unable To Query the Performance Counter)", MsgBoxStyle.Critical, "Error")
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
            If Not IsValidSettings() Then Exit Sub
            If ObjectRoomLeft() < 0 Then
                MsgBox("The number Of objects In the simulation surpasses the maximum number of objects", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
            If Simulation.Config.ObjectGroups.Count <= 0 Then
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
            Simulation.StopSimulation()
            EndSimulationForm()
        End If
    End Sub

    Public Sub EndSimulationForm()
        If Output.Visible Then
            Output.Hide()
        End If

        Simulation.Copy(Backup)
        SetAllEnabled(True)
        CmdSaveOut.Enabled = False
        cmdStart.Text = "&Start Simulation"
    End Sub
    Private Sub CmdSaveOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSaveOut.Click
        SaveDialog.FileName = ""
        SaveDialog.DefaultExt = "bmp"
        SaveDialog.Title = "Save Output Image"
        SaveDialog.Filter = "Bitmap (*.bmp)|*.bmp"
        SaveDialog.ShowDialog()
        If SaveDialog.FileName <> "" Then
            SaveDialog.InitialDirectory = Path.GetDirectoryName(SaveDialog.FileName)
            Dim BackBuffer As Surface
            BackBuffer = Simulation.Render.Device.GetBackBuffer(0, 0)
            Using fileStream As FileStream = File.Create(SaveDialog.FileName)
                Surface.ToStream(BackBuffer, ImageFileFormat.Png).CopyTo(fileStream)
            End Using
            BackBuffer.Dispose()
        End If
    End Sub
    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If IsValidSettings() = True Then
            SaveDialog.FileName = ""
            SaveDialog.DefaultExt = "PR4"
            SaveDialog.Title = "Save Simulation"
            SaveDialog.Filter = "PR4 File (*.PR4)|*.PR4"
            SaveDialog.ShowDialog()
            If SaveDialog.FileName <> "" Then
                SaveDialog.InitialDirectory = Path.GetDirectoryName(SaveDialog.FileName)
                Try
                    UpdateSimulation()
                    Dim Err As String = ""
                    If SaveTextToFile(Simulation.Config.ToString(), SaveDialog.FileName, Err) = False Then
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
            OpenDialog.InitialDirectory = Path.GetDirectoryName(OpenDialog.FileName)
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

        'Paint the controls only at the end
        Me.SuspendLayout()
        If listLights.SelectedIndex <> -1 Then
            txtLightName.Text = Simulation.Config.LightConfigs(listLights.SelectedIndex).Name
            plLightColor.BackColor = Simulation.Config.LightConfigs(listLights.SelectedIndex).Color
            txtLightDirectionX.Text = Simulation.Config.LightConfigs(listLights.SelectedIndex).Direction.X.ToString
            txtLightDirectionY.Text = Simulation.Config.LightConfigs(listLights.SelectedIndex).Direction.Y.ToString
            txtLightDirectionZ.Text = Simulation.Config.LightConfigs(listLights.SelectedIndex).Direction.Z.ToString
            If Simulation.Config.LightConfigs(listLights.SelectedIndex).Type = LightType.Spot Then
                cbLightType.SelectedIndex = 2
            ElseIf Simulation.Config.LightConfigs(listLights.SelectedIndex).Type = LightType.Point Then
                cbLightType.SelectedIndex = 1
            Else
                cbLightType.SelectedIndex = 0
            End If
            txtLightPositionX.Text = Simulation.Config.LightConfigs(listLights.SelectedIndex).Position.X.ToString
            txtLightPositionY.Text = Simulation.Config.LightConfigs(listLights.SelectedIndex).Position.Y.ToString
            txtLightPositionZ.Text = Simulation.Config.LightConfigs(listLights.SelectedIndex).Position.Z.ToString
            tbLightHighlight.Value = Simulation.Config.LightConfigs(listLights.SelectedIndex).SpecularColor.R
            tbLightAmbient.Value = Simulation.Config.LightConfigs(listLights.SelectedIndex).AmbientRatio
            txtLightRange.Text = Simulation.Config.LightConfigs(listLights.SelectedIndex).Range.ToString
            txtLightAttenuationA.Text = Simulation.Config.LightConfigs(listLights.SelectedIndex).AttenuationA.ToString
            txtLightAttenuationB.Text = Simulation.Config.LightConfigs(listLights.SelectedIndex).AttenuationB.ToString
            txtLightAttenuationC.Text = Simulation.Config.LightConfigs(listLights.SelectedIndex).AttenuationC.ToString
            txtLightAngleInner.Text = ToInt32((Simulation.Config.LightConfigs(listLights.SelectedIndex).InnerCone / PI) * 180).ToString
            txtLightAngleOuter.Text = ToInt32((Simulation.Config.LightConfigs(listLights.SelectedIndex).OuterCone / PI) * 180).ToString
            txtLightFalloff.Text = Simulation.Config.LightConfigs(listLights.SelectedIndex).Falloff.ToString
        Else
            ClearLightForm()
        End If
        CheckConditionals()

        'Paint the controls only at the end
        Me.ResumeLayout()
    End Sub
    Private Sub CmdAddLight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLightAdd.Click
        If Not IsValidLight() = True Then Exit Sub
        InsertLight(Simulation.Config.LightConfigs.Count)
        listLights.Items.Insert(listLights.Items.Count, Simulation.Config.LightConfigs(Simulation.Config.LightConfigs.Count - 1).Name)
        listLights.ClearSelected()
        ConfigModified = True
    End Sub
    Private Sub InsertLight(ByRef i As Integer)
        Dim isDirectionalLight As Boolean = (cbLightType.SelectedIndex = 0)
        Dim isPointLight As Boolean = (cbLightType.SelectedIndex = 1)
        Dim isSpotLight As Boolean = (cbLightType.SelectedIndex = 2)

        Dim newLight As New SimulationConfigLight
        Simulation.Config.LightConfigs.Insert(i, newLight)

        If isSpotLight Then
            newLight.Type = LightType.Spot
        ElseIf isPointLight Then
            newLight.Type = LightType.Point
        ElseIf isDirectionalLight Then
            newLight.Type = LightType.Directional
        End If

        newLight.Name = txtLightName.Text
        newLight.Color = plLightColor.BackColor

        If (isDirectionalLight Or isSpotLight) Then
            newLight.Direction.X = ToSingle(txtLightDirectionX.Text)
            newLight.Direction.Y = ToSingle(txtLightDirectionY.Text)
            newLight.Direction.Z = ToSingle(txtLightDirectionZ.Text)
        End If

        If (isSpotLight Or isPointLight) Then
            newLight.Position.X = ToSingle(txtLightPositionX.Text)
            newLight.Position.Y = ToSingle(txtLightPositionY.Text)
            newLight.Position.Z = ToSingle(txtLightPositionZ.Text)

            newLight.AttenuationA = ToSingle(txtLightAttenuationA.Text)
            newLight.AttenuationB = ToSingle(txtLightAttenuationB.Text)
            newLight.AttenuationC = ToSingle(txtLightAttenuationC.Text)

            newLight.Range = ToSingle(txtLightRange.Text)
        End If

        If (isSpotLight) Then
            newLight.InnerCone = ToSingle(ToDouble(txtLightAngleInner.Text) * (Math.PI / 180))
            newLight.OuterCone = ToSingle(ToDouble(txtLightAngleOuter.Text) * (Math.PI / 180))
            newLight.Falloff = ToSingle(txtLightFalloff.Text)
        End If

        newLight.AmbientRatio = tbLightAmbient.Value
        newLight.AmbientColor = Color.FromArgb(255, ToByte(plLightColor.BackColor.R * (tbLightAmbient.Value / 100)), ToByte(plLightColor.BackColor.G * (tbLightAmbient.Value / 100)), ToByte(plLightColor.BackColor.B * (tbLightAmbient.Value / 100)))
        newLight.SpecularColor = Color.FromArgb(255, tbLightHighlight.Value, tbLightHighlight.Value, tbLightHighlight.Value)
    End Sub
    Private Sub CmdReplaceLight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLightReplace.Click
        If IsValidLight() = True Then
            Dim index As Integer
            index = listLights.SelectedIndex
            Simulation.Config.LightConfigs.RemoveAt(index)
            InsertLight(index)
            listLights.Items.RemoveAt(index)
            listLights.Items.Insert(index, Simulation.Config.LightConfigs(index).Name)
            listLights.ClearSelected()
            ConfigModified = True
        End If
    End Sub
    Private Sub CmdRemoveLight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLightRemove.Click
        If MsgBox("Are you sure you want to remove the selected light?", MsgBoxStyle.YesNo, "Remove?") = vbYes Then
            Simulation.Config.LightConfigs.RemoveAt(listLights.SelectedIndex)
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
            lblStat.Text = "Frames : " & Simulation.RenderCounter.FullCount &
                           "  |  FPS : " & Int((Simulation.RenderCounter.FullCount - Simulation.RenderCounter.LastCount) / ((Simulation.RenderCounter.StopValue - Simulation.RenderCounter.StartValue) / Simulation.RenderCounter.Frequency)) &
                           "  |  Calculations : " & Simulation.CalcCounter.FullCount &
                           "  |  CPS : " & Int((Simulation.CalcCounter.FullCount - Simulation.CalcCounter.LastCount) / ((Simulation.CalcCounter.StopValue - Simulation.CalcCounter.StartValue) / Simulation.CalcCounter.Frequency))
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
    Private Sub TxtFieldX_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtFieldX.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtFieldY_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtFieldY.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtFieldZ_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtFieldZ.TextChanged
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
    Private Sub TxtAddMin_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAddMin.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtAddAvg_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAddAvg.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtAddMax_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAddMax.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtScale_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScale.TextChanged
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
    Private Sub TxtCOrientX_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCOrientX.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtCOrientY_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCOrientY.TextChanged
        ConfigModified = True
    End Sub
    Private Sub TxtCOrientZ_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCOrientZ.TextChanged
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
        'Paint the controls only at the end
        Me.SuspendLayout()

        If listGroups.SelectedIndex <> -1 Then
            Dim index As Integer = listGroups.SelectedIndex
            chObjectAffected.Checked = Simulation.Config.ObjectGroups(index).Affected
            chObjectAffects.Checked = Simulation.Config.ObjectGroups(index).Affects
            chObjectWireframe.Checked = Simulation.Config.ObjectGroups(index).Wireframe
            chObjectPoints.Checked = Simulation.Config.ObjectGroups(index).Points
            cbObjectType.SelectedIndex = Simulation.Config.ObjectGroups(index).Type
            txtObjectName.Text = Simulation.Config.ObjectGroups(index).Name

            'NUMBER 
            ObjectNumber.Copy(Simulation.Config.ObjectGroups(index).Number)
            txtObjectNumber.Text = ObjectNumber.Value.ToString
            If ObjectNumber.UseFunction Then
                cmdObjectNumber.ForeColor = Color.RoyalBlue
            Else
                cmdObjectNumber.ForeColor = Color.Black
            End If

            'MASS
            ObjectMass.Copy(Simulation.Config.ObjectGroups(index).Mass)
            txtObjectMass.Text = ObjectMass.Value.ToString
            If ObjectMass.UseFunction Then
                cmdObjectMass.ForeColor = Color.RoyalBlue
            Else
                cmdObjectMass.ForeColor = Color.Black
            End If

            'CHARGE
            ObjectCharge.Copy(Simulation.Config.ObjectGroups(index).Charge)
            txtObjectCharge.Text = ObjectCharge.Value.ToString
            If ObjectCharge.UseFunction Then
                cmdObjectCharge.ForeColor = Color.RoyalBlue
            Else
                cmdObjectCharge.ForeColor = Color.Black
            End If

            'RADIUS
            ObjectRadius.Copy(Simulation.Config.ObjectGroups(index).Radius)
            txtObjectRadius.Text = ObjectRadius.Value.ToString
            If ObjectRadius.UseFunction Then
                cmdObjectRadius.ForeColor = Color.RoyalBlue
            Else
                cmdObjectRadius.ForeColor = Color.Black
            End If

            'SIZE
            ObjectSize.Copy(Simulation.Config.ObjectGroups(index).Size)
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
            ObjectRotation.Copy(Simulation.Config.ObjectGroups(index).Rotation)
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
            ObjectNormal.Copy(Simulation.Config.ObjectGroups(index).Normal)
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
            ObjectPosition.Copy(Simulation.Config.ObjectGroups(index).Position)
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
            ObjectVelocity.Copy(Simulation.Config.ObjectGroups(index).Velocity)
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
            ObjectColor.Copy(Simulation.Config.ObjectGroups(index).Color)
            plObjectColor.BackColor = ObjectColor.Value
            If ObjectColor.UseFunction Then
                cmdObjectColor.ForeColor = Color.RoyalBlue
            Else
                cmdObjectColor.ForeColor = Color.Black
            End If

            'HIGHLIGHT
            ObjectHighlight.Copy(Simulation.Config.ObjectGroups(index).Highlight)
            plObjectHighlightColor.BackColor = ObjectHighlight.Value
            If ObjectHighlight.UseFunction Then
                cmdObjectHighlightColor.ForeColor = Color.RoyalBlue
            Else
                cmdObjectHighlightColor.ForeColor = Color.Black
            End If

            'SHARPNESS
            ObjectSharpness.Copy(Simulation.Config.ObjectGroups(index).Sharpness)
            tbObjectHighlightSharpness.Value = ToInt32(ObjectSharpness.Value)
            If ObjectSharpness.UseFunction Then
                cmdObjectHighlightSharpness.ForeColor = Color.RoyalBlue
            Else
                cmdObjectHighlightSharpness.ForeColor = Color.Black
            End If

            'REFLECTIVITY
            ObjectReflectivity.Copy(Simulation.Config.ObjectGroups(index).Reflectivity)
            tbObjectReflectivity.Value = ToInt32(ObjectReflectivity.Value)
            If ObjectReflectivity.UseFunction Then
                cmdObjectReflectivity.ForeColor = Color.RoyalBlue
            Else
                cmdObjectReflectivity.ForeColor = Color.Black
            End If

            'TRANSPARENCY
            ObjectTransparency.Copy(Simulation.Config.ObjectGroups(index).Transparency)
            tbObjectTransparency.Value = ToInt32(ObjectTransparency.Value)
            If ObjectTransparency.UseFunction Then
                cmdObjectTransparency.ForeColor = Color.RoyalBlue
            Else
                cmdObjectTransparency.ForeColor = Color.Black
            End If

            'REFRACTIVE INDEX
            ObjectRefractiveIndex.Copy(Simulation.Config.ObjectGroups(index).RefractiveIndex)
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

        'Paint the controls only at the end
        Me.ResumeLayout()
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
        chObjectPoints.Checked = False

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
        For i = 0 To Simulation.Config.ObjectGroups.Count - 1
            If Simulation.Config.ObjectGroups(i).Number.UseFunction Then
                If Simulation.Config.ObjectGroups(i).Number.Random Then
                    CurrentObjects += Simulation.Config.ObjectGroups(i).Number.RandomMax
                Else
                    CurrentObjects += Simulation.Config.ObjectGroups(i).Number.NormalMax
                End If
                'TODO: Figure out Polynomial & Even distribution max
            Else
                CurrentObjects += Simulation.Config.ObjectGroups(i).Number.Value
            End If
        Next
        Return ToInt32(txtLimitObjects.Text) - CurrentObjects
    End Function
    Private Sub CmdObjectAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGroupAdd.Click
        If Not IsValidObjectGroup() Or Not IsValidMaxObjects() Then Exit Sub

        'Paint the controls only at the end
        Me.SuspendLayout()

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

        InsertGroup(Simulation.Config.ObjectGroups.Count)
        listGroups.Items.Insert(listGroups.Items.Count, Simulation.Config.ObjectGroups(Simulation.Config.ObjectGroups.Count - 1).Name)
        listGroups.ClearSelected()
        ConfigModified = True

        'Paint the controls only at the end
        Me.ResumeLayout()
    End Sub
    Private Sub InsertGroup(ByRef i As Integer)

        Dim newGroup As New SimulationConfigObjectGroup
        Simulation.Config.ObjectGroups.Insert(i, newGroup)

        newGroup.Name = txtObjectName.Text
        newGroup.Affects = chObjectAffects.Checked
        newGroup.Wireframe = chObjectWireframe.Checked
        newGroup.Points = chObjectPoints.Checked

        If cbObjectType.SelectedIndex = 1 Then
            newGroup.Type = ObjectType.Box
            newGroup.Affected = chObjectAffected.Checked
        ElseIf cbObjectType.SelectedIndex = 2 Then
            newGroup.Type = ObjectType.Plane
            newGroup.Affected = False
        ElseIf cbObjectType.SelectedIndex = 3 Then
            newGroup.Type = ObjectType.InfinitePlane
            newGroup.Affected = False
        Else
            newGroup.Type = ObjectType.Sphere
            newGroup.Affected = chObjectAffected.Checked
        End If

        ObjectNumber.Value = ToInt32(txtObjectNumber.Text)
        newGroup.Number.Copy(ObjectNumber)

        ObjectMass.Value = ToDouble(txtObjectMass.Text)
        newGroup.Mass.Copy(ObjectMass)

        ObjectCharge.Value = ToDouble(txtObjectCharge.Text)
        newGroup.Charge.Copy(ObjectCharge)

        ObjectSize.X.Value = ToDouble(txtObjectSizeX.Text)
        ObjectSize.Y.Value = ToDouble(txtObjectSizeY.Text)
        ObjectSize.Z.Value = ToDouble(txtObjectSizeZ.Text)
        newGroup.Size.Copy(ObjectSize)

        ObjectRadius.Value = ToDouble(txtObjectRadius.Text)
        newGroup.Radius.Copy(ObjectRadius)

        ObjectRotation.X.Value = ToDouble(txtObjectRotationX.Text)
        ObjectRotation.Y.Value = ToDouble(txtObjectRotationY.Text)
        ObjectRotation.Z.Value = ToDouble(txtObjectRotationZ.Text)
        newGroup.Rotation.Copy(ObjectRotation)

        ObjectNormal.X.Value = ToDouble(txtObjectNormalX.Text)
        ObjectNormal.Y.Value = ToDouble(txtObjectNormalY.Text)
        ObjectNormal.Z.Value = ToDouble(txtObjectNormalZ.Text)
        newGroup.Normal.Copy(ObjectNormal)

        ObjectPosition.X.Value = ToDouble(txtObjectPositionX.Text)
        ObjectPosition.Y.Value = ToDouble(txtObjectPositionY.Text)
        ObjectPosition.Z.Value = ToDouble(txtObjectPositionZ.Text)
        newGroup.Position.Copy(ObjectPosition)

        ObjectVelocity.X.Value = ToDouble(txtObjectVelocityX.Text)
        ObjectVelocity.Y.Value = ToDouble(txtObjectVelocityY.Text)
        ObjectVelocity.Z.Value = ToDouble(txtObjectVelocityZ.Text)
        newGroup.Velocity.Copy(ObjectVelocity)

        ObjectColor.Value = plObjectColor.BackColor
        newGroup.Color.Copy(ObjectColor)

        ObjectHighlight.Value = plObjectHighlightColor.BackColor
        newGroup.Highlight.Copy(ObjectHighlight)

        ObjectRefractiveIndex.Value = ToDouble(txtObjectRefractiveIndex.Text)
        newGroup.RefractiveIndex.Copy(ObjectRefractiveIndex)

        ObjectTransparency.Value = ToDouble(tbObjectTransparency.Value)
        newGroup.Transparency.Copy(ObjectTransparency)

        ObjectSharpness.Value = ToSingle(tbObjectHighlightSharpness.Value)
        newGroup.Sharpness.Copy(ObjectSharpness)

        ObjectReflectivity.Value = ToSingle(tbObjectReflectivity.Value)
        newGroup.Reflectivity.Copy(ObjectReflectivity)
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
        If Not IsValidObjectGroup() Or Not IsValidMaxObjects() Then Exit Sub
        'Paint the controls only at the end
        Me.SuspendLayout()

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
        If Simulation.Config.ObjectGroups(index).Number.UseFunction Then
            If ObjectNumber.Random Then
                CurrentObjects -= Simulation.Config.ObjectGroups(index).Number.RandomMax
            Else
                CurrentObjects -= Simulation.Config.ObjectGroups(index).Number.NormalMax
            End If
        Else
            CurrentObjects -= Simulation.Config.ObjectGroups(index).Number.Value
        End If
        If CurrentObjects > ObjectRoomLeft() Then
            MsgBox("Objects are currently limited to " & ToInt32(txtLimitObjects.Text) & ".", MsgBoxStyle.Exclamation, "Warning")
            Exit Sub
        End If

        Simulation.Config.ObjectGroups.RemoveAt(index)
        InsertGroup(index)
        listGroups.Items.RemoveAt(index)
        listGroups.Items.Insert(index, Simulation.Config.ObjectGroups(index).Name)
        listGroups.ClearSelected()
        ConfigModified = True

        'Paint the controls only at the end
        Me.ResumeLayout()
    End Sub
    Private Sub CmdRemoveGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGroupRemove.Click
        If MsgBox("Are you sure you want to remove the selected group?", MsgBoxStyle.YesNo, "Remove?") = MsgBoxResult.No Then Exit Sub
        Simulation.Config.ObjectGroups.RemoveAt(listGroups.SelectedIndex)
        listGroups.Items.RemoveAt(listGroups.SelectedIndex)
        listGroups.ClearSelected()

        ConfigModified = True
    End Sub
    Private Sub PlObjectHighlightColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles plObjectHighlightColor.Click
        ColorDialog.Color = plObjectHighlightColor.BackColor
        ColorDialog.ShowDialog()
        plObjectHighlightColor.BackColor = ColorDialog.Color
    End Sub

    Private Sub ChObjectAffected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chObjectAffected.CheckedChanged
        CheckConditionals()
    End Sub
    Private Sub ChObjectAffects_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chObjectAffects.CheckedChanged
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
        Return Distribution.ShowDialog() = DialogResult.OK
    End Function
    Private Sub TbPolys_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPolys.Scroll
        ConfigModified = True
    End Sub

    Private Sub TxtRenderThreads_TextChanged(sender As Object, e As EventArgs) Handles txtRenderThreads.TextChanged
        ConfigModified = True
    End Sub

    Private Sub chObjectPoints_CheckedChanged(sender As Object, e As EventArgs) Handles chObjectPoints.CheckedChanged
        If (chObjectPoints.Checked) Then chObjectWireframe.Checked = False
    End Sub

    Private Sub chObjectWireframe_CheckedChanged(sender As Object, e As EventArgs) Handles chObjectWireframe.CheckedChanged
        If (chObjectWireframe.Checked) Then chObjectPoints.Checked = False
    End Sub

    Private Sub listGroups_MouseDown(sender As Object, e As MouseEventArgs) Handles listGroups.MouseDown
        If e.Button = MouseButtons.Right Then
            listGroups.ClearSelected()
        ElseIf listGroups.SelectedIndex >= 0 Then
            listGroups.DoDragDrop(listGroups.SelectedIndex, DragDropEffects.Move)
            ListObjects_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub listGroups_DragOver(sender As Object, e As DragEventArgs) Handles listGroups.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub listGroups_DragDrop(sender As Object, e As DragEventArgs) Handles listGroups.DragDrop
        Dim point As Point = listGroups.PointToClient(New Point(e.X, e.Y))
        Dim newIndex As Integer = listGroups.IndexFromPoint(point)

        If newIndex < 0 Then newIndex = listGroups.Items.Count - 1
        Dim dropObject As Object = e.Data.GetData(GetType(Int32))
        If dropObject Is Nothing Then Return

        Dim oldIndex As Integer = DirectCast(dropObject, Int32)
        If oldIndex < 0 Or oldIndex = newIndex Then Return

        Dim oldItem = listGroups.Items.Item(oldIndex)
        listGroups.Items.RemoveAt(oldIndex)
        listGroups.Items.Insert(newIndex, oldItem)

        Dim oldGroup = Simulation.Config.ObjectGroups.Item(oldIndex)
        Simulation.Config.ObjectGroups.RemoveAt(oldIndex)
        Simulation.Config.ObjectGroups.Insert(newIndex, oldGroup)
    End Sub

    Private Sub listLights_MouseDown(sender As Object, e As MouseEventArgs) Handles listLights.MouseDown
        If e.Button = MouseButtons.Right Then
            listLights.ClearSelected()
        ElseIf listLights.SelectedIndex >= 0 Then
            listLights.DoDragDrop(listLights.SelectedIndex, DragDropEffects.Move)
            ListLights_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub listLights_DragOver(sender As Object, e As DragEventArgs) Handles listLights.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub listLights_DragDrop(sender As Object, e As DragEventArgs) Handles listLights.DragDrop
        Dim point As Point = listLights.PointToClient(New Point(e.X, e.Y))
        Dim newIndex As Integer = listLights.IndexFromPoint(point)

        If newIndex < 0 Then newIndex = listLights.Items.Count - 1
        Dim dropObject As Object = e.Data.GetData(GetType(Int32))
        If dropObject Is Nothing Then Return

        Dim oldIndex As Integer = DirectCast(dropObject, Int32)
        If oldIndex < 0 Or oldIndex = newIndex Then Return

        Dim oldItem = listLights.Items.Item(oldIndex)
        listLights.Items.RemoveAt(oldIndex)
        listLights.Items.Insert(newIndex, oldItem)

        Dim oldLight = Simulation.Config.LightConfigs.Item(oldIndex)
        Simulation.Config.LightConfigs.RemoveAt(oldIndex)
        Simulation.Config.LightConfigs.Insert(newIndex, oldLight)
    End Sub
    Private Sub TxtHFoV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHFoV.TextChanged
        updateVFov()
        ConfigModified = True
    End Sub
    Private Sub TxtWindowX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWindowX.TextChanged
        updateVFov()
        ConfigModified = True
    End Sub
    Private Sub TxtWindowY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWindowY.TextChanged
        updateVFov()
        ConfigModified = True
    End Sub

    Private Sub updateVFov()
        If Not IsNumeric(txtWindowX.Text) OrElse Not IsNumeric(txtWindowY.Text) OrElse Not IsNumeric(txtHFoV.Text) Then Return

        Dim x As Double = ToDouble(txtWindowX.Text)
        Dim y As Double = ToDouble(txtWindowY.Text)
        Dim hfov As Double = ToDouble(txtHFoV.Text) 'In degrees
        If x < 1 OrElse y < 1 OrElse hfov < 0 Then Return

        Dim aspectRatio As Double = x / y
        Dim vfovRadians As Double = 2 * Math.Atan(Math.Tan(hfov * Math.PI / 360) / aspectRatio)
        txtVFoV.Text = (vfovRadians * 180 / Math.PI).ToString
    End Sub
End Class

