Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmInsuranceCompanyStatistics
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
        If gOfficeTypeID = 2 Then
            Label6.Visible = False
            lblReportType.Visible = False
            ComboBoxRefOffice.Visible = False
            cboReportType.Visible = False
            cboReportType.SelectedIndex = 0
            ComboBoxRefOffice.SelectedIndex = 0
        End If
        'DateTimePickerFrom.Value = DateAdd("M", -1, Now)
        'DateTimePickerTo.Value = Now
        DateTimePickerFrom.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerFrom", DateAdd("d", -7, Now))
        DateTimePickerTo.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerTo", Now)
        If gPrinterOtherDocuments <> "" Then lblPrinter.Text = "Printer: " & gPrinterOtherDocuments
    End Sub
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String

        With cboReportType
            .Items.Add(New ValueDescription(0, "Insurance Companies"))
            .Items.Add(New ValueDescription(1, "By Ref Companies"))
            .SelectedIndex = 0
        End With
        SQL = "SELECT  OfficeID,   OfficeName FROM         ReferringOffices ORDER BY OfficeName "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ComboBoxRefOffice.Items.Clear()
        ComboBoxRefOffice.Items.Add(New ValueDescription(-1, "All"))
        Do Until Reader.Read = False
            ComboBoxRefOffice.Items.Add(New ValueDescription(CLng(Reader("OfficeID").ToString), Reader("OfficeName").ToString))
        Loop
        ComboBoxRefOffice.SelectedIndex = 0
        Reader.Close()

        SQL = "SELECT     EmpID, Fname+' '+Lname + ' ' + Alias as EmpName, BillingPrv FROM Employees WHERE BillingPrv = 1 AND EmpID IN (SELECT EmpID FROM EmployeeOffice WHERE OfficeID = " & gOfficeID & ") ORDER BY Fname, Lname "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ComboBoxBillingProviderID.Items.Clear()
        ComboBoxBillingProviderID.Items.Add(New ValueDescription(-1, "All"))
        Do Until Reader.Read = False
            ComboBoxBillingProviderID.Items.Add(New ValueDescription(CLng(Reader("EmpID").ToString), Reader("EmpName").ToString))
        Loop
        ComboBoxBillingProviderID.SelectedIndex = 0
        ComboBoxRefOffice.SelectedIndex = 0
        Reader.Close()



        Reader.Close() : Reader.Dispose()
    End Sub
    Private CR As ReportDocument = Nothing
    Private Sub Setup_report()
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Dim SF As String
        Try
            If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
                If CType(cboReportType.SelectedItem, ValueDescription).Value = 0 Then
                    CR = New rptInsuranceCompanyStatisticsReport
                Else
                    CR = New rptInsuranceCompanyStatisticsReportByRefOffice
                End If
            Else
                CR = New rptInsuranceCompanyStatisticsReportPT
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




            SF = "{Patients.OfficeID}=" & gOfficeID & " "
            SF &= " and {Patients.CaseStatusID} <> 3 "
            SF &= " and {PatientProcedures.ProcedureStatusID}=2 "
            SF &= " and {Patients.InsuranceCompanyID}>0 "

            CR.SetParameterValue("FromDate", DateTimePickerFrom.Value.ToString("MM/dd/yyyy"))
            CR.SetParameterValue("ToDate", DateTimePickerTo.Value.ToString("MM/dd/yyyy"))
            CR.SetParameterValue("ReferringOfficeID", ComboBoxRefOffice.SelectedItem.value)
            CR.SetParameterValue("BillingProvider", "")

            If CType(ComboBoxRefOffice.SelectedItem, ValueDescription).Value > -1 Then
                SF = SF & " and {ReferringOffices.OfficeID}= " & CType(ComboBoxRefOffice.SelectedItem, ValueDescription).Value & " "
            End If
            If CType(ComboBoxBillingProviderID.SelectedItem, ValueDescription).Value > -1 Then
                SF = SF & " and {PatientProcedures.BillingProviderID}= " & CType(ComboBoxBillingProviderID.SelectedItem, ValueDescription).Value & " "
                CR.SetParameterValue("BillingProvider", CType(ComboBoxBillingProviderID.SelectedItem, ValueDescription).Description)
            End If

            SF &= " and {Schedule.ScheduleDateTime} > #" & DateTimePickerFrom.Value.ToString("yyyy,MM,dd") & "# and {Schedule.ScheduleDateTime} < #" & DateAdd(DateInterval.Day, 1, DateTimePickerTo.Value).ToString("yyyy,MM,dd") & "# "


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
        Try
            If CrystalReportViewer1.ReportSource Is Nothing Then
                MsgBox("Unable to Print report. No report has been loaded. Please select a search criteria and click the Load Button.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.PrintReport()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
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
        AddHandler ComboBoxRefOffice.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler ComboBoxRefOffice.Leave, AddressOf sSearchComboBox_Leave
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
        Subject = "Message From " & gOfficeName & " / Office Statistics Report / Attached: Office Statistics Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\OfficeStatisticsReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
        Subject = "Message From " & gOfficeName & " / Office Statistics Report / Attached: Office Statistics Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\OfficeStatisticsReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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