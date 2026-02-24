<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPaymentsReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaymentsReport))
        Dim TextCellType15 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType16 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim NumberCellType3 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim TextCellType17 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType18 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType19 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType20 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType21 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim CurrencyCellType3 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboInsuranceCompanyID = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBillNumber = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimeCheckTo = New System.Windows.Forms.DateTimePicker()
        Me.DateTimeCheckFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.ButtonFind = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LabelCount = New System.Windows.Forms.Label()
        Me.FpSpreadForPrint = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpreadForPrint_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.SaveFD = New System.Windows.Forms.SaveFileDialog()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TimerSearch = New System.Windows.Forms.Timer(Me.components)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ComboBoxUsers = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.FpSpreadForPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpreadForPrint_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(1163, 36)
        Me.Panel1.TabIndex = 197
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1120, 0)
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
        Me.Label1.Size = New System.Drawing.Size(161, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Payments Received Report"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.btnPrint)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 532)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1163, 34)
        Me.Panel2.TabIndex = 199
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(174, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(81, 24)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Excel"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(87, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 24)
        Me.Button1.TabIndex = 1
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
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(1081, 5)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 24)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.BackColor = System.Drawing.Color.Transparent
        Me.Label87.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.ForeColor = System.Drawing.Color.Black
        Me.Label87.Location = New System.Drawing.Point(3, 3)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(53, 13)
        Me.Label87.TabIndex = 201
        Me.Label87.Text = "Payments"
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
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.ComboBoxUsers)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.cboInsuranceCompanyID)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtBillNumber)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.DateTimeCheckTo)
        Me.Panel3.Controls.Add(Me.DateTimeCheckFrom)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.DateTimePickerTo)
        Me.Panel3.Controls.Add(Me.DateTimePickerFrom)
        Me.Panel3.Controls.Add(Me.ButtonClear)
        Me.Panel3.Controls.Add(Me.ButtonFind)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtSearch)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1163, 49)
        Me.Panel3.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(819, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 279
        Me.Label7.Text = "Insurance"
        '
        'cboInsuranceCompanyID
        '
        Me.cboInsuranceCompanyID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboInsuranceCompanyID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboInsuranceCompanyID.BackColor = System.Drawing.Color.White
        Me.cboInsuranceCompanyID.DropDownWidth = 300
        Me.cboInsuranceCompanyID.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboInsuranceCompanyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInsuranceCompanyID.ForeColor = System.Drawing.Color.Black
        Me.cboInsuranceCompanyID.FormattingEnabled = True
        Me.cboInsuranceCompanyID.Location = New System.Drawing.Point(822, 24)
        Me.cboInsuranceCompanyID.MaxDropDownItems = 40
        Me.cboInsuranceCompanyID.Name = "cboInsuranceCompanyID"
        Me.cboInsuranceCompanyID.Size = New System.Drawing.Size(231, 21)
        Me.cboInsuranceCompanyID.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(127, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 277
        Me.Label5.Text = "Bill Number"
        '
        'txtBillNumber
        '
        Me.txtBillNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtBillNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtBillNumber.Location = New System.Drawing.Point(130, 24)
        Me.txtBillNumber.MaxLength = 10
        Me.txtBillNumber.Name = "txtBillNumber"
        Me.txtBillNumber.Size = New System.Drawing.Size(114, 20)
        Me.txtBillNumber.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label8.ForeColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(559, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 275
        Me.Label8.Text = "Check Date To"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label9.ForeColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(455, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 274
        Me.Label9.Text = "Check Date From"
        '
        'DateTimeCheckTo
        '
        Me.DateTimeCheckTo.Checked = False
        Me.DateTimeCheckTo.CustomFormat = "MM/dd/yyyy"
        Me.DateTimeCheckTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeCheckTo.Location = New System.Drawing.Point(562, 25)
        Me.DateTimeCheckTo.Name = "DateTimeCheckTo"
        Me.DateTimeCheckTo.ShowCheckBox = True
        Me.DateTimeCheckTo.Size = New System.Drawing.Size(98, 20)
        Me.DateTimeCheckTo.TabIndex = 5
        '
        'DateTimeCheckFrom
        '
        Me.DateTimeCheckFrom.Checked = False
        Me.DateTimeCheckFrom.CustomFormat = "MM/dd/yyyy"
        Me.DateTimeCheckFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeCheckFrom.Location = New System.Drawing.Point(458, 24)
        Me.DateTimeCheckFrom.Name = "DateTimeCheckFrom"
        Me.DateTimeCheckFrom.ShowCheckBox = True
        Me.DateTimeCheckFrom.Size = New System.Drawing.Size(98, 20)
        Me.DateTimeCheckFrom.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(351, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 267
        Me.Label4.Text = "Posted Date To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(247, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 266
        Me.Label3.Text = "Posted Date From"
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTo.Location = New System.Drawing.Point(354, 24)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.ShowCheckBox = True
        Me.DateTimePickerTo.Size = New System.Drawing.Size(98, 20)
        Me.DateTimePickerTo.TabIndex = 3
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(250, 23)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.ShowCheckBox = True
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(98, 20)
        Me.DateTimePickerFrom.TabIndex = 2
        '
        'ButtonClear
        '
        Me.ButtonClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClear.Image = CType(resources.GetObject("ButtonClear.Image"), System.Drawing.Image)
        Me.ButtonClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonClear.Location = New System.Drawing.Point(1059, 19)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(25, 25)
        Me.ButtonClear.TabIndex = 7
        Me.ButtonClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'ButtonFind
        '
        Me.ButtonFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFind.Image = CType(resources.GetObject("ButtonFind.Image"), System.Drawing.Image)
        Me.ButtonFind.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonFind.Location = New System.Drawing.Point(1090, 6)
        Me.ButtonFind.Name = "ButtonFind"
        Me.ButtonFind.Size = New System.Drawing.Size(61, 38)
        Me.ButtonFind.TabIndex = 8
        Me.ButtonFind.Text = "Find   "
        Me.ButtonFind.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(3, 6)
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
        Me.txtSearch.TabIndex = 0
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
        Me.LabelCount.Location = New System.Drawing.Point(517, 3)
        Me.LabelCount.Name = "LabelCount"
        Me.LabelCount.Size = New System.Drawing.Size(621, 15)
        Me.LabelCount.TabIndex = 204
        Me.LabelCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.FpSpreadForPrint.Location = New System.Drawing.Point(840, 154)
        Me.FpSpreadForPrint.Name = "FpSpreadForPrint"
        Me.FpSpreadForPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpreadForPrint.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpreadForPrint_Sheet1})
        Me.FpSpreadForPrint.Size = New System.Drawing.Size(200, 118)
        Me.FpSpreadForPrint.TabIndex = 205
        Me.FpSpreadForPrint.Visible = False
        '
        'FpSpreadForPrint_Sheet1
        '
        Me.FpSpreadForPrint_Sheet1.Reset()
        Me.FpSpreadForPrint_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpreadForPrint_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpreadForPrint_Sheet1.ColumnCount = 9
        Me.FpSpreadForPrint_Sheet1.RowCount = 1
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Patient #"
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Patient Name"
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Bill #"
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Bill Date"
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Insurance"
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Posted Date"
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Check Date"
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Check Number"
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Amount"
        TextCellType15.MaxLength = 500
        Me.FpSpreadForPrint_Sheet1.Columns.Get(0).CellType = TextCellType15
        Me.FpSpreadForPrint_Sheet1.Columns.Get(0).Label = "Patient #"
        Me.FpSpreadForPrint_Sheet1.Columns.Get(0).Width = 123.0!
        TextCellType16.MaxLength = 500
        Me.FpSpreadForPrint_Sheet1.Columns.Get(1).CellType = TextCellType16
        Me.FpSpreadForPrint_Sheet1.Columns.Get(1).Label = "Patient Name"
        Me.FpSpreadForPrint_Sheet1.Columns.Get(1).Width = 123.0!
        NumberCellType3.DecimalPlaces = 0
        NumberCellType3.MaximumValue = 10000000.0R
        NumberCellType3.MinimumValue = -10000000.0R
        Me.FpSpreadForPrint_Sheet1.Columns.Get(2).CellType = NumberCellType3
        Me.FpSpreadForPrint_Sheet1.Columns.Get(2).Label = "Bill #"
        Me.FpSpreadForPrint_Sheet1.Columns.Get(2).Width = 123.0!
        TextCellType17.MaxLength = 500
        Me.FpSpreadForPrint_Sheet1.Columns.Get(3).CellType = TextCellType17
        Me.FpSpreadForPrint_Sheet1.Columns.Get(3).Label = "Bill Date"
        Me.FpSpreadForPrint_Sheet1.Columns.Get(3).Width = 123.0!
        TextCellType18.MaxLength = 500
        Me.FpSpreadForPrint_Sheet1.Columns.Get(4).CellType = TextCellType18
        Me.FpSpreadForPrint_Sheet1.Columns.Get(4).Label = "Insurance"
        Me.FpSpreadForPrint_Sheet1.Columns.Get(4).Width = 123.0!
        TextCellType19.MaxLength = 500
        Me.FpSpreadForPrint_Sheet1.Columns.Get(5).CellType = TextCellType19
        Me.FpSpreadForPrint_Sheet1.Columns.Get(5).Label = "Posted Date"
        Me.FpSpreadForPrint_Sheet1.Columns.Get(5).Width = 123.0!
        TextCellType20.MaxLength = 500
        Me.FpSpreadForPrint_Sheet1.Columns.Get(6).CellType = TextCellType20
        Me.FpSpreadForPrint_Sheet1.Columns.Get(6).Label = "Check Date"
        Me.FpSpreadForPrint_Sheet1.Columns.Get(6).Width = 123.0!
        TextCellType21.MaxLength = 500
        Me.FpSpreadForPrint_Sheet1.Columns.Get(7).CellType = TextCellType21
        Me.FpSpreadForPrint_Sheet1.Columns.Get(7).Label = "Check Number"
        Me.FpSpreadForPrint_Sheet1.Columns.Get(7).Width = 123.0!
        Me.FpSpreadForPrint_Sheet1.Columns.Get(8).CellType = CurrencyCellType3
        Me.FpSpreadForPrint_Sheet1.Columns.Get(8).Label = "Amount"
        Me.FpSpreadForPrint_Sheet1.Columns.Get(8).Width = 123.0!
        Me.FpSpreadForPrint_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpreadForPrint_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(1144, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 206
        Me.PictureBox2.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Controls.Add(Me.Label87)
        Me.Panel4.Controls.Add(Me.LabelCount)
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 85)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1163, 21)
        Me.Panel4.TabIndex = 207
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader1})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.ListView1.Location = New System.Drawing.Point(0, 106)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1163, 426)
        Me.ListView1.SmallImageList = Me.ImageList2
        Me.ListView1.TabIndex = 209
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Patient #"
        Me.ColumnHeader2.Width = 88
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Patient Name"
        Me.ColumnHeader3.Width = 85
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Bill #"
        Me.ColumnHeader12.Width = 62
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Bill Date"
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Insurance Company"
        Me.ColumnHeader14.Width = 115
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Posted Date"
        Me.ColumnHeader15.Width = 99
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Check Date"
        Me.ColumnHeader16.Width = 92
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Check #"
        Me.ColumnHeader17.Width = 100
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Amount"
        Me.ColumnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader18.Width = 86
        '
        'TimerSearch
        '
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "User"
        '
        'ComboBoxUsers
        '
        Me.ComboBoxUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxUsers.BackColor = System.Drawing.Color.White
        Me.ComboBoxUsers.DropDownWidth = 300
        Me.ComboBoxUsers.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBoxUsers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxUsers.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxUsers.FormattingEnabled = True
        Me.ComboBoxUsers.Location = New System.Drawing.Point(666, 24)
        Me.ComboBoxUsers.MaxDropDownItems = 40
        Me.ComboBoxUsers.Name = "ComboBoxUsers"
        Me.ComboBoxUsers.Size = New System.Drawing.Size(150, 21)
        Me.ComboBoxUsers.TabIndex = 280
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(663, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 281
        Me.Label6.Text = "User"
        '
        'frmPaymentsReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(1163, 566)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FpSpreadForPrint)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1179, 605)
        Me.Name = "frmPaymentsReport"
        Me.Opacity = 0R
        Me.Text = "Billing Report"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.FpSpreadForPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpreadForPrint_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents ButtonFind As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LabelCount As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DateTimeCheckTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimeCheckFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label5 As Label
    Public WithEvents cboInsuranceCompanyID As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents FpSpreadForPrint As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpreadForPrint_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents SaveFD As SaveFileDialog
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Public WithEvents txtBillNumber As TextBox
    Friend WithEvents TimerSearch As Timer
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents Label6 As Label
    Public WithEvents ComboBoxUsers As ComboBox
End Class
