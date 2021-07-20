<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setting
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabApplication = New System.Windows.Forms.TabPage()
        Me.cboCardPrinter = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDefaultPassword = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tabEcard = New System.Windows.Forms.TabPage()
        Me.btnTestConnection_eCard = New System.Windows.Forms.Button()
        Me.txtPassword_eCard = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUser_eCard = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDatabase_eCard = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtServer_eCard = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabGSIS = New System.Windows.Forms.TabPage()
        Me.txtPassword_GSIS = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnTestConnection_GSIS = New System.Windows.Forms.Button()
        Me.txtUser_GSIS = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPort_GSIS = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtServer_GSIS = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDSN_GSIS = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtIdleLimit = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tabApplication.SuspendLayout()
        Me.tabEcard.SuspendLayout()
        Me.tabGSIS.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabApplication)
        Me.TabControl1.Controls.Add(Me.tabEcard)
        Me.TabControl1.Controls.Add(Me.tabGSIS)
        Me.TabControl1.Location = New System.Drawing.Point(13, 45)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(352, 269)
        Me.TabControl1.TabIndex = 0
        '
        'tabApplication
        '
        Me.tabApplication.Controls.Add(Me.txtIdleLimit)
        Me.tabApplication.Controls.Add(Me.Label12)
        Me.tabApplication.Controls.Add(Me.cboCardPrinter)
        Me.tabApplication.Controls.Add(Me.Label11)
        Me.tabApplication.Controls.Add(Me.txtDefaultPassword)
        Me.tabApplication.Controls.Add(Me.Label10)
        Me.tabApplication.Location = New System.Drawing.Point(4, 23)
        Me.tabApplication.Name = "tabApplication"
        Me.tabApplication.Size = New System.Drawing.Size(344, 242)
        Me.tabApplication.TabIndex = 2
        Me.tabApplication.Text = "Application"
        Me.tabApplication.UseVisualStyleBackColor = True
        '
        'cboCardPrinter
        '
        Me.cboCardPrinter.FormattingEnabled = True
        Me.cboCardPrinter.Location = New System.Drawing.Point(114, 54)
        Me.cboCardPrinter.Name = "cboCardPrinter"
        Me.cboCardPrinter.Size = New System.Drawing.Size(188, 22)
        Me.cboCardPrinter.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 14)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Card Printer"
        '
        'txtDefaultPassword
        '
        Me.txtDefaultPassword.Location = New System.Drawing.Point(114, 27)
        Me.txtDefaultPassword.Name = "txtDefaultPassword"
        Me.txtDefaultPassword.Size = New System.Drawing.Size(188, 20)
        Me.txtDefaultPassword.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 14)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Default Password"
        '
        'tabEcard
        '
        Me.tabEcard.Controls.Add(Me.btnTestConnection_eCard)
        Me.tabEcard.Controls.Add(Me.txtPassword_eCard)
        Me.tabEcard.Controls.Add(Me.Label4)
        Me.tabEcard.Controls.Add(Me.txtUser_eCard)
        Me.tabEcard.Controls.Add(Me.Label3)
        Me.tabEcard.Controls.Add(Me.txtDatabase_eCard)
        Me.tabEcard.Controls.Add(Me.Label2)
        Me.tabEcard.Controls.Add(Me.txtServer_eCard)
        Me.tabEcard.Controls.Add(Me.Label1)
        Me.tabEcard.Location = New System.Drawing.Point(4, 23)
        Me.tabEcard.Name = "tabEcard"
        Me.tabEcard.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEcard.Size = New System.Drawing.Size(344, 242)
        Me.tabEcard.TabIndex = 0
        Me.tabEcard.Text = "Ecard Database"
        Me.tabEcard.UseVisualStyleBackColor = True
        '
        'btnTestConnection_eCard
        '
        Me.btnTestConnection_eCard.Location = New System.Drawing.Point(21, 199)
        Me.btnTestConnection_eCard.Name = "btnTestConnection_eCard"
        Me.btnTestConnection_eCard.Size = New System.Drawing.Size(109, 25)
        Me.btnTestConnection_eCard.TabIndex = 8
        Me.btnTestConnection_eCard.Text = "Test Connection"
        Me.btnTestConnection_eCard.UseVisualStyleBackColor = True
        '
        'txtPassword_eCard
        '
        Me.txtPassword_eCard.Location = New System.Drawing.Point(77, 111)
        Me.txtPassword_eCard.Name = "txtPassword_eCard"
        Me.txtPassword_eCard.PasswordChar = Global.Microsoft.VisualBasic.ChrW(64)
        Me.txtPassword_eCard.Size = New System.Drawing.Size(229, 20)
        Me.txtPassword_eCard.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Password"
        '
        'txtUser_eCard
        '
        Me.txtUser_eCard.Location = New System.Drawing.Point(77, 83)
        Me.txtUser_eCard.Name = "txtUser_eCard"
        Me.txtUser_eCard.Size = New System.Drawing.Size(229, 20)
        Me.txtUser_eCard.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "User"
        '
        'txtDatabase_eCard
        '
        Me.txtDatabase_eCard.Location = New System.Drawing.Point(77, 55)
        Me.txtDatabase_eCard.Name = "txtDatabase_eCard"
        Me.txtDatabase_eCard.Size = New System.Drawing.Size(229, 20)
        Me.txtDatabase_eCard.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Database"
        '
        'txtServer_eCard
        '
        Me.txtServer_eCard.Location = New System.Drawing.Point(77, 27)
        Me.txtServer_eCard.Name = "txtServer_eCard"
        Me.txtServer_eCard.Size = New System.Drawing.Size(229, 20)
        Me.txtServer_eCard.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server"
        '
        'tabGSIS
        '
        Me.tabGSIS.Controls.Add(Me.txtPassword_GSIS)
        Me.tabGSIS.Controls.Add(Me.Label9)
        Me.tabGSIS.Controls.Add(Me.btnTestConnection_GSIS)
        Me.tabGSIS.Controls.Add(Me.txtUser_GSIS)
        Me.tabGSIS.Controls.Add(Me.Label5)
        Me.tabGSIS.Controls.Add(Me.txtPort_GSIS)
        Me.tabGSIS.Controls.Add(Me.Label6)
        Me.tabGSIS.Controls.Add(Me.txtServer_GSIS)
        Me.tabGSIS.Controls.Add(Me.Label7)
        Me.tabGSIS.Controls.Add(Me.txtDSN_GSIS)
        Me.tabGSIS.Controls.Add(Me.Label8)
        Me.tabGSIS.Location = New System.Drawing.Point(4, 23)
        Me.tabGSIS.Name = "tabGSIS"
        Me.tabGSIS.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGSIS.Size = New System.Drawing.Size(344, 242)
        Me.tabGSIS.TabIndex = 1
        Me.tabGSIS.Text = "GSIS Database"
        Me.tabGSIS.UseVisualStyleBackColor = True
        '
        'txtPassword_GSIS
        '
        Me.txtPassword_GSIS.Location = New System.Drawing.Point(77, 137)
        Me.txtPassword_GSIS.Name = "txtPassword_GSIS"
        Me.txtPassword_GSIS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(64)
        Me.txtPassword_GSIS.Size = New System.Drawing.Size(229, 20)
        Me.txtPassword_GSIS.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 14)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Password"
        '
        'btnTestConnection_GSIS
        '
        Me.btnTestConnection_GSIS.Location = New System.Drawing.Point(21, 199)
        Me.btnTestConnection_GSIS.Name = "btnTestConnection_GSIS"
        Me.btnTestConnection_GSIS.Size = New System.Drawing.Size(109, 25)
        Me.btnTestConnection_GSIS.TabIndex = 17
        Me.btnTestConnection_GSIS.Text = "Test Connection"
        Me.btnTestConnection_GSIS.UseVisualStyleBackColor = True
        '
        'txtUser_GSIS
        '
        Me.txtUser_GSIS.Location = New System.Drawing.Point(77, 111)
        Me.txtUser_GSIS.Name = "txtUser_GSIS"
        Me.txtUser_GSIS.Size = New System.Drawing.Size(229, 20)
        Me.txtUser_GSIS.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 14)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "User"
        '
        'txtPort_GSIS
        '
        Me.txtPort_GSIS.Location = New System.Drawing.Point(77, 83)
        Me.txtPort_GSIS.Name = "txtPort_GSIS"
        Me.txtPort_GSIS.Size = New System.Drawing.Size(229, 20)
        Me.txtPort_GSIS.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 14)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Port"
        '
        'txtServer_GSIS
        '
        Me.txtServer_GSIS.Location = New System.Drawing.Point(77, 55)
        Me.txtServer_GSIS.Name = "txtServer_GSIS"
        Me.txtServer_GSIS.Size = New System.Drawing.Size(229, 20)
        Me.txtServer_GSIS.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Server"
        '
        'txtDSN_GSIS
        '
        Me.txtDSN_GSIS.Location = New System.Drawing.Point(77, 27)
        Me.txtDSN_GSIS.Name = "txtDSN_GSIS"
        Me.txtDSN_GSIS.Size = New System.Drawing.Size(229, 20)
        Me.txtDSN_GSIS.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 14)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "DSN"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(17, 9)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtIdleLimit
        '
        Me.txtIdleLimit.Location = New System.Drawing.Point(114, 82)
        Me.txtIdleLimit.Name = "txtIdleLimit"
        Me.txtIdleLimit.Size = New System.Drawing.Size(61, 20)
        Me.txtIdleLimit.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 14)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Idle Limit (seconds)"
        '
        'Setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 327)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Setting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Setting"
        Me.TabControl1.ResumeLayout(False)
        Me.tabApplication.ResumeLayout(False)
        Me.tabApplication.PerformLayout()
        Me.tabEcard.ResumeLayout(False)
        Me.tabEcard.PerformLayout()
        Me.tabGSIS.ResumeLayout(False)
        Me.tabGSIS.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabEcard As System.Windows.Forms.TabPage
    Friend WithEvents btnTestConnection_eCard As System.Windows.Forms.Button
    Friend WithEvents txtPassword_eCard As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUser_eCard As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDatabase_eCard As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtServer_eCard As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabGSIS As System.Windows.Forms.TabPage
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents tabApplication As System.Windows.Forms.TabPage
    Friend WithEvents txtPassword_GSIS As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnTestConnection_GSIS As System.Windows.Forms.Button
    Friend WithEvents txtUser_GSIS As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPort_GSIS As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtServer_GSIS As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDSN_GSIS As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCardPrinter As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDefaultPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtIdleLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
