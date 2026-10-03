Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports log4net
Imports System.ComponentModel

Public Class frmBillingManagement
    Private Loading As Boolean
    Private SkipCal As Boolean
    Private SkipDays As Boolean
    Private m_SortingColumn As ColumnHeader
    Private btp_SortingColumn As ColumnHeader
    Private a_SortingColumn As ColumnHeader
    Public SearchBillID As String
    Public SearchPatientID As Integer
    Public InitialPatientNo As Integer
    Public InitialBillNo As Integer
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmBillingManagement_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmBillingManagement_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        With My.Application.Info
            SaveSetting(.ProductName, "Settings", "BillingDateFrom", DateTimePickerFrom.Value)
            SaveSetting(.ProductName, "Settings", "BillingDateTo", DateTimePickerTo.Value)
            SaveSetting(.ProductName, "Settings", "BillingManagementCaseType", cboCaseTypeID.SelectedIndex)
            SaveSetting(.ProductName, "Settings", "BillingPatientBills", PanelShowBills.Visible)
            SaveSetting(.ProductName, "Settings", "BillingDateFromChecked", DateTimePickerFrom.Checked)
            SaveSetting(.ProductName, "Settings", "BillingDateToChecked", DateTimePickerTo.Checked)
            SaveSetting(.ProductName, "Settings", "DateTimePaymentFromChecked", DateTimePaymentFrom.Checked)
            SaveSetting(.ProductName, "Settings", "DateTimePaymentToChecked", DateTimePaymentTo.Checked)
            SaveSetting(.ProductName, "Settings", Me.Name & "SplitterDistance", SplitContainer1.SplitterDistance)
            gListview_Settings(Me, ListViewBillToPatient, ReadWrite.sWrite)
            gListview_Settings(Me, ListViewDenials, ReadWrite.sWrite)
            gListview_Settings(Me, ListViewPatients, ReadWrite.sWrite)
            gListview_Settings(Me, ListViewComments, ReadWrite.sWrite)
            gListview_Settings(Me, ListViewAttention, ReadWrite.sWrite)
            gListview_Settings(Me, ListViewRequests, ReadWrite.sWrite)
            gListview_Settings(Me, ListViewPatientComments, ReadWrite.sWrite)
        End With

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Hide()
        End If
    End Sub

    Private Sub frmBillingManagement_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            ButtonFind_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub frmBillingManagement_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Public PreselectStatus As Integer = 0

    Private Sub SetFont(Optional incr As Integer = 0)
        Dim BaseSize = 8
        If BaseSize + My.Settings.FontSize + incr < 8 Or BaseSize + My.Settings.FontSize + incr > 15 Then Return
        My.Settings.FontSize = My.Settings.FontSize + incr
        My.Settings.Save()
        Dim F = New Font(Font.FontFamily, BaseSize + My.Settings.FontSize, FontStyle.Regular)
        ListViewAttention.Font = F
        ListViewPatients.Font = F
        ListViewPayments.Font = F
        ListViewRequests.Font = F
        TreeViewBills.Font = F
        ListViewDocs.Font = F
        ListViewDenials.Font = F
        ListViewPatientComments.Font = F
        TextBoxCommentView.Font = F
    End Sub

    Public Sub frmBillingManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmBillingManagementInstance = Me
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        gToolStripSettings(Me, ToolStrip2, ReadWrite.sRead)
        If gCurrentEmployee.PositionID > 3 Then ToolStrip2.ContextMenuStrip = Nothing

        SplitContainer1.Panel1Collapsed = True
        Dim ShowBills = GetSetting(My.Application.Info.ProductName, "Settings", "BillingPatientBills", True)
        PanelShowBills.Visible = ShowBills
        SplitContainer2.Panel2Collapsed = ShowBills
        DateTimePickerFrom.MaxDate = Now.Date
        DateTimePickerTo.MaxDate = Now.Date
        If PreselectStatus = 0 Then
            With My.Application.Info
                DateTimePickerFrom.Value = GetSetting(.ProductName, "Settings", "BillingDateFrom", DateAdd(DateInterval.Day, -7, Now.Date))
                DateTimePickerTo.Value = GetSetting(.ProductName, "Settings", "BillingDateTo", Now.Date)
                DateTimePaymentFrom.Value = GetSetting(.ProductName, "Settings", "DateTimePaymentFrom", DateAdd(DateInterval.Day, -30, Now.Date))
                DateTimePaymentTo.Value = GetSetting(.ProductName, "Settings", "DateTimePaymentTo", Now.Date)
                SplitContainer1.SplitterDistance = GetSetting(.ProductName, "Settings", Me.Name & "SplitterDistance", 250)
                DateTimePaymentFrom.MaxDate = Now.Date
                DateTimePaymentTo.MaxDate = Now.Date
                DateTimePaymentFrom.Checked = False
                DateTimePaymentTo.Checked = False

                'DateTimePickerFrom.Checked = GetSetting(.ProductName, "Settings", "BillingDateFromChecked", True)
                'DateTimePickerTo.Checked = GetSetting(.ProductName, "Settings", "BillingDateToChecked", True)
                'DateTimePaymentFrom.Checked = GetSetting(.ProductName, "Settings", "DateTimePaymentFromChecked", False)
                'DateTimePaymentTo.Checked = GetSetting(.ProductName, "Settings", "DateTimePaymentToChecked", False)
                DateTimePickerFrom.Checked = False
                DateTimePickerTo.Checked = False
                DateTimePaymentFrom.Checked = False
                DateTimePaymentTo.Checked = False

            End With

        End If
        If gOfficeTypeID = 2 Then
            mnuPrintSelectedBillReadings2.Visible = False
            ToolStripSeparator17.Visible = False
            mnuPrintSelectedBillReadings.Visible = False
            PrintCheckedBillsReadingsToolStripMenuItem.Visible = False
            PrintCheckedBillsReadingsToolStripMenuItem1.Visible = False
        End If
        Application.DoEvents()
        m_SortingColumn = ListViewPatients.Columns(1)
        a_SortingColumn = ListViewAttention.Columns(0)
        btp_SortingColumn = ListViewBillToPatient.Columns(0)
        Loading = True
        Load_Data()
        Setup_Comboboxes()
        Loading = False
        SetFont()

        gListview_Settings(Me, ListViewPatients, ReadWrite.sRead)
        gListview_Settings(Me, ListViewComments, ReadWrite.sRead)
        gListview_Settings(Me, ListViewAttention, ReadWrite.sRead)
        gListview_Settings(Me, ListViewRequests, ReadWrite.sRead)
        gListview_Settings(Me, ListViewBillToPatient, ReadWrite.sRead)
        gListview_Settings(Me, ListViewDenials, ReadWrite.sRead)
        gListview_Settings(Me, ListViewPatientComments, ReadWrite.sRead)

        Count_Selected()
        If PreselectStatus > 0 Then
            ButtonClear_Click(Nothing, Nothing)
            gFindComboItemByValue(cboBillStatus, PreselectStatus, True)
            ButtonFind_Click(Nothing, Nothing)
            PreselectStatus = 0
        End If
        If SearchBillID = "" And SearchPatientID = 0 Then TimerCheckWarnings.Enabled = True
        'Bill Lost
        ToolStripButton9.Visible = gCurrentEmployee.PositionID < 4
        ToolStripSeparator34.Visible = gCurrentEmployee.PositionID < 4
        If InitialPatientNo > 0 Or InitialBillNo > 0 Then
            txtPatient.Text = InitialPatientNo
            If InitialBillNo > 0 Then
                txtBillNumber.Text = InitialBillNo
            End If
            ButtonFind_Click(Nothing, Nothing)
        End If
        ToolStripButtoneFile.Visible = gEnableElectronicBillFiling > 0
    End Sub

    Public Sub Show_Patient(PatId As String)
        ButtonClear_Click(Nothing, Nothing)
        cboBillStatus.SelectedIndex = 0
        txtPatient.Text = PatId
        ButtonFind_Click(Nothing, Nothing)
    End Sub

    Public Sub Show_Bill(PatId As String, BillId As String)
        ButtonClear_Click(Nothing, Nothing)
        cboBillStatus.SelectedIndex = 0
        txtPatient.Text = PatId
        txtBillNumber.Text = BillId
        ButtonFind_Click(Nothing, Nothing)
    End Sub

    Private Sub Setup_Comboboxes()
        AddHandler cboInsuranceCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboInsuranceCompanyID.Leave, AddressOf sSearchComboBox_Leave
        AddHandler cboAttorneysCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboAttorneysCompanyID.Leave, AddressOf sSearchComboBox_Leave

        AddHandler cboCaseTypeID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboCaseTypeID.Leave, AddressOf sSearchComboBox_Leave

        AddHandler cboBillStatus.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboBillStatus.Leave, AddressOf sSearchComboBox_Leave

        AddHandler cboBillingCompany.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboBillingCompany.Leave, AddressOf sSearchComboBox_Leave

    End Sub

    Private Sub Load_Data()
        Dim I As Integer = 0
        Dim Reader As SqlClient.SqlDataReader
        Try
            cboBillingProvider.Items.Clear()
            cboBillingProvider.Items.Add(New ValueDescription("0", "All"))
            Reader = gSQLGetDataReader("SELECT     EmpID, Fname+' '+Lname+' '+ Alias as DName From Employees WHERE (BillingPrv = 1) and EmpID in (select EmpID from EmployeeOffice where OfficeID=" & gOfficeID & ")")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboBillingProvider.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("DName").ToString))
            Loop
            Reader.Close() : Reader.Dispose()

            ComboBoxRefOffice.Items.Clear()
            ComboBoxRefOffice.Items.Add(New ValueDescription("0", "All"))
            Reader = gSQLGetDataReader("SELECT OfficeID, OfficeName FROM ReferringOffices WHERE sysOfficeID = " & gOfficeID & " ORDER BY OfficeName")

            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxRefOffice.Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)), Reader("OfficeName").ToString))
            Loop
            Reader.Close() : Reader.Dispose()

            cboPaymentNote.Items.Clear()
            cboPaymentNote.Items.Add(New ValueDescription("0", "All"))
            Reader = gSQLGetDataReader("SELECT     BillPaymentNotes.NoteID, BillPaymentNotes.Description + ' - ' + BillPaymentNotesType.Description AS Description FROM BillPaymentNotes INNER JOIN BillPaymentNotesType ON BillPaymentNotes.NoteTypeID = BillPaymentNotesType.NoteTypeID ORDER BY Description")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboPaymentNote.Items.Add(New ValueDescription(CLng(Val(Reader("NoteID").ToString)), Reader("Description").ToString))
            Loop
            Reader.Close() : Reader.Dispose()

            cboDenial.Items.Clear()
            cboDenial.Items.Add(New ValueDescription("0", "None"))
            Reader = gSQLGetDataReader("SELECT     ID, Description FROM BillDenialReasons ORDER BY SortOrder")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboDenial.Items.Add(New ValueDescription(CLng(Val(Reader("ID").ToString)), Reader("Description").ToString))
            Loop
            Reader.Close() : Reader.Dispose()

            cboLienAttorney.Items.Clear()
            cboLienAttorney.Items.Add(New ValueDescription("0", "All Liens"))
            Reader = gSQLGetDataReader("SELECT        CompanyID, ltrim(rtrim(CompanyName)) as CompanyName FROM InsuranceCompanies WHERE CaseTypeID = 5 ORDER BY CompanyName")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboLienAttorney.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString))
            Loop
            Reader.Close() : Reader.Dispose()

            cboCaseTypeID.Items.Clear()
            cboCaseTypeID.Items.Add(New ValueDescription("0", "All (Not Cash)"))
            Reader = gSQLGetDataReader("Select CaseTypeID, Abbreviation from CaseTypes")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboCaseTypeID.Items.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)), Reader("Abbreviation").ToString))
            Loop
            Reader.Close() : Reader.Dispose()
            Dim AttotneyInd As Boolean = False
            cboBillStatus.Items.Clear()
            cboBillStatus.Items.Add(New ValueDescription("0", "All"))
            cboBillStatus.Items.Add(New ValueDescription("-1", "All Active"))
            Reader = gSQLGetDataReader("SELECT     BillStatusID, Description FROM         BillStatus ")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                If Reader("BillStatusID") = 4 Or Reader("BillStatusID") = 5 Then
                    If AttotneyInd = False Then
                        AttotneyInd = True
                        cboBillStatus.Items.Add(New ValueDescription(-10, "Attorney"))
                    End If
                ElseIf Reader("BillStatusID") = 3 Then   'Paid
                    cboBillStatus.Items.Add(New ValueDescription(CLng(Val(Reader("BillStatusID").ToString)), Reader("Description").ToString))
                    cboBillStatus.Items.Add(New ValueDescription("-60", "Paid With Balance"))
                ElseIf Reader("BillStatusID") = 10 Then
                    'Do Nothing - Will Be Added Later - Litigation
                ElseIf Reader("BillStatusID") = 11 Then
                    'Do Nothing - Will Be Added Later - Arbitration
                Else
                    cboBillStatus.Items.Add(New ValueDescription(CLng(Val(Reader("BillStatusID").ToString)), Reader("Description").ToString))
                End If
            Loop
            cboBillStatus.Items.Add(New ValueDescription("-99", "----------------------------------------------"))
            cboBillStatus.Items.Add(New ValueDescription("-20", "Not Answered"))
            cboBillStatus.Items.Add(New ValueDescription("-30", "No More Collection"))
            cboBillStatus.Items.Add(New ValueDescription("-99", "----------------------------------------------"))
            cboBillStatus.Items.Add(New ValueDescription(10, "Filed Litigation"))
            cboBillStatus.Items.Add(New ValueDescription(11, "Filed Arbitration"))
            cboBillStatus.Items.Add(New ValueDescription(-40, "All Not Filed"))
            cboBillStatus.Items.Add(New ValueDescription("-99", "----------------------------------------------"))
            cboBillStatus.Items.Add(New ValueDescription(-50, "Attorney Fees Paid"))
            cboBillStatus.Items.Add(New ValueDescription(-51, "Attorney Fees Not Paid"))
            cboBillStatus.Items.Add(New ValueDescription("-99", "----------------------------------------------"))
            cboBillStatus.Items.Add(New ValueDescription(-61, "e-Filed"))
            Reader.Close() : Reader.Dispose()
            With cboAttorneysCompanyID.Items
                .Clear()
                .Add(New ValueDescription("0", ""))
                .Add(New ValueDescription("-1", "All Attorney Bills Only"))
                .Add(New ValueDescription("-2", "Attorney Confirmed Bills Only"))
                .Add(New ValueDescription("-3", "Attorney Not Confirmed Bills Only"))
                .Add(New ValueDescription("-99", "----------------------------------------------"))
                Reader = gSQLGetDataReader("Select CompanyID, CompanyName, AttorneyFName+' '+AttorneyLName as AttorneyName from Attorneys Where OfficeID=" & gOfficeID)
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    .Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString & " - " & Reader("AttorneyName").ToString))
                Loop
            End With
            Reader.Close() : Reader.Dispose()

            cboBillingCompany.Items.Clear()
            cboBillingCompany.Items.Add(New ValueDescription("-1", "All"))
            Reader = gSQLGetDataReader("SELECT     BillingCompanyID, CompanyName FROM         BillingCompanies ORDER BY CompanyName")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboBillingCompany.Items.Add(New ValueDescription(CLng(Val(Reader("BillingCompanyID").ToString)), Reader("CompanyName").ToString))
            Loop
            Reader.Close() : Reader.Dispose()

            cboDiagnostic.Items.Clear()
            cboDiagnostic.Items.Add(New ValueDescription("-1", "All"))
            Reader = gSQLGetDataReader("SELECT     DiagID, DiagName FROM Diagnostics WHERE ActiveInd=1 ORDER BY DiagName")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboDiagnostic.Items.Add(New ValueDescription(CLng(Val(Reader("DiagID").ToString)), Reader("DiagName").ToString))
            Loop
            Reader.Close() : Reader.Dispose()

            cboCaseTypeID.SelectedIndex = CInt(GetSetting(My.Application.Info.ProductName, "Settings", "BillingManagementCaseType", "0"))
            cboAttorneysCompanyID.SelectedIndex = 0
            If cboBillStatus.SelectedIndex > 1 Or cboBillStatus.SelectedIndex = -1 Then cboBillStatus.SelectedIndex = 1
            cboBillingProvider.SelectedIndex = 0
            cboDiagnostic.SelectedIndex = 0
            cboBillingCompany.SelectedIndex = 0
            cboPaymentNote.SelectedIndex = 0
            ComboBoxRefOffice.SelectedIndex = 0
            cboDenial.SelectedIndex = 0

            cboBillStatus.DropDownWidth = 120
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Public Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        txtPatient.Text = ""
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        DateTimePaymentFrom.Checked = False
        DateTimePaymentTo.Checked = False
        DateTimePickerAttorneyFrom.Checked = False
        DateTimePickerAttorneyTo.Checked = False
        cboAttorneysCompanyID.SelectedIndex = 0
        cboPaymentNote.SelectedIndex = 0
        cboDenial.SelectedIndex = 0
        cboBillStatus.SelectedIndex = 1
        cboCaseTypeID.SelectedIndex = 0
        cboInsuranceCompanyID.SelectedIndex = 0
        cboBillingCompany.SelectedIndex = 0
        cboBillingProvider.SelectedIndex = 0
        ListViewPatients.Items.Clear()
        ListViewComments.Items.Clear()
        cboDiagnostic.SelectedIndex = 0
        cboBillingCompany.SelectedIndex = 0
        ComboBoxRefOffice.SelectedIndex = 0
        TreeViewBills.Nodes.Clear()
        ListViewDocs.Items.Clear()
        ListViewDenials.Items.Clear()
        cboLienAttorney.Text = ""
        cboLienAttorney.SelectedIndex = -1
        txtComments.Text = ""
        txtPatientComments.Text = ""
        txtBillNumber.Text = ""
        Count_Selected()
        ListViewPatients.Focus()
    End Sub

    Public Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        ToolStripButtoneFile.Visible = gEnableElectronicBillFiling
        ButtonFind.Enabled = False
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        TableLayoutPanel1.Enabled = False
        ListViewPatients.BeginUpdate()
        Find_Patients()
        SearchBillID = ""
        SearchPatientID = 0
        ListViewPatients.EndUpdate()
        ButtonFind.Enabled = True
        TableLayoutPanel1.Enabled = True
        Cursor = Cursors.Default
        ListViewPatients.Focus()
    End Sub

    Public Sub Find_Patients()
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""
        Dim Li As ListViewItem
        Dim SI As ListViewItem.ListViewSubItem
        Dim SISTATUS As ListViewItem.ListViewSubItem
        Dim SIACCEPTANCE As ListViewItem.ListViewSubItem
        Dim SICASESTATUS As ListViewItem.ListViewSubItem
        Dim PName() As String
        SplitContainer1.SuspendLayout()
        PanelBills.SuspendLayout()
        ListViewPatients.Items.Clear()
        TreeViewBills.Nodes.Clear()
        ListViewComments.Items.Clear()
        txtComments.Text = ""
        txtPatientComments.Text = ""
        Dim SQLPayment As String
        Dim SQLPaymentWhereSelected As Boolean
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        If DateTimePaymentFrom.Checked Or DateTimePaymentTo.Checked And searchBillIds = "" And Val(SearchBillID) = 0 Then
            SQL = "SELECT InsuranceCompaniesLien.CompanyName as Lien_Attorney, Bills.efileId, Bills.efileDate, Bills.Lien_date,Bills.Lien_comments, Patients.DOB, POM.RegisteredDT, IndexNumber, FilingDate, Bills.FilingFee, Bills.FilingFeePaidDate, Bills.AttorneyCaseNumberDate, Bills.NoMoreCollection, Patients.AdjusterPhone, (SELECT COUNT(RequestID) AS C FROM BillingRequests WHERE BillID = Bills.BillID) as Requests,(Bills.BillAmount-isnull(Bills.PaidAmount,0)) as Balance, Bills.AttorneyCaseNumber, BillPayments.PaymentAmount AS PaidAmount, Bills.POMID, Bills.BillStatusID, Bills.CopyFromBillID, CaseTypes.CaseTypeID, CaseTypes.Description as CaseType, Patients.PatientID,  Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS pName, Patients.DOA, Bills.ServiceFrom , Bills.ServiceTo, Bills.BillID, Bills.BillDate, Bills.PolicyNumber, Bills.ClaimNumber, Bills.BillAmount, BillStatus.Description as BillStatus, InsuranceCompanies.AcceptanceID, InsuranceCompanies.CompanyName as Insurance, Attorneys.CompanyName AS Attorney, Bills.AttorneyDate, Bills.AttorneyCompanyID,  Employees.Fname + ' ' + Employees.Lname AS Doctor, EmployeesBP.Fname + ' ' + EmployeesBP.Lname +' '+ EmployeesBP.Alias AS BPName, EmployeesBP.EmpID as BPID, Bills.Adjuster, Bills.DenialFound,  "
            SQL &= " BillPayments.InsertedDate as InsertedDate, BillPayments.PaymentDate as CheckDates, CaseStatuses.Description as CaseStatus, Patients.CaseStatusID, Patients.Attorney as pAttorney "
        Else
            SQL = "SELECT InsuranceCompaniesLien.CompanyName as Lien_Attorney, Bills.efileId, Bills.efileDate, Bills.Lien_date,Bills.Lien_comments, Patients.DOB, POM.RegisteredDT, IndexNumber, FilingDate, Bills.FilingFee, Bills.FilingFeePaidDate, Bills.AttorneyCaseNumberDate, Bills.NoMoreCollection, Patients.AdjusterPhone, (SELECT COUNT(RequestID) AS C FROM BillingRequests WHERE BillID = Bills.BillID) as Requests,(Bills.BillAmount-isnull(Bills.PaidAmount,0)) as Balance, Bills.AttorneyCaseNumber, Bills.PaidAmount, Bills.POMID, Bills.BillStatusID, Bills.CopyFromBillID, CaseTypes.CaseTypeID, CaseTypes.Description as CaseType, Patients.PatientID,  Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS pName, Patients.DOA, Bills.ServiceFrom , Bills.ServiceTo, Bills.BillID, Bills.BillDate, Bills.PolicyNumber, Bills.ClaimNumber, Bills.BillAmount, BillStatus.Description as BillStatus, InsuranceCompanies.AcceptanceID, InsuranceCompanies.CompanyName as Insurance, Attorneys.CompanyName AS Attorney, Bills.AttorneyDate, Bills.AttorneyCompanyID,  Employees.Fname + ' ' + Employees.Lname AS Doctor, EmployeesBP.Fname + ' ' + EmployeesBP.Lname +' '+ EmployeesBP.Alias AS BPName, EmployeesBP.EmpID as BPID, Bills.Adjuster, Bills.DenialFound,  "
            'SQL &= " (SELECT cast(CONVERT(VARCHAR(10), MIN(PaymentDate) , 101)  as varchar(20))+' - '+ cast(CONVERT(VARCHAR(10), MAX(PaymentDate) , 101)  as varchar(20)) from BillPayments Where BillID=Bills.BillID ) as CheckDates , CaseStatuses.Description as CaseStatus, Patients.CaseStatusID, Patients.Attorney  as pAttorney "
            SQL &= " (SELECT cast(CONVERT(VARCHAR(10), MIN(InsertedDate) , 101)  as varchar(20))+' - '+ cast(CONVERT(VARCHAR(10), MAX(InsertedDate) , 101)  as varchar(20)) from BillPayments Where BillID=Bills.BillID ) as InsertedDate , (SELECT cast(CONVERT(VARCHAR(10), MIN(PaymentDate) , 101)  as varchar(20))+' - '+ cast(CONVERT(VARCHAR(10), MAX(PaymentDate) , 101)  as varchar(20)) from BillPayments Where BillID=Bills.BillID ) as CheckDates , CaseStatuses.Description as CaseStatus, Patients.CaseStatusID, Patients.Attorney  as pAttorney "
        End If
        SQL &= ", (Select sum(AttorneyFeesPaid) from BillAttorneyFees where BillAttorneyFees.BillID=Bills.BillID) As AttorneyFeesPaid "
        SQL &= ", (SELECT  max(InsertedDT) FROM BillToPatient WHERE BillToPatient.BillID = Bills.BillID) as BillToPatientDT "

        SQL &= " FROM Bills Bills LEFT OUTER JOIN Employees On Bills.TreatingProviderID = Employees.EmpID LEFT OUTER JOIN Employees EmployeesBP On Bills.BillingProviderID = EmployeesBP.EmpID  INNER JOIN CaseTypes On Bills.CaseTypeID = CaseTypes.CaseTypeID INNER JOIN Patients On Bills.PatientID = Patients.PatientID INNER JOIN BillStatus On Bills.BillStatusID = BillStatus.BillStatusID inner join CaseStatuses On Patients.CaseStatusID = CaseStatuses.CaseStatusID LEFT OUTER JOIN InsuranceCompanies On Bills.InsCompanyID = InsuranceCompanies.CompanyID LEFT OUTER JOIN Attorneys On Bills.AttorneyCompanyID = Attorneys.CompanyID  LEFT OUTER JOIN POM On Bills.POMID = POM.POMID "
        SQL &= " LEFT OUTER JOIN InsuranceCompanies InsuranceCompaniesLien On Bills.Lien_attorney_id = InsuranceCompaniesLien.CompanyID"

        If DateTimePaymentFrom.Checked Or DateTimePaymentTo.Checked Then
            SQL &= " INNER JOIN BillPayments On BillPayments.BillID = Bills.BillID "
        End If
        SQL &= " WHERE Patients.OfficeID = " & gOfficeID & " "

        ' Search Criterias
        txtPatient.Text = txtPatient.Text.Trim.ToSafeSQLString()
        If Not String.IsNullOrEmpty(searchBillIds) Then
            SQL &= " And Bills.BillID in (" & searchBillIds & ") "
            SQL &= " And (Bills.BillStatusID <> 13) "   ' Never show Replicated Bills
        End If
        If IsNumeric(SearchBillID) And Val(SearchBillID) > 0 Then
            SQL &= " And Bills.BillID = " & Val(SearchBillID) & " "
            If cboBillStatus.SelectedIndex > 0 And CType(cboBillStatus.SelectedItem, ValueDescription).Value <> 13 Then
                SQL &= " And (Bills.BillStatusID <> 13) "   ' Never show Replicated Bills
            End If
            GoTo StartSearch
        End If
        If IsNumeric(SearchPatientID) And Val(SearchPatientID) > 0 Then
            SQL &= " And Patients.PatientID = " & Val(SearchPatientID) & " "
            If cboBillStatus.SelectedIndex > 0 And CType(cboBillStatus.SelectedItem, ValueDescription).Value <> 13 Then
                SQL &= " And (Bills.BillStatusID <> 13) "   ' Never show Replicated Bills
            End If
            GoTo StartSearch
        End If
        If txtBillNumber.Text.Trim <> "" And DateTimePaymentFrom.Checked = False And DateTimePaymentTo.Checked = False Then
            If IsNumeric(txtBillNumber.Text) Then
                SQL &= " And (Bills.OldBillNumber = " & Val(txtBillNumber.Text) & " Or Bills.BillID = " & Val(txtBillNumber.Text) & " Or Bills.AttorneyCaseNumber = " & Val(txtBillNumber.Text) & " Or Bills.ClaimNumber Like '" & txtBillNumber.Text.Trim.ToSafeSQLString() & "%' or Bills.PolicyNumber like '" & txtBillNumber.Text.Trim.ToSafeSQLString() & "%') "
            Else
                SQL &= " And (Bills.OldBillNumber = '" & txtBillNumber.Text.ToSafeSQLString() & "' Or Bills.ClaimNumber Like '" & txtBillNumber.Text.Trim.ToSafeSQLString() & "%' or Bills.PolicyNumber like '" & txtBillNumber.Text.Trim.ToSafeSQLString() & "%') "
            End If
            If cboBillStatus.SelectedIndex > 0 And CType(cboBillStatus.SelectedItem, ValueDescription).Value <> 13 Then
                SQL &= " AND (Bills.BillStatusID <> 13) "   ' Never show Replicated Bills
            End If
        End If
        'Else
        If txtPatient.Text.Trim <> "" Then
            If IsNumeric(txtPatient.Text) Then
                SQL &= " AND Patients.PatientID = " & Val(txtPatient.Text) & " "
            Else
                PName = Split(txtPatient.Text.ToSafeSQLString(), " ")
                Select Case PName.Length
                    Case 1
                        If PName(0).Trim = "*" Then PName(0) = ""
                        SQL &= " and (Patients.FName Like '" & PName(0).Trim & "%' or Patients.LName Like '" & PName(0) & "%') "
                    Case 2
                        SQL &= " and ("
                        SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.LName Like '" & PName(1).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.LName Like '" & PName(0).Trim & "%')"
                        SQL &= " )"
                    Case 3
                        SQL &= " and ("
                        SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" & PName(1).Trim & "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" & PName(2).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" & PName(0).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" & PName(1).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" & PName(0).Trim & "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" & PName(2).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "

                        SQL &= " )"
                End Select

            End If
        End If

        If DateTimePickerAttorneyFrom.Checked Then
            SQL &= " and DATEDIFF(d, Bills.AttorneyDate, '" & DateTimePickerAttorneyFrom.Value.Date & "')<=0 "
        End If

        If DateTimePickerAttorneyTo.Checked Then
            SQL &= " and DATEDIFF(d, Bills.AttorneyDate, '" & DateTimePickerAttorneyTo.Value.Date & "')>=0 "
        End If

        If DateTimePickerFrom.Checked Then
            SQL &= " and DATEDIFF(d, Bills.BillDate, '" & DateTimePickerFrom.Value.Date & "')<=0  "
        End If
        If DateTimePickerTo.Checked Then
            SQL &= " and DATEDIFF(d, Bills.BillDate, '" & DateTimePickerTo.Value.Date & "')>=0 "
        End If

        If (chkPaymentSearch.Checked) Then
            If DateTimePaymentFrom.Checked Then
                SQL &= " and DATEDIFF(d, BillPayments.PaymentDate, '" & DateTimePaymentFrom.Value.Date & "')<=0  "
            End If
            If DateTimePaymentTo.Checked Then
                SQL &= " and DATEDIFF(d, BillPayments.PaymentDate, '" & DateTimePaymentTo.Value.Date & "')>=0 "
            End If
        Else
            If DateTimePaymentFrom.Checked Then
                SQL &= " and DATEDIFF(d, BillPayments.InsertedDate, '" & DateTimePaymentFrom.Value.Date & "')<=0  "
            End If
            If DateTimePaymentTo.Checked Then
                SQL &= " and DATEDIFF(d, BillPayments.InsertedDate, '" & DateTimePaymentTo.Value.Date & "')>=0 "
            End If

        End If
        'If DateTimePaymentFrom.Checked Then
        '    SQL &= " and DATEDIFF(d, BillPayments.PaymentDate, '" & DateTimePaymentFrom.Value.Date & "')<=0  "
        'End If
        'If DateTimePaymentTo.Checked Then
        '    SQL &= " and DATEDIFF(d, BillPayments.PaymentDate, '" & DateTimePaymentTo.Value.Date & "')>=0 "
        'End If

        If cboBillingProvider.SelectedIndex > 0 Then
            SQL &= " AND Bills.BillingProviderID = " & CType(cboBillingProvider.SelectedItem, ValueDescription).Value & " "
        End If

        If cboCaseTypeID.SelectedIndex > 0 Then
            SQL &= " AND Bills.CaseTypeID = " & CType(cboCaseTypeID.SelectedItem, ValueDescription).Value & " "
        Else
            SQL &= " AND Bills.CaseTypeID <> 4"
        End If

        If cboInsuranceCompanyID.SelectedIndex > 0 Then
            If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value1 = "0" Then
                SQL &= " AND Bills.InsCompanyID in (Select CompanyID From InsuranceCompanies Where GroupID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & ") "
            Else
                SQL &= " AND Bills.InsCompanyID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & " "
            End If

        End If
        If cboAttorneysCompanyID.SelectedIndex = 1 Then
            SQL &= " AND (Bills.AttorneyCompanyID IS NOT NULL and Bills.AttorneyCompanyID<>0)"
        ElseIf cboAttorneysCompanyID.SelectedIndex = 2 Then
            SQL &= " AND (Bills.AttorneyCompanyID IS NOT NULL and Bills.AttorneyCompanyID<>0 and Bills.AttorneyCaseNumber IS NOT NULL)"
        ElseIf cboAttorneysCompanyID.SelectedIndex = 3 Then
            SQL &= " AND (Bills.AttorneyCompanyID IS NOT NULL and Bills.AttorneyCompanyID<>0 and Bills.AttorneyCaseNumber IS NULL)"
        ElseIf cboAttorneysCompanyID.SelectedIndex > 4 Then
            SQL &= " AND (Bills.AttorneyCompanyID = " & CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Value & " )"
        End If

        If cboBillStatus.SelectedIndex > 0 Then
            If CType(cboBillStatus.SelectedItem, ValueDescription).Value <> 13 Then
                SQL &= " AND (Bills.BillStatusID <> 13) "   ' Never show Replicated Bills
            End If

            If CType(cboBillStatus.SelectedItem, ValueDescription).Value = 13 Then ' show Replicated Bills if Replicated Bills selected only
                SQL &= " AND Bills.BillStatusID = 13 " ' show Replicated Bills if Replicated Bills selected only
            ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = -1 Then ' All Active
                '06/23/2025 DIMA REQUEST - DO NOT SHOW BILLS IF SELECTED ACTIVE SELECTED
                SQL &= " AND (Bills.BillStatusID <> 7 and Bills.BillStatusID <> 8 and isnull(NoMoreCollection,0)=0) "
            ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = -10 Then ' Attorney - Litigation = 4 Arbitration = 5
                SQL &= " AND (Bills.BillStatusID = 4 or Bills.BillStatusID = 5) "
            ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = -20 Then  ' Not Answered
                'SQL &= " AND (Bills.DenialFound=0 and (Bills.BillStatusID=2 or Bills.BillStatusID=4 or Bills.BillStatusID =5))"
                SQL &= " AND (Bills.DenialFound=0 and (Bills.BillStatusID=2 or Bills.BillStatusID=4 or Bills.BillStatusID =5))"
            ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = -30 Then  ' Not Answered
                SQL &= " AND (Bills.NoMoreCollection=1)"
            ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = -60 Then  ' Paid With Balance
                SQL &= " AND (Bills.BillStatusID=3 and ((Bills.BillAmount-isnull(Bills.PaidAmount,0)) > 0))"
            ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = 6 Then  ' Denied
                'SQL &= " AND Bills.DenialFound = 1 "
                SQL &= " AND Bills.DenialFound = 1 and ((Bills.BillAmount-isnull(Bills.PaidAmount,0)) > 0) "
            ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = -61 Then  ' Denied
                SQL &= " AND Bills.efileDate is not null "
            ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = 10 Then  ' Litigation
                SQL &= " AND Bills.IndexNumber like 'L-%' "
            ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = 11 Then  ' Arbitration
                SQL &= " AND Bills.IndexNumber like 'A-%' "
            ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = -40 Then  ' All Not Filed
                SQL &= " AND isnull(Bills.IndexNumber,'')='' "

            ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = -50 Then  ' Attorney Fees Paid
                SQL &= " AND  (select COUNT(*) from BillAttorneyFees Where BillID = Bills.BillID)>0 "
            ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = -51 Then  ' Attorney Fees Not Paid
                SQL &= " AND (select COUNT(*) from BillAttorneyFees Where BillID = Bills.BillID)=0 "
            Else
                SQL &= " AND Bills.BillStatusID = " & CType(cboBillStatus.SelectedItem, ValueDescription).Value & " "
            End If
        ElseIf cboBillStatus.SelectedIndex = 0 Then
            If CType(cboBillStatus.SelectedItem, ValueDescription).Value <> 13 Then
                'SQL &= " AND Bills.BillStatusID <> 13 "   ' Never show Replicated Bills
            End If
        End If
        'End If
        If cboDiagnostic.SelectedIndex > 0 Then
            SQL &= " AND (Bills.BillID in (Select BillProcedures.BillID FROM BillProcedures INNER JOIN PatientProcedures ON BillProcedures.PatientProcedureID = PatientProcedures.PatientProcedureID WHERE PatientProcedures.DiagID = " & CType(cboDiagnostic.SelectedItem, ValueDescription).Value & ")) "
        End If
        If ComboBoxRefOffice.SelectedIndex > 0 Then
            SQL &= " AND Patients.ReferringCompanyID = " & CType(ComboBoxRefOffice.SelectedItem, ValueDescription).Value & " "
        End If

        If cboPaymentNote.SelectedIndex > 0 Then
            SQL &= " AND (Bills.BillID in (Select BillID FROM BillPayments WHERE NoteID = " & CType(cboPaymentNote.SelectedItem, ValueDescription).Value & ")) "
        End If
        If cboDenial.SelectedIndex > 0 Then
            SQL &= " AND ((Bills.BillID in (Select BillProcedures.BillID FROM BillProcedures INNER JOIN PatientProcedures ON BillProcedures.PatientProcedureID = PatientProcedures.PatientProcedureID WHERE PatientProcedures.Comments like '%" & CType(cboDenial.SelectedItem, ValueDescription).Description.ToSafeSQLString() & "%')) "
            SQL &= " or Bills.DenialComments like '%" & CType(cboDenial.SelectedItem, ValueDescription).Description.ToSafeSQLString() & "%') "
        End If
        If cboLienAttorney.SelectedIndex = 0 Then
            SQL &= " AND isnull(Bills.Lien_attorney_id,0) <> 0 "
        ElseIf cboLienAttorney.SelectedIndex > 0 Then
            SQL &= " AND Bills.Lien_attorney_id = " & CType(cboLienAttorney.SelectedItem, ValueDescription).Value
        End If

