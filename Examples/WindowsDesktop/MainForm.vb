﻿Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports UnderAutomation.UniversalRobots
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class MainForm

    ' instance of the UR connection
    Private WithEvents _ur As New UR()

#Region "Initialization"
    Public Sub New()
        InitializeComponent()

        ' change here if you have a valid license
        Dim license = New LicenseInfo(licenseIdentifier:=Nothing, licenseKey:=Nothing)
        txtLicense.Text = license.ToString

        ' show current license state
        licGrid.SetSelectedObject(license)

        ' fill enums
        For Each value In [Enum].GetValues(GetType(UserRoles))
            cbUserRoles.Items.Add(value)
        Next
        cbUserRoles.SelectedItem = UserRoles.Operator

        cbOperationalMode.Items.Add(OperationalModes.Automatic)
        cbOperationalMode.Items.Add(OperationalModes.Manual)
        cbOperationalMode.SelectedItem = OperationalModes.Automatic

        txtIP.Text = My.Settings.ip
        If String.IsNullOrEmpty(txtIP.Text) Then
            txtIP.Text = "192.168.0.1"
        End If
    End Sub

    ' Disconnect robot on form closing
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)

        Try
            _ur.Disconnect()
        Catch ex As Exception
            HandleEx(ex)
        End Try
    End Sub
#End Region


#Region "Errors"
    Private Sub HandleEx(message As String)
        If InvokeRequired Then
            Invoke(Sub() HandleEx(message))
        Else
            txtErrors.AppendText(message)
            txtErrors.AppendText(vbNewLine)
            txtErrors.AppendText(vbNewLine)
            txtErrors.ScrollToCaret()
        End If
    End Sub

    Private Sub HandleEx(ex As Exception)
        HandleEx(ex.Message)
    End Sub

    Private Sub btnAck_Click(sender As Object, e As EventArgs) Handles btnAck.Click
        txtErrors.Clear()
    End Sub

#End Region


#Region "Header info"
    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            ' connect to the robot
            _ur.Connect(txtIP.Text)

            My.Settings.ip = txtIP.Text
            My.Settings.Save()

            ' get IP of the local network interface connected to the robot
            txtLocalIP.Text = _ur.DataStreamingLocalEndPoint.Address.ToString()
            udXmlRpcPort.Value = 50000
        Catch ex As Exception
            HandleEx(ex)
        End Try
    End Sub

    Private Sub txtIP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIP.KeyDown, txtLocalIP.KeyDown, txtXmlRpcPort.KeyDown
        If e.KeyData = Keys.Enter Then
            btnConnect_Click(sender, e)
        End If
    End Sub

    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click
        Try
            _ur.Disconnect()
        Catch ex As Exception
            HandleEx(ex)
        End Try
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Try
            _ur.Send(txtScript.Text)
        Catch ex As Exception
            HandleEx(ex)
        End Try
    End Sub

    Private Sub linkDoc_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkDoc.LinkClicked
        Try
            Process.Start("https://underautomation.github.io/documentation?f")
        Catch
        End Try
    End Sub

    ' refresh status labels
    Private Sub tmrConnected_Tick(sender As Object, e As EventArgs) Handles tmrConnected.Tick
        Try
            Dim dataStreamingEnabled = _ur.DataStreamingEnabled
            If dataStreamingEnabled Then
                lblConnected.Text = "Connected"
                lblConnected.ForeColor = Color.Green
            Else
                lblConnected.Text = "Disconnected"
                lblConnected.ForeColor = Color.Red
            End If

            txtIP.Enabled = Not dataStreamingEnabled
            btnConnect.Enabled = Not dataStreamingEnabled
            btnDisconnect.Enabled = dataStreamingEnabled
        Catch
        End Try

        Try
            Dim xmlRpcServerEnabled = _ur.XmlRpcServerEnabled
            If xmlRpcServerEnabled Then
                txtXmlRpcStatus.Text = "Enabled"
                txtXmlRpcStatus.ForeColor = Color.Green
            Else
                txtXmlRpcStatus.Text = "Disabled"
                txtXmlRpcStatus.ForeColor = Color.Red
            End If

            udXmlRpcPort.Enabled = Not xmlRpcServerEnabled
            btnEnableXmlRpcServer.Enabled = Not xmlRpcServerEnabled
            btnDisableXmlRpcServer.Enabled = xmlRpcServerEnabled
        Catch
        End Try

        ' blink tab icon
        tabCommands.ImageIndex = (tabCommands.ImageIndex + 1) Mod 2
    End Sub

    Private Sub tabCommands_Click(sender As Object, e As EventArgs) Handles mainTabControl.Selected
        ' stop tab icon blinking
        If mainTabControl.SelectedTab Is tabCommands Then mainTabControl.ImageList = Nothing
    End Sub
