<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CardProfile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CardProfile))
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.CardProfileID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CardProfileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridProperty = New System.Windows.Forms.DataGridView()
        Me.CPPropertyID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PropertyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PositionTop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PositionLeft = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageHeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageWidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Font = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.lblPropertyName = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtTop = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLeft = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridProperty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CardProfileID, Me.CardProfileName})
        Me.grid.Location = New System.Drawing.Point(11, 12)
        Me.grid.Name = "grid"
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid.Size = New System.Drawing.Size(167, 239)
        Me.grid.TabIndex = 2
        '
        'CardProfileID
        '
        Me.CardProfileID.DataPropertyName = "CardProfileID"
        Me.CardProfileID.HeaderText = "ID"
        Me.CardProfileID.Name = "CardProfileID"
        Me.CardProfileID.Width = 43
        '
        'CardProfileName
        '
        Me.CardProfileName.DataPropertyName = "CardProfileName"
        Me.CardProfileName.HeaderText = "Profile"
        Me.CardProfileName.Name = "CardProfileName"
        Me.CardProfileName.Width = 61
        '
        'gridProperty
        '
        Me.gridProperty.AllowUserToAddRows = False
        Me.gridProperty.AllowUserToDeleteRows = False
        Me.gridProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridProperty.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CPPropertyID, Me.PropertyName, Me.PositionTop, Me.PositionLeft, Me.ImageHeight, Me.ImageWidth, Me.Size, Me.Font})
        Me.gridProperty.Location = New System.Drawing.Point(184, 12)
        Me.gridProperty.Name = "gridProperty"
        Me.gridProperty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridProperty.Size = New System.Drawing.Size(191, 239)
        Me.gridProperty.TabIndex = 3
        '
        'CPPropertyID
        '
        Me.CPPropertyID.DataPropertyName = "CPPropertyID"
        Me.CPPropertyID.HeaderText = "ID"
        Me.CPPropertyID.Name = "CPPropertyID"
        Me.CPPropertyID.Width = 43
        '
        'PropertyName
        '
        Me.PropertyName.DataPropertyName = "PropertyName"
        Me.PropertyName.HeaderText = "Property Name"
        Me.PropertyName.Name = "PropertyName"
        Me.PropertyName.Width = 102
        '
        'PositionTop
        '
        Me.PositionTop.DataPropertyName = "PositionTop"
        Me.PositionTop.HeaderText = "PositionTop"
        Me.PositionTop.Name = "PositionTop"
        Me.PositionTop.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PositionTop.Width = 88
        '
        'PositionLeft
        '
        Me.PositionLeft.DataPropertyName = "PositionLeft"
        Me.PositionLeft.HeaderText = "PositionLeft"
        Me.PositionLeft.Name = "PositionLeft"
        Me.PositionLeft.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PositionLeft.Width = 87
        '
        'ImageHeight
        '
        Me.ImageHeight.DataPropertyName = "ImageHeight"
        Me.ImageHeight.HeaderText = "ImageHeight"
        Me.ImageHeight.Name = "ImageHeight"
        Me.ImageHeight.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ImageHeight.Width = 92
        '
        'ImageWidth
        '
        Me.ImageWidth.DataPropertyName = "ImageWidth"
        Me.ImageWidth.HeaderText = "ImageWidth"
        Me.ImageWidth.Name = "ImageWidth"
        Me.ImageWidth.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ImageWidth.Width = 89
        '
        'Size
        '
        Me.Size.DataPropertyName = "Size"
        Me.Size.HeaderText = "Size"
        Me.Size.Name = "Size"
        Me.Size.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Size.Width = 52
        '
        'Font
        '
        Me.Font.DataPropertyName = "Font"
        Me.Font.HeaderText = "Font"
        Me.Font.Name = "Font"
        Me.Font.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Font.Width = 53
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Height"
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(76, 16)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(68, 20)
        Me.txtHeight.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Width"
        '
        'txtWidth
        '
        Me.txtWidth.Location = New System.Drawing.Point(76, 38)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(68, 20)
        Me.txtWidth.TabIndex = 7
        '
        'lblPropertyName
        '
        Me.lblPropertyName.AutoSize = True
        Me.lblPropertyName.Location = New System.Drawing.Point(384, 12)
        Me.lblPropertyName.Name = "lblPropertyName"
        Me.lblPropertyName.Size = New System.Drawing.Size(49, 13)
        Me.lblPropertyName.TabIndex = 16
        Me.lblPropertyName.Text = "Property:"
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSave.Location = New System.Drawing.Point(520, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(26, 23)
        Me.btnSave.TabIndex = 10
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtHeight)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtWidth)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(384, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(162, 68)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Image"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSize)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtName)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(384, 183)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(162, 68)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Font"
        '
        'txtSize
        '
        Me.txtSize.Location = New System.Drawing.Point(76, 15)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(68, 20)
        Me.txtSize.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Size"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(76, 38)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(68, 20)
        Me.txtName.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Name"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtTop)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtLeft)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(384, 36)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(162, 68)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Position"
        '
        'txtTop
        '
        Me.txtTop.Location = New System.Drawing.Point(76, 16)
        Me.txtTop.Name = "txtTop"
        Me.txtTop.Size = New System.Drawing.Size(68, 20)
        Me.txtTop.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Top"
        '
        'txtLeft
        '
        Me.txtLeft.Location = New System.Drawing.Point(76, 38)
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.Size = New System.Drawing.Size(68, 20)
        Me.txtLeft.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Left"
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Image)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.Location = New System.Drawing.Point(492, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(26, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'CardProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 266)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblPropertyName)
        Me.Controls.Add(Me.gridProperty)
        Me.Controls.Add(Me.grid)
        'Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "CardProfile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CARD PROFILE"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridProperty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents gridProperty As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents lblPropertyName As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSize As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTop As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLeft As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CardProfileID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CardProfileName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CPPropertyID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PropertyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PositionTop As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PositionLeft As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageHeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageWidth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Font As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
