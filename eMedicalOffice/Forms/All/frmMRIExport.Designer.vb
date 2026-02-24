<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMRIExport
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
        Dim ColumnHeaderRenderer3 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer4 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer5 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer6 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer7 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer8 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer9 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer10 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer11 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer12 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer13 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer16 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer17 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMRIExport))
        Dim DefaultScrollBarRenderer1 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("ColumnHeaderEnhanced")
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer1 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle3 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim EmptyCellType1 As FarPoint.Win.Spread.CellType.EmptyCellType = New FarPoint.Win.Spread.CellType.EmptyCellType()
        Dim NamedStyle4 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("HeaderDefault")
        Dim NamedStyle5 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType1 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin1 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim DefaultScrollBarRenderer2 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim DefaultScrollBarRenderer3 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType2 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType3 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType4 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxNames = New System.Windows.Forms.ComboBox()
        Me.ComboBoxTreatingProviderID = New System.Windows.Forms.ComboBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.FpSpreadResults = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpread1_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.SaveFD = New System.Windows.Forms.SaveFileDialog()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCloseForm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LabelCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        CType(Me.FpSpreadResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread1_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        ColumnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ColumnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer4.Name = "ColumnHeaderRenderer4"
        ColumnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer4.TextRotationAngle = 0R
        ColumnHeaderRenderer5.Name = "ColumnHeaderRenderer5"
        ColumnHeaderRenderer5.TextRotationAngle = 0R
        ColumnHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ColumnHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer6.Name = "ColumnHeaderRenderer6"
        ColumnHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer6.TextRotationAngle = 0R
        ColumnHeaderRenderer7.Name = "ColumnHeaderRenderer7"
        ColumnHeaderRenderer7.TextRotationAngle = 0R
        ColumnHeaderRenderer8.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ColumnHeaderRenderer8.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer8.Name = "ColumnHeaderRenderer8"
        ColumnHeaderRenderer8.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer8.TextRotationAngle = 0R
        ColumnHeaderRenderer9.Name = "ColumnHeaderRenderer9"
        ColumnHeaderRenderer9.TextRotationAngle = 0R
        ColumnHeaderRenderer10.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        ColumnHeaderRenderer10.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer10.Name = "ColumnHeaderRenderer10"
        ColumnHeaderRenderer10.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer10.TextRotationAngle = 0R
        ColumnHeaderRenderer11.Name = "ColumnHeaderRenderer11"
        ColumnHeaderRenderer11.TextRotationAngle = 0R
        ColumnHeaderRenderer12.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        ColumnHeaderRenderer12.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer12.Name = "ColumnHeaderRenderer12"
        ColumnHeaderRenderer12.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer12.TextRotationAngle = 0R
        ColumnHeaderRenderer13.Name = "ColumnHeaderRenderer13"
        ColumnHeaderRenderer13.TextRotationAngle = 0R
        ColumnHeaderRenderer16.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        ColumnHeaderRenderer16.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer16.Name = "ColumnHeaderRenderer16"
        ColumnHeaderRenderer16.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer16.TextRotationAngle = 0R
        ColumnHeaderRenderer17.Name = "ColumnHeaderRenderer17"
        ColumnHeaderRenderer17.TextRotationAngle = 0R
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(410, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 297
        Me.Label2.Text = "Patient Name Format"
        '
        'ComboBoxNames
        '
        Me.ComboBoxNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxNames.FormattingEnabled = True
        Me.ComboBoxNames.Location = New System.Drawing.Point(413, 18)
        Me.ComboBoxNames.Name = "ComboBoxNames"
        Me.ComboBoxNames.Size = New System.Drawing.Size(200, 21)
        Me.ComboBoxNames.TabIndex = 296
        '
        'ComboBoxTreatingProviderID
        '
        Me.ComboBoxTreatingProviderID.AccessibleDescription = "1"
        Me.ComboBoxTreatingProviderID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTreatingProviderID.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxTreatingProviderID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxTreatingProviderID.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTreatingProviderID.FormattingEnabled = True
        Me.ComboBoxTreatingProviderID.Location = New System.Drawing.Point(209, 19)
        Me.ComboBoxTreatingProviderID.Name = "ComboBoxTreatingProviderID"
        Me.ComboBoxTreatingProviderID.Size = New System.Drawing.Size(200, 21)
        Me.ComboBoxTreatingProviderID.TabIndex = 294
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.ForeColor = System.Drawing.Color.White
        Me.Label68.Location = New System.Drawing.Point(209, 3)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(88, 13)
        Me.Label68.TabIndex = 295
        Me.Label68.Text = "Treating Provider"
        '
        'cmdLoad
        '
        Me.cmdLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLoad.Image = CType(resources.GetObject("cmdLoad.Image"), System.Drawing.Image)
        Me.cmdLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLoad.Location = New System.Drawing.Point(983, 6)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(66, 34)
        Me.cmdLoad.TabIndex = 4
        Me.cmdLoad.Text = "Load"
        Me.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(103, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Procedure To"
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTo.Location = New System.Drawing.Point(106, 19)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.ShowCheckBox = True
        Me.DateTimePickerTo.Size = New System.Drawing.Size(97, 20)
        Me.DateTimePickerTo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Procedure From"
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(5, 19)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.ShowCheckBox = True
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(97, 20)
        Me.DateTimePickerFrom.TabIndex = 2
        '
        'FpSpreadResults
        '
        Me.FpSpreadResults.AccessibleDescription = "FpSpreadResults, Sheet1, Row 0, Column 0, "
        Me.FpSpreadResults.AllowUserZoom = False
        Me.FpSpreadResults.BackColor = System.Drawing.Color.Transparent
        Me.FpSpreadResults.BackgroundImage = CType(resources.GetObject("FpSpreadResults.BackgroundImage"), System.Drawing.Image)
        Me.FpSpreadResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FpSpreadResults.EditModePermanent = True
        Me.FpSpreadResults.EditModeReplace = True
        Me.FpSpreadResults.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpreadResults.HorizontalScrollBar.Name = ""
        Me.FpSpreadResults.HorizontalScrollBar.Renderer = DefaultScrollBarRenderer1
        Me.FpSpreadResults.HorizontalScrollBar.TabIndex = 2
        Me.FpSpreadResults.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FpSpreadResults.Location = New System.Drawing.Point(200, 69)
        Me.FpSpreadResults.Name = "FpSpreadResults"
        NamedStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(233, Byte), Integer))
        NamedStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle1.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(233, Byte), Integer))
        NamedStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle2.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle2.Renderer = EnhancedCornerRenderer1
        NamedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle3.BackColor = System.Drawing.SystemColors.Control
        NamedStyle3.CellType = EmptyCellType1
        NamedStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle3.Locked = False
        NamedStyle3.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle3.Renderer = EmptyCellType1
        NamedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle4.BackColor = System.Drawing.SystemColors.Control
        NamedStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle4.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle4.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle4.Renderer = ColumnHeaderRenderer17
        NamedStyle4.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle5.BackColor = System.Drawing.SystemColors.Window
        NamedStyle5.CellType = GeneralCellType1
        NamedStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle5.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle5.Renderer = GeneralCellType1
        Me.FpSpreadResults.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1, NamedStyle2, NamedStyle3, NamedStyle4, NamedStyle5})
        Me.FpSpreadResults.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpreadResults.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpreadResults.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both
        Me.FpSpreadResults.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical
        Me.FpSpreadResults.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows
        Me.FpSpreadResults.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpread1_Sheet1})
        Me.FpSpreadResults.Size = New System.Drawing.Size(852, 463)
        SpreadSkin1.ColumnHeaderDefaultStyle = NamedStyle4
        SpreadSkin1.CornerDefaultStyle = NamedStyle4
        SpreadSkin1.DefaultStyle = NamedStyle5
        SpreadSkin1.Name = "CustomSkin1"
        SpreadSkin1.RowHeaderDefaultStyle = NamedStyle4
        SpreadSkin1.ScrollBarRenderer = DefaultScrollBarRenderer2
        SpreadSkin1.SelectionRenderer = New FarPoint.Win.Spread.DefaultSelectionRenderer()
        Me.FpSpreadResults.Skin = SpreadSkin1
        Me.FpSpreadResults.TabIndex = 119
        Me.FpSpreadResults.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never
        Me.FpSpreadResults.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpreadResults.VerticalScrollBar.Name = ""
        Me.FpSpreadResults.VerticalScrollBar.Renderer = DefaultScrollBarRenderer3
        Me.FpSpreadResults.VerticalScrollBar.TabIndex = 3
        Me.FpSpreadResults.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FpSpreadResults.Visible = False
        '
        'FpSpread1_Sheet1
        '
        Me.FpSpread1_Sheet1.Reset()
        Me.FpSpread1_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpread1_Sheet1.ColumnCount = 10
        Me.FpSpread1_Sheet1.RowCount = 11
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "PatientID"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Patient Name"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "DOB"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Sex"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "DOA"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Initial DT"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Procedure"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Date Of Service"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Referring Doctor"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Symptoms"
        Me.FpSpread1_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault"
        TextCellType1.Multiline = True
        Me.FpSpread1_Sheet1.Columns.Get(1).CellType = TextCellType1
        Me.FpSpread1_Sheet1.Columns.Get(1).Label = "Patient Name"
        Me.FpSpread1_Sheet1.Columns.Get(1).Locked = False
        Me.FpSpread1_Sheet1.Columns.Get(1).Width = 209.0!
        Me.FpSpread1_Sheet1.Columns.Get(2).Label = "DOB"
        Me.FpSpread1_Sheet1.Columns.Get(2).Width = 99.0!
        Me.FpSpread1_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(3).Label = "Sex"
        Me.FpSpread1_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        TextCellType2.Multiline = True
        Me.FpSpread1_Sheet1.Columns.Get(6).CellType = TextCellType2
        Me.FpSpread1_Sheet1.Columns.Get(6).Label = "Procedure"
        Me.FpSpread1_Sheet1.Columns.Get(6).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(6).Width = 193.0!
        TextCellType3.Multiline = True
        Me.FpSpread1_Sheet1.Columns.Get(7).CellType = TextCellType3
        Me.FpSpread1_Sheet1.Columns.Get(7).Label = "Date Of Service"
        Me.FpSpread1_Sheet1.Columns.Get(7).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(7).Width = 112.0!
        TextCellType4.Multiline = True
        Me.FpSpread1_Sheet1.Columns.Get(8).CellType = TextCellType4
        Me.FpSpread1_Sheet1.Columns.Get(8).Label = "Referring Doctor"
        Me.FpSpread1_Sheet1.Columns.Get(8).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(8).Width = 144.0!
        Me.FpSpread1_Sheet1.Columns.Get(9).Label = "Symptoms"
        Me.FpSpread1_Sheet1.Columns.Get(9).Width = 193.0!
        Me.FpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
        Me.FpSpread1_Sheet1.GroupBarBackColor = System.Drawing.Color.LightSteelBlue
        Me.FpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Me.FpSpread1_Sheet1.Protect = False
        Me.FpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpread1_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.FpSpread1_Sheet1.SelectionBackColor = System.Drawing.Color.Lavender
        Me.FpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.[Single]
        Me.FpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row
        Me.FpSpread1_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault"
        Me.FpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'ListView1
        '
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 69)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(200, 463)
        Me.ListView1.TabIndex = 299
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Fields"
        Me.ColumnHeader1.Width = 175
        '
        'Timer1
        '
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.DateTimePickerFrom)
        Me.Panel3.Controls.Add(Me.cmdLoad)
        Me.Panel3.Controls.Add(Me.DateTimePickerTo)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.ComboBoxNames)
        Me.Panel3.Controls.Add(Me.Label68)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.ComboBoxTreatingProviderID)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 25)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1052, 44)
        Me.Panel3.TabIndex = 150
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripSeparator2, Me.ToolStripButton2, Me.ToolStripDropDownButton1, Me.ToolStripButtonCloseForm, Me.ToolStripButton4, Me.ToolStripButton5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1052, 25)
        Me.ToolStrip1.TabIndex = 300
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.ToolStripButton3.Size = New System.Drawing.Size(28, 22)
        Me.ToolStripButton3.ToolTipText = "Autosize Spreads Columns Width"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.ToolStripButton2.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripButton2.Text = "Print"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripDropDownButton1.Text = "Excell"
        '
        'ToolStripButtonCloseForm
        '
        Me.ToolStripButtonCloseForm.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonCloseForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonCloseForm.Image = CType(resources.GetObject("ToolStripButtonCloseForm.Image"), System.Drawing.Image)
        Me.ToolStripButtonCloseForm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonCloseForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCloseForm.Name = "ToolStripButtonCloseForm"
        Me.ToolStripButtonCloseForm.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonCloseForm.ToolTipText = "Close Patient Procedures Statistic"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.ToolStripButton4.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton4.Text = "Email"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripButton5.Size = New System.Drawing.Size(47, 22)
        Me.ToolStripButton5.Text = "Fax"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 532)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1052, 22)
        Me.StatusStrip1.TabIndex = 301
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LabelCount
        '
        Me.LabelCount.Name = "LabelCount"
        Me.LabelCount.Size = New System.Drawing.Size(22, 17)
        Me.LabelCount.Text = "     "
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'frmMRIExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1052, 554)
        Me.Controls.Add(Me.FpSpreadResults)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmMRIExport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Data Export"
        CType(Me.FpSpreadResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpread1_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents FpSpreadResults As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpread1_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents SaveFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ComboBoxTreatingProviderID As System.Windows.Forms.ComboBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxNames As System.Windows.Forms.ComboBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonCloseForm As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents LabelCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
End Class