#End Region

#Region "Data streaming"
    Private Sub ur_AdditionalInfoReceived(sender As Object, e As AdditionalInfoPackageEventArgs) Handles _ur.AdditionalInfoReceived
        gridAdditionnalInfo.SetSelectedObject(e)
    End Sub

    Private Sub ur_CartesianInfoReceived(sender As Object, e As CartesianInfoPackageEventArgs) Handles _ur.CartesianInfoReceived
        gridCartesian.SetSelectedObject(e)
    End Sub

    Private Sub ur_ConfigurationDataReceived(sender As Object, e As ConfigurationDataPackageEventArgs) Handles _ur.ConfigurationDataReceived
        gridConfiguration.SetSelectedObject(e)
    End Sub

    Private Sub ur_ForceModeDataReceived(sender As Object, e As ForceModeDataPackageEventArgs) Handles _ur.ForceModeDataReceived
        gridForce.SetSelectedObject(e)
    End Sub

    Private Sub ur_JointDataReceived(sender As Object, e As JointDataPackageEventArgs) Handles _ur.JointDataReceived
        gridJointData.SetSelectedObject(e)
    End Sub

    Private Sub ur_MasterboardDataReceived(sender As Object, e As MasterboardDataPackageEventArgs) Handles _ur.MasterboardDataReceived
        gridMasterboard.SetSelectedObject(e)
    End Sub

    Private Sub ur_RobotModeDataReceived(sender As Object, e As RobotModeDataPackageEventArgs) Handles _ur.RobotModeDataReceived
        gridRobotMode.SetSelectedObject(e)
    End Sub
    Private Sub ur_ToolCommunicationInfoReceived(sender As Object, e As ToolCommunicationInfoPackageEventArgs) Handles _ur.ToolCommunicationInfoReceived
        GridToolCommunication.SetSelectedObject(e)
    End Sub

    Private Sub ur_ToolDataReceived(sender As Object, e As ToolDataPackageEventArgs) Handles _ur.ToolDataReceived
        gridTool.SetSelectedObject(e)
    End Sub
    Private Sub ur_ToolDataReceived(sender As Object, e As ToolModeInfoPackageEventArgs) Handles _ur.ToolModeInfoReceived
        gridToolModeInfo.SetSelectedObject(e)
    End Sub

    Private Sub ur_KinematicsInfoReceived(sender As Object, e As KinematicsInfoPackageEventArgs) Handles _ur.KinematicsInfoReceived
        gridKinematicsData.SetSelectedObject(e)
    End Sub
#End Region