StartSearch:

        '
        SQL &= " ORDER BY pName, Bills.BillID "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then
            SplitContainer1.ResumeLayout(True)
            PanelBills.ResumeLayout(True)
            Exit Sub
        End If

        Loading = True
        ListViewPatients.BeginUpdate()
        ListViewPatients.ListViewItemSorter = Nothing
        Do Until Reader.Read = False

            Li = ListViewPatients.Items.Add("K" & Reader("BillID").ToString, Reader("PatientID").ToString, "")
            With Li
                .ToolTipText = "Bill Status: " & Reader("BillStatus").ToString
                .UseItemStyleForSubItems = False
                .Tag = New ValueDescription(Reader("BillID").ToString, "", Reader("PatientID").ToString)
                .SubItems.Add(Reader("PName").ToString)
                If IsDate(Reader("DOA")) Then .SubItems.Add(CDate(Reader("DOA")).ToString("MM/dd/yyyy")) Else .SubItems.Add("")
                .SubItems.Add(Reader("CaseType").ToString).Tag = Val(Reader("CaseTypeID").ToString)
                'If Val(Reader("CaseTypeID").ToString) <> Val(Reader("CaseTypeID1").ToString) Then
                ' Li.BackColor = Color.Red
                'End If

                If IsNumeric(Reader("CopyFromBillID").ToString) Then
                    .ToolTipText &= "This bill has been reproduced from the bill number: " & Reader("CopyFromBillID").ToString
                    .SubItems.Add(Reader("BillID").ToString & "R")
                Else
                    .SubItems.Add(Reader("BillID").ToString)
                End If

                If IsDate(Reader("BillDate")) Then .SubItems.Add(CDate(Reader("BillDate")).ToString("MM/dd/yyyy")) Else .SubItems.Add("")
                .SubItems.Add(Reader("PolicyNumber").ToString)
                .SubItems.Add(Reader("ClaimNumber").ToString)
                .SubItems.Add(Val(Reader("BillAmount").ToString))

                'If Reader("Attorney").ToString <> "" Then
                'SISTATUS = Li.SubItems.Add("Attorney")
                'Else
                SISTATUS = .SubItems.Add(Reader("BillStatus").ToString)
                'End If
                SISTATUS.Tag = Val(Reader("BillStatusID").ToString)
                SIACCEPTANCE = .SubItems.Add(Reader("Insurance").ToString)
                SIACCEPTANCE.Tag = Reader("AcceptanceID").ToString

                If IsDate(Reader("ServiceFrom")) Then
                    .SubItems.Add(CDate(Reader("ServiceFrom")).ToString("MM/dd/yy") & " - " & CDate(Reader("ServiceTo")).ToString("MM/dd/yy"))
                Else
                    .SubItems.Add("")
                End If

                SI = .SubItems.Add(Reader("Attorney").ToString)
                SI.Tag = Reader("AttorneyCompanyID").ToString
                If IsDate(Reader("AttorneyDate")) Then .SubItems.Add(CDate(Reader("AttorneyDate")).ToString("MM/dd/yyyy")) Else .SubItems.Add("")
                If Val(Reader("POMID").ToString) > 0 Then
                    SI = .SubItems.Add(Reader("POMID").ToString)
                    If Reader("RegisteredDT").ToString = "" Then
                        SI.Text &= "P"
                        SI.BackColor = Color.Gold
                        SI.Tag = "POM Pending"
                        .ToolTipText &= vbCrLf & "POM Pending"
                    Else
                        SI.Tag = "Mailed"
                    End If
                Else
                    .SubItems.Add("")
                End If
                .SubItems.Add(Val(Reader("PaidAmount").ToString))
                .SubItems.Add(Val(Reader("Balance").ToString))
                .SubItems.Add(Reader("Doctor").ToString)

                If Val(Reader("POMID").ToString) > 0 Then
                    If Val(Reader("BillStatusID").ToString) = 1 Then
                        SI.BackColor = Color.Gold
                    End If
                End If
                .SubItems.Add(Reader("Adjuster").ToString)
                .SubItems.Add(Reader("AttorneyCaseNumber").ToString)
                SI = .SubItems.Add(Reader("Requests").ToString)
                If Val(Reader("Requests").ToString) > 0 Then
                    SI.BackColor = Color.LightGoldenrodYellow
                End If
                If IsDate(Reader("CheckDates").ToString) Then
                    .SubItems.Add(FormatDateTime(Reader("CheckDates").ToString, DateFormat.ShortDate))
                Else
                    .SubItems.Add(Reader("CheckDates").ToString)
                End If
                SICASESTATUS = .SubItems.Add(Reader("CaseStatus").ToString)

                .SubItems.Add(Reader("BPName").ToString).Tag = Val(Reader("BPID").ToString)
                .SubItems.Add(Reader("AdjusterPhone").ToString)
                If Val(Reader("NoMoreCollection").ToString) = 1 Then
                    .SubItems.Add("YES").BackColor = Color.Red
                Else
                    .SubItems.Add("")
                End If
                If IsDate(Reader("AttorneyCaseNumberDate")) Then
                    .SubItems.Add(CDate(Reader("AttorneyCaseNumberDate")).ToString("MM/dd/yyyy"))
                Else
                    If IsDate(Reader("AttorneyDate")) Then
                        If DateDiff(DateInterval.Day, CDate(Reader("AttorneyDate")), Now.Date) > 3 Then
                            .SubItems.Add("").BackColor = Color.LightSalmon
                            .SubItems(19).BackColor = Color.LightSalmon
                        Else
                            .SubItems.Add("").BackColor = Color.PeachPuff
                            .SubItems(19).BackColor = Color.PeachPuff
                        End If
                    Else
                        .SubItems.Add("")
                    End If
                End If
                .SubItems.Add(Reader("IndexNumber").ToString)
                If IsDate(Reader("FilingDate")) Then
                    .SubItems.Add(CDate(Reader("FilingDate")).ToString("MM/dd/yyyy"))
                Else
                    .SubItems.Add("")
                End If
                If Val(Reader("FilingFee").ToString) > 0 Then
                    .SubItems.Add(Val(Reader("FilingFee").ToString).ToString("c"))
                Else
                    .SubItems.Add("")
                End If
                If IsDate(Reader("FilingFeePaidDate").ToString) Then
                    .SubItems.Add(CDate(Reader("FilingFeePaidDate")).ToString("MM/dd/yyyy"))
                Else
                    .SubItems.Add("")
                End If
                If Val(Reader("AttorneyFeesPaid").ToString) > 0 Then
                    .SubItems.Add(Val(Reader("AttorneyFeesPaid").ToString).ToString("c"))
                Else
                    .SubItems.Add("")
                End If
                .SubItems.Add(Trim(Reader("pAttorney").ToString))

                If IsDate(Reader("DOB").ToString) Then
                    .SubItems.Add(CDate(Reader("DOB")).ToString("MM/dd/yyyy"))
                Else
                    .SubItems.Add("")
                End If
                SI = .SubItems.Add(Trim(Reader("Lien_Attorney").ToString))
                SI.Tag = Reader("Lien_comments").ToString

                If IsDate(Reader("Lien_date").ToString) Then
                    .SubItems.Add(CDate(Reader("Lien_date")).ToString("MM/dd/yyyy"))
                Else
                    .SubItems.Add("")
                End If
                If IsDate(Reader("BillToPatientDT").ToString) Then
                    SI = .SubItems.Add(CDate(Reader("BillToPatientDT")).ToString("MM/dd/yyyy"))
                Else
                    SI = .SubItems.Add("")
                End If
                If IsDate(Reader("BillToPatientDT")) And Val("" & Reader("Balance").ToString) > 0 And Val("" & Reader("NoMoreCollection").ToString) = 0 And Val("" & Reader("CaseStatusID").ToString) = 1 And Val("" & Reader("BillStatusID").ToString) <> 13 And Val("" & Reader("BillStatusID").ToString) <> 8 Then
                    If DateDiff(DateInterval.Day, CDate(Reader("BillToPatientDT")), Now.Date) > 30 Then
                        SI.BackColor = Color.Red
                        SI.ForeColor = Color.White
                    End If
                End If

                If Val(Reader("DenialFound").ToString) = 1 Then
                    SI = .SubItems.Add("YES")
                    SI.ForeColor = Color.Red
                Else
                    SI = .SubItems.Add("NO")
                End If

                If IsDate(Reader("InsertedDate").ToString) Then
                    .SubItems.Add(FormatDateTime(Reader("InsertedDate").ToString, DateFormat.ShortDate))
                Else
                    .SubItems.Add(Reader("InsertedDate").ToString)
                End If
                .SubItems.Add(Reader("efileId").ToString)
                If IsDate(Reader("efileDate")) Then .SubItems.Add(CDate(Reader("efileDate")).ToString("MM/dd/yyyy hh:mm tt")) Else .SubItems.Add("")

                If Val(Reader("DenialFound").ToString) = 1 Then
                    gSetListItemColor(Li, Color.PaleGoldenrod)
                End If
                Select Case Val(Reader("AcceptanceID").ToString)
                    Case 1
                        SIACCEPTANCE.BackColor = Color.Pink
                    Case 2
                        SIACCEPTANCE.BackColor = Color.DarkSalmon
                End Select
                Select Case Val(Reader("BillStatusID").ToString)
                    Case 1
                        'gSetListItemColor(Li, Color.Olive)
                    Case 2
                        'gSetListItemColor(Li, Color.LightSteelBlue)
                        SISTATUS.BackColor = Color.LightSteelBlue
                    Case 3
                        'gSetListItemColor(Li, Color.Green)
                        SISTATUS.BackColor = Color.LightGreen
                    Case 4, 5, 10, 11
                        'gSetListItemColor(Li, Color.Orange)
                        SISTATUS.BackColor = Color.DarkOrange
                    Case 6, 7
                        'gSetListItemColor(Li, Color.Red)
                        SISTATUS.BackColor = Color.DarkSalmon
                    Case 8, 13
                        'gSetListItemColor(Li, Color.Gainsboro)
                        SISTATUS.BackColor = Color.Red
                        SISTATUS.ForeColor = Color.White
                End Select

            End With
        Loop
        Loading = False
        If DateTimePaymentFrom.Checked Or DateTimePaymentTo.Checked Then
            With ListViewPatients
                .Columns(15).Text = "Payment Amt."
                .Columns(8).Width = 0
                .Columns(9).Width = 0
                .Columns(16).Width = 0
                .Columns(21).Width = -2
            End With
            lblCaption.Text = "PAYMENTS [PAYMENT DATES SELECTED]"
        Else
            With ListViewPatients
                .Columns(8).Width = -2
                .Columns(16).Width = -2
                .Columns(21).Width = -2
                .Columns(9).Width = -2
                .Columns(15).Text = "Paid Amt."
            End With
            lblCaption.Text = "BILLS"
        End If
        Application.DoEvents()
        If ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
            ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
        End If
        Count_Selected()
        Cursor = Cursors.Default
        ListViewPatients.EndUpdate()
        SplitContainer1.ResumeLayout(True)
        PanelBills.ResumeLayout(True)
    End Sub

    Private Sub cboCaseTypeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaseTypeID.SelectedIndexChanged
        Dim Reader As SqlClient.SqlDataReader
        With cboInsuranceCompanyID
            .Items.Clear()
            .Items.Add(New ValueDescription(0, "All"))
            .Items.Add(New ValueDescription(-1, "-----------------------------------------INSURANCE GROUPS-----------------------------------------"))
            .SelectedIndex = 0
            .DropDownHeight = 106
            Cursor = Cursors.WaitCursor
            Application.DoEvents()
            If CType(cboCaseTypeID.SelectedItem, ValueDescription).Value = 0 Then
                Reader = gSQLGetDataReader("SELECT DISTINCT  GroupID, Description FROM InsuranceCompaniesGroups ORDER BY Description")
            Else
                Reader = gSQLGetDataReader("SELECT DISTINCT InsuranceCompaniesGroups.GroupID, InsuranceCompaniesGroups.Description FROM InsuranceCompaniesGroups INNER JOIN InsuranceCompanies ON InsuranceCompaniesGroups.GroupID = InsuranceCompanies.GroupID Where CaseTypeID =" & CType(cboCaseTypeID.SelectedItem, ValueDescription).Value & " ORDER BY InsuranceCompaniesGroups.Description")
            End If
            If Reader Is Nothing Then GoTo ExitSub
            Do Until Reader.Read = False
                .Items.Add(New ValueDescription(CLng(Val(Reader("GroupID").ToString)), Reader("Description").ToString & " - Group", "0"))
            Loop
            If .Items.Count > 0 Then
                .Items.Add(New ValueDescription(-1, "--------------------------------------INSURANCE COMPANIES--------------------------------------"))
            End If
            If CType(cboCaseTypeID.SelectedItem, ValueDescription).Value = 0 Then
                Reader = gSQLGetDataReader("Select CompanyID, CompanyName from InsuranceCompanies ORDER BY CompanyName")
            Else
                Reader = gSQLGetDataReader("Select CompanyID, CompanyName from InsuranceCompanies Where CaseTypeID =" & CType(cboCaseTypeID.SelectedItem, ValueDescription).Value & " ORDER BY CompanyName")
            End If
            If Reader Is Nothing Then GoTo ExitSub
            Do Until Reader.Read = False
                .Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString, "1"))
            Loop
            If .Items.Count = 0 Then
                .DropDownHeight = 20
            End If
        End With
        Reader.Close() : Reader.Dispose()
