<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReadings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReadings))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.ButtonUnlock = New System.Windows.Forms.Button()
        Me.ButtonShowPatientInfo = New System.Windows.Forms.Button()
        Me.ButtonAddUpdate = New System.Windows.Forms.Button()
        Me.ButtonShowReport = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.ListViewReadings = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuShowSelectedPatientInfo1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowReadingReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddUpdateReadingReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimeReadingTo = New System.Windows.Forms.DateTimePicker()
        Me.DateTimeReadingFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboCaseStatus = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboTreatingProvider = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.ButtonFind = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboReadingStatus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LabelCount = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1052, 36)
        Me.Panel1.TabIndex = 197
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1009, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(43, 36)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Procedure Readings Report"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.btnPrint)
        Me.Panel2.Controls.Add(Me.ButtonUnlock)
        Me.Panel2.Controls.Add(Me.ButtonShowPatientInfo)
        Me.Panel2.Controls.Add(Me.ButtonAddUpdate)
        Me.Panel2.Controls.Add(Me.ButtonShowReport)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 576)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1052, 34)
        Me.Panel2.TabIndex = 199
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(174, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 24)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Fax"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(87, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 24)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Email"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.Location = New System.Drawing.Point(6, 5)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 24)
        Me.btnPrint.TabIndex = 12
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'ButtonUnlock
        '
        Me.ButtonUnlock.ForeColor = System.Drawing.Color.OrangeRed
        Me.ButtonUnlock.Image = CType(resources.GetObject("ButtonUnlock.Image"), System.Drawing.Image)
        Me.ButtonUnlock.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonUnlock.Location = New System.Drawing.Point(630, 5)
        Me.ButtonUnlock.Name = "ButtonUnlock"
        Me.ButtonUnlock.Size = New System.Drawing.Size(115, 24)
        Me.ButtonUnlock.TabIndex = 11
        Me.ButtonUnlock.Text = "Unlock Reading"
        Me.ButtonUnlock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonUnlock.UseVisualStyleBackColor = True
        '
        'ButtonShowPatientInfo
        '
        Me.ButtonShowPatientInfo.Image = CType(resources.GetObject("ButtonShowPatientInfo.Image"), System.Drawing.Image)
        Me.ButtonShowPatientInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonShowPatientInfo.Location = New System.Drawing.Point(261, 5)
        Me.ButtonShowPatientInfo.Name = "ButtonShowPatientInfo"
        Me.ButtonShowPatientInfo.Size = New System.Drawing.Size(96, 24)
        Me.ButtonShowPatientInfo.TabIndex = 10
        Me.ButtonShowPatientInfo.Text = "Show Patient"
        Me.ButtonShowPatientInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonShowPatientInfo.UseVisualStyleBackColor = True
        '
        'ButtonAddUpdate
        '
        Me.ButtonAddUpdate.ForeColor = System.Drawing.Color.Black
        Me.ButtonAddUpdate.Image = CType(resources.GetObject("ButtonAddUpdate.Image"), System.Drawing.Image)
        Me.ButtonAddUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAddUpdate.Location = New System.Drawing.Point(473, 5)
        Me.ButtonAddUpdate.Name = "ButtonAddUpdate"
        Me.ButtonAddUpdate.Size = New System.Drawing.Size(151, 24)
        Me.ButtonAddUpdate.TabIndex = 9
        Me.ButtonAddUpdate.Text = "Add / Update Reading"
        Me.ButtonAddUpdate.UseVisualStyleBackColor = True
        '
        'ButtonShowReport
        '
        Me.ButtonShowReport.Image = CType(resources.GetObject("ButtonShowReport.Image"), System.Drawing.Image)
        Me.ButtonShowReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonShowReport.Location = New System.Drawing.Point(363, 5)
        Me.ButtonShowReport.Name = "ButtonShowReport"
        Me.ButtonShowReport.Size = New System.Drawing.Size(104, 24)
        Me.ButtonShowReport.TabIndex = 5
        Me.ButtonShowReport.Text = "Show Reading"
        Me.ButtonShowReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonShowReport.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(970, 5)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 24)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.BackColor = System.Drawing.Color.Transparent
        Me.Label87.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.ForeColor = System.Drawing.Color.Black
        Me.Label87.Location = New System.Drawing.Point(3, 88)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(95, 13)
        Me.Label87.TabIndex = 201
        Me.Label87.Text = "Patient's Readings"
        '
        'ListViewReadings
        '
        Me.ListViewReadings.AllowColumnReorder = True
        Me.ListViewReadings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewReadings.BackColor = System.Drawing.Color.White
        Me.ListViewReadings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewReadings.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader24, Me.ColumnHeader23, Me.ColumnHeader25, Me.ColumnHeader3, Me.ColumnHeader26, Me.ColumnHeader2})
        Me.ListViewReadings.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListViewReadings.FullRowSelect = True
        Me.ListViewReadings.GridLines = True
        Me.ListViewReadings.HideSelection = False
        Me.ListViewReadings.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.ListViewReadings.Location = New System.Drawing.Point(6, 104)
        Me.ListViewReadings.MultiSelect = False
        Me.ListViewReadings.Name = "ListViewReadings"
        Me.ListViewReadings.Size = New System.Drawing.Size(1039, 466)
        Me.ListViewReadings.SmallImageList = Me.ImageList2
        Me.ListViewReadings.TabIndex = 200
        Me.ListViewReadings.UseCompatibleStateImageBehavior = False
        Me.ListViewReadings.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Patient"
        Me.ColumnHeader1.Width = 117
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Service DT"
        Me.ColumnHeader24.Width = 96
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Procedure"
        Me.ColumnHeader23.Width = 128
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "By"
        Me.ColumnHeader25.Width = 134
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Dictation DT"
        Me.ColumnHeader3.Width = 108
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "Reading DT"
        Me.ColumnHeader26.Width = 131
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Unlocked"
        Me.ColumnHeader2.Width = 84
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowSelectedPatientInfo1, Me.ShowReadingReportToolStripMenuItem, Me.AddUpdateReadingReportToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(219, 70)
        '
        'mnuShowSelectedPatientInfo1
        '
        Me.mnuShowSelectedPatientInfo1.Image = CType(resources.GetObject("mnuShowSelectedPatientInfo1.Image"), System.Drawing.Image)
        Me.mnuShowSelectedPatientInfo1.Name = "mnuShowSelectedPatientInfo1"
        Me.mnuShowSelectedPatientInfo1.Size = New System.Drawing.Size(218, 22)
        Me.mnuShowSelectedPatientInfo1.Text = "Show Patient's Information"
        '
        'ShowReadingReportToolStripMenuItem
        '
        Me.ShowReadingReportToolStripMenuItem.Image = CType(resources.GetObject("ShowReadingReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ShowReadingReportToolStripMenuItem.Name = "ShowReadingReportToolStripMenuItem"
        Me.ShowReadingReportToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ShowReadingReportToolStripMenuItem.Text = "Show Reading Report"
        '
        'AddUpdateReadingReportToolStripMenuItem
        '
        Me.AddUpdateReadingReportToolStripMenuItem.Image = CType(resources.GetObject("AddUpdateReadingReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddUpdateReadingReportToolStripMenuItem.Name = "AddUpdateReadingReportToolStripMenuItem"
        Me.AddUpdateReadingReportToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.AddUpdateReadingReportToolStripMenuItem.Text = "Add Update reading Report"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Changes.png")
        Me.ImageList2.Images.SetKeyName(1, "SORT1")
        Me.ImageList2.Images.SetKeyName(2, "SORT2")
        Me.ImageList2.Images.SetKeyName(3, "SORT0")
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.DateTimeReadingTo)
        Me.Panel3.Controls.Add(Me.DateTimeReadingFrom)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.cboCaseStatus)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.cboTreatingProvider)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.DateTimePickerTo)
        Me.Panel3.Controls.Add(Me.DateTimePickerFrom)
        Me.Panel3.Controls.Add(Me.ButtonClear)
        Me.Panel3.Controls.Add(Me.ButtonFind)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.cboReadingStatus)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtSearch)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1052, 49)
        Me.Panel3.TabIndex = 203
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(798, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 275
        Me.Label8.Text = "Reading DT To"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(694, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 274
        Me.Label9.Text = "Reading DT From"
        '
        'DateTimeReadingTo
        '
        Me.DateTimeReadingTo.Checked = False
        Me.DateTimeReadingTo.CustomFormat = "MM/dd/yyyy"
        Me.DateTimeReadingTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeReadingTo.Location = New System.Drawing.Point(801, 25)
        Me.DateTimeReadingTo.Name = "DateTimeReadingTo"
        Me.DateTimeReadingTo.ShowCheckBox = True
        Me.DateTimeReadingTo.Size = New System.Drawing.Size(98, 20)
        Me.DateTimeReadingTo.TabIndex = 273
        '
        'DateTimeReadingFrom
        '
        Me.DateTimeReadingFrom.Checked = False
        Me.DateTimeReadingFrom.CustomFormat = "MM/dd/yyyy"
        Me.DateTimeReadingFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeReadingFrom.Location = New System.Drawing.Point(697, 24)
        Me.DateTimeReadingFrom.Name = "DateTimeReadingFrom"
        Me.DateTimeReadingFrom.ShowCheckBox = True
        Me.DateTimeReadingFrom.Size = New System.Drawing.Size(98, 20)
        Me.DateTimeReadingFrom.TabIndex = 272
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(123, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 271
        Me.Label6.Text = "Case Status"
        '
        'cboCaseStatus
        '
        Me.cboCaseStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboCaseStatus.BackColor = System.Drawing.Color.White
        Me.cboCaseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaseStatus.DropDownWidth = 300
        Me.cboCaseStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCaseStatus.ForeColor = System.Drawing.Color.Black
        Me.cboCaseStatus.FormattingEnabled = True
        Me.cboCaseStatus.Location = New System.Drawing.Point(126, 23)
        Me.cboCaseStatus.Name = "cboCaseStatus"
        Me.cboCaseStatus.Size = New System.Drawing.Size(76, 21)
        Me.cboCaseStatus.TabIndex = 270
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(201, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 269
        Me.Label5.Text = "Treating Provider"
        '
        'cboTreatingProvider
        '
        Me.cboTreatingProvider.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboTreatingProvider.BackColor = System.Drawing.Color.White
        Me.cboTreatingProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTreatingProvider.DropDownWidth = 300
        Me.cboTreatingProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTreatingProvider.ForeColor = System.Drawing.Color.Black
        Me.cboTreatingProvider.FormattingEnabled = True
        Me.cboTreatingProvider.Location = New System.Drawing.Point(204, 23)
        Me.cboTreatingProvider.Name = "cboTreatingProvider"
        Me.cboTreatingProvider.Size = New System.Drawing.Size(180, 21)
        Me.cboTreatingProvider.TabIndex = 268
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(590, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 267
        Me.Label4.Text = "Service DT To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(486, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 266
        Me.Label3.Text = "Service DT From"
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTo.Location = New System.Drawing.Point(593, 24)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.ShowCheckBox = True
        Me.DateTimePickerTo.Size = New System.Drawing.Size(98, 20)
        Me.DateTimePickerTo.TabIndex = 265
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(489, 23)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.ShowCheckBox = True
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(98, 20)
        Me.DateTimePickerFrom.TabIndex = 264
        '
        'ButtonClear
        '
        Me.ButtonClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClear.Image = CType(resources.GetObject("ButtonClear.Image"), System.Drawing.Image)
        Me.ButtonClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonClear.Location = New System.Drawing.Point(948, 19)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(25, 25)
        Me.ButtonClear.TabIndex = 262
        Me.ButtonClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'ButtonFind
        '
        Me.ButtonFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFind.Image = CType(resources.GetObject("ButtonFind.Image"), System.Drawing.Image)
        Me.ButtonFind.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonFind.Location = New System.Drawing.Point(979, 6)
        Me.ButtonFind.Name = "ButtonFind"
        Me.ButtonFind.Size = New System.Drawing.Size(61, 38)
        Me.ButtonFind.TabIndex = 263
        Me.ButtonFind.Text = "Find   "
        Me.ButtonFind.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(387, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 261
        Me.Label7.Text = "Reading Status"
        '
        'cboReadingStatus
        '
        Me.cboReadingStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboReadingStatus.BackColor = System.Drawing.Color.White
        Me.cboReadingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReadingStatus.DropDownWidth = 300
        Me.cboReadingStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboReadingStatus.ForeColor = System.Drawing.Color.Black
        Me.cboReadingStatus.FormattingEnabled = True
        Me.cboReadingStatus.Location = New System.Drawing.Point(390, 23)
        Me.cboReadingStatus.Name = "cboReadingStatus"
        Me.cboReadingStatus.Size = New System.Drawing.Size(93, 21)
        Me.cboReadingStatus.TabIndex = 260
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(3, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 257
        Me.Label2.Text = "Patient First / Last /  ##"
        '
        'txtSearch
        '
        Me.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtSearch.Location = New System.Drawing.Point(6, 23)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(118, 20)
        Me.txtSearch.TabIndex = 256
        '
        'Timer1
        '
        '
        'LabelCount
        '
        Me.LabelCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelCount.BackColor = System.Drawing.Color.Transparent
        Me.LabelCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCount.ForeColor = System.Drawing.Color.Black
        Me.LabelCount.Location = New System.Drawing.Point(677, 88)
        Me.LabelCount.Name = "LabelCount"
        Me.LabelCount.Size = New System.Drawing.Size(368, 13)
        Me.LabelCount.TabIndex = 204
        Me.LabelCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmReadings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(1052, 610)
        Me.Controls.Add(Me.LabelCount)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label87)
        Me.Controls.Add(Me.ListViewReadings)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "frmReadings"
        Me.Text = "Patient's Procedure Readings"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ButtonShowReport As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents ListViewReadings As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents ButtonFind As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents cboReadingStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ButtonAddUpdate As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowReadingReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddUpdateReadingReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonShowPatientInfo As System.Windows.Forms.Button
    Friend WithEvents mnuShowSelectedPatientInfo1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents cboTreatingProvider As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonUnlock As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents cboCaseStatus As System.Windows.Forms.ComboBox
    Friend WithEvents LabelCount As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DateTimeReadingTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimeReadingFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
