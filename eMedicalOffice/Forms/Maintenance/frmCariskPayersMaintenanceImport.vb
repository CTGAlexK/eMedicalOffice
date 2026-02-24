Imports System.Data.SqlClient
Imports System.IO

Public Class frmCariskPayersMaintenanceImport
    Public tbl As DataTable
    Public tblexisting As DataTable
    Public ParentWindow As Form
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Try
            cmdUpdate.Enabled = False
            picArrow.Visible = False
            btnImport.Enabled = False
            Dim i As Integer
            Dim addCount As Integer
            Dim updateCount As Integer
            lblWait.Text = "Loading file data. Please wait..."
            lblWait.Refresh()
            OpenFileDialog1.FileName = "Carisk-Payers.xlsx"
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                ListView1.Items.Clear()
                tbl = DatatableFromXLSX(OpenFileDialog1.FileName, True)
                If tbl.Columns.Count <> 9 Then
                    MsgBox("Invalid file format." & vbCrLf & "Expected Carisk-Payers.xlsx file with the following columns:" & vbCrLf & vbCrLf & "[Payer Name]" & vbCrLf & "[PayerId]" & vbCrLf & "[States]" & vbCrLf & "[Professional]" & vbCrLf & "[Institutional]" & vbCrLf & "[PharmacyRx]" & vbCrLf & "[WorkComp]" & vbCrLf & "[Automotive]" & vbCrLf & "[835/EOB]" & vbCrLf & vbCrLf & "Please check the file format and try again.", MsgBoxStyle.Critical, "e-File...")
                    lblWait.Text = "Invalid File Format"
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
                    lblWait.Text = "Invalid File Format"
                    cmdUpdate.Enabled = True
                    btnImport.Enabled = True
                    Return
                End If
                ProgressBar1.Maximum = tbl.Rows.Count
                ListView1.BeginUpdate()
                Dim recColor As Color

                For Each row As DataRow In tbl.Rows
                    i = i + 1
                    ProgressBar1.Value = i
                    ProgressBar1.Value = i - 1
                    ProgressBar1.Value = i
                    ProgressBar1.Refresh()
                    Dim dr() As System.Data.DataRow
                    Dim ActionStr As String
                    dr = tblexisting.Select("PayerId = '" & row("PayerId").ToString() & "'")
                    If dr.Length = 0 Then
                        recColor = Color.FromArgb(217, 235, 255)
                        addCount = addCount + 1
                        ActionStr = "Add"
                    ElseIf dr(0).Item("Payer Name").ToString() <> row.Item("Payer Name").ToString() Or dr(0).Item("States").ToString() <> row.Item("States").ToString() Or dr(0).Item("Professional").ToString() <> row.Item("Professional").ToString() Or dr(0).Item("Institutional").ToString() <> row.Item("Institutional").ToString() Or dr(0).Item("PharmacyRx").ToString() <> row.Item("PharmacyRx").ToString() Or dr(0).Item("WorkComp").ToString() <> row.Item("WorkComp").ToString() Or dr(0).Item("Automotive").ToString() <> row.Item("Automotive").ToString() Or dr(0).Item("835/EOB").ToString() <> row.Item("835/EOB").ToString() Then
                        recColor = Color.FromArgb(255, 222, 189)
                        updateCount = updateCount + 1
                        ActionStr = "Update"
                    Else
                        Continue For
                    End If

                    Dim lvi As ListViewItem = ListView1.Items.Add(row(0))
                    lvi.BackColor = recColor
                    lvi.SubItems.Add(row(1).ToString())
                    lvi.SubItems.Add(row(2).ToString())
                    lvi.SubItems.Add(row(3).ToString())
                    lvi.SubItems.Add(row(4).ToString())
                    lvi.SubItems.Add(row(5).ToString())
                    lvi.SubItems.Add(row(6).ToString())
                    lvi.SubItems.Add(row(7).ToString())
                    lvi.SubItems.Add(row(8).ToString())
                    lvi.SubItems.Add(ActionStr)
                    lvi.SubItems.Add(i + 1)
                Next
                ListView1.EndUpdate()
                lblWait.Text = "Processed " & tbl.Rows.Count & " record" & IIf(tbl.Rows.Count > 1, "s", "") & ". " & addCount & " record" & IIf(addCount > 1, "s", "") & " added. " & updateCount & " record" & IIf(updateCount > 1, "s", "") & " updated."
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "e-File...")
        End Try
        picArrow.Visible = True
        cmdUpdate.Enabled = True
        btnImport.Enabled = True
    End Sub
    Private Function DatatableFromXLSX(ByVal filepath As String, ByVal Optional hasHeader As Boolean = True) As DataTable
        Using pck = New OfficeOpenXml.ExcelPackage()
            Dim TempFile As String = Path.GetTempFileName
            TempFile = Path.ChangeExtension(TempFile, "xlsx")
            File.Copy(filepath, TempFile)

            Using stream = File.OpenRead(TempFile)
                pck.Load(stream)
            End Using
            Try
                File.Delete(TempFile)
            Catch
            End Try
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

    Private Sub cmdClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        If ListView1.Items.Count = 0 Then
            MsgBox("No data loaded.", MsgBoxStyle.Critical, "e-File...")
            Return
        End If

        For Each item As ListViewItem In ListView1.Items
            If item.SubItems(0).Text = "" Then
                MsgBox("Unable to process update." & vbCrLf & vbCrLf & "Payer Name is missing." & vbCrLf & vbCrLf & "Fix the problem in Excel file and process import again.", MsgBoxStyle.Exclamation, "Validation Error")
                item.Selected = True : item.EnsureVisible() : ListView1.Focus() : Return
            End If
            If item.SubItems(1).Text = "" Then
                MsgBox("Unable to process update." & vbCrLf & vbCrLf & "Payer Id is missing." & vbCrLf & vbCrLf & "Fix the problem in Excel file and process import again.", MsgBoxStyle.Exclamation, "Validation Error")
                item.Selected = True : item.EnsureVisible() : ListView1.Focus() : Return
            End If
            If item.SubItems(2).Text = "" Then
                MsgBox("Unable to process update." & vbCrLf & vbCrLf & "Payer States is missing." & vbCrLf & vbCrLf & "Fix the problem in Excel file and process import again.", MsgBoxStyle.Exclamation, "Validation Error")
                item.Selected = True : item.EnsureVisible() : ListView1.Focus() : Return
            End If
        Next
        Dim msg As String
        If gOffices.Count > 0 Then
            msg = "Please confirm you want to update list of payers database in all " & gOffices.Count & " offices?"
        Else
            msg = "Please confirm you want to update list of payers database?"
        End If
        If MsgBox(msg, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm...") = MsgBoxResult.No Then
            Return
        End If
        picArrow.Visible = False
        btnImport.Enabled = False
        cmdUpdate.Enabled = False
        Try
            If gOffices.Count > 1 Then
                For Each soffice In gOffices
                    lblWait.Text = "Updating " & soffice.OfficeName & " database. Please wait..."
                    lblWait.Refresh()
                    UpdatePayer(soffice.ConnectionString)
                Next
            Else
                lblWait.Text = "Updating database. Please wait..."
                lblWait.Refresh()
                UpdatePayer(gConnectionString)
            End If
            lblWait.Text = "Update complete..."
            lblWait.Refresh()
            MsgBox("Database update complete.", MsgBoxStyle.Information)
            cmdUpdate.Enabled = True
            btnImport.Enabled = True
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Oops...")
            cmdUpdate.Enabled = True
            btnImport.Enabled = True
        End Try
    End Sub
    Private Function UpdatePayer(ConnectionString As String) As Boolean
        Using cnn As SqlConnection = New SqlConnection(ConnectionString)
            Dim transaction As SqlTransaction = Nothing
            Try
                cnn.Open()
                transaction = cnn.BeginTransaction()
                ProgressBar1.Maximum = tbl.Rows.Count
                Dim i As Integer
                For Each Row As ListViewItem In ListView1.Items
                    i = i + 1
                    ProgressBar1.Value = i
                    ProgressBar1.Value = i - 1
                    ProgressBar1.Value = i
                    Dim tblName As String = "CariskPayers"
                    ' Debug
                    'tblName = "CariskPayers1"
                    'ProgressBar1.Refresh()
                    If Row.SubItems(9).Text = "Add" Then
                        Using sc As New SqlCommand(
                            "INSERT INTO " & tblName & " ([Payer Name], [PayerId],[States],[Professional],[Institutional],[PharmacyRx],[WorkComp],[Automotive],[835/EOB]) VALUES" &
                            "(@PayerName, @PayerId,@States,@Professional,@Institutional, @PharmacyRx,@WorkComp,@Automotive,@EOB)", cnn, transaction)
                            sc.Parameters.AddWithValue("@PayerName", Row.SubItems(0).Text.Trim)
                            sc.Parameters.AddWithValue("@PayerId", Row.SubItems(1).Text.Trim())
                            sc.Parameters.AddWithValue("@States", Row.SubItems(2).Text.Trim)
                            sc.Parameters.AddWithValue("@Professional", Row.SubItems(3).Text.Trim)
                            sc.Parameters.AddWithValue("@Institutional", Row.SubItems(4).Text.Trim)
                            sc.Parameters.AddWithValue("@PharmacyRx", Row.SubItems(5).Text.Trim)
                            sc.Parameters.AddWithValue("@WorkComp", Row.SubItems(6).Text.Trim)
                            sc.Parameters.AddWithValue("@Automotive", Row.SubItems(7).Text.Trim)
                            sc.Parameters.AddWithValue("@EOB", Row.SubItems(8).Text.Trim)
                            sc.ExecuteNonQuery()
                        End Using
                    ElseIf Row.SubItems(9).Text = "Update" Then
                        Using sc As New SqlCommand(
                                                    "UPDATE " & tblName & " SET [Payer Name]=@PayerName, [States]=@States,[Professional]=@Professional,[Institutional]=@Institutional,[PharmacyRx]=@PharmacyRx,[WorkComp]=@WorkComp,[Automotive]=@Automotive,[835/EOB]=@EOB " &
                                                    " WHERE [PayerId]=@PayerId", cnn, transaction)
                            sc.Parameters.AddWithValue("@PayerName", Row.SubItems(0).Text.Trim)
                            sc.Parameters.AddWithValue("@PayerId", Row.SubItems(1).Text.Trim())
                            sc.Parameters.AddWithValue("@States", Row.SubItems(2).Text.Trim)
                            sc.Parameters.AddWithValue("@Professional", Row.SubItems(3).Text.Trim)
                            sc.Parameters.AddWithValue("@Institutional", Row.SubItems(4).Text.Trim)
                            sc.Parameters.AddWithValue("@PharmacyRx", Row.SubItems(5).Text.Trim)
                            sc.Parameters.AddWithValue("@WorkComp", Row.SubItems(6).Text.Trim)
                            sc.Parameters.AddWithValue("@Automotive", Row.SubItems(7).Text.Trim)
                            sc.Parameters.AddWithValue("@EOB", Row.SubItems(8).Text.Trim)
                            sc.ExecuteNonQuery()
                        End Using
                    End If
                Next
                transaction.Commit()
                cnn.Close()
                Return True
            Catch ex As Exception
                transaction.Rollback()
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error...")
                Return False
            End Try
        End Using
    End Function
    Private Sub frmEFileImport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not tbl Is Nothing Then tbl.Dispose()
        ParentWindow.Show()
    End Sub

    Private Sub frmCariskPayersMaintenanceImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim OfficesMsg As String
        ListView1.Columns(9).DisplayIndex = 0
        ListView1.Columns(10).DisplayIndex = 0
        If gOffices.Count > 0 Then
            For Each item As Office In gOffices
                OfficesMsg &= item.OfficeName & vbCrLf
            Next
            lblMultipleOffices.Text = "Update All " & gOffices.Count & " Offices"
            ToolTip1.SetToolTip(lblMultipleOffices, OfficesMsg)
        Else
            lblMultipleOffices.Text = "Update " & gOfficeName & " Office"
            ToolTip1.SetToolTip(lblMultipleOffices, gOfficeName)
        End If
        Load_Payers()
        Timer1.Enabled = True
    End Sub
    Private Sub Load_Payers()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        tblexisting = New DataTable()
        Reader = gSQLGetDataReader("SELECT [Payer Name],[PayerId],[States],[Professional],[Institutional],[PharmacyRx],[WorkComp],[Automotive],[835/EOB] FROM [dbo].[CariskPayers]")
        If Reader Is Nothing Then Exit Sub
        tblexisting.Load(Reader)
        Reader.Close() : Reader.Dispose()
    End Sub
    Private Sub frmCariskPayersMaintenanceImport_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Timer1.Enabled = False
        Opacity = 1
        ParentWindow.Hide()
    End Sub
End Class
