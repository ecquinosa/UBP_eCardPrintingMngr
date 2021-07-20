Public Class Setting

    Private Sub Setting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetInstalledPrinters()

        BindSettings()

        My.Settings.MainLoaderFlag = False
        My.Settings.Save()
    End Sub

    Private Sub BindSettings()
        txtDefaultPassword.Text = My.Settings.DefAppPassword
        cboCardPrinter.Text = My.Settings.CardPrinter

        txtServer_eCard.Text = My.Settings.Server_eCard
        txtDatabase_eCard.Text = My.Settings.Database_eCard
        txtUser_eCard.Text = My.Settings.User_eCard
        txtPassword_eCard.Text = My.Settings.Password_eCard

        txtDSN_GSIS.Text = My.Settings.ServiceName_GSIS
        txtServer_GSIS.Text = My.Settings.Server_GSIS
        txtPort_GSIS.Text = My.Settings.Port_GSIS
        txtUser_GSIS.Text = My.Settings.User_GSIS
        txtPassword_GSIS.Text = My.Settings.Password_GSIS

        txtIdleLimit.Text = My.Settings.IdleLimit
    End Sub

    Private Sub SaveSettings()
        If txtIdleLimit.Text = "" Then
            SharedFunction.ShowErrorMessage("Please enter value in Idle Limit not less than 35")
            Return
        Else
            If CInt(txtIdleLimit.Text) < 35 Then
                SharedFunction.ShowErrorMessage("Please enter value in Idle Limit not less than 35")
                Return
            End If
        End If


        My.Settings.DefAppPassword = txtDefaultPassword.Text
        My.Settings.CardPrinter = cboCardPrinter.Text

        My.Settings.Server_eCard = txtServer_eCard.Text
        My.Settings.Database_eCard = txtDatabase_eCard.Text
        My.Settings.User_eCard = txtUser_eCard.Text
        My.Settings.Password_eCard = txtPassword_eCard.Text

        My.Settings.ServiceName_GSIS = txtDSN_GSIS.Text
        My.Settings.Server_GSIS = txtServer_GSIS.Text
        My.Settings.Port_GSIS = txtPort_GSIS.Text
        My.Settings.User_GSIS = txtUser_GSIS.Text
        My.Settings.Password_GSIS = txtPassword_GSIS.Text

        My.Settings.IdleLimit = txtIdleLimit.Text

        My.Settings.Save()
    End Sub

    Private Sub GetInstalledPrinters()
        cboCardPrinter.Items.Clear()
        For Each strPrinter As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            'If CheckBox1.Checked Then
            If strPrinter.ToUpper.Contains("JAVELIN") Then
                cboCardPrinter.Items.Add(strPrinter)
            ElseIf strPrinter.ToUpper.Contains("EVOLIS") Then
                cboCardPrinter.Items.Add(strPrinter)
            End If
            'Else
            'cboCardPrinter.Items.Add(strPrinter)
            'End If
        Next
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        SharedFunction.ReportToApp()

        SharedFunction.ControlDisposition(False, Me.Cursor, False, btnSave, btnTestConnection_eCard, btnTestConnection_GSIS)

        SaveSettings()

        SharedFunction.ControlDisposition(True, Me.Cursor, False, btnSave, btnTestConnection_eCard, btnTestConnection_GSIS)

        SharedFunction.ShowInfoMessage("Changes has been saved")
    End Sub

    Private Sub btnTestConnection_eCard_Click(sender As System.Object, e As System.EventArgs) Handles btnTestConnection_eCard.Click
        SharedFunction.ReportToApp()

        Dim sb As New System.Text.StringBuilder
        If txtServer_GSIS.Text = "" Then sb.AppendLine("Please enter server")
        If txtDatabase_eCard.Text = "" Then sb.AppendLine("Please enter database")
        If txtUser_GSIS.Text = "" Then sb.AppendLine("Please enter user")
        If txtPassword_GSIS.Text = "" Then sb.AppendLine("Please enter password")

        If sb.ToString <> "" Then
            SharedFunction.ShowErrorMessage(sb.ToString)
            Return
        End If

        SharedFunction.ControlDisposition(False, Me.Cursor, False, btnSave, btnTestConnection_eCard, btnTestConnection_GSIS)

        Dim DAL As New DAL_UBP_EcardMgr
        Dim ConStr As String = "Server=" & txtServer_eCard.Text & ";Database=" & txtDatabase_eCard.Text & ";User=" & txtUser_eCard.Text & ";Password=" & txtPassword_eCard.Text & ";"
        If DAL.IsConnectionOK(ConStr) Then
            SharedFunction.ShowInfoMessage("Connection success...")
        Else
            SharedFunction.ShowErrorMessage("Connection failed...")
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "TestConn(): " & DAL.ErrorMessage)
        End If
        DAL.Dispose()
        DAL = Nothing

        SharedFunction.ControlDisposition(True, Me.Cursor, False, btnSave, btnTestConnection_eCard, btnTestConnection_GSIS)
    End Sub

    Private Sub btnTestConnection_GSIS_Click(sender As System.Object, e As System.EventArgs) Handles btnTestConnection_GSIS.Click
        SharedFunction.ReportToApp()

        Dim sb As New System.Text.StringBuilder
        If txtDSN_GSIS.Text = "" Then sb.AppendLine("Please enter DSN")
        If txtServer_GSIS.Text = "" Then sb.AppendLine("Please enter server")
        If txtPort_GSIS.Text = "" Then sb.AppendLine("Please enter port")
        If txtUser_GSIS.Text = "" Then sb.AppendLine("Please enter user")
        If txtPassword_GSIS.Text = "" Then sb.AppendLine("Please enter password")

        If sb.ToString <> "" Then
            SharedFunction.ShowErrorMessage(sb.ToString)
            Return
        End If

        SharedFunction.ControlDisposition(False, Me.Cursor, False, btnSave, btnTestConnection_eCard, btnTestConnection_GSIS)

        Dim DAL As New DAL_GSIS_Oracle
        Dim ConStr As String = String.Format("Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = {0})(PORT = {1})))(CONNECT_DATA=(SERVICE_NAME = {2})));User Id={3};Password={4};", txtServer_GSIS.Text, txtPort_GSIS.Text, txtDSN_GSIS.Text, txtUser_GSIS.Text, txtPassword_GSIS.Text)
        If DAL.IsConnectionOK(ConStr) Then
            SharedFunction.ShowInfoMessage("Connection success...")
        Else
            SharedFunction.ShowErrorMessage("Connection failed...")
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "TestConn(): " & DAL.ErrorMessage)
        End If
        DAL = Nothing

        SharedFunction.ControlDisposition(True, Me.Cursor, False, btnSave, btnTestConnection_eCard, btnTestConnection_GSIS)
    End Sub

End Class