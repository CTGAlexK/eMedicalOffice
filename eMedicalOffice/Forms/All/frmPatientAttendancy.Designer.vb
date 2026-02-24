<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientAttendancy
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
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ColumnHeaderRenderer1 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer1 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer1 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim ColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer5 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim ColumnHeaderRenderer6 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientAttendancy))
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType2 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType3 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType4 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType5 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType6 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType7 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType8 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType9 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType10 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim EmptyCellType1 As FarPoint.Win.Spread.CellType.EmptyCellType = New FarPoint.Win.Spread.CellType.EmptyCellType()
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("HeaderDefault")
        Dim NamedStyle3 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType1 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ContextMenuStripCustomizeToolStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CustomizeToolbarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonCloseForm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripStatusLabelChecked = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripStatusLabelFound = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ExportAllToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportCheckedToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrinting2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PrintCheckedSelectedNF23ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPatientScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPatientsFileLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrintCheckedEnvelopes1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintResultListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuickPrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrintAll1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintCheckedOnly1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.EmailAllRecordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailCheckedOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindDuplicatePatientsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAccidentRelatedPatientsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFD = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PanelShowDetails = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ButtonDetails = New System.Windows.Forms.PictureBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ListViewPatients = New System.Windows.Forms.ListView()
        Me.PatientNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PatientName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DOA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CaseType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.STATUS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Insurance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PolicyNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClaimNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AdjusterName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Attorney = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NF2Date = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripNF2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuShowSelectedPatientInfo1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrinting1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageListTray = New System.Windows.Forms.ImageList(Me.components)
        Me.PanelDetails = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.ListViewPatientsRelated = New System.Windows.Forms.ListView()
        Me.ColumnHeader45 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader46 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.ListViewRequests = New System.Windows.Forms.ListView()
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.TreeViewBills = New System.Windows.Forms.TreeView()
        Me.PanelBills = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ListViewServices = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.ListViewProcedures = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Type = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ListViewSchedule = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ImageListCurrentBills = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtPACSAltNumber = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.txtBillNumber = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxFilter = New System.Windows.Forms.ComboBox()
        Me.txtPatientAttorney = New System.Windows.Forms.TextBox()
        Me.cboTreatingProvider = New System.Windows.Forms.ComboBox()
        Me.cboBillingProvider = New System.Windows.Forms.ComboBox()
        Me.ComboBoxSearchCaseType = New System.Windows.Forms.ComboBox()
        Me.ComboBoxSearchCaseStatus = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DateTimePickerDOATo = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerDOAFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DateTimePickerServicesFrom = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerServicesTo = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FpSpreadForPrint_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.FpSpreadForPrint = New FarPoint.Win.Spread.FpSpread()
        Me.PanelWait = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip2.SuspendLayout()
        Me.ContextMenuStripCustomizeToolStrip.SuspendLayout()
        Me.PanelShowDetails.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripNF2.SuspendLayout()
        Me.PanelDetails.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.PanelBills.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.FpSpreadForPrint_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpreadForPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelWait.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ColumnHeaderRenderer1.Name = "ColumnHeaderRenderer1"
        ColumnHeaderRenderer1.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        EnhancedColumnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer1.Name = "EnhancedColumnHeaderRenderer1"
        EnhancedColumnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer1.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer2.Name = "EnhancedColumnHeaderRenderer2"
        EnhancedColumnHeaderRenderer2.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer1.Name = "EnhancedRowHeaderRenderer1"
        EnhancedRowHeaderRenderer1.TextRotationAngle = 0R
        ColumnHeaderRenderer2.Name = "ColumnHeaderRenderer2"
        ColumnHeaderRenderer2.TextRotationAngle = 0R
        ColumnHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control
        ColumnHeaderRenderer5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        ColumnHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText
        ColumnHeaderRenderer5.Name = "ColumnHeaderRenderer5"
        ColumnHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No
        ColumnHeaderRenderer5.TextRotationAngle = 0R
        ColumnHeaderRenderer6.Name = "ColumnHeaderRenderer6"
        ColumnHeaderRenderer6.TextRotationAngle = 0R
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.ContextMenuStrip = Me.ContextMenuStripCustomizeToolStrip
        Me.ToolStrip2.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton12, Me.ToolStripButton13, Me.ToolStripSeparator7, Me.ToolStripButtonCloseForm, Me.ToolStripStatusLabelChecked, Me.ToolStripSeparator24, Me.ToolStripStatusLabelFound, Me.ToolStripSeparator8, Me.ToolStripButton3, Me.ToolStripSeparator26, Me.mnuPrinting2, Me.ToolStripDropDownButton1, Me.ToolStripDropDownButton2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1098, 25)
        Me.ToolStrip2.TabIndex = 116
        Me.ToolStrip2.Text = "Paid Checked"
        '
        'ContextMenuStripCustomizeToolStrip
        '
        Me.ContextMenuStripCustomizeToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomizeToolbarToolStripMenuItem, Me.ToolStripSeparator6, Me.ToolStripMenuItem12})
        Me.ContextMenuStripCustomizeToolStrip.Name = "ContextMenuStripCustomizeToolStrip"
        Me.ContextMenuStripCustomizeToolStrip.Size = New System.Drawing.Size(175, 54)
        '
        'CustomizeToolbarToolStripMenuItem
        '
        Me.CustomizeToolbarToolStripMenuItem.Image = CType(resources.GetObject("CustomizeToolbarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CustomizeToolbarToolStripMenuItem.Name = "CustomizeToolbarToolStripMenuItem"
        Me.CustomizeToolbarToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.CustomizeToolbarToolStripMenuItem.Text = "Customize Toolbar"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(171, 6)
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Image = CType(resources.GetObject("ToolStripMenuItem12.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(174, 22)
        Me.ToolStripMenuItem12.Text = "Restore"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.ToolStripButton1.Size = New System.Drawing.Size(28, 22)
        Me.ToolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton1.ToolTipText = "Autosize Spread Columns Width"
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ToolStripButton12.Size = New System.Drawing.Size(30, 22)
        Me.ToolStripButton12.ToolTipText = "Font Increase"
        Me.ToolStripButton12.Visible = False
        '
        'ToolStripButton13
        '
        Me.ToolStripButton13.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton13.Image = CType(resources.GetObject("ToolStripButton13.Image"), System.Drawing.Image)
        Me.ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton13.ToolTipText = "Font Decrease"
        Me.ToolStripButton13.Visible = False
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
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
        Me.ToolStripButtonCloseForm.ToolTipText = "Close Billing Management"
        '
        'ToolStripStatusLabelChecked
        '
        Me.ToolStripStatusLabelChecked.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripStatusLabelChecked.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripStatusLabelChecked.Name = "ToolStripStatusLabelChecked"
        Me.ToolStripStatusLabelChecked.Size = New System.Drawing.Size(89, 22)
        Me.ToolStripStatusLabelChecked.Text = "ToolStripLabel3"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripStatusLabelFound
        '
        Me.ToolStripStatusLabelFound.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripStatusLabelFound.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripStatusLabelFound.Name = "ToolStripStatusLabelFound"
        Me.ToolStripStatusLabelFound.Size = New System.Drawing.Size(89, 22)
        Me.ToolStripStatusLabelFound.Text = "ToolStripLabel2"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportAllToExcelToolStripMenuItem, Me.ExportCheckedToExcelToolStripMenuItem})
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton3.Text = "Excel"
        '
        'ExportAllToExcelToolStripMenuItem
        '
        Me.ExportAllToExcelToolStripMenuItem.Name = "ExportAllToExcelToolStripMenuItem"
        Me.ExportAllToExcelToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.ExportAllToExcelToolStripMenuItem.Text = "Export All To Excel"
        '
        'ExportCheckedToExcelToolStripMenuItem
        '
        Me.ExportCheckedToExcelToolStripMenuItem.Name = "ExportCheckedToExcelToolStripMenuItem"
        Me.ExportCheckedToExcelToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.ExportCheckedToExcelToolStripMenuItem.Text = "Export Checked To Excel"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(6, 25)
        '
        'mnuPrinting2
        '
        Me.mnuPrinting2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintCheckedSelectedNF23ToolStripMenuItem, Me.PrintPatientScheduleToolStripMenuItem, Me.PrintPatientsFileLabelToolStripMenuItem, Me.ToolStripSeparator4, Me.mnuPrintCheckedEnvelopes1, Me.ToolStripSeparator1, Me.PrintResultListToolStripMenuItem})
        Me.mnuPrinting2.Image = CType(resources.GetObject("mnuPrinting2.Image"), System.Drawing.Image)
        Me.mnuPrinting2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuPrinting2.Name = "mnuPrinting2"
        Me.mnuPrinting2.Size = New System.Drawing.Size(78, 22)
        Me.mnuPrinting2.Text = "Printing"
        Me.mnuPrinting2.ToolTipText = "Printing Tools"
        '
        'PrintCheckedSelectedNF23ToolStripMenuItem
        '
        Me.PrintCheckedSelectedNF23ToolStripMenuItem.Image = CType(resources.GetObject("PrintCheckedSelectedNF23ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintCheckedSelectedNF23ToolStripMenuItem.Name = "PrintCheckedSelectedNF23ToolStripMenuItem"
        Me.PrintCheckedSelectedNF23ToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.PrintCheckedSelectedNF23ToolStripMenuItem.Text = "Print Checked / Selected Patient's Information"
        '
        'PrintPatientScheduleToolStripMenuItem
        '
        Me.PrintPatientScheduleToolStripMenuItem.Image = CType(resources.GetObject("PrintPatientScheduleToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPatientScheduleToolStripMenuItem.Name = "PrintPatientScheduleToolStripMenuItem"
        Me.PrintPatientScheduleToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.PrintPatientScheduleToolStripMenuItem.Text = "Print Patient Schedule"
        '
        'PrintPatientsFileLabelToolStripMenuItem
        '
        Me.PrintPatientsFileLabelToolStripMenuItem.Image = CType(resources.GetObject("PrintPatientsFileLabelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPatientsFileLabelToolStripMenuItem.Name = "PrintPatientsFileLabelToolStripMenuItem"
        Me.PrintPatientsFileLabelToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.PrintPatientsFileLabelToolStripMenuItem.Text = "Print Selected Patient's File Label"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(314, 6)
        '
        'mnuPrintCheckedEnvelopes1
        '
        Me.mnuPrintCheckedEnvelopes1.Image = CType(resources.GetObject("mnuPrintCheckedEnvelopes1.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedEnvelopes1.Name = "mnuPrintCheckedEnvelopes1"
        Me.mnuPrintCheckedEnvelopes1.Size = New System.Drawing.Size(317, 22)
        Me.mnuPrintCheckedEnvelopes1.Text = "Print Checked/Selected Envelopes"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(314, 6)
        '
        'PrintResultListToolStripMenuItem
        '
        Me.PrintResultListToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuickPrintToolStripMenuItem, Me.ToolStripSeparator5, Me.mnuPrintAll1, Me.mnuPrintCheckedOnly1})
        Me.PrintResultListToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PrintResultListToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.PrintResultListToolStripMenuItem.Image = CType(resources.GetObject("PrintResultListToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintResultListToolStripMenuItem.Name = "PrintResultListToolStripMenuItem"
        Me.PrintResultListToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.PrintResultListToolStripMenuItem.Text = "Print Result List"
        '
        'QuickPrintToolStripMenuItem
        '
        Me.QuickPrintToolStripMenuItem.Name = "QuickPrintToolStripMenuItem"
        Me.QuickPrintToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.QuickPrintToolStripMenuItem.Text = "Quik Print "
        Me.QuickPrintToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(173, 6)
        Me.ToolStripSeparator5.Visible = False
        '
        'mnuPrintAll1
        '
        Me.mnuPrintAll1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuPrintAll1.Image = CType(resources.GetObject("mnuPrintAll1.Image"), System.Drawing.Image)
        Me.mnuPrintAll1.Name = "mnuPrintAll1"
        Me.mnuPrintAll1.Size = New System.Drawing.Size(176, 22)
        Me.mnuPrintAll1.Text = "Print All"
        '
        'mnuPrintCheckedOnly1
        '
        Me.mnuPrintCheckedOnly1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuPrintCheckedOnly1.Image = CType(resources.GetObject("mnuPrintCheckedOnly1.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedOnly1.Name = "mnuPrintCheckedOnly1"
        Me.mnuPrintCheckedOnly1.Size = New System.Drawing.Size(176, 22)
        Me.mnuPrintCheckedOnly1.Text = "Print Checked Only"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailAllRecordsToolStripMenuItem, Me.EmailCheckedOnlyToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripDropDownButton1.Text = "Email"
        '
        'EmailAllRecordsToolStripMenuItem
        '
        Me.EmailAllRecordsToolStripMenuItem.Name = "EmailAllRecordsToolStripMenuItem"
        Me.EmailAllRecordsToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.EmailAllRecordsToolStripMenuItem.Text = "Email Search Result All Records"
        '
        'EmailCheckedOnlyToolStripMenuItem
        '
        Me.EmailCheckedOnlyToolStripMenuItem.Name = "EmailCheckedOnlyToolStripMenuItem"
        Me.EmailCheckedOnlyToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.EmailCheckedOnlyToolStripMenuItem.Text = "Email Search Result Checked Only"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem3, Me.ToolStripSeparator2, Me.ToolStripMenuItem2, Me.FindDuplicatePatientsToolStripMenuItem, Me.ShowAccidentRelatedPatientsToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripDropDownButton2.Text = "Tools"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(280, 22)
        Me.ToolStripMenuItem1.Text = "Check All"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(280, 22)
        Me.ToolStripMenuItem3.Text = "Check None"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(277, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(280, 22)
        Me.ToolStripMenuItem2.Text = "Show Patient's Information"
        '
        'FindDuplicatePatientsToolStripMenuItem
        '
        Me.FindDuplicatePatientsToolStripMenuItem.Image = CType(resources.GetObject("FindDuplicatePatientsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FindDuplicatePatientsToolStripMenuItem.Name = "FindDuplicatePatientsToolStripMenuItem"
        Me.FindDuplicatePatientsToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.FindDuplicatePatientsToolStripMenuItem.Text = "Find Duplicate Patients"
        '
        'ShowAccidentRelatedPatientsToolStripMenuItem
        '
        Me.ShowAccidentRelatedPatientsToolStripMenuItem.Image = CType(resources.GetObject("ShowAccidentRelatedPatientsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ShowAccidentRelatedPatientsToolStripMenuItem.Name = "ShowAccidentRelatedPatientsToolStripMenuItem"
        Me.ShowAccidentRelatedPatientsToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.ShowAccidentRelatedPatientsToolStripMenuItem.Text = "Accident Related Patients Maintenance"
        '
        'PanelShowDetails
        '
        Me.PanelShowDetails.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelShowDetails.Controls.Add(Me.PictureBox1)
        Me.PanelShowDetails.Controls.Add(Me.PictureBox2)
        Me.PanelShowDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PanelShowDetails.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelShowDetails.Location = New System.Drawing.Point(760, 112)
        Me.PanelShowDetails.Name = "PanelShowDetails"
        Me.PanelShowDetails.Size = New System.Drawing.Size(16, 519)
        Me.PanelShowDetails.TabIndex = 124
        Me.ToolTip1.SetToolTip(Me.PanelShowDetails, "Show Patient Details")
        Me.PanelShowDetails.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(9, 86)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Enabled = False
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 13)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Tag = "1"
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Close Patient Details")
        '
        'ButtonDetails
        '
        Me.ButtonDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonDetails.Image = CType(resources.GetObject("ButtonDetails.Image"), System.Drawing.Image)
        Me.ButtonDetails.Location = New System.Drawing.Point(296, 1)
        Me.ButtonDetails.Name = "ButtonDetails"
        Me.ButtonDetails.Size = New System.Drawing.Size(20, 13)
        Me.ButtonDetails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.ButtonDetails.TabIndex = 33
        Me.ButtonDetails.TabStop = False
        Me.ButtonDetails.Tag = "1"
        Me.ToolTip1.SetToolTip(Me.ButtonDetails, "Hide Patient Details")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "SORT1")
        Me.ImageList1.Images.SetKeyName(1, "SORT2")
        Me.ImageList1.Images.SetKeyName(2, "SORT0")
        Me.ImageList1.Images.SetKeyName(3, "BallGreen9.bmp")
        Me.ImageList1.Images.SetKeyName(4, "BallRed9.bmp")
        '
        'ListViewPatients
        '
        Me.ListViewPatients.AllowColumnReorder = True
        Me.ListViewPatients.CheckBoxes = True
        Me.ListViewPatients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PatientNo, Me.PatientName, Me.ColumnHeader2, Me.DOA, Me.CaseType, Me.STATUS, Me.Insurance, Me.PolicyNo, Me.ClaimNo, Me.AdjusterName, Me.Attorney, Me.NF2Date, Me.ColumnHeader6})
        Me.ListViewPatients.ContextMenuStrip = Me.ContextMenuStripNF2
        Me.ListViewPatients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewPatients.FullRowSelect = True
        Me.ListViewPatients.GridLines = True
        Me.ListViewPatients.HideSelection = False
        Me.ListViewPatients.LabelWrap = False
        Me.ListViewPatients.LargeImageList = Me.ImageListTray
        Me.ListViewPatients.Location = New System.Drawing.Point(0, 112)
        Me.ListViewPatients.Margin = New System.Windows.Forms.Padding(0)
        Me.ListViewPatients.MultiSelect = False
        Me.ListViewPatients.Name = "ListViewPatients"
        Me.ListViewPatients.ShowGroups = False
        Me.ListViewPatients.ShowItemToolTips = True
        Me.ListViewPatients.Size = New System.Drawing.Size(760, 486)
        Me.ListViewPatients.SmallImageList = Me.ImageListTray
        Me.ListViewPatients.TabIndex = 121
        Me.ListViewPatients.UseCompatibleStateImageBehavior = False
        Me.ListViewPatients.View = System.Windows.Forms.View.Details
        '
        'PatientNo
        '
        Me.PatientNo.Text = "Patient #"
        Me.PatientNo.Width = 93
        '
        'PatientName
        '
        Me.PatientName.Text = "Name"
        Me.PatientName.Width = 102
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "SSN"
        '
        'DOA
        '
        Me.DOA.Text = "DOA"
        Me.DOA.Width = 107
        '
        'CaseType
        '
        Me.CaseType.Text = "Type"
        Me.CaseType.Width = 94
        '
        'STATUS
        '
        Me.STATUS.Text = "Status"
        Me.STATUS.Width = 122
        '
        'Insurance
        '
        Me.Insurance.Text = "Insurance"
        Me.Insurance.Width = 115
        '
        'PolicyNo
        '
        Me.PolicyNo.Text = "Policy #"
        Me.PolicyNo.Width = 91
        '
        'ClaimNo
        '
        Me.ClaimNo.Text = "Claim #"
        Me.ClaimNo.Width = 121
        '
        'AdjusterName
        '
        Me.AdjusterName.Text = "Adjuster Name"
        Me.AdjusterName.Width = 179
        '
        'Attorney
        '
        Me.Attorney.Text = "Attorney"
        '
        'NF2Date
        '
        Me.NF2Date.Text = "NF2Date"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Initial DT"
        '
        'ContextMenuStripNF2
        '
        Me.ContextMenuStripNF2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.SelectNoneToolStripMenuItem, Me.ToolStripSeparator28, Me.mnuShowSelectedPatientInfo1, Me.ToolStripSeparator3, Me.mnuPrinting1, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6})
        Me.ContextMenuStripNF2.Name = "ContextMenuStrip1"
        Me.ContextMenuStripNF2.Size = New System.Drawing.Size(254, 148)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Image = CType(resources.GetObject("SelectAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.SelectAllToolStripMenuItem.Text = "Check All"
        '
        'SelectNoneToolStripMenuItem
        '
        Me.SelectNoneToolStripMenuItem.Name = "SelectNoneToolStripMenuItem"
        Me.SelectNoneToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.SelectNoneToolStripMenuItem.Text = "Check None"
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(250, 6)
        '
        'mnuShowSelectedPatientInfo1
        '
        Me.mnuShowSelectedPatientInfo1.Image = CType(resources.GetObject("mnuShowSelectedPatientInfo1.Image"), System.Drawing.Image)
        Me.mnuShowSelectedPatientInfo1.Name = "mnuShowSelectedPatientInfo1"
        Me.mnuShowSelectedPatientInfo1.Size = New System.Drawing.Size(253, 22)
        Me.mnuShowSelectedPatientInfo1.Text = "Show Patient's Information"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(250, 6)
        '
        'mnuPrinting1
        '
        Me.mnuPrinting1.Image = CType(resources.GetObject("mnuPrinting1.Image"), System.Drawing.Image)
        Me.mnuPrinting1.Name = "mnuPrinting1"
        Me.mnuPrinting1.Size = New System.Drawing.Size(253, 22)
        Me.mnuPrinting1.Text = "Print Selected Patient Information"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Image = CType(resources.GetObject("ToolStripMenuItem5.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(253, 22)
        Me.ToolStripMenuItem5.Text = "Print Patient Schedule"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Image = CType(resources.GetObject("ToolStripMenuItem6.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(253, 22)
        Me.ToolStripMenuItem6.Text = "Print Checked/Selected Envelopes"
        '
        'ImageListTray
        '
        Me.ImageListTray.ImageStream = CType(resources.GetObject("ImageListTray.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTray.TransparentColor = System.Drawing.Color.White
        Me.ImageListTray.Images.SetKeyName(0, "Ball_greenNF2.png")
        Me.ImageListTray.Images.SetKeyName(1, "Ball_RedNF2.png")
        Me.ImageListTray.Images.SetKeyName(2, "SORT1")
        Me.ImageListTray.Images.SetKeyName(3, "SORT2")
        Me.ImageListTray.Images.SetKeyName(4, "SORT0")
        '
        'PanelDetails
        '
        Me.PanelDetails.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelDetails.Controls.Add(Me.Panel1)
        Me.PanelDetails.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelDetails.Location = New System.Drawing.Point(776, 112)
        Me.PanelDetails.Name = "PanelDetails"
        Me.PanelDetails.Size = New System.Drawing.Size(322, 519)
        Me.PanelDetails.TabIndex = 123
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(322, 519)
        Me.Panel1.TabIndex = 32
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel11, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel9, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel8, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(322, 519)
        Me.TableLayoutPanel1.TabIndex = 36
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.ListViewPatientsRelated)
        Me.Panel11.Controls.Add(Me.Panel12)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(3, 433)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(316, 83)
        Me.Panel11.TabIndex = 38
        '
        'ListViewPatientsRelated
        '
        Me.ListViewPatientsRelated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewPatientsRelated.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader45, Me.ColumnHeader46})
        Me.ListViewPatientsRelated.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewPatientsRelated.FullRowSelect = True
        Me.ListViewPatientsRelated.GridLines = True
        Me.ListViewPatientsRelated.LargeImageList = Me.ImageList2
        Me.ListViewPatientsRelated.Location = New System.Drawing.Point(0, 13)
        Me.ListViewPatientsRelated.MultiSelect = False
        Me.ListViewPatientsRelated.Name = "ListViewPatientsRelated"
        Me.ListViewPatientsRelated.Size = New System.Drawing.Size(316, 70)
        Me.ListViewPatientsRelated.SmallImageList = Me.ImageList2
        Me.ListViewPatientsRelated.TabIndex = 286
        Me.ListViewPatientsRelated.UseCompatibleStateImageBehavior = False
        Me.ListViewPatientsRelated.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader45
        '
        Me.ColumnHeader45.Text = "ID"
        Me.ColumnHeader45.Width = 45
        '
        'ColumnHeader46
        '
        Me.ColumnHeader46.Text = "Patient Name"
        Me.ColumnHeader46.Width = 244
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "UserBlue.png")
        Me.ImageList2.Images.SetKeyName(1, "UserOrange.png")
        Me.ImageList2.Images.SetKeyName(2, "UserRed.png")
        Me.ImageList2.Images.SetKeyName(3, "UserRed.png")
        Me.ImageList2.Images.SetKeyName(4, "UserRed.png")
        Me.ImageList2.Images.SetKeyName(5, "SORT1")
        Me.ImageList2.Images.SetKeyName(6, "SORT2")
        Me.ImageList2.Images.SetKeyName(7, "SORT0")
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.Transparent
        Me.Panel12.Controls.Add(Me.Label3)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(316, 13)
        Me.Panel12.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(164, 14)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "ACCIDENT RELATED PATIENTS"
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.ListViewRequests)
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(3, 347)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(316, 80)
        Me.Panel9.TabIndex = 37
        '
        'ListViewRequests
        '
        Me.ListViewRequests.BackColor = System.Drawing.Color.White
        Me.ListViewRequests.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader12, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.ListViewRequests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewRequests.FullRowSelect = True
        Me.ListViewRequests.GridLines = True
        Me.ListViewRequests.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewRequests.Location = New System.Drawing.Point(0, 13)
        Me.ListViewRequests.MultiSelect = False
        Me.ListViewRequests.Name = "ListViewRequests"
        Me.ListViewRequests.Size = New System.Drawing.Size(316, 67)
        Me.ListViewRequests.TabIndex = 297
        Me.ListViewRequests.UseCompatibleStateImageBehavior = False
        Me.ListViewRequests.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Bill #"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Date"
        Me.ColumnHeader9.Width = 75
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Status"
        Me.ColumnHeader10.Width = 57
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Request"
        Me.ColumnHeader11.Width = 97
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Transparent
        Me.Panel10.Controls.Add(Me.Label11)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(316, 13)
        Me.Panel10.TabIndex = 38
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 14)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "PATIENT REQUESTS"
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.TreeViewBills)
        Me.Panel8.Controls.Add(Me.PanelBills)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(3, 261)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(316, 80)
        Me.Panel8.TabIndex = 36
        '
        'TreeViewBills
        '
        Me.TreeViewBills.BackColor = System.Drawing.Color.White
        Me.TreeViewBills.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewBills.FullRowSelect = True
        Me.TreeViewBills.HideSelection = False
        Me.TreeViewBills.ImageKey = "2"
        Me.TreeViewBills.Indent = 12
        Me.TreeViewBills.Location = New System.Drawing.Point(0, 13)
        Me.TreeViewBills.Name = "TreeViewBills"
        Me.TreeViewBills.ShowNodeToolTips = True
        Me.TreeViewBills.Size = New System.Drawing.Size(316, 67)
        Me.TreeViewBills.TabIndex = 37
        '
        'PanelBills
        '
        Me.PanelBills.BackColor = System.Drawing.Color.Transparent
        Me.PanelBills.Controls.Add(Me.Label6)
        Me.PanelBills.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBills.Location = New System.Drawing.Point(0, 0)
        Me.PanelBills.Name = "PanelBills"
        Me.PanelBills.Size = New System.Drawing.Size(316, 13)
        Me.PanelBills.TabIndex = 36
        Me.PanelBills.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 14)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "PATIENT BILLS"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.ListViewServices)
        Me.Panel7.Controls.Add(Me.Panel2)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 175)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(316, 80)
        Me.Panel7.TabIndex = 35
        '
        'ListViewServices
        '
        Me.ListViewServices.BackColor = System.Drawing.Color.White
        Me.ListViewServices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListViewServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewServices.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewServices.FullRowSelect = True
        Me.ListViewServices.GridLines = True
        Me.ListViewServices.LabelWrap = False
        Me.ListViewServices.Location = New System.Drawing.Point(0, 13)
        Me.ListViewServices.MultiSelect = False
        Me.ListViewServices.Name = "ListViewServices"
        Me.ListViewServices.ShowItemToolTips = True
        Me.ListViewServices.Size = New System.Drawing.Size(316, 67)
        Me.ListViewServices.TabIndex = 35
        Me.ListViewServices.UseCompatibleStateImageBehavior = False
        Me.ListViewServices.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Type"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Procedure"
        Me.ColumnHeader5.Width = 107
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(316, 13)
        Me.Panel2.TabIndex = 34
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 14)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "PATIENT SERVICES"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.ListViewProcedures)
        Me.Panel6.Controls.Add(Me.Panel3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 89)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(316, 80)
        Me.Panel6.TabIndex = 34
        '
        'ListViewProcedures
        '
        Me.ListViewProcedures.BackColor = System.Drawing.Color.White
        Me.ListViewProcedures.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.Type, Me.ColumnHeader20})
        Me.ListViewProcedures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewProcedures.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewProcedures.FullRowSelect = True
        Me.ListViewProcedures.GridLines = True
        Me.ListViewProcedures.LabelWrap = False
        Me.ListViewProcedures.Location = New System.Drawing.Point(0, 16)
        Me.ListViewProcedures.MultiSelect = False
        Me.ListViewProcedures.Name = "ListViewProcedures"
        Me.ListViewProcedures.ShowItemToolTips = True
        Me.ListViewProcedures.Size = New System.Drawing.Size(316, 64)
        Me.ListViewProcedures.TabIndex = 34
        Me.ListViewProcedures.UseCompatibleStateImageBehavior = False
        Me.ListViewProcedures.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Procedure Date"
        Me.ColumnHeader1.Width = 91
        '
        'Type
        '
        Me.Type.Text = "Type"
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Procedure"
        Me.ColumnHeader20.Width = 137
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(316, 16)
        Me.Panel3.TabIndex = 33
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(123, 14)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "PATIENT PROCEDURES"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.ListViewSchedule)
        Me.Panel4.Controls.Add(Me.Panel13)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(316, 80)
        Me.Panel4.TabIndex = 39
        '
        'ListViewSchedule
        '
        Me.ListViewSchedule.BackColor = System.Drawing.Color.White
        Me.ListViewSchedule.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader14})
        Me.ListViewSchedule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewSchedule.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewSchedule.FullRowSelect = True
        Me.ListViewSchedule.GridLines = True
        Me.ListViewSchedule.LabelWrap = False
        Me.ListViewSchedule.Location = New System.Drawing.Point(0, 16)
        Me.ListViewSchedule.MultiSelect = False
        Me.ListViewSchedule.Name = "ListViewSchedule"
        Me.ListViewSchedule.ShowItemToolTips = True
        Me.ListViewSchedule.Size = New System.Drawing.Size(316, 64)
        Me.ListViewSchedule.TabIndex = 34
        Me.ListViewSchedule.UseCompatibleStateImageBehavior = False
        Me.ListViewSchedule.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Date"
        Me.ColumnHeader3.Width = 91
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Procedure"
        Me.ColumnHeader14.Width = 192
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Transparent
        Me.Panel13.Controls.Add(Me.ButtonDetails)
        Me.Panel13.Controls.Add(Me.Label19)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(0, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(316, 16)
        Me.Panel13.TabIndex = 33
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label19.Location = New System.Drawing.Point(0, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(108, 14)
        Me.Label19.TabIndex = 15
        Me.Label19.Text = "PATIENT SCHEDULE"
        '
        'ImageListCurrentBills
        '
        Me.ImageListCurrentBills.ImageStream = CType(resources.GetObject("ImageListCurrentBills.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListCurrentBills.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListCurrentBills.Images.SetKeyName(0, "3")
        Me.ImageListCurrentBills.Images.SetKeyName(1, "4")
        Me.ImageListCurrentBills.Images.SetKeyName(2, "5")
        Me.ImageListCurrentBills.Images.SetKeyName(3, "6")
        Me.ImageListCurrentBills.Images.SetKeyName(4, "7")
        Me.ImageListCurrentBills.Images.SetKeyName(5, "31")
        Me.ImageListCurrentBills.Images.SetKeyName(6, "41")
        Me.ImageListCurrentBills.Images.SetKeyName(7, "51")
        Me.ImageListCurrentBills.Images.SetKeyName(8, "61")
        Me.ImageListCurrentBills.Images.SetKeyName(9, "71")
        Me.ImageListCurrentBills.Images.SetKeyName(10, "diag")
        Me.ImageListCurrentBills.Images.SetKeyName(11, "8")
        Me.ImageListCurrentBills.Images.SetKeyName(12, "81")
        Me.ImageListCurrentBills.Images.SetKeyName(13, "2")
        Me.ImageListCurrentBills.Images.SetKeyName(14, "21")
        Me.ImageListCurrentBills.Images.SetKeyName(15, "1")
        Me.ImageListCurrentBills.Images.SetKeyName(16, "11")
        Me.ImageListCurrentBills.Images.SetKeyName(17, "PROC")
        Me.ImageListCurrentBills.Images.SetKeyName(18, "DIAG")
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(144, 26)
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(143, 22)
        Me.ToolStripMenuItem4.Text = "Show Patient"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoScroll = True
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 10
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtPACSAltNumber, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label17, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxSearch, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtBillNumber, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBoxFilter, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtPatientAttorney, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.cboTreatingProvider, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.cboBillingProvider, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBoxSearchCaseType, 4, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBoxSearchCaseStatus, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label14, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DateTimePickerDOATo, 5, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.DateTimePickerDOAFrom, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonClear, 8, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Button1, 9, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.DateTimePickerTo, 7, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.DateTimePickerFrom, 7, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 7, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.DateTimePickerServicesFrom, 6, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.DateTimePickerServicesTo, 6, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 6, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label90, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 4, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.Padding = New System.Windows.Forms.Padding(1, 1, 1, 6)
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1098, 87)
        Me.TableLayoutPanel2.TabIndex = 125
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(124, 41)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(97, 13)
        Me.Label21.TabIndex = 328
        Me.Label21.Text = "PACS Accession #"
        '
        'txtPACSAltNumber
        '
        Me.txtPACSAltNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtPACSAltNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPACSAltNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPACSAltNumber.Location = New System.Drawing.Point(124, 57)
        Me.txtPACSAltNumber.MaxLength = 10
        Me.txtPACSAltNumber.Name = "txtPACSAltNumber"
        Me.txtPACSAltNumber.Size = New System.Drawing.Size(115, 20)
        Me.txtPACSAltNumber.TabIndex = 327
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(789, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 13)
        Me.Label17.TabIndex = 325
        Me.Label17.Text = "Services From"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(890, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 321
        Me.Label8.Text = "Initial DT From"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(124, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 307
        Me.Label10.Text = "Filter"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(4, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Patient Name /  ##"
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.TextBoxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxSearch.Location = New System.Drawing.Point(4, 17)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(114, 20)
        Me.TextBoxSearch.TabIndex = 256
        '
        'txtBillNumber
        '
        Me.txtBillNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtBillNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtBillNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBillNumber.Location = New System.Drawing.Point(4, 57)
        Me.txtBillNumber.MaxLength = 10
        Me.txtBillNumber.Name = "txtBillNumber"
        Me.txtBillNumber.Size = New System.Drawing.Size(114, 20)
        Me.txtBillNumber.TabIndex = 257
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(4, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 255
        Me.Label5.Text = "Claim #/Policy #"
        '
        'ComboBoxFilter
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.ComboBoxFilter, 2)
        Me.ComboBoxFilter.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ComboBoxFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFilter.DropDownWidth = 350
        Me.ComboBoxFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxFilter.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxFilter.FormattingEnabled = True
        Me.ComboBoxFilter.Location = New System.Drawing.Point(124, 17)
        Me.ComboBoxFilter.Name = "ComboBoxFilter"
        Me.ComboBoxFilter.Size = New System.Drawing.Size(236, 21)
        Me.ComboBoxFilter.TabIndex = 285
        '
        'txtPatientAttorney
        '
        Me.txtPatientAttorney.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtPatientAttorney.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPatientAttorney.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPatientAttorney.Location = New System.Drawing.Point(245, 57)
        Me.txtPatientAttorney.Name = "txtPatientAttorney"
        Me.txtPatientAttorney.Size = New System.Drawing.Size(115, 20)
        Me.txtPatientAttorney.TabIndex = 295
        '
        'cboTreatingProvider
        '
        Me.cboTreatingProvider.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTreatingProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTreatingProvider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTreatingProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTreatingProvider.ForeColor = System.Drawing.Color.Black
        Me.cboTreatingProvider.FormattingEnabled = True
        Me.cboTreatingProvider.Location = New System.Drawing.Point(366, 57)
        Me.cboTreatingProvider.Name = "cboTreatingProvider"
        Me.cboTreatingProvider.Size = New System.Drawing.Size(236, 21)
        Me.cboTreatingProvider.TabIndex = 306
        '
        'cboBillingProvider
        '
        Me.cboBillingProvider.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboBillingProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingProvider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillingProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBillingProvider.ForeColor = System.Drawing.Color.Black
        Me.cboBillingProvider.FormattingEnabled = True
        Me.cboBillingProvider.Location = New System.Drawing.Point(366, 17)
        Me.cboBillingProvider.Name = "cboBillingProvider"
        Me.cboBillingProvider.Size = New System.Drawing.Size(236, 21)
        Me.cboBillingProvider.TabIndex = 305
        '
        'ComboBoxSearchCaseType
        '
        Me.ComboBoxSearchCaseType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxSearchCaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSearchCaseType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxSearchCaseType.FormattingEnabled = True
        Me.ComboBoxSearchCaseType.Location = New System.Drawing.Point(608, 57)
        Me.ComboBoxSearchCaseType.Name = "ComboBoxSearchCaseType"
        Me.ComboBoxSearchCaseType.Size = New System.Drawing.Size(74, 21)
        Me.ComboBoxSearchCaseType.TabIndex = 304
        '
        'ComboBoxSearchCaseStatus
        '
        Me.ComboBoxSearchCaseStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxSearchCaseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSearchCaseStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxSearchCaseStatus.FormattingEnabled = True
        Me.ComboBoxSearchCaseStatus.Location = New System.Drawing.Point(608, 17)
        Me.ComboBoxSearchCaseStatus.Name = "ComboBoxSearchCaseStatus"
        Me.ComboBoxSearchCaseStatus.Size = New System.Drawing.Size(74, 21)
        Me.ComboBoxSearchCaseStatus.TabIndex = 303
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(245, 41)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 13)
        Me.Label12.TabIndex = 308
        Me.Label12.Text = "Patient Attorney"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(366, 41)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 13)
        Me.Label15.TabIndex = 312
        Me.Label15.Text = "Treating Provider"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(366, 1)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 13)
        Me.Label14.TabIndex = 311
        Me.Label14.Text = "Billing Provider"
        '
        'DateTimePickerDOATo
        '
        Me.DateTimePickerDOATo.Checked = False
        Me.DateTimePickerDOATo.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePickerDOATo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePickerDOATo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerDOATo.Location = New System.Drawing.Point(688, 57)
        Me.DateTimePickerDOATo.Name = "DateTimePickerDOATo"
        Me.DateTimePickerDOATo.ShowCheckBox = True
        Me.DateTimePickerDOATo.Size = New System.Drawing.Size(95, 20)
        Me.DateTimePickerDOATo.TabIndex = 314
        '
        'DateTimePickerDOAFrom
        '
        Me.DateTimePickerDOAFrom.Checked = False
        Me.DateTimePickerDOAFrom.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePickerDOAFrom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePickerDOAFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerDOAFrom.Location = New System.Drawing.Point(688, 17)
        Me.DateTimePickerDOAFrom.Name = "DateTimePickerDOAFrom"
        Me.DateTimePickerDOAFrom.ShowCheckBox = True
        Me.DateTimePickerDOAFrom.Size = New System.Drawing.Size(95, 20)
        Me.DateTimePickerDOAFrom.TabIndex = 313
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(688, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 316
        Me.Label9.Text = "DOA To"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(688, 1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 315
        Me.Label13.Text = "DOA From"
        '
        'ButtonClear
        '
        Me.ButtonClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClear.Image = CType(resources.GetObject("ButtonClear.Image"), System.Drawing.Image)
        Me.ButtonClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonClear.Location = New System.Drawing.Point(991, 17)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Padding = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.TableLayoutPanel2.SetRowSpan(Me.ButtonClear, 3)
        Me.ButtonClear.Size = New System.Drawing.Size(35, 37)
        Me.ButtonClear.TabIndex = 317
        Me.ButtonClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(1032, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.TableLayoutPanel2.SetRowSpan(Me.Button1, 3)
        Me.Button1.Size = New System.Drawing.Size(62, 60)
        Me.Button1.TabIndex = 318
        Me.Button1.Text = "Find"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.Checked = False
        Me.DateTimePickerTo.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePickerTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTo.Location = New System.Drawing.Point(890, 57)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.ShowCheckBox = True
        Me.DateTimePickerTo.Size = New System.Drawing.Size(95, 20)
        Me.DateTimePickerTo.TabIndex = 320
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.Checked = False
        Me.DateTimePickerFrom.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePickerFrom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(890, 17)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.ShowCheckBox = True
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(95, 20)
        Me.DateTimePickerFrom.TabIndex = 319
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(890, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 322
        Me.Label7.Text = "Initial DT To"
        '
        'DateTimePickerServicesFrom
        '
        Me.DateTimePickerServicesFrom.Checked = False
        Me.DateTimePickerServicesFrom.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePickerServicesFrom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePickerServicesFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerServicesFrom.Location = New System.Drawing.Point(789, 17)
        Me.DateTimePickerServicesFrom.Name = "DateTimePickerServicesFrom"
        Me.DateTimePickerServicesFrom.ShowCheckBox = True
        Me.DateTimePickerServicesFrom.Size = New System.Drawing.Size(95, 20)
        Me.DateTimePickerServicesFrom.TabIndex = 323
        '
        'DateTimePickerServicesTo
        '
        Me.DateTimePickerServicesTo.Checked = False
        Me.DateTimePickerServicesTo.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePickerServicesTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePickerServicesTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerServicesTo.Location = New System.Drawing.Point(789, 57)
        Me.DateTimePickerServicesTo.Name = "DateTimePickerServicesTo"
        Me.DateTimePickerServicesTo.ShowCheckBox = True
        Me.DateTimePickerServicesTo.Size = New System.Drawing.Size(95, 20)
        Me.DateTimePickerServicesTo.TabIndex = 324
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(789, 41)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 13)
        Me.Label18.TabIndex = 326
        Me.Label18.Text = "Services To"
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.BackColor = System.Drawing.Color.Transparent
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.Transparent
        Me.Label90.Location = New System.Drawing.Point(608, 41)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(58, 13)
        Me.Label90.TabIndex = 310
        Me.Label90.Text = "Case Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(608, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 309
        Me.Label2.Text = "Case Status"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'FpSpreadForPrint_Sheet1
        '
        Me.FpSpreadForPrint_Sheet1.Reset()
        Me.FpSpreadForPrint_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpreadForPrint_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpreadForPrint_Sheet1.ColumnCount = 10
        Me.FpSpreadForPrint_Sheet1.RowCount = 11
        Me.FpSpreadForPrint_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Patient #"
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Name"
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.[Auto]
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.FpSpreadForPrint_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.[Auto]
        TextCellType1.Multiline = True
        Me.FpSpreadForPrint_Sheet1.Columns.Get(0).CellType = TextCellType1
        Me.FpSpreadForPrint_Sheet1.Columns.Get(0).Label = "Patient #"
        Me.FpSpreadForPrint_Sheet1.Columns.Get(0).Locked = False
        TextCellType2.Multiline = True
        Me.FpSpreadForPrint_Sheet1.Columns.Get(1).CellType = TextCellType2
        Me.FpSpreadForPrint_Sheet1.Columns.Get(1).Label = "Name"
        Me.FpSpreadForPrint_Sheet1.Columns.Get(1).Locked = True
        TextCellType3.Multiline = True
        Me.FpSpreadForPrint_Sheet1.Columns.Get(2).CellType = TextCellType3
        Me.FpSpreadForPrint_Sheet1.Columns.Get(2).Locked = True
        TextCellType4.Multiline = True
        Me.FpSpreadForPrint_Sheet1.Columns.Get(3).CellType = TextCellType4
        Me.FpSpreadForPrint_Sheet1.Columns.Get(3).Locked = True
        TextCellType5.Multiline = True
        Me.FpSpreadForPrint_Sheet1.Columns.Get(4).CellType = TextCellType5
        Me.FpSpreadForPrint_Sheet1.Columns.Get(4).Locked = True
        TextCellType6.Multiline = True
        Me.FpSpreadForPrint_Sheet1.Columns.Get(5).CellType = TextCellType6
        Me.FpSpreadForPrint_Sheet1.Columns.Get(5).Locked = True
        TextCellType7.Multiline = True
        Me.FpSpreadForPrint_Sheet1.Columns.Get(6).CellType = TextCellType7
        Me.FpSpreadForPrint_Sheet1.Columns.Get(6).Locked = True
        TextCellType8.Multiline = True
        Me.FpSpreadForPrint_Sheet1.Columns.Get(7).CellType = TextCellType8
        Me.FpSpreadForPrint_Sheet1.Columns.Get(7).Locked = True
        TextCellType9.Multiline = True
        Me.FpSpreadForPrint_Sheet1.Columns.Get(8).CellType = TextCellType9
        Me.FpSpreadForPrint_Sheet1.Columns.Get(8).Locked = True
        TextCellType10.Multiline = True
        Me.FpSpreadForPrint_Sheet1.Columns.Get(9).CellType = TextCellType10
        Me.FpSpreadForPrint_Sheet1.Columns.Get(9).Locked = True
        Me.FpSpreadForPrint_Sheet1.GroupBarBackColor = System.Drawing.Color.LightSteelBlue
        Me.FpSpreadForPrint_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Me.FpSpreadForPrint_Sheet1.PrintInfo.BestFitCols = True
        Me.FpSpreadForPrint_Sheet1.PrintInfo.BestFitRows = True
        Me.FpSpreadForPrint_Sheet1.PrintInfo.Footer = ""
        Me.FpSpreadForPrint_Sheet1.PrintInfo.Header = ""
        Me.FpSpreadForPrint_Sheet1.PrintInfo.JobName = ""
        Me.FpSpreadForPrint_Sheet1.PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
        Me.FpSpreadForPrint_Sheet1.PrintInfo.Printer = ""
        Me.FpSpreadForPrint_Sheet1.PrintInfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Me.FpSpreadForPrint_Sheet1.PrintInfo.ShowPrintDialog = True
        Me.FpSpreadForPrint_Sheet1.PrintInfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
        Me.FpSpreadForPrint_Sheet1.PrintInfo.ShowShadows = False
        Me.FpSpreadForPrint_Sheet1.PrintInfo.SmartPrintRules = CType(resources.GetObject("resource.SmartPrintRules"), FarPoint.Win.Spread.SmartPrintRulesCollection)
        Me.FpSpreadForPrint_Sheet1.PrintInfo.UseSmartPrint = True
        Me.FpSpreadForPrint_Sheet1.Protect = False
        Me.FpSpreadForPrint_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpreadForPrint_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.[Auto]
        Me.FpSpreadForPrint_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadForPrint_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.FpSpreadForPrint_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.[Auto]
        Me.FpSpreadForPrint_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.[Single]
        Me.FpSpreadForPrint_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row
        Me.FpSpreadForPrint_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpreadForPrint_Sheet1.SheetCornerStyle.Parent = "HeaderDefault"
        Me.FpSpreadForPrint_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'FpSpreadForPrint
        '
        Me.FpSpreadForPrint.AccessibleDescription = "FpSpreadResults, Sheet1, Row 0, Column 0, "
        Me.FpSpreadForPrint.AllowUserZoom = False
        Me.FpSpreadForPrint.BackColor = System.Drawing.Color.Transparent
        Me.FpSpreadForPrint.BackgroundImage = CType(resources.GetObject("FpSpreadForPrint.BackgroundImage"), System.Drawing.Image)
        Me.FpSpreadForPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.FpSpreadForPrint.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FpSpreadForPrint.CausesValidation = False
        Me.FpSpreadForPrint.CellNoteIndicatorVisible = False
        Me.FpSpreadForPrint.ClipboardOptions = FarPoint.Win.Spread.ClipboardOptions.NoHeaders
        Me.FpSpreadForPrint.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpreadForPrint.EnableCrossSheetReference = False
        Me.FpSpreadForPrint.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.FpSpreadForPrint.Location = New System.Drawing.Point(309, 269)
        Me.FpSpreadForPrint.MoveActiveOnFocus = False
        Me.FpSpreadForPrint.Name = "FpSpreadForPrint"
        NamedStyle1.BackColor = System.Drawing.SystemColors.Control
        NamedStyle1.CellType = EmptyCellType1
        NamedStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle1.Locked = False
        NamedStyle1.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle1.Renderer = EmptyCellType1
        NamedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle2.BackColor = System.Drawing.SystemColors.Control
        NamedStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle2.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle2.Renderer = ColumnHeaderRenderer6
        NamedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle3.BackColor = System.Drawing.SystemColors.Window
        NamedStyle3.CellType = GeneralCellType1
        NamedStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle3.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle3.Renderer = GeneralCellType1
        Me.FpSpreadForPrint.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1, NamedStyle2, NamedStyle3})
        Me.FpSpreadForPrint.RetainSelectionBlock = False
        Me.FpSpreadForPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpreadForPrint.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.FpSpreadForPrint.ScrollBarMaxAlign = False
        Me.FpSpreadForPrint.ScrollBarShowMax = False
        Me.FpSpreadForPrint.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None
        Me.FpSpreadForPrint.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpreadForPrint_Sheet1})
        Me.FpSpreadForPrint.Size = New System.Drawing.Size(379, 130)
        Me.FpSpreadForPrint.SuspendAnimations = True
        Me.FpSpreadForPrint.TabIndex = 126
        Me.FpSpreadForPrint.TabStop = False
        Me.FpSpreadForPrint.TabStrip.ButtonPolicy = FarPoint.Win.Spread.TabStripButtonPolicy.Never
        Me.FpSpreadForPrint.TabStripInsertTab = False
        Me.FpSpreadForPrint.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never
        Me.FpSpreadForPrint.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpreadForPrint.VerticalScrollBar.Name = ""
        Me.FpSpreadForPrint.VerticalScrollBar.Renderer = Nothing
        Me.FpSpreadForPrint.VerticalScrollBar.TabIndex = 1
        Me.FpSpreadForPrint.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.FpSpreadForPrint.Visible = False
        Me.FpSpreadForPrint.VisualStyles = FarPoint.Win.VisualStyles.Off
        '
        'PanelWait
        '
        Me.PanelWait.BackColor = System.Drawing.Color.White
        Me.PanelWait.BackgroundImage = CType(resources.GetObject("PanelWait.BackgroundImage"), System.Drawing.Image)
        Me.PanelWait.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PanelWait.Controls.Add(Me.Label20)
        Me.PanelWait.Controls.Add(Me.PictureBox3)
        Me.PanelWait.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelWait.Location = New System.Drawing.Point(0, 598)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(760, 33)
        Me.PanelWait.TabIndex = 127
        Me.PanelWait.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(31, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(177, 15)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Print in progress. Please wait..."
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'frmPatientAttendancy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1098, 631)
        Me.Controls.Add(Me.FpSpreadForPrint)
        Me.Controls.Add(Me.ListViewPatients)
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.PanelShowDetails)
        Me.Controls.Add(Me.PanelDetails)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.ToolStrip2)
        Me.DoubleBuffered = true
        Me.KeyPreview = true
        Me.MinimumSize = New System.Drawing.Size(1000, 600)
        Me.Name = "frmPatientAttendancy"
        Me.ShowInTaskbar = false
        Me.Text = "Advanced Search"
        Me.ToolStrip2.ResumeLayout(false)
        Me.ToolStrip2.PerformLayout
        Me.ContextMenuStripCustomizeToolStrip.ResumeLayout(false)
        Me.PanelShowDetails.ResumeLayout(false)
        Me.PanelShowDetails.PerformLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ButtonDetails,System.ComponentModel.ISupportInitialize).EndInit
        Me.ContextMenuStripNF2.ResumeLayout(false)
        Me.PanelDetails.ResumeLayout(false)
        Me.Panel1.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.Panel11.ResumeLayout(false)
        Me.Panel12.ResumeLayout(false)
        Me.Panel12.PerformLayout
        Me.Panel9.ResumeLayout(false)
        Me.Panel10.ResumeLayout(false)
        Me.Panel10.PerformLayout
        Me.Panel8.ResumeLayout(false)
        Me.PanelBills.ResumeLayout(false)
        Me.PanelBills.PerformLayout
        Me.Panel7.ResumeLayout(false)
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        Me.Panel6.ResumeLayout(false)
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.Panel4.ResumeLayout(false)
        Me.Panel13.ResumeLayout(false)
        Me.Panel13.PerformLayout
        Me.ContextMenuStrip3.ResumeLayout(false)
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel2.PerformLayout
        CType(Me.FpSpreadForPrint_Sheet1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.FpSpreadForPrint,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelWait.ResumeLayout(false)
        Me.PanelWait.PerformLayout
        CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripStatusLabelChecked As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripStatusLabelFound As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportAllToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportCheckedToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrinting2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents PrintResultListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintAll1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintCheckedOnly1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ListViewPatients As System.Windows.Forms.ListView
    Friend WithEvents PatientNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents PatientName As System.Windows.Forms.ColumnHeader
    Friend WithEvents DOA As System.Windows.Forms.ColumnHeader
    Friend WithEvents CaseType As System.Windows.Forms.ColumnHeader
    Friend WithEvents PolicyNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClaimNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents STATUS As System.Windows.Forms.ColumnHeader
    Friend WithEvents Insurance As System.Windows.Forms.ColumnHeader
    Friend WithEvents AdjusterName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStripNF2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuShowSelectedPatientInfo1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrinting1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PanelDetails As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageListTray As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ListViewProcedures As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Type As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListViewServices As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageListCurrentBills As System.Windows.Forms.ImageList
    Friend WithEvents ListViewRequests As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Attorney As System.Windows.Forms.ColumnHeader
    Friend WithEvents NF2Date As System.Windows.Forms.ColumnHeader
    Friend WithEvents PrintCheckedSelectedNF23ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FindDuplicatePatientsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAccidentRelatedPatientsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListViewPatientsRelated As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader45 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader46 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PrintPatientsFileLabelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents PanelShowDetails As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents txtBillNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxFilter As System.Windows.Forms.ComboBox
    Friend WithEvents txtPatientAttorney As System.Windows.Forms.TextBox
    Friend WithEvents cboTreatingProvider As System.Windows.Forms.ComboBox
    Friend WithEvents cboBillingProvider As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxSearchCaseType As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxSearchCaseStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerDOATo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerDOAFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DateTimePickerTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerServicesFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerServicesTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonDetails As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PrintPatientScheduleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ListViewSchedule As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents FpSpreadForPrint_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents QuickPrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents FpSpreadForPrint As FarPoint.Win.Spread.FpSpread
    Friend WithEvents mnuPrintCheckedEnvelopes1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents EmailAllRecordsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailCheckedOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtPACSAltNumber As System.Windows.Forms.TextBox
    Friend WithEvents TreeViewBills As System.Windows.Forms.TreeView
    Friend WithEvents PanelBills As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButtonCloseForm As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStripCustomizeToolStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CustomizeToolbarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton12 As ToolStripButton
    Friend WithEvents ToolStripButton13 As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem12 As ToolStripMenuItem
End Class
