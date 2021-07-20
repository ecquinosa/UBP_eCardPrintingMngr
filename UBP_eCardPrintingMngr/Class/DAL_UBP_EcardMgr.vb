
Imports System.Data.SqlClient

Public Class DAL_UBP_EcardMgr
    Implements IDisposable

    Public Shared ConStr As String = "Server=" & My.Settings.Server_eCard & ";Database=" & My.Settings.Database_eCard & ";User=" & My.Settings.User_eCard & ";Password=" & My.Settings.Password_eCard & ";"

    Private dtResult As DataTable
    Private dsResult As DataSet
    Private objResult As Object
    Private _readerResult As IDataReader
    Private strErrorMessage As String

    Private con As SqlConnection
    Private cmd As SqlCommand
    Private da As SqlDataAdapter

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return strErrorMessage
        End Get
    End Property

    Public ReadOnly Property TableResult() As DataTable
        Get
            Return dtResult
        End Get
    End Property

    Public ReadOnly Property DatasetResult() As DataSet
        Get
            Return dsResult
        End Get
    End Property

    Public ReadOnly Property ObjectResult() As Object
        Get
            Return objResult
        End Get
    End Property

    Public ReadOnly Property ReaderResult() As IDataReader
        Get
            Return _readerResult
        End Get
    End Property

    Public Sub ClearAllPools()
        SqlConnection.ClearAllPools()
    End Sub

    Private Sub OpenConnection()
        If con Is Nothing Then con = New SqlConnection(ConStr)
    End Sub

    Private Sub CloseConnection()
        If Not cmd Is Nothing Then cmd.Dispose()
        If Not da Is Nothing Then da.Dispose()
        If Not _readerResult Is Nothing Then
            _readerResult.Close()
            _readerResult.Dispose()
        End If
        If Not con Is Nothing Then If con.State = ConnectionState.Open Then con.Close()
        ClearAllPools()
    End Sub

    Private Sub ExecuteNonQuery(ByVal cmdType As CommandType)
        cmd.CommandType = cmdType

        'If con.State = ConnectionState.Open Then con.Close()
        'con.Open()
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub _ExecuteScalar(ByVal cmdType As CommandType)
        cmd.CommandType = cmdType

        'If con.State = ConnectionState.Open Then con.Close()
        'con.Open()
        If con.State = ConnectionState.Closed Then con.Open()
        Dim _obj As Object
        _obj = cmd.ExecuteScalar()
        con.Close()

        objResult = _obj
    End Sub

    Private Sub _ExecuteReader(ByVal cmdType As CommandType)
        cmd.CommandType = cmdType

        'If con.State = ConnectionState.Open Then con.Close()
        'con.Open()
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader

        _readerResult = reader
    End Sub

    Private Sub FillDataAdapter(ByVal cmdType As CommandType)
        cmd.CommandTimeout = 0
        cmd.CommandType = cmdType
        da = New SqlDataAdapter(cmd)
        Dim _dt As New DataTable
        da.Fill(_dt)
        dtResult = _dt
    End Sub

    Public Function IsConnectionOK(Optional ByVal strConString As String = "") As Boolean
        Try
            If strConString <> "" Then ConStr = strConString
            OpenConnection()

            con.Open()
            con.Close()

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectQuery(ByVal strQuery As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand(strQuery, con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectCardTxn_MF_Report(ByVal dtmFrom As Date, ByVal dtmTo As Date, ByVal intCardTypeID As Integer) As Boolean
        Try
            Dim strWhereCriteria As String = String.Format(" AND CONVERT(char(10),DateTimePosted,101) BETWEEN '{0}' AND '{1}' ", dtmFrom.ToString("MM/dd/yyyy"), dtmTo.ToString("MM/dd/yyyy"))

            Dim sb As New System.Text.StringBuilder
            sb.Append("SELECT dbo.tblCardTxn.Card_No, dbo.tblCardType.CardType, dbo.tblCardType.CardTypeID FROM dbo.tblCardTxn INNER JOIN dbo.tblCardType ON dbo.tblCardTxn.CardTypeID = dbo.tblCardType.CardTypeID WHERE (ISNULL(dbo.tblCardTxn.IsSpoiled, 0) = 0) ")
            If intCardTypeID > 0 Then sb.Append(" AND dbo.tblCardType.CardTypeID=" & intCardTypeID.ToString)
            sb.Append(strWhereCriteria)

            'SharedFunction.ShowMessage(sb.ToString)
            OpenConnection()
            cmd = New SqlCommand(sb.ToString, con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectCardTxn_MF_Report_ByDate(ByVal dtmFrom As Date, ByVal dtmTo As Date, ByVal intCardTypeID As Integer) As Boolean
        Try
            Dim strWhereCriteria As String = String.Format(" AND CONVERT(char(10),DateTimePosted,101) BETWEEN '{0}' AND '{1}' ", dtmFrom.ToString("MM/dd/yyyy"), dtmTo.ToString("MM/dd/yyyy"))

            Dim sb As New System.Text.StringBuilder
            sb.Append("SELECT dbo.tblCardTxn.Card_No, dbo.tblCardType.CardType, dbo.tblCardType.CardTypeID FROM dbo.tblCardTxn INNER JOIN dbo.tblCardType ON dbo.tblCardTxn.CardTypeID = dbo.tblCardType.CardTypeID WHERE (ISNULL(dbo.tblCardTxn.IsSpoiled, 0) = 0) ")
            If intCardTypeID > 0 Then sb.Append(" AND dbo.tblCardType.CardTypeID=" & intCardTypeID.ToString)
            sb.Append(strWhereCriteria)

            'SharedFunction.ShowMessage(sb.ToString)
            OpenConnection()
            cmd = New SqlCommand(sb.ToString, con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectCardTxn_MF_Report_ByGSISNo(ByVal GSISNos As String) As Boolean
        Try
            Dim strWhereCriteria As String = String.Format(" AND dbo.tblCardTxn.GSIS_No IN ({0})", "'" & GSISNos.Replace(",", "','") & "'")

            Dim sb As New System.Text.StringBuilder
            sb.Append("SELECT dbo.tblCardTxn.Card_No, dbo.tblCardType.CardType, dbo.tblCardType.CardTypeID FROM dbo.tblCardTxn INNER JOIN dbo.tblCardType ON dbo.tblCardTxn.CardTypeID = dbo.tblCardType.CardTypeID WHERE (ISNULL(dbo.tblCardTxn.IsSpoiled, 0) = 0) ")
            sb.Append(strWhereCriteria)

            'SharedFunction.ShowInfoMessage(sb.ToString)
            OpenConnection()
            cmd = New SqlCommand(sb.ToString, con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectWeeklySummary_CardTxn() As Boolean
        Try
            Dim strDateTo As String = Now.ToString("MM/dd/yyyy")

            Dim DayOfWeekToday As Short = CDate(strDateTo).DayOfWeek
            Dim strDateFrom As String = CDate(strDateTo).AddDays(-(DayOfWeekToday - 1)).ToString("MM/dd/yyyy")
            Dim strWhereCriteria As String = String.Format(" AND CONVERT(char(10),DateTimePosted,101) BETWEEN '{0}' AND '{1}' ", strDateFrom, strDateTo)

            Dim sb As New System.Text.StringBuilder
            sb.Append("SELECT CONVERT(char(20),DateTimePosted,101) As DatePost, COUNT(CardTxnID) As Qty FROM dbo.tblCardTxn WHERE (ISNULL(IsSpoiled, 0) = 0) ")
            sb.Append(strWhereCriteria)
            sb.Append(" GROUP BY CONVERT(char(20),DateTimePosted,101)")
            OpenConnection()
            cmd = New SqlCommand(sb.ToString, con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectWeeklySummary_Spoiled() As Boolean
        Try
            Dim strDateTo As String = Now.ToString("MM/dd/yyyy")

            Dim DayOfWeekToday As Short = CDate(strDateTo).DayOfWeek
            Dim strDateFrom As String = CDate(strDateTo).AddDays(-(DayOfWeekToday - 1)).ToString("MM/dd/yyyy")
            Dim strWhereCriteria As String = String.Format(" WHERE CONVERT(char(10),DateTimePosted,101) BETWEEN '{0}' AND '{1}' ", strDateFrom, strDateTo)

            'SharedFunction.ShowMessage(strWhereCriteria)

            Dim sb As New System.Text.StringBuilder
            sb.Append("SELECT CONVERT(char(20),DateTimePosted,101) As DatePost, COUNT(CardTxnID) As Qty FROM dbo.tblSpoiledTxn ")
            sb.Append(strWhereCriteria)
            sb.Append(" GROUP BY CONVERT(char(20),DateTimePosted,101)")
            OpenConnection()
            cmd = New SqlCommand(sb.ToString, con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectRelCardProfileProperty(ByVal CardProfileID As Integer) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("SELECT * FROM dbo.tblRelCardProfileProperty WHERE CardProfileID=" & CardProfileID.ToString, con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectCardTxnTotalByCardType(ByVal strWhereCriteria As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("SELECT CardTypeID, IsSpoiled, DateTimePosted FROM dbo.tblCardTxn " & strWhereCriteria, con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function GetTotalCardInventoried(ByVal strWhereCriteria As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("SELECT COUNT(CardInvID) FROM dbo.tblCardInventory " & strWhereCriteria, con)

            _ExecuteScalar(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectMagstripeData(ByVal Magstripe As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcSelectMagstripeData", con)
            cmd.Parameters.AddWithValue("Magstripe", Magstripe)

            FillDataAdapter(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectCard_NoData(ByVal Card_No As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcSelectCard_NoData", con)
            cmd.Parameters.AddWithValue("Card_No", Card_No)

            FillDataAdapter(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectUserRole(ByVal UserID As Integer) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcSelectUserRole", con)
            cmd.Parameters.AddWithValue("UserID", UserID)

            FillDataAdapter(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectSpoiledTxn(ByVal WhereCriteria As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcSelectSpoiledTxn", con)
            cmd.Parameters.AddWithValue("WhereCriteria", WhereCriteria)

            FillDataAdapter(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectCardTxn(ByVal WhereCriteria As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcSelectCardTxn", con)
            cmd.Parameters.AddWithValue("WhereCriteria", WhereCriteria)

            FillDataAdapter(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function
    
    Public Function SelectRptCIR(ByVal CardTxnID As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("SELECT CardTypeID, FName, MName, LName, Address, DateOfBirth, PlaceOfBirth, GSIS_No, Card_No, GSIS_HandlingBranch, GSIS_OfficeCode, IsSpoiled FROM dbo.tblCardTxn WHERE CardTxnID=" & CardTxnID, con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function ValidateLogIn(ByVal WhereCriteria As String) As Boolean
        Try
            Dim sb As New System.Text.StringBuilder
            sb.Append("SELECT dbo.tblUser.UserID, dbo.tblUser.Username, dbo.tblUser.Password, dbo.tblUser.FName, dbo.tblUser.MName, dbo.tblUser.LName, dbo.tblRole.RoleDesc, dbo.tblRole.RoleID ")
            sb.Append("FROM dbo.tblUser INNER JOIN dbo.tblRole ON dbo.tblUser.RoleID = dbo.tblRole.RoleID ")
            sb.Append("WHERE (ISNULL(dbo.tblUser.IsDeleted, 0) = 0) AND (ISNULL(dbo.tblUser.IsActive, 0) = 1) ")
            sb.Append(WhereCriteria)

            OpenConnection()
            cmd = New SqlCommand(sb.ToString, con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectCardInventory(ByVal WhereCriteria As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcSelectCardInventory", con)
            cmd.Parameters.AddWithValue("WhereCriteria", WhereCriteria)

            FillDataAdapter(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function SelectUser(ByVal WhereCriteria As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcSelectUser", con)
            cmd.Parameters.AddWithValue("WhereCriteria", WhereCriteria)

            FillDataAdapter(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function ExecuteQuery(ByVal strQuery As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand(strQuery, con)

            ExecuteNonQuery(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function ResetPassword(ByVal UserID As Integer) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand(String.Format("UPDATE dbo.tblUser SET Password='{0}' WHERE UserID={1}", EncryptDecrypt.EncryptData(My.Settings.DefAppPassword), UserID), con)

            ExecuteNonQuery(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function ChangeUserStatus(ByVal UserID As Integer, ByVal IsStatus As Boolean) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand(String.Format("UPDATE dbo.tblUser SET IsActive='{0}' WHERE UserID={1}", IsStatus, UserID), con)

            ExecuteNonQuery(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function ExecuteScalar(ByVal strQuery As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand(strQuery, con)

            _ExecuteScalar(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function AddCardInventory(ByVal Card_No As String, ByVal ExpiryDate As String, ByVal Magstripe As String, ByVal UserID As Integer, ByVal CardProdType As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcAddCardInventory", con)
            cmd.Parameters.AddWithValue("Card_No", Card_No)
            cmd.Parameters.AddWithValue("ExpiryDate", ExpiryDate)
            cmd.Parameters.AddWithValue("Magstripe", Magstripe)
            cmd.Parameters.AddWithValue("UserID", UserID)
            cmd.Parameters.AddWithValue("CardProdType", CardProdType)

            ExecuteNonQuery(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function AddUser(ByVal Username As String, ByVal FName As String, ByVal MName As String, ByVal LName As String, _
                            ByVal RoleID As Integer) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcAddUser", con)
            cmd.Parameters.AddWithValue("Username", Username)
            cmd.Parameters.AddWithValue("Password", EncryptDecrypt.EncryptData(My.Settings.DefAppPassword))
            cmd.Parameters.AddWithValue("FName", FName)
            cmd.Parameters.AddWithValue("MName", MName)
            cmd.Parameters.AddWithValue("LName", LName)
            cmd.Parameters.AddWithValue("RoleID", RoleID)

            _ExecuteScalar(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function EditUser(ByVal UserID As Integer, ByVal Username As String, ByVal FName As String, ByVal MName As String, ByVal LName As String, _
                           ByVal RoleID As Integer) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcEditUser", con)
            cmd.Parameters.AddWithValue("UserID", UserID)
            cmd.Parameters.AddWithValue("Username", Username)
            cmd.Parameters.AddWithValue("FName", FName)
            cmd.Parameters.AddWithValue("MName", MName)
            cmd.Parameters.AddWithValue("LName", LName)
            cmd.Parameters.AddWithValue("RoleID", RoleID)

            _ExecuteScalar(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function AddCardTxn(ByVal UserID As Integer, ByVal CardTypeID As Short, ByVal TxnTypeID As Short, _
                               ByVal GSIS_No As String, ByVal Card_No As String, ByVal FName As String, _
                               ByVal MName As String, ByVal LName As String, ByVal DateOfBirth As String, _
                               ByVal PlaceOfBirth As String, ByVal Address As String, _
                               ByVal Retirement_No As String, ByVal GSIS_HandlingBranch As String, _
                               ByVal GSIS_OfficeCode As String, ByVal AcctNo As String, _
                               ByVal ApproverUsername As String, ByVal ModificationRemark As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcAddCardTxn", con)
            cmd.Parameters.AddWithValue("UserID", UserID)
            cmd.Parameters.AddWithValue("CardTypeID", CardTypeID)
            cmd.Parameters.AddWithValue("TxnTypeID", TxnTypeID)
            cmd.Parameters.AddWithValue("GSIS_No", GSIS_No)
            cmd.Parameters.AddWithValue("Card_No", Card_No)
            cmd.Parameters.AddWithValue("FName", FName)
            cmd.Parameters.AddWithValue("MName", MName)
            cmd.Parameters.AddWithValue("LName", LName)
            cmd.Parameters.AddWithValue("DateOfBirth", DateOfBirth)
            cmd.Parameters.AddWithValue("PlaceOfBirth", PlaceOfBirth)
            cmd.Parameters.AddWithValue("Address", Address)
            cmd.Parameters.AddWithValue("Retirement_No", Retirement_No)
            cmd.Parameters.AddWithValue("GSIS_HandlingBranch", GSIS_HandlingBranch)
            cmd.Parameters.AddWithValue("GSIS_OfficeCode", GSIS_OfficeCode)
            cmd.Parameters.AddWithValue("AcctNo", AcctNo)
            cmd.Parameters.AddWithValue("ApproverUsername", ApproverUsername)
            cmd.Parameters.AddWithValue("ModificationRemark", ModificationRemark)

            _ExecuteScalar(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function AddCardTxnv2(ByVal UserID As Integer, ByVal CardTypeID As Short, ByVal TxnTypeID As Short, _
                               ByVal GSIS_No As String, ByVal Card_No As String, ByVal FName As String, _
                               ByVal MName As String, ByVal LName As String, ByVal DateOfBirth As String, _
                               ByVal PlaceOfBirth As String, ByVal HomeStreet As String, ByVal HomeTownCity As String, _
                               ByVal HomeProvince As String, ByVal HomeRegion As String, ByVal HomeZip As String, _
                               ByVal Telephone_No As String, ByVal Mobile_No As String, ByVal Email As String, _
                               ByVal FName_Father As String, ByVal MName_Father As String, ByVal LName_Father As String, _
                               ByVal FName_Mother As String, ByVal MName_Mother As String, ByVal LName_Mother As String, _
                               ByVal Retirement_No As String, ByVal GSIS_HandlingBranch As String, ByVal GSIS_OfficeCode As String, _
                               ByVal GSIS_Site As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcAddCardTxn", con)
            cmd.Parameters.AddWithValue("UserID", UserID)
            cmd.Parameters.AddWithValue("CardTypeID", CardTypeID)
            cmd.Parameters.AddWithValue("TxnTypeID", TxnTypeID)
            cmd.Parameters.AddWithValue("GSIS_No", GSIS_No)
            cmd.Parameters.AddWithValue("Card_No", Card_No)
            cmd.Parameters.AddWithValue("FName", FName)
            cmd.Parameters.AddWithValue("MName", MName)
            cmd.Parameters.AddWithValue("LName", LName)
            cmd.Parameters.AddWithValue("DateOfBirth", DateOfBirth)
            cmd.Parameters.AddWithValue("PlaceOfBirth", PlaceOfBirth)
            cmd.Parameters.AddWithValue("HomeStreet", HomeStreet)
            cmd.Parameters.AddWithValue("HomeTownCity", HomeTownCity)
            cmd.Parameters.AddWithValue("HomeProvince", HomeProvince)
            cmd.Parameters.AddWithValue("HomeRegion", HomeRegion)
            cmd.Parameters.AddWithValue("HomeZip", HomeZip)
            cmd.Parameters.AddWithValue("Telephone_No", Telephone_No)
            cmd.Parameters.AddWithValue("Mobile_No", Mobile_No)
            cmd.Parameters.AddWithValue("Email", Email)
            cmd.Parameters.AddWithValue("FName_Father", FName_Father)
            cmd.Parameters.AddWithValue("MName_Father", MName_Father)
            cmd.Parameters.AddWithValue("LName_Father", LName_Father)
            cmd.Parameters.AddWithValue("FName_Mother", FName_Mother)
            cmd.Parameters.AddWithValue("MName_Mother", MName_Mother)
            cmd.Parameters.AddWithValue("LName_Mother", LName_Mother)
            cmd.Parameters.AddWithValue("Retirement_No", Retirement_No)
            cmd.Parameters.AddWithValue("GSIS_HandlingBranch", GSIS_HandlingBranch)
            cmd.Parameters.AddWithValue("GSIS_OfficeCode", GSIS_OfficeCode)
            cmd.Parameters.AddWithValue("GSIS_Site", GSIS_Site)

            ExecuteNonQuery(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function AddSpoiledTxn(ByVal Card_No As String, ByVal CardTxnID As Object, ByVal UserID As Integer, _
                                  ByVal SpoiledReasonID As Integer, ByVal OtherReason As String, ByVal ApproverUsername As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcAddSpoiledTxn", con)
            cmd.Parameters.AddWithValue("Card_No", Card_No)
            cmd.Parameters.AddWithValue("CardTxnID", CardTxnID)
            cmd.Parameters.AddWithValue("UserID", UserID)
            cmd.Parameters.AddWithValue("SpoiledReasonID", SpoiledReasonID)
            cmd.Parameters.AddWithValue("OtherReason", OtherReason)
            cmd.Parameters.AddWithValue("ApproverUsername", ApproverUsername)

            ExecuteNonQuery(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function AddSystemLog(ByVal SystemLogDesc As String, ByVal Process As String, ByVal UserID As Integer) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcAddSystemLog", con)
            cmd.Parameters.AddWithValue("SystemLogDesc", SystemLogDesc)
            cmd.Parameters.AddWithValue("Process", Process)
            cmd.Parameters.AddWithValue("SubmittedBy_UserID", UserID)

            ExecuteNonQuery(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function AddLoggedUsers(ByVal UserID As Integer) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcAddLoggedUsers", con)
            cmd.Parameters.AddWithValue("UserID", UserID)

            ExecuteNonQuery(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function AddErrorLog(ByVal ErrorLogDesc As String, ByVal Process As String, ByVal UserID As Integer) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcAddErrorLog", con)
            cmd.Parameters.AddWithValue("ErrorLogDesc", ErrorLogDesc)
            cmd.Parameters.AddWithValue("Process", Process)
            cmd.Parameters.AddWithValue("SubmittedBy_UserID", UserID)

            ExecuteNonQuery(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Function UpdateRelCardProfileProperty(ByVal CPPropertyID As Integer, _
                                                 ByVal PositionTop As Integer, ByVal PositionLeft As Integer, _
                                                 ByVal ImageHeight As Integer, ByVal ImageWidth As Integer, _
                                                 ByVal Size As Integer, ByVal Font As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand("prcUpdateRelCardProfileProperty", con)
            cmd.Parameters.AddWithValue("CPPropertyID", CPPropertyID)
            cmd.Parameters.AddWithValue("PositionTop", PositionTop)
            cmd.Parameters.AddWithValue("PositionLeft", PositionLeft)
            cmd.Parameters.AddWithValue("ImageHeight", ImageHeight)
            cmd.Parameters.AddWithValue("ImageWidth", ImageWidth)
            cmd.Parameters.AddWithValue("Size", Size)
            cmd.Parameters.AddWithValue("Font", Font)

            ExecuteNonQuery(CommandType.StoredProcedure)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        End Try
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
            CloseConnection()

        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
