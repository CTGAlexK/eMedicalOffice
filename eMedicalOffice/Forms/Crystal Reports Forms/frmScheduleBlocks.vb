Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net
Public Class frmScheduleBlocks
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private Sub ScheduleSearchPopup_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            DateTimePickerFrom.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        SaveSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerFrom", DateTimePickerFrom.Value)
        SaveSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerTo", DateTimePickerTo.Value)
        CloseReport(CR)
        DeleteTempFiles()
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        gSetup_GotFocus(Me)
        Setup_SearchComboBoxes()
        Load_Data()
        If gPrinterOtherDocuments <> "" Then lblPrinter.Text = "Printer: " & gPrinterOtherDocuments
        'DateTimePickerFrom.Value = DateAdd("M", -1, Now)
        'DateTimePickerTo.Value = Now
        'DateTimePickerFrom.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerFrom", DateAdd("M", -1, Now))
        'DateTimePickerTo.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerTo", Now)
    End Sub
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String

        SQL = "SELECT     DiagID, DiagName FROM Diagnostics where OfficeID = " & gOfficeID & " ORDER BY DiagName"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ComboBoxDiag.Items.Clear()
        ComboBoxDiag.Items.Add(New ValueDescription(-1, "All"))
        Do Until Reader.Read = False
            ComboBoxDiag.Items.Add(New ValueDescription(CLng(Reader("DiagID").ToString), Reader("DiagName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        ComboBoxDiag.SelectedIndex = 0
    End Sub
    Private CR As ReportDocument = Nothing
    Private Sub Setup_report()
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Dim SF As String
        Try
            CR = New rptScheduleBlocks
            'ConInfo.ConnectionInfo.UserID = gSQLServerUID
            'ConInfo.ConnectionInfo.Password = gSQLServerPassword
            'ConInfo.ConnectionInfo.ServerName = gSQLServerName
            'ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase




            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub



            SF = "{ScheduleBlock.OfficeID} = " & gOfficeID & " "
            If ComboBoxDiag.SelectedIndex > 0 Then
                SF &= " AND {ScheduleBlock.DiagID}= " & CType(ComboBoxDiag.SelectedItem, ValueDescription).Value & " "
            End If

            If DateTimePickerFrom.Checked Then
                SF &= " and {ScheduleBlock.ScheduleDateTime} >= #" & DateTimePickerFrom.Value.ToString("yyyy,MM,dd") & "# "
            End If
            If DateTimePickerTo.Checked Then
                SF &= " and {ScheduleBlock.ScheduleDateTime} <= #" & DateAdd(DateInterval.Day, 1, DateTimePickerTo.Value).ToString("yyyy,MM,dd") & "# "
            End If

            CR.RecordSelectionFormula = SF
            CR.SetParameterValue("FromDate", DateTimePickerFrom.Value.ToString("yyyy,MM,dd"))
            CR.SetParameterValue("ToDate", DateTimePickerTo.Value.ToString("yyyy,MM,dd"))

            If gPrinterOtherDocuments <> "" Then CR.PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.ReportSource = CR
            If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
            log.Debug(ex.Message, ex)
        End Try
    End Sub


    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub


    Private Sub DateTimePickerFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerFrom.ValueChanged
        'Timer1.Enabled = True
        Application.DoEvents()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Try
        If CrystalReportViewer1.ReportSource Is Nothing Then
            MsgBox("Unable to Print report. No report has been loaded. Please select a search criteria and click the Load Button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
        CrystalReportViewer1.PrintReport()
        'Catch ex As Exception
        'MsgBox(ex.Message)
        'gProcess_Log(ex.Message, ex.StackTrace, True)
        'End Try
    End Sub
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        CrystalReportViewer1.SuspendLayout()
        gShowWait(True, PanelWait, Me)
        Setup_report()
        CrystalReportViewer1.ResumeLayout(True)
        gShowWait(False, PanelWait)
    End Sub
    Private Sub Setup_SearchComboBoxes()
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
        Subject = "Message From " & gOfficeName & " / Outsource Services Report/ Attached: Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\OutsourceServicesReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
            log.Debug("Error Sending Email", ex)
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
        Subject = "Message From " & gOfficeName & " / Outsource Services Report / Attached: Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\OutsourceServicesReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
            log.Debug("Error Sending Fax", ex)
        End Try
    End Sub

    Private Sub ComboBoxProvider_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class