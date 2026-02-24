<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiagnosisMaintenance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiagnosisMaintenance))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripDuplicateDiagnose = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.CheckBoxActiveInd = New System.Windows.Forms.CheckBox()
        Me.txtICDCode = New System.Windows.Forms.TextBox()
        Me.txtICDDescription = New System.Windows.Forms.TextBox()
        Me.CheckedListBoxProcedures = New System.Windows.Forms.CheckedListBox()
        Me.ContextMenuStripCopyProcedures = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PastCheckedProceduresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonConvert = New System.Windows.Forms.Button()
        Me.cmdDuplicate = New System.Windows.Forms.Button()
        Me.ButtonBatchProcess = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdAddNew = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ComboBoxGroups = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PanelDiagnoses = New System.Windows.Forms.Panel()
        Me.ContextMenuStripDuplicateDiagnose.SuspendLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ContextMenuStripCopyProcedures.SuspendLayout
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel2.SuspendLayout
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.PanelDiagnoses.SuspendLayout
        Me.SuspendLayout
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStripDuplicateDiagnose
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(3, 42)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(316, 359)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ICD Code"
        Me.ColumnHeader1.Width = 65
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Description"
        Me.ColumnHeader2.Width = 215
        '
        'ContextMenuStripDuplicateDiagnose
        '
        Me.ContextMenuStripDuplicateDiagnose.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStripDuplicateDiagnose.Name = "ContextMenuStripCopyProcedures"
        Me.ContextMenuStripDuplicateDiagnose.Size = New System.Drawing.Size(177, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem1.Text = "Duplicate Diagnose"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "PageRed.png")
        Me.ImageList1.Images.SetKeyName(1, "Page.png")
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(701, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ErrorProvider1.SetIconAlignment(Me.TextBoxSearch, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.TextBoxSearch.Location = New System.Drawing.Point(3, 18)
        Me.TextBoxSearch.MaxLength = 50
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(316, 20)
        Me.TextBoxSearch.TabIndex = 0
        '
        'CheckBoxActiveInd
        '
        Me.CheckBoxActiveInd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxActiveInd.AutoSize = True
        Me.CheckBoxActiveInd.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxActiveInd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxActiveInd.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.CheckBoxActiveInd, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CheckBoxActiveInd.Location = New System.Drawing.Point(329, 9)
        Me.CheckBoxActiveInd.Name = "CheckBoxActiveInd"
        Me.CheckBoxActiveInd.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxActiveInd.TabIndex = 2
        Me.CheckBoxActiveInd.Text = "Active"
        Me.ToolTip1.SetToolTip(Me.CheckBoxActiveInd, "Injury Active Indicator")
        Me.CheckBoxActiveInd.UseVisualStyleBackColor = False
        '
        'txtICDCode
        '
        Me.txtICDCode.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtICDCode, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtICDCode.Location = New System.Drawing.Point(24, 29)
        Me.txtICDCode.MaxLength = 10
        Me.txtICDCode.Name = "txtICDCode"
        Me.txtICDCode.Size = New System.Drawing.Size(107, 20)
        Me.txtICDCode.TabIndex = 0
        '
        'txtICDDescription
        '
        Me.txtICDDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtICDDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtICDDescription.Enabled = False
        Me.txtICDDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtICDDescription.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconAlignment(Me.txtICDDescription, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtICDDescription.Location = New System.Drawing.Point(24, 67)
        Me.txtICDDescription.MaxLength = 250
        Me.txtICDDescription.Name = "txtICDDescription"
        Me.txtICDDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtICDDescription.Size = New System.Drawing.Size(361, 20)
        Me.txtICDDescription.TabIndex = 2
        '
        'CheckedListBoxProcedures
        '
        Me.CheckedListBoxProcedures.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckedListBoxProcedures.ContextMenuStrip = Me.ContextMenuStripCopyProcedures
        Me.CheckedListBoxProcedures.Enabled = False
        Me.CheckedListBoxProcedures.FormattingEnabled = True
        Me.CheckedListBoxProcedures.HorizontalScrollbar = True
        Me.ErrorProvider1.SetIconAlignment(Me.CheckedListBoxProcedures, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CheckedListBoxProcedures.IntegralHeight = False
        Me.CheckedListBoxProcedures.Location = New System.Drawing.Point(24, 111)
        Me.CheckedListBoxProcedures.Name = "CheckedListBoxProcedures"
        Me.CheckedListBoxProcedures.Size = New System.Drawing.Size(361, 247)
        Me.CheckedListBoxProcedures.TabIndex = 3
        '
        'ContextMenuStripCopyProcedures
        '
        Me.ContextMenuStripCopyProcedures.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PastCheckedProceduresToolStripMenuItem})
        Me.ContextMenuStripCopyProcedures.Name = "ContextMenuStripCopyProcedures"
        Me.ContextMenuStripCopyProcedures.Size = New System.Drawing.Size(208, 26)
        '
        'PastCheckedProceduresToolStripMenuItem
        '
        Me.PastCheckedProceduresToolStripMenuItem.Image = CType(resources.GetObject("PastCheckedProceduresToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PastCheckedProceduresToolStripMenuItem.Name = "PastCheckedProceduresToolStripMenuItem"
        Me.PastCheckedProceduresToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.PastCheckedProceduresToolStripMenuItem.Text = "Past Checked Procedures"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 20
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 20
        Me.ToolTip1.ReshowDelay = 4
        Me.ToolTip1.ShowAlways = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(369, 93)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 216
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Copy List of Checked Procedures")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.ButtonConvert)
        Me.Panel2.Controls.Add(Me.cmdDuplicate)
        Me.Panel2.Controls.Add(Me.ButtonBatchProcess)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.cmdCancel)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Controls.Add(Me.cmdEdit)
        Me.Panel2.Controls.Add(Me.cmdAddNew)
        Me.Panel2.Controls.Add(Me.cmdDelete)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 406)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(731, 34)
        Me.Panel2.TabIndex = 99
        '
        'ButtonConvert
        '
        Me.ButtonConvert.Image = CType(resources.GetObject("ButtonConvert.Image"), System.Drawing.Image)
        Me.ButtonConvert.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonConvert.Location = New System.Drawing.Point(417, 6)
        Me.ButtonConvert.Name = "ButtonConvert"
        Me.ButtonConvert.Size = New System.Drawing.Size(98, 23)
        Me.ButtonConvert.TabIndex = 8
        Me.ButtonConvert.Text = "Convert Code"
        Me.ButtonConvert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonConvert.UseVisualStyleBackColor = True
        '
        'cmdDuplicate
        '
        Me.cmdDuplicate.Image = CType(resources.GetObject("cmdDuplicate.Image"), System.Drawing.Image)
        Me.cmdDuplicate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDuplicate.Location = New System.Drawing.Point(95, 6)
        Me.cmdDuplicate.Name = "cmdDuplicate"
        Me.cmdDuplicate.Size = New System.Drawing.Size(85, 23)
        Me.cmdDuplicate.TabIndex = 7
        Me.cmdDuplicate.Text = "Duplicate"
        Me.cmdDuplicate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDuplicate.UseVisualStyleBackColor = True
        '
        'ButtonBatchProcess
        '
        Me.ButtonBatchProcess.Image = CType(resources.GetObject("ButtonBatchProcess.Image"), System.Drawing.Image)
        Me.ButtonBatchProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonBatchProcess.Location = New System.Drawing.Point(521, 6)
        Me.ButtonBatchProcess.Name = "ButtonBatchProcess"
        Me.ButtonBatchProcess.Size = New System.Drawing.Size(102, 23)
        Me.ButtonBatchProcess.TabIndex = 6
        Me.ButtonBatchProcess.Text = "Batch Update"
        Me.ButtonBatchProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonBatchProcess.UseVisualStyleBackColor = True
        Me.ButtonBatchProcess.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(650, 6)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(340, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Enabled = False
        Me.cmdUpdate.Image = CType(resources.GetObject("cmdUpdate.Image"), System.Drawing.Image)
        Me.cmdUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdUpdate.Location = New System.Drawing.Point(263, 6)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(71, 23)
        Me.cmdUpdate.TabIndex = 3
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Enabled = False
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEdit.Location = New System.Drawing.Point(186, 6)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(71, 23)
        Me.cmdEdit.TabIndex = 2
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Image = CType(resources.GetObject("cmdAddNew.Image"), System.Drawing.Image)
        Me.cmdAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddNew.Location = New System.Drawing.Point(4, 6)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(85, 23)
        Me.cmdAddNew.TabIndex = 1
        Me.cmdAddNew.Text = "Add New"
        Me.cmdAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Enabled = False
        Me.cmdDelete.Location = New System.Drawing.Point(4, 8)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(85, 23)
        Me.cmdDelete.TabIndex = 0
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        Me.cmdDelete.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(27, 13)
        Me.Label25.TabIndex = 157
        Me.Label25.Text = "Find"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(326, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(399, 390)
        Me.TabControl1.TabIndex = 158
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PictureBox2)
        Me.TabPage1.Controls.Add(Me.ComboBoxGroups)
        Me.TabPage1.Controls.Add(Me.CheckBoxActiveInd)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.CheckedListBoxProcedures)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtICDCode)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.txtICDDescription)
        Me.TabPage1.Controls.Add(Me.Label29)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(391, 364)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ComboBoxGroups
        '
        Me.ComboBoxGroups.Enabled = False
        Me.ComboBoxGroups.FormattingEnabled = True
        Me.ComboBoxGroups.Location = New System.Drawing.Point(153, 29)
        Me.ComboBoxGroups.Name = "ComboBoxGroups"
        Me.ComboBoxGroups.Size = New System.Drawing.Size(232, 21)
        Me.ComboBoxGroups.TabIndex = 215
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 13)
        Me.Label3.TabIndex = 214
        Me.Label3.Text = "Assigned To Procedures"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(150, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 212
        Me.Label2.Text = "ICDGroup"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(21, 13)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(50, 13)
        Me.Label28.TabIndex = 210
        Me.Label28.Text = "ICDCode"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(21, 52)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(78, 13)
        Me.Label29.TabIndex = 211
        Me.Label29.Text = "ICDDescription"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'PanelDiagnoses
        '
        Me.PanelDiagnoses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDiagnoses.BackColor = System.Drawing.Color.Transparent
        Me.PanelDiagnoses.Controls.Add(Me.TextBoxSearch)
        Me.PanelDiagnoses.Controls.Add(Me.Label25)
        Me.PanelDiagnoses.Controls.Add(Me.ListView1)
        Me.PanelDiagnoses.Location = New System.Drawing.Point(0, -2)
        Me.PanelDiagnoses.Name = "PanelDiagnoses"
        Me.PanelDiagnoses.Size = New System.Drawing.Size(331, 404)
        Me.PanelDiagnoses.TabIndex = 159
        '
        'frmDiagnosisMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(731, 440)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PanelDiagnoses)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(747, 479)
        Me.Name = "frmDiagnosisMaintenance"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Diagnosis Maintenance"
        Me.ContextMenuStripDuplicateDiagnose.ResumeLayout(false)
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ContextMenuStripCopyProcedures.ResumeLayout(false)
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel2.ResumeLayout(false)
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage1.PerformLayout
        Me.PanelDiagnoses.ResumeLayout(false)
        Me.PanelDiagnoses.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents CheckBoxActiveInd As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtICDCode As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtICDDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBoxProcedures As System.Windows.Forms.CheckedListBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PanelDiagnoses As System.Windows.Forms.Panel
    Friend WithEvents ButtonBatchProcess As Button
    Friend WithEvents ComboBoxGroups As ComboBox
    Friend WithEvents ContextMenuStripCopyProcedures As ContextMenuStrip
    Friend WithEvents PastCheckedProceduresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents ContextMenuStripDuplicateDiagnose As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents cmdDuplicate As Button
    Friend WithEvents ButtonConvert As Button
End Class
