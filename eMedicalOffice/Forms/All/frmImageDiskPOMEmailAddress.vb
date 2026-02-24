Public Class frmImageDiskPOMEmailAddress
    Public SelectedEmailRecipient As Integer
    Public CalledForm As frmImageDiskPOM
    Private Sub frmImageDiskPOMEmailAddress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        SelectedEmailRecipient = -1
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then SelectedEmailRecipient = 1
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If RadioButton1.Checked Then
            CalledForm.SelectedEmailRecipient = 1
        ElseIf RadioButton2.Checked Then
            CalledForm.SelectedEmailRecipient = 0
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub
End Class