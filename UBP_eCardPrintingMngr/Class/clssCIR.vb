Public Class clssCIR

    Public Sub New(ByVal valueToSearch As String, ByVal _intSearchType As Short, Optional _IsBindPhoto As Boolean = False)
        _valueToSearch = valueToSearch.Trim

        Me._intSearchType = _intSearchType
        Me._IsBindPhoto = _IsBindPhoto

        _IsSuccess = GetMemberData()

        If _IsBindPhoto Then
            If _IsSuccess Then
                _IsSuccess = GetMemberPhoto(_GSISNo)
            End If
        End If
    End Sub

    Private _intSearchType As Short = 0 '1 = GSISNo, 2 = CRN, 3 = CardNo
    Private _valueToSearch As String = ""

    Private _GSISNo As String
    Private _CRN As String
    Private _CardNo As String
    Private _FName As String
    Private _MName As String
    Private _LName As String
    Private _FullName As String
    Private _CardName As String
    Private _DateOfBirth As String
    Private _PlaceOfBirth As String

    Private _Address1 As String
    Private _Address2 As String
    Private _Address3 As String
    Private _Address4 As String
    Private _HomeStreet As String
    Private _HomeTownCity As String
    Private _HomeProvince As String
    Private _HomeRegion As String
    Private _HomeCountry As String
    Private _HomeZip As String
    Private _MailingAddress As String

    Private _MFType As String
    Private _PreferredBank As String
    Private _HandlingBranch As String
    Private _OfficeCode As String
    Private _EnrolledAt As String

    Private _RetirementNo As String

    Private _ErrorMessage As String
    Private _IsSuccess As Boolean

    Private _Photo() As Byte
    Private _IsBindPhoto As Boolean

    Private Function GetMemberData() As Boolean
        Try
            Dim strWhereCriteria As String = ""
            Select Case _intSearchType
                Case 0
                    strWhereCriteria = String.Format(" WHERE ECARD_DB.ENROLLEE_TA.OLD_GSIS_NO='{0}'", _valueToSearch)
                Case 1
                    strWhereCriteria = String.Format(" WHERE ECARD_DB.ENROLLEE_TA.CRN='{0}'", _valueToSearch)
                Case 2
                    strWhereCriteria = String.Format(" WHERE ECARD_DB.ENROLLEE_TA.ECARD_PLUS_NO='{0}'", _valueToSearch)
            End Select

            'SharedFunction.ShowInfoMessage("SelectCIR")
            Dim DAL As New DAL_GSIS_Oracle
            If DAL.SelectCIR(strWhereCriteria) Then
                Dim rw As DataRow = DAL.TableResult.Rows(0)
                _GSISNo = ConvertFromNULLToString(rw("OLD_GSIS_NO"))
                _CRN = ConvertFromNULLToString(rw("CRN"))
                _CardNo = ConvertFromNULLToString(rw("ECARD_PLUS_NO"))
                _FName = ConvertFromNULLToString(rw("FIRST_NAME"))
                _MName = ConvertFromNULLToString(rw("MIDDLE_NAME"))
                _LName = ConvertFromNULLToString(rw("LAST_NAME"))
                Try
                    _FullName = String.Format("{0}{1}{2}", _FName, IIf(_MName = "", " ", " " & _MName & " "), _LName)
                    _CardName = SharedFunction.CompleteName2(_FName, _MName, _LName) '  String.Format("{0}{1}{2}", _FName, IIf(_MName = "", " ", " " & _MName.Substring(0, 1) & ". "), _LName) 
                Catch ex As Exception

                End Try
                
                _DateOfBirth = ConvertFromNULLToString(rw("BIRTHDATE"))
                _PlaceOfBirth = ConvertFromNULLToString(rw("BIRTHPLACE"))

                _Address1 = ConvertFromNULLToString(rw("ADDRESS1"))
                _Address2 = ConvertFromNULLToString(rw("ADDRESS2"))
                _Address3 = ConvertFromNULLToString(rw("ADDRESS3"))
                _Address4 = ConvertFromNULLToString(rw("ADDRESS4"))
                _HomeStreet = ConvertFromNULLToString(rw("HOME_STREET"))
                _HomeTownCity = ConvertFromNULLToString(rw("HOME_TOWNCITY"))
                _HomeProvince = ConvertFromNULLToString(rw("HOME_PROVINCE"))
                '_HomeRegion = ConvertFromNULLToString(rw("HOME_REGION"))
                _HomeCountry = ConvertFromNULLToString(rw("HOME_COUNTRY"))
                _HomeZip = ConvertFromNULLToString(rw("HOME_ZIP"))

                Try
                    '_MailingAddress = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}", FormatAddress(_Address1), FormatAddress(_Address2), FormatAddress(_HomeStreet), FormatAddress(_Address3), FormatAddress(_Address4), FormatAddress(_HomeTownCity), FormatAddress(_HomeProvince), FormatAddress(_HomeRegion), FormatAddress(_HomeCountry), _HomeZip)
                    _MailingAddress = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", FormatAddress(_Address1), FormatAddress(_Address2), FormatAddress(_HomeStreet), FormatAddress(_Address3), FormatAddress(_Address4), FormatAddress(_HomeTownCity), FormatAddress(_HomeProvince), FormatAddress(_HomeCountry), _HomeZip)
                Catch ex As Exception
                End Try

                _MFType = ConvertFromNULLToString(rw("CARDTYPE"))
                _PreferredBank = ConvertFromNULLToString(rw("PREFERREDBANK"))
                _HandlingBranch = ConvertFromNULLToString(rw("HANDLING_BRANCH_CODE"))
                _OfficeCode = ConvertFromNULLToString(rw("OFFICECODE"))
                _EnrolledAt = ConvertFromNULLToString(rw("ENROLLED_AT"))
                _RetirementNo = ConvertFromNULLToString(rw("RETIREMENTNO"))
            Else
                _ErrorMessage = DAL.ErrorMessage
                Return False
            End If
            DAL = Nothing

            Return True
        Catch ex As Exception
            _ErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Private Function ConvertFromNULLToString(ByVal value As Object) As String
        If IsDBNull(value) Then
            Return ""
        Else
            Return value.ToString.Trim
        End If
    End Function

    Private Function FormatAddress(ByVal value As String) As String
        If value.Length = 0 Then
            Return ""
        Else
            Return Trim(value) & " "
        End If
    End Function

    Private Function GetMemberPhoto(ByVal GSISNo As String) As Boolean
        Try
            'SharedFunction.ShowInfoMessage("photo")
            Dim DAL As New DAL_GSIS_Oracle
            If DAL.SelectPhotoAndSignature(GSISNo) Then
                Dim rw As DataRow = DAL.TableResult.Rows(0)
                _Photo = rw("PHOTO")
            End If
            DAL = Nothing

            Return True
        Catch ex As Exception
            _ErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public ReadOnly Property ErrorMessage As String
        Get
            Return _ErrorMessage
        End Get
    End Property

    Public ReadOnly Property IsSuccess As Boolean
        Get
            Return _IsSuccess
        End Get
    End Property

    Public ReadOnly Property Photo As Byte()
        Get
            Return _Photo
        End Get
    End Property

    Public ReadOnly Property GSISNo As String
        Get
            Return _GSISNo
        End Get
    End Property

    Public ReadOnly Property CRN As String
        Get
            Return _CRN
        End Get
    End Property

    Public ReadOnly Property CardNo As String
        Get
            Return _CardNo
        End Get
    End Property

    Public ReadOnly Property FName As String
        Get
            Return _FName
        End Get
    End Property

    Public ReadOnly Property MName As String
        Get
            Return _MName
        End Get
    End Property

    Public ReadOnly Property LName As String
        Get
            Return _LName
        End Get
    End Property

    Public ReadOnly Property FullName As String
        Get
            Return _FullName
        End Get
    End Property

    Public ReadOnly Property CardName As String
        Get
            Return _CardName
        End Get
    End Property

    Public ReadOnly Property DateOfBirth As String
        Get
            Return _DateOfBirth
        End Get
    End Property

    Public ReadOnly Property PlaceOfBirth As String
        Get
            Return _PlaceOfBirth
        End Get
    End Property

    Public ReadOnly Property Address1 As String
        Get
            Return _Address1
        End Get
    End Property

    Public ReadOnly Property Address2 As String
        Get
            Return _Address2
        End Get
    End Property

    Public ReadOnly Property Address3 As String
        Get
            Return _Address3
        End Get
    End Property

    Public ReadOnly Property Address4 As String
        Get
            Return _Address4
        End Get
    End Property

    Public ReadOnly Property HomeStreet As String
        Get
            Return _HomeStreet
        End Get
    End Property

    Public ReadOnly Property HomeTownCity As String
        Get
            Return _HomeTownCity
        End Get
    End Property

    Public ReadOnly Property HomeProvince As String
        Get
            Return _HomeProvince
        End Get
    End Property

    Public ReadOnly Property HomeRegion As String
        Get
            Return _HomeRegion
        End Get
    End Property

    Public ReadOnly Property HomeCountry As String
        Get
            Return _HomeCountry
        End Get
    End Property

    Public ReadOnly Property HomeZip As String
        Get
            Return _HomeZip
        End Get
    End Property

    Public ReadOnly Property MailingAddress As String
        Get
            Return _MailingAddress
        End Get
    End Property

    Public ReadOnly Property MFType As String
        Get
            Return _MFType
        End Get
    End Property

    Public ReadOnly Property PreferredBank As String
        Get
            Return _PreferredBank
        End Get
    End Property

    Public ReadOnly Property HandlingBranch As String
        Get
            Return _HandlingBranch
        End Get
    End Property

    Public ReadOnly Property OfficeCode As String
        Get
            Return _OfficeCode
        End Get
    End Property

    Public ReadOnly Property EnrolledAt As String
        Get
            Return _EnrolledAt
        End Get
    End Property

    Public ReadOnly Property RetirementNo As String
        Get
            Return _RetirementNo
        End Get
    End Property

End Class
