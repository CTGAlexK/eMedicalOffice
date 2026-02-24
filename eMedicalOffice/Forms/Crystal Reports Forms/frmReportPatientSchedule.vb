Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmReportSchedule

    Private Sub ScheduleSearchPopup_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub
    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        Setup_report()
    End Sub
    Public DiagName As String
    Public DiagID As Long
    Public ScheduleDate As Date = Nothing
    Private CR As ReportDocument = Nothing
    Public ByPatient As Boolean = False
    Public PatientID As Integer = 0
    Private Sub Setup_report()
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Dim SF As String
        Try
            If ByPatient = False Then
                CR = New rptSchedulePT
            Else
                CR = New rptSchedulePTByPatients
            End If

            ConInfo.ConnectionInfo.UserID = gSQLServerUID
            ConInfo.ConnectionInfo.Password = gSQLServerPassword
            ConInfo.ConnectionInfo.ServerName = gSQLServerName
            ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase




            For intCounter = 0 To CR.Database.Tables.Count - 1

                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.UserID = gSQLServerUID
                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.Password = gSQLServerPassword
                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.ServerName = gSQLServerName
                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase

                Application.DoEvents()
                CR.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
                Application.DoEvents()
            Next
            CR.Refresh()



            SF = "{Patients.OfficeID} = " & gOfficeID & " "
            If PatientID > 0 Then
                SF &= " and {Patients.PatientID} = " & PatientID & " "
                If CheckBox1.Checked = False Then SF &= " and {SchedulePT.ScheduleDate} > '" & DateAdd(DateInterval.Day, -1, CDate(Now)).ToString("yyyy-MM-dd") & "' "
            End If
            'SF &= " and {SchedulePT.ScheduleDate} = #" & CDate(ScheduleDate).ToString("yyyy,MM,dd") & "# "
            If IsDate(ScheduleDate) And ScheduleDate <> Nothing Then
                SF &= " and {SchedulePT.ScheduleDate} = '" & CDate(ScheduleDate).ToString("yyyy-MM-dd") & "' "
            End If
            If ByPatient = False Then

                
                CR.SetParameterValue("ScheduleDate", CDate(ScheduleDate).ToString("MM/dd/yyyy"))
                CR.SetParameterValue("Diag", DiagName)
            End If
            ' 0, "All Treatments"
            '-1, "Office Treatments"
            '-2, "Outsource Treatments"

            Select Case DiagID
                Case 0
                Case -1
                    SF &= " and {SchedulePT.DiagTypeID} = 2 "
                Case -2
                    SF &= " and {SchedulePT.DiagTypeID} = 3 "
                Case Else
                    SF &= " and {SchedulePT.DiagID} = " & Val(DiagID) & " "
            End Select
            CR.RecordSelectionFormula = SF

            CrystalReportViewer1.ReportSource = CR
            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
            gProcess_Log(ex.Message, ex.StackTrace, True)
        End Try
    End Sub


    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub


    Private Sub DateTimePickerFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Timer1.Enabled = True
        Application.DoEvents()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If CrystalReportViewer1.ReportSource Is Nothing Then
            MsgBox("Unable to Print report. No report has been loaded. Please select a search criteria and click the Load Button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
        CrystalReportViewer1.PrintReport()
    End Sub
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CrystalReportViewer1.SuspendLayout()
        gShowWait(True, PanelWait, Me)
        Setup_report()
        CrystalReportViewer1.ResumeLayout(True)
        gShowWait(False, PanelWait)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If CrystalReportViewer1.ReportSource Is Nothing Then
            MsgBox("Unable to Email report. No report has been loaded. Please select a search criteria and click the Load Button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Schedule Report " & DiagName & "/ Attached: Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\ScheduleReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
Recheck:
        If System.IO.File.Exists(Fname) Then
            Try
                System.IO.File.Delete(Fname)
            Catch ex As Exception
                Fname = System.IO.Path.GetTempFileName
                Fname.Replace(".tmp", ".pdf")
                GoTo Recheck
            End Try
        End If
        Try
            CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)
            Msg.SendMail(Fname.ToString, Subject, Subject)
        Catch ex As Exception
            gProcess_Log("Error Sending Email", ex.StackTrace, True)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If CrystalReportViewer1.ReportSource Is Nothing Then
            MsgBox("Unable to Email report. No report has been loaded. Please select a search criteria and click the Load Button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Schedule Report " & DiagName & "/ Attached: Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\ScheduleReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
Recheck:
        If System.IO.File.Exists(Fname) Then
            Try
                System.IO.File.Delete(Fname)
            Catch ex As Exception
                Fname = System.IO.Path.GetTempFileName
                Fname.Replace(".tmp", ".pdf")
                GoTo Recheck
            End Try
        End If
        Try
            CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)
            gFax(Me, "", Subject, Fname.ToString, gOfficeFax)
        Catch ex As Exception
            gProcess_Log("Error Sending Fax", ex.StackTrace, True)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Setup_report()
    End Sub
End Class