Imports System.IO

Public Class frmAgingReport
    Dim Loading As Boolean
    Dim Col2Total As Decimal
    Dim Col3Total As Decimal
    Dim Col4Total As Decimal
    Dim Col5Total As Decimal

    Private Sub frmAgingReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FpSpreadReport.ActiveSheet.RowCount = 0
        Load_Data()
    End Sub
    Private Sub Load_Data()
        If gOffices.Count > 1 Then
            ComboBoxFacility.Items.Add(New ValueDescription(0, "All Facilities"))
            For Each item As Office In gOffices
                ComboBoxFacility.Items.Add(New ValueDescription(item.OfficeID, item.OfficeName))
                CheckBoxGrandTotal.Visible = True
                CheckBoxNewPage.Visible = True
            Next
        Else
            ComboBoxFacility.Items.Add(New ValueDescription(gOfficeID, gOfficeName))
            CheckBoxGrandTotal.Visible = False
            CheckBoxNewPage.Visible = False
        End If
        ComboBoxFacility.SelectedIndex = 0
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        dummy.Focus()
        Dim reader As SqlClient.SqlDataReader
        Dim Sql As String = ""
        Dim NewRow As Integer
        Dim AttorneyCompanyID As Integer
        Dim OfficeTotal As Integer
        Dim GrandTotal As Integer
        FpSpreadReport.ActiveSheet.RowCount = 0
        Dim ReportDate As String = DateTimePicker1.Value.Date
        If ComboBoxFacility.SelectedIndex = -1 Then ComboBoxFacility.SelectedIndex = 0
        Dim OfficeId = CType(ComboBoxFacility.SelectedItem, ValueDescription).Value

        Sql &= " SELECT 0 ordr, InsuranceCompanies.CompanyName, "
        Sql &= "          sum(case when NoMoreCollection=0 and BillStatusID not in (7,8,13) and DATEDIFF(day,  BillDate,'" & ReportDate & "' ) BETWEEN 0 AND 30 then BillAmount-PaidAmount  else 0 end) Col2, "
        Sql &= "          sum(case when NoMoreCollection=0 and BillStatusID not in (7,8,13) and DATEDIFF(day,  BillDate,'" & ReportDate & "' ) BETWEEN 31 AND 60 then BillAmount-PaidAmount  else 0 end) Col3, "
        Sql &= "          sum(case when NoMoreCollection=0 and BillStatusID not in (7,8,13) and DATEDIFF(day,  BillDate,'" & ReportDate & "' ) BETWEEN 61 AND 90 then BillAmount-PaidAmount  else 0 end) Col4, "
        Sql &= " 		 sum(case when NoMoreCollection=0 and BillStatusID not in (7,8,13) and DATEDIFF(day,  BillDate,'" & ReportDate & "' ) BETWEEN 0 AND 90 then BillAmount-PaidAmount  else 0 end) Col5 "
        Sql &= " FROM Bills  "
        Sql &= " inner join InsuranceCompanies on InsCompanyID = InsuranceCompanies.CompanyID "
        Sql &= " inner join Patients on bills.PatientID = Patients.PatientID "
        'Sql &= " WHERE InsuranceCompanies.CaseTypeId in (1,2)  "
        Sql &= " group by InsuranceCompanies.CompanyName "
        Sql &= " having  "
        Sql &= " sum(case when NoMoreCollection=0 and BillStatusID not in (7,8,13) and DATEDIFF(day,  BillDate,'" & ReportDate & "' ) BETWEEN 0 AND 30 then BillAmount-PaidAmount  else 0 end) >0 "
        Sql &= " or sum(case when NoMoreCollection=0 and BillStatusID not in (7,8,13) and DATEDIFF(day,  BillDate,'" & ReportDate & "' ) BETWEEN 31 AND 60 then BillAmount-PaidAmount  else 0 end) >0  "
        Sql &= " or sum(case when NoMoreCollection=0 and BillStatusID not in (7,8,13) and DATEDIFF(day,  BillDate,'" & ReportDate & "' ) BETWEEN 61 AND 90 then BillAmount-PaidAmount  else 0 end) >0 "
        Sql &= " or sum(case when NoMoreCollection=0 and BillStatusID not in (7,8,13) and DATEDIFF(day,  BillDate,'" & ReportDate & "' ) BETWEEN 0 AND 90 then BillAmount-PaidAmount  else 0 end) >0 "
        Sql &= " UNION "
        Sql &= " SELECT 1 ordr, 'FACILITY TOTAL', "
        Sql &= "          sum(case when NoMoreCollection=0 and BillStatusID not in (7,8,13) and DATEDIFF(day,  BillDate,'" & ReportDate & "' ) BETWEEN 0 AND 30 then BillAmount-PaidAmount  else 0 end) [0-30 Days], "
        Sql &= "          sum(case when NoMoreCollection=0 and BillStatusID not in (7,8,13) and DATEDIFF(day,  BillDate,'" & ReportDate & "' ) BETWEEN 31 AND 60 then BillAmount-PaidAmount  else 0 end) [30-60 Days], "
        Sql &= "          sum(case when NoMoreCollection=0 and BillStatusID not in (7,8,13) and DATEDIFF(day,  BillDate,'" & ReportDate & "' ) BETWEEN 61 AND 90 then BillAmount-PaidAmount  else 0 end) [60-90 Days], "
        Sql &= " 		 sum(case when NoMoreCollection=0 and BillStatusID not in (7,8,13) and DATEDIFF(day,  BillDate,'" & ReportDate & "' ) BETWEEN 0 AND 90 then BillAmount-PaidAmount  else 0 end) [90 Days] "
        Sql &= " FROM Bills  "
        Sql &= " inner join InsuranceCompanies on InsCompanyID = InsuranceCompanies.CompanyID "
        Sql &= " inner join Patients on bills.PatientID = Patients.PatientID "

        'Sql &= " WHERE InsuranceCompanies.CaseTypeId in (1,2)  "
        Sql &= " ORDER by ordr, InsuranceCompanies.CompanyName "

        Col2Total = 0
        Col3Total = 0
        Col4Total = 0
        Col5Total = 0
        Dim MultipleOffices As Integer
        If gOffices.Count > 1 Then
            For Each o As Office In gOffices
                If OfficeId > 0 Then
                    If OfficeId <> o.OfficeID Then Continue For
                End If
                reader = gSQLGetDataReader(Sql, o.ConnectionString)
                Load_Spread(o.OfficeName, reader)
                If CheckBoxNewPage.Checked Then FpSpreadReport.Sheets(0).SetRowPageBreak(FpSpreadReport.ActiveSheet.RowCount - 1, True)
                MultipleOffices = MultipleOffices + 1
            Next
        Else
            reader = gSQLGetDataReader(Sql, gConnectionString)
            Load_Spread(gOfficeName, reader)
        End If
        If CheckBoxGrandTotal.Checked And MultipleOffices > 1 Then
            NewRow = FpSpreadReport.ActiveSheet.RowCount
            FpSpreadReport.ActiveSheet.RowCount = FpSpreadReport.ActiveSheet.RowCount + 1
            FpSpreadReport.ActiveSheet.SetText(NewRow, 0, "GRAND TOTAL:")
            FpSpreadReport.ActiveSheet.SetText(NewRow, 1, Col2Total.ToString("c"))
            FpSpreadReport.ActiveSheet.SetText(NewRow, 2, Col3Total.ToString("c"))
            FpSpreadReport.ActiveSheet.SetText(NewRow, 3, Col4Total.ToString("c"))
            FpSpreadReport.ActiveSheet.SetText(NewRow, 4, Col5Total.ToString("c"))
            FpSpreadReport.ActiveSheet.SetText(NewRow, 5, 1)
            FpSpreadReport.ActiveSheet.Rows(NewRow).Font = New Font(FpSpreadReport.Font, FontStyle.Bold)
            FpSpreadReport.ActiveSheet.Rows(NewRow).BackColor = Color.FromArgb(234, 234, 234)
        End If
    End Sub

    Private Sub Load_Spread(officeName As String, reader As SqlClient.SqlDataReader)
        Dim NewRow As Integer
        NewRow = FpSpreadReport.ActiveSheet.RowCount
        FpSpreadReport.ActiveSheet.RowCount = FpSpreadReport.ActiveSheet.RowCount + 1
        FpSpreadReport.ActiveSheet.SetText(NewRow, 0, "FACILITY: " & officeName.ToUpper())
        FpSpreadReport.ActiveSheet.Rows(NewRow).Font = New Font(FpSpreadReport.Font, FontStyle.Bold)
        FpSpreadReport.ActiveSheet.Rows(NewRow).BackColor = Color.FromArgb(234, 234, 234)
        FpSpreadReport.ActiveSheet.SetText(NewRow, 5, 1)
        Do Until reader.Read = False
            If reader("CompanyName").ToString().StartsWith("FACILITY TOTAL") Then
                Col2Total = Col2Total + Val(reader("Col2").ToString())
                Col3Total = Col2Total + Val(reader("Col3").ToString())
                Col4Total = Col2Total + Val(reader("Col4").ToString())
                Col5Total = Col2Total + Val(reader("Col5").ToString())
                If CheckBoxFacilityTotal.Checked = False Then
                    Continue Do
                End If
            End If
            NewRow = FpSpreadReport.ActiveSheet.RowCount
            FpSpreadReport.ActiveSheet.RowCount = FpSpreadReport.ActiveSheet.RowCount + 1
            FpSpreadReport.ActiveSheet.SetText(NewRow, 0, reader("CompanyName").ToString().ToUpper)
            FpSpreadReport.ActiveSheet.SetText(NewRow, 1, Val(reader("Col2").ToString()).ToString("c"))
            FpSpreadReport.ActiveSheet.SetText(NewRow, 2, Val(reader("Col3").ToString()).ToString("c"))
            FpSpreadReport.ActiveSheet.SetText(NewRow, 3, Val(reader("Col4").ToString()).ToString("c"))
            FpSpreadReport.ActiveSheet.SetText(NewRow, 4, Val(reader("Col5").ToString()).ToString("c"))
            FpSpreadReport.ActiveSheet.SetText(NewRow, 5, 0)

            'FpSpreadReport.ActiveSheet.Rows(NewRow).Font = New Font(FpSpreadReport.Font, FontStyle.Bold)
            'FpSpreadReport.ActiveSheet.Rows(NewRow).BackColor = Color.FromArgb(229, 229, 229)
            'FpSpreadReport.ActiveSheet.Cells(NewRow, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Loop
        If CheckBoxFacilityTotal.Checked Then
            FpSpreadReport.ActiveSheet.Rows(NewRow).Font = New Font(FpSpreadReport.Font, FontStyle.Bold)
        End If
        FpSpreadReport.ActiveSheet.RowCount = FpSpreadReport.ActiveSheet.RowCount + 1
        Cursor = Cursors.Default
    End Sub

    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
        dummy.Focus()
        Dim FileName As String
        Dim CT As New FarPoint.Win.Spread.CellType.TextCellType
        If FpSpreadReport.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "No data loaded.", MsgBoxStyle.Exclamation, "Oops...")
            Exit Sub
        End If
        FpSpreadReport.Focus()
        Application.DoEvents()
        SaveFileDialog1.Filter = "MS Excel File|*.xls"
        SaveFileDialog1.FileName = "Aging Report " & DateTimePicker1.Value.ToString("MM-dd-yyyy") & ".xls"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            Application.DoEvents()
            FpSpreadReport.ActiveSheet.Protect = False
            FileName = SaveFileDialog1.FileName
            FpSpreadReport.ActiveSheet.Rows.Add(0, 1)
            For c As Integer = 0 To 4
                FpSpreadReport.ActiveSheet.Columns(c).Locked = False
                FpSpreadReport.ActiveSheet.Cells(0, c).CellType = CT
                FpSpreadReport.ActiveSheet.Cells(0, c).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                FpSpreadReport.ActiveSheet.Columns(c).Resizable = True
            Next
            FpSpreadReport.ActiveSheet.SetText(0, 0, "Insurance")
            FpSpreadReport.ActiveSheet.Cells(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            FpSpreadReport.ActiveSheet.SetText(0, 1, "0-30 Days")
            FpSpreadReport.ActiveSheet.SetText(0, 2, "30-60 Days")
            FpSpreadReport.ActiveSheet.SetText(0, 3, "60-90 Days")
            FpSpreadReport.ActiveSheet.SetText(0, 4, "Total 90 Days")


            For i = 0 To FpSpreadReport.ActiveSheet.Rows.Count - 1
                If Val(FpSpreadReport.ActiveSheet.Cells(i, 5).Text) = 1 Then
                    FpSpreadReport.ActiveSheet.AddSpanCell(i, i, 1, 4)
                    'FpSpreadReport.ActiveSheet.Rows(0).Font = New Font(FpSpreadReport.Font.FontFamily, 12, FontStyle.Bold)
                    'FpSpreadReport.ActiveSheet.Rows(0).Height = FpSpreadReport.ActiveSheet.Rows(0).GetPreferredHeight() + 20
                End If
            Next

            FpSpreadReport.SaveExcel(FileName)
            For c As Integer = 0 To 4
                FpSpreadReport.ActiveSheet.Columns(c).Locked = True
                FpSpreadReport.ActiveSheet.Columns(c).Resizable = False
            Next
            FpSpreadReport.ActiveSheet.Rows.Remove(0, 1)
            FpSpreadReport.ActiveSheet.Rows.Remove(0, 1)
            FpSpreadReport.ActiveSheet.Protect = True
            Try
                Dim officeType As Type = Type.GetTypeFromProgID("Excel.Application")
                If officeType <> Nothing Then
                    If MessageBox.Show(Me, "Export Complete." & vbCrLf & vbCrLf & "Open created excel file?", "Ok...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Process.Start(FileName)
                    End If
                Else
                    MessageBox.Show(Me, "Export Complete.", "Ok...", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
            End Try
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        dummy.Focus()
        Dim FileName As String
        If FpSpreadReport.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "No data loaded.", MsgBoxStyle.Exclamation, "Oops...")
            Exit Sub
        End If

        SaveFileDialog2.Filter = "Adobe Acrobat|*.pdf"
        SaveFileDialog2.FileName = "Aging Report " & DateTimePicker1.Value.ToString("MM-dd-yyyy") & ".pdf"
        If SaveFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
            FileName = SaveFileDialog2.FileName
            Cursor = Cursors.WaitCursor
            Application.DoEvents()
            Try
                Dim HGridLine As New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.LightGray)
                FpSpreadReport.Sheets(0).HorizontalGridLine = HGridLine
                Dim printmar As FarPoint.Win.Spread.PrintMargin = New FarPoint.Win.Spread.PrintMargin()
                printmar.Left = 40
                printmar.Top = 40
                Dim Printinfo As New FarPoint.Win.Spread.PrintInfo()
                Printinfo.Header = "/l AGING REPORT " & DateTimePicker1.Value.ToString("MM-dd-yyyy") & "/r Page /p of /pc" & vbCrLf & vbCrLf
                Printinfo.ShowColor = True
                Printinfo.Margin = printmar
                Printinfo.PdfWriteTo = FarPoint.Win.Spread.PdfWriteTo.File
                Printinfo.PrintToPdf = True
                Printinfo.PdfFileName = FileName
                Printinfo.Centering = FarPoint.Win.Spread.Centering.Horizontal
                Printinfo.ShowGrid = True
                Printinfo.ShowBorder = False
                Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
                Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
                FpSpreadReport.Sheets(0).PrintInfo = Printinfo
                FpSpreadReport.PrintSheet(0)
                Try
                    If MessageBox.Show(Me, "Export Complete." & vbCrLf & vbCrLf & "Open created PDF file?", "Ok...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Process.Start(FileName)
                    End If
                Catch ex As Exception
                End Try
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Oops...")
            End Try

            Cursor = Cursors.Default
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnPrint.Click
        dummy.Focus()
        If FpSpreadReport.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "No data loaded.", MsgBoxStyle.Exclamation, "Oops...")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim HGridLine As New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.LightGray)
        FpSpreadReport.Sheets(0).HorizontalGridLine = HGridLine
        Dim printmar As FarPoint.Win.Spread.PrintMargin = New FarPoint.Win.Spread.PrintMargin()
        printmar.Left = 40
        printmar.Top = 40
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo()
        Printinfo.ShowColor = True
        Printinfo.Header = "/l AGING REPORT " & DateTimePicker1.Value.ToString("MM-dd-yyyy") & "/r Page /p of /pc" & vbCrLf & vbCrLf
        Printinfo.Margin = printmar
        Printinfo.Centering = FarPoint.Win.Spread.Centering.Horizontal
        Printinfo.ShowGrid = True
        Printinfo.ShowBorder = False
        Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
        Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
        Printinfo.Printer = gPrinterNF3
        FpSpreadReport.Sheets(0).PrintInfo = Printinfo

        Printinfo.ShowPrintDialog = True
        FpSpreadReport.PrintSheet(0)
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonEmail_Click(sender As Object, e As EventArgs) Handles ButtonEmail.Click
        dummy.Focus()
        If FpSpreadReport.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & vbCrLf & "No data loaded.", MsgBoxStyle.Exclamation, "Oops...")
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Subject = "Aging Report " & DateTimePicker1.Value.ToString("MM-dd-yyyy")
        Try
            Dim printmar As FarPoint.Win.Spread.PrintMargin = New FarPoint.Win.Spread.PrintMargin()
            Dim FileName As String
            FileName = Path.GetTempFileName
            FileName = Path.ChangeExtension(FileName, "pdf")
            Dim HGridLine As New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.LightGray)
            FpSpreadReport.Sheets(0).HorizontalGridLine = HGridLine
            printmar.Left = 40
            printmar.Top = 40
            Dim Printinfo As New FarPoint.Win.Spread.PrintInfo()
            Printinfo.Header = "/l AGING REPORT " & DateTimePicker1.Value.ToString("MM-dd-yyyy") & "/r Page /p of /pc" & vbCrLf & vbCrLf
            Printinfo.ShowColor = True
            Printinfo.Margin = printmar
            Printinfo.PrintToPdf = True
            Printinfo.PdfFileName = FileName
            Printinfo.Centering = FarPoint.Win.Spread.Centering.Horizontal
            Printinfo.ShowGrid = True
            Printinfo.ShowBorder = False
            Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
            Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
            FpSpreadReport.Sheets(0).PrintInfo = Printinfo
            FpSpreadReport.PrintSheet(0)
            Msg.SendMail(FileName, Subject, "Attached is the Aging Report " & DateTimePicker1.Value.ToString("MM-dd-yyyy") & vbCrLf & vbCrLf & "Thanks." & vbCrLf & "This email has been automatically generated by " & gOfficeName & " office.")
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ComboBoxFacility_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxFacility.SelectedIndexChanged
        If gOffices.Count > 1 Then
            CheckBoxGrandTotal.Visible = ComboBoxFacility.SelectedIndex < 1
            CheckBoxNewPage.Visible = ComboBoxFacility.SelectedIndex < 1
        Else
            CheckBoxGrandTotal.Visible = False
            CheckBoxNewPage.Visible = False
        End If
    End Sub
End Class