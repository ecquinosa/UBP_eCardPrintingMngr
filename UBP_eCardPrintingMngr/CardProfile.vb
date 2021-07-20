Public Class CardProfile

    Private Sub CardProfile_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        grid.AutoGenerateColumns = False
        gridProperty.AutoGenerateColumns = False
        BindCardProfiles()

        My.Settings.MainLoaderFlag = False
        My.Settings.Save()
    End Sub

    Private Sub BindCardProfiles()
        Dim DAL As New DAL_UBP_EcardMgr
        If DAL.SelectQuery("SELECT CardProfileID, CardProfileName FROM tblCardProfile") Then
            grid.DataSource = DAL.TableResult
        End If
        DAL.Dispose()
        DAL = Nothing
    End Sub

    Private Sub BindCardProfileProperties(ByVal CardProfileID As Integer)
        Dim DAL As New DAL_UBP_EcardMgr
        If DAL.SelectQuery("SELECT * FROM tblRelCardProfileProperty WHERE CardProfileID=" & CardProfileID) Then
            gridProperty.DataSource = DAL.TableResult
        End If
        DAL.Dispose()
        DAL = Nothing
    End Sub

    Private Sub grid_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles grid.SelectionChanged
        SharedFunction.ReportToApp()

        BindCardProfileProperties(grid.CurrentRow.Cells(0).Value)
    End Sub

    Private gridCPPropertyID As Integer = 0

    Private Sub gridProperty_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridProperty.CellDoubleClick
        SharedFunction.ReportToApp()

        grid.Enabled = False
        gridProperty.Enabled = False
        btnCancel.Visible = True
        btnSave.Visible = True

        gridCPPropertyID = gridProperty.CurrentRow.Cells(0).Value
        Try
            lblPropertyName.Text = gridProperty.CurrentRow.Cells(1).Value.ToString
        Catch ex As Exception
            lblPropertyName.Text = "Property:"
        End Try

        txtTop.Text = FormatValue(gridProperty.CurrentRow.Cells(2).Value)
        txtLeft.Text = FormatValue(gridProperty.CurrentRow.Cells(3).Value)
        txtHeight.Text = FormatValue(gridProperty.CurrentRow.Cells(4).Value)
        txtWidth.Text = FormatValue(gridProperty.CurrentRow.Cells(5).Value)
        txtSize.Text = FormatValue(gridProperty.CurrentRow.Cells(6).Value)
        Try
            txtName.Text = gridProperty.CurrentRow.Cells(7).Value.ToString
        Catch ex As Exception
            txtName.Text = ""
        End Try
    End Sub

    Private Function FormatValue(ByVal value As Object) As Integer
        Try
            Return value.ToString
        Catch ex As Exception
            Return "0"
        End Try

    End Function

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        ResetForm
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim DAL As New DAL_UBP_EcardMgr
        If Not DAL.UpdateRelCardProfileProperty(gridCPPropertyID, txtTop.Text, txtLeft.Text, txtHeight.Text, txtWidth.Text, txtSize.Text, txtName.Text) Then
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "Save(): Error catched " & DAL.ErrorMessage)
            SharedFunction.ShowErrorMessage("Failed to save changes")
        Else
            ResetForm()
        End If
        DAL.Dispose()
        DAL = Nothing

        BindCardProfileProperties(grid.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub ResetForm()
        btnCancel.Visible = False
        btnSave.Visible = False
        grid.Enabled = True
        gridProperty.Enabled = True
        lblPropertyName.Text = "Property:"
        txtTop.Clear()
        txtLeft.Clear()
        txtHeight.Clear()
        txtWidth.Clear()
        txtSize.Clear()
        txtName.Clear()
    End Sub

End Class