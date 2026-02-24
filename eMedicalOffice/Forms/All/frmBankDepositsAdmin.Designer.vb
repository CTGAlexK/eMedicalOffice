<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBankDepositsAdmin
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
        Dim EnhancedColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer2 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBankDepositsAdmin))
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("ColumnHeaderEnhanced")
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderEnhanced")
        Dim NamedStyle3 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer1 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle4 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType1 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin1 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim EnhancedFocusIndicatorRenderer1 As FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer = New FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer()
        Dim EnhancedInterfaceRenderer1 As FarPoint.Win.Spread.EnhancedInterfaceRenderer = New FarPoint.Win.Spread.EnhancedInterfaceRenderer()
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType2 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType3 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType4 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.FpSpreadDeposits = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpreadDeposits_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportAllToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblFrom = New System.Windows.Forms.ToolStripLabel()
        Me.lblTo = New System.Windows.Forms.ToolStripLabel()
        Me.lblTotalAmount = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator35 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblTotalAmountLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator34 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblCheckFound = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblCheckFoundLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblDepositsaFound = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblDepositsaFoundLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.FpSpreadDeposits, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpreadDeposits_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        EnhancedColumnHeaderRenderer2.Name = "EnhancedColumnHeaderRenderer2"
        EnhancedColumnHeaderRenderer2.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer2.Name = "EnhancedRowHeaderRenderer2"
        EnhancedRowHeaderRenderer2.TextRotationAngle = 0R
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 36)
        Me.Panel1.TabIndex = 203
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.CustomFormat = "MM/dd/yyyy dddd "
        Me.DateTimePicker2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(551, 7)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.ShowCheckBox = True
        Me.DateTimePicker2.Size = New System.Drawing.Size(204, 22)
        Me.DateTimePicker2.TabIndex = 3
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.CustomFormat = "MM/dd/yyyy dddd "
        Me.DateTimePicker1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(341, 7)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowCheckBox = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(204, 22)
        Me.DateTimePicker1.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(941, 0)
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
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bank Deposits"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 528)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 34)
        Me.Panel2.TabIndex = 204
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(-279, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Print"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Location = New System.Drawing.Point(906, 8)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'FpSpreadDeposits
        '
        Me.FpSpreadDeposits.AccessibleDescription = "FpSpreadDeposits, Sheet1, Row 0, Column 0, "
        Me.FpSpreadDeposits.AutoClipboard = False
        Me.FpSpreadDeposits.BackColor = System.Drawing.Color.White
        Me.FpSpreadDeposits.ClipboardOptions = FarPoint.Win.Spread.ClipboardOptions.NoHeaders
        Me.FpSpreadDeposits.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpreadDeposits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FpSpreadDeposits.EditModeReplace = True
        Me.FpSpreadDeposits.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FpSpreadDeposits.Location = New System.Drawing.Point(0, 61)
        Me.FpSpreadDeposits.Name = "FpSpreadDeposits"
        NamedStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(233, Byte), Integer))
        NamedStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle1.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle1.Renderer = EnhancedColumnHeaderRenderer2
        NamedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(247, Byte), Integer))
        NamedStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle2.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle2.Renderer = EnhancedRowHeaderRenderer2
        NamedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(233, Byte), Integer))
        NamedStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle3.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle3.Renderer = EnhancedCornerRenderer1
        NamedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle4.BackColor = System.Drawing.SystemColors.Window
        NamedStyle4.CellType = GeneralCellType1
        NamedStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle4.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle4.Renderer = GeneralCellType1
        Me.FpSpreadDeposits.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1, NamedStyle2, NamedStyle3, NamedStyle4})
        Me.FpSpreadDeposits.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpreadDeposits.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpreadDeposits.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical
        Me.FpSpreadDeposits.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows
        Me.FpSpreadDeposits.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpreadDeposits_Sheet1})
        Me.FpSpreadDeposits.Size = New System.Drawing.Size(984, 467)
        SpreadSkin1.ColumnHeaderDefaultStyle = NamedStyle1
        SpreadSkin1.CornerDefaultStyle = NamedStyle3
        SpreadSkin1.DefaultStyle = NamedStyle4
        SpreadSkin1.FocusRenderer = EnhancedFocusIndicatorRenderer1
        EnhancedInterfaceRenderer1.GrayAreaColor = System.Drawing.Color.White
        EnhancedInterfaceRenderer1.ScrollBoxBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(221, Byte), Integer))
        EnhancedInterfaceRenderer1.SheetTabLowerActiveColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(244, Byte), Integer))
        EnhancedInterfaceRenderer1.SheetTabLowerNormalColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(249, Byte), Integer))
        EnhancedInterfaceRenderer1.SheetTabUpperActiveColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(244, Byte), Integer))
        EnhancedInterfaceRenderer1.SheetTabUpperNormalColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(249, Byte), Integer))
        EnhancedInterfaceRenderer1.TabStripBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(221, Byte), Integer))
        SpreadSkin1.InterfaceRenderer = EnhancedInterfaceRenderer1
        SpreadSkin1.Name = "CustomSkin1"
        SpreadSkin1.RowHeaderDefaultStyle = NamedStyle2
        SpreadSkin1.ScrollBarRenderer = EnhancedScrollBarRenderer1
        SpreadSkin1.SelectionRenderer = New FarPoint.Win.Spread.DefaultSelectionRenderer()
        Me.FpSpreadDeposits.Skin = SpreadSkin1
        Me.FpSpreadDeposits.TabIndex = 205
        Me.FpSpreadDeposits.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating
        Me.FpSpreadDeposits.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'FpSpreadDeposits_Sheet1
        '
        Me.FpSpreadDeposits_Sheet1.Reset()
        Me.FpSpreadDeposits_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpreadDeposits_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpreadDeposits_Sheet1.ColumnCount = 4
        Me.FpSpreadDeposits_Sheet1.RowCount = 1
        Me.FpSpreadDeposits_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        Me.FpSpreadDeposits_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        Me.FpSpreadDeposits_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.FpSpreadDeposits_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "##"
        Me.FpSpreadDeposits_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Deposit DT"
        Me.FpSpreadDeposits_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Checks #"
        Me.FpSpreadDeposits_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Amount"
        Me.FpSpreadDeposits_Sheet1.Columns.Get(0).CellType = TextCellType1
        Me.FpSpreadDeposits_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.FpSpreadDeposits_Sheet1.Columns.Get(0).Label = "##"
        Me.FpSpreadDeposits_Sheet1.Columns.Get(0).Locked = True
        Me.FpSpreadDeposits_Sheet1.Columns.Get(0).Width = 54.0!
        Me.FpSpreadDeposits_Sheet1.Columns.Get(1).CellType = TextCellType2
        Me.FpSpreadDeposits_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.FpSpreadDeposits_Sheet1.Columns.Get(1).Label = "Deposit DT"
        Me.FpSpreadDeposits_Sheet1.Columns.Get(1).Locked = True
        Me.FpSpreadDeposits_Sheet1.Columns.Get(1).Width = 186.0!
        Me.FpSpreadDeposits_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.Transparent
        Me.FpSpreadDeposits_Sheet1.Columns.Get(2).CellType = TextCellType3
        Me.FpSpreadDeposits_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.FpSpreadDeposits_Sheet1.Columns.Get(2).Label = "Checks #"
        Me.FpSpreadDeposits_Sheet1.Columns.Get(2).Locked = True
        Me.FpSpreadDeposits_Sheet1.Columns.Get(2).Width = 98.0!
        Me.FpSpreadDeposits_Sheet1.Columns.Get(3).CellType = TextCellType4
        Me.FpSpreadDeposits_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.FpSpreadDeposits_Sheet1.Columns.Get(3).Label = "Amount"
        Me.FpSpreadDeposits_Sheet1.Columns.Get(3).Locked = True
        Me.FpSpreadDeposits_Sheet1.Columns.Get(3).Width = 130.0!
        Me.FpSpreadDeposits_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
        Me.FpSpreadDeposits_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode
        Me.FpSpreadDeposits_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpreadDeposits_Sheet1.RowHeader.Visible = False
        Me.FpSpreadDeposits_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.[Single]
        Me.FpSpreadDeposits_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row
        Me.FpSpreadDeposits_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripSeparator26, Me.lblFrom, Me.lblTo, Me.lblTotalAmount, Me.ToolStripSeparator35, Me.lblTotalAmountLabel, Me.ToolStripSeparator34, Me.lblCheckFound, Me.ToolStripSeparator25, Me.lblCheckFoundLabel, Me.ToolStripSeparator7, Me.lblDepositsaFound, Me.ToolStripSeparator24, Me.lblDepositsaFoundLabel, Me.ToolStripSeparator8, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 36)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(984, 25)
        Me.ToolStrip1.TabIndex = 282
        Me.ToolStrip1.Text = "Paid Checked"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.AutoSize = False
        Me.ToolStripButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem, Me.ToolStripSeparator2, Me.ExportAllToExcelToolStripMenuItem})
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripButton3.Text = "Tools"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(150, 6)
        '
        'ExportAllToExcelToolStripMenuItem
        '
        Me.ExportAllToExcelToolStripMenuItem.Image = CType(resources.GetObject("ExportAllToExcelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportAllToExcelToolStripMenuItem.Name = "ExportAllToExcelToolStripMenuItem"
        Me.ExportAllToExcelToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ExportAllToExcelToolStripMenuItem.Text = "Export To Excel"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(6, 25)
        '
        'lblFrom
        '
        Me.lblFrom.Margin = New System.Windows.Forms.Padding(22, 1, 0, 2)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(53, 22)
        Me.lblFrom.Text = "From DT"
        '
        'lblTo
        '
        Me.lblTo.Margin = New System.Windows.Forms.Padding(35, 1, 0, 2)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(39, 22)
        Me.lblTo.Text = "To DT"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.Black
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(25, 22)
        Me.lblTotalAmount.Text = "000"
        '
        'ToolStripSeparator35
        '
        Me.ToolStripSeparator35.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator35.Name = "ToolStripSeparator35"
        Me.ToolStripSeparator35.Size = New System.Drawing.Size(6, 25)
        '
        'lblTotalAmountLabel
        '
        Me.lblTotalAmountLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTotalAmountLabel.Name = "lblTotalAmountLabel"
        Me.lblTotalAmountLabel.Size = New System.Drawing.Size(34, 22)
        Me.lblTotalAmountLabel.Text = "Total"
        '
        'ToolStripSeparator34
        '
        Me.ToolStripSeparator34.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator34.Name = "ToolStripSeparator34"
        Me.ToolStripSeparator34.Size = New System.Drawing.Size(6, 25)
        '
        'lblCheckFound
        '
        Me.lblCheckFound.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblCheckFound.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCheckFound.Name = "lblCheckFound"
        Me.lblCheckFound.Size = New System.Drawing.Size(25, 22)
        Me.lblCheckFound.Text = "000"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(6, 25)
        '
        'lblCheckFoundLabel
        '
        Me.lblCheckFoundLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblCheckFoundLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCheckFoundLabel.Name = "lblCheckFoundLabel"
        Me.lblCheckFoundLabel.Size = New System.Drawing.Size(45, 22)
        Me.lblCheckFoundLabel.Text = "Checks"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator7.AutoSize = False
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'lblDepositsaFound
        '
        Me.lblDepositsaFound.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDepositsaFound.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepositsaFound.Name = "lblDepositsaFound"
        Me.lblDepositsaFound.Size = New System.Drawing.Size(31, 22)
        Me.lblDepositsaFound.Text = "0000"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(6, 25)
        '
        'lblDepositsaFoundLabel
        '
        Me.lblDepositsaFoundLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDepositsaFoundLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepositsaFoundLabel.Name = "lblDepositsaFoundLabel"
        Me.lblDepositsaFoundLabel.Size = New System.Drawing.Size(52, 22)
        Me.lblDepositsaFoundLabel.Text = "Deposits"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripButton1.Text = "Load"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "xls"
        '
        'frmBankDepositsAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 562)
        Me.Controls.Add(Me.FpSpreadDeposits)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MinimumSize = New System.Drawing.Size(1000, 600)
        Me.Name = "frmBankDepositsAdmin"
        Me.Text = "Admin Report"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.FpSpreadDeposits, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpreadDeposits_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents FpSpreadDeposits As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpreadDeposits_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTotalAmount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator35 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblTotalAmountLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator34 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblCheckFound As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblCheckFoundLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblDepositsaFound As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblDepositsaFoundLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportAllToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblFrom As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblTo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
