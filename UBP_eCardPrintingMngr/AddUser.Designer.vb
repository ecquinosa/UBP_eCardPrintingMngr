<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddUser))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtRoles = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnStatus = New System.Windows.Forms.Button()
        Me.btnResetPassword = New System.Windows.Forms.Button()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Username"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(108, 12)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(272, 23)
        Me.txtUsername.TabIndex = 5
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(108, 42)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(272, 23)
        Me.txtFName.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "First"
        '
        'txtMName
        '
        Me.txtMName.Location = New System.Drawing.Point(108, 72)
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Size = New System.Drawing.Size(272, 23)
        Me.txtMName.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Middle"
        '
        'txtLName
        '
        Me.txtLName.Location = New System.Drawing.Point(108, 102)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(272, 23)
        Me.txtLName.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Last"
        '
        'btnReset
        '
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(108, 192)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(93, 37)
        Me.btnReset.TabIndex = 15
        Me.btnReset.Text = "Reset"
        Me.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(8, 236)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(49, 16)
        Me.lblStatus.TabIndex = 16
        Me.lblStatus.Text = "Ready"
        '
        'txtRoles
        '
        Me.txtRoles.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtRoles.Location = New System.Drawing.Point(108, 132)
        Me.txtRoles.Multiline = True
        Me.txtRoles.Name = "txtRoles"
        Me.txtRoles.ReadOnly = True
        Me.txtRoles.Size = New System.Drawing.Size(272, 49)
        Me.txtRoles.TabIndex = 17
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(21, 147)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(48, 16)
        Me.LinkLabel1.TabIndex = 18
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Role/s"
        '
        'btnSubmit
        '
        Me.btnSubmit.Image = CType(resources.GetObject("btnSubmit.Image"), System.Drawing.Image)
        Me.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSubmit.Location = New System.Drawing.Point(11, 192)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(90, 37)
        Me.btnSubmit.TabIndex = 19
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnStatus
        '
        Me.btnStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStatus.Image = CType(resources.GetObject("btnStatus.Image"), System.Drawing.Image)
        Me.btnStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStatus.Location = New System.Drawing.Point(207, 192)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(90, 37)
        Me.btnStatus.TabIndex = 20
        Me.btnStatus.Text = "Status"
        Me.btnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStatus.UseVisualStyleBackColor = True
        Me.btnStatus.Visible = False
        '
        'btnResetPassword
        '
        Me.btnResetPassword.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetPassword.Image = CType(resources.GetObject("btnResetPassword.Image"), System.Drawing.Image)
        Me.btnResetPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetPassword.Location = New System.Drawing.Point(304, 192)
        Me.btnResetPassword.Name = "btnResetPassword"
        Me.btnResetPassword.Size = New System.Drawing.Size(90, 37)
        Me.btnResetPassword.TabIndex = 21
        Me.btnResetPassword.Text = "Reset Password"
        Me.btnResetPassword.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnResetPassword.UseVisualStyleBackColor = True
        Me.btnResetPassword.Visible = False
        '
        'AddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 266)
        Me.Controls.Add(Me.btnResetPassword)
        Me.Controls.Add(Me.btnStatus)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.txtRoles)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.txtLName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "AddUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD USER"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtRoles As System.Windows.Forms.TextBox
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents btnResetPassword As System.Windows.Forms.Button
    Friend WithEvents btnStatus As System.Windows.Forms.Button
End Class
