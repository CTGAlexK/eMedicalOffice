Public Class frmTreatingProviderUpdate
    Private m_SortingColumn As ColumnHeader

    Private Sub frmTreatingProviderUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sRead)
        Load_Data()
        m_SortingColumn = ListViewProcedures.Columns(1)
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        cboProviders.Items.Clear()
        Reader = gSQLGetDataReader("SELECT   Employees.EmpID,   Employees.Fname, Employees.Lname, Employees.Alias, Employees.BillingPrv, Employees.TreatmentPrv FROM Employees INNER JOIN EmployeeOffice ON Employees.EmpID = EmployeeOffice.EmpID WHERE  TreatmentPrv=1 and Employees.ActiveInd = 1 and   (Employees.PositionID = 5) AND (EmployeeOffice.OfficeID = " & gOfficeID & ")")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboProviders.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("FName").ToString & " " & Reader("LName").ToString))
            cboProvidersTo.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("FName").ToString & " " & Reader("LName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboDiagnostic.Items.Clear()
        cboDiagnostic.Items.Add(New ValueDescription(0, "ALL"))
        Reader = gSQLGetDataReader("SELECT        Diagnostics.DiagID, Diagnostics.DiagName FROM Diagnostics INNER JOIN OfficeDiagnostics ON Diagnostics.DiagID = OfficeDiagnostics.DiagID WHERE Diagnostics.ActiveInd = 1 AND OfficeDiagnostics.OfficeID = " & gOfficeID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboDiagnostic.Items.Add(New ValueDescription(CLng(Val(Reader("DiagID").ToString)), Reader("DiagName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboDiagnostic.SelectedIndex = 0

    End Sub

    Private Sub frmTreatingProviderUpdate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sWrite)
    End Sub

    Private Sub ButtonLoad_Click(sender As Object, e As EventArgs) Handles ButtonLoad.Click
        Dim SQL As String
        Dim PName() As String
        Dim FromProviderId As Integer
        Dim Reader As SqlClient.SqlDataReader
        Dim LVI As ListViewItem
        Dim c As Color
        If cboProviders.SelectedIndex = -1 Then
            MsgBox("Unable to process your request." & vbCrLf & "No From Provider selected.", MsgBoxStyle.Exclamation)
            cboProviders.Focus()
            Exit Sub
        End If
        Panel3.Enabled = False
        LabelFound.Text = "Loading..."
        LabelCount.Text = ""
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        ListViewProcedures.Items.Clear()
        FromProviderId = CType(cboProviders.SelectedItem, ValueDescription).Value
        SQL = "SELECT BillProcedures.BillID , PatientProcedureReadings.EditInd, ReferringOffices.OfficeName, PatientProcedures.ReferringDoctor, Employees.Fname+' '+Employees.Lname as TRName, Patients.PatientID,   PatientProcedures.PatientProcedureID, Schedule.ScheduleDateTime, Procedures.ProcName, PatientProcedures.DictationDate, PatientProcedureReadings.ResultID, PatientProcedureReadings.ReadingDate, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS Pname "
        SQL = SQL & " FROM         PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN Patients ON PatientProcedures.PatientID = Patients.PatientID LEFT OUTER JOIN BillProcedures ON PatientProcedures.PatientProcedureID = BillProcedures.PatientProcedureID LEFT OUTER JOIN PatientProcedureReadings ON PatientProcedures.PatientProcedureID = PatientProcedureReadings.PatientProcedureID LEFT OUTER JOIN Employees ON PatientProcedures.TreatingProviderID = Employees.EmpID LEFT OUTER JOIN ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID "
        SQL = SQL & " WHERE  PatientProcedures.ProcedureStatusID = 2  "
        SQL = SQL & " AND  BillProcedures.BillID IS NULL "

        SQL = SQL & " AND PatientProcedures.TreatingProviderID = " & FromProviderId & " "
        If chkDictation.Checked Then
            SQL = SQL & " AND PatientProcedureReadings.ResultID is null "
            SQL = SQL & " AND PatientProcedures.DictationDate is null "
        End If
        If DateTimePicker1.Checked Then
            SQL = SQL & " AND DateDiff(dd, Schedule.ScheduleDateTime, '" & DateTimePicker1.Value.ToShortDateString & "') <= 0 "
        End If
        If DateTimePicker2.Checked Then
            SQL = SQL & " AND DateDiff(dd, Schedule.ScheduleDateTime, '" & DateTimePicker2.Value.ToShortDateString & " 23:59" & "') >= 0 "
        End If
        If (cboDiagnostic.SelectedIndex > 0) Then
            SQL = SQL & " AND PatientProcedures.DiagID = " & CType(cboDiagnostic.SelectedItem, ValueDescription).Value
        End If
        If TextBoxSearch.Text.Trim <> "" Then
            If IsNumeric(TextBoxSearch.Text) Then
                SQL &= " AND Patients.PatientID = " & Val(TextBoxSearch.Text.Trim) & " "
            Else
                PName = Split(TextBoxSearch.Text.Trim.ToSafeSQLString(), " ")
                Select Case PName.Length
                    Case 1
                        If PName(0).Trim = "*" Then PName(0) = ""
                        SQL &= " and (Patients.FName Like '" & PName(0).Trim & "%' or Patients.LName Like '" & PName(0) & "%') "
                    Case 2
                        SQL &= " and ("
                        SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.LName Like '" & PName(1).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.LName Like '" & PName(0).Trim & "%')"
                        SQL &= " ) "
                    Case 3
                        SQL &= " and ("
                        SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" & PName(1).Trim & "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" & PName(2).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" & PName(0).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" & PName(1).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" & PName(0).Trim & "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" & PName(2).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "

                        SQL &= " ) "
                End Select
            End If
        End If
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then
            Panel3.Enabled = True
            Exit Sub
        End If
        Do Until Reader.Read = False
            Dim DictationDate As String
            Dim ReadingDate As String
            DictationDate = ""
            ReadingDate = ""
            c = Color.Black
            If IsDate(Reader("DictationDate").ToString) Then
                DictationDate = CDate(Reader("DictationDate")).ToString("MM/dd/yyyy")
                c = Color.Red
            End If
            If IsDate(Reader("ReadingDate").ToString) Then
                ReadingDate = CDate(Reader("ReadingDate")).ToString("MM/dd/yyyy")
                c = Color.Red
            End If
            LVI = ListViewProcedures.Items.Add(CDate(Reader("ScheduleDateTime")).ToString("MM/dd/yyyy"))
            LVI.ForeColor = c
            LVI.UseItemStyleForSubItems = True
            LVI.SubItems.Add(Reader("PatientID").ToString)
            LVI.SubItems.Add(Reader("PName").ToString)
            LVI.SubItems.Add(Reader("ProcName").ToString)
            LVI.SubItems.Add(DictationDate)
            LVI.SubItems.Add(ReadingDate)
            LVI.Tag = Reader("PatientProcedureID").ToString
            If c = Color.Black Then
                LVI.Checked = True
            End If
        Loop
        If ListViewProcedures.Items.Count > 0 Then
            gListViewRestoreDefaultColumnWidth(ListViewProcedures)
        End If
        LabelFound.Text = "Found: " & ListViewProcedures.Items.Count
        Reader.Close() : Reader.Dispose()
        Panel3.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If ListViewProcedures.SelectedItems.Count = 0 Then e.Cancel = True
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each item As ListViewItem In ListViewProcedures.Items
            item.Checked = True
        Next
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectNoneToolStripMenuItem.Click
        For Each item As ListViewItem In ListViewProcedures.Items
            item.Checked = False
        Next
    End Sub

    Private Sub ListViewProcedures_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles ListViewProcedures.ItemCheck

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Close()
    End Sub

    Private Sub ListViewProcedures_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles ListViewProcedures.ItemChecked
        LabelCount.Text = "Checked: " & ListViewProcedures.CheckedItems.Count
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim FromId As Integer
        Dim ToId As Integer
        Dim ApprovedByID As Long
        Dim ApprovedByName As String
        Dim SQL As String
        If cboProviders.SelectedIndex = -1 Then
            MsgBox("Unable to process your request." & vbCrLf & "No [From Provider] selected.", MsgBoxStyle.Exclamation)
            cboProviders.Focus()
            Exit Sub
        End If
        If ListViewProcedures.CheckedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No procedures checked.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If cboProvidersTo.SelectedIndex = -1 Then
            MsgBox("Unable to process your request." & vbCrLf & "No [To Provider] selected.", MsgBoxStyle.Exclamation)
            cboProvidersTo.Focus()
            Exit Sub
        End If
        FromId = CType(cboProviders.SelectedItem, ValueDescription).Value
        ToId = CType(cboProvidersTo.SelectedItem, ValueDescription).Value
        If FromId = ToId Then
            MsgBox("Unable to process your request." & vbCrLf & "The same [From] and [To] provider selected.", MsgBoxStyle.Exclamation)
            cboProvidersTo.Focus()
            Exit Sub
        End If

        If gCurrentEmployee.PositionID > 3 Then
            If MsgBox("Please confirm you want to change " & ListViewProcedures.CheckedItems.Count & " procedures Treating Provider?" & vbCrLf & vbCrLf & "From: " & cboProviders.Text & vbCrLf & "To: " & cboProvidersTo.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                Exit Sub
            End If
            frmSupervisorApproval.LabelMsg.Text = "Change Treating Provider: " & ListViewProcedures.CheckedItems.Count & " procedures"
            If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frmSupervisorApproval.Dispose()
                Exit Sub
            End If
            ApprovedByID = frmSupervisorApproval.SupervisorID
            ApprovedByName = frmSupervisorApproval.SupervisorName
            frmSupervisorApproval.Dispose()
        Else
            If MsgBox("Please confirm you want to change " & ListViewProcedures.CheckedItems.Count & " procedures Treating Provider?" & vbCrLf & vbCrLf & "From: " & cboProviders.Text & vbCrLf & "To: " & cboProvidersTo.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                Exit Sub
            End If
            ApprovedByID = gCurrentEmployee.EmpID
            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If
        Panel3.Enabled = False
        Panel2.Enabled = False
        LabelFound.Text = "Update in progress. Please wait..."
        LabelCount.Text = ""
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        For Each item As ListViewItem In ListViewProcedures.CheckedItems
            SQL = "UPDATE PatientProcedures set TreatingProviderID = " & ToId & " where PatientProcedureID=" & item.Tag.ToString
            gSQLUpdateData(SQL)
        Next
        Panel3.Enabled = True
        Panel2.Enabled = True
        Cursor = Cursors.Default
        MsgBox("Update Complete." & vbCrLf & vbCrLf & ListViewProcedures.CheckedItems.Count & " procedures updated." & vbCrLf & vbCrLf & "New Treating Provider: " & cboProvidersTo.Text & vbCrLf & vbCrLf & "Procedures list will be reloaded...", MsgBoxStyle.Information)
        ButtonLoad_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewProcedures_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewProcedures.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewProcedures.Columns(e.Column)
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
        ListViewProcedures.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewProcedures.Sort()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cboProviders.SelectedIndex = -1
        cboProvidersTo.SelectedIndex = -1
        chkDictation.Checked = False
        cboDiagnostic.SelectedIndex = 0
        TextBoxSearch.Text = ""
        DateTimePicker1.Checked = False
        DateTimePicker2.Checked = False
        cboProviders.Focus()
    End Sub

End Class