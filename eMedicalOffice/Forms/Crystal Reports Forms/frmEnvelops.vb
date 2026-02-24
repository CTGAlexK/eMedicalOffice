Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmEnvelops
    Public PatientName As String
    Private CR As ReportDocument
    Private lPatientID() As String
    Private Loading As Boolean
    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        If gPrinterBillingEnvelope <> "" Then lblPrinter.Text = "Printer: " & gPrinterBillingEnvelope
        Loading = True
        cboEnvelopPaperType.Items.Add(New ValueDescription(20, "#10 Envelope, 4 1/8- by 9 1/2-inches"))
        cboEnvelopPaperType.Items.Add(New ValueDescription(261, "Post Card Large"))
        gFindComboItemByValue(cboEnvelopPaperType, gEnvelopPaperType, True)
        Loading = False
    End Sub
    Public Sub Setup_report(ByVal PatientID() As String, Optional ByVal lEnvelopPaperType As Integer = 0)
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        If Loading = True Then Exit Sub
        If lEnvelopPaperType = 0 Then lEnvelopPaperType = gEnvelopPaperType
        Try
            Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
            Dim crParameterFieldLocation As ParameterFieldDefinition = Nothing
            Dim crParameterValues As ParameterValues = Nothing
            lPatientID = PatientID
            Select Case lEnvelopPaperType
                Case 9
                    CR = New rptPatientEnvelope9
                Case 261
                    CR = New rptPatientEnvelope261
                Case Else
                    CR = New rptPatientEnvelope
            End Select


            gShowWait(True, PanelWait, Me)
            gWindow_Settings(Me, ReadWrite.sRead)

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
            For i As Integer = 0 To PatientID.Count - 1
                crParameterFieldLocation = crParameterFieldDefinitions.Item("PatientID")
                crParameterValues = crParameterFieldLocation.CurrentValues
                crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                crParameterDiscreteValue.Value = PatientID(i).ToString
                crParameterValues.Add(crParameterDiscreteValue)
            Next
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
            CrystalReportViewer1.ReportSource = CR
            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True
            gShowWait(False, PanelWait)

        Catch ex As Exception
            gProcess_Log(ex.Message, ex.StackTrace, True)
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
            If gPrinterBillingEnvelope <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterBillingEnvelope
            CrystalReportViewer1.PrintReport()
        Catch ex As Exception
            MsgBox(ex.Message)
            gProcess_Log(ex.Message, ex.StackTrace, True)
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
        Subject = "Message From " & gOfficeName & " / Attached: Mailing Envelops PDF File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " MENV-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboEnvelopPaperType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEnvelopPaperType.SelectedIndexChanged
        If cboEnvelopPaperType.SelectedIndex = -1 Then Exit Sub
        Setup_report(lPatientID, CType(cboEnvelopPaperType.SelectedItem, ValueDescription).Value)
    End Sub
End Class