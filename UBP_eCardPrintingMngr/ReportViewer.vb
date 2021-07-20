Public Class ReportViewer

    Private reportType As DataKeysEnum.Report
    Private IsManualView As Boolean
    Private CardTxnID As Integer

    Public Sub New(ByVal reportType As DataKeysEnum.Report, Optional IsManualView As Boolean = True, Optional CardTxnID As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()
        Me.reportType = reportType
        Me.IsManualView = IsManualView
        Me.CardTxnID = CardTxnID

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ReportViewer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Not IsManualView Then
            crv.Location = New Point(crv.Location.X, 12)
            crv.Height = 518
            GenerateReport()
        Else
            SharedFunction.PopulateCBO("tblCardType", "CardTypeID", "CardType", cboCardType)
            SharedFunction.PopulateCBO("tblTxnType", "TxnTypeID", "TxnTypeDesc", cboTxnType)
        End If

        Select Case reportType
            Case DataKeysEnum.Report.CardTxn_Transmittal ', DataKeysEnum.Report.MF_Report
                dtpTo.Enabled = False

                'If reportType = DataKeysEnum.Report.MF_Report Then Me.Height = 221
            Case DataKeysEnum.Report.MF_Report
                'dtpTo.Enabled = False
                Me.Height = 221
        End Select

        My.Settings.MainLoaderFlag = False
        My.Settings.Save()
    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        If dtpFrom.Value > dtpTo.Value Then
            lblStatus.Text = "Please recheck date(s)"
            lblStatus.ForeColor = SharedFunction.ErrorColor
            Return
        End If

        SharedFunction.ShowLoader(pbLoader)
        SharedFunction.ControlDisposition(False, Me.Cursor, False, btnSubmit)
        GenerateReport()
        SharedFunction.ControlDisposition(True, Me.Cursor, False, btnSubmit)
        SharedFunction.DisposeLoader(pbLoader)
    End Sub

    Private Function AdditionalWhereCriteria(ByVal strWhereCriteria As String) As String
        Dim sb As New System.Text.StringBuilder
        sb.Append(strWhereCriteria)

        If IsManualView Then
            If cboCardType.SelectedIndex > 0 Then sb.Append(IIf(sb.ToString = "", " WHERE ", " AND ") & " dbo.tblCardTxn.CardTypeID=" & cboCardType.SelectedValue)
            If cboTxnType.SelectedIndex > 0 Then sb.Append(IIf(sb.ToString = "", " WHERE ", " AND ") & " dbo.tblCardTxn.TxnTypeID=" & cboTxnType.SelectedValue)
            If txtGSISNo.Text <> "" Then sb.Append(IIf(sb.ToString = "", " WHERE ", " AND ") & " dbo.tblCardTxn.GSIS_No IN ('" & txtGSISNo.Text.Replace(",", "','") & "')")
        End If

        Return sb.ToString
    End Function

    Private Sub GenerateReport()
        SharedFunction.ReportToApp()

        Dim _rpt As New RptGenerator
        Select Case reportType
            Case DataKeysEnum.Report.AvailableInventory
                'String.Format(" WHERE dbo.tblCardTxn.DateTimePosted IS NULL AND CAST(dbo.tblCardInventory.DateTimePosted as date) BETWEEN '{0}' AND '{1}'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpFrom.Value.ToString("MM/dd/yyyy")) _
                If _rpt.GenerateReport(reportType,
                                       String.Format("{0} to {1}", dtpFrom.Value.ToString("MMM dd, yyyy"), dtpTo.Value.ToString("MMM dd, yyyy")),
                                       String.Format(" WHERE dbo.tblCardTxn.DateTimePosted IS NULL AND dbo.tblCardInventory.DateTimePosted BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", "12/12/2010", dtpFrom.Value.ToString("MM/dd/yyyy"))
                                       ) Then
                    crv.ReportSource = _rpt.ReportDocument

                    'String.Format(" WHERE dbo.tblCardTxn.DateTimePosted IS NULL AND dbo.tblCardInventory.DateTimePosted BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpFrom.Value.ToString("MM/dd/yyyy"))
                End If
            Case DataKeysEnum.Report.CardInventory
                Dim dt As DataTable
                Dim SummaryVariables As String

                Dim DAL As New DAL_UBP_EcardMgr
                'If DAL.SelectCardTxnTotalByCardType(String.Format(" WHERE CAST(dbo.tblCardTxn.DateTimePosted as date) BETWEEN '{0}' AND '{1}'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpFrom.Value.ToString("MM/dd/yyyy"))) Then
                'If DAL.SelectCardTxnTotalByCardType(String.Format(" WHERE dbo.tblCardTxn.DateTimePosted BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpFrom.Value.ToString("MM/dd/yyyy"))) Then
                If DAL.SelectCardTxnTotalByCardType(String.Format(" WHERE dbo.tblCardTxn.DateTimePosted BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", "12/12/2010", dtpFrom.Value.ToString("MM/dd/yyyy"))) Then
                    dt = DAL.TableResult

                    Dim Renewal As Integer = dt.Select("CardTypeID=" & CShort(DataKeysEnum.CardTypeID.Renewal)).Length
                    Dim Active As Integer = dt.Select("CardTypeID=" & CShort(DataKeysEnum.CardTypeID.Active)).Length
                    Dim Employee As Integer = dt.Select("CardTypeID=" & CShort(DataKeysEnum.CardTypeID.Employee)).Length
                    Dim Pensioner As Integer = dt.Select("CardTypeID=" & CShort(DataKeysEnum.CardTypeID.Pensioner)).Length
                    Dim Survivor As Integer = dt.Select("CardTypeID=" & CShort(DataKeysEnum.CardTypeID.Survivor)).Length
                    Dim Replacement As Integer = dt.Select("CardTypeID=" & CShort(DataKeysEnum.CardTypeID.Replacement)).Length

                    Dim CardsIssued As Integer = dt.Select("IsSpoiled=False").Length '(RenewalReplacement + ActiveNew + Employee + Pensioner + Survivor)
                    Dim CardsSpoiled As Integer = 0 'dt.Select("IsSpoiled=True").Length
                    Dim CardsInventory As Integer = 0

                    'If DAL.GetTotalCardInventoried(String.Format(" WHERE IsSpoiled=0 AND CAST(dbo.tblCardInventory.DateTimePosted as date) BETWEEN '{0}' AND '{1}'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpFrom.Value.ToString("MM/dd/yyyy"))) Then
                    If DAL.GetTotalCardInventoried(String.Format(" WHERE IsSpoiled=0 AND dbo.tblCardInventory.DateTimePosted BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpFrom.Value.ToString("MM/dd/yyyy"))) Then
                        CardsInventory = DAL.ObjectResult
                    End If

                    Dim CardsUnused As Integer = CardsInventory - CardsIssued - CardsSpoiled

                    SummaryVariables = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                                                     Renewal.ToString("N0"),
                                                     Active.ToString("N0"),
                                                     Employee.ToString("N0"),
                                                     Pensioner.ToString("N0"),
                                                     Survivor.ToString("N0"),
                                                     CardsIssued.ToString("N0"),
                                                     CardsSpoiled.ToString("N0"),
                                                     CardsUnused.ToString("N0"),
                                                     CardsInventory.ToString("N0"))
                End If
                DAL.Dispose()
                DAL = Nothing

                'String.Format(" AND CAST(dbo.tblCardTxn.DateTimePosted as date) BETWEEN '{0}' AND '{1}'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpFrom.Value.ToString("MM/dd/yyyy")), _
                If _rpt.GenerateReport(reportType,
                                       String.Format(" AND dbo.tblCardTxn.DateTimePosted BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpFrom.Value.ToString("MM/dd/yyyy")),
                                       SummaryVariables,
                                       String.Format("{0} to {1}", dtpFrom.Value.ToString("MMM dd, yyyy"), dtpTo.Value.ToString("MMM dd, yyyy"))
                                       ) Then
                    crv.ReportSource = _rpt.ReportDocument
                End If
            Case DataKeysEnum.Report.CardTxn_CIR_New, DataKeysEnum.Report.CardTxn_CIR_Replacement, DataKeysEnum.Report.CardTxn_Mailing
                Dim Name As String = ""
                Dim Address As String = ""
                Dim DateOfBirth As String = ""
                Dim PlaceOfBirth As String = ""
                Dim TelephoneNo As String = ""
                Dim MobileNo As String = ""
                Dim GSIS_No As String = ""
                Dim MotherName As String = ""
                Dim EmailAddress As String = ""
                Dim Card_No As String = ""
                Dim BranchAndOffice As String = ""
                Dim IsSpoiled As Boolean
                Dim CardTypeID As Integer

                Dim DAL As New DAL_UBP_EcardMgr
                If DAL.SelectRptCIR(CardTxnID) Then
                    Dim rw As DataRow = DAL.TableResult.Rows(0)
                    CardTypeID = rw("CardTypeID")
                    Name = SharedFunction.CompleteName2(rw("FName").ToString.Trim, rw("MName").ToString.Trim, rw("LName").ToString.Trim)
                    Address = rw("Address").ToString.Trim
                    DateOfBirth = rw("DateOfBirth").ToString.Trim
                    PlaceOfBirth = rw("PlaceOfBirth").ToString.Trim
                    GSIS_No = rw("GSIS_No").ToString.Trim
                    Card_No = rw("Card_No").ToString.Trim
                    BranchAndOffice = String.Format("{0}-{1}", rw("GSIS_HandlingBranch").ToString.Trim, rw("GSIS_OfficeCode").ToString.Trim)
                    IsSpoiled = CBool(rw("IsSpoiled"))
                End If
                DAL.Dispose()
                DAL = Nothing

                If reportType <> DataKeysEnum.Report.CardTxn_Mailing Then
                    Select Case CardTypeID
                        Case DataKeysEnum.CardTypeID.Renewal, DataKeysEnum.CardTypeID.Replacement
                            reportType = DataKeysEnum.Report.CardTxn_CIR_Replacement
                    End Select
                End If

                If _rpt.GenerateReport(reportType, _
                                       Name, Address, DateOfBirth, PlaceOfBirth, TelephoneNo, MobileNo, GSIS_No, MotherName, EmailAddress, Card_No, BranchAndOffice, IsSpoiled) Then
                    crv.ReportSource = _rpt.ReportDocument
                End If
            Case DataKeysEnum.Report.CardTxn_Transmittal
                'String.Format(" WHERE IsSpoiled=0 AND CAST(dbo.tblCardTxn.DateTimePosted as date) BETWEEN '{0}' AND '{1}'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpFrom.Value.ToString("MM/dd/yyyy"))), _
                If _rpt.GenerateReport(reportType,
                                       AdditionalWhereCriteria(
                                       String.Format(" WHERE IsSpoiled=0 AND dbo.tblCardTxn.DateTimePosted BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", "11/29/2016", dtpFrom.Value.ToString("MM/dd/yyyy"))),
                                       dtpFrom.Value
                                       ) Then
                    crv.ReportSource = _rpt.ReportDocument

                    'String.Format(" WHERE IsSpoiled=0 AND dbo.tblCardTxn.DateTimePosted BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpFrom.Value.ToString("MM/dd/yyyy"))),
                End If
            Case DataKeysEnum.Report.CardTxnList
                'String.Format(" WHERE CAST(dbo.tblCardTxn.DateTimePosted as date) BETWEEN '{0}' AND '{1}'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpTo.Value.ToString("MM/dd/yyyy")) _
                If _rpt.GenerateReport(reportType,
                                       AdditionalWhereCriteria(
                                       String.Format(" WHERE dbo.tblCardTxn.DateTimePosted BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpTo.Value.ToString("MM/dd/yyyy"))
                                       ),
                                       String.Format("{0} to {1}", dtpFrom.Value.ToString("MMM dd, yyyy"), dtpTo.Value.ToString("MMM dd, yyyy"))) Then
                    crv.ReportSource = _rpt.ReportDocument
                End If
            Case DataKeysEnum.Report.SpoiledTxn
                'String.Format(" WHERE CAST(dbo.tblCardTxn.DateTimePosted as date) BETWEEN '{0}' AND '{1}'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpTo.Value.ToString("MM/dd/yyyy")) _
                If _rpt.GenerateReport(reportType,
                                       AdditionalWhereCriteria(
                                       String.Format(" WHERE dbo.tblSpoiledTxn.DateTimePosted BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpTo.Value.ToString("MM/dd/yyyy"))
                                       ),
                                       String.Format("{0} to {1}", dtpFrom.Value.ToString("MMM dd, yyyy"), dtpTo.Value.ToString("MMM dd, yyyy"))) Then
                    crv.ReportSource = _rpt.ReportDocument
                End If
            Case DataKeysEnum.Report.MF_Report
                Dim sbLine As New System.Text.StringBuilder
                Dim intSuccess As Integer = 0
                Dim intFailed As Integer = 0
                Dim intTotal As Integer = 0
                Dim DAL As New DAL_UBP_EcardMgr
                Dim DAL2 As New DAL_GSIS_Oracle
                Dim dt As DataTable

                Dim bln As Boolean
                Dim intCardTypeID As Integer = 0
                If cboCardType.SelectedIndex > 0 Then intCardTypeID = cboCardType.SelectedValue

                If txtGSISNo.Text = "" Then
                    bln = DAL.SelectCardTxn_MF_Report_ByDate(dtpFrom.Value, dtpTo.Value, intCardTypeID)
                Else
                    bln = DAL.SelectCardTxn_MF_Report_ByGSISNo(txtGSISNo.Text)
                End If
                
                If bln Then
                    For Each rw As DataRow In DAL.TableResult.Rows
                        Dim sb As New System.Text.StringBuilder
                        If DAL2.Generate_MF_Report("WHERE ECARD_DB.ENROLLEE_TA.ECARD_PLUS_NO='" & rw("Card_No").ToString.Trim & "'") Then
                            'SharedFunction.ShowInfoMessage("Generate_MF_Report(): " & DAL2.TableResult.DefaultView.Count.ToString & " CardNo " & rw("Card_No").ToString.Trim)
                            If DAL2.TableResult.DefaultView.Count > 0 Then
                                Dim rw2 As DataRow = DAL2.TableResult.Rows(0)
                                For i As Short = 0 To DAL2.TableResult.Columns.Count - 1
                                    Select Case i
                                        Case 0
                                            sb.Append("P" & rw2(i).ToString.Trim.ToUpper)
                                        Case 7
                                            Dim dtmBirthDate As String = ""
                                            If Not IsDBNull(rw2(i)) Then _
                                                If rw2(i).ToString.Trim <> "" Then dtmBirthDate = CDate(rw2(i)).ToString("yyyyMMdd")

                                            sb.Append("^" & dtmBirthDate)
                                        Case 29
                                            Try
                                                Dim dtmRetirementDate As String = ""
                                                If Not IsDBNull(rw2(i)) Then _
                                                    If rw2(i).ToString.Trim <> "" Then dtmRetirementDate = CDate(rw2(i)).ToString("yyyyMMdd")

                                                sb.Append("^" & dtmRetirementDate)
                                            Catch ex As Exception
                                            End Try
                                        Case 34
                                            sb.Append("^" & IIf(rw("CardType").ToString.Trim.ToUpper = "REPLACEMENT", rw("CardType").ToString.Trim.ToUpper, "NEW"))
                                        Case 37
                                        Case Else
                                            If IsDBNull(rw2(i)) Then
                                                sb.Append("^")
                                            Else
                                                sb.Append("^" & rw2(i).ToString.Trim.ToUpper)
                                            End If
                                    End Select
                                Next
                                intSuccess += 1

                                sb.Append(vbNewLine)
                                sbLine.Append(sb.ToString)
                            Else
                                intFailed += 1
                                DAL.AddSystemLog("Generate_MF_Report(): Unable to find CardNo " & rw("Card_No").ToString.Trim, "ReportViewer", SharedFunction.UserID)
                                SharedFunction.ShowErrorMessage("Unable to find CardNo " & rw("Card_No").ToString.Trim)
                            End If
                        Else
                            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "Generate_MF_Report(): CardNo " & rw("Card_No").ToString.Trim & " Error catched " & DAL2.ErrorMessage)
                            SharedFunction.ShowErrorMessage("MF report generation failed for CardNo " & rw("Card_No").ToString.Trim)
                        End If
                        intTotal += 1
                    Next
                Else
                    SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "Generate_MF_Report():" & DAL.ErrorMessage)
                End If
                DAL.Dispose()
                DAL = Nothing
                DAL2 = Nothing

                If intSuccess > 0 Then
                    sbLine.Append(intSuccess.ToString)

                    Dim strFile As String = ""
                    Dim sfd As New SaveFileDialog
                    If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                        strFile = sfd.FileName.Replace(".TXT", "").Replace(".txt", "") & ".txt"

                        If cboCardType.Text = "" Then
                            'strFile = sfd.FileName.Replace(".TXT", "").Replace(".txt", "") & ".txt"
                        ElseIf cboCardType.Text = "-Select Item-" Then
                            'strFile = sfd.FileName.Replace(".TXT", "").Replace(".txt", "") & ".txt"
                        Else
                            strFile = strFile.Replace(".txt", "_" & cboCardType.Text.ToUpper.Trim & ".txt")
                        End If

                        IO.File.WriteAllText(strFile, sbLine.ToString)
                    End If
                    sfd.Dispose()
                    sfd = Nothing

                    SharedFunction.ShowInfoMessage(String.Format("Done. File is saved in {0}" & vbNewLine & vbNewLine & "Success: " & intSuccess.ToString & "   Failed: " & intFailed.ToString & "   Total: " & intTotal.ToString, strFile))
                Else
                    SharedFunction.ShowInfoMessage(String.Format("Done. Success: " & intSuccess.ToString & "   Failed: " & intFailed.ToString & "   Total: " & intTotal.ToString))
                End If
        End Select
    End Sub

    Private Sub cboCardType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCardType.SelectedIndexChanged
        'SharedFunction.ShowInfoMessage(cboCardType.Text)
    End Sub

End Class