Public Class CIR

    Private _GSISNo As String = ""
    Private _PhotoByte As Byte()

    Public Property GSISNo As String
        Get
            Return _GSISNo
        End Get
        Set(value As String)
            _GSISNo = value
        End Set
    End Property

    Public ReadOnly Property PhotoByte As Byte()
        Get
            Return _PhotoByte
        End Get
    End Property

    Private Sub CIR_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SharedFunction.ClearMainFormExistingForm()
    End Sub

    Private Sub CIR_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboField.SelectedIndex = 0

        BindBlankPhoto()

        If _GSISNo = "" Then
            txtValue.Focus()
            txtValue.Select()
        Else
            txtValue.Text = _GSISNo
            BindData()
            GroupBox1.Enabled = False
        End If

        My.Settings.MainLoaderFlag = False
        My.Settings.Save()
    End Sub

    Private Sub txtValue_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtValue.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                SharedFunction.ReportToApp()

                BindData()
        End Select
    End Sub

    Private Sub ResetForm()
        txtGSISNo.Clear()
        txtCRN.Clear()
        txtCardNo.Clear()
        txtFullname.Clear()
        txtCardname.Clear()
        txtDOB.Clear()
        txtPlaceOfBirth.Clear()
        txtMailingAddress.Clear()
        txtMFType.Clear()
        txtBank.Clear()
        txtBranchOffice.Clear()
        txtEnrolledAt.Clear()
        txtIssuedBy.Clear()
        txtPrintDate.Clear()
        BindBlankPhoto()
    End Sub

    Public Sub BindData()
        ControlDisposition(False)

        Dim _cir As New clssCIR(txtValue.Text, cboField.SelectedIndex, chkDisplayPhoto.Checked)
        If _cir.IsSuccess Then
            txtCardname.BackColor = Color.White

            txtGSISNo.Text = _cir.GSISNo
            txtCRN.Text = _cir.CRN

            If txtCRN.Text <> "" Then
                txtCRN.BackColor = SharedFunction.ErrorColor
            Else
                txtCRN.BackColor = Color.White
            End If

            txtCardNo.Text = _cir.CardNo
            txtFullname.Text = _cir.FullName
            txtCardname.Text = _cir.CardName
            txtDOB.Text = _cir.DateOfBirth
            txtPlaceOfBirth.Text = _cir.PlaceOfBirth
            txtMailingAddress.Text = _cir.MailingAddress
            If _cir.MFType.Trim = "" Then
                txtMFType.Text = _cir.MFType
            Else
                txtMFType.Text = String.Format("{0} - {1}", _cir.MFType.ToUpper, SharedFunction.CardTypeDescription(CShort(_cir.MFType)).ToUpper)
            End If

            txtBank.Text = _cir.PreferredBank

            If _cir.OfficeCode.Trim = "" Then
                txtBranchOffice.Text = _cir.HandlingBranch.ToUpper
            Else
                txtBranchOffice.Text = String.Format("{0} - {1}", _cir.HandlingBranch.ToUpper, _cir.OfficeCode.ToUpper)
            End If

            txtEnrolledAt.Text = _cir.EnrolledAt
            _PhotoByte = _cir.Photo

            If Not chkDisplayPhoto.Checked Then BindBlankPhoto() Else picPhoto.BackgroundImage = Image.FromStream(New System.IO.MemoryStream(_cir.Photo))

            Try
                Dim DAL As New DAL_UBP_EcardMgr
                Dim strWhereCriteria As String = " WHERE dbo.tblCardTxn.Card_No='" & txtCardNo.Text & "'"
                'If cboField.Text <> "GSIS NO." Then strWhereCriteria = " WHERE dbo.tblCardTxn.Card_No='" & txtValue.Text & "'"
                'If DAL.SelectQuery("SELECT dbo.tblCardTxn.DateTimePosted, dbo.fnGetUserCompleteName(dbo.tblCardTxn.UserID) As IssuedBy, dbo.tblCardType.CardType, dbo.tblTxnType.TxnTypeDesc FROM dbo.tblCardTxn INNER JOIN dbo.tblCardType ON dbo.tblCardTxn.CardTypeID = dbo.tblCardType.CardTypeID INNER JOIN dbo.tblTxnType ON dbo.tblCardTxn.TxnTypeID = dbo.tblTxnType.TxnTypeID" & strWhereCriteria) Then
                If DAL.SelectQuery("SELECT dbo.tblCardTxn.DateTimePosted, (SELECT b.UserName from tblUser b WHERE b.UserID = dbo.tblCardTxn.UserID) As IssuedBy, dbo.tblCardType.CardType, dbo.tblTxnType.TxnTypeDesc FROM dbo.tblCardTxn INNER JOIN dbo.tblCardType ON dbo.tblCardTxn.CardTypeID = dbo.tblCardType.CardTypeID INNER JOIN dbo.tblTxnType ON dbo.tblCardTxn.TxnTypeID = dbo.tblTxnType.TxnTypeID" & strWhereCriteria & " ORDER BY dbo.tblCardTxn.DateTimePosted DESC") Then
                    If DAL.TableResult.DefaultView.Count > 0 Then
                        txtIssuedBy.Text = DAL.TableResult.Rows(0)("IssuedBy").ToString.ToUpper
                        txtPrintDate.Text = CDate(DAL.TableResult.Rows(0)("DateTimePosted")).ToString("MM/dd/yyyy")
                        txtCardType.Text = DAL.TableResult.Rows(0)("CardType").ToString.Trim.ToUpper
                        txtTxnType.Text = DAL.TableResult.Rows(0)("TxnTypeDesc").ToString.Trim.ToUpper
                    Else
                        txtIssuedBy.Clear()
                        txtPrintDate.Clear()
                        txtCardType.Clear()
                        txtTxnType.Clear()
                    End If
                Else
                    SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "BindData(): Error catched " & DAL.ErrorMessage)
                End If
                DAL.Dispose()
                DAL = Nothing
            Catch ex As Exception
                SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "BindData(): Runtime error catched " & ex.Message)
            End Try
        Else
            lblStatus.Text = _cir.ErrorMessage
            lblStatus.ForeColor = SharedFunction.ErrorColor
            ResetForm()
        End If

        txtValue.Clear()
        txtValue.Select()
        txtValue.Focus()

        ControlDisposition(True)
    End Sub

    Private Sub ControlDisposition(ByVal bln As Boolean)
        SharedFunction.ControlDisposition(bln, Me.Cursor, True, _
                                          cboField, txtValue)
    End Sub

    Private Sub BindBlankPhoto()
        picPhoto.BackgroundImage = Image.FromStream(New System.IO.MemoryStream(System.IO.File.ReadAllBytes(SharedFunction.ImagesRepository & "\blank_photo.jpg")))
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        btnCancel.Visible = False
        btnModify.Text = "Modify"
    End Sub

    Private Sub btnModify_Click(sender As System.Object, e As System.EventArgs) Handles btnModify.Click
        If btnModify.Text = "Modify" Then
            txtFullname.Enabled = True
        Else
            'submit request for modification
        End If
    End Sub

    Private Sub LabelStatus(ByVal status As String, ByVal intStatus As Short)
        lblStatus.Text = status
        Select Case intStatus
            Case 0
                lblStatus.ForeColor = Color.Black
            Case 1
                lblStatus.ForeColor = SharedFunction.SuccessColor
            Case 2
                lblStatus.ForeColor = SharedFunction.ErrorColor
        End Select
        Application.DoEvents()
    End Sub

    Private Sub cboField_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboField.SelectedIndexChanged
        Try
            If cboField.Text = "GSIS NO." Then
                txtValue.MaxLength = 11
            Else
                txtValue.MaxLength = 15
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCardname_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtCardname.DoubleClick
        'txtCardname.ReadOnly = False
        'txtCardname.BackColor = Color.Bisque
    End Sub

    Private Sub txtMailingAddress_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtMailingAddress.DoubleClick
        'txtMailingAddress.ReadOnly = False
    End Sub

End Class