Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmBillingEnvelops
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public PatientName As String
    Private CR As ReportDocument
    Private lPatientID() As String
    Private Loading As Boolean
    Private lPrintBillInfo As Boolean

    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        CloseReport(CR)
        DeleteTempFiles()
    End Sub

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        If gPrinterBillingEnvelope <> "" Then lblPrinter.Text = "Printer: " & gPrinterBillingEnvelope
        Loading = True
        cboEnvelopPaperType.Items.Add(New ValueDescription(20, "#10 Envelope, 4 1/8- by 9 1/2-inches"))
        cboEnvelopPaperType.Items.Add(New ValueDescription(261, "Post Card Large"))
        gFindComboItemByValue(cboEnvelopPaperType, gEnvelopPaperType, True)
        cboWcAddress.Items.Add("Insurance Address")
        cboWcAddress.Items.Add("WCB Address")
        cboWcAddress.SelectedIndex = 0

        Loading = False
    End Sub

    Public Sub Setup_report(ByVal ID() As String, Optional ByVal lEnvelopPaperType As Integer = 0, Optional ByVal PrintBillInfo As Boolean = True)
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        If Loading = True Then Exit Sub

        lPrintBillInfo = PrintBillInfo
        If lEnvelopPaperType = 0 Then lEnvelopPaperType = gEnvelopPaperType
        Try
            Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
            Dim crParameterFieldLocation As ParameterFieldDefinition = Nothing
            Dim crParameterValues As ParameterValues = Nothing
            lPatientID = ID
            If PrintBillInfo Then
                Select Case lEnvelopPaperType
                    Case 9
                        CR = New rptBillingEnvelope9
                        If Not gEnvelopNoPageSize Then CR.PrintOptions.PaperSize = PaperSize.PaperEnvelope9
                    Case 261
                        CR = New rptBillingEnvelope261
                        If Not gEnvelopNoPageSize Then CR.PrintOptions.PaperSize = PaperSize.PaperEnvelopeB5
                    Case Else
                        CR = New rptBillingEnvelope
                        If Not gEnvelopNoPageSize Then CR.PrintOptions.PaperSize = PaperSize.PaperEnvelope10
                End Select
            Else
                cboWcAddress.Visible = False
                'if printing from the Patient Profile - BillId will be used for PatientID
                Select Case lEnvelopPaperType
                    Case 9
                        CR = New rptEnvelope9
                        If Not gEnvelopNoPageSize Then CR.PrintOptions.PaperSize = PaperSize.PaperEnvelope9
                    Case 261
                        CR = New rptEnvelope261
                        If Not gEnvelopNoPageSize Then CR.PrintOptions.PaperSize = PaperSize.PaperEnvelopeB5
                    Case Else
                        CR = New rptEnvelope
                        If Not gEnvelopNoPageSize Then CR.PrintOptions.PaperSize = PaperSize.PaperEnvelope10
                End Select
            End If

            gShowWait(True, PanelWait, Me)

            Me.MinimizeBox = False
            If gOfficeTypeID Then

            End If

            'ConInfo.ConnectionInfo.UserID = gSQLServerUID
            'ConInfo.ConnectionInfo.Password = gSQLServerPassword
            'ConInfo.ConnectionInfo.ServerName = gSQLServerName
            'ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
            ' For intCounter = 0 To CR.Database.Tables.Count - 1
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
            'If lEnvelopPaperType <> 261 Then
            '    CR.PrintOptions.PaperSize = lEnvelopPaperType
            'End If
            crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
            'if printing from the Patient Profile - BillId will be used for PatientID
            For i As Integer = 0 To ID.Count - 1
                crParameterFieldLocation = crParameterFieldDefinitions.Item("BillID")
                crParameterValues = crParameterFieldLocation.CurrentValues
                crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                crParameterDiscreteValue.Value = ID(i).ToString
                crParameterValues.Add(crParameterDiscreteValue)
            Next
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
            If PrintBillInfo Then
                CR.SetParameterValue("AddressType", IIf(cboWcAddress.SelectedIndex > -1, cboWcAddress.SelectedIndex, 0))
            End If

            If gEnvelopShiftToCenter Then
                CR.SetParameterValue("ShiftEnvelope", 1)
                'CR.PrintOptions.PaperSize = CType(System.Drawing.Printing.PaperKind.Letter, CrystalDecisions.Shared.PaperSize)
                CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 480, 240, 231))
            Else
                'If gEnvelopNoPageSize Then
                '    CR.PrintOptions.PaperSize = CType(System.Drawing.Printing.PaperKind.Letter, CrystalDecisions.Shared.PaperSize)
                'End If
                CR.SetParameterValue("ShiftEnvelope", 0)
                CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 475, 245, 230))
            End If
            If gPrinterBillingEnvelope <> "" Then CType(CR, ReportDocument).PrintOptions.PrinterName = gPrinterBillingEnvelope
            If gPrinterBillingEnvelope <> "" Then CR.PrintOptions.PrinterName = gPrinterBillingEnvelope
            CrystalReportViewer1.ReportSource = CR
            gCrystalViewerTabs(CrystalReportViewer1, False)
            Timer1.Enabled = True
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
        Dim lEnvelopPaperType As Integer
        If cboEnvelopPaperType.SelectedIndex < 0 Then
            lEnvelopPaperType = gEnvelopPaperType
        Else
            lEnvelopPaperType = CType(cboEnvelopPaperType.SelectedItem, ValueDescription).Value
        End If

        Try
            If CrystalReportViewer1.Visible = False Then Exit Sub
            If gPrinterBillingEnvelope <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterBillingEnvelope
            If Not gEnvelopNoPageSize Then
                Select Case lEnvelopPaperType
                    Case 9
                        CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PaperSize = PaperSize.PaperEnvelope9
                    Case 261
                        CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PaperSize = PaperSize.PaperEnvelopeB5
                    Case Else
                        CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PaperSize = PaperSize.PaperEnvelope10
                End Select
            End If
            CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PaperSource = PaperSource.Envelope

            CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        CrystalReportViewer1.Visible = True
        cboWcAddress.Visible = True
        cboEnvelopPaperType.Visible = True
        cboWcAddress.BringToFront()
        cboEnvelopPaperType.BringToFront()
        gShowWait(False, PanelWait)
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Application.DoEvents()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Attached: Mailing Envelops PDF File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " MENV-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboEnvelopPaperType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEnvelopPaperType.SelectedIndexChanged
        If cboEnvelopPaperType.SelectedIndex = -1 Then Exit Sub
        Setup_report(lPatientID, CType(cboEnvelopPaperType.SelectedItem, ValueDescription).Value, lPrintBillInfo)
    End Sub

    Private Sub cboWcAddress_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboWcAddress.SelectedIndexChanged

    End Sub

    Private saveSelectedAddressIndex As Integer

    Private Sub cboWcAddress_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboWcAddress.SelectionChangeCommitted
        cboWcAddress.DroppedDown = False
        Application.DoEvents()
        If cboWcAddress.SelectedIndex = -1 Then Exit Sub
        Setup_report(lPatientID, CType(cboEnvelopPaperType.SelectedItem, ValueDescription).Value, lPrintBillInfo)
    End Sub

End Class