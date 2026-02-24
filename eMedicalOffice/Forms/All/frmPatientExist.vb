Public Class frmPatientExist
    Public CalledForm As frmPatient

    Private Sub frmPatientExist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count > 0 Then
            cmdUpdate_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowProfile.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to show profile. No Patient selected.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
            Exit Sub
        End If
        CalledForm.RetPatientName = ListView1.SelectedItems(0).SubItems(2).Text & " " & ListView1.SelectedItems(0).SubItems(3).Text
        Using FRM As New frmPatient

            With FRM
                .Width = 733
                .PanelSearch.Left = -10000
                .cmdClose.Visible = True
                .cmdAddNew.Visible = False
                .cmdEdit.Visible = False
                .ToolStripProcedures.Visible = False
                .cmdCancel.Visible = False
                .cmdUpdate.Visible = False
                .InitialTab = 0
                .InitialPatientName = CalledForm.RetPatientName
                .InitialEdit = False
                .HideCalledForm = Me
                .MinimizeBox = False
                .MaximizeBox = False
                .Opacity = 0
                cmdShowProfile.Text = "Loading.Please wait..."
                cmdShowProfile.Enabled = False
                cmdClose.Enabled = False
                Cursor = Cursors.WaitCursor
                Application.DoEvents()
                .MinimizeBox = False
                .MaximizeBox = False

                .ShowDialog(Me)
                cmdClose.Enabled = True
                cmdShowProfile.Enabled = True
                cmdShowProfile.Text = "Show Patient Profile"
                Do Until Me.Opacity >= 1
                    Me.Opacity = Me.Opacity + 0.01
                    Threading.Thread.Sleep(5)
                    Application.DoEvents()
                Loop

                Me.Opacity = 1
                .Dispose()
            End With
        End Using
        'Me.DialogResult = Windows.Forms.DialogResult.OK
        'Me.Close()
    End Sub

End Class