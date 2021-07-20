Public Class SearchData

    Private _tableName As DataKeysEnum.TableName

    Public Sub New(ByVal TableName As DataKeysEnum.TableName)

        ' This call is required by the designer.
        InitializeComponent()
        _tableName = TableName

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private _IsSearchData As Boolean
    Private _WhereCriteria As String

    Public ReadOnly Property WhereCriteria As String
        Get
            Return _WhereCriteria
        End Get
    End Property

    Public ReadOnly Property IsSearchData As Boolean
        Get
            Return _IsSearchData
        End Get
    End Property

    Private Sub SearchData_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboField.SelectedIndex = 0
        cboDelimiter.SelectedIndex = 0
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        SharedFunction.ReportToApp()

        If dtpFrom.Value.Date > dtpTo.Value.Date Then
            SharedFunction.ShowErrorMessage("Please recheck date(s)")
            Return
        End If

        Dim sb As New System.Text.StringBuilder

        Select Case _tableName
            Case DataKeysEnum.TableName.CardTxn
                sb.Append(String.Format(" WHERE CAST(dbo.tblCardTxn.DateTimePosted as date) BETWEEN '{0}' AND '{1}'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpTo.Value.ToString("MM/dd/yyyy")))
                If txtValue.Text <> "" Then
                    If cboField.SelectedIndex = 0 Then
                        sb.Append(String.Format(" AND dbo.tblCardTxn.GSIS_No IN ({0})", GetValues()))
                    Else
                        sb.Append(String.Format(" AND dbo.tblCardTxn.Card_No IN ({0})", GetValues()))
                    End If
                End If
            Case DataKeysEnum.TableName.Inventory
                sb.Append(String.Format(" WHERE CAST(dbo.tblCardInventory.DateTimePosted as date) BETWEEN '{0}' AND '{1}'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpTo.Value.ToString("MM/dd/yyyy")))
                If txtValue.Text <> "" Then
                    If cboField.SelectedIndex = 0 Then
                        sb.Append(String.Format(" AND dbo.tblCardTxn.GSIS_No IN ({0})", GetValues()))
                    Else
                        sb.Append(String.Format(" AND dbo.tblCardInventory.Card_No IN ({0})", GetValues()))
                    End If
                End If
            Case DataKeysEnum.TableName.Spoiled
                sb.Append(String.Format(" WHERE CAST(dbo.tblSpoiledTxn.DateTimePosted as date) BETWEEN '{0}' AND '{1}'", dtpFrom.Value.ToString("MM/dd/yyyy"), dtpTo.Value.ToString("MM/dd/yyyy")))
                If txtValue.Text <> "" Then
                    If cboField.SelectedIndex = 0 Then
                        sb.Append(String.Format(" dbo.tblCardTxn.GSIS_No IN ({0})", GetValues()))
                    Else
                        sb.Append(String.Format(" dbo.tblSpoiledTxn.Card_No IN ({0})", GetValues()))
                    End If
                End If
        End Select

        _IsSearchData = True
        _WhereCriteria = sb.ToString

        Close()
    End Sub

    Private Function GetValues() As String
        Dim sb As New System.Text.StringBuilder
        If cboDelimiter.SelectedIndex = 0 Then
            sb.Append(txtValue.Text.Trim)
        Else
            For Each value As String In txtValue.Text.Split(GetDelimiter)
                If sb.ToString = "" Then
                    sb.Append("'" & value.Trim & "'")
                Else
                    sb.Append(",'" & value.Trim & "'")
                End If
            Next
        End If

        Return sb.ToString
    End Function

    Private Function GetDelimiter() As String
        Select cboDelimiter.Text
            Case "None"
                Return ""
            Case "Space ()"
                Return " "
            Case "Comma (,)"
                Return ","
            Case "Colon (:)"
                Return ":"
            Case "Semi-colon (;)"
                Return ";"
            Case "Pipe (|)"
                Return "|"
            Case Else
                Return cboDelimiter.Text
        End Select
    End Function

    Private Sub txtValue_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtValue.TextChanged
        SharedFunction.ReportToApp()
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFrom.ValueChanged
        SharedFunction.ReportToApp()
    End Sub

End Class