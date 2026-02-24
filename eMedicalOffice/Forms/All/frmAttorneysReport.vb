Public Class frmAttorneysReport
    Dim Loading As Boolean

    Private Sub frmAttorneysReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Data()
    End Sub

    Private Sub Load_Data()
        cboAttorneysCompanyID.Items.Clear()
        cboAttorneysCompanyID.Items.Add(New ValueDescription(0, "All"))
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("Select CompanyID, CompanyName from Attorneys Where OfficeID=" & gOfficeID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboAttorneysCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()

        cboBillingProvider.Items.Clear()
        cboBillingProvider.Items.Add(New ValueDescription("0", "All"))
        Reader = gSQLGetDataReader("SELECT   CorporationName,  EmpID, Fname+' '+Lname+' '+ Alias as DName From Employees WHERE (BillingPrv = 1) and EmpID in (select EmpID from EmployeeOffice where OfficeID=" & gOfficeID & ")")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboBillingProvider.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("DName").ToString, Reader("CorporationName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboYear.Items.Add("All")
        For i As Integer = Now.Year - 10 To Now.Year
            cboYear.Items.Add(i)
        Next
        Loading = True
        cboAttorneysCompanyID.SelectedIndex = 0
        cboBillingProvider.SelectedIndex = 0
        cboYear.SelectedIndex = 0
        Loading = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim reader As SqlClient.SqlDataReader
        Dim Sql As String = " select Attorneys.CompanyName, Bills.AttorneyCompanyID, "
        Dim NewRow As Integer
        Dim AttorneyCompanyID As Integer
        Dim OfficeTotal As Integer
        Dim GrandTotal As Integer
        If cboAttorneysCompanyID.SelectedIndex = -1 Then cboAttorneysCompanyID.SelectedIndex = 0
        If cboBillingProvider.SelectedIndex = -1 Then cboBillingProvider.SelectedIndex = 0
        If cboYear.SelectedIndex = -1 Then cboYear.SelectedIndex = 0

        Sql &= " (select count(*) from bills b where b.AttorneyCompanyID = Bills.AttorneyCompanyID "
        If cboBillingProvider.SelectedIndex > 0 Then
            Sql &= " AND b.BillingProviderID = " & CType(cboBillingProvider.SelectedItem, ValueDescription).Value & " "
        End If
        If cboYear.SelectedIndex > 0 Then
            Sql &= " AND datepart(yyyy, b.AttorneyDate) = " & Val(cboYear.Text) & " "
        End If
        Sql &= " ) as 'OfficeTotal', "
        Sql &= " datepart(yyyy, bills.AttorneyDate) as 'CaseYear', count(*) as 'YearTotal', "
        Sql &= " (select count(*) from bills b where b.AttorneyCompanyID = Bills.AttorneyCompanyID and datepart(YEAR, b.AttorneyDate)=datepart(yyyy, bills.AttorneyDate) and datepart(MONTH, b.AttorneyDate)=1) as 'Jan', "
        Sql &= " (select count(*) from bills b where b.AttorneyCompanyID = Bills.AttorneyCompanyID and datepart(YEAR, b.AttorneyDate)=datepart(yyyy, bills.AttorneyDate) and datepart(MONTH, b.AttorneyDate)=2) as 'Feb', "
        Sql &= " (select count(*) from bills b where b.AttorneyCompanyID = Bills.AttorneyCompanyID and datepart(YEAR, b.AttorneyDate)=datepart(yyyy, bills.AttorneyDate) and datepart(MONTH, b.AttorneyDate)=3) as 'Mar', "
        Sql &= " (select count(*) from bills b where b.AttorneyCompanyID = Bills.AttorneyCompanyID and datepart(YEAR, b.AttorneyDate)=datepart(yyyy, bills.AttorneyDate) and datepart(MONTH, b.AttorneyDate)=4) as 'Apr', "
        Sql &= " (select count(*) from bills b where b.AttorneyCompanyID = Bills.AttorneyCompanyID and datepart(YEAR, b.AttorneyDate)=datepart(yyyy, bills.AttorneyDate) and datepart(MONTH, b.AttorneyDate)=5) as 'May', "
        Sql &= " (select count(*) from bills b where b.AttorneyCompanyID = Bills.AttorneyCompanyID and datepart(YEAR, b.AttorneyDate)=datepart(yyyy, bills.AttorneyDate) and datepart(MONTH, b.AttorneyDate)=6) as 'Jun', "
        Sql &= " (select count(*) from bills b where b.AttorneyCompanyID = Bills.AttorneyCompanyID and datepart(YEAR, b.AttorneyDate)=datepart(yyyy, bills.AttorneyDate) and datepart(MONTH, b.AttorneyDate)=7) as 'Jul', "
        Sql &= " (select count(*) from bills b where b.AttorneyCompanyID = Bills.AttorneyCompanyID and datepart(YEAR, b.AttorneyDate)=datepart(yyyy, bills.AttorneyDate) and datepart(MONTH, b.AttorneyDate)=8) as 'Aug', "
        Sql &= " (select count(*) from bills b where b.AttorneyCompanyID = Bills.AttorneyCompanyID and datepart(YEAR, b.AttorneyDate)=datepart(yyyy, bills.AttorneyDate) and datepart(MONTH, b.AttorneyDate)=9) as 'Sep', "
        Sql &= " (select count(*) from bills b where b.AttorneyCompanyID = Bills.AttorneyCompanyID and datepart(YEAR, b.AttorneyDate)=datepart(yyyy, bills.AttorneyDate) and datepart(MONTH, b.AttorneyDate)=10) as 'Oct', "
        Sql &= " (select count(*) from bills b where b.AttorneyCompanyID = Bills.AttorneyCompanyID and datepart(YEAR, b.AttorneyDate)=datepart(yyyy, bills.AttorneyDate) and datepart(MONTH, b.AttorneyDate)=11) as 'Nov', "
        Sql &= " (select count(*) from bills b where b.AttorneyCompanyID = Bills.AttorneyCompanyID and datepart(YEAR, b.AttorneyDate)=datepart(yyyy, bills.AttorneyDate) and datepart(MONTH, b.AttorneyDate)=12) as 'Dec' "
        Sql &= " from Attorneys left outer join Bills on Attorneys.CompanyID = Bills.AttorneyCompanyID "
        Sql &= " where AttorneyDate is not null  "
        Sql &= " and bills.OfficeID = " & gOfficeID

        If cboAttorneysCompanyID.SelectedIndex > 0 Then
            Sql &= " and (Bills.AttorneyCompanyID = " & CType(cboAttorneysCompanyID.SelectedItem, ValueDescription).Value & " )"
        End If
        If cboBillingProvider.SelectedIndex > 0 Then
            Sql &= " AND Bills.BillingProviderID = " & CType(cboBillingProvider.SelectedItem, ValueDescription).Value & " "
        End If
        If cboYear.SelectedIndex > 0 Then
            Sql &= " AND datepart(yyyy, bills.AttorneyDate) = " & Val(cboYear.Text) & " "
        End If

        Sql &= " group by Attorneys.CompanyName, Bills.AttorneyCompanyID, datepart(YEAR, bills.AttorneyDate) "
        Sql &= " order by Attorneys.CompanyName,datepart(YEAR, bills.AttorneyDate) "
        reader = gSQLGetDataReader(Sql)
        FpSpreadReport.ActiveSheet.RowCount = 0
        If reader Is Nothing Then Exit Sub
        Dim M1 As Decimal
        Dim M2 As Decimal
        Dim M3 As Decimal
        Dim M4 As Decimal
        Dim M5 As Decimal
        Dim M6 As Decimal
        Dim M7 As Decimal
        Dim M8 As Decimal
        Dim M9 As Decimal
        Dim M10 As Decimal
        Dim M11 As Decimal
        Dim M12 As Decimal
        Dim MO1 As Decimal
        Dim MO2 As Decimal
        Dim MO3 As Decimal
        Dim MO4 As Decimal
        Dim MO5 As Decimal
        Dim MO6 As Decimal
        Dim MO7 As Decimal
        Dim MO8 As Decimal
        Dim MO9 As Decimal
        Dim MO10 As Decimal
        Dim MO11 As Decimal
        Dim MO12 As Decimal


        Do Until reader.Read = False
            NewRow = FpSpreadReport.ActiveSheet.RowCount
            FpSpreadReport.ActiveSheet.RowCount = FpSpreadReport.ActiveSheet.RowCount + 1
            If NewRow > 0 And AttorneyCompanyID <> Val(reader("AttorneyCompanyID").ToString()) And cboYear.SelectedIndex = 0 Then
                FpSpreadReport.ActiveSheet.SetText(NewRow, 0, "Office Total")
                FpSpreadReport.ActiveSheet.SetText(NewRow, 2, OfficeTotal)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 3, MO1)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 4, MO2)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 5, MO3)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 6, MO4)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 7, MO5)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 8, MO6)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 9, MO7)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 10, MO8)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 11, MO9)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 12, MO10)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 13, MO11)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 14, MO12)

                FpSpreadReport.ActiveSheet.Rows(NewRow).Font = New Font(FpSpreadReport.Font, FontStyle.Bold)
                FpSpreadReport.ActiveSheet.Rows(NewRow).BackColor = Color.FromArgb(229, 229, 229)
                FpSpreadReport.ActiveSheet.Cells(NewRow, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                NewRow = FpSpreadReport.ActiveSheet.RowCount
                FpSpreadReport.ActiveSheet.RowCount = FpSpreadReport.ActiveSheet.RowCount + 1
                MO1 = 0
                MO2 = 0
                MO3 = 0
                MO4 = 0
                MO5 = 0
                MO6 = 0
                MO7 = 0
                MO8 = 0
                MO9 = 0
                MO10 = 0
                MO11 = 0
                MO12 = 0

            End If
            FpSpreadReport.ActiveSheet.SetText(NewRow, 0, reader("CompanyName").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 1, reader("CaseYear").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 2, reader("YearTotal").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 3, reader("Jan").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 4, reader("Feb").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 5, reader("Mar").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 6, reader("Apr").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 7, reader("May").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 8, reader("Jun").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 9, reader("Jul").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 10, reader("Aug").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 11, reader("Sep").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 12, reader("Oct").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 13, reader("Nov").ToString())
            FpSpreadReport.ActiveSheet.SetText(NewRow, 14, reader("Dec").ToString())
            MO1 = MO1 + Val(reader("Jan").ToString())
            MO2 = MO2 + Val(reader("Feb").ToString())
            MO3 = MO3 + Val(reader("Mar").ToString())
            MO4 = MO4 + Val(reader("Apr").ToString())
            MO5 = MO5 + Val(reader("May").ToString())
            MO6 = MO6 + Val(reader("Jun").ToString())
            MO7 = MO7 + Val(reader("Jul").ToString())
            MO8 = MO8 + Val(reader("Aug").ToString())
            MO9 = MO9 + Val(reader("Sep").ToString())
            MO10 = MO10 + Val(reader("Oct").ToString())
            MO11 = MO11 + Val(reader("Nov").ToString())
            MO12 = MO12 + Val(reader("Dec").ToString())

            M1 = M1 + Val(reader("Jan").ToString())
            M2 = M2 + Val(reader("Feb").ToString())
            M3 = M3 + Val(reader("Mar").ToString())
            M4 = M4 + Val(reader("Apr").ToString())
            M5 = M5 + Val(reader("May").ToString())
            M6 = M6 + Val(reader("Jun").ToString())
            M7 = M7 + Val(reader("Jul").ToString())
            M8 = M8 + Val(reader("Aug").ToString())
            M9 = M9 + Val(reader("Sep").ToString())
            M10 = M10 + Val(reader("Oct").ToString())
            M11 = M11 + Val(reader("Nov").ToString())
            M12 = M12 + Val(reader("Dec").ToString())


            OfficeTotal = Val(reader("OfficeTotal").ToString())
            GrandTotal += reader("YearTotal").ToString()
            AttorneyCompanyID = Val(reader("AttorneyCompanyID").ToString())
        Loop
        NewRow = FpSpreadReport.ActiveSheet.RowCount
        If NewRow > 0 Then
            If cboYear.SelectedIndex = 0 Then
                FpSpreadReport.ActiveSheet.RowCount = FpSpreadReport.ActiveSheet.RowCount + 1
                FpSpreadReport.ActiveSheet.SetText(NewRow, 0, "Office Total")
                FpSpreadReport.ActiveSheet.SetText(NewRow, 2, OfficeTotal)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 3, MO1)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 4, MO2)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 5, MO3)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 6, MO4)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 7, MO5)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 8, MO6)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 9, MO7)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 10, MO8)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 11, MO9)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 12, MO10)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 13, MO11)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 14, MO12)

                FpSpreadReport.ActiveSheet.Rows(NewRow).BackColor = Color.FromArgb(229, 229, 229)
                FpSpreadReport.ActiveSheet.Rows(NewRow).Font = New Font(FpSpreadReport.Font, FontStyle.Bold)
                FpSpreadReport.ActiveSheet.Cells(NewRow, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                NewRow += 1
            End If
            '''''''''''''''
            If cboAttorneysCompanyID.SelectedIndex = 0 Then
                FpSpreadReport.ActiveSheet.RowCount = FpSpreadReport.ActiveSheet.RowCount + 1
                FpSpreadReport.ActiveSheet.SetText(NewRow, 0, "Grand Total")
                FpSpreadReport.ActiveSheet.SetText(NewRow, 2, GrandTotal)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 3, M1)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 4, M2)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 5, M3)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 6, M4)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 7, M5)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 8, M6)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 9, M7)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 10, M8)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 11, M9)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 12, M10)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 13, M11)
                FpSpreadReport.ActiveSheet.SetText(NewRow, 14, M12)
                FpSpreadReport.ActiveSheet.Rows(NewRow).BackColor = Color.FromArgb(210, 210, 210)
                FpSpreadReport.ActiveSheet.Rows(NewRow).ForeColor = Color.Black
                FpSpreadReport.ActiveSheet.Rows(NewRow).Font = New Font(FpSpreadReport.Font, FontStyle.Bold)
                FpSpreadReport.ActiveSheet.Cells(NewRow, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            End If
        End If
        'FpSpreadReport.ActiveSheet.SetColumnMerge(0, FarPoint.Win.Spread.Model.MergePolicy.Always)
    End Sub

    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
        Dim FileName As String
        Dim CT As New FarPoint.Win.Spread.CellType.TextCellType
        FpSpreadReport.Focus()
        Application.DoEvents()
        SaveFileDialog1.Filter = "MS Excel File|*.xls"
        SaveFileDialog1.FileName = "Arbitration Cases Summary Report.xls"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            FpSpreadReport.ActiveSheet.Protect = False
            FileName = SaveFileDialog1.FileName
            FpSpreadReport.ActiveSheet.Rows.Add(0, 1)
            For c As Integer = 0 To 14
                FpSpreadReport.ActiveSheet.Columns(c).Locked = False
                FpSpreadReport.ActiveSheet.Cells(0, c).CellType = CT
                FpSpreadReport.ActiveSheet.Cells(0, c).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                FpSpreadReport.ActiveSheet.Columns(c).Resizable = True
            Next
            FpSpreadReport.ActiveSheet.SetText(0, 0, "Attorney")
            FpSpreadReport.ActiveSheet.Cells(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            FpSpreadReport.ActiveSheet.SetText(0, 1, "Year")
            FpSpreadReport.ActiveSheet.SetText(0, 2, "Year Total")
            FpSpreadReport.ActiveSheet.SetText(0, 3, "Jan")
            FpSpreadReport.ActiveSheet.SetText(0, 4, "Feb")
            FpSpreadReport.ActiveSheet.SetText(0, 5, "Mar")
            FpSpreadReport.ActiveSheet.SetText(0, 6, "Apr")
            FpSpreadReport.ActiveSheet.SetText(0, 7, "May")
            FpSpreadReport.ActiveSheet.SetText(0, 8, "Jun")
            FpSpreadReport.ActiveSheet.SetText(0, 9, "Jul")
            FpSpreadReport.ActiveSheet.SetText(0, 10, "Aug")
            FpSpreadReport.ActiveSheet.SetText(0, 11, "Sep")
            FpSpreadReport.ActiveSheet.SetText(0, 12, "Oct")
            FpSpreadReport.ActiveSheet.SetText(0, 13, "Nov")
            FpSpreadReport.ActiveSheet.SetText(0, 14, "Dec")
            FpSpreadReport.ActiveSheet.Rows(0).BackColor = Color.LightGray
            FpSpreadReport.ActiveSheet.Rows(0).Font = New Font(FpSpreadReport.Font, FontStyle.Bold)

            FpSpreadReport.ActiveSheet.Rows.Add(0, 1)
            If cboBillingProvider.SelectedIndex = 0 Then
                FpSpreadReport.ActiveSheet.SetText(0, 0, "ARBITRATION CASES REPORT. FACILITY: " & gOfficeName.ToUpper)
            Else

                FpSpreadReport.ActiveSheet.SetText(0, 0, "ARBITRATION CASES REPORT. FACILITY: " & gOfficeName.ToUpper & ": PROVIDER: " & CType(cboBillingProvider.SelectedItem, ValueDescription).Value1.ToUpper())
            End If
            FpSpreadReport.ActiveSheet.AddSpanCell(0, 0, 1, 15)
            FpSpreadReport.ActiveSheet.Rows(0).Font = New Font(FpSpreadReport.Font.FontFamily, 12, FontStyle.Bold)
            FpSpreadReport.ActiveSheet.Rows(0).Height = FpSpreadReport.ActiveSheet.Rows(0).GetPreferredHeight() + 20

            FpSpreadReport.SaveExcel(FileName)
                For c As Integer = 0 To 14
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
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        cboAttorneysCompanyID.SelectedIndex = 0
        cboBillingProvider.SelectedIndex = 0
        cboYear.SelectedIndex = 0
        cboAttorneysCompanyID.Focus()
    End Sub

    Private Sub cboYear_DropDown(sender As Object, e As EventArgs) Handles cboYear.DropDown
        If cboYear.SelectedIndex = 0 Then
            cboYear.Text = Now.Year()
        End If
    End Sub

End Class