<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttorneysReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAttorneysReport))
        Dim DefaultFocusIndicatorRenderer1 As FarPoint.Win.Spread.DefaultFocusIndicatorRenderer = New FarPoint.Win.Spread.DefaultFocusIndicatorRenderer()
        Dim DefaultScrollBarRenderer1 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("ColumnHeaderEnhanced")
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderEnhanced")
        Dim NamedStyle3 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer1 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle4 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType1 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim DefaultScrollBarRenderer2 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim NumberCellType1 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType2 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType3 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType4 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType5 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType6 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType7 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType8 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType9 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType10 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType11 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType12 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType13 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType14 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnExportToExcel = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.FpSpreadReport = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpreadReport_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.cboBillingProvider = New System.Windows.Forms.ComboBox()
        Me.cboAttorneysCompanyID = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.FpSpreadReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpreadReport_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
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
        Me.Label2.Size = New System.Drawing.Size(190, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ARBITRATION CASES REPORT"
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
        Me.Panel3.Controls.Add(Me.btnExportToExcel)
        Me.Panel3.Controls.Add(Me.cmdClose)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 421)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(898, 29)
        Me.Panel3.TabIndex = 206
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Image = CType(resources.GetObject("btnExportToExcel.Image"), System.Drawing.Image)
        Me.btnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportToExcel.Location = New System.Drawing.Point(7, 3)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(108, 23)
        Me.btnExportToExcel.TabIndex = 4
        Me.btnExportToExcel.Text = "To Excel"
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
        Me.FpSpreadReport.HorizontalScrollBar.TabIndex = 12
        Me.FpSpreadReport.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FpSpreadReport.Location = New System.Drawing.Point(0, 62)
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
        Me.FpSpreadReport.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1, NamedStyle2, NamedStyle3, NamedStyle4})
        Me.FpSpreadReport.RetainSelectionBlock = False
        Me.FpSpreadReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpreadReport.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpreadReport.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical
        Me.FpSpreadReport.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows
        Me.FpSpreadReport.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpreadReport_Sheet1})
        Me.FpSpreadReport.Size = New System.Drawing.Size(898, 359)
        Me.FpSpreadReport.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic
        Me.FpSpreadReport.TabIndex = 207
        Me.FpSpreadReport.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating
        Me.FpSpreadReport.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpreadReport.VerticalScrollBar.Name = ""
        Me.FpSpreadReport.VerticalScrollBar.Renderer = DefaultScrollBarRenderer2
        Me.FpSpreadReport.VerticalScrollBar.TabIndex = 13
        Me.FpSpreadReport.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FpSpreadReport.VisualStyles = FarPoint.Win.VisualStyles.Off
        '
        'FpSpreadReport_Sheet1
        '
        Me.FpSpreadReport_Sheet1.Reset()
        Me.FpSpreadReport_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpreadReport_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpreadReport_Sheet1.ColumnCount = 15
        Me.FpSpreadReport_Sheet1.RowCount = 1
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Attorney"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Year"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Year Total"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Jan"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Feb"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 5).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Mar"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 6).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Apr"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 7).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "May"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 8).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Jun"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 9).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Jul"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 10).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Aug"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 11).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Sep"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 12).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Oct"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 13).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Nov"
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 14).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpreadReport_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Dec"
        Me.FpSpreadReport_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadReport_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.FpSpreadReport_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.FpSpreadReport_Sheet1.Columns.Get(0).Label = "Attorney"
        Me.FpSpreadReport_Sheet1.Columns.Get(0).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(0).Width = 221.0!
        NumberCellType1.DecimalPlaces = 0
        NumberCellType1.MaximumValue = 10000000.0R
        NumberCellType1.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(1).CellType = NumberCellType1
        Me.FpSpreadReport_Sheet1.Columns.Get(1).Label = "Year"
        Me.FpSpreadReport_Sheet1.Columns.Get(1).Locked = True
        NumberCellType2.DecimalPlaces = 0
        NumberCellType2.MaximumValue = 10000000.0R
        NumberCellType2.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(2).CellType = NumberCellType2
        Me.FpSpreadReport_Sheet1.Columns.Get(2).Label = "Year Total"
        Me.FpSpreadReport_Sheet1.Columns.Get(2).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(2).Width = 83.0!
        NumberCellType3.DecimalPlaces = 0
        NumberCellType3.MaximumValue = 10000000.0R
        NumberCellType3.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(3).CellType = NumberCellType3
        Me.FpSpreadReport_Sheet1.Columns.Get(3).Label = "Jan"
        Me.FpSpreadReport_Sheet1.Columns.Get(3).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(3).Width = 41.0!
        NumberCellType4.DecimalPlaces = 0
        NumberCellType4.MaximumValue = 10000000.0R
        NumberCellType4.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(4).CellType = NumberCellType4
        Me.FpSpreadReport_Sheet1.Columns.Get(4).Label = "Feb"
        Me.FpSpreadReport_Sheet1.Columns.Get(4).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(4).Width = 41.0!
        NumberCellType5.DecimalPlaces = 0
        NumberCellType5.MaximumValue = 10000000.0R
        NumberCellType5.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(5).CellType = NumberCellType5
        Me.FpSpreadReport_Sheet1.Columns.Get(5).Label = "Mar"
        Me.FpSpreadReport_Sheet1.Columns.Get(5).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(5).Width = 41.0!
        NumberCellType6.DecimalPlaces = 0
        NumberCellType6.MaximumValue = 10000000.0R
        NumberCellType6.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(6).CellType = NumberCellType6
        Me.FpSpreadReport_Sheet1.Columns.Get(6).Label = "Apr"
        Me.FpSpreadReport_Sheet1.Columns.Get(6).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(6).Width = 41.0!
        NumberCellType7.DecimalPlaces = 0
        NumberCellType7.MaximumValue = 10000000.0R
        NumberCellType7.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(7).CellType = NumberCellType7
        Me.FpSpreadReport_Sheet1.Columns.Get(7).Label = "May"
        Me.FpSpreadReport_Sheet1.Columns.Get(7).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(7).Width = 41.0!
        NumberCellType8.DecimalPlaces = 0
        NumberCellType8.MaximumValue = 10000000.0R
        NumberCellType8.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(8).CellType = NumberCellType8
        Me.FpSpreadReport_Sheet1.Columns.Get(8).Label = "Jun"
        Me.FpSpreadReport_Sheet1.Columns.Get(8).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(8).Width = 41.0!
        NumberCellType9.DecimalPlaces = 0
        NumberCellType9.MaximumValue = 10000000.0R
        NumberCellType9.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(9).CellType = NumberCellType9
        Me.FpSpreadReport_Sheet1.Columns.Get(9).Label = "Jul"
        Me.FpSpreadReport_Sheet1.Columns.Get(9).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(9).Width = 41.0!
        NumberCellType10.DecimalPlaces = 0
        NumberCellType10.MaximumValue = 10000000.0R
        NumberCellType10.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(10).CellType = NumberCellType10
        Me.FpSpreadReport_Sheet1.Columns.Get(10).Label = "Aug"
        Me.FpSpreadReport_Sheet1.Columns.Get(10).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(10).Width = 41.0!
        NumberCellType11.DecimalPlaces = 0
        NumberCellType11.MaximumValue = 10000000.0R
        NumberCellType11.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(11).CellType = NumberCellType11
        Me.FpSpreadReport_Sheet1.Columns.Get(11).Label = "Sep"
        Me.FpSpreadReport_Sheet1.Columns.Get(11).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(11).Width = 41.0!
        NumberCellType12.DecimalPlaces = 0
        NumberCellType12.MaximumValue = 10000000.0R
        NumberCellType12.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(12).CellType = NumberCellType12
        Me.FpSpreadReport_Sheet1.Columns.Get(12).Label = "Oct"
        Me.FpSpreadReport_Sheet1.Columns.Get(12).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(12).Width = 41.0!
        NumberCellType13.DecimalPlaces = 0
        NumberCellType13.MaximumValue = 10000000.0R
        NumberCellType13.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(13).CellType = NumberCellType13
        Me.FpSpreadReport_Sheet1.Columns.Get(13).Label = "Nov"
        Me.FpSpreadReport_Sheet1.Columns.Get(13).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(13).Width = 41.0!
        NumberCellType14.DecimalPlaces = 0
        NumberCellType14.MaximumValue = 10000000.0R
        NumberCellType14.MinimumValue = -10000000.0R
        Me.FpSpreadReport_Sheet1.Columns.Get(14).CellType = NumberCellType14
        Me.FpSpreadReport_Sheet1.Columns.Get(14).Label = "Dec"
        Me.FpSpreadReport_Sheet1.Columns.Get(14).Locked = True
        Me.FpSpreadReport_Sheet1.Columns.Get(14).Width = 41.0!
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
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.ButtonClear)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.cboYear)
        Me.Panel4.Controls.Add(Me.cboBillingProvider)
        Me.Panel4.Controls.Add(Me.cboAttorneysCompanyID)
        Me.Panel4.Controls.Add(Me.Button2)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel4.Location = New System.Drawing.Point(0, 33)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(898, 29)
        Me.Panel4.TabIndex = 208
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(631, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 148
        Me.Label4.Text = "Year"
        '
        'ButtonClear
        '
        Me.ButtonClear.BackColor = System.Drawing.Color.Transparent
        Me.ButtonClear.FlatAppearance.BorderSize = 0
        Me.ButtonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClear.Image = CType(resources.GetObject("ButtonClear.Image"), System.Drawing.Image)
        Me.ButtonClear.Location = New System.Drawing.Point(749, 2)
        Me.ButtonClear.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(26, 25)
        Me.ButtonClear.TabIndex = 147
        Me.ButtonClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButtonClear, "Reset")
        Me.ButtonClear.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(406, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 146
        Me.Label1.Text = "Provider"
        '
        'cboYear
        '
        Me.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboYear.ForeColor = System.Drawing.Color.Black
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(666, 5)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(79, 21)
        Me.cboYear.TabIndex = 145
        '
        'cboBillingProvider
        '
        Me.cboBillingProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingProvider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillingProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBillingProvider.ForeColor = System.Drawing.Color.Black
        Me.cboBillingProvider.FormattingEnabled = True
        Me.cboBillingProvider.Location = New System.Drawing.Point(458, 5)
        Me.cboBillingProvider.Name = "cboBillingProvider"
        Me.cboBillingProvider.Size = New System.Drawing.Size(172, 21)
        Me.cboBillingProvider.TabIndex = 145
        '
        'cboAttorneysCompanyID
        '
        Me.cboAttorneysCompanyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttorneysCompanyID.DropDownWidth = 300
        Me.cboAttorneysCompanyID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAttorneysCompanyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAttorneysCompanyID.ForeColor = System.Drawing.Color.Black
        Me.cboAttorneysCompanyID.FormattingEnabled = True
        Me.cboAttorneysCompanyID.Location = New System.Drawing.Point(55, 5)
        Me.cboAttorneysCompanyID.Name = "cboAttorneysCompanyID"
        Me.cboAttorneysCompanyID.Size = New System.Drawing.Size(347, 21)
        Me.cboAttorneysCompanyID.TabIndex = 144
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
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Attorney"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "xls"
        '
        'frmAttorneysReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 450)
        Me.Controls.Add(Me.FpSpreadReport)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmAttorneysReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Arbitration Cases Report"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.FpSpreadReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpreadReport_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
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
    Friend WithEvents cboAttorneysCompanyID As ComboBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents cboBillingProvider As ComboBox
    Friend WithEvents ButtonClear As Button
    Friend WithEvents cboYear As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
