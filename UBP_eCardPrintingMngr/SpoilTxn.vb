Public Class SpoilTxn

    Private params() As String
    Private ApproverUsername As String

    Public Sub New(ByVal ParamArray params() As String)

        ' This call is required by the designer.
        InitializeComponent()
        Me.params = params

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub SpoilTxn_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        SharedFunction.PopulateCBO("tblSpoiledReason", "SpoiledReasonID", "SpoiledReason", cboSpoiledReason)

        cboSpoiledReason.Select()
        cboSpoiledReason.Focus()

        txtCardNo.Text = params(0).Trim

        If params.Length > 1 Then
            txtCardTxnID.Text = params(2).Trim
            txtGSISNo.Text = params(1).Trim
        End If
    End Sub

    Private Sub cboSpoiledReason_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSpoiledReason.SelectedIndexChanged
        Try
            SharedFunction.ReportToApp()

            If CInt(cboSpoiledReason.SelectedValue) = 11 Then
                txtOtherReason.Enabled = True
                txtOtherReason.Select()
                txtOtherReason.Focus()
            Else
                txtOtherReason.Enabled = False
                txtOtherReason.Clear()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        lblStatus.Text = ""

        If CInt(cboSpoiledReason.SelectedValue) = 11 Then
            If txtOtherReason.Text = "" Then
                lblStatus.Text = "Please enter other reason"
                lblStatus.ForeColor = SharedFunction.ErrorColor
                Return
            End If
        End If

        If btnSubmit.Text = "Approve" Then
            Dim approveTxn As New ApproveTxn
            approveTxn.ShowDialog()
            If approveTxn.IsApprove Then
                ApproverUsername = approveTxn.Approver
                btnSubmit.Text = "Submit"
            End If
        Else
            Dim DAL As New DAL_UBP_EcardMgr
            Try
                If Not DAL.AddSpoiledTxn(txtCardNo.Text, IIf(txtCardTxnID.Text = "N/A", 0, txtCardTxnID.Text), SharedFunction.UserID, cboSpoiledReason.SelectedValue, txtOtherReason.Text, ApproverUsername) Then
                    lblStatus.Text = DAL.ErrorMessage
                    lblStatus.ForeColor = SharedFunction.ErrorColor
                    Return
                Else
                    DAL.AddSystemLog(String.Format("{0} spoiled card {1}. Appoved by {2}", SharedFunction.CompleteName, txtCardNo.Text, ApproverUsername), "SpoilTxn", SharedFunction.UserID)
                    SharedFunction.ShowInfoMessage("Card/ Transaction has been spoiled")
                    Close()
                End If
            Catch ex As Exception
                SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "Submit_Click(): Card#" & txtCardNo.Text & ". Runtime error catched " & ex.Message)
                SharedFunction.ShowErrorMessage("Runtime error catched. See log for description.")
            Finally
                DAL.Dispose()
                DAL = Nothing
            End Try
        End If
    End Sub
   
End Class