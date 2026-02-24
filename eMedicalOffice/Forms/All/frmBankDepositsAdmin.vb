Public Class frmBankDepositsAdmin
    Dim Loading As Boolean

    Private Sub frmBankDepositsAdmin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub


    Private Sub frmBankDepositsAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loading = True
        Dim H As ToolStripControlHost
        Me.DoubleBuffered = True
        gWindow_Settings(Me, ReadWrite.sRead)
        H = New ToolStripControlHost(DateTimePicker1)
        ToolStrip1.Items.Insert(3, H)
        H = New ToolStripControlHost(DateTimePicker2)
        ToolStrip1.Items.Insert(5, H)
        DateTimePicker1.Value = GetFirstWeekDateDates(Now.Date) & " " & Now.TimeOfDay.ToString
        DateTimePicker1.MaxDate = Today
        DateTimePicker2.Value = Now
        DateTimePicker2.Value = Today
        Loading = False
        Load_Data()

    End Sub
    Private Paid As Decimal = 0
    Private Checks As Integer = 0
    Private Sub SetFont(Optional incr As Integer = 0)
        Dim BaseSize = 8
        If BaseSize + My.Settings.FontSize + incr < 8 Or BaseSize + My.Settings.FontSize + incr > 15 Then Return
        My.Settings.FontSize = My.Settings.FontSize + incr
        My.Settings.Save()
        Dim F = New Font(Font.FontFamily, BaseSize + My.Settings.FontSize, FontStyle.Regular)
        FpSpreadDeposits.Font = F
    End Sub
    Private Sub Load_Data()
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Paid = 0
        Checks = 0
        If Loading Then Exit Sub
        SQL = "SELECT convert(varchar,PaymentDate,111) as DT, SUM(PaymentAmount) AS Amt, COUNT(PaymentID) as C FROM BillPayments Where 1=1 "
        If DateTimePicker1.Checked Then
            SQL = SQL & " AND DateDiff(dd, PaymentDate, '" & DateTimePicker1.Value.Date & "') <= 0 "
        End If
        If DateTimePicker2.Checked Then
            SQL = SQL & " AND DateDiff(dd, PaymentDate, '" & DateTimePicker2.Value.Date & "') >= 0 "
        End If
        SQL = SQL & " group by convert(varchar,PaymentDate,111) "
        SQL = SQL & " order by convert(varchar,PaymentDate,111) desc "
        Reader = gSQLGetDataReader(SQL)
        With FpSpreadDeposits.ActiveSheet
            .RowCount = 0
            Do Until Reader.Read = False
                .RowCount = .RowCount + 1
                Paid = Paid + Val(Reader("Amt").ToString)
                Checks = Checks + Val(Reader("C").ToString)

                .SetText(.RowCount - 1, 0, .RowCount)
                .SetText(.RowCount - 1, 1, Reader("DT").ToString)
                .SetText(.RowCount - 1, 2, Val(Reader("C").ToString))
                .SetText(.RowCount - 1, 3, CDec(Val(Reader("Amt")).ToString("c")))
            Loop
        End With
        lblDepositsaFound.Text = FpSpreadDeposits.ActiveSheet.RowCount
        lblCheckFound.Text = Checks
        lblTotalAmount.Text = Paid.ToString("c")
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Load_Data()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Load_Data()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        Load_Data()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Application.DoEvents()
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        FpSpreadDeposits.ActiveSheet.RowCount = FpSpreadDeposits.ActiveSheet.RowCount + 1
        FpSpreadDeposits.ActiveSheet.SetText(FpSpreadDeposits.ActiveSheet.RowCount - 1, 0, FpSpreadDeposits.ActiveSheet.RowCount - 1)
        FpSpreadDeposits.ActiveSheet.SetText(FpSpreadDeposits.ActiveSheet.RowCount - 1, 1, "Totals:")
        FpSpreadDeposits.ActiveSheet.SetText(FpSpreadDeposits.ActiveSheet.RowCount - 1, 2, Checks)
        FpSpreadDeposits.ActiveSheet.SetText(FpSpreadDeposits.ActiveSheet.RowCount - 1, 3, Paid.ToString("c"))
        FpSpreadDeposits.ActiveSheet.Rows(FpSpreadDeposits.ActiveSheet.RowCount - 1).BackColor = Color.LightGray
        FpSpreadDeposits.ActiveSheet.Rows(FpSpreadDeposits.ActiveSheet.RowCount - 1).Font = New Font(FpSpreadDeposits.Font, FontStyle.Bold)

        Printinfo.SmartPrintPagesWide = 1
        Printinfo.Header = "BANK DEPOSITS " & IIf(DateTimePicker1.Checked, " FROM:" & DateTimePicker1.Text.ToUpper, "") & IIf(DateTimePicker2.Checked, " TO:" & DateTimePicker2.Text.ToUpper, "") & vbCrLf
        Printinfo.BestFitRows = True
        Printinfo.BestFitCols = False
        Printinfo.Preview = True
        Printinfo.ShowShadows = False
        Printinfo.JobName = "eMedical Office Schedule"
        Printinfo.PrintType = FarPoint.Win.Spread.PrintType.All
        Printinfo.ShowColor = True
        Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.ShowBorder = False
        Printinfo.ShowGrid = True
        Printinfo.ShowPrintDialog = True
        Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.None))
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.BestFitColumnRule(FarPoint.Win.Spread.ResetOption.None))
        Printinfo.UseSmartPrint = False
        Printinfo.UseMax = False

        FpSpreadDeposits.ActiveSheet.PrintInfo = Printinfo
        FpSpreadDeposits.PrintSheet(FpSpreadDeposits.ActiveSheet)
        Cursor = Cursors.Default
        FpSpreadDeposits.ActiveSheet.RowCount = FpSpreadDeposits.ActiveSheet.RowCount - 1
    End Sub

    Private Sub ExportAllToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportAllToExcelToolStripMenuItem.Click
        Dim FileName
        SaveFileDialog1.Filter = "MS Excel File|*.xls"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            FileName = SaveFileDialog1.FileName
            FpSpreadDeposits.ActiveSheet.Columns(0).Locked = False
            FpSpreadDeposits.ActiveSheet.Columns(1).Locked = False
            FpSpreadDeposits.ActiveSheet.Columns(2).Locked = False
            FpSpreadDeposits.ActiveSheet.Columns(3).Locked = False
            FpSpreadDeposits.ActiveSheet.Rows.Add(0, 1)
            FpSpreadDeposits.ActiveSheet.SetText(0, 0, "##")
            FpSpreadDeposits.ActiveSheet.SetText(0, 1, "Deposit DT")
            FpSpreadDeposits.ActiveSheet.SetText(0, 2, "Checks ##")
            FpSpreadDeposits.ActiveSheet.SetText(0, 3, "Amount")
            FpSpreadDeposits.ActiveSheet.Rows(0).BackColor = Color.LightGray
            FpSpreadDeposits.ActiveSheet.Rows(0).Font = New Font(FpSpreadDeposits.Font, FontStyle.Bold)
            FpSpreadDeposits.ActiveSheet.RowCount = FpSpreadDeposits.ActiveSheet.RowCount + 1
            FpSpreadDeposits.ActiveSheet.SetText(FpSpreadDeposits.ActiveSheet.RowCount - 1, 0, FpSpreadDeposits.ActiveSheet.RowCount - 2)
            FpSpreadDeposits.ActiveSheet.SetText(FpSpreadDeposits.ActiveSheet.RowCount - 1, 1, "Totals:")
            FpSpreadDeposits.ActiveSheet.SetText(FpSpreadDeposits.ActiveSheet.RowCount - 1, 2, Checks)
            FpSpreadDeposits.ActiveSheet.SetText(FpSpreadDeposits.ActiveSheet.RowCount - 1, 3, Paid.ToString("c"))
            FpSpreadDeposits.ActiveSheet.Rows(FpSpreadDeposits.ActiveSheet.RowCount - 1).BackColor = Color.LightGray
            FpSpreadDeposits.ActiveSheet.Rows(FpSpreadDeposits.ActiveSheet.RowCount - 1).Font = New Font(FpSpreadDeposits.Font, FontStyle.Bold)
            FpSpreadDeposits.SaveExcel(FileName)
            FpSpreadDeposits.ActiveSheet.Columns(0).Locked = True
            FpSpreadDeposits.ActiveSheet.Columns(1).Locked = True
            FpSpreadDeposits.ActiveSheet.Columns(2).Locked = True
            FpSpreadDeposits.ActiveSheet.Columns(3).Locked = True
            FpSpreadDeposits.ActiveSheet.Rows.Remove(0, 1)
            FpSpreadDeposits.ActiveSheet.RowCount = FpSpreadDeposits.ActiveSheet.RowCount - 1
        End If

    End Sub

    Private Sub ToolStripFontIncrease_Click(sender As Object, e As EventArgs)
        SetFont(1)
    End Sub

    Private Sub ToolStripFonrDecrease_Click(sender As Object, e As EventArgs)
        SetFont(-1)
    End Sub
End Class