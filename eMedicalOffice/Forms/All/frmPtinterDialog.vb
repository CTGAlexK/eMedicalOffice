Public Class frmPtinterDialog

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity = Me.Opacity + 0.05
        If Me.Opacity >= 1 Then
            Me.Opacity = 1
            Timer1.Enabled = False
        End If
    End Sub

End Class