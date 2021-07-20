
Public Class SharedFunction

    Const MsgHeader = "eCard Manager Printing"

    Public Shared ReadOnly CardProfileRepository As String = "CardProfile"
    Public Shared ReadOnly ImagesRepository As String = "Images"

    Public Shared ReadOnly SuccessColor As Color = Color.LightGreen
    Public Shared ReadOnly ErrorColor As Color = Color.OrangeRed

    Public Shared ReadOnly LoadingImage As String = "Images\loading.gif"

    Public Shared ReadOnly CardType_OPLUS As String = "OPLUS"
    Public Shared ReadOnly CardType_VISA As String = "VISA"

    Public Shared CardProdType As String

    Public Shared ReportTime As Date

    Public Delegate Sub Action()

    Public Shared Function ShowMessage(ByVal strMsg As String, Optional ByVal msgBoxBtn As MessageBoxButtons = MessageBoxButtons.YesNo, Optional ByVal msgBoxIcn As MessageBoxIcon = MessageBoxIcon.Question) As DialogResult
        Return MessageBox.Show(strMsg, MsgHeader, msgBoxBtn, msgBoxIcn)
    End Function

    Public Shared Function ShowInfoMessage(ByVal strMsg As String, Optional ByVal msgBoxBtn As MessageBoxButtons = MessageBoxButtons.OK) As DialogResult
        Return MessageBox.Show(strMsg, MsgHeader, msgBoxBtn, MessageBoxIcon.Information)
    End Function

    Public Shared Function ShowErrorMessage(ByVal strMsg As String, Optional ByVal msgBoxBtn As MessageBoxButtons = MessageBoxButtons.OK) As DialogResult
        Return MessageBox.Show(strMsg, MsgHeader, msgBoxBtn, MessageBoxIcon.Error)
    End Function

    Public Shared Sub HouseKeeping()
        Try
            'If IO.Directory.Exists("Temp") Then IO.Directory.Delete("Temp", True)
            For Each strFile In IO.Directory.GetFiles("Temp")
                IO.File.Delete(strFile)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function CheckIfCardNoExist(ByVal Card_No As String) As Boolean
        Dim DAL As New DAL_UBP_EcardMgr
        Try
            If DAL.ExecuteScalar(String.Format("SELECT COUNT(Card_No) FROM tblCardInventory WHERE Card_No='{0}'", Card_No)) Then
                If CShort(DAL.ObjectResult) = 0 Then
                    Return False
                Else
                    Return True
                End If
            End If
        Catch ex As Exception
            Return False
        Finally
            DAL.Dispose()
            DAL = Nothing
        End Try
    End Function

    Public Shared Function CheckIfMagstripeExist(ByVal Magstripe As String, ByRef CardInvID As Integer) As Boolean
        Dim DAL As New DAL_UBP_EcardMgr
        Try
            If DAL.ExecuteScalar(String.Format("SELECT ISNULL(CardInvID,0) As CardInvID FROM tblCardInventory WHERE Mastripe='{0}' AND IsSpoiled=0", Magstripe)) Then
                CardInvID = CInt(DAL.ObjectResult)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            DAL.Dispose()
            DAL = Nothing
        End Try
    End Function

    Public Shared Sub ShowForm(ByVal _frm As Form, Optional IsShowAsDialog As Boolean = True)
        SharedFunction.ReportToApp()
        If Not IsShowAsDialog Then
            _frm.Show()
        Else
            _frm.ShowDialog()
        End If
    End Sub

    Public Shared Sub ErrorProvider(ByVal ctrl As Control, ByVal _errorMsg As String, ByRef _errorProvider As ErrorProvider)
        If TypeOf ctrl Is TextBox Then
            If CType(ctrl, TextBox).Text = "" Then
                _errorProvider.SetError(ctrl, _errorMsg)
            Else
                _errorProvider.SetError(ctrl, "")
            End If
        ElseIf TypeOf ctrl Is ComboBox Then
            If CType(ctrl, ComboBox).SelectedIndex = 0 Then
                _errorProvider.SetError(ctrl, _errorMsg)
            Else
                _errorProvider.SetError(ctrl, "")
            End If
        End If
    End Sub

    Public Shared Function CompleteName(ByVal FName As String, ByVal MName As String, ByVal LName As String) As String
        Return String.Format("{0}{1}{2}", FName, IIf(Trim(MName) = "", " ", " " & MName & " "), LName)
    End Function

    Public Shared Function CompleteName2(ByVal FName As String, ByVal MName As String, ByVal LName As String) As String
        Return String.Format("{0}{1}{2}", FName, IIf(Trim(MName) = "", " ", " " & MName.Substring(0, 1) & ". "), LName)
    End Function

    Public Shared Function ValidateControl(ByRef errorProvider1 As ErrorProvider, ParamArray ctrls As Control()) As Boolean
        Dim bln As Boolean = True
        For Each ctrl As Control In ctrls
            If TypeOf ctrl Is TextBox Then
                If DirectCast(ctrl, TextBox).Text = "" Then
                    errorProvider1.SetError(ctrl, "Enter value here")
                    bln = False
                Else
                    errorProvider1.SetError(ctrl, String.Empty)
                End If
            ElseIf TypeOf ctrl Is ComboBox Then
                If DirectCast(ctrl, ComboBox).Text = "" Then
                    errorProvider1.SetError(ctrl, "Select value here")
                    bln = False
                Else
                    errorProvider1.SetError(ctrl, String.Empty)
                End If
            ElseIf TypeOf ctrl Is MaskedTextBox Then
                If DirectCast(ctrl, MaskedTextBox).Text = "" Then
                    errorProvider1.SetError(ctrl, "Enter value here")
                    bln = False
                ElseIf DirectCast(ctrl, MaskedTextBox).Text = "  /  /" Then
                    errorProvider1.SetError(ctrl, "Enter value here")
                    bln = False
                Else
                    errorProvider1.SetError(ctrl, String.Empty)
                End If

            End If
        Next

        Return bln
    End Function

    Public Shared Sub PopulateRoles(ByRef cbo As ComboBox)
        Dim DAL As New DAL_UBP_EcardMgr
        If DAL.SelectQuery("SELECT RoleID, RoleDesc FROM tblRole") Then
            cbo.DataSource = DAL.TableResult
            cbo.ValueMember = "RoleID"
            cbo.DisplayMember = "RoleDesc"
            If cbo.Items.Count > 0 Then cbo.Text = "-Select Item-"
        Else
            cbo.Text = "Unable to populate data"
        End If
        DAL.Dispose()
        DAL = Nothing
    End Sub

    Public Shared Sub PopulateCBO(ByVal TableName As String, ByVal ValueMember As String, ByVal DisplayMember As String, ByRef cbo As ComboBox)
        Dim DAL As New DAL_UBP_EcardMgr
        If DAL.SelectQuery(String.Format("SELECT 0 As " & ValueMember & " , '-Select Item-' As " & DisplayMember & " UNION ALL SELECT {1} As " & ValueMember & ", {2} As " & DisplayMember & " FROM {0}", TableName, ValueMember, DisplayMember)) Then
            cbo.DataSource = DAL.TableResult
            cbo.ValueMember = ValueMember
            cbo.DisplayMember = DisplayMember
            'If cbo.Items.Count > 0 Then cbo.Text = "-Select Item-"
        Else
            MessageBox.Show(DAL.ErrorMessage)
        End If
        DAL.Dispose()
        DAL = Nothing
    End Sub

    Public Shared Sub ShowMainLoader()
        Main.ShowLoader()
    End Sub

    Public Shared Sub DisposeMainLoader()
        Main.DisposeLoader()
    End Sub

    Public Shared Function GetRoleDesc(ByVal dt As DataTable, Optional IsAll As Boolean = False) As String
        Dim sb As New System.Text.StringBuilder
        For Each rw As DataRow In dt.Rows
            If sb.ToString = "" Then
                If IsAll Then
                    sb.Append(rw("RoleDesc").ToString.Trim)
                Else
                    If CBool(rw("IsSelected")) Then sb.Append(rw("RoleDesc").ToString.Trim)
                End If
            Else
                If IsAll Then
                    sb.Append("; " & rw("RoleDesc").ToString.Trim)
                Else
                    If CBool(rw("IsSelected")) Then sb.Append("; " & rw("RoleDesc").ToString.Trim)
                End If
            End If
        Next

        Return sb.ToString
    End Function

    Public Shared Sub ControlDisposition(ByVal bln As Boolean, ByVal crsr As Cursor, _
                                         ByVal CursorOnly As Boolean,
                                         ByVal ParamArray ctrls() As Control)
        If Not CursorOnly Then
            For Each ctrl As Control In ctrls
                If TypeOf ctrl Is PictureBox Then
                ElseIf TypeOf ctrl Is Label Then
                Else
                    ctrl.Enabled = bln
                End If
            Next
        End If

        crsr = IIf(bln, Cursors.Default, Cursors.WaitCursor)
    End Sub

    Public Shared Sub ClearMainFormExistingForm()
        Main._frmExisting = Nothing
    End Sub

    Public Shared Sub SaveToUserVariable(ByVal UserID As Integer, ByVal Username As String, ByVal CompleteName As String, ByVal RoleID As String, ByVal RoleDesc As String, ByVal LogIN_Time As String, ByVal LoggedUserID As Integer)
        My.Settings.UserVariables = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", UserID, Username, CompleteName, RoleID, RoleDesc, LogIN_Time, LoggedUserID)
        My.Settings.Save()
    End Sub

    Public Shared Function UserID() As Integer
        Return My.Settings.UserVariables.Split("|")(0)
    End Function

    Public Shared Function Username() As String
        Return My.Settings.UserVariables.Split("|")(1)
    End Function

    Public Shared Function CompleteName() As String
        Return My.Settings.UserVariables.Split("|")(2)
    End Function

    Public Shared Function UserRoleID() As Integer
        Return My.Settings.UserVariables.Split("|")(3)
    End Function

    Public Shared Function UserRoleDesc() As String
        Return My.Settings.UserVariables.Split("|")(4)
    End Function

    Public Shared Function LogIN_Time() As String
        Return My.Settings.UserVariables.Split("|")(5)
    End Function

    Public Shared Function LoggedUserID() As String
        Return My.Settings.UserVariables.Split("|")(6)
    End Function

    Public Shared Sub LogOut()
        Dim DAL As New DAL_UBP_EcardMgr
        DAL.ExecuteQuery("DELETE FROM tblLoggedUsers WHERE UserID=" & UserID())
        DAL.AddSystemLog(String.Format("{0} has logged out", SharedFunction.CompleteName), "LogOut", UserID)
        DAL.Dispose()
        DAL = Nothing
    End Sub

    Public Shared Sub ForceLogOut(ByVal intUserID As Integer)
        Dim DAL As New DAL_UBP_EcardMgr
        DAL.ExecuteQuery("DELETE FROM tblLoggedUsers WHERE UserID=" & intUserID)
        DAL.AddSystemLog(String.Format("{0} was forced logged out", SharedFunction.CompleteName), "LogOut", 0)
        DAL.Dispose()
        DAL = Nothing
    End Sub

    Public Shared Function ValidateLogIN(ByVal WhereCriteria As String, ByVal _Password As String, ByRef lblResult As Label, Optional ByRef rw As DataRow = Nothing) As Boolean
        Dim DAL As New DAL_UBP_EcardMgr
        Try
            If DAL.ValidateLogIn(WhereCriteria) Then
                If DAL.TableResult.DefaultView.Count > 0 Then
                    rw = DAL.TableResult.Rows(0)
                    If rw("Password").ToString.Trim <> EncryptDecrypt.EncryptData(_Password) Then
                        lblResult.Text = "Invalid credential"
                        lblResult.ForeColor = ErrorColor
                    ElseIf String.IsNullOrEmpty(rw("RoleID")) Then
                        lblResult.Text = "User have no assigned role. Please contact Administrator."
                        lblResult.ForeColor = ErrorColor
                    Else
                        Return True
                    End If
                Else
                    lblResult.Text = "Invalid credential"
                    lblResult.ForeColor = ErrorColor

                    Return False
                End If
            Else
                SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "ValidateLogIn(): " & DAL.ErrorMessage)
                lblResult.Text = "Login error occurred"
                lblResult.ForeColor = ErrorColor

                Return False
            End If
        Catch ex As Exception
            SharedFunction.SaveToErrorLog(SharedFunction.TimeStamp & "ValidateLogIn(): Runtime error occurred " & ex.Message)
            lblResult.Text = "Runtime error occurred"
            lblResult.ForeColor = ErrorColor

            Return False
        Finally
            DAL.Dispose()
            DAL = Nothing
        End Try
    End Function

    Public Shared Sub ShowLoader(ByRef pbLoader As PictureBox)
        Try
            pbLoader.Image = Image.FromFile(SharedFunction.LoadingImage)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub DisposeLoader(ByRef pbLoader As PictureBox)
        Try
            pbLoader.Image = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub PrintCard(ByVal CardName As String, ByVal GSISNo As String, ByVal picByte As Byte(), ByVal CardProdType As String, _
                                ByVal IsCardPreviewOnly As Boolean, ByVal IsPrintPhoto As Boolean)
        Try
            If My.Settings.CardPrinter = "" Then
                SharedFunction.ShowErrorMessage("No card printer is set")
            Else
                Dim printcard As New PrintCard()

                printcard.CardProfileID = GetCardProdTypeID(CardProdType)
                printcard.CardName = CardName
                printcard.GSISNo = GSISNo
                printcard.IsPrintPhoto = IsPrintPhoto

                printcard.Photo = Image.FromStream(New IO.MemoryStream(picByte))
                'printcard.Photo = Image.FromStream(New IO.MemoryStream(IO.File.ReadAllBytes("D:\1.jpg")))
                'printcard.Print()
                If IsCardPreviewOnly Then
                    printcard.Preview()
                Else
                    printcard.Print()
                End If

                'printcard.Dispose()
                'printcard = Nothing
            End If
        Catch ex As Exception
            SharedFunction.ShowErrorMessage(ex.Message)
        End Try

    End Sub

    Public Shared Function CardTypeDescription(ByVal CardTypeID As DataKeysEnum.CardTypeID) As String
        Select Case CardTypeID
            Case DataKeysEnum.CardTypeID.Renewal
                Return "Renewal"
            Case DataKeysEnum.CardTypeID.Active
                Return "Active"
            Case DataKeysEnum.CardTypeID.Employee
                Return "Employee"
            Case DataKeysEnum.CardTypeID.Pensioner
                Return "Pensioner"
            Case DataKeysEnum.CardTypeID.Survivor
                Return "Survivor"
            Case DataKeysEnum.CardTypeID.Replacement
                Return "Replacement"
        End Select
    End Function

    Public Shared Sub txtBox_DoubleClick(sender As System.Object, e As System.EventArgs)
        CType(sender, TextBox).SelectAll()
        CType(sender, TextBox).Focus()
    End Sub

    Public Shared Function GetCardProdTypeID(ByVal CardProdType As String) As Integer
        If CardProdType = SharedFunction.CardType_OPLUS Then
            Return DataKeysEnum.CardProfileID.OPLUS
        ElseIf CardProdType = SharedFunction.CardType_VISA Then
            Return DataKeysEnum.CardProfileID.VISA
        End If
    End Function

    Public Shared Sub ReportToApp()
        ReportTime = Now
        Main.tsslLastActivity.Text = "   |   Last Activity: " & ReportTime
    End Sub

    Public Shared Function GetLoggedUserID(ByVal intUserID As Integer) As Integer
        Dim intLoggedUserID As Integer = 0

        Dim DAL As New DAL_UBP_EcardMgr
        If DAL.SelectQuery("SELECT LoggedUserID FROM tblLoggedUsers WHERE UserID=" & intUserID.ToString.Trim) Then
            If DAL.TableResult.DefaultView.Count > 0 Then
                intLoggedUserID = DAL.TableResult.Rows(0)(0)
            End If
        End If
        DAL.Dispose()
        DAL = Nothing

        Return intLoggedUserID
    End Function


#Region " Logs "

    Private Shared SystemLog As String = "Logs\" & Now.ToString("MMddyyyy") & "\System.log"
    Private Shared ErrorLog As String = "Logs\" & Now.ToString("MMddyyyy") & "\Error.log"

    Private Shared Sub InitLogFolder()
        If Not IO.Directory.Exists("Logs\" & Now.ToString("MMddyyyy")) Then IO.Directory.CreateDirectory("Logs\" & Now.ToString("MMddyyyy"))
    End Sub

    Public Shared Sub SaveToLog(ByVal strData As String)
        Try
            InitLogFolder()
            Dim sw As New IO.StreamWriter(SystemLog, True)
            sw.WriteLine(strData)
            sw.Dispose()
            sw.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub SaveToErrorLog(ByVal strData As String)
        Try
            InitLogFolder()
            Dim sw As New IO.StreamWriter(ErrorLog, True)
            sw.WriteLine(strData)
            sw.Dispose()
            sw.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function TimeStamp() As String
        Return Now.ToString("MM/dd/yy hh:mm:ss tt").PadRight(25, " ")
    End Function

#End Region

End Class
