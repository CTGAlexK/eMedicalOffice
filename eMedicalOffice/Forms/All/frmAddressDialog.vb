Public Class frmAddressDialog
    Public RetResult As Integer = 1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RetResult = 1
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RetResult = 2
        Me.Hide()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        RetResult = 3
        Me.Hide()
    End Sub


    Private Sub RoundButton1_ButtonClick()
        RetResult = 3
        Me.Hide()
    End Sub

    Private Sub RoundButton2_ButtonClick()
        RetResult = 2
        Me.Hide()
    End Sub

    Private Sub RoundButton3_ButtonClick()
        RetResult = 1
        Me.Hide()
    End Sub

    Private Sub RoundButton3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Dim I As Double = 0.001
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        I = I + 0.006
        Me.Opacity += I
        If Me.Opacity >= 1 Then
            Timer1.Enabled = False
        End If


    End Sub

    Private Sub frmAddressDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.Lock, AudioPlayMode.Background)
        Timer1.Enabled = True
    End Sub
End Class