ExitSub:
        Cursor = Cursors.Default
    End Sub

    Private Sub cboInsuranceCompanyID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboInsuranceCompanyID.KeyUp
        gComboboxAutoComplete(cboInsuranceCompanyID, e, True)
    End Sub

    Private Sub ListViewPatients_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewPatients.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewPatients.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
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

    Private Sub ButtonPrintEnvelop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboAttorneysCompanyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAttorneysCompanyID.SelectedIndexChanged
        If cboAttorneysCompanyID.SelectedIndex = -1 Then Exit Sub
        If CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Value = "-99" Then
            cboAttorneysCompanyID.SelectedIndex = 0
        End If
        If cboAttorneysCompanyID.SelectedIndex > 0 Then
            DateTimePickerAttorneyFrom.Enabled = True
            DateTimePickerAttorneyTo.Enabled = True
        Else
            DateTimePickerAttorneyFrom.Enabled = False
            DateTimePickerAttorneyTo.Enabled = False
            DateTimePickerAttorneyFrom.Checked = False
            DateTimePickerAttorneyTo.Checked = False
        End If
    End Sub

    Private Sub cboBillStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Count_Selected()
        Dim T As Double
        Dim Tc As Double
        Dim I As Integer
        Dim P As Double
        Dim PC As Double
        Dim B As Double
        Dim BC As Double

        If CheckUncheck Then Exit Sub
        ToolStripStatusLabelFound.Text = " Found: " & ListViewPatients.Items.Count & "   "
        Try
            ToolStripStatusLabelChecked.Text = " Checked: " & ListViewPatients.CheckedItems?.Count & "   "
        Catch
        End Try
        If ListViewPatients.Items.Count > 0 Then
            If ListViewPatients.Items(0).SubItems.Count > 0 Then
                For I = 0 To ListViewPatients.Items.Count - 1
                    T = T + CDbl(ListViewPatients.Items(I).SubItems(8).Text)
                    P = P + +CDbl(ListViewPatients.Items(I).SubItems(15).Text)
                    '7 - Status Lost
                    '8 - Status Closed
                    If ListViewPatients.Items(I).SubItems(25).Text = "" And Val(ListViewPatients.Items(I).SubItems(9).Tag) <> 7 And Val(ListViewPatients.Items(I).SubItems(9).Tag) <> 8 And Val(ListViewPatients.Items(I).SubItems(9).Tag) <> 13 Then
                        ' Do not calculate overpayment - balance becomes negative...
                        If CDbl(ListViewPatients.Items(I).SubItems(16).Text) > 0 Then
                            B = B + CDbl(ListViewPatients.Items(I).SubItems(16).Text)
                        End If
                    End If
                    If ListViewPatients.Items(I).Checked Then
                        Tc = Tc + CDbl(ListViewPatients.Items(I).SubItems(8).Text)
                        PC = PC + CDbl(ListViewPatients.Items(I).SubItems(15).Text)
                        BC = BC + CDbl(ListViewPatients.Items(I).SubItems(16).Text)
                    End If
                Next
            End If
        End If
        If DateTimePaymentFrom.Checked Or DateTimePaymentTo.Checked Then
            ToolStripLabelTotal.Visible = False
            ToolStripStatusLabelBalanceFound.Visible = False
            ToolStripLabelPaidFound.Text = "Total Payments: " & P.ToString("c") & "   "
        Else
            If T > 0 Then
                ToolStripLabelPaidFound.Text = "Paid: " & P.ToString("c") & "   " & "   " & Format(((P * 100) / T), "##0.00") & "%"
            Else
                ToolStripLabelPaidFound.Text = "Paid $0.00"
            End If

            ToolStripLabelTotal.Visible = True
            ToolStripStatusLabelBalanceFound.Visible = True
        End If
        ToolStripLabelTotal.Text = " Total: " & T.ToString("c") & "   "
        ToolStripStatusLabelBalanceFound.Text = "Receivable: " & B.ToString("c") & "   "
        ToolStripStatusLabelDeadDebt.Text = "Dead Debt: " & (T - (P + B)).ToString("c")
    End Sub

    Private CheckUncheck As Boolean

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim LI As ListViewItem
        CheckUncheck = True
        ListViewPatients.BeginUpdate()
        Loading = True
        For Each LI In ListViewPatients.Items
            LI.Checked = True
        Next
        Loading = False
        ListViewPatients.EndUpdate()
        CheckUncheck = False
        Count_Selected()
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNoneToolStripMenuItem.Click
        Dim LI As ListViewItem
        CheckUncheck = True
        ListViewPatients.BeginUpdate()
        For Each LI In ListViewPatients.Items
            LI.Checked = False
        Next
        ListViewPatients.EndUpdate()
        CheckUncheck = False
        Count_Selected()

    End Sub

    Private Sub InvertSelectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim LI As ListViewItem
        For Each LI In ListViewPatients.Items
            LI.Checked = Not LI.Checked
        Next
        Count_Selected()

    End Sub

    Private Sub ListViewPatients_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles ListViewPatients.ColumnWidthChanged
        If ListViewPatients.Columns(e.ColumnIndex).Width < 60 Then
            If e.ColumnIndex <> 8 And e.ColumnIndex <> 16 And e.ColumnIndex <> 9 Then
                ListViewPatients.Columns(e.ColumnIndex).Width = 60
            End If
        End If
    End Sub

    Private Sub ListViewPatients_ColumnWidthChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles ListViewPatients.ColumnWidthChanging

    End Sub

    Private Sub ListViewPatients_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPatients.DoubleClick
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        Dim LI As ListViewItem
        LI = ListViewPatients.SelectedItems(0)
        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.InitialPatientName = LI.Text
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ListViewPatients_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPatients.GotFocus
        LastSelected = ListViewPatients
    End Sub

    Public SelectedInsCompanyIndex As Integer

    Private Sub ReproduceBillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBillingTools1.Click

    End Sub

    Private Sub ReProduce_Bill()
        Dim Li As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to Reproduce Bill. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim BillID As Long
        Dim NewBillID As Long
        Dim PatientID As Long
        Dim PatientName As String
        Li = ListViewPatients.SelectedItems(0)
        PatientID = CType(Li.Tag, ValueDescription).Value1
        PatientName = Li.SubItems(1).Text
        BillID = CType(Li.Tag, ValueDescription).Value

        If gCurrentEmployee.PositionID > 3 Then
            frmSupervisorApproval.LabelMsg.Text = "ReProduce Bill: " & BillID & vbCrLf & vbCrLf & "The Bill:" & BillID & " will  be canceled and the new bill will be created."
            If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frmSupervisorApproval.Dispose()
                Exit Sub
            End If
            ApprovedByID = frmSupervisorApproval.SupervisorID
            ApprovedByName = frmSupervisorApproval.SupervisorName
            frmSupervisorApproval.Dispose()
        Else
            If MsgBox("Attention! This process can not be undone!" & vbCrLf & vbCrLf & "You have requested to ReProduce Bill: " & BillID & vbCrLf & "The Bill:" & BillID & " will  be canceled and the new bill will be created." & vbCrLf & vbCrLf & "This function should be used if the patient's insurance information changhed, and bill will be resubmitted to the insurance company." & vbCrLf & "Do you want to continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tBillReproduced, "Bill #: " & BillID & " has been deleted.", ApprovedByName)

        SQL = "INSERT INTO Bills (OfficeID, PatientID, CaseTypeID, ScheduleID, BillAmount, BillDiscountPct, BillProcedures, BillStatusID, BillDate, SplitBillID, BillingProviderID, TreatingProviderID, ServiceFrom, ServiceTo, CopyFromBillID, InsCompanyID, InsAddressID, ClaimNumber, PolicyNumber, PolicyHolder, Adjuster, AdjusterPhone) "
        SQL &= " SELECT Bills.OfficeID, Bills.PatientID, Patients.CaseTypeID, Bills.ScheduleID, Bills.BillAmount, Bills.BillDiscountPct, Bills.BillProcedures, 1 as BillStatusID, getdate() as BillDate, Bills.SplitBillID, Bills.BillingProviderID, Bills.TreatingProviderID, Bills.ServiceFrom, Bills.ServiceTo, Bills.BillID, "

        Reader = gSQLGetDataReader("SELECT   Patients.ClaimAddressID, Patients.ClaimAddressID1, InsuranceCompanies.CompanyName, InsuranceCompanies_1.CompanyName AS CompanyName1 FROM         Patients LEFT OUTER JOIN InsuranceCompanies InsuranceCompanies_1 ON Patients.InsuranceCompanyID1 = InsuranceCompanies_1.CompanyID LEFT OUTER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID = InsuranceCompanies.CompanyID Where Patients.PatientID = " & PatientID)
        If Reader Is Nothing Then
            MsgBox("Unexpected  Error. Please try again.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Reader.HasRows = False Then
            MsgBox("Unexpected  Error. Please try again.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Reader.Read()
        If Val(Reader("ClaimAddressID").ToString) > 0 And Val(Reader("ClaimAddressID1").ToString) > 0 Then
            frmSelectInsuranceCompany.ComboBox1.Items.Add(Reader("CompanyName").ToString)
            frmSelectInsuranceCompany.ComboBox1.Items.Add(Reader("CompanyName1").ToString)
            frmSelectInsuranceCompany.CalledForm = Me
            If frmSelectInsuranceCompany.ShowDialog = Windows.Forms.DialogResult.OK Then
                If SelectedInsCompanyIndex = 0 Then
                    SQL &= " Patients.InsuranceCompanyID, Patients.ClaimAddressID, Patients.ClaimNumber, Patients.PolicyNumber, Patients.PolicyHolderFName + ' ' + Patients.PolicyHolderLName AS PolicyHolder, Patients.AdjusterName, Patients.AdjusterPhone "
                Else
                    SQL &= " Patients.InsuranceCompanyID1, Patients.ClaimAddressID1, Patients.ClaimNumber1, Patients.PolicyNumber1, Patients.PolicyHolderFName1 + ' ' + Patients.PolicyHolderLName1 AS PolicyHolder, Patients.AdjusterName1, Patients.AdjusterPhone1 "
                End If
                frmSelectInsuranceCompany = Nothing
            Else
                frmSelectInsuranceCompany = Nothing
                Exit Sub
            End If
        Else
            SQL &= " Patients.InsuranceCompanyID, Patients.ClaimAddressID, Patients.ClaimNumber, Patients.PolicyNumber, Patients.PolicyHolderFName + ' ' + Patients.PolicyHolderLName AS PolicyHolder, Patients.AdjusterName, Patients.AdjusterPhone "
        End If
        SQL &= " FROM Bills INNER JOIN Patients ON Bills.PatientID = Patients.PatientID WHERE Bills.BillID = " & BillID
        gSQLUpdateData(SQL)
        NewBillID = gSQLGetSingleValue("Select IDENT_CURRENT('Bills')")
        SQL = "INSERT INTO BillProcedures (BillID, PatientProcedureID, DiagID, ProcID, ProcName, ProcDescription, Code, NFCost, WCCost, PRCost, AgreementInd, AgrNFCost, AgrWCCost, AgrPRCost) SELECT " & NewBillID & " as BillID, PatientProcedureID, DiagID, ProcID, ProcName, ProcDescription, Code, NFCost, WCCost, PRCost, AgreementInd, AgrNFCost, AgrWCCost, AgrPRCost FROM BillProcedures Where BillID=" & BillID
        gSQLUpdateData(SQL)
        SQL = "INSERT INTO BillDiagnosis (BillID, PatientProcedureID, DignosisID, ICDCode,ICDDescription) SELECT " & NewBillID & " as BillID, PatientProcedureID, DignosisID,ICDCode, ICDDescription FROM BillDiagnosis Where BillID = " & BillID
        gSQLUpdateData(SQL)

        SQL = "INSERT INTO BillComments  (BillID, Comment, InsertedBy, InsertedDT) SELECT " & NewBillID & " as BillID, Comment, InsertedBy, InsertedDT FROM BillComments  Where BillID = " & BillID
        gSQLUpdateData(SQL)

        SQL = "INSERT INTO BillComments (BillID, Comment, InsertedBy, InsertedDT) values(" & NewBillID & ", 'Bill Replicated From the Bill Number " & BillID & "'," & gCurrentEmployee.EmpID & ",getdate())"
        gSQLUpdateData(SQL)

        SQL = "INSERT INTO BillComments (BillID, Comment, InsertedBy, InsertedDT) values(" & BillID & ", 'Bill Replicated. The New Bill Number " & NewBillID & "'," & gCurrentEmployee.EmpID & ",getdate())"
        gSQLUpdateData(SQL)

        gSQLUpdateData("Update Bills Set BillStatusID = 13 Where BillID=" & BillID)   'Cancel Previous Bill
        If cboBillStatus.SelectedIndex > 1 Or cboBillStatus.SelectedIndex = -1 Then cboBillStatus.SelectedIndex = 1
        ButtonClear_Click(Nothing, Nothing)
        Find_Patients()
        If ListViewPatients.Items.ContainsKey("K" & NewBillID) Then
            ListViewPatients.Items("K" & NewBillID).Selected = True
            ListViewPatients.Items("K" & NewBillID).EnsureVisible()
            ListViewPatients.TopItem = ListViewPatients.Items("K" & NewBillID)
            Load_Patient_Bills(PatientID)
            Load_Comments(BillID)
        End If

    End Sub

    Private Sub ListViewPatients_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewPatients.ItemCheck
        If Loading Then Exit Sub
        If CheckUncheck Then Exit Sub
        Try
            ToolStripStatusLabelChecked.Text = " Checked: " & ListViewPatients.CheckedItems?.Count & "   "
        Catch
        End Try

    End Sub

    Private Sub ListViewPatients_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListViewPatients.ItemChecked
        If Loading Then Exit Sub
        If CheckUncheck Then Exit Sub
        Try
            ToolStripStatusLabelChecked.Text = " Checked: " & ListViewPatients.CheckedItems?.Count & "   "
        Catch
        End Try
    End Sub

    Private Sub ListViewPatients_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewPatients.MouseDown
        'Application.DoEvents()
        Dim HI As ListViewHitTestInfo
        HI = ListViewPatients.HitTest(e.X, e.Y)
        Dim ev As New System.ComponentModel.CancelEventArgs
        If Not HI.Item Is Nothing Then
            HI.Item.Selected = True
            HI.Item.EnsureVisible()
            If e.Button = Windows.Forms.MouseButtons.Right Then
                If ContextMenuStrip1.Visible = False Then
                    Setup_Menus(ev)
                    If ev.Cancel = False Then
                        ContextMenuStrip1.Show(ListViewPatients, New Point(e.X, e.Y))
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub ListViewPatients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewPatients.SelectedIndexChanged
        If SplitContainer2.Panel2Collapsed = False Then
            TimerDetails.Enabled = False
            TimerDetails.Enabled = True
        End If
    End Sub

    Private Sub Load_Patient_QNotes(ByVal ID As Long)
        If txtPatientComments.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf Load_Patient_QNotes), ID)
            Exit Sub
        End If
        Try
            Dim Reader As SqlClient.SqlDataReader = Nothing
            txtPatientComments.Text = ""
            Reader = gSQLGetDataReader("SELECT Comments FROM Patients where PatientID = " & ID)
            If Reader Is Nothing Then Exit Sub
            If Reader.HasRows Then
                Reader.Read()
                txtPatientComments.Text = Reader("Comments").ToString
            End If
        Catch ex As Exception
            log.Error(ex)

        End Try
    End Sub

    Private Sub Load_Payments(ByVal BillID As Long)
        If ListViewPayments.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf Load_Payments), BillID)
            Exit Sub
        End If
        Try
            Dim SQL As String = ""
            Dim Reader As SqlClient.SqlDataReader = Nothing
            Dim LI As ListViewItem
            SQL = "SELECT     PaymentDate, PaymentAmount, PaymentTypeID, CheckNumber "
            SQL &= " FROM         BillPayments "
            SQL &= " WHERE BillID = " & BillID
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then
                MsgBox("Unexpected Error. Please call your system administrator.")
                Exit Sub
            End If
            ListViewPayments.Items.Clear()

            Do Until Reader.Read = False
                If IsDate(Reader("PaymentDate").ToString) Then
                    LI = ListViewPayments.Items.Add(CDate(Reader("PaymentDate")).ToString("MM/dd/yyyy"))
                Else
                    LI = ListViewPayments.Items.Add("")
                End If
                With LI
                    .SubItems.Add(CDbl(Reader("PaymentAmount").ToString).ToString("c"))
                    Select Case Val(Reader("PaymentTypeID").ToString)
                        Case 1
                            .ToolTipText = "Check Number:" & Reader("CheckNumber").ToString
                            .SubItems.Add(Reader("CheckNumber").ToString)
                        Case 2
                            .ToolTipText = "Cash Payment"
                            .SubItems.Add("Cash Payment")
                        Case 3
                            .ToolTipText = "Credit Card Payment"
                            .SubItems.Add("Credit Card")
                        Case 4
                            .ToolTipText = "Money Order Payment"
                            .SubItems.Add("Money Order")
                    End Select
                End With
            Loop
        Catch ex As Exception
            log.Error(ex)

        End Try
    End Sub

    Private Sub Load_Comments(ByVal BillID As Long)
        If ListViewComments.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf Load_Comments), BillID)
            Exit Sub
        End If
        Try
            Dim Reader As SqlClient.SqlDataReader
            Dim LI As ListViewItem
            Dim LIReminder As ListViewItem.ListViewSubItem
            ListViewComments.Items.Clear()
            txtComments.Text = ""
            Reader = gSQLGetDataReader("SELECT ReminderDT, ReminderCompleteInd, BillComments.CommentID, BillComments.BillID, BillComments.Comment, BillComments.InsertedBy, BillComments.InsertedDT, Employees.Fname +' '+Employees.Lname as EmpName FROM BillComments INNER JOIN Employees ON BillComments.InsertedBy = Employees.EmpID Where BillID = " & BillID & "  order by InsertedDT Desc")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                If IsDate(Reader("InsertedDT").ToString) Then
                    LI = ListViewComments.Items.Add(CDate(Reader("InsertedDT")).ToString("MM/dd/yy HH:mm"))
                Else
                    LI = ListViewComments.Items.Add("")
                End If
                LI.UseItemStyleForSubItems = False
                LI.Tag = Reader("Comment").ToString
                LI.SubItems.Add(Reader("EmpName").ToString)
                If IsDate(Reader("ReminderDT").ToString) Then
                    LIReminder = LI.SubItems.Add(CDate(Reader("ReminderDT")).ToString("MM/dd/yy"))
                    If CDate(CDate(Reader("ReminderDT").ToString).ToShortDateString) < CDate(Now.ToShortDateString) Then
                        If Val(Reader("ReminderCompleteInd").ToString) = 0 Then
                            LIReminder.BackColor = Color.LightSalmon
                        Else
                            LIReminder.BackColor = Color.LightSeaGreen
                        End If
                    Else
                        LIReminder.BackColor = Color.Gold
                    End If
                Else
                    LI.SubItems.Add("")
                End If
            Loop
            If ListViewComments.Items.Count > 0 Then
                ListViewComments.Items(0).Selected = True
                ListViewComments.Items(0).EnsureVisible()
                ListViewComments_SelectedIndexChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            log.Error(ex)

        End Try
    End Sub

    Private Sub PrintBillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintCheckedBills1.Click, mnuPrintCheckedBills2.Click, mnuPrintCheckedBills3.Click
        Dim BillID() As String = Nothing
        Dim I As Integer = 0
        Dim SaveCaseType As Integer
        If ListViewPatients.CheckedItems.Count = 0 And ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to produce Bill. No bills checked / selected. Please check the bill(s) and try again.", MsgBoxStyle.Critical)
            ListViewPatients.Focus()
            Exit Sub
        End If

        Dim LI As ListViewItem
        If ListViewPatients.CheckedItems.Count = 0 Then
            ReDim Preserve BillID(0)
            BillID(I) = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value
            SaveCaseType = ListViewPatients.SelectedItems(0).SubItems(3).Tag
        Else
            SaveCaseType = ListViewPatients.CheckedItems(0).SubItems(3).Tag
            For Each LI In ListViewPatients.CheckedItems
                If SaveCaseType <> LI.SubItems(3).Tag Then
                    MsgBox("Unable to produce bills. You have checked different case types bills." & vbCrLf & vbCrLf & "The different Case Type bills should be printed separately.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                ReDim Preserve BillID(I)
                BillID(I) = CType(LI.Tag, ValueDescription).Value
                I = I + 1
            Next
        End If
        frmNF3Report.Setup_report(BillID, SaveCaseType)
        Application.DoEvents()
        frmNF3Report.MinimizeBox = False

        frmNF3Report.ShowDialog(Me)
        frmNF3Report.Dispose()
    End Sub

    Private Sub PrintEnvelopeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintCheckedEnvelopes1.Click, mnuPrintCheckedEnvelopes2.Click
        Dim BillsID() As String = Nothing
        Dim I As Integer = 0
        Dim T As ValueDescription
        If ListViewPatients.CheckedItems.Count = 0 And ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to print envelope(s). No bills checked/selected. Please check the bill(s) and try again.", MsgBoxStyle.Critical)
            ListViewPatients.Focus()
            Exit Sub
        End If

        Dim LI As ListViewItem
        If ListViewPatients.CheckedItems.Count = 0 Then
            ReDim Preserve BillsID(0)
            BillsID(I) = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value
        Else
            For Each LI In ListViewPatients.CheckedItems
                ReDim Preserve BillsID(I)
                BillsID(I) = CType(LI.Tag, ValueDescription).Value
                I = I + 1
            Next
        End If

        frmBillingEnvelops.Setup_report(BillsID)
        frmBillingEnvelops.MinimizeBox = False
        frmBillingEnvelops.MaximizeBox = False
        Application.DoEvents()
        frmBillingEnvelops.ShowDialog(Me)
        frmBillingEnvelops.Dispose()
    End Sub

    Private Sub PrintPOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintCheckedPOM1.Click, mnuPrintCheckedPOM2.Click
        Dim BillID() As String = Nothing
        Dim SaveBP As Integer
        Dim I As Integer = 0
        Dim CreatedFound As Integer
        If ListViewPatients.CheckedItems.Count = 0 And ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to produce POM. No bills checked. Please check the bill(s) and try again.", MsgBoxStyle.Critical)
            ListViewPatients.Focus()
            Exit Sub
        End If

        Dim LI As ListViewItem
        If ListViewPatients.CheckedItems.Count < 2 Then
            ReDim Preserve BillID(0)
            If ListViewPatients.CheckedItems.Count = 0 Then
                LI = ListViewPatients.SelectedItems(0)
                BillID(I) = CType(LI.Tag, ValueDescription).Value
            Else
                LI = ListViewPatients.CheckedItems(0)
                BillID(I) = CType(LI.Tag, ValueDescription).Value
            End If
            If LI.SubItems(14).Text <> "" Then
                If MsgBox("Attention!" & vbCrLf & vbCrLf & "The selected bill is already assigned to the previously created POM." & vbCrLf & vbCrLf & "Please confirm you want to recreate POM for this bill?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    LI.Selected = True
                    LI.EnsureVisible()
                    Exit Sub
                End If
            End If
        Else
            For Each LI In ListViewPatients.CheckedItems
                If SaveBP <> 0 And SaveBP <> Val(LI.SubItems(23).Tag) Then
                    MsgBox("Unable to produce POM for the different Billing Providers." & vbCrLf & vbCrLf & "POM for different Billing Providers should be printed separately.", MsgBoxStyle.Exclamation)
                    ListViewPatients.Focus()
                    Exit Sub
                End If
                SaveBP = Val(LI.SubItems(23).Tag)
                ReDim Preserve BillID(I)
                'If LI.SubItems(9).Tag <> 1 Then
                'MsgBox("Unable to produce POM." & vbCrLf & "The POM can be produced for the Bill status [Bill Created] only." & vbCrLf & "Please check the checked bills list and try again.", MsgBoxStyle.Exclamation)
                'LI.Selected = True
                'LI.EnsureVisible()
                'Exit Sub
                'End If
                If LI.SubItems(14).Text <> "" Then
                    CreatedFound = CreatedFound + 1
                End If
                BillID(I) = CType(LI.Tag, ValueDescription).Value
                I = I + 1
            Next
        End If
        If CreatedFound > 0 Then
            If MsgBox("Attention!" & vbCrLf & vbCrLf & CreatedFound & " of selected bills POM is already created or pending to be processed." & vbCrLf & vbCrLf & "Please confirm you want to recreate POM for these bills?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                LI.Selected = True
                LI.EnsureVisible()
                Exit Sub
            End If
        End If

        'BillID.ToString
        gSQLUpdateData("INSERT INTO POM (CreateBy) VALUES(" & gCurrentEmployee.EmpID & ")")
        Dim POMID As Long = gSQLGetSingleValue("Select IDENT_CURRENT('POM')")
        frmPOM.Setup_report(BillID, POMID)
        frmPOM.MinimizeBox = False
        frmPOM.MaximizeBox = False

        frmPOM.ShowDialog(Me)
        frmPOM.Dispose()
        Dim Ret As DialogResult
        Ret = frmPOMCreationConfirmation.ShowDialog(Me)

        If Ret = MsgBoxResult.Ok Then
            gSQLUpdateData("UPDATE BILLS SET POMID=" & POMID & " WHERE BillID in (" & String.Join(", ", BillID) & ")")
            If ListViewPatients.CheckedItems.Count = 0 Then
                LI = ListViewPatients.SelectedItems(0)
                With LI
                    .SubItems(14).Text = POMID & "P"
                    .SubItems(14).BackColor = Color.Gold
                    .SubItems(14).Tag = "POM Pending"
                    .ToolTipText &= vbCrLf & "POM Pending"
                End With
            Else
                For Each LI In ListViewPatients.CheckedItems
                    With LI
                        .SubItems(14).Text = POMID & "P"
                        .SubItems(14).BackColor = Color.Gold
                        .SubItems(14).Tag = "POM Pending"
                        .ToolTipText &= vbCrLf & "POM Pending"
                    End With
                Next
            End If
        Else
            'gSQLUpdateData("DELETE FROM POM WHERE POMID=" & POMID)
            'MsgBox("The POM Registration Number has been deleted." & vbCrLf & "If generated POM was printed, it should be destroyed.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If ListViewPatients.CheckedItems.Count = 0 Then
            If ListViewPatients.SelectedItems.Count = 0 Then
                e.Cancel = True
                Exit Sub
            End If
            mnuPrintAll2.Visible = False
            mnuPrintCheckedOnly2.Visible = False
        Else
            mnuPrintAll2.Visible = True
            mnuPrintCheckedOnly2.Visible = True
        End If
        Setup_Menus(e)
        EFileSelectedBillToolStripMenuItem.Visible = gEnableElectronicBillFiling > 0
    End Sub

    Private Sub Setup_Menus(ByVal e As System.ComponentModel.CancelEventArgs)
        Dim mnu As Object

        If ListViewPatients.Items.Count = 0 Or ListViewPatients.SelectedItems.Count = 0 Then
            If Not e Is Nothing Then e.Cancel = True
            Exit Sub
        Else
            For Each mnu In ContextMenuStrip1.Items
                mnu.Enabled = True
                If TypeOf mnu Is ToolStripMenuItem Then
                    Enable_Menus(mnu)
                End If
            Next

            For Each mnu In ToolStrip2.Items
                mnu.Enabled = True
                If TypeOf mnu Is ToolStripDropDownButton Then
                    Enable_Menus(mnu)
                End If
            Next

        End If
        mnuProcessSelectedPOM1.Enabled = True
        mnuProcessSelectedPOM2.Enabled = True

        If ListViewPatients.SelectedItems.Count = 0 Then
            mnuBillingTools1.Enabled = False
            mnuRemoveBillFromAttorney1.Enabled = False
        Else
            mnuRemoveBillFromAttorney1.Enabled = ListViewPatients.SelectedItems(0).SubItems(12).Text <> ""
        End If
        mnuPrintCheckedBills1.Enabled = ListViewPatients.SelectedItems.Count > 0
        mnuPrintCheckedBills2.Enabled = ListViewPatients.SelectedItems.Count > 0
        mnuPrintCheckedBills3.Enabled = ListViewPatients.SelectedItems.Count > 0

        If ListViewPatients.CheckedItems.Count = 0 Then
            mnuPrintCheckedEnvelopes1.Enabled = ListViewPatients.SelectedItems.Count > 0
            mnuPrintCheckedPOM1.Enabled = ListViewPatients.SelectedItems.Count > 0
            mnuPrintCheckedPOM2.Enabled = ListViewPatients.SelectedItems.Count > 0
        End If

        mnuAttorney1.Enabled = (ListViewPatients.SelectedItems.Count > 0 Or ListViewPatients.CheckedItems.Count > 0)
        mnuSendToAttorney1.Enabled = (ListViewPatients.SelectedItems.Count > 0 Or ListViewPatients.CheckedItems.Count > 0)
        If ListViewPatients.Items.Count = 0 Then
            mnuPrintAll1.Visible = False
            mnuPrintAll2.Visible = False
        Else
            mnuPrintAll1.Visible = True
            mnuPrintAll2.Visible = True
        End If
        If ListViewPatients.CheckedItems.Count = 0 Then
            mnuPrintCheckedOnly1.Visible = False
            mnuPrintCheckedOnly2.Visible = False
        Else
            mnuPrintCheckedOnly1.Visible = True
            mnuPrintCheckedOnly2.Visible = True
        End If
        mnuBillDenied1.Enabled = False
        mnuBillDenied2.Enabled = False
        If ListViewPatients.SelectedItems.Count > 0 Then
            If ListViewPatients.SelectedItems(0).SubItems(9).Tag <> 6 Then
                mnuBillDenied1.Enabled = True
                mnuBillDenied2.Enabled = True
            End If
        End If

        If ListViewPatients.SelectedItems.Count > 0 Then
            DeleteBillToolStripMenuItem.Enabled = True
            DeleteBillToolStripMenuItem2.Enabled = True
            If ListViewPatients.SelectedItems(0).SubItems(9).Tag <> 1 Then
                DeleteBillToolStripMenuItem.Enabled = False
                DeleteBillToolStripMenuItem2.Enabled = False
            End If
        Else
            DeleteBillToolStripMenuItem.Enabled = False
            DeleteBillToolStripMenuItem2.Enabled = False
        End If
        If ListViewPatients.SelectedItems.Count > 0 Then
            If ListViewPatients.SelectedItems(0).SubItems(3).Text.ToUpper = "CASH" Then
                DeleteBillToolStripMenuItem.Enabled = False
                DeleteBillToolStripMenuItem2.Enabled = False
                mnuBillDenied1.Enabled = False
                mnuBillDenied2.Enabled = False
                mnuPrintCheckedEnvelopes1.Enabled = False
                mnuPrintCheckedEnvelopes2.Enabled = False
                ToolStripMenuItemPrintCover.Enabled = False
                mnuBillingTools1.Enabled = False
                mnuBillingTools2.Enabled = False

                mnuPrintCheckedBills1.Enabled = False
                mnuPrintCheckedBills2.Enabled = False
                mnuPrintCheckedBills3.Enabled = False

                mnuPOM1.Enabled = False
                mnuPOM2.Enabled = False

                mnuAttorney1.Enabled = False
                mnuAttorney2.Enabled = False
                ToolStripMenuItemRequest.Enabled = False
            End If
        Else
            DeleteBillToolStripMenuItem.Enabled = False
            DeleteBillToolStripMenuItem2.Enabled = False
            mnuBillDenied1.Enabled = False
            mnuBillDenied2.Enabled = False
            mnuPrintCheckedEnvelopes1.Enabled = False
            mnuPrintCheckedEnvelopes2.Enabled = False
            ToolStripMenuItemPrintCover.Enabled = False
            mnuBillingTools1.Enabled = False
            mnuBillingTools2.Enabled = False

            mnuPrintCheckedBills1.Enabled = False
            mnuPrintCheckedBills2.Enabled = False
            mnuPrintCheckedBills3.Enabled = False

            mnuPOM1.Enabled = False
            mnuPOM2.Enabled = False

            mnuAttorney1.Enabled = False
            mnuAttorney2.Enabled = False
            ToolStripMenuItemRequest.Enabled = False
        End If
        AdminToolsToolStripMenuItem.Visible = (gCurrentEmployee.PositionID < 3)
        AdminToolsToolStripSeparator.Visible = (gCurrentEmployee.PositionID < 3)
        ClearAttorneyCaseNumberToolStripMenuItem.Enabled = ListViewPatients.SelectedItems(0).SubItems(19).Text <> ""
        ClearAttorneyCaseNumberToolStripMenuItem1.Enabled = ListViewPatients.SelectedItems(0).SubItems(19).Text <> ""
        If Val(ListViewPatients.SelectedItems(0).SubItems(9).Tag) = 8 Or Val(ListViewPatients.SelectedItems(0).SubItems(9).Tag) = 13 Then
            mnuAttorney1.Enabled = False
            mnuAttorney2.Enabled = False
            mnuCollection1.Enabled = False
            mnuCollection2.Enabled = False
            ToolStripButton3.Enabled = False
        End If
        If Val(ListViewPatients.SelectedItems(0).SubItems(9).Tag) = 13 Then
            mnuAttorney1.Enabled = False
            mnuAttorney2.Enabled = False
            mnuCollection1.Enabled = False
            mnuCollection2.Enabled = False
            mnuBillingTools1.Enabled = False
            mnuBillingTools2.Enabled = False
            ToolStripButton3.Enabled = False
            mnuPOM2.Enabled = False
            mnuPOM1.Enabled = False
            ToolStripMenuItemRequest.Enabled = False
            ToolStripButton7.Enabled = False
            AdminToolsToolStripMenuItem.Enabled = False
            For Each mnu In ContextMenuStrip1.Items
                mnu.Enabled = True
                If TypeOf mnu Is ToolStripMenuItem Then
                    Disable_Menus(mnu)
                End If
            Next
            SelectAllToolStripMenuItem.Enabled = True
            SelectNoneToolStripMenuItem.Enabled = True
        End If

    End Sub

    Private Sub Enable_Menus(ByVal mnu)
        Dim M As Object
        mnu.Enabled = True
        For Each M In mnu.DropDownItems
            If TypeOf M Is ToolStripMenuItem Then
                Enable_Menus(M)
            End If
        Next
        ToolStripButtoneFile.Visible = gEnableElectronicBillFiling > 0
    End Sub

    Private Sub Disable_Menus(ByVal mnu)
        Dim M As Object
        mnu.Enabled = False
        For Each M In mnu.DropDownItems
            If TypeOf M Is ToolStripMenuItem Then
                Enable_Menus(M)
            End If
        Next
    End Sub

    Private Sub Print_Label(ByVal PatientID As Long)
        Dim intCounter As Integer
        Dim CR As ReportDocument
        Dim ConInfo As New TableLogOnInfo
        CR = New eMedicalOffice.rptPatientFileLabel

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

    Delegate Sub MethodInvoker(ByVal arg As Object)

    Private Sub Load_Patient_Bills(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String = ""
        Dim ParentNode As TreeNode = Nothing
        Dim ChildNode As TreeNode = Nothing
        Dim DiagNode As TreeNode = Nothing
        Dim Icn As String = ""
        Dim SaveBillID As Long = 0
        Dim SaveProcedureID As Long = 0
        Try
            If TreeViewBills.InvokeRequired Then
                Me.Invoke(New MethodInvoker(AddressOf Load_Patient_Bills), ID)
                Exit Sub
            End If
            SQL = "SELECT    BillProcedures.PatientProcedureID,    Bills.CopyFromBillID, Bills.SplitBillID, Bills.BillDate, BillProcedures.BillID, Bills.BillAmount, Bills.BillStatusID, BillStatus.Description AS BillStatus,  BillDiagnosis.ICDCode, BillDiagnosis.ICDDescription, BillProcedures.ProcName "
            SQL &= " FROM            Bills INNER JOIN BillProcedures ON Bills.BillID = BillProcedures.BillID LEFT OUTER JOIN BillStatus ON Bills.BillStatusID = BillStatus.BillStatusID LEFT OUTER JOIN BillDiagnosis ON BillProcedures.BillID = BillDiagnosis.BillID  "
            SQL &= " WHERE Bills.PatientID = " & ID
            SQL &= " ORDER BY Bills.BillID "
            Reader = gSQLGetDataReader(SQL)
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
                    ParentNode = TreeViewBills.Nodes.Add("K" & Reader("BillID").ToString, Reader("BillID").ToString & "  " & CDate(Reader("BillDate")).ToString("MM/dd/yyyy") & "   " & CDbl(Reader("BillAmount")).ToString("c") & " " & Reader("BillStatus").ToString, Icn, Icn)
                    'ParentNode.BackColor = SystemColors.Highlight
                    'ParentNode.ForeColor = SystemColors.HighlightText
                    'ParentNode.NodeFont = New Font(TreeViewBills.Font, FontStyle.Bold)
                    ParentNode.Tag = New ValueDescription(Reader("BillID").ToString, "", Val(Reader("SplitBillID").ToString))
                    ParentNode.ToolTipText = "Bill Status: " & Reader("BillStatus").ToString
                    If IsNumeric(Reader("CopyFromBillID").ToString) Then
                        ParentNode.ToolTipText = ParentNode.ToolTipText & vbCrLf & "Bill ReProduced from the Bill Number: " & Reader("CopyFromBillID").ToString
                    End If
                    'If Val(Reader("SplitBillID").ToString) > 0 Then
                    ' ParentNode.ForeColor = Color.BlueViolet
                    ' ParentNode.ToolTipText = ParentNode.ToolTipText & vbCrLf & "Split Bill: " & Reader("SplitBillID").ToString
                    'End If
                End If
                If SaveProcedureID <> Reader("PatientProcedureID").ToString Then
                    SaveProcedureID = Reader("PatientProcedureID").ToString
                    ChildNode = ParentNode.Nodes.Add("", Reader("ProcName").ToString, "PROC", "PROC")
                    ChildNode.Tag = Reader("PatientProcedureID").ToString
                End If
                DiagNode = ChildNode.Nodes.Add("", Reader("ICDCode").ToString & "   " & Reader("ICDDescription").ToString, "DIAG", "DIAG")
            Loop
            Reader.Close() : Reader.Dispose()
            'TreeViewBills.ExpandAll()

        Catch ex As Exception
            log.Error(ex)
        End Try
        TreeViewBills.EndUpdate()
    End Sub

    Private Sub ButtonDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDetails.Click

        SplitContainer2.Panel2Collapsed = True
        PanelShowBills.Visible = True
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        PanelShowBills_Click(Nothing, Nothing)
    End Sub

    Private Sub PanelShowBills_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelShowBills.Click
        LockWindowUpdate(SplitContainer2.Handle)
        SplitContainer2.Panel2Collapsed = False
        Application.DoEvents()
        TabControl1.SelectedIndex = 0
        PanelShowBills.Visible = False
        TimerDetails.Enabled = True
        LockWindowUpdate(0)
    End Sub

    Private Sub PanelShowBills_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelShowBills.Paint
        ' Translate to the origin, rotate, and translate back.

        If PanelShowBills.Visible = False Then Exit Sub
        Dim B As New SolidBrush(Label16.ForeColor)
        With e.Graphics
            Dim sf As New StringFormat
            .TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
            sf.LineAlignment = StringAlignment.Center
            sf.Alignment = StringAlignment.Center
            sf.FormatFlags = StringFormatFlags.DirectionVertical
            .DrawString("PATIENT BILLS / COMMENTS", Label16.Font, B, New RectangleF(-3, 0, 12, 190), sf)
        End With

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddSelectedBillNotes1.Click, mnuAddSelectedBillNotes2.Click, mnuAddSelectedBillNotes3.Click
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to add notes. No Bill Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        frmAddCommentBilling.BillID = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value
        If frmAddCommentBilling.ShowDialog = Windows.Forms.DialogResult.OK Then
            Load_Comments(CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value)
        End If
        frmAddCommentBilling.Dispose()

    End Sub

    Private Sub ListViewComments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewComments.DoubleClick
        ToolStripButton5_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewComments_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewComments.SelectedIndexChanged
        If ListViewComments.SelectedItems.Count > 0 Then
            txtComments.Text = ListViewComments.SelectedItems(0).Tag
        Else
            txtComments.Text = ""
        End If
    End Sub

    Private Sub txtComments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComments.DoubleClick
        If txtComments.Text.Trim = "" Then Exit Sub
        ToolStripButton5_Click(Nothing, Nothing)
    End Sub

    Private Sub txtComments_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComments.KeyDown
        e.Handled = True
    End Sub

    Private Sub txtComments_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComments.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtComments_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComments.TextChanged

    End Sub

    Private Sub txtBillNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBillNumber.KeyPress
        'e.Handled = gNumbersOnly(e.KeyChar, txtBillNumber, False)
    End Sub

    Public AtterneyID As Long
    Public AtterneyName As String
    Public StatusID As Integer

    Private Sub SendToAttorneyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub mnuPrintSelectedFileLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintSelectedFileLabel1.Click, mnuPrintSelectedFileLabel2.Click
        Dim ID As Long
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to print the Patient's File Label. No patient selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ID = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value1
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Print_Label(ID)
        Cursor = Cursors.Default
    End Sub

    Private Sub ReProduceBillToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReProduce_Bill()
    End Sub

    Private Sub mnuShowSelectedPatientInfo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowSelectedPatientInfo2.Click, mnuShowSelectedPatientInfo1.Click
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.InitialPatientName = LI.Text
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.ShowDialog(Me)
        End Using
        'Dim frm As Form = FormsCollection.FindForm("frmPatient")
        'If Not frm Is Nothing Then
        '    Dim NewFrm As New frmPatient
        '    NewFrm.InitialTab = 0
        '    NewFrm.InitialPatientName = LI.Text
        '    NewFrm.ShowDialog(Me)
        '    'MsgBox("The Patient's information window is already opened." & vbCrLf & vbCrLf & "Please close the previous patient information window before opening a new one.", MsgBoxStyle.Exclamation)
        '    'frm.WindowState = FormWindowState.Normal
        '    'frm.BringToFront()
        '    'Exit Sub
        'Else
        '    frmPatient.InitialTab = 0
        '    frmPatient.InitialPatientName = LI.Text
        '    frmPatient.ShowDialog(Me)
        'End If
    End Sub

    Private Sub SendToAttorneyToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSendToAttorney1.Click, mnuSendToAttorney2.Click

        ExportAttorneyDocumentsToolStripMenuItem_Click(Nothing, Nothing)
        Exit Sub

        Dim BillID() As String = Nothing
        Dim BillIDString As String = ""
        Dim I As Integer = 0
        Dim LI As ListViewItem
        Dim BillAttorneys As String = ""
        Dim WrongBills As String = ""
        Dim AttorneyBillsCount As Integer = 0
        AtterneyID = 0
        AtterneyName = ""
        StatusID = 0
        If ListViewPatients.CheckedItems.Count = 0 Then
            If ListViewPatients.SelectedItems.Count = 0 Then
                MsgBox("Unable to process. No bills checked / selected. Please check/select the bill(s) and try again.", MsgBoxStyle.Critical)
                ListViewPatients.Focus()
                Exit Sub
            Else
                ListViewPatients.SelectedItems(0).Checked = True
            End If
        Else
            ListViewPatients.Items(ListViewPatients.CheckedItems(0).Index).Selected = True
            ListViewPatients.Items(ListViewPatients.CheckedItems(0).Index).EnsureVisible()
        End If
        For Each LI In ListViewPatients.CheckedItems
            With LI
                If .SubItems(12).Text <> "" Then
                    BillAttorneys &= "Bill#: " & .SubItems(4).Text & ", Patient: " & .SubItems(1).Text & ", Attorney: " & .SubItems(12).Text & vbCrLf
                    AttorneyBillsCount = AttorneyBillsCount + 1
                End If
                If Val(.SubItems(9).Tag) = 7 Or Val(.SubItems(9).Tag) = 8 Or Val(.SubItems(9).Tag) = 13 Then
                    WrongBills &= "Bill#: " & .SubItems(4).Text & ", Patient: " & .SubItems(1).Text & ", Status: " & .SubItems(9).Text & vbCrLf
                End If
                If Val(.SubItems(3).Tag) > 3 Then
                    WrongBills &= "Bill#: " & .SubItems(4).Text & ", Patient: " & .SubItems(1).Text & ", Case Type: " & .SubItems(3).Text & vbCrLf
                End If
            End With
        Next
        If WrongBills <> "" Then
            If WrongBills <> "" Then WrongBills = "Wrong Status: " & vbCrLf & WrongBills & vbCrLf
            MsgBox("The following bill(s) can not be processed:" & vbCrLf & vbCrLf & WrongBills & vbCrLf & vbCrLf & "Please review the checked bills list and try again.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        'If AttorneyBillsCount > 0 Then
        '    If AttorneyBillsCount = 1 Then
        '        If MsgBox("The following bill was previously assigned to the attorney:" & vbCrLf & vbCrLf & BillAttorneys & vbCrLf & vbCrLf & "Please confirm you want to resubmit this bill to the different attorney?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '            Exit Sub
        '        End If
        '    Else
        '        If MsgBox("The following bills was previously assigned to the attorneys:" & vbCrLf & vbCrLf & BillAttorneys & vbCrLf & vbCrLf & "Please confirm you want to resubmit selected bills to the different attorney?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '            Exit Sub
        '        End If
        '    End If
        'End If

        '''''''   NEW LOGIC
        For Each LI In ListViewPatients.CheckedItems
            ReDim Preserve BillID(I)
            BillID(I) = CType(LI.Tag, ValueDescription).Value
            I = I + 1
            BillIDString &= CType(LI.Tag, ValueDescription).Value & ", "
            LI.Selected = True
            LI.EnsureVisible()
            Application.DoEvents()
            ExportAttorneyDocumentsToolStripMenuItem_Click(Nothing, Nothing)
        Next

        Exit Sub
        '''''''''''''''''''''''''''

        frmBillingSelectLower.Label1.Text = "Please select an attorney for the " & ListViewPatients.CheckedItems.Count & " checked bills"
        frmBillingSelectLower.CalledForm = Me
        If frmBillingSelectLower.ShowDialog <> Windows.Forms.DialogResult.OK Then
            frmBillingSelectLower.Dispose()
            Exit Sub
        End If
        frmBillingSelectLower.Dispose()
        'Status 9
        For Each LI In ListViewPatients.CheckedItems
            ReDim Preserve BillID(I)
            BillID(I) = CType(LI.Tag, ValueDescription).Value
            I = I + 1
            BillIDString &= CType(LI.Tag, ValueDescription).Value & ", "
            LI.Selected = True
            LI.EnsureVisible()
            ExportAttorneyDocumentsToolStripMenuItem_Click(Nothing, Nothing)
        Next

        Exit Sub
        BillIDString = BillIDString.Mid(1, BillIDString.Length - 2)
        gSQLUpdateData("Update Bills set AttorneyCaseNumber=Null, AttorneyCaseNumberDate=Null, BillStatusID=" & StatusID & ", AttorneyDate = getdate(), AttorneyCompanyID = " & AtterneyID & " WHERE BillID in (" & BillIDString & ")")
        Dim BillStatus As String
        If StatusID = 4 Then
            BillStatus = "Attorney L"
        Else
            BillStatus = "Attorney A"
        End If
        'frmCoverPageReport.Setup_report(BillID)
        'frmCoverPageReport.ShowDialog(Me)
        'If frmCoverPageReport.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        For Each LI In ListViewPatients.CheckedItems
            'gSetListItemColor(LI, Color.DarkOrange)
            With LI
                If .SubItems(12).Text <> "" Then
                    gUpdate_Profile_Log(CType(.Tag, ValueDescription).Value1, PatientLogTypes.tAttorneyAssigned, "Attorney ReAssigned. Previous Attorney: " & .SubItems(12).Text & " New Attorney: " & AtterneyName)
                Else
                    gUpdate_Profile_Log(CType(.Tag, ValueDescription).Value1, PatientLogTypes.tAttorneyAssigned, "Attorney Assigned. Bill Status:" & BillStatus)
                End If
                .SubItems(9).BackColor = Color.DarkOrange
                .SubItems(9).Text = BillStatus
                .SubItems(9).Tag = StatusID
                .SubItems(12).Text = AtterneyName
                .SubItems(12).Tag = AtterneyID
                .SubItems(19).Text = ""
                .SubItems(26).Text = ""
                .SubItems(13).Text = Now.ToShortDateString
                .SubItems(19).BackColor = Color.PeachPuff
                .SubItems(26).BackColor = Color.PeachPuff

            End With
        Next
        'Else
        'For Each LI In ListViewPatients.CheckedItems
        ' If IsNumeric(LI.SubItems(12).Tag) Then
        ' gSQLUpdateData("Update Bills set BillStatusID=" & Val(LI.SubItems(9).Tag) & ", AttorneyDate = '" & CDate(LI.SubItems(13).Text) & "', AttorneyCompanyID = " & Val(LI.SubItems(12).Tag) & " WHERE BillID = " & CType(LI.Tag, ValueDescription).Value)
        ' Else
        ' gSQLUpdateData("Update Bills set BillStatusID=" & Val(LI.SubItems(9).Tag) & ", AttorneyDate = null, AttorneyCompanyID = null WHERE BillID = " & CType(LI.Tag, ValueDescription).Value)
        ' End If
        'Next
        'End If
        'frmNF3Report.Dispose()
    End Sub

    Private ApprovedByID As Long
    Private ApprovedByName As String

    Private Sub mnuRemoveBillFromAttorney1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRemoveBillFromAttorney1.Click, mnuRemoveBillFromAttorney2.Click
        Dim LI As ListViewItem

        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        LI = ListViewPatients.SelectedItems(0)
        If LI.SubItems(12).Text = "" Then
            MsgBox("Unable to process your request. No Attorney assigned to the current bill.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim BillID As Long = CType(LI.Tag, ValueDescription).Value
        Dim PatientID As Long = CType(LI.Tag, ValueDescription).Value1
        Dim PatientName As String = LI.SubItems(1).Text
        Dim Attorney As String = LI.SubItems(12).Text
        Dim AttorneyID As String = Val(LI.SubItems(12).Tag)

        If gCurrentEmployee.PositionID > 3 Then
            frmSupervisorApproval.LabelMsg.Text = "Remove Attorney From Bill#: " & BillID & ", Patient: " & PatientName
            If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frmSupervisorApproval.Dispose()
                Exit Sub
            End If
            ApprovedByID = frmSupervisorApproval.SupervisorID
            ApprovedByName = frmSupervisorApproval.SupervisorName
            frmSupervisorApproval.Dispose()
        Else
            If MsgBox("Please confirm the Attorney removal from the" & vbCrLf & "Bill#: " & BillID & ", Patient: " & PatientName & "?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                Exit Sub
            End If
            ApprovedByID = gCurrentEmployee.EmpID
            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If

        gSQLUpdateData("Update Bills set AttorneyFeesPaid=0, AttorneyFeesDate=null, AttorneyFeesCheckNumber=null, FilingFee=0, FilingFeePaidDate=null, AttorneyCaseNumber = null, AttorneyCaseNumberDate=null, BillStatusID=1, AttorneyDate = Null, AttorneyCompanyID = Null Where BillID = " & BillID)

        With LI
            .SubItems(9).BackColor = Color.White
            .SubItems(9).Text = "Bill Created"
            .SubItems(9).Tag = 1
            .SubItems(12).Text = ""
            .SubItems(12).Tag = 0
            .SubItems(13).Text = ""
        End With

        gSQLUpdateData("INSERT INTO AttorneyDocumentsAccessLog (BillID, WebDocID, DocumentName, StatusID, StatusDate, ChangedBy) SELECT BillID, WebDocID, DocName, 3 as StatusID, getdate() as StatusDate, '" & ToSafeSQLString(gCurrentEmployee.FName & " " & gCurrentEmployee.LName) & "' as ChangedBy From AttorneyDocumentsAccess Where  AttorneyID = " & AttorneyID & " AND BillID=" & BillID & " AND StatusID <> 3")

        gSQLUpdateData("DELETE From AttorneyDocumentsAccess Where AttorneyID = " & AttorneyID & " and BillID = " & BillID)

        gUpdate_Profile_Log(PatientID, PatientLogTypes.tAttorneyRemoved, "Bill#: " & BillID & ", Attorney " & Attorney & " Has Been Removed", ApprovedByName)

    End Sub

    Private Sub ToolStripMenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProcessSelectedPOM1.Click, mnuProcessSelectedPOM2.Click
        Dim Ret As Boolean
        If gScannerMode = 1 Then
            Ret = ScanDocumentFromScannerApplication(6)
        Else
            Ret = ScanDocumentFromScanner(6)
        End If
        If Ret = True Then If ListViewPatients.Items.Count > 0 Then Find_Patients()
    End Sub

    Private Function ScanDocumentFromScanner(ByVal DocProfileID As Integer, Optional ByVal PatientID As Integer = 0) As Boolean
        frmDocumentScannerPDF.IniDocProfile = DocProfileID
        frmDocumentScannerPDF.PatientID = PatientID
        frmDocumentScannerPDF.MinimizeBox = False
        frmDocumentScannerPDF.MaximizeBox = False

        If frmDocumentScannerPDF.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Load_Documents(PatientID)
            ScanDocumentFromScanner = True
        End If
        frmDocumentScannerPDF.Dispose()
    End Function

    Private Function ScanDocumentFromScannerApplication(ByVal DocProfileID As Integer, Optional ByVal PatientID As Integer = 0) As Boolean
        If gScannerFolder = "" Then
            MsgBox("Unable to scan. The Scanner Folder has not been specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Function
        End If
        If IO.Directory.Exists(gScannerFolder) = False Then
            MsgBox("Unable to scan. Invalid Scanner Folder specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Function
        End If
        frmDocumentScannerExternalProgram.IniDocProfile = DocProfileID
        frmDocumentScannerExternalProgram.PatientID = PatientID
        frmDocumentScannerExternalProgram.MinimizeBox = False
        frmDocumentScannerExternalProgram.MaximizeBox = False

        If frmDocumentScannerExternalProgram.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Load_Documents(PatientID)
            ScanDocumentFromScannerApplication = True
        End If
        frmDocumentScannerExternalProgram.Dispose()
    End Function

    Private Sub mnuShowSelectedPOM1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowSelectedPOM1.Click, mnuShowSelectedPOM2.Click
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim POMID As String
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to show POM. No Bill Selected", MsgBoxStyle.Information)
            Exit Sub
        End If
        '2
        LI = ListViewPatients.SelectedItems(0)

        If LI.SubItems(9).Tag < 2 And LI.SubItems(14).Text <> "" Then
            RePrintPOM()
            Exit Sub
        End If
        'If ListViewPatients.SelectedItems(0).SubItems(9).Tag <> 2 Then
        'MsgBox("Unable to show POM." & vbCrLf & "No POM available." & vbCrLf & vbCrLf & "The POM is only available for the bill status [Bill Mailed]", MsgBoxStyle.Information)
        'Exit Sub
        'End If

        If LI.SubItems(14).Text = "" Then
            MsgBox("Unable to show POM." & vbCrLf & "The selected bill has does not have a proof of mail.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If IsNumeric(LI.SubItems(14).Text) = False Then
            MsgBox("Unable to show POM." & vbCrLf & "The selected bill prrof of mail is pending.", MsgBoxStyle.Information)
            Exit Sub
        End If

        POMID = LI.SubItems(14).Text
        If POMID = "" Then
            'MsgBox("Unable to show POM. The POM has not been registered with this bill.", MsgBoxStyle.Information)
            RePrintPOM()
            Exit Sub
        End If

        Reader = gSQLGetDataReader("SELECT POMImage FROM POM where POMID=" & Val(POMID))
        If Reader Is Nothing Then
            MsgBox("Unexpected error. Please call system administrator.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Reader.HasRows Then
            Reader.Read()
            Dim arrayImage() As Byte = CType(Reader("POMImage"), Byte())
            Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", "POM")
            If System.IO.File.Exists(FName) Then
                With frmPOMPreview
                    .Tag = POMID
                    .pdfViewer.Tag = FName
                    .MinimizeBox = False
                    .MaximizeBox = False

                    .ShowDialog(Me)
                    .Dispose()
                End With
            End If
        Else
            MsgBox("Unexpected error. No POM Image Found. Please call system administrator.", MsgBoxStyle.Critical)
            Exit Sub
        End If
    End Sub

    Private Sub mnuFindPOM1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFindPOM1.Click, mnuFindPOM2.Click
        frmFindPOM.MinimizeBox = False
        frmFindPOM.MaximizeBox = False

        frmFindPOM.ShowDialog(Me)
        frmFindPOM.Dispose()

    End Sub

    Private Sub mnuSelectedBillPayment1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectedBillPayment1.Click, mnuSelectedBillPayment2.Click
        Dim BillID As Long
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""
        Dim LI As ListViewItem
        Dim SelectedLI As ListViewItem
        Dim PaidAmount As Double
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to process. No bills selected.", MsgBoxStyle.Critical)
            ListViewPatients.Focus()
            Exit Sub
        End If
        SelectedLI = ListViewPatients.SelectedItems(0)
        If Val(SelectedLI.SubItems(9).Tag) = 8 Or Val(SelectedLI.SubItems(9).Tag) = 13 Then
            MsgBox("Unable to set payment for the canceled bill.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim PatID As Long

        BillID = CType(SelectedLI.Tag, ValueDescription).Value
        PatID = Val(SelectedLI.Text)
        With frmAddPayment
            SQL = "SELECT   PatientID,  isnull(BillAmount,0) as BillAmount, isnull(PaidAmount,0) as PaidAmount FROM         Bills Where BillID=" & BillID
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then
                MsgBox("Unexpected Error. Please call your system administrator.")
                Exit Sub
            End If
            If Reader.HasRows Then
                Reader.Read()
                .PatientID = Reader("PatientID").ToString
                PatID = Reader("PatientID").ToString
                .txtPaid.Text = CDbl(Reader("PaidAmount").ToString).ToString("c")
                .txtBillAmount.Text = CDbl(Reader("BillAmount")).ToString("c")
                .txtRemaining.Text = CDbl(Reader("BillAmount") - Reader("PaidAmount")).ToString("c")
                .txtRemaining.Tag = CDbl(Reader("BillAmount") - Reader("PaidAmount")).ToString("c")
                '.txtAmount.Text = .txtRemaining.Text
            End If
            Reader.Close() : Reader.Dispose()
            SQL = "SELECT     Bills.BillID, Bills.BillDate, ISNULL(Bills.BillAmount, 0) AS BillAmount, BillStatus.Description AS BillStatus, ISNULL(Bills.PaidAmount, 0) AS PaidAmount,Bills.ServiceFrom, Bills.ServiceTo  "
            SQL &= "FROM         Bills LEFT OUTER JOIN "
            SQL &= "                      BillStatus ON Bills.BillStatusID = BillStatus.BillStatusID"

            SQL &= " WHERE Bills.PatientID = " & PatID
            SQL &= " ORDER BY Bills.BillID "
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then
                MsgBox("Unexpected Error. Please call your system administrator.")
                Exit Sub
            End If
            .ListViewBills.Items.Clear()
            Do Until Reader.Read = False
                LI = .ListViewBills.Items.Add("K" & Reader("BillID").ToString, Reader("BillID").ToString, "")
                If IsDate(Reader("BillDate").ToString) Then
                    LI.SubItems.Add(CDate(Reader("BillDate")).ToString("MM/dd/yyyy"))
                Else
                    LI.SubItems.Add("")
                End If

                LI.SubItems.Add(Reader("BillStatus").ToString)
                LI.SubItems.Add(CDbl(Reader("BillAmount").ToString).ToString("c"))
                LI.SubItems.Add(CDbl(Reader("PaidAmount").ToString).ToString("c"))
                If CDbl(Reader("BillAmount").ToString) = CDbl(Reader("PaidAmount").ToString) Then
                    gSetListItemColor(LI, Color.DarkSeaGreen)
                End If
                If IsDate(Reader("ServiceFrom").ToString) Then
                    LI.SubItems.Add(FormatDateTime(Reader("ServiceFrom").ToString, DateFormat.ShortDate) & "  -  " & FormatDateTime(Reader("ServiceTo").ToString, DateFormat.ShortDate))
                Else
                    LI.SubItems.Add("")
                End If

            Loop
            Reader.Close() : Reader.Dispose()

            SQL = "SELECT     BillPayments.PaymentDate, BillPaymentTypes.Description, BillPayments.PaymentAmount, BillPayments.CheckNumber, BillPaymentNotes.Description AS Notes"
            SQL &= " FROM         BillPayments LEFT OUTER JOIN BillPaymentNotes ON BillPayments.NoteID = BillPaymentNotes.NoteID LEFT OUTER JOIN BillPaymentTypes ON BillPayments.PaymentTypeID = BillPaymentTypes.PaymentTypeID "
            SQL &= " WHERE BillPayments.BillID = " & BillID
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then
                MsgBox("Unexpected Error. Please call your system administrator.")
                Exit Sub
            End If
            .ListView1.Items.Clear()
            Do Until Reader.Read = False
                With .ListView1.Items
                    If IsDate(Reader("PaymentDate").ToString) Then
                        LI = .Add(CDate(Reader("PaymentDate")).ToString("MM/dd/yyyy"))
                    Else
                        LI = .Add("")
                    End If
                    LI.SubItems.Add(Reader("Description").ToString)
                    LI.SubItems.Add(CDbl(Reader("PaymentAmount").ToString).ToString("c"))
                    LI.SubItems.Add(Reader("CheckNumber").ToString)
                    LI.SubItems.Add(Reader("Notes").ToString)
                End With
            Loop
            frmAddPayment.lblMsg.Text = "Bill #" & BillID
            frmAddPayment.BillID = BillID

            Dim BillAmount As Double
            frmAddPayment.MinimizeBox = False
            frmAddPayment.MaximizeBox = False

            PaymentScanCheck = False
            If frmAddPayment.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                PaidAmount = gSQLGetSingleValue("SELECT PaidAmount From Bills Where BillID=" & BillID)
                BillAmount = gSQLGetSingleValue("SELECT BillAmount From Bills Where BillID=" & BillID)
                Load_Payments(BillID)
                Load_Comments(BillID)
                SelectedLI.SubItems(9).Text = "Paid"
                SelectedLI.SubItems(9).Tag = 3
                SelectedLI.SubItems(15).Text = PaidAmount.ToString("c")
                SelectedLI.SubItems(16).Text = (BillAmount - PaidAmount).ToString("c")
                SelectedLI.SubItems(9).BackColor = Color.LightGreen
            End If
            frmAddPayment.Dispose()
            Application.DoEvents()
            If PaymentScanCheck Then
                If gScannerMode = 1 Then
                    ScanDocumentFromScannerApplication(5, PatID)
                Else
                    ScanDocumentFromScanner(5, PatID)
                End If
            End If
        End With
        Count_Selected()
    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mnuSelectedBillPayment1_Click(Nothing, Nothing)
    End Sub

    Private Sub PrintResultListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintResultList.Click
        'If ListViewPatients.CheckedItems.Count = 0 Then
        'Print_Listview(True)
        'End If

    End Sub

    Private Sub Print_Listview(Optional ByVal All As Boolean = True)
        Dim CH As ColumnHeader = Nothing
        Dim LI As ListViewItem
        Dim I As Integer
        Dim C As Integer
        Dim C1
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        With FpSpreadForPrint
            If ListViewPatients.Items.Count = 0 Then
                MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            .ActiveSheet.ColumnCount = ListViewPatients.Columns.Count
            For C = 0 To ListViewPatients.Columns.Count - 1
                For C1 = 0 To ListViewPatients.Columns.Count - 1
                    If ListViewPatients.Columns(C1).DisplayIndex = C Then
                        CH = ListViewPatients.Columns(C1)
                        Exit For
                    End If
                Next
                I += 1
                'FpSpread1.ActiveSheet.Columns(I - 1).CellType = CT
                .ActiveSheet.ColumnHeader.Rows(0).Height = 32
                Select Case CH.TextAlign
                    Case HorizontalAlignment.Left
                        .ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                    Case HorizontalAlignment.Right
                        .ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                    Case HorizontalAlignment.Center
                        .ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                End Select
                .ActiveSheet.Columns(I - 1).Tag = CH.Index
                .ActiveSheet.Columns(I - 1).Width = CH.Width
                Select Case CH.Text
                    Case "Patient #"
                        .ActiveSheet.Columns(I - 1).Label = "##"
                    Case "Amt $"
                        .ActiveSheet.Columns(I - 1).Label = "Amt"
                    Case "Paid Amt $"
                        .ActiveSheet.Columns(I - 1).Label = "Paid"
                    Case "Balance $"
                        .ActiveSheet.Columns(I - 1).Label = "Balance"
                    Case Else
                        .ActiveSheet.Columns(I - 1).Label = CH.Text
                End Select

            Next
            I = 0
            .ActiveSheet.RowCount = 0
            For Each LI In ListViewPatients.Items
                If All = True Or LI.Checked = True Then
                    I += 1
                    .ActiveSheet.RowCount = I
                    For C = 0 To .ActiveSheet.ColumnCount - 1
                        .ActiveSheet.SetText(I - 1, C, LI.SubItems(.ActiveSheet.Columns(C).Tag).Text)
                    Next
                End If
            Next
            Printinfo.SmartPrintPagesWide = 1
            Printinfo.Preview = True
            Printinfo.Header = "BILLING MANAGEMENT / COLLECTION SEARCH RESULT AS OF " & Now & vbCrLf & vbCrLf
            Printinfo.BestFitRows = False
            Printinfo.BestFitCols = True
            Printinfo.ShowShadows = False
            Printinfo.JobName = "eMedical Office Billing Management"
            Printinfo.PrintType = FarPoint.Win.Spread.PrintType.All
            Printinfo.ShowColor = True
            Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
            Printinfo.ShowBorder = False
            Printinfo.ShowGrid = True
            Printinfo.ShowPrintDialog = True
            Printinfo.Preview = False
            Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
            Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
            Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.All))
            Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.BestFitColumnRule(FarPoint.Win.Spread.ResetOption.All))
            Printinfo.UseSmartPrint = True
            Printinfo.UseMax = True
            Printinfo.Printer = gPrinterOtherDocuments
            .ActiveSheet.PrintInfo = Printinfo
            .PrintSheet(.ActiveSheet)
        End With
    End Sub

    Private Sub mnuPrintAll1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintAll2.Click, mnuPrintAll1.Click
        Print_Listview(True)
    End Sub

    Private Sub mnuPrintCheckedOnly1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintCheckedOnly2.Click, mnuPrintCheckedOnly1.Click
        Print_Listview(False)
    End Sub

    Private Sub mnuPrinting2_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs)
        If ListViewPatients.Items.Count = 0 Then
            mnuPrintAll1.Visible = False
            mnuPrintAll2.Visible = False
        Else
            mnuPrintAll1.Visible = True
            mnuPrintAll2.Visible = True
        End If
        If ListViewPatients.CheckedItems.Count = 0 Then
            mnuPrintCheckedOnly1.Visible = False
            mnuPrintCheckedOnly2.Visible = False
        Else
            mnuPrintCheckedOnly1.Visible = True
            mnuPrintCheckedOnly2.Visible = True
        End If
    End Sub

    Private Sub RestoreColumnWidthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gListViewRestoreDefaultColumnWidth(ListViewPatients)
    End Sub

    Private Sub ReprintCoverpageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReprintCoverpage.Click, mnuReprintCoverpage1.Click, ToolStripMenuItemPrintCover.Click
        Dim BillID() As String = Nothing
        Dim I As Integer = 0

        If ListViewPatients.SelectedItems.Count = 0 And ListViewPatients.CheckedItems.Count = 0 Then
            MsgBox("Unable to reprint Attorney Coverpage. No Bill Checked / Selected!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim LI As ListViewItem
        If ListViewPatients.CheckedItems.Count = 0 Then
            ReDim Preserve BillID(0)
            BillID(I) = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value
        Else

            For Each LI In ListViewPatients.CheckedItems
                If IsNumeric(LI.SubItems(12).Tag) = False Then
                    MsgBox("Unable to reprint Attorney Coverpage. One of the checked bills has not been assigned to attorney!", MsgBoxStyle.Exclamation)
                    LI.Selected = True
                    LI.EnsureVisible()
                    Exit Sub
                End If
                ReDim Preserve BillID(I)
                BillID(I) = CType(LI.Tag, ValueDescription).Value
                I = I + 1
            Next
        End If
        frmCoverPageReport.Setup_report(BillID)
        frmCoverPageReport.MinimizeBox = False
        frmCoverPageReport.MaximizeBox = False

        frmCoverPageReport.ShowDialog(Me)
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub RePrintPOM()
        Dim BillID() As String = Nothing
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim POMID As Long = Val(ListViewPatients.SelectedItems(0).SubItems(14).Text)
        Dim I As Integer = 0
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to RePrint POM. No bill selected. Please select a bill and try again.", MsgBoxStyle.Critical)
            ListViewPatients.Focus()
            Exit Sub
        End If
        If ListViewPatients.SelectedItems(0).SubItems(14).Text = "" Then
            MsgBox("Unable to RePrint POM." & vbCrLf & "No Original POM has been created for this bill." & vbCrLf & "For new bills, please use the Create Checked Bills POM function.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        SQL = "SELECT BillID, POMID FROM Bills WHERE POMID = " & POMID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ReDim Preserve BillID(I)
            BillID(I) = Reader("BillID").ToString
            I = I + 1
        Loop
        Reader.Close() : Reader.Dispose()
        frmPOM.Setup_report(BillID, POMID)
        frmPOM.MinimizeBox = False
        frmPOM.MaximizeBox = False

        frmPOM.ShowDialog(Me)
        frmPOM.Dispose()
    End Sub

    Private Sub mnuPrintSelectedBillReadings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintSelectedBillReadings.Click, mnuPrintSelectedBillReadings2.Click
        Dim BillID As Long
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to print. No bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        BillID = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value
        Print_Readings(BillID)
    End Sub

    Private Sub Print_Readings(ByVal BillID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim PatientProcedureID() As Long = Nothing
        Dim SQL As String
        Dim I As Integer = 0
        SQL = "SELECT     BillProcedures.PatientProcedureID FROM BillProcedures INNER JOIN PatientProcedureReadings ON BillProcedures.PatientProcedureID = PatientProcedureReadings.PatientProcedureID "
        SQL &= " WHERE    BillProcedures.BillID = " & BillID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows = False Then
            MsgBox("Unable to produce Reading Report. The Bill procedures does not have readings!", MsgBoxStyle.Information)
            Exit Sub
        End If
        Do Until Reader.Read = False
            ReDim Preserve PatientProcedureID(I)
            PatientProcedureID(I) = Reader("PatientProcedureID").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        Dim PatientID As Integer = Val(ListViewPatients.SelectedItems(0).Text)
        frmReadingReport.Setup_report(PatientProcedureID, PatientID)
        frmReadingReport.MinimizeBox = False
        frmReadingReport.MaximizeBox = False

        frmReadingReport.ShowDialog(Me)
        frmReadingReport.Dispose()
    End Sub

    Private Sub Export_Listview(Optional ByVal All As Boolean = True)
        Dim CH As ColumnHeader = Nothing
        Dim LI As ListViewItem
        Dim I As Integer
        Dim C As Integer
        Dim C1
        Dim strFileName As String
        Application.DoEvents()
        If All = False Then
            If ListViewPatients.CheckedItems.Count = 0 Then
                MsgBox("Unable to process your request. No records checked.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Else
            If ListViewPatients.Items.Count = 0 Then
                MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        SaveFD.Title = "Export Billing To Excel."
        SaveFD.Filter = "MS Excel File (*.xls)|*.xls"
        Dim DidWork As Integer = SaveFD.ShowDialog()
        If DidWork = DialogResult.OK Then
            strFileName = SaveFD.FileName
        Else
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        With FpSpreadForPrint
            .ActiveSheet.RowCount = 0
            .ActiveSheet.RowCount = 1
            .ActiveSheet.ColumnCount = ListViewPatients.Columns.Count
            For C = 0 To ListViewPatients.Columns.Count - 1
                For C1 = 0 To ListViewPatients.Columns.Count - 1
                    If ListViewPatients.Columns(C1).DisplayIndex = C Then
                        CH = ListViewPatients.Columns(C1)
                        Exit For
                    End If
                Next
                I += 1
                .ActiveSheet.ColumnHeader.Rows(0).Height = 32
                Select Case CH.TextAlign
                    Case HorizontalAlignment.Left
                        .ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                    Case HorizontalAlignment.Right
                        .ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                    Case HorizontalAlignment.Center
                        .ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                End Select
                .ActiveSheet.Columns(I - 1).Tag = CH.Index
                .ActiveSheet.Columns(I - 1).Width = CH.Width
                .ActiveSheet.Columns(I - 1).Locked = False
                .ActiveSheet.SetText(0, I - 1, CH.Text)
            Next
            I = 1

            For Each LI In ListViewPatients.Items
                If All = True Or LI.Checked = True Then
                    I += 1
                    .ActiveSheet.RowCount = I
                    For C = 0 To .ActiveSheet.ColumnCount - 1
                        .ActiveSheet.SetText(I - 1, C, LI.SubItems(.ActiveSheet.Columns(C).Tag).Text.ToString)
                    Next
                End If
            Next
            .ActiveSheet.Protect = False
            Try
                .SaveExcel(strFileName)
            Catch ex As Exception
                MsgBox("Unable to save file. the file may be in use by another application or drive is full or write protected.", MsgBoxStyle.Critical)
            End Try
            .ActiveSheet.RowCount = 0
            .ResumeLayout()
            SaveFD.Reset()
            System.Diagnostics.Process.Start(strFileName)
            Cursor = Cursors.Default
        End With
    End Sub

    Private Sub Print_CheckedReadings()
        Dim BillIDs() As Long = Nothing
        Dim I As Integer = 0
        Dim LI As ListViewItem
        Dim PatientID As Integer
        If ListViewPatients.CheckedItems.Count = 0 And ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No records checked.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewPatients.CheckedItems.Count = 0 Then
            ReDim Preserve BillIDs(0)
            BillIDs(I) = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value & ", "
            PatientID = Val(ListViewPatients.SelectedItems(0).Text)

        Else
            For Each LI In ListViewPatients.CheckedItems
                ReDim Preserve BillIDs(I)
                BillIDs(I) = CType(LI.Tag, ValueDescription).Value & ", "
                I = I + 1
            Next
            If MsgBox("Would you like to print all " & ListViewPatients.CheckedItems.Count & " checked bill(s) procedures readings?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        'rptReadingsByBill.rpt()
        frmReadingReport.Setup_report_ByBills(BillIDs, PatientID)
        frmReadingReport.MinimizeBox = False
        frmReadingReport.MaximizeBox = False

        frmReadingReport.ShowDialog(Me)
        frmReadingReport.Dispose()
    End Sub

    Private Sub Print_SelectedPatientProgress()
        Dim BillID As Long = Nothing
        Dim I As Integer = 0
        Dim LI As ListViewItem

        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No records checked.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        BillID = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value
        frmPatientInforBilling.BillID = BillID
        frmPatientInforBilling.MinimizeBox = False
        frmPatientInforBilling.MaximizeBox = False
        Application.DoEvents()
        frmPatientInforBilling.ShowDialog(Me)
        frmPatientInforBilling.Dispose()
    End Sub

    Private Sub ExportAllToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportAllToExcelToolStripMenuItem.Click
        Export_Listview()
    End Sub

    Private Sub ExportCheckedToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportCheckedToExcelToolStripMenuItem.Click
        Export_Listview(False)
    End Sub

    Private Sub PrintCheckedBillsReadingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCheckedBillsReadingsToolStripMenuItem.Click
        Print_CheckedReadings()
    End Sub

    Private Sub PrintCheckedBillsReadingsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCheckedBillsReadingsToolStripMenuItem1.Click
        Print_CheckedReadings()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click

        If frmAttorneyAssignCaseNumber.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ButtonFind_Click(Nothing, Nothing)
        End If

        frmAttorneyAssignCaseNumber.Dispose()
    End Sub

    Private Sub mnuBillDenied1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBillDenied1.Click, mnuBillDenied2.Click
        Dim LI As ListViewItem = Nothing
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to process. No Bill selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        If LI Is Nothing Then Exit Sub
        If LI.SubItems(9).Tag <> 1 And LI.SubItems(9).Tag <> 6 Then
            frmBillingDenial.SLI = LI
            frmBillingDenial.BillID = CType(LI.Tag, ValueDescription).Value
            frmBillingDenial.CalledForm = Me
            frmBillingDenial.MinimizeBox = False
            frmBillingDenial.MaximizeBox = False

            frmBillingDenial.ShowDialog(Me)
            frmBillingDenial.Dispose()
            ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
            Load_Comments(CType(LI.Tag, ValueDescription).Value)
            Load_Denials(CType(LI.Tag, ValueDescription).Value)
        Else
            MsgBox("Unable to set bill status " & LI.SubItems(9).Text & " as Denied.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Count_Selected()
    End Sub

    Private Sub DeleteBillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBillToolStripMenuItem.Click, DeleteBillToolStripMenuItem2.Click
        Dim BillID As Long = 0
        Dim BillID1 As Long = 0
        Dim Bill1 As String = ""
        Dim LI As ListViewItem
        Dim ApprovedByName As String = ""
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to process. No bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        If LI Is Nothing Then Exit Sub
        BillID = CType(LI.Tag, ValueDescription).Value
        Dim PatientID As Long = CType(LI.Tag, ValueDescription).Value1
        If gSQLGetSingleValue("SELECT    count(*) FROM Bills WHERE Bills.BillStatusID=1 and  Bills.BillID = " & BillID) = 0 Then
            MsgBox("Unable to delete the selected bill. This bill has already been processed. " & vbCrLf & vbCrLf & "Only unprocessed bills can be deleted.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If gCurrentEmployee.PositionID > 3 Then
            frmSupervisorApproval.LabelMsg.Text = "Request to delete the Bill: " & BillID
            If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frmSupervisorApproval.Dispose()
                Exit Sub
            End If
            ApprovedByID = frmSupervisorApproval.SupervisorID
            ApprovedByName = frmSupervisorApproval.SupervisorName
            frmSupervisorApproval.Dispose()
        Else
            If MsgBox("Attention! This process can not be undone!" & vbCrLf & vbCrLf & "You have requested to delete the Bill: " & BillID & vbCrLf & vbCrLf & "Please make sure this bill has not been mailed to the insurance company!" & vbCrLf & "Do you want to continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tBillDeleted, "Bill #: " & BillID & " has been deleted.", ApprovedByName)

        Try
            gSQLDeleteRecord("Delete From Bills Where BillID = " & BillID)
            gSQLDeleteRecord("Delete From BillDiagnosis Where BillID = " & BillID)
            gSQLDeleteRecord("Delete From BillProcedures Where BillID = " & BillID)
            gSQLDeleteRecord("Delete From BillComments Where BillID = " & BillID)
            gSQLDeleteRecord("DELETE FROM BillPayments WHERE BillID =" & BillID)
            ListViewPatients.Items.Remove(LI)
            ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
            Count_Selected()
        Catch ex As Exception

            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try

    End Sub

    Private Sub CreateReminderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReminder.Show(Me)
    End Sub

    Private Sub ToolStripMenuItemRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemRequest.Click, ToolStripMenuItemBillingRequest1.Click
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to create Billing request. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        With LI
            frmBillingAddRequest.lblMsg.Text = "Patient: " & .SubItems(1).Text & "   Bill #: " & .SubItems(4).Text
            frmBillingAddRequest.BillAttorney = .SubItems(12).Text
            frmBillingAddRequest.BillInsurance = .SubItems(10).Text
            frmBillingAddRequest.BillID = Val(.SubItems(4).Text)
            frmBillingAddRequest.PatientID = Val(.SubItems(0).Text)
            frmBillingAddRequest.MinimizeBox = False
            frmBillingAddRequest.MaximizeBox = False
            Try
                frmBillingAddRequest.ShowDialog(Me)
            Catch ex As Exception
            End Try
            frmBillingAddRequest.Dispose()
            Load_Requests(CType(.Tag, ValueDescription).Value)
        End With
        MDIForm1Win8.TimerRefresh_Tick(Nothing, Nothing)
    End Sub

    Private Sub Load_Requests(ByVal BillID)
        If ListViewRequests.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf Load_Requests), BillID)
            Exit Sub
        End If
        Try
            Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim SaverequestID As Long
        If ListViewRequests.SelectedItems.Count > 0 Then
            SaverequestID = ListViewRequests.SelectedItems(0).Tag
        End If
        ListViewRequests.Items.Clear()
        SQL = "SELECT BillingRequests.RequestStatusID,   BillingRequests.RequestID, BillingRequests.RequestDate, BillingRequestStatuses.Description AS Status, BillingRequestStatuses.StatusID, BillingRequests.RequestDescription FROM BillingRequests INNER JOIN BillingRequestStatuses ON BillingRequests.RequestStatusID = BillingRequestStatuses.StatusID  Where BillID = " & BillID & " order by RequestDate desc"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False

                If IsDate(Reader("RequestDate").ToString) Then
                    LI = ListViewRequests.Items.Add(CDate(Reader("RequestDate").ToString).ToString("MM/dd/yy"))
                Else
                    LI = ListViewRequests.Items.Add("")
                End If
                With LI
                    .Tag = Reader("RequestID").ToString
                    .SubItems.Add(Reader("Status").ToString)
                    .SubItems.Add(Reader("RequestDescription").ToString)
                    .ToolTipText = Reader("RequestDescription").ToString
                    If Val(Reader("RequestStatusID").ToString) < 3 Then
                        If DateDiff(DateInterval.Day, CDate(Reader("RequestDate").ToString), Now) > 3 Then
                            .ForeColor = Color.Red
                            .SubItems(1).Text = .SubItems(1).Text & " " & DateDiff(DateInterval.Day, CDate(Reader("RequestDate").ToString), Now)
                        End If
                    End If
                End With
            Loop

        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Private Sub cboInsuranceCompanyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInsuranceCompanyID.SelectedIndexChanged
        If cboInsuranceCompanyID.SelectedIndex > -1 Then
            If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value = -1 Then
                cboInsuranceCompanyID.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub CheckWarnings()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        Dim SI As ListViewItem.ListViewSubItem
        ListViewAttention.SuspendLayout()
        ListViewAttention.ListViewItemSorter = Nothing
        ListViewAttention.Items.Clear()
        If RadioButtonF1.Checked Or RadioButtonF2.Checked Then
            SQL = "SELECT  Bills.ServiceFrom , Bills.ServiceTo,   Bills.BillID, Bills.PatientID, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS PName, Attorneys.CompanyName, Bills.AttorneyDate "
            SQL &= "FROM  Bills INNER JOIN Patients ON Bills.PatientID = Patients.PatientID INNER JOIN Attorneys ON Bills.AttorneyCompanyID = Attorneys.CompanyID "
            SQL &= " WHERE DATEDIFF(d, Bills.AttorneyDate, getdate())>=" & gAttorneyNoConfirmationAge & " "
            SQL &= " AND (AttorneyCompanyID IS NOT NULL and AttorneyCompanyID<>0 and Bills.AttorneyCaseNumber IS NULL)"
            SQL &= " AND  Patients.OfficeID = " & gOfficeID & " "
            SQL &= " AND  Patients.CaseStatusID <> 3 and CaseStatusID<>5 "
            SQL &= " AND (Bills.BillStatusID=4 or Bills.BillStatusID=5) "
            Reader = gSQLGetDataReader(SQL)
            If Reader.HasRows Then
                Do Until Reader.Read = False
                    Dim AttorneyDateString As String
                    LI = ListViewAttention.Items.Add("No Confirmation")
                    With LI
                        .UseItemStyleForSubItems = False
                        .SubItems.Add(Reader("BillID").ToString)
                        If IsDate(Reader("AttorneyDate")) Then
                            AttorneyDateString = CDate(Reader("AttorneyDate")).ToString("MM/dd/yy")
                            SI = .SubItems.Add(DateDiff(DateInterval.Day, CDate(Reader("AttorneyDate").ToString), Now.Date))
                        Else
                            SI = .SubItems.Add("0")
                        End If
                        SI.ForeColor = Color.Red
                        .SubItems.Add(Reader("PName").ToString)
                        If IsDate(Reader("ServiceFrom").ToString) And IsDate(Reader("ServiceTo")) Then
                            .SubItems.Add(CDate(Reader("ServiceFrom")).ToString("MM/dd/yy") & " - " & CDate(Reader("ServiceTo")).ToString("MM/dd/yy"))
                        Else
                            .SubItems.Add("")
                        End If
                        SI = .SubItems.Add("Bill Submitted to the " & Reader("CompanyName").ToString & " on " & AttorneyDateString & " - more then " & gAttorneyNoConfirmationAge & " days ago.")
                        .Tag = Reader("BillID").ToString
                        .SubItems(1).Tag = Reader("PatientID").ToString
                        If IsDate(Reader("ServiceFrom")) Then
                            If DateDiff(DateInterval.Day, CDate(Reader("ServiceFrom")), Now) > 35 Then
                                gSetListItemForeColor(LI, Color.Red)
                                .ImageIndex = 3
                                SI.Text = SI.Text & " Oldest service is " & DateDiff(DateInterval.Day, CDate(Reader("ServiceFrom")), Now) & " days old!"
                            Else
                                .ImageIndex = 2
                            End If
                        Else
                            .ImageIndex = 2
                        End If
                    End With
                Loop
            End If
        End If
        If RadioButtonF1.Checked Or RadioButtonF3.Checked Then
            SQL = "SELECT     Bills.ServiceFrom, Bills.ServiceTo, Bills.BillID, Bills.PatientID, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS PName, Bills.BillStatusID, BillDate, DATEDIFF(d, Bills.BillDate, GETDATE()) as Age "
            SQL &= " FROM         Bills INNER JOIN  Patients ON Bills.PatientID = Patients.PatientID "
            SQL &= " WHERE     Bills.BillStatusID = 1 "
            SQL &= " AND  Patients.OfficeID = " & gOfficeID & " "
            SQL &= " AND  Patients.CaseStatusID <> 3 and CaseStatusID<>5 "
            SQL &= " AND Bills.BillStatusID<>6 AND Bills.BillStatusID<>7 and Bills.BillStatusID<>8 and Bills.BillStatusID<>13 "

            Reader = gSQLGetDataReader(SQL)
            If Reader.HasRows Then

                Do Until Reader.Read = False
                    LI = ListViewAttention.Items.Add("Bill Not Processed")
                    With LI
                        .UseItemStyleForSubItems = False
                        .SubItems.Add(Reader("BillID").ToString)
                        SI = .SubItems.Add(Reader("Age").ToString)
                        SI.ForeColor = Color.Red
                        .SubItems.Add(Reader("PName").ToString)
                        If IsDate(Reader("ServiceFrom").ToString) And IsDate(Reader("ServiceTo")) Then
                            .SubItems.Add(CDate(Reader("ServiceFrom")).ToString("MM/dd/yy") & " - " & CDate(Reader("ServiceTo")).ToString("MM/dd/yy"))
                        Else
                            .SubItems.Add("")
                        End If
                        If IsDate(Reader("BillDate")) Then
                            .SubItems.Add("Bill has been created on " & CDate(Reader("BillDate")).ToString("MM/dd/yy") & " and not been processed.")
                        Else
                            .SubItems.Add("Bill has been created and not been processed.")
                        End If
                        .Tag = Reader("BillID").ToString
                        .SubItems(1).Tag = Reader("PatientID").ToString
                        If IsDate(Reader("BillDate")) Then
                            If DateDiff(DateInterval.Day, CDate(Reader("BillDate")), Now) > 1 Then
                                .ImageIndex = 3
                            Else
                                .ImageIndex = 0
                            End If
                        Else
                            .ImageIndex = 0
                        End If
                    End With
                Loop

            End If
        End If
        If RadioButtonF1.Checked Or RadioButtonF4.Checked Then
            SQL = "SELECT     Bills.ServiceFrom, Bills.ServiceTo, Bills.BillID, Bills.PatientID, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS PName, BillingRequests.RequestDate,  BillingRequestStatuses.Description AS Status, BillingRequestStatuses.StatusID, BillingRequests.RequestDescription, DATEDIFF(d, BillingRequests.RequestDate, GETDATE()) as Age "
            SQL &= " FROM         BillingRequests INNER JOIN BillingRequestStatuses ON BillingRequests.RequestStatusID = BillingRequestStatuses.StatusID LEFT OUTER JOIN Bills ON BillingRequests.BillID = Bills.BillID LEFT OUTER JOIN Patients ON BillingRequests.PatientID = Patients.PatientID "
            SQL &= " WHERE  BillingRequestStatuses.StatusID < 3 and   DATEDIFF(d, BillingRequests.RequestDate, GETDATE()) >= " & gBillingRequestWarningAge & " "
            SQL &= " AND  Patients.OfficeID = " & gOfficeID & " "
            SQL &= " AND  Patients.CaseStatusID <> 3 and CaseStatusID<>5 "
            SQL &= " AND Bills.BillStatusID<>8 "
            SQL &= " AND Bills.BillStatusID<>13 "
            SQL &= " ORDER BY BillingRequests.RequestDate"
            Reader = gSQLGetDataReader(SQL)
            If Reader.HasRows Then
                Do Until Reader.Read = False

                    LI = ListViewAttention.Items.Add("Incomplete Request")
                    With LI
                        .UseItemStyleForSubItems = False
                        .SubItems.Add(Reader("BillID").ToString)
                        SI = .SubItems.Add(Reader("Age").ToString)
                        SI.ForeColor = Color.Red
                        .SubItems.Add(Reader("PName").ToString)
                        If IsDate(Reader("ServiceFrom").ToString) And IsDate(Reader("ServiceTo")) Then
                            .SubItems.Add(CDate(Reader("ServiceFrom")).ToString("MM/dd/yy") & " - " & CDate(Reader("ServiceTo")).ToString("MM/dd/yy"))
                        Else
                            .SubItems.Add("")
                        End If
                        If IsDate(Reader("RequestDate")) Then
                            .SubItems.Add("Request Date " & CDate(Reader("RequestDate")).ToString("MM/dd/yy") & ". Status: " & Reader("Status").ToString & ". Request:" & Reader("RequestDescription").ToString)
                        Else
                            .SubItems.Add("Request Status: " & Reader("Status").ToString & ". Request:" & Reader("RequestDescription").ToString)
                        End If

                        .ToolTipText = Reader("RequestDescription").ToString
                        .SubItems(1).Tag = Reader("PatientID").ToString
                        .Tag = Reader("BillID").ToString
                        .ImageIndex = 2
                    End With
                Loop
            End If

        End If
        ListViewAttention.ResumeLayout()
        Select Case ListViewAttention.Items.Count
            Case 0
                LabelAttentionsCount.Text = "No Warnings Found."
            Case Else
                LabelAttentionsCount.Text = "Warnings Found: " & ListViewAttention.Items.Count
        End Select

        If ListViewAttention.Items.Count > 0 Then
            'Beep()
            LockWindowUpdate(Me.Handle)
            My.Computer.Audio.Play(My.Resources.Notify, AudioPlayMode.Background)
            SplitContainer1.SplitterDistance = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SplitterDistance", SplitContainer1.SplitterDistance)
            SplitContainer1.Panel1Collapsed = False
            SplitContainer1.SplitterDistance = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SplitterDistance", SplitContainer1.SplitterDistance)
            ToolStripButton2.Enabled = False
            LockWindowUpdate(0)
        End If

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxClose.Click
        SaveSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SplitterDistance", SplitContainer1.SplitterDistance)
        SplitContainer1.Panel1Collapsed = True
        ListViewAttention.Items.Clear()
        ToolStripButton2.Enabled = True
        LastSelected = ListViewPatients
        ListViewPatients.Focus()
    End Sub

    Private Sub TimerCheckWarnings_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCheckWarnings.Tick
        TimerCheckWarnings.Enabled = False
        If gCurrentEmployee.PositionID < 3 Then
            CheckWarnings()
        End If
    End Sub

    Private Sub ListViewAttention_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewAttention.DoubleClick
        If ListViewAttention.SelectedItems.Count = 0 Then Exit Sub
        SearchBillID = Val(ListViewAttention.SelectedItems(0).Tag).ToString
        ButtonFind_Click(Nothing, Nothing)
        SearchBillID = ""
    End Sub

    Private Sub ToolStripButton1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        ToolStripMenuItemRequest_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        mnuSelectedBillPayment1_Click(Nothing, Nothing)
    End Sub

    Private Sub RadioButtonF1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonF1.CheckedChanged
        If Me.CanFocus = False Then Exit Sub
        If RadioButtonF1.Checked Then CheckWarnings()
    End Sub

    Private Sub RadioButtonF2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonF2.CheckedChanged
        If RadioButtonF2.Checked Then CheckWarnings()
    End Sub

    Private Sub RadioButtonF3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonF3.CheckedChanged
        If RadioButtonF3.Checked Then CheckWarnings()
    End Sub

    Private Sub RadioButtonF4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonF4.CheckedChanged
        If RadioButtonF4.Checked Then CheckWarnings()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Application.DoEvents()

        If SplitContainer1.Panel1Collapsed = True Then
            RadioButtonF1.Checked = True
            CheckWarnings()
            SplitContainer1.SplitterDistance = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SplitterDistance", 250)
            SplitContainer1.Panel1Collapsed = False
        End If
        ToolStripButton2.Enabled = False
    End Sub

    Private Sub ListViewAttention_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewAttention.GotFocus
        LastSelected = ListViewAttention
    End Sub

    Private Sub ListViewAttention_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FindCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindCheckToolStripMenuItem.Click
        Application.DoEvents()
        frmFindCheck.CalledForm = Me
        frmFindCheck.MinimizeBox = False
        frmFindCheck.MaximizeBox = False

        frmFindCheck.ShowDialog(Me)
        frmFindCheck.Dispose()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click, ToolStripMenuItemTodayPayments.Click
        frmBillingTodayPayments.ShowDialog()
        frmBillingTodayPayments.Dispose()
    End Sub

    Private Sub ToolStripMenuItemWShiwPatientInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemWShiwPatientInformation.Click
        Dim LI As ListViewItem
        If ListViewAttention.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No Record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewAttention.SelectedItems(0)

        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.InitialPatientName = LI.SubItems(1).Tag
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.ShowDialog(Me)
        End Using
        'Dim frm As Form = FormsCollection.FindForm("frmPatient")
        'If Not frm Is Nothing Then
        '    Dim NewFrm As New frmPatient
        '    NewFrm.InitialTab = 0
        '    NewFrm.InitialPatientName = LI.SubItems(1).Tag
        '    NewFrm.ShowDialog(Me)

        '    'MsgBox("The Patient's information window is already opened." & vbCrLf & vbCrLf & "Please close the previous patient information window before opening a new one.", MsgBoxStyle.Exclamation)
        '    'frm.WindowState = FormWindowState.Normal
        '    'frm.BringToFront()
        '    'Exit Sub
        'Else
        '    frmPatient.InitialTab = 0
        '    frmPatient.InitialPatientName = LI.SubItems(1).Tag
        '    frmPatient.ShowDialog(Me)
        'End If
    End Sub

    Private Sub ToolStripMenuItemWBillingRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemWBillingRequest.Click
        Dim LI As ListViewItem
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        If ListViewAttention.SelectedItems.Count = 0 Then
            MsgBox("Unable to create Billing request. No Record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewAttention.SelectedItems(0)
        SQL = "SELECT     Bills.BillID, Patients.FName + ' ' + Patients.LName AS PName, Attorneys.CompanyName AS Attorney, InsuranceCompanies.CompanyName AS Insurance "
        SQL &= " FROM         Bills LEFT OUTER JOIN Attorneys ON Bills.AttorneyCompanyID = Attorneys.CompanyID LEFT OUTER JOIN Patients ON Bills.PatientID = Patients.PatientID LEFT OUTER JOIN InsuranceCompanies ON Bills.InsCompanyID = InsuranceCompanies.CompanyID "
        SQL &= " WHERE Bills.BillID = " & LI.Tag
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Reader.Read()
            frmBillingAddRequest.lblMsg.Text = "Patient: " & Reader("Pname").ToString & "   Bill #: " & Reader("BillID").ToString
            frmBillingAddRequest.BillAttorney = Reader("Attorney").ToString
            frmBillingAddRequest.BillInsurance = Reader("Insurance").ToString
            frmBillingAddRequest.BillID = Val(LI.Tag)
            frmBillingAddRequest.PatientID = Val(LI.SubItems(1).Tag)
            frmBillingAddRequest.MinimizeBox = False
            frmBillingAddRequest.MaximizeBox = False

            frmBillingAddRequest.ShowDialog(Me)
            frmBillingAddRequest.Dispose()
            If ListViewPatients.SelectedItems.Count > 0 Then
                If Val(LI.Tag) = Val(ListViewPatients.SelectedItems(0).SubItems(4).Text) Then
                    Load_Requests(CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value)
                    MDIForm1Win8.TimerRefresh_Tick(Nothing, Nothing)
                End If
            End If

        End If
    End Sub

    Private Sub ToolStripMenuItemShowPatientBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemShowPatientBill.Click
        If ListViewAttention.SelectedItems.Count = 0 Then Exit Sub
        SearchBillID = Val(ListViewAttention.SelectedItems(0).Tag).ToString
        ButtonFind_Click(Nothing, Nothing)
        SearchBillID = ""
    End Sub

    Private Sub mnuPOM2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPOM2.Click

    End Sub

    Private Sub mnuPOM2_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPOM2.DropDownOpened
        Setup_Menus(Nothing)
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Application.DoEvents()
        frmFindCheck.CalledForm = Me
        frmFindCheck.MinimizeBox = False
        frmFindCheck.MaximizeBox = False

        frmFindCheck.ShowDialog(Me)
        frmFindCheck.Dispose()
    End Sub

    Private Sub txtPatient_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPatient.KeyDown
        If e.KeyCode = Keys.Enter Then
            ButtonFind_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtPatient_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPatient.KeyPress

    End Sub

    Private Sub txtPatient_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPatient.TextChanged

    End Sub

    Private Sub cboBillingCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillingCompany.SelectedIndexChanged

    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripAutoResize.Click
        gListViewRestoreDefaultColumnWidth(ListViewPatients)
        gListViewRestoreDefaultColumnWidth(ListViewAttention)
        gListViewRestoreDefaultColumnWidth(ListViewBillToPatient)
        gListViewRestoreDefaultColumnWidth(ListViewDenials)
    End Sub

    Private Sub ChangeBillDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeBillDateToolStripMenuItem.Click
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to change bill date. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        With frmBillingChangeBillDate
            .BillID = Val(LI.SubItems(4).Text)
            .CalledBillDateSI = LI.SubItems(5)
            .LabelCurrentDate.Text = LI.SubItems(5).Text
            .LabelPatientName.Text = LI.SubItems(1).Text
            .LabelBillNumber.Text = LI.SubItems(4).Text
            .PatientID = Val(LI.Text)
            .DateTimePicker1.Value = CDate(LI.SubItems(5).Text)
            .MinimizeBox = False
            .MaximizeBox = False
            .ShowDialog(Me)
            .Dispose()
        End With
    End Sub

    Private Sub ChangeBillAmountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeBillAmountToolStripMenuItem.Click
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to change bill amount. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        Using frm As New frmBillingChangeBillAmount
            If SaveSuppervisorApprovalBorBillAmountChange Then
                frm.PanelSuppervisorApproval.Visible = False
                frm.Height = 408
            End If
            frm.BillID = Val(LI.SubItems(4).Text)
            frm.CaseTypeID = gSQLGetSingleValue($"select CaseTypeID from Patients where PatientID = {Val(LI.Text)}")
            If frm.CaseTypeID > 3 Then frm.CaseTypeID = 1
            frm.CalledBillAmountSI = LI.SubItems(8)
            frm.CalledBillBalanceSI = LI.SubItems(16)
            frm.PaidAmount = Val(LI.SubItems(15).Text)
            frm.LabelPatientName.Text = LI.SubItems(1).Text
            frm.LabelBillNumber.Text = LI.SubItems(4).Text
            frm.txtNewAmount.Text = CDbl(LI.SubItems(8).Text)
            frm.CaseTypeName = LI.SubItems(3).Text
            frm.lblCaseType.Text = LI.SubItems(3).Text.ToUpper
            frm.LabelCurrentAmount.Text = Val(LI.SubItems(8).Text).ToString("C2")
            frm.lblPaidAmount.Text = Val(LI.SubItems(15).Text).ToString("C2")
            frm.lblBallance.Text = Val(LI.SubItems(16).Text).ToString("C2")
            frm.PatientID = Val(LI.Text)
            frm.LoadProcedures()
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
        Count_Selected()
    End Sub

    Private Sub ChangePaymentAmountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePaymentAmountToolStripMenuItem.Click
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to change bill amount. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)

        frmBillingChangePaymentInformation.BillID = Val(LI.SubItems(4).Text)
        frmBillingChangePaymentInformation.CalledBillPaidSI = LI.SubItems(15)
        frmBillingChangePaymentInformation.CalledBillBalanceSI = LI.SubItems(16)
        frmBillingChangePaymentInformation.BillAmount = Val(LI.SubItems(8).Text)
        frmBillingChangePaymentInformation.LabelPatientName.Text = LI.SubItems(1).Text
        frmBillingChangePaymentInformation.LabelBillNumber.Text = LI.SubItems(4).Text
        frmBillingChangePaymentInformation.LabelBillDate.Text = LI.SubItems(5).Text
        frmBillingChangePaymentInformation.Load_Payments(Val(LI.SubItems(4).Text))
        frmBillingChangePaymentInformation.PatientID = Val(LI.Text)
        frmBillingChangePaymentInformation.MinimizeBox = False
        frmBillingChangePaymentInformation.MaximizeBox = False

        frmBillingChangePaymentInformation.ShowDialog(Me)
        frmBillingChangePaymentInformation.Dispose()
        Count_Selected()
    End Sub

    Private Sub TableLayoutPanel1_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles TableLayoutPanel1.Layout
        'TableLayoutPanel1.Refresh()
        cboInsuranceCompanyID.Refresh()
        cboBillingProvider.Refresh()
        Application.DoEvents()
    End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub ClearAttorneyCaseNumberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearAttorneyCaseNumberToolStripMenuItem.Click
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        If ListViewPatients.SelectedItems(0).SubItems(19).Text = "" Then
            MsgBox("Unable to process your request. No Attorney case number is assigned to this bill.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim ApprovedByName As String
        Dim LI As ListViewItem = ListViewPatients.SelectedItems(0)
        Dim PatientID As Long = CType(LI.Tag, ValueDescription).Value1

        If gCurrentEmployee.PositionID > 3 Then
            frmSupervisorApproval.LabelMsg.Text = "Remove Attorney Case number From Bill#: " & Val(LI.SubItems(4).Text) & ", Patient: " & LI.SubItems(1).Text & vbCrLf & "Assigned Attorney Case # " & ListViewPatients.SelectedItems(0).SubItems(19).Text
            If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frmSupervisorApproval.Dispose()
                Exit Sub
            End If
            ApprovedByName = frmSupervisorApproval.SupervisorName
            frmSupervisorApproval.Dispose()
        Else
            If MsgBox("Please confirm you want to remove the Attorney Case # " & LI.SubItems(19).Text & " from the" & vbCrLf & "Bill#: " & Val(LI.SubItems(4).Text) & ", Patient: " & LI.SubItems(1).Text & "?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                Exit Sub
            End If
            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tAttorneyRemoved, "Attorney Case number " & LI.SubItems(19).Text & " removed", ApprovedByName)

        gSQLUpdateData("Update Bills set AttorneyCaseNumber = Null, AttorneyCaseNumberDate=Null where BillID = " & Val(ListViewPatients.SelectedItems(0).SubItems(4).Text))
        LI.SubItems(19).Text = ""
        LI.SubItems(26).Text = ""
        LI.SubItems(19).BackColor = Color.PeachPuff
        LI.SubItems(26).BackColor = Color.PeachPuff

    End Sub

    Private Sub ClearAttorneyCaseNumberToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearAttorneyCaseNumberToolStripMenuItem1.Click
        ClearAttorneyCaseNumberToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        Dim LI As ListViewItem = ListViewPatients.SelectedItems(0)
        If LI.SubItems(12).Text = "" Then
            MsgBox("Unable to process your request. No Attorney assigned to the current bill.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If LI.SubItems(19).Text <> "" Then
            MsgBox("Unable to process your request. The Attorney case number is already assigned to this bill.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        frmAttorneyAssignCaseNumber.initLI = LI
        frmAttorneyAssignCaseNumber.ShowDialog()
        frmAttorneyAssignCaseNumber.Dispose()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        ToolStripMenuItem5_Click(Nothing, Nothing)
    End Sub

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved

    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Dim C As Color
        If ListViewComments.SelectedItems.Count = 0 Then Exit Sub
        If txtComments.Text.Trim = "" Then Exit Sub
        frmBillCommentsShow.BillNumber = Val(ListViewPatients.SelectedItems(0).SubItems(4).Text)
        frmBillCommentsShow.PatientName = ListViewPatients.SelectedItems(0).Text & "  " & ListViewPatients.SelectedItems(0).SubItems(1).Text
        frmBillCommentsShow.lblInfo.Text = "Bill #: " & ListViewPatients.SelectedItems(0).SubItems(4).Text & "    Patient: " & ListViewPatients.SelectedItems(0).Text & "  " & ListViewPatients.SelectedItems(0).SubItems(1).Text
        frmBillCommentsShow.TextBox1.Text = txtComments.Text
        If IsDate(ListViewComments.SelectedItems(0).SubItems(2).Text) Then
            C = ListViewComments.SelectedItems(0).SubItems(2).BackColor
            Select Case C
                Case Color.LightSalmon
                    frmBillCommentsShow.Label1.Text = "PAST INCOMPLETE FOLLOW UP REMINDER: " & ListViewComments.SelectedItems(0).SubItems(2).Text
                    frmBillCommentsShow.Label1.ForeColor = Color.Red
                Case Color.Gold
                    frmBillCommentsShow.Label1.Text = "FUTURE FOLLOW UP REMINDER: " & ListViewComments.SelectedItems(0).SubItems(2).Text
                    frmBillCommentsShow.Label1.ForeColor = Color.DarkOrange
                Case Color.LightSeaGreen
                    frmBillCommentsShow.Label1.Text = "COMPLETE FOLLOW UP REMINDER: " & ListViewComments.SelectedItems(0).SubItems(2).Text
                    frmBillCommentsShow.Label1.ForeColor = Color.DarkOrange
            End Select
        End If

        frmBillCommentsShow.MinimizeBox = False
        frmBillCommentsShow.MaximizeBox = False

        frmBillCommentsShow.ShowDialog(Me)
        frmBillCommentsShow.Dispose()
    End Sub

    Private Sub txtPatientComments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPatientComments.DoubleClick
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        If txtPatientComments.Text.Trim = "" Then Exit Sub
        frmBillCommentsShow.Label1.Text = "PATIENT COMMENTS"
        frmBillCommentsShow.BillNumber = Val(ListViewPatients.SelectedItems(0).SubItems(4).Text)
        frmBillCommentsShow.PatientName = ListViewPatients.SelectedItems(0).Text & "  " & ListViewPatients.SelectedItems(0).SubItems(1).Text
        frmBillCommentsShow.lblInfo.Text = "Patient: " & ListViewPatients.SelectedItems(0).Text & "  " & ListViewPatients.SelectedItems(0).SubItems(1).Text
        frmBillCommentsShow.TextBox1.Text = txtPatientComments.Text
        frmBillCommentsShow.MinimizeBox = False
        frmBillCommentsShow.MaximizeBox = False

        frmBillCommentsShow.ShowDialog(Me)
        frmBillCommentsShow.Dispose()
    End Sub

    Private Sub txtPatientComments_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPatientComments.TextChanged

    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        txtPatientComments_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Dim BillID As Long
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""
        Dim LI As ListViewItem
        Dim SelectedLI As ListViewItem
        Dim PaidAmount As Double
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to process. No bills selected.", MsgBoxStyle.Exclamation)
            ListViewPatients.Focus()
            Exit Sub
        End If

        SelectedLI = ListViewPatients.SelectedItems(0)
        If CDbl(SelectedLI.SubItems(15).Text) = 0 Then
            MsgBox("Unable to remove bill payment." & vbCrLf & "The selected bill has no payment(s).", MsgBoxStyle.Exclamation)
            ListViewPatients.Focus()
            Exit Sub
        End If
        Dim PatID As Long
        BillID = CType(SelectedLI.Tag, ValueDescription).Value
        PatID = Val(SelectedLI.Text)
        With frmDeleteBillPayment
            .lblBillNumber.Text = BillID
            .BillID = BillID
            .lblPatient.Text = SelectedLI.SubItems(1).Text

            SQL = "SELECT   PatientID,  isnull(BillAmount,0) as BillAmount, isnull(PaidAmount,0) as PaidAmount FROM         Bills Where BillID=" & BillID
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then
                MsgBox("Unexpected Error. Please call your system administrator.")
                Exit Sub
            End If
            If Reader.HasRows Then
                Reader.Read()
                .PatientID = Reader("PatientID").ToString
                PatID = Reader("PatientID").ToString
                .lblPaid.Text = CDbl(Reader("PaidAmount").ToString).ToString("c")
                .lblBillAmount.Text = CDbl(Reader("BillAmount")).ToString("c")
                .lblRemaining.Text = CDbl(Reader("BillAmount") - Reader("PaidAmount")).ToString("c")
                .lblRemaining.Tag = CDbl(Reader("BillAmount") - Reader("PaidAmount")).ToString("c")
                '.txtAmount.Text = .txtRemaining.Text
            End If
            Reader.Close() : Reader.Dispose()

            SQL = "SELECT  BillPayments.PaymentID,   BillPayments.PaymentDate, BillPaymentTypes.Description, BillPayments.PaymentAmount, BillPayments.CheckNumber, BillPaymentNotes.Description AS Notes"
            SQL &= " FROM         BillPayments LEFT OUTER JOIN BillPaymentNotes ON BillPayments.NoteID = BillPaymentNotes.NoteID LEFT OUTER JOIN BillPaymentTypes ON BillPayments.PaymentTypeID = BillPaymentTypes.PaymentTypeID "
            SQL &= " WHERE BillPayments.BillID = " & BillID
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then
                MsgBox("Unexpected Error. Please call your system administrator.")
                Exit Sub
            End If
            .ListView1.Items.Clear()
            Do Until Reader.Read = False
                With .ListView1.Items
                    If IsDate(Reader("PaymentDate").ToString) Then
                        LI = .Add(CDate(Reader("PaymentDate")).ToString("MM/dd/yyyy"))
                    Else
                        LI = .Add("")
                    End If
                    LI.Tag = Val(Reader("PaymentID").ToString)
                    LI.SubItems.Add(Reader("Description").ToString)
                    LI.SubItems.Add(CDbl(Reader("PaymentAmount").ToString).ToString("c"))
                    LI.SubItems.Add(Reader("CheckNumber").ToString)
                    LI.SubItems.Add(Reader("Notes").ToString)
                End With
            Loop

            Dim BillAmount As Double
            frmDeleteBillPayment.MinimizeBox = False
            frmDeleteBillPayment.MaximizeBox = False

            If frmDeleteBillPayment.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                PaidAmount = gSQLGetSingleValue("SELECT PaidAmount From Bills Where BillID=" & BillID)
                BillAmount = gSQLGetSingleValue("SELECT BillAmount From Bills Where BillID=" & BillID)
                Load_Payments(BillID)
                Load_Comments(BillID)

                If CDbl(PaidAmount) = 0 Then
                    SelectedLI.SubItems(9).Text = "Attorney L"
                    SelectedLI.SubItems(9).BackColor = Color.DarkOrange
                    SelectedLI.SubItems(9).Tag = 4
                End If
                SelectedLI.SubItems(15).Text = PaidAmount.ToString("c")
                SelectedLI.SubItems(16).Text = (BillAmount - PaidAmount).ToString("c")
            End If
            frmDeleteBillPayment.Dispose()
        End With
        Count_Selected()
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim LI As ListViewItem
        Dim BillProcessed As Boolean = False
        Dim ApprovedByName As String = ""
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to process. No bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        If LI Is Nothing Then Exit Sub
        Dim BillID As Long = CType(LI.Tag, ValueDescription).Value
        Dim PatientID As Long = CType(LI.Tag, ValueDescription).Value1
        Dim PatientName As String = LI.SubItems(1).Text

        If gSQLGetSingleValue("SELECT    count(*) FROM Bills WHERE Bills.BillStatusID=1 and  Bills.BillID = " & BillID) = 0 Then
            BillProcessed = True
            'MsgBox("Unable to delete the selected bill. This bill has already been processed. " & vbCrLf & vbCrLf & "Only unprocessed bills can be deleted.", MsgBoxStyle.Exclamation)
        End If

        If gCurrentEmployee.PositionID > 3 Then
            frmSupervisorApproval.LabelMsg.Text = "Request to delete the Bill: " & BillID
            If BillProcessed Then
                frmSupervisorApproval.LabelMsg.Text = "Attention! Bill has  been processed!"
            End If
            If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frmSupervisorApproval.Dispose()
                Exit Sub
            End If
            ApprovedByID = frmSupervisorApproval.SupervisorID
            ApprovedByName = frmSupervisorApproval.SupervisorName
            frmSupervisorApproval.Dispose()
        Else
            If MsgBox("Attention! This process can not be undone!" & vbCrLf & vbCrLf & "You have requested to delete the Bill: " & BillID & IIf(BillProcessed, vbCrLf & vbCrLf & "Attention! This Bill has been processed!", vbCrLf & vbCrLf & "Please make sure this bill has not been mailed to the insurance company!") & vbCrLf & "Do you want to continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tBillDeleted, "Bill #: " & BillID & " has been deleted.", ApprovedByName)

        Try
            gSQLDeleteRecord("Delete From Bills Where BillID = " & BillID)
            gSQLDeleteRecord("Delete From BillDiagnosis Where BillID = " & BillID)
            gSQLDeleteRecord("Delete From BillProcedures Where BillID = " & BillID)
            gSQLDeleteRecord("Delete From BillComments Where BillID = " & BillID)
            gSQLDeleteRecord("DELETE FROM BillPayments WHERE BillID =" & BillID)
            ListViewPatients.Items.Remove(LI)
            ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
            Count_Selected()
        Catch ex As Exception

            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Count_Selected()
    End Sub

    Private Sub mnuReProduceSelectedBill1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReProduceSelectedBill1.Click
        ReProduce_Bill()
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        Dim LI As ListViewItem = ListViewPatients.SelectedItems(0)
        If LI.SubItems(27).Text = "" Then
            MsgBox("Unable to process your request. No Arbitration/Litigation Attorney assigned to the current bill.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If LI.SubItems(29).Text <> "" Then
            MsgBox("Unable to process your request. The Arbitration/Litigation Attorney case number is already assigned to this bill.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        frmAttorneyAssignCaseNumber.Panel1.BackColor = Color.MistyRose
        frmAttorneyAssignCaseNumber.Text = "Assign Arbitration / Litigation Attorney Case Number"
        frmAttorneyAssignCaseNumber.lblMsg.Text = "Assign Arbitration / Litigation Attorney Case Number"
        frmAttorneyAssignCaseNumber.Arbitration = True
        frmAttorneyAssignCaseNumber.ArbitrationFieldPrefix = "Arbitration"
        frmAttorneyAssignCaseNumber.initLI = LI
        frmAttorneyAssignCaseNumber.ShowDialog()
        frmAttorneyAssignCaseNumber.Dispose()
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        If ListViewPatients.SelectedItems(0).SubItems(29).Text = "" Then
            MsgBox("Unable to process your request. No Arbitration / Litigation Attorney case number is assigned to this bill.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim ApprovedByName As String
        Dim LI As ListViewItem = ListViewPatients.SelectedItems(0)
        Dim PatientID As Long = CType(LI.Tag, ValueDescription).Value1

        If gCurrentEmployee.PositionID > 3 Then
            frmSupervisorApproval.LabelMsg.Text = "Remove Attorney Case number From Bill#: " & Val(LI.SubItems(4).Text) & ", Patient: " & LI.SubItems(1).Text & vbCrLf & "Assigned Attorney Case # " & ListViewPatients.SelectedItems(0).SubItems(29).Text
            If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frmSupervisorApproval.Dispose()
                Exit Sub
            End If
            ApprovedByName = frmSupervisorApproval.SupervisorName
            frmSupervisorApproval.Dispose()
        Else
            If MsgBox("Please confirm you want to remove the Arbitration / Litigation Attorney Case # " & LI.SubItems(29).Text & " from the" & vbCrLf & "Bill#: " & Val(LI.SubItems(4).Text) & ", Patient: " & LI.SubItems(1).Text & "?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                Exit Sub
            End If
            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tAttorneyRemoved, "Arbitration / Litigation Attorney Case number " & LI.SubItems(29).Text & " removed", ApprovedByName)

        gSQLUpdateData("Update Bills set ArbitrationAttorneyCaseNumber = Null, ArbitrationAttorneyCaseNumberDate=Null where BillID = " & Val(ListViewPatients.SelectedItems(0).SubItems(4).Text))
        LI.SubItems(29).Text = ""
        LI.SubItems(30).Text = ""
        LI.SubItems(29).BackColor = Color.PeachPuff
        LI.SubItems(30).BackColor = Color.PeachPuff
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ToolStripMenuItem10_Click(Nothing, Nothing)
    End Sub

    Private Sub ChangeBillStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeBillStatusToolStripMenuItem.Click
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to change bill status. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        With frmBillingChangeBillStatus
            .BillID = Val(LI.SubItems(4).Text)
            .CalledBillStatusSI = LI.SubItems(9)
            .CalledBillStatusAttorneySI = LI.SubItems(12)
            .CalledBillStatusDateSI = LI.SubItems(13)

            .LabelCurrentDate.Text = LI.SubItems(5).Text
            .LabelPatientName.Text = LI.SubItems(1).Text
            .LabelBillNumber.Text = LI.SubItems(4).Text
            .PatientID = Val(LI.Text)
            .CurrentStatusID = Val(LI.SubItems(9).Tag)
            .LabelCurrentStatus.Text = LI.SubItems(9).Text
            .MinimizeBox = False
            .MaximizeBox = False
            .ShowDialog(Me)
            .Dispose()
        End With
        Count_Selected()
    End Sub

    Private Sub CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CourtIndexNumbersFilingDatesMaintenanceToolStripMenuItem.Click
        frmBillingIndexNumber.ShowDialog(Me)
        frmBillingIndexNumber.Dispose()
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        If ListViewPatients.SelectedItems.Count > 0 Then
            frmBillingIndexNumber.txtInvoice.Text = ListViewPatients.SelectedItems(0).SubItems(4).Text
        End If
        frmBillingIndexNumber.Button2.Visible = False
        If frmBillingIndexNumber.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Find_Patients()
        End If
        frmBillingIndexNumber.Dispose()
    End Sub

    Private Sub PaymentsProgressAnalysisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentsProgressAnalysisToolStripMenuItem.Click
        frmPaymentsChart.ShowDialog(Me)
        frmPaymentsChart.Dispose()
    End Sub

    Private Sub cboBillStatus_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillStatus.SelectedIndexChanged
        If CType(cboBillStatus.SelectedItem, ValueDescription).Value = "-99" Then
            cboBillStatus.SelectedIndex = 0
        End If
    End Sub

    Private Sub AttorneyFeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttorneyFeesToolStripMenuItem.Click
        If ListViewPatients.SelectedItems.Count > 0 Then
            frmAttorneyFees.txtInvoice.Text = ListViewPatients.SelectedItems(0).SubItems(4).Text
            If frmAttorneyFees.ListView1.Items.Count > 0 Then
                frmAttorneyFees.Load_BillFees(Val(ListViewPatients.SelectedItems(0).SubItems(4).Text))
                'frmAttorneyFees.ListView1.Items(0).Selected = True
                'frmAttorneyFees.ListView1.Items(0).EnsureVisible()
            End If

        End If
        If frmAttorneyFees.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Find_Patients()
        End If
        frmAttorneyFees.Dispose()
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        AttorneyFeesToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Public SelectedAttorneyIndex As Integer = -1

    Private Sub ExportAttorneyDocumentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportAttorneyDocumentsToolStripMenuItem.Click
        Dim LI As ListViewItem
        Dim C As Integer
        If ListViewPatients.SelectedItems.Count = 0 And ListViewPatients.CheckedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No Bill Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewPatients.CheckedItems.Count = 0 Then
            ListViewPatients.SelectedItems(0).Checked = True
        End If
        SelectedAttorneyIndex = -1
        For Each LI In ListViewPatients.CheckedItems
            'LI = ListViewPatients.SelectedItems(0)
            LI.Selected = True
            If LI.SubItems(25).Text = "YES" Then
                frmAttorneyDocumentsAccess.PanelNoMoreCollection.Visible = True
            End If
            Dim SkipAttorneyIndex As Boolean = Val(LI.SubItems(12).Tag) > 0
            frmAttorneyDocumentsAccess.AttorneyID = Val(LI.SubItems(12).Tag)
            frmAttorneyDocumentsAccess.BillStatusID = Val(LI.SubItems(9).Tag)
            frmAttorneyDocumentsAccess.AttorneyName = LI.SubItems(12).Text
            frmAttorneyDocumentsAccess.PatientID = Val(LI.Text)
            frmAttorneyDocumentsAccess.BillID = Val(LI.SubItems(4).Text)

            frmAttorneyDocumentsAccess.CalledLI = LI

            frmAttorneyDocumentsAccess.SaveCaseType = ListViewPatients.SelectedItems(0).SubItems(3).Tag
            frmAttorneyDocumentsAccess.lblPatient.Text = "BILL #: " & LI.SubItems(4).Text & "   " & "PATIENT: " & LI.SubItems(1).Text & "   " & "SERVICE DT: " & LI.SubItems(11).Text
            frmAttorneyDocumentsAccess.AttorneyIndex = SelectedAttorneyIndex
            C = C + 1
            If frmAttorneyDocumentsAccess.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
                If C < ListViewPatients.CheckedItems.Count Then
                    If MessageBox.Show("Would you like to stop process?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        frmAttorneyDocumentsAccess.Dispose()
                        Exit Sub
                    End If
                End If
            End If
            If SkipAttorneyIndex = False Then
                SelectedAttorneyIndex = frmAttorneyDocumentsAccess.cboAttorneysCompanyID.SelectedIndex
            End If
            frmAttorneyDocumentsAccess.Dispose()
        Next
    End Sub

    Private LastSelected As ListView

    Private Sub ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem15.Click
        If LastSelected Is Nothing Then
            MsgBox("Unable to process your request. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If LastSelected Is ListViewAttention Then
            ToolStripMenuItemWShiwPatientInformation_Click(Nothing, Nothing)
        Else
            mnuShowSelectedPatientInfo1_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub ToolStripMenuItem9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)

        If LI.SubItems(25).Text = "YES" Then
            frmBillingNoMoreCollectionChange.NoMoreCollection = 1
            frmBillingNoMoreCollectionChange.RadioButtonNoMoreCollection.Checked = True
        Else
            frmBillingNoMoreCollectionChange.NoMoreCollection = 0
            frmBillingNoMoreCollectionChange.RadioButtonContinueCollection.Checked = True
        End If
        frmBillingNoMoreCollectionChange.BillID = Val(LI.SubItems(4).Text)
        frmBillingNoMoreCollectionChange.CalledNoMoreCollection = LI.SubItems(25)
        frmBillingNoMoreCollectionChange.CalledBillStatusSI = LI.SubItems(9)
        frmBillingNoMoreCollectionChange.CalledNoMoreCollection = LI.SubItems(25)
        frmBillingNoMoreCollectionChange.LabelCurrentAmount.Text = LI.SubItems(8).Text
        frmBillingNoMoreCollectionChange.LabelPatientName.Text = LI.SubItems(1).Text
        frmBillingNoMoreCollectionChange.LabelBillNumber.Text = LI.SubItems(4).Text
        frmBillingNoMoreCollectionChange.PatientID = Val(LI.Text)
        frmBillingNoMoreCollectionChange.MinimizeBox = False
        frmBillingNoMoreCollectionChange.MaximizeBox = False

        frmBillingNoMoreCollectionChange.ShowDialog(Me)
        frmBillingNoMoreCollectionChange.Dispose()
        Count_Selected()
        Load_Comments(Val(LI.SubItems(4).Text))
    End Sub

    Private Sub ToolStripButtonCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCloseForm.Click
        Me.Close()
    End Sub

    Private Sub frmBillingManagement_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ToolStripButtonCloseForm.Visible = Me.WindowState = FormWindowState.Maximized
        'If Width > 600 Then
        '    Me.SplitContainer2.Panel1MinSize = 300
        '    Me.SplitContainer2.Panel2MinSize = 300
        'Else
        '    Me.SplitContainer2.Panel1MinSize = Width / 2
        '    Me.SplitContainer2.Panel2MinSize = Width / 2
        'End If

    End Sub

    Private Sub frmBillingManagement_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ToolStripButtonCloseForm.Visible = Me.WindowState = FormWindowState.Maximized
        ToolStripButtoneFile.Visible = gEnableElectronicBillFiling > 0
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        mnuBillDenied1_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        mnuSelectedBillPayment1_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStrip2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStrip2.DoubleClick
        Return
        gCustomizeToolStrip(ToolStrip2, Me)
        'Bill Lost
        ToolStripButton9.Visible = gCurrentEmployee.PositionID < 4
        ToolStripSeparator34.Visible = gCurrentEmployee.PositionID < 4
    End Sub

    Private Sub ToolStrip2_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub

    Private Sub CustomizeToolbarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomizeToolbarToolStripMenuItem.Click
        gCustomizeToolStrip(ToolStrip2, Me)
        gToolStripSettings(Me, ToolStrip2, ReadWrite.sWrite)
        'Bill Lost
        ToolStripButton9.Visible = gCurrentEmployee.PositionID < 4
        ToolStripSeparator34.Visible = gCurrentEmployee.PositionID < 4
    End Sub

    Private Sub TimerDetails_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerDetails.Tick
        TimerDetails.Enabled = False
        TreeViewBills.Nodes.Clear()
        ListViewComments.Items.Clear()
        ListViewPayments.Items.Clear()
        ListViewPatientComments.Items.Clear()
        txtPatientComments.Text = ""
        txtComments.Text = ""
        ListViewRequests.Items.Clear()
        ListViewBillToPatient.Items.Clear()
        ListViewDenials.Items.Clear()
        txtDenialComments.Text = ""
        RichTextBox1.Text = ""
        TextBoxCommentView.Text = ""
        TextBoxCommentViewBy.Text = ""
        RichTextBox1.Visible = False
        pdfViewer.CloseDocument()
        Application.DoEvents()

        If SplitContainer2.Panel2Collapsed = False Then
            If ListViewPatients.SelectedItems.Count = 0 Then
                TreeViewBills.Nodes.Clear()
                ListViewComments.Items.Clear()
                ListViewPayments.Items.Clear()
                ListViewPatientComments.Items.Clear()
                txtPatientComments.Text = ""
                txtComments.Text = ""
                ListViewRequests.Items.Clear()
                ListViewBillToPatient.Items.Clear()
                ListViewDenials.Items.Clear()
                txtDenialComments.Text = ""
                RichTextBox1.Text = ""
                TextBoxCommentView.Text = ""
                TextBoxCommentViewBy.Text = ""
                RichTextBox1.Visible = False
                pdfViewer.CloseDocument()
                Exit Sub
            End If
            'LockWindowUpdate(PanelBills.Handle)

            PanelBills.SuspendLayout()
            With ListViewPatients.SelectedItems(0)
                Dim bk1 = New BackgroundWorker() : AddHandler bk1.DoWork, AddressOf bw1_DoWork : bk1.RunWorkerAsync(CType(.Tag, ValueDescription).Value1)
                Dim bk2 = New BackgroundWorker() : AddHandler bk2.DoWork, AddressOf bw2_DoWork : bk2.RunWorkerAsync(CType(.Tag, ValueDescription).Value)
                Dim bk3 = New BackgroundWorker() : AddHandler bk3.DoWork, AddressOf bw3_DoWork : bk3.RunWorkerAsync(CType(.Tag, ValueDescription).Value)
                Dim bk4 = New BackgroundWorker() : AddHandler bk4.DoWork, AddressOf bw4_DoWork : bk4.RunWorkerAsync(CType(.Tag, ValueDescription).Value)
                Dim bk5 = New BackgroundWorker() : AddHandler bk5.DoWork, AddressOf bw5_DoWork : bk5.RunWorkerAsync(CType(.Tag, ValueDescription).Value1)
                Dim bk6 = New BackgroundWorker() : AddHandler bk6.DoWork, AddressOf bw6_DoWork : bk6.RunWorkerAsync(CType(.Tag, ValueDescription).Value1)
                Dim bk7 = New BackgroundWorker() : AddHandler bk7.DoWork, AddressOf bw7_DoWork : bk7.RunWorkerAsync(CType(.Tag, ValueDescription).Value)
                Dim bk8 = New BackgroundWorker() : AddHandler bk8.DoWork, AddressOf bw8_DoWork : bk8.RunWorkerAsync(CType(.Tag, ValueDescription).Value)
                Dim bk9 = New BackgroundWorker() : AddHandler bk9.DoWork, AddressOf bw9_DoWork : bk9.RunWorkerAsync(CType(.Tag, ValueDescription).Value1)

                'Load_Patient_Bills(CType(.Tag, ValueDescription).Value1)
                'Load_Comments(CType(.Tag, ValueDescription).Value)
                'Load_Payments(CType(.Tag, ValueDescription).Value)
                'Load_Requests(CType(.Tag, ValueDescription).Value)
                'Load_Patient_QNotes(CType(.Tag, ValueDescription).Value1)
                'Load_Patient_Comments(CType(.Tag, ValueDescription).Value1)
                'Load_BillToPatients(CType(.Tag, ValueDescription).Value)
                'Load_Denials(CType(.Tag, ValueDescription).Value)
                'Load_Documents(CType(.Tag, ValueDescription).Value1)
            End With
            'LockWindowUpdate(0)
            PanelBills.ResumeLayout()
            ListViewPatients.Focus()
        End If
    End Sub

    Private Sub bw1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Load_Patient_Bills(e.Argument)
    End Sub

    Private Sub bw2_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Load_Comments(e.Argument)
    End Sub

    Private Sub bw3_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Load_Payments(e.Argument)
    End Sub

    Private Sub bw4_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Load_Requests(e.Argument)
    End Sub

    Private Sub bw5_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Load_Patient_QNotes(e.Argument)
    End Sub

    Private Sub bw6_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Load_Patient_Comments(e.Argument)
    End Sub

    Private Sub bw7_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Load_BillToPatients(e.Argument)
    End Sub

    Private Sub bw8_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Load_Denials(e.Argument)
    End Sub

    Private Sub bw9_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Load_Documents(e.Argument)
    End Sub

    Private Sub Load_Patient_Comments(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        If ListViewPatientComments.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf Load_Patient_Comments), ID)
            Exit Sub
        End If
        Try
            ListViewPatientComments.Items.Clear()
        TextBoxCommentView.Text = ""
        TextBoxCommentViewBy.Text = ""
        Cursor = Cursors.WaitCursor
        SQL =
            "SELECT PatientComments.CommentsID, PatientComments.PatientID, PatientComments.Comment, PatientComments.InsertedDT ,  Employees.Fname + ' ' + Employees.Lname AS InsertedByName "
        SQL = SQL & " FROM PatientComments INNER JOIN Employees ON PatientComments.InsertedBy = Employees.EmpID "
        SQL = SQL & " Where PatientComments.PatientID = " & ID
        SQL = SQL & " ORDER BY PatientComments.CommentsID DESC"
        Reader = gSQLGetDataReaderAsync(SQL).Result
        If Reader Is Nothing Then Exit Sub
        ListViewPatientComments.ListViewItemSorter = Nothing
        Do Until Reader.Read = False
            If IsDate(Reader("InsertedDT").ToString) Then
                LI = ListViewPatientComments.Items.Add(CDate(Reader("InsertedDT").ToString).ToString("MM/dd/yyyy hh:mm tt"))
            Else
                LI = ListViewPatientComments.Items.Add("")
            End If
            LI.SubItems.Add(Reader("Comment").ToString)
            LI.SubItems.Add(Reader("InsertedByName").ToString)
            LI.Tag = Reader("Comment").ToString
            LI.ToolTipText = Reader("Comment").ToString
        Loop
        Reader.Close()
        Reader.Dispose()
        If ListViewPatientComments.Items.Count > 0 Then
            ListViewPatientComments.Items(0).Selected = True
            ListViewPatientComments.Items(0).EnsureVisible()
            ListViewPatientComments_SelectedIndexChanged(Nothing, Nothing)
        End If
            'gListViewRestoreDefaultColumnWidth(ListViewPatientComments)
            Cursor = Cursors.Default

        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Private Sub Load_Documents(ByVal PatientID As Integer)
        If ListViewDocs.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf Load_Documents), PatientID)
            Exit Sub
        End If
        Try
            Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        RichTextBox1.Text = ""
        RichTextBox1.Visible = False
        pdfViewer.CloseDocument()
        ListViewDocs.Items.Clear()
        'SQL = "SELECT     DocumentID, PatientID, DocumentName, DocumentProfileID, InsertedDate FROM         Documents Where PatientID=" & PatientID & "Order by DocumentID"

        SQL = "SELECT DocumentID, DocumentName, DocumentProfileID, InsertedDate FROM Documents WHERE PatientID = " & PatientID & " and DocumentProfileID in (select ProfileID from DocumentProfileSecurityLevels where PositionID= " & gCurrentEmployee.PositionID & ") ORDER BY DocumentID"

        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewDocs.Items.Add(Reader("DocumentName").ToString)
            LI.SubItems.Add(CDate(Reader("InsertedDate").ToString).ToString("MM/dd/yyyy"))
            LI.Tag = Reader("DocumentID").ToString
            LI.SubItems(1).Tag = Val(Reader("DocumentProfileID").ToString)
        Loop
        ' POM's
        If gSQLGetSingleValue("select count(*) from DocumentProfileSecurityLevels Where ProfileID=6 and PositionID=" & gCurrentEmployee.PositionID) > 0 Then
            SQL = "SELECT DISTINCT  Bills.BillID, POM.CreatedDT, POM.POMID FROM POM INNER JOIN Bills ON POM.POMID = Bills.POMID WHERE (POMImage IS NOT NULL) and Bills.PatientID = " & PatientID
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                LI = ListViewDocs.Items.Add("Bill# " & Reader("BillID").ToString & " POM")
                LI.ForeColor = Color.Blue
                LI.SubItems.Add(CDate(Reader("CreatedDT").ToString).ToString("MM/dd/yyyy"))
                LI.Tag = Reader("POMID").ToString
                LI.SubItems(1).Tag = 6
            Loop
        End If
        ' CDPOM's
        If gSQLGetSingleValue("select count(*) from DocumentProfileSecurityLevels Where ProfileID=18 and PositionID=" & gCurrentEmployee.PositionID) > 0 Then
            SQL = "SELECT  ImageDiskRequests.BillID, CDPOM.POMID, CDPOM.CreatedDT, CDPOM.CreateBy, CDPOM.RegisteredDT, CDPOM.RegisteredBy, CDPOM.POMImage, CDPOM.TS FROM CDPOM INNER JOIN ImageDiskRequests ON CDPOM.POMID = ImageDiskRequests.POMID WHERE (POMImage IS NOT NULL) and ImageDiskRequests.PatientID = " & PatientID
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                LI = ListViewDocs.Items.Add("Bill# " & Reader("BillID").ToString & "CD POM")
                LI.ForeColor = Color.Blue
                LI.SubItems.Add(CDate(Reader("CreatedDT").ToString).ToString("MM/dd/yyyy"))
                LI.Tag = Reader("POMID").ToString
                LI.SubItems(1).Tag = 18
            Loop
        End If

        ' Library
        SQL = "SELECT ID, PatientID, Data, DocName, DocDate FROM  PatientRTFDocuments WHERE PatientID = " & PatientID & " order by id "

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
            LI.Tag = doc
            LI.ToolTipText = doc.DocName
            LI.SubItems(1).Tag = 999
        Loop

        Catch ex As Exception
            log.Error(ex)
        End Try
er:
    End Sub

    Private Sub Load_Denials(BillID As Integer)
        If ListViewDenials.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf Load_Denials), BillID)
            Exit Sub
        End If
        Try

            Dim SQL As String = "SELECT BillProcedures.ProcName, PatientProcedures.DenialDate, PatientProcedures.Comments FROM Bills inner join BillProcedures on Bills.billid = BillProcedures.billid INNER JOIN PatientProcedures ON BillProcedures.PatientProcedureID = PatientProcedures.PatientProcedureID WHERE Bills.denialfound=1 and Bills.BillID = " & BillID
            Dim Reader As SqlClient.SqlDataReader
            Reader = gSQLGetDataReader(SQL)
            Dim LI As ListViewItem

            ListViewDenials.Items.Clear()
            txtDenialComments.Text = ""
            Do Until Reader.Read = False
                LI = ListViewDenials.Items.Add(Reader("ProcName").ToString())
                If IsDate(Reader("DenialDate")) Then
                    LI.SubItems.Add(CDate(Reader("DenialDate")).ToString("MM/dd/yyyy"))
                Else
                    LI.SubItems.Add("")
                End If
                LI.SubItems.Add(Reader("Comments").ToString)
            Loop
        Catch ex As Exception
            log.Error(ex)

        End Try

    End Sub

    Private Sub Load_BillToPatients(BillID As Integer)
        If ListViewBillToPatient.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf Load_BillToPatients), BillID)
            Exit Sub
        End If
        Try
            Dim SQL As String = "SELECT ID, BillID, InsertedDT, (Employees.Fname +' '+ Employees.LName) as EmpName FROM BillToPatient LEFT OUTER JOIN Employees on  BillToPatient.CreateBy = employees.EmpID  Where BillID= " & BillID
            Dim Reader As SqlClient.SqlDataReader
            Reader = gSQLGetDataReader(SQL)
            Dim LI As ListViewItem

            ListViewBillToPatient.Items.Clear()

            Do Until Reader.Read = False
                LI = ListViewBillToPatient.Items.Add(Reader("BillID"))
                LI.SubItems.Add(CDate(Reader("InsertedDT")).ToString("MM/dd/yyyy hh:mm tt"))
                LI.Tag = Reader("ID").ToString
                LI.SubItems.Add(Reader("EmpName").ToString)
            Loop
        Catch ex As Exception
            log.Error(ex)

        End Try
    End Sub

    Private Sub ToolStripMenuItem10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        ExportAttorneyDocumentsToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        ExportAttorneyDocumentsToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuUpdateAdjusterInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuUpdateAdjusterInformation.Click
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)

        frmBillingChangeAdjusterInformation.pPatientID = Val(LI.Text)
        frmBillingChangeAdjusterInformation.txtAdjuster.Text = ListViewPatients.SelectedItems(0).SubItems(18).Text
        frmBillingChangeAdjusterInformation.txtAdjusterPhone.Text = ListViewPatients.SelectedItems(0).SubItems(24).Text
        If frmBillingChangeAdjusterInformation.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ListViewPatients.SelectedItems(0).SubItems(18).Text = frmBillingChangeAdjusterInformation.txtAdjuster.Text
            ListViewPatients.SelectedItems(0).SubItems(24).Text = frmBillingChangeAdjusterInformation.txtAdjusterPhone.Text
        End If
        frmBillingChangeAdjusterInformation.Close()
        frmBillingChangeAdjusterInformation.Dispose()
    End Sub

    Private Sub ToolStripMenuItemItemizedCharges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemItemizedCharges.Click
        Dim BillID() As String = Nothing
        Dim I As Integer = 0
        Dim SavePatientID As Integer
        If ListViewPatients.CheckedItems.Count = 0 And ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to print the Itemized Charges Report. No Bill Selected!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim LI As ListViewItem
        'BillID = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value
        If ListViewPatients.CheckedItems.Count = 0 Then
            ReDim Preserve BillID(0)
            BillID(I) = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value
            SavePatientID = ListViewPatients.SelectedItems(0).Text
        Else
            For Each LI In ListViewPatients.CheckedItems
                If SavePatientID <> 0 And SavePatientID <> Val(LI.Text) Then
                    MsgBox("Unable to print the Itemized Charges Report." & vbCrLf & "The bills for the different patient's can not be included into the same Itemized Charges Report.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                SavePatientID = LI.Text
                ReDim Preserve BillID(I)
                BillID(I) = CType(LI.Tag, ValueDescription).Value
                I = I + 1
            Next
        End If
        Using frm As New frmItemizedCharges
            frm.Setup_report(BillID, SavePatientID)
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.TopMost = True
            Application.DoEvents()
            frm.ShowDialog(Me)
        End Using

    End Sub

    Private Sub ListViewRequests_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewRequests.DoubleClick
        Dim Li As ListViewItem
        Dim NewLi As ListViewItem
        Application.DoEvents()
        If ListViewRequests.SelectedItems.Count = 0 Then
            MsgBox("Unable to set Action. No Request Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim RequestDate As DateTime
        Dim BillID As Long
        SQL = "SELECT  Bills.ServiceFrom, Bills.ServiceTo,  BillingRequests.RequestTypeID, BillingRequests.RequestID, BillingRequests.BillID, BillingRequests.PatientID, BillingRequests.RequestDescription, BillingRequests.RequestFrom,  BillingRequests.ResponsibleEmpID, BillingRequests.RequestDate, BillingRequests.RequestStatusID, BillingRequests.StatusDate, BillingRequests.CDProcedures, BillingRequestStatuses.Description AS Status, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS pName "
        SQL &= " FROM         BillingRequests INNER JOIN BillingRequestStatuses ON BillingRequests.RequestStatusID = BillingRequestStatuses.StatusID INNER JOIN Patients ON BillingRequests.PatientID = Patients.PatientID LEFT OUTER JOIN Bills on BillingRequests.BillID=Bills.BillID "
        SQL &= "Where BillingRequests.RequestID = " & Val(ListViewRequests.SelectedItems(0).Tag)

        Reader = gSQLGetDataReader(SQL)
        If Reader.HasRows = False Then Exit Sub
        Reader.Read()
        frmReminder.RequestTypeID = Val(Reader("RequestTypeID").ToString)
        frmReminder.PatientID = Val(Reader("PatientID").ToString)
        frmReminder.RequestID = Val(Reader("RequestID").ToString)
        frmReminder.txtPatientInfo.Text = Reader("pName").ToString
        frmReminder.txtRequest.Text = Reader("RequestDescription").ToString
        frmReminder.txtBillID.Text = Val(Reader("BillID").ToString)
        BillID = Val(Reader("BillID").ToString)
        RequestDate = FormatDateTime(Reader("RequestDate").ToString, DateFormat.ShortDate)
        frmReminder.lblRequestAge.Text = DateDiff(DateInterval.Day, RequestDate, Now)
        frmReminder.Load_Statuses()
        gFindComboItemByValue(frmReminder.ComboBoxStatus, Val(Reader("RequestStatusID").ToString), True)
        Select Case Val(frmReminder.lblRequestAge.Text)
            Case 0
                frmReminder.lblRequestAge.Text = "CREATED TODAY"
            Case 1
                frmReminder.lblRequestAge.Text = "CREATED " & frmReminder.lblRequestAge.Text & " AGO"
            Case 2
                frmReminder.lblRequestAge.Text = "CREATED " & frmReminder.lblRequestAge.Text & " AGO"
            Case Else
                frmReminder.lblRequestAge.Text = "ATTENTION! CREATED " & frmReminder.lblRequestAge.Text & " AGO"
                frmReminder.lblRequestAge.ForeColor = Color.Red
        End Select
        frmReminder.RequestStatus = Val(Reader("RequestStatusID").ToString)

        SQL = "SELECT Fname+' '+Lname as EmpName, RequestActionID, RequestID, Description, RequestActionDate FROM BillingRequestActions inner join Employees on BillingRequestActions.CreatedBy = Employees.EmpID where RequestID = " & Val(ListViewRequests.SelectedItems(0).Tag)

        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Do Until Reader.Read = False
                Li = frmReminder.ListViewrequestActions.Items.Add(FormatDateTime(Reader("RequestActionDate").ToString, DateFormat.ShortDate))
                Li.Tag = Reader("RequestActionID").ToString
                Li.SubItems.Add(Reader("Description").ToString)
                Li.SubItems(1).Tag = Reader("EmpName").ToString
                Li.ToolTipText = Reader("Description").ToString
                Li.SubItems.Add(Reader("EmpName").ToString)
            Loop
        End If

        frmReminder.ActionsCount = frmReminder.ListViewrequestActions.Items.Count
        frmReminder.MinimizeBox = False
        frmReminder.MaximizeBox = False

        If frmReminder.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Load_Requests(BillID)
            MDIForm1Win8.TimerRefresh_Tick(Nothing, Nothing)
        End If
        frmReminder.Dispose()
        Application.DoEvents()
        ListViewRequests.Focus()

    End Sub

    Private Sub ListViewRequests_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewRequests.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        If ListViewRequests.Items.Count = 0 Then Exit Sub
        If ListViewRequests.SelectedItems.Count = 0 Then
            ListViewRequests.Items(0).Selected = True
        End If

        ListViewRequests_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ListViewAttention_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewAttention.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewAttention.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If a_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(a_SortingColumn) Then
                ' Same column. Switch the sort order.

                'If a_SortingColumn.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If a_SortingColumn.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'a_SortingColumn.Text =             a_SortingColumn.Text.Mid(2)
            a_SortingColumn.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        a_SortingColumn = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'a_SortingColumn.Text = "> " & a_SortingColumn.Text
        'Else
        'a_SortingColumn.Text = "< " & a_SortingColumn.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            a_SortingColumn.ImageKey = "SORT1"
        Else
            a_SortingColumn.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewAttention.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewAttention.Sort()
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to process. No Bill selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If gCurrentEmployee.PositionID > 3 Then
            MsgBox("Unable to process. You have no permission to access this function.", MsgBoxStyle.Critical)
        End If
        ToolStripMenuItem9_Click_1(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripFontIncrease.Click, ToolStripFontIncrease.DoubleClick
        SetFont(1)
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripFonrDecrease.Click, ToolStripFonrDecrease.DoubleClick
        SetFont(-1)
    End Sub

    Private Sub DeleteSelectedBillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSelectedBillToolStripMenuItem.Click
        Dim Li As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim SQLDeleteReplicated As String
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete Bill. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Select Case Val(ListViewPatients.SelectedItems(0).SubItems(9).Tag)
            Case 3 ' Paid
                MsgBox("Unable to delete the Paid Status Bill.", MsgBoxStyle.Exclamation)
                Exit Sub
            Case 8 ' Closed
                MsgBox("Unable to delete the Closed Bill.", MsgBoxStyle.Exclamation)
                Exit Sub
        End Select

        Dim BillID As Long
        Dim NewBillID As Long
        Dim PatientID As Long
        Dim PatientName As String
        Dim ReplicatedBills As String = ""
        Dim msgtoshow As String
        Dim billslist As New List(Of Integer)
        Li = ListViewPatients.SelectedItems(0)
        PatientID = CType(Li.Tag, ValueDescription).Value1
        PatientName = Li.SubItems(1).Text
        BillID = CType(Li.Tag, ValueDescription).Value

        SQLDeleteReplicated = "WITH    q AS "
        SQLDeleteReplicated &= "( "
        SQLDeleteReplicated &= " SELECT  CopyFromBillID "
        SQLDeleteReplicated &= " FROM    Bills "
        SQLDeleteReplicated &= " WHERE   BillID = " & BillID & " "
        SQLDeleteReplicated &= " UNION ALL "
        SQLDeleteReplicated &= " SELECT  TC.CopyFromBillID "
        SQLDeleteReplicated &= " FROM    q "
        SQLDeleteReplicated &= " JOIN    Bills tc "
        SQLDeleteReplicated &= " ON      tc.BillID = q.CopyFromBillID "
        SQLDeleteReplicated &= ") "
        SQL = SQLDeleteReplicated & " SELECT * from Q Where NOT CopyFromBillID is null "
        Reader = gSQLGetDataReader(SQL)
        billslist.Add(BillID)
        Do Until Reader.Read = False
            ReplicatedBills &= ("" & Reader("CopyFromBillID")).ToString() & ", "
            billslist.Add(Reader("CopyFromBillID"))
        Loop
        Reader.Close()

        If ReplicatedBills.EndsWith(", ") Then
            ReplicatedBills = ReplicatedBills.Mid(1, ReplicatedBills.Length - 2)
        End If
        My.Computer.Audio.Play(My.Resources.Beep221, AudioPlayMode.Background)
        If gCurrentEmployee.PositionID > 3 Then
            msgtoshow = "Delete bill # " & BillID
            If ReplicatedBills.Length > 0 Then
                msgtoshow &= vbCrLf & "The following bill(s), which were replicated, will also be deleted: "
                msgtoshow &= vbCrLf & ReplicatedBills
            End If
            frmSupervisorApproval.LabelMsg.Text = msgtoshow
            If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frmSupervisorApproval.Dispose()
                Exit Sub
            End If
            ApprovedByID = frmSupervisorApproval.SupervisorID
            ApprovedByName = frmSupervisorApproval.SupervisorName
            frmSupervisorApproval.Dispose()
            My.Computer.Audio.Play(My.Resources.Beep221, AudioPlayMode.Background)
            cMessageBox.LabelTitle.Text = "WARNING! ADMIN FUNCTION" & vbCrLf
            msgtoshow = "This process CANNOT be undone!" & vbCrLf & vbCrLf
            msgtoshow &= "You have requested to delete bill #: " & BillID & "   Bill status: " & ListViewPatients.SelectedItems(0).SubItems(9).Text
            If ReplicatedBills.Length > 0 Then
                msgtoshow &= vbCrLf & "The following bill(s), which were replicated, will also be deleted: "
                msgtoshow &= vbCrLf & ReplicatedBills
            End If
            msgtoshow &= vbCrLf & vbCrLf & "If this bill(s) has been submitted to insurance company before, it is illegal to delete this bill, unless you contact the insurance company / attorney and inform about this action!" & vbCrLf & vbCrLf & vbCrLf & "Still want to continue?"

            cMessageBox.LabelMessage.Text = msgtoshow
            If cMessageBox.ShowDialog(Me) <> DialogResult.OK Then
                cMessageBox.Dispose()
                Exit Sub
            End If
        Else
            My.Computer.Audio.Play(My.Resources.Beep221, AudioPlayMode.Background)
            cMessageBox.LabelTitle.Text = "WARNING! ADMIN FUNCTION" & vbCrLf
            msgtoshow = "This process CANNOT be undone!" & vbCrLf & vbCrLf
            msgtoshow &= "You have requested to delete bill #: " & BillID & "   Bill status: " & ListViewPatients.SelectedItems(0).SubItems(9).Text
            If ReplicatedBills.Length > 0 Then
                msgtoshow &= vbCrLf & "The following bill(s), which were replicated, will also be deleted: "
                msgtoshow &= vbCrLf & ReplicatedBills
            End If
            msgtoshow &= vbCrLf & vbCrLf & "If this bill(s) has been submitted to insurance company before, it is illegal to delete this bill, unless you contact the insurance company / attorney and inform about this action!" & vbCrLf & vbCrLf & vbCrLf & "Still want to continue?"
            cMessageBox.LabelMessage.Text = msgtoshow
            If cMessageBox.ShowDialog(Me) <> DialogResult.OK Then
                cMessageBox.Dispose()
                Exit Sub
            End If
            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If

        ' Delete Replicated Bills
        'SQL = SQLDeleteReplicated & " DELETE bills from bills inner join q on bills.BillID = q.CopyFromBillID "
        'gSQLUpdateData(SQL)

        For Each id As Integer In billslist
            gUpdate_Profile_Log(PatientID, PatientLogTypes.tBillDeleted, "Bill #: " & id & " has been deleted.", ApprovedByName)
            SQL = "DELETE FROM Bills where Bills.BillID = " & BillID
            gSQLUpdateData(SQL)
            SQL = "DELETE FROM BillProcedures Where BillID=" & id
            gSQLUpdateData(SQL)
            SQL = "DELETE FROM BillDiagnosis Where BillID = " & id
            gSQLUpdateData(SQL)
            SQL = "DELETE FROM BillComments  Where BillID = " & id
            gSQLUpdateData(SQL)
        Next

        My.Computer.Audio.Play(My.Resources.BEEP22, AudioPlayMode.Background)
        cMessageBox.ButtonYes.Visible = False
        cMessageBox.ButtonCancel.Text = "Ok Got it..."
        msgtoshow = "The Bill: " & BillID & " has been deleted!" & vbCrLf & vbCrLf
        If ReplicatedBills.Length > 0 Then
            msgtoshow &= vbCrLf & "The following replicated bill(s) has been deleted: "
            msgtoshow &= vbCrLf & ReplicatedBills
        End If
        msgtoshow &= vbCrLf & "It is illegal to delete this bill if the bill was previously submitted to an insurance company. You must contact the insurance company / attorney and advise about this change." & vbCrLf & vbCrLf & "Now, You can create a new bill for the patient: " & PatientID & " " & PatientName & " in the Billing module."
        cMessageBox.LabelMessage.Text = msgtoshow
        If cMessageBox.ShowDialog(Me) <> DialogResult.OK Then
            cMessageBox.Dispose()
            Exit Sub
        End If
        If cboBillStatus.SelectedIndex > 1 Or cboBillStatus.SelectedIndex = -1 Then cboBillStatus.SelectedIndex = 1
        Find_Patients()
        'Load_Parient_Bills(PatientID)
        'Load_Comments(BillID)
    End Sub

    Private Sub AdminToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolsToolStripMenuItem.Click

    End Sub

    Private Sub PictureBoxCloseWarnings_Click(sender As Object, e As EventArgs)
        If SplitContainer1.Panel1Collapsed = True Then
            RadioButtonF1.Checked = True
            CheckWarnings()
            SplitContainer1.SplitterDistance = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SplitterDistance", 250)
            SplitContainer1.Panel1Collapsed = False
        End If
        ToolStripButton2.Enabled = False
    End Sub

    Private Sub AssignLienAttorneyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssignLienAttorneyToolStripMenuItem.Click
        Dim frm As New frmBillingLienAttorney
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No bill selected", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim LI As ListViewItem = ListViewPatients.SelectedItems(0)

        Dim BillID As Integer = CType(LI.Tag, ValueDescription).Value
        frm.Load_Data(LI.SubItems(34).Text.Trim <> "")
        frm.Find_Data(BillID, LI.SubItems(34).Text, LI.SubItems(35).Text, LI.SubItems(34).Tag.ToString, LI)
        Dim ret = frm.ShowDialog(Me)
        frm.Dispose()
        If ret = DialogResult.OK Then Load_Comments(CType(LI.Tag, ValueDescription).Value)
    End Sub

    Private Sub ToolStripMenuItem4_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        AssignLienAttorneyToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuPrintBillProgress_Click(sender As Object, e As EventArgs) Handles mnuPrintBillProgress.Click

        Print_SelectedPatientProgress()
    End Sub

    Private Sub BillToPatientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillToPatientToolStripMenuItem.Click
        Dim BillID As Long
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to print. No bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        BillID = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value
        frmBillToPatient.BillId = BillID
        frmBillToPatient.MinimizeBox = False
        frmBillToPatient.MaximizeBox = False
        frmBillToPatient.ShowDialog(Me)
        frmBillToPatient.Dispose()
        If MsgBox("Will you send that generated bill to the patient?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = DialogResult.No Then
            Exit Sub
        End If
        Dim Sql = "INSERT INTO BillToPatient (BillID, CreateBy) VALUES(" & BillID & ",'" & gCurrentEmployee.EmpID.ToString() & "')"
        gSQLUpdateData(Sql)
        Load_BillToPatients(BillID)

        Dim TR As DataRow
        Using TA = New SqlClient.SqlDataAdapter("SELECT * FROM BillComments Where 1=2", gConnectionString)
            Using CB = New SqlClient.SqlCommandBuilder(TA)
                CB.ConflictOption = ConflictOption.OverwriteChanges
                Using dTab = New DataTable("BillComments")
                    TA.Fill(dTab)
                    TR = dTab.NewRow
                    TR("BillID") = BillID
                    TR("Comment") = "Bill Sent to the Patient."
                    TR("InsertedBy") = gCurrentEmployee.EmpID.ToString
                    TR("InsertedDT") = Now
                    TR("ReminderCompleteInd") = 0
                    TR("ReminderCompleteBy") = 0
                    TR("ReminderDT") = DateAdd(DateInterval.Day, 30, Now.Date)
                    dTab.Rows.Add(TR)
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
                    dTab.Dispose() : CB.Dispose() : TA.Dispose()
                End Using
            End Using
        End Using

        Load_Comments(BillID)
    End Sub

    Private Sub ListViewBillToPatient_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewBillToPatient.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewBillToPatient.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If btp_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(btp_SortingColumn) Then
                ' Same column. Switch the sort order.

                'If btp_SortingColumn.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If btp_SortingColumn.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'btp_SortingColumn.Text =             btp_SortingColumn.Text.Mid(2)
            btp_SortingColumn.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        btp_SortingColumn = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'btp_SortingColumn.Text = "> " & btp_SortingColumn.Text
        'Else
        'btp_SortingColumn.Text = "< " & btp_SortingColumn.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            btp_SortingColumn.ImageKey = "SORT1"
        Else
            btp_SortingColumn.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewBillToPatient.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewBillToPatient.Sort()
    End Sub

    Private Sub ListViewBillToPatient_DoubleClick(sender As Object, e As EventArgs) Handles ListViewBillToPatient.DoubleClick
        If ListViewBillToPatient.SelectedItems.Count = 0 Then Exit Sub
        SearchBillID = Val(ListViewBillToPatient.SelectedItems(0).Text).ToString
        ButtonFind_Click(Nothing, Nothing)
        SearchBillID = ""
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        BillToPatientToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.InitialPatientName = LI.Text
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ContextMenuStrip2_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening
        If ListViewBillToPatient.Items.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ToolStripMenuItem8_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        ListViewBillToPatient_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButtonDetach_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDetach.Click
        ListViewPatients.Focus()
        ToolStripButtonDetach.Image = gDetachAttachWindow(Me, MDIForm1Win8)
    End Sub

    Private Sub frmBillingManagement_ParentChanged(sender As Object, e As EventArgs) Handles MyBase.ParentChanged
        If MdiParent Is Nothing Then
            PanelTop.Visible = True
        Else
            PanelTop.Visible = False
        End If
        Application.DoEvents()
    End Sub

    Private Sub ToolStripMenuItem12_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        For Each TSi In ToolStrip2.Items
            TSi.Visible = True
        Next
        gToolStripSettings(Me, ToolStrip2, ReadWrite.sWrite)
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click

        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to use Library." & vbCrLf & "No Patient Selected.", MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If gCanRead(gSystemLibraryPath) = False Then
            MsgBox("Unable to use Library." & vbCrLf & "The library setup is not complete.", MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim frm As New frmLibrary

        frm.BillID = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value
        frm.PatientID = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value1
        frm.calledForm = Me
        If frm.ShowDialog(Me) = DialogResult.No Then
            Load_Documents(CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value1)
        End If
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub ListViewDenials_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewDenials.SelectedIndexChanged
        txtDenialComments.Text = ""
        If ListViewDenials.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        txtDenialComments.Text = ListViewDenials.SelectedItems(0).SubItems(2).Text

    End Sub

    Private Sub ToolStripButton12_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        mnuBillDenied1_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewDocs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewDocs.SelectedIndexChanged
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim MyFile As IO.FileInfo
        gHighlightListviewItem(ListViewDocs, True, False)

        If ListViewDocs.SelectedItems.Count = 0 Then
            pdfViewer.CloseDocument()

            Exit Sub
        End If
        PanelDocumentWait.Visible = True
        PanelDocumentWait.BringToFront()
        ListViewDocs.Enabled = False
        Application.DoEvents()

        Select Case Val(ListViewDocs.SelectedItems(0).SubItems(1).Tag)

            Case 6
                RichTextBox1.Visible = False
                Reader = gSQLGetDataReader("SELECT POMImage FROM POM where POMID=" & Val(ListViewDocs.SelectedItems(0).Tag))
                If Reader Is Nothing Then
                    MsgBox("Unexpected error. Please call system administrator.", MsgBoxStyle.Critical)
                    ListViewDocs.Enabled = True
                    PanelDocumentWait.Visible = False
                    Exit Sub
                End If
                If Reader.HasRows Then
                    Cursor = Cursors.WaitCursor
                    Reader.Read()
                    If Reader("POMImage") Is DBNull.Value Then
                        MsgBox("Unexpected Error." & vbCrLf & "The POM image is invalid or damaged." & vbCrLf & "Please ReScan the document." & vbCrLf & vbCrLf & "The current/invalid document image will be deleted.", MsgBoxStyle.Exclamation)
                        ListViewDocs.SelectedItems(0).Remove()
                        pdfViewer.CloseDocument()
                        pdfViewer.Visible = True

                        Cursor = Cursors.Default
                        ListViewDocs.Enabled = True
                        PanelDocumentWait.Visible = False
                        Exit Sub
                    End If
                    Dim arrayImage() As Byte = CType(Reader("POMImage"), Byte())
                    Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", ListViewDocs.SelectedItems(0).Text)
                    If System.IO.File.Exists(FName) Then
                        pdfViewer.Visible = True
                        pdfViewer.LoadDocument(FName)
                        pdfViewer.Tag = FName
                        MyFile = New IO.FileInfo(FName)
                        Cursor = Cursors.Default
                    End If
                Else
                    MsgBox("Unexpected error. No POM Image Found. Please call system administrator.", MsgBoxStyle.Critical)
                    ListViewDocs.Enabled = True
                    PanelDocumentWait.Visible = False
                    Exit Sub
                End If
            Case 18
                RichTextBox1.Visible = False
                Reader = gSQLGetDataReader("SELECT POMImage FROM CDPOM where POMID=" & Val(ListViewDocs.SelectedItems(0).Tag))
                If Reader Is Nothing Then
                    MsgBox("Unexpected error. Please call system administrator.", MsgBoxStyle.Critical)
                    ListViewDocs.Enabled = True
                    PanelDocumentWait.Visible = False
                    Exit Sub
                End If
                If Reader.HasRows Then
                    Cursor = Cursors.WaitCursor
                    Reader.Read()
                    If Reader("POMImage") Is DBNull.Value Then
                        MsgBox("Unexpected Error. The CD POM image is invalid or damaged. Please ReScan the document." & vbCrLf & vbCrLf & "The current/invalid document image will be deleted.")
                        gSQLUpdateData("DELETE FROM CDPOM where (POMImage IS NULL) and POMID=" & Val(ListViewDocs.SelectedItems(0).Tag))
                        ListViewDocs.SelectedItems(0).Remove()
                        pdfViewer.CloseDocument()
                        pdfViewer.Visible = True
                        Cursor = Cursors.Default
                        ListViewDocs.Enabled = True
                        PanelDocumentWait.Visible = False
                        Exit Sub
                    End If
                    Dim arrayImage() As Byte = CType(Reader("POMImage"), Byte())
                    Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", ListViewDocs.SelectedItems(0).Text)
                    If System.IO.File.Exists(FName) Then
                        pdfViewer.Visible = True
                        pdfViewer.LoadDocument(FName)
                        pdfViewer.Tag = FName
                        MyFile = New IO.FileInfo(FName)
                        Cursor = Cursors.Default
                    End If
                Else
                    MsgBox("Unexpected error. No POM Image Found. Please call system administrator.", MsgBoxStyle.Critical)
                    ListViewDocs.Enabled = True
                    PanelDocumentWait.Visible = False
                    Exit Sub
                End If
            Case 999 ' Library
                RichTextBox1.Rtf = CType(ListViewDocs.SelectedItems(0).Tag, RTFDocument).Data
                RichTextBox1.Dock = DockStyle.Fill
                RichTextBox1.Visible = True
                RichTextBox1.Refresh()
                pdfViewer.Visible = False

            Case Else
                RichTextBox1.Visible = False
                SQL = "SELECT DocumentImage   FROM         Documents Where DocumentID=" & ListViewDocs.SelectedItems(0).Tag
                Reader = gSQLGetDataReader(SQL)
                If Reader Is Nothing Then
                    ListViewDocs.Enabled = True
                    PanelDocumentWait.Visible = False
                    Exit Sub
                End If
                If Reader.HasRows Then
                    Cursor = Cursors.WaitCursor
                    Reader.Read()
                    If Reader("DocumentImage") Is DBNull.Value Then
                        MsgBox("Unexpected Error. The Document image is invalid or damaged. Please ReScan the document." & vbCrLf & vbCrLf & "The current/invalid document image will be deleted.")
                        gSQLUpdateData("DELETE FROM Documents where DocumentID=" & Val(ListViewDocs.SelectedItems(0).Tag))
                        ListViewDocs.SelectedItems(0).Remove()
                        pdfViewer.CloseDocument()
                        pdfViewer.Visible = True
                        Cursor = Cursors.Default
                    Else
                        Dim arrayImage() As Byte = CType(Reader("DocumentImage"), Byte())
                        Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", ListViewDocs.SelectedItems(0).Text)
                        If System.IO.File.Exists(FName) Then
                            pdfViewer.Visible = True
                            pdfViewer.LoadDocument(FName)
                            pdfViewer.Tag = FName
                            MyFile = New IO.FileInfo(FName)
                        End If
                    End If
                End If
        End Select
        ListViewDocs.Enabled = True
        PanelDocumentWait.Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        ToolStripMenuItem17_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonScannDocument_Click(sender As Object, e As EventArgs) Handles ButtonScannDocument.Click
        If gScannerMode = 1 Then
            ScanDocumentFromScannerApplication(0)
        Else
            ScanDocumentFromScanner(0)

        End If
    End Sub

    Private Sub ToolStripButtonDocuments_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDocuments.Click
        If ListViewDocs.SelectedItems.Count = 0 Then
            Exit Sub
        Else

        End If
        Select Case Val(ListViewDocs.SelectedItems(0).SubItems(1).Tag)

            Case 999
                With frmDocumentPreview
                    .RichTextBox1.Rtf = CType(ListViewDocs.SelectedItems(0).Tag, RTFDocument).Data
                    .pdfViewer.Visible = False
                    .RichTextBox1.Visible = True
                    .RichTextBox1.Dock = DockStyle.Fill
                    .RichTextBox1.BringToFront()
                    .ShowDialog(Me)
                    frmDocumentPreview.Dispose()
                    Application.DoEvents()
                End With
            Case Else
                If System.IO.File.Exists(pdfViewer.Tag) And pdfViewer.Tag <> "" Then
                    With frmDocumentPreview
                        .TextBoxReading.Visible = False
                        .pdfViewer.Visible = True
                        .pdfViewer.Dock = DockStyle.Fill
                        .pdfViewer.LoadDocument(pdfViewer.Tag.ToString())
                        .ShowDialog(Me)
                    End With
                    frmDocumentPreview.Dispose()
                    Application.DoEvents()
                End If
        End Select
    End Sub

    Private Sub ListViewPatientComments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewPatientComments.SelectedIndexChanged
        TextBoxCommentView.Text = ""
        TextBoxCommentViewBy.Text = ""
        If ListViewPatientComments.SelectedItems.Count = 0 Then Exit Sub
        TextBoxCommentView.Text = ListViewPatientComments.SelectedItems(0).Tag
        TextBoxCommentViewBy.Text = "By: " & ListViewPatientComments.SelectedItems(0).SubItems(2).Text
    End Sub

    Private Sub ButtonAddComments_Click(sender As Object, e As EventArgs) Handles ButtonAddComments.Click
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to add comments. No Patient's bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim PatId As Long = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value1

        Dim frm As frmAddComment = New frmAddComment
        frm.txtComments = TextBoxCommentView
        frm.ListViewComments = Nothing
        frm.PatientID = PatId
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            gSQLUpdateData(
                "UPDATE PatientComments set PatientID = " & PatId &
                " where PatientID=0 and InsertedBy=" & gCurrentEmployee.EmpID)
            Load_Patient_Comments(PatId)

        End If
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub chkPaymentSearch_CheckedChanged(sender As Object, e As EventArgs) Handles chkPaymentSearch.CheckedChanged
        If chkPaymentSearch.Checked Then
            Label12.Text = "Check Date: From / To"
        Else
            Label12.Text = "Payment Posted Date: From / To"
        End If

    End Sub

    Private Sub PaymentsReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaymentsReportToolStripMenuItem.Click
        Application.DoEvents()
        Dim frm As frmPaymentsReport = New frmPaymentsReport
        frm.MinimizeBox = False
        frm.MaximizeBox = False
        frm.ShowDialog(Me)
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        Dim BillId As Integer
        Application.DoEvents()
        Dim frm As frmPaymentsReport = New frmPaymentsReport
        frm.MinimizeBox = False
        frm.MaximizeBox = False
        If ListViewPatients.SelectedItems.Count > 0 Then
            BillId = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value
            frm.txtBillNumber.Text = BillId
            frm.autoSearch = True
        End If
        frm.ShowDialog(Me)
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub BulkReassignBillsToAttorneyToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub EFileSelectedBillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EFileSelectedBillToolStripMenuItem.Click
        If gEnableElectronicBillFiling = 0 Then
            ToolStripButtoneFile.Visible = False
            MsgBox("Unable to produce e-File(s)." & vbCrLf & vbCrLf & "eFileing is not activated for this office.", MsgBoxStyle.Critical)
            ListViewPatients.Focus()
            Exit Sub
        End If
        If ListViewPatients.CheckedItems.Count = 0 And ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to produce e-File(s)." & vbCrLf & "No bills checked / selected." & vbCrLf & "Please check the bill(s) and try again.", MsgBoxStyle.Critical)
            ListViewPatients.Focus()
            Exit Sub
        End If
        Dim BillID() As String = Nothing
        Dim i As Integer
        Dim eFileCreated() As String = Nothing
        Dim LI As ListViewItem
        If ListViewPatients.CheckedItems.Count = 0 Then
            ReDim Preserve BillID(0)
            BillID(i) = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value
            If ListViewPatients.SelectedItems(0).SubItems(39).Text <> "" Then
                ReDim Preserve eFileCreated(0)
                eFileCreated(0) = "Bill # " & CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value & ": eFile created on " & ListViewPatients.SelectedItems(0).SubItems(40).Text
            End If
        Else
            For Each LI In ListViewPatients.CheckedItems
                ReDim Preserve BillID(i)
                BillID(i) = CType(LI.Tag, ValueDescription).Value
                If LI.SubItems(39).Text <> "" Then
                    If IsNothing(eFileCreated) = True OrElse eFileCreated.Length < 20 Then
                        ReDim Preserve eFileCreated(i)
                        eFileCreated(i) = "Bill # " & CType(LI.Tag, ValueDescription).Value & ": eFile created on " & LI.SubItems(40).Text
                    End If
                End If
                i = i + 1
            Next
        End If
        If Not eFileCreated Is Nothing AndAlso eFileCreated.Length = 1 Then
            If MsgBox("The eFile for the following bill is already created:" & vbCrLf & vbCrLf & String.Join(vbCrLf, eFileCreated) & vbCrLf & vbCrLf & "Continue and recreate eFile for this bill?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Oops!") = MsgBoxResult.No Then
                Return
            End If
        ElseIf Not eFileCreated Is Nothing AndAlso eFileCreated.Length > 1 Then
            If MsgBox("eFiles for the following checked bills are already created:" & vbCrLf & vbCrLf & String.Join(vbCrLf, eFileCreated) & vbCrLf & vbCrLf & "Continue and recreate eFiles for those bills?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Oops!") = MsgBoxResult.No Then
                Return
            End If
        End If
        eFileBill(Me, BillID)
        If ListViewPatients.SelectedItems.Count > 0 Then
            Load_Comments(CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value)
            ListViewPatients.SelectedItems(0).SubItems(40).Text = Now.ToString("MM/dd/yyyy hh:mm tt")
        End If

    End Sub

    Private Sub ToolStripButton13_Click_1(sender As Object, e As EventArgs) Handles ToolStripButtoneFile.Click
        EFileSelectedBillToolStripMenuItem_Click(Nothing, Nothing)
    End Sub
    Private searchBillIds As String
    Private Sub ToolStripButton13_Click_2(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Using frm As New frmBillingSearch
            If frm.ShowDialog(Me) = DialogResult.OK Then
                For Each item As ListViewItem In frm.ListViewSelected.Items
                    searchBillIds = searchBillIds & item.Tag & ", "
                Next
                If searchBillIds.Length > 0 Then
                    searchBillIds = searchBillIds.Left(searchBillIds.Length - 2)
                End If
            End If
            Application.DoEvents()
            If Not String.IsNullOrEmpty(searchBillIds) Then ButtonFind_Click(Nothing, Nothing)
            searchBillIds = ""
        End Using
    End Sub
End Class