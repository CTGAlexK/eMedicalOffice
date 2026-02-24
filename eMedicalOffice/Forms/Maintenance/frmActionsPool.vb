Imports System.Reflection
Imports log4net

Public Class frmActionsPool
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public txtBox As TextBox

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmActionsPool_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting(My.Application.Info.ProductName, "Settings", "ActionShowMyActionsOnly", CheckBox1.Checked)
    End Sub

    Private Sub frmFAX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If txtBox Is Nothing Then cmdSetMessage.Visible = False
        CheckBox1.Checked = GetSetting(My.Application.Info.ProductName, "Settings", "ActionShowMyActionsOnly", True)
        Load_Data()
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        ListBox1.Items.Clear()
        Try
            If CheckBox1.Checked Then
                SQL = "SELECT     ID, Message, InsertedBy FROM ActionsPool where InsertedBy = " & gCurrentEmployee.EmpID & " Order By Message"
            Else
                SQL = "SELECT     ID, Message, InsertedBy FROM ActionsPool Order By Message"
            End If
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ListBox1.Items.Add(New ValueDescription(Reader("ID").ToString, Reader("Message").ToString, Reader("InsertedBy").ToString))
            Loop
            Reader.Close() : Reader.Dispose()
            If ListBox1.Items.Count > 0 Then
                ListBox1.SelectedIndex = 0
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        If Not txtBox Is Nothing Then cmdStartFax_Click(Nothing, Nothing)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If OpMode <> AddEditMode.None Then Exit Sub
        If ListBox1.SelectedIndex = -1 Then
            cmdDelete.Enabled = False
            cmdEdit.Enabled = False
            txtMessage.Text = ""
            Exit Sub
        End If
        txtMessage.Text = CType(ListBox1.SelectedItem, ValueDescription).Description
        If CType(ListBox1.SelectedItem, ValueDescription).Value1 = gCurrentEmployee.EmpID Or gCurrentEmployee.PositionID < 4 Then
            cmdDelete.Enabled = True
            cmdEdit.Enabled = True
        Else
            cmdDelete.Enabled = False
            cmdEdit.Enabled = False
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim msgLength As Long
        If ListBox1.SelectedIndex = 0 Then
            MsgBox("Unable to process your request. No message selected.", MsgBoxStyle.Exclamation)
            cmdDelete.Enabled = False
            cmdEdit.Enabled = False
            txtMessage.Text = ""
        End If
        If CType(ListBox1.SelectedItem, ValueDescription).Value1 <> gCurrentEmployee.EmpID And gCurrentEmployee.PositionID > 3 Then
            MsgBox("Unable to process your request. You can not delete messages created by others.")
            Exit Sub
        End If
        msgLength = txtMessage.Text.Length
        If msgLength > 50 Then msgLength = 50
        If MsgBox("Please confirm you want to delete the message: " & vbCrLf & vbCrLf & txtMessage.Text.Mid(1, msgLength) & "...", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        gSQLDeleteRecord("DELETE FROM ActionsPool Where ID = " & CType(ListBox1.SelectedItem, ValueDescription).Value)
        txtMessage.Text = ""
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        cmdDelete.Enabled = False
        cmdEdit.Enabled = False
    End Sub

    Private Sub Enable_Controls(ByVal En As Boolean)
        cmdAddNew.Enabled = Not En
        cmdDelete.Enabled = Not En
        cmdEdit.Enabled = Not En
        cmdClose.Enabled = Not En
        cmdCancelUpdate.Enabled = En
        cmdUpdate.Enabled = En
        txtMessage.ReadOnly = Not En
        ListBox1.Enabled = Not En
        cmdSetMessage.Enabled = Not En
    End Sub

    Private OpMode As AddEditMode = AddEditMode.None

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        txtMessage.Text = ""
        txtMessage.Focus()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        OpMode = AddEditMode.Edit
        Enable_Controls(True)
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ID As Long
        Dim NewIndex As Integer
        Try
            If txtMessage.Text.Trim = "" Then
                MsgBox("Unable to update. The Message can not be empty.", MsgBoxStyle.Exclamation)
                txtMessage.Focus()
                Exit Sub
            End If
            If OpMode = AddEditMode.Edit Then
                ID = CType(ListBox1.SelectedItem, ValueDescription).Value
            Else
                ID = 0
            End If
            Dim TA As New SqlClient.SqlDataAdapter("SELECT     ID, Message, InsertedBy FROM ActionsPool Where ID = " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("ActionsPool")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("Message") = txtMessage.Text.Trim
            TR("InsertedBy") = gCurrentEmployee.EmpID

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
                ID = gSQLGetSingleValue("Select IDENT_CURRENT('ActionsPool')")
                NewIndex = ListBox1.Items.Add(New ValueDescription(ID, txtMessage.Text.Trim, gCurrentEmployee.EmpID))
                ListBox1.SelectedIndex = NewIndex
            Else
                Dim SavePos = ListBox1.SelectedIndex
                If SavePos = 0 Then SavePos = 1
                ListBox1.Items.Remove(ListBox1.SelectedItem)
                ListBox1.Items.Insert(SavePos - 1, New ValueDescription(ID, txtMessage.Text.Trim, gCurrentEmployee.EmpID))
                ListBox1.SelectedIndex = SavePos - 1
                ListBox1.Refresh()
            End If
            Enable_Controls(False)
            OpMode = AddEditMode.None
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub cmdCancelUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelUpdate.Click
        OpMode = AddEditMode.None
        Enable_Controls(False)
        ListBox1_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub cmdStartFax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetMessage.Click
        If txtBox.Text <> "" Then
            txtBox.Text &= vbCrLf & txtMessage.Text
        Else
            txtBox.Text = txtMessage.Text
        End If
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Load_Data()
    End Sub

End Class