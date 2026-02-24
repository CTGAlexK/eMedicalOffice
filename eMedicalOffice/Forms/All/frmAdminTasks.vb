Public Class frmAdminTasks

    Private Sub frmAdminTasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead, True)
        FpSpread.ActiveSheet.Columns(1).Width = FpSpread.Width - 50
        Label3.Text = Date.Now.ToShortDateString()
        Load_Tasks()

    End Sub

    Private Sub Load_Tasks()
        Dim reader As SqlClient.SqlDataReader
        Dim LV As ListViewItem
        Dim SQL As String = "SELECT ID, TaskName, Description, ShowOrder, ActiveInd FROM AdminTasksList where ActiveInd=1 Order by ShowOrder"
        reader = gSQLGetDataReader(SQL)
        FpSpread.Sheets(0).RowCount = 0
        Do Until reader.Read = False
            Dim AT As New clsAdminTask
            FpSpread.Sheets(0).RowCount = FpSpread.Sheets(0).RowCount + 1
            FpSpread.Sheets(0).Cells(FpSpread.Sheets(0).RowCount, 1).Value = reader("TaskName").ToString()
            AT.TaskID = reader("ID")
            AT.TaskName = reader("TaskName").ToString()
            AT.Description = reader("Description").ToString()
            FpSpread.Sheets(0).Cells(FpSpread.Sheets(0).RowCount, 1).Tag = AT
        Loop
    End Sub

    Private Sub frmAdminTasks_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub frmAdminTasks_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite, True)
    End Sub

    Private Sub FpSpread_SelectionChanged(sender As Object, e As FarPoint.Win.Spread.SelectionChangedEventArgs) Handles FpSpread.SelectionChanged
        If FpSpread.ActiveSheet.ActiveRowIndex = 0 Then

        End If
        'Label1.Text = ""
        'If ListView1.SelectedItems.Count = 0 Then Exit Sub
        'HighLightRow()
        'Dim AT As New clsAdminTask
        'AT = ListView1.SelectedItems(0).Tag
        'Label1.Text = AT.Description

    End Sub

End Class