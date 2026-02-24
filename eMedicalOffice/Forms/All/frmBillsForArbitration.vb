Imports System.Text
Imports System.IO
Imports System.Reflection
Imports log4net

Public Class frmBillsForArbitration
    Public AtterneyID As Integer
    Public AtterneyName As String
    Private m_SortingColumn As ColumnHeader
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub ScheduleSearchPopup_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            cboDays.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmBillsForArbitration_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)
        SaveSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SelectedDays", cboDays.SelectedIndex)
    End Sub

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
        gWindow_Settings(Me, ReadWrite.sRead)
        PanelShowBills.Visible = GetSetting(My.Application.Info.ProductName, "Settings", "BillingPatientBills", True)
        PanelBills.Visible = Not PanelShowBills.Visible
        If PanelBills.Visible = False Then
            ListView1.Width = 10000
        End If
        m_SortingColumn = ListView1.Columns(0)
        Load_Data()
    End Sub

    Private LoadingFlag As Boolean

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        LoadingFlag = True
        SQL = "SELECT     CompanyID, CompanyName FROM Attorneys WHERE OfficeID = 1 ORDER BY CompanyName"
        Reader = gSQLGetDataReader(SQL)

        cboAttorney.Items.Add(New ValueDescription(0, "All"))
        Do Until Reader.Read = False
            cboAttorney.Items.Add(New ValueDescription(Reader("CompanyID").ToString, Reader("CompanyName").ToString))
        Loop
        cboAttorney.SelectedIndex = 0
        For i As Integer = 1 To 45
            Select Case i
                Case 1, 21, 31, 41
                    cboDays.Items.Add(i & " Day")
                Case Else
                    cboDays.Items.Add(i & " Days")
            End Select
        Next
        cboDays.SelectedIndex = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SelectedDays", 29)

        With cboInsurance

            .Items.Clear()
            .Items.Add(New ValueDescription(0, "All"))
            .Items.Add(New ValueDescription(-1, "-----------------------------------------INSURANCE GROUPS-----------------------------------------"))
            .SelectedIndex = 0
            .DropDownHeight = 106
            Cursor = Cursors.WaitCursor
            Application.DoEvents()
            Reader = gSQLGetDataReader("SELECT DISTINCT InsuranceCompaniesGroups.GroupID, InsuranceCompaniesGroups.Description FROM InsuranceCompaniesGroups INNER JOIN InsuranceCompanies ON InsuranceCompaniesGroups.GroupID = InsuranceCompanies.GroupID Where CaseTypeID =1 ORDER BY InsuranceCompaniesGroups.Description")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                .Items.Add(New ValueDescription(CLng(Val(Reader("GroupID").ToString)), Reader("Description").ToString & " - Group", "0"))
            Loop
            If .Items.Count > 0 Then
                .Items.Add(New ValueDescription(-1, "--------------------------------------INSURANCE COMPANIES--------------------------------------"))
            End If
            Reader = gSQLGetDataReader("Select CompanyID, CompanyName from InsuranceCompanies Where CaseTypeID =1 ORDER BY CompanyName")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                .Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString, "1"))
            Loop
            If .Items.Count = 0 Then
                .DropDownHeight = 20
            End If
        End With
        Reader.Close() : Reader.Dispose()
        cboInsurance.DropDownWidth = 450
        cboAttorney.DropDownWidth = 250
        LoadingFlag = False
        Timer1.Enabled = True
    End Sub

    Private Sub Find_Data()
        Dim I As Integer = 0
        Dim Reader As SqlClient.SqlDataReader
        Dim dbDataSet As DataSet
        Dim LI As ListViewItem
        Dim SISTATUS As ListViewItem.ListViewSubItem
        Dim Amount As Double
        Dim SQL As String
        Dim Days As Integer
        Cursor = Cursors.WaitCursor
        If cboDays.SelectedIndex = -1 Then Exit Sub
        Application.DoEvents()
        Application.DoEvents()
        Days = cboDays.SelectedIndex + 1
        SQL = "SELECT DISTINCT Bills.AttorneyDate, Bills.BillAmount, Bills.BillStatusID, Patients.DOA, Patients.PatientID , Attorneys.CompanyName as Attorney, Patients.AdjusterName, Patients.AdjusterPhone, FName+' '+isnull(MI,'')+' '+isnull(LName,'')+' '+ISNULL(Suffix,'') as PatName, Patients.ClaimNumber, Patients.PolicyNumber, convert(varchar, Bills.ServiceFrom, 101)+' - '+ convert(varchar, Bills.ServiceTo, 101) as SvcDates , Bills.BillID, Description as BillStatus, convert(varchar, Bills.BillDate, 101) as BillDate, DATEDIFF(d,BillDate ,getdate()) as BillDays, convert(varchar, BillingRequests.StatusDate, 101)  as LastRequestStatusDT, DATEDIFF(d,StatusDate ,getdate()) as LastRequestStatusDays, InsuranceCompanies.CompanyName as Insurance, IndexNumber "
        SQL &= "        FROM Bills "
        SQL &= "        LEFT OUTER JOIN BillingRequests on Bills.BillID = BillingRequests.BillID "
        SQL &= "        LEFT OUTER JOIN InsuranceCompanies on Bills.InsCompanyID =InsuranceCompanies.CompanyID "
        SQL &= "        INNER JOIN BillStatus on Bills.BillStatusID = BillStatus.BillStatusID "
        SQL &= "        INNER JOIN Patients on Bills.PatientID = Patients.PatientID "
        SQL &= "        LEFT OUTER JOIN Attorneys on Bills.AttorneyCompanyID =Attorneys.OfficeID "
        SQL &= "        WHERE Bills.OfficeID = " & gOfficeID & " AND Bills.CaseTypeID =1 AND "
        SQL &= "        Bills.DenialFound = 0 AND "
        If cboAttorney.SelectedIndex > 0 Then
            SQL &= " Bills.AttorneyCompanyID = " & CType(cboAttorney.SelectedItem, ValueDescription).Value & " AND "
        End If

        If cboInsurance.SelectedIndex > 0 Then
            If CType(cboInsurance.SelectedItem, ValueDescription).Value1 = "0" Then
                SQL &= " Bills.InsCompanyID in (Select CompanyID From InsuranceCompanies Where GroupID = " & CType(cboInsurance.SelectedItem, ValueDescription).Value & ") AND "
            Else
                SQL &= " Bills.InsCompanyID = " & CType(cboInsurance.SelectedItem, ValueDescription).Value & " AND "
            End If
        End If
        SQL &= " (Bills.BillStatusID = 2 Or Bills.BillStatusID = 4 Or Bills.BillStatusID = 5) AND "
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
        SQL &= "        order by BillID "

        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ListView1.SuspendLayout()
        ListView1.BeginUpdate()
        ListView1.Items.Clear()
        ListView1.ListViewItemSorter = Nothing
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("PatientID").ToString)
            LI.UseItemStyleForSubItems = False
            LI.Tag = Reader("BillID").ToString
            LI.SubItems.Add(Reader("PatName").ToString)
            If IsDate(Reader("DOA").ToString) Then
                LI.SubItems.Add(CDate(Reader("DOA").ToString).ToShortDateString)
            Else
                LI.SubItems.Add("")
            End If
            LI.SubItems.Add(Reader("BillID").ToString)
            If IsDate(Reader("BillDate").ToString) Then
                LI.SubItems.Add(CDate(Reader("BillDate").ToString).ToShortDateString)
            Else
                LI.SubItems.Add("")
            End If
            LI.SubItems.Add(Reader("BillDays").ToString)
            SISTATUS = LI.SubItems.Add(Reader("BillStatus").ToString)
            SISTATUS.Tag = Reader("BillStatusID").ToString
            LI.SubItems.Add(CDbl(Reader("BillAmount").ToString).ToString("c"))
            Amount += CDbl(Reader("BillAmount").ToString)
            LI.SubItems.Add(Reader("SvcDates").ToString)
            LI.SubItems.Add(Reader("LastRequestStatusDT").ToString)
            LI.SubItems.Add(Reader("LastRequestStatusDays").ToString)
            LI.SubItems.Add(Reader("Insurance").ToString)
            LI.SubItems.Add(Reader("PolicyNumber").ToString)
            LI.SubItems.Add(Reader("ClaimNumber").ToString)
            LI.SubItems.Add(Reader("AdjusterName").ToString)
            LI.SubItems.Add(Reader("AdjusterPhone").ToString)
            LI.SubItems.Add(Reader("Attorney").ToString)
            If IsDate(Reader("AttorneyDate").ToString) Then
                LI.SubItems.Add(CDate(Reader("AttorneyDate").ToString).ToShortDateString)
            Else
                LI.SubItems.Add("")
            End If
            LI.SubItems.Add(Reader("IndexNumber").ToString)
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
                Case 8
                    'gSetListItemColor(Li, Color.Gainsboro)
                    SISTATUS.BackColor = Color.Red
                    SISTATUS.ForeColor = Color.White
            End Select
        Loop
        ToolStripLabelCount.Text = "Found: " & ListView1.Items.Count
        ToolStripLabelAmount.Text = "Amount: " & Amount.ToString("c")
        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
            ListView1_SelectedIndexChanged(Nothing, Nothing)
        End If
