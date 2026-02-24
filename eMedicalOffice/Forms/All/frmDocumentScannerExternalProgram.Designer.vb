<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentScannerExternalProgram
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
    '<System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumentScannerExternalProgram))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelLoading = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdScan = New System.Windows.Forms.Button()
        Me.ButtonPrint = New System.Windows.Forms.Button()
        Me.ComboBoxDocProfile = New System.Windows.Forms.ComboBox()
        Me.txtDocumentName = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboPatientProcedure = New System.Windows.Forms.ComboBox()
        Me.PictureBoxInfo = New System.Windows.Forms.PictureBox()
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LabelPatientProcedure = New System.Windows.Forms.Label()
        Me.PanelExplorer = New System.Windows.Forms.Panel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ScanReferralToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AssignmentOfBenefitsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.PoliceReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.PaymentCheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonScannInsuranceCard = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.OtherDocumentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonDeleteDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.Label1.Location = New System.Drawing.Point(245, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(685, 36)
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
        Me.LabelLoading.Size = New System.Drawing.Size(245, 36)
        Me.LabelLoading.TabIndex = 134
        Me.LabelLoading.Text = "Document Scanner"
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
        'cmdScan
        '
        Me.cmdScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdScan.Image = CType(resources.GetObject("cmdScan.Image"), System.Drawing.Image)
        Me.cmdScan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdScan.Location = New System.Drawing.Point(859, 2)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.Size = New System.Drawing.Size(60, 40)
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
        Me.ToolTip1.SetToolTip(Me.ButtonPrint, "Print Document")
        Me.ButtonPrint.UseVisualStyleBackColor = True
        '
        'ComboBoxDocProfile
        '
        Me.ComboBoxDocProfile.DropDownHeight = 600
        Me.ComboBoxDocProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDocProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ComboBoxDocProfile.FormattingEnabled = True
        Me.ComboBoxDocProfile.IntegralHeight = False
        Me.ComboBoxDocProfile.Location = New System.Drawing.Point(12, 18)
        Me.ComboBoxDocProfile.Name = "ComboBoxDocProfile"
        Me.ComboBoxDocProfile.Size = New System.Drawing.Size(383, 24)
        Me.ComboBoxDocProfile.TabIndex = 195
        Me.ToolTip1.SetToolTip(Me.ComboBoxDocProfile, "Select Document Profile")
        '
        'txtDocumentName
        '
        Me.txtDocumentName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDocumentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtDocumentName.Location = New System.Drawing.Point(397, 18)
        Me.txtDocumentName.MaxLength = 50
        Me.txtDocumentName.Name = "txtDocumentName"
        Me.txtDocumentName.Size = New System.Drawing.Size(223, 22)
        Me.txtDocumentName.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtDocumentName, "Specify Document Name")
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(921, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 40)
        Me.Button1.TabIndex = 198
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
        Me.cboPatientProcedure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cboPatientProcedure.FormattingEnabled = True
        Me.cboPatientProcedure.IntegralHeight = False
        Me.cboPatientProcedure.Location = New System.Drawing.Point(622, 18)
        Me.cboPatientProcedure.Name = "cboPatientProcedure"
        Me.cboPatientProcedure.Size = New System.Drawing.Size(236, 24)
        Me.cboPatientProcedure.TabIndex = 199
        Me.ToolTip1.SetToolTip(Me.cboPatientProcedure, "Select the Document Associated Procedure")
        Me.cboPatientProcedure.Visible = False
        '
        'PictureBoxInfo
        '
        Me.PictureBoxInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxInfo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxInfo.Image = CType(resources.GetObject("PictureBoxInfo.Image"), System.Drawing.Image)
        Me.PictureBoxInfo.Location = New System.Drawing.Point(842, 1)
        Me.PictureBoxInfo.Name = "PictureBoxInfo"
        Me.PictureBoxInfo.Size = New System.Drawing.Size(16, 16)
        Me.PictureBoxInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBoxInfo.TabIndex = 275
        Me.PictureBoxInfo.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBoxInfo, "If the Scanned Report Procedure is not on the list, please check the Patient's Pr" &
        "ocedure's Schedule")
        Me.PictureBoxInfo.Visible = False
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
        Me.ToolTip1.SetToolTip(Me.Button3, "Fax Document")
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
        Me.ToolTip1.SetToolTip(Me.Button2, "Email Document")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(394, 4)
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
        Me.ButtonFixCheck.AutoSize = True
        Me.ButtonFixCheck.BackColor = System.Drawing.Color.Transparent
        Me.ButtonFixCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonFixCheck.ForeColor = System.Drawing.Color.Black
        Me.ButtonFixCheck.Image = CType(resources.GetObject("ButtonFixCheck.Image"), System.Drawing.Image)
        Me.ButtonFixCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonFixCheck.Location = New System.Drawing.Point(267, 4)
        Me.ButtonFixCheck.Name = "ButtonFixCheck"
        Me.ButtonFixCheck.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ButtonFixCheck.Size = New System.Drawing.Size(152, 24)
        Me.ButtonFixCheck.TabIndex = 36
        Me.ButtonFixCheck.Text = "Change Check Number"
        Me.ButtonFixCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonFixCheck.UseVisualStyleBackColor = False
        Me.ButtonFixCheck.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(12, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 196
        Me.Label7.Text = "Document Profile"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.PictureBoxInfo)
        Me.Panel3.Controls.Add(Me.LabelPatientProcedure)
        Me.Panel3.Controls.Add(Me.cboPatientProcedure)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.cmdScan)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.ComboBoxDocProfile)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtDocumentName)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(984, 50)
        Me.Panel3.TabIndex = 197
        '
        'LabelPatientProcedure
        '
        Me.LabelPatientProcedure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelPatientProcedure.AutoSize = True
        Me.LabelPatientProcedure.BackColor = System.Drawing.Color.Transparent
        Me.LabelPatientProcedure.ForeColor = System.Drawing.Color.Transparent
        Me.LabelPatientProcedure.Location = New System.Drawing.Point(619, 4)
        Me.LabelPatientProcedure.Name = "LabelPatientProcedure"
        Me.LabelPatientProcedure.Size = New System.Drawing.Size(92, 13)
        Me.LabelPatientProcedure.TabIndex = 200
        Me.LabelPatientProcedure.Text = "Patient Procedure"
        Me.LabelPatientProcedure.Visible = False
        '
        'PanelExplorer
        '
        Me.PanelExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelExplorer.Location = New System.Drawing.Point(0, 86)
        Me.PanelExplorer.Name = "PanelExplorer"
        Me.PanelExplorer.Size = New System.Drawing.Size(984, 642)
        Me.PanelExplorer.TabIndex = 198
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
        Me.OpenFileDialog1.Filter = "Adobe Acrobat Files (*.PDF)|*.PDF"
        Me.OpenFileDialog1.Title = "Select Document Image PDF File"
        '
        'ScanReferralToolStripMenuItem
        '
        Me.ScanReferralToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ScanReferralToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ScanReferralToolStripMenuItem.Image = CType(resources.GetObject("ScanReferralToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ScanReferralToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ScanReferralToolStripMenuItem.Name = "ScanReferralToolStripMenuItem"
        Me.ScanReferralToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0)
        Me.ScanReferralToolStripMenuItem.Size = New System.Drawing.Size(199, 36)
        Me.ScanReferralToolStripMenuItem.Text = "Referral"
        Me.ScanReferralToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.AutoSize = False
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(196, 6)
        '
        'AssignmentOfBenefitsToolStripMenuItem
        '
        Me.AssignmentOfBenefitsToolStripMenuItem.AutoSize = False
        Me.AssignmentOfBenefitsToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AssignmentOfBenefitsToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.AssignmentOfBenefitsToolStripMenuItem.Image = CType(resources.GetObject("AssignmentOfBenefitsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AssignmentOfBenefitsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AssignmentOfBenefitsToolStripMenuItem.Name = "AssignmentOfBenefitsToolStripMenuItem"
        Me.AssignmentOfBenefitsToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0)
        Me.AssignmentOfBenefitsToolStripMenuItem.Size = New System.Drawing.Size(199, 32)
        Me.AssignmentOfBenefitsToolStripMenuItem.Text = "Assignment Of Benefits"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(196, 6)
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.AutoSize = False
        Me.ToolStripMenuItem4.Image = CType(resources.GetObject("ToolStripMenuItem4.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(199, 32)
        Me.ToolStripMenuItem4.Text = "ToolStripMenuItem4"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(196, 6)
        '
        'PoliceReportToolStripMenuItem
        '
        Me.PoliceReportToolStripMenuItem.AutoSize = False
        Me.PoliceReportToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.PoliceReportToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.PoliceReportToolStripMenuItem.Image = CType(resources.GetObject("PoliceReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PoliceReportToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PoliceReportToolStripMenuItem.Name = "PoliceReportToolStripMenuItem"
        Me.PoliceReportToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0)
        Me.PoliceReportToolStripMenuItem.Size = New System.Drawing.Size(199, 32)
        Me.PoliceReportToolStripMenuItem.Text = "Police Report"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.AutoSize = False
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(196, 6)
        '
        'PaymentCheckToolStripMenuItem
        '
        Me.PaymentCheckToolStripMenuItem.AutoSize = False
        Me.PaymentCheckToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.PaymentCheckToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.PaymentCheckToolStripMenuItem.Image = CType(resources.GetObject("PaymentCheckToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PaymentCheckToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PaymentCheckToolStripMenuItem.Name = "PaymentCheckToolStripMenuItem"
        Me.PaymentCheckToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0)
        Me.PaymentCheckToolStripMenuItem.Size = New System.Drawing.Size(199, 32)
        Me.PaymentCheckToolStripMenuItem.Text = "Payment Check"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.AutoSize = False
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(196, 6)
        '
        'ButtonScannInsuranceCard
        '
        Me.ButtonScannInsuranceCard.AutoSize = False
        Me.ButtonScannInsuranceCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonScannInsuranceCard.ForeColor = System.Drawing.Color.Black
        Me.ButtonScannInsuranceCard.Image = CType(resources.GetObject("ButtonScannInsuranceCard.Image"), System.Drawing.Image)
        Me.ButtonScannInsuranceCard.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonScannInsuranceCard.Name = "ButtonScannInsuranceCard"
        Me.ButtonScannInsuranceCard.Padding = New System.Windows.Forms.Padding(0)
        Me.ButtonScannInsuranceCard.Size = New System.Drawing.Size(199, 32)
        Me.ButtonScannInsuranceCard.Text = "Insurance Scan Card"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.AutoSize = False
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(196, 6)
        '
        'OtherDocumentsToolStripMenuItem
        '
        Me.OtherDocumentsToolStripMenuItem.AutoSize = False
        Me.OtherDocumentsToolStripMenuItem.Image = CType(resources.GetObject("OtherDocumentsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OtherDocumentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.OtherDocumentsToolStripMenuItem.Name = "OtherDocumentsToolStripMenuItem"
        Me.OtherDocumentsToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0)
        Me.OtherDocumentsToolStripMenuItem.Size = New System.Drawing.Size(199, 32)
        Me.OtherDocumentsToolStripMenuItem.Text = "Pre-Authorization"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.AutoSize = False
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(196, 6)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.AutoSize = False
        Me.ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(199, 32)
        Me.ToolStripMenuItem3.Text = "Other Documents"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.AutoSize = False
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(196, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.AutoSize = False
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(199, 32)
        Me.ToolStripMenuItem2.Text = "Open Document File"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(196, 6)
        '
        'ButtonDeleteDocument
        '
        Me.ButtonDeleteDocument.AutoSize = False
        Me.ButtonDeleteDocument.BackColor = System.Drawing.Color.Transparent
        Me.ButtonDeleteDocument.BackgroundImage = CType(resources.GetObject("ButtonDeleteDocument.BackgroundImage"), System.Drawing.Image)
        Me.ButtonDeleteDocument.ForeColor = System.Drawing.Color.Black
        Me.ButtonDeleteDocument.Image = CType(resources.GetObject("ButtonDeleteDocument.Image"), System.Drawing.Image)
        Me.ButtonDeleteDocument.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonDeleteDocument.Name = "ButtonDeleteDocument"
        Me.ButtonDeleteDocument.Padding = New System.Windows.Forms.Padding(0)
        Me.ButtonDeleteDocument.Size = New System.Drawing.Size(199, 32)
        Me.ButtonDeleteDocument.Text = "Delete Document"
        Me.ButtonDeleteDocument.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonDeleteDocument.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(196, 6)
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'frmDocumentScannerExternalProgram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(984, 762)
        Me.Controls.Add(Me.PanelExplorer)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MinimizeBox = false
        Me.MinimumSize = New System.Drawing.Size(1000, 800)
        Me.Name = "frmDocumentScannerExternalProgram"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Scanner"
        Me.Panel1.ResumeLayout(false)
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBoxInfo,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        Me.ContextMenuStrip1.ResumeLayout(false)
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDocProfile As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PanelExplorer As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ScanReferralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AssignmentOfBenefitsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PoliceReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PaymentCheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonScannInsuranceCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OtherDocumentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonDeleteDocument As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonFixCheck As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LabelPatientProcedure As System.Windows.Forms.Label
    Friend WithEvents cboPatientProcedure As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBoxInfo As System.Windows.Forms.PictureBox
    Friend WithEvents PrintDialog1 As PrintDialog
End Class
