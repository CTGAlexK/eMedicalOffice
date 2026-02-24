Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmReportPatientVisitsPT
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
        SQL = "SELECT     Diagnostics.DiagID, Diagnostics.DiagName+' / ' +OTCompanies.CompanyName as Diag FROM Diagnostics INNER JOIN OTCompanies ON Diagnostics.OTCompanyID = OTCompanies.CompanyID WHERE Diagnostics.OfficeID = " & gOfficeID & " ORDER BY OTCompanies.CompanyName, Diagnostics.DiagName "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        With ComboBoxFilter.Items
            .Clear()
            .Add(New ValueDescription(0, "All Patients"))
            .Add(New ValueDescription(9999, "----------------------------------------------"))
            .Add(New ValueDescription(-1, "Completed Procedures"))
            .Add(New ValueDescription(-2, "No Procedures"))
            .Add(New ValueDescription(9999, "----------------------------------------------"))
            .Add(New ValueDescription(-3, "Outsource Services"))
            .Add(New ValueDescription(-4, "No Outsource Services"))
            .Add(New ValueDescription(9999, "----------------------------------------------"))
            Do Until Reader.Read = False
                .Add(New ValueDescription(Reader("DiagID").ToString, Reader("Diag").ToString))
            Loop
        End With
        With ComboBoxStatus.Items
            .Add(New ValueDescription(0, "All Statuses"))
            .Add(New ValueDescription(1, "Scheduled"))
            .Add(New ValueDescription(2, "Complete"))
            .Add(New ValueDescription(3, "Result Received"))
        End With
        gFindComboItemByValue(ComboBoxFilter, -1, True)
        Reader.Close() : Reader.Dispose()
    End Sub
    Private CR As ReportDocument = Nothing
    Private Sub Setup_report()
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Dim SF As String
        gSQLUpdateData("update PatientProcedures set ProcedureInformationID = 0 WHERE (ProcedureInformationID IS NULL)")
        Try
            CR = New rptPatientVisitsReportPT



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



            SF = "{Patients.OfficeID} = " & gOfficeID & " "
            CR.SetParameterValue("OfficeID", gOfficeID)
            If CType(ComboBoxFilter.SelectedItem, ValueDescription).Value = -1 Then 'All Scheduled
                CR.SetParameterValue("NoShow", 0)
                CR.SetParameterValue("ProcedureStatusID", ComboBoxFilter.SelectedItem.value)
                SF &= " AND {PatientProcedures.ProcedureStatusID} = 1 "
            ElseIf CType(ComboBoxFilter.SelectedItem, ValueDescription).Value = -101 Then
                CR.SetParameterValue("ProcedureStatusID", 1)
                CR.SetParameterValue("NoShow", 1)
                SF &= " AND {PatientProcedures.ProcedureStatusID} = 1 "
            ElseIf CType(ComboBoxFilter.SelectedItem, ValueDescription).Value = -100 Then 'Referring Offices Report
                CR.SetParameterValue("NoShow", 0)
                CR.SetParameterValue("ProcedureStatusID", -100) ' Parameter not in use, but exist
                SF &= " AND ({PatientProcedures.ProcedureStatusID} = 1 or {PatientProcedures.ProcedureStatusID} = 2) "
            ElseIf CType(ComboBoxFilter.SelectedItem, ValueDescription).Value = -103 Then ' Not Scheduled - Not In USe
                CR.SetParameterValue("NoShow", 0)
            ElseIf CType(ComboBoxFilter.SelectedItem, ValueDescription).Value = -105 Then 'Attendance Report
                CR.SetParameterValue("NoShow", 1)
                CR.SetParameterValue("ProcedureStatusID", -1)
            ElseIf CType(ComboBoxFilter.SelectedItem, ValueDescription).Value = -102 Then ' NoShow

            Else
                CR.SetParameterValue("NoShow", 0)
                CR.SetParameterValue("ProcedureStatusID", ComboBoxFilter.SelectedItem.value)
                SF &= " AND {PatientProcedures.ProcedureStatusID} = " & ComboBoxFilter.SelectedItem.value
            End If
            CR.SetParameterValue("FromDate", DateTimePickerFrom.Value.ToString("MM/dd/yyyy"))
            CR.SetParameterValue("ToDate", DateTimePickerTo.Value.ToString("MM/dd/yyyy"))
            If CType(ComboBoxFilter.SelectedItem, ValueDescription).Value = 0 Then ' "Not Scheduled"
                'Dates parameters not in use in selection formula
                CR.SetParameterValue("FromDate", "01/01/1900")
                CR.SetParameterValue("ToDate", "12/31/9999")
            Else
                SF &= " and {Schedule.ScheduleDateTime} > #" & DateTimePickerFrom.Value.ToString("yyyy,MM,dd") & "# and {Schedule.ScheduleDateTime} < #" & DateAdd(DateInterval.Day, 1, DateTimePickerTo.Value).ToString("yyyy,MM,dd") & "# "
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
        'If CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value = -100 Then
        '    Dim Frm As New frmPatientProcedureInformation
        '    Frm.Height = (Me.Height / 7) * 6
        '    Frm.Width = (Me.Width / 7) * 6
        '    Frm.NoDefaultDates = True
        '    Frm.Timer1.Enabled = False
        '    Frm.Load_Data()
        '    Frm.StartPosition = FormStartPosition.CenterParent
        '    Frm.DateTimePickerFrom.Value = "01/01/2010"
        '    Frm.DateTimePickerTo.Value = DateTimePickerTo.Value
        '    Frm.cboReferringCompanyID.SelectedIndex = ComboBoxRefOffice.SelectedIndex
        '    Frm.Find_Data()
        '    Frm.ShowDialog(Me)
        '    Frm.Dispose()
        'End If

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
    Private Sub ComboBoxFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxFilter.SelectedIndexChanged
        If ComboBoxFilter.SelectedIndex = -1 Then Exit Sub
        DateTimePickerFrom.Enabled = True
        DateTimePickerTo.Enabled = True

        If CType(ComboBoxFilter.SelectedItem, ValueDescription).Value > 0 Or CType(ComboBoxFilter.SelectedItem, ValueDescription).Value = -3 Then
            If ComboBoxStatus.Enabled = False Then
                ComboBoxStatus.Enabled = True
                ComboBoxStatus.SelectedIndex = 0
            End If
        Else
            ComboBoxStatus.Enabled = False
            ComboBoxStatus.SelectedIndex = -1
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