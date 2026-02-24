Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmItemizedCharges
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public PatientName As String
    Public PatientId As Integer
    Private CR As ReportDocument
    Private lPatientID() As String
    Private Loading As Boolean
    Private lPrintBillInfo As Boolean
    Private SaveBillID() As String
    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        CloseReport(CR)
        DeleteTempFiles()
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        If gPrinterBillingEnvelope <> "" Then lblPrinter.Text = "Printer: " & gPrinterBillingEnvelope

    End Sub
    Public Sub Setup_report(ByVal BillID() As String, pPatientId As String)
        Dim I As Integer
        Dim sBills As String
        PatientId = pPatientId
        btnAddToPatient.Visible = PatientId <> 0
        SaveBillID = BillID
        Try
            Dim crParameterDiscreteValue As ParameterDiscreteValue = Nothing
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions = Nothing
            Dim crParameterFieldLocation As ParameterFieldDefinition = Nothing
            Dim crParameterValues As ParameterValues = Nothing
            CR = New rptItemizedCharges

            gShowWait(True, PanelWait, Me)
            gWindow_Settings(Me, ReadWrite.sRead)

            Me.MinimizeBox = False

            If SetupCrystalSecurityInfo(CR) = False Then Exit Sub

            crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
            For I = 0 To BillID.Count - 1
                crParameterFieldLocation = crParameterFieldDefinitions.Item("BillID")
                crParameterValues = crParameterFieldLocation.CurrentValues
                crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
                crParameterDiscreteValue.Value = BillID(I).ToString
                crParameterValues.Add(crParameterDiscreteValue)
            Next
            'crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
            'crParameterFieldLocation = crParameterFieldDefinitions.Item("BillID")
            'crParameterValues = crParameterFieldLocation.CurrentValues
            'crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'crParameterDiscreteValue.Value = BillID
            'crParameterValues.Add(crParameterDiscreteValue)


            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
            If gPrinterOtherDocuments <> "" Then CR.PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.ReportSource = CR
            If gPrinterOtherDocuments <> "" Then
                CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
                lblPrinter.Text = "Printer: " & gPrinterOtherDocuments
            End If


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
        Dim lEnvelopPaperType As Integer

        Try
            If gPrinterOtherDocuments <> "" Then CType(CrystalReportViewer1.ReportSource, ReportDocument).PrintOptions.PrinterName = gPrinterOtherDocuments
            CrystalReportViewer1.PrintReport()



        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String

        If PatientId <> 0 Then
            Subject = "Message From " & gOfficeName & " / Attached: Itemized Charges PDF File For Patient #" & PatientId
        Else
            Subject = "Message From " & gOfficeName & " / Attached: Itemized Charges PDF File"
        End If
        Subject &= ". Office: " & gOfficeName.ToUpper()
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(PatientName) & " Itemized Charges " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
        Subject = "Itemized Charges: " & gOfficeName & " / Attached: Itemized Charges PDF File For Patient #" & PatientId
        Fname = System.IO.Path.GetTempPath & "Itemized Charges " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
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
            gFax(Me, "", Subject, Fname.ToString, gOfficeFax, 0, "")
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnAddToPatient.Click
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
                    cmd.Parameters.AddWithValue("@PatientID", PatientId)
                    If SaveBillID.Count = 1 Then
                        DocName = "Itemized Chrg Bill #" & SaveBillID(0)
                    Else
                        DocName = "Itemized Chrg Bills #" & String.Join(",", SaveBillID)

                    End If
                    cmd.Parameters.AddWithValue("@DocumentName", DocName)
                    cmd.Parameters.AddWithValue("@DocumentProfileID", 17)
                    cmd.Parameters.AddWithValue("@DocumentImage", arrImage)
                    cmd.Parameters.AddWithValue("@InsertedBy", gCurrentEmployee.EmpID)
                    cmd.Parameters.AddWithValue("@InsertedDate", FormatDateTime(Now, DateFormat.ShortDate))
                    cmd.Parameters.AddWithValue("@PatientProcedureID", 0)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MsgBox(DocName & " has been added to the patient: " & PatientId, MsgBoxStyle.Information, "Information")

        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            gShowWait(False, PanelWait)
        End Try


    End Sub
End Class