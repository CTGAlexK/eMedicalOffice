Public Class frmBillingSearch
    Private loadingind As Boolean
    Private m_SortingColumn As ColumnHeader
    Private s_SortingColumn As ColumnHeader
    Private KeyDn As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonFind.Click
        If txtPatient.Text.Trim.Length = 0 And txtBillNumber.Text.Trim.Length = 0 And txtClaimNumber.Text.Trim.Length = 0 And txtPolicyNumber.Text.Trim.Length = 0 And DateTimePickerFrom.Checked = False And DateTimePickerTo.Checked = False And cboInsuranceCompanyID.SelectedIndex < 2 And cboBillingProvider.SelectedIndex < 1 Then
            MsgBox("Unable to process your request." & vbCrLf & "No search criteria specified.", MsgBoxStyle.Exclamation, "Oops")
            Return
        End If
        PanelSearch.Enabled = False
        If Not LastSelectedList Is Nothing AndAlso LastSelectedList Is ListViewFound Then Clear_Details()
        Dim Li As ListViewItem
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SQL As String = ""
        Dim PName() As String
        lblSearch.Text = "Search in progress. Please wait..."
        Application.DoEvents()
        lblSearch.Refresh()
        ListViewFound.Items.Clear()
        SQL = "SELECT Bills.BillAmount, Patients.PatientID,  Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS pName, Bills.BillID, Bills.ClaimNumber, InsuranceCompanies.CompanyName as Insurance, CaseTypes.Abbreviation as CaseType"
        SQL &= " FROM Bills with(nolock) INNER JOIN Patients with(nolock) On Bills.PatientID = Patients.PatientID LEFT OUTER JOIN InsuranceCompanies with(nolock) On Bills.InsCompanyID = InsuranceCompanies.CompanyID INNER JOIN CaseTypes with(nolock) On Bills.CaseTypeID = CaseTypes.CaseTypeID   "
        SQL &= " WHERE Bills.BillStatusID <> 13 "   ' Never show Replicated Bills
        txtPatient.Text = txtPatient.Text.Trim.ToSafeSQLString()
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
        If txtBillNumber.Text.Trim <> "" Then
            SQL &= " And Bills.BillID = " & Val(txtBillNumber.Text)
        End If
        If txtClaimNumber.Text.Trim <> "" Then
            SQL &= " And (REPLACE(Bills.ClaimNumber,' ','') Like '" & txtClaimNumber.Text.Trim.ToSafeSQLString() & "%' or Bills.ClaimNumber Like '" & txtClaimNumber.Text.Trim.ToSafeSQLString() & "%' )"
        End If
        If txtPolicyNumber.Text.Trim <> "" Then
            SQL &= " And (REPLACE(Bills.PolicyNumber,' ','') like '" & txtBillNumber.Text.Trim.ToSafeSQLString() & "%' or Bills.PolicyNumber like '" & txtBillNumber.Text.Trim.ToSafeSQLString() & "%' ) "
        End If



        If DateTimePickerFrom.Checked Then
            SQL &= " and DATEDIFF(d, Bills.BillDate, '" & DateTimePickerFrom.Value.Date & "')<=0  "
        End If
        If DateTimePickerTo.Checked Then
            SQL &= " and DATEDIFF(d, Bills.BillDate, '" & DateTimePickerTo.Value.Date & "')>=0 "
        End If
        If cboInsuranceCompanyID.SelectedIndex > 0 Then
            If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value1 = "0" Then
                SQL &= " AND Bills.InsCompanyID in (Select CompanyID From InsuranceCompanies Where GroupID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & ") "
            Else
                SQL &= " AND Bills.InsCompanyID = " & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & " "
            End If
        End If
        If cboCaseTypeID.SelectedIndex > 0 Then
            SQL &= " AND Bills.CaseTypeID = " & CType(cboCaseTypeID.SelectedItem, ValueDescription).Value & " "
        Else
            SQL &= " AND Bills.CaseTypeID <> 4"
        End If
        If cboBillingProvider.SelectedIndex > 0 Then
            SQL &= " AND Bills.BillingProviderID = " & CType(cboBillingProvider.SelectedItem, ValueDescription).Value & " "
        End If

        ListViewFound.BeginUpdate()
        If CheckBoxNetSearch.Checked Then
            Dim offices = New List(Of Office)
            For Each office In gOffices
                lblSearch.Text = "Search in progress [" & office.OfficeName & "]. Please wait..."
                lblSearch.Refresh()
                If office.ConnectionString <> "" Then
                    Reader = gSQLGetDataReader(SQL, office.ConnectionString)
                    Do Until Reader.Read = False
                        Li = ListViewFound.Items.Add("K" & Reader("BillID").ToString, Reader("PatientID").ToString, "")
                        With Li
                            .Tag = Reader("BillID").ToString
                            Dim lvsi = .SubItems.Add(Reader("PName").ToString)
                            lvsi.Tag = office.ConnectionString
                            .SubItems.Add(Reader("BillID").ToString)
                            .SubItems.Add(Val(Reader("BillAmount").ToString()).ToString("####0.00"))
                            .SubItems.Add(Reader("ClaimNumber").ToString)
                            .SubItems.Add(Reader("Insurance").ToString)
                            .SubItems.Add(Reader("CaseType").ToString)
                            .SubItems.Add(office.OfficeName)
                            If gOfficeName <> office.OfficeName Then
                                .ForeColor = Color.Red
                                .UseItemStyleForSubItems = True
                            End If
                        End With
                    Loop
                    Reader.Close()


                End If
            Next
        Else
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                Li = ListViewFound.Items.Add("K" & Reader("BillID").ToString, Reader("PatientID").ToString, "")
                With Li
                    .Tag = Reader("BillID").ToString
                    Dim lvsi = .SubItems.Add(Reader("PName").ToString)
                    lvsi.Tag = gConnectionString
                    .SubItems.Add(Reader("BillID").ToString)
                    .SubItems.Add(Val(Reader("BillAmount").ToString()).ToString("####0.00"))
                    .SubItems.Add(Reader("ClaimNumber").ToString)
                    .SubItems.Add(Reader("Insurance").ToString)
                    .SubItems.Add(Reader("CaseType").ToString)
                    .SubItems.Add(gOfficeName)
                End With
            Loop

        End If
        PanelSearch.Enabled = True
        ListViewFound.EndUpdate()
        lblSearch.Text = "Found: " & ListViewFound.Items.Count
        Reader.Close()
    End Sub

    Private Sub cboInsuranceCompanyID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboInsuranceCompanyID.SelectedIndexChanged
        If cboInsuranceCompanyID.SelectedIndex > -1 Then
            If CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value = -1 Then
                cboInsuranceCompanyID.SelectedIndex = 0
            End If
        End If
    End Sub
    Private Sub Setup_Comboboxes()
        AddHandler cboInsuranceCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboInsuranceCompanyID.Leave, AddressOf sSearchComboBox_Leave
    End Sub

    Private Sub frmBillingSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadingind = True
        Dim ConnectionsCount As Integer = gOffices.Where(Function(x) x.ConnectionString <> "").Count()
        If ConnectionsCount > 1 And
            (gCurrentEmployee.PositionID < 5 Or gCurrentEmployee.PositionID = 6 Or gCurrentEmployee.PositionID = 110) Then
            CheckBoxNetSearch.Visible = True
        End If
        Load_Data()
        Setup_Comboboxes()
        m_SortingColumn = ListViewFound.Columns(1)
        s_SortingColumn = ListViewSelected.Columns(1)
        loadingind = False
        Load_Insurances()
    End Sub
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        cboCaseTypeID.Items.Clear()
        cboCaseTypeID.Items.Add(New ValueDescription("0", "All (Not Cash)"))
        Reader = gSQLGetDataReader("Select CaseTypeID, Description from CaseTypes")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboCaseTypeID.Items.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)), Reader("Description").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboCaseTypeID.SelectedIndex = 0
        cboBillingProvider.Items.Clear()
        cboBillingProvider.Items.Add(New ValueDescription("0", "All"))
        Reader = gSQLGetDataReader("SELECT     EmpID, Fname+' '+Lname+' '+ Alias as DName From Employees WHERE (BillingPrv = 1) and EmpID in (select EmpID from EmployeeOffice where OfficeID=" & gOfficeID & ")")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboBillingProvider.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("DName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboBillingProvider.SelectedIndex = 0
ExitSub:
        Cursor = Cursors.Default
    End Sub
    Private Sub Load_Insurances()
        If loadingind = True Then Exit Sub
        Dim Reader As SqlClient.SqlDataReader


        With cboInsuranceCompanyID
            .Items.Clear()
            .Items.Add(New ValueDescription(0, "All"))
            .Items.Add(New ValueDescription(-1, "-----------------------------------------INSURANCE GROUPS-----------------------------------------"))
            .SelectedIndex = 0
            .DropDownHeight = 106
            Cursor = Cursors.WaitCursor
            Application.DoEvents()
            .SelectedIndex = 0
            If cboCaseTypeID.SelectedItem Is Nothing OrElse CType(cboCaseTypeID.SelectedItem, ValueDescription).Value = 0 Then
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
            If cboCaseTypeID.SelectedItem Is Nothing OrElse CType(cboCaseTypeID.SelectedItem, ValueDescription).Value = 0 Then
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
        cboInsuranceCompanyID.SelectedIndex = 0
ExitSub:
        Cursor = Cursors.Default
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListViewFound.SelectedItems.Count = 0 Then Return
        Dim lvi As ListViewItem = ListViewFound.SelectedItems(0)

        If lvi.ForeColor = Color.Red Then
            MsgBox("Unable to add bill from another office to bills selection.", MsgBoxStyle.Exclamation, "Oops")
            Return
        End If
        Panel2.Enabled = False
        Panel5.Enabled = False
        PanelSearch.Enabled = False

        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        ListViewFound.BeginUpdate()
        ListViewSelected.BeginUpdate()
        Dim Li As ListViewItem = ListViewSelected.Items.Add(lvi.Text)
        With Li
            .Tag = lvi.Tag
            Dim lvsi = .SubItems.Add(lvi.SubItems(1).Text)
            lvsi.Tag = lvi.SubItems(1).Tag
            .SubItems.Add(lvi.SubItems(2).Text)
            .SubItems.Add(lvi.SubItems(3).Text)
            .SubItems.Add(lvi.SubItems(4).Text)
            .SubItems.Add(lvi.SubItems(5).Text)
            .SubItems.Add(lvi.SubItems(6).Text)
            .SubItems.Add(lvi.SubItems(7).Text)
            Li.Selected = True
            Li.EnsureVisible()
        End With
        ListViewFound.Items.Remove(lvi)
        ListViewFound.EndUpdate()
        ListViewSelected.EndUpdate()
        Cursor = Cursors.Default
        Panel2.Enabled = True
        Panel5.Enabled = True
        PanelSearch.Enabled = True

        Application.DoEvents()
        LabelSelected.Text = "Selected: " & ListViewSelected.Items.Count
        lblSearch.Text = "Found: " & ListViewFound.Items.Count
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ListViewFound.Items.Count = 0 Then Return
        Cursor = Cursors.WaitCursor
        Panel2.Enabled = False
        Panel5.Enabled = False
        PanelSearch.Enabled = False

        Application.DoEvents()
        ListViewFound.BeginUpdate()
        ListViewSelected.BeginUpdate()
        For Each lvi As ListViewItem In ListViewFound.Items
            If lvi.ForeColor <> Color.Red Then
                Dim Li As ListViewItem = ListViewSelected.Items.Add(lvi.Text)
                With Li
                    .Tag = lvi.Tag
                    Dim lvsi = .SubItems.Add(lvi.SubItems(1).Text)
                    lvsi.Tag = lvi.SubItems(1).Tag
                    .SubItems.Add(lvi.SubItems(2).Text)
                    .SubItems.Add(lvi.SubItems(3).Text)
                    .SubItems.Add(lvi.SubItems(4).Text)
                    .SubItems.Add(lvi.SubItems(5).Text)
                    .SubItems.Add(lvi.SubItems(6).Text)
                    .SubItems.Add(lvi.SubItems(7).Text)
                End With
                ListViewFound.Items.Remove(lvi)
            End If
        Next
        ListViewFound.EndUpdate()
        ListViewSelected.EndUpdate()
        Cursor = Cursors.Default
        Panel2.Enabled = True
        Panel5.Enabled = True
        PanelSearch.Enabled = True

        Application.DoEvents()
        LabelSelected.Text = "Selected: " & ListViewSelected.Items.Count
        lblSearch.Text = "Found: " & ListViewFound.Items.Count
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ListViewSelected.SelectedItems.Count = 0 Then Return
        Cursor = Cursors.WaitCursor
        Panel2.Enabled = False
        Panel5.Enabled = False
        PanelSearch.Enabled = False

        Application.DoEvents()
        ListViewFound.BeginUpdate()
        ListViewSelected.BeginUpdate()
        Dim lvi As ListViewItem = ListViewSelected.SelectedItems(0)
        Dim Li As ListViewItem = ListViewFound.Items.Add(lvi.Text)
        With Li
            .Tag = lvi.Tag
            Dim lvsi = .SubItems.Add(lvi.SubItems(1).Text)
            lvsi.Tag = lvi.SubItems(1).Tag
            .SubItems.Add(lvi.SubItems(2).Text)
            .SubItems.Add(lvi.SubItems(3).Text)
            .SubItems.Add(lvi.SubItems(4).Text)
            .SubItems.Add(lvi.SubItems(5).Text)
            .SubItems.Add(lvi.SubItems(6).Text)
            .SubItems.Add(lvi.SubItems(7).Text)
            Li.Selected = True
            Li.EnsureVisible()
        End With
        ListViewSelected.Items.Remove(lvi)
        ListViewFound.EndUpdate()
        ListViewSelected.EndUpdate()
        Cursor = Cursors.Default
        Panel2.Enabled = True
        Panel5.Enabled = True
        PanelSearch.Enabled = True

        Application.DoEvents()
        LabelSelected.Text = "Selected: " & ListViewSelected.Items.Count
        lblSearch.Text = "Found: " & ListViewFound.Items.Count
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ListViewSelected.Items.Count = 0 Then Return
        Cursor = Cursors.WaitCursor
        Panel2.Enabled = False
        Panel5.Enabled = False
        PanelSearch.Enabled = False

        Application.DoEvents()
        ListViewFound.BeginUpdate()
        ListViewSelected.BeginUpdate()
        For Each lvi As ListViewItem In ListViewSelected.Items
            Dim Li As ListViewItem = ListViewFound.Items.Add(lvi.Text)
            With Li
                .Tag = lvi.Tag
                Dim lvsi = .SubItems.Add(lvi.SubItems(1).Text)
                lvsi.Tag = lvi.SubItems(1).Tag
                .SubItems.Add(lvi.SubItems(2).Text)
                .SubItems.Add(lvi.SubItems(3).Text)
                .SubItems.Add(lvi.SubItems(4).Text)
                .SubItems.Add(lvi.SubItems(5).Text)
                .SubItems.Add(lvi.SubItems(6).Text)
                .SubItems.Add(lvi.SubItems(7).Text)
            End With
        Next
        ListViewSelected.Items.Clear()
        ListViewFound.EndUpdate()
        ListViewSelected.EndUpdate()
        Cursor = Cursors.Default
        Panel2.Enabled = True
        Panel5.Enabled = True
        PanelSearch.Enabled = True

        Application.DoEvents()
        LabelSelected.Text = "Selected: " & ListViewSelected.Items.Count
        lblSearch.Text = "Found: " & ListViewFound.Items.Count
    End Sub

    Private Sub ListViewFound_DoubleClick(sender As Object, e As EventArgs) Handles ListViewFound.DoubleClick
        Button2_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewSelected_DoubleClick(sender As Object, e As EventArgs) Handles ListViewSelected.DoubleClick
        Button4_Click(Nothing, Nothing)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        txtPatient.Text = ""
        txtBillNumber.Text = ""
        txtClaimNumber.Text = ""
        txtPolicyNumber.Text = ""
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        cboInsuranceCompanyID.SelectedIndex = 0
        cboCaseTypeID.SelectedIndex = 0
        cboBillingProvider.SelectedIndex = 0
    End Sub

    Private Sub cmdShow_Click(sender As Object, e As EventArgs) Handles cmdShow.Click
        If ListViewSelected.Items.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No bills selected.", MsgBoxStyle.Exclamation, "Oops")
            Return
        End If
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub frmBillingSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

    End Sub

    Private Sub frmBillingSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cboCaseTypeID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCaseTypeID.SelectedIndexChanged
        Load_Insurances()
    End Sub

    Private Sub ListViewFound_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewFound.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewFound.Columns(e.Column)
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
        ListViewFound.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewFound.Sort()
    End Sub

    Private Sub ListViewSelected_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewSelected.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewSelected.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If s_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(s_SortingColumn) Then
                ' Same column. Switch the sort order.

                'If s_SortingColumn.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If s_SortingColumn.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            's_SortingColumn.Text =             s_SortingColumn.Text.Mid(2)
            s_SortingColumn.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        s_SortingColumn = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        's_SortingColumn.Text = "> " & s_SortingColumn.Text
        'Else
        's_SortingColumn.Text = "< " & s_SortingColumn.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            s_SortingColumn.ImageKey = "SORT1"
        Else
            s_SortingColumn.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewSelected.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewSelected.Sort()
    End Sub
    Private Sub Clear_Details()
        Dim I As Integer
        FpSpreadDetails_Sheet1.RowCount = 14
        For I = 0 To FpSpreadDetails_Sheet1.RowCount - 1
            FpSpreadDetails_Sheet1.Cells(I, 0).ForeColor = Color.Black
            FpSpreadDetails_Sheet1.Cells(I, 1).ForeColor = Color.Black
            FpSpreadDetails_Sheet1.SetText(I, 1, "")
            FpSpreadDetails_Sheet1.SetRowHeight(I, CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight))
        Next
        LabelOffice.Text = "Office:"
        LabelOffice.ForeColor = Color.Black
    End Sub
    Private Sub CheckBoxNetSearch_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxNetSearch.CheckedChanged
        LabelMsg.Visible = CheckBoxNetSearch.Checked
    End Sub
    Public Sub Show_Details(ByVal ID As Long, billid As Integer, connectionstring As String, office As String)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim lCell As String
        Dim I As Integer
        Dim SPHeight As Integer
        If connectionstring = "" Then
            Exit Sub
        End If
        LabelOffice.Text = "Office:            " & office.ToUpper
        If gOfficeName <> office Then
            LabelOffice.ForeColor = Color.Red
        Else
            LabelOffice.ForeColor = Color.Black
        End If
        SQL = "SELECT PolicyNumber,ClaimNumber,SSN, CaseTypes.Description as CaseType, Patients.DOA, Patients.PatientID,  Patients.FName, Patients.MI, Patients.LName, Patients.DOB, Patients.Phone1, Patients.Phone2, Patients.CellPhone, Patients.Address1, Patients.Address2, Patients.City, Patients.State, Patients.Zip, "
        SQL = SQL & " Patients.ReferringDoctor, ReferringOffices.OfficeName AS ReferringCompany, ReferringOffices.Phone1 AS RefPhone1, ReferringOffices.Phone2 AS RefPhone2, ReferringOffices.Phone3 AS RefPhone3, Patients.Comments "
        SQL = SQL & " FROM Patients with(nolock) LEFT OUTER JOIN ReferringOffices with(nolock) ON Patients.ReferringCompanyID = ReferringOffices.OfficeID Inner Join CaseTypes with(nolock) on Patients.CaseTypeID = CaseTypes.CaseTypeID "
        SQL = SQL & " WHERE Patients.PatientID = " & ID
        Reader = gSQLGetDataReader(SQL.ToString(), connectionstring)
        SPHeight = FpSpreadDetails.Height
        If Reader Is Nothing Then GoTo ExitSub
        Panel3.SuspendLayout()
        FpSpreadDetails.ShowRow(FpSpreadDetails.GetActiveRowViewportIndex, 0, FarPoint.Win.Spread.VerticalPosition.Top)

        With FpSpreadDetails_Sheet1

            Do Until Reader.Read = False
                .SetText(0, 1, Reader("PatientID").ToString)

                If IsDate(Reader("DOB").ToString) Then
                    .SetText(1, 1, CDate(Reader("DOB").ToString).ToString("MM/dd/yyyy"))
                End If

                If IsDate(Reader("DOA").ToString) Then
                    .SetText(2, 1, CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy"))
                End If
                .SetText(3, 1, Reader("PolicyNumber").ToString)
                .SetText(4, 1, Reader("ClaimNumber").ToString)
                .SetText(5, 1, Reader("SSN").ToString)
                .SetText(6, 1, Reader("Phone1").ToString)
                .SetText(7, 1, Reader("CellPhone").ToString)
                .SetText(8, 1, Reader("Phone2").ToString)
                .SetText(9, 1, Reader("Address1").ToString & " " & Reader("Address2").ToString & vbCrLf & IIf(Reader("City").ToString <> "", Reader("City").ToString, "").ToString & IIf(Reader("State").ToString <> "", ", " & Reader("State").ToString, "").ToString & IIf(Replace(Reader("Zip").ToString, "_", "") <> "", ", " & Reader("Zip").ToString, "").ToString & vbCrLf & "  ")
                Dim BillingProvider As String = gSQLGetSingleValueString("Select Employees.Fname + ' ' + Employees.Lname + Char(10) + Alias + Char(10) + Char(10) as bName from bills  inner join Employees on EmpID = BillingProviderID where bills.billid = " & billid)
                .SetText(10, 1, BillingProvider)

                lCell = Reader("ReferringCompany").ToString
                lCell = lCell & IIf(Reader("RefPhone1").ToString <> "" And Reader("RefPhone1").ToString <> "", vbCrLf & Reader("RefPhone1").ToString, "").ToString
                lCell = lCell & IIf(Reader("RefPhone2").ToString <> "" And Reader("RefPhone2").ToString <> "", vbCrLf & Reader("RefPhone2").ToString, "").ToString
                lCell = lCell & IIf(Reader("RefPhone3").ToString <> "" And Reader("RefPhone3").ToString <> "", vbCrLf & Reader("RefPhone3").ToString, "").ToString
                lCell = lCell & IIf(Reader("ReferringDoctor").ToString <> "", vbCrLf & Reader("ReferringDoctor").ToString, "").ToString
                .SetText(11, 1, lCell)
                .SetText(13, 1, Reader("Comments").ToString)
                SPHeight = 0
                For I = 0 To .RowCount - 1
                    .SetRowHeight(I, CInt(.Rows(I).GetPreferredHeight))
                Next
            Loop
        End With

ExitSub:
        Panel3.ResumeLayout(True)
    End Sub
    Private LastSelectedList As ListView
    Private Sub ListViewFound_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewFound.SelectedIndexChanged

        FpSpreadDetails.SuspendLayout()
        Clear_Details()
        If ListViewFound.SelectedItems.Count = 0 Then Return
        LastSelectedList = ListViewFound
        Dim lvi As ListViewItem = ListViewFound.SelectedItems(0)
        If KeyDn = False Then
            Show_Details(lvi.Text, lvi.Tag, lvi.SubItems(1).Tag, lvi.SubItems(7).Text)
        End If
        FpSpreadDetails.ResumeLayout()

    End Sub

    Private Sub ListViewSelected_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewSelected.SelectedIndexChanged
        FpSpreadDetails.SuspendLayout()
        Clear_Details()
        If ListViewSelected.SelectedItems.Count = 0 Then Return
        LastSelectedList = ListViewSelected
        Dim lvi As ListViewItem = ListViewSelected.SelectedItems(0)
        If KeyDn = False Then
            Show_Details(lvi.Text, lvi.Tag, lvi.SubItems(1).Tag, lvi.SubItems(7).Text)
        End If
        FpSpreadDetails.ResumeLayout()
    End Sub

    Private Sub ListViewFound_Enter(sender As Object, e As EventArgs) Handles ListViewFound.Enter
        FpSpreadDetails.SuspendLayout()
        Clear_Details()
        If ListViewFound.SelectedItems.Count = 0 Then Return
        LastSelectedList = ListViewFound
        Dim lvi As ListViewItem = ListViewFound.SelectedItems(0)
        Show_Details(lvi.Text, lvi.Tag, lvi.SubItems(1).Tag, lvi.SubItems(7).Text)
        FpSpreadDetails.ResumeLayout()
    End Sub

    Private Sub ListViewSelected_Enter(sender As Object, e As EventArgs) Handles ListViewSelected.Enter
        FpSpreadDetails.SuspendLayout()
        Clear_Details()
        If ListViewSelected.SelectedItems.Count = 0 Then Return
        LastSelectedList = ListViewSelected
        Dim lvi As ListViewItem = ListViewSelected.SelectedItems(0)
        Show_Details(lvi.Text, lvi.Tag, lvi.SubItems(1).Tag, lvi.SubItems(7).Text)
        FpSpreadDetails.ResumeLayout()
    End Sub

    Private Sub ListViewFound_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewFound.KeyDown
        If e.KeyCode = 40 Or e.KeyCode = 38 Then
            KeyDn = True
        End If
    End Sub

    Private Sub ListViewSelected_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewSelected.KeyDown
        If e.KeyCode = 40 Or e.KeyCode = 38 Then
            KeyDn = True
        End If
    End Sub

    Private Sub ListViewFound_KeyUp(sender As Object, e As KeyEventArgs) Handles ListViewFound.KeyUp
        If e.KeyCode = 40 Or e.KeyCode = 38 Then
            KeyDn = False
            ListViewFound_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListViewSelected_KeyUp(sender As Object, e As KeyEventArgs) Handles ListViewSelected.KeyUp
        If e.KeyCode = 40 Or e.KeyCode = 38 Then
            KeyDn = False
            ListViewSelected_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub
End Class