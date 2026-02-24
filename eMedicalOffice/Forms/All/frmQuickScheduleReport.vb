Imports System.Reflection
Imports log4net

Public Class frmQuickScheduleReport
    Private log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private Sub frmPatientProcedureInformation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gSpread_Settings(Me, FpSpreadResults, ReadWrite.sWrite)
        If WindowState <> FormWindowState.Minimized Then
            gWindow_Settings(Me, ReadWrite.sWrite)
        End If
    End Sub

    Private Sub frmPatientProcedureInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim H As ToolStripControlHost
        gWindow_Settings(Me, ReadWrite.sRead)
        gSpread_Settings(Me, FpSpreadResults, ReadWrite.sRead)
        Me.DoubleBuffered = True
        H = New ToolStripControlHost(DateTimePicker1)
        ToolStrip1.Items.Insert(3, H)

        DateTimePicker1.Value = Now
        FpSpreadResults.ActiveSheet.RowCount = 0
    End Sub
    Private Sub Find_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim I As Integer = 0
        Dim SC As Integer = 0
        Dim CT As Integer = 0
        Dim NS As Integer = 0
        Dim CN As Integer = 0
        Dim CNT As String = ""
        Dim SH As Integer = 0
        Dim TimeCOLOR As Color = Color.Black
        Dim bgcolor As Color = Nothing
        lbl1.Text = ""
        lbl2.Text = ""
        lbl3.Text = ""
        lbl4.Text = ""
        lbl5.Text = ""
        FpSpreadResults.ActiveSheet.RowCount = 0
        Application.DoEvents()
        SQL = "SELECT  ShowUpDatetime, ConfirmedBy, PatientProcedures.ProcedureStatusID, ReferringOffices.OfficeName as Office, Patients.PatientID, Schedule.ScheduleDateTime, Procedures.ProcName, Patients.FName + ' ' +Patients.LName as PName, "
        SQL = SQL & "CASE  "
        SQL = SQL & "		When PatientProcedures.ProcedureStatusID = 1 and DateDiff(dd, Schedule.ScheduleDateTime, getdate()) >0 then 'No Show' "
        SQL = SQL & "		else "
        SQL = SQL & "		 PatientProcedureStatuses.Description "
        SQL = SQL & "	end	as Status "

        SQL = SQL & " FROM         PatientProcedures INNER JOIN "
        SQL = SQL & "                      Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN "
        SQL = SQL & "                      Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN "
        SQL = SQL & "                      Patients ON PatientProcedures.PatientID = Patients.PatientID INNER JOIN "
        SQL = SQL & "                      ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID INNER JOIN "
        SQL = SQL & "                      PatientProcedureStatuses ON PatientProcedures.ProcedureStatusID = PatientProcedureStatuses.ProcedureStatusID LEFT OUTER JOIN "
        SQL = SQL & "                      PatientProcedureReadings ON PatientProcedures.PatientProcedureID = PatientProcedureReadings.PatientProcedureID "

        SQL = SQL & " WHERE  "
        SQL = SQL & " DateDiff(dd, Schedule.ScheduleDateTime, '" & DateTimePicker1.Value.Date & "') <= 0 AND DateDiff(dd, Schedule.ScheduleDateTime, '" & DateTimePicker1.Value.Date & "') >= 0 "
        SQL = SQL & " ORDER BY Schedule.ScheduleDateTime "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then
            Exit Sub
        End If

        FpSpreadResults.SuspendLayout()
        I = 0
        SC = 0
        CT = 0
        NS = 0
        CN = 0
        CNT = ""
        SH = 0
        With FpSpreadResults.ActiveSheet
            Do Until Reader.Read = False
                I += 1
                If CDate(Reader("ScheduleDateTime").ToString) < CDate(Now) Then
                    TimeCOLOR = Color.Blue
                Else
                    TimeCOLOR = Color.Black
                End If
                CNT = ""
                If Val(Reader("ProcedureStatusID").ToString) <> 2 Then
                    If IsDate(Reader("ShowUpDatetime")) And CDate(FormatDateTime(CDate(Reader("ScheduleDateTime").ToString), 2)) >= CDate(FormatDateTime(Now, 2)) Then
                        bgcolor = Color.Violet
                        CNT = ""
                        CN = CN + 1
                        SC = SC + 1
                        SH = SH + 1
                    Else
                        If CDate(FormatDateTime(CDate(Reader("ScheduleDateTime").ToString), 2)) < CDate(FormatDateTime(Now, 2)) And Val(Reader("ProcedureStatusID").ToString) <> "2" Then
                            bgcolor = Color.LightSalmon
                            CNT = ""
                            NS = NS + 1
                        Else
                            If Reader("ConfirmedBy").ToString.Trim = "" Then
                                bgcolor = Nothing
                            Else
                                bgcolor = Color.BurlyWood
                                CN = CN + 1
                                CNT = "-Confirmed"
                            End If
                            SC = SC + 1
                        End If
                    End If
                Else
                    bgcolor = Color.MediumAquamarine
                    CT = CT + 1
                End If

                .RowCount = I
                .SetText(I - 1, 0, Reader("Office").ToString)
                .SetText(I - 1, 1, Reader("Status").ToString & " " & CNT)
                .SetText(I - 1, 2, FormatDateTime(Trim("" & Reader("ScheduleDateTime")), 4))
                .Cells(I - 1, 2).ForeColor = TimeCOLOR
                If TimeCOLOR <> Color.Black Then
                    .Cells(I - 1, 2).Font = New Font(FpSpreadResults.Font, FontStyle.Strikeout)
                End If
                .SetText(I - 1, 3, Reader("PName").ToString)
                .SetText(I - 1, 4, Reader("ProcName").ToString)
                .Rows(I - 1).BackColor = bgcolor

            Loop
        End With
        lbl1.Text = "COMPLETED: " & CT
        lbl2.Text = "SCHEDULED: " & SC
        lbl3.Text = "CONFIRMED: " & CN
        lbl4.Text = "NO SHOW: " & NS
        lbl5.Text = "WAITING: " & SH

        FpSpreadResults.ResumeLayout()
        If FpSpreadResults.ActiveSheet.RowCount > 0 Then
            FpSpreadResults.ActiveSheet.ActiveRowIndex = 0
            FpSpreadResults.ActiveSheet.AddSelection(0, 0, 1, 1)
            FpSpreadResults.Focus()
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to Print. No Data has been loaded. Please specify the search criteria an click the Load button.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Printinfo.SmartPrintPagesWide = 1
        Printinfo.BestFitRows = True
        Printinfo.Preview = True
        Printinfo.ShowShadows = False
        Printinfo.JobName = "Patient Procedure Information"
        Printinfo.PrintType = FarPoint.Win.Spread.PrintType.All
        Printinfo.ShowColor = True
        Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.ShowBorder = False
        Printinfo.ShowGrid = True
        Printinfo.ShowPrintDialog = True
        Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
        Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.All))
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.BestFitColumnRule(FarPoint.Win.Spread.ResetOption.None))
        Printinfo.UseSmartPrint = True
        Printinfo.UseMax = True
        FpSpreadResults.ActiveSheet.PrintInfo = Printinfo
        FpSpreadResults.PrintSheet(FpSpreadResults.ActiveSheet)
    End Sub
    Private SaveInfo As Long
    Private SaveInfoText As String
    Private Sub FpSpreadResults_ComboDropDown(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpreadResults.ComboDropDown
        SaveInfo = Val(FpSpreadResults.ActiveSheet.Cells(e.Row, e.Column).Value)
        SaveInfoText = FpSpreadResults.ActiveSheet.Cells(e.Row, e.Column).Text
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strFileName As String
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to process Data Export." & vbCrLf & "No data loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        SaveFD.Title = "Export To Excel."
        SaveFD.Filter = "MS Excel File (*.xls)|*.xls"
        Dim DidWork As Integer = SaveFD.ShowDialog()
        If DidWork = DialogResult.OK Then
            strFileName = SaveFD.FileName
            FpSpreadResults.SuspendLayout()
            FpSpreadResults.ActiveSheet.Rows.Add(0, 1)
            Dim I As Integer
            For I = 0 To FpSpreadResults.ActiveSheet.Columns.Count - 1
                FpSpreadResults.ActiveSheet.SetText(0, I, FpSpreadResults.ActiveSheet.ColumnHeader.Columns(I).Label)
            Next
            FpSpreadResults.SaveExcel(strFileName)
            FpSpreadResults.ActiveSheet.Rows.Remove(0, 1)
            FpSpreadResults.ResumeLayout()
            SaveFD.Reset()
            System.Diagnostics.Process.Start(strFileName)
        End If
    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to Email. No Data has been loaded.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Schedule Information Report: " & DateTimePicker1.Value.Date & " / Attached: Data Excel File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName("Procedure Information " & DateTimePicker1.Value.Date) & ".xls"
Recheck:
        If System.IO.File.Exists(Fname) Then
            Try
                System.IO.File.Delete(Fname)
            Catch ex As Exception
                Fname = System.IO.Path.GetTempFileName
                Fname.Replace(".tmp", ".xls")
                GoTo Recheck
            End Try
        End If
        Try
            FpSpreadResults.SuspendLayout()
            FpSpreadResults.ActiveSheet.Rows.Add(0, 1)
            Dim I As Integer
            For I = 0 To FpSpreadResults.ActiveSheet.Columns.Count - 1
                FpSpreadResults.ActiveSheet.SetText(0, I, FpSpreadResults.ActiveSheet.ColumnHeader.Columns(I).Label)
            Next
            FpSpreadResults.SaveExcel(Fname)
            FpSpreadResults.ActiveSheet.Rows.Remove(0, 1)
            FpSpreadResults.ResumeLayout()
             Msg.SendMail(Fname.ToString, Subject, Subject)
        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to Email. No Data has been loaded. Please specify the search criteria an click the Load button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Schedule Information Report: " & DateTimePicker1.Value.Date & " / Attached: Data Excel File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName("Procedure Information " & DateTimePicker1.Value.Date) & ".xls"
Recheck:
        If System.IO.File.Exists(Fname) Then
            Try
                System.IO.File.Delete(Fname)
            Catch ex As Exception
                Fname = System.IO.Path.GetTempFileName
                Fname.Replace(".tmp", ".xls")
                GoTo Recheck
            End Try
        End If
        Try
            FpSpreadResults.SuspendLayout()
            FpSpreadResults.ActiveSheet.Rows.Add(0, 1)
            Dim I As Integer
            For I = 0 To FpSpreadResults.ActiveSheet.Columns.Count - 1
                FpSpreadResults.ActiveSheet.SetText(0, I, FpSpreadResults.ActiveSheet.ColumnHeader.Columns(I).Label)
            Next
            FpSpreadResults.SaveExcel(Fname)
            FpSpreadResults.ActiveSheet.Rows.Remove(0, 1)
            FpSpreadResults.ResumeLayout()
            gFax(Me, "", Subject, Fname.ToString, gOfficeFax)
        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Find_Data()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Application.DoEvents()
        Find_Data()
    End Sub

    Private Sub ToolStripButtonToday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonToday.Click
        DateTimePicker1.Value = Now
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Timer1.Enabled = True
        Timer1.Interval = 1
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        DateTimePicker1.Value = DateAdd(DateInterval.Day, 1, DateTimePicker1.Value)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        DateTimePicker1.Value = DateAdd(DateInterval.Day, -1, DateTimePicker1.Value)
    End Sub

    Private Sub TimerRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRefresh.Tick
        If gIdleTimeCurrent > 20 Then
            Application.DoEvents()
            Find_Data()
        End If
    End Sub

    Private Sub frmQuickScheduleReport_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move

    End Sub

    Private Sub frmQuickScheduleReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    End Sub
End Class