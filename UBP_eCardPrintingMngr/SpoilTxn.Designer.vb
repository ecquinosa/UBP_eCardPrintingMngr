<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpoilTxn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SpoilTxn))
        Me.cboSpoiledReason = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCardNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOtherReason = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCardTxnID = New System.Windows.Forms.TextBox()
        Me.txtGSISNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboSpoiledReason
        '
        Me.cboSpoiledReason.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cboSpoiledReason.FormattingEnabled = True
        Me.cboSpoiledReason.Items.AddRange(New Object() {"GSIS NO.", "CRN", "CARD NO."})
        Me.cboSpoiledReason.Location = New System.Drawing.Point(149, 45)
        Me.cboSpoiledReason.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboSpoiledReason.Name = "cboSpoiledReason"
        Me.cboSpoiledReason.Size = New System.Drawing.Size(276, 26)
        Me.cboSpoiledReason.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(20, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 15)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "CARD NO."
        '
        'txtCardNo
        '
        Me.txtCardNo.BackColor = System.Drawing.Color.White
        Me.txtCardNo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCardNo.Location = New System.Drawing.Point(149, 12)
        Me.txtCardNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCardNo.Name = "txtCardNo"
        Me.txtCardNo.ReadOnly = True
        Me.txtCardNo.Size = New System.Drawing.Size(276, 26)
        Me.txtCardNo.TabIndex = 1
        Me.txtCardNo.TabStop = False
        Me.txtCardNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(20, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "REASON"
        '
        'txtOtherReason
        '
        Me.txtOtherReason.BackColor = System.Drawing.Color.White
        Me.txtOtherReason.Enabled = False
        Me.txtOtherReason.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOtherReason.Location = New System.Drawing.Point(149, 78)
        Me.txtOtherReason.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtOtherReason.Multiline = True
        Me.txtOtherReason.Name = "txtOtherReason"
        Me.txtOtherReason.Size = New System.Drawing.Size(276, 67)
        Me.txtOtherReason.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(20, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 15)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "OTHER REASON"
        '
        'txtCardTxnID
        '
        Me.txtCardTxnID.BackColor = System.Drawing.Color.White
        Me.txtCardTxnID.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCardTxnID.Location = New System.Drawing.Point(149, 152)
        Me.txtCardTxnID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCardTxnID.Name = "txtCardTxnID"
        Me.txtCardTxnID.ReadOnly = True
        Me.txtCardTxnID.Size = New System.Drawing.Size(276, 26)
        Me.txtCardTxnID.TabIndex = 4
        Me.txtCardTxnID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtGSISNo
        '
        Me.txtGSISNo.BackColor = System.Drawing.Color.White
        Me.txtGSISNo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGSISNo.Location = New System.Drawing.Point(149, 185)
        Me.txtGSISNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtGSISNo.Name = "txtGSISNo"
        Me.txtGSISNo.ReadOnly = True
        Me.txtGSISNo.Size = New System.Drawing.Size(276, 26)
        Me.txtGSISNo.TabIndex = 5
        Me.txtGSISNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(20, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "CARD TXN ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(20, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 15)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "GSIS NO"
        '
        'btnSubmit
        '
        Me.btnSubmit.Image = CType(resources.GetObject("btnSubmit.Image"), System.Drawing.Image)
        Me.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSubmit.Location = New System.Drawing.Point(12, 236)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(90, 35)
        Me.btnSubmit.TabIndex = 8
        Me.btnSubmit.Text = "Approve"
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(108, 246)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 15)
        Me.lblStatus.TabIndex = 60
        '
        'SpoilTxn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 283)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtGSISNo)
        Me.Controls.Add(Me.txtCardTxnID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOtherReason)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSpoiledReason)
        Me.Controls.Add(Me.txtCardNo)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "SpoilTxn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SPOIL CARD/ TRANSACTION"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboSpoiledReason As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOtherReason As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCardTxnID As System.Windows.Forms.TextBox
    Friend WithEvents txtGSISNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
End Class
