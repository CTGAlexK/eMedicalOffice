<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAgingReport
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
        Dim RowHeaderRenderer1 As FarPoint.Win.Spread.CellType.RowHeaderRenderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer()
        Dim DefaultFocusIndicatorRenderer1 As FarPoint.Win.Spread.DefaultFocusIndicatorRenderer = New FarPoint.Win.Spread.DefaultFocusIndicatorRenderer()
        Dim DefaultScrollBarRenderer1 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("ColumnHeaderEnhanced")
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderEnhanced")
        Dim NamedStyle3 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer1 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle4 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType1 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim NamedStyle5 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim NamedStyle6 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderDefault")
        Dim NamedStyle7 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerDefault")
        Dim CornerRenderer1 As FarPoint.Win.Spread.CellType.CornerRenderer = New FarPoint.Win.Spread.CellType.CornerRenderer()
        Dim NamedStyle8 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style2")
        Dim GeneralCellType2 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin1 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim DefaultScrollBarRenderer2 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim DefaultScrollBarRenderer3 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim CurrencyCellType1 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim CurrencyCellType2 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim CurrencyCellType3 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim CurrencyCellType4 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgingReport))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ButtonEmail = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnPDF = New System.Windows.Forms.Button()
        Me.btnExportToExcel = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.FpSpreadReport = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpreadReport_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxFacility = New System.Windows.Forms.ComboBox()
        Me.CheckBoxNewPage = New System.Windows.Forms.CheckBox()
        Me.CheckBoxGrandTotal = New System.Windows.Forms.CheckBox()
        Me.CheckBoxFacilityTotal = New System.Windows.Forms.CheckBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.dummy = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.FpSpreadReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpreadReport_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ColumnHeaderRenderer1.Name = "ColumnHeaderRenderer1"
        ColumnHeaderRenderer1.TextRotationAngle = 0R
        RowHeaderRenderer1.Name = "RowHeaderRenderer1"
        RowHeaderRenderer1.TextRotationAngle = 0R
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(898, 33)
        Me.Panel1.TabIndex = 146
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(4, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "RECEIVABLE AGING REPORT"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(863, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.ButtonEmail)
        Me.Panel3.Controls.Add(Me.btnPrint)
        Me.Panel3.Controls.Add(Me.btnPDF)
        Me.Panel3.Controls.Add(Me.btnExportToExcel)
        Me.Panel3.Controls.Add(Me.cmdClose)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 421)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(898, 29)
        Me.Panel3.TabIndex = 206
        '
        'ButtonEmail
        '
        Me.ButtonEmail.Image = CType(resources.GetObject("ButtonEmail.Image"), System.Drawing.Image)
        Me.ButtonEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonEmail.Location = New System.Drawing.Point(283, 3)
        Me.ButtonEmail.Name = "ButtonEmail"
        Me.ButtonEmail.Size = New System.Drawing.Size(86, 24)
        Me.ButtonEmail.TabIndex = 8
        Me.ButtonEmail.Text = "Email"
        Me.ToolTip1.SetToolTip(Me.ButtonEmail, "Email Report")
        Me.ButtonEmail.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(191, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(86, 23)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "Print"
        Me.ToolTip1.SetToolTip(Me.btnPrint, "Print Report")
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnPDF
        '
        Me.btnPDF.Image = CType(resources.GetObject("btnPDF.Image"), System.Drawing.Image)
        Me.btnPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPDF.Location = New System.Drawing.Point(99, 3)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(86, 23)
        Me.btnPDF.TabIndex = 6
        Me.btnPDF.Text = "Adobe"
        Me.ToolTip1.SetToolTip(Me.btnPDF, "Export to Adobe PDF")
        Me.btnPDF.UseVisualStyleBackColor = True
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Image = CType(resources.GetObject("btnExportToExcel.Image"), System.Drawing.Image)
        Me.btnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportToExcel.Location = New System.Drawing.Point(7, 3)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(86, 23)
        Me.btnExportToExcel.TabIndex = 4
        Me.btnExportToExcel.Text = "Excel"
        Me.ToolTip1.SetToolTip(Me.btnExportToExcel, "Export To Excel")
        Me.btnExportToExcel.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(785, 3)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(108, 23)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'FpSpreadReport
        '
        Me.FpSpreadReport.AccessibleDescription = "FpSpreadReport, Sheet1, Row 0, Column 0, "
        Me.FpSpreadReport.AutoClipboard = False
        Me.FpSpreadReport.BackColor = System.Drawing.Color.White
        Me.FpSpreadReport.CellNoteIndicatorVisible = False
        Me.FpSpreadReport.ClipboardOptions = FarPoint.Win.Spread.ClipboardOptions.NoHeaders
        Me.FpSpreadReport.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpreadReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FpSpreadReport.FocusRenderer = DefaultFocusIndicatorRenderer1
        Me.FpSpreadReport.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpreadReport.HorizontalScrollBar.Name = ""
        Me.FpSpreadReport.HorizontalScrollBar.Renderer = DefaultScrollBarRenderer1
        Me.FpSpreadReport.HorizontalScrollBar.TabIndex = 36
        Me.FpSpreadReport.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FpSpreadReport.Location = New System.Drawing.Point(0, 65)
        Me.FpSpreadReport.Name = "FpSpreadReport"
        NamedStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(233, Byte), Integer))
        NamedStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle1.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(247, Byte), Integer))
        NamedStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle2.NoteIndicatorColor = System.Drawing.Color.Red
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
        NamedStyle5.BackColor = System.Drawing.SystemColors.Control
        NamedStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        NamedStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle5.Locked = False
        NamedStyle5.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle5.Renderer = ColumnHeaderRenderer1
        NamedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle6.BackColor = System.Drawing.SystemColors.Control
        NamedStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle6.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle6.Renderer = RowHeaderRenderer1
        NamedStyle6.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle7.BackColor = System.Drawing.SystemColors.Control
        NamedStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle7.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle7.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle7.Renderer = CornerRenderer1
        NamedStyle7.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle8.BackColor = System.Drawing.SystemColors.Window
        NamedStyle8.CellType = GeneralCellType2
        NamedStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle8.Locked = False
        NamedStyle8.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle8.Renderer = GeneralCellType2
        NamedStyle8.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpreadReport.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1, NamedStyle2, NamedStyle3, NamedStyle4, NamedStyle5, NamedStyle6, NamedStyle7, NamedStyle8})
        Me.FpSpreadReport.RetainSelectionBlock = False
        Me.FpSpreadReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpreadReport.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpreadReport.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical
        Me.FpSpreadReport.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows
        Me.FpSpreadReport.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpreadReport_Sheet1})
        Me.FpSpreadReport.Size = New System.Drawing.Size(898, 356)
        SpreadSkin1.ColumnHeaderDefaultStyle = NamedStyle5
        SpreadSkin1.CornerDefaultStyle = NamedStyle7
        SpreadSkin1.DefaultStyle = NamedStyle8
        SpreadSkin1.FocusRenderer = DefaultFocusIndicatorRenderer1
        SpreadSkin1.Name = "CustomSkin1"
        SpreadSkin1.RowHeaderDefaultStyle = NamedStyle6
        SpreadSkin1.ScrollBarRenderer = DefaultScrollBarRenderer2
        SpreadSkin1.SelectionRenderer = New FarPoint.Win.Spread.DefaultSelectionRenderer()
        Me.FpSpreadReport.Skin = SpreadSkin1
        Me.FpSpreadReport.TabIndex = 207
        Me.FpSpreadReport.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating
        Me.FpSpreadReport.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpreadReport.VerticalScrollBar.Name = ""
        Me.FpSpreadReport.VerticalScrollBar.Renderer = DefaultScrollBarRenderer3
        Me.FpSpreadReport.VerticalScrollBar.TabIndex = 37
        Me.FpSpreadReport.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'FpSpreadReport_Sheet1
        '
        Me.FpSpreadReport_Sheet1.Reset()
        Me.FpSpreadReport_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpreadReport_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpreadReport_Sheet1.ColumnCount = 6
        Me.FpSpreadReport_Sheet1.RowCount = 1
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Insurance Company"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "0-30 Days"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "30-60 Days"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "60-90 Days"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Total 90 Days"
        Me.FpSpreadReport_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadReport_Sheet1.ColumnHeader.DefaultStyle.Parent = "Style1"
        Me.FpSpreadReport_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.FpSpreadReport_Sheet1.Columns.Get(0).Label = "Insurance Company"
        Me.FpSpreadReport_Sheet1.Columns.Get(0).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(0).Width = 442.0!
        CurrencyCellType1.ShowSeparator = True
        Me.FpSpreadReport_Sheet1.Columns.Get(1).CellType = CurrencyCellType1
        Me.FpSpreadReport_Sheet1.Columns.Get(1).Label = "0-30 Days"
        Me.FpSpreadReport_Sheet1.Columns.Get(1).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(1).Width = 106.0!
        CurrencyCellType2.ShowSeparator = True
        Me.FpSpreadReport_Sheet1.Columns.Get(2).CellType = CurrencyCellType2
        Me.FpSpreadReport_Sheet1.Columns.Get(2).Label = "30-60 Days"
        Me.FpSpreadReport_Sheet1.Columns.Get(2).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(2).Width = 106.0!
        CurrencyCellType3.ShowSeparator = True
        Me.FpSpreadReport_Sheet1.Columns.Get(3).CellType = CurrencyCellType3
        Me.FpSpreadReport_Sheet1.Columns.Get(3).Label = "60-90 Days"
        Me.FpSpreadReport_Sheet1.Columns.Get(3).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(3).Width = 106.0!
        CurrencyCellType4.ShowSeparator = True
        Me.FpSpreadReport_Sheet1.Columns.Get(4).CellType = CurrencyCellType4
        Me.FpSpreadReport_Sheet1.Columns.Get(4).Label = "Total 90 Days"
        Me.FpSpreadReport_Sheet1.Columns.Get(4).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(4).Width = 106.0!
        Me.FpSpreadReport_Sheet1.Columns.Get(5).Visible = False
        Me.FpSpreadReport_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadReport_Sheet1.DefaultStyle.Parent = "Style2"
        Me.FpSpreadReport_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
        Me.FpSpreadReport_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode
        Me.FpSpreadReport_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpreadReport_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadReport_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault"
        Me.FpSpreadReport_Sheet1.RowHeader.Visible = False
        Me.FpSpreadReport_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadReport_Sheet1.SheetCornerStyle.Parent = "CornerDefault"
        Me.FpSpreadReport_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.ComboBoxFacility)
        Me.Panel4.Controls.Add(Me.CheckBoxNewPage)
        Me.Panel4.Controls.Add(Me.CheckBoxGrandTotal)
        Me.Panel4.Controls.Add(Me.CheckBoxFacilityTotal)
        Me.Panel4.Controls.Add(Me.DateTimePicker1)
        Me.Panel4.Controls.Add(Me.Button2)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel4.Location = New System.Drawing.Point(0, 33)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(898, 32)
        Me.Panel4.TabIndex = 208
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(191, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = "Facility"
        '
        'ComboBoxFacility
        '
        Me.ComboBoxFacility.BackColor = System.Drawing.Color.White
        Me.ComboBoxFacility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFacility.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxFacility.FormattingEnabled = True
        Me.ComboBoxFacility.Location = New System.Drawing.Point(236, 5)
        Me.ComboBoxFacility.Name = "ComboBoxFacility"
        Me.ComboBoxFacility.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxFacility.TabIndex = 139
        '
        'CheckBoxNewPage
        '
        Me.CheckBoxNewPage.AutoSize = True
        Me.CheckBoxNewPage.Checked = True
        Me.CheckBoxNewPage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxNewPage.ForeColor = System.Drawing.Color.White
        Me.CheckBoxNewPage.Location = New System.Drawing.Point(543, 7)
        Me.CheckBoxNewPage.Name = "CheckBoxNewPage"
        Me.CheckBoxNewPage.Size = New System.Drawing.Size(117, 17)
        Me.CheckBoxNewPage.TabIndex = 138
        Me.CheckBoxNewPage.Text = "Facility Page Break"
        Me.CheckBoxNewPage.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ToolTip1.SetToolTip(Me.CheckBoxNewPage, "Start each facility from new page")
        Me.CheckBoxNewPage.UseVisualStyleBackColor = True
        '
        'CheckBoxGrandTotal
        '
        Me.CheckBoxGrandTotal.AutoSize = True
        Me.CheckBoxGrandTotal.Checked = True
        Me.CheckBoxGrandTotal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxGrandTotal.ForeColor = System.Drawing.Color.White
        Me.CheckBoxGrandTotal.Location = New System.Drawing.Point(459, 7)
        Me.CheckBoxGrandTotal.Name = "CheckBoxGrandTotal"
        Me.CheckBoxGrandTotal.Size = New System.Drawing.Size(82, 17)
        Me.CheckBoxGrandTotal.TabIndex = 137
        Me.CheckBoxGrandTotal.Text = "Grand Total"
        Me.ToolTip1.SetToolTip(Me.CheckBoxGrandTotal, "Print Grand Totals")
        Me.CheckBoxGrandTotal.UseVisualStyleBackColor = True
        '
        'CheckBoxFacilityTotal
        '
        Me.CheckBoxFacilityTotal.AutoSize = True
        Me.CheckBoxFacilityTotal.Checked = True
        Me.CheckBoxFacilityTotal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxFacilityTotal.ForeColor = System.Drawing.Color.White
        Me.CheckBoxFacilityTotal.Location = New System.Drawing.Point(372, 7)
        Me.CheckBoxFacilityTotal.Name = "CheckBoxFacilityTotal"
        Me.CheckBoxFacilityTotal.Size = New System.Drawing.Size(85, 17)
        Me.CheckBoxFacilityTotal.TabIndex = 136
        Me.CheckBoxFacilityTotal.Text = "Facility Total"
        Me.ToolTip1.SetToolTip(Me.CheckBoxFacilityTotal, "Print Totals per facility")
        Me.CheckBoxFacilityTotal.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(72, 5)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(113, 20)
        Me.DateTimePicker1.TabIndex = 135
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(786, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 25)
        Me.Button2.TabIndex = 134
        Me.Button2.Text = "Load"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Report Date"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "xls"
        Me.SaveFileDialog1.Title = "Export to MS Excel"
        '
        'SaveFileDialog2
        '
        Me.SaveFileDialog2.DefaultExt = "pdf"
        Me.SaveFileDialog2.Title = "Export to Adobe PDF"
        '
        'dummy
        '
        Me.dummy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dummy.Image = CType(resources.GetObject("dummy.Image"), System.Drawing.Image)
        Me.dummy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.dummy.Location = New System.Drawing.Point(395, -1000)
        Me.dummy.Name = "dummy"
        Me.dummy.Size = New System.Drawing.Size(108, 25)
        Me.dummy.TabIndex = 209
        Me.dummy.Text = "Load"
        Me.dummy.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(191, 7)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 275
        Me.PictureBox3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox3, "Receivable Aging Report " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "shows amount of outstanding balances " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "excluding dead d" &
        "ebt / closed bills.")
        '
        'frmAgingReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 450)
        Me.Controls.Add(Me.dummy)
        Me.Controls.Add(Me.FpSpreadReport)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(914, 489)
        Me.Name = "frmAgingReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Receivable Aging Report"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.FpSpreadReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpreadReport_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnExportToExcel As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents FpSpreadReport As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpreadReport_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents btnPDF As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents SaveFileDialog2 As SaveFileDialog
    Friend WithEvents dummy As Button
    Friend WithEvents ButtonEmail As Button
    Friend WithEvents CheckBoxGrandTotal As CheckBox
    Friend WithEvents CheckBoxFacilityTotal As CheckBox
    Friend WithEvents CheckBoxNewPage As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBoxFacility As ComboBox
    Friend WithEvents PictureBox3 As PictureBox
End Class
