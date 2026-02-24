<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIForm1
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
        Me.components = New System.ComponentModel.Container
        Dim ColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.ColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIForm1))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Patient #", ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Patient", ""}, -1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Bill #", ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Request", ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"From", ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Request DT", ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Status", ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Status DT", ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"CDProcs", ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Type", ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Patient", ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Contact1", ""}, -1)
        Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Contact2", ""}, -1)
        Dim ListViewItem14 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Date", ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem15 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Insurance", ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.LogOffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.FullScreenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparatorNotifications = New System.Windows.Forms.ToolStripSeparator
        Me.ShowNotificationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowRequestsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemToBeScheduled = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator37 = New System.Windows.Forms.ToolStripSeparator
        Me.ShowSmallToolBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowPrintIntakeFormButtonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator38 = New System.Windows.Forms.ToolStripSeparator
        Me.ShowImagesOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowTextOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowImagesAndTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator34 = New System.Windows.Forms.ToolStripSeparator
        Me.BackgrounfdColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem23 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem24 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem25 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem26 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem29 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem27 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem28 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator35 = New System.Windows.Forms.ToolStripSeparator
        Me.CustomColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator33 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPatientIntakeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator32 = New System.Windows.Forms.ToolStripSeparator
        Me.QuickScheduleReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintTodaysScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemTransportationRequest = New System.Windows.Forms.ToolStripMenuItem
        Me.PatientsScheduleReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem20 = New System.Windows.Forms.ToolStripMenuItem
        Me.ProceduresToBeRescheduledReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PatientInformationReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem
        Me.TodaysScheduledProceduresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SignInSheetByDateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SignInSheetByPatientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageDiskReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PatientsProcedureReadingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MRIDataExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator
        Me.NoFaultMissingClaimNumberReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NoFaultMissingInformationReceivedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InsuranceStatisticsReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TreatmentStatisticReport = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.QuickSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PatientsSearchToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewPatientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.SchedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScheduleMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TechScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemProceduresSchedule = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.BillingToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem
        Me.InHouseBillingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BillingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BillMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.POMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FindPOMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator30 = New System.Windows.Forms.ToolStripSeparator
        Me.InsuranceVerificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator
        Me.OutBillingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator
        Me.PatientsProcedureReadingsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator
        Me.PatientsNF2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.FindCheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemTodayPayments = New System.Windows.Forms.ToolStripMenuItem
        Me.PaymentsProgressAnalysisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CollectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemCollection = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator31 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemReadyForArbitration = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator36 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem21 = New System.Windows.Forms.ToolStripMenuItem
        Me.CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator39 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem22 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.RequestImageDiskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.ProduceDiskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageDisksProcessScanPOMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemCDReport = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.FindDuplicatePatientsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AdminMessagingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AdministrativeToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOfficesCompaniesMaintenance = New System.Windows.Forms.ToolStripMenuItem
        Me.OfficesMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEmployeeMaintenance = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.ReferringOfficesMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReferringOfficesStatisticReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InsurancesMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TransportationMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BillingCompaniesMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AttorneyMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemOTMaintenance = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdminStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuDiagnosticsProceduresMaintenance = New System.Windows.Forms.ToolStripMenuItem
        Me.DiagnosticsMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProcedureMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DiagnosisMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InjuryTypesMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdminStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuUnlockPatientProfiles = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdminStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemRequestsMaintenance = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripBillingPaymentManagementReport = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBankDepositsAdmin = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdminStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemChangePatientInformation = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangeBillingProviderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangeTreatingProviderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangeRefferingDoctorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.PatientProcedureInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ResetPatientInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem17 = New System.Windows.Forms.ToolStripMenuItem
        Me.BillingTemplatesMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PhoneBookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MessagePoolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ScannerDocumentMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem
        Me.AnnouncementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemLetterHead = New System.Windows.Forms.ToolStripMenuItem
        Me.BulkEmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EmailerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator29 = New System.Windows.Forms.ToolStripSeparator
        Me.EmailerMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.SecuritySettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator40 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem30 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemWeb = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemBookMarkManager = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.CheckBoxDoNotShowBills = New System.Windows.Forms.CheckBox
        Me.CheckBoxDoNotShowRequests = New System.Windows.Forms.CheckBox
        Me.ShowToBeScheduled = New System.Windows.Forms.CheckBox
        Me.PictureBoxClose = New System.Windows.Forms.PictureBox
        Me.Timer5Sec = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.DBStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblOffice = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusDBServer = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblOfficeType = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblServer = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblUserName = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblPosition = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblDate = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblTime = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripButtonSchedule = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonPatientProfile = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonSearch = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripButtonIntakeForm = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonPatSearchAndTools = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonInsuranceMainenance = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonBilling = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonBillMaintenance = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonCollection = New System.Windows.Forms.ToolStripButton
        Me.ImageListTray = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PanelRequests = New System.Windows.Forms.Panel
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.ListViewrequestActions = New System.Windows.Forms.ListView
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ListViewRequestsDetails = New System.Windows.Forms.ListView
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ListViewRequests = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStripRequest = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripMenuItem
        Me.PictureBoxPanelReminders = New System.Windows.Forms.PictureBox
        Me.PictureBoxPanelBills = New System.Windows.Forms.PictureBox
        Me.TimerRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.TimerReminderReset = New System.Windows.Forms.Timer(Me.components)
        Me.PanelBills = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ListViewBills = New System.Windows.Forms.ListView
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStripProcessBills = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem18 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator27 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem19 = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.ListViewNF2 = New System.Windows.Forms.ListView
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStripNF2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuShowSelectedPatientInfo1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuPrinting1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripMenuItem
        Me.TimerFlashRedBall = New System.Windows.Forms.Timer(Me.components)
        Me.PanelSchedule = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.PictureBoxSchedule = New System.Windows.Forms.PictureBox
        Me.SplitContainerEUOIME = New System.Windows.Forms.SplitContainer
        Me.ListViewSchedule = New System.Windows.Forms.ListView
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStripWarning = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripMenuItem
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEUOComments = New System.Windows.Forms.TextBox
        Me.ListViewEUODetails = New System.Windows.Forms.ListView
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader17 = New System.Windows.Forms.ColumnHeader
        Me.Label4 = New System.Windows.Forms.Label
        Me.ListViewEUOIME = New System.Windows.Forms.ListView
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton
        Me.TimerAutoUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.ImageListDBStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.PanelMessage = New System.Windows.Forms.Panel
        Me.lblMessage = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblMessageTitle = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.ToolStrip6 = New System.Windows.Forms.ToolStrip
        Me.PictureBoxGlobe = New System.Windows.Forms.PictureBox
        Me.MenuStrip.SuspendLayout()
        CType(Me.PictureBoxClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.PanelRequests.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.ContextMenuStripRequest.SuspendLayout()
        CType(Me.PictureBoxPanelReminders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxPanelBills, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBills.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStripProcessBills.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ContextMenuStripNF2.SuspendLayout()
        Me.PanelSchedule.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBoxSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerEUOIME.Panel1.SuspendLayout()
        Me.SplitContainerEUOIME.Panel2.SuspendLayout()
        Me.SplitContainerEUOIME.SuspendLayout()
        Me.ContextMenuStripWarning.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.PanelMessage.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxGlobe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ColumnHeaderRenderer2.Name = "ColumnHeaderRenderer2"
        ColumnHeaderRenderer2.TextRotationAngle = 0
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ToolStripMenuItem1, Me.ReportsToolStripMenuItem1, Me.ToolsMenu, Me.ToolStripMenuItemWeb, Me.WindowsMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1260, 24)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogOffToolStripMenuItem, Me.ToolStripSeparator12, Me.ExitToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(37, 20)
        Me.FileMenu.Text = "&File"
        '
        'LogOffToolStripMenuItem
        '
        Me.LogOffToolStripMenuItem.Image = CType(resources.GetObject("LogOffToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LogOffToolStripMenuItem.Name = "LogOffToolStripMenuItem"
        Me.LogOffToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.LogOffToolStripMenuItem.Text = "Log Off"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(111, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FullScreenToolStripMenuItem, Me.ToolStripSeparatorNotifications, Me.ShowNotificationsToolStripMenuItem, Me.ShowRequestsToolStripMenuItem, Me.ToolStripMenuItemToBeScheduled, Me.ToolStripSeparator37, Me.ShowSmallToolBarToolStripMenuItem, Me.ToolStripSeparator34, Me.BackgrounfdColorToolStripMenuItem, Me.ToolStripSeparator33, Me.ToolStripButton9})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(44, 20)
        Me.ToolStripMenuItem1.Text = "&View"
        '
        'FullScreenToolStripMenuItem
        '
        Me.FullScreenToolStripMenuItem.Image = CType(resources.GetObject("FullScreenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FullScreenToolStripMenuItem.Name = "FullScreenToolStripMenuItem"
        Me.FullScreenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11
        Me.FullScreenToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.FullScreenToolStripMenuItem.Text = "&Full Screen"
        '
        'ToolStripSeparatorNotifications
        '
        Me.ToolStripSeparatorNotifications.Name = "ToolStripSeparatorNotifications"
        Me.ToolStripSeparatorNotifications.Size = New System.Drawing.Size(300, 6)
        '
        'ShowNotificationsToolStripMenuItem
        '
        Me.ShowNotificationsToolStripMenuItem.Checked = True
        Me.ShowNotificationsToolStripMenuItem.CheckOnClick = True
        Me.ShowNotificationsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowNotificationsToolStripMenuItem.Name = "ShowNotificationsToolStripMenuItem"
        Me.ShowNotificationsToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.ShowNotificationsToolStripMenuItem.Text = "Show Bills/NF2 Notifications"
        '
        'ShowRequestsToolStripMenuItem
        '
        Me.ShowRequestsToolStripMenuItem.Checked = True
        Me.ShowRequestsToolStripMenuItem.CheckOnClick = True
        Me.ShowRequestsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowRequestsToolStripMenuItem.Name = "ShowRequestsToolStripMenuItem"
        Me.ShowRequestsToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.ShowRequestsToolStripMenuItem.Text = "Show Requests Notifications"
        '
        'ToolStripMenuItemToBeScheduled
        '
        Me.ToolStripMenuItemToBeScheduled.Checked = True
        Me.ToolStripMenuItemToBeScheduled.CheckOnClick = True
        Me.ToolStripMenuItemToBeScheduled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItemToBeScheduled.Name = "ToolStripMenuItemToBeScheduled"
        Me.ToolStripMenuItemToBeScheduled.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItemToBeScheduled.Text = "Show ReSchedule / EUO / IME Notifications"
        '
        'ToolStripSeparator37
        '
        Me.ToolStripSeparator37.Name = "ToolStripSeparator37"
        Me.ToolStripSeparator37.Size = New System.Drawing.Size(300, 6)
        '
        'ShowSmallToolBarToolStripMenuItem
        '
        Me.ShowSmallToolBarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowPrintIntakeFormButtonToolStripMenuItem, Me.ToolStripSeparator38, Me.ShowImagesOnlyToolStripMenuItem, Me.ShowTextOnlyToolStripMenuItem, Me.ShowImagesAndTextToolStripMenuItem})
        Me.ShowSmallToolBarToolStripMenuItem.Image = CType(resources.GetObject("ShowSmallToolBarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ShowSmallToolBarToolStripMenuItem.Name = "ShowSmallToolBarToolStripMenuItem"
        Me.ShowSmallToolBarToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.ShowSmallToolBarToolStripMenuItem.Text = "Tool Bar"
        '
        'ShowPrintIntakeFormButtonToolStripMenuItem
        '
        Me.ShowPrintIntakeFormButtonToolStripMenuItem.CheckOnClick = True
        Me.ShowPrintIntakeFormButtonToolStripMenuItem.Image = CType(resources.GetObject("ShowPrintIntakeFormButtonToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ShowPrintIntakeFormButtonToolStripMenuItem.Name = "ShowPrintIntakeFormButtonToolStripMenuItem"
        Me.ShowPrintIntakeFormButtonToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.ShowPrintIntakeFormButtonToolStripMenuItem.Text = "Show Print Intake Form Button"
        '
        'ToolStripSeparator38
        '
        Me.ToolStripSeparator38.Name = "ToolStripSeparator38"
        Me.ToolStripSeparator38.Size = New System.Drawing.Size(233, 6)
        '
        'ShowImagesOnlyToolStripMenuItem
        '
        Me.ShowImagesOnlyToolStripMenuItem.Name = "ShowImagesOnlyToolStripMenuItem"
        Me.ShowImagesOnlyToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.ShowImagesOnlyToolStripMenuItem.Text = "Show Images Only"
        '
        'ShowTextOnlyToolStripMenuItem
        '
        Me.ShowTextOnlyToolStripMenuItem.Name = "ShowTextOnlyToolStripMenuItem"
        Me.ShowTextOnlyToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.ShowTextOnlyToolStripMenuItem.Text = "Show Text Only"
        '
        'ShowImagesAndTextToolStripMenuItem
        '
        Me.ShowImagesAndTextToolStripMenuItem.Name = "ShowImagesAndTextToolStripMenuItem"
        Me.ShowImagesAndTextToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.ShowImagesAndTextToolStripMenuItem.Text = "Show Images And Text"
        '
        'ToolStripSeparator34
        '
        Me.ToolStripSeparator34.Name = "ToolStripSeparator34"
        Me.ToolStripSeparator34.Size = New System.Drawing.Size(300, 6)
        Me.ToolStripSeparator34.Visible = False
        '
        'BackgrounfdColorToolStripMenuItem
        '
        Me.BackgrounfdColorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem23, Me.ToolStripMenuItem24, Me.ToolStripMenuItem25, Me.ToolStripMenuItem26, Me.ToolStripMenuItem29, Me.ToolStripMenuItem27, Me.ToolStripMenuItem28, Me.ToolStripSeparator35, Me.CustomColorToolStripMenuItem})
        Me.BackgrounfdColorToolStripMenuItem.Image = CType(resources.GetObject("BackgrounfdColorToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BackgrounfdColorToolStripMenuItem.Name = "BackgrounfdColorToolStripMenuItem"
        Me.BackgrounfdColorToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.BackgrounfdColorToolStripMenuItem.Text = "BackGround Color"
        Me.BackgrounfdColorToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem23
        '
        Me.ToolStripMenuItem23.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStripMenuItem23.Name = "ToolStripMenuItem23"
        Me.ToolStripMenuItem23.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem23.Text = "White Smoke"
        '
        'ToolStripMenuItem24
        '
        Me.ToolStripMenuItem24.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolStripMenuItem24.Name = "ToolStripMenuItem24"
        Me.ToolStripMenuItem24.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem24.Text = "Gainsboro"
        '
        'ToolStripMenuItem25
        '
        Me.ToolStripMenuItem25.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ToolStripMenuItem25.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem25.Name = "ToolStripMenuItem25"
        Me.ToolStripMenuItem25.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem25.Text = "App Workspace"
        '
        'ToolStripMenuItem26
        '
        Me.ToolStripMenuItem26.BackColor = System.Drawing.Color.DimGray
        Me.ToolStripMenuItem26.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem26.Name = "ToolStripMenuItem26"
        Me.ToolStripMenuItem26.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem26.Text = "Dim Gray"
        '
        'ToolStripMenuItem29
        '
        Me.ToolStripMenuItem29.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStripMenuItem29.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem29.Name = "ToolStripMenuItem29"
        Me.ToolStripMenuItem29.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem29.Text = "Light Steel Blue"
        '
        'ToolStripMenuItem27
        '
        Me.ToolStripMenuItem27.BackColor = System.Drawing.Color.SlateGray
        Me.ToolStripMenuItem27.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem27.Name = "ToolStripMenuItem27"
        Me.ToolStripMenuItem27.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem27.Text = "Slate Gray"
        '
        'ToolStripMenuItem28
        '
        Me.ToolStripMenuItem28.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ToolStripMenuItem28.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem28.Name = "ToolStripMenuItem28"
        Me.ToolStripMenuItem28.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem28.Text = "Dark Slate Gray"
        '
        'ToolStripSeparator35
        '
        Me.ToolStripSeparator35.Name = "ToolStripSeparator35"
        Me.ToolStripSeparator35.Size = New System.Drawing.Size(154, 6)
        '
        'CustomColorToolStripMenuItem
        '
        Me.CustomColorToolStripMenuItem.Image = CType(resources.GetObject("CustomColorToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CustomColorToolStripMenuItem.Name = "CustomColorToolStripMenuItem"
        Me.CustomColorToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.CustomColorToolStripMenuItem.Text = "Custom Color"
        '
        'ToolStripSeparator33
        '
        Me.ToolStripSeparator33.Name = "ToolStripSeparator33"
        Me.ToolStripSeparator33.Size = New System.Drawing.Size(300, 6)
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.ToolStripButton9.Size = New System.Drawing.Size(311, 20)
        Me.ToolStripButton9.Text = "Restore Default Workspace Settings"
        '
        'ReportsToolStripMenuItem1
        '
        Me.ReportsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintPatientIntakeToolStripMenuItem, Me.ToolStripSeparator32, Me.QuickScheduleReportToolStripMenuItem, Me.PrintTodaysScheduleToolStripMenuItem, Me.ToolStripMenuItemTransportationRequest, Me.PatientsScheduleReportToolStripMenuItem, Me.ToolStripMenuItem20, Me.ProceduresToBeRescheduledReportToolStripMenuItem, Me.PatientInformationReportToolStripMenuItem, Me.ToolStripSeparator20, Me.ToolStripMenuItem9, Me.TodaysScheduledProceduresToolStripMenuItem, Me.ImageDiskReportToolStripMenuItem, Me.PatientsProcedureReadingsToolStripMenuItem, Me.MRIDataExportToolStripMenuItem, Me.ToolStripSeparator16, Me.NoFaultMissingClaimNumberReportToolStripMenuItem, Me.NoFaultMissingInformationReceivedToolStripMenuItem, Me.InsuranceStatisticsReportToolStripMenuItem, Me.TreatmentStatisticReport, Me.ToolStripMenuItem11, Me.ToolStripMenuItem12})
        Me.ReportsToolStripMenuItem1.Name = "ReportsToolStripMenuItem1"
        Me.ReportsToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ReportsToolStripMenuItem1.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem1.Text = "&Reports"
        '
        'PrintPatientIntakeToolStripMenuItem
        '
        Me.PrintPatientIntakeToolStripMenuItem.BackColor = System.Drawing.Color.Azure
        Me.PrintPatientIntakeToolStripMenuItem.Image = CType(resources.GetObject("PrintPatientIntakeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPatientIntakeToolStripMenuItem.Name = "PrintPatientIntakeToolStripMenuItem"
        Me.PrintPatientIntakeToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.PrintPatientIntakeToolStripMenuItem.Text = "Print Patient Intake Form"
        '
        'ToolStripSeparator32
        '
        Me.ToolStripSeparator32.Name = "ToolStripSeparator32"
        Me.ToolStripSeparator32.Size = New System.Drawing.Size(276, 6)
        '
        'QuickScheduleReportToolStripMenuItem
        '
        Me.QuickScheduleReportToolStripMenuItem.Image = CType(resources.GetObject("QuickScheduleReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.QuickScheduleReportToolStripMenuItem.Name = "QuickScheduleReportToolStripMenuItem"
        Me.QuickScheduleReportToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.QuickScheduleReportToolStripMenuItem.Tag = "1"
        Me.QuickScheduleReportToolStripMenuItem.Text = "Quick Schedule Report"
        '
        'PrintTodaysScheduleToolStripMenuItem
        '
        Me.PrintTodaysScheduleToolStripMenuItem.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.PrintTodaysScheduleToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PrintTodaysScheduleToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.PrintTodaysScheduleToolStripMenuItem.Image = CType(resources.GetObject("PrintTodaysScheduleToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintTodaysScheduleToolStripMenuItem.Name = "PrintTodaysScheduleToolStripMenuItem"
        Me.PrintTodaysScheduleToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.PrintTodaysScheduleToolStripMenuItem.Tag = "2"
        Me.PrintTodaysScheduleToolStripMenuItem.Text = "Print Today Schedule"
        '
        'ToolStripMenuItemTransportationRequest
        '
        Me.ToolStripMenuItemTransportationRequest.Image = CType(resources.GetObject("ToolStripMenuItemTransportationRequest.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemTransportationRequest.Name = "ToolStripMenuItemTransportationRequest"
        Me.ToolStripMenuItemTransportationRequest.Size = New System.Drawing.Size(279, 22)
        Me.ToolStripMenuItemTransportationRequest.Tag = "1"
        Me.ToolStripMenuItemTransportationRequest.Text = "&Transportation Request"
        '
        'PatientsScheduleReportToolStripMenuItem
        '
        Me.PatientsScheduleReportToolStripMenuItem.Image = CType(resources.GetObject("PatientsScheduleReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PatientsScheduleReportToolStripMenuItem.Name = "PatientsScheduleReportToolStripMenuItem"
        Me.PatientsScheduleReportToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.PatientsScheduleReportToolStripMenuItem.Tag = "1"
        Me.PatientsScheduleReportToolStripMenuItem.Text = "Patients &Attendance Report"
        '
        'ToolStripMenuItem20
        '
        Me.ToolStripMenuItem20.Image = CType(resources.GetObject("ToolStripMenuItem20.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem20.Name = "ToolStripMenuItem20"
        Me.ToolStripMenuItem20.Size = New System.Drawing.Size(279, 22)
        Me.ToolStripMenuItem20.Tag = "1"
        Me.ToolStripMenuItem20.Text = "Patient Cancel Reschedule Report"
        '
        'ProceduresToBeRescheduledReportToolStripMenuItem
        '
        Me.ProceduresToBeRescheduledReportToolStripMenuItem.Image = CType(resources.GetObject("ProceduresToBeRescheduledReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ProceduresToBeRescheduledReportToolStripMenuItem.Name = "ProceduresToBeRescheduledReportToolStripMenuItem"
        Me.ProceduresToBeRescheduledReportToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.ProceduresToBeRescheduledReportToolStripMenuItem.Tag = "1"
        Me.ProceduresToBeRescheduledReportToolStripMenuItem.Text = "Procedures To Be Rescheduled Report"
        '
        'PatientInformationReportToolStripMenuItem
        '
        Me.PatientInformationReportToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PatientInformationReportToolStripMenuItem.Image = CType(resources.GetObject("PatientInformationReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PatientInformationReportToolStripMenuItem.Name = "PatientInformationReportToolStripMenuItem"
        Me.PatientInformationReportToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.PatientInformationReportToolStripMenuItem.Tag = ""
        Me.PatientInformationReportToolStripMenuItem.Text = "&Patient Information Report"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(276, 6)
        Me.ToolStripSeparator20.Tag = "2"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Image = CType(resources.GetObject("ToolStripMenuItem9.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(279, 22)
        Me.ToolStripMenuItem9.Tag = "2"
        Me.ToolStripMenuItem9.Text = "Patient Missing Information Report"
        '
        'TodaysScheduledProceduresToolStripMenuItem
        '
        Me.TodaysScheduledProceduresToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SignInSheetByDateToolStripMenuItem, Me.SignInSheetByPatientToolStripMenuItem})
        Me.TodaysScheduledProceduresToolStripMenuItem.Image = CType(resources.GetObject("TodaysScheduledProceduresToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TodaysScheduledProceduresToolStripMenuItem.Name = "TodaysScheduledProceduresToolStripMenuItem"
        Me.TodaysScheduledProceduresToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.TodaysScheduledProceduresToolStripMenuItem.Tag = "1"
        Me.TodaysScheduledProceduresToolStripMenuItem.Text = "Sign In Sheet"
        '
        'SignInSheetByDateToolStripMenuItem
        '
        Me.SignInSheetByDateToolStripMenuItem.Name = "SignInSheetByDateToolStripMenuItem"
        Me.SignInSheetByDateToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.SignInSheetByDateToolStripMenuItem.Text = "Sign In Sheet By Date"
        '
        'SignInSheetByPatientToolStripMenuItem
        '
        Me.SignInSheetByPatientToolStripMenuItem.Name = "SignInSheetByPatientToolStripMenuItem"
        Me.SignInSheetByPatientToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.SignInSheetByPatientToolStripMenuItem.Text = "Sign In Sheet By Patient"
        '
        'ImageDiskReportToolStripMenuItem
        '
        Me.ImageDiskReportToolStripMenuItem.Image = CType(resources.GetObject("ImageDiskReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImageDiskReportToolStripMenuItem.Name = "ImageDiskReportToolStripMenuItem"
        Me.ImageDiskReportToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.ImageDiskReportToolStripMenuItem.Tag = "1"
        Me.ImageDiskReportToolStripMenuItem.Text = "Image Disk Report"
        '
        'PatientsProcedureReadingsToolStripMenuItem
        '
        Me.PatientsProcedureReadingsToolStripMenuItem.Image = CType(resources.GetObject("PatientsProcedureReadingsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PatientsProcedureReadingsToolStripMenuItem.Name = "PatientsProcedureReadingsToolStripMenuItem"
        Me.PatientsProcedureReadingsToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.PatientsProcedureReadingsToolStripMenuItem.Tag = "1"
        Me.PatientsProcedureReadingsToolStripMenuItem.Text = "Patient's Procedure Readings"
        '
        'MRIDataExportToolStripMenuItem
        '
        Me.MRIDataExportToolStripMenuItem.Image = CType(resources.GetObject("MRIDataExportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MRIDataExportToolStripMenuItem.Name = "MRIDataExportToolStripMenuItem"
        Me.MRIDataExportToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.MRIDataExportToolStripMenuItem.Tag = "1"
        Me.MRIDataExportToolStripMenuItem.Text = "MRI Data Export"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(276, 6)
        Me.ToolStripSeparator16.Tag = "1"
        '
        'NoFaultMissingClaimNumberReportToolStripMenuItem
        '
        Me.NoFaultMissingClaimNumberReportToolStripMenuItem.Image = CType(resources.GetObject("NoFaultMissingClaimNumberReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NoFaultMissingClaimNumberReportToolStripMenuItem.Name = "NoFaultMissingClaimNumberReportToolStripMenuItem"
        Me.NoFaultMissingClaimNumberReportToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.NoFaultMissingClaimNumberReportToolStripMenuItem.Tag = "1"
        Me.NoFaultMissingClaimNumberReportToolStripMenuItem.Text = "NoFault Missing Information Report"
        '
        'NoFaultMissingInformationReceivedToolStripMenuItem
        '
        Me.NoFaultMissingInformationReceivedToolStripMenuItem.Image = CType(resources.GetObject("NoFaultMissingInformationReceivedToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NoFaultMissingInformationReceivedToolStripMenuItem.Name = "NoFaultMissingInformationReceivedToolStripMenuItem"
        Me.NoFaultMissingInformationReceivedToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.NoFaultMissingInformationReceivedToolStripMenuItem.Tag = "1"
        Me.NoFaultMissingInformationReceivedToolStripMenuItem.Text = "No Fault Missing Information Received"
        '
        'InsuranceStatisticsReportToolStripMenuItem
        '
        Me.InsuranceStatisticsReportToolStripMenuItem.Image = CType(resources.GetObject("InsuranceStatisticsReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InsuranceStatisticsReportToolStripMenuItem.Name = "InsuranceStatisticsReportToolStripMenuItem"
        Me.InsuranceStatisticsReportToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.InsuranceStatisticsReportToolStripMenuItem.Tag = ""
        Me.InsuranceStatisticsReportToolStripMenuItem.Text = "Insurance Statistics Report"
        '
        'TreatmentStatisticReport
        '
        Me.TreatmentStatisticReport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TreatmentStatisticReport.ForeColor = System.Drawing.Color.Black
        Me.TreatmentStatisticReport.Image = CType(resources.GetObject("TreatmentStatisticReport.Image"), System.Drawing.Image)
        Me.TreatmentStatisticReport.Name = "TreatmentStatisticReport"
        Me.TreatmentStatisticReport.Size = New System.Drawing.Size(279, 22)
        Me.TreatmentStatisticReport.Tag = "2"
        Me.TreatmentStatisticReport.Text = "Patients Treatment Statistic Report"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Image = CType(resources.GetObject("ToolStripMenuItem11.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(279, 22)
        Me.ToolStripMenuItem11.Tag = "2"
        Me.ToolStripMenuItem11.Text = "Patient Procedures Report"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Image = CType(resources.GetObject("ToolStripMenuItem12.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(279, 22)
        Me.ToolStripMenuItem12.Tag = "2"
        Me.ToolStripMenuItem12.Text = "Patient IME / EUO Report"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuickSearchToolStripMenuItem, Me.PatientsSearchToolsToolStripMenuItem, Me.NewPatientToolStripMenuItem, Me.ToolStripSeparator6, Me.SchedToolStripMenuItem, Me.ScheduleMaintenanceToolStripMenuItem, Me.TechScheduleToolStripMenuItem, Me.ToolStripMenuItemProceduresSchedule, Me.ToolStripSeparator7, Me.BillingToolStripMenuItem1, Me.CollectionToolStripMenuItem, Me.ToolStripSeparator10, Me.ToolStripMenuItem4, Me.ToolStripSeparator1, Me.FindDuplicatePatientsToolStripMenuItem, Me.SearchToolStripMenuItem, Me.AdminMessagingToolStripMenuItem, Me.AdministrativeToolsToolStripMenuItem})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(48, 20)
        Me.ToolsMenu.Text = "&Tools"
        '
        'QuickSearchToolStripMenuItem
        '
        Me.QuickSearchToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.QuickSearchToolStripMenuItem.Image = CType(resources.GetObject("QuickSearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.QuickSearchToolStripMenuItem.Name = "QuickSearchToolStripMenuItem"
        Me.QuickSearchToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.QuickSearchToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.QuickSearchToolStripMenuItem.Text = "Quick Search"
        '
        'PatientsSearchToolsToolStripMenuItem
        '
        Me.PatientsSearchToolsToolStripMenuItem.Image = CType(resources.GetObject("PatientsSearchToolsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PatientsSearchToolsToolStripMenuItem.Name = "PatientsSearchToolsToolStripMenuItem"
        Me.PatientsSearchToolsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.PatientsSearchToolsToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.PatientsSearchToolsToolStripMenuItem.Text = "Patients Search && Tools"
        '
        'NewPatientToolStripMenuItem
        '
        Me.NewPatientToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.NewPatientToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.NewPatientToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.NewPatientToolStripMenuItem.Image = CType(resources.GetObject("NewPatientToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewPatientToolStripMenuItem.Name = "NewPatientToolStripMenuItem"
        Me.NewPatientToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.NewPatientToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.NewPatientToolStripMenuItem.Text = "Patient Profile Maintenance"
        Me.NewPatientToolStripMenuItem.ToolTipText = "Patient Profile Maintenance"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(246, 6)
        '
        'SchedToolStripMenuItem
        '
        Me.SchedToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.SchedToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SchedToolStripMenuItem.ForeColor = System.Drawing.Color.Teal
        Me.SchedToolStripMenuItem.Image = CType(resources.GetObject("SchedToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SchedToolStripMenuItem.Name = "SchedToolStripMenuItem"
        Me.SchedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.SchedToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.SchedToolStripMenuItem.Tag = ""
        Me.SchedToolStripMenuItem.Text = "&Schedule"
        Me.SchedToolStripMenuItem.ToolTipText = "Show Office Schedule"
        '
        'ScheduleMaintenanceToolStripMenuItem
        '
        Me.ScheduleMaintenanceToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.ScheduleMaintenanceToolStripMenuItem.ForeColor = System.Drawing.Color.Teal
        Me.ScheduleMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("ScheduleMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ScheduleMaintenanceToolStripMenuItem.Name = "ScheduleMaintenanceToolStripMenuItem"
        Me.ScheduleMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.ScheduleMaintenanceToolStripMenuItem.Tag = "2"
        Me.ScheduleMaintenanceToolStripMenuItem.Text = "Schedule &Maintenance"
        Me.ScheduleMaintenanceToolStripMenuItem.ToolTipText = "Show Office Schedule"
        '
        'TechScheduleToolStripMenuItem
        '
        Me.TechScheduleToolStripMenuItem.Image = CType(resources.GetObject("TechScheduleToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TechScheduleToolStripMenuItem.Name = "TechScheduleToolStripMenuItem"
        Me.TechScheduleToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.TechScheduleToolStripMenuItem.Tag = "1"
        Me.TechScheduleToolStripMenuItem.Text = "Technician Schedule"
        Me.TechScheduleToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItemProceduresSchedule
        '
        Me.ToolStripMenuItemProceduresSchedule.Image = CType(resources.GetObject("ToolStripMenuItemProceduresSchedule.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemProceduresSchedule.Name = "ToolStripMenuItemProceduresSchedule"
        Me.ToolStripMenuItemProceduresSchedule.Size = New System.Drawing.Size(249, 22)
        Me.ToolStripMenuItemProceduresSchedule.Text = "Show Procedures Schedule"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(246, 6)
        '
        'BillingToolStripMenuItem1
        '
        Me.BillingToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem10, Me.InHouseBillingToolStripMenuItem, Me.ToolStripSeparator30, Me.InsuranceVerificationToolStripMenuItem, Me.ToolStripSeparator18, Me.ToolStripMenuItem5, Me.ToolStripSeparator13, Me.OutBillingToolStripMenuItem, Me.ToolStripSeparator14, Me.PatientsProcedureReadingsToolStripMenuItem1, Me.ToolStripSeparator21, Me.PatientsNF2ToolStripMenuItem, Me.ToolStripSeparator5, Me.FindCheckToolStripMenuItem, Me.ToolStripSeparator23, Me.ToolStripMenuItemTodayPayments, Me.PaymentsProgressAnalysisToolStripMenuItem})
        Me.BillingToolStripMenuItem1.Image = CType(resources.GetObject("BillingToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.BillingToolStripMenuItem1.Name = "BillingToolStripMenuItem1"
        Me.BillingToolStripMenuItem1.Size = New System.Drawing.Size(249, 22)
        Me.BillingToolStripMenuItem1.Text = "Billing Tools"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.ForeColor = System.Drawing.Color.DarkGreen
        Me.ToolStripMenuItem10.Image = CType(resources.GetObject("ToolStripMenuItem10.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(234, 22)
        Me.ToolStripMenuItem10.Text = "Bills Management / Collection"
        '
        'InHouseBillingToolStripMenuItem
        '
        Me.InHouseBillingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BillingToolStripMenuItem, Me.BillMaintenanceToolStripMenuItem, Me.POMToolStripMenuItem, Me.FindPOMToolStripMenuItem})
        Me.InHouseBillingToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGreen
        Me.InHouseBillingToolStripMenuItem.Image = CType(resources.GetObject("InHouseBillingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InHouseBillingToolStripMenuItem.Name = "InHouseBillingToolStripMenuItem"
        Me.InHouseBillingToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.InHouseBillingToolStripMenuItem.Text = "InHouse-Billing"
        '
        'BillingToolStripMenuItem
        '
        Me.BillingToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGreen
        Me.BillingToolStripMenuItem.Image = CType(resources.GetObject("BillingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BillingToolStripMenuItem.Name = "BillingToolStripMenuItem"
        Me.BillingToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.BillingToolStripMenuItem.Text = "Billing"
        '
        'BillMaintenanceToolStripMenuItem
        '
        Me.BillMaintenanceToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGreen
        Me.BillMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("BillMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BillMaintenanceToolStripMenuItem.Name = "BillMaintenanceToolStripMenuItem"
        Me.BillMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.BillMaintenanceToolStripMenuItem.Text = "Bills Management / Collection"
        '
        'POMToolStripMenuItem
        '
        Me.POMToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGreen
        Me.POMToolStripMenuItem.Image = CType(resources.GetObject("POMToolStripMenuItem.Image"), System.Drawing.Image)
        Me.POMToolStripMenuItem.Name = "POMToolStripMenuItem"
        Me.POMToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.POMToolStripMenuItem.Text = "Scan POM"
        '
        'FindPOMToolStripMenuItem
        '
        Me.FindPOMToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGreen
        Me.FindPOMToolStripMenuItem.Image = CType(resources.GetObject("FindPOMToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FindPOMToolStripMenuItem.Name = "FindPOMToolStripMenuItem"
        Me.FindPOMToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.FindPOMToolStripMenuItem.Text = "Find POM"
        '
        'ToolStripSeparator30
        '
        Me.ToolStripSeparator30.Name = "ToolStripSeparator30"
        Me.ToolStripSeparator30.Size = New System.Drawing.Size(231, 6)
        '
        'InsuranceVerificationToolStripMenuItem
        '
        Me.InsuranceVerificationToolStripMenuItem.Image = CType(resources.GetObject("InsuranceVerificationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InsuranceVerificationToolStripMenuItem.Name = "InsuranceVerificationToolStripMenuItem"
        Me.InsuranceVerificationToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.InsuranceVerificationToolStripMenuItem.Text = "Insurance Verification"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(231, 6)
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Image = CType(resources.GetObject("ToolStripMenuItem5.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(234, 22)
        Me.ToolStripMenuItem5.Text = "Assign Atorney Case Number"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(231, 6)
        '
        'OutBillingToolStripMenuItem
        '
        Me.OutBillingToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue
        Me.OutBillingToolStripMenuItem.Image = CType(resources.GetObject("OutBillingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OutBillingToolStripMenuItem.Name = "OutBillingToolStripMenuItem"
        Me.OutBillingToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.OutBillingToolStripMenuItem.Text = "Out-Billing Maintenance"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(231, 6)
        Me.ToolStripSeparator14.Tag = "1"
        '
        'PatientsProcedureReadingsToolStripMenuItem1
        '
        Me.PatientsProcedureReadingsToolStripMenuItem1.Image = CType(resources.GetObject("PatientsProcedureReadingsToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.PatientsProcedureReadingsToolStripMenuItem1.Name = "PatientsProcedureReadingsToolStripMenuItem1"
        Me.PatientsProcedureReadingsToolStripMenuItem1.Size = New System.Drawing.Size(234, 22)
        Me.PatientsProcedureReadingsToolStripMenuItem1.Tag = "1"
        Me.PatientsProcedureReadingsToolStripMenuItem1.Text = "Patient's Procedure Readings"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(231, 6)
        '
        'PatientsNF2ToolStripMenuItem
        '
        Me.PatientsNF2ToolStripMenuItem.Image = CType(resources.GetObject("PatientsNF2ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PatientsNF2ToolStripMenuItem.Name = "PatientsNF2ToolStripMenuItem"
        Me.PatientsNF2ToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.PatientsNF2ToolStripMenuItem.Text = "Patient's NF2"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(231, 6)
        '
        'FindCheckToolStripMenuItem
        '
        Me.FindCheckToolStripMenuItem.Image = CType(resources.GetObject("FindCheckToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FindCheckToolStripMenuItem.Name = "FindCheckToolStripMenuItem"
        Me.FindCheckToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.FindCheckToolStripMenuItem.Text = "Find Check Payment"
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(231, 6)
        '
        'ToolStripMenuItemTodayPayments
        '
        Me.ToolStripMenuItemTodayPayments.Image = CType(resources.GetObject("ToolStripMenuItemTodayPayments.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemTodayPayments.Name = "ToolStripMenuItemTodayPayments"
        Me.ToolStripMenuItemTodayPayments.Size = New System.Drawing.Size(234, 22)
        Me.ToolStripMenuItemTodayPayments.Text = "Bank Deposits"
        '
        'PaymentsProgressAnalysisToolStripMenuItem
        '
        Me.PaymentsProgressAnalysisToolStripMenuItem.Image = Global.eMedicalOffice.My.Resources.Resources.chart_bar_icon
        Me.PaymentsProgressAnalysisToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PaymentsProgressAnalysisToolStripMenuItem.Name = "PaymentsProgressAnalysisToolStripMenuItem"
        Me.PaymentsProgressAnalysisToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.PaymentsProgressAnalysisToolStripMenuItem.Text = "Payments Progress Analysis"
        '
        'CollectionToolStripMenuItem
        '
        Me.CollectionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemCollection, Me.ToolStripSeparator31, Me.ToolStripMenuItemReadyForArbitration, Me.ToolStripSeparator36, Me.ToolStripMenuItem21, Me.CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem, Me.ToolStripSeparator39, Me.ToolStripMenuItem22})
        Me.CollectionToolStripMenuItem.Image = CType(resources.GetObject("CollectionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CollectionToolStripMenuItem.Name = "CollectionToolStripMenuItem"
        Me.CollectionToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.CollectionToolStripMenuItem.Text = "Collection Tools"
        '
        'ToolStripMenuItemCollection
        '
        Me.ToolStripMenuItemCollection.Image = CType(resources.GetObject("ToolStripMenuItemCollection.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemCollection.Name = "ToolStripMenuItemCollection"
        Me.ToolStripMenuItemCollection.Size = New System.Drawing.Size(350, 22)
        Me.ToolStripMenuItemCollection.Text = "Collection"
        '
        'ToolStripSeparator31
        '
        Me.ToolStripSeparator31.Name = "ToolStripSeparator31"
        Me.ToolStripSeparator31.Size = New System.Drawing.Size(347, 6)
        '
        'ToolStripMenuItemReadyForArbitration
        '
        Me.ToolStripMenuItemReadyForArbitration.Image = CType(resources.GetObject("ToolStripMenuItemReadyForArbitration.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemReadyForArbitration.Name = "ToolStripMenuItemReadyForArbitration"
        Me.ToolStripMenuItemReadyForArbitration.Size = New System.Drawing.Size(350, 22)
        Me.ToolStripMenuItemReadyForArbitration.Text = "Bills Qualified For Arbitratrion"
        '
        'ToolStripSeparator36
        '
        Me.ToolStripSeparator36.Name = "ToolStripSeparator36"
        Me.ToolStripSeparator36.Size = New System.Drawing.Size(347, 6)
        '
        'ToolStripMenuItem21
        '
        Me.ToolStripMenuItem21.Image = CType(resources.GetObject("ToolStripMenuItem21.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem21.Name = "ToolStripMenuItem21"
        Me.ToolStripMenuItem21.Size = New System.Drawing.Size(350, 22)
        Me.ToolStripMenuItem21.Text = "Assign Arbitration / Litigation Atorney Case Number"
        '
        'CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem
        '
        Me.CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem.Name = "CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem"
        Me.CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(350, 22)
        Me.CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem.Text = "Court Index Number / Filing Date Maintenance"
        '
        'ToolStripSeparator39
        '
        Me.ToolStripSeparator39.Name = "ToolStripSeparator39"
        Me.ToolStripSeparator39.Size = New System.Drawing.Size(347, 6)
        '
        'ToolStripMenuItem22
        '
        Me.ToolStripMenuItem22.Image = CType(resources.GetObject("ToolStripMenuItem22.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem22.Name = "ToolStripMenuItem22"
        Me.ToolStripMenuItem22.Size = New System.Drawing.Size(350, 22)
        Me.ToolStripMenuItem22.Text = "Attorney Fees"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(246, 6)
        Me.ToolStripSeparator10.Tag = "1"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RequestImageDiskToolStripMenuItem, Me.ToolStripSeparator9, Me.ProduceDiskToolStripMenuItem, Me.ToolStripSeparator8, Me.ToolStripMenuItem7, Me.ImageDisksProcessScanPOMToolStripMenuItem, Me.ToolStripSeparator19, Me.ToolStripMenuItemCDReport})
        Me.ToolStripMenuItem4.Image = CType(resources.GetObject("ToolStripMenuItem4.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(249, 22)
        Me.ToolStripMenuItem4.Tag = "1"
        Me.ToolStripMenuItem4.Text = "Image Disk"
        '
        'RequestImageDiskToolStripMenuItem
        '
        Me.RequestImageDiskToolStripMenuItem.Image = CType(resources.GetObject("RequestImageDiskToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RequestImageDiskToolStripMenuItem.Name = "RequestImageDiskToolStripMenuItem"
        Me.RequestImageDiskToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.RequestImageDiskToolStripMenuItem.Text = "1. Order Image Disk"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(213, 6)
        '
        'ProduceDiskToolStripMenuItem
        '
        Me.ProduceDiskToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ProduceDiskToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ProduceDiskToolStripMenuItem.Image = CType(resources.GetObject("ProduceDiskToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ProduceDiskToolStripMenuItem.Name = "ProduceDiskToolStripMenuItem"
        Me.ProduceDiskToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ProduceDiskToolStripMenuItem.Text = "2. Process Image Disk"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(213, 6)
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Image = CType(resources.GetObject("ToolStripMenuItem7.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItem7.Text = "3. Create Image Disks POM"
        '
        'ImageDisksProcessScanPOMToolStripMenuItem
        '
        Me.ImageDisksProcessScanPOMToolStripMenuItem.ForeColor = System.Drawing.Color.DarkCyan
        Me.ImageDisksProcessScanPOMToolStripMenuItem.Image = CType(resources.GetObject("ImageDisksProcessScanPOMToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImageDisksProcessScanPOMToolStripMenuItem.Name = "ImageDisksProcessScanPOMToolStripMenuItem"
        Me.ImageDisksProcessScanPOMToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ImageDisksProcessScanPOMToolStripMenuItem.Text = "4. Scan Image Disks POM"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(213, 6)
        '
        'ToolStripMenuItemCDReport
        '
        Me.ToolStripMenuItemCDReport.Image = CType(resources.GetObject("ToolStripMenuItemCDReport.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemCDReport.Name = "ToolStripMenuItemCDReport"
        Me.ToolStripMenuItemCDReport.Size = New System.Drawing.Size(216, 22)
        Me.ToolStripMenuItemCDReport.Text = "Image Disk Report"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(246, 6)
        '
        'FindDuplicatePatientsToolStripMenuItem
        '
        Me.FindDuplicatePatientsToolStripMenuItem.Image = CType(resources.GetObject("FindDuplicatePatientsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FindDuplicatePatientsToolStripMenuItem.Name = "FindDuplicatePatientsToolStripMenuItem"
        Me.FindDuplicatePatientsToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.FindDuplicatePatientsToolStripMenuItem.Text = "Find Duplicate Patients"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.SearchToolStripMenuItem.Image = CType(resources.GetObject("SearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F3), System.Windows.Forms.Keys)
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.SearchToolStripMenuItem.Text = "Advanced &Search"
        Me.SearchToolStripMenuItem.Visible = False
        '
        'AdminMessagingToolStripMenuItem
        '
        Me.AdminMessagingToolStripMenuItem.Image = CType(resources.GetObject("AdminMessagingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AdminMessagingToolStripMenuItem.Name = "AdminMessagingToolStripMenuItem"
        Me.AdminMessagingToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.AdminMessagingToolStripMenuItem.Text = "Admin Messaging System"
        '
        'AdministrativeToolsToolStripMenuItem
        '
        Me.AdministrativeToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOfficesCompaniesMaintenance, Me.mnuAdminStripSeparator2, Me.mnuDiagnosticsProceduresMaintenance, Me.mnuAdminStripSeparator3, Me.mnuUnlockPatientProfiles, Me.mnuAdminStripSeparator1, Me.ToolStripMenuItemRequestsMaintenance, Me.ToolStripBillingPaymentManagementReport, Me.mnuBankDepositsAdmin, Me.mnuAdminStripSeparator4, Me.ToolStripMenuItemChangePatientInformation, Me.ToolStripSeparator15, Me.ToolStripMenuItem17, Me.BillingTemplatesMaintenanceToolStripMenuItem, Me.PhoneBookToolStripMenuItem, Me.MessagePoolToolStripMenuItem, Me.ToolStripSeparator2, Me.ScannerDocumentMaintenanceToolStripMenuItem, Me.ToolStripSeparator4, Me.ToolStripMenuItem8, Me.ToolStripSeparator17, Me.ToolStripMenuItem2, Me.SecuritySettingsToolStripMenuItem, Me.ToolStripSeparator40, Me.ToolStripMenuItem30})
        Me.AdministrativeToolsToolStripMenuItem.Image = CType(resources.GetObject("AdministrativeToolsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AdministrativeToolsToolStripMenuItem.Name = "AdministrativeToolsToolStripMenuItem"
        Me.AdministrativeToolsToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.AdministrativeToolsToolStripMenuItem.Text = "&Maintenance Tools"
        '
        'mnuOfficesCompaniesMaintenance
        '
        Me.mnuOfficesCompaniesMaintenance.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OfficesMaintenanceToolStripMenuItem, Me.mnuEmployeeMaintenance, Me.ToolStripSeparator11, Me.ReferringOfficesMaintenanceToolStripMenuItem, Me.ReferringOfficesStatisticReportToolStripMenuItem, Me.InsurancesMaintenanceToolStripMenuItem, Me.TransportationMaintenanceToolStripMenuItem, Me.BillingCompaniesMaintenanceToolStripMenuItem, Me.AttorneyMaintenanceToolStripMenuItem, Me.ToolStripMenuItemOTMaintenance})
        Me.mnuOfficesCompaniesMaintenance.Image = CType(resources.GetObject("mnuOfficesCompaniesMaintenance.Image"), System.Drawing.Image)
        Me.mnuOfficesCompaniesMaintenance.Name = "mnuOfficesCompaniesMaintenance"
        Me.mnuOfficesCompaniesMaintenance.Size = New System.Drawing.Size(277, 22)
        Me.mnuOfficesCompaniesMaintenance.Text = "Offices / Companies Maintenance"
        '
        'OfficesMaintenanceToolStripMenuItem
        '
        Me.OfficesMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("OfficesMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OfficesMaintenanceToolStripMenuItem.Name = "OfficesMaintenanceToolStripMenuItem"
        Me.OfficesMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.OfficesMaintenanceToolStripMenuItem.Text = "&Offices Maintenance"
        '
        'mnuEmployeeMaintenance
        '
        Me.mnuEmployeeMaintenance.Image = CType(resources.GetObject("mnuEmployeeMaintenance.Image"), System.Drawing.Image)
        Me.mnuEmployeeMaintenance.Name = "mnuEmployeeMaintenance"
        Me.mnuEmployeeMaintenance.Size = New System.Drawing.Size(264, 22)
        Me.mnuEmployeeMaintenance.Text = "&Employees / Doctors Maintenance"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(261, 6)
        '
        'ReferringOfficesMaintenanceToolStripMenuItem
        '
        Me.ReferringOfficesMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("ReferringOfficesMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReferringOfficesMaintenanceToolStripMenuItem.Name = "ReferringOfficesMaintenanceToolStripMenuItem"
        Me.ReferringOfficesMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.ReferringOfficesMaintenanceToolStripMenuItem.Tag = "1"
        Me.ReferringOfficesMaintenanceToolStripMenuItem.Text = "&Referring Offices Maintenance"
        '
        'ReferringOfficesStatisticReportToolStripMenuItem
        '
        Me.ReferringOfficesStatisticReportToolStripMenuItem.Image = CType(resources.GetObject("ReferringOfficesStatisticReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReferringOfficesStatisticReportToolStripMenuItem.Name = "ReferringOfficesStatisticReportToolStripMenuItem"
        Me.ReferringOfficesStatisticReportToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.ReferringOfficesStatisticReportToolStripMenuItem.Tag = "1"
        Me.ReferringOfficesStatisticReportToolStripMenuItem.Text = "Referring Offices Statistic Report"
        '
        'InsurancesMaintenanceToolStripMenuItem
        '
        Me.InsurancesMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("InsurancesMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InsurancesMaintenanceToolStripMenuItem.Name = "InsurancesMaintenanceToolStripMenuItem"
        Me.InsurancesMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.InsurancesMaintenanceToolStripMenuItem.Text = "&Insurance Maintenance"
        '
        'TransportationMaintenanceToolStripMenuItem
        '
        Me.TransportationMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("TransportationMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TransportationMaintenanceToolStripMenuItem.Name = "TransportationMaintenanceToolStripMenuItem"
        Me.TransportationMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.TransportationMaintenanceToolStripMenuItem.Text = "&Transportation Maintenance"
        '
        'BillingCompaniesMaintenanceToolStripMenuItem
        '
        Me.BillingCompaniesMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("BillingCompaniesMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BillingCompaniesMaintenanceToolStripMenuItem.Name = "BillingCompaniesMaintenanceToolStripMenuItem"
        Me.BillingCompaniesMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.BillingCompaniesMaintenanceToolStripMenuItem.Text = "Billing Companies Maintenance"
        '
        'AttorneyMaintenanceToolStripMenuItem
        '
        Me.AttorneyMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("AttorneyMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AttorneyMaintenanceToolStripMenuItem.Name = "AttorneyMaintenanceToolStripMenuItem"
        Me.AttorneyMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.AttorneyMaintenanceToolStripMenuItem.Text = "&Attorney Maintenance"
        '
        'ToolStripMenuItemOTMaintenance
        '
        Me.ToolStripMenuItemOTMaintenance.Image = CType(resources.GetObject("ToolStripMenuItemOTMaintenance.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemOTMaintenance.Name = "ToolStripMenuItemOTMaintenance"
        Me.ToolStripMenuItemOTMaintenance.Size = New System.Drawing.Size(264, 22)
        Me.ToolStripMenuItemOTMaintenance.Tag = "2"
        Me.ToolStripMenuItemOTMaintenance.Text = "&Outsource Companies Maintenance"
        '
        'mnuAdminStripSeparator2
        '
        Me.mnuAdminStripSeparator2.Name = "mnuAdminStripSeparator2"
        Me.mnuAdminStripSeparator2.Size = New System.Drawing.Size(274, 6)
        '
        'mnuDiagnosticsProceduresMaintenance
        '
        Me.mnuDiagnosticsProceduresMaintenance.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DiagnosticsMaintenanceToolStripMenuItem, Me.ProcedureMaintenanceToolStripMenuItem, Me.DiagnosisMaintenanceToolStripMenuItem, Me.InjuryTypesMaintenanceToolStripMenuItem})
        Me.mnuDiagnosticsProceduresMaintenance.ForeColor = System.Drawing.Color.SteelBlue
        Me.mnuDiagnosticsProceduresMaintenance.Image = CType(resources.GetObject("mnuDiagnosticsProceduresMaintenance.Image"), System.Drawing.Image)
        Me.mnuDiagnosticsProceduresMaintenance.Name = "mnuDiagnosticsProceduresMaintenance"
        Me.mnuDiagnosticsProceduresMaintenance.Size = New System.Drawing.Size(277, 22)
        Me.mnuDiagnosticsProceduresMaintenance.Text = "Diagnostics / Procedures Maintenance"
        '
        'DiagnosticsMaintenanceToolStripMenuItem
        '
        Me.DiagnosticsMaintenanceToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue
        Me.DiagnosticsMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("DiagnosticsMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DiagnosticsMaintenanceToolStripMenuItem.Name = "DiagnosticsMaintenanceToolStripMenuItem"
        Me.DiagnosticsMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.DiagnosticsMaintenanceToolStripMenuItem.Text = "&Procedure Types Maintenance"
        '
        'ProcedureMaintenanceToolStripMenuItem
        '
        Me.ProcedureMaintenanceToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ProcedureMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("ProcedureMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ProcedureMaintenanceToolStripMenuItem.Name = "ProcedureMaintenanceToolStripMenuItem"
        Me.ProcedureMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.ProcedureMaintenanceToolStripMenuItem.Text = "&Procedure Maintenance"
        '
        'DiagnosisMaintenanceToolStripMenuItem
        '
        Me.DiagnosisMaintenanceToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue
        Me.DiagnosisMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("DiagnosisMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DiagnosisMaintenanceToolStripMenuItem.Name = "DiagnosisMaintenanceToolStripMenuItem"
        Me.DiagnosisMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.DiagnosisMaintenanceToolStripMenuItem.Text = "Diagnosis Maintenance"
        '
        'InjuryTypesMaintenanceToolStripMenuItem
        '
        Me.InjuryTypesMaintenanceToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue
        Me.InjuryTypesMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("InjuryTypesMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InjuryTypesMaintenanceToolStripMenuItem.Name = "InjuryTypesMaintenanceToolStripMenuItem"
        Me.InjuryTypesMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.InjuryTypesMaintenanceToolStripMenuItem.Text = "&Injury Types Maintenance"
        '
        'mnuAdminStripSeparator3
        '
        Me.mnuAdminStripSeparator3.Name = "mnuAdminStripSeparator3"
        Me.mnuAdminStripSeparator3.Size = New System.Drawing.Size(274, 6)
        '
        'mnuUnlockPatientProfiles
        '
        Me.mnuUnlockPatientProfiles.ForeColor = System.Drawing.Color.DarkGreen
        Me.mnuUnlockPatientProfiles.Image = CType(resources.GetObject("mnuUnlockPatientProfiles.Image"), System.Drawing.Image)
        Me.mnuUnlockPatientProfiles.Name = "mnuUnlockPatientProfiles"
        Me.mnuUnlockPatientProfiles.Size = New System.Drawing.Size(277, 22)
        Me.mnuUnlockPatientProfiles.Text = "&Unlock Patient Profiles"
        '
        'mnuAdminStripSeparator1
        '
        Me.mnuAdminStripSeparator1.Name = "mnuAdminStripSeparator1"
        Me.mnuAdminStripSeparator1.Size = New System.Drawing.Size(274, 6)
        '
        'ToolStripMenuItemRequestsMaintenance
        '
        Me.ToolStripMenuItemRequestsMaintenance.Image = CType(resources.GetObject("ToolStripMenuItemRequestsMaintenance.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemRequestsMaintenance.Name = "ToolStripMenuItemRequestsMaintenance"
        Me.ToolStripMenuItemRequestsMaintenance.Size = New System.Drawing.Size(277, 22)
        Me.ToolStripMenuItemRequestsMaintenance.Text = "Requests Maintenance"
        '
        'ToolStripBillingPaymentManagementReport
        '
        Me.ToolStripBillingPaymentManagementReport.Image = CType(resources.GetObject("ToolStripBillingPaymentManagementReport.Image"), System.Drawing.Image)
        Me.ToolStripBillingPaymentManagementReport.Name = "ToolStripBillingPaymentManagementReport"
        Me.ToolStripBillingPaymentManagementReport.Size = New System.Drawing.Size(277, 22)
        Me.ToolStripBillingPaymentManagementReport.Text = "Payment Management"
        Me.ToolStripBillingPaymentManagementReport.Visible = False
        '
        'mnuBankDepositsAdmin
        '
        Me.mnuBankDepositsAdmin.Image = CType(resources.GetObject("mnuBankDepositsAdmin.Image"), System.Drawing.Image)
        Me.mnuBankDepositsAdmin.Name = "mnuBankDepositsAdmin"
        Me.mnuBankDepositsAdmin.Size = New System.Drawing.Size(277, 22)
        Me.mnuBankDepositsAdmin.Text = "Bank Deposits Report"
        Me.mnuBankDepositsAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mnuAdminStripSeparator4
        '
        Me.mnuAdminStripSeparator4.Name = "mnuAdminStripSeparator4"
        Me.mnuAdminStripSeparator4.Size = New System.Drawing.Size(274, 6)
        '
        'ToolStripMenuItemChangePatientInformation
        '
        Me.ToolStripMenuItemChangePatientInformation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeBillingProviderToolStripMenuItem, Me.ChangeTreatingProviderToolStripMenuItem, Me.ChangeRefferingDoctorToolStripMenuItem, Me.ToolStripMenuItem6, Me.PatientProcedureInformationToolStripMenuItem, Me.ResetPatientInformationToolStripMenuItem})
        Me.ToolStripMenuItemChangePatientInformation.Image = CType(resources.GetObject("ToolStripMenuItemChangePatientInformation.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemChangePatientInformation.Name = "ToolStripMenuItemChangePatientInformation"
        Me.ToolStripMenuItemChangePatientInformation.Size = New System.Drawing.Size(277, 22)
        Me.ToolStripMenuItemChangePatientInformation.Text = "Change Patient Information"
        '
        'ChangeBillingProviderToolStripMenuItem
        '
        Me.ChangeBillingProviderToolStripMenuItem.Image = CType(resources.GetObject("ChangeBillingProviderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ChangeBillingProviderToolStripMenuItem.Name = "ChangeBillingProviderToolStripMenuItem"
        Me.ChangeBillingProviderToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ChangeBillingProviderToolStripMenuItem.Text = "Change Billing Provider"
        '
        'ChangeTreatingProviderToolStripMenuItem
        '
        Me.ChangeTreatingProviderToolStripMenuItem.Image = CType(resources.GetObject("ChangeTreatingProviderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ChangeTreatingProviderToolStripMenuItem.Name = "ChangeTreatingProviderToolStripMenuItem"
        Me.ChangeTreatingProviderToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ChangeTreatingProviderToolStripMenuItem.Text = "Change Treating Provider"
        '
        'ChangeRefferingDoctorToolStripMenuItem
        '
        Me.ChangeRefferingDoctorToolStripMenuItem.Image = CType(resources.GetObject("ChangeRefferingDoctorToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ChangeRefferingDoctorToolStripMenuItem.Name = "ChangeRefferingDoctorToolStripMenuItem"
        Me.ChangeRefferingDoctorToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ChangeRefferingDoctorToolStripMenuItem.Text = "Change Reffering Doctor"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Image = CType(resources.GetObject("ToolStripMenuItem6.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(262, 22)
        Me.ToolStripMenuItem6.Text = "Patient Procedures Switch Schedule"
        '
        'PatientProcedureInformationToolStripMenuItem
        '
        Me.PatientProcedureInformationToolStripMenuItem.Image = CType(resources.GetObject("PatientProcedureInformationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PatientProcedureInformationToolStripMenuItem.Name = "PatientProcedureInformationToolStripMenuItem"
        Me.PatientProcedureInformationToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.PatientProcedureInformationToolStripMenuItem.Text = "Patient Procedure Information"
        '
        'ResetPatientInformationToolStripMenuItem
        '
        Me.ResetPatientInformationToolStripMenuItem.Image = CType(resources.GetObject("ResetPatientInformationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ResetPatientInformationToolStripMenuItem.Name = "ResetPatientInformationToolStripMenuItem"
        Me.ResetPatientInformationToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ResetPatientInformationToolStripMenuItem.Text = "Reset Patient Information"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(274, 6)
        '
        'ToolStripMenuItem17
        '
        Me.ToolStripMenuItem17.Image = CType(resources.GetObject("ToolStripMenuItem17.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem17.Name = "ToolStripMenuItem17"
        Me.ToolStripMenuItem17.Size = New System.Drawing.Size(277, 22)
        Me.ToolStripMenuItem17.Text = "Denial Reasons Maintenance"
        '
        'BillingTemplatesMaintenanceToolStripMenuItem
        '
        Me.BillingTemplatesMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("BillingTemplatesMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BillingTemplatesMaintenanceToolStripMenuItem.Name = "BillingTemplatesMaintenanceToolStripMenuItem"
        Me.BillingTemplatesMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.BillingTemplatesMaintenanceToolStripMenuItem.Text = "Billing Templates Maintenance"
        '
        'PhoneBookToolStripMenuItem
        '
        Me.PhoneBookToolStripMenuItem.Image = CType(resources.GetObject("PhoneBookToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PhoneBookToolStripMenuItem.Name = "PhoneBookToolStripMenuItem"
        Me.PhoneBookToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.PhoneBookToolStripMenuItem.Text = "Phone Book Maintenance"
        '
        'MessagePoolToolStripMenuItem
        '
        Me.MessagePoolToolStripMenuItem.Image = CType(resources.GetObject("MessagePoolToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MessagePoolToolStripMenuItem.Name = "MessagePoolToolStripMenuItem"
        Me.MessagePoolToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.MessagePoolToolStripMenuItem.Text = "Message Pool"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(274, 6)
        '
        'ScannerDocumentMaintenanceToolStripMenuItem
        '
        Me.ScannerDocumentMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("ScannerDocumentMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ScannerDocumentMaintenanceToolStripMenuItem.Name = "ScannerDocumentMaintenanceToolStripMenuItem"
        Me.ScannerDocumentMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.ScannerDocumentMaintenanceToolStripMenuItem.Text = "&Scanner Document Maintenance"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(274, 6)
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnnouncementsToolStripMenuItem, Me.ToolStripMenuItemLetterHead, Me.BulkEmailToolStripMenuItem})
        Me.ToolStripMenuItem8.Image = CType(resources.GetObject("ToolStripMenuItem8.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(277, 22)
        Me.ToolStripMenuItem8.Text = "Writing Tools"
        '
        'AnnouncementsToolStripMenuItem
        '
        Me.AnnouncementsToolStripMenuItem.Image = CType(resources.GetObject("AnnouncementsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AnnouncementsToolStripMenuItem.Name = "AnnouncementsToolStripMenuItem"
        Me.AnnouncementsToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.AnnouncementsToolStripMenuItem.Text = "Announcements"
        '
        'ToolStripMenuItemLetterHead
        '
        Me.ToolStripMenuItemLetterHead.Image = CType(resources.GetObject("ToolStripMenuItemLetterHead.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemLetterHead.Name = "ToolStripMenuItemLetterHead"
        Me.ToolStripMenuItemLetterHead.Size = New System.Drawing.Size(162, 22)
        Me.ToolStripMenuItemLetterHead.Text = "Letter"
        '
        'BulkEmailToolStripMenuItem
        '
        Me.BulkEmailToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailerToolStripMenuItem, Me.ToolStripSeparator29, Me.EmailerMaintenanceToolStripMenuItem})
        Me.BulkEmailToolStripMenuItem.Image = CType(resources.GetObject("BulkEmailToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BulkEmailToolStripMenuItem.Name = "BulkEmailToolStripMenuItem"
        Me.BulkEmailToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.BulkEmailToolStripMenuItem.Text = "Bulk Emailer"
        '
        'EmailerToolStripMenuItem
        '
        Me.EmailerToolStripMenuItem.Image = CType(resources.GetObject("EmailerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EmailerToolStripMenuItem.Name = "EmailerToolStripMenuItem"
        Me.EmailerToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.EmailerToolStripMenuItem.Text = "Start Emailer"
        '
        'ToolStripSeparator29
        '
        Me.ToolStripSeparator29.Name = "ToolStripSeparator29"
        Me.ToolStripSeparator29.Size = New System.Drawing.Size(182, 6)
        '
        'EmailerMaintenanceToolStripMenuItem
        '
        Me.EmailerMaintenanceToolStripMenuItem.Image = CType(resources.GetObject("EmailerMaintenanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EmailerMaintenanceToolStripMenuItem.Name = "EmailerMaintenanceToolStripMenuItem"
        Me.EmailerMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.EmailerMaintenanceToolStripMenuItem.Text = "Emailer Maintenance"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(274, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(277, 22)
        Me.ToolStripMenuItem2.Text = "&System Properties"
        '
        'SecuritySettingsToolStripMenuItem
        '
        Me.SecuritySettingsToolStripMenuItem.Image = CType(resources.GetObject("SecuritySettingsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SecuritySettingsToolStripMenuItem.Name = "SecuritySettingsToolStripMenuItem"
        Me.SecuritySettingsToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.SecuritySettingsToolStripMenuItem.Text = "Security Settings"
        Me.SecuritySettingsToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator40
        '
        Me.ToolStripSeparator40.Name = "ToolStripSeparator40"
        Me.ToolStripSeparator40.Size = New System.Drawing.Size(274, 6)
        '
        'ToolStripMenuItem30
        '
        Me.ToolStripMenuItem30.Image = CType(resources.GetObject("ToolStripMenuItem30.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem30.Name = "ToolStripMenuItem30"
        Me.ToolStripMenuItem30.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.ToolStripMenuItem30.Size = New System.Drawing.Size(285, 20)
        Me.ToolStripMenuItem30.Text = "Restore Default Workspace Settings"
        '
        'ToolStripMenuItemWeb
        '
        Me.ToolStripMenuItemWeb.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemBookMarkManager})
        Me.ToolStripMenuItemWeb.Name = "ToolStripMenuItemWeb"
        Me.ToolStripMenuItemWeb.Size = New System.Drawing.Size(105, 20)
        Me.ToolStripMenuItemWeb.Text = "Web Bookmarks"
        '
        'ToolStripMenuItemBookMarkManager
        '
        Me.ToolStripMenuItemBookMarkManager.Image = CType(resources.GetObject("ToolStripMenuItemBookMarkManager.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemBookMarkManager.Name = "ToolStripMenuItemBookMarkManager"
        Me.ToolStripMenuItemBookMarkManager.Size = New System.Drawing.Size(178, 22)
        Me.ToolStripMenuItemBookMarkManager.Text = "Bookmark Manager"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(68, 20)
        Me.WindowsMenu.Text = "&Windows"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.CascadeToolStripMenuItem.Text = "&Cascade"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.TileVerticalToolStripMenuItem.Text = "Tile &Vertical"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.CloseAllToolStripMenuItem.Text = "C&lose All"
        '
        'HelpMenu
        '
        Me.HelpMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpMenu.Margin = New System.Windows.Forms.Padding(0, 0, 20, 0)
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(44, 20)
        Me.HelpMenu.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.AboutToolStripMenuItem.Text = "&About ..."
        '
        'ToolTip
        '
        Me.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip.ToolTipTitle = "eMedical Office"
        '
        'CheckBoxDoNotShowBills
        '
        Me.CheckBoxDoNotShowBills.AutoSize = True
        Me.CheckBoxDoNotShowBills.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxDoNotShowBills.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxDoNotShowBills.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxDoNotShowBills.Location = New System.Drawing.Point(53, 3)
        Me.CheckBoxDoNotShowBills.Name = "CheckBoxDoNotShowBills"
        Me.CheckBoxDoNotShowBills.Size = New System.Drawing.Size(45, 17)
        Me.CheckBoxDoNotShowBills.TabIndex = 35
        Me.CheckBoxDoNotShowBills.Text = "Hide"
        Me.ToolTip.SetToolTip(Me.CheckBoxDoNotShowBills, "Do not show notifications")
        Me.CheckBoxDoNotShowBills.UseVisualStyleBackColor = True
        '
        'CheckBoxDoNotShowRequests
        '
        Me.CheckBoxDoNotShowRequests.AutoSize = True
        Me.CheckBoxDoNotShowRequests.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxDoNotShowRequests.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxDoNotShowRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxDoNotShowRequests.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxDoNotShowRequests.Location = New System.Drawing.Point(166, 3)
        Me.CheckBoxDoNotShowRequests.Name = "CheckBoxDoNotShowRequests"
        Me.CheckBoxDoNotShowRequests.Size = New System.Drawing.Size(45, 17)
        Me.CheckBoxDoNotShowRequests.TabIndex = 36
        Me.CheckBoxDoNotShowRequests.Text = "Hide"
        Me.ToolTip.SetToolTip(Me.CheckBoxDoNotShowRequests, "Do not show notifications")
        Me.CheckBoxDoNotShowRequests.UseVisualStyleBackColor = False
        '
        'ShowToBeScheduled
        '
        Me.ShowToBeScheduled.AutoSize = True
        Me.ShowToBeScheduled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ShowToBeScheduled.FlatAppearance.BorderSize = 0
        Me.ShowToBeScheduled.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ShowToBeScheduled.ForeColor = System.Drawing.Color.Black
        Me.ShowToBeScheduled.Location = New System.Drawing.Point(55, 1)
        Me.ShowToBeScheduled.Name = "ShowToBeScheduled"
        Me.ShowToBeScheduled.Size = New System.Drawing.Size(45, 17)
        Me.ShowToBeScheduled.TabIndex = 35
        Me.ShowToBeScheduled.Text = "Hide"
        Me.ToolTip.SetToolTip(Me.ShowToBeScheduled, "Do not show notifications")
        Me.ShowToBeScheduled.UseVisualStyleBackColor = True
        '
        'PictureBoxClose
        '
        Me.PictureBoxClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxClose.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxClose.Image = CType(resources.GetObject("PictureBoxClose.Image"), System.Drawing.Image)
        Me.PictureBoxClose.Location = New System.Drawing.Point(579, 0)
        Me.PictureBoxClose.Name = "PictureBoxClose"
        Me.PictureBoxClose.Size = New System.Drawing.Size(19, 20)
        Me.PictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBoxClose.TabIndex = 14
        Me.PictureBoxClose.TabStop = False
        Me.PictureBoxClose.Tag = "1"
        Me.ToolTip1.SetToolTip(Me.PictureBoxClose, "Acknowledge and Close Message")
        '
        'Timer5Sec
        '
        Me.Timer5Sec.Enabled = True
        Me.Timer5Sec.Interval = 10000
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(32, 19)
        '
        'StatusStrip
        '
        Me.StatusStrip.AllowMerge = False
        Me.StatusStrip.BackColor = System.Drawing.Color.LightSteelBlue
        Me.StatusStrip.BackgroundImage = CType(resources.GetObject("StatusStrip.BackgroundImage"), System.Drawing.Image)
        Me.StatusStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DBStatusLabel, Me.lblStatus, Me.lblOffice, Me.ToolStripStatusDBServer, Me.lblOfficeType, Me.lblServer, Me.lblUserName, Me.lblPosition, Me.lblDate, Me.lblTime})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 664)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip.ShowItemToolTips = True
        Me.StatusStrip.Size = New System.Drawing.Size(1260, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'DBStatusLabel
        '
        Me.DBStatusLabel.Image = CType(resources.GetObject("DBStatusLabel.Image"), System.Drawing.Image)
        Me.DBStatusLabel.Name = "DBStatusLabel"
        Me.DBStatusLabel.Size = New System.Drawing.Size(16, 17)
        '
        'lblStatus
        '
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(715, 17)
        Me.lblStatus.Spring = True
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOffice
        '
        Me.lblOffice.ForeColor = System.Drawing.Color.White
        Me.lblOffice.Name = "lblOffice"
        Me.lblOffice.Size = New System.Drawing.Size(39, 17)
        Me.lblOffice.Text = "Office"
        '
        'ToolStripStatusDBServer
        '
        Me.ToolStripStatusDBServer.ForeColor = System.Drawing.Color.White
        Me.ToolStripStatusDBServer.Name = "ToolStripStatusDBServer"
        Me.ToolStripStatusDBServer.Size = New System.Drawing.Size(0, 17)
        '
        'lblOfficeType
        '
        Me.lblOfficeType.ForeColor = System.Drawing.Color.White
        Me.lblOfficeType.Name = "lblOfficeType"
        Me.lblOfficeType.Size = New System.Drawing.Size(68, 17)
        Me.lblOfficeType.Text = "Office Type"
        '
        'lblServer
        '
        Me.lblServer.ForeColor = System.Drawing.Color.White
        Me.lblServer.Image = CType(resources.GetObject("lblServer.Image"), System.Drawing.Image)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(55, 17)
        Me.lblServer.Text = "Server"
        '
        'lblUserName
        '
        Me.lblUserName.ForeColor = System.Drawing.Color.White
        Me.lblUserName.Image = CType(resources.GetObject("lblUserName.Image"), System.Drawing.Image)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(78, 17)
        Me.lblUserName.Text = "UserName"
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = False
        Me.lblPosition.DoubleClickEnabled = True
        Me.lblPosition.ForeColor = System.Drawing.Color.White
        Me.lblPosition.Image = CType(resources.GetObject("lblPosition.Image"), System.Drawing.Image)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(130, 17)
        Me.lblPosition.Text = "Position"
        '
        'lblDate
        '
        Me.lblDate.ForeColor = System.Drawing.Color.White
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(44, 17)
        Me.lblDate.Text = "lblDate"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTime
        '
        Me.lblTime.AutoSize = False
        Me.lblTime.ForeColor = System.Drawing.Color.White
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(100, 17)
        Me.lblTime.Text = "lblTime"
        '
        'ToolStripButtonSchedule
        '
        Me.ToolStripButtonSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSchedule.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripButtonSchedule.ForeColor = System.Drawing.Color.White
        Me.ToolStripButtonSchedule.Image = CType(resources.GetObject("ToolStripButtonSchedule.Image"), System.Drawing.Image)
        Me.ToolStripButtonSchedule.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSchedule.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.ToolStripButtonSchedule.Name = "ToolStripButtonSchedule"
        Me.ToolStripButtonSchedule.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.ToolStripButtonSchedule.Size = New System.Drawing.Size(82, 53)
        Me.ToolStripButtonSchedule.Text = "Schedule"
        Me.ToolStripButtonSchedule.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonSchedule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButtonSchedule.ToolTipText = "Show Office Schedule [F1]"
        '
        'ToolStripButtonPatientProfile
        '
        Me.ToolStripButtonPatientProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonPatientProfile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripButtonPatientProfile.ForeColor = System.Drawing.Color.White
        Me.ToolStripButtonPatientProfile.Image = CType(resources.GetObject("ToolStripButtonPatientProfile.Image"), System.Drawing.Image)
        Me.ToolStripButtonPatientProfile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonPatientProfile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonPatientProfile.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.ToolStripButtonPatientProfile.Name = "ToolStripButtonPatientProfile"
        Me.ToolStripButtonPatientProfile.Padding = New System.Windows.Forms.Padding(15, 1, 15, 0)
        Me.ToolStripButtonPatientProfile.Size = New System.Drawing.Size(82, 53)
        Me.ToolStripButtonPatientProfile.Text = "Patient Maintenance"
        Me.ToolStripButtonPatientProfile.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonPatientProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButtonPatientProfile.ToolTipText = "Patient Profile Maintenance  [F2]"
        '
        'ToolStripButtonSearch
        '
        Me.ToolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSearch.ForeColor = System.Drawing.Color.White
        Me.ToolStripButtonSearch.Image = CType(resources.GetObject("ToolStripButtonSearch.Image"), System.Drawing.Image)
        Me.ToolStripButtonSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSearch.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.ToolStripButtonSearch.Name = "ToolStripButtonSearch"
        Me.ToolStripButtonSearch.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.ToolStripButtonSearch.Size = New System.Drawing.Size(79, 53)
        Me.ToolStripButtonSearch.Text = "QSearch"
        Me.ToolStripButtonSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButtonSearch.ToolTipText = "Quick Search [F3]"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.BackColor = System.Drawing.Color.DimGray
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripButtonSchedule, Me.ToolStripButtonIntakeForm, Me.ToolStripButtonPatientProfile, Me.ToolStripButtonPatSearchAndTools, Me.ToolStripButtonSearch, Me.ToolStripButtonInsuranceMainenance, Me.ToolStripButtonBilling, Me.ToolStripButtonBillMaintenance, Me.ToolStripLabel2, Me.ToolStripButtonCollection})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1260, 56)
        Me.ToolStrip1.TabIndex = 1
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ToolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(13, 53)
        Me.ToolStripLabel1.Text = "  "
        Me.ToolStripLabel1.ToolTipText = "Hold Alt Key and drug a button to customise button location on the toolbar"
        '
        'ToolStripButtonIntakeForm
        '
        Me.ToolStripButtonIntakeForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonIntakeForm.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripButtonIntakeForm.ForeColor = System.Drawing.Color.White
        Me.ToolStripButtonIntakeForm.Image = CType(resources.GetObject("ToolStripButtonIntakeForm.Image"), System.Drawing.Image)
        Me.ToolStripButtonIntakeForm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonIntakeForm.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.ToolStripButtonIntakeForm.Name = "ToolStripButtonIntakeForm"
        Me.ToolStripButtonIntakeForm.Padding = New System.Windows.Forms.Padding(15, 1, 15, 0)
        Me.ToolStripButtonIntakeForm.Size = New System.Drawing.Size(82, 53)
        Me.ToolStripButtonIntakeForm.Text = "Intake Form"
        Me.ToolStripButtonIntakeForm.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonIntakeForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButtonIntakeForm.ToolTipText = "Print Intake Form"
        '
        'ToolStripButtonPatSearchAndTools
        '
        Me.ToolStripButtonPatSearchAndTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonPatSearchAndTools.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripButtonPatSearchAndTools.ForeColor = System.Drawing.Color.White
        Me.ToolStripButtonPatSearchAndTools.Image = CType(resources.GetObject("ToolStripButtonPatSearchAndTools.Image"), System.Drawing.Image)
        Me.ToolStripButtonPatSearchAndTools.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonPatSearchAndTools.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.ToolStripButtonPatSearchAndTools.Name = "ToolStripButtonPatSearchAndTools"
        Me.ToolStripButtonPatSearchAndTools.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.ToolStripButtonPatSearchAndTools.Size = New System.Drawing.Size(82, 53)
        Me.ToolStripButtonPatSearchAndTools.Text = "Search"
        Me.ToolStripButtonPatSearchAndTools.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonPatSearchAndTools.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButtonPatSearchAndTools.ToolTipText = "Patients Search & Tools [F4]"
        '
        'ToolStripButtonInsuranceMainenance
        '
        Me.ToolStripButtonInsuranceMainenance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonInsuranceMainenance.ForeColor = System.Drawing.Color.White
        Me.ToolStripButtonInsuranceMainenance.Image = CType(resources.GetObject("ToolStripButtonInsuranceMainenance.Image"), System.Drawing.Image)
        Me.ToolStripButtonInsuranceMainenance.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonInsuranceMainenance.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.ToolStripButtonInsuranceMainenance.Name = "ToolStripButtonInsuranceMainenance"
        Me.ToolStripButtonInsuranceMainenance.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.ToolStripButtonInsuranceMainenance.Size = New System.Drawing.Size(82, 53)
        Me.ToolStripButtonInsuranceMainenance.Text = "Insurances"
        Me.ToolStripButtonInsuranceMainenance.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonInsuranceMainenance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButtonInsuranceMainenance.ToolTipText = "Insurance / Lien Attorneys Maintenance"
        '
        'ToolStripButtonBilling
        '
        Me.ToolStripButtonBilling.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonBilling.ForeColor = System.Drawing.Color.White
        Me.ToolStripButtonBilling.Image = CType(resources.GetObject("ToolStripButtonBilling.Image"), System.Drawing.Image)
        Me.ToolStripButtonBilling.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonBilling.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonBilling.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.ToolStripButtonBilling.Name = "ToolStripButtonBilling"
        Me.ToolStripButtonBilling.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.ToolStripButtonBilling.Size = New System.Drawing.Size(82, 53)
        Me.ToolStripButtonBilling.Text = "Billing"
        Me.ToolStripButtonBilling.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonBilling.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButtonBilling.ToolTipText = "Billing"
        '
        'ToolStripButtonBillMaintenance
        '
        Me.ToolStripButtonBillMaintenance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonBillMaintenance.ForeColor = System.Drawing.Color.White
        Me.ToolStripButtonBillMaintenance.Image = CType(resources.GetObject("ToolStripButtonBillMaintenance.Image"), System.Drawing.Image)
        Me.ToolStripButtonBillMaintenance.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonBillMaintenance.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.ToolStripButtonBillMaintenance.Name = "ToolStripButtonBillMaintenance"
        Me.ToolStripButtonBillMaintenance.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.ToolStripButtonBillMaintenance.Size = New System.Drawing.Size(82, 53)
        Me.ToolStripButtonBillMaintenance.Text = "Billing / Management"
        Me.ToolStripButtonBillMaintenance.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonBillMaintenance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButtonBillMaintenance.ToolTipText = "Billing / Management"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.White
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.ToolStripLabel2.Size = New System.Drawing.Size(82, 53)
        Me.ToolStripLabel2.Text = "About"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripLabel2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButtonCollection
        '
        Me.ToolStripButtonCollection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonCollection.ForeColor = System.Drawing.Color.White
        Me.ToolStripButtonCollection.Image = CType(resources.GetObject("ToolStripButtonCollection.Image"), System.Drawing.Image)
        Me.ToolStripButtonCollection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCollection.Margin = New System.Windows.Forms.Padding(3, 1, 3, 2)
        Me.ToolStripButtonCollection.Name = "ToolStripButtonCollection"
        Me.ToolStripButtonCollection.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.ToolStripButtonCollection.Size = New System.Drawing.Size(82, 53)
        Me.ToolStripButtonCollection.Text = "Collection"
        Me.ToolStripButtonCollection.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonCollection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButtonCollection.ToolTipText = "Collection"
        '
        'ImageListTray
        '
        Me.ImageListTray.ImageStream = CType(resources.GetObject("ImageListTray.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTray.TransparentColor = System.Drawing.Color.White
        Me.ImageListTray.Images.SetKeyName(0, "YELLOW")
        Me.ImageListTray.Images.SetKeyName(1, "Ball_greenNF2.png")
        Me.ImageListTray.Images.SetKeyName(2, "Ball_RedNF2.png")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.DarkOrange
        Me.Panel1.Location = New System.Drawing.Point(0, 80)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1260, 3)
        Me.Panel1.TabIndex = 13
        '
        'PanelRequests
        '
        Me.PanelRequests.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.PanelRequests.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelRequests.Controls.Add(Me.ToolStrip3)
        Me.PanelRequests.Controls.Add(Me.CheckBoxDoNotShowRequests)
        Me.PanelRequests.Controls.Add(Me.Label2)
        Me.PanelRequests.Controls.Add(Me.ListViewrequestActions)
        Me.PanelRequests.Controls.Add(Me.ListViewRequestsDetails)
        Me.PanelRequests.Controls.Add(Me.ListViewRequests)
        Me.PanelRequests.Controls.Add(Me.PictureBoxPanelReminders)
        Me.PanelRequests.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelRequests.Location = New System.Drawing.Point(1041, 83)
        Me.PanelRequests.Name = "PanelRequests"
        Me.PanelRequests.Size = New System.Drawing.Size(219, 581)
        Me.PanelRequests.TabIndex = 22
        Me.PanelRequests.Visible = False
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip3.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton6, Me.ToolStripButton7})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 556)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip3.Size = New System.Drawing.Size(219, 25)
        Me.ToolStrip3.TabIndex = 185
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Margin = New System.Windows.Forms.Padding(8, 1, 0, 2)
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(67, 22)
        Me.ToolStripButton6.Text = " Patient"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Margin = New System.Windows.Forms.Padding(0, 1, 8, 2)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton7.Text = "Action"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 14)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Process Requestes"
        '
        'ListViewrequestActions
        '
        Me.ListViewrequestActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewrequestActions.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewrequestActions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6})
        Me.ListViewrequestActions.FullRowSelect = True
        Me.ListViewrequestActions.GridLines = True
        Me.ListViewrequestActions.Location = New System.Drawing.Point(5, 403)
        Me.ListViewrequestActions.Name = "ListViewrequestActions"
        Me.ListViewrequestActions.ShowItemToolTips = True
        Me.ListViewrequestActions.Size = New System.Drawing.Size(210, 150)
        Me.ListViewrequestActions.TabIndex = 32
        Me.ListViewrequestActions.UseCompatibleStateImageBehavior = False
        Me.ListViewrequestActions.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Action Date"
        Me.ColumnHeader5.Width = 81
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Description"
        Me.ColumnHeader6.Width = 101
        '
        'ListViewRequestsDetails
        '
        Me.ListViewRequestsDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewRequestsDetails.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewRequestsDetails.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListViewRequestsDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewRequestsDetails.FullRowSelect = True
        Me.ListViewRequestsDetails.GridLines = True
        Me.ListViewRequestsDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewRequestsDetails.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9})
        Me.ListViewRequestsDetails.Location = New System.Drawing.Point(5, 235)
        Me.ListViewRequestsDetails.Name = "ListViewRequestsDetails"
        Me.ListViewRequestsDetails.ShowItemToolTips = True
        Me.ListViewRequestsDetails.Size = New System.Drawing.Size(210, 162)
        Me.ListViewRequestsDetails.TabIndex = 29
        Me.ListViewRequestsDetails.UseCompatibleStateImageBehavior = False
        Me.ListViewRequestsDetails.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Request DT"
        Me.ColumnHeader3.Width = 67
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Request"
        Me.ColumnHeader4.Width = 130
        '
        'ListViewRequests
        '
        Me.ListViewRequests.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewRequests.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewRequests.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListViewRequests.ContextMenuStrip = Me.ContextMenuStripRequest
        Me.ListViewRequests.FullRowSelect = True
        Me.ListViewRequests.GridLines = True
        Me.ListViewRequests.Location = New System.Drawing.Point(4, 22)
        Me.ListViewRequests.MultiSelect = False
        Me.ListViewRequests.Name = "ListViewRequests"
        Me.ListViewRequests.ShowGroups = False
        Me.ListViewRequests.ShowItemToolTips = True
        Me.ListViewRequests.Size = New System.Drawing.Size(210, 207)
        Me.ListViewRequests.TabIndex = 0
        Me.ListViewRequests.UseCompatibleStateImageBehavior = False
        Me.ListViewRequests.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Request DT"
        Me.ColumnHeader1.Width = 78
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Request"
        Me.ColumnHeader2.Width = 99
        '
        'ContextMenuStripRequest
        '
        Me.ContextMenuStripRequest.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem16, Me.ToolStripSeparator24, Me.ToolStripButton10})
        Me.ContextMenuStripRequest.Name = "ContextMenuStrip1"
        Me.ContextMenuStripRequest.Size = New System.Drawing.Size(218, 57)
        '
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Image = CType(resources.GetObject("ToolStripMenuItem16.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        Me.ToolStripMenuItem16.Size = New System.Drawing.Size(217, 22)
        Me.ToolStripMenuItem16.Text = "Show Patient's Information"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(214, 6)
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Margin = New System.Windows.Forms.Padding(0, 1, 8, 2)
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(217, 22)
        Me.ToolStripButton10.Text = "Action"
        '
        'PictureBoxPanelReminders
        '
        Me.PictureBoxPanelReminders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxPanelReminders.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanelReminders.Image = CType(resources.GetObject("PictureBoxPanelReminders.Image"), System.Drawing.Image)
        Me.PictureBoxPanelReminders.Location = New System.Drawing.Point(198, 4)
        Me.PictureBoxPanelReminders.Name = "PictureBoxPanelReminders"
        Me.PictureBoxPanelReminders.Size = New System.Drawing.Size(16, 16)
        Me.PictureBoxPanelReminders.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBoxPanelReminders.TabIndex = 34
        Me.PictureBoxPanelReminders.TabStop = False
        '
        'PictureBoxPanelBills
        '
        Me.PictureBoxPanelBills.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxPanelBills.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanelBills.Image = CType(resources.GetObject("PictureBoxPanelBills.Image"), System.Drawing.Image)
        Me.PictureBoxPanelBills.Location = New System.Drawing.Point(194, 4)
        Me.PictureBoxPanelBills.Name = "PictureBoxPanelBills"
        Me.PictureBoxPanelBills.Size = New System.Drawing.Size(16, 16)
        Me.PictureBoxPanelBills.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBoxPanelBills.TabIndex = 33
        Me.PictureBoxPanelBills.TabStop = False
        '
        'TimerRefresh
        '
        Me.TimerRefresh.Interval = 5000
        '
        'TimerReminderReset
        '
        Me.TimerReminderReset.Interval = 3000
        '
        'PanelBills
        '
        Me.PanelBills.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.PanelBills.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelBills.Controls.Add(Me.Panel2)
        Me.PanelBills.Controls.Add(Me.SplitContainer1)
        Me.PanelBills.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelBills.Location = New System.Drawing.Point(825, 83)
        Me.PanelBills.Name = "PanelBills"
        Me.PanelBills.Size = New System.Drawing.Size(216, 581)
        Me.PanelBills.TabIndex = 24
        Me.PanelBills.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.CheckBoxDoNotShowBills)
        Me.Panel2.Location = New System.Drawing.Point(109, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(104, 18)
        Me.Panel2.TabIndex = 28
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBoxPanelBills)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListViewBills)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip4)
        Me.SplitContainer1.Panel1MinSize = 150
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListViewNF2)
        Me.SplitContainer1.Panel2MinSize = 150
        Me.SplitContainer1.Size = New System.Drawing.Size(216, 581)
        Me.SplitContainer1.SplitterDistance = 201
        Me.SplitContainer1.TabIndex = 27
        '
        'ListViewBills
        '
        Me.ListViewBills.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewBills.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewBills.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader11, Me.ColumnHeader12})
        Me.ListViewBills.ContextMenuStrip = Me.ContextMenuStripProcessBills
        Me.ListViewBills.FullRowSelect = True
        Me.ListViewBills.GridLines = True
        Me.ListViewBills.Location = New System.Drawing.Point(5, 22)
        Me.ListViewBills.MultiSelect = False
        Me.ListViewBills.Name = "ListViewBills"
        Me.ListViewBills.ShowGroups = False
        Me.ListViewBills.ShowItemToolTips = True
        Me.ListViewBills.Size = New System.Drawing.Size(206, 161)
        Me.ListViewBills.TabIndex = 0
        Me.ListViewBills.UseCompatibleStateImageBehavior = False
        Me.ListViewBills.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Bill #"
        Me.ColumnHeader11.Width = 57
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Bill Status"
        Me.ColumnHeader12.Width = 105
        '
        'ContextMenuStripProcessBills
        '
        Me.ContextMenuStripProcessBills.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator26, Me.ToolStripMenuItem18, Me.ToolStripSeparator27, Me.ToolStripMenuItem19})
        Me.ContextMenuStripProcessBills.Name = "ContextMenuStrip1"
        Me.ContextMenuStripProcessBills.Size = New System.Drawing.Size(202, 60)
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(198, 6)
        '
        'ToolStripMenuItem18
        '
        Me.ToolStripMenuItem18.Image = CType(resources.GetObject("ToolStripMenuItem18.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem18.Name = "ToolStripMenuItem18"
        Me.ToolStripMenuItem18.Size = New System.Drawing.Size(201, 22)
        Me.ToolStripMenuItem18.Text = "Show Selected Bill"
        '
        'ToolStripSeparator27
        '
        Me.ToolStripSeparator27.Name = "ToolStripSeparator27"
        Me.ToolStripSeparator27.Size = New System.Drawing.Size(198, 6)
        '
        'ToolStripMenuItem19
        '
        Me.ToolStripMenuItem19.Image = CType(resources.GetObject("ToolStripMenuItem19.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem19.Name = "ToolStripMenuItem19"
        Me.ToolStripMenuItem19.Size = New System.Drawing.Size(201, 22)
        Me.ToolStripMenuItem19.Text = "Open Bills Management"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 14)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Process Bills"
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip4.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 176)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip4.Size = New System.Drawing.Size(216, 25)
        Me.ToolStrip4.TabIndex = 183
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Margin = New System.Windows.Forms.Padding(8, 1, 0, 2)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(149, 22)
        Me.ToolStripButton2.Text = "Open Bill Management"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton5})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 351)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip2.Size = New System.Drawing.Size(216, 25)
        Me.ToolStrip2.TabIndex = 184
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Margin = New System.Windows.Forms.Padding(8, 1, 0, 2)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripButton3.Text = "Patient"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Margin = New System.Windows.Forms.Padding(0, 1, 8, 2)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(82, 22)
        Me.ToolStripButton4.Text = "NF2 Maint"
        Me.ToolStripButton4.ToolTipText = "Open NF2 Maintenance"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "ToolStripButton5"
        Me.ToolStripButton5.ToolTipText = "Print Checked / Selected NF2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 14)
        Me.Label3.TabIndex = 185
        Me.Label3.Text = "Process NF2"
        '
        'ListViewNF2
        '
        Me.ListViewNF2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewNF2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewNF2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader13, Me.ColumnHeader14})
        Me.ListViewNF2.ContextMenuStrip = Me.ContextMenuStripNF2
        Me.ListViewNF2.FullRowSelect = True
        Me.ListViewNF2.GridLines = True
        Me.ListViewNF2.LargeImageList = Me.ImageListTray
        Me.ListViewNF2.Location = New System.Drawing.Point(5, 22)
        Me.ListViewNF2.MultiSelect = False
        Me.ListViewNF2.Name = "ListViewNF2"
        Me.ListViewNF2.ShowGroups = False
        Me.ListViewNF2.ShowItemToolTips = True
        Me.ListViewNF2.Size = New System.Drawing.Size(206, 326)
        Me.ListViewNF2.SmallImageList = Me.ImageListTray
        Me.ListViewNF2.TabIndex = 37
        Me.ListViewNF2.UseCompatibleStateImageBehavior = False
        Me.ListViewNF2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Patient #"
        Me.ColumnHeader13.Width = 74
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "DOA"
        Me.ColumnHeader14.Width = 87
        '
        'ContextMenuStripNF2
        '
        Me.ContextMenuStripNF2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.SelectNoneToolStripMenuItem, Me.ToolStripSeparator28, Me.mnuShowSelectedPatientInfo1, Me.ToolStripSeparator3, Me.mnuPrinting1, Me.ToolStripSeparator25, Me.ToolStripMenuItem15})
        Me.ContextMenuStripNF2.Name = "ContextMenuStrip1"
        Me.ContextMenuStripNF2.Size = New System.Drawing.Size(218, 132)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Image = CType(resources.GetObject("SelectAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.SelectAllToolStripMenuItem.Text = "Check All"
        '
        'SelectNoneToolStripMenuItem
        '
        Me.SelectNoneToolStripMenuItem.Name = "SelectNoneToolStripMenuItem"
        Me.SelectNoneToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.SelectNoneToolStripMenuItem.Text = "Check None"
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(214, 6)
        '
        'mnuShowSelectedPatientInfo1
        '
        Me.mnuShowSelectedPatientInfo1.Image = CType(resources.GetObject("mnuShowSelectedPatientInfo1.Image"), System.Drawing.Image)
        Me.mnuShowSelectedPatientInfo1.Name = "mnuShowSelectedPatientInfo1"
        Me.mnuShowSelectedPatientInfo1.Size = New System.Drawing.Size(217, 22)
        Me.mnuShowSelectedPatientInfo1.Text = "Show Patient's Information"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(214, 6)
        '
        'mnuPrinting1
        '
        Me.mnuPrinting1.Image = CType(resources.GetObject("mnuPrinting1.Image"), System.Drawing.Image)
        Me.mnuPrinting1.Name = "mnuPrinting1"
        Me.mnuPrinting1.Size = New System.Drawing.Size(217, 22)
        Me.mnuPrinting1.Text = "Print Selected NF2"
        Me.mnuPrinting1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(214, 6)
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Image = CType(resources.GetObject("ToolStripMenuItem15.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        Me.ToolStripMenuItem15.Size = New System.Drawing.Size(217, 22)
        Me.ToolStripMenuItem15.Text = "Patient's NF2 Maintenance"
        '
        'TimerFlashRedBall
        '
        Me.TimerFlashRedBall.Interval = 500
        '
        'PanelSchedule
        '
        Me.PanelSchedule.BackColor = System.Drawing.Color.BurlyWood
        Me.PanelSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelSchedule.Controls.Add(Me.Panel6)
        Me.PanelSchedule.Controls.Add(Me.PictureBoxSchedule)
        Me.PanelSchedule.Controls.Add(Me.SplitContainerEUOIME)
        Me.PanelSchedule.Controls.Add(Me.ToolStrip5)
        Me.PanelSchedule.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelSchedule.Location = New System.Drawing.Point(599, 83)
        Me.PanelSchedule.Name = "PanelSchedule"
        Me.PanelSchedule.Size = New System.Drawing.Size(226, 581)
        Me.PanelSchedule.TabIndex = 26
        Me.PanelSchedule.Visible = False
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.ShowToBeScheduled)
        Me.Panel6.Location = New System.Drawing.Point(118, 1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(104, 18)
        Me.Panel6.TabIndex = 28
        '
        'PictureBoxSchedule
        '
        Me.PictureBoxSchedule.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxSchedule.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxSchedule.Image = CType(resources.GetObject("PictureBoxSchedule.Image"), System.Drawing.Image)
        Me.PictureBoxSchedule.Location = New System.Drawing.Point(201, 4)
        Me.PictureBoxSchedule.Name = "PictureBoxSchedule"
        Me.PictureBoxSchedule.Size = New System.Drawing.Size(16, 16)
        Me.PictureBoxSchedule.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBoxSchedule.TabIndex = 186
        Me.PictureBoxSchedule.TabStop = False
        '
        'SplitContainerEUOIME
        '
        Me.SplitContainerEUOIME.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerEUOIME.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerEUOIME.Name = "SplitContainerEUOIME"
        Me.SplitContainerEUOIME.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerEUOIME.Panel1
        '
        Me.SplitContainerEUOIME.Panel1.Controls.Add(Me.ListViewSchedule)
        Me.SplitContainerEUOIME.Panel1.Controls.Add(Me.Label5)
        '
        'SplitContainerEUOIME.Panel2
        '
        Me.SplitContainerEUOIME.Panel2.Controls.Add(Me.txtEUOComments)
        Me.SplitContainerEUOIME.Panel2.Controls.Add(Me.ListViewEUODetails)
        Me.SplitContainerEUOIME.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainerEUOIME.Panel2.Controls.Add(Me.ListViewEUOIME)
        Me.SplitContainerEUOIME.Size = New System.Drawing.Size(226, 556)
        Me.SplitContainerEUOIME.SplitterDistance = 204
        Me.SplitContainerEUOIME.TabIndex = 187
        '
        'ListViewSchedule
        '
        Me.ListViewSchedule.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewSchedule.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewSchedule.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10})
        Me.ListViewSchedule.ContextMenuStrip = Me.ContextMenuStripWarning
        Me.ListViewSchedule.FullRowSelect = True
        Me.ListViewSchedule.GridLines = True
        Me.ListViewSchedule.Location = New System.Drawing.Point(4, 19)
        Me.ListViewSchedule.MultiSelect = False
        Me.ListViewSchedule.Name = "ListViewSchedule"
        Me.ListViewSchedule.ShowGroups = False
        Me.ListViewSchedule.ShowItemToolTips = True
        Me.ListViewSchedule.Size = New System.Drawing.Size(218, 189)
        Me.ListViewSchedule.TabIndex = 0
        Me.ListViewSchedule.UseCompatibleStateImageBehavior = False
        Me.ListViewSchedule.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Pat #"
        Me.ColumnHeader9.Width = 57
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Name"
        Me.ColumnHeader10.Width = 130
        '
        'ContextMenuStripWarning
        '
        Me.ContextMenuStripWarning.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem13, Me.ToolStripSeparator22, Me.ToolStripMenuItem14})
        Me.ContextMenuStripWarning.Name = "ContextMenuStrip1"
        Me.ContextMenuStripWarning.Size = New System.Drawing.Size(218, 54)
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.ForeColor = System.Drawing.Color.Green
        Me.ToolStripMenuItem13.Image = CType(resources.GetObject("ToolStripMenuItem13.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.ShowShortcutKeys = False
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(217, 22)
        Me.ToolStripMenuItem13.Text = "IME / EUO Confirmed"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(214, 6)
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Image = CType(resources.GetObject("ToolStripMenuItem14.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(217, 22)
        Me.ToolStripMenuItem14.Text = "Show Patient's Information"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 14)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "To Be Scheduled"
        '
        'txtEUOComments
        '
        Me.txtEUOComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEUOComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEUOComments.Location = New System.Drawing.Point(4, 288)
        Me.txtEUOComments.Multiline = True
        Me.txtEUOComments.Name = "txtEUOComments"
        Me.txtEUOComments.ReadOnly = True
        Me.txtEUOComments.Size = New System.Drawing.Size(218, 57)
        Me.txtEUOComments.TabIndex = 35
        '
        'ListViewEUODetails
        '
        Me.ListViewEUODetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewEUODetails.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewEUODetails.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader16, Me.ColumnHeader17})
        Me.ListViewEUODetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewEUODetails.FullRowSelect = True
        Me.ListViewEUODetails.GridLines = True
        Me.ListViewEUODetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewEUODetails.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem10, ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15})
        Me.ListViewEUODetails.Location = New System.Drawing.Point(4, 175)
        Me.ListViewEUODetails.Name = "ListViewEUODetails"
        Me.ListViewEUODetails.ShowItemToolTips = True
        Me.ListViewEUODetails.Size = New System.Drawing.Size(218, 107)
        Me.ListViewEUODetails.TabIndex = 34
        Me.ListViewEUODetails.UseCompatibleStateImageBehavior = False
        Me.ListViewEUODetails.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Request DT"
        Me.ColumnHeader16.Width = 67
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Request"
        Me.ColumnHeader17.Width = 140
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(196, 14)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Insurance Exams To Be Confirmed"
        '
        'ListViewEUOIME
        '
        Me.ListViewEUOIME.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewEUOIME.BackColor = System.Drawing.Color.White
        Me.ListViewEUOIME.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader15})
        Me.ListViewEUOIME.ContextMenuStrip = Me.ContextMenuStripWarning
        Me.ListViewEUOIME.ForeColor = System.Drawing.Color.Black
        Me.ListViewEUOIME.FullRowSelect = True
        Me.ListViewEUOIME.GridLines = True
        Me.ListViewEUOIME.Location = New System.Drawing.Point(4, 20)
        Me.ListViewEUOIME.MultiSelect = False
        Me.ListViewEUOIME.Name = "ListViewEUOIME"
        Me.ListViewEUOIME.ShowGroups = False
        Me.ListViewEUOIME.ShowItemToolTips = True
        Me.ListViewEUOIME.Size = New System.Drawing.Size(218, 149)
        Me.ListViewEUOIME.TabIndex = 1
        Me.ListViewEUOIME.UseCompatibleStateImageBehavior = False
        Me.ListViewEUOIME.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Pat #"
        Me.ColumnHeader7.Width = 48
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Name"
        Me.ColumnHeader8.Width = 101
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Type"
        Me.ColumnHeader15.Width = 39
        '
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip5.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton8})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 556)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip5.Size = New System.Drawing.Size(226, 25)
        Me.ToolStrip5.TabIndex = 185
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(8, 1, 0, 2)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripButton1.Text = "Show Patient"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Margin = New System.Windows.Forms.Padding(0, 1, 8, 2)
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton8.Text = "Report"
        Me.ToolStripButton8.ToolTipText = "Open NF2 Maintenance"
        '
        'TimerAutoUpdate
        '
        Me.TimerAutoUpdate.Interval = 1800000
        '
        'ImageListDBStatus
        '
        Me.ImageListDBStatus.ImageStream = CType(resources.GetObject("ImageListDBStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListDBStatus.TransparentColor = System.Drawing.Color.White
        Me.ImageListDBStatus.Images.SetKeyName(0, "DBStatus.png")
        Me.ImageListDBStatus.Images.SetKeyName(1, "DBStatusOK.png")
        Me.ImageListDBStatus.Images.SetKeyName(2, "DBStatusWarning.png")
        Me.ImageListDBStatus.Images.SetKeyName(3, "DBStatusError.png")
        '
        'PanelMessage
        '
        Me.PanelMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelMessage.BackgroundImage = CType(resources.GetObject("PanelMessage.BackgroundImage"), System.Drawing.Image)
        Me.PanelMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelMessage.Controls.Add(Me.lblMessage)
        Me.PanelMessage.Controls.Add(Me.Panel3)
        Me.PanelMessage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelMessage.Location = New System.Drawing.Point(0, 561)
        Me.PanelMessage.Name = "PanelMessage"
        Me.PanelMessage.Size = New System.Drawing.Size(599, 103)
        Me.PanelMessage.TabIndex = 28
        Me.PanelMessage.Visible = False
        '
        'lblMessage
        '
        Me.lblMessage.AutoEllipsis = True
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMessage.Location = New System.Drawing.Point(0, 17)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Padding = New System.Windows.Forms.Padding(5)
        Me.lblMessage.Size = New System.Drawing.Size(87, 23)
        Me.lblMessage.TabIndex = 15
        Me.lblMessage.Text = "Message Body"
        Me.lblMessage.UseMnemonic = False
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.lblMessageTitle)
        Me.Panel3.Controls.Add(Me.PictureBoxClose)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(599, 17)
        Me.Panel3.TabIndex = 16
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(2, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = "1"
        '
        'lblMessageTitle
        '
        Me.lblMessageTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblMessageTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblMessageTitle.ForeColor = System.Drawing.Color.White
        Me.lblMessageTitle.Location = New System.Drawing.Point(19, 1)
        Me.lblMessageTitle.Name = "lblMessageTitle"
        Me.lblMessageTitle.Size = New System.Drawing.Size(524, 14)
        Me.lblMessageTitle.TabIndex = 0
        Me.lblMessageTitle.Text = "Message From Manager"
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.FullOpen = True
        Me.ColorDialog1.SolidColorOnly = True
        '
        'ToolStrip6
        '
        Me.ToolStrip6.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip6.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip6.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip6.Name = "ToolStrip6"
        Me.ToolStrip6.Size = New System.Drawing.Size(100, 25)
        Me.ToolStrip6.TabIndex = 0
        '
        'PictureBoxGlobe
        '
        Me.PictureBoxGlobe.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxGlobe.Image = CType(resources.GetObject("PictureBoxGlobe.Image"), System.Drawing.Image)
        Me.PictureBoxGlobe.Location = New System.Drawing.Point(1132, 27)
        Me.PictureBoxGlobe.Name = "PictureBoxGlobe"
        Me.PictureBoxGlobe.Size = New System.Drawing.Size(21, 20)
        Me.PictureBoxGlobe.TabIndex = 30
        Me.PictureBoxGlobe.TabStop = False
        Me.PictureBoxGlobe.Visible = False
        '
        'MDIForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1260, 686)
        Me.Controls.Add(Me.PictureBoxGlobe)
        Me.Controls.Add(Me.PanelMessage)
        Me.Controls.Add(Me.PanelSchedule)
        Me.Controls.Add(Me.PanelBills)
        Me.Controls.Add(Me.PanelRequests)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.MinimumSize = New System.Drawing.Size(1024, 595)
        Me.Name = "MDIForm1"
        Me.Text = "eMedicalOffice"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.PictureBoxClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PanelRequests.ResumeLayout(False)
        Me.PanelRequests.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ContextMenuStripRequest.ResumeLayout(False)
        CType(Me.PictureBoxPanelReminders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxPanelBills, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBills.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStripProcessBills.ResumeLayout(False)
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ContextMenuStripNF2.ResumeLayout(False)
        Me.PanelSchedule.ResumeLayout(False)
        Me.PanelSchedule.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.PictureBoxSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerEUOIME.Panel1.ResumeLayout(False)
        Me.SplitContainerEUOIME.Panel1.PerformLayout()
        Me.SplitContainerEUOIME.Panel2.ResumeLayout(False)
        Me.SplitContainerEUOIME.Panel2.PerformLayout()
        Me.SplitContainerEUOIME.ResumeLayout(False)
        Me.ContextMenuStripWarning.ResumeLayout(False)
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.PanelMessage.ResumeLayout(False)
        Me.PanelMessage.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxGlobe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents lblUserName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblPosition As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents AdministrativeToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer5Sec As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FullScreenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblOffice As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewPatientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdminStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ScannerDocumentMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SchedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUnlockPatientProfiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdminStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripStatusDBServer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ReportsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatientsScheduleReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemTransportationRequest As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatientInformationReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TodaysScheduledProceduresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblServer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TechScheduleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButtonSchedule As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonPatientProfile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents QuickSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonBillMaintenance As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImageListTray As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripButtonBilling As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RequestImageDiskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ProduceDiskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageDiskReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BillingToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemCDReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessagePoolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PhoneBookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdminStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAdminStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SignInSheetByDateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SignInSheetByPatientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InHouseBillingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OutBillingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BillingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BillMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents POMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindPOMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatientsProcedureReadingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatientsProcedureReadingsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MRIDataExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoFaultMissingClaimNumberReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents InsuranceStatisticsReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoFaultMissingInformationReceivedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BillingTemplatesMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents QuickScheduleReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelRequests As System.Windows.Forms.Panel
    Friend WithEvents TimerRefresh As System.Windows.Forms.Timer
    Friend WithEvents ListViewRequests As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TimerReminderReset As System.Windows.Forms.Timer
    Friend WithEvents ListViewRequestsDetails As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageDisksProcessScanPOMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListViewrequestActions As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripMenuItemRequestsMaintenance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButtonInsuranceMainenance As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDiagnosticsProceduresMaintenance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DiagnosticsMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcedureMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DiagnosisMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InjuryTypesMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelBills As System.Windows.Forms.Panel
    Friend WithEvents ListViewBills As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxPanelReminders As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxPanelBills As System.Windows.Forms.PictureBox
    Friend WithEvents TimerFlashRedBall As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnnouncementsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemLetterHead As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FindCheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemTodayPayments As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblOfficeType As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuOfficesCompaniesMaintenance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReferringOfficesMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OfficesMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsurancesMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReferringOfficesStatisticReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransportationMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BillingCompaniesMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AttorneyMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripBillingPaymentManagementReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListViewNF2 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStripNF2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuShowSelectedPatientInfo1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrinting1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents PatientsNF2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CheckBoxDoNotShowRequests As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxDoNotShowBills As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripSeparatorNotifications As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShowNotificationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowRequestsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItemOTMaintenance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemChangePatientInformation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeRefferingDoctorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeTreatingProviderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeBillingProviderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatientProcedureInformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEmployeeMaintenance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatientsSearchToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogOffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TreatmentStatisticReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintTodaysScheduleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScheduleMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelSchedule As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ListViewSchedule As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents ShowToBeScheduled As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItemToBeScheduled As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBoxSchedule As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerAutoUpdate As System.Windows.Forms.Timer
    Friend WithEvents SplitContainerEUOIME As System.Windows.Forms.SplitContainer
    Friend WithEvents ListViewEUOIME As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListViewEUODetails As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtEUOComments As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItemProceduresSchedule As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DBStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImageListDBStatus As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStripWarning As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem14 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripProcessBills As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuStripRequest As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem16 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem15 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem17 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem18 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator27 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem19 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BulkEmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailerMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator29 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EmailerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SecuritySettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetPatientInformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelMessage As System.Windows.Forms.Panel
    Friend WithEvents lblMessageTitle As System.Windows.Forms.Label
    Friend WithEvents PictureBoxClose As System.Windows.Forms.PictureBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents AdminMessagingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripButtonCollection As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuBankDepositsAdmin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CollectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem21 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProceduresToBeRescheduledReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsuranceVerificationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator30 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonIntakeForm As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintPatientIntakeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator32 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator33 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator34 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BackgrounfdColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem23 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem24 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem25 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem26 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem27 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem28 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem29 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator35 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CustomColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents FindDuplicatePatientsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemReadyForArbitration As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator36 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip6 As System.Windows.Forms.ToolStrip
    Friend WithEvents PaymentsProgressAnalysisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowSmallToolBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowImagesOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowTextOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowImagesAndTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButtonPatSearchAndTools As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator37 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShowPrintIntakeFormButtonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator38 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator39 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem22 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem30 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemCollection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator31 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator40 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemWeb As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemBookMarkManager As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBoxGlobe As System.Windows.Forms.PictureBox

End Class