#Region "Commands"
    Private Sub LogCommand(action As Func(Of CommandResponse), command As String)
        Try
            txtConsole.AppendText(command)
            txtConsole.AppendText("()")
            txtConsole.AppendText(vbCrLf)

            Dim response = action()

            txtConsole.SelectionBullet = True
            If response.Succeed Then
                txtConsole.SelectionColor = Color.Green
                txtConsole.AppendText("OK : ")
            Else
                txtConsole.SelectionColor = Color.Red
                txtConsole.AppendText("FAILED : ")
            End If

            txtConsole.AppendText(response.ToString)

        Catch ex As Exception
            txtConsole.SelectionColor = Color.DarkRed
            txtConsole.AppendText(ex.Message)
        End Try

        txtConsole.SelectionBullet = False
        txtConsole.SelectionColor = Color.White
        txtConsole.AppendText(vbNewLine)
        txtConsole.AppendText(vbNewLine)
        txtConsole.AppendText("> ")
        txtConsole.ScrollToCaret()

    End Sub

    Private Sub btnProgrammRunning_Click(sender As Object, e As EventArgs) Handles btnProgrammRunning.Click
        LogCommand(Function()

                       Return _ur.IsProgramRunning()

                   End Function,
                   "IsProgramRunning")
    End Sub

    Private Sub btnGetRobotMode_Click(sender As Object, e As EventArgs) Handles btnGetRobotMode.Click
        LogCommand(Function()

                       Return _ur.GetRobotMode()

                   End Function,
                   "GetRobotMode")
    End Sub

    Private Sub btnLoadProgram_Click(sender As Object, e As EventArgs) Handles btnLoadProgram.Click
        LogCommand(Function()

                       Return _ur.LoadProgram(txtProgram.Text)

                   End Function,
                   "LoadProgram")
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        LogCommand(Function()

                       Return _ur.Play()

                   End Function,
                   "Play")
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        LogCommand(Function()

                       Return _ur.Stop()

                   End Function,
                   "Stop")

    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        LogCommand(Function()

                       Return _ur.Pause()

                   End Function,
                   "Pause")

    End Sub

    Private Sub btnShutdown_Click(sender As Object, e As EventArgs) Handles btnShutdown.Click
        LogCommand(Function()

                       Return _ur.Shutdown()

                   End Function,
                   "Shutdown")

    End Sub

    Private Sub btnGetLoadedProgram_Click(sender As Object, e As EventArgs) Handles btnGetLoadedProgram.Click
        LogCommand(Function()

                       Return _ur.GetLoadedProgram()

                   End Function,
                   "GetLoadedProgram")

    End Sub

    Private Sub btnShowPopup_Click(sender As Object, e As EventArgs) Handles btnShowPopup.Click
        LogCommand(Function()

                       Return _ur.ShowPopup(txtPopup.Text)

                   End Function,
                   "ShowPopup")

    End Sub

    Private Sub btnClosePopup_Click(sender As Object, e As EventArgs) Handles btnClosePopup.Click
        LogCommand(Function()

                       Return _ur.ClosePopup()

                   End Function,
                   "ClosePopup")

    End Sub

    Private Sub btnAddToLog_Click(sender As Object, e As EventArgs) Handles btnAddToLog.Click
        LogCommand(Function()

                       Return _ur.AddToLog(txtLog.Text)

                   End Function,
                   "AddToLog")

    End Sub

    Private Sub btnIsProgramSaved_Click(sender As Object, e As EventArgs) Handles btnIsProgramSaved.Click
        LogCommand(Function()

                       Return _ur.IsProgramSaved()

                   End Function,
                   "IsProgramSaved")

    End Sub

    Private Sub btnGetProgramState_Click(sender As Object, e As EventArgs) Handles btnGetProgramState.Click
        LogCommand(Function()

                       Return _ur.GetProgramState()

                   End Function,
                   "GetProgramState")

    End Sub

    Private Sub btnPolyscopeVersion_Click(sender As Object, e As EventArgs) Handles btnPolyscopeVersion.Click
        LogCommand(Function()

                       Return _ur.GetPolyscopeVersion()

                   End Function,
                   "GetPolyscopeVersion")

    End Sub

    Private Sub btnSetUserRole_Click(sender As Object, e As EventArgs) Handles btnSetUserRole.Click
        LogCommand(Function()

                       Return _ur.SetUserRole(CType(cbUserRoles.SelectedItem, UserRoles))

                   End Function,
                   "LoadProgram")

    End Sub

    Private Sub btnPowerOn_Click(sender As Object, e As EventArgs) Handles btnPowerOn.Click
        LogCommand(Function()

                       Return _ur.PowerOn()

                   End Function,
                   "PowerOn")

    End Sub

    Private Sub btnPowerOff_Click(sender As Object, e As EventArgs) Handles btnPowerOff.Click
        LogCommand(Function()

                       Return _ur.PowerOff()

                   End Function,
                   "PowerOff")

    End Sub

    Private Sub ReaseBrake_Click(sender As Object, e As EventArgs) Handles ReaseBrake.Click
        LogCommand(Function()

                       Return _ur.ReleaseBrake()

                   End Function,
                   "ReleaseBrake")

    End Sub

    Private Sub btnUnlockProtectiveStop_Click(sender As Object, e As EventArgs) Handles btnUnlockProtectiveStop.Click
        LogCommand(Function()

                       Return _ur.UnlockProtectiveStop()

                   End Function,
                   "UnlockProtectiveStop")

    End Sub

    Private Sub btnCloseSafetyPopup_Click(sender As Object, e As EventArgs) Handles btnCloseSafetyPopup.Click
        LogCommand(Function()

                       Return _ur.CloseSafetyPopup()

                   End Function,
                   "CloseSafetyPopup")

    End Sub

    Private Sub btnLoadInstallation_Click(sender As Object, e As EventArgs) Handles btnLoadInstallation.Click
        LogCommand(Function()

                       Return _ur.LoadInstallation(txtInstallation.Text)

                   End Function,
                   "LoadInstallation")

    End Sub

    Private Sub btnRestartSafety_Click(sender As Object, e As EventArgs) Handles btnRestartSafety.Click
        LogCommand(Function()

                       Return _ur.RestartSafety()
                   End Function,
                   "RestartSafety")

    End Sub

    Private Sub btnSafetyStatus_Click(sender As Object, e As EventArgs) Handles btnSafetyStatus.Click
        LogCommand(Function()

                       Return _ur.GetSafetyStatus()

                   End Function,
                   "GetSafetyStatus")

    End Sub

    Private Sub btnGetSerialNumber_Click(sender As Object, e As EventArgs) Handles btnGetSerialNumber.Click
        LogCommand(Function()

                       Return _ur.GetSerialNumber()

                   End Function,
                   "GetSerialNumber")

    End Sub

    Private Sub btnGetRobotModel_Click(sender As Object, e As EventArgs) Handles btnGetRobotModel.Click
        LogCommand(Function()

                       Return _ur.GetRobotModel()

                   End Function,
                   "GetRobotModel")

    End Sub

    Private Sub btnIsInRemoteControl_Click(sender As Object, e As EventArgs) Handles btnIsInRemoteControl.Click
        LogCommand(Function()

                       Return _ur.IsInRemoteControl()

                   End Function,
                   "IsInRemoteControl")

    End Sub

    Private Sub btnGetOperationalMode_Click(sender As Object, e As EventArgs) Handles btnGetOperationalMode.Click
        LogCommand(Function()

                       Return _ur.GetOperationalMode()

                   End Function,
                   "GetOperationalMode")

    End Sub

    Private Sub btnClearOIperationalMode_Click(sender As Object, e As EventArgs) Handles btnClearOIperationalMode.Click
        LogCommand(Function()

                       Return _ur.ClearOperationalMode()

                   End Function,
                   "ClearOperationalMode")

    End Sub

    Private Sub btnSetOperationalMode_Click(sender As Object, e As EventArgs) Handles btnSetOperationalMode.Click
        LogCommand(Function()

                       Return _ur.SetOperationalMode(CType(cbOperationalMode.SelectedItem, OperationalModes))

                   End Function,
                   "SetOperationalMode")

    End Sub
