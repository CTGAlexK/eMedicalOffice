Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmReportReschedulesCancelations
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

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
        'DateTimePickerFrom.Value = DateAdd("M", -1, Now)
        'DateTimePickerTo.Value = Now
        DateTimePickerFrom.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerFrom", DateAdd("M", -1, Now))
        DateTimePickerTo.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerTo", Now)
        If gPrinterOtherDocuments <> "" Then lblPrinter.Text = "Printer: " & gPrinterOtherDocuments
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        ComboBoxProcedureStatus.Items.Clear()
        ComboBoxProcedureStatus.Items.Add(New ValueDescription(-1, "All"))
        ComboBoxProcedureStatus.Items.Add(New ValueDescription(-1, "Rescheduled"))
        ComboBoxProcedureStatus.Items.Add(New ValueDescription(-1, "Canceled"))
        ComboBoxProcedureStatus.SelectedIndex = 0
        SQL = "SELECT  OfficeID,   OfficeName FROM         ReferringOffices ORDER BY OfficeName "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ComboBoxRefOffice.Items.Clear()
        ComboBoxRefOffice.Items.Add(New ValueDescription(-1, "All"))
        Do Until Reader.Read = False
            ComboBoxRefOffice.Items.Add(New ValueDescription(CLng(Reader("OfficeID").ToString), Reader("OfficeName").ToString))
        Loop
        ComboBoxRefOffice.SelectedIndex = 0
        Reader.Close() : Reader.Dispose()
    End Sub

    Private CR As ReportDocument = Nothing

    Private Sub Setup_report()
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Dim SF As String
        Try
            CR = New rptReschedulesCancelations
            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
            SF = "{Patients.OfficeID} = " & gOfficeID & " "

            If CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value > -1 Then
                SF = SF & " and {PatientReschedulesCancelations.ReScheduleCancelInd} = " & 1 & " "
            End If
            CR.SetParameterValue("FromDate", "NOT SELECTED")
            CR.SetParameterValue("ToDate", "NOT SELECTED")

            If DateTimePickerFrom.Checked Then '
                CR.SetParameterValue("FromDate", DateTimePickerFrom.Value.ToString("yyyy,MM,dd"))
                SF &= " and {PatientReschedulesCancelations.ProcessedDate} >= #" & DateTimePickerFrom.Value.ToString("yyyy,MM,dd") & "# "
            End If

            If DateTimePickerTo.Checked Then '
                CR.SetParameterValue("ToDate", DateTimePickerTo.Value.ToString("yyyy,MM,dd"))
                SF &= " and {PatientReschedulesCancelations.ProcessedDate} < #" & DateAdd(DateInterval.Day, 1, DateTimePickerTo.Value).ToString("yyyy,MM,dd") & "# "
            End If
            If ComboBoxRefOffice.SelectedItem.value > -1 Then
                SF &= " and {Patients.ReferringCompanyID} = " & ComboBoxRefOffice.SelectedItem.value & " "
            End If
            CR.RecordSelectionFormula = SF
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
        If CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value = -100 Then
            Using Frm As New frmPatientProcedureInformation

                With Frm
                    .Height = (Me.Height / 7) * 6
                    .Width = (Me.Width / 7) * 6
                    .NoDefaultDates = True
                    .Timer1.Enabled = False
                    .Load_Data()
                    .StartPosition = FormStartPosition.CenterParent
                    .DateTimePickerFrom.Value = "01/01/2010"
                    .DateTimePickerTo.Value = DateTimePickerTo.Value
                    .cboReferringCompanyID.SelectedIndex = ComboBoxRefOffice.SelectedIndex
                    .Find_Data()
                    .MinimizeBox = False
                    .MaximizeBox = False
                    .ShowDialog(Me)
                    .Dispose()
                End With
            End Using
        End If

        'Catch ex As Exception
        'MsgBox(ex.Message)
        'gProcess_Log(ex.Message, ex.StackTrace, True)
        'End Try
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

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
        AddHandler ComboBoxProcedureStatus.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler ComboBoxProcedureStatus.Leave, AddressOf sSearchComboBox_Leave
        AddHandler ComboBoxRefOffice.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler ComboBoxRefOffice.Leave, AddressOf sSearchComboBox_Leave
    End Sub

    Private Sub ComboBoxProcedureStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxProcedureStatus.SelectedIndexChanged
        If ComboBoxProcedureStatus.SelectedIndex = -1 Then Exit Sub
        DateTimePickerFrom.Enabled = True
        DateTimePickerTo.Enabled = True
        If CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value = -103 Then
            DateTimePickerFrom.Enabled = False
            DateTimePickerTo.Enabled = False
        End If

        If CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value = 9999 Then
            ComboBoxProcedureStatus.SelectedIndex = 0
            Exit Sub
        End If
        If CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value = -102 Then

        End If

        'If CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value = -100 Then
        '    DateTimePickerFrom.Value = DateAdd("M", -1, Now)
        '    DateTimePickerTo.Value = DateAdd("d", -1, Now)
        '    DateTimePickerFrom.Enabled = True
        '    DateTimePickerTo.Enabled = False
        'ElseIf CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value = -101 Then
        '    DateTimePickerFrom.Value = DateAdd("d", -1, Now)
        '    DateTimePickerTo.Value = DateAdd("d", -1, Now)
        '    DateTimePickerFrom.Enabled = False
        '    DateTimePickerTo.Enabled = False
        'ElseIf CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value = -102 Then
        '    DateTimePickerFrom.Value = DateAdd("M", -1, Now)
        '    DateTimePickerTo.Value = DateAdd("d", -1, Now)
        '    DateTimePickerFrom.Enabled = True
        '    DateTimePickerTo.Enabled = False
        'ElseIf CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value = 0 Then
        '    DateTimePickerFrom.Enabled = False
        '    DateTimePickerTo.Enabled = False
        'End If
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
        Subject = "Message From " & gOfficeName & " / Patient Attendency Report / Attached: Patient Attendency Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\PatientAttendencyReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
            MsgBox("Unable to Email report. No report has been loaded. Please select a search criteria and click the Load Button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Patient Attendency Report / Attached: Patient Attendency Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\PatientAttendencyReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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