Public Class frmBillingIndexNumber
    Private Loading As Boolean
    Private Updated As Boolean
    Private Sub txtInvoice_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInvoice.KeyUp
        If txtInvoice.Text <> "" Then
            If txtCaseNumber.Text <> "" Then txtCaseNumber.Text = ""
        End If
    End Sub

    Private Sub txtCaseNumber_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCaseNumber.KeyUp
        If txtCaseNumber.Text <> "" Then
            If txtInvoice.Text <> "" Then txtInvoice.Text = ""
        End If
    End Sub
    Private Sub txtInvoice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoice.TextChanged
        Find_Bills()
    End Sub
    Private SkeepSearch As Boolean
    Private Sub Find_Bills(Optional ByVal Force As Boolean = False)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        Dim SI As ListViewItem.ListViewSubItem
        If txtInvoice.Text.Trim = "" And txtCaseNumber.Text.Trim = "" Then Exit Sub
        If SkeepSearch = True Then Exit Sub
        If ToolStripStatusLabelMsg.Visible = True And Force = False Then
            If MsgBox("You have not updated bill(s)" & vbCrLf & "Discard Changes?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                SkeepSearch = True
                txtInvoice.Text = txtInvoice.Tag
                txtCaseNumber.Text = txtCaseNumber.Tag
                SkeepSearch = False
                Exit Sub
            End If
        End If
        SQL = "SELECT     Bills.BillID, Bills.AttorneyCaseNumber, Patients.FName + ' ' + Patients.LName AS PatName, Employees.Fname + ' ' + Employees.Lname AS BName, Bills.ServiceFrom, Bills.ServiceTo, Bills.IndexNumber, Bills.FilingDate, Bills.BillDate, Attorneys.CompanyName AS Attorney, BillStatus.Description AS BillStatus, CaseStatuses.Description AS CaseStatus "
        SQL &= " FROM         Bills INNER JOIN Patients ON Bills.PatientID = Patients.PatientID INNER JOIN Employees ON Bills.BillingProviderID = Employees.EmpID INNER JOIN Bills AS Bills_Search ON Bills.PatientID = Bills_Search.PatientID AND Bills.BillingProviderID = Bills_Search.BillingProviderID INNER JOIN BillStatus ON Bills.BillStatusID = BillStatus.BillStatusID INNER JOIN CaseStatuses ON Patients.CaseStatusID = CaseStatuses.CaseStatusID LEFT OUTER JOIN Attorneys ON Bills.AttorneyCompanyID = Attorneys.CompanyID "
        txtInvoice.Tag = txtInvoice.Text.Trim
        txtCaseNumber.Tag = txtCaseNumber.Text.Trim
        If txtInvoice.Text.Trim <> "" Then
            SQL &= " WHERE Bills_Search.BillID = " & Val(txtInvoice.Text.Trim)
        Else
            SQL &= " WHERE (Bills_Search.AttorneyCaseNumber = " & Val(txtCaseNumber.Text.Trim) & " or Bills_Search.ArbitrationAttorneyCaseNumber = " & Val(txtCaseNumber.Text.Trim) & ") "
        End If
        SQL &= " ORDER BY Bills.BillDate "
        ToolStripStatusLabelMsg.Visible = False
        txtIndexNumber.Text = ""
        cbofType.SelectedIndex = -1
        DateTimePicker1.Checked = False
        ListView1.Items.Clear()
        ToolStripStatusLabel1.Text = ""
        ToolStripStatusLabel2.Text = ""
        ToolStripStatusLabelPatName.Text = ""
        ToolStripStatusLabelCaseStatus.Text = ""
        ToolStripStatusLabelBillingProvider.Text = ""
        cmdUpdate.Enabled = False
        cmdCancel.Enabled = False
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ListView1.SuspendLayout()
        Loading = True
        Do Until Reader.Read = False
            If ListView1.Items.Count = 0 Then
                ToolStripStatusLabelPatName.Text = "Patient: " & Reader("PatName").ToString.Trim
                ToolStripStatusLabelCaseStatus.Text = "Status: " & Reader("CaseStatus").ToString.Trim
                ToolStripStatusLabelBillingProvider.Text = "Provider: " & Reader("BName").ToString.Trim
            End If

            LI = ListView1.Items.Add(Reader("BillID").ToString.Trim)
            LI.UseItemStyleForSubItems = False
            LI.SubItems.Add(Reader("Attorney").ToString.Trim)
            LI.SubItems.Add(Reader("AttorneyCaseNumber").ToString.Trim)
            LI.SubItems.Add(Reader("BillStatus").ToString.Trim)
            LI.SubItems.Add(CDate(Reader("BillDate")).ToString("MM/dd/yyyy"))
            LI.SubItems.Add(CDate(Reader("ServiceFrom")).ToString("MM/dd/yyyy") & " - " & CDate(Reader("ServiceTo")).ToString("MM/dd/yyyy"))
            SI = LI.SubItems.Add(Reader("IndexNumber").ToString.Trim)
            If Reader("IndexNumber").ToString.Trim <> "" Then
                SI.BackColor = Color.LightSalmon
                SI.Tag = Reader("IndexNumber").ToString.Trim
            End If
            If IsDate(Reader("FilingDate").ToString) Then
                SI = LI.SubItems.Add(CDate(Reader("FilingDate")).ToString("MM/dd/yyyy"))
                SI.Tag = CDate(Reader("FilingDate")).ToString("MM/dd/yyyy")
                SI.BackColor = Color.MediumAquamarine
            Else
                LI.SubItems.Add("")
            End If
        Loop
        Loading = False
        ListView1.ResumeLayout()
        ToolStripStatusLabel1.Text = "Bills Found: " & ListView1.Items.Count
        ToolStripStatusLabel2.Text = "Bills Checked: " & ListView1.CheckedItems.Count
    End Sub

    Private Sub frmBillingIndexNumber_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ToolStripStatusLabelMsg.Visible Then
            If MsgBox("You have not updated bill(s)." & vbCrLf & "Discard Changes?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        gWindow_Settings(Me, ReadWrite.sWrite)
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)
        If Updated Then Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmBillingIndexNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 114 Then
            Button2_Click_1(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmBillingIndexNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmBillingIndexNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
        StatusStrip2.SizingGrip = False
        cbofType.Items.Add("Litigation")
        cbofType.Items.Add("Arbitration")
        Timer1.Enabled = True
    End Sub

    Private Sub RestoreSpreadColumnSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gListViewRestoreDefaultColumnWidth(ListView1)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim LI As ListViewItem
        Dim C As Integer
        Dim SI As ListViewItem.ListViewSubItem
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("Unable to process your request" & vbCrLf & "No Bill(s) checked.", MsgBoxStyle.Exclamation)
            txtInvoice.Focus()
            Exit Sub
        End If
        If cbofType.SelectedIndex = -1 Then
            MsgBox("Unable to process your request." & vbCrLf & "No Filing Type selected.", MsgBoxStyle.Exclamation)
            cbofType.Focus()
            Exit Sub
        End If
        If DateTimePicker1.Checked = False And txtIndexNumber.Text.Trim = "" Then
            MsgBox("Unable to process your request." & vbCrLf & "No Court Index Number / Filing Date specified.", MsgBoxStyle.Exclamation)
            txtIndexNumber.Focus()
            Exit Sub
        End If
        If DateTimePicker1.Checked Then
            If DateTimePicker1.Value > Now Then
                MsgBox("Unable to process your request." & vbCrLf & "The Filing date should can not be grater then today's date.", MsgBoxStyle.Exclamation)
                DateTimePicker1.Focus()
                Exit Sub
            End If
        End If
        If txtIndexNumber.Text <> "" Then
            C = 0
            For Each LI In ListView1.Items
                If LI.Checked Then
                    If LI.SubItems(6).Text <> "" Then
                        C = C + 1
                    End If
                End If
            Next
            If C > 0 Then
                If MsgBox(C & " of the checked bill(s) the Court Index Number is already assigned." & vbCrLf & "Please confirm you want to overwrite the Court Index number?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        End If
        If DateTimePicker1.Checked Then
            C = 0
            For Each LI In ListView1.Items
                If LI.Checked Then
                    If IsDate(LI.SubItems(7).Text) Then
                        C = C + 1
                    End If
                End If
            Next
            If C > 0 Then
                If MsgBox(C & " of the checked bill(s) the Filing Date is already assigned." & vbCrLf & "Please confirm you want to overwrite the Filing Date?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        End If
        If txtIndexNumber.Text <> "" Then
            For Each LI In ListView1.CheckedItems
                LI.SubItems(6).Text = IIf(cbofType.SelectedIndex = 0, "L-", "A-") & txtIndexNumber.Text
                LI.SubItems(6).BackColor = Color.LightPink
            Next
        End If
        If DateTimePicker1.Checked Then
            For Each LI In ListView1.CheckedItems
                LI.SubItems(7).Text = DateTimePicker1.Value.ToString("MM/dd/yyyy")
                LI.SubItems(7).BackColor = Color.LightPink
            Next
        End If
        cmdUpdate.Enabled = True
        cmdCancel.Enabled = True
        ToolStripStatusLabelMsg.Visible = True
    End Sub

    Private Sub ListView1_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView1.ItemChecked
        If Loading = True Then Exit Sub
        ToolStripStatusLabel2.Text = ListView1.CheckedItems.Count & " Bills Checked"
    End Sub

    Private Sub txtCaseNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCaseNumber.TextChanged
        Find_Bills()
    End Sub

    Private Sub CheckAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAllToolStripMenuItem.Click
        Dim LI As ListViewItem
        Loading = True
        For Each LI In ListView1.Items
            LI.Checked = True
        Next
        Loading = False
        ToolStripStatusLabel2.Text = "Bills Checked: " & ListView1.CheckedItems.Count
    End Sub

    Private Sub CheckNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckNoneToolStripMenuItem.Click
        Dim LI As ListViewItem
        Loading = True
        For Each LI In ListView1.CheckedItems
            LI.Checked = False
        Next
        Loading = False
        ToolStripStatusLabel2.Text = "Bills Checked: 0"
    End Sub

    Private Sub CheckAllWithNoIndexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAllWithNoIndexToolStripMenuItem.Click
        Dim LI As ListViewItem
        Loading = True
        For Each LI In ListView1.Items
            If LI.SubItems(6).Text = "" Then
                LI.Checked = True
            End If
        Next
        Loading = False
        ToolStripStatusLabel2.Text = "Bills Checked: " & ListView1.CheckedItems.Count
    End Sub

    Private Sub CheckAllWithNoDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAllWithNoDateToolStripMenuItem.Click
        Dim LI As ListViewItem
        Loading = True
        For Each LI In ListView1.Items
            If IsDate(LI.SubItems(7).Text) = False Then
                LI.Checked = True
            End If
        Next
        Loading = False
        ToolStripStatusLabel2.Text = "Bills Checked: " & ListView1.CheckedItems.Count
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim LI As ListViewItem
        Dim C As Integer
        Dim Comment As String
        For Each LI In ListView1.Items
            If LI.SubItems(6).BackColor = Color.LightPink Or LI.SubItems(7).BackColor = Color.LightPink Then
                C = C + 1
            End If
        Next
        If C = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "Nothing to update.")
        Else
            If MsgBox("Please confirm you want to update " & C & " bills?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Loading = True
        For Each LI In ListView1.Items
            If LI.SubItems(6).BackColor = Color.LightPink Then
                gSQLUpdateData("Update Bills set IndexNumber='" & LI.SubItems(6).Text.ToSafeSQLString() & "' Where BillID=" & Val(LI.Text))
                Comment = "Index Number Assigned: " & LI.SubItems(6).Text.ToSafeSQLString()
                If LI.SubItems(6).Tag <> "" Then
                    Comment = "Index Number Overwritten. Old Index Number: " & LI.SubItems(6).Tag.ToString().ToSafeSQLString()  & ". New Index Number: " & LI.SubItems(6).Text.ToSafeSQLString()
                End If
                gSQLUpdateData("INSERT INTO BillComments (BillID, Comment, InsertedBy, InsertedDT) values(" & Val(LI.Text) & ", '" & Comment & "', " & gCurrentEmployee.EmpID & ", getdate())")
                LI.SubItems(6).BackColor = Color.LightSalmon
                LI.SubItems(6).Tag = LI.SubItems(6).Text.ToSafeSQLString()
            End If
            If LI.SubItems(7).BackColor = Color.LightPink Then
                gSQLUpdateData("Update Bills set FilingDate='" & LI.SubItems(7).Text.ToSafeSQLString() & "' Where BillID=" & Val(LI.Text))
                Comment = "Filing Date Assigned: " & LI.SubItems(7).Text.ToSafeSQLString()
                If LI.SubItems(6).Tag <> "" Then
                    Comment = "Filing Date Overwritten. Old Filing Date: " & LI.SubItems(7).Tag.ToString().ToSafeSQLString() & ". New Filing Date: " & LI.SubItems(7).Text.ToSafeSQLString()
                End If
                gSQLUpdateData("INSERT INTO BillComments (BillID, Comment, InsertedBy, InsertedDT) values(" & Val(LI.Text) & ", '" & Comment & "', " & gCurrentEmployee.EmpID & ", getdate())")
                LI.SubItems(7).BackColor = Color.MediumAquamarine
                LI.SubItems(7).Tag = LI.SubItems(7).Text.ToSafeSQLString()

            End If
            LI.Checked = False
        Next
        Loading = False
        ToolStripStatusLabelMsg.Visible = False
        cmdUpdate.Enabled = False
        cmdCancel.Enabled = False
        ToolStripStatusLabel2.Text = "Bills Checked: " & ListView1.CheckedItems.Count
        Updated = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtIndexNumber.Text.Trim = "" Then
            MsgBox("Unable to process Filing Date search." & vbCrLf & "No Court Index Number specified.", MsgBoxStyle.Exclamation)
            txtIndexNumber.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If MsgBox("Please confirm you want to discard changes?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Find_Bills(True)
        cmdUpdate.Enabled = False
        cmdCancel.Enabled = False
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Button2.Visible = False Then Exit Sub
        If ToolStripStatusLabelMsg.Visible = True Then
            If MsgBox("You have not updated bill(s)" & vbCrLf & "Discard Changes?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        frmBillingIndexNumberSearch.BillTextBox = txtInvoice
        frmBillingIndexNumberSearch.ShowDialog(Me)
        frmBillingIndexNumberSearch.Dispose()
        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
            ListView1.Focus()
        End If
        'Find_Bills()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
        If ListView1.Items.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No data loaded for printing.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        gPrintListview(ListView1, PrinterOrientation.Landscape, True, "BILLING COURT INDEX NUMBER MAINTENANCE OF " & Now)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity += 0.08
        If Me.Opacity = 1 Then Timer1.Enabled = False
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        gListViewRestoreDefaultColumnWidth(ListView1)
    End Sub
End Class