Public Class frmScheduleComplete
    Private ScheduleDate As String
    Private PatientID As Long
    Public Sub Load_Procedures(ByVal ScheduleID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem
        Dim I As Integer = 0
        SQL = "SELECT  PatientProcedures.PatientID, PatientProcedures.PatientProcedureID,   PatientProcedures.PACSAltNumber, Procedures.ProcName, Schedule.ScheduleID, Schedule.ScheduleDateTime FROM Procedures INNER JOIN PatientProcedures ON Procedures.ProcID = PatientProcedures.ProcID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID WHERE PatientProcedures.ProcedureStatusID=1 and PatientProcedures.ScheduleID = " & ScheduleID

        Reader = gSQLGetDataReader(SQL)
        With FpSpreadProcedures.ActiveSheet
            .RowCount = 0
            Do Until Reader.Read = False
                Text = "Procedure(s) Completion Confirmation: " & Reader("ScheduleDateTime")
                ScheduleDate = Reader("ScheduleDateTime")
                PatientID = Reader("PatientID")
                Tag = ScheduleID
                I = I + 1
                .RowCount = I
                .SetText(I - 1, 1, Reader("PACSAltNumber").ToString)
                .SetText(I - 1, 2, Reader("ProcName").ToString)
                .SetTag(I - 1, 2, Val(Reader("PatientProcedureID").ToString))
            Loop
        End With
        Reader.Close() : Reader.Dispose()
        If FpSpreadProcedures.ActiveSheet.RowCount = 1 Then
            Label1.Text = "Please select completed procedure"
        Else
            Label1.Text = "Please select completed procedures"
        End If
        SQL = "SELECT PatientProcedures.ProcedureStatusID, PatientProcedures.PatientProcedureID,   Procedures.ProcName, Schedule.ScheduleID, Schedule.ScheduleDateTime FROM Procedures INNER JOIN PatientProcedures ON Procedures.ProcID = PatientProcedures.ProcID LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID WHERE (ScheduleDateTime  IS NOT NULL) and (PatientProcedures.ProcedureStatusID=1 or PatientProcedures.ProcedureStatusID=0) and PatientProcedures.PatientID = " & PatientID
        Reader = gSQLGetDataReader(SQL)
        Do Until Reader.Read = False
            If Val(Reader("ProcedureStatusID").ToString) = 0 Then
                LI = ListViewProcedures1.Items.Add(Reader("ProcName").ToString)
                LI.Tag = Reader("PatientProcedureID").ToString
                LI.SubItems.Add("")
            ElseIf Val(Reader("ProcedureStatusID").ToString) = 1 And DateDiff(DateInterval.Hour, CDate(Reader("ScheduleDateTime")), Now) > gNoShowHours Then
                LI = ListViewProcedures1.Items.Add(Reader("ProcName").ToString)
                LI.Tag = Reader("PatientProcedureID").ToString

                LI.SubItems.Add("NS " & Reader("ScheduleDateTime").ToString)
                LI.ForeColor = Color.DarkRed
                LI.SubItems(1).ForeColor = Color.DarkRed
            End If
        Loop
        If ListViewProcedures1.Items.Count > 0 Then
            If ListViewProcedures1.Items.Count = 1 Then
                Labelreschedule.Text = "Attention! The following procedure should be scheduled!"
            Else
                Labelreschedule.Text = "Attention! The following procedures should be scheduled!"
            End If
            Me.Height = 486
        Else
            Me.Height = 303
        End If
    End Sub
    Public Sub Load_Procedures_Back(ByVal ScheduleID As Long)
        'Dim Reader As SqlClient.SqlDataReader
        'Dim SQL As String
        'Dim LI As ListViewItem
        'SQL = "SELECT  PatientProcedures.PatientID, PatientProcedures.PatientProcedureID,   Procedures.ProcName, Schedule.ScheduleID, Schedule.ScheduleDateTime FROM Procedures INNER JOIN PatientProcedures ON Procedures.ProcID = PatientProcedures.ProcID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID WHERE PatientProcedures.ProcedureStatusID=1 and PatientProcedures.ScheduleID = " & ScheduleID
        'Reader = gSQLGetDataReader(SQL)
        'Do Until Reader.Read = False
        '    Text = "Procedure(s) Completion Confirmation: " & Reader("ScheduleDateTime")
        '    ScheduleDate = Reader("ScheduleDateTime")
        '    PatientID = Reader("PatientID")
        '    Tag = ScheduleID
        '    LI = ListViewProcedures.Items.Add(Reader("ProcName").ToString)
        '    LI.Tag = Reader("PatientProcedureID").ToString
        'Loop
        'Reader.Close() : Reader.Dispose()
        'If ListViewProcedures.Items.Count = 1 Then
        '    Label1.Text = "Please select completed procedure"
        'Else
        '    Label1.Text = "Please select completed procedures"
        'End If
        'SQL = "SELECT PatientProcedures.ProcedureStatusID, PatientProcedures.PatientProcedureID,   Procedures.ProcName, Schedule.ScheduleID, Schedule.ScheduleDateTime FROM Procedures INNER JOIN PatientProcedures ON Procedures.ProcID = PatientProcedures.ProcID LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID WHERE (ScheduleDateTime  IS NOT NULL) and (PatientProcedures.ProcedureStatusID=1 or PatientProcedures.ProcedureStatusID=0) and PatientProcedures.PatientID = " & PatientID
        'Reader = gSQLGetDataReader(SQL)
        'Do Until Reader.Read = False
        '    If Val(Reader("ProcedureStatusID").ToString) = 0 Then
        '        LI = ListViewProcedures1.Items.Add(Reader("ProcName").ToString)
        '        LI.Tag = Reader("PatientProcedureID").ToString
        '        LI.SubItems.Add("")
        '    ElseIf Val(Reader("ProcedureStatusID").ToString) = 1 And DateDiff(DateInterval.Hour, CDate(Reader("ScheduleDateTime")), Now) > gNoShowHours Then
        '        LI = ListViewProcedures1.Items.Add(Reader("ProcName").ToString)
        '        LI.Tag = Reader("PatientProcedureID").ToString

        '        LI.SubItems.Add("NS " & Reader("ScheduleDateTime").ToString)
        '        LI.ForeColor = Color.DarkRed
        '        LI.SubItems(1).ForeColor = Color.DarkRed
        '    End If
        'Loop
        'If ListViewProcedures1.Items.Count > 0 Then
        '    If ListViewProcedures1.Items.Count = 1 Then
        '        Labelreschedule.Text = "Attention! The following procedure should be scheduled!"
        '    Else
        '        Labelreschedule.Text = "Attention! The following procedures should be scheduled!"
        '    End If
        '    Me.Height = 466
        'Else
        '    Me.Height = 279
        'End If
    End Sub

    Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
        Dim I As Integer = 0
        Dim Checked As Integer = 0

        For I = 0 To FpSpreadProcedures.ActiveSheet.RowCount - 1
            If FpSpreadProcedures.ActiveSheet.Cells(I, 0).Value = True Then
                If gPACSAltNumberRequired Then
                    If FpSpreadProcedures.ActiveSheet.Cells(I, 1).Text = "" Then
                        MsgBox("Unable to process update." & vbCrLf & "Please specify the Accession Number for all completed procedures.", MsgBoxStyle.Exclamation)
                        gSpreadActivateCell(FpSpreadProcedures, I, 1)
                        Exit Sub
                    End If
                End If
                Checked = Checked + 1
            End If
        Next

        If Checked = 0 Then
            MsgBox("Unable to process your request. No Procedure(s) selectd." & vbCrLf & "Please select procedure(s) which has been completed.", MsgBoxStyle.Exclamation)
            FpSpreadProcedures.Focus()
            Exit Sub
        End If
        If Checked < FpSpreadProcedures.ActiveSheet.RowCount Then
            If MsgBox("Please confirm only " & Checked & " of " & FpSpreadProcedures.ActiveSheet.RowCount & " procedures completed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                FpSpreadProcedures.Focus()
                Exit Sub
            End If
        End If
        For I = 0 To FpSpreadProcedures.ActiveSheet.RowCount - 1
            If FpSpreadProcedures.ActiveSheet.Cells(I, 0).Value = True Then
                If gPACSAltNumberRequired Then
                    gSQLUpdateData("UPDATE PatientProcedures set UpdatedByEmpID=" & gCurrentEmployee.EmpID.ToString & ", UpdatedDT=getdate(), ProcedureStatusID = 2, PACSAltNumber='" & FpSpreadProcedures.ActiveSheet.Cells(I, 1).Text & "' Where PatientProcedures.PatientProcedureID=" & FpSpreadProcedures.ActiveSheet.Cells(I, 2).Tag)
                Else
                    gSQLUpdateData("UPDATE PatientProcedures set UpdatedByEmpID=" & gCurrentEmployee.EmpID.ToString & ", UpdatedDT=getdate(), ProcedureStatusID = 2 Where PatientProcedures.PatientProcedureID=" & FpSpreadProcedures.ActiveSheet.Cells(I, 2).Tag)
                End If

            End If
        Next
        gUpdate_Profile_Log(PatientID, PatientLogTypes.tScheduleCompleted, "Schedule " & ScheduleDate & " Completed")
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub btnComplete_Click_Back(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim Li As ListViewItem
        'If ListViewProcedures.CheckedItems.Count = 0 Then
        '    MsgBox("Unable to process your request. No Procedure(s) selectd." & vbCrLf & "Please select procedure(s) which has been completed.", MsgBoxStyle.Exclamation)
        '    ListViewProcedures.Focus()
        '    Exit Sub
        'End If
        'If ListViewProcedures.CheckedItems.Count < ListViewProcedures.Items.Count Then
        '    If MsgBox("Please confirm only " & ListViewProcedures.CheckedItems.Count & " of " & ListViewProcedures.Items.Count & " procedures completed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '        ListViewProcedures.Focus()
        '        Exit Sub
        '    End If
        'End If
        'For Each Li In ListViewProcedures.CheckedItems
        '    gSQLUpdateData("UPDATE PatientProcedures set UpdatedByEmpID=" & gCurrentEmployee.EmpID.ToString & ", UpdatedDT=getdate(), ProcedureStatusID = 2 Where PatientProcedures.PatientProcedureID=" & Li.Tag)
        'Next
        'gUpdate_Profile_Log(PatientID, PatientLogTypes.tScheduleCompleted, "Schedule " & ScheduleDate & " Completed")
        'Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub frmScheduleComplete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If gPACSAltNumberRequired = False Then
            FpSpreadProcedures.ActiveSheet.Columns(1).Visible = False
            FpSpreadProcedures.ActiveSheet.Columns(2).Width = 395
        Else
            FpSpreadProcedures.ActiveSheet.Columns(1).Visible = True
            FpSpreadProcedures.ActiveSheet.Columns(2).Width = 280
        End If
    End Sub
End Class