Imports System.Reflection
Imports log4net

Public Class frmBillingLitigationArbitrationComments
    Public BillIDs() As Long
    Public Status As String
    Public CalledForm As frmBillingManagement
    Public CalledFormBillsForArbitration As frmBillsForArbitration
    Public AtterneyID As Integer
    Private log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim I As Long
        If TextBoxComment.Text.Trim = "" Then
            MsgBox("Unable to process update." & vbCrLf & vbCrLf & "The Bill Status Change comments is required.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ComboBoxAttorneys.SelectedIndex = -1 Then
            MsgBox("Unable to process update." & vbCrLf & vbCrLf & "The " & Status & " Attorney is required.", MsgBoxStyle.Exclamation)
            ComboBoxAttorneys.Focus()
            Exit Sub
        End If


        If MsgBox("Process " & BillIDs.Length & " bill(s) as " & Status & "." & vbCrLf & Status & " Attorney: " & CType(ComboBoxAttorneys.SelectedItem, ValueDescription).Description & vbCrLf & vbCrLf & "Please confirm?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Try
            For I = 0 To BillIDs.Length - 1
                Dim TR As DataRow
                Using TA = New SqlClient.SqlDataAdapter("SELECT * FROM BillComments Where 1=2", gConnectionString)
                    Using CB = New SqlClient.SqlCommandBuilder(TA)
                        CB.ConflictOption=ConflictOption.OverwriteChanges
                        Using dTab = New DataTable("BillComments")
                            TA.Fill(dTab)
                            TR = dTab.NewRow
                            TR("BillID") = BillIDs(I)
                            TR("Comment") = "Bill Status " & Status & ": " & TextBoxComment.Text.Trim
                            TR("InsertedBy") = gCurrentEmployee.EmpID.ToString
                            TR("InsertedDT") = Now
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
            Next
            AtterneyID = CType(ComboBoxAttorneys.SelectedItem, ValueDescription).Value
            If Not CalledForm Is Nothing Then
                CalledForm.AtterneyID = CType(ComboBoxAttorneys.SelectedItem, ValueDescription).Value
                CalledForm.AtterneyName = CType(ComboBoxAttorneys.SelectedItem, ValueDescription).Description
            End If
            If Not CalledFormBillsForArbitration Is Nothing Then
                CalledFormBillsForArbitration.AtterneyID = CType(ComboBoxAttorneys.SelectedItem, ValueDescription).Value
                CalledFormBillsForArbitration.AtterneyName = CType(ComboBoxAttorneys.SelectedItem, ValueDescription).Description
            End If


            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If MsgBox("The status change [" & Status & "]." & vbCrLf & "The status comments required." & vbCrLf & "Are you sure you want to cancel status change?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Me.Close()
    End Sub

    Private Sub frmAddComment_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            TextBoxComment.Focus()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub frmBillingLitigationArbitrationComments_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
         gListview_Settings(Me, ListViewPatients, ReadWrite.sWrite)
    End Sub
    Private Sub frmBillingLitigationArbitrationComments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListViewPatients, ReadWrite.sRead)
        Load_Attorneys()
    End Sub
    Private Sub Load_Attorneys()
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("Select * from Attorneys where OfficeID = " & gOfficeID & " Order by CompanyName")
        If Reader Is Nothing Then Exit Sub
        ComboBoxAttorneys.Items.Clear()
        Do Until Reader.Read = False
            ComboBoxAttorneys.Items.Add(New ValueDescription(Reader("CompanyID").ToString, Reader("CompanyName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        If ComboBoxAttorneys.Items.Count = 1 Then
            ComboBoxAttorneys.SelectedIndex = 0
        End If

    End Sub
End Class