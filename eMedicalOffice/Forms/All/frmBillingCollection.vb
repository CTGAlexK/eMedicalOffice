Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmBillingCollection
    Private m_SortingColumn As ColumnHeader
    Private r_SortingColumn As ColumnHeader
    Private pPatientID As Integer = 0
    Private pPatientName As String = ""
    Private pBillID As Integer = 0
    Private pAttorney As String = ""
    Private pInsurance As String = ""
    Private pSaveCaseType As Integer = 0
    Private LastSelectedList As ListView
    Private Loaded As Boolean
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmBillingCollection_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewPatients, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewReminders, ReadWrite.sWrite)

        SaveSetting(My.Application.Info.ProductName, "Settings", "CollectionBillingDateFrom", DateTimePickerFrom.Value)
        SaveSetting(My.Application.Info.ProductName, "Settings", "CollectionBillingDateTo", DateTimePickerTo.Value)
        SaveSetting(My.Application.Info.ProductName, "Settings", "SplitterDistance", SplitContainer2.SplitterDistance)

        pdfViewer.CloseDocument(False)
    End Sub

    Private Sub frmBillingCollection_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub

    Public Loading As Boolean

    Private Sub SetFont(Optional incr As Integer = 0)
        Dim BaseSize = 8
        If BaseSize + My.Settings.FontSize + incr < 8 Or BaseSize + My.Settings.FontSize + incr > 15 Then Return
        My.Settings.FontSize = My.Settings.FontSize + incr
        My.Settings.Save()
        Dim F = New Font(Font.FontFamily, BaseSize + My.Settings.FontSize, FontStyle.Regular)
        ListViewReminders.Font = F
        ListViewPatients.Font = F
        ListViewActions.Font = F
        txtAction.Font = F
        ListViewPayments.Font = F
        ListViewRequests.Font = F
        TreeViewBills.Font = F
        txtPatientComments.Font = F
        ListViewDocs.Font = F
        ListViewDenials.Font = F
    End Sub

    Private Sub frmBillingCollection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If gCurrentEmployee.PositionID > 3 Then ToolStrip2.ContextMenuStrip = Nothing
        ToolStripSeparatorAdmin.Visible = gCurrentEmployee.PositionID < 3
        CollectionStatisticsToolStripMenuItem.Visible = gCurrentEmployee.PositionID < 3
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        DateTimePickerFrom.MaxDate = Now.Date
        DateTimePickerTo.MaxDate = Now.Date
        gListview_Settings(Me, ListViewPatients, ReadWrite.sRead)
        gListview_Settings(Me, ListViewReminders, ReadWrite.sRead)
        m_SortingColumn = ListViewPatients.Columns(1)
        r_SortingColumn = ListViewReminders.Columns(0)
        SplitContainer2.Panel1Collapsed = True
        gToolStripSettings(Me, ToolStrip2, ReadWrite.sRead)
        With My.Application.Info
            If SplitContainer2.SplitterDistance < SplitContainer2.Panel1MinSize Then
                SplitContainer2.SplitterDistance = SplitContainer2.Panel1MinSize + 1
            End If
            Dim Ret As String
            Ret = GetSetting(.ProductName, "Settings", "CollectionBillingDateFrom", "")
            If IsDate(Ret) Then
                DateTimePickerFrom.Value = Ret
            End If
            Ret = GetSetting(.ProductName, "Settings", "CollectionBillingDateTo", "")
            If IsDate(Ret) Then
                DateTimePickerTo.Value = Ret
            End If
            SplitContainer2.SplitterDistance = GetSetting(.ProductName, "Settings", "SplitterDistance", SplitContainer2.SplitterDistance)
            DateTimePickerFrom.Checked = False
            DateTimePickerTo.Checked = False
        End With
        Dim gAutocompleteAdjuster As New AutoCompleteStringCollection()
        Dim Sql As String = "SELECT DISTINCT Adjuster FROM Bills Where isnull(Bills.NoMoreCollection,0)<>1 Order by Adjuster"
        Dim Reader As SqlClient.SqlDataReader = gSQLGetDataReader(Sql)
        Do Until Reader.Read = False
            gAutocompleteAdjuster.Add(Reader("Adjuster").ToString.Trim)
            Application.DoEvents()
        Loop
        txtAdjuster.AutoCompleteCustomSource = gAutocompleteAdjuster
        Setup_Comboboxes()
        Load_Data()
        SetFont()
        Loading = False
        Loaded = True
        TimerRefresh.Interval = 500
        TimerRefresh.Enabled = True
    End Sub

    Private Sub Clear_Details()
        Dim LI As ListViewItem
        For Each LI In ListViewDetails.Items
            LI.SubItems(1).Text = ""
        Next
        RichTextBox1.Text = ""
        RichTextBox1.Visible = False
        ToolStripStatusLabelPatName.Text = ""
        ListViewActions.Items.Clear()
        TreeViewBills.Nodes.Clear()
        ListViewPayments.Items.Clear()
        ListViewRequests.Items.Clear()
        ListViewDocs.Items.Clear()
        ListViewBillToPatient.Items.Clear()
        ListViewDenials.Items.Clear()
        txtDenialComments.Text = ""
        txtPatientComments.Text = ""
        txtAction.Text = ""
        pPatientID = 0
        pPatientName = ""
        pBillID = 0
        pAttorney = ""
        pInsurance = ""
        pSaveCaseType = 0
        pdfViewer.CloseDocument()
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

            Dim AttotneyInd As Boolean = False
            cboBillStatus.Items.Clear()
            cboBillStatus.Items.Add(New ValueDescription("0", "All"))
            cboBillStatus.Items.Add(New ValueDescription("-1", "All Active"))
            Reader = gSQLGetDataReader("SELECT     BillStatusID, Description FROM BillStatus ")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                If Reader("BillStatusID") = 4 Or Reader("BillStatusID") = 5 Then
                    If AttotneyInd = False Then
                        AttotneyInd = True
                        cboBillStatus.Items.Add(New ValueDescription(-10, "Attorney"))
                    End If
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

            Reader.Close() : Reader.Dispose()
            With cboAttorneysCompanyID.Items
                .Clear()
                .Add(New ValueDescription("0", "All"))
                Reader = gSQLGetDataReader("Select CompanyID, CompanyName, AttorneyFName+' '+AttorneyLName as AttorneyName from Attorneys Where OfficeID=" & gOfficeID)
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    .Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString & " - " & Reader("AttorneyName").ToString))
                Loop
            End With
            Reader.Close() : Reader.Dispose()

            cboDays.Items.Add("")
            For I = 1 To 45
                Select Case I
                    Case 1, 21, 31, 41
                        cboDays.Items.Add(I & " Day")
                    Case Else
                        cboDays.Items.Add(I & " Days")
                End Select
            Next
            ' cboDays.SelectedIndex = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SelectedDays", 29)

            With cboInsuranceCompanyID
                .Items.Clear()
                .Items.Add(New ValueDescription(0, "All"))
                .Items.Add(New ValueDescription(-1, "-----------------------------------------INSURANCE GROUPS-----------------------------------------"))
                .SelectedIndex = 0
                .DropDownHeight = 106
                Application.DoEvents()
                Reader = gSQLGetDataReader("SELECT DISTINCT  GroupID, Description FROM InsuranceCompaniesGroups ORDER BY Description")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    .Items.Add(New ValueDescription(CLng(Val(Reader("GroupID").ToString)), Reader("Description").ToString & " - Group", "0"))
                Loop
                If .Items.Count > 0 Then
                    .Items.Add(New ValueDescription(-1, "--------------------------------------INSURANCE COMPANIES--------------------------------------"))
                End If

                Reader = gSQLGetDataReader("Select CompanyID, CompanyName from InsuranceCompanies ORDER BY CompanyName")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    .Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString, "1"))
                Loop
                If .Items.Count = 0 Then
                    .DropDownHeight = 20
                End If
            End With
            Reader.Close() : Reader.Dispose()

            cboBillStatus.DropDownWidth = 120
            With cboCollector.Items
                .Clear()
                .Add(New ValueDescription("0", "All"))
                Reader = gSQLGetDataReader("SELECT Positions.Description,    EmpID, Fname + '  ' +Lname as EmpName FROM Positions INNER JOIN Employees ON Positions.PositionID = Employees.PositionID WHERE Positions.PositionID = 1 or Positions.PositionID = 2 or Positions.PositionID = 3 or Positions.PositionID = 6 ORDER BY Fname , Lname")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    .Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("EmpName").ToString & " - " & Reader("Description").ToString))
                Loop
            End With
            Reader.Close() : Reader.Dispose()
            Clear_Criterias()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Clear_Criterias()
        txtPatient.Text = ""
        txtBillNumber.Text = ""
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        txtAdjuster.Text = ""
        cboDays.SelectedIndex = 0
        cboAttorneysCompanyID.SelectedIndex = 0
        cboBillingProvider.SelectedIndex = 0
        cboCollector.SelectedIndex = 0
        cboBillStatus.SelectedIndex = 1

    End Sub

    Private Sub Setup_Comboboxes()
        AddHandler cboInsuranceCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboInsuranceCompanyID.Leave, AddressOf sSearchComboBox_Leave
        AddHandler cboAttorneysCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboAttorneysCompanyID.Leave, AddressOf sSearchComboBox_Leave

        AddHandler cboBillStatus.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboBillStatus.Leave, AddressOf sSearchComboBox_Leave

    End Sub

    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        TableLayoutPanel1.Enabled = False
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Find_Bills()
        Cursor = Cursors.Default
        TableLayoutPanel1.Enabled = True
    End Sub

    Private Sub Find_Bills()
        Dim SQL As String = ""
        Dim Reader As SqlClient.SqlDataReader
        Dim PName() As String
        Dim Days As Integer = 0
        Dim LI As ListViewItem
        Dim SISTATUS As ListViewItem.ListViewSubItem
        Dim Amount As Double = 0
        Dim SI As ListViewItem.ListViewSubItem

        If Not m_SortingColumn Is Nothing Then m_SortingColumn.ImageKey = "SORT0"
        m_SortingColumn = ListViewPatients.Columns(1)
        m_SortingColumn.ImageKey = "SORT1"
        ToolStripLabelFound.Text = ""

        SQL = "SELECT Bills.DenialFound, Patients.CaseStatusID, InsuranceCompaniesLien.CompanyName as Lien_Attorney, Bills.Lien_date,Bills.Lien_comments,    Bills.CaseTypeID, Bills.PatientID, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS pName, Patients.DOA, Bills.BillID, Bills.BillDate, Bills.BillStatusID, BillStatus.Description, CONVERT(varchar, Bills.ServiceFrom, 101) + ' - ' + CONVERT(varchar, Bills.ServiceTo, 101) AS SvcDates, Bills.BillAmount, ISNULL(Bills.PaidAmount, 0) AS PAmount, Bills.BillAmount - ISNULL(Bills.PaidAmount, 0) AS Balance, Bills.IndexNumber, Bills.Adjuster, Bills.AdjusterPhone, InsuranceCompanies.CompanyName AS Ins, Patients.Attorney as pAttorney "
        SQL &= ", (SELECT  max(InsertedDT) FROM BillToPatient WHERE BillToPatient.BillID = Bills.BillID) as BillToPatientDT "

        SQL &= " FROM Bills INNER JOIN Patients ON Bills.PatientID = Patients.PatientID INNER JOIN BillStatus ON Bills.BillStatusID = BillStatus.BillStatusID INNER JOIN InsuranceCompanies ON Bills.InsCompanyID = InsuranceCompanies.CompanyID "
        SQL &= " LEFT OUTER JOIN InsuranceCompanies InsuranceCompaniesLien On Bills.Lien_attorney_id = InsuranceCompaniesLien.CompanyID"
        SQL &= " WHERE Patients.OfficeID = " & gOfficeID & " and isnull(Bills.NoMoreCollection,0)<>1 "
        ' Search Criterias
        txtPatient.Text = txtPatient.Text.Trim.ToSafeSQLString()

        If txtBillNumber.Text.Trim <> "" Then
            SQL &= " AND (Bills.OldBillNumber = " & Val(txtBillNumber.Text) & " or Bills.BillID = " & Val(txtBillNumber.Text) & " or Bills.PolicyNumber = '" & txtBillNumber.Text.Trim.ToSafeSQLString() & "%' or Bills.ClaimNumber = '" & txtBillNumber.Text.Trim.ToSafeSQLString() & "%') "
        Else
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

            If DateTimePickerFrom.Checked Then
                SQL &= " and DATEDIFF(d, Bills.BillDate, '" & DateTimePickerFrom.Value.Date & "')<=0  "
            End If
            If DateTimePickerTo.Checked Then
                SQL &= " and DATEDIFF(d, Bills.BillDate, '" & DateTimePickerTo.Value.Date & "')>=0 "
            End If
            If cboBillingProvider.SelectedIndex > 0 Then
                SQL &= " AND Bills.BillingProviderID = " & CType(cboBillingProvider.SelectedItem, ValueDescription).Value & " "
            End If

            If cboAttorneysCompanyID.SelectedIndex > 0 Then
                SQL &= " AND (Bills.AttorneyCompanyID = " & CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Value & " )"
            End If
            If cboInsuranceCompanyID.SelectedIndex > 0 Then
                If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value1 = "0" Then
                    SQL &= " AND Bills.InsCompanyID in (Select CompanyID From InsuranceCompanies Where GroupID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & ") "
                Else
                    SQL &= " AND Bills.InsCompanyID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & " "
                End If
            End If
            If cboBillStatus.SelectedIndex > 0 Then
                If CType(cboBillStatus.SelectedItem, ValueDescription).Value = -1 Then ' All Active
                    SQL &= " AND (Bills.BillStatusID <> 7 and Bills.BillStatusID <> 8) "
                ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = -10 Then ' Attorney - Litigation = 4 Arbitration = 5
                    SQL &= " AND (Bills.BillStatusID = 4 or Bills.BillStatusID = 5) "
                ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = -20 Then  ' Not Answered
                    SQL &= " AND (Bills.DenialFound=0 and (Bills.BillStatusID=2 or Bills.BillStatusID=4 or Bills.BillStatusID =5))"
                ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = -30 Then  ' Not Answered
                    SQL &= " AND (Bills.NoMoreCollection=1)"
                ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = 6 Then  ' Denied
                    'SQL &= " AND Bills.DenialFound = 1 "
                    SQL &= " AND Bills.DenialFound = 1 and ((Bills.BillAmount-isnull(Bills.PaidAmount,0)) > 0) "

                ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = 10 Then  ' Litigation
                    SQL &= " AND Bills.IndexNumber like 'L-%' "
                ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = 11 Then  ' Arbitration
                    SQL &= " AND Bills.IndexNumber like 'A-%' "
                ElseIf CType(cboBillStatus.SelectedItem, ValueDescription).Value = -40 Then  ' All Not Filed
                    SQL &= " AND isnull(Bills.IndexNumber,'')='' "
                Else
                    SQL &= " AND Bills.BillStatusID = " & CType(cboBillStatus.SelectedItem, ValueDescription).Value & " "
                End If
            End If
            If cboDays.SelectedIndex > 0 Then
                Days = cboDays.SelectedIndex + 1
                SQL &= " AND (Bills.BillStatusID = 2 Or Bills.BillStatusID = 4 Or Bills.BillStatusID = 5) AND "
                SQL &= "        ( "
                SQL &= "        (Bills.BillID in ( "
                SQL &= "        select BillID from BillingRequests "
                SQL &= "                WHERE(RequestStatusID = 3) "
                SQL &= "                GROUP BY BillID "
                SQL &= "                HAVING DATEDIFF(d,max(StatusDate),getdate()) > " & Days
                SQL &= "        )) or "
                SQL &= "        (Bills.BillID not in ( "
                SQL &= "        select BillID from dbo.BillingRequests "
                SQL &= "        ) and DATEDIFF(d,BillDate ,getdate()) > " & Days & " "
                SQL &= "        )) "
            End If
        End If
        If txtAdjuster.Text <> "" Then
            SQL &= " AND Bills.Adjuster = '" & txtAdjuster.Text.ToSafeSQLString() & "' "

        End If
        SQL &= " ORDER BY pName, Bills.BillID "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ListViewPatients.SuspendLayout()
        ListViewPatients.BeginUpdate()
        ListViewPatients.Items.Clear()
        ListViewPatients.ListViewItemSorter = Nothing

        Do Until Reader.Read = False
            LI = ListViewPatients.Items.Add(Reader("PatientID").ToString)
            LI.UseItemStyleForSubItems = False
            LI.Tag = Reader("BillID").ToString
            LI.SubItems.Add(Reader("pName").ToString)
            If IsDate(Reader("DOA").ToString) Then
                LI.SubItems.Add(CDate(Reader("DOA").ToString).ToShortDateString)
            Else
                LI.SubItems.Add("")
            End If
            LI.SubItems.Add(Reader("SvcDates").ToString)
            LI.SubItems.Add(Reader("BillID").ToString)
            If IsDate(Reader("BillDate").ToString) Then
                LI.SubItems.Add(CDate(Reader("BillDate").ToString).ToShortDateString)
            Else
                LI.SubItems.Add("")
            End If

            SISTATUS = LI.SubItems.Add(Reader("Description").ToString)
            SISTATUS.Tag = Reader("BillStatusID").ToString
            LI.SubItems.Add(Val(Reader("BillAmount").ToString))
            Amount += Val(Reader("BillAmount").ToString)
            LI.SubItems.Add(Val(Reader("PAmount").ToString))
            LI.SubItems.Add(Val(Reader("Balance").ToString))
            LI.SubItems.Add(Reader("IndexNumber").ToString)
            LI.SubItems.Add(Reader("Ins").ToString)
            LI.SubItems.Add(Reader("Adjuster").ToString)
            If Reader("AdjusterPhone").ToString <> "(___) ___-____ Ext. _____" And InStr(Reader("AdjusterPhone").ToString, "(___) ___-____") = 0 Then
                LI.SubItems.Add(Reader("AdjusterPhone").ToString)
            Else
                LI.SubItems.Add("")
            End If
            LI.SubItems.Add(Trim(Reader("pAttorney").ToString))

            SI = LI.SubItems.Add(Trim(Reader("Lien_Attorney").ToString))
            SI.Tag = Reader("Lien_comments").ToString

            If IsDate(Reader("Lien_date").ToString) Then
                LI.SubItems.Add(CDate(Reader("Lien_date")).ToString("MM/dd/yyyy"))
            Else
                LI.SubItems.Add("")
            End If
            If IsDate(Reader("BillToPatientDT").ToString) Then
                SI = LI.SubItems.Add(CDate(Reader("BillToPatientDT")).ToString("MM/dd/yyyy"))
            Else
                SI = LI.SubItems.Add("")
            End If
            If IsDate(Reader("BillToPatientDT")) And Val("" & Reader("Balance").ToString) > 0 And Val("" & Reader("CaseStatusID").ToString) = 1 And Val("" & Reader("BillStatusID").ToString) <> 13 And Val("" & Reader("BillStatusID").ToString) <> 8 Then
                If DateDiff(DateInterval.Day, CDate(Reader("BillToPatientDT")), Now.Date) > 30 Then
                    SI.BackColor = Color.Red
                    SI.ForeColor = Color.White
                End If
            End If
            If Val(Reader("DenialFound").ToString) = 1 Then
                SI = LI.SubItems.Add("YES")
                SI.ForeColor = Color.Red
            Else
                SI = LI.SubItems.Add("NO")
            End If

            Select Case Val(Reader("BillStatusID").ToString)
                Case 1
                    'gSetListItemColor(Li, Color.Olive)
                Case 2
                    'gSetListItemColor(Li, Color.LightSteelBlue)
                    SISTATUS.BackColor = Color.LightSteelBlue
                Case 3
                    'gSetListItemColor(Li, Color.Green)
                    SISTATUS.BackColor = Color.LightGreen
                    'Case 4, 5, 10, 11
                Case 10, 11
                    'gSetListItemColor(Li, Color.Orange)
                    SISTATUS.BackColor = Color.DarkOrange
                Case 6, 7
                    'gSetListItemColor(Li, Color.Red)
                    SISTATUS.BackColor = Color.DarkSalmon
                Case 8
                    'gSetListItemColor(Li, Color.Gainsboro)
                    SISTATUS.BackColor = Color.Red
                    SISTATUS.ForeColor = Color.White
            End Select
            LI.SubItems(1).Tag = Val(Reader("CaseTypeID").ToString)
        Loop

        If ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
            ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
        End If
