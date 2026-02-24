<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminTasks
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
        Dim EnhancedRowHeaderRenderer1 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdminTasks))
        Dim DefaultFocusIndicatorRenderer1 As FarPoint.Win.Spread.DefaultFocusIndicatorRenderer = New FarPoint.Win.Spread.DefaultFocusIndicatorRenderer()
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderMetallic")
        Dim NamedStyle3 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType1 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin1 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim EnhancedInterfaceRenderer1 As FarPoint.Win.Spread.EnhancedInterfaceRenderer = New FarPoint.Win.Spread.EnhancedInterfaceRenderer()
        Dim CheckBoxCellType1 As FarPoint.Win.Spread.CellType.CheckBoxCellType = New FarPoint.Win.Spread.CellType.CheckBoxCellType()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.FpSpread = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpread_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.FpSpread, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ColumnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        ColumnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer1.Name = "ColumnHeaderRenderer1"
        ColumnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer1.TextRotationAngle = 0R
        ColumnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        ColumnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer2.Name = "ColumnHeaderRenderer2"
        ColumnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer2.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer1.ActiveBackgroundColor = System.Drawing.Color.DarkGray
        EnhancedRowHeaderRenderer1.Name = "EnhancedRowHeaderRenderer1"
        EnhancedRowHeaderRenderer1.NormalGridLineColor = System.Drawing.Color.DarkGray
        EnhancedRowHeaderRenderer1.SelectedActiveBackgroundColor = System.Drawing.Color.DarkGray
        EnhancedRowHeaderRenderer1.SelectedBackgroundColor = System.Drawing.Color.Gray
        EnhancedRowHeaderRenderer1.SelectedGridLineColor = System.Drawing.Color.DimGray
        EnhancedRowHeaderRenderer1.TextRotationAngle = 0R
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1127, 40)
        Me.Panel1.TabIndex = 146
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(167, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ADMIN TASKS CHECK LIST"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1081, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(46, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1127, 556)
        Me.TabControl1.TabIndex = 154
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel5)
        Me.TabPage1.Controls.Add(Me.Panel11)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1119, 530)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Current Tasks"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.FpSpread)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 33)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(10)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1113, 494)
        Me.Panel5.TabIndex = 157
        '
        'FpSpread
        '
        Me.FpSpread.AccessibleDescription = "FpSpreadForPrint, Sheet1, Row 0, Column 0, "
        Me.FpSpread.AllowCellOverflow = True
        Me.FpSpread.AllowColumnMove = True
        Me.FpSpread.AllowDrop = True
        Me.FpSpread.AllowEditOverflow = True
        Me.FpSpread.AllowRowMove = True
        Me.FpSpread.AllowSheetMove = True
        Me.FpSpread.AutoClipboard = False
        Me.FpSpread.BackColor = System.Drawing.SystemColors.Control
        Me.FpSpread.ClipboardOptions = FarPoint.Win.Spread.ClipboardOptions.NoHeaders
        Me.FpSpread.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpread.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FpSpread.FocusRenderer = DefaultFocusIndicatorRenderer1
        Me.FpSpread.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpread.HorizontalScrollBar.Name = ""
        Me.FpSpread.HorizontalScrollBar.Renderer = Nothing
        Me.FpSpread.HorizontalScrollBar.TabIndex = 14
        Me.FpSpread.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.FpSpread.Location = New System.Drawing.Point(0, 0)
        Me.FpSpread.Name = "FpSpread"
        NamedStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle1.Locked = False
        NamedStyle1.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle1.Renderer = ColumnHeaderRenderer2
        NamedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle2.BackColor = System.Drawing.Color.Silver
        NamedStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle2.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle2.Renderer = EnhancedRowHeaderRenderer1
        NamedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle3.BackColor = System.Drawing.SystemColors.Window
        NamedStyle3.CellType = GeneralCellType1
        NamedStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle3.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle3.Renderer = GeneralCellType1
        Me.FpSpread.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1, NamedStyle2, NamedStyle3})
        Me.FpSpread.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpread.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpread.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows
        Me.FpSpread.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpread_Sheet1})
        Me.FpSpread.Size = New System.Drawing.Size(1113, 494)
        SpreadSkin1.ColumnHeaderDefaultStyle = NamedStyle1
        SpreadSkin1.CornerDefaultStyle = NamedStyle3
        SpreadSkin1.DefaultStyle = NamedStyle3
        SpreadSkin1.FocusRenderer = DefaultFocusIndicatorRenderer1
        EnhancedInterfaceRenderer1.ArrowColorEnabled = System.Drawing.Color.Black
        EnhancedInterfaceRenderer1.GrayAreaColor = System.Drawing.Color.LightGray
        EnhancedInterfaceRenderer1.RangeGroupBackgroundColor = System.Drawing.Color.LightGray
        EnhancedInterfaceRenderer1.RangeGroupButtonBorderColor = System.Drawing.Color.DarkGray
        EnhancedInterfaceRenderer1.ScrollBoxBackgroundColor = System.Drawing.Color.LightGray
        EnhancedInterfaceRenderer1.SheetTabBorderColor = System.Drawing.Color.DarkGray
        EnhancedInterfaceRenderer1.SheetTabLowerActiveColor = System.Drawing.Color.LightGray
        EnhancedInterfaceRenderer1.SheetTabLowerNormalColor = System.Drawing.Color.Silver
        EnhancedInterfaceRenderer1.SheetTabUpperActiveColor = System.Drawing.Color.White
        EnhancedInterfaceRenderer1.SheetTabUpperNormalColor = System.Drawing.Color.LightGray
        EnhancedInterfaceRenderer1.SplitBarBackgroundColor = System.Drawing.Color.Silver
        EnhancedInterfaceRenderer1.SplitBarDarkColor = System.Drawing.Color.DarkGray
        EnhancedInterfaceRenderer1.SplitBoxBackgroundColor = System.Drawing.Color.Silver
        EnhancedInterfaceRenderer1.SplitBoxBorderColor = System.Drawing.Color.DarkGray
        EnhancedInterfaceRenderer1.TabStripBackgroundColor = System.Drawing.Color.LightGray
        EnhancedInterfaceRenderer1.TabStripButtonBorderColor = System.Drawing.Color.White
        EnhancedInterfaceRenderer1.TabStripButtonFlatStyle = System.Windows.Forms.FlatStyle.Flat
        EnhancedInterfaceRenderer1.TabStripButtonLowerActiveColor = System.Drawing.Color.DarkGray
        EnhancedInterfaceRenderer1.TabStripButtonLowerNormalColor = System.Drawing.Color.Silver
        EnhancedInterfaceRenderer1.TabStripButtonLowerPressedColor = System.Drawing.Color.DarkGray
        EnhancedInterfaceRenderer1.TabStripButtonUpperActiveColor = System.Drawing.Color.LightGray
        EnhancedInterfaceRenderer1.TabStripButtonUpperNormalColor = System.Drawing.Color.LightGray
        EnhancedInterfaceRenderer1.TabStripButtonUpperPressedColor = System.Drawing.Color.DarkGray
        SpreadSkin1.InterfaceRenderer = EnhancedInterfaceRenderer1
        SpreadSkin1.Name = "CustomSkin2"
        SpreadSkin1.RowHeaderDefaultStyle = NamedStyle2
        SpreadSkin1.SelectionRenderer = New FarPoint.Win.Spread.DefaultSelectionRenderer()
        Me.FpSpread.Skin = SpreadSkin1
        Me.FpSpread.TabIndex = 120
        Me.FpSpread.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpread.VerticalScrollBar.Name = ""
        Me.FpSpread.VerticalScrollBar.Renderer = Nothing
        Me.FpSpread.VerticalScrollBar.TabIndex = 15
        Me.FpSpread.Visible = False
        '
        'FpSpread_Sheet1
        '
        Me.FpSpread_Sheet1.Reset()
        Me.FpSpread_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpread_Sheet1.ColumnCount = 2
        Me.FpSpread_Sheet1.RowCount = 5
        Me.FpSpread_Sheet1.ActiveSkin = New FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Horizontal, System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer)), System.Drawing.Color.Black, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, True, False, False, True, True, "HeaderDefault", "RowHeaderEnhanced", "DataAreaDefault", "CornerEnhanced")
        Me.FpSpread_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Task"
        Me.FpSpread_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Status"
        Me.FpSpread_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off
        Me.FpSpread_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FpSpread_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.Black
        Me.FpSpread_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.FpSpread_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off
        Me.FpSpread_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off
        Me.FpSpread_Sheet1.Columns.Get(0).Label = "Task"
        Me.FpSpread_Sheet1.Columns.Get(0).Locked = True
        Me.FpSpread_Sheet1.Columns.Get(0).Width = 763.0!
        CheckBoxCellType1.Picture.False = CType(resources.GetObject("resource.False"), System.Drawing.Image)
        CheckBoxCellType1.Picture.FalseDisabled = CType(resources.GetObject("resource.FalseDisabled"), System.Drawing.Image)
        CheckBoxCellType1.Picture.FalsePressed = CType(resources.GetObject("resource.FalsePressed"), System.Drawing.Image)
        CheckBoxCellType1.Picture.True = CType(resources.GetObject("resource.True"), System.Drawing.Image)
        CheckBoxCellType1.Picture.TrueDisabled = CType(resources.GetObject("resource.TrueDisabled"), System.Drawing.Image)
        CheckBoxCellType1.Picture.TruePressed = CType(resources.GetObject("resource.TruePressed"), System.Drawing.Image)
        CheckBoxCellType1.TextFalse = "Pending"
        CheckBoxCellType1.TextTrue = "Complete"
        Me.FpSpread_Sheet1.Columns.Get(1).CellType = CheckBoxCellType1
        Me.FpSpread_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.FpSpread_Sheet1.Columns.Get(1).Label = "Status"
        Me.FpSpread_Sheet1.Columns.Get(1).Width = 102.0!
        Me.FpSpread_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode
        Me.FpSpread_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpread_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off
        Me.FpSpread_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FpSpread_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.Black
        Me.FpSpread_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderEnhanced"
        Me.FpSpread_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off
        Me.FpSpread_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off
        Me.FpSpread_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FpSpread_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.Black
        Me.FpSpread_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread_Sheet1.SheetCornerStyle.Parent = "CornerEnhanced"
        Me.FpSpread_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off
        Me.FpSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.ForeColor = System.Drawing.Color.DarkOrange
        Me.Panel11.Location = New System.Drawing.Point(3, 30)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1113, 3)
        Me.Panel11.TabIndex = 153
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1119, 530)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Tasks History"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.Label3.Size = New System.Drawing.Size(1113, 27)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Label3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmAdminTasks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1127, 596)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmAdminTasks"
        Me.Text = "Admin Tasks"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.FpSpread, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpread_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents FpSpread As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpread_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Label3 As Label
End Class
