Public Class frmPatientRefferingDoctor
    Private KeyDn As Boolean
    Private Loading As Boolean
    Private m_SortingColumnPatients As ColumnHeader
    Private m_SortingColumnProcedures As ColumnHeader

    Private Sub TextBoxSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxSearch.GotFocus
        TextBoxSearch.SelectAll()
    End Sub

    Private Sub TextBoxSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxSearch.KeyDown
        If e.KeyCode = 40 Then
            If ListViewPatients.SelectedItems.Count > 0 Then
                ListViewPatients.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        If Loading = True Then Exit Sub
        ListViewPatients.BeginUpdate()
        ListViewPatients.Items.Clear()

        Clear_Details()
        If TextBoxSearch.Text.Trim <> "" Or txtDOA.Checked Then
            Seach_Data()
        End If
        ListViewPatients.EndUpdate()
    End Sub

    Private Sub ListViewPatients_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = 40 Or e.KeyCode = 38 Then
            KeyDn = False
            ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub Seach_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String = ""
        Dim SI As ListViewItem.ListViewSubItem
        ListViewPatients.Items.Clear()
        If Not m_SortingColumnPatients Is Nothing Then m_SortingColumnPatients.ImageKey = "SORT0"
        m_SortingColumnPatients = ListViewPatients.Columns(1)
        If Not m_SortingColumnProcedures Is Nothing Then m_SortingColumnProcedures.ImageKey = "SORT0"
        m_SortingColumnProcedures = ListViewProcedures.Columns(1)

        SQL = "Select ReferringCompanyID, PatientID, FName, LName, DOA from Patients Where OfficeID = " & gOfficeID
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
        If txtDOA.Checked Then
            SQL &= " and DOA ='" & txtDOA.Value.ToShortDateString & "'"
        End If

        SQL &= " Order by FName, LName"

        Reader = gSQLGetDataReader(SQL)

        If Reader Is Nothing Then Exit Sub
        ListViewPatients.ListViewItemSorter = Nothing
        Do Until Reader.Read = False
            LI = ListViewPatients.Items.Add(Reader("PatientID").ToString)
            SI = LI.SubItems.Add(Reader("FName").ToString & " " & Reader("LName").ToString)
            SI.Tag = Val(Reader("ReferringCompanyID").ToString)
            If IsDate(Reader("DOA").ToString) Then
                LI.SubItems.Add(FormatDateTime(Reader("DOA").ToString, 2))
            Else
                LI.SubItems.Add("")
            End If
            LI.Tag = "" & Reader("PatientID").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
        Else
            Clear_Details()
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub Clear_Details()
        ListViewProcedures.Items.Clear()
    End Sub

    Private Sub Label21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label21.Click

    End Sub

    Private Sub Label21_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label21.GotFocus
        txtDOA.Focus()
    End Sub

    Private Sub ListViewPatients_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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

    Public Sub ListViewPatients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewPatients.SelectedIndexChanged
        LockWindowUpdate(Me.Handle)
        If Not m_SortingColumnProcedures Is Nothing Then m_SortingColumnProcedures.ImageKey = "SORT0"
        m_SortingColumnProcedures = ListViewProcedures.Columns(1)
        Clear_Details()
        If KeyDn = False Then
            If ListViewPatients.SelectedItems.Count = 0 Then
                Clear_Details()
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
        SQL = " SELECT  PatientProcedures.PatientProcedureID,   Procedures.ProcName, Schedule.ScheduleDateTime, ReferringDoctor , PatientProcedureReadings.ReadingDate, PatientProcedureStatuses.Description as Status "
        SQL &= " FROM         PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID LEFT OUTER JOIN PatientProcedureReadings ON PatientProcedures.PatientProcedureID = PatientProcedureReadings.PatientProcedureID INNER JOIN PatientProcedureStatuses ON PatientProcedures.ProcedureStatusID = PatientProcedureStatuses.ProcedureStatusID "
        SQL &= " WHERE  PatientProcedures.PatientID = " & ID

        Reader = gSQLGetDataReader(SQL.ToString())
        ListViewProcedures.Items.Clear()
        ListViewProcedures.SuspendLayout()
        ListViewProcedures.ListViewItemSorter = Nothing
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewProcedures.Items.Add(Reader("ProcName").ToString)
            LI.Tag = Reader("PatientProcedureID")
            If IsDate(Reader("ScheduleDateTime").ToString) Then
                LI.SubItems.Add(FormatDateTime(Reader("ScheduleDateTime").ToString, 2))
            Else
                LI.SubItems.Add("")
            End If
            LI.SubItems.Add(Reader("Status").ToString)
            SI = LI.SubItems.Add(Reader("ReferringDoctor").ToString)
            If IsDate(Reader("ReadingDate").ToString) Then
                LI.SubItems.Add(FormatDateTime(Reader("ReadingDate").ToString, 2))
            Else
                LI.SubItems.Add("")
            End If

        Loop
        ListViewProcedures.ResumeLayout()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmQuickSearch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TextBoxSearch.Focus()
    End Sub

    Private Sub frmQuickSearch_BackgroundImageLayoutChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackgroundImageLayoutChanged

    End Sub

    Private Sub frmQuickSearch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewPatients, ReadWrite.sRead)
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sRead)
    End Sub

    Private Sub frmQuickSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListViewPatients, ReadWrite.sRead)
        gListview_Settings(Me, ListViewProcedures, ReadWrite.sRead)
        Load_Data()
    End Sub

    Private Sub Load_Data()
        Loading = True

        Loading = False
    End Sub

    Private Sub ComboBoxStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBoxSearch_TextChanged(Nothing, Nothing)
    End Sub

    Private Sub txtDOA_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)

    End Sub

    Private LastIndex As Integer

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

    Private Sub ListViewProcedures_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewProcedures.DoubleClick

        If ListViewProcedures.SelectedItems.Count = 0 Then Exit Sub
        ChangeProfile_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewProcedures_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewProcedures.SelectedIndexChanged

    End Sub

    Private Sub ChangeProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ListViewProcedures.SelectedItems.Count = 0 Then
            MsgBox("Unable to change Reffering Doctor. No Procedure selected.", MsgBoxStyle.Exclamation)
            ListViewProcedures.Focus()
            Exit Sub
        End If
        If Val(ListViewPatients.SelectedItems(0).SubItems(1).Tag) = 0 Then
            MsgBox("Unable to change Reffering Doctor. No Reffering Office selected for the current patient." & vbCrLf & vbCrLf & "Please open the patient's profile and select the Reffering Office.", MsgBoxStyle.Exclamation)
            ListViewPatients.Focus()
            Exit Sub
        End If
        Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
        If Suppervisor.SupervisorName = "" Then Exit Sub
        Dim SupervisorName As String = Suppervisor.SupervisorName

        If ListViewProcedures.SelectedItems(0).SubItems(4).Text <> "" Then
            frmPatientRefferingDoctorPopUp.Label4.Text = "ATTENTION! THE PROCEDURE READING IS ALREADY ASSIGNED!"
        Else
            frmPatientRefferingDoctorPopUp.Label4.Text = "ATTENTION! ADMINISTRATIVE FUNCTION!"
        End If

        frmPatientRefferingDoctorPopUp.lblCurrentRefferingDoctor.Text = ListViewProcedures.SelectedItems(0).SubItems(3).Text
        frmPatientRefferingDoctorPopUp.RefferingDoctor = ListViewProcedures.SelectedItems(0).SubItems(3).Text
        frmPatientRefferingDoctorPopUp.ReferringCompanyID = Val(ListViewPatients.SelectedItems(0).SubItems(1).Tag)

        frmPatientRefferingDoctorPopUp.ProcedureID = Val(ListViewProcedures.SelectedItems(0).Tag)
        frmPatientRefferingDoctorPopUp.CalledListView = ListViewProcedures
        frmPatientRefferingDoctorPopUp.ShowDialog(Me)
        frmPatientRefferingDoctorPopUp.Dispose()
    End Sub

    Private Sub txtDOA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        TextBoxSearch_TextChanged(Nothing, Nothing)
    End Sub

End Class