Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmToBeScheduledReport
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private CR As ReportDocument

    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gSQLDeleteRecord("DELETE  FROM  ToBeScheduled    Where empid = " & gCurrentEmployee.EmpID)
        gWindow_Settings(Me, ReadWrite.sWrite)
        CloseReport(CR)
        DeleteTempFiles()
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        If gPrinterOtherDocuments <> "" Then lblPrinter.Text = "Printer: " & gPrinterOtherDocuments
        Cursor = Cursors.WaitCursor
    End Sub
    Public Sub Setup_report()
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Dim SQL As String
        gSQLDeleteRecord("DELETE  FROM  ToBeScheduled    Where empid = " & gCurrentEmployee.EmpID)

        gShowWait(True, PanelWait, Me)
        SQL = "INSERT INTO ToBeScheduled    "
        SQL &= "    SELECT 1 as EmpID, Patients.DOA, Patients.PatientID, upper(isnull(Patients.FName,'') + ' ' + isnull(Patients.MI,'') + ' ' + isnull(Patients.LName,'')) AS PatName, ProcName, null as ScheduleDateTime, (select COUNT(*) from PatientNoShow where PatientID = Patients.PatientID ) as NoShowCount  , isnull(Patients.Phone1,'')+'   '+ isnull(Patients.Phone2,'') + '   '+ isnull(Patients.CellPhone,'') as Contact, upper(ReferringOffices.OfficeName) as RefOfficeName, isnull(ReferringOffices.Phone1,'')+'   '+ isnull(ReferringOffices.Phone2,'') as RefOfficeContact,'' as 'NoShow', Patients.Comments  "
        SQL &= "    FROM         Patients INNER JOIN PatientProcedures ON Patients.PatientID = PatientProcedures.PatientID INNER JOIN Procedures on Procedures.ProcID = PatientProcedures.ProcID INNER JOIN ReferringOffices on ReferringOffices.OfficeID = Patients.ReferringCompanyID "
        SQL &= "    WHERE (Patients.OfficeID = " & gOfficeID & " And (Patients.CaseStatusID = 1 Or (Patients.CaseStatusID = 4 And PatientProcedures.DoNotBillAction = 1)) And (Patients.NoMoreAppointmentsInd = 0 Or PatientProcedures.DoNotBillAction = 1) And PatientProcedures.ProcedureStatusID = 0) "

        SQL &= "UNION "
        SQL &= "    SELECT 1 as EmpID, Patients.DOA, Patients.PatientID, upper(isnull(Patients.FName,'') + ' ' + isnull(Patients.MI,'') + ' ' + isnull(Patients.LName,'')) AS PatName, ProcName, ScheduleDateTime, (select COUNT(*) from PatientNoShow where PatientID = Patients.PatientID ) as NoShowCount , isnull(Patients.Phone1,'')+'   '+ isnull(Patients.Phone2,'') + '   '+ isnull(Patients.CellPhone,'') as Contact, upper(ReferringOffices.OfficeName) as RefOfficeName, isnull(ReferringOffices.Phone1,'')+'   '+ isnull(ReferringOffices.Phone2,'') as RefOfficeContact,'N/S' as 'NoShow' , Patients.Comments  "
        SQL &= "    FROM         PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Patients ON PatientProcedures.PatientID = Patients.PatientID INNER JOIN Procedures on Procedures.ProcID = PatientProcedures.ProcID INNER JOIN ReferringOffices on ReferringOffices.OfficeID = Patients.ReferringCompanyID  "
        SQL &= "    WHERE Patients.OfficeID = " & gOfficeID & " And (Patients.CaseStatusID = 1 And (DateDiff(hh, Schedule.ScheduleDateTime, GETDATE()) > " & gNoShowHours & ") And (PatientProcedures.ProcedureStatusID = 1)) "

        gSQLUpdateData(SQL)

        Try
            CR = New rptToBeScheduledReport



            Me.MinimizeBox = False

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            If gPrinterOtherDocuments <> "" Then CR.PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.ReportSource = CR
            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True
            gShowWait(False, PanelWait)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            gShowWait(False, PanelWait)
        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub


    Private Sub DateTimePickerFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer1.Enabled = True
        Application.DoEvents()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If CrystalReportViewer1.Visible = False Then Exit Sub
            If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.PrintReport()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Setup_report()
        Cursor = Cursors.Default
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Attached: To Be Scheduled Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\TBScheduled-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
            CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)

            Msg.SendMail(Fname.ToString, Subject, Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Attached: To Be Scheduled Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\TBScheduled-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
            CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)
            gFax(Me, "", Subject, Fname.ToString, gOfficeFax)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub
End Class