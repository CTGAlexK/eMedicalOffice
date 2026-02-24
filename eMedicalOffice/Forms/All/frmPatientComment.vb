Imports System.Reflection
Imports log4net

Public Class frmPatientComment
    Private log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Public PatientID As Long = 0
    Public calledForm As Form
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If TextBoxComment.Text.Trim = "" Then
            MsgBox("Unable to process update. No Comments.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Try
            TextBoxComment.Text = TextBoxComment.Text.Trim
            gSQLUpdateData("Update Patients Set Comments = '" & TextBoxCommentExisting.Text.ToSafeSQLString() & vbCrLf & TextBoxComment.Text.ToSafeSQLString() & "' Where PatientID=" & PatientID)

            DirectCast(calledForm, frmSchedule).Show_Details(PatientID)
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmAddComment_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            TextBoxComment.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmPatientComment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class