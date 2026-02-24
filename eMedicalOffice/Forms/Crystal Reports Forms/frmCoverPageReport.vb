Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmCoverPageReport
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public PatientName As String
    Private CR As ReportDocument
    Private lBillID() As String

    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        CloseReport(CR)
        DeleteTempFiles()
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        If gPrinterNF3 <> "" Then lblPrinter.Text = "Printer: " & gPrinterNF3
    End Sub
    Public Sub Setup_report(ByVal BillID() As String)
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Try
            Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
            Dim crParameterFieldLocation As ParameterFieldDefinition = Nothing
            Dim crParameterValues As ParameterValues = Nothing
            lBillID = BillID
            CR = New rptCoverPage
            gShowWait(True, PanelWait, Me)
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
            For i As Integer = 0 To BillID.Count - 1
                crParameterFieldLocation = crParameterFieldDefinitions.Item("BillID")
                crParameterValues = crParameterFieldLocation.CurrentValues
                crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                crParameterDiscreteValue.Value = BillID(i).ToString
                crParameterValues.Add(crParameterDiscreteValue)
            Next
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
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
        If ReportProcessed Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        Me.Close()
    End Sub


    Private Sub DateTimePickerFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer1.Enabled = True
        Application.DoEvents()
    End Sub
    Private ReportProcessed As Boolean
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If CrystalReportViewer1.Visible = False Then Exit Sub
            If gPrinterNF3 <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterNF3
            CrystalReportViewer1.PrintReport()
            ReportProcessed = True
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
        Subject = "Message From " & gOfficeName & " / Attached: NF3 Cover Page PDF File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " NF3COVER-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
            ReportProcessed = True
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Attached: NF3 Cover Page PDF File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " NF3COVER-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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