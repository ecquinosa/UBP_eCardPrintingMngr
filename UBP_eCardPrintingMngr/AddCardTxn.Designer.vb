<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddCardTxn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddCardTxn))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGSISNo = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTxnType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCardType = New System.Windows.Forms.ComboBox()
        Me.piceCardPreview = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMagstripe = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCardName = New System.Windows.Forms.Label()
        Me.lblGSISNo = New System.Windows.Forms.Label()
        Me.picPhoto = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkPrintPhoto = New System.Windows.Forms.CheckBox()
        Me.pbLoader = New System.Windows.Forms.PictureBox()
        Me.btnPrintCIR = New System.Windows.Forms.Button()
        Me.btnPrintMailer = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtLast3Digits = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTxnType = New System.Windows.Forms.TextBox()
        Me.txtCardType = New System.Windows.Forms.TextBox()
        Me.txtPrintDate = New System.Windows.Forms.TextBox()
        Me.txtIssuedBy = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEnrolledAt = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtBranchOffice = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBank = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtMailingAddress = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPlaceOfBirth = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDOB = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCardname = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFullname = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCardNo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCRN = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtGSISNo_CIR = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.piceCardPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.pbLoader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(9, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "GSIS NO"
        '
        'txtGSISNo
        '
        Me.txtGSISNo.BackColor = System.Drawing.Color.White
        Me.txtGSISNo.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGSISNo.Location = New System.Drawing.Point(89, 73)
        Me.txtGSISNo.MaxLength = 11
        Me.txtGSISNo.Name = "txtGSISNo"
        Me.txtGSISNo.Size = New System.Drawing.Size(296, 38)
        Me.txtGSISNo.TabIndex = 3
        Me.txtGSISNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboTxnType)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboCardType)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(461, 63)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(237, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "TXN. TYPE"
        '
        'cboTxnType
        '
        Me.cboTxnType.FormattingEnabled = True
        Me.cboTxnType.Location = New System.Drawing.Point(240, 27)
        Me.cboTxnType.Name = "cboTxnType"
        Me.cboTxnType.Size = New System.Drawing.Size(191, 22)
        Me.cboTxnType.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "CARD TYPE"
        '
        'cboCardType
        '
        Me.cboCardType.FormattingEnabled = True
        Me.cboCardType.Items.AddRange(New Object() {"GSIS NO.", "CRN", "CARD NO."})
        Me.cboCardType.Location = New System.Drawing.Point(29, 29)
        Me.cboCardType.Name = "cboCardType"
        Me.cboCardType.Size = New System.Drawing.Size(177, 22)
        Me.cboCardType.TabIndex = 1
        '
        'piceCardPreview
        '
        Me.piceCardPreview.BackgroundImage = CType(resources.GetObject("piceCardPreview.BackgroundImage"), System.Drawing.Image)
        Me.piceCardPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.piceCardPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.piceCardPreview.Location = New System.Drawing.Point(21, 34)
        Me.piceCardPreview.Name = "piceCardPreview"
        Me.piceCardPreview.Size = New System.Drawing.Size(345, 217)
        Me.piceCardPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.piceCardPreview.TabIndex = 49
        Me.piceCardPreview.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(9, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "SWIPE CARD"
        '
        'txtMagstripe
        '
        Me.txtMagstripe.BackColor = System.Drawing.Color.White
        Me.txtMagstripe.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMagstripe.Location = New System.Drawing.Point(89, 115)
        Me.txtMagstripe.Name = "txtMagstripe"
        Me.txtMagstripe.Size = New System.Drawing.Size(217, 27)
        Me.txtMagstripe.TabIndex = 4
        Me.txtMagstripe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(18, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 14)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "CARD PREVIEW"
        '
        'lblCardName
        '
        Me.lblCardName.AutoSize = True
        Me.lblCardName.BackColor = System.Drawing.Color.Transparent
        Me.lblCardName.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCardName.ForeColor = System.Drawing.Color.Gray
        Me.lblCardName.Location = New System.Drawing.Point(46, 208)
        Me.lblCardName.Name = "lblCardName"
        Me.lblCardName.Size = New System.Drawing.Size(132, 16)
        Me.lblCardName.TabIndex = 53
        Me.lblCardName.Text = "<< CARD NAME >>"
        '
        'lblGSISNo
        '
        Me.lblGSISNo.AutoSize = True
        Me.lblGSISNo.BackColor = System.Drawing.Color.Transparent
        Me.lblGSISNo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGSISNo.ForeColor = System.Drawing.Color.Gray
        Me.lblGSISNo.Location = New System.Drawing.Point(46, 225)
        Me.lblGSISNo.Name = "lblGSISNo"
        Me.lblGSISNo.Size = New System.Drawing.Size(106, 16)
        Me.lblGSISNo.TabIndex = 54
        Me.lblGSISNo.Text = "<< GSIS NO >>"
        '
        'picPhoto
        '
        Me.picPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picPhoto.Location = New System.Drawing.Point(34, 54)
        Me.picPhoto.Name = "picPhoto"
        Me.picPhoto.Size = New System.Drawing.Size(72, 71)
        Me.picPhoto.TabIndex = 55
        Me.picPhoto.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.chkPrintPhoto)
        Me.Panel2.Controls.Add(Me.pbLoader)
        Me.Panel2.Controls.Add(Me.btnPrintCIR)
        Me.Panel2.Controls.Add(Me.btnPrintMailer)
        Me.Panel2.Controls.Add(Me.btnSubmit)
        Me.Panel2.Controls.Add(Me.picPhoto)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.lblCardName)
        Me.Panel2.Controls.Add(Me.lblGSISNo)
        Me.Panel2.Controls.Add(Me.piceCardPreview)
        Me.Panel2.Location = New System.Drawing.Point(0, 179)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(471, 263)
        Me.Panel2.TabIndex = 57
        '
        'chkPrintPhoto
        '
        Me.chkPrintPhoto.AutoSize = True
        Me.chkPrintPhoto.Checked = True
        Me.chkPrintPhoto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintPhoto.Location = New System.Drawing.Point(289, 10)
        Me.chkPrintPhoto.Name = "chkPrintPhoto"
        Me.chkPrintPhoto.Size = New System.Drawing.Size(77, 18)
        Me.chkPrintPhoto.TabIndex = 62
        Me.chkPrintPhoto.Text = "Print Photo"
        Me.chkPrintPhoto.UseVisualStyleBackColor = True
        '
        'pbLoader
        '
        Me.pbLoader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbLoader.BackColor = System.Drawing.Color.White
        Me.pbLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbLoader.Location = New System.Drawing.Point(407, 120)
        Me.pbLoader.Name = "pbLoader"
        Me.pbLoader.Size = New System.Drawing.Size(30, 30)
        Me.pbLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbLoader.TabIndex = 61
        Me.pbLoader.TabStop = False
        '
        'btnPrintCIR
        '
        Me.btnPrintCIR.Image = CType(resources.GetObject("btnPrintCIR.Image"), System.Drawing.Image)
        Me.btnPrintCIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintCIR.Location = New System.Drawing.Point(371, 82)
        Me.btnPrintCIR.Name = "btnPrintCIR"
        Me.btnPrintCIR.Size = New System.Drawing.Size(94, 32)
        Me.btnPrintCIR.TabIndex = 9
        Me.btnPrintCIR.Text = "Print CIR"
        Me.btnPrintCIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrintCIR.UseVisualStyleBackColor = True
        Me.btnPrintCIR.Visible = False
        '
        'btnPrintMailer
        '
        Me.btnPrintMailer.Image = CType(resources.GetObject("btnPrintMailer.Image"), System.Drawing.Image)
        Me.btnPrintMailer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintMailer.Location = New System.Drawing.Point(371, 44)
        Me.btnPrintMailer.Name = "btnPrintMailer"
        Me.btnPrintMailer.Size = New System.Drawing.Size(94, 32)
        Me.btnPrintMailer.TabIndex = 8
        Me.btnPrintMailer.Text = "Print Mailer"
        Me.btnPrintMailer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrintMailer.UseVisualStyleBackColor = True
        Me.btnPrintMailer.Visible = False
        '
        'btnSubmit
        '
        Me.btnSubmit.Enabled = False
        Me.btnSubmit.Image = CType(resources.GetObject("btnSubmit.Image"), System.Drawing.Image)
        Me.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSubmit.Location = New System.Drawing.Point(371, 6)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(94, 32)
        Me.btnSubmit.TabIndex = 7
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.Gray
        Me.lblStatus.Location = New System.Drawing.Point(9, 157)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(43, 14)
        Me.lblStatus.TabIndex = 58
        Me.lblStatus.Text = "READY"
        '
        'txtLast3Digits
        '
        Me.txtLast3Digits.BackColor = System.Drawing.Color.White
        Me.txtLast3Digits.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLast3Digits.Location = New System.Drawing.Point(312, 115)
        Me.txtLast3Digits.Name = "txtLast3Digits"
        Me.txtLast3Digits.Size = New System.Drawing.Size(73, 27)
        Me.txtLast3Digits.TabIndex = 5
        Me.txtLast3Digits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.txtEnrolledAt)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtBranchOffice)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtBank)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtMailingAddress)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtPlaceOfBirth)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtDOB)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtCardname)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtFullname)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtCardNo)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtCRN)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtGSISNo_CIR)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Location = New System.Drawing.Point(477, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(354, 441)
        Me.GroupBox2.TabIndex = 59
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CIR"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txtTxnType)
        Me.GroupBox3.Controls.Add(Me.txtCardType)
        Me.GroupBox3.Controls.Add(Me.txtPrintDate)
        Me.GroupBox3.Controls.Add(Me.txtIssuedBy)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Location = New System.Drawing.Point(2, 312)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(343, 123)
        Me.GroupBox3.TabIndex = 69
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "UBP"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Gray
        Me.Label16.Location = New System.Drawing.Point(7, 94)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 14)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "TXN TYPE"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Gray
        Me.Label17.Location = New System.Drawing.Point(1, 66)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 14)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "CARD TYPE"
        '
        'txtTxnType
        '
        Me.txtTxnType.BackColor = System.Drawing.Color.White
        Me.txtTxnType.Location = New System.Drawing.Point(106, 90)
        Me.txtTxnType.Name = "txtTxnType"
        Me.txtTxnType.ReadOnly = True
        Me.txtTxnType.Size = New System.Drawing.Size(181, 20)
        Me.txtTxnType.TabIndex = 47
        '
        'txtCardType
        '
        Me.txtCardType.BackColor = System.Drawing.Color.White
        Me.txtCardType.Location = New System.Drawing.Point(106, 65)
        Me.txtCardType.Name = "txtCardType"
        Me.txtCardType.ReadOnly = True
        Me.txtCardType.Size = New System.Drawing.Size(181, 20)
        Me.txtCardType.TabIndex = 46
        '
        'txtPrintDate
        '
        Me.txtPrintDate.BackColor = System.Drawing.Color.White
        Me.txtPrintDate.Location = New System.Drawing.Point(106, 40)
        Me.txtPrintDate.Name = "txtPrintDate"
        Me.txtPrintDate.ReadOnly = True
        Me.txtPrintDate.Size = New System.Drawing.Size(181, 20)
        Me.txtPrintDate.TabIndex = 45
        '
        'txtIssuedBy
        '
        Me.txtIssuedBy.BackColor = System.Drawing.Color.White
        Me.txtIssuedBy.Location = New System.Drawing.Point(106, 15)
        Me.txtIssuedBy.Name = "txtIssuedBy"
        Me.txtIssuedBy.ReadOnly = True
        Me.txtIssuedBy.Size = New System.Drawing.Size(181, 20)
        Me.txtIssuedBy.TabIndex = 45
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Gray
        Me.Label15.Location = New System.Drawing.Point(2, 42)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 14)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "PRINT DATE"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Gray
        Me.Label14.Location = New System.Drawing.Point(2, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 14)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "ISSUED BY"
        '
        'txtEnrolledAt
        '
        Me.txtEnrolledAt.BackColor = System.Drawing.Color.White
        Me.txtEnrolledAt.Location = New System.Drawing.Point(108, 292)
        Me.txtEnrolledAt.Name = "txtEnrolledAt"
        Me.txtEnrolledAt.ReadOnly = True
        Me.txtEnrolledAt.Size = New System.Drawing.Size(237, 20)
        Me.txtEnrolledAt.TabIndex = 67
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(5, 295)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 14)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "ENROLLED AT"
        '
        'txtBranchOffice
        '
        Me.txtBranchOffice.BackColor = System.Drawing.Color.White
        Me.txtBranchOffice.Location = New System.Drawing.Point(108, 267)
        Me.txtBranchOffice.Name = "txtBranchOffice"
        Me.txtBranchOffice.ReadOnly = True
        Me.txtBranchOffice.Size = New System.Drawing.Size(237, 20)
        Me.txtBranchOffice.TabIndex = 55
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(5, 269)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 14)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "BRANCH/ OFFICE"
        '
        'txtBank
        '
        Me.txtBank.BackColor = System.Drawing.Color.White
        Me.txtBank.Location = New System.Drawing.Point(108, 242)
        Me.txtBank.Name = "txtBank"
        Me.txtBank.ReadOnly = True
        Me.txtBank.Size = New System.Drawing.Size(237, 20)
        Me.txtBank.TabIndex = 54
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(5, 243)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 14)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "PREFERRED BANK"
        '
        'txtMailingAddress
        '
        Me.txtMailingAddress.BackColor = System.Drawing.Color.White
        Me.txtMailingAddress.Location = New System.Drawing.Point(108, 188)
        Me.txtMailingAddress.Multiline = True
        Me.txtMailingAddress.Name = "txtMailingAddress"
        Me.txtMailingAddress.Size = New System.Drawing.Size(237, 49)
        Me.txtMailingAddress.TabIndex = 53
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(5, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 14)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "MAILING ADDRESS"
        '
        'txtPlaceOfBirth
        '
        Me.txtPlaceOfBirth.BackColor = System.Drawing.Color.White
        Me.txtPlaceOfBirth.Location = New System.Drawing.Point(108, 163)
        Me.txtPlaceOfBirth.Name = "txtPlaceOfBirth"
        Me.txtPlaceOfBirth.ReadOnly = True
        Me.txtPlaceOfBirth.Size = New System.Drawing.Size(237, 20)
        Me.txtPlaceOfBirth.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(5, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 14)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "PLACE OF BIRTH"
        '
        'txtDOB
        '
        Me.txtDOB.BackColor = System.Drawing.Color.White
        Me.txtDOB.Location = New System.Drawing.Point(108, 138)
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.ReadOnly = True
        Me.txtDOB.Size = New System.Drawing.Size(237, 20)
        Me.txtDOB.TabIndex = 51
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(5, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 14)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "DATE OF BIRTH"
        '
        'txtCardname
        '
        Me.txtCardname.BackColor = System.Drawing.Color.White
        Me.txtCardname.Location = New System.Drawing.Point(108, 113)
        Me.txtCardname.Name = "txtCardname"
        Me.txtCardname.Size = New System.Drawing.Size(237, 20)
        Me.txtCardname.TabIndex = 50
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(5, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 14)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "CARD NAME"
        '
        'txtFullname
        '
        Me.txtFullname.BackColor = System.Drawing.Color.White
        Me.txtFullname.Location = New System.Drawing.Point(108, 88)
        Me.txtFullname.Name = "txtFullname"
        Me.txtFullname.ReadOnly = True
        Me.txtFullname.Size = New System.Drawing.Size(237, 20)
        Me.txtFullname.TabIndex = 49
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(5, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 14)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "FULL NAME"
        '
        'txtCardNo
        '
        Me.txtCardNo.BackColor = System.Drawing.Color.White
        Me.txtCardNo.Location = New System.Drawing.Point(108, 63)
        Me.txtCardNo.Name = "txtCardNo"
        Me.txtCardNo.ReadOnly = True
        Me.txtCardNo.Size = New System.Drawing.Size(237, 20)
        Me.txtCardNo.TabIndex = 48
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Gray
        Me.Label18.Location = New System.Drawing.Point(5, 65)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 14)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "CARD NO."
        '
        'txtCRN
        '
        Me.txtCRN.BackColor = System.Drawing.Color.White
        Me.txtCRN.Location = New System.Drawing.Point(108, 38)
        Me.txtCRN.Name = "txtCRN"
        Me.txtCRN.ReadOnly = True
        Me.txtCRN.Size = New System.Drawing.Size(237, 20)
        Me.txtCRN.TabIndex = 47
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Gray
        Me.Label19.Location = New System.Drawing.Point(5, 40)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 14)
        Me.Label19.TabIndex = 58
        Me.Label19.Text = "CRN"
        '
        'txtGSISNo_CIR
        '
        Me.txtGSISNo_CIR.BackColor = System.Drawing.Color.White
        Me.txtGSISNo_CIR.Location = New System.Drawing.Point(108, 13)
        Me.txtGSISNo_CIR.Name = "txtGSISNo_CIR"
        Me.txtGSISNo_CIR.ReadOnly = True
        Me.txtGSISNo_CIR.Size = New System.Drawing.Size(237, 20)
        Me.txtGSISNo_CIR.TabIndex = 46
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Gray
        Me.Label20.Location = New System.Drawing.Point(5, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 14)
        Me.Label20.TabIndex = 57
        Me.Label20.Text = "GSIS NO"
        '
        'AddCardTxn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(834, 442)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtLast3Digits)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMagstripe)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtGSISNo)
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "AddCardTxn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PRINT CARD"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.piceCardPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbLoader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGSISNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTxnType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCardType As System.Windows.Forms.ComboBox
    Friend WithEvents piceCardPreview As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMagstripe As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCardName As System.Windows.Forms.Label
    Friend WithEvents lblGSISNo As System.Windows.Forms.Label
    Friend WithEvents picPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnPrintCIR As System.Windows.Forms.Button
    Friend WithEvents btnPrintMailer As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents pbLoader As System.Windows.Forms.PictureBox
    Friend WithEvents txtLast3Digits As System.Windows.Forms.TextBox
    Friend WithEvents chkPrintPhoto As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTxnType As System.Windows.Forms.TextBox
    Friend WithEvents txtCardType As System.Windows.Forms.TextBox
    Friend WithEvents txtPrintDate As System.Windows.Forms.TextBox
    Friend WithEvents txtIssuedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtEnrolledAt As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtBranchOffice As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBank As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtMailingAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPlaceOfBirth As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDOB As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCardname As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFullname As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCRN As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtGSISNo_CIR As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
End Class
