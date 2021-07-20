<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsddbCIR = New System.Windows.Forms.ToolStripButton()
        Me.tssCIR = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddbProcess = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApprovalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssProcess = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddbCard = New System.Windows.Forms.ToolStripDropDownButton()
        Me.InventoryToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpoiledToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssCard = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddbReport = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TransactionToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpoiledToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvailableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransmittalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssReport = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddbAdministration = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ProfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssAdmin = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddbSystemAdmin = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tssSystemAdmin = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddbProfile = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslUserVariable = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslLastActivity = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbLoader = New System.Windows.Forms.PictureBox()
        Me.gridTxn = New System.Windows.Forms.DataGridView()
        Me.DatePost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.gridSpoiled = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbRefreshCardTxn = New System.Windows.Forms.LinkLabel()
        Me.lbRefreshSpoiled = New System.Windows.Forms.LinkLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.pbLoader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridTxn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridSpoiled, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1052, 69)
        Me.Panel1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsddbCIR, Me.tssCIR, Me.tsddbProcess, Me.tssProcess, Me.tsddbCard, Me.tssCard, Me.tsddbReport, Me.tssReport, Me.tsddbAdministration, Me.tssAdmin, Me.tsddbSystemAdmin, Me.tssSystemAdmin, Me.tsddbProfile})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 69)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1052, 39)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsddbCIR
        '
        Me.tsddbCIR.Image = CType(resources.GetObject("tsddbCIR.Image"), System.Drawing.Image)
        Me.tsddbCIR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsddbCIR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddbCIR.Name = "tsddbCIR"
        Me.tsddbCIR.Size = New System.Drawing.Size(80, 36)
        Me.tsddbCIR.Text = "CIR"
        '
        'tssCIR
        '
        Me.tssCIR.Name = "tssCIR"
        Me.tssCIR.Size = New System.Drawing.Size(6, 39)
        '
        'tsddbProcess
        '
        Me.tsddbProcess.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransactionToolStripMenuItem, Me.RequestToolStripMenuItem, Me.ApprovalToolStripMenuItem})
        Me.tsddbProcess.Image = CType(resources.GetObject("tsddbProcess.Image"), System.Drawing.Image)
        Me.tsddbProcess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsddbProcess.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddbProcess.Name = "tsddbProcess"
        Me.tsddbProcess.Size = New System.Drawing.Size(127, 36)
        Me.tsddbProcess.Text = "Process"
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewToolStripMenuItem, Me.ListToolStripMenuItem})
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(181, 28)
        Me.TransactionToolStripMenuItem.Text = "Transaction"
        '
        'AddNewToolStripMenuItem
        '
        Me.AddNewToolStripMenuItem.Name = "AddNewToolStripMenuItem"
        Me.AddNewToolStripMenuItem.Size = New System.Drawing.Size(160, 28)
        Me.AddNewToolStripMenuItem.Text = "Add New"
        '
        'ListToolStripMenuItem
        '
        Me.ListToolStripMenuItem.Name = "ListToolStripMenuItem"
        Me.ListToolStripMenuItem.Size = New System.Drawing.Size(160, 28)
        Me.ListToolStripMenuItem.Text = "List"
        '
        'RequestToolStripMenuItem
        '
        Me.RequestToolStripMenuItem.Name = "RequestToolStripMenuItem"
        Me.RequestToolStripMenuItem.Size = New System.Drawing.Size(181, 28)
        Me.RequestToolStripMenuItem.Text = "Request"
        Me.RequestToolStripMenuItem.Visible = False
        '
        'ApprovalToolStripMenuItem
        '
        Me.ApprovalToolStripMenuItem.Name = "ApprovalToolStripMenuItem"
        Me.ApprovalToolStripMenuItem.Size = New System.Drawing.Size(181, 28)
        Me.ApprovalToolStripMenuItem.Text = "Approval"
        Me.ApprovalToolStripMenuItem.Visible = False
        '
        'tssProcess
        '
        Me.tssProcess.Name = "tssProcess"
        Me.tssProcess.Size = New System.Drawing.Size(6, 39)
        '
        'tsddbCard
        '
        Me.tsddbCard.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventoryToolStripMenuItem1, Me.SpoiledToolStripMenuItem1})
        Me.tsddbCard.Image = CType(resources.GetObject("tsddbCard.Image"), System.Drawing.Image)
        Me.tsddbCard.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsddbCard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddbCard.Name = "tsddbCard"
        Me.tsddbCard.Size = New System.Drawing.Size(98, 36)
        Me.tsddbCard.Text = "Card"
        '
        'InventoryToolStripMenuItem1
        '
        Me.InventoryToolStripMenuItem1.Name = "InventoryToolStripMenuItem1"
        Me.InventoryToolStripMenuItem1.Size = New System.Drawing.Size(160, 28)
        Me.InventoryToolStripMenuItem1.Text = "Inventory"
        '
        'SpoiledToolStripMenuItem1
        '
        Me.SpoiledToolStripMenuItem1.Name = "SpoiledToolStripMenuItem1"
        Me.SpoiledToolStripMenuItem1.Size = New System.Drawing.Size(160, 28)
        Me.SpoiledToolStripMenuItem1.Text = "Spoiled"
        '
        'tssCard
        '
        Me.tssCard.Name = "tssCard"
        Me.tssCard.Size = New System.Drawing.Size(6, 39)
        '
        'tsddbReport
        '
        Me.tsddbReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransactionToolStripMenuItem1, Me.InventoryToolStripMenuItem, Me.TransmittalToolStripMenuItem, Me.MFToolStripMenuItem})
        Me.tsddbReport.Image = CType(resources.GetObject("tsddbReport.Image"), System.Drawing.Image)
        Me.tsddbReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsddbReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddbReport.Name = "tsddbReport"
        Me.tsddbReport.Size = New System.Drawing.Size(115, 36)
        Me.tsddbReport.Text = "Report"
        '
        'TransactionToolStripMenuItem1
        '
        Me.TransactionToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransactionToolStripMenuItem2, Me.SpoiledToolStripMenuItem})
        Me.TransactionToolStripMenuItem1.Name = "TransactionToolStripMenuItem1"
        Me.TransactionToolStripMenuItem1.Size = New System.Drawing.Size(181, 28)
        Me.TransactionToolStripMenuItem1.Text = "Transaction"
        '
        'TransactionToolStripMenuItem2
        '
        Me.TransactionToolStripMenuItem2.Name = "TransactionToolStripMenuItem2"
        Me.TransactionToolStripMenuItem2.Size = New System.Drawing.Size(181, 28)
        Me.TransactionToolStripMenuItem2.Text = "Transaction"
        '
        'SpoiledToolStripMenuItem
        '
        Me.SpoiledToolStripMenuItem.Name = "SpoiledToolStripMenuItem"
        Me.SpoiledToolStripMenuItem.Size = New System.Drawing.Size(181, 28)
        Me.SpoiledToolStripMenuItem.Text = "Spoiled"
        '
        'InventoryToolStripMenuItem
        '
        Me.InventoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AvailableToolStripMenuItem, Me.AssignedToolStripMenuItem})
        Me.InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        Me.InventoryToolStripMenuItem.Size = New System.Drawing.Size(181, 28)
        Me.InventoryToolStripMenuItem.Text = "Inventory"
        '
        'AvailableToolStripMenuItem
        '
        Me.AvailableToolStripMenuItem.Name = "AvailableToolStripMenuItem"
        Me.AvailableToolStripMenuItem.Size = New System.Drawing.Size(160, 28)
        Me.AvailableToolStripMenuItem.Text = "Available"
        '
        'AssignedToolStripMenuItem
        '
        Me.AssignedToolStripMenuItem.Name = "AssignedToolStripMenuItem"
        Me.AssignedToolStripMenuItem.Size = New System.Drawing.Size(160, 28)
        Me.AssignedToolStripMenuItem.Text = "Assigned"
        '
        'TransmittalToolStripMenuItem
        '
        Me.TransmittalToolStripMenuItem.Name = "TransmittalToolStripMenuItem"
        Me.TransmittalToolStripMenuItem.Size = New System.Drawing.Size(181, 28)
        Me.TransmittalToolStripMenuItem.Text = "Transmittal"
        '
        'MFToolStripMenuItem
        '
        Me.MFToolStripMenuItem.Name = "MFToolStripMenuItem"
        Me.MFToolStripMenuItem.Size = New System.Drawing.Size(181, 28)
        Me.MFToolStripMenuItem.Text = "MF"
        '
        'tssReport
        '
        Me.tssReport.Name = "tssReport"
        Me.tssReport.Size = New System.Drawing.Size(6, 39)
        '
        'tsddbAdministration
        '
        Me.tsddbAdministration.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProfileToolStripMenuItem, Me.SystemToolStripMenuItem, Me.LogToolStripMenuItem, Me.BackupToolStripMenuItem})
        Me.tsddbAdministration.Image = CType(resources.GetObject("tsddbAdministration.Image"), System.Drawing.Image)
        Me.tsddbAdministration.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsddbAdministration.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddbAdministration.Name = "tsddbAdministration"
        Me.tsddbAdministration.Size = New System.Drawing.Size(178, 36)
        Me.tsddbAdministration.Text = "Administration"
        '
        'ProfileToolStripMenuItem
        '
        Me.ProfileToolStripMenuItem.Name = "ProfileToolStripMenuItem"
        Me.ProfileToolStripMenuItem.Size = New System.Drawing.Size(238, 28)
        Me.ProfileToolStripMenuItem.Text = "Card Profile"
        '
        'SystemToolStripMenuItem
        '
        Me.SystemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserToolStripMenuItem, Me.RoleToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem"
        Me.SystemToolStripMenuItem.Size = New System.Drawing.Size(238, 28)
        Me.SystemToolStripMenuItem.Text = "System"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(151, 28)
        Me.UserToolStripMenuItem.Text = "User"
        '
        'RoleToolStripMenuItem
        '
        Me.RoleToolStripMenuItem.Name = "RoleToolStripMenuItem"
        Me.RoleToolStripMenuItem.Size = New System.Drawing.Size(151, 28)
        Me.RoleToolStripMenuItem.Text = "Role"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(151, 28)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'LogToolStripMenuItem
        '
        Me.LogToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ErrorToolStripMenuItem, Me.SystemToolStripMenuItem1})
        Me.LogToolStripMenuItem.Name = "LogToolStripMenuItem"
        Me.LogToolStripMenuItem.Size = New System.Drawing.Size(238, 28)
        Me.LogToolStripMenuItem.Text = "Log"
        '
        'ErrorToolStripMenuItem
        '
        Me.ErrorToolStripMenuItem.Name = "ErrorToolStripMenuItem"
        Me.ErrorToolStripMenuItem.Size = New System.Drawing.Size(146, 28)
        Me.ErrorToolStripMenuItem.Text = "Error"
        '
        'SystemToolStripMenuItem1
        '
        Me.SystemToolStripMenuItem1.Name = "SystemToolStripMenuItem1"
        Me.SystemToolStripMenuItem1.Size = New System.Drawing.Size(146, 28)
        Me.SystemToolStripMenuItem1.Text = "System"
        '
        'tssAdmin
        '
        Me.tssAdmin.Name = "tssAdmin"
        Me.tssAdmin.Size = New System.Drawing.Size(6, 39)
        '
        'tsddbSystemAdmin
        '
        Me.tsddbSystemAdmin.Image = CType(resources.GetObject("tsddbSystemAdmin.Image"), System.Drawing.Image)
        Me.tsddbSystemAdmin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsddbSystemAdmin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddbSystemAdmin.Name = "tsddbSystemAdmin"
        Me.tsddbSystemAdmin.Size = New System.Drawing.Size(249, 36)
        Me.tsddbSystemAdmin.Text = "System Administration"
        '
        'tssSystemAdmin
        '
        Me.tssSystemAdmin.Name = "tssSystemAdmin"
        Me.tssSystemAdmin.Size = New System.Drawing.Size(6, 39)
        '
        'tsddbProfile
        '
        Me.tsddbProfile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordToolStripMenuItem, Me.LogoutToolStripMenuItem})
        Me.tsddbProfile.Image = CType(resources.GetObject("tsddbProfile.Image"), System.Drawing.Image)
        Me.tsddbProfile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsddbProfile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddbProfile.Name = "tsddbProfile"
        Me.tsddbProfile.Size = New System.Drawing.Size(111, 36)
        Me.tsddbProfile.Text = "Profile"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(239, 28)
        Me.ChangePasswordToolStripMenuItem.Text = "Change password"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(239, 28)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslUserVariable, Me.tsslLastActivity})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 700)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1052, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslUserVariable
        '
        Me.tsslUserVariable.Name = "tsslUserVariable"
        Me.tsslUserVariable.Size = New System.Drawing.Size(79, 17)
        Me.tsslUserVariable.Text = "User Variables"
        '
        'tsslLastActivity
        '
        Me.tsslLastActivity.Name = "tsslLastActivity"
        Me.tsslLastActivity.Size = New System.Drawing.Size(93, 17)
        Me.tsslLastActivity.Text = "Last Activity: <>"
        '
        'pbLoader
        '
        Me.pbLoader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbLoader.BackColor = System.Drawing.Color.White
        Me.pbLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbLoader.Location = New System.Drawing.Point(1018, 73)
        Me.pbLoader.Name = "pbLoader"
        Me.pbLoader.Size = New System.Drawing.Size(30, 30)
        Me.pbLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbLoader.TabIndex = 4
        Me.pbLoader.TabStop = False
        '
        'gridTxn
        '
        Me.gridTxn.AllowUserToAddRows = False
        Me.gridTxn.AllowUserToDeleteRows = False
        Me.gridTxn.BackgroundColor = System.Drawing.Color.White
        Me.gridTxn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridTxn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DatePost, Me.Qty})
        Me.gridTxn.Location = New System.Drawing.Point(17, 186)
        Me.gridTxn.Name = "gridTxn"
        Me.gridTxn.ReadOnly = True
        Me.gridTxn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridTxn.Size = New System.Drawing.Size(335, 227)
        Me.gridTxn.TabIndex = 6
        '
        'DatePost
        '
        Me.DatePost.DataPropertyName = "DatePost"
        Me.DatePost.HeaderText = "DATE"
        Me.DatePost.Name = "DatePost"
        Me.DatePost.ReadOnly = True
        Me.DatePost.Width = 150
        '
        'Qty
        '
        Me.Qty.DataPropertyName = "Qty"
        Me.Qty.HeaderText = "TOTAL"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.White
        Me.lblDate.Location = New System.Drawing.Point(12, 121)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(63, 23)
        Me.lblDate.TabIndex = 7
        Me.lblDate.Text = "Today"
        '
        'gridSpoiled
        '
        Me.gridSpoiled.AllowUserToAddRows = False
        Me.gridSpoiled.AllowUserToDeleteRows = False
        Me.gridSpoiled.BackgroundColor = System.Drawing.Color.White
        Me.gridSpoiled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridSpoiled.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.gridSpoiled.Location = New System.Drawing.Point(358, 186)
        Me.gridSpoiled.Name = "gridSpoiled"
        Me.gridSpoiled.ReadOnly = True
        Me.gridSpoiled.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridSpoiled.Size = New System.Drawing.Size(335, 227)
        Me.gridSpoiled.TabIndex = 8
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DatePost"
        Me.DataGridViewTextBoxColumn1.HeaderText = "DATE"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Qty"
        Me.DataGridViewTextBoxColumn2.HeaderText = "TOTAL"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(14, 165)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(252, 18)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Summary of Issued Cards (Weekly)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(355, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(261, 18)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Summary of Spoiled Cards (Weekly)"
        '
        'lbRefreshCardTxn
        '
        Me.lbRefreshCardTxn.AutoSize = True
        Me.lbRefreshCardTxn.BackColor = System.Drawing.Color.Transparent
        Me.lbRefreshCardTxn.Location = New System.Drawing.Point(306, 169)
        Me.lbRefreshCardTxn.Name = "lbRefreshCardTxn"
        Me.lbRefreshCardTxn.Size = New System.Drawing.Size(46, 14)
        Me.lbRefreshCardTxn.TabIndex = 10
        Me.lbRefreshCardTxn.TabStop = True
        Me.lbRefreshCardTxn.Text = "Refresh"
        '
        'lbRefreshSpoiled
        '
        Me.lbRefreshSpoiled.AutoSize = True
        Me.lbRefreshSpoiled.BackColor = System.Drawing.Color.Transparent
        Me.lbRefreshSpoiled.Location = New System.Drawing.Point(647, 169)
        Me.lbRefreshSpoiled.Name = "lbRefreshSpoiled"
        Me.lbRefreshSpoiled.Size = New System.Drawing.Size(46, 14)
        Me.lbRefreshSpoiled.TabIndex = 10
        Me.lbRefreshSpoiled.TabStop = True
        Me.lbRefreshSpoiled.Text = "Refresh"
        '
        'Timer1
        '
        Me.Timer1.Interval = 30000
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(238, 28)
        Me.BackupToolStripMenuItem.Text = "Backup EcardMgr"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 722)
        Me.Controls.Add(Me.lbRefreshSpoiled)
        Me.Controls.Add(Me.lbRefreshCardTxn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gridSpoiled)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.gridTxn)
        Me.Controls.Add(Me.pbLoader)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UNION BANK - ECARD PRINTING MANAGER v1.0"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.pbLoader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridTxn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridSpoiled, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsddbProcess As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsddbReport As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsddbAdministration As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsddbSystemAdmin As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents InventoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AvailableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProfileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RequestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApprovalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslUserVariable As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsddbProfile As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsddbCard As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tssProcess As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tssCard As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tssReport As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tssAdmin As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tssSystemAdmin As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsddbCIR As System.Windows.Forms.ToolStripButton
    Friend WithEvents InventoryToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpoiledToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransmittalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RoleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tssCIR As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbLoader As System.Windows.Forms.PictureBox
    Friend WithEvents gridTxn As System.Windows.Forms.DataGridView
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents DatePost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gridSpoiled As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbRefreshCardTxn As System.Windows.Forms.LinkLabel
    Friend WithEvents lbRefreshSpoiled As System.Windows.Forms.LinkLabel
    Friend WithEvents TransactionToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpoiledToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsslLastActivity As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BackupToolStripMenuItem As ToolStripMenuItem
End Class
