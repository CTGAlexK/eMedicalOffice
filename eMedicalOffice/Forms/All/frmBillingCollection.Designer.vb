<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBillingCollection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBillingCollection))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Insurance", ""}, -1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Adjuster Name", ""}, -1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Adjuster Contact", ""}, -1)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Policy #", ""}, -1)
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Claim #", ""}, -1)
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Attorney", ""}, -1)
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Attorney DT", ""}, -1)
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"POM", ""}, -1)
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Treating Provider", ""}, -1)
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Billing Provider", ""}, -1)
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Index #", ""}, -1)
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Filing Date", ""}, -1)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ContextMenuStripCustomizeToolStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CustomizeToolbarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripAutoResize = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripFontIncrease = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripFonrDecrease = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTools = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuPrinting2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintCheckedBills2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintCheckedEnvelopes2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintCheckedBillsReadingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintSelectedFileLabel2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintResultListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintAll1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintCheckedOnly1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportCheckedToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportAllToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparatorAdmin = New System.Windows.Forms.ToolStripSeparator()
        Me.CollectionStatisticsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemAction = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripMenuItemRequest = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCloseForm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemPatient = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDetach = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboBillStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenuStripAction = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuActionComplete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripActionSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboDays = New System.Windows.Forms.ComboBox()
        Me.cboInsuranceCompanyID = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboAttorneysCompanyID = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboBillingProvider = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBillNumber = New System.Windows.Forms.TextBox()
        Me.txtPatient = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker()
        Me.ButtonFind = New System.Windows.Forms.Button()
        Me.txtAdjuster = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ListViewReminders = New eMedicalOffice.clsListView()
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripReminderComplete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripReminderSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PopUpButtonAddAction = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem28 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectedBillPayment1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem17 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuUpdateAdjusterInformation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuFilterByAdjuster = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem27 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.PopUpMenuItemShowPatient = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemItemizedCharges = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintBillProgress = New System.Windows.Forms.ToolStripMenuItem()
        Me.BillToPatientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ListViewPatients = New eMedicalOffice.clsListView()
        Me.PatientNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PatientName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DOA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ServiceDT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BillID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BillDT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Amt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PaidAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Balance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Insurance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Adjuster = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AdjusterContact = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PatientAttorney = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader35 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboCollector = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PanelDetails = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ListViewActions = New System.Windows.Forms.ListView()
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtAction = New System.Windows.Forms.TextBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonComplete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonAction = New System.Windows.Forms.ToolStripButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListViewRequests = New System.Windows.Forms.ListView()
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripRequest = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip9 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonBillRequests = New System.Windows.Forms.ToolStripButton()
        Me.ListViewPayments = New System.Windows.Forms.ListView()
        Me.PaymentDT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Amount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TreeViewBills = New System.Windows.Forms.TreeView()
        Me.ToolStrip7 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonShowBill = New System.Windows.Forms.ToolStripButton()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.txtPatientComments = New System.Windows.Forms.TextBox()
        Me.ContextMenuStripComments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip8 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonPatientComments = New System.Windows.Forms.ToolStripButton()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.PanelDocumentWait = New System.Windows.Forms.Panel()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.pdfViewer = New PdfiumViewer.PdfViewer()
        Me.ListViewDocs = New System.Windows.Forms.ListView()
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripDocument = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip6 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonDocuments = New System.Windows.Forms.ToolStripButton()
        Me.ButtonScannDocument = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.ListViewBillToPatient = New System.Windows.Forms.ListView()
        Me.ColumnHeader33 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader32 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.ListViewDenials = New System.Windows.Forms.ListView()
        Me.ColumnHeader36 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader37 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader38 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtDenialComments = New System.Windows.Forms.TextBox()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ListViewDetails = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripNotes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TimerRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripLabelFound = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLabelReminders = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelPatName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimerLoadData = New System.Windows.Forms.Timer(Me.components)
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CachedrptCoverPage1 = New eMedicalOffice.CachedrptCoverPage()
        Me.TimerGetReminderDetails = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip2.SuspendLayout()
        Me.ContextMenuStripCustomizeToolStrip.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ContextMenuStripAction.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.ContextMenuStripMain.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PanelDetails.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.ContextMenuStripRequest.SuspendLayout()
        Me.ToolStrip9.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.ToolStrip7.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.ContextMenuStripComments.SuspendLayout()
        Me.ToolStrip8.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.PanelDocumentWait.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripDocument.SuspendLayout()
        Me.ToolStrip6.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.ContextMenuStripNotes.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.ContextMenuStrip = Me.ContextMenuStripCustomizeToolStrip
        Me.ToolStrip2.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripAutoResize, Me.ToolStripFontIncrease, Me.ToolStripFonrDecrease, Me.ToolStripSeparator14, Me.ToolStripTools, Me.ToolStripSeparator26, Me.ToolStripMenuItemAction, Me.ToolStripMenuItemRequest, Me.ToolStripButton11, Me.ToolStripButtonCloseForm, Me.ToolStripSeparator5, Me.ToolStripMenuItemPatient, Me.ToolStripButtonDetach})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 39)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1084, 25)
        Me.ToolStrip2.TabIndex = 2
        Me.ToolStrip2.Text = "Paid Checked"
        '
        'ContextMenuStripCustomizeToolStrip
        '
        Me.ContextMenuStripCustomizeToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomizeToolbarToolStripMenuItem, Me.ToolStripSeparator7, Me.ToolStripMenuItem12})
        Me.ContextMenuStripCustomizeToolStrip.Name = "ContextMenuStripCustomizeToolStrip"
        Me.ContextMenuStripCustomizeToolStrip.Size = New System.Drawing.Size(173, 54)
        '
        'CustomizeToolbarToolStripMenuItem
        '
        Me.CustomizeToolbarToolStripMenuItem.Image = CType(resources.GetObject("CustomizeToolbarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CustomizeToolbarToolStripMenuItem.Name = "CustomizeToolbarToolStripMenuItem"
        Me.CustomizeToolbarToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CustomizeToolbarToolStripMenuItem.Text = "Customize Toolbar"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(169, 6)
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Image = CType(resources.GetObject("ToolStripMenuItem12.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(172, 22)
        Me.ToolStripMenuItem12.Text = "Restore"
        '
        'ToolStripAutoResize
        '
        Me.ToolStripAutoResize.Image = CType(resources.GetObject("ToolStripAutoResize.Image"), System.Drawing.Image)
        Me.ToolStripAutoResize.Name = "ToolStripAutoResize"
        Me.ToolStripAutoResize.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.ToolStripAutoResize.Size = New System.Drawing.Size(28, 22)
        Me.ToolStripAutoResize.ToolTipText = "Autosize Spreads Columns Width"
        '
        'ToolStripFontIncrease
        '
        Me.ToolStripFontIncrease.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripFontIncrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripFontIncrease.Image = CType(resources.GetObject("ToolStripFontIncrease.Image"), System.Drawing.Image)
        Me.ToolStripFontIncrease.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripFontIncrease.Name = "ToolStripFontIncrease"
        Me.ToolStripFontIncrease.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ToolStripFontIncrease.Size = New System.Drawing.Size(30, 22)
        Me.ToolStripFontIncrease.ToolTipText = "Font Increase"
        '
        'ToolStripFonrDecrease
        '
        Me.ToolStripFonrDecrease.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripFonrDecrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripFonrDecrease.Image = CType(resources.GetObject("ToolStripFonrDecrease.Image"), System.Drawing.Image)
        Me.ToolStripFonrDecrease.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripFonrDecrease.Name = "ToolStripFonrDecrease"
        Me.ToolStripFonrDecrease.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripFonrDecrease.ToolTipText = "Font Decrease"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTools
        '
        Me.ToolStripTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrinting2, Me.ToolStripSeparator3, Me.ExportToolStripMenuItem, Me.ToolStripSeparatorAdmin, Me.CollectionStatisticsToolStripMenuItem})
        Me.ToolStripTools.Image = CType(resources.GetObject("ToolStripTools.Image"), System.Drawing.Image)
        Me.ToolStripTools.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripTools.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripTools.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolStripTools.Name = "ToolStripTools"
        Me.ToolStripTools.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripTools.Text = "Tools"
        '
        'mnuPrinting2
        '
        Me.mnuPrinting2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrintCheckedBills2, Me.mnuPrintCheckedEnvelopes2, Me.PrintCheckedBillsReadingsToolStripMenuItem, Me.mnuPrintSelectedFileLabel2, Me.ToolStripSeparator9, Me.PrintResultListToolStripMenuItem})
        Me.mnuPrinting2.Image = CType(resources.GetObject("mnuPrinting2.Image"), System.Drawing.Image)
        Me.mnuPrinting2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuPrinting2.Name = "mnuPrinting2"
        Me.mnuPrinting2.Size = New System.Drawing.Size(215, 22)
        Me.mnuPrinting2.Text = "Printing"
        Me.mnuPrinting2.ToolTipText = "Printing Tools"
        '
        'mnuPrintCheckedBills2
        '
        Me.mnuPrintCheckedBills2.Image = CType(resources.GetObject("mnuPrintCheckedBills2.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedBills2.Name = "mnuPrintCheckedBills2"
        Me.mnuPrintCheckedBills2.Size = New System.Drawing.Size(217, 22)
        Me.mnuPrintCheckedBills2.Text = "Print Selected Bill"
        Me.mnuPrintCheckedBills2.ToolTipText = "Generate And Print Checked Bills"
        '
        'mnuPrintCheckedEnvelopes2
        '
        Me.mnuPrintCheckedEnvelopes2.Image = CType(resources.GetObject("mnuPrintCheckedEnvelopes2.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedEnvelopes2.Name = "mnuPrintCheckedEnvelopes2"
        Me.mnuPrintCheckedEnvelopes2.Size = New System.Drawing.Size(217, 22)
        Me.mnuPrintCheckedEnvelopes2.Text = "Print Selected Envelope"
        Me.mnuPrintCheckedEnvelopes2.ToolTipText = "Print Checked Bills Envelopes"
        '
        'PrintCheckedBillsReadingsToolStripMenuItem
        '
        Me.PrintCheckedBillsReadingsToolStripMenuItem.Image = CType(resources.GetObject("PrintCheckedBillsReadingsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintCheckedBillsReadingsToolStripMenuItem.Name = "PrintCheckedBillsReadingsToolStripMenuItem"
        Me.PrintCheckedBillsReadingsToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.PrintCheckedBillsReadingsToolStripMenuItem.Text = "Print Selected Bill Readings"
        Me.PrintCheckedBillsReadingsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mnuPrintSelectedFileLabel2
        '
        Me.mnuPrintSelectedFileLabel2.Image = CType(resources.GetObject("mnuPrintSelectedFileLabel2.Image"), System.Drawing.Image)
        Me.mnuPrintSelectedFileLabel2.Name = "mnuPrintSelectedFileLabel2"
        Me.mnuPrintSelectedFileLabel2.Size = New System.Drawing.Size(217, 22)
        Me.mnuPrintSelectedFileLabel2.Text = "Print Selected Bill File Label"
        Me.mnuPrintSelectedFileLabel2.ToolTipText = "Print Selected Bill File Label"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(214, 6)
        '
        'PrintResultListToolStripMenuItem
        '
        Me.PrintResultListToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrintAll1, Me.mnuPrintCheckedOnly1})
        Me.PrintResultListToolStripMenuItem.ForeColor = System.Drawing.Color.Navy
        Me.PrintResultListToolStripMenuItem.Image = CType(resources.GetObject("PrintResultListToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintResultListToolStripMenuItem.Name = "PrintResultListToolStripMenuItem"
        Me.PrintResultListToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.PrintResultListToolStripMenuItem.Text = "Print Result List"
        '
        'mnuPrintAll1
        '
        Me.mnuPrintAll1.Image = CType(resources.GetObject("mnuPrintAll1.Image"), System.Drawing.Image)
        Me.mnuPrintAll1.Name = "mnuPrintAll1"
        Me.mnuPrintAll1.Size = New System.Drawing.Size(176, 22)
        Me.mnuPrintAll1.Text = "Print All"
        '
        'mnuPrintCheckedOnly1
        '
        Me.mnuPrintCheckedOnly1.Image = CType(resources.GetObject("mnuPrintCheckedOnly1.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedOnly1.Name = "mnuPrintCheckedOnly1"
        Me.mnuPrintCheckedOnly1.Size = New System.Drawing.Size(176, 22)
        Me.mnuPrintCheckedOnly1.Text = "Print Checked Only"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(212, 6)
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportCheckedToExcelToolStripMenuItem, Me.ExportAllToExcelToolStripMenuItem})
        Me.ExportToolStripMenuItem.Image = CType(resources.GetObject("ExportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.ExportToolStripMenuItem.Text = "Export To Excel"
        '
        'ExportCheckedToExcelToolStripMenuItem
        '
        Me.ExportCheckedToExcelToolStripMenuItem.Image = CType(resources.GetObject("ExportCheckedToExcelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportCheckedToExcelToolStripMenuItem.Name = "ExportCheckedToExcelToolStripMenuItem"
        Me.ExportCheckedToExcelToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ExportCheckedToExcelToolStripMenuItem.Text = "Export Checked"
        Me.ExportCheckedToExcelToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ExportAllToExcelToolStripMenuItem
        '
        Me.ExportAllToExcelToolStripMenuItem.Image = CType(resources.GetObject("ExportAllToExcelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportAllToExcelToolStripMenuItem.Name = "ExportAllToExcelToolStripMenuItem"
        Me.ExportAllToExcelToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ExportAllToExcelToolStripMenuItem.Text = "Export All"
        Me.ExportAllToExcelToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparatorAdmin
        '
        Me.ToolStripSeparatorAdmin.Name = "ToolStripSeparatorAdmin"
        Me.ToolStripSeparatorAdmin.Size = New System.Drawing.Size(212, 6)
        '
        'CollectionStatisticsToolStripMenuItem
        '
        Me.CollectionStatisticsToolStripMenuItem.Image = CType(resources.GetObject("CollectionStatisticsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CollectionStatisticsToolStripMenuItem.Name = "CollectionStatisticsToolStripMenuItem"
        Me.CollectionStatisticsToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.CollectionStatisticsToolStripMenuItem.Text = "Collection Statistic Reports"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ToolStripSeparator26.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripMenuItemAction
        '
        Me.ToolStripMenuItemAction.Image = CType(resources.GetObject("ToolStripMenuItemAction.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemAction.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripMenuItemAction.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolStripMenuItemAction.Name = "ToolStripMenuItemAction"
        Me.ToolStripMenuItemAction.Padding = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.ToolStripMenuItemAction.Size = New System.Drawing.Size(148, 22)
        Me.ToolStripMenuItemAction.Text = "Add Note/Reminder"
        Me.ToolStripMenuItemAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripMenuItemAction.ToolTipText = "Add Reminder"
        '
        'ToolStripMenuItemRequest
        '
        Me.ToolStripMenuItemRequest.Image = CType(resources.GetObject("ToolStripMenuItemRequest.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemRequest.Name = "ToolStripMenuItemRequest"
        Me.ToolStripMenuItemRequest.Padding = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.ToolStripMenuItemRequest.Size = New System.Drawing.Size(144, 25)
        Me.ToolStripMenuItemRequest.Text = "Add Billing Request"
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.AutoSize = False
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Padding = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.ToolStripButton11.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripButton11.Text = "Add Payment"
        Me.ToolStripButton11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripMenuItemPatient
        '
        Me.ToolStripMenuItemPatient.Image = CType(resources.GetObject("ToolStripMenuItemPatient.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemPatient.Margin = New System.Windows.Forms.Padding(0, 1, 15, 2)
        Me.ToolStripMenuItemPatient.Name = "ToolStripMenuItemPatient"
        Me.ToolStripMenuItemPatient.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ToolStripMenuItemPatient.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripMenuItemPatient.RightToLeftAutoMirrorImage = True
        Me.ToolStripMenuItemPatient.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripMenuItemPatient.Text = "Patient"
        Me.ToolStripMenuItemPatient.ToolTipText = "Open Patient Profile"
        '
        'ToolStripButtonDetach
        '
        Me.ToolStripButtonDetach.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonDetach.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDetach.Image = CType(resources.GetObject("ToolStripButtonDetach.Image"), System.Drawing.Image)
        Me.ToolStripButtonDetach.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonDetach.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDetach.Name = "ToolStripButtonDetach"
        Me.ToolStripButtonDetach.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonDetach.Text = "Attach / Detach Window"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 12
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 10, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboBillStatus, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDays, 9, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboInsuranceCompanyID, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboAttorneysCompanyID, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboBillingProvider, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePickerFrom, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBillNumber, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPatient, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePickerTo, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonFind, 11, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAdjuster, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 8, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 64)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1084, 44)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(813, 6)
        Me.Button1.Name = "Button1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Button1, 5)
        Me.Button1.Size = New System.Drawing.Size(26, 32)
        Me.Button1.TabIndex = 281
        Me.ToolTip1.SetToolTip(Me.Button1, "Clear Search Criteria")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(468, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 12)
        Me.Label4.TabIndex = 280
        Me.Label4.Text = "Status"
        '
        'cboBillStatus
        '
        Me.cboBillStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboBillStatus.BackColor = System.Drawing.Color.White
        Me.cboBillStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboBillStatus.DropDownWidth = 300
        Me.cboBillStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboBillStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBillStatus.ForeColor = System.Drawing.Color.Black
        Me.cboBillStatus.FormattingEnabled = True
        Me.cboBillStatus.Location = New System.Drawing.Point(468, 18)
        Me.cboBillStatus.MaxDropDownItems = 40
        Me.cboBillStatus.Name = "cboBillStatus"
        Me.cboBillStatus.Size = New System.Drawing.Size(84, 21)
        Me.cboBillStatus.TabIndex = 279
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ContextMenuStrip = Me.ContextMenuStripAction
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(708, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 12)
        Me.Label1.TabIndex = 277
        Me.Label1.Text = "No Response Days"
        '
        'ContextMenuStripAction
        '
        Me.ContextMenuStripAction.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuActionComplete, Me.ToolStripActionSeparator, Me.ToolStripButton7})
        Me.ContextMenuStripAction.Name = "ContextMenuStripAction"
        Me.ContextMenuStripAction.Size = New System.Drawing.Size(181, 54)
        '
        'ToolStripMenuActionComplete
        '
        Me.ToolStripMenuActionComplete.Image = CType(resources.GetObject("ToolStripMenuActionComplete.Image"), System.Drawing.Image)
        Me.ToolStripMenuActionComplete.Name = "ToolStripMenuActionComplete"
        Me.ToolStripMenuActionComplete.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuActionComplete.Text = "Reminder Complete"
        '
        'ToolStripActionSeparator
        '
        Me.ToolStripActionSeparator.Name = "ToolStripActionSeparator"
        Me.ToolStripActionSeparator.Size = New System.Drawing.Size(177, 6)
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripButton7.Text = "Add Action"
        Me.ToolStripButton7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButton7.ToolTipText = "Add Reminder"
        '
        'cboDays
        '
        Me.cboDays.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboDays.BackColor = System.Drawing.Color.White
        Me.cboDays.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDays.DropDownWidth = 300
        Me.cboDays.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDays.ForeColor = System.Drawing.Color.Black
        Me.cboDays.FormattingEnabled = True
        Me.cboDays.Location = New System.Drawing.Point(708, 18)
        Me.cboDays.MaxDropDownItems = 40
        Me.cboDays.Name = "cboDays"
        Me.cboDays.Size = New System.Drawing.Size(99, 21)
        Me.cboDays.TabIndex = 276
        '
        'cboInsuranceCompanyID
        '
        Me.cboInsuranceCompanyID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboInsuranceCompanyID.BackColor = System.Drawing.Color.White
        Me.cboInsuranceCompanyID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboInsuranceCompanyID.DropDownWidth = 300
        Me.cboInsuranceCompanyID.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboInsuranceCompanyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInsuranceCompanyID.ForeColor = System.Drawing.Color.Black
        Me.cboInsuranceCompanyID.FormattingEnabled = True
        Me.cboInsuranceCompanyID.Location = New System.Drawing.Point(318, 18)
        Me.cboInsuranceCompanyID.MaxDropDownItems = 40
        Me.cboInsuranceCompanyID.Name = "cboInsuranceCompanyID"
        Me.cboInsuranceCompanyID.Size = New System.Drawing.Size(144, 21)
        Me.cboInsuranceCompanyID.TabIndex = 274
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(318, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 12)
        Me.Label7.TabIndex = 275
        Me.Label7.Text = "Insurance"
        '
        'cboAttorneysCompanyID
        '
        Me.cboAttorneysCompanyID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboAttorneysCompanyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttorneysCompanyID.DropDownWidth = 300
        Me.cboAttorneysCompanyID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAttorneysCompanyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAttorneysCompanyID.ForeColor = System.Drawing.Color.Black
        Me.cboAttorneysCompanyID.FormattingEnabled = True
        Me.cboAttorneysCompanyID.Location = New System.Drawing.Point(168, 18)
        Me.cboAttorneysCompanyID.Name = "cboAttorneysCompanyID"
        Me.cboAttorneysCompanyID.Size = New System.Drawing.Size(144, 21)
        Me.cboAttorneysCompanyID.TabIndex = 272
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(168, 3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 12)
        Me.Label18.TabIndex = 273
        Me.Label18.Text = "Attorney"
        '
        'cboBillingProvider
        '
        Me.cboBillingProvider.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboBillingProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingProvider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillingProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBillingProvider.ForeColor = System.Drawing.Color.Black
        Me.cboBillingProvider.FormattingEnabled = True
        Me.cboBillingProvider.Location = New System.Drawing.Point(172, 18)
        Me.cboBillingProvider.Name = "cboBillingProvider"
        Me.cboBillingProvider.Size = New System.Drawing.Size(1, 21)
        Me.cboBillingProvider.TabIndex = 270
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(172, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(1, 12)
        Me.Label13.TabIndex = 271
        Me.Label13.Text = "Billing Provider"
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.Checked = False
        Me.DateTimePickerFrom.CustomFormat = "MM/dd/yy"
        Me.DateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(-4, 18)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.ShowCheckBox = True
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(82, 20)
        Me.DateTimePickerFrom.TabIndex = 258
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(-4, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 12)
        Me.Label6.TabIndex = 260
        Me.Label6.Text = "Bill From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(84, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 12)
        Me.Label3.TabIndex = 261
        Me.Label3.Text = "To"
        '
        'txtBillNumber
        '
        Me.txtBillNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtBillNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtBillNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBillNumber.Location = New System.Drawing.Point(0, 18)
        Me.txtBillNumber.MaxLength = 10
        Me.txtBillNumber.Name = "txtBillNumber"
        Me.txtBillNumber.Size = New System.Drawing.Size(1, 20)
        Me.txtBillNumber.TabIndex = 257
        '
        'txtPatient
        '
        Me.txtPatient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtPatient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPatient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPatient.Location = New System.Drawing.Point(3, 18)
        Me.txtPatient.Name = "txtPatient"
        Me.txtPatient.Size = New System.Drawing.Size(1, 20)
        Me.txtPatient.TabIndex = 110
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1, 12)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "First/Last/##"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(0, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(1, 12)
        Me.Label5.TabIndex = 256
        Me.Label5.Text = "Bill/Claim/Policy ##"
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.Checked = False
        Me.DateTimePickerTo.CustomFormat = "MM/dd/yy"
        Me.DateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTo.Location = New System.Drawing.Point(84, 18)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.ShowCheckBox = True
        Me.DateTimePickerTo.Size = New System.Drawing.Size(82, 20)
        Me.DateTimePickerTo.TabIndex = 259
        '
        'ButtonFind
        '
        Me.ButtonFind.Image = CType(resources.GetObject("ButtonFind.Image"), System.Drawing.Image)
        Me.ButtonFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonFind.Location = New System.Drawing.Point(845, 6)
        Me.ButtonFind.Name = "ButtonFind"
        Me.ButtonFind.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.TableLayoutPanel1.SetRowSpan(Me.ButtonFind, 5)
        Me.ButtonFind.Size = New System.Drawing.Size(68, 32)
        Me.ButtonFind.TabIndex = 278
        Me.ButtonFind.Text = "Find   "
        Me.ButtonFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButtonFind, "Find Bills")
        Me.ButtonFind.UseVisualStyleBackColor = True
        '
        'txtAdjuster
        '
        Me.txtAdjuster.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtAdjuster.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtAdjuster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAdjuster.Location = New System.Drawing.Point(558, 18)
        Me.txtAdjuster.Name = "txtAdjuster"
        Me.txtAdjuster.Size = New System.Drawing.Size(144, 20)
        Me.txtAdjuster.TabIndex = 282
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(558, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 12)
        Me.Label9.TabIndex = 283
        Me.Label9.Text = "Adjuster"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 133)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer2.Panel1.Controls.Add(Me.ListViewReminders)
        Me.SplitContainer2.Panel1MinSize = 150
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer2.Panel2.Controls.Add(Me.ListViewPatients)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Panel4)
        Me.SplitContainer2.Panel2MinSize = 150
        Me.SplitContainer2.Size = New System.Drawing.Size(741, 457)
        Me.SplitContainer2.SplitterDistance = 150
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 19
        '
        'ListViewReminders
        '
        Me.ListViewReminders.AllowColumnReorder = True
        Me.ListViewReminders.BackColor = System.Drawing.Color.Snow
        Me.ListViewReminders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader17, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader28})
        Me.ListViewReminders.ContextMenuStrip = Me.ContextMenuStripMain
        Me.ListViewReminders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewReminders.FullRowSelect = True
        Me.ListViewReminders.GridLines = True
        Me.ListViewReminders.HideSelection = False
        Me.ListViewReminders.LabelWrap = False
        Me.ListViewReminders.LargeImageList = Me.ImageList1
        Me.ListViewReminders.Location = New System.Drawing.Point(0, 0)
        Me.ListViewReminders.Margin = New System.Windows.Forms.Padding(0)
        Me.ListViewReminders.MultiSelect = False
        Me.ListViewReminders.Name = "ListViewReminders"
        Me.ListViewReminders.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListViewReminders.ShowGroups = False
        Me.ListViewReminders.ShowItemToolTips = True
        Me.ListViewReminders.Size = New System.Drawing.Size(741, 150)
        Me.ListViewReminders.SmallImageList = Me.ImageList1
        Me.ListViewReminders.TabIndex = 17
        Me.ListViewReminders.UseCompatibleStateImageBehavior = False
        Me.ListViewReminders.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Reminder DT"
        Me.ColumnHeader19.Width = 91
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Reminder By"
        Me.ColumnHeader20.Width = 82
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Patient #"
        Me.ColumnHeader1.Width = 97
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 110
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "DOA"
        Me.ColumnHeader3.Width = 85
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Service DT"
        Me.ColumnHeader5.Width = 91
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Bill #"
        Me.ColumnHeader6.Width = 66
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Bill DT"
        Me.ColumnHeader7.Width = 108
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Status"
        Me.ColumnHeader9.Width = 73
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Amt $"
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader10.Width = 72
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Paid Amt $"
        Me.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader11.Width = 85
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Balance $"
        Me.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Index Number"
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Insurance"
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Adjuster"
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "Adjuster Contact"
        '
        'ContextMenuStripMain
        '
        Me.ContextMenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripReminderComplete, Me.ToolStripReminderSeparator, Me.PopUpButtonAddAction, Me.ToolStripMenuItem28, Me.mnuSelectedBillPayment1, Me.ToolStripSeparator8, Me.ToolStripMenuItem17, Me.ToolStripSeparator4, Me.ToolStripMenuUpdateAdjusterInformation, Me.ToolStripMenuFilterByAdjuster, Me.ToolStripSeparator2, Me.ToolStripMenuItem27, Me.ToolStripSeparator6, Me.PopUpMenuItemShowPatient, Me.ToolStripMenuItemItemizedCharges, Me.mnuPrintBillProgress, Me.BillToPatientToolStripMenuItem, Me.ToolStripSeparator10, Me.ToolStripMenuItem3})
        Me.ContextMenuStripMain.Name = "ContextMenuStrip1"
        Me.ContextMenuStripMain.Size = New System.Drawing.Size(323, 326)
        '
        'ToolStripReminderComplete
        '
        Me.ToolStripReminderComplete.Image = CType(resources.GetObject("ToolStripReminderComplete.Image"), System.Drawing.Image)
        Me.ToolStripReminderComplete.Name = "ToolStripReminderComplete"
        Me.ToolStripReminderComplete.Size = New System.Drawing.Size(322, 22)
        Me.ToolStripReminderComplete.Text = "Reminder Complete"
        '
        'ToolStripReminderSeparator
        '
        Me.ToolStripReminderSeparator.Name = "ToolStripReminderSeparator"
        Me.ToolStripReminderSeparator.Size = New System.Drawing.Size(319, 6)
        '
        'PopUpButtonAddAction
        '
        Me.PopUpButtonAddAction.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.PopUpButtonAddAction.Image = CType(resources.GetObject("PopUpButtonAddAction.Image"), System.Drawing.Image)
        Me.PopUpButtonAddAction.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PopUpButtonAddAction.Name = "PopUpButtonAddAction"
        Me.PopUpButtonAddAction.Size = New System.Drawing.Size(322, 22)
        Me.PopUpButtonAddAction.Text = "Add Note / Reminder"
        Me.PopUpButtonAddAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PopUpButtonAddAction.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.PopUpButtonAddAction.ToolTipText = "Add Reminder"
        '
        'ToolStripMenuItem28
        '
        Me.ToolStripMenuItem28.Image = CType(resources.GetObject("ToolStripMenuItem28.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem28.Name = "ToolStripMenuItem28"
        Me.ToolStripMenuItem28.Size = New System.Drawing.Size(322, 22)
        Me.ToolStripMenuItem28.Text = "Add Billing Request"
        '
        'mnuSelectedBillPayment1
        '
        Me.mnuSelectedBillPayment1.Image = CType(resources.GetObject("mnuSelectedBillPayment1.Image"), System.Drawing.Image)
        Me.mnuSelectedBillPayment1.Name = "mnuSelectedBillPayment1"
        Me.mnuSelectedBillPayment1.Size = New System.Drawing.Size(322, 22)
        Me.mnuSelectedBillPayment1.Text = "Add Bill Payment"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(319, 6)
        '
        'ToolStripMenuItem17
        '
        Me.ToolStripMenuItem17.Image = CType(resources.GetObject("ToolStripMenuItem17.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem17.Name = "ToolStripMenuItem17"
        Me.ToolStripMenuItem17.Size = New System.Drawing.Size(322, 22)
        Me.ToolStripMenuItem17.Text = "Add Document From Library"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(319, 6)
        '
        'ToolStripMenuUpdateAdjusterInformation
        '
        Me.ToolStripMenuUpdateAdjusterInformation.Image = CType(resources.GetObject("ToolStripMenuUpdateAdjusterInformation.Image"), System.Drawing.Image)
        Me.ToolStripMenuUpdateAdjusterInformation.Name = "ToolStripMenuUpdateAdjusterInformation"
        Me.ToolStripMenuUpdateAdjusterInformation.Size = New System.Drawing.Size(322, 22)
        Me.ToolStripMenuUpdateAdjusterInformation.Text = "Update Adjuster Information"
        '
        'ToolStripMenuFilterByAdjuster
        '
        Me.ToolStripMenuFilterByAdjuster.Image = CType(resources.GetObject("ToolStripMenuFilterByAdjuster.Image"), System.Drawing.Image)
        Me.ToolStripMenuFilterByAdjuster.Name = "ToolStripMenuFilterByAdjuster"
        Me.ToolStripMenuFilterByAdjuster.Size = New System.Drawing.Size(322, 22)
        Me.ToolStripMenuFilterByAdjuster.Text = "Filter By Adjuster"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(319, 6)
        '
        'ToolStripMenuItem27
        '
        Me.ToolStripMenuItem27.Image = CType(resources.GetObject("ToolStripMenuItem27.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem27.Name = "ToolStripMenuItem27"
        Me.ToolStripMenuItem27.Size = New System.Drawing.Size(322, 22)
        Me.ToolStripMenuItem27.Text = "Court Index Number / Filing Date Maintenance"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(319, 6)
        '
        'PopUpMenuItemShowPatient
        '
        Me.PopUpMenuItemShowPatient.Image = CType(resources.GetObject("PopUpMenuItemShowPatient.Image"), System.Drawing.Image)
        Me.PopUpMenuItemShowPatient.Name = "PopUpMenuItemShowPatient"
        Me.PopUpMenuItemShowPatient.Size = New System.Drawing.Size(322, 22)
        Me.PopUpMenuItemShowPatient.Text = "Patient's Information"
        '
        'ToolStripMenuItemItemizedCharges
        '
        Me.ToolStripMenuItemItemizedCharges.Image = CType(resources.GetObject("ToolStripMenuItemItemizedCharges.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemItemizedCharges.Name = "ToolStripMenuItemItemizedCharges"
        Me.ToolStripMenuItemItemizedCharges.Size = New System.Drawing.Size(322, 22)
        Me.ToolStripMenuItemItemizedCharges.Text = "Itemized Charges"
        '
        'mnuPrintBillProgress
        '
        Me.mnuPrintBillProgress.Image = CType(resources.GetObject("mnuPrintBillProgress.Image"), System.Drawing.Image)
        Me.mnuPrintBillProgress.Name = "mnuPrintBillProgress"
        Me.mnuPrintBillProgress.Size = New System.Drawing.Size(322, 22)
        Me.mnuPrintBillProgress.Text = "Print Selected Patient Progress Report"
        '
        'BillToPatientToolStripMenuItem
        '
        Me.BillToPatientToolStripMenuItem.Image = CType(resources.GetObject("BillToPatientToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BillToPatientToolStripMenuItem.Name = "BillToPatientToolStripMenuItem"
        Me.BillToPatientToolStripMenuItem.Size = New System.Drawing.Size(322, 22)
        Me.BillToPatientToolStripMenuItem.Text = "Bill To Patient"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(319, 6)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuItem9, Me.ToolStripMenuItem10})
        Me.ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(322, 22)
        Me.ToolStripMenuItem3.Text = "Printing"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Image = CType(resources.GetObject("ToolStripMenuItem5.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem5.Text = "Print Selected Bill"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Image = CType(resources.GetObject("ToolStripMenuItem6.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem6.Text = "Print Selected Envelope"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Image = CType(resources.GetObject("ToolStripMenuItem9.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem9.Text = "Print Selected Bill Readings"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Image = CType(resources.GetObject("ToolStripMenuItem10.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem10.Text = "Print File Label"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "SORT1")
        Me.ImageList1.Images.SetKeyName(1, "SORT2")
        Me.ImageList1.Images.SetKeyName(2, "SORT0")
        '
        'ListViewPatients
        '
        Me.ListViewPatients.AllowColumnReorder = True
        Me.ListViewPatients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PatientNo, Me.PatientName, Me.DOA, Me.ServiceDT, Me.BillID, Me.BillDT, Me.Status, Me.Amt, Me.PaidAmount, Me.Balance, Me.ColumnHeader18, Me.Insurance, Me.Adjuster, Me.AdjusterContact, Me.PatientAttorney, Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader31, Me.ColumnHeader35})
        Me.ListViewPatients.ContextMenuStrip = Me.ContextMenuStripMain
        Me.ListViewPatients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewPatients.FullRowSelect = True
        Me.ListViewPatients.GridLines = True
        Me.ListViewPatients.HideSelection = False
        Me.ListViewPatients.LabelWrap = False
        Me.ListViewPatients.LargeImageList = Me.ImageList1
        Me.ListViewPatients.Location = New System.Drawing.Point(0, 20)
        Me.ListViewPatients.Margin = New System.Windows.Forms.Padding(0)
        Me.ListViewPatients.MultiSelect = False
        Me.ListViewPatients.Name = "ListViewPatients"
        Me.ListViewPatients.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListViewPatients.ShowGroups = False
        Me.ListViewPatients.ShowItemToolTips = True
        Me.ListViewPatients.Size = New System.Drawing.Size(741, 282)
        Me.ListViewPatients.SmallImageList = Me.ImageList1
        Me.ListViewPatients.TabIndex = 1
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
        Me.PatientName.Width = 110
        '
        'DOA
        '
        Me.DOA.Text = "DOA"
        Me.DOA.Width = 85
        '
        'ServiceDT
        '
        Me.ServiceDT.Text = "Service DT"
        Me.ServiceDT.Width = 91
        '
        'BillID
        '
        Me.BillID.Text = "Bill #"
        Me.BillID.Width = 66
        '
        'BillDT
        '
        Me.BillDT.Text = "Bill DT"
        Me.BillDT.Width = 108
        '
        'Status
        '
        Me.Status.Text = "Status"
        Me.Status.Width = 73
        '
        'Amt
        '
        Me.Amt.Text = "Amt $"
        Me.Amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Amt.Width = 72
        '
        'PaidAmount
        '
        Me.PaidAmount.Text = "Paid Amt $"
        Me.PaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.PaidAmount.Width = 85
        '
        'Balance
        '
        Me.Balance.Text = "Balance $"
        Me.Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Index Number"
        '
        'Insurance
        '
        Me.Insurance.Text = "Insurance"
        '
        'Adjuster
        '
        Me.Adjuster.Text = "Adjuster"
        '
        'AdjusterContact
        '
        Me.AdjusterContact.Text = "Adjuster Contact"
        '
        'PatientAttorney
        '
        Me.PatientAttorney.Text = "Patient Attorney"
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "Lien Attorney"
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "Lien Date"
        '
        'ColumnHeader31
        '
        Me.ColumnHeader31.Text = "BillToPatient DT"
        '
        'ColumnHeader35
        '
        Me.ColumnHeader35.Text = "Denials"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Controls.Add(Me.lblCaption)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(741, 20)
        Me.Panel4.TabIndex = 17
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.BackColor = System.Drawing.Color.Transparent
        Me.lblCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblCaption.Location = New System.Drawing.Point(5, 4)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(148, 13)
        Me.lblCaption.TabIndex = 1
        Me.lblCaption.Text = "BILLS SEARCH RESULT"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.RadioButton2)
        Me.Panel3.Controls.Add(Me.RadioButton1)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.cboCollector)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 108)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(741, 25)
        Me.Panel3.TabIndex = 18
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(714, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(22, 18)
        Me.Button2.TabIndex = 275
        Me.ToolTip1.SetToolTip(Me.Button2, "Refresh Reminders")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(225, 4)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(66, 17)
        Me.RadioButton2.TabIndex = 274
        Me.RadioButton2.Text = "Show All"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(106, 4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(113, 17)
        Me.RadioButton1.TabIndex = 273
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Show Current Only"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(344, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 272
        Me.Label8.Text = "Filter By Collector"
        '
        'cboCollector
        '
        Me.cboCollector.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCollector.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCollector.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCollector.ForeColor = System.Drawing.Color.Black
        Me.cboCollector.FormattingEnabled = True
        Me.cboCollector.IntegralHeight = False
        Me.cboCollector.ItemHeight = 13
        Me.cboCollector.Location = New System.Drawing.Point(438, 2)
        Me.cboCollector.Name = "cboCollector"
        Me.cboCollector.Size = New System.Drawing.Size(275, 21)
        Me.cboCollector.TabIndex = 271
        Me.ToolTip1.SetToolTip(Me.cboCollector, "Filter By Collector")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(5, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "REMINDERS"
        '
        'PanelDetails
        '
        Me.PanelDetails.Controls.Add(Me.TabControl1)
        Me.PanelDetails.Controls.Add(Me.ListViewDetails)
        Me.PanelDetails.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelDetails.Location = New System.Drawing.Point(746, 108)
        Me.PanelDetails.Name = "PanelDetails"
        Me.PanelDetails.Size = New System.Drawing.Size(338, 504)
        Me.PanelDetails.TabIndex = 20
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 211)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(338, 293)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TabControl1.TabIndex = 23
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ListViewActions)
        Me.TabPage1.Controls.Add(Me.txtAction)
        Me.TabPage1.Controls.Add(Me.ToolStrip3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 40)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(330, 249)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Collection Notes / Reminders"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ListViewActions
        '
        Me.ListViewActions.BackColor = System.Drawing.Color.White
        Me.ListViewActions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader13, Me.ColumnHeader16, Me.ColumnHeader27})
        Me.ListViewActions.ContextMenuStrip = Me.ContextMenuStripAction
        Me.ListViewActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewActions.FullRowSelect = True
        Me.ListViewActions.GridLines = True
        Me.ListViewActions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewActions.HideSelection = False
        Me.ListViewActions.Location = New System.Drawing.Point(3, 28)
        Me.ListViewActions.MultiSelect = False
        Me.ListViewActions.Name = "ListViewActions"
        Me.ListViewActions.ShowItemToolTips = True
        Me.ListViewActions.Size = New System.Drawing.Size(324, 80)
        Me.ListViewActions.TabIndex = 17
        Me.ListViewActions.UseCompatibleStateImageBehavior = False
        Me.ListViewActions.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Date"
        Me.ColumnHeader13.Width = 91
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "By"
        Me.ColumnHeader16.Width = 120
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "Reminder"
        Me.ColumnHeader27.Width = 80
        '
        'txtAction
        '
        Me.txtAction.BackColor = System.Drawing.Color.White
        Me.txtAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAction.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtAction.Location = New System.Drawing.Point(3, 108)
        Me.txtAction.Multiline = True
        Me.txtAction.Name = "txtAction"
        Me.txtAction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAction.Size = New System.Drawing.Size(324, 138)
        Me.txtAction.TabIndex = 22
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.ToolStripButton9, Me.ToolStripButtonComplete, Me.ToolStripButtonAction})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(324, 25)
        Me.ToolStrip3.TabIndex = 16
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(111, 22)
        Me.ToolStripLabel2.Text = "NOTES / REMINDERS"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton9.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButton9.Text = "Show"
        Me.ToolStripButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButton9.ToolTipText = "Show Document"
        '
        'ToolStripButtonComplete
        '
        Me.ToolStripButtonComplete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonComplete.Image = CType(resources.GetObject("ToolStripButtonComplete.Image"), System.Drawing.Image)
        Me.ToolStripButtonComplete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonComplete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonComplete.Name = "ToolStripButtonComplete"
        Me.ToolStripButtonComplete.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripButtonComplete.Text = "Complete"
        Me.ToolStripButtonComplete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButtonComplete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButtonComplete.ToolTipText = "Reminder Complete"
        '
        'ToolStripButtonAction
        '
        Me.ToolStripButtonAction.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonAction.Image = CType(resources.GetObject("ToolStripButtonAction.Image"), System.Drawing.Image)
        Me.ToolStripButtonAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButtonAction.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonAction.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAction.Name = "ToolStripButtonAction"
        Me.ToolStripButtonAction.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.ToolStripButtonAction.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripButtonAction.Text = "Add"
        Me.ToolStripButtonAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButtonAction.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButtonAction.ToolTipText = "Add Note / Reminder"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListViewRequests)
        Me.TabPage2.Controls.Add(Me.ToolStrip9)
        Me.TabPage2.Controls.Add(Me.ListViewPayments)
        Me.TabPage2.Controls.Add(Me.ToolStrip4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 40)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(330, 249)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Bill Info"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListViewRequests
        '
        Me.ListViewRequests.BackColor = System.Drawing.Color.White
        Me.ListViewRequests.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24})
        Me.ListViewRequests.ContextMenuStrip = Me.ContextMenuStripRequest
        Me.ListViewRequests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewRequests.FullRowSelect = True
        Me.ListViewRequests.GridLines = True
        Me.ListViewRequests.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewRequests.HideSelection = False
        Me.ListViewRequests.Location = New System.Drawing.Point(3, 155)
        Me.ListViewRequests.MultiSelect = False
        Me.ListViewRequests.Name = "ListViewRequests"
        Me.ListViewRequests.Size = New System.Drawing.Size(324, 91)
        Me.ListViewRequests.TabIndex = 11
        Me.ListViewRequests.UseCompatibleStateImageBehavior = False
        Me.ListViewRequests.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Date"
        Me.ColumnHeader22.Width = 79
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Status"
        Me.ColumnHeader23.Width = 57
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Request"
        Me.ColumnHeader24.Width = 165
        '
        'ContextMenuStripRequest
        '
        Me.ContextMenuStripRequest.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3})
        Me.ContextMenuStripRequest.Name = "ContextMenuStripRequest"
        Me.ContextMenuStripRequest.Size = New System.Drawing.Size(139, 26)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.AutoSize = False
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripButton3.Text = "Add request"
        Me.ToolStripButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButton3.ToolTipText = "Add Request"
        '
        'ToolStrip9
        '
        Me.ToolStrip9.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip9.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip9.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel8, Me.ToolStripButtonBillRequests})
        Me.ToolStrip9.Location = New System.Drawing.Point(3, 130)
        Me.ToolStrip9.Name = "ToolStrip9"
        Me.ToolStrip9.Size = New System.Drawing.Size(324, 25)
        Me.ToolStrip9.TabIndex = 21
        Me.ToolStrip9.Text = "ToolStrip9"
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel8.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(89, 22)
        Me.ToolStripLabel8.Text = "BILL REQUESTS"
        Me.ToolStripLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripButtonBillRequests
        '
        Me.ToolStripButtonBillRequests.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonBillRequests.AutoSize = False
        Me.ToolStripButtonBillRequests.Image = CType(resources.GetObject("ToolStripButtonBillRequests.Image"), System.Drawing.Image)
        Me.ToolStripButtonBillRequests.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonBillRequests.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonBillRequests.Name = "ToolStripButtonBillRequests"
        Me.ToolStripButtonBillRequests.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripButtonBillRequests.Text = "Add request"
        Me.ToolStripButtonBillRequests.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButtonBillRequests.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButtonBillRequests.ToolTipText = "Add Request"
        '
        'ListViewPayments
        '
        Me.ListViewPayments.BackColor = System.Drawing.Color.White
        Me.ListViewPayments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PaymentDT, Me.Amount, Me.ColumnHeader21})
        Me.ListViewPayments.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListViewPayments.FullRowSelect = True
        Me.ListViewPayments.GridLines = True
        Me.ListViewPayments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewPayments.HideSelection = False
        Me.ListViewPayments.Location = New System.Drawing.Point(3, 28)
        Me.ListViewPayments.MultiSelect = False
        Me.ListViewPayments.Name = "ListViewPayments"
        Me.ListViewPayments.ShowItemToolTips = True
        Me.ListViewPayments.Size = New System.Drawing.Size(324, 102)
        Me.ListViewPayments.TabIndex = 4
        Me.ListViewPayments.UseCompatibleStateImageBehavior = False
        Me.ListViewPayments.View = System.Windows.Forms.View.Details
        '
        'PaymentDT
        '
        Me.PaymentDT.Text = "Date"
        Me.PaymentDT.Width = 78
        '
        'Amount
        '
        Me.Amount.Text = "Amount"
        Me.Amount.Width = 81
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Check #"
        Me.ColumnHeader21.Width = 142
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel5, Me.ToolStripButton10})
        Me.ToolStrip4.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(324, 25)
        Me.ToolStrip4.TabIndex = 3
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel5.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(91, 22)
        Me.ToolStripLabel5.Text = "BILL PAYMENTS"
        Me.ToolStripLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton10.AutoSize = False
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripButton10.Text = "Add Payment"
        Me.ToolStripButton10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.TreeViewBills)
        Me.TabPage4.Controls.Add(Me.ToolStrip7)
        Me.TabPage4.Location = New System.Drawing.Point(4, 40)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(330, 249)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Patient's Bills"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TreeViewBills
        '
        Me.TreeViewBills.BackColor = System.Drawing.Color.White
        Me.TreeViewBills.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewBills.FullRowSelect = True
        Me.TreeViewBills.HideSelection = False
        Me.TreeViewBills.ImageKey = "2"
        Me.TreeViewBills.Indent = 12
        Me.TreeViewBills.Location = New System.Drawing.Point(0, 25)
        Me.TreeViewBills.Name = "TreeViewBills"
        Me.TreeViewBills.ShowNodeToolTips = True
        Me.TreeViewBills.Size = New System.Drawing.Size(330, 224)
        Me.TreeViewBills.TabIndex = 1
        '
        'ToolStrip7
        '
        Me.ToolStrip7.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip7.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip7.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel6, Me.ToolStripButtonShowBill})
        Me.ToolStrip7.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip7.Name = "ToolStrip7"
        Me.ToolStrip7.Size = New System.Drawing.Size(330, 25)
        Me.ToolStrip7.TabIndex = 18
        Me.ToolStrip7.Text = "ToolStrip7"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel6.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(84, 22)
        Me.ToolStripLabel6.Text = "PATIENT BILLS"
        Me.ToolStripLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripButtonShowBill
        '
        Me.ToolStripButtonShowBill.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonShowBill.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButtonShowBill.Image = CType(resources.GetObject("ToolStripButtonShowBill.Image"), System.Drawing.Image)
        Me.ToolStripButtonShowBill.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonShowBill.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonShowBill.Name = "ToolStripButtonShowBill"
        Me.ToolStripButtonShowBill.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripButtonShowBill.Text = "Find Bill"
        Me.ToolStripButtonShowBill.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButtonShowBill.ToolTipText = "Show Document"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.txtPatientComments)
        Me.TabPage5.Controls.Add(Me.ToolStrip8)
        Me.TabPage5.Location = New System.Drawing.Point(4, 40)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(330, 249)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Patient Comments"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'txtPatientComments
        '
        Me.txtPatientComments.BackColor = System.Drawing.Color.White
        Me.txtPatientComments.ContextMenuStrip = Me.ContextMenuStripComments
        Me.txtPatientComments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPatientComments.Location = New System.Drawing.Point(0, 25)
        Me.txtPatientComments.Multiline = True
        Me.txtPatientComments.Name = "txtPatientComments"
        Me.txtPatientComments.ReadOnly = True
        Me.txtPatientComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPatientComments.Size = New System.Drawing.Size(330, 224)
        Me.txtPatientComments.TabIndex = 24
        '
        'ContextMenuStripComments
        '
        Me.ContextMenuStripComments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ContextMenuStripComments.Name = "ContextMenuStripComments"
        Me.ContextMenuStripComments.Size = New System.Drawing.Size(104, 26)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripButton1.Text = "Show"
        Me.ToolStripButton1.ToolTipText = "Show Document"
        '
        'ToolStrip8
        '
        Me.ToolStrip8.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip8.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip8.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel7, Me.ToolStripButtonPatientComments})
        Me.ToolStrip8.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip8.Name = "ToolStrip8"
        Me.ToolStrip8.Size = New System.Drawing.Size(330, 25)
        Me.ToolStrip8.TabIndex = 23
        Me.ToolStrip8.Text = "ToolStrip8"
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel7.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripLabel7.Text = "PATIENT QUICK NOTES"
        Me.ToolStripLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripButtonPatientComments
        '
        Me.ToolStripButtonPatientComments.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonPatientComments.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButtonPatientComments.Image = CType(resources.GetObject("ToolStripButtonPatientComments.Image"), System.Drawing.Image)
        Me.ToolStripButtonPatientComments.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonPatientComments.Name = "ToolStripButtonPatientComments"
        Me.ToolStripButtonPatientComments.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButtonPatientComments.Text = "Show"
        Me.ToolStripButtonPatientComments.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButtonPatientComments.ToolTipText = "Show Document"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.PanelDocumentWait)
        Me.TabPage3.Controls.Add(Me.RichTextBox1)
        Me.TabPage3.Controls.Add(Me.pdfViewer)
        Me.TabPage3.Controls.Add(Me.ListViewDocs)
        Me.TabPage3.Controls.Add(Me.ToolStrip6)
        Me.TabPage3.Location = New System.Drawing.Point(4, 40)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(330, 249)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Documents"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'PanelDocumentWait
        '
        Me.PanelDocumentWait.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelDocumentWait.BackColor = System.Drawing.Color.White
        Me.PanelDocumentWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDocumentWait.Controls.Add(Me.PictureBox6)
        Me.PanelDocumentWait.Controls.Add(Me.PictureBox7)
        Me.PanelDocumentWait.Controls.Add(Me.Label123)
        Me.PanelDocumentWait.Location = New System.Drawing.Point(57, 78)
        Me.PanelDocumentWait.Name = "PanelDocumentWait"
        Me.PanelDocumentWait.Size = New System.Drawing.Size(216, 35)
        Me.PanelDocumentWait.TabIndex = 377
        Me.PanelDocumentWait.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(26, 23)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox6.TabIndex = 2
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PictureBox7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox7.Location = New System.Drawing.Point(0, 23)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(214, 10)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox7.TabIndex = 1
        Me.PictureBox7.TabStop = False
        '
        'Label123
        '
        Me.Label123.BackColor = System.Drawing.Color.Transparent
        Me.Label123.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label123.ForeColor = System.Drawing.Color.Black
        Me.Label123.Location = New System.Drawing.Point(27, 5)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(182, 13)
        Me.Label123.TabIndex = 0
        Me.Label123.Text = "Loading Document. Please Wait..."
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 165)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.ShowSelectionMargin = True
        Me.RichTextBox1.Size = New System.Drawing.Size(330, 84)
        Me.RichTextBox1.TabIndex = 371
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.Visible = False
        '
        'pdfViewer
        '
        Me.pdfViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfViewer.Location = New System.Drawing.Point(0, 165)
        Me.pdfViewer.Name = "pdfViewer"
        Me.pdfViewer.ShowBookmarks = False
        Me.pdfViewer.ShowToolbar = False
        Me.pdfViewer.Size = New System.Drawing.Size(330, 84)
        Me.pdfViewer.TabIndex = 370
        Me.pdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitBest
        '
        'ListViewDocs
        '
        Me.ListViewDocs.AllowColumnReorder = True
        Me.ListViewDocs.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewDocs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader25, Me.ColumnHeader26})
        Me.ListViewDocs.ContextMenuStrip = Me.ContextMenuStripDocument
        Me.ListViewDocs.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListViewDocs.FullRowSelect = True
        Me.ListViewDocs.GridLines = True
        Me.ListViewDocs.HideSelection = False
        Me.ListViewDocs.LargeImageList = Me.ImageList1
        Me.ListViewDocs.Location = New System.Drawing.Point(0, 25)
        Me.ListViewDocs.MultiSelect = False
        Me.ListViewDocs.Name = "ListViewDocs"
        Me.ListViewDocs.Size = New System.Drawing.Size(330, 140)
        Me.ListViewDocs.SmallImageList = Me.ImageList1
        Me.ListViewDocs.TabIndex = 3
        Me.ListViewDocs.UseCompatibleStateImageBehavior = False
        Me.ListViewDocs.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "Document Name"
        Me.ColumnHeader25.Width = 200
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "Date"
        Me.ColumnHeader26.Width = 108
        '
        'ContextMenuStripDocument
        '
        Me.ContextMenuStripDocument.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowDocumentToolStripMenuItem})
        Me.ContextMenuStripDocument.Name = "ContextMenuStripDocument"
        Me.ContextMenuStripDocument.Size = New System.Drawing.Size(163, 26)
        '
        'ShowDocumentToolStripMenuItem
        '
        Me.ShowDocumentToolStripMenuItem.Image = CType(resources.GetObject("ShowDocumentToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ShowDocumentToolStripMenuItem.Name = "ShowDocumentToolStripMenuItem"
        Me.ShowDocumentToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ShowDocumentToolStripMenuItem.Text = "Show Document"
        '
        'ToolStrip6
        '
        Me.ToolStrip6.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip6.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip6.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.ToolStripButtonDocuments, Me.ButtonScannDocument, Me.ToolStripButton5})
        Me.ToolStrip6.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip6.Name = "ToolStrip6"
        Me.ToolStrip6.Size = New System.Drawing.Size(330, 25)
        Me.ToolStrip6.TabIndex = 17
        Me.ToolStrip6.Text = "ToolStrip6"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel4.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripLabel4.Text = "DOCUMENTS"
        Me.ToolStripLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripButtonDocuments
        '
        Me.ToolStripButtonDocuments.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonDocuments.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButtonDocuments.Image = CType(resources.GetObject("ToolStripButtonDocuments.Image"), System.Drawing.Image)
        Me.ToolStripButtonDocuments.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonDocuments.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDocuments.Name = "ToolStripButtonDocuments"
        Me.ToolStripButtonDocuments.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButtonDocuments.Text = "Show"
        Me.ToolStripButtonDocuments.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButtonDocuments.ToolTipText = "Show Document"
        '
        'ButtonScannDocument
        '
        Me.ButtonScannDocument.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ButtonScannDocument.Image = CType(resources.GetObject("ButtonScannDocument.Image"), System.Drawing.Image)
        Me.ButtonScannDocument.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonScannDocument.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonScannDocument.Name = "ButtonScannDocument"
        Me.ButtonScannDocument.Size = New System.Drawing.Size(76, 22)
        Me.ButtonScannDocument.Text = "Scan Doc"
        Me.ButtonScannDocument.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ButtonScannDocument.ToolTipText = "Scan Document"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripButton5.Text = "Library"
        Me.ToolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.ListViewBillToPatient)
        Me.TabPage6.Controls.Add(Me.ToolStrip1)
        Me.TabPage6.Location = New System.Drawing.Point(4, 40)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(330, 249)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Bills To Patient"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'ListViewBillToPatient
        '
        Me.ListViewBillToPatient.BackColor = System.Drawing.Color.White
        Me.ListViewBillToPatient.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader33, Me.ColumnHeader32, Me.ColumnHeader34})
        Me.ListViewBillToPatient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewBillToPatient.FullRowSelect = True
        Me.ListViewBillToPatient.GridLines = True
        Me.ListViewBillToPatient.HideSelection = False
        Me.ListViewBillToPatient.LargeImageList = Me.ImageList1
        Me.ListViewBillToPatient.Location = New System.Drawing.Point(0, 25)
        Me.ListViewBillToPatient.MultiSelect = False
        Me.ListViewBillToPatient.Name = "ListViewBillToPatient"
        Me.ListViewBillToPatient.ShowItemToolTips = True
        Me.ListViewBillToPatient.Size = New System.Drawing.Size(330, 224)
        Me.ListViewBillToPatient.TabIndex = 5
        Me.ListViewBillToPatient.UseCompatibleStateImageBehavior = False
        Me.ListViewBillToPatient.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader33
        '
        Me.ColumnHeader33.Text = "Bill #"
        '
        'ColumnHeader32
        '
        Me.ColumnHeader32.Text = "Date"
        Me.ColumnHeader32.Width = 143
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "By"
        Me.ColumnHeader34.Width = 127
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(330, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(95, 22)
        Me.ToolStripLabel1.Text = "BILL TO PATIENT"
        Me.ToolStripLabel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.AutoSize = False
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripButton2.Text = "Bill To Patient"
        Me.ToolStripButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.ListViewDenials)
        Me.TabPage7.Controls.Add(Me.txtDenialComments)
        Me.TabPage7.Controls.Add(Me.ToolStrip5)
        Me.TabPage7.Location = New System.Drawing.Point(4, 40)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(330, 249)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Bill Denials"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'ListViewDenials
        '
        Me.ListViewDenials.BackColor = System.Drawing.Color.White
        Me.ListViewDenials.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader36, Me.ColumnHeader37, Me.ColumnHeader38})
        Me.ListViewDenials.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewDenials.FullRowSelect = True
        Me.ListViewDenials.GridLines = True
        Me.ListViewDenials.HideSelection = False
        Me.ListViewDenials.LargeImageList = Me.ImageList1
        Me.ListViewDenials.Location = New System.Drawing.Point(0, 25)
        Me.ListViewDenials.MultiSelect = False
        Me.ListViewDenials.Name = "ListViewDenials"
        Me.ListViewDenials.ShowItemToolTips = True
        Me.ListViewDenials.Size = New System.Drawing.Size(330, 164)
        Me.ListViewDenials.TabIndex = 5
        Me.ListViewDenials.UseCompatibleStateImageBehavior = False
        Me.ListViewDenials.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader36
        '
        Me.ColumnHeader36.Text = "Proc"
        '
        'ColumnHeader37
        '
        Me.ColumnHeader37.Text = "Date"
        Me.ColumnHeader37.Width = 122
        '
        'ColumnHeader38
        '
        Me.ColumnHeader38.Text = "Comment"
        Me.ColumnHeader38.Width = 127
        '
        'txtDenialComments
        '
        Me.txtDenialComments.BackColor = System.Drawing.Color.White
        Me.txtDenialComments.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtDenialComments.Location = New System.Drawing.Point(0, 189)
        Me.txtDenialComments.Multiline = True
        Me.txtDenialComments.Name = "txtDenialComments"
        Me.txtDenialComments.Size = New System.Drawing.Size(330, 60)
        Me.txtDenialComments.TabIndex = 8
        '
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(330, 25)
        Me.ToolStrip5.TabIndex = 4
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel3.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripLabel3.Text = "BILL DENIALS"
        Me.ToolStripLabel3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ListViewDetails
        '
        Me.ListViewDetails.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader8})
        Me.ListViewDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListViewDetails.FullRowSelect = True
        Me.ListViewDetails.GridLines = True
        Me.ListViewDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewDetails.HideSelection = False
        Me.ListViewDetails.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12})
        Me.ListViewDetails.Location = New System.Drawing.Point(0, 0)
        Me.ListViewDetails.Name = "ListViewDetails"
        Me.ListViewDetails.Scrollable = False
        Me.ListViewDetails.ShowGroups = False
        Me.ListViewDetails.ShowItemToolTips = True
        Me.ListViewDetails.Size = New System.Drawing.Size(338, 211)
        Me.ListViewDetails.TabIndex = 15
        Me.ListViewDetails.UseCompatibleStateImageBehavior = False
        Me.ListViewDetails.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Width = 216
        '
        'ContextMenuStripNotes
        '
        Me.ContextMenuStripNotes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripButton6})
        Me.ContextMenuStripNotes.Name = "ContextMenuStripNotes"
        Me.ContextMenuStripNotes.Size = New System.Drawing.Size(126, 54)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripButton4.Text = "Show"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButton4.ToolTipText = "Show Bill Notes"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(122, 6)
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripButton6.Text = "Add Note"
        Me.ToolStripButton6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButton6.ToolTipText = "Add Bill Notes"
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(741, 108)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(5, 504)
        Me.Panel2.TabIndex = 21
        '
        'TimerRefresh
        '
        '
        'StatusStrip1
        '
        Me.StatusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabelFound, Me.ToolStripLabelReminders, Me.ToolStripStatusLabelPatName})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 590)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(741, 22)
        Me.StatusStrip1.TabIndex = 24
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripLabelFound
        '
        Me.ToolStripLabelFound.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabelFound.AutoSize = False
        Me.ToolStripLabelFound.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripLabelFound.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripLabelFound.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripLabelFound.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.ToolStripLabelFound.Name = "ToolStripLabelFound"
        Me.ToolStripLabelFound.Size = New System.Drawing.Size(100, 19)
        Me.ToolStripLabelFound.Text = "      "
        Me.ToolStripLabelFound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripLabelReminders
        '
        Me.ToolStripLabelReminders.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabelReminders.AutoSize = False
        Me.ToolStripLabelReminders.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripLabelReminders.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripLabelReminders.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripLabelReminders.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.ToolStripLabelReminders.Name = "ToolStripLabelReminders"
        Me.ToolStripLabelReminders.Size = New System.Drawing.Size(100, 19)
        Me.ToolStripLabelReminders.Text = "      "
        Me.ToolStripLabelReminders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabelPatName
        '
        Me.ToolStripStatusLabelPatName.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabelPatName.Name = "ToolStripStatusLabelPatName"
        Me.ToolStripStatusLabelPatName.Size = New System.Drawing.Size(25, 17)
        Me.ToolStripStatusLabelPatName.Text = "      "
        '
        'TimerLoadData
        '
        Me.TimerLoadData.Interval = 500
        '
        'PanelTop
        '
        Me.PanelTop.BackgroundImage = CType(resources.GetObject("PanelTop.BackgroundImage"), System.Drawing.Image)
        Me.PanelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelTop.Controls.Add(Me.Label23)
        Me.PanelTop.Controls.Add(Me.Label22)
        Me.PanelTop.Controls.Add(Me.PictureBox1)
        Me.PanelTop.Controls.Add(Me.Panel1)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1084, 39)
        Me.PanelTop.TabIndex = 128
        Me.PanelTop.Visible = False
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label23.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(0, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(158, 36)
        Me.Label23.TabIndex = 115
        Me.Label23.Text = "eMEDICAL OFFICE"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(932, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(109, 36)
        Me.Label22.TabIndex = 111
        Me.Label22.Text = "COLLECTION"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1041, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(43, 36)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 112
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.ForeColor = System.Drawing.Color.DarkOrange
        Me.Panel1.Location = New System.Drawing.Point(0, 36)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1084, 3)
        Me.Panel1.TabIndex = 113
        '
        'TimerGetReminderDetails
        '
        Me.TimerGetReminderDetails.Interval = 500
        '
        'frmBillingCollection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 612)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PanelDetails)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.PanelTop)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1100, 650)
        Me.Name = "frmBillingCollection"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Collection"
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ContextMenuStripCustomizeToolStrip.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ContextMenuStripAction.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ContextMenuStripMain.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.PanelDetails.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ContextMenuStripRequest.ResumeLayout(False)
        Me.ToolStrip9.ResumeLayout(False)
        Me.ToolStrip9.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ToolStrip7.ResumeLayout(False)
        Me.ToolStrip7.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ContextMenuStripComments.ResumeLayout(False)
        Me.ToolStrip8.ResumeLayout(False)
        Me.ToolStrip8.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.PanelDocumentWait.ResumeLayout(False)
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripDocument.ResumeLayout(False)
        Me.ToolStrip6.ResumeLayout(False)
        Me.ToolStrip6.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ContextMenuStripNotes.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.PanelTop.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripAutoResize As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtPatient As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBillNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboBillingProvider As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboAttorneysCompanyID As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents cboInsuranceCompanyID As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents cboDays As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonFind As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PatientNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents PatientName As System.Windows.Forms.ColumnHeader
    Friend WithEvents DOA As System.Windows.Forms.ColumnHeader
    Friend WithEvents ServiceDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents BillID As System.Windows.Forms.ColumnHeader
    Friend WithEvents BillDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents Status As System.Windows.Forms.ColumnHeader
    Friend WithEvents Amt As System.Windows.Forms.ColumnHeader
    Friend WithEvents PaidAmount As System.Windows.Forms.ColumnHeader
    Friend WithEvents Balance As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents PanelDetails As System.Windows.Forms.Panel
    Friend WithEvents ListViewActions As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButtonAction As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListViewDetails As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents cboBillStatus As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtAction As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCollector As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ListViewPayments As System.Windows.Forms.ListView
    Friend WithEvents PaymentDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents Amount As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ListViewRequests As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip6 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ListViewDocs As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents ToolStripButtonDocuments As System.Windows.Forms.ToolStripButton
    Friend WithEvents TreeViewBills As System.Windows.Forms.TreeView
    Friend WithEvents ToolStrip7 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip9 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel8 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButtonBillRequests As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStripDocument As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripRequest As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripNotes As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripAction As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripComments As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButtonShowBill As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStripMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PopUpMenuItemShowPatient As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem27 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem28 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PopUpButtonAddAction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonScannDocument As System.Windows.Forms.ToolStripButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents TimerRefresh As System.Windows.Forms.Timer
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader27 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripReminderComplete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripReminderSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripMenuActionComplete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripActionSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtPatientComments As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip8 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel7 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButtonPatientComments As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonComplete As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuSelectedBillPayment1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemAction As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItemRequest As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItemPatient As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripTools As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuPrinting2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintCheckedBills2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintCheckedEnvelopes2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintCheckedBillsReadingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintSelectedFileLabel2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintResultListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintAll1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintCheckedOnly1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportCheckedToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportAllToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparatorAdmin As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CollectionStatisticsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CachedrptCoverPage1 As eMedicalOffice.CachedrptCoverPage
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripLabelFound As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLabelReminders As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelPatName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ListViewReminders As eMedicalOffice.clsListView
    Friend WithEvents ListViewPatients As eMedicalOffice.clsListView
    Friend WithEvents ToolStripButtonCloseForm As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents ContextMenuStripCustomizeToolStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CustomizeToolbarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerLoadData As System.Windows.Forms.Timer
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Insurance As System.Windows.Forms.ColumnHeader
    Friend WithEvents Adjuster As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
    Friend WithEvents AdjusterContact As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripMenuUpdateAdjusterInformation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtAdjuster As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuFilterByAdjuster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemItemizedCharges As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatientAttorney As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripFontIncrease As ToolStripButton
    Friend WithEvents ToolStripFonrDecrease As ToolStripButton
    Friend WithEvents pdfViewer As PdfiumViewer.PdfViewer
    Friend WithEvents mnuPrintBillProgress As ToolStripMenuItem
    Friend WithEvents BillToPatientToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader29 As ColumnHeader
    Friend WithEvents ColumnHeader30 As ColumnHeader
    Friend WithEvents ColumnHeader31 As ColumnHeader
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ListViewBillToPatient As ListView
    Friend WithEvents ColumnHeader33 As ColumnHeader
    Friend WithEvents ColumnHeader32 As ColumnHeader
    Friend WithEvents ColumnHeader34 As ColumnHeader
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Public WithEvents ToolStripButtonDetach As ToolStripButton
    Friend WithEvents Label22 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem12 As ToolStripMenuItem
    Public WithEvents PanelTop As Panel
    Friend WithEvents Label23 As Label
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem17 As ToolStripMenuItem
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents TimerGetReminderDetails As Timer
    Friend WithEvents ColumnHeader35 As ColumnHeader
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents ListViewDenials As ListView
    Friend WithEvents ColumnHeader36 As ColumnHeader
    Friend WithEvents ColumnHeader37 As ColumnHeader
    Friend WithEvents ColumnHeader38 As ColumnHeader
    Friend WithEvents txtDenialComments As TextBox
    Friend WithEvents ToolStrip5 As ToolStrip
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents PanelDocumentWait As Panel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Label123 As Label
End Class
