Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmChart
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public PatientName As String
    Private CR As ReportDocument
    Public PatientID As Long
    Public ChartShouldBePrinted As Boolean
    Public ChartPrinted As Boolean

    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ChartShouldBePrinted And ChartPrinted = False Then
            If MsgBox("The Chart Print is required!" & vbCrLf & vbCrLf & "Are you sure you want to exit without printing?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        gWindow_Settings(Me, ReadWrite.sWrite)
        CloseReport(CR)
        DeleteTempFiles()
    End Sub

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        If gPrinterNF3 <> "" Then lblPrinter.Text = "Printer: " & gPrinterNF3
    End Sub

    Public SelectedProcedureIDs() As Long
    Private lPatientProcedureID() As String
    Private lCasePrivate As Boolean
    Private lForceFullReport As Boolean

    Public Sub Setup_report(ByVal PatientProcedureID() As String, Optional ByVal CasePrivate As Boolean = False, Optional ByVal ForceFullReport As Boolean = False)
        lPatientProcedureID = PatientProcedureID
        lCasePrivate = CasePrivate
        lForceFullReport = ForceFullReport
        gShowWait(True, PanelWait, Me)
        Timer1.Enabled = True
    End Sub

    Public Sub Setup_report_Delayed(ByVal PatientProcedureID() As String, Optional ByVal CasePrivate As Boolean = False, Optional ByVal ForceFullReport As Boolean = False)

        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Dim NoPrivacyStatement As Integer = 0
        Try
            Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
            Dim crParameterFieldLocation As ParameterFieldDefinition = Nothing
            Dim crParameterValues As ParameterValues = Nothing
            If CasePrivate = False Then
                If gOfficeTypeID = 3 Then
                    CR = New rptChartNJ
                Else
                    CR = New rptChart
                End If
            Else
                CR = New rptChartPrivate
            End If

            gWindow_Settings(Me, ReadWrite.sRead)
            Me.MinimizeBox = False
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
            crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
            For i As Integer = 0 To PatientProcedureID.Count - 1
                crParameterFieldLocation = crParameterFieldDefinitions.Item("PatientProcedureID")
                crParameterValues = crParameterFieldLocation.CurrentValues
                crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                crParameterDiscreteValue.Value = PatientProcedureID(i).ToString
                crParameterValues.Add(crParameterDiscreteValue)
            Next
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            CR.SetParameterValue("ForceFullReport", IIf(ForceFullReport, 1, 0))
            If gPrinterNF3 <> "" Then CR.PrintOptions.PrinterName = gPrinterNF3
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

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Dim PatientProcedureIDs As String
            If CrystalReportViewer1.Visible = False Then Exit Sub
            If gPrinterNF3 <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterNF3
            CrystalReportViewer1.PrintReport()
            If gPrintDialog("Please pickup the printed Chart..." & vbCrLf & vbCrLf & "Where the Patient's Chart forms printed successfully?", "Chart Printing") = Windows.Forms.DialogResult.Yes Then
                ChartPrinted = True
                For i As Integer = 0 To lPatientProcedureID.Count - 1
                    PatientProcedureIDs &= ", " & lPatientProcedureID(i)
                Next
                If PatientProcedureIDs <> "" Then
                    PatientProcedureIDs = PatientProcedureIDs.Mid(2)
                End If
                ' Prevent Duplicates
                gSQLUpdateData("DELETE FROM PatientPrintedCharts Where PatientID = " & PatientID & " and BillingProviderID in (select BillingProviderID from PatientProcedures where PatientProcedureID in (" & PatientProcedureIDs & "))")
                ' Save Printed Providers
                gSQLUpdateData("INSERT into PatientPrintedCharts select PatientID, BillingProviderID from PatientProcedures where PatientProcedureID in (" & PatientProcedureIDs & ")")
                gSQLUpdateData("UPDATE PATIENTS SET PrivacyPrintedInd=1 where PatientID=" & PatientID)
                Me.Close()
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Attached: CHART PDF File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " CHART-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
        Subject = "Attached: CHART PDF File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " CHART-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub CrystalReportViewer1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles CrystalReportViewer1.Paint

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        Setup_report_Delayed(lPatientProcedureID, lCasePrivate, lForceFullReport)
        gShowWait(False, PanelWait)
    End Sub

End Class