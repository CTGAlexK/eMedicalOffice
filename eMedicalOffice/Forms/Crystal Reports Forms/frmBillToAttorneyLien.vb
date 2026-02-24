Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmBillToAttorneyLien
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private CR As ReportDocument
    Public BillId As Long
    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        CloseReport(CR)
        DeleteTempFiles()
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        If gPrinterOtherDocuments <> "" Then lblPrinter.Text = "Printer: " & gPrinterOtherDocuments
        gShowWait(True, PanelWait, Me)
        Me.MinimizeBox = False
        Timer1.Enabled = True
    End Sub
    Public Sub Setup_report_ByBills(ByVal BillIDs() As Long)
        '    Dim intCounter As Integer
        '    Dim ConInfo As New TableLogOnInfo
        '    Try

        '        Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
        '        Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
        '        Dim crParameterFieldLocation As ParameterFieldDefinition = Nothing
        '        Dim crParameterValues As ParameterValues = Nothing
        '        CR = New rptReadingsByBill


        '        gShowWait(True, PanelWait, Me)
        '        gWindow_Settings(Me, ReadWrite.sRead)
        '        Me.MinimizeBox = False
        '        'ConInfo.ConnectionInfo.UserID = gSQLServerUID
        '        'ConInfo.ConnectionInfo.Password = gSQLServerPassword
        '        'ConInfo.ConnectionInfo.ServerName = gSQLServerName
        '        'ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase

        '        'For intCounter = 0 To CR.Database.Tables.Count - 1

        '        '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.UserID = gSQLServerUID
        '        '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.Password = gSQLServerPassword
        '        '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.ServerName = gSQLServerName
        '        '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase

        '        '    Application.DoEvents()
        '        '    CR.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
        '        '    Application.DoEvents()
        '        'Next
        '        'CR.Refresh()


        '        If SetupCrystalSecurityInfo(CR) = False Then Exit Sub


        '        crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
        '        For i As Integer = 0 To BillIDs.Count - 1
        '            crParameterFieldLocation = crParameterFieldDefinitions.Item("BillIDs")
        '            crParameterValues = crParameterFieldLocation.CurrentValues
        '            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        '            crParameterDiscreteValue.Value = BillIDs(i).ToString
        '            crParameterValues.Add(crParameterDiscreteValue)
        '        Next
        '        crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
        '        CrystalReportViewer1.ReportSource = CR
        '        gCrystalViewerTabs(CrystalReportViewer1, False)
        '        CrystalReportViewer1.Visible = True
        '        gShowWait(False, PanelWait)

        '    Catch ex As Exception
        '        TopMost = False
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        '        log.Error(ex.Message, ex)
        '        gShowWait(False, PanelWait)
        '    End Try

    End Sub
    Public Sub Setup_report()
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Try

            CR = New rptLienBill


            CrystalReportViewer1.Visible = True
            Application.DoEvents()
            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            CR.SetParameterValue("BillID", BillId)
            CR.RecordSelectionFormula = "{Bills.BillID}=" & BillId & ""
            gShowWait(False, PanelWait)
            If gPrinterOtherDocuments <> "" Then CR.PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.ReportSource = CR
            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True


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
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Attached: Bill # " & BillId & " PDF File"
        Fname = System.IO.Path.GetTempPath & "\BILL-" & BillId & " " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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

    Private Sub ButtonFax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFax.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Attached: Bill # " & BillId & " PDF File"
        Fname = System.IO.Path.GetTempPath & "\BILL-" & BillId & " " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Fname As String
        SaveFileDialog1.FileName = "BILL-" & BillId & " " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Fname = SaveFileDialog1.FileName
            Try
                CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try
        End If
    End Sub
End Class