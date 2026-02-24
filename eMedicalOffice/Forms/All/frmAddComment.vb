Imports System.Reflection
Imports log4net

Public Class frmAddComment
    Dim log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public txtComments As TextBox
    Public ListViewComments As ListView
    Public PatientID As Long = 0

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim LI As ListViewItem
        If TextBoxComment.Text.Trim = "" Then
            MsgBox("Unable to process update. No Comments.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Try
            txtComments.Text = TextBoxComment.Text.Trim
            Dim TR As DataRow
            Using TA = New SqlClient.SqlDataAdapter("SELECT * FROM PatientComments Where 1=2", gConnectionString)
                Using CB = New SqlClient.SqlCommandBuilder(TA)
                    CB.ConflictOption = ConflictOption.OverwriteChanges
                    Using dTab = New DataTable("PatientComments")
                        TA.Fill(dTab)
                        TR = dTab.NewRow
                        TR("PatientID") = PatientID
                        TR("Comment") = TextBoxComment.Text.Trim
                        TR("InsertedBy") = gCurrentEmployee.EmpID.ToString
                        TR("InsertedDT") = Now
                        dTab.Rows.Add(TR)
                        TA.UpdateCommand = CB.GetUpdateCommand(True)
                        Try
                            TA.Update(dTab)
                            dTab.AcceptChanges()
                        Catch ex As Exception
                            TopMost = False
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                            log.Error(ex.Message, ex)
                            Exit Sub
                        End Try
                        dTab.Dispose() : CB.Dispose() : TA.Dispose()
                    End Using
                End Using
            End Using
            If Not ListViewComments Is Nothing Then
                LI = ListViewComments.Items.Add(Now.ToString)
                LI.SubItems.Add(TextBoxComment.Text.Trim)
                LI.SubItems.Add(gCurrentEmployee.FName & " " & gCurrentEmployee.LName)
                LI.Selected = True
                LI.Tag = gSQLGetSingleValue("Select IDENT_CURRENT('PatientComments')")
                LI.EnsureVisible()
            End If
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
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

    Private Sub frmAddComment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class