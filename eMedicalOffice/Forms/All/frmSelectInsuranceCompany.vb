Public Class frmSelectInsuranceCompany
    Public CalledForm As frmBillingManagement

    Private Sub frmSelectInsuranceCompany_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If DialogResult <> Windows.Forms.DialogResult.OK Then
            If MsgBox("The Insurance Company should be selected for the Bill ReProduction." & vbCrLf & vbCrLf & "Cancel Bill ReProduction process?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = vbNo Then
                ComboBox1.Focus()
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub
    Private Sub frmSelectInsuranceCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelect.Click
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Unable to process. The Insurance Company should be selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        CalledForm.SelectedInsCompanyIndex = ComboBox1.SelectedIndex
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class