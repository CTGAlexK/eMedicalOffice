Public Class frmAttorneyFees
    Private Loading As Boolean
    Private Updated As Boolean
    Private Sub txtInvoice_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInvoice.KeyUp
        If txtInvoice.Text <> "" Then
            If txtCaseNumber.Text <> "" Then txtCaseNumber.Text = ""
            If txtPatient.Text <> "" Then txtPatient.Text = ""
            If txtFindCheckNumber.Text <> "" Then txtFindCheckNumber.Text = ""
            If txtIndexNumber.Text <> "" Then txtIndexNumber.Text = ""
        End If
    End Sub

    Private Sub txtCaseNumber_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCaseNumber.KeyUp
        If txtCaseNumber.Text <> "" Then
            If txtInvoice.Text <> "" Then txtInvoice.Text = ""
            If txtPatient.Text <> "" Then txtPatient.Text = ""
            If txtFindCheckNumber.Text <> "" Then txtFindCheckNumber.Text = ""
            If txtIndexNumber.Text <> "" Then txtIndexNumber.Text = ""
        End If
    End Sub
    Private Sub txtInvoice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoice.TextChanged
        Find_Bills()
    End Sub
    Private SkeepSearch As Boolean
    Public Sub Find_Bills(Optional ByVal Force As Boolean = False)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        Dim SI As ListViewItem.ListViewSubItem
        Dim PName() As String
        Dim Paid As Double
        Dim WhereFound As Boolean
        If Loading Then Exit Sub
        ListViewPayments.Items.Clear()
        ListView1.Items.Clear()
        If txtInvoice.Text.Trim = "" And txtCaseNumber.Text.Trim = "" And txtPatient.Text.Trim = "" And txtFindCheckNumber.Text.Trim = "" And txtIndexNumber.Text.Trim = "" Then Loading = False : Exit Sub
        txtInvoice.Tag = txtInvoice.Text.Trim
        txtCaseNumber.Tag = txtCaseNumber.Text.Trim
        txtPatient.Tag = txtPatient.Text.Trim

        SQL = "SELECT Att.CompanyName, Patients.FName, Patients.LName, Patients.MI,  Bills.IndexNumber, Bills.FilingFee, Bills.FilingFeePaidDate,  Bills.BillID, Bills.AttorneyCaseNumber, Patients.FName + ' ' + Patients.LName AS PatName, Bills.ServiceFrom, Bills.ServiceTo, Bills.BillDate, Bills.ArbitrationAttorneyCaseNumber "
        SQL &= ", (select sum(AttorneyFeesPaid) from BillAttorneyFees where BillAttorneyFees.BillID=Bills.BillID) as AttorneyFeesPaid "
        SQL &= " FROM         Bills INNER JOIN Patients ON Bills.PatientID = Patients.PatientID "
        SQL &= " LEFT OUTER JOIN Attorneys as Att ON Bills.AttorneyCompanyID = Att.CompanyID "

        If txtInvoice.Text.Trim <> "" Then
            If txtInvoice.Text.Trim = "*" Then
                SQL &= " WHERE 1=1 "
            Else
                SQL &= " WHERE Bills.BillID = " & Val(txtInvoice.Text.Trim)
            End If
            WhereFound = True
        ElseIf txtCaseNumber.Text.Trim <> "" Then
            SQL &= " WHERE (Bills.AttorneyCaseNumber = " & Val(txtCaseNumber.Text.Trim) & " or Bills_Search.ArbitrationAttorneyCaseNumber = " & Val(txtCaseNumber.Text.Trim) & ") "
            WhereFound = True
        ElseIf txtFindCheckNumber.Text.Trim <> "" Then
            SQL &= " WHERE (Bills.BillID in (select billid from BillAttorneyFees where AttorneyFeesCheckNumber like '" & Val(txtFindCheckNumber.Text.Trim) & "%')) "
            WhereFound = True
        ElseIf txtIndexNumber.Text.Trim <> "" Then
            SQL &= " WHERE Bills.IndexNumber like '" & txtIndexNumber.Text.Trim.ToSafeSQLString() & "%'"
            WhereFound = True
        Else
            If txtPatient.Text.Trim <> "" Then
                WhereFound = True
                If IsNumeric(txtPatient.Text) Then
                    SQL &= " WHERE Patients.PatientID = " & Val(txtPatient.Text.Trim) & " "
                Else
                    PName = Split(txtPatient.Text.Trim.ToSafeSQLString(), " ")
                    Select Case PName.Length
                        Case 1
                            If PName(0).Trim = "*" Then PName(0) = ""
                            SQL &= " WHERE (Patients.FName Like '" & PName(0).Trim & "%' or Patients.LName Like '" & PName(0) & "%') "
                        Case 2
                            SQL &= " WHERE ("
                            SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.LName Like '" & PName(1).Trim & "%') "
                            SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.LName Like '" & PName(0).Trim & "%')"
                            SQL &= " )"
                        Case 3
                            SQL &= " WHERE ("
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
        End If
        SQL &= " ORDER BY Bills.BillDate "

        ToolStripStatusLabel1.Text = ""
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ListView1.SuspendLayout()
        Loading = True
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("BillID").ToString.Trim)
            LI.UseItemStyleForSubItems = False
            LI.SubItems.Add(Reader("FName").ToString.Trim & IIf(Reader("LName").ToString.Trim <> "", " " & Reader("LName").ToString.Trim, "") & IIf(Reader("MI").ToString.Trim <> "", " " & Reader("MI").ToString.Trim, ""))

            LI.SubItems.Add(CDate(Reader("BillDate")).ToString("MM/dd/yyyy"))
            LI.SubItems.Add(CDate(Reader("ServiceFrom")).ToString("MM/dd/yyyy") & " - " & CDate(Reader("ServiceTo")).ToString("MM/dd/yyyy"))
            If Val(Reader("AttorneyFeesPaid").ToString) > 0 Then
                SI = LI.SubItems.Add(Val(Reader("AttorneyFeesPaid").ToString).ToString("c"))
                SI.Tag = Reader("AttorneyFeesPaid").ToString.Trim
                Paid = Paid + Val(Reader("AttorneyFeesPaid").ToString)
            Else
                SI = LI.SubItems.Add("")
                SI.Tag = ""
            End If
            LI.SubItems.Add(Reader("CompanyName").ToString.Trim)
            LI.SubItems.Add(Reader("AttorneyCaseNumber").ToString.Trim)
            LI.SubItems.Add(Reader("IndexNumber").ToString.Trim)
            If Val(Reader("FilingFee").ToString) > 0 Then
                LI.SubItems.Add(Val(Reader("FilingFee").ToString).ToString("c"))
            Else
                LI.SubItems.Add("")
            End If
            If IsDate(Reader("FilingFeePaidDate").ToString) Then
                LI.SubItems.Add(CDate(Reader("FilingFeePaidDate")).ToString("MM/dd/yyyy"))
            Else
                LI.SubItems.Add("")
            End If
        Loop
        Loading = False
        ListView1.ResumeLayout()
        ToolStripStatusLabel1.Text = "Found Bill(s): " & ListView1.Items.Count & "   "
        ToolStripStatusLabelTotalTop.Text = "Found Fees: " & Paid.ToString("c") & "   "
        Timer2.Enabled = False
        Timer2.Enabled = True
    End Sub
    Public Sub Load_BillFees(ByVal BillID As Integer)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        Dim Paid As Double
        ListViewPayments.Items.Clear()
        SQL = "SELECT ID, AttorneyFeesDate, AttorneyFeesPaid, AttorneyFeesCheckNumber, CompanyName from BillAttorneyFees inner join Attorneys on BillAttorneyFees.AttorneyID = Attorneys.CompanyID where BillID = " & BillID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ListViewPayments.SuspendLayout()
        Do Until Reader.Read = False
            LI = ListViewPayments.Items.Add(CDate(Reader("AttorneyFeesDate")).ToString("MM/dd/yyyy"))
            LI.Tag = Reader("ID").ToString
            LI.SubItems.Add(Reader("AttorneyFeesCheckNumber").ToString.Trim)
            LI.SubItems.Add(Val(Reader("AttorneyFeesPaid").ToString).ToString("c"))
            LI.SubItems.Add(Reader("CompanyName").ToString.Trim)
            Paid = Paid + Val(Reader("AttorneyFeesPaid").ToString)

        Loop
        ListViewPayments.ResumeLayout()
    End Sub
    Private Sub frmBillingIndexNumber_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ToolStripStatusLabelMsg.Visible Then
            If MsgBox("You have unsaved data." & vbCrLf & "Discard Changes?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        gWindow_Settings(Me, ReadWrite.sWrite)
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewPayBills, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewPayments, ReadWrite.sWrite)
        If Updated Then Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmBillingIndexNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 114 Then
            Button2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmBillingIndexNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmBillingIndexNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Reader As SqlClient.SqlDataReader
        gWindow_Settings(Me, ReadWrite.sRead, True)
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
        gListview_Settings(Me, ListViewPayBills, ReadWrite.sRead)
        gListview_Settings(Me, ListViewPayments, ReadWrite.sRead)
        DateTimePicker1.Value = Now
        Reader = gSQLGetDataReader("Select CompanyID, CompanyName from Attorneys Where OfficeID=" & gOfficeID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboAttorneysCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        Loading = True
        cboAttorneysCompanyID.SelectedIndex = -1
        Loading = False
        Timer1.Enabled = True
    End Sub

    Private Sub ButtonAddBillFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddBillFee.Click
        Dim LI As ListViewItem
        Dim sLI As ListViewItem
        Dim C As Integer
        Dim SI As ListViewItem.ListViewSubItem
        Dim Paid As Double
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request" & vbCrLf & "No Bill selected.", MsgBoxStyle.Exclamation)
            txtInvoice.Focus()
            Exit Sub
        End If
        For Each sLI In ListViewPayBills.Items

        Next
        If cboAttorneysCompanyID.SelectedIndex = -1 Then
            MsgBox("Unable to process your request" & vbCrLf & "The Attorney should be selected.", MsgBoxStyle.Exclamation)
            cboAttorneysCompanyID.Focus()
            Exit Sub
        End If

        If txtCheckNumber.Text.Trim = "" Then
            MsgBox("Unable to process your request." & vbCrLf & "The Check Number should be specified", MsgBoxStyle.Exclamation)
            txtCheckNumber.Focus()
            Exit Sub
        End If

        If txtFeeAmout.Text.Trim = "" Then
            MsgBox("Unable to process your request." & vbCrLf & "The Fee Amount should be specified", MsgBoxStyle.Exclamation)
            txtFeeAmout.Focus()
            Exit Sub
        End If
        If IsNumeric(txtFeeAmout.Text.Trim) = False Then
            MsgBox("Unable to process your request." & vbCrLf & "Invalid Fee Amount." & vbCrLf & "The Fee Amouont should be numeric value", MsgBoxStyle.Exclamation)
            txtFeeAmout.Focus()
            Exit Sub
        End If
        If Val(txtFeeAmout.Text.Trim) = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "Invalid Fee Amount." & vbCrLf & "The Amouont should be positive value", MsgBoxStyle.Exclamation)
            txtFeeAmout.Focus()
            Exit Sub
        End If
        If Val(txtFeeAmout.Text.Trim) < 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "Invalid Fee Amount." & vbCrLf & "The Amouont should be positive value", MsgBoxStyle.Exclamation)
            txtFeeAmout.Focus()
            Exit Sub
        End If
        If CDate(DateTimePicker1.Value.Date) > Now.Date Then
            MsgBox("Unable to process your request." & vbCrLf & "Invalid Fee Date." & vbCrLf & "The Date can not be future date.", MsgBoxStyle.Exclamation)
            DateTimePicker1.Focus()
            Exit Sub
        End If
        Dim MessageShown As Boolean = False

        LI = ListView1.SelectedItems(0)
        For Each sLI In ListViewPayBills.Items
            If sLI.Text.ToUpper = LI.Text.ToUpper Then
                MessageShown = True
                If MsgBox("The Bill number " & LI.Text & " is already on selected the payments list." & vbCrLf & "Please confirm you want to add another Attorney Fees payment in the amount of " & Val(txtFeeAmout.Text).ToString("C") & " to the same bill?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    sLI.Selected = True
                    sLI.EnsureVisible()
                    ListView1.Focus()
                    Exit Sub
                End If
                Exit For
            End If
        Next
        If LI.SubItems(4).Text <> "" And MessageShown = False Then
            If MsgBox("The selected bill Attorney Fees in the amount of " & LI.SubItems(4).Text & " is already recorded." & vbCrLf & "Please confirm you want to add another Attorney Fees payment in the amount of " & Val(txtFeeAmout.Text).ToString("C") & " to the same bill?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Dim NewLI As ListViewItem
        NewLI = ListViewPayBills.Items.Add(LI.Text)
        NewLI.SubItems.Add(LI.SubItems(1).Text)
        NewLI.SubItems.Add(LI.SubItems(2).Text)
        NewLI.SubItems.Add(LI.SubItems(3).Text)
        NewLI.SubItems.Add(CDbl(txtFeeAmout.Text).ToString("c"))
        NewLI.SubItems.Add(DateTimePicker1.Value.ToString("MM/dd/yyyy"))
        NewLI.SubItems.Add(txtCheckNumber.Text.Trim)
        NewLI.SubItems.Add(CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Description).Tag = CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Value
        cboAttorneysCompanyID.Enabled = False
        cmdUpdate.Enabled = True
        ToolStripStatusLabelMsg.Visible = True

        Dim SplitCount As Integer
        Dim SplitAmount As Double
        If CheckBox1.Checked Then
            For Each LI In ListViewPayBills.Items
                If LI.SubItems(6).Text = txtCheckNumber.Text.Trim Then
                    SplitCount = SplitCount + 1
                End If
            Next
            SplitAmount = Val(txtFeeAmout.Text.Trim)
            SplitAmount = SplitAmount / SplitCount
            For Each LI In ListViewPayBills.Items
                If LI.SubItems(6).Text = txtCheckNumber.Text.Trim Then
                    LI.SubItems(4).Text = SplitAmount.ToString("c")
                End If
            Next
        End If
        Calc_Selected_Fees()


    End Sub
    Private Sub Calc_Selected_Fees()
        Dim LI As ListViewItem
        Dim Paid As Double = 0
        For Each LI In ListViewPayBills.Items
            Paid = Paid + CDbl(LI.SubItems(4).Text)
        Next
        ToolStripStatusLabel2.Text = "Selected Bill(s): " & ListViewPayBills.Items.Count
        ToolStripStatusLabelTotalBottom.Text = "Selected Fees: " & Paid.ToString("c") & "   "
    End Sub
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        ButtonAddBillFee_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.GotFocus
        LV = ListView1
    End Sub

    Private Sub ListView1_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView1.ItemChecked
    End Sub

    Private Sub txtCaseNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCaseNumber.TextChanged
        Find_Bills()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim LI As ListViewItem
        Dim sLI As ListViewItem
        Dim C As Integer
        Dim Comment As String
        If MsgBox("Please confirm you want to update " & ListViewPayBills.Items.Count & " bill(s)?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        For Each LI In ListViewPayBills.Items
            gSQLUpdateData("INSERT INTO BillAttorneyFees (AttorneyID, BillID, AttorneyFeesPaid, AttorneyFeesDate, AttorneyFeesCheckNumber) VALUES(" & CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Value & ", " & Val(LI.Text) & ", " & CDbl(LI.SubItems(4).Text) & ", '" & LI.SubItems(5).Text.ToSafeSQLString() & "', '" & LI.SubItems(6).Text.ToSafeSQLString() & "')")
            Comment = "Attorney Fees Attorney: " & CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Description & "  Paid: " & LI.SubItems(4).Text.ToSafeSQLString() & " Check Number: " & LI.SubItems(6).Text.ToSafeSQLString()
            gSQLUpdateData("INSERT INTO BillComments (BillID, Comment, InsertedBy, InsertedDT) VALUES(" & Val(LI.Text) & ", '" & Comment & "', " & gCurrentEmployee.EmpID & ", getdate())")
        Next
        ListViewPayBills.Items.Clear()
        txtCheckNumber.Text = ""
        txtFeeAmout.Text = ""
        cboAttorneysCompanyID.SelectedIndex = -1
        cboAttorneysCompanyID.Enabled = True
        cmdUpdate.Enabled = False
        Find_Bills()
        ToolStripStatusLabelMsg.Visible = False
        Updated = True
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Dim LV As ListView
    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
        ContextMenuStrip3.Show(ButtonPrint, New Point(0, 0))
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity += 0.08
        If Me.Opacity = 1 Then Timer1.Enabled = False
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        gListViewRestoreDefaultColumnWidth(ListView1)
        gListViewRestoreDefaultColumnWidth(ListViewPayBills)
        gListViewRestoreDefaultColumnWidth(ListViewPayments)
    End Sub

    Private Sub StatusStrip2_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub txtPatient_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPatient.KeyUp
        If txtPatient.Text <> "" Then
            If txtCaseNumber.Text <> "" Then txtCaseNumber.Text = ""
            If txtInvoice.Text <> "" Then txtInvoice.Text = ""
            If txtFindCheckNumber.Text <> "" Then txtFindCheckNumber.Text = ""
            If txtIndexNumber.Text <> "" Then txtIndexNumber.Text = ""
        End If
    End Sub

    Private Sub txtPatient_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPatient.TextChanged
        Find_Bills()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        gListViewRestoreDefaultColumnWidth(ListView1)
        gListViewRestoreDefaultColumnWidth(ListViewPayBills)
        gListViewRestoreDefaultColumnWidth(ListViewPayments)
    End Sub

    Private Sub ButtonRemoveBillFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRemoveBillFee.Click
        Dim LI As ListViewItem
        If ListViewPayBills.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Attorney Fees Payment selected.", MsgBoxStyle.Exclamation)
            ListViewPayBills.Focus()
            Exit Sub
        End If
        LI = ListViewPayBills.SelectedItems(0)
        If MsgBox("Please confirm you want to remove the Attorney Fees Payment for the bill number " & LI.Text & " from the payments list?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        LI.Remove()
        cmdUpdate.Enabled = CBool(ListViewPayBills.Items.Count)
        cboAttorneysCompanyID.Enabled = Not CBool(ListViewPayBills.Items.Count)
        ToolStripStatusLabelMsg.Visible = CBool(ListViewPayBills.Items.Count)
        Calc_Selected_Fees()
    End Sub

    Private Sub ButtonRemoveBillAllFees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ListViewPayBills.Items.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("Please confirm you want to remove All Attorney Fee Payments?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        ListViewPayBills.Items.Clear()
        cmdUpdate.Enabled = False
        ToolStripStatusLabelMsg.Visible = False
        Calc_Selected_Fees()
    End Sub
    Private Sub ListView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPayBills.DoubleClick
        If ListViewPayBills.SelectedItems.Count = 0 Then Exit Sub
        ButtonRemoveBillFee_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPayBills.GotFocus
        LV = ListView1
    End Sub
    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If ListView1.SelectedItems.Count = 0 Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim psInfo As New  _
        System.Diagnostics.ProcessStartInfo("calc.exe")
        psInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
        Dim myProcess As Process = System.Diagnostics.Process.Start(psInfo)

    End Sub

    Private Sub PrintTopListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintTopListToolStripMenuItem.Click
        If ListView1.Items.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No data loaded for printing.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        gPrintListview(ListView1, PrinterOrientation.Landscape, True, "ATTORNEY FEES REPORT AS OF " & Now)

    End Sub

    Private Sub PrintBottomListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBottomListToolStripMenuItem.Click
        If ListViewPayBills.Items.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No data loaded for printing.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        gPrintListview(ListViewPayBills, PrinterOrientation.Landscape, True, "ATTORNEY FEES REPORT AS OF " & Now)

    End Sub

    Private Sub txtFindCheckNumber_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFindCheckNumber.KeyUp
        If txtFindCheckNumber.Text <> "" Then
            If txtCaseNumber.Text <> "" Then txtCaseNumber.Text = ""
            If txtInvoice.Text <> "" Then txtInvoice.Text = ""
            If txtPatient.Text <> "" Then txtPatient.Text = ""

        End If

    End Sub

    Private Sub txtFindCheckNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFindCheckNumber.TextChanged
        Find_Bills()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        ButtonFilingFees.Enabled = False
        If ListView1.SelectedItems.Count = 0 Then
            ListViewPayments.Items.Clear()
        Else
            If ListView1.SelectedItems(0).SubItems(8).Text <> "" Then
                ButtonFilingFees.Enabled = True
            End If
            Load_BillFees(Val(ListView1.SelectedItems(0).Text))
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        gListViewRestoreDefaultColumnWidth(ListView1)
        gListViewRestoreDefaultColumnWidth(ListViewPayBills)
        gListViewRestoreDefaultColumnWidth(ListViewPayments)
    End Sub

    Private Sub mnuAddBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddBill.Click
        ButtonAddBillFee_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuRemoveBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRemoveBill.Click
        ButtonRemoveBillFee_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuRemoveAllBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRemoveAllBills.Click
        ButtonRemoveBillAllFees_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonRemoveExistingBillFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRemoveExistingBillFee.Click
        Dim LI As ListViewItem
        Dim LIp As ListViewItem
        Dim Comment As String
        Dim ApprovedByName As String
        Dim SelectedIndex As Integer
        If ListView1.SelectedItems.Count = 0 Or ListViewPayments.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Attorney Fees payment selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListView1.SelectedItems(0)
        LIp = ListViewPayments.SelectedItems(0)
        SelectedIndex = Val(LI.Index)
        If gCurrentEmployee.PositionID > 2 Then
            frmSupervisorApproval.LabelMsg.Text = "Remove Attorney Fees Payment from Bill #" & LI.Text
            If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frmSupervisorApproval.Dispose()
                Exit Sub
            End If
            ApprovedByName = frmSupervisorApproval.SupervisorName
            frmSupervisorApproval.Dispose()
        Else
            If MsgBox("Please confirm you want to remove the Attorney Fees Payment in the amount of " & LIp.SubItems(2).Text & " from the bill number " & LI.Text & " ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If

        gSQLUpdateData("DELETE FROM BillAttorneyFees Where ID = " & Val(LIp.Tag))

        Comment = "Attorney Fees Payment: Check #: " & LIp.SubItems(1).Text & " Amt: " & LIp.SubItems(2).Text & " has been removed."
        gSQLUpdateData("INSERT INTO BillComments (BillID, Comment, InsertedBy, InsertedDT) values(" & Val(LI.Text) & ", '" & Comment & "', " & gCurrentEmployee.EmpID & ", getdate())")
        ListViewPayments.Items.Remove(LIp)
        Dim NewAmt As Double
        NewAmt = gSQLGetSingleValue("select sum(AttorneyFeesPaid) from BillAttorneyFees where BillID=" & Val(LI.Text))
        If NewAmt = 0 Then
            LI.SubItems(4).Text = ""
        Else
            LI.SubItems(4).Text = NewAmt.ToString("c")
        End If
        'Find_Bills()
        'Application.DoEvents()
        'On Error Resume Next
        'ListView1.Items(SelectedIndex).Selected = True
        'ListView1.Items(SelectedIndex).EnsureVisible()
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub txtIndexNumber_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIndexNumber.KeyUp
        If txtIndexNumber.Text <> "" Then
            If txtInvoice.Text <> "" Then txtInvoice.Text = ""
            If txtPatient.Text <> "" Then txtPatient.Text = ""
            If txtFindCheckNumber.Text <> "" Then txtFindCheckNumber.Text = ""
            If txtCaseNumber.Text <> "" Then txtCaseNumber.Text = ""
        End If

    End Sub

    Private Sub txtIndexNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIndexNumber.TextChanged
        Find_Bills()
    End Sub

    Private Sub ButtonFilingFees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFilingFees.Click
        Dim LI As ListViewItem
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        LI = ListView1.SelectedItems(0)
        If LI.SubItems(7).Text = "" Then Exit Sub
        frmFilingFeesPaymentStatus.LabelPatientName.Text = LI.SubItems(1).Text
        frmFilingFeesPaymentStatus.LabelBillNumber.Text = LI.Text
        frmFilingFeesPaymentStatus.LabelFilingIndex.Text = LI.SubItems(7).Text
        frmFilingFeesPaymentStatus.LabelFilingFees.Text = LI.SubItems(8).Text
        frmFilingFeesPaymentStatus.LabelFilingFeesPaymentDT.Text = LI.SubItems(9).Text
        frmFilingFeesPaymentStatus.CalledBillLI = LI
        If IsDate(LI.SubItems(9).Text) Then
            frmFilingFeesPaymentStatus.cboPaymentStatus.SelectedIndex = 1
        Else
            frmFilingFeesPaymentStatus.cboPaymentStatus.SelectedIndex = 0
        End If

        
        frmFilingFeesPaymentStatus.ShowDialog(Me)
        frmFilingFeesPaymentStatus.Dispose()
    End Sub
End Class