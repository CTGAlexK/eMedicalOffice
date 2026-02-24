Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmReadingReport
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private CR As ReportDocument
    Private PatientProcedureID() As Long
    Private SavePatientID As Integer
    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        CloseReport(CR)
        DeleteTempFiles()
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        If gPrinterOtherDocuments <> "" Then lblPrinter.Text = "Printer: " & gPrinterOtherDocuments
    End Sub
    Public Sub Setup_report_ByBills(ByVal BillIDs() As Long, PatientID As Integer)
        SavePatientID = PatientID

        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Try
            btnAddToPatient.Visible = PatientID > 0
            Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
            Dim crParameterFieldLocation As ParameterFieldDefinition = Nothing
            Dim crParameterValues As ParameterValues = Nothing
            CR = New rptReadingsByBill


            gShowWait(True, PanelWait, Me)
            gWindow_Settings(Me, ReadWrite.sRead)
            Me.MinimizeBox = False
            ConInfo.ConnectionInfo.UserID = gSQLServerUID
            ConInfo.ConnectionInfo.Password = gSQLServerPassword
            ConInfo.ConnectionInfo.ServerName = gSqlServerName
            ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase

            For intCounter = 0 To CR.Database.Tables.Count - 1

                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.UserID = gSQLServerUID
                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.Password = gSQLServerPassword
                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.ServerName = gSqlServerName
                CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase

                Application.DoEvents()
                CR.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
                Application.DoEvents()
            Next
            CR.Refresh()


            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub


            crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
            For i As Integer = 0 To BillIDs.Count - 1
                crParameterFieldLocation = crParameterFieldDefinitions.Item("BillIDs")
                crParameterValues = crParameterFieldLocation.CurrentValues
                crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                crParameterDiscreteValue.Value = BillIDs(i).ToString
                crParameterValues.Add(crParameterDiscreteValue)
            Next
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
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
    Public Sub Setup_report(ByVal paramPatientProcedureID() As Long, PatientID As Integer)
        SavePatientID = PatientID
        PatientProcedureID = paramPatientProcedureID
        gShowWait(True, PanelWait, Me)
        gWindow_Settings(Me, ReadWrite.sRead)
        Me.MinimizeBox = False
        Timer1.Enabled = True
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
    Dim errorCount As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Timer1.Enabled = False
        Try

            Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
            Dim crParameterFieldLocation As ParameterFieldDefinition = Nothing
            Dim crParameterValues As ParameterValues = Nothing
            CR = New rptReading
            CR.Refresh()

            If SetupCrystalSecurityInfo(CR) = False Then
                If errorCount < 5 Then
                    CloseReport(CR)
                    CR.Dispose()
                    DeleteTempFiles()
                    errorCount = errorCount + 1
                    Text = "eMedical Office Procedure Readings " & errorCount
                    Timer1.Enabled = True
                    Exit Sub
                End If
                Exit Sub
            End If


            crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
            For i As Integer = 0 To PatientProcedureID.Count - 1
                crParameterFieldLocation = crParameterFieldDefinitions.Item("PatientProcedureID")
                crParameterValues = crParameterFieldLocation.CurrentValues
                crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                crParameterDiscreteValue.Value = PatientProcedureID(i).ToString
                crParameterValues.Add(crParameterDiscreteValue)
            Next
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
            If gPrinterOtherDocuments <> "" Then CR.PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.ReportSource = CR
            gCrystalViewerTabs(CrystalReportViewer1, False)
            CrystalReportViewer1.Visible = True
            gShowWait(False, PanelWait)

        Catch ex As Exception
            If errorCount < 5 Then
                CloseReport(CR)
                CR.Dispose()
                DeleteTempFiles()
                errorCount = errorCount + 1
                Text = "eMedical Office Procedure Readings " & errorCount
                Timer1.Enabled = True
                Exit Sub
            End If
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            gShowWait(False, PanelWait)
            Close()
        End Try

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Attached: Patient's Procedure Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\PR-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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

    Private Sub ButtonFax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFax.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Attached: Patient's Procedure Report PDF File"
        Fname = System.IO.Path.GetTempPath & "\PR-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Fname As String
        SaveFileDialog1.FileName = "PR-" & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Fname = SaveFileDialog1.FileName
            Try
                CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try
        End If
    End Sub

    Private Sub btnAddToPatient_Click(sender As Object, e As EventArgs) Handles btnAddToPatient.Click
        Dim Msg As New SendFileTo
        Dim Fname As String
        Dim arrImage() As Byte
        Fname = System.IO.Path.GetTempFileName
        Fname = Fname.Replace(".tmp", ".pdf")
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
            arrImage = gSQLReadFileToArray(Fname)
            Dim Sql As String
            Dim DocName As String
            Sql = "INSERT INTO Documents (PatientID, DocumentProfileID, DocumentImage, DocumentName, InsertedBy, InsertedDate, PatientProcedureID) "
            Sql = Sql & " VALUES(@PatientID, @DocumentProfileID, @DocumentImage, @DocumentName, @InsertedBy, @InsertedDate, @PatientProcedureID)"
            Using adoConnect = New SqlClient.SqlConnection(gConnectionString & "; Connection Timeout=60")
                adoConnect.Open()
                Using cmd = New SqlClient.SqlCommand(Sql, adoConnect)
                    cmd.CommandTimeout = 60
                    cmd.Parameters.AddWithValue("@PatientID", SavePatientID)
                    DocName = "Reading Report(s)"
                    cmd.Parameters.AddWithValue("@DocumentName", DocName)
                    cmd.Parameters.AddWithValue("@DocumentProfileID", 17)
                    cmd.Parameters.AddWithValue("@DocumentImage", arrImage)
                    cmd.Parameters.AddWithValue("@InsertedBy", gCurrentEmployee.EmpID)
                    cmd.Parameters.AddWithValue("@InsertedDate", FormatDateTime(Now, DateFormat.ShortDate))
                    cmd.Parameters.AddWithValue("@PatientProcedureID", 0)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MsgBox(DocName & " has been added to the patient: " & SavePatientID, MsgBoxStyle.Information, "Information")

        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            gShowWait(False, PanelWait)
        End Try
    End Sub
End Class