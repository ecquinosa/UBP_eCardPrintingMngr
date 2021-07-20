
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class RptGenerator

    Private crReportDocument As New ReportDocument

    Private Delegate Sub Action()

    Private strErrorMessage As String

    Public ReadOnly Property ReportDocument As ReportDocument
        Get
            Return crReportDocument
        End Get
    End Property

    Public ReadOnly Property ErrorMessage As String
        Get
            Return strErrorMessage
        End Get
    End Property

    'Public Function GenerateReport(ByVal Report As DataKeysEnum.Report, ByVal intFormatType As Short, ByRef outputFile As String, ByVal ParamArray params() As String) As Boolean
    Public Function GenerateReport(ByVal Report As DataKeysEnum.Report, ByVal ParamArray params() As String) As Boolean

        Try
            Dim strFilename As String = ""

            Select Case Report
                Case DataKeysEnum.Report.AvailableInventory
                    crReportDocument = New RptAvailableInventory
                    Dim i As Short = 0
                    For Each param As String In params
                        crReportDocument.SetParameterValue(i, param)
                        i += 1
                    Next
                Case DataKeysEnum.Report.CardInventory
                    crReportDocument = New RptCardInventory
                    Dim i As Short = 0
                    For Each param As String In params
                        crReportDocument.SetParameterValue(i, param)
                        i += 1
                    Next
                Case DataKeysEnum.Report.CardTxn_CIR_New
                    crReportDocument = New RptCardTxn_CIR_New
                    Dim i As Short = 0
                    For Each param As String In params
                        crReportDocument.SetParameterValue(i, param)
                        i += 1
                    Next
                Case DataKeysEnum.Report.CardTxn_CIR_Replacement
                    crReportDocument = New RptCardTxn_CIR_Replacement
                    Dim i As Short = 0
                    For Each param As String In params
                        crReportDocument.SetParameterValue(i, param)
                        i += 1
                    Next
                Case DataKeysEnum.Report.CardTxn_Mailing
                    crReportDocument = New RptCardTxn_Mailing
                    Dim i As Short = 0
                    For Each param As String In params
                        crReportDocument.SetParameterValue(i, param)
                        i += 1
                    Next
                Case DataKeysEnum.Report.CardTxn_Transmittal
                    crReportDocument = New RptCardTxn_Transmittal
                    Dim i As Short = 0
                    For Each param As String In params
                        crReportDocument.SetParameterValue(i, param)
                        i += 1
                    Next
                Case DataKeysEnum.Report.CardTxnList
                    crReportDocument = New RptCardTxnList
                    PopulateParams(params)
                Case DataKeysEnum.Report.SpoiledTxn
                    crReportDocument = New RptSpoiledCards
                    PopulateParams(params)
            End Select

            OpenReportDbase()

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message

            Return False
        Finally
            'If Not crReportDocument Is Nothing Then
            '    crReportDocument.Close()
            '    crReportDocument.Dispose()
            'End If
        End Try
    End Function

    Private Sub PopulateParams(ByVal ParamArray params() As String)
        Dim i As Short = 0
        For Each param As String In params
            crReportDocument.SetParameterValue(i, param)
            i += 1
        Next
    End Sub

    'Public Function GenerateReport(ByVal Report As DataKeysEnum.Report, ByVal intFormatType As Short, ByRef outputFile As String, ByVal ParamArray params() As String) As Boolean

    '    Try
    '        Dim strFilename As String = ""

    '        Select Case Report
    '            Case DataKeysEnum.Report.SummaryOfCreatedPrintOrderReport
    '                crReportDocument = New ReportA_CreatedPrintOrder
    '                Dim i As Short = 0
    '                For Each param As String In params
    '                    crReportDocument.SetParameterValue(i, param)
    '                    i += 1
    '                Next
    '            Case DataKeysEnum.Report.SummaryOfInitialPrintAndReprintRequest
    '                crReportDocument = New ReportC_InitialPrintAndReprintRequest
    '                Dim i As Short = 0
    '                For Each param As String In params
    '                    crReportDocument.SetParameterValue(i, param)
    '                    i += 1
    '                Next
    '            Case DataKeysEnum.Report.ElectronicReportOfDeliveredCardsPerPrintOrder
    '                crReportDocument = New ReportE_DlvrdCrdsPerPO
    '                crReportDocument.SetParameterValue(0, params)
    '            Case DataKeysEnum.Report.ElectronicReportOfGoodCards
    '                crReportDocument = New ReportG_GoodCards
    '                crReportDocument.SetParameterValue(0, params)
    '            Case DataKeysEnum.Report.ElectronicReportOfGoodCards
    '                crReportDocument = New ReportG_GoodCards
    '                crReportDocument.SetParameterValue(0, params)
    '            Case DataKeysEnum.Report.InspectionQualityControlAndYieldReport
    '                crReportDocument = New RptInspection_QC_YieldReport
    '                Dim i As Short = 0
    '                '0 = IDs, 1 = TotalQty, 2 = PurchaseOrders, 3 = DocCntr
    '                For Each param As String In params
    '                    crReportDocument.SetParameterValue(i, param)
    '                    i += 1
    '                Next

    '                strFilename = SharedFunction.GetReportNameByReportTypeID(Report) & "_" & Now.ToString("MMddyy_hhmmtt") '"-" & params(3)
    '            Case DataKeysEnum.Report.CertificateOfDeletion
    '                'crReportDocument = New RptCertiOfDeletion
    '                crReportDocument = New RptCertiOfDeletion_v2
    '                'crReportDocument.SetParameterValue(0, String.Format(" WHERE PurchaseOrder='{0}'", params(0)))
    '                crReportDocument.SetParameterValue(0, params(0))

    '                'strFilename = SharedFunction.GetReportNameByReportTypeID(Report) & "_" & params(0)
    '                'strFilename = params(0)
    '                strFilename = params(1)
    '            Case DataKeysEnum.Report.MaterialInventory
    '                crReportDocument = New RptMaterialInventory
    '            Case DataKeysEnum.Report.RejectReportDaily
    '                crReportDocument = New RptRejectReport

    '                Dim i As Short = 0
    '                '0 = IDs, 1 = ReportDate
    '                For Each param As String In params
    '                    crReportDocument.SetParameterValue(i, param)
    '                    i += 1
    '                Next
    '            Case DataKeysEnum.Report.RejectReportByPO
    '                crReportDocument = New RptRejectCertificationWholePage

    '                Dim i As Short = 0
    '                '0 = IDs, 1 = ReportDate
    '                For Each param As String In params
    '                    crReportDocument.SetParameterValue(i, param)
    '                    i += 1
    '                Next
    '            Case DataKeysEnum.Report.DeliveryReceipt_PDF
    '                'crReportDocument = New RptDR

    '                Dim i As Short = 0
    '                ''0 = PurchaseOrder, 1 = Quantity, 2 = Data
    '                'For Each param As String In params
    '                '    crReportDocument.SetParameterValue(i, param)
    '                '    i += 1
    '                'Next

    '                crReportDocument = New ReportD_DeliveryReceipt_PDF

    '                Dim strDocCntr As String = ""

    '                For Each param As String In params
    '                    strDocCntr = param
    '                    crReportDocument.SetParameterValue(i, param)
    '                    i += 1
    '                Next

    '                strFilename = params(0) & "_Qty" & strDocCntr
    '        End Select

    '        Select Case Report
    '            Case DataKeysEnum.Report.InspectionQualityControlAndYieldReport, DataKeysEnum.Report.CertificateOfDeletion, DataKeysEnum.Report.DeliveryReceipt_PDF
    '            Case Else
    '                strFilename = SharedFunction.GetReportNameByReportTypeID(Report)
    '        End Select

    '        OpenReportDbase()

    '        Select Case Report
    '            Case DataKeysEnum.Report.MaterialInventory
    '                crReportDocument.Refresh()
    '        End Select
    '        '
    '        Dim fileExt As String = "pdf"
    '        If intFormatType = 2 Then fileExt = "xls"
    '        Dim CrExportOptions As ExportOptions
    '        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
    '        Dim CrFormatTypeOptionsPDF As New PdfRtfWordFormatOptions
    '        Dim CrFormatTypeOptionsXLS As New ExcelFormatOptions

    '        Select Case Report
    '            Case DataKeysEnum.Report.CertificateOfDeletion
    '                If Not IO.Directory.Exists(String.Format("{0}\{1}", SharedFunction.ReportsRepository, params(1))) Then IO.Directory.CreateDirectory(String.Format("{0}\{1}", SharedFunction.ReportsRepository, params(1)))

    '                CrDiskFileDestinationOptions.DiskFileName = String.Format("{0}\{1}\{2}_CoD.{3}", SharedFunction.ReportsRepository, params(1), strFilename, fileExt)
    '            Case DataKeysEnum.Report.DeliveryReceipt_PDF
    '                CrDiskFileDestinationOptions.DiskFileName = String.Format("{0}\{1}.{2}", SharedFunction.ReportsDeliveryReceiptRepository, strFilename, fileExt)
    '            Case Else
    '                CrDiskFileDestinationOptions.DiskFileName = String.Format("{0}\{1}.{2}", SharedFunction.ReportsRepository, strFilename, fileExt)
    '        End Select

    '        CrExportOptions = crReportDocument.ExportOptions

    '        With CrExportOptions
    '            .ExportDestinationType = ExportDestinationType.DiskFile
    '            .DestinationOptions = CrDiskFileDestinationOptions

    '            If intFormatType = 1 Then
    '                .ExportFormatType = ExportFormatType.PortableDocFormat
    '                .FormatOptions = CrFormatTypeOptionsPDF
    '            Else
    '                .ExportFormatType = ExportFormatType.Excel
    '                .FormatOptions = CrFormatTypeOptionsXLS
    '            End If
    '        End With
    '        Try
    '            crReportDocument.Export()
    '            outputFile = CrDiskFileDestinationOptions.DiskFileName
    '        Catch ex As Exception
    '            strErrorMessage = ex.Message

    '            Return False
    '        End Try

    '        Return True
    '    Catch ex As Exception
    '        strErrorMessage = ex.Message

    '        Return False
    '    Finally
    '        If Not crReportDocument Is Nothing Then
    '            crReportDocument.Close()
    '            crReportDocument.Dispose()
    '        End If
    '    End Try
    'End Function   

    Private Sub OpenReportDbase()
        Dim strLogin As CrystalDecisions.Shared.TableLogOnInfo = Nothing
        Dim strConnectionInfo As New CrystalDecisions.Shared.ConnectionInfo

        strConnectionInfo.ServerName = My.Settings.Server_eCard
        strConnectionInfo.DatabaseName = My.Settings.Database_eCard
        strConnectionInfo.UserID = My.Settings.User_eCard
        strConnectionInfo.Password = My.Settings.Password_eCard

        For Each strTable As CrystalDecisions.CrystalReports.Engine.Table In crReportDocument.Database.Tables
            strLogin = strTable.LogOnInfo
            strLogin.ConnectionInfo = strConnectionInfo
            strTable.ApplyLogOnInfo(strLogin)
        Next

        'if report have subreport/s
        For i As Short = 0 To crReportDocument.Subreports.Count - 1
            Dim crDoc As ReportDocument = crReportDocument.OpenSubreport(crReportDocument.Subreports(i).Name)

            Dim strLogin2 As CrystalDecisions.Shared.TableLogOnInfo = Nothing
            For Each strTable2 As CrystalDecisions.CrystalReports.Engine.Table In crDoc.Database.Tables
                strLogin2 = strTable2.LogOnInfo
                strLogin2.ConnectionInfo = strConnectionInfo
                strTable2.ApplyLogOnInfo(strLogin2)
            Next
        Next
    End Sub

End Class
