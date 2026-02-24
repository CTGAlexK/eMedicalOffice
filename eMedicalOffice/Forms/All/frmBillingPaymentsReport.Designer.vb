<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillingPaymentsReport
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
        Dim ColumnHeaderRenderer1 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBillingPaymentsReport))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCaseTypeID = New System.Windows.Forms.ComboBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboBillingProvider = New System.Windows.Forms.ComboBox()
        Me.DateTimePickerAttorneyTo = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DateTimePickerAttorneyFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboBillingCompany = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBillNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboInsuranceCompanyID = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboAttorneysCompanyID = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ButtonFind = New System.Windows.Forms.Button()
        Me.ListViewPatients = New System.Windows.Forms.ListView()
        Me.PatientNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PatientName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DOA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CaseType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BillID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BillDT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PolicyNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClaimNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Amt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.STATUS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Insurance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ServiceDT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Attorney = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AttorneyDT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.POM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PaidAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Balance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Doctor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AdjusterName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AttorneyCaseNumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripStatusLabelPaidChecked = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator35 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabelPaidFound = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator34 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabelCheched = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabelTotal = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripStatusLabelChecked = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripStatusLabelFound = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ExportAllToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportCheckedToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrinting2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PrintResultListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintAll1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintCheckedOnly1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FpSpreadForPrint = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpreadForPrint_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.SaveFD = New System.Windows.Forms.SaveFileDialog()
        Me.Panel4.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.FpSpreadForPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpreadForPrint_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ColumnHeaderRenderer1.Name = "ColumnHeaderRenderer1"
        ColumnHeaderRenderer1.TextRotationAngle = 0R
        ColumnHeaderRenderer2.Name = "ColumnHeaderRenderer2"
        ColumnHeaderRenderer2.TextRotationAngle = 0R
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(598, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 110
        Me.Label4.Text = "Case Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(3, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "First / Last /  ##"
        '
        'cboCaseTypeID
        '
        Me.cboCaseTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaseTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCaseTypeID.ForeColor = System.Drawing.Color.Black
        Me.cboCaseTypeID.FormattingEnabled = True
        Me.cboCaseTypeID.Location = New System.Drawing.Point(601, 21)
        Me.cboCaseTypeID.Name = "cboCaseTypeID"
        Me.cboCaseTypeID.Size = New System.Drawing.Size(62, 21)
        Me.cboCaseTypeID.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.cboCaseTypeID, "Case Type")
        '
        'txtSearch
        '
        Me.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtSearch.Location = New System.Drawing.Point(6, 21)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(79, 20)
        Me.txtSearch.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtSearch, "Patient's First Name or Last Name or Number")
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.cboBillingProvider)
        Me.Panel4.Controls.Add(Me.DateTimePickerAttorneyTo)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.DateTimePickerAttorneyFrom)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.DateTimePickerTo)
        Me.Panel4.Controls.Add(Me.DateTimePickerFrom)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.cboBillingCompany)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.txtBillNumber)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.ButtonClear)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.cboInsuranceCompanyID)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.cboAttorneysCompanyID)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.ButtonFind)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.cboCaseTypeID)
        Me.Panel4.Controls.Add(Me.txtSearch)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 25)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1495, 48)
        Me.Panel4.TabIndex = 114
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(230, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 265
        Me.Label1.Text = "Billing Provider"
        '
        'cboBillingProvider
        '
        Me.cboBillingProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBillingProvider.ForeColor = System.Drawing.Color.Black
        Me.cboBillingProvider.FormattingEnabled = True
        Me.cboBillingProvider.Location = New System.Drawing.Point(230, 21)
        Me.cboBillingProvider.Name = "cboBillingProvider"
        Me.cboBillingProvider.Size = New System.Drawing.Size(150, 21)
        Me.cboBillingProvider.TabIndex = 264
        Me.ToolTip1.SetToolTip(Me.cboBillingProvider, "Case Type")
        '
        'DateTimePickerAttorneyTo
        '
        Me.DateTimePickerAttorneyTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePickerAttorneyTo.Checked = False
        Me.DateTimePickerAttorneyTo.CustomFormat = "MM/dd/yyy"
        Me.DateTimePickerAttorneyTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerAttorneyTo.Location = New System.Drawing.Point(1102, 22)
        Me.DateTimePickerAttorneyTo.Name = "DateTimePickerAttorneyTo"
        Me.DateTimePickerAttorneyTo.ShowCheckBox = True
        Me.DateTimePickerAttorneyTo.Size = New System.Drawing.Size(102, 20)
        Me.DateTimePickerAttorneyTo.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(1099, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 13)
        Me.Label11.TabIndex = 263
        Me.Label11.Text = "Attorney To Date"
        '
        'DateTimePickerAttorneyFrom
        '
        Me.DateTimePickerAttorneyFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePickerAttorneyFrom.Checked = False
        Me.DateTimePickerAttorneyFrom.CustomFormat = "MM/dd/yyy"
        Me.DateTimePickerAttorneyFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerAttorneyFrom.Location = New System.Drawing.Point(996, 22)
        Me.DateTimePickerAttorneyFrom.Name = "DateTimePickerAttorneyFrom"
        Me.DateTimePickerAttorneyFrom.ShowCheckBox = True
        Me.DateTimePickerAttorneyFrom.Size = New System.Drawing.Size(99, 20)
        Me.DateTimePickerAttorneyFrom.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(994, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 13)
        Me.Label10.TabIndex = 261
        Me.Label10.Text = "Attorney From Date"
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.CustomFormat = "MM/dd/yyy"
        Me.DateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTo.Location = New System.Drawing.Point(497, 22)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.ShowCheckBox = True
        Me.DateTimePickerTo.Size = New System.Drawing.Size(98, 20)
        Me.DateTimePickerTo.TabIndex = 5
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.CustomFormat = "MM/dd/yyy"
        Me.DateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(389, 22)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.ShowCheckBox = True
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(102, 20)
        Me.DateTimePickerFrom.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(1206, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 13)
        Me.Label9.TabIndex = 258
        Me.Label9.Text = "Billing Company    "
        '
        'cboBillingCompany
        '
        Me.cboBillingCompany.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboBillingCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingCompany.DropDownWidth = 150
        Me.cboBillingCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBillingCompany.ForeColor = System.Drawing.Color.Black
        Me.cboBillingCompany.FormattingEnabled = True
        Me.cboBillingCompany.Location = New System.Drawing.Point(1209, 21)
        Me.cboBillingCompany.Name = "cboBillingCompany"
        Me.cboBillingCompany.Size = New System.Drawing.Size(181, 21)
        Me.cboBillingCompany.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(94, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 13)
        Me.Label5.TabIndex = 254
        Me.Label5.Text = "Bill / Case / Claim / Policy"
        '
        'txtBillNumber
        '
        Me.txtBillNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtBillNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtBillNumber.Location = New System.Drawing.Point(94, 21)
        Me.txtBillNumber.MaxLength = 10
        Me.txtBillNumber.Name = "txtBillNumber"
        Me.txtBillNumber.Size = New System.Drawing.Size(130, 20)
        Me.txtBillNumber.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtBillNumber, "Bill Number")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(494, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 251
        Me.Label3.Text = "Payment To DT"
        '
        'ButtonClear
        '
        Me.ButtonClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClear.Image = CType(resources.GetObject("ButtonClear.Image"), System.Drawing.Image)
        Me.ButtonClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonClear.Location = New System.Drawing.Point(1396, 17)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(27, 25)
        Me.ButtonClear.TabIndex = 12
        Me.ButtonClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButtonClear, "Clear Search Criteria")
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(666, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 249
        Me.Label7.Text = "Ins Company"
        '
        'cboInsuranceCompanyID
        '
        Me.cboInsuranceCompanyID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboInsuranceCompanyID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboInsuranceCompanyID.BackColor = System.Drawing.Color.White
        Me.cboInsuranceCompanyID.DropDownWidth = 300
        Me.cboInsuranceCompanyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInsuranceCompanyID.ForeColor = System.Drawing.Color.Black
        Me.cboInsuranceCompanyID.FormattingEnabled = True
        Me.cboInsuranceCompanyID.Location = New System.Drawing.Point(669, 21)
        Me.cboInsuranceCompanyID.Name = "cboInsuranceCompanyID"
        Me.cboInsuranceCompanyID.Size = New System.Drawing.Size(164, 21)
        Me.cboInsuranceCompanyID.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(836, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 247
        Me.Label18.Text = "Attorney"
        '
        'cboAttorneysCompanyID
        '
        Me.cboAttorneysCompanyID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAttorneysCompanyID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboAttorneysCompanyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttorneysCompanyID.DropDownWidth = 300
        Me.cboAttorneysCompanyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAttorneysCompanyID.ForeColor = System.Drawing.Color.Black
        Me.cboAttorneysCompanyID.FormattingEnabled = True
        Me.cboAttorneysCompanyID.Location = New System.Drawing.Point(839, 21)
        Me.cboAttorneysCompanyID.Name = "cboAttorneysCompanyID"
        Me.cboAttorneysCompanyID.Size = New System.Drawing.Size(151, 21)
        Me.cboAttorneysCompanyID.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(386, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 120
        Me.Label6.Text = "Payment From DT"
        '
        'ButtonFind
        '
        Me.ButtonFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFind.Image = CType(resources.GetObject("ButtonFind.Image"), System.Drawing.Image)
        Me.ButtonFind.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonFind.Location = New System.Drawing.Point(1429, 6)
        Me.ButtonFind.Name = "ButtonFind"
        Me.ButtonFind.Size = New System.Drawing.Size(61, 38)
        Me.ButtonFind.TabIndex = 13
        Me.ButtonFind.Text = "Find   "
        Me.ToolTip1.SetToolTip(Me.ButtonFind, "Find Records")
        Me.ButtonFind.UseVisualStyleBackColor = True
        '
        'ListViewPatients
        '
        Me.ListViewPatients.AllowColumnReorder = True
        Me.ListViewPatients.CheckBoxes = True
        Me.ListViewPatients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PatientNo, Me.PatientName, Me.DOA, Me.CaseType, Me.BillID, Me.BillDT, Me.PolicyNo, Me.ClaimNo, Me.Amt, Me.STATUS, Me.Insurance, Me.ServiceDT, Me.Attorney, Me.AttorneyDT, Me.POM, Me.PaidAmount, Me.Balance, Me.Doctor, Me.AdjusterName, Me.AttorneyCaseNumber, Me.ColumnHeader1})
        Me.ListViewPatients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewPatients.FullRowSelect = True
        Me.ListViewPatients.GridLines = True
        Me.ListViewPatients.HideSelection = False
        Me.ListViewPatients.LabelWrap = False
        Me.ListViewPatients.LargeImageList = Me.ImageList1
        Me.ListViewPatients.Location = New System.Drawing.Point(0, 73)
        Me.ListViewPatients.Margin = New System.Windows.Forms.Padding(0)
        Me.ListViewPatients.MultiSelect = False
        Me.ListViewPatients.Name = "ListViewPatients"
        Me.ListViewPatients.ShowGroups = False
        Me.ListViewPatients.ShowItemToolTips = True
        Me.ListViewPatients.Size = New System.Drawing.Size(1495, 514)
        Me.ListViewPatients.SmallImageList = Me.ImageList1
        Me.ListViewPatients.TabIndex = 0
        Me.ListViewPatients.UseCompatibleStateImageBehavior = False
        Me.ListViewPatients.View = System.Windows.Forms.View.Details
        '
        'PatientNo
        '
        Me.PatientNo.Text = "Patient #"
        Me.PatientNo.Width = 93
        '
        'PatientName
        '
        Me.PatientName.Text = "Name"
        Me.PatientName.Width = 166
        '
        'DOA
        '
        Me.DOA.Text = "DOA"
        Me.DOA.Width = 181
        '
        'CaseType
        '
        Me.CaseType.Text = "Type"
        '
        'BillID
        '
        Me.BillID.Text = "Bill #"
        '
        'BillDT
        '
        Me.BillDT.Text = "Bill DT"
        Me.BillDT.Width = 159
        '
        'PolicyNo
        '
        Me.PolicyNo.Text = "Policy #"
        '
        'ClaimNo
        '
        Me.ClaimNo.Text = "Claim #"
        '
        'Amt
        '
        Me.Amt.Text = "Amt $"
        Me.Amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'STATUS
        '
        Me.STATUS.Text = "Status"
        '
        'Insurance
        '
        Me.Insurance.Text = "Insurance"
        '
        'ServiceDT
        '
        Me.ServiceDT.Text = "Service DT"
        '
        'Attorney
        '
        Me.Attorney.Text = "Attorney"
        '
        'AttorneyDT
        '
        Me.AttorneyDT.Text = "Attorney DT"
        '
        'POM
        '
        Me.POM.Text = "POM"
        '
        'PaidAmount
        '
        Me.PaidAmount.Text = "Paid Amt $"
        Me.PaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Balance
        '
        Me.Balance.Text = "Balance $"
        Me.Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Doctor
        '
        Me.Doctor.Text = "Doctor"
        '
        'AdjusterName
        '
        Me.AdjusterName.Text = "Adjuster Name"
        '
        'AttorneyCaseNumber
        '
        Me.AttorneyCaseNumber.Text = "Attorney Case #"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Requests"
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
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "3")
        Me.ImageList2.Images.SetKeyName(1, "4")
        Me.ImageList2.Images.SetKeyName(2, "5")
        Me.ImageList2.Images.SetKeyName(3, "6")
        Me.ImageList2.Images.SetKeyName(4, "7")
        Me.ImageList2.Images.SetKeyName(5, "31")
        Me.ImageList2.Images.SetKeyName(6, "41")
        Me.ImageList2.Images.SetKeyName(7, "51")
        Me.ImageList2.Images.SetKeyName(8, "61")
        Me.ImageList2.Images.SetKeyName(9, "71")
        Me.ImageList2.Images.SetKeyName(10, "8")
        Me.ImageList2.Images.SetKeyName(11, "81")
        Me.ImageList2.Images.SetKeyName(12, "2")
        Me.ImageList2.Images.SetKeyName(13, "21")
        Me.ImageList2.Images.SetKeyName(14, "1")
        Me.ImageList2.Images.SetKeyName(15, "11")
        Me.ImageList2.Images.SetKeyName(16, "PROC")
        Me.ImageList2.Images.SetKeyName(17, "DIAG")
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripStatusLabelPaidChecked, Me.ToolStripSeparator35, Me.ToolStripLabelPaidFound, Me.ToolStripSeparator34, Me.ToolStripLabelCheched, Me.ToolStripSeparator25, Me.ToolStripLabelTotal, Me.ToolStripSeparator7, Me.ToolStripStatusLabelChecked, Me.ToolStripSeparator24, Me.ToolStripStatusLabelFound, Me.ToolStripSeparator8, Me.ToolStripButton3, Me.ToolStripSeparator26, Me.mnuPrinting2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1495, 25)
        Me.ToolStrip2.TabIndex = 1
        Me.ToolStrip2.Text = "Paid Checked"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.ToolStripButton1.Size = New System.Drawing.Size(28, 22)
        Me.ToolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton1.ToolTipText = "Autosize Spread Columns Width"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripStatusLabelPaidChecked
        '
        Me.ToolStripStatusLabelPaidChecked.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripStatusLabelPaidChecked.Name = "ToolStripStatusLabelPaidChecked"
        Me.ToolStripStatusLabelPaidChecked.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripStatusLabelPaidChecked.Text = "Paid Checked"
        '
        'ToolStripSeparator35
        '
        Me.ToolStripSeparator35.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator35.Name = "ToolStripSeparator35"
        Me.ToolStripSeparator35.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabelPaidFound
        '
        Me.ToolStripLabelPaidFound.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabelPaidFound.Name = "ToolStripLabelPaidFound"
        Me.ToolStripLabelPaidFound.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripLabelPaidFound.Text = "Paid Checked"
        '
        'ToolStripSeparator34
        '
        Me.ToolStripSeparator34.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator34.Name = "ToolStripSeparator34"
        Me.ToolStripSeparator34.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabelCheched
        '
        Me.ToolStripLabelCheched.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabelCheched.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripLabelCheched.Name = "ToolStripLabelCheched"
        Me.ToolStripLabelCheched.Size = New System.Drawing.Size(89, 22)
        Me.ToolStripLabelCheched.Text = "ToolStripLabel3"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabelTotal
        '
        Me.ToolStripLabelTotal.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabelTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripLabelTotal.Name = "ToolStripLabelTotal"
        Me.ToolStripLabelTotal.Size = New System.Drawing.Size(89, 22)
        Me.ToolStripLabelTotal.Text = "ToolStripLabel3"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator7.AutoSize = False
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripStatusLabelChecked
        '
        Me.ToolStripStatusLabelChecked.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripStatusLabelChecked.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripStatusLabelChecked.Name = "ToolStripStatusLabelChecked"
        Me.ToolStripStatusLabelChecked.Size = New System.Drawing.Size(89, 22)
        Me.ToolStripStatusLabelChecked.Text = "ToolStripLabel3"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripStatusLabelFound
        '
        Me.ToolStripStatusLabelFound.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripStatusLabelFound.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripStatusLabelFound.Name = "ToolStripStatusLabelFound"
        Me.ToolStripStatusLabelFound.Size = New System.Drawing.Size(89, 22)
        Me.ToolStripStatusLabelFound.Text = "ToolStripLabel2"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportAllToExcelToolStripMenuItem, Me.ExportCheckedToExcelToolStripMenuItem})
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton3.Text = "Excel"
        '
        'ExportAllToExcelToolStripMenuItem
        '
        Me.ExportAllToExcelToolStripMenuItem.Name = "ExportAllToExcelToolStripMenuItem"
        Me.ExportAllToExcelToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.ExportAllToExcelToolStripMenuItem.Text = "Export All To Excel"
        '
        'ExportCheckedToExcelToolStripMenuItem
        '
        Me.ExportCheckedToExcelToolStripMenuItem.Name = "ExportCheckedToExcelToolStripMenuItem"
        Me.ExportCheckedToExcelToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.ExportCheckedToExcelToolStripMenuItem.Text = "Export Checked To Excel"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(6, 25)
        '
        'mnuPrinting2
        '
        Me.mnuPrinting2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintResultListToolStripMenuItem})
        Me.mnuPrinting2.Image = CType(resources.GetObject("mnuPrinting2.Image"), System.Drawing.Image)
        Me.mnuPrinting2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuPrinting2.Name = "mnuPrinting2"
        Me.mnuPrinting2.Size = New System.Drawing.Size(78, 22)
        Me.mnuPrinting2.Text = "Printing"
        Me.mnuPrinting2.ToolTipText = "Printing Tools"
        '
        'PrintResultListToolStripMenuItem
        '
        Me.PrintResultListToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrintAll1, Me.mnuPrintCheckedOnly1})
        Me.PrintResultListToolStripMenuItem.ForeColor = System.Drawing.Color.Navy
        Me.PrintResultListToolStripMenuItem.Image = CType(resources.GetObject("PrintResultListToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintResultListToolStripMenuItem.Name = "PrintResultListToolStripMenuItem"
        Me.PrintResultListToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.PrintResultListToolStripMenuItem.Text = "Print Result List"
        '
        'mnuPrintAll1
        '
        Me.mnuPrintAll1.Image = CType(resources.GetObject("mnuPrintAll1.Image"), System.Drawing.Image)
        Me.mnuPrintAll1.Name = "mnuPrintAll1"
        Me.mnuPrintAll1.Size = New System.Drawing.Size(176, 22)
        Me.mnuPrintAll1.Text = "Print All"
        '
        'mnuPrintCheckedOnly1
        '
        Me.mnuPrintCheckedOnly1.Image = CType(resources.GetObject("mnuPrintCheckedOnly1.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedOnly1.Name = "mnuPrintCheckedOnly1"
        Me.mnuPrintCheckedOnly1.Size = New System.Drawing.Size(176, 22)
        Me.mnuPrintCheckedOnly1.Text = "Print Checked Only"
        '
        'FpSpreadForPrint
        '
        Me.FpSpreadForPrint.AccessibleDescription = "FpSpreadForPrint, Sheet1, Row 0, Column 0, "
        Me.FpSpreadForPrint.AllowCellOverflow = True
        Me.FpSpreadForPrint.AllowColumnMove = True
        Me.FpSpreadForPrint.AllowDragDrop = True
        Me.FpSpreadForPrint.AllowDragFill = True
        Me.FpSpreadForPrint.AllowDrop = True
        Me.FpSpreadForPrint.AllowEditOverflow = True
        Me.FpSpreadForPrint.AllowRowMove = True
        Me.FpSpreadForPrint.AllowSheetMove = True
        Me.FpSpreadForPrint.AllowUserFormulas = True
        Me.FpSpreadForPrint.BackColor = System.Drawing.SystemColors.Control
        Me.FpSpreadForPrint.Location = New System.Drawing.Point(26, 286)
        Me.FpSpreadForPrint.Name = "FpSpreadForPrint"
        Me.FpSpreadForPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpreadForPrint.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpreadForPrint_Sheet1})
        Me.FpSpreadForPrint.Size = New System.Drawing.Size(161, 151)
        Me.FpSpreadForPrint.TabIndex = 119
        Me.FpSpreadForPrint.Visible = False
        '
        'FpSpreadForPrint_Sheet1
        '
        Me.FpSpreadForPrint_Sheet1.Reset()
        Me.FpSpreadForPrint_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpreadForPrint_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpreadForPrint_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpreadForPrint_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'frmBillingPaymentsReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1495, 587)
        Me.Controls.Add(Me.FpSpreadForPrint)
        Me.Controls.Add(Me.ListViewPatients)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.ToolStrip2)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(970, 620)
        Me.Name = "frmBillingPaymentsReport"
        Me.Text = "Payments Management"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.FpSpreadForPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpreadForPrint_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCaseTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents ButtonFind As System.Windows.Forms.Button
    Friend WithEvents ListViewPatients As System.Windows.Forms.ListView
    Friend WithEvents PatientName As System.Windows.Forms.ColumnHeader
    Friend WithEvents DOA As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboAttorneysCompanyID As System.Windows.Forms.ComboBox
    Friend WithEvents BillDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PolicyNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClaimNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Amt As System.Windows.Forms.ColumnHeader
    Friend WithEvents STATUS As System.Windows.Forms.ColumnHeader
    Friend WithEvents Insurance As System.Windows.Forms.ColumnHeader
    Friend WithEvents Attorney As System.Windows.Forms.ColumnHeader
    Friend WithEvents AttorneyDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents BillID As System.Windows.Forms.ColumnHeader
    Friend WithEvents PatientNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ServiceDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents CaseType As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Public WithEvents cboInsuranceCompanyID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBillNumber As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripStatusLabelFound As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripStatusLabelChecked As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents POM As System.Windows.Forms.ColumnHeader
    Friend WithEvents PaidAmount As System.Windows.Forms.ColumnHeader
    Friend WithEvents Balance As System.Windows.Forms.ColumnHeader
    Friend WithEvents Doctor As System.Windows.Forms.ColumnHeader
    Friend WithEvents FpSpreadForPrint As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpreadForPrint_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents AdjusterName As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboBillingCompany As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePickerTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStripLabelTotal As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabelCheched As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportAllToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportCheckedToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents AttorneyCaseNumber As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuPrinting2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents PrintResultListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintAll1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintCheckedOnly1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateTimePickerAttorneyTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerAttorneyFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabelPaidChecked As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator35 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabelPaidFound As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator34 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboBillingProvider As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
