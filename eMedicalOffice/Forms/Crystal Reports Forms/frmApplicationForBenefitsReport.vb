Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmApplicationForBenefitsReport
    Private log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public PatientName As String
    Private CR As ReportDocument
    Private lPatientID() As String

    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        gSQLDeleteRecord("delete from PrintNF2 where EmpID=" & gCurrentEmployee.EmpID)
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
    End Sub
    Public Response As Boolean
    Public Sub Setup_report(ByVal PatientID() As String)
        lPatientID = PatientID
        gShowWait(True, PanelWait, Me)
        Timer2.Enabled = True
        gWindow_Settings(Me, ReadWrite.sRead)
    End Sub
    Public Sub lSetup_report(ByVal PatientID() As String)
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Try
            CR = New rptApplicationForBenefits
            Me.MinimizeBox = False
            

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub


            gSQLDeleteRecord("delete from PrintNF2 where EmpID=" & gCurrentEmployee.EmpID)
            For i As Integer = 0 To PatientID.Count - 1
                gSQLUpdateData("INSERT INTO PrintNF2 (PatientID, EmpID) VALUES(" & PatientID(i).ToString & ", " & gCurrentEmployee.EmpID & ")")

            Next
            Application.DoEvents()
            CR.SetParameterValue("EmpID", gCurrentEmployee.EmpID)
            'Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
            'Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
            'Dim crParameterFieldLocation As ParameterFieldDefinition = Nothing
            'Dim crParameterValues As ParameterValues = Nothing
            'crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
            'For i As Integer = 0 To PatientID.Count - 1

            '    crParameterFieldLocation = crParameterFieldDefinitions.Item("PatientID")
            '    crParameterValues = crParameterFieldLocation.CurrentValues
            '    crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            '    crParameterDiscreteValue.Value = PatientID(i).ToString
            '    crParameterValues.Add(crParameterDiscreteValue)
            'Next
            'crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
            CrystalReportViewer1.ReportSource = CR
            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True
            gShowWait(False, PanelWait)
            If gPrinterNF3 <> "" Then
                CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterNF3
                lblPrinter.Text = "Printer: " & gPrinterNF3
            End If

        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
            gShowWait(False, PanelWait)
        End Try
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        If ReportProcessed Then
            DialogResult = Windows.Forms.DialogResult.OK
        End If
        Me.Close()
    End Sub


    Private Sub DateTimePickerFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer1.Enabled = True
        Application.DoEvents()
    End Sub
    Private ReportProcessed As Boolean
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If CrystalReportViewer1.Visible = False Then Exit Sub
            If gPrinterNF3 <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterNF3
            CrystalReportViewer1.PrintReport()
            ReportProcessed = True
        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
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
        Subject = "Attached: Application For Benefits PDF File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " ApplicationForBenefits-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
            ReportProcessed = True
        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Attached: Application For Benefits PDF File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " ApplicationForBenefits-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
            ReportProcessed = True
        Catch ex As Exception
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        lSetup_report(lPatientID)
    End Sub
End Class