Imports System.Data.SqlClient
Imports System.IO

Public Class frmCariskPayersMaintenanceImport
    Public tbl As DataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Try
            cmdClose.Enabled = False
            cmdUpdate.Enabled = False
            picArrow.Visible = False
            btnImport.Enabled = False
            Dim i As Integer
            OpenFileDialog1.FileName = "Carisk-Payers.xlsx"
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                lblWait.Text = "Loading file data. Please wait..."
                lblWait.Refresh()
                ListView1.Items.Clear()
                tbl = DatatableFromXLSX(OpenFileDialog1.FileName, True)
                If tbl.Columns.Count <> 9 Then
                    MsgBox("Invalid file format." & vbCrLf & "Expected Carisk-Payers.xlsx file with the following columns:" & vbCrLf & vbCrLf & "[Payer Name]" & vbCrLf & "[PayerId]" & vbCrLf & "[States]" & vbCrLf & "[Professional]" & vbCrLf & "[Institutional]" & vbCrLf & "[PharmacyRx]" & vbCrLf & "[WorkComp]" & vbCrLf & "[Automotive]" & vbCrLf & "[835/EOB]" & vbCrLf & vbCrLf & "Please check the file format and try again.", MsgBoxStyle.Critical, "e-File...")
                    lblWait.Text = "e-File"
                    cmdClose.Enabled = True
                    cmdUpdate.Enabled = True
                    btnImport.Enabled = True
                    Return
                End If
                If tbl.Columns(0).ColumnName <> "Payer Name" And
                    tbl.Columns(1).ColumnName <> "PayerId" And
                    tbl.Columns(2).ColumnName <> "States" And
                    tbl.Columns(3).ColumnName <> "Professional" And
                    tbl.Columns(4).ColumnName <> "Institutional" And
                    tbl.Columns(5).ColumnName <> "PharmacyRx" And
                    tbl.Columns(6).ColumnName <> "WorkComp" And
                    tbl.Columns(7).ColumnName <> "Automotive" And
                    tbl.Columns(8).ColumnName <> "835/EOB" Then
                    MsgBox("Invalid file format." & vbCrLf & "Expected Carisk-Payers.xlsx file with the following columns:" & vbCrLf & vbCrLf & "[Payer Name]" & vbCrLf & "[PayerId]" & vbCrLf & "[States]" & vbCrLf & "[Professional]" & vbCrLf & "[Institutional]" & vbCrLf & "[PharmacyRx]" & vbCrLf & "[WorkComp]" & vbCrLf & "[Automotive]" & vbCrLf & "[835/EOB]" & vbCrLf & vbCrLf & "Please check the file format and try again.", MsgBoxStyle.Critical, "e-File...")
                    lblWait.Text = "e-File"
                    cmdClose.Enabled = True
                    cmdUpdate.Enabled = True
                    btnImport.Enabled = True
                    Return
                End If
                ProgressBar1.Maximum = tbl.Rows.Count
                ListView1.BeginUpdate()
                For Each row As DataRow In tbl.Rows
                    i = i + 1
                    ProgressBar1.Value = i
                    ProgressBar1.Value = i - 1
                    ProgressBar1.Value = i
                    ProgressBar1.Refresh()
                    Dim lvi As ListViewItem = ListView1.Items.Add(row(0))
                    lvi.SubItems.Add(row(1).ToString())
                    lvi.SubItems.Add(row(2).ToString())
                    lvi.SubItems.Add(row(3).ToString())
                    lvi.SubItems.Add(row(4).ToString())
                    lvi.SubItems.Add(row(5).ToString())
                    lvi.SubItems.Add(row(6).ToString())
                    lvi.SubItems.Add(row(7).ToString())
                    lvi.SubItems.Add(row(8).ToString())
                Next
                ListView1.EndUpdate()
                lblWait.Text = tbl.Rows.Count & " rows imported"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "e-File...")
        End Try
        picArrow.Visible = True
        cmdClose.Enabled = True
        cmdUpdate.Enabled = True
        btnImport.Enabled = True
    End Sub
    Private Function DatatableFromXLSX(ByVal path As String, ByVal Optional hasHeader As Boolean = True) As DataTable
        Using pck = New OfficeOpenXml.ExcelPackage()

            Using stream = File.OpenRead(path)
                pck.Load(stream)
            End Using

            Dim ws = pck.Workbook.Worksheets(1)
            Dim tbl As DataTable = New DataTable()

            For Each firstRowCell In ws.Cells(1, 1, 1, ws.Dimension.[End].Column)
                tbl.Columns.Add(If(hasHeader, firstRowCell.Text, String.Format("Column {0}", firstRowCell.Start.Column)))
            Next

            Dim startRow = If(hasHeader, 2, 1)

            For rowNum As Integer = startRow To ws.Dimension.[End].Row
                Dim wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.[End].Column)
                Dim row As DataRow = tbl.Rows.Add()

                For Each cell In wsRow
                    row(cell.Start.Column - 1) = cell.Text
                Next
            Next

            Return tbl
        End Using
    End Function

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim Updated As Boolean
        If ListView1.Items.Count = 0 Then
            MsgBox("No data loaded.", MsgBoxStyle.Critical, "e-File...")
            Return
        End If
        If MsgBox("Please confirm you want to update list of payers database.", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm...") = MsgBoxResult.No Then
            Return
        End If
        picArrow.Visible = False
        btnImport.Enabled = False
        cmdClose.Enabled = False
        cmdUpdate.Enabled = False
        lblWait.Text = "Updating database. PLease wait..."
        lblWait.Refresh()

        Using cnn As SqlConnection = New SqlConnection("Server=MAINSERVER;Database=eMedicalOffice;User Id=sa;Password=1966;")
            Dim transaction As SqlTransaction = Nothing
            Try
                cnn.Open()
                transaction = cnn.BeginTransaction()
                Using tr As New SqlCommand("truncate table CariskPayers1", cnn, transaction)
                    tr.ExecuteNonQuery()
                End Using
                ProgressBar1.Maximum = tbl.Rows.Count
                Dim i As Integer
                For Each Row As DataRow In tbl.Rows
                    i = i + 1
                    ProgressBar1.Value = i
                    ProgressBar1.Value = i - 1
                    ProgressBar1.Value = i
                    'ProgressBar1.Refresh()

                    Using sc As New SqlCommand(
                "INSERT INTO CariskPayers1 ([Payer Name], [PayerId],[States],[Professional],[Institutional],[PharmacyRx],[WorkComp],[Automotive],[835/EOB]) VALUES" &
                "(@PayerName, @PayerId,@States,@Professional,@Institutional, @PharmacyRx,@WorkComp,@Automotive,@EOB)", cnn, transaction)
                        sc.Parameters.AddWithValue("@PayerName", Row(0).ToString())
                        sc.Parameters.AddWithValue("@PayerId", Row(1).ToString())
                        sc.Parameters.AddWithValue("@States", Row(2).ToString())
                        sc.Parameters.AddWithValue("@Professional", Row(3).ToString())
                        sc.Parameters.AddWithValue("@Institutional", Row(4).ToString())
                        sc.Parameters.AddWithValue("@PharmacyRx", Row(5).ToString())
                        sc.Parameters.AddWithValue("@WorkComp", Row(6).ToString())
                        sc.Parameters.AddWithValue("@Automotive", Row(7).ToString())
                        sc.Parameters.AddWithValue("@EOB", Row(8).ToString())
                        sc.ExecuteNonQuery()
                    End Using
                Next
                transaction.Commit()
                cnn.Close()
                Updated = True
            Catch ex As Exception
                transaction.Rollback()
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error...")
            End Try
        End Using
        lblWait.Text = tbl.Rows.Count & " rows imported"
        lblWait.Refresh()
        MsgBox("Database update copmplete.", MsgBoxStyle.Information, "e-File")
        cmdClose.Enabled = True
        If Not Updated Then cmdUpdate.Enabled = True
        btnImport.Enabled = True
        If Updated Then Close()
    End Sub

    Private Sub frmEFileImport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not tbl Is Nothing Then tbl.Dispose()
    End Sub
End Class
