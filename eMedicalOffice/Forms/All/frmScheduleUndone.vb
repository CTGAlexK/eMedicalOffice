Public Class frmScheduleUndone
    Private ScheduleDate As String
    Private PatientID As Long
    Public Sub Load_Procedures(ByVal ScheduleID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        SQL = "SELECT  PatientProcedures.PatientID, PatientProcedures.PatientProcedureID,   Procedures.ProcName, Schedule.ScheduleID, Schedule.ScheduleDateTime FROM Procedures INNER JOIN PatientProcedures ON Procedures.ProcID = PatientProcedures.ProcID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID WHERE PatientProcedures.ProcedureStatusID=2 and PatientProcedures.ScheduleID = " & ScheduleID
        Reader = gSQLGetDataReader(SQL)
        Do Until Reader.Read = False
            ScheduleDate = Reader("ScheduleDateTime")
            PatientID = Reader("PatientID")
            Tag = ScheduleID
            LI = ListViewProcedures.Items.Add(Reader("ProcName").ToString)
            LI.Tag = Reader("PatientProcedureID").ToString
        Loop
        If ListViewProcedures.Items.Count = 0 Then
            Label1.Text = "No Completed procedures found for this schedule."
            btnComplete.Enabled = False
        End If
    End Sub
    Private Sub ListBoxProcedures_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewProcedures.ItemCheck

    End Sub

    Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
        Dim Li As ListViewItem
        If ListViewProcedures.CheckedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Procedure(s) selectd." & vbCrLf & "Please select procedure(s) which has been completed.", MsgBoxStyle.Exclamation)
            ListViewProcedures.Focus()
            Exit Sub
        End If
        For Each Li In ListViewProcedures.CheckedItems
            gSQLUpdateData("UPDATE PatientProcedures set PACSAltNumber='', UpdatedByEmpID=" & gCurrentEmployee.EmpID.ToString & ", UpdatedDT=getdate(), ProcedureStatusID = 1 Where PatientProcedures.PatientProcedureID=" & Li.Tag)
        Next
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tStatusChange, "Schedule " & ScheduleDate & " Undone by Admin")
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ListViewProcedures_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListViewProcedures.ItemChecked
        If ListViewProcedures.CheckedItems.Count > 0 Then
            btnComplete.Enabled = True
        Else
            btnComplete.Enabled = False
        End If
    End Sub

    Private Sub frmScheduleUndone_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class