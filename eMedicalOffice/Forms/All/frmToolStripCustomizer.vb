Public Class frmToolStripCustomizer
    Public TS As ToolStrip
    Public Sub LoadToolStrip(ByVal TS As ToolStrip)
        Dim TSi As ToolStripItem
        Dim I As Integer
        Dim LI As ListViewItem
        For Each TSi In TS.Items

            I = I + 1
            If TypeOf TSi Is ToolStripSeparator Then
                LI = ListView1.Items.Add("Separator", "Separator")
                LI.Checked = TSi.Visible
                LI.Tag = TSi
                LI.IndentCount = 1
            Else
                If TSi.Text <> "" And Not TSi.Image Is Nothing Then
                    If TSi.Text = "e-File" And gEnableElectronicBillFiling = 0 Then Continue For
                    ImageList1.Images.Add("K" & I, TSi.Image)
                    LI = ListView1.Items.Add(TSi.Text, "K" & I)
                    LI.Checked = TSi.Visible
                    LI.Tag = TSi
                    LI.IndentCount = 1
                End If
            End If

        Next

    End Sub

    Private Sub frmToolStripCustomizer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListView1.Columns(0).Width = ListView1.Width - 40
        Timer1.Enabled = True
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub ButtonUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdate.Click
        Dim LI As ListViewItem
        For Each LI In ListView1.Items
            CType(LI.Tag, ToolStripItem).Visible = LI.Checked
        Next
        Me.Close()
    End Sub

    Private Sub cmdRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRestore.Click
        Dim LI As ListViewItem
        For Each LI In ListView1.Items
            CType(LI.Tag, ToolStripItem).Visible = True
        Next
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity += 0.03
        If Me.Opacity >= 1 Then Me.Opacity = 1 : Timer1.Enabled = False
    End Sub
End Class