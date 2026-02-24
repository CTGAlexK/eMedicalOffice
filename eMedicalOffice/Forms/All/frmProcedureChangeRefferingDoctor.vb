Public Class frmProcedureChangeRefferingDoctor
    Public ReferringCompanyID As Long
    Public PatientProcedureID As Long
    Public PatientID As Long

    Private Sub frmProcedureChangeRefferingDoctor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
    End Sub

    Private Sub Load_Data()
        Dim reader As SqlClient.SqlDataReader
        ComboBoxReferringDoctor.Items.Clear()
        ComboBoxReferringDoctor.Text = ""
        reader = gSQLGetDataReader("Select * from ReferringOffices Where ReferringOffices.OfficeID =" & ReferringCompanyID)
        If reader Is Nothing Then Exit Sub
        Do Until reader.Read = False
            For d As Integer = 1 To gReferringOfficeDoctors
                If reader("Doctor" + d.ToString()).ToString.Trim <> "" And reader("Doctor" + d.ToString()).ToString.Trim <> LabelCurrentDoctor.Text.Trim() Then
                    ComboBoxReferringDoctor.Items.Add(New ValueDescription(0, reader("Doctor" + d.ToString()).ToString.Trim, reader("Doctor" + d.ToString() + "Phone").ToString.Trim))
                    'ComboBoxReferringDoctor.Items.Add(reader("Doctor" + d.ToString()).ToString.Trim)
                End If
            Next
        Loop
        If ComboBoxReferringDoctor.Items.Count = 0 Then
            ComboBoxReferringDoctor.Items.Add("No Other Referring Doctors Found In The Patient's Referring Office.")
            ComboBoxReferringDoctor.SelectedIndex = 0
            'ComboBoxReferringDoctor.Enabled = False
            cmdUpdate.Enabled = False
        End If
        reader.Close() : reader.Dispose()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If ComboBoxReferringDoctor.SelectedIndex = -1 Then
            MsgBox("Unable to process your request." & vbCrLf & "No Reffering Doctor selected.", MsgBoxStyle.Exclamation)
            ComboBoxReferringDoctor.Focus()
            Exit Sub
        End If
        If LabelCurrentDoctor.Text.Trim = ComboBoxReferringDoctor.Text.Trim Then
            MsgBox("Unable to process your request." & vbCrLf & "No Reffering Doctor changed.", MsgBoxStyle.Exclamation)
            ComboBoxReferringDoctor.Focus()
            Exit Sub
        End If
        'gSQLUpdateData("Update PatientProcedures set ReferringDoctor='" & RBC(ComboBoxReferringDoctor.Text) & "' Where PatientProcedureID=" & PatientProcedureID)
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tUpdated, "Referring Doctor Changed From: & " & LabelCurrentDoctor.Text & " To: " & ComboBoxReferringDoctor.Text)
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class