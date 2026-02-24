Imports System.Reflection
Imports log4net

Public Class frmDocumentsMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode

    Private Sub frmDocumentsMaintenance_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmEmployeeMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        gSetup_GotFocus(Me)
        Application.DoEvents()
        Load_Data()
        Load_Documents()
        Cursor = Cursors.Default
        Application.DoEvents()
        Enable_Controls(False)
    End Sub

    Private Sub frmAdjusterMaintenance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cmdUpdate.Enabled Then
            If MsgBox("You have unsaved data. Discard changes?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Load_Documents()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Try
            Reader = gSQLGetDataReader("Select ProfileID, DocumentName, ActiveInd from DocumentProfiles Order by DocumentName")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                LI = ListView1.Items.Add(Reader("DocumentName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                LI.Tag = "" & Reader("ProfileID").ToString
            Loop
            Reader.Close() : Reader.Dispose()
            If ListView1.Items.Count > 0 Then
                ListView1.Items(0).Selected = True
                ListView1.Items(0).EnsureVisible()
                ListView1_SelectedIndexChanged(Nothing, Nothing)
                cmdEdit.Enabled = True
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Try
            ComboBoxDocColor.Items.Add(New ValueDescription(0, "B/W"))
            ComboBoxDocColor.Items.Add(New ValueDescription(1, "Gray Scale"))
            ComboBoxDocColor.Items.Add(New ValueDescription(2, "Color Photo"))
            ComboBoxDocResolution.Items.Add(New ValueDescription(75, "75 Dpi"))
            ComboBoxDocResolution.Items.Add(New ValueDescription(100, "100 Dpi"))
            ComboBoxDocResolution.Items.Add(New ValueDescription(150, "150 Dpi"))
            ComboBoxDocResolution.Items.Add(New ValueDescription(200, "200 Dpi"))
            ComboBoxDocResolution.Items.Add(New ValueDescription(300, "300 Dpi"))
            ComboBoxDocResolution.Items.Add(New ValueDescription(600, "500 Dpi"))
            Dim I As Double
            For I = 1 To 100
                If I < 10 Then
                    ComboBoxJpegQuality.Items.Add(New ValueDescription(I, I & " Very Low"))
                ElseIf I < 25 Then
                    ComboBoxJpegQuality.Items.Add(New ValueDescription(I, I & " Low"))
                ElseIf I < 40 Then
                    ComboBoxJpegQuality.Items.Add(New ValueDescription(I, I & " Medium"))
                ElseIf I < 75 Then
                    ComboBoxJpegQuality.Items.Add(New ValueDescription(I, I & " High"))
                ElseIf I < 90 Then
                    ComboBoxJpegQuality.Items.Add(New ValueDescription(I, I & " Very High"))
                Else
                    ComboBoxJpegQuality.Items.Add(New ValueDescription(I, I & " Maximum"))
                End If
            Next

            For I = 0 To 5 Step 0.05
                ComboBoxTrimBorder.Items.Add(New ValueDescription(I, I.ToString("#0.00") & "  Inch"))
            Next
            For I = 0 To 250
                ComboBoxShowOrder.Items.Add(I)
            Next

            ComboBoxDocSize.Items.Add(New ValueDescription(3, "US Letter"))
            ComboBoxDocSize.Items.Add(New ValueDescription(4, "US Legal"))

            Reader = gSQLGetDataReader("SELECT     DiagID, DiagName  FROM Diagnostics WHERE OfficeID = " & gOfficeID & " ORDER BY DiagName")
            cboDiagID.Items.Add(New ValueDescription(0, "Not Assigned"))
            Do Until Reader.Read = False
                cboDiagID.Items.Add(New ValueDescription(Val(Reader("DiagID").ToString), Reader("DiagName").ToString))
            Loop
            cboDiagID.SelectedIndex = 0
            Dim LI As ListViewItem
            Reader = gSQLGetDataReader("SELECT PositionID , Description FROM Positions Where PositionID > 1 and PositionID < 100")
            Do Until Reader.Read = False
                LI = ListViewAccess.Items.Add("K" & Val(Reader("PositionID").ToString), Reader("Description").ToString, "USER")
                LI.Tag = Val(Reader("PositionID").ToString)
            Loop
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
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Clear_Controls()
        cmdEdit.Enabled = True
        Try
            ID = CLng(ListView1.SelectedItems(0).Tag)
            SaveSelectedItem = ListView1.SelectedItems(0)
            Reader = gSQLGetDataReader("Select * from DocumentProfiles Where ProfileID=" & ID)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                CheckBoxActiveInd.Checked = CBool(Val("" & Reader("ActiveInd").ToString))
                txtDocumentName.Text = "" & Reader("DocumentName").ToString
                txtComments.Text = "" & Reader("Comments").ToString

                gFindComboItemByValue(ComboBoxDocColor, CLng(Val(Reader("DocColor").ToString)), True)
                gFindComboItemByValue(ComboBoxDocResolution, CLng(Val(Reader("DocResolution").ToString)), True)
                gFindComboItemByValue(ComboBoxJpegQuality, CLng(Val(Reader("JpegQuality").ToString)), True)
                gFindComboItemByValue(ComboBoxDocSize, CLng(Val(Reader("DocSize").ToString)), True)
                gFindComboItemByValue(ComboBoxTrimBorder, Val(Reader("TrimBorder").ToString), True)
                ComboBoxShowOrder.SelectedIndex = Val(Reader("ShowOrder").ToString)
                CheckBox1.Checked = IIf(Val(Reader("NameEditableInd").ToString), True, False)
                gFindComboItemByValue(cboDiagID, CLng(Val(Reader("DiagID").ToString)), True)
                If cboDiagID.SelectedIndex = -1 Then cboDiagID.SelectedIndex = 0
                Try
                    If Val(Reader("SystemProfile").ToString) > 0 Then
                        lblSystem.Visible = True
                        CheckBoxActiveInd.Visible = False
                        CheckBoxActiveInd.Checked = True
                        txtDocumentName.ReadOnly = True
                    Else
                        lblSystem.Visible = False
                        CheckBoxActiveInd.Visible = True
                        txtDocumentName.ReadOnly = False
                    End If
                Catch ex As Exception
                    lblSystem.Visible = False
                    CheckBoxActiveInd.Visible = True
                End Try
            Loop
            Reader.Close()
            ClearAccess()
            Dim LI As ListViewItem
            Reader = gSQLGetDataReader("Select PositionID from DocumentProfileSecurityLevels where ProfileID=" & ID)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                If Not ListViewAccess.Items("K" & Reader("PositionID").ToString) Is Nothing Then
                    ListViewAccess.Items("K" & Reader("PositionID").ToString).Checked = True
                End If
            Loop
            Reader.Close()
            Reader.Dispose()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ClearAccess()
        Dim LI As ListViewItem
        For Each LI In ListViewAccess.Items
            LI.Checked = False
        Next
    End Sub

    Private Sub Clear_Controls()
        gLoop_Clear_Controls(Me)
        ClearAccess()
        ComboBoxDocColor.SelectedIndex = -1
        ComboBoxDocResolution.SelectedIndex = -1
        ComboBoxJpegQuality.SelectedIndex = -1
        ComboBoxShowOrder.SelectedIndex = 0
        ComboBoxDocSize.SelectedIndex = 0
    End Sub

    Private Sub Enable_Controls(ByVal En As Boolean)
        gLoop_Enable_Controls(Me, En)
        ListView1.Enabled = Not En
        cmdAddNew.Enabled = Not En
        cmdUpdate.Enabled = En
        cmdCancel.Enabled = En
        ListViewAccess.Enabled = En
        If En = False Then
            If ListView1.Items.Count > 0 Then
                cmdEdit.Enabled = True
            Else
                cmdEdit.Enabled = False
            End If
        Else
            cmdEdit.Enabled = False
        End If
        ComboBoxDocSize.Enabled = En
    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        Clear_Controls()
        lblSystem.Visible = False
        CheckBoxActiveInd.Visible = True
        txtDocumentName.ReadOnly = False
        CheckBoxActiveInd.Checked = True
        ComboBoxDocColor.SelectedIndex = 0
        ComboBoxDocResolution.SelectedIndex = 0
        ComboBoxJpegQuality.SelectedIndex = 1
        cboDiagID.SelectedIndex = 0
        txtDocumentName.Focus()
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

        If lblSystem.Visible Then
            CheckBoxActiveInd.Visible = False
            CheckBoxActiveInd.Checked = True
            txtDocumentName.ReadOnly = True
        Else
            CheckBoxActiveInd.Visible = True
            txtDocumentName.ReadOnly = False
        End If
        'If lblSystem.Visible = False Then
        '    txtDocumentName.Enabled = True
        '    txtDocumentName.Focus()
        'Else
        '    txtDocumentName.Enabled = False
        '    CheckBox1.Focus()
        'End If
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ID As Long
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Try
            If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
                Exit Sub
            End If
            gLoop_Trim_Controls(Me)
            If txtDocumentName.Text = "" Then
                ErrorProvider1.SetError(txtDocumentName, "Unable to process update. The Document Profile Name is required.")
                MsgBox("Unable to process update. The Document Profile Name is required.", MsgBoxStyle.Exclamation)
                txtDocumentName.Focus()
                Exit Sub
            End If
            If ComboBoxShowOrder.SelectedIndex = -1 Then
                ComboBoxShowOrder.SelectedIndex = 99
            End If
            If ComboBoxDocSize.SelectedIndex = -1 Then
                ErrorProvider1.SetError(ComboBoxDocSize, "Unable to process update. The Paper Size should be selected.")
                MsgBox("Unable to process update. The Paper Size should be selected.", MsgBoxStyle.Exclamation)
                ComboBoxDocSize.Focus()
                Exit Sub
            End If
            If ComboBoxTrimBorder.SelectedIndex = -1 Then
                ComboBoxTrimBorder.SelectedIndex = 0
            End If
            If ComboBoxDocColor.SelectedIndex = -1 Then
                ErrorProvider1.SetError(ComboBoxDocColor, "Unable to process update. The Documnet Color should be selected.")
                MsgBox("Unable to process update. The Documnet Color should be selected.", MsgBoxStyle.Exclamation)
                ComboBoxDocColor.Focus()
                Exit Sub
            End If
            If ComboBoxDocResolution.SelectedIndex = -1 Then
                ErrorProvider1.SetError(ComboBoxDocResolution, "Unable to process update. The Documnet Resolution should be selected.")
                MsgBox("Unable to process update. The Documnet Resolution should be selected.", MsgBoxStyle.Exclamation)
                ComboBoxDocResolution.Focus()
                Exit Sub
            End If
            If ComboBoxJpegQuality.SelectedIndex = -1 Then
                ErrorProvider1.SetError(ComboBoxDocResolution, "Unable to process update. The Documnet Jpeg Quality should be selected.")
                MsgBox("Unable to process update. The Documnet Jpeg Quality should be selected.", MsgBoxStyle.Exclamation)
                ComboBoxJpegQuality.Focus()
                Exit Sub
            End If
            If ListViewAccess.CheckedItems.Count = 0 Then
                If MsgBox("Attention." & vbCrLf & "You have not selected anybody to be able to access the documents of this profile." & vbCrLf & "The only Administrators will have access." & vbCrLf & vbCrLf & "Please confirm?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    ErrorProvider1.SetError(Label10, "Please select an access level.")
                    ListViewAccess.Focus()
                    Exit Sub
                End If
            End If

            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
                Reader = gSQLGetDataReader("Select * from DocumentProfiles Where ProfileID<>" & ID & " and DocumentName='" & txtDocumentName.Text.ToSafeSQLString() & "'")
            Else
                ID = -1
                Reader = gSQLGetDataReader("Select * from DocumentProfiles Where DocumentName='" & txtDocumentName.Text.ToSafeSQLString() & "'")
            End If
            If Reader.Read() = True Then
                ErrorProvider1.SetError(txtDocumentName, "Unable to process update. The Document Name is already exist.")
                MsgBox("Unable to process update. The Document Name is already exist.", MsgBoxStyle.Exclamation)
                txtDocumentName.Focus()
                txtDocumentName.SelectAll()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()

            Dim TA As New SqlClient.SqlDataAdapter("Select * from DocumentProfiles Where ProfileID = " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("DocumentProfiles")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("ActiveInd") = IIf(CheckBoxActiveInd.Checked, 1, 0)
            TR("DocumentName") = txtDocumentName.Text

            TR("DocColor") = CType(ComboBoxDocColor.SelectedItem, ValueDescription).Value
            TR("DocResolution") = CType(ComboBoxDocResolution.SelectedItem, ValueDescription).Value
            TR("JpegQuality") = CType(ComboBoxJpegQuality.SelectedItem, ValueDescription).Value
            TR("DocSize") = CType(ComboBoxDocSize.SelectedItem, ValueDescription).Value
            TR("TrimBorder") = CType(ComboBoxTrimBorder.SelectedItem, ValueDescription).Value
            TR("Comments") = txtComments.Text.Trim

            TR("ShowOrder") = ComboBoxShowOrder.SelectedIndex
            TR("NameEditableInd") = IIf(CheckBox1.Checked, 1, 0)
            TR("DiagID") = CType(cboDiagID.SelectedItem, ValueDescription).Value

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

                Reader = gSQLGetDataReader("Select * from DocumentProfiles Where ProfileID = IDENT_CURRENT('DocumentProfiles')")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListView1.Items.Add(Reader("DocumentName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                    LI.Tag = "" & Reader("ProfileID").ToString
                    If ListView1.SelectedItems.Count > 0 Then ListView1.SelectedItems(0).Selected = False
                    LI.Selected = True
                    LI.EnsureVisible()
                    ListView1_SelectedIndexChanged(Nothing, Nothing)
                    ID = CLng(Val(Reader("ProfileID").ToString))
                    SaveSelectedItem = LI
                Loop
                Reader.Close() : Reader.Dispose()
            Else
                SaveSelectedItem.Text = txtDocumentName.Text
            End If
            If CheckBoxActiveInd.Checked = True Then
                ListView1.SelectedItems(0).ImageIndex = 1
            Else
                ListView1.SelectedItems(0).ImageIndex = 0
            End If

            If OpMode = AddEditMode.Edit Then
                gSQLUpdateData("Delete from  DocumentProfileSecurityLevels Where ProfileID=" & ID)
            End If
            gSQLUpdateData("INSERT INTO DocumentProfileSecurityLevels (ProfileID, PositionID) VALUES(" & ID & ",1)")
            Dim ALI As ListViewItem
            For Each ALI In ListViewAccess.CheckedItems
                gSQLUpdateData("INSERT INTO DocumentProfileSecurityLevels (ProfileID, PositionID) VALUES(" & ID & "," & ALI.Tag & ")")
            Next
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

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ID As Long
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete. No Document Profile selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to delete the Document Profile " & ListView1.SelectedItems(0).Text & "?" & vbCrLf & vbCrLf & "It is highly recommended to use the Active Indicator to disable Employee.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Try
            ID = CLng(ListView1.SelectedItems(0).Tag)
            If gSQLDeleteRecord("DELETE FROM DocumentProfiles WHERE ProfileID=" & ID) Then
                ListView1.Items.Remove(ListView1.SelectedItems(0))
                SaveSelectedItem = Nothing
                If ListView1.SelectedItems.Count > 0 Then
                    ListView1_SelectedIndexChanged(Nothing, Nothing)
                Else
                    Clear_Controls()
                    cmdEdit.Enabled = False
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

    Private Sub txtDocumentName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDocumentName.TextChanged
        ErrorProvider1.SetError(txtDocumentName, "")
    End Sub

    Private Sub ComboBoxNumberOfVisits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDocColor.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxDocColor, "")
    End Sub

    Private Sub ComboBoxProcTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDocResolution.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxDocResolution, "")
    End Sub

    Private Sub ComboBoxJpegQuality_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxJpegQuality.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxJpegQuality, "")
    End Sub

    Private Sub ListViewAccess_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewAccess.ItemCheck
        ErrorProvider1.SetError(Label10, "")
    End Sub

    Private Sub ListViewAccess_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewAccess.SelectedIndexChanged

    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim LI As ListViewItem
        For Each LI In ListViewAccess.Items
            LI.Checked = True
        Next
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNoneToolStripMenuItem.Click
        Dim LI As ListViewItem
        For Each LI In ListViewAccess.Items
            LI.Checked = False
        Next
    End Sub

End Class