<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentsMaintenance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumentsMaintenance))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtDocumentName = New System.Windows.Forms.TextBox()
        Me.CheckBoxActiveInd = New System.Windows.Forms.CheckBox()
        Me.ComboBoxDocColor = New System.Windows.Forms.ComboBox()
        Me.ComboBoxDocResolution = New System.Windows.Forms.ComboBox()
        Me.ComboBoxJpegQuality = New System.Windows.Forms.ComboBox()
        Me.ComboBoxDocSize = New System.Windows.Forms.ComboBox()
        Me.ComboBoxTrimBorder = New System.Windows.Forms.ComboBox()
        Me.ComboBoxShowOrder = New System.Windows.Forms.ComboBox()
        Me.ListViewAccess = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripSelectAll = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdAddNew = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cboDiagID = New System.Windows.Forms.ComboBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblSystem = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripSelectAll.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView1.HideSelection = False
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(3, 17)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(284, 350)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 250
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "PageRed.png")
        Me.ImageList1.Images.SetKeyName(1, "Page.png")
        Me.ImageList1.Images.SetKeyName(2, "PageBlueSys.png")
        Me.ImageList1.Images.SetKeyName(3, "USER")
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtDocumentName
        '
        Me.txtDocumentName.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtDocumentName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtDocumentName.Location = New System.Drawing.Point(13, 24)
        Me.txtDocumentName.MaxLength = 50
        Me.txtDocumentName.Name = "txtDocumentName"
        Me.txtDocumentName.Size = New System.Drawing.Size(297, 20)
        Me.txtDocumentName.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtDocumentName, "Document Name")
        '
        'CheckBoxActiveInd
        '
        Me.CheckBoxActiveInd.AutoSize = True
        Me.CheckBoxActiveInd.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxActiveInd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxActiveInd.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.CheckBoxActiveInd, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CheckBoxActiveInd.Location = New System.Drawing.Point(254, 5)
        Me.CheckBoxActiveInd.Name = "CheckBoxActiveInd"
        Me.CheckBoxActiveInd.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxActiveInd.TabIndex = 0
        Me.CheckBoxActiveInd.Text = "Active"
        Me.ToolTip1.SetToolTip(Me.CheckBoxActiveInd, "Document Active Indicator")
        Me.CheckBoxActiveInd.UseVisualStyleBackColor = False
        '
        'ComboBoxDocColor
        '
        Me.ComboBoxDocColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDocColor.Enabled = False
        Me.ComboBoxDocColor.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxDocColor, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxDocColor.Location = New System.Drawing.Point(5, 80)
        Me.ComboBoxDocColor.Name = "ComboBoxDocColor"
        Me.ComboBoxDocColor.Size = New System.Drawing.Size(144, 21)
        Me.ComboBoxDocColor.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.ComboBoxDocColor, "Document Color")
        '
        'ComboBoxDocResolution
        '
        Me.ComboBoxDocResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDocResolution.Enabled = False
        Me.ComboBoxDocResolution.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxDocResolution, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxDocResolution.Location = New System.Drawing.Point(159, 80)
        Me.ComboBoxDocResolution.Name = "ComboBoxDocResolution"
        Me.ComboBoxDocResolution.Size = New System.Drawing.Size(136, 21)
        Me.ComboBoxDocResolution.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.ComboBoxDocResolution, "Dociment Resolution")
        '
        'ComboBoxJpegQuality
        '
        Me.ComboBoxJpegQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJpegQuality.Enabled = False
        Me.ComboBoxJpegQuality.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxJpegQuality, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxJpegQuality.Location = New System.Drawing.Point(6, 120)
        Me.ComboBoxJpegQuality.Name = "ComboBoxJpegQuality"
        Me.ComboBoxJpegQuality.Size = New System.Drawing.Size(144, 21)
        Me.ComboBoxJpegQuality.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.ComboBoxJpegQuality, "Document Jpeg Saving Quality")
        '
        'ComboBoxDocSize
        '
        Me.ComboBoxDocSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDocSize.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxDocSize, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxDocSize.Location = New System.Drawing.Point(5, 40)
        Me.ComboBoxDocSize.Name = "ComboBoxDocSize"
        Me.ComboBoxDocSize.Size = New System.Drawing.Size(144, 21)
        Me.ComboBoxDocSize.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.ComboBoxDocSize, "Document Color")
        '
        'ComboBoxTrimBorder
        '
        Me.ComboBoxTrimBorder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTrimBorder.Enabled = False
        Me.ComboBoxTrimBorder.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxTrimBorder, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxTrimBorder.Location = New System.Drawing.Point(159, 40)
        Me.ComboBoxTrimBorder.Name = "ComboBoxTrimBorder"
        Me.ComboBoxTrimBorder.Size = New System.Drawing.Size(136, 21)
        Me.ComboBoxTrimBorder.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.ComboBoxTrimBorder, "Dociment Resolution")
        '
        'ComboBoxShowOrder
        '
        Me.ComboBoxShowOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxShowOrder.Enabled = False
        Me.ComboBoxShowOrder.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxShowOrder, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxShowOrder.Location = New System.Drawing.Point(156, 120)
        Me.ComboBoxShowOrder.Name = "ComboBoxShowOrder"
        Me.ComboBoxShowOrder.Size = New System.Drawing.Size(139, 21)
        Me.ComboBoxShowOrder.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.ComboBoxShowOrder, "Document Jpeg Saving Quality")
        '
        'ListViewAccess
        '
        Me.ListViewAccess.CheckBoxes = True
        Me.ListViewAccess.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.ListViewAccess.ContextMenuStrip = Me.ContextMenuStripSelectAll
        Me.ListViewAccess.FullRowSelect = True
        Me.ListViewAccess.GridLines = True
        Me.ListViewAccess.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewAccess.HideSelection = False
        Me.ErrorProvider1.SetIconAlignment(Me.ListViewAccess, System.Windows.Forms.ErrorIconAlignment.TopRight)
        Me.ListViewAccess.LargeImageList = Me.ImageList1
        Me.ListViewAccess.Location = New System.Drawing.Point(322, 24)
        Me.ListViewAccess.MultiSelect = False
        Me.ListViewAccess.Name = "ListViewAccess"
        Me.ListViewAccess.Size = New System.Drawing.Size(155, 294)
        Me.ListViewAccess.SmallImageList = Me.ImageList1
        Me.ListViewAccess.TabIndex = 10
        Me.ListViewAccess.UseCompatibleStateImageBehavior = False
        Me.ListViewAccess.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 130
        '
        'ContextMenuStripSelectAll
        '
        Me.ContextMenuStripSelectAll.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.ToolStripSeparator1, Me.SelectNoneToolStripMenuItem})
        Me.ContextMenuStripSelectAll.Name = "ContextMenuStripSelectAll"
        Me.ContextMenuStripSelectAll.Size = New System.Drawing.Size(138, 54)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(134, 6)
        '
        'SelectNoneToolStripMenuItem
        '
        Me.SelectNoneToolStripMenuItem.Name = "SelectNoneToolStripMenuItem"
        Me.SelectNoneToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.SelectNoneToolStripMenuItem.Text = "Select None"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.cmdCancel)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Controls.Add(Me.cmdEdit)
        Me.Panel2.Controls.Add(Me.cmdAddNew)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 371)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(792, 34)
        Me.Panel2.TabIndex = 99
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(714, 6)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.Location = New System.Drawing.Point(246, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.Enabled = False
        Me.cmdUpdate.Location = New System.Drawing.Point(165, 6)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate.TabIndex = 3
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEdit.Enabled = False
        Me.cmdEdit.Location = New System.Drawing.Point(84, 6)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.cmdEdit.TabIndex = 2
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddNew.Location = New System.Drawing.Point(3, 6)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddNew.TabIndex = 1
        Me.cmdAddNew.Text = "Add New"
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 20
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 20
        Me.ToolTip1.ReshowDelay = 4
        Me.ToolTip1.ShowAlways = True
        '
        'cboDiagID
        '
        Me.cboDiagID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiagID.FormattingEnabled = True
        Me.cboDiagID.Location = New System.Drawing.Point(12, 253)
        Me.cboDiagID.Name = "cboDiagID"
        Me.cboDiagID.Size = New System.Drawing.Size(298, 21)
        Me.cboDiagID.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cboDiagID, "If specified, the Document will be assigned to the Patient's Procedure")
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(460, 7)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 275
        Me.PictureBox3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox3, "Select the users to be able to access this type of documents." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Administrators a" &
        "re always permitted to access all types of " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "documents.")
        '
        'lblSystem
        '
        Me.lblSystem.AutoSize = True
        Me.lblSystem.ForeColor = System.Drawing.Color.Red
        Me.lblSystem.Location = New System.Drawing.Point(79, 8)
        Me.lblSystem.Name = "lblSystem"
        Me.lblSystem.Size = New System.Drawing.Size(73, 13)
        Me.lblSystem.TabIndex = 276
        Me.lblSystem.Text = "System Profile"
        Me.ToolTip1.SetToolTip(Me.lblSystem, "System Profile Name Can Not Be Changed")
        Me.lblSystem.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Profile Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "Document Color"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(156, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "Scan Resolution"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 128
        Me.Label7.Text = "Jpeg Quality"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(293, 17)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(491, 350)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.lblSystem)
        Me.TabPage1.Controls.Add(Me.PictureBox3)
        Me.TabPage1.Controls.Add(Me.ListViewAccess)
        Me.TabPage1.Controls.Add(Me.CheckBoxActiveInd)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.cboDiagID)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.txtComments)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtDocumentName)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(483, 324)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ComboBoxShowOrder)
        Me.GroupBox1.Controls.Add(Me.ComboBoxTrimBorder)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.ComboBoxDocSize)
        Me.GroupBox1.Controls.Add(Me.ComboBoxDocColor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ComboBoxDocResolution)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ComboBoxJpegQuality)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(9, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(301, 150)
        Me.GroupBox1.TabIndex = 277
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TWAIN Scan Process Parameters"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(156, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 167
        Me.Label6.Text = "Show Order"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(156, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 165
        Me.Label5.Text = "Trim Border (Inch)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 163
        Me.Label9.Text = "Paper Size"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(319, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 13)
        Me.Label10.TabIndex = 172
        Me.Label10.Text = "Access Permitted To:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 237)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(171, 13)
        Me.Label8.TabIndex = 170
        Me.Label8.Text = "Diagnostic Assigned To Document"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(163, 50)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(147, 17)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "Document Name Editable"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(10, 277)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 13)
        Me.Label28.TabIndex = 161
        Me.Label28.Text = "Comments"
        '
        'txtComments
        '
        Me.txtComments.Enabled = False
        Me.txtComments.Location = New System.Drawing.Point(12, 293)
        Me.txtComments.MaxLength = 255
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(298, 25)
        Me.txtComments.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(0, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Documents"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(757, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 101
        Me.PictureBox1.TabStop = False
        '
        'frmDocumentsMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(792, 405)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDocumentsMaintenance"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Scanner Document Profiles Maintenance"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripSelectAll.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDocumentName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDocResolution As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDocColor As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxActiveInd As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxJpegQuality As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDocSize As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxTrimBorder As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxShowOrder As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboDiagID As System.Windows.Forms.ComboBox
    Friend WithEvents ListViewAccess As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripSelectAll As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblSystem As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
