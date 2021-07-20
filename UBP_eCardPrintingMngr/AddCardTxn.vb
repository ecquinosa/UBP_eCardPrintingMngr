Public Class AddCardTxn

    'Private _parentForm As ListForm
    'Private _frm2 As CIR

    Dim _cir As clssCIR

    Private IsGSISNoValid As Boolean
    Private IsMagstripeValid As Boolean
    'Private IsAcctNoValid As Boolean = True

    Private GSISNo As String = ""
    Private CardMagstripe As String = ""

    Private magstripe As Magstripe
    Private CardTxnID As Integer = 0

    Private ApproverUsername As String = ""

    Private IsMailerClicked As Boolean
    Private IsCIRClicked As Boolean

    'Private _PhotoByte As Byte()

    'Public Sub New(ByRef _parentForm As ListForm)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'Me._parentForm = _parentForm
        'Me._parentForm = _parentForm

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub AddCardTxn_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'If Not _frm2 Is Nothing Then _frm2.Close()
        '_parentForm.Show()
    End Sub

    Private Sub AddCardTxn_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        SharedFunction.PopulateCBO("tblCardType", "CardTypeID", "CardType", cboCardType)
        SharedFunction.PopulateCBO("tblTxnType", "TxnTypeID", "TxnTypeDesc", cboTxnType)

        AddHandler txtGSISNo.DoubleClick, AddressOf SharedFunction.txtBox_DoubleClick
        AddHandler txtMagstripe.DoubleClick, AddressOf SharedFunction.txtBox_DoubleClick
        AddHandler txtLast3Digits.DoubleClick, AddressOf SharedFunction.txtBox_DoubleClick
        'AddHandler txtAcctNo.DoubleClick, AddressOf SharedFunction.txtBox_DoubleClick

        txtGSISNo.Select()
        txtGSISNo.Focus()
    End Sub

    Private Function IsCIR_Have_Modifications(ByVal CardName As String, ByVal Address As String) As String
        Dim sb As New System.Text.StringBuilder
        sb.Append("")
        If CardName <> txtCardname.Text Then sb.Append("Cardname is modified. ")
        'If Address <> _frm2.txtMailingAddress.Text Then sb.Append("Address is modified. ")
        Return sb.ToString
    End Function

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        SharedFunction.ReportToApp()

        If btnSubmit.Text = "Submit" Then
            If cboCardType.Text = "" Then
                SharedFunction.ShowErrorMessage("Please select card type")
                Return
            ElseIf cboTxnType.Text = "" Then
                SharedFunction.ShowErrorMessage("Please select txn type")
                Return
            End If

            Dim DAL As New DAL_UBP_EcardMgr
            'Dim _cir As New clssCIR(GSISNo, 0)
            SharedFunction.ShowLoader(pbLoader)
            Try
                If _cir.IsSuccess Then
                    Dim result As String = IsCIR_Have_Modifications(_cir.CardName, _cir.MailingAddress)

                    If result <> "" Then
                        Dim approveTxn As New ApproveTxn
                        approveTxn.ShowDialog()
                        If approveTxn.IsApprove Then
                            ApproverUsername = approveTxn.Approver
                        Else
                            SharedFunction.ShowErrorMessage("Approver did not approved txn or cancelled approval process")
                            DAL.AddSystemLog(String.Format("Card issuance of {0} for cardno#{1} did not approved or cancelled by {2}", SharedFunction.CompleteName, magstripe.Card_No, ApproverUsername), "AddCardTxn", SharedFunction.UserID)
                            LabelStatus("Approver did not approved txn or cancelled approval process", 2)
                            Return
                        End If
                    End If

                    Dim strAcctNo As String = ""
                    'If txtAcctNo.Text <> "" Then strAcctNo = txtAcctNo.Text
                    If DAL.AddCardTxn(SharedFunction.UserID, cboCardType.SelectedValue, cboTxnType.SelectedValue, GSISNo, magstripe.Card_No, _cir.FName, _cir.MName, _cir.LName, _cir.DateOfBirth, _cir.PlaceOfBirth, txtMailingAddress.Text, _cir.RetirementNo, _cir.HandlingBranch, _cir.OfficeCode, strAcctNo, ApproverUsername, result) Then
                        DAL.AddSystemLog(String.Format("{0} issued cardno#{1}", SharedFunction.CompleteName, magstripe.Card_No), "AddCardTxn", SharedFunction.UserID)

                        CardTxnID = DAL.ObjectResult

                        'If Not String.IsNullOrEmpty(DAL.ObjectResult) Then
                        If CardTxnID > 0 Then
                            SharedFunction.PrintCard(lblCardName.Text, lblGSISNo.Text, _cir.Photo, SharedFunction.CardProdType, False, chkPrintPhoto.Checked)

                            Dim DAL2 As New DAL_GSIS_Oracle
                            Try
                                If Not DAL2.Update_ENROLLEE_TA_CardNo(GSISNo, magstripe.Card_No) Then
                                    SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & String.Format("Update_ENROLLEE_TA_CardNo(): GSIS#{0}, Card#{1}. Error catched " & DAL2.ErrorMessage, GSISNo, magstripe.Card_No))
                                    LabelStatus(String.Format("Failed to update GSIS ENROLLEE_TA for GSIS#{0}, Card#{1}", GSISNo, magstripe.Card_No), 2)
                                End If
                            Catch ex As Exception
                                SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & String.Format("Update_ENROLLEE_TA_CardNo(): GSIS#{0}, Card#{1}. Runtime error catched " & ex.Message, GSISNo, magstripe.Card_No))
                                LabelStatus(String.Format("Failed to update GSIS ENROLLEE_TA for GSIS#{0}, Card#{1}", txtGSISNo.Text, magstripe.Card_No), 2)
                            Finally
                                DAL2 = Nothing
                            End Try

                            btnPrintCIR.Visible = True
                            btnPrintMailer.Visible = True
                            'btnSubmit.Text = "Preview"
                            btnSubmit.Enabled = False

                            txtGSISNo.Clear()
                            txtMagstripe.Clear()
                            txtLast3Digits.Clear()

                            'cboCardType.Items.Clear()
                            'cboTxnType.Items.Clear()
                            'cboCardType.Enabled = False
                            'cboTxnType.Enabled = False

                            LabelStatus("SUBMITTED!", 1)
                        End If
                    Else
                        SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & String.Format("AddCardTxn(DAL): GSIS#{0}, Card#{1}. Error " & DAL.ErrorMessage, txtGSISNo.Text, magstripe.Card_No))
                        LabelStatus(DAL.ErrorMessage, 2)
                    End If
                Else
                    SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & String.Format("AddCardTxn(CIR): GSIS#{0}, Card#{1}. Error " & DAL.ErrorMessage, txtGSISNo.Text, magstripe.Card_No))
                    LabelStatus(_cir.ErrorMessage, 2)
                End If
            Catch ex As Exception
                SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & String.Format("Submit(): GSIS#{0}, Card#{1}. Runtime error catched " & ex.Message, txtGSISNo.Text, magstripe.Card_No))
                LabelStatus(DAL.ErrorMessage, 2)
            Finally
                DAL.Dispose()
                DAL = Nothing
                _cir = Nothing
                SharedFunction.DisposeLoader(pbLoader)
            End Try
        Else
            SharedFunction.PrintCard(lblCardName.Text, lblGSISNo.Text, _cir.Photo, SharedFunction.CardProdType, True, chkPrintPhoto.Checked)
        End If
    End Sub

    Private Sub LabelStatus(ByVal status As String, ByVal intStatus As Short)
        lblStatus.Text = status
        Select Case intStatus
            Case 0
                lblStatus.ForeColor = Color.Gray
            Case 1
                lblStatus.ForeColor = SharedFunction.SuccessColor
            Case 2
                lblStatus.ForeColor = SharedFunction.ErrorColor
        End Select
    End Sub

    Private Sub txtGSISNo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtGSISNo.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                SharedFunction.ReportToApp()

                Dim IsValid As Boolean = True
                If cboCardType.Text = "-Select Item-" Then
                    IsValid = False
                ElseIf cboCardType.Text = "" Then
                    IsValid = False
                ElseIf cboTxnType.Text = "-Select Item-" Then
                    IsValid = False
                ElseIf cboTxnType.Text = "" Then
                    IsValid = False
                End If

                If Not IsValid Then
                    SharedFunction.ShowErrorMessage("Please select item in Card Type or Txn Type")
                    Return
                End If

                If txtGSISNo.TextLength <> 11 Then
                    SharedFunction.ShowErrorMessage("Please enter valid 11 characters GSIS#")
                    Return
                End If

                BindData()

                lblCardName.Text = txtCardname.Text
                lblGSISNo.Text = txtGSISNo.Text

                If txtGSISNo.Text <> "" Then
                    IsGSISNoValid = True
                    GSISNo = txtGSISNo_CIR.Text
                End If

                If IsGSISNoValid And IsMagstripeValid Then
                    SubmitAndPrintButtons(True)
                End If

                'txtGSISNo.Clear()
                txtMagstripe.Select()
                txtMagstripe.Focus()

                SharedFunction.DisposeLoader(pbLoader)
        End Select
    End Sub

    Private AcctNoKeyPressedTwice As Short

    Private Sub txtMagstripe_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMagstripe.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                SharedFunction.ReportToApp()

                Dim IsValid As Boolean = False
                If txtMagstripe.Text.Contains("=") Then IsValid = True
                If txtMagstripe.Text.Contains("^") Then IsValid = True

                'txtAcctNo.Clear()

                If Not IsValid Then
                    SharedFunction.ShowErrorMessage("Please swipe valid OPLUS or VISA card")
                    txtMagstripe.SelectAll()
                    txtMagstripe.Focus()
                    Return
                End If

                'AcctNoKeyPressedTwice = 0

                If txtMagstripe.Text.Trim.Substring(0, 4) = ";589" Then
                    SharedFunction.CardProdType = SharedFunction.CardType_OPLUS
                    txtLast3Digits.Visible = True
                    txtLast3Digits.Select()
                    txtLast3Digits.Focus()
                ElseIf txtMagstripe.Text.Trim.Substring(0, 4).ToUpper = "%B44" Then
                    SharedFunction.CardProdType = SharedFunction.CardType_VISA
                    txtLast3Digits.Visible = False

                    ProcessCard()

                    'AcctNoControls()

                    'txtAcctNo.Select()
                    'txtAcctNo.Focus()

                    'If txtAcctNo.Text = "" Then Return
                    'If txtAcctNo.Text.Trim.Substring(0, 5) = ";4404" Then txtAcctNo.Clear()
                    ''    End If

                    'If txtAcctNo.Text <> "" Then

                    '    txtAcctNo.Select()
                    '    txtAcctNo.Focus()
                    'Else
                    '    If txtAcctNo.Text = "" Then Return
                    '    If txtAcctNo.Text.Trim.Substring(0, 4) = ";4404" Then
                    '        txtAcctNo.Clear()
                    '    End If
                    'End If
                    'Else
                    '    If txtAcctNo.Text = "" Then Return
                    '    If txtAcctNo.Text.Trim.Substring(0, 5) = ";4404" Then
                    '        txtAcctNo.Clear()
                    '    End If
                End If
        End Select
    End Sub

    'Private Sub txtAcctNo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
    '    Select Case e.KeyChar
    '        Case Microsoft.VisualBasic.ChrW(Keys.Return)
    '            If txtAcctNo.Text = "" Then Return

    '            If txtAcctNo.Text.Trim.Substring(0, 5) = ";4404" Then
    '                txtAcctNo.Clear()
    '            Else
    '                If txtAcctNo.TextLength <> 12 Then
    '                    SharedFunction.ShowErrorMessage("Please enter valid 12 characters acct#")
    '                    Return
    '                End If

    '                IsAcctNoValid = True
    '                ProcessCard()
    '            End If
    '    End Select
    'End Sub

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

                    ProcessCard()
                Catch ex As Exception
                    SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & String.Format("txtLast3Digits_KeyPress(): Runtime error catched {0}", ex.Message))
                End Try
        End Select
    End Sub

    Private Sub ProcessCard()
        SharedFunction.ShowLoader(pbLoader)

        LabelStatus("", 0)

        Dim DAL As New DAL_UBP_EcardMgr
        CardMagstripe = txtMagstripe.Text
        If Not magstripe Is Nothing Then magstripe = Nothing
        magstripe = New Magstripe(CardMagstripe, txtLast3Digits.Text)
        If DAL.SelectCard_NoData(magstripe.Card_No) Then
            If DAL.TableResult.DefaultView.Count > 0 Then
                Dim rw As DataRow = DAL.TableResult.Rows(0)
                If CBool(rw("IsSpoiled")) Then
                    LabelStatus("Card is tagged as spoiled on " & rw("DateTimePosted").ToString.Trim, 2)
                    txtMagstripe.SelectAll()
                    txtMagstripe.Focus()
                Else
                    'If CBool(rw("CardIsSpoiled")) Then
                    '    LabelStatus("Txn is tagged as spoiled on " & rw("DateTimePosted").ToString.Trim, 2)
                    '    txtMagstripe.SelectAll()
                    '    txtMagstripe.Focus()
                    'Else
                    If rw("GSIS_No").ToString.Trim = "" Then
                        IsMagstripeValid = True
                        If IsGSISNoValid And IsMagstripeValid Then
                            SubmitAndPrintButtons(True)

                            lblGSISNo.Text = txtGSISNo_CIR.Text

                            If SharedFunction.CardProdType = SharedFunction.CardType_VISA Then
                                Select Case CShort(cboCardType.SelectedValue)
                                    Case DataKeysEnum.CardTypeID.Renewal, DataKeysEnum.CardTypeID.Replacement
                                        'lblGSISNo.Text = String.Format("{0} \ {1}", txtAcctNo.Text, _frm2.txtGSISNo.Text)
                                        lblGSISNo.Text = txtGSISNo_CIR.Text
                                    Case Else
                                        lblGSISNo.Text = String.Format("                         \ {0}", txtGSISNo_CIR.Text)
                                End Select
                            ElseIf SharedFunction.CardProdType = SharedFunction.CardType_OPLUS Then
                                lblGSISNo.Text = txtGSISNo_CIR.Text
                            End If
                        End If
                    Else
                        LabelStatus(String.Format("Card is already assigned to {0}-{1}", rw("GSIS_No").ToString.Trim, SharedFunction.CompleteName(rw("FName").ToString.Trim, rw("MName").ToString.Trim, rw("LName").ToString.Trim)), 2)
                        txtMagstripe.SelectAll()
                        txtMagstripe.Focus()
                    End If
                End If
                'End If
            Else
                LabelStatus("Card does not exist in card inventory", 2)
                txtMagstripe.SelectAll()
                txtMagstripe.Focus()
            End If
        Else
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "ProcessCard(): " & DAL.ErrorMessage)
            LabelStatus(DAL.ErrorMessage, 2)
            txtMagstripe.SelectAll()
            txtMagstripe.Focus()
        End If

        SharedFunction.DisposeLoader(pbLoader)
    End Sub

    Private Sub SubmitAndPrintButtons(ByVal bln As Boolean)
        btnSubmit.Enabled = bln
    End Sub

    'Private Sub AcctNoControls()
    '    Try
    '        Dim bln As Boolean
    '        If SharedFunction.CardProdType = SharedFunction.CardType_OPLUS Then bln = False
    '        If SharedFunction.CardProdType = SharedFunction.CardType_VISA Then bln = True

    '        Select Case CShort(cboCardType.SelectedValue)
    '            Case DataKeysEnum.CardTypeID.Renewal, DataKeysEnum.CardTypeID.Replacement
    '            Case Else
    '                bln = False
    '        End Select

    '        Label6.Visible = bln
    '        txtAcctNo.Visible = bln
    '        txtAcctNo.ReadOnly = Not bln
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub EnableTextboxes(ByVal bln As Boolean)
        txtGSISNo.ReadOnly = Not bln
        txtMagstripe.ReadOnly = Not bln
    End Sub

    Private Sub btnPrintMailer_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintMailer.Click
        IsMailerClicked = True
        SharedFunction.ShowForm(New ReportViewer(DataKeysEnum.Report.CardTxn_Mailing, False, CardTxnID))

        If IsCIRClicked Then ResetForm()
        If IsMailerClicked Then ResetForm()
    End Sub

    Private Sub btnPrintCIR_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintCIR.Click
        IsCIRClicked = True
        SharedFunction.ShowForm(New ReportViewer(DataKeysEnum.Report.CardTxn_CIR_New, False, CardTxnID))

        If IsCIRClicked Then ResetForm()
        If IsMailerClicked Then ResetForm()
    End Sub

    'Private Sub cboCardType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCardType.SelectedIndexChanged
    '    Try
    '        Select Case cboCardType.Text.Trim.ToUpper
    '            Case "RENEWAL", "REPLACEMENT"
    '                If IsMagstripeValid Then
    '                    AcctNoControls()
    '                    txtAcctNo.SelectAll()
    '                    txtAcctNo.Focus()
    '                End If
    '            Case Else
    '                Label6.Visible = False
    '                txtAcctNo.Visible = False
    '                txtAcctNo.ReadOnly = True
    '        End Select
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub IfCardNameIsModified()
        lblCardName.Text = txtCardname.Text.ToUpper
    End Sub

    Private Sub ResetForm()
        _cir = Nothing

        IsCIRClicked = False
        IsMailerClicked = False

        IsGSISNoValid = False
        IsMagstripeValid = False
        'IsAcctNoValid = True

        GSISNo = ""
        CardMagstripe = ""

        magstripe = Nothing
        CardTxnID = 0

        ApproverUsername = ""

        txtGSISNo.Clear()
        txtMagstripe.Clear()
        txtLast3Digits.Clear()

        txtGSISNo_CIR.Clear()
        txtCRN.Clear()
        txtCardNo.Clear()
        txtFullname.Clear()
        txtCardname.Clear()
        txtDOB.Clear()
        txtPlaceOfBirth.Clear()
        txtMailingAddress.Clear()
        txtBank.Clear()
        txtBranchOffice.Clear()
        txtEnrolledAt.Clear()
        txtIssuedBy.Clear()
        txtPrintDate.Clear()
        lblCardName.Text = "<< CARD NAME >>"
        lblGSISNo.Text = "<< GSIS NO >>"
        BindBlankPhoto()

        btnSubmit.Text = "Submit"
        btnSubmit.Enabled = True
        btnPrintCIR.Visible = False
        btnPrintMailer.Visible = False
    End Sub

    Public Sub BindData()
        ControlDisposition(False)

        'Dim _cir As New clssCIR("GSISNo", txtGSISNo.Text, True)
        _cir = New clssCIR(txtGSISNo.Text, 0, True)
        If _cir.IsSuccess Then
            txtCardname.BackColor = Color.White

            txtGSISNo_CIR.Text = _cir.GSISNo
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

            txtBank.Text = _cir.PreferredBank

            If _cir.OfficeCode.Trim = "" Then
                txtBranchOffice.Text = _cir.HandlingBranch.ToUpper
            Else
                txtBranchOffice.Text = String.Format("{0} - {1}", _cir.HandlingBranch.ToUpper, _cir.OfficeCode.ToUpper)
            End If

            txtEnrolledAt.Text = _cir.EnrolledAt
            '_PhotoByte = _cir.Photo

            picPhoto.BackgroundImage = Image.FromStream(New System.IO.MemoryStream(_cir.Photo))

            Try
                Dim DAL As New DAL_UBP_EcardMgr
                Dim strWhereCriteria As String = " WHERE dbo.tblCardTxn.Card_No='" & txtCardNo.Text & "'"
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

        ControlDisposition(True)
    End Sub

    Private Sub ControlDisposition(ByVal bln As Boolean)
        'SharedFunction.ControlDisposition(bln, Me.Cursor, True, cboField, txtValue)
    End Sub

    Private Sub BindBlankPhoto()
        picPhoto.BackgroundImage = Image.FromStream(New System.IO.MemoryStream(System.IO.File.ReadAllBytes(SharedFunction.ImagesRepository & "\blank_photo.jpg")))
    End Sub

    Private Sub txtCardname_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtCardname.DoubleClick
        'txtCardname.ReadOnly = False
        'txtCardname.BackColor = Color.Bisque
    End Sub

    Private Sub txtCardname_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCardname.TextChanged
        IfCardNameIsModified()
    End Sub

    Private Sub txtMailingAddress_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtMailingAddress.DoubleClick
        'txtMailingAddress.ReadOnly = False
        'txtMailingAddress.BackColor = Color.Bisque
    End Sub

End Class