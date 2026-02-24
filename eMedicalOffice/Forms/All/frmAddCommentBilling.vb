Imports System.Reflection
Imports log4net

Public Class frmAddCommentBilling
    Dim log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public BillID As Long
    Public ReminderID As Integer
    Public CompleteInd As Boolean
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If CheckBoxComplete.Visible Then
            If CheckBoxComplete.Checked = False Then
                ErrorProvider1.SetError(CheckBoxComplete, "Confirmation Required.")
                MsgBox("Unable to process update." & vbCrLf & vbCrLf & "Please confirm the reminder completion" & vbCrLf & "by checking the Reminder Complete box.", MsgBoxStyle.Exclamation)
                CheckBoxComplete.Focus()
                Exit Sub
            End If

            If TextBoxComment.Text.Trim = "" Then
                If MsgBox("You have not specified any completion comments." & vbCrLf & vbCrLf & "It is highly recommended to save comments on any bill collection actions." & vbCrLf & vbCrLf & "Would you like to continue with no comments?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    TextBoxComment.Focus()
                    Exit Sub
                End If
            End If
        Else
            If TextBoxComment.Text.Trim = "" Then
                ErrorProvider1.SetError(TextBoxComment, "Information Required")
                If DateTimePicker1.Checked Then
                    MsgBox("Unable to process update." & vbCrLf & "No Reminder Information Specified.", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("Unable to process update." & vbCrLf & "No Information Specified.", MsgBoxStyle.Exclamation)
                End If
                TextBoxComment.Focus()
                Exit Sub
            End If

        End If
        Try
            If CheckBoxComplete.Visible Then
                If TextBoxComment.Text.Trim <> "" Then
                    gSQLUpdateData("UPDATE BillComments set ReminderCompleteInd=1, ReminderCompleteBy=" & gCurrentEmployee.EmpID & ", ReminderCompleteDT=getdate(), Comment = Comment + '" & vbCrLf & TextBoxComment.Text.Trim & vbCrLf & "Completed by " & (gCurrentEmployee.FName & " " & gCurrentEmployee.LName).ToSafeSQLString() & " On " & Now.ToShortDateString & "' where CommentID=" & ReminderID)
                Else
                    gSQLUpdateData("UPDATE BillComments set ReminderCompleteInd=1, ReminderCompleteBy=" & gCurrentEmployee.EmpID & ", ReminderCompleteDT=getdate(), Comment = Comment + '" & vbCrLf & "Completed by " & (gCurrentEmployee.FName & " " & gCurrentEmployee.LName).ToSafeSQLString() & " On " & Now.ToShortDateString & "' where CommentID=" & ReminderID)
                End If
                If DateTimePicker1.Checked Then
                    Dim TR As DataRow
                    Using TA = New SqlClient.SqlDataAdapter("SELECT * FROM BillComments Where 1=2", gConnectionString)
                        Using CB = New SqlClient.SqlCommandBuilder(TA)
                            CB.ConflictOption=ConflictOption.OverwriteChanges
                            Using dTab = New DataTable("BillComments")
                                TA.Fill(dTab)
                                TR = dTab.NewRow
                                TR("BillID") = BillID
                                TR("Comment") = TextBoxComment.Text.Trim
                                TR("InsertedBy") = gCurrentEmployee.EmpID.ToString
                                TR("InsertedDT") = Now
                                TR("ReminderCompleteInd") = 0
                                TR("ReminderCompleteBy") = 0
                                TR("ReminderDT") = DateTimePicker1.Value.ToShortDateString

                                dTab.Rows.Add(TR)
                                TA.UpdateCommand = CB.GetUpdateCommand(True)
                                Try
                                    TA.Update(dTab)
                                    dTab.AcceptChanges()
                                Catch ex As Exception
                                    TopMost=False
                                    msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
                                    log.Error(ex.Message, ex)
                                    Exit Sub
                                End Try
                                dTab.Dispose() : CB.Dispose() : TA.Dispose()
                            End Using
                        End Using
                    End Using
                End If

            Else
                Dim TR As DataRow
                Using TA = New SqlClient.SqlDataAdapter("SELECT * FROM BillComments Where 1=2", gConnectionString)
                    Using CB = New SqlClient.SqlCommandBuilder(TA)
                        CB.ConflictOption=ConflictOption.OverwriteChanges
                        Using dTab = New DataTable("BillComments")
                            TA.Fill(dTab)
                            TR = dTab.NewRow
                            TR("BillID") = BillID
                            TR("Comment") = TextBoxComment.Text.Trim
                            TR("InsertedBy") = gCurrentEmployee.EmpID.ToString
                            TR("InsertedDT") = Now
                            TR("ReminderCompleteInd") = 0
                            TR("ReminderCompleteBy") = 0
                            If DateTimePicker1.Checked Then
                                TR("ReminderDT") = DateTimePicker1.Value.ToShortDateString
                            End If
                            dTab.Rows.Add(TR)
                            TA.UpdateCommand = CB.GetUpdateCommand(True)
                            Try
                                TA.Update(dTab)
                                dTab.AcceptChanges()
                            Catch ex As Exception
                                TopMost=False
                                msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
                                log.Error(ex.Message, ex)
                                Exit Sub
                            End Try
                            dTab.Dispose() : CB.Dispose() : TA.Dispose()
                        End Using
                    End Using
                End Using
            End If
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmAddComment_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            TextBoxComment.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmAddCommentBilling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim I As Integer
        Panel3.Visible = gCollectionFunction
        'If CompleteInd = True Then Panel3.Visible = False
        DateTimePicker1.MinDate = Now.Date
        DateTimePicker1.Checked = False
        cboDays.Items.Add("No Reminder")
        For I = 0 To 45
            Select Case I
                Case 0
                    cboDays.Items.Add("Today")
                Case 1
                    cboDays.Items.Add("Tomorrow")
                Case 21, 31, 41
                    cboDays.Items.Add("In " & I & " Day")
                Case Else
                    cboDays.Items.Add("In " & I & " Days")
            End Select
        Next

    End Sub
    Private SetByCombo As Boolean
    Private SetByDTPicker As Boolean
    Private Sub cboDays_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDays.SelectedIndexChanged
        If SetByDTPicker = False Then
            SetByCombo = True
            If cboDays.SelectedIndex > 0 Then

                DateTimePicker1.Value = DateAdd(DateInterval.Day, cboDays.SelectedIndex - 1, Now.Date)
                DateTimePicker1.Checked = True

            Else
                DateTimePicker1.Value = Now.Date
                DateTimePicker1.Checked = False
            End If
            SetByCombo = False
        End If
        If DateTimePicker1.Checked Then
            PictureBox2.Image = ImageOrange.Image
        Else
            PictureBox2.Image = ImageGray.Image
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If SetByCombo = False Then
            If DateTimePicker1.Checked Then
                SetByDTPicker = True
                If DateDiff(DateInterval.Day, Now.Date, DateTimePicker1.Value.Date) < 46 Then

                    cboDays.SelectedIndex = DateDiff(DateInterval.Day, Now.Date, DateTimePicker1.Value.Date) + 1
                Else
                    cboDays.SelectedIndex = -1
                End If
                SetByDTPicker = False
            Else
                SetByDTPicker = True
                cboDays.SelectedIndex = 0
                SetByDTPicker = False
            End If

        End If
        If DateTimePicker1.Checked Then
            PictureBox2.Image = ImageOrange.Image
        Else
            PictureBox2.Image = ImageGray.Image
        End If
    End Sub

    Private Sub TextBoxComment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxComment.TextChanged
        ErrorProvider1.SetError(TextBoxComment, "")
    End Sub

    Private Sub CheckBoxComplete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxComplete.CheckedChanged
        ErrorProvider1.SetError(CheckBoxComplete, "")
    End Sub


End Class