<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProcedureMaintenance
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer1 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer3 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcedureMaintenance))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DuplicateProcedureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtProcName = New System.Windows.Forms.TextBox()
        Me.txtProcDescription = New System.Windows.Forms.TextBox()
        Me.CheckBoxActiveInd = New System.Windows.Forms.CheckBox()
        Me.ComboBoxDiagIDSearch = New System.Windows.Forms.ComboBox()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.ComboBoxDiagID = New System.Windows.Forms.ComboBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.txtNFPrice = New System.Windows.Forms.TextBox()
        Me.txtWCPrice = New System.Windows.Forms.TextBox()
        Me.txtPRPrice = New System.Windows.Forms.TextBox()
        Me.txtAbbr = New System.Windows.Forms.TextBox()
        Me.txtModifier = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TextBoxSearchDiagnos = New System.Windows.Forms.TextBox()
        Me.cboMinDays = New System.Windows.Forms.ComboBox()
        Me.cboInterval = New System.Windows.Forms.ComboBox()
        Me.ButtonRefresh = New System.Windows.Forms.Button()
        Me.picNFPrice = New System.Windows.Forms.PictureBox()
        Me.picWCPrice = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ButtonDuplicate = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdAddNew = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNYNFWarning = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel22 = New System.Windows.Forms.ToolStrip()
        Me.ButtonAddDiagnos = New System.Windows.Forms.ToolStripButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonDn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonUp = New System.Windows.Forms.ToolStripButton()
        Me.ListViewDiagnosisSelected = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ListViewDiagnosis = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LabelProcedureName = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageListInfo = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStripFormulaUpdate = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItemUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuItemUpdateAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picNFPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picWCPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel22.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripFormulaUpdate.SuspendLayout()
        Me.SuspendLayout()
        ColumnHeaderRenderer2.Name = "ColumnHeaderRenderer2"
        ColumnHeaderRenderer2.TextRotationAngle = 0R
        ColumnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        ColumnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer1.Name = "ColumnHeaderRenderer1"
        ColumnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer1.TextRotationAngle = 0R
        ColumnHeaderRenderer3.Name = "ColumnHeaderRenderer3"
        ColumnHeaderRenderer3.TextRotationAngle = 0R
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView1.HideSelection = False
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(3, 54)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(316, 373)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 280
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DuplicateProcedureToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 26)
        '
        'DuplicateProcedureToolStripMenuItem
        '
        Me.DuplicateProcedureToolStripMenuItem.Image = CType(resources.GetObject("DuplicateProcedureToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DuplicateProcedureToolStripMenuItem.Name = "DuplicateProcedureToolStripMenuItem"
        Me.DuplicateProcedureToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.DuplicateProcedureToolStripMenuItem.Text = "Duplicate Procedure"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "PageRed.png")
        Me.ImageList1.Images.SetKeyName(1, "Page.png")
        Me.ImageList1.Images.SetKeyName(2, "PageGreenRed.png")
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtProcName
        '
        Me.txtProcName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtProcName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtProcName.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtProcName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtProcName.Location = New System.Drawing.Point(22, 83)
        Me.txtProcName.MaxLength = 50
        Me.txtProcName.Name = "txtProcName"
        Me.txtProcName.Size = New System.Drawing.Size(243, 20)
        Me.txtProcName.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtProcName, "Procedure Name")
        '
        'txtProcDescription
        '
        Me.txtProcDescription.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtProcDescription, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtProcDescription.Location = New System.Drawing.Point(22, 144)
        Me.txtProcDescription.MaxLength = 250
        Me.txtProcDescription.Multiline = True
        Me.txtProcDescription.Name = "txtProcDescription"
        Me.txtProcDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProcDescription.Size = New System.Drawing.Size(425, 40)
        Me.txtProcDescription.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.txtProcDescription, "Procedure Description")
        '
        'CheckBoxActiveInd
        '
        Me.CheckBoxActiveInd.AutoSize = True
        Me.CheckBoxActiveInd.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxActiveInd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxActiveInd.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.CheckBoxActiveInd, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CheckBoxActiveInd.Location = New System.Drawing.Point(391, 10)
        Me.CheckBoxActiveInd.Name = "CheckBoxActiveInd"
        Me.CheckBoxActiveInd.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxActiveInd.TabIndex = 4
        Me.CheckBoxActiveInd.Text = "Active"
        Me.ToolTip1.SetToolTip(Me.CheckBoxActiveInd, "Procedure Active Indicator")
        Me.CheckBoxActiveInd.UseVisualStyleBackColor = False
        '
        'ComboBoxDiagIDSearch
        '
        Me.ComboBoxDiagIDSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDiagIDSearch.DropDownWidth = 307
        Me.ComboBoxDiagIDSearch.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxDiagIDSearch, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxDiagIDSearch.Location = New System.Drawing.Point(3, 14)
        Me.ComboBoxDiagIDSearch.Name = "ComboBoxDiagIDSearch"
        Me.ComboBoxDiagIDSearch.Size = New System.Drawing.Size(163, 21)
        Me.ComboBoxDiagIDSearch.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.ComboBoxDiagIDSearch, "Diagnostic")
        '
        'TextBoxSearch
        '
        Me.ErrorProvider1.SetIconAlignment(Me.TextBoxSearch, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.TextBoxSearch.Location = New System.Drawing.Point(172, 14)
        Me.TextBoxSearch.MaxLength = 50
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(112, 20)
        Me.TextBoxSearch.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TextBoxSearch, "Procedure Name")
        '
        'ComboBoxDiagID
        '
        Me.ComboBoxDiagID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDiagID.Enabled = False
        Me.ComboBoxDiagID.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxDiagID.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxDiagID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxDiagID.Location = New System.Drawing.Point(22, 36)
        Me.ComboBoxDiagID.Name = "ComboBoxDiagID"
        Me.ComboBoxDiagID.Size = New System.Drawing.Size(425, 21)
        Me.ComboBoxDiagID.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.ComboBoxDiagID, "Diagnostic")
        '
        'txtCode
        '
        Me.txtCode.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtCode, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCode.Location = New System.Drawing.Point(338, 83)
        Me.txtCode.MaxLength = 10
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(68, 20)
        Me.txtCode.TabIndex = 5
        Me.txtCode.Text = "0"
        Me.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtCode, "Procedure Name")
        '
        'txtNFPrice
        '
        Me.txtNFPrice.BackColor = System.Drawing.Color.White
        Me.txtNFPrice.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtNFPrice, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtNFPrice.Location = New System.Drawing.Point(22, 228)
        Me.txtNFPrice.MaxLength = 50
        Me.txtNFPrice.Name = "txtNFPrice"
        Me.txtNFPrice.Size = New System.Drawing.Size(71, 20)
        Me.txtNFPrice.TabIndex = 8
        Me.txtNFPrice.Text = "0"
        Me.txtNFPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtNFPrice, "No Fault Price")
        '
        'txtWCPrice
        '
        Me.txtWCPrice.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtWCPrice, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtWCPrice.Location = New System.Drawing.Point(111, 228)
        Me.txtWCPrice.MaxLength = 50
        Me.txtWCPrice.Name = "txtWCPrice"
        Me.txtWCPrice.Size = New System.Drawing.Size(71, 20)
        Me.txtWCPrice.TabIndex = 9
        Me.txtWCPrice.Text = "0"
        Me.txtWCPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtWCPrice, "Working Comp Price")
        '
        'txtPRPrice
        '
        Me.txtPRPrice.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtPRPrice, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtPRPrice.Location = New System.Drawing.Point(206, 228)
        Me.txtPRPrice.MaxLength = 50
        Me.txtPRPrice.Name = "txtPRPrice"
        Me.txtPRPrice.Size = New System.Drawing.Size(77, 20)
        Me.txtPRPrice.TabIndex = 10
        Me.txtPRPrice.Text = "0"
        Me.txtPRPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtPRPrice, "Private Insurance Price")
        '
        'txtAbbr
        '
        Me.txtAbbr.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtAbbr, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtAbbr.Location = New System.Drawing.Point(274, 83)
        Me.txtAbbr.MaxLength = 50
        Me.txtAbbr.Name = "txtAbbr"
        Me.txtAbbr.Size = New System.Drawing.Size(58, 20)
        Me.txtAbbr.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtAbbr, "Procedure Name")
        '
        'txtModifier
        '
        Me.txtModifier.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtModifier, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtModifier.Location = New System.Drawing.Point(412, 83)
        Me.txtModifier.MaxLength = 2
        Me.txtModifier.Name = "txtModifier"
        Me.txtModifier.Size = New System.Drawing.Size(35, 20)
        Me.txtModifier.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtModifier, "Procedure Name")
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 20
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 20
        Me.ToolTip1.ReshowDelay = 4
        Me.ToolTip1.ShowAlways = True
        '
        'TextBoxSearchDiagnos
        '
        Me.TextBoxSearchDiagnos.Enabled = False
        Me.TextBoxSearchDiagnos.Location = New System.Drawing.Point(66, 14)
        Me.TextBoxSearchDiagnos.Name = "TextBoxSearchDiagnos"
        Me.TextBoxSearchDiagnos.Size = New System.Drawing.Size(215, 20)
        Me.TextBoxSearchDiagnos.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.TextBoxSearchDiagnos, "Search ICDCode / ICDDescription / ICDGroup")
        '
        'cboMinDays
        '
        Me.cboMinDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMinDays.Enabled = False
        Me.cboMinDays.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboMinDays.FormattingEnabled = True
        Me.cboMinDays.Location = New System.Drawing.Point(302, 228)
        Me.cboMinDays.Name = "cboMinDays"
        Me.cboMinDays.Size = New System.Drawing.Size(50, 21)
        Me.cboMinDays.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.cboMinDays, "Minimum Days From The DOA")
        '
        'cboInterval
        '
        Me.cboInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInterval.Enabled = False
        Me.cboInterval.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboInterval.FormattingEnabled = True
        Me.cboInterval.Location = New System.Drawing.Point(367, 228)
        Me.cboInterval.Name = "cboInterval"
        Me.cboInterval.Size = New System.Drawing.Size(80, 21)
        Me.cboInterval.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.cboInterval, "Minimum Interval Between Procedures")
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.Image = CType(resources.GetObject("ButtonRefresh.Image"), System.Drawing.Image)
        Me.ButtonRefresh.Location = New System.Drawing.Point(290, 10)
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Size = New System.Drawing.Size(27, 24)
        Me.ButtonRefresh.TabIndex = 283
        Me.ToolTip1.SetToolTip(Me.ButtonRefresh, "Refresh")
        Me.ButtonRefresh.UseVisualStyleBackColor = True
        '
        'picNFPrice
        '
        Me.picNFPrice.BackColor = System.Drawing.Color.Transparent
        Me.picNFPrice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picNFPrice.Image = CType(resources.GetObject("picNFPrice.Image"), System.Drawing.Image)
        Me.picNFPrice.Location = New System.Drawing.Point(82, 213)
        Me.picNFPrice.Name = "picNFPrice"
        Me.picNFPrice.Size = New System.Drawing.Size(11, 10)
        Me.picNFPrice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picNFPrice.TabIndex = 338
        Me.picNFPrice.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picNFPrice, "Procedures with NF Price set to 0 will be inaccessible for NF cases")
        Me.picNFPrice.Visible = False
        '
        'picWCPrice
        '
        Me.picWCPrice.BackColor = System.Drawing.Color.Transparent
        Me.picWCPrice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picWCPrice.Image = CType(resources.GetObject("picWCPrice.Image"), System.Drawing.Image)
        Me.picWCPrice.Location = New System.Drawing.Point(171, 213)
        Me.picWCPrice.Name = "picWCPrice"
        Me.picWCPrice.Size = New System.Drawing.Size(11, 10)
        Me.picWCPrice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picWCPrice.TabIndex = 339
        Me.picWCPrice.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picWCPrice, "Procedures with WC Price set to 0 will be inaccessible for WC cases")
        Me.picWCPrice.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 13)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Procedure  / Service Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 13)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Procedure  / Service Description"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.ButtonDuplicate)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.cmdCancel)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Controls.Add(Me.cmdEdit)
        Me.Panel2.Controls.Add(Me.cmdAddNew)
        Me.Panel2.Controls.Add(Me.cmdDelete)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 438)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(797, 34)
        Me.Panel2.TabIndex = 99
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(415, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Batch Pricing"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ButtonDuplicate
        '
        Me.ButtonDuplicate.Image = CType(resources.GetObject("ButtonDuplicate.Image"), System.Drawing.Image)
        Me.ButtonDuplicate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonDuplicate.Location = New System.Drawing.Point(91, 8)
        Me.ButtonDuplicate.Name = "ButtonDuplicate"
        Me.ButtonDuplicate.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDuplicate.TabIndex = 6
        Me.ButtonDuplicate.Text = "Duplicate"
        Me.ButtonDuplicate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonDuplicate.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(714, 8)
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
        Me.cmdCancel.Location = New System.Drawing.Point(334, 8)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
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
        Me.cmdUpdate.Location = New System.Drawing.Point(253, 8)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
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
        Me.cmdEdit.Location = New System.Drawing.Point(172, 8)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.cmdEdit.TabIndex = 2
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Image = CType(resources.GetObject("cmdAddNew.Image"), System.Drawing.Image)
        Me.cmdAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddNew.Location = New System.Drawing.Point(3, 8)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(82, 23)
        Me.cmdAddNew.TabIndex = 1
        Me.cmdAddNew.Text = "Add New"
        Me.cmdAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Enabled = False
        Me.cmdDelete.Location = New System.Drawing.Point(3, 8)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete.TabIndex = 0
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        Me.cmdDelete.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(0, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "Procedures / Services"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(0, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 135
        Me.Label10.Text = "Diagnostic"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(169, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 137
        Me.Label4.Text = "Search"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 139
        Me.Label6.Text = "Diagnostic  Type"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(337, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 143
        Me.Label8.Text = "CPT Code"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 213)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 145
        Me.Label9.Text = "NF Price"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(325, 15)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(465, 412)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtModifier)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.lblNYNFWarning)
        Me.TabPage1.Controls.Add(Me.picWCPrice)
        Me.TabPage1.Controls.Add(Me.picNFPrice)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.cboInterval)
        Me.TabPage1.Controls.Add(Me.cboMinDays)
        Me.TabPage1.Controls.Add(Me.CheckBoxActiveInd)
        Me.TabPage1.Controls.Add(Me.txtAbbr)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.txtPRPrice)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtWCPrice)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.txtComments)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtProcName)
        Me.TabPage1.Controls.Add(Me.txtNFPrice)
        Me.TabPage1.Controls.Add(Me.txtProcDescription)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtCode)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.ComboBoxDiagID)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(457, 386)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Procedure Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(409, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 341
        Me.Label1.Text = "Modifier"
        '
        'lblNYNFWarning
        '
        Me.lblNYNFWarning.AutoSize = True
        Me.lblNYNFWarning.Font = New System.Drawing.Font("Segoe UI Semibold", 8.75!, System.Drawing.FontStyle.Bold)
        Me.lblNYNFWarning.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblNYNFWarning.Location = New System.Drawing.Point(21, 192)
        Me.lblNYNFWarning.Name = "lblNYNFWarning"
        Me.lblNYNFWarning.Size = New System.Drawing.Size(378, 15)
        Me.lblNYNFWarning.TabIndex = 340
        Me.lblNYNFWarning.Text = "Starting from 10/1/2020 NY WC fee schedule will be used for NF cases"
        Me.lblNYNFWarning.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(361, 213)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(90, 13)
        Me.Label18.TabIndex = 286
        Me.Label18.Text = "Schedule Interval"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(271, 67)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(29, 13)
        Me.Label16.TabIndex = 166
        Me.Label16.Text = "Abbr"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(203, 213)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 163
        Me.Label14.Text = "PR Price"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(108, 213)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 161
        Me.Label13.Text = "WC Price"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(19, 252)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 13)
        Me.Label28.TabIndex = 159
        Me.Label28.Text = "Comments"
        '
        'txtComments
        '
        Me.txtComments.Enabled = False
        Me.txtComments.Location = New System.Drawing.Point(22, 268)
        Me.txtComments.MaxLength = 255
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(425, 112)
        Me.txtComments.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(298, 213)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 147
        Me.Label11.Text = "Min Days"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel4)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Controls.Add(Me.ListViewDiagnosisSelected)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.ListViewDiagnosis)
        Me.TabPage2.Controls.Add(Me.LabelProcedureName)
        Me.TabPage2.Controls.Add(Me.TextBoxSearchDiagnos)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(457, 386)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Procedure Diagnosis"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel22)
        Me.Panel4.Location = New System.Drawing.Point(428, 28)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(25, 23)
        Me.Panel4.TabIndex = 132
        '
        'Panel22
        '
        Me.Panel22.BackColor = System.Drawing.Color.White
        Me.Panel22.Dock = System.Windows.Forms.DockStyle.None
        Me.Panel22.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Panel22.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonAddDiagnos})
        Me.Panel22.Location = New System.Drawing.Point(0, 0)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Panel22.Size = New System.Drawing.Size(26, 25)
        Me.Panel22.TabIndex = 0
        Me.Panel22.Text = "ToolStrip2"
        '
        'ButtonAddDiagnos
        '
        Me.ButtonAddDiagnos.BackColor = System.Drawing.Color.White
        Me.ButtonAddDiagnos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonAddDiagnos.Enabled = False
        Me.ButtonAddDiagnos.Image = CType(resources.GetObject("ButtonAddDiagnos.Image"), System.Drawing.Image)
        Me.ButtonAddDiagnos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonAddDiagnos.Name = "ButtonAddDiagnos"
        Me.ButtonAddDiagnos.Size = New System.Drawing.Size(23, 22)
        Me.ButtonAddDiagnos.ToolTipText = "Add New Diagnose "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 131
        Me.Label12.Text = "Search"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ToolStrip1)
        Me.Panel3.Location = New System.Drawing.Point(398, 220)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(55, 23)
        Me.Panel3.TabIndex = 130
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonDn, Me.ToolStripSeparator1, Me.ButtonUp})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(55, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonDn
        '
        Me.ButtonDn.BackColor = System.Drawing.Color.White
        Me.ButtonDn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonDn.Enabled = False
        Me.ButtonDn.Image = CType(resources.GetObject("ButtonDn.Image"), System.Drawing.Image)
        Me.ButtonDn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDn.Name = "ButtonDn"
        Me.ButtonDn.Size = New System.Drawing.Size(23, 22)
        Me.ButtonDn.Text = "Clear Card Front Image"
        Me.ButtonDn.ToolTipText = "Assign Diagnos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonUp
        '
        Me.ButtonUp.BackColor = System.Drawing.Color.White
        Me.ButtonUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonUp.Enabled = False
        Me.ButtonUp.Image = CType(resources.GetObject("ButtonUp.Image"), System.Drawing.Image)
        Me.ButtonUp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonUp.Name = "ButtonUp"
        Me.ButtonUp.Size = New System.Drawing.Size(23, 22)
        Me.ButtonUp.Text = "Rotate Left"
        Me.ButtonUp.ToolTipText = "Remove Diagnos"
        '
        'ListViewDiagnosisSelected
        '
        Me.ListViewDiagnosisSelected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewDiagnosisSelected.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewDiagnosisSelected.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.ListViewDiagnosisSelected.FullRowSelect = True
        Me.ListViewDiagnosisSelected.GridLines = True
        Me.ListViewDiagnosisSelected.HideSelection = False
        Me.ListViewDiagnosisSelected.LargeImageList = Me.ImageList2
        Me.ListViewDiagnosisSelected.Location = New System.Drawing.Point(19, 245)
        Me.ListViewDiagnosisSelected.MultiSelect = False
        Me.ListViewDiagnosisSelected.Name = "ListViewDiagnosisSelected"
        Me.ListViewDiagnosisSelected.Size = New System.Drawing.Size(435, 138)
        Me.ListViewDiagnosisSelected.SmallImageList = Me.ImageList2
        Me.ListViewDiagnosisSelected.TabIndex = 2
        Me.ListViewDiagnosisSelected.UseCompatibleStateImageBehavior = False
        Me.ListViewDiagnosisSelected.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "ICDCode"
        Me.ColumnHeader5.Width = 93
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "ICDDescription"
        Me.ColumnHeader6.Width = 216
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "ICDGroup"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "ComputerRed.png")
        Me.ImageList2.Images.SetKeyName(1, "Computer.png")
        Me.ImageList2.Images.SetKeyName(2, "SORT1")
        Me.ImageList2.Images.SetKeyName(3, "SORT2")
        Me.ImageList2.Images.SetKeyName(4, "SORT0")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Diagnosis"
        '
        'ListViewDiagnosis
        '
        Me.ListViewDiagnosis.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewDiagnosis.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewDiagnosis.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListViewDiagnosis.FullRowSelect = True
        Me.ListViewDiagnosis.GridLines = True
        Me.ListViewDiagnosis.HideSelection = False
        Me.ListViewDiagnosis.LargeImageList = Me.ImageList2
        Me.ListViewDiagnosis.Location = New System.Drawing.Point(19, 54)
        Me.ListViewDiagnosis.MultiSelect = False
        Me.ListViewDiagnosis.Name = "ListViewDiagnosis"
        Me.ListViewDiagnosis.Size = New System.Drawing.Size(434, 160)
        Me.ListViewDiagnosis.SmallImageList = Me.ImageList2
        Me.ListViewDiagnosis.TabIndex = 1
        Me.ListViewDiagnosis.UseCompatibleStateImageBehavior = False
        Me.ListViewDiagnosis.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ICDCode"
        Me.ColumnHeader2.Width = 93
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "ICDDescription"
        Me.ColumnHeader3.Width = 216
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "ICDGroup"
        '
        'LabelProcedureName
        '
        Me.LabelProcedureName.AutoSize = True
        Me.LabelProcedureName.Location = New System.Drawing.Point(19, 229)
        Me.LabelProcedureName.Name = "LabelProcedureName"
        Me.LabelProcedureName.Size = New System.Drawing.Size(39, 13)
        Me.LabelProcedureName.TabIndex = 4
        Me.LabelProcedureName.Text = "Label7"
        '
        'Timer2
        '
        Me.Timer2.Interval = 250
        '
        'ToolTip2
        '
        Me.ToolTip2.AutomaticDelay = 20
        Me.ToolTip2.AutoPopDelay = 25000
        Me.ToolTip2.BackColor = System.Drawing.Color.Crimson
        Me.ToolTip2.InitialDelay = 20
        Me.ToolTip2.ReshowDelay = 4
        Me.ToolTip2.ShowAlways = True
        Me.ToolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip2.ToolTipTitle = "Refering Initial Evaluation"
        '
        'ImageListInfo
        '
        Me.ImageListInfo.ImageStream = CType(resources.GetObject("ImageListInfo.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListInfo.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListInfo.Images.SetKeyName(0, "GREEN")
        Me.ImageListInfo.Images.SetKeyName(1, "RED")
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(751, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 282
        Me.PictureBox1.TabStop = False
        '
        'ContextMenuStripFormulaUpdate
        '
        Me.ContextMenuStripFormulaUpdate.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemUpdate, Me.ToolStripSeparator2, Me.MenuItemUpdateAll})
        Me.ContextMenuStripFormulaUpdate.Name = "ContextMenuStripFormulaUpdate"
        Me.ContextMenuStripFormulaUpdate.Size = New System.Drawing.Size(137, 64)
        '
        'MenuItemUpdate
        '
        Me.MenuItemUpdate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MenuItemUpdate.Name = "MenuItemUpdate"
        Me.MenuItemUpdate.Size = New System.Drawing.Size(136, 22)
        Me.MenuItemUpdate.Text = "Update"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Margin = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(133, 6)
        '
        'MenuItemUpdateAll
        '
        Me.MenuItemUpdateAll.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MenuItemUpdateAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MenuItemUpdateAll.Name = "MenuItemUpdateAll"
        Me.MenuItemUpdateAll.Size = New System.Drawing.Size(136, 22)
        Me.MenuItemUpdateAll.Text = "Update All"
        '
        'frmProcedureMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(797, 472)
        Me.Controls.Add(Me.ButtonRefresh)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ComboBoxDiagIDSearch)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxSearch)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProcedureMaintenance"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Procedures Maintenance"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picNFPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picWCPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel22.ResumeLayout(False)
        Me.Panel22.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripFormulaUpdate.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProcName As System.Windows.Forms.TextBox
    Friend WithEvents txtProcDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxActiveInd As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDiagIDSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxDiagID As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNFPrice As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents LabelProcedureName As System.Windows.Forms.Label
    Friend WithEvents TextBoxSearchDiagnos As System.Windows.Forms.TextBox
    Friend WithEvents ListViewDiagnosisSelected As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ListViewDiagnosis As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonDn As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonUp As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel22 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonAddDiagnos As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPRPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtWCPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtAbbr As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ImageListInfo As System.Windows.Forms.ImageList
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboInterval As System.Windows.Forms.ComboBox
    Friend WithEvents cboMinDays As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DuplicateProcedureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonDuplicate As System.Windows.Forms.Button
    Friend WithEvents ButtonRefresh As System.Windows.Forms.Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ContextMenuStripFormulaUpdate As ContextMenuStrip
    Friend WithEvents MenuItemUpdate As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents MenuItemUpdateAll As ToolStripMenuItem
    Friend WithEvents picWCPrice As PictureBox
    Friend WithEvents picNFPrice As PictureBox
    Friend WithEvents lblNYNFWarning As Label
    Friend WithEvents txtModifier As TextBox
    Friend WithEvents Label1 As Label
End Class
