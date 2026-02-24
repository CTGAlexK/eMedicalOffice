Public Class frmBillingCollectionReport
    Private m_SortingColumn As ColumnHeader
    Private c_SortingColumn As ColumnHeader

    Private Sub frmBillingCollectionReport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)
        gListview_Settings(Me, ListView2, ReadWrite.sWrite)
        SaveSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SplitterDistance1", SplitContainer1.SplitterDistance)
        SaveSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SplitterDistance2", SplitContainer2.SplitterDistance)
    End Sub

    Private Sub frmBillingCollectionReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
        gListview_Settings(Me, ListView2, ReadWrite.sRead)
        DateTimePickerFrom.Value = DateAdd(DateInterval.Day, -7, Now)
        DateTimePickerTo.Value = Now
        On Error Resume Next
        SplitContainer1.SplitterDistance = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SplitterDistance1", SplitContainer1.SplitterDistance)
        SplitContainer2.SplitterDistance = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "SplitterDistance2", SplitContainer2.SplitterDistance)
        Load_Data()
        m_SortingColumn = ListView1.Columns(1)
        c_SortingColumn = ListView2.Columns(0)
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("SELECT EmpID, Fname + ' ' + Lname AS EmpName FROM Employees WHERE (PositionID <> 4) AND (PositionID <> 5) AND (PositionID <> 10) AND (PositionID <> 100) ORDER BY EmpName")
        cboEmployee.Items.Add(New ValueDescription(0, "Show All"))
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboEmployee.Items.Add(New ValueDescription(Val(Reader("EmpID").ToString), Reader("EmpName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboEmployee.SelectedIndex = 0

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        Find_Data()

    End Sub

    Private Sub Find_Data()
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        ListView1.Items.Clear()

        Clear_Data()
        LabelTotal.Text = "Loading. Please Wait..."
        ListView1.BeginUpdate()
        ListView1.SuspendLayout()
        m_SortingColumn = ListView1.Columns(1)
        m_SortingColumn.ImageKey = "SORT1"
        ListView1.ListViewItemSorter = Nothing
        c_SortingColumn = ListView2.Columns(0)
        c_SortingColumn.ImageKey = "SORT2"
        ListView2.ListViewItemSorter = Nothing

        SQL = "SELECT DISTINCT Employees.Fname + ' ' + Employees.Lname AS EmpName, Patients.FName + ' ' + Patients.LName AS PatName, Patients.PatientID, DATEADD(D, 0, DATEDIFF(D, 0, BillComments.InsertedDT)) as InsertedDT, Employees.EmpID, 'Notes' as t "
        SQL &= " FROM Bills INNER JOIN Patients ON Bills.PatientID = Patients.PatientID INNER JOIN BillComments ON Bills.BillID = BillComments.BillID INNER JOIN Employees ON BillComments.InsertedBy = Employees.EmpID "
        SQL &= " WHERE   1=1 "
        If cboEmployee.SelectedIndex > 0 Then
            SQL &= " AND  BillComments.InsertedBy = " & CType(cboEmployee.SelectedItem, ValueDescription).Value
        End If
        If DateTimePickerFrom.Checked Then
            SQL &= " and DATEDIFF(d, BillComments.InsertedDT, '" & DateTimePickerFrom.Value.Date & "')<=0  "
        End If
        If DateTimePickerTo.Checked Then
            SQL &= " and DATEDIFF(d, BillComments.InsertedDT, '" & DateTimePickerTo.Value.Date & "')>=0 "
        End If
        If RadioButton1.Checked Then
            SQL &= "UNION "
            SQL &= "SELECT DISTINCT Employees.Fname + ' ' + Employees.Lname AS EmpName, Patients.FName + ' ' + Patients.LName AS PatName, Patients.PatientID, DATEADD(D, 0, DATEDIFF(D, 0, PatientLog.AccessDT)) as InsertedDT, Employees.EmpID, 'Comments' as t  "
            SQL &= "FROM Patients INNER JOIN PatientLog ON Patients.PatientID = PatientLog.PatientID INNER JOIN Employees ON PatientLog.AccessByUserID = Employees.EmpID "
            SQL &= " WHERE   1=1 "
            If cboEmployee.SelectedIndex > 0 Then
                SQL &= " AND  PatientLog.AccessByUserID = " & CType(cboEmployee.SelectedItem, ValueDescription).Value
            End If
            If DateTimePickerFrom.Checked Then
                SQL &= " and DATEDIFF(d, PatientLog.AccessDT, '" & DateTimePickerFrom.Value.Date & "')<=0  "
            End If
            If DateTimePickerTo.Checked Then
                SQL &= " and DATEDIFF(d, PatientLog.AccessDT, '" & DateTimePickerTo.Value.Date & "')>=0 "
            End If
        End If
        SQL &= " ORDER BY InsertedDT, EmpName asc "
        Reader = gSQLGetDataReader(SQL)
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("EmpName").ToString)
            LI.Tag = Val(Reader("PatientID").ToString)
            LI.SubItems.Add(CDate(Reader("InsertedDT").ToString).ToString("MM/dd/yyyy"))
            LI.SubItems(1).Tag = Reader("EmpID").ToString
            LI.SubItems.Add(Reader("PatName").ToString())
            LI.SubItems.Add(Reader("T").ToString())
        Loop
        ListView1.EndUpdate()
        ListView1.ResumeLayout()
        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
            ListView1_SelectedIndexChanged(Nothing, Nothing)
        End If
        LabelTotal.Text = "Found: " & ListView1.Items.Count
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DateTimePickerFrom.Value = DateAdd(DateInterval.Day, -1, Now)
        DateTimePickerTo.Value = Now
        Find_Data()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DateTimePickerFrom.Value = DateAdd(DateInterval.Day, -7, Now)
        DateTimePickerTo.Value = Now
        Find_Data()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DateTimePickerFrom.Value = DateAdd(DateInterval.Month, -1, Now)
        DateTimePickerTo.Value = Now
        Find_Data()
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
        Dim LI As ListViewItem
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Clear_Data()
        c_SortingColumn = ListView2.Columns(0)
        c_SortingColumn.ImageKey = "SORT2"
        ListView2.ListViewItemSorter = Nothing

        If ListView1.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        LI = ListView1.SelectedItems(0)
        If (LI.SubItems(3).Text) = "Comments" Then
            SQL &= " select PatientLog.AccessDT as InsertedDT, Comments as Comment from PatientLog "
            SQL &= " WHERE PatientID = " & Val(LI.Tag)
            SQL &= " AND PatientLog.AccessByUserID  = " & Val(LI.SubItems(1).Tag.ToString)
            SQL &= " AND cast(PatientLog.AccessDT as date)  = '" & LI.SubItems(1).Text.ToString & "'"
        Else
            SQL = "SELECT     BillComments.InsertedDT as InsertedDT, BillComments.Comment as Comment "
            SQL &= " FROM Bills INNER JOIN Patients ON Bills.PatientID = Patients.PatientID INNER JOIN BillComments ON Bills.BillID = BillComments.BillID "
            SQL &= " WHERE Bills.PatientID = " & Val(LI.Tag)
            SQL &= " AND BillComments.InsertedBy  = " & Val(LI.SubItems(1).Tag.ToString)
            SQL &= " AND cast(BillComments.InsertedDT as date)  = '" & LI.SubItems(1).Text.ToString & "'"
        End If
        SQL &= " ORDER BY InsertedDT DESC "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListView2.Items.Add(CDate(Reader("InsertedDT").ToString).ToString("MM/dd/yyyy hh:mm"))
            LI.Tag = Reader("Comment").ToString
            LI.ToolTipText = Reader("Comment").ToString
            LI.SubItems.Add(Reader("Comment").ToString())
        Loop
        If ListView2.Items.Count > 0 Then
            ListView2.Items(0).Selected = True
            ListView2.Items(0).EnsureVisible()
            ListView2_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub

    Private Sub Clear_Data()
        ListView2.Items.Clear()
        TextBox1.Text = ""
    End Sub

    Private Sub ListView2_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView2.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListView2.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If c_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(c_SortingColumn) Then
                ' Same column. Switch the sort order.

                'If c_SortingColumn.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If c_SortingColumn.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'c_SortingColumn.Text =             c_SortingColumn.Text.Mid(2)
            c_SortingColumn.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        c_SortingColumn = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'c_SortingColumn.Text = "> " & c_SortingColumn.Text
        'Else
        'c_SortingColumn.Text = "< " & c_SortingColumn.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            c_SortingColumn.ImageKey = "SORT1"
        Else
            c_SortingColumn.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListView2.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListView2.Sort()
    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        TextBox1.Text = ""
        If ListView2.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        TextBox1.Text = ListView2.SelectedItems(0).Tag
    End Sub

    Private Sub PopUpMenuItemShowPatient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopUpMenuItemShowPatient.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.InitialPatientName = Val(ListView1.SelectedItems(0).Tag)
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.ShowDialog(Me)
        End Using
    End Sub

End Class