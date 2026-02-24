Public Class frmBillingChangeBillStatus
    Public BillID As Long
    Public CurrentStatusID As Integer
    Public CalledBillStatusSI As ListViewItem.ListViewSubItem
    Public CalledBillStatusDateSI As ListViewItem.ListViewSubItem
    Public CalledBillStatusAttorneySI As ListViewItem.ListViewSubItem
    Public PatientID As Long
    Private SupervisorName As String
    Private Sub frmBillingChangeBillDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
        PanelAttorney.Visible = False

        DateTimePicker1.MaxDate = Now
    End Sub
    Private Sub Load_Data()
        Dim reader As SqlClient.SqlDataReader
        cboBillStatus.Items.Clear()
        reader = gSQLGetDataReader("SELECT     BillStatusID, Description FROM         BillStatus where BillStatusID <> 9 and BillStatusID <> 6 and BillStatusID <> 7  ORDER BY BillStatusID")
        If reader Is Nothing Then Exit Sub
        Do Until reader.Read = False
            cboBillStatus.Items.Add(New ValueDescription(CLng(Val(reader("BillStatusID").ToString)), reader("Description").ToString))
        Loop
        reader.Close() : reader.Dispose()
        cboBillStatus.SelectedIndex = -1

        cboAttorneysCompanyID.Items.Clear()
        reader = gSQLGetDataReader("Select CompanyID, CompanyName, AttorneyFName+' '+AttorneyLName as AttorneyName from Attorneys Where OfficeID=" & gOfficeID)
        If reader Is Nothing Then Exit Sub
        Do Until reader.Read = False
            cboAttorneysCompanyID.Items.Add(New ValueDescription(CLng(Val(reader("CompanyID").ToString)), reader("CompanyName").ToString & " - " & reader("AttorneyName").ToString))
        Loop
        cboAttorneysCompanyID.SelectedIndex = -1
        reader.Close() : reader.Dispose()
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If cboBillStatus.SelectedIndex = -1 Then
            MsgBox("Unable to process update." & vbCrLf & "The new status should be selected.", MsgBoxStyle.Exclamation)
            cboBillStatus.Focus()
            Exit Sub
        End If
        If Val(CType(cboBillStatus.SelectedItem, ValueDescription).Value) = Val(CurrentStatusID) Then
            MsgBox("Unable to process update." & vbCrLf & "The new status is the same as the current bill status.", MsgBoxStyle.Exclamation)
            cboBillStatus.Focus()
            Exit Sub
        End If
        Select Case CType(cboBillStatus.SelectedItem, ValueDescription).Value
            Case 4, 5
                If cboAttorneysCompanyID.SelectedIndex = -1 Then
                    MsgBox("Unable to process update." & vbCrLf & "The Attorney should be selected.", MsgBoxStyle.Exclamation)
                    cboAttorneysCompanyID.Focus()
                    Exit Sub
                End If
        End Select
        If txtComments.Text.Trim = "" Then
            MsgBox("Unable to process update." & vbCrLf & "The Bill Status change Comments required.", MsgBoxStyle.Exclamation)
            txtComments.Focus()
            Exit Sub
        End If


        Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
        If Suppervisor.SupervisorName = "" Then Exit Sub

        If MsgBox("Please confirm you want to update bill status to " & CType(cboBillStatus.SelectedItem, ValueDescription).Description & "?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Select Case CType(cboBillStatus.SelectedItem, ValueDescription).Value
            Case 4, 5
                gSQLUpdateData("Update Bills Set BillStatusID = " & CType(cboBillStatus.SelectedItem, ValueDescription).Value & ", AttorneyCompanyID = " & CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Value & ", AttorneyDate = '" & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & "' where BillID = " & BillID)

                CalledBillStatusDateSI.Text = DateTimePicker1.Value.Date.ToString("MM/dd/yyyy")
                CalledBillStatusAttorneySI.Text = CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Description
                CalledBillStatusAttorneySI.Tag = CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Value
            Case Else
                gSQLUpdateData("Update Bills Set BillStatusID = " & CType(cboBillStatus.SelectedItem, ValueDescription).Value & " where BillID = " & BillID)
        End Select

        gUpdate_Profile_Log(PatientID, PatientLogTypes.tBillChanged, "Bill Status Updated. Old Bill Status: " & CalledBillStatusSI.Text & " New Bill Status: " & CType(cboBillStatus.SelectedItem, ValueDescription).Description, SupervisorName)


        Select Case CType(cboBillStatus.SelectedItem, ValueDescription).Value
            Case 1
                CalledBillStatusSI.BackColor = Color.Black
            Case 2
                'gSetListItemColor(Li, Color.LightSteelBlue)
                CalledBillStatusSI.BackColor = Color.LightSteelBlue
            Case 3
                'gSetListItemColor(Li, Color.Green)
                CalledBillStatusSI.BackColor = Color.LightGreen
            Case 4, 5, 10, 11
                'gSetListItemColor(Li, Color.Orange)
                CalledBillStatusSI.BackColor = Color.DarkOrange
            Case 6, 7
                'gSetListItemColor(Li, Color.Red)
                CalledBillStatusSI.BackColor = Color.DarkSalmon
            Case 8
                'gSetListItemColor(Li, Color.Gainsboro)
                CalledBillStatusSI.BackColor = Color.Gainsboro
        End Select

        gSQLUpdateData("INSERT INTO BillComments (BillID, Comment, InsertedBy, InsertedDT) VALUES(" & BillID & ", '" & txtComments.Text.Trim.ToSafeSQLString() & "', " & gCurrentEmployee.EmpID & ", getdate())")

        CalledBillStatusSI.Text = CType(cboBillStatus.SelectedItem, ValueDescription).Description
        CalledBillStatusSI.Tag = CType(cboBillStatus.SelectedItem, ValueDescription).Value
        Me.Close()
    End Sub

    Private Sub cboBillStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillStatus.SelectedIndexChanged
        If cboBillStatus.SelectedIndex = -1 Then Exit Sub
        Select Case CType(cboBillStatus.SelectedItem, ValueDescription).Value
            Case 4, 5
                cboAttorneysCompanyID.Visible = True
                If cboAttorneysCompanyID.Items.Count = 1 Then
                    cboAttorneysCompanyID.SelectedIndex = 0
                End If
                Label7.Visible = True
                DateTimePicker1.Visible = True
                Label8.Visible = True
                PanelAttorney.Visible = True
            Case Else
                cboAttorneysCompanyID.Visible = False
                cboAttorneysCompanyID.SelectedIndex = -1
                Label7.Visible = False
                DateTimePicker1.Visible = False
                Label8.Visible = False
                PanelAttorney.Visible = False
        End Select
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