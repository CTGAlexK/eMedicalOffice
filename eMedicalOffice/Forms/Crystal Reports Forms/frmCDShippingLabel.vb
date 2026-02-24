Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmCDShippingLabel
    Public PatientName As String
    Private CR As ReportDocument
    Private lBillID() As String

    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        If gPrinterBillingEnvelope <> "" Then lblPrinter.Text = "Printer: " & gPrinterBillingEnvelope
    End Sub
    Public Sub Setup_Report(ByVal CDID() As String)
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Try
            Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
            Dim crParameterFieldLocation As ParameterFieldDefinition = Nothing
            Dim crParameterValues As ParameterValues = Nothing
            Dim margins As PageMargins
            CR = New rptCDShippingLabel

            lBillID = CDID
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

            For i As Integer = 0 To CDID.Count - 1
                crParameterFieldLocation = crParameterFieldDefinitions.Item("CDID")
                crParameterValues = crParameterFieldLocation.CurrentValues
                crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                crParameterDiscreteValue.Value = CDID(i).ToString
                crParameterValues.Add(crParameterDiscreteValue)
            Next
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            CR.PrintOptions.PrinterName = gPrinterFileLabel
            ' Get the PageMargins structure and set the 

            ' margins for the report.

            margins = CR.PrintOptions.PageMargins
            margins.bottomMargin = 0
            margins.leftMargin = 0
            margins.rightMargin = 0
            margins.topMargin = 0
            ' Apply the page margins.
            CR.PrintOptions.ApplyPageMargins(margins)

            CrystalReportViewer1.ReportSource = CR
            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True
            gShowWait(False, PanelWait)
            CrystalReportViewer1.PrintReport()
        Catch ex As Exception
            MsgBox(ex.Message)
            gProcess_Log(ex.Message, ex.StackTrace, True)
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
            If gPrinterBillingEnvelope <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterBillingEnvelope
            'Dim margins As PageMargins
            'margins =CR.PrintOptions.PageMargins
            'margins.bottomMargin = 0
            'margins.leftMargin = 0
            'margins.rightMargin = 0
            'margins.topMargin = 0
            ' Apply the page margins.
            '.PrintOptions.PrinterName = gPrinterFileLabel
            '.PrintOptions.ApplyPageMargins(margins)
            'CRCR.PrintToPrinter(1, False, 0, 0)

            CrystalReportViewer1.PrintReport()
        Catch ex As Exception
            MsgBox(ex.Message)
            gProcess_Log(ex.Message, ex.StackTrace, True)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Attached: POM PDF File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " POM-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Attached: POM PDF File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " POM-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
End Class