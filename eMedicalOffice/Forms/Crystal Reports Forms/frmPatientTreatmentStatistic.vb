Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPatientTreatmentStatistic

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
        'DateTimePickerFrom.Value = DateAdd("M", -1, Now)
        'DateTimePickerTo.Value = Now
        DateTimePickerFrom.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerFrom", DateAdd("d", -7, Now))
        DateTimePickerTo.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerTo", Now)
        Load_Data()
    End Sub
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        SQL = "SELECT     Diagnostics.DiagID, Diagnostics.DiagName, OTCompanies.CompanyName, Diagnostics.DiagTypeID FROM         Diagnostics LEFT OUTER JOIN OTCompanies ON Diagnostics.OTCompanyID = OTCompanies.CompanyID WHERE Diagnostics.OfficeID = " & gOfficeID & " AND Diagnostics.ActiveInd = 1 ORDER BY OTCompanies.CompanyName, Diagnostics.DiagName"
        ComboBoxTreatmentType.Items.Add(New ValueDescription(0, "All"))
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxTreatmentType.Items.Add(New ValueDescription(Reader("DiagID").ToString, Reader("DiagName").ToString & IIf(Reader("CompanyName").ToString <> "", "   -   " & Reader("CompanyName").ToString, ""), Val(Reader("DiagTypeID").ToString)))
        Loop
        Reader.Close()
        ComboBoxTreatmentType.SelectedIndex = 0
    End Sub
    Private CR As ReportDocument = Nothing
    Private Sub Setup_report()
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Dim SF As String
        Try
            If ComboBoxTreatmentType.SelectedIndex > 0 Then
                If CType(ComboBoxTreatmentType.SelectedItem, ValueDescription).Value1 = 3 Then
                    CR = New rptPatientsTreatmentStatisticByService
                Else
                    CR = New rptPatientsTreatmentStatisticByTreatment
                End If
            Else
                CR = New rptPatientsTreatmentStatistic
            End If


            ConInfo.ConnectionInfo.UserID = gSQLServerUID
            ConInfo.ConnectionInfo.Password = gSQLServerPassword
            ConInfo.ConnectionInfo.ServerName = gSQLServerName
            ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase


            SF = "{Patients.OfficeID}=" & gOfficeID & " "
            SF &= " and {Patients.CaseStatusID} <> 3 "
            SF &= " and {PatientProcedures.ProcedureStatusID}=2 "
            SF &= " and {Patients.InsuranceCompanyID}>0 "


            For intCounter = 0 To CR.Database.Tables.Count - 1

                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.UserID = gSQLServerUID
                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.Password = gSQLServerPassword
                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.ServerName = gSQLServerName
                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase

                Application.DoEvents()
                CR.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
                Application.DoEvents()
            Next
            CR.Refresh()
            If ComboBoxTreatmentType.SelectedIndex > 0 Then
                CR.SetParameterValue("FromDate", DateTimePickerFrom.Value.ToString("MM/dd/yyyy"))
                CR.SetParameterValue("ToDate", DateAdd(DateInterval.Day, 1, DateTimePickerTo.Value).ToString("MM/dd/yyyy"))
                CR.SetParameterValue("OfficeID", gOfficeID)
                CR.SetParameterValue("DiagID", CType(ComboBoxTreatmentType.SelectedItem, ValueDescription).Value)
            Else
                CR.SetParameterValue("@FromDate", DateTimePickerFrom.Value.ToString("MM/dd/yyyy"))
                CR.SetParameterValue("@ToDate", DateAdd(DateInterval.Day, 1, DateTimePickerTo.Value).ToString("MM/dd/yyyy"))
                CR.SetParameterValue("@OfficeID", gOfficeID)

            End If

            'If CType(ComboBoxDiagID.SelectedItem, ValueDescription).Value > -1 Then
            '    SF = SF & " and {ReferringOffices.OfficeID}= " & CType(ComboBoxDiagID.SelectedItem, ValueDescription).Value & " "
            'End If
            'SF &= " and {Schedule.ScheduleDateTime} > #" & DateTimePickerFrom.Value.ToString("yyyy,MM,dd") & "# and {Schedule.ScheduleDateTime} < #" & DateAdd(DateInterval.Day, 1, DateTimePickerTo.Value).ToString("yyyy,MM,dd") & "# "


            'CRCR.RecordSelectionFormula = SF
            CrystalReportViewer1.ReportSource = CR
            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
            gProcess_Log(ex.Message, ex.StackTrace, True)
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
            MsgBox(ex.Message)
            gProcess_Log(ex.Message, ex.StackTrace, True)
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
  
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If CrystalReportViewer1.ReportSource Is Nothing Then
            MsgBox("Unable to Email report. No report has been loaded. Please select a search criteria and click the Load Button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Patients Treatment Statistics Report / Attached: Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\PatientsTreatmentStatisticsReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If CrystalReportViewer1.ReportSource Is Nothing Then
            MsgBox("Unable to Email report. No report has been loaded. Please select a search criteria and click the Load Button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Patients Treatment Statistics Report / Attached: Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\PatientsTreatmentStatisticsReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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