
Imports System.IO
Imports System.Text

Public Class Allcard_AFIS

    Private _DirectoryPath As String
    Private LOG_FILE As String = "ProcessLog"
    Private _DirFilesCount As Integer

    Private _NoOfProcess As Short
    Private sbLog() As StringBuilder
    Private ProcessesRange() As Integer


    Private _IsLogFileReady As Boolean = True

    Public Property DirectoryPath As String
        Get
            Return _DirectoryPath
        End Get
        Set(value As String)
            _DirectoryPath = value
        End Set
    End Property

    Public Property NoOfProcess As Short
        Get
            Return _NoOfProcess
        End Get
        Set(value As Short)
            _NoOfProcess = value
        End Set
    End Property

    Public Sub Initialize()
        'Console.Write(String.Format("sbLog length: {0}", sbLog.Length))
        'Console.Write(String.Format("ProcessesRange length: {0}", ProcessesRange.Length))

        Console.Write(String.Format("No of process: {0}", _NoOfProcess.ToString) & Environment.NewLine)

        ReDim sbLog(_NoOfProcess - 1)
        ReDim ProcessesRange(_NoOfProcess - 1)
        _DirFilesCount = Directory.GetFiles(_DirectoryPath).Length

        Console.Write(String.Format("sbLog length: {0}", sbLog.Length) & Environment.NewLine)
        Console.Write(String.Format("ProcessesRange length: {0}", ProcessesRange.Length) & Environment.NewLine)
        Console.Write(String.Format("Files count: {0}", _DirFilesCount.ToString) & Environment.NewLine)

        For i As Short = 0 To _NoOfProcess - 1
            sbLog(i) = New StringBuilder
        Next

        Dim intDistribution As Integer
        Dim strDistribution As String = (_DirFilesCount / _NoOfProcess).ToString
        Dim intBalance As Integer = 0

        If Not strDistribution.Contains(".") Then
            intDistribution = strDistribution
        Else
            intDistribution = strDistribution.Split(".")(0)
        End If

        Console.Write(String.Format("Distribution: {0}", intDistribution) & Environment.NewLine)

        Dim intTotalFiles As Integer = 0
        For i As Short = 0 To _NoOfProcess - 1
            If i <> _NoOfProcess - 1 Then
                ProcessesRange(i) = intDistribution
                intTotalFiles += intDistribution
            Else
                intBalance = _DirFilesCount - intTotalFiles
                ProcessesRange(i) = intBalance
            End If
        Next

        Console.Write(String.Format("Balance: {0}", intBalance))
        Console.Write("Complete!" & Environment.NewLine)
    End Sub

    Private Sub MatchFiles()

    End Sub

    Private Sub SaveToLog(ByVal Process As Short)
        If _IsLogFileReady Then
            Dim sw As New StreamWriter("LOG_FILE", True)
            sw.Write(sbLog(Process).ToString)
            sw.Dispose()
            sw.Close()
            sw = Nothing
        End If
    End Sub


End Class
