<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDocumentScannerPDF
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
    '<System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumentScannerPDF))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelLoading = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxFeeder = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxScanner = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdScan = New System.Windows.Forms.Button()
        Me.ButtonPrint = New System.Windows.Forms.Button()
        Me.ComboBoxDocProfile = New System.Windows.Forms.ComboBox()
        Me.txtDocumentName = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboPatientProcedure = New System.Windows.Forms.ComboBox()
        Me.chkDuplexScanning = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonFixCheck = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ReScanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelWait = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LabelPatientProcedure = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.pdfViewer = New PdfiumViewer.PdfViewer()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.PanelWait.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LabelLoading)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 36)
        Me.Panel1.TabIndex = 100
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SlateGray
        Me.Label1.Location = New System.Drawing.Point(344, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(586, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DOCUMENT SCANNER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelLoading
        '
        Me.LabelLoading.BackColor = System.Drawing.Color.Transparent
        Me.LabelLoading.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLoading.ForeColor = System.Drawing.Color.Black
        Me.LabelLoading.Location = New System.Drawing.Point(0, 0)
        Me.LabelLoading.Name = "LabelLoading"
        Me.LabelLoading.Size = New System.Drawing.Size(344, 36)
        Me.LabelLoading.TabIndex = 134
        Me.LabelLoading.Text = "Connecting Scanner. Please wait..."
        Me.LabelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(930, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(54, 36)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(7, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Scanner"
        '
        'ComboBoxFeeder
        '
        Me.ComboBoxFeeder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFeeder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ComboBoxFeeder.FormattingEnabled = True
        Me.ComboBoxFeeder.Items.AddRange(New Object() {"Feeder", "Flat Bed"})
        Me.ComboBoxFeeder.Location = New System.Drawing.Point(199, 18)
        Me.ComboBoxFeeder.Name = "ComboBoxFeeder"
        Me.ComboBoxFeeder.Size = New System.Drawing.Size(83, 21)
        Me.ComboBoxFeeder.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.ComboBoxFeeder, "Select Scanner Source")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(201, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 115
        Me.Label5.Text = "Source"
        '
        'ComboBoxScanner
        '
        Me.ComboBoxScanner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxScanner.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ComboBoxScanner.FormattingEnabled = True
        Me.ComboBoxScanner.Location = New System.Drawing.Point(10, 18)
        Me.ComboBoxScanner.Name = "ComboBoxScanner"
        Me.ComboBoxScanner.Size = New System.Drawing.Size(189, 21)
        Me.ComboBoxScanner.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.ComboBoxScanner, "Select Scanner Profile")
        '
        'cmdScan
        '
        Me.cmdScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdScan.Image = CType(resources.GetObject("cmdScan.Image"), System.Drawing.Image)
        Me.cmdScan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdScan.Location = New System.Drawing.Point(856, 3)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.Size = New System.Drawing.Size(60, 36)
        Me.cmdScan.TabIndex = 3
        Me.cmdScan.Text = "Scan"
        Me.cmdScan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdScan, "Start Scan")
        Me.cmdScan.UseVisualStyleBackColor = True
        '
        'ButtonPrint
        '
        Me.ButtonPrint.Image = CType(resources.GetObject("ButtonPrint.Image"), System.Drawing.Image)
        Me.ButtonPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonPrint.Location = New System.Drawing.Point(12, 5)
        Me.ButtonPrint.Name = "ButtonPrint"
        Me.ButtonPrint.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPrint.TabIndex = 0
        Me.ButtonPrint.Text = "Print"
        Me.ToolTip1.SetToolTip(Me.ButtonPrint, "Print Scanned Document")
        Me.ButtonPrint.UseVisualStyleBackColor = True
        '
        'ComboBoxDocProfile
        '
        Me.ComboBoxDocProfile.DropDownHeight = 600
        Me.ComboBoxDocProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDocProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ComboBoxDocProfile.FormattingEnabled = True
        Me.ComboBoxDocProfile.IntegralHeight = False
        Me.ComboBoxDocProfile.Location = New System.Drawing.Point(283, 18)
        Me.ComboBoxDocProfile.Name = "ComboBoxDocProfile"
        Me.ComboBoxDocProfile.Size = New System.Drawing.Size(168, 21)
        Me.ComboBoxDocProfile.TabIndex = 195
        Me.ToolTip1.SetToolTip(Me.ComboBoxDocProfile, "Select Document Profile")
        '
        'txtDocumentName
        '
        Me.txtDocumentName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDocumentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtDocumentName.Location = New System.Drawing.Point(453, 18)
        Me.txtDocumentName.MaxLength = 50
        Me.txtDocumentName.Name = "txtDocumentName"
        Me.txtDocumentName.Size = New System.Drawing.Size(163, 20)
        Me.txtDocumentName.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtDocumentName, "Specify Document Name")
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(920, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 36)
        Me.Button1.TabIndex = 197
        Me.Button1.Text = "Open"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.Button1, "Import Document Image From The File")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cboPatientProcedure
        '
        Me.cboPatientProcedure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPatientProcedure.DropDownHeight = 600
        Me.cboPatientProcedure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPatientProcedure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cboPatientProcedure.FormattingEnabled = True
        Me.cboPatientProcedure.IntegralHeight = False
        Me.cboPatientProcedure.Location = New System.Drawing.Point(618, 18)
        Me.cboPatientProcedure.Name = "cboPatientProcedure"
        Me.cboPatientProcedure.Size = New System.Drawing.Size(236, 21)
        Me.cboPatientProcedure.TabIndex = 201
        Me.ToolTip1.SetToolTip(Me.cboPatientProcedure, "Select the Document Associated Procedure")
        Me.cboPatientProcedure.Visible = False
        '
        'chkDuplexScanning
        '
        Me.chkDuplexScanning.AutoSize = True
        Me.chkDuplexScanning.BackColor = System.Drawing.Color.Transparent
        Me.chkDuplexScanning.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDuplexScanning.ForeColor = System.Drawing.Color.Transparent
        Me.chkDuplexScanning.Location = New System.Drawing.Point(137, 3)
        Me.chkDuplexScanning.Name = "chkDuplexScanning"
        Me.chkDuplexScanning.Size = New System.Drawing.Size(59, 17)
        Me.chkDuplexScanning.TabIndex = 277
        Me.chkDuplexScanning.Text = "Duplex"
        Me.ToolTip1.SetToolTip(Me.chkDuplexScanning, "Enable Double Side document scanning if supported by scanner")
        Me.chkDuplexScanning.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(180, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(81, 24)
        Me.Button3.TabIndex = 35
        Me.Button3.Text = "Fax"
        Me.ToolTip1.SetToolTip(Me.Button3, "Fax Scanned Document")
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(93, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 24)
        Me.Button2.TabIndex = 34
        Me.Button2.Text = "Email"
        Me.ToolTip1.SetToolTip(Me.Button2, "Email Scanned Document")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(450, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Document Name"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.ButtonFixCheck)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.ButtonPrint)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 728)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 34)
        Me.Panel2.TabIndex = 101
        '
        'ButtonFixCheck
        '
        Me.ButtonFixCheck.BackColor = System.Drawing.Color.Transparent
        Me.ButtonFixCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonFixCheck.ForeColor = System.Drawing.Color.Black
        Me.ButtonFixCheck.Image = CType(resources.GetObject("ButtonFixCheck.Image"), System.Drawing.Image)
        Me.ButtonFixCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonFixCheck.Location = New System.Drawing.Point(267, 4)
        Me.ButtonFixCheck.Name = "ButtonFixCheck"
        Me.ButtonFixCheck.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ButtonFixCheck.Size = New System.Drawing.Size(148, 24)
        Me.ButtonFixCheck.TabIndex = 37
        Me.ButtonFixCheck.Text = "Change Check Number"
        Me.ButtonFixCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonFixCheck.UseVisualStyleBackColor = False
        Me.ButtonFixCheck.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdClose.Location = New System.Drawing.Point(897, 5)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 24)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.Enabled = False
        Me.cmdUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdUpdate.Location = New System.Drawing.Point(816, 5)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 24)
        Me.cmdUpdate.TabIndex = 1
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReScanToolStripMenuItem, Me.ToolStripSeparator1, Me.PrintToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(159, 54)
        '
        'ReScanToolStripMenuItem
        '
        Me.ReScanToolStripMenuItem.Name = "ReScanToolStripMenuItem"
        Me.ReScanToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ReScanToolStripMenuItem.Text = "Scan Document"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(155, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'PanelWait
        '
        Me.PanelWait.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelWait.BackgroundImage = CType(resources.GetObject("PanelWait.BackgroundImage"), System.Drawing.Image)
        Me.PanelWait.Controls.Add(Me.PictureBox3)
        Me.PanelWait.Controls.Add(Me.Label6)
        Me.PanelWait.Location = New System.Drawing.Point(388, 366)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(236, 31)
        Me.PanelWait.TabIndex = 194
        Me.PanelWait.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(191, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(42, 27)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 1
        Me.PictureBox3.TabStop = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(3, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(182, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Connecting Scanner. Please wait..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(280, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 196
        Me.Label7.Text = "Document Profile"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.ComboBoxScanner)
        Me.Panel3.Controls.Add(Me.chkDuplexScanning)
        Me.Panel3.Controls.Add(Me.LabelPatientProcedure)
        Me.Panel3.Controls.Add(Me.cboPatientProcedure)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.cmdScan)
        Me.Panel3.Controls.Add(Me.ComboBoxFeeder)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.ComboBoxDocProfile)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtDocumentName)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(984, 47)
        Me.Panel3.TabIndex = 197
        '
        'LabelPatientProcedure
        '
        Me.LabelPatientProcedure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelPatientProcedure.AutoSize = True
        Me.LabelPatientProcedure.BackColor = System.Drawing.Color.Transparent
        Me.LabelPatientProcedure.ForeColor = System.Drawing.Color.Transparent
        Me.LabelPatientProcedure.Location = New System.Drawing.Point(615, 2)
        Me.LabelPatientProcedure.Name = "LabelPatientProcedure"
        Me.LabelPatientProcedure.Size = New System.Drawing.Size(99, 13)
        Me.LabelPatientProcedure.TabIndex = 202
        Me.LabelPatientProcedure.Text = "Patient's Procedure"
        Me.LabelPatientProcedure.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "K1")
        Me.ImageList1.Images.SetKeyName(1, "K2")
        Me.ImageList1.Images.SetKeyName(2, "K4")
        Me.ImageList1.Images.SetKeyName(3, "K5")
        Me.ImageList1.Images.SetKeyName(4, "K6")
        Me.ImageList1.Images.SetKeyName(5, "K7")
        Me.ImageList1.Images.SetKeyName(6, "K8")
        Me.ImageList1.Images.SetKeyName(7, "K9")
        Me.ImageList1.Images.SetKeyName(8, "K11")
        Me.ImageList1.Images.SetKeyName(9, "K12")
        Me.ImageList1.Images.SetKeyName(10, "K13")
        Me.ImageList1.Images.SetKeyName(11, "K14")
        Me.ImageList1.Images.SetKeyName(12, "K15")
        Me.ImageList1.Images.SetKeyName(13, "K16")
        Me.ImageList1.Images.SetKeyName(14, "K17")
        Me.ImageList1.Images.SetKeyName(15, "K3")
        Me.ImageList1.Images.SetKeyName(16, "K10")
        Me.ImageList1.Images.SetKeyName(17, "K18")
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "PDF"
        Me.OpenFileDialog1.Filter = "Adobe Acrobat Files (*.pdf)|*.pdf"
        Me.OpenFileDialog1.Title = "Select Document Image"
        '
        'pdfViewer
        '
        Me.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfViewer.Location = New System.Drawing.Point(0, 83)
        Me.pdfViewer.Name = "pdfViewer"
        Me.pdfViewer.ShowBookmarks = False
        Me.pdfViewer.ShowToolbar = False
        Me.pdfViewer.Size = New System.Drawing.Size(984, 645)
        Me.pdfViewer.TabIndex = 371
        Me.pdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitBest
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'frmDocumentScannerPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(984, 762)
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.pdfViewer)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1000, 800)
        Me.Name = "frmDocumentScannerPDF"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Scanner"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.PanelWait.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxFeeder As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxScanner As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdScan As System.Windows.Forms.Button
    Friend WithEvents ButtonPrint As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LabelLoading As System.Windows.Forms.Label
    Friend WithEvents txtDocumentName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ReScanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDocProfile As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ButtonFixCheck As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LabelPatientProcedure As System.Windows.Forms.Label
    Friend WithEvents cboPatientProcedure As System.Windows.Forms.ComboBox
    Friend WithEvents chkDuplexScanning As System.Windows.Forms.CheckBox
    Friend WithEvents pdfViewer As PdfiumViewer.PdfViewer
    Friend WithEvents PrintDialog1 As PrintDialog
End Class
