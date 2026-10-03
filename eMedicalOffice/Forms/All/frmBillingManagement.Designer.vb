<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBillingManagement
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
        Dim frm As Form
Retry:
        Try
            FormsCollection.Forms.Remove(Me)
        Catch ex As Exception

        End Try

        'For Each frm In FormsCollection.Forms
        '    If frm.Name = Me.Name Then
        '        FormsCollection.Forms.Remove(frm)
        '        GoTo Retry
        '    End If
        'Next
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBillingManagement))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuShowSelectedPatientInfo1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem17 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator51 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuUpdateAdjusterInformation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrinting1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintCheckedBills1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintCheckedEnvelopes1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintCheckedBillsReadingsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintSelectedFileLabel1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPrintCover = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintBillProgress = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrintResultList = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintAll2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintCheckedOnly2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBillingTools1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem18 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator52 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrintCheckedBills3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EFileSelectedBillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrintSelectedBillReadings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.BillToPatientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator38 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteBillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparatorSendToAttorneyToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPOM1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintCheckedPOM1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuProcessSelectedPOM1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuShowSelectedPOM1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFindPOM1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAttorney1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSendToAttorney1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoveBillFromAttorney1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearAttorneyCaseNumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuReprintCoverpage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator46 = New System.Windows.Forms.ToolStripSeparator()
        Me.AttorneyFeesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator48 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportAttorneyDocumentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator35 = New System.Windows.Forms.ToolStripSeparator()
        Me.AssignLienAttorneyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemItemizedCharges = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCollection1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectedBillPayment1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAddSelectedBillNotes2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator33 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBillDenied1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator40 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemRequest = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdminToolsToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.AdminToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeBillDateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeBillStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeBillAmountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangePaymentAmountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator43 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuReProduceSelectedBill1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator42 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteSelectedBillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCaseTypeID = New System.Windows.Forms.ComboBox()
        Me.txtPatient = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPaymentNote = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DateTimePickerAttorneyTo = New System.Windows.Forms.DateTimePicker()
        Me.cboAttorneysCompanyID = New System.Windows.Forms.ComboBox()
        Me.cboBillingProvider = New System.Windows.Forms.ComboBox()
        Me.cboInsuranceCompanyID = New System.Windows.Forms.ComboBox()
        Me.DateTimePaymentFrom = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboDiagnostic = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DateTimePaymentTo = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DateTimePickerAttorneyFrom = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboBillingCompany = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBillNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ButtonDetails = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PanelShowBills = New System.Windows.Forms.Panel()
        Me.RadioButtonF1 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonF2 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonF3 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonF4 = New System.Windows.Forms.RadioButton()
        Me.ButtonFind = New System.Windows.Forms.Button()
        Me.cboBillStatus = New System.Windows.Forms.ComboBox()
        Me.ComboBoxRefOffice = New System.Windows.Forms.ComboBox()
        Me.cboDenial = New System.Windows.Forms.ComboBox()
        Me.PictureBoxClose = New System.Windows.Forms.PictureBox()
        Me.chkPaymentSearch = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PanelBills = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ListViewRequests = New System.Windows.Forms.ListView()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator31 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ListViewPayments = New System.Windows.Forms.ListView()
        Me.PaymentDT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Amount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.TreeViewBills = New System.Windows.Forms.TreeView()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.PanelBillDetails = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ListViewDenials = New System.Windows.Forms.ListView()
        Me.ColumnHeader35 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader36 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader37 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator45 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtDenialComments = New System.Windows.Forms.TextBox()
        Me.ToolStrip7 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ListViewBillToPatient = New System.Windows.Forms.ListView()
        Me.ColumnHeader33 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader32 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip6 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListViewComments = New System.Windows.Forms.ListView()
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.mnuAddSelectedBillNotes1 = New System.Windows.Forms.ToolStripButton()
        Me.txtPatientComments = New System.Windows.Forms.TextBox()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.PanelDocumentWait = New System.Windows.Forms.Panel()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.ListViewDocs = New System.Windows.Forms.ListView()
        Me.ColumnHeader38 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader39 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pdfViewer = New PdfiumViewer.PdfViewer()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ToolStrip8 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonDocuments = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ButtonScannDocument = New System.Windows.Forms.ToolStripButton()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.ListViewPatientComments = New System.Windows.Forms.ListView()
        Me.ColumnHeader40 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader41 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader42 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TextBoxCommentView = New System.Windows.Forms.TextBox()
        Me.TextBoxCommentViewBy = New System.Windows.Forms.TextBox()
        Me.ToolStrip9 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.ButtonAddComments = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ContextMenuStripCustomizeToolStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CustomizeToolbarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator50 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBillingTools2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuShowSelectedPatientInfo2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentsReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindCheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrintSelectedBillReadings2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator32 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteBillToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPOM2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuPrintCheckedPOM2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProcessSelectedPOM2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuShowSelectedPOM2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFindPOM2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAttorney2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuSendToAttorney2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoveBillFromAttorney2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator27 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearAttorneyCaseNumberToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator39 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator41 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuReprintCoverpage1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator47 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCollection2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuSelectedBillPayment2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemTodayPayments = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentsProgressAnalysisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator30 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAddSelectedBillNotes3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator29 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBillDenied2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator36 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemBillingRequest1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator44 = New System.Windows.Forms.ToolStripSeparator()
        Me.CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCloseForm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDetach = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator34 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator37 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator49 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator53 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtoneFile = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
        Me.FpSpreadForPrint = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpreadForPrint_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.SaveFD = New System.Windows.Forms.SaveFileDialog()
        Me.PanelAttention = New System.Windows.Forms.Panel()
        Me.ListViewAttention = New System.Windows.Forms.ListView()
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripWarnings = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemWShiwPatientInformation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemWBillingRequest = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemShowPatientBill = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelAttentionsCount = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TimerCheckWarnings = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListViewPatients = New eMedicalOffice.clsListView()
        Me.PatientNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PatientName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DOA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CaseType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BillID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BillDT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PolicyNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClaimNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Amt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Insurance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ServiceDT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Attorney = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AttorneyDT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.POM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PaidAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Balance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Doctor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AdjusterName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AttorneyCaseNumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader43 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader44 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader45 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboLienAttorney = New eMedicalOffice.AutoCompleteComboBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Process1 = New System.Diagnostics.Process()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelFound = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelChecked = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLabelTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLabelPaidFound = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelBalanceFound = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelDeadDebt = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimerDetails = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ButtonDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelShowBills.SuspendLayout()
        CType(Me.PictureBoxClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBills.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.PanelBillDetails.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ToolStrip7.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.ToolStrip6.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.PanelDocumentWait.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip8.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.ToolStrip9.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ContextMenuStripCustomizeToolStrip.SuspendLayout()
        CType(Me.FpSpreadForPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpreadForPrint_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelAttention.SuspendLayout()
        Me.ContextMenuStripWarnings.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        Me.SuspendLayout()
        ColumnHeaderRenderer1.Name = "ColumnHeaderRenderer1"
        ColumnHeaderRenderer1.TextRotationAngle = 0R
        ColumnHeaderRenderer2.Name = "ColumnHeaderRenderer2"
        ColumnHeaderRenderer2.TextRotationAngle = 0R
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.SelectNoneToolStripMenuItem, Me.ToolStripSeparator28, Me.mnuShowSelectedPatientInfo1, Me.ToolStripSeparator25, Me.ToolStripMenuItem17, Me.ToolStripSeparator51, Me.ToolStripMenuUpdateAdjusterInformation, Me.ToolStripSeparator2, Me.mnuPrinting1, Me.ToolStripSeparator18, Me.mnuBillingTools1, Me.ToolStripSeparatorSendToAttorneyToolStripMenuItem, Me.mnuPOM1, Me.ToolStripSeparator10, Me.mnuAttorney1, Me.ToolStripSeparator1, Me.ToolStripMenuItemItemizedCharges, Me.mnuCollection1, Me.ToolStripMenuItemRequest, Me.AdminToolsToolStripSeparator, Me.AdminToolsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(226, 344)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Image = CType(resources.GetObject("SelectAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.SelectAllToolStripMenuItem.Text = "Check All"
        '
        'SelectNoneToolStripMenuItem
        '
        Me.SelectNoneToolStripMenuItem.Name = "SelectNoneToolStripMenuItem"
        Me.SelectNoneToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.SelectNoneToolStripMenuItem.Text = "Check None"
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(222, 6)
        '
        'mnuShowSelectedPatientInfo1
        '
        Me.mnuShowSelectedPatientInfo1.Image = CType(resources.GetObject("mnuShowSelectedPatientInfo1.Image"), System.Drawing.Image)
        Me.mnuShowSelectedPatientInfo1.Name = "mnuShowSelectedPatientInfo1"
        Me.mnuShowSelectedPatientInfo1.Size = New System.Drawing.Size(225, 22)
        Me.mnuShowSelectedPatientInfo1.Text = "Show Patient's Information"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(222, 6)
        '
        'ToolStripMenuItem17
        '
        Me.ToolStripMenuItem17.Image = CType(resources.GetObject("ToolStripMenuItem17.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem17.Name = "ToolStripMenuItem17"
        Me.ToolStripMenuItem17.Size = New System.Drawing.Size(225, 22)
        Me.ToolStripMenuItem17.Text = "Add Document From Library"
        '
        'ToolStripSeparator51
        '
        Me.ToolStripSeparator51.Name = "ToolStripSeparator51"
        Me.ToolStripSeparator51.Size = New System.Drawing.Size(222, 6)
        '
        'ToolStripMenuUpdateAdjusterInformation
        '
        Me.ToolStripMenuUpdateAdjusterInformation.Image = CType(resources.GetObject("ToolStripMenuUpdateAdjusterInformation.Image"), System.Drawing.Image)
        Me.ToolStripMenuUpdateAdjusterInformation.Name = "ToolStripMenuUpdateAdjusterInformation"
        Me.ToolStripMenuUpdateAdjusterInformation.Size = New System.Drawing.Size(225, 22)
        Me.ToolStripMenuUpdateAdjusterInformation.Text = "Update Adjuster Information"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(222, 6)
        '
        'mnuPrinting1
        '
        Me.mnuPrinting1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrintCheckedBills1, Me.mnuPrintCheckedEnvelopes1, Me.PrintCheckedBillsReadingsToolStripMenuItem1, Me.mnuPrintSelectedFileLabel1, Me.ToolStripMenuItemPrintCover, Me.mnuPrintBillProgress, Me.ToolStripSeparator12, Me.mnuPrintResultList})
        Me.mnuPrinting1.Image = CType(resources.GetObject("mnuPrinting1.Image"), System.Drawing.Image)
        Me.mnuPrinting1.Name = "mnuPrinting1"
        Me.mnuPrinting1.Size = New System.Drawing.Size(225, 22)
        Me.mnuPrinting1.Text = "Printing"
        '
        'mnuPrintCheckedBills1
        '
        Me.mnuPrintCheckedBills1.Image = CType(resources.GetObject("mnuPrintCheckedBills1.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedBills1.Name = "mnuPrintCheckedBills1"
        Me.mnuPrintCheckedBills1.Size = New System.Drawing.Size(343, 22)
        Me.mnuPrintCheckedBills1.Text = "Print Checked/Selected Bills"
        '
        'mnuPrintCheckedEnvelopes1
        '
        Me.mnuPrintCheckedEnvelopes1.Image = CType(resources.GetObject("mnuPrintCheckedEnvelopes1.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedEnvelopes1.Name = "mnuPrintCheckedEnvelopes1"
        Me.mnuPrintCheckedEnvelopes1.Size = New System.Drawing.Size(343, 22)
        Me.mnuPrintCheckedEnvelopes1.Text = "Print Checked/Selected Envelopes"
        '
        'PrintCheckedBillsReadingsToolStripMenuItem1
        '
        Me.PrintCheckedBillsReadingsToolStripMenuItem1.Image = CType(resources.GetObject("PrintCheckedBillsReadingsToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.PrintCheckedBillsReadingsToolStripMenuItem1.Name = "PrintCheckedBillsReadingsToolStripMenuItem1"
        Me.PrintCheckedBillsReadingsToolStripMenuItem1.Size = New System.Drawing.Size(343, 22)
        Me.PrintCheckedBillsReadingsToolStripMenuItem1.Text = "Print Checked/Selected Bills Readings"
        '
        'mnuPrintSelectedFileLabel1
        '
        Me.mnuPrintSelectedFileLabel1.Image = CType(resources.GetObject("mnuPrintSelectedFileLabel1.Image"), System.Drawing.Image)
        Me.mnuPrintSelectedFileLabel1.Name = "mnuPrintSelectedFileLabel1"
        Me.mnuPrintSelectedFileLabel1.Size = New System.Drawing.Size(343, 22)
        Me.mnuPrintSelectedFileLabel1.Text = "Print File Label"
        '
        'ToolStripMenuItemPrintCover
        '
        Me.ToolStripMenuItemPrintCover.Image = CType(resources.GetObject("ToolStripMenuItemPrintCover.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemPrintCover.Name = "ToolStripMenuItemPrintCover"
        Me.ToolStripMenuItemPrintCover.Size = New System.Drawing.Size(343, 22)
        Me.ToolStripMenuItemPrintCover.Text = "Reprint Checked/Selected Bills Attorney Coverpage"
        '
        'mnuPrintBillProgress
        '
        Me.mnuPrintBillProgress.Image = CType(resources.GetObject("mnuPrintBillProgress.Image"), System.Drawing.Image)
        Me.mnuPrintBillProgress.Name = "mnuPrintBillProgress"
        Me.mnuPrintBillProgress.Size = New System.Drawing.Size(343, 22)
        Me.mnuPrintBillProgress.Text = "Print Selected Patient Progress Report"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(340, 6)
        '
        'mnuPrintResultList
        '
        Me.mnuPrintResultList.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrintAll2, Me.mnuPrintCheckedOnly2})
        Me.mnuPrintResultList.Image = CType(resources.GetObject("mnuPrintResultList.Image"), System.Drawing.Image)
        Me.mnuPrintResultList.Name = "mnuPrintResultList"
        Me.mnuPrintResultList.Size = New System.Drawing.Size(343, 22)
        Me.mnuPrintResultList.Text = "Print Result List"
        '
        'mnuPrintAll2
        '
        Me.mnuPrintAll2.Image = CType(resources.GetObject("mnuPrintAll2.Image"), System.Drawing.Image)
        Me.mnuPrintAll2.Name = "mnuPrintAll2"
        Me.mnuPrintAll2.Size = New System.Drawing.Size(176, 22)
        Me.mnuPrintAll2.Text = "Print All"
        '
        'mnuPrintCheckedOnly2
        '
        Me.mnuPrintCheckedOnly2.Image = CType(resources.GetObject("mnuPrintCheckedOnly2.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedOnly2.Name = "mnuPrintCheckedOnly2"
        Me.mnuPrintCheckedOnly2.Size = New System.Drawing.Size(176, 22)
        Me.mnuPrintCheckedOnly2.Text = "Print Checked Only"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(222, 6)
        '
        'mnuBillingTools1
        '
        Me.mnuBillingTools1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem18, Me.ToolStripSeparator52, Me.mnuPrintCheckedBills3, Me.EFileSelectedBillToolStripMenuItem, Me.ToolStripSeparator11, Me.mnuPrintSelectedBillReadings, Me.ToolStripSeparator17, Me.BillToPatientToolStripMenuItem, Me.ToolStripSeparator38, Me.DeleteBillToolStripMenuItem})
        Me.mnuBillingTools1.Image = CType(resources.GetObject("mnuBillingTools1.Image"), System.Drawing.Image)
        Me.mnuBillingTools1.Name = "mnuBillingTools1"
        Me.mnuBillingTools1.Size = New System.Drawing.Size(225, 22)
        Me.mnuBillingTools1.Text = "Billing Tools"
        '
        'ToolStripMenuItem18
        '
        Me.ToolStripMenuItem18.Image = CType(resources.GetObject("ToolStripMenuItem18.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem18.Name = "ToolStripMenuItem18"
        Me.ToolStripMenuItem18.Size = New System.Drawing.Size(223, 22)
        Me.ToolStripMenuItem18.Text = "Payments Report"
        '
        'ToolStripSeparator52
        '
        Me.ToolStripSeparator52.Name = "ToolStripSeparator52"
        Me.ToolStripSeparator52.Size = New System.Drawing.Size(220, 6)
        '
        'mnuPrintCheckedBills3
        '
        Me.mnuPrintCheckedBills3.Image = CType(resources.GetObject("mnuPrintCheckedBills3.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedBills3.Name = "mnuPrintCheckedBills3"
        Me.mnuPrintCheckedBills3.Size = New System.Drawing.Size(223, 22)
        Me.mnuPrintCheckedBills3.Text = "Print Checked/Selected Bills"
        '
        'EFileSelectedBillToolStripMenuItem
        '
        Me.EFileSelectedBillToolStripMenuItem.Image = CType(resources.GetObject("EFileSelectedBillToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EFileSelectedBillToolStripMenuItem.Name = "EFileSelectedBillToolStripMenuItem"
        Me.EFileSelectedBillToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.EFileSelectedBillToolStripMenuItem.Text = "e-File Checked Selected Bills"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(220, 6)
        '
        'mnuPrintSelectedBillReadings
        '
        Me.mnuPrintSelectedBillReadings.Image = CType(resources.GetObject("mnuPrintSelectedBillReadings.Image"), System.Drawing.Image)
        Me.mnuPrintSelectedBillReadings.Name = "mnuPrintSelectedBillReadings"
        Me.mnuPrintSelectedBillReadings.Size = New System.Drawing.Size(223, 22)
        Me.mnuPrintSelectedBillReadings.Text = "Print Selected Bill Readings"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(220, 6)
        '
        'BillToPatientToolStripMenuItem
        '
        Me.BillToPatientToolStripMenuItem.Image = CType(resources.GetObject("BillToPatientToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BillToPatientToolStripMenuItem.Name = "BillToPatientToolStripMenuItem"
        Me.BillToPatientToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.BillToPatientToolStripMenuItem.Text = "Bill To Patient"
        '
        'ToolStripSeparator38
        '
        Me.ToolStripSeparator38.Name = "ToolStripSeparator38"
        Me.ToolStripSeparator38.Size = New System.Drawing.Size(220, 6)
        '
        'DeleteBillToolStripMenuItem
        '
        Me.DeleteBillToolStripMenuItem.Image = CType(resources.GetObject("DeleteBillToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteBillToolStripMenuItem.Name = "DeleteBillToolStripMenuItem"
        Me.DeleteBillToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.DeleteBillToolStripMenuItem.Text = "Delete Selected Bill"
        '
        'ToolStripSeparatorSendToAttorneyToolStripMenuItem
        '
        Me.ToolStripSeparatorSendToAttorneyToolStripMenuItem.Name = "ToolStripSeparatorSendToAttorneyToolStripMenuItem"
        Me.ToolStripSeparatorSendToAttorneyToolStripMenuItem.Size = New System.Drawing.Size(222, 6)
        '
        'mnuPOM1
        '
        Me.mnuPOM1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrintCheckedPOM1, Me.ToolStripSeparator23, Me.mnuProcessSelectedPOM1, Me.ToolStripSeparator5, Me.mnuShowSelectedPOM1, Me.ToolStripSeparator4, Me.mnuFindPOM1})
        Me.mnuPOM1.Image = CType(resources.GetObject("mnuPOM1.Image"), System.Drawing.Image)
        Me.mnuPOM1.Name = "mnuPOM1"
        Me.mnuPOM1.Size = New System.Drawing.Size(225, 22)
        Me.mnuPOM1.Text = "POM"
        '
        'mnuPrintCheckedPOM1
        '
        Me.mnuPrintCheckedPOM1.Image = CType(resources.GetObject("mnuPrintCheckedPOM1.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedPOM1.Name = "mnuPrintCheckedPOM1"
        Me.mnuPrintCheckedPOM1.Size = New System.Drawing.Size(269, 22)
        Me.mnuPrintCheckedPOM1.Text = "Create Checked /  Selected Bills POM"
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(266, 6)
        '
        'mnuProcessSelectedPOM1
        '
        Me.mnuProcessSelectedPOM1.Image = CType(resources.GetObject("mnuProcessSelectedPOM1.Image"), System.Drawing.Image)
        Me.mnuProcessSelectedPOM1.Name = "mnuProcessSelectedPOM1"
        Me.mnuProcessSelectedPOM1.Size = New System.Drawing.Size(269, 22)
        Me.mnuProcessSelectedPOM1.Text = "Process / Scan POM"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(266, 6)
        '
        'mnuShowSelectedPOM1
        '
        Me.mnuShowSelectedPOM1.Image = CType(resources.GetObject("mnuShowSelectedPOM1.Image"), System.Drawing.Image)
        Me.mnuShowSelectedPOM1.Name = "mnuShowSelectedPOM1"
        Me.mnuShowSelectedPOM1.Size = New System.Drawing.Size(269, 22)
        Me.mnuShowSelectedPOM1.Text = "Show Selected Bill POM"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(266, 6)
        '
        'mnuFindPOM1
        '
        Me.mnuFindPOM1.Image = CType(resources.GetObject("mnuFindPOM1.Image"), System.Drawing.Image)
        Me.mnuFindPOM1.Name = "mnuFindPOM1"
        Me.mnuFindPOM1.Size = New System.Drawing.Size(269, 22)
        Me.mnuFindPOM1.Text = "Find POM"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(222, 6)
        '
        'mnuAttorney1
        '
        Me.mnuAttorney1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSendToAttorney1, Me.mnuRemoveBillFromAttorney1, Me.ToolStripSeparator6, Me.ToolStripMenuItem6, Me.ClearAttorneyCaseNumberToolStripMenuItem, Me.ToolStripSeparator16, Me.mnuReprintCoverpage, Me.ToolStripSeparator46, Me.AttorneyFeesToolStripMenuItem, Me.ToolStripSeparator48, Me.ExportAttorneyDocumentsToolStripMenuItem, Me.ToolStripSeparator35, Me.AssignLienAttorneyToolStripMenuItem})
        Me.mnuAttorney1.Image = CType(resources.GetObject("mnuAttorney1.Image"), System.Drawing.Image)
        Me.mnuAttorney1.Name = "mnuAttorney1"
        Me.mnuAttorney1.Size = New System.Drawing.Size(225, 22)
        Me.mnuAttorney1.Text = "Attorney"
        '
        'mnuSendToAttorney1
        '
        Me.mnuSendToAttorney1.BackColor = System.Drawing.SystemColors.Control
        Me.mnuSendToAttorney1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.mnuSendToAttorney1.Image = CType(resources.GetObject("mnuSendToAttorney1.Image"), System.Drawing.Image)
        Me.mnuSendToAttorney1.Name = "mnuSendToAttorney1"
        Me.mnuSendToAttorney1.Size = New System.Drawing.Size(295, 22)
        Me.mnuSendToAttorney1.Text = "Assign Selected Bill To Attorney"
        '
        'mnuRemoveBillFromAttorney1
        '
        Me.mnuRemoveBillFromAttorney1.BackColor = System.Drawing.SystemColors.Control
        Me.mnuRemoveBillFromAttorney1.ForeColor = System.Drawing.Color.IndianRed
        Me.mnuRemoveBillFromAttorney1.Image = CType(resources.GetObject("mnuRemoveBillFromAttorney1.Image"), System.Drawing.Image)
        Me.mnuRemoveBillFromAttorney1.Name = "mnuRemoveBillFromAttorney1"
        Me.mnuRemoveBillFromAttorney1.Size = New System.Drawing.Size(295, 22)
        Me.mnuRemoveBillFromAttorney1.Text = "Remove Selected Bill From Attorney"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(292, 6)
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripMenuItem6.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ToolStripMenuItem6.Image = CType(resources.GetObject("ToolStripMenuItem6.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(295, 22)
        Me.ToolStripMenuItem6.Text = "Assign Selected Bill Atorney Case Number"
        '
        'ClearAttorneyCaseNumberToolStripMenuItem
        '
        Me.ClearAttorneyCaseNumberToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.ClearAttorneyCaseNumberToolStripMenuItem.ForeColor = System.Drawing.Color.IndianRed
        Me.ClearAttorneyCaseNumberToolStripMenuItem.Image = CType(resources.GetObject("ClearAttorneyCaseNumberToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ClearAttorneyCaseNumberToolStripMenuItem.Name = "ClearAttorneyCaseNumberToolStripMenuItem"
        Me.ClearAttorneyCaseNumberToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.ClearAttorneyCaseNumberToolStripMenuItem.Text = "Remove Attorney Case Number"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(292, 6)
        '
        'mnuReprintCoverpage
        '
        Me.mnuReprintCoverpage.Image = CType(resources.GetObject("mnuReprintCoverpage.Image"), System.Drawing.Image)
        Me.mnuReprintCoverpage.Name = "mnuReprintCoverpage"
        Me.mnuReprintCoverpage.Size = New System.Drawing.Size(295, 22)
        Me.mnuReprintCoverpage.Text = "Reprint Selected / Checked Bill Coverpage"
        '
        'ToolStripSeparator46
        '
        Me.ToolStripSeparator46.Name = "ToolStripSeparator46"
        Me.ToolStripSeparator46.Size = New System.Drawing.Size(292, 6)
        '
        'AttorneyFeesToolStripMenuItem
        '
        Me.AttorneyFeesToolStripMenuItem.Image = CType(resources.GetObject("AttorneyFeesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AttorneyFeesToolStripMenuItem.Name = "AttorneyFeesToolStripMenuItem"
        Me.AttorneyFeesToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.AttorneyFeesToolStripMenuItem.Text = "Attorney Fees"
        '
        'ToolStripSeparator48
        '
        Me.ToolStripSeparator48.Name = "ToolStripSeparator48"
        Me.ToolStripSeparator48.Size = New System.Drawing.Size(292, 6)
        '
        'ExportAttorneyDocumentsToolStripMenuItem
        '
        Me.ExportAttorneyDocumentsToolStripMenuItem.Image = CType(resources.GetObject("ExportAttorneyDocumentsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportAttorneyDocumentsToolStripMenuItem.Name = "ExportAttorneyDocumentsToolStripMenuItem"
        Me.ExportAttorneyDocumentsToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.ExportAttorneyDocumentsToolStripMenuItem.Text = "Attorney Documents Access"
        '
        'ToolStripSeparator35
        '
        Me.ToolStripSeparator35.Name = "ToolStripSeparator35"
        Me.ToolStripSeparator35.Size = New System.Drawing.Size(292, 6)
        '
        'AssignLienAttorneyToolStripMenuItem
        '
        Me.AssignLienAttorneyToolStripMenuItem.Image = CType(resources.GetObject("AssignLienAttorneyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AssignLienAttorneyToolStripMenuItem.Name = "AssignLienAttorneyToolStripMenuItem"
        Me.AssignLienAttorneyToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.AssignLienAttorneyToolStripMenuItem.Text = "Lien Attorney"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(222, 6)
        '
        'ToolStripMenuItemItemizedCharges
        '
        Me.ToolStripMenuItemItemizedCharges.Image = CType(resources.GetObject("ToolStripMenuItemItemizedCharges.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemItemizedCharges.Name = "ToolStripMenuItemItemizedCharges"
        Me.ToolStripMenuItemItemizedCharges.Size = New System.Drawing.Size(225, 22)
        Me.ToolStripMenuItemItemizedCharges.Text = "Itemized Charges"
        '
        'mnuCollection1
        '
        Me.mnuCollection1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelectedBillPayment1, Me.ToolStripMenuItem2, Me.mnuAddSelectedBillNotes2, Me.ToolStripSeparator33, Me.mnuBillDenied1, Me.ToolStripSeparator40, Me.ToolStripMenuItem13})
        Me.mnuCollection1.Image = CType(resources.GetObject("mnuCollection1.Image"), System.Drawing.Image)
        Me.mnuCollection1.Name = "mnuCollection1"
        Me.mnuCollection1.Size = New System.Drawing.Size(225, 22)
        Me.mnuCollection1.Text = "Collection"
        '
        'mnuSelectedBillPayment1
        '
        Me.mnuSelectedBillPayment1.Image = CType(resources.GetObject("mnuSelectedBillPayment1.Image"), System.Drawing.Image)
        Me.mnuSelectedBillPayment1.Name = "mnuSelectedBillPayment1"
        Me.mnuSelectedBillPayment1.Size = New System.Drawing.Size(322, 22)
        Me.mnuSelectedBillPayment1.Text = "Add Selected Bill Payment"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(322, 22)
        Me.ToolStripMenuItem2.Text = "Show Today's Payments Total"
        '
        'mnuAddSelectedBillNotes2
        '
        Me.mnuAddSelectedBillNotes2.Image = CType(resources.GetObject("mnuAddSelectedBillNotes2.Image"), System.Drawing.Image)
        Me.mnuAddSelectedBillNotes2.Name = "mnuAddSelectedBillNotes2"
        Me.mnuAddSelectedBillNotes2.Size = New System.Drawing.Size(322, 22)
        Me.mnuAddSelectedBillNotes2.Text = "Add Notes"
        '
        'ToolStripSeparator33
        '
        Me.ToolStripSeparator33.Name = "ToolStripSeparator33"
        Me.ToolStripSeparator33.Size = New System.Drawing.Size(319, 6)
        '
        'mnuBillDenied1
        '
        Me.mnuBillDenied1.ForeColor = System.Drawing.Color.Red
        Me.mnuBillDenied1.Image = CType(resources.GetObject("mnuBillDenied1.Image"), System.Drawing.Image)
        Me.mnuBillDenied1.Name = "mnuBillDenied1"
        Me.mnuBillDenied1.Size = New System.Drawing.Size(322, 22)
        Me.mnuBillDenied1.Text = "Selected Bill Denied"
        '
        'ToolStripSeparator40
        '
        Me.ToolStripSeparator40.Name = "ToolStripSeparator40"
        Me.ToolStripSeparator40.Size = New System.Drawing.Size(319, 6)
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Image = CType(resources.GetObject("ToolStripMenuItem13.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(322, 22)
        Me.ToolStripMenuItem13.Text = "Court Index Number / Filing Date Maintenance"
        '
        'ToolStripMenuItemRequest
        '
        Me.ToolStripMenuItemRequest.Image = CType(resources.GetObject("ToolStripMenuItemRequest.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemRequest.Name = "ToolStripMenuItemRequest"
        Me.ToolStripMenuItemRequest.Size = New System.Drawing.Size(225, 22)
        Me.ToolStripMenuItemRequest.Text = "Billing Request"
        '
        'AdminToolsToolStripSeparator
        '
        Me.AdminToolsToolStripSeparator.Name = "AdminToolsToolStripSeparator"
        Me.AdminToolsToolStripSeparator.Size = New System.Drawing.Size(222, 6)
        '
        'AdminToolsToolStripMenuItem
        '
        Me.AdminToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeBillDateToolStripMenuItem, Me.ChangeBillStatusToolStripMenuItem, Me.ToolStripMenuItem9, Me.ChangeBillAmountToolStripMenuItem, Me.ToolStripSeparator15, Me.ChangePaymentAmountToolStripMenuItem, Me.ToolStripSeparator43, Me.mnuReProduceSelectedBill1, Me.ToolStripSeparator42, Me.ToolStripMenuItem7, Me.DeleteSelectedBillToolStripMenuItem})
        Me.AdminToolsToolStripMenuItem.Image = CType(resources.GetObject("AdminToolsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AdminToolsToolStripMenuItem.Name = "AdminToolsToolStripMenuItem"
        Me.AdminToolsToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.AdminToolsToolStripMenuItem.Text = "Administrative Tools"
        '
        'ChangeBillDateToolStripMenuItem
        '
        Me.ChangeBillDateToolStripMenuItem.Enabled = False
        Me.ChangeBillDateToolStripMenuItem.Image = CType(resources.GetObject("ChangeBillDateToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ChangeBillDateToolStripMenuItem.Name = "ChangeBillDateToolStripMenuItem"
        Me.ChangeBillDateToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ChangeBillDateToolStripMenuItem.Text = "Change Bill Date"
        Me.ChangeBillDateToolStripMenuItem.Visible = False
        '
        'ChangeBillStatusToolStripMenuItem
        '
        Me.ChangeBillStatusToolStripMenuItem.Image = CType(resources.GetObject("ChangeBillStatusToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ChangeBillStatusToolStripMenuItem.Name = "ChangeBillStatusToolStripMenuItem"
        Me.ChangeBillStatusToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ChangeBillStatusToolStripMenuItem.Text = "Change Bill Status"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.ForeColor = System.Drawing.Color.Black
        Me.ToolStripMenuItem9.Image = CType(resources.GetObject("ToolStripMenuItem9.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(231, 22)
        Me.ToolStripMenuItem9.Text = "No More Collection"
        '
        'ChangeBillAmountToolStripMenuItem
        '
        Me.ChangeBillAmountToolStripMenuItem.Image = CType(resources.GetObject("ChangeBillAmountToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ChangeBillAmountToolStripMenuItem.Name = "ChangeBillAmountToolStripMenuItem"
        Me.ChangeBillAmountToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ChangeBillAmountToolStripMenuItem.Text = "Change Bill Amount"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(228, 6)
        '
        'ChangePaymentAmountToolStripMenuItem
        '
        Me.ChangePaymentAmountToolStripMenuItem.Image = CType(resources.GetObject("ChangePaymentAmountToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ChangePaymentAmountToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 8, 0, 8)
        Me.ChangePaymentAmountToolStripMenuItem.Name = "ChangePaymentAmountToolStripMenuItem"
        Me.ChangePaymentAmountToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ChangePaymentAmountToolStripMenuItem.Text = "Change Payment Information"
        '
        'ToolStripSeparator43
        '
        Me.ToolStripSeparator43.Name = "ToolStripSeparator43"
        Me.ToolStripSeparator43.Size = New System.Drawing.Size(228, 6)
        '
        'mnuReProduceSelectedBill1
        '
        Me.mnuReProduceSelectedBill1.Image = CType(resources.GetObject("mnuReProduceSelectedBill1.Image"), System.Drawing.Image)
        Me.mnuReProduceSelectedBill1.Name = "mnuReProduceSelectedBill1"
        Me.mnuReProduceSelectedBill1.Size = New System.Drawing.Size(231, 22)
        Me.mnuReProduceSelectedBill1.Text = "ReProduce Selected Bill"
        '
        'ToolStripSeparator42
        '
        Me.ToolStripSeparator42.Name = "ToolStripSeparator42"
        Me.ToolStripSeparator42.Size = New System.Drawing.Size(228, 6)
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.ForeColor = System.Drawing.Color.Firebrick
        Me.ToolStripMenuItem7.Image = CType(resources.GetObject("ToolStripMenuItem7.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(231, 22)
        Me.ToolStripMenuItem7.Text = "Delete Selected Bill Payment"
        '
        'DeleteSelectedBillToolStripMenuItem
        '
        Me.DeleteSelectedBillToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed
        Me.DeleteSelectedBillToolStripMenuItem.Image = CType(resources.GetObject("DeleteSelectedBillToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteSelectedBillToolStripMenuItem.Name = "DeleteSelectedBillToolStripMenuItem"
        Me.DeleteSelectedBillToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.DeleteSelectedBillToolStripMenuItem.Text = "Delete Selected Bill"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(124, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 110
        Me.Label4.Text = "Case Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(4, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "First/Last/##"
        '
        'cboCaseTypeID
        '
        Me.cboCaseTypeID.BackColor = System.Drawing.Color.White
        Me.cboCaseTypeID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCaseTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaseTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCaseTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCaseTypeID.ForeColor = System.Drawing.Color.Black
        Me.cboCaseTypeID.FormattingEnabled = True
        Me.cboCaseTypeID.Location = New System.Drawing.Point(124, 17)
        Me.cboCaseTypeID.Name = "cboCaseTypeID"
        Me.cboCaseTypeID.Size = New System.Drawing.Size(94, 21)
        Me.cboCaseTypeID.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cboCaseTypeID, "Case Type")
        '
        'txtPatient
        '
        Me.txtPatient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtPatient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPatient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPatient.Location = New System.Drawing.Point(4, 17)
        Me.txtPatient.Name = "txtPatient"
        Me.txtPatient.Size = New System.Drawing.Size(114, 20)
        Me.txtPatient.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtPatient, "Patient's First Name / Last Name / Patient's Number")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(124, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Bill Status"
        '
        'cboPaymentNote
        '
        Me.cboPaymentNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPaymentNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentNote.DropDownWidth = 400
        Me.cboPaymentNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPaymentNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPaymentNote.ForeColor = System.Drawing.Color.Black
        Me.cboPaymentNote.FormattingEnabled = True
        Me.cboPaymentNote.Location = New System.Drawing.Point(996, 60)
        Me.cboPaymentNote.Name = "cboPaymentNote"
        Me.cboPaymentNote.Size = New System.Drawing.Size(94, 21)
        Me.cboPaymentNote.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.cboPaymentNote, "Payment Notes")
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(996, 41)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 272
        Me.Label17.Text = "Pay Notes"
        '
        'DateTimePickerAttorneyTo
        '
        Me.DateTimePickerAttorneyTo.Checked = False
        Me.DateTimePickerAttorneyTo.CustomFormat = "MM/dd/yy"
        Me.DateTimePickerAttorneyTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePickerAttorneyTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerAttorneyTo.Location = New System.Drawing.Point(705, 60)
        Me.DateTimePickerAttorneyTo.Name = "DateTimePickerAttorneyTo"
        Me.DateTimePickerAttorneyTo.ShowCheckBox = True
        Me.DateTimePickerAttorneyTo.Size = New System.Drawing.Size(102, 20)
        Me.DateTimePickerAttorneyTo.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.DateTimePickerAttorneyTo, "Attorney To Date")
        '
        'cboAttorneysCompanyID
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboAttorneysCompanyID, 2)
        Me.cboAttorneysCompanyID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboAttorneysCompanyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttorneysCompanyID.DropDownWidth = 300
        Me.cboAttorneysCompanyID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAttorneysCompanyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAttorneysCompanyID.ForeColor = System.Drawing.Color.Black
        Me.cboAttorneysCompanyID.FormattingEnabled = True
        Me.cboAttorneysCompanyID.Location = New System.Drawing.Point(615, 17)
        Me.cboAttorneysCompanyID.Name = "cboAttorneysCompanyID"
        Me.cboAttorneysCompanyID.Size = New System.Drawing.Size(192, 21)
        Me.cboAttorneysCompanyID.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.cboAttorneysCompanyID, "Attorney")
        '
        'cboBillingProvider
        '
        Me.cboBillingProvider.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboBillingProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingProvider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillingProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBillingProvider.ForeColor = System.Drawing.Color.Black
        Me.cboBillingProvider.FormattingEnabled = True
        Me.cboBillingProvider.Location = New System.Drawing.Point(412, 60)
        Me.cboBillingProvider.Name = "cboBillingProvider"
        Me.cboBillingProvider.Size = New System.Drawing.Size(197, 21)
        Me.cboBillingProvider.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.cboBillingProvider, "Billing Provider")
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
        Me.cboInsuranceCompanyID.Location = New System.Drawing.Point(412, 17)
        Me.cboInsuranceCompanyID.MaxDropDownItems = 40
        Me.cboInsuranceCompanyID.Name = "cboInsuranceCompanyID"
        Me.cboInsuranceCompanyID.Size = New System.Drawing.Size(197, 21)
        Me.cboInsuranceCompanyID.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cboInsuranceCompanyID, "Insurance Company")
        '
        'DateTimePaymentFrom
        '
        Me.DateTimePaymentFrom.Checked = False
        Me.DateTimePaymentFrom.CustomFormat = "MM/dd/yy"
        Me.DateTimePaymentFrom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePaymentFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePaymentFrom.Location = New System.Drawing.Point(224, 60)
        Me.DateTimePaymentFrom.Name = "DateTimePaymentFrom"
        Me.DateTimePaymentFrom.ShowCheckBox = True
        Me.DateTimePaymentFrom.Size = New System.Drawing.Size(82, 20)
        Me.DateTimePaymentFrom.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.DateTimePaymentFrom, "If Posted / Check date checked, the search result " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "may represent multiple record" &
        "s per bill - separate record " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for each payment.")
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.Checked = False
        Me.DateTimePickerFrom.CustomFormat = "MM/dd/yy"
        Me.DateTimePickerFrom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(224, 17)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.ShowCheckBox = True
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(82, 20)
        Me.DateTimePickerFrom.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.DateTimePickerFrom, "Bill From Date")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(996, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 13)
        Me.Label15.TabIndex = 271
        Me.Label15.Text = "Diag"
        '
        'cboDiagnostic
        '
        Me.cboDiagnostic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDiagnostic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiagnostic.DropDownWidth = 400
        Me.cboDiagnostic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDiagnostic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDiagnostic.ForeColor = System.Drawing.Color.Black
        Me.cboDiagnostic.FormattingEnabled = True
        Me.cboDiagnostic.Location = New System.Drawing.Point(996, 17)
        Me.cboDiagnostic.Name = "cboDiagnostic"
        Me.cboDiagnostic.Size = New System.Drawing.Size(94, 21)
        Me.cboDiagnostic.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.cboDiagnostic, "Diagnostic")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(615, 1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 247
        Me.Label18.Text = "Attorney"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(412, 41)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 269
        Me.Label13.Text = "Billing Provider"
        '
        'DateTimePaymentTo
        '
        Me.DateTimePaymentTo.Checked = False
        Me.DateTimePaymentTo.CustomFormat = "MM/dd/yy"
        Me.DateTimePaymentTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePaymentTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePaymentTo.Location = New System.Drawing.Point(312, 60)
        Me.DateTimePaymentTo.Name = "DateTimePaymentTo"
        Me.DateTimePaymentTo.ShowCheckBox = True
        Me.DateTimePaymentTo.Size = New System.Drawing.Size(94, 20)
        Me.DateTimePaymentTo.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.DateTimePaymentTo, "If Posted / Check date checked, the search result " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "may represent multiple record" &
        "s per bill - separate record " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for each payment.")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(705, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 13)
        Me.Label11.TabIndex = 263
        Me.Label11.Text = "To"
        '
        'DateTimePickerAttorneyFrom
        '
        Me.DateTimePickerAttorneyFrom.Checked = False
        Me.DateTimePickerAttorneyFrom.CustomFormat = "MM/dd/yy"
        Me.DateTimePickerAttorneyFrom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePickerAttorneyFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerAttorneyFrom.Location = New System.Drawing.Point(615, 60)
        Me.DateTimePickerAttorneyFrom.Name = "DateTimePickerAttorneyFrom"
        Me.DateTimePickerAttorneyFrom.ShowCheckBox = True
        Me.DateTimePickerAttorneyFrom.Size = New System.Drawing.Size(84, 20)
        Me.DateTimePickerAttorneyFrom.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.DateTimePickerAttorneyFrom, "Attorney From Date")
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.Checked = False
        Me.DateTimePickerTo.CustomFormat = "MM/dd/yy"
        Me.DateTimePickerTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTo.Location = New System.Drawing.Point(312, 17)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.ShowCheckBox = True
        Me.DateTimePickerTo.Size = New System.Drawing.Size(94, 20)
        Me.DateTimePickerTo.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.DateTimePickerTo, "Bill To Date")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(813, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 258
        Me.Label9.Text = "Billing Comp"
        '
        'cboBillingCompany
        '
        Me.cboBillingCompany.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboBillingCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingCompany.DropDownWidth = 300
        Me.cboBillingCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillingCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBillingCompany.ForeColor = System.Drawing.Color.Black
        Me.cboBillingCompany.FormattingEnabled = True
        Me.cboBillingCompany.Location = New System.Drawing.Point(813, 17)
        Me.cboBillingCompany.Name = "cboBillingCompany"
        Me.cboBillingCompany.Size = New System.Drawing.Size(177, 21)
        Me.cboBillingCompany.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.cboBillingCompany, "Billing Company")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(4, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 13)
        Me.Label5.TabIndex = 254
        Me.Label5.Text = "Bill/Case/Claim/Policy"
        '
        'txtBillNumber
        '
        Me.txtBillNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtBillNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtBillNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBillNumber.Location = New System.Drawing.Point(4, 60)
        Me.txtBillNumber.MaxLength = 10
        Me.txtBillNumber.Name = "txtBillNumber"
        Me.txtBillNumber.Size = New System.Drawing.Size(114, 20)
        Me.txtBillNumber.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtBillNumber, "Bill Number / Case Number / Claim Number / Policy Number")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(312, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 251
        Me.Label3.Text = "To"
        '
        'ButtonClear
        '
        Me.ButtonClear.BackColor = System.Drawing.Color.Transparent
        Me.ButtonClear.Image = CType(resources.GetObject("ButtonClear.Image"), System.Drawing.Image)
        Me.ButtonClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonClear.Location = New System.Drawing.Point(1208, 57)
        Me.ButtonClear.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(26, 25)
        Me.ButtonClear.TabIndex = 18
        Me.ButtonClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButtonClear, "Clear Search Criteria")
        Me.ButtonClear.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(412, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 249
        Me.Label7.Text = "Insurance"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(224, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 120
        Me.Label6.Text = "Bill From"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(615, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 261
        Me.Label10.Text = "Attorney From"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "UserBlue.png")
        Me.ImageList1.Images.SetKeyName(1, "UserOrange.png")
        Me.ImageList1.Images.SetKeyName(2, "UserRed.png")
        Me.ImageList1.Images.SetKeyName(3, "UserRed.png")
        Me.ImageList1.Images.SetKeyName(4, "UserRed.png")
        Me.ImageList1.Images.SetKeyName(5, "SORT1")
        Me.ImageList1.Images.SetKeyName(6, "SORT2")
        Me.ImageList1.Images.SetKeyName(7, "SORT0")
        '
        'ButtonDetails
        '
        Me.ButtonDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDetails.BackColor = System.Drawing.Color.Transparent
        Me.ButtonDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonDetails.Image = CType(resources.GetObject("ButtonDetails.Image"), System.Drawing.Image)
        Me.ButtonDetails.Location = New System.Drawing.Point(321, 3)
        Me.ButtonDetails.Name = "ButtonDetails"
        Me.ButtonDetails.Size = New System.Drawing.Size(20, 16)
        Me.ButtonDetails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.ButtonDetails.TabIndex = 12
        Me.ButtonDetails.TabStop = False
        Me.ButtonDetails.Tag = "1"
        Me.ToolTip1.SetToolTip(Me.ButtonDetails, "Hide Patient Details Panel")
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
        'PanelShowBills
        '
        Me.PanelShowBills.BackgroundImage = CType(resources.GetObject("PanelShowBills.BackgroundImage"), System.Drawing.Image)
        Me.PanelShowBills.Controls.Add(Me.PictureBox2)
        Me.PanelShowBills.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PanelShowBills.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelShowBills.Location = New System.Drawing.Point(1292, 154)
        Me.PanelShowBills.Name = "PanelShowBills"
        Me.PanelShowBills.Size = New System.Drawing.Size(16, 458)
        Me.PanelShowBills.TabIndex = 117
        Me.ToolTip1.SetToolTip(Me.PanelShowBills, "Show Patient Bills / Bill Comments")
        Me.PanelShowBills.Visible = False
        '
        'RadioButtonF1
        '
        Me.RadioButtonF1.AutoSize = True
        Me.RadioButtonF1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButtonF1.Checked = True
        Me.RadioButtonF1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.RadioButtonF1.Location = New System.Drawing.Point(174, 1)
        Me.RadioButtonF1.Name = "RadioButtonF1"
        Me.RadioButtonF1.Size = New System.Drawing.Size(72, 19)
        Me.RadioButtonF1.TabIndex = 17
        Me.RadioButtonF1.TabStop = True
        Me.RadioButtonF1.Text = "Show All"
        Me.ToolTip1.SetToolTip(Me.RadioButtonF1, "Filter Result")
        Me.RadioButtonF1.UseVisualStyleBackColor = True
        '
        'RadioButtonF2
        '
        Me.RadioButtonF2.AutoSize = True
        Me.RadioButtonF2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButtonF2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.RadioButtonF2.Location = New System.Drawing.Point(250, 1)
        Me.RadioButtonF2.Name = "RadioButtonF2"
        Me.RadioButtonF2.Size = New System.Drawing.Size(119, 19)
        Me.RadioButtonF2.TabIndex = 18
        Me.RadioButtonF2.Text = "No Confirmations"
        Me.RadioButtonF2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.RadioButtonF2, "Filter Result")
        Me.RadioButtonF2.UseVisualStyleBackColor = True
        '
        'RadioButtonF3
        '
        Me.RadioButtonF3.AutoSize = True
        Me.RadioButtonF3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButtonF3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.RadioButtonF3.Location = New System.Drawing.Point(365, 1)
        Me.RadioButtonF3.Name = "RadioButtonF3"
        Me.RadioButtonF3.Size = New System.Drawing.Size(128, 19)
        Me.RadioButtonF3.TabIndex = 19
        Me.RadioButtonF3.Text = "Not Processed Bills "
        Me.ToolTip1.SetToolTip(Me.RadioButtonF3, "Filter Result")
        Me.RadioButtonF3.UseVisualStyleBackColor = True
        '
        'RadioButtonF4
        '
        Me.RadioButtonF4.AutoSize = True
        Me.RadioButtonF4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButtonF4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.RadioButtonF4.Location = New System.Drawing.Point(494, 1)
        Me.RadioButtonF4.Name = "RadioButtonF4"
        Me.RadioButtonF4.Size = New System.Drawing.Size(136, 19)
        Me.RadioButtonF4.TabIndex = 20
        Me.RadioButtonF4.Text = "Incomplete Requests"
        Me.ToolTip1.SetToolTip(Me.RadioButtonF4, "Filter Result")
        Me.RadioButtonF4.UseVisualStyleBackColor = True
        '
        'ButtonFind
        '
        Me.ButtonFind.BackColor = System.Drawing.Color.Transparent
        Me.ButtonFind.Image = CType(resources.GetObject("ButtonFind.Image"), System.Drawing.Image)
        Me.ButtonFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonFind.Location = New System.Drawing.Point(1237, 17)
        Me.ButtonFind.Name = "ButtonFind"
        Me.ButtonFind.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.TableLayoutPanel1.SetRowSpan(Me.ButtonFind, 3)
        Me.ButtonFind.Size = New System.Drawing.Size(65, 60)
        Me.ButtonFind.TabIndex = 19
        Me.ButtonFind.Text = "    Find   "
        Me.ButtonFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButtonFind, "Find Records")
        Me.ButtonFind.UseVisualStyleBackColor = False
        '
        'cboBillStatus
        '
        Me.cboBillStatus.BackColor = System.Drawing.Color.White
        Me.cboBillStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboBillStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBillStatus.ForeColor = System.Drawing.Color.Black
        Me.cboBillStatus.FormattingEnabled = True
        Me.cboBillStatus.Location = New System.Drawing.Point(124, 60)
        Me.cboBillStatus.Name = "cboBillStatus"
        Me.cboBillStatus.Size = New System.Drawing.Size(94, 21)
        Me.cboBillStatus.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.cboBillStatus, "Case Type")
        '
        'ComboBoxRefOffice
        '
        Me.ComboBoxRefOffice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxRefOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRefOffice.DropDownWidth = 300
        Me.ComboBoxRefOffice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxRefOffice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxRefOffice.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxRefOffice.FormattingEnabled = True
        Me.ComboBoxRefOffice.Location = New System.Drawing.Point(813, 60)
        Me.ComboBoxRefOffice.Name = "ComboBoxRefOffice"
        Me.ComboBoxRefOffice.Size = New System.Drawing.Size(177, 21)
        Me.ComboBoxRefOffice.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.ComboBoxRefOffice, "Billing Company")
        '
        'cboDenial
        '
        Me.cboDenial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDenial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDenial.DropDownWidth = 400
        Me.cboDenial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDenial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDenial.ForeColor = System.Drawing.Color.Black
        Me.cboDenial.FormattingEnabled = True
        Me.cboDenial.Location = New System.Drawing.Point(1096, 60)
        Me.cboDenial.Name = "cboDenial"
        Me.cboDenial.Size = New System.Drawing.Size(109, 21)
        Me.cboDenial.TabIndex = 17
        Me.ToolTip1.SetToolTip(Me.cboDenial, "Denial Reason")
        '
        'PictureBoxClose
        '
        Me.PictureBoxClose.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBoxClose.Image = CType(resources.GetObject("PictureBoxClose.Image"), System.Drawing.Image)
        Me.PictureBoxClose.Location = New System.Drawing.Point(916, 0)
        Me.PictureBoxClose.Name = "PictureBoxClose"
        Me.PictureBoxClose.Size = New System.Drawing.Size(26, 20)
        Me.PictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBoxClose.TabIndex = 22
        Me.PictureBoxClose.TabStop = False
        Me.PictureBoxClose.Tag = "1"
        Me.ToolTip1.SetToolTip(Me.PictureBoxClose, "Hide Attention Panel")
        '
        'chkPaymentSearch
        '
        Me.chkPaymentSearch.AutoSize = True
        Me.chkPaymentSearch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPaymentSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.chkPaymentSearch.ForeColor = System.Drawing.Color.White
        Me.chkPaymentSearch.Location = New System.Drawing.Point(173, 0)
        Me.chkPaymentSearch.Name = "chkPaymentSearch"
        Me.chkPaymentSearch.Size = New System.Drawing.Size(15, 16)
        Me.chkPaymentSearch.TabIndex = 268
        Me.ToolTip1.SetToolTip(Me.chkPaymentSearch, resources.GetString("chkPaymentSearch.ToolTip"))
        Me.chkPaymentSearch.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(0, 2)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(163, 13)
        Me.Label12.TabIndex = 269
        Me.Label12.Text = "Payment Posted Date: From / To"
        Me.ToolTip1.SetToolTip(Me.Label12, resources.GetString("Label12.ToolTip"))
        '
        'PanelBills
        '
        Me.PanelBills.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelBills.Controls.Add(Me.TabControl1)
        Me.PanelBills.Controls.Add(Me.Panel1)
        Me.PanelBills.Controls.Add(Me.Panel5)
        Me.PanelBills.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBills.Location = New System.Drawing.Point(0, 0)
        Me.PanelBills.Name = "PanelBills"
        Me.PanelBills.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.PanelBills.Size = New System.Drawing.Size(346, 458)
        Me.PanelBills.TabIndex = 115
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(2, 25)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(5, 5)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(344, 433)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TabControl1.TabIndex = 126
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ListViewRequests)
        Me.TabPage1.Controls.Add(Me.ToolStrip3)
        Me.TabPage1.Controls.Add(Me.ListViewPayments)
        Me.TabPage1.Controls.Add(Me.ToolStrip4)
        Me.TabPage1.Controls.Add(Me.TreeViewBills)
        Me.TabPage1.Controls.Add(Me.PanelBillDetails)
        Me.TabPage1.Location = New System.Drawing.Point(4, 48)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(336, 381)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ListViewRequests
        '
        Me.ListViewRequests.BackColor = System.Drawing.Color.White
        Me.ListViewRequests.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.ListViewRequests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewRequests.FullRowSelect = True
        Me.ListViewRequests.GridLines = True
        Me.ListViewRequests.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewRequests.HideSelection = False
        Me.ListViewRequests.Location = New System.Drawing.Point(3, 299)
        Me.ListViewRequests.MultiSelect = False
        Me.ListViewRequests.Name = "ListViewRequests"
        Me.ListViewRequests.Size = New System.Drawing.Size(330, 79)
        Me.ListViewRequests.TabIndex = 9
        Me.ListViewRequests.UseCompatibleStateImageBehavior = False
        Me.ListViewRequests.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Date"
        Me.ColumnHeader8.Width = 91
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Status"
        Me.ColumnHeader9.Width = 57
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Request"
        Me.ColumnHeader10.Width = 148
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.ToolStripButton8, Me.ToolStripSeparator31, Me.ToolStripButton1})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 274)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(330, 25)
        Me.ToolStrip3.TabIndex = 8
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripLabel2.Text = "BILL REQUESTS"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ToolStripButton8.Size = New System.Drawing.Size(67, 22)
        Me.ToolStripButton8.Text = "Action"
        Me.ToolStripButton8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButton8.ToolTipText = "Add Request Action"
        '
        'ToolStripSeparator31
        '
        Me.ToolStripSeparator31.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator31.Name = "ToolStripSeparator31"
        Me.ToolStripSeparator31.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.ToolStripButton1.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripButton1.Text = "Request"
        Me.ToolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButton1.ToolTipText = "Add Request"
        '
        'ListViewPayments
        '
        Me.ListViewPayments.BackColor = System.Drawing.Color.White
        Me.ListViewPayments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PaymentDT, Me.Amount, Me.ColumnHeader4})
        Me.ListViewPayments.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListViewPayments.FullRowSelect = True
        Me.ListViewPayments.GridLines = True
        Me.ListViewPayments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewPayments.HideSelection = False
        Me.ListViewPayments.Location = New System.Drawing.Point(3, 114)
        Me.ListViewPayments.MultiSelect = False
        Me.ListViewPayments.Name = "ListViewPayments"
        Me.ListViewPayments.ShowItemToolTips = True
        Me.ListViewPayments.Size = New System.Drawing.Size(330, 160)
        Me.ListViewPayments.TabIndex = 2
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
        Me.Amount.Width = 127
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Check #"
        Me.ColumnHeader4.Width = 126
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.ToolStripButton4})
        Me.ToolStrip4.Location = New System.Drawing.Point(3, 89)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(330, 25)
        Me.ToolStrip4.TabIndex = 1
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel3.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(93, 22)
        Me.ToolStripLabel3.Text = "BILL PAYMENTS"
        Me.ToolStripLabel3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.AutoSize = False
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripButton4.Text = "Add Payment"
        Me.ToolStripButton4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'TreeViewBills
        '
        Me.TreeViewBills.BackColor = System.Drawing.Color.White
        Me.TreeViewBills.Dock = System.Windows.Forms.DockStyle.Top
        Me.TreeViewBills.FullRowSelect = True
        Me.TreeViewBills.HideSelection = False
        Me.TreeViewBills.ImageKey = "2"
        Me.TreeViewBills.ImageList = Me.ImageList2
        Me.TreeViewBills.Indent = 12
        Me.TreeViewBills.Location = New System.Drawing.Point(3, 19)
        Me.TreeViewBills.Name = "TreeViewBills"
        Me.TreeViewBills.SelectedImageIndex = 0
        Me.TreeViewBills.ShowNodeToolTips = True
        Me.TreeViewBills.Size = New System.Drawing.Size(330, 70)
        Me.TreeViewBills.TabIndex = 0
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "3")
        Me.ImageList2.Images.SetKeyName(1, "4")
        Me.ImageList2.Images.SetKeyName(2, "5")
        Me.ImageList2.Images.SetKeyName(3, "6")
        Me.ImageList2.Images.SetKeyName(4, "7")
        Me.ImageList2.Images.SetKeyName(5, "31")
        Me.ImageList2.Images.SetKeyName(6, "41")
        Me.ImageList2.Images.SetKeyName(7, "51")
        Me.ImageList2.Images.SetKeyName(8, "61")
        Me.ImageList2.Images.SetKeyName(9, "71")
        Me.ImageList2.Images.SetKeyName(10, "8")
        Me.ImageList2.Images.SetKeyName(11, "81")
        Me.ImageList2.Images.SetKeyName(12, "2")
        Me.ImageList2.Images.SetKeyName(13, "21")
        Me.ImageList2.Images.SetKeyName(14, "1")
        Me.ImageList2.Images.SetKeyName(15, "11")
        Me.ImageList2.Images.SetKeyName(16, "PROC")
        Me.ImageList2.Images.SetKeyName(17, "DIAG")
        Me.ImageList2.Images.SetKeyName(18, "SORT1")
        Me.ImageList2.Images.SetKeyName(19, "SORT2")
        Me.ImageList2.Images.SetKeyName(20, "SORT0")
        '
        'PanelBillDetails
        '
        Me.PanelBillDetails.BackColor = System.Drawing.Color.White
        Me.PanelBillDetails.Controls.Add(Me.Label16)
        Me.PanelBillDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBillDetails.Location = New System.Drawing.Point(3, 3)
        Me.PanelBillDetails.Name = "PanelBillDetails"
        Me.PanelBillDetails.Size = New System.Drawing.Size(330, 16)
        Me.PanelBillDetails.TabIndex = 274
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 15)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "PATIENT BILLS"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.ListViewDenials)
        Me.TabPage4.Controls.Add(Me.txtDenialComments)
        Me.TabPage4.Controls.Add(Me.ToolStrip7)
        Me.TabPage4.Location = New System.Drawing.Point(4, 48)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(336, 381)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Denials"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'ListViewDenials
        '
        Me.ListViewDenials.BackColor = System.Drawing.Color.White
        Me.ListViewDenials.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader35, Me.ColumnHeader36, Me.ColumnHeader37})
        Me.ListViewDenials.ContextMenuStrip = Me.ContextMenuStrip2
        Me.ListViewDenials.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewDenials.FullRowSelect = True
        Me.ListViewDenials.GridLines = True
        Me.ListViewDenials.HideSelection = False
        Me.ListViewDenials.LargeImageList = Me.ImageList1
        Me.ListViewDenials.Location = New System.Drawing.Point(0, 25)
        Me.ListViewDenials.MultiSelect = False
        Me.ListViewDenials.Name = "ListViewDenials"
        Me.ListViewDenials.ShowItemToolTips = True
        Me.ListViewDenials.Size = New System.Drawing.Size(336, 286)
        Me.ListViewDenials.SmallImageList = Me.ImageList2
        Me.ListViewDenials.TabIndex = 5
        Me.ListViewDenials.UseCompatibleStateImageBehavior = False
        Me.ListViewDenials.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader35
        '
        Me.ColumnHeader35.Text = "Proc"
        '
        'ColumnHeader36
        '
        Me.ColumnHeader36.Text = "Date"
        Me.ColumnHeader36.Width = 143
        '
        'ColumnHeader37
        '
        Me.ColumnHeader37.Text = "Comment"
        Me.ColumnHeader37.Width = 127
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem16, Me.ToolStripSeparator45, Me.ToolStripMenuItem8})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(218, 54)
        '
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Image = CType(resources.GetObject("ToolStripMenuItem16.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        Me.ToolStripMenuItem16.Size = New System.Drawing.Size(217, 22)
        Me.ToolStripMenuItem16.Text = "Show Patient's Information"
        '
        'ToolStripSeparator45
        '
        Me.ToolStripSeparator45.Name = "ToolStripSeparator45"
        Me.ToolStripSeparator45.Size = New System.Drawing.Size(214, 6)
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Image = CType(resources.GetObject("ToolStripMenuItem8.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(217, 22)
        Me.ToolStripMenuItem8.Text = "Show Bill"
        '
        'txtDenialComments
        '
        Me.txtDenialComments.BackColor = System.Drawing.Color.White
        Me.txtDenialComments.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtDenialComments.Location = New System.Drawing.Point(0, 311)
        Me.txtDenialComments.Multiline = True
        Me.txtDenialComments.Name = "txtDenialComments"
        Me.txtDenialComments.Size = New System.Drawing.Size(336, 70)
        Me.txtDenialComments.TabIndex = 8
        '
        'ToolStrip7
        '
        Me.ToolStrip7.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip7.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip7.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel6, Me.ToolStripButton12})
        Me.ToolStrip7.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip7.Name = "ToolStrip7"
        Me.ToolStrip7.Size = New System.Drawing.Size(336, 25)
        Me.ToolStrip7.TabIndex = 4
        Me.ToolStrip7.Text = "ToolStrip7"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel6.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripLabel6.Text = "BILL DENIALS"
        Me.ToolStripLabel6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton12.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.Size = New System.Drawing.Size(61, 22)
        Me.ToolStripButton12.Text = "Denial"
        Me.ToolStripButton12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButton12.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ListViewBillToPatient)
        Me.TabPage3.Controls.Add(Me.ToolStrip6)
        Me.TabPage3.Location = New System.Drawing.Point(4, 48)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(336, 381)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Bills To Patient"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ListViewBillToPatient
        '
        Me.ListViewBillToPatient.BackColor = System.Drawing.Color.White
        Me.ListViewBillToPatient.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader33, Me.ColumnHeader31, Me.ColumnHeader32})
        Me.ListViewBillToPatient.ContextMenuStrip = Me.ContextMenuStrip2
        Me.ListViewBillToPatient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewBillToPatient.FullRowSelect = True
        Me.ListViewBillToPatient.GridLines = True
        Me.ListViewBillToPatient.HideSelection = False
        Me.ListViewBillToPatient.LargeImageList = Me.ImageList1
        Me.ListViewBillToPatient.Location = New System.Drawing.Point(0, 25)
        Me.ListViewBillToPatient.MultiSelect = False
        Me.ListViewBillToPatient.Name = "ListViewBillToPatient"
        Me.ListViewBillToPatient.ShowItemToolTips = True
        Me.ListViewBillToPatient.Size = New System.Drawing.Size(336, 356)
        Me.ListViewBillToPatient.SmallImageList = Me.ImageList2
        Me.ListViewBillToPatient.TabIndex = 4
        Me.ListViewBillToPatient.UseCompatibleStateImageBehavior = False
        Me.ListViewBillToPatient.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader33
        '
        Me.ColumnHeader33.Text = "Bill #"
        '
        'ColumnHeader31
        '
        Me.ColumnHeader31.Text = "Date"
        Me.ColumnHeader31.Width = 143
        '
        'ColumnHeader32
        '
        Me.ColumnHeader32.Text = "By"
        Me.ColumnHeader32.Width = 127
        '
        'ToolStrip6
        '
        Me.ToolStrip6.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip6.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip6.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel5, Me.ToolStripButton10})
        Me.ToolStrip6.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip6.Name = "ToolStrip6"
        Me.ToolStrip6.Size = New System.Drawing.Size(336, 25)
        Me.ToolStrip6.TabIndex = 3
        Me.ToolStrip6.Text = "ToolStrip6"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel5.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(95, 22)
        Me.ToolStripLabel5.Text = "BILL TO PATIENT"
        Me.ToolStripLabel5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton10.AutoSize = False
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripButton10.Text = "Bill To Patient"
        Me.ToolStripButton10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListViewComments)
        Me.TabPage2.Controls.Add(Me.ToolStrip1)
        Me.TabPage2.Controls.Add(Me.txtPatientComments)
        Me.TabPage2.Controls.Add(Me.ToolStrip5)
        Me.TabPage2.Controls.Add(Me.txtComments)
        Me.TabPage2.Location = New System.Drawing.Point(4, 48)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(336, 381)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Notes"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListViewComments
        '
        Me.ListViewComments.BackColor = System.Drawing.Color.White
        Me.ListViewComments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader12})
        Me.ListViewComments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewComments.FullRowSelect = True
        Me.ListViewComments.GridLines = True
        Me.ListViewComments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewComments.HideSelection = False
        Me.ListViewComments.Location = New System.Drawing.Point(3, 206)
        Me.ListViewComments.MultiSelect = False
        Me.ListViewComments.Name = "ListViewComments"
        Me.ListViewComments.ShowItemToolTips = True
        Me.ListViewComments.Size = New System.Drawing.Size(330, 25)
        Me.ListViewComments.TabIndex = 6
        Me.ListViewComments.UseCompatibleStateImageBehavior = False
        Me.ListViewComments.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Date"
        Me.ColumnHeader14.Width = 91
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "By"
        Me.ColumnHeader15.Width = 127
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "FollowUp"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripButton5, Me.mnuAddSelectedBillNotes1})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 181)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(330, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripLabel1.Text = "BILL NOTES"
        Me.ToolStripLabel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButton5.Text = "Show"
        Me.ToolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButton5.ToolTipText = "Show Bill Notes"
        '
        'mnuAddSelectedBillNotes1
        '
        Me.mnuAddSelectedBillNotes1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.mnuAddSelectedBillNotes1.Image = CType(resources.GetObject("mnuAddSelectedBillNotes1.Image"), System.Drawing.Image)
        Me.mnuAddSelectedBillNotes1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuAddSelectedBillNotes1.Name = "mnuAddSelectedBillNotes1"
        Me.mnuAddSelectedBillNotes1.Size = New System.Drawing.Size(78, 22)
        Me.mnuAddSelectedBillNotes1.Text = "Add Note"
        Me.mnuAddSelectedBillNotes1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.mnuAddSelectedBillNotes1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.mnuAddSelectedBillNotes1.ToolTipText = "Add Bill Notes"
        '
        'txtPatientComments
        '
        Me.txtPatientComments.BackColor = System.Drawing.Color.White
        Me.txtPatientComments.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtPatientComments.Location = New System.Drawing.Point(3, 28)
        Me.txtPatientComments.Multiline = True
        Me.txtPatientComments.Name = "txtPatientComments"
        Me.txtPatientComments.ReadOnly = True
        Me.txtPatientComments.Size = New System.Drawing.Size(330, 153)
        Me.txtPatientComments.TabIndex = 4
        '
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.ToolStripButton6})
        Me.ToolStrip5.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(330, 25)
        Me.ToolStrip5.TabIndex = 3
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel4.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripLabel4.Text = "PATIENT QUICK NOTES"
        Me.ToolStripLabel4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButton6.Text = "Show"
        Me.ToolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButton6.ToolTipText = "Show Patient's Comments"
        '
        'txtComments
        '
        Me.txtComments.BackColor = System.Drawing.Color.White
        Me.txtComments.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtComments.Location = New System.Drawing.Point(3, 231)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(330, 147)
        Me.txtComments.TabIndex = 7
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.SplitContainer3)
        Me.TabPage5.Controls.Add(Me.ToolStrip8)
        Me.TabPage5.Location = New System.Drawing.Point(4, 48)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(336, 381)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Patient Docs"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.PanelDocumentWait)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ListViewDocs)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.pdfViewer)
        Me.SplitContainer3.Panel2.Controls.Add(Me.RichTextBox1)
        Me.SplitContainer3.Size = New System.Drawing.Size(336, 356)
        Me.SplitContainer3.SplitterDistance = 175
        Me.SplitContainer3.TabIndex = 372
        '
        'PanelDocumentWait
        '
        Me.PanelDocumentWait.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelDocumentWait.BackColor = System.Drawing.Color.White
        Me.PanelDocumentWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDocumentWait.Controls.Add(Me.PictureBox6)
        Me.PanelDocumentWait.Controls.Add(Me.PictureBox7)
        Me.PanelDocumentWait.Controls.Add(Me.Label123)
        Me.PanelDocumentWait.Location = New System.Drawing.Point(60, 62)
        Me.PanelDocumentWait.Name = "PanelDocumentWait"
        Me.PanelDocumentWait.Size = New System.Drawing.Size(216, 35)
        Me.PanelDocumentWait.TabIndex = 376
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
        'ListViewDocs
        '
        Me.ListViewDocs.AllowColumnReorder = True
        Me.ListViewDocs.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewDocs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader38, Me.ColumnHeader39})
        Me.ListViewDocs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewDocs.FullRowSelect = True
        Me.ListViewDocs.GridLines = True
        Me.ListViewDocs.HideSelection = False
        Me.ListViewDocs.LargeImageList = Me.ImageList1
        Me.ListViewDocs.Location = New System.Drawing.Point(0, 0)
        Me.ListViewDocs.MultiSelect = False
        Me.ListViewDocs.Name = "ListViewDocs"
        Me.ListViewDocs.Size = New System.Drawing.Size(336, 175)
        Me.ListViewDocs.SmallImageList = Me.ImageList1
        Me.ListViewDocs.TabIndex = 3
        Me.ListViewDocs.UseCompatibleStateImageBehavior = False
        Me.ListViewDocs.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader38
        '
        Me.ColumnHeader38.Text = "Document Name"
        Me.ColumnHeader38.Width = 200
        '
        'ColumnHeader39
        '
        Me.ColumnHeader39.Text = "Date"
        Me.ColumnHeader39.Width = 108
        '
        'pdfViewer
        '
        Me.pdfViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfViewer.Location = New System.Drawing.Point(0, 0)
        Me.pdfViewer.Name = "pdfViewer"
        Me.pdfViewer.ShowBookmarks = False
        Me.pdfViewer.ShowToolbar = False
        Me.pdfViewer.Size = New System.Drawing.Size(336, 177)
        Me.pdfViewer.TabIndex = 370
        Me.pdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitBest
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.ShowSelectionMargin = True
        Me.RichTextBox1.Size = New System.Drawing.Size(336, 177)
        Me.RichTextBox1.TabIndex = 371
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.Visible = False
        '
        'ToolStrip8
        '
        Me.ToolStrip8.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip8.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip8.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel8, Me.ToolStripButtonDocuments, Me.ToolStripButton11, Me.ButtonScannDocument})
        Me.ToolStrip8.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip8.Name = "ToolStrip8"
        Me.ToolStrip8.Size = New System.Drawing.Size(336, 25)
        Me.ToolStrip8.TabIndex = 17
        Me.ToolStrip8.Text = "ToolStrip8"
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel8.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripLabel8.Text = "PAT DOCS"
        Me.ToolStripLabel8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolStripButtonDocuments
        '
        Me.ToolStripButtonDocuments.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonDocuments.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButtonDocuments.Image = CType(resources.GetObject("ToolStripButtonDocuments.Image"), System.Drawing.Image)
        Me.ToolStripButtonDocuments.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonDocuments.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDocuments.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.ToolStripButtonDocuments.Name = "ToolStripButtonDocuments"
        Me.ToolStripButtonDocuments.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButtonDocuments.Text = "Show"
        Me.ToolStripButtonDocuments.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButtonDocuments.ToolTipText = "Show Document"
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton11.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripButton11.Text = "Library"
        Me.ToolStripButton11.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ButtonScannDocument
        '
        Me.ButtonScannDocument.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ButtonScannDocument.Image = CType(resources.GetObject("ButtonScannDocument.Image"), System.Drawing.Image)
        Me.ButtonScannDocument.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonScannDocument.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonScannDocument.Name = "ButtonScannDocument"
        Me.ButtonScannDocument.Size = New System.Drawing.Size(52, 22)
        Me.ButtonScannDocument.Text = "Scan"
        Me.ButtonScannDocument.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ButtonScannDocument.ToolTipText = "Scan Document"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.SplitContainer4)
        Me.TabPage6.Controls.Add(Me.ToolStrip9)
        Me.TabPage6.Location = New System.Drawing.Point(4, 48)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(336, 381)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Patient Comments"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.ListViewPatientComments)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.TextBoxCommentView)
        Me.SplitContainer4.Panel2.Controls.Add(Me.TextBoxCommentViewBy)
        Me.SplitContainer4.Size = New System.Drawing.Size(336, 356)
        Me.SplitContainer4.SplitterDistance = 177
        Me.SplitContainer4.TabIndex = 6
        '
        'ListViewPatientComments
        '
        Me.ListViewPatientComments.AllowColumnReorder = True
        Me.ListViewPatientComments.BackColor = System.Drawing.Color.White
        Me.ListViewPatientComments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader40, Me.ColumnHeader41, Me.ColumnHeader42})
        Me.ListViewPatientComments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewPatientComments.FullRowSelect = True
        Me.ListViewPatientComments.GridLines = True
        Me.ListViewPatientComments.HideSelection = False
        Me.ListViewPatientComments.LargeImageList = Me.ImageList1
        Me.ListViewPatientComments.Location = New System.Drawing.Point(0, 0)
        Me.ListViewPatientComments.MultiSelect = False
        Me.ListViewPatientComments.Name = "ListViewPatientComments"
        Me.ListViewPatientComments.Size = New System.Drawing.Size(336, 177)
        Me.ListViewPatientComments.SmallImageList = Me.ImageList1
        Me.ListViewPatientComments.TabIndex = 2
        Me.ListViewPatientComments.UseCompatibleStateImageBehavior = False
        Me.ListViewPatientComments.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader40
        '
        Me.ColumnHeader40.Text = "Date"
        Me.ColumnHeader40.Width = 61
        '
        'ColumnHeader41
        '
        Me.ColumnHeader41.Text = "Comment"
        Me.ColumnHeader41.Width = 183
        '
        'ColumnHeader42
        '
        Me.ColumnHeader42.Text = "By"
        '
        'TextBoxCommentView
        '
        Me.TextBoxCommentView.BackColor = System.Drawing.Color.White
        Me.TextBoxCommentView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCommentView.Location = New System.Drawing.Point(0, 20)
        Me.TextBoxCommentView.Multiline = True
        Me.TextBoxCommentView.Name = "TextBoxCommentView"
        Me.TextBoxCommentView.ReadOnly = True
        Me.TextBoxCommentView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxCommentView.Size = New System.Drawing.Size(336, 155)
        Me.TextBoxCommentView.TabIndex = 5
        '
        'TextBoxCommentViewBy
        '
        Me.TextBoxCommentViewBy.BackColor = System.Drawing.Color.Gainsboro
        Me.TextBoxCommentViewBy.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBoxCommentViewBy.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxCommentViewBy.Name = "TextBoxCommentViewBy"
        Me.TextBoxCommentViewBy.Size = New System.Drawing.Size(336, 20)
        Me.TextBoxCommentViewBy.TabIndex = 6
        '
        'ToolStrip9
        '
        Me.ToolStrip9.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip9.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip9.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel7, Me.ButtonAddComments})
        Me.ToolStrip9.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip9.Name = "ToolStrip9"
        Me.ToolStrip9.Size = New System.Drawing.Size(336, 25)
        Me.ToolStrip9.TabIndex = 4
        Me.ToolStrip9.Text = "ToolStrip9"
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel7.ForeColor = System.Drawing.Color.SteelBlue
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripLabel7.Text = "PATIENT COMMENTS"
        Me.ToolStripLabel7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ButtonAddComments
        '
        Me.ButtonAddComments.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ButtonAddComments.Image = CType(resources.GetObject("ButtonAddComments.Image"), System.Drawing.Image)
        Me.ButtonAddComments.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonAddComments.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonAddComments.Margin = New System.Windows.Forms.Padding(15, 1, 0, 2)
        Me.ButtonAddComments.Name = "ButtonAddComments"
        Me.ButtonAddComments.Size = New System.Drawing.Size(105, 22)
        Me.ButtonAddComments.Text = "Add Comment"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(2, 22)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(344, 3)
        Me.Panel1.TabIndex = 295
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.ButtonDetails)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(2, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(344, 22)
        Me.Panel5.TabIndex = 296
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.ContextMenuStrip = Me.ContextMenuStripCustomizeToolStrip
        Me.ToolStrip2.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripAutoResize, Me.ToolStripFontIncrease, Me.ToolStripFonrDecrease, Me.ToolStripSeparator14, Me.ToolStripTools, Me.ToolStripSeparator26, Me.mnuBillingTools2, Me.ToolStripSeparator20, Me.mnuPOM2, Me.ToolStripSeparator21, Me.mnuAttorney2, Me.ToolStripSeparator22, Me.mnuCollection2, Me.ToolStripButton2, Me.ToolStripSeparator7, Me.ToolStripButton3, Me.ToolStripSeparator8, Me.ToolStripButton7, Me.ToolStripButtonCloseForm, Me.ToolStripButtonDetach, Me.ToolStripSeparator24, Me.ToolStripMenuItem11, Me.ToolStripSeparator34, Me.ToolStripButton9, Me.ToolStripSeparator37, Me.ToolStripMenuItem4, Me.ToolStripSeparator49, Me.ToolStripMenuItem15, Me.ToolStripSeparator53, Me.ToolStripButtoneFile, Me.ToolStripButton13})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 39)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1308, 25)
        Me.ToolStrip2.TabIndex = 1
        Me.ToolStrip2.Text = "Paid Checked"
        '
        'ContextMenuStripCustomizeToolStrip
        '
        Me.ContextMenuStripCustomizeToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomizeToolbarToolStripMenuItem, Me.ToolStripSeparator50, Me.ToolStripMenuItem12})
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
        'ToolStripSeparator50
        '
        Me.ToolStripSeparator50.Name = "ToolStripSeparator50"
        Me.ToolStripSeparator50.Size = New System.Drawing.Size(169, 6)
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
        Me.ToolStripAutoResize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
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
        Me.ToolStripTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrinting2, Me.ToolStripSeparator3, Me.ExportToolStripMenuItem})
        Me.ToolStripTools.Image = CType(resources.GetObject("ToolStripTools.Image"), System.Drawing.Image)
        Me.ToolStripTools.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripTools.ImageTransparentColor = System.Drawing.Color.Magenta
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
        Me.mnuPrinting2.Size = New System.Drawing.Size(153, 22)
        Me.mnuPrinting2.Text = "Printing"
        Me.mnuPrinting2.ToolTipText = "Printing Tools"
        '
        'mnuPrintCheckedBills2
        '
        Me.mnuPrintCheckedBills2.Image = CType(resources.GetObject("mnuPrintCheckedBills2.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedBills2.Name = "mnuPrintCheckedBills2"
        Me.mnuPrintCheckedBills2.Size = New System.Drawing.Size(272, 22)
        Me.mnuPrintCheckedBills2.Text = "Print Checked/Selected Bills"
        Me.mnuPrintCheckedBills2.ToolTipText = "Generate And Print Checked Bills"
        '
        'mnuPrintCheckedEnvelopes2
        '
        Me.mnuPrintCheckedEnvelopes2.Image = CType(resources.GetObject("mnuPrintCheckedEnvelopes2.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedEnvelopes2.Name = "mnuPrintCheckedEnvelopes2"
        Me.mnuPrintCheckedEnvelopes2.Size = New System.Drawing.Size(272, 22)
        Me.mnuPrintCheckedEnvelopes2.Text = "Print Checked/Selected Envelopes"
        Me.mnuPrintCheckedEnvelopes2.ToolTipText = "Print Checked Bills Envelopes"
        '
        'PrintCheckedBillsReadingsToolStripMenuItem
        '
        Me.PrintCheckedBillsReadingsToolStripMenuItem.Image = CType(resources.GetObject("PrintCheckedBillsReadingsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintCheckedBillsReadingsToolStripMenuItem.Name = "PrintCheckedBillsReadingsToolStripMenuItem"
        Me.PrintCheckedBillsReadingsToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.PrintCheckedBillsReadingsToolStripMenuItem.Text = "Print Checked/Selected Bills Readings"
        '
        'mnuPrintSelectedFileLabel2
        '
        Me.mnuPrintSelectedFileLabel2.Image = CType(resources.GetObject("mnuPrintSelectedFileLabel2.Image"), System.Drawing.Image)
        Me.mnuPrintSelectedFileLabel2.Name = "mnuPrintSelectedFileLabel2"
        Me.mnuPrintSelectedFileLabel2.Size = New System.Drawing.Size(272, 22)
        Me.mnuPrintSelectedFileLabel2.Text = "Print Selected Bill File Label"
        Me.mnuPrintSelectedFileLabel2.ToolTipText = "Print Selected Bill File Label"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(269, 6)
        '
        'PrintResultListToolStripMenuItem
        '
        Me.PrintResultListToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrintAll1, Me.mnuPrintCheckedOnly1})
        Me.PrintResultListToolStripMenuItem.ForeColor = System.Drawing.Color.Navy
        Me.PrintResultListToolStripMenuItem.Image = CType(resources.GetObject("PrintResultListToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintResultListToolStripMenuItem.Name = "PrintResultListToolStripMenuItem"
        Me.PrintResultListToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
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
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(150, 6)
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportCheckedToExcelToolStripMenuItem, Me.ExportAllToExcelToolStripMenuItem})
        Me.ExportToolStripMenuItem.Image = CType(resources.GetObject("ExportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
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
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(6, 25)
        '
        'mnuBillingTools2
        '
        Me.mnuBillingTools2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowSelectedPatientInfo2, Me.PaymentsReportToolStripMenuItem, Me.FindCheckToolStripMenuItem, Me.ToolStripSeparator13, Me.mnuPrintSelectedBillReadings2, Me.ToolStripSeparator32, Me.DeleteBillToolStripMenuItem2})
        Me.mnuBillingTools2.Image = CType(resources.GetObject("mnuBillingTools2.Image"), System.Drawing.Image)
        Me.mnuBillingTools2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuBillingTools2.Name = "mnuBillingTools2"
        Me.mnuBillingTools2.Size = New System.Drawing.Size(69, 22)
        Me.mnuBillingTools2.Text = "Billing"
        '
        'mnuShowSelectedPatientInfo2
        '
        Me.mnuShowSelectedPatientInfo2.Image = CType(resources.GetObject("mnuShowSelectedPatientInfo2.Image"), System.Drawing.Image)
        Me.mnuShowSelectedPatientInfo2.Name = "mnuShowSelectedPatientInfo2"
        Me.mnuShowSelectedPatientInfo2.Size = New System.Drawing.Size(217, 22)
        Me.mnuShowSelectedPatientInfo2.Text = "Show Patient's Information"
        Me.mnuShowSelectedPatientInfo2.ToolTipText = "Show Patient's Information"
        '
        'PaymentsReportToolStripMenuItem
        '
        Me.PaymentsReportToolStripMenuItem.Image = CType(resources.GetObject("PaymentsReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PaymentsReportToolStripMenuItem.Name = "PaymentsReportToolStripMenuItem"
        Me.PaymentsReportToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.PaymentsReportToolStripMenuItem.Text = "Payments Report"
        '
        'FindCheckToolStripMenuItem
        '
        Me.FindCheckToolStripMenuItem.Image = CType(resources.GetObject("FindCheckToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FindCheckToolStripMenuItem.Name = "FindCheckToolStripMenuItem"
        Me.FindCheckToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.FindCheckToolStripMenuItem.Text = "Find Check Payment"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(214, 6)
        '
        'mnuPrintSelectedBillReadings2
        '
        Me.mnuPrintSelectedBillReadings2.Image = CType(resources.GetObject("mnuPrintSelectedBillReadings2.Image"), System.Drawing.Image)
        Me.mnuPrintSelectedBillReadings2.Name = "mnuPrintSelectedBillReadings2"
        Me.mnuPrintSelectedBillReadings2.Size = New System.Drawing.Size(217, 22)
        Me.mnuPrintSelectedBillReadings2.Text = "Print Selected Bill Readings"
        '
        'ToolStripSeparator32
        '
        Me.ToolStripSeparator32.Name = "ToolStripSeparator32"
        Me.ToolStripSeparator32.Size = New System.Drawing.Size(214, 6)
        '
        'DeleteBillToolStripMenuItem2
        '
        Me.DeleteBillToolStripMenuItem2.Image = CType(resources.GetObject("DeleteBillToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.DeleteBillToolStripMenuItem2.Name = "DeleteBillToolStripMenuItem2"
        Me.DeleteBillToolStripMenuItem2.Size = New System.Drawing.Size(217, 22)
        Me.DeleteBillToolStripMenuItem2.Text = "Delete Selected Bill"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.AutoSize = False
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(6, 25)
        '
        'mnuPOM2
        '
        Me.mnuPOM2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrintCheckedPOM2, Me.mnuProcessSelectedPOM2, Me.mnuShowSelectedPOM2, Me.mnuFindPOM2})
        Me.mnuPOM2.Image = CType(resources.GetObject("mnuPOM2.Image"), System.Drawing.Image)
        Me.mnuPOM2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuPOM2.Name = "mnuPOM2"
        Me.mnuPOM2.Size = New System.Drawing.Size(63, 22)
        Me.mnuPOM2.Text = "POM"
        Me.mnuPOM2.ToolTipText = "Proof Of Mail Tools"
        '
        'mnuPrintCheckedPOM2
        '
        Me.mnuPrintCheckedPOM2.Image = CType(resources.GetObject("mnuPrintCheckedPOM2.Image"), System.Drawing.Image)
        Me.mnuPrintCheckedPOM2.Name = "mnuPrintCheckedPOM2"
        Me.mnuPrintCheckedPOM2.Size = New System.Drawing.Size(269, 22)
        Me.mnuPrintCheckedPOM2.Text = "Create Checked /  Selected Bills POM"
        Me.mnuPrintCheckedPOM2.ToolTipText = "Generate And Print Checked Bills Proof Of Mail"
        '
        'mnuProcessSelectedPOM2
        '
        Me.mnuProcessSelectedPOM2.Image = CType(resources.GetObject("mnuProcessSelectedPOM2.Image"), System.Drawing.Image)
        Me.mnuProcessSelectedPOM2.Name = "mnuProcessSelectedPOM2"
        Me.mnuProcessSelectedPOM2.Size = New System.Drawing.Size(269, 22)
        Me.mnuProcessSelectedPOM2.Text = "Process / Scan POM"
        Me.mnuProcessSelectedPOM2.ToolTipText = "Scan Proof Of Mail"
        '
        'mnuShowSelectedPOM2
        '
        Me.mnuShowSelectedPOM2.Image = CType(resources.GetObject("mnuShowSelectedPOM2.Image"), System.Drawing.Image)
        Me.mnuShowSelectedPOM2.Name = "mnuShowSelectedPOM2"
        Me.mnuShowSelectedPOM2.Size = New System.Drawing.Size(269, 22)
        Me.mnuShowSelectedPOM2.Text = "Show Selected Bill POM"
        Me.mnuShowSelectedPOM2.ToolTipText = "Show Selected Bills Proof Of Mail"
        '
        'mnuFindPOM2
        '
        Me.mnuFindPOM2.Image = CType(resources.GetObject("mnuFindPOM2.Image"), System.Drawing.Image)
        Me.mnuFindPOM2.Name = "mnuFindPOM2"
        Me.mnuFindPOM2.Size = New System.Drawing.Size(269, 22)
        Me.mnuFindPOM2.Text = "Find POM"
        Me.mnuFindPOM2.ToolTipText = "Find Proof Of Mail"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.AutoSize = False
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(10, 25)
        '
        'mnuAttorney2
        '
        Me.mnuAttorney2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSendToAttorney2, Me.mnuRemoveBillFromAttorney2, Me.ToolStripSeparator27, Me.ToolStripMenuItem5, Me.ClearAttorneyCaseNumberToolStripMenuItem1, Me.ToolStripSeparator39, Me.ToolStripMenuItem1, Me.ToolStripSeparator41, Me.mnuReprintCoverpage1, Me.ToolStripSeparator47, Me.ToolStripMenuItem14, Me.ToolStripSeparator19, Me.ToolStripMenuItem10})
        Me.mnuAttorney2.Image = CType(resources.GetObject("mnuAttorney2.Image"), System.Drawing.Image)
        Me.mnuAttorney2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuAttorney2.Name = "mnuAttorney2"
        Me.mnuAttorney2.Size = New System.Drawing.Size(82, 22)
        Me.mnuAttorney2.Text = "Attorney"
        Me.mnuAttorney2.ToolTipText = "Attorney Asignment"
        '
        'mnuSendToAttorney2
        '
        Me.mnuSendToAttorney2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.mnuSendToAttorney2.Image = CType(resources.GetObject("mnuSendToAttorney2.Image"), System.Drawing.Image)
        Me.mnuSendToAttorney2.Name = "mnuSendToAttorney2"
        Me.mnuSendToAttorney2.Size = New System.Drawing.Size(303, 22)
        Me.mnuSendToAttorney2.Text = "Assign Selected Bill To Attorney"
        Me.mnuSendToAttorney2.ToolTipText = "Assign / Send Checked Bills To Attorney"
        '
        'mnuRemoveBillFromAttorney2
        '
        Me.mnuRemoveBillFromAttorney2.ForeColor = System.Drawing.Color.Firebrick
        Me.mnuRemoveBillFromAttorney2.Image = CType(resources.GetObject("mnuRemoveBillFromAttorney2.Image"), System.Drawing.Image)
        Me.mnuRemoveBillFromAttorney2.Name = "mnuRemoveBillFromAttorney2"
        Me.mnuRemoveBillFromAttorney2.Size = New System.Drawing.Size(303, 22)
        Me.mnuRemoveBillFromAttorney2.Text = "Remove Selected Bill From Attorney"
        Me.mnuRemoveBillFromAttorney2.ToolTipText = "Remove Selected Bill From Attorney"
        '
        'ToolStripSeparator27
        '
        Me.ToolStripSeparator27.Name = "ToolStripSeparator27"
        Me.ToolStripSeparator27.Size = New System.Drawing.Size(300, 6)
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ToolStripMenuItem5.Image = CType(resources.GetObject("ToolStripMenuItem5.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItem5.Text = "Assign Selected Bill Atorney Case Number"
        '
        'ClearAttorneyCaseNumberToolStripMenuItem1
        '
        Me.ClearAttorneyCaseNumberToolStripMenuItem1.ForeColor = System.Drawing.Color.Firebrick
        Me.ClearAttorneyCaseNumberToolStripMenuItem1.Image = CType(resources.GetObject("ClearAttorneyCaseNumberToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ClearAttorneyCaseNumberToolStripMenuItem1.Name = "ClearAttorneyCaseNumberToolStripMenuItem1"
        Me.ClearAttorneyCaseNumberToolStripMenuItem1.Size = New System.Drawing.Size(303, 22)
        Me.ClearAttorneyCaseNumberToolStripMenuItem1.Text = "Remove Attorney Case number"
        '
        'ToolStripSeparator39
        '
        Me.ToolStripSeparator39.Name = "ToolStripSeparator39"
        Me.ToolStripSeparator39.Size = New System.Drawing.Size(300, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItem1.Text = "Assign Atorney Case Number Management"
        '
        'ToolStripSeparator41
        '
        Me.ToolStripSeparator41.Name = "ToolStripSeparator41"
        Me.ToolStripSeparator41.Size = New System.Drawing.Size(300, 6)
        '
        'mnuReprintCoverpage1
        '
        Me.mnuReprintCoverpage1.Image = CType(resources.GetObject("mnuReprintCoverpage1.Image"), System.Drawing.Image)
        Me.mnuReprintCoverpage1.Name = "mnuReprintCoverpage1"
        Me.mnuReprintCoverpage1.Size = New System.Drawing.Size(303, 22)
        Me.mnuReprintCoverpage1.Text = "RePrint Selected Bill Coverpage"
        '
        'ToolStripSeparator47
        '
        Me.ToolStripSeparator47.Name = "ToolStripSeparator47"
        Me.ToolStripSeparator47.Size = New System.Drawing.Size(300, 6)
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Image = CType(resources.GetObject("ToolStripMenuItem14.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItem14.Text = "Attorney Fees"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(300, 6)
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Image = CType(resources.GetObject("ToolStripMenuItem10.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItem10.Text = "Attorney Documents Access"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.AutoSize = False
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(10, 25)
        '
        'mnuCollection2
        '
        Me.mnuCollection2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelectedBillPayment2, Me.ToolStripMenuItemTodayPayments, Me.ToolStripMenuItem3, Me.PaymentsProgressAnalysisToolStripMenuItem, Me.ToolStripSeparator30, Me.mnuAddSelectedBillNotes3, Me.ToolStripSeparator29, Me.mnuBillDenied2, Me.ToolStripSeparator36, Me.ToolStripMenuItemBillingRequest1, Me.ToolStripSeparator44, Me.CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem})
        Me.mnuCollection2.Image = CType(resources.GetObject("mnuCollection2.Image"), System.Drawing.Image)
        Me.mnuCollection2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuCollection2.Name = "mnuCollection2"
        Me.mnuCollection2.Size = New System.Drawing.Size(90, 22)
        Me.mnuCollection2.Text = "Collection"
        Me.mnuCollection2.ToolTipText = "Bill Collection Tools"
        '
        'mnuSelectedBillPayment2
        '
        Me.mnuSelectedBillPayment2.ForeColor = System.Drawing.Color.ForestGreen
        Me.mnuSelectedBillPayment2.Image = CType(resources.GetObject("mnuSelectedBillPayment2.Image"), System.Drawing.Image)
        Me.mnuSelectedBillPayment2.Name = "mnuSelectedBillPayment2"
        Me.mnuSelectedBillPayment2.Size = New System.Drawing.Size(322, 22)
        Me.mnuSelectedBillPayment2.Text = "Add Selected Bill Payment"
        '
        'ToolStripMenuItemTodayPayments
        '
        Me.ToolStripMenuItemTodayPayments.Image = CType(resources.GetObject("ToolStripMenuItemTodayPayments.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemTodayPayments.Name = "ToolStripMenuItemTodayPayments"
        Me.ToolStripMenuItemTodayPayments.Size = New System.Drawing.Size(322, 22)
        Me.ToolStripMenuItemTodayPayments.Text = "Bank Deposits"
        Me.ToolStripMenuItemTodayPayments.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(322, 22)
        Me.ToolStripMenuItem3.Text = "Find Payment Check"
        '
        'PaymentsProgressAnalysisToolStripMenuItem
        '
        Me.PaymentsProgressAnalysisToolStripMenuItem.Image = CType(resources.GetObject("PaymentsProgressAnalysisToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PaymentsProgressAnalysisToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PaymentsProgressAnalysisToolStripMenuItem.Name = "PaymentsProgressAnalysisToolStripMenuItem"
        Me.PaymentsProgressAnalysisToolStripMenuItem.Size = New System.Drawing.Size(322, 22)
        Me.PaymentsProgressAnalysisToolStripMenuItem.Text = "Payments Progress Analysis"
        '
        'ToolStripSeparator30
        '
        Me.ToolStripSeparator30.Name = "ToolStripSeparator30"
        Me.ToolStripSeparator30.Size = New System.Drawing.Size(319, 6)
        '
        'mnuAddSelectedBillNotes3
        '
        Me.mnuAddSelectedBillNotes3.Image = CType(resources.GetObject("mnuAddSelectedBillNotes3.Image"), System.Drawing.Image)
        Me.mnuAddSelectedBillNotes3.Name = "mnuAddSelectedBillNotes3"
        Me.mnuAddSelectedBillNotes3.Size = New System.Drawing.Size(322, 22)
        Me.mnuAddSelectedBillNotes3.Text = "Add Notes"
        '
        'ToolStripSeparator29
        '
        Me.ToolStripSeparator29.Name = "ToolStripSeparator29"
        Me.ToolStripSeparator29.Size = New System.Drawing.Size(319, 6)
        '
        'mnuBillDenied2
        '
        Me.mnuBillDenied2.Image = CType(resources.GetObject("mnuBillDenied2.Image"), System.Drawing.Image)
        Me.mnuBillDenied2.Name = "mnuBillDenied2"
        Me.mnuBillDenied2.Size = New System.Drawing.Size(322, 22)
        Me.mnuBillDenied2.Text = "Selected Bill Denied"
        '
        'ToolStripSeparator36
        '
        Me.ToolStripSeparator36.Name = "ToolStripSeparator36"
        Me.ToolStripSeparator36.Size = New System.Drawing.Size(319, 6)
        '
        'ToolStripMenuItemBillingRequest1
        '
        Me.ToolStripMenuItemBillingRequest1.Image = CType(resources.GetObject("ToolStripMenuItemBillingRequest1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemBillingRequest1.Name = "ToolStripMenuItemBillingRequest1"
        Me.ToolStripMenuItemBillingRequest1.Size = New System.Drawing.Size(322, 22)
        Me.ToolStripMenuItemBillingRequest1.Text = "Billing Request"
        '
        'ToolStripSeparator44
        '
        Me.ToolStripSeparator44.Name = "ToolStripSeparator44"
        Me.ToolStripSeparator44.Size = New System.Drawing.Size(319, 6)
        '
        'CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem
        '
        Me.CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem.Name = "CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem"
        Me.CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(322, 22)
        Me.CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem.Text = "Court Index Number / Filing Date Maintenance"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.Maroon
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(82, 22)
        Me.ToolStripButton2.Text = "Attentions"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Margin = New System.Windows.Forms.Padding(0, 0, 12, 0)
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripButton3.Text = "Payment"
        Me.ToolStripButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripButton7.Text = "Denial"
        Me.ToolStripButton7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
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
        Me.ToolStripButtonDetach.Visible = False
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator24.Visible = False
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Image = CType(resources.GetObject("ToolStripMenuItem11.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(110, 25)
        Me.ToolStripMenuItem11.Text = "Attorney Docs"
        Me.ToolStripMenuItem11.Visible = False
        '
        'ToolStripSeparator34
        '
        Me.ToolStripSeparator34.Name = "ToolStripSeparator34"
        Me.ToolStripSeparator34.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripButton9.Text = "Bill Lost"
        Me.ToolStripButton9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator37
        '
        Me.ToolStripSeparator37.Name = "ToolStripSeparator37"
        Me.ToolStripSeparator37.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Image = CType(resources.GetObject("ToolStripMenuItem4.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(99, 25)
        Me.ToolStripMenuItem4.Text = "LN Attorney"
        Me.ToolStripMenuItem4.ToolTipText = "Lien Attorney"
        '
        'ToolStripSeparator49
        '
        Me.ToolStripSeparator49.Name = "ToolStripSeparator49"
        Me.ToolStripSeparator49.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Image = CType(resources.GetObject("ToolStripMenuItem15.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem15.Margin = New System.Windows.Forms.Padding(0, 1, 1, 2)
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        Me.ToolStripMenuItem15.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripMenuItem15.Text = "Patient"
        Me.ToolStripMenuItem15.ToolTipText = "Open Patient Profile"
        '
        'ToolStripSeparator53
        '
        Me.ToolStripSeparator53.Name = "ToolStripSeparator53"
        Me.ToolStripSeparator53.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtoneFile
        '
        Me.ToolStripButtoneFile.Image = CType(resources.GetObject("ToolStripButtoneFile.Image"), System.Drawing.Image)
        Me.ToolStripButtoneFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtoneFile.Name = "ToolStripButtoneFile"
        Me.ToolStripButtoneFile.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButtoneFile.Text = "e-File"
        Me.ToolStripButtoneFile.Visible = False
        '
        'ToolStripButton13
        '
        Me.ToolStripButton13.Image = CType(resources.GetObject("ToolStripButton13.Image"), System.Drawing.Image)
        Me.ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton13.Text = "Search"
        '
        'FpSpreadForPrint
        '
        Me.FpSpreadForPrint.AccessibleDescription = "FpSpreadForPrint, Sheet1, Row 0, Column 0, "
        Me.FpSpreadForPrint.AllowCellOverflow = True
        Me.FpSpreadForPrint.AllowColumnMove = True
        Me.FpSpreadForPrint.AllowDragDrop = True
        Me.FpSpreadForPrint.AllowDragFill = True
        Me.FpSpreadForPrint.AllowDrop = True
        Me.FpSpreadForPrint.AllowEditOverflow = True
        Me.FpSpreadForPrint.AllowRowMove = True
        Me.FpSpreadForPrint.AllowSheetMove = True
        Me.FpSpreadForPrint.AllowUserFormulas = True
        Me.FpSpreadForPrint.BackColor = System.Drawing.SystemColors.Control
        Me.FpSpreadForPrint.Location = New System.Drawing.Point(26, 286)
        Me.FpSpreadForPrint.Name = "FpSpreadForPrint"
        Me.FpSpreadForPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpreadForPrint.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpreadForPrint_Sheet1})
        Me.FpSpreadForPrint.Size = New System.Drawing.Size(161, 151)
        Me.FpSpreadForPrint.TabIndex = 119
        Me.FpSpreadForPrint.Visible = False
        '
        'FpSpreadForPrint_Sheet1
        '
        Me.FpSpreadForPrint_Sheet1.Reset()
        Me.FpSpreadForPrint_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpreadForPrint_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpreadForPrint_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpreadForPrint_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'PanelAttention
        '
        Me.PanelAttention.BackColor = System.Drawing.Color.Snow
        Me.PanelAttention.Controls.Add(Me.ListViewAttention)
        Me.PanelAttention.Controls.Add(Me.Panel2)
        Me.PanelAttention.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAttention.Location = New System.Drawing.Point(0, 0)
        Me.PanelAttention.Name = "PanelAttention"
        Me.PanelAttention.Size = New System.Drawing.Size(942, 165)
        Me.PanelAttention.TabIndex = 121
        '
        'ListViewAttention
        '
        Me.ListViewAttention.AllowColumnReorder = True
        Me.ListViewAttention.BackColor = System.Drawing.Color.Snow
        Me.ListViewAttention.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader13, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20})
        Me.ListViewAttention.ContextMenuStrip = Me.ContextMenuStripWarnings
        Me.ListViewAttention.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewAttention.FullRowSelect = True
        Me.ListViewAttention.GridLines = True
        Me.ListViewAttention.HideSelection = False
        Me.ListViewAttention.LabelWrap = False
        Me.ListViewAttention.LargeImageList = Me.ImageList2
        Me.ListViewAttention.Location = New System.Drawing.Point(0, 20)
        Me.ListViewAttention.Margin = New System.Windows.Forms.Padding(0)
        Me.ListViewAttention.MultiSelect = False
        Me.ListViewAttention.Name = "ListViewAttention"
        Me.ListViewAttention.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListViewAttention.ShowGroups = False
        Me.ListViewAttention.ShowItemToolTips = True
        Me.ListViewAttention.Size = New System.Drawing.Size(942, 145)
        Me.ListViewAttention.SmallImageList = Me.ImageList2
        Me.ListViewAttention.TabIndex = 0
        Me.ListViewAttention.UseCompatibleStateImageBehavior = False
        Me.ListViewAttention.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Type"
        Me.ColumnHeader13.Width = 166
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Bill #"
        Me.ColumnHeader16.Width = 181
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Age"
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Patient"
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Service DT"
        Me.ColumnHeader19.Width = 159
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Information"
        '
        'ContextMenuStripWarnings
        '
        Me.ContextMenuStripWarnings.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemWShiwPatientInformation, Me.ToolStripMenuItemWBillingRequest, Me.ToolStripMenuItemShowPatientBill})
        Me.ContextMenuStripWarnings.Name = "ContextMenuStripWarnings"
        Me.ContextMenuStripWarnings.Size = New System.Drawing.Size(218, 70)
        '
        'ToolStripMenuItemWShiwPatientInformation
        '
        Me.ToolStripMenuItemWShiwPatientInformation.Image = CType(resources.GetObject("ToolStripMenuItemWShiwPatientInformation.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemWShiwPatientInformation.Name = "ToolStripMenuItemWShiwPatientInformation"
        Me.ToolStripMenuItemWShiwPatientInformation.Size = New System.Drawing.Size(217, 22)
        Me.ToolStripMenuItemWShiwPatientInformation.Text = "Show Patient's Information"
        '
        'ToolStripMenuItemWBillingRequest
        '
        Me.ToolStripMenuItemWBillingRequest.Image = CType(resources.GetObject("ToolStripMenuItemWBillingRequest.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemWBillingRequest.Name = "ToolStripMenuItemWBillingRequest"
        Me.ToolStripMenuItemWBillingRequest.Size = New System.Drawing.Size(217, 22)
        Me.ToolStripMenuItemWBillingRequest.Text = "Billing Request"
        '
        'ToolStripMenuItemShowPatientBill
        '
        Me.ToolStripMenuItemShowPatientBill.Image = CType(resources.GetObject("ToolStripMenuItemShowPatientBill.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemShowPatientBill.Name = "ToolStripMenuItemShowPatientBill"
        Me.ToolStripMenuItemShowPatientBill.Size = New System.Drawing.Size(217, 22)
        Me.ToolStripMenuItemShowPatientBill.Text = "Show Bill"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.PictureBoxClose)
        Me.Panel2.Controls.Add(Me.LabelAttentionsCount)
        Me.Panel2.Controls.Add(Me.RadioButtonF4)
        Me.Panel2.Controls.Add(Me.RadioButtonF3)
        Me.Panel2.Controls.Add(Me.RadioButtonF2)
        Me.Panel2.Controls.Add(Me.RadioButtonF1)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(942, 20)
        Me.Panel2.TabIndex = 15
        '
        'LabelAttentionsCount
        '
        Me.LabelAttentionsCount.AutoSize = True
        Me.LabelAttentionsCount.Location = New System.Drawing.Point(668, 5)
        Me.LabelAttentionsCount.Name = "LabelAttentionsCount"
        Me.LabelAttentionsCount.Size = New System.Drawing.Size(0, 13)
        Me.LabelAttentionsCount.TabIndex = 21
        Me.LabelAttentionsCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.LabelAttentionsCount.UseMnemonic = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(5, 4)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(131, 15)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "ATTENTION REQUIRED"
        '
        'TimerCheckWarnings
        '
        Me.TimerCheckWarnings.Interval = 2000
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PanelAttention)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Panel1MinSize = 150
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListViewPatients)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Panel2MinSize = 150
        Me.SplitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Size = New System.Drawing.Size(942, 436)
        Me.SplitContainer1.SplitterDistance = 165
        Me.SplitContainer1.SplitterWidth = 8
        Me.SplitContainer1.TabIndex = 122
        '
        'ListViewPatients
        '
        Me.ListViewPatients.AllowColumnReorder = True
        Me.ListViewPatients.CheckBoxes = True
        Me.ListViewPatients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PatientNo, Me.PatientName, Me.DOA, Me.CaseType, Me.BillID, Me.BillDT, Me.PolicyNo, Me.ClaimNo, Me.Amt, Me.Status, Me.Insurance, Me.ServiceDT, Me.Attorney, Me.AttorneyDT, Me.POM, Me.PaidAmount, Me.Balance, Me.Doctor, Me.AdjusterName, Me.AttorneyCaseNumber, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader11, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader26, Me.ColumnHeader23, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader34, Me.ColumnHeader43, Me.ColumnHeader44, Me.ColumnHeader45})
        Me.ListViewPatients.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListViewPatients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewPatients.FullRowSelect = True
        Me.ListViewPatients.GridLines = True
        Me.ListViewPatients.HideSelection = False
        Me.ListViewPatients.LabelWrap = False
        Me.ListViewPatients.LargeImageList = Me.ImageList1
        Me.ListViewPatients.Location = New System.Drawing.Point(0, 19)
        Me.ListViewPatients.Margin = New System.Windows.Forms.Padding(0)
        Me.ListViewPatients.MultiSelect = False
        Me.ListViewPatients.Name = "ListViewPatients"
        Me.ListViewPatients.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListViewPatients.ShowGroups = False
        Me.ListViewPatients.ShowItemToolTips = True
        Me.ListViewPatients.Size = New System.Drawing.Size(942, 244)
        Me.ListViewPatients.SmallImageList = Me.ImageList1
        Me.ListViewPatients.TabIndex = 0
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
        Me.PatientName.Width = 166
        '
        'DOA
        '
        Me.DOA.Text = "DOA"
        Me.DOA.Width = 181
        '
        'CaseType
        '
        Me.CaseType.Text = "Type"
        '
        'BillID
        '
        Me.BillID.Text = "Bill #"
        '
        'BillDT
        '
        Me.BillDT.Text = "Bill DT"
        Me.BillDT.Width = 159
        '
        'PolicyNo
        '
        Me.PolicyNo.Text = "Policy #"
        '
        'ClaimNo
        '
        Me.ClaimNo.Text = "Claim #"
        '
        'Amt
        '
        Me.Amt.Text = "Amt $"
        Me.Amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Status
        '
        Me.Status.Text = "Status"
        '
        'Insurance
        '
        Me.Insurance.Text = "Insurance"
        '
        'ServiceDT
        '
        Me.ServiceDT.Text = "Service DT"
        '
        'Attorney
        '
        Me.Attorney.Text = "Attorney"
        '
        'AttorneyDT
        '
        Me.AttorneyDT.Text = "Attorney DT"
        '
        'POM
        '
        Me.POM.Text = "POM"
        '
        'PaidAmount
        '
        Me.PaidAmount.Text = "Paid Amt $"
        Me.PaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Balance
        '
        Me.Balance.Text = "Balance $"
        Me.Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Doctor
        '
        Me.Doctor.Text = "Treating Provider"
        '
        'AdjusterName
        '
        Me.AdjusterName.Text = "Adjuster Name"
        '
        'AttorneyCaseNumber
        '
        Me.AttorneyCaseNumber.Text = "Attorney Case #"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Requests"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Check DT"
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Case Status"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Billing Provider"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Adjuster Phone"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "No More Collection"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Attorney Conf DT"
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Index Number"
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "Filing Date"
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.DisplayIndex = 30
        Me.ColumnHeader21.Text = "Filing Fee"
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.DisplayIndex = 31
        Me.ColumnHeader22.Text = "Filing Fee Paid DT"
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.DisplayIndex = 29
        Me.ColumnHeader26.Text = "Attorney Fees"
        Me.ColumnHeader26.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Patient Attorney"
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "DOB"
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "Lien Attorney"
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "Lien Date"
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "BillToPatient DT"
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "Denials"
        '
        'ColumnHeader43
        '
        Me.ColumnHeader43.Text = "Payment Posted DT"
        '
        'ColumnHeader44
        '
        Me.ColumnHeader44.Text = "e-File ID"
        '
        'ColumnHeader45
        '
        Me.ColumnHeader45.Text = "e-File Date"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblCaption)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(942, 19)
        Me.Panel3.TabIndex = 121
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.BackColor = System.Drawing.Color.Transparent
        Me.lblCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCaption.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblCaption.Location = New System.Drawing.Point(5, 3)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(37, 15)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Text = "BILLS"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 12
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.78378!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.43478!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.08212!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxRefOffice, 7, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePickerAttorneyTo, 6, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPatient, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboBillingCompany, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboAttorneysCompanyID, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBillNumber, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboBillingProvider, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePickerAttorneyFrom, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboInsuranceCompanyID, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePaymentFrom, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboCaseTypeID, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePickerFrom, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePaymentTo, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePickerTo, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonFind, 11, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboBillStatus, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label19, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDiagnostic, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPaymentNote, 8, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 8, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDenial, 9, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label20, 9, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label21, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonClear, 10, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLienAttorney, 9, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 2, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 64)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(1, 1, 1, 6)
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1308, 90)
        Me.TableLayoutPanel1.TabIndex = 123
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(813, 41)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 13)
        Me.Label19.TabIndex = 275
        Me.Label19.Text = "Ref Office"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(1096, 41)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 13)
        Me.Label20.TabIndex = 277
        Me.Label20.Text = "Denial Rsn"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(1096, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 13)
        Me.Label21.TabIndex = 278
        Me.Label21.Text = "Accession"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboLienAttorney
        '
        Me.cboLienAttorney.BackColor = System.Drawing.Color.White
        Me.cboLienAttorney.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLienAttorney.DropDownWidth = 400
        Me.cboLienAttorney.FormattingEnabled = True
        Me.cboLienAttorney.LimitToList = True
        Me.cboLienAttorney.Location = New System.Drawing.Point(1096, 17)
        Me.cboLienAttorney.MaxNumericValue = 1.7976931348623157E+308R
        Me.cboLienAttorney.Name = "cboLienAttorney"
        Me.cboLienAttorney.NoDecimals = False
        Me.cboLienAttorney.NumericOnly = False
        Me.cboLienAttorney.ReadOnlyCombo = False
        Me.cboLienAttorney.Size = New System.Drawing.Size(109, 21)
        Me.cboLienAttorney.TabIndex = 279
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel6, 2)
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Controls.Add(Me.chkPaymentSearch)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(221, 41)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(188, 16)
        Me.Panel6.TabIndex = 280
        '
        'Process1
        '
        Me.Process1.StartInfo.Domain = ""
        Me.Process1.StartInfo.LoadUserProfile = False
        Me.Process1.StartInfo.Password = Nothing
        Me.Process1.StartInfo.StandardErrorEncoding = Nothing
        Me.Process1.StartInfo.StandardOutputEncoding = Nothing
        Me.Process1.StartInfo.UserName = ""
        Me.Process1.SynchronizingObject = Me
        '
        'StatusStrip1
        '
        Me.StatusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelFound, Me.ToolStripStatusLabelChecked, Me.ToolStripLabelTotal, Me.ToolStripLabelPaidFound, Me.ToolStripStatusLabelBalanceFound, Me.ToolStripStatusLabelDeadDebt})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 436)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(942, 22)
        Me.StatusStrip1.TabIndex = 124
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelFound
        '
        Me.ToolStripStatusLabelFound.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripStatusLabelFound.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabelFound.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabelFound.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripStatusLabelFound.Margin = New System.Windows.Forms.Padding(0, 2, 5, 0)
        Me.ToolStripStatusLabelFound.Name = "ToolStripStatusLabelFound"
        Me.ToolStripStatusLabelFound.Size = New System.Drawing.Size(91, 20)
        Me.ToolStripStatusLabelFound.Text = "ToolStripLabel2"
        '
        'ToolStripStatusLabelChecked
        '
        Me.ToolStripStatusLabelChecked.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripStatusLabelChecked.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabelChecked.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabelChecked.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripStatusLabelChecked.Margin = New System.Windows.Forms.Padding(0, 2, 5, 0)
        Me.ToolStripStatusLabelChecked.Name = "ToolStripStatusLabelChecked"
        Me.ToolStripStatusLabelChecked.Size = New System.Drawing.Size(91, 20)
        Me.ToolStripStatusLabelChecked.Text = "ToolStripLabel3"
        '
        'ToolStripLabelTotal
        '
        Me.ToolStripLabelTotal.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabelTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripLabelTotal.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripLabelTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripLabelTotal.Margin = New System.Windows.Forms.Padding(0, 2, 5, 0)
        Me.ToolStripLabelTotal.Name = "ToolStripLabelTotal"
        Me.ToolStripLabelTotal.Size = New System.Drawing.Size(36, 20)
        Me.ToolStripLabelTotal.Text = "Total"
        '
        'ToolStripLabelPaidFound
        '
        Me.ToolStripLabelPaidFound.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabelPaidFound.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripLabelPaidFound.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripLabelPaidFound.Margin = New System.Windows.Forms.Padding(0, 2, 5, 0)
        Me.ToolStripLabelPaidFound.Name = "ToolStripLabelPaidFound"
        Me.ToolStripLabelPaidFound.Size = New System.Drawing.Size(68, 20)
        Me.ToolStripLabelPaidFound.Text = "PaidFound"
        '
        'ToolStripStatusLabelBalanceFound
        '
        Me.ToolStripStatusLabelBalanceFound.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripStatusLabelBalanceFound.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabelBalanceFound.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabelBalanceFound.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabelBalanceFound.Margin = New System.Windows.Forms.Padding(0, 2, 5, 0)
        Me.ToolStripStatusLabelBalanceFound.Name = "ToolStripStatusLabelBalanceFound"
        Me.ToolStripStatusLabelBalanceFound.Size = New System.Drawing.Size(86, 20)
        Me.ToolStripStatusLabelBalanceFound.Text = "BalanceFound"
        '
        'ToolStripStatusLabelDeadDebt
        '
        Me.ToolStripStatusLabelDeadDebt.ForeColor = System.Drawing.Color.Maroon
        Me.ToolStripStatusLabelDeadDebt.Name = "ToolStripStatusLabelDeadDebt"
        Me.ToolStripStatusLabelDeadDebt.Size = New System.Drawing.Size(62, 17)
        Me.ToolStripStatusLabelDeadDebt.Text = "Dead Debt"
        '
        'TimerDetails
        '
        Me.TimerDetails.Interval = 20
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 154)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer2.Panel1MinSize = 250
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.PanelBills)
        Me.SplitContainer2.Panel2MinSize = 200
        Me.SplitContainer2.Size = New System.Drawing.Size(1292, 458)
        Me.SplitContainer2.SplitterDistance = 942
        Me.SplitContainer2.TabIndex = 125
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(1107, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(158, 36)
        Me.Label22.TabIndex = 111
        Me.Label22.Text = "BILLING COLLECTION"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1265, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(43, 36)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 112
        Me.PictureBox1.TabStop = False
        '
        'PanelTop
        '
        Me.PanelTop.BackgroundImage = CType(resources.GetObject("PanelTop.BackgroundImage"), System.Drawing.Image)
        Me.PanelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelTop.Controls.Add(Me.Label23)
        Me.PanelTop.Controls.Add(Me.Label22)
        Me.PanelTop.Controls.Add(Me.PictureBox1)
        Me.PanelTop.Controls.Add(Me.Panel4)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1308, 39)
        Me.PanelTop.TabIndex = 127
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
        Me.Label23.TabIndex = 114
        Me.Label23.Text = "eMEDICAL OFFICE"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.ForeColor = System.Drawing.Color.DarkOrange
        Me.Panel4.Location = New System.Drawing.Point(0, 36)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1308, 3)
        Me.Panel4.TabIndex = 113
        '
        'frmBillingManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1308, 612)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.PanelShowBills)
        Me.Controls.Add(Me.FpSpreadForPrint)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.PanelTop)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1100, 650)
        Me.Name = "frmBillingManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Bills Management / Collection"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ButtonDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelShowBills.ResumeLayout(False)
        CType(Me.PictureBoxClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBills.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.PanelBillDetails.ResumeLayout(False)
        Me.PanelBillDetails.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ToolStrip7.ResumeLayout(False)
        Me.ToolStrip7.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ToolStrip6.ResumeLayout(False)
        Me.ToolStrip6.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.PanelDocumentWait.ResumeLayout(False)
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip8.ResumeLayout(False)
        Me.ToolStrip8.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        Me.SplitContainer4.Panel2.PerformLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.ToolStrip9.ResumeLayout(False)
        Me.ToolStrip9.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ContextMenuStripCustomizeToolStrip.ResumeLayout(False)
        CType(Me.FpSpreadForPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpreadForPrint_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelAttention.ResumeLayout(False)
        Me.ContextMenuStripWarnings.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCaseTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents txtPatient As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents PatientName As System.Windows.Forms.ColumnHeader
    Friend WithEvents DOA As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboAttorneysCompanyID As System.Windows.Forms.ComboBox
    Friend WithEvents BillDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PanelBills As System.Windows.Forms.Panel
    Friend WithEvents PolicyNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClaimNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Amt As System.Windows.Forms.ColumnHeader
    Friend WithEvents Status As System.Windows.Forms.ColumnHeader
    Friend WithEvents Insurance As System.Windows.Forms.ColumnHeader
    Friend WithEvents Attorney As System.Windows.Forms.ColumnHeader
    Friend WithEvents AttorneyDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents BillID As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatientNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ServiceDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuBillingTools1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CaseType As System.Windows.Forms.ColumnHeader
    Friend WithEvents PanelBillDetails As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ButtonDetails As System.Windows.Forms.PictureBox
    Friend WithEvents PanelShowBills As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TreeViewBills As System.Windows.Forms.TreeView
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents ListViewComments As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents mnuAddSelectedBillNotes1 As System.Windows.Forms.ToolStripButton
    Public WithEvents cboInsuranceCompanyID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBillNumber As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparatorSendToAttorneyToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuAttorney1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoveBillFromAttorney1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSendToAttorney1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents POM As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPOM2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuAttorney2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuSendToAttorney2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoveBillFromAttorney2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrinting1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintCheckedBills1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintCheckedEnvelopes1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPOM1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProcessSelectedPOM1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuShowSelectedPOM1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrintCheckedPOM1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrintCheckedPOM2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProcessSelectedPOM2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuShowSelectedPOM2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintSelectedFileLabel1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCollection1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectedBillPayment1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAddSelectedBillNotes2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCollection2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuSelectedBillPayment2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAddSelectedBillNotes3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFindPOM1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFindPOM2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaidAmount As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ListViewPayments As System.Windows.Forms.ListView
    Friend WithEvents PaymentDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents Amount As System.Windows.Forms.ColumnHeader
    Friend WithEvents Balance As System.Windows.Forms.ColumnHeader
    Friend WithEvents Doctor As System.Windows.Forms.ColumnHeader
    Friend WithEvents FpSpreadForPrint As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpreadForPrint_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrintResultList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintAll2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintCheckedOnly2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdjusterName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuReprintCoverpage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReprintCoverpage1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboBillingCompany As System.Windows.Forms.ComboBox
    Friend WithEvents mnuPrintSelectedBillReadings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DateTimePickerTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStripTools As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PrintCheckedBillsReadingsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AttorneyCaseNumber As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator27 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBillingTools2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuShowSelectedPatientInfo2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintSelectedBillReadings2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DateTimePickerAttorneyTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerAttorneyFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents mnuShowSelectedPatientInfo1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuBillDenied1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator30 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator29 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuBillDenied2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteBillToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator32 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteBillToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintCheckedBills3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemRequest As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator36 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemBillingRequest1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemPrintCover As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents DateTimePaymentTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePaymentFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboBillingProvider As System.Windows.Forms.ComboBox
    Friend WithEvents PanelAttention As System.Windows.Forms.Panel
    Friend WithEvents TimerCheckWarnings As System.Windows.Forms.Timer
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ListViewRequests As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents RadioButtonF3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonF2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonF1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonF4 As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelAttentionsCount As System.Windows.Forms.Label
    Friend WithEvents txtPatientComments As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents FindCheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboDiagnostic As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemTodayPayments As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripWarnings As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemWShiwPatientInformation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemWBillingRequest As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemShowPatientBill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboPaymentNote As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonFind As System.Windows.Forms.Button
    Friend WithEvents cboBillStatus As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ComboBoxRefOffice As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ToolStripAutoResize As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboDenial As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents AdminToolsToolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AdminToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeBillDateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeBillAmountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ChangePaymentAmountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearAttorneyCaseNumberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator39 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearAttorneyCaseNumberToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator41 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator42 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator43 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuReProduceSelectedBill1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator33 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator44 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Process1 As System.Diagnostics.Process
    Friend WithEvents ChangeBillStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator40 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentsProgressAnalysisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator46 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AttorneyFeesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator47 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem14 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator48 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportAttorneyDocumentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        FormsCollection.Forms.Add(Me)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        ' Add any initialization after the InitializeComponent() call.

    End Sub
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
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripMenuItem15 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelFound As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelChecked As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLabelTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLabelPaidFound As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelBalanceFound As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ListViewPatients As eMedicalOffice.clsListView
    Friend WithEvents ListViewAttention As System.Windows.Forms.ListView
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButtonCloseForm As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStripCustomizeToolStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CustomizeToolbarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerDetails As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabelDeadDebt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuUpdateAdjusterInformation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemItemizedCharges As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator31 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton9 As ToolStripButton
    Friend WithEvents ToolStripSeparator34 As ToolStripSeparator
    Friend WithEvents ToolStripFontIncrease As ToolStripButton
    Friend WithEvents ToolStripFonrDecrease As ToolStripButton
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents DeleteSelectedBillToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBoxClose As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblCaption As Label
    Friend WithEvents ColumnHeader27 As ColumnHeader
    Friend WithEvents ToolStripSeparator35 As ToolStripSeparator
    Friend WithEvents AssignLienAttorneyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cboLienAttorney As AutoCompleteComboBox
    Friend WithEvents ColumnHeader28 As ColumnHeader
    Friend WithEvents ColumnHeader29 As ColumnHeader
    Friend WithEvents ToolStripSeparator37 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents mnuPrintBillProgress As ToolStripMenuItem
    Friend WithEvents BillToPatientToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator38 As ToolStripSeparator
    Friend WithEvents ColumnHeader30 As ColumnHeader
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents ListViewBillToPatient As ListView
    Friend WithEvents ColumnHeader31 As ColumnHeader
    Friend WithEvents ColumnHeader32 As ColumnHeader
    Friend WithEvents ToolStrip6 As ToolStrip
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents ToolStripButton10 As ToolStripButton
    Friend WithEvents ColumnHeader33 As ColumnHeader
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem16 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator45 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem8 As ToolStripMenuItem
    Public WithEvents ToolStripButtonDetach As ToolStripButton
    Friend WithEvents ToolStripSeparator49 As ToolStripSeparator
    Friend WithEvents Label22 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ToolStripSeparator50 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem12 As ToolStripMenuItem
    Friend WithEvents Panel4 As Panel
    Public WithEvents PanelTop As Panel
    Friend WithEvents Label23 As Label
    Friend WithEvents ToolStripMenuItem17 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator51 As ToolStripSeparator
    Friend WithEvents ColumnHeader34 As ColumnHeader
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents ListViewDenials As ListView
    Friend WithEvents ColumnHeader35 As ColumnHeader
    Friend WithEvents ColumnHeader36 As ColumnHeader
    Friend WithEvents ColumnHeader37 As ColumnHeader
    Friend WithEvents txtDenialComments As TextBox
    Friend WithEvents ToolStrip7 As ToolStrip
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents ToolStripButton12 As ToolStripButton
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents pdfViewer As PdfiumViewer.PdfViewer
    Friend WithEvents ListViewDocs As ListView
    Friend WithEvents ColumnHeader38 As ColumnHeader
    Friend WithEvents ColumnHeader39 As ColumnHeader
    Friend WithEvents ToolStrip8 As ToolStrip
    Friend WithEvents ToolStripButtonDocuments As ToolStripButton
    Friend WithEvents ButtonScannDocument As ToolStripButton
    Friend WithEvents ToolStripButton11 As ToolStripButton
    Friend WithEvents Panel5 As Panel
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents ToolStrip9 As ToolStrip
    Friend WithEvents ToolStripLabel7 As ToolStripLabel
    Friend WithEvents ListViewPatientComments As ListView
    Friend WithEvents ColumnHeader40 As ColumnHeader
    Friend WithEvents ColumnHeader41 As ColumnHeader
    Friend WithEvents TextBoxCommentView As TextBox
    Friend WithEvents ButtonAddComments As ToolStripButton
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents ColumnHeader42 As ColumnHeader
    Friend WithEvents TextBoxCommentViewBy As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStripLabel8 As ToolStripLabel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents chkPaymentSearch As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents ColumnHeader43 As ColumnHeader
    Friend WithEvents PaymentsReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem18 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator52 As ToolStripSeparator
    Friend WithEvents PanelDocumentWait As Panel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Label123 As Label
    Friend WithEvents EFileSelectedBillToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButtoneFile As ToolStripButton
    Friend WithEvents ToolStripSeparator53 As ToolStripSeparator
    Friend WithEvents ColumnHeader44 As ColumnHeader
    Friend WithEvents ColumnHeader45 As ColumnHeader
    Friend WithEvents ToolStripButton13 As ToolStripButton
End Class
