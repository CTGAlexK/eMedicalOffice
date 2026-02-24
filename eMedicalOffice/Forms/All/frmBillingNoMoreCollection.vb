Public Class frmBillingNoMoreCollectionChange
    Public BillID As Long
    Public CalledNoMoreCollection As ListViewItem.ListViewSubItem
    Public CalledBillStatusSI As ListViewItem.ListViewSubItem
    Public PatientID As Long
    Private SupervisorName As String
    Public NoMoreCollection As Integer
    Private Sub frmBillingNoMoreCollectionChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If gCurrentEmployee.PositionID > 3 Then
            Height = 265
            Panel3.Visible = True
        Else
            Height = 215
            Panel3.Visible = False
        End If

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim SupervisorName As String

        If gCurrentEmployee.PositionID > 3 Then
            Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
            If Suppervisor.SupervisorName = "" Then Exit Sub
            SupervisorName = Suppervisor.SupervisorName
        Else
            SupervisorName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If

        Dim BillStatus As String
        Dim SQL As String
        If SupervisorName = "" Then Exit Sub
        If RadioButtonContinueCollection.Checked Then
            BillStatus = "Continue Collection"
        Else
            BillStatus = "No More Collection"
        End If
        If (NoMoreCollection = 0 And RadioButtonContinueCollection.Checked) Or (NoMoreCollection = 1 And RadioButtonContinueCollection.Checked = False) Then
            MsgBox("Unable to process update. No status changed.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MsgBox("Please confirm you want to update bill status to [" & BillStatus & "] ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        If RadioButtonContinueCollection.Checked Then
            SQL = "UPDATE Bills Set NoMoreCollection = 0 Where BillID=" & BillID
        Else
            SQL = "UPDATE Bills Set NoMoreCollection = 1, BillStatusID=8 Where BillID=" & BillID

        End If
        gSQLUpdateData(SQL)
        SQL = "INSERT INTO BillComments  (BillID, Comment, InsertedBy, InsertedDT) VALUES(" & BillID & ",'Bill Status Changed: " & BillStatus & vbCrLf & " on " & Date.Today.ToShortDateString & "', " & gCurrentEmployee.EmpID & ", getdate())"
        gSQLUpdateData(SQL)
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tBillChanged, "Bill # " & BillID & " Status Updated: " & BillStatus, SupervisorName)
        If RadioButtonContinueCollection.Checked Then
            CalledNoMoreCollection.Text = ""
            CalledNoMoreCollection.BackColor = Nothing
        Else
            CalledNoMoreCollection.Text = "YES"
            CalledNoMoreCollection.BackColor = Color.Red
            CalledBillStatusSI.BackColor = Color.Gainsboro
            CalledBillStatusSI.Text = "Closed"
        End If
        'CalledBillAmountSI.Text = Val(TextBox1.Text)
        'CalledBillBalanceSI.Text = Val(TextBox1.Text) - PaidAmount
        Close()
    End Sub

    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        txtPassword.PasswordChar = ""
    End Sub

    Private Sub PictureBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        txtPassword.PasswordChar = "*"
    End Sub
End Class