Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmBillingTodayPayments
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmBillingTodayPayments_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)
        gSpread_Settings(Me, FpSpreadChecks, ReadWrite.sWrite)
        pdfViewer.CloseDocument(False)
    End Sub

    Private Sub frmBillingTodayPayments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pdfViewer.CloseDocument()
        Load_Data()
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
        gSpread_Settings(Me, FpSpreadChecks, ReadWrite.sRead)
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim Li As ListViewItem
        SQL = "SELECT convert(varchar,PaymentDate,111) as DT, SUM(PaymentAmount) AS Amt, COUNT(PaymentID) as C FROM BillPayments group by convert(varchar,PaymentDate,111) order by convert(varchar,PaymentDate,111) desc"
        Reader = gSQLGetDataReader(SQL)
        Do Until Reader.Read = False
            If IsDate(Reader("DT").ToString) Then
                Li = ListView1.Items.Add(CDate(Reader("DT").ToString).ToString("MM/dd/yyyy, dddd"))
            Else
                Li = ListView1.Items.Add("Unknown")
            End If
            Li.Tag = Reader("DT").ToString
            Li.SubItems.Add(Reader("C").ToString)
            Li.SubItems.Add(Val(Reader("Amt").ToString).ToString("c"))
        Loop
        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()

        End If

    End Sub

    Private Sub Load_Payments()

        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim C As Integer
        Dim T As Double
        Dim Msg As String
        Dim D As Integer
        FpSpreadChecks.ActiveSheet.Rows.Count = 0
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        If IsDate(ListView1.SelectedItems(0).Tag) Then
            D = DateDiff(DateInterval.Day, CDate(ListView1.SelectedItems(0).Tag), Now)
            SQL = " SELECT     BillPayments.BillID, BillPayments.PaymentAmount, BillPayments.CheckNumber, InsuranceCompanies.CompanyName, Employees.CorporationName FROM BillPayments INNER JOIN Bills ON BillPayments.BillID = Bills.BillID INNER JOIN InsuranceCompanies ON Bills.InsCompanyID = InsuranceCompanies.CompanyID INNER JOIN Employees ON Bills.BillingProviderID = Employees.EmpID WHERE     (DATEDIFF(d, BillPayments.PaymentDate, GETDATE()) = " & D & ")"
            SQL &= " UNION "
            SQL &= "SELECT     ImageDiskRequests.ID AS BillID, ImageDiskRequests.PaidAmount AS PaymentAmount, ImageDiskRequests.CheckNumber, ImageDiskRequests.Recepient AS CompanyName, Employees.CorporationName FROM ImageDiskRequests INNER JOIN Patients ON ImageDiskRequests.PatientID = Patients.PatientID INNER JOIN Bills on ImageDiskRequests.BillID = Bills.BillID INNER JOIN Employees ON Bills.BillingProviderID = Employees.EmpID  WHERE     (DATEDIFF(d, ImageDiskRequests.PaymentDate, GETDATE()) = " & D & ") "
            SQL &= " ORDER BY  CorporationName "
        Else
            SQL = " SELECT     BillPayments.BillID, BillPayments.PaymentAmount, BillPayments.CheckNumber, InsuranceCompanies.CompanyName, Employees.CorporationName FROM BillPayments LEFT OUTER JOIN Bills ON BillPayments.BillID = Bills.BillID LEFT OUTER JOIN InsuranceCompanies ON Bills.InsCompanyID = InsuranceCompanies.CompanyID LEFT OUTER JOIN Employees ON Bills.BillingProviderID = Employees.EmpID WHERE PaymentDate is null "
            'SQL = " SELECT     BillPayments.BillID, BillPayments.PaymentAmount, BillPayments.CheckNumber, '' as CompanyName, '' as CorporationName FROM BillPayments WHERE PaymentDate is null "
        End If

        Reader = gSQLGetDataReader(SQL)

        Do Until Reader.Read = False
            C = C + 1
            FpSpreadChecks.ActiveSheet.Rows.Count = C

            FpSpreadChecks.ActiveSheet.Cells(C - 1, 0).Text = C
            FpSpreadChecks.ActiveSheet.Cells(C - 1, 1).Text = Reader("BillID").ToString
            FpSpreadChecks.ActiveSheet.Cells(C - 1, 2).Text = Reader("CheckNumber").ToString
            FpSpreadChecks.ActiveSheet.Cells(C - 1, 3).Text = CDbl(Reader("PaymentAmount").ToString).ToString("c")
            FpSpreadChecks.ActiveSheet.Cells(C - 1, 4).Text = Reader("CompanyName").ToString
            FpSpreadChecks.ActiveSheet.Cells(C - 1, 5).Text = Reader("CorporationName").ToString
            T += Val(Reader("PaymentAmount").ToString)
        Loop
        If FpSpreadChecks.ActiveSheet.Rows.Count > 0 Then
            FpSpreadChecks.ActiveSheet.Rows.Count += 2
            FpSpreadChecks.ActiveSheet.Cells(FpSpreadChecks.ActiveSheet.Rows.Count - 1, 2).Text = "Total: "
            FpSpreadChecks.ActiveSheet.Cells(FpSpreadChecks.ActiveSheet.Rows.Count - 1, 3).Text = T.ToString("c")
            FpSpreadChecks.ActiveSheet.Rows(FpSpreadChecks.ActiveSheet.Rows.Count - 1).BackColor = Color.LightGray
            FpSpreadChecks.ActiveSheet.Rows(FpSpreadChecks.ActiveSheet.Rows.Count - 1).Font = New Font(FpSpreadChecks.Font, FontStyle.Bold)
        End If
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub Load_Slip()

        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim C As Integer
        Dim T As Double
        Dim ST As Double
        Dim Msg As String
        Dim CorporationName As String
        SQL = "SELECT     SUM(BillPayments.PaymentAmount) AS Amount, BillPayments.CheckNumber, Employees.CorporationName, Employees.CheckingAccountNumber FROM BillPayments INNER JOIN Bills ON BillPayments.BillID = Bills.BillID INNER JOIN Employees ON Bills.BillingProviderID = Employees.EmpID WHERE(DateDiff(d, BillPayments.PaymentDate, GETDATE()) = 0) "
        SQL &= " GROUP BY Employees.CorporationName, Employees.CheckingAccountNumber, BillPayments.CheckNumber "
        SQL &= " UNION "
        SQL &= "SELECT     SUM(ImageDiskRequests.PaidAmount) AS Amount, ImageDiskRequests.CheckNumber, Employees.CorporationName, Employees.CheckingAccountNumber FROM ImageDiskRequests INNER JOIN Patients ON ImageDiskRequests.PatientID = Patients.PatientID INNER JOIN Bills ON ImageDiskRequests.BillID = Bills.BillID INNER JOIN Employees ON Bills.BillingProviderID = Employees.EmpID WHERE (DATEDIFF(d, ImageDiskRequests.PaymentDate, GETDATE()) = 0) AND (ImageDiskRequests.Recepient <> 'Cash') AND (ISNULL(ImageDiskRequests.CheckNumber, '') <> '') "
        SQL &= " GROUP BY ImageDiskRequests.CheckNumber, Employees.CorporationName, Employees.CheckingAccountNumber "
        SQL &= " ORDER BY CorporationName"

        Reader = gSQLGetDataReader(SQL)

        FpSpreadChecks.ActiveSheet.Rows.Count = 0
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False

            If CorporationName <> Reader("CorporationName").ToString.Trim Then
                CorporationName = Reader("CorporationName").ToString.Trim
                If ST > 0 Then
                    C = C + 1
                    FpSpreadChecks.ActiveSheet.Rows.Count = C
                    FpSpreadChecks.ActiveSheet.Cells(FpSpreadChecks.ActiveSheet.Rows.Count - 1, 2).Text = "Sub Total: "
                    FpSpreadChecks.ActiveSheet.Cells(FpSpreadChecks.ActiveSheet.Rows.Count - 1, 3).Text = ST.ToString("c")
                    FpSpreadChecks.ActiveSheet.Rows(FpSpreadChecks.ActiveSheet.Rows.Count - 1).BackColor = Color.LightGray
                End If
                ST = 0
                C = C + 2
                FpSpreadChecks.ActiveSheet.Rows.Count = C
                FpSpreadChecks.ActiveSheet.Cells(C - 1, 2).Text = Reader("CorporationName").ToString
                FpSpreadChecks.ActiveSheet.Cells(C - 1, 3).Text = Reader("CheckingAccountNumber").ToString
                C = C + 1
            End If
            C = C + 1
            FpSpreadChecks.ActiveSheet.Rows.Count = C

            FpSpreadChecks.ActiveSheet.Cells(C - 1, 0).Text = C
            FpSpreadChecks.ActiveSheet.Cells(C - 1, 1).Text = ""
            FpSpreadChecks.ActiveSheet.Cells(C - 1, 2).Text = Reader("CheckNumber").ToString
            FpSpreadChecks.ActiveSheet.Cells(C - 1, 3).Text = CDbl(Reader("Amount").ToString).ToString("c")
            FpSpreadChecks.ActiveSheet.Cells(C - 1, 4).Text = ""
            T += Val(Reader("Amount").ToString)
            ST += Val(Reader("Amount").ToString)
        Loop
        If ST > 0 Then
            C = C + 1
            FpSpreadChecks.ActiveSheet.Rows.Count = C
            FpSpreadChecks.ActiveSheet.Cells(FpSpreadChecks.ActiveSheet.Rows.Count - 1, 2).Text = "Sub Total: "
            FpSpreadChecks.ActiveSheet.Cells(FpSpreadChecks.ActiveSheet.Rows.Count - 1, 3).Text = ST.ToString("c")
            FpSpreadChecks.ActiveSheet.Rows(FpSpreadChecks.ActiveSheet.Rows.Count - 1).BackColor = Color.LightGray
        End If

        If FpSpreadChecks.ActiveSheet.Rows.Count > 0 Then
            FpSpreadChecks.ActiveSheet.Rows.Count += 2
            FpSpreadChecks.ActiveSheet.Cells(FpSpreadChecks.ActiveSheet.Rows.Count - 1, 2).Text = "Grand Total: "
            FpSpreadChecks.ActiveSheet.Cells(FpSpreadChecks.ActiveSheet.Rows.Count - 1, 3).Text = T.ToString("c")
            FpSpreadChecks.ActiveSheet.Rows(FpSpreadChecks.ActiveSheet.Rows.Count - 1).BackColor = Color.LightGray
            FpSpreadChecks.ActiveSheet.Rows(FpSpreadChecks.ActiveSheet.Rows.Count - 1).Font = New Font(FpSpreadChecks.Font, FontStyle.Bold)
        End If
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        gHighlightListviewItem(ListView1, False, False)
        pdfViewer.CloseDocument()
        pdfViewer.Tag = ""
        Load_Payments()

    End Sub

    Private Sub FpSpreadChecks_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadChecks.CellClick
        Dim Reader As SqlClient.SqlDataReader
        Dim ChkNumber As String
        Dim SQL As String
        Dim NoImage As Boolean
        pdfViewer.CloseDocument()
        pdfViewer.Tag = ""
        If e.Row < 0 Then
            Exit Sub
        End If
        If e.Row >= FpSpreadChecks.ActiveSheet.Rows.Count - 2 Then
            Exit Sub
        End If
        ChkNumber = FpSpreadChecks.ActiveSheet.Cells(e.Row, 2).Text
        SQL = "SELECT     DocumentImage FROM Documents WHERE DocumentName = '" & ChkNumber.ToSafeSQLString() & "'"
        lblNotFound.Text = "Loading. Please wait..."
        lblNotFound.Visible = True
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then
            NoImage = True
            GoTo ExitSub
        End If
        If Reader.HasRows = False Then
            NoImage = True
            GoTo ExitSub
        End If
        Reader.Read()
        Dim arrayImage() As Byte = CType(Reader("DocumentImage"), Byte())
        Dim FName As String = gSQLWriteFileFromArray(arrayImage, "PDF", ChkNumber)
        If System.IO.File.Exists(FName) Then
            pdfViewer.LoadDocument(FName)
            pdfViewer.Tag = FName
        End If

