Public Class frmFilingFeesPaymentStatus
    Public CalledBillLI As ListViewItem
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim SQL As String = ""
        If IsDate(LabelFilingFeesPaymentDT.Text) And LabelFilingFeesPaymentDT.Text <> "" And cboPaymentStatus.SelectedIndex = 1 Then
            MsgBox("Unable to process update. No changes made.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If LabelFilingFeesPaymentDT.Text = "" And cboPaymentStatus.SelectedIndex = 0 Then
            MsgBox("Unable to process update. No changes made.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If IsDate(LabelFilingFeesPaymentDT.Text) And LabelFilingFeesPaymentDT.Text <> "" And cboPaymentStatus.SelectedIndex = 0 Then
            If MsgBox("Attention!" & vbCrLf & vbCrLf & "Please confirm you want to set the Filing Fees Payment status to Not Paid?" & vbCrLf & vbCrLf & "Affected bills: " & ListView1.Items.Count, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If (IsDate(LabelFilingFeesPaymentDT.Text) = False Or LabelFilingFeesPaymentDT.Text = "") And cboPaymentStatus.SelectedIndex = 1 Then
            If MsgBox("Attention!" & vbCrLf & vbCrLf & "Please confirm you want to set the Filing Fees Payment status to Paid?" & vbCrLf & vbCrLf & "Affected bills: " & ListView1.Items.Count, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
        If Suppervisor.SupervisorName = "" Then Exit Sub
        Dim SupervisorName As String = Suppervisor.SupervisorName

        If cboPaymentStatus.SelectedIndex = 1 Then
            SQL = "UPDATE Bills set FilingFeePaidDate = getdate() where (FilingFeePaidDate is null) and IndexNumber = '" & LabelFilingIndex.Text.Trim.ToSafeSQLString() & "'"
            gSQLUpdateData(SQL)
            CalledBillLI.SubItems(9).Text = Now.ToShortDateString
        ElseIf cboPaymentStatus.SelectedIndex = 0 Then
            SQL = "UPDATE Bills set FilingFeePaidDate = Null where IndexNumber = '" & LabelFilingIndex.Text.Trim.ToSafeSQLString() & "'"
            gSQLUpdateData(SQL)
            CalledBillLI.SubItems(9).Text = ""
        End If
        Me.Close()
    End Sub

    Private Sub frmFilingFeesPaymentStatus_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)
    End Sub

    Private Sub frmFilingFeesPaymentStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Dim reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        reader = gSQLGetDataReader("SELECT BillID, FName + ' ' + LName AS PatName FROM Bills INNER JOIN Patients ON Bills.PatientID = Patients.PatientID WHERE Bills.IndexNumber = '" & LabelFilingIndex.Text.ToSafeSQLString() & "'")
        If Not reader Is Nothing Then
            Do Until reader.Read = False
                LI = ListView1.Items.Add(reader("BillID").ToString)
                LI.SubItems.Add(reader("PatName").ToString)
            Loop
        End If
    End Sub
End Class