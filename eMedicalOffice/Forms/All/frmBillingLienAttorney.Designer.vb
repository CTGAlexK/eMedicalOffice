<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBillingLienAttorney
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
        Dim ColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer3 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer4 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer5 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBillingLienAttorney))
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("ColumnHeaderEnhanced")
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer1 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle3 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType1 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim NamedStyle4 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim LineBorder1 As FarPoint.Win.LineBorder = New FarPoint.Win.LineBorder(System.Drawing.Color.Gainsboro, 1, False, True, False, True)
        Dim GeneralCellType2 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim NamedStyle5 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("HeaderDefault")
        Dim ColumnHeaderRenderer6 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim NamedStyle6 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style2")
        Dim GeneralCellType3 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin1 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim NamedStyle7 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim LineBorder2 As FarPoint.Win.LineBorder = New FarPoint.Win.LineBorder(System.Drawing.Color.Gainsboro, 1, False, True, False, True)
        Dim GeneralCellType4 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim NamedStyle8 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("HeaderDefault")
        Dim ColumnHeaderRenderer7 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim NamedStyle9 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style2")
        Dim GeneralCellType5 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType2 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType3 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType4 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonPrint = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelRemove = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblAction = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLienDate = New System.Windows.Forms.MaskedTextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboLienAttorney = New eMedicalOffice.AutoCompleteComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblAddresses = New System.Windows.Forms.Label()
        Me.FpSpread1 = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpread1_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtContact2Phone = New System.Windows.Forms.Label()
        Me.txtContact2 = New System.Windows.Forms.Label()
        Me.txtContact1Phone = New System.Windows.Forms.Label()
        Me.txtContact1 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.Label()
        Me.txtFax2 = New System.Windows.Forms.Label()
        Me.txtFax1 = New System.Windows.Forms.Label()
        Me.txtPhone2 = New System.Windows.Forms.Label()
        Me.txtPhone1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtLienComments = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread1_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ColumnHeaderRenderer1.Name = "ColumnHeaderRenderer1"
        ColumnHeaderRenderer1.TextRotationAngle = 0R
        ColumnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        ColumnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer2.Name = "ColumnHeaderRenderer2"
        ColumnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer2.TextRotationAngle = 0R
        ColumnHeaderRenderer3.Name = "ColumnHeaderRenderer3"
        ColumnHeaderRenderer3.TextRotationAngle = 0R
        ColumnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        ColumnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer4.Name = "ColumnHeaderRenderer4"
        ColumnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer4.TextRotationAngle = 0R
        ColumnHeaderRenderer5.Name = "ColumnHeaderRenderer5"
        ColumnHeaderRenderer5.TextRotationAngle = 0R
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.Controls.Add(Me.ButtonPrint)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 400)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(733, 34)
        Me.Panel2.TabIndex = 147
        '
        'ButtonPrint
        '
        Me.ButtonPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPrint.Location = New System.Drawing.Point(563, 8)
        Me.ButtonPrint.Name = "ButtonPrint"
        Me.ButtonPrint.Size = New System.Drawing.Size(84, 23)
        Me.ButtonPrint.TabIndex = 2
        Me.ButtonPrint.Text = "Print Lien Bill"
        Me.ButtonPrint.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(7, 8)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.Location = New System.Drawing.Point(653, 8)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate.TabIndex = 0
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.LabelRemove)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblAction)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(733, 39)
        Me.Panel1.TabIndex = 148
        '
        'LabelRemove
        '
        Me.LabelRemove.AutoSize = True
        Me.LabelRemove.BackColor = System.Drawing.Color.Transparent
        Me.LabelRemove.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelRemove.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelRemove.Location = New System.Drawing.Point(384, 20)
        Me.LabelRemove.Name = "LabelRemove"
        Me.LabelRemove.Size = New System.Drawing.Size(298, 15)
        Me.LabelRemove.TabIndex = 284
        Me.LabelRemove.Text = "To remove a lien, clear data from the Lien Attorney Box"
        Me.LabelRemove.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(14, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 20)
        Me.Label1.TabIndex = 282
        Me.Label1.Text = "LIEN ATTORNEY INFORMATION"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(691, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 39)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lblAction
        '
        Me.lblAction.AutoSize = True
        Me.lblAction.BackColor = System.Drawing.Color.Transparent
        Me.lblAction.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAction.ForeColor = System.Drawing.Color.Green
        Me.lblAction.Location = New System.Drawing.Point(15, 20)
        Me.lblAction.Name = "lblAction"
        Me.lblAction.Size = New System.Drawing.Size(116, 15)
        Me.lblAction.TabIndex = 283
        Me.lblAction.Text = "Assign Lien Attorney"
        Me.lblAction.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(547, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 17)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "Lien Date"
        '
        'txtLienDate
        '
        Me.txtLienDate.AccessibleDescription = ""
        Me.txtLienDate.AccessibleName = ""
        Me.txtLienDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtLienDate.HidePromptOnLeave = True
        Me.txtLienDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtLienDate.Location = New System.Drawing.Point(550, 71)
        Me.txtLienDate.Mask = "00/00/0000"
        Me.txtLienDate.Name = "txtLienDate"
        Me.txtLienDate.Size = New System.Drawing.Size(171, 20)
        Me.txtLienDate.TabIndex = 151
        Me.txtLienDate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtLienDate.ValidatingType = GetType(Date)
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label21.Location = New System.Drawing.Point(12, 50)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(84, 17)
        Me.Label21.TabIndex = 280
        Me.Label21.Text = "Lien Attorney"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboLienAttorney
        '
        Me.cboLienAttorney.BackColor = System.Drawing.Color.White
        Me.cboLienAttorney.DropDownWidth = 400
        Me.cboLienAttorney.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboLienAttorney.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboLienAttorney.FormattingEnabled = True
        Me.cboLienAttorney.LimitToList = True
        Me.cboLienAttorney.Location = New System.Drawing.Point(15, 70)
        Me.cboLienAttorney.MaxNumericValue = 1.7976931348623157E+308R
        Me.cboLienAttorney.Name = "cboLienAttorney"
        Me.cboLienAttorney.NoDecimals = False
        Me.cboLienAttorney.NumericOnly = False
        Me.cboLienAttorney.ReadOnlyCombo = False
        Me.cboLienAttorney.Size = New System.Drawing.Size(525, 21)
        Me.cboLienAttorney.TabIndex = 281
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(9, 51)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(102, 17)
        Me.Label19.TabIndex = 296
        Me.Label19.Text = "Contact 1 Name"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(367, 51)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(102, 17)
        Me.Label20.TabIndex = 297
        Me.Label20.Text = "Contact 2 Name"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(9, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 17)
        Me.Label11.TabIndex = 291
        Me.Label11.Text = "Phone 1"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(110, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 17)
        Me.Label12.TabIndex = 292
        Me.Label12.Text = "Phone 2"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(416, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 17)
        Me.Label14.TabIndex = 294
        Me.Label14.Text = "Email"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(214, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 17)
        Me.Label13.TabIndex = 293
        Me.Label13.Text = "Fax 1"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(188, 51)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(103, 17)
        Me.Label22.TabIndex = 298
        Me.Label22.Text = "Contact 1 Phone"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(547, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(103, 17)
        Me.Label23.TabIndex = 299
        Me.Label23.Text = "Contact 2 Phone"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(315, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 17)
        Me.Label2.TabIndex = 295
        Me.Label2.Text = "Fax 2"
        '
        'lblAddresses
        '
        Me.lblAddresses.AutoSize = True
        Me.lblAddresses.BackColor = System.Drawing.Color.Transparent
        Me.lblAddresses.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblAddresses.ForeColor = System.Drawing.Color.White
        Me.lblAddresses.Location = New System.Drawing.Point(9, 95)
        Me.lblAddresses.Name = "lblAddresses"
        Me.lblAddresses.Size = New System.Drawing.Size(149, 17)
        Me.lblAddresses.TabIndex = 301
        Me.lblAddresses.Text = "Lien Attorney Addresses"
        '
        'FpSpread1
        '
        Me.FpSpread1.AccessibleDescription = "FpSpread1, Sheet1, Row 0, Column 0, "
        Me.FpSpread1.AllowUserZoom = False
        Me.FpSpread1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.FpSpread1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FpSpread1.EditModePermanent = True
        Me.FpSpread1.EditModeReplace = True
        Me.FpSpread1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FpSpread1.Location = New System.Drawing.Point(8, 115)
        Me.FpSpread1.Name = "FpSpread1"
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
        NamedStyle3.BackColor = System.Drawing.SystemColors.Window
        NamedStyle3.CellType = GeneralCellType1
        NamedStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle3.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle3.Renderer = GeneralCellType1
        NamedStyle4.BackColor = System.Drawing.Color.LightSlateGray
        NamedStyle4.Border = LineBorder1
        NamedStyle4.ForeColor = System.Drawing.Color.White
        NamedStyle4.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle4.Locked = False
        NamedStyle4.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle4.Renderer = GeneralCellType2
        NamedStyle4.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle4.VisualStyles = FarPoint.Win.VisualStyles.Off
        NamedStyle5.BackColor = System.Drawing.SystemColors.Control
        NamedStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle5.NoteIndicatorColor = System.Drawing.Color.Red
        ColumnHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        ColumnHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer6.Name = ""
        ColumnHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer6.TextRotationAngle = 0R
        NamedStyle5.Renderer = ColumnHeaderRenderer6
        NamedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        NamedStyle6.CellType = GeneralCellType3
        NamedStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle6.Locked = False
        NamedStyle6.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle6.Renderer = GeneralCellType3
        Me.FpSpread1.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1, NamedStyle2, NamedStyle3, NamedStyle4, NamedStyle5, NamedStyle6})
        Me.FpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpread1.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpread1.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows
        Me.FpSpread1.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpread1_Sheet1})
        Me.FpSpread1.Size = New System.Drawing.Size(712, 86)
        NamedStyle7.BackColor = System.Drawing.Color.LightSlateGray
        NamedStyle7.Border = LineBorder2
        NamedStyle7.ForeColor = System.Drawing.Color.White
        NamedStyle7.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle7.Locked = False
        NamedStyle7.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle7.Renderer = GeneralCellType4
        NamedStyle7.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle7.VisualStyles = FarPoint.Win.VisualStyles.Off
        SpreadSkin1.ColumnHeaderDefaultStyle = NamedStyle7
        NamedStyle8.BackColor = System.Drawing.SystemColors.Control
        NamedStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle8.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle8.NoteIndicatorColor = System.Drawing.Color.Red
        ColumnHeaderRenderer7.Name = ""
        ColumnHeaderRenderer7.TextRotationAngle = 0R
        NamedStyle8.Renderer = ColumnHeaderRenderer7
        NamedStyle8.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        SpreadSkin1.CornerDefaultStyle = NamedStyle8
        NamedStyle9.BackColor = System.Drawing.Color.WhiteSmoke
        NamedStyle9.CellType = GeneralCellType5
        NamedStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle9.Locked = False
        NamedStyle9.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle9.Renderer = GeneralCellType5
        SpreadSkin1.DefaultStyle = NamedStyle9
        SpreadSkin1.Name = "CustomSkin1"
        SpreadSkin1.RowHeaderDefaultStyle = NamedStyle8
        SpreadSkin1.ScrollBarRenderer = EnhancedScrollBarRenderer1
        SpreadSkin1.SelectionRenderer = New FarPoint.Win.Spread.DefaultSelectionRenderer()
        Me.FpSpread1.Skin = SpreadSkin1
        Me.FpSpread1.TabIndex = 300
        Me.FpSpread1.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never
        Me.FpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'FpSpread1_Sheet1
        '
        Me.FpSpread1_Sheet1.Reset()
        Me.FpSpread1_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpread1_Sheet1.ColumnCount = 4
        Me.FpSpread1_Sheet1.RowCount = 1
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Address"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "City"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "State"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Zip"
        Me.FpSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FpSpread1_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "Style1"
        Me.FpSpread1_Sheet1.Columns.Get(0).CellType = TextCellType1
        Me.FpSpread1_Sheet1.Columns.Get(0).Label = "Address"
        Me.FpSpread1_Sheet1.Columns.Get(0).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(0).Width = 398.0!
        Me.FpSpread1_Sheet1.Columns.Get(1).CellType = TextCellType2
        Me.FpSpread1_Sheet1.Columns.Get(1).Label = "City"
        Me.FpSpread1_Sheet1.Columns.Get(1).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(1).Width = 139.0!
        Me.FpSpread1_Sheet1.Columns.Get(2).CellType = TextCellType3
        Me.FpSpread1_Sheet1.Columns.Get(2).Label = "State"
        Me.FpSpread1_Sheet1.Columns.Get(2).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(2).Width = 71.0!
        Me.FpSpread1_Sheet1.Columns.Get(3).CellType = TextCellType4
        Me.FpSpread1_Sheet1.Columns.Get(3).Label = "Zip"
        Me.FpSpread1_Sheet1.Columns.Get(3).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(3).Width = 72.0!
        Me.FpSpread1_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread1_Sheet1.DefaultStyle.Parent = "Style2"
        Me.FpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.Transparent
        Me.FpSpread1_Sheet1.LockBackColor = System.Drawing.Color.WhiteSmoke
        Me.FpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpread1_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.FpSpread1_Sheet1.RowHeader.Visible = False
        Me.FpSpread1_Sheet1.Rows.Get(0).Locked = True
        Me.FpSpread1_Sheet1.SelectionBackColor = System.Drawing.Color.Lavender
        Me.FpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.[Single]
        Me.FpSpread1_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault"
        Me.FpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.txtContact2Phone)
        Me.Panel3.Controls.Add(Me.txtContact2)
        Me.Panel3.Controls.Add(Me.txtContact1Phone)
        Me.Panel3.Controls.Add(Me.txtContact1)
        Me.Panel3.Controls.Add(Me.txtEmail)
        Me.Panel3.Controls.Add(Me.txtFax2)
        Me.Panel3.Controls.Add(Me.txtFax1)
        Me.Panel3.Controls.Add(Me.txtPhone2)
        Me.Panel3.Controls.Add(Me.txtPhone1)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.lblAddresses)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.FpSpread1)
        Me.Panel3.Controls.Add(Me.Label23)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Panel3.ForeColor = System.Drawing.Color.White
        Me.Panel3.Location = New System.Drawing.Point(0, 189)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(733, 211)
        Me.Panel3.TabIndex = 303
        '
        'txtContact2Phone
        '
        Me.txtContact2Phone.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtContact2Phone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtContact2Phone.ForeColor = System.Drawing.Color.Black
        Me.txtContact2Phone.Location = New System.Drawing.Point(547, 72)
        Me.txtContact2Phone.Name = "txtContact2Phone"
        Me.txtContact2Phone.Size = New System.Drawing.Size(173, 20)
        Me.txtContact2Phone.TabIndex = 311
        Me.txtContact2Phone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContact2
        '
        Me.txtContact2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtContact2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtContact2.ForeColor = System.Drawing.Color.Black
        Me.txtContact2.Location = New System.Drawing.Point(367, 72)
        Me.txtContact2.Name = "txtContact2"
        Me.txtContact2.Size = New System.Drawing.Size(173, 20)
        Me.txtContact2.TabIndex = 310
        Me.txtContact2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContact1Phone
        '
        Me.txtContact1Phone.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtContact1Phone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtContact1Phone.ForeColor = System.Drawing.Color.Black
        Me.txtContact1Phone.Location = New System.Drawing.Point(188, 72)
        Me.txtContact1Phone.Name = "txtContact1Phone"
        Me.txtContact1Phone.Size = New System.Drawing.Size(173, 20)
        Me.txtContact1Phone.TabIndex = 309
        Me.txtContact1Phone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContact1
        '
        Me.txtContact1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtContact1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtContact1.ForeColor = System.Drawing.Color.Black
        Me.txtContact1.Location = New System.Drawing.Point(9, 72)
        Me.txtContact1.Name = "txtContact1"
        Me.txtContact1.Size = New System.Drawing.Size(173, 20)
        Me.txtContact1.TabIndex = 308
        Me.txtContact1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.txtEmail.Location = New System.Drawing.Point(416, 29)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(304, 20)
        Me.txtEmail.TabIndex = 307
        Me.txtEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFax2
        '
        Me.txtFax2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFax2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFax2.ForeColor = System.Drawing.Color.Black
        Me.txtFax2.Location = New System.Drawing.Point(315, 29)
        Me.txtFax2.Name = "txtFax2"
        Me.txtFax2.Size = New System.Drawing.Size(95, 20)
        Me.txtFax2.TabIndex = 306
        Me.txtFax2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFax1
        '
        Me.txtFax1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFax1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFax1.ForeColor = System.Drawing.Color.Black
        Me.txtFax1.Location = New System.Drawing.Point(214, 29)
        Me.txtFax1.Name = "txtFax1"
        Me.txtFax1.Size = New System.Drawing.Size(95, 20)
        Me.txtFax1.TabIndex = 305
        Me.txtFax1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPhone2
        '
        Me.txtPhone2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPhone2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPhone2.ForeColor = System.Drawing.Color.Black
        Me.txtPhone2.Location = New System.Drawing.Point(113, 29)
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.Size = New System.Drawing.Size(95, 20)
        Me.txtPhone2.TabIndex = 304
        Me.txtPhone2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPhone1
        '
        Me.txtPhone1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPhone1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPhone1.ForeColor = System.Drawing.Color.Black
        Me.txtPhone1.Location = New System.Drawing.Point(12, 29)
        Me.txtPhone1.Name = "txtPhone1"
        Me.txtPhone1.Size = New System.Drawing.Size(95, 20)
        Me.txtPhone1.TabIndex = 303
        Me.txtPhone1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(703, 74)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 304
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Set Today's date")
        '
        'txtLienComments
        '
        Me.txtLienComments.Location = New System.Drawing.Point(15, 110)
        Me.txtLienComments.Multiline = True
        Me.txtLienComments.Name = "txtLienComments"
        Me.txtLienComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLienComments.Size = New System.Drawing.Size(706, 64)
        Me.txtLienComments.TabIndex = 305
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(12, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 17)
        Me.Label4.TabIndex = 306
        Me.Label4.Text = "Lien Comments"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(492, 90)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 307
        Me.MonthCalendar1.Visible = False
        '
        'frmBillingLienAttorney
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(733, 434)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.txtLienComments)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cboLienAttorney)
        Me.Controls.Add(Me.txtLienDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmBillingLienAttorney"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Lien Attorney Information"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpread1_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLienDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cboLienAttorney As AutoCompleteComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblAddresses As Label
    Friend WithEvents FpSpread1 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpread1_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txtContact2Phone As Label
    Friend WithEvents txtContact2 As Label
    Friend WithEvents txtContact1Phone As Label
    Friend WithEvents txtContact1 As Label
    Friend WithEvents txtEmail As Label
    Friend WithEvents txtFax2 As Label
    Friend WithEvents txtFax1 As Label
    Friend WithEvents txtPhone2 As Label
    Friend WithEvents txtPhone1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents txtLienComments As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAction As Label
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents LabelRemove As Label
    Friend WithEvents ButtonPrint As Button
End Class
