Public Class frmReCertificationExpDate
    Private Sub frmReCertificationExpDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.MinDate = CDate(DateTime.Now.ToShortDateString)
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        DialogResult = DialogResult.OK
    End Sub
End Class