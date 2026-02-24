Public Class frmDiagSchedule

    Private Sub frmDiagSchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim R As Integer = 0
        SQL = "SELECT     DiagID, DiagName, Day1, Day2, Day3, Day4, Day5, Day6, Day7 FROM Diagnostics WHERE     ActiveInd = 1 AND OfficeID = " & gOfficeID & " order by DiagName "
        Reader = gSQLGetDataReader(SQL)
        FpSpread1.ActiveSheet.RowCount = R
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                R = R + 1
                FpSpread1.ActiveSheet.RowCount = R
                FpSpread1.ActiveSheet.Cells(R - 1, 0).Text = Reader("DiagName").ToString.ToUpper
                FpSpread1.ActiveSheet.Cells(R - 1, 0).Font = New Font(FpSpread1.Font, FontStyle.Bold)
                FpSpread1.ActiveSheet.Cells(R - 1, 1).Value = Val(Reader("Day1").ToString)
                FpSpread1.ActiveSheet.Cells(R - 1, 2).Value = Val(Reader("Day2").ToString)
                FpSpread1.ActiveSheet.Cells(R - 1, 3).Value = Val(Reader("Day3").ToString)
                FpSpread1.ActiveSheet.Cells(R - 1, 4).Value = Val(Reader("Day4").ToString)
                FpSpread1.ActiveSheet.Cells(R - 1, 5).Value = Val(Reader("Day5").ToString)
                FpSpread1.ActiveSheet.Cells(R - 1, 6).Value = Val(Reader("Day6").ToString)
                FpSpread1.ActiveSheet.Cells(R - 1, 7).Value = Val(Reader("Day7").ToString)
            Loop
        End If
        FpSpread1.ActiveSheet.Columns(1).BackColor = Color.PeachPuff
        FpSpread1.ActiveSheet.Columns(7).BackColor = Color.PeachPuff

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        Printinfo.SmartPrintPagesWide = 1
        Printinfo.Header = "eMEDICAL OFFICE PROCEDURES SCHEDULE" & vbCrLf & vbCrLf
        Printinfo.ShowShadows = True
        Printinfo.JobName = "eMedical Office"
        Printinfo.ShowColor = True
        Printinfo.ShowBorder = False
        Printinfo.ShowGrid = True
        Printinfo.ShowPrintDialog = True
        Printinfo.Preview = False
        Printinfo.Printer = gPrinterOtherDocuments
        FpSpread1.ActiveSheet.PrintInfo = Printinfo
        FpSpread1.PrintSheet(FpSpread1.ActiveSheet)
    End Sub
End Class