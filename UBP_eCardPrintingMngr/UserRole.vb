Public Class UserRole

    Private dtUserRole As DataTable
    Private Role(1) As String
    Private OperatorName As String = ""

    Public Sub New(ByVal OperatorName As String, ByRef dtUserRole As DataTable, ByRef Role() As String)

        ' This call is required by the designer.
        InitializeComponent()
        Me.dtUserRole = dtUserRole
        Me.Role = Role
        Me.OperatorName = OperatorName

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub UserRole_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblUser.Text = "Name: " & OperatorName
        If Not Role Is Nothing Then lblRole.Text = "Primary Role: " & Role(1)

        BindGrid()
    End Sub

    Private Sub BindGrid()
        grid.DataSource = dtUserRole
    End Sub

    Private Sub grid_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellContentDoubleClick
        SharedFunction.ReportToApp()

        Dim bln As Boolean = dtUserRole.Select("RoleID=" & grid.CurrentRow.Cells(0).Value.ToString)(0)("IsSelected")
        dtUserRole.Select("RoleID=" & grid.CurrentRow.Cells(0).Value.ToString)(0)("IsSelected") = Not bln
        BindGrid()
    End Sub

    Private Sub btnSetPrimary_Click(sender As System.Object, e As System.EventArgs) Handles btnSetPrimary.Click
        If dtUserRole.Select("RoleID=" & grid.CurrentRow.Cells(0).Value.ToString)(0)("IsSelected") Then
            If SharedFunction.ShowMessage(String.Format("Set '{0}' as primary role?", grid.CurrentRow.Cells(1).Value.ToString.Trim)) = Windows.Forms.DialogResult.Yes Then
                Role(0) = grid.CurrentRow.Cells(0).Value
                Role(1) = grid.CurrentRow.Cells(1).Value.ToString.Trim
                lblRole.Text = "Primary Role: " & Role(1)
            End If
        End If
    End Sub
End Class