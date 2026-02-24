Imports System.Reflection
Imports log4net

Public Class frmReportPatientVisitsProceduresByPaqtientSearch
    Private log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public CalledForm As frmReportPatientVisitsProceduresByPatient
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If ListViewPatients.SelectedItems.Count = 0 Then
                MsgBox("Unable to create report. No Patient selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            CalledForm.PatientID = ListViewPatients.SelectedItems(0).Tag
            CalledForm.PatientName = ListViewPatients.SelectedItems(0).ToolTipText
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub frmReportPatientVisitsProceduresByPaqtientSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class