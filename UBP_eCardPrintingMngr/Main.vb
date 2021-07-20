Public Class Main

    Private Delegate Sub Action()
    Public _frmExisting As Form

    Private Sub Main_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        SharedFunction.ReportToApp()
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'SharedFunction.LogOut()
    End Sub

    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FormLoad()

        lblDate.Text = Now.ToString("dddd, MMM dd, yyyy")
        gridTxn.AutoGenerateColumns = False
        gridSpoiled.AutoGenerateColumns = False
        BindWeeklySummary_CardTxn()
        BindWeeklySummary_Spoiled()

        SharedFunction.ReportToApp()

        Timer1.Start()
    End Sub

    Private Sub FormLoad()
        Me.Hide()
        LogIN.ShowDialog()
        tsslUserVariable.Text = String.Format("User: {0}  |  Role: {1}  |  Last login time: {2}", SharedFunction.CompleteName, SharedFunction.UserRoleDesc, SharedFunction.LogIN_Time)
        ResetToolstripMenu()
        LogIN.ResetForm()
        MenuDisposition()
        IsMsgCloseAppAppeared = False
        Me.Show()
    End Sub

    Private Sub ResetToolstripMenu()
        tsddbCard.Visible = True
        tssCard.Visible = True
        tsddbReport.Visible = True
        tssReport.Visible = True
        tsddbAdministration.Visible = True
        tssAdmin.Visible = True
        tsddbSystemAdmin.Visible = True
        tssSystemAdmin.Visible = True
    End Sub

    Private Sub MenuDisposition()
        Select Case DirectCast(SharedFunction.UserRoleID, DataKeysEnum.RoleID)
            Case DataKeysEnum.RoleID.Viewer
                tsddbProcess.Visible = False
                tsddbCard.Visible = False
                tssCard.Visible = False
                tsddbReport.Visible = False
                tssReport.Visible = False
                tsddbAdministration.Visible = False
                tssAdmin.Visible = False
                tsddbSystemAdmin.Visible = False
                tssSystemAdmin.Visible = False
            Case DataKeysEnum.RoleID.CardIssuer, DataKeysEnum.RoleID.Supervisor
                'tsddbCard.Visible = False
                'tsddbReport.Visible = False
                'tssReport.Visible = False
                tsddbAdministration.Visible = False
                tssAdmin.Visible = False
                tsddbSystemAdmin.Visible = False
                tssSystemAdmin.Visible = False
                'Case DataKeysEnum.RoleID.Supervisor
                '    tsddbAdministration.Visible = False
                '    tssAdmin.Visible = False
                '    tsddbSystemAdmin.Visible = False
                '    tssSystemAdmin.Visible = False
            Case DataKeysEnum.RoleID.Admin
                tsddbSystemAdmin.Visible = False
                tssSystemAdmin.Visible = False
            Case DataKeysEnum.RoleID.SystemAdmin
        End Select
    End Sub

    Private Sub ShowForm(ByVal _frm As Form)
        ShowLoader()
        My.Settings.MainLoaderFlag = True
        My.Settings.Save()
        StartThread()

        If _frmExisting Is Nothing Then
            _frmExisting = _frm
            SharedFunction.ShowForm(_frm)
            _frmExisting = Nothing
        Else
            SetFormStateToNormal()
        End If
    End Sub

    Private Sub ToolStripDropDownButton7_Click(sender As System.Object, e As System.EventArgs) Handles tsddbCIR.Click
        ShowForm(New CIR)
    End Sub

    Private Sub InventoryToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles InventoryToolStripMenuItem1.Click
        'Dim strWhereCriteria As String = String.Format(" WHERE CAST(dbo.tblCardInventory.DateTimePosted as date) BETWEEN '{0}' AND '{1}'", Now.ToString("MM/dd/yyyy"), Now.ToString("MM/dd/yyyy"))
        Dim strWhereCriteria As String = String.Format(" WHERE CONVERT(char(10),dbo.tblCardInventory.DateTimePosted,101) BETWEEN '{0}' AND '{1}'", Now.ToString("MM/dd/yyyy"), Now.ToString("MM/dd/yyyy"))

        'temp
        strWhereCriteria = String.Format(" WHERE dbo.tblCardInventory.DateTimePosted BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", "12/12/2010", Now.ToString("MM/dd/yyyy"))
        ShowForm(New ListForm(SourceTable.CardInventoryTable(strWhereCriteria), DataKeysEnum.TableName.Inventory))
    End Sub

    Private Sub TransactionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TransactionToolStripMenuItem.Click
        'Dim strWhereCriteria As String = String.Format(" WHERE CAST(dbo.tblCardTxn.DateTimePosted as date) BETWEEN '{0}' AND '{1}'", Now.ToString("MM/dd/yyyy"), Now.ToString("MM/dd/yyyy"))
        'Dim strWhereCriteria As String = String.Format(" WHERE CONVERT(char(10),dbo.tblCardTxn.DateTimePosted,101) BETWEEN '{0}' AND '{1}'", Now.ToString("MM/dd/yyyy"), Now.ToString("MM/dd/yyyy"))
        'ShowForm(New ListForm(SourceTable.CardTxnTable(strWhereCriteria), DataKeysEnum.TableName.CardTxn))
    End Sub

    Private Sub SetFormStateToNormal()
        If _frmExisting.WindowState = FormWindowState.Minimized Then
            _frmExisting.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub SpoiledToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SpoiledToolStripMenuItem1.Click
        'Dim strWhereCriteria As String = String.Format(" WHERE CAST(dbo.tblSpoiledTxn.DateTimePosted as date) BETWEEN '{0}' AND '{1}'", Now.ToString("MM/dd/yyyy"), Now.ToString("MM/dd/yyyy"))
        Dim strWhereCriteria As String = String.Format(" WHERE CONVERT(char(10),dbo.tblSpoiledTxn.DateTimePosted,101) BETWEEN '{0}' AND '{1}'", Now.ToString("MM/dd/yyyy"), Now.ToString("MM/dd/yyyy"))
        ShowForm(New ListForm(SourceTable.SpoiledTxnTable(strWhereCriteria), DataKeysEnum.TableName.Spoiled))
    End Sub

    Private Sub AvailableToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AvailableToolStripMenuItem.Click
        SharedFunction.ShowForm(New ReportViewer(DataKeysEnum.Report.AvailableInventory, False))
    End Sub

    Private Sub AssignedToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AssignedToolStripMenuItem.Click
        SharedFunction.ShowForm(New ReportViewer(DataKeysEnum.Report.CardInventory))
    End Sub

    Private Sub TransmittalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TransmittalToolStripMenuItem.Click
        SharedFunction.ShowForm(New ReportViewer(DataKeysEnum.Report.CardTxn_Transmittal))
    End Sub

    Private Sub UserToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles UserToolStripMenuItem.Click
        Dim strWhereCriteria As String = " WHERE ISNULL(IsDeleted,0) = 0"
        ShowForm(New ListForm(SourceTable.UserTable(strWhereCriteria), DataKeysEnum.TableName.User))
    End Sub

    Private Sub RoleToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles RoleToolStripMenuItem.Click
        ShowForm(New ListForm(SourceTable.RoleTable, DataKeysEnum.TableName.Role))
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        ShowForm(New Setting)
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        ShowForm(New ChangePassword)
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        SharedFunction.LogOut()
        IsMsgCloseAppAppeared = True
       FormLoad
    End Sub

    Private Sub SystemToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SystemToolStripMenuItem1.Click
        ShowForm(New ListForm(SourceTable.SystemLogTable(" ORDER BY SystemLogID DESC"), DataKeysEnum.TableName.SystemLog))
    End Sub

    Private Sub ErrorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ErrorToolStripMenuItem.Click
        ShowForm(New ErrorLogViewer)
    End Sub

    Private Sub tsddbSystemAdmin_Click(sender As System.Object, e As System.EventArgs) Handles tsddbSystemAdmin.Click

    End Sub

    Public Sub ShowLoader()
        pbLoader.Image = Image.FromFile(SharedFunction.LoadingImage)
    End Sub

    Private _thread As System.Threading.Thread

    Private Sub StartThread()
        Dim objNewThread As New System.Threading.Thread(AddressOf DisposeLoader)
        objNewThread.Start()
        _thread = objNewThread
    End Sub

    Public Sub DisposeLoader()
        While My.Settings.MainLoaderFlag
            System.Threading.Thread.Sleep(500)
        End While

        pbLoader.Image = Nothing
    End Sub

    Private Sub MFToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MFToolStripMenuItem.Click
        SharedFunction.ShowForm(New ReportViewer(DataKeysEnum.Report.MF_Report))
    End Sub

    Private Sub ProfileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProfileToolStripMenuItem.Click
        SharedFunction.ShowForm(New CardProfile)
    End Sub

    Private Sub BindWeeklySummary_CardTxn()
        Try
            Dim DAL As New DAL_UBP_EcardMgr
            If DAL.SelectWeeklySummary_CardTxn() Then
                gridTxn.DataSource = DAL.TableResult
            End If
            DAL.Dispose()
            DAL = Nothing
        Catch ex As Exception
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "BindWeeklySummary_CardTxn(): Runtime error catched " & ex.Message)
        End Try
    End Sub

    Private Sub BindWeeklySummary_Spoiled()
        Try
            Dim DAL As New DAL_UBP_EcardMgr
            If DAL.SelectWeeklySummary_Spoiled() Then
                gridSpoiled.DataSource = DAL.TableResult
            End If
            DAL.Dispose()
            DAL = Nothing
        Catch ex As Exception
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "BindWeeklySummary_Spoiled(): Runtime error catched " & ex.Message)
        End Try
    End Sub

    Private Sub lbRefreshCardTxn_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbRefreshCardTxn.LinkClicked
        BindWeeklySummary_CardTxn()
    End Sub

    Private Sub lbRefreshSpoiled_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbRefreshSpoiled.LinkClicked
        BindWeeklySummary_Spoiled()
    End Sub

    Private Sub TransactionToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles TransactionToolStripMenuItem2.Click
        SharedFunction.ShowForm(New ReportViewer(DataKeysEnum.Report.CardTxnList))
    End Sub

    Private Sub SpoiledToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SpoiledToolStripMenuItem.Click
        SharedFunction.ShowForm(New ReportViewer(DataKeysEnum.Report.SpoiledTxn))
    End Sub

    Private Sub ListToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListToolStripMenuItem.Click
        Dim strWhereCriteria As String = String.Format(" WHERE CONVERT(char(10),dbo.tblCardTxn.DateTimePosted,101) BETWEEN '{0}' AND '{1}'", Now.ToString("MM/dd/yyyy"), Now.ToString("MM/dd/yyyy"))
        'temp
        strWhereCriteria = String.Format(" WHERE dbo.tblCardTxn.DateTimePosted BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", "12/12/2010", Now.ToString("MM/dd/yyyy"))
        ShowForm(New ListForm(SourceTable.CardTxnTable(strWhereCriteria), DataKeysEnum.TableName.CardTxn))
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddNewToolStripMenuItem.Click
        Dim _frm1 As New AddCardTxn() 'Me)
        _frm1.StartPosition = FormStartPosition.Manual
        _frm1.Location = New Point(0, 0)
        SharedFunction.ShowForm(_frm1)
    End Sub

    Private IsMsgCloseAppAppeared As Boolean

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Not IsMsgCloseAppAppeared Then
            Dim intLoggedUserID As Integer = SharedFunction.GetLoggedUserID(SharedFunction.UserID)
            If intLoggedUserID = SharedFunction.LoggedUserID Then
                Dim intSecondsDiff As Long = DateDiff(DateInterval.Second, SharedFunction.ReportTime, Now)

                If intSecondsDiff > My.Settings.IdleLimit Then
                    IsMsgCloseAppAppeared = True
                    SharedFunction.ShowInfoMessage("Your session has expired. Application will now exit.")
                    Dim DAL As New DAL_UBP_EcardMgr
                    DAL.AddSystemLog(String.Format("{0} session expired", SharedFunction.CompleteName), "Main", SharedFunction.UserID)
                    DAL.Dispose()
                    DAL = Nothing
                    SharedFunction.LogOut()
                    Close()
                    Application.Exit()
                End If
            Else
                IsMsgCloseAppAppeared = True
                SharedFunction.ShowInfoMessage("Simultaneous login detected. Application will now exit.")
                Dim DAL As New DAL_UBP_EcardMgr
                DAL.AddSystemLog(String.Format("{0} have simultaneous login detected", SharedFunction.CompleteName), "Main", SharedFunction.UserID)
                DAL.Dispose()
                DAL = Nothing
                'SharedFunction.LogOut()
                Close()
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        SharedFunction.ShowForm(New BackupDbase)
    End Sub

End Class