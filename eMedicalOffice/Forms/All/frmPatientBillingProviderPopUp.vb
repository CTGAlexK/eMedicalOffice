Imports System.Reflection
Imports log4net

Public Class frmPatientBillingProviderPopUp
    Private log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Public BillingProvider As Long
    Public ProcedureID As Long
    Public CalledListView As ListView
    Private Sub frmPatientTreatingProviderPopUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
    End Sub
    Private Sub Load_Data()
        Try
            Dim Reader As SqlClient.SqlDataReader
            ComboBoxTreatingProviderID.Items.Clear()
            Reader = gSQLGetDataReader("SELECT   Employees.EmpID,   Employees.Fname, Employees.Lname, Employees.Alias, Employees.BillingPrv FROM Employees INNER JOIN EmployeeOffice ON Employees.EmpID = EmployeeOffice.EmpID WHERE  Employees.EmpID <> " & BillingProvider & " and BillingPrv=1 and Employees.ActiveInd = 1 and   (Employees.PositionID = 5) AND (EmployeeOffice.OfficeID = " & gOfficeID & ")")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxTreatingProviderID.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("FName").ToString & " " & Reader("LName").ToString & " " & Reader("Alias").ToString))
            Loop
            'If BillingProvider <> 0 Then gFindComboItemByValue(ComboBoxTreatingProviderID, BillingProvider, True)
            If ComboBoxTreatingProviderID.Items.Count = 1 Then
                ComboBoxTreatingProviderID.SelectedIndex = 0
            End If
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
        If ComboBoxTreatingProviderID.SelectedIndex = -1 Then
            MsgBox("Unable to process update. No Billing Provider selected", MsgBoxStyle.Exclamation)
            ComboBoxTreatingProviderID.Focus()
            Exit Sub
        End If
        If CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Value = BillingProvider Then
            MsgBox("Unable to process update. The Billing Provider not changed", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to update the Billing Provider?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            ComboBoxTreatingProviderID.Focus()
            Exit Sub
        End If
        gSQLUpdateData("UPDATE PatientProcedures set BillingProviderID = " & CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Value & " WHERE  PatientProcedureID = " & ProcedureID)
        'frmPatientTreatingProvider.ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
        CalledListView.SelectedItems(0).SubItems(3).Tag = CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Value
        CalledListView.SelectedItems(0).SubItems(3).Text = CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Description
        Me.Close()
    End Sub
End Class