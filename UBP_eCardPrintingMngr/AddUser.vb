
Public Class AddUser

    Public Sub New(Optional _UserID As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()
        Me._UserID = _UserID

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private _UserID As Integer
    Private IsActive As Boolean
    Private RoleDesc As String

    Private intTotal As Integer = 0
    Private dt As DataTable
    Private dtUserRole As DataTable
    Private Role(1) As String
    Public IsHaveChanges As Boolean

    Private Sub AddUser_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindUserRole()

        If _UserID > 0 Then
            Me.Text = "USER"
            btnReset.Visible = False
            btnStatus.Visible = True
            btnResetPassword.Visible = True

            Dim dt As DataTable
            Dim DAL As New DAL_UBP_EcardMgr
            If DAL.SelectQuery("SELECT Username, FName, MName, LName, IsActive FROM dbo.tblUser WHERE UserID=" & _UserID) Then
                Dim rw As DataRow = DAL.TableResult.Rows(0)
                txtUsername.Text = rw("Username").ToString.Trim
                txtFName.Text = rw("FName").ToString.Trim
                txtMName.Text = rw("MName").ToString.Trim
                txtLName.Text = rw("LName").ToString.Trim
                IsActive = rw("IsActive")
                If IsActive Then btnStatus.Text = "Deactivate" Else btnStatus.Text = "Activate"
            End If
            DAL.Dispose()
            DAL = Nothing

            RoleDesc = txtRoles.Text
        End If
    End Sub

    Private Sub BindUserRole()
        Dim DAL As New DAL_UBP_EcardMgr
        If DAL.SelectUserRole(_UserID) Then
            dtUserRole = DAL.TableResult
        End If
        DAL.Dispose()
        DAL = Nothing

        txtRoles.Text = SharedFunction.GetRoleDesc(dtUserRole)
    End Sub

    Private Sub Reset()
        txtUsername.Clear()
        txtFName.Clear()
        txtMName.Clear()
        txtLName.Clear()
        txtRoles.Clear()

        lblStatus.Text = "Ready"
        lblStatus.ForeColor = Color.Black
    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        lblStatus.Text = ""

        If Not SharedFunction.ValidateControl(ErrorProvider1, txtUsername, txtFName, txtLName, txtRoles) Then
            lblStatus.Text = "Please complete the required field(s)"
            lblStatus.ForeColor = SharedFunction.ErrorColor
            Return
        End If

        Dim DAL As New DAL_UBP_EcardMgr
        Try
            If _UserID = 0 Then
                If DAL.AddUser(txtUsername.Text, txtFName.Text, txtMName.Text, txtLName.Text, Role(0)) Then
                    Dim result() As String = DAL.ObjectResult.ToString.Split("|")
                    If result(0) = "0" Then
                        DAL.AddSystemLog(String.Format("{0} added user {1}", SharedFunction.CompleteName, txtUsername.Text), "AddUser", SharedFunction.UserID)

                        For Each rw As DataRow In dtUserRole.Rows
                            If CBool(rw("IsSelected")) Then _
                                DAL.ExecuteQuery(String.Format("INSERT INTO tblUserRole (UserID, RoleID) VALUES({0},{1})", result(1), rw(0)))
                        Next
                    Else
                        lblStatus.Text = result(1)
                        lblStatus.ForeColor = SharedFunction.ErrorColor
                        Return
                    End If
                Else
                    SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "SubmitUser(): Error catched " & DAL.ErrorMessage)
                    SharedFunction.ShowErrorMessage("An error occurred while adding user")
                    Return
                End If

                IsHaveChanges = True
                SharedFunction.ShowInfoMessage("New user is added")
                Close()
            Else
                If SharedFunction.ShowMessage("Are you sure you want to submit changes?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    If DAL.ExecuteScalar("SELECT COUNT(UserID) FROM tblUser WHERE Username='" & txtUsername.Text & "' AND UserID<>" & _UserID) Then
                        If CShort(DAL.ObjectResult) = 0 Then
                            DAL.EditUser(_UserID, txtUsername.Text, txtFName.Text, txtMName.Text, txtLName.Text, Role(0))
                            DAL.ExecuteQuery("DELETE FROM tblUserRole WHERE UserID=" & _UserID)
                            For Each rw As DataRow In dtUserRole.Rows
                                If CBool(rw("IsSelected")) Then _
                                    DAL.ExecuteQuery(String.Format("INSERT INTO tblUserRole (UserID, RoleID) VALUES({0},{1})", _UserID, rw(0)))
                            Next

                            SharedFunction.ShowInfoMessage("Saved!")
                        Else
                            SharedFunction.ShowErrorMessage("Duplicate username is not allowed")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "SubmitUser(): Runtime error catched " & ex.Message)
            SharedFunction.ShowErrorMessage("An error occurred while adding user")
        Finally
            DAL.Dispose()
            DAL = Nothing
        End Try
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        SharedFunction.ReportToApp()

        Dim OperatorName As String = String.Format("{0}{1}{2}", txtFName.Text, IIf(txtMName.Text = "", " ", " " & txtMName.Text & " "), txtLName.Text)
        SharedFunction.ShowForm(New UserRole(OperatorName, dtUserRole, Role))

        txtRoles.Text = SharedFunction.GetRoleDesc(dtUserRole)
    End Sub

    Private Sub btnStatus_Click(sender As System.Object, e As System.EventArgs) Handles btnStatus.Click
        Dim DAL As New DAL_UBP_EcardMgr
        Dim status As String = IIf(IsActive, "deactivated", "activated")
        If DAL.ChangeUserStatus(_UserID, Not IsActive) Then
            DAL.AddSystemLog(String.Format("{0} changed status of user {1} to {2}", SharedFunction.CompleteName, txtUsername.Text, status), "AddUser", SharedFunction.UserID)
            IsActive = Not IsActive
            If IsActive Then btnStatus.Text = "Deactivate" Else btnStatus.Text = "Activate"
            SharedFunction.ShowInfoMessage("User status has been " & status)
        Else
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "ChangeStatus(): Error catched " & DAL.ErrorMessage)
            SharedFunction.ShowErrorMessage("Failed to change user status")
        End If
        DAL.Dispose()
        DAL = Nothing
    End Sub

    Private Sub btnResetPassword_Click(sender As System.Object, e As System.EventArgs) Handles btnResetPassword.Click
        Dim DAL As New DAL_UBP_EcardMgr
        Dim status As String = IIf(IsActive, "deactivated", "activated")
        If DAL.ResetPassword(_UserID) Then
            DAL.AddSystemLog(String.Format("{0} reset password of user {1}", SharedFunction.CompleteName, txtUsername.Text), "AddUser", SharedFunction.UserID)
            SharedFunction.ShowInfoMessage("User password has been reset")
        Else
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "ResetPassword(): Error catched " & DAL.ErrorMessage)
            SharedFunction.ShowErrorMessage("Failed to reset password")
        End If
        DAL.Dispose()
        DAL = Nothing
    End Sub
End Class