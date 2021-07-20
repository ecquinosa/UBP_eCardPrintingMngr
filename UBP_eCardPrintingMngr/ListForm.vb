Public Class ListForm

    Private _dt As DataTable
    Private _tableName As DataKeysEnum.TableName

    Public Sub New(ByVal dt As DataTable, ByVal TableName As DataKeysEnum.TableName)

        ' This call is required by the designer.
        InitializeComponent()
        _dt = dt
        _tableName = TableName
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub ListForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        SharedFunction.ReportToApp()
    End Sub

    Private Sub ListForm_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SharedFunction.ClearMainFormExistingForm()
    End Sub

    Private isdone As Boolean = False

    Private Sub ListForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = TableName()
        MenuDisposition()
        BindGrid()

        My.Settings.MainLoaderFlag = False
        My.Settings.Save()
    End Sub

    Private Sub BindGrid()
        grid.DataSource = _dt

        Try
            Select Case _tableName
                Case DataKeysEnum.TableName.Inventory
                    grid.Columns("CardInvID").HeaderText = "ID"
                    grid.Columns("Card_No").HeaderText = "Card#"
                    grid.Columns("IsSpoiled").HeaderText = "Spoiled"
                    grid.Columns("DateTimePosted").HeaderText = "SwipedDate"
                Case Else
                    grid.Columns(0).HeaderText = "ID"
            End Select
        Catch ex As Exception
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "BindGrid(): Runtime error catched " & ex.Message)
        End Try
    End Sub

    Private Sub MenuDisposition()
        Select Case DirectCast(SharedFunction.UserRoleID, DataKeysEnum.RoleID)
            Case DataKeysEnum.RoleID.Viewer
                tsbAdd.Visible = False
                tsbEdit.Visible = False
                'Case DataKeysEnum.RoleID.Viewer, DataKeysEnum.RoleID.CardIssuer, DataKeysEnum.RoleID.Supervisor
            Case Else
                Select Case _tableName
                    Case DataKeysEnum.TableName.CardTxn
                        tsbAdd.Visible = False
                        tsbEdit.Visible = False
                        tsbSpoil.Visible = True
                        tsbRecall.Visible = True
                        tsbCardPreview.Visible = True
                        tsbCIR.Visible = True
                        tsbMailing.Visible = True
                    Case DataKeysEnum.TableName.Inventory
                        tsbEdit.Visible = False
                        tsbSpoil.Visible = True
                        tsbRecall.Visible = True
                    Case DataKeysEnum.TableName.Spoiled
                        tsbAdd.Visible = False
                        tsbEdit.Visible = False
                        tsbRecall.Visible = True
                    Case DataKeysEnum.TableName.Role
                        tsbSearch.Visible = False
                        tsbEdit.Visible = False
                    Case DataKeysEnum.TableName.SystemLog
                        tsbAdd.Visible = False
                        tsbEdit.Visible = False
                        tsbSearch.Visible = False
                End Select
        End Select
    End Sub

    Private Sub tsbAdd_Click(sender As System.Object, e As System.EventArgs) Handles tsbAdd.Click
        Select Case _tableName
            Case DataKeysEnum.TableName.User
                SharedFunction.ShowForm(New AddUser())

                Dim strWhereCriteria As String = " WHERE ISNULL(IsDeleted,0) = 0"
                _dt = SourceTable.UserTable(strWhereCriteria)
            Case DataKeysEnum.TableName.Inventory
                SharedFunction.ShowForm(New AddCardInventory)

                Dim strWhereCriteria As String = String.Format(" WHERE CONVERT(char(10),dbo.tblCardInventory.DateTimePosted,101) BETWEEN '{0}' AND '{1}'", Now.ToString("MM/dd/yyyy"), Now.ToString("MM/dd/yyyy"))
                _dt = SourceTable.CardInventoryTable(strWhereCriteria)
            Case DataKeysEnum.TableName.CardTxn
                Me.Hide()
                Dim _frm1 As New AddCardTxn()
                _frm1.StartPosition = FormStartPosition.Manual
                _frm1.Location = New Point(0, 0)
                SharedFunction.ShowForm(_frm1, False)
        End Select

        BindGrid()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Function TableName() As String
        Select Case _tableName
            Case DataKeysEnum.TableName.CardTxn
                Return "Card Transaction List"
            Case DataKeysEnum.TableName.Inventory
                Return "Card Inventory List"
            Case DataKeysEnum.TableName.Role
                Return "System Role List"
            Case DataKeysEnum.TableName.Spoiled
                Return "Spoiled Card List"
            Case DataKeysEnum.TableName.User
                Return "System User List"
            Case DataKeysEnum.TableName.SystemLog
                Return "System Log List"
        End Select
    End Function

    Private Sub tsbSpoil_Click(sender As System.Object, e As System.EventArgs) Handles tsbSpoil.Click
        Select Case _tableName
            Case DataKeysEnum.TableName.CardTxn
                If Not CBool(grid.CurrentRow.Cells(12).Value) Then
                    SharedFunction.ShowForm(New SpoilTxn(grid.CurrentRow.Cells(3).Value, grid.CurrentRow.Cells(4).Value, grid.CurrentRow.Cells(0).Value))
                    _dt = SourceTable.CardTxnTable
                Else
                    SharedFunction.ShowInfoMessage("Transaction is already spoiled")
                End If
            Case DataKeysEnum.TableName.Inventory
                If Not CBool(grid.CurrentRow.Cells(7).Value) Then
                    SharedFunction.ShowForm(New SpoilTxn(grid.CurrentRow.Cells(1).Value, "N/A", "N/A"))
                    _dt = SourceTable.CardInventoryTable
                Else
                    SharedFunction.ShowInfoMessage("Card is already spoiled")
                End If
        End Select

        BindGrid()
    End Sub

    Private Sub tsbCIR_Click(sender As System.Object, e As System.EventArgs) Handles tsbCIR.Click
        Try
            SharedFunction.ShowForm(New ReportViewer(DataKeysEnum.Report.CardTxn_CIR_New, False, grid.CurrentRow.Cells(0).Value))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsbMailing_Click(sender As System.Object, e As System.EventArgs) Handles tsbMailing.Click
        Try
            SharedFunction.ShowForm(New ReportViewer(DataKeysEnum.Report.CardTxn_Mailing, False, grid.CurrentRow.Cells(0).Value))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsbSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsbSearch.Click
        Dim _frm As New SearchData(_tableName)
        SharedFunction.ShowForm(_frm)
        '_dt = SourceTable.CardTxnTable(_frm.WhereCriteria)

        If _frm.IsSearchData Then
            Select Case _tableName
                Case DataKeysEnum.TableName.CardTxn
                    _dt = SourceTable.CardTxnTable(_frm.WhereCriteria)
                Case DataKeysEnum.TableName.Inventory
                    _dt = SourceTable.CardInventoryTable(_frm.WhereCriteria)
                Case DataKeysEnum.TableName.Spoiled
                    _dt = SourceTable.SpoiledTxnTable(_frm.WhereCriteria)
            End Select

            BindGrid()
        End If
    End Sub

    Private Sub tsbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tsbDelete.Click

    End Sub

    Private Sub tsbEdit_Click(sender As System.Object, e As System.EventArgs) Handles tsbEdit.Click
        Select Case _tableName
            Case DataKeysEnum.TableName.User
                SharedFunction.ShowForm(New AddUser(grid.CurrentRow.Cells(0).Value))

                Dim strWhereCriteria As String = " WHERE ISNULL(IsDeleted,0) = 0"
                _dt = SourceTable.UserTable(strWhereCriteria)
            Case DataKeysEnum.TableName.CardTxn
                Me.Hide()
                Dim _frm1 As New AddCardTxn() 'Me)
                _frm1.StartPosition = FormStartPosition.Manual
                _frm1.Location = New Point(0, 0)
                SharedFunction.ShowForm(_frm1, False)
        End Select

        BindGrid()
    End Sub

    Private Sub CardPreview(ByVal IsPrintPhoto As Boolean, ByVal IsCardPreviewOnly As Boolean)
        Try
            'SharedFunction.PrintCard(grid.CurrentRow.Cells(5).Value, grid.CurrentRow.Cells(4).Value, IO.File.ReadAllBytes("1.jpg"), grid.CurrentRow.Cells("CardProdType").Value)
            'Return

            Dim DAL As New DAL_GSIS_Oracle
            If DAL.SelectPhotoAndSignature(grid.CurrentRow.Cells(4).Value) Then
                Dim rw As DataRow = DAL.TableResult.Rows(0)
                Dim strCardProdType As String = ""
                Dim strCardType As String = ""
                Dim strGSISNo As String = ""
                Dim strAcctNo As String = ""

                If Not IsDBNull(grid.CurrentRow.Cells("CardProdType").Value) Then strCardProdType = grid.CurrentRow.Cells("CardProdType").Value
                If Not IsDBNull(grid.CurrentRow.Cells("CardType").Value) Then strCardType = grid.CurrentRow.Cells("CardType").Value
                If Not IsDBNull(grid.CurrentRow.Cells("GSIS_No").Value) Then strGSISNo = grid.CurrentRow.Cells("GSIS_No").Value
                If Not IsDBNull(grid.CurrentRow.Cells("AcctNo").Value) Then strAcctNo = grid.CurrentRow.Cells("AcctNo").Value

                If strCardProdType.ToUpper = SharedFunction.CardType_VISA Then
                    Select Case strCardType.Trim.ToUpper
                        Case "RENEWAL", "REPLACEMENT"
                            'strGSISNo = String.Format("{0} \ {1}", strAcctNo, strGSISNo)
                            strGSISNo = String.Format("{0}", strGSISNo)
                        Case Else
                            strGSISNo = String.Format("                         \ {0}", strGSISNo)
                    End Select
                End If

                'strGSISNo = String.Format("{0}", strGSISNo)
                SharedFunction.PrintCard(SharedFunction.CompleteName2(grid.CurrentRow.Cells("FName").Value, grid.CurrentRow.Cells("MName").Value, grid.CurrentRow.Cells("LName").Value), strGSISNo, rw("PHOTO"), strCardProdType, IsCardPreviewOnly, IsPrintPhoto)
            Else
                SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "tsbCardPreview_Click(): Error catched " & DAL.ErrorMessage)
            End If
            DAL = Nothing
        Catch ex As Exception
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "tsbCardPreview_Click(): Runtime error catched " & ex.Message)
        End Try
    End Sub

    Private Sub WithPhotoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WithPhotoToolStripMenuItem.Click
        Try
            CardPreview(True, True)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub WithoutPhotoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WithoutPhotoToolStripMenuItem.Click
        Try
            CardPreview(False, True)
        Catch ex As Exception
        End Try
    End Sub
    
    Private Sub tsbRecall_Click(sender As System.Object, e As System.EventArgs) Handles tsbRecall.Click
        If Not CBool(grid.CurrentRow.Cells("IsSpoiled").Value) Then
            SharedFunction.ShowInfoMessage("Selected item is not spoiled")
        Else
            If SharedFunction.ShowMessage("Are you sure you want to recall spoiled txn?") = Windows.Forms.DialogResult.Yes Then
                Select Case _tableName
                    Case DataKeysEnum.TableName.Inventory
                        Dim DAL As New DAL_UBP_EcardMgr
                        DAL.ExecuteQuery("UPDATE dbo.tblCardInventory SET IsSpoiled=0 WHERE CardInvID = " & grid.CurrentRow.Cells(0).Value)
                        DAL.ExecuteQuery("UPDATE dbo.tblSpoiledTxn SET IsRecalled=1 WHERE Card_No = '" & grid.CurrentRow.Cells("Card_No").Value.ToString.Trim & "'")
                        DAL.AddSystemLog(String.Format("{0} recalled cardno#{1}", SharedFunction.CompleteName, grid.CurrentRow.Cells("Card_No").Value.ToString.Trim), "CardInventory", SharedFunction.UserID)
                        DAL.Dispose()
                        DAL = Nothing
                    Case DataKeysEnum.TableName.CardTxn
                        Dim DAL As New DAL_UBP_EcardMgr
                        DAL.ExecuteQuery("UPDATE dbo.tblCardTxn SET IsSpoiled=0 WHERE CardTxnID = " & grid.CurrentRow.Cells(0).Value)
                        DAL.ExecuteQuery("UPDATE dbo.tblSpoiledTxn SET IsRecalled=1 WHERE Card_No = '" & grid.CurrentRow.Cells("Card_No").Value.ToString.Trim & "'")
                        DAL.AddSystemLog(String.Format("{0} recalled cardno#{1}", SharedFunction.CompleteName, grid.CurrentRow.Cells("Card_No").Value.ToString.Trim), "CardInventory", SharedFunction.UserID)
                        DAL.Dispose()
                        DAL = Nothing
                End Select
            End If
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Try
            If SharedFunction.ShowMessage(String.Format("Are you sure you want to print card Card#{0} and GSIS#{1}?", grid.CurrentRow.Cells("Card_No").Value.ToString.Trim, grid.CurrentRow.Cells("GSIS_No").Value.ToString.Trim)) = Windows.Forms.DialogResult.Yes Then
                CardPreview(True, False)
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class