ExitSub:
        ListView1.EndUpdate()
        ListView1.ResumeLayout()
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub Setup_SearchComboBoxes()
        AddHandler cboDays.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboDays.Leave, AddressOf sSearchComboBox_Leave
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Find_Data()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim strFileName As String
        Dim sb As StringBuilder = New StringBuilder
        Dim CH As ColumnHeader

        SaveFD.Title = "Export Billing To Excel."
        SaveFD.Filter = "MS Excel File (*.xls)|*.xls"
        SaveFD.FileName = "BillsDesignatedForArbitration.xls"
        Dim DidWork As Integer = SaveFD.ShowDialog()
        If DidWork = DialogResult.OK Then
            strFileName = SaveFD.FileName
        Else
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        For Each CH In ListView1.Columns
            sb.Append(CH.Text + vbTab)
        Next
        sb.AppendLine()
        For Each lvi As ListViewItem In ListView1.Items
            For Each lvs As ListViewItem.ListViewSubItem In lvi.SubItems
                If lvs.Text = String.Empty Then
                    sb.Append(vbTab)
                Else
                    sb.Append(lvs.Text + vbTab)
                End If
            Next
            sb.AppendLine()
        Next
        Try
            Dim Sw As New StreamWriter(strFileName)
            Sw.Write(sb.ToString)
            Sw.Close()
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try

        Cursor = Cursors.Default
        Application.DoEvents()
    End Sub

    Private Sub ToolStripButton7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Application.DoEvents()
        gListViewRestoreDefaultColumnWidth(ListView1)
    End Sub

    Private Sub cboDays_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDays.SelectedIndexChanged
        If cboDays.SelectedIndex = -1 Then Exit Sub
        If LoadingFlag = True Then Exit Sub
        Timer1.Enabled = True
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim LI As ListViewItem
        ListView1.BeginUpdate()
        ListView1.SuspendLayout()
        For Each LI In ListView1.Items
            LI.Checked = True
        Next
        ListView1.ResumeLayout()
        ListView1.EndUpdate()
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNoneToolStripMenuItem.Click
        Dim LI As ListViewItem
        ListView1.BeginUpdate()
        ListView1.SuspendLayout()
        For Each LI In ListView1.Items
            LI.Checked = False
        Next
        ListView1.ResumeLayout()
        ListView1.EndUpdate()

    End Sub

    Private Sub mnuPrintCheckedBills3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintCheckedBills3.Click
        Dim BillID() As String = Nothing
        Dim I As Integer = 0
        Dim SaveCaseType As Integer
        If ListView1.CheckedItems.Count = 0 And ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to produce Bill. No bills checked / selected. Please check the bill(s) and try again.", MsgBoxStyle.Critical)
            ListView1.Focus()
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim LI As ListViewItem
        If ListView1.CheckedItems.Count = 0 Then
            ReDim Preserve BillID(0)
            BillID(I) = Val(ListView1.SelectedItems(0).Tag)
            SaveCaseType = 1
        Else
            SaveCaseType = 1
            For Each LI In ListView1.CheckedItems
                ReDim Preserve BillID(I)
                BillID(I) = Val(LI.Tag)
                I = I + 1
            Next
        End If
        frmNF3Report.Setup_report(BillID, SaveCaseType)
        frmNF3Report.MinimizeBox = False
        Cursor = Cursors.Default
        Application.DoEvents()
        frmNF3Report.ShowDialog(Me)
        frmNF3Report.Dispose()
    End Sub

    Private Sub PanelShowBills_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelShowBills.Click
        PanelBills.Visible = True
        PanelShowBills.Visible = False

        If ListView1.SelectedItems.Count = 0 Then
            TreeViewBills.Nodes.Clear()
            ListViewComments.Items.Clear()
            ListViewPayments.Items.Clear()
            txtPatientComments.Text = ""
            txtComments.Text = ""
            ListViewRequests.Items.Clear()
        Else
            LockWindowUpdate(PanelBills.Handle)
            PanelBills.SuspendLayout()
            With ListView1.SelectedItems(0)
                Load_Parient_Bills(Val(.Text))
                Load_Comments(Val(.Tag))
                Load_Payments(Val(Tag))
                Load_Requests(Val(.Tag))
                Load_Patient_Coments(Val(.Tag))
            End With
            LockWindowUpdate(0)
            PanelBills.ResumeLayout()

        End If
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

    Private Sub ButtonDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDetails.Click
        PanelBills.Visible = False
        PanelShowBills.Visible = True
    End Sub

    Private Sub ListView1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListView1.Columns(e.Column)
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
        ListView1.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListView1.Sort()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 0 Then
            TreeViewBills.Nodes.Clear()
            ListViewComments.Items.Clear()
            ListViewPayments.Items.Clear()
            txtPatientComments.Text = ""
            txtComments.Text = ""
            ListViewRequests.Items.Clear()

            Exit Sub
        End If
        If PanelBills.Visible = True Then
            LockWindowUpdate(PanelBills.Handle)
            PanelBills.SuspendLayout()
            With ListView1.SelectedItems(0)
                Load_Parient_Bills(Val(.Text))
                Load_Comments(Val(.Tag))
                Load_Payments(Val(Tag))
                Load_Requests(Val(.Tag))
                Load_Patient_Coments(Val(.Tag))
            End With
            LockWindowUpdate(0)
            PanelBills.ResumeLayout()
        End If
    End Sub

    Private Sub Load_Parient_Bills(ByVal ID)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String = ""
        Dim ParentNode As TreeNode = Nothing
        Dim ChildNode As TreeNode = Nothing
        Dim DiagNode As TreeNode = Nothing
        Dim Icn As String = ""
        Dim SaveBillID As Long = 0
        Dim SaveProcedureID As Long = 0
        'If PanelBills.Visible = False Then Exit Sub
        SQL = "SELECT  Bills.CaseTypeID,  BillProcedures.PatientProcedureID,    Bills.CopyFromBillID, Bills.SplitBillID, Bills.BillDate, BillProcedures.BillID, Bills.BillAmount, Bills.BillStatusID, BillStatus.Description AS BillStatus,  BillDiagnosis.ICDCode, BillDiagnosis.ICDDescription, BillProcedures.ProcName "
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
        TreeViewBills.EndUpdate()
    End Sub

    Private Sub Load_Comments(ByVal BillID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        ListViewComments.Items.Clear()
        txtComments.Text = ""
        Reader = gSQLGetDataReader("SELECT BillComments.CommentID, BillComments.BillID, BillComments.Comment, BillComments.InsertedBy, BillComments.InsertedDT, Employees.Fname +' '+Employees.Lname as EmpName FROM BillComments INNER JOIN Employees ON BillComments.InsertedBy = Employees.EmpID Where BillID = " & BillID & "  order by InsertedDT Desc")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            If IsDate(Reader("InsertedDT").ToString) Then
                LI = ListViewComments.Items.Add(CDate(Reader("InsertedDT")).ToString("MM/dd/yy hh:mm"))
            Else
                LI = ListViewComments.Items.Add("")
            End If
            LI.Tag = Reader("Comment").ToString
            LI.SubItems.Add(Reader("EmpName").ToString)
        Loop
        If ListViewComments.Items.Count > 0 Then
            ListViewComments.Items(0).Selected = True
            ListViewComments.Items(0).EnsureVisible()
            ListViewComments_SelectedIndexChanged(Nothing, Nothing)
        End If

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

    Private Sub Load_Patient_Coments(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader = Nothing
        txtPatientComments.Text = ""
        Reader = gSQLGetDataReader("SELECT Comments FROM Patients where PatientID = " & ID)
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Reader.Read()
            txtPatientComments.Text = Reader("Comments").ToString
        End If
    End Sub

    Private Sub ListViewComments_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewComments.SelectedIndexChanged
        If ListViewComments.SelectedItems.Count > 0 Then
            txtComments.Text = ListViewComments.SelectedItems(0).Tag
        Else
            txtComments.Text = ""
        End If
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        txtPatientComments_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtPatientComments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPatientComments.DoubleClick
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        If txtPatientComments.Text.Trim = "" Then Exit Sub
        frmBillCommentsShow.Label1.Text = "PATIENT COMMENTS"
        frmBillCommentsShow.BillNumber = ListView1.SelectedItems(0).Tag
        frmBillCommentsShow.PatientName = ListView1.SelectedItems(0).Text & "  " & ListView1.SelectedItems(0).SubItems(1).Text
        frmBillCommentsShow.lblInfo.Text = "Patient: " & ListView1.SelectedItems(1).Text
        frmBillCommentsShow.TextBox1.Text = txtPatientComments.Text
        frmBillCommentsShow.MinimizeBox = False
        frmBillCommentsShow.MaximizeBox = False
        frmBillCommentsShow.ShowDialog(Me)
        frmBillCommentsShow.Dispose()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        If ListViewComments.SelectedItems.Count = 0 Then Exit Sub
        If txtComments.Text.Trim = "" Then Exit Sub
        frmBillCommentsShow.BillNumber = ListView1.SelectedItems(0).Tag
        frmBillCommentsShow.PatientName = ListView1.SelectedItems(0).Text & "  " & ListView1.SelectedItems(0).SubItems(1).Text
        frmBillCommentsShow.lblInfo.Text = "Bill #: " & ListView1.SelectedItems(0).SubItems(3).Text & "    Patient: " & ListView1.SelectedItems(0).Text & "  " & ListView1.SelectedItems(0).SubItems(1).Text
        frmBillCommentsShow.TextBox1.Text = txtComments.Text
        frmBillCommentsShow.MinimizeBox = False
        frmBillCommentsShow.MaximizeBox = False

        frmBillCommentsShow.ShowDialog(Me)
        frmBillCommentsShow.Dispose()
    End Sub

    Private Sub mnuAddSelectedBillNotes1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddSelectedBillNotes1.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to add notes. No Bill Selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        frmAddCommentBilling.BillID = ListView1.SelectedItems(0).Tag
        If frmAddCommentBilling.ShowDialog = Windows.Forms.DialogResult.OK Then
            Load_Comments(Val(ListView1.SelectedItems(0).Tag))
        End If
        frmAddCommentBilling.Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim LI As ListViewItem
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to create Billing request. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListView1.SelectedItems(0)
        With LI
            frmBillingAddRequest.lblMsg.Text = "Patient: " & .SubItems(1).Text & "   Bill #: " & .Tag
            frmBillingAddRequest.BillAttorney = .SubItems(15).Text
            frmBillingAddRequest.BillInsurance = .SubItems(10).Text
            frmBillingAddRequest.BillID = Val(.Tag)
            frmBillingAddRequest.PatientID = Val(.SubItems(0).Text)
            frmBillingAddRequest.MinimizeBox = False
            frmBillingAddRequest.MaximizeBox = False

            frmBillingAddRequest.ShowDialog(Me)
            frmBillingAddRequest.Dispose()
            Load_Requests(Val(.Tag))
        End With
        MDIForm1Win8.TimerRefresh_Tick(Nothing, Nothing)
    End Sub

    Private Sub cboAttorney_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAttorney.SelectedIndexChanged
        If LoadingFlag Then Exit Sub
        Timer1.Enabled = True
    End Sub

    Private Sub cboArbAttorney_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If LoadingFlag Then Exit Sub
        Timer1.Enabled = True

    End Sub

    Private Sub cboInsurance_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboInsurance.SelectedIndexChanged
        If LoadingFlag Then Exit Sub
        Timer1.Enabled = True
    End Sub

    Private Sub ToolStripButtonReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonReset.Click
        LoadingFlag = True
        cboInsurance.SelectedIndex = 0
        cboAttorney.SelectedIndex = 0
        cboDays.SelectedIndex = 29
        LoadingFlag = False
        Timer1.Enabled = True
    End Sub

    Private Sub cboDays_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDays.Click

    End Sub

    Private Sub cboInsurance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInsurance.Click

    End Sub

    Private Sub cboAttorney_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAttorney.Click

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Find_Data()
    End Sub

End Class