Public Class frmBillingProcedureDoNotBill
    Public PatientID As Integer
    Public ProcID As Integer
    Public PatientProcedureID As Integer
    Public ApprovedByName As String
    Private Sub frmBillingProcedureDoNotBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If gOfficeTypeID = 2 Then
            ComboBox1.Visible = False
            Label3.Visible = False
            Me.Height = 231
        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim ScheduleID As Integer
        TextBox1.Text = TextBox1.Text.Trim
        If TextBox1.Text = "" Then
            MsgBox("Unable to process your request." & vbCrLf & "Please specify the Do Not Bill Reason!", MsgBoxStyle.Critical)
            TextBox1.Focus()
            Exit Sub
        End If
        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            If ComboBox1.SelectedIndex = -1 Then
                MsgBox("Unable to process your request." & vbCrLf & "Please specify Bill Action!", MsgBoxStyle.Critical)
                ComboBox1.Focus()
                Exit Sub
            End If
        End If
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tProcedureDoNotBill, "Procedure: " & LabelProcedure.Text, ApprovedByName)
        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            If ComboBox1.SelectedIndex = 0 Then
                ScheduleID = gSQLGetSingleValue("Select ScheduleID from PatientProcedures where PatientProcedureID = " & PatientProcedureID)
                'gSQLUpdateData("Delete From Schedule Where ScheduleID = " & ScheduleID)
                'gSQLUpdateData("Update PatientProcedures set ScheduleID=Null, ProcedureStatusID = 3, DoNotBillAction=" & ComboBox1.SelectedIndex & ", DoNotBillInd=1, Comments=isnull(comments,'')+' " & RBC(TextBox1.Text) & "' Where PatientProcedureID= " & PatientProcedureID & " ")
                gSQLUpdateData("Update PatientProcedures set  DoNotBillAction=" & ComboBox1.SelectedIndex & ", DoNotBillInd=1, Comments=isnull(comments,'')+' " & TextBox1.Text.ToSafeSQLString() & "' Where PatientProcedureID= " & PatientProcedureID & " ")
            Else
                gSQLUpdateData("Update PatientProcedures set ProcedureStatusID = 0, DoNotBillAction=" & ComboBox1.SelectedIndex & ", DoNotBillInd=1, Comments=isnull(comments,'')+' " & TextBox1.Text.ToSafeSQLString() & "' Where PatientProcedureID= " & PatientProcedureID & " ")
            End If
        Else
            gSQLUpdateData("Update PatientProcedures set DoNotBillAction=0, DoNotBillInd=1, Comments=isnull(comments,'')+' " & TextBox1.Text.ToSafeSQLString() & "' Where PatientProcedureID= " & PatientProcedureID & " ")
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub
End Class