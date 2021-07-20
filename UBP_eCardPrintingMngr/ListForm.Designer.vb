<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListForm))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbSearch = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbSpoil = New System.Windows.Forms.ToolStripButton()
        Me.tsbCIR = New System.Windows.Forms.ToolStripButton()
        Me.tsbMailing = New System.Windows.Forms.ToolStripButton()
        Me.tsbCardPreview = New System.Windows.Forms.ToolStripDropDownButton()
        Me.WithPhotoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WithoutPhotoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbRecall = New System.Windows.Forms.ToolStripButton()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAdd, Me.tsbDelete, Me.tsbSearch, Me.tsbEdit, Me.tsbSpoil, Me.tsbCIR, Me.tsbMailing, Me.tsbCardPreview, Me.tsbRecall})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(912, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbAdd
        '
        Me.tsbAdd.Image = CType(resources.GetObject("tsbAdd.Image"), System.Drawing.Image)
        Me.tsbAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAdd.Name = "tsbAdd"
        Me.tsbAdd.Size = New System.Drawing.Size(57, 28)
        Me.tsbAdd.Text = "Add"
        '
        'tsbDelete
        '
        Me.tsbDelete.Image = CType(resources.GetObject("tsbDelete.Image"), System.Drawing.Image)
        Me.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(68, 28)
        Me.tsbDelete.Text = "Delete"
        Me.tsbDelete.Visible = False
        '
        'tsbSearch
        '
        Me.tsbSearch.Image = CType(resources.GetObject("tsbSearch.Image"), System.Drawing.Image)
        Me.tsbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSearch.Name = "tsbSearch"
        Me.tsbSearch.Size = New System.Drawing.Size(70, 28)
        Me.tsbSearch.Text = "Search"
        '
        'tsbEdit
        '
        Me.tsbEdit.Image = CType(resources.GetObject("tsbEdit.Image"), System.Drawing.Image)
        Me.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEdit.Name = "tsbEdit"
        Me.tsbEdit.Size = New System.Drawing.Size(47, 28)
        Me.tsbEdit.Text = "Edit"
        '
        'tsbSpoil
        '
        Me.tsbSpoil.Image = CType(resources.GetObject("tsbSpoil.Image"), System.Drawing.Image)
        Me.tsbSpoil.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbSpoil.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSpoil.Name = "tsbSpoil"
        Me.tsbSpoil.Size = New System.Drawing.Size(61, 28)
        Me.tsbSpoil.Text = "Spoil"
        Me.tsbSpoil.Visible = False
        '
        'tsbCIR
        '
        Me.tsbCIR.Image = CType(resources.GetObject("tsbCIR.Image"), System.Drawing.Image)
        Me.tsbCIR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCIR.Name = "tsbCIR"
        Me.tsbCIR.Size = New System.Drawing.Size(45, 28)
        Me.tsbCIR.Text = "CIR"
        Me.tsbCIR.Visible = False
        '
        'tsbMailing
        '
        Me.tsbMailing.Image = CType(resources.GetObject("tsbMailing.Image"), System.Drawing.Image)
        Me.tsbMailing.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMailing.Name = "tsbMailing"
        Me.tsbMailing.Size = New System.Drawing.Size(67, 28)
        Me.tsbMailing.Text = "Mailing"
        Me.tsbMailing.Visible = False
        '
        'tsbCardPreview
        '
        Me.tsbCardPreview.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WithPhotoToolStripMenuItem, Me.WithoutPhotoToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.tsbCardPreview.Image = CType(resources.GetObject("tsbCardPreview.Image"), System.Drawing.Image)
        Me.tsbCardPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCardPreview.Name = "tsbCardPreview"
        Me.tsbCardPreview.Size = New System.Drawing.Size(105, 28)
        Me.tsbCardPreview.Text = "Card Preview"
        Me.tsbCardPreview.Visible = False
        '
        'WithPhotoToolStripMenuItem
        '
        Me.WithPhotoToolStripMenuItem.Name = "WithPhotoToolStripMenuItem"
        Me.WithPhotoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.WithPhotoToolStripMenuItem.Text = "With Photo"
        '
        'WithoutPhotoToolStripMenuItem
        '
        Me.WithoutPhotoToolStripMenuItem.Name = "WithoutPhotoToolStripMenuItem"
        Me.WithoutPhotoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.WithoutPhotoToolStripMenuItem.Text = "Without Photo"
        '
        'tsbRecall
        '
        Me.tsbRecall.Image = CType(resources.GetObject("tsbRecall.Image"), System.Drawing.Image)
        Me.tsbRecall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbRecall.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRecall.Name = "tsbRecall"
        Me.tsbRecall.Size = New System.Drawing.Size(66, 28)
        Me.tsbRecall.Text = "Recall"
        Me.tsbRecall.Visible = False
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Location = New System.Drawing.Point(0, 31)
        Me.grid.Name = "grid"
        Me.grid.ReadOnly = True
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid.Size = New System.Drawing.Size(912, 440)
        Me.grid.TabIndex = 1
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 471)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ListForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ListForm"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents tsbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSpoil As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCIR As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbMailing As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCardPreview As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents WithPhotoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WithoutPhotoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbRecall As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
