Public Class frmIntakeForm

    Private Sub frmIntakeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBoxBillingProvider_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBoxBillingProvider.DrawItem
        If e.Index < 0 Then
            e.DrawBackground()
            e.DrawFocusRectangle()
            Exit Sub
        End If
        Dim CurrentColor As Color

        CurrentColor = Color.FromArgb(CType(ComboBoxBillingProvider.Items(e.Index), ValueDescription).Value1)
        'Dim SizeRect As Rectangle = New Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height)
        Dim SizeRect As Rectangle = New Rectangle(e.Bounds.Width - 40, e.Bounds.Top + 2, 40, e.Bounds.Height - 4)
        Dim ComboBrush As Brush
        e.DrawBackground()
        e.DrawFocusRectangle()
        e.Graphics.FillRectangle(New SolidBrush(CurrentColor), SizeRect)
        ' change brush color if item is selected
        ComboBrush = Brushes.Black
        e.Graphics.DrawString(CType(ComboBoxBillingProvider.Items(e.Index), ValueDescription).Description, ComboBoxBillingProvider.Font, ComboBrush, e.Bounds.Left, ((e.Bounds.Height - ComboBoxBillingProvider.Font.Height) \ 2) + e.Bounds.Top)

    End Sub

    Private Sub ComboBoxBillingProvider_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxBillingProvider.SelectedIndexChanged

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If ComboBoxBillingProvider.SelectedIndex = -1 Then
            MsgBox("Unable to print Intake Form" & vbCrLf & "Please select a Billing Provider", MsgBoxStyle.Exclamation)
            ComboBoxBillingProvider.Focus()
            Exit Sub
        End If
        MDIForm1Win8.BillingProviderID = CType(ComboBoxBillingProvider.SelectedItem, ValueDescription).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class