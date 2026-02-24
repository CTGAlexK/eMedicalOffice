Public Class frmNotes

    Private Sub frmNotes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub

    Private Sub frmNotes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub frmNotes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

    End Sub
    Private Sub frmNotes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
    End Sub

    Private Sub frmNotes_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        FpSpreadNotes.ActiveSheet.Columns(0).Width = FpSpreadNotes.Width - SystemInformation.VerticalScrollBarWidth
    End Sub

    Private Sub frmNotes_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd

    End Sub

    Private Sub FpSpreadResults_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadNotes.CellClick

    End Sub

    Private Sub FpSpreadResults_EditModeOff(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpreadNotes.EditModeOff

    End Sub
    Dim Loc As Integer
    Private Sub FpSpreadResults_EditModeOn(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpreadNotes.EditModeOn
      

    End Sub

    Private Sub FpSpreadNotes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FpSpreadNotes.KeyUp
       
    End Sub
End Class