#End Region

#Region "XML-RPC"
    Private Sub _ur_OnXmlRpcServerRequest(sender As Object, request As XmlRpcEventArg) Handles _ur.XmlRpcServerRequest

        Dim waitHandle = New AutoResetEvent(False)

        Me.Invoke(Sub()
                      Dim dlg = New XmlRpcPopup(request, waitHandle)

                      dlg.ShowDialog()
                  End Sub)

        waitHandle.WaitOne()
    End Sub

    Private Sub btnEnableXmlRpcServer_Click(sender As Object, e As EventArgs) Handles btnEnableXmlRpcServer.Click
        Try
            _ur.EnableXmlRpcServer(CInt(udXmlRpcPort.Value))
        Catch ex As Exception
            HandleEx(ex)
        End Try
    End Sub

    Private Sub btnDisableXmlRpcServer_Click(sender As Object, e As EventArgs) Handles btnDisableXmlRpcServer.Click
        Try
            _ur.DisableXmlRpcServer()
        Catch ex As Exception
            HandleEx(ex)
        End Try
    End Sub

    Private Sub udXmlRpcPort_ValueChanged(sender As Object, e As EventArgs) Handles udXmlRpcPort.ValueChanged
        txtXmlRpcPort.Text = udXmlRpcPort.Value.ToString
    End Sub

    Private Sub linkXmlRpcSample_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkXmlRpcSample.LinkClicked
        Dim samplePath = Path.Combine(Path.GetDirectoryName(GetType(MainForm).Assembly.Location), "Samples", "xml_rpc_sample.urp")
        Process.Start("explorer.exe", $"/select,""{samplePath}""")
    End Sub
#End Region

#Region "Tools"
    ' convert poses types
    Private Sub radioRPYToRotationVector_CheckedChanged(sender As Object, e As EventArgs) Handles radioRPYToRotationVector.CheckedChanged, udRx.ValueChanged, udRy.ValueChanged, udRz.ValueChanged

        Dim inPose = New Pose(0, 0, 0, udRx.Value, udRy.Value, udRz.Value)

        Dim outPose As Pose = Nothing

        If radioRPYToRotationVector.Checked Then

            ' Convert from RPY to Rotation vector
            outPose = inPose.FromRPYToRotationVector

            txtIn.Text = "RPY"
            txtOut.Text = "Rotation Vector"
        Else

            ' Convert from Rotation vector to RPY
            outPose = inPose.FromRotationVectorToRPY

            txtIn.Text = "Rotation Vector"
            txtOut.Text = "RPY"
        End If

        txtRx.Text = $"{outPose.Rx} rad"
        txtRy.Text = $"{outPose.Ry} rad"
        txtRz.Text = $"{outPose.Rz} rad"
    End Sub


#End Region

End Class
