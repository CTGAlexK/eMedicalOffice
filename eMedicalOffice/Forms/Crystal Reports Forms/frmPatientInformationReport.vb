Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmPatientInformationReport
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public PatientName As String
    Private CR As ReportDocument
    Private lPatientID() As Long
    Private Loading As Boolean = False
    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        gWindow_Settings(Me, ReadWrite.sWrite)
        SaveSetting(My.Application.Info.ProductName, "Settings", "Reports\PatientInfoShowProcedures", CheckBoxShowProcedures.Checked)
        SaveSetting(My.Application.Info.ProductName, "Settings", "Reports\PatientInfoShowBills", CheckBoxShowBills.Checked)
        SaveSetting(My.Application.Info.ProductName, "Settings", "Reports\PatientInfoShowCamments", CheckBoxShowComments.Checked)
        CloseReport(CR)
        DeleteTempFiles()
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        If gPrinterOtherDocuments <> "" Then lblPrinter.Text = "Printer: " & gPrinterOtherDocuments
    End Sub
    Public Sub Setup_report(ByVal PatientID() As Long)
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Dim LI As ListViewItem
        If PatientID Is Nothing Then Exit Sub
        Try
            lPatientID = PatientID
            CR = New rptPatientInfo
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


            CR.SetParameterValue("PatientID", PatientID)
            CR.SetParameterValue("ShowTransportation", Math.Abs(Val(CheckBoxShowBills.Checked)))
            CR.SetParameterValue("ShowProcedures", Math.Abs(Val(CheckBoxShowProcedures.Checked)))
            CR.SetParameterValue("ShowComments", Math.Abs(Val(CheckBoxShowComments.Checked)))
            If gPrinterOtherDocuments <> "" Then CR.PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.ReportSource = CR
            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True
            gShowWait(False, PanelWait)

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

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        If lPatientID.Length = 1 Then
            PatientName = gSQLGetSingleValueString("select Fname + ' ' + Lname as PName from Patients where PatientID=" & lPatientID(0))
            Subject = "Message From " & gOfficeName & " / Patient: " & PatientName & " / Attached: Patient Info PDF File"
            Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
        Else
            Subject = "Message From " & gOfficeName & " / Patients Information Report / Attached: Patient Info PDF File"
            Fname = System.IO.Path.GetTempPath & "\PatiensInformationReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
        End If

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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxShowBills.CheckedChanged
        If Loading = True Then Exit Sub
        Setup_report(lPatientID)
    End Sub

    Private Sub CheckBoxShowProcedures_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxShowProcedures.CheckedChanged
        If Loading = True Then Exit Sub
        Setup_report(lPatientID)
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Loading = True
        CheckBoxShowProcedures.Checked = GetSetting(My.Application.Info.ProductName, "Settings", "Reports\PatientInfoShowProcedures", True)
        CheckBoxShowBills.Checked = GetSetting(My.Application.Info.ProductName, "Settings", "Reports\PatientInfoShowBills", False)
        CheckBoxShowComments.Checked = GetSetting(My.Application.Info.ProductName, "Settings", "Reports\PatientInfoShowCamments", False)
        Loading = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        If lPatientID.Length = 1 Then
            PatientName = gSQLGetSingleValueString("select Fname + ' ' + Lname as PName from Patients where PatientID=" & lPatientID(0))
            Subject = "Message From " & gOfficeName & " / Patient: " & PatientName & " / Attached: Patient Info PDF File"
            Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
        Else
            Subject = "Message From " & gOfficeName & " / Patients Information Report / Attached: Patient Info PDF File"
            Fname = System.IO.Path.GetTempPath & "\PatientsInformationReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
        End If

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

    Private Sub CheckBoxShowComments_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxShowComments.CheckedChanged
        If Loading = True Then Exit Sub
        Setup_report(lPatientID)
    End Sub
End Class