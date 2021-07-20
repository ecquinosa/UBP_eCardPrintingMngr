
Public Class AddCardInventory

    Private intTotal As Integer = 0
    Private dt As DataTable
    Public IsSubmitted As Boolean

    Private Sub AddCardInventory_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If dt.DefaultView.Count > 0 Then
            If Not IsSubmitted Then
                If SharedFunction.ShowMessage("Swiped card(s) is/ are not yet submitted? Continue without saving?") = Windows.Forms.DialogResult.No Then
                    e.Cancel = False
                End If
            End If
        End If
    End Sub

    Private Sub AddCardInventory_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        grid.AutoGenerateColumns = False
        txtCardNo.Focus()
        dt = New DataTable
        dt.Columns.Add("CardNo", Type.GetType("System.String"))
        dt.Columns.Add("ExpiryDate", Type.GetType("System.String"))
        dt.Columns.Add("Magstripe", Type.GetType("System.String"))
        dt.Columns.Add("CardProdType", Type.GetType("System.String"))

        AddHandler txtCardNo.DoubleClick, AddressOf SharedFunction.txtBox_DoubleClick
        AddHandler txtLast3Digits.DoubleClick, AddressOf SharedFunction.txtBox_DoubleClick

        BindGrid()
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub Reset()
        intTotal = 0
        txtCardNo.Clear()
        If Not dt Is Nothing Then dt.Clear()
        txtCardNo.Focus()
        lblTotal.Text = String.Format("TOTAL: {0}", 0)
    End Sub

    Private Sub grid_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellContentDoubleClick
        Try
            If SharedFunction.ShowMessage(String.Format("Are you sure you want to delete {0}?", grid.CurrentCell.Value.ToString)) = Windows.Forms.DialogResult.Yes Then
                dt.Select("CardNo='" & grid.CurrentCell.Value.ToString & "'")(0).Delete()
                BindGrid()
            End If
        Catch ex As Exception
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & String.Format("grid_CellContentDoubleClick(): Runtime error catched {0}", ex.Message))
        End Try
        
    End Sub

    Dim intKeyPressCntr As Integer

    Private Sub txtCardNo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCardNo.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                SharedFunction.ReportToApp()

                Dim IsValid As Boolean = False
                If txtCardNo.Text.Contains("=") Then IsValid = True
                If txtCardNo.Text.Contains("^") Then IsValid = True

                'If Not txtCardNo.Text.Contains("=") Then
                If Not IsValid Then
                    SharedFunction.ShowErrorMessage("Please swipe valid OPLUS or VISA card")
                    txtCardNo.SelectAll()
                    txtCardNo.Focus()
                    Return
                End If

                If txtCardNo.Text.Trim.Substring(0, 4) = ";589" Then
                    Label2.Visible = True
                    txtLast3Digits.Visible = True
                    txtLast3Digits.Select()
                    txtLast3Digits.Focus()
                ElseIf txtCardNo.Text.Trim.Substring(0, 4).ToUpper = "%B44" Then
                    Label2.Visible = False
                    txtLast3Digits.Visible = False

                    txtCardNo.SelectAll()
                    txtCardNo.Focus()

                    AddToGrid()
                Else
                    txtCardNo.Clear()
                    txtCardNo.SelectAll()
                    txtCardNo.Focus()
                End If
        End Select
    End Sub

    Private Sub txtLast3Digits_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLast3Digits.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                Try
                    If txtLast3Digits.Text.Length <> 3 Then
                        SharedFunction.ShowErrorMessage("Please enter 3 digits number")
                        txtLast3Digits.SelectAll()
                        txtLast3Digits.Focus()
                        Return
                    End If

                    AddToGrid()
                Catch ex As Exception
                    SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & String.Format("txtLast3Digits_KeyPress(): Runtime error catched {0}", ex.Message))
                End Try
        End Select
    End Sub

    Private Sub AddToGrid()
        Dim magstripe As New Magstripe(txtCardNo.Text.Trim, txtLast3Digits.Text)

        If dt.Select("CardNo='" & magstripe.Card_No & "'").Length = 0 Then
            If Not SharedFunction.CheckIfCardNoExist(magstripe.Card_No) Then
                Dim rw As DataRow = dt.NewRow
                rw(0) = magstripe.Card_No
                If magstripe.CardType = SharedFunction.CardType_OPLUS Then
                    rw(1) = String.Format("{0}/{1}", magstripe.ExpiryDate.Substring(0, 2), magstripe.ExpiryDate.Substring(2, 2))
                ElseIf magstripe.CardType = SharedFunction.CardType_VISA Then
                    rw(1) = String.Format("{0}/{1}", magstripe.ExpiryDate.Substring(2, 2), magstripe.ExpiryDate.Substring(0, 2))
                End If
                rw(2) = magstripe.Magstripe
                rw(3) = magstripe.CardType
                dt.Rows.Add(rw)
                BindGrid()
                txtLast3Digits.Clear()
                txtCardNo.Clear()
                txtCardNo.Select()
                txtCardNo.Focus()
            Else
                SharedFunction.ShowErrorMessage(magstripe.Card_No & " already exist in inventory")
            End If
        Else
            SharedFunction.ShowErrorMessage("Duplicate entry is not allowed")
            txtCardNo.SelectAll()
            txtCardNo.Focus()
        End If

        magstripe = Nothing
    End Sub

    Private Sub BindGrid()
        Try
            grid.DataSource = dt
            Try
                grid.FirstDisplayedScrollingRowIndex = grid.RowCount - 1
                grid.ClearSelection()
                grid.Rows(grid.RowCount - 1).Selected = True
            Catch ex As Exception
            End Try
            lblTotal.Text = String.Format("TOTAL: {0}", dt.DefaultView.Count.ToString)
        Catch ex As Exception
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & String.Format("BindGrid(): Runtime error catched {0}", ex.Message))
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        SharedFunction.ControlDisposition(False, Me.Cursor, False, txtCardNo, btnReset, btnSubmit)

        Dim DAL As New DAL_UBP_EcardMgr
        Try
            Dim intTotal As Integer = 0
            Dim sbBad As New System.Text.StringBuilder
            For Each rw As DataRow In dt.Rows
                'If Not DAL.AddCardInventory(rw(0).ToString.Trim, rw(1).ToString.Trim, rw(2).ToString.Trim, SharedFunction.UserID, rw(3).ToString.Trim) Then
                If Not DAL.AddCardInventory(rw(0).ToString.Trim, rw(1).ToString.Trim, rw(2).ToString.Trim, SharedFunction.UserID, rw(3).ToString.Trim) Then
                    sbBad.AppendLine(rw(0).ToString.Trim)
                    DAL.AddSystemLog(String.Format("{0} swiped card for inventory", SharedFunction.CompleteName), "CardInventory", SharedFunction.UserID)
                End If
                intTotal += 1
            Next

            SharedFunction.ShowInfoMessage("Process is complete." & vbNewLine & vbNewLine & _
                                            "TOTAL: " & intTotal.ToString & vbNewLine & _
                                            "Success: " & (intTotal - sbBad.Length).ToString & vbNewLine & _
                                            "Failed: " & sbBad.Length.ToString & vbNewLine & _
                                            sbBad.ToString)


            IsSubmitted = True

            Reset()
        Catch ex As Exception
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & String.Format("Submit(): Runtime error catched {0}", ex.Message))
            SharedFunction.ShowErrorMessage("An error occurred")
        Finally
            DAL.Dispose()
            DAL = Nothing
            SharedFunction.ControlDisposition(True, Me.Cursor, False, txtCardNo, btnReset, btnSubmit)
        End Try
    End Sub

End Class