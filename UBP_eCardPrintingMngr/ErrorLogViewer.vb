Public Class ErrorLogViewer

    Private Sub ErrorLogViewer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ViewLog()

        My.Settings.MainLoaderFlag = False
        My.Settings.Save()
    End Sub

    Private Sub ViewLog()
        Dim ErrorLog As String = "Logs\" & DateTimePicker1.Value.ToString("MMddyyyy") & "\Error.log"
        If System.IO.File.Exists(ErrorLog) Then
            rtb.LoadFile(ErrorLog, RichTextBoxStreamType.PlainText)
        Else
            rtb.Clear()
            rtb.AppendText("** NO LOG FOUND **")
        End If
        rtb.ScrollToCaret()
    End Sub

    Private Sub btnView_Click(sender As System.Object, e As System.EventArgs) Handles btnView.Click
        ViewLog()
    End Sub

End Class