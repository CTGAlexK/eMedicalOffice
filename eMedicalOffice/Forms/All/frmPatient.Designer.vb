<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPatient
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
        Dim frm As Form
        Try
            FormsCollection.Forms.Remove(Me)
        Catch ex As Exception

        End Try
        'Retry:
        '        For Each frm In FormsCollection.Forms
        '            If frm.Name = Me.Name Then
        '                FormsCollection.Forms.Remove(frm)
        '                GoTo Retry
        '            End If
        '        Next

    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim EnhancedColumnHeaderRenderer1 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatient))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CheckBoxNoMoreCollection = New System.Windows.Forms.CheckBox()
        Me.ToolStripProcedures = New System.Windows.Forms.ToolStrip()
        Me.ButtonAddProcedure = New System.Windows.Forms.ToolStripButton()
        Me.ButtonDeleteProcedure = New System.Windows.Forms.ToolStripButton()
        Me.ListViewProcedures = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader54 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader57 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader59 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripProcedures = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddProcedureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveProcedureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangeReferringDoctorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparatorPreCertification = New System.Windows.Forms.ToolStripSeparator()
        Me.PreCertificationCompleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreCertificationNotCompleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageListProcedures = New System.Windows.Forms.ImageList(Me.components)
        Me.txtEmployerAddressZip = New System.Windows.Forms.MaskedTextBox()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.cboEmployerAddressState = New System.Windows.Forms.ComboBox()
        Me.Label126 = New System.Windows.Forms.Label()
        Me.txtEmployerAddressCity = New System.Windows.Forms.TextBox()
        Me.Label125 = New System.Windows.Forms.Label()
        Me.LabelSMS = New System.Windows.Forms.Label()
        Me.ButtonProceduresAutosize = New System.Windows.Forms.Button()
        Me.LabelNotesLength = New System.Windows.Forms.Label()
        Me.ButtonCheckAddress = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ToolStrip7 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonCapturePhoto = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonPreview = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonPrintPhotoLabel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDeletePhoto = New System.Windows.Forms.ToolStripButton()
        Me.cboSuffix = New System.Windows.Forms.ComboBox()
        Me.CheckBoxNoMoreAppointmentsInd = New System.Windows.Forms.CheckBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.picPhoto = New System.Windows.Forms.PictureBox()
        Me.txtCommentsNew = New System.Windows.Forms.TextBox()
        Me.cboInjury = New System.Windows.Forms.ComboBox()
        Me.LabelIME = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.txtPlaceOfAccident = New System.Windows.Forms.TextBox()
        Me.txtTOA = New System.Windows.Forms.MaskedTextBox()
        Me.ContextMenuStripTime = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.SetTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.SetCurrentTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.CancelToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtEmergencyInfo = New System.Windows.Forms.TextBox()
        Me.ComboBoxStateOfAccident = New System.Windows.Forms.ComboBox()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtDOA = New System.Windows.Forms.MaskedTextBox()
        Me.ContextMenuPopUpCalendar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.ComboBoxCaseStatusID = New System.Windows.Forms.ComboBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.ComboBoxCaseTypeID = New System.Windows.Forms.ComboBox()
        Me.txtOccupation = New System.Windows.Forms.TextBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtInsertedDT = New System.Windows.Forms.TextBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxState = New System.Windows.Forms.ComboBox()
        Me.txtCaseStatusDT = New System.Windows.Forms.TextBox()
        Me.txtEmployerName = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.LabelDOB = New System.Windows.Forms.Label()
        Me.ComboBoxEmploymentStatusID = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtDOB = New System.Windows.Forms.MaskedTextBox()
        Me.txtZip = New System.Windows.Forms.MaskedTextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.ComboBoxSex = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmployerAddress = New System.Windows.Forms.TextBox()
        Me.lblNoMoreAppointmentsInd = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.txtEmployerPhone = New System.Windows.Forms.MaskedTextBox()
        Me.txtSSN = New System.Windows.Forms.MaskedTextBox()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPhone2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtMI = New System.Windows.Forms.TextBox()
        Me.txtCellPhone = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBoxMaritalStatusID = New System.Windows.Forms.ComboBox()
        Me.txtPhone1 = New System.Windows.Forms.MaskedTextBox()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LabelPreCertification = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.BtnAddPatientAttorney = New System.Windows.Forms.Button()
        Me.PanelWC = New System.Windows.Forms.Panel()
        Me.WCIcon = New System.Windows.Forms.PictureBox()
        Me.txtWCInsuranceCarrierAddressZip = New System.Windows.Forms.MaskedTextBox()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.txtWCCaseNumber = New System.Windows.Forms.TextBox()
        Me.cboWCInsuranceCarrierAddressState = New System.Windows.Forms.ComboBox()
        Me.txtWCCarrierCaseNumber = New System.Windows.Forms.TextBox()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.txtWCCarrierCode = New System.Windows.Forms.TextBox()
        Me.txtWCInsuranceCarrierAddressCity = New System.Windows.Forms.TextBox()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.txtWCPatientAccountNumber = New System.Windows.Forms.TextBox()
        Me.txtWCInsuranceCarrierAddress = New System.Windows.Forms.TextBox()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.txtWCEmployerInsuranceCarrier = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.ComboBoxInsuranceCompanyID = New eMedicalOffice.AutoCompleteComboBox()
        Me.cmdAddInsuranceAddress = New System.Windows.Forms.Button()
        Me.CheckBoxInsuranceVerifyed = New System.Windows.Forms.CheckBox()
        Me.ButtonShowInsurance = New System.Windows.Forms.Button()
        Me.cmdUnlockInsurance = New System.Windows.Forms.Button()
        Me.ComboBoxClaimAddress = New System.Windows.Forms.ComboBox()
        Me.LabelInsuranceCompany = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.PanelInsurance = New System.Windows.Forms.Panel()
        Me.txtPolicyNumber = New System.Windows.Forms.TextBox()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.txtPolicyHolderOccupation = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtPolicyHolderEmployerName = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtPolicyHolderEmployerAddress = New System.Windows.Forms.TextBox()
        Me.txtPolicyHolderEmployerPhone = New System.Windows.Forms.MaskedTextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.txtPolicyHolderSSN = New System.Windows.Forms.MaskedTextBox()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.txtPolicyHolderBirthDate = New System.Windows.Forms.MaskedTextBox()
        Me.txtPolicyHolderOtherDependents = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAdjusterComments = New System.Windows.Forms.TextBox()
        Me.txtGroupNumber = New System.Windows.Forms.TextBox()
        Me.txtIDNumber = New System.Windows.Forms.TextBox()
        Me.txtAdjusterPhone = New System.Windows.Forms.MaskedTextBox()
        Me.txtAdjuster = New System.Windows.Forms.TextBox()
        Me.txtPolicyHolderPhone = New System.Windows.Forms.MaskedTextBox()
        Me.txtPolicyHolderZip = New System.Windows.Forms.MaskedTextBox()
        Me.ComboBoxPolicyHolderState = New System.Windows.Forms.ComboBox()
        Me.txtPolicyHolderCity = New System.Windows.Forms.TextBox()
        Me.txtPolicyHolderAddress = New System.Windows.Forms.TextBox()
        Me.ComboBoxRelationToInsuredID = New System.Windows.Forms.ComboBox()
        Me.txtPolicyHolderLName = New System.Windows.Forms.TextBox()
        Me.txtPolicyHolderMI = New System.Windows.Forms.TextBox()
        Me.txtPolicyHolderFName = New System.Windows.Forms.TextBox()
        Me.txtClaimEffectiveDT = New System.Windows.Forms.MaskedTextBox()
        Me.txtClaimNumber = New System.Windows.Forms.TextBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.LabelEffectiveDate = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.PanelSecondaryInsurance = New System.Windows.Forms.Panel()
        Me.txtAdjusterComments1 = New System.Windows.Forms.TextBox()
        Me.txtAdjusterPhone1 = New System.Windows.Forms.MaskedTextBox()
        Me.txtAdjuster1 = New System.Windows.Forms.TextBox()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.Label119 = New System.Windows.Forms.Label()
        Me.txtClaimNumber1 = New System.Windows.Forms.TextBox()
        Me.Label116 = New System.Windows.Forms.Label()
        Me.cmdAddInsuranceAddress1 = New System.Windows.Forms.Button()
        Me.ComboBoxClaimAddress1 = New System.Windows.Forms.ComboBox()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.ButtonShowInsurance1 = New System.Windows.Forms.Button()
        Me.txtPolicyNumber1 = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.txtPolicyHolderOtherDependents1 = New System.Windows.Forms.TextBox()
        Me.txtPolicyHolderOccupation1 = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.txtPolicyHolderEmployerName1 = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.txtPolicyHolderEmployerAddress1 = New System.Windows.Forms.TextBox()
        Me.txtPolicyHolderEmployerPhone1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.txtPolicyHolderSSN1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.txtPolicyHolderBirthDate1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.ComboBoxInsuranceCompanyID1 = New System.Windows.Forms.ComboBox()
        Me.CheckBoxInsurance1Verifyed = New System.Windows.Forms.CheckBox()
        Me.txtGroupNumber1 = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtIDNumber1 = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.txtPolicyHolderPhone1 = New System.Windows.Forms.MaskedTextBox()
        Me.txtPolicyHolderZip1 = New System.Windows.Forms.MaskedTextBox()
        Me.ComboBoxPolicyHolderState1 = New System.Windows.Forms.ComboBox()
        Me.txtPolicyHolderCity1 = New System.Windows.Forms.TextBox()
        Me.txtPolicyHolderAddress1 = New System.Windows.Forms.TextBox()
        Me.ComboBoxRelationToInsuredID1 = New System.Windows.Forms.ComboBox()
        Me.txtPolicyHolderLName1 = New System.Windows.Forms.TextBox()
        Me.txtPolicyHolderMI1 = New System.Windows.Forms.TextBox()
        Me.txtPolicyHolderFName1 = New System.Windows.Forms.TextBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.txtNF2 = New System.Windows.Forms.TextBox()
        Me.chkNF2 = New System.Windows.Forms.CheckBox()
        Me.ComboBoxReferringDoctor = New System.Windows.Forms.ComboBox()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.chkPoliceReportReceived = New System.Windows.Forms.CheckBox()
        Me.chkInitialReportReceived = New System.Windows.Forms.CheckBox()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.txtVehicleOwner = New System.Windows.Forms.TextBox()
        Me.PictureBoxRefCompany = New System.Windows.Forms.PictureBox()
        Me.ComboBoxTransportationCompanyID = New System.Windows.Forms.ComboBox()
        Me.PictureBoxRefDoctor = New System.Windows.Forms.PictureBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cboBillingCompany = New System.Windows.Forms.ComboBox()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.ComboBoxReferringCompanyID = New System.Windows.Forms.ComboBox()
        Me.ComboBoxPatientTypeID = New System.Windows.Forms.ComboBox()
        Me.ComboBoxInjuryID = New System.Windows.Forms.ComboBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboPatientAttorney = New eMedicalOffice.AutoCompleteComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ButtonRotatePDF = New System.Windows.Forms.Button()
        Me.MenuPDFRotate = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelDocumentWait = New System.Windows.Forms.Panel()
        Me.Label124 = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New eMedicalOffice.RichTextBoxPrintCtrl()
        Me.pdfViewer = New PdfiumViewer.PdfViewer()
        Me.ButtonAutosizeDocuments = New System.Windows.Forms.Button()
        Me.ListViewDocs = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader47 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripDocuments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemRenameDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemRenameDocumentBar = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemDeleteDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.LabelDocument = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonEmail = New System.Windows.Forms.ToolStripButton()
        Me.ButtonScannDocument = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuScan = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonDeleteDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSaveAs = New System.Windows.Forms.ToolStripButton()
        Me.lblFileSize = New System.Windows.Forms.ToolStripLabel()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.ButtonAutosizeComments = New System.Windows.Forms.Button()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ButtonAddComments = New System.Windows.Forms.ToolStripButton()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.ListViewComments = New System.Windows.Forms.ListView()
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label45 = New System.Windows.Forms.Label()
        Me.TextBoxCommentView = New System.Windows.Forms.TextBox()
        Me.TabPageReadings = New System.Windows.Forms.TabPage()
        Me.ButtonReadingsAutoSize = New System.Windows.Forms.Button()
        Me.TextBoxReading = New System.Windows.Forms.TextBox()
        Me.ToolStripFontSize = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.cmdAddReading = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonUnlockReading = New System.Windows.Forms.ToolStripButton()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.ListViewReadings = New System.Windows.Forms.ListView()
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader58 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripReadings = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPageBills = New System.Windows.Forms.TabPage()
        Me.ButtonAutosizeBillComments = New System.Windows.Forms.Button()
        Me.ButtonAutosizeReadings = New System.Windows.Forms.Button()
        Me.ToolStrip8 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonShowBill = New System.Windows.Forms.ToolStripButton()
        Me.ShowBillsToolBarButton = New System.Windows.Forms.ToolStripButton()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.ListViewBillComments = New System.Windows.Forms.ListView()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListViewPayments = New System.Windows.Forms.ListView()
        Me.BillID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PaymentDT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PaymentType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CheckNumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Amount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Note = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label83 = New System.Windows.Forms.Label()
        Me.TreeViewBills = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExpandAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollapsAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPageLog = New System.Windows.Forms.TabPage()
        Me.ButtonAutosizePatientProfileLog = New System.Windows.Forms.Button()
        Me.ButtonAutosizeCancelationLog = New System.Windows.Forms.Button()
        Me.ListViewCancelations = New System.Windows.Forms.ListView()
        Me.ColumnHeader33 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader32 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label89 = New System.Windows.Forms.Label()
        Me.txtFieldsChanged = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.ListViewPatientLog = New System.Windows.Forms.ListView()
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.ButtonAutosizeRequestActions = New System.Windows.Forms.Button()
        Me.ButtonAutosizeRequests = New System.Windows.Forms.Button()
        Me.ToolStrip6 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ListViewRequests = New System.Windows.Forms.ListView()
        Me.ColumnHeader40 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader37 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader38 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader39 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader41 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader42 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader43 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader44 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader60 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.ListViewActions = New System.Windows.Forms.ListView()
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader35 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader36 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LabelActions = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.TabPageExamination = New System.Windows.Forms.TabPage()
        Me.ButtonAutosizeIME = New System.Windows.Forms.Button()
        Me.ListViewIME = New System.Windows.Forms.ListView()
        Me.ColumnHeader52 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader55 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader56 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader64 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonAddIME = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonEditIME = New System.Windows.Forms.ToolStripButton()
        Me.Label115 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ToolStrip9 = New System.Windows.Forms.ToolStrip()
        Me.ButtonPrintWebAccess = New System.Windows.Forms.ToolStripButton()
        Me.ButtonWebPassword = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonNavigateWebAccess = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonFaxWebAccessInfo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEmailWebAccessInformation = New System.Windows.Forms.ToolStripButton()
        Me.Label122 = New System.Windows.Forms.Label()
        Me.TextBoxWebURL = New System.Windows.Forms.TextBox()
        Me.Label120 = New System.Windows.Forms.Label()
        Me.TextBoxWebPassword = New System.Windows.Forms.TextBox()
        Me.TextBoxWebUid = New System.Windows.Forms.TextBox()
        Me.Label121 = New System.Windows.Forms.Label()
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NetSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparatorNetSearch = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintPatientsChartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPatientsFileLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPreScreenFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPatientsInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPatientsNF2FormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPatientsApplicationForBenefitsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSchedule = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAccidentRelatedPatientsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindDuplicatePatientsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.FindPatientBillsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImportPatientsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtPatientID = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ListViewPatients = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TimerLoad = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PanelPrinting = New System.Windows.Forms.Panel()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LabelFound = New System.Windows.Forms.Label()
        Me.ButtonTools = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdAddNew = New System.Windows.Forms.Button()
        Me.TimerPdfRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PanelSearch = New System.Windows.Forms.Panel()
        Me.MonthCalendarPopUp = New System.Windows.Forms.MonthCalendar()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.DateTimePickerPopUp = New System.Windows.Forms.DateTimePicker()
        Me.ListViewPatientsRelated = New System.Windows.Forms.ListView()
        Me.ColumnHeader45 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader46 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.imgWait1 = New System.Windows.Forms.PictureBox()
        Me.ComboBoxSearchCaseType = New System.Windows.Forms.ComboBox()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.ComboBoxSearchCaseStatus = New System.Windows.Forms.ComboBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.ImageListErrorProvider = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.TimerSearch = New System.Windows.Forms.Timer(Me.components)
        Me.TimerSearchFocus = New System.Windows.Forms.Timer(Me.components)
        Me.TimerDetails = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtDummy = New System.Windows.Forms.TextBox()
        Me.TimerSearchPatients = New System.Windows.Forms.Timer(Me.components)
        Me.TimerRefreshWhenMaximized = New System.Windows.Forms.Timer(Me.components)
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripFontIncrease = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripFonrDecrease = New System.Windows.Forms.ToolStripButton()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog2 = New System.Windows.Forms.PrintDialog()
        Me.PanelWait = New System.Windows.Forms.Panel()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.ToolStripProcedures.SuspendLayout
        Me.ContextMenuStripProcedures.SuspendLayout
        Me.Panel5.SuspendLayout
        Me.ToolStrip7.SuspendLayout
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).BeginInit
        Me.ContextMenuStripTime.SuspendLayout
        Me.ContextMenuPopUpCalendar.SuspendLayout
        Me.TabPage2.SuspendLayout
        Me.PanelWC.SuspendLayout
        CType(Me.WCIcon, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabControl3.SuspendLayout
        Me.TabPage7.SuspendLayout
        Me.PanelInsurance.SuspendLayout
        Me.TabPage9.SuspendLayout
        Me.PanelSecondaryInsurance.SuspendLayout
        Me.Panel4.SuspendLayout
        CType(Me.PictureBoxRefCompany, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBoxRefDoctor, System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPage3.SuspendLayout
        Me.MenuPDFRotate.SuspendLayout
        Me.PanelDocumentWait.SuspendLayout
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit
        Me.ContextMenuStripDocuments.SuspendLayout
        Me.ToolStrip2.SuspendLayout
        Me.TabPage5.SuspendLayout
        Me.ToolStrip3.SuspendLayout
        Me.TabPageReadings.SuspendLayout
        Me.ToolStripFontSize.SuspendLayout
        Me.ToolStrip4.SuspendLayout
        Me.ContextMenuStripReadings.SuspendLayout
        Me.TabPageBills.SuspendLayout
        Me.ToolStrip8.SuspendLayout
        Me.ContextMenuStrip2.SuspendLayout
        Me.TabPageLog.SuspendLayout
        Me.TabPage8.SuspendLayout
        Me.ToolStrip6.SuspendLayout
        Me.TabPageExamination.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        Me.TabPage4.SuspendLayout
        Me.ToolStrip9.SuspendLayout
        Me.ContextMenuStrip1.SuspendLayout
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel3.SuspendLayout
        Me.PanelPrinting.SuspendLayout
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit
        Me.PanelSearch.SuspendLayout
        Me.ContextMenuStrip3.SuspendLayout
        CType(Me.imgWait1, System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel2.SuspendLayout
        Me.Panel1.SuspendLayout
        Me.ToolStrip5.SuspendLayout
        Me.PanelWait.SuspendLayout
        Me.SuspendLayout
        EnhancedColumnHeaderRenderer1.Name = "EnhancedColumnHeaderRenderer1"
        EnhancedColumnHeaderRenderer1.TextRotationAngle = 0R
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPageReadings)
        Me.TabControl1.Controls.Add(Me.TabPageBills)
        Me.TabControl1.Controls.Add(Me.TabPageLog)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Controls.Add(Me.TabPageExamination)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ImageList = Me.ImageList4
        Me.TabControl1.Location = New System.Drawing.Point(265, 6)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(0, 0)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(771, 533)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.CheckBoxNoMoreCollection)
        Me.TabPage1.Controls.Add(Me.ToolStripProcedures)
        Me.TabPage1.Controls.Add(Me.ListViewProcedures)
        Me.TabPage1.Controls.Add(Me.txtEmployerAddressZip)
        Me.TabPage1.Controls.Add(Me.Label127)
        Me.TabPage1.Controls.Add(Me.cboEmployerAddressState)
        Me.TabPage1.Controls.Add(Me.Label126)
        Me.TabPage1.Controls.Add(Me.txtEmployerAddressCity)
        Me.TabPage1.Controls.Add(Me.Label125)
        Me.TabPage1.Controls.Add(Me.LabelSMS)
        Me.TabPage1.Controls.Add(Me.ButtonProceduresAutosize)
        Me.TabPage1.Controls.Add(Me.LabelNotesLength)
        Me.TabPage1.Controls.Add(Me.ButtonCheckAddress)
        Me.TabPage1.Controls.Add(Me.Panel5)
        Me.TabPage1.Controls.Add(Me.cboSuffix)
        Me.TabPage1.Controls.Add(Me.CheckBoxNoMoreAppointmentsInd)
        Me.TabPage1.Controls.Add(Me.Label47)
        Me.TabPage1.Controls.Add(Me.picPhoto)
        Me.TabPage1.Controls.Add(Me.txtCommentsNew)
        Me.TabPage1.Controls.Add(Me.cboInjury)
        Me.TabPage1.Controls.Add(Me.LabelIME)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Label105)
        Me.TabPage1.Controls.Add(Me.txtPlaceOfAccident)
        Me.TabPage1.Controls.Add(Me.txtTOA)
        Me.TabPage1.Controls.Add(Me.txtEmergencyInfo)
        Me.TabPage1.Controls.Add(Me.ComboBoxStateOfAccident)
        Me.TabPage1.Controls.Add(Me.Label94)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.txtDOA)
        Me.TabPage1.Controls.Add(Me.Label36)
        Me.TabPage1.Controls.Add(Me.ComboBoxCaseStatusID)
        Me.TabPage1.Controls.Add(Me.Label49)
        Me.TabPage1.Controls.Add(Me.ComboBoxCaseTypeID)
        Me.TabPage1.Controls.Add(Me.txtOccupation)
        Me.TabPage1.Controls.Add(Me.Label82)
        Me.TabPage1.Controls.Add(Me.Label33)
        Me.TabPage1.Controls.Add(Me.txtInsertedDT)
        Me.TabPage1.Controls.Add(Me.Label81)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.ComboBoxState)
        Me.TabPage1.Controls.Add(Me.txtCaseStatusDT)
        Me.TabPage1.Controls.Add(Me.txtEmployerName)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.txtCity)
        Me.TabPage1.Controls.Add(Me.LabelDOB)
        Me.TabPage1.Controls.Add(Me.ComboBoxEmploymentStatusID)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label64)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.txtDOB)
        Me.TabPage1.Controls.Add(Me.txtZip)
        Me.TabPage1.Controls.Add(Me.txtEmail)
        Me.TabPage1.Controls.Add(Me.ComboBoxSex)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtEmployerAddress)
        Me.TabPage1.Controls.Add(Me.lblNoMoreAppointmentsInd)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtAddress2)
        Me.TabPage1.Controls.Add(Me.txtComments)
        Me.TabPage1.Controls.Add(Me.txtLName)
        Me.TabPage1.Controls.Add(Me.txtEmployerPhone)
        Me.TabPage1.Controls.Add(Me.txtSSN)
        Me.TabPage1.Controls.Add(Me.txtAddress1)
        Me.TabPage1.Controls.Add(Me.Label79)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtPhone2)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.txtMI)
        Me.TabPage1.Controls.Add(Me.txtCellPhone)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.ComboBoxMaritalStatusID)
        Me.TabPage1.Controls.Add(Me.txtPhone1)
        Me.TabPage1.Controls.Add(Me.txtFName)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.LabelPreCertification)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(763, 506)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Patient Info"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'CheckBoxNoMoreCollection
        '
        Me.CheckBoxNoMoreCollection.AutoSize = True
        Me.CheckBoxNoMoreCollection.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxNoMoreCollection.Enabled = False
        Me.CheckBoxNoMoreCollection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxNoMoreCollection.Location = New System.Drawing.Point(410, 26)
        Me.CheckBoxNoMoreCollection.Name = "CheckBoxNoMoreCollection"
        Me.CheckBoxNoMoreCollection.Size = New System.Drawing.Size(113, 17)
        Me.CheckBoxNoMoreCollection.TabIndex = 300
        Me.CheckBoxNoMoreCollection.Text = "No More Collection"
        Me.CheckBoxNoMoreCollection.UseVisualStyleBackColor = False
        '
        'ToolStripProcedures
        '
        Me.ToolStripProcedures.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStripProcedures.AutoSize = False
        Me.ToolStripProcedures.BackColor = System.Drawing.Color.White
        Me.ToolStripProcedures.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripProcedures.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripProcedures.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStripProcedures.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonAddProcedure, Me.ButtonDeleteProcedure})
        Me.ToolStripProcedures.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStripProcedures.Location = New System.Drawing.Point(719, 394)
        Me.ToolStripProcedures.Name = "ToolStripProcedures"
        Me.ToolStripProcedures.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStripProcedures.Size = New System.Drawing.Size(23, 104)
        Me.ToolStripProcedures.TabIndex = 28
        Me.ToolStripProcedures.Text = "ToolStrip2"
        '
        'ButtonAddProcedure
        '
        Me.ButtonAddProcedure.BackColor = System.Drawing.Color.Transparent
        Me.ButtonAddProcedure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonAddProcedure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonAddProcedure.Enabled = False
        Me.ButtonAddProcedure.Image = CType(resources.GetObject("ButtonAddProcedure.Image"), System.Drawing.Image)
        Me.ButtonAddProcedure.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonAddProcedure.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonAddProcedure.Name = "ButtonAddProcedure"
        Me.ButtonAddProcedure.Size = New System.Drawing.Size(22, 20)
        Me.ButtonAddProcedure.Text = "Clear Card Front Image"
        Me.ButtonAddProcedure.ToolTipText = "Add Procedure"
        '
        'ButtonDeleteProcedure
        '
        Me.ButtonDeleteProcedure.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ButtonDeleteProcedure.BackColor = System.Drawing.Color.Transparent
        Me.ButtonDeleteProcedure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonDeleteProcedure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonDeleteProcedure.Enabled = False
        Me.ButtonDeleteProcedure.Image = CType(resources.GetObject("ButtonDeleteProcedure.Image"), System.Drawing.Image)
        Me.ButtonDeleteProcedure.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonDeleteProcedure.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDeleteProcedure.Name = "ButtonDeleteProcedure"
        Me.ButtonDeleteProcedure.Size = New System.Drawing.Size(22, 20)
        Me.ButtonDeleteProcedure.Text = "Rotate Left"
        Me.ButtonDeleteProcedure.ToolTipText = "Remove Procedure"
        '
        'ListViewProcedures
        '
        Me.ListViewProcedures.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewProcedures.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewProcedures.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader5, Me.ColumnHeader27, Me.ColumnHeader54, Me.ColumnHeader28, Me.ColumnHeader3, Me.ColumnHeader57, Me.ColumnHeader59})
        Me.ListViewProcedures.ContextMenuStrip = Me.ContextMenuStripProcedures
        Me.ListViewProcedures.FullRowSelect = True
        Me.ListViewProcedures.GridLines = True
        Me.ListViewProcedures.HideSelection = False
        Me.ErrorProvider1.SetIconAlignment(Me.ListViewProcedures, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ListViewProcedures.LargeImageList = Me.ImageListProcedures
        Me.ListViewProcedures.Location = New System.Drawing.Point(22, 393)
        Me.ListViewProcedures.MultiSelect = False
        Me.ListViewProcedures.Name = "ListViewProcedures"
        Me.ListViewProcedures.ShowGroups = False
        Me.ListViewProcedures.ShowItemToolTips = True
        Me.ListViewProcedures.Size = New System.Drawing.Size(690, 108)
        Me.ListViewProcedures.SmallImageList = Me.ImageListProcedures
        Me.ListViewProcedures.TabIndex = 33
        Me.ListViewProcedures.UseCompatibleStateImageBehavior = False
        Me.ListViewProcedures.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Schedule Date"
        Me.ColumnHeader6.Width = 114
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DisplayIndex = 2
        Me.ColumnHeader5.Text = "Procedure Name"
        Me.ColumnHeader5.Width = 134
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.DisplayIndex = 3
        Me.ColumnHeader27.Text = "Treating Provider"
        Me.ColumnHeader27.Width = 123
        '
        'ColumnHeader54
        '
        Me.ColumnHeader54.DisplayIndex = 5
        Me.ColumnHeader54.Text = "Billing Provider"
        Me.ColumnHeader54.Width = 111
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "Ref Doctor"
        Me.ColumnHeader28.Width = 104
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DisplayIndex = 1
        Me.ColumnHeader3.Text = "Type"
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader57
        '
        Me.ColumnHeader57.Text = "Comments"
        Me.ColumnHeader57.Width = 83
        '
        'ColumnHeader59
        '
        Me.ColumnHeader59.Text = "Pre-Cert"
        '
        'ContextMenuStripProcedures
        '
        Me.ContextMenuStripProcedures.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddProcedureToolStripMenuItem, Me.RemoveProcedureToolStripMenuItem, Me.ToolStripSeparator2, Me.ToolStripMenuItem3, Me.ToolStripSeparator6, Me.ChangeReferringDoctorToolStripMenuItem, Me.ToolStripSeparator7, Me.ToolStripMenuItem8, Me.ToolStripSeparatorPreCertification, Me.PreCertificationCompleteToolStripMenuItem, Me.PreCertificationNotCompleteToolStripMenuItem})
        Me.ContextMenuStripProcedures.Name = "ContextMenuStripProcedures"
        Me.ContextMenuStripProcedures.Size = New System.Drawing.Size(265, 182)
        '
        'AddProcedureToolStripMenuItem
        '
        Me.AddProcedureToolStripMenuItem.Image = CType(resources.GetObject("AddProcedureToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddProcedureToolStripMenuItem.Name = "AddProcedureToolStripMenuItem"
        Me.AddProcedureToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.AddProcedureToolStripMenuItem.Text = "Add Procedure"
        '
        'RemoveProcedureToolStripMenuItem
        '
        Me.RemoveProcedureToolStripMenuItem.Image = CType(resources.GetObject("RemoveProcedureToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RemoveProcedureToolStripMenuItem.Name = "RemoveProcedureToolStripMenuItem"
        Me.RemoveProcedureToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.RemoveProcedureToolStripMenuItem.Text = "Remove Procedure"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(261, 6)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(264, 22)
        Me.ToolStripMenuItem3.Text = "Replace Procedure"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(261, 6)
        '
        'ChangeReferringDoctorToolStripMenuItem
        '
        Me.ChangeReferringDoctorToolStripMenuItem.Image = CType(resources.GetObject("ChangeReferringDoctorToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ChangeReferringDoctorToolStripMenuItem.Name = "ChangeReferringDoctorToolStripMenuItem"
        Me.ChangeReferringDoctorToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.ChangeReferringDoctorToolStripMenuItem.Text = "Change Procedure Referring Doctor"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(261, 6)
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Image = CType(resources.GetObject("ToolStripMenuItem8.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(264, 22)
        Me.ToolStripMenuItem8.Text = "Change Procedure Treating Provider"
        '
        'ToolStripSeparatorPreCertification
        '
        Me.ToolStripSeparatorPreCertification.Name = "ToolStripSeparatorPreCertification"
        Me.ToolStripSeparatorPreCertification.Size = New System.Drawing.Size(261, 6)
        '
        'PreCertificationCompleteToolStripMenuItem
        '
        Me.PreCertificationCompleteToolStripMenuItem.Image = CType(resources.GetObject("PreCertificationCompleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PreCertificationCompleteToolStripMenuItem.Name = "PreCertificationCompleteToolStripMenuItem"
        Me.PreCertificationCompleteToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.PreCertificationCompleteToolStripMenuItem.Text = "Pre-Certification Verified"
        '
        'PreCertificationNotCompleteToolStripMenuItem
        '
        Me.PreCertificationNotCompleteToolStripMenuItem.Image = CType(resources.GetObject("PreCertificationNotCompleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PreCertificationNotCompleteToolStripMenuItem.Name = "PreCertificationNotCompleteToolStripMenuItem"
        Me.PreCertificationNotCompleteToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.PreCertificationNotCompleteToolStripMenuItem.Text = "Pre-Certification Not Verified"
        '
        'ImageListProcedures
        '
        Me.ImageListProcedures.ImageStream = CType(resources.GetObject("ImageListProcedures.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListProcedures.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListProcedures.Images.SetKeyName(0, "UnChecked.gif")
        Me.ImageListProcedures.Images.SetKeyName(1, "Checked.gif")
        Me.ImageListProcedures.Images.SetKeyName(2, "CheckedMid.gif")
        Me.ImageListProcedures.Images.SetKeyName(3, "CHeckRed.png")
        Me.ImageListProcedures.Images.SetKeyName(4, "CHeckRed.png")
        Me.ImageListProcedures.Images.SetKeyName(5, "SORT1")
        Me.ImageListProcedures.Images.SetKeyName(6, "SORT2")
        Me.ImageListProcedures.Images.SetKeyName(7, "SORT0")
        Me.ImageListProcedures.Images.SetKeyName(8, "Error.ico")
        '
        'txtEmployerAddressZip
        '
        Me.txtEmployerAddressZip.AccessibleDescription = ""
        Me.txtEmployerAddressZip.AccessibleName = ""
        Me.txtEmployerAddressZip.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmployerAddressZip.Enabled = False
        Me.txtEmployerAddressZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployerAddressZip.ForeColor = System.Drawing.Color.Black
        Me.txtEmployerAddressZip.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtEmployerAddressZip, -18)
        Me.txtEmployerAddressZip.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtEmployerAddressZip.Location = New System.Drawing.Point(389, 316)
        Me.txtEmployerAddressZip.Mask = "00000"
        Me.txtEmployerAddressZip.Name = "txtEmployerAddressZip"
        Me.txtEmployerAddressZip.Size = New System.Drawing.Size(73, 20)
        Me.txtEmployerAddressZip.TabIndex = 30
        Me.txtEmployerAddressZip.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Label127
        '
        Me.Label127.AutoSize = True
        Me.Label127.BackColor = System.Drawing.Color.Transparent
        Me.Label127.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label127.ForeColor = System.Drawing.Color.Black
        Me.Label127.Location = New System.Drawing.Point(386, 303)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(74, 13)
        Me.Label127.TabIndex = 299
        Me.Label127.Text = "Emp Zip Code"
        '
        'cboEmployerAddressState
        '
        Me.cboEmployerAddressState.AccessibleDescription = ""
        Me.cboEmployerAddressState.AccessibleName = ""
        Me.cboEmployerAddressState.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cboEmployerAddressState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmployerAddressState.Enabled = False
        Me.cboEmployerAddressState.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEmployerAddressState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmployerAddressState.ForeColor = System.Drawing.Color.Black
        Me.cboEmployerAddressState.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.cboEmployerAddressState, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.cboEmployerAddressState, -18)
        Me.cboEmployerAddressState.Location = New System.Drawing.Point(316, 316)
        Me.cboEmployerAddressState.Name = "cboEmployerAddressState"
        Me.cboEmployerAddressState.Size = New System.Drawing.Size(66, 21)
        Me.cboEmployerAddressState.TabIndex = 29
        '
        'Label126
        '
        Me.Label126.AutoSize = True
        Me.Label126.BackColor = System.Drawing.Color.Transparent
        Me.Label126.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label126.ForeColor = System.Drawing.Color.Black
        Me.Label126.Location = New System.Drawing.Point(313, 303)
        Me.Label126.Name = "Label126"
        Me.Label126.Size = New System.Drawing.Size(56, 13)
        Me.Label126.TabIndex = 297
        Me.Label126.Text = "Emp State"
        '
        'txtEmployerAddressCity
        '
        Me.txtEmployerAddressCity.AccessibleDescription = ""
        Me.txtEmployerAddressCity.AccessibleName = ""
        Me.txtEmployerAddressCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtEmployerAddressCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtEmployerAddressCity.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmployerAddressCity.Enabled = False
        Me.txtEmployerAddressCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployerAddressCity.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtEmployerAddressCity, -18)
        Me.txtEmployerAddressCity.Location = New System.Drawing.Point(208, 316)
        Me.txtEmployerAddressCity.MaxLength = 50
        Me.txtEmployerAddressCity.Name = "txtEmployerAddressCity"
        Me.txtEmployerAddressCity.Size = New System.Drawing.Size(102, 20)
        Me.txtEmployerAddressCity.TabIndex = 28
        '
        'Label125
        '
        Me.Label125.AutoSize = True
        Me.Label125.BackColor = System.Drawing.Color.Transparent
        Me.Label125.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label125.ForeColor = System.Drawing.Color.Black
        Me.Label125.Location = New System.Drawing.Point(207, 303)
        Me.Label125.Name = "Label125"
        Me.Label125.Size = New System.Drawing.Size(70, 13)
        Me.Label125.TabIndex = 295
        Me.Label125.Text = "Employer City"
        '
        'LabelSMS
        '
        Me.LabelSMS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelSMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelSMS.ForeColor = System.Drawing.Color.Red
        Me.LabelSMS.Image = CType(resources.GetObject("LabelSMS.Image"), System.Drawing.Image)
        Me.LabelSMS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelSMS.Location = New System.Drawing.Point(1, 245)
        Me.LabelSMS.Name = "LabelSMS"
        Me.LabelSMS.Size = New System.Drawing.Size(19, 16)
        Me.LabelSMS.TabIndex = 292
        Me.LabelSMS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LabelSMS, "Cell phone number is required for SMS reminder notifications to be sent")
        Me.LabelSMS.Visible = False
        '
        'ButtonProceduresAutosize
        '
        Me.ButtonProceduresAutosize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonProceduresAutosize.FlatAppearance.BorderSize = 0
        Me.ButtonProceduresAutosize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonProceduresAutosize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonProceduresAutosize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonProceduresAutosize.Image = CType(resources.GetObject("ButtonProceduresAutosize.Image"), System.Drawing.Image)
        Me.ButtonProceduresAutosize.Location = New System.Drawing.Point(444, 372)
        Me.ButtonProceduresAutosize.Name = "ButtonProceduresAutosize"
        Me.ButtonProceduresAutosize.Size = New System.Drawing.Size(16, 17)
        Me.ButtonProceduresAutosize.TabIndex = 289
        Me.ToolTip1.SetToolTip(Me.ButtonProceduresAutosize, "Autosize Spread Columns")
        Me.ButtonProceduresAutosize.UseVisualStyleBackColor = True
        '
        'LabelNotesLength
        '
        Me.LabelNotesLength.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelNotesLength.BackColor = System.Drawing.Color.Transparent
        Me.LabelNotesLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNotesLength.ForeColor = System.Drawing.Color.Black
        Me.LabelNotesLength.Location = New System.Drawing.Point(599, 228)
        Me.LabelNotesLength.Name = "LabelNotesLength"
        Me.LabelNotesLength.Size = New System.Drawing.Size(160, 13)
        Me.LabelNotesLength.TabIndex = 288
        Me.LabelNotesLength.Text = "Quick Notes"
        Me.LabelNotesLength.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ButtonCheckAddress
        '
        Me.ButtonCheckAddress.Enabled = False
        Me.ButtonCheckAddress.FlatAppearance.BorderSize = 0
        Me.ButtonCheckAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCheckAddress.Image = CType(resources.GetObject("ButtonCheckAddress.Image"), System.Drawing.Image)
        Me.ButtonCheckAddress.Location = New System.Drawing.Point(437, 203)
        Me.ButtonCheckAddress.Name = "ButtonCheckAddress"
        Me.ButtonCheckAddress.Size = New System.Drawing.Size(23, 26)
        Me.ButtonCheckAddress.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.ButtonCheckAddress, "Verify Address")
        Me.ButtonCheckAddress.UseVisualStyleBackColor = True
        Me.ButtonCheckAddress.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.ToolStrip7)
        Me.Panel5.Location = New System.Drawing.Point(472, 59)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(22, 96)
        Me.Panel5.TabIndex = 286
        '
        'ToolStrip7
        '
        Me.ToolStrip7.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip7.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip7.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip7.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip7.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip7.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonCapturePhoto, Me.ToolStripButtonPreview, Me.ToolStripButtonPrintPhotoLabel, Me.ToolStripButtonDeletePhoto})
        Me.ToolStrip7.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip7.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip7.Name = "ToolStrip7"
        Me.ToolStrip7.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStrip7.Size = New System.Drawing.Size(23, 97)
        Me.ToolStrip7.TabIndex = 282
        Me.ToolStrip7.Text = "ToolStrip7"
        '
        'ToolStripButtonCapturePhoto
        '
        Me.ToolStripButtonCapturePhoto.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButtonCapturePhoto.Enabled = False
        Me.ToolStripButtonCapturePhoto.Image = CType(resources.GetObject("ToolStripButtonCapturePhoto.Image"), System.Drawing.Image)
        Me.ToolStripButtonCapturePhoto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButtonCapturePhoto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonCapturePhoto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCapturePhoto.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripButtonCapturePhoto.Name = "ToolStripButtonCapturePhoto"
        Me.ToolStripButtonCapturePhoto.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripButtonCapturePhoto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButtonCapturePhoto.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButtonCapturePhoto.ToolTipText = "Capture Photo"
        '
        'ToolStripButtonPreview
        '
        Me.ToolStripButtonPreview.Enabled = False
        Me.ToolStripButtonPreview.Image = CType(resources.GetObject("ToolStripButtonPreview.Image"), System.Drawing.Image)
        Me.ToolStripButtonPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButtonPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonPreview.Margin = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.ToolStripButtonPreview.Name = "ToolStripButtonPreview"
        Me.ToolStripButtonPreview.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripButtonPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButtonPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolStripButtonPreview.ToolTipText = "Show Patient's Photo"
        '
        'ToolStripButtonPrintPhotoLabel
        '
        Me.ToolStripButtonPrintPhotoLabel.Enabled = False
        Me.ToolStripButtonPrintPhotoLabel.Image = CType(resources.GetObject("ToolStripButtonPrintPhotoLabel.Image"), System.Drawing.Image)
        Me.ToolStripButtonPrintPhotoLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButtonPrintPhotoLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonPrintPhotoLabel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonPrintPhotoLabel.Margin = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.ToolStripButtonPrintPhotoLabel.Name = "ToolStripButtonPrintPhotoLabel"
        Me.ToolStripButtonPrintPhotoLabel.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripButtonPrintPhotoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButtonPrintPhotoLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.ToolStripButtonPrintPhotoLabel.ToolTipText = "Print Patient's Photo Label"
        '
        'ToolStripButtonDeletePhoto
        '
        Me.ToolStripButtonDeletePhoto.Enabled = False
        Me.ToolStripButtonDeletePhoto.Image = CType(resources.GetObject("ToolStripButtonDeletePhoto.Image"), System.Drawing.Image)
        Me.ToolStripButtonDeletePhoto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButtonDeletePhoto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonDeletePhoto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDeletePhoto.Margin = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.ToolStripButtonDeletePhoto.Name = "ToolStripButtonDeletePhoto"
        Me.ToolStripButtonDeletePhoto.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripButtonDeletePhoto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButtonDeletePhoto.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.ToolStripButtonDeletePhoto.ToolTipText = "Delete Patient's Photo"
        '
        'cboSuffix
        '
        Me.cboSuffix.FormattingEnabled = True
        Me.cboSuffix.Location = New System.Drawing.Point(403, 96)
        Me.cboSuffix.Name = "cboSuffix"
        Me.cboSuffix.Size = New System.Drawing.Size(56, 21)
        Me.cboSuffix.TabIndex = 10
        '
        'CheckBoxNoMoreAppointmentsInd
        '
        Me.CheckBoxNoMoreAppointmentsInd.AutoSize = True
        Me.CheckBoxNoMoreAppointmentsInd.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxNoMoreAppointmentsInd.Enabled = False
        Me.CheckBoxNoMoreAppointmentsInd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxNoMoreAppointmentsInd.Location = New System.Drawing.Point(410, 10)
        Me.CheckBoxNoMoreAppointmentsInd.Name = "CheckBoxNoMoreAppointmentsInd"
        Me.CheckBoxNoMoreAppointmentsInd.Size = New System.Drawing.Size(12, 11)
        Me.CheckBoxNoMoreAppointmentsInd.TabIndex = 22
        Me.CheckBoxNoMoreAppointmentsInd.UseVisualStyleBackColor = False
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.Black
        Me.Label47.Location = New System.Drawing.Point(635, 45)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(78, 13)
        Me.Label47.TabIndex = 280
        Me.Label47.Text = "Patient's Photo"
        '
        'picPhoto
        '
        Me.picPhoto.BackColor = System.Drawing.Color.WhiteSmoke
        Me.picPhoto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picPhoto.Location = New System.Drawing.Point(497, 61)
        Me.picPhoto.Name = "picPhoto"
        Me.picPhoto.Size = New System.Drawing.Size(215, 161)
        Me.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPhoto.TabIndex = 276
        Me.picPhoto.TabStop = False
        '
        'txtCommentsNew
        '
        Me.txtCommentsNew.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCommentsNew.BackColor = System.Drawing.SystemColors.Window
        Me.txtCommentsNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommentsNew.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconAlignment(Me.txtCommentsNew, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtCommentsNew.Location = New System.Drawing.Point(472, 317)
        Me.txtCommentsNew.MaxLength = 2000
        Me.txtCommentsNew.Multiline = True
        Me.txtCommentsNew.Name = "txtCommentsNew"
        Me.txtCommentsNew.ReadOnly = True
        Me.txtCommentsNew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCommentsNew.Size = New System.Drawing.Size(286, 69)
        Me.txtCommentsNew.TabIndex = 30
        '
        'cboInjury
        '
        Me.cboInjury.FormattingEnabled = True
        Me.ErrorProvider1.SetIconPadding(Me.cboInjury, -18)
        Me.cboInjury.Location = New System.Drawing.Point(312, 59)
        Me.cboInjury.Name = "cboInjury"
        Me.cboInjury.Size = New System.Drawing.Size(147, 21)
        Me.cboInjury.TabIndex = 6
        '
        'LabelIME
        '
        Me.LabelIME.AutoSize = True
        Me.LabelIME.BackColor = System.Drawing.Color.Transparent
        Me.LabelIME.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelIME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelIME.Location = New System.Drawing.Point(425, 155)
        Me.LabelIME.Name = "LabelIME"
        Me.LabelIME.Size = New System.Drawing.Size(0, 13)
        Me.LabelIME.TabIndex = 273
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(276, 157)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(156, 13)
        Me.Label17.TabIndex = 269
        Me.Label17.Text = "Appartment # / Suite # / Unit #"
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.BackColor = System.Drawing.Color.Transparent
        Me.Label105.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label105.ForeColor = System.Drawing.Color.Black
        Me.Label105.Location = New System.Drawing.Point(312, 46)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(91, 13)
        Me.Label105.TabIndex = 268
        Me.Label105.Text = "Injury / Symptoms"
        '
        'txtPlaceOfAccident
        '
        Me.txtPlaceOfAccident.AccessibleDescription = ""
        Me.txtPlaceOfAccident.AccessibleName = "1"
        Me.txtPlaceOfAccident.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPlaceOfAccident.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPlaceOfAccident.BackColor = System.Drawing.SystemColors.Window
        Me.txtPlaceOfAccident.Enabled = False
        Me.txtPlaceOfAccident.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlaceOfAccident.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPlaceOfAccident, -18)
        Me.txtPlaceOfAccident.Location = New System.Drawing.Point(95, 60)
        Me.txtPlaceOfAccident.MaxLength = 255
        Me.txtPlaceOfAccident.Name = "txtPlaceOfAccident"
        Me.txtPlaceOfAccident.Size = New System.Drawing.Size(211, 20)
        Me.txtPlaceOfAccident.TabIndex = 5
        '
        'txtTOA
        '
        Me.txtTOA.AccessibleDescription = "1"
        Me.txtTOA.AccessibleName = "1"
        Me.txtTOA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTOA.ContextMenuStrip = Me.ContextMenuStripTime
        Me.txtTOA.Enabled = False
        Me.txtTOA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTOA.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtTOA, -18)
        Me.txtTOA.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtTOA.Location = New System.Drawing.Point(250, 23)
        Me.txtTOA.Mask = "00:00"
        Me.txtTOA.Name = "txtTOA"
        Me.txtTOA.Size = New System.Drawing.Size(55, 20)
        Me.txtTOA.TabIndex = 2
        Me.txtTOA.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtTOA.ValidatingType = GetType(Date)
        '
        'ContextMenuStripTime
        '
        Me.ContextMenuStripTime.BackColor = System.Drawing.Color.White
        Me.ContextMenuStripTime.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator14, Me.SetTimeToolStripMenuItem, Me.ToolStripSeparator13, Me.SetCurrentTimeToolStripMenuItem, Me.ToolStripSeparator17, Me.CancelToolStripMenuItem1})
        Me.ContextMenuStripTime.Name = "ContextMenuStrip1"
        Me.ContextMenuStripTime.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStripTime.ShowImageMargin = False
        Me.ContextMenuStripTime.ShowItemToolTips = False
        Me.ContextMenuStripTime.Size = New System.Drawing.Size(152, 86)
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(148, 6)
        '
        'SetTimeToolStripMenuItem
        '
        Me.SetTimeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SetTimeToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SetTimeToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.SetTimeToolStripMenuItem.Name = "SetTimeToolStripMenuItem"
        Me.SetTimeToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0)
        Me.SetTimeToolStripMenuItem.Size = New System.Drawing.Size(151, 20)
        Me.SetTimeToolStripMenuItem.Text = "Set Selected Time"
        Me.SetTimeToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(148, 6)
        '
        'SetCurrentTimeToolStripMenuItem
        '
        Me.SetCurrentTimeToolStripMenuItem.Name = "SetCurrentTimeToolStripMenuItem"
        Me.SetCurrentTimeToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.SetCurrentTimeToolStripMenuItem.Text = "Set Current Time"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(148, 6)
        '
        'CancelToolStripMenuItem1
        '
        Me.CancelToolStripMenuItem1.Name = "CancelToolStripMenuItem1"
        Me.CancelToolStripMenuItem1.Size = New System.Drawing.Size(151, 22)
        Me.CancelToolStripMenuItem1.Text = "Cancel"
        '
        'txtEmergencyInfo
        '
        Me.txtEmergencyInfo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtEmergencyInfo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtEmergencyInfo.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmergencyInfo.Enabled = False
        Me.txtEmergencyInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmergencyInfo.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtEmergencyInfo, -18)
        Me.txtEmergencyInfo.Location = New System.Drawing.Point(208, 351)
        Me.txtEmergencyInfo.MaxLength = 500
        Me.txtEmergencyInfo.Name = "txtEmergencyInfo"
        Me.txtEmergencyInfo.Size = New System.Drawing.Size(254, 20)
        Me.txtEmergencyInfo.TabIndex = 32
        '
        'ComboBoxStateOfAccident
        '
        Me.ComboBoxStateOfAccident.AccessibleDescription = "1"
        Me.ComboBoxStateOfAccident.AccessibleName = "1"
        Me.ComboBoxStateOfAccident.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxStateOfAccident.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxStateOfAccident.Enabled = False
        Me.ComboBoxStateOfAccident.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxStateOfAccident.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxStateOfAccident.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxStateOfAccident.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxStateOfAccident, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxStateOfAccident, -18)
        Me.ComboBoxStateOfAccident.Location = New System.Drawing.Point(21, 60)
        Me.ComboBoxStateOfAccident.Name = "ComboBoxStateOfAccident"
        Me.ComboBoxStateOfAccident.Size = New System.Drawing.Size(68, 21)
        Me.ComboBoxStateOfAccident.TabIndex = 4
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.BackColor = System.Drawing.Color.Transparent
        Me.Label94.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.ForeColor = System.Drawing.Color.Black
        Me.Label94.Location = New System.Drawing.Point(20, 46)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(166, 13)
        Me.Label94.TabIndex = 260
        Me.Label94.Text = "Accident State  Accident Address"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(159, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(127, 13)
        Me.Label21.TabIndex = 122
        Me.Label21.Text = "Accident Date    /    Time"
        '
        'txtDOA
        '
        Me.txtDOA.AccessibleDescription = "1"
        Me.txtDOA.AccessibleName = "1"
        Me.txtDOA.BackColor = System.Drawing.SystemColors.Window
        Me.txtDOA.ContextMenuStrip = Me.ContextMenuPopUpCalendar
        Me.txtDOA.Enabled = False
        Me.txtDOA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDOA.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtDOA, -18)
        Me.txtDOA.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtDOA.Location = New System.Drawing.Point(159, 23)
        Me.txtDOA.Mask = "00/00/0000"
        Me.txtDOA.Name = "txtDOA"
        Me.txtDOA.Size = New System.Drawing.Size(84, 20)
        Me.txtDOA.TabIndex = 1
        Me.txtDOA.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtDOA.ValidatingType = GetType(Date)
        '
        'ContextMenuPopUpCalendar
        '
        Me.ContextMenuPopUpCalendar.BackColor = System.Drawing.Color.White
        Me.ContextMenuPopUpCalendar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator15, Me.CancelToolStripMenuItem})
        Me.ContextMenuPopUpCalendar.Name = "ContextMenuStrip1"
        Me.ContextMenuPopUpCalendar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuPopUpCalendar.ShowImageMargin = False
        Me.ContextMenuPopUpCalendar.ShowItemToolTips = False
        Me.ContextMenuPopUpCalendar.Size = New System.Drawing.Size(86, 32)
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(82, 6)
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(85, 22)
        Me.CancelToolStripMenuItem.Text = "Cancel"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(312, 8)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(64, 13)
        Me.Label36.TabIndex = 254
        Me.Label36.Text = "Case Status"
        '
        'ComboBoxCaseStatusID
        '
        Me.ComboBoxCaseStatusID.AccessibleDescription = "2"
        Me.ComboBoxCaseStatusID.AccessibleName = "2"
        Me.ComboBoxCaseStatusID.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxCaseStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCaseStatusID.Enabled = False
        Me.ComboBoxCaseStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxCaseStatusID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxCaseStatusID.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxCaseStatusID.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxCaseStatusID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxCaseStatusID, -18)
        Me.ComboBoxCaseStatusID.Location = New System.Drawing.Point(314, 23)
        Me.ComboBoxCaseStatusID.Name = "ComboBoxCaseStatusID"
        Me.ComboBoxCaseStatusID.Size = New System.Drawing.Size(83, 21)
        Me.ComboBoxCaseStatusID.TabIndex = 3
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Black
        Me.Label49.Location = New System.Drawing.Point(21, 8)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(58, 13)
        Me.Label49.TabIndex = 252
        Me.Label49.Text = "Case Type"
        '
        'ComboBoxCaseTypeID
        '
        Me.ComboBoxCaseTypeID.AccessibleDescription = "2"
        Me.ComboBoxCaseTypeID.AccessibleName = "2"
        Me.ComboBoxCaseTypeID.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxCaseTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCaseTypeID.Enabled = False
        Me.ComboBoxCaseTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxCaseTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxCaseTypeID.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxCaseTypeID.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxCaseTypeID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxCaseTypeID, -18)
        Me.ComboBoxCaseTypeID.Location = New System.Drawing.Point(21, 23)
        Me.ComboBoxCaseTypeID.Name = "ComboBoxCaseTypeID"
        Me.ComboBoxCaseTypeID.Size = New System.Drawing.Size(132, 21)
        Me.ComboBoxCaseTypeID.TabIndex = 0
        '
        'txtOccupation
        '
        Me.txtOccupation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtOccupation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtOccupation.BackColor = System.Drawing.SystemColors.Window
        Me.txtOccupation.Enabled = False
        Me.txtOccupation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOccupation.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtOccupation, -18)
        Me.txtOccupation.Location = New System.Drawing.Point(22, 351)
        Me.txtOccupation.MaxLength = 50
        Me.txtOccupation.Name = "txtOccupation"
        Me.txtOccupation.Size = New System.Drawing.Size(180, 20)
        Me.txtOccupation.TabIndex = 31
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.BackColor = System.Drawing.Color.Transparent
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.Black
        Me.Label82.Location = New System.Drawing.Point(22, 337)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(98, 13)
        Me.Label82.TabIndex = 250
        Me.Label82.Text = "Patient Occupation"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(633, 8)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(64, 13)
        Me.Label33.TabIndex = 247
        Me.Label33.Text = "Date Added"
        '
        'txtInsertedDT
        '
        Me.txtInsertedDT.BackColor = System.Drawing.SystemColors.Control
        Me.txtInsertedDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInsertedDT.ForeColor = System.Drawing.Color.Black
        Me.txtInsertedDT.Location = New System.Drawing.Point(636, 23)
        Me.txtInsertedDT.Name = "txtInsertedDT"
        Me.txtInsertedDT.ReadOnly = True
        Me.txtInsertedDT.Size = New System.Drawing.Size(79, 20)
        Me.txtInsertedDT.TabIndex = 13
        Me.txtInsertedDT.TabStop = False
        Me.txtInsertedDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.BackColor = System.Drawing.Color.Transparent
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.Black
        Me.Label81.Location = New System.Drawing.Point(208, 337)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(100, 13)
        Me.Label81.TabIndex = 241
        Me.Label81.Text = "Emergency Contact"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(21, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "First Name"
        '
        'ComboBoxState
        '
        Me.ComboBoxState.AccessibleDescription = "1"
        Me.ComboBoxState.AccessibleName = "1"
        Me.ComboBoxState.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxState.Enabled = False
        Me.ComboBoxState.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxState.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxState.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxState, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxState, -18)
        Me.ComboBoxState.Location = New System.Drawing.Point(279, 206)
        Me.ComboBoxState.Name = "ComboBoxState"
        Me.ComboBoxState.Size = New System.Drawing.Size(75, 21)
        Me.ComboBoxState.TabIndex = 17
        '
        'txtCaseStatusDT
        '
        Me.txtCaseStatusDT.BackColor = System.Drawing.SystemColors.Control
        Me.txtCaseStatusDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCaseStatusDT.ForeColor = System.Drawing.Color.Black
        Me.txtCaseStatusDT.Location = New System.Drawing.Point(556, 23)
        Me.txtCaseStatusDT.Name = "txtCaseStatusDT"
        Me.txtCaseStatusDT.ReadOnly = True
        Me.txtCaseStatusDT.Size = New System.Drawing.Size(74, 20)
        Me.txtCaseStatusDT.TabIndex = 3
        Me.txtCaseStatusDT.TabStop = False
        Me.txtCaseStatusDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEmployerName
        '
        Me.txtEmployerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtEmployerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtEmployerName.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmployerName.Enabled = False
        Me.txtEmployerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployerName.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtEmployerName, -18)
        Me.txtEmployerName.Location = New System.Drawing.Point(208, 279)
        Me.txtEmployerName.MaxLength = 50
        Me.txtEmployerName.Name = "txtEmployerName"
        Me.txtEmployerName.Size = New System.Drawing.Size(165, 20)
        Me.txtEmployerName.TabIndex = 25
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(376, 265)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(84, 13)
        Me.Label26.TabIndex = 173
        Me.Label26.Text = "Employer Phone"
        '
        'txtCity
        '
        Me.txtCity.AccessibleDescription = "1"
        Me.txtCity.AccessibleName = "1"
        Me.txtCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCity.BackColor = System.Drawing.SystemColors.Window
        Me.txtCity.Enabled = False
        Me.txtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtCity, -18)
        Me.txtCity.Location = New System.Drawing.Point(21, 207)
        Me.txtCity.MaxLength = 50
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(253, 20)
        Me.txtCity.TabIndex = 16
        '
        'LabelDOB
        '
        Me.LabelDOB.AutoSize = True
        Me.LabelDOB.BackColor = System.Drawing.Color.Transparent
        Me.LabelDOB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDOB.ForeColor = System.Drawing.Color.Black
        Me.LabelDOB.Location = New System.Drawing.Point(21, 119)
        Me.LabelDOB.Name = "LabelDOB"
        Me.LabelDOB.Size = New System.Drawing.Size(30, 13)
        Me.LabelDOB.TabIndex = 120
        Me.LabelDOB.Text = "DOB"
        '
        'ComboBoxEmploymentStatusID
        '
        Me.ComboBoxEmploymentStatusID.AccessibleDescription = ""
        Me.ComboBoxEmploymentStatusID.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxEmploymentStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEmploymentStatusID.Enabled = False
        Me.ComboBoxEmploymentStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxEmploymentStatusID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxEmploymentStatusID.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEmploymentStatusID.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxEmploymentStatusID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxEmploymentStatusID, -18)
        Me.ComboBoxEmploymentStatusID.Location = New System.Drawing.Point(21, 279)
        Me.ComboBoxEmploymentStatusID.Name = "ComboBoxEmploymentStatusID"
        Me.ComboBoxEmploymentStatusID.Size = New System.Drawing.Size(181, 21)
        Me.ComboBoxEmploymentStatusID.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(400, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Suffix"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.BackColor = System.Drawing.Color.Transparent
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.ForeColor = System.Drawing.Color.Black
        Me.Label64.Location = New System.Drawing.Point(553, 8)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(55, 13)
        Me.Label64.TabIndex = 239
        Me.Label64.Text = "Status DT"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(205, 265)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(156, 13)
        Me.Label20.TabIndex = 169
        Me.Label20.Text = "Employer Name / School Name"
        '
        'txtDOB
        '
        Me.txtDOB.AccessibleDescription = "1"
        Me.txtDOB.AccessibleName = "1"
        Me.txtDOB.BackColor = System.Drawing.SystemColors.Window
        Me.txtDOB.ContextMenuStrip = Me.ContextMenuPopUpCalendar
        Me.txtDOB.Enabled = False
        Me.txtDOB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDOB.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtDOB, -18)
        Me.txtDOB.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtDOB.Location = New System.Drawing.Point(21, 133)
        Me.txtDOB.Mask = "00/00/0000"
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.Size = New System.Drawing.Size(150, 20)
        Me.txtDOB.TabIndex = 10
        Me.txtDOB.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtDOB.ValidatingType = GetType(Date)
        '
        'txtZip
        '
        Me.txtZip.AccessibleDescription = "1"
        Me.txtZip.AccessibleName = "1"
        Me.txtZip.BackColor = System.Drawing.SystemColors.Window
        Me.txtZip.Enabled = False
        Me.txtZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZip.ForeColor = System.Drawing.Color.Black
        Me.txtZip.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtZip, -18)
        Me.txtZip.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtZip.Location = New System.Drawing.Point(360, 207)
        Me.txtZip.Mask = "00000"
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(73, 20)
        Me.txtZip.TabIndex = 18
        Me.txtZip.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmail.Enabled = False
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtEmail, -18)
        Me.txtEmail.Location = New System.Drawing.Point(279, 243)
        Me.txtEmail.MaxLength = 255
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(180, 20)
        Me.txtEmail.TabIndex = 23
        '
        'ComboBoxSex
        '
        Me.ComboBoxSex.AccessibleDescription = "1"
        Me.ComboBoxSex.AccessibleName = "1"
        Me.ComboBoxSex.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSex.Enabled = False
        Me.ComboBoxSex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxSex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxSex.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxSex.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxSex, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxSex, -18)
        Me.ComboBoxSex.Items.AddRange(New Object() {"M", "F"})
        Me.ComboBoxSex.Location = New System.Drawing.Point(180, 133)
        Me.ComboBoxSex.Name = "ComboBoxSex"
        Me.ComboBoxSex.Size = New System.Drawing.Size(63, 21)
        Me.ComboBoxSex.TabIndex = 11
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(21, 265)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(97, 13)
        Me.Label19.TabIndex = 167
        Me.Label19.Text = "Employment Status"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(248, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Last Name"
        '
        'txtEmployerAddress
        '
        Me.txtEmployerAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtEmployerAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtEmployerAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmployerAddress.Enabled = False
        Me.txtEmployerAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployerAddress.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtEmployerAddress, -18)
        Me.txtEmployerAddress.Location = New System.Drawing.Point(23, 316)
        Me.txtEmployerAddress.MaxLength = 50
        Me.txtEmployerAddress.Name = "txtEmployerAddress"
        Me.txtEmployerAddress.Size = New System.Drawing.Size(179, 20)
        Me.txtEmployerAddress.TabIndex = 27
        '
        'lblNoMoreAppointmentsInd
        '
        Me.lblNoMoreAppointmentsInd.BackColor = System.Drawing.Color.Transparent
        Me.lblNoMoreAppointmentsInd.Location = New System.Drawing.Point(424, 0)
        Me.lblNoMoreAppointmentsInd.Name = "lblNoMoreAppointmentsInd"
        Me.lblNoMoreAppointmentsInd.Size = New System.Drawing.Size(121, 31)
        Me.lblNoMoreAppointmentsInd.TabIndex = 2
        Me.lblNoMoreAppointmentsInd.Text = "No More Appointments"
        Me.lblNoMoreAppointmentsInd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(177, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 13)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "Sex"
        '
        'txtAddress2
        '
        Me.txtAddress2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtAddress2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtAddress2.BackColor = System.Drawing.SystemColors.Window
        Me.txtAddress2.Enabled = False
        Me.txtAddress2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress2.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtAddress2, -18)
        Me.txtAddress2.Location = New System.Drawing.Point(279, 171)
        Me.txtAddress2.MaxLength = 50
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(180, 20)
        Me.txtAddress2.TabIndex = 15
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconAlignment(Me.txtComments, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtComments.Location = New System.Drawing.Point(471, 242)
        Me.txtComments.MaxLength = 2000
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ReadOnly = True
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(286, 69)
        Me.txtComments.TabIndex = 36
        '
        'txtLName
        '
        Me.txtLName.AccessibleDescription = "2"
        Me.txtLName.AccessibleName = "2"
        Me.txtLName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtLName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtLName.BackColor = System.Drawing.SystemColors.Window
        Me.txtLName.Enabled = False
        Me.txtLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLName.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtLName, -18)
        Me.txtLName.Location = New System.Drawing.Point(250, 97)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(147, 20)
        Me.txtLName.TabIndex = 9
        '
        'txtEmployerPhone
        '
        Me.txtEmployerPhone.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmployerPhone.Enabled = False
        Me.txtEmployerPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployerPhone.ForeColor = System.Drawing.Color.Black
        Me.txtEmployerPhone.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtEmployerPhone, -18)
        Me.txtEmployerPhone.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtEmployerPhone.Location = New System.Drawing.Point(379, 279)
        Me.txtEmployerPhone.Mask = "(999) 000-0000"
        Me.txtEmployerPhone.Name = "txtEmployerPhone"
        Me.txtEmployerPhone.Size = New System.Drawing.Size(81, 20)
        Me.txtEmployerPhone.TabIndex = 26
        Me.txtEmployerPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txtSSN
        '
        Me.txtSSN.AccessibleName = "1"
        Me.txtSSN.BackColor = System.Drawing.SystemColors.Window
        Me.txtSSN.Enabled = False
        Me.txtSSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSSN.ForeColor = System.Drawing.Color.Black
        Me.txtSSN.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtSSN, -18)
        Me.txtSSN.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtSSN.Location = New System.Drawing.Point(249, 133)
        Me.txtSSN.Mask = "000-00-0000"
        Me.txtSSN.Name = "txtSSN"
        Me.txtSSN.Size = New System.Drawing.Size(105, 20)
        Me.txtSSN.TabIndex = 12
        Me.txtSSN.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txtAddress1
        '
        Me.txtAddress1.AccessibleDescription = "1"
        Me.txtAddress1.AccessibleName = "1"
        Me.txtAddress1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtAddress1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtAddress1.BackColor = System.Drawing.SystemColors.Window
        Me.txtAddress1.Enabled = False
        Me.txtAddress1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtAddress1, -18)
        Me.txtAddress1.Location = New System.Drawing.Point(21, 171)
        Me.txtAddress1.MaxLength = 50
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(252, 20)
        Me.txtAddress1.TabIndex = 14
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.BackColor = System.Drawing.Color.Transparent
        Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.Black
        Me.Label79.Location = New System.Drawing.Point(469, 228)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(66, 13)
        Me.Label79.TabIndex = 225
        Me.Label79.Text = "Quick Notes"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(177, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "MI"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(22, 303)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(97, 13)
        Me.Label25.TabIndex = 171
        Me.Label25.Text = "Employeer Address"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(248, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 124
        Me.Label8.Text = "SSN"
        '
        'txtPhone2
        '
        Me.txtPhone2.BackColor = System.Drawing.SystemColors.Window
        Me.txtPhone2.Enabled = False
        Me.txtPhone2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone2.ForeColor = System.Drawing.Color.Black
        Me.txtPhone2.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtPhone2, -18)
        Me.txtPhone2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtPhone2.Location = New System.Drawing.Point(194, 243)
        Me.txtPhone2.Mask = "(999) 000-0000"
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.Size = New System.Drawing.Size(79, 20)
        Me.txtPhone2.TabIndex = 22
        Me.txtPhone2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(21, 155)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(158, 13)
        Me.Label18.TabIndex = 138
        Me.Label18.Text = "Building Number + Street Name "
        '
        'txtMI
        '
        Me.txtMI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMI.Enabled = False
        Me.txtMI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMI.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtMI, -18)
        Me.txtMI.Location = New System.Drawing.Point(180, 97)
        Me.txtMI.MaxLength = 5
        Me.txtMI.Name = "txtMI"
        Me.txtMI.Size = New System.Drawing.Size(63, 20)
        Me.txtMI.TabIndex = 8
        '
        'txtCellPhone
        '
        Me.txtCellPhone.BackColor = System.Drawing.SystemColors.Window
        Me.txtCellPhone.Enabled = False
        Me.txtCellPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCellPhone.ForeColor = System.Drawing.Color.Black
        Me.txtCellPhone.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtCellPhone, -18)
        Me.txtCellPhone.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtCellPhone.Location = New System.Drawing.Point(21, 242)
        Me.txtCellPhone.Mask = "(999) 000-0000"
        Me.txtCellPhone.Name = "txtCellPhone"
        Me.txtCellPhone.Size = New System.Drawing.Size(80, 20)
        Me.txtCellPhone.TabIndex = 20
        Me.txtCellPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(357, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 148
        Me.Label9.Text = "Marital Status"
        '
        'ComboBoxMaritalStatusID
        '
        Me.ComboBoxMaritalStatusID.AccessibleDescription = ""
        Me.ComboBoxMaritalStatusID.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxMaritalStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxMaritalStatusID.Enabled = False
        Me.ComboBoxMaritalStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxMaritalStatusID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxMaritalStatusID.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxMaritalStatusID.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxMaritalStatusID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxMaritalStatusID, -18)
        Me.ComboBoxMaritalStatusID.Location = New System.Drawing.Point(360, 133)
        Me.ComboBoxMaritalStatusID.Name = "ComboBoxMaritalStatusID"
        Me.ComboBoxMaritalStatusID.Size = New System.Drawing.Size(99, 21)
        Me.ComboBoxMaritalStatusID.TabIndex = 13
        '
        'txtPhone1
        '
        Me.txtPhone1.AccessibleDescription = "1"
        Me.txtPhone1.AccessibleName = "1"
        Me.txtPhone1.BackColor = System.Drawing.SystemColors.Window
        Me.txtPhone1.Enabled = False
        Me.txtPhone1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone1.ForeColor = System.Drawing.Color.Black
        Me.txtPhone1.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtPhone1, -18)
        Me.txtPhone1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtPhone1.Location = New System.Drawing.Point(107, 242)
        Me.txtPhone1.Mask = "(999) 000-0000"
        Me.txtPhone1.Name = "txtPhone1"
        Me.txtPhone1.Size = New System.Drawing.Size(81, 20)
        Me.txtPhone1.TabIndex = 21
        Me.txtPhone1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txtFName
        '
        Me.txtFName.AccessibleDescription = "2"
        Me.txtFName.AccessibleName = "2"
        Me.txtFName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtFName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtFName.BackColor = System.Drawing.SystemColors.Window
        Me.txtFName.Enabled = False
        Me.txtFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFName.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtFName, -18)
        Me.txtFName.Location = New System.Drawing.Point(21, 97)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(150, 20)
        Me.txtFName.TabIndex = 7
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(495, 59)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(219, 166)
        Me.TextBox1.TabIndex = 284
        '
        'LabelPreCertification
        '
        Me.LabelPreCertification.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelPreCertification.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelPreCertification.ForeColor = System.Drawing.Color.Red
        Me.LabelPreCertification.Image = CType(resources.GetObject("LabelPreCertification.Image"), System.Drawing.Image)
        Me.LabelPreCertification.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelPreCertification.Location = New System.Drawing.Point(19, 374)
        Me.LabelPreCertification.Name = "LabelPreCertification"
        Me.LabelPreCertification.Size = New System.Drawing.Size(164, 17)
        Me.LabelPreCertification.TabIndex = 291
        Me.LabelPreCertification.Text = "Pre-Certification Required!"
        Me.LabelPreCertification.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LabelPreCertification.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(276, 230)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 146
        Me.Label14.Text = "Email"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(21, 230)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 145
        Me.Label13.Text = "Cell Phone"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(107, 230)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 143
        Me.Label11.Text = "Phone 1"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(191, 230)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 144
        Me.Label12.Text = "Phone 2"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(20, 194)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(24, 13)
        Me.Label16.TabIndex = 140
        Me.Label16.Text = "City"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(357, 194)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 13)
        Me.Label15.TabIndex = 141
        Me.Label15.Text = "Zip Code"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(276, 194)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 142
        Me.Label10.Text = "State"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.Controls.Add(Me.BtnAddPatientAttorney)
        Me.TabPage2.Controls.Add(Me.PanelWC)
        Me.TabPage2.Controls.Add(Me.PictureBox1)
        Me.TabPage2.Controls.Add(Me.TabControl3)
        Me.TabPage2.Controls.Add(Me.txtNF2)
        Me.TabPage2.Controls.Add(Me.chkNF2)
        Me.TabPage2.Controls.Add(Me.ComboBoxReferringDoctor)
        Me.TabPage2.Controls.Add(Me.Label102)
        Me.TabPage2.Controls.Add(Me.Panel4)
        Me.TabPage2.Controls.Add(Me.Label106)
        Me.TabPage2.Controls.Add(Me.txtVehicleOwner)
        Me.TabPage2.Controls.Add(Me.PictureBoxRefCompany)
        Me.TabPage2.Controls.Add(Me.ComboBoxTransportationCompanyID)
        Me.TabPage2.Controls.Add(Me.PictureBoxRefDoctor)
        Me.TabPage2.Controls.Add(Me.Label35)
        Me.TabPage2.Controls.Add(Me.cboBillingCompany)
        Me.TabPage2.Controls.Add(Me.Label86)
        Me.TabPage2.Controls.Add(Me.ComboBoxReferringCompanyID)
        Me.TabPage2.Controls.Add(Me.ComboBoxPatientTypeID)
        Me.TabPage2.Controls.Add(Me.ComboBoxInjuryID)
        Me.TabPage2.Controls.Add(Me.Label63)
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.Label62)
        Me.TabPage2.Controls.Add(Me.Label37)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.cboPatientAttorney)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(763, 506)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Insurance"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'BtnAddPatientAttorney
        '
        Me.BtnAddPatientAttorney.Enabled = False
        Me.BtnAddPatientAttorney.FlatAppearance.BorderSize = 0
        Me.BtnAddPatientAttorney.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAddPatientAttorney.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddPatientAttorney.Image = CType(resources.GetObject("BtnAddPatientAttorney.Image"), System.Drawing.Image)
        Me.BtnAddPatientAttorney.Location = New System.Drawing.Point(366, 103)
        Me.BtnAddPatientAttorney.Name = "BtnAddPatientAttorney"
        Me.BtnAddPatientAttorney.Size = New System.Drawing.Size(22, 21)
        Me.BtnAddPatientAttorney.TabIndex = 342
        Me.ToolTip1.SetToolTip(Me.BtnAddPatientAttorney, "Add Lien Attorney")
        Me.BtnAddPatientAttorney.UseVisualStyleBackColor = True
        '
        'PanelWC
        '
        Me.PanelWC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelWC.Controls.Add(Me.WCIcon)
        Me.PanelWC.Controls.Add(Me.txtWCInsuranceCarrierAddressZip)
        Me.PanelWC.Controls.Add(Me.Label103)
        Me.PanelWC.Controls.Add(Me.Label114)
        Me.PanelWC.Controls.Add(Me.txtWCCaseNumber)
        Me.PanelWC.Controls.Add(Me.cboWCInsuranceCarrierAddressState)
        Me.PanelWC.Controls.Add(Me.txtWCCarrierCaseNumber)
        Me.PanelWC.Controls.Add(Me.Label113)
        Me.PanelWC.Controls.Add(Me.Label107)
        Me.PanelWC.Controls.Add(Me.Label112)
        Me.PanelWC.Controls.Add(Me.txtWCCarrierCode)
        Me.PanelWC.Controls.Add(Me.txtWCInsuranceCarrierAddressCity)
        Me.PanelWC.Controls.Add(Me.Label109)
        Me.PanelWC.Controls.Add(Me.Label111)
        Me.PanelWC.Controls.Add(Me.txtWCPatientAccountNumber)
        Me.PanelWC.Controls.Add(Me.txtWCInsuranceCarrierAddress)
        Me.PanelWC.Controls.Add(Me.Label110)
        Me.PanelWC.Controls.Add(Me.Label108)
        Me.PanelWC.Controls.Add(Me.txtWCEmployerInsuranceCarrier)
        Me.PanelWC.Location = New System.Drawing.Point(20, 447)
        Me.PanelWC.Name = "PanelWC"
        Me.PanelWC.Size = New System.Drawing.Size(730, 49)
        Me.PanelWC.TabIndex = 259
        '
        'WCIcon
        '
        Me.WCIcon.Image = CType(resources.GetObject("WCIcon.Image"), System.Drawing.Image)
        Me.WCIcon.Location = New System.Drawing.Point(2, 21)
        Me.WCIcon.Name = "WCIcon"
        Me.WCIcon.Size = New System.Drawing.Size(17, 17)
        Me.WCIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.WCIcon.TabIndex = 351
        Me.WCIcon.TabStop = False
        Me.ToolTip1.SetToolTip(Me.WCIcon, "Workers Compensation Information")
        '
        'txtWCInsuranceCarrierAddressZip
        '
        Me.txtWCInsuranceCarrierAddressZip.AccessibleDescription = "1"
        Me.txtWCInsuranceCarrierAddressZip.AccessibleName = "1"
        Me.txtWCInsuranceCarrierAddressZip.BackColor = System.Drawing.SystemColors.Window
        Me.txtWCInsuranceCarrierAddressZip.Enabled = False
        Me.txtWCInsuranceCarrierAddressZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWCInsuranceCarrierAddressZip.ForeColor = System.Drawing.Color.Black
        Me.txtWCInsuranceCarrierAddressZip.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtWCInsuranceCarrierAddressZip, -18)
        Me.txtWCInsuranceCarrierAddressZip.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtWCInsuranceCarrierAddressZip.Location = New System.Drawing.Point(869, 160)
        Me.txtWCInsuranceCarrierAddressZip.Mask = "00000"
        Me.txtWCInsuranceCarrierAddressZip.Name = "txtWCInsuranceCarrierAddressZip"
        Me.txtWCInsuranceCarrierAddressZip.Size = New System.Drawing.Size(70, 20)
        Me.txtWCInsuranceCarrierAddressZip.TabIndex = 8
        Me.txtWCInsuranceCarrierAddressZip.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtWCInsuranceCarrierAddressZip.Visible = False
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.BackColor = System.Drawing.Color.Transparent
        Me.Label103.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label103.ForeColor = System.Drawing.Color.Black
        Me.Label103.Location = New System.Drawing.Point(21, 5)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(99, 13)
        Me.Label103.TabIndex = 334
        Me.Label103.Text = "WCB Case Number"
        '
        'Label114
        '
        Me.Label114.AutoSize = True
        Me.Label114.BackColor = System.Drawing.Color.Transparent
        Me.Label114.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label114.ForeColor = System.Drawing.Color.Black
        Me.Label114.Location = New System.Drawing.Point(866, 144)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(50, 13)
        Me.Label114.TabIndex = 350
        Me.Label114.Text = "Zip Code"
        Me.Label114.Visible = False
        '
        'txtWCCaseNumber
        '
        Me.txtWCCaseNumber.AccessibleDescription = "2"
        Me.txtWCCaseNumber.AccessibleName = "2"
        Me.txtWCCaseNumber.Enabled = False
        Me.txtWCCaseNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWCCaseNumber.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtWCCaseNumber, -18)
        Me.txtWCCaseNumber.Location = New System.Drawing.Point(20, 21)
        Me.txtWCCaseNumber.MaxLength = 50
        Me.txtWCCaseNumber.Name = "txtWCCaseNumber"
        Me.txtWCCaseNumber.Size = New System.Drawing.Size(140, 20)
        Me.txtWCCaseNumber.TabIndex = 0
        '
        'cboWCInsuranceCarrierAddressState
        '
        Me.cboWCInsuranceCarrierAddressState.AccessibleDescription = "1"
        Me.cboWCInsuranceCarrierAddressState.AccessibleName = "1"
        Me.cboWCInsuranceCarrierAddressState.BackColor = System.Drawing.SystemColors.Window
        Me.cboWCInsuranceCarrierAddressState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWCInsuranceCarrierAddressState.Enabled = False
        Me.cboWCInsuranceCarrierAddressState.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboWCInsuranceCarrierAddressState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboWCInsuranceCarrierAddressState.ForeColor = System.Drawing.Color.Black
        Me.cboWCInsuranceCarrierAddressState.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.cboWCInsuranceCarrierAddressState, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.cboWCInsuranceCarrierAddressState, -18)
        Me.cboWCInsuranceCarrierAddressState.Location = New System.Drawing.Point(754, 158)
        Me.cboWCInsuranceCarrierAddressState.Name = "cboWCInsuranceCarrierAddressState"
        Me.cboWCInsuranceCarrierAddressState.Size = New System.Drawing.Size(95, 21)
        Me.cboWCInsuranceCarrierAddressState.TabIndex = 7
        Me.cboWCInsuranceCarrierAddressState.Visible = False
        '
        'txtWCCarrierCaseNumber
        '
        Me.txtWCCarrierCaseNumber.AccessibleDescription = "2"
        Me.txtWCCarrierCaseNumber.AccessibleName = "2"
        Me.txtWCCarrierCaseNumber.Enabled = False
        Me.txtWCCarrierCaseNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWCCarrierCaseNumber.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtWCCarrierCaseNumber, -18)
        Me.txtWCCarrierCaseNumber.Location = New System.Drawing.Point(167, 21)
        Me.txtWCCarrierCaseNumber.MaxLength = 50
        Me.txtWCCarrierCaseNumber.Name = "txtWCCarrierCaseNumber"
        Me.txtWCCarrierCaseNumber.Size = New System.Drawing.Size(205, 20)
        Me.txtWCCarrierCaseNumber.TabIndex = 1
        '
        'Label113
        '
        Me.Label113.AutoSize = True
        Me.Label113.BackColor = System.Drawing.Color.Transparent
        Me.Label113.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label113.ForeColor = System.Drawing.Color.Black
        Me.Label113.Location = New System.Drawing.Point(751, 143)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(32, 13)
        Me.Label113.TabIndex = 348
        Me.Label113.Text = "State"
        Me.Label113.Visible = False
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.BackColor = System.Drawing.Color.Transparent
        Me.Label107.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label107.ForeColor = System.Drawing.Color.Black
        Me.Label107.Location = New System.Drawing.Point(164, 5)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(104, 13)
        Me.Label107.TabIndex = 336
        Me.Label107.Text = "Carrier Case Number"
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.BackColor = System.Drawing.Color.Transparent
        Me.Label112.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label112.ForeColor = System.Drawing.Color.Black
        Me.Label112.Location = New System.Drawing.Point(246, 143)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(107, 13)
        Me.Label112.TabIndex = 346
        Me.Label112.Text = "Insurance Carrier City"
        Me.Label112.Visible = False
        '
        'txtWCCarrierCode
        '
        Me.txtWCCarrierCode.AccessibleDescription = "2"
        Me.txtWCCarrierCode.AccessibleName = "2"
        Me.txtWCCarrierCode.Enabled = False
        Me.txtWCCarrierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWCCarrierCode.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtWCCarrierCode, -18)
        Me.txtWCCarrierCode.Location = New System.Drawing.Point(568, 21)
        Me.txtWCCarrierCode.MaxLength = 50
        Me.txtWCCarrierCode.Name = "txtWCCarrierCode"
        Me.txtWCCarrierCode.Size = New System.Drawing.Size(147, 20)
        Me.txtWCCarrierCode.TabIndex = 4
        '
        'txtWCInsuranceCarrierAddressCity
        '
        Me.txtWCInsuranceCarrierAddressCity.AccessibleDescription = "2"
        Me.txtWCInsuranceCarrierAddressCity.AccessibleName = "2"
        Me.txtWCInsuranceCarrierAddressCity.Enabled = False
        Me.txtWCInsuranceCarrierAddressCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWCInsuranceCarrierAddressCity.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtWCInsuranceCarrierAddressCity, -18)
        Me.txtWCInsuranceCarrierAddressCity.Location = New System.Drawing.Point(246, 159)
        Me.txtWCInsuranceCarrierAddressCity.MaxLength = 50
        Me.txtWCInsuranceCarrierAddressCity.Name = "txtWCInsuranceCarrierAddressCity"
        Me.txtWCInsuranceCarrierAddressCity.Size = New System.Drawing.Size(497, 20)
        Me.txtWCInsuranceCarrierAddressCity.TabIndex = 6
        Me.txtWCInsuranceCarrierAddressCity.Visible = False
        '
        'Label109
        '
        Me.Label109.AutoSize = True
        Me.Label109.BackColor = System.Drawing.Color.Transparent
        Me.Label109.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label109.ForeColor = System.Drawing.Color.Black
        Me.Label109.Location = New System.Drawing.Point(567, 2)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(65, 13)
        Me.Label109.TabIndex = 340
        Me.Label109.Text = "Carrier Code"
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.BackColor = System.Drawing.Color.Transparent
        Me.Label111.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label111.ForeColor = System.Drawing.Color.Black
        Me.Label111.Location = New System.Drawing.Point(246, 104)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(128, 13)
        Me.Label111.TabIndex = 344
        Me.Label111.Text = "Insurance Carrier Address"
        Me.Label111.Visible = False
        '
        'txtWCPatientAccountNumber
        '
        Me.txtWCPatientAccountNumber.AccessibleDescription = "2"
        Me.txtWCPatientAccountNumber.AccessibleName = "2"
        Me.txtWCPatientAccountNumber.Enabled = False
        Me.txtWCPatientAccountNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWCPatientAccountNumber.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtWCPatientAccountNumber, -18)
        Me.txtWCPatientAccountNumber.Location = New System.Drawing.Point(378, 21)
        Me.txtWCPatientAccountNumber.MaxLength = 50
        Me.txtWCPatientAccountNumber.Name = "txtWCPatientAccountNumber"
        Me.txtWCPatientAccountNumber.ReadOnly = True
        Me.txtWCPatientAccountNumber.Size = New System.Drawing.Size(183, 20)
        Me.txtWCPatientAccountNumber.TabIndex = 2
        '
        'txtWCInsuranceCarrierAddress
        '
        Me.txtWCInsuranceCarrierAddress.AccessibleDescription = "2"
        Me.txtWCInsuranceCarrierAddress.AccessibleName = "2"
        Me.txtWCInsuranceCarrierAddress.Enabled = False
        Me.txtWCInsuranceCarrierAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWCInsuranceCarrierAddress.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtWCInsuranceCarrierAddress, -18)
        Me.txtWCInsuranceCarrierAddress.Location = New System.Drawing.Point(246, 120)
        Me.txtWCInsuranceCarrierAddress.MaxLength = 50
        Me.txtWCInsuranceCarrierAddress.Name = "txtWCInsuranceCarrierAddress"
        Me.txtWCInsuranceCarrierAddress.Size = New System.Drawing.Size(689, 20)
        Me.txtWCInsuranceCarrierAddress.TabIndex = 5
        Me.txtWCInsuranceCarrierAddress.Visible = False
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.BackColor = System.Drawing.Color.Transparent
        Me.Label110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label110.ForeColor = System.Drawing.Color.Black
        Me.Label110.Location = New System.Drawing.Point(375, 5)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(123, 13)
        Me.Label110.TabIndex = 342
        Me.Label110.Text = "Patient Account Number"
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.BackColor = System.Drawing.Color.Transparent
        Me.Label108.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label108.ForeColor = System.Drawing.Color.Black
        Me.Label108.Location = New System.Drawing.Point(246, 65)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(133, 13)
        Me.Label108.TabIndex = 338
        Me.Label108.Text = "Employer Insurance Carrier"
        Me.Label108.Visible = False
        '
        'txtWCEmployerInsuranceCarrier
        '
        Me.txtWCEmployerInsuranceCarrier.AccessibleDescription = "2"
        Me.txtWCEmployerInsuranceCarrier.AccessibleName = "2"
        Me.txtWCEmployerInsuranceCarrier.Enabled = False
        Me.txtWCEmployerInsuranceCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWCEmployerInsuranceCarrier.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtWCEmployerInsuranceCarrier, -18)
        Me.txtWCEmployerInsuranceCarrier.Location = New System.Drawing.Point(246, 81)
        Me.txtWCEmployerInsuranceCarrier.MaxLength = 50
        Me.txtWCEmployerInsuranceCarrier.Name = "txtWCEmployerInsuranceCarrier"
        Me.txtWCEmployerInsuranceCarrier.Size = New System.Drawing.Size(497, 20)
        Me.txtWCEmployerInsuranceCarrier.TabIndex = 3
        Me.txtWCEmployerInsuranceCarrier.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(699, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(11, 10)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 336
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "The Initial / Police Report indicator cannot be set manually. It will be set auto" &
        "matically when the Report is scanned.")
        '
        'TabControl3
        '
        Me.TabControl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl3.Controls.Add(Me.TabPage7)
        Me.TabControl3.Controls.Add(Me.TabPage9)
        Me.TabControl3.Location = New System.Drawing.Point(20, 131)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(730, 314)
        Me.TabControl3.TabIndex = 338
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.ComboBoxInsuranceCompanyID)
        Me.TabPage7.Controls.Add(Me.cmdAddInsuranceAddress)
        Me.TabPage7.Controls.Add(Me.CheckBoxInsuranceVerifyed)
        Me.TabPage7.Controls.Add(Me.ButtonShowInsurance)
        Me.TabPage7.Controls.Add(Me.cmdUnlockInsurance)
        Me.TabPage7.Controls.Add(Me.ComboBoxClaimAddress)
        Me.TabPage7.Controls.Add(Me.LabelInsuranceCompany)
        Me.TabPage7.Controls.Add(Me.Label27)
        Me.TabPage7.Controls.Add(Me.PanelInsurance)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(722, 288)
        Me.TabPage7.TabIndex = 0
        Me.TabPage7.Text = "Primary Insurance Company"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'ComboBoxInsuranceCompanyID
        '
        Me.ComboBoxInsuranceCompanyID.AccessibleDescription = "1"
        Me.ComboBoxInsuranceCompanyID.AccessibleName = "1"
        Me.ComboBoxInsuranceCompanyID.BackColor = System.Drawing.Color.White
        Me.ComboBoxInsuranceCompanyID.Enabled = False
        Me.ComboBoxInsuranceCompanyID.FormattingEnabled = True
        Me.ComboBoxInsuranceCompanyID.LimitToList = True
        Me.ComboBoxInsuranceCompanyID.Location = New System.Drawing.Point(20, 24)
        Me.ComboBoxInsuranceCompanyID.MaxNumericValue = 1.7976931348623157E+308R
        Me.ComboBoxInsuranceCompanyID.Name = "ComboBoxInsuranceCompanyID"
        Me.ComboBoxInsuranceCompanyID.NoDecimals = False
        Me.ComboBoxInsuranceCompanyID.NumericOnly = False
        Me.ComboBoxInsuranceCompanyID.ReadOnlyCombo = False
        Me.ComboBoxInsuranceCompanyID.Size = New System.Drawing.Size(666, 21)
        Me.ComboBoxInsuranceCompanyID.TabIndex = 339
        '
        'cmdAddInsuranceAddress
        '
        Me.cmdAddInsuranceAddress.Enabled = False
        Me.cmdAddInsuranceAddress.FlatAppearance.BorderSize = 0
        Me.cmdAddInsuranceAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAddInsuranceAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddInsuranceAddress.Image = CType(resources.GetObject("cmdAddInsuranceAddress.Image"), System.Drawing.Image)
        Me.cmdAddInsuranceAddress.Location = New System.Drawing.Point(689, 63)
        Me.cmdAddInsuranceAddress.Name = "cmdAddInsuranceAddress"
        Me.cmdAddInsuranceAddress.Size = New System.Drawing.Size(22, 21)
        Me.cmdAddInsuranceAddress.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.cmdAddInsuranceAddress, "Add Insurance Claim Address")
        Me.cmdAddInsuranceAddress.UseVisualStyleBackColor = True
        '
        'CheckBoxInsuranceVerifyed
        '
        Me.CheckBoxInsuranceVerifyed.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxInsuranceVerifyed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxInsuranceVerifyed.Location = New System.Drawing.Point(600, 3)
        Me.CheckBoxInsuranceVerifyed.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBoxInsuranceVerifyed.Name = "CheckBoxInsuranceVerifyed"
        Me.CheckBoxInsuranceVerifyed.Size = New System.Drawing.Size(111, 17)
        Me.CheckBoxInsuranceVerifyed.TabIndex = 11
        Me.CheckBoxInsuranceVerifyed.Text = "Insurance Verified"
        Me.CheckBoxInsuranceVerifyed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.CheckBoxInsuranceVerifyed, "Primary Insurance Information Verified")
        Me.CheckBoxInsuranceVerifyed.UseVisualStyleBackColor = False
        '
        'ButtonShowInsurance
        '
        Me.ButtonShowInsurance.Enabled = False
        Me.ButtonShowInsurance.FlatAppearance.BorderSize = 0
        Me.ButtonShowInsurance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonShowInsurance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonShowInsurance.Image = CType(resources.GetObject("ButtonShowInsurance.Image"), System.Drawing.Image)
        Me.ButtonShowInsurance.Location = New System.Drawing.Point(689, 25)
        Me.ButtonShowInsurance.Name = "ButtonShowInsurance"
        Me.ButtonShowInsurance.Size = New System.Drawing.Size(22, 21)
        Me.ButtonShowInsurance.TabIndex = 325
        Me.ToolTip1.SetToolTip(Me.ButtonShowInsurance, "Show Insurance Maintenance")
        Me.ButtonShowInsurance.UseVisualStyleBackColor = True
        '
        'cmdUnlockInsurance
        '
        Me.cmdUnlockInsurance.BackColor = System.Drawing.Color.White
        Me.cmdUnlockInsurance.FlatAppearance.BorderSize = 0
        Me.cmdUnlockInsurance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdUnlockInsurance.Image = CType(resources.GetObject("cmdUnlockInsurance.Image"), System.Drawing.Image)
        Me.cmdUnlockInsurance.Location = New System.Drawing.Point(1, 24)
        Me.cmdUnlockInsurance.Name = "cmdUnlockInsurance"
        Me.cmdUnlockInsurance.Size = New System.Drawing.Size(16, 19)
        Me.cmdUnlockInsurance.TabIndex = 337
        Me.ToolTip1.SetToolTip(Me.cmdUnlockInsurance, "Unlock Insurance Information  Section")
        Me.cmdUnlockInsurance.UseVisualStyleBackColor = False
        Me.cmdUnlockInsurance.Visible = False
        '
        'ComboBoxClaimAddress
        '
        Me.ComboBoxClaimAddress.AccessibleDescription = "1"
        Me.ComboBoxClaimAddress.AccessibleName = "1"
        Me.ComboBoxClaimAddress.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxClaimAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxClaimAddress.DropDownWidth = 650
        Me.ComboBoxClaimAddress.Enabled = False
        Me.ComboBoxClaimAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxClaimAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxClaimAddress.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxClaimAddress.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxClaimAddress, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxClaimAddress, -18)
        Me.ComboBoxClaimAddress.Location = New System.Drawing.Point(19, 65)
        Me.ComboBoxClaimAddress.Name = "ComboBoxClaimAddress"
        Me.ComboBoxClaimAddress.Size = New System.Drawing.Size(667, 21)
        Me.ComboBoxClaimAddress.TabIndex = 15
        '
        'LabelInsuranceCompany
        '
        Me.LabelInsuranceCompany.AutoSize = True
        Me.LabelInsuranceCompany.BackColor = System.Drawing.Color.Transparent
        Me.LabelInsuranceCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInsuranceCompany.ForeColor = System.Drawing.Color.Black
        Me.LabelInsuranceCompany.Location = New System.Drawing.Point(19, 9)
        Me.LabelInsuranceCompany.Name = "LabelInsuranceCompany"
        Me.LabelInsuranceCompany.Size = New System.Drawing.Size(132, 13)
        Me.LabelInsuranceCompany.TabIndex = 213
        Me.LabelInsuranceCompany.Text = "Insurance Company Name"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(19, 49)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(333, 13)
        Me.Label27.TabIndex = 272
        Me.Label27.Text = "Claim Address (if address is not on the list, please inform administrator)"
        '
        'PanelInsurance
        '
        Me.PanelInsurance.BackColor = System.Drawing.Color.Transparent
        Me.PanelInsurance.Controls.Add(Me.txtPolicyNumber)
        Me.PanelInsurance.Controls.Add(Me.Label100)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderOccupation)
        Me.PanelInsurance.Controls.Add(Me.Label28)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderEmployerName)
        Me.PanelInsurance.Controls.Add(Me.Label29)
        Me.PanelInsurance.Controls.Add(Me.Label30)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderEmployerAddress)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderEmployerPhone)
        Me.PanelInsurance.Controls.Add(Me.Label67)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderSSN)
        Me.PanelInsurance.Controls.Add(Me.Label96)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderBirthDate)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderOtherDependents)
        Me.PanelInsurance.Controls.Add(Me.Label6)
        Me.PanelInsurance.Controls.Add(Me.txtAdjusterComments)
        Me.PanelInsurance.Controls.Add(Me.txtGroupNumber)
        Me.PanelInsurance.Controls.Add(Me.txtIDNumber)
        Me.PanelInsurance.Controls.Add(Me.txtAdjusterPhone)
        Me.PanelInsurance.Controls.Add(Me.txtAdjuster)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderPhone)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderZip)
        Me.PanelInsurance.Controls.Add(Me.ComboBoxPolicyHolderState)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderCity)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderAddress)
        Me.PanelInsurance.Controls.Add(Me.ComboBoxRelationToInsuredID)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderLName)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderMI)
        Me.PanelInsurance.Controls.Add(Me.txtPolicyHolderFName)
        Me.PanelInsurance.Controls.Add(Me.txtClaimEffectiveDT)
        Me.PanelInsurance.Controls.Add(Me.txtClaimNumber)
        Me.PanelInsurance.Controls.Add(Me.Label65)
        Me.PanelInsurance.Controls.Add(Me.Label31)
        Me.PanelInsurance.Controls.Add(Me.Label61)
        Me.PanelInsurance.Controls.Add(Me.Label60)
        Me.PanelInsurance.Controls.Add(Me.Label59)
        Me.PanelInsurance.Controls.Add(Me.Label58)
        Me.PanelInsurance.Controls.Add(Me.Label56)
        Me.PanelInsurance.Controls.Add(Me.Label41)
        Me.PanelInsurance.Controls.Add(Me.Label24)
        Me.PanelInsurance.Controls.Add(Me.Label34)
        Me.PanelInsurance.Controls.Add(Me.LabelEffectiveDate)
        Me.PanelInsurance.Controls.Add(Me.Label55)
        Me.PanelInsurance.Controls.Add(Me.Label50)
        Me.PanelInsurance.Controls.Add(Me.Label52)
        Me.PanelInsurance.Controls.Add(Me.Label51)
        Me.PanelInsurance.Controls.Add(Me.Label53)
        Me.PanelInsurance.Controls.Add(Me.Label54)
        Me.PanelInsurance.Location = New System.Drawing.Point(0, 92)
        Me.PanelInsurance.Name = "PanelInsurance"
        Me.PanelInsurance.Size = New System.Drawing.Size(719, 193)
        Me.PanelInsurance.TabIndex = 334
        '
        'txtPolicyNumber
        '
        Me.txtPolicyNumber.AccessibleDescription = "1"
        Me.txtPolicyNumber.AccessibleName = "1"
        Me.txtPolicyNumber.Enabled = False
        Me.txtPolicyNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyNumber.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyNumber, -18)
        Me.txtPolicyNumber.Location = New System.Drawing.Point(17, 17)
        Me.txtPolicyNumber.MaxLength = 20
        Me.txtPolicyNumber.Name = "txtPolicyNumber"
        Me.txtPolicyNumber.Size = New System.Drawing.Size(166, 20)
        Me.txtPolicyNumber.TabIndex = 12
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.BackColor = System.Drawing.Color.Transparent
        Me.Label100.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.ForeColor = System.Drawing.Color.Black
        Me.Label100.Location = New System.Drawing.Point(495, 149)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(92, 13)
        Me.Label100.TabIndex = 324
        Me.Label100.Text = "Other dependents"
        '
        'txtPolicyHolderOccupation
        '
        Me.txtPolicyHolderOccupation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderOccupation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderOccupation.BackColor = System.Drawing.SystemColors.Window
        Me.txtPolicyHolderOccupation.Enabled = False
        Me.txtPolicyHolderOccupation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderOccupation.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderOccupation, -18)
        Me.txtPolicyHolderOccupation.Location = New System.Drawing.Point(387, 126)
        Me.txtPolicyHolderOccupation.MaxLength = 255
        Me.txtPolicyHolderOccupation.Name = "txtPolicyHolderOccupation"
        Me.txtPolicyHolderOccupation.Size = New System.Drawing.Size(184, 20)
        Me.txtPolicyHolderOccupation.TabIndex = 31
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(387, 112)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(62, 13)
        Me.Label28.TabIndex = 315
        Me.Label28.Text = "Occupation"
        '
        'txtPolicyHolderEmployerName
        '
        Me.txtPolicyHolderEmployerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderEmployerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderEmployerName.BackColor = System.Drawing.SystemColors.Window
        Me.txtPolicyHolderEmployerName.Enabled = False
        Me.txtPolicyHolderEmployerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderEmployerName.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderEmployerName, -18)
        Me.txtPolicyHolderEmployerName.Location = New System.Drawing.Point(16, 126)
        Me.txtPolicyHolderEmployerName.MaxLength = 255
        Me.txtPolicyHolderEmployerName.Name = "txtPolicyHolderEmployerName"
        Me.txtPolicyHolderEmployerName.Size = New System.Drawing.Size(206, 20)
        Me.txtPolicyHolderEmployerName.TabIndex = 29
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(579, 112)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(84, 13)
        Me.Label29.TabIndex = 314
        Me.Label29.Text = "Employer Phone"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(16, 112)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(81, 13)
        Me.Label30.TabIndex = 312
        Me.Label30.Text = "Employer Name"
        '
        'txtPolicyHolderEmployerAddress
        '
        Me.txtPolicyHolderEmployerAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderEmployerAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderEmployerAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtPolicyHolderEmployerAddress.Enabled = False
        Me.txtPolicyHolderEmployerAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderEmployerAddress.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderEmployerAddress, -18)
        Me.txtPolicyHolderEmployerAddress.Location = New System.Drawing.Point(230, 126)
        Me.txtPolicyHolderEmployerAddress.MaxLength = 255
        Me.txtPolicyHolderEmployerAddress.Name = "txtPolicyHolderEmployerAddress"
        Me.txtPolicyHolderEmployerAddress.Size = New System.Drawing.Size(149, 20)
        Me.txtPolicyHolderEmployerAddress.TabIndex = 30
        '
        'txtPolicyHolderEmployerPhone
        '
        Me.txtPolicyHolderEmployerPhone.BackColor = System.Drawing.SystemColors.Window
        Me.txtPolicyHolderEmployerPhone.Enabled = False
        Me.txtPolicyHolderEmployerPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderEmployerPhone.ForeColor = System.Drawing.Color.Black
        Me.txtPolicyHolderEmployerPhone.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderEmployerPhone, -18)
        Me.txtPolicyHolderEmployerPhone.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtPolicyHolderEmployerPhone.Location = New System.Drawing.Point(577, 126)
        Me.txtPolicyHolderEmployerPhone.Mask = "(999) 000-0000"
        Me.txtPolicyHolderEmployerPhone.Name = "txtPolicyHolderEmployerPhone"
        Me.txtPolicyHolderEmployerPhone.Size = New System.Drawing.Size(134, 20)
        Me.txtPolicyHolderEmployerPhone.TabIndex = 32
        Me.txtPolicyHolderEmployerPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.ForeColor = System.Drawing.Color.Black
        Me.Label67.Location = New System.Drawing.Point(230, 113)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(97, 13)
        Me.Label67.TabIndex = 313
        Me.Label67.Text = "Employeer Address"
        '
        'txtPolicyHolderSSN
        '
        Me.txtPolicyHolderSSN.BackColor = System.Drawing.SystemColors.Window
        Me.txtPolicyHolderSSN.Enabled = False
        Me.txtPolicyHolderSSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderSSN.ForeColor = System.Drawing.Color.Black
        Me.txtPolicyHolderSSN.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderSSN, -18)
        Me.txtPolicyHolderSSN.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtPolicyHolderSSN.Location = New System.Drawing.Point(584, 55)
        Me.txtPolicyHolderSSN.Mask = "000-00-0000"
        Me.txtPolicyHolderSSN.Name = "txtPolicyHolderSSN"
        Me.txtPolicyHolderSSN.Size = New System.Drawing.Size(127, 20)
        Me.txtPolicyHolderSSN.TabIndex = 28
        Me.txtPolicyHolderSSN.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.BackColor = System.Drawing.Color.Transparent
        Me.Label96.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label96.ForeColor = System.Drawing.Color.Black
        Me.Label96.Location = New System.Drawing.Point(682, 40)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(29, 13)
        Me.Label96.TabIndex = 305
        Me.Label96.Text = "SSN"
        '
        'txtPolicyHolderBirthDate
        '
        Me.txtPolicyHolderBirthDate.AccessibleDescription = ""
        Me.txtPolicyHolderBirthDate.ContextMenuStrip = Me.ContextMenuPopUpCalendar
        Me.txtPolicyHolderBirthDate.Enabled = False
        Me.txtPolicyHolderBirthDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderBirthDate.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderBirthDate, -18)
        Me.txtPolicyHolderBirthDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtPolicyHolderBirthDate.Location = New System.Drawing.Point(497, 56)
        Me.txtPolicyHolderBirthDate.Mask = "00/00/0000"
        Me.txtPolicyHolderBirthDate.Name = "txtPolicyHolderBirthDate"
        Me.txtPolicyHolderBirthDate.Size = New System.Drawing.Size(81, 20)
        Me.txtPolicyHolderBirthDate.TabIndex = 22
        Me.txtPolicyHolderBirthDate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtPolicyHolderBirthDate, "Policy Holder DOB")
        Me.txtPolicyHolderBirthDate.ValidatingType = GetType(Date)
        '
        'txtPolicyHolderOtherDependents
        '
        Me.txtPolicyHolderOtherDependents.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderOtherDependents.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderOtherDependents.Enabled = False
        Me.txtPolicyHolderOtherDependents.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderOtherDependents.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderOtherDependents, -18)
        Me.txtPolicyHolderOtherDependents.Location = New System.Drawing.Point(498, 163)
        Me.txtPolicyHolderOtherDependents.MaxLength = 50
        Me.txtPolicyHolderOtherDependents.Name = "txtPolicyHolderOtherDependents"
        Me.txtPolicyHolderOtherDependents.Size = New System.Drawing.Size(213, 20)
        Me.txtPolicyHolderOtherDependents.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(495, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 301
        Me.Label6.Text = "Policy Holder DOB"
        '
        'txtAdjusterComments
        '
        Me.txtAdjusterComments.Enabled = False
        Me.txtAdjusterComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdjusterComments.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtAdjusterComments, -18)
        Me.txtAdjusterComments.Location = New System.Drawing.Point(331, 163)
        Me.txtAdjusterComments.MaxLength = 50
        Me.txtAdjusterComments.Name = "txtAdjusterComments"
        Me.txtAdjusterComments.Size = New System.Drawing.Size(160, 20)
        Me.txtAdjusterComments.TabIndex = 35
        '
        'txtGroupNumber
        '
        Me.txtGroupNumber.Enabled = False
        Me.txtGroupNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroupNumber.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtGroupNumber, -18)
        Me.txtGroupNumber.Location = New System.Drawing.Point(498, 17)
        Me.txtGroupNumber.MaxLength = 20
        Me.txtGroupNumber.Name = "txtGroupNumber"
        Me.txtGroupNumber.Size = New System.Drawing.Size(80, 20)
        Me.txtGroupNumber.TabIndex = 13
        '
        'txtIDNumber
        '
        Me.txtIDNumber.Enabled = False
        Me.txtIDNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDNumber.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtIDNumber, -18)
        Me.txtIDNumber.Location = New System.Drawing.Point(583, 15)
        Me.txtIDNumber.MaxLength = 20
        Me.txtIDNumber.Name = "txtIDNumber"
        Me.txtIDNumber.Size = New System.Drawing.Size(128, 20)
        Me.txtIDNumber.TabIndex = 14
        '
        'txtAdjusterPhone
        '
        Me.txtAdjusterPhone.AccessibleDescription = ""
        Me.txtAdjusterPhone.AccessibleName = ""
        Me.txtAdjusterPhone.Enabled = False
        Me.txtAdjusterPhone.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtAdjusterPhone, -18)
        Me.txtAdjusterPhone.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtAdjusterPhone.Location = New System.Drawing.Point(189, 163)
        Me.txtAdjusterPhone.Mask = "(999) 000-0000 Ext. 00000"
        Me.txtAdjusterPhone.Name = "txtAdjusterPhone"
        Me.txtAdjusterPhone.Size = New System.Drawing.Size(138, 20)
        Me.txtAdjusterPhone.TabIndex = 34
        Me.txtAdjusterPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtAdjusterPhone, "Contact 1 Phone Number")
        '
        'txtAdjuster
        '
        Me.txtAdjuster.AccessibleDescription = "1"
        Me.txtAdjuster.AccessibleName = "1"
        Me.txtAdjuster.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtAdjuster.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtAdjuster.Enabled = False
        Me.txtAdjuster.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdjuster.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtAdjuster, -18)
        Me.txtAdjuster.Location = New System.Drawing.Point(16, 163)
        Me.txtAdjuster.MaxLength = 50
        Me.txtAdjuster.Name = "txtAdjuster"
        Me.txtAdjuster.Size = New System.Drawing.Size(167, 20)
        Me.txtAdjuster.TabIndex = 33
        '
        'txtPolicyHolderPhone
        '
        Me.txtPolicyHolderPhone.Enabled = False
        Me.txtPolicyHolderPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderPhone.ForeColor = System.Drawing.Color.Black
        Me.txtPolicyHolderPhone.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderPhone, -18)
        Me.txtPolicyHolderPhone.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtPolicyHolderPhone.Location = New System.Drawing.Point(584, 91)
        Me.txtPolicyHolderPhone.Mask = "(999) 000-0000"
        Me.txtPolicyHolderPhone.Name = "txtPolicyHolderPhone"
        Me.txtPolicyHolderPhone.Size = New System.Drawing.Size(127, 20)
        Me.txtPolicyHolderPhone.TabIndex = 27
        Me.txtPolicyHolderPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtPolicyHolderPhone, "Policy Holder Phone")
        '
        'txtPolicyHolderZip
        '
        Me.txtPolicyHolderZip.Enabled = False
        Me.txtPolicyHolderZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderZip.ForeColor = System.Drawing.Color.Black
        Me.txtPolicyHolderZip.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderZip, -18)
        Me.txtPolicyHolderZip.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtPolicyHolderZip.Location = New System.Drawing.Point(498, 91)
        Me.txtPolicyHolderZip.Mask = "00000"
        Me.txtPolicyHolderZip.Name = "txtPolicyHolderZip"
        Me.txtPolicyHolderZip.Size = New System.Drawing.Size(80, 20)
        Me.txtPolicyHolderZip.TabIndex = 26
        Me.txtPolicyHolderZip.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'ComboBoxPolicyHolderState
        '
        Me.ComboBoxPolicyHolderState.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxPolicyHolderState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPolicyHolderState.Enabled = False
        Me.ComboBoxPolicyHolderState.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxPolicyHolderState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxPolicyHolderState.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxPolicyHolderState.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxPolicyHolderState, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxPolicyHolderState, -18)
        Me.ComboBoxPolicyHolderState.Location = New System.Drawing.Point(387, 91)
        Me.ComboBoxPolicyHolderState.Name = "ComboBoxPolicyHolderState"
        Me.ComboBoxPolicyHolderState.Size = New System.Drawing.Size(104, 21)
        Me.ComboBoxPolicyHolderState.TabIndex = 25
        '
        'txtPolicyHolderCity
        '
        Me.txtPolicyHolderCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderCity.Enabled = False
        Me.txtPolicyHolderCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderCity.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderCity, -18)
        Me.txtPolicyHolderCity.Location = New System.Drawing.Point(230, 90)
        Me.txtPolicyHolderCity.MaxLength = 50
        Me.txtPolicyHolderCity.Name = "txtPolicyHolderCity"
        Me.txtPolicyHolderCity.Size = New System.Drawing.Size(149, 20)
        Me.txtPolicyHolderCity.TabIndex = 24
        '
        'txtPolicyHolderAddress
        '
        Me.txtPolicyHolderAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderAddress.Enabled = False
        Me.txtPolicyHolderAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderAddress.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderAddress, -18)
        Me.txtPolicyHolderAddress.Location = New System.Drawing.Point(16, 91)
        Me.txtPolicyHolderAddress.MaxLength = 50
        Me.txtPolicyHolderAddress.Name = "txtPolicyHolderAddress"
        Me.txtPolicyHolderAddress.Size = New System.Drawing.Size(205, 20)
        Me.txtPolicyHolderAddress.TabIndex = 23
        '
        'ComboBoxRelationToInsuredID
        '
        Me.ComboBoxRelationToInsuredID.AccessibleDescription = "1"
        Me.ComboBoxRelationToInsuredID.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxRelationToInsuredID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRelationToInsuredID.Enabled = False
        Me.ComboBoxRelationToInsuredID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxRelationToInsuredID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxRelationToInsuredID.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxRelationToInsuredID.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxRelationToInsuredID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxRelationToInsuredID, -18)
        Me.ComboBoxRelationToInsuredID.Location = New System.Drawing.Point(18, 54)
        Me.ComboBoxRelationToInsuredID.Name = "ComboBoxRelationToInsuredID"
        Me.ComboBoxRelationToInsuredID.Size = New System.Drawing.Size(104, 21)
        Me.ComboBoxRelationToInsuredID.TabIndex = 21
        '
        'txtPolicyHolderLName
        '
        Me.txtPolicyHolderLName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderLName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderLName.Enabled = False
        Me.txtPolicyHolderLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderLName.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderLName, -18)
        Me.txtPolicyHolderLName.Location = New System.Drawing.Point(358, 55)
        Me.txtPolicyHolderLName.Name = "txtPolicyHolderLName"
        Me.txtPolicyHolderLName.Size = New System.Drawing.Size(133, 20)
        Me.txtPolicyHolderLName.TabIndex = 20
        '
        'txtPolicyHolderMI
        '
        Me.txtPolicyHolderMI.Enabled = False
        Me.txtPolicyHolderMI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderMI.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderMI, -18)
        Me.txtPolicyHolderMI.Location = New System.Drawing.Point(320, 56)
        Me.txtPolicyHolderMI.MaxLength = 5
        Me.txtPolicyHolderMI.Name = "txtPolicyHolderMI"
        Me.txtPolicyHolderMI.Size = New System.Drawing.Size(32, 20)
        Me.txtPolicyHolderMI.TabIndex = 13
        '
        'txtPolicyHolderFName
        '
        Me.txtPolicyHolderFName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderFName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderFName.Enabled = False
        Me.txtPolicyHolderFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderFName.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderFName, -18)
        Me.txtPolicyHolderFName.Location = New System.Drawing.Point(128, 55)
        Me.txtPolicyHolderFName.Name = "txtPolicyHolderFName"
        Me.txtPolicyHolderFName.Size = New System.Drawing.Size(186, 20)
        Me.txtPolicyHolderFName.TabIndex = 19
        '
        'txtClaimEffectiveDT
        '
        Me.txtClaimEffectiveDT.AccessibleDescription = "1"
        Me.txtClaimEffectiveDT.AccessibleName = "1"
        Me.txtClaimEffectiveDT.ContextMenuStrip = Me.ContextMenuPopUpCalendar
        Me.txtClaimEffectiveDT.Enabled = False
        Me.txtClaimEffectiveDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaimEffectiveDT.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtClaimEffectiveDT, -18)
        Me.txtClaimEffectiveDT.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtClaimEffectiveDT.Location = New System.Drawing.Point(358, 17)
        Me.txtClaimEffectiveDT.Mask = "00/00/0000"
        Me.txtClaimEffectiveDT.Name = "txtClaimEffectiveDT"
        Me.txtClaimEffectiveDT.Size = New System.Drawing.Size(133, 20)
        Me.txtClaimEffectiveDT.TabIndex = 18
        Me.txtClaimEffectiveDT.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtClaimEffectiveDT.ValidatingType = GetType(Date)
        '
        'txtClaimNumber
        '
        Me.txtClaimNumber.AccessibleDescription = "1"
        Me.txtClaimNumber.AccessibleName = "1"
        Me.txtClaimNumber.Enabled = False
        Me.txtClaimNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaimNumber.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtClaimNumber, -18)
        Me.txtClaimNumber.Location = New System.Drawing.Point(189, 17)
        Me.txtClaimNumber.Name = "txtClaimNumber"
        Me.txtClaimNumber.Size = New System.Drawing.Size(163, 20)
        Me.txtClaimNumber.TabIndex = 17
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.ForeColor = System.Drawing.Color.Black
        Me.Label65.Location = New System.Drawing.Point(495, 3)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(46, 13)
        Me.Label65.TabIndex = 285
        Me.Label65.Text = "Group #"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(581, 3)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(67, 13)
        Me.Label31.TabIndex = 281
        Me.Label31.Text = "Subscriber #"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.BackColor = System.Drawing.Color.Transparent
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.Black
        Me.Label61.Location = New System.Drawing.Point(581, 77)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(80, 13)
        Me.Label61.TabIndex = 239
        Me.Label61.Text = "Policy H Phone"
        Me.ToolTip1.SetToolTip(Me.Label61, "Policy Holder Phone")
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.BackColor = System.Drawing.Color.Transparent
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.Black
        Me.Label60.Location = New System.Drawing.Point(387, 77)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(32, 13)
        Me.Label60.TabIndex = 237
        Me.Label60.Text = "State"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.BackColor = System.Drawing.Color.Transparent
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.Black
        Me.Label59.Location = New System.Drawing.Point(495, 77)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(50, 13)
        Me.Label59.TabIndex = 236
        Me.Label59.Text = "Zip Code"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(230, 76)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(24, 13)
        Me.Label58.TabIndex = 235
        Me.Label58.Text = "City"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.ForeColor = System.Drawing.Color.Black
        Me.Label56.Location = New System.Drawing.Point(16, 77)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(110, 13)
        Me.Label56.TabIndex = 233
        Me.Label56.Text = "Policy Holder Address"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(189, 149)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(79, 13)
        Me.Label41.TabIndex = 210
        Me.Label41.Text = "Adjuster Phone"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(189, 3)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(72, 13)
        Me.Label24.TabIndex = 179
        Me.Label24.Text = "Claim Number"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(16, 147)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(76, 13)
        Me.Label34.TabIndex = 208
        Me.Label34.Text = "Adjuster Name"
        '
        'LabelEffectiveDate
        '
        Me.LabelEffectiveDate.AutoSize = True
        Me.LabelEffectiveDate.BackColor = System.Drawing.Color.Transparent
        Me.LabelEffectiveDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEffectiveDate.ForeColor = System.Drawing.Color.Black
        Me.LabelEffectiveDate.Location = New System.Drawing.Point(355, 3)
        Me.LabelEffectiveDate.Name = "LabelEffectiveDate"
        Me.LabelEffectiveDate.Size = New System.Drawing.Size(67, 13)
        Me.LabelEffectiveDate.TabIndex = 182
        Me.LabelEffectiveDate.Text = "Effective DT"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.Transparent
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.Black
        Me.Label55.Location = New System.Drawing.Point(16, 40)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(100, 13)
        Me.Label55.TabIndex = 227
        Me.Label55.Text = "Relation To Insured"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(328, 149)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(95, 13)
        Me.Label50.TabIndex = 215
        Me.Label50.Text = "Adjuster Other Info"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(125, 39)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(122, 13)
        Me.Label52.TabIndex = 220
        Me.Label52.Text = "Policy Holder First Name"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(16, 3)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(75, 13)
        Me.Label51.TabIndex = 219
        Me.Label51.Text = "Policy Number"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(317, 40)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(19, 13)
        Me.Label53.TabIndex = 223
        Me.Label53.Text = "MI"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.Black
        Me.Label54.Location = New System.Drawing.Point(355, 40)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(123, 13)
        Me.Label54.TabIndex = 225
        Me.Label54.Text = "Policy Holder Last Name"
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.PanelSecondaryInsurance)
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage9.Size = New System.Drawing.Size(722, 288)
        Me.TabPage9.TabIndex = 1
        Me.TabPage9.Text = "Secondary Insurance Company"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'PanelSecondaryInsurance
        '
        Me.PanelSecondaryInsurance.BackColor = System.Drawing.Color.Transparent
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtAdjusterComments1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtAdjusterPhone1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtAdjuster1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label117)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label118)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label119)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtClaimNumber1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label116)
        Me.PanelSecondaryInsurance.Controls.Add(Me.cmdAddInsuranceAddress1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.ComboBoxClaimAddress1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label104)
        Me.PanelSecondaryInsurance.Controls.Add(Me.ButtonShowInsurance1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyNumber1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label68)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label101)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderOtherDependents1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderOccupation1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label75)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderEmployerName1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label76)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label98)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderEmployerAddress1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderEmployerPhone1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label99)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderSSN1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label97)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderBirthDate1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label95)
        Me.PanelSecondaryInsurance.Controls.Add(Me.ComboBoxInsuranceCompanyID1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.CheckBoxInsurance1Verifyed)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtGroupNumber1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label32)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtIDNumber1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label69)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderPhone1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderZip1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.ComboBoxPolicyHolderState1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderCity1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderAddress1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.ComboBoxRelationToInsuredID1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderLName1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderMI1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.txtPolicyHolderFName1)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label77)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label80)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label78)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label57)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label73)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label40)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label72)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label71)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label74)
        Me.PanelSecondaryInsurance.Controls.Add(Me.Label70)
        Me.PanelSecondaryInsurance.Location = New System.Drawing.Point(0, 0)
        Me.PanelSecondaryInsurance.Name = "PanelSecondaryInsurance"
        Me.PanelSecondaryInsurance.Size = New System.Drawing.Size(719, 292)
        Me.PanelSecondaryInsurance.TabIndex = 333
        '
        'txtAdjusterComments1
        '
        Me.txtAdjusterComments1.Enabled = False
        Me.txtAdjusterComments1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdjusterComments1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtAdjusterComments1, -18)
        Me.txtAdjusterComments1.Location = New System.Drawing.Point(333, 267)
        Me.txtAdjusterComments1.MaxLength = 50
        Me.txtAdjusterComments1.Name = "txtAdjusterComments1"
        Me.txtAdjusterComments1.Size = New System.Drawing.Size(134, 20)
        Me.txtAdjusterComments1.TabIndex = 59
        '
        'txtAdjusterPhone1
        '
        Me.txtAdjusterPhone1.AccessibleDescription = ""
        Me.txtAdjusterPhone1.AccessibleName = ""
        Me.txtAdjusterPhone1.Enabled = False
        Me.txtAdjusterPhone1.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtAdjusterPhone1, -18)
        Me.txtAdjusterPhone1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtAdjusterPhone1.Location = New System.Drawing.Point(191, 267)
        Me.txtAdjusterPhone1.Mask = "(999) 000-0000 Ext. 00000"
        Me.txtAdjusterPhone1.Name = "txtAdjusterPhone1"
        Me.txtAdjusterPhone1.Size = New System.Drawing.Size(138, 20)
        Me.txtAdjusterPhone1.TabIndex = 58
        Me.txtAdjusterPhone1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtAdjusterPhone1, "Contact 1 Phone Number")
        '
        'txtAdjuster1
        '
        Me.txtAdjuster1.AccessibleDescription = "1"
        Me.txtAdjuster1.AccessibleName = "1"
        Me.txtAdjuster1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtAdjuster1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtAdjuster1.Enabled = False
        Me.txtAdjuster1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdjuster1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtAdjuster1, -18)
        Me.txtAdjuster1.Location = New System.Drawing.Point(18, 267)
        Me.txtAdjuster1.MaxLength = 50
        Me.txtAdjuster1.Name = "txtAdjuster1"
        Me.txtAdjuster1.Size = New System.Drawing.Size(167, 20)
        Me.txtAdjuster1.TabIndex = 57
        '
        'Label117
        '
        Me.Label117.AutoSize = True
        Me.Label117.BackColor = System.Drawing.Color.Transparent
        Me.Label117.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label117.ForeColor = System.Drawing.Color.Black
        Me.Label117.Location = New System.Drawing.Point(191, 253)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(79, 13)
        Me.Label117.TabIndex = 338
        Me.Label117.Text = "Adjuster Phone"
        '
        'Label118
        '
        Me.Label118.AutoSize = True
        Me.Label118.BackColor = System.Drawing.Color.Transparent
        Me.Label118.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label118.ForeColor = System.Drawing.Color.Black
        Me.Label118.Location = New System.Drawing.Point(18, 251)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(76, 13)
        Me.Label118.TabIndex = 337
        Me.Label118.Text = "Adjuster Name"
        '
        'Label119
        '
        Me.Label119.AutoSize = True
        Me.Label119.BackColor = System.Drawing.Color.Transparent
        Me.Label119.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label119.ForeColor = System.Drawing.Color.Black
        Me.Label119.Location = New System.Drawing.Point(330, 253)
        Me.Label119.Name = "Label119"
        Me.Label119.Size = New System.Drawing.Size(95, 13)
        Me.Label119.TabIndex = 339
        Me.Label119.Text = "Adjuster Other Info"
        '
        'txtClaimNumber1
        '
        Me.txtClaimNumber1.AccessibleDescription = "1"
        Me.txtClaimNumber1.AccessibleName = "1"
        Me.txtClaimNumber1.Enabled = False
        Me.txtClaimNumber1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaimNumber1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtClaimNumber1, -18)
        Me.txtClaimNumber1.Location = New System.Drawing.Point(190, 110)
        Me.txtClaimNumber1.Name = "txtClaimNumber1"
        Me.txtClaimNumber1.Size = New System.Drawing.Size(172, 20)
        Me.txtClaimNumber1.TabIndex = 40
        '
        'Label116
        '
        Me.Label116.AutoSize = True
        Me.Label116.BackColor = System.Drawing.Color.Transparent
        Me.Label116.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label116.ForeColor = System.Drawing.Color.Black
        Me.Label116.Location = New System.Drawing.Point(190, 96)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(72, 13)
        Me.Label116.TabIndex = 333
        Me.Label116.Text = "Claim Number"
        '
        'cmdAddInsuranceAddress1
        '
        Me.cmdAddInsuranceAddress1.Enabled = False
        Me.cmdAddInsuranceAddress1.FlatAppearance.BorderSize = 0
        Me.cmdAddInsuranceAddress1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAddInsuranceAddress1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddInsuranceAddress1.Image = CType(resources.GetObject("cmdAddInsuranceAddress1.Image"), System.Drawing.Image)
        Me.cmdAddInsuranceAddress1.Location = New System.Drawing.Point(689, 64)
        Me.cmdAddInsuranceAddress1.Name = "cmdAddInsuranceAddress1"
        Me.cmdAddInsuranceAddress1.Size = New System.Drawing.Size(22, 21)
        Me.cmdAddInsuranceAddress1.TabIndex = 331
        Me.ToolTip1.SetToolTip(Me.cmdAddInsuranceAddress1, "Add Insurance Claim Address")
        Me.cmdAddInsuranceAddress1.UseVisualStyleBackColor = True
        '
        'ComboBoxClaimAddress1
        '
        Me.ComboBoxClaimAddress1.AccessibleDescription = "1"
        Me.ComboBoxClaimAddress1.AccessibleName = "1"
        Me.ComboBoxClaimAddress1.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxClaimAddress1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxClaimAddress1.DropDownWidth = 650
        Me.ComboBoxClaimAddress1.Enabled = False
        Me.ComboBoxClaimAddress1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxClaimAddress1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxClaimAddress1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxClaimAddress1.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxClaimAddress1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxClaimAddress1, -18)
        Me.ComboBoxClaimAddress1.Location = New System.Drawing.Point(19, 65)
        Me.ComboBoxClaimAddress1.Name = "ComboBoxClaimAddress1"
        Me.ComboBoxClaimAddress1.Size = New System.Drawing.Size(663, 21)
        Me.ComboBoxClaimAddress1.TabIndex = 329
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.BackColor = System.Drawing.Color.Transparent
        Me.Label104.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.ForeColor = System.Drawing.Color.Black
        Me.Label104.Location = New System.Drawing.Point(19, 49)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(333, 13)
        Me.Label104.TabIndex = 330
        Me.Label104.Text = "Claim Address (if address is not on the list, please inform administrator)"
        '
        'ButtonShowInsurance1
        '
        Me.ButtonShowInsurance1.Enabled = False
        Me.ButtonShowInsurance1.FlatAppearance.BorderSize = 0
        Me.ButtonShowInsurance1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonShowInsurance1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonShowInsurance1.Image = CType(resources.GetObject("ButtonShowInsurance1.Image"), System.Drawing.Image)
        Me.ButtonShowInsurance1.Location = New System.Drawing.Point(688, 26)
        Me.ButtonShowInsurance1.Name = "ButtonShowInsurance1"
        Me.ButtonShowInsurance1.Size = New System.Drawing.Size(22, 21)
        Me.ButtonShowInsurance1.TabIndex = 328
        Me.ToolTip1.SetToolTip(Me.ButtonShowInsurance1, "Show Insurance Maintenance")
        Me.ButtonShowInsurance1.UseVisualStyleBackColor = True
        '
        'txtPolicyNumber1
        '
        Me.txtPolicyNumber1.Enabled = False
        Me.txtPolicyNumber1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyNumber1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyNumber1, -18)
        Me.txtPolicyNumber1.Location = New System.Drawing.Point(18, 110)
        Me.txtPolicyNumber1.MaxLength = 20
        Me.txtPolicyNumber1.Name = "txtPolicyNumber1"
        Me.txtPolicyNumber1.Size = New System.Drawing.Size(166, 20)
        Me.txtPolicyNumber1.TabIndex = 39
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.ForeColor = System.Drawing.Color.Black
        Me.Label68.Location = New System.Drawing.Point(365, 94)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(46, 13)
        Me.Label68.TabIndex = 327
        Me.Label68.Text = "Group #"
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.BackColor = System.Drawing.Color.Transparent
        Me.Label101.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.ForeColor = System.Drawing.Color.Black
        Me.Label101.Location = New System.Drawing.Point(468, 251)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(206, 13)
        Me.Label101.TabIndex = 326
        Me.Label101.Text = "Other dependents covered under this plan"
        '
        'txtPolicyHolderOtherDependents1
        '
        Me.txtPolicyHolderOtherDependents1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderOtherDependents1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderOtherDependents1.Enabled = False
        Me.txtPolicyHolderOtherDependents1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderOtherDependents1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderOtherDependents1, -18)
        Me.txtPolicyHolderOtherDependents1.Location = New System.Drawing.Point(473, 267)
        Me.txtPolicyHolderOtherDependents1.MaxLength = 50
        Me.txtPolicyHolderOtherDependents1.Name = "txtPolicyHolderOtherDependents1"
        Me.txtPolicyHolderOtherDependents1.Size = New System.Drawing.Size(237, 20)
        Me.txtPolicyHolderOtherDependents1.TabIndex = 60
        '
        'txtPolicyHolderOccupation1
        '
        Me.txtPolicyHolderOccupation1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderOccupation1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderOccupation1.BackColor = System.Drawing.SystemColors.Window
        Me.txtPolicyHolderOccupation1.Enabled = False
        Me.txtPolicyHolderOccupation1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderOccupation1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderOccupation1, -18)
        Me.txtPolicyHolderOccupation1.Location = New System.Drawing.Point(405, 230)
        Me.txtPolicyHolderOccupation1.MaxLength = 255
        Me.txtPolicyHolderOccupation1.Name = "txtPolicyHolderOccupation1"
        Me.txtPolicyHolderOccupation1.Size = New System.Drawing.Size(181, 20)
        Me.txtPolicyHolderOccupation1.TabIndex = 55
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.BackColor = System.Drawing.Color.Transparent
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.Black
        Me.Label75.Location = New System.Drawing.Point(404, 214)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(62, 13)
        Me.Label75.TabIndex = 323
        Me.Label75.Text = "Occupation"
        '
        'txtPolicyHolderEmployerName1
        '
        Me.txtPolicyHolderEmployerName1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderEmployerName1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderEmployerName1.BackColor = System.Drawing.SystemColors.Window
        Me.txtPolicyHolderEmployerName1.Enabled = False
        Me.txtPolicyHolderEmployerName1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderEmployerName1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderEmployerName1, -18)
        Me.txtPolicyHolderEmployerName1.Location = New System.Drawing.Point(18, 228)
        Me.txtPolicyHolderEmployerName1.MaxLength = 255
        Me.txtPolicyHolderEmployerName1.Name = "txtPolicyHolderEmployerName1"
        Me.txtPolicyHolderEmployerName1.Size = New System.Drawing.Size(206, 20)
        Me.txtPolicyHolderEmployerName1.TabIndex = 53
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.BackColor = System.Drawing.Color.Transparent
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.Black
        Me.Label76.Location = New System.Drawing.Point(589, 214)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(84, 13)
        Me.Label76.TabIndex = 322
        Me.Label76.Text = "Employer Phone"
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.BackColor = System.Drawing.Color.Transparent
        Me.Label98.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label98.ForeColor = System.Drawing.Color.Black
        Me.Label98.Location = New System.Drawing.Point(18, 214)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(81, 13)
        Me.Label98.TabIndex = 320
        Me.Label98.Text = "Employer Name"
        '
        'txtPolicyHolderEmployerAddress1
        '
        Me.txtPolicyHolderEmployerAddress1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderEmployerAddress1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderEmployerAddress1.BackColor = System.Drawing.SystemColors.Window
        Me.txtPolicyHolderEmployerAddress1.Enabled = False
        Me.txtPolicyHolderEmployerAddress1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderEmployerAddress1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderEmployerAddress1, -18)
        Me.txtPolicyHolderEmployerAddress1.Location = New System.Drawing.Point(230, 230)
        Me.txtPolicyHolderEmployerAddress1.MaxLength = 255
        Me.txtPolicyHolderEmployerAddress1.Name = "txtPolicyHolderEmployerAddress1"
        Me.txtPolicyHolderEmployerAddress1.Size = New System.Drawing.Size(166, 20)
        Me.txtPolicyHolderEmployerAddress1.TabIndex = 54
        '
        'txtPolicyHolderEmployerPhone1
        '
        Me.txtPolicyHolderEmployerPhone1.BackColor = System.Drawing.SystemColors.Window
        Me.txtPolicyHolderEmployerPhone1.Enabled = False
        Me.txtPolicyHolderEmployerPhone1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderEmployerPhone1.ForeColor = System.Drawing.Color.Black
        Me.txtPolicyHolderEmployerPhone1.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderEmployerPhone1, -18)
        Me.txtPolicyHolderEmployerPhone1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtPolicyHolderEmployerPhone1.Location = New System.Drawing.Point(591, 230)
        Me.txtPolicyHolderEmployerPhone1.Mask = "(999) 000-0000"
        Me.txtPolicyHolderEmployerPhone1.Name = "txtPolicyHolderEmployerPhone1"
        Me.txtPolicyHolderEmployerPhone1.Size = New System.Drawing.Size(119, 20)
        Me.txtPolicyHolderEmployerPhone1.TabIndex = 56
        Me.txtPolicyHolderEmployerPhone1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.BackColor = System.Drawing.Color.Transparent
        Me.Label99.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.ForeColor = System.Drawing.Color.Black
        Me.Label99.Location = New System.Drawing.Point(230, 214)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(97, 13)
        Me.Label99.TabIndex = 321
        Me.Label99.Text = "Employeer Address"
        '
        'txtPolicyHolderSSN1
        '
        Me.txtPolicyHolderSSN1.BackColor = System.Drawing.SystemColors.Window
        Me.txtPolicyHolderSSN1.Enabled = False
        Me.txtPolicyHolderSSN1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderSSN1.ForeColor = System.Drawing.Color.Black
        Me.txtPolicyHolderSSN1.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderSSN1, -18)
        Me.txtPolicyHolderSSN1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtPolicyHolderSSN1.Location = New System.Drawing.Point(591, 151)
        Me.txtPolicyHolderSSN1.Mask = "000-00-0000"
        Me.txtPolicyHolderSSN1.Name = "txtPolicyHolderSSN1"
        Me.txtPolicyHolderSSN1.Size = New System.Drawing.Size(119, 20)
        Me.txtPolicyHolderSSN1.TabIndex = 52
        Me.txtPolicyHolderSSN1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.BackColor = System.Drawing.Color.Transparent
        Me.Label97.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label97.ForeColor = System.Drawing.Color.Black
        Me.Label97.Location = New System.Drawing.Point(638, 135)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(29, 13)
        Me.Label97.TabIndex = 307
        Me.Label97.Text = "SSN"
        '
        'txtPolicyHolderBirthDate1
        '
        Me.txtPolicyHolderBirthDate1.AccessibleDescription = ""
        Me.txtPolicyHolderBirthDate1.ContextMenuStrip = Me.ContextMenuPopUpCalendar
        Me.txtPolicyHolderBirthDate1.Enabled = False
        Me.txtPolicyHolderBirthDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderBirthDate1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderBirthDate1, -18)
        Me.txtPolicyHolderBirthDate1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtPolicyHolderBirthDate1.Location = New System.Drawing.Point(505, 152)
        Me.txtPolicyHolderBirthDate1.Mask = "00/00/0000"
        Me.txtPolicyHolderBirthDate1.Name = "txtPolicyHolderBirthDate1"
        Me.txtPolicyHolderBirthDate1.Size = New System.Drawing.Size(81, 20)
        Me.txtPolicyHolderBirthDate1.TabIndex = 46
        Me.txtPolicyHolderBirthDate1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtPolicyHolderBirthDate1, "Policy Holder DOB")
        Me.txtPolicyHolderBirthDate1.ValidatingType = GetType(Date)
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.BackColor = System.Drawing.Color.Transparent
        Me.Label95.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label95.ForeColor = System.Drawing.Color.Black
        Me.Label95.Location = New System.Drawing.Point(502, 135)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(95, 13)
        Me.Label95.TabIndex = 303
        Me.Label95.Text = "Policy Holder DOB"
        '
        'ComboBoxInsuranceCompanyID1
        '
        Me.ComboBoxInsuranceCompanyID1.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxInsuranceCompanyID1.Enabled = False
        Me.ComboBoxInsuranceCompanyID1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxInsuranceCompanyID1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxInsuranceCompanyID1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxInsuranceCompanyID1.FormattingEnabled = True
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxInsuranceCompanyID1, -18)
        Me.ComboBoxInsuranceCompanyID1.Location = New System.Drawing.Point(20, 25)
        Me.ComboBoxInsuranceCompanyID1.Name = "ComboBoxInsuranceCompanyID1"
        Me.ComboBoxInsuranceCompanyID1.Size = New System.Drawing.Size(662, 21)
        Me.ComboBoxInsuranceCompanyID1.TabIndex = 37
        '
        'CheckBoxInsurance1Verifyed
        '
        Me.CheckBoxInsurance1Verifyed.AutoSize = True
        Me.CheckBoxInsurance1Verifyed.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxInsurance1Verifyed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxInsurance1Verifyed.Location = New System.Drawing.Point(600, 6)
        Me.CheckBoxInsurance1Verifyed.Name = "CheckBoxInsurance1Verifyed"
        Me.CheckBoxInsurance1Verifyed.Size = New System.Drawing.Size(111, 17)
        Me.CheckBoxInsurance1Verifyed.TabIndex = 38
        Me.CheckBoxInsurance1Verifyed.Text = "Insurance Verified"
        Me.CheckBoxInsurance1Verifyed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.CheckBoxInsurance1Verifyed, "Secondary Insurance Information Verified")
        Me.CheckBoxInsurance1Verifyed.UseVisualStyleBackColor = False
        '
        'txtGroupNumber1
        '
        Me.txtGroupNumber1.Enabled = False
        Me.txtGroupNumber1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroupNumber1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtGroupNumber1, -18)
        Me.txtGroupNumber1.Location = New System.Drawing.Point(368, 110)
        Me.txtGroupNumber1.MaxLength = 20
        Me.txtGroupNumber1.Name = "txtGroupNumber1"
        Me.txtGroupNumber1.Size = New System.Drawing.Size(130, 20)
        Me.txtGroupNumber1.TabIndex = 40
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(503, 94)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(67, 13)
        Me.Label32.TabIndex = 283
        Me.Label32.Text = "Subscriber #"
        '
        'txtIDNumber1
        '
        Me.txtIDNumber1.Enabled = False
        Me.txtIDNumber1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDNumber1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtIDNumber1, -18)
        Me.txtIDNumber1.Location = New System.Drawing.Point(506, 112)
        Me.txtIDNumber1.MaxLength = 20
        Me.txtIDNumber1.Name = "txtIDNumber1"
        Me.txtIDNumber1.Size = New System.Drawing.Size(80, 20)
        Me.txtIDNumber1.TabIndex = 41
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.BackColor = System.Drawing.Color.Transparent
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.ForeColor = System.Drawing.Color.Black
        Me.Label69.Location = New System.Drawing.Point(589, 175)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(80, 13)
        Me.Label69.TabIndex = 40
        Me.Label69.Text = "Policy H Phone"
        Me.ToolTip1.SetToolTip(Me.Label69, "Policy Holder Phone")
        '
        'txtPolicyHolderPhone1
        '
        Me.txtPolicyHolderPhone1.Enabled = False
        Me.txtPolicyHolderPhone1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderPhone1.ForeColor = System.Drawing.Color.Black
        Me.txtPolicyHolderPhone1.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderPhone1, -18)
        Me.txtPolicyHolderPhone1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtPolicyHolderPhone1.Location = New System.Drawing.Point(591, 191)
        Me.txtPolicyHolderPhone1.Mask = "(999) 000-0000"
        Me.txtPolicyHolderPhone1.Name = "txtPolicyHolderPhone1"
        Me.txtPolicyHolderPhone1.Size = New System.Drawing.Size(119, 20)
        Me.txtPolicyHolderPhone1.TabIndex = 51
        Me.txtPolicyHolderPhone1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ToolTip1.SetToolTip(Me.txtPolicyHolderPhone1, "Policy Holder Phone")
        '
        'txtPolicyHolderZip1
        '
        Me.txtPolicyHolderZip1.Enabled = False
        Me.txtPolicyHolderZip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderZip1.ForeColor = System.Drawing.Color.Black
        Me.txtPolicyHolderZip1.HidePromptOnLeave = True
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderZip1, -18)
        Me.txtPolicyHolderZip1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtPolicyHolderZip1.Location = New System.Drawing.Point(506, 189)
        Me.txtPolicyHolderZip1.Mask = "00000"
        Me.txtPolicyHolderZip1.Name = "txtPolicyHolderZip1"
        Me.txtPolicyHolderZip1.Size = New System.Drawing.Size(80, 20)
        Me.txtPolicyHolderZip1.TabIndex = 50
        Me.txtPolicyHolderZip1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'ComboBoxPolicyHolderState1
        '
        Me.ComboBoxPolicyHolderState1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPolicyHolderState1.Enabled = False
        Me.ComboBoxPolicyHolderState1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxPolicyHolderState1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxPolicyHolderState1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxPolicyHolderState1.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxPolicyHolderState1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxPolicyHolderState1.Location = New System.Drawing.Point(405, 188)
        Me.ComboBoxPolicyHolderState1.Name = "ComboBoxPolicyHolderState1"
        Me.ComboBoxPolicyHolderState1.Size = New System.Drawing.Size(93, 21)
        Me.ComboBoxPolicyHolderState1.TabIndex = 49
        '
        'txtPolicyHolderCity1
        '
        Me.txtPolicyHolderCity1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderCity1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderCity1.Enabled = False
        Me.txtPolicyHolderCity1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderCity1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderCity1, -18)
        Me.txtPolicyHolderCity1.Location = New System.Drawing.Point(230, 188)
        Me.txtPolicyHolderCity1.MaxLength = 50
        Me.txtPolicyHolderCity1.Name = "txtPolicyHolderCity1"
        Me.txtPolicyHolderCity1.Size = New System.Drawing.Size(166, 20)
        Me.txtPolicyHolderCity1.TabIndex = 48
        '
        'txtPolicyHolderAddress1
        '
        Me.txtPolicyHolderAddress1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderAddress1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderAddress1.Enabled = False
        Me.txtPolicyHolderAddress1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderAddress1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderAddress1, -18)
        Me.txtPolicyHolderAddress1.Location = New System.Drawing.Point(19, 188)
        Me.txtPolicyHolderAddress1.MaxLength = 50
        Me.txtPolicyHolderAddress1.Name = "txtPolicyHolderAddress1"
        Me.txtPolicyHolderAddress1.Size = New System.Drawing.Size(205, 20)
        Me.txtPolicyHolderAddress1.TabIndex = 47
        '
        'ComboBoxRelationToInsuredID1
        '
        Me.ComboBoxRelationToInsuredID1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRelationToInsuredID1.Enabled = False
        Me.ComboBoxRelationToInsuredID1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxRelationToInsuredID1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxRelationToInsuredID1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxRelationToInsuredID1.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxRelationToInsuredID1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ComboBoxRelationToInsuredID1.Location = New System.Drawing.Point(19, 148)
        Me.ComboBoxRelationToInsuredID1.Name = "ComboBoxRelationToInsuredID1"
        Me.ComboBoxRelationToInsuredID1.Size = New System.Drawing.Size(118, 21)
        Me.ComboBoxRelationToInsuredID1.TabIndex = 45
        '
        'txtPolicyHolderLName1
        '
        Me.txtPolicyHolderLName1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderLName1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderLName1.Enabled = False
        Me.txtPolicyHolderLName1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderLName1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderLName1, -18)
        Me.txtPolicyHolderLName1.Location = New System.Drawing.Point(368, 151)
        Me.txtPolicyHolderLName1.Name = "txtPolicyHolderLName1"
        Me.txtPolicyHolderLName1.Size = New System.Drawing.Size(131, 20)
        Me.txtPolicyHolderLName1.TabIndex = 44
        '
        'txtPolicyHolderMI1
        '
        Me.txtPolicyHolderMI1.Enabled = False
        Me.txtPolicyHolderMI1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderMI1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderMI1, -18)
        Me.txtPolicyHolderMI1.Location = New System.Drawing.Point(293, 149)
        Me.txtPolicyHolderMI1.MaxLength = 5
        Me.txtPolicyHolderMI1.Name = "txtPolicyHolderMI1"
        Me.txtPolicyHolderMI1.Size = New System.Drawing.Size(69, 20)
        Me.txtPolicyHolderMI1.TabIndex = 43
        '
        'txtPolicyHolderFName1
        '
        Me.txtPolicyHolderFName1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPolicyHolderFName1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPolicyHolderFName1.Enabled = False
        Me.txtPolicyHolderFName1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyHolderFName1.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconPadding(Me.txtPolicyHolderFName1, -18)
        Me.txtPolicyHolderFName1.Location = New System.Drawing.Point(143, 149)
        Me.txtPolicyHolderFName1.Name = "txtPolicyHolderFName1"
        Me.txtPolicyHolderFName1.Size = New System.Drawing.Size(145, 20)
        Me.txtPolicyHolderFName1.TabIndex = 42
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.BackColor = System.Drawing.Color.Transparent
        Me.Label77.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.ForeColor = System.Drawing.Color.Black
        Me.Label77.Location = New System.Drawing.Point(16, 130)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(100, 13)
        Me.Label77.TabIndex = 269
        Me.Label77.Text = "Relation To Insured"
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.BackColor = System.Drawing.Color.Transparent
        Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.Black
        Me.Label80.Location = New System.Drawing.Point(19, 9)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(132, 13)
        Me.Label80.TabIndex = 263
        Me.Label80.Text = "Insurance Company Name"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.BackColor = System.Drawing.Color.Transparent
        Me.Label78.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.ForeColor = System.Drawing.Color.Black
        Me.Label78.Location = New System.Drawing.Point(18, 94)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(75, 13)
        Me.Label78.TabIndex = 267
        Me.Label78.Text = "Policy Number"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.Black
        Me.Label57.Location = New System.Drawing.Point(140, 133)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(122, 13)
        Me.Label57.TabIndex = 242
        Me.Label57.Text = "Policy Holder First Name"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.BackColor = System.Drawing.Color.Transparent
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.Black
        Me.Label73.Location = New System.Drawing.Point(290, 135)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(19, 13)
        Me.Label73.TabIndex = 251
        Me.Label73.Text = "MI"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(18, 172)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(110, 13)
        Me.Label40.TabIndex = 245
        Me.Label40.Text = "Policy Holder Address"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.BackColor = System.Drawing.Color.Transparent
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.ForeColor = System.Drawing.Color.Black
        Me.Label72.Location = New System.Drawing.Point(402, 175)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(32, 13)
        Me.Label72.TabIndex = 259
        Me.Label72.Text = "State"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.BackColor = System.Drawing.Color.Transparent
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.ForeColor = System.Drawing.Color.Black
        Me.Label71.Location = New System.Drawing.Point(503, 175)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(50, 13)
        Me.Label71.TabIndex = 258
        Me.Label71.Text = "Zip Code"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.BackColor = System.Drawing.Color.Transparent
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.Black
        Me.Label74.Location = New System.Drawing.Point(365, 135)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(123, 13)
        Me.Label74.TabIndex = 253
        Me.Label74.Text = "Policy Holder Last Name"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.BackColor = System.Drawing.Color.Transparent
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.ForeColor = System.Drawing.Color.Black
        Me.Label70.Location = New System.Drawing.Point(230, 175)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(24, 13)
        Me.Label70.TabIndex = 257
        Me.Label70.Text = "City"
        '
        'txtNF2
        '
        Me.txtNF2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNF2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNF2.ForeColor = System.Drawing.Color.Black
        Me.txtNF2.Location = New System.Drawing.Point(646, 65)
        Me.txtNF2.Name = "txtNF2"
        Me.txtNF2.ReadOnly = True
        Me.txtNF2.Size = New System.Drawing.Size(89, 20)
        Me.txtNF2.TabIndex = 8
        Me.txtNF2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkNF2
        '
        Me.chkNF2.AutoSize = True
        Me.chkNF2.BackColor = System.Drawing.Color.Transparent
        Me.chkNF2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNF2.Location = New System.Drawing.Point(629, 68)
        Me.chkNF2.Name = "chkNF2"
        Me.chkNF2.Size = New System.Drawing.Size(15, 14)
        Me.chkNF2.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.chkNF2, "NF2")
        Me.chkNF2.UseVisualStyleBackColor = False
        '
        'ComboBoxReferringDoctor
        '
        Me.ComboBoxReferringDoctor.AccessibleDescription = "1"
        Me.ComboBoxReferringDoctor.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxReferringDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxReferringDoctor.Enabled = False
        Me.ComboBoxReferringDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxReferringDoctor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxReferringDoctor.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxReferringDoctor.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxReferringDoctor, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxReferringDoctor, -18)
        Me.ComboBoxReferringDoctor.Location = New System.Drawing.Point(251, 65)
        Me.ComboBoxReferringDoctor.Name = "ComboBoxReferringDoctor"
        Me.ComboBoxReferringDoctor.Size = New System.Drawing.Size(344, 21)
        Me.ComboBoxReferringDoctor.Sorted = True
        Me.ComboBoxReferringDoctor.TabIndex = 5
        '
        'Label102
        '
        Me.Label102.BackColor = System.Drawing.Color.Transparent
        Me.Label102.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label102.ForeColor = System.Drawing.Color.Black
        Me.Label102.Location = New System.Drawing.Point(603, 68)
        Me.Label102.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(27, 13)
        Me.Label102.TabIndex = 330
        Me.Label102.Text = "NF2"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.chkPoliceReportReceived)
        Me.Panel4.Controls.Add(Me.chkInitialReportReceived)
        Me.Panel4.Enabled = False
        Me.Panel4.Location = New System.Drawing.Point(636, 11)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(110, 47)
        Me.Panel4.TabIndex = 335
        '
        'chkPoliceReportReceived
        '
        Me.chkPoliceReportReceived.AccessibleDescription = "1"
        Me.chkPoliceReportReceived.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPoliceReportReceived.AutoCheck = False
        Me.chkPoliceReportReceived.AutoSize = True
        Me.chkPoliceReportReceived.BackColor = System.Drawing.Color.Transparent
        Me.chkPoliceReportReceived.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ErrorProvider1.SetIconAlignment(Me.chkPoliceReportReceived, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.chkPoliceReportReceived.Location = New System.Drawing.Point(9, 28)
        Me.chkPoliceReportReceived.Name = "chkPoliceReportReceived"
        Me.chkPoliceReportReceived.Size = New System.Drawing.Size(90, 17)
        Me.chkPoliceReportReceived.TabIndex = 7
        Me.chkPoliceReportReceived.Text = "Police Report"
        Me.ToolTip1.SetToolTip(Me.chkPoliceReportReceived, "Police Report Received")
        Me.chkPoliceReportReceived.UseVisualStyleBackColor = False
        '
        'chkInitialReportReceived
        '
        Me.chkInitialReportReceived.AccessibleDescription = "1"
        Me.chkInitialReportReceived.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkInitialReportReceived.AutoCheck = False
        Me.chkInitialReportReceived.AutoSize = True
        Me.chkInitialReportReceived.BackColor = System.Drawing.Color.Transparent
        Me.chkInitialReportReceived.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkInitialReportReceived.FlatAppearance.BorderSize = 0
        Me.chkInitialReportReceived.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.chkInitialReportReceived.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.chkInitialReportReceived.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconAlignment(Me.chkInitialReportReceived, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.chkInitialReportReceived.Location = New System.Drawing.Point(14, 2)
        Me.chkInitialReportReceived.Name = "chkInitialReportReceived"
        Me.chkInitialReportReceived.Size = New System.Drawing.Size(85, 17)
        Me.chkInitialReportReceived.TabIndex = 6
        Me.chkInitialReportReceived.Text = "Initial Report"
        Me.ToolTip1.SetToolTip(Me.chkInitialReportReceived, "Initial Report Received")
        Me.chkInitialReportReceived.UseVisualStyleBackColor = False
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.BackColor = System.Drawing.Color.Transparent
        Me.Label106.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.ForeColor = System.Drawing.Color.Black
        Me.Label106.Location = New System.Drawing.Point(248, 9)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(76, 13)
        Me.Label106.TabIndex = 332
        Me.Label106.Text = "Vehicle Owner"
        '
        'txtVehicleOwner
        '
        Me.txtVehicleOwner.AccessibleDescription = ""
        Me.txtVehicleOwner.AccessibleName = ""
        Me.txtVehicleOwner.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtVehicleOwner.Enabled = False
        Me.txtVehicleOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleOwner.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconAlignment(Me.txtVehicleOwner, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.txtVehicleOwner, -18)
        Me.txtVehicleOwner.Location = New System.Drawing.Point(251, 25)
        Me.txtVehicleOwner.MaxLength = 20
        Me.txtVehicleOwner.Name = "txtVehicleOwner"
        Me.txtVehicleOwner.Size = New System.Drawing.Size(380, 20)
        Me.txtVehicleOwner.TabIndex = 331
        '
        'PictureBoxRefCompany
        '
        Me.PictureBoxRefCompany.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxRefCompany.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxRefCompany.Image = CType(resources.GetObject("PictureBoxRefCompany.Image"), System.Drawing.Image)
        Me.PictureBoxRefCompany.Location = New System.Drawing.Point(230, 50)
        Me.PictureBoxRefCompany.Name = "PictureBoxRefCompany"
        Me.PictureBoxRefCompany.Size = New System.Drawing.Size(11, 10)
        Me.PictureBoxRefCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxRefCompany.TabIndex = 299
        Me.PictureBoxRefCompany.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBoxRefCompany, "Default Referring Doctor will be used on Add Patient's Procedure Dialog")
        '
        'ComboBoxTransportationCompanyID
        '
        Me.ComboBoxTransportationCompanyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTransportationCompanyID.Enabled = False
        Me.ComboBoxTransportationCompanyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxTransportationCompanyID.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTransportationCompanyID.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxTransportationCompanyID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxTransportationCompanyID, -18)
        Me.ComboBoxTransportationCompanyID.Location = New System.Drawing.Point(394, 103)
        Me.ComboBoxTransportationCompanyID.Name = "ComboBoxTransportationCompanyID"
        Me.ComboBoxTransportationCompanyID.Size = New System.Drawing.Size(153, 21)
        Me.ComboBoxTransportationCompanyID.TabIndex = 3
        '
        'PictureBoxRefDoctor
        '
        Me.PictureBoxRefDoctor.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxRefDoctor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxRefDoctor.Image = CType(resources.GetObject("PictureBoxRefDoctor.Image"), System.Drawing.Image)
        Me.PictureBoxRefDoctor.Location = New System.Drawing.Point(368, 50)
        Me.PictureBoxRefDoctor.Name = "PictureBoxRefDoctor"
        Me.PictureBoxRefDoctor.Size = New System.Drawing.Size(11, 10)
        Me.PictureBoxRefDoctor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxRefDoctor.TabIndex = 295
        Me.PictureBoxRefDoctor.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBoxRefDoctor, "Default Referring Doctor will be used on Add Patient's Procedure Dialog")
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(395, 87)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(122, 13)
        Me.Label35.TabIndex = 198
        Me.Label35.Text = "Transportation Company"
        '
        'cboBillingCompany
        '
        Me.cboBillingCompany.AccessibleDescription = "1"
        Me.cboBillingCompany.AccessibleName = "1"
        Me.cboBillingCompany.BackColor = System.Drawing.SystemColors.Window
        Me.cboBillingCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillingCompany.Enabled = False
        Me.cboBillingCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBillingCompany.ForeColor = System.Drawing.Color.Black
        Me.cboBillingCompany.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.cboBillingCompany, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.cboBillingCompany, -18)
        Me.cboBillingCompany.Location = New System.Drawing.Point(556, 103)
        Me.cboBillingCompany.Name = "cboBillingCompany"
        Me.cboBillingCompany.Size = New System.Drawing.Size(179, 21)
        Me.cboBillingCompany.TabIndex = 3
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.BackColor = System.Drawing.Color.Transparent
        Me.Label86.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.ForeColor = System.Drawing.Color.Black
        Me.Label86.Location = New System.Drawing.Point(553, 87)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(81, 13)
        Me.Label86.TabIndex = 258
        Me.Label86.Text = "Billing Company"
        '
        'ComboBoxReferringCompanyID
        '
        Me.ComboBoxReferringCompanyID.AccessibleDescription = "1"
        Me.ComboBoxReferringCompanyID.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxReferringCompanyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxReferringCompanyID.DropDownWidth = 320
        Me.ComboBoxReferringCompanyID.Enabled = False
        Me.ComboBoxReferringCompanyID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxReferringCompanyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxReferringCompanyID.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxReferringCompanyID.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxReferringCompanyID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxReferringCompanyID, -18)
        Me.ComboBoxReferringCompanyID.Location = New System.Drawing.Point(21, 65)
        Me.ComboBoxReferringCompanyID.Name = "ComboBoxReferringCompanyID"
        Me.ComboBoxReferringCompanyID.Size = New System.Drawing.Size(225, 21)
        Me.ComboBoxReferringCompanyID.TabIndex = 4
        '
        'ComboBoxPatientTypeID
        '
        Me.ComboBoxPatientTypeID.AccessibleDescription = "1"
        Me.ComboBoxPatientTypeID.AccessibleName = "1"
        Me.ComboBoxPatientTypeID.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxPatientTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPatientTypeID.Enabled = False
        Me.ComboBoxPatientTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxPatientTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxPatientTypeID.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxPatientTypeID.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxPatientTypeID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxPatientTypeID, -18)
        Me.ComboBoxPatientTypeID.Location = New System.Drawing.Point(151, 25)
        Me.ComboBoxPatientTypeID.Name = "ComboBoxPatientTypeID"
        Me.ComboBoxPatientTypeID.Size = New System.Drawing.Size(90, 21)
        Me.ComboBoxPatientTypeID.TabIndex = 1
        '
        'ComboBoxInjuryID
        '
        Me.ComboBoxInjuryID.AccessibleDescription = "1"
        Me.ComboBoxInjuryID.AccessibleName = "1"
        Me.ComboBoxInjuryID.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxInjuryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxInjuryID.Enabled = False
        Me.ComboBoxInjuryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxInjuryID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxInjuryID.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxInjuryID.FormattingEnabled = True
        Me.ErrorProvider1.SetIconAlignment(Me.ComboBoxInjuryID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.ErrorProvider1.SetIconPadding(Me.ComboBoxInjuryID, -18)
        Me.ComboBoxInjuryID.Location = New System.Drawing.Point(21, 25)
        Me.ComboBoxInjuryID.Name = "ComboBoxInjuryID"
        Me.ComboBoxInjuryID.Size = New System.Drawing.Size(109, 21)
        Me.ComboBoxInjuryID.TabIndex = 0
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.Black
        Me.Label63.Location = New System.Drawing.Point(248, 50)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(122, 13)
        Me.Label63.TabIndex = 222
        Me.Label63.Text = "Default Referring Doctor"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(148, 9)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(94, 13)
        Me.Label23.TabIndex = 178
        Me.Label23.Text = "Driver/Pass/Other"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(21, 11)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(32, 13)
        Me.Label22.TabIndex = 176
        Me.Label22.Text = "Injury"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.BackColor = System.Drawing.Color.Transparent
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.Black
        Me.Label62.Location = New System.Drawing.Point(21, 88)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(89, 13)
        Me.Label62.TabIndex = 220
        Me.Label62.Text = "Patient's Attorney"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(21, 50)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(97, 13)
        Me.Label37.TabIndex = 200
        Me.Label37.Text = "Referring Company"
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(340, 102)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 21)
        Me.Button1.TabIndex = 339
        Me.ToolTip1.SetToolTip(Me.Button1, "Show Insurance Maintenance")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cboPatientAttorney
        '
        Me.cboPatientAttorney.BackColor = System.Drawing.Color.White
        Me.cboPatientAttorney.FormattingEnabled = True
        Me.cboPatientAttorney.LimitToList = True
        Me.cboPatientAttorney.Location = New System.Drawing.Point(21, 103)
        Me.cboPatientAttorney.MaxNumericValue = 1.7976931348623157E+308R
        Me.cboPatientAttorney.Name = "cboPatientAttorney"
        Me.cboPatientAttorney.NoDecimals = False
        Me.cboPatientAttorney.NumericOnly = False
        Me.cboPatientAttorney.ReadOnlyCombo = False
        Me.cboPatientAttorney.Size = New System.Drawing.Size(317, 21)
        Me.cboPatientAttorney.TabIndex = 341
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Transparent
        Me.TabPage3.Controls.Add(Me.ButtonRotatePDF)
        Me.TabPage3.Controls.Add(Me.PanelDocumentWait)
        Me.TabPage3.Controls.Add(Me.RichTextBox1)
        Me.TabPage3.Controls.Add(Me.pdfViewer)
        Me.TabPage3.Controls.Add(Me.ButtonAutosizeDocuments)
        Me.TabPage3.Controls.Add(Me.ListViewDocs)
        Me.TabPage3.Controls.Add(Me.LabelDocument)
        Me.TabPage3.Controls.Add(Me.Label46)
        Me.TabPage3.Controls.Add(Me.ToolStrip2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(0, 6, 6, 0)
        Me.TabPage3.Size = New System.Drawing.Size(763, 506)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Documents"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ButtonRotatePDF
        '
        Me.ButtonRotatePDF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRotatePDF.ContextMenuStrip = Me.MenuPDFRotate
        Me.ButtonRotatePDF.FlatAppearance.BorderSize = 0
        Me.ButtonRotatePDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRotatePDF.Image = CType(resources.GetObject("ButtonRotatePDF.Image"), System.Drawing.Image)
        Me.ButtonRotatePDF.Location = New System.Drawing.Point(729, 4)
        Me.ButtonRotatePDF.Name = "ButtonRotatePDF"
        Me.ButtonRotatePDF.Size = New System.Drawing.Size(24, 27)
        Me.ButtonRotatePDF.TabIndex = 380
        Me.ButtonRotatePDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.ButtonRotatePDF, "Rotate Document")
        Me.ButtonRotatePDF.UseVisualStyleBackColor = True
        '
        'MenuPDFRotate
        '
        Me.MenuPDFRotate.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem13, Me.ToolStripMenuItem14, Me.ToolStripMenuItem15, Me.ToolStripMenuItem16})
        Me.MenuPDFRotate.Name = "MenuPDFRotate"
        Me.MenuPDFRotate.ShowImageMargin = False
        Me.MenuPDFRotate.Size = New System.Drawing.Size(73, 92)
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripMenuItem13.Text = "0°"
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripMenuItem14.Text = "90°"
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        Me.ToolStripMenuItem15.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripMenuItem15.Text = "180°"
        '
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        Me.ToolStripMenuItem16.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripMenuItem16.Text = "270°"
        '
        'PanelDocumentWait
        '
        Me.PanelDocumentWait.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelDocumentWait.BackColor = System.Drawing.Color.White
        Me.PanelDocumentWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDocumentWait.Controls.Add(Me.Label124)
        Me.PanelDocumentWait.Controls.Add(Me.PictureBox6)
        Me.PanelDocumentWait.Controls.Add(Me.PictureBox7)
        Me.PanelDocumentWait.Controls.Add(Me.Label123)
        Me.PanelDocumentWait.Location = New System.Drawing.Point(455, 220)
        Me.PanelDocumentWait.Name = "PanelDocumentWait"
        Me.PanelDocumentWait.Size = New System.Drawing.Size(216, 51)
        Me.PanelDocumentWait.TabIndex = 375
        Me.PanelDocumentWait.Visible = False
        '
        'Label124
        '
        Me.Label124.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label124.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label124.ForeColor = System.Drawing.Color.White
        Me.Label124.Location = New System.Drawing.Point(-1, 21)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(216, 24)
        Me.Label124.TabIndex = 3
        Me.Label124.Text = "document loading speed depends " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "on document size and network speed." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label124.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(26, 21)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox6.TabIndex = 2
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PictureBox7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox7.Location = New System.Drawing.Point(0, 21)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(214, 28)
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
        Me.RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.Location = New System.Drawing.Point(402, 27)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(10)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(353, 450)
        Me.RichTextBox1.TabIndex = 373
        Me.RichTextBox1.Text = ""
        '
        'pdfViewer
        '
        Me.pdfViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pdfViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pdfViewer.Location = New System.Drawing.Point(402, 27)
        Me.pdfViewer.Name = "pdfViewer"
        Me.pdfViewer.ShowBookmarks = False
        Me.pdfViewer.ShowToolbar = False
        Me.pdfViewer.Size = New System.Drawing.Size(353, 450)
        Me.pdfViewer.TabIndex = 368
        Me.pdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitBest
        '
        'ButtonAutosizeDocuments
        '
        Me.ButtonAutosizeDocuments.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAutosizeDocuments.FlatAppearance.BorderSize = 0
        Me.ButtonAutosizeDocuments.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeDocuments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeDocuments.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAutosizeDocuments.Image = CType(resources.GetObject("ButtonAutosizeDocuments.Image"), System.Drawing.Image)
        Me.ButtonAutosizeDocuments.Location = New System.Drawing.Point(380, 9)
        Me.ButtonAutosizeDocuments.Name = "ButtonAutosizeDocuments"
        Me.ButtonAutosizeDocuments.Size = New System.Drawing.Size(16, 15)
        Me.ButtonAutosizeDocuments.TabIndex = 367
        Me.ToolTip1.SetToolTip(Me.ButtonAutosizeDocuments, "Autosize Spread Columns")
        Me.ButtonAutosizeDocuments.UseVisualStyleBackColor = True
        '
        'ListViewDocs
        '
        Me.ListViewDocs.AllowColumnReorder = True
        Me.ListViewDocs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListViewDocs.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewDocs.CheckBoxes = True
        Me.ListViewDocs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader1, Me.ColumnHeader47})
        Me.ListViewDocs.ContextMenuStrip = Me.ContextMenuStripDocuments
        Me.ListViewDocs.FullRowSelect = True
        Me.ListViewDocs.GridLines = True
        Me.ListViewDocs.HideSelection = False
        Me.ListViewDocs.LargeImageList = Me.ImageList1
        Me.ListViewDocs.Location = New System.Drawing.Point(21, 26)
        Me.ListViewDocs.MultiSelect = False
        Me.ListViewDocs.Name = "ListViewDocs"
        Me.ListViewDocs.Size = New System.Drawing.Size(375, 452)
        Me.ListViewDocs.SmallImageList = Me.ImageList1
        Me.ListViewDocs.TabIndex = 2
        Me.ListViewDocs.UseCompatibleStateImageBehavior = False
        Me.ListViewDocs.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Document Name"
        Me.ColumnHeader2.Width = 118
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Date"
        Me.ColumnHeader1.Width = 108
        '
        'ColumnHeader47
        '
        Me.ColumnHeader47.Text = "By"
        Me.ColumnHeader47.Width = 125
        '
        'ContextMenuStripDocuments
        '
        Me.ContextMenuStripDocuments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemRenameDocument, Me.ToolStripMenuItemRenameDocumentBar, Me.ToolStripMenuItemDeleteDocument})
        Me.ContextMenuStripDocuments.Name = "ContextMenuStrip2"
        Me.ContextMenuStripDocuments.Size = New System.Drawing.Size(177, 54)
        '
        'ToolStripMenuItemRenameDocument
        '
        Me.ToolStripMenuItemRenameDocument.Image = CType(resources.GetObject("ToolStripMenuItemRenameDocument.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemRenameDocument.Name = "ToolStripMenuItemRenameDocument"
        Me.ToolStripMenuItemRenameDocument.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItemRenameDocument.Text = "Rename Document"
        '
        'ToolStripMenuItemRenameDocumentBar
        '
        Me.ToolStripMenuItemRenameDocumentBar.Name = "ToolStripMenuItemRenameDocumentBar"
        Me.ToolStripMenuItemRenameDocumentBar.Size = New System.Drawing.Size(173, 6)
        '
        'ToolStripMenuItemDeleteDocument
        '
        Me.ToolStripMenuItemDeleteDocument.Image = CType(resources.GetObject("ToolStripMenuItemDeleteDocument.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemDeleteDocument.Name = "ToolStripMenuItemDeleteDocument"
        Me.ToolStripMenuItemDeleteDocument.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItemDeleteDocument.Text = "Delete Document"
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
        'LabelDocument
        '
        Me.LabelDocument.AutoSize = True
        Me.LabelDocument.BackColor = System.Drawing.Color.Transparent
        Me.LabelDocument.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDocument.ForeColor = System.Drawing.Color.Black
        Me.LabelDocument.Location = New System.Drawing.Point(398, 11)
        Me.LabelDocument.Name = "LabelDocument"
        Me.LabelDocument.Size = New System.Drawing.Size(97, 13)
        Me.LabelDocument.TabIndex = 254
        Me.LabelDocument.Text = "Document Preview"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(21, 11)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(61, 13)
        Me.Label46.TabIndex = 253
        Me.Label46.Text = "Documents"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripSeparator3, Me.ToolStripButtonEmail, Me.ButtonScannDocument, Me.ToolStripButton1, Me.ToolStripButtonSaveAs, Me.lblFileSize})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 481)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip2.Size = New System.Drawing.Size(757, 25)
        Me.ToolStrip2.TabIndex = 130
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripButton7.Text = "Print Preview"
        Me.ToolStripButton7.ToolTipText = "Print Document"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripButton2.Text = "Print"
        Me.ToolStripButton2.ToolTipText = "Print Document"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButton3.Text = "Show"
        Me.ToolStripButton3.ToolTipText = "Show Document"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonEmail
        '
        Me.ToolStripButtonEmail.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonEmail.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButtonEmail.Image = CType(resources.GetObject("ToolStripButtonEmail.Image"), System.Drawing.Image)
        Me.ToolStripButtonEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonEmail.Name = "ToolStripButtonEmail"
        Me.ToolStripButtonEmail.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButtonEmail.Text = "Email"
        Me.ToolStripButtonEmail.ToolTipText = "Email Selected/Checked Document(s)"
        '
        'ButtonScannDocument
        '
        Me.ButtonScannDocument.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuScan, Me.ToolStripSeparator10, Me.ButtonDeleteDocument})
        Me.ButtonScannDocument.Image = CType(resources.GetObject("ButtonScannDocument.Image"), System.Drawing.Image)
        Me.ButtonScannDocument.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonScannDocument.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonScannDocument.Margin = New System.Windows.Forms.Padding(15, 1, 0, 2)
        Me.ButtonScannDocument.Name = "ButtonScannDocument"
        Me.ButtonScannDocument.Size = New System.Drawing.Size(92, 22)
        Me.ButtonScannDocument.Text = "Document"
        '
        'ToolStripMenuScan
        '
        Me.ToolStripMenuScan.BackColor = System.Drawing.Color.White
        Me.ToolStripMenuScan.Image = CType(resources.GetObject("ToolStripMenuScan.Image"), System.Drawing.Image)
        Me.ToolStripMenuScan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuScan.Name = "ToolStripMenuScan"
        Me.ToolStripMenuScan.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always
        Me.ToolStripMenuScan.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.ToolStripMenuScan.Size = New System.Drawing.Size(237, 34)
        Me.ToolStripMenuScan.Tag = ""
        Me.ToolStripMenuScan.Text = "Scan / Import PDF Document"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.AutoSize = False
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(234, 6)
        '
        'ButtonDeleteDocument
        '
        Me.ButtonDeleteDocument.BackColor = System.Drawing.Color.White
        Me.ButtonDeleteDocument.ForeColor = System.Drawing.Color.Red
        Me.ButtonDeleteDocument.Image = CType(resources.GetObject("ButtonDeleteDocument.Image"), System.Drawing.Image)
        Me.ButtonDeleteDocument.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonDeleteDocument.Name = "ButtonDeleteDocument"
        Me.ButtonDeleteDocument.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always
        Me.ButtonDeleteDocument.Padding = New System.Windows.Forms.Padding(0)
        Me.ButtonDeleteDocument.Size = New System.Drawing.Size(237, 28)
        Me.ButtonDeleteDocument.Text = "Delete Document"
        Me.ButtonDeleteDocument.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonDeleteDocument.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripButton1.Text = "Fax"
        Me.ToolStripButton1.ToolTipText = "Fax Selected/Checked Document(s)"
        '
        'ToolStripButtonSaveAs
        '
        Me.ToolStripButtonSaveAs.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonSaveAs.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButtonSaveAs.Image = CType(resources.GetObject("ToolStripButtonSaveAs.Image"), System.Drawing.Image)
        Me.ToolStripButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSaveAs.Name = "ToolStripButtonSaveAs"
        Me.ToolStripButtonSaveAs.Size = New System.Drawing.Size(67, 22)
        Me.ToolStripButtonSaveAs.Text = "Save As"
        Me.ToolStripButtonSaveAs.ToolTipText = "Save Document As"
        '
        'lblFileSize
        '
        Me.lblFileSize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblFileSize.Name = "lblFileSize"
        Me.lblFileSize.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.lblFileSize.Size = New System.Drawing.Size(30, 22)
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.Transparent
        Me.TabPage5.Controls.Add(Me.ButtonAutosizeComments)
        Me.TabPage5.Controls.Add(Me.ToolStrip3)
        Me.TabPage5.Controls.Add(Me.Label43)
        Me.TabPage5.Controls.Add(Me.ListViewComments)
        Me.TabPage5.Controls.Add(Me.Label45)
        Me.TabPage5.Controls.Add(Me.TextBoxCommentView)
        Me.TabPage5.Location = New System.Drawing.Point(4, 23)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(763, 506)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Comments"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'ButtonAutosizeComments
        '
        Me.ButtonAutosizeComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAutosizeComments.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAutosizeComments.FlatAppearance.BorderSize = 0
        Me.ButtonAutosizeComments.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeComments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeComments.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAutosizeComments.Image = CType(resources.GetObject("ButtonAutosizeComments.Image"), System.Drawing.Image)
        Me.ButtonAutosizeComments.Location = New System.Drawing.Point(731, 8)
        Me.ButtonAutosizeComments.Name = "ButtonAutosizeComments"
        Me.ButtonAutosizeComments.Size = New System.Drawing.Size(16, 15)
        Me.ButtonAutosizeComments.TabIndex = 366
        Me.ToolTip1.SetToolTip(Me.ButtonAutosizeComments, "Autosize Spread Columns")
        Me.ButtonAutosizeComments.UseVisualStyleBackColor = True
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip3.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonAddComments})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 481)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip3.Size = New System.Drawing.Size(763, 25)
        Me.ToolStrip3.TabIndex = 130
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ButtonAddComments
        '
        Me.ButtonAddComments.Image = CType(resources.GetObject("ButtonAddComments.Image"), System.Drawing.Image)
        Me.ButtonAddComments.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonAddComments.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonAddComments.Margin = New System.Windows.Forms.Padding(15, 1, 0, 2)
        Me.ButtonAddComments.Name = "ButtonAddComments"
        Me.ButtonAddComments.Size = New System.Drawing.Size(133, 22)
        Me.ButtonAddComments.Text = "Add New Comment"
        '
        'Label43
        '
        Me.Label43.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(21, 286)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(51, 13)
        Me.Label43.TabIndex = 179
        Me.Label43.Text = "Comment"
        '
        'ListViewComments
        '
        Me.ListViewComments.AllowColumnReorder = True
        Me.ListViewComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewComments.BackColor = System.Drawing.Color.White
        Me.ListViewComments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader19})
        Me.ListViewComments.FullRowSelect = True
        Me.ListViewComments.GridLines = True
        Me.ListViewComments.HideSelection = False
        Me.ListViewComments.LargeImageList = Me.ImageList1
        Me.ListViewComments.Location = New System.Drawing.Point(21, 26)
        Me.ListViewComments.MultiSelect = False
        Me.ListViewComments.Name = "ListViewComments"
        Me.ListViewComments.Size = New System.Drawing.Size(726, 257)
        Me.ListViewComments.SmallImageList = Me.ImageList1
        Me.ListViewComments.TabIndex = 1
        Me.ListViewComments.UseCompatibleStateImageBehavior = False
        Me.ListViewComments.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Date"
        Me.ColumnHeader16.Width = 112
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Comment"
        Me.ColumnHeader17.Width = 431
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Created By"
        Me.ColumnHeader19.Width = 112
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Black
        Me.Label45.Location = New System.Drawing.Point(21, 11)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(92, 13)
        Me.Label45.TabIndex = 176
        Me.Label45.Text = "Patient Comments"
        '
        'TextBoxCommentView
        '
        Me.TextBoxCommentView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCommentView.BackColor = System.Drawing.Color.White
        Me.TextBoxCommentView.Location = New System.Drawing.Point(19, 302)
        Me.TextBoxCommentView.Multiline = True
        Me.TextBoxCommentView.Name = "TextBoxCommentView"
        Me.TextBoxCommentView.ReadOnly = True
        Me.TextBoxCommentView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxCommentView.Size = New System.Drawing.Size(728, 169)
        Me.TextBoxCommentView.TabIndex = 2
        '
        'TabPageReadings
        '
        Me.TabPageReadings.BackColor = System.Drawing.Color.Transparent
        Me.TabPageReadings.Controls.Add(Me.ButtonReadingsAutoSize)
        Me.TabPageReadings.Controls.Add(Me.TextBoxReading)
        Me.TabPageReadings.Controls.Add(Me.ToolStripFontSize)
        Me.TabPageReadings.Controls.Add(Me.ToolStrip4)
        Me.TabPageReadings.Controls.Add(Me.Label87)
        Me.TabPageReadings.Controls.Add(Me.ListViewReadings)
        Me.TabPageReadings.Location = New System.Drawing.Point(4, 23)
        Me.TabPageReadings.Name = "TabPageReadings"
        Me.TabPageReadings.Size = New System.Drawing.Size(763, 506)
        Me.TabPageReadings.TabIndex = 7
        Me.TabPageReadings.Text = "Readings"
        Me.TabPageReadings.UseVisualStyleBackColor = True
        '
        'ButtonReadingsAutoSize
        '
        Me.ButtonReadingsAutoSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonReadingsAutoSize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonReadingsAutoSize.FlatAppearance.BorderSize = 0
        Me.ButtonReadingsAutoSize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonReadingsAutoSize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonReadingsAutoSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonReadingsAutoSize.Image = CType(resources.GetObject("ButtonReadingsAutoSize.Image"), System.Drawing.Image)
        Me.ButtonReadingsAutoSize.Location = New System.Drawing.Point(731, 8)
        Me.ButtonReadingsAutoSize.Name = "ButtonReadingsAutoSize"
        Me.ButtonReadingsAutoSize.Size = New System.Drawing.Size(16, 15)
        Me.ButtonReadingsAutoSize.TabIndex = 365
        Me.ToolTip1.SetToolTip(Me.ButtonReadingsAutoSize, "Autosize Spread Columns")
        Me.ButtonReadingsAutoSize.UseVisualStyleBackColor = True
        '
        'TextBoxReading
        '
        Me.TextBoxReading.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxReading.BackColor = System.Drawing.Color.White
        Me.TextBoxReading.Location = New System.Drawing.Point(21, 234)
        Me.TextBoxReading.Multiline = True
        Me.TextBoxReading.Name = "TextBoxReading"
        Me.TextBoxReading.ReadOnly = True
        Me.TextBoxReading.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxReading.Size = New System.Drawing.Size(726, 237)
        Me.TextBoxReading.TabIndex = 181
        Me.TextBoxReading.Tag = "setup motorola blue toth device"
        '
        'ToolStripFontSize
        '
        Me.ToolStripFontSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStripFontSize.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripFontSize.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripFontSize.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripFontSize.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton5, Me.ToolStripSeparator12, Me.ToolStripButton6})
        Me.ToolStripFontSize.Location = New System.Drawing.Point(687, 210)
        Me.ToolStripFontSize.Name = "ToolStripFontSize"
        Me.ToolStripFontSize.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStripFontSize.Size = New System.Drawing.Size(55, 25)
        Me.ToolStripFontSize.TabIndex = 364
        Me.ToolStripFontSize.Text = "ToolStrip3"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.ToolTipText = "Font Increase"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.ToolTipText = "Font Decrease"
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip4.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdAddReading, Me.ToolStripSeparator5, Me.ToolStripButton4, Me.ToolStripButtonUnlockReading})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 481)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip4.Size = New System.Drawing.Size(763, 25)
        Me.ToolStrip4.TabIndex = 182
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'cmdAddReading
        '
        Me.cmdAddReading.Image = CType(resources.GetObject("cmdAddReading.Image"), System.Drawing.Image)
        Me.cmdAddReading.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdAddReading.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAddReading.Margin = New System.Windows.Forms.Padding(15, 1, 0, 2)
        Me.cmdAddReading.Name = "cmdAddReading"
        Me.cmdAddReading.Size = New System.Drawing.Size(144, 22)
        Me.cmdAddReading.Text = "Add / Update Reading"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(155, 22)
        Me.ToolStripButton4.Text = "Produce Reading Report"
        '
        'ToolStripButtonUnlockReading
        '
        Me.ToolStripButtonUnlockReading.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonUnlockReading.Image = CType(resources.GetObject("ToolStripButtonUnlockReading.Image"), System.Drawing.Image)
        Me.ToolStripButtonUnlockReading.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonUnlockReading.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.ToolStripButtonUnlockReading.Name = "ToolStripButtonUnlockReading"
        Me.ToolStripButtonUnlockReading.Size = New System.Drawing.Size(110, 22)
        Me.ToolStripButtonUnlockReading.Text = "Unlock Reading"
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.BackColor = System.Drawing.Color.Transparent
        Me.Label87.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.ForeColor = System.Drawing.Color.Black
        Me.Label87.Location = New System.Drawing.Point(21, 11)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(95, 13)
        Me.Label87.TabIndex = 180
        Me.Label87.Text = "Patient's Readings"
        '
        'ListViewReadings
        '
        Me.ListViewReadings.AllowColumnReorder = True
        Me.ListViewReadings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewReadings.BackColor = System.Drawing.Color.White
        Me.ListViewReadings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewReadings.CheckBoxes = True
        Me.ListViewReadings.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader24, Me.ColumnHeader23, Me.ColumnHeader25, Me.ColumnHeader58, Me.ColumnHeader26})
        Me.ListViewReadings.ContextMenuStrip = Me.ContextMenuStripReadings
        Me.ListViewReadings.FullRowSelect = True
        Me.ListViewReadings.GridLines = True
        Me.ListViewReadings.HideSelection = False
        ListViewItem1.StateImageIndex = 0
        Me.ListViewReadings.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.ListViewReadings.Location = New System.Drawing.Point(21, 26)
        Me.ListViewReadings.MultiSelect = False
        Me.ListViewReadings.Name = "ListViewReadings"
        Me.ListViewReadings.Size = New System.Drawing.Size(726, 179)
        Me.ListViewReadings.SmallImageList = Me.ImageList2
        Me.ListViewReadings.TabIndex = 179
        Me.ListViewReadings.UseCompatibleStateImageBehavior = False
        Me.ListViewReadings.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Service DT"
        Me.ColumnHeader24.Width = 101
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Procedure"
        Me.ColumnHeader23.Width = 179
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "By"
        Me.ColumnHeader25.Width = 162
        '
        'ColumnHeader58
        '
        Me.ColumnHeader58.Text = "Dictation DT"
        Me.ColumnHeader58.Width = 98
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "Reading DT"
        Me.ColumnHeader26.Width = 107
        '
        'ContextMenuStripReadings
        '
        Me.ContextMenuStripReadings.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.SelectNoneToolStripMenuItem})
        Me.ContextMenuStripReadings.Name = "ContextMenuStrip1"
        Me.ContextMenuStripReadings.Size = New System.Drawing.Size(140, 48)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Image = CType(resources.GetObject("SelectAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.SelectAllToolStripMenuItem.Text = "Check All"
        '
        'SelectNoneToolStripMenuItem
        '
        Me.SelectNoneToolStripMenuItem.Name = "SelectNoneToolStripMenuItem"
        Me.SelectNoneToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.SelectNoneToolStripMenuItem.Text = "Check None"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Changes.png")
        Me.ImageList2.Images.SetKeyName(1, "SORT1")
        Me.ImageList2.Images.SetKeyName(2, "SORT2")
        Me.ImageList2.Images.SetKeyName(3, "SORT0")
        Me.ImageList2.Images.SetKeyName(4, "PageGreen.png")
        Me.ImageList2.Images.SetKeyName(5, "PageRed.png")
        '
        'TabPageBills
        '
        Me.TabPageBills.BackColor = System.Drawing.Color.Transparent
        Me.TabPageBills.Controls.Add(Me.ButtonAutosizeBillComments)
        Me.TabPageBills.Controls.Add(Me.ButtonAutosizeReadings)
        Me.TabPageBills.Controls.Add(Me.ToolStrip8)
        Me.TabPageBills.Controls.Add(Me.Label85)
        Me.TabPageBills.Controls.Add(Me.Label84)
        Me.TabPageBills.Controls.Add(Me.ListViewBillComments)
        Me.TabPageBills.Controls.Add(Me.ListViewPayments)
        Me.TabPageBills.Controls.Add(Me.Label83)
        Me.TabPageBills.Controls.Add(Me.TreeViewBills)
        Me.TabPageBills.Location = New System.Drawing.Point(4, 23)
        Me.TabPageBills.Name = "TabPageBills"
        Me.TabPageBills.Size = New System.Drawing.Size(763, 506)
        Me.TabPageBills.TabIndex = 6
        Me.TabPageBills.Text = "Bills"
        Me.TabPageBills.UseVisualStyleBackColor = True
        '
        'ButtonAutosizeBillComments
        '
        Me.ButtonAutosizeBillComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAutosizeBillComments.FlatAppearance.BorderSize = 0
        Me.ButtonAutosizeBillComments.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeBillComments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeBillComments.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAutosizeBillComments.Image = CType(resources.GetObject("ButtonAutosizeBillComments.Image"), System.Drawing.Image)
        Me.ButtonAutosizeBillComments.Location = New System.Drawing.Point(695, 205)
        Me.ButtonAutosizeBillComments.Name = "ButtonAutosizeBillComments"
        Me.ButtonAutosizeBillComments.Size = New System.Drawing.Size(16, 15)
        Me.ButtonAutosizeBillComments.TabIndex = 367
        Me.ToolTip1.SetToolTip(Me.ButtonAutosizeBillComments, "Autosize Columns")
        Me.ButtonAutosizeBillComments.UseVisualStyleBackColor = True
        '
        'ButtonAutosizeReadings
        '
        Me.ButtonAutosizeReadings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAutosizeReadings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAutosizeReadings.FlatAppearance.BorderSize = 0
        Me.ButtonAutosizeReadings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeReadings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeReadings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAutosizeReadings.Image = CType(resources.GetObject("ButtonAutosizeReadings.Image"), System.Drawing.Image)
        Me.ButtonAutosizeReadings.Location = New System.Drawing.Point(695, 82)
        Me.ButtonAutosizeReadings.Name = "ButtonAutosizeReadings"
        Me.ButtonAutosizeReadings.Size = New System.Drawing.Size(16, 15)
        Me.ButtonAutosizeReadings.TabIndex = 366
        Me.ToolTip1.SetToolTip(Me.ButtonAutosizeReadings, "Autosize Spread Columns")
        Me.ButtonAutosizeReadings.UseVisualStyleBackColor = True
        '
        'ToolStrip8
        '
        Me.ToolStrip8.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip8.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip8.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip8.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonShowBill, Me.ShowBillsToolBarButton})
        Me.ToolStrip8.Location = New System.Drawing.Point(0, 481)
        Me.ToolStrip8.Name = "ToolStrip8"
        Me.ToolStrip8.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip8.Size = New System.Drawing.Size(763, 25)
        Me.ToolStrip8.TabIndex = 298
        Me.ToolStrip8.Text = "ToolStrip8"
        '
        'ToolStripButtonShowBill
        '
        Me.ToolStripButtonShowBill.Image = CType(resources.GetObject("ToolStripButtonShowBill.Image"), System.Drawing.Image)
        Me.ToolStripButtonShowBill.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonShowBill.Margin = New System.Windows.Forms.Padding(15, 1, 0, 2)
        Me.ToolStripButtonShowBill.Name = "ToolStripButtonShowBill"
        Me.ToolStripButtonShowBill.Size = New System.Drawing.Size(122, 22)
        Me.ToolStripButtonShowBill.Text = "Show Selected Bill"
        '
        'ShowBillsToolBarButton
        '
        Me.ShowBillsToolBarButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ShowBillsToolBarButton.Image = CType(resources.GetObject("ShowBillsToolBarButton.Image"), System.Drawing.Image)
        Me.ShowBillsToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ShowBillsToolBarButton.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.ShowBillsToolBarButton.Name = "ShowBillsToolBarButton"
        Me.ShowBillsToolBarButton.Size = New System.Drawing.Size(149, 22)
        Me.ShowBillsToolBarButton.Text = "Show Bill Management"
        Me.ShowBillsToolBarButton.ToolTipText = "Show Patient Bills in Bills Management"
        '
        'Label85
        '
        Me.Label85.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label85.AutoSize = True
        Me.Label85.BackColor = System.Drawing.Color.Transparent
        Me.Label85.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.ForeColor = System.Drawing.Color.Black
        Me.Label85.Location = New System.Drawing.Point(19, 206)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(72, 13)
        Me.Label85.TabIndex = 297
        Me.Label85.Text = "Bill Comments"
        '
        'Label84
        '
        Me.Label84.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label84.AutoSize = True
        Me.Label84.BackColor = System.Drawing.Color.Transparent
        Me.Label84.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.ForeColor = System.Drawing.Color.Black
        Me.Label84.Location = New System.Drawing.Point(19, 83)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(69, 13)
        Me.Label84.TabIndex = 296
        Me.Label84.Text = "Bill Payments"
        '
        'ListViewBillComments
        '
        Me.ListViewBillComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewBillComments.BackColor = System.Drawing.Color.White
        Me.ListViewBillComments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10, Me.ColumnHeader22, Me.ColumnHeader15})
        Me.ListViewBillComments.FullRowSelect = True
        Me.ListViewBillComments.GridLines = True
        Me.ListViewBillComments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewBillComments.HideSelection = False
        Me.ListViewBillComments.Location = New System.Drawing.Point(21, 222)
        Me.ListViewBillComments.MultiSelect = False
        Me.ListViewBillComments.Name = "ListViewBillComments"
        Me.ListViewBillComments.Size = New System.Drawing.Size(690, 249)
        Me.ListViewBillComments.TabIndex = 295
        Me.ListViewBillComments.UseCompatibleStateImageBehavior = False
        Me.ListViewBillComments.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Date"
        Me.ColumnHeader10.Width = 47
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Inserted By"
        Me.ColumnHeader22.Width = 113
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Comment"
        Me.ColumnHeader15.Width = 479
        '
        'ListViewPayments
        '
        Me.ListViewPayments.AllowColumnReorder = True
        Me.ListViewPayments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewPayments.BackColor = System.Drawing.Color.White
        Me.ListViewPayments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.BillID, Me.PaymentDT, Me.PaymentType, Me.CheckNumber, Me.Amount, Me.Note})
        Me.ListViewPayments.FullRowSelect = True
        Me.ListViewPayments.GridLines = True
        Me.ListViewPayments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewPayments.HideSelection = False
        Me.ListViewPayments.Location = New System.Drawing.Point(21, 99)
        Me.ListViewPayments.MultiSelect = False
        Me.ListViewPayments.Name = "ListViewPayments"
        Me.ListViewPayments.Size = New System.Drawing.Size(690, 104)
        Me.ListViewPayments.TabIndex = 294
        Me.ListViewPayments.UseCompatibleStateImageBehavior = False
        Me.ListViewPayments.View = System.Windows.Forms.View.Details
        '
        'BillID
        '
        Me.BillID.Text = "Bill #"
        '
        'PaymentDT
        '
        Me.PaymentDT.Text = "Date"
        Me.PaymentDT.Width = 75
        '
        'PaymentType
        '
        Me.PaymentType.Text = "Type"
        Me.PaymentType.Width = 77
        '
        'CheckNumber
        '
        Me.CheckNumber.Text = "Check Number"
        Me.CheckNumber.Width = 90
        '
        'Amount
        '
        Me.Amount.Text = "Amount"
        Me.Amount.Width = 90
        '
        'Note
        '
        Me.Note.Text = "Note"
        Me.Note.Width = 267
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.BackColor = System.Drawing.Color.Transparent
        Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.ForeColor = System.Drawing.Color.Black
        Me.Label83.Location = New System.Drawing.Point(21, 11)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(61, 13)
        Me.Label83.TabIndex = 178
        Me.Label83.Text = "Patient Bills"
        '
        'TreeViewBills
        '
        Me.TreeViewBills.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeViewBills.BackColor = System.Drawing.Color.White
        Me.TreeViewBills.ContextMenuStrip = Me.ContextMenuStrip2
        Me.TreeViewBills.FullRowSelect = True
        Me.TreeViewBills.HideSelection = False
        Me.TreeViewBills.ImageKey = "2"
        Me.TreeViewBills.ImageList = Me.ImageList3
        Me.TreeViewBills.Indent = 12
        Me.TreeViewBills.Location = New System.Drawing.Point(21, 26)
        Me.TreeViewBills.Name = "TreeViewBills"
        Me.TreeViewBills.SelectedImageIndex = 0
        Me.TreeViewBills.ShowNodeToolTips = True
        Me.TreeViewBills.Size = New System.Drawing.Size(690, 54)
        Me.TreeViewBills.TabIndex = 1
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExpandAllToolStripMenuItem, Me.CollapsAllToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(137, 48)
        '
        'ExpandAllToolStripMenuItem
        '
        Me.ExpandAllToolStripMenuItem.Name = "ExpandAllToolStripMenuItem"
        Me.ExpandAllToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ExpandAllToolStripMenuItem.Text = "Expand All"
        '
        'CollapsAllToolStripMenuItem
        '
        Me.CollapsAllToolStripMenuItem.Name = "CollapsAllToolStripMenuItem"
        Me.CollapsAllToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.CollapsAllToolStripMenuItem.Text = "Collapse All"
        '
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "3")
        Me.ImageList3.Images.SetKeyName(1, "4")
        Me.ImageList3.Images.SetKeyName(2, "5")
        Me.ImageList3.Images.SetKeyName(3, "6")
        Me.ImageList3.Images.SetKeyName(4, "7")
        Me.ImageList3.Images.SetKeyName(5, "31")
        Me.ImageList3.Images.SetKeyName(6, "41")
        Me.ImageList3.Images.SetKeyName(7, "51")
        Me.ImageList3.Images.SetKeyName(8, "61")
        Me.ImageList3.Images.SetKeyName(9, "71")
        Me.ImageList3.Images.SetKeyName(10, "8")
        Me.ImageList3.Images.SetKeyName(11, "81")
        Me.ImageList3.Images.SetKeyName(12, "2")
        Me.ImageList3.Images.SetKeyName(13, "21")
        Me.ImageList3.Images.SetKeyName(14, "1")
        Me.ImageList3.Images.SetKeyName(15, "11")
        Me.ImageList3.Images.SetKeyName(16, "PROC")
        Me.ImageList3.Images.SetKeyName(17, "DIAG")
        '
        'TabPageLog
        '
        Me.TabPageLog.BackColor = System.Drawing.Color.Transparent
        Me.TabPageLog.Controls.Add(Me.ButtonAutosizePatientProfileLog)
        Me.TabPageLog.Controls.Add(Me.ButtonAutosizeCancelationLog)
        Me.TabPageLog.Controls.Add(Me.ListViewCancelations)
        Me.TabPageLog.Controls.Add(Me.Label89)
        Me.TabPageLog.Controls.Add(Me.txtFieldsChanged)
        Me.TabPageLog.Controls.Add(Me.Label48)
        Me.TabPageLog.Controls.Add(Me.ListViewPatientLog)
        Me.TabPageLog.Location = New System.Drawing.Point(4, 23)
        Me.TabPageLog.Name = "TabPageLog"
        Me.TabPageLog.Size = New System.Drawing.Size(763, 506)
        Me.TabPageLog.TabIndex = 5
        Me.TabPageLog.Text = "Log"
        Me.TabPageLog.UseVisualStyleBackColor = True
        '
        'ButtonAutosizePatientProfileLog
        '
        Me.ButtonAutosizePatientProfileLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAutosizePatientProfileLog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAutosizePatientProfileLog.FlatAppearance.BorderSize = 0
        Me.ButtonAutosizePatientProfileLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonAutosizePatientProfileLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonAutosizePatientProfileLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAutosizePatientProfileLog.Image = CType(resources.GetObject("ButtonAutosizePatientProfileLog.Image"), System.Drawing.Image)
        Me.ButtonAutosizePatientProfileLog.Location = New System.Drawing.Point(694, 135)
        Me.ButtonAutosizePatientProfileLog.Name = "ButtonAutosizePatientProfileLog"
        Me.ButtonAutosizePatientProfileLog.Size = New System.Drawing.Size(16, 15)
        Me.ButtonAutosizePatientProfileLog.TabIndex = 369
        Me.ToolTip1.SetToolTip(Me.ButtonAutosizePatientProfileLog, "Autosize Spread Columns")
        Me.ButtonAutosizePatientProfileLog.UseVisualStyleBackColor = True
        '
        'ButtonAutosizeCancelationLog
        '
        Me.ButtonAutosizeCancelationLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAutosizeCancelationLog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAutosizeCancelationLog.FlatAppearance.BorderSize = 0
        Me.ButtonAutosizeCancelationLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeCancelationLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeCancelationLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAutosizeCancelationLog.Image = CType(resources.GetObject("ButtonAutosizeCancelationLog.Image"), System.Drawing.Image)
        Me.ButtonAutosizeCancelationLog.Location = New System.Drawing.Point(695, 8)
        Me.ButtonAutosizeCancelationLog.Name = "ButtonAutosizeCancelationLog"
        Me.ButtonAutosizeCancelationLog.Size = New System.Drawing.Size(16, 15)
        Me.ButtonAutosizeCancelationLog.TabIndex = 368
        Me.ToolTip1.SetToolTip(Me.ButtonAutosizeCancelationLog, "Autosize Spread Columns")
        Me.ButtonAutosizeCancelationLog.UseVisualStyleBackColor = True
        '
        'ListViewCancelations
        '
        Me.ListViewCancelations.AllowColumnReorder = True
        Me.ListViewCancelations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewCancelations.BackColor = System.Drawing.Color.White
        Me.ListViewCancelations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewCancelations.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader33, Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader31, Me.ColumnHeader32})
        Me.ListViewCancelations.FullRowSelect = True
        Me.ListViewCancelations.GridLines = True
        Me.ListViewCancelations.HideSelection = False
        Me.ListViewCancelations.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem2})
        Me.ListViewCancelations.LargeImageList = Me.ImageList1
        Me.ListViewCancelations.Location = New System.Drawing.Point(21, 26)
        Me.ListViewCancelations.MultiSelect = False
        Me.ListViewCancelations.Name = "ListViewCancelations"
        Me.ListViewCancelations.Size = New System.Drawing.Size(690, 106)
        Me.ListViewCancelations.SmallImageList = Me.ImageList1
        Me.ListViewCancelations.TabIndex = 180
        Me.ListViewCancelations.UseCompatibleStateImageBehavior = False
        Me.ListViewCancelations.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader33
        '
        Me.ColumnHeader33.Text = "##"
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "Date"
        Me.ColumnHeader29.Width = 85
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "Action"
        Me.ColumnHeader30.Width = 117
        '
        'ColumnHeader31
        '
        Me.ColumnHeader31.Text = "Comments"
        Me.ColumnHeader31.Width = 333
        '
        'ColumnHeader32
        '
        Me.ColumnHeader32.Text = "Action By"
        Me.ColumnHeader32.Width = 100
        '
        'Label89
        '
        Me.Label89.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label89.AutoSize = True
        Me.Label89.BackColor = System.Drawing.Color.Transparent
        Me.Label89.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.ForeColor = System.Drawing.Color.Black
        Me.Label89.Location = New System.Drawing.Point(18, 135)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(93, 13)
        Me.Label89.TabIndex = 179
        Me.Label89.Text = "Patient Profile Log"
        '
        'txtFieldsChanged
        '
        Me.txtFieldsChanged.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFieldsChanged.BackColor = System.Drawing.Color.White
        Me.txtFieldsChanged.Location = New System.Drawing.Point(21, 372)
        Me.txtFieldsChanged.Multiline = True
        Me.txtFieldsChanged.Name = "txtFieldsChanged"
        Me.txtFieldsChanged.ReadOnly = True
        Me.txtFieldsChanged.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFieldsChanged.Size = New System.Drawing.Size(690, 118)
        Me.txtFieldsChanged.TabIndex = 178
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.Black
        Me.Label48.Location = New System.Drawing.Point(21, 11)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(177, 13)
        Me.Label48.TabIndex = 177
        Me.Label48.Text = "Patient Reschedules / Cancelations"
        '
        'ListViewPatientLog
        '
        Me.ListViewPatientLog.AllowColumnReorder = True
        Me.ListViewPatientLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewPatientLog.BackColor = System.Drawing.Color.White
        Me.ListViewPatientLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewPatientLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader18, Me.ColumnHeader21, Me.ColumnHeader11, Me.ColumnHeader4, Me.ColumnHeader9})
        Me.ListViewPatientLog.FullRowSelect = True
        Me.ListViewPatientLog.GridLines = True
        Me.ListViewPatientLog.HideSelection = False
        Me.ListViewPatientLog.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem3})
        Me.ListViewPatientLog.Location = New System.Drawing.Point(21, 151)
        Me.ListViewPatientLog.MultiSelect = False
        Me.ListViewPatientLog.Name = "ListViewPatientLog"
        Me.ListViewPatientLog.Size = New System.Drawing.Size(690, 215)
        Me.ListViewPatientLog.SmallImageList = Me.ImageList2
        Me.ListViewPatientLog.TabIndex = 176
        Me.ListViewPatientLog.UseCompatibleStateImageBehavior = False
        Me.ListViewPatientLog.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Date"
        Me.ColumnHeader18.Width = 85
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Access Type"
        Me.ColumnHeader21.Width = 117
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Updated By"
        Me.ColumnHeader11.Width = 134
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Approved By"
        Me.ColumnHeader4.Width = 102
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Comments"
        Me.ColumnHeader9.Width = 214
        '
        'TabPage8
        '
        Me.TabPage8.BackColor = System.Drawing.Color.Transparent
        Me.TabPage8.Controls.Add(Me.ButtonAutosizeRequestActions)
        Me.TabPage8.Controls.Add(Me.ButtonAutosizeRequests)
        Me.TabPage8.Controls.Add(Me.ToolStrip6)
        Me.TabPage8.Controls.Add(Me.ListViewRequests)
        Me.TabPage8.Controls.Add(Me.Label92)
        Me.TabPage8.Controls.Add(Me.Label93)
        Me.TabPage8.Controls.Add(Me.ListViewActions)
        Me.TabPage8.Controls.Add(Me.LabelActions)
        Me.TabPage8.Controls.Add(Me.Label91)
        Me.TabPage8.Location = New System.Drawing.Point(4, 23)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(763, 506)
        Me.TabPage8.TabIndex = 8
        Me.TabPage8.Text = "Requests"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'ButtonAutosizeRequestActions
        '
        Me.ButtonAutosizeRequestActions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAutosizeRequestActions.FlatAppearance.BorderSize = 0
        Me.ButtonAutosizeRequestActions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeRequestActions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeRequestActions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAutosizeRequestActions.Image = CType(resources.GetObject("ButtonAutosizeRequestActions.Image"), System.Drawing.Image)
        Me.ButtonAutosizeRequestActions.Location = New System.Drawing.Point(695, 158)
        Me.ButtonAutosizeRequestActions.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAutosizeRequestActions.Name = "ButtonAutosizeRequestActions"
        Me.ButtonAutosizeRequestActions.Size = New System.Drawing.Size(16, 15)
        Me.ButtonAutosizeRequestActions.TabIndex = 371
        Me.ToolTip1.SetToolTip(Me.ButtonAutosizeRequestActions, "Autosize Columns")
        Me.ButtonAutosizeRequestActions.UseVisualStyleBackColor = True
        '
        'ButtonAutosizeRequests
        '
        Me.ButtonAutosizeRequests.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAutosizeRequests.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAutosizeRequests.FlatAppearance.BorderSize = 0
        Me.ButtonAutosizeRequests.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeRequests.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAutosizeRequests.Image = CType(resources.GetObject("ButtonAutosizeRequests.Image"), System.Drawing.Image)
        Me.ButtonAutosizeRequests.Location = New System.Drawing.Point(695, 8)
        Me.ButtonAutosizeRequests.Name = "ButtonAutosizeRequests"
        Me.ButtonAutosizeRequests.Size = New System.Drawing.Size(16, 15)
        Me.ButtonAutosizeRequests.TabIndex = 370
        Me.ToolTip1.SetToolTip(Me.ButtonAutosizeRequests, "Autosize Spread Columns")
        Me.ButtonAutosizeRequests.UseVisualStyleBackColor = True
        '
        'ToolStrip6
        '
        Me.ToolStrip6.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip6.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip6.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip6.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton8})
        Me.ToolStrip6.Location = New System.Drawing.Point(3, 478)
        Me.ToolStrip6.Name = "ToolStrip6"
        Me.ToolStrip6.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip6.Size = New System.Drawing.Size(757, 25)
        Me.ToolStrip6.TabIndex = 186
        Me.ToolStrip6.Text = "ToolStrip6"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Margin = New System.Windows.Forms.Padding(15, 1, 0, 2)
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(94, 22)
        Me.ToolStripButton8.Text = "Add Request"
        '
        'ListViewRequests
        '
        Me.ListViewRequests.AllowColumnReorder = True
        Me.ListViewRequests.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewRequests.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewRequests.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader40, Me.ColumnHeader37, Me.ColumnHeader38, Me.ColumnHeader39, Me.ColumnHeader41, Me.ColumnHeader42, Me.ColumnHeader43, Me.ColumnHeader44, Me.ColumnHeader60})
        Me.ListViewRequests.FullRowSelect = True
        Me.ListViewRequests.GridLines = True
        Me.ListViewRequests.HideSelection = False
        Me.ListViewRequests.LargeImageList = Me.ImageList1
        Me.ListViewRequests.Location = New System.Drawing.Point(21, 26)
        Me.ListViewRequests.Name = "ListViewRequests"
        Me.ListViewRequests.ShowItemToolTips = True
        Me.ListViewRequests.Size = New System.Drawing.Size(690, 130)
        Me.ListViewRequests.SmallImageList = Me.ImageList1
        Me.ListViewRequests.TabIndex = 162
        Me.ListViewRequests.UseCompatibleStateImageBehavior = False
        Me.ListViewRequests.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader40
        '
        Me.ColumnHeader40.Text = "Request Date"
        Me.ColumnHeader40.Width = 84
        '
        'ColumnHeader37
        '
        Me.ColumnHeader37.Text = "Request"
        '
        'ColumnHeader38
        '
        Me.ColumnHeader38.Text = "Request From"
        Me.ColumnHeader38.Width = 120
        '
        'ColumnHeader39
        '
        Me.ColumnHeader39.Text = "Responsible"
        Me.ColumnHeader39.Width = 106
        '
        'ColumnHeader41
        '
        Me.ColumnHeader41.Text = "Prioroty"
        '
        'ColumnHeader42
        '
        Me.ColumnHeader42.Text = "Status"
        '
        'ColumnHeader43
        '
        Me.ColumnHeader43.Text = "Status Date"
        '
        'ColumnHeader44
        '
        Me.ColumnHeader44.Text = "CD Information"
        Me.ColumnHeader44.Width = 74
        '
        'ColumnHeader60
        '
        Me.ColumnHeader60.Text = "Service DT"
        '
        'Label92
        '
        Me.Label92.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label92.AutoSize = True
        Me.Label92.BackColor = System.Drawing.Color.Transparent
        Me.Label92.Location = New System.Drawing.Point(21, 159)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(85, 13)
        Me.Label92.TabIndex = 161
        Me.Label92.Text = "Request Actions"
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.BackColor = System.Drawing.Color.Transparent
        Me.Label93.Location = New System.Drawing.Point(21, 11)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(52, 13)
        Me.Label93.TabIndex = 160
        Me.Label93.Text = "Requests"
        '
        'ListViewActions
        '
        Me.ListViewActions.AllowColumnReorder = True
        Me.ListViewActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewActions.BackColor = System.Drawing.Color.White
        Me.ListViewActions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader34, Me.ColumnHeader35, Me.ColumnHeader36})
        Me.ListViewActions.FullRowSelect = True
        Me.ListViewActions.GridLines = True
        Me.ListViewActions.HideSelection = False
        Me.ListViewActions.LargeImageList = Me.ImageList1
        Me.ListViewActions.Location = New System.Drawing.Point(21, 175)
        Me.ListViewActions.Name = "ListViewActions"
        Me.ListViewActions.ShowItemToolTips = True
        Me.ListViewActions.Size = New System.Drawing.Size(690, 293)
        Me.ListViewActions.SmallImageList = Me.ImageList1
        Me.ListViewActions.TabIndex = 159
        Me.ListViewActions.UseCompatibleStateImageBehavior = False
        Me.ListViewActions.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "Action DT"
        Me.ColumnHeader34.Width = 102
        '
        'ColumnHeader35
        '
        Me.ColumnHeader35.Text = "Action Information"
        Me.ColumnHeader35.Width = 387
        '
        'ColumnHeader36
        '
        Me.ColumnHeader36.Text = "By"
        Me.ColumnHeader36.Width = 143
        '
        'LabelActions
        '
        Me.LabelActions.AutoSize = True
        Me.LabelActions.BackColor = System.Drawing.Color.Transparent
        Me.LabelActions.Location = New System.Drawing.Point(-219, 302)
        Me.LabelActions.Name = "LabelActions"
        Me.LabelActions.Size = New System.Drawing.Size(85, 13)
        Me.LabelActions.TabIndex = 158
        Me.LabelActions.Text = "Request Actions"
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.BackColor = System.Drawing.Color.Transparent
        Me.Label91.Location = New System.Drawing.Point(-215, 74)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(52, 13)
        Me.Label91.TabIndex = 157
        Me.Label91.Text = "Requests"
        '
        'TabPageExamination
        '
        Me.TabPageExamination.Controls.Add(Me.ButtonAutosizeIME)
        Me.TabPageExamination.Controls.Add(Me.ListViewIME)
        Me.TabPageExamination.Controls.Add(Me.ToolStrip1)
        Me.TabPageExamination.Controls.Add(Me.Label115)
        Me.TabPageExamination.Location = New System.Drawing.Point(4, 23)
        Me.TabPageExamination.Name = "TabPageExamination"
        Me.TabPageExamination.Size = New System.Drawing.Size(763, 506)
        Me.TabPageExamination.TabIndex = 10
        Me.TabPageExamination.Text = "IME/EUO"
        Me.TabPageExamination.UseVisualStyleBackColor = True
        '
        'ButtonAutosizeIME
        '
        Me.ButtonAutosizeIME.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAutosizeIME.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAutosizeIME.FlatAppearance.BorderSize = 0
        Me.ButtonAutosizeIME.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeIME.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonAutosizeIME.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAutosizeIME.Image = CType(resources.GetObject("ButtonAutosizeIME.Image"), System.Drawing.Image)
        Me.ButtonAutosizeIME.Location = New System.Drawing.Point(695, 8)
        Me.ButtonAutosizeIME.Name = "ButtonAutosizeIME"
        Me.ButtonAutosizeIME.Size = New System.Drawing.Size(16, 15)
        Me.ButtonAutosizeIME.TabIndex = 371
        Me.ToolTip1.SetToolTip(Me.ButtonAutosizeIME, "Autosize Spread Columns")
        Me.ButtonAutosizeIME.UseVisualStyleBackColor = True
        '
        'ListViewIME
        '
        Me.ListViewIME.AllowColumnReorder = True
        Me.ListViewIME.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewIME.BackColor = System.Drawing.Color.Snow
        Me.ListViewIME.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader52, Me.ColumnHeader55, Me.ColumnHeader56, Me.ColumnHeader64})
        Me.ListViewIME.FullRowSelect = True
        Me.ListViewIME.GridLines = True
        Me.ListViewIME.HideSelection = False
        Me.ListViewIME.LabelWrap = False
        Me.ListViewIME.Location = New System.Drawing.Point(21, 26)
        Me.ListViewIME.Margin = New System.Windows.Forms.Padding(0)
        Me.ListViewIME.MultiSelect = False
        Me.ListViewIME.Name = "ListViewIME"
        Me.ListViewIME.ShowGroups = False
        Me.ListViewIME.ShowItemToolTips = True
        Me.ListViewIME.Size = New System.Drawing.Size(692, 440)
        Me.ListViewIME.TabIndex = 184
        Me.ListViewIME.UseCompatibleStateImageBehavior = False
        Me.ListViewIME.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader52
        '
        Me.ColumnHeader52.Text = "Type"
        Me.ColumnHeader52.Width = 82
        '
        'ColumnHeader55
        '
        Me.ColumnHeader55.Text = "Date / Time"
        Me.ColumnHeader55.Width = 127
        '
        'ColumnHeader56
        '
        Me.ColumnHeader56.Text = "Status"
        Me.ColumnHeader56.Width = 120
        '
        'ColumnHeader64
        '
        Me.ColumnHeader64.Text = "Address / Comments"
        Me.ColumnHeader64.Width = 321
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonAddIME, Me.ToolStripSeparator4, Me.ToolStripButtonEditIME})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 481)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(763, 25)
        Me.ToolStrip1.TabIndex = 183
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButtonAddIME
        '
        Me.ToolStripButtonAddIME.AutoSize = False
        Me.ToolStripButtonAddIME.Image = CType(resources.GetObject("ToolStripButtonAddIME.Image"), System.Drawing.Image)
        Me.ToolStripButtonAddIME.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonAddIME.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAddIME.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.ToolStripButtonAddIME.Name = "ToolStripButtonAddIME"
        Me.ToolStripButtonAddIME.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripButtonAddIME.Text = "Add"
        Me.ToolStripButtonAddIME.ToolTipText = "Add New Insurance Examination"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonEditIME
        '
        Me.ToolStripButtonEditIME.Image = CType(resources.GetObject("ToolStripButtonEditIME.Image"), System.Drawing.Image)
        Me.ToolStripButtonEditIME.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonEditIME.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonEditIME.Name = "ToolStripButtonEditIME"
        Me.ToolStripButtonEditIME.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripButtonEditIME.Text = "Change Status"
        Me.ToolStripButtonEditIME.ToolTipText = "Edit Insurance Examination Status"
        '
        'Label115
        '
        Me.Label115.AutoSize = True
        Me.Label115.BackColor = System.Drawing.Color.Transparent
        Me.Label115.Location = New System.Drawing.Point(21, 11)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(108, 13)
        Me.Label115.TabIndex = 163
        Me.Label115.Text = "EUO / IME Schedule"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.ToolStrip9)
        Me.TabPage4.Controls.Add(Me.Label122)
        Me.TabPage4.Controls.Add(Me.TextBoxWebURL)
        Me.TabPage4.Controls.Add(Me.Label120)
        Me.TabPage4.Controls.Add(Me.TextBoxWebPassword)
        Me.TabPage4.Controls.Add(Me.TextBoxWebUid)
        Me.TabPage4.Controls.Add(Me.Label121)
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(763, 506)
        Me.TabPage4.TabIndex = 11
        Me.TabPage4.Text = "Patient Web Access"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'ToolStrip9
        '
        Me.ToolStrip9.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip9.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip9.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip9.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonPrintWebAccess, Me.ButtonWebPassword, Me.ToolStripButtonNavigateWebAccess, Me.ToolStripButtonFaxWebAccessInfo, Me.ToolStripButtonEmailWebAccessInformation})
        Me.ToolStrip9.Location = New System.Drawing.Point(0, 481)
        Me.ToolStrip9.Name = "ToolStrip9"
        Me.ToolStrip9.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip9.Size = New System.Drawing.Size(763, 25)
        Me.ToolStrip9.TabIndex = 256
        Me.ToolStrip9.Text = "ToolStrip9"
        '
        'ButtonPrintWebAccess
        '
        Me.ButtonPrintWebAccess.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ButtonPrintWebAccess.Image = CType(resources.GetObject("ButtonPrintWebAccess.Image"), System.Drawing.Image)
        Me.ButtonPrintWebAccess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonPrintWebAccess.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonPrintWebAccess.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.ButtonPrintWebAccess.Name = "ButtonPrintWebAccess"
        Me.ButtonPrintWebAccess.Size = New System.Drawing.Size(52, 22)
        Me.ButtonPrintWebAccess.Text = "Print"
        Me.ButtonPrintWebAccess.ToolTipText = "Print Document"
        '
        'ButtonWebPassword
        '
        Me.ButtonWebPassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonWebPassword.Image = CType(resources.GetObject("ButtonWebPassword.Image"), System.Drawing.Image)
        Me.ButtonWebPassword.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonWebPassword.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.ButtonWebPassword.Name = "ButtonWebPassword"
        Me.ButtonWebPassword.Size = New System.Drawing.Size(23, 22)
        Me.ButtonWebPassword.Text = "ReGenerate Web Access Password"
        '
        'ToolStripButtonNavigateWebAccess
        '
        Me.ToolStripButtonNavigateWebAccess.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonNavigateWebAccess.Image = CType(resources.GetObject("ToolStripButtonNavigateWebAccess.Image"), System.Drawing.Image)
        Me.ToolStripButtonNavigateWebAccess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonNavigateWebAccess.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonNavigateWebAccess.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.ToolStripButtonNavigateWebAccess.Name = "ToolStripButtonNavigateWebAccess"
        Me.ToolStripButtonNavigateWebAccess.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripButtonNavigateWebAccess.Text = "Navigate"
        Me.ToolStripButtonNavigateWebAccess.ToolTipText = "Open Company Web Side"
        '
        'ToolStripButtonFaxWebAccessInfo
        '
        Me.ToolStripButtonFaxWebAccessInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonFaxWebAccessInfo.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButtonFaxWebAccessInfo.Image = CType(resources.GetObject("ToolStripButtonFaxWebAccessInfo.Image"), System.Drawing.Image)
        Me.ToolStripButtonFaxWebAccessInfo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonFaxWebAccessInfo.Margin = New System.Windows.Forms.Padding(10, 1, 10, 2)
        Me.ToolStripButtonFaxWebAccessInfo.Name = "ToolStripButtonFaxWebAccessInfo"
        Me.ToolStripButtonFaxWebAccessInfo.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripButtonFaxWebAccessInfo.Text = "Fax"
        Me.ToolStripButtonFaxWebAccessInfo.ToolTipText = "Fax Document"
        '
        'ToolStripButtonEmailWebAccessInformation
        '
        Me.ToolStripButtonEmailWebAccessInformation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonEmailWebAccessInformation.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButtonEmailWebAccessInformation.Image = CType(resources.GetObject("ToolStripButtonEmailWebAccessInformation.Image"), System.Drawing.Image)
        Me.ToolStripButtonEmailWebAccessInformation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonEmailWebAccessInformation.Name = "ToolStripButtonEmailWebAccessInformation"
        Me.ToolStripButtonEmailWebAccessInformation.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButtonEmailWebAccessInformation.Text = "Email"
        Me.ToolStripButtonEmailWebAccessInformation.ToolTipText = "Email Document"
        '
        'Label122
        '
        Me.Label122.AutoSize = True
        Me.Label122.BackColor = System.Drawing.Color.Transparent
        Me.Label122.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label122.ForeColor = System.Drawing.Color.Black
        Me.Label122.Location = New System.Drawing.Point(18, 17)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(55, 13)
        Me.Label122.TabIndex = 255
        Me.Label122.Text = "Web URL"
        '
        'TextBoxWebURL
        '
        Me.TextBoxWebURL.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxWebURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TextBoxWebURL.ForeColor = System.Drawing.Color.Black
        Me.TextBoxWebURL.Location = New System.Drawing.Point(21, 33)
        Me.TextBoxWebURL.Name = "TextBoxWebURL"
        Me.TextBoxWebURL.ReadOnly = True
        Me.TextBoxWebURL.Size = New System.Drawing.Size(404, 20)
        Me.TextBoxWebURL.TabIndex = 254
        Me.TextBoxWebURL.TabStop = False
        '
        'Label120
        '
        Me.Label120.AutoSize = True
        Me.Label120.BackColor = System.Drawing.Color.Transparent
        Me.Label120.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label120.ForeColor = System.Drawing.Color.Black
        Me.Label120.Location = New System.Drawing.Point(18, 107)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(53, 13)
        Me.Label120.TabIndex = 251
        Me.Label120.Text = "Password"
        '
        'TextBoxWebPassword
        '
        Me.TextBoxWebPassword.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxWebPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBoxWebPassword.ForeColor = System.Drawing.Color.Black
        Me.TextBoxWebPassword.Location = New System.Drawing.Point(21, 123)
        Me.TextBoxWebPassword.Name = "TextBoxWebPassword"
        Me.TextBoxWebPassword.ReadOnly = True
        Me.TextBoxWebPassword.Size = New System.Drawing.Size(404, 22)
        Me.TextBoxWebPassword.TabIndex = 249
        Me.TextBoxWebPassword.TabStop = False
        '
        'TextBoxWebUid
        '
        Me.TextBoxWebUid.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxWebUid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBoxWebUid.ForeColor = System.Drawing.Color.Black
        Me.TextBoxWebUid.Location = New System.Drawing.Point(21, 78)
        Me.TextBoxWebUid.Name = "TextBoxWebUid"
        Me.TextBoxWebUid.ReadOnly = True
        Me.TextBoxWebUid.Size = New System.Drawing.Size(404, 22)
        Me.TextBoxWebUid.TabIndex = 248
        Me.TextBoxWebUid.TabStop = False
        '
        'Label121
        '
        Me.Label121.AutoSize = True
        Me.Label121.BackColor = System.Drawing.Color.Transparent
        Me.Label121.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label121.ForeColor = System.Drawing.Color.Black
        Me.Label121.Location = New System.Drawing.Point(18, 62)
        Me.Label121.Name = "Label121"
        Me.Label121.Size = New System.Drawing.Size(60, 13)
        Me.Label121.TabIndex = 250
        Me.Label121.Text = "User Name"
        '
        'ImageList4
        '
        Me.ImageList4.ImageStream = CType(resources.GetObject("ImageList4.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList4.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList4.Images.SetKeyName(0, "CheckedBlue.gif")
        Me.ImageList4.Images.SetKeyName(1, "CHeckRed.png")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NetSearchToolStripMenuItem, Me.ToolStripSeparatorNetSearch, Me.PrintPatientsChartToolStripMenuItem, Me.PrintPatientsFileLabelToolStripMenuItem, Me.PrintPreScreenFormToolStripMenuItem, Me.PrintPatientsInformationToolStripMenuItem, Me.PrintPatientsNF2FormToolStripMenuItem, Me.PrintPatientsApplicationForBenefitsToolStripMenuItem, Me.ToolStripMenuItemSchedule, Me.ToolStripMenuItem7, Me.ToolStripSeparator1, Me.ToolStripMenuItem6, Me.ShowAccidentRelatedPatientsToolStripMenuItem, Me.FindDuplicatePatientsToolStripMenuItem, Me.ToolStripSeparator18, Me.FindPatientBillsToolStripMenuItem, Me.ToolStripSeparator8, Me.ImportPatientsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(301, 336)
        '
        'NetSearchToolStripMenuItem
        '
        Me.NetSearchToolStripMenuItem.Image = CType(resources.GetObject("NetSearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NetSearchToolStripMenuItem.Name = "NetSearchToolStripMenuItem"
        Me.NetSearchToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.NetSearchToolStripMenuItem.Text = "Net Search"
        '
        'ToolStripSeparatorNetSearch
        '
        Me.ToolStripSeparatorNetSearch.Name = "ToolStripSeparatorNetSearch"
        Me.ToolStripSeparatorNetSearch.Size = New System.Drawing.Size(297, 6)
        '
        'PrintPatientsChartToolStripMenuItem
        '
        Me.PrintPatientsChartToolStripMenuItem.BackColor = System.Drawing.Color.Lavender
        Me.PrintPatientsChartToolStripMenuItem.Image = CType(resources.GetObject("PrintPatientsChartToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPatientsChartToolStripMenuItem.Name = "PrintPatientsChartToolStripMenuItem"
        Me.PrintPatientsChartToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.PrintPatientsChartToolStripMenuItem.Text = "Print Patient's Chart"
        '
        'PrintPatientsFileLabelToolStripMenuItem
        '
        Me.PrintPatientsFileLabelToolStripMenuItem.BackColor = System.Drawing.Color.LemonChiffon
        Me.PrintPatientsFileLabelToolStripMenuItem.Image = CType(resources.GetObject("PrintPatientsFileLabelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPatientsFileLabelToolStripMenuItem.Name = "PrintPatientsFileLabelToolStripMenuItem"
        Me.PrintPatientsFileLabelToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.PrintPatientsFileLabelToolStripMenuItem.Text = "Print Patient's File Label"
        '
        'PrintPreScreenFormToolStripMenuItem
        '
        Me.PrintPreScreenFormToolStripMenuItem.BackColor = System.Drawing.Color.GhostWhite
        Me.PrintPreScreenFormToolStripMenuItem.Image = CType(resources.GetObject("PrintPreScreenFormToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPreScreenFormToolStripMenuItem.Name = "PrintPreScreenFormToolStripMenuItem"
        Me.PrintPreScreenFormToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.PrintPreScreenFormToolStripMenuItem.Text = "Print Pre Screen Form"
        Me.PrintPreScreenFormToolStripMenuItem.Visible = False
        '
        'PrintPatientsInformationToolStripMenuItem
        '
        Me.PrintPatientsInformationToolStripMenuItem.Image = CType(resources.GetObject("PrintPatientsInformationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPatientsInformationToolStripMenuItem.Name = "PrintPatientsInformationToolStripMenuItem"
        Me.PrintPatientsInformationToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.PrintPatientsInformationToolStripMenuItem.Text = "Print Patient's Information"
        '
        'PrintPatientsNF2FormToolStripMenuItem
        '
        Me.PrintPatientsNF2FormToolStripMenuItem.Name = "PrintPatientsNF2FormToolStripMenuItem"
        Me.PrintPatientsNF2FormToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.PrintPatientsNF2FormToolStripMenuItem.Text = "Print Patient's NF2 Form"
        '
        'PrintPatientsApplicationForBenefitsToolStripMenuItem
        '
        Me.PrintPatientsApplicationForBenefitsToolStripMenuItem.Image = CType(resources.GetObject("PrintPatientsApplicationForBenefitsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPatientsApplicationForBenefitsToolStripMenuItem.Name = "PrintPatientsApplicationForBenefitsToolStripMenuItem"
        Me.PrintPatientsApplicationForBenefitsToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.PrintPatientsApplicationForBenefitsToolStripMenuItem.Text = "Print Patient's Application For Benefits (NJ)"
        '
        'ToolStripMenuItemSchedule
        '
        Me.ToolStripMenuItemSchedule.Image = CType(resources.GetObject("ToolStripMenuItemSchedule.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemSchedule.Name = "ToolStripMenuItemSchedule"
        Me.ToolStripMenuItemSchedule.Size = New System.Drawing.Size(300, 22)
        Me.ToolStripMenuItemSchedule.Text = "Print Patient Schedule"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Image = CType(resources.GetObject("ToolStripMenuItem7.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(300, 22)
        Me.ToolStripMenuItem7.Text = "Print Patient's Envelope"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(297, 6)
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Image = CType(resources.GetObject("ToolStripMenuItem6.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(300, 22)
        Me.ToolStripMenuItem6.Text = "Patient Procedures Switch Schedule"
        '
        'ShowAccidentRelatedPatientsToolStripMenuItem
        '
        Me.ShowAccidentRelatedPatientsToolStripMenuItem.Image = CType(resources.GetObject("ShowAccidentRelatedPatientsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ShowAccidentRelatedPatientsToolStripMenuItem.Name = "ShowAccidentRelatedPatientsToolStripMenuItem"
        Me.ShowAccidentRelatedPatientsToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.ShowAccidentRelatedPatientsToolStripMenuItem.Text = "Accident Related Patients Maintenance"
        '
        'FindDuplicatePatientsToolStripMenuItem
        '
        Me.FindDuplicatePatientsToolStripMenuItem.Image = CType(resources.GetObject("FindDuplicatePatientsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FindDuplicatePatientsToolStripMenuItem.Name = "FindDuplicatePatientsToolStripMenuItem"
        Me.FindDuplicatePatientsToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.FindDuplicatePatientsToolStripMenuItem.Text = "Find Duplicate Patients"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(297, 6)
        '
        'FindPatientBillsToolStripMenuItem
        '
        Me.FindPatientBillsToolStripMenuItem.Image = CType(resources.GetObject("FindPatientBillsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FindPatientBillsToolStripMenuItem.Name = "FindPatientBillsToolStripMenuItem"
        Me.FindPatientBillsToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.FindPatientBillsToolStripMenuItem.Text = "Find Patient Bills"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(297, 6)
        '
        'ImportPatientsToolStripMenuItem
        '
        Me.ImportPatientsToolStripMenuItem.Image = CType(resources.GetObject("ImportPatientsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImportPatientsToolStripMenuItem.Name = "ImportPatientsToolStripMenuItem"
        Me.ImportPatientsToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.ImportPatientsToolStripMenuItem.Text = "Import Patients"
        '
        'txtPatientID
        '
        Me.txtPatientID.BackColor = System.Drawing.Color.Khaki
        Me.txtPatientID.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtPatientID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientID.ForeColor = System.Drawing.Color.Black
        Me.ErrorProvider1.SetIconAlignment(Me.txtPatientID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txtPatientID.Location = New System.Drawing.Point(54, 0)
        Me.txtPatientID.MaxLength = 50
        Me.txtPatientID.Name = "txtPatientID"
        Me.txtPatientID.ReadOnly = True
        Me.txtPatientID.Size = New System.Drawing.Size(67, 20)
        Me.txtPatientID.TabIndex = 232
        Me.txtPatientID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.Icon = CType(resources.GetObject("ErrorProvider1.Icon"), System.Drawing.Icon)
        '
        'ListViewPatients
        '
        Me.ListViewPatients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListViewPatients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewPatients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListViewPatients.FullRowSelect = True
        Me.ListViewPatients.GridLines = True
        Me.ListViewPatients.HideSelection = False
        Me.ListViewPatients.LargeImageList = Me.ImageList1
        Me.ListViewPatients.Location = New System.Drawing.Point(7, 80)
        Me.ListViewPatients.MultiSelect = False
        Me.ListViewPatients.Name = "ListViewPatients"
        Me.ListViewPatients.Size = New System.Drawing.Size(251, 258)
        Me.ListViewPatients.SmallImageList = Me.ImageList1
        Me.ListViewPatients.TabIndex = 2
        Me.ListViewPatients.UseCompatibleStateImageBehavior = False
        Me.ListViewPatients.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "ID"
        Me.ColumnHeader7.Width = 45
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Patient Name"
        Me.ColumnHeader8.Width = 180
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 186
        Me.Label1.Text = "Case Status"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(8, 5)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(149, 13)
        Me.Label39.TabIndex = 187
        Me.Label39.Text = "Find Patient  [ Type     For All ]"
        '
        'TimerLoad
        '
        '
        'Timer2
        '
        Me.Timer2.Interval = 250
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 20
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 20
        Me.ToolTip1.ReshowDelay = 4
        Me.ToolTip1.ShowAlways = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(211, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 274
        Me.PictureBox3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox3, "Specify Patient Number Or Patient First Name or Patient Name.  Type * To Show All" &
        " Patients")
        '
        'Label88
        '
        Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.ForeColor = System.Drawing.Color.Blue
        Me.Label88.Location = New System.Drawing.Point(102, 4)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(12, 34)
        Me.Label88.TabIndex = 275
        Me.Label88.Text = "*"
        Me.ToolTip1.SetToolTip(Me.Label88, "Specify Patient Number Or Patient First Name or Patient Name.  Type Start To Show" &
        " All Patients")
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.PanelPrinting)
        Me.Panel3.Controls.Add(Me.LabelFound)
        Me.Panel3.Controls.Add(Me.ButtonTools)
        Me.Panel3.Controls.Add(Me.cmdClose)
        Me.Panel3.Controls.Add(Me.cmdCancel)
        Me.Panel3.Controls.Add(Me.cmdUpdate)
        Me.Panel3.Controls.Add(Me.cmdDelete)
        Me.Panel3.Controls.Add(Me.cmdEdit)
        Me.Panel3.Controls.Add(Me.cmdAddNew)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 539)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1036, 30)
        Me.Panel3.TabIndex = 103
        '
        'PanelPrinting
        '
        Me.PanelPrinting.BackColor = System.Drawing.Color.Transparent
        Me.PanelPrinting.Controls.Add(Me.Label42)
        Me.PanelPrinting.Controls.Add(Me.PictureBox2)
        Me.PanelPrinting.Location = New System.Drawing.Point(269, 6)
        Me.PanelPrinting.Name = "PanelPrinting"
        Me.PanelPrinting.Size = New System.Drawing.Size(181, 20)
        Me.PanelPrinting.TabIndex = 252
        Me.PanelPrinting.Visible = False
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Red
        Me.Label42.Location = New System.Drawing.Point(39, 2)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(114, 13)
        Me.Label42.TabIndex = 1
        Me.Label42.Text = "Printing. Please Wait..."
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(4, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 17)
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'LabelFound
        '
        Me.LabelFound.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelFound.BackColor = System.Drawing.Color.Transparent
        Me.LabelFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFound.ForeColor = System.Drawing.Color.Black
        Me.LabelFound.Location = New System.Drawing.Point(143, 10)
        Me.LabelFound.Name = "LabelFound"
        Me.LabelFound.Size = New System.Drawing.Size(114, 13)
        Me.LabelFound.TabIndex = 251
        Me.LabelFound.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonTools
        '
        Me.ButtonTools.BackColor = System.Drawing.Color.Gainsboro
        Me.ButtonTools.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ButtonTools.FlatAppearance.BorderSize = 0
        Me.ButtonTools.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonTools.Image = CType(resources.GetObject("ButtonTools.Image"), System.Drawing.Image)
        Me.ButtonTools.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonTools.Location = New System.Drawing.Point(10, 3)
        Me.ButtonTools.Name = "ButtonTools"
        Me.ButtonTools.Size = New System.Drawing.Size(85, 24)
        Me.ButtonTools.TabIndex = 7
        Me.ButtonTools.Text = "Tools"
        Me.ButtonTools.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdClose.CausesValidation = False
        Me.cmdClose.FlatAppearance.BorderSize = 0
        Me.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdClose.Location = New System.Drawing.Point(951, 3)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 24)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdCancel.CausesValidation = False
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.FlatAppearance.BorderSize = 0
        Me.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(833, 3)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 24)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdate.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdUpdate.Enabled = False
        Me.cmdUpdate.FlatAppearance.BorderSize = 0
        Me.cmdUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdUpdate.Image = CType(resources.GetObject("cmdUpdate.Image"), System.Drawing.Image)
        Me.cmdUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdUpdate.Location = New System.Drawing.Point(752, 3)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 24)
        Me.cmdUpdate.TabIndex = 3
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdDelete.Enabled = False
        Me.cmdDelete.FlatAppearance.BorderSize = 0
        Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDelete.Location = New System.Drawing.Point(464, 3)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete.TabIndex = 0
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = False
        Me.cmdDelete.Visible = False
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEdit.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdEdit.Enabled = False
        Me.cmdEdit.FlatAppearance.BorderSize = 0
        Me.cmdEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEdit.Location = New System.Drawing.Point(671, 3)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(75, 24)
        Me.cmdEdit.TabIndex = 2
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEdit.UseVisualStyleBackColor = False
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddNew.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdAddNew.FlatAppearance.BorderSize = 0
        Me.cmdAddNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAddNew.Image = CType(resources.GetObject("cmdAddNew.Image"), System.Drawing.Image)
        Me.cmdAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddNew.Location = New System.Drawing.Point(590, 3)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(75, 24)
        Me.cmdAddNew.TabIndex = 1
        Me.cmdAddNew.Text = "Add"
        Me.cmdAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddNew.UseVisualStyleBackColor = False
        '
        'TimerPdfRefresh
        '
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.DisplayIndex = 0
        Me.ColumnHeader12.Text = "Date"
        Me.ColumnHeader12.Width = 82
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.DisplayIndex = 1
        Me.ColumnHeader13.Text = "Procedure"
        Me.ColumnHeader13.Width = 229
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.DisplayIndex = 2
        Me.ColumnHeader14.Text = "Status"
        Me.ColumnHeader14.Width = 137
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.DisplayIndex = 3
        Me.ColumnHeader20.Text = "Updated By"
        Me.ColumnHeader20.Width = 151
        '
        'PanelSearch
        '
        Me.PanelSearch.BackColor = System.Drawing.Color.Transparent
        Me.PanelSearch.Controls.Add(Me.MonthCalendarPopUp)
        Me.PanelSearch.Controls.Add(Me.Label44)
        Me.PanelSearch.Controls.Add(Me.DateTimePickerPopUp)
        Me.PanelSearch.Controls.Add(Me.ListViewPatientsRelated)
        Me.PanelSearch.Controls.Add(Me.imgWait1)
        Me.PanelSearch.Controls.Add(Me.ComboBoxSearchCaseType)
        Me.PanelSearch.Controls.Add(Me.TextBoxSearch)
        Me.PanelSearch.Controls.Add(Me.Label88)
        Me.PanelSearch.Controls.Add(Me.PictureBox3)
        Me.PanelSearch.Controls.Add(Me.Label39)
        Me.PanelSearch.Controls.Add(Me.ListViewPatients)
        Me.PanelSearch.Controls.Add(Me.Label1)
        Me.PanelSearch.Controls.Add(Me.ComboBoxSearchCaseStatus)
        Me.PanelSearch.Controls.Add(Me.Label90)
        Me.PanelSearch.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelSearch.Location = New System.Drawing.Point(0, 6)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Size = New System.Drawing.Size(265, 533)
        Me.PanelSearch.TabIndex = 190
        '
        'MonthCalendarPopUp
        '
        Me.MonthCalendarPopUp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MonthCalendarPopUp.Location = New System.Drawing.Point(0, 161)
        Me.MonthCalendarPopUp.Margin = New System.Windows.Forms.Padding(0)
        Me.MonthCalendarPopUp.MaxSelectionCount = 1
        Me.MonthCalendarPopUp.Name = "MonthCalendarPopUp"
        Me.MonthCalendarPopUp.TabIndex = 259
        Me.MonthCalendarPopUp.Visible = False
        '
        'Label44
        '
        Me.Label44.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Black
        Me.Label44.Location = New System.Drawing.Point(3, 344)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(130, 13)
        Me.Label44.TabIndex = 285
        Me.Label44.Text = "Accident Related Patients"
        '
        'DateTimePickerPopUp
        '
        Me.DateTimePickerPopUp.Checked = False
        Me.DateTimePickerPopUp.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePickerPopUp.Location = New System.Drawing.Point(0, 152)
        Me.DateTimePickerPopUp.Name = "DateTimePickerPopUp"
        Me.DateTimePickerPopUp.ShowUpDown = True
        Me.DateTimePickerPopUp.Size = New System.Drawing.Size(83, 20)
        Me.DateTimePickerPopUp.TabIndex = 260
        Me.DateTimePickerPopUp.Visible = False
        '
        'ListViewPatientsRelated
        '
        Me.ListViewPatientsRelated.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListViewPatientsRelated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewPatientsRelated.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader45, Me.ColumnHeader46})
        Me.ListViewPatientsRelated.ContextMenuStrip = Me.ContextMenuStrip3
        Me.ListViewPatientsRelated.FullRowSelect = True
        Me.ListViewPatientsRelated.GridLines = True
        Me.ListViewPatientsRelated.HideSelection = False
        Me.ListViewPatientsRelated.LargeImageList = Me.ImageList1
        Me.ListViewPatientsRelated.Location = New System.Drawing.Point(6, 359)
        Me.ListViewPatientsRelated.MultiSelect = False
        Me.ListViewPatientsRelated.Name = "ListViewPatientsRelated"
        Me.ListViewPatientsRelated.Size = New System.Drawing.Size(251, 165)
        Me.ListViewPatientsRelated.SmallImageList = Me.ImageList1
        Me.ListViewPatientsRelated.TabIndex = 284
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
        Me.ColumnHeader46.Width = 180
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(144, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(143, 22)
        Me.ToolStripMenuItem1.Text = "Show Patient"
        '
        'imgWait1
        '
        Me.imgWait1.BackColor = System.Drawing.Color.Transparent
        Me.imgWait1.Image = CType(resources.GetObject("imgWait1.Image"), System.Drawing.Image)
        Me.imgWait1.Location = New System.Drawing.Point(233, 18)
        Me.imgWait1.Name = "imgWait1"
        Me.imgWait1.Size = New System.Drawing.Size(25, 25)
        Me.imgWait1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.imgWait1.TabIndex = 283
        Me.imgWait1.TabStop = False
        Me.imgWait1.Visible = False
        '
        'ComboBoxSearchCaseType
        '
        Me.ComboBoxSearchCaseType.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxSearchCaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSearchCaseType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxSearchCaseType.FormattingEnabled = True
        Me.ComboBoxSearchCaseType.Location = New System.Drawing.Point(143, 56)
        Me.ComboBoxSearchCaseType.Name = "ComboBoxSearchCaseType"
        Me.ComboBoxSearchCaseType.Size = New System.Drawing.Size(114, 21)
        Me.ComboBoxSearchCaseType.TabIndex = 276
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.Location = New System.Drawing.Point(6, 22)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(223, 20)
        Me.TextBoxSearch.TabIndex = 1
        '
        'ComboBoxSearchCaseStatus
        '
        Me.ComboBoxSearchCaseStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxSearchCaseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSearchCaseStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxSearchCaseStatus.FormattingEnabled = True
        Me.ComboBoxSearchCaseStatus.Location = New System.Drawing.Point(8, 56)
        Me.ComboBoxSearchCaseStatus.Name = "ComboBoxSearchCaseStatus"
        Me.ComboBoxSearchCaseStatus.Size = New System.Drawing.Size(114, 21)
        Me.ComboBoxSearchCaseStatus.TabIndex = 0
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.Black
        Me.Label90.Location = New System.Drawing.Point(143, 42)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(58, 13)
        Me.Label90.TabIndex = 277
        Me.Label90.Text = "Case Type"
        '
        'ImageListErrorProvider
        '
        Me.ImageListErrorProvider.ImageStream = CType(resources.GetObject("ImageListErrorProvider.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListErrorProvider.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListErrorProvider.Images.SetKeyName(0, "ERROR")
        Me.ImageListErrorProvider.Images.SetKeyName(1, "WARNING")
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Label38)
        Me.Panel2.Controls.Add(Me.txtPatientID)
        Me.Panel2.Location = New System.Drawing.Point(1050, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(121, 21)
        Me.Panel2.TabIndex = 257
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(3, 3)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(50, 13)
        Me.Label38.TabIndex = 247
        Me.Label38.Text = "Patient #"
        '
        'TimerSearch
        '
        Me.TimerSearch.Interval = 250
        '
        'TimerSearchFocus
        '
        Me.TimerSearchFocus.Interval = 200
        '
        'TimerDetails
        '
        Me.TimerDetails.Interval = 500
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuItem2.Text = "Scheduled"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Image = CType(resources.GetObject("ToolStripMenuItem4.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuItem4.Text = "Complete"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Image = CType(resources.GetObject("ToolStripMenuItem5.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuItem5.Text = "Results received"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.txtDummy)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1036, 6)
        Me.Panel1.TabIndex = 258
        '
        'txtDummy
        '
        Me.txtDummy.Location = New System.Drawing.Point(389, -100)
        Me.txtDummy.Name = "txtDummy"
        Me.txtDummy.Size = New System.Drawing.Size(100, 20)
        Me.txtDummy.TabIndex = 259
        '
        'TimerSearchPatients
        '
        Me.TimerSearchPatients.Interval = 300
        '
        'TimerRefreshWhenMaximized
        '
        Me.TimerRefreshWhenMaximized.Interval = 200
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip5.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip5.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripFontIncrease, Me.ToolStripFonrDecrease})
        Me.ToolStrip5.Location = New System.Drawing.Point(972, 1)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip5.Size = New System.Drawing.Size(56, 25)
        Me.ToolStrip5.TabIndex = 370
        Me.ToolStrip5.Text = "ToolStrip5"
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
        'PrintDocument1
        '
        '
        'PrintDialog2
        '
        Me.PrintDialog2.Document = Me.PrintDocument1
        Me.PrintDialog2.UseEXDialog = True
        '
        'PanelWait
        '
        Me.PanelWait.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelWait.BackColor = System.Drawing.Color.White
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.Label66)
        Me.PanelWait.Location = New System.Drawing.Point(399, 271)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(238, 27)
        Me.PanelWait.TabIndex = 371
        Me.PanelWait.Visible = False
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label66.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label66.ForeColor = System.Drawing.Color.White
        Me.Label66.Location = New System.Drawing.Point(0, 0)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(236, 25)
        Me.Label66.TabIndex = 0
        Me.Label66.Text = "Validating Address. Please wait..."
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPatient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1036, 569)
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.ToolStrip5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PanelSearch)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1044, 600)
        Me.Name = "frmPatient"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Patient Maintenance"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout
        Me.ToolStripProcedures.ResumeLayout(False)
        Me.ToolStripProcedures.PerformLayout
        Me.ContextMenuStripProcedures.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout
        Me.ToolStrip7.ResumeLayout(False)
        Me.ToolStrip7.PerformLayout
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).EndInit
        Me.ContextMenuStripTime.ResumeLayout(False)
        Me.ContextMenuPopUpCalendar.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout
        Me.PanelWC.ResumeLayout(False)
        Me.PanelWC.PerformLayout
        CType(Me.WCIcon, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout
        Me.PanelInsurance.ResumeLayout(False)
        Me.PanelInsurance.PerformLayout
        Me.TabPage9.ResumeLayout(False)
        Me.PanelSecondaryInsurance.ResumeLayout(False)
        Me.PanelSecondaryInsurance.PerformLayout
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout
        CType(Me.PictureBoxRefCompany, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBoxRefDoctor, System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout
        Me.MenuPDFRotate.ResumeLayout(False)
        Me.PanelDocumentWait.ResumeLayout(False)
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit
        Me.ContextMenuStripDocuments.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout
        Me.TabPageReadings.ResumeLayout(False)
        Me.TabPageReadings.PerformLayout
        Me.ToolStripFontSize.ResumeLayout(False)
        Me.ToolStripFontSize.PerformLayout
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout
        Me.ContextMenuStripReadings.ResumeLayout(False)
        Me.TabPageBills.ResumeLayout(False)
        Me.TabPageBills.PerformLayout
        Me.ToolStrip8.ResumeLayout(False)
        Me.ToolStrip8.PerformLayout
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.TabPageLog.ResumeLayout(False)
        Me.TabPageLog.PerformLayout
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout
        Me.ToolStrip6.ResumeLayout(False)
        Me.ToolStrip6.PerformLayout
        Me.TabPageExamination.ResumeLayout(False)
        Me.TabPageExamination.PerformLayout
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout
        Me.ToolStrip9.ResumeLayout(False)
        Me.ToolStrip9.PerformLayout
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel3.ResumeLayout(False)
        Me.PanelPrinting.ResumeLayout(False)
        Me.PanelPrinting.PerformLayout
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelSearch.ResumeLayout(False)
        Me.PanelSearch.PerformLayout
        Me.ContextMenuStrip3.ResumeLayout(False)
        CType(Me.imgWait1, System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout
        Me.PanelWait.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout

    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        FormsCollection.Forms.Add(Me)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage

    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LabelDOB As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ListViewPatients As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TimerLoad As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPageLog As System.Windows.Forms.TabPage
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents ListViewComments As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents ListViewPatientLog As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents LabelInsuranceCompany As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents LabelEffectiveDate As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxNoMoreAppointmentsInd As System.Windows.Forms.CheckBox
    Friend WithEvents lblNoMoreAppointmentsInd As System.Windows.Forms.Label
    Friend WithEvents ListViewProcedures As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageListProcedures As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripProcedures As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonAddProcedure As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonDeleteProcedure As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdAddInsuranceAddress As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonAddComments As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListViewDocs As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TimerPdfRefresh As System.Windows.Forms.Timer
    Friend WithEvents ToolStripButtonEmail As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonSaveAs As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PanelSearch As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ComboBoxCaseTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxSex As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxState As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxMaritalStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxEmploymentStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxSearchCaseStatus As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxRelationToInsuredID As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxPolicyHolderState As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxReferringDoctor As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxInjuryID As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxReferringCompanyID As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxTransportationCompanyID As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxPatientTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxRelationToInsuredID1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxInsuranceCompanyID1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxPolicyHolderState1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxCaseStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxClaimAddress As System.Windows.Forms.ComboBox
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents txtLName As System.Windows.Forms.TextBox
    Friend WithEvents txtMI As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployerName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployerAddress As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCommentView As System.Windows.Forms.TextBox
    Friend WithEvents txtAdjuster As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyHolderFName As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyHolderMI As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyHolderLName As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyHolderAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyHolderCity As System.Windows.Forms.TextBox
    Friend WithEvents txtFieldsChanged As System.Windows.Forms.TextBox
    Friend WithEvents txtAdjusterComments As System.Windows.Forms.TextBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtClaimNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtInsertedDT As System.Windows.Forms.TextBox
    Friend WithEvents txtPatientID As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyNumber1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyHolderFName1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyHolderAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyHolderMI1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyHolderLName1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyHolderCity1 As System.Windows.Forms.TextBox
    Friend WithEvents txtOccupation As System.Windows.Forms.TextBox
    Friend WithEvents txtGroupNumber1 As System.Windows.Forms.TextBox
    Friend WithEvents txtGroupNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtIDNumber1 As System.Windows.Forms.TextBox
    Friend WithEvents txtIDNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtDOA As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDOB As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSSN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtZip As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCellPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPhone2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPhone1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtEmployerPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtAdjusterPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPolicyHolderPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPolicyHolderZip As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtClaimEffectiveDT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPolicyHolderPhone1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPolicyHolderZip1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ImageListErrorProvider As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PrintPatientsInformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPatientsFileLabelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonTools As System.Windows.Forms.Button
    Friend WithEvents TabPageBills As System.Windows.Forms.TabPage
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents TreeViewBills As System.Windows.Forms.TreeView
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExpandAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CollapsAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListViewPayments As System.Windows.Forms.ListView
    Friend WithEvents PaymentDT As System.Windows.Forms.ColumnHeader
    Friend WithEvents PaymentType As System.Windows.Forms.ColumnHeader
    Friend WithEvents Amount As System.Windows.Forms.ColumnHeader
    Friend WithEvents CheckNumber As System.Windows.Forms.ColumnHeader
    Friend WithEvents BillID As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListViewBillComments As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Note As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents cboBillingCompany As System.Windows.Forms.ComboBox
    Friend WithEvents TabPageReadings As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdAddReading As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBoxReading As System.Windows.Forms.TextBox
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents ListViewReadings As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColumnHeader27 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkInitialReportReceived As System.Windows.Forms.CheckBox
    Friend WithEvents TimerSearch As System.Windows.Forms.Timer
    Friend WithEvents TimerSearchFocus As System.Windows.Forms.Timer
    Friend WithEvents LabelFound As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents ListViewCancelations As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader29 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader30 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader31 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader32 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader33 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBoxRefDoctor As System.Windows.Forms.PictureBox
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxSearchCaseType As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonScannDocument As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonDeleteDocument As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents imgWait1 As System.Windows.Forms.PictureBox
    Friend WithEvents TimerDetails As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListViewActions As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader34 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader35 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader36 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LabelActions As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents ListViewRequests As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader38 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader39 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader40 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader41 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader42 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader43 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader44 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader37 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkPoliceReportReceived As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxStateOfAccident As System.Windows.Forms.ComboBox
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents txtCaseStatusDT As System.Windows.Forms.TextBox
    Friend WithEvents PrintPatientsChartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreScreenFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckBoxInsuranceVerifyed As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxInsurance1Verifyed As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBoxRefCompany As System.Windows.Forms.PictureBox
    Friend WithEvents ShowAccidentRelatedPatientsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindDuplicatePatientsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtEmergencyInfo As System.Windows.Forms.TextBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents txtPolicyHolderBirthDate1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents txtPolicyHolderBirthDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPolicyHolderSSN1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents txtPolicyHolderSSN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents txtPolicyHolderOccupation1 As System.Windows.Forms.TextBox
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents txtPolicyHolderEmployerName1 As System.Windows.Forms.TextBox
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents txtPolicyHolderEmployerAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyHolderEmployerPhone1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents txtPolicyHolderOccupation As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtPolicyHolderEmployerName As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtPolicyHolderEmployerAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicyHolderEmployerPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents txtPolicyHolderOtherDependents As System.Windows.Forms.TextBox
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents txtPolicyHolderOtherDependents1 As System.Windows.Forms.TextBox
    Friend WithEvents chkNF2 As System.Windows.Forms.CheckBox
    Friend WithEvents txtNF2 As System.Windows.Forms.TextBox
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents txtTOA As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPlaceOfAccident As System.Windows.Forms.TextBox
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents txtVehicleOwner As System.Windows.Forms.TextBox
    Friend WithEvents PrintPatientsNF2FormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader54 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip6 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents ListViewPatientsRelated As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader45 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader46 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelSecondaryInsurance As System.Windows.Forms.Panel
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuScan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelInsurance As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdUnlockInsurance As System.Windows.Forms.Button
    Friend WithEvents ButtonShowInsurance As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStripProcedures As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddProcedureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveProcedureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemSchedule As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelPrinting As System.Windows.Forms.Panel
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents txtWCCaseNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents txtWCCarrierCaseNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents txtWCCarrierCode As System.Windows.Forms.TextBox
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents txtWCEmployerInsuranceCarrier As System.Windows.Forms.TextBox
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents txtWCPatientAccountNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboWCInsuranceCarrierAddressState As System.Windows.Forms.ComboBox
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents txtWCInsuranceCarrierAddressCity As System.Windows.Forms.TextBox
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents txtWCInsuranceCarrierAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtWCInsuranceCarrierAddressZip As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents LabelIME As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabPageExamination As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonEditIME As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents ListViewIME As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader52 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader55 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader56 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader64 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripButtonAddIME As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImageList4 As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader57 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboInjury As System.Windows.Forms.ComboBox
    Friend WithEvents ChangeReferringDoctorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCommentsNew As System.Windows.Forms.TextBox
    Friend WithEvents picPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip7 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonCapturePhoto As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripButtonPreview As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonPrintPhotoLabel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonDeletePhoto As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl3 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents LabelDocument As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButtonUnlockReading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripFontSize As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip8 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonShowBill As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonShowInsurance1 As System.Windows.Forms.Button
    Friend WithEvents MonthCalendarPopUp As System.Windows.Forms.MonthCalendar
    Friend WithEvents ContextMenuPopUpCalendar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateTimePickerPopUp As System.Windows.Forms.DateTimePicker
    Friend WithEvents ContextMenuStripTime As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SetTimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SetCurrentTimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CancelToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboSuffix As System.Windows.Forms.ComboBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblFileSize As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TimerSearchPatients As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FindPatientBillsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowBillsToolBarButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonCheckAddress As System.Windows.Forms.Button
    Friend WithEvents TimerRefreshWhenMaximized As System.Windows.Forms.Timer
    Friend WithEvents LabelNotesLength As System.Windows.Forms.Label
    Friend WithEvents ButtonProceduresAutosize As System.Windows.Forms.Button
    Friend WithEvents ButtonReadingsAutoSize As System.Windows.Forms.Button
    Friend WithEvents ButtonAutosizeReadings As System.Windows.Forms.Button
    Friend WithEvents ButtonAutosizeBillComments As System.Windows.Forms.Button
    Friend WithEvents ButtonAutosizePatientProfileLog As System.Windows.Forms.Button
    Friend WithEvents ButtonAutosizeCancelationLog As System.Windows.Forms.Button
    Friend WithEvents ButtonAutosizeRequestActions As System.Windows.Forms.Button
    Friend WithEvents ButtonAutosizeRequests As System.Windows.Forms.Button
    Friend WithEvents ButtonAutosizeComments As System.Windows.Forms.Button
    Friend WithEvents txtDummy As System.Windows.Forms.TextBox
    Friend WithEvents ButtonAutosizeDocuments As System.Windows.Forms.Button
    Friend WithEvents ButtonAutosizeIME As System.Windows.Forms.Button
    Friend WithEvents PrintPatientsApplicationForBenefitsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader58 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader59 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PreCertificationCompleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreCertificationNotCompleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparatorPreCertification As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LabelPreCertification As System.Windows.Forms.Label
    Friend WithEvents ComboBoxClaimAddress1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents cmdAddInsuranceAddress1 As System.Windows.Forms.Button
    Friend WithEvents txtClaimNumber1 As System.Windows.Forms.TextBox
    Friend WithEvents Label116 As System.Windows.Forms.Label
    Friend WithEvents txtAdjusterComments1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAdjusterPhone1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtAdjuster1 As System.Windows.Forms.TextBox
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents Label119 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripReadings As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader60 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Label120 As Label
    Friend WithEvents TextBoxWebPassword As TextBox
    Friend WithEvents TextBoxWebUid As TextBox
    Friend WithEvents Label121 As Label
    Friend WithEvents Label122 As Label
    Friend WithEvents TextBoxWebURL As TextBox
    Friend WithEvents ToolStrip9 As ToolStrip
    Friend WithEvents ButtonPrintWebAccess As ToolStripButton
    Friend WithEvents ButtonWebPassword As ToolStripButton
    Friend WithEvents ToolStripButtonNavigateWebAccess As ToolStripButton
    Friend WithEvents ToolStripButtonFaxWebAccessInfo As ToolStripButton
    Friend WithEvents ToolStripButtonEmailWebAccessInformation As ToolStripButton
    Friend WithEvents LabelSMS As Label
    Friend WithEvents pdfViewer As PdfiumViewer.PdfViewer
    Friend WithEvents PanelWC As Panel
    Friend WithEvents WCIcon As PictureBox
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents BtnAddPatientAttorney As Button
    Friend WithEvents cboPatientAttorney As AutoCompleteComboBox
    Friend WithEvents ComboBoxInsuranceCompanyID As AutoCompleteComboBox
    Friend WithEvents ToolStrip5 As ToolStrip
    Friend WithEvents ToolStripFontIncrease As ToolStripButton
    Friend WithEvents ToolStripFonrDecrease As ToolStripButton
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog2 As PrintDialog
    Friend WithEvents RichTextBox1 As RichTextBoxPrintCtrl
    Friend WithEvents ContextMenuStripDocuments As ContextMenuStrip
    Friend WithEvents ToolStripMenuItemRenameDocument As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemRenameDocumentBar As ToolStripSeparator
    Friend WithEvents ToolStripMenuItemDeleteDocument As ToolStripMenuItem
    Friend WithEvents NetSearchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparatorNetSearch As ToolStripSeparator
    Friend WithEvents PanelDocumentWait As Panel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Label123 As Label
    Friend WithEvents Label124 As Label
    Friend WithEvents ButtonRotatePDF As Button
    Friend WithEvents ColumnHeader47 As ColumnHeader
    Friend WithEvents MenuPDFRotate As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem13 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem14 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem15 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem16 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem8 As ToolStripMenuItem
    Friend WithEvents txtEmployerAddressZip As MaskedTextBox
    Friend WithEvents Label127 As Label
    Friend WithEvents cboEmployerAddressState As ComboBox
    Friend WithEvents Label126 As Label
    Friend WithEvents txtEmployerAddressCity As TextBox
    Friend WithEvents Label125 As Label
    Friend WithEvents ImportPatientsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ToolStripButton7 As ToolStripButton
    Friend WithEvents CheckBoxNoMoreCollection As CheckBox
    Friend WithEvents PanelWait As Panel
    Friend WithEvents Label66 As Label
End Class
