Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmOfficeStatistics
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
        If ComboBoxProcedureStatus.Visible = False Then
            CheckBoxByDoctor.Anchor = AnchorStyles.Left
            CheckBoxByDoctor.Left = Label5.Left
        End If
    End Sub
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        SQL = "SELECT      ProcedureStatusID, Description  FROM         PatientProcedureStatuses "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        With ComboBoxProcedureStatus.Items
            .Clear()
            .Add(New ValueDescription(-1, "All"))
            Do Until Reader.Read = False
                .Add(New ValueDescription(CLng(Reader("ProcedureStatusID").ToString), Reader("Description").ToString))
            Loop
        End With
        gFindComboItemByValue(ComboBoxProcedureStatus, 2, True)
        Reader.Close() : Reader.Dispose()

        SQL = "SELECT  OfficeID,   OfficeName FROM         ReferringOffices ORDER BY OfficeName "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ComboBoxRefOffice.Items.Clear()
        ComboBoxRefOffice.Items.Add(New ValueDescription(-1, "All Offices"))
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
            Label2.Text = "Connecting Server..."
            Label2.Refresh()
            CR = New rptRefOfficeStatisticReport
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
            Label2.Text = "Loading Report. Please Wait..."
            Label2.Refresh()



            SF = "{Patients.OfficeID}=" & gOfficeID & " "
            SF &= " and {Patients.CaseStatusID} <> 3 "

            'If CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value = -1 Then
            '    CR.SetParameterValue("ProcedureStatusID", -1)
            '    CR.SetParameterValue("NoShow", 0)
            'Else
            '    CR.SetParameterValue("ProcedureStatusID", CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value)
            '    CR.SetParameterValue("NoShow", 0)
            '    SF &= " and {PatientProcedures.ProcedureStatusID} = " & CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value & " "
            'End If
            'CR.SetParameterValue("OfficeID", gOfficeID)
            If ComboBoxRefOffice.SelectedIndex > 0 Then
                CR.SetParameterValue("ReferringOfficeID", ComboBoxRefOffice.SelectedItem.value)
            Else
                CR.SetParameterValue("ReferringOfficeID", 0)
            End If
            If CheckBoxByDoctor.Checked Then
                CR.SetParameterValue("GroupByDoctor", 1)
            Else
                CR.SetParameterValue("GroupByDoctor", 0)
            End If

            CR.SetParameterValue("OfficeID", gOfficeID)
            CR.SetParameterValue("ToDate", DateTimePickerTo.Value.ToString("MM/dd/yyyy"))
            CR.SetParameterValue("FromDate", DateTimePickerFrom.Value.ToString("MM/dd/yyyy"))

            'SF &= " and {PatientProcedures.InsertedDT} > #" & DateTimePickerFrom.Value.ToString("yyyy,MM,dd") & "# and {PatientProcedures.InsertedDT} < #" & DateAdd(DateInterval.Day, 1, DateTimePickerTo.Value).ToString("yyyy,MM,dd") & "# "
            SF &= " and {PatientProcedures.InsertedDT} > Date('" + DateTimePickerFrom.Value.ToString("yyyy, MM, dd") + "') AND {PatientProcedures.InsertedDT} < Date('" + DateAdd(DateInterval.Day, 1, DateTimePickerTo.Value).ToString("yyyy, MM, dd") + "')"
            gShowWait(False, PanelWait)
            Application.DoEvents()
            'CR.RecordSelectionFormula = SF
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
            If CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value = -100 Then
                With frmPatientProcedureInformation
                    .NoDefaultDates = True
                    .Timer1.Enabled = False
                    .Load_Data()
                    .StartPosition = FormStartPosition.CenterParent
                    .DateTimePickerFrom.Value = DateTimePickerFrom.Value
                    .DateTimePickerTo.Value = DateTimePickerTo.Value


                    .Find_Data()
                    .ShowDialog(Me)
                    .Dispose()
                End With
            End If

        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
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
    End Sub
    Private Sub ComboBoxProcedureStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxProcedureStatus.SelectedIndexChanged
        If ComboBoxProcedureStatus.SelectedIndex = -1 Then Exit Sub
        DateTimePickerFrom.Enabled = True
        DateTimePickerTo.Enabled = True
        If CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value = -103 Then
            DateTimePickerFrom.Enabled = False
            DateTimePickerTo.Enabled = False
        End If

        'If CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value = 9999 Then
        '    gFindComboItemByValue(ComboBoxProcedureStatus, -1, True)
        '    Exit Sub
        'End If
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
        Fname = System.IO.Path.GetTempPath & "\OfficeStatistics " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class