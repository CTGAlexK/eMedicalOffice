Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmTransportationRequest
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub ScheduleSearchPopup_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            DateTimePicker.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        CloseReport(CR)
        DeleteTempFiles()
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        gSetup_GotFocus(Me)
        DateTimePicker.Value = Now
        If gPrinterOtherDocuments <> "" Then lblPrinter.Text = "Printer: " & gPrinterOtherDocuments
    End Sub
    Private CR As ReportDocument
    Private Sub Setup_report()
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Try
            If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
                CR = New rptTransportation
            Else
                'CR = New rptTransportationPT
            End If




            'ConInfo.ConnectionInfo.UserID = gSQLServerUID
            'ConInfo.ConnectionInfo.Password = gSQLServerPassword
            'ConInfo.ConnectionInfo.ServerName = gSQLServerName
            'ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
            'For intCounter = 0 To CR.Database.Tables.Count - 1

            '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.UserID = gSQLServerUID
            '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.Password = gSQLServerPassword
            '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.ServerName = gSQLServerName
            '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase

            '    Application.DoEvents()
            '    CR.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
            '    Application.DoEvents()
            'Next
            'CR.Refresh()

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub


            CR.SetParameterValue("OfficeID", gOfficeID)
            CR.SetParameterValue("ScheduleDate", DateTimePicker.Value.ToString("MM/dd/yyyy"))

            If gPrinterOtherDocuments <> "" Then CR.PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.ReportSource = CR
            If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try

    End Sub


    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub


    Private Sub DateTimePickerFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker.ValueChanged
        Timer1.Enabled = False
        Timer1.Enabled = True
        Application.DoEvents()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.PrintReport()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        DateTimePicker.Enabled = False
        Timer1.Enabled = False
        CrystalReportViewer1.SuspendLayout()
        gShowWait(True, PanelWait, Me)
        Setup_report()
        CrystalReportViewer1.ResumeLayout(True)
        DateTimePicker.Visible = True
        DateTimePicker.BringToFront()
        gShowWait(False, PanelWait, Me)
        DateTimePicker.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If CrystalReportViewer1.ReportSource Is Nothing Then
            MsgBox("Unable to Email report. No report has been loaded.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Transportation Request Report As Of " & Now.ToString("MM/dd/yyyy") & ". Attached: Transportation Request Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\TransportationRequestReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If CrystalReportViewer1.ReportSource Is Nothing Then
            MsgBox("Unable to Email report. No report has been loaded.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Transportation Request Report As Of " & Now.ToString("MM/dd/yyyy") & ". Attached: Transportation Request Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\TransportationRequestReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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