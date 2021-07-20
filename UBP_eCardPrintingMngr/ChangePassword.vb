Public Class ChangePassword

    Private Sub ChangePassword_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ResetForm()
        txtOldPassword.Clear()
        txtNewPassword.Clear()
        txtConfirmPassword.Clear()
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        ResetForm()
    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        SharedFunction.ReportToApp()

        If Not SharedFunction.ValidateControl(ErrorProvider1, txtOldPassword, txtNewPassword, txtConfirmPassword) Then
            lblStatus.Text = "Please complete the required field(s)"
            lblStatus.ForeColor = SharedFunction.ErrorColor
            Return
        Else
            If txtNewPassword.Text.Length < 6 Then
                lblStatus.Text = "Minimum characters required for password is 6"
                lblStatus.ForeColor = SharedFunction.ErrorColor
                Return
            End If
        End If

        Dim DAL As New DAL_UBP_EcardMgr
        If DAL.ExecuteScalar(String.Format("SELECT Password FROM dbo.tblUser WHERE UserID={0}", SharedFunction.UserID)) Then
            If DAL.ObjectResult.ToString.Trim <> EncryptDecrypt.EncryptData(txtOldPassword.Text) Then
                lblStatus.Text = "Please enter valid old password"
                lblStatus.ForeColor = SharedFunction.ErrorColor
                Return
            Else
                If txtNewPassword.Text <> txtConfirmPassword.Text Then
                    lblStatus.Text = "Please enter identical value in new and confirm password"
                    lblStatus.ForeColor = SharedFunction.ErrorColor
                    Return
                Else
                    If DAL.ExecuteQuery(String.Format("UPDATE dbo.tblUser SET Password='{1}' WHERE UserID={0}", SharedFunction.UserID, EncryptDecrypt.EncryptData(txtConfirmPassword.Text))) Then
                        lblStatus.Text = "Password is saved!"
                        lblStatus.ForeColor = SharedFunction.SuccessColor
                        DAL.AddSystemLog(String.Format("{0} changed password", SharedFunction.CompleteName), "ChangePassword", SharedFunction.UserID)
                        ResetForm()
                        Return
                    End If
                End If
            End If
        End If
        DAL.Dispose()
        DAL = Nothing
    End Sub

End Class