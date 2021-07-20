Public Class BackupDbase
    Private Sub BackupDbase_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Function BackupFilename() As String
        Return String.Format("dbcUBP_EcardMgr_{0}.bak", Now.ToString("yyyyMMdd_hhmmss"))
    End Function

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        lblStatus.ForeColor = Color.Black
        txtFilename.Text = BackupFilename()

        If txtPath.Text = "" Then
            lblStatus.Text = "Please enter path in Save To"
            lblStatus.ForeColor = Color.OrangeRed
            Return
        End If

        Dim DAL As New DAL_UBP_EcardMgr
        Dim fileName As String = String.Format("{0}{1}", txtPath.Text, txtFilename.Text)
        If DAL.ExecuteQuery(String.Format("backup database dbcUBP_EcardMgr to disk='{0}'", fileName)) Then
            lblStatus.Text = "Backup success"
            lblStatus.ForeColor = Color.Green
        Else
            lblStatus.Text = "Backup failed"
            lblStatus.ForeColor = Color.OrangeRed
        End If
        DAL.Dispose()
        DAL = Nothing
    End Sub
End Class