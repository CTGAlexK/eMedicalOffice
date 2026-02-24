Public Class frmUnlockProfiles
    Private OpMode As AddEditMode
    Private m_SortingColumn As ColumnHeader

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
        Load_Locks()

        Application.DoEvents()
        m_SortingColumn = ListView1.Columns(1)
        gSetup_GotFocus(Me)
        Cursor = Cursors.Default
    End Sub

    Private Sub frmAdjusterMaintenance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)
    End Sub

    Private Sub Load_Locks()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem

        Reader = gSQLGetDataReader("SELECT     PatientID, FName, LName, LockedByName, LockedByHostName, LockDT FROM Patients WHERE isnull(LockedByIP,'')<>'' order by FName, LName")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("PatientID").ToString, 0)
            LI.SubItems.Add(Reader("FName").ToString & " " & Reader("LName").ToString)
            LI.SubItems.Add(Reader("FName").ToString)
            If IsDate(Reader("LockDT").ToString) Then
                LI.ToolTipText = CDate(Reader("LockDT").ToString).ToString("MM/dd/yyyy hh:mm")
            End If
            LI.SubItems.Add(Reader("LockedByName").ToString)
            LI.SubItems.Add(Reader("LockedByHostName").ToString)
            LI.Tag = "" & Reader("PatientID").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
        End If
        If ListView1.SelectedItems.Count = 0 Then
            cmdUnlock.Enabled = False
        Else
            cmdUnlock.Enabled = True
        End If
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
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Clear_Controls()
        Cursor = Cursors.Default
    End Sub

    Private Sub Clear_Controls()
        gLoop_Clear_Controls(Me, TextBoxSearch)
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnlock.Click
        Dim ID As Long
        If ListView1.SelectedItems.Count = 0 And ListView1.CheckedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Patient's profile checked / selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListView1.CheckedItems.Count = 0 Then
            ID = CLng(ListView1.SelectedItems(0).Tag)
            gSQLDeleteRecord("UPDATE Patients Set LockDT=Null, LockByID=0, LockedByIP = '', LockedByHostName='', LockedByName='' Where PatientID=" & ID)
            ListView1.Items.Remove(ListView1.SelectedItems(0))
        Else
            For Each LI As ListViewItem In ListView1.CheckedItems
                ID = CLng(LI.Tag)
                gSQLDeleteRecord("UPDATE Patients Set LockDT=Null, LockByID=0, LockedByIP = '', LockedByHostName='', LockedByName='' Where PatientID=" & ID)
                LI.Remove()
            Next
        End If
        If ListView1.SelectedItems.Count = 0 Then
            cmdUnlock.Enabled = False
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        gSearchListView(ListView1, TextBoxSearch, False, 1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ID As Long
        gSQLDeleteRecord("UPDATE Patients Set LockDT=Null, LockByID=0, LockedByIP = '', LockedByHostName='', LockedByName='' ")
        ListView1.Items.Clear()
    End Sub

End Class