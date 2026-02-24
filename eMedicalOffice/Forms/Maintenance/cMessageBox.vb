Public Class cMessageBox
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonYes.Click
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub
    Private c As Integer 
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        c=c+1
        PictureBoxSign.Visible = not PictureBoxSign.Visible 
        If c > 30 Then
            Timer1.Enabled=False
            PictureBoxSign.Visible = True 
        End If
    End Sub

    Private Sub cMessageBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled=True
    End Sub
End Class