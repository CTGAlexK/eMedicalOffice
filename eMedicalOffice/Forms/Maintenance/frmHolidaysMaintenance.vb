Imports System.Reflection
Imports log4net

Public Class frmHolidaysMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode

    Private Sub frmInjuryTypesMaintenance_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Load_Data()
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

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Reader = gSQLGetDataReader("Select OffName, ID, OffDate, Description, ActiveInd from HolidaysOffDays Order by OffDate")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("OffName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
            LI.SubItems.Add(FormatDateTime(Reader("OffDate").ToString, DateFormat.ShortDate))
            LI.ToolTipText = "" & Reader("Description").ToString
            LI.Tag = "" & Reader("ID").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
            ListView1_SelectedIndexChanged(Nothing, Nothing)
            cmdEdit.Enabled = True
            cmdDelete.Enabled = True
        End If
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        cmdEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim ID As Long
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Clear_Controls()
        cmdEdit.Enabled = True
        cmdDelete.Enabled = True
        ID = CLng(ListView1.SelectedItems(0).Tag)
        SaveSelectedItem = ListView1.SelectedItems(0)
        txtName.Text = SaveSelectedItem.Text
        txtDescription.Text = SaveSelectedItem.ToolTipText
        DateTimePicker1.Value = SaveSelectedItem.SubItems(1).Text
        CheckBoxActiveInd.Checked = CBool(SaveSelectedItem.ImageIndex)
        Cursor = Cursors.Default
    End Sub

    Private Sub Clear_Controls()
        gLoop_Clear_Controls(Me, TextBoxSearch)
    End Sub

    Private Sub Enable_Controls(ByVal En As Boolean)
        gLoop_Enable_Controls(Me, En)
        TextBoxSearch.Enabled = Not En
        ListView1.Enabled = Not En
        cmdAddNew.Enabled = Not En
        cmdUpdate.Enabled = En
        cmdCancel.Enabled = En
        DateTimePicker1.Enabled = En

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

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        Clear_Controls()
        CheckBoxActiveInd.Checked = True
        DateTimePicker1.Focus()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
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
        DateTimePicker1.Focus()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ID As Long
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Try
            If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
            End If
            gLoop_Trim_Controls(Me)
            If txtName.Text = "" Then
                ErrorProvider1.SetError(txtName, "Unable to process update. The Holiday Name is required is required.")
                MsgBox("Unable to process update. The Holiday Name is required.", MsgBoxStyle.Exclamation)
                txtName.Focus()
                Exit Sub
            End If

            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
                Reader = gSQLGetDataReader("Select * from HolidaysOffDays Where ID<>" & ID & " and OffName='" & txtName.Text.ToSafeSQLString() & "'")
            Else
                ID = -1
                Reader = gSQLGetDataReader("Select * from HolidaysOffDays Where OffName='" & txtName.Text.ToSafeSQLString() & "'")
            End If
            If Reader.Read() = True Then
                ErrorProvider1.SetError(txtName, "Unable to process update. The Holiday Name is already exist.")
                MsgBox("Unable to process update. The Holiday Name is already exist.", MsgBoxStyle.Exclamation)
                txtName.Focus()
                txtName.SelectAll()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()
            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
                Reader = gSQLGetDataReader("Select * from HolidaysOffDays Where ID<>" & ID & " AND DATEDIFF(d,  OffDate, '" & FormatDateTime(DateTimePicker1.Value, DateFormat.ShortDate) & "')=0")
            Else
                ID = -1
                Reader = gSQLGetDataReader("Select * from HolidaysOffDays Where DATEDIFF(d,  OffDate, '" & FormatDateTime(DateTimePicker1.Value, DateFormat.ShortDate) & "')=0")
            End If
            If Reader.Read() = True Then
                ErrorProvider1.SetError(DateTimePicker1, "Unable to process update. The Holiday Date is already exist.")
                MsgBox("Unable to process update. The Holiday Date is already exist.", MsgBoxStyle.Exclamation)
                DateTimePicker1.Focus()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()

            Dim TA As New SqlClient.SqlDataAdapter("Select * from HolidaysOffDays Where ID = " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("HolidaysOffDays")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If

            TR("OffName") = txtName.Text
            TR("Description") = StrConv(txtDescription.Text, VbStrConv.ProperCase)
            TR("OffDate") = FormatDateTime(DateTimePicker1.Value, DateFormat.ShortDate)
            TR("ActiveInd") = IIf(CheckBoxActiveInd.Checked, 1, 0)
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

                Reader = gSQLGetDataReader("Select * from HolidaysOffDays Where ID = IDENT_CURRENT('HolidaysOffDays')")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListView1.Items.Add(Reader("OffName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                    LI.SubItems.Add(FormatDateTime(Reader("OffDate").ToString, DateFormat.ShortDate))
                    LI.Tag = "" & Reader("ID").ToString
                    LI.ToolTipText = "" & Reader("Description").ToString
                    If ListView1.SelectedItems.Count > 0 Then ListView1.SelectedItems(0).Selected = False
                    LI.Selected = True
                    LI.EnsureVisible()
                    ListView1_SelectedIndexChanged(Nothing, Nothing)
                    ID = CLng(Val(Reader("ID").ToString))
                    SaveSelectedItem = LI
                Loop
                Reader.Close() : Reader.Dispose()
            Else
                SaveSelectedItem.Text = txtName.Text
                SaveSelectedItem.ToolTipText = txtDescription.Text
                SaveSelectedItem.SubItems(1).Text = FormatDateTime(DateTimePicker1.Value, DateFormat.ShortDate)
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
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim ID As Long
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete. No Record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to delete the Record for " & ListView1.SelectedItems(0).Text & "?" & vbCrLf & vbCrLf & "It is highly recommended to use the Active Indicator to disable Off Day.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ID = CLng(ListView1.SelectedItems(0).Tag)
        If gSQLDeleteRecord("DELETE FROM HolidaysOffDays WHERE ID=" & ID) Then
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

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()

    End Sub

    Private Sub txtInjuryDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged
        ErrorProvider1.SetError(txtDescription, "")
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        gSearchListView(ListView1, TextBoxSearch)
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        ErrorProvider1.SetError(txtName, "")
    End Sub

End Class