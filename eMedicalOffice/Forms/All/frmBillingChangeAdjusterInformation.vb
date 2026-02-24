Public Class frmBillingChangeAdjusterInformation
    Public pPatientID As Integer

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If txtAdjuster.Text.Trim = "" Then
            If MsgBox("The Adjuster name is not specified." & vbCrLf & "Do you want to continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                txtAdjuster.Focus()
                Exit Sub
            End If
        End If
        txtAdjusterPhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
        If txtAdjusterPhone.Text = "" Then
            If MsgBox("The Adjuster Phone Number is not specified." & vbCrLf & "Do you want to continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                txtAdjusterPhone.Focus()
                Exit Sub
            End If
        End If
        txtAdjusterPhone.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
        gUpdate_Profile_Log(Val(pPatientID), PatientLogTypes.tUpdated, "Patient Adjuster information updated. All Bills Updated.")
        gSQLUpdateData("Update Bills set Adjuster = '" & txtAdjuster.Text.ToSafeSQLString() & "', AdjusterPhone = '" & txtAdjusterPhone.Text.ToSafeSQLString() & "' Where PatientID = " & Val(pPatientID))
        gSQLUpdateData("Update Patients set AdjusterName = '" & txtAdjuster.Text.ToSafeSQLString() & "', AdjusterPhone = '" & txtAdjusterPhone.Text.ToSafeSQLString() & "' Where PatientID = " & Val(pPatientID))
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub
End Class