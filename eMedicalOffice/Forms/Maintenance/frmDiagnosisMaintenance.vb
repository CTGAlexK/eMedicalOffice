Imports System.Reflection
Imports log4net

Public Class frmDiagnosisMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode
    Public CalledListBox As ListView
    Private listOfProcedures As New List(Of Integer)
    Private copyOfProcedures As String

    Private Sub frmDiagnosisMaintenance_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        Application.DoEvents()

        Cursor = Cursors.Default
        Application.DoEvents()
        gSetup_GotFocus(Me)
    End Sub

    Private Sub frmAdjusterMaintenance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cmdUpdate.Enabled Then
            If MsgBox("You have unsaved data. Discard changes?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Load_Diagnosis()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Try
            Reader = gSQLGetDataReader("SELECT * FROM Diagnosis Order By ICDCode")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                LI = ListView1.Items.Add(Reader("ICDCode").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                LI.SubItems.Add(Reader("ICDDescription").ToString)
                LI.ToolTipText = "" & Reader("ICDDescription").ToString
                LI.Tag = "" & Reader("DignosisID").ToString
            Loop
            Reader.Close() : Reader.Dispose()
            If ListView1.Items.Count > 0 Then
                ListView1.Items(0).Selected = True
                ListView1.Items(0).EnsureVisible()
                ListView1.Items(0).Focused = True
                ListView1_SelectedIndexChanged(Nothing, Nothing)
                cmdEdit.Enabled = True
                cmdDelete.Enabled = True
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim lAutocomplete As New AutoCompleteStringCollection()
        Dim lAutocomplete1 As New AutoCompleteStringCollection()
        Try
            ComboBoxGroups.Items.Clear()
            'ComboBoxGroups.Items.Add("")
            Reader = gSQLGetDataReader("SELECT  DISTINCT   ICDGroup FROM Diagnosis Where (ICDGroup IS NOT NULL) and ICDGroup <> '' ORDER BY ICDGroup")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                lAutocomplete.Add(Reader("ICDGroup").ToString)
                ComboBoxGroups.Items.Add(Reader("ICDGroup").ToString)
            Loop
            Reader.Close() : Reader.Dispose()
            Reader = gSQLGetDataReader("SELECT  DISTINCT   ICDDescription FROM Diagnosis Where (ICDDescription IS NOT NULL) and ICDDescription <> '' ORDER BY ICDDescription")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                lAutocomplete1.Add(Reader("ICDDescription").ToString)
            Loop
            Reader.Close() : Reader.Dispose()
            ComboBoxGroups.AutoCompleteCustomSource = lAutocomplete
            'txtICDGroup.AutoCompleteCustomSource = lAutocomplete
            txtICDDescription.AutoCompleteCustomSource = lAutocomplete1
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        cmdEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim ID As Long
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        gHighlightListviewItem(ListView1, False, False, Color.FromKnownColor(KnownColor.Highlight), Color.FromKnownColor(KnownColor.HighlightText))
        Clear_Controls()
        Try
            cmdEdit.Enabled = True
            cmdDelete.Enabled = True
            ID = CLng(ListView1.SelectedItems(0).Tag)
            SaveSelectedItem = ListView1.SelectedItems(0)
            SQL = "SELECT     ICDCode, ICDDescription, ICDGroup, ActiveInd FROM Diagnosis WHERE DignosisID = " & ID
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            If Reader.HasRows Then
                Reader.Read()
                txtICDCode.Text = Reader("ICDCode")
                txtICDDescription.Text = Reader("ICDDescription")
                ComboBoxGroups.Text = Reader("ICDGroup")
                CheckBoxActiveInd.Checked = CBool(Reader("ActiveInd"))
            End If
            Load_Procedures(ID)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Public Sub Load_Procedures(Optional ByVal ID As Long = -1)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim Checked As Boolean
        CheckedListBoxProcedures.Items.Clear()
        Try
            SQL = " SELECT     Procedures.ProcID, Procedures.ProcName, (select DignosisID  from ProcedureDiagnosis where ProcedureDiagnosis.ProcID = Procedures.ProcID and ProcedureDiagnosis.DignosisID  =" & ID & ") as DignosisID "
            SQL &= " FROM         Procedures INNER JOIN Diagnostics ON Procedures.DiagID = Diagnostics.DiagID WHERE Diagnostics.OfficeID = " & gOfficeID & " and (Procedures.ProcedureTypeID=3 or Procedures.ProcedureTypeID=4 or Procedures.ProcedureTypeID=1) "
            SQL &= " ORDER BY DignosisID DESC, Procedures.ProcName  "

            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                If IsNumeric(Reader("DignosisID").ToString) Then
                    If CLng(Reader("DignosisID").ToString) = CLng(ID) Then
                        Checked = True
                    Else
                        Checked = False
                    End If
                Else
                    Checked = False
                End If
                CheckedListBoxProcedures.Items.Add(New ValueDescription(Reader("ProcID").ToString, Reader("ProcName").ToString), Checked)
            Loop
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
    End Sub

    Private Sub Clear_Controls()
        gLoop_Clear_Controls(Me, TextBoxSearch)
    End Sub

    Private Sub Enable_Controls(ByVal En As Boolean)
        gLoop_Enable_Controls(Me, En)
        ComboBoxGroups.Enabled = En
        TextBoxSearch.Enabled = Not En
        ListView1.Enabled = Not En
        ButtonBatchProcess.Enabled = Not En
        cmdAddNew.Enabled = Not En
        cmdUpdate.Enabled = En
        cmdCancel.Enabled = En
        cmdDuplicate.Enabled = Not En
        ButtonConvert.Enabled = Not En
        CheckedListBoxProcedures.Enabled = En
        If En = False Then
            If ListView1.Items.Count > 0 Then
                cmdEdit.Enabled = True
                cmdDelete.Enabled = True
            Else
                cmdEdit.Enabled = False
                cmdDelete.Enabled = False
            End If
        Else
            cmdEdit.Enabled = False
            cmdDelete.Enabled = False
        End If

    End Sub

    Public Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        Clear_Controls()
        ComboBoxGroups.Text = ""
        ComboBoxGroups.SelectedIndex = -1
        CheckBoxActiveInd.Checked = True
        txtICDCode.Focus()
        Load_Procedures()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If Not CalledListBox Is Nothing Then
            cmdUpdate.Enabled = False
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
            Exit Sub
        End If
        OpMode = AddEditMode.None
        Enable_Controls(False)
        If Not SaveSelectedItem Is Nothing Then
            ListView1_SelectedIndexChanged(Nothing, Nothing)
        Else
            If ListView1.Items.Count > 0 Then
                ListView1.Items(0).Selected = True
                ListView1.Items(0).EnsureVisible()
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            End If
        End If
        gLoop_ResetErrors_Controls(ErrorProvider1, Me)
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        OpMode = AddEditMode.Edit
        Enable_Controls(True)
        txtICDCode.Focus()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim Reader As SqlClient.SqlDataReader
        Dim ID As Long
        Dim LI As ListViewItem
        Dim I As Integer
        Try
            gLoop_Trim_Controls(Me)
            If txtICDCode.Text = "" Then
                ErrorProvider1.SetError(txtICDCode, "The ICDCode is required.")
                MsgBox("Unable to update. The ICDCode is required.", MsgBoxStyle.Exclamation)
                txtICDCode.Focus()
                Exit Sub
            End If
            'If IsNumeric(txtICDCode.Text) = False Then
            '    ErrorProvider1.SetError(txtICDCode, "Invalid ICDCode.")
            '    MsgBox("Unable to update. Invalid ICDCode. The ICDCode should be numeric value.", MsgBoxStyle.Exclamation)
            '    txtICDCode.Focus()
            '    Exit Sub
            'End If

            If OpMode = AddEditMode.AddNew Then
                ID = -1
                Reader = gSQLGetDataReader("Select count(*) as C from Diagnosis Where ICDCode = '" & txtICDCode.Text.ToSafeSQLString() & "'")
            Else
                If ListView1.SelectedItems.Count = 0 Then Exit Sub
                ID = ListView1.SelectedItems(0).Tag
                Reader = gSQLGetDataReader("Select count(*) as C from Diagnosis Where DignosisID <> " & ID & " and ICDCode = '" & txtICDCode.Text.ToSafeSQLString() & "'")
            End If
            If Reader Is Nothing Then Exit Sub
            Reader.Read()
            If Reader("C") > 0 Then
                If MsgBox("Attention!" & vbCrLf & "The ICDCode " & txtICDCode.Text & " is already exist." & vbCrLf & vbCrLf & "Do you want to continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    ErrorProvider1.SetError(txtICDCode, "Duplicate ICDCode.")
                    txtICDCode.Focus()
                    Reader.Close() : Reader.Dispose()
                    Exit Sub
                End If
            End If
            Reader.Close() : Reader.Dispose()

            If ComboBoxGroups.Text = "" Then
                ComboBoxGroups.Text = "Ungrouped"
                'ErrorProvider1.SetError(txtICDGroup, "The ICDGroup is required.")
                'MsgBox("Unable to update. The ICDGroup is required.", MsgBoxStyle.Exclamation)
                'txtICDGroup.Focus()
                'Exit Sub
            End If
            If txtICDDescription.Text = "" Then
                ErrorProvider1.SetError(txtICDDescription, "The ICDDescription is required.")
                MsgBox("Unable to update. The ICDDescription is required.", MsgBoxStyle.Exclamation)
                txtICDDescription.Focus()
                Exit Sub
            End If
            If ComboBoxGroups.Text = "" Then
                ErrorProvider1.SetError(ComboBoxGroups, "The ICDGroup is required.")
                MsgBox("Unable to update. The ICDGroup is required.", MsgBoxStyle.Exclamation)
                ComboBoxGroups.Focus()
                Exit Sub
            End If

            If CheckedListBoxProcedures.CheckedItems.Count = 0 Then
                If MsgBox("You have not assigned this Diagnose to any procedure(s)." & vbCrLf & "Do you want to continue without procedure(s) assignment?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    ErrorProvider1.SetError(CheckedListBoxProcedures, "No Procedure selected.")
                    CheckedListBoxProcedures.Focus()
                    Exit Sub
                End If
            End If
            If OpMode = AddEditMode.AddNew Then
                Reader = gSQLGetDataReader("Select count(*) as C from Diagnosis Where ICDGroup = '" & ComboBoxGroups.Text.ToSafeSQLString() & "' and ICDDescription = '" & txtICDDescription.Text.ToSafeSQLString() & "'")
            Else
                Reader = gSQLGetDataReader("Select count(*) as C from Diagnosis Where ICDGroup = '" & ComboBoxGroups.Text.ToSafeSQLString() & "' and DignosisID <> " & ID & " and ICDDescription = '" & txtICDDescription.Text.ToSafeSQLString() & "'")
            End If
            If Reader Is Nothing Then Exit Sub
            Reader.Read()
            If Reader("C") > 0 Then
                ErrorProvider1.SetError(txtICDDescription, "Duplicate ICDDescription.")
                MsgBox("Unable to update. Duplicate ICDDescription.", MsgBoxStyle.Exclamation)
                txtICDDescription.Focus()
                Reader.Close() : Reader.Dispose()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()

            Dim TA As New SqlClient.SqlDataAdapter("Select * from Diagnosis Where DignosisID  = " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("Diagnosis")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("ICDCode") = txtICDCode.Text
            TR("ICDGroup") = ComboBoxGroups.Text
            TR("ICDDescription") = txtICDDescription.Text
            TR("ActiveInd") = IIf(CheckBoxActiveInd.Checked, 1, 0)
            TR("ChangedBy") = gCurrentEmployee.EmpID
            TR("ChangedDT") = Now.ToString("MM/dd/yyyy")

            If OpMode = AddEditMode.AddNew Then
                dTab.Rows.Add(TR)
            End If
            TA.UpdateCommand = CB.GetUpdateCommand(True)
            Try
                TA.Update(dTab)
                dTab.AcceptChanges()
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
                Exit Sub
            End Try
            dTab.Dispose()
            CB.Dispose()
            TA.Dispose()

            If OpMode = AddEditMode.AddNew Then
                ID = gSQLGetSingleValue("Select IDENT_CURRENT('Diagnosis')")
                Reader = gSQLGetDataReader("Select * from Diagnosis Where DignosisID = " & ID)
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListView1.Items.Add(Reader("ICDCode").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                    LI.Tag = "" & Reader("DignosisID").ToString
                    LI.SubItems.Add(Reader("ICDDescription").ToString)
                    LI.ToolTipText = "" & Reader("ICDDescription").ToString
                    If ListView1.SelectedItems.Count > 0 Then ListView1.SelectedItems(0).Selected = False
                    ID = CLng(Val(Reader("DignosisID").ToString))
                    SaveSelectedItem = LI
                    If Not CalledListBox Is Nothing Then   ' If called from the billing form
                        LI = CalledListBox.Items.Add(Reader("ICDCode").ToString)
                        LI.SubItems.Add(Reader("ICDDescription").ToString)
                        LI.SubItems.Add(Reader("ICDGroup").ToString)
                        LI.Tag = Reader("DignosisID").ToString
                        LI.ToolTipText = Reader("ICDDescription").ToString
                        LI.Selected = True
                        LI.EnsureVisible()
                    End If
                Loop
                Reader.Close() : Reader.Dispose()
            Else
                SaveSelectedItem.Text = txtICDCode.Text
                SaveSelectedItem.SubItems(1).Text = txtICDDescription.Text
                SaveSelectedItem.ToolTipText = txtICDDescription.Text
            End If
            gSQLUpdateData("Delete From ProcedureDiagnosis where DignosisID=" & ID)
            If CheckedListBoxProcedures.CheckedItems.Count > 0 Then
                For I = 0 To CheckedListBoxProcedures.Items.Count - 1
                    If CheckedListBoxProcedures.GetItemChecked(I) Then
                        gSQLUpdateData("INSERT INTO ProcedureDiagnosis (DignosisID, ProcID,ChangedBy, ChangedDT) VALUES(" & ID & ", " & CheckedListBoxProcedures.Items(I).value & ", " & gCurrentEmployee.EmpID & ", '" & Now.ToString("MM/dd/yyyy") & "')")
                    End If
                Next
            End If
            If Not LI Is Nothing Then
                LI.Selected = True
                LI.EnsureVisible()
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            End If

            If Not CalledListBox Is Nothing Then
                cmdUpdate.Enabled = False
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
                Exit Sub
            End If
            If CheckBoxActiveInd.Checked = True Then
                ListView1.SelectedItems(0).ImageIndex = 1
            Else
                ListView1.SelectedItems(0).ImageIndex = 0
            End If

            OpMode = AddEditMode.None
            Enable_Controls(False)
            gLoop_ResetErrors_Controls(ErrorProvider1, Me)
            If ListView1.SelectedItems.Count > 0 Then
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            End If
            Load_Data()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim ID As Long
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete. No Procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to delete the Injury Type " & ListView1.SelectedItems(0).Text & "?" & vbCrLf & vbCrLf & "It is highly recommended to use the Active Indicator to disable Employee.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Try
            ID = CLng(ListView1.SelectedItems(0).Tag)
            If gSQLDeleteRecord("DELETE FROM InjuryTypes WHERE InjuryID=" & ID) Then
                ListView1.Items.Remove(ListView1.SelectedItems(0))
                SaveSelectedItem = Nothing
                If ListView1.SelectedItems.Count > 0 Then
                    ListView1_SelectedIndexChanged(Nothing, Nothing)
                Else
                    Clear_Controls()
                    cmdEdit.Enabled = False
                    cmdDelete.Enabled = False
                End If
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()

    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        gSearchListView(ListView1, TextBoxSearch, False, 1)
    End Sub

    Private Sub txtICDCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtICDCode.TextChanged
        ErrorProvider1.SetError(txtICDCode, "")
    End Sub

    Private Sub txtICDGroup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ErrorProvider1.SetError(ComboBoxGroups, "")
    End Sub

    Private Sub txtICDDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtICDDescription.TextChanged
        ErrorProvider1.SetError(txtICDDescription, "")
    End Sub

    Private Sub CheckedListBoxProcedures_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles CheckedListBoxProcedures.ItemCheck
        ErrorProvider1.SetError(CheckedListBoxProcedures, "")
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Load_Data()
        Load_Diagnosis()
        Cursor = Cursors.Default
    End Sub

    Private Sub PanelDiagnoses_Paint(sender As Object, e As PaintEventArgs) Handles PanelDiagnoses.Paint

    End Sub

    Private Sub ButtonBatchProcess_Click(sender As Object, e As EventArgs) Handles ButtonBatchProcess.Click
        Dim ret As DialogResult = frmDiagnosisBatch.ShowDialog(Me)
        If ret = DialogResult.OK Then
            TextBoxSearch.Text = ""
            Load_Data()
            Load_Diagnosis()
        End If

    End Sub

    Private Sub ComboBoxGroups_KeyUp(sender As Object, e As KeyEventArgs) Handles ComboBoxGroups.KeyUp
        sSearchComboBox_KeyUp(ComboBoxGroups, e, False)
    End Sub

    Private Sub CopyCheckedProceduresToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ContextMenuStripCopyProcedures_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripCopyProcedures.Opening
        If listOfProcedures.Count = 0 Then
            e.Cancel = True
            Return
        End If
        If copyOfProcedures.Trim.Length > 0 Then
            PastCheckedProceduresToolStripMenuItem.Text = "Check Procedures as copied from ICD Code: " & copyOfProcedures
        Else
            PastCheckedProceduresToolStripMenuItem.Text = "Check Copied Procedures"
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If CheckedListBoxProcedures.CheckedItems.Count > 0 Then
            listOfProcedures.Clear()
            Dim i As Integer
            copyOfProcedures = txtICDCode.Text
            For Each item In CheckedListBoxProcedures.CheckedItems
                listOfProcedures.Add(CheckedListBoxProcedures.Items.IndexOf(item))
            Next
        Else
            MsgBox("No procedures checked.", MsgBoxStyle.Exclamation, "Oops...")
        End If
    End Sub

    Private Sub PastCheckedProceduresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PastCheckedProceduresToolStripMenuItem.Click
        If listOfProcedures.Count = 0 Then Exit Sub
        If MsgBox("This action will overwrite the currently selected procedures." & vbCrLf & "Continue?", vbYesNo + MsgBoxStyle.Exclamation, "Confirm") = MsgBoxResult.No Then
            Return
        End If
        For i As Integer = 0 To CheckedListBoxProcedures.Items.Count - 1
            CheckedListBoxProcedures.SetItemChecked(i, False)
        Next
        For Each item As Integer In listOfProcedures
            CheckedListBoxProcedures.SetItemChecked(item, True)
        Next
    End Sub

    Private Sub ContextMenuStripDuplicateDiagnose_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripDuplicateDiagnose.Opening
        If ListView1.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        CheckBoxActiveInd.Checked = True
        txtICDCode.Focus()
        txtICDCode.SelectAll()
    End Sub

    Private Sub cmdDuplicate_Click(sender As Object, e As EventArgs) Handles cmdDuplicate.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to  process duplicate. No diagnose selected.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
            Return
        End If
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        CheckBoxActiveInd.Checked = True
        txtICDCode.Focus()
        txtICDCode.SelectAll()
    End Sub

    Private Sub ButtonConvert_Click(sender As Object, e As EventArgs) Handles ButtonConvert.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to  process duplicate. No diagnose selected.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
            Return
        End If
        Dim SaveDiagnosisID As Long
        Dim SaveCode As String
        Dim frm As FrmDiagnosisMaintenanceConvert = New FrmDiagnosisMaintenanceConvert()
        frm.txtICDCode.Text = txtICDCode.Text
        frm.txtICDDescription.Text = txtICDDescription.Text
        SaveCode = txtICDCode.Text
        SaveDiagnosisID = CInt(ListView1.SelectedItems(0).Tag)
        frm.txtICDCode.Tag = SaveDiagnosisID
        frm.ComboBoxGroups.Text = ComboBoxGroups.Text
        frm.callerForm = Me
        For i As Integer = 0 To CheckedListBoxProcedures.Items.Count - 1
            frm.CheckedListBoxProcedures.Items.Add(CheckedListBoxProcedures.Items(i))
            frm.CheckedListBoxProcedures.SetItemChecked(i, CheckedListBoxProcedures.GetItemChecked(i))
        Next
        frm.WebBrowser1.NavigateURL("http://www.icd10data.com/Convert/" & SaveCode)
        frm.GetICD10Codes(SaveCode)
        frm.Size = Me.Size
        frm.Location = Me.Location
        frm.Timer1.Enabled = True
        If frm.ShowDialog(Me) = DialogResult.OK Then
            LockWindowUpdate(Me.Handle)
            Load_Diagnosis()
            For Each item As ListViewItem In ListView1.Items
                If (CInt(item.Tag) = SaveDiagnosisID) Then
                    item.Selected = True
                    item.EnsureVisible()
                    ListView1_SelectedIndexChanged(Nothing, Nothing)
                    ListView1.Focus()
                End If
            Next
            LockWindowUpdate(0)
        End If
        frm.Dispose()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

End Class