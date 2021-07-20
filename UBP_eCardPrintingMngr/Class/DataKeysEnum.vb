Public Class DataKeysEnum

    Public Enum TableName
        User = 1
        Role
        Inventory
        Spoiled
        CardTxn
        SystemLog
    End Enum

    Public Enum RptName
        CardTxn_CIR_New = 1
        CardTxn_CIR_Replacement
        CardTxn_Mailing
        CardTxn_Transmittal
        CardInventory
        SpoiledTxn
    End Enum

    Public Enum Report
        AvailableInventory = 1
        CardInventory
        CardTxn_CIR_New
        CardTxn_CIR_Replacement
        CardTxn_Mailing
        CardTxn_Transmittal
        CardTxnList
        MF_Report
        SpoiledTxn
    End Enum

    Public Enum CardTypeID
        Renewal = 1
        Active
        Employee
        Pensioner
        Survivor
        Replacement
    End Enum

    Public Enum RoleID
        Viewer = 1
        CardIssuer
        Supervisor
        Admin
        SystemAdmin
    End Enum

    Public Enum CardProfileID
        OPLUS = 1
        VISA
    End Enum

End Class
