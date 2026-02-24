<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashPayment
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
        Dim ColumnHeaderRenderer4 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer5 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer3 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCashPayment))
        Dim NamedStyle5 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("ColumnHeaderEnhanced")
        Dim NamedStyle6 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer2 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle7 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("HeaderDefault")
        Dim NamedStyle8 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType2 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin2 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim TextCellType2 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim CurrencyCellType3 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim PercentCellType2 As FarPoint.Win.Spread.CellType.PercentCellType = New FarPoint.Win.Spread.CellType.PercentCellType()
        Dim CurrencyCellType4 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FpSpreadProcedures = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpreadProcedures_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.ComboBoxPaymentType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxAmount = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PanelPaid = New System.Windows.Forms.Panel()
        Me.LabelAmountPaid = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpreadProcedures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpreadProcedures_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPaid.SuspendLayout()
        Me.SuspendLayout()
        ColumnHeaderRenderer1.Name = "ColumnHeaderRenderer1"
        ColumnHeaderRenderer1.TextRotationAngle = 0R
        ColumnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ColumnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer4.Name = "ColumnHeaderRenderer4"
        ColumnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer4.TextRotationAngle = 0R
        ColumnHeaderRenderer5.Name = "ColumnHeaderRenderer5"
        ColumnHeaderRenderer5.TextRotationAngle = 0R
        ColumnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ColumnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer2.Name = "ColumnHeaderRenderer2"
        ColumnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer2.TextRotationAngle = 0R
        ColumnHeaderRenderer3.Name = "ColumnHeaderRenderer3"
        ColumnHeaderRenderer3.TextRotationAngle = 0R
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 275)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(561, 34)
        Me.Panel2.TabIndex = 144
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(9, 8)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.Location = New System.Drawing.Point(478, 8)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate.TabIndex = 0
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(561, 34)
        Me.Panel1.TabIndex = 145
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(523, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 34)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PAYMENT REQUIRED"
        '
        'FpSpreadProcedures
        '
        Me.FpSpreadProcedures.AccessibleDescription = "FpSpreadProcedures, Sheet1, Row 0, Column 0, "
        Me.FpSpreadProcedures.AllowUserZoom = False
        Me.FpSpreadProcedures.BackColor = System.Drawing.Color.Transparent
        Me.FpSpreadProcedures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FpSpreadProcedures.EditModePermanent = True
        Me.FpSpreadProcedures.EditModeReplace = True
        Me.FpSpreadProcedures.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FpSpreadProcedures.Location = New System.Drawing.Point(9, 77)
        Me.FpSpreadProcedures.Name = "FpSpreadProcedures"
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
        Me.FpSpreadProcedures.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle5, NamedStyle6, NamedStyle7, NamedStyle8})
        Me.FpSpreadProcedures.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpreadProcedures.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpreadProcedures.ScrollBarMaxAlign = False
        Me.FpSpreadProcedures.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows
        Me.FpSpreadProcedures.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpreadProcedures_Sheet1})
        Me.FpSpreadProcedures.Size = New System.Drawing.Size(544, 160)
        SpreadSkin2.ColumnHeaderDefaultStyle = NamedStyle7
        SpreadSkin2.CornerDefaultStyle = NamedStyle7
        SpreadSkin2.DefaultStyle = NamedStyle8
        SpreadSkin2.Name = "CustomSkin1"
        SpreadSkin2.RowHeaderDefaultStyle = NamedStyle7
        SpreadSkin2.ScrollBarRenderer = EnhancedScrollBarRenderer2
        SpreadSkin2.SelectionRenderer = New FarPoint.Win.Spread.DefaultSelectionRenderer()
        Me.FpSpreadProcedures.Skin = SpreadSkin2
        Me.FpSpreadProcedures.TabIndex = 146
        Me.FpSpreadProcedures.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never
        Me.FpSpreadProcedures.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'FpSpreadProcedures_Sheet1
        '
        Me.FpSpreadProcedures_Sheet1.Reset()
        Me.FpSpreadProcedures_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpreadProcedures_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpreadProcedures_Sheet1.ColumnCount = 4
        Me.FpSpreadProcedures_Sheet1.RowCount = 1
        Me.FpSpreadProcedures_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Procedure"
        Me.FpSpreadProcedures_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Price"
        Me.FpSpreadProcedures_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Discount"
        Me.FpSpreadProcedures_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Discount Price"
        Me.FpSpreadProcedures_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadProcedures_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.FpSpreadProcedures_Sheet1.Columns.Get(0).CellType = TextCellType2
        Me.FpSpreadProcedures_Sheet1.Columns.Get(0).Label = "Procedure"
        Me.FpSpreadProcedures_Sheet1.Columns.Get(0).Locked = True
        Me.FpSpreadProcedures_Sheet1.Columns.Get(0).Resizable = False
        Me.FpSpreadProcedures_Sheet1.Columns.Get(0).Width = 296.0!
        CurrencyCellType3.DecimalPlaces = 2
        CurrencyCellType3.MinimumValue = New Decimal(New Integer() {0, 0, 0, 131072})
        CurrencyCellType3.ReadOnly = True
        Me.FpSpreadProcedures_Sheet1.Columns.Get(1).CellType = CurrencyCellType3
        Me.FpSpreadProcedures_Sheet1.Columns.Get(1).Label = "Price"
        Me.FpSpreadProcedures_Sheet1.Columns.Get(1).Resizable = False
        Me.FpSpreadProcedures_Sheet1.Columns.Get(1).Width = 82.0!
        PercentCellType2.DecimalPlaces = 0
        PercentCellType2.MaximumValue = 100.0R
        PercentCellType2.MinimumValue = 0R
        PercentCellType2.ReadOnly = True
        Me.FpSpreadProcedures_Sheet1.Columns.Get(2).CellType = PercentCellType2
        Me.FpSpreadProcedures_Sheet1.Columns.Get(2).Label = "Discount"
        Me.FpSpreadProcedures_Sheet1.Columns.Get(2).Resizable = False
        Me.FpSpreadProcedures_Sheet1.Columns.Get(2).Width = 59.0!
        CurrencyCellType4.DecimalPlaces = 2
        CurrencyCellType4.MinimumValue = New Decimal(New Integer() {0, 0, 0, 131072})
        CurrencyCellType4.ReadOnly = True
        Me.FpSpreadProcedures_Sheet1.Columns.Get(3).CellType = CurrencyCellType4
        Me.FpSpreadProcedures_Sheet1.Columns.Get(3).Label = "Discount Price"
        Me.FpSpreadProcedures_Sheet1.Columns.Get(3).Resizable = False
        Me.FpSpreadProcedures_Sheet1.Columns.Get(3).Width = 82.0!
        Me.FpSpreadProcedures_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
        Me.FpSpreadProcedures_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpreadProcedures_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadProcedures_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.FpSpreadProcedures_Sheet1.RowHeader.Visible = False
        Me.FpSpreadProcedures_Sheet1.SelectionBackColor = System.Drawing.Color.Lavender
        Me.FpSpreadProcedures_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.[Single]
        Me.FpSpreadProcedures_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadProcedures_Sheet1.SheetCornerStyle.Parent = "HeaderDefault"
        Me.FpSpreadProcedures_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'ComboBoxPaymentType
        '
        Me.ComboBoxPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPaymentType.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxPaymentType, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxPaymentType.Location = New System.Drawing.Point(106, 247)
        Me.ComboBoxPaymentType.Name = "ComboBoxPaymentType"
        Me.ComboBoxPaymentType.Size = New System.Drawing.Size(260, 21)
        Me.ComboBoxPaymentType.TabIndex = 147
        Me.ToolTip1.SetToolTip(Me.ComboBoxPaymentType, "Select Payment Type")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 250)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = "Payment Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(372, 250)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "Amount Paid"
        '
        'TextBoxAmount
        '
        Me.ErrorProvider1.SetIconAlignment(Me.TextBoxAmount, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.TextBoxAmount.Location = New System.Drawing.Point(466, 245)
        Me.TextBoxAmount.Name = "TextBoxAmount"
        Me.TextBoxAmount.Size = New System.Drawing.Size(83, 20)
        Me.TextBoxAmount.TabIndex = 150
        Me.TextBoxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBoxAmount, "Specify Payment Amount")
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'PanelPaid
        '
        Me.PanelPaid.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PanelPaid.Controls.Add(Me.LabelAmountPaid)
        Me.PanelPaid.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelPaid.Location = New System.Drawing.Point(0, 34)
        Me.PanelPaid.Name = "PanelPaid"
        Me.PanelPaid.Size = New System.Drawing.Size(561, 28)
        Me.PanelPaid.TabIndex = 151
        '
        'LabelAmountPaid
        '
        Me.LabelAmountPaid.AutoSize = True
        Me.LabelAmountPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelAmountPaid.ForeColor = System.Drawing.Color.White
        Me.LabelAmountPaid.Location = New System.Drawing.Point(12, 7)
        Me.LabelAmountPaid.Name = "LabelAmountPaid"
        Me.LabelAmountPaid.Size = New System.Drawing.Size(45, 13)
        Me.LabelAmountPaid.TabIndex = 0
        Me.LabelAmountPaid.Text = "Label4"
        '
        'frmCashPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(561, 309)
        Me.Controls.Add(Me.PanelPaid)
        Me.Controls.Add(Me.TextBoxAmount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBoxPaymentType)
        Me.Controls.Add(Me.FpSpreadProcedures)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCashPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payment Processing System"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpreadProcedures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpreadProcedures_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPaid.ResumeLayout(False)
        Me.PanelPaid.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FpSpreadProcedures As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpreadProcedures_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents ComboBoxPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAmount As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PanelPaid As System.Windows.Forms.Panel
    Friend WithEvents LabelAmountPaid As System.Windows.Forms.Label
End Class