ExitSub:
        Cursor = Cursors.Default
        If NoImage = True Then
            lblNotFound.Text = "No Check Image Found."
            lblNotFound.Visible = True
        Else
            lblNotFound.Visible = False
        End If

    End Sub

    Private Sub ToolStripButtonSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSaveAs.Click
        Dim Fname As String
        Dim ChkNumber As String
        Dim BillNumber As String
        If FpSpreadChecks.ActiveSheet.ActiveRowIndex < 0 Or pdfViewer.Tag = "" Then
            Exit Sub
        End If
        If lblNotFound.Visible = True Then
            MsgBox("Unable to save file. No Check image loaded.")
            Exit Sub
        End If
        If System.IO.File.Exists(pdfViewer.Tag) = False Then
            MsgBox("Unexpected Error. Unable to save file. Please select a document and try again.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        ChkNumber = FpSpreadChecks.ActiveSheet.Cells(FpSpreadChecks.ActiveSheet.ActiveRowIndex, 2).Text
        BillNumber = FpSpreadChecks.ActiveSheet.Cells(FpSpreadChecks.ActiveSheet.ActiveRowIndex, 1).Text

        If pdfViewer.Tag.ToString().Right(3).ToUpper() = "PDF" Then    ' To keep compatible with previous JPG file versions
            SaveFileDialog1.Filter = "Adobe Acrobat File (*.pdf)|*.pdf"
            SaveFileDialog1.DefaultExt = "pdf"
            Fname = "Bill# " & BillNumber & " Check# " & ChkNumber & ".pdf"
        Else
            SaveFileDialog1.Filter = "JPEG FIle (*.jpg)|*.jpg"
            SaveFileDialog1.DefaultExt = "jpg"
            Fname = "Bill# " & BillNumber & " Check# " & ChkNumber & ".jpg"
        End If

        Fname = gFixFileName(Fname)
        SaveFileDialog1.FileName = Fname
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                If pdfViewer.Tag.ToString().Right(3).ToUpper() = "PDF" Then
                    IO.File.Copy(pdfViewer.Tag, SaveFileDialog1.FileName)
                Else
                    Image.FromFile(pdfViewer.Tag).Save(SaveFileDialog1.FileName)
                End If
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
            End Try

            Dim P As New ProcessStartInfo()
            With P
                .FileName = SaveFileDialog1.FileName
                .UseShellExecute = True
            End With
            Process.Start(P)
        End If
    End Sub

    Private Sub ToolStripButtonEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonEmail.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim ChkNumber As String
        Dim BillNumber As String
        If FpSpreadChecks.ActiveSheet.ActiveRowIndex < 0 Or pdfViewer.Tag = "" Then
            Exit Sub
        End If
        If lblNotFound.Visible = True Then
            MsgBox("Unable to process Email. No Check image loaded.")
            Exit Sub
        End If

        If System.IO.File.Exists(pdfViewer.Tag) = False Then
            MsgBox("Unexpected Error. Unable to save file. Please select a document and try again.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        ChkNumber = FpSpreadChecks.ActiveSheet.Cells(FpSpreadChecks.ActiveSheet.ActiveRowIndex, 2).Text
        BillNumber = FpSpreadChecks.ActiveSheet.Cells(FpSpreadChecks.ActiveSheet.ActiveRowIndex, 1).Text

        Subject = "Message From " & gOfficeName & " / Attached: " & "Bill# " & BillNumber & " Check# " & ChkNumber & ".pdf"
        Try
            Msg.SendMail(pdfViewer.Tag.ToString, Subject, Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If FpSpreadChecks.ActiveSheet.ActiveRowIndex < 0 Or pdfViewer.Tag = "" Then
            Exit Sub
        End If
        If lblNotFound.Visible = True Then
            MsgBox("Unable to preview. No Check image loaded.")
            Exit Sub
        End If
        If System.IO.File.Exists(pdfViewer.Tag) = False Then
            MsgBox("Unexpected Error. Unable to save file. Please select a document and try again.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        With frmDocumentPreview
            .TextBoxReading.Visible = False
            .pdfViewer.Visible = True
            .pdfViewer.Dock = DockStyle.Fill
            .pdfViewer.LoadDocument(pdfViewer.Tag.ToString())
            .ShowDialog(Me)
        End With
        frmDocumentPreview.Dispose()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If FpSpreadChecks.ActiveSheet.ActiveRowIndex < 0 Or pdfViewer.Tag = "" Then
            Exit Sub
        End If
        If lblNotFound.Visible = True Then
            MsgBox("Unable to print. No Check image loaded.")
            Exit Sub
        End If
        If System.IO.File.Exists(pdfViewer.Tag) = False Then
            MsgBox("Unexpected Error. Unable to save file. Please select a document and try again.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        pdfViewer.PrintDocument(Me)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        Printinfo.SmartPrintPagesWide = 1
        Printinfo.Preview = False
        Printinfo.Header = "PAYMENTS AS OF " & Now.Date.ToString("MM/dd/yyyy") & vbCrLf & vbCrLf
        Printinfo.BestFitRows = False
        Printinfo.BestFitCols = False
        Printinfo.ShowShadows = False
        Printinfo.JobName = "eMedical Office Billing Management"
        Printinfo.PrintType = FarPoint.Win.Spread.PrintType.All
        Printinfo.ShowColor = True
        Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.ShowBorder = False
        Printinfo.ShowGrid = True
        Printinfo.ShowPrintDialog = True
        Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
        Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.All))
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.BestFitColumnRule(FarPoint.Win.Spread.ResetOption.All))
        Printinfo.UseSmartPrint = True
        Printinfo.UseMax = True
        Printinfo.Printer = gPrinterOtherDocuments
        FpSpreadChecks.ActiveSheet.PrintInfo = Printinfo
        FpSpreadChecks.PrintSheet(FpSpreadChecks.ActiveSheet)
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim NumDays As Integer

        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to produce deposit slip. No data selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If IsDate(ListView1.SelectedItems(0).Tag) = False Then
            MsgBox("Unable to produce deposit slip. Unknows payment date.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        NumDays = DateDiff(DateInterval.Day, CDate(ListView1.SelectedItems(0).Tag), Now)

        frmDepositSlip.Setup_report(NumDays)
        gWindow_Settings(frmDepositSlip, ReadWrite.sRead)
        Application.DoEvents()
        frmDepositSlip.ShowDialog(Me)
        frmDepositSlip.Dispose()
    End Sub

End Class