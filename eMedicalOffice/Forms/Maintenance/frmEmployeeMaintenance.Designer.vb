<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeeMaintenance
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
        Dim EnhancedColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer3 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer1 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer4 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer5 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer6 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer7 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer8 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer9 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer10 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer11 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim ColumnHeaderRenderer1 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer3 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer12 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim ColumnHeaderRenderer4 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer5 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer14 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim ColumnHeaderRenderer8 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer9 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeMaintenance))
        Me.ListViewEmployees = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.CheckBoxActiveInd = New System.Windows.Forms.CheckBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ComboBoxState = New System.Windows.Forms.ComboBox()
        Me.txtZip = New System.Windows.Forms.MaskedTextBox()
        Me.txtCellPhone = New System.Windows.Forms.MaskedTextBox()
        Me.txtPhone1 = New System.Windows.Forms.MaskedTextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.txtSSN = New System.Windows.Forms.MaskedTextBox()
        Me.txtDOB = New System.Windows.Forms.MaskedTextBox()
        Me.ContextMenuPopUpCalendar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtLname = New System.Windows.Forms.TextBox()
        Me.txtFname = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtDateHired = New System.Windows.Forms.MaskedTextBox()
        Me.ComboBoxPosition = New System.Windows.Forms.ComboBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUID = New System.Windows.Forms.TextBox()
        Me.TextBoxMI = New System.Windows.Forms.TextBox()
        Me.txtCorporationAddress1 = New System.Windows.Forms.TextBox()
        Me.ComboBoxCorporationState = New System.Windows.Forms.ComboBox()
        Me.txtCorporationAddress2 = New System.Windows.Forms.TextBox()
        Me.txtCorporationZip = New System.Windows.Forms.MaskedTextBox()
        Me.txtCorporationCity = New System.Windows.Forms.TextBox()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.txtLICNumber = New System.Windows.Forms.TextBox()
        Me.ListViewDoctorDiagnostics = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.txtCorporationName = New System.Windows.Forms.TextBox()
        Me.txtCorporationTaxID = New System.Windows.Forms.TextBox()
        Me.txtDoctorTitle = New System.Windows.Forms.TextBox()
        Me.txtWebAdminPWD = New System.Windows.Forms.TextBox()
        Me.txtWebAdminUID = New System.Windows.Forms.TextBox()
        Me.CheckBoxPrivate = New System.Windows.Forms.CheckBox()
        Me.CheckBoxNoFault = New System.Windows.Forms.CheckBox()
        Me.CheckBoxTreatmentPrv = New System.Windows.Forms.CheckBox()
        Me.CheckBoxBillingPrv = New System.Windows.Forms.CheckBox()
        Me.txtAccountNumber = New System.Windows.Forms.TextBox()
        Me.txtAlias = New System.Windows.Forms.TextBox()
        Me.txtWCBAuthorizationNumber = New System.Windows.Forms.TextBox()
        Me.txtWCBRatingCode = New System.Windows.Forms.TextBox()
        Me.txtWCProviderNPI = New System.Windows.Forms.TextBox()
        Me.txtDoctorTitle1 = New System.Windows.Forms.TextBox()
        Me.txtCorporateFax = New System.Windows.Forms.MaskedTextBox()
        Me.txtCorporatePhone = New System.Windows.Forms.MaskedTextBox()
        Me.txtCorporationDBA = New System.Windows.Forms.TextBox()
        Me.ComboBoxTreatingProvider = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonDistribute = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdAddNew = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBoxDoctorSignature = New System.Windows.Forms.PictureBox()
        Me.ListViewNPI = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonWebAdminRefresh = New System.Windows.Forms.Button()
        Me.cmdSelectPictureFile = New System.Windows.Forms.Button()
        Me.cmdSelectPicture = New System.Windows.Forms.Button()
        Me.cmdRemovePicture = New System.Windows.Forms.Button()
        Me.PictureBoxAlias = New System.Windows.Forms.PictureBox()
        Me.lblAbbreviationDescription = New System.Windows.Forms.Label()
        Me.ComboBoxAbbreviation = New System.Windows.Forms.ComboBox()
        Me.ComboBoxreferralColor = New System.Windows.Forms.ComboBox()
        Me.cmdRemovePCLogo = New System.Windows.Forms.Button()
        Me.cmdSelectPicturePCLogo = New System.Windows.Forms.Button()
        Me.PictureBoxPCLogo = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBoxWeb = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblWebAdminUID = New System.Windows.Forms.Label()
        Me.lblWebAdminPWD = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DoctorInfo = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.DoctorNPI = New System.Windows.Forms.TabPage()
        Me.ButtonDeleteNPI = New System.Windows.Forms.Button()
        Me.ButtonAddNPI = New System.Windows.Forms.Button()
        Me.EmailTab = New System.Windows.Forms.TabPage()
        Me.PanelEmailWarning = New System.Windows.Forms.Panel()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CheckBoxEmail10 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxEmail9 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxEmail8 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxEmail7 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxEmail6 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxEmail5 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxEmail1 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxEmail4 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxEmail2 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxEmail3 = New System.Windows.Forms.CheckBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.openFD = New System.Windows.Forms.OpenFileDialog()
        Me.MonthCalendarPopUp = New System.Windows.Forms.MonthCalendar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStripOffices = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToOfficeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBoxPassword = New System.Windows.Forms.PictureBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuPopUpCalendar.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBoxDoctorSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxAlias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxPCLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBoxWeb.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.DoctorInfo.SuspendLayout()
        Me.DoctorNPI.SuspendLayout()
        Me.EmailTab.SuspendLayout()
        Me.PanelEmailWarning.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripOffices.SuspendLayout()
        CType(Me.PictureBoxPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        EnhancedColumnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer2.Name = "EnhancedColumnHeaderRenderer2"
        EnhancedColumnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer2.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer3.Name = "EnhancedColumnHeaderRenderer3"
        EnhancedColumnHeaderRenderer3.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer1.Name = "EnhancedColumnHeaderRenderer1"
        EnhancedColumnHeaderRenderer1.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer4.Name = "EnhancedColumnHeaderRenderer4"
        EnhancedColumnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer4.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer5.Name = "EnhancedColumnHeaderRenderer5"
        EnhancedColumnHeaderRenderer5.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer6.Name = "EnhancedColumnHeaderRenderer6"
        EnhancedColumnHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer6.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer7.Name = "EnhancedColumnHeaderRenderer7"
        EnhancedColumnHeaderRenderer7.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer8.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer8.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer8.Name = "EnhancedColumnHeaderRenderer8"
        EnhancedColumnHeaderRenderer8.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer8.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer9.Name = "EnhancedColumnHeaderRenderer9"
        EnhancedColumnHeaderRenderer9.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer10.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer10.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer10.Name = "EnhancedColumnHeaderRenderer10"
        EnhancedColumnHeaderRenderer10.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer10.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer11.Name = "EnhancedColumnHeaderRenderer11"
        EnhancedColumnHeaderRenderer11.TextRotationAngle = 0R
        ColumnHeaderRenderer1.Name = "ColumnHeaderRenderer1"
        ColumnHeaderRenderer1.TextRotationAngle = 0R
        ColumnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ColumnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer2.Name = "ColumnHeaderRenderer2"
        ColumnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer2.TextRotationAngle = 0R
        ColumnHeaderRenderer3.Name = "ColumnHeaderRenderer3"
        ColumnHeaderRenderer3.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer12.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer12.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer12.Name = "EnhancedColumnHeaderRenderer12"
        EnhancedColumnHeaderRenderer12.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer12.TextRotationAngle = 0R
        ColumnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ColumnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer4.Name = "ColumnHeaderRenderer4"
        ColumnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer4.TextRotationAngle = 0R
        ColumnHeaderRenderer5.Name = "ColumnHeaderRenderer5"
        ColumnHeaderRenderer5.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer14.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer14.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer14.Name = "EnhancedColumnHeaderRenderer14"
        EnhancedColumnHeaderRenderer14.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer14.TextRotationAngle = 0R
        ColumnHeaderRenderer8.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        ColumnHeaderRenderer8.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer8.Name = "ColumnHeaderRenderer8"
        ColumnHeaderRenderer8.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer8.TextRotationAngle = 0R
        ColumnHeaderRenderer9.Name = "ColumnHeaderRenderer9"
        ColumnHeaderRenderer9.TextRotationAngle = 0R
        '
        'ListViewEmployees
        '
        Me.ListViewEmployees.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListViewEmployees.FullRowSelect = True
        Me.ListViewEmployees.GridLines = True
        Me.ListViewEmployees.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewEmployees.HideSelection = False
        Me.ListViewEmployees.LargeImageList = Me.ImageList1
        Me.ListViewEmployees.Location = New System.Drawing.Point(3, 42)
        Me.ListViewEmployees.MultiSelect = False
        Me.ListViewEmployees.Name = "ListViewEmployees"
        Me.ListViewEmployees.Size = New System.Drawing.Size(194, 424)
        Me.ListViewEmployees.SmallImageList = Me.ImageList1
        Me.ListViewEmployees.TabIndex = 1
        Me.ListViewEmployees.UseCompatibleStateImageBehavior = False
        Me.ListViewEmployees.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 160
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "UserRed.png")
        Me.ImageList1.Images.SetKeyName(1, "User.png")
        Me.ImageList1.Images.SetKeyName(2, "UserDoctorBlue.png")
        '
        'CheckBoxActiveInd
        '
        Me.CheckBoxActiveInd.AutoSize = True
        Me.CheckBoxActiveInd.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxActiveInd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxActiveInd.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.CheckBoxActiveInd, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CheckBoxActiveInd.Location = New System.Drawing.Point(520, 8)
        Me.CheckBoxActiveInd.Name = "CheckBoxActiveInd"
        Me.CheckBoxActiveInd.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxActiveInd.TabIndex = 3
        Me.CheckBoxActiveInd.Text = "Active"
        Me.ToolTip1.SetToolTip(Me.CheckBoxActiveInd, "Employee Active Indicator")
        Me.CheckBoxActiveInd.UseVisualStyleBackColor = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ComboBoxState
        '
        Me.ComboBoxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxState.Enabled = False
        Me.ComboBoxState.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxState.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxState, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxState.Location = New System.Drawing.Point(290, 185)
        Me.ComboBoxState.Name = "ComboBoxState"
        Me.ComboBoxState.Size = New System.Drawing.Size(141, 21)
        Me.ComboBoxState.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.ComboBoxState, "Employee Address State")
        '
        'txtZip
        '
        Me.txtZip.Enabled = False
        Me.txtZip.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconAlignment(Me.txtZip, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtZip.Location = New System.Drawing.Point(437, 184)
        Me.txtZip.Mask = "00000"
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(139, 20)
        Me.txtZip.TabIndex = 9
        Me.txtZip.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtZip, "Employee Address Zip Code")
        '
        'txtCellPhone
        '
        Me.txtCellPhone.Enabled = False
        Me.txtCellPhone.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconAlignment(Me.txtCellPhone, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCellPhone.Location = New System.Drawing.Point(290, 224)
        Me.txtCellPhone.Mask = "(999) 000-0000"
        Me.txtCellPhone.Name = "txtCellPhone"
        Me.txtCellPhone.Size = New System.Drawing.Size(286, 20)
        Me.txtCellPhone.TabIndex = 11
        Me.txtCellPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtCellPhone, "Employee Cell Phone Number")
        '
        'txtPhone1
        '
        Me.txtPhone1.Enabled = False
        Me.txtPhone1.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconAlignment(Me.txtPhone1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtPhone1.Location = New System.Drawing.Point(17, 224)
        Me.txtPhone1.Mask = "(999) 000-0000"
        Me.txtPhone1.Name = "txtPhone1"
        Me.txtPhone1.Size = New System.Drawing.Size(264, 20)
        Me.txtPhone1.TabIndex = 10
        Me.txtPhone1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtPhone1, "Employee Phone Number")
        '
        'txtCity
        '
        Me.txtCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCity.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtCity, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCity.Location = New System.Drawing.Point(17, 185)
        Me.txtCity.MaxLength = 50
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(264, 20)
        Me.txtCity.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.txtCity, "Employee Address City")
        '
        'txtAddress2
        '
        Me.txtAddress2.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtAddress2, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtAddress2.Location = New System.Drawing.Point(290, 146)
        Me.txtAddress2.MaxLength = 255
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(286, 20)
        Me.txtAddress2.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtAddress2, "Employee Address 2")
        '
        'txtAddress1
        '
        Me.txtAddress1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtAddress1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtAddress1.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtAddress1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtAddress1.Location = New System.Drawing.Point(17, 146)
        Me.txtAddress1.MaxLength = 255
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(264, 20)
        Me.txtAddress1.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtAddress1, "Employee Address 1")
        '
        'txtSSN
        '
        Me.txtSSN.Enabled = False
        Me.txtSSN.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconAlignment(Me.txtSSN, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtSSN.Location = New System.Drawing.Point(290, 107)
        Me.txtSSN.Mask = "000-00-0000"
        Me.txtSSN.Name = "txtSSN"
        Me.txtSSN.Size = New System.Drawing.Size(286, 20)
        Me.txtSSN.TabIndex = 4
        Me.txtSSN.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtSSN, "Social Security Number - Optional")
        '
        'txtDOB
        '
        Me.txtDOB.ContextMenuStrip = Me.ContextMenuPopUpCalendar
        Me.txtDOB.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtDOB, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtDOB.Location = New System.Drawing.Point(17, 107)
        Me.txtDOB.Mask = "00/00/0000"
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.Size = New System.Drawing.Size(264, 20)
        Me.txtDOB.TabIndex = 3
        Me.txtDOB.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtDOB, "Employee Date Of Birth")
        Me.txtDOB.ValidatingType = GetType(Date)
        '
        'ContextMenuPopUpCalendar
        '
        Me.ContextMenuPopUpCalendar.BackColor = System.Drawing.Color.White
        Me.ContextMenuPopUpCalendar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem})
        Me.ContextMenuPopUpCalendar.Name = "ContextMenuStrip1"
        Me.ContextMenuPopUpCalendar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuPopUpCalendar.ShowImageMargin = False
        Me.ContextMenuPopUpCalendar.ShowItemToolTips = False
        Me.ContextMenuPopUpCalendar.Size = New System.Drawing.Size(86, 26)
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(85, 22)
        Me.CancelToolStripMenuItem.Text = "Cancel"
        '
        'txtLname
        '
        Me.txtLname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtLname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtLname.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtLname, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtLname.Location = New System.Drawing.Point(335, 31)
        Me.txtLname.MaxLength = 50
        Me.txtLname.Name = "txtLname"
        Me.txtLname.Size = New System.Drawing.Size(243, 20)
        Me.txtLname.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtLname, "Employee Last Name")
        '
        'txtFname
        '
        Me.txtFname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtFname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtFname.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtFname, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtFname.Location = New System.Drawing.Point(17, 31)
        Me.txtFname.MaxLength = 50
        Me.txtFname.Name = "txtFname"
        Me.txtFname.Size = New System.Drawing.Size(243, 20)
        Me.txtFname.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtFname, "Employee First Name")
        '
        'txtEmail
        '
        Me.txtEmail.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtEmail, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtEmail.Location = New System.Drawing.Point(17, 263)
        Me.txtEmail.MaxLength = 255
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(559, 20)
        Me.txtEmail.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.txtEmail, "Employee Email Address")
        '
        'txtDateHired
        '
        Me.txtDateHired.ContextMenuStrip = Me.ContextMenuPopUpCalendar
        Me.txtDateHired.Enabled = False
        Me.txtDateHired.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconAlignment(Me.txtDateHired, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtDateHired.Location = New System.Drawing.Point(17, 31)
        Me.txtDateHired.Mask = "00/00/0000"
        Me.txtDateHired.Name = "txtDateHired"
        Me.txtDateHired.Size = New System.Drawing.Size(69, 20)
        Me.txtDateHired.TabIndex = 0
        Me.txtDateHired.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtDateHired, "Employee Date Hired")
        Me.txtDateHired.ValidatingType = GetType(Date)
        '
        'ComboBoxPosition
        '
        Me.ComboBoxPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPosition.Enabled = False
        Me.ComboBoxPosition.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxPosition.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxPosition, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxPosition.Location = New System.Drawing.Point(95, 31)
        Me.ComboBoxPosition.Name = "ComboBoxPosition"
        Me.ComboBoxPosition.Size = New System.Drawing.Size(461, 21)
        Me.ComboBoxPosition.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.ComboBoxPosition, "Employee Position")
        '
        'txtPassword
        '
        Me.txtPassword.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtPassword, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtPassword.Location = New System.Drawing.Point(302, 37)
        Me.txtPassword.MaxLength = 10
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(237, 20)
        Me.txtPassword.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtPassword, "Employee Login Password")
        '
        'txtUID
        '
        Me.txtUID.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtUID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtUID.Location = New System.Drawing.Point(78, 37)
        Me.txtUID.MaxLength = 10
        Me.txtUID.Name = "txtUID"
        Me.txtUID.Size = New System.Drawing.Size(218, 20)
        Me.txtUID.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtUID, "Employee Login User Name")
        '
        'TextBoxMI
        '
        Me.TextBoxMI.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.TextBoxMI, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.TextBoxMI.Location = New System.Drawing.Point(290, 31)
        Me.TextBoxMI.MaxLength = 10
        Me.TextBoxMI.Name = "TextBoxMI"
        Me.TextBoxMI.Size = New System.Drawing.Size(34, 20)
        Me.TextBoxMI.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TextBoxMI, "Employee Middle Initial")
        '
        'txtCorporationAddress1
        '
        Me.txtCorporationAddress1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCorporationAddress1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCorporationAddress1.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtCorporationAddress1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCorporationAddress1.Location = New System.Drawing.Point(17, 229)
        Me.txtCorporationAddress1.MaxLength = 50
        Me.txtCorporationAddress1.Name = "txtCorporationAddress1"
        Me.txtCorporationAddress1.Size = New System.Drawing.Size(123, 20)
        Me.txtCorporationAddress1.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.txtCorporationAddress1, "Doctor Professional Corporation Mailing Address 1")
        '
        'ComboBoxCorporationState
        '
        Me.ComboBoxCorporationState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCorporationState.Enabled = False
        Me.ComboBoxCorporationState.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBoxCorporationState.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxCorporationState, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxCorporationState.Location = New System.Drawing.Point(279, 228)
        Me.ComboBoxCorporationState.Name = "ComboBoxCorporationState"
        Me.ComboBoxCorporationState.Size = New System.Drawing.Size(45, 21)
        Me.ComboBoxCorporationState.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.ComboBoxCorporationState, "Doctor Professional Corporation Mailing Address State")
        '
        'txtCorporationAddress2
        '
        Me.txtCorporationAddress2.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtCorporationAddress2, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCorporationAddress2.Location = New System.Drawing.Point(146, 228)
        Me.txtCorporationAddress2.MaxLength = 50
        Me.txtCorporationAddress2.Name = "txtCorporationAddress2"
        Me.txtCorporationAddress2.Size = New System.Drawing.Size(71, 20)
        Me.txtCorporationAddress2.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.txtCorporationAddress2, "Doctor Professional Corporation Mailing Address 2")
        '
        'txtCorporationZip
        '
        Me.txtCorporationZip.Enabled = False
        Me.txtCorporationZip.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconAlignment(Me.txtCorporationZip, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCorporationZip.Location = New System.Drawing.Point(330, 228)
        Me.txtCorporationZip.Mask = "00000-0000"
        Me.txtCorporationZip.Name = "txtCorporationZip"
        Me.txtCorporationZip.Size = New System.Drawing.Size(69, 20)
        Me.txtCorporationZip.TabIndex = 15
        Me.txtCorporationZip.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtCorporationZip, "Doctor Professional Corporation Mailing Address Zip Code")
        '
        'txtCorporationCity
        '
        Me.txtCorporationCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCorporationCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCorporationCity.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtCorporationCity, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCorporationCity.Location = New System.Drawing.Point(223, 228)
        Me.txtCorporationCity.MaxLength = 50
        Me.txtCorporationCity.Name = "txtCorporationCity"
        Me.txtCorporationCity.Size = New System.Drawing.Size(54, 20)
        Me.txtCorporationCity.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.txtCorporationCity, "Doctor Professional Corporation Mailing Address City")
        '
        'TextBoxSearch
        '
        Me.ErrorProvider1.SetIconAlignment(Me.TextBoxSearch, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.TextBoxSearch.Location = New System.Drawing.Point(3, 18)
        Me.TextBoxSearch.MaxLength = 50
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(194, 20)
        Me.TextBoxSearch.TabIndex = 0
        '
        'txtLICNumber
        '
        Me.txtLICNumber.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtLICNumber, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtLICNumber.Location = New System.Drawing.Point(17, 32)
        Me.txtLICNumber.MaxLength = 50
        Me.txtLICNumber.Name = "txtLICNumber"
        Me.txtLICNumber.Size = New System.Drawing.Size(58, 20)
        Me.txtLICNumber.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtLICNumber, "Doctor License Number")
        '
        'ListViewDoctorDiagnostics
        '
        Me.ListViewDoctorDiagnostics.CheckBoxes = True
        Me.ListViewDoctorDiagnostics.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.ListViewDoctorDiagnostics.Enabled = False
        Me.ListViewDoctorDiagnostics.FullRowSelect = True
        Me.ListViewDoctorDiagnostics.GridLines = True
        Me.ListViewDoctorDiagnostics.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewDoctorDiagnostics.HideSelection = False
        Me.ErrorProvider1.SetIconAlignment(Me.ListViewDoctorDiagnostics, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.ListViewDoctorDiagnostics.Location = New System.Drawing.Point(17, 350)
        Me.ListViewDoctorDiagnostics.Name = "ListViewDoctorDiagnostics"
        Me.ListViewDoctorDiagnostics.ShowItemToolTips = True
        Me.ListViewDoctorDiagnostics.Size = New System.Drawing.Size(382, 60)
        Me.ListViewDoctorDiagnostics.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.ListViewDoctorDiagnostics, "Employee Offices")
        Me.ListViewDoctorDiagnostics.UseCompatibleStateImageBehavior = False
        Me.ListViewDoctorDiagnostics.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 240
        '
        'txtCorporationName
        '
        Me.txtCorporationName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCorporationName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCorporationName.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtCorporationName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCorporationName.Location = New System.Drawing.Point(17, 144)
        Me.txtCorporationName.MaxLength = 50
        Me.txtCorporationName.Name = "txtCorporationName"
        Me.txtCorporationName.Size = New System.Drawing.Size(266, 20)
        Me.txtCorporationName.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.txtCorporationName, "Doctor's Doctor Professional Corporation")
        '
        'txtCorporationTaxID
        '
        Me.txtCorporationTaxID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCorporationTaxID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCorporationTaxID.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtCorporationTaxID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCorporationTaxID.Location = New System.Drawing.Point(289, 143)
        Me.txtCorporationTaxID.MaxLength = 50
        Me.txtCorporationTaxID.Name = "txtCorporationTaxID"
        Me.txtCorporationTaxID.Size = New System.Drawing.Size(105, 20)
        Me.txtCorporationTaxID.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.txtCorporationTaxID, "Doctor Professional Corporation Tax ID")
        '
        'txtDoctorTitle
        '
        Me.txtDoctorTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtDoctorTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDoctorTitle.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtDoctorTitle, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtDoctorTitle.Location = New System.Drawing.Point(16, 69)
        Me.txtDoctorTitle.MaxLength = 255
        Me.txtDoctorTitle.Name = "txtDoctorTitle"
        Me.txtDoctorTitle.Size = New System.Drawing.Size(368, 20)
        Me.txtDoctorTitle.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtDoctorTitle, "Doctor Title")
        '
        'txtWebAdminPWD
        '
        Me.txtWebAdminPWD.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtWebAdminPWD, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtWebAdminPWD.Location = New System.Drawing.Point(302, 42)
        Me.txtWebAdminPWD.MaxLength = 10
        Me.txtWebAdminPWD.Name = "txtWebAdminPWD"
        Me.txtWebAdminPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtWebAdminPWD.Size = New System.Drawing.Size(237, 20)
        Me.txtWebAdminPWD.TabIndex = 176
        Me.ToolTip1.SetToolTip(Me.txtWebAdminPWD, "Employee Web Login Password." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If you manually overwrite username and password, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "make sure these values are unique.")
        '
        'txtWebAdminUID
        '
        Me.txtWebAdminUID.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtWebAdminUID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtWebAdminUID.Location = New System.Drawing.Point(77, 42)
        Me.txtWebAdminUID.MaxLength = 10
        Me.txtWebAdminUID.Name = "txtWebAdminUID"
        Me.txtWebAdminUID.Size = New System.Drawing.Size(218, 20)
        Me.txtWebAdminUID.TabIndex = 175
        Me.ToolTip1.SetToolTip(Me.txtWebAdminUID, "Employee Web Login User Name." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If you manually overwrite username and password, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "make sure these values are unique.")
        '
        'CheckBoxPrivate
        '
        Me.CheckBoxPrivate.AutoSize = True
        Me.ErrorProvider1.SetIconAlignment(Me.CheckBoxPrivate, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CheckBoxPrivate.Location = New System.Drawing.Point(513, 36)
        Me.CheckBoxPrivate.Name = "CheckBoxPrivate"
        Me.CheckBoxPrivate.Size = New System.Drawing.Size(59, 17)
        Me.CheckBoxPrivate.TabIndex = 23
        Me.CheckBoxPrivate.Text = "Private"
        Me.CheckBoxPrivate.UseVisualStyleBackColor = True
        '
        'CheckBoxNoFault
        '
        Me.CheckBoxNoFault.AutoSize = True
        Me.ErrorProvider1.SetIconAlignment(Me.CheckBoxNoFault, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CheckBoxNoFault.Location = New System.Drawing.Point(513, 16)
        Me.CheckBoxNoFault.Name = "CheckBoxNoFault"
        Me.CheckBoxNoFault.Size = New System.Drawing.Size(63, 17)
        Me.CheckBoxNoFault.TabIndex = 22
        Me.CheckBoxNoFault.Text = "NoFault"
        Me.CheckBoxNoFault.UseVisualStyleBackColor = True
        '
        'CheckBoxTreatmentPrv
        '
        Me.CheckBoxTreatmentPrv.AutoSize = True
        Me.ErrorProvider1.SetIconAlignment(Me.CheckBoxTreatmentPrv, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CheckBoxTreatmentPrv.Location = New System.Drawing.Point(394, 35)
        Me.CheckBoxTreatmentPrv.Name = "CheckBoxTreatmentPrv"
        Me.CheckBoxTreatmentPrv.Size = New System.Drawing.Size(116, 17)
        Me.CheckBoxTreatmentPrv.TabIndex = 21
        Me.CheckBoxTreatmentPrv.Text = "Treatment Provider"
        Me.CheckBoxTreatmentPrv.UseVisualStyleBackColor = True
        '
        'CheckBoxBillingPrv
        '
        Me.CheckBoxBillingPrv.AutoSize = True
        Me.ErrorProvider1.SetIconAlignment(Me.CheckBoxBillingPrv, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CheckBoxBillingPrv.Location = New System.Drawing.Point(394, 15)
        Me.CheckBoxBillingPrv.Name = "CheckBoxBillingPrv"
        Me.CheckBoxBillingPrv.Size = New System.Drawing.Size(95, 17)
        Me.CheckBoxBillingPrv.TabIndex = 20
        Me.CheckBoxBillingPrv.Text = "Billing Provider"
        Me.CheckBoxBillingPrv.UseVisualStyleBackColor = True
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtAccountNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtAccountNumber.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtAccountNumber, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtAccountNumber.Location = New System.Drawing.Point(18, 310)
        Me.txtAccountNumber.MaxLength = 50
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.Size = New System.Drawing.Size(381, 20)
        Me.txtAccountNumber.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.txtAccountNumber, "Checking Account Number - For Deposit Slip Printing")
        '
        'txtAlias
        '
        Me.txtAlias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtAlias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtAlias.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtAlias, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtAlias.Location = New System.Drawing.Point(17, 68)
        Me.txtAlias.MaxLength = 50
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(561, 20)
        Me.txtAlias.TabIndex = 160
        Me.ToolTip1.SetToolTip(Me.txtAlias, "Employee First Name")
        '
        'txtWCBAuthorizationNumber
        '
        Me.txtWCBAuthorizationNumber.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtWCBAuthorizationNumber, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtWCBAuthorizationNumber.Location = New System.Drawing.Point(80, 32)
        Me.txtWCBAuthorizationNumber.MaxLength = 50
        Me.txtWCBAuthorizationNumber.Name = "txtWCBAuthorizationNumber"
        Me.txtWCBAuthorizationNumber.Size = New System.Drawing.Size(104, 20)
        Me.txtWCBAuthorizationNumber.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtWCBAuthorizationNumber, "Required For Working Comp")
        '
        'txtWCBRatingCode
        '
        Me.txtWCBRatingCode.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtWCBRatingCode, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtWCBRatingCode.Location = New System.Drawing.Point(189, 32)
        Me.txtWCBRatingCode.MaxLength = 50
        Me.txtWCBRatingCode.Name = "txtWCBRatingCode"
        Me.txtWCBRatingCode.Size = New System.Drawing.Size(94, 20)
        Me.txtWCBRatingCode.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtWCBRatingCode, "Required For Working Comp")
        '
        'txtWCProviderNPI
        '
        Me.txtWCProviderNPI.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtWCProviderNPI, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtWCProviderNPI.Location = New System.Drawing.Point(292, 32)
        Me.txtWCProviderNPI.MaxLength = 50
        Me.txtWCProviderNPI.Name = "txtWCProviderNPI"
        Me.txtWCProviderNPI.Size = New System.Drawing.Size(92, 20)
        Me.txtWCProviderNPI.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtWCProviderNPI, "Required For Working Comp")
        '
        'txtDoctorTitle1
        '
        Me.txtDoctorTitle1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtDoctorTitle1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDoctorTitle1.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtDoctorTitle1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtDoctorTitle1.Location = New System.Drawing.Point(18, 106)
        Me.txtDoctorTitle1.MaxLength = 255
        Me.txtDoctorTitle1.Name = "txtDoctorTitle1"
        Me.txtDoctorTitle1.Size = New System.Drawing.Size(238, 20)
        Me.txtDoctorTitle1.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtDoctorTitle1, "Used under the Doctor's signature line.")
        '
        'txtCorporateFax
        '
        Me.txtCorporateFax.Enabled = False
        Me.txtCorporateFax.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconAlignment(Me.txtCorporateFax, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCorporateFax.Location = New System.Drawing.Point(146, 269)
        Me.txtCorporateFax.Mask = "(999) 000-0000"
        Me.txtCorporateFax.Name = "txtCorporateFax"
        Me.txtCorporateFax.Size = New System.Drawing.Size(151, 20)
        Me.txtCorporateFax.TabIndex = 17
        Me.txtCorporateFax.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtCorporateFax, "Employee Fax")
        '
        'txtCorporatePhone
        '
        Me.txtCorporatePhone.Enabled = False
        Me.txtCorporatePhone.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconAlignment(Me.txtCorporatePhone, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCorporatePhone.Location = New System.Drawing.Point(16, 269)
        Me.txtCorporatePhone.Mask = "(999) 000-0000"
        Me.txtCorporatePhone.Name = "txtCorporatePhone"
        Me.txtCorporatePhone.Size = New System.Drawing.Size(124, 20)
        Me.txtCorporatePhone.TabIndex = 16
        Me.txtCorporatePhone.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtCorporatePhone, "Employee Phone Number")
        '
        'txtCorporationDBA
        '
        Me.txtCorporationDBA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCorporationDBA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCorporationDBA.Enabled = False
        Me.ErrorProvider1.SetIconAlignment(Me.txtCorporationDBA, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCorporationDBA.Location = New System.Drawing.Point(16, 182)
        Me.txtCorporationDBA.MaxLength = 50
        Me.txtCorporationDBA.Name = "txtCorporationDBA"
        Me.txtCorporationDBA.Size = New System.Drawing.Size(378, 20)
        Me.txtCorporationDBA.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.txtCorporationDBA, "Doctor's Doctor Professional Corporation")
        '
        'ComboBoxTreatingProvider
        '
        Me.ComboBoxTreatingProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTreatingProvider.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxTreatingProvider.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxTreatingProvider, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxTreatingProvider.Location = New System.Drawing.Point(77, 91)
        Me.ComboBoxTreatingProvider.Name = "ComboBoxTreatingProvider"
        Me.ComboBoxTreatingProvider.Size = New System.Drawing.Size(461, 21)
        Me.ComboBoxTreatingProvider.TabIndex = 182
        Me.ToolTip1.SetToolTip(Me.ComboBoxTreatingProvider, "Employee Position")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.ButtonDistribute)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.cmdCancel)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Controls.Add(Me.cmdDelete)
        Me.Panel2.Controls.Add(Me.cmdEdit)
        Me.Panel2.Controls.Add(Me.cmdAddNew)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 472)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(798, 34)
        Me.Panel2.TabIndex = 99
        '
        'ButtonDistribute
        '
        Me.ButtonDistribute.Location = New System.Drawing.Point(327, 6)
        Me.ButtonDistribute.Name = "ButtonDistribute"
        Me.ButtonDistribute.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDistribute.TabIndex = 6
        Me.ButtonDistribute.Text = "Copy"
        Me.ButtonDistribute.UseVisualStyleBackColor = True
        Me.ButtonDistribute.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(720, 6)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
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
        Me.cmdUpdate.Enabled = False
        Me.cmdUpdate.Location = New System.Drawing.Point(165, 6)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate.TabIndex = 3
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Enabled = False
        Me.cmdDelete.Location = New System.Drawing.Point(408, 6)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete.TabIndex = 0
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        Me.cmdDelete.Visible = False
        '
        'cmdEdit
        '
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
        'PictureBoxDoctorSignature
        '
        Me.PictureBoxDoctorSignature.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBoxDoctorSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxDoctorSignature.Enabled = False
        Me.PictureBoxDoctorSignature.Location = New System.Drawing.Point(405, 275)
        Me.PictureBoxDoctorSignature.Name = "PictureBoxDoctorSignature"
        Me.PictureBoxDoctorSignature.Size = New System.Drawing.Size(165, 98)
        Me.PictureBoxDoctorSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxDoctorSignature.TabIndex = 181
        Me.PictureBoxDoctorSignature.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBoxDoctorSignature, "Doubleclick to capture Doctor's Signature")
        '
        'ListViewNPI
        '
        Me.ListViewNPI.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewNPI.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListViewNPI.FullRowSelect = True
        Me.ListViewNPI.GridLines = True
        Me.ListViewNPI.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewNPI.HideSelection = False
        Me.ListViewNPI.Location = New System.Drawing.Point(17, 15)
        Me.ListViewNPI.Name = "ListViewNPI"
        Me.ListViewNPI.ShowItemToolTips = True
        Me.ListViewNPI.Size = New System.Drawing.Size(557, 351)
        Me.ListViewNPI.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.ListViewNPI, "Employee Offices")
        Me.ListViewNPI.UseCompatibleStateImageBehavior = False
        Me.ListViewNPI.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Insurance Company"
        Me.ColumnHeader4.Width = 345
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "NPI"
        Me.ColumnHeader5.Width = 181
        '
        'ButtonWebAdminRefresh
        '
        Me.ButtonWebAdminRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonWebAdminRefresh.FlatAppearance.BorderSize = 0
        Me.ButtonWebAdminRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonWebAdminRefresh.Image = CType(resources.GetObject("ButtonWebAdminRefresh.Image"), System.Drawing.Image)
        Me.ButtonWebAdminRefresh.Location = New System.Drawing.Point(3, -4)
        Me.ButtonWebAdminRefresh.Name = "ButtonWebAdminRefresh"
        Me.ButtonWebAdminRefresh.Size = New System.Drawing.Size(24, 25)
        Me.ButtonWebAdminRefresh.TabIndex = 179
        Me.ToolTip1.SetToolTip(Me.ButtonWebAdminRefresh, "Auto Generate Web Access Login Information")
        Me.ButtonWebAdminRefresh.UseVisualStyleBackColor = True
        '
        'cmdSelectPictureFile
        '
        Me.cmdSelectPictureFile.Enabled = False
        Me.cmdSelectPictureFile.Image = CType(resources.GetObject("cmdSelectPictureFile.Image"), System.Drawing.Image)
        Me.cmdSelectPictureFile.Location = New System.Drawing.Point(456, 250)
        Me.cmdSelectPictureFile.Name = "cmdSelectPictureFile"
        Me.cmdSelectPictureFile.Size = New System.Drawing.Size(32, 24)
        Me.cmdSelectPictureFile.TabIndex = 27
        Me.ToolTip1.SetToolTip(Me.cmdSelectPictureFile, "Load Doctor's Signature From File")
        Me.cmdSelectPictureFile.UseVisualStyleBackColor = True
        '
        'cmdSelectPicture
        '
        Me.cmdSelectPicture.Enabled = False
        Me.cmdSelectPicture.Image = CType(resources.GetObject("cmdSelectPicture.Image"), System.Drawing.Image)
        Me.cmdSelectPicture.Location = New System.Drawing.Point(497, 250)
        Me.cmdSelectPicture.Name = "cmdSelectPicture"
        Me.cmdSelectPicture.Size = New System.Drawing.Size(32, 24)
        Me.cmdSelectPicture.TabIndex = 28
        Me.ToolTip1.SetToolTip(Me.cmdSelectPicture, "Capture Doctor's Information by Signature Device")
        Me.cmdSelectPicture.UseVisualStyleBackColor = True
        '
        'cmdRemovePicture
        '
        Me.cmdRemovePicture.Enabled = False
        Me.cmdRemovePicture.Image = CType(resources.GetObject("cmdRemovePicture.Image"), System.Drawing.Image)
        Me.cmdRemovePicture.Location = New System.Drawing.Point(538, 250)
        Me.cmdRemovePicture.Name = "cmdRemovePicture"
        Me.cmdRemovePicture.Size = New System.Drawing.Size(32, 24)
        Me.cmdRemovePicture.TabIndex = 29
        Me.ToolTip1.SetToolTip(Me.cmdRemovePicture, "Delete Doctor's Signature")
        Me.cmdRemovePicture.UseVisualStyleBackColor = True
        '
        'PictureBoxAlias
        '
        Me.PictureBoxAlias.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxAlias.Image = CType(resources.GetObject("PictureBoxAlias.Image"), System.Drawing.Image)
        Me.PictureBoxAlias.Location = New System.Drawing.Point(562, 52)
        Me.PictureBoxAlias.Name = "PictureBoxAlias"
        Me.PictureBoxAlias.Size = New System.Drawing.Size(16, 16)
        Me.PictureBoxAlias.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBoxAlias.TabIndex = 279
        Me.PictureBoxAlias.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBoxAlias, "Used to differentiate multiple employees with the same name (For Ex. When Doctor " &
        "has multiple P.C., more than one profile will be created for the same doctor.)")
        '
        'lblAbbreviationDescription
        '
        Me.lblAbbreviationDescription.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblAbbreviationDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAbbreviationDescription.Location = New System.Drawing.Point(334, 105)
        Me.lblAbbreviationDescription.Name = "lblAbbreviationDescription"
        Me.lblAbbreviationDescription.Size = New System.Drawing.Size(50, 21)
        Me.lblAbbreviationDescription.TabIndex = 7
        Me.lblAbbreviationDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.lblAbbreviationDescription, "Doctor specialty description")
        '
        'ComboBoxAbbreviation
        '
        Me.ComboBoxAbbreviation.Enabled = False
        Me.ComboBoxAbbreviation.FormattingEnabled = True
        Me.ComboBoxAbbreviation.Location = New System.Drawing.Point(262, 105)
        Me.ComboBoxAbbreviation.Name = "ComboBoxAbbreviation"
        Me.ComboBoxAbbreviation.Size = New System.Drawing.Size(66, 21)
        Me.ComboBoxAbbreviation.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.ComboBoxAbbreviation, "Doctor specialty abbreviation")
        '
        'ComboBoxreferralColor
        '
        Me.ComboBoxreferralColor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ComboBoxreferralColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxreferralColor.DropDownHeight = 150
        Me.ComboBoxreferralColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxreferralColor.Enabled = False
        Me.ComboBoxreferralColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBoxreferralColor.FormattingEnabled = True
        Me.ComboBoxreferralColor.IntegralHeight = False
        Me.ComboBoxreferralColor.Location = New System.Drawing.Point(405, 389)
        Me.ComboBoxreferralColor.Name = "ComboBoxreferralColor"
        Me.ComboBoxreferralColor.Size = New System.Drawing.Size(165, 21)
        Me.ComboBoxreferralColor.TabIndex = 30
        Me.ToolTip1.SetToolTip(Me.ComboBoxreferralColor, "Used to identify doctor by referral color")
        '
        'cmdRemovePCLogo
        '
        Me.cmdRemovePCLogo.Enabled = False
        Me.cmdRemovePCLogo.Image = CType(resources.GetObject("cmdRemovePCLogo.Image"), System.Drawing.Image)
        Me.cmdRemovePCLogo.Location = New System.Drawing.Point(539, 81)
        Me.cmdRemovePCLogo.Name = "cmdRemovePCLogo"
        Me.cmdRemovePCLogo.Size = New System.Drawing.Size(32, 24)
        Me.cmdRemovePCLogo.TabIndex = 26
        Me.ToolTip1.SetToolTip(Me.cmdRemovePCLogo, "Delete PC Logo")
        Me.cmdRemovePCLogo.UseVisualStyleBackColor = True
        '
        'cmdSelectPicturePCLogo
        '
        Me.cmdSelectPicturePCLogo.Enabled = False
        Me.cmdSelectPicturePCLogo.Image = CType(resources.GetObject("cmdSelectPicturePCLogo.Image"), System.Drawing.Image)
        Me.cmdSelectPicturePCLogo.Location = New System.Drawing.Point(503, 81)
        Me.cmdSelectPicturePCLogo.Name = "cmdSelectPicturePCLogo"
        Me.cmdSelectPicturePCLogo.Size = New System.Drawing.Size(32, 24)
        Me.cmdSelectPicturePCLogo.TabIndex = 25
        Me.ToolTip1.SetToolTip(Me.cmdSelectPicturePCLogo, "Load PC Logo File 80 x 80 x 300 px")
        Me.cmdSelectPicturePCLogo.UseVisualStyleBackColor = True
        '
        'PictureBoxPCLogo
        '
        Me.PictureBoxPCLogo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBoxPCLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxPCLogo.Enabled = False
        Me.PictureBoxPCLogo.Location = New System.Drawing.Point(406, 106)
        Me.PictureBoxPCLogo.Name = "PictureBoxPCLogo"
        Me.PictureBoxPCLogo.Size = New System.Drawing.Size(165, 98)
        Me.PictureBoxPCLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxPCLogo.TabIndex = 210
        Me.PictureBoxPCLogo.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBoxPCLogo, "Doubleclick to capture Doctor's Signature")
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(3, -5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 25)
        Me.Button2.TabIndex = 181
        Me.ToolTip1.SetToolTip(Me.Button2, "Auto Generate Web Access Login Information")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(47, 37)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 25)
        Me.Button1.TabIndex = 180
        Me.ToolTip1.SetToolTip(Me.Button1, "Auto Generate Web Access Login Information")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.DoctorInfo)
        Me.TabControl1.Controls.Add(Me.DoctorNPI)
        Me.TabControl1.Controls.Add(Me.EmailTab)
        Me.TabControl1.Location = New System.Drawing.Point(203, 18)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(592, 448)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PictureBoxAlias)
        Me.TabPage1.Controls.Add(Me.CheckBoxActiveInd)
        Me.TabPage1.Controls.Add(Me.Label41)
        Me.TabPage1.Controls.Add(Me.txtAlias)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.txtComments)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.TextBoxMI)
        Me.TabPage1.Controls.Add(Me.txtEmail)
        Me.TabPage1.Controls.Add(Me.ComboBoxState)
        Me.TabPage1.Controls.Add(Me.txtZip)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtCellPhone)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.txtPhone1)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtCity)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtAddress2)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtAddress1)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtSSN)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtDOB)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtLname)
        Me.TabPage1.Controls.Add(Me.txtFname)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(584, 422)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Personal Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(17, 52)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(29, 13)
        Me.Label41.TabIndex = 161
        Me.Label41.Text = "Alias"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(17, 286)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 13)
        Me.Label28.TabIndex = 159
        Me.Label28.Text = "Comments"
        '
        'txtComments
        '
        Me.txtComments.Enabled = False
        Me.txtComments.Location = New System.Drawing.Point(17, 301)
        Me.txtComments.MaxLength = 255
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(559, 115)
        Me.txtComments.TabIndex = 14
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(287, 15)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(19, 13)
        Me.Label26.TabIndex = 137
        Me.Label26.Text = "MI"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 247)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 128
        Me.Label14.Text = "Email"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(289, 209)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 127
        Me.Label13.Text = "Cell Phone"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 208)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "Phone"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(289, 169)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 124
        Me.Label10.Text = "State"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(434, 169)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 123
        Me.Label8.Text = "Zip Code"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 13)
        Me.Label9.TabIndex = 122
        Me.Label9.Text = "City"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(287, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 121
        Me.Label7.Text = "Address 2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 120
        Me.Label6.Text = "Address 1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(289, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 119
        Me.Label5.Text = "SSN"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 118
        Me.Label4.Text = "DOB"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(342, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Last Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "First Name"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBoxWeb)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.ComboBoxPosition)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.txtDateHired)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(584, 422)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Work Information"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBoxWeb
        '
        Me.GroupBoxWeb.Controls.Add(Me.Label12)
        Me.GroupBoxWeb.Controls.Add(Me.Button1)
        Me.GroupBoxWeb.Controls.Add(Me.ComboBoxTreatingProvider)
        Me.GroupBoxWeb.Controls.Add(Me.ButtonWebAdminRefresh)
        Me.GroupBoxWeb.Controls.Add(Me.lblWebAdminUID)
        Me.GroupBoxWeb.Controls.Add(Me.lblWebAdminPWD)
        Me.GroupBoxWeb.Controls.Add(Me.txtWebAdminUID)
        Me.GroupBoxWeb.Controls.Add(Me.txtWebAdminPWD)
        Me.GroupBoxWeb.Location = New System.Drawing.Point(17, 146)
        Me.GroupBoxWeb.Name = "GroupBoxWeb"
        Me.GroupBoxWeb.Size = New System.Drawing.Size(546, 130)
        Me.GroupBoxWeb.TabIndex = 181
        Me.GroupBoxWeb.TabStop = False
        Me.GroupBoxWeb.Text = "        Web Credentials"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(77, 75)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 13)
        Me.Label12.TabIndex = 183
        Me.Label12.Text = "Treating Provider"
        '
        'lblWebAdminUID
        '
        Me.lblWebAdminUID.AutoSize = True
        Me.lblWebAdminUID.Location = New System.Drawing.Point(77, 25)
        Me.lblWebAdminUID.Name = "lblWebAdminUID"
        Me.lblWebAdminUID.Size = New System.Drawing.Size(60, 13)
        Me.lblWebAdminUID.TabIndex = 177
        Me.lblWebAdminUID.Text = "User Name"
        '
        'lblWebAdminPWD
        '
        Me.lblWebAdminPWD.AutoSize = True
        Me.lblWebAdminPWD.Location = New System.Drawing.Point(299, 26)
        Me.lblWebAdminPWD.Name = "lblWebAdminPWD"
        Me.lblWebAdminPWD.Size = New System.Drawing.Size(53, 13)
        Me.lblWebAdminPWD.TabIndex = 178
        Me.lblWebAdminPWD.Text = "Password"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBoxPassword)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtUID)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(17, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(547, 74)
        Me.GroupBox1.TabIndex = 180
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "        System Credentials"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(78, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 13)
        Me.Label18.TabIndex = 142
        Me.Label18.Text = "User Name"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(300, 21)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(53, 13)
        Me.Label25.TabIndex = 143
        Me.Label25.Text = "Password"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(95, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 13)
        Me.Label16.TabIndex = 140
        Me.Label16.Text = "Position"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 13)
        Me.Label15.TabIndex = 110
        Me.Label15.Text = "Date Hired"
        '
        'DoctorInfo
        '
        Me.DoctorInfo.Controls.Add(Me.txtCorporationDBA)
        Me.DoctorInfo.Controls.Add(Me.Label1)
        Me.DoctorInfo.Controls.Add(Me.Label22)
        Me.DoctorInfo.Controls.Add(Me.txtCorporateFax)
        Me.DoctorInfo.Controls.Add(Me.Label23)
        Me.DoctorInfo.Controls.Add(Me.txtCorporatePhone)
        Me.DoctorInfo.Controls.Add(Me.cmdRemovePCLogo)
        Me.DoctorInfo.Controls.Add(Me.cmdSelectPicturePCLogo)
        Me.DoctorInfo.Controls.Add(Me.Label31)
        Me.DoctorInfo.Controls.Add(Me.PictureBoxPCLogo)
        Me.DoctorInfo.Controls.Add(Me.lblAbbreviationDescription)
        Me.DoctorInfo.Controls.Add(Me.Label46)
        Me.DoctorInfo.Controls.Add(Me.txtDoctorTitle1)
        Me.DoctorInfo.Controls.Add(Me.ComboBoxAbbreviation)
        Me.DoctorInfo.Controls.Add(Me.Label45)
        Me.DoctorInfo.Controls.Add(Me.Label44)
        Me.DoctorInfo.Controls.Add(Me.txtWCProviderNPI)
        Me.DoctorInfo.Controls.Add(Me.Label43)
        Me.DoctorInfo.Controls.Add(Me.txtWCBRatingCode)
        Me.DoctorInfo.Controls.Add(Me.Label42)
        Me.DoctorInfo.Controls.Add(Me.txtWCBAuthorizationNumber)
        Me.DoctorInfo.Controls.Add(Me.Label29)
        Me.DoctorInfo.Controls.Add(Me.txtAccountNumber)
        Me.DoctorInfo.Controls.Add(Me.ComboBoxreferralColor)
        Me.DoctorInfo.Controls.Add(Me.cmdRemovePicture)
        Me.DoctorInfo.Controls.Add(Me.cmdSelectPicture)
        Me.DoctorInfo.Controls.Add(Me.cmdSelectPictureFile)
        Me.DoctorInfo.Controls.Add(Me.Label19)
        Me.DoctorInfo.Controls.Add(Me.PictureBoxDoctorSignature)
        Me.DoctorInfo.Controls.Add(Me.CheckBoxPrivate)
        Me.DoctorInfo.Controls.Add(Me.CheckBoxNoFault)
        Me.DoctorInfo.Controls.Add(Me.txtDoctorTitle)
        Me.DoctorInfo.Controls.Add(Me.Label40)
        Me.DoctorInfo.Controls.Add(Me.txtCorporationTaxID)
        Me.DoctorInfo.Controls.Add(Me.Label39)
        Me.DoctorInfo.Controls.Add(Me.CheckBoxTreatmentPrv)
        Me.DoctorInfo.Controls.Add(Me.CheckBoxBillingPrv)
        Me.DoctorInfo.Controls.Add(Me.txtCorporationName)
        Me.DoctorInfo.Controls.Add(Me.Label32)
        Me.DoctorInfo.Controls.Add(Me.ListViewDoctorDiagnostics)
        Me.DoctorInfo.Controls.Add(Me.Label30)
        Me.DoctorInfo.Controls.Add(Me.Label21)
        Me.DoctorInfo.Controls.Add(Me.txtLICNumber)
        Me.DoctorInfo.Controls.Add(Me.txtCorporationAddress1)
        Me.DoctorInfo.Controls.Add(Me.Label33)
        Me.DoctorInfo.Controls.Add(Me.ComboBoxCorporationState)
        Me.DoctorInfo.Controls.Add(Me.txtCorporationAddress2)
        Me.DoctorInfo.Controls.Add(Me.txtCorporationZip)
        Me.DoctorInfo.Controls.Add(Me.Label34)
        Me.DoctorInfo.Controls.Add(Me.txtCorporationCity)
        Me.DoctorInfo.Controls.Add(Me.Label35)
        Me.DoctorInfo.Controls.Add(Me.Label36)
        Me.DoctorInfo.Controls.Add(Me.Label37)
        Me.DoctorInfo.Controls.Add(Me.Label24)
        Me.DoctorInfo.Location = New System.Drawing.Point(4, 22)
        Me.DoctorInfo.Name = "DoctorInfo"
        Me.DoctorInfo.Size = New System.Drawing.Size(584, 422)
        Me.DoctorInfo.TabIndex = 3
        Me.DoctorInfo.Text = "Doctor Information"
        Me.DoctorInfo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 220
        Me.Label1.Text = "Corporation DBA"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(143, 253)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(116, 13)
        Me.Label22.TabIndex = 218
        Me.Label22.Text = "Doctor / Corporate Fax"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(16, 253)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(130, 13)
        Me.Label23.TabIndex = 217
        Me.Label23.Text = "Doctor / Corporate Phone"
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(403, 89)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(52, 17)
        Me.Label31.TabIndex = 211
        Me.Label31.Text = "PC Logo"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(15, 91)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(71, 13)
        Me.Label46.TabIndex = 208
        Me.Label46.Text = "Doctor Title 1"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(274, 92)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(50, 13)
        Me.Label45.TabIndex = 205
        Me.Label45.Text = "Specialty"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(289, 19)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(95, 13)
        Me.Label44.TabIndex = 203
        Me.Label44.Text = "WC Provider's NPI"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(189, 19)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(94, 13)
        Me.Label43.TabIndex = 201
        Me.Label43.Text = "WCB Rating Code"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(77, 19)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(106, 13)
        Me.Label42.TabIndex = 199
        Me.Label42.Text = "WCB Authorization #"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(16, 294)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(256, 13)
        Me.Label29.TabIndex = 197
        Me.Label29.Text = "Checking Account Number - For Deposit Slip Printing"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(402, 246)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 29)
        Me.Label19.TabIndex = 183
        Me.Label19.Text = "Doctor Siganture"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(14, 55)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(62, 13)
        Me.Label40.TabIndex = 177
        Me.Label40.Text = "Doctor Title"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(289, 126)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(88, 13)
        Me.Label39.TabIndex = 176
        Me.Label39.Text = "Corporate Tax ID"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(14, 129)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(92, 13)
        Me.Label32.TabIndex = 174
        Me.Label32.Text = "Corporation Name"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(13, 334)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(62, 13)
        Me.Label30.TabIndex = 171
        Me.Label30.Text = "Diagnostics"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(12, 19)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 170
        Me.Label21.Text = "LIC Number"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(14, 214)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(54, 13)
        Me.Label33.TabIndex = 161
        Me.Label33.Text = "Address 1"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(143, 214)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(54, 13)
        Me.Label34.TabIndex = 162
        Me.Label34.Text = "Address 2"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(220, 215)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(27, 13)
        Me.Label35.TabIndex = 163
        Me.Label35.Text = " City"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(377, 215)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(22, 13)
        Me.Label36.TabIndex = 164
        Me.Label36.Text = "Zip"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(276, 214)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(32, 13)
        Me.Label37.TabIndex = 165
        Me.Label37.Text = "State"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(402, 376)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(71, 13)
        Me.Label24.TabIndex = 195
        Me.Label24.Text = "Referral Color"
        '
        'DoctorNPI
        '
        Me.DoctorNPI.Controls.Add(Me.ButtonDeleteNPI)
        Me.DoctorNPI.Controls.Add(Me.ButtonAddNPI)
        Me.DoctorNPI.Controls.Add(Me.ListViewNPI)
        Me.DoctorNPI.Location = New System.Drawing.Point(4, 22)
        Me.DoctorNPI.Name = "DoctorNPI"
        Me.DoctorNPI.Size = New System.Drawing.Size(584, 422)
        Me.DoctorNPI.TabIndex = 4
        Me.DoctorNPI.Text = "Doctor NPI"
        Me.DoctorNPI.UseVisualStyleBackColor = True
        '
        'ButtonDeleteNPI
        '
        Me.ButtonDeleteNPI.Enabled = False
        Me.ButtonDeleteNPI.Location = New System.Drawing.Point(423, 372)
        Me.ButtonDeleteNPI.Name = "ButtonDeleteNPI"
        Me.ButtonDeleteNPI.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDeleteNPI.TabIndex = 9
        Me.ButtonDeleteNPI.Text = "Delete"
        Me.ButtonDeleteNPI.UseVisualStyleBackColor = True
        '
        'ButtonAddNPI
        '
        Me.ButtonAddNPI.Enabled = False
        Me.ButtonAddNPI.Location = New System.Drawing.Point(504, 372)
        Me.ButtonAddNPI.Name = "ButtonAddNPI"
        Me.ButtonAddNPI.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAddNPI.TabIndex = 10
        Me.ButtonAddNPI.Text = "Add New"
        Me.ButtonAddNPI.UseVisualStyleBackColor = True
        '
        'EmailTab
        '
        Me.EmailTab.Controls.Add(Me.PanelEmailWarning)
        Me.EmailTab.Controls.Add(Me.CheckBoxEmail10)
        Me.EmailTab.Controls.Add(Me.CheckBoxEmail9)
        Me.EmailTab.Controls.Add(Me.CheckBoxEmail8)
        Me.EmailTab.Controls.Add(Me.CheckBoxEmail7)
        Me.EmailTab.Controls.Add(Me.CheckBoxEmail6)
        Me.EmailTab.Controls.Add(Me.CheckBoxEmail5)
        Me.EmailTab.Controls.Add(Me.CheckBoxEmail1)
        Me.EmailTab.Controls.Add(Me.CheckBoxEmail4)
        Me.EmailTab.Controls.Add(Me.CheckBoxEmail2)
        Me.EmailTab.Controls.Add(Me.CheckBoxEmail3)
        Me.EmailTab.Location = New System.Drawing.Point(4, 22)
        Me.EmailTab.Name = "EmailTab"
        Me.EmailTab.Size = New System.Drawing.Size(584, 422)
        Me.EmailTab.TabIndex = 5
        Me.EmailTab.Text = "Email Alerts"
        Me.EmailTab.UseVisualStyleBackColor = True
        '
        'PanelEmailWarning
        '
        Me.PanelEmailWarning.Controls.Add(Me.Label27)
        Me.PanelEmailWarning.Controls.Add(Me.PictureBox2)
        Me.PanelEmailWarning.Location = New System.Drawing.Point(22, 388)
        Me.PanelEmailWarning.Name = "PanelEmailWarning"
        Me.PanelEmailWarning.Size = New System.Drawing.Size(559, 31)
        Me.PanelEmailWarning.TabIndex = 12
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(28, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(387, 26)
        Me.Label27.TabIndex = 1
        Me.Label27.Text = "The eMail system setup has not been completed. No eMail alerts will be sent out." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please open the Office maintenance function and setup the eMail system."
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 22)
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'CheckBoxEmail10
        '
        Me.CheckBoxEmail10.AutoSize = True
        Me.CheckBoxEmail10.Enabled = False
        Me.CheckBoxEmail10.Location = New System.Drawing.Point(22, 226)
        Me.CheckBoxEmail10.Name = "CheckBoxEmail10"
        Me.CheckBoxEmail10.Size = New System.Drawing.Size(72, 17)
        Me.CheckBoxEmail10.TabIndex = 11
        Me.CheckBoxEmail10.Text = "Reserved"
        Me.CheckBoxEmail10.UseVisualStyleBackColor = True
        Me.CheckBoxEmail10.Visible = False
        '
        'CheckBoxEmail9
        '
        Me.CheckBoxEmail9.AutoSize = True
        Me.CheckBoxEmail9.Enabled = False
        Me.CheckBoxEmail9.Location = New System.Drawing.Point(22, 203)
        Me.CheckBoxEmail9.Name = "CheckBoxEmail9"
        Me.CheckBoxEmail9.Size = New System.Drawing.Size(72, 17)
        Me.CheckBoxEmail9.TabIndex = 10
        Me.CheckBoxEmail9.Text = "Reserved"
        Me.CheckBoxEmail9.UseVisualStyleBackColor = True
        Me.CheckBoxEmail9.Visible = False
        '
        'CheckBoxEmail8
        '
        Me.CheckBoxEmail8.AutoSize = True
        Me.CheckBoxEmail8.Enabled = False
        Me.CheckBoxEmail8.Location = New System.Drawing.Point(22, 180)
        Me.CheckBoxEmail8.Name = "CheckBoxEmail8"
        Me.CheckBoxEmail8.Size = New System.Drawing.Size(72, 17)
        Me.CheckBoxEmail8.TabIndex = 9
        Me.CheckBoxEmail8.Text = "Reserved"
        Me.CheckBoxEmail8.UseVisualStyleBackColor = True
        Me.CheckBoxEmail8.Visible = False
        '
        'CheckBoxEmail7
        '
        Me.CheckBoxEmail7.AutoSize = True
        Me.CheckBoxEmail7.Enabled = False
        Me.CheckBoxEmail7.Location = New System.Drawing.Point(22, 157)
        Me.CheckBoxEmail7.Name = "CheckBoxEmail7"
        Me.CheckBoxEmail7.Size = New System.Drawing.Size(72, 17)
        Me.CheckBoxEmail7.TabIndex = 8
        Me.CheckBoxEmail7.Text = "Reserved"
        Me.CheckBoxEmail7.UseVisualStyleBackColor = True
        Me.CheckBoxEmail7.Visible = False
        '
        'CheckBoxEmail6
        '
        Me.CheckBoxEmail6.AutoSize = True
        Me.CheckBoxEmail6.Enabled = False
        Me.CheckBoxEmail6.Location = New System.Drawing.Point(22, 134)
        Me.CheckBoxEmail6.Name = "CheckBoxEmail6"
        Me.CheckBoxEmail6.Size = New System.Drawing.Size(72, 17)
        Me.CheckBoxEmail6.TabIndex = 5
        Me.CheckBoxEmail6.Text = "Reserved"
        Me.CheckBoxEmail6.UseVisualStyleBackColor = True
        Me.CheckBoxEmail6.Visible = False
        '
        'CheckBoxEmail5
        '
        Me.CheckBoxEmail5.AutoSize = True
        Me.CheckBoxEmail5.Enabled = False
        Me.CheckBoxEmail5.Location = New System.Drawing.Point(22, 111)
        Me.CheckBoxEmail5.Name = "CheckBoxEmail5"
        Me.CheckBoxEmail5.Size = New System.Drawing.Size(72, 17)
        Me.CheckBoxEmail5.TabIndex = 4
        Me.CheckBoxEmail5.Text = "Reserved"
        Me.CheckBoxEmail5.UseVisualStyleBackColor = True
        Me.CheckBoxEmail5.Visible = False
        '
        'CheckBoxEmail1
        '
        Me.CheckBoxEmail1.AutoSize = True
        Me.CheckBoxEmail1.Enabled = False
        Me.CheckBoxEmail1.Location = New System.Drawing.Point(22, 19)
        Me.CheckBoxEmail1.Name = "CheckBoxEmail1"
        Me.CheckBoxEmail1.Size = New System.Drawing.Size(129, 17)
        Me.CheckBoxEmail1.TabIndex = 0
        Me.CheckBoxEmail1.Text = "Office Statistic Report"
        Me.CheckBoxEmail1.UseVisualStyleBackColor = True
        '
        'CheckBoxEmail4
        '
        Me.CheckBoxEmail4.AutoSize = True
        Me.CheckBoxEmail4.Enabled = False
        Me.CheckBoxEmail4.Location = New System.Drawing.Point(22, 88)
        Me.CheckBoxEmail4.Name = "CheckBoxEmail4"
        Me.CheckBoxEmail4.Size = New System.Drawing.Size(72, 17)
        Me.CheckBoxEmail4.TabIndex = 3
        Me.CheckBoxEmail4.Text = "Reserved"
        Me.CheckBoxEmail4.UseVisualStyleBackColor = True
        Me.CheckBoxEmail4.Visible = False
        '
        'CheckBoxEmail2
        '
        Me.CheckBoxEmail2.AutoSize = True
        Me.CheckBoxEmail2.Enabled = False
        Me.CheckBoxEmail2.Location = New System.Drawing.Point(22, 42)
        Me.CheckBoxEmail2.Name = "CheckBoxEmail2"
        Me.CheckBoxEmail2.Size = New System.Drawing.Size(138, 17)
        Me.CheckBoxEmail2.TabIndex = 1
        Me.CheckBoxEmail2.Text = "Admin Warnings Report"
        Me.CheckBoxEmail2.UseVisualStyleBackColor = True
        '
        'CheckBoxEmail3
        '
        Me.CheckBoxEmail3.AutoSize = True
        Me.CheckBoxEmail3.Enabled = False
        Me.CheckBoxEmail3.Location = New System.Drawing.Point(22, 65)
        Me.CheckBoxEmail3.Name = "CheckBoxEmail3"
        Me.CheckBoxEmail3.Size = New System.Drawing.Size(72, 17)
        Me.CheckBoxEmail3.TabIndex = 2
        Me.CheckBoxEmail3.Text = "Reserved"
        Me.CheckBoxEmail3.UseVisualStyleBackColor = True
        Me.CheckBoxEmail3.Visible = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Location = New System.Drawing.Point(2, 3)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(27, 13)
        Me.Label38.TabIndex = 157
        Me.Label38.Text = "Find"
        '
        'openFD
        '
        Me.openFD.FileName = "OpenFileDialog1"
        '
        'MonthCalendarPopUp
        '
        Me.MonthCalendarPopUp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MonthCalendarPopUp.Location = New System.Drawing.Point(0, 106)
        Me.MonthCalendarPopUp.Margin = New System.Windows.Forms.Padding(0)
        Me.MonthCalendarPopUp.MaxSelectionCount = 1
        Me.MonthCalendarPopUp.Name = "MonthCalendarPopUp"
        Me.MonthCalendarPopUp.TabIndex = 279
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(760, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'ContextMenuStripOffices
        '
        Me.ContextMenuStripOffices.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToOfficeToolStripMenuItem})
        Me.ContextMenuStripOffices.Name = "ContextMenuStripOffices"
        Me.ContextMenuStripOffices.Size = New System.Drawing.Size(153, 26)
        '
        'CopyToOfficeToolStripMenuItem
        '
        Me.CopyToOfficeToolStripMenuItem.Image = CType(resources.GetObject("CopyToOfficeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyToOfficeToolStripMenuItem.Name = "CopyToOfficeToolStripMenuItem"
        Me.CopyToOfficeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CopyToOfficeToolStripMenuItem.Text = "Copy To Office"
        '
        'PictureBoxPassword
        '
        Me.PictureBoxPassword.BackColor = System.Drawing.Color.White
        Me.PictureBoxPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxPassword.Image = CType(resources.GetObject("PictureBoxPassword.Image"), System.Drawing.Image)
        Me.PictureBoxPassword.Location = New System.Drawing.Point(517, 40)
        Me.PictureBoxPassword.Name = "PictureBoxPassword"
        Me.PictureBoxPassword.Size = New System.Drawing.Size(21, 15)
        Me.PictureBoxPassword.TabIndex = 182
        Me.PictureBoxPassword.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBoxPassword, "Show Hidden Password Characters")
        '
        'frmEmployeeMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(798, 506)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TextBoxSearch)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.ListViewEmployees)
        Me.Controls.Add(Me.MonthCalendarPopUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmEmployeeMaintenance"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Employees Maintenance"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuPopUpCalendar.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBoxDoctorSignature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxAlias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxPCLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBoxWeb.ResumeLayout(False)
        Me.GroupBoxWeb.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.DoctorInfo.ResumeLayout(False)
        Me.DoctorInfo.PerformLayout()
        Me.DoctorNPI.ResumeLayout(False)
        Me.EmailTab.ResumeLayout(False)
        Me.EmailTab.PerformLayout()
        Me.PanelEmailWarning.ResumeLayout(False)
        Me.PanelEmailWarning.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripOffices.ResumeLayout(False)
        CType(Me.PictureBoxPassword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents ListViewEmployees As System.Windows.Forms.ListView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents CheckBoxActiveInd As System.Windows.Forms.CheckBox
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxState As System.Windows.Forms.ComboBox
    Friend WithEvents txtZip As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCellPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPhone1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSSN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDOB As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLname As System.Windows.Forms.TextBox
    Friend WithEvents txtFname As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtDateHired As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ComboBoxPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUID As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TextBoxMI As System.Windows.Forms.TextBox
    Friend WithEvents DoctorInfo As System.Windows.Forms.TabPage
    Friend WithEvents txtCorporationAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCorporationState As System.Windows.Forms.ComboBox
    Friend WithEvents txtCorporationAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCorporationZip As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtCorporationCity As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtLICNumber As System.Windows.Forms.TextBox
    Friend WithEvents ListViewDoctorDiagnostics As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtCorporationName As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxTreatmentPrv As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxBillingPrv As System.Windows.Forms.CheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtCorporationTaxID As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxPrivate As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxNoFault As System.Windows.Forms.CheckBox
    Friend WithEvents txtDoctorTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents DoctorNPI As System.Windows.Forms.TabPage
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxDoctorSignature As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonDeleteNPI As System.Windows.Forms.Button
    Friend WithEvents ButtonAddNPI As System.Windows.Forms.Button
    Friend WithEvents ListViewNPI As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblWebAdminPWD As System.Windows.Forms.Label
    Friend WithEvents lblWebAdminUID As System.Windows.Forms.Label
    Friend WithEvents txtWebAdminPWD As System.Windows.Forms.TextBox
    Friend WithEvents txtWebAdminUID As System.Windows.Forms.TextBox
    Friend WithEvents ButtonWebAdminRefresh As System.Windows.Forms.Button
    Friend WithEvents openFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdSelectPicture As System.Windows.Forms.Button
    Friend WithEvents cmdSelectPictureFile As System.Windows.Forms.Button
    Friend WithEvents cmdRemovePicture As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxreferralColor As System.Windows.Forms.ComboBox
    Friend WithEvents txtAccountNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxAlias As System.Windows.Forms.PictureBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtWCBAuthorizationNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtWCBRatingCode As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtWCProviderNPI As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtDoctorTitle1 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxAbbreviation As System.Windows.Forms.ComboBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents lblAbbreviationDescription As System.Windows.Forms.Label
    Friend WithEvents cmdRemovePCLogo As System.Windows.Forms.Button
    Friend WithEvents cmdSelectPicturePCLogo As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxPCLogo As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuPopUpCalendar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonthCalendarPopUp As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCorporateFax As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtCorporatePhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents EmailTab As System.Windows.Forms.TabPage
    Friend WithEvents CheckBoxEmail4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxEmail3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxEmail2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxEmail1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxEmail5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxEmail6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxEmail10 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxEmail9 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxEmail8 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxEmail7 As System.Windows.Forms.CheckBox
    Friend WithEvents PanelEmailWarning As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxWeb As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents ButtonDistribute As Button
    Friend WithEvents ContextMenuStripOffices As ContextMenuStrip
    Friend WithEvents CopyToOfficeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents txtCorporationDBA As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents ComboBoxTreatingProvider As ComboBox
    Friend WithEvents PictureBoxPassword As PictureBox
End Class
