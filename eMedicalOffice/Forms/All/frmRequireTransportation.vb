Public Class frmRequireTransportation
    Public CalledForm
    Private CancelSelected As Boolean
    Private Sub frmRequireTransportation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If CancelSelected = False Then
            If ComboBoxPickup.SelectedIndex = -1 Then
                MsgBox("Please select the Transportation Pickup Information.", MsgBoxStyle.Exclamation)
                ComboBoxPickup.Focus()
                e.Cancel = True
                Exit Sub
            End If
            If ComboBoxDestination.SelectedIndex = -1 Then
                MsgBox("Please select the Transportation Destination Information.", MsgBoxStyle.Exclamation)
                ComboBoxDestination.Focus()
                e.Cancel = True
                Exit Sub
            End If
            CalledForm.ReturnSchPickupTransportation = ComboBoxPickup.SelectedIndex
            CalledForm.ReturnSchDestinationTransportation = ComboBoxDestination.SelectedIndex
            CalledForm.ReturnSchPickupTransportationOther = "PU: " & txtPickupOther.text.trim() 
            CalledForm.ReturnSchDestinationTransportationOther = "DO: " & txtDestinationOther.text.trim()
        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        if ComboBoxpickup.SelectedIndex=3 and txtPickupOther.Text.Trim = "" Then
            MsgBox("Unable to update transportation." & vbCrLf & "Pickup Type - [Other], Pickup Address is required.",MsgBoxStyle.Exclamation,"Oops...")
            txtPickupOther.Enabled=true
            If txtPickupOther.CanSelect Then txtPickupOther.Focus()
            Return
        End If

        if ComboBoxDestination.SelectedIndex=3 and txtDestinationOther.Text.Trim = "" Then
            MsgBox("Unable to update transportation." & vbCrLf & "DropOff Type - [Other], DropOff Address is required.",MsgBoxStyle.Exclamation,"Oops...")
            txtDestinationOther.Enabled=true
            If txtDestinationOther.CanSelect Then txtDestinationOther.Focus()
            Return
        End If

        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ComboBoxPickup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxPickup.GotFocus
        If CalledForm.ReturnSchPickupTransportation = 0 And CalledForm.ReturnSchDestinationTransportation = 0 Then
            If ComboBoxPickup.SelectedIndex = -1 Then ComboBoxPickup.DroppedDown = True
        Else

        End If
    End Sub

    Private Sub ComboBoxDestination_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxDestination.GotFocus
        If ComboBoxDestination.SelectedIndex = -1 Then ComboBoxDestination.DroppedDown = True
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        CancelSelected = True
        Me.Close()
    End Sub

    Private Sub ComboBoxPickup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPickup.SelectedIndexChanged
        Application.DoEvents()
        if ComboBoxPickup.SelectedIndex=3 Then
            txtPickupOther.Enabled=true
            If txtPickupOther.CanSelect Then txtPickupOther.Focus()
        else
            txtPickupOther.Enabled=false
            If txtPickupOther.CanSelect Then txtPickupOther.Focus()
        End If
        
    End Sub

    Private Sub frmRequireTransportation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBoxDestination_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDestination.SelectedIndexChanged
        Application.DoEvents()
        if ComboBoxDestination.SelectedIndex=3 Then
            txtDestinationOther.Enabled=true
            If txtDestinationOther.CanSelect Then txtDestinationOther.Focus()
        else
            txtDestinationOther.Enabled=false
            If ComboBoxDestination.CanSelect Then ComboBoxDestination.Focus()
        End If
    End Sub

    Private Sub txtPickupOther_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPickupOther.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ComboBoxDestination.CanSelect Then ComboBoxDestination.Focus()
        end if
    End Sub

    Private Sub txtDestinationOther_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDestinationOther.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cmdOk.CanSelect Then cmdOk.Focus()
        end if
    End Sub

   
End Class