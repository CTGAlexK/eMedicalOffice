Imports System.Reflection
Imports log4net

Public Class frmPatientRefferingDoctorPopUp
    Private log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Public RefferingDoctor As String
    Public ReferringCompanyID As Long
    Public ProcedureID As Long
    Public CalledListView As ListView
    Private Sub frmPatientTreatingProviderPopUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
    End Sub
    Private Sub Load_Data()
        Try
            Dim Reader As SqlClient.SqlDataReader
            ComboBoxRefferingDoctor.Items.Clear()

            ComboBoxRefferingDoctor.Items.Clear()
            Reader = gSQLGetDataReader("Select * from ReferringOffices Where OfficeID =" & ReferringCompanyID)
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    For d As Integer = 1 To gReferringOfficeDoctors
                        If Reader("Doctor" + d.ToString()).ToString.Trim <> "" Then
                            ComboBoxRefferingDoctor.Items.Add(New ValueDescription(0, Reader("Doctor" + d.ToString()).ToString.Trim, Reader("Doctor" + d.ToString() + "Phone").ToString.Trim))
                        End If
                    Next
                Loop
                Reader.Close() : Reader.Dispose()
            End If
            ComboBoxRefferingDoctor.SelectedIndex = gFindComboItemByDescription(ComboBoxRefferingDoctor, RefferingDoctor, True)
            Reader.Close() : Reader.Dispose()
        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If ComboBoxRefferingDoctor.SelectedIndex = -1 Then
            MsgBox("Unable to process update. No Reffering Doctor selected", MsgBoxStyle.Exclamation)
            ComboBoxRefferingDoctor.Focus()
            Exit Sub
        End If
        If ComboBoxRefferingDoctor.Text = RefferingDoctor Then
            MsgBox("Unable to process update. The Reffering Doctor has not been changed", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to update the Reffering Doctor?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            ComboBoxRefferingDoctor.Focus()
            Exit Sub
        End If
        gSQLUpdateData("UPDATE PatientProcedures set ReferringOfficeID = " & ReferringCompanyID & ", ReferringDoctorNPI='" & CType(ComboBoxRefferingDoctor.SelectedItem, ValueDescription).Value1 & "', ReferringDoctor = '" & CType(ComboBoxRefferingDoctor.SelectedItem, ValueDescription).Description.ToSafeSQLString() & "' WHERE  PatientProcedureID = " & ProcedureID)
        CalledListView.SelectedItems(0).SubItems(3).Text = CType(ComboBoxRefferingDoctor.SelectedItem, ValueDescription).Description
        CalledListView.SelectedItems(0).SubItems(3).Tag = CType(ComboBoxRefferingDoctor.SelectedItem, ValueDescription).Value1
        Me.Close()
    End Sub
End Class