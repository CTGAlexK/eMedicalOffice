Public Class frmServiceStatus
    Public CalledLI As ListViewItem
    Public CalledSI As ListViewItem.ListViewSubItem
    Public Message As String
    Public FutureDate As Boolean
    Public ScheduledDate
    Public ActionName As String
    Private Sub frmServiceStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim Msg As String
        If IsNothing(ScheduledDate) = False Then
            If IsDate(ScheduledDate.ToString) Then
                If DateTimePicker1.Value.Date < CDate(CDate(ScheduledDate).ToString("MM/dd/yyyy")) Then
                    MsgBox("Unable to update." & vbCrLf & vbCrLf & "Service Schedule Date: " & ScheduledDate.ToString & vbCrLf & "Selected " & Label1.Text & ": " & DateTimePicker1.Value.Date & vbCrLf & vbCrLf & vbCrLf & "The " & Label1.Text & " date can not be earlier then the Scheduled Date.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
        End If
        If FutureDate Then
            If DateTimePicker1.Value.Date < Now.Date Then
                Msg = vbCrLf & vbCrLf & vbCrLf & "Attention!" & vbCrLf & "The selected " & Label1.Text & " is past date."
            End If
        Else
            If DateTimePicker1.Value.Date > Now.Date Then
                Msg = vbCrLf & vbCrLf & vbCrLf & "Attention!" & vbCrLf & "The selected " & Label1.Text & " is future date."
            End If
        End If
        If MsgBox(Message & DateTimePicker1.Value.Date & Msg, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            DateTimePicker1.Focus()
            Exit Sub
        End If
        CalledSI.Text = DateTimePicker1.Value.Date & " " & DateTimePicker1.Value.ToString("h:mm tt")


        CalledSI.ForeColor = Color.DarkOrange
        Me.DialogResult = Windows.Forms.DialogResult.OK
        ' Update
        Me.Close()
    End Sub
End Class