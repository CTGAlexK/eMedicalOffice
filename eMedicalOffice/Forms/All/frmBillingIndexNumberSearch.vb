Public Class frmBillingIndexNumberSearch
    Public BillTextBox As TextBox

    Private Sub TextBoxSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxSearch.KeyDown
        If e.KeyCode = 40 And ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
            ListViewPatients.Focus()
        End If
    End Sub

    Private Sub TextBoxSearch_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBoxSearch.MouseDown

    End Sub
    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        Seach_Data()
    End Sub
    Private Sub Seach_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim sLI As ListViewItem.ListViewSubItem
        Dim SQL As String = ""
        Dim S As String
        Dim PName() As String
        ListViewPatients.Items.Clear()
        SQL = "SELECT Patients.PatientID,  Bills.IndexNumber, Bills.BillID,  Patients.FName, Patients.MI, Patients.LName, Patients.Suffix, Bills.ServiceFrom, Bills.ServiceTo, BillAmount, PaidAmount FROM Patients INNER JOIN Bills ON Patients.PatientID = Bills.PatientID "
        SQL &= " Where (Patients.OfficeID = " & gOfficeID & ") "
        If TextBoxSearch.Text <> "" Then
            S = TextBoxSearch.Text.ToSafeSQLString()
            PName = Split(S, " ")
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
        SQL &= " ORDER BY Patients.FName, Patients.MI, Patients.LName, Patients.Suffix, Bills.ServiceFrom, Bills.ServiceTo "

        Reader = gSQLGetDataReader(SQL)

        If Reader Is Nothing Then Exit Sub
        ListViewPatients.BeginUpdate()
        Dim SavePatID As Long
        Dim SaveColor As Color = Color.White
        Do Until Reader.Read = False
            If SavePatID <> CInt(Reader("PatientID").ToString) Then
                If SaveColor = Color.LightGray Then
                    SaveColor = Color.White
                Else
                    SaveColor = Color.LightGray
                End If
                SavePatID = CInt(Reader("PatientID").ToString)
            End If
            If Reader("MI").ToString <> "" Then
                LI = ListViewPatients.Items.Add(Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString & " " & Reader("Suffix").ToString)
            Else
                LI = ListViewPatients.Items.Add(Reader("FName").ToString & " " & Reader("LName").ToString & " " & Reader("Suffix").ToString)
            End If
            LI.BackColor = SaveColor
            LI.UseItemStyleForSubItems = False
            LI.SubItems.Add(CDate(Reader("ServiceFrom").ToString).ToString("MM/dd/yyyy") & " - " & CDate(Reader("ServiceTo").ToString).ToString("MM/dd/yyyy"))
            LI.SubItems.Add(CDbl(Reader("BillAmount").ToString).ToString("c"))
            LI.SubItems.Add(CDbl(Reader("PaidAmount").ToString).ToString("c"))
            sLI = LI.SubItems.Add(Reader("IndexNumber").ToString)
            If Reader("IndexNumber").ToString <> "" Then
                sLI.BackColor = Color.LightSalmon
            End If
            LI.Tag = "" & Reader("BillID").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
        End If
        Cursor = Cursors.Default
        ListViewPatients.EndUpdate()
    End Sub

    Private Sub frmBillingIndexNumberSearch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
        TextBoxSearch.Focus()
    End Sub

    Private Sub frmBillingIndexNumberSearch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewPatients, ReadWrite.sWrite)
    End Sub

    Private Sub frmBillingIndexNumberSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListViewPatients, ReadWrite.sRead)
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Show_Patient()
    End Sub
    Public Sub Show_Patient()
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to show patient's bills. No Patient selected.", MsgBoxStyle.Exclamation)
            TextBoxSearch.Focus()
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        BillTextBox.Text = LI.Tag
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ListViewPatients_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPatients.DoubleClick
        If ListViewPatients.SelectedItems.Count > 0 Then
            Show_Patient()
        End If
    End Sub

    Private Sub ListViewPatients_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListViewPatients.KeyDown
        If e.KeyCode = 13 Then
            If ListViewPatients.SelectedItems.Count > 0 Then
                Show_Patient()
            End If
        End If
        If e.KeyCode = 38 Then
            If ListViewPatients.SelectedIndices(0) = 0 Then
                TextBoxSearch.Focus()
                TextBoxSearch.SelectAll()
            End If
        End If

    End Sub
End Class