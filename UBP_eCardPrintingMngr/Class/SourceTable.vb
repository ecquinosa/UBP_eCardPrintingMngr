Public Structure SourceTable

    Public Shared Function CardTxnTable(Optional ByVal strWhereCriteria As String = "") As DataTable
        Dim DAL As New DAL_UBP_EcardMgr
        Dim dt As DataTable
        If DAL.SelectCardTxn(strWhereCriteria) Then
            dt = DAL.TableResult
        End If
        DAL.Dispose()
        DAL = Nothing

        Return dt
    End Function

    Public Shared Function CardInventoryTable(Optional ByVal strWhereCriteria As String = "") As DataTable
        Dim DAL As New DAL_UBP_EcardMgr
        Dim dt As DataTable
        'If DAL.SelectQuery(String.Format("SELECT CardInvID AS ID, Card_No AS Card#, ExpiryDate, DateTimePosted, IsSpoiled AS Spoiled, dbo.fnGetUserCompleteName(UserID) AS Operator FROM dbo.tblCardInventory {0}", strWhereCriteria)) Then
        If DAL.SelectCardInventory(strWhereCriteria) Then
            dt = DAL.TableResult
        End If
        DAL.Dispose()
        DAL = Nothing

        Return dt
    End Function

    Public Shared Function RoleTable(Optional ByVal strWhereCriteria As String = "") As DataTable
        Dim DAL As New DAL_UBP_EcardMgr
        Dim dt As DataTable
        If DAL.SelectQuery("SELECT * FROM tblRole") Then
            dt = DAL.TableResult
        End If
        DAL.Dispose()
        DAL = Nothing

        Return dt
    End Function

    Public Shared Function UserTable(Optional ByVal strWhereCriteria As String = "") As DataTable
        Dim DAL As New DAL_UBP_EcardMgr
        Dim dt As DataTable
        If DAL.SelectUser(strWhereCriteria) Then
            dt = DAL.TableResult
        End If
        DAL.Dispose()
        DAL = Nothing

        Return dt
    End Function

    Public Shared Function SpoiledTxnTable(Optional ByVal strWhereCriteria As String = "") As DataTable
        Dim DAL As New DAL_UBP_EcardMgr
        Dim dt As DataTable
        If DAL.SelectSpoiledTxn(strWhereCriteria) Then
            dt = DAL.TableResult
        End If
        DAL.Dispose()
        DAL = Nothing

        Return dt
    End Function

    Public Shared Function SystemLogTable(Optional ByVal strWhereCriteria As String = "") As DataTable
        Dim DAL As New DAL_UBP_EcardMgr
        Dim dt As DataTable
        If DAL.SelectQuery("SELECT SystemLogID, SystemLogDesc, Process, dbo.fnGetUserCompleteName(SubmittedBy_UserID) As SubmittedBy, DateTimePosted FROM dbo.tblSystemLog " & strWhereCriteria) Then
            dt = DAL.TableResult
        End If
        DAL.Dispose()
        DAL = Nothing

        Return dt
    End Function

End Structure
