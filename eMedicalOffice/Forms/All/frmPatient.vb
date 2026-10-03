Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports System.Threading.Tasks
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmPatient
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public m_SortingColumn As ColumnHeader
    Public m_SortingColumnRelated As ColumnHeader
    Public m_SortingColumnLog As ColumnHeader
    Public m_SortingColumnRequests As ColumnHeader
    Public m_SortingColumnAppointmentsLog As ColumnHeader
    Public m_SortingColumnDocuments As ColumnHeader
    Public m_SortingColumnComments As ColumnHeader
    Public m_SortingColumnReadings As ColumnHeader
    Public pr_SortingColumn As ColumnHeader
    Public m_SortingColumnRequestsAction As ColumnHeader
    Public m_SortingColumnCancelations As ColumnHeader

    Public SaveSelectedItem As ListViewItem
    Public SaveCasyTypeID As Integer
    Public UpdateInd As Boolean
    Public frmImportPat As New frmImportPatients

    Public Enum AddEditMode
        None = 0
        AddNew = 1
        Edit = 2
    End Enum

    Public OpMode As AddEditMode
    Private KeyDn As Boolean
    Public SaveCaseStatusID As Integer 'Used to see if case status changed - update Case Status Date
    Public InitialEdit As Boolean
    Public HideCalledForm As Form
    Public NoFindDuplicatePatients As Boolean

    Private Sub frmPatient_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        On Error Resume Next
        TextBoxSearch.Focus()
    End Sub

    Private Sub frmPatient_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        If cmdUpdate.Enabled Then
            If _
                MsgBox("You have unsaved data. Discard changes?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) =
                MsgBoxResult.No Then
                Application.DoEvents()
                e.Cancel = True
                Visible = True
                Exit Sub
            End If
            Cancel_Edit(False)
        End If
        frmImportPat.PatientsProviders.ForceClose = True
        frmImportPat.PatientsProviders.Close()
        frmImportPat.PatientsProviders.Dispose()
        frmImportPat.Close()
        frmImportPat.Dispose()
        gListview_Settings(Me, ListViewPatients, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewDocs, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewComments, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewPayments, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewReadings, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewCancelations, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewPatientLog, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewActions, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewRequests, ReadWrite.sWrite)
        LockUnclockProfile(False)
        pdfViewer.CloseDocument(False)
        If UpdateInd Then
            DialogResult = DialogResult.OK
        End If
        Dispose()
    End Sub

    Public InitialPatientName As String
    Public InitialTab As Long = 0

    'Public TabPageWCInfo As TabPage
    Private Sub SetFont(Optional incr As Integer = 0)
        Dim BaseSize = 8
        If BaseSize + My.Settings.FontSize + incr < 8 Or BaseSize + My.Settings.FontSize + incr > 15 Then Return
        My.Settings.FontSize = My.Settings.FontSize + incr
        My.Settings.Save()
        Dim F = New Font(Font.FontFamily, BaseSize + My.Settings.FontSize, FontStyle.Regular)
        ListViewPatients.Font = F
        ListViewPatientsRelated.Font = F
        ListViewDocs.Font = F
        ListViewComments.Font = F
        TextBoxCommentView.Font = F
        ListViewReadings.Font = F
        TextBoxReading.Font = F
        TreeViewBills.Font = F
        ListViewPayments.Font = F
        ListViewBillComments.Font = F
        ListViewCancelations.Font = F
        ListViewPatientLog.Font = F
        txtFieldsChanged.Font = F
        ListViewRequests.Font = F
        ListViewActions.Font = F
        ListViewIME.Font = F
        ListViewProcedures.Font = F
        gListViewRestoreDefaultColumnWidth(ListViewPatients)
        gListViewRestoreDefaultColumnWidth(ListViewPatientsRelated)
        gListViewRestoreDefaultColumnWidth(ListViewDocs)
        gListViewRestoreDefaultColumnWidth(ListViewComments)
        gListViewRestoreDefaultColumnWidth(ListViewReadings)
        gListViewRestoreDefaultColumnWidth(ListViewPayments)
        gListViewRestoreDefaultColumnWidth(ListViewBillComments)
        gListViewRestoreDefaultColumnWidth(ListViewCancelations)
        gListViewRestoreDefaultColumnWidth(ListViewPatientLog)
        gListViewRestoreDefaultColumnWidth(ListViewRequests)
        gListViewRestoreDefaultColumnWidth(ListViewActions)
        gListViewRestoreDefaultColumnWidth(ListViewIME)
        gListViewRestoreDefaultColumnWidth(ListViewProcedures)
    End Sub

    Public Sub frmPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = False
        'SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        'SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        pdfViewer.CloseDocument()
        'TabPageWCInfo = TabPageWC
        cboSuffix.Items.Add("Sr")
        cboSuffix.Items.Add("Jr")

        cboSuffix.Items.Add("I")
        cboSuffix.Items.Add("II")
        cboSuffix.Items.Add("III")
        cboSuffix.Items.Add("IV")
        cboSuffix.Items.Add("V")
        TextBoxWebURL.Text = gOfficeURL

        'ListViewProcedures.Columns.Clear()
        SetFont()
        Select Case gOfficeTypeID
            Case 1 ' NY RADIOLOGY
                'ListViewProcedures.Columns.Add("Schedule DT").ImageKey = "SORT1"
                'ListViewProcedures.Columns.Add("Procedure").ImageKey = "SORT0"
                'ListViewProcedures.Columns.Add("Treating Provider").ImageKey = "SORT0"
                'ListViewProcedures.Columns.Add("Billing Provider").ImageKey = "SORT0"
                'ListViewProcedures.Columns.Add("Ref Doctor").ImageKey = "SORT0"
                'ListViewProcedures.Columns.Add("Type").ImageKey = "SORT0"
                'ListViewProcedures.Columns.Add("Comments").ImageKey = "SORT0"
                'ListViewProcedures.Columns.Add("Accession #").ImageKey = "SORT0"
                ListViewProcedures.Columns(0).DisplayIndex = 0
                ListViewProcedures.Columns(5).DisplayIndex = 1
                ListViewProcedures.Columns(1).DisplayIndex = 2
                ListViewProcedures.Columns(2).DisplayIndex = 3
                ListViewProcedures.Columns(3).DisplayIndex = 4
                ListViewProcedures.Columns(4).DisplayIndex = 5
                ListViewProcedures.Columns(6).DisplayIndex = 6
                ListViewProcedures.Columns(7).DisplayIndex = 7
                ListViewProcedures.Columns(7).TextAlign = HorizontalAlignment.Right
                ToolStripMenuItemSchedule.Visible = False
                PrintPatientsNF2FormToolStripMenuItem.Visible = False
                ToolStripButtonUnlockReading.Visible = True
            Case 3 'NJ RADIOLOGY
                'ListViewProcedures.Columns.Add("Schedule DT").ImageKey = "SORT1"
                'ListViewProcedures.Columns.Add("Procedure").ImageKey = "SORT0"
                'ListViewProcedures.Columns.Add("Treating Provider").ImageKey = "SORT0"
                'ListViewProcedures.Columns.Add("Billing Provider").ImageKey = "SORT0"
                'ListViewProcedures.Columns.Add("Ref Doctor").ImageKey = "SORT0"
                'ListViewProcedures.Columns.Add("Type").ImageKey = "SORT0"
                'ListViewProcedures.Columns.Add("Comments").ImageKey = "SORT0"
                'ListViewProcedures.Columns.Add("Accession #").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Pre-Cert DT").ImageKey = "SORT0"
                ListViewProcedures.Columns(0).DisplayIndex = 0
                ListViewProcedures.Columns(5).DisplayIndex = 2
                ListViewProcedures.Columns(1).DisplayIndex = 3
                ListViewProcedures.Columns(2).DisplayIndex = 4
                ListViewProcedures.Columns(3).DisplayIndex = 5
                ListViewProcedures.Columns(4).DisplayIndex = 6
                ListViewProcedures.Columns(6).DisplayIndex = 7
                ListViewProcedures.Columns(7).DisplayIndex = 8
                ListViewProcedures.Columns(7).TextAlign = HorizontalAlignment.Right
                ListViewProcedures.Columns(8).DisplayIndex = 1
                ToolStripMenuItemSchedule.Visible = False
                PrintPatientsNF2FormToolStripMenuItem.Visible = False
                ToolStripButtonUnlockReading.Visible = True
        End Select
        ListViewPatients.HideSelection = True
        ListViewProcedures.HideSelection = True
        ListViewDocs.HideSelection = True
        ListViewComments.HideSelection = True
        ListViewReadings.HideSelection = True
        ListViewPayments.HideSelection = True
        ListViewBillComments.HideSelection = True
        ListViewCancelations.HideSelection = True
        ListViewPatientLog.HideSelection = True
        ListViewRequests.HideSelection = True
        ListViewActions.HideSelection = True
        ListViewIME.HideSelection = True
        'gListview_Settings(Me, ListViewPatients, ReadWrite.sRead)
        '''gListview_Settings(Me, ListViewDocs, ReadWrite.sRead)
        '''gListview_Settings(Me, ListViewComments, ReadWrite.sRead)
        '''gListview_Settings(Me, ListViewProcedures, ReadWrite.sRead, True)
        '''gListview_Settings(Me, ListViewPayments, ReadWrite.sRead)
        '''gListview_Settings(Me, ListViewReadings, ReadWrite.sRead)
        '''gListview_Settings(Me, ListViewCancelations, ReadWrite.sRead)
        '''gListview_Settings(Me, ListViewPatientLog, ReadWrite.sRead)
        '''gListview_Settings(Me, ListViewActions, ReadWrite.sRead)
        '''gListview_Settings(Me, ListViewRequests, ReadWrite.sRead)

        m_SortingColumn = ListViewPatients.Columns(1)
        m_SortingColumnRelated = ListViewPatientsRelated.Columns(1)
        m_SortingColumnLog = ListViewPatientLog.Columns(0)
        m_SortingColumnDocuments = ListViewDocs.Columns(0)
        m_SortingColumnComments = ListViewComments.Columns(0)
        m_SortingColumnReadings = ListViewReadings.Columns(0)
        pr_SortingColumn = ListViewProcedures.Columns(0)
        m_SortingColumnRequests = ListViewRequests.Columns(0)
        m_SortingColumnRequestsAction = ListViewActions.Columns(0)
        m_SortingColumnCancelations = ListViewActions.Columns(0)

        txtFName.AutoCompleteCustomSource = gAutocompleteFname
        txtLName.AutoCompleteCustomSource = gAutocompleteLName
        txtAddress1.AutoCompleteCustomSource = gAutocompleteAddress
        txtCity.AutoCompleteCustomSource = gAutocompleteCity

        'TextBoxAttorney.AutoCompleteCustomSource = gAutocompleteAttorneys

        txtEmployerName.AutoCompleteCustomSource = gAutocompleteEmployerName
        txtEmployerAddress.AutoCompleteCustomSource = gAutocompleteAddress
        txtOccupation.AutoCompleteCustomSource = gAutocompleteOccupation

        txtAdjuster.AutoCompleteCustomSource = gAutocompleteAdjusterName

        txtPolicyHolderFName.AutoCompleteCustomSource = gAutocompleteFname
        txtPolicyHolderLName.AutoCompleteCustomSource = gAutocompleteLName
        txtPolicyHolderAddress.AutoCompleteCustomSource = gAutocompleteAddress
        txtPolicyHolderCity.AutoCompleteCustomSource = gAutocompleteCity

        txtPolicyHolderFName1.AutoCompleteCustomSource = gAutocompleteFname
        txtPolicyHolderLName1.AutoCompleteCustomSource = gAutocompleteLName
        txtPolicyHolderAddress1.AutoCompleteCustomSource = gAutocompleteAddress
        txtPolicyHolderCity1.AutoCompleteCustomSource = gAutocompleteCity

        'AddHandler ComboBoxInsuranceCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        'AddHandler ComboBoxInsuranceCompanyID.Leave, AddressOf sSearchComboBox_Leave

        AddHandler ComboBoxInsuranceCompanyID1.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler ComboBoxInsuranceCompanyID1.Leave, AddressOf sSearchComboBox_Leave

        AddHandler ComboBoxReferringCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler ComboBoxReferringCompanyID.Leave, AddressOf sSearchComboBox_Leave

        AddHandler ComboBoxReferringDoctor.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler ComboBoxReferringDoctor.Leave, AddressOf sSearchComboBox_Leave

        AddHandler ComboBoxTransportationCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler ComboBoxTransportationCompanyID.Leave, AddressOf sSearchComboBox_Leave
        ToolStrip2.Visible = True
        ToolStrip3.Visible = True
        ToolStrip4.Visible = True
        ToolStrip6.Visible = True
        gSetup_GotFocus(Me)
        SkipSearch = True
        Load_Data()

        ComboBoxSearchCaseType.SelectedIndex = 0
        If InitialPatientName <> "" Then
            ComboBoxSearchCaseStatus.SelectedIndex = 0
        Else
            ComboBoxSearchCaseStatus.SelectedIndex = 0
        End If
        SkipSearch = False
        TextBoxSearch.Text = InitialPatientName
        TabControl1.SelectedIndex = InitialTab
        If InitialEdit Then cmdEdit_Click(Nothing, Nothing)
        TimerLoad.Enabled = True
        Cursor = Cursors.Default
        On Error Resume Next
        TextBoxSearch.Focus()
        'cmdAddInsuranceAddress.Visible = gCurrentEmployee.PositionID < 3
        'cmdAddInsuranceAddress.Visible = False
        ImportPatientsToolStripMenuItem.Visible = False
        ToolStripSeparator8.Visible = False
        ImportPatientsToolStripMenuItem.Visible = gCurrentEmployee.PositionID = 1
        ToolStripSeparator8.Visible = gCurrentEmployee.PositionID = 1
        FindDuplicatePatientsToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 4

        If gCurrentEmployee.PositionID = 4 Or gCurrentEmployee.PositionID = 10 Then '
            TabControl1.TabPages.Remove(TabPageBills)
        End If
        If gCurrentEmployee.PositionID > 3 Then '
            If TabControl1.TabPages.Contains(TabPageLog) Then TabControl1.TabPages.Remove(TabPageLog)
        End If
        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            ToolStripButtonUnlockReading.Visible = gCurrentEmployee.PositionID < 3
            If TabControl1.TabPages.Contains(TabPageExamination) Then TabControl1.TabPages.Remove(TabPageExamination)
        End If
        'if TabControl1.TabPages.Contains(TabPageWC) then TabControl1.TabPages.Remove(TabPageWC)

        Enable_Controls(False)
        If NoFindDuplicatePatients Then
            FindDuplicatePatientsToolStripMenuItem.Visible = False
        End If
        Dim H As ToolStripControlHost
        H = New ToolStripControlHost(MonthCalendarPopUp)
        ContextMenuPopUpCalendar.Items.Insert(0, H)
        ContextMenuPopUpCalendar.Show()
        ContextMenuPopUpCalendar.Hide()

        H = New ToolStripControlHost(DateTimePickerPopUp)
        ContextMenuStripTime.Items.Insert(0, H)
        ContextMenuStripTime.Show()
        ContextMenuStripTime.Hide()
        ContextMenuStripTime.Items(0).Padding = New Padding(0, 20, 0, 20)
        If _
            SystemFunctions.BillingManagement = False Or gCurrentEmployee.PositionID = 4 Or
            gCurrentEmployee.PositionID = 10 Then
            FindPatientBillsToolStripMenuItem.Visible = False
            ToolStripSeparator18.Visible = False
        End If
        ToolStripSeparatorNetSearch.Visible = False
        NetSearchToolStripMenuItem.Visible = False
        '1	Administrator
        '2	Manager
        '3	Supervisor
        '4	Front Desk
        '5	Doctor
        '6	Billing
        '10	Technician
        '100	Transcriptionist
        Dim ConnectionsCount As Integer = gOffices.Where(Function(x) x.ConnectionString <> "").Count()
        If ConnectionsCount > 1 And
            (gCurrentEmployee.PositionID < 3 Or gCurrentEmployee.PositionID = 6 Or gCurrentEmployee.PositionID = 4) Then
            ToolStripSeparatorNetSearch.Visible = True
            NetSearchToolStripMenuItem.Visible = True
        End If
        If Me.Owner IsNot Nothing Then
            If Me.Owner.Name = "frmNetSearch" Then
                Me.Owner.UseWaitCursor = False
                Me.Owner.Hide()
            End If
        End If
        Cursor = Cursors.Default
        TimerRefreshWhenMaximized.Enabled = True
    End Sub

    Private SkipSearch As Boolean

    Public Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Try
            Do While preLoadBillingCompanies.Count = 0
                ' Make sure all async data loaded...
                Application.DoEvents()
            Loop

            ComboBoxSearchCaseStatus.Items.Clear()
            For Each item In preLoadCaseStatuses
                ComboBoxSearchCaseStatus.Items.Add(item)
                If item.Value <> 0 Then
                    ComboBoxCaseStatusID.Items.Add(item)
                End If
            Next

            ComboBoxState.Items.Clear()
            ComboBoxStateOfAccident.Items.Clear()
            ComboBoxPolicyHolderState.Items.Clear()
            cboEmployerAddressState.Items.Clear()
            cboWCInsuranceCarrierAddressState.Items.Clear()

            For Each item In preLoadStates
                ComboBoxState.Items.Add(item)
                ComboBoxPolicyHolderState1.Items.Add(item)
                ComboBoxPolicyHolderState.Items.Add(item)
                ComboBoxStateOfAccident.Items.Add(item)
                cboWCInsuranceCarrierAddressState.Items.Add(item)
                cboEmployerAddressState.Items.Add(item)
            Next
            ComboBoxMaritalStatusID.Items.Clear()
            For Each item In preLoadMaritalStatuses
                ComboBoxMaritalStatusID.Items.Add(item)
            Next

            ComboBoxEmploymentStatusID.Items.Clear()
            For Each item In preLoadEmploymentStatuses
                ComboBoxEmploymentStatusID.Items.Add(item)
            Next

            ComboBoxInjuryID.Items.Clear()
            For Each item In preLoadInjuryTypes
                ComboBoxInjuryID.Items.Add(item)
            Next

            ComboBoxTransportationCompanyID.Items.Clear()
            For Each item In preLoadTransportationCompanies
                ComboBoxTransportationCompanyID.Items.Add(item)
            Next

            ComboBoxReferringCompanyID.Items.Clear()
            Reader =
                gSQLGetDataReaderAsync(
                    "Select OfficeID, OfficeName from ReferringOffices Where ActiveInd=1 order by OfficeName").Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxReferringCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)),
                                                                          Reader("OfficeName").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()

            ComboBoxPatientTypeID.Items.Clear()
            For Each item In preLoadPatientTypes
                ComboBoxPatientTypeID.Items.Add(item)
            Next

            ComboBoxCaseTypeID.Items.Clear()
            ComboBoxSearchCaseType.Items.Clear()
            ComboBoxSearchCaseType.Items.Add(New ValueDescription(0, "All Types"))
            For Each item In preLoadCaseTypes
                ComboBoxCaseTypeID.Items.Add(item)
                ComboBoxSearchCaseType.Items.Add(item)
            Next

            ComboBoxRelationToInsuredID.Items.Clear()
            ComboBoxRelationToInsuredID1.Items.Clear()
            For Each item In preLoadRelationships
                ComboBoxRelationToInsuredID.Items.Add(item)
                ComboBoxRelationToInsuredID1.Items.Add(item)
            Next

            cboInjury.Items.Clear()
            For Each item In preLoadSymptoms
                cboInjury.Items.Add(item)
            Next
            cboBillingCompany.Items.Clear()
            For Each item In preLoadBillingCompanies
                cboBillingCompany.Items.Add(item)
            Next

            Load_Patient_Attorneys()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Public Sub Load_Data_Back()
        Dim Reader As SqlClient.SqlDataReader
        Try
            ComboBoxSearchCaseStatus.Items.Clear()
            Reader = gSQLGetDataReaderAsync("SELECT CaseStatusID, Description FROM CaseStatuses Order By ShowOrder").Result
            If Reader Is Nothing Then Exit Sub
            ComboBoxSearchCaseStatus.Items.Add(New ValueDescription(0, "All Statuses"))
            Do Until Reader.Read = False
                ComboBoxSearchCaseStatus.Items.Add(New ValueDescription(CLng(Val(Reader("CaseStatusID").ToString)),
                                                                            Reader("Description").ToString))
                ComboBoxCaseStatusID.Items.Add(New ValueDescription(CLng(Val(Reader("CaseStatusID").ToString)),
                                                                        Reader("Description").ToString))
            Loop

            Reader.Close()
            Reader.Dispose()
            ComboBoxState.Items.Clear()
            ComboBoxStateOfAccident.Items.Clear()
            ComboBoxPolicyHolderState.Items.Clear()
            cboWCInsuranceCarrierAddressState.Items.Clear()
            Reader = gSQLGetDataReaderAsync("Select State, ShowOrder from States Order by ShowOrder").Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxState.Items.Add(Reader("State").ToString)
                ComboBoxPolicyHolderState1.Items.Add(Reader("State").ToString)
                ComboBoxPolicyHolderState.Items.Add(Reader("State").ToString)
                ComboBoxStateOfAccident.Items.Add(Reader("State").ToString)
                cboWCInsuranceCarrierAddressState.Items.Add(Reader("State").ToString)
            Loop
            Reader.Close()
            Reader.Dispose()
            ComboBoxMaritalStatusID.Items.Clear()
            Reader = gSQLGetDataReaderAsync("Select MaritalStatusID, Description from MaritalStatuses").Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxMaritalStatusID.Items.Add(New ValueDescription(CLng(Val(Reader("MaritalStatusID").ToString)),
                                                                       Reader("Description").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()
            ComboBoxEmploymentStatusID.Items.Clear()
            Reader = gSQLGetDataReaderAsync("Select EmploymentStatusID, Description from EmploymentStatuses").Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxEmploymentStatusID.Items.Add(
                    New ValueDescription(
                        CLng(Val(Reader("EmploymentStatusID").ToString)), Reader("Description").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()
            ComboBoxInjuryID.Items.Clear()
            Reader = gSQLGetDataReaderAsync("Select InjuryID, InjuryName from InjuryTypes Where ActiveInd=1").Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxInjuryID.Items.Add(New ValueDescription(CLng(Val(Reader("InjuryID").ToString)),
                                                                Reader("InjuryName").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()
            ComboBoxTransportationCompanyID.Items.Clear()
            Reader = gSQLGetDataReaderAsync("Select CompanyID, CompanyName from TransportationCompanies Where ActiveInd=1").Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxTransportationCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)),
                                                                               Reader("CompanyName").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()
            ComboBoxReferringCompanyID.Items.Clear()
            Reader =
                gSQLGetDataReaderAsync(
                    "Select OfficeID, OfficeName from ReferringOffices Where ActiveInd=1 order by OfficeName").Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxReferringCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)),
                                                                          Reader("OfficeName").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()
            ComboBoxPatientTypeID.Items.Clear()
            Reader = gSQLGetDataReaderAsync("Select PatientTypeID, Description from PatientTypes").Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxPatientTypeID.Items.Add(New ValueDescription(CLng(Val(Reader("PatientTypeID").ToString)),
                                                                     Reader("Description").ToString))

            Loop
            Reader.Close()
            Reader.Dispose()
            ComboBoxCaseTypeID.Items.Clear()
            ComboBoxSearchCaseType.Items.Clear()
            ComboBoxSearchCaseType.Items.Add(New ValueDescription(0, "All Types"))
            Reader = gSQLGetDataReaderAsync("Select CaseTypeID, Description from CaseTypes order by ShowOrder").Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxCaseTypeID.Items.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)),
                                                                  Reader("Description").ToString))
                ComboBoxSearchCaseType.Items.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)),
                                                                      Reader("Description").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()
            ComboBoxRelationToInsuredID.Items.Clear()
            ComboBoxRelationToInsuredID1.Items.Clear()
            Reader = gSQLGetDataReaderAsync("Select RelationshipID, Description from Relationships").Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxRelationToInsuredID.Items.Add(New ValueDescription(CLng(Val(Reader("RelationshipID").ToString)),
                                                                           Reader("Description").ToString))
                ComboBoxRelationToInsuredID1.Items.Add(New ValueDescription(CLng(Val(Reader("RelationshipID").ToString)),
                                                                            Reader("Description").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()
            'gAutocompleteAttorneys.Clear()
            'Reader =
            '    gSQLGetDataReaderAsync("SELECT CompanyName FROM InsuranceCompanies WHERE (CaseTypeID = 5) ORDER BY CompanyName").Result
            'Do Until Reader.Read = False
            '    gAutocompleteAttorneys.Add(Reader("CompanyName").ToString.Trim)
            'Loop
            ''Reader = gSQLGetDataReaderAsync("SELECT DISTINCT Attorney FROM Patients  Where rtrim(Attorney)<>'' Order by Attorney").Result
            ''Do Until Reader.Read = False
            ''    gAutocompleteAttorneys.Add(Reader("Attorney").ToString.Trim)
            ''Loop
            'TextBoxAttorney.AutoCompleteCustomSource = gAutocompleteAttorneys
            'Reader.Close()
            'Reader.Dispose()
            Load_Patient_Attorneys()

            cboInjury.Items.Clear()
            Reader = gSQLGetDataReaderAsync("Select ID, Description from Symptoms").Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboInjury.Items.Add(New ValueDescription(CLng(Val(Reader("ID").ToString)),
                                                         Reader("Description").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()

            cboBillingCompany.Items.Clear()
            Reader =
                gSQLGetDataReaderAsync("SELECT     BillingCompanyID, CompanyName FROM BillingCompanies ORDER BY CompanyName").Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboBillingCompany.Items.Add(New ValueDescription(CLng(Val(Reader("BillingCompanyID").ToString)),
                                                                 Reader("CompanyName").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Load_Patient_Attorneys()
        Dim Reader As SqlClient.SqlDataReader
        Try
            cboPatientAttorney.Items.Clear()
            Reader = gSQLGetDataReader("SELECT CompanyName FROM InsuranceCompanies WHERE (CaseTypeID = 5) ORDER BY CompanyName")
            Do Until Reader.Read = False
                cboPatientAttorney.Items.Add(Reader("CompanyName").ToString.Trim)
            Loop
            Reader.Close()
            Reader.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)

        End Try

    End Sub

    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewPatients.ColumnClick

        Dim new_sorting_column As ColumnHeader = ListViewPatients.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumn.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumn.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumn.Text =             m_SortingColumn.Text.Mid(2)
            m_SortingColumn.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumn.Text = "> " & m_SortingColumn.Text
        'Else
        'm_SortingColumn.Text = "< " & m_SortingColumn.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.ImageKey = "SORT1"
        Else
            m_SortingColumn.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewPatients.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewPatients.Sort()
    End Sub

    Private ErrorsCleared

    Public Sub Load_Patients()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        Dim PName() As String
        ListViewPatients.BeginUpdate()
        ListViewPatients.Items.Clear()
        If _
            TextBoxSearch.Text.Trim = "" Or ComboBoxSearchCaseStatus.SelectedItem Is Nothing Or
            ComboBoxSearchCaseType.SelectedItem Is Nothing Then
            Clear_Controls()
            Validate_Billing_Data(True)
            ListViewPatients.EndUpdate()
            Exit Sub
        End If
        SQL =
            " Select Suffix, PatientID, FName,LName, MI, CaseStatusID, NoMoreAppointmentsInd  from Patients  WHERE Patients.OfficeID = " &
            gOfficeID & " "
        If TextBoxSearch.Text.Trim <> "" Then
            If IsNumeric(TextBoxSearch.Text) Then
                SQL &= " AND Patients.PatientID = " & Val(TextBoxSearch.Text.Trim) & " "
            Else
                PName = Split(TextBoxSearch.Text.Trim.ToSafeSQLString(), " ")
                Select Case PName.Length
                    Case 1
                        If PName(0).Trim = "*" Then PName(0) = ""
                        SQL &= " and (Patients.FName Like '" & PName(0).Trim & "%' or Patients.LName Like '" & PName(0) &
                               "%') "
                    Case 2
                        SQL &= " and ("
                        SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.LName Like '" &
                               PName(1).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.LName Like '" &
                               PName(0).Trim & "%')"
                        SQL &= " )"
                    Case 3
                        SQL &= " and ("
                        SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" & PName(1).Trim &
                               "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" &
                               PName(2).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" &
                               PName(0).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" &
                               PName(1).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" &
                               PName(0).Trim & "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" &
                               PName(2).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "

                        SQL &= " )"
                End Select
            End If
        End If
        If CType(ComboBoxSearchCaseStatus.SelectedItem, ValueDescription).Value > 0 Then
            SQL &= " AND CaseStatusID=" & CType(ComboBoxSearchCaseStatus.SelectedItem, ValueDescription).Value
        End If

        If CType(ComboBoxSearchCaseType.SelectedItem, ValueDescription).Value > 0 Then
            SQL &= " AND CaseTypeID=" & CType(ComboBoxSearchCaseType.SelectedItem, ValueDescription).Value
        End If

        SQL &= " Order by FName, LName"
        Reader = gSQLGetDataReaderAsync(SQL).Result

        If Reader Is Nothing Then ListViewPatients.EndUpdate() : Exit Sub
        ListViewPatients.ListViewItemSorter = Nothing
        Dim Lst As List(Of ListViewItem) = New List(Of ListViewItem)
        If Reader.HasRows Then

            Do Until Reader.Read = False

                LI = New ListViewItem(Reader("PatientID").ToString, CInt(Val(Reader("CaseStatusID").ToString) - 1))
                If Reader("Suffix").ToString <> "" Then
                    LI.SubItems.Add(
                        Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString & " " &
                        Reader("Suffix").ToString)
                Else
                    LI.SubItems.Add(
                        Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString)
                End If
                LI.ToolTipText = Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString &
                                 " " & Reader("Suffix").ToString
                LI.Tag = "" & Reader("PatientID").ToString
                If Val(Reader("NoMoreAppointmentsInd").ToString) <> 0 Then
                    LI.ForeColor = Color.Red
                Else
                    LI.ForeColor = Color.Black
                End If
                Lst.Add(LI)
            Loop
        End If
        ListViewPatients.Items.AddRange(Lst.ToArray)
        ListViewPatients.EndUpdate()
        Reader.Close()
        Reader.Dispose()
        If ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
            cmdEdit.Enabled = True
            cmdDelete.Enabled = True
        Else
            Clear_Controls()
            cmdEdit.Enabled = False
            cmdDelete.Enabled = False
        End If
        Cursor = Cursors.Default
        'ListView1_SelectedIndexChanged(Nothing, Nothing)
        'Catch ex As Exception
        '
        'gProcess_Log(ex.Message, ex.StackTrace, True)
        'End Try
    End Sub

    Private Sub Clear_Controls()
        gLoop_Clear_Controls(Me, TextBoxSearch, ComboBoxSearchCaseStatus, ComboBoxSearchCaseType, TextBoxWebURL)
        ToolStripButtonSaveAs.Visible = True
        ToolStripButton1.Visible = True
        ToolStripButtonEmail.Visible = True
        ToolStripButton3.Visible = True

        RichTextBox1.Visible = False

        TextBoxWebUid.Text = ""
        TextBoxWebPassword.Text = ""
        txtComments.Text = ""
        txtCommentsNew.Text = ""
        CheckBoxNoMoreAppointmentsInd.Checked = False
        picPhoto.Image = Nothing
        picPhoto.Tag = ""
        TreeViewBills.Nodes.Clear()
        ListViewPayments.Items.Clear()
        ListViewBillComments.Items.Clear()
        ListViewPatientLog.Items.Clear()
        ListViewProcedures.Items.Clear()
        ListViewDocs.Items.Clear()
        ListViewComments.Items.Clear()
        ListViewReadings.Items.Clear()
        ListViewPatientsRelated.Items.Clear()
        ListViewCancelations.Items.Clear()
        ComboBoxInsuranceCompanyID.SelectedIndex = -1
        ComboBoxInsuranceCompanyID1.SelectedIndex = -1
        ComboBoxStateOfAccident.SelectedIndex = -1
        cboInjury.SelectedIndex = -1
        ListViewRequests.Items.Clear()
        ListViewActions.Items.Clear()
        lblFileSize.Text = ""
        cboSuffix.Text = ""
        cboSuffix.SelectedIndex = -1
        TextBoxReading.Text = ""
        TextBoxCommentView.Text = ""
        LabelDOB.ForeColor = Color.Black
        LabelDOB.Text = "DOB"
        LabelEffectiveDate.ForeColor = Color.Black
        LabelEffectiveDate.Text = "Effective DT"
        lblFileSize.Text = ""
        pdfViewer.Visible = True
        'Clear_Web_Document(pdfViewer)
        pdfViewer.CloseDocument()
        chkInitialReportReceived.Checked = False
        chkPoliceReportReceived.Tag = 0
        chkPoliceReportReceived.Checked = False
        CheckBoxInsuranceVerifyed.Checked = False
        CheckBoxInsurance1Verifyed.Checked = False
        LabelPreCertification.Visible = False
        ComboBoxReferringCompanyID.Tag = ""

    End Sub

    Private Sub ComboBoxCaseStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSearchCaseStatus.SelectedIndexChanged

        If SkipSearch Then Exit Sub
        Load_Patients()
        If ListViewPatients.Items.Count = 0 Then
            LabelFound.Text = ""
        Else
            LabelFound.Text = "Found: " & ListViewPatients.Items.Count
        End If
        TextBoxSearch.Focus()
    End Sub

    Private Sub TextBoxSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxSearch.KeyDown

        If e.KeyCode = 40 Then
            If ListViewPatients.Items.Count > 0 Then
                ListViewPatients.Focus()
            End If
        End If
    End Sub

    Private Sub TextBoxSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearch.KeyPress

    End Sub

    Private Sub TextBoxSearch_LostFocus(sender As Object, e As EventArgs) Handles TextBoxSearch.LostFocus

    End Sub

    Private Sub TextBoxSearch_MouseDown(sender As Object, e As MouseEventArgs) Handles TextBoxSearch.MouseDown

    End Sub

    'Public Sub TimerLoad_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TimerLoad.Tick
    '    TimerLoad.Enabled = False
    '    If ComboBoxSearchCaseStatus.Items.Count > 0 Then
    '        ComboBoxSearchCaseStatus.SelectedIndex = 1
    '    End If

    'End Sub

    Public Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged
        TimerDetails.Enabled = False
        TimerSearchPatients.Enabled = False
        TimerSearchPatients.Enabled = True
    End Sub

    Private Sub Clear_Color()
        Dim LI As ListViewItem
        ListViewPatients.BeginUpdate()
        For Each LI In ListViewPatients.Items
            If LI.Selected = False Then
                LI.BackColor = Color.White
            End If
        Next
        ListViewPatients.EndUpdate()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        TextBoxSearch.BackColor = Color.White
    End Sub

    Private Sub ListViewPatients_DoubleClick(sender As Object, e As EventArgs) Handles ListViewPatients.DoubleClick

        If ListViewPatients.SelectedItems.Count > 0 Then
            TimerDetails_Tick(Nothing, Nothing)
            cmdEdit_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListViewPatients_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListViewPatients.DrawItem

    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewPatients.KeyDown _

        'If e.KeyCode = 38 Then
        '    If ListViewPatients.SelectedIndices(0) = 0 Then
        '        TextBoxSearch.Focus()
        '        Exit Sub
        '    End If
        'End If
        If e.KeyCode = 40 Or e.KeyCode = 38 Then
            TimerDetails.Enabled = False
            KeyDn = True
        End If
    End Sub

    Private Sub ListView1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListViewPatients.KeyUp

        If e.KeyCode = 40 Or e.KeyCode = 38 Then
            KeyDn = False
            ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListViewPatients_MouseDown(sender As Object, e As MouseEventArgs) Handles ListViewPatients.MouseDown

        Dim HI As ListViewHitTestInfo
        Try

            imgWait1.Visible = False
            HI = ListViewPatients.HitTest(e.X, e.Y)
            If HI.Item Is Nothing Then
                ListViewPatients.ContextMenuStrip = Nothing
            Else
                If LoadingData = False Then
                    HI.Item.Selected = True
                End If
                HI.Item.EnsureVisible()
                ListViewPatients.ContextMenuStrip = ContextMenuStrip1
            End If
            'TimerDetails.Enabled = False
        Catch
        End Try
    End Sub

    Public Loading As Boolean
    Public LoadingData As Boolean

    Public Sub ListViewPatients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewPatients.SelectedIndexChanged
        'If LoadingData Then Exit Sub
        'LoadingData = True
        imgWait1.Visible = False
        gHighlightListviewItem(ListViewPatients, True, False)
        TimerDetails.Enabled = False
        'If txtPatientID.Text <> "" Then
        '    Clear_Controls()
        'End If
        If ListViewPatients.SelectedItems.Count = 0 And OpMode = AddEditMode.None Then
            Clear_Controls()
            Validate_Billing_Data(True)
            imgWait1.Visible = False
            LoadingData = False
            Exit Sub
        End If

        TimerDetails.Enabled = False
        If KeyDn = True Then Exit Sub
        TimerDetails.Enabled = True
        'LoadingData = False
    End Sub

    Public Sub Validate_Billing_Data(Optional Clear As Boolean = False)
        Dim Pnls As New Collection
        Dim Pnl As Panel
        ' AccessibleDescription property used to specify required fields.
        Pnls.Add(TabPage1)
        Pnls.Add(TabPage2)
        Pnls.Add(PanelInsurance)
        If ErrorsCleared And Clear Then Exit Sub
        ErrorsCleared = Clear
        'If TabControl1.TabPages.ContainsKey("TabPageWC") = True Then
        '    Pnls.Add(TabPageWCInfo)
        'End If
        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            For Each Pnl In Pnls
                For Each Obj As Object In Pnl.Controls
                    If _
                        TypeOf Obj Is ComboBox Or TypeOf Obj Is TextBox Or
                        TypeOf Obj Is MaskedTextBox Then
                        'If Clear = True Then
                        '    If ErrorProvider1.GetError(Obj).ToString <> "" Then ErrorProvider1.SetError(Obj, String.Empty)
                        'Else
                        If ErrorProvider1.GetError(Obj).ToString <> "" Then ErrorProvider1.SetError(Obj, String.Empty)
                        If Clear = False Then
                            If TypeOf Obj Is MaskedTextBox Then
                                If _
                                    Val(Obj.AccessibleDescription) > 0 And
                                    CType(Obj, MaskedTextBox).MaskCompleted = False Then
                                    If ErrorProvider1.GetError(Obj).ToString = "" Then _
                                        ErrorProvider1.SetError(Obj, "This field is required.")
                                End If
                            ElseIf TypeOf Obj Is ComboBox Then
                                If Val(Obj.AccessibleDescription) > 0 And Obj.selectedindex = -1 Then
                                    If ErrorProvider1.GetError(Obj).ToString = "" Then _
                                        ErrorProvider1.SetError(Obj, "This field is required.")

                                End If
                            Else
                                If Val(Obj.AccessibleDescription) > 0 And Obj.text.trim = "" Then
                                    If ErrorProvider1.GetError(Obj).ToString = "" Then _
                                        ErrorProvider1.SetError(Obj, "This field is required.")
                                End If
                            End If
                        End If
                    End If
                Next
            Next
        Else
            For Each Pnl In Pnls
                For Each Obj As Object In Pnl.Controls
                    If _
                        TypeOf Obj Is ComboBox Or TypeOf Obj Is TextBox Or
                        TypeOf Obj Is MaskedTextBox Then
                        'If Clear = True Then
                        '    ErrorProvider1.SetError(Obj, "")
                        'Else
                        If ErrorProvider1.GetError(Obj).ToString <> "" Then ErrorProvider1.SetError(Obj, String.Empty)
                        If Clear = False Then
                            If TypeOf Obj Is MaskedTextBox Then
                                If Val(Obj.AccessibleName) > 0 And CType(Obj, MaskedTextBox).MaskCompleted = False Then
                                    If ErrorProvider1.GetError(Obj).ToString = "" Then _
                                        ErrorProvider1.SetError(Obj, "This field is required.")
                                End If
                            ElseIf TypeOf Obj Is ComboBox Then
                                If Val(Obj.AccessibleName) > 0 And Obj.selectedindex = -1 Then
                                    If ErrorProvider1.GetError(Obj).ToString = "" Then _
                                        ErrorProvider1.SetError(Obj, "This field is required.")

                                End If
                            Else
                                If Val(Obj.AccessibleName) > 0 And Obj.text = "" Then
                                    If ErrorProvider1.GetError(Obj).ToString = "" Then _
                                        ErrorProvider1.SetError(Obj, "This field is required.")

                                End If
                            End If
                        End If
                    End If
                Next
            Next
        End If
        Return
    End Sub

    Private Sub Load_Requests()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        Dim dvcDt As String
        ListViewRequests.Items.Clear()
        If Not m_SortingColumnRequests Is Nothing Then m_SortingColumnRequests.ImageKey = "SORT0"
        m_SortingColumnRequests = _ListViewRequests.Columns(0)
        ListViewRequests.Columns(0).ImageKey = "SORT1"

        If ListViewPatients.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        SQL =
            "SELECT     BillingRequests.Priority, BillingRequests.CDProcedures, BillingRequests.RequestID, BillingRequests.BillID, BillingRequests.PatientID, "
        SQL &=
            "              BillingRequests.RequestDescription, BillingRequests.RequestFrom, BillingRequests.ResponsibleEmpID, BillingRequests.RequestDate, BillingRequests.RequestStatusID, "
        SQL &=
            "              BillingRequests.StatusDate, BillingRequestStatuses.Description AS Status, Employees.Fname +' '+ Employees.Lname as EmpName, Bills.ServiceFrom, Bills.ServiceTo "
        SQL &= " FROM         BillingRequests LEFT OUTER JOIN "
        SQL &=
            "              BillingRequestStatuses ON BillingRequests.RequestStatusID = BillingRequestStatuses.StatusID LEFT OUTER JOIN "
        SQL &= "              Employees ON BillingRequests.ResponsibleEmpID = Employees.EmpID "
        SQL &= "              LEFT OUTER JOIN Bills on BillingRequests.BillID = Bills.BillID "
        SQL &= " Where BillingRequests.PatientID = " & ListViewPatients.SelectedItems(0).Tag

        Reader = gSQLGetDataReaderAsync(SQL).Result
        If Reader Is Nothing Then Exit Sub
        ListViewRequests.ListViewItemSorter = Nothing
        Do Until Reader.Read = False
            LI = ListViewRequests.Items.Add(FormatDateTime(Reader("RequestDate").ToString, DateFormat.ShortDate))
            LI.Tag = Reader("RequestID").ToString
            LI.SubItems.Add(Reader("RequestDescription").ToString)
            LI.SubItems.Add(Reader("RequestFrom").ToString)
            LI.SubItems.Add(Reader("EmpName").ToString)
            LI.SubItems.Add(Choose(Val(Reader("Priority").ToString) + 1, "Normal", "Urgent"))
            LI.SubItems.Add(Reader("Status").ToString)
            LI.SubItems.Add(CDate(Reader("StatusDate").ToString).ToString("MM/dd/yyyy"))
            LI.SubItems.Add(Reader("CDProcedures").ToString)
            dvcDt = ""
            If Reader("ServiceFrom").ToString <> "" Then
                dvcDt = CDate(Reader("ServiceFrom").ToString).ToString("MM/dd/yyyy")
                If Reader("ServiceTo").ToString <> "" And Reader("ServiceFrom") <> Reader("ServiceTo") Then
                    dvcDt = dvcDt & " - " & CDate(Reader("ServiceTo").ToString).ToString("MM/dd/yyyy")
                End If
            End If
            LI.SubItems.Add(dvcDt)
        Loop
        If ListViewRequests.Items.Count > 0 Then
            ListViewRequests.Items(0).Selected = True
            ListViewRequests.Items(0).EnsureVisible()
            ListViewRequests_SelectedIndexChanged(Nothing, Nothing)
        End If
        gListViewRestoreDefaultColumnWidth(ListViewRequests)
    End Sub

    Private Sub ListViewRequests_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewRequests.SelectedIndexChanged

        Dim RequestID
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        ListViewActions.Items.Clear()

        If Not m_SortingColumnRequestsAction Is Nothing Then m_SortingColumnRequestsAction.ImageKey = "SORT0"
        m_SortingColumnRequestsAction = ListViewActions.Columns(0)
        ListViewActions.Columns(0).ImageKey = "SORT1"

        If ListViewRequests.SelectedItems.Count = 0 Then Exit Sub
        RequestID = Val(ListViewRequests.SelectedItems(0).Tag)
        If RequestID = 0 Then Exit Sub
        SQL =
            "SELECT Fname+' '+Fname as EmpName, RequestActionID, RequestID, Description, RequestActionDate FROM BillingRequestActions inner join Employees on BillingRequestActions.CreatedBy = Employees.EmpID where RequestID = " &
            RequestID

        Reader = gSQLGetDataReaderAsync(SQL).Result
        ListViewActions.Items.Clear()
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Do Until Reader.Read = False
                LI = ListViewActions.Items.Add(FormatDateTime(Reader("RequestActionDate").ToString, DateFormat.ShortDate))
                LI.Tag = Reader("RequestActionID").ToString
                LI.SubItems.Add(Reader("Description").ToString)
                LI.SubItems.Add(Reader("EmpName").ToString)
                LI.ToolTipText = Reader("Description").ToString
            Loop
        End If
        gListViewRestoreDefaultColumnWidth(ListViewActions)
        Reader.Close()
        Reader.Dispose()
    End Sub

    Private Sub Load_Cancelations()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        ListViewCancelations.Items.Clear()
        If Not m_SortingColumnCancelations Is Nothing Then m_SortingColumnCancelations.ImageKey = "SORT0"
        m_SortingColumnCancelations = ListViewCancelations.Columns(0)
        ListViewCancelations.Columns(0).ImageKey = "SORT1"

        If ListViewPatients.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        SQL =
            "SELECT   ReScheduleCancelInd, rank() OVER (ORDER BY ProcessedDate) as Num ,  ProcessedDate, Description AS ActionType, PatientReschedulesCancelations.Comments, Fname + ' ' + Lname AS EmpName "
        SQL &=
            " FROM PatientReschedulesCancelations INNER JOIN PatientReschedulesCancelationsTypes ON PatientReschedulesCancelations.ReScheduleCancelInd = PatientReschedulesCancelationsTypes.ID INNER JOIN Employees ON PatientReschedulesCancelations.ProcessedBy = Employees.EmpID "
        SQL &= " WHERE PatientReschedulesCancelations.PatientID = " & ListViewPatients.SelectedItems(0).Tag
        SQL &= " ORDER BY PatientReschedulesCancelations.ProcessedDate "
        Reader = gSQLGetDataReaderAsync(SQL).Result
        ListViewCancelations.ListViewItemSorter = Nothing
        ListViewCancelations.BeginUpdate()
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewCancelations.Items.Add(Reader("Num"))
            If Val(Reader("ReScheduleCancelInd").ToString) = 1 Then
                LI.ForeColor = Color.Brown
            Else
                LI.ForeColor = Color.Red
            End If
            LI.SubItems.Add(FormatDateTime(Reader("ProcessedDate").ToString, DateFormat.ShortDate))
            LI.SubItems.Add(Reader("ActionType").ToString)
            LI.SubItems.Add(Reader("Comments").ToString)
            LI.SubItems.Add(Reader("EmpName").ToString)

        Loop
        Reader.Close()
        Reader.Dispose()
        ListViewCancelations.EndUpdate()
        gListViewRestoreDefaultColumnWidth(ListViewCancelations)
    End Sub

    Public Sub Load_PatientProcedures()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim sLI As ListViewItem.ListViewSubItem
        Dim SQL As String
        Dim PreCertificationRequired As Boolean
        ListViewProcedures.Items.Clear()
        If ListViewPatients.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        SQL =
            "SELECT  PatientProcedures.PreCertificationDT, PatientProcedures.PACSAltNumber, PatientProcedures.Comments, PatientProcedures.DoNotBillInd, PatientProcedures.DoNotBillAction, Diagnostics.DiagID, ProcedureTypeID, Diagnostics.DiagName ,  PatientProcedures.DoNotBillInd, PatientProcedures.BillingProviderID, PatientProcedures.ReferringDoctor, Schedule.ScheduleDateTime, PatientProcedures.ProcID, Procedures.ProcName, PatientProcedures.PatientProcedureID, PatientProcedures.ProcedureStatusID,  PatientProcedureStatuses.Description AS StatusDescription, Employees.Fname + ' ' + Employees.Lname + ' ' + Employees.Alias AS TRName, EmployeesBP.Fname + ' ' + EmployeesBP.Lname +' '+ EmployeesBP.Alias AS BPName, PatientProcedures.TreatingProviderID "
        SQL = SQL &
              " FROM         PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN PatientProcedureStatuses ON PatientProcedures.ProcedureStatusID = PatientProcedureStatuses.ProcedureStatusID LEFT OUTER JOIN Employees ON PatientProcedures.TreatingProviderID = Employees.EmpID  LEFT OUTER JOIN Employees EmployeesBP ON PatientProcedures.BillingProviderID = EmployeesBP.EmpID  LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Diagnostics on PatientProcedures.DiagID = Diagnostics.DiagID "
        SQL = SQL & " Where PatientProcedures.PatientID = " & ListViewPatients.SelectedItems(0).Tag
        SQL = SQL & " ORDER BY PatientProcedures.PatientProcedureID "

        Reader = gSQLGetDataReaderAsync(SQL).Result
        If Reader Is Nothing Then Exit Sub
        ListViewProcedures.ListViewItemSorter = Nothing
        Do Until Reader.Read = False
            If IsDate(Reader("ScheduleDateTime").ToString) Then
                If _
                    CDate(Reader("ScheduleDateTime").ToString).Date < Now.Date And
                    Val(Reader("ProcedureStatusID").ToString) = 1 Then
                    LI =
                        ListViewProcedures.Items.Add(
                            CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yyyy hh:mm"), 4)
                Else
                    LI =
                        ListViewProcedures.Items.Add(
                            CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yyyy hh:mm"),
                            CInt(Val(Reader("ProcedureStatusID").ToString)))
                End If
            Else
                LI = ListViewProcedures.Items.Add("", 0)
            End If
            If _
                (Val(Reader("DoNotBillInd").ToString) = 1 And Val(Reader("DoNotBillAction").ToString) = 0) Or
                Val(Reader("ProcedureStatusID").ToString) = 3 Then
                LI.ImageIndex = 3
                LI.ToolTipText = "Do Not Bill / Canceled"
            Else
                LI.ToolTipText = Reader("StatusDescription").ToString
            End If
            LI.UseItemStyleForSubItems = False
            LI.Name = Reader("ProcedureTypeID").ToString
            LI.SubItems.Add(Reader("ProcName").ToString)
            LI.SubItems(0).Tag = Reader("PatientProcedureID").ToString
            LI.Tag = Reader("ProcID").ToString

            LI.SubItems.Add(Reader("TRName").ToString)
            LI.SubItems(2).Tag = Reader("TreatingProviderID").ToString
            LI.SubItems.Add(Reader("BPName").ToString).Tag = Val(Reader("BillingProviderID").ToString)
            LI.SubItems.Add(Reader("ReferringDoctor").ToString)
            LI.SubItems.Add(Reader("DiagName").ToString).Tag = Reader("DiagID").ToString
            If Val(Reader("ProcedureTypeID").ToString) = 3 Or Val(Reader("ProcedureTypeID").ToString) = 4 Then
                LI.ForeColor = Color.Blue
            End If
            LI.SubItems.Add(Replace(Reader("Comments").ToString, vbCrLf, ", "))
            LI.SubItems.Add(Replace(Reader("PACSAltNumber").ToString, vbCrLf, ", "))
            If gOfficeTypeID = 3 Then
                If IsDate(Reader("PreCertificationDT").ToString) Then
                    sLI = LI.SubItems.Add(CDate(Reader("PreCertificationDT").ToString).ToShortDateString)
                    If CDate(CDate(Reader("PreCertificationDT")).ToShortDateString()) < CDate(DateTime.Now.ToShortDateString) Then
                        sLI.BackColor = Color.LightPink
                    Else
                        sLI.BackColor = Color.LightGreen
                    End If
                Else
                    sLI = LI.SubItems.Add("")
                    sLI.BackColor = Color.LightPink
                    PreCertificationRequired = True
                End If
            End If
            If IsDate(Reader("ScheduleDateTime").ToString) Then
                If _
                    CDate(Reader("ScheduleDateTime").ToString).Date < Now.Date And
                    Val(Reader("ProcedureStatusID").ToString) = 1 Then
                    LI.ToolTipText = "No Show"
                End If
            End If

        Loop
        LabelPreCertification.Visible = PreCertificationRequired
        Reader.Close()
        Reader.Dispose()
        If ListViewProcedures.Items.Count > 0 Then
            ListViewProcedures.Items(0).Selected = True
            ListViewProcedures.Items(0).EnsureVisible()
            gListViewRestoreDefaultColumnWidth(ListViewProcedures)
        End If
    End Sub

    Private Sub Load_Readings()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SI As ListViewItem.ListViewSubItem
        Dim SQL As String
        ListViewReadings.Items.Clear()
        If ListViewPatients.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        If Not m_SortingColumnReadings Is Nothing Then m_SortingColumnReadings.ImageKey = "SORT0"
        m_SortingColumnReadings = ListViewReadings.Columns(0)
        'ListViewReadings.Columns(0).ImageKey = "SORT1"

        Cursor = Cursors.WaitCursor
        SQL =
            "SELECT  PatientProcedures.DictationDate, Procedures.ProcName, Schedule.ScheduleDateTime, Employees.EmpID, Employees.Fname + ' ' + Employees.Lname AS Doctor, PatientProcedureReadings.ResultDescription, PatientProcedureReadings.ResultDescription2, PatientProcedureReadings.ReadingDate, PatientProcedureReadings.PatientID, PatientProcedures.PatientProcedureID,  PatientProcedureReadings.ResultID, PatientProcedureReadings.EditInd "
        SQL &=
            " FROM         Procedures INNER JOIN PatientProcedures ON Procedures.ProcID = PatientProcedures.ProcID LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Employees ON PatientProcedures.TreatingProviderID = Employees.EmpID LEFT OUTER JOIN PatientProcedureReadings ON PatientProcedures.PatientProcedureID = PatientProcedureReadings.PatientProcedureID "
        SQL &=
            " WHERE (PatientProcedures.ProcedureStatusID = 2 or PatientProcedures.ProcedureStatusID = 3) and PatientProcedures.PatientID = " &
            ListViewPatients.SelectedItems(0).Tag
        SQL = SQL & " ORDER BY Schedule.ScheduleDateTime DESC"
        Reader = gSQLGetDataReaderAsync(SQL).Result
        If Reader Is Nothing Then Exit Sub
        ListViewReadings.ListViewItemSorter = Nothing
        Dim ImageNum
        Do Until Reader.Read = False
            If Val(Reader("EditInd").ToString) = 1 Then
                ImageNum = 4
            Else
                ImageNum = 5
            End If
            If IsDate(Reader("ScheduleDateTime").ToString) Then
                LI = ListViewReadings.Items.Add(CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yyyy"),
                                                ImageNum)
            Else
                LI = ListViewReadings.Items.Add("", ImageNum)
            End If
            SI = LI.SubItems.Add(Reader("ProcName").ToString)
            SI.Tag = Reader("ResultDescription").ToString & vbCrLf & Reader("ResultDescription2").ToString

            SI = LI.SubItems.Add(Reader("Doctor").ToString)
            SI.Tag = Reader("EmpID").ToString

            If Reader("DictationDate").ToString <> "" Then
                LI.SubItems.Add(CDate(Reader("DictationDate").ToString).ToString("MM/dd/yyyy"))
            Else
                LI.SubItems.Add("")
            End If

            If Reader("ReadingDate").ToString <> "" Then
                LI.SubItems.Add(CDate(Reader("ReadingDate").ToString).ToString("MM/dd/yyyy"))
                LI.ForeColor = Color.Black
                gSetListItemForeColor(LI, Color.Black)
            Else
                LI.SubItems.Add("")
                LI.ForeColor = Color.Red
                gSetListItemForeColor(LI, Color.Red)
            End If

            LI.Tag = New ValueDescription(Reader("PatientProcedureID").ToString, "", "",
                                          Reader("ResultDescription").ToString, Reader("ResultDescription2").ToString,
                                          ListViewPatients.SelectedItems(0).Tag, Reader("ResultID").ToString)
        Loop
        Reader.Close()
        Reader.Dispose()
        If ListViewReadings.Items.Count > 0 Then
            ListViewReadings.Items(0).Selected = True
            ListViewReadings.Items(0).EnsureVisible()
            ListViewReadings_SelectedIndexChanged(Nothing, Nothing)
        End If
        gListViewRestoreDefaultColumnWidth(ListViewReadings)
        Cursor = Cursors.Default
    End Sub

    Private Sub Load_Comments()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        ListViewComments.Items.Clear()
        If ListViewPatients.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        If Not m_SortingColumnComments Is Nothing Then m_SortingColumnComments.ImageKey = "SORT0"
        m_SortingColumnComments = ListViewComments.Columns(0)
        'ListViewComments.Columns(0).ImageKey = "SORT1"

        Cursor = Cursors.WaitCursor
        SQL =
            "SELECT PatientComments.CommentsID, PatientComments.PatientID, PatientComments.Comment, PatientComments.InsertedDT,  Employees.Fname + ' ' + Employees.Lname AS InsertedByName "
        SQL = SQL & " FROM PatientComments INNER JOIN Employees ON PatientComments.InsertedBy = Employees.EmpID "
        SQL = SQL & " Where PatientComments.PatientID = " & ListViewPatients.SelectedItems(0).Tag
        SQL = SQL & " ORDER BY PatientComments.CommentsID DESC"
        Reader = gSQLGetDataReaderAsync(SQL).Result
        If Reader Is Nothing Then Exit Sub
        ListViewComments.ListViewItemSorter = Nothing
        Do Until Reader.Read = False
            If IsDate(Reader("InsertedDT").ToString) Then
                LI = ListViewComments.Items.Add(CDate(Reader("InsertedDT").ToString).ToString("MM/dd/yyyy hh:mm"))
            Else
                LI = ListViewComments.Items.Add("")
            End If
            LI.SubItems.Add(Reader("Comment").ToString)
            LI.SubItems.Add(Reader("InsertedByName").ToString)
            LI.Tag = Reader("CommentsID").ToString
        Loop
        Reader.Close()
        Reader.Dispose()
        If ListViewComments.Items.Count > 0 Then
            ListViewComments.Items(0).Selected = True
            ListViewComments.Items(0).EnsureVisible()
            ListViewComments_SelectedIndexChanged(Nothing, Nothing)
        End If
        gListViewRestoreDefaultColumnWidth(ListViewComments)
        Cursor = Cursors.Default
    End Sub

    Private Sub Enable_Controls(ByVal En As Boolean)
        gLoop_Enable_Controls(Me, En, TextBoxSearch)
        If En = False Then
            ToolStripButtonDeletePhoto.Enabled = False
        Else
            ToolStripButtonDeletePhoto.Enabled = (Not picPhoto.Image Is Nothing)
        End If
        TextBoxWebUid.ReadOnly = True
        TextBoxWebPassword.ReadOnly = True
        TextBoxWebURL.ReadOnly = True
        ButtonWebPassword.Enabled = True
        ToolStripButtonCapturePhoto.Enabled = En
        TextBoxSearch.Enabled = Not En
        ComboBoxSearchCaseStatus.Enabled = Not En
        ComboBoxSearchCaseType.Enabled = Not En
        ListViewPatients.Enabled = Not En
        cmdAddInsuranceAddress.Enabled = En
        BtnAddPatientAttorney.Enabled = En
        txtFieldsChanged.Enabled = True
        TextBoxCommentView.Enabled = True
        'ButtonAddComments.Enabled = True
        ButtonAddProcedure.Enabled = True
        LabelNotesLength.Visible = En
        'ButtonScannDocument.Enabled = En
        'ButtonScannInsuranceCard.Enabled = En
        'ButtonDeleteDocument.Enabled = En
        chkInitialReportReceived.Enabled = En
        chkPoliceReportReceived.Enabled = En
        'ButtonCheckAddress.Enabled = En
        If CheckBoxNoMoreAppointmentsInd.Checked = False Then
            ButtonDeleteProcedure.Enabled = En
            ButtonAddProcedure.Enabled = En
        Else
            ButtonDeleteProcedure.Enabled = False
            ButtonAddProcedure.Enabled = False
        End If
        If En Then
            If ListViewProcedures.SelectedItems.Count > 0 AndAlso ListViewProcedures.SelectedItems(0).ImageIndex = 2 _
                Then
                ButtonDeleteProcedure.Enabled = False
            Else
                ButtonDeleteProcedure.Enabled = True
            End If
        End If
        'If lblLocked.Visible And lblLocked.Visible = True And gCurrentEmployee.PositionID > 2 Then
        '    cmdAddNew.Enabled = False
        '    cmdUpdate.Enabled = False
        '    cmdCancel.Enabled = False
        '    cmdEdit.Enabled = False
        '    ButtonAddComments.Enabled = False
        '    ButtonAddProcedure.Enabled = False
        '    ButtonAddService.Enabled = False
        '    ButtonScannDocument.Enabled = False
        '    ButtonDeleteProcedure.Enabled = False
        '    ButtonDeleteService.Enabled = False

        'Else
        TextBoxReading.Enabled = True
        cmdAddNew.Enabled = Not En

        cmdUpdate.Enabled = En
        cmdCancel.Enabled = En
        ButtonScannDocument.Enabled = True
        If En = False Then
            If ListViewPatients.Items.Count > 0 Then
                cmdEdit.Enabled = True
                cmdDelete.Enabled = True
            Else
                cmdEdit.Enabled = False
                cmdDelete.Enabled = False
            End If
            cmdUnlockInsurance.Visible = False
        Else
            cmdEdit.Enabled = False
            cmdDelete.Enabled = False
        End If
        'End If
        PanelSecondaryInsurance.Enabled = False

        If En Then
            PanelSecondaryInsurance.Enabled = True
            If ComboBoxCaseTypeID.SelectedIndex > -1 Then
                Select Case CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value
                    Case 1 'NF
                        If OpMode = AddEditMode.AddNew Then _
                            gFindComboItemByValue(cboBillingCompany, gBillingNFDefaultBillingCompany, True)
                        cboBillingCompany.Enabled = gBillingNFDefaultBillingCompanyAllowChange
                    Case 2 'WC
                        If OpMode = AddEditMode.AddNew Then _
                            gFindComboItemByValue(cboBillingCompany, gBillingWCDefaultBillingCompany, True)
                        cboBillingCompany.Enabled = gBillingWCDefaultBillingCompanyAllowChange
                    Case 3 'PR
                        If OpMode = AddEditMode.AddNew Then _
                            gFindComboItemByValue(cboBillingCompany, gBillingPrivateDefaultBillingCompany, True)
                        cboBillingCompany.Enabled = gBillingPrivateDefaultBillingCompanyAllowChange
                        PanelSecondaryInsurance.Enabled = True
                    Case 4 'Cash
                        If OpMode = AddEditMode.AddNew And cboBillingCompany.Items.Count > 0 Then
                            cboBillingCompany.SelectedIndex = gFindComboItemByValue(cboBillingCompany, 1, True)
                        End If
                        cboBillingCompany.Enabled = False
                End Select
            Else
                cboBillingCompany.SelectedIndex = -1
                cboBillingCompany.Enabled = False
            End If
        Else
            cboBillingCompany.Enabled = False
        End If
        If cboBillingCompany.Enabled = False And cboBillingCompany.Items.Count > 0 And cboBillingCompany.SelectedIndex = -1 Then
            cboBillingCompany.SelectedIndex = 0
        End If
        txtPatientID.Enabled = True
        txtInsertedDT.Enabled = True
        'txtUpdatedDT.Enabled = True
        txtCaseStatusDT.Enabled = True
        ListViewProcedures.BackColor = CType(IIf(ButtonDeleteProcedure.Enabled, Color.White, Color.WhiteSmoke),
                                             Color)
        chkInitialReportReceived.Enabled = True
        chkPoliceReportReceived.Enabled = True
        ButtonAddProcedure.Enabled = True
        ButtonShowInsurance.Enabled = True
        ButtonShowInsurance1.Enabled = True
        txtComments.Enabled = True
        txtComments.ReadOnly = Not En
        txtComments.BackColor = CType(IIf(txtComments.ReadOnly, Color.WhiteSmoke, Color.White), Color)
        txtDummy.Enabled = True
        If En Then
            ComboBoxCaseStatusID_SelectedIndexChanged(Nothing, Nothing)
        Else
            ComboBoxCaseStatusID.Enabled = False
        End If
        'gLoop_Controls_Backcolor(Me, Color.White)
    End Sub

    Public Sub cmdAddNew_Click(sender As Object, e As EventArgs) Handles cmdAddNew.Click
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        Clear_Controls()
        ListViewDocs.Items.Clear()
        ComboBoxCaseTypeID.Focus()
        SaveCaseStatusID = 0
        SaveCasyTypeID = 0
        ComboBoxCaseStatusID.SelectedIndex = 0
        ComboBoxCaseStatusID.Enabled = gCurrentEmployee.PositionID < 3
        cboWCInsuranceCarrierAddressState.SelectedIndex = -1
        SavePatientInsCompanyID = -1
        SavePatientInsCompanyID1 = -1
        chkNF2.Enabled = True
        chkNF2.Checked = False
        txtNF2.Text = ""
        LabelNotesLength.Text = 4000 & " Chars Remaining"
        txtComments.Text = ""
        LabelNotesLength.Visible = True
        txtCommentsNew.Text = ""
        LabelPreCertification.Visible = False
        If ComboBoxTransportationCompanyID.Items.Count = 1 Then
            ComboBoxTransportationCompanyID.SelectedIndex = 0
        End If
        chkInitialReportReceived.ForeColor = Color.Red
        chkPoliceReportReceived.ForeColor = Color.Red
        chkInitialReportReceived.Checked = False
        chkPoliceReportReceived.Checked = False
        chkPoliceReportReceived.Tag = ""
        PanelInsurance.Enabled = True
        PanelSecondaryInsurance.Enabled = True
        txtComments.BackColor = Color.WhiteSmoke
        txtComments.ReadOnly = True
        txtCommentsNew.Enabled = True
        txtCommentsNew.ReadOnly = False
        txtCommentsNew.BackColor = Color.White
        txtCommentsNew.MaxLength = 4000
        If cboBillingCompany.Items.Count = 1 And cboBillingCompany.SelectedIndex = -1 Then
            cboBillingCompany.SelectedIndex = 0
        End If
        Validate_Billing_Data(True)
    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        Try
            OpMode = AddEditMode.Edit
            Enable_Controls(True)
            cmdUnlockInsurance.Visible = False
            txtDOA.Enabled = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value < 3 Or
                         CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5
            ComboBoxStateOfAccident.Enabled = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value < 3 Or
                                          CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5
            ComboBoxTransportationCompanyID.Enabled = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value < 3 Or
                                                  CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5
            cboPatientAttorney.Enabled = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value < 3 Or
                                  CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5
            'txtAdjuster.Enabled = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value < 3 Or CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5
            'txtAdjusterPhone.Enabled = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value < 3 Or CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5
            'txtAdjusterComments.Enabled = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value < 3 Or CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5
            PanelInsurance.Enabled = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value <> 5
            PanelSecondaryInsurance.Enabled = PanelInsurance.Enabled
            txtComments.BackColor = Color.WhiteSmoke
            txtComments.ReadOnly = True
            txtCommentsNew.Enabled = True
            txtCommentsNew.ReadOnly = False
            txtCommentsNew.BackColor = Color.White
            If 4000 - txtComments.Text.Length > 0 Then
                txtCommentsNew.MaxLength = 4000 - txtComments.Text.Length
                If txtCommentsNew.MaxLength = 0 Then
                    txtCommentsNew.Enabled = False
                End If
                LabelNotesLength.Text = 4000 - txtComments.Text.Length & " Chars Remaining"
            Else
                LabelNotesLength.Text = 0 & " Chars Remaining"
                txtCommentsNew.MaxLength = 0
            End If
            LabelNotesLength.Visible = True
            ComboBoxCaseTypeID.Enabled = gCurrentEmployee.PositionID < 3
            ComboBoxCaseStatusID.Enabled = gCurrentEmployee.PositionID < 3
            ComboBoxCaseTypeID.Focus()
            LockUnclockProfile(True, CLng(ListViewPatients.SelectedItems(0).Tag))
            If txtNF2.Text <> "" Then
                chkNF2.Enabled = True
            End If
            'If TreeViewBills.Nodes.Count > 0 Then
            If ComboBoxInsuranceCompanyID.SelectedIndex > -1 Then
                'If gCurrentEmployee.PositionID < 3 Or gCurrentEmployee.PositionID = 6 Then
                '    ComboBoxInsuranceCompanyID.Enabled = True
                '    ComboBoxClaimAddress.Enabled = True
                '    PanelInsurance.Enabled = True
                '    PanelSecondaryInsurance.Enabled = True
                '    cmdAddInsuranceAddress.Enabled = True
                'Else
                ComboBoxInsuranceCompanyID.Enabled = False
                ComboBoxClaimAddress.Enabled = False
                PanelInsurance.Enabled = False
                cmdAddInsuranceAddress.Enabled = False
                cmdUnlockInsurance.Visible = True
                cmdUnlockInsurance.BringToFront()
                'End If
            End If
            PanelSecondaryInsurance.Enabled = True
        Catch ex As Exception
            log.Error(ex)
        End Try
        'End If
    End Sub

    Public Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Cancel_Edit(True)
    End Sub

    Public Sub Cancel_Edit(Optional ByVal ShowWarning As Boolean = False)
        If ShowWarning Then
            If _
                MsgBox("You may have unsaved data. Discard Changes?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) =
                MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        OpMode = AddEditMode.None
        Enable_Controls(False)
        Clear_Controls()
        txtComments.BackColor = Color.WhiteSmoke
        txtComments.ReadOnly = True
        txtCommentsNew.Enabled = False
        txtCommentsNew.ReadOnly = True
        txtCommentsNew.BackColor = Color.WhiteSmoke
        txtCommentsNew.Text = ""
        gLoop_ResetErrors_Controls(ErrorProvider1, Me)
        ' Clean Not Saved Documents
        gSQLUpdateData("DELETE FROM Documents where PatientID=0 and InsertedBy=" & gCurrentEmployee.EmpID)
        gSQLUpdateData("DELETE FROM PatientComments where PatientID=0 and InsertedBy=" & gCurrentEmployee.EmpID)

        If InitialPatientName <> "" Then
            cmdUpdate.Enabled = False
            LockUnclockProfile(False)
            DialogResult = DialogResult.Cancel
            Close()
            Exit Sub
        End If

        If Not SaveSelectedItem Is Nothing Then
            ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
        Else
            If ListViewPatients.Items.Count > 0 Then
                ListViewPatients.Items(0).Selected = True
                ListViewPatients.Items(0).EnsureVisible()
                ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
            End If
        End If
        ToolStripButtonDeletePhoto.Enabled = False
        LockUnclockProfile(False)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        If cmdUpdate.Enabled Then
            If _
                MsgBox("You have unsaved data. Discard changes?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) =
                MsgBoxResult.No Then
                Exit Sub
            Else
                Cancel_Edit()
            End If
        End If
        Close()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim ID As Long = 0
        Dim FocusItem As ListViewItem = Nothing
        Dim ParentsRequiredInd As Integer = 0
        Dim ShiftWCTab As Integer = 1
        Dim SQL As String
        Dim ApprovedByName As String
        Dim RefOfficeChanged As Boolean
        Dim DAOApprovedBy As String
        Dim AddressApprovedBy As String
        Dim NF2ApprovedBy As String
        Dim PatientTypeApprovedBy As String
        'If TabControl1.TabPages.ContainsKey("TabPageWC") = True Then
        '    ShiftWCTab = 0
        'End If
        If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
            MsgBox("Unexpected Error. Please try again.", MsgBoxStyle.Critical)
            cmdCancel_Click(Nothing, Nothing)
            Exit Sub
        End If
        Try
            'OpMode = AddEditMode.AddNew
            'Alex
            gLoop_ResetErrors_Controls(ErrorProvider1, Me)
            gLoop_Trim_Controls(Me)
            gLoop_Text_PropperCase(Me, cboSuffix, txtCommentsNew, txtComments, TextBoxSearch)
            If ComboBoxCaseTypeID.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(ComboBoxCaseTypeID, "Unable to process update. The Case Type is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Case Type is required.", MsgBoxStyle.Exclamation)
                ComboBoxCaseTypeID.Focus()
                Exit Sub
            End If
            If _
                CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value < 3 Or
                CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5 Then
                If txtDOA.MaskCompleted = False Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(txtDOA, "Unable to process update. Missing/Invalid Patient's DOA.")
                    MsgBox("Unable to process update." & vbCrLf & "Missing/Invalid Patient's DOA.",
                           MsgBoxStyle.Exclamation)
                    txtDOA.Focus()
                    Exit Sub
                End If
                'If ComboBoxStateOfAccident.SelectedIndex = -1 Then
                'TabControl1.SelectedIndex = 0
                'ErrorProvider1.SetError(ComboBoxStateOfAccident, "Unable to process update. The State Of Accident should be specified.")
                'MsgBox("Unable to process update." & vbCrLf & "The State Of Accident should be specified.", MsgBoxStyle.Exclamation)
                'ComboBoxStateOfAccident.Focus()
                'Exit Sub
                If IsDate(txtDOA.Text) = False Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(txtDOA, "Unable to process update. Missing/Invalid Patient's DOA.")
                    MsgBox("Unable to process update." & vbCrLf & "Missing/Invalid Patient's DOA.",
                           MsgBoxStyle.Exclamation)
                    txtDOA.Focus()
                    Exit Sub
                End If
                If CDate(txtDOA.Text) > Now Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(txtDOA, "Unable to process update. Invalid Patient's DOA.")
                    MsgBox("Unable to process update." & vbCrLf & "Invalid Patient's DOA.", MsgBoxStyle.Exclamation)
                    txtDOA.Focus()
                    Exit Sub
                End If
            End If
            If CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 1 Then

                If CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 1 Then
                    If DateDiff(DateInterval.Month, CDate(txtDOA.Text), Now) > 12 Then
                        If gCurrentEmployee.PositionID > 3 And gCurrentEmployee.PositionID <> 6 Then
                            Dim frm As frmSupervisorApproval = New frmSupervisorApproval
                            frm.LabelMsg.Text = "The specified DOA is invalid or too old." & vbCrLf & "Please check the Police report."
                            If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                                frm.Dispose()
                                TabControl1.SelectedIndex = 0
                                ErrorProvider1.SetError(txtDOA,
                                                        "Unable to process update. The specified DOA is invalid or too old.")
                                txtDOA.Focus()
                                Exit Sub
                            End If
                            ApprovedByName = frm.SupervisorName
                            frm.Dispose()
                            frm = Nothing
                        Else
                            If _
                                MsgBox(
                                    "Warning!" & vbCrLf & "The specified DOA is invalid or too old!" & vbCrLf &
                                    "Please check the police report." & vbCrLf & "Do you want to continue?",
                                    MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                frmSupervisorApproval.Dispose()
                                TabControl1.SelectedIndex = 0
                                ErrorProvider1.SetError(txtDOA,
                                                        "Unable to process update. The specified DOA is invalid or too old")
                                txtDOA.Focus()
                                Exit Sub
                            End If
                            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
                        End If
                        DAOApprovedBy = ApprovedByName
                    End If
                    DAOApprovedBy = ApprovedByName
                End If
            End If

            If txtFName.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtFName, "Unable to process update. The Patient's First Name is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Patient's First Name is required.",
                       MsgBoxStyle.Exclamation)
                txtFName.Focus()
                Exit Sub
            End If
            If txtLName.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtLName, "Unable to process update. The Patient's Last Name is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Patient's Last Name is required.",
                       MsgBoxStyle.Exclamation)
                txtLName.Focus()
                Exit Sub
            End If
            If txtDOB.MaskCompleted = False Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtDOB, "Unable to process update. Missing/Invalid Patient's DOB.")
                MsgBox("Unable to process update." & vbCrLf & "Missing/Invalid Patient's DOB.", MsgBoxStyle.Exclamation)
                txtDOB.Focus()
                Exit Sub
            End If
            If IsDate(txtDOB.Text) = False Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtDOB, "Unable to process update. Missing/Invalid Patient's DOB.")
                MsgBox("Unable to process update." & vbCrLf & "Missing/Invalid Patient's DOB.", MsgBoxStyle.Exclamation)
                txtDOB.Focus()
                Exit Sub
            End If
            If gYearsFromDate(txtDOB.Text) > 100 Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtDOB, "Unable to process update. Invalid DOB specified.")
                MsgBox("Unable to process update." & vbCrLf & "Invalid DOB specified.", MsgBoxStyle.Exclamation)
                txtDOB.Focus()
                Exit Sub
            End If
            If gYearsFromDate(txtDOB.Text) < gMinAge Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtDOB,
                                        "Unable to process update. The patient is too young. Please refer to pediatrician")
                MsgBox("Unable to process update." & vbCrLf & "The patient is too yong.", MsgBoxStyle.Exclamation)
                txtDOB.Focus()
                Exit Sub
            End If
            If ComboBoxSex.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(ComboBoxSex, "Unable to process update. The Patient's Sex should be specified.")
                MsgBox("Unable to process update." & vbCrLf & "The Patient's Sex should be specified.",
                       MsgBoxStyle.Exclamation)
                ComboBoxSex.Focus()
                Exit Sub
            End If
            If txtAddress1.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtAddress1,
                                        "Unable to process update. The Patient's Address1 should be specified.")
                MsgBox("Unable to process update." & vbCrLf & "The Patient's Address1 should be specified.",
                       MsgBoxStyle.Exclamation)
                txtAddress1.Focus()
                Exit Sub
            End If
            If txtCity.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtCity, "Unable to process update. Invalid Patient's City should be specified.")
                MsgBox("Unable to process update." & vbCrLf & "Invalid Patient's City should be specified.",
                       MsgBoxStyle.Exclamation)
                txtCity.Focus()
                Exit Sub
            End If
            If ComboBoxState.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(ComboBoxState,
                                        "Unable to process update. The Patient's State should be specified.")
                MsgBox("Unable to process update." & vbCrLf & "The Patient's State should be specified.",
                       MsgBoxStyle.Exclamation)
                ComboBoxState.Focus()
                Exit Sub
            End If

            If gCheckAddress And gIsOnline() And 1 = 2 Then ' CheckAddress
                Dim Addr As Address
                Dim RetAddr As Address
                Dim MapAddress As String
                Addr.StreetAddress = txtAddress1.Text.Trim
                Addr.City = txtCity.Text.Trim
                Addr.State = ComboBoxState.Text.Trim
                Addr.Zip = txtZip.Text.Trim
                RetAddr = gVerifyAddress(Addr)
                Select Case RetAddr.AddressType
                    Case "OK"
                        If RetAddr.Adjusted Then
                            TabControl1.SelectedIndex = 0

                            'http://maps.googleapis.com/maps/api/staticmap?center=444+Neptune+Avenue,Brooklyn,NY+11224&zoom=17&size=400x400&maptype=roadmap&markers=444+Neptune+Avenue,Brooklyn, NY+11224&sensor=false
                            MapAddress = Replace(RetAddr.StreetAddress, " ", "+")
                            MapAddress &= "," & Replace(RetAddr.City, " ", "+")
                            MapAddress &= "+" & RetAddr.State
                            Dim frm As frmAddressDialog = New frmAddressDialog
                            frm.lblOriginal.Text = Addr.StreetAddress & ", " & Addr.City & ", " &
                                                                Addr.State & " " & Addr.Zip
                            frm.lblVerified.Text = RetAddr.StreetAddress & ", " & RetAddr.City & ", " &
                                                                RetAddr.State & " " & RetAddr.Zip

                            frm.ShowDialog(Me)
                            Dim RetResult As Integer = frm.RetResult
                            frm.Close()
                            frm.Dispose()
                            frm = Nothing
                            Select Case RetResult
                                Case 1
                                    txtAddress1.Text = RetAddr.StreetAddress
                                    txtCity.Text = RetAddr.City
                                    ComboBoxState.Text = RetAddr.State
                                    txtZip.Text = RetAddr.Zip
                                Case 2

                                Case Else
                                    txtAddress1.Focus()
                                    Exit Sub
                            End Select

                        End If
                    Case "ZERO_RESULTS", "NOMATCH"
                        If txtAddress1.Tag = "" Then
                            If _
                                MsgBox(
                                    "Unable to verify the Patient's address!" & vbCrLf & "Please check the address." &
                                    vbCrLf & vbCrLf & vbCrLf &
                                    "Do not include Appartment/Suite/Unit in the street address field." & vbCrLf &
                                    vbCrLf & vbCrLf & "Do you still want to use this address?",
                                    MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                TabControl1.SelectedIndex = 0
                                txtAddress1.Focus()
                                Exit Sub
                            Else
                                If gCurrentEmployee.PositionID > 3 Then
                                    Dim frm As frmSupervisorApproval = New frmSupervisorApproval
                                    frm.LabelMsg.Text = "Unable to verify the Patient's address!" &
                                                                          vbCrLf & vbCrLf &
                                                                          "Please confirm the specified address is correct?"
                                    If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                                        frm.Dispose()
                                        frm = Nothing
                                        TabControl1.SelectedIndex = 0
                                        txtAddress1.Focus()
                                        Exit Sub
                                    End If
                                    ApprovedByName = frm.SupervisorName
                                    frm.Dispose()
                                    frm = Nothing
                                Else
                                    ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
                                End If
                                AddressApprovedBy = ApprovedByName

                                txtAddress1.Tag = "WrongAddressAdminApproved"
                            End If
                        End If
                End Select
            End If

            If txtCellPhone.MaskCompleted = False And txtPhone1.MaskCompleted = False And
                txtPhone2.MaskCompleted = False Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtCellPhone,
                                        "Unable to process update. Missing/Invalid Patient's Cell Phone. At least one phone number should be specified.")
                MsgBox(
                    "Unable to process update." & vbCrLf &
                    "Missing/Invalid Patient's Phone. At least one phone number should be specified." & vbCrLf & vbCrLf &
                    "Cell phone number is required for SMS reminder notifications to be sent.",
                    MsgBoxStyle.Exclamation)
                txtCellPhone.Focus()
                Exit Sub
            End If
            If txtEmail.Text <> "" AndAlso gEmailCheck(txtEmail.Text) = False Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtEmail, "Unable to process update. Invalid Email address specified.")
                MsgBox("Unable to process update." & vbCrLf & "Invalid Email address specified.",
                       MsgBoxStyle.Exclamation)
                txtEmail.Focus()
                Exit Sub
            End If
            If ComboBoxTransportationCompanyID.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 2 - ShiftWCTab
                TabControl3.SelectedIndex = 0
                ErrorProvider1.SetError(ComboBoxTransportationCompanyID,
                                        "Unable to process update. The Transportation Company Should be selected.")
                MsgBox("Unable to process update." & vbCrLf & "The Transportation Company Should be selected.",
                       MsgBoxStyle.Exclamation)
                ComboBoxTransportationCompanyID.Enabled = True
                ComboBoxTransportationCompanyID.Focus()
                Exit Sub
            End If
            If cboBillingCompany.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 2 - ShiftWCTab
                TabControl3.SelectedIndex = 0
                ErrorProvider1.SetError(cboBillingCompany,
                                        "Unable to process update. The Billing Company Should be selected.")
                MsgBox("Unable to process update." & vbCrLf & "The Billing Company Should be selected.",
                       MsgBoxStyle.Exclamation)
                cboBillingCompany.Enabled = True
                cboBillingCompany.Focus()
                Exit Sub
            End If
            If ValidateInsuranceActive(ComboBoxInsuranceCompanyID, 3 - ShiftWCTab, 0) = False Then
                Return
            End If
            If ValidateInsuranceActive(ComboBoxInsuranceCompanyID1, 3 - ShiftWCTab, 1) = False Then
                Return
            End If
            If CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 1 Then

                If txtNF2.Text <> "" And chkNF2.Checked = False Then
                    If gCurrentEmployee.PositionID > 3 Then
                        Dim frm As frmSupervisorApproval = New frmSupervisorApproval
                        frm.LabelMsg.Text = "NF2 Report has not been submitted" & vbCrLf &
                                                              "Please confirm that NF2 Report has not been processed?"
                        If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                            frm.Dispose()
                            frm = Nothing
                            TabControl1.SelectedIndex = 2 - ShiftWCTab
                            chkNF2.Focus()
                            Exit Sub
                        End If
                        ApprovedByName = frm.SupervisorName
                        frm.Dispose()
                    Else
                        If _
                            MsgBox(
                                "Warning!" & vbCrLf & "You have removed check from the NF2 indicator." & vbCrLf &
                                "Please confirm that NF2 Report has not been processed?",
                                MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            frmSupervisorApproval.Dispose()
                            TabControl1.SelectedIndex = 2 - ShiftWCTab
                            chkNF2.Focus()
                            Exit Sub
                        End If
                        ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName

                    End If
                    NF2ApprovedBy = ApprovedByName
                End If

                If _
                CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value < 3 Or
                CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5 Then
                    If IsDate(txtClaimEffectiveDT.Text) And txtClaimEffectiveDT.Text <> "" Then
                        If gYearsFromDate(txtClaimEffectiveDT.Text) > 100 Then
                            TabControl1.SelectedIndex = 2 - ShiftWCTab
                            TabControl3.SelectedIndex = 0
                            ErrorProvider1.SetError(txtClaimEffectiveDT,
                                                "Unable to process update. Invalid Claim Effective Date.")
                            MsgBox("Unable to process update." & vbCrLf & "Invalid Claim Effective Date.",
                               MsgBoxStyle.Exclamation)
                            txtClaimEffectiveDT.Focus()
                            Exit Sub
                        End If
                        If CDate(txtClaimEffectiveDT.Text) > CDate(txtDOA.Text) Then
                            TabControl1.SelectedIndex = 2 - ShiftWCTab
                            TabControl3.SelectedIndex = 0
                            ErrorProvider1.SetError(txtClaimEffectiveDT,
                                                "Unable to process update. Invalid Claim Effective Date.")
                            MsgBox(
                            "Unable to process update." & vbCrLf & "Invalid Claim Effective Date." & vbCrLf &
                            "The Claim Effective Date should be less then DOA.", MsgBoxStyle.Exclamation)
                            LabelEffectiveDate.ForeColor = Color.Black
                            txtClaimEffectiveDT.Focus()
                            Exit Sub
                        End If
                        If CDate(txtClaimEffectiveDT.Text) = CDate(txtDOA.Text) Then
                            TabControl1.SelectedIndex = 2 - ShiftWCTab
                            TabControl3.SelectedIndex = 0
                            If _
                            MsgBox(
                                "Attention! The Claim Effective Date is the same as DOA!" & vbCrLf &
                                "The Claim Effective Date should be less then DOA." & vbCrLf &
                                "Do you want to continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) =
                            MsgBoxResult.No Then
                                ErrorProvider1.SetError(txtClaimEffectiveDT,
                                                    "Unable to process update. Invalid Claim Effective Date.")
                                LabelEffectiveDate.ForeColor = Color.Black
                                txtClaimEffectiveDT.Focus()
                                Exit Sub
                            End If
                            LabelEffectiveDate.ForeColor = Color.IndianRed
                        End If
                    End If
                End If
                If OpMode = AddEditMode.Edit Then
                    If _
                        CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5 And
                        cboPatientAttorney.Text.Trim.Length = 0 And SaveCasyTypeID <> 5 Then
                        TabControl1.SelectedIndex = 2 - ShiftWCTab
                        ErrorProvider1.SetError(cboPatientAttorney,
                                                "Unable to process update. The Patient's Attorney Information is missing or invalid!")
                        If gCurrentEmployee.PositionID > 3 Then
                            MsgBox(
                                "Unable to process update." & vbCrLf & "The case type changed to LEAN case!" & vbCrLf &
                                "The Patient's Attorney Information is missing or invalid!", MsgBoxStyle.Critical)
                        Else
                            Reader =
                                gSQLGetDataReaderAsync(
                                    "Select TOP 1 BillID from Bills where BillStatusID <> 8 and BillStatusID <> 3 and CaseTypeID = 1 and PatientID = " &
                                    CLng(SaveSelectedItem.Tag)).Result
                            If Not Reader Is Nothing Then
                                If Reader.HasRows Then
                                    Reader.Read()
                                    If _
                                        MsgBox(
                                            "Unable to process update." & vbCrLf & "The case type changed to LEAN case!" &
                                            vbCrLf & "The Patient's Attorney Information is missing or invalid!" &
                                            vbCrLf & vbCrLf & "Would you like to create request for the" & vbCrLf &
                                            "Pation's Attorney Information now?",
                                            MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                        Dim frm As frmBillingAddRequest = New frmBillingAddRequest
                                        frm.lblMsg.Text = "Patient: " & txtFName.Text & " " &
                                                                           txtLName.Text & "   Bill #: " &
                                                                           Reader("BillID").ToString
                                        frm.BillID = Reader("BillID").ToString
                                        frm.PatientID = CLng(SaveSelectedItem.Tag)
                                        frm.ShowDialog(Me)
                                        frm.Dispose()
                                        frm = Nothing
                                        MDIForm1Win8.TimerRefresh_Tick(Nothing, Nothing)
                                    End If
                                Else
                                    MsgBox(
                                        "Unable to process update." & vbCrLf & "The case type changed to LEAN case!" &
                                        vbCrLf & "The Patient's Attorney Information is required!", MsgBoxStyle.Critical)
                                End If
                            Else
                                MsgBox(
                                    "Unable to process update." & vbCrLf & "The case type changed to LEAN case!" &
                                    vbCrLf & "The Patient's Attorney Information is required!", MsgBoxStyle.Critical)
                            End If
                        End If
                        cboPatientAttorney.Focus()
                        Exit Sub
                    End If
                End If
                If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
                    If ComboBoxReferringCompanyID.SelectedIndex = -1 Then
                        TabControl1.SelectedIndex = 2 - ShiftWCTab
                        ErrorProvider1.SetError(ComboBoxReferringCompanyID,
                                                "Unable to process update. The Referring Company should be specified.")
                        MsgBox("Unable to process update." & vbCrLf & "The Referring Company should be specified.",
                               MsgBoxStyle.Exclamation)
                        ComboBoxReferringCompanyID.Focus()
                        Exit Sub
                    End If

                    If OpMode = AddEditMode.AddNew Then
                        If gSQLGetSingleValue("select ActiveInd from ReferringOffices where officeid = " & CType(ComboBoxReferringCompanyID.SelectedItem, ValueDescription).Value) = 0 Then
                            TabControl1.SelectedIndex = 2 - ShiftWCTab
                            ErrorProvider1.SetError(ComboBoxReferringCompanyID,
                                                "Unable to process update. The Referring Company you have selected is Not Active.")
                            MsgBox("Unable to process update." & vbCrLf & "The Referring Company you have selected is Not Active.", MsgBoxStyle.Exclamation)
                            ComboBoxReferringCompanyID.Focus()
                            Exit Sub
                        End If
                    End If

                    If IsNumeric(ComboBoxReferringCompanyID.Tag) = True And ListViewProcedures.Items.Count > 0 Then
                        If ComboBoxReferringCompanyID.Tag <> CType(ComboBoxReferringCompanyID.SelectedItem, ValueDescription).Value Then
                            RefOfficeChanged = True
                        End If
                    End If

                    If CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 1 Then
                        If validateInsurancePatientType() = False Then
                            If gCurrentEmployee.PositionID > 3 Then
                                Dim frm As frmSupervisorApproval = New frmSupervisorApproval
                                frm.LabelMsg.Text = "Patient type: " & ComboBoxPatientTypeID.Text &
                                                                      vbCrLf &
                                                                      "Cannot be accepted by insurance company: " &
                                                                      vbCrLf &
                                                                      ComboBoxInsuranceCompanyID.Text
                                If frm.ShowDialog <> DialogResult.OK Then
                                    frm.Dispose()
                                    frm = Nothing
                                    TabControl1.SelectedIndex = 2 - ShiftWCTab
                                    ComboBoxPatientTypeID.Focus()
                                    Exit Sub
                                End If
                                ApprovedByName = frm.SupervisorName
                                frm.Dispose()
                                frm = Nothing
                            Else
                                If MsgBox(
                                    "Patient type: " & ComboBoxPatientTypeID.Text & vbCrLf &
                                    "Cannot be accepted by the insurance company: " & vbCrLf &
                                    ComboBoxInsuranceCompanyID.Text & vbCrLf & vbCrLf & "Continue?",
                                    MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                    TabControl1.SelectedIndex = 2 - ShiftWCTab
                                    ComboBoxPatientTypeID.Focus()
                                    Exit Sub
                                End If
                                ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
                            End If
                            PatientTypeApprovedBy = ApprovedByName
                        End If

                    End If

                    If ComboBoxReferringDoctor.SelectedIndex = -1 Then
                        TabControl1.SelectedIndex = 2 - ShiftWCTab
                        ErrorProvider1.SetError(ComboBoxReferringDoctor,
                                                "Unable to process update. The Referring Doctor should be specified.")
                        MsgBox("Unable to process update." & vbCrLf & "The Referring Doctor should be specified.",
                               MsgBoxStyle.Exclamation)
                        ComboBoxReferringDoctor.Focus()
                        Exit Sub
                    End If
                End If

                If ComboBoxInsuranceCompanyID.SelectedIndex = -1 And ComboBoxInsuranceCompanyID1.SelectedIndex > 0 Then
                    TabControl1.SelectedIndex = 2 - ShiftWCTab
                    ErrorProvider1.SetError(ComboBoxInsuranceCompanyID1,
                                        "Unable to set Secondary insurance company when Primary insurance company is not set.")
                    MsgBox(
                    "Unable to process update." & vbCrLf &
                    "Unable to set Secondary insurance company when Primary insurance company is not set.",
                    MsgBoxStyle.Exclamation)
                    TabControl3.SelectedIndex = 1
                    ComboBoxInsuranceCompanyID1.Focus()
                    Exit Sub
                End If
            End If
            If Not ComboBoxInsuranceCompanyID.SelectedItem Is Nothing Then
                If _
                    CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Fld1 <> "" And
                    CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 1 Then
                    If _
                        MsgBox(
                            "Attention! Message From Manager..." & vbCrLf & vbCrLf &
                            CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Fld1 & vbCrLf & vbCrLf &
                            "Continue Update?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
                Select Case Val(CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Value1)
                    Case 0
                        If _
                            SaveCaseStatusID <> CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value And
                            CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value > 1 Then
                            If _
                                MsgBox(
                                    "The Patient's Case Status is set to " &
                                    CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Description & vbCrLf &
                                    "No More Appointments allowed." & vbCrLf &
                                    "All future scheduled appointments will be deleted!",
                                    MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                TabControl1.SelectedIndex = 0
                                ComboBoxCaseStatusID.Focus()
                                Exit Sub
                            End If
                            CheckBoxNoMoreAppointmentsInd.Checked = True
                        Else
                            If _
                                CheckBoxNoMoreAppointmentsInd.Checked And
                                CBool(CheckBoxNoMoreAppointmentsInd.Tag) = False Then
                                If _
                                    MsgBox(
                                        "Please confirm this patient has been set to Not More Appointments." & vbCrLf &
                                        "All future scheduled appointments will be deleted!",
                                        MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                    TabControl1.SelectedIndex = 0
                                    CheckBoxNoMoreAppointmentsInd.Focus()
                                    Exit Sub
                                End If
                            End If
                        End If
                    Case 1

                        If _
                            SaveCaseStatusID <> CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value And
                            CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value > 1 Then
                            If _
                                MsgBox(
                                    "The Patient's Case Status is set to " &
                                    CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Description & vbCrLf &
                                    "No More Appointments allowed." & vbCrLf &
                                    "All future scheduled appointments will be deleted!",
                                    MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                TabControl1.SelectedIndex = 0
                                ComboBoxCaseStatusID.Focus()
                                Exit Sub
                            End If
                        Else
                            MsgBox("The selected Insurance Company Acceptance level - Warning.", MsgBoxStyle.Exclamation)
                        End If
                    Case 2
                        MsgBox(
                            "The selected Insurance Company Acceptance level - Rejected." & vbCrLf &
                            "No More Appointments allowed." & vbCrLf &
                            "All future scheduled appointments will be deleted!" & vbCrLf &
                            "Please inform the administrator.", MsgBoxStyle.Exclamation)
                        CheckBoxNoMoreAppointmentsInd.Checked = True
                End Select
                'Val(CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Value)
            Else
                If _
                    SaveCaseStatusID <> CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value And
                    CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value > 1 Then
                    If _
                        MsgBox(
                            "The Patient's Case Status is set to " &
                            CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Description & vbCrLf &
                            "No More Appointments allowed." & vbCrLf &
                            "All future scheduled appointments will be deleted!",
                            MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        TabControl1.SelectedIndex = 0
                        ComboBoxCaseStatusID.Focus()
                        Exit Sub
                    End If
                    CheckBoxNoMoreAppointmentsInd.Checked = True
                Else
                    If CheckBoxNoMoreAppointmentsInd.Checked And CBool(CheckBoxNoMoreAppointmentsInd.Tag) = False Then
                        If _
                            MsgBox(
                                "Please confirm this patient has been set to Not More Appointments." & vbCrLf &
                                "All future scheduled appointments will be deleted!",
                                MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            TabControl1.SelectedIndex = 0
                            CheckBoxNoMoreAppointmentsInd.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            End If

            If Not ComboBoxInsuranceCompanyID1.SelectedItem Is Nothing Then
                If _
                    CType(ComboBoxInsuranceCompanyID1.SelectedItem, ValueDescription).Fld1 <> "" And
                    CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 1 Then
                    If _
                        MsgBox(
                            "Attention! Message From Manager..." & vbCrLf & vbCrLf &
                            CType(ComboBoxInsuranceCompanyID1.SelectedItem, ValueDescription).Fld1 & vbCrLf & vbCrLf &
                            "Continue Update?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If

            If _
                txtCommentsNew.Text.Trim = "" And txtComments.Text.Trim = "" And
                CheckBoxNoMoreAppointmentsInd.Checked = True Then
                If CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value > 1 Then
                    MsgBox(
                        "The pation's profile status is set to " &
                        CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Description & vbCrLf &
                        "Coments Required!", MsgBoxStyle.Exclamation)
                    TabControl1.SelectedIndex = 0
                    txtCommentsNew.Focus()
                    Exit Sub
                Else
                    MsgBox(
                        "The pation's profile is set to No More Appointments." & vbCrLf & vbCrLf & "Coments Required!",
                        MsgBoxStyle.Exclamation)
                    TabControl1.SelectedIndex = 0
                    txtCommentsNew.Focus()
                    Exit Sub
                End If
            End If
            If gYearsFromDate(txtDOB.Text) < gUnderAge Then
                ParentsRequiredInd = 1
            End If
            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
            End If
            If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
                If OpMode = AddEditMode.AddNew Then
                    Dim frm As frmPrescanAlert = New frmPrescanAlert
                    frm.CaseType = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value

                    If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                        frm.Dispose()
                        frm = Nothing
                        Exit Sub
                    End If
                    frm.Dispose()
                    frm = Nothing
                End If
            End If
            If OpMode = AddEditMode.Edit Then
                If _
                    CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 3 Or
                    CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 5 Then
                    If _
                        gSQLGetSingleValue(
                            "select count(*) from BillingRequests  Where PatientID=" & ID &
                            " and RequestStatusID<>3 and RequestStatusID<>4 ") > 0 Then
                        gSQLUpdateData(
                            "UPDATE BillingRequests Set RequestStatusID = 4 Where PatientID=" & ID &
                            " and RequestStatusID<>3 and RequestStatusID<>4")
                        gUpdate_Profile_Log(ID, PatientLogTypes.tRequestCanceledAll,
                                            "Case Closed. All Procedures Paid. All Requests Canceled")
                    End If
                End If
            End If
            Dim TA As New SqlClient.SqlDataAdapter("SELECT * FROM Patients Where PatientID = " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("Patients")

            TA.Fill(dTab)
            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
                TR("InsertedDT") = Now()
            Else
                TR = dTab.Rows(0)
            End If

            If SaveCaseStatusID <> CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value Then
                TR("CaseStatusDate") = CDate(Now).ToString("MM/dd/yyyy")
                gUpdate_Profile_Log(ID, PatientLogTypes.tStatusChange, SaveCaseStatusID,
                                    CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value)
            End If


            If OpMode = AddEditMode.Edit Then
                If CheckBoxNoMoreCollection.Tag <> IIf(CheckBoxNoMoreCollection.Checked, 1, 0) Then
                    If CheckBoxNoMoreCollection.Checked Then
                        Dim PatientID As Integer = ListViewPatients.SelectedItems(0).Tag
                        gSQLUpdateData("update Bills set NoMoreCollection =1 where PatientID = " & PatientID)
                        Dim lSQL As String = "INSERT INTO BillComments (BillID, Comment, InsertedBy, InsertedDT)
                            SELECT BillID, 'Bill marked as No More Collection due to a patient status change.', " & gCurrentEmployee.EmpID & ", getdate() FROM Bills
                            WHERE PatientID = " & PatientID
                        gSQLUpdateData(lSQL)
                    Else
                        Dim PatientID As Integer = ListViewPatients.SelectedItems(0).Tag
                        gSQLUpdateData("update Bills set NoMoreCollection = 0 where PatientID = " & PatientID)
                        Dim lSQL As String = "INSERT INTO BillComments (BillID, Comment, InsertedBy, InsertedDT)
                            SELECT BillID, 'Bill Reverted From No More Collection due to a patient status change.', " & gCurrentEmployee.EmpID & ", getdate() FROM Bills
                            WHERE PatientID = " & PatientID
                        gSQLUpdateData(lSQL)
                    End If
                End If
            End If


            If OpMode = AddEditMode.AddNew Then
                TR("WebPassword") = gSQLGetSingleValueString("select [dbo].GenPassword(6)")
            End If
            If Not IsDate(TR("CaseStatusDate")) Then
                TR("CaseStatusDate") = CDate(Now).ToString("MM/dd/yyyy")
            End If
            TR("CaseStatusID") = CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value
            TR("ParentsRequiredInd") = ParentsRequiredInd
            TR("FName") = txtFName.Text.Trim
            TR("MI") = txtMI.Text.Trim
            TR("LName") = txtLName.Text.Trim
            TR("Suffix") = cboSuffix.Text.Trim
            If txtDOB.MaskCompleted Then TR("DOB") = txtDOB.Text Else TR("DOB") = DBNull.Value
            TR("Sex") = ComboBoxSex.Text.Trim
            If txtSSN.MaskCompleted Then TR("SSN") = txtSSN.Text Else TR("SSN") = ""
            TR("Address1") = txtAddress1.Text.Trim
            TR("Address2") = txtAddress2.Text.Trim
            TR("City") = txtCity.Text.Trim
            TR("State") = ComboBoxState.Text.Trim
            TR("StateOfAccident") = ComboBoxStateOfAccident.Text.Trim
            TR("Injury") = cboInjury.Text.Trim
            If txtZip.MaskCompleted Then TR("Zip") = txtZip.Text Else TR("Zip") = ""
            If txtPhone1.MaskCompleted Then TR("Phone1") = txtPhone1.Text Else TR("Phone1") = ""
            If txtPhone2.MaskCompleted Then TR("Phone2") = txtPhone2.Text Else TR("Phone2") = ""
            If txtCellPhone.MaskCompleted Then TR("CellPhone") = txtCellPhone.Text Else TR("CellPhone") = ""
            TR("Email") = txtEmail.Text
            TR("Comments") = txtComments.Text &
                             IIf(txtCommentsNew.Text.Trim <> "", vbCrLf & txtCommentsNew.Text.Trim, "")
            TR("NoMoreAppointmentsInd") = IIf(CheckBoxNoMoreAppointmentsInd.Checked, 1, 0)
            'TR("InitialReportReceived") = IIf(chkInitialReportReceived.Checked, 1, 0)
            'TR("PoliceReportReceived") = IIf(chkPoliceReportReceived.Checked, 1, 0)
            'TR("AtWorkTime") = IIf(CheckBoxAtWorkTime.Checked, 1, 0)

            If Not ComboBoxMaritalStatusID.SelectedItem Is Nothing Then _
                TR("MaritalStatusID") = CType(ComboBoxMaritalStatusID.SelectedItem, ValueDescription).Value Else _
                TR("MaritalStatusID") = DBNull.Value
            If Not ComboBoxEmploymentStatusID.SelectedItem Is Nothing Then _
                TR("EmploymentStatusID") = CType(ComboBoxEmploymentStatusID.SelectedItem, ValueDescription).Value Else _
                TR("EmploymentStatusID") = DBNull.Value
            TR("Occupation") = txtOccupation.Text
            TR("EmployerName") = txtEmployerName.Text
            TR("EmployerAddress") = txtEmployerAddress.Text

            TR("EmployerAddressCity") = txtEmployerAddressCity.Text.Trim
            TR("EmployerAddressState") = cboEmployerAddressState.Text.Trim
            If txtEmployerAddressZip.MaskCompleted Then TR("EmployerAddressZip") = txtEmployerAddressZip.Text Else TR("EmployerAddressZip") = ""


            TR("PlaceOfAccident") = txtPlaceOfAccident.Text
            TR("VehicleOwner") = txtVehicleOwner.Text.Trim

            If txtTOA.MaskCompleted Then TR("TOA") = txtTOA.Text Else TR("TOA") = "00:00"

            If txtEmployerPhone.MaskCompleted Then TR("EmployerPhone") = txtEmployerPhone.Text Else _
                TR("EmployerPhone") = ""
            If txtDOA.MaskCompleted Then TR("DOA") = txtDOA.Text Else TR("DOA") = DBNull.Value

            If txtClaimEffectiveDT.MaskCompleted Then TR("ClaimEffectiveDT") = txtClaimEffectiveDT.Text Else _
                TR("ClaimEffectiveDT") = DBNull.Value
            TR("EmergencyInfo") = txtEmergencyInfo.Text.Trim
            TR("ClaimNumber") = txtClaimNumber.Text.ToUpper
            TR("ClaimNumber1") = txtClaimNumber1.Text.ToUpper

            If txtPolicyHolderSSN.MaskCompleted Then TR("PolicyHolderSSN") = txtPolicyHolderSSN.Text Else _
                TR("PolicyHolderSSN") = DBNull.Value
            If txtPolicyHolderSSN1.MaskCompleted Then TR("PolicyHolderSSN1") = txtPolicyHolderSSN.Text Else _
                TR("PolicyHolderSSN1") = DBNull.Value

            TR("PolicyHolderEmployerName") = txtPolicyHolderEmployerName.Text
            TR("PolicyHolderEmployerName1") = txtPolicyHolderEmployerName1.Text

            TR("PolicyHolderEmployerAddress") = txtPolicyHolderEmployerAddress.Text
            TR("PolicyHolderEmployerAddress1") = txtPolicyHolderEmployerAddress1.Text

            TR("PolicyHolderOccupation") = txtPolicyHolderOccupation.Text
            TR("PolicyHolderOccupation1") = txtPolicyHolderOccupation1.Text

            If txtPolicyHolderEmployerPhone.MaskCompleted Then _
                TR("PolicyHolderEmployerPhone") = txtPolicyHolderEmployerPhone.Text Else _
                TR("PolicyHolderEmployerPhone") = ""
            If txtPolicyHolderEmployerPhone1.MaskCompleted Then _
                TR("PolicyHolderEmployerPhone1") = txtPolicyHolderEmployerPhone1.Text Else _
                TR("PolicyHolderEmployerPhone1") = ""

            If txtPolicyHolderBirthDate.MaskCompleted Then TR("PolicyHolderBirthDate") = txtPolicyHolderBirthDate.Text _
                Else TR("PolicyHolderBirthDate") = DBNull.Value
            If txtPolicyHolderBirthDate1.MaskCompleted Then _
                TR("PolicyHolderBirthDate1") = txtPolicyHolderBirthDate1.Text Else _
                TR("PolicyHolderBirthDate") = DBNull.Value

            TR("PolicyHolderOtherDependents") = txtPolicyHolderOtherDependents.Text
            TR("PolicyHolderOtherDependents1") = txtPolicyHolderOtherDependents1.Text

            If Val(ComboBoxClaimAddress.Tag) = 0 Then ' Check to see if somebody removed claim address.
                If Not ComboBoxClaimAddress.SelectedItem Is Nothing Then _
                    TR("ClaimAddressID") = CType(ComboBoxClaimAddress.SelectedItem, ValueDescription).Value Else _
                    TR("ClaimAddressID") = DBNull.Value
            Else
                If Not ComboBoxClaimAddress.SelectedItem Is Nothing Then _
                    TR("ClaimAddressID") = CType(ComboBoxClaimAddress.SelectedItem, ValueDescription).Value Else _
                    TR("ClaimAddressID") = 0
            End If
            If Val(ComboBoxClaimAddress1.Tag) = 0 Then ' Check to see if somebody removed claim address.
                If Not ComboBoxClaimAddress1.SelectedItem Is Nothing Then _
                    TR("ClaimAddressID1") = CType(ComboBoxClaimAddress1.SelectedItem, ValueDescription).Value Else _
                    TR("ClaimAddressID1") = DBNull.Value
            Else
                If Not ComboBoxClaimAddress1.SelectedItem Is Nothing Then _
                    TR("ClaimAddressID1") = CType(ComboBoxClaimAddress1.SelectedItem, ValueDescription).Value Else _
                    TR("ClaimAddressID1") = 0
            End If

            TR("UpdatedDT") = Now
            TR("UpdatedByEmpID") = gCurrentEmployee.EmpID.ToString
            TR("Attorney") = cboPatientAttorney.Text

            If Not ComboBoxInjuryID.SelectedItem Is Nothing Then _
                TR("InjuryID") = CType(ComboBoxInjuryID.SelectedItem, ValueDescription).Value Else _
                TR("InjuryID") = DBNull.Value
            If Not ComboBoxPatientTypeID.SelectedItem Is Nothing Then _
                TR("PatientTypeID") = CType(ComboBoxPatientTypeID.SelectedItem, ValueDescription).Value Else _
                TR("PatientTypeID") = DBNull.Value
            If Not ComboBoxReferringCompanyID.SelectedItem Is Nothing Then _
                TR("ReferringCompanyID") = CType(ComboBoxReferringCompanyID.SelectedItem, ValueDescription).Value Else _
                TR("ReferringCompanyID") = DBNull.Value
            If Not ComboBoxReferringDoctor.SelectedItem Is Nothing Then
                TR("ReferringDoctor") = CType(ComboBoxReferringDoctor.SelectedItem, ValueDescription).Description
                TR("ReferringDoctorNPI") = CType(ComboBoxReferringDoctor.SelectedItem, ValueDescription).Value1
            Else
                TR("ReferringDoctor") = DBNull.Value
                TR("ReferringDoctorNPI") = DBNull.Value
            End If


            If Not ComboBoxTransportationCompanyID.SelectedItem Is Nothing Then _
                TR("TransportationCompanyID") =
                    CType(ComboBoxTransportationCompanyID.SelectedItem, ValueDescription).Value Else _
                TR("TransportationCompanyID") = DBNull.Value
            If Not ComboBoxPatientTypeID.SelectedItem Is Nothing Then _
                TR("PatientTypeID") = CType(ComboBoxPatientTypeID.SelectedItem, ValueDescription).Value Else _
                TR("PatientTypeID") = DBNull.Value

            If Not ComboBoxCaseTypeID.SelectedItem Is Nothing Then
                TR("CaseTypeID") = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value
            Else
                TR("CaseTypeID") = DBNull.Value
            End If
            If Not ComboBoxInsuranceCompanyID.SelectedItem Is Nothing Then _
                    TR("InsuranceCompanyID") = CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Value Else _
                    TR("InsuranceCompanyID") = DBNull.Value

            TR("PolicyNumber") = txtPolicyNumber.Text.ToUpper
            TR("PolicyHolderFName") = txtPolicyHolderFName.Text
            TR("PolicyHolderMI") = txtPolicyHolderMI.Text
            TR("PolicyHolderLName") = txtPolicyHolderLName.Text
            If Not ComboBoxRelationToInsuredID.SelectedItem Is Nothing Then _
                TR("RelationToInsuredID") = CType(ComboBoxRelationToInsuredID.SelectedItem, ValueDescription).Value Else _
                TR("RelationToInsuredID") = DBNull.Value
            TR("PolicyHolderAddress") = txtPolicyHolderAddress.Text
            TR("PolicyHolderCity") = txtPolicyHolderCity.Text
            TR("PolicyHolderState") = ComboBoxPolicyHolderState.Text
            If txtPolicyHolderZip.MaskCompleted Then TR("PolicyHolderZip") = txtPolicyHolderZip.Text Else _
                TR("PolicyHolderZip") = ""
            If txtPolicyHolderPhone.MaskCompleted Then TR("PolicyHolderPhone") = txtPolicyHolderPhone.Text Else _
                TR("PolicyHolderPhone") = ""
            TR("AdjusterName") = txtAdjuster.Text
            TR("AdjusterPhone") = txtAdjusterPhone.Text
            TR("AdjusterComments") = txtAdjusterComments.Text

            TR("AdjusterName1") = txtAdjuster1.Text
            TR("AdjusterPhone1") = txtAdjusterPhone1.Text
            TR("AdjusterComments1") = txtAdjusterComments1.Text

            If Not ComboBoxInsuranceCompanyID1.SelectedItem Is Nothing Then _
                TR("InsuranceCompanyID1") = CType(ComboBoxInsuranceCompanyID1.SelectedItem, ValueDescription).Value Else _
                TR("InsuranceCompanyID1") = DBNull.Value
            TR("PolicyNumber1") = txtPolicyNumber1.Text
            TR("PolicyHolderFName1") = txtPolicyHolderFName1.Text
            TR("PolicyHolderMI1") = txtPolicyHolderMI1.Text
            TR("PolicyHolderLName1") = txtPolicyHolderLName1.Text
            If Not ComboBoxRelationToInsuredID1.SelectedItem Is Nothing Then _
                TR("RelationToInsuredID1") = CType(ComboBoxRelationToInsuredID1.SelectedItem, ValueDescription).Value _
                Else TR("RelationToInsuredID1") = DBNull.Value
            TR("PolicyHolderAddress1") = txtPolicyHolderAddress1.Text
            TR("PolicyHolderCity1") = txtPolicyHolderCity1.Text
            TR("PolicyHolderState1") = ComboBoxPolicyHolderState1.Text
            If txtPolicyHolderZip1.MaskCompleted Then TR("PolicyHolderZip1") = txtPolicyHolderZip1.Text Else _
                TR("PolicyHolderZip1") = ""
            If txtPolicyHolderPhone1.MaskCompleted Then TR("PolicyHolderPhone1") = txtPolicyHolderPhone1.Text Else _
                TR("PolicyHolderPhone1") = ""
            TR("OfficeID") = gOfficeID
            TR("InsuranceVerifyed") = IIf(CheckBoxInsuranceVerifyed.Checked, 1, 0)
            TR("Insurance1Verifyed") = IIf(CheckBoxInsurance1Verifyed.Checked, 1, 0)
            TR("IDNumber") = txtIDNumber.Text.Trim
            TR("IDNumber1") = txtIDNumber1.Text.Trim
            If chkNF2.Checked = True Then
                If txtNF2.Text = "" Then
                    TR("NF2Date") = Now()
                End If
            Else
                TR("NF2Date") = DBNull.Value
            End If

            TR("WCCarrierCaseNumber") = txtWCCarrierCaseNumber.Text
            TR("WCCarrierCode") = txtWCCarrierCode.Text
            TR("WCCaseNumber") = txtWCCaseNumber.Text
            'TR("WCPatientAccountNumber") = txtWCPatientAccountNumber.Text
            TR("WCEmployerInsuranceCarrier") = txtWCEmployerInsuranceCarrier.Text
            TR("WCInsuranceCarrierAddress") = txtWCInsuranceCarrierAddress.Text
            TR("WCInsuranceCarrierAddressCity") = txtWCInsuranceCarrierAddressCity.Text
            TR("WCInsuranceCarrierAddressState") = cboWCInsuranceCarrierAddressState.Text
            TR("WCInsuranceCarrierAddressZip") = txtWCInsuranceCarrierAddressZip.Text

            If Not ComboBoxPatientTypeID.SelectedItem Is Nothing Then
                SavePatientTypeID = CType(ComboBoxPatientTypeID.SelectedItem, ValueDescription).Value
            Else
                SavePatientTypeID = 0
            End If
            If Not ComboBoxInsuranceCompanyID.SelectedItem Is Nothing Then
                SavePatientInsCompanyID = CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Value
            Else
                SavePatientInsCompanyID = 0
            End If
            If Not cboBillingCompany.SelectedItem Is Nothing Then _
                TR("BillingCompanyID") = CType(cboBillingCompany.SelectedItem, ValueDescription).Value Else _
                TR("BillingCompanyID") = DBNull.Value
            If OpMode = AddEditMode.AddNew Then
                dTab.Rows.Add(TR)
            End If
            TA.UpdateCommand = CB.GetUpdateCommand(True)
            Try
                TA.Update(dTab)
                dTab.AcceptChanges()
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
                Exit Sub
            End Try
            dTab.Dispose()
            CB.Dispose()
            TA.Dispose()

            If OpMode = AddEditMode.AddNew Then
                gUpdate_Profile_Log(ID, PatientLogTypes.tCreateNew)
                Reader =
                    gSQLGetDataReaderAsync("Select * from Patients Where PatientID = IDENT_CURRENT('Patients')").Result
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListViewPatients.Items.Add(Reader("PatientID").ToString,
                                                    CInt(Val(Reader("CaseStatusID").ToString) - 1))
                    LI.SubItems.Add(Reader("FName").ToString & " " & Reader("LName").ToString)
                    LI.ToolTipText = Reader("FName").ToString & " " & Reader("LName").ToString
                    LI.SubItems(1).Tag = "" & Reader("SSN").ToString
                    LI.Tag = "" & Reader("PatientID").ToString

                    If ListViewPatients.SelectedItems.Count > 0 Then ListViewPatients.SelectedItems(0).Selected = False
                    FocusItem = LI
                    ID = CLng(Val(Reader("PatientID").ToString))
                    If Val(Reader("NoMoreAppointmentsInd").ToString) <> 0 Then
                        LI.ForeColor = Color.Red
                    Else
                        LI.ForeColor = Color.Black
                    End If
                    SaveSelectedItem = LI
                Loop
                Reader.Close()
                Reader.Dispose()
            Else
                If CheckBoxNoMoreAppointmentsInd.Checked Then
                    gDeleteFutureAppointments(ID)
                End If
                gUpdate_Profile_Log(ID, PatientLogTypes.tUpdated)
                SaveSelectedItem.ImageIndex = CInt(CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value - 1)
                SaveSelectedItem.SubItems(1).Text = txtFName.Text & " " & txtLName.Text
                If txtSSN.MaskCompleted Then SaveSelectedItem.SubItems(1).Tag = txtSSN.Text Else _
                    SaveSelectedItem.SubItems(1).Tag = ""
                If CheckBoxNoMoreAppointmentsInd.Checked Then
                    SaveSelectedItem.ForeColor = Color.Red
                Else
                    SaveSelectedItem.ForeColor = Color.Black
                End If
                FocusItem = SaveSelectedItem
            End If

            Dim AccessType As PatientLogTypes
            If OpMode = AddEditMode.AddNew Then
                AccessType = PatientLogTypes.tCreateNew
            Else
                AccessType = PatientLogTypes.tUpdated
            End If

            If Trim(DAOApprovedBy) <> "" Then
                gUpdate_Profile_Log(ID, AccessType, "The specified DOA is invalid or too old", DAOApprovedBy)
            End If
            If Trim(AddressApprovedBy) <> "" Then
                gUpdate_Profile_Log(ID, AccessType, "Unable to verify the Patient's address", AddressApprovedBy)
            End If
            If Trim(NF2ApprovedBy) <> "" Then
                gUpdate_Profile_Log(ID, AccessType, "NF2 Report is set as not processed", NF2ApprovedBy)
            End If
            If Trim(PatientTypeApprovedBy) <> "" Then
                gUpdate_Profile_Log(ID, AccessType,
                                    "Patient type: " & ComboBoxPatientTypeID.Text &
                                    " accepted with the insurance company: " & ComboBoxInsuranceCompanyID.Text,
                                    PatientTypeApprovedBy)
            End If

            ''' Update WC   WCPatientAccountNumber

            gSQLUpdateData("Update Patients set WCPatientAccountNumber = PatientID where PatientID = " & Val(ID))
            txtWCPatientAccountNumber.Text = Val(ID)
            If txtAdjuster.Text.Trim.Length > 0 Then
                gSQLUpdateData(
                    "Update Bills set Adjuster = '" & txtAdjuster.Text.ToSafeSQLString() & "', AdjusterPhone = '" & txtAdjusterPhone.Text.ToSafeSQLString() & "' Where PatientID = " & Val(ID))
            End If

            If txtAdjuster.Text.Trim.Length > 0 Then
                gSQLUpdateData(
                    "Update Bills set Adjuster = '" & txtAdjuster.Text.ToSafeSQLString() & "', AdjusterPhone = '" & txtAdjusterPhone.Text.ToSafeSQLString() & "' Where PatientID = " & Val(ID))
            End If

            ''Update  Procedures

            If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then

                TA = New SqlClient.SqlDataAdapter("SELECT * FROM PatientProcedures Where 1=2", gConnectionString)
                CB = New SqlClient.SqlCommandBuilder(TA)
                CB.ConflictOption = ConflictOption.OverwriteChanges
                dTab = New DataTable("PatientProcedures")
                TA.Fill(dTab)
                Dim NewScheduleID As Long
                For Each LI In ListViewProcedures.Items
                    If Val(LI.SubItems(0).Tag) = 0 Then
                        TR = dTab.NewRow

                        TR("PatientID") = ID
                        TR("ReferringDoctorNPI") = LI.SubItems(3).Tag
                        If Not ComboBoxReferringCompanyID.SelectedItem Is Nothing Then
                            TR("ReferringOfficeID") = CType(ComboBoxReferringCompanyID.SelectedItem, ValueDescription).Value
                        Else
                            TR("ReferringOfficeID") = DBNull.Value
                        End If
                        TR("OfficeID") = gOfficeID
                        TR("ProcID") = LI.SubItems(1).Tag
                        TR("InsertedDT") = Now
                        Dim ScheduleDate As String
                        If LI.SubItems(6).Tag Is Nothing Then
                            ScheduleDate = ""
                        Else
                            ScheduleDate = LI.SubItems(6).Tag.ToString
                        End If

                        Dim ProcedureStatus As String = Val(LI.SubItems(7).Tag)

                        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
                            TR("ProcedureStatusID") = 0 ' Not Scheduled
                        Else
                            TR("ProcedureStatusID") = 2 ' Complete
                        End If
                        TR("BillingCompanyBillStatusID") = 1 ' New
                        TR("TreatingProviderID") = Val(LI.SubItems(2).Tag)
                        TR("BillingProviderID") = Val(LI.SubItems(3).Tag)
                        TR("DoNotBillInd") = 0




                        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
                            TR("DiagID") = LI.SubItems(5).Tag
                            TR("ReferringDoctor") = LI.SubItems(4).Text
                            If gOfficeTypeID = 3 AndAlso IsDate(LI.SubItems(8).Text) Then
                                TR("PreCertificationDT") = LI.SubItems(8).Text
                            End If
                            If IsDate(ScheduleDate) And String.IsNullOrEmpty(ScheduleDate) = False Then
                                SQL = " INSERT INTO Schedule (ScheduleDateTime, PickupTransportation, DestinationTransportation, PickupTransportationStatus, DestinationTransportationStatus, InsertedDT, UpdatedDT, UpdatedByEmpID, ToolTip) "
                                SQL &= " VALUES('" & CDate(ScheduleDate) & "', 0, 0, 0, 0, getdate(), getdate(), " & gCurrentEmployee.EmpID & ", '" & LI.SubItems(1).Text & "')"
                                gSQLUpdateData(SQL)
                                NewScheduleID = gSQLGetSingleValue("Select IDENT_CURRENT('Schedule')")
                                TR("ScheduleID") = NewScheduleID
                                TR("ProcedureStatusID") = ProcedureStatus
                            End If

                        Else
                            TR("DiagID") = LI.Tag
                            ' Create Schedule
                            SQL =
                                " INSERT INTO Schedule (ScheduleDateTime, PickupTransportation, DestinationTransportation, PickupTransportationStatus, DestinationTransportationStatus, InsertedDT, UpdatedDT, UpdatedByEmpID, ToolTip) "
                            SQL &= " VALUES('" & CDate(LI.SubItems(0).Text).ToString("MM/dd/yyyy") & " " &
                                   Now.ToString("HH:mm") & "', 0, 0, 0, 0, getdate(), getdate(), " &
                                   gCurrentEmployee.EmpID & ", '" & LI.SubItems(1).Text & "')"
                            gSQLUpdateData(SQL)
                            NewScheduleID = gSQLGetSingleValue("Select IDENT_CURRENT('Schedule')")
                            TR("ScheduleID") = NewScheduleID
                            TR("ReferringDoctor") = ""
                            TR("BillingProviderID") = Val(LI.SubItems(3).Tag)
                        End If
                        If Not ComboBoxCaseTypeID.SelectedItem Is Nothing Then
                            Select Case CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value
                                Case 1
                                    TR("BillingPrice") =
                                        gSQLGetSingleValue(
                                            "SELECT NFCost FROM Procedures WHERE ProcID = " & LI.SubItems(1).Tag)
                                Case 2
                                    TR("BillingPrice") =
                                        gSQLGetSingleValue(
                                            "SELECT WCCost FROM Procedures WHERE ProcID = " & LI.SubItems(1).Tag)
                                Case 3
                                    TR("BillingPrice") =
                                        gSQLGetSingleValue(
                                            "SELECT PRCost FROM Procedures WHERE ProcID = " & LI.SubItems(1).Tag)
                            End Select
                        End If
                        TR("BillingCompanyID") = CType(cboBillingCompany.SelectedItem, ValueDescription).Value
                        TR("UpdatedByEmpID") = gCurrentEmployee.EmpID.ToString
                        dTab.Rows.Add(TR)
                        If String.IsNullOrEmpty(LI.SubItems(4).Tag) = False Then
                            ' Insert Reading
                        End If
                    End If
                Next
                TA.UpdateCommand = CB.GetUpdateCommand(True)
                Try
                    TA.Update(dTab)
                    dTab.AcceptChanges()
                Catch ex As Exception
                    TopMost = False
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    log.Error(ex.Message, ex)
                    Exit Sub
                End Try
            End If

            If (RefOfficeChanged) Then
                MsgBox(
                    "Attention!" & vbCrLf & "Referring Company Changed!" & vbCrLf & vbCrLf &
                    "Please be advised that the Referring Doctor must be changed on all future appointments under 'Patient Procedures'",
                    MsgBoxStyle.Exclamation)
            End If
            '''''''    Update Services  - Commented because services updated at real time.

            'If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then

            '    'Update  Procedures

            '    For Each LI In ListViewServices.Items
            '        Dim NewServiceID As Long
            '        TA = New SqlClient.SqlDataAdapter("SELECT * FROM PatientServices Where PatientServiceID=" & Val(LI.SubItems(0).Tag), gConnectionString)
            '        CB = New SqlClient.SqlCommandBuilder(TA)
            '        dTab = New DataTable("PatientServices")
            '        TA.Fill(dTab)

            '        If Val(LI.SubItems(0).Tag) = 0 Then
            '            TR = dTab.NewRow
            '            TR("PatientID") = ID
            '            TR("DiagID") = LI.Tag
            '            TR("OfficeID") = gOfficeID
            '            TR("ProcID") = LI.SubItems(1).Tag
            '            TR("ProviderID") = LI.SubItems(2).Tag
            '            TR("InsertedDT") = Now.ToShortDateString
            '            TR("UpdatedByEmpID") = gCurrentEmployee.EmpID.ToString
            '            If IsDate(LI.SubItems(3).Text) Then
            '                TR("ScheduledDate") = LI.SubItems(3).Text
            '                gUpdate_Profile_Log(ID, PatientLogTypes.tServiceScheduled, LI.SubItems(1).Text & " " & LI.SubItems(3).Text)
            '            End If
            '            If IsDate(LI.SubItems(4).Text) Then
            '                TR("CompleteDate") = LI.SubItems(4).Text
            '                gUpdate_Profile_Log(ID, PatientLogTypes.tServiceComplete, LI.SubItems(1).Text & " " & LI.SubItems(4).Text)
            '            End If
            '            If IsDate(LI.SubItems(5).Text) Then
            '                TR("ResultsDate") = LI.SubItems(5).Text
            '                gUpdate_Profile_Log(ID, PatientLogTypes.tServiceResultReceived, LI.SubItems(1).Text & " " & LI.SubItems(5).Text)
            '            End If
            '            dTab.Rows.Add(TR)
            '            gUpdate_Profile_Log(ID, PatientLogTypes.tServiceAdded, LI.SubItems(1).Text)
            '        Else
            '            TR = dTab.Rows(0)
            '            If IsDate(LI.SubItems(3).Text) And LI.SubItems(3).ForeColor = Color.DarkOrange Then
            '                TR("ScheduledDate") = LI.SubItems(3).Text
            '                If IsDate(LI.SubItems(3).Tag) Then ' Update
            '                    gUpdate_Profile_Log(ID, PatientLogTypes.tServiceScheduleDateChanged, LI.SubItems(1).Text & " From " & LI.SubItems(3).Tag & " To " & LI.SubItems(3).Text)
            '                Else
            '                    gUpdate_Profile_Log(ID, PatientLogTypes.tServiceScheduled, LI.SubItems(1).Text & " " & LI.SubItems(3).Text)
            '                End If
            '            End If
            '            If IsDate(LI.SubItems(4).Text) And LI.SubItems(4).ForeColor = Color.DarkOrange Then
            '                TR("CompleteDate") = LI.SubItems(4).Text
            '                If IsDate(LI.SubItems(4).Tag) Then ' Update
            '                    gUpdate_Profile_Log(ID, PatientLogTypes.tServiceCompleteDateChanged, LI.SubItems(1).Text & " From " & LI.SubItems(4).Tag & " To " & LI.SubItems(4).Text)
            '                Else
            '                    gUpdate_Profile_Log(ID, PatientLogTypes.tServiceComplete, LI.SubItems(1).Text & " " & LI.SubItems(4).Text)
            '                End If
            '            End If
            '            If IsDate(LI.SubItems(5).Text) And LI.SubItems(5).ForeColor = Color.DarkOrange Then
            '                TR("ResultsDate") = LI.SubItems(5).Text
            '                If IsDate(LI.SubItems(5).Tag) Then ' Update
            '                    gUpdate_Profile_Log(ID, PatientLogTypes.tServiceResultReceivedDateChanged, LI.SubItems(1).Text & " From " & LI.SubItems(5).Tag & " To " & LI.SubItems(5).Text)
            '                Else
            '                    gUpdate_Profile_Log(ID, PatientLogTypes.tServiceResultReceived, LI.SubItems(1).Text & " " & LI.SubItems(5).Text)
            '                End If
            '            End If
            '        End If
            '        TA.UpdateCommand = CB.GetUpdateCommand(True)
            '        Try
            '            TA.Update(dTab)
            '            dTab.AcceptChanges()
            '        Catch ex As Exception
            '            gProcess_Log(ex.Message, ex.StackTrace, True)
            '            Exit Sub
            '        End Try
            '    Next
            'End If

            ''''''''''''''''''''''''''''''''

            dTab.Dispose()
            CB.Dispose()
            TA.Dispose()

            If SaveCaseStatusID <> CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value Then
                If _
                        CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 3 Or
                        CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 4 Then
                    gSQLUpdateData(
                            "UPDATE PatientProcedures set Comments = isnull(Comments,'') + ' " &
                            IIf(txtCommentsNew.Text.Trim <> "", vbCrLf & txtCommentsNew.Text.Trim.ToSafeSQLString(), "") &
                            "' Where PatientID = " & ID)
                End If
            End If

            For Each LI In ListViewDocs.Items
                If LI.SubItems(1).Tag = 0 Then
                    gUpdate_Profile_Log(ID, PatientLogTypes.tDocumentAdded, LI.Text)
                End If
            Next
            gSQLUpdateData(
                "UPDATE Documents set PatientID = " & ID & " where PatientID=0 and InsertedBy=" & gCurrentEmployee.EmpID)
            gSQLUpdateData(
                "UPDATE PatientComments set PatientID = " & ID & " where PatientID=0 and InsertedBy=" &
                gCurrentEmployee.EmpID)

            If CheckBoxNoMoreAppointmentsInd.Checked And CBool(CheckBoxNoMoreAppointmentsInd.Tag) = False Then
                gUpdate_Profile_Log(ID, PatientLogTypes.tNoMoreSchedules)
            ElseIf CheckBoxNoMoreAppointmentsInd.Checked = False And CBool(CheckBoxNoMoreAppointmentsInd.Tag) = True _
                Then
                gUpdate_Profile_Log(ID, PatientLogTypes.tNoMoreSchedulesRemoved)
            End If
            Enable_Controls(False)
            txtComments.BackColor = Color.WhiteSmoke
            txtComments.ReadOnly = True
            txtCommentsNew.Enabled = False
            txtCommentsNew.ReadOnly = True
            txtCommentsNew.BackColor = Color.WhiteSmoke

            If OpMode = AddEditMode.AddNew Then
                If gPrintPatientLabel = 0 Then
                    Print_Label(ID)
                ElseIf gPrintPatientLabel = 1 Then
                    If _
                        MsgBox("Print Patient's File Label?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) =
                        MsgBoxResult.Yes Then
                        Print_Label(ID)
                    End If
                End If
            End If

            Dim AddMode As Boolean
            AddMode = False
            If OpMode = AddEditMode.AddNew Then AddMode = True
            OpMode = AddEditMode.None
            gLoop_ResetErrors_Controls(ErrorProvider1, Me)
            If InitialEdit Then
                DialogResult = Windows.Forms.DialogResult.OK
                Exit Sub
            End If
            txtDOB.ForeColor = Color.Black
            LabelDOB.ForeColor = Color.Black
            LabelDOB.Text = "DOB"
            If AddMode Then
                If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
                    If CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 1 Then
                        If _
                            DateDiff(DateInterval.Day, CDate(txtDOA.Text), Now) >= Val(gDOAAge) Or
                            CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5 Then
                            MsgBox(
                                "Attention" & vbCrLf & "The DOA is more then " & Val(gDOAAge) & " days old!" & vbCrLf &
                                vbCrLf &
                                "All schedules should be verified with insurance company and Pre-approved by supervisor.",
                                MsgBoxStyle.Information)
                        End If
                    End If
                End If
                If gYearsFromDate(txtDOB.Text) < gUnderAge Then
                    TabControl1.SelectedIndex = 0
                    'ParentsRequiredInd = 1
                    txtDOB.ForeColor = Color.Red
                    LabelDOB.Text = "DOB Underage"
                    LabelDOB.ForeColor = Color.IndianRed
                    MsgBox(
                        "Attention Underage Patient!" & vbCrLf & vbCrLf & "The patient is " &
                        gYearsFromDate(txtDOB.Text) & " years old." & vbCrLf &
                        " The Parents'/Legal Guardian presence is required." & vbCrLf & vbCrLf &
                        "The 'Testing of a Minor' form must be signed.", MsgBoxStyle.Exclamation)
                End If
                If _
                    CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5 And
                    cboPatientAttorney.Text.Trim.Length = 0 Then
                    MsgBox(
                        "ATTENTION!" & vbCrLf & vbCrLf &
                        "This is a Lien Case! The Patient's Attorney Information is required!" & vbCrLf & vbCrLf &
                        "If the Patient's Attorney Information is not available at this time, please contact the Referring Office to obtain this information ASAP!",
                        MsgBoxStyle.Critical, "Attention")
                End If
            End If

            ''' Update Photo
            If LastLoadedTab(0) = ID Then
                Select Case Val(picPhoto.Tag)
                    Case 1 ' Add / Update
                        Dim ms As New IO.MemoryStream
                        picPhoto.Image.Save(ms, Imaging.ImageFormat.Png)
                        Dim arrImage() As Byte = ms.GetBuffer

                        TA =
                            New SqlClient.SqlDataAdapter(
                                "SELECT ID, PatientPhoto, PatientID FROM PatientPhotos Where PatientID=" & Val(ID),
                                gConnectionString)
                        CB = New SqlClient.SqlCommandBuilder(TA)
                        CB.ConflictOption = ConflictOption.OverwriteChanges
                        dTab = New DataTable("PatientPhotos")
                        TA.Fill(dTab)
                        If dTab.Rows.Count > 0 Then
                            TR = dTab.Rows(0)
                            TR("PatientPhoto") = arrImage
                        Else
                            TR = dTab.NewRow
                            TR("PatientID") = ID
                            TR("PatientPhoto") = arrImage
                            dTab.Rows.Add(TR)
                        End If
                        TA.UpdateCommand = CB.GetUpdateCommand(True)
                        Try
                            TA.Update(dTab)
                            dTab.AcceptChanges()
                        Catch ex As Exception
                            TopMost = False
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                            log.Error(ex.Message, ex)
                            Exit Sub
                        End Try

                        ms.Close()
                    Case 2 ' Delete
                        gSQLUpdateData("Delete From  PatientPhotos Where PatientID = " & Val(ID))
                End Select
            End If

            'Dim BillCount As Integer
            'If AddMode = False Then
            '    If gCurrentEmployee.PositionID < 3 Then
            '        If CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5 And SaveCasyTypeID <> 5 Then
            '            Reader = gSQLGetDataReaderAsync("Select BillID from Bills where BillStatusID <> 8 and BillStatusID <> 3 and CaseTypeID = 1 and PatientID = " & ID)
            '            If Not Reader Is Nothing Then
            '                If Reader.HasRows Then
            '                    Do Until Reader.Read = False
            '                        BillCount = BillCount + 1
            '                        ReProduce_Bill(Val(Reader("BillID").ToString), ID)
            '                    Loop
            '                    If BillCount = 1 Then
            '                        MsgBox("The case status has been changed from NoFault to Lean." & vbCrLf & vbCrLf & "One patient's bill has been recreated as Lean bill." & vbCrLf & " Please print and process created bill.")
            '                    Else
            '                        MsgBox("The case status has been changed from NoFault to Lean." & vbCrLf & vbCrLf & BillCount & " patient's bills has been recreated as Lean bills." & vbCrLf & " Please print and process these bills.")
            '                    End If

            '                End If
            '            End If
            '        End If
            '    End If
            'End If
            picPhoto.Tag = ""
            ToolStripButtonPreview.Enabled = (Not picPhoto.Image Is Nothing)
            ToolStripButtonPrintPhotoLabel.Enabled = (Not picPhoto.Image Is Nothing)

            txtCommentsNew.Text = ""
            FocusItem.Selected = True
            FocusItem.EnsureVisible()
            If FocusItem Is Nothing Then
                If ListViewPatients.SelectedItems.Count > 0 Then
                    ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
                End If
            End If
            If gYearsFromDate(txtDOB.Text) < gUnderAge Then
                TabControl1.SelectedIndex = 0
                'ParentsRequiredInd = 1
                txtDOB.ForeColor = Color.Red
                LabelDOB.Text = "DOB Underage"
                LabelDOB.ForeColor = Color.IndianRed
            End If
            Validate_Billing_Data(False)
            ' Update Adjuster Information in previously created bills.
            UpdateInd = True
        Catch ex As Exception

            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private WithEvents CheckPatient As CheckPatientExist
    Private PatientCheckInProgress As Boolean

    Private Sub txtFName_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtLName.LostFocus, txtFName.LostFocus

        If _
            txtFName.Text.Trim <> "" And txtLName.Text.Trim <> "" And OpMode = AddEditMode.AddNew And
            PatientCheckInProgress = False Then
            CheckPatient = New CheckPatientExist
            Dim T As New Threading.Thread(AddressOf CheckPatient.Check_Patient_Exist)
            CheckPatient.Fname = txtFName.Text.Trim
            CheckPatient.Lname = txtLName.Text.Trim
            PatientCheckInProgress = True
            T.Start()
        End If
    End Sub

    Private RetLV As ListView
    Public RetPatientName As String

    Sub CheckPatientEventHandler(ByVal LV As ListView) Handles CheckPatient.ThreadComplete
        RetLV = LV
        ShowDuplicatePatients()
    End Sub

    Private Sub ShowDuplicatePatients()
        If InvokeRequired Then
            Invoke(New MethodInvoker(AddressOf ShowDuplicatePatients))
        Else
            If Not RetLV Is Nothing Then
                Using frm As frmPatientExist = New frmPatientExist
                    With frm
                        .ListView1.Items.Clear()
                        For Each LI As ListViewItem In RetLV.Items
                            .ListView1.Items.Add(LI.Clone)
                        Next
                        .CalledForm = Me
                        .ListView1.Items(0).Selected = True
                        .ListView1.Items(0).EnsureVisible()
                        If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

                        End If
                        .Dispose()
                    End With
                End Using
            End If
            PatientCheckInProgress = False
        End If
    End Sub

    Private Sub txtFName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtFName.TextChanged

        ErrorProvider1.SetError(txtFName, "")
    End Sub

    Private Sub txtLName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtLName.TextChanged

        ErrorProvider1.SetError(txtLName, "")
    End Sub

    Private Sub txtDOB_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDOB.TextChanged
        ErrorProvider1.SetError(txtDOB, "")
    End Sub

    Private Sub ComboBoxSex_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxSex.SelectedIndexChanged

        ErrorProvider1.SetError(ComboBoxSex, "")
    End Sub

    Public Sub Load_Patient_Log()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        ListViewPatientLog.Items.Clear()
        If ListViewPatients.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        If Not m_SortingColumnLog Is Nothing Then m_SortingColumnLog.ImageKey = "SORT0"
        m_SortingColumnLog = ListViewPatientLog.Columns(0)
        ListViewPatientLog.Columns(0).ImageKey = "SORT1"

        Cursor = Cursors.WaitCursor
        SQL =
            "SELECT  ApprovedBy, PatientLog.Comments, PatientLog.AccessDT,   PatientLog.ParentLogTypeID, Employees.Fname+' '+Employees.Lname as AccessedByName, PatientLogTypes.Description AS AccessType "
        SQL = SQL &
              " FROM    PatientLog LEFT OUTER JOIN Employees ON PatientLog.AccessByUserID = Employees.EmpID LEFT OUTER JOIN PatientLogTypes ON PatientLog.ParentLogTypeID = PatientLogTypes.ParentLogTypeID "
        SQL = SQL & " WHERE PatientLog.PatientID = " & ListViewPatients.SelectedItems(0).Tag & ""
        SQL = SQL & " ORDER BY PatientLog.PatientsLogID DESC"
        Reader = gSQLGetDataReaderAsync(SQL).Result
        If Reader Is Nothing Then Exit Sub
        ListViewPatientLog.ListViewItemSorter = Nothing
        Do Until Reader.Read = False
            If IsDate(Reader("AccessDT").ToString) Then
                LI = ListViewPatientLog.Items.Add(CDate(Reader("AccessDT").ToString).ToString("MM/dd/yyyy hh:mm"), 0)
            Else
                LI = ListViewPatientLog.Items.Add("", 0)
            End If
            LI.SubItems.Add(Reader("AccessType").ToString)
            LI.SubItems.Add(Reader("AccessedByName").ToString)
            LI.SubItems.Add(Reader("ApprovedBy").ToString)
            LI.SubItems.Add(Reader("Comments").ToString)
            LI.Tag = Reader("Comments").ToString
        Loop
        Reader.Close()
        Reader.Dispose()
        gListViewRestoreDefaultColumnWidth(ListViewPatientLog)
        Cursor = Cursors.Default
    End Sub

    Private Sub ListViewPatientLog_ColumnClick(sender As Object,
                                               e As ColumnClickEventArgs) Handles ListViewPatientLog.ColumnClick

        Dim new_sorting_column As ColumnHeader = ListViewPatientLog.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As SortOrder
        If m_SortingColumnLog Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumnLog) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumnLog.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumnLog.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumnLog.Text =             m_SortingColumnLog.Text.Mid(2)
            m_SortingColumnLog.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumnLog = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumnLog.Text = "> " & m_SortingColumnLog.Text
        'Else
        'm_SortingColumnLog.Text = "< " & m_SortingColumnLog.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumnLog.ImageKey = "SORT1"
        Else
            m_SortingColumnLog.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewPatientLog.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewPatientLog.Sort()
    End Sub

    Private Sub ListViewPatientLog_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewPatientLog.SelectedIndexChanged
        Try
            gHighlightListviewItem(ListViewPatientLog, True, True)
            If ListViewPatientLog.SelectedItems.Count = 0 Then
                txtFieldsChanged.Text = ""
                Exit Sub
            End If
            txtFieldsChanged.Text = ListViewPatientLog.SelectedItems(0).Tag
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Private Sub ListViewComments_ColumnClick(sender As Object,
                                             e As ColumnClickEventArgs) Handles ListViewComments.ColumnClick

        Dim new_sorting_column As ColumnHeader = ListViewComments.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As SortOrder
        If m_SortingColumnComments Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumnComments) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumnComments.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumnComments.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumnComments.Text =             m_SortingColumnComments.Text.Mid(2)
            m_SortingColumnComments.ImageKey = "SORT0"
            m_SortingColumnComments.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumnComments = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumnComments.Text = "> " & m_SortingColumnComments.Text
        'Else
        'm_SortingColumnComments.Text = "< " & m_SortingColumnComments.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumnComments.ImageKey = "SORT1"
        Else
            m_SortingColumnComments.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewComments.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewPatients.Sort()
    End Sub

    Private Sub ListViewComments_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewComments.SelectedIndexChanged

        gHighlightListviewItem(ListViewComments, True, True)
        If ListViewComments.SelectedItems.Count = 0 Then Exit Sub
        TextBoxCommentView.Text = ListViewComments.SelectedItems(0).SubItems(1).Text
    End Sub

    Private Sub Load_Documents(Optional ByVal DoNotSelect As Boolean = False)
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String

        ListViewDocs.Items.Clear()
        If ListViewPatients.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        'SQL = "SELECT     DocumentID, PatientID, DocumentName, DocumentProfileID, InsertedDate FROM         Documents Where PatientID=" & ListViewPatients.SelectedItems(0).Tag & "Order by DocumentID"

        m_SortingColumnDocuments = ListViewDocs.Columns(0)
        If Not m_SortingColumnDocuments Is Nothing Then m_SortingColumnDocuments.ImageKey = "SORT0"
        ListViewDocs.Columns(0).ImageKey = "SORT0"
        ListViewDocs.Columns(1).ImageKey = "SORT0"

        SQL =
            "SELECT DocumentID, PatientID, DocumentName, DocumentProfileID, InsertedDate, Documents.PatientProcedureID, Employees.Fname + ' ' + Employees.Lname AS EmpName FROM " &
            " Documents LEFT OUTER JOIN Employees ON Documents.InsertedBy = Employees.EmpID " &
            " WHERE PatientID = " & ListViewPatients.SelectedItems(0).Tag &
            " And DocumentProfileID in (select ProfileID from DocumentProfileSecurityLevels where PositionID= " &
            gCurrentEmployee.PositionID & ") ORDER BY DocumentID"

        Reader = gSQLGetDataReaderAsync(SQL).Result
        ListViewDocs.ListViewItemSorter = Nothing
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewDocs.Items.Add(Reader("DocumentName").ToString)
            LI.SubItems.Add(CDate(Reader("InsertedDate").ToString).ToString("MM/dd/yyyy"))
            LI.SubItems.Add(Reader("EmpName").ToString)
            LI.Tag = Reader("DocumentID").ToString
            LI.SubItems(1).Tag = Val(Reader("DocumentProfileID").ToString)
        Loop
        ' POM's
        If _
            gSQLGetSingleValue(
                "Select count(*) from DocumentProfileSecurityLevels Where ProfileID=6 And PositionID=" &
                gCurrentEmployee.PositionID) > 0 Then
            SQL =
                "SELECT  DISTINCT  Bills.BillID, POM.CreatedDT, POM.POMID, Employees.Fname + ' ' + Employees.Lname AS EmpName " &
                " FROM            POM INNER JOIN Bills ON POM.POMID = Bills.POMID LEFT OUTER JOIN Employees ON POM.CreateBy = Employees.EmpID " &
                " WHERE (POMImage Is Not NULL) And Bills.PatientID = " &
                ListViewPatients.SelectedItems(0).Tag
            Reader = gSQLGetDataReaderAsync(SQL).Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                LI = ListViewDocs.Items.Add("Bill# " & Reader("BillID").ToString & " POM")
                LI.ForeColor = Color.Blue
                LI.SubItems.Add(CDate(Reader("CreatedDT").ToString).ToString("MM/dd/yyyy"))
                LI.SubItems.Add(Reader("EmpName").ToString())
                LI.Tag = Reader("POMID").ToString
                LI.SubItems(1).Tag = 6
                LI.SubItems.Add("")
            Loop
        End If
        ' CDPOM's
        If _
            gSQLGetSingleValue(
                "Select count(*) from DocumentProfileSecurityLevels Where ProfileID=18 And PositionID=" &
                gCurrentEmployee.PositionID) > 0 Then
            SQL =
                "SELECT  ImageDiskRequests.BillID, CDPOM.POMID, CDPOM.CreatedDT, CDPOM.CreateBy, CDPOM.RegisteredDT, CDPOM.RegisteredBy, CDPOM.POMImage, CDPOM.TS, Employees.Fname + ' ' + Employees.Lname AS EmpName " &
                " FROM            CDPOM INNER JOIN ImageDiskRequests ON CDPOM.POMID = ImageDiskRequests.POMID LEFT OUTER JOIN Employees ON CDPOM.CreateBy = Employees.EmpID " &
                " WHERE (POMImage Is Not NULL) And ImageDiskRequests.PatientID = " &
                ListViewPatients.SelectedItems(0).Tag
            Reader = gSQLGetDataReaderAsync(SQL).Result
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                LI = ListViewDocs.Items.Add("Bill# " & Reader("BillID").ToString & "CD POM")
                LI.ForeColor = Color.Blue
                LI.SubItems.Add(CDate(Reader("CreatedDT").ToString).ToString("MM/dd/yyyy"))
                LI.SubItems.Add(Reader("EmpName").ToString())
                LI.Tag = Reader("POMID").ToString
                LI.SubItems(1).Tag = 18
                LI.SubItems.Add("")
            Loop
        End If

        SQL = "Select ID, PatientID, Data, DocName, DocDate, Employees.Fname + ' ' + Employees.Lname AS EmpName  FROM PatientRTFDocuments  LEFT OUTER JOIN Employees ON PatientRTFDocuments.AddedBy = Employees.EmpID WHERE PatientID = " & ListViewPatients.SelectedItems(0).Tag & " order by id "

        Reader = gSQLGetDataReaderAsync(SQL).Result
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            Dim doc As RTFDocument = New RTFDocument()
            doc.ID = Val(Reader("ID").ToString)
            doc.PatientID = Reader("PatientID").ToString
            doc.DocName = Reader("DocName").ToString
            doc.Data = Reader("Data").ToString
            doc.DocDate = CDate(Reader("DocDate").ToString).ToString("MM/dd/yyyy")

            LI = ListViewDocs.Items.Add(doc.DocName)
            LI.SubItems.Add(doc.DocDate)
            LI.SubItems.Add(Reader("EmpName").ToString)
            LI.Tag = doc
            LI.ToolTipText = doc.DocName
            LI.SubItems(1).Tag = 999
            LI.SubItems.Add("")
        Loop

        ListViewDocs_ColumnClick(ListViewDocs, New ColumnClickEventArgs(0))
        If ListViewDocs.Items.Count > 0 And DoNotSelect = False Then
            On Error GoTo er
            ListViewDocs.Items(0).Selected = True
            ListViewDocs.Items(0).EnsureVisible()
            ListViewDocs_SelectedIndexChanged(Nothing, Nothing)

        End If
        gListViewRestoreDefaultColumnWidth(ListViewDocs)
er:
    End Sub

    Private Sub ComboBoxCaseTypeID_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles ComboBoxCaseTypeID.DrawItem

    End Sub

    Private Sub ComboBoxCaseTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxCaseTypeID.SelectedIndexChanged

        Try
            ErrorProvider1.SetError(ComboBoxCaseTypeID, "")
            Dim InsCompanyID As Integer = -1
            Dim InsCompanyID1 As Integer = -1
            If ComboBoxCaseTypeID.SelectedIndex = -1 Then Exit Sub
            If ComboBoxCaseTypeID.SelectedItem Is Nothing Then Exit Sub
            Dim CaseType As ValueDescription
            CaseType = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription)

            If OpMode = AddEditMode.Edit Then
                If SavePatientInsCompanyID > -1 And ComboBoxInsuranceCompanyID.SelectedItem Is Nothing Then
                    InsCompanyID = SavePatientInsCompanyID
                Else
                    If Not ComboBoxInsuranceCompanyID.SelectedItem Is Nothing Then
                        InsCompanyID = CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Value
                    Else
                        InsCompanyID = SavePatientInsCompanyID
                    End If
                End If
                If SavePatientInsCompanyID1 > -1 And ComboBoxInsuranceCompanyID1.SelectedItem Is Nothing Then
                    'InsCompanyID1 = SavePatientInsCompanyID1
                Else
                    If Not ComboBoxInsuranceCompanyID1.SelectedItem Is Nothing Then
                        InsCompanyID1 = CType(ComboBoxInsuranceCompanyID1.SelectedItem, ValueDescription).Value
                    Else
                        InsCompanyID1 = -1
                    End If
                End If
            End If
            ComboBoxInsuranceCompanyID.Text = ""
            ComboBoxInsuranceCompanyID1.Text = ""
            ComboBoxInsuranceCompanyID.Items.Clear()
            ComboBoxInsuranceCompanyID.DropDownHeight = 210
            ComboBoxInsuranceCompanyID1.Items.Clear()
            ComboBoxInsuranceCompanyID1.DropDownHeight = 210
            If ComboBoxCaseTypeID.SelectedIndex = -1 Then Exit Sub
            Dim Reader As SqlClient.SqlDataReader
            Cursor = Cursors.WaitCursor

            Select Case CaseType.Value
                Case 1 ' NF
                    Reader =
                    gSQLGetDataReaderAsync(
                        "Select CompanyID, CompanyName, AcceptanceID, Message from InsuranceCompanies Where CaseTypeID =1 ORDER BY CompanyName").Result
                Case 5 ' Lien
                    Reader =
                    gSQLGetDataReaderAsync(
                        "Select CompanyID, CompanyName, AcceptanceID, Message from InsuranceCompanies Where CaseTypeID =5 ORDER BY CompanyName").Result
                Case Else
                    Reader =
                    gSQLGetDataReaderAsync(
                        "Select CompanyID, CompanyName, AcceptanceID, Message from InsuranceCompanies Where CaseTypeID =" &
                        CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value.ToString &
                        " ORDER BY CompanyName").Result
            End Select
            If Reader Is Nothing Then GoTo ExitSub
            Do Until Reader.Read = False
                ComboBoxInsuranceCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)),
                                                                      Reader("CompanyName").ToString,
                                                                      Reader("AcceptanceID").ToString,
                                                                      Reader("Message").ToString))
                ComboBoxInsuranceCompanyID1.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)),
                                                                       Reader("CompanyName").ToString,
                                                                       Reader("AcceptanceID").ToString,
                                                                       Reader("Message").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()

            ' Add private insurance as secondary
            Reader =
            gSQLGetDataReaderAsync(
                "Select CompanyID, CompanyName, AcceptanceID, Message from InsuranceCompanies Where CaseTypeID =3 ORDER BY CompanyName").Result

            If Reader Is Nothing Then GoTo ExitSub
            Do Until Reader.Read = False
                ComboBoxInsuranceCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)),
                                                                      Reader("CompanyName").ToString,
                                                                      Reader("AcceptanceID").ToString,
                                                                      Reader("Message").ToString))
            Loop
            Reader.Close()
            Reader.Dispose()

            If OpMode = AddEditMode.Edit Then
                If CaseType.Value <> 4 Then
                    gFindComboItemByValue(ComboBoxInsuranceCompanyID, InsCompanyID, True)
                    gFindComboItemByValue(ComboBoxInsuranceCompanyID1, InsCompanyID1, True)
                    If SavePatientInsCompanyID > -1 And ComboBoxInsuranceCompanyID.SelectedItem Is Nothing Then
                        MsgBox("The Case Type Is changed. Do Not forget To Select a New insurance company.",
                           MsgBoxStyle.Information)
                    End If
                End If
            End If
            If OpMode <> AddEditMode.None Then
                txtDOA.Enabled = CaseType.Value < 3 Or CaseType.Value = 5
                ComboBoxStateOfAccident.Enabled = CaseType.Value < 3 Or CaseType.Value = 5
                ComboBoxTransportationCompanyID.Enabled = CaseType.Value < 3 Or CaseType.Value = 5
                cboPatientAttorney.Enabled = CaseType.Value < 3 Or CaseType.Value = 5
                'txtAdjuster.Enabled = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value < 3 Or CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5
                'txtAdjusterPhone.Enabled = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value < 3 Or CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5
                'txtAdjusterComments.Enabled = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value < 3 Or CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 5
            End If
            LabelInsuranceCompany.Text = "Insurance Company"
            Label27.Text = "Claim Address (If address Is Not On the list, please inform administrator)"
            PanelInsurance.Enabled = True
            PanelSecondaryInsurance.Enabled = gOfficeTypeID = 3
            Select Case CaseType.Value
                Case 1 'NF
                    'If TabControl1.TabPages.ContainsKey("TabPageWC") Then
                    '    TabControl1.TabPages.RemoveByKey("TabPageWC")
                    'End If
                    PanelWC.Visible = False
                    If OpMode <> AddEditMode.None Then _
                    gFindComboItemByValue(cboBillingCompany, gBillingNFDefaultBillingCompany, True)
                    cboBillingCompany.Enabled = gBillingNFDefaultBillingCompanyAllowChange
                Case 2 'WC
                    'If TabControl1.TabPages.ContainsKey("TabPageWC") = False Then
                    '    TabControl1.TabPages.Insert(1, TabPageWCInfo)
                    'End If
                    PanelWC.Visible = True
                    If OpMode <> AddEditMode.None Then
                        gFindComboItemByValue(cboBillingCompany, gBillingWCDefaultBillingCompany, True)
                        'gLoop_Enable_Controls(TabPageWCInfo, True, TextBoxSearch)
                    End If

                    cboBillingCompany.Enabled = gBillingWCDefaultBillingCompanyAllowChange

                Case 3 'PR
                    'If TabControl1.TabPages.ContainsKey("TabPageWCInfo") Then
                    '    TabControl1.TabPages.RemoveByKey("TabPageWCInfo")
                    'End If
                    PanelWC.Visible = False
                    If OpMode <> AddEditMode.None Then
                        gFindComboItemByValue(cboBillingCompany, gBillingPrivateDefaultBillingCompany, True)
                        cboBillingCompany.Enabled = gBillingPrivateDefaultBillingCompanyAllowChange
                        txtDOA.Enabled = False
                        ComboBoxStateOfAccident.Enabled = False
                        cboPatientAttorney.Enabled = True
                        txtAdjuster.Enabled = True
                        txtAdjusterPhone.Enabled = True
                        txtAdjusterComments.Enabled = True
                        txtDOA.Text = ""
                        ComboBoxStateOfAccident.SelectedIndex = -1
                    End If
                    cboPatientAttorney.Text = ""
                    cboPatientAttorney.SelectedIndex = -1
                    txtAdjuster.Text = ""
                    txtAdjusterPhone.Text = ""
                    txtAdjusterComments.Text = ""
                    txtAdjuster1.Text = ""
                    txtAdjusterPhone1.Text = ""

                    If OpMode <> AddEditMode.None Then
                        PanelSecondaryInsurance.Enabled = True
                    End If
                Case 4 'Cash
                    'If TabControl1.TabPages.ContainsKey("TabPageWCInfo") Then
                    '    TabControl1.TabPages.RemoveByKey("TabPageWCInfo")
                    'End If
                    PanelWC.Visible = False
                    If OpMode <> AddEditMode.None Then _
                    cboBillingCompany.SelectedIndex = gFindComboItemByValue(cboBillingCompany, 1, True)
                    cboBillingCompany.Enabled = False
                Case 5 ' Lien
                    LabelInsuranceCompany.Text = "Lien Attorney"
                    Label27.Text = "Lien Attorney Address"
                    PanelInsurance.Enabled = False
                    PanelSecondaryInsurance.Enabled = False
                    gLoop_Clear_Controls(PanelInsurance)
            End Select
            If ComboBoxInsuranceCompanyID.SelectedIndex > -1 Then
                ComboBoxInsuranceCompanyID.Enabled = False
                ComboBoxClaimAddress.Enabled = False
                PanelInsurance.Enabled = False
                cmdAddInsuranceAddress.Enabled = False
                cmdUnlockInsurance.Visible = True
                cmdUnlockInsurance.BringToFront()
            Else
                If OpMode <> AddEditMode.None Then
                    ComboBoxInsuranceCompanyID.Enabled = True
                    ComboBoxClaimAddress.Enabled = True
                    PanelInsurance.Enabled = True
                    cmdAddInsuranceAddress.Enabled = True

                End If
                cmdUnlockInsurance.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Oops")
            log.Error(ex.Message, ex)
        End Try
ExitSub:
        Cursor = Cursors.Default
    End Sub

    Private Sub ComboBoxReferringCompanyID_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ComboBoxReferringCompanyID.KeyUp

        If ComboBoxReferringCompanyID.SelectedIndex = -1 Then
            ComboBoxReferringDoctor.Items.Clear()
            ComboBoxReferringDoctor.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub ComboBoxReferringCompanyID_SelectedIndexChanged(ByVal sender As Object,
                                                                ByVal e As EventArgs) Handles ComboBoxReferringCompanyID.SelectedIndexChanged

        ErrorProvider1.SetError(ComboBoxReferringCompanyID, "")
        ComboBoxReferringDoctor.Items.Clear()
        ComboBoxReferringDoctor.Text = ""
        If ComboBoxReferringCompanyID.SelectedIndex = -1 Then Exit Sub
        Dim Reader As SqlClient.SqlDataReader
        Cursor = Cursors.WaitCursor
        Reader =
            gSQLGetDataReaderAsync(
                "Select * from ReferringOffices Where OfficeID =" &
                CType(ComboBoxReferringCompanyID.SelectedItem, ValueDescription).Value.ToString).Result

        If Reader Is Nothing Then GoTo ExitSub
        Do Until Reader.Read = False

            For d As Integer = 1 To gReferringOfficeDoctors
                If Reader("Doctor" + d.ToString()).ToString.Trim <> "" Then
                    ComboBoxReferringDoctor.Items.Add(New ValueDescription(0, Reader("Doctor" + d.ToString()).ToString.Trim, Reader("Doctor" + d.ToString() + "Phone").ToString.Trim))

                End If
            Next
        Loop
        Reader.Close()
        Reader.Dispose()
        If ComboBoxReferringDoctor.Items.Count = 1 Then
            ComboBoxReferringDoctor.SelectedIndex = 0
        End If
ExitSub:
        Cursor = Cursors.Default
    End Sub

    Private Sub txtDOA_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDOA.TextChanged
        ErrorProvider1.SetError(txtDOA, "")
    End Sub

    Private skeepNoMoreAppointmentsCheck As Boolean

    Private Sub CheckBoxNoMoreAppointmentsInd_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxNoMoreAppointmentsInd.CheckedChanged
        Dim ApprovedByName As String
        If skeepNoMoreAppointmentsCheck Then
            Exit Sub
        Else

        End If
        If OpMode = AddEditMode.Edit And CBool(CheckBoxNoMoreAppointmentsInd.Tag) = True And CheckBoxNoMoreAppointmentsInd.Checked = False Then
            If gCurrentEmployee.PositionID > 3 Then
                Dim frm As frmSupervisorApproval = New frmSupervisorApproval
                frm.LabelMsg.Text = "This patient's profile has been set as <No More Appointments>." & vbCrLf & "Please confirm you want to remove the <No More Appointments> flag..."
                If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                    skeepNoMoreAppointmentsCheck = True
                    CheckBoxNoMoreAppointmentsInd.Checked = True
                    skeepNoMoreAppointmentsCheck = False
                    frm.Dispose()
                    frm = Nothing
                    Exit Sub
                End If
                ApprovedByName = frm.SupervisorName
                frm.Dispose()
                frm = Nothing
            Else
                If MsgBox("This patient's profile has been set as <No More Appointments>." & vbCrLf & "Please confirm you want to remove the <No More Appointments> flag...", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                    skeepNoMoreAppointmentsCheck = True
                    CheckBoxNoMoreAppointmentsInd.Checked = True
                    skeepNoMoreAppointmentsCheck = False
                    Exit Sub
                End If
                ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
            End If
            gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Tag, PatientLogTypes.tNoMoreSchedulesRemoved, "", ApprovedByName)
        End If
        If CheckBoxNoMoreAppointmentsInd.Checked Then
            lblNoMoreAppointmentsInd.ForeColor = Color.Red
        Else
            lblNoMoreAppointmentsInd.ForeColor = Color.Black
        End If
        If OpMode <> AddEditMode.None Then
            ButtonDeleteProcedure.Enabled = Not CheckBoxNoMoreAppointmentsInd.Checked
            ButtonAddProcedure.Enabled = Not CheckBoxNoMoreAppointmentsInd.Checked
            ListViewPatientLog.BackColor = CType(IIf(ButtonDeleteProcedure.Enabled, Color.White, Color.WhiteSmoke),
                                                 Color)
            ListViewProcedures.BackColor = CType(IIf(ButtonAddProcedure.Enabled, Color.White, Color.WhiteSmoke),
                                                 Color)
        End If
    End Sub

    Private Sub LockUnclockProfile(ByVal Lc As Boolean, Optional ByVal PatientID As Long = 0)
        If Lc = True Then
            gSQLDeleteRecord(
                "UPDATE Patients Set LockDT=getdate(), LockByID=" & gCurrentEmployee.EmpID.ToString & ", LockedByIP = '" & gCurrentEmployee.ComputerInfo.HostIP.ToSafeSQLString() & "', LockedByHostName='" & gCurrentEmployee.ComputerInfo.HostName.ToSafeSQLString() & "', LockedByName='" & gCurrentEmployee.FName.ToSafeSQLString() & " " & gCurrentEmployee.LName.ToSafeSQLString() & "' Where PatientID=" & PatientID)
        Else
            gSQLDeleteRecord(
                "UPDATE Patients Set LockDT=Null, LockByID=0, LockedByIP = '', LockedByHostName='', LockedByName='' Where LockByID=" &
                gCurrentEmployee.EmpID.ToString)
        End If
    End Sub

    Private Sub ButtonAddProcedure_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAddProcedure.Click

        ErrorProvider1.SetError(ListViewProcedures, "")
        If ListViewPatients.SelectedItems.Count = 0 And OpMode = AddEditMode.None Then
            MsgBox("Unable to add procedure." & vbCrLf & "No Patient Selected", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If CheckBoxNoMoreAppointmentsInd.Checked Then
            MsgBox("Unable to add procedures to the patient marked as" & vbCrLf & "No More Appointments",
                   MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim ShiftWCTab As Integer = 1
        'If TabControl1.TabPages.ContainsKey("TabPageWC") = True Then
        '    ShiftWCTab = 0
        'End If
        If ComboBoxCaseStatusID.SelectedIndex > -1 Then
            If CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value <> 1 Then
                MsgBox(
                    "The case status " & CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Description & "." &
                    vbCrLf & "Unable to add procedures to the " &
                    CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Description & " case.",
                    MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        'If ComboBoxCaseTypeID.SelectedIndex = -1 Then
        '    MsgBox("Unable to add procedures. Please select a case Type.", MsgBoxStyle.Exclamation)
        '    ComboBoxCaseTypeID.Focus()
        '    Exit Sub
        'End If
        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            If ComboBoxReferringCompanyID.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 2 - ShiftWCTab
                MsgBox("Unable to add procedures. Please specify the Referring Company and Referring Doctor.",
                       MsgBoxStyle.Exclamation)
                ComboBoxReferringCompanyID.Focus()
                Exit Sub
            End If
        End If
        If ComboBoxCaseTypeID.SelectedItem Is Nothing Then
            TabControl1.SelectedIndex = 1 - ShiftWCTab
            MsgBox("Unable to add procedures. Please specify the Case Type.",
                       MsgBoxStyle.Exclamation)
            ComboBoxCaseTypeID.Focus()
            Exit Sub
        End If
        Dim frm As frmAddProcedure = New frmAddProcedure
        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            frm.ReferringCompanyID = CType(ComboBoxReferringCompanyID.SelectedItem, ValueDescription).Value.ToString
            If ComboBoxReferringDoctor.SelectedIndex > -1 Then
                frm.ReferringDoctorIndex = ComboBoxReferringDoctor.SelectedIndex
                frm.ReferringDoctorName = CType(ComboBoxReferringDoctor.SelectedItem, ValueDescription).Description
                'frm.ReferringDoctorName = ComboBoxReferringDoctor.Text
            End If
        Else
            With frm
                .ComboBoxReferringDoctor.Visible = False
                .Height = 495
                .ListViewProcedures.Top = .ListViewProcedures.Top - 40
                .ListViewProcedures.Height = .ListViewProcedures.Height + 40
                .LabelProcDate.Visible = True
                .DateTimePickerProcDate.Visible = True
                .Label2.Visible = False
                .Label63.Visible = False
            End With
        End If
        frm.CalledListViewProcedures = ListViewProcedures
        frm.CaseType = CInt(CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value)
        'frm.CaseType = 999   ' Ignore Case Type
        'frm.ExcludeExistingProcedures = RetIDs
        If OpMode = AddEditMode.None Then
            If ListViewPatients.SelectedItems.Count > 0 Then
                cmdEdit_Click(Nothing, Nothing)
            Else
                cmdAddNew_Click(Nothing, Nothing)
            End If
        End If

        frm.ShowDialog(Me)
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub ButtonDeleteProcedure_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonDeleteProcedure.Click

        Dim SaveIndex As Integer
        Dim Reader As SqlClient.SqlDataReader
        Dim ScheduleDateTime As String = ""
        ErrorProvider1.SetError(ListViewProcedures, "")
        If ListViewProcedures.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ComboBoxCaseStatusID.SelectedIndex > -1 Then
            If CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value <> 1 Then
                MsgBox(
                    "Unable to modify the Patient's profile when the case status is " &
                    CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Description & ".",
                    MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            If ListViewProcedures.SelectedItems(0).ImageIndex = 2 Then
                MsgBox("Unable to remove Compleded procedure.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If Val(ListViewProcedures.SelectedItems(0).SubItems(0).Tag) > 0 Then
                Reader =
                    gSQLGetDataReaderAsync(
                        "SELECT    Schedule.ScheduleID ,  Schedule.ScheduleDateTime FROM         PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID Where PatientProcedures.PatientProcedureID = " &
                        ListViewProcedures.SelectedItems(0).SubItems(0).Tag).Result
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    ScheduleDateTime = CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yyyy hh:mm tt")
                Loop
                Reader.Close()
                Reader.Dispose()

                If _
                    MsgBox(
                        "Please confirm you want to remove procedure" & vbCrLf &
                        ListViewProcedures.SelectedItems(0).SubItems(1).Text & vbCrLf & " scheduled for " &
                        ScheduleDateTime & "from the patient's profile?" & vbCrLf & vbCrLf &
                        "The schedule for this procedure will be canceled also!",
                        MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                If ListViewProcedures.SelectedItems(0).SubItems(0).Tag <> "" Then
                    gSQLDeleteRecord(
                        "Delete from PatientProcedures Where PatientProcedureID = " &
                        ListViewProcedures.SelectedItems(0).SubItems(0).Tag)
                    gUpdate_Profile_Log(CLng(ListViewPatients.SelectedItems(0).Tag), PatientLogTypes.tProceduresRemoved,
                                        "Procedure " & ListViewProcedures.SelectedItems(0).SubItems(1).Text)
                End If
                MsgBox(
                    "Procedure has been removed. Please inform the Patient about procedure scheduled for " &
                    ScheduleDateTime & " cancelation.", MsgBoxStyle.Information)
            Else
                If _
                    MsgBox(
                        "Please confirm you want to remove procedure" & vbCrLf &
                        ListViewProcedures.SelectedItems(0).SubItems(1).Text & vbCrLf & " from the patient's profile?",
                        MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            End If
        Else

            If _
                gSQLGetSingleValue(
                    "SELECT     COUNT(*) AS C FROM BillProcedures WHERE PatientProcedureID = " &
                    ListViewProcedures.SelectedItems(0).SubItems(0).Tag) > 0 Then
                MsgBox("Unable to delete selected procedure." & vbCrLf & "This procedure is already billed.",
                       MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If Val(ListViewProcedures.SelectedItems(0).SubItems(0).Tag) > 0 Then
                Reader =
                    gSQLGetDataReaderAsync(
                        "SELECT    Schedule.ScheduleID ,  Schedule.ScheduleDateTime FROM         PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID Where PatientProcedures.PatientProcedureID = " &
                        ListViewProcedures.SelectedItems(0).SubItems(0).Tag).Result
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    ScheduleDateTime = CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yyyy hh:mm tt")
                Loop
                Reader.Close()
                Reader.Dispose()

                If _
                    MsgBox(
                        "Please confirm you want to remove procedure" & vbCrLf &
                        ListViewProcedures.SelectedItems(0).SubItems(1).Text & vbCrLf & " completted on " &
                        ScheduleDateTime & " from the patient's profile?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) =
                    MsgBoxResult.No Then Exit Sub
                If ListViewProcedures.SelectedItems(0).SubItems(0).Tag <> "" Then
                    gSQLDeleteRecord(
                        "Delete from PatientProcedures Where PatientProcedureID = " &
                        ListViewProcedures.SelectedItems(0).SubItems(0).Tag)
                    gUpdate_Profile_Log(CLng(ListViewPatients.SelectedItems(0).Tag), PatientLogTypes.tProceduresRemoved,
                                        "Procedure " & ListViewProcedures.SelectedItems(0).Text)
                End If
            End If
        End If
        SaveIndex = ListViewProcedures.SelectedItems(0).Index
        ListViewProcedures.Items.Remove(ListViewProcedures.SelectedItems(0))
        If ListViewProcedures.Items.Count > 0 Then
            If ListViewProcedures.Items.Count - 1 >= SaveIndex Then
                ListViewProcedures.Items(SaveIndex).Selected = True
            Else
                ListViewProcedures.Items(SaveIndex - 1).Selected = True
            End If
        End If
    End Sub

    Private Sub txtDOB_MaskInputRejected(ByVal sender As Object,
                                         ByVal e As MaskInputRejectedEventArgs) Handles txtDOB.MaskInputRejected

    End Sub

    Private Sub txtDOB_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles txtDOB.Validated
        If IsDate(txtDOB.Text) Then
            If gYearsFromDate(txtDOB.Text) < gUnderAge Then
                LabelDOB.ForeColor = Color.IndianRed
                LabelDOB.Text = "DOB Underage"
            Else
                LabelDOB.Text = "DOB"
                LabelDOB.ForeColor = Color.Black
            End If
        Else
            LabelDOB.Text = "DOB"
            LabelDOB.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ListViewProcedures_ColumnClick(ByVal sender As Object,
                                               ByVal e As ColumnClickEventArgs) Handles ListViewProcedures.ColumnClick

        Dim new_sorting_column As ColumnHeader = ListViewProcedures.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As SortOrder
        If pr_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(pr_SortingColumn) Then
                ' Same column. Switch the sort order.

                'If pr_SortingColumn.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If pr_SortingColumn.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'pr_SortingColumn.Text =             pr_SortingColumn.Text.Mid(2)
            pr_SortingColumn.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        pr_SortingColumn = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'pr_SortingColumn.Text = "> " & pr_SortingColumn.Text
        'Else
        'pr_SortingColumn.Text = "< " & pr_SortingColumn.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            pr_SortingColumn.ImageKey = "SORT1"
        Else
            pr_SortingColumn.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewProcedures.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewProcedures.Sort()
    End Sub

    Private Sub ListViewProcedures_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewProcedures.SelectedIndexChanged

        gHighlightListviewItem(ListViewProcedures, True, False)
        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            If OpMode <> AddEditMode.None Then
                If ListViewProcedures.SelectedItems.Count > 0 AndAlso ListViewProcedures.SelectedItems(0).ImageIndex = 2 _
                    Then
                    ButtonDeleteProcedure.Enabled = False
                Else
                    ButtonDeleteProcedure.Enabled = True
                End If
            End If
        Else
            ButtonDeleteProcedure.Enabled = True
        End If
    End Sub

    Private Sub txtAddress1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtAddress1.KeyPress

        txtAddress1.Tag = ""
    End Sub

    Private Sub txtAddress1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAddress1.TextChanged

        ErrorProvider1.SetError(txtAddress1, "")
    End Sub

    Private Sub txtAddress2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAddress2.TextChanged

        ErrorProvider1.SetError(txtAddress2, "")
    End Sub

    Private Sub txtCity_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCity.KeyPress

        txtAddress1.Tag = ""
    End Sub

    Private Sub txtCity_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCity.TextChanged

        ErrorProvider1.SetError(txtCity, "")
    End Sub

    Private Sub ComboBoxState_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxState.Click
        txtAddress1.Tag = ""
    End Sub

    Private Sub ComboBoxState_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxState.SelectedIndexChanged

        ErrorProvider1.SetError(ComboBoxState, "")
    End Sub

    Private Sub txtPhone1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPhone1.TextChanged
        ErrorProvider1.SetError(txtPhone1, "")
    End Sub

    Private Sub ComboBoxReferringDoctor_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxReferringDoctor.SelectedIndexChanged

        ErrorProvider1.SetError(ComboBoxReferringDoctor, "")
    End Sub

    Private Sub ComboBoxTransportationCompanyID_SelectedIndexChanged(ByVal sender As Object,
                                                                     ByVal e As EventArgs) Handles ComboBoxTransportationCompanyID.SelectedIndexChanged

        ErrorProvider1.SetError(ComboBoxTransportationCompanyID, "")
    End Sub

    Private Sub Print_Photo_Label(ByVal PatientID As Long)
        Dim CR As ReportDocument
        CR = New rptPatientPhotoFileLabel
        If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
        CR.SetParameterValue("PatientID", PatientID.ToString)
        If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gPrinterFileLabel
        CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 0, 0, 0))
        CR.PrintToPrinter(1, False, 0, 0)
    End Sub

    Private Sub Print_Label(ByVal PatientID As Long)
        Dim CR As ReportDocument
        CR = New rptPatientFileLabel

        'gShowWait(True, PanelWait, Me)
        'ConInfo.ConnectionInfo.UserID = gSQLServerUID
        'ConInfo.ConnectionInfo.Password = gSQLServerPassword
        'ConInfo.ConnectionInfo.ServerName = gSQLServerName
        'ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
        'For intCounter = 0 To CR.Database.Tables.Count - 1
        '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.UserID = gSQLServerUID
        '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.Password = gSQLServerPassword
        '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.ServerName = gSQLServerName
        '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
        '    Application.DoEvents()
        '    CR.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
        '    Application.DoEvents()
        'Next
        'CR.Refresh()
        If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
        CR.SetParameterValue("PatientID", PatientID.ToString)
        If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gPrinterFileLabel
        CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 0, 0, 0))
        CR.PrintToPrinter(1, False, 0, 0)
    End Sub

    Private Sub ComboBoxInsuranceCompanyID_SelectedIndexChanged(ByVal sender As Object,
                                                                ByVal e As EventArgs) Handles ComboBoxInsuranceCompanyID.SelectedIndexChanged

        ErrorProvider1.SetError(ComboBoxInsuranceCompanyID, "")
        ComboBoxClaimAddress.Items.Clear()
        ComboBoxClaimAddress.Text = ""
        If ComboBoxInsuranceCompanyID.SelectedIndex = -1 Then Exit Sub
        Dim Reader As SqlClient.SqlDataReader
        Cursor = Cursors.WaitCursor
        Reader =
            gSQLGetDataReaderAsync(
                "SELECT AddressID, AddressName + ' - ' + Address + ' ' + City + ' ' + State + ' ' + Zip AS ClaimAddress FROM         InsuranceCompanyAddresses WHERE ActiveInd=1 and CompanyID =" &
                CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Value.ToString &
                " ORDER BY ClaimAddress").Result
        If Reader Is Nothing Then GoTo ExitSub
        Do Until Reader.Read = False
            ComboBoxClaimAddress.Items.Add(New ValueDescription(CLng(Val(Reader("AddressID").ToString)), Reader("ClaimAddress").ToString))
        Loop
        If ComboBoxClaimAddress.Items.Count = 1 Then
            ComboBoxClaimAddress.SelectedIndex = 0
        End If
        Reader.Close()
        Reader.Dispose()
ExitSub:
        Cursor = Cursors.Default
    End Sub

    Public NewAddress As Long

    Private Sub cmdAddInsuranceAddress_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddInsuranceAddress.Click

        If gCurrentEmployee.PositionID > 3 Then
            Dim frm As frmSupervisorApproval = New frmSupervisorApproval
            frm.LabelMsg.Text = "Add New Insurance Claim Address"
            If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frm.Dispose()
                frm = Nothing
                Exit Sub
            End If
            frm.Dispose()
            frm = Nothing
        End If
        If ComboBoxInsuranceCompanyID.SelectedIndex = -1 Then
            MsgBox("Unable to add Insurance Address. Please select an Insurance Company first.", MsgBoxStyle.Exclamation)
            ComboBoxInsuranceCompanyID.Focus()
            Exit Sub
        End If
        NewAddress = 0
        Dim frmins As frmInsuranceAddAddress = New frmInsuranceAddAddress
        frmins.CalledForm = Me
        frmins.InsCompanyID = CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Value
        If frmins.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ComboBoxInsuranceCompanyID_SelectedIndexChanged(Nothing, Nothing)
            If NewAddress <> 0 Then
                gFindComboItemByValue(ComboBoxClaimAddress, NewAddress, True)
            End If
        End If
        frmins.Dispose()
        frmins = Nothing
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
    End Sub

    Public Sub ListViewDocs_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles ListViewDocs.ColumnClick

        Dim new_sorting_column As ColumnHeader = ListViewDocs.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As SortOrder
        If m_SortingColumnDocuments Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumnDocuments) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumnDocuments.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumnDocuments.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumnDocuments.Text =             m_SortingColumnDocuments.Text.Mid(2)
            m_SortingColumnDocuments.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumnDocuments = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumnDocuments.Text = "> " & m_SortingColumnDocuments.Text
        'Else
        'm_SortingColumnDocuments.Text = "< " & m_SortingColumnDocuments.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumnDocuments.ImageKey = "SORT1"
        Else
            m_SortingColumnDocuments.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewDocs.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewDocs.Sort()
    End Sub

    Private Sub ListViewDocs_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewDocs.DoubleClick

        Dim Ret As String
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Or ListViewDocs.SelectedItems.Count = 0 Then Exit Sub
        LI = ListViewDocs.SelectedItems(0)
        Dim PatientID As Integer
        PatientID = ListViewPatients.SelectedItems(0).Tag
        Select Case Val(LI.SubItems(1).Tag)
            Case 6, 18 ' POM ' CDPOM
                MsgBox("Unable to rename POM / CD POM", MsgBoxStyle.Exclamation, "Oops...")
                Exit Sub
            Case 999 'RTF
                Dim doc As RTFDocument = DirectCast(ListViewDocs.SelectedItems(0).Tag, RTFDocument)
                Ret = InputBox("Specify the new document name." & vbCrLf & "The current document name - " & LI.Text, "Rename Document", LI.Text).Trim
retry999:
                If Ret = "" Then Exit Sub
                If Ret = LI.Text Then Exit Sub
                If Ret.Length > 50 Then
                    MsgBox("Unable to rename document." & vbCrLf & "The maximum length of the document name allowed: 50 characters.", MsgBoxStyle.Exclamation, "Oops...")
                    Ret = InputBox("Specify the new document name." & vbCrLf & "The current document name - " & LI.Text, "Rename Document", Ret).Trim
                    GoTo retry999
                End If
                gSQLUpdateData("Update PatientRTFDocuments Set DocName = '" & Ret.ToSafeSQLString() & "' where ID = " & doc.ID)
                doc.DocName = Ret
                ListViewDocs.SelectedItems(0).Tag = doc
            Case Else
                Ret = InputBox("Specify the new document name." & vbCrLf & "The current document name - " & LI.Text, "Rename Document", LI.Text).Trim
retry:
                If Ret = "" Then Exit Sub
                If Ret = LI.Text Then Exit Sub
                If Ret.Length > 50 Then
                    MsgBox("Unable to rename document." & vbCrLf & "The maximum length of the document name allowed: 50 characters.", MsgBoxStyle.Exclamation, "Oops...")
                    Ret = InputBox("Specify the new document name." & vbCrLf & "The current document name - " & LI.Text, "Rename Document", Ret).Trim
                    GoTo retry
                End If
                gSQLUpdateData("Update Documents Set DocumentName = '" & Ret.ToSafeSQLString() & "' where DocumentID = " & Val(LI.Tag))
        End Select
        LI.Text = Ret
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tOther, "Document Renamed from: " & LI.Text & " TO " & Ret)
    End Sub

    Public Sub ListViewDocs_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewDocs.SelectedIndexChanged
        gHighlightListviewItem(ListViewDocs, True, False)
        LabelDocument.Text = "Loading Document. Please wait..."
        PanelDocumentWait.Visible = True
        PanelDocumentWait.BringToFront()
        Application.DoEvents()
        LockWindowUpdate(Me.Handle)
        TabControl1.Enabled = False
        PanelSearch.Enabled = False
        If ListViewDocs.SelectedItems.Count = 0 Then
            lblFileSize.Text = ""
            'Clear_Web_Document(pdfViewer)
            pdfViewer.CloseDocument()
            TabControl1.Enabled = True
            PanelSearch.Enabled = True
            LockWindowUpdate(0)
            LabelDocument.Text = "Document Preview"
            PanelDocumentWait.Visible = False
            Exit Sub
        End If

        Application.DoEvents()
        Application.DoEvents()
        Application.DoEvents()
        Application.DoEvents()
        load_document()
        LabelDocument.Text = "Document Preview"
        PanelDocumentWait.Visible = False
        TabControl1.Enabled = True
        PanelSearch.Enabled = True
        If RichTextBox1.Visible Then
            ButtonRotatePDF.Visible = False
        Else
            If pdfViewer.Renderer.Rotation <> PdfiumViewer.PdfRotation.Rotate0 Then
                pdfViewer.Renderer.Rotation = PdfiumViewer.PdfRotation.Rotate0
                pdfViewer.Refresh()
            End If
            ButtonRotatePDF.Top = 0
            ButtonRotatePDF.Visible = True
            ButtonRotatePDF.BringToFront()
            pdfViewer.ShowToolbar = True
        End If
        LockWindowUpdate(0)
    End Sub

    Private Sub load_document()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim MyFile As IO.FileInfo
        'Clear_Web_Document(pdfViewer)
        Try
            pdfViewer.CloseDocument()
            Application.DoEvents()
            lblFileSize.Text = ""
            Application.DoEvents()
            Application.DoEvents()
            Application.DoEvents()
            ToolStripButton3.Visible = True
            Select Case Val(ListViewDocs.SelectedItems(0).SubItems(1).Tag)

                Case 6
                    RichTextBox1.Visible = False
                    If Not ListViewDocs.SelectedItems(0).SubItems(2).Tag Is Nothing Then
                        GoTo load_cached_image6
                    End If
                    Reader =
                    gSQLGetDataReaderAsync("SELECT POMImage FROM POM where POMID=" & Val(ListViewDocs.SelectedItems(0).Tag)).Result
                    If Reader Is Nothing Then
                        MsgBox("Unexpected error. Please call system administrator.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If Reader.HasRows Then
                        Cursor = Cursors.WaitCursor
                        Reader.Read()
                        If Reader("POMImage") Is DBNull.Value Then
                            MsgBox(
                            "Unexpected Error." & vbCrLf & "The POM image is invalid or damaged." & vbCrLf &
                            "Please ReScan the document." & vbCrLf & vbCrLf &
                            "The current/invalid document image will be deleted.", MsgBoxStyle.Exclamation)
                            ListViewDocs.SelectedItems(0).Remove()
                            'Clear_Web_Document(pdfViewer)
                            pdfViewer.CloseDocument()
                            pdfViewer.Visible = True
                            lblFileSize.Text = ""
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
load_cached_image6:
                        Dim arrayImage() As Byte
                        If (ListViewDocs.SelectedItems(0).SubItems(2).Tag Is Nothing) Then
                            arrayImage = CType(Reader("POMImage"), Byte())
                            ListViewDocs.SelectedItems(0).SubItems(2).Tag = arrayImage
                            'ListViewDocs.SelectedItems(0).SubItems(2).Text = "+"
                        Else
                            arrayImage = CType(ListViewDocs.SelectedItems(0).SubItems(2).Tag, Byte())
                        End If
                        Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", ListViewDocs.SelectedItems(0).Text)
                        If IO.File.Exists(FName) Then
                            pdfViewer.Visible = True
                            pdfViewer.LoadDocument(FName)
                            pdfViewer.Tag = FName
                            'MyFile = New IO.FileInfo(FName)
                            lblFileSize.Text = "Document Size: " & gFormatFileSize(arrayImage.Length)
                            'pdfViewer.Visible = True
                            TimerPdfRefresh.Enabled = True
                            Cursor = Cursors.Default
                        End If
                    Else
                        MsgBox("Unexpected error. No POM Image Found. Please call system administrator.",
                           MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Case 18
                    RichTextBox1.Visible = False
                    If Not ListViewDocs.SelectedItems(0).SubItems(2).Tag Is Nothing Then
                        GoTo load_cached_image18
                    End If
                    Reader =
                    gSQLGetDataReaderAsync("SELECT POMImage FROM CDPOM where POMID=" & Val(ListViewDocs.SelectedItems(0).Tag)).Result
                    If Reader Is Nothing Then
                        MsgBox("Unexpected error. Please call system administrator.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If Reader.HasRows Then
                        Cursor = Cursors.WaitCursor
                        Reader.Read()
                        If Reader("POMImage") Is DBNull.Value Then
                            MsgBox(
                            "Unexpected Error. The CD POM image is invalid or damaged. Please ReScan the document." &
                            vbCrLf & vbCrLf & "The current/invalid document image will be deleted.")
                            gSQLUpdateData(
                            "DELETE FROM CDPOM where (POMImage IS NULL) and POMID=" &
                            Val(ListViewDocs.SelectedItems(0).Tag))
                            ListViewDocs.SelectedItems(0).Remove()
                            'Clear_Web_Document(pdfViewer)
                            pdfViewer.CloseDocument()
                            pdfViewer.Visible = True
                            lblFileSize.Text = ""
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
load_cached_image18:
                        Dim arrayImage() As Byte
                        If (ListViewDocs.SelectedItems(0).SubItems(2).Tag Is Nothing) Then
                            arrayImage = CType(Reader("POMImage"), Byte())
                            ListViewDocs.SelectedItems(0).SubItems(2).Tag = arrayImage
                            'ListViewDocs.SelectedItems(0).SubItems(2).Text = "+"
                        Else
                            arrayImage = CType(ListViewDocs.SelectedItems(0).SubItems(2).Tag, Byte())
                        End If
                        Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", ListViewDocs.SelectedItems(0).Text)
                        If IO.File.Exists(FName) Then
                            pdfViewer.Visible = True
                            pdfViewer.LoadDocument(FName)
                            pdfViewer.Tag = FName
                            'MyFile = New IO.FileInfo(FName)
                            lblFileSize.Text = "Document Size: " & gFormatFileSize(arrayImage.Length)
                            'pdfViewer.Visible = True
                            TimerPdfRefresh.Enabled = True
                            Cursor = Cursors.Default
                        End If
                    Else
                        MsgBox("Unexpected error. No POM Image Found. Please call system administrator.",
                           MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Case 999 And ListViewDocs.SelectedItems(0).Text.StartsWith("Bill # ") = False 'RTF
                    ToolStripButton3.Visible = False

                    Dim doc As RTFDocument = DirectCast(ListViewDocs.SelectedItems(0).Tag, RTFDocument)
                    RichTextBox1.Rtf = doc.Data
                    RichTextBox1.Tag = doc
                    RichTextBox1.Location = pdfViewer.Location
                    RichTextBox1.Size = pdfViewer.Size
                    RichTextBox1.Visible = True
                    RichTextBox1.BringToFront()

                Case Else
                    If Not ListViewDocs.SelectedItems(0).SubItems(2).Tag Is Nothing Then
                        GoTo load_cached_image
                    End If
                    RichTextBox1.Visible = False
                    SQL = "SELECT DocumentImage   FROM         Documents Where DocumentID=" &
                      ListViewDocs.SelectedItems(0).Tag
                    Reader = gSQLGetDataReaderAsync(SQL).Result
                    If Reader Is Nothing Then Exit Sub
                    If Reader.HasRows Then
                        Cursor = Cursors.WaitCursor
                        Reader.Read()
                        If Reader("DocumentImage") Is DBNull.Value Then
                            MsgBox(
                            "Unexpected Error. The Document image is invalid or damaged. Please ReScan the document." &
                            vbCrLf & vbCrLf & "The current/invalid document image will be deleted.")
                            gSQLUpdateData(
                            "DELETE FROM Documents where DocumentID=" & Val(ListViewDocs.SelectedItems(0).Tag))
                            ListViewDocs.SelectedItems(0).Remove()
                            'Clear_Web_Document(pdfViewer)
                            pdfViewer.CloseDocument()
                            pdfViewer.Visible = True
                            Cursor = Cursors.Default
                            lblFileSize.Text = ""
                        Else
load_cached_image:
                            Dim arrayImage() As Byte
                            If (ListViewDocs.SelectedItems(0).SubItems(2).Tag Is Nothing) Then
                                arrayImage = CType(Reader("DocumentImage"), Byte())
                                ListViewDocs.SelectedItems(0).SubItems(2).Tag = arrayImage
                                'ListViewDocs.SelectedItems(0).SubItems(2).Text = "+"
                            Else
                                arrayImage = CType(ListViewDocs.SelectedItems(0).SubItems(2).Tag, Byte())
                            End If
                            Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", ListViewDocs.SelectedItems(0).Text)
                            If IO.File.Exists(FName) Then
                                pdfViewer.Visible = True
                                pdfViewer.LoadDocument(FName)
                                pdfViewer.Tag = FName
                                'MyFile = New IO.FileInfo(FName)
                                lblFileSize.Text = "Document Size: " & gFormatFileSize(arrayImage.Length)
                                TimerPdfRefresh.Enabled = True
                            End If
                        End If
                    End If
            End Select
        Catch ex As Exception
            log.Error(ex)
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub ToolStripButton3_Click_2(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAddComments.Click

        If OpMode = AddEditMode.None Then
            If ListViewPatients.SelectedItems.Count = 0 Then
                MsgBox("Unable to add comments. No Patient selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            Else
            End If
        End If
        Dim frm As frmAddComment = New frmAddComment
        frm.txtComments = TextBoxCommentView
        frm.ListViewComments = ListViewComments
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If OpMode = AddEditMode.None Then
                gSQLUpdateData(
                    "UPDATE PatientComments set PatientID = " & ListViewPatients.SelectedItems(0).Tag &
                    " where PatientID=0 and InsertedBy=" & gCurrentEmployee.EmpID)
            End If
        End If
        frm.Dispose()
        frm = Nothing
    End Sub

    Dim WithEvents PD As New Printing.PrintDocument
    Private checkPrint As Integer

    Private Sub ToolStripButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButton2.Click

        If ListViewDocs.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Document selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        'For windows 11, to return old style dialog, use Command Prompt,
        'reg add "HKCU\Software\Microsoft\Print\UnifiedPrintDialog" /v "PreferLegacyPrintDialog" /d 1 /t REG_DWORD /f

        Using PrintDialog1 As PrintDialog = New PrintDialog

            If Val(ListViewDocs.SelectedItems(0).SubItems(1).Tag) = 999 Then
                PrintDialog2.Document = PrintDocument1
                If PrintDialog2.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    PrintDocument1.Print()
                End If
            Else
                If pdfViewer.Tag = "" Then
                    MsgBox("Unable to process your request. No Document Loaded.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                Dim p = pdfViewer.Document.CreatePrintDocument
                AddHandler p.PrintPage, AddressOf Pdf_PrintPage
                PrintDialog1.Document = p
                PrintDialog1.PrinterSettings = p.PrinterSettings
                PrintDialog1.AllowSomePages = False
                PrintDialog1.AllowPrintToFile = True
                PrintDialog1.AllowCurrentPage = True
                PrintDialog1.UseEXDialog = False
                If PrintDialog1.ShowDialog(Me) = DialogResult.OK Then
                    p.PrinterSettings = PrintDialog1.PrinterSettings
                    p.PrinterSettings.PrintRange = PrintDialog1.PrinterSettings.PrintRange
                    'Using printPrvDlg As PrintPreviewDialog = New PrintPreviewDialog()

                    '    printPrvDlg.Document = p
                    '    printPrvDlg.StartPosition = FormStartPosition.CenterParent
                    '    printPrvDlg.Width = 500
                    '    printPrvDlg.Height = 600

                    '    'If printPrvDlg.ShowDialog(Me) = DialogResult.OK Then
                    '    'If printPrvDlg.ShowDialog() = DialogResult.OK Then
                    '    p.Print()
                    'End Using
                    p.Print()
                End If
                'pdfViewer.PrintDocument(Me)
            End If
        End Using
        GC.Collect()

    End Sub
    Private Sub Pdf_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)

        If sender.PrinterSettings.PrintRange = Printing.PrintRange.CurrentPage Then
            Dim PageNumber = pdfViewer.Renderer.Page
            Dim Sizes As IList(Of SizeF) = pdfViewer.Document.PageSizes()
            Dim img As Image = pdfViewer.Document.Render(PageNumber, e.Graphics.DpiX, e.Graphics.DpiY, PdfiumViewer.PdfRenderFlags.CorrectFromDpi)
            e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            e.Graphics.DrawImage(img, -10, -10, e.PageSettings.Bounds.Width, e.PageSettings.Bounds.Height)
            e.HasMorePages = False
        Else

        End If
    End Sub
    Private ReadOnly LastLoadedTab(10) As Integer

    Public Async Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        Dim ShiftWCTab As Integer = 0

        'If TabControl1.TabPages.ContainsKey("TabPageWC") = True Then
        '    ShiftWCTab = 1
        'End If
        Dim ID As Integer = CLng(ListViewPatients.SelectedItems(0).Tag)

        Select Case TabControl1.SelectedIndex
            Case 0
                If LastLoadedTab(0) <> ID Then
                    Load_RelatedPatients()
                    'Load_Photo()
                    Dim img As Image = Await Load_Photo()
                    picPhoto.Image = img
                    If img Is Nothing Then
                        ToolStripButtonPreview.Enabled = False
                        ToolStripButtonPrintPhotoLabel.Enabled = False
                    Else
                        ToolStripButtonPreview.Enabled = True
                        ToolStripButtonPrintPhotoLabel.Enabled = True
                    End If
                    '

                    LastLoadedTab(0) = ID
                End If
            Case 1 + ShiftWCTab
                If LastLoadedTab(1) <> ID Then

                    LastLoadedTab(1) = ID
                End If
            Case 2 + ShiftWCTab
                If LastLoadedTab(2) <> ID Then
                    Load_Documents(True)
                    LastLoadedTab(2) = ID
                End If
                If Loading = False Then ListViewDocs.Focus()
            Case 3 + ShiftWCTab
                If LastLoadedTab(3) <> ID Then
                    Load_Comments()
                    LastLoadedTab(3) = ID
                End If
            Case 4 + ShiftWCTab
                If LastLoadedTab(4) <> ID Then
                    Load_Readings()
                    LastLoadedTab(4) = ID
                End If
            Case 5 + ShiftWCTab
                If LastLoadedTab(5) <> ID Then
                    If gCurrentEmployee.PositionID <> 4 And gCurrentEmployee.PositionID <> 10 Then
                        Load_Parient_Bills()
                    End If
                    LastLoadedTab(5) = ID
                End If
            Case 6 + ShiftWCTab
                If LastLoadedTab(6) <> ID Then
                    Load_Cancelations()
                    Load_Patient_Log()
                    LastLoadedTab(6) = ID
                End If
            Case 7 + ShiftWCTab
                If LastLoadedTab(7) <> ID Then
                    Load_Requests()
                    LastLoadedTab(7) = ID
                End If
            Case 8 + ShiftWCTab
                If LastLoadedTab(8) <> ID Then
                    Load_IME()
                    LastLoadedTab(8) = ID
                End If
            Case 9 + ShiftWCTab
                If LastLoadedTab(9) <> ID Then

                    LastLoadedTab(9) = ID
                End If
        End Select
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButton3.Click

        If ListViewDocs.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Document selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If pdfViewer.Tag = "" Then
            MsgBox("Unable to process your request. No Document Loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim frm As frmDocumentPreview = New frmDocumentPreview
        With frm
            .TextBoxReading.Visible = False
            .pdfViewer.Visible = True
            .pdfViewer.Dock = DockStyle.Fill
            '.pdfViewer.setShowToolbar(True)
            '.pdfViewer.setView("FitH")
            '.pdfViewer.setLayoutMode("SinglePage")
            '.pdfViewer.setShowScrollbars(True)
            .pdfViewer.LoadDocument(pdfViewer.Tag.ToString())
            .pdfViewer.Renderer.Rotation = pdfViewer.Renderer.Rotation
            .ShowDialog(Me)
        End With
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub TimerPdfRefresh_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TimerPdfRefresh.Tick

        TimerPdfRefresh.Enabled = False
        pdfViewer.Visible = True
        pdfViewer.Show()
        pdfViewer.BringToFront()
        pdfViewer.Update()
    End Sub

    Private Sub ToolStripButtonSaveAs_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonSaveAs.Click

        Dim Fname As String
        If ListViewDocs.SelectedItems.Count = 0 Then
            MsgBox("Unable to Save. No document selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            Fname = ListViewDocs.SelectedItems(0).Text
            If ListViewPatients.SelectedItems.Count > 0 Then
                Fname &= " " & ListViewPatients.SelectedItems(0).Text.ToSafeSQLString
            End If
        End If
        Fname = Fname.SanitizeFileName()
        If Val(ListViewDocs.SelectedItems(0).SubItems(1).Tag) = 999 Then
            SaveFileDialog1.Filter = "Rich Text Format (*.rtf)|*.rtf"
            SaveFileDialog1.DefaultExt = "rtf"
            Fname &= ".rtf"
            Fname = gFixFileName(Fname)
            SaveFileDialog1.FileName = Fname
            If SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Try
                    RichTextBox1.SaveFile(SaveFileDialog1.FileName)
                Catch ex As Exception
                    TopMost = False
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    log.Error(ex.Message, ex)
                End Try

            End If
        Else
            If IO.File.Exists(pdfViewer.Tag) = False Then
                MsgBox("Unexpected Error. Unable to save file. Please select a document and try again.",
                   MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If pdfViewer.Tag.ToString().Right(3).ToUpper() = "PDF" Then ' To keep compatible with previous JPG file versions
                SaveFileDialog1.Filter = "Adobe Acrobat File (*.pdf)|*.pdf"
                SaveFileDialog1.DefaultExt = "pdf"
                Fname &= ".pdf"
            Else
                SaveFileDialog1.Filter = "JPEG FIle (*.jpg)|*.jpg"
                SaveFileDialog1.DefaultExt = "jpg"
                Fname &= ".jpg"
            End If

            Fname = gFixFileName(Fname)
            SaveFileDialog1.FileName = Fname
            If SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Try
                    If pdfViewer.Tag.ToString().Right(3).ToUpper() = "PDF" Then
                        IO.File.Copy(pdfViewer.Tag, SaveFileDialog1.FileName)
                    Else
                        Image.FromFile(pdfViewer.Tag).Save(SaveFileDialog1.FileName)
                    End If
                Catch ex As Exception
                    TopMost = False
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    log.Error(ex.Message, ex)
                End Try

                'Dim P As New ProcessStartInfo()
                'With P
                '.FileName = SaveFileDialog1.FileName
                '.UseShellExecute = True
                'End With
                'Process.Start(P)
            End If

        End If
    End Sub

    Private Function GetEncoder(format As Imaging.ImageFormat) _
        As Imaging.ImageCodecInfo

        Dim codecs As Imaging.ImageCodecInfo() = Imaging.ImageCodecInfo.GetImageDecoders()

        Dim codec As Imaging.ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing
    End Function

    Private Sub ToolStripButtonEmail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonEmail.Click

        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim fCount As Integer
        Dim DocNames As String
        Dim Fname() As String = Nothing
        If ListViewDocs.SelectedItems.Count > 0 AndAlso Val(ListViewDocs.SelectedItems(0).SubItems(1).Tag) = 999 Then
            If ListViewDocs.SelectedItems.Count = 0 Then
                MsgBox("Unable to process your request. No Document selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim TempFile As String
            Subject = "Document: " & ListViewDocs.SelectedItems(0).Text & ". Office: " & gOfficeName
            TempFile = Path.GetTempFileName()
            TempFile = TempFile.Mid(1, TempFile.Length - 3) & "rtf"
            Try
                RichTextBox1.SaveFile(TempFile)
                Msg.SendMail(TempFile, Subject, Subject)
                gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Tag, PatientLogTypes.tEmailSent, ListViewDocs.SelectedItems(0).Text & " Emailed")
                Load_Patient_Log()
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try
            Return
        End If

        If ListViewDocs.CheckedItems.Count = 0 Then
            If ListViewDocs.SelectedItems.Count = 0 Then
                MsgBox("Unable to send email. No document selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If ListViewPatients.SelectedItems.Count > 0 And OpMode <> AddEditMode.AddNew Then
                Subject = "Attached: " & ListViewDocs.SelectedItems(0).Text & " Patient: " &
                          ListViewPatients.SelectedItems(0).SubItems(1).Text &
                          IIf(txtPolicyNumber.Text <> "", " Policy #: " & txtPolicyNumber.Text, "") &
                          IIf(txtClaimNumber.Text <> "", " Claim #: " & txtClaimNumber.Text, "")

            Else
                Subject = "Attached: " & ListViewDocs.SelectedItems(0).Text
            End If
            If ListViewDocs.SelectedItems.Count > 0 Then
                Subject &= " / Attached: " & ListViewDocs.SelectedItems(0).Text
            End If
            Subject &= ". Office: " & gOfficeName.ToUpper()
            Try

                Msg.SendMail(pdfViewer.Tag.ToString(), Subject, Subject)
                gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Tag, PatientLogTypes.tEmailSent, ListViewDocs.SelectedItems(0).Text & " Emailed")
                Load_Patient_Log()
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try
        Else
            fCount = 0
            For Each lvi As ListViewItem In ListViewDocs.CheckedItems

                lvi.EnsureVisible()
                lvi.Selected = True
                DocNames = DocNames + lvi.Text + " \ "
                ReDim Preserve Fname(fCount)
                Fname(fCount) = pdfViewer.Tag
                fCount = fCount + 1
            Next
            If ListViewPatients.SelectedItems.Count > 0 And OpMode <> AddEditMode.AddNew Then
                Subject = "Attached: " & ListViewDocs.CheckedItems.Count & "Files. Patient: " &
                          ListViewPatients.SelectedItems(0).SubItems(1).Text &
                          IIf(txtPolicyNumber.Text <> "", " Policy #: " & txtPolicyNumber.Text, "") &
                          IIf(txtClaimNumber.Text <> "", " Claim #: " & txtClaimNumber.Text, "")
            Else
                Subject = "Attached: " & ListViewDocs.CheckedItems.Count & " Files. "
            End If
            Subject &= " / Attached: " & DocNames
            Subject &= ". Office: " & gOfficeName.ToUpper()
            Try
                Msg.SendMail(Fname, Subject, Subject)
                If ListViewPatients.SelectedItems.Count > 0 Then
                    gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Text, PatientLogTypes.tEmailSent, DocNames & " Emailed.")
                    Load_Patient_Log()
                End If
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try
        End If
    End Sub

    Private Sub ComboBoxClaimAddress_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxClaimAddress.SelectedIndexChanged

        ErrorProvider1.SetError(ComboBoxClaimAddress, "")
    End Sub

    Private Sub PrintPatientInformationToolStripMenuItem_Click(ByVal sender As Object,
                                                               ByVal e As EventArgs) Handles PrintPatientsInformationToolStripMenuItem.Click

        Try
            If ListViewPatients.SelectedItems.Count = 0 Then
                MsgBox("Unable to print the Patient's information. No patient selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim PatID(0) As Long
            PatID(0) = ListViewPatients.SelectedItems(0).Tag
            Cursor = Cursors.WaitCursor
            Using frm As frmPatientInformationReport = New frmPatientInformationReport
                frm.Setup_report(PatID)
                Cursor = Cursors.Default
                frm.ShowDialog(Me)
                frm.Dispose()
            End Using
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub PrintPatientFileLabelToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PrintPatientsFileLabelToolStripMenuItem.Click

        Try
            Dim ID As Long
            If ListViewPatients.SelectedItems.Count = 0 Then
                MsgBox("Unable to print the Patient's File Label. No patient selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            PanelPrinting.Visible = True
            Application.DoEvents()
            ID = ListViewPatients.SelectedItems(0).Tag
            Cursor = Cursors.WaitCursor
            Print_Label(ID)
            Cursor = Cursors.Default
            PanelPrinting.Visible = False
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Button1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ButtonTools.MouseDown

        ContextMenuStrip1.Show(ButtonTools, e.Location)
    End Sub

    Private Sub Load_Parient_Bills()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim ParentNode As TreeNode = Nothing
        Dim ChildNode As TreeNode = Nothing

        Dim Icn As String
        Dim SaveBillID As Long = 0
        Dim SaveProcedureID As Long = 0
        Dim AttorneyInfo As String
        TreeViewBills.Nodes.Clear()
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        SQL =
            "SELECT  ISNULL(ServiceFrom, Bills.BillDate) AS ServiceFrom, ISNULL(ServiceTo, Bills.BillDate) AS ServiceTo, Bills.CopyFromBillID, Bills.SplitBillID, Bills.BillDate, BillProcedures.ProcName, BillProcedures.PatientProcedureID, BillProcedures.BillID, Bills.BillAmount, Bills.PaidAmount, (Bills.BillAmount-isnull(Bills.PaidAmount,0)) as Balance, Bills.BillStatusID, BillStatus.Description AS BillStatus, BillDiagnosis.ICDCode, BillDiagnosis.ICDDescription, Attorneys.CompanyName as AttorneyInfo, Bills.AttorneyDate"
        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            SQL &=
                " FROM  Bills INNER JOIN BillProcedures ON Bills.BillID = BillProcedures.BillID INNER JOIN BillStatus ON Bills.BillStatusID = BillStatus.BillStatusID LEFT OUTER JOIN  BillDiagnosis ON BillProcedures.BillID = BillDiagnosis.BillID AND BillProcedures.PatientProcedureID = BillDiagnosis.PatientProcedureID LEFT OUTER JOIN Attorneys on Bills.AttorneyCompanyID = Attorneys.CompanyID "
        Else
            SQL &=
                " FROM dbo.Bills LEFT OUTER JOIN BillDiagnosis ON BillDiagnosis.BillID = Bills.BillID INNER JOIN BillProcedures ON Bills.BillID = BillProcedures.BillID INNER JOIN BillStatus ON Bills.BillStatusID = BillStatus.BillStatusID LEFT OUTER JOIN Attorneys on Bills.AttorneyCompanyID = Attorneys.CompanyID "
        End If
        SQL &= " WHERE Bills.PatientID = " & ListViewPatients.SelectedItems(0).Tag
        SQL &= " ORDER BY Bills.BillID "
        Reader = gSQLGetDataReaderAsync(SQL).Result
        If Reader Is Nothing Then Exit Sub
        TreeViewBills.BeginUpdate()
        TreeViewBills.Nodes.Clear()
        Do Until Reader.Read = False
            If SaveBillID <> Reader("BillID").ToString Then
                SaveBillID = Reader("BillID").ToString
                SaveProcedureID = 0
                Icn = Reader("BillStatusID").ToString
                If IsNumeric(Reader("CopyFromBillID").ToString) Then
                    Icn = Icn & "1"
                End If
                If IsDBNull(Reader("AttorneyDate")) Then
                    AttorneyInfo = ""
                Else
                    AttorneyInfo = "      Attorney: " & Reader("AttorneyInfo").ToString & " " &
                                   CDate(Reader("AttorneyDate")).ToString("MM/dd/yyyy")
                End If
                ParentNode = TreeViewBills.Nodes.Add("K" & Reader("BillID").ToString,
                                                     "Bill#: " & Reader("BillID").ToString & "      BillDT: " &
                                                     CDate(Reader("BillDate")).ToString("MM/dd/yyyy") & "      DOS: [" &
                                                     CDate(Reader("ServiceFrom")).ToShortDateString & " - " &
                                                     CDate(Reader("ServiceTo").ToString).ToShortDateString &
                                                     "]      Billed: " &
                                                     CDbl(Val(Reader("BillAmount").ToString)).ToString("c") &
                                                     "      Paid:" &
                                                     CDbl(Val(Reader("PaidAmount").ToString)).ToString("c") &
                                                     "      Balance: " & CDbl(Reader("Balance")).ToString("c") &
                                                     "      Status: " & Reader("BillStatus").ToString &
                                                     AttorneyInfo, Icn, Icn)
                ParentNode.Tag = Reader("BillID").ToString
                ParentNode.ToolTipText = "Bill Status: " & Reader("BillStatus").ToString
                If IsNumeric(Reader("CopyFromBillID").ToString) Then
                    ParentNode.ToolTipText = ParentNode.ToolTipText & vbCrLf & "Bill ReProduced from the Bill Number: " &
                                             Reader("CopyFromBillID").ToString
                End If
            End If
            If SaveProcedureID <> Reader("PatientProcedureID").ToString Then
                SaveProcedureID = Reader("PatientProcedureID").ToString
                ChildNode = ParentNode.Nodes.Add("", Reader("ProcName").ToString, "PROC", "PROC")
                ChildNode.Tag = Reader("PatientProcedureID").ToString
            End If
            If Reader("ICDCode").ToString <> "" Then
                ChildNode.Nodes.Add("", Reader("ICDCode").ToString & "   " & Reader("ICDDescription").ToString, "DIAG",
                                    "DIAG")
            End If

        Loop
        Reader.Close()
        Reader.Dispose()
        For Each ParentNode In TreeViewBills.Nodes
            If ParentNode.Parent Is Nothing Then
                ParentNode.Expand()
            End If
        Next
        'TreeViewBills.ExpandAll()
        TreeViewBills.EndUpdate()
        If TreeViewBills.Nodes.Count > 0 Then
            TreeViewBills.SelectedNode = TreeViewBills.Nodes(0)
            TreeViewBills.TopNode = TreeViewBills.Nodes(0)
        End If
    End Sub

    Private Sub TreeViewBills_AfterSelect(ByVal sender As Object,
                                          ByVal e As TreeViewEventArgs) Handles TreeViewBills.AfterSelect

        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim pBillID As Long = 0
        If e.Node Is Nothing Then Exit Sub
        If e.Node.Parent Is Nothing Then
            pBillID = e.Node.Tag
        ElseIf e.Node.Parent.Parent Is Nothing Then
            pBillID = e.Node.Parent.Tag
        ElseIf e.Node.Parent.Parent.Parent Is Nothing Then
            pBillID = e.Node.Parent.Parent.Tag
        End If

        SQL =
            "SELECT     BillPayments.Note, BillPayments.PaymentDate, BillPaymentTypes.Description, BillPayments.PaymentAmount, BillPayments.CheckNumber "
        SQL &=
            " FROM         BillPayments LEFT OUTER JOIN BillPaymentTypes ON BillPayments.PaymentTypeID = BillPaymentTypes.PaymentTypeID "
        SQL &= " WHERE BillPayments.BillID = " & pBillID
        Reader = gSQLGetDataReaderAsync(SQL).Result
        If Reader Is Nothing Then
            MsgBox("Unexpected Error. Please call your system administrator.")
            Exit Sub
        End If
        ListViewPayments.Items.Clear()
        Do Until Reader.Read = False
            LI = ListViewPayments.Items.Add(pBillID)
            If IsDate(Reader("PaymentDate").ToString) Then
                LI.SubItems.Add(CDate(Reader("PaymentDate")).ToString("MM/dd/yyyy"))
            Else
                LI.SubItems.Add("")
            End If
            LI.SubItems.Add(Reader("Description").ToString)
            LI.SubItems.Add(Reader("CheckNumber").ToString)
            LI.SubItems.Add(CDbl(Reader("PaymentAmount").ToString).ToString("c"))
            LI.SubItems.Add(Reader("Note").ToString)

        Loop
        ListViewBillComments.Items.Clear()
        Reader =
            gSQLGetDataReaderAsync(
                "SELECT BillComments.CommentID, BillComments.BillID, BillComments.Comment, BillComments.InsertedBy, BillComments.InsertedDT, Employees.Fname +' '+Employees.Lname as EmpName FROM BillComments INNER JOIN Employees ON BillComments.InsertedBy = Employees.EmpID Where BillID = " &
                pBillID & "  order by InsertedDT Desc").Result
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            If IsDate(Reader("InsertedDT")) Then
                LI = ListViewBillComments.Items.Add(CDate(Reader("InsertedDT")).ToString("MM/dd/yy hh:mm"))
            Else
                LI = ListViewBillComments.Items.Add("")
            End If
            LI.SubItems.Add(Reader("EmpName").ToString)
            LI.ToolTipText = Reader("Comment").ToString
            LI.SubItems.Add(Reader("Comment").ToString)
        Loop
        gListViewRestoreDefaultColumnWidth(ListViewPayments)
        gListViewRestoreDefaultColumnWidth(ListViewBillComments)
    End Sub

    Private Sub ExpandAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExpandAllToolStripMenuItem.Click

        TreeViewBills.ExpandAll()
    End Sub

    Private Sub CollapsAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CollapsAllToolStripMenuItem.Click

        TreeViewBills.CollapseAll()
    End Sub

    Private Sub TimerLoad_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TimerLoad.Tick
        TimerLoad.Enabled = False
        If Not HideCalledForm Is Nothing Then
            Do Until Opacity >= 1
                Opacity = Opacity + 0.01
                Threading.Thread.Sleep(2)
                Application.DoEvents()
            Loop
            Do Until HideCalledForm.Opacity <= 0
                HideCalledForm.Opacity = HideCalledForm.Opacity - 0.02
                Threading.Thread.Sleep(2)
                Application.DoEvents()
            Loop
            HideCalledForm.Cursor = Cursors.Default
        End If
        On Error Resume Next
        ComboBoxSearchCaseStatus.Focus()
        TimerSearchFocus.Enabled = True
    End Sub

    Private Sub ComboBoxInsuranceCompanyID1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxInsuranceCompanyID1.TextChanged

    End Sub

    Private Sub ComboBoxInsuranceCompanyID_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxInsuranceCompanyID.TextChanged

        ComboBoxInsuranceCompanyID_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub cboBillingCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboBillingCompany.SelectedIndexChanged

        ErrorProvider1.SetError(cboBillingCompany, "")
    End Sub

    Private Sub txtEmail_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtEmail.TextChanged

    End Sub

    Private Sub ListViewReadings_ColumnClick(ByVal sender As Object,
                                             ByVal e As ColumnClickEventArgs) Handles ListViewReadings.ColumnClick

        Dim new_sorting_column As ColumnHeader = ListViewReadings.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As SortOrder
        If m_SortingColumnReadings Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumnReadings) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumnReadings.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumnReadings.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumnReadings.Text =             m_SortingColumnReadings.Text.Mid(2)
            m_SortingColumnReadings.ImageKey = "SORT0"
            m_SortingColumnReadings.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumnReadings = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumnReadings.Text = "> " & m_SortingColumnReadings.Text
        'Else
        'm_SortingColumnReadings.Text = "< " & m_SortingColumnReadings.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumnReadings.ImageKey = "SORT1"
        Else
            m_SortingColumnReadings.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewReadings.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewReadings.Sort()
    End Sub

    Private Sub ListViewReadings_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewReadings.SelectedIndexChanged

        Dim LI As ListViewItem
        Dim VD As ValueDescription

        gHighlightListviewItem(ListViewReadings, True, True)
        ToolStripButtonUnlockReading.Enabled = False
        If ListViewReadings.SelectedItems.Count = 0 Then
            TextBoxReading.Text = ""
            Exit Sub
        End If
        LI = ListViewReadings.SelectedItems(0)
        VD = CType(LI.Tag, ValueDescription)
        If Val(VD.Fld4) > 0 And LI.ImageIndex = 5 Then
            ToolStripButtonUnlockReading.Enabled = True
        End If
        TextBoxReading.Text = ListViewReadings.SelectedItems(0).SubItems(1).Tag
    End Sub

    Private Sub cmdAddReading_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddReading.Click

        Dim LI As ListViewItem
        Dim VD As ValueDescription
        If ListViewReadings.SelectedItems.Count = 0 Then
            MsgBox(
                "Unable to Add / Update reading. No procedure selected." & vbCrLf &
                "Add / Update Reading is allowed for the completted procedures only.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewReadings.SelectedItems(0)
        VD = CType(LI.Tag, ValueDescription)
        Dim frm As frmAddReading = New frmAddReading
        With frm
            .txtResultDescription.Text = VD.Fld1
            .txtResultDescription2.Text = VD.Fld2
            .PatientProcedureID = VD.Value
            .PatientID = VD.Fld3
            .ReadingID = Val(VD.Fld4)
            .ListViewReadings = ListViewReadings
            .txtProcedure.Text = LI.SubItems(1).Text
            .DoctorID = Val(LI.SubItems(2).Tag)
            .ScheduleDate = LI.Text
            .lblAuth.Visible = Val(VD.Fld4) > 0
            'LI.Tag = New ValueDescription(Reader("PatientProcedureID").ToString, "", "", Reader("ResultDescription").ToString, Reader("ResultDescription2").ToString, ListViewPatients.SelectedItems(0).Tag, Reader("ResultID").ToString)
            .ShowDialog(Me)
            ListViewReadings_SelectedIndexChanged(Nothing, Nothing)
        End With
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub TextBoxReading_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBoxReading.TextChanged

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButton4.Click

        Dim LI As ListViewItem
        Dim VD As ValueDescription
        Dim PatientProcedureID(0) As Long
        Dim Cnt As Long = -1
        Dim PatientID As Integer = 0
        If ListViewPatients.SelectedItems.Count > 0 Then PatientID = ListViewPatients.SelectedItems(0).Tag
        If ListViewReadings.SelectedItems.Count = 0 And ListViewReadings.CheckedItems.Count = 0 Then
            MsgBox(
                "Unable to produce the procedure(s) reading report." & Environment.NewLine &
                "No procedure(s) checked / selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewReadings.CheckedItems.Count > 0 Then
            For Each LIs In ListViewReadings.CheckedItems
                VD = CType(LIs.Tag, ValueDescription)
                If Val(VD.Fld4) <> 0 Then
                    Cnt = Cnt + 1
                    ReDim Preserve PatientProcedureID(Cnt)
                    PatientProcedureID(Cnt) = Val(VD.Value)
                End If
            Next
        Else
            LI = ListViewReadings.SelectedItems(0)
            VD = CType(LI.Tag, ValueDescription)

            If Val(VD.Fld4) = 0 Then
                MsgBox(
                    "Unable to produce the procedure reading report." & Environment.NewLine &
                    "The selected procedure does not have a reading.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            ReDim Preserve PatientProcedureID(0)
            PatientProcedureID(0) = Val(VD.Value)
            Cnt = 0
        End If
        Dim frm As frmReadingReport = New frmReadingReport
        If Cnt > -1 Then
            Using frm
                frm.Setup_report(PatientProcedureID, PatientID)
                frm.ShowDialog(Me)
                Load_Documents()
            End Using
        Else
            MsgBox(
                "Unable to produce the procedure(s) reading report." & Environment.NewLine &
                "Selected/Checked procedure(s) does not have a reading(s).", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub Label63_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label63.Click
    End Sub

    Private Sub Label37_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label37.Click
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TimerSearchFocus.Tick
        TimerSearchFocus.Enabled = False
        On Error Resume Next
        TextBoxSearch.Focus()
    End Sub

    Private Sub ButtonDeleteDocument_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonDeleteDocument.Click

        Dim Sql As String
        Dim ApprovedByName As String
        Dim PatientID As Long
        If ListViewDocs.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Dim LI = ListViewDocs.SelectedItems
        If OpMode <> AddEditMode.AddNew Then
            If gCurrentEmployee.PositionID > 3 Then
                Dim frm As frmSupervisorApproval = New frmSupervisorApproval
                If LI.Count = 1 Then
                    frm.LabelMsg.Text = "Delete Document: " & LI(0).Text
                Else
                    frm.LabelMsg.Text = "Delete " & LI.Count & " Documents"
                End If
                If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                    frm.Dispose()
                    frm = Nothing
                    Exit Sub
                End If
                ApprovedByName = frm.SupervisorName
                frm.Dispose()
                frm = Nothing
            Else
                Dim msg As String
                If LI.Count = 1 Then
                    msg = "Please confirm you want to delete " & LI(0).Text & "?"
                Else
                    msg = "Please confirm you want to delete " & LI.Count & " documents?"
                End If

                If MsgBox(msg, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                    Exit Sub
                End If
                ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
            End If
            For Each item As ListViewItem In LI
                gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Tag, PatientLogTypes.tDocumentDeleted, item.Text, ApprovedByName)
            Next
        End If

        If ListViewPatients.SelectedItems.Count > 0 And (OpMode = AddEditMode.None Or OpMode = AddEditMode.Edit) Then
            'cmdEdit_Click(Nothing, Nothing)
            PatientID = ListViewPatients.SelectedItems(0).Tag
        ElseIf OpMode = AddEditMode.None Then
            cmdAddNew_Click(Nothing, Nothing)
            PatientID = 0
        End If
        'Clear_Web_Document(pdfViewer)
        pdfViewer.CloseDocument()
        RichTextBox1.Text = ""
        Dim SQLAttorney As String
        For Each item As ListViewItem In LI
            If item.SubItems(1).Tag = 999 Then
                Dim doc As RTFDocument = CType(item.Tag, RTFDocument)
                Sql = "DELETE FROM PatientRTFDocuments Where ID=" & doc.ID
                SQLAttorney = "DELETE from AttorneyDocumentsAccess where AttorneyDocumentsAccess.DocumentID = " & doc.ID
            Else
                Sql = "DELETE FROM Documents Where DocumentID=" & item.Tag
                SQLAttorney = "DELETE from AttorneyDocumentsAccess where AttorneyDocumentsAccess.DocumentID = " & item.Tag
            End If

        Next
        If SQLAttorney.Length > 0 Then gSQLDeleteRecord(SQLAttorney)
        gSQLDeleteRecord(Sql)
        Dim Reader As SqlClient.SqlDataReader
        Dim PatIDS As String
        Dim PatMessage As String
        Dim PCount As Integer
        For Each item As ListViewItem In LI
            Dim ProfileID As Integer = item.SubItems(1).Tag
            If ProfileID = 7 And PatientID <> 0 Then ' Preauthorization
                gSQLUpdateData("Update Patients set PreAuthorizationDocID = 0 Where PatientID=" & PatientID)
            ElseIf ProfileID = 11 And PatientID > 0 Then
                If _
                        gSQLGetSingleValue(
                            "Select Count(*) from Documents Where PatientId = " & PatientID & " and DocumentProfileID= 11") = 0 _
                        Then
                    gSQLUpdateData("Update Patients set InitialReportReceived = 0 Where PatientID=" & PatientID)
                    chkInitialReportReceived.ForeColor = Color.Red
                End If
            ElseIf ProfileID = 4 Then  'Police Report
                If _
                        gSQLGetSingleValue(
                            "Select Count(*) from Documents Where PatientId = " & PatientID & " and DocumentProfileID= 4") = 0 _
                        Then
                    gSQLUpdateData("Update Patients set PoliceReportReceived = 0 Where PatientID=" & PatientID)
                    chkPoliceReportReceived.Tag = 0
                    chkPoliceReportReceived.Checked = False
                    chkPoliceReportReceived.ForeColor = Color.Red
                End If
                Sql =
                        "SELECT PatientAccidentGroups.PatientID FROM PatientAccidentGroups INNER JOIN PatientAccidentGroups AS PatientAccidentGroups_1 ON PatientAccidentGroups.GroupID = PatientAccidentGroups_1.GroupID "
                Sql &= " WHERE PatientAccidentGroups_1.PatientID = " & PatientID &
                           " AND PatientAccidentGroups.PatientID <> " & PatientID &
                           " AND PatientAccidentGroups.PatientID IN (SELECT PatientID FROM Documents WHERE DocumentProfileID = 4 OR DocumentName = 'Police Report')"
                Reader = gSQLGetDataReaderAsync(Sql).Result
                If Reader.HasRows Then
                    Do Until Reader.Read = False
                        PatMessage = PatIDS & "Patient#: " & Reader("PatientID").ToString & ", " &
                                         gSQLGetSingleValueString(
                                             "SELECT rtrim(FName)+' '+rtrim(MI)+' '+rtrim(Lname)+' '+rtrim(Suffix) as PatName From Patients WHERE PAtientID=" &
                                             Reader("PatientID").ToString).ToString.Trim.Replace("  ", " ") & vbCrLf
                        PatIDS = PatIDS & ", " & Reader("PatientID").ToString
                        PCount = PCount + 1
                    Loop
                End If
                If PatIDS <> "" Then
                    PatIDS = PatIDS.Mid(2)
                    gSQLDeleteRecord(
                            "DELETE FROM Documents WHERE (DocumentProfileID = 4 OR DocumentName = 'Police Report') and PatientID in(" &
                            PatIDS & ")")
                    gSQLUpdateData("Update Patients set PoliceReportReceived = 0 Where PatientID in(" & PatIDS & ")")

                    If PCount = 1 Then
                        MsgBox(
                                "The Police Report image has been deleted from the" & vbCrLf &
                                "following Accident Related Patient: " & vbCrLf & vbCrLf & PatMessage, MsgBoxStyle.Exclamation)
                    Else
                        MsgBox(
                                "The Police Report image has been deleted from the" & vbCrLf &
                                "following Accident Related Patients:" & vbCrLf & vbCrLf & PatMessage, MsgBoxStyle.Exclamation)
                    End If

                End If
            End If
            Dim SaveIndex As Integer = item.Index
            ListViewDocs.Items.Remove(item)

        Next

        'Clear_Web_Document(pdfViewer)
        pdfViewer.CloseDocument()
        If ListViewDocs.Items.Count > 0 Then
            ListViewDocs.Items(0).Selected = True
            ListViewDocs.Items(0).EnsureVisible()
        End If
    End Sub

    Private Sub ScanDocumentFromScanner(ByVal DocProfileID As Integer)
        Dim PatientID As Long

        If ListViewPatients.SelectedItems.Count > 0 And (OpMode = AddEditMode.None Or OpMode = AddEditMode.Edit) Then
            'cmdEdit_Click(Nothing, Nothing)
            PatientID = ListViewPatients.SelectedItems(0).Tag
        ElseIf OpMode = AddEditMode.None Then
            cmdAddNew_Click(Nothing, Nothing)
            PatientID = 0
        End If
        Dim frm As frmDocumentScannerPDF = New frmDocumentScannerPDF
        frm.PoliceReportCheck = chkPoliceReportReceived
        frm.InitialReportCheck = chkInitialReportReceived
        frm.IniDocProfile = DocProfileID
        frm.PatientID = PatientID
        frm.LoadListView = ListViewDocs
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If OpMode = AddEditMode.None And ListViewPatients.SelectedItems.Count > 0 Then
                gSQLUpdateData(
                    "UPDATE Documents set PatientID = " & ListViewPatients.SelectedItems(0).Tag &
                    " where PatientID=0 and InsertedBy=" & gCurrentEmployee.EmpID)
            End If
        End If
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub ScanDocumentFromScannerApplication(ByVal DocProfileID As Integer)
        Dim PatientID As Long

        If ListViewPatients.SelectedItems.Count > 0 And (OpMode = AddEditMode.None Or OpMode = AddEditMode.Edit) Then
            'cmdEdit_Click(Nothing, Nothing)
            PatientID = ListViewPatients.SelectedItems(0).Tag
        ElseIf OpMode = AddEditMode.None Then
            cmdAddNew_Click(Nothing, Nothing)
            PatientID = 0
        End If

        If gScannerFolder = "" Then
            MsgBox(
                "Unable to scan. The Scanner Folder has not been specified." & vbCrLf &
                "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If IO.Directory.Exists(gScannerFolder) = False Then
            MsgBox(
                "Unable to scan. Invalid Scanner Folder specified." & vbCrLf & "Please call your system administrator.",
                MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Using frm As frmDocumentScannerExternalProgram = New frmDocumentScannerExternalProgram

            frm.IniDocProfile = DocProfileID
            frm.PoliceReportCheck = chkPoliceReportReceived
            frm.InitialReportCheck = chkInitialReportReceived
            frm.PatientID = PatientID
            frm.LoadListView = ListViewDocs
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                If OpMode = AddEditMode.None And ListViewPatients.SelectedItems.Count > 0 Then
                    gSQLUpdateData(
                    "UPDATE Documents set PatientID = " & ListViewPatients.SelectedItems(0).Tag &
                    " where PatientID=0 and InsertedBy=" & gCurrentEmployee.EmpID)
                End If
            End If
            frm.DisposeExplorer()
            frm.Dispose()
        End Using
        GC.Collect()
    End Sub

    Private Sub ListViewPayments_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewPayments.SelectedIndexChanged

        gHighlightListviewItem(ListViewPayments, True, True)
    End Sub

    Private Sub ListViewBillComments_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewBillComments.SelectedIndexChanged

        gHighlightListviewItem(ListViewBillComments, True, True)
    End Sub

    Private Sub ListViewCancelations_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewCancelations.SelectedIndexChanged

        gHighlightListviewItem(ListViewCancelations, True, True)
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PictureBoxRefDoctor.Click, PictureBoxRefCompany.Click

        If ComboBoxReferringCompanyID.SelectedIndex = -1 Then Exit Sub
        Dim frm As frmPatirntInformationRefferedCompanyInfo = New frmPatirntInformationRefferedCompanyInfo
        If _
            frm.Show_CompanyInformation(
                CType(ComboBoxReferringCompanyID.SelectedItem, ValueDescription).Value) Then
            frm.ShowDialog(Me)
        End If
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub ComboBoxSearchCaseType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxSearchCaseType.SelectedIndexChanged

        If SkipSearch Then Exit Sub
        Load_Patients()
        If ListViewPatients.Items.Count = 0 Then
            LabelFound.Text = ""
        Else
            LabelFound.Text = "Found: " & ListViewPatients.Items.Count
        End If
        TextBoxSearch.Focus()
    End Sub

    Public SavePatientInsCompanyID As Integer
    Public SavePatientTypeID As Integer
    Public SavePatientInsCompanyID1 As Integer
    Public TimerDetailsRunning As Boolean

    Private Sub TimerDetails_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TimerDetails.Tick
        Dim ID As Long
        Dim Reader As SqlClient.SqlDataReader
        If Loading Then Exit Sub
        TimerDetails.Enabled = False
        imgWait1.Visible = True
        If OpMode = AddEditMode.None Then
            Clear_Controls()
        End If
        imgWait1.Refresh()
        LoadingData = True
        Do Until TimerDetailsRunning = False
            Application.DoEvents()
        Loop
        SavePatientInsCompanyID = 0
        SavePatientTypeID = 0
        TimerDetailsRunning = True
        txtAddress1.Tag = ""
        LastLoadedTab(0) = 0
        LastLoadedTab(1) = 0
        LastLoadedTab(2) = 0
        LastLoadedTab(3) = 0
        LastLoadedTab(4) = 0
        LastLoadedTab(5) = 0
        LastLoadedTab(6) = 0
        LastLoadedTab(7) = 0
        LastLoadedTab(8) = 0
        LastLoadedTab(9) = 0
        LastLoadedTab(10) = 0
        LabelPreCertification.Visible = False
        If ListViewPatients.SelectedItems.Count = 0 Then
            imgWait1.Visible = False
            Validate_Billing_Data(True)
            TimerDetailsRunning = False
            Exit Sub
        End If
        If KeyDn = True Then TimerDetailsRunning = False : Exit Sub

        Loading = True

        'Try
        'LockWindowUpdate(Handle)
        'Validate_Billing_Data(True)
        txtDOB.ForeColor = Color.Black
        LabelDOB.ForeColor = Color.Black
        LabelDOB.Text = "DOB"
        lblNoMoreAppointmentsInd.ForeColor = Color.Black
        cmdEdit.Enabled = True
        cmdDelete.Enabled = True
        ID = CLng(ListViewPatients.SelectedItems(0).Tag)
        SavePatientInsCompanyID = -1
        SavePatientInsCompanyID1 = -1
        ComboBoxClaimAddress.Items.Clear()
        ToolStripButtonUnlockReading.Enabled = False
        SaveSelectedItem = ListViewPatients.SelectedItems(0)
        Reader =
            gSQLGetDataReaderAsync(
                "Select Patients.*, Employees.FName +' '+ Employees.LName as UpdatedBy from Patients LEFT OUTER JOIN Employees on Patients.UpdatedByEmpID = Employees.EmpID Where PatientID=" &
                ID).Result
        'If Reader Is Nothing Then LockWindowUpdate(0) : Exit Sub
        TabControl1.SuspendLayout()
        If Reader Is Nothing Then TimerDetailsRunning = False : Exit Sub
        If Reader.HasRows = False Then TimerDetailsRunning = False : Exit Sub
        Reader.Read()
        txtVehicleOwner.Text = Reader("VehicleOwner").ToString
        txtPlaceOfAccident.Text = Reader("PlaceOfAccident").ToString
        If IsDate(Reader("TOA").ToString) Then txtTOA.Text = CDate(Reader("TOA").ToString).ToString("HH:mm")
        cboInjury.Text = Reader("Injury").ToString
        txtPatientID.Text = Reader("PatientID").ToString
        txtInsertedDT.Text = CDate(Reader("InsertedDT").ToString).ToString("MM/dd/yy")
        If IsDate(Reader("CaseStatusDate").ToString) Then
            txtCaseStatusDT.Text = CDate(Reader("CaseStatusDate").ToString).ToString("MM/dd/yy")
        Else
            txtCaseStatusDT.Text = ""
        End If
        gFindComboItemByValue(ComboBoxCaseStatusID, CLng(Val(Reader("CaseStatusID").ToString)), True)
        SaveCaseStatusID = CInt(Val(Reader("CaseStatusID").ToString))

        TextBoxWebUid.Text = "PNT" & Reader("PatientID").ToString
        TextBoxWebPassword.Text = Reader("WebPassword").ToString

        txtFName.Text = Reader("FName").ToString
        txtMI.Text = Reader("MI").ToString
        txtLName.Text = Reader("LName").ToString
        cboSuffix.Text = Reader("Suffix").ToString
        If IsDate(Reader("DOB").ToString) Then txtDOB.Text = CDate(Reader("DOB").ToString).ToString("MM/dd/yyyy")
        ComboBoxSex.Text = Reader("Sex").ToString
        txtSSN.Text = Reader("SSN").ToString
        txtAddress1.Text = Reader("Address1").ToString
        txtAddress2.Text = Reader("Address2").ToString
        txtCity.Text = Reader("City").ToString
        ComboBoxState.Text = Reader("State").ToString
        ComboBoxStateOfAccident.Text = Reader("StateOfAccident").ToString
        txtZip.Text = Reader("Zip").ToString
        txtPhone1.Text = Reader("Phone1").ToString
        txtPhone2.Text = Reader("Phone2").ToString
        txtCellPhone.Text = Reader("CellPhone").ToString
        txtEmail.Text = Reader("Email").ToString
        txtComments.Text = Reader("Comments").ToString

        gFindComboItemByValue(ComboBoxCaseTypeID, CLng(Val(Reader("CaseTypeID").ToString)), True)


        CheckBoxNoMoreAppointmentsInd.Tag = CBool(Val(Reader("NoMoreAppointmentsInd").ToString))
        chkInitialReportReceived.Checked = CBool(Val(Reader("InitialReportReceived").ToString))
        chkInitialReportReceived.ForeColor = IIf(chkInitialReportReceived.Checked, Color.Black, Color.Red)
        chkPoliceReportReceived.Tag = Val(Reader("PoliceReportReceived").ToString)
        chkPoliceReportReceived.Checked = CBool(Val(Reader("PoliceReportReceived").ToString))
        chkPoliceReportReceived.ForeColor = IIf(chkPoliceReportReceived.Checked, Color.Black, Color.Red)
        'CheckBoxAtWorkTime.Checked = CBool(Val(Reader("AtWorkTime").ToString))
        gFindComboItemByValue(ComboBoxMaritalStatusID, CLng(Val(Reader("MaritalStatusID").ToString)), True)
        gFindComboItemByValue(ComboBoxEmploymentStatusID, CLng(Val(Reader("EmploymentStatusID").ToString)), True)
        txtOccupation.Text = Reader("Occupation").ToString
        txtEmployerName.Text = Reader("EmployerName").ToString
        txtEmployerAddress.Text = Reader("EmployerAddress").ToString
        txtEmployerAddressCity.Text = Reader("EmployerAddressCity").ToString
        cboEmployerAddressState.Text = Reader("EmployerAddressState").ToString
        txtEmployerAddressZip.Text = Reader("EmployerAddressZip").ToString

        txtEmployerPhone.Text = Reader("EmployerPhone").ToString
        If IsDate(Reader("DOA").ToString) Then txtDOA.Text = CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy")
        If IsDate(Reader("ClaimEffectiveDT").ToString) Then _
            txtClaimEffectiveDT.Text = CDate(Reader("ClaimEffectiveDT").ToString).ToString("MM/dd/yyyy")
        txtClaimNumber.Text = Reader("ClaimNumber").ToString
        txtClaimNumber1.Text = Reader("ClaimNumber1").ToString

        txtPolicyHolderSSN.Text = Reader("PolicyHolderSSN").ToString
        txtPolicyHolderSSN1.Text = Reader("PolicyHolderSSN1").ToString

        txtPolicyHolderEmployerName.Text = Reader("PolicyHolderEmployerName").ToString
        txtPolicyHolderEmployerName1.Text = Reader("PolicyHolderEmployerName1").ToString

        txtPolicyHolderEmployerAddress.Text = Reader("PolicyHolderEmployerAddress").ToString
        txtPolicyHolderEmployerAddress1.Text = Reader("PolicyHolderEmployerAddress1").ToString

        txtPolicyHolderOccupation.Text = Reader("PolicyHolderOccupation").ToString
        txtPolicyHolderOccupation1.Text = Reader("PolicyHolderOccupation1").ToString

        txtPolicyHolderEmployerPhone.Text = Reader("PolicyHolderEmployerPhone").ToString
        txtPolicyHolderEmployerPhone1.Text = Reader("PolicyHolderEmployerPhone1").ToString

        txtPolicyHolderOtherDependents.Text = Reader("PolicyHolderOtherDependents").ToString
        txtPolicyHolderOtherDependents1.Text = Reader("PolicyHolderOtherDependents1").ToString

        If IsDate(Reader("PolicyHolderBirthDate").ToString) Then _
            txtPolicyHolderBirthDate.Text = CDate(Reader("PolicyHolderBirthDate").ToString).ToString("MM/dd/yyyy")
        If IsDate(Reader("PolicyHolderBirthDate1").ToString) Then _
            txtPolicyHolderBirthDate1.Text = CDate(Reader("PolicyHolderBirthDate1").ToString).ToString("MM/dd/yyyy")

        cboPatientAttorney.Text = Reader("Attorney").ToString
        txtEmergencyInfo.Text = Reader("EmergencyInfo").ToString
        gFindComboItemByValue(ComboBoxInjuryID, CLng(Val(Reader("InjuryID").ToString)), True)
        gFindComboItemByValue(ComboBoxPatientTypeID, CLng(Val(Reader("PatientTypeID").ToString)), True)
        If ComboBoxPatientTypeID.SelectedIndex > -1 Then
            SavePatientTypeID = CLng(Val(Reader("PatientTypeID").ToString))
        End If
        gFindComboItemByValue(ComboBoxReferringCompanyID, CLng(Val(Reader("ReferringCompanyID").ToString)), True)
        ComboBoxReferringCompanyID.Tag = CLng(Val(Reader("ReferringCompanyID").ToString))
        ComboBoxReferringDoctor.SelectedIndex = gFindComboItemByDescription(ComboBoxReferringDoctor, Reader("ReferringDoctor").ToString.Trim, True)
        If ComboBoxReferringDoctor.SelectedIndex = -1 Then
            ComboBoxReferringDoctor.Text = Reader("ReferringDoctor").ToString.Trim
        End If
        gFindComboItemByValue(ComboBoxTransportationCompanyID, CLng(Val(Reader("TransportationCompanyID").ToString)),
                              True)

        'txtUpdatedDT.Text = CDate(Reader("UpdatedDT").ToString).ToString("MM/dd/yy")
        gFindComboItemByValue(ComboBoxPatientTypeID, CLng(Val(Reader("PatientTypeID").ToString)), True)

        'INSURANCE COMPANY / CLAIM
        'Primary Insurance
        gFindComboItemByValue(cboBillingCompany, CLng(Val(Reader("BillingCompanyID").ToString)), True)

        gFindComboItemByValue(ComboBoxCaseTypeID, CLng(Val(Reader("CaseTypeID").ToString)), True)

        SaveCasyTypeID = CLng(Val(Reader("CaseTypeID").ToString))

        gFindComboItemByValue(ComboBoxInsuranceCompanyID, CLng(Val(Reader("InsuranceCompanyID").ToString)), True)
        If ComboBoxInsuranceCompanyID.SelectedIndex > -1 Then _
            SavePatientInsCompanyID = CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Value

        txtPolicyNumber.Text = Reader("PolicyNumber").ToString
        txtIDNumber.Text = Reader("IDNumber").ToString
        txtGroupNumber.Text = Reader("GroupNumber").ToString

        txtPolicyHolderFName.Text = Reader("PolicyHolderFName").ToString
        txtPolicyHolderMI.Text = Reader("PolicyHolderMI").ToString
        txtPolicyHolderLName.Text = Reader("PolicyHolderLName").ToString
        txtPolicyHolderAddress.Text = Reader("PolicyHolderAddress").ToString
        txtPolicyHolderCity.Text = Reader("PolicyHolderCity").ToString
        ComboBoxPolicyHolderState.Text = Reader("PolicyHolderState").ToString
        txtPolicyHolderZip.Text = Reader("PolicyHolderZip").ToString
        txtPolicyHolderPhone.Text = Reader("PolicyHolderPhone").ToString

        txtAdjuster.Text = Reader("AdjusterName").ToString
        txtAdjusterPhone.Text = Reader("AdjusterPhone").ToString
        txtAdjusterComments.Text = Reader("AdjusterComments").ToString

        'Secondary Insurance
        gFindComboItemByValue(ComboBoxInsuranceCompanyID1, CLng(Val(Reader("InsuranceCompanyID1").ToString)), True)
        If ComboBoxInsuranceCompanyID1.SelectedIndex > -1 Then _
            SavePatientInsCompanyID1 = CType(ComboBoxInsuranceCompanyID1.SelectedItem, ValueDescription).Value
        txtPolicyNumber1.Text = Reader("PolicyNumber1").ToString
        txtIDNumber1.Text = Reader("IDNumber1").ToString
        txtGroupNumber1.Text = Reader("GroupNumber1").ToString
        gFindComboItemByValue(ComboBoxRelationToInsuredID1, CLng(Val(Reader("RelationToInsuredID1").ToString)), True)
        txtPolicyHolderFName1.Text = Reader("PolicyHolderFName1").ToString
        txtPolicyHolderMI1.Text = Reader("PolicyHolderMI1").ToString
        txtPolicyHolderLName1.Text = Reader("PolicyHolderLName1").ToString
        txtPolicyHolderAddress1.Text = Reader("PolicyHolderAddress1").ToString
        txtPolicyHolderCity1.Text = Reader("PolicyHolderCity1").ToString

        txtAdjuster1.Text = Reader("AdjusterName1").ToString
        txtAdjusterPhone1.Text = Reader("AdjusterPhone1").ToString
        txtAdjusterComments1.Text = Reader("AdjusterComments1").ToString

        ComboBoxPolicyHolderState1.Text = Reader("PolicyHolderState1").ToString
        txtPolicyHolderZip1.Text = Reader("PolicyHolderZip1").ToString
        txtPolicyHolderPhone1.Text = Reader("PolicyHolderPhone1").ToString
        CheckBoxNoMoreAppointmentsInd.Checked = CBool(Val(Reader("NoMoreAppointmentsInd").ToString))
        CheckBoxInsuranceVerifyed.Checked = CBool(Val(Reader("InsuranceVerifyed").ToString))
        CheckBoxInsurance1Verifyed.Checked = CBool(Val(Reader("Insurance1Verifyed").ToString))

        txtWCCarrierCaseNumber.Text = Reader("WCCarrierCaseNumber").ToString
        txtWCCarrierCode.Text = Reader("WCCarrierCode").ToString
        txtWCCaseNumber.Text = Reader("WCCaseNumber").ToString
        txtWCPatientAccountNumber.Text = Reader("WCPatientAccountNumber").ToString
        txtWCEmployerInsuranceCarrier.Text = Reader("WCEmployerInsuranceCarrier").ToString
        txtWCInsuranceCarrierAddress.Text = Reader("WCInsuranceCarrierAddress").ToString
        txtWCInsuranceCarrierAddressCity.Text = Reader("WCInsuranceCarrierAddressCity").ToString
        cboWCInsuranceCarrierAddressState.Text = Reader("WCInsuranceCarrierAddressState").ToString
        txtWCInsuranceCarrierAddressZip.Text = Reader("WCInsuranceCarrierAddressZip").ToString

        'If Reader("LockedByIP").ToString <> "" And CInt(Val(Reader("LockByID").ToString)) <> gCurrentEmployee.EmpID Then
        '    If gPing(Reader("LockedByIP").ToString) = True Then
        '        lblLocked.Text = "Profile Readonly. Locked On " & CDate(Reader("LockDT").ToString).ToString("MM/dd/yyyy hh:mm") & "  By: " & Reader("LockedByName").ToString
        '        lblLocked.Visible = True
        '    Else
        '        lblLocked.Visible = False
        '    End If
        'End If
        LabelEffectiveDate.ForeColor = Color.Black
        If IsDate(Reader("ClaimEffectiveDT").ToString) And IsDate(Reader("DOA").ToString) Then
            If CDate(Reader("ClaimEffectiveDT").ToString) >= CDate(Reader("DOA").ToString) Then
                LabelEffectiveDate.ForeColor = Color.IndianRed
            End If
        End If

        gFindComboItemByValue(ComboBoxClaimAddress, CLng(Val(Reader("ClaimAddressID").ToString)), True)
        ComboBoxClaimAddress.Tag = Val(Reader("ClaimAddressID").ToString)

        gFindComboItemByValue(ComboBoxClaimAddress1, CLng(Val(Reader("ClaimAddressID1").ToString)), True)
        ComboBoxClaimAddress1.Tag = Val(Reader("ClaimAddressID1").ToString)

        If IsDate(Reader("NF2Date").ToString) And Reader("NF2Date").ToString <> "" Then
            chkNF2.Checked = True
            txtNF2.Text = CDate(Reader("NF2Date").ToString).ToString("MM/dd/yy")
        Else
            chkNF2.Checked = False
            txtNF2.Text = ""
        End If

        If IsDate(txtDOB.Text) Then
            If gYearsFromDate(txtDOB.Text) < gUnderAge Then
                LabelDOB.ForeColor = Color.IndianRed
                LabelDOB.Text = "DOB Underage"
                txtDOB.ForeColor = Color.IndianRed
            Else
                LabelDOB.ForeColor = Color.Black
                LabelDOB.Text = "DOB"
                txtDOB.ForeColor = Color.Black
            End If
        Else
            LabelDOB.ForeColor = Color.Black
            LabelDOB.Text = "DOB"
            txtDOB.ForeColor = Color.Black
        End If
        gFindComboItemByValue(ComboBoxCaseTypeID, CLng(Val(Reader("CaseTypeID").ToString)), True)
        SaveCasyTypeID = CLng(Val(Reader("CaseTypeID").ToString))
        If Val(CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value) <> 3 Then 'Private
            txtDOA.AccessibleDescription = "1"
            txtSSN.AccessibleDescription = ""
        Else
            txtDOA.AccessibleDescription = ""
            txtSSN.AccessibleDescription = "1"
        End If

        Load_PatientProcedures()
        gFindComboItemByValue(ComboBoxRelationToInsuredID1, CLng(Val(Reader("RelationToInsuredID1").ToString)), True)
        gFindComboItemByValue(ComboBoxRelationToInsuredID, CLng(Val(Reader("RelationToInsuredID").ToString)), True)
        'Try to speedup load
        'If ID = CLng(ListViewPatients.SelectedItems(0).Tag) Then
        '    'Load_Documents()
        '    Load_Documents(True)
        '    Load_Patient_Log()
        '    If gCurrentEmployee.PositionID <> 4 And gCurrentEmployee.PositionID <> 10 Then
        '        Load_Parient_Bills()
        '    End If
        '    Load_Readings()
        '    Load_Cancelations()
        '    Load_Requests()
        '    Load_RelatedPatients()
        '    Load_IME()
        '    Load_Photo()
        'End If
        'ComboBoxCaseTypeID_SelectedIndexChanged(Nothing, Nothing)
        TabControl1_SelectedIndexChanged(Nothing, Nothing)
        Validate_Billing_Data()
        Loading = False
        TabControl1.ResumeLayout()
        imgWait1.Visible = False
        If ListViewProcedures.Columns.Count = 0 Then
            Load_ProcedureColumns()
        End If
        If ListViewProcedures.Columns.Count > 0 Then
            pr_SortingColumn = ListViewProcedures.Columns(0)
            For Each CLMN As ColumnHeader In ListViewProcedures.Columns
                CLMN.ImageKey = "SORT0"
            Next
            ListViewProcedures.Columns(0).ImageKey = "SORT1"
            ListViewProcedures.ListViewItemSorter = New ListViewComparer(0, SortOrder.Ascending)
            ListViewProcedures.Sort()

        End If
        gListViewRestoreDefaultColumnWidth(ListViewPatientsRelated)
        gListViewRestoreDefaultColumnWidth(ListViewProcedures)

        If gSQLGetValue("SELECT count(*) FROM Bills WHERE PatientID =  " & ID) > 0 Then
            If gSQLGetValue("SELECT count(*) FROM Bills WHERE NoMoreCollection = 0 and PatientID =  " & ID) = 0 Then
                CheckBoxNoMoreCollection.Checked = True
            Else
                CheckBoxNoMoreCollection.Checked = False
            End If
        End If
        CheckBoxNoMoreCollection.Tag = IIf(CheckBoxNoMoreCollection.Checked, 1, 0)
        If gCurrentEmployee.PositionID < 3 Then
            CheckBoxNoMoreCollection.Enabled = False
        End If



        LoadingData = False
        TimerDetailsRunning = False
    End Sub

    Public Sub Load_ProcedureColumns()
        ListViewProcedures.Columns.Clear()
        Select Case gOfficeTypeID
            Case 1 ' NY RADIOLOGY
                ListViewProcedures.Columns.Add("Schedule DT").ImageKey = "SORT1"
                ListViewProcedures.Columns.Add("Procedure").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Treating Provider").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Billing Provider").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Ref Doctor").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Type").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Comments").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Accession #").ImageKey = "SORT0"
                ListViewProcedures.Columns(0).DisplayIndex = 0
                ListViewProcedures.Columns(5).DisplayIndex = 1
                ListViewProcedures.Columns(1).DisplayIndex = 2
                ListViewProcedures.Columns(2).DisplayIndex = 3
                ListViewProcedures.Columns(3).DisplayIndex = 4
                ListViewProcedures.Columns(4).DisplayIndex = 5
                ListViewProcedures.Columns(6).DisplayIndex = 6
                ListViewProcedures.Columns(7).DisplayIndex = 7
                ListViewProcedures.Columns(7).TextAlign = HorizontalAlignment.Right
            Case 3 'NJ RADIOLOGY
                ListViewProcedures.Columns.Add("Schedule DT").ImageKey = "SORT1"
                ListViewProcedures.Columns.Add("Procedure").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Treating Provider").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Billing Provider").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Ref Doctor").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Type").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Comments").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Accession #").ImageKey = "SORT0"
                ListViewProcedures.Columns.Add("Pre-Cert DT").ImageKey = "SORT0"
                ListViewProcedures.Columns(0).DisplayIndex = 0
                ListViewProcedures.Columns(5).DisplayIndex = 2
                ListViewProcedures.Columns(1).DisplayIndex = 3
                ListViewProcedures.Columns(2).DisplayIndex = 4
                ListViewProcedures.Columns(3).DisplayIndex = 5
                ListViewProcedures.Columns(4).DisplayIndex = 6
                ListViewProcedures.Columns(6).DisplayIndex = 7
                ListViewProcedures.Columns(7).DisplayIndex = 8
                ListViewProcedures.Columns(7).TextAlign = HorizontalAlignment.Right
                ListViewProcedures.Columns(8).DisplayIndex = 1
        End Select
    End Sub

    Private Async Function Load_Photo() As Task(Of Image)
        Dim Reader As SqlClient.SqlDataReader
        Dim img As Image
        Dim PatientID As Integer = ListViewPatients.SelectedItems(0).Tag
        Reader = gSQLGetDataReaderAsync("SELECT ID, PatientPhoto FROM PatientPhotos Where PatientID=" & PatientID).Result
        picPhoto.Tag = ""
        If Reader.HasRows Then
            Reader.Read()
            If Reader("PatientPhoto") Is DBNull.Value Then
                img = Nothing
            Else
                Dim arrayImage() As Byte = CType(Reader("PatientPhoto"), Byte())
                Dim ms As New IO.MemoryStream(arrayImage)
                img = Image.FromStream(ms)
            End If
        Else
            img = Nothing
        End If
        Return img
    End Function

    'Private Sub Load_Photo()
    '    Dim Reader As SqlClient.SqlDataReader
    '    Dim PatientID As Integer = ListViewPatients.SelectedItems(0).Tag
    '    Reader = gSQLGetDataReaderAsync("SELECT ID, PatientPhoto FROM PatientPhotos Where PatientID=" & PatientID).Result
    '    picPhoto.Tag = ""
    '    If Reader.HasRows Then
    '        Reader.Read()
    '        If Reader("PatientPhoto") Is DBNull.Value Then
    '            picPhoto.Image = Nothing
    '            ToolStripButtonPreview.Enabled = False
    '            ToolStripButtonPrintPhotoLabel.Enabled = False
    '        Else
    '            Dim arrayImage() As Byte = CType(Reader("PatientPhoto"), Byte())
    '            Dim ms As New IO.MemoryStream(arrayImage)
    '            picPhoto.Image = Image.FromStream(ms)
    '            picPhoto.Refresh()
    '            picPhoto.Refresh()
    '            Application.DoEvents()
    '            ToolStripButtonPreview.Enabled = True
    '            ToolStripButtonPrintPhotoLabel.Enabled = True

    '        End If
    '    Else
    '        picPhoto.Image = Nothing
    '        ToolStripButtonPreview.Enabled = False
    '        ToolStripButtonPrintPhotoLabel.Enabled = False
    '    End If
    'End Sub

    Private Sub Load_IME()
        Dim SQL As String
        Dim PatientID As Integer = ListViewPatients.SelectedItems(0).Tag
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim ScheduledFound As Boolean
        ListViewIME.Items.Clear()
        SQL =
            " SELECT     InsuranceExaminations.ID, InsuranceExaminations.ScheduleDate, InsuranceExaminationsTypes.Description AS Type, InsuranceExaminationStatuses.Description AS Status, InsuranceExaminations.AddressComments, InsuranceExaminationStatuses.StatusID "
        SQL &=
            " FROM         InsuranceExaminations INNER JOIN InsuranceExaminationsTypes ON InsuranceExaminations.TypeID = InsuranceExaminationsTypes.TypeID INNER JOIN InsuranceExaminationStatuses ON InsuranceExaminations.StatusID = InsuranceExaminationStatuses.StatusID "
        SQL &= " WHERE InsuranceExaminations.PatientID = " & PatientID
        SQL &= " ORDER BY InsuranceExaminations.ScheduleDate "
        Reader = gSQLGetDataReaderAsync(SQL).Result
        If Reader Is Nothing Then Exit Sub
        ListViewIME.ListViewItemSorter = Nothing
        Do Until Reader.Read = False
            LI = ListViewIME.Items.Add(Reader("Type").ToString)
            If IsDate(Reader("ScheduleDate").ToString) Then
                LI.SubItems.Add(CDate(Reader("ScheduleDate").ToString))
            Else
                LI.SubItems.Add("")
            End If
            LI.SubItems.Add(Reader("Status").ToString)
            LI.SubItems.Add(Reader("AddressComments").ToString)
            LI.Tag = Val(Reader("ID").ToString)
            LI.SubItems(2).Tag = Val(Reader("StatusID").ToString)
            If Val(Reader("StatusID").ToString) = 1 Or Val(Reader("StatusID").ToString) = 2 Then
                ScheduledFound = True
            End If
        Loop
        If ListViewIME.Items.Count > 0 Then
            ListViewIME.Items(0).Selected = True
            If ScheduledFound Then
                TabPageExamination.ImageIndex = 1
                LabelIME.Text = "ATTENTION! IME/EUO SCHEDULED"
            Else
                TabPageExamination.ImageIndex = 0
                LabelIME.Text = ""
            End If
        Else
            TabPageExamination.ImageIndex = -1
            LabelIME.Text = ""
        End If
        gListViewRestoreDefaultColumnWidth(ListViewIME)
    End Sub

    Private Sub Load_RelatedPatients()
        Dim SQL As String
        Dim PatientID As Long
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        ListViewPatientsRelated.BeginUpdate()
        ListViewPatientsRelated.Items.Clear()
        If ListViewPatients.SelectedItems.Count = 0 Then
            ListViewPatientsRelated.EndUpdate()
            Exit Sub
        End If
        PatientID = ListViewPatients.SelectedItems(0).Tag
        SQL =
            " SELECT DISTINCT Patients.PatientID, Patients.FName, Patients.LName, Patients.MI, Patients.CaseStatusID, Patients.NoMoreAppointmentsInd,  Patients.Suffix "
        SQL &=
            " FROM         PatientAccidentGroups INNER JOIN PatientAccidentGroups AS PatientAccidentGroups_1 ON PatientAccidentGroups.GroupID = PatientAccidentGroups_1.GroupID INNER JOIN Patients ON PatientAccidentGroups.PatientID = Patients.PatientID "
        SQL &= " WHERE PatientAccidentGroups_1.PatientID = " & PatientID & " AND PatientAccidentGroups.PatientID <> " &
               PatientID
        SQL &= " Order by Patients.FName, Patients.LName"
        Reader = gSQLGetDataReaderAsync(SQL).Result
        If Reader Is Nothing Then ListViewPatientsRelated.EndUpdate() : Exit Sub
        ListViewPatientsRelated.ListViewItemSorter = Nothing
        If Reader.HasRows Then
            Do Until Reader.Read = False

                LI = ListViewPatientsRelated.Items.Add(Reader("PatientID").ToString,
                                                       CInt(Val(Reader("CaseStatusID").ToString) - 1))
                If Reader("Suffix").ToString <> "" Then
                    LI.SubItems.Add(
                        Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString & " " &
                        Reader("Suffix").ToString)
                Else
                    LI.SubItems.Add(
                        Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString)
                End If
                LI.ToolTipText = Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString &
                                 " " & Reader("Suffix").ToString
                LI.Tag = "" & Reader("PatientID").ToString
                If Val(Reader("NoMoreAppointmentsInd").ToString) <> 0 Then
                    LI.ForeColor = Color.Red
                Else
                    LI.ForeColor = Color.Black
                End If
            Loop
            ListViewPatientsRelated.EndUpdate()
        Else
            ListViewPatientsRelated.EndUpdate()
        End If
        Reader.Close()
        Reader.Dispose()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem6.Click

        Dim ID As Long
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to print the Patient's information. No patient selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ID = ListViewPatients.SelectedItems(0).Tag
        Using frm As frmPatientProceduresSwitchSchedule = New frmPatientProceduresSwitchSchedule
            frm.PatientID = ID
            frm.ShowDialog(Me)
        End Using
        Load_PatientProcedures()
    End Sub

    Private Sub ComboBoxStateOfAccident_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxStateOfAccident.SelectedIndexChanged

        ErrorProvider1.SetError(ComboBoxStateOfAccident, "")
    End Sub

    Private Async Function WaitForTabletSignatureToCompleteAsync(chartSignPadID As Integer) As Task
        Const pollIntervalMilliseconds As Integer = 2000

        Do While Await ChartSignPadRecordExistsAsync(chartSignPadID)
            Await Task.Delay(pollIntervalMilliseconds)
        Loop
        gSQLUpdateData($"DELETE FROM ChartSignPad where ID = {chartSignPadID}")
    End Function
    Private Async Function ChartSignPadRecordExistsAsync(chartSignPadID As Integer) As Task(Of Boolean)
        Const sql As String =
        "SELECT CASE WHEN EXISTS " &
        "(SELECT 1 FROM ChartSignPad WHERE CompleteInd=0 and ID = @ChartSignPadID) " &
        "THEN 1 ELSE 0 END;"

        Using conn As New SqlClient.SqlConnection(gConnectionString)
            Await conn.OpenAsync()

            Using cmd As New SqlClient.SqlCommand(sql, conn)
                cmd.Parameters.Add("@ChartSignPadID", SqlDbType.Int).Value = chartSignPadID

                Dim result As Integer = CInt(Await cmd.ExecuteScalarAsync())
                Return result = 1
            End Using
        End Using
    End Function
    Private Sub Print_Chart(Optional ByVal ForceEditMode As Boolean = False)
        Dim ForceFullReport As Boolean
        Try

            Dim CasePrivate As Boolean
            Dim ID As Long
            Dim PatientProcedureID() As String
            If ListViewPatients.SelectedItems.Count = 0 Then
                MsgBox("Unable to print the Patient's Chart. No patient selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If ComboBoxCaseTypeID.SelectedItem Is Nothing Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(ComboBoxCaseTypeID,
                                        "nable to print the Patient's Chart. The case type should be selected.")
                MsgBox("Unable to print the Patient's Chart. The case type should be selected.", MsgBoxStyle.Exclamation)
                ComboBoxCaseTypeID.Focus()
                Exit Sub

            End If
            If OpMode <> AddEditMode.None And ForceEditMode = False Then
                MsgBox(
                    "Unable to print the Patient's Chart while in edit mode. Please update the patient's profile and try again.",
                    MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            CasePrivate = CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value = 3
            ID = ListViewPatients.SelectedItems(0).Tag

            Dim Ret As DialogResult

            Using frm As frmPatientChartProcedures = New frmPatientChartProcedures
                frm.PatientID = ID
                Ret = frm.ShowDialog(Me)
                If Ret = Windows.Forms.DialogResult.Cancel Then
                    frm.Dispose()
                    Exit Sub
                End If
                PatientProcedureID = frm.PatientProcedureID
                ForceFullReport = frm.CheckBox2.Checked
            End Using

            Cursor = Cursors.WaitCursor
            Dim frmc As frmChart = New frmChart
            frmc.PatientID = ID
            frmc.Setup_report(PatientProcedureID, CasePrivate, ForceFullReport)
            frmc.ShowDialog(Me)
            frmc.Dispose()
            frmc = Nothing
            Cursor = Cursors.Default
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub PrintPreScreenFormToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PrintPreScreenFormToolStripMenuItem.Click

        Try
            Dim ID As Long
            If ListViewPatients.SelectedItems.Count = 0 Then
                MsgBox("Unable to print the Patient's MRI Pre-Screen Form. No patient selected.",
                       MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If OpMode <> AddEditMode.None Then
                MsgBox(
                    "Unable to print the Patient's MRI Pre-Screen Form while in edit mode. Please update the patient's profile and try again.",
                    MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ID = ListViewPatients.SelectedItems(0).Tag
            Cursor = Cursors.WaitCursor
            Dim frm As frmChartPreScreen = New frmChartPreScreen
            frm.PatientID = ID
            frm.Setup_report(ID)
            frm.ShowDialog(Me)
            frm.Dispose()
            frm = Nothing
            Cursor = Cursors.Default
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ShowAccidentRelatedPatientsToolStripMenuItem_Click(ByVal sender As Object,
                                                                   ByVal e As EventArgs) Handles ShowAccidentRelatedPatientsToolStripMenuItem.Click

        Dim ID As Long
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to show Accident related Patients. No Patient selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        ID = ListViewPatients.SelectedItems(0).Tag
        Dim frm As frmAccidentPatients = New frmAccidentPatients
        frm.PatientID = ID
        frm.DOA = txtDOA.Text
        frm.PolicyNumber = txtPolicyNumber.Text
        If Not ComboBoxInsuranceCompanyID.SelectedItem Is Nothing Then
            frm.InsuranceCompanyID =
                CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Value
        End If
        frm.lblPatient.Text = ListViewPatients.SelectedItems(0).SubItems(1).Text.ToUpper
        frm.lblPatient1.Text = "INSURANCE: " & ComboBoxInsuranceCompanyID.Text
        frm.lblPatient2.Text =
            UCase(
                IIf(txtPolicyNumber.Text <> "", "POLICY #:" & txtPolicyNumber.Text, "") &
                IIf(txtClaimNumber.Text <> "", "   CLAIM#:" & txtClaimNumber.Text, "") &
                IIf(txtDOA.Text <> "", "   DOA:" & txtDOA.Text, ""))
        frm.Load_Data()
        frm.ShowDialog(Me)
        Load_RelatedPatients()
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub FindDuplicatePatientsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FindDuplicatePatientsToolStripMenuItem.Click
        If PatientsFindDuplicatesOpened Then
            frmPatientsFindDuplicates.BringToFront()
        Else
            PatientsFindDuplicatesOpened = True
            frmPatientsFindDuplicates.Load_Data()
            frmPatientsFindDuplicates.Show(Me)
        End If
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButton8.Click

        Dim LI As ListViewItem
        If OpMode = AddEditMode.AddNew Then
            MsgBox("Unable to add request while adding new patient. Please update patient's information first.")
            Exit Sub
        End If
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to create request. No patient selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        Dim frm As frmBillingAddRequest = New frmBillingAddRequest
        frm.lblMsg.Text = "Patient: " & txtFName.Text & " " & txtLName.Text
        frm.BillAttorney = ""
        frm.BillInsurance = ComboBoxInsuranceCompanyID.Text
        frm.BillID = 0
        frm.PatientID = LI.Tag
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Load_Requests()
        End If
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Function CheckIfDocumentExist(ByVal DocTypeID As Integer) As Boolean
        Dim LI As ListViewItem
        For Each LI In ListViewDocs.Items
            If Val(LI.SubItems(2).Tag) = DocTypeID Then
                LI.Selected = True
                LI.EnsureVisible()
                CheckIfDocumentExist = True
                Application.DoEvents()
                Exit Function
            End If
        Next
    End Function

    Private Sub ListViewPatientsRelated_ColumnClick(ByVal sender As Object,
                                                    ByVal e As ColumnClickEventArgs) Handles ListViewPatientsRelated.ColumnClick

        Dim new_sorting_column As ColumnHeader = ListViewPatientsRelated.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As SortOrder
        If m_SortingColumnRelated Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumnRelated) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumnRelated.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumnRelated.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumnRelated.Text =             m_SortingColumnRelated.Text.Mid(2)
            m_SortingColumnRelated.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumnRelated = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumnRelated.Text = "> " & m_SortingColumnRelated.Text
        'Else
        'm_SortingColumnRelated.Text = "< " & m_SortingColumnRelated.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumnRelated.ImageKey = "SORT1"
        Else
            m_SortingColumnRelated.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewPatientsRelated.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewPatientsRelated.Sort()
    End Sub

    Private Sub ListViewPatientsRelated_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewPatientsRelated.DoubleClick

        Dim PatID As Long
        If ListViewPatientsRelated.SelectedItems.Count > 0 Then
            If OpMode <> AddEditMode.None Then
                Exit Sub
            End If
            PatID = ListViewPatientsRelated.SelectedItems(0).Tag
            SkipSearch = True
            ComboBoxSearchCaseStatus.SelectedIndex = 0
            ComboBoxSearchCaseType.SelectedIndex = 0
            SkipSearch = False
            TextBoxSearch.Text = PatID
        End If
    End Sub

    Private Sub ListViewPatientsRelated_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListViewPatientsRelated.MouseDown

        Dim H As ListViewHitTestInfo
        If e.Button = Windows.Forms.MouseButtons.Right Then
            H = ListViewPatientsRelated.HitTest(New Point(e.X, e.Y))
            If H.Item Is Nothing Then
                ListViewPatientsRelated.ContextMenuStrip = Nothing
            Else
                If OpMode = AddEditMode.None Then
                    H.Item.Selected = True
                    H.Item.EnsureVisible()
                    ListViewPatientsRelated.ContextMenuStrip = ContextMenuStrip3
                Else
                    ListViewPatientsRelated.ContextMenuStrip = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub ListViewPatientsRelated_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewPatientsRelated.SelectedIndexChanged

        gHighlightListviewItem(ListViewPatientsRelated, True, False)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem1.Click

        ListViewPatientsRelated_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub chkPoliceReportReceived_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPoliceReportReceived.CheckedChanged

    End Sub

    Private Sub chkPoliceReportReceived_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPoliceReportReceived.CheckStateChanged

    End Sub

    Private Sub TabPage1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TabPage1.Click
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuScan.Click

        If gScannerMode = 1 Then
            ScanDocumentFromScannerApplication(0)
        Else
            ScanDocumentFromScanner(0)

        End If
    End Sub

    Private Sub ButtonScannDocument_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonScannDocument.Click

    End Sub

    Private Sub chkPoliceReportReceived_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkPoliceReportReceived.Click

        MsgBox(
            "The Police Report indicator cannot be set manually." & vbCrLf & vbCrLf &
            "It will be set automatically when the Police Report is scanned..", MsgBoxStyle.Information)
    End Sub

    Private Sub chkInitialReportReceived_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkInitialReportReceived.Click

        MsgBox(
            "The Initial Report indicator cannot be set manually." & vbCrLf & vbCrLf &
            "It will be set automatically when the Initial Report is scanned.", MsgBoxStyle.Information)
    End Sub

    Private Sub chkInitialReportReceived_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkInitialReportReceived.CheckedChanged

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButton1.Click

        Dim Fname() As String
        Dim fCount As Integer
        Dim Subject As String
        Dim DocNames As String
        If ListViewDocs.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Document selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewDocs.SelectedItems.Count > 0 AndAlso Val(ListViewDocs.SelectedItems(0).SubItems(1).Tag) = 999 Then
            Dim TempFile As String
            If ListViewDocs.SelectedItems.Count = 0 Then
                MsgBox("Unable to process your request. No Document selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Subject = "Document: " & ListViewDocs.SelectedItems(0).Text
            Subject &= ". Office: " & gOfficeName.ToUpper()
            TempFile = Path.GetTempFileName()
            TempFile = TempFile.Mid(1, TempFile.Length - 3) & "rtf"
            Try
                RichTextBox1.SaveFile(TempFile)
                gFax(Me, "", Subject, TempFile, gOfficeFax)
                gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Tag, PatientLogTypes.tFaxSent, ListViewDocs.SelectedItems(0).Text & " sent")
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try
            Return
        End If
        If ListViewDocs.CheckedItems.Count = 0 Then
            If ListViewDocs.SelectedItems.Count = 0 Then
                MsgBox("Unable to process your request. No Document selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If pdfViewer.Tag = "" Then
                MsgBox("Unable to process your request. No Document Loaded.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If ListViewPatients.SelectedItems.Count > 0 And OpMode <> AddEditMode.AddNew Then
                Subject = "Document: " & ListViewDocs.SelectedItems(0).Text & ", Patient: " &
                          ListViewPatients.SelectedItems(0).SubItems(1).Text &
                          IIf(txtPolicyNumber.Text <> "", " Policy #: " & txtPolicyNumber.Text, "") &
                          IIf(txtClaimNumber.Text <> "", " Claim #: " & txtClaimNumber.Text, "")
            Else
                Subject = "Document: " & ListViewDocs.SelectedItems(0).Text
            End If
            Subject &= ". Office: " & gOfficeName.ToUpper()
            ReDim Preserve Fname(0)
            Fname(0) = pdfViewer.Tag
            Try
                SentFaxNumber = ""

                If gFax(Me, "", Subject, Fname(0), gOfficeFax) Then
                    If SentFaxNumber.Length > 0 And SentFaxNumber.Contains("@") Then
                        SentFaxNumber = SentFaxNumber.Left(SentFaxNumber.IndexOf("@"))
                    End If
                    If ListViewPatients.SelectedItems.Count > 0 Then
                        gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Tag, PatientLogTypes.tFaxSent, ListViewDocs.SelectedItems(0).Text & " Faxed [" & SentFaxNumber & "]")
                        Load_Patient_Log()
                    End If
                End If
                SentFaxNumber = ""
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try
        Else
            fCount = 0
            For Each lvi As ListViewItem In ListViewDocs.CheckedItems

                lvi.EnsureVisible()
                lvi.Selected = True
                DocNames = DocNames + lvi.Text + " \ "
                ReDim Preserve Fname(fCount)
                Fname(fCount) = pdfViewer.Tag
                fCount = fCount + 1
            Next
            Try
                SentFaxNumber = ""
                If gFax(Me, "", Subject, Fname, gOfficeFax) Then
                    If SentFaxNumber.Length > 0 And SentFaxNumber.Contains("@") Then
                        SentFaxNumber = SentFaxNumber.Left(SentFaxNumber.IndexOf("@"))
                    End If
                    gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Tag, PatientLogTypes.tFaxSent, DocNames & " Faxed [" & SentFaxNumber & "]")
                    Load_Patient_Log()
                End If
                SentFaxNumber = ""
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try
            SentFaxNumber = ""
        End If
    End Sub

    Private Sub ComboBoxInjuryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxInjuryID.SelectedIndexChanged

        ErrorProvider1.SetError(ComboBoxInjuryID, "")
    End Sub

    Private Function validateInsurancePatientType() As Boolean
        If ComboBoxPatientTypeID.SelectedIndex = -1 Or ComboBoxInsuranceCompanyID.SelectedIndex = -1 Then
            Return True
        End If
        Dim PatientTypeID As Integer = CType(ComboBoxPatientTypeID.SelectedItem, ValueDescription).Value
        Dim InsuranceID As Integer = CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Value
        If SavePatientInsCompanyID = InsuranceID And SavePatientTypeID = PatientTypeID Then
            Return True
        End If
        If _
            gSQLGetSingleValue(
                "select count(*) from InsuranceCompanies where CompanyID = " & InsuranceID & " and RejectID = " &
                PatientTypeID) > 0 Then

            Return False
        End If
        Return True
    End Function
    Private Function ValidateInsuranceActive(ComboBoxInsuranceCompany As ComboBox, tab As Integer, insTab As Integer) As Boolean
        If ComboBoxInsuranceCompanyID.SelectedIndex = -1 Then
            Return True
        End If
        Dim InsuranceID As Integer = CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Value
        If SavePatientInsCompanyID = InsuranceID Then
            Return True
        End If
        If gSQLGetSingleValue("select count(*) from InsuranceCompanies where CompanyID = " & InsuranceID & " and ActiveInd=1") = 0 Then
            TabControl1.SelectedIndex = tab
            TabControl3.SelectedIndex = insTab
            MsgBox("Unable to process update." & vbCrLf & "The selected Insurance company  is not active.", MsgBoxStyle.Exclamation)
            ComboBoxInsuranceCompany.Focus()
            Return False
        End If

        Return True
    End Function
    Private Sub ComboBoxPatientTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxPatientTypeID.SelectedIndexChanged

        ErrorProvider1.SetError(ComboBoxPatientTypeID, "")
    End Sub

    Private Sub txtVehicleOwner_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtVehicleOwner.TextChanged

        ErrorProvider1.SetError(txtVehicleOwner, "")
    End Sub

    Private Sub txtPolicyNumber_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyNumber.TextChanged

        ErrorProvider1.SetError(txtPolicyNumber, "")
    End Sub

    Private Sub txtClaimNumber_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtClaimNumber.TextChanged

        ErrorProvider1.SetError(txtClaimNumber, "")
    End Sub

    Private Sub txtAdjuster_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAdjuster.TextChanged

        ErrorProvider1.SetError(txtAdjuster, "")
    End Sub

    Private Sub cmdUnlockInsurance_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUnlockInsurance.Click

        Dim ApprovedByName As String = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        Application.DoEvents()
        If gCurrentEmployee.PositionID > 3 Then
            Dim frm As frmSupervisorApproval = New frmSupervisorApproval
            frm.LabelMsg.Text = "ATTENTION!" & vbCrLf & vbCrLf &
                                                  "Change insurance information after BILL created!"
            If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frm.Dispose()
                frm = Nothing
                Exit Sub
            End If
            ApprovedByName = frm.SupervisorName
            frm.Dispose()
            frm = Nothing
        End If
        gUpdate_Profile_Log(ListViewPatients.SelectedItems(0).Tag, PatientLogTypes.tSuppervisorApproval,
                            "Approved Insurance Information Change After Bill Created", ApprovedByName)
        cmdUnlockInsurance.Visible = False
        cmdAddInsuranceAddress.Enabled = True
        ComboBoxInsuranceCompanyID.Enabled = True
        ComboBoxClaimAddress.Enabled = True
        PanelInsurance.Enabled = True
        PanelSecondaryInsurance.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonShowInsurance.Click

        Dim frm As Form = FormsCollection.FindForm("frmInsuranceMaintenance")
        If Not frm Is Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else
            'frmInsuranceMaintenance.Width = 1000
            frmInsuranceMaintenance.WindowState = FormWindowState.Normal
            frmInsuranceMaintenance.Location = New Point(Left + ((Width - frmInsuranceMaintenance.Size.Width) \ 2),
                                                         Top + ((Height - frmInsuranceMaintenance.Size.Height) \ 2))
            frmInsuranceMaintenance.Show(Me)
            frmInsuranceMaintenance.BringToFront()
            If ComboBoxInsuranceCompanyID.SelectedIndex > -1 Then
                frmInsuranceMaintenance.PreSelectedInsuranceID =
                    CType(ComboBoxInsuranceCompanyID.SelectedItem, ValueDescription).Value
            End If
            frmInsuranceMaintenance.TimerSearch.Enabled = True
        End If
    End Sub

    Private Sub AddProcedureToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AddProcedureToolStripMenuItem.Click

        ButtonAddProcedure_Click(Nothing, Nothing)
    End Sub

    Private Sub RemoveProcedureToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RemoveProcedureToolStripMenuItem.Click

        ButtonDeleteProcedure_Click(Nothing, Nothing)
    End Sub

    Private Sub ContextMenuStripProcedures_Opening(ByVal sender As Object,
                                                   ByVal e As ComponentModel.CancelEventArgs) Handles ContextMenuStripProcedures.Opening

        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            e.Cancel = True
            Exit Sub
        End If
        ToolStripMenuItem3.Visible = gCurrentEmployee.PositionID < 4 Or gCurrentEmployee.PositionID = 6
        ToolStripSeparator6.Visible = gCurrentEmployee.PositionID < 4 Or gCurrentEmployee.PositionID = 6
        AddProcedureToolStripMenuItem.Visible = ButtonAddProcedure.Enabled
        RemoveProcedureToolStripMenuItem.Visible = ButtonDeleteProcedure.Enabled

        ChangeReferringDoctorToolStripMenuItem.Visible = (gOfficeTypeID = 1 Or gOfficeTypeID = 3)
        If ListViewPatients.SelectedItems.Count = 0 And OpMode = AddEditMode.None Then

            AddProcedureToolStripMenuItem.Visible = False
        End If
        If CheckBoxNoMoreAppointmentsInd.Checked Then
            AddProcedureToolStripMenuItem.Visible = False
        End If
        If ListViewProcedures.SelectedItems.Count = 0 Then
            ToolStripMenuItem3.Visible = False
            ToolStripSeparator6.Visible = False
            RemoveProcedureToolStripMenuItem.Visible = False
            ChangeReferringDoctorToolStripMenuItem.Visible = False
        Else
            If ListViewProcedures.SelectedItems(0).Text <> "" And (gOfficeTypeID = 1 Or gOfficeTypeID = 3) Then
                RemoveProcedureToolStripMenuItem.Visible = False
            End If
        End If
        If ListViewProcedures.SelectedItems.Count > 0 Then
            LI = ListViewProcedures.SelectedItems(0)
            If gOfficeTypeID = 3 Then
                ToolStripSeparatorPreCertification.Visible = True
                If IsDate(LI.SubItems(8).Text) AndAlso CDate(LI.SubItems(8).Text) >= CDate(DateTime.Now.ToShortDateString) Then
                    PreCertificationNotCompleteToolStripMenuItem.Visible = True
                    PreCertificationCompleteToolStripMenuItem.Visible = False
                Else
                    PreCertificationNotCompleteToolStripMenuItem.Visible = False
                    PreCertificationCompleteToolStripMenuItem.Visible = True
                End If
            Else
                PreCertificationCompleteToolStripMenuItem.Visible = False
                PreCertificationNotCompleteToolStripMenuItem.Visible = False
                ToolStripSeparatorPreCertification.Visible = False
            End If
        Else
            PreCertificationCompleteToolStripMenuItem.Visible = False
            PreCertificationNotCompleteToolStripMenuItem.Visible = False
            ToolStripSeparatorPreCertification.Visible = False
        End If


    End Sub

    Private Sub ToolStripMenuItemSchedule_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItemSchedule.Click

        If OpMode <> AddEditMode.None Then
            MsgBox("Unable to print Schedule while patient's profile in the edit mode.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to print Schedule. No patient selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If ListViewPatients.SelectedItems.Count > 0 Then
            Dim frm As frmReportSchedule = New frmReportSchedule
            frm.ByPatient = True
            frm.ScheduleDate = Nothing
            frm.CheckBox1.Visible = True
            frm.PatientID = Val(ListViewPatients.SelectedItems(0).Tag)
            frm.ShowDialog(Me)
            frm.Dispose()
            frm = Nothing
        Else
            MsgBox("Unable to print patient's schedule. No Patient selected.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem7.Click

        Dim PatientID() As String = Nothing
        Try
            If ListViewPatients.SelectedItems.Count = 0 Then
                MsgBox("Unable to print  Envelope. No Patient selected.", MsgBoxStyle.Critical)
                TreeViewBills.Focus()
                Exit Sub
            End If

            ReDim Preserve PatientID(0)
            PatientID(0) = Val(ListViewPatients.SelectedItems(0).Text)
            Dim frm As frmBillingEnvelops = New frmBillingEnvelops
            frm.Setup_report(PatientID, 0, False)
            frm.ShowDialog(Me)
            frm.Dispose()
            frm = Nothing
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ToolStripButtonComplete_Click()
        If ListViewPatients.SelectedItems.Count = 0 And OpMode = AddEditMode.None Then
            MsgBox("Unable to set Procedure as completed." & vbCrLf & "No Patient Selected", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewProcedures.SelectedItems.Count = 0 Then
            MsgBox("Unable to set Procedure as completed." & vbCrLf & "No Procedure Selected", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewProcedures.SelectedItems(0).ImageIndex <> 1 Then
            MsgBox(
                "Unableto set status Complete for the procedure status " &
                Choose(ListViewProcedures.SelectedItems(0).ImageIndex + 1, "Not Scheduled", "Scheduled", "Complete",
                       "Canceled") & vbCrLf & vbCrLf &
                "The status Complete can be set for the Scheduled procedure status only.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If _
            MsgBox("Please verify the " & ListViewProcedures.SelectedItems(0).SubItems(2).Text & " has been completed?",
                   MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        gSQLUpdateData(
            "Update PatientProcedures set ProcedureStatusID = 2, UpdatedDT=getdate(), UpdatedByEmpID=" &
            gCurrentEmployee.EmpID & " WHERE PatientProcedureID = " &
            Val(ListViewProcedures.SelectedItems(0).SubItems(2).Tag))
        gUpdate_Profile_Log(Val(ListViewPatients.SelectedItems(0).Text), PatientLogTypes.tScheduleCompleted)
        ListViewProcedures.SelectedItems(0).ImageIndex = 2
        ListViewProcedures.SelectedItems(0).SubItems(1).Text = "Complete"
    End Sub

    Private Sub CancelAppointmentToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 And OpMode = AddEditMode.None Then
            MsgBox("Unable to Cancel Appointment." & vbCrLf & "No Patient Selected", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewProcedures.SelectedItems.Count = 0 Then
            MsgBox("Unable to Cancel Appointment." & vbCrLf & "No Procedure Selected", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewProcedures.SelectedItems(0).ImageIndex <> 1 Then
            MsgBox(
                "Unable to Cancel Appointment for the procedure status " &
                Choose(ListViewProcedures.SelectedItems(0).ImageIndex + 1, "Not Scheduled", "Scheduled", "Complete",
                       "Canceled") & vbCrLf & vbCrLf &
                "The status Complete can be set for the Scheduled procedure status only.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewProcedures.SelectedItems(0)
        If _
            MsgBox(
                "Please confirm you want to cancel appointment at " & vbCrLf & LI.Text & " for the " &
                LI.SubItems(2).Text & "?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        If _
            gSQLGetSingleValue(
                "select count(*) from BillProcedures Where PatientProcedureID = " & Val(LI.SubItems(2).Tag)) > 0 Then
            MsgBox("Unable to Cancel Procedure." & vbCrLf & vbCrLf & "Procedure already billed!",
                   MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim lblCancelReason As New Label
        Dim frm As frmScheduleCancelationReason = New frmScheduleCancelationReason
        frm.CancelReason = lblCancelReason
        frm.LabelInfo.Text = "Patient: " & ListViewPatients.SelectedItems(0).SubItems(1).Text &
                                                      vbCrLf & "Procedure: " &
                                                      ListViewProcedures.SelectedItems(0).SubItems(2).Text
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

            gUpdate_Profile_Log(Val(ListViewPatients.SelectedItems(0).Text), PatientLogTypes.tScheduleCanceled,
                                "Appointment canceled: " & LI.Text & " for the " & LI.SubItems(2).Text &
                                ". Cancelation Reason: " & lblCancelReason.Text.ToSafeSQLString())
            gSQLUpdateData("Delete from Schedule where ScheduleID = " & LI.SubItems(1).Tag)
            gSQLUpdateData("Delete from PatientProcedures where PatientProcedureID = " & LI.SubItems(2).Tag)
            gSQLUpdateData(
                "INSERT INTO PatientReschedulesCancelations (PatientID, ReScheduleCancelInd, Comments, ProcessedBy) VALUES(" &
                Val(ListViewPatients.SelectedItems(0).Text) & ",2, '" & LI.SubItems(2).Text & " at " & LI.Text &
                " has been Canceled. Cancelation Reason: " & lblCancelReason.Text.ToSafeSQLString() & "'," & gCurrentEmployee.EmpID &
                " )")

            LI.Remove()
            MsgBox(
                "The appointment has been canceled." & vbCrLf & vbCrLf & "ATTENTION!" & vbCrLf & vbCrLf &
                "Please Inform the Patient about this appointment cancelation!", MsgBoxStyle.Exclamation)
        End If
        frm.Dispose()
        frm = Nothing
        lblCancelReason.Dispose()
    End Sub

    Private Sub ToolStripButtonEditIME_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonEditIME.Click

        Dim LI As ListViewItem
        If OpMode = AddEditMode.AddNew Then
            MsgBox(
                "Unable to edit Insurance Examination while adding new patient. Please update patient's information first.")
            Exit Sub
        End If
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to edit Insurance Examination. No patient selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewIME.SelectedItems.Count = 0 Then
            MsgBox("Unable to edit Insurance Examination. No Insurance Examination selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewIME.SelectedItems(0)
        Dim frm As frmInsuranceExamination = New frmInsuranceExamination
        With frm
            .Load_Data()
            .PatientID = ListViewPatients.SelectedItems(0).Tag
            .ExaminationID = LI.Tag
            .cboType.Text = LI.Text
            .ScheduleDate = CType(LI.SubItems(1).Text, DateTime)
            .Status = LI.SubItems(2).Tag
            '.DateTimePickerDate.Value = CType(LI.SubItems(1).Text, DateTime)
            '.DateTimePickerTime.Value = CType(LI.SubItems(1).Text, DateTime)
            .txtIMEEUOAddress.Text = LI.SubItems(3).Text
            .cboStatus.Tag = Val(LI.SubItems(2).Tag)

            .DateTimePickerDate.Enabled = False
            Select Case Val(LI.SubItems(2).Tag)
                Case 3, 4, 5
                    .cboStatus.Enabled = False
                    .DateTimePickerTime.Enabled = False
                Case Else
                    .cboStatus.Enabled = True
                    .DateTimePickerTime.Enabled = True
            End Select
            .cboType.Enabled = False

            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Load_IME()
            End If
        End With
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub ToolStripButtonAddIME_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonAddIME.Click

        If OpMode = AddEditMode.AddNew Then
            MsgBox(
                "Unable to add Insurance Examination while adding new patient. Please update patient's information first.")
            Exit Sub
        End If
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to add Insurance Examination. No patient selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ComboBoxInsuranceCompanyID.SelectedIndex = -1 Then
            'If TabControl1.TabPages.ContainsKey("TabPageWC") = True Then
            '    TabControl1.SelectedIndex = 2
            'Else
            TabControl1.SelectedIndex = 1
            'End If
            MsgBox("Unable to add Insurance Examination. No Insurance Company Selected.", MsgBoxStyle.Exclamation)
            ComboBoxInsuranceCompanyID.Focus()
            Exit Sub
        End If
        Dim frm As frmInsuranceExamination = New frmInsuranceExamination
        With frm
            .Load_Data()
            .PatientID = ListViewPatients.SelectedItems(0).Tag
            .cboType.Enabled = True
            .DateTimePickerDate.Enabled = True
            .DateTimePickerTime.Enabled = True
            .cboStatus.Enabled = True
            '.DateTimePickerDate.MinDate = Now
            '.DateTimePickerDate.MinDate = Now
            .cboStatus.SelectedIndex = 0
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Load_IME()
            End If
        End With
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub ListViewIME_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewIME.DoubleClick

        ToolStripButtonEditIME_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewIME_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewIME.SelectedIndexChanged

    End Sub

    Private Sub ScheduleNoShowToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim LI As ListViewItem
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim ProcDate As String
        If ListViewProcedures.SelectedItems.Count = 0 Then Exit Sub
        LI = ListViewProcedures.SelectedItems(0)

        SQL =
            "SELECT  PatientProcedureStatuses.Description as Status, PatientProcedures.ProcedureStatusID,  PatientProcedures.ProcID, PatientProcedures.DiagID, PatientProcedures.PatientID, Schedule.ScheduleDateTime, Procedures.ProcName "
        SQL &= " FROM PatientProcedures "
        SQL &= " INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID "
        SQL &= " INNER JOIN Diagnostics on Diagnostics.DiagID = PatientProcedures.DiagID "
        SQL &= " INNER JOIN [Procedures] on [Procedures].ProcID = PatientProcedures.ProcID "
        SQL &=
            " INNER JOIN [PatientProcedureStatuses] on [PatientProcedureStatuses].ProcedureStatusID = PatientProcedures.ProcedureStatusID "
        SQL &= " WHERE PatientProcedures.PatientProcedureID = " & LI.SubItems(0).Tag
        Reader = gSQLGetDataReaderAsync(SQL).Result
        If Reader Is Nothing Then
            MsgBox("Unexpected error. Please call system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Reader.HasRows = False Then
            MsgBox("Unexpected error. Please call system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Reader.Read()
        If Val(Reader("ProcedureStatusID").ToString) <> 1 Then
            MsgBox("Unable to set appointment status " & Reader("Status").ToString & " as No Show")
            Exit Sub
        End If
        If IsDate(Reader("ScheduleDateTime").ToString) Then
            ProcDate = CDate(Reader("ScheduleDateTime").ToString).Date
            If CDate(Reader("ScheduleDateTime").ToString).Date > Now.Date Then
                MsgBox("Unable to set future appointment as No Show", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Else
            ProcDate = ""
        End If
        If _
            MsgBox("Please confirm the selected appointment No Show?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) =
            MsgBoxResult.No Then
            Exit Sub
        End If
        gSQLUpdateData(
            "Update PatientProcedures set ProcedureStatusID = 4, UpdatedDT=getdate(), UpdatedByEmpID=" &
            gCurrentEmployee.EmpID & " WHERE PatientProcedureID = " & Val(LI.SubItems(0).Tag))
        gUpdate_Profile_Log(Val(Reader("PatientID").ToString), PatientLogTypes.tScheduleNoShow,
                            "No Show - " & Reader("ProcName").ToString & " - " & ProcDate)
        gSQLUpdateData(
            "INSERT INTO PatientNoShow (ProcedureID,DiagID,PatientID,ScheduleDateTime) VALUES (" &
            Val(Reader("ProcID").ToString) & "," & Val(Reader("DiagID").ToString) & "," &
            Val(Reader("PatientID").ToString) & ",'" & ProcDate & "')")

        LI.ImageIndex = 4
        LI.SubItems(1).Text = "No Show"
        LI.SubItems(1).BackColor = Color.LightCoral
        LI.SubItems(1).ForeColor = Color.White
    End Sub

    Private Sub ChangeReferringDoctorToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ChangeReferringDoctorToolStripMenuItem.Click

        Dim LI As ListViewItem
        Dim ShiftWCTab As Integer = 1
        'If TabControl1.TabPages.ContainsKey("TabPageWC") = True Then
        '    ShiftWCTab = 0
        'End If
        If gOfficeTypeID = 2 Then Exit Sub
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        If ListViewProcedures.SelectedItems.Count = 0 Then Exit Sub
        LI = ListViewProcedures.SelectedItems(0)
        If ComboBoxReferringCompanyID.SelectedIndex = -1 Then
            TabControl1.SelectedIndex = 2 - ShiftWCTab
            MsgBox("Unable to change procedure Reffering Doctor. Please select the Referring Company first.",
                   MsgBoxStyle.Exclamation)
            ComboBoxReferringCompanyID.Focus()
            Exit Sub
        End If
        If _
            gSQLGetSingleValue(
                "SELECT COUNT(*) AS C  FROM BillProcedures  WHERE PatientProcedureID = " & Val(LI.SubItems(0).Tag)) > 0 _
            Then
            MsgBox(
                "Unable to change the Procedure Reffering Doctor." & vbCrLf &
                "This procedure is already has been billed.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If gCurrentEmployee.PositionID > 3 Then
            Dim frm As frmSupervisorApproval = New frmSupervisorApproval
            frm.LabelMsg.Text = "Change Procedure Reffering Doctor."
            If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frm.Dispose()
                frm = Nothing
                Exit Sub
            End If
            frm.Dispose()
            frm = Nothing
        Else
        End If
        Dim frmrd As frmProcedureChangeRefferingDoctor = New frmProcedureChangeRefferingDoctor
        frmrd.PatientID = Val(ListViewPatients.SelectedItems(0).Text)
        frmrd.ReferringCompanyID =
            CType(ComboBoxReferringCompanyID.SelectedItem, ValueDescription).Value.ToString
        frmrd.PatientProcedureID = Val(LI.SubItems(0).Tag)
        frmrd.LabelReferringOffice.Text = ComboBoxReferringCompanyID.Text
        frmrd.LabelPatientName.Text = ListViewPatients.SelectedItems(0).SubItems(1).Text
        frmrd.LabelProcedure.Text = LI.SubItems(1).Text
        frmrd.LabelCurrentDoctor.Text = LI.SubItems(4).Text
        frmrd.StartPosition = FormStartPosition.CenterParent
        If frmrd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If frmrd.ComboBoxReferringDoctor.SelectedIndex > -1 Then
                LI.SubItems(4).Text = CType(frmrd.ComboBoxReferringDoctor.SelectedItem, ValueDescription).Description
                LI.SubItems(4).Tag = CType(frmrd.ComboBoxReferringDoctor.SelectedItem, ValueDescription).Value1
            Else
                LI.SubItems(4).Text = frmrd.ComboBoxReferringDoctor.Text
            End If
            gSQLUpdateData(
                "UPDATE PatientProcedures Set ReferringDoctorNPI='" & LI.SubItems(4).Tag.ToString().ToSafeSQLString() & "', ReferringDoctor = '" & LI.SubItems(4).Text.ToSafeSQLString() &
                "' Where PatientProcedureID = " & Val(LI.SubItems(0).Tag))

        End If
        frmrd.Dispose()
        frmrd = Nothing
    End Sub

    Public PhotoImage As Image
    Private Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short,
                                                                         ByVal lpszName As String,
                                                                         ByVal cbName As Integer,
                                                                         ByVal lpszVer As String, ByVal cbVer As Integer) _
        As Boolean

    Private Sub ToolStripButton5_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonCapturePhoto.Click

        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim x As Integer = 0
        Dim bReturn As Boolean
        bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
        If bReturn = False Then
            MsgBox(
                "Unable to capture Patient's Photo." & vbCrLf & "No Capture Device Found." & vbCrLf &
                "Please contact your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not picPhoto.Image Is Nothing Then
            If _
                MsgBox("Please confirm you want to overwrite the Patient's Photo?",
                       MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        If gCapturePhoto Is Nothing OrElse gCapturePhoto.IsDisposed Then
            gCapturePhoto = New frmCapturePhoto()
            gCapturePhoto.FirstLoad = True
        End If
        gCapturePhoto.Hide()
        gCapturePhoto.ParentPhotoContainer = picPhoto
        gCapturePhoto.ParentForm = MDIForm1Win8
        gCapturePhoto.ToolStripButtonPreview = ToolStripButtonPreview
        gCapturePhoto.ParentPhotoContainer = picPhoto
        gCapturePhoto.picSave.Image = Nothing
        gCapturePhoto.Show(MDIForm1Win8)

        MDIForm1Win8.Enabled = False
        'If gCapturePhoto.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '    ToolStripButtonPreview.Enabled = True
        'End If
        'frmCapturePhoto.Dispose()
    End Sub

    Private Sub ToolStripButtonDeletePhoto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonDeletePhoto.Click

        If picPhoto.Image Is Nothing Then
            MsgBox("Nothing To Delete!" & vbCrLf & "No Patient's Photo captured.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If _
            MsgBox("Please confirm you want to delete the Patient's Photo?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) =
            MsgBoxResult.No Then Exit Sub
        picPhoto.Image = Nothing
        picPhoto.Tag = "2"
        ToolStripButtonPreview.Enabled = False
        ToolStripButtonPrintPhotoLabel.Enabled = False
    End Sub

    Private Sub picPhoto_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles picPhoto.DoubleClick
        If picPhoto.Image Is Nothing Then Exit Sub
        Using frm As frmPatientPhotoPreview = New frmPatientPhotoPreview
            frm.Label1.Text = txtFName.Text & " " & txtLName.Text
            frm.DOB = txtDOB.Text

            frm.PictureBox1.Image = picPhoto.Image.Clone
            frm.ShowDialog(Me)

        End Using
    End Sub

    Private Sub ToolStripButton6_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonPreview.Click

        picPhoto_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton5_Click_2(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonPrintPhotoLabel.Click

        Try
            Dim ID As Long
            If ListViewPatients.SelectedItems.Count = 0 Then
                MsgBox("Unable to print Patient's Photo Label." & vbCrLf & "No patient selected.",
                       MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If picPhoto.Image Is Nothing Then
                If _
                    MsgBox("Unable to print Patient's Photo Label." & vbCrLf & "No Patient's photo captured.",
                           MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Exit Sub
            End If
            If MsgBox("Print Patient's Photo Label?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then _
                Exit Sub

            PanelPrinting.Visible = True
            Application.DoEvents()
            ID = ListViewPatients.SelectedItems(0).Tag
            Cursor = Cursors.WaitCursor
            Print_Photo_Label(ID)
            Cursor = Cursors.Default
            PanelPrinting.Visible = False
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ToolStripButtonUnlockReading_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonUnlockReading.Click

        Dim LI As ListViewItem
        Dim VD As ValueDescription
        Dim msg As String
        If ListViewReadings.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewReadings.SelectedItems(0)
        VD = CType(LI.Tag, ValueDescription)
        If Val(VD.Fld4) = 0 Then
            MsgBox("Unable to process your request. The selected procedure does not have a reading.",
                   MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If _
            gSQLGetSingleValue("SELECT count(*) FROM BillProcedures where PatientProcedureID=" & Val(VD.Value).ToString) >
            0 Then
            msg = "Unlock Procedure Reading." & vbCrLf & "Attention! This procedure already has been billed!" & vbCrLf &
                  "The Reading report has been sent to the insurance company"
        Else
            msg = "Unlock Procedure Reading."
        End If
        Dim frm As frmSupervisorApproval = New frmSupervisorApproval
        frm.LabelMsg.Text = msg
        Dim ApprovedByName As String
        frm.SupervisorName = ApprovedByName
        If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
            frm.Dispose()
            frm = Nothing
            Exit Sub
        End If
        ApprovedByName = frm.SupervisorName
        frm.Dispose()
        frm = Nothing
        gUpdate_Profile_Log(Val(ListViewPatients.SelectedItems(0).Tag), PatientLogTypes.tProcedureReadingUpdated,
                            LI.SubItems(1).Text & " - Reading Has Been Unlocked", ApprovedByName)

        gSQLUpdateData("UPDATE PatientProcedureReadings SET EditInd=1 WHERE resultid=" & Val(VD.Fld4).ToString)
        LI.ImageIndex = 4
        ToolStripButtonUnlockReading.Enabled = False
    End Sub

    Private Sub ToolStripButton5_Click_3(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButton5.Click

        If TextBoxReading.Font.Size > 72 Then Exit Sub
        TextBoxReading.Font = New Font(TextBoxReading.Font.Name, TextBoxReading.Font.Size + 1, FontStyle.Regular)
    End Sub

    Private Sub ToolStripButton6_Click_2(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButton6.Click

        If TextBoxReading.Font.Size < 9 Then Exit Sub
        TextBoxReading.Font = New Font(TextBoxReading.Font.Name, TextBoxReading.Font.Size - 1, FontStyle.Regular)
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonShowBill.Click

        Dim SelectedBillID As Long
        Dim Node As TreeNode
        Node = TreeViewBills.SelectedNode
        If Node Is Nothing Then
            MsgBox("Unable to produce the Bill. No bill selected.", MsgBoxStyle.Critical)
            TreeViewBills.Focus()
            Exit Sub
        End If
        If ComboBoxCaseTypeID.SelectedIndex = -1 Then
            MsgBox("Unable to produce the Bill. No Case Type Selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Node.Parent Is Nothing Then
            SelectedBillID = Node.Tag
        ElseIf Node.Parent.Parent Is Nothing Then
            SelectedBillID = Node.Parent.Tag
        ElseIf Node.Parent.Parent.Parent Is Nothing Then
            SelectedBillID = Node.Parent.Parent.Tag
        End If
        Dim pBillID() As String
        ReDim pBillID(0)
        pBillID(0) = SelectedBillID

        Try
            Dim frm As frmNF3Report = New frmNF3Report
            frm.Setup_report(pBillID, CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value)
            frm.MinimizeBox = False

            frm.ShowDialog(Me)
            frm.Dispose()
            frm = Nothing
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ComboBoxRelationToInsuredID1_SelectedIndexChanged(ByVal sender As Object,
                                                                  ByVal e As EventArgs) Handles ComboBoxRelationToInsuredID1.SelectedIndexChanged

        If ComboBoxRelationToInsuredID1.SelectedIndex = -1 Then Exit Sub
        If CType(ComboBoxRelationToInsuredID1.SelectedItem, ValueDescription).Value = 1 Then
            If txtFName.Text.Trim <> "" Then
                If txtPolicyHolderFName1.Text = "" Then txtPolicyHolderFName1.Text = txtFName.Text.Trim
            End If
            If txtLName.Text.Trim <> "" Then
                If txtPolicyHolderLName1.Text = "" Then txtPolicyHolderLName1.Text = txtLName.Text.Trim
            End If
            If txtMI.Text.Trim <> "" Then
                If txtPolicyHolderMI1.Text = "" Then txtPolicyHolderMI1.Text = txtMI.Text.Trim
            End If
            If txtDOB.MaskCompleted Then
                If txtPolicyHolderBirthDate1.MaskCompleted = False Then txtPolicyHolderBirthDate1.Text = txtDOB.Text
            End If
            If txtAddress1.Text <> "" Then
                If txtPolicyHolderAddress1.Text = "" Then _
                    txtPolicyHolderAddress1.Text = txtAddress1.Text & " " & txtAddress2.Text
            End If
            If txtCity.Text <> "" Then
                If txtPolicyHolderCity1.Text = "" Then txtPolicyHolderCity1.Text = txtCity.Text
            End If
            If ComboBoxState.SelectedIndex > -1 Then
                If ComboBoxPolicyHolderState1.SelectedIndex = -1 Then _
                    ComboBoxPolicyHolderState1.SelectedIndex = ComboBoxState.SelectedIndex
            End If
            If txtZip.MaskCompleted Then
                If txtPolicyHolderZip1.MaskCompleted = False Then txtPolicyHolderZip1.Text = txtZip.Text
            End If
            If txtEmployerName.Text <> "" Then
                If txtPolicyHolderEmployerName1.Text = "" Then txtPolicyHolderEmployerName1.Text = txtEmployerName.Text
            End If
            If txtEmployerAddress.Text <> "" Then
                If txtPolicyHolderEmployerAddress1.Text = "" Then _
                    txtPolicyHolderEmployerAddress1.Text = txtEmployerAddress.Text
            End If
            If txtOccupation.Text <> "" Then
                If txtPolicyHolderOccupation1.Text = "" Then txtPolicyHolderOccupation1.Text = txtOccupation.Text
            End If
            If txtEmployerPhone.MaskCompleted Then
                If txtPolicyHolderEmployerPhone.MaskCompleted = False Then _
                    txtPolicyHolderEmployerPhone.Text = txtEmployerPhone.Text
            End If
        End If
    End Sub

    Private Sub ButtonShowInsurance1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonShowInsurance1.Click

        Dim frm As Form = FormsCollection.FindForm("frmInsuranceMaintenance")
        If Not frm Is Nothing Then
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else
            'frmInsuranceMaintenance.Width = 1000
            frmInsuranceMaintenance.WindowState = FormWindowState.Normal
            frmInsuranceMaintenance.Location = New Point(Left + ((Width - frmInsuranceMaintenance.Size.Width) \ 2),
                                                         Top + ((Height - frmInsuranceMaintenance.Size.Height) \ 2))
            frmInsuranceMaintenance.Show(Me)
            frmInsuranceMaintenance.BringToFront()
            If ComboBoxInsuranceCompanyID1.SelectedIndex > -1 Then
                frmInsuranceMaintenance.PreSelectedInsuranceID =
                    CType(ComboBoxInsuranceCompanyID1.SelectedItem, ValueDescription).Value
            End If
            frmInsuranceMaintenance.TimerSearch.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxRelationToInsuredID_SelectedIndexChanged(ByVal sender As Object,
                                                                 ByVal e As EventArgs) Handles ComboBoxRelationToInsuredID.SelectedIndexChanged

        ErrorProvider1.SetError(ComboBoxRelationToInsuredID, "")
        If ComboBoxRelationToInsuredID.SelectedIndex = -1 Then Exit Sub
        If CType(ComboBoxRelationToInsuredID.SelectedItem, ValueDescription).Value = 1 Then
            If txtFName.Text.Trim <> "" Then
                If txtPolicyHolderFName.Text = "" Then txtPolicyHolderFName.Text = txtFName.Text.Trim
            End If
            If txtLName.Text.Trim <> "" Then
                If txtPolicyHolderLName.Text = "" Then txtPolicyHolderLName.Text = txtLName.Text.Trim
            End If
            If txtMI.Text.Trim <> "" Then
                If txtPolicyHolderMI.Text = "" Then txtPolicyHolderMI.Text = txtMI.Text.Trim
            End If
            If IsDate(txtDOB.Text) Then
                If IsDate(txtPolicyHolderBirthDate.Text) = False Then txtPolicyHolderBirthDate.Text = txtDOB.Text
            End If
            If txtAddress1.Text <> "" Then
                If txtPolicyHolderAddress.Text = "" Then _
                    txtPolicyHolderAddress.Text = txtAddress1.Text & " " & txtAddress2.Text
            End If
            If txtCity.Text <> "" Then
                If txtPolicyHolderCity.Text = "" Then txtPolicyHolderCity.Text = txtCity.Text
            End If
            If ComboBoxState.SelectedIndex > -1 Then
                If ComboBoxPolicyHolderState.SelectedIndex = -1 Then _
                    ComboBoxPolicyHolderState.SelectedIndex = ComboBoxState.SelectedIndex
            End If
            If txtZip.MaskCompleted Then
                If txtPolicyHolderZip.Text = "" Or txtPolicyHolderZip.Text = "_____" Then _
                    txtPolicyHolderZip.Text = txtZip.Text
            End If
            If txtEmployerName.Text <> "" Then
                If txtPolicyHolderEmployerName.Text = "" Then txtPolicyHolderEmployerName.Text = txtEmployerName.Text
            End If
            If txtEmployerAddress.Text <> "" Then
                If txtPolicyHolderEmployerAddress.Text = "" Then _
                    txtPolicyHolderEmployerAddress.Text = txtEmployerAddress.Text
            End If
            If txtOccupation.Text <> "" Then
                If txtPolicyHolderOccupation.Text = "" Then txtPolicyHolderOccupation.Text = txtOccupation.Text
            End If
            If txtEmployerPhone.MaskCompleted Then
                If txtPolicyHolderEmployerPhone.Text = "" Or txtPolicyHolderEmployerPhone.Text = "_____" Then _
                    txtPolicyHolderEmployerPhone.Text = txtEmployerPhone.Text
            End If

        End If
    End Sub

    Private Sub txtClaimEffectiveDT_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtClaimEffectiveDT.TextChanged

        ErrorProvider1.SetError(txtClaimEffectiveDT, "")
    End Sub

    Private Sub txtPolicyHolderFName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderFName.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderFName, "")
    End Sub

    Private Sub txtPolicyHolderMI_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderMI.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderMI, "")
    End Sub

    Private Sub txtPolicyHolderLName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderLName.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderLName, "")
    End Sub

    Private Sub txtClaimEffectiveDT_MaskInputRejected(ByVal sender As Object,
                                                      ByVal e As MaskInputRejectedEventArgs) Handles txtClaimEffectiveDT.MaskInputRejected

    End Sub

    Private Sub txtGroupNumber_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtGroupNumber.TextChanged

        ErrorProvider1.SetError(txtGroupNumber, "")
    End Sub

    Private Sub txtIDNumber_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtIDNumber.TextChanged

        ErrorProvider1.SetError(txtIDNumber, "")
    End Sub

    Private Sub txtPolicyHolderBirthDate_MaskInputRejected(ByVal sender As Object,
                                                           ByVal e As MaskInputRejectedEventArgs) Handles txtPolicyHolderBirthDate.MaskInputRejected

    End Sub

    Private Sub txtPolicyHolderBirthDate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderBirthDate.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderBirthDate, "")
    End Sub

    Private Sub txtPolicyHolderSSN_MaskInputRejected(ByVal sender As Object,
                                                     ByVal e As MaskInputRejectedEventArgs) Handles txtPolicyHolderSSN.MaskInputRejected

    End Sub

    Private Sub txtPolicyHolderSSN_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderSSN.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderSSN, "")
    End Sub

    Private Sub txtPolicyHolderAddress_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderAddress.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderAddress, "")
    End Sub

    Private Sub txtPolicyHolderCity_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderCity.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderCity, "")
    End Sub

    Private Sub ComboBoxPolicyHolderState_SelectedIndexChanged(ByVal sender As Object,
                                                               ByVal e As EventArgs) Handles ComboBoxPolicyHolderState.SelectedIndexChanged

        ErrorProvider1.SetError(ComboBoxPolicyHolderState, "")
    End Sub

    Private Sub txtPolicyHolderZip_MaskInputRejected(ByVal sender As Object,
                                                     ByVal e As MaskInputRejectedEventArgs) Handles txtPolicyHolderZip.MaskInputRejected

    End Sub

    Private Sub txtPolicyHolderZip_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderZip.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderZip, "")
    End Sub

    Private Sub txtPolicyHolderPhone_MaskInputRejected(ByVal sender As Object,
                                                       ByVal e As MaskInputRejectedEventArgs) Handles txtPolicyHolderPhone.MaskInputRejected

    End Sub

    Private Sub txtPolicyHolderPhone_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderPhone.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderPhone, "")
    End Sub

    Private Sub txtPolicyHolderEmployerName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderEmployerName.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderEmployerName, "")
    End Sub

    Private Sub txtPolicyHolderEmployerAddress_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderEmployerAddress.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderEmployerAddress, "")
    End Sub

    Private Sub txtPolicyHolderOccupation_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderOccupation.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderOccupation, "")
    End Sub

    Private Sub txtPolicyHolderEmployerPhone_MaskInputRejected(ByVal sender As Object,
                                                               ByVal e As _
                                                                  MaskInputRejectedEventArgs) Handles txtPolicyHolderEmployerPhone.MaskInputRejected

    End Sub

    Private Sub txtPolicyHolderEmployerPhone_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderEmployerPhone.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderEmployerPhone, "")
    End Sub

    Private Sub txtAdjusterPhone_MaskInputRejected(ByVal sender As Object,
                                                   ByVal e As MaskInputRejectedEventArgs) Handles txtAdjusterPhone.MaskInputRejected

        ErrorProvider1.SetError(txtAdjusterPhone, "")
    End Sub

    Private Sub txtAdjusterComments_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAdjusterComments.TextChanged

        ErrorProvider1.SetError(txtAdjusterComments, "")
    End Sub

    Private Sub txtPolicyHolderOtherDependents_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPolicyHolderOtherDependents.TextChanged

        ErrorProvider1.SetError(txtPolicyHolderOtherDependents, "")
    End Sub

    Private Sub txtPhone1_MaskInputRejected(ByVal sender As Object,
                                            ByVal e As MaskInputRejectedEventArgs) Handles txtPhone1.MaskInputRejected

    End Sub

    Private Sub txtPhone1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPhone1.Validating

        If txtPhone1.MaskedTextProvider.AssignedEditPositionCount > 0 And txtPhone1.MaskCompleted = False Then
            ErrorProvider1.SetError(txtPhone1, "Invalid Phone Number")
            MsgBox("Invalid Phone Number entered.", MsgBoxStyle.Exclamation)
            txtPhone1.SelectAll()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtDOA_MaskInputRejected(ByVal sender As Object,
                                         ByVal e As MaskInputRejectedEventArgs) Handles txtDOA.MaskInputRejected

    End Sub

    Private Sub txtDOA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDOA.Validating

        If txtDOA.MaskedTextProvider.AssignedEditPositionCount > 0 And txtDOA.MaskCompleted = False Then
            ErrorProvider1.SetError(txtDOA, "Invalid DOA")
            MsgBox("Invalid DOA entered.", MsgBoxStyle.Exclamation)
            txtDOA.SelectAll()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtTOA_MaskInputRejected(ByVal sender As Object,
                                         ByVal e As MaskInputRejectedEventArgs) Handles txtTOA.MaskInputRejected

    End Sub

    Private Sub txtTOA_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTOA.TextChanged
        ErrorProvider1.SetError(txtTOA, "")
    End Sub

    Private Sub txtTOA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTOA.Validating

        If txtTOA.MaskedTextProvider.AssignedEditPositionCount > 0 And txtTOA.MaskCompleted = False Then
            ErrorProvider1.SetError(txtTOA, "Invalid TOA")
            MsgBox("Invalid TOA entered.", MsgBoxStyle.Exclamation)
            txtTOA.SelectAll()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtDOB_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDOB.Validating

        If txtDOB.MaskedTextProvider.AssignedEditPositionCount > 0 And txtDOB.MaskCompleted = False Then
            ErrorProvider1.SetError(txtDOB, "Invalid DOB")
            MsgBox("Invalid DOB entered.", MsgBoxStyle.Exclamation)
            txtDOB.SelectAll()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtSSN_MaskInputRejected(ByVal sender As Object,
                                         ByVal e As MaskInputRejectedEventArgs) Handles txtSSN.MaskInputRejected

    End Sub

    Private Sub txtZip_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtZip.KeyPress

        txtAddress1.Tag = ""
    End Sub

    Private Sub txtZip_MaskInputRejected(ByVal sender As Object,
                                         ByVal e As MaskInputRejectedEventArgs) Handles txtZip.MaskInputRejected

    End Sub

    Private Sub txtSSN_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSSN.TextChanged
        ErrorProvider1.SetError(txtSSN, "")
    End Sub

    Private Sub txtSSN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSSN.Validating

        If txtSSN.MaskedTextProvider.AssignedEditPositionCount > 0 And txtSSN.MaskCompleted = False Then
            ErrorProvider1.SetError(txtSSN, "Invalid SSN")
            MsgBox("Invalid SSN entered.", MsgBoxStyle.Exclamation)
            txtSSN.SelectAll()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtZip_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtZip.TextChanged
        ErrorProvider1.SetError(txtZip, "")
    End Sub

    Private Sub txtZip_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtZip.Validating

        If txtZip.MaskedTextProvider.AssignedEditPositionCount > 0 And txtZip.MaskCompleted = False Then
            ErrorProvider1.SetError(txtZip, "Invalid Zip Code")
            MsgBox("Invalid Zip Code entered.", MsgBoxStyle.Exclamation)
            txtZip.SelectAll()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtCellPhone_MaskInputRejected(ByVal sender As Object,
                                               ByVal e As MaskInputRejectedEventArgs) Handles txtCellPhone.MaskInputRejected

    End Sub

    Private Sub txtCellPhone_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCellPhone.TextChanged

        ErrorProvider1.SetError(txtCellPhone, "")
    End Sub

    Private Sub txtCellPhone_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCellPhone.Validating

        If txtCellPhone.MaskedTextProvider.AssignedEditPositionCount > 0 And txtCellPhone.MaskCompleted = False Then
            ErrorProvider1.SetError(txtCellPhone, "Invalid Cell Phone")
            MsgBox("Invalid Cell Phone Number entered.", MsgBoxStyle.Exclamation)
            txtCellPhone.SelectAll()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtPhone2_MaskInputRejected(ByVal sender As Object,
                                            ByVal e As MaskInputRejectedEventArgs) Handles txtPhone2.MaskInputRejected

    End Sub

    Private Sub txtPhone2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPhone2.TextChanged
        ErrorProvider1.SetError(txtPhone2, "")
    End Sub

    Private Sub txtPhone2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPhone2.Validating

        If txtPhone2.MaskedTextProvider.AssignedEditPositionCount > 0 And txtPhone2.MaskCompleted = False Then
            ErrorProvider1.SetError(txtPhone2, "Invalid Phone2")
            MsgBox("Invalid Phone2 Number entered.", MsgBoxStyle.Exclamation)
            txtPhone2.SelectAll()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtEmployerPhone_MaskInputRejected(ByVal sender As Object,
                                                   ByVal e As MaskInputRejectedEventArgs) Handles txtEmployerPhone.MaskInputRejected

    End Sub

    Private Sub txtEmployerPhone_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtEmployerPhone.TextChanged

        ErrorProvider1.SetError(txtEmployerPhone, "")
    End Sub

    Private Sub txtEmployerPhone_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEmployerPhone.Validating

        If txtEmployerPhone.MaskedTextProvider.AssignedEditPositionCount > 0 And txtEmployerPhone.MaskCompleted = False _
            Then
            ErrorProvider1.SetError(txtEmployerPhone, "Invalid Employer Phone")
            MsgBox("Invalid Employer Phone Number entered.", MsgBoxStyle.Exclamation)
            txtEmployerPhone.SelectAll()
            e.Cancel = True
        End If
    End Sub

    Private Sub ContextMenuPopUpCalendar_DateSelected(ByVal sender As Object,
                                                      ByVal e As DateRangeEventArgs) Handles MonthCalendarPopUp.DateSelected

        ContextMenuPopUpCalendar.SourceControl.Text = MonthCalendarPopUp.SelectionStart.ToString("MM/dd/yyyy")
        ContextMenuPopUpCalendar.Hide()
    End Sub

    Private Sub DateTimePickerPopUp_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DateTimePickerPopUp.ValueChanged

    End Sub

    Private Sub SetTimeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SetTimeToolStripMenuItem.Click

        ContextMenuStripTime.SourceControl.Text = DateTimePickerPopUp.Value.ToString("HH:mm")
        ContextMenuStripTime.Hide()
    End Sub

    Private Sub SetCurrentTimeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SetCurrentTimeToolStripMenuItem.Click

        DateTimePickerPopUp.Value = Now
        ContextMenuStripTime.SourceControl.Text = DateTimePickerPopUp.Value.ToString("HH:mm")
        ContextMenuStripTime.Hide()
    End Sub

    Private Sub picPhoto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles picPhoto.Click
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub ToolStrip7_ItemClicked(ByVal sender As Object,
                                       ByVal e As ToolStripItemClickedEventArgs) Handles ToolStrip7.ItemClicked

    End Sub

    Private Sub TimerSearchPatients_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TimerSearchPatients.Tick

        TimerSearchPatients.Enabled = False
        Load_Patients()
        If ListViewPatients.Items.Count = 0 Then
            Clear_Controls()
            Validate_Billing_Data(True)
            LabelFound.Text = ""
        Else
            LabelFound.Text = "Found: " & ListViewPatients.Items.Count
        End If
        gListViewRestoreDefaultColumnWidth(ListViewPatients)
        TextBoxSearch.Focus()
    End Sub

    Private Sub FindPatientBillsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FindPatientBillsToolStripMenuItem.Click

        Dim PatientID As Integer
        If OpMode = AddEditMode.AddNew Then
            MsgBox("Unable to show the Patient's bills in Add New Patient mode.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewPatients.Items.Count = 0 Then
            MsgBox("Unable to show the Patient's bills. No Patient selected", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            PatientID = ListViewPatients.SelectedItems(0).Text
        End If
        Me.UseWaitCursor = True
        Cursor = Cursors.WaitCursor
        Label66.Text = "Loadintg. Please wait..."
        PanelWait.Visible = True
        PanelWait.Refresh()
        Label66.Refresh()
        Application.DoEvents()
        LockWindowUpdate(MDIForm1Win8.Handle)
        Application.DoEvents()
        Dim frm As Form = FormsCollection.FindForm("frmBillingManagement")
        If frm IsNot Nothing Then
            frm.Close()
            frm.Dispose()
        End If
        'If FormsCollection.FindForm("frmBillingManagement") Is Nothing Then
        '    frmBillingManagement.SearchPatientID = PatientID
        '    frmBillingManagement.MdiParent = MDIForm1Win8
        '    frmBillingManagement.Size = New Size(MDIForm1Win8.Width, MDIForm1Win8.Height)
        '    frmBillingManagement.WindowState = FormWindowState.Maximized
        '    Application.DoEvents()
        '    frmBillingManagement.Show()
        '    frmBillingManagement.BringToFront()
        '    frmBillingManagement.WindowState = FormWindowState.Maximized
        '    frmBillingManagement.ButtonFind_Click(Nothing, Nothing)
        'Else
        '    frmBillingManagement.SearchPatientID = PatientID
        '    frmBillingManagement.Show()
        '    frmBillingManagement.BringToFront()
        '    frmBillingManagement.WindowState = FormWindowState.Maximized
        '    frmBillingManagement.ButtonFind_Click(Nothing, Nothing)
        '    frmBillingManagement.BringToFront()
        'End If

        frmBillingManagement.SearchPatientID = PatientID
        frmBillingManagement.MdiParent = MDIForm1Win8
        'frmBillingManagement.Size = New Size(MDIForm1Win8.Width, MDIForm1Win8.Height)
        frmBillingManagement.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        frmBillingManagement.Show()
        frmBillingManagement.BringToFront()
        frmBillingManagement.WindowState = FormWindowState.Maximized
        frmBillingManagement.ButtonFind_Click(Nothing, Nothing)


        Me.UseWaitCursor = False
        Cursor = Cursors.Default
        PanelWait.Visible = False
        Label66.Text = "Validating Address. Please wait..."
        LockWindowUpdate(0)
        Me.WindowState = FormWindowState.Normal
        Me.SendToBack()
        frmBillingManagement.BringToFront()
        'Me.Close()
        'Me.Dispose()
    End Sub

    Private Sub ShowBillsToolBarButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ShowBillsToolBarButton.Click

        FindPatientBillsToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCheckAddress.Click
        Return
        'If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        If txtAddress1.Text = "" Then
            MsgBox("Unable to verify address. Incomplete address.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If gIsOnline() = False Then Exit Sub
        Cursor = Cursors.WaitCursor
        gShowWait(True, PanelWait, TabPage1)
        Application.DoEvents()
        Dim Addr As Address
        Dim RetAddr As Address
        Dim MapAddress As String
        Dim dlg As frmAddressDialog
        Addr.StreetAddress = txtAddress1.Text.Trim
        Addr.City = txtCity.Text.Trim
        Addr.State = ComboBoxState.Text.Trim
        Addr.Zip = txtZip.Text.Trim
        RetAddr = gVerifyAddress(Addr)
        If IsNothing(RetAddr) Then
            Cursor = Cursors.Default
            gShowWait(False, PanelWait)
            Exit Sub
        End If
        Select Case RetAddr.AddressType
            Case "OK"
                If RetAddr.Adjusted Then
                    TabControl1.SelectedIndex = 0

                    'http://maps.googleapis.com/maps/api/staticmap?center=444+Neptune+Avenue,Brooklyn,NY+11224&zoom=17&size=400x400&maptype=roadmap&markers=444+Neptune+Avenue,Brooklyn, NY+11224&sensor=false
                    MapAddress = Replace(RetAddr.StreetAddress, " ", "+")
                    MapAddress &= "," & Replace(RetAddr.City, " ", "+")
                    MapAddress &= "+" & RetAddr.State
                    dlg = New frmAddressDialog()
                    dlg.lblOriginal.Text = Addr.StreetAddress & ", " & Addr.City & ", " & Addr.State & " " & Addr.Zip
                    dlg.lblVerified.Text = RetAddr.StreetAddress & ", " & RetAddr.City & ", " & RetAddr.State & " " & RetAddr.Zip
                    Cursor = Cursors.Default
                    gShowWait(False, PanelWait)
                    dlg.ShowDialog(Me)
                    Dim RetResult As Integer = dlg.RetResult
                    dlg.Close()
                    dlg.Dispose()
                    dlg = Nothing
                    Select Case RetResult
                        Case 1
                            If OpMode = AddEditMode.None Then
                                cmdEdit_Click(Nothing, Nothing)
                            End If
                            txtAddress1.Text = RetAddr.StreetAddress
                            txtCity.Text = RetAddr.City
                            ComboBoxState.Text = RetAddr.State
                            txtZip.Text = RetAddr.Zip
                        Case 2

                        Case Else
                            txtAddress1.Focus()
                            Cursor = Cursors.Default
                            gShowWait(False, PanelWait)
                            Exit Sub
                    End Select
                Else
                    MsgBox("The specified address is correct.", MsgBoxStyle.Information)
                End If
                gShowWait(False, PanelWait)
                Cursor = Cursors.Default
            Case "ZERO_RESULTS", "NOMATCH"
                MsgBox(
                    "Unable to verify the Patient's address!" & vbCrLf & "Please check the address." & vbCrLf & vbCrLf &
                    vbCrLf & "Do not include Appartment/Suite/Unit in the street address field.",
                    MsgBoxStyle.Exclamation)
                TabControl1.SelectedIndex = 0
                txtAddress1.Focus()
                gShowWait(False, PanelWait)
                Cursor = Cursors.Default
                Exit Sub

        End Select
        Cursor = Cursors.Default
    End Sub

    Private Sub TimerRefreshWhenMaximized_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TimerRefreshWhenMaximized.Tick

        TimerRefreshWhenMaximized.Enabled = False
        TabPage1.Refresh()
        TabPage1.Invalidate()
    End Sub

    Private Sub txtCommentsNew_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCommentsNew.KeyUp

        LabelNotesLength.Text = 4000 - (txtCommentsNew.Text.Length + txtComments.Text.Length) & " Chars Remaining"
    End Sub

    Private Sub txtCommentsNew_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCommentsNew.TextChanged

    End Sub

    Private Sub ButtonProceduresAutosize_Click_2(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonProceduresAutosize.Click

        gListViewRestoreDefaultColumnWidth(ListViewProcedures)
        txtDummy.Focus()
    End Sub

    Private Sub ButtonReadingsAutoSize_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonReadingsAutoSize.Click

        gListViewRestoreDefaultColumnWidth(ListViewReadings)
        txtDummy.Focus()
    End Sub

    Private Sub ButtonAutosizeReadings_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAutosizeReadings.Click

        gListViewRestoreDefaultColumnWidth(ListViewPayments)
        txtDummy.Focus()
    End Sub

    Private Sub ButtonAutosizeBillComments_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAutosizeBillComments.Click

        gListViewRestoreDefaultColumnWidth(ListViewBillComments)
        txtDummy.Focus()
    End Sub

    Private Sub ButtonAutosizeCancelationLog_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAutosizeCancelationLog.Click

        gListViewRestoreDefaultColumnWidth(ListViewCancelations)
        txtDummy.Focus()
    End Sub

    Private Sub ButtonAutosizePatientProfileLog_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAutosizePatientProfileLog.Click

        gListViewRestoreDefaultColumnWidth(ListViewPatientLog)
        txtDummy.Focus()
    End Sub

    Private Sub ButtonAutosizeRequests_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAutosizeRequests.Click

        gListViewRestoreDefaultColumnWidth(ListViewRequests)
        txtDummy.Focus()
    End Sub

    Private Sub ButtonAutosizeRequestActions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAutosizeRequestActions.Click

        gListViewRestoreDefaultColumnWidth(ListViewActions)
        txtDummy.Focus()
    End Sub

    Private Sub ButtonAutosizeComments_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAutosizeComments.Click

        gListViewRestoreDefaultColumnWidth(ListViewComments)
        txtDummy.Focus()
    End Sub

    Private Sub ButtonAutosizeDocuments_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAutosizeDocuments.Click

        gListViewRestoreDefaultColumnWidth(ListViewDocs)
        txtDummy.Focus()
    End Sub

    Private Sub ButtonAutosizeIME_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAutosizeIME.Click

        gListViewRestoreDefaultColumnWidth(ListViewIME)
        txtDummy.Focus()
    End Sub

    Private Sub PreCertificationCompleteToolStripMenuItem_Click(ByVal sender As Object,
                                                                ByVal e As EventArgs) Handles PreCertificationCompleteToolStripMenuItem.Click

        Dim Li As ListViewItem
        Dim PatName As String
        Dim PreCertificationRequired As Boolean
        Dim ReCertDate As DateTime
        If ListViewProcedures.SelectedItems.Count = 0 Then Exit Sub
        Li = ListViewProcedures.SelectedItems(0)
        PatName = ListViewPatients.SelectedItems(0).SubItems(1).Text
        Using frm As New frmReCertificationExpDate
            frm.Label1.Text = "Please specify the Re-Cretification Expiration Date for" & vbCrLf & "Patient " & PatName & vbCrLf & "Procedure: " & Li.SubItems(1).Text
            If frm.ShowDialog(Me) <> DialogResult.OK Then
                Return
            End If
            ReCertDate = frm.DateTimePicker1.Value
        End Using

        'If _
        '    MsgBox(
        '        "Please confirm the Insurance Pre-Certification Verification has been completed for the following Patient/Procedure:" &
        '        vbCrLf & vbCrLf & "Patient " & PatName & vbCrLf & vbCrLf & "Procedure: " & Li.SubItems(1).Text,
        '        MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Li.SubItems(8).Text = ReCertDate.ToShortDateString
        Li.SubItems(8).BackColor = Color.LightGreen
        If Val(Li.SubItems(0).Tag) > 0 Then
            gSQLUpdateData(
                "Update PatientProcedures set PreCertificationDT = getdate() where PatientProcedureID = " &
                Li.SubItems(0).Tag)
        End If
        gUpdate_Profile_Log(CLng(ListViewPatients.SelectedItems(0).Tag), PatientLogTypes.tPreCertificationComplete,
                            "Procedure " & ListViewProcedures.SelectedItems(0).Text & " Pre-Certification Complete")

        For Each Li In ListViewProcedures.Items
            If IsDate(Li.SubItems(8).Text) = False Then
                PreCertificationRequired = True
            End If
        Next

        LabelPreCertification.Visible = PreCertificationRequired
    End Sub

    Private Sub PreCertificationNotCompleteToolStripMenuItem_Click(ByVal sender As Object,
                                                                   ByVal e As EventArgs) Handles PreCertificationNotCompleteToolStripMenuItem.Click

        Dim Li As ListViewItem
        Dim PatName As String
        Dim ApprovedByName As String
        If ListViewProcedures.SelectedItems.Count = 0 Then Exit Sub
        Li = ListViewProcedures.SelectedItems(0)
        PatName = ListViewPatients.SelectedItems(0).SubItems(1).Text
        If gCurrentEmployee.PositionID > 3 Then
            Dim frm As frmSupervisorApproval = New frmSupervisorApproval
            frm.LabelMsg.Text = "Pre-Certification Verification has Not been completed." & vbCrLf &
                                                  "Patient " & PatName & vbCrLf & "Procedure: " & Li.SubItems(1).Text
            If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frm.Dispose()
                frm = Nothing
                Exit Sub
            End If
            ApprovedByName = frm.SupervisorName
            frmSupervisorApproval.Dispose()
            frm = Nothing
        Else
            If _
                MsgBox(
                    "Please confirn the following Patient/Procedure:" & vbCrLf & vbCrLf & "Patient " & PatName & vbCrLf &
                    vbCrLf & "Procedure: " & Li.SubItems(1).Text & vbCrLf & vbCrLf &
                    "Pre-Certification Verification Has Not been completed?",
                    MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                frmSupervisorApproval.Dispose()
                Exit Sub
            End If
            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If
        Li.SubItems(8).Text = ""
        Li.SubItems(8).BackColor = Color.LightPink
        If Val(Li.SubItems(0).Tag) > 0 Then
            gSQLUpdateData(
                "Update PatientProcedures set PreCertificationDT = Null where PatientProcedureID = " &
                Li.SubItems(0).Tag)
        End If
        gUpdate_Profile_Log(CLng(ListViewPatients.SelectedItems(0).Tag), PatientLogTypes.tPreCertificationRemoved,
                            "Procedure " & ListViewProcedures.SelectedItems(0).Text & " Pre-Certification Not Completed",
                            ApprovedByName)
        LabelPreCertification.Visible = True
    End Sub

    Private Sub chkNF2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkNF2.CheckedChanged

    End Sub

    Private Sub ComboBoxInsuranceCompanyID1_SelectedIndexChanged(ByVal sender As Object,
                                                                 ByVal e As EventArgs) Handles ComboBoxInsuranceCompanyID1.SelectedIndexChanged

        ErrorProvider1.SetError(ComboBoxInsuranceCompanyID1, "")
        ComboBoxClaimAddress1.Items.Clear()
        ComboBoxClaimAddress1.Text = ""
        If ComboBoxInsuranceCompanyID1.SelectedIndex = -1 Then Exit Sub
        Dim Reader As SqlClient.SqlDataReader
        Cursor = Cursors.WaitCursor
        Reader =
            gSQLGetDataReaderAsync(
                "SELECT AddressID, AddressName + ' - ' + Address + ' ' + City + ' ' + State + ' ' + Zip AS ClaimAddress FROM         InsuranceCompanyAddresses WHERE ActiveInd=1 and CompanyID =" &
                CType(ComboBoxInsuranceCompanyID1.SelectedItem, ValueDescription).Value.ToString &
                " ORDER BY ClaimAddress").Result
        If Reader Is Nothing Then GoTo ExitSub
        Do Until Reader.Read = False
            ComboBoxClaimAddress1.Items.Add(New ValueDescription(CLng(Val(Reader("AddressID").ToString)), Reader("ClaimAddress").ToString))
        Loop
        If ComboBoxClaimAddress1.Items.Count = 1 Then
            ComboBoxClaimAddress1.SelectedIndex = 0
        End If
        Reader.Close()
        Reader.Dispose()
ExitSub:
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdAddInsuranceAddress1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddInsuranceAddress1.Click

        If gCurrentEmployee.PositionID > 3 Then
            Dim frm As frmSupervisorApproval = New frmSupervisorApproval
            frm.LabelMsg.Text = "Add New Insurance Claim Address"
            If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frm.Dispose()
                frm = Nothing
                Exit Sub
            End If
            frm.Dispose()
        End If
        If ComboBoxInsuranceCompanyID1.SelectedIndex = -1 Then
            MsgBox("Unable to add Insurance Address. Please select an Insurance Company first.", MsgBoxStyle.Exclamation)
            ComboBoxInsuranceCompanyID1.Focus()
            Exit Sub
        End If
        NewAddress = 0
        Dim frmis As frmInsuranceAddAddress = New frmInsuranceAddAddress
        frmis.CalledForm = Me
        frmis.InsCompanyID = CType(ComboBoxInsuranceCompanyID1.SelectedItem, ValueDescription).Value
        If frmis.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ComboBoxInsuranceCompanyID_SelectedIndexChanged(Nothing, Nothing)
            If NewAddress <> 0 Then
                gFindComboItemByValue(ComboBoxClaimAddress1, NewAddress, True)
            End If
        End If
        frmis.Dispose()
        frmis = Nothing
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click

        For Each lvi As ListViewItem In ListViewReadings.Items
            lvi.Checked = True
        Next
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectNoneToolStripMenuItem.Click

        For Each lvi As ListViewItem In ListViewReadings.Items
            lvi.Checked = False
        Next
    End Sub

    Private Sub ContextMenuStripReadings_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripReadings.Opening

        If ListViewReadings.Items.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ListViewRequests_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewRequests.ColumnClick

        Dim new_sorting_column As ColumnHeader = ListViewRequests.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As SortOrder
        If m_SortingColumnRequests Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumnRequests) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumnRequests.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumnRequests.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumnRequests.Text =             m_SortingColumnRequests.Text.Mid(2)
            m_SortingColumnRequests.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumnRequests = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumnRequests.Text = "> " & m_SortingColumnRequests.Text
        'Else
        'm_SortingColumnRequests.Text = "< " & m_SortingColumnRequests.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumnRequests.ImageKey = "SORT1"
        Else
            m_SortingColumnRequests.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewRequests.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewPatients.Sort()
    End Sub

    Private Sub ListViewActions_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewActions.ColumnClick

        Dim new_sorting_column As ColumnHeader = ListViewActions.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As SortOrder
        If m_SortingColumnRequestsAction Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumnRequestsAction) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumnRequestsAction.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumnRequestsAction.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumnRequestsAction.Text =             m_SortingColumnRequestsAction.Text.Mid(2)
            m_SortingColumnRequestsAction.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumnRequestsAction = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumnRequestsAction.Text = "> " & m_SortingColumnRequestsAction.Text
        'Else
        'm_SortingColumnRequestsAction.Text = "< " & m_SortingColumnRequestsAction.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumnRequestsAction.ImageKey = "SORT1"
        Else
            m_SortingColumnRequestsAction.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewActions.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewActions.Sort()
    End Sub

    Private Sub ListViewCancelations_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewCancelations.ColumnClick

        Dim new_sorting_column As ColumnHeader = ListViewCancelations.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As SortOrder
        If m_SortingColumnCancelations Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumnCancelations) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumnCancelations.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumnCancelations.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumnCancelations.Text =             m_SortingColumnCancelations.Text.Mid(2)
            m_SortingColumnCancelations.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumnCancelations = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumnCancelations.Text = "> " & m_SortingColumnCancelations.Text
        'Else
        'm_SortingColumnCancelations.Text = "< " & m_SortingColumnCancelations.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumnCancelations.ImageKey = "SORT1"
        Else
            m_SortingColumnCancelations.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewCancelations.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewCancelations.Sort()
    End Sub

    Private Sub ButtonWebPassword_Click(sender As Object, e As EventArgs) Handles ButtonWebPassword.Click
        Dim ApprovedByName As String
        Dim lvi As ListViewItem
        Dim NewPassword As String
        If ListViewPatients.SelectedItems.Count() = 0 Then
            MsgBox("Unable to process password reset." & vbCrLf & "No patient selected.", MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        lvi = ListViewPatients.SelectedItems(0)

        If OpMode = AddEditMode.AddNew Then
            MsgBox("Unable to process password reset." & vbCrLf & "The password will be generated automatically.",
                   MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If gCurrentEmployee.PositionID > 3 Then
            Dim frm As frmSupervisorApproval = New frmSupervisorApproval
            frm.LabelMsg.Text = "Patient Web Access Password Change!" &
                                                  vbCrLf & vbCrLf &
                                                  "Authorization Required!"
            If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frm.Dispose()
                frm = Nothing
                Exit Sub
            End If
            ApprovedByName = frm.SupervisorName
            frm.Dispose()
            frm = Nothing
        Else
            If _
                MsgBox("Please confirm you  want to reset the patient's web access password?",
                       MessageBoxButtons.YesNo + MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If
        Try
            NewPassword = gSQLGetSingleValueString("select [dbo].GenPassword(6)")
            gSQLUpdateData("update Patients set WebPassword = '" & NewPassword & "' Where PatientID = " & lvi.Text)
            gUpdate_Profile_Log(lvi.Text, PatientLogTypes.tUpdated,
                                "Web Access Password changed. New Password:" & NewPassword, ApprovedByName)
            TextBoxWebPassword.Text = NewPassword
            TextBoxWebPassword.Refresh()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        If _
            MsgBox("Print patient web access info?", MessageBoxButtons.YesNo + MessageBoxIcon.Question) =
            Windows.Forms.DialogResult.Yes Then
            PrintWebAccessInformation()
        End If
    End Sub

    Private Sub PrintWebAccessInformation()
        Try
            Dim ID As Long

            Dim CR As ReportDocument

            If ListViewPatients.SelectedItems.Count = 0 Then
                MsgBox("Unable to print the patient's Web Access Information." & vbCrLf & "No patient selected.",
                       MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            PanelPrinting.Visible = True
            Application.DoEvents()
            ID = ListViewPatients.SelectedItems(0).Tag
            Cursor = Cursors.WaitCursor
            CR = New rptPatientWebAccess

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            CR.SetParameterValue("PatientID", ID.ToString)
            If gPrinterNF3 <> "" Then CR.PrintOptions.PrinterName = gPrinterNF3
            CR.PrintToPrinter(1, False, 0, 0)

            Cursor = Cursors.Default
            PanelPrinting.Visible = False
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ButtonPrintWebAccess_Click(sender As Object, e As EventArgs) Handles ButtonPrintWebAccess.Click
        If ListViewPatients.SelectedItems.Count() = 0 Then
            MsgBox("Unable to print the patient's Web Access Information." & vbCrLf & "No patient selected.",
                   MessageBoxButtons.OK + MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If OpMode = AddEditMode.AddNew Then
            MsgBox(
                "Unable to print patient's web access information." & vbCrLf &
                "The web access information will be generated after profile update.",
                MessageBoxButtons.OK + MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        PrintWebAccessInformation()
    End Sub

    Private Sub ToolStripButtonNavigateWebAccess_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNavigateWebAccess.Click

        Process.Start(gOfficeURL)
    End Sub

    Private Sub ToolStripButtonEmailWebAccessInformation_Click(sender As Object, e As EventArgs) Handles ToolStripButtonFaxWebAccessInfo.Click

        Try
            Dim Subject As String
            Dim Fname As String
            Subject = "Attached: Web Access Information PDF File"
            Dim ID As Long
            Dim CR As ReportDocument
            Dim PatientName As String
            If ListViewPatients.SelectedItems.Count = 0 Then
                MsgBox("Unable to fax the patient's Web Access Information." & vbCrLf & "No patient selected.",
                       MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Application.DoEvents()
            ID = ListViewPatients.SelectedItems(0).Tag
            PatientName = ListViewPatients.SelectedItems(0).SubItems(1).Text
            Cursor = Cursors.WaitCursor
            CR = New rptPatientWebAccess

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            CR.SetParameterValue("PatientID", ID.ToString)
            If gPrinterNF3 <> "" Then CR.PrintOptions.PrinterName = gPrinterNF3
            Fname = IO.Path.Combine(IO.Path.GetTempPath, gFixFileName(PatientName) & " Web Access Information.pdf")
Recheck:
            If IO.File.Exists(Fname) Then
                Try
                    IO.File.Delete(Fname)
                Catch ex As Exception
                    Fname = IO.Path.GetTempFileName
                    Fname = Fname.Replace(".tmp", ".pdf")
                    GoTo Recheck
                End Try
            End If
            CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)
            gFax(Me, "", Subject, Fname, gOfficeFax)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButtonEmailWebAccessInformation.Click

        Try
            Dim Msg As New SendFileTo
            Dim Subject As String
            Dim Fname As String
            Subject = "Attached: Web Access Information PDF File"
            Dim ID As Long
            Dim CR As ReportDocument

            Dim PatientName As String
            If ListViewPatients.SelectedItems.Count = 0 Then
                MsgBox("Unable to email the patient's Web Access Information." & vbCrLf & "No patient selected.",
                       MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Application.DoEvents()
            ID = ListViewPatients.SelectedItems(0).Tag
            PatientName = ListViewPatients.SelectedItems(0).SubItems(1).Text
            Cursor = Cursors.WaitCursor
            CR = New rptPatientWebAccess

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            CR.SetParameterValue("PatientID", ID.ToString)
            If gPrinterNF3 <> "" Then CR.PrintOptions.PrinterName = gPrinterNF3
            Fname = IO.Path.Combine(IO.Path.GetTempPath, gFixFileName(PatientName) & " Web Access Information.pdf")
Recheck:
            If IO.File.Exists(Fname) Then
                Try
                    IO.File.Delete(Fname)
                Catch ex As Exception
                    Fname = IO.Path.GetTempFileName
                    Fname = Fname.Replace(".tmp", ".pdf")
                    GoTo Recheck
                End Try
            End If
            CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)
            Msg.SendMail(Fname, "Attached: " & PatientName & " Web Acccess Information", Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ComboBoxInsuranceCompanyID_KeyUp(sender As Object, e As KeyEventArgs)
        sSearchComboBox_KeyUp(ComboBoxInsuranceCompanyID, e, True)
    End Sub

    Private Sub ComboBoxInsuranceCompanyID_Leave(sender As Object, e As EventArgs)
        sSearchComboBox_Leave(ComboBoxInsuranceCompanyID, e)
    End Sub

    Private Sub frmPatient_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If Width < 1100 Then
            If ToolStripProcedures.Width > 40 Then
                ToolStripProcedures.Width = 31
                ButtonAddProcedure.Image = My.Resources.Add_New16
                ButtonDeleteProcedure.Image = My.Resources.Delete16
            End If
        Else
            If ToolStripProcedures.Width < 40 Then
                ToolStripProcedures.Width = 52
                ButtonAddProcedure.Image = My.Resources.Add_New32
                ButtonDeleteProcedure.Image = My.Resources.Delete32
            End If
        End If
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim InsuranceId As Long
        txtDummy.Focus()
        cboPatientAttorney.Text = cboPatientAttorney.Text
        If (cboPatientAttorney.Text.Length = 0) Then
            MsgBox("Unable to process your request." & vbCrLf & "No Patient's Attorney specified.", MsgBoxStyle.Critical, "Error")
            If cboPatientAttorney.CanFocus Then cboPatientAttorney.Focus()
            Return
        End If
        SQL = "SELECT CompanyID FROM InsuranceCompanies WHERE CaseTypeID = 5 AND CompanyName = '" & cboPatientAttorney.Text.ToSafeSQLString() & "'"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows = False Then
            MsgBox("Unable to process your request." & vbCrLf & "The specified Patient's Attorney is not found in the Lien attorneys list.", MsgBoxStyle.Critical, "Error")
            If cboPatientAttorney.CanFocus Then cboPatientAttorney.Focus()
            Return
        End If
        Reader.Read()
        InsuranceId = Reader("CompanyID")

        Dim frm As New frmInsuranceMaintenance
        frm.WindowState = FormWindowState.Normal
        frm.Location = New Point(Left + ((Width - frm.Size.Width) \ 2),
                                                         Top + ((Height - frm.Size.Height) \ 2))
        frm.PreSelectedInsuranceID = InsuranceId
        frm.TimerSearch.Enabled = True
        frm.ShowDialog(Me)
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub BtnAddPatientAttorney_Click(sender As Object, e As EventArgs) Handles BtnAddPatientAttorney.Click
        txtDummy.Focus()

        If gCurrentEmployee.PositionID > 3 Then
            Dim frmc As frmSupervisorApproval = New frmSupervisorApproval
            frmc.LabelMsg.Text = "Add New Patient's Attorney"
            If frmc.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frmc.Dispose()
                frmc = Nothing
                Exit Sub
            End If
            frmc.Dispose()
            frmc = Nothing
        End If
        Dim frm As New frmInsuranceMaintenance

        frm.WindowState = FormWindowState.Normal
        frm.Location = New Point(Left + ((Width - frm.Size.Width) \ 2),
                                                         Top + ((Height - frm.Size.Height) \ 2))
        frm.ComboBoxCaseTypes.SelectedValue = 5
        frm.TextBoxSearch.Text = "*"
        frm.AddNewFlag = True
        frm.AddNewCaseType = 5
        frm.TimerSearch.Enabled = True
        frm.ShowDialog(Me)
        frm.Dispose()
        frm = Nothing
        Load_Patient_Attorneys()
    End Sub

    Private Sub ToolStripFontIncrease_Click(sender As Object, e As EventArgs) Handles ToolStripFontIncrease.Click
        SetFont(1)
    End Sub

    Private Sub ToolStripFonrDecrease_Click(sender As Object, e As EventArgs) Handles ToolStripFonrDecrease.Click
        SetFont(-1)
    End Sub

    Private Sub ToolStripButtonRTF_Click(sender As Object, e As EventArgs)
        Dim f As String = Path.GetTempFileName()
        f = f.Mid(1, f.Length - 3) & "rtf"
        RichTextBox1.SaveFile(f)
        Dim objProcess As System.Diagnostics.Process
        Try
            objProcess = New System.Diagnostics.Process()
            objProcess.StartInfo.FileName = f
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            objProcess.Start()
            'Wait until the process passes back an exit code
            objProcess.WaitForExit()
            'Free resources associated with this process
            objProcess.Close()
            RichTextBox1.LoadFile(f)

            Dim doc As RTFDocument = DirectCast(RichTextBox1.Tag, RTFDocument)
            doc.Data = RichTextBox1.Rtf
            doc.DocDate = Now
            Dim TA As New SqlClient.SqlDataAdapter("SELECT * FROM PatientRTFDocuments Where ID = " & doc.ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("PatientRTFDocuments")
            TA.Fill(dTab)
            TR = dTab.Rows(0)
            TR("Data") = doc.Data
            TR("DocDate") = doc.DocDate
            TA.UpdateCommand = CB.GetUpdateCommand(True)
            Try
                TA.Update(dTab)
                dTab.AcceptChanges()
                gUpdate_Profile_Log(doc.PatientID, PatientLogTypes.tOther, doc.DocName & " - Opened/Updated")
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
                Exit Sub
            End Try
            dTab.Dispose()
            CB.Dispose()
            TA.Dispose()
            Kill(f)
        Catch ex As Exception
            log.Error("ToolStripButtonRTF_Click", ex)
            MsgBox(ex.Message, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolStripMenuAddLetter_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        checkPrint = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        checkPrint = RichTextBox1.Print(checkPrint, RichTextBox1.TextLength, e)

        ' Look for more pages
        If checkPrint < RichTextBox1.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub



    Private Sub ContextMenuStripDocuments_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripDocuments.Opening
        Dim Ret As String
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Or ListViewDocs.SelectedItems.Count = 0 Then
            e.Cancel = True
            Exit Sub
        End If
        LI = ListViewDocs.SelectedItems(0)
        Select Case Val(LI.SubItems(1).Tag)
            Case 6, 18 ' POM ' CDPOM
                ToolStripMenuItemRenameDocument.Visible = False
                ToolStripMenuItemRenameDocumentBar.Visible = False
            Case Else
                ToolStripMenuItemRenameDocument.Visible = True
                ToolStripMenuItemRenameDocumentBar.Visible = True
        End Select
    End Sub

    Private Sub ToolStripMenuItemRenameDocument_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemRenameDocument.Click
        ListViewDocs_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItemDeleteDocument_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDeleteDocument.Click
        ButtonDeleteDocument_Click(Nothing, Nothing)
    End Sub

    Private Sub NetSearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NetSearchToolStripMenuItem.Click
        Application.DoEvents()
        Dim frm As frmNetSearch = New frmNetSearch
        If ListViewPatients.SelectedItems.Count > 0 Then
            frm.ExternalSearchPatientName = ListViewPatients.SelectedItems(0).SubItems(1).Text
        End If

        frm.MinimizeBox = False
        frm.MaximizeBox = False
        frm.ShowDialog(Me)
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub ButtonRotatePDF_Click(sender As Object, e As EventArgs) Handles ButtonRotatePDF.Click
        txtDummy.Focus()
        If ListViewDocs.SelectedItems.Count = 0 Then
            Return
        End If
        If pdfViewer.Document Is Nothing Or pdfViewer.Renderer Is Nothing Then
            Return
        End If
        On Error GoTo er
        pdfViewer.Renderer.RotateRight()
        pdfViewer.Refresh()
er:
    End Sub

    Private Sub MenuPDFRotate_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MenuPDFRotate.Opening
        If ListViewDocs.SelectedItems.Count = 0 Or RichTextBox1.Visible Then
            e.Cancel = True
        End If
        If pdfViewer.Document Is Nothing Or pdfViewer.Renderer Is Nothing Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        On Error GoTo er
        pdfViewer.Renderer.Rotation = PdfiumViewer.PdfRotation.Rotate0
        pdfViewer.Refresh()
er:
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        On Error GoTo er
        pdfViewer.Renderer.Rotation = PdfiumViewer.PdfRotation.Rotate90
        pdfViewer.Refresh()
er:

    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        On Error GoTo er
        pdfViewer.Renderer.Rotation = PdfiumViewer.PdfRotation.Rotate180
        pdfViewer.Refresh()
er:

    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        On Error GoTo er
        pdfViewer.Renderer.Rotation = PdfiumViewer.PdfRotation.Rotate270
        pdfViewer.Refresh()
er:

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub ToolStripMenuItem3_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click

        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to print Patient's Photo Label." & vbCrLf & "No patient selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim ID As Long = ListViewPatients.SelectedItems(0).Tag

        If ListViewProcedures.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If


        If ComboBoxCaseStatusID.SelectedIndex > -1 Then
            If CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value <> 1 Then
                MsgBox(
                    "Unable to modify the Patient's profile when the case status is " &
                    CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Description & ".",
                    MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If

        Dim BillID As Integer = gSQLGetSingleValue("SELECT     BillId AS C FROM BillProcedures WHERE PatientProcedureID = " & Val(ListViewProcedures.SelectedItems(0).SubItems(0).Tag))
        If BillID > 0 Then
            MsgBox("Unable to replace selected procedure." & vbCrLf & "This procedure is assigned to the bill #: " & BillID, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim frm As frmReplaceProcedure = New frmReplaceProcedure
        frm.LabelProcedure.Text = ListViewProcedures.SelectedItems(0).SubItems(1).Text.ToUpper
        frm.OldProcName = ListViewProcedures.SelectedItems(0).SubItems(1).Text
        frm.CaseType = CInt(CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value)
        frm.PatientID = ID
        frm.PatientProcedureID = ListViewProcedures.SelectedItems(0).SubItems(0).Tag
        frm.OldProcId = ListViewProcedures.SelectedItems(0).Tag
        frm.CalledListViewProcedures = ListViewProcedures
        frm.CalledFrom = "PatientMaintenance"

        frm.ShowDialog(Me)
        frm.Dispose()
        frm = Nothing

    End Sub

    Private Sub ComboBoxEmploymentStatusID_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxEmploymentStatusID.SelectedValueChanged
        CheckBoxNoMoreCollection.Enabled = False
        If Not ComboBoxCaseStatusID.SelectedItem Is Nothing Then
            CheckBoxNoMoreCollection.Enabled = Not CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 1 And Not CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 4
            If CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 1 Or CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 4 Then
                CheckBoxNoMoreCollection.Checked = False
            End If
        End If
        txtEmployerName.AccessibleDescription = ""
        txtEmployerName.AccessibleName = ""
        txtEmployerAddress.AccessibleDescription = ""
        txtEmployerAddress.AccessibleName = ""
        txtEmployerAddressCity.AccessibleDescription = ""
        txtEmployerAddressCity.AccessibleName = ""
        cboEmployerAddressState.AccessibleDescription = ""
        cboEmployerAddressState.AccessibleName = ""
        txtEmployerAddressZip.AccessibleDescription = ""
        txtEmployerAddressZip.AccessibleName = ""
        If Not ComboBoxEmploymentStatusID.SelectedItem Is Nothing And Not ComboBoxCaseTypeID.SelectedItem Is Nothing Then
            If CType(ComboBoxEmploymentStatusID.SelectedItem, ValueDescription).Value = 1 And Val(CType(ComboBoxCaseTypeID.SelectedItem, ValueDescription).Value) = 2 Then
                txtEmployerName.AccessibleDescription = "1"
                txtEmployerName.AccessibleName = "1"
                txtEmployerAddress.AccessibleDescription = "1"
                txtEmployerAddress.AccessibleName = "1"
                txtEmployerAddressCity.AccessibleDescription = "1"
                txtEmployerAddressCity.AccessibleName = "1"
                cboEmployerAddressState.AccessibleDescription = "1"
                cboEmployerAddressState.AccessibleName = "1"
                txtEmployerAddressZip.AccessibleDescription = "1"
                txtEmployerAddressZip.AccessibleName = "1"


            End If

        End If
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        Dim LI As ListViewItem
        Dim ShiftWCTab As Integer = 1
        'If TabControl1.TabPages.ContainsKey("TabPageWC") = True Then
        '    ShiftWCTab = 0
        'End If
        If gOfficeTypeID = 2 Then Exit Sub
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        If ListViewProcedures.SelectedItems.Count = 0 Then Exit Sub
        LI = ListViewProcedures.SelectedItems(0)
        If gSQLGetSingleValue("SELECT COUNT(*) AS C  FROM BillProcedures  WHERE PatientProcedureID = " & Val(LI.SubItems(0).Tag)) > 0 Then
            MsgBox(
                "Unable to change the Procedure Treating Provider." & vbCrLf &
                "This procedure is already has been billed.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If gCurrentEmployee.PositionID > 3 Then
            Dim frm As frmSupervisorApproval = New frmSupervisorApproval
            frm.LabelMsg.Text = "Change Procedure Treating Provider."
            If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frm.Dispose()
                frm = Nothing
                Exit Sub
            End If
            frm.Dispose()
            frm = Nothing
        Else
        End If
        Dim frmrd As frmPatientTreatingProviderPopUp = New frmPatientTreatingProviderPopUp
        frmrd.ProcedureID = Val(LI.SubItems(0).Tag)
        frmrd.TreatingProvider = Val(LI.SubItems(2).Tag)
        frmrd.StartPosition = FormStartPosition.CenterParent
        frmrd.lblCurrentProvider.Text = LI.SubItems(2).Text
        If frmrd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If frmrd.ComboBoxTreatingProviderID.SelectedIndex > -1 Then
                LI.SubItems(2).Text = CType(frmrd.ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Description
                LI.SubItems(2).Tag = CType(frmrd.ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Value
            Else
                LI.SubItems(2).Text = frmrd.ComboBoxTreatingProviderID.Text
            End If
            gSQLUpdateData(
                "UPDATE PatientProcedures Set TreatingProviderID=" & LI.SubItems(2).Tag.ToString().ToSafeSQLString() & " Where PatientProcedureID = " & Val(LI.SubItems(0).Tag))

        End If
        frmrd.Dispose()
        frmrd = Nothing
    End Sub

    Private Sub ImportPatientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportPatientsToolStripMenuItem.Click
        If frmImportPat.IsDisposed Then
            frmImportPat = New frmImportPatients()
        End If


        frmImportPat.MdiParent = Me.MdiParent
        frmImportPat.CallerForm = Me
        Me.WindowState = FormWindowState.Normal
        Me.Left = frmImportPat.Width
        frmImportPat.Left = 0
        frmImportPat.Top = Top
        frmImportPat.Height = Height
        frmImportPat.TopMost = True
        frmImportPat.Left = 0
        frmImportPat.Top = Top
        frmImportPat.Show()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If ListViewDocs.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Document selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        'For windows 11, to return old style dialog, use Command Prompt,
        'reg add "HKCU\Software\Microsoft\Print\UnifiedPrintDialog" /v "PreferLegacyPrintDialog" /d 1 /t REG_DWORD /f

        Using PrintDialog1 As PrintDialog = New PrintDialog

            If Val(ListViewDocs.SelectedItems(0).SubItems(1).Tag) = 999 Then
                PrintDialog1.Document = PrintDocument1
                If PrintDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    PrintDocument1.Print()
                End If
            Else
                If pdfViewer.Tag = "" Then
                    MsgBox("Unable to process your request. No Document Loaded.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                ' WINDOWS 11 HAS PROBLEM PRINTING - TEST USING ANOTHER DIALOG
                Dim p = pdfViewer.Document.CreatePrintDocument
                AddHandler p.PrintPage, AddressOf Pdf_PrintPage
                Using ppvPreview As New PrintPreviewDialog
                    ppvPreview.Document = p
                    ppvPreview.Width = 500
                    ppvPreview.Height = 600
                    ppvPreview.StartPosition = FormStartPosition.CenterParent
                    ppvPreview.FindForm.WindowState = FormWindowState.Normal
                    If IsNothing(Owner) Then
                        ppvPreview.ShowDialog()
                    Else
                        ppvPreview.ShowDialog(Owner)
                    End If
                    ppvPreview.Dispose()
                End Using
            End If
        End Using
        GC.Collect()
    End Sub

    Private Sub ComboBoxCaseStatusID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCaseStatusID.SelectedIndexChanged
        CheckBoxNoMoreCollection.Enabled = False
        If Not ComboBoxCaseStatusID.SelectedItem Is Nothing Then
            CheckBoxNoMoreCollection.Enabled = Not CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 1 And Not CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 4
            If CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 1 Or CType(ComboBoxCaseStatusID.SelectedItem, ValueDescription).Value = 4 Then
                CheckBoxNoMoreCollection.Checked = False
            End If
        End If
    End Sub

End Class