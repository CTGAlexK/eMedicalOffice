<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportPatientInfo
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
        FormsCollection.Forms.Remove(Me)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportPatientInfo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.lblPrinter = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ImageListProcedures = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.ListViewPatients = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComboBoxSearchCaseStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TimerLoad = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CheckBoxShowComments = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CheckBoxShowProcedures = New System.Windows.Forms.CheckBox()
        Me.CheckBoxShowBills = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.LabelFound = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.ComboBoxSearchCaseType = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PanelWait = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ContextMenuStrip1.SuspendLayout
        Me.Panel3.SuspendLayout
        Me.Panel2.SuspendLayout
        Me.PanelWait.SuspendLayout
        CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label42)
        Me.Panel1.Controls.Add(Me.lblPrinter)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(994, 34)
        Me.Panel1.TabIndex = 100
        '
        'Label42
        '
        Me.Label42.AutoSize = true
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.Label42.Location = New System.Drawing.Point(12, 9)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(162, 13)
        Me.Label42.TabIndex = 2
        Me.Label42.Text = "Patients Information Report"
        '
        'lblPrinter
        '
        Me.lblPrinter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblPrinter.BackColor = System.Drawing.Color.Transparent
        Me.lblPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblPrinter.ForeColor = System.Drawing.Color.Black
        Me.lblPrinter.Location = New System.Drawing.Point(294, 9)
        Me.lblPrinter.Name = "lblPrinter"
        Me.lblPrinter.Size = New System.Drawing.Size(656, 16)
        Me.lblPrinter.TabIndex = 13
        Me.lblPrinter.Text = "Printer: Default Printer"
        Me.lblPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"),System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(956, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 34)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = false
        '
        'ImageListProcedures
        '
        Me.ImageListProcedures.ImageStream = CType(resources.GetObject("ImageListProcedures.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListProcedures.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListProcedures.Images.SetKeyName(0, "UnChecked.gif")
        Me.ImageListProcedures.Images.SetKeyName(1, "Checked.gif")
        Me.ImageListProcedures.Images.SetKeyName(2, "CheckedMid.gif")
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "UserBlue16.png")
        Me.ImageList2.Images.SetKeyName(1, "UserOrange16.png")
        Me.ImageList2.Images.SetKeyName(2, "UserRed16.png")
        Me.ImageList2.Images.SetKeyName(3, "UserRed16.png")
        Me.ImageList2.Images.SetKeyName(4, "UserRed16.png")
        Me.ImageList2.Images.SetKeyName(5, "SORT1")
        Me.ImageList2.Images.SetKeyName(6, "SORT2")
        Me.ImageList2.Images.SetKeyName(7, "SORT0")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "UserBlue.png")
        Me.ImageList1.Images.SetKeyName(1, "UserOrange.png")
        Me.ImageList1.Images.SetKeyName(2, "UserRed.png")
        Me.ImageList1.Images.SetKeyName(3, "UserRed.png")
        Me.ImageList1.Images.SetKeyName(4, "UserRed.png")
        Me.ImageList1.Images.SetKeyName(5, "SORT1")
        Me.ImageList1.Images.SetKeyName(6, "SORT2")
        Me.ImageList1.Images.SetKeyName(7, "SORT0")
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.Location = New System.Drawing.Point(6, 20)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(162, 20)
        Me.TextBoxSearch.TabIndex = 1
        '
        'ListViewPatients
        '
        Me.ListViewPatients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.ListViewPatients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewPatients.CheckBoxes = true
        Me.ListViewPatients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListViewPatients.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListViewPatients.FullRowSelect = true
        Me.ListViewPatients.GridLines = true
        Me.ListViewPatients.HideSelection = false
        Me.ListViewPatients.LargeImageList = Me.ImageList2
        Me.ListViewPatients.Location = New System.Drawing.Point(6, 87)
        Me.ListViewPatients.MultiSelect = false
        Me.ListViewPatients.Name = "ListViewPatients"
        Me.ListViewPatients.Size = New System.Drawing.Size(262, 489)
        Me.ListViewPatients.SmallImageList = Me.ImageList2
        Me.ListViewPatients.TabIndex = 2
        Me.ListViewPatients.UseCompatibleStateImageBehavior = false
        Me.ListViewPatients.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "ID"
        Me.ColumnHeader7.Width = 45
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Patient Name"
        Me.ColumnHeader8.Width = 180
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.ToolStripSeparator1, Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(140, 54)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.SelectAllToolStripMenuItem.Text = "Check All"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(136, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.ToolStripMenuItem1.Text = "UnCheck All"
        '
        'ComboBoxSearchCaseStatus
        '
        Me.ComboBoxSearchCaseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSearchCaseStatus.FormattingEnabled = true
        Me.ComboBoxSearchCaseStatus.Location = New System.Drawing.Point(174, 19)
        Me.ComboBoxSearchCaseStatus.Name = "ComboBoxSearchCaseStatus"
        Me.ComboBoxSearchCaseStatus.Size = New System.Drawing.Size(130, 21)
        Me.ComboBoxSearchCaseStatus.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(171, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 186
        Me.Label1.Text = "Case Status"
        '
        'TimerLoad
        '
        '
        'Timer2
        '
        Me.Timer2.Interval = 250
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"),System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(870, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 41)
        Me.Button1.TabIndex = 191
        Me.Button1.Text = "Load Report"
        Me.ToolTip1.SetToolTip(Me.Button1, "Load Report")
        Me.Button1.UseVisualStyleBackColor = true
        '
        'Label88
        '
        Me.Label88.BackColor = System.Drawing.Color.Transparent
        Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 14!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label88.ForeColor = System.Drawing.Color.Red
        Me.Label88.Location = New System.Drawing.Point(101, 3)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(12, 34)
        Me.Label88.TabIndex = 277
        Me.Label88.Text = "*"
        Me.ToolTip1.SetToolTip(Me.Label88, "Specify Patient Number Or Patient First Name or Patient Name.  Type Start To Show"& _ 
        " All Patients")
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.CheckBoxShowComments)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.CheckBoxShowProcedures)
        Me.Panel3.Controls.Add(Me.CheckBoxShowBills)
        Me.Panel3.Controls.Add(Me.btnPrint)
        Me.Panel3.Controls.Add(Me.cmdClose)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 582)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(994, 34)
        Me.Panel3.TabIndex = 103
        '
        'CheckBoxShowComments
        '
        Me.CheckBoxShowComments.AutoSize = True
        Me.CheckBoxShowComments.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxShowComments.ForeColor = System.Drawing.Color.White
        Me.CheckBoxShowComments.Location = New System.Drawing.Point(466, 11)
        Me.CheckBoxShowComments.Name = "CheckBoxShowComments"
        Me.CheckBoxShowComments.Size = New System.Drawing.Size(105, 17)
        Me.CheckBoxShowComments.TabIndex = 32
        Me.CheckBoxShowComments.Text = "Show Comments"
        Me.CheckBoxShowComments.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(173, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(81, 24)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "Fax"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(86, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 24)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "Email"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CheckBoxShowProcedures
        '
        Me.CheckBoxShowProcedures.AutoSize = True
        Me.CheckBoxShowProcedures.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxShowProcedures.ForeColor = System.Drawing.Color.White
        Me.CheckBoxShowProcedures.Location = New System.Drawing.Point(354, 11)
        Me.CheckBoxShowProcedures.Name = "CheckBoxShowProcedures"
        Me.CheckBoxShowProcedures.Size = New System.Drawing.Size(110, 17)
        Me.CheckBoxShowProcedures.TabIndex = 29
        Me.CheckBoxShowProcedures.Text = "Show Procedures"
        Me.CheckBoxShowProcedures.UseVisualStyleBackColor = False
        '
        'CheckBoxShowBills
        '
        Me.CheckBoxShowBills.AutoSize = True
        Me.CheckBoxShowBills.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxShowBills.ForeColor = System.Drawing.Color.White
        Me.CheckBoxShowBills.Location = New System.Drawing.Point(274, 11)
        Me.CheckBoxShowBills.Name = "CheckBoxShowBills"
        Me.CheckBoxShowBills.Size = New System.Drawing.Size(74, 17)
        Me.CheckBoxShowBills.TabIndex = 28
        Me.CheckBoxShowBills.Text = "Show Bills"
        Me.CheckBoxShowBills.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.Location = New System.Drawing.Point(6, 7)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(74, 24)
        Me.btnPrint.TabIndex = 27
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdClose.Location = New System.Drawing.Point(910, 7)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 24)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'LabelFound
        '
        Me.LabelFound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelFound.BackColor = System.Drawing.Color.Transparent
        Me.LabelFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFound.ForeColor = System.Drawing.Color.Black
        Me.LabelFound.Location = New System.Drawing.Point(750, 18)
        Me.LabelFound.Name = "LabelFound"
        Me.LabelFound.Size = New System.Drawing.Size(114, 13)
        Me.LabelFound.TabIndex = 252
        Me.LabelFound.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.DisplayBackgroundEdge = False
        Me.CrystalReportViewer1.EnableDrillDown = False
        Me.CrystalReportViewer1.EnableToolTips = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(274, 87)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowGotoPageButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowPrintButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.ShowTextSearchButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(711, 489)
        Me.CrystalReportViewer1.TabIndex = 190
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(6, 4)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(149, 13)
        Me.Label39.TabIndex = 276
        Me.Label39.Text = "Find Patient  [ Type     For All ]"
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.BackColor = System.Drawing.Color.Transparent
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.Black
        Me.Label90.Location = New System.Drawing.Point(310, 4)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(58, 13)
        Me.Label90.TabIndex = 279
        Me.Label90.Text = "Case Type"
        '
        'ComboBoxSearchCaseType
        '
        Me.ComboBoxSearchCaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSearchCaseType.FormattingEnabled = True
        Me.ComboBoxSearchCaseType.Location = New System.Drawing.Point(310, 20)
        Me.ComboBoxSearchCaseType.Name = "ComboBoxSearchCaseType"
        Me.ComboBoxSearchCaseType.Size = New System.Drawing.Size(122, 21)
        Me.ComboBoxSearchCaseType.TabIndex = 278
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.LabelFound)
        Me.Panel2.Controls.Add(Me.TextBoxSearch)
        Me.Panel2.Controls.Add(Me.Label88)
        Me.Panel2.Controls.Add(Me.Label90)
        Me.Panel2.Controls.Add(Me.Label39)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.ComboBoxSearchCaseType)
        Me.Panel2.Controls.Add(Me.ComboBoxSearchCaseStatus)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(994, 47)
        Me.Panel2.TabIndex = 280
        '
        'PanelWait
        '
        Me.PanelWait.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelWait.BackColor = System.Drawing.Color.White
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.PictureBox3)
        Me.PanelWait.Controls.Add(Me.PictureBox2)
        Me.PanelWait.Controls.Add(Me.Label3)
        Me.PanelWait.Location = New System.Drawing.Point(557, 324)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(196, 37)
        Me.PanelWait.TabIndex = 281
        Me.PanelWait.Visible = false
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"),System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(26, 22)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = false
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"),System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 22)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(194, 13)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = false
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(27, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(182, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Loading Report. Please Wait..."
        '
        'frmReportPatientInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(994, 616)
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.ListViewPatients)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = true
        Me.MinimizeBox = false
        Me.MinimumSize = New System.Drawing.Size(1000, 640)
        Me.Name = "frmReportPatientInfo"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Patient Information report"
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ContextMenuStrip1.ResumeLayout(false)
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        Me.PanelWait.ResumeLayout(false)
        CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private Loading As Boolean
    Public Sub New()
        Loading = True
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        FormsCollection.Forms.Add(Me)
        ' Add any initialization after the InitializeComponent() call.

        Loading = False
    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents ListViewPatients As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxSearchCaseStatus As System.Windows.Forms.ComboBox
    Friend WithEvents TimerLoad As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ImageListProcedures As System.Windows.Forms.ImageList
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxSearchCaseType As System.Windows.Forms.ComboBox
    Friend WithEvents LabelFound As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CheckBoxShowComments As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxShowProcedures As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxShowBills As System.Windows.Forms.CheckBox
    Friend WithEvents lblPrinter As System.Windows.Forms.Label
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
