<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiagSchedule
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
        Dim EnhancedColumnHeaderRenderer3 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer3 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer1 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer1 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer2 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiagSchedule))
        Dim DefaultScrollBarRenderer1 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("ColumnHeaderEnhanced")
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderEnhanced")
        Dim NamedStyle3 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer1 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle4 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType1 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin1 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim EnhancedFocusIndicatorRenderer1 As FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer = New FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer()
        Dim EnhancedInterfaceRenderer1 As FarPoint.Win.Spread.EnhancedInterfaceRenderer = New FarPoint.Win.Spread.EnhancedInterfaceRenderer()
        Dim DefaultScrollBarRenderer2 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim DefaultScrollBarRenderer3 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim CheckBoxCellType1 As FarPoint.Win.Spread.CellType.CheckBoxCellType = New FarPoint.Win.Spread.CellType.CheckBoxCellType()
        Dim CheckBoxCellType2 As FarPoint.Win.Spread.CellType.CheckBoxCellType = New FarPoint.Win.Spread.CellType.CheckBoxCellType()
        Dim CheckBoxCellType3 As FarPoint.Win.Spread.CellType.CheckBoxCellType = New FarPoint.Win.Spread.CellType.CheckBoxCellType()
        Dim CheckBoxCellType4 As FarPoint.Win.Spread.CellType.CheckBoxCellType = New FarPoint.Win.Spread.CellType.CheckBoxCellType()
        Dim CheckBoxCellType5 As FarPoint.Win.Spread.CellType.CheckBoxCellType = New FarPoint.Win.Spread.CellType.CheckBoxCellType()
        Dim CheckBoxCellType6 As FarPoint.Win.Spread.CellType.CheckBoxCellType = New FarPoint.Win.Spread.CellType.CheckBoxCellType()
        Dim CheckBoxCellType7 As FarPoint.Win.Spread.CellType.CheckBoxCellType = New FarPoint.Win.Spread.CellType.CheckBoxCellType()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.FpSpread1 = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpread1_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread1_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        EnhancedColumnHeaderRenderer3.Name = "EnhancedColumnHeaderRenderer3"
        EnhancedColumnHeaderRenderer3.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer3.Name = "EnhancedRowHeaderRenderer3"
        EnhancedRowHeaderRenderer3.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        EnhancedColumnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer1.Name = "EnhancedColumnHeaderRenderer1"
        EnhancedColumnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer1.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control
        EnhancedRowHeaderRenderer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        EnhancedRowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedRowHeaderRenderer1.Name = "EnhancedRowHeaderRenderer1"
        EnhancedRowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedRowHeaderRenderer1.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer2.Name = "EnhancedColumnHeaderRenderer2"
        EnhancedColumnHeaderRenderer2.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer2.Name = "EnhancedRowHeaderRenderer2"
        EnhancedRowHeaderRenderer2.TextRotationAngle = 0R
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(721, 34)
        Me.Panel1.TabIndex = 147
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(683, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DIAGNOSTIC SCHEDULE"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.cmdPrint)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 535)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(721, 34)
        Me.Panel2.TabIndex = 149
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.ForeColor = System.Drawing.Color.Black
        Me.cmdClose.Location = New System.Drawing.Point(643, 8)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.BackColor = System.Drawing.Color.Transparent
        Me.cmdPrint.ForeColor = System.Drawing.Color.Black
        Me.cmdPrint.Location = New System.Drawing.Point(7, 8)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(75, 23)
        Me.cmdPrint.TabIndex = 0
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'FpSpread1
        '
        Me.FpSpread1.AccessibleDescription = "FpSpread1, Sheet1, Row 0, Column 0, "
        Me.FpSpread1.AllowUserZoom = False
        Me.FpSpread1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FpSpread1.AutoClipboard = False
        Me.FpSpread1.BackColor = System.Drawing.SystemColors.Control
        Me.FpSpread1.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpread1.HorizontalScrollBar.Name = ""
        Me.FpSpread1.HorizontalScrollBar.Renderer = DefaultScrollBarRenderer1
        Me.FpSpread1.HorizontalScrollBar.TabIndex = 2
        Me.FpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.FpSpread1.Location = New System.Drawing.Point(7, 40)
        Me.FpSpread1.Name = "FpSpread1"
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
        Me.FpSpread1.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1, NamedStyle2, NamedStyle3, NamedStyle4})
        Me.FpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpread1.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpread1.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpread1_Sheet1})
        Me.FpSpread1.Size = New System.Drawing.Size(713, 489)
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
        SpreadSkin1.Name = "CustomSkin3"
        SpreadSkin1.RowHeaderDefaultStyle = NamedStyle2
        SpreadSkin1.ScrollBarRenderer = DefaultScrollBarRenderer2
        SpreadSkin1.SelectionRenderer = New FarPoint.Win.Spread.DefaultSelectionRenderer()
        Me.FpSpread1.Skin = SpreadSkin1
        Me.FpSpread1.TabIndex = 150
        Me.FpSpread1.TabStrip.ButtonPolicy = FarPoint.Win.Spread.TabStripButtonPolicy.Never
        Me.FpSpread1.TabStripInsertTab = False
        Me.FpSpread1.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never
        Me.FpSpread1.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpread1.VerticalScrollBar.Name = ""
        Me.FpSpread1.VerticalScrollBar.Renderer = DefaultScrollBarRenderer3
        Me.FpSpread1.VerticalScrollBar.TabIndex = 3
        Me.FpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'FpSpread1_Sheet1
        '
        Me.FpSpread1_Sheet1.Reset()
        Me.FpSpread1_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpread1_Sheet1.ColumnCount = 8
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Procedure"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Sun"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Mon"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Tue"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Wed"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Thu"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Fri"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Sat"
        Me.FpSpread1_Sheet1.Columns.Get(0).CellType = TextCellType1
        Me.FpSpread1_Sheet1.Columns.Get(0).Label = "Procedure"
        Me.FpSpread1_Sheet1.Columns.Get(0).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(0).Resizable = False
        Me.FpSpread1_Sheet1.Columns.Get(0).Width = 270.0!
        CheckBoxCellType1.Picture.False = CType(resources.GetObject("resource.False"), System.Drawing.Image)
        CheckBoxCellType1.Picture.FalseDisabled = CType(resources.GetObject("resource.FalseDisabled"), System.Drawing.Image)
        CheckBoxCellType1.Picture.FalsePressed = CType(resources.GetObject("resource.FalsePressed"), System.Drawing.Image)
        CheckBoxCellType1.Picture.Indeterminate = CType(resources.GetObject("resource.Indeterminate"), System.Drawing.Image)
        CheckBoxCellType1.Picture.IndeterminateDisabled = CType(resources.GetObject("resource.IndeterminateDisabled"), System.Drawing.Image)
        CheckBoxCellType1.Picture.IndeterminatePressed = CType(resources.GetObject("resource.IndeterminatePressed"), System.Drawing.Image)
        CheckBoxCellType1.Picture.True = CType(resources.GetObject("resource.True"), System.Drawing.Image)
        CheckBoxCellType1.Picture.TrueDisabled = CType(resources.GetObject("resource.TrueDisabled"), System.Drawing.Image)
        CheckBoxCellType1.Picture.TruePressed = CType(resources.GetObject("resource.TruePressed"), System.Drawing.Image)
        Me.FpSpread1_Sheet1.Columns.Get(1).CellType = CheckBoxCellType1
        Me.FpSpread1_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(1).Label = "Sun"
        Me.FpSpread1_Sheet1.Columns.Get(1).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(1).Resizable = False
        Me.FpSpread1_Sheet1.Columns.Get(1).ShowSortIndicator = False
        CheckBoxCellType2.Picture.False = CType(resources.GetObject("resource.False1"), System.Drawing.Image)
        CheckBoxCellType2.Picture.FalseDisabled = CType(resources.GetObject("resource.FalseDisabled1"), System.Drawing.Image)
        CheckBoxCellType2.Picture.FalsePressed = CType(resources.GetObject("resource.FalsePressed1"), System.Drawing.Image)
        CheckBoxCellType2.Picture.Indeterminate = CType(resources.GetObject("resource.Indeterminate1"), System.Drawing.Image)
        CheckBoxCellType2.Picture.IndeterminateDisabled = CType(resources.GetObject("resource.IndeterminateDisabled1"), System.Drawing.Image)
        CheckBoxCellType2.Picture.IndeterminatePressed = CType(resources.GetObject("resource.IndeterminatePressed1"), System.Drawing.Image)
        CheckBoxCellType2.Picture.True = CType(resources.GetObject("resource.True1"), System.Drawing.Image)
        CheckBoxCellType2.Picture.TrueDisabled = CType(resources.GetObject("resource.TrueDisabled1"), System.Drawing.Image)
        CheckBoxCellType2.Picture.TruePressed = CType(resources.GetObject("resource.TruePressed1"), System.Drawing.Image)
        Me.FpSpread1_Sheet1.Columns.Get(2).CellType = CheckBoxCellType2
        Me.FpSpread1_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(2).Label = "Mon"
        Me.FpSpread1_Sheet1.Columns.Get(2).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(2).Resizable = False
        Me.FpSpread1_Sheet1.Columns.Get(2).ShowSortIndicator = False
        CheckBoxCellType3.Picture.False = CType(resources.GetObject("resource.False2"), System.Drawing.Image)
        CheckBoxCellType3.Picture.FalseDisabled = CType(resources.GetObject("resource.FalseDisabled2"), System.Drawing.Image)
        CheckBoxCellType3.Picture.FalsePressed = CType(resources.GetObject("resource.FalsePressed2"), System.Drawing.Image)
        CheckBoxCellType3.Picture.Indeterminate = CType(resources.GetObject("resource.Indeterminate2"), System.Drawing.Image)
        CheckBoxCellType3.Picture.IndeterminateDisabled = CType(resources.GetObject("resource.IndeterminateDisabled2"), System.Drawing.Image)
        CheckBoxCellType3.Picture.IndeterminatePressed = CType(resources.GetObject("resource.IndeterminatePressed2"), System.Drawing.Image)
        CheckBoxCellType3.Picture.True = CType(resources.GetObject("resource.True2"), System.Drawing.Image)
        CheckBoxCellType3.Picture.TrueDisabled = CType(resources.GetObject("resource.TrueDisabled2"), System.Drawing.Image)
        CheckBoxCellType3.Picture.TruePressed = CType(resources.GetObject("resource.TruePressed2"), System.Drawing.Image)
        Me.FpSpread1_Sheet1.Columns.Get(3).CellType = CheckBoxCellType3
        Me.FpSpread1_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(3).Label = "Tue"
        Me.FpSpread1_Sheet1.Columns.Get(3).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(3).Resizable = False
        Me.FpSpread1_Sheet1.Columns.Get(3).ShowSortIndicator = False
        CheckBoxCellType4.Picture.False = CType(resources.GetObject("resource.False3"), System.Drawing.Image)
        CheckBoxCellType4.Picture.FalseDisabled = CType(resources.GetObject("resource.FalseDisabled3"), System.Drawing.Image)
        CheckBoxCellType4.Picture.FalsePressed = CType(resources.GetObject("resource.FalsePressed3"), System.Drawing.Image)
        CheckBoxCellType4.Picture.Indeterminate = CType(resources.GetObject("resource.Indeterminate3"), System.Drawing.Image)
        CheckBoxCellType4.Picture.IndeterminateDisabled = CType(resources.GetObject("resource.IndeterminateDisabled3"), System.Drawing.Image)
        CheckBoxCellType4.Picture.IndeterminatePressed = CType(resources.GetObject("resource.IndeterminatePressed3"), System.Drawing.Image)
        CheckBoxCellType4.Picture.True = CType(resources.GetObject("resource.True3"), System.Drawing.Image)
        CheckBoxCellType4.Picture.TrueDisabled = CType(resources.GetObject("resource.TrueDisabled3"), System.Drawing.Image)
        CheckBoxCellType4.Picture.TruePressed = CType(resources.GetObject("resource.TruePressed3"), System.Drawing.Image)
        Me.FpSpread1_Sheet1.Columns.Get(4).CellType = CheckBoxCellType4
        Me.FpSpread1_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(4).Label = "Wed"
        Me.FpSpread1_Sheet1.Columns.Get(4).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(4).Resizable = False
        Me.FpSpread1_Sheet1.Columns.Get(4).ShowSortIndicator = False
        CheckBoxCellType5.Picture.False = CType(resources.GetObject("resource.False4"), System.Drawing.Image)
        CheckBoxCellType5.Picture.FalseDisabled = CType(resources.GetObject("resource.FalseDisabled4"), System.Drawing.Image)
        CheckBoxCellType5.Picture.FalsePressed = CType(resources.GetObject("resource.FalsePressed4"), System.Drawing.Image)
        CheckBoxCellType5.Picture.Indeterminate = CType(resources.GetObject("resource.Indeterminate4"), System.Drawing.Image)
        CheckBoxCellType5.Picture.IndeterminateDisabled = CType(resources.GetObject("resource.IndeterminateDisabled4"), System.Drawing.Image)
        CheckBoxCellType5.Picture.IndeterminatePressed = CType(resources.GetObject("resource.IndeterminatePressed4"), System.Drawing.Image)
        CheckBoxCellType5.Picture.True = CType(resources.GetObject("resource.True4"), System.Drawing.Image)
        CheckBoxCellType5.Picture.TrueDisabled = CType(resources.GetObject("resource.TrueDisabled4"), System.Drawing.Image)
        CheckBoxCellType5.Picture.TruePressed = CType(resources.GetObject("resource.TruePressed4"), System.Drawing.Image)
        Me.FpSpread1_Sheet1.Columns.Get(5).CellType = CheckBoxCellType5
        Me.FpSpread1_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(5).Label = "Thu"
        Me.FpSpread1_Sheet1.Columns.Get(5).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(5).Resizable = False
        Me.FpSpread1_Sheet1.Columns.Get(5).ShowSortIndicator = False
        CheckBoxCellType6.Picture.False = CType(resources.GetObject("resource.False5"), System.Drawing.Image)
        CheckBoxCellType6.Picture.FalseDisabled = CType(resources.GetObject("resource.FalseDisabled5"), System.Drawing.Image)
        CheckBoxCellType6.Picture.FalsePressed = CType(resources.GetObject("resource.FalsePressed5"), System.Drawing.Image)
        CheckBoxCellType6.Picture.Indeterminate = CType(resources.GetObject("resource.Indeterminate5"), System.Drawing.Image)
        CheckBoxCellType6.Picture.IndeterminateDisabled = CType(resources.GetObject("resource.IndeterminateDisabled5"), System.Drawing.Image)
        CheckBoxCellType6.Picture.IndeterminatePressed = CType(resources.GetObject("resource.IndeterminatePressed5"), System.Drawing.Image)
        CheckBoxCellType6.Picture.True = CType(resources.GetObject("resource.True5"), System.Drawing.Image)
        CheckBoxCellType6.Picture.TrueDisabled = CType(resources.GetObject("resource.TrueDisabled5"), System.Drawing.Image)
        CheckBoxCellType6.Picture.TruePressed = CType(resources.GetObject("resource.TruePressed5"), System.Drawing.Image)
        Me.FpSpread1_Sheet1.Columns.Get(6).CellType = CheckBoxCellType6
        Me.FpSpread1_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(6).Label = "Fri"
        Me.FpSpread1_Sheet1.Columns.Get(6).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(6).Resizable = False
        Me.FpSpread1_Sheet1.Columns.Get(6).ShowSortIndicator = False
        CheckBoxCellType7.Picture.False = CType(resources.GetObject("resource.False6"), System.Drawing.Image)
        CheckBoxCellType7.Picture.FalseDisabled = CType(resources.GetObject("resource.FalseDisabled6"), System.Drawing.Image)
        CheckBoxCellType7.Picture.FalsePressed = CType(resources.GetObject("resource.FalsePressed6"), System.Drawing.Image)
        CheckBoxCellType7.Picture.Indeterminate = CType(resources.GetObject("resource.Indeterminate6"), System.Drawing.Image)
        CheckBoxCellType7.Picture.IndeterminateDisabled = CType(resources.GetObject("resource.IndeterminateDisabled6"), System.Drawing.Image)
        CheckBoxCellType7.Picture.IndeterminatePressed = CType(resources.GetObject("resource.IndeterminatePressed6"), System.Drawing.Image)
        CheckBoxCellType7.Picture.True = CType(resources.GetObject("resource.True6"), System.Drawing.Image)
        CheckBoxCellType7.Picture.TrueDisabled = CType(resources.GetObject("resource.TrueDisabled6"), System.Drawing.Image)
        CheckBoxCellType7.Picture.TruePressed = CType(resources.GetObject("resource.TruePressed6"), System.Drawing.Image)
        Me.FpSpread1_Sheet1.Columns.Get(7).CellType = CheckBoxCellType7
        Me.FpSpread1_Sheet1.Columns.Get(7).ForeColor = System.Drawing.Color.Red
        Me.FpSpread1_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(7).Label = "Sat"
        Me.FpSpread1_Sheet1.Columns.Get(7).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(7).Resizable = False
        Me.FpSpread1_Sheet1.Columns.Get(7).ShowSortIndicator = False
        Me.FpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpread1_Sheet1.RowHeader.Visible = False
        Me.FpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'frmDiagSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(721, 569)
        Me.Controls.Add(Me.FpSpread1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDiagSchedule"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Procedures Schedule"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpread1_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents FpSpread1 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpread1_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
End Class
