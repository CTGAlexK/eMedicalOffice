Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports FarPoint.Win.Spread
Imports FarPoint.Win.Spread.Model
Imports log4net

Public Class frmProceduresBatch
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem

    Private LoadingInd As Boolean
    Private UpdatedInd As Boolean

    Private Sub frmDiagnosisMaintenance_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            gWindow_Settings(Me, ReadWrite.sRead)
            Cursor = Cursors.WaitCursor
            Application.DoEvents()
            SetupSpread()
            Cursor = Cursors.Default
            Application.DoEvents()
            gSetup_GotFocus(Me)
            Application.DoEvents()
            Opacity = 100
            SetFont(0)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            Close()
        End Try
    End Sub

    Private Sub Load_Data()
        LoadingInd = True
        Dim SQL As String = "SELECT        DiagID, DiagName, DiagAbbreviation FROM Diagnostics ORDER BY DiagID"
        Dim Reader As SqlDataReader = gSQLGetDataReader(SQL)
        cmbDiag.Items.Clear()
        cmbDiag.Items.Add(New ValueDescription(0, "All "))
        Do Until Reader.Read() = False
            cmbDiag.Items.Add(New ValueDescription(Reader("DiagID").ToString(), Reader("DiagAbbreviation").ToString()))
        Loop
        cmbDiag.SelectedIndex = 0
        LoadingInd = True
    End Sub

    Private Sub SetupSpread()

        ' Define the operation of pressing Enter key in cells not being edited as "Move to the next row".

        Dim im As InputMap = FpSpread.GetInputMap(InputMapMode.WhenFocused)

        im.Put(New Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow)

        ' Define the operation of pressing Enter key in cells being edited as "Move to the next row".

        im = FpSpread.GetInputMap(InputMapMode.WhenAncestorOfFocused)

        im.Put(New Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow)

        im = FpSpread.GetInputMap(InputMapMode.WhenAncestorOfFocused)

        im.Put(New Keystroke(Keys.Delete, Keys.None), SpreadActions.ClearCell)

        im = FpSpread.GetInputMap(InputMapMode.WhenFocused)
        im.Put(New Keystroke(Keys.Delete, Keys.None), SpreadActions.ClearCell)

        FpSpread.ActiveSheet.Columns(0).AllowAutoSort = True
        FpSpread.ActiveSheet.Columns(0).ShowSortIndicator = True
        FpSpread.ActiveSheet.Columns(1).AllowAutoSort = True
        FpSpread.ActiveSheet.Columns(1).ShowSortIndicator = True
        FpSpread.ActiveSheet.Columns(2).AllowAutoSort = True
        FpSpread.ActiveSheet.Columns(2).ShowSortIndicator = True
        FpSpread.ActiveSheet.Columns(3).AllowAutoSort = True
        FpSpread.ActiveSheet.Columns(3).ShowSortIndicator = True
        FpSpread.ActiveSheet.Columns(4).AllowAutoSort = True
        FpSpread.ActiveSheet.Columns(4).ShowSortIndicator = True
    End Sub

    Private Sub frmAdjusterMaintenance_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        If cmdUpdate.Enabled Then
            If _
                MsgBox("You have unsaved data. Discard changes?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) =
                MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        If UpdatedInd Then
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub Load_Procedures()
        Dim Reader As SqlDataReader
        Dim RowInd = 0
        Dim SQL As String
        SQL = "SELECT        ProcID, ProcName, DiagID, Code, NFCost, WCCost, PRCost FROM Procedures WHERE ActiveInd = 1 "
        If cmbDiag.SelectedIndex > 0 Then
            SQL &= " AND DiagID = " & (CType(cmbDiag.SelectedItem, ValueDescription)).Value.ToString()
        End If
        SQL &= "  ORDER BY ProcName "
        Reader = gSQLGetDataReader(SQL)
        FpSpread.ActiveSheet.RowCount = 0
        If Reader Is Nothing Then Exit Sub
        LoadingInd = True
        FpSpread.ActiveSheet.RowHeaderVisible = False
        Do Until Reader.Read = False
            RowInd = RowInd + 1
            FpSpread.ActiveSheet.RowCount = RowInd
            FpSpread.ActiveSheet.Cells(RowInd - 1, 0).Text = Reader("Code").ToString()
            FpSpread.ActiveSheet.Cells(RowInd - 1, 0).Tag = Reader("ProcID").ToString()
            FpSpread.ActiveSheet.Cells(RowInd - 1, 1).Text = Reader("ProcName").ToString()
            FpSpread.ActiveSheet.Cells(RowInd - 1, 1).Tag = Reader("ProcName").ToString()
            FpSpread.ActiveSheet.Cells(RowInd - 1, 2).Text = Reader("NFCost").ToString()
            FpSpread.ActiveSheet.Cells(RowInd - 1, 2).Tag = Reader("NFCost").ToString()
            FpSpread.ActiveSheet.Cells(RowInd - 1, 3).Text = Reader("WCCost").ToString()
            FpSpread.ActiveSheet.Cells(RowInd - 1, 3).Tag = Reader("WCCost").ToString()
            FpSpread.ActiveSheet.Cells(RowInd - 1, 4).Text = Reader("PRCost").ToString()
            FpSpread.ActiveSheet.Cells(RowInd - 1, 4).Tag = Reader("PRCost").ToString()
            FpSpread.ActiveSheet.Rows(RowInd - 1).Tag = "0"
        Loop
        FpSpread.ActiveSheet.Columns(0).ResetSortIndicator()
        FpSpread.ActiveSheet.Columns(1).ResetSortIndicator()
        FpSpread.ActiveSheet.Columns(2).ResetSortIndicator()
        FpSpread.ActiveSheet.Columns(3).ResetSortIndicator()
        FpSpread.ActiveSheet.Columns(4).ResetSortIndicator()
        LoadingInd = False
        Reader.Close()
        Reader.Dispose()
        'Autosize_Spread()
        gSpreadAutoColumnWidth(FpSpread)
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Application.DoEvents()
        If MsgBox("Discard Changes?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, "Warning") = MsgBoxResult.No Then
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        cmdUpdate.Enabled = False
        cmdCancel.Enabled = False
        LabelUpdate.Visible = False
        Timer1.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        LabelProgress.Text = "Loadin Data. Please wait..."
        Load_Data()
        Load_Procedures()
        gSpreadAutoColumnWidth(FpSpread)
        gSpreadAutoColumnHeight(FpSpread)
        Cursor = Cursors.Default
        LabelProgress.Text = ""
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        SetFont(1)
    End Sub

    Private Sub SetFont(Optional incr As Integer = 0)
        Dim BaseSize = 8
        If BaseSize + My.Settings.FontSize + incr < 8 Or BaseSize + My.Settings.FontSize + incr > 15 Then Return
        My.Settings.FontSize = My.Settings.FontSize + incr
        My.Settings.Save()
        Dim F = New Font(FpSpread.Font.FontFamily, BaseSize + My.Settings.FontSize, FontStyle.Regular)
        FpSpread.Font = F
        gSpreadAutoColumnWidth(FpSpread)
        gSpreadAutoColumnHeight(FpSpread)
        'Autosize_Spread()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        SetFont(-1)
    End Sub

    Private Sub frmDiagnosisBatch_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        'Autosize_Spread()
    End Sub

    Private Sub FpSpread_Change(sender As Object, e As ChangeEventArgs) Handles FpSpread.Change
    End Sub

    Private Sub FpSpread_CellClick(sender As Object, e As CellClickEventArgs) Handles FpSpread.CellClick
    End Sub

    Private Sub FpSpread_Sheet1_CellChanged(sender As Object, e As SheetViewEventArgs) Handles FpSpread_Sheet1.CellChanged

        Dim ret1 As String
        Dim retTag1 As String
        Dim ret2 As String
        Dim retTag2 As String
        Dim ret3 As String
        Dim retTag3 As String

        If LoadingInd Then Exit Sub
        If e.Row = -1 Or e.Column = -1 Then Exit Sub
        ret1 = FpSpread.ActiveSheet.Cells(e.Row, 2).Text.Trim()
        If FpSpread.ActiveSheet.Cells(e.Row, 2).Tag Is Nothing Then
            retTag1 = ""
        Else
            retTag1 = FpSpread.ActiveSheet.Cells(e.Row, 2).Tag.ToString().Trim()
        End If
        ret2 = FpSpread.ActiveSheet.Cells(e.Row, 3).Text.Trim()
        If FpSpread.ActiveSheet.Cells(e.Row, 3).Tag Is Nothing Then
            retTag2 = ""
        Else
            retTag2 = FpSpread.ActiveSheet.Cells(e.Row, 3).Tag.ToString().Trim()
        End If

        ret3 = FpSpread.ActiveSheet.Cells(e.Row, 4).Text.Trim()
        If FpSpread.ActiveSheet.Cells(e.Row, 4).Tag Is Nothing Then
            retTag3 = ""
        Else
            retTag3 = FpSpread.ActiveSheet.Cells(e.Row, 4).Tag.ToString().Trim()
        End If

        If CDbl(ret1) <> CDbl(retTag1) Or CDbl(ret2) <> CDbl(retTag2) Or CDbl(ret3) <> CDbl(retTag3) Then
            FpSpread.ActiveSheet.Rows(e.Row).BackColor = Color.Orange
            FpSpread.ActiveSheet.Rows(e.Row).Tag = 1
        Else
            FpSpread.ActiveSheet.Rows(e.Row).BackColor = Color.Empty
            FpSpread.ActiveSheet.Rows(e.Row).Tag = 0
        End If
        CheckChanges()
    End Sub

    Private Sub CheckChanges()
        Dim ret As String

        For r = 0 To FpSpread.ActiveSheet.Rows.Count - 1
            If FpSpread.ActiveSheet.Rows(r).Tag Is Nothing Then
                ret = ""
            Else
                ret = FpSpread.ActiveSheet.Rows(r).Tag.ToString().Trim()
            End If
            If ret = "1" Or ret = "2" Then
                cmdUpdate.Enabled = True
                cmdCancel.Enabled = True
                LabelUpdate.Visible = True
                Return
            End If
        Next
        cmdUpdate.Enabled = False
        cmdCancel.Enabled = False
        LabelUpdate.Visible = False
        Return
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim ret As ValidateResult
        Dim msg As String
        ret = Validate()
        If ret.IsOk = False Then Return

        msg = "Please confirm you want to update " & ret.u & " record" & IIf(ret.u > 1, "s", "") & vbCrLf & vbCrLf
        If MsgBox(msg, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation") = MsgBoxResult.No Then
            Exit Sub
        End If
        LabelProgress.Text = "Updatig Data. Please wait..."
        Application.DoEvents()
        Dim SQL As String

        For r = 0 To FpSpread.ActiveSheet.Rows.Count - 1
            Dim ProcedureID As Integer = Val(FpSpread.ActiveSheet.Cells(r, 0).Tag.ToString())
            Dim NFCost As String = FpSpread.ActiveSheet.Cells(r, 2).Text.Trim()
            Dim WCCost As String = FpSpread.ActiveSheet.Cells(r, 3).Text.Trim()
            Dim PRCost As String = FpSpread.ActiveSheet.Cells(r, 4).Text.Trim()
            If FpSpread.ActiveSheet.Rows(r).Tag.ToString() = "1" Then
                SQL = "Update [Procedures] set "
                SQL &= "NFCost = '" & CType(NFCost, Double) & "', "
                SQL &= "WCCost = '" & CType(WCCost, Double) & "', "
                SQL &= "PRCost = '" & CType(PRCost, Double) & "' "
                SQL &= "WHERE ProcID = " & ProcedureID
                gSQLUpdateData(SQL)
            End If
        Next
        LabelProgress.Text = ""
        Timer1.Enabled = True
        UpdatedInd = True
        cmdUpdate.Enabled = False
        cmdCancel.Enabled = False
        LabelUpdate.Visible = False
    End Sub

    Private Function IsRowEmpty(RowIndex) As Boolean
        Dim retDignosisID As String
        Dim ret1 As String
        Dim ret2 As String
        Dim ret3 As String

        If RowIndex > -1 Then
            ret1 = FpSpread.ActiveSheet.Cells(RowIndex, 1).Text.Trim()
            ret2 = FpSpread.ActiveSheet.Cells(RowIndex, 2).Text.Trim()
            ret3 = FpSpread.ActiveSheet.Cells(RowIndex, 3).Text.Trim()
            If FpSpread.ActiveSheet.Cells(RowIndex, 0).Tag Is Nothing Then
                retDignosisID = ""
            Else
                retDignosisID = FpSpread.ActiveSheet.Cells(RowIndex, 0).Tag.ToString().Trim()
            End If
            If retDignosisID = "" And ret1 = "" And ret2 = "" And ret3 = "" Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub FpSpread_EditModeOff(sender As Object, e As EventArgs) Handles FpSpread.EditModeOff
        Dim ActiveRowIndex As Integer = FpSpread.ActiveSheet.ActiveRow.Index
        If IsRowEmpty(ActiveRowIndex) Then
            FpSpread.ActiveSheet.RemoveRows(ActiveRowIndex, 1)
        End If
    End Sub

    Private Function Validate() As ValidateResult
        Dim ret As New ValidateResult
        For r = 0 To FpSpread.ActiveSheet.Rows.Count - 1
            Dim Reader As SqlDataReader
            Dim ProcedureID As Integer
            Dim NF2Price As String = FpSpread.ActiveSheet.Cells(r, 2).Text.Trim()
            Dim WCPrice As String = FpSpread.ActiveSheet.Cells(r, 3).Text.Trim()
            Dim PRPrice As String = FpSpread.ActiveSheet.Cells(r, 4).Text.Trim()
            ProcedureID = Val(FpSpread.ActiveSheet.Cells(r, 0).Tag.ToString())
            If NF2Price = "" Then
                FpSpread.ActiveSheet.Cells(r, 2).Text = "$0"
                FpSpread.ActiveSheet.Rows(r).Tag = "1"
            End If
            If WCPrice = "" Then
                FpSpread.ActiveSheet.Cells(r, 3).Text = "$0"
                FpSpread.ActiveSheet.Rows(r).Tag = "1"
            End If
            If PRPrice = "" Then
                FpSpread.ActiveSheet.Cells(r, 4).Text = "$0"
                FpSpread.ActiveSheet.Rows(r).Tag = "1"
            End If
            If FpSpread.ActiveSheet.Rows(r).Tag.ToString() = "1" Or FpSpread.ActiveSheet.Rows(r).Tag.ToString() = "" Then
                ret.u = ret.u + 1
            End If
        Next
        If ret.u = 0 Then
            MsgBox("Nothing to update.", MsgBoxStyle.Exclamation, "Oops")
            Return ret
        End If
        ret.IsOk = True
        Return ret
    End Function

    Private Class ValidateResult
        Public IsOk As Boolean
        Public u As Integer
        Public a As Integer
        Public d As Integer
    End Class

    Private Sub TimerSearchReset_Tick(sender As Object, e As EventArgs) Handles TimerSearchReset.Tick
        TimerSearchReset.Enabled = False
        TextBoxSearch.BackColor = Color.White
    End Sub

    Private Sub TextBoxSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearch.KeyPress

    End Sub

    Private Sub frmDiagnosisBatch_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, TextBoxSearch.KeyDown
        If e.KeyCode = Keys.Down Then
            FpSpread.Focus()
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.F3 Then
            TimerSearchFocus.Enabled = True
        End If
    End Function

    Private Sub TimerSearchFocus_Tick(sender As Object, e As EventArgs) Handles TimerSearchFocus.Tick
        TimerSearchFocus.Enabled = False
        TextBoxSearch.Focus()
        TextBoxSearch.BackColor = Color.DarkOrange
        TimerSearchReset.Enabled = True
    End Sub

    Private Sub ToolStripAutoResize_Click(sender As Object, e As EventArgs) Handles ToolStripAutoResize.Click
        gSpreadAutoColumnWidth(FpSpread)
        'Autosize_Spread
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButtonExport.Click
        SaveFileDialog1.FileName = "Procedure Prices as of " & Now.ToString("MM-dd-yyyy") & ".xls"
        If SaveFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            FpSpread.SaveExcel(SaveFileDialog1.FileName, IncludeHeaders.ColumnHeadersCustomOnly)
            Process.Start(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged
        TextBoxSearch.BackColor = Color.White
        For r = 0 To FpSpread.ActiveSheet.RowCount - 1
            If FpSpread.ActiveSheet.Cells(r, 0).Text.ToUpper() Like TextBoxSearch.Text.ToUpper() & "*" Or FpSpread.ActiveSheet.Cells(r, 1).Text.ToUpper() Like "*" & TextBoxSearch.Text.ToUpper() & "*" Then
                FpSpread.ActiveSheet.SetActiveCell(r, 0)
                FpSpread.ShowActiveCell(0, 0)
                Exit Sub
            End If
        Next
        FpSpread.ActiveSheet.SetActiveCell(-1, -1)
        FpSpread.ShowActiveCell(0, 0)
        TextBoxSearch.BackColor = Color.LightSalmon
        Beep()
        TimerSearchReset.Enabled = True
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButtonEmail.Click
        Dim Msg As New SendFileTo
        Dim Subject As String
        ToolStripButtonEmail.Enabled = False
        UseWaitCursor = True
        LabelProgress.Text = "Sending Email. Please wait..."
        Application.DoEvents()
        Subject = "Attached: Diagnoses List as of " & Now.Date.ToShortDateString() & "  " & Now.Date.ToShortTimeString()
        Try
            Dim filepath As String = Path.GetTempFileName
            filepath = filepath.Mid(1, filepath.Length - 4) & "_Diagnosis" & ".xls"
            FpSpread.SaveExcel(filepath, IncludeHeaders.ColumnHeadersCustomOnly)
            Msg.SendMail(filepath, Subject, Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        UseWaitCursor = False
        ToolStripButtonEmail.Enabled = True
        LabelProgress.Text = ""
    End Sub

    Private Sub cmbDiag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiag.SelectedIndexChanged
        If LoadingInd Then Return
        If cmbDiag.SelectedIndex = -1 Then Return
        Load_Procedures()

    End Sub

End Class