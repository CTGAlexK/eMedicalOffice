Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmChiropractorExams
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub ScheduleSearchPopup_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    End Sub

    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        gSpread_Settings(Me, FpSpreadExams, ReadWrite.sWrite)
    End Sub

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        gSpread_Settings(Me, FpSpreadExams, ReadWrite.sRead)
        gSetup_GotFocus(Me)
        Load_Data()
        If gPrinterOtherDocuments <> "" Then lblPrinter.Text = "Printer: " & gPrinterOtherDocuments
        gSpreadActivateCell(FpSpreadExams, 0, 0)
        gSetSpreadCustomSortIndicator(FpSpreadExams)
        Timer1.Enabled = True
        'DateTimePickerFrom.Value = DateAdd("M", -1, Now)
        'DateTimePickerTo.Value = Now
        'DateTimePickerFrom.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerFrom", DateAdd("M", -1, Now))
        'DateTimePickerTo.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerTo", Now)
    End Sub

    Private Sub Load_Data()

    End Sub

    Private CR As ReportDocument = Nothing

    Private Sub Setup_report()
        Dim intCounter As Integer
        Dim SQL As String
        Dim ReaderDays As SqlClient.SqlDataReader
        Dim Reader As SqlClient.SqlDataReader
        Dim BgColor As Color = Color.PaleGoldenrod
        FpSpreadExams.Visible = False
        gShowWait(True, PanelWait, Me)
        Application.DoEvents()
        FpSpreadExams.ActiveSheet.RowCount = 0
        SQL = "SELECT     ExaminationIntervals.DiagID, ExaminationIntervals.DaysNumber, Diagnostics.DiagName FROM ExaminationIntervals INNER JOIN Diagnostics ON ExaminationIntervals.DiagID = Diagnostics.DiagID Where ExaminationIntervals.OfficeID=" & gOfficeID & " ORDER BY  Diagnostics.DiagName "
        ReaderDays = gSQLGetDataReader(SQL)
        If ReaderDays Is Nothing Then GoTo ExitSub
        FpSpreadExams.SuspendLayout()
        Do Until ReaderDays.Read = False
            If BgColor = Color.White Then
                BgColor = Color.PaleGoldenrod
            Else
                BgColor = Color.White
            End If
            SQL = "SELECT   "
            SQL &= "(SELECT MAX(Schedule.ScheduleDateTime) FROM PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID WHERE PatientProcedures.PatientID=Patients.PatientID and (Procedures.ProcedureTypeID = 3 OR Procedures.ProcedureTypeID = 4) AND (PatientProcedures.DiagID = " & Val(ReaderDays("DiagID").ToString) & ")) as ProcDate, "
            SQL &= "  PatientID, FName, MI, LName, DOB, DOA, Phone1, Phone2, CellPhone FROM Patients Where CaseStatusID=1 and NoMoreAppointmentsInd=0 and PatientID not in  (SELECT PatientProcedures.PatientID FROM PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID WHERE (Procedures.ProcedureTypeID = 3 OR Procedures.ProcedureTypeID = 4) AND (PatientProcedures.DiagID = " & Val(ReaderDays("DiagID").ToString) & ") AND (DATEDIFF(d, Schedule.ScheduleDateTime, GETDATE()) <= " & Val(ReaderDays("DaysNumber").ToString) & "))"
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False

                With FpSpreadExams.ActiveSheet
                    .RowCount = .RowCount + 1
                    .SetText(.RowCount - 1, 0, ReaderDays("DiagName").ToString)
                    .Rows(.RowCount - 1).BackColor = BgColor
                    If IsDate(Reader("ProcDate").ToString) Then .SetText(.RowCount - 1, 1, CDate(Reader("ProcDate").ToString).ToString("MM/dd/yyyy"))
                    .SetText(.RowCount - 1, 2, Reader("PatientID").ToString)
                    .SetText(.RowCount - 1, 3, Reader("FName").ToString & " " & Reader("LName").ToString)
                    If IsDate(Reader("DOB").ToString) Then .SetText(.RowCount - 1, 4, CDate(Reader("DOB").ToString).ToString("MM/dd/yyyy"))
                    If IsDate(Reader("DOA").ToString) Then .SetText(.RowCount - 1, 5, CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy"))
                    .SetText(.RowCount - 1, 6, Reader("Phone1").ToString)
                    .SetText(.RowCount - 1, 7, Reader("Phone2").ToString)
                    .SetText(.RowCount - 1, 8, Reader("CellPhone").ToString)
                End With
            Loop
        Loop
        'FpSpreadExams.ActiveSheet.SetColumnMerge(0, FarPoint.Win.Spread.Model.MergePolicy.Always)
        'FpSpreadExams.ActiveSheet.SetColumnMerge(1, FarPoint.Win.Spread.Model.MergePolicy.Always)
        gSpreadActivateCell(FpSpreadExams, 0, 0)
ExitSub:
        FpSpreadExams.Visible = True
        FpSpreadExams.ResumeLayout()
        gShowWait(False, PanelWait, Me)

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub DateTimePickerFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Timer1.Enabled = True
        Application.DoEvents()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Cursor = Cursors.WaitCursor
        Me.UseWaitCursor = True
        Application.DoEvents()

        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        Printinfo.SmartPrintPagesWide = 1
        Printinfo.BestFitRows = True
        Printinfo.Preview = True
        Printinfo.ShowShadows = False
        Printinfo.JobName = "eMedical Office Examinations"
        Printinfo.PrintType = FarPoint.Win.Spread.PrintType.All
        Printinfo.ShowColor = True
        Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.ShowBorder = False
        Printinfo.ShowGrid = True
        Printinfo.ShowPrintDialog = True
        'Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
        Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.All))
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.BestFitColumnRule(FarPoint.Win.Spread.ResetOption.None))
        Printinfo.UseSmartPrint = True
        Printinfo.UseMax = True
        FpSpreadExams.ActiveSheet.PrintInfo = Printinfo
        FpSpreadExams.PrintSheet(FpSpreadExams.ActiveSheet)
        Cursor = Cursors.Default
        Me.UseWaitCursor = False
        Application.DoEvents()
        'If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
        'CrystalReportViewer1.PrintReport()

        'Catch ex As Exception
        'MsgBox(ex.Message)
        'gProcess_Log(ex.Message, ex.StackTrace, True)
        'End Try
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Setup_report()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If FpSpreadExams.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to Email report. No data loaded.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Me.UseWaitCursor = True
        Application.DoEvents()
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Examination Required Report/ Attached: MS Excel File"
        Fname = System.IO.Path.GetTempPath & "\ExaminationRequiredReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".xls"
