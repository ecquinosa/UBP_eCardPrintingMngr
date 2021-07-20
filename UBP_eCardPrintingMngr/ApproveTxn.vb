Public Class ApproveTxn

    Public Approver As String
    Public IsApprove As Boolean

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        SharedFunction.ReportToApp()

        Dim DAL As New DAL_UBP_EcardMgr
        Try
            If txtUsername.Text = "" And txtPassword.Text = "" Then
                lblStatus.Text = "Please enter valid approver's credential to proceed"
                lblStatus.ForeColor = SharedFunction.ErrorColor
                Return
            ElseIf txtUsername.Text <> "" And txtPassword.Text = "" Then
                lblStatus.Text = "Please enter valid approver's credential to proceed"
                lblStatus.ForeColor = SharedFunction.ErrorColor
                Return
            ElseIf txtUsername.Text = "" And txtPassword.Text <> "" Then
                lblStatus.Text = "Please enter valid approver's credential to proceed"
                lblStatus.ForeColor = SharedFunction.ErrorColor
                Return
            Else
                Dim sb2 As New System.Text.StringBuilder
                sb2.Append(String.Format(" AND dbo.tblUser.Username='{0}'", txtUsername.Text))
                sb2.Append(String.Format(" AND dbo.tblUser.RoleID IN ({0})", DataKeysEnum.RoleID.Supervisor & "," & DataKeysEnum.RoleID.Admin & "," & DataKeysEnum.RoleID.SystemAdmin))

                If SharedFunction.ValidateLogIN(sb2.ToString, txtPassword.Text, lblStatus) Then
                    Approver = txtUsername.Text
                    IsApprove = True
                    Close()
                Else
                    SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "ApproveTxn(): Error catched " & DAL.ErrorMessage)
                    'SharedFunction.ShowErrorMessage(String.Format("[{0}] Failed to validate account", SharedFunction.TimeStamp.Trim))
                End If
            End If
        Catch ex As Exception
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "ApproveTxn(): Runtime error catched " & ex.Message)
            SharedFunction.ShowErrorMessage(String.Format("[{0}] An error occurred", SharedFunction.TimeStamp.Trim))
        Finally
            DAL.Dispose()
            DAL = Nothing
        End Try
    End Sub

    Private Sub txtPassword_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                btnSubmit.PerformClick()
        End Select
    End Sub
    
End Class