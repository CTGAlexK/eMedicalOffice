<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBillingSearch
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
        Dim ColumnHeaderRenderer1 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer3 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBillingSearch))
        Dim NamedStyle5 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("ColumnHeaderEnhanced")
        Dim NamedStyle6 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer2 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle7 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("HeaderDefault")
        Dim NamedStyle8 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType2 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin2 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim TextCellType4 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType5 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType6 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdShow = New System.Windows.Forms.Button()
        Me.PanelSearch = New System.Windows.Forms.Panel()
        Me.cboBillingProvider = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPolicyNumber = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtClaimNumber = New System.Windows.Forms.TextBox()
        Me.LabelMsg = New System.Windows.Forms.Label()
        Me.CheckBoxNetSearch = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCaseTypeID = New System.Windows.Forms.ComboBox()
        Me.ButtonFind = New System.Windows.Forms.Button()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboInsuranceCompanyID = New System.Windows.Forms.ComboBox()
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBillNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPatient = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.ListViewFound = New eMedicalOffice.ListViewDoubleBuffered()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ListViewSelected = New eMedicalOffice.ListViewDoubleBuffered()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.LabelSelected = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FpSpreadDetails = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpreadDetails_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.LabelOffice = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2.SuspendLayout()
        Me.PanelSearch.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.FpSpreadDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpreadDetails_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        ColumnHeaderRenderer1.Name = "ColumnHeaderRenderer1"
        ColumnHeaderRenderer1.TextRotationAngle = 0R
        ColumnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        ColumnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer2.Name = "ColumnHeaderRenderer2"
        ColumnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer2.TextRotationAngle = 0R
        ColumnHeaderRenderer3.Name = "ColumnHeaderRenderer3"
        ColumnHeaderRenderer3.TextRotationAngle = 0R
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.cmdShow)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 513)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1278, 34)
        Me.Panel2.TabIndex = 146
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.DimGray
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdClose.FlatAppearance.BorderSize = 0
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdClose.ForeColor = System.Drawing.Color.White
        Me.cmdClose.Location = New System.Drawing.Point(0, 0)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(95, 34)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.DimGray
        Me.cmdShow.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdShow.FlatAppearance.BorderSize = 0
        Me.cmdShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShow.ForeColor = System.Drawing.Color.White
        Me.cmdShow.Location = New System.Drawing.Point(1175, 0)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(103, 34)
        Me.cmdShow.TabIndex = 0
        Me.cmdShow.Text = "Show"
        Me.cmdShow.UseVisualStyleBackColor = False
        '
        'PanelSearch
        '
        Me.PanelSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelSearch.Controls.Add(Me.cboBillingProvider)
        Me.PanelSearch.Controls.Add(Me.Label13)
        Me.PanelSearch.Controls.Add(Me.Label10)
        Me.PanelSearch.Controls.Add(Me.txtPolicyNumber)
        Me.PanelSearch.Controls.Add(Me.Label9)
        Me.PanelSearch.Controls.Add(Me.txtClaimNumber)
        Me.PanelSearch.Controls.Add(Me.LabelMsg)
        Me.PanelSearch.Controls.Add(Me.CheckBoxNetSearch)
        Me.PanelSearch.Controls.Add(Me.Label1)
        Me.PanelSearch.Controls.Add(Me.cboCaseTypeID)
        Me.PanelSearch.Controls.Add(Me.ButtonFind)
        Me.PanelSearch.Controls.Add(Me.ButtonClear)
        Me.PanelSearch.Controls.Add(Me.Label7)
        Me.PanelSearch.Controls.Add(Me.cboInsuranceCompanyID)
        Me.PanelSearch.Controls.Add(Me.DateTimePickerTo)
        Me.PanelSearch.Controls.Add(Me.Label3)
        Me.PanelSearch.Controls.Add(Me.DateTimePickerFrom)
        Me.PanelSearch.Controls.Add(Me.Label6)
        Me.PanelSearch.Controls.Add(Me.Label5)
        Me.PanelSearch.Controls.Add(Me.txtBillNumber)
        Me.PanelSearch.Controls.Add(Me.Label2)
        Me.PanelSearch.Controls.Add(Me.txtPatient)
        Me.PanelSearch.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelSearch.Location = New System.Drawing.Point(0, 0)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Size = New System.Drawing.Size(193, 513)
        Me.PanelSearch.TabIndex = 0
        '
        'cboBillingProvider
        '
        Me.cboBillingProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingProvider.DropDownWidth = 240
        Me.cboBillingProvider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillingProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBillingProvider.ForeColor = System.Drawing.Color.Black
        Me.cboBillingProvider.FormattingEnabled = True
        Me.cboBillingProvider.Location = New System.Drawing.Point(7, 294)
        Me.cboBillingProvider.Name = "cboBillingProvider"
        Me.cboBillingProvider.Size = New System.Drawing.Size(180, 21)
        Me.cboBillingProvider.TabIndex = 279
        Me.ToolTip1.SetToolTip(Me.cboBillingProvider, "Billing Provider")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(5, 278)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 280
        Me.Label13.Text = "Billing Provider"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(5, 160)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 13)
        Me.Label10.TabIndex = 278
        Me.Label10.Text = "Policy #   start with....."
        '
        'txtPolicyNumber
        '
        Me.txtPolicyNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtPolicyNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyNumber.Location = New System.Drawing.Point(7, 176)
        Me.txtPolicyNumber.MaxLength = 10
        Me.txtPolicyNumber.Name = "txtPolicyNumber"
        Me.txtPolicyNumber.Size = New System.Drawing.Size(180, 20)
        Me.txtPolicyNumber.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(4, 121)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 13)
        Me.Label9.TabIndex = 276
        Me.Label9.Text = "Claim #   start with....."
        '
        'txtClaimNumber
        '
        Me.txtClaimNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtClaimNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtClaimNumber.Location = New System.Drawing.Point(7, 137)
        Me.txtClaimNumber.MaxLength = 10
        Me.txtClaimNumber.Name = "txtClaimNumber"
        Me.txtClaimNumber.Size = New System.Drawing.Size(180, 20)
        Me.txtClaimNumber.TabIndex = 3
        '
        'LabelMsg
        '
        Me.LabelMsg.BackColor = System.Drawing.Color.Transparent
        Me.LabelMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelMsg.ForeColor = System.Drawing.Color.White
        Me.LabelMsg.Location = New System.Drawing.Point(0, 483)
        Me.LabelMsg.Name = "LabelMsg"
        Me.LabelMsg.Size = New System.Drawing.Size(193, 30)
        Me.LabelMsg.TabIndex = 272
        Me.LabelMsg.Text = "Only bills from the current office can be added to selection list"
        Me.LabelMsg.Visible = False
        '
        'CheckBoxNetSearch
        '
        Me.CheckBoxNetSearch.AutoSize = True
        Me.CheckBoxNetSearch.ForeColor = System.Drawing.Color.White
        Me.CheckBoxNetSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CheckBoxNetSearch.Location = New System.Drawing.Point(8, 319)
        Me.CheckBoxNetSearch.Name = "CheckBoxNetSearch"
        Me.CheckBoxNetSearch.Size = New System.Drawing.Size(110, 17)
        Me.CheckBoxNetSearch.TabIndex = 271
        Me.CheckBoxNetSearch.Text = "Search All Offices"
        Me.CheckBoxNetSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxNetSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 270
        Me.Label1.Text = "Case Type"
        '
        'cboCaseTypeID
        '
        Me.cboCaseTypeID.BackColor = System.Drawing.Color.White
        Me.cboCaseTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaseTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCaseTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCaseTypeID.ForeColor = System.Drawing.Color.Black
        Me.cboCaseTypeID.FormattingEnabled = True
        Me.cboCaseTypeID.Location = New System.Drawing.Point(7, 19)
        Me.cboCaseTypeID.Name = "cboCaseTypeID"
        Me.cboCaseTypeID.Size = New System.Drawing.Size(180, 21)
        Me.cboCaseTypeID.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.cboCaseTypeID, "Case Type")
        '
        'ButtonFind
        '
        Me.ButtonFind.BackColor = System.Drawing.Color.DimGray
        Me.ButtonFind.FlatAppearance.BorderSize = 0
        Me.ButtonFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFind.ForeColor = System.Drawing.Color.White
        Me.ButtonFind.Image = CType(resources.GetObject("ButtonFind.Image"), System.Drawing.Image)
        Me.ButtonFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonFind.Location = New System.Drawing.Point(34, 352)
        Me.ButtonFind.Name = "ButtonFind"
        Me.ButtonFind.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ButtonFind.Size = New System.Drawing.Size(154, 25)
        Me.ButtonFind.TabIndex = 8
        Me.ButtonFind.Text = "    Find   "
        Me.ToolTip1.SetToolTip(Me.ButtonFind, "Find Records")
        Me.ButtonFind.UseVisualStyleBackColor = False
        '
        'ButtonClear
        '
        Me.ButtonClear.BackColor = System.Drawing.Color.DimGray
        Me.ButtonClear.FlatAppearance.BorderSize = 0
        Me.ButtonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClear.Image = CType(resources.GetObject("ButtonClear.Image"), System.Drawing.Image)
        Me.ButtonClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClear.Location = New System.Drawing.Point(7, 352)
        Me.ButtonClear.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(24, 25)
        Me.ButtonClear.TabIndex = 9
        Me.ButtonClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.ButtonClear, "Clear Search Criteria")
        Me.ButtonClear.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(5, 238)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 13)
        Me.Label7.TabIndex = 264
        Me.Label7.Text = "Insurance Company"
        '
        'cboInsuranceCompanyID
        '
        Me.cboInsuranceCompanyID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboInsuranceCompanyID.BackColor = System.Drawing.Color.White
        Me.cboInsuranceCompanyID.DropDownWidth = 300
        Me.cboInsuranceCompanyID.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboInsuranceCompanyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInsuranceCompanyID.ForeColor = System.Drawing.Color.Black
        Me.cboInsuranceCompanyID.FormattingEnabled = True
        Me.cboInsuranceCompanyID.Location = New System.Drawing.Point(7, 254)
        Me.cboInsuranceCompanyID.MaxDropDownItems = 40
        Me.cboInsuranceCompanyID.Name = "cboInsuranceCompanyID"
        Me.cboInsuranceCompanyID.Size = New System.Drawing.Size(180, 21)
        Me.cboInsuranceCompanyID.TabIndex = 7
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.Checked = False
        Me.DateTimePickerTo.CustomFormat = "MM/dd/yy"
        Me.DateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTo.Location = New System.Drawing.Point(102, 215)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.ShowCheckBox = True
        Me.DateTimePickerTo.Size = New System.Drawing.Size(86, 20)
        Me.DateTimePickerTo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(102, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 261
        Me.Label3.Text = "Bill To"
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.Checked = False
        Me.DateTimePickerFrom.CustomFormat = "MM/dd/yy"
        Me.DateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(7, 215)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.ShowCheckBox = True
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePickerFrom.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(5, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 258
        Me.Label6.Text = "Bill From"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(4, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 256
        Me.Label5.Text = "Bill #"
        '
        'txtBillNumber
        '
        Me.txtBillNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtBillNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtBillNumber.Location = New System.Drawing.Point(7, 96)
        Me.txtBillNumber.MaxLength = 10
        Me.txtBillNumber.Name = "txtBillNumber"
        Me.txtBillNumber.Size = New System.Drawing.Size(180, 20)
        Me.txtBillNumber.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(4, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 13)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "First/Last/##     any known part"
        '
        'txtPatient
        '
        Me.txtPatient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtPatient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPatient.Location = New System.Drawing.Point(7, 57)
        Me.txtPatient.Name = "txtPatient"
        Me.txtPatient.Size = New System.Drawing.Size(180, 20)
        Me.txtPatient.TabIndex = 1
        '
        'Button5
        '
        Me.Button5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(648, 0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(25, 23)
        Me.Button5.TabIndex = 273
        Me.ToolTip1.SetToolTip(Me.Button5, "Remove All")
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(569, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(25, 23)
        Me.Button4.TabIndex = 272
        Me.ToolTip1.SetToolTip(Me.Button4, "Remove Selected")
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(342, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(25, 23)
        Me.Button3.TabIndex = 271
        Me.ToolTip1.SetToolTip(Me.Button3, "Add All Found")
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(255, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(25, 23)
        Me.Button2.TabIndex = 270
        Me.ToolTip1.SetToolTip(Me.Button2, "Add Selected")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.ListViewFound)
        Me.Panel6.Controls.Add(Me.Panel3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(785, 244)
        Me.Panel6.TabIndex = 266
        '
        'ListViewFound
        '
        Me.ListViewFound.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader11, Me.ColumnHeader13, Me.ColumnHeader15})
        Me.ListViewFound.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewFound.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListViewFound.FullRowSelect = True
        Me.ListViewFound.GridLines = True
        Me.ListViewFound.HideSelection = False
        Me.ListViewFound.LargeImageList = Me.ImageList1
        Me.ListViewFound.Location = New System.Drawing.Point(0, 19)
        Me.ListViewFound.MultiSelect = False
        Me.ListViewFound.Name = "ListViewFound"
        Me.ListViewFound.Size = New System.Drawing.Size(785, 225)
        Me.ListViewFound.SmallImageList = Me.ImageList1
        Me.ListViewFound.TabIndex = 2
        Me.ListViewFound.UseCompatibleStateImageBehavior = False
        Me.ListViewFound.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Patient #"
        Me.ColumnHeader1.Width = 59
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Patient Name"
        Me.ColumnHeader2.Width = 157
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Bill #"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 61
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Amount"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 62
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Claim #"
        Me.ColumnHeader5.Width = 98
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Insurance"
        Me.ColumnHeader11.Width = 147
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Case Type"
        Me.ColumnHeader13.Width = 62
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Office"
        Me.ColumnHeader15.Width = 109
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblSearch)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(785, 19)
        Me.Panel3.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblSearch.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblSearch.ForeColor = System.Drawing.Color.White
        Me.lblSearch.Location = New System.Drawing.Point(0, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(367, 19)
        Me.lblSearch.TabIndex = 112
        Me.lblSearch.Text = "Found: 0"
        Me.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ListViewSelected, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(193, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1085, 513)
        Me.TableLayoutPanel1.TabIndex = 148
        '
        'ListViewSelected
        '
        Me.ListViewSelected.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader12, Me.ColumnHeader14, Me.ColumnHeader16})
        Me.ListViewSelected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewSelected.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListViewSelected.FullRowSelect = True
        Me.ListViewSelected.GridLines = True
        Me.ListViewSelected.HideSelection = False
        Me.ListViewSelected.LargeImageList = Me.ImageList1
        Me.ListViewSelected.Location = New System.Drawing.Point(3, 272)
        Me.ListViewSelected.MultiSelect = False
        Me.ListViewSelected.Name = "ListViewSelected"
        Me.ListViewSelected.Size = New System.Drawing.Size(779, 238)
        Me.ListViewSelected.SmallImageList = Me.ImageList1
        Me.ListViewSelected.TabIndex = 267
        Me.ListViewSelected.UseCompatibleStateImageBehavior = False
        Me.ListViewSelected.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Patient #"
        Me.ColumnHeader6.Width = 64
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Patient Name"
        Me.ColumnHeader7.Width = 161
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Bill #"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader8.Width = 67
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Amount"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader9.Width = 63
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Claim #"
        Me.ColumnHeader10.Width = 95
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Insurance"
        Me.ColumnHeader12.Width = 148
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Case Type"
        Me.ColumnHeader14.Width = 62
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Office"
        Me.ColumnHeader16.Width = 90
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Button5)
        Me.Panel5.Controls.Add(Me.LabelSelected)
        Me.Panel5.Controls.Add(Me.Button4)
        Me.Panel5.Controls.Add(Me.Button2)
        Me.Panel5.Controls.Add(Me.Button3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 244)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(785, 25)
        Me.Panel5.TabIndex = 2
        '
        'LabelSelected
        '
        Me.LabelSelected.BackColor = System.Drawing.Color.Transparent
        Me.LabelSelected.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelSelected.ForeColor = System.Drawing.Color.White
        Me.LabelSelected.Location = New System.Drawing.Point(0, 0)
        Me.LabelSelected.Name = "LabelSelected"
        Me.LabelSelected.Size = New System.Drawing.Size(203, 25)
        Me.LabelSelected.TabIndex = 112
        Me.LabelSelected.Text = "Selected: 0"
        Me.LabelSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.FpSpreadDetails)
        Me.Panel1.Controls.Add(Me.LabelOffice)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(785, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel1, 3)
        Me.Panel1.Size = New System.Drawing.Size(300, 513)
        Me.Panel1.TabIndex = 268
        '
        'FpSpreadDetails
        '
        Me.FpSpreadDetails.AccessibleDescription = "FpSpreadDetails, Sheet1, Row 0, Column 0, Patient #"
        Me.FpSpreadDetails.AllowUserZoom = False
        Me.FpSpreadDetails.BackColor = System.Drawing.Color.White
        Me.FpSpreadDetails.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse
        Me.FpSpreadDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FpSpreadDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FpSpreadDetails.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpreadDetails.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.FpSpreadDetails.Location = New System.Drawing.Point(20, 34)
        Me.FpSpreadDetails.MoveActiveOnFocus = False
        Me.FpSpreadDetails.Name = "FpSpreadDetails"
        NamedStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(233, Byte), Integer))
        NamedStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle5.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(233, Byte), Integer))
        NamedStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle6.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle6.Renderer = EnhancedCornerRenderer2
        NamedStyle6.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle7.BackColor = System.Drawing.SystemColors.Control
        NamedStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle7.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle7.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle7.Renderer = ColumnHeaderRenderer3
        NamedStyle7.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle8.BackColor = System.Drawing.SystemColors.Window
        NamedStyle8.CellType = GeneralCellType2
        NamedStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle8.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle8.Renderer = GeneralCellType2
        Me.FpSpreadDetails.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle5, NamedStyle6, NamedStyle7, NamedStyle8})
        Me.FpSpreadDetails.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpreadDetails.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpreadDetails.ScrollBarMaxAlign = False
        Me.FpSpreadDetails.ScrollBarShowMax = False
        Me.FpSpreadDetails.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None
        Me.FpSpreadDetails.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpreadDetails_Sheet1})
        Me.FpSpreadDetails.Size = New System.Drawing.Size(280, 479)
        SpreadSkin2.ColumnHeaderDefaultStyle = NamedStyle7
        SpreadSkin2.CornerDefaultStyle = NamedStyle7
        SpreadSkin2.DefaultStyle = NamedStyle8
        SpreadSkin2.Name = "CustomSkin1"
        SpreadSkin2.RowHeaderDefaultStyle = NamedStyle7
        SpreadSkin2.ScrollBarRenderer = EnhancedScrollBarRenderer2
        SpreadSkin2.SelectionRenderer = New FarPoint.Win.Spread.DefaultSelectionRenderer()
        Me.FpSpreadDetails.Skin = SpreadSkin2
        Me.FpSpreadDetails.SuspendAnimations = True
        Me.FpSpreadDetails.TabIndex = 4
        Me.FpSpreadDetails.TabStop = False
        Me.FpSpreadDetails.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never
        Me.FpSpreadDetails.TabStripRatio = 0.148798521256932R
        Me.FpSpreadDetails.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        '
        'FpSpreadDetails_Sheet1
        '
        Me.FpSpreadDetails_Sheet1.Reset()
        Me.FpSpreadDetails_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpreadDetails_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpreadDetails_Sheet1.ColumnCount = 2
        Me.FpSpreadDetails_Sheet1.RowCount = 14
        Me.FpSpreadDetails_Sheet1.Cells.Get(0, 0).Value = "Patient #"
        Me.FpSpreadDetails_Sheet1.Cells.Get(1, 0).Value = "DOB"
        Me.FpSpreadDetails_Sheet1.Cells.Get(2, 0).Value = "DOA"
        Me.FpSpreadDetails_Sheet1.Cells.Get(3, 0).Value = "Policy #"
        Me.FpSpreadDetails_Sheet1.Cells.Get(4, 0).Value = "Claim #"
        Me.FpSpreadDetails_Sheet1.Cells.Get(5, 0).Value = "SSN"
        Me.FpSpreadDetails_Sheet1.Cells.Get(6, 0).Value = "Phone 1"
        Me.FpSpreadDetails_Sheet1.Cells.Get(6, 1).Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpreadDetails_Sheet1.Cells.Get(7, 0).Value = "Cell Phone"
        Me.FpSpreadDetails_Sheet1.Cells.Get(7, 1).Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpreadDetails_Sheet1.Cells.Get(8, 0).Value = "Phone 2"
        Me.FpSpreadDetails_Sheet1.Cells.Get(8, 1).Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpreadDetails_Sheet1.Cells.Get(9, 0).Value = "Address"
        Me.FpSpreadDetails_Sheet1.Cells.Get(9, 1).Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpreadDetails_Sheet1.Cells.Get(10, 0).Value = "Blng Provider"
        Me.FpSpreadDetails_Sheet1.Cells.Get(11, 0).Value = "Referred by"
        Me.FpSpreadDetails_Sheet1.Cells.Get(11, 1).Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpreadDetails_Sheet1.Cells.Get(13, 0).Value = "Comments"
        TextCellType4.WordWrap = True
        Me.FpSpreadDetails_Sheet1.Cells.Get(13, 1).CellType = TextCellType4
        Me.FpSpreadDetails_Sheet1.Cells.Get(13, 1).Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpreadDetails_Sheet1.Cells.Get(13, 1).ForeColor = System.Drawing.Color.Black
        Me.FpSpreadDetails_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadDetails_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.FpSpreadDetails_Sheet1.ColumnHeader.Visible = False
        Me.FpSpreadDetails_Sheet1.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.[Auto]
        Me.FpSpreadDetails_Sheet1.Columns.Get(0).CellType = TextCellType5
        Me.FpSpreadDetails_Sheet1.Columns.Get(0).Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpreadDetails_Sheet1.Columns.Get(0).Locked = True
        Me.FpSpreadDetails_Sheet1.Columns.Get(0).Width = 69.0!
        TextCellType6.Multiline = True
        TextCellType6.WordWrap = True
        Me.FpSpreadDetails_Sheet1.Columns.Get(1).CellType = TextCellType6
        Me.FpSpreadDetails_Sheet1.Columns.Get(1).Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpreadDetails_Sheet1.Columns.Get(1).Locked = True
        Me.FpSpreadDetails_Sheet1.Columns.Get(1).Width = 210.0!
        Me.FpSpreadDetails_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadDetails_Sheet1.DefaultStyle.Parent = "DataAreaDefault"
        Me.FpSpreadDetails_Sheet1.FrozenTrailingColumnCount = 2
        Me.FpSpreadDetails_Sheet1.GrayAreaBackColor = System.Drawing.Color.Transparent
        Me.FpSpreadDetails_Sheet1.HorizontalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Lowered, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.FpSpreadDetails_Sheet1.LockBackColor = System.Drawing.Color.Transparent
        Me.FpSpreadDetails_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpreadDetails_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadDetails_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.FpSpreadDetails_Sheet1.RowHeader.HorizontalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Raised, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.SystemColors.ControlDark)
        Me.FpSpreadDetails_Sheet1.RowHeader.Visible = False
        Me.FpSpreadDetails_Sheet1.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.[Auto]
        Me.FpSpreadDetails_Sheet1.SelectionBackColor = System.Drawing.Color.Lavender
        Me.FpSpreadDetails_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.[Single]
        Me.FpSpreadDetails_Sheet1.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.SelectionColors
        Me.FpSpreadDetails_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadDetails_Sheet1.SheetCornerStyle.Parent = "HeaderDefault"
        Me.FpSpreadDetails_Sheet1.VerticalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.FpSpreadDetails_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        Me.FpSpreadDetails.SetActiveViewport(0, 0, 1)
        '
        'LabelOffice
        '
        Me.LabelOffice.BackColor = System.Drawing.Color.White
        Me.LabelOffice.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelOffice.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelOffice.Location = New System.Drawing.Point(20, 19)
        Me.LabelOffice.Name = "LabelOffice"
        Me.LabelOffice.Size = New System.Drawing.Size(280, 15)
        Me.LabelOffice.TabIndex = 6
        Me.LabelOffice.Text = "Office:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(20, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(280, 19)
        Me.Panel4.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(-3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 19)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "Details"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmBillingSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1278, 547)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.PanelSearch)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1294, 586)
        Me.Name = "frmBillingSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search"
        Me.Panel2.ResumeLayout(False)
        Me.PanelSearch.ResumeLayout(False)
        Me.PanelSearch.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.FpSpreadDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpreadDetails_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdShow As Button
    Friend WithEvents PanelSearch As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPatient As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBillNumber As TextBox
    Friend WithEvents DateTimePickerFrom As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents DateTimePickerTo As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Public WithEvents cboInsuranceCompanyID As ComboBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblSearch As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LabelSelected As Label
    Friend WithEvents ListViewFound As ListViewDoubleBuffered
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ListViewSelected As ListViewDoubleBuffered
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ButtonFind As Button
    Friend WithEvents ButtonClear As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cboCaseTypeID As ComboBox
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents CheckBoxNetSearch As CheckBox
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents LabelMsg As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FpSpreadDetails As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpreadDetails_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents LabelOffice As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPolicyNumber As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtClaimNumber As TextBox
    Friend WithEvents cboBillingProvider As ComboBox
    Friend WithEvents Label13 As Label
End Class
