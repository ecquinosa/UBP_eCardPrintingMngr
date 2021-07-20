<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserRole
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.btnSetPrimary = New System.Windows.Forms.Button()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.RoleID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RoleDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblRole)
        Me.Panel1.Controls.Add(Me.btnSetPrimary)
        Me.Panel1.Controls.Add(Me.lblUser)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(499, 65)
        Me.Panel1.TabIndex = 0
        '
        'lblRole
        '
        Me.lblRole.AutoSize = True
        Me.lblRole.Location = New System.Drawing.Point(14, 37)
        Me.lblRole.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(0, 16)
        Me.lblRole.TabIndex = 5
        '
        'btnSetPrimary
        '
        Me.btnSetPrimary.Location = New System.Drawing.Point(348, 7)
        Me.btnSetPrimary.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSetPrimary.Name = "btnSetPrimary"
        Me.btnSetPrimary.Size = New System.Drawing.Size(139, 46)
        Me.btnSetPrimary.TabIndex = 4
        Me.btnSetPrimary.Text = "Set Primary Role"
        Me.btnSetPrimary.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSetPrimary.UseVisualStyleBackColor = True
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(14, 14)
        Me.lblUser.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(51, 16)
        Me.lblUser.TabIndex = 0
        Me.lblUser.Text = "Label1"
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RoleID, Me.RoleDesc, Me.IsSelected})
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Location = New System.Drawing.Point(0, 65)
        Me.grid.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.grid.Name = "grid"
        Me.grid.ReadOnly = True
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid.Size = New System.Drawing.Size(499, 333)
        Me.grid.TabIndex = 2
        '
        'RoleID
        '
        Me.RoleID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.RoleID.DataPropertyName = "RoleID"
        Me.RoleID.HeaderText = "RoleID"
        Me.RoleID.Name = "RoleID"
        Me.RoleID.ReadOnly = True
        Me.RoleID.Width = 66
        '
        'RoleDesc
        '
        Me.RoleDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.RoleDesc.DataPropertyName = "RoleDesc"
        Me.RoleDesc.HeaderText = "Role Description"
        Me.RoleDesc.Name = "RoleDesc"
        Me.RoleDesc.ReadOnly = True
        Me.RoleDesc.Width = 112
        '
        'IsSelected
        '
        Me.IsSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.IsSelected.DataPropertyName = "IsSelected"
        Me.IsSelected.HeaderText = ""
        Me.IsSelected.Name = "IsSelected"
        Me.IsSelected.ReadOnly = True
        Me.IsSelected.Width = 5
        '
        'UserRole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 398)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "UserRole"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Role"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents btnSetPrimary As System.Windows.Forms.Button
    Friend WithEvents lblRole As System.Windows.Forms.Label
    Friend WithEvents RoleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RoleDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
