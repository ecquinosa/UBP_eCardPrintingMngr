
Imports System.Data.OleDb

Public Class DAL_GSIS_Oracle

    'test server
    Private ConStr As String = String.Format("Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = {0})(PORT = {1})))(CONNECT_DATA=(SERVICE_NAME = {2})));User Id={3};Password={4};", My.Settings.Server_GSIS, My.Settings.Port_GSIS, My.Settings.ServiceName_GSIS, My.Settings.User_GSIS, My.Settings.Password_GSIS)

    Private dtResult As DataTable
    Private objResult As Object
    Private strErrorMessage As String

    Private con As OleDbConnection
    Private cmd As OleDbCommand
    Private da As OleDbDataAdapter
    Private intUserID As Integer = 0

    Private sbQuery As New System.Text.StringBuilder

    Public Sub New()
    End Sub

    Public Sub New(ByVal intUserID As Integer)
        Me.intUserID = intUserID
    End Sub

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

    Public ReadOnly Property ObjectResult() As Object
        Get
            Return objResult
        End Get
    End Property

    Private Sub OpenConnection()
        Try
            con = New OleDbConnection(ConStr)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CloseConnection()
        If Not cmd Is Nothing Then cmd.Dispose()
        If Not da Is Nothing Then da.Dispose()
        If con.State = ConnectionState.Open Then con.Close()
    End Sub

    Private Sub ExecuteNonQuery(ByVal cmdType As CommandType)
        cmd.CommandType = cmdType

        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub ExecuteScalar(ByVal cmdType As CommandType)
        cmd.CommandType = cmdType

        con.Open()
        Dim _obj As Object
        _obj = cmd.ExecuteScalar()
        con.Close()

        objResult = _obj
    End Sub

    Private Sub FillDataAdapter(ByVal cmdType As CommandType)
        cmd.CommandType = cmdType
        da = New OleDbDataAdapter(cmd)
        Dim _dt As New DataTable
        da.Fill(_dt)
        dtResult = _dt
    End Sub

    Private Sub FillDataAdapterDS(ByVal cmdType As CommandType, ByRef ds As DataSet)
        cmd.CommandType = cmdType
        da = New OleDbDataAdapter(cmd)
        Dim _dt As New DataTable
        da.Fill(ds, "PROG_SECURA_DEFAULT")
        'da.Fill(_dt)
        'dtResult = _dt
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
        Finally
            CloseConnection()
        End Try
    End Function

    Public Function ExecuteQuery(ByVal strQuery As String) As Boolean
        Try
            OpenConnection()
            cmd = New OleDbCommand(strQuery, con)

            ExecuteNonQuery(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    Public Function Update_ENROLLEE_TA_CardNo(ByVal GSISNo As String, ByVal CardNo As String) As Boolean
        Try
            OpenConnection()
            Dim strQuery As String = String.Format("update ECARD_DB.ENROLLEE_TA set ECARD_DB.ENROLLEE_TA.ECARD_PLUS_NO = '" & CardNo & "' where ECARD_DB.ENROLLEE_TA.OLD_GSIS_NO = '" & GSISNo & "'")
            cmd = New OleDbCommand(strQuery, con)

            ExecuteNonQuery(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    Public Function ExecuteQuery_Scalar(ByVal strQuery As String) As Boolean
        Try
            OpenConnection()
            cmd = New OleDbCommand(strQuery, con)

            ExecuteScalar(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    Public Function SelectQuery(ByVal strQuery As String) As Boolean
        Try
            OpenConnection()
            cmd = New OleDbCommand(strQuery, con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    Public Function SelectCIR(ByVal strWhereCriteria As String) As Boolean
        Try
            Dim sb As New System.Text.StringBuilder
            sb.Append("SELECT ECARD_DB.ENROLLEE_TA.OLD_GSIS_NO, ECARD_DB.ENROLLEE_TA.CRN, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.ECARD_PLUS_NO, ECARD_DB.ENROLLEE_TA.CARD_PREFERRED_NAME, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.FIRST_NAME, ECARD_DB.ENROLLEE_TA.MIDDLE_NAME, ECARD_DB.ENROLLEE_TA.LAST_NAME, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.BIRTHDATE, ECARD_DB.ENROLLEE_TA.BIRTHPLACE, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.CARDTYPE, ECARD_DB.ENROLLEE_TA.PREFERREDBANK, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.HANDLING_BRANCH_CODE, ECARD_DB.ENROLLEE_TA.OFFICECODE, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.ENROLLED_AT, ECARD_DB.ENROLLEE_TA.ADDRESS1, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.ADDRESS2, ECARD_DB.ENROLLEE_TA.ADDRESS3, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.ADDRESS4, ECARD_DB.ENROLLEE_TA.HOME_STREET, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.HOME_TOWNCITY, ECARD_DB.ENROLLEE_TA.HOME_PROVINCE, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.HOME_REGION, ECARD_DB.ENROLLEE_TA.HOME_ZIP, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.HOME_COUNTRY, ECARD_DB.ENROLLEE_TA.RETIREMENTNO FROM ECARD_DB.ENROLLEE_TA ")
            sb.Append(strWhereCriteria)

            OpenConnection()
            cmd = New OleDbCommand(sb.ToString, con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    Public Function Generate_MF_Report(ByVal strWhereCriteria As String) As Boolean
        Try
            Dim sb As New System.Text.StringBuilder
            sb.Append("SELECT ECARD_DB.ENROLLEE_TA.OLD_GSIS_NO, ECARD_DB.ENROLLEE_TA.OLD_GSIS_NO, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.NEW_GSIS_NO, ECARD_DB.ENROLLEE_TA.FIRST_NAME, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.MIDDLE_NAME, ECARD_DB.ENROLLEE_TA.LAST_NAME, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.NAME_SUFFIX, ECARD_DB.ENROLLEE_TA.BIRTHDATE, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.ADDRESS1, ECARD_DB.ENROLLEE_TA.ADDRESS2, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.HOME_STREET, ECARD_DB.ENROLLEE_TA.ADDRESS3, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.ADDRESS4, ECARD_DB.ENROLLEE_TA.HOME_TOWNCITY, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.HOME_PROVINCE, ECARD_DB.ENROLLEE_TA.HOME_ZIP, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.HOME_COUNTRY, ECARD_DB.ENROLLEE_TA.PHONE_CELL, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.EMAIL, ECARD_DB.ENROLLEE_TA.BIRTHPLACE, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.BIRTHPLACE_PROVINCE, ECARD_DB.ENROLLEE_TA.MOTHERSFIRSTNAME, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.MOTHERSMIDDLENAME, ECARD_DB.ENROLLEE_TA.MOTHERSLASTNAME, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.MOTHER_SUFFIX, ECARD_DB.ENROLLEE_TA.HANDLING_BRANCH_CODE, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.OFFICECODE, ECARD_DB.ENROLLEE_TA.OFFICENAME, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.RETIREMENTNO, ECARD_DB.ENROLLEE_TA.RETIREMENTDATE, ")
            'sb.Append("ECARD_DB.ENROLLEE_TA.SURVIVORRETIREMENTNO, ECARD_DB.ENROLLEE_TA.SIGNATURE_STAT, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.SURVIVORRETIREMENTNO, '' As SIGNATURE_STAT, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.ENROLLEE_STATUS, 'N' As GSIS_EMPLOYEE, ")
            sb.Append("'' As UMID_CARDTYPE, TIN_NO, ")
            sb.Append("CASE ")
            sb.Append("WHEN SUBSTR(ECARD_DB.ENROLLEE_TA.ECARD_PLUS_NO,0,3) IN (956,957) THEN 'OPLUS' ")
            sb.Append("WHEN SUBSTR(ECARD_DB.ENROLLEE_TA.ECARD_PLUS_NO,0,3) IN (440) THEN 'VISA' ")
            sb.Append("END As CARD_PROD_TYPE, ")
            sb.Append("ECARD_DB.ENROLLEE_TA.ECARD_NO, ECARD_DB.ENROLLEE_TA.ECARD_PLUS_NO ")
            sb.Append("FROM ECARD_DB.ENROLLEE_TA ")
            sb.Append(strWhereCriteria)

            'SharedFunction.ShowMessage(sb.ToString)

            OpenConnection()
            cmd = New OleDbCommand(sb.ToString, con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    Public Function SelectPhotoAndSignature(ByVal GSISNo As String) As Boolean
        Try
            OpenConnection()
            cmd = New OleDbCommand(String.Format("SELECT ECARD_DB.PHOTOSIGNATURE_TA.PHOTO, ECARD_DB.PHOTOSIGNATURE_TA.SIGNATURE FROM ECARD_DB.PHOTOSIGNATURE_TA WHERE ECARD_DB.PHOTOSIGNATURE_TA.OLD_GSIS_NO = '{0}'", GSISNo), con)

            FillDataAdapter(CommandType.Text)

            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

End Class
