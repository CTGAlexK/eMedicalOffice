Public Class frmBillingSelectLower
    Public CalledForm As frmBillingManagement
    Public ApprovedByID As Long
    Public ApprovedByName As String
    Public HideLitigationChoice As Boolean = False

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If ComboBoxAttorneys.SelectedIndex = -1 Then
            MsgBox("Unable to process. No attorney selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        CalledForm.AtterneyID = CType(ComboBoxAttorneys.SelectedItem, ValueDescription).Value
        CalledForm.AtterneyName = CType(ComboBoxAttorneys.SelectedItem, ValueDescription).Description
        If HideLitigationChoice = False Then
            If RadioButton1.Checked Then
                CalledForm.StatusID = 4
            Else
                If gCurrentEmployee.PositionID > 3 Then
                    frmSupervisorApproval.LabelMsg.Text = "In case of denial, invoices will be processed as Arbitration"
                    If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                        frmSupervisorApproval.Dispose()
                        Exit Sub
                    End If
                    ApprovedByID = frmSupervisorApproval.SupervisorID
                    ApprovedByName = frmSupervisorApproval.SupervisorName
                    frmSupervisorApproval.Dispose()
                Else
                    If MsgBox("Please Confirm in case of denial, these invoices will be processed as Arbitration?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    ApprovedByID = gCurrentEmployee.EmpID
                    ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
                End If
                CalledForm.StatusID = 5
            End If
        End If
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private CloseSelected As Boolean
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        CloseSelected = True
        Me.Close()
    End Sub

    Private Sub frmAddComment_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            ComboBoxAttorneys.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmBillingSelectLower_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If HideLitigationChoice = False Then
            If CalledForm.AtterneyID = 0 Then
                If CloseSelected = False Then
                    If MsgBox("The attorney selection is required for the process - Send To Atterney." & vbCrLf & vbCrLf & "Cancel Process?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        e.Cancel = True
                        Exit Sub
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub frmBillingSelectLower_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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