Imports System.Reflection
Imports log4net

Public Class frmInjuryTypesMaintenance
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
        Load_Injuries()
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

    Private Sub Load_Injuries()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Reader = gSQLGetDataReader("Select InjuryID, InjuryName, Description, ActiveInd from InjuryTypes Order by InjuryID")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("InjuryName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
            LI.ToolTipText = "" & Reader("Description").ToString
            LI.Tag = "" & Reader("InjuryID").ToString
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

    Private Sub Load_Data()

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
        txtInjuryName.Text = SaveSelectedItem.Text
        txtInjuryDescription.Text = SaveSelectedItem.ToolTipText
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
        txtInjuryName.Focus()
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
        txtInjuryName.Focus()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ID As Long
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader

        gLoop_Trim_Controls(Me)
        gLoop_Text_PropperCase(Me)
        Try
            If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
            End If
            gLoop_Trim_Controls(Me)
            If txtInjuryName.Text = "" Then
                ErrorProvider1.SetError(txtInjuryName, "Unable to process update. The Injury Type Name is required.")
                MsgBox("Unable to process update. The Injury Type Name is required.", MsgBoxStyle.Exclamation)
                txtInjuryName.Focus()
                Exit Sub
            End If

            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
                Reader = gSQLGetDataReader("Select * from InjuryTypes Where InjuryID<>" & ID & " and InjuryName='" & txtInjuryName.Text.ToSafeSQLString() & "'")
            Else
                ID = -1
                Reader = gSQLGetDataReader("Select * from InjuryTypes Where InjuryName='" & txtInjuryName.Text.ToSafeSQLString() & "'")
            End If
            If Reader.Read() = True Then
                ErrorProvider1.SetError(txtInjuryName, "Unable to process update. The Injury Type Name is already exist.")
                MsgBox("Unable to process update. The Injury Type Name is already exist.", MsgBoxStyle.Exclamation)
                txtInjuryName.Focus()
                txtInjuryName.SelectAll()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()

            Dim TA As New SqlClient.SqlDataAdapter("Select * from InjuryTypes Where InjuryID = " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("InjuryTypes")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("InjuryName") = txtInjuryName.Text
            TR("Description") = txtInjuryDescription.Text
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

                Reader = gSQLGetDataReader("Select * from InjuryTypes Where InjuryID = IDENT_CURRENT('InjuryTypes')")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListView1.Items.Add(Reader("InjuryName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                    LI.Tag = "" & Reader("InjuryID").ToString
                    LI.ToolTipText = "" & Reader("Description").ToString
                    If ListView1.SelectedItems.Count > 0 Then ListView1.SelectedItems(0).Selected = False
                    LI.Selected = True
                    LI.EnsureVisible()
                    ListView1_SelectedIndexChanged(Nothing, Nothing)
                    ID = CLng(Val(Reader("InjuryID").ToString))
                    SaveSelectedItem = LI
                Loop
                Reader.Close() : Reader.Dispose()
            Else
                SaveSelectedItem.Text = txtInjuryName.Text
                SaveSelectedItem.ToolTipText = txtInjuryName.Text
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
            MsgBox("Unable to delete. No Procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to delete the Injury Type " & ListView1.SelectedItems(0).Text & "?" & vbCrLf & vbCrLf & "It is highly recommended to use the Active Indicator to disable Employee.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
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

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()

    End Sub

    Private Sub txtInjuryName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInjuryName.TextChanged
        ErrorProvider1.SetError(txtInjuryName, "")
    End Sub

    Private Sub txtInjuryDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInjuryDescription.TextChanged
        ErrorProvider1.SetError(txtInjuryDescription, "")
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        gSearchListView(ListView1, TextBoxSearch)
    End Sub

End Class