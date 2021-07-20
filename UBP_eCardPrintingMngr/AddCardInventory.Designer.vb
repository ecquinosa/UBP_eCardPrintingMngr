<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddCardInventory
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtCardNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.txtLast3Digits = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CardNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Magstripe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCardNo
        '
        Me.txtCardNo.Font = New System.Drawing.Font("Arial", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCardNo.Location = New System.Drawing.Point(12, 48)
        Me.txtCardNo.Name = "txtCardNo"
        Me.txtCardNo.Size = New System.Drawing.Size(428, 53)
        Me.txtCardNo.TabIndex = 1
        Me.txtCardNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Swipe Card"
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CardNo, Me.ExpiryDate, Me.Magstripe})
        Me.grid.Location = New System.Drawing.Point(15, 112)
        Me.grid.Name = "grid"
        Me.grid.ReadOnly = True
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 20.25!)
        Me.grid.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grid.Size = New System.Drawing.Size(558, 299)
        Me.grid.TabIndex = 2
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(12, 418)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(130, 32)
        Me.lblTotal.TabIndex = 3
        Me.lblTotal.Text = "TOTAL: 0"
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(461, 419)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(112, 32)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "Submit Card(s)"
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(343, 419)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(112, 32)
        Me.btnReset.TabIndex = 3
        Me.btnReset.Text = "Reset"
        Me.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'txtLast3Digits
        '
        Me.txtLast3Digits.Font = New System.Drawing.Font("Arial", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLast3Digits.Location = New System.Drawing.Point(446, 48)
        Me.txtLast3Digits.MaxLength = 3
        Me.txtLast3Digits.Name = "txtLast3Digits"
        Me.txtLast3Digits.Size = New System.Drawing.Size(127, 53)
        Me.txtLast3Digits.TabIndex = 4
        Me.txtLast3Digits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(441, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 25)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Last 3 digits"
        '
        'CardNo
        '
        Me.CardNo.DataPropertyName = "CardNo"
        Me.CardNo.HeaderText = "Card No."
        Me.CardNo.Name = "CardNo"
        Me.CardNo.ReadOnly = True
        Me.CardNo.Width = 74
        '
        'ExpiryDate
        '
        Me.ExpiryDate.DataPropertyName = "ExpiryDate"
        Me.ExpiryDate.HeaderText = "Expiry Date"
        Me.ExpiryDate.Name = "ExpiryDate"
        Me.ExpiryDate.ReadOnly = True
        Me.ExpiryDate.Width = 87
        '
        'Magstripe
        '
        Me.Magstripe.DataPropertyName = "Magstripe"
        Me.Magstripe.HeaderText = "Magstripe"
        Me.Magstripe.Name = "Magstripe"
        Me.Magstripe.ReadOnly = True
        Me.Magstripe.Visible = False
        Me.Magstripe.Width = 79
        '
        'AddCardInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 461)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLast3Digits)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCardNo)
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "AddCardInventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD CARD INVENTORY"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents txtLast3Digits As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CardNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Magstripe As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
