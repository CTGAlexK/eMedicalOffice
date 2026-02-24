Public Class frmScheduleFindPatient
    Public frm As frmSchedule

    Private Sub frmScheduleFindPatient_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtPatient.Focus()
    End Sub

    Private Sub frmScheduleFindPatient_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)
    End Sub

    Private Sub frmScheduleFindPatient_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = 13 Then
            ButtonFind_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmScheduleFindPatient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
    End Sub

    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim PName() As String
        Dim LI As ListViewItem
        Dim SI As ListViewItem.ListViewSubItem
        Dim C As Color
        Dim ProcStatus
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        SQL = "SELECT       Schedule.ScheduleID, Patients.PatientID, ISNULL(Patients.FName, '') + ' ' + ISNULL(Patients.LName, '') + ' ' + ISNULL(Patients.MI, '') AS PatName, Patients.DOB, Patients.Sex, "
        SQL &= "           Patients.CaseStatusID, CaseStatuses.Description AS CaseStatus, Schedule.ScheduleDateTime, Procedures.ProcName, PatientProcedureStatuses.Description AS ProcStatus, PatientProcedures.ProcedureStatusID "
        SQL &= " FROM         Patients INNER JOIN CaseStatuses ON Patients.CaseStatusID = CaseStatuses.CaseStatusID INNER JOIN PatientProcedures ON Patients.PatientID = PatientProcedures.PatientID INNER JOIN PatientProcedureStatuses ON PatientProcedures.ProcedureStatusID = PatientProcedureStatuses.ProcedureStatusID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID "
        SQL &= " Where Patients.OfficeID=" & gOfficeID & " and Patients.CaseStatusID=1 "

        If txtPatient.Text.Trim <> "" Then
            If IsNumeric(txtPatient.Text) Then
                SQL &= " AND Patients.PatientID = " & Val(txtPatient.Text) & " "
            Else
                PName = Split(txtPatient.Text.ToSafeSQLString(), " ")
                Select Case PName.Length
                    Case 1
                        If PName(0).Trim = "*" Then PName(0) = ""
                        SQL &= " and (Patients.FName Like '" & PName(0).Trim & "%' or Patients.LName Like '" & PName(0) & "%') "
                    Case 2
                        SQL &= " and ("
                        SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.LName Like '" & PName(1).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.LName Like '" & PName(0).Trim & "%')"
                        SQL &= " )"
                    Case 3
                        SQL &= " and ("
                        SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" & PName(1).Trim & "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" & PName(2).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" & PName(0).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" & PName(1).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" & PName(0).Trim & "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" & PName(2).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "

                        SQL &= " )"
                End Select

            End If
        End If

        ListView1.Items.Clear()
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ListView1.ListViewItemSorter = Nothing
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("PatientID").ToString)
            LI.UseItemStyleForSubItems = False
            LI.SubItems.Add(Reader("PatName").ToString)
            If IsDate(Reader("DOB").ToString) Then
                LI.SubItems.Add(CDate(Reader("DOB").ToString).ToString("MM/dd/yyyy"))
            Else
                LI.SubItems.Add(Reader("DOB").ToString)
            End If
            LI.SubItems.Add(Reader("Sex").ToString)
            If Val(Reader("CaseStatusID").ToString) = 1 Then
                C = Color.White
            Else
                C = Color.SeaShell
            End If
            LI.SubItems.Add(Reader("CaseStatus").ToString).BackColor = C
            SI = LI.SubItems.Add(CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yyyy hh:mm tt"))
            SI.BackColor = Color.FromArgb(255, 224, 192)
            SI.Tag = Val(Reader("ScheduleID"))
            LI.SubItems.Add(Reader("ProcName").ToString)
            C = Color.White
            If Val(Reader("ProcedureStatusID").ToString) = 2 Then
                C = Color.FromArgb(192, 255, 192)
            End If
            If DateDiff(DateInterval.Hour, CDate(Reader("ScheduleDateTime").ToString), Now) > gNoShowHours And Val(Reader("ProcedureStatusID").ToString) <> 2 Then
                C = Color.SeaShell
                ProcStatus = "No Show"
            Else
                ProcStatus = Reader("ProcStatus").ToString
            End If
            LI.SubItems.Add(ProcStatus).BackColor = C

        Loop
        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim SelectedDate As Date
        Dim C As Integer
        Dim R As Integer
        Dim PatName As String
        Dim Ret As String
        Dim SelectedSchedule As DateTime
        Dim SI As ScheduleInfo = Nothing
        Dim ScheduleID As Long
        Dim Rp As FarPoint.Win.Spread.EnterCellEventArgs
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to show schedule." & vbCrLf & "No Patient's procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        SelectedDate = CDate(ListView1.SelectedItems(0).SubItems(5).Text).ToString("MM/dd/yyyy")
        SelectedSchedule = ListView1.SelectedItems(0).SubItems(5).Text
        PatName = ListView1.SelectedItems(0).SubItems(1).Text.Trim
        ScheduleID = Val(ListView1.SelectedItems(0).SubItems(5).Tag)
        If frm.DateTimePicker1.Value <> SelectedDate Then
            frm.DateTimePicker1.Value = SelectedDate
            'frm.DateTimePicker1_ValueChanged(Nothing, Nothing)
        End If

        For R = 0 To frm.FpSpreadSchedule.ActiveSheet.RowCount - 1
            Ret = frm.FpSpreadSchedule.ActiveSheet.GetText(R, 0)
            If Ret = SelectedSchedule.ToString("hh tt") Then
                gSpreadActivateCell(frm.FpSpreadSchedule, R, 0, False)
                Exit For
            End If
        Next

        For C = 2 To frm.FpSpreadSchedule.ActiveSheet.ColumnCount - 1
            For R = 0 To frm.FpSpreadSchedule.ActiveSheet.RowCount - 1
                SI = CType(frm.FpSpreadSchedule.ActiveSheet.Cells(R, C).Tag, ScheduleInfo)

                If Val(SI.ScheduleID) = Val(ScheduleID) Then
                    frm.FpSpreadSchedule.ActiveSheet.SetActiveCell(R, C)
                    Rp = New FarPoint.Win.Spread.EnterCellEventArgs(Nothing, R, C)
                    frm.FpSpread1_EnterCell(Nothing, Rp)

                    'gSpreadActivateCell(frm.FpSpreadSchedule, R, C, False)
                    Exit Sub
                End If
            Next
        Next

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        cmdAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim LI As ListViewItem
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No Bill selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListView1.SelectedItems(0)
        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.MinimizeBox = False
            NewFrm.InitialPatientName = LI.Text
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.ShowDialog(Me)
        End Using
    End Sub

End Class