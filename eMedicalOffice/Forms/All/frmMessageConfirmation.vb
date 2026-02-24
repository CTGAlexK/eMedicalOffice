Public Class frmMessageConfirmation
    Public MessageID As Long
    Public OriginalMessage As String
    Public HightPriority As Boolean
    Private Replyed As Boolean

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim SQL As String
        'Me.DialogResult = Windows.Forms.DialogResult.Cancel
        If txtReply.Text.Trim = "" Then
            MsgBox("Unable to send reply message." & vbCrLf & vbCrLf & "The reply message is required by administrator." & vbCrLf & vbCrLf & "No reply message specified.", MsgBoxStyle.Exclamation)
            txtReply.Focus()
            Exit Sub
        End If
        SQL = "UPDATE MessagesRecipients set Response='" & txtReply.Text.Trim.ToSafeSQLString() & "', ConfirmedDT = getdate() where ID=" & MessageID
        gSQLUpdateData(SQL)
        Dim OriginalMessageFromID As Integer = gSQLGetSingleValue("SELECT    CreatedBy FROM  Messages INNER JOIN MessagesRecipients ON Messages.MessageID = MessagesRecipients.MessageID WHERE  MessagesRecipients.ID = " & MessageID)
        SQL = "INSERT INTO Messages (MessageTitle, MessageBody, CreatedBy, CreatedDT, ResponseRequired) VALUES('Reply Received From " & ToSafeSQLString(gCurrentEmployee.FName & " " & gCurrentEmployee.LName) & "','" & OriginalMessage.ToSafeSQLString() & vbCrLf & "----------------  Reply  ----------------" & vbCrLf & txtReply.Text.Trim.ToSafeSQLString() & "', " & gCurrentEmployee.EmpID & ", getdate(), 0)"
        gSQLUpdateData(SQL)
        Dim MsgID As Integer = gSQLGetSingleValue("Select IDENT_CURRENT('Messages')")
        SQL = "INSERT INTO MessagesRecipients (MessageID, ToID) VALUES(" & MsgID & ", " & OriginalMessageFromID & ")"
        gSQLUpdateData(SQL)
        Replyed = True

        'Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmMessageConfirmation_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If txtReply.CanFocus Then txtReply.Focus()
    End Sub

    Private Sub frmMessageConfirmation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Replyed = False Then
            If HightPriority Then
                If MsgBox("Attention" & vbCrLf & "This is high priority messaage from administrator!" & vbCrLf & "Immidiate response is required!" & vbCrLf & vbCrLf & "Please confirm you want to postpone this message?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub frmMessageConfirmation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.Lock, AudioPlayMode.Background)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

    End Sub

End Class