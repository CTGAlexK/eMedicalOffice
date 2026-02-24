Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmReportVisitsByProcedures
    Private log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

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
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
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
        'SQL = "SELECT      ProcedureStatusID, Description  FROM         PatientProcedureStatuses order by  ProcedureStatusID "
        'Reader = gSQLGetDataReader(SQL)
        'If Reader Is Nothing Then Exit Sub
        ComboBoxProcedureStatus.Items.Clear()
        ComboBoxProcedureStatus.Items.Add(New ValueDescription(-1, "All"))
        'Do Until Reader.Read = False
        'ComboBoxProcedureStatus.Items.Add(New ValueDescription(CLng(Reader("ProcedureStatusID").ToString), Reader("Description").ToString))
        'Loop
        ComboBoxProcedureStatus.Items.Add(New ValueDescription(2, "Complete"))
        ComboBoxProcedureStatus.Items.Add(New ValueDescription(1, "Scheduled"))

        ComboBoxProcedureStatus.SelectedIndex = 0
        'Reader.Close() : Reader.Dispose()

        SQL = "SELECT DiagTypeID,  Diagnostics.DiagID,  Diagnostics.DiagName "
        SQL &= " FROM Diagnostics  "
        SQL &= " WHERE Diagnostics.OfficeID = " & gOfficeID & " ORDER BY DiagName "

        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ComboBoxProcedures.Items.Clear()
        ComboBoxProcedures.Items.Add(New ValueDescription(-1, "All"))
        Do Until Reader.Read = False
            ComboBoxProcedures.Items.Add(New ValueDescription(CLng(Reader("DiagID").ToString), Reader("DiagName").ToString, Val(Reader("DiagTypeID").ToString)))
        Loop
        ComboBoxProcedures.SelectedIndex = 0
        Reader.Close() : Reader.Dispose()
    End Sub
    Private CR As ReportDocument = Nothing
    Private Sub Setup_report()
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Dim SF As String
        gSQLUpdateData("update PatientProcedures set ProcedureInformationID = 0 WHERE (ProcedureInformationID IS NULL)")
        Try
            CR = New rptPatientProceduresPT

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
            SF &= " and (({Diagnostics.CountByVisitInd}=1 and {Procedures.ProcedureTypeID}=0) or {Diagnostics.CountByVisitInd}=0) "
            Dim Parameter As String = "ALL DATES"

            If DateTimePickerFrom.Checked Then
                SF &= " and {Schedule.ScheduleDateTime} >= #" & DateTimePickerFrom.Value.ToString("yyyy,MM,dd") & "# "
                Parameter = DateTimePickerFrom.Value.ToString("MM/dd/yyyy") & "    "
            End If
            If DateTimePickerTo.Checked Then
                SF &= " and {Schedule.ScheduleDateTime} <= #" & DateAdd(DateInterval.Day, 1, DateTimePickerTo.Value).ToString("yyyy,MM,dd") & "# "
                Parameter &= DateTimePickerTo.Value.ToString("MM/dd/yyyy") & "    "
            End If
            CR.SetParameterValue("DateRange", Parameter)

            If CType(ComboBoxProcedures.SelectedItem, ValueDescription).Value > -1 Then
                SF &= " and {PatientProcedures.DiagID} = " & CType(ComboBoxProcedures.SelectedItem, ValueDescription).Value & " "
            End If
            If CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value > -1 Then
                SF &= " and {PatientProcedures.ProcedureStatusID} = " & CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value & " "
            End If

            If ComboBoxProvider.SelectedIndex > 0 Then
                SF &= " and {PatientProcedures.BillingProviderID} = " & CType(ComboBoxProvider.SelectedItem, ValueDescription).Value & " "
            End If


            CR.RecordSelectionFormula = SF

            CrystalReportViewer1.ReportSource = CR
            If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True

        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
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
            Dim Frm As New frmPatientProcedureInformation
            With Frm
                .Height = (Me.Height / 7) * 6
                .Width = (Me.Width / 7) * 6
                .NoDefaultDates = True
                .Timer1.Enabled = False
                .Load_Data()
                .StartPosition = FormStartPosition.CenterParent
                .DateTimePickerFrom.Value = "01/01/2010"
                .DateTimePickerTo.Value = DateTimePickerTo.Value
                .cboReferringCompanyID.SelectedIndex = ComboBoxProcedures.SelectedIndex
                .Find_Data()
                .MinimizeBox = False
                .MaximizeBox = False
                .ShowDialog(Me)
                .Dispose()
            End With
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
        AddHandler ComboBoxProcedures.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler ComboBoxProcedures.Leave, AddressOf sSearchComboBox_Leave
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
                Fname=Fname.Replace(".tmp", ".pdf")
                GoTo Recheck
            End Try
        End If
        Try
            CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)
              
            Msg.SendMail(Fname.ToString, Subject, Subject)
        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
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
                Fname=Fname.Replace(".tmp", ".pdf")
                GoTo Recheck
            End Try
        End If
        Try
            CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)
            gFax(Me, "", Subject, Fname.ToString, gOfficeFax)
        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ComboBoxProcedures_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxProcedures.SelectedIndexChanged
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        ComboBoxProvider.Items.Clear()
        ComboBoxProvider.Items.Add("All")
        If ComboBoxProcedures.SelectedIndex < 1 Then
            ComboBoxProvider.SelectedIndex = 0
            Exit Sub
        End If
        If CType(ComboBoxProcedures.SelectedItem, ValueDescription).Value1 = 2 Then
            SQL = "SELECT     Employees.EmpID as ProviderID, Employees.Fname+' '+Employees.Lname+' '+isnull(Employees.Alias,'') as Provider FROM Employees INNER JOIN EmployeeOffice ON Employees.EmpID = EmployeeOffice.EmpID WHERE     (Employees.PositionID = 5) AND (EmployeeOffice.OfficeID = " & gOfficeID & ")"
        Else
            SQL = "SELECT     OTCompanies.CompanyID AS ProviderID, OTCompanies.CompanyName AS Provider  FROM OTCompanies INNER JOIN OTCompanyDiagnostics ON OTCompanies.CompanyID = OTCompanyDiagnostics.CompanyID WHERE OTCompanyDiagnostics.DiagID = " & CType(ComboBoxProcedures.SelectedItem, ValueDescription).Value & " ORDER BY Provider "
        End If
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxProvider.Items.Add(New ValueDescription(Val(Reader("ProviderID").ToString), Reader("Provider").ToString))
        Loop
        If ComboBoxProvider.Items.Count = 2 Then
            ComboBoxProvider.SelectedIndex = 1
        Else
            ComboBoxProvider.SelectedIndex = 0
        End If

    End Sub

    Private Sub ComboBoxProvider_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxProvider.SelectedIndexChanged

    End Sub
End Class