<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportViewer))
        Me.gb = New System.Windows.Forms.GroupBox()
        Me.pbLoader = New System.Windows.Forms.PictureBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.groupCardAndTxnType = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtGSISNo = New System.Windows.Forms.TextBox()
        Me.cboTxnType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCardType = New System.Windows.Forms.ComboBox()
        Me.groupDate = New System.Windows.Forms.GroupBox()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.gb.SuspendLayout()
        CType(Me.pbLoader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupCardAndTxnType.SuspendLayout()
        Me.groupDate.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb
        '
        Me.gb.Controls.Add(Me.pbLoader)
        Me.gb.Controls.Add(Me.lblStatus)
        Me.gb.Controls.Add(Me.groupCardAndTxnType)
        Me.gb.Controls.Add(Me.groupDate)
        Me.gb.Controls.Add(Me.btnSubmit)
        Me.gb.Location = New System.Drawing.Point(12, 8)
        Me.gb.Name = "gb"
        Me.gb.Size = New System.Drawing.Size(896, 160)
        Me.gb.TabIndex = 1
        Me.gb.TabStop = False
        '
        'pbLoader
        '
        Me.pbLoader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbLoader.BackColor = System.Drawing.Color.White
        Me.pbLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbLoader.Location = New System.Drawing.Point(702, 45)
        Me.pbLoader.Name = "pbLoader"
        Me.pbLoader.Size = New System.Drawing.Size(30, 30)
        Me.pbLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbLoader.TabIndex = 60
        Me.pbLoader.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.Gray
        Me.lblStatus.Location = New System.Drawing.Point(599, 85)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 14)
        Me.lblStatus.TabIndex = 59
        '
        'groupCardAndTxnType
        '
        Me.groupCardAndTxnType.Controls.Add(Me.Label6)
        Me.groupCardAndTxnType.Controls.Add(Me.Label5)
        Me.groupCardAndTxnType.Controls.Add(Me.txtGSISNo)
        Me.groupCardAndTxnType.Controls.Add(Me.cboTxnType)
        Me.groupCardAndTxnType.Controls.Add(Me.Label3)
        Me.groupCardAndTxnType.Controls.Add(Me.Label4)
        Me.groupCardAndTxnType.Controls.Add(Me.cboCardType)
        Me.groupCardAndTxnType.Location = New System.Drawing.Point(6, 57)
        Me.groupCardAndTxnType.Name = "groupCardAndTxnType"
        Me.groupCardAndTxnType.Size = New System.Drawing.Size(573, 97)
        Me.groupCardAndTxnType.TabIndex = 9
        Me.groupCardAndTxnType.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(23, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 26)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "(comma " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "delimited)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(23, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 14)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "GSIS Nos"
        '
        'txtGSISNo
        '
        Me.txtGSISNo.Location = New System.Drawing.Point(97, 44)
        Me.txtGSISNo.Multiline = True
        Me.txtGSISNo.Name = "txtGSISNo"
        Me.txtGSISNo.Size = New System.Drawing.Size(459, 47)
        Me.txtGSISNo.TabIndex = 50
        '
        'cboTxnType
        '
        Me.cboTxnType.FormattingEnabled = True
        Me.cboTxnType.Items.AddRange(New Object() {"GSIS NO.", "CRN", "CARD NO."})
        Me.cboTxnType.Location = New System.Drawing.Point(365, 15)
        Me.cboTxnType.Name = "cboTxnType"
        Me.cboTxnType.Size = New System.Drawing.Size(191, 22)
        Me.cboTxnType.TabIndex = 47
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(296, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "TXN. TYPE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(23, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 14)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "CARD TYPE"
        '
        'cboCardType
        '
        Me.cboCardType.FormattingEnabled = True
        Me.cboCardType.Items.AddRange(New Object() {"GSIS NO.", "CRN", "CARD NO."})
        Me.cboCardType.Location = New System.Drawing.Point(97, 16)
        Me.cboCardType.Name = "cboCardType"
        Me.cboCardType.Size = New System.Drawing.Size(177, 22)
        Me.cboCardType.TabIndex = 46
        '
        'groupDate
        '
        Me.groupDate.Controls.Add(Me.dtpFrom)
        Me.groupDate.Controls.Add(Me.Label1)
        Me.groupDate.Controls.Add(Me.dtpTo)
        Me.groupDate.Controls.Add(Me.Label2)
        Me.groupDate.Location = New System.Drawing.Point(6, 8)
        Me.groupDate.Name = "groupDate"
        Me.groupDate.Size = New System.Drawing.Size(573, 51)
        Me.groupDate.TabIndex = 8
        Me.groupDate.TabStop = False
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(64, 17)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtpFrom.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(23, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "FROM"
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(296, 17)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(200, 20)
        Me.dtpTo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(270, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "TO"
        '
        'btnSubmit
        '
        Me.btnSubmit.Image = CType(resources.GetObject("btnSubmit.Image"), System.Drawing.Image)
        Me.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSubmit.Location = New System.Drawing.Point(602, 37)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(94, 45)
        Me.btnSubmit.TabIndex = 0
        Me.btnSubmit.Text = "Generate"
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.crv.CachedPageNumberPerDoc = 10
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Location = New System.Drawing.Point(12, 174)
        Me.crv.Name = "crv"
        Me.crv.Size = New System.Drawing.Size(896, 391)
        Me.crv.TabIndex = 2
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(920, 578)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.gb)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ReportViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "REPORT"
        Me.gb.ResumeLayout(False)
        Me.gb.PerformLayout()
        CType(Me.pbLoader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupCardAndTxnType.ResumeLayout(False)
        Me.groupCardAndTxnType.PerformLayout()
        Me.groupDate.ResumeLayout(False)
        Me.groupDate.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb As System.Windows.Forms.GroupBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents groupCardAndTxnType As System.Windows.Forms.GroupBox
    Friend WithEvents groupDate As System.Windows.Forms.GroupBox
    Friend WithEvents cboTxnType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCardType As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents pbLoader As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtGSISNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
