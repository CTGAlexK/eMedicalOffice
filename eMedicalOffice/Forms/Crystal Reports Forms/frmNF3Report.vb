Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmNF3Report
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public PatientName As String
    Private CR As ReportDocument
    Private lBillID() As String
    Private SaveCaseType As Integer
    Private Loading As Boolean

    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim sBills As String
        Dim I As Integer
        If SaveCaseType = 5 Then
            For I = 0 To lBillID.Length - 1
                sBills += ", " & lBillID(I)
            Next

            If gPrintDialog("Where the bill(s) printed successfully?", "Bill Printing Confirmation") = MsgBoxResult.Yes Then
                If sBills = "" Then Exit Sub
                sBills = sBills.Mid(2)
                gSQLUpdateData("UPDATE BILLS SET BillStatusID = 2 Where BillStatusID = 1  and BillID in (" & sBills & ")")
            End If
        End If
        gWindow_Settings(Me, ReadWrite.sWrite)
        gOneSettingSave("UserPrePrintedPaper", IIf(chkUserPrePrintedPaper.Checked, 1, 0))
        CloseReport(CR)
        DeleteTempFiles()
    End Sub

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loading = True
        Button3.Visible = True
        gWindow_Settings(Me, ReadWrite.sRead)
        chkUserPrePrintedPaper.Checked = Val(gOneSettingRead("UserPrePrintedPaper"))
        Loading = False
        Application.DoEvents()
        Timer1.Enabled = True
    End Sub

    Public Response As Boolean
    Private InitialLoaded As Boolean
    Public Sub Setup_report(ByVal BillID() As String, ByVal CaseType As Integer, Optional forceReportType As Integer = -1)
        SaveCaseType = CaseType
        cboReportType.Enabled = False
        Try
            If forceReportType = -1 Then
                If CaseType = 2 Then
                    Label1.Text = "WORKERS COMPENSATION BILL(s)"
                    'Change to rptNF1500 since July 1 2022
                    If CDate(Date.Now.ToShortDateString) >= CDate("07/01/2022") Then
                        CR = New rptNF1500
                        forceReportType = 1
                    Else
                        CR = New rptWCRadiology
                        forceReportType = 2
                    End If
                    'CR = New rptWCRadiology

                Else
                    If gOfficeTypeID = 3 Then
                        Label1.Text = "NF3 BILL(s)"
                        CR = New rptNF1500
                        forceReportType = 1
                    Else
                        Label1.Text = "NF3 BILL(s)"
                        If gNF3Template = 1 Then
                            CR = New rptNF3
                        Else
                            CR = New rptNF3Ver2
                        End If
                        forceReportType = 0
                    End If

                End If
            Else
                Select Case forceReportType
                    Case 0  'NF3
                        If gNF3Template = 1 Then
                            CR = New rptNF3
                        Else
                            CR = New rptNF3Ver2
                        End If
                    Case 1  'NF1500
                        CR = New rptNF1500
                    Case 2  'C-4
                        CR = New rptWCRadiology

                End Select
            End If
            Label3.Text = "Connecting Database..."

            lBillID = BillID
            gShowWait(True, PanelWait, Me)

            Me.MinimizeBox = False
            cboReportType.SelectedIndex = forceReportType

        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            gShowWait(False, PanelWait)
            InitialLoaded = True
            cboReportType.Visible = True
            cboReportType.Enabled = True
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
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Try
            Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
            Dim crParameterFieldLocation As ParameterFieldDefinition = Nothing
            Dim crParameterValues As ParameterValues = Nothing
            Dim I As Integer
            Dim sBills As String
            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub

            crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
            For I = 0 To lBillID.Count - 1
                crParameterFieldLocation = crParameterFieldDefinitions.Item("BillID")
                crParameterValues = crParameterFieldLocation.CurrentValues
                crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                crParameterDiscreteValue.Value = lBillID(I).ToString
                crParameterValues.Add(crParameterDiscreteValue)
                sBills = ", " & lBillID(I)
            Next
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
            If cboReportType.SelectedIndex = 1 Then
                CR.SetParameterValue("NoBackground", Val(IIf(chkUserPrePrintedPaper.Checked, 1, 0)))
            End If
            CR.SetParameterValue("NoSignature", Val(IIf(CheckBox1.Checked, 1, 0)))
            CR.SetParameterValue("NoCover", 0)

            gShowWait(False, PanelWait)
            Application.DoEvents()
            If gPrinterNF3 <> "" Then CR.PrintOptions.PrinterName = gPrinterNF3
            CrystalReportViewer1.ReportSource = CR
            If gPrinterNF3 <> "" Then
                CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterNF3
                lblPrinter.Text = "Printer: " & gPrinterNF3
            End If

            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True
            Panel2.Enabled = True
            InitialLoaded = True
            cboReportType.Visible = True
            cboReportType.BringToFront()
            cboReportType.Enabled = True
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            gShowWait(False, PanelWait)
        End Try
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Attached: NF3 PDF File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " NF3-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
            ReportProcessed = True
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
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
        Subject = "Attached: NF3 PDF File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " NF3-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
            ReportProcessed = True
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Panel2.Enabled = False
        Setup_report(lBillID, SaveCaseType, cboReportType.SelectedIndex)
        Timer1.Enabled = True

    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Setup_report(lBillID, SaveCaseType, cboReportType.SelectedIndex)
    End Sub

    Private Sub cboReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReportType.SelectedIndexChanged
        If cboReportType.SelectedIndex = -1 Then Exit Sub
        chkUserPrePrintedPaper.Visible = cboReportType.SelectedIndex = 1
        If cboReportType.Visible = False Then Exit Sub
        'Button3.Visible = cboReportType.SelectedIndex = 1
        '02/02/2024 AS PER SERGEY
        Button3.Visible = True

        Panel2.Enabled = False
        Setup_report(lBillID, SaveCaseType, cboReportType.SelectedIndex)
        Timer1.Enabled = True
    End Sub

    Private Sub chkUserPrePrintedPaper_CheckedChanged(sender As Object, e As EventArgs) Handles chkUserPrePrintedPaper.CheckedChanged
        If Loading Then Exit Sub
        Panel2.Enabled = False
        Setup_report(lBillID, SaveCaseType, cboReportType.SelectedIndex)
        Timer1.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        gShowWait(True, PanelWait, Me)
        eFileBill(Me, lBillID)
        gShowWait(False, PanelWait, Me)
    End Sub
End Class