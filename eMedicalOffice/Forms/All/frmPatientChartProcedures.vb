Public Class frmPatientChartProcedures
    Public PatientID As Long
    Public PatientProcedureID() As String
    Private Sub frmPatientChartProcedures_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_PatientProcedures(PatientID)
    End Sub
    Public Sub Load_PatientProcedures(ByVal PatientID As Long, Optional ByVal ForceAll As Boolean = False)
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        ListViewProcedures.Items.Clear()
        SQL = "SELECT     PatientProcedures.BillingProviderID, PatientProcedures.ReferringDoctor, Schedule.ScheduleDateTime, PatientProcedures.ProcID, Procedures.ProcName, PatientProcedures.PatientProcedureID, PatientProcedures.ProcedureStatusID,  PatientProcedureStatuses.Description AS StatusDescription, Employees.Fname + ' ' + Employees.Lname+' '+Employees.Alias AS TRName, EmployeesBP.Fname + ' ' + EmployeesBP.Lname +' '+ EmployeesBP.Alias AS BPName, PatientProcedures.TreatingProviderID "
        SQL = SQL & " FROM         PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN PatientProcedureStatuses ON PatientProcedures.ProcedureStatusID = PatientProcedureStatuses.ProcedureStatusID LEFT OUTER JOIN Employees ON PatientProcedures.TreatingProviderID = Employees.EmpID  LEFT OUTER JOIN Employees EmployeesBP ON PatientProcedures.BillingProviderID = EmployeesBP.EmpID  LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID "
        If ForceAll = True Then
            SQL = SQL & " Where PatientProcedures.PatientID = " & PatientID & " and Schedule.ScheduleID is not null"

        Else
            SQL = SQL & " Where PatientProcedures.ProcedureStatusID=1 and PatientProcedures.PatientID = " & PatientID
        End If
        SQL = SQL & " ORDER BY PatientProcedures.PatientProcedureID "

        Reader = gSQLGetDataReader(SQL)
        ListViewProcedures.BeginUpdate()
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            If IsDate(Reader("ScheduleDateTime").ToString) Then
                LI = ListViewProcedures.Items.Add(CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yyyy hh:mm"), CInt(Val(Reader("ProcedureStatusID").ToString)))
                If CDate(CDate(Reader("ScheduleDateTime")).ToString("MM/dd/yyyy")) = CDate(Now.ToString("MM/dd/yyyy")) Then
                    LI.ForeColor = Color.Green
                    LI.Checked = True
                End If
            Else
                LI = ListViewProcedures.Items.Add("", 0)
            End If
            LI.SubItems.Add(Reader("ProcName").ToString)
            LI.SubItems.Add(Reader("StatusDescription").ToString)
            LI.SubItems.Add(Reader("BPName").ToString).Tag = Val(Reader("BillingProviderID").ToString)

            LI.ToolTipText = Reader("StatusDescription").ToString
            LI.SubItems(0).Tag = Reader("BillingProviderID").ToString
            LI.Tag = Reader("PatientProcedureID").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewProcedures.Items.Count > 0 Then
            ListViewProcedures.Items(0).Selected = True
            ListViewProcedures.Items(0).EnsureVisible()
            Label2.ForeColor = Color.Black
            If ForceAll = False Then
                Label2.Text = "Check the today's visit procedures."
            Else
                Label2.Text = "Check Procedures/Billing Providers you need to reprint chart for."
            End If

            cmdUpdate.Enabled = True
        Else
            Label2.ForeColor = Color.Red
            Label2.Text = "No Scheduled Procedures found for this patient."
            cmdUpdate.Enabled = False
        End If
            ListViewProcedures.EndUpdate()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim LI As ListViewItem
        Dim lPatientProcedureID() As String
        Dim BillingProvider() As String
        Dim I As Integer = 0
        Dim BP As New ArrayList
        If ListViewProcedures.CheckedItems.Count = 0 Then
            MsgBox("Unable to produce the Patient's Chart Forms. No Procedure(s) selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            For Each LI In ListViewProcedures.CheckedItems
                If BP.Contains(LI.SubItems(0).Tag.ToString) = False Then
                    BP.Add(LI.SubItems(0).Tag.ToString)
                    ReDim Preserve lPatientProcedureID(I)
                    lPatientProcedureID(I) = LI.Tag
                    I = I + 1
                End If
            Next
        End If
        PatientProcedureID = lPatientProcedureID
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Load_PatientProcedures(PatientID, CheckBox1.Checked)
    End Sub

    Private Sub ListViewProcedures_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListViewProcedures.ItemChecked

    End Sub
End Class