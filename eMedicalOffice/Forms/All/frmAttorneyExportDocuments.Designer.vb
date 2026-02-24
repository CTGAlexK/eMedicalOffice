<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAttorneyDocumentsAccess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAttorneyDocumentsAccess))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBoxLoading = New System.Windows.Forms.PictureBox()
        Me.lblPatient = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblDemo = New System.Windows.Forms.Label()
        Me.cboAttorneysCompanyID = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonSaveToHD = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.ListViewDocs = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RebuildDocumentToolStripMenuItemSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.RebuildDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonEmail = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSaveAs = New System.Windows.Forms.ToolStripButton()
        Me.lblFileSize = New System.Windows.Forms.ToolStripLabel()
        Me.TimerPdfRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.TimerLoadDocuments = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxComments = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkAllPOMs = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PanelDocumentWait = New System.Windows.Forms.Panel()
        Me.Label124 = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.pdfViewer = New PdfiumViewer.PdfViewer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListViewLog = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.CheckBoxAttorney = New System.Windows.Forms.CheckBox()
        Me.PanelAttorney = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelNoMoreCollection = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBoxLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PanelDocumentWait.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.PanelAttorney.SuspendLayout()
        Me.PanelNoMoreCollection.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBoxLoading)
        Me.Panel1.Controls.Add(Me.lblPatient)
        Me.Panel1.Controls.Add(Me.CrystalReportViewer1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblLoading)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1117, 38)
        Me.Panel1.TabIndex = 146
        '
        'PictureBoxLoading
        '
        Me.PictureBoxLoading.Image = CType(resources.GetObject("PictureBoxLoading.Image"), System.Drawing.Image)
        Me.PictureBoxLoading.Location = New System.Drawing.Point(1026, 6)
        Me.PictureBoxLoading.Name = "PictureBoxLoading"
        Me.PictureBoxLoading.Size = New System.Drawing.Size(25, 25)
        Me.PictureBoxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBoxLoading.TabIndex = 210
        Me.PictureBoxLoading.TabStop = False
        Me.PictureBoxLoading.Visible = False
        '
        'lblPatient
        '
        Me.lblPatient.AutoSize = True
        Me.lblPatient.BackColor = System.Drawing.Color.Transparent
        Me.lblPatient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblPatient.Location = New System.Drawing.Point(4, 19)
        Me.lblPatient.Name = "lblPatient"
        Me.lblPatient.Size = New System.Drawing.Size(47, 13)
        Me.lblPatient.TabIndex = 3
        Me.lblPatient.Text = "Patient"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.DisplayBackgroundEdge = False
        Me.CrystalReportViewer1.EnableDrillDown = False
        Me.CrystalReportViewer1.EnableToolTips = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(356, -5)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowGotoPageButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowPrintButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.ShowTextSearchButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(117, 60)
        Me.CrystalReportViewer1.TabIndex = 209
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        Me.CrystalReportViewer1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(196, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Attorney Web Documents Access"
        '
        'lblLoading
        '
        Me.lblLoading.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLoading.BackColor = System.Drawing.Color.Transparent
        Me.lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.Red
        Me.lblLoading.Location = New System.Drawing.Point(403, 13)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(616, 18)
        Me.lblLoading.TabIndex = 4
        Me.lblLoading.Text = "Loading Data. Please Wait..."
        Me.lblLoading.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblLoading.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1064, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(53, 38)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lblDemo
        '
        Me.lblDemo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDemo.BackColor = System.Drawing.Color.Transparent
        Me.lblDemo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblDemo.ForeColor = System.Drawing.Color.Red
        Me.lblDemo.Location = New System.Drawing.Point(162, 12)
        Me.lblDemo.Name = "lblDemo"
        Me.lblDemo.Size = New System.Drawing.Size(771, 13)
        Me.lblDemo.TabIndex = 4
        Me.lblDemo.Text = "DEMO MODE"
        Me.lblDemo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblDemo, "DEMO MODE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "No Updates Allowed." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please contact the Software Developer to obta" &
        "in the proper license to use this function")
        Me.lblDemo.Visible = False
        '
        'cboAttorneysCompanyID
        '
        Me.cboAttorneysCompanyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttorneysCompanyID.DropDownWidth = 300
        Me.cboAttorneysCompanyID.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboAttorneysCompanyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAttorneysCompanyID.ForeColor = System.Drawing.Color.Black
        Me.cboAttorneysCompanyID.FormattingEnabled = True
        Me.cboAttorneysCompanyID.Location = New System.Drawing.Point(61, 5)
        Me.cboAttorneysCompanyID.Name = "cboAttorneysCompanyID"
        Me.cboAttorneysCompanyID.Size = New System.Drawing.Size(345, 21)
        Me.cboAttorneysCompanyID.TabIndex = 249
        Me.ToolTip1.SetToolTip(Me.cboAttorneysCompanyID, "Select and attorney from the list of attorneys which has WEB access.")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(7, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 248
        Me.Label18.Text = "Attorney"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.ButtonSaveToHD)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.lblDemo)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 576)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1117, 34)
        Me.Panel2.TabIndex = 205
        '
        'ButtonSaveToHD
        '
        Me.ButtonSaveToHD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSaveToHD.Image = CType(resources.GetObject("ButtonSaveToHD.Image"), System.Drawing.Image)
        Me.ButtonSaveToHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSaveToHD.Location = New System.Drawing.Point(3, 6)
        Me.ButtonSaveToHD.Name = "ButtonSaveToHD"
        Me.ButtonSaveToHD.Size = New System.Drawing.Size(98, 24)
        Me.ButtonSaveToHD.TabIndex = 5
        Me.ButtonSaveToHD.Text = "Save To HD"
        Me.ButtonSaveToHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButtonSaveToHD, "Save checked files to the local folder")
        Me.ButtonSaveToHD.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(1039, 5)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 24)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.Enabled = False
        Me.cmdUpdate.Image = CType(resources.GetObject("cmdUpdate.Image"), System.Drawing.Image)
        Me.cmdUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdUpdate.Location = New System.Drawing.Point(950, 5)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(83, 24)
        Me.cmdUpdate.TabIndex = 0
        Me.cmdUpdate.Text = "Update Access"
        Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'ListViewDocs
        '
        Me.ListViewDocs.AllowColumnReorder = True
        Me.ListViewDocs.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewDocs.CheckBoxes = True
        Me.ListViewDocs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader9, Me.ColumnHeader7})
        Me.ListViewDocs.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListViewDocs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewDocs.FullRowSelect = True
        Me.ListViewDocs.GridLines = True
        Me.ListViewDocs.HideSelection = False
        Me.ListViewDocs.Location = New System.Drawing.Point(3, 52)
        Me.ListViewDocs.MultiSelect = False
        Me.ListViewDocs.Name = "ListViewDocs"
        Me.ListViewDocs.Size = New System.Drawing.Size(409, 348)
        Me.ListViewDocs.SmallImageList = Me.ImageList1
        Me.ListViewDocs.TabIndex = 206
        Me.ListViewDocs.UseCompatibleStateImageBehavior = False
        Me.ListViewDocs.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Document"
        Me.ColumnHeader1.Width = 193
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Access Granted DT"
        Me.ColumnHeader9.Width = 121
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Status"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.SelectNoneToolStripMenuItem, Me.RebuildDocumentToolStripMenuItemSeparator, Me.RebuildDocumentToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(174, 76)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Image = CType(resources.GetObject("SelectAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SelectAllToolStripMenuItem.Text = "Check All"
        '
        'SelectNoneToolStripMenuItem
        '
        Me.SelectNoneToolStripMenuItem.Name = "SelectNoneToolStripMenuItem"
        Me.SelectNoneToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SelectNoneToolStripMenuItem.Text = "Check None"
        '
        'RebuildDocumentToolStripMenuItemSeparator
        '
        Me.RebuildDocumentToolStripMenuItemSeparator.Name = "RebuildDocumentToolStripMenuItemSeparator"
        Me.RebuildDocumentToolStripMenuItemSeparator.Size = New System.Drawing.Size(170, 6)
        '
        'RebuildDocumentToolStripMenuItem
        '
        Me.RebuildDocumentToolStripMenuItem.Image = CType(resources.GetObject("RebuildDocumentToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RebuildDocumentToolStripMenuItem.Name = "RebuildDocumentToolStripMenuItem"
        Me.RebuildDocumentToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.RebuildDocumentToolStripMenuItem.Text = "Rebuild Document"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "SORT1")
        Me.ImageList1.Images.SetKeyName(1, "SORT2")
        Me.ImageList1.Images.SetKeyName(2, "SORT0")
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripSeparator3, Me.ToolStripButtonEmail, Me.ToolStripButton1, Me.ToolStripButtonSaveAs, Me.lblFileSize})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 415)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip2.Size = New System.Drawing.Size(688, 25)
        Me.ToolStrip2.TabIndex = 208
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripButton2.Text = "Print"
        Me.ToolStripButton2.ToolTipText = "Print Document"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButton3.Text = "Show"
        Me.ToolStripButton3.ToolTipText = "Show Document"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonEmail
        '
        Me.ToolStripButtonEmail.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonEmail.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButtonEmail.Image = CType(resources.GetObject("ToolStripButtonEmail.Image"), System.Drawing.Image)
        Me.ToolStripButtonEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonEmail.Name = "ToolStripButtonEmail"
        Me.ToolStripButtonEmail.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButtonEmail.Text = "Email"
        Me.ToolStripButtonEmail.ToolTipText = "Email Document"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripButton1.Text = "Fax"
        Me.ToolStripButton1.ToolTipText = "Save Document As"
        '
        'ToolStripButtonSaveAs
        '
        Me.ToolStripButtonSaveAs.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonSaveAs.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButtonSaveAs.Image = CType(resources.GetObject("ToolStripButtonSaveAs.Image"), System.Drawing.Image)
        Me.ToolStripButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSaveAs.Name = "ToolStripButtonSaveAs"
        Me.ToolStripButtonSaveAs.Size = New System.Drawing.Size(67, 22)
        Me.ToolStripButtonSaveAs.Text = "Save As"
        Me.ToolStripButtonSaveAs.ToolTipText = "Save Document As"
        '
        'lblFileSize
        '
        Me.lblFileSize.Name = "lblFileSize"
        Me.lblFileSize.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.lblFileSize.Size = New System.Drawing.Size(30, 22)
        '
        'TimerPdfRefresh
        '
        '
        'TimerLoadDocuments
        '
        Me.TimerLoadDocuments.Interval = 500
        '
        'RadioButton2
        '
        Me.RadioButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton2.Location = New System.Drawing.Point(985, 6)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(122, 17)
        Me.RadioButton2.TabIndex = 150
        Me.RadioButton2.Text = "Arbitration On Denial"
        Me.ToolTip1.SetToolTip(Me.RadioButton2, "Request Arbitration Process On Bill Denial")
        Me.RadioButton2.UseVisualStyleBackColor = False
        '
        'RadioButton1
        '
        Me.RadioButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(862, 6)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(117, 17)
        Me.RadioButton1.TabIndex = 149
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Litigation On Denial"
        Me.ToolTip1.SetToolTip(Me.RadioButton1, "Request Litigation Process On Bill Denial")
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(390, 2)
        Me.Button1.Margin = New System.Windows.Forms.Padding(0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(17, 20)
        Me.Button1.TabIndex = 211
        Me.ToolTip1.SetToolTip(Me.Button1, "Delete Bill Comment")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.ListViewDocs)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.TextBoxComments)
        Me.Panel5.Controls.Add(Me.Panel3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 61)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel5.Size = New System.Drawing.Size(415, 483)
        Me.Panel5.TabIndex = 210
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label3)
        Me.Panel7.Controls.Add(Me.Button1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 400)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel7.Size = New System.Drawing.Size(409, 24)
        Me.Panel7.TabIndex = 212
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(254, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 16)
        Me.Label3.TabIndex = 213
        Me.Label3.Text = "Bill comments to attorney"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TextBoxComments
        '
        Me.TextBoxComments.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBoxComments.Location = New System.Drawing.Point(3, 424)
        Me.TextBoxComments.MaxLength = 250
        Me.TextBoxComments.Multiline = True
        Me.TextBoxComments.Name = "TextBoxComments"
        Me.TextBoxComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxComments.Size = New System.Drawing.Size(409, 56)
        Me.TextBoxComments.TabIndex = 209
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.chkAllPOMs)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.cboAttorneysCompanyID)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(409, 49)
        Me.Panel3.TabIndex = 208
        '
        'chkAllPOMs
        '
        Me.chkAllPOMs.AutoSize = True
        Me.chkAllPOMs.Location = New System.Drawing.Point(61, 29)
        Me.chkAllPOMs.Name = "chkAllPOMs"
        Me.chkAllPOMs.Size = New System.Drawing.Size(179, 17)
        Me.chkAllPOMs.TabIndex = 250
        Me.chkAllPOMs.Text = "Show All Patient's Proofs Of Mail"
        Me.chkAllPOMs.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ItemSize = New System.Drawing.Size(102, 26)
        Me.TabControl1.Location = New System.Drawing.Point(415, 67)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(702, 477)
        Me.TabControl1.TabIndex = 211
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PanelDocumentWait)
        Me.TabPage1.Controls.Add(Me.pdfViewer)
        Me.TabPage1.Controls.Add(Me.ToolStrip2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 30)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(694, 443)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Document Preview"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PanelDocumentWait
        '
        Me.PanelDocumentWait.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelDocumentWait.BackColor = System.Drawing.Color.White
        Me.PanelDocumentWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDocumentWait.Controls.Add(Me.Label124)
        Me.PanelDocumentWait.Controls.Add(Me.PictureBox6)
        Me.PanelDocumentWait.Controls.Add(Me.PictureBox7)
        Me.PanelDocumentWait.Controls.Add(Me.Label123)
        Me.PanelDocumentWait.Location = New System.Drawing.Point(239, 196)
        Me.PanelDocumentWait.Name = "PanelDocumentWait"
        Me.PanelDocumentWait.Size = New System.Drawing.Size(216, 55)
        Me.PanelDocumentWait.TabIndex = 376
        Me.PanelDocumentWait.Visible = False
        '
        'Label124
        '
        Me.Label124.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label124.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label124.ForeColor = System.Drawing.Color.White
        Me.Label124.Location = New System.Drawing.Point(-1, 23)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(216, 29)
        Me.Label124.TabIndex = 3
        Me.Label124.Text = "document loading speed depends " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "on document size and network speed." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label124.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(26, 25)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox6.TabIndex = 2
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PictureBox7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox7.Location = New System.Drawing.Point(0, 25)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(214, 28)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox7.TabIndex = 1
        Me.PictureBox7.TabStop = False
        '
        'Label123
        '
        Me.Label123.BackColor = System.Drawing.Color.Transparent
        Me.Label123.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label123.ForeColor = System.Drawing.Color.Black
        Me.Label123.Location = New System.Drawing.Point(27, 5)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(182, 13)
        Me.Label123.TabIndex = 0
        Me.Label123.Text = "Loading Document. Please Wait..."
        '
        'pdfViewer
        '
        Me.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfViewer.Location = New System.Drawing.Point(3, 3)
        Me.pdfViewer.Name = "pdfViewer"
        Me.pdfViewer.ShowBookmarks = False
        Me.pdfViewer.Size = New System.Drawing.Size(688, 412)
        Me.pdfViewer.TabIndex = 371
        Me.pdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitBest
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListViewLog)
        Me.TabPage2.Location = New System.Drawing.Point(4, 30)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(694, 443)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Documents Access Log"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListViewLog
        '
        Me.ListViewLog.AllowColumnReorder = True
        Me.ListViewLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader8, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.ListViewLog.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListViewLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewLog.FullRowSelect = True
        Me.ListViewLog.GridLines = True
        Me.ListViewLog.HideSelection = False
        Me.ListViewLog.Location = New System.Drawing.Point(3, 3)
        Me.ListViewLog.MultiSelect = False
        Me.ListViewLog.Name = "ListViewLog"
        Me.ListViewLog.Size = New System.Drawing.Size(688, 437)
        Me.ListViewLog.TabIndex = 207
        Me.ListViewLog.UseCompatibleStateImageBehavior = False
        Me.ListViewLog.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "##"
        Me.ColumnHeader2.Width = 33
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "BillID"
        Me.ColumnHeader3.Width = 42
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Document"
        Me.ColumnHeader8.Width = 69
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Status"
        Me.ColumnHeader4.Width = 75
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "DT"
        Me.ColumnHeader5.Width = 80
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Changed By"
        Me.ColumnHeader6.Width = 195
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(415, 67)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(5, 477)
        Me.Panel4.TabIndex = 213
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(415, 61)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(702, 6)
        Me.Panel6.TabIndex = 215
        '
        'CheckBoxAttorney
        '
        Me.CheckBoxAttorney.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxAttorney.AutoSize = True
        Me.CheckBoxAttorney.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxAttorney.Checked = True
        Me.CheckBoxAttorney.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxAttorney.Location = New System.Drawing.Point(725, 7)
        Me.CheckBoxAttorney.Name = "CheckBoxAttorney"
        Me.CheckBoxAttorney.Size = New System.Drawing.Size(131, 17)
        Me.CheckBoxAttorney.TabIndex = 151
        Me.CheckBoxAttorney.Text = "Assign Bill To Attorney"
        Me.CheckBoxAttorney.UseVisualStyleBackColor = False
        '
        'PanelAttorney
        '
        Me.PanelAttorney.BackColor = System.Drawing.Color.SandyBrown
        Me.PanelAttorney.Controls.Add(Me.Label1)
        Me.PanelAttorney.Controls.Add(Me.RadioButton2)
        Me.PanelAttorney.Controls.Add(Me.CheckBoxAttorney)
        Me.PanelAttorney.Controls.Add(Me.RadioButton1)
        Me.PanelAttorney.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelAttorney.Location = New System.Drawing.Point(0, 544)
        Me.PanelAttorney.Name = "PanelAttorney"
        Me.PanelAttorney.Size = New System.Drawing.Size(1117, 32)
        Me.PanelAttorney.TabIndex = 216
        Me.PanelAttorney.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 13)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "Assign Bill To Attorney"
        '
        'PanelNoMoreCollection
        '
        Me.PanelNoMoreCollection.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PanelNoMoreCollection.Controls.Add(Me.Label4)
        Me.PanelNoMoreCollection.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelNoMoreCollection.Location = New System.Drawing.Point(0, 38)
        Me.PanelNoMoreCollection.Name = "PanelNoMoreCollection"
        Me.PanelNoMoreCollection.Size = New System.Drawing.Size(1117, 23)
        Me.PanelNoMoreCollection.TabIndex = 217
        Me.PanelNoMoreCollection.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(396, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "ATTENTION!    THIS BILL IS MARKED AS NO MORE COLLECTION!"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Select a folder to save deocuments"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'frmAttorneyDocumentsAccess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1117, 610)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.PanelAttorney)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PanelNoMoreCollection)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmAttorneyDocumentsAccess"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Attorney Documents Access"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBoxLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.PanelDocumentWait.ResumeLayout(False)
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.PanelAttorney.ResumeLayout(False)
        Me.PanelAttorney.PerformLayout()
        Me.PanelNoMoreCollection.ResumeLayout(False)
        Me.PanelNoMoreCollection.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboAttorneysCompanyID As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents ListViewDocs As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblPatient As System.Windows.Forms.Label
    Friend WithEvents TimerPdfRefresh As System.Windows.Forms.Timer
    Friend WithEvents TimerLoadDocuments As System.Windows.Forms.Timer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonEmail As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonSaveAs As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblFileSize As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblDemo As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ListViewLog As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBoxAttorney As System.Windows.Forms.CheckBox
    Friend WithEvents PanelAttorney As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxComments As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PanelNoMoreCollection As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxLoading As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonSaveToHD As System.Windows.Forms.Button
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents RebuildDocumentToolStripMenuItemSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RebuildDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkAllPOMs As CheckBox
    Friend WithEvents pdfViewer As PdfiumViewer.PdfViewer
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents PanelDocumentWait As Panel
    Friend WithEvents Label124 As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Label123 As Label
End Class
