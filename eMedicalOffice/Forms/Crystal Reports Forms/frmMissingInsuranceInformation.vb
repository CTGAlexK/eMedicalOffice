Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmMissingInsuranceInformation
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
        If gPrinterNF3 <> "" Then
            lblPrinter.Text = "Printer: " & gPrinterOtherDocuments
        End If
    End Sub
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        SQL = "SELECT  OfficeID,   OfficeName, Fax1 FROM  ReferringOffices ORDER BY OfficeName "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ComboBoxRefOffice.Items.Clear()
        ComboBoxRefOffice.Items.Add(New ValueDescription(-1, "All"))
        Do Until Reader.Read = False
            ComboBoxRefOffice.Items.Add(New ValueDescription(CLng(Reader("OfficeID").ToString), Reader("OfficeName").ToString, Reader("Fax1").ToString))
        Loop
        ComboBoxRefOffice.SelectedIndex = 0
        Reader.Close() : Reader.Dispose()
        With ComboBoxType
            .Items.Add("Missing Insurance Info")
            .Items.Add("Missing Initial Report")
            .Items.Add("Missing Police Report")
            .Items.Add("Missing NF2 Report")
            .SelectedIndex = 0
        End With
    End Sub
    Private CR As ReportDocument = Nothing
    Private Sub Setup_report()
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Dim SF As String
        Dim Msg As String
        Dim Header As String
        Try
            'CR = New rptMissingPoliceReport
            CR = New rptMissingInformation
            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub

            Select Case ComboBoxType.SelectedIndex
                Case 0
                    'CR = New rptMissingInsuranceInformation
                    SF = "((isnull({Patients.ClaimNumber}) OR ({Patients.ClaimNumber}='')) or {Patients.InsuranceCompanyID}=0 or isnull({Patients.InsuranceCompanyID})) "
                    Msg = "PLEASE FAX US INSURANCE INFORMATION ON THE FOLLOWING PATIENTS AS SOON AS POSSIBLE."
                    Header = "MISSING INSURANCE INFORMATION"
                Case 1
                    'CR = New rptMissingInitialreport
                    SF = "((isnull({Patients.InitialReportReceived})) OR ({Patients.InitialReportReceived}=0)) "
                    Msg = "PLEASE FAX US INITIAL REPORTS ON THE FOLLOWING PATIENTS AS SOON AS POSSIBLE."
                    Header = "MISSING INITIAL REPORTS"
                Case 2
                    SF = "((isnull({Patients.PoliceReportReceived})) OR ({Patients.PoliceReportReceived}=0)) "
                    Msg = "PLEASE FAX US POLICE REPORTS ON THE FOLLOWING PATIENTS AS SOON AS POSSIBLE."
                    Header = "MISSING POLICE REPORTS"
                Case 3
                    SF = "(isnull({Patients.NF2Date})) "
                    Msg = "PLEASE FAX US NF2 WITH POM REPORTS ON THE FOLLOWING PATIENTS AS SOON AS POSSIBLE."
                    Header = "MISSING NF2 WITH POM REPORTS"
            End Select





            SF &= " and {Patients.CaseStatusID} = 1 "
            If CheckBox1.Checked Then
                SF &= " and {PatientProcedures.ProcedureStatusID} = 2 "
            End If
            SF &= " and {Patients.CaseTypeID}=1 "
            SF &= " AND {Patients.OfficeID}=" & gOfficeID
            SF &= " AND isnull({Patients.ReferringCompanyID})=false "
            If DateTimePickerFrom.Checked Then
                SF &= " and {Schedule.ScheduleDateTime} >= #" & DateTimePickerFrom.Value.ToString("yyyy,MM,dd") & "# "
            End If
            If DateTimePickerTo.Checked Then
                SF &= " and {Schedule.ScheduleDateTime} < #" & DateAdd(DateInterval.Day, 1, DateTimePickerTo.Value).ToString("yyyy,MM,dd") & "# "
            End If

            If ComboBoxRefOffice.SelectedIndex > 0 Then
                SF &= " and {Patients.ReferringCompanyID}=" & CType(ComboBoxRefOffice.SelectedItem, ValueDescription).Value
            End If
            CR.RecordSelectionFormula = SF
            CR.SetParameterValue("Message", Msg)
            CR.SetParameterValue("Header", Header)
            CR.SetParameterValue("OfficeID", gOfficeID)
            If DateTimePickerFrom.Checked Then
                CR.SetParameterValue("FromDate", DateTimePickerFrom.Value.ToString("MM/dd/yyyy"))
            Else
                CR.SetParameterValue("FromDate", "")
            End If

            If DateTimePickerTo.Checked Then
                CR.SetParameterValue("ToDate", DateTimePickerTo.Value.ToString("MM/dd/yyyy"))
            Else
                CR.SetParameterValue("ToDate", "")
            End If
            'CR.SetParameterValue("ReferringOfficeID", ComboBoxRefOffice.SelectedItem.value)
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
        If ComboBoxType.SelectedIndex = -1 Then
            MsgBox("Unable to process your request. The report type should be selected.", MsgBoxStyle.Exclamation)
            ComboBoxType.Focus()
            Exit Sub
        End If
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
        Subject = "Message From " & gOfficeName & " / Missing Insurance Information Report / Attached: Missing Insurance Information Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\MissingInsuranceInformationReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
        Subject = "Message From " & gOfficeName & " / " & ComboBoxType.Text & " / Attached: " & ComboBoxType.Text & " PDF File"
        Fname = System.IO.Path.GetTempPath & "\MissingInsuranceInformationReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
            gFax(Me, "", Subject, Fname.ToString, gOfficeFax, 0, IIf(ComboBoxRefOffice.SelectedIndex > 0, ComboBoxRefOffice.Text, ""))
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim I As Integer
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Dim SQL As String = ""
        Dim MsgDates As String
        If ComboBoxType.SelectedIndex = -1 Then
            MsgBox("Unable to process your request. The report type should be selected.", MsgBoxStyle.Exclamation)
            ComboBoxType.Focus()
            Exit Sub
        End If
        If DateTimePickerFrom.Checked Then MsgDates &= "Procedure Date From: " & DateTimePickerFrom.Text & vbCrLf
        If DateTimePickerTo.Checked Then MsgDates &= "Procedure Date To: " & DateTimePickerTo.Text & vbCrLf

        If MsgBox("Please confirm you want to produce and fax report to all " & ComboBoxRefOffice.Items.Count - 1 & " reffering offices" & vbCrLf & vbCrLf & "Report Type: " & ComboBoxType.Text & IIf(MsgDates <> "", vbCrLf & vbCrLf & MsgDates, ""), MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Me.Enabled = False
        For I = 1 To ComboBoxRefOffice.Items.Count - 1
            ComboBoxRefOffice.SelectedIndex = I
            Application.DoEvents()
            SQL = " SELECT COUNT(*) "
            SQL &= "FROM   Schedule INNER JOIN PatientProcedures ON Schedule.ScheduleID=PatientProcedures.ScheduleID INNER JOIN Patients ON PatientProcedures.PatientID=Patients.PatientID LEFT OUTER JOIN ReferringOffices ON Patients.ReferringCompanyID=ReferringOffices.OfficeID "
            SQL &= " WHERE PatientProcedures.ProcedureStatusID = 2 "
            SQL &= " and Patients.CaseStatusID = 1 "
            SQL &= " and Patients.CaseTypeID=1 "
            SQL &= " AND Patients.OfficeID= " & gOfficeID
            SQL &= " AND Patients.ReferringCompanyID= " & CType(ComboBoxRefOffice.Items(I), ValueDescription).Value
            If DateTimePickerFrom.Checked Then SQL &= " and Schedule.ScheduleDateTime >= '" & DateTimePickerFrom.Value.ToString("MM/dd/yyyy") & "' "
            If DateTimePickerTo.Checked Then SQL &= " and Schedule.ScheduleDateTime < '" & DateAdd(DateInterval.Day, 1, DateTimePickerTo.Value).ToString("MM/dd/yyyy") & "' "

            Select Case ComboBoxType.SelectedIndex
                Case 0
                    SQL &= " and (Patients.ClaimNumber='' or Patients.ClaimNumber is null or Patients.InsuranceCompanyID=0 or Patients.InsuranceCompanyID is null)"
                Case 1
                    SQL &= " and (Patients.InitialReportReceived=0 or Patients.InitialReportReceived is null ) "
                Case 2
                    SQL &= " and (Patients.PoliceReportReceived=0 or Patients.PoliceReportReceived is null )  "
            End Select

            If gSQLGetSingleValue(SQL) = 0 Then
                GoTo NextOffice
            End If
            cmdLoad_Click(Nothing, Nothing)
            Subject = "Message From " & gOfficeName & " / " & ComboBoxType.Text & " / Attached: " & ComboBoxType.Text & " PDF File"
            Fname = System.IO.Path.GetTempPath & "\MissingPatientInformationReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
                If gFax(Me, CType(ComboBoxRefOffice.Items(I), ValueDescription).Value1, Subject, Fname.ToString, gOfficeFax, 0, CType(ComboBoxRefOffice.Items(I), ValueDescription).Description, True) = False Then
                    Exit For
                End If
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
                Exit For
            End Try
NextOffice:
        Next
        Me.Enabled = True
        CrystalReportViewer1.Hide()
        ComboBoxRefOffice.SelectedIndex = 0
        MsgBox("Batch Fax Process Complete.", MsgBoxStyle.Information)
    End Sub
End Class