<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDiagnosisMaintenanceConvert
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
        Dim RowHeaderRenderer1 As FarPoint.Win.Spread.CellType.RowHeaderRenderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer()
        Dim ColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim RowHeaderRenderer2 As FarPoint.Win.Spread.CellType.RowHeaderRenderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer()
        Dim ColumnHeaderRenderer3 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim RowHeaderRenderer3 As FarPoint.Win.Spread.CellType.RowHeaderRenderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDiagnosisMaintenanceConvert))
        Dim DefaultScrollBarRenderer1 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("ColumnHeaderEnhanced")
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer1 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle3 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("HeaderDefault")
        Dim NamedStyle4 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderDefault")
        Dim NamedStyle5 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerDefault")
        Dim CornerRenderer1 As FarPoint.Win.Spread.CellType.CornerRenderer = New FarPoint.Win.Spread.CellType.CornerRenderer()
        Dim NamedStyle6 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType1 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin1 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim DefaultScrollBarRenderer2 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim DefaultScrollBarRenderer3 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim CheckBoxCellType1 As FarPoint.Win.Spread.CellType.CheckBoxCellType = New FarPoint.Win.Spread.CellType.CheckBoxCellType()
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType2 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtICDCode = New System.Windows.Forms.TextBox()
        Me.txtICDDescription = New System.Windows.Forms.TextBox()
        Me.CheckedListBoxProcedures = New System.Windows.Forms.CheckedListBox()
        Me.ComboBoxGroups = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelUpdate = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FpSpread = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpread_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.FpSpread, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        ColumnHeaderRenderer1.Name = "ColumnHeaderRenderer1"
        ColumnHeaderRenderer1.TextRotationAngle = 0R
        RowHeaderRenderer1.Name = "RowHeaderRenderer1"
        RowHeaderRenderer1.TextRotationAngle = 0R
        ColumnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        ColumnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer2.Name = "ColumnHeaderRenderer2"
        ColumnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer2.TextRotationAngle = 0R
        RowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control
        RowHeaderRenderer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        RowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText
        RowHeaderRenderer2.Name = "RowHeaderRenderer2"
        RowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No
        RowHeaderRenderer2.TextRotationAngle = 0R
        ColumnHeaderRenderer3.Name = "ColumnHeaderRenderer3"
        ColumnHeaderRenderer3.TextRotationAngle = 0R
        RowHeaderRenderer3.Name = "RowHeaderRenderer3"
        RowHeaderRenderer3.TextRotationAngle = 0R
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "PageRed.png")
        Me.ImageList1.Images.SetKeyName(1, "Page.png")
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(701, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.Icon = CType(resources.GetObject("ErrorProvider1.Icon"), System.Drawing.Icon)
        '
        'txtICDCode
        '
        Me.txtICDCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtICDCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtICDCode.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconAlignment(Me.txtICDCode, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtICDCode.Location = New System.Drawing.Point(69, 30)
        Me.txtICDCode.MaxLength = 10
        Me.txtICDCode.Name = "txtICDCode"
        Me.txtICDCode.ReadOnly = True
        Me.txtICDCode.Size = New System.Drawing.Size(107, 21)
        Me.txtICDCode.TabIndex = 0
        '
        'txtICDDescription
        '
        Me.txtICDDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtICDDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtICDDescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtICDDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtICDDescription.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconAlignment(Me.txtICDDescription, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtICDDescription.Location = New System.Drawing.Point(203, 30)
        Me.txtICDDescription.MaxLength = 250
        Me.txtICDDescription.Name = "txtICDDescription"
        Me.txtICDDescription.ReadOnly = True
        Me.txtICDDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtICDDescription.Size = New System.Drawing.Size(510, 21)
        Me.txtICDDescription.TabIndex = 2
        '
        'CheckedListBoxProcedures
        '
        Me.CheckedListBoxProcedures.BackColor = System.Drawing.Color.White
        Me.CheckedListBoxProcedures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxProcedures.FormattingEnabled = True
        Me.CheckedListBoxProcedures.HorizontalScrollbar = True
        Me.ErrorProvider1.SetIconAlignment(Me.CheckedListBoxProcedures, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CheckedListBoxProcedures.IntegralHeight = False
        Me.CheckedListBoxProcedures.Location = New System.Drawing.Point(5, 5)
        Me.CheckedListBoxProcedures.Name = "CheckedListBoxProcedures"
        Me.CheckedListBoxProcedures.Size = New System.Drawing.Size(709, 293)
        Me.CheckedListBoxProcedures.TabIndex = 0
        '
        'ComboBoxGroups
        '
        Me.ComboBoxGroups.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ComboBoxGroups.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ComboBoxGroups.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxGroups, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxGroups.Location = New System.Drawing.Point(69, 57)
        Me.ComboBoxGroups.Name = "ComboBoxGroups"
        Me.ComboBoxGroups.Size = New System.Drawing.Size(644, 23)
        Me.ComboBoxGroups.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconAlignment(Me.Label2, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.Label2.Location = New System.Drawing.Point(5, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 212
        Me.Label2.Text = "Group"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 20
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 20
        Me.ToolTip1.ReshowDelay = 4
        Me.ToolTip1.ShowAlways = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LabelUpdate)
        Me.Panel2.Controls.Add(Me.cmdCancel)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 371)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(731, 34)
        Me.Panel2.TabIndex = 99
        '
        'LabelUpdate
        '
        Me.LabelUpdate.BackColor = System.Drawing.Color.Transparent
        Me.LabelUpdate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelUpdate.ForeColor = System.Drawing.Color.White
        Me.LabelUpdate.Location = New System.Drawing.Point(138, 8)
        Me.LabelUpdate.Name = "LabelUpdate"
        Me.LabelUpdate.Size = New System.Drawing.Size(506, 19)
        Me.LabelUpdate.TabIndex = 5
        Me.LabelUpdate.Text = "Update in progress. Please wait..."
        Me.LabelUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelUpdate.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(12, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.Image = CType(resources.GetObject("cmdUpdate.Image"), System.Drawing.Image)
        Me.cmdUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdUpdate.Location = New System.Drawing.Point(650, 6)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate.TabIndex = 3
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(2, 32)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(727, 331)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.ComboBoxGroups)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtICDCode)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.txtICDDescription)
        Me.TabPage1.Controls.Add(Me.Label29)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(719, 303)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.FpSpread)
        Me.Panel1.Location = New System.Drawing.Point(9, 86)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(704, 201)
        Me.Panel1.TabIndex = 257
        '
        'FpSpread
        '
        Me.FpSpread.AccessibleDescription = "FpSpread, Sheet1, Row 0, Column 0, "
        Me.FpSpread.AllowUserZoom = False
        Me.FpSpread.BackColor = System.Drawing.Color.White
        Me.FpSpread.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse
        Me.FpSpread.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FpSpread.ClipboardOptions = FarPoint.Win.Spread.ClipboardOptions.NoHeaders
        Me.FpSpread.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FpSpread.EditModeReplace = True
        Me.FpSpread.FocusRenderer = CType(resources.GetObject("FpSpread.FocusRenderer"), FarPoint.Win.Spread.IFocusIndicatorRenderer)
        Me.FpSpread.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FpSpread.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpread.HorizontalScrollBar.Name = ""
        Me.FpSpread.HorizontalScrollBar.Renderer = DefaultScrollBarRenderer1
        Me.FpSpread.HorizontalScrollBar.TabIndex = 34
        Me.FpSpread.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.FpSpread.Location = New System.Drawing.Point(0, 0)
        Me.FpSpread.Name = "FpSpread"
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
        NamedStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle3.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle3.Renderer = ColumnHeaderRenderer3
        NamedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle4.BackColor = System.Drawing.SystemColors.Control
        NamedStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle4.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle4.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle4.Renderer = RowHeaderRenderer3
        NamedStyle4.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle5.BackColor = System.Drawing.SystemColors.Control
        NamedStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle5.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle5.Renderer = CornerRenderer1
        NamedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle6.BackColor = System.Drawing.SystemColors.Window
        NamedStyle6.CellType = GeneralCellType1
        NamedStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle6.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle6.Renderer = GeneralCellType1
        Me.FpSpread.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1, NamedStyle2, NamedStyle3, NamedStyle4, NamedStyle5, NamedStyle6})
        Me.FpSpread.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpread.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpread.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical
        Me.FpSpread.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both
        Me.FpSpread.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows
        Me.FpSpread.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpread_Sheet1})
        Me.FpSpread.Size = New System.Drawing.Size(702, 199)
        SpreadSkin1.ColumnHeaderDefaultStyle = NamedStyle3
        SpreadSkin1.CornerDefaultStyle = NamedStyle5
        SpreadSkin1.DefaultStyle = NamedStyle6
        SpreadSkin1.FocusRenderer = CType(resources.GetObject("SpreadSkin1.FocusRenderer"), FarPoint.Win.Spread.IFocusIndicatorRenderer)
        SpreadSkin1.Name = "CustomSkin1"
        SpreadSkin1.RowHeaderDefaultStyle = NamedStyle4
        SpreadSkin1.ScrollBarRenderer = DefaultScrollBarRenderer2
        SpreadSkin1.SelectionRenderer = New FarPoint.Win.Spread.DefaultSelectionRenderer()
        Me.FpSpread.Skin = SpreadSkin1
        Me.FpSpread.TabIndex = 256
        Me.FpSpread.TabStop = False
        Me.FpSpread.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never
        Me.FpSpread.TextTipDelay = 200
        Me.FpSpread.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpread.VerticalScrollBar.Name = ""
        Me.FpSpread.VerticalScrollBar.Renderer = DefaultScrollBarRenderer3
        Me.FpSpread.VerticalScrollBar.TabIndex = 35
        Me.FpSpread.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FpSpread.VerticalScrollBarWidth = 16
        '
        'FpSpread_Sheet1
        '
        Me.FpSpread_Sheet1.Reset()
        Me.FpSpread_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpread_Sheet1.ColumnCount = 3
        Me.FpSpread_Sheet1.RowCount = 1
        Me.FpSpread_Sheet1.ActiveSkin = New FarPoint.Win.Spread.SheetSkin("CustomSkin2", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, True, True, False, True, True, "HeaderDefault", "HeaderDefault", "DataAreaDefault", "HeaderDefault")
        Me.FpSpread_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = " "
        Me.FpSpread_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "ICD Code"
        Me.FpSpread_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description"
        Me.FpSpread_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.[Auto]
        Me.FpSpread_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.FpSpread_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.[Auto]
        Me.FpSpread_Sheet1.Columns.Get(0).CellType = CheckBoxCellType1
        Me.FpSpread_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread_Sheet1.Columns.Get(0).Label = " "
        Me.FpSpread_Sheet1.Columns.Get(0).Width = 38.0!
        TextCellType1.MaxLength = 10
        Me.FpSpread_Sheet1.Columns.Get(1).CellType = TextCellType1
        Me.FpSpread_Sheet1.Columns.Get(1).Label = "ICD Code"
        Me.FpSpread_Sheet1.Columns.Get(1).Width = 160.0!
        TextCellType2.MaxLength = 150
        Me.FpSpread_Sheet1.Columns.Get(2).CellType = TextCellType2
        Me.FpSpread_Sheet1.Columns.Get(2).Label = "Description"
        Me.FpSpread_Sheet1.Columns.Get(2).Width = 449.0!
        Me.FpSpread_Sheet1.DataAllowAddNew = True
        Me.FpSpread_Sheet1.LockBackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.FpSpread_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpread_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.[Auto]
        Me.FpSpread_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.FpSpread_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.[Auto]
        Me.FpSpread_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread_Sheet1.SheetCornerStyle.Parent = "HeaderDefault"
        Me.FpSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Image = CType(resources.GetObject("Label11.Image"), System.Drawing.Image)
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(417, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(295, 19)
        Me.Label11.TabIndex = 255
        Me.Label11.Text = "The Original ICD9 Code will be set as Inactive"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(66, 10)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 15)
        Me.Label28.TabIndex = 210
        Me.Label28.Text = "ICDCode"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(200, 10)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(89, 15)
        Me.Label29.TabIndex = 211
        Me.Label29.Text = "ICDDescription"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(6, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 15)
        Me.Label10.TabIndex = 254
        Me.Label10.Text = "Original"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CheckedListBoxProcedures)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage2.Size = New System.Drawing.Size(719, 303)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Assigned To Procedures"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.WebBrowser1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage3.Size = New System.Drawing.Size(719, 303)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "LookUp"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.AllowWebBrowserDrop = False
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(5, 5)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.Size = New System.Drawing.Size(709, 293)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 20
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(0, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(731, 33)
        Me.Label12.TabIndex = 256
        Me.Label12.Text = "Please review the suggested ICD10 codes and if everything correct, click the Upda" &
    "te button"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmDiagnosisMaintenanceConvert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(731, 405)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label12)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "FrmDiagnosisMaintenanceConvert"
        Me.Opacity = 0R
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Diagnosis Maintenance Codes Convert"
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel2.ResumeLayout(false)
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage1.PerformLayout
        Me.Panel1.ResumeLayout(false)
        CType(Me.FpSpread,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.FpSpread_Sheet1,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage3.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label10 As Label
    Public WithEvents CheckedListBoxProcedures As CheckedListBox
    Public WithEvents txtICDCode As TextBox
    Public WithEvents txtICDDescription As TextBox
    Public WithEvents Timer1 As Timer
    Public WithEvents ComboBoxGroups As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TabPage3 As TabPage
    Public WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Label12 As Label
    Friend WithEvents FpSpread As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpread_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelUpdate As Label
End Class