Recheck:
        If System.IO.File.Exists(Fname) Then
            Try
                System.IO.File.Delete(Fname)
            Catch ex As Exception
                Fname = System.IO.Path.GetTempFileName
                Fname = Fname.Replace(".tmp", ".pdf")
                GoTo Recheck
            End Try
        End If
        Try
            'Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
            'Printinfo.PrintToPdf = True
            'Printinfo.PdfFileName = Fname
            'Printinfo.PdfWriteMode = FarPoint.Win.Spread.PdfWriteMode.New
            'Printinfo.PdfWriteTo = FarPoint.Win.Spread.PdfWriteTo.File
            'Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
            'Printinfo.ShowBorder = False
            'Printinfo.ShowGrid = True
            'Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
            'FpSpreadExams.ActiveSheet.PrintInfo = Printinfo
            'FpSpreadExams.SafePrint(FpSpreadExams, 0)
            If FpSpreadExams.SaveExcel(Fname, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders, Nothing) Then

                Msg.SendMail(Fname.ToString, Subject, Subject)
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
        Me.UseWaitCursor = False
        Application.DoEvents()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If FpSpreadExams.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to Email report. No data loaded.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Cursor = Cursors.WaitCursor
        Me.UseWaitCursor = True
        Application.DoEvents()
        Subject = "Message From " & gOfficeName & " / Examination Required Report / Attached: MS Excel File"
        Fname = System.IO.Path.GetTempPath & "\ExaminationRequiredReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".xls"
Recheck:
        If System.IO.File.Exists(Fname) Then
            Try
                System.IO.File.Delete(Fname)
            Catch ex As Exception
                Fname = System.IO.Path.GetTempFileName
                Fname = Fname.Replace(".tmp", ".pdf")
                GoTo Recheck
            End Try
        End If
        Try
            'Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
            'Printinfo.PrintToPdf = True
            'Printinfo.PdfFileName = Fname
            'Printinfo.PdfWriteMode = FarPoint.Win.Spread.PdfWriteMode.New
            'Printinfo.PdfWriteTo = FarPoint.Win.Spread.PdfWriteTo.File
            'Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
            'Printinfo.ShowBorder = False
            'Printinfo.ShowGrid = True
            'Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
            'FpSpreadExams.ActiveSheet.PrintInfo = Printinfo
            'FpSpreadExams.SafePrint(FpSpreadExams, 0)
            If FpSpreadExams.SaveExcel(Fname, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders, Nothing) Then
                gFax(Me, "", Subject, Fname.ToString, gOfficeFax)
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
        Me.UseWaitCursor = False
    End Sub

    Private Sub FpSpreadExams_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadExams.CellClick

    End Sub

    Private Sub FpSpreadExams_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadExams.CellDoubleClick
        Dim PatID As Integer
        If FpSpreadExams.ActiveSheet.RowCount = 0 Then Exit Sub
        If e.ColumnHeader Then Exit Sub
        Me.UseWaitCursor = True
        Application.DoEvents()
        PatID = FpSpreadExams.ActiveSheet.GetText(e.Row, 2)
        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.InitialPatientName = PatID
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            Me.UseWaitCursor = False
            NewFrm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim PatID As Integer
        If FpSpreadExams.ActiveSheet.RowCount = 0 Then Exit Sub
        If FpSpreadExams.ActiveSheet.ActiveRowIndex = -1 Then Exit Sub
        PatID = FpSpreadExams.ActiveSheet.GetText(FpSpreadExams.ActiveSheet.ActiveRowIndex, 2)
        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.InitialPatientName = PatID
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Setup_report()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If FpSpreadExams.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to Export to Excel. No data loaded.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        SaveFileDialog1.Filter = "MS Excel File (*.xls)|*.xls"
        SaveFileDialog1.DefaultExt = "xls"
        Fname = "ExaminationRequiredReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".xls"
        Fname = gFixFileName(Fname)
        SaveFileDialog1.FileName = Fname
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            Fname = SaveFileDialog1.FileName
        Else
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Me.UseWaitCursor = True
        Application.DoEvents()
        Try
            FpSpreadExams.SaveExcel(Fname, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders, Nothing)
            Dim P As New ProcessStartInfo()
            With P
                .FileName = Fname
                .UseShellExecute = True
            End With
            Process.Start(P)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
        Me.UseWaitCursor = False
    End Sub

End Class