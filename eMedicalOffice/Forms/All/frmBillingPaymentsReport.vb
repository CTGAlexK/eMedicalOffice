Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports log4net

Public Class frmBillingPaymentsReport
    Private Loading As Boolean
    Private SkipCal As Boolean
    Private SkipDays As Boolean
    Private m_SortingColumn As ColumnHeader
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmBillingManagement_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting(My.Application.Info.ProductName, "Settings", "BillingDateFrom", DateTimePickerFrom.Value)
        SaveSetting(My.Application.Info.ProductName, "Settings", "BillingDateTo", DateTimePickerTo.Value)
        SaveSetting(My.Application.Info.ProductName, "Settings", "BillingManagementCaseType", cboCaseTypeID.SelectedIndex)
        gListview_Settings(Me, ListViewPatients, ReadWrite.sWrite)
        Dispose()
    End Sub

    Private Sub frmBillingManagement_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            ButtonFind_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub frmBillingManagement_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmBillingManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        DateTimePickerFrom.Value = GetSetting(My.Application.Info.ProductName, "Settings", "BillingDateFrom", DateAdd(DateInterval.Day, -7, Now.Date))
        DateTimePickerTo.Value = GetSetting(My.Application.Info.ProductName, "Settings", "BillingDateTo", Now.Date)
        DateTimePickerFrom.MaxDate = Now.Date
        DateTimePickerTo.MaxDate = Now.Date

        Application.DoEvents()
        m_SortingColumn = ListViewPatients.Columns(1)
        Loading = True
        Load_Data()
        Setup_Comboboxes()
        Loading = False
        gListview_Settings(Me, ListViewPatients, ReadWrite.sRead)
        Count_Selected()
    End Sub

    Private Sub Setup_Comboboxes()
        AddHandler cboInsuranceCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboInsuranceCompanyID.Leave, AddressOf sSearchComboBox_Leave
        AddHandler cboAttorneysCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboAttorneysCompanyID.Leave, AddressOf sSearchComboBox_Leave

        AddHandler cboCaseTypeID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboCaseTypeID.Leave, AddressOf sSearchComboBox_Leave

        AddHandler cboBillingCompany.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboBillingCompany.Leave, AddressOf sSearchComboBox_Leave

    End Sub

    Private Sub Load_Data()
        Dim I As Integer = 0
        Dim Reader As SqlClient.SqlDataReader
        Try
            cboCaseTypeID.Items.Clear()
            cboCaseTypeID.Items.Add(New ValueDescription("0", "All"))
            Reader = gSQLGetDataReader("Select CaseTypeID, Description from CaseTypes Where CaseTypeID <> 4")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboCaseTypeID.Items.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)), Reader("Description").ToString))
            Loop
            Reader.Close() : Reader.Dispose()
            Dim AttotneyInd As Boolean = False
            cboBillingProvider.Items.Clear()
            cboBillingProvider.Items.Add(New ValueDescription("0", "All"))
            Reader = gSQLGetDataReader("SELECT     EmpID, Fname+' '+Lname+' '+ Alias as DName From Employees WHERE     (BillingPrv = 1) and EmpID in (select EmpID from EmployeeOffice where OfficeID=" & gOfficeID & ")")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboBillingProvider.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("DName").ToString))
            Loop
            Reader.Close() : Reader.Dispose()
            cboAttorneysCompanyID.Items.Clear()
            cboAttorneysCompanyID.Items.Add(New ValueDescription("0", "All"))
            Reader = gSQLGetDataReader("Select CompanyID, CompanyName, AttorneyFName+' '+AttorneyLName as AttorneyName from Attorneys Where OfficeID=" & gOfficeID)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboAttorneysCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString & " - " & Reader("AttorneyName").ToString))
            Loop
            Reader.Close() : Reader.Dispose()

            cboBillingCompany.Items.Clear()
            cboBillingCompany.Items.Add(New ValueDescription("-1", "All"))
            Reader = gSQLGetDataReader("SELECT     BillingCompanyID, CompanyName FROM         BillingCompanies ORDER BY CompanyName")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                cboBillingCompany.Items.Add(New ValueDescription(CLng(Val(Reader("BillingCompanyID").ToString)), Reader("CompanyName").ToString))
            Loop
            Reader.Close() : Reader.Dispose()
            Reader = Nothing
            cboCaseTypeID.SelectedIndex = CInt(GetSetting(My.Application.Info.ProductName, "Settings", "BillingManagementCaseType", "0"))
            cboAttorneysCompanyID.SelectedIndex = 0
            cboBillingProvider.SelectedIndex = 0
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        txtSearch.Text = ""
        DateTimePickerAttorneyFrom.Checked = False
        DateTimePickerAttorneyTo.Checked = False
        cboAttorneysCompanyID.SelectedIndex = 0
        cboBillingProvider.SelectedIndex = 0
        cboCaseTypeID.SelectedIndex = 0
        cboInsuranceCompanyID.SelectedIndex = 0
        cboBillingCompany.SelectedIndex = 0
        ListViewPatients.Items.Clear()
        txtBillNumber.Text = ""
        Count_Selected()
        ListViewPatients.Focus()
    End Sub

    Public Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        ButtonFind.Enabled = False
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        ListViewPatients.BeginUpdate()
        Find_Patients()
        ListViewPatients.EndUpdate()
        ButtonFind.Enabled = True
        Cursor = Cursors.Default
        ListViewPatients.Focus()
    End Sub

    Private Sub Find_Patients()
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""
        Dim Li As ListViewItem
        Dim SI As ListViewItem.ListViewSubItem
        Dim SISTATUS As ListViewItem.ListViewSubItem
        ListViewPatients.Items.Clear()

        SQL = "SELECT (SELECT COUNT(RequestID) AS C FROM BillingRequests WHERE BillID = Bills.BillID and RequestStatusID < 3) as Requests,(Bills.BillAmount-isnull(Bills.PaidAmount,0)) as Balance, Bills.AttorneyCaseNumber, Bills.PaidAmount, Bills.POMID, Bills.BillStatusID, Bills.CopyFromBillID, CaseTypes.CaseTypeID, CaseTypes.Description as CaseType, Patients.PatientID,  Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS pName, Patients.DOA, Bills.ServiceFrom , Bills.ServiceTo, Bills.BillID, Bills.BillDate, Bills.PolicyNumber, Bills.ClaimNumber, Bills.BillAmount, BillStatus.Description as BillStatus, InsuranceCompanies.AcceptanceID, InsuranceCompanies.CompanyName as Insurance, Attorneys.CompanyName AS Attorney, Bills.AttorneyDate, Bills.AttorneyCompanyID,  Employees.Fname + ' ' + Employees.Lname AS Doctor, Bills.Adjuster, Bills.DenialFound "
        SQL &= " FROM Bills Bills INNER JOIN Employees ON Bills.TreatingProviderID = Employees.EmpID INNER JOIN CaseTypes on Bills.CaseTypeID = CaseTypes.CaseTypeID INNER JOIN Patients ON Bills.PatientID = Patients.PatientID INNER JOIN BillStatus ON Bills.BillStatusID = BillStatus.BillStatusID INNER JOIN InsuranceCompanies ON Bills.InsCompanyID = InsuranceCompanies.CompanyID LEFT OUTER JOIN Attorneys ON Bills.AttorneyCompanyID = Attorneys.CompanyID "

        SQL &= " WHERE Bills.OfficeID = " & gOfficeID & " "

        ' Search Criterias
        txtSearch.Text = txtSearch.Text.Trim

        If IsNumeric(txtBillNumber.Text) Then
            SQL &= " AND (Bills.BillID = " & Val(txtBillNumber.Text) & " or Bills.AttorneyCaseNumber = " & Val(txtBillNumber.Text) & " or Bills.ClaimNumber like '" & txtBillNumber.Text.Trim.ToSafeSQLString() & "%' or Bills.PolicyNumber like '" & txtBillNumber.Text.Trim.ToSafeSQLString() & "%') "
        Else
            If txtSearch.Text <> "" Then
                If IsNumeric(txtSearch.Text) Then
                    SQL &= " AND Patients.PatientID = " & Val(txtSearch.Text) & " "
                Else
                    SQL &= " AND (Patients.FName Like '" & txtSearch.Text.ToSafeSQLString() & "%' or Patients.LName Like '" & txtSearch.Text.ToSafeSQLString() & "%') "
                End If
            End If

            If DateTimePickerAttorneyFrom.Enabled And DateTimePickerAttorneyFrom.Checked Then
                SQL &= " and DATEDIFF(d, Bills.AttorneyDate, '" & DateTimePickerAttorneyFrom.Value.Date & "')<=0 "
            End If

            If DateTimePickerAttorneyTo.Enabled And DateTimePickerAttorneyTo.Checked Then
                SQL &= " and DATEDIFF(d, Bills.AttorneyDate, '" & DateTimePickerAttorneyTo.Value.Date & "')>=0 "
            End If

            SQL &= " and (DATEDIFF(d, Bills.BillDate, '" & DateTimePickerFrom.Value.Date & "')<=0 and DATEDIFF(d, Bills.BillDate, '" & DateTimePickerTo.Value.Date & "')>=0) "

            If cboCaseTypeID.SelectedIndex > 0 Then
                SQL &= " AND Bills.CaseTypeID = " & CType(cboCaseTypeID.SelectedItem, ValueDescription).Value & " "
            End If

            If cboInsuranceCompanyID.SelectedIndex > 0 Then
                SQL &= " AND Bills.InsCompanyID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & " "
            End If
            If cboAttorneysCompanyID.SelectedIndex > 0 Then
                SQL &= " AND Bills.AttorneyCompanyID = " & CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Value & " "
            End If

            If cboBillingProvider.SelectedIndex > 0 Then
                SQL &= " AND Bills.BillingProviderID = " & CType(cboBillingProvider.SelectedItem, ValueDescription).Value & " "
            End If
        End If

        '
        SQL &= " ORDER BY pName, BillID "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Loading = True
        ListViewPatients.BeginUpdate()
        ListViewPatients.ListViewItemSorter = Nothing
        Do Until Reader.Read = False
            Li = ListViewPatients.Items.Add("K" & Reader("BillID").ToString, Reader("PatientID").ToString, "")
            Li.ToolTipText = "Bill Status: " & Reader("BillStatus").ToString
            Li.UseItemStyleForSubItems = False
            Li.Tag = New ValueDescription(Reader("BillID").ToString, "", Reader("PatientID").ToString)
            Li.SubItems.Add(Reader("PName").ToString)
            If IsDate(Reader("DOA")) Then Li.SubItems.Add(CDate(Reader("DOA")).ToString("MM/dd/yyyy")) Else Li.SubItems.Add("")
            Li.SubItems.Add(Reader("CaseType").ToString)
            'If Val(Reader("CaseTypeID").ToString) <> Val(Reader("CaseTypeID1").ToString) Then
            ' Li.BackColor = Color.Red
            'End If

            If IsNumeric(Reader("CopyFromBillID").ToString) Then
                Li.ToolTipText &= "This bill has been reproduced from the bill number: " & Reader("CopyFromBillID").ToString
                Li.SubItems.Add(Reader("BillID").ToString & "R")
            Else
                Li.SubItems.Add(Reader("BillID").ToString)
            End If

            If IsDate(Reader("BillDate")) Then Li.SubItems.Add(CDate(Reader("BillDate")).ToString("MM/dd/yyyy")) Else Li.SubItems.Add("")
            Li.SubItems.Add(Reader("PolicyNumber").ToString)
            Li.SubItems.Add(Reader("ClaimNumber").ToString)
            Li.SubItems.Add(Val(Reader("BillAmount").ToString))

            'If Reader("Attorney").ToString <> "" Then
            'SISTATUS = Li.SubItems.Add("Attorney")
            'Else
            SISTATUS = Li.SubItems.Add(Reader("BillStatus").ToString)
            'End If
            SISTATUS.Tag = Val(Reader("BillStatusID").ToString)
            SI = Li.SubItems.Add(Reader("Insurance").ToString)
            SI.Tag = Reader("AcceptanceID").ToString
            Select Case Val(Reader("AcceptanceID").ToString)
                Case 1
                    SI.BackColor = Color.Pink
                Case 2
                    SI.BackColor = Color.Red
            End Select
            If IsDate(Reader("ServiceFrom").ToString) And IsDate(Reader("ServiceTo")) Then
                Li.SubItems.Add(CDate(Reader("ServiceFrom")).ToString("MM/dd/yy") & " - " & CDate(Reader("ServiceTo")).ToString("MM/dd/yy"))
            Else
                Li.SubItems.Add("")
            End If
            SI = Li.SubItems.Add(Reader("Attorney").ToString)
            SI.Tag = Reader("AttorneyCompanyID").ToString
            If IsDate(Reader("AttorneyDate")) Then Li.SubItems.Add(CDate(Reader("AttorneyDate")).ToString("MM/dd/yyyy")) Else Li.SubItems.Add("")
            If Val(Reader("POMID").ToString) > 0 Then
                SI = Li.SubItems.Add(Reader("POMID").ToString)
                If Val(Reader("BillStatusID").ToString) = 1 Then
                    SI.Text &= "P"
                    SI.BackColor = Color.Gold
                    SI.Tag = "POM Pending"
                    Li.ToolTipText &= vbCrLf & "POM Pending"
                Else
                    SI.Tag = "Mailed"
                End If
            Else
                Li.SubItems.Add("")
            End If
            Li.SubItems.Add(Val(Reader("PaidAmount").ToString))
            Li.SubItems.Add(Val(Reader("Balance").ToString))
            Li.SubItems.Add(Reader("Doctor").ToString)
            If Val(Reader("DenialFound").ToString) = 1 Then
                gSetListItemColor(Li, Color.PaleGoldenrod)
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
                Case 4, 5
                    'gSetListItemColor(Li, Color.Orange)
                    SISTATUS.BackColor = Color.Orange
                Case 6, 7
                    'gSetListItemColor(Li, Color.Red)
                    SISTATUS.BackColor = Color.Red
                Case 8
                    'gSetListItemColor(Li, Color.Gainsboro)
                    SISTATUS.BackColor = Color.Gainsboro
            End Select
            If Val(Reader("POMID").ToString) > 0 Then
                If Val(Reader("BillStatusID").ToString) = 1 Then
                    SI.BackColor = Color.Gold
                End If
            End If
            Li.SubItems.Add(Reader("Adjuster").ToString)
            Li.SubItems.Add(Reader("AttorneyCaseNumber").ToString)
            SI = Li.SubItems.Add(Reader("Requests").ToString)
            If Val(Reader("Requests").ToString) > 0 Then
                SI.BackColor = Color.Gold
            End If

        Loop
        Loading = False
        If ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
            ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
        End If
        Count_Selected()
        ListViewPatients.EndUpdate()
    End Sub

    Private Sub cboCaseTypeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaseTypeID.SelectedIndexChanged
        cboInsuranceCompanyID.Items.Clear()
        cboInsuranceCompanyID.Items.Add(New ValueDescription(0, "All"))
        cboInsuranceCompanyID.SelectedIndex = 0
        cboInsuranceCompanyID.DropDownHeight = 106
        Dim Reader As SqlClient.SqlDataReader
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        If CType(cboCaseTypeID.SelectedItem, ValueDescription).Value = 0 Then
            Reader = gSQLGetDataReader("Select CompanyID, CompanyName from InsuranceCompanies ORDER BY CompanyName")
        Else
            Reader = gSQLGetDataReader("Select CompanyID, CompanyName from InsuranceCompanies Where CaseTypeID =" & CType(cboCaseTypeID.SelectedItem, ValueDescription).Value & " ORDER BY CompanyName")
        End If
        If Reader Is Nothing Then GoTo ExitSub
        Do Until Reader.Read = False
            cboInsuranceCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString))
        Loop
        If cboInsuranceCompanyID.Items.Count = 0 Then
            cboInsuranceCompanyID.DropDownHeight = 20
        End If
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
        If CheckUncheck Then Exit Sub
        ToolStripStatusLabelFound.Text = " Found: " & ListViewPatients.Items.Count & "   "
        ToolStripStatusLabelChecked.Text = " Checked: " & ListViewPatients.CheckedItems.Count & "   "
        If ListViewPatients.Items.Count > 0 Then
            If ListViewPatients.Items(0).SubItems.Count > 0 Then
                For I = 0 To ListViewPatients.Items.Count - 1
                    T = T + CDbl(ListViewPatients.Items(I).SubItems(8).Text)
                    P = P + +CDbl(ListViewPatients.Items(I).SubItems(15).Text)
                    If ListViewPatients.Items(I).Checked Then
                        Tc = Tc + CDbl(ListViewPatients.Items(I).SubItems(8).Text)
                        PC = PC + +CDbl(ListViewPatients.Items(I).SubItems(15).Text)
                    End If
                Next
            End If
        End If
        ToolStripLabelTotal.Text = " All Total: " & T.ToString("c") & "   "
        ToolStripLabelCheched.Text = " Checked Total: " & Tc.ToString("c") & "   "
        ToolStripLabelPaidFound.Text = " All Paid: " & P.ToString("c") & "   "
        ToolStripStatusLabelPaidChecked.Text = " Checked Paid: " & PC.ToString("c") & "   "
    End Sub

    Private CheckUncheck As Boolean

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim LI As ListViewItem
        CheckUncheck = True
        ListViewPatients.BeginUpdate()
        For Each LI In ListViewPatients.Items
            LI.Checked = True
        Next
        ListViewPatients.EndUpdate()
        CheckUncheck = False
        Count_Selected()
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            ListViewPatients.Columns(e.ColumnIndex).Width = 60
        End If
    End Sub

    Private Sub ListViewPatients_ColumnWidthChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles ListViewPatients.ColumnWidthChanging

    End Sub

    Private Sub ListViewPatients_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewPatients.ItemCheck

    End Sub

    Private Sub ListViewPatients_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListViewPatients.ItemChecked
        If Loading Then Exit Sub
        Count_Selected()
    End Sub

    Public SelectedInsCompanyIndex As Integer

    Private Sub ListViewPatients_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewPatients.MouseDown
        Application.DoEvents()
        Dim HI As ListViewHitTestInfo
        HI = ListViewPatients.HitTest(e.X, e.Y)

        If Not HI.Item Is Nothing Then
            HI.Item.Selected = True
            HI.Item.EnsureVisible()
        End If
    End Sub

    Private Sub ListViewPatients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewPatients.SelectedIndexChanged
        If ListViewPatients.SelectedItems.Count = 0 Then
            Exit Sub
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Print_Listview(Optional ByVal All As Boolean = True)
        Dim CH As ColumnHeader = Nothing
        Dim LI As ListViewItem
        Dim I As Integer
        Dim C As Integer
        Dim C1
        If ListViewPatients.Items.Count = 0 Then
            MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        FpSpreadForPrint.ActiveSheet.ColumnCount = ListViewPatients.Columns.Count
        For C = 0 To ListViewPatients.Columns.Count - 1
            For C1 = 0 To ListViewPatients.Columns.Count - 1
                If ListViewPatients.Columns(C1).DisplayIndex = C Then
                    CH = ListViewPatients.Columns(C1)
                    Exit For
                End If
            Next
            I += 1
            'FpSpread1.ActiveSheet.Columns(I - 1).CellType = CT
            FpSpreadForPrint.ActiveSheet.ColumnHeader.Rows(0).Height = 32
            Select Case CH.TextAlign
                Case HorizontalAlignment.Left
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                Case HorizontalAlignment.Right
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                Case HorizontalAlignment.Center
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            End Select
            FpSpreadForPrint.ActiveSheet.Columns(I - 1).Tag = CH.Index
            FpSpreadForPrint.ActiveSheet.Columns(I - 1).Width = CH.Width
            Select Case CH.Text
                Case "Patient #"
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).Label = "##"
                Case "Amt $"
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).Label = "Amt"
                Case "Paid Amt $"
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).Label = "Paid"
                Case "Balance $"
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).Label = "Balance"
                Case Else
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).Label = CH.Text
            End Select

        Next
        I = 0
        FpSpreadForPrint.ActiveSheet.RowCount = 0
        For Each LI In ListViewPatients.Items
            If All = True Or LI.Checked = True Then
                I += 1
                FpSpreadForPrint.ActiveSheet.RowCount = I
                For C = 0 To FpSpreadForPrint.ActiveSheet.ColumnCount - 1
                    FpSpreadForPrint.ActiveSheet.SetText(I - 1, C, LI.SubItems(FpSpreadForPrint.ActiveSheet.Columns(C).Tag).Text)
                Next
            End If
        Next
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
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
        FpSpreadForPrint.ActiveSheet.PrintInfo = Printinfo
        FpSpreadForPrint.PrintSheet(FpSpreadForPrint.ActiveSheet)
    End Sub

    Private Sub mnuPrintAll1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintAll1.Click
        Print_Listview(True)
    End Sub

    Private Sub mnuPrintCheckedOnly1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintCheckedOnly1.Click
        Print_Listview(False)
    End Sub

    Private Sub mnuPrinting2_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPrinting2.DropDownOpening
        If ListViewPatients.Items.Count = 0 Then
            mnuPrintAll1.Visible = False
        Else
            mnuPrintAll1.Visible = True
        End If
        If ListViewPatients.CheckedItems.Count = 0 Then
            mnuPrintCheckedOnly1.Visible = False
        Else
            mnuPrintCheckedOnly1.Visible = True
        End If
    End Sub

    Private Sub RestoreColumnWidthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
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
        FpSpreadForPrint.ActiveSheet.RowCount = 0
        FpSpreadForPrint.ActiveSheet.RowCount = 1
        FpSpreadForPrint.ActiveSheet.ColumnCount = ListViewPatients.Columns.Count
        For C = 0 To ListViewPatients.Columns.Count - 1
            For C1 = 0 To ListViewPatients.Columns.Count - 1
                If ListViewPatients.Columns(C1).DisplayIndex = C Then
                    CH = ListViewPatients.Columns(C1)
                    Exit For
                End If
            Next
            I += 1
            FpSpreadForPrint.ActiveSheet.ColumnHeader.Rows(0).Height = 32
            Select Case CH.TextAlign
                Case HorizontalAlignment.Left
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                Case HorizontalAlignment.Right
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                Case HorizontalAlignment.Center
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            End Select
            FpSpreadForPrint.ActiveSheet.Columns(I - 1).Tag = CH.Index
            FpSpreadForPrint.ActiveSheet.Columns(I - 1).Width = CH.Width
            FpSpreadForPrint.ActiveSheet.Columns(I - 1).Locked = False
            FpSpreadForPrint.ActiveSheet.SetText(0, I - 1, CH.Text)
        Next
        I = 1

        For Each LI In ListViewPatients.Items
            If All = True Or LI.Checked = True Then
                I += 1
                FpSpreadForPrint.ActiveSheet.RowCount = I
                For C = 0 To FpSpreadForPrint.ActiveSheet.ColumnCount - 1
                    FpSpreadForPrint.ActiveSheet.SetText(I - 1, C, LI.SubItems(FpSpreadForPrint.ActiveSheet.Columns(C).Tag).Text.ToString)
                Next
            End If
        Next
        FpSpreadForPrint.ActiveSheet.Protect = False
        Try
            FpSpreadForPrint.SaveExcel(strFileName)
        Catch ex As Exception
            MsgBox("Unable to save file. the file may be in use by another application or drive is full or write protected.", MsgBoxStyle.Critical)
        End Try
        FpSpreadForPrint.ActiveSheet.RowCount = 0
        FpSpreadForPrint.ResumeLayout()
        SaveFD.Reset()
        System.Diagnostics.Process.Start(strFileName)
        Cursor = Cursors.Default
    End Sub

    Private Sub ExportAllToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportAllToExcelToolStripMenuItem.Click
        Export_Listview()
    End Sub

    Private Sub ExportCheckedToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportCheckedToExcelToolStripMenuItem.Click
        Export_Listview(False)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        gListViewRestoreDefaultColumnWidth(ListViewPatients)
    End Sub

End Class