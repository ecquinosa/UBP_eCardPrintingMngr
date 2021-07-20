Public Class LogIN

    Private IsLogIN_Success As Boolean

    Private Sub LogIN_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not IsLogIN_Success Then
            Application.Exit()
        End If
    End Sub

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        Dim sb As New System.Text.StringBuilder

        If txtUsername.Text = "" Then sb.AppendLine("Please enter username")
        If txtPassword.Text = "" Then sb.AppendLine("Please enter password")

        If sb.ToString <> "" Then
            'SharedFunction.ShowErrorMessage(sb.ToString)
            lblResult.Text = sb.ToString
            Return
        End If

        If txtUsername.Text = "sysadminoffline" And txtPassword.Text = "ubpallcard2016" Then
            Try
                SharedFunction.SaveToUserVariable(0, "sysadminoffline", "System Administrator (Offline)", 0, "System Administrator", Now, 0)
                IsLogIN_Success = True
                Me.Close()
            Catch ex As Exception
                SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "ValidateLogIn(): Runtime error catched " & ex.Message)
                lblResult.Text = "Login error occurred"
            End Try
        Else
            Dim DAL As New DAL_UBP_EcardMgr
            Try
                Dim sb2 As New System.Text.StringBuilder
                sb2.Append(String.Format(" AND dbo.tblUser.Username='{0}'", txtUsername.Text))
                Dim rw As DataRow

                If SharedFunction.ValidateLogIN(sb2.ToString, txtPassword.Text, lblResult, rw) Then
                    Dim intLoggedUserID As Integer = SharedFunction.GetLoggedUserID(rw("UserID"))
                    If intLoggedUserID = 0 Then
                        DAL.AddLoggedUsers(rw("UserID"))
                        intLoggedUserID = SharedFunction.GetLoggedUserID(rw("UserID"))
                        SharedFunction.SaveToUserVariable(rw("UserID"), rw("Username"), SharedFunction.CompleteName(rw("FName"), rw("MName"), rw("LName")), rw("RoleID"), rw("RoleDesc").ToString.Trim, Now, intLoggedUserID)
                        DAL.AddSystemLog(String.Format("{0} has logged in", SharedFunction.CompleteName), "LogIn", SharedFunction.UserID)
                        IsLogIN_Success = True
                        Me.Dispose()
                        Me.Close()
                    Else
                        If SharedFunction.ShowMessage("User is already logged in. Do you want to continue?") = Windows.Forms.DialogResult.Yes Then
                            SharedFunction.ForceLogOut(rw("UserID"))
                            DAL.AddLoggedUsers(rw("UserID"))
                            intLoggedUserID = SharedFunction.GetLoggedUserID(rw("UserID"))
                            SharedFunction.SaveToUserVariable(rw("UserID"), rw("Username"), SharedFunction.CompleteName(rw("FName"), rw("MName"), rw("LName")), rw("RoleID"), rw("RoleDesc").ToString.Trim, Now, intLoggedUserID)
                            DAL.AddSystemLog(String.Format("{0} has logged in", SharedFunction.CompleteName), "LogIn", SharedFunction.UserID)
                            IsLogIN_Success = True
                            Me.Dispose()
                            Me.Close()
                        End If
                    End If
                End If
            Catch ex As Exception
                SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "ValidateLogIn(): Runtime error occurred " & ex.Message)
                lblResult.Text = "Runtime error occurred"
            Finally
                DAL.Dispose()
                DAL = Nothing
            End Try
            
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim _frm As New Setting
        _frm.ShowDialog()
    End Sub

    Private Sub txtPassword_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        Select e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                btnLogin.PerformClick()
        End Select
    End Sub

    Private Sub LogIN_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub ResetForm()
        txtUsername.Clear()
        txtPassword.Clear()
        IsLogIN_Success = False
        txtUsername.Select()
        txtUsername.Focus()
    End Sub
   
End Class