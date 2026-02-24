Public Class frmScheduleCancelationReason
    Public CancelReason As Label

    Private Sub frmScheduleCancelationReason_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
        TextBox1.Focus()
    End Sub
    Private Sub frmScheduleCancelationReason_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LabelCanceledBy.Text = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If TextBox1.Text = "" Then
            MsgBox("Unable to cancel appointment. The cancelation reason should be specified.", MsgBoxStyle.Exclamation)
            TextBox1.Focus()
            Exit Sub
        End If
        CancelReason.Text = TextBox1.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class