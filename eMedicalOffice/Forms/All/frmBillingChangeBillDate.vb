Public Class frmBillingChangeBillDate
    Public BillID As Long
    Public CalledBillDateSI As ListViewItem.ListViewSubItem
    Public PatientID As Long
    Private SupervisorName As String
    Private Sub frmBillingChangeBillDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
        If Suppervisor.SupervisorName = "" Then Exit Sub

        If MsgBox("Please confirm you want to update bill date to " & DateTimePicker1.Value.Date & "?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        gSQLUpdateData("Update Bills Set BillDate = '" & DateTimePicker1.Value & "' where BillID = " & BillID)
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tBillChanged, "Bill Date Updated. Old Bill Date: " & CalledBillDateSI.Text & " New Bill Date: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy"), SupervisorName)
        CalledBillDateSI.Text = DateTimePicker1.Value.Date.ToString("MM/dd/yyyy")
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        txtPassword.PasswordChar = ""

    End Sub

    Private Sub PictureBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        txtPassword.PasswordChar = "*"
    End Sub
End Class