Imports System.Reflection
Imports log4net

Public Class frmBillingTemplates
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode
    Private DataUpdated As Boolean

    Private Sub frmInjuryTypesMaintenance_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Load_Data()
        Load_Templates()
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

    Private Sub Load_Templates()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Try
            Reader = gSQLGetDataReader("SELECT TemplateID, TemplateName  FROM BillingTemplates")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                LI = ListView1.Items.Add(Reader("TemplateName").ToString, 1)
                LI.ToolTipText = "" & Reader("TemplateName").ToString
                LI.Tag = "" & Reader("TemplateID").ToString
            Loop
            Reader.Close() : Reader.Dispose()
            If ListView1.Items.Count > 0 Then
                ListView1.Items(0).Selected = True
                ListView1.Items(0).EnsureVisible()
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
        txtTemplateName.Text = SaveSelectedItem.Text
        Load_Diagnosis(Val(ListView1.SelectedItems(0).Tag))
        Cursor = Cursors.Default
    End Sub

    Private Sub Load_Diagnosis(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        Dim ProcID As Long = 0
        ListViewDiagnosis.Items.Clear()
        If ListView1.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        SQL = "SELECT     BillingTemplateDiagnosis.ID, BillingTemplateDiagnosis.TemplateID, BillingTemplateDiagnosis.DignosisID, Diagnosis.ICDCode, Diagnosis.ICDDescription, Diagnosis.ICDGroup FROM BillingTemplateDiagnosis INNER JOIN Diagnosis ON BillingTemplateDiagnosis.DignosisID = Diagnosis.DignosisID "
        SQL &= " WHERE BillingTemplateDiagnosis.TemplateID  = " & ID
        SQL &= "ORDER BY ICDCode "

        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewDiagnosis.Items.Add("K" & Reader("DignosisID").ToString, Reader("ICDCode").ToString, "")
            LI.SubItems.Add(Reader("ICDDescription").ToString)
            LI.SubItems.Add(Reader("ICDGroup").ToString)
            LI.Tag = Reader("DignosisID").ToString
            LI.ToolTipText = Reader("ICDDescription").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewDiagnosis.Items.Count > 0 Then
            ListViewDiagnosis.Items(0).Selected = True
            ListViewDiagnosis.Items(0).EnsureVisible()
        End If
    End Sub

    Private Sub Clear_Controls()
        txtTemplateName.Text = ""
        ListViewDiagnosis.Items.Clear()
    End Sub

    Private Sub Enable_Controls(ByVal En As Boolean)
        gLoop_Enable_Controls(Me, En)
        ListView1.Enabled = Not En
        cmdAddNew.Enabled = Not En
        cmdUpdate.Enabled = En
        cmdCancel.Enabled = En
        ToolStripButtonAddDiagnose.Enabled = En
        ToolStripButtonDelete.Enabled = En
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
        txtTemplateName.Focus()
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
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        OpMode = AddEditMode.Edit
        Enable_Controls(True)
        txtTemplateName.Focus()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ID As Long
        Dim LI As ListViewItem
        'SaveSelectedItem = ListView1.SelectedItems(0)
        gLoop_Trim_Controls(Me)
        gLoop_Text_PropperCase(Me)
        Try
            If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
            End If
            txtTemplateName.Text = txtTemplateName.Text.Trim.ToSafeSQLString()
            If txtTemplateName.Text = "" Then
                MsgBox("Unable to process update. The Template Name is required.", MsgBoxStyle.Exclamation)
                txtTemplateName.Focus()
                Exit Sub
            End If
            If ListViewDiagnosis.Items.Count = 0 Then
                MsgBox("Unable to process update. No diagnosis selected for this template.", MsgBoxStyle.Exclamation)
                txtTemplateName.Focus()
                Exit Sub
            End If

            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
                gSQLUpdateData("Update BillingTemplates Set TemplateName = '" & txtTemplateName.Text.ToSafeSQLString() & "' WHERE TemplateID= " & ID)
                gSQLUpdateData("delete from BillingTemplateDiagnosis WHERE TemplateID= " & ID)
            Else
                gSQLUpdateData("INSERT INTO BillingTemplates (TemplateName) VALUES('" & txtTemplateName.Text.ToSafeSQLString() & "')")
                ID = gSQLGetSingleValue("Select IDENT_CURRENT('BillingTemplates')")
            End If
            For Each LI In ListViewDiagnosis.Items
                gSQLUpdateData("INSERT INTO BillingTemplateDiagnosis (TemplateID, DignosisID) VALUES(" & ID & ", " & Val(LI.Tag) & ")")

            Next
            If OpMode = AddEditMode.Edit Then
                SaveSelectedItem.Text = txtTemplateName.Text
            Else
                LI = ListView1.Items.Add(txtTemplateName.Text, 0)
                LI.Tag = ID
            End If
            OpMode = AddEditMode.None
            Enable_Controls(False)
            If ListView1.SelectedItems.Count > 0 Then
                SaveSelectedItem = ListView1.SelectedItems(0)
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            End If
            DataUpdated = True
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim ID As Long
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete. No Template selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to delete the Template " & ListView1.SelectedItems(0).Text & "?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ID = CLng(ListView1.SelectedItems(0).Tag)
        If gSQLDeleteRecord("DELETE FROM BillingTemplates WHERE TemplateID=" & ID) Then
            gSQLDeleteRecord("DELETE FROM BillingTemplateDiagnosis WHERE TemplateID=" & ID)
            ListViewDiagnosis.Items.Clear()
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
        If DataUpdated = True Then
            DialogResult = Windows.Forms.DialogResult.OK
        End If
        Me.Close()

    End Sub

    Private Sub ToolStripButtonAddDiagnose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonAddDiagnose.Click
        frmBillingTemplatesMaintenanceAdd.CalledForm = Me
        frmBillingTemplatesMaintenanceAdd.ShowDialog(Me)
        frmBillingTemplatesMaintenanceAdd.Dispose()
    End Sub

    Private Sub ToolStripButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonDelete.Click
        If ListViewDiagnosis.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No diagnosis selected.")
            Exit Sub
        End If
        ListViewDiagnosis.Items.Remove(ListViewDiagnosis.SelectedItems(0))
    End Sub

End Class