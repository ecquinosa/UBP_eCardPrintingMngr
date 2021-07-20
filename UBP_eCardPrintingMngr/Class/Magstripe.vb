Public Class Magstripe

    Private _CardMagstripe As String = ""
    Private _Magstripe As String = ""
    Private _CardNo As String = ""
    Private _ExpiryDate As String = ""
    Private _CardType As String = ""

    Private _Last3Digits As String = ""

    Public Sub New(ByVal _CardMagstripe As String, Optional _Last3Digits As String = "")
        Me._CardMagstripe = _CardMagstripe

        If Me._CardMagstripe.Substring(0, 4) = ";589" Then
            _CardType = SharedFunction.CardType_OPLUS
        ElseIf Me._CardMagstripe.Substring(0, 4).ToUpper = "%B44" Then
            _CardType = SharedFunction.CardType_VISA
        End If

        _Magstripe = _CardMagstripe

        If _CardType = SharedFunction.CardType_OPLUS Then
            _CardNo = Microsoft.VisualBasic.Right(_Magstripe.Split("=")(0), 10) & _Last3Digits
            _ExpiryDate = _Magstripe.Split("=")(1).Substring(0, 4)
            '_Magstripe = _CardMagstripe.Substring(0, 29)
        ElseIf _CardType = SharedFunction.CardType_VISA Then
            _CardNo = Microsoft.VisualBasic.Right(_Magstripe.Split("^")(0), 16)
            _ExpiryDate = _Magstripe.Split("^")(2).Substring(0, 4)
            '_Magstripe = _CardMagstripe.Substring(0, 29)
        End If



        'If _Last3Digits <> "" Then
        '    _CardNo = Microsoft.VisualBasic.Right(_Magstripe.Split("=")(0), 10) & _Last3Digits
        'Else
        '    Dim DAL As New DAL_UBP_EcardMgr
        '    If DAL.ExecuteScalar(String.Format("SELECT Card_No FROM tblCardInventory WHERE Magstripe='{0}'", _Magstripe)) Then
        '        _CardNo = DAL.ObjectResult.ToString
        '    End If
        'End If


    End Sub

    Public ReadOnly Property Magstripe As String
        Get
            Return _Magstripe
        End Get
    End Property

    Public ReadOnly Property Card_No As String
        Get
            Return _CardNo
        End Get
    End Property

    Public ReadOnly Property CardType As String
        Get
            Return _CardType
        End Get
    End Property


    Public ReadOnly Property ExpiryDate As String
        Get
            Return _ExpiryDate
        End Get
    End Property

End Class
