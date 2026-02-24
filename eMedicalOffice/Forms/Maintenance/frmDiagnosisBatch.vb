Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms.VisualStyles
Imports FarPoint.Win.Spread
Imports FarPoint.Win.Spread.Model
Imports log4net

Public Class frmDiagnosisBatch
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

    Private Sub Load_Diagnosis()
        Dim Reader As SqlDataReader
        Dim RowInd = 0
        Try
            Reader = gSQLGetDataReader("SELECT * FROM Diagnosis Order By ICDCode")
            FpSpread.ActiveSheet.RowCount = 0
            If Reader Is Nothing Then Exit Sub
            LoadingInd = True
            FpSpread.ActiveSheet.RowHeaderVisible = False
            Do Until Reader.Read = False
                RowInd = RowInd + 1
                FpSpread.ActiveSheet.RowCount = RowInd
                FpSpread.ActiveSheet.Cells(RowInd - 1, 0).Text = Reader("ICDCode").ToString()
                FpSpread.ActiveSheet.Cells(RowInd - 1, 0).Tag = Reader("DignosisID").ToString()
                FpSpread.ActiveSheet.Cells(RowInd - 1, 1).Tag = ""
                FpSpread.ActiveSheet.Cells(RowInd - 1, 2).Text = Reader("ICDDescription").ToString()
                FpSpread.ActiveSheet.Cells(RowInd - 1, 2).Tag = Reader("ICDDescription").ToString()
                FpSpread.ActiveSheet.Cells(RowInd - 1, 3).Text = Reader("ICDGroup").ToString()
                FpSpread.ActiveSheet.Cells(RowInd - 1, 3).Tag = Reader("ICDGroup").ToString()
                FpSpread.ActiveSheet.Rows(RowInd - 1).Tag = "0"
            Loop
            FpSpread.ActiveSheet.Columns(0).ResetSortIndicator()
            FpSpread.ActiveSheet.Columns(1).ResetSortIndicator()
            FpSpread.ActiveSheet.Columns(2).ResetSortIndicator()
            FpSpread.ActiveSheet.Columns(3).ResetSortIndicator()
            LoadingInd = False
            Reader.Close()
            Reader.Dispose()
            'Autosize_Spread()
            gSpreadAutoColumnWidth(FpSpread)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlDataReader
        Dim lAutocomplete As New AutoCompleteStringCollection()
        Try
            Reader =
            gSQLGetDataReader(
                "SELECT  DISTINCT   ICDGroup FROM Diagnosis Where (ICDGroup IS NOT NULL) and ICDGroup <> '' ORDER BY ICDGroup")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                lAutocomplete.Add(Reader("ICDGroup").ToString)
            Loop
            Reader.Close()
            Reader.Dispose()
            Dim cb As New CellType.TextCellType
            cb.MaxLength = 15
            cb.AutoCompleteCustomSource = lAutocomplete
            cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cb.AutoCompleteSource = AutoCompleteSource.CustomSource
            FpSpread.ActiveSheet.Columns(3).CellType = cb
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
    End Sub

    Public Sub cmdAddNew_Click(sender As Object, e As EventArgs) Handles cmdAddNew.Click

        Dim LastRowIndex As Integer = FpSpread.ActiveSheet.Rows.Count - 1
        Dim retOldCode As String = FpSpread.ActiveSheet.Cells(LastRowIndex, 0).Text.ToString()
        Dim retCode As String = FpSpread.ActiveSheet.Cells(LastRowIndex, 1).Text.ToString()
        If retOldCode.Trim <> "" Or (retOldCode.Trim = "" And retCode <> "") Then

            FpSpread.ActiveSheet.Rows.Count = FpSpread.ActiveSheet.Rows.Count + 1
            LastRowIndex = FpSpread.ActiveSheet.Rows.Count - 1
        End If
        FpSpread.ActiveSheet.SetActiveCell(LastRowIndex, 1)
        FpSpread.Focus()
        FpSpread.EditMode = True
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Application.DoEvents()
        If MsgBox("Discard Changes?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, "Warning") = MsgBoxResult.No Then
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        cmdDelete.Enabled = True
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
        Load_Diagnosis()
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
        ret1 = FpSpread.ActiveSheet.Cells(e.Row, 1).Text.Trim()
        If FpSpread.ActiveSheet.Cells(e.Row, 1).Tag Is Nothing Then
            retTag1 = ""
        Else
            retTag1 = FpSpread.ActiveSheet.Cells(e.Row, 1).Tag.ToString().Trim()
        End If
        ret2 = FpSpread.ActiveSheet.Cells(e.Row, 2).Text.Trim()
        If FpSpread.ActiveSheet.Cells(e.Row, 2).Tag Is Nothing Then
            retTag2 = ""
        Else
            retTag2 = FpSpread.ActiveSheet.Cells(e.Row, 2).Tag.ToString().Trim()
        End If

        ret3 = FpSpread.ActiveSheet.Cells(e.Row, 3).Text.Trim()
        If FpSpread.ActiveSheet.Cells(e.Row, 3).Tag Is Nothing Then
            retTag3 = ""
        Else
            retTag3 = FpSpread.ActiveSheet.Cells(e.Row, 3).Tag.ToString().Trim()
        End If

        If ret1 <> retTag1 Or ret2 <> retTag2 Or ret3 <> retTag3 Then
            FpSpread.ActiveSheet.Rows(e.Row).BackColor = Color.Orange
            FpSpread.ActiveSheet.Rows(e.Row).Tag = 1
        Else
            FpSpread.ActiveSheet.Rows(e.Row).BackColor = Color.Empty
            FpSpread.ActiveSheet.Rows(e.Row).Tag = 0
        End If
        Dim ActiveRowIndex As Integer = e.Row
        If IsRowEmpty(ActiveRowIndex) Then
            FpSpread.ActiveSheet.RemoveRows(ActiveRowIndex, 1)
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

        msg = "Please confirm you want to " & vbCrLf & vbCrLf
        If ret.a > 0 Then
            msg &= "Add New: " & ret.a & " record" & IIf(ret.a > 1, "s", "") & vbCrLf
        End If

        If ret.u > 0 Then
            msg &= "Update: " & ret.u & " record" & IIf(ret.u > 1, "s", "") & vbCrLf
        End If
        If ret.d > 0 Then
            msg &= "Delete: " & ret.d & " record" & IIf(ret.d > 1, "s", "") & vbCrLf
        End If
        If MsgBox(msg, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation") = MsgBoxResult.No Then
            Exit Sub
        End If
        LabelProgress.Text = "Updatig Data. Please wait..."
        Application.DoEvents()
        Dim SQL As String

        For r = 0 To FpSpread.ActiveSheet.Rows.Count - 1
            Dim DignosisID As Integer
            Dim ICDCode As String
            Dim NewICDCode As String
            Dim ICDDescription As String
            Dim ICDGroup As String
            ICDCode = FpSpread.ActiveSheet.Cells(r, 0).Text.Trim()
            NewICDCode = FpSpread.ActiveSheet.Cells(r, 1).Text.Trim()
            ICDDescription = FpSpread.ActiveSheet.Cells(r, 2).Text.Trim()
            ICDGroup = FpSpread.ActiveSheet.Cells(r, 3).Text.Trim()
            If FpSpread.ActiveSheet.Cells(r, 0).Tag Is Nothing Then
                DignosisID = -1
            Else
                DignosisID = Val(FpSpread.ActiveSheet.Cells(r, 0).Tag.ToString())
            End If
            If NewICDCode.Trim().Length > 0 Then
                ICDCode = NewICDCode.Trim()
            End If

            If FpSpread.ActiveSheet.Rows(r).Tag.ToString() = "1" Then
                If DignosisID > -1 Then
                    SQL = "Update [Diagnosis] set "
                    SQL &= "ICDCode = '" & ICDCode.ToSafeSQLString() & "', "
                    SQL &= "ICDDescription = '" & ICDDescription.ToSafeSQLString() & "', "
                    SQL &= "ICDGroup = '" & ICDGroup.ToSafeSQLString() & "', "
                    SQL &= "ChangedBy = " & gCurrentEmployee.EmpID & ", "
                    SQL &= "ChangedDT= '" & Now.ToString("MM/dd/yyyy") & "' "
                    SQL &= "WHERE DignosisID = " & DignosisID
                Else
                    SQL = "INSERT INTO Diagnosis (ICDCode, ICDDescription, ICDGroup, ChangedBy, ChangedDT) VALUES "
                    SQL &= "('" & ICDCode.ToSafeSQLString() & "','" & ICDDescription.ToSafeSQLString() & "','" & ICDGroup.ToSafeSQLString() & "'," &
                           gCurrentEmployee.EmpID & ",'" & Now.ToString("MM/dd/yyyy") & "')"
                End If
                gSQLUpdateData(SQL)
            ElseIf FpSpread.ActiveSheet.Rows(r).Tag.ToString() = "2" Then
                If DignosisID > 0 Then
                    SQL = "DELETE FROM Diagnosis WHERE DignosisID = " & DignosisID
                    gSQLUpdateData(SQL)
                End If
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

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        Dim ActiveRowIndex As Integer = FpSpread.ActiveSheet.ActiveRow.Index
        If ActiveRowIndex = -1 Then Return
        Dim RetretDignosisID As String
        Dim ICDCode As String = FpSpread.ActiveSheet.Cells(ActiveRowIndex, 0).Text
        Dim NewICDCode As String = FpSpread.ActiveSheet.Cells(ActiveRowIndex, 1).Text
        If FpSpread.ActiveSheet.Cells(ActiveRowIndex, 0).Tag Is Nothing Then
            RetretDignosisID = ""
        Else
            RetretDignosisID = FpSpread.ActiveSheet.Cells(ActiveRowIndex, 0).Tag
        End If
        If RetretDignosisID = "" And ICDCode = "" And NewICDCode = "" Then
            FpSpread.ActiveSheet.RemoveRows(ActiveRowIndex, 1)
            Return
        End If
        If ICDCode = "" Then ICDCode = NewICDCode
        If _
            MsgBox("Please confirm you want to delete record for ICD Code " & ICDCode & "?",
                   MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation") = MsgBoxResult.No Then
            Exit Sub
        End If
        FpSpread.ActiveSheet.Rows(ActiveRowIndex).Tag = 2
        Dim F = New Font(FpSpread.Font.FontFamily, FpSpread.Font.Size, FontStyle.Strikeout)
        FpSpread.ActiveSheet.Rows(ActiveRowIndex).Font = F
        FpSpread.ActiveSheet.Rows(ActiveRowIndex).ForeColor = Color.Red
        cmdUpdate.Enabled = True
        cmdCancel.Enabled = True
        LabelUpdate.Visible = True
    End Sub

    Private Function Validate() As ValidateResult
        Dim ret As New ValidateResult
        For r = 0 To FpSpread.ActiveSheet.Rows.Count - 1
            Dim Reader As SqlDataReader
            Dim DignosisID As Integer
            Dim ICDCode As String
            Dim NewICDCode As String
            Dim ICDDescription As String
            Dim ICDGroup As String
            ICDCode = FpSpread.ActiveSheet.Cells(r, 0).Text.Trim()
            NewICDCode = FpSpread.ActiveSheet.Cells(r, 1).Text.Trim()
            ICDDescription = FpSpread.ActiveSheet.Cells(r, 2).Text.Trim()
            ICDGroup = FpSpread.ActiveSheet.Cells(r, 3).Text.Trim()
            If FpSpread.ActiveSheet.Cells(r, 0).Tag Is Nothing Then
                DignosisID = -1
            Else
                DignosisID = Val(FpSpread.ActiveSheet.Cells(r, 0).Tag.ToString())
            End If
            If NewICDCode.Trim().Length > 0 Then
                ICDCode = NewICDCode.Trim()
            End If
            If ICDCode = "" Then
                FpSpread.ActiveSheet.SetActiveCell(r, 1)
                FpSpread.ShowActiveCell(0, 0)
                FpSpread.Focus()
                Application.DoEvents()
                MsgBox("Unable to update. The ICDCode is required.", MsgBoxStyle.Exclamation)
                FpSpread.Focus()
                FpSpread.EditMode = True
                Return ret
            End If
            If ICDDescription = "" Then
                FpSpread.ActiveSheet.SetActiveCell(r, 2)
                FpSpread.ShowActiveCell(0, 0)
                FpSpread.Focus()
                Application.DoEvents()
                MsgBox("Unable to update. The ICDDescription is required.", MsgBoxStyle.Exclamation)
                FpSpread.Focus()
                FpSpread.EditMode = True
                Return ret
            End If
            If ICDGroup = "" Then

                FpSpread.ActiveSheet.SetActiveCell(r, 3)
                FpSpread.ShowActiveCell(0, 0)
                FpSpread.Focus()
                Application.DoEvents()
                MsgBox("Unable to update. The ICDGroup is required.", MsgBoxStyle.Exclamation)
                FpSpread.EditMode = True
                FpSpread.Focus()
                Return ret
            End If
            If FpSpread.ActiveSheet.Rows(r).Tag.ToString() = "1" Or FpSpread.ActiveSheet.Rows(r).Tag.ToString() = "" _
                Then
                If DignosisID = -1 Then
                    Reader =
                        gSQLGetDataReader("Select count(*) as C from Diagnosis Where ICDCode = '" & ICDCode.ToSafeSQLString() & "'")
                Else
                    Reader =
                        gSQLGetDataReader(
                            "Select count(*) as C from Diagnosis Where DignosisID <> " & DignosisID & " and ICDCode = '" & ICDCode.ToSafeSQLString() & "'")
                End If
                If Reader Is Nothing Then Return ret
                Reader.Read()
                If Reader("C") > 0 Then
                    FpSpread.ActiveSheet.SetActiveCell(r, 1)
                    FpSpread.ShowActiveCell(0, 0)
                    FpSpread.Focus()
                    Application.DoEvents()
                    If MsgBox("Attention!" & vbCrLf & "The ICDCode " & ICDCode & " is already exist." & vbCrLf & vbCrLf &
                              "Do you want to continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        FpSpread.EditMode = True
                        FpSpread.Focus()
                        Reader.Close()
                        Reader.Dispose()
                        Return ret
                    End If
                End If
                Reader.Close()
                Reader.Dispose()

                If DignosisID = -1 Then
                    Reader =
                        gSQLGetDataReader(
                            "Select count(*) as C from Diagnosis Where ICDGroup = '" & ICDGroup.ToSafeSQLString() &
                            "' and ICDDescription = '" & ICDDescription.ToSafeSQLString() & "'")
                Else
                    Reader =
                        gSQLGetDataReader(
                            "Select count(*) as C from Diagnosis Where ICDGroup = '" & ICDGroup.ToSafeSQLString() &
                            "' and DignosisID <> " & DignosisID & " and ICDDescription = '" & ICDDescription.ToSafeSQLString() & "'")
                End If
                If Reader Is Nothing Then Return ret
                Reader.Read()
                If Reader("C") > 0 Then
                    FpSpread.ActiveSheet.SetActiveCell(r, 2)
                    FpSpread.ShowActiveCell(0, 0)
                    FpSpread.Focus()
                    Application.DoEvents()
                    MsgBox("Unable to update. Duplicate ICDDescription.", MsgBoxStyle.Exclamation)
                    FpSpread.EditMode = True
                    FpSpread.Focus()
                    Reader.Close()
                    Reader.Dispose()
                    Return ret
                End If

            End If

            If FpSpread.ActiveSheet.Rows(r).Tag.ToString() = "1" Or FpSpread.ActiveSheet.Rows(r).Tag.ToString() = "" Then
                If FpSpread.ActiveSheet.Cells(r, 0).Tag Is Nothing Then
                    ret.a = ret.a + 1
                Else
                    ret.u = ret.u + 1
                End If

            End If
            If FpSpread.ActiveSheet.Rows(r).Tag.ToString() = "2" Then
                ret.d = ret.d + 1
            End If
        Next
        If ret.u = 0 And ret.d = 0 And ret.a = 0 Then
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
        SaveFileDialog1.FileName = "Diagnoses as of " & Now.ToString("MM-dd-yyyy") & ".xls"
        If SaveFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            FpSpread.SaveExcel(SaveFileDialog1.FileName, IncludeHeaders.ColumnHeadersCustomOnly)
            Process.Start(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged
        TextBoxSearch.BackColor = Color.White
        For r = 0 To FpSpread.ActiveSheet.RowCount - 1
            If FpSpread.ActiveSheet.Cells(r, 0).Text.ToUpper() Like TextBoxSearch.Text.ToUpper() & "*" Or FpSpread.ActiveSheet.Cells(r, 2).Text.ToUpper() Like TextBoxSearch.Text.ToUpper() & "*" Then
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

End Class