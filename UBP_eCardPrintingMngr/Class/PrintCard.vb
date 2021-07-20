
Imports UBP_eCardPrintingMngr.Spooler
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports System.Threading
Imports System.Windows.Forms

Public Class PrintCard
    Implements IDisposable

    Private WithEvents m_pDoc As New PrintDocument

    Private _CardName As String = ""
    Private _GSISNo As String = ""
    Private _CardProfileID As Integer
    Private _IsPrintPhoto As Boolean

    Private imgPhoto As Image

    Public X As Integer
    Public Y As Integer
    Public imgWidth As Integer
    Public imgHeight As Integer

    Public intPage As Short = 1

    Public _IsHasMorePages As Boolean = False

    Public Property CardProfileID() As Integer
        Get
            Return _CardProfileID
        End Get
        Set(ByVal value As Integer)
            _CardProfileID = value
        End Set
    End Property

    Public Property CardName() As String
        Get
            Return _CardName
        End Get
        Set(ByVal value As String)
            _CardName = value
        End Set
    End Property

    Public Property GSISNo() As String
        Get
            Return _GSISNo
        End Get
        Set(ByVal value As String)
            _GSISNo = value
        End Set
    End Property

    Public Property IsPrintPhoto() As Boolean
        Get
            Return _IsPrintPhoto
        End Get
        Set(ByVal value As Boolean)
            _IsPrintPhoto = value
        End Set
    End Property

    Public Property Photo() As Image
        Get
            Return imgPhoto
        End Get
        Set(ByVal value As Image)
            imgPhoto = value
        End Set
    End Property

    Public Property HasMorePages() As Boolean
        Get
            Return _IsHasMorePages
        End Get
        Set(ByVal value As Boolean)
            _IsHasMorePages = value
        End Set
    End Property

    Public Property Page() As Short
        Get
            Return intPage
        End Get
        Set(ByVal value As Short)
            intPage = value
        End Set
    End Property


#Region "Printing"

    Private Sub m_pDoc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles m_pDoc.BeginPrint
        m_pDoc.DocumentName = "eCardPrintinManager - Printing of GSIS#" & _GSISNo
        m_pDoc.DefaultPageSettings.Landscape = True
        m_pDoc.PrinterSettings.Copies = 1
        m_pDoc.PrinterSettings.PrinterName = My.Settings.CardPrinter
    End Sub

    Private Sub m_pDoc_PrintPage(ByVal sender As System.Object, ByVal e As PrintPageEventArgs) Handles m_pDoc.PrintPage
        Try
            'e.Graphics.PageUnit = GraphicsUnit.Pixel

            Select Case _CardProfileID
                Case DataKeysEnum.CardProfileID.OPLUS, DataKeysEnum.CardProfileID.VISA
                    'SharedFunction.ShowMessage(_CardProfileID.ToString)

                    Dim dBlack As New SolidBrush(Color.Black)

                    Dim DAL As New DAL_UBP_EcardMgr
                    If DAL.SelectRelCardProfileProperty(_CardProfileID) Then
                        If DAL.TableResult.DefaultView.Count > 0 Then
                            Dim dt As DataTable = DAL.TableResult
                            Dim rw As DataRow

                            If _IsPrintPhoto Then
                                If dt.Select("PropertyName='Photo'").Length > 0 Then
                                    rw = dt.Select("PropertyName='Photo'")(0)
                                    e.Graphics.DrawImage(imgPhoto, rw("PositionLeft"), rw("PositionTop"), rw("ImageWidth"), rw("ImageHeight"))
                                End If
                            End If

                            If dt.Select("PropertyName='CardName'").Length > 0 Then
                                rw = dt.Select("PropertyName='CardName'")(0)
                                e.Graphics.DrawString(_CardName, New Font(rw("Font").ToString.Trim, rw("Size"), FontStyle.Bold), dBlack, rw("PositionLeft"), rw("PositionTop"))
                            End If

                            If dt.Select("PropertyName='CardGSIS'").Length > 0 Then
                                rw = dt.Select("PropertyName='CardGSIS'")(0)
                                e.Graphics.DrawString(_GSISNo, New Font(rw("Font").ToString.Trim, rw("Size"), FontStyle.Bold), dBlack, rw("PositionLeft"), rw("PositionTop"))
                            End If

                            'Dim fontHightlight As New Font("Arial", 10.5, FontStyle.Bold)
                            'Dim fontGeneric As New Font("Arial", 7.5)                            

                            e.HasMorePages = _IsHasMorePages
                        End If
                    End If
                    DAL.Dispose()
                    DAL = Nothing

                    'SharedFunction.ShowInfoMessage("Done")
            End Select
        Catch ex As Exception
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & String.Format("PrintPage(): CardName {0}, GSIS#{1}. Runtime error catched " & ex.Message, _CardName, _GSISNo))
            SharedFunction.ShowErrorMessage(String.Format("PrintPage(): CardName {0}, GSIS#{1}. Runtime error catched " & ex.Message, _CardName, _GSISNo))
        End Try
    End Sub

    Public Sub Print()
        m_pDoc.Print()
    End Sub

    Public Sub Preview()
        Try
            Dim ppDlg As New PrintPreviewDialog()
            ppDlg.Document = m_pDoc
            ppDlg.Show()
        Catch ex As Exception
            SharedFunction.ShowErrorMessage(ex.Message)
        End Try
    End Sub

#End Region

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
                imgPhoto.Dispose()
            End If

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class

