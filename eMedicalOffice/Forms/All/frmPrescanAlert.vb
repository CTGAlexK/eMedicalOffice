Public Class frmPrescanAlert
    Public CaseType As Integer
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then

            MsgBox("Please check verification status.", MsgBoxStyle.Critical)
            RadioButton1.Focus()
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub frmPrescanAlert_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If CaseType < 3 Then
            Label4.Text = "If Any of These Conditions is Positive - The Radiology Procedure is Not Allowed!"
        Else
            Label4.Text = "If Any of These Conditions is Positive - The Patient's Acknowledgement Signature Is Required!" & vbCrLf & vbCrLf
        End If
    End Sub
End Class