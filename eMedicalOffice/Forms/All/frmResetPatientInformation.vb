Public Class frmResetPatientInformation
    Private m_SortingColumnPatients As ColumnHeader
    Private m_SortingColumnProcedures As ColumnHeader
    Private KeyDn As Boolean

    Private Sub Seach_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String = ""
        Dim SI As ListViewItem.ListViewSubItem
        ListViewPatients.Items.Clear()
        If Not m_SortingColumnPatients Is Nothing Then m_SortingColumnPatients.ImageKey = "SORT0"
        m_SortingColumnPatients = ListViewPatients.Columns(1)
        If Not m_SortingColumnProcedures Is Nothing Then m_SortingColumnProcedures.ImageKey = "SORT0"
        m_SortingColumnProcedures = ListViewProcedures.Columns(2)

        SQL = "SELECT  InsuranceCompanies.AcceptanceID,   Patients.PatientID, Patients.FName, Patients.LName, Patients.DOA, ReferringOffices.OfficeName, InsuranceCompanies.CompanyName FROM         Patients LEFT OUTER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID = InsuranceCompanies.CompanyID LEFT OUTER JOIN ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID Where Patients.OfficeID = " & gOfficeID

        Dim PName() As String
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

        Reader = gSQLGetDataReader(SQL)

        If Reader Is Nothing Then Exit Sub
        ListViewPatients.ListViewItemSorter = Nothing
        ListViewPatients.BeginUpdate()
        Do Until Reader.Read = False
            LI = ListViewPatients.Items.Add(Reader("PatientID").ToString)
            LI.SubItems.Add(Reader("FName").ToString & " " & Reader("LName").ToString)
            If IsDate(Reader("DOA").ToString) Then
                LI.SubItems.Add(FormatDateTime(Reader("DOA").ToString, 2))
            Else
                LI.SubItems.Add("")
            End If
            LI.Tag = "" & Reader("PatientID").ToString
            LI.SubItems.Add(Reader("OfficeName").ToString)
            SI = LI.SubItems.Add(Reader("CompanyName").ToString)
            Select Case Val(Reader("AcceptanceID").ToString) = 1
                Case 1
                    SI.ForeColor = Color.Orange
                Case 2
                    SI.ForeColor = Color.Red
            End Select
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
        Else
            ListViewProcedures.Items.Clear()
        End If
        Cursor = Cursors.Default
        ListViewPatients.EndUpdate()
    End Sub

    Private Sub frmResetPatientInformation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewPatients, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sWrite)
        SaveSetting(My.Application.Info.ProductName, UCase(Me.Name), "ComplettedProcedureInfoOnly", CheckBox1.Checked)
        SaveSetting(My.Application.Info.ProductName, UCase(Me.Name), "ProcedureWithInformationOnly", CheckBox2.Checked)
    End Sub

    Private Sub frmResetPatientInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListViewPatients, ReadWrite.sRead)
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sRead)
        m_SortingColumnPatients = ListViewPatients.Columns(0)
        m_SortingColumnProcedures = ListViewProcedures.Columns(2)
        CheckBox1.Checked = GetSetting(My.Application.Info.ProductName, UCase(Me.Name), "ComplettedProcedureInfoOnly", True)
        CheckBox2.Checked = GetSetting(My.Application.Info.ProductName, UCase(Me.Name), "ProcedureWithInformationOnly", True)
    End Sub

    Private Sub ListViewPatients_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewPatients.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewPatients.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumnPatients Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumnPatients) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumnPatients.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumnPatients.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumnPatients.Text =             m_SortingColumnPatients.Text.Mid(2)
            m_SortingColumnPatients.ImageKey = "SORT0"
            m_SortingColumnPatients.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumnPatients = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumnPatients.Text = "> " & m_SortingColumnPatients.Text
        'Else
        'm_SortingColumnPatients.Text = "< " & m_SortingColumnPatients.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumnPatients.ImageKey = "SORT1"
        Else
            m_SortingColumnPatients.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewPatients.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewPatients.Sort()
    End Sub

    Private Sub ListViewPatients_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListViewPatients.KeyDown
        If e.KeyCode = 38 Then
            If ListViewPatients.SelectedItems.Count > 0 AndAlso ListViewPatients.SelectedItems(0).Index = 0 Then
                TextBoxSearch.Focus()
                TextBoxSearch.SelectAll()
                KeyDn = False
                ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
                Exit Sub
            End If
        End If
        If e.KeyCode = 40 Or e.KeyCode = 38 Then
            KeyDn = True
        End If
    End Sub

    Private Sub ListViewPatients_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListViewPatients.KeyUp
        If e.KeyCode = 40 Or e.KeyCode = 38 Then
            KeyDn = False
            ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListViewPatients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewPatients.SelectedIndexChanged
        LockWindowUpdate(Me.Handle)
        If Not m_SortingColumnProcedures Is Nothing Then m_SortingColumnProcedures.ImageKey = "SORT0"
        m_SortingColumnProcedures = ListViewProcedures.Columns(2)
        ListViewProcedures.Items.Clear()
        If KeyDn = False Then
            If ListViewPatients.SelectedItems.Count = 0 Then
                ListViewProcedures.Items.Clear()
            Else
                Show_Details(CLng(Val(ListViewPatients.SelectedItems(0).Tag)))
            End If
        End If
        LockWindowUpdate(0)
    End Sub

    Public Sub Show_Details(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        Dim SI As ListViewItem.ListViewSubItem
        SQL = " SELECT   PatientProcedures.ProcedureStatusID,  PatientProcedures.PatientProcedureID, Procedures.ProcName, Schedule.ScheduleDateTime, PatientProcedureStatuses.Description AS Status, PatientProcedures.TreatingProviderID, PatientProcedureInformation.Description AS Information, PatientProcedures.ProcedureInformationDT, PatientProcedures.ProcedureInformationID "
        SQL &= " FROM         PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID LEFT OUTER JOIN "
        SQL &= "                       Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID LEFT OUTER JOIN "
        SQL &= "                       PatientProcedureStatuses ON PatientProcedures.ProcedureStatusID = PatientProcedureStatuses.ProcedureStatusID LEFT OUTER JOIN "
        SQL &= "                       PatientProcedureInformation ON PatientProcedures.ProcedureInformationID = PatientProcedureInformation.ProcedureInformationID "
        SQL &= " WHERE  PatientProcedures.PatientID = " & ID

        If CheckBox1.Checked Then
            SQL &= " and PatientProcedures.ProcedureStatusID = 2 "
        End If
        If CheckBox2.Checked Then
            SQL &= " and PatientProcedures.ProcedureInformationID > 0 "
        End If

        SQL &= " order by Schedule.ScheduleDateTime"
        If Not m_SortingColumnProcedures Is Nothing Then m_SortingColumnProcedures.ImageKey = "SORT0"
        m_SortingColumnProcedures = ListViewProcedures.Columns(2)

        Reader = gSQLGetDataReader(SQL.ToString())
        ListViewProcedures.Items.Clear()
        ListViewProcedures.SuspendLayout()
        ListViewProcedures.ListViewItemSorter = Nothing
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewProcedures.Items.Add(Reader("ProcName").ToString)
            LI.UseItemStyleForSubItems = False
            LI.Tag = Reader("PatientProcedureID")
            If IsDate(Reader("ScheduleDateTime").ToString) Then
                LI.SubItems.Add(FormatDateTime(Reader("ScheduleDateTime").ToString, 2))
            Else
                LI.SubItems.Add("")
            End If
            SI = LI.SubItems.Add(Reader("Status").ToString)
            If Val(Reader("ProcedureStatusID").ToString) = 2 Then
                SI.ForeColor = Color.Green
            ElseIf Val(Reader("ProcedureStatusID").ToString) = 0 Then
                SI.ForeColor = Color.Red
            End If

            SI = LI.SubItems.Add(Reader("Information").ToString)
            SI.Tag = Val(Reader("ProcedureInformationID").ToString)
            Select Case SI.Tag
                Case 1
                    SI.ForeColor = Color.Red
                    LI.Checked = True
                Case 2
                    SI.ForeColor = Color.Green
                    LI.Checked = True
                Case 3
                    SI.ForeColor = Color.Orange
                    LI.Checked = True
            End Select
            If IsDate(Reader("ProcedureInformationDT").ToString) Then
                LI.SubItems.Add(FormatDateTime(Reader("ProcedureInformationDT").ToString, 2))
            Else
                LI.SubItems.Add("")
            End If

        Loop
        ListViewProcedures.ResumeLayout()
    End Sub

    Private Sub ListViewProcedures_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewProcedures.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewProcedures.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumnProcedures Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumnProcedures) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumnProcedures.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumnProcedures.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumnProcedures.Text =             m_SortingColumnProcedures.Text.Mid(2)
            m_SortingColumnProcedures.ImageKey = "SORT0"
            m_SortingColumnProcedures.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumnProcedures = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumnProcedures.Text = "> " & m_SortingColumnProcedures.Text
        'Else
        'm_SortingColumnProcedures.Text = "< " & m_SortingColumnProcedures.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumnProcedures.ImageKey = "SORT1"
        Else
            m_SortingColumnProcedures.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewProcedures.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewProcedures.Sort()
    End Sub

    Private Sub ListViewProcedures_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListViewProcedures.ItemChecked
        If e.Item.Checked Then
            If e.Item.SubItems(3).Tag = 0 Then
                e.Item.Checked = False
                MsgBox("Unable to process reset on this procedure. The procedure status None.", MsgBoxStyle.Exclamation)

            End If
        End If
    End Sub

    Private Sub ListViewProcedures_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewProcedures.SelectedIndexChanged

    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        ListViewPatients.BeginUpdate()
        ListViewPatients.Items.Clear()
        ListViewProcedures.Items.Clear()
        If TextBoxSearch.Text.Trim <> "" Then
            Seach_Data()
        End If
        ListViewPatients.EndUpdate()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Dim LI As ListViewItem
        Dim Found As Integer = 0
        Dim FoundIDs As String
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to reset procedure(s) information. No Patient selected.", MsgBoxStyle.Exclamation)
            ListViewProcedures.Focus()
            Exit Sub
        End If
        For Each LI In ListViewProcedures.CheckedItems
            Found = Found + 1
            FoundIDs = FoundIDs & LI.Tag & ", "
        Next
        If Found = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No procedure(s) selected forreset.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            If MsgBox("Please confirm you want to reset the Patient: " & ListViewPatients.SelectedItems(0).Text & " " & Found & " procedure(s)?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            FoundIDs = FoundIDs.Left(Len(FoundIDs) - 2)
        End If
        gSQLUpdateData("Update PatientProcedures Set ProcedureStatusID =0, ProcedureInformationDT = Null Where PatientProcedureID in (" & FoundIDs & ")")

    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim LI As ListViewItem
        ListViewProcedures.BeginUpdate()
        For Each LI In ListViewProcedures.Items
            If Val(LI.SubItems(3).Tag) <> 0 Then
                LI.Checked = True
            End If
        Next
        ListViewProcedures.EndUpdate()
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNoneToolStripMenuItem.Click
        Dim LI As ListViewItem
        ListViewProcedures.BeginUpdate()
        For Each LI In ListViewProcedures.Items
            LI.Checked = False
        Next
        ListViewProcedures.EndUpdate()

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        SelectAllToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        SelectNoneToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.InitialPatientName = LI.Tag
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False

            NewFrm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        Show_Details(CLng(Val(ListViewPatients.SelectedItems(0).Tag)))
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        Show_Details(CLng(Val(ListViewPatients.SelectedItems(0).Tag)))
    End Sub

End Class