ExitSub:
        ListViewPatients.EndUpdate()
        ListViewPatients.ResumeLayout()
        Cursor = Cursors.Default
        If ListViewPatients.Items.Count = 1 Then
            ToolStripLabelFound.Text = "1 Bill"
        Else
            ToolStripLabelFound.Text = ListViewPatients.Items.Count & " Bills"
        End If

    End Sub

    Private Sub Find_Reminders()
        Dim SQL As String = ""
        Dim Reader As SqlClient.SqlDataReader
        Dim PName() As String
        Dim Days As Integer = 0
        Dim LI As ListViewItem
        Dim SISTATUS As ListViewItem.ListViewSubItem
        Dim Amount As Double = 0
        If Loading = True Then Exit Sub
        If Not r_SortingColumn Is Nothing Then r_SortingColumn.ImageKey = "SORT0"
        r_SortingColumn = ListViewReminders.Columns(0)
        r_SortingColumn.ImageKey = "SORT1"
        ToolStripLabelReminders.Text = ""

        SQL = "SELECT     BillComments.Comment, BillComments.CommentID, BillComments.ReminderCompleteInd, BillComments.ReminderDT, Employees.Fname + ' ' + Employees.Lname AS EmpName, Bills.CaseTypeID, Bills.PatientID, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS pName, Patients.DOA, Bills.BillID, Bills.BillDate, Bills.BillStatusID, BillStatus.Description, CONVERT(varchar, Bills.ServiceFrom, 101) + ' - ' + CONVERT(varchar, Bills.ServiceTo, 101) AS SvcDates, Bills.BillAmount, ISNULL(Bills.PaidAmount, 0) AS PAmount, Bills.BillAmount - ISNULL(Bills.PaidAmount, 0) AS Balance, Bills.IndexNumber, InsuranceCompanies.CompanyName AS ins, Bills.Adjuster, Bills.AdjusterPhone "
        SQL &= " FROM Bills INNER JOIN Patients ON Bills.PatientID = Patients.PatientID INNER JOIN BillStatus ON Bills.BillStatusID = BillStatus.BillStatusID INNER JOIN BillComments ON BillComments.BillID = Bills.BillID INNER JOIN Employees ON BillComments.InsertedBy = Employees.EmpID INNER JOIN InsuranceCompanies ON Bills.InsCompanyID = InsuranceCompanies.CompanyID "
        SQL &= " WHERE Patients.OfficeID = " & gOfficeID & " and isnull(Bills.NoMoreCollection,0)<>1 "
        SQL &= " AND  (ReminderDT IS NOT NULL) "
        If RadioButton1.Checked Then
            SQL &= " AND DATEDIFF(d, BillComments.ReminderDT, getdate())>=0 "
        End If
        SQL &= " AND ReminderCompleteInd = 0"

        If cboCollector.SelectedIndex > 0 Then
            SQL &= " AND BillComments.InsertedBy = " & CType(cboCollector.SelectedItem, ValueDescription).Value
        End If
        SQL &= " ORDER BY ReminderDT, pName, Bills.BillID "

        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ListViewReminders.SuspendLayout()
        ListViewReminders.BeginUpdate()
        ListViewReminders.Items.Clear()
        ListViewReminders.ListViewItemSorter = Nothing

        Do Until Reader.Read = False
            LI = ListViewReminders.Items.Add(CDate(Reader("ReminderDT").ToString).ToShortDateString)

            If CDate(CDate(Reader("ReminderDT").ToString).ToShortDateString) < CDate(Now.ToShortDateString) Then
                If Val(Reader("ReminderCompleteInd").ToString) = 0 Then
                    LI.BackColor = Color.LightSalmon
                Else
                    LI.BackColor = Color.LightSeaGreen
                End If
            Else
                LI.BackColor = Color.Gold
            End If

            LI.UseItemStyleForSubItems = False
            LI.Tag = Reader("BillID").ToString
            LI.SubItems.Add(Reader("EmpName").ToString)
            LI.SubItems.Add(Reader("PatientID").ToString)
            LI.SubItems.Add(Reader("pName").ToString)
            If IsDate(Reader("DOA").ToString) Then
                LI.SubItems.Add(CDate(Reader("DOA").ToString).ToShortDateString)
            Else
                LI.SubItems.Add("")
            End If
            LI.SubItems.Add(Reader("SvcDates").ToString)
            LI.SubItems.Add(Reader("BillID").ToString)
            If IsDate(Reader("BillDate").ToString) Then
                LI.SubItems.Add(CDate(Reader("BillDate").ToString).ToShortDateString)
            Else
                LI.SubItems.Add("")
            End If

            SISTATUS = LI.SubItems.Add(Reader("Description").ToString)
            SISTATUS.Tag = Reader("BillStatusID").ToString
            LI.SubItems.Add(Val(Reader("BillAmount").ToString))
            Amount += CDbl(Reader("BillAmount").ToString)
            LI.SubItems.Add(Val(Reader("PAmount").ToString))
            LI.SubItems.Add(Val(Reader("Balance").ToString))
            LI.SubItems(5).Tag = Val(Reader("CommentID").ToString)
            LI.SubItems(4).Tag = Reader("Comment").ToString

            LI.SubItems.Add(Reader("IndexNumber").ToString)
            LI.SubItems.Add(Reader("Ins").ToString)
            LI.SubItems.Add(Reader("Adjuster").ToString)
            If Reader("AdjusterPhone").ToString <> "(___) ___-____ Ext. _____" And InStr(Reader("AdjusterPhone").ToString, "(___) ___-____") = 0 Then
                LI.SubItems.Add(Reader("AdjusterPhone").ToString)
            Else
                LI.SubItems.Add("")
            End If

            Select Case Val(Reader("BillStatusID").ToString)
                Case 1
                    'gSetListItemColor(Li, Color.Olive)
                Case 2
                    'gSetListItemColor(Li, Color.LightSteelBlue)
                    SISTATUS.BackColor = Color.LightSteelBlue
                Case 3
                    'gSetListItemColor(Li, Color.Green)
                    SISTATUS.BackColor = Color.LightGreen
                    'Case 4, 5, 10, 11
                Case 10, 11
                    'gSetListItemColor(Li, Color.Orange)
                    SISTATUS.BackColor = Color.DarkOrange
                Case 6, 7
                    'gSetListItemColor(Li, Color.Red)
                    SISTATUS.BackColor = Color.DarkSalmon
                Case 8
                    'gSetListItemColor(Li, Color.Gainsboro)
                    SISTATUS.BackColor = Color.Red
                    SISTATUS.ForeColor = Color.White
            End Select
            LI.SubItems(1).Tag = Val(Reader("CaseTypeID").ToString)
        Loop

        Application.DoEvents()
        LockWindowUpdate(Me.Handle)
        If ListViewReminders.Items.Count > 0 Then
            SplitContainer2.Panel1Collapsed = False
            SplitContainer2.Refresh()
            Application.DoEvents()
            Application.DoEvents()

            TimerGetReminderDetails.Enabled = True
        Else
            SplitContainer2.Panel1Collapsed = True
        End If
        LockWindowUpdate(0)
ExitSub:
        ListViewReminders.EndUpdate()
        ListViewReminders.ResumeLayout()
        ListViewReminders.Refresh()
        Cursor = Cursors.Default
        If ListViewReminders.Items.Count = 1 Then
            ToolStripLabelReminders.Text = "1 Reminder"
        Else
            ToolStripLabelReminders.Text = ListViewReminders.Items.Count & " Reminders"
        End If

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

    Private Sub ListViewReminders_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewReminders.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewReminders.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If r_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(r_SortingColumn) Then
                ' Same column. Switch the sort order.

                'If r_SortingColumn.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If r_SortingColumn.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'r_SortingColumn.Text =             r_SortingColumn.Text.Mid(2)
            r_SortingColumn.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        r_SortingColumn = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'r_SortingColumn.Text = "> " & r_SortingColumn.Text
        'Else
        'r_SortingColumn.Text = "< " & r_SortingColumn.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            r_SortingColumn.ImageKey = "SORT1"
        Else
            r_SortingColumn.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewReminders.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewReminders.Sort()
    End Sub

    Private Sub ListViewPatients_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPatients.DoubleClick
        'If ListViewPatients.SelectedItems.Count > 0 Then
        '    ToolStripButtonAction_Click(Nothing, Nothing)
        'End If
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
        SaveListView = ListViewPatients
        ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub ListViewPatients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewPatients.SelectedIndexChanged
        Dim Reader As SqlClient.SqlDataReader

        If ListViewPatients.SelectedItems.Count = 0 Then
            Clear_Details()
            Exit Sub
        End If
        SaveListView = ListViewPatients
        pSaveCaseType = ListViewPatients.SelectedItems(0).SubItems(1).Tag
        Load_Details(Val(ListViewPatients.SelectedItems(0).Tag), Val(ListViewPatients.SelectedItems(0).Text), ListViewPatients.SelectedItems(0).SubItems(1).Text)
        LastSelectedList = ListViewPatients
    End Sub

    Private Sub Load_Details(ByVal BillID As Integer, ByVal PatientID As Integer, ByVal PatientName As String)
        Clear_Details()
        pPatientID = PatientID
        pPatientName = PatientName
        pBillID = BillID
        ToolStripStatusLabelPatName.Text = PatientName
        LockWindowUpdate(PanelDetails.Handle)
        PanelDetails.SuspendLayout()
        Load_Info(BillID, PatientID)
        Load_Patient_Bills(PatientID)
        Load_Payments(BillID)
        Load_Requests(BillID)
        Load_Patient_Coments(PatientID)
        Load_Documents(PatientID)
        Load_Actions(BillID)
        Load_BillToPatients(BillID)
        Load_Denials(BillID)
        LockWindowUpdate(0)
        PanelDetails.ResumeLayout()
    End Sub

    Private Sub Load_Denials(BillID As Integer)
        Dim SQL As String = "SELECT BillProcedures.ProcName, PatientProcedures.DenialDate, PatientProcedures.Comments FROM Bills inner join BillProcedures on Bills.billid = BillProcedures.billid INNER JOIN PatientProcedures ON BillProcedures.PatientProcedureID = PatientProcedures.PatientProcedureID WHERE Bills.denialfound=1 and Bills.BillID = " & BillID
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader(SQL)
        Dim LI As ListViewItem

        ListViewDenials.Items.Clear()
        txtDenialComments.Text = ""
        Do Until Reader.Read = False
            LI = ListViewDenials.Items.Add("" & Reader("ProcName").ToString())
            If IsDate(Reader("DenialDate")) Then
                LI.SubItems.Add(CDate(Reader("DenialDate")).ToString("MM/dd/yyyy"))
            Else
                LI.SubItems.Add("")
            End If
            LI.SubItems.Add("" & Reader("Comments").ToString())
        Loop

    End Sub

    Private Sub Load_Actions(ByVal BillID As Integer)
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim LIReminder As ListViewItem.ListViewSubItem
        ListViewActions.Items.Clear()
        txtAction.Text = ""
        Reader = gSQLGetDataReader("SELECT ReminderCompleteDT, CompletedEmp.Fname + ' ' + CompletedEmp.Lname as CompEmp, BillComments.CommentID, BillComments.BillID, BillComments.Comment, BillComments.ReminderDT, BillComments.ReminderCompleteInd, BillComments.InsertedDT, BillComments.InsertedBy, Employees.Fname + ' ' + Employees.Lname AS EmpName FROM BillComments INNER JOIN Employees ON BillComments.InsertedBy = Employees.EmpID LEFT OUTER JOIN Employees as CompletedEmp ON BillComments.ReminderCompleteBy = CompletedEmp.EmpID Where BillID = " & BillID & "  order by InsertedDT Desc")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewActions.Items.Add(CDate(Reader("InsertedDT")).ToString("MM/dd/yy"))
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
                        LI.ToolTipText = "Reminder Completed by " & Reader("CompEmp").ToString & " on " & CDate(Reader("ReminderCompleteDT")).ToString("MM/dd/yy")
                    End If
                Else
                    If Val(Reader("ReminderCompleteInd").ToString) = 0 Then
                        LIReminder.BackColor = Color.Gold
                    Else
                        LIReminder.BackColor = Color.LightSeaGreen
                        LI.ToolTipText = "Reminder Completed by " & Reader("CompEmp").ToString & " on " & CDate(Reader("ReminderCompleteDT")).ToString("MM/dd/yy")
                    End If
                End If
            Else
                LI.SubItems.Add("")
            End If
            LI.SubItems(2).Tag = Val(Reader("CommentID").ToString)

        Loop
        If ListViewActions.Items.Count > 0 Then
            ListViewActions.Items(0).Selected = True
            ListViewActions.Items(0).EnsureVisible()
            ListViewActions_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub Load_Documents(ByVal PatientID As Integer)
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

er:
    End Sub

    Private Sub Load_Info(ByVal BillID As Integer, ByVal PatientID As Integer)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String = ""
        Dim LI As ListViewItem
        For Each LI In ListViewDetails.Items
            LI.SubItems(1).Text = ""
        Next
        Application.DoEvents()
        SQL = "SELECT     Bills.BillID, Bills.InsCompanyID, InsuranceCompanies.CompanyName, Bills.Adjuster, Bills.AdjusterPhone, Bills.PolicyNumber, Bills.ClaimNumber, Attorneys.CompanyName AS Attorney, Bills.AttorneyDate, Bills.POMID, TR.Fname + ' ' + TR.Lname AS TRName, BL.Fname + ' ' + BL.Lname AS BLName, Bills.IndexNumber, Bills.FilingDate, Bills.AttorneyCompanyID, Bills.CaseTypeID "
        SQL &= " FROM Bills LEFT OUTER JOIN "
        SQL &= " Employees AS BL ON Bills.BillingProviderID = BL.EmpID LEFT OUTER JOIN "
        SQL &= " Employees AS TR ON Bills.TreatingProviderID = TR.EmpID LEFT OUTER JOIN "
        SQL &= " Attorneys ON Bills.AttorneyCompanyID = Attorneys.CompanyID LEFT OUTER JOIN "
        SQL &= " InsuranceCompanies ON Bills.InsCompanyID = InsuranceCompanies.CompanyID "
        SQL &= " WHERE Bills.BillID = " & BillID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Reader.Read()
            ListViewDetails.Items(0).SubItems(1).Text = Reader("CompanyName").ToString
            ListViewDetails.Items(1).SubItems(1).Text = Reader("Adjuster").ToString
            ListViewDetails.Items(2).SubItems(1).Text = Reader("AdjusterPhone").ToString
            ListViewDetails.Items(3).SubItems(1).Text = Reader("PolicyNumber").ToString
            ListViewDetails.Items(4).SubItems(1).Text = Reader("ClaimNumber").ToString
            ListViewDetails.Items(5).SubItems(1).Text = Reader("Attorney").ToString
            If IsDate(Reader("AttorneyDate").ToString) Then
                ListViewDetails.Items(6).SubItems(1).Text = CDate(Reader("AttorneyDate")).ToString("MM/dd/yy")
            End If
            ListViewDetails.Items(7).SubItems(1).Text = Reader("POMID").ToString
            ListViewDetails.Items(8).SubItems(1).Text = Reader("TRName").ToString
            ListViewDetails.Items(9).SubItems(1).Text = Reader("BLName").ToString
            ListViewDetails.Items(10).SubItems(1).Text = Reader("IndexNumber").ToString
            If IsDate(Reader("FilingDate").ToString) Then
                ListViewDetails.Items(11).SubItems(1).Text = CDate(Reader("FilingDate")).ToString("MM/dd/yy")
            End If

            pAttorney = Val(Reader("AttorneyCompanyID").ToString)
            pInsurance = Val(Reader("InsCompanyID").ToString)
            pSaveCaseType = Val(Reader("CaseTypeID").ToString)
        End If
    End Sub

    Private Sub Load_Patient_Bills(ByVal PatientID)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String = ""
        Dim ParentNode As TreeNode = Nothing
        Dim ChildNode As TreeNode = Nothing
        Dim DiagNode As TreeNode = Nothing
        Dim Icn As String = ""
        Dim SaveBillID As Long = 0
        Dim SaveProcedureID As Long = 0
        'If PanelBills.Visible = False Then Exit Sub
        SQL = "SELECT    BillProcedures.PatientProcedureID,    Bills.CopyFromBillID, Bills.SplitBillID, Bills.BillDate, BillProcedures.BillID, Bills.BillAmount, Bills.BillStatusID, BillStatus.Description AS BillStatus,  BillDiagnosis.ICDCode, BillDiagnosis.ICDDescription, BillProcedures.ProcName "
        SQL &= " FROM            Bills INNER JOIN BillProcedures ON Bills.BillID = BillProcedures.BillID LEFT OUTER JOIN BillStatus ON Bills.BillStatusID = BillStatus.BillStatusID LEFT OUTER JOIN BillDiagnosis ON BillProcedures.BillID = BillDiagnosis.BillID  "
        SQL &= " WHERE Bills.PatientID = " & PatientID
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
        TreeViewBills.EndUpdate()
    End Sub

    Private Sub Load_Payments(ByVal BillID As Long)
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

    End Sub

    Private Sub Load_Requests(ByVal BillID)
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
    End Sub

    Private Sub Load_Patient_Coments(ByVal PatientID As Long)
        Dim Reader As SqlClient.SqlDataReader = Nothing
        txtPatientComments.Text = ""
        Reader = gSQLGetDataReader("SELECT Comments FROM Patients where PatientID = " & PatientID)
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Reader.Read()
            txtPatientComments.Text = Reader("Comments").ToString
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripAutoResize.Click
        gListViewRestoreDefaultColumnWidth(ListViewPatients)
        gListViewRestoreDefaultColumnWidth(ListViewReminders)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Clear_Criterias()
    End Sub

    Private Sub ToolStripButtonPatientComments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonPatientComments.Click
        If pBillID = 0 Then Exit Sub
        If txtPatientComments.Text.Trim = "" Then Exit Sub
        frmBillCommentsShow.Label1.Text = "PATIENT COMMENTS"
        frmBillCommentsShow.BillNumber = pBillID
        frmBillCommentsShow.PatientName = pPatientID & "  " & pPatientName
        frmBillCommentsShow.lblInfo.Text = "Patient: " & pPatientName
        frmBillCommentsShow.TextBox1.Text = txtPatientComments.Text
        frmBillCommentsShow.MinimizeBox = False
        frmBillCommentsShow.MaximizeBox = False
        frmBillCommentsShow.ShowDialog(Me)
        frmBillCommentsShow.Dispose()
    End Sub

    Private Sub txtPatientComments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        ToolStripButtonPatientComments_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButtonBillRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonBillRequests.Click, ToolStripMenuItemRequest.Click
        Dim LI As ListViewItem
        If pBillID = 0 Then
            MsgBox("Unable to create Billing request. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        With LI
            frmBillingAddRequest.lblMsg.Text = "Patient: " & pPatientName & "   Bill #: " & pBillID
            frmBillingAddRequest.BillAttorney = pAttorney
            frmBillingAddRequest.BillInsurance = pInsurance
            frmBillingAddRequest.BillID = pBillID
            frmBillingAddRequest.PatientID = pPatientID
            frmBillingAddRequest.MinimizeBox = False
            frmBillingAddRequest.MaximizeBox = False
            frmBillingAddRequest.ShowDialog(Me)
            frmBillingAddRequest.Dispose()
            Load_Requests(pBillID)
        End With
        MDIForm1Win8.TimerRefresh_Tick(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonDocuments.Click

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

    Private Sub ListViewDocs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewDocs.SelectedIndexChanged
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim MyFile As IO.FileInfo
        gHighlightListviewItem(ListViewDocs, True, False)
        If ListViewDocs.SelectedItems.Count = 0 Then
            pdfViewer.CloseDocument()
            Exit Sub
        End If
        ListViewDocs.Enabled = False
        PanelDocumentWait.Visible = True
        PanelDocumentWait.BringToFront()
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
                        ListViewDocs.Enabled = True
                        PanelDocumentWait.Visible = False
                        Cursor = Cursors.Default
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

    Private Sub ShowDocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowDocumentToolStripMenuItem.Click
        ToolStripButton4_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        ToolStripButtonBillRequests_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButtonAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonAction.Click, ToolStripMenuItemAction.Click
        If pBillID = 0 Then
            MsgBox("Unable to add notes. No Bill Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        frmAddCommentBilling.Label1.Text &= "  BILL: " & pBillID & "  PATIENT: " & pPatientID & "  " & pPatientName.ToUpper
        frmAddCommentBilling.BillID = pBillID
        If frmAddCommentBilling.ShowDialog = Windows.Forms.DialogResult.OK Then
            Find_Reminders()
            Load_Actions(pBillID)
        End If
        frmAddCommentBilling.Dispose()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        ToolStripButtonAction_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        ToolStripButtonPatientComments_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButtonShowBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonShowBill.Click
        Dim ParentNode As TreeNode
        If TreeViewBills.Nodes.Count = 0 Then Exit Sub
        ParentNode = TreeViewBills.SelectedNode
        If ParentNode Is Nothing Then Exit Sub
        If Not ParentNode.Parent Is Nothing Then
            ParentNode = ParentNode.Parent
        End If
        If Not ParentNode.Parent Is Nothing Then
            ParentNode = ParentNode.Parent
        End If
        If Not ParentNode.Parent Is Nothing Then
            ParentNode = ParentNode.Parent
        End If
        If Not ParentNode.Parent Is Nothing Then
            ParentNode = ParentNode.Parent
        End If
        If Not ParentNode.Parent Is Nothing Then
            ParentNode = ParentNode.Parent
        End If
        If Not ParentNode.Parent Is Nothing Then
            ParentNode = ParentNode.Parent
        End If

        Clear_Criterias()
        txtBillNumber.Text = CType(ParentNode.Tag, ValueDescription).Value
        ButtonFind_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonScannDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonScannDocument.Click
        If gScannerMode = 1 Then
            ScanDocumentFromScannerApplication(0)
        Else
            ScanDocumentFromScanner(0)

        End If
    End Sub

    Private Sub ScanDocumentFromScanner(ByVal DocProfileID As Integer)
        Dim PatientID As Long
        If pPatientID = 0 Then Exit Sub
        PatientID = pPatientID

        frmDocumentScannerPDF.IniDocProfile = DocProfileID
        frmDocumentScannerPDF.PatientID = PatientID
        frmDocumentScannerPDF.LoadListView = ListViewDocs
        If frmDocumentScannerPDF.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            gSQLUpdateData("UPDATE Documents set PatientID = " & PatientID & " where PatientID=0 and InsertedBy=" & gCurrentEmployee.EmpID)
            Load_Documents(PatientID)
        End If
        frmDocumentScannerPDF.Dispose()
    End Sub

    Private Sub ScanDocumentFromScannerApplication(ByVal DocProfileID As Integer)
        Dim PatientID As Long
        If pPatientID = 0 Then Exit Sub
        PatientID = pPatientID

        If gScannerFolder = "" Then
            MsgBox("Unable to scan. The Scanner Folder has not been specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If IO.Directory.Exists(gScannerFolder) = False Then
            MsgBox("Unable to scan. Invalid Scanner Folder specified." & vbCrLf & "Please call your system administrator.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        frmDocumentScannerExternalProgram.IniDocProfile = DocProfileID
        frmDocumentScannerExternalProgram.PatientID = PatientID
        frmDocumentScannerExternalProgram.LoadListView = ListViewDocs
        If frmDocumentScannerExternalProgram.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            gSQLUpdateData("UPDATE Documents set PatientID = " & PatientID & " where PatientID=0 and InsertedBy=" & gCurrentEmployee.EmpID)
            Load_Documents(PatientID)
        End If
        frmDocumentScannerExternalProgram.Dispose()
    End Sub

    Private Sub PopUpButtonAddAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopUpButtonAddAction.Click
        ToolStripButtonAction_Click(Nothing, Nothing)
    End Sub

    Private Sub PopUpMenuItemShowPatient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopUpMenuItemShowPatient.Click, ToolStripMenuItemPatient.Click
        If pPatientID = 0 Then
            MsgBox("Unable to open patient's information. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If SaveListView Is Nothing Then Exit Sub
        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.InitialPatientName = pPatientID
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            If NewFrm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim saveIndex As Integer = SaveListView.SelectedItems(0).Index
                If SaveListView Is ListViewReminders Then
                    TimerRefresh_Tick(Nothing, Nothing)
                Else
                    Find_Bills()
                End If
                If saveIndex <= SaveListView.Items.Count - 1 Then
                    SaveListView.Items(saveIndex).Selected = True
                    SaveListView.Items(saveIndex).EnsureVisible()
                End If
            End If
        End Using
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Dim BillID() As String = Nothing
        Dim I As Integer = 0
        Dim SaveCaseType As Integer
        If pBillID = 0 Then
            MsgBox("Unable to produce Bill. No bill selected. Please select a bill and try again.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        ReDim Preserve BillID(0)
        BillID(I) = pBillID
        SaveCaseType = pSaveCaseType
        frmNF3Report.Setup_report(BillID, SaveCaseType)
        frmNF3Report.MinimizeBox = False
        frmNF3Report.ShowDialog(Me)
        frmNF3Report.Dispose()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Dim BillsID() As String = Nothing
        Dim I As Integer = 0
        Dim T As ValueDescription
        If pBillID = 0 Then
            MsgBox("Unable to print envelope. No bill selected. Please check a bill and try again.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim LI As ListViewItem
        ReDim Preserve BillsID(0)
        BillsID(I) = pBillID
        frmBillingEnvelops.Setup_report(BillsID)
        frmBillingEnvelops.MinimizeBox = False
        frmBillingEnvelops.MaximizeBox = False

        frmBillingEnvelops.ShowDialog(Me)
        frmBillingEnvelops.Dispose()
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Dim BillIDs() As Long = Nothing
        Dim I As Integer = 0
        Dim LI As ListViewItem

        If pBillID = 0 Then
            MsgBox("Unable to process your request. No record checked.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        ReDim Preserve BillIDs(0)
        BillIDs(I) = pBillID
        frmReadingReport.Setup_report_ByBills(BillIDs, pPatientID)
        frmReadingReport.MinimizeBox = False
        frmReadingReport.MaximizeBox = False

        frmReadingReport.ShowDialog(Me)
        frmReadingReport.Dispose()
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        If pBillID = 0 Then
            MsgBox("Unable to print the Patient's File Label. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim intCounter As Integer
        Dim CR As ReportDocument
        Dim ConInfo As New TableLogOnInfo
        CR = New eMedicalOffice.rptPatientFileLabel
        If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
        CR.SetParameterValue("PatientID", pPatientID)
        If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gPrinterFileLabel
        CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 0, 0, 0))
        CR.PrintToPrinter(1, False, 0, 0)

        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem28.Click
        ToolStripButtonBillRequests_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem27.Click
        If pBillID > 0 Then
            frmBillingIndexNumber.txtInvoice.Text = pBillID
        End If
        frmBillingIndexNumber.Button2.Visible = False
        If frmBillingIndexNumber.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Find_Bills()
        End If
        frmBillingIndexNumber.Dispose()
    End Sub

    Private Sub TimerRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRefresh.Tick
        TimerRefresh.Interval = 100
        TimerRefresh.Enabled = False
        Find_Reminders()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Loading Or Loaded = False Then Exit Sub
        TimerRefresh.Enabled = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If Loading Or Loaded = False Then Exit Sub
        TimerRefresh.Enabled = True
    End Sub

    Private Sub cboCollector_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCollector.SelectedIndexChanged
        If Loading Or Loaded = False Then Exit Sub
        TimerRefresh.Enabled = True
    End Sub

    Private Sub ListViewReminders_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewReminders.DoubleClick
        If ListViewReminders.SelectedItems.Count > 0 Then
            ToolStripMenuActionComplete_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListViewReminders_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewReminders.GotFocus
        SaveListView = ListViewReminders
        ListViewReminders_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Dim SaveListView As ListView

    Private Sub ListViewReminders_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewReminders.ItemActivate

    End Sub

    Private Sub ListViewReminders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewReminders.SelectedIndexChanged
        Dim Reader As SqlClient.SqlDataReader

        If ListViewReminders.SelectedItems.Count = 0 Then
            Clear_Details()
            Exit Sub
        End If
        SaveListView = ListViewReminders
        pSaveCaseType = ListViewReminders.SelectedItems(0).SubItems(1).Tag
        Load_Details(Val(ListViewReminders.SelectedItems(0).Tag), Val(ListViewReminders.SelectedItems(0).SubItems(2).Text), ListViewReminders.SelectedItems(0).SubItems(3).Text)
        LastSelectedList = ListViewReminders

    End Sub

    Private Sub ListViewActions_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewActions.DoubleClick
        If ListViewActions.SelectedItems.Count > 0 Then
            ToolStripButton9_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListViewActions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewActions.SelectedIndexChanged
        ToolStripButtonComplete.Enabled = False
        ToolStripMenuActionComplete.Enabled = False
        If ListViewActions.SelectedItems.Count = 0 Then
            txtAction.Text = ""
            Exit Sub
        Else
            If IsDate(ListViewActions.SelectedItems(0).SubItems(2).Text) And ListViewActions.SelectedItems(0).SubItems(2).BackColor <> Color.LightSeaGreen Then
                ToolStripButtonComplete.Enabled = True
                ToolStripMenuActionComplete.Enabled = True
            End If
            txtAction.Text = ListViewActions.SelectedItems(0).Tag
        End If

    End Sub

    Private Sub ContextMenuStripMain_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripMain.Opening
        ToolStripReminderComplete.Visible = False
        ToolStripReminderSeparator.Visible = False
        'If Not ActiveControl Is Nothing Then
        If DirectCast(sender.SourceControl, ListView).SelectedItems.Count = 0 Then
            e.Cancel = True
            Exit Sub
        End If

        If sender.SourceControl Is ListViewReminders Then
            ToolStripReminderComplete.Visible = True
            ToolStripReminderSeparator.Visible = True
            ToolStripMenuFilterByAdjuster.Visible = False
        Else
            If ListViewPatients.SelectedItems.Count > 0 AndAlso ListViewPatients.SelectedItems(0).SubItems(12).Text <> "" Then
                ToolStripMenuFilterByAdjuster.Visible = True
            Else
                ToolStripMenuFilterByAdjuster.Visible = False
            End If
        End If
        'End If
    End Sub

    Private Sub ToolStripReminderComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripReminderComplete.Click
        If ListViewReminders.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No Bill Reminder Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If pBillID = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No Bill Reminder Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        frmAddCommentBilling.TextBoxReminder.Visible = True
        frmAddCommentBilling.TextBoxReminder.Text = ListViewReminders.SelectedItems(0).SubItems(4).Tag
        frmAddCommentBilling.TextBoxComment.Top = 167
        frmAddCommentBilling.TextBoxComment.Height = 124
        frmAddCommentBilling.ReminderID = ListViewReminders.SelectedItems(0).SubItems(5).Tag
        frmAddCommentBilling.Label1.Text = "REMINDER COMPLETE. BILL #:" & pBillID
        frmAddCommentBilling.Panel3.Visible = False
        frmAddCommentBilling.CheckBoxComplete.Visible = True
        frmAddCommentBilling.BillID = pBillID
        If frmAddCommentBilling.ShowDialog = Windows.Forms.DialogResult.OK Then
            Find_Reminders()
            Load_Actions(pBillID)
        End If
        frmAddCommentBilling.Dispose()
    End Sub

    Private Sub ContextMenuStripAction_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripAction.Opening
        ToolStripActionSeparator.Visible = False
        ToolStripMenuActionComplete.Visible = False
        If ListViewActions.SelectedItems.Count > 0 Then
            If IsDate(ListViewActions.SelectedItems(0).SubItems(2).Text) And ListViewActions.SelectedItems(0).SubItems(2).BackColor <> Color.LightSeaGreen Then
                ToolStripActionSeparator.Visible = True
                ToolStripMenuActionComplete.Visible = True
            End If
        End If
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        Dim C As Color
        If ListViewActions.SelectedItems.Count = 0 Then Exit Sub
        If txtAction.Text.Trim = "" Then Exit Sub
        frmBillCommentsShow.BillNumber = pBillID
        frmBillCommentsShow.PatientName = pPatientID & "  " & pPatientName
        frmBillCommentsShow.lblInfo.Text = "Bill #: " & pBillID & "    Patient: " & pPatientID & "  " & pPatientName
        If IsDate(ListViewActions.SelectedItems(0).SubItems(2).Text) Then
            C = ListViewActions.SelectedItems(0).SubItems(2).BackColor
            Select Case C
                Case Color.LightSalmon
                    frmBillCommentsShow.Label1.Text = "PAST INCOMPLETE FOLLOW UP REMINDER: " & ListViewActions.SelectedItems(0).SubItems(2).Text
                    frmBillCommentsShow.Label1.ForeColor = Color.Red
                Case Color.Gold
                    frmBillCommentsShow.Label1.Text = "FUTURE FOLLOW UP REMINDER: " & ListViewActions.SelectedItems(0).SubItems(2).Text
                    frmBillCommentsShow.Label1.ForeColor = Color.DarkOrange
                Case Color.LightSeaGreen
                    frmBillCommentsShow.Label1.Text = "COMPLETE FOLLOW UP REMINDER: " & ListViewActions.SelectedItems(0).SubItems(2).Text
                    frmBillCommentsShow.Label1.ForeColor = Color.DarkOrange
            End Select
        End If
        frmBillCommentsShow.TextBox1.Text = txtAction.Text
        frmBillCommentsShow.MinimizeBox = False
        frmBillCommentsShow.MaximizeBox = False

        frmBillCommentsShow.ShowDialog(Me)
        frmBillCommentsShow.Dispose()
    End Sub

    Private Sub ToolStripMenuActionComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuActionComplete.Click
        If ListViewActions.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No Reminder Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        frmAddCommentBilling.TextBoxReminder.Visible = True
        frmAddCommentBilling.TextBoxReminder.Text = ListViewActions.SelectedItems(0).Tag
        frmAddCommentBilling.TextBoxComment.Top = 167
        frmAddCommentBilling.TextBoxComment.Height = 124
        frmAddCommentBilling.BillID = pBillID
        frmAddCommentBilling.ReminderID = ListViewActions.SelectedItems(0).SubItems(2).Tag
        frmAddCommentBilling.Label1.ForeColor = Color.DarkRed
        frmAddCommentBilling.Label1.Text = "REMINDER COMPLETE. BILL #:" & pBillID & "    /    CREATE FOLLOWUP"
        'frmAddCommentBilling.CompleteInd = True
        frmAddCommentBilling.Panel3.Visible = False
        frmAddCommentBilling.CheckBoxComplete.Visible = True
        If frmAddCommentBilling.ShowDialog = Windows.Forms.DialogResult.OK Then
            Find_Reminders()
            Load_Actions(pBillID)
        End If
        frmAddCommentBilling.Dispose()
    End Sub

    Private Sub ToolStripButtonComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonComplete.Click
        ToolStripMenuActionComplete_Click(Nothing, Nothing)
    End Sub

    Public PaymentScanCheck As Boolean

    Private Sub mnuSelectedBillPayment1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectedBillPayment1.Click
        Dim BillID As Long
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""
        Dim LI As ListViewItem
        Dim SelectedLI As ListViewItem
        Dim PaidAmount As Double
        If LastSelectedList Is Nothing Then Exit Sub
        If pBillID = 0 Then
            MsgBox("Unable to process. No bills selected.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        SelectedLI = LastSelectedList.SelectedItems(0)
        Dim PatID As Long

        BillID = pBillID
        PatID = pPatientID
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
            Dim NoMoreCollection As Integer
            If frmAddPayment.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                PaidAmount = gSQLGetSingleValue("SELECT PaidAmount From Bills Where BillID=" & BillID)
                BillAmount = gSQLGetSingleValue("SELECT BillAmount From Bills Where BillID=" & BillID)
                NoMoreCollection = gSQLGetSingleValue("SELECT NoMoreCollection From Bills Where BillID=" & BillID)

                Load_Payments(BillID)
                If LastSelectedList Is ListViewReminders Then
                    SelectedLI.SubItems(8).Text = "Paid"
                    SelectedLI.SubItems(8).Tag = 3
                    SelectedLI.SubItems(8).BackColor = Color.LightGreen
                    SelectedLI.SubItems(10).Text = PaidAmount.ToString("c")
                    SelectedLI.SubItems(11).Text = (BillAmount - PaidAmount).ToString("c")
                Else
                    SelectedLI.SubItems(6).Text = "Paid"
                    SelectedLI.SubItems(6).Tag = 3
                    SelectedLI.SubItems(6).BackColor = Color.LightGreen
                    SelectedLI.SubItems(8).Text = PaidAmount.ToString("c")
                    SelectedLI.SubItems(9).Text = (BillAmount - PaidAmount).ToString("c")
                End If
            End If
            frmAddPayment.Dispose()
            Application.DoEvents()
            If PaymentScanCheck Then
                If gScannerMode = 1 Then
                    ScanDocumentFromScannerApplication(5)
                Else
                    ScanDocumentFromScanner(5)
                End If
            End If
            If NoMoreCollection = 1 Then
                If MsgBox("The selected bill has been set as [No More Collection]." & vbCrLf & "Remove it from collection list?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    LastSelectedList.Items.Remove(SelectedLI)
                    Clear_Details()
                End If
            End If
        End With
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CollectionStatisticsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectionStatisticsToolStripMenuItem.Click
        Application.DoEvents()
        frmCollectionStatistic.ShowDialog(Me)
        frmCollectionStatistic.Dispose()
    End Sub

    Private Sub frmBillingCollection_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ToolStripButtonCloseForm.Visible = Me.WindowState = FormWindowState.Maximized
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Height = PanelDetails.Height - ListViewDetails.Height
        TabControl1.Dock = DockStyle.Fill
    End Sub

    Private Sub frmBillingCollection_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ToolStripButtonCloseForm.Visible = Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripButtonCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCloseForm.Click
        Me.Close()
    End Sub

    Private Sub ToolStrip2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStrip2.DoubleClick
        Return
        gCustomizeToolStrip(ToolStrip2, Me)
    End Sub

    Private Sub ToolStrip2_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub

    Private Sub CustomizeToolbarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomizeToolbarToolStripMenuItem.Click
        gCustomizeToolStrip(ToolStrip2, Me)
        gToolStripSettings(Me, ToolStrip2, ReadWrite.sWrite)
    End Sub

    Private Sub TimerLoadData_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLoadData.Tick

    End Sub

    Private Sub ToolStripMenuUpdateAdjusterInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuUpdateAdjusterInformation.Click
        If pPatientID = 0 Then
            MsgBox("Unable to open patient's information. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim LI As ListViewItem
        If SaveListView Is Nothing Then Exit Sub
        frmBillingChangeAdjusterInformation.pPatientID = pPatientID
        If SaveListView Is ListViewReminders Then
            frmBillingChangeAdjusterInformation.txtAdjuster.Text = ListViewReminders.SelectedItems(0).SubItems(14).Text
            frmBillingChangeAdjusterInformation.txtAdjusterPhone.Text = ListViewReminders.SelectedItems(0).SubItems(15).Text
            If frmBillingChangeAdjusterInformation.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ListViewReminders.SelectedItems(0).SubItems(14).Text = frmBillingChangeAdjusterInformation.txtAdjuster.Text
                ListViewReminders.SelectedItems(0).SubItems(15).Text = frmBillingChangeAdjusterInformation.txtAdjusterPhone.Text
                For Each LI In ListViewPatients.Items
                    If Val(LI.SubItems(0).Text) = pPatientID Then
                        LI.SubItems(12).Text = ListViewReminders.SelectedItems(0).SubItems(14).Text
                        LI.SubItems(13).Text = ListViewReminders.SelectedItems(0).SubItems(15).Text
                    End If
                Next

            End If
            frmBillingChangeAdjusterInformation.Close()
            frmBillingChangeAdjusterInformation.Dispose()
        Else
            frmBillingChangeAdjusterInformation.txtAdjuster.Text = ListViewPatients.SelectedItems(0).SubItems(12).Text
            frmBillingChangeAdjusterInformation.txtAdjusterPhone.Text = ListViewPatients.SelectedItems(0).SubItems(13).Text
            If frmBillingChangeAdjusterInformation.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ListViewPatients.SelectedItems(0).SubItems(12).Text = frmBillingChangeAdjusterInformation.txtAdjuster.Text
                ListViewPatients.SelectedItems(0).SubItems(13).Text = frmBillingChangeAdjusterInformation.txtAdjusterPhone.Text
                For Each LI In ListViewReminders.Items
                    If Val(LI.SubItems(2).Text) = pPatientID Then
                        LI.SubItems(14).Text = ListViewPatients.SelectedItems(0).SubItems(12).Text
                        LI.SubItems(15).Text = ListViewPatients.SelectedItems(0).SubItems(13).Text
                    End If
                Next
            End If
            frmBillingChangeAdjusterInformation.Close()
            frmBillingChangeAdjusterInformation.Dispose()
        End If
    End Sub

    Private Sub ToolStripMenuFilterByAdjuster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuFilterByAdjuster.Click
        Dim SaveAdjuster As String = txtAdjuster.Text
        If ListViewPatients.SelectedItems.Count > 0 AndAlso ListViewPatients.SelectedItems(0).SubItems(12).Text <> "" Then
            txtAdjuster.Text = ListViewPatients.SelectedItems(0).SubItems(12).Text
            Find_Bills()
            txtAdjuster.Text = SaveAdjuster
        End If
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
            BillID(I) = ListViewPatients.SelectedItems(0).Tag
            SavePatientID = ListViewPatients.SelectedItems(0).Text
        Else
            For Each LI In ListViewPatients.CheckedItems
                If SavePatientID <> 0 And SavePatientID <> Val(LI.Text) Then
                    MsgBox("Unable to print the Itemized Charges Report." & vbCrLf & "The bills for the different patient's can not be included into the same Itemized Charges Report.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                SavePatientID = LI.Text
                ReDim Preserve BillID(I)
                BillID(I) = LI.Tag
                I = I + 1
            Next
        End If

        frmItemizedCharges.Setup_report(BillID, SavePatientID)
        frmItemizedCharges.MinimizeBox = False
        frmItemizedCharges.MaximizeBox = False
        Application.DoEvents()
        frmItemizedCharges.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripFontIncrease.Click, ToolStripFontIncrease.DoubleClick
        SetFont(1)
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripFonrDecrease.Click, ToolStripFonrDecrease.DoubleClick
        SetFont(-1)
    End Sub

    Private Sub mnuPrintBillProgress_Click(sender As Object, e As EventArgs) Handles mnuPrintBillProgress.Click
        Print_SelectedPatientProgress()
    End Sub

    Private Sub Print_SelectedPatientProgress()
        Dim BillID As Long = Nothing
        Dim I As Integer = 0
        Dim LI As ListViewItem

        If ListViewPatients.SelectedItems.Count = 0 And ListViewReminders.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No records checked.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        'BillID = CType(ListViewPatients.SelectedItems(0).Tag, ValueDescription).Value
        frmPatientInforBilling.BillID = pBillID
        frmPatientInforBilling.MinimizeBox = False
        frmPatientInforBilling.MaximizeBox = False
        Application.DoEvents()
        frmPatientInforBilling.ShowDialog(Me)
        frmPatientInforBilling.Dispose()
    End Sub

    Private Sub Load_BillToPatients(BillID As Integer)
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

    End Sub

    Private Sub BillToPatientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillToPatientToolStripMenuItem.Click
        Dim BillID As Long
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to print. No bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        BillID = pBillID
        frmBillToPatient.BillId = BillID
        frmBillToPatient.MinimizeBox = False
        frmBillToPatient.MaximizeBox = False
        frmBillToPatient.ShowDialog(Me)
        frmBillToPatient.Dispose()
        If MessageBox.Show(Me, "Will you send this bill to the patient?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = DialogResult.No Then
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

        Load_Actions(BillID)
    End Sub

    Private Sub ToolStripButtonDetach_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDetach.Click
        ListViewPatients.Focus()
        ToolStripButtonDetach.Image = gDetachAttachWindow(Me, MDIForm1Win8)
    End Sub

    Private Sub frmBillingCollection_ParentChanged(sender As Object, e As EventArgs) Handles MyBase.ParentChanged
        If MdiParent Is Nothing Then
            PanelTop.Visible = True
        Else
            PanelTop.Visible = False

        End If
        Application.DoEvents()
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
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

        frm.BillID = ListViewPatients.SelectedItems(0).Tag
        frm.PatientID = ListViewPatients.SelectedItems(0).Text
        frm.calledForm = Me
        If frm.ShowDialog(Me) = DialogResult.OK Then
            Load_Documents(ListViewPatients.SelectedItems(0).Text)
        End If
        frm.Dispose()
        frm = Nothing

    End Sub

    Private Sub ToolStripButton5_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        ToolStripMenuItem17_Click(Nothing, Nothing)
    End Sub

    Private Sub TimerGetReminderDetails_Tick(sender As Object, e As EventArgs) Handles TimerGetReminderDetails.Tick
        TimerGetReminderDetails.Enabled = False
        If ListViewReminders.Items.Count > 0 Then
            ListViewReminders.Items(0).Selected = True
            ListViewReminders.Items(0).EnsureVisible()
            ListViewReminders_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub

    Private Sub cboAttorneysCompanyID_MouseDown(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub DateTimePickerFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePickerFrom.KeyDown, txtAdjuster.KeyDown, DateTimePickerTo.KeyDown, cboInsuranceCompanyID.KeyDown, cboDays.KeyDown, cboBillStatus.KeyDown, cboAttorneysCompanyID.KeyDown, ButtonFind.KeyDown, txtPatient.KeyDown, txtBillNumber.KeyDown
        If e.KeyCode = 13 Then
            ButtonFind_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListViewDenials_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewDenials.SelectedIndexChanged
        txtDenialComments.Text = ""
        If ListViewDenials.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        txtDenialComments.Text = ListViewDenials.SelectedItems(0).SubItems(2).Text
    End Sub

End Class