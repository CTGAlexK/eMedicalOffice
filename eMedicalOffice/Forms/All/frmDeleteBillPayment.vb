Public Class frmDeleteBillPayment
    Public BillID As Long
    Public PatientID As Long
    Private SupervisorName As String
    Private RemoveAmount As Double = 0

    Private Sub frmDeleteBillPayment_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)
    End Sub
    Private Sub frmDeleteBillPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmdUpdate.Enabled = True
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
    End Sub
    Dim Updated As Boolean
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim LI As ListViewItem
        Dim SQL As String
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("Unable to delete bill payment(s)." & vbCrLf & "No Payment(s) selected.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
            Exit Sub
        End If
        If txtComments.Text.Trim = "" Then
            MsgBox("Unable to delete bill payment(s)." & vbCrLf & "The Payment Removal Reason should be specified.", MsgBoxStyle.Exclamation)
            txtComments.Focus()
            Exit Sub
        End If
        Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
        If Suppervisor.SupervisorName = "" Then Exit Sub
        SupervisorName = Suppervisor.SupervisorName

        If MsgBox("Please confirm you want to delete " & ListView1.CheckedItems.Count & " payment(s) " & vbCrLf & "For the total amount " & lblRemoveAmouont.Text & "?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        If ListView1.CheckedItems.Count = ListView1.Items.Count Then
            gSQLUpdateData("UPDATE Bills SET PaidAmount = 0, BillStatusID=4 Where BillID=" & BillID)
        Else
            gSQLUpdateData("UPDATE Bills SET PaidAmount = PaidAmount-" & CDbl(RemoveAmount) & " Where BillID=" & BillID)
        End If
        For Each LI In ListView1.CheckedItems
            gSQLUpdateData("DELETE FROM BillPayments where PaymentID=" & Val(LI.Tag))
            gUpdate_Profile_Log(PatientID, PatientLogTypes.tPaymentDeleted, "Bill #:" & BillID & " Payment Deleted: " & LI.SubItems(2).Text & " Check Number: " & LI.SubItems(3).Text & " Reason:" & txtComments.Text.Trim.ToSafeSQLString(), SupervisorName)
            SQL = "INSERT INTO BillComments (BillID, Comment,InsertedBy , InsertedDT) VALUES( "
            SQL &= BillID & ", 'Payments Deleted on " & Now & ". Amount Deleted: " & LI.SubItems(2).Text & " Reason: " & txtComments.Text.Trim.ToSafeSQLString() & "', " & gCurrentEmployee.EmpID & ", GETDATE())"
            gSQLUpdateData(SQL)
            LI.Remove()
        Next
        txtUserName.Text = ""
        txtPassword.Text = ""
        lblPaid.Text = (CDbl(lblPaid.Text) - RemoveAmount).ToString("c")
        lblRemaining.Text = (CDbl(lblRemaining.Text) + RemoveAmount).ToString("c")
        lblRemoveAmouont.Text = "$0.00"
        Updated = True
        If ListView1.Items.Count = 0 Then
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        If Updated = True Then
            DialogResult = Windows.Forms.DialogResult.OK
        End If

        Me.Close()
    End Sub

    Private Sub ListView1_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView1.ItemChecked
        Dim LI As ListViewItem
        Dim Amt As Double = 0
        lblRemoveAmouont.Text = "$0.00"

        For Each LI In ListView1.CheckedItems
            Amt = Amt + CDbl(LI.SubItems(2).Text)
        Next
        RemoveAmount = Amt
        lblRemoveAmouont.Text = CDbl(Amt).ToString("c")
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = -1 Then Exit Sub
        If txtComments.Text.Trim = "" Then
            txtComments.Text = ComboBox1.Items(ComboBox1.SelectedIndex)
        Else
            txtComments.Text = vbCrLf & ComboBox1.Items(ComboBox1.SelectedIndex)
        End If


        ComboBox1.SelectedIndex = -1
    End Sub
End Class