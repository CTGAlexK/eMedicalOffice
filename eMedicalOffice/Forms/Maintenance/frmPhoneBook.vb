Imports System.Reflection
Imports log4net

Public Class frmPhoneBook
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public cboTo As ComboBox = Nothing
    Public txtToNumber As MaskedTextBox = Nothing
    Public CalledForm As Form
    Private DataChanged As Boolean

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        If Not CalledForm Is Nothing Then
            If DataChanged Then
                If CalledForm.Name = "frmFAX" Then
                    DirectCast(CalledForm, frmFAX).Load_Data()
                End If
            End If
        End If
        Me.Close()
    End Sub

    Private Sub frmFAX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If CalledForm Is Nothing Then cmdSelectEntry.Visible = False
        Enable_Controls(False)
        Load_Data()
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        ListBox1.Items.Clear()
        SQL = "SELECT     ID, ToName, Fax, InsertedBy FROM PhoneBook Order By ToName"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ListBox1.Items.Add(New ValueDescription(Reader("ID").ToString, Reader("ToName").ToString & " - " & Reader("Fax").ToString, Reader("InsertedBy").ToString, Reader("ToName").ToString.Trim, Reader("Fax").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        If ListBox1.Items.Count > 0 Then
            ListBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        If Not CalledForm Is Nothing Then cmdSelectEntry_Click(Nothing, Nothing)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If OpMode <> AddEditMode.None Then Exit Sub
        If ListBox1.SelectedIndex = -1 Then
            cmdDelete.Enabled = False
            cmdEdit.Enabled = False
            txtToName.Text = ""
            txtPhoneNumber.Text = ""
            Exit Sub
        End If
        txtToName.Text = CType(ListBox1.SelectedItem, ValueDescription).Fld1
        txtPhoneNumber.Text = CType(ListBox1.SelectedItem, ValueDescription).Fld2
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
            MsgBox("Unable to process your request. No Phone Book Entry selected.", MsgBoxStyle.Exclamation)
            cmdDelete.Enabled = False
            cmdEdit.Enabled = False
            txtToName.Text = ""
        End If
        If CType(ListBox1.SelectedItem, ValueDescription).Value1 <> gCurrentEmployee.EmpID And gCurrentEmployee.PositionID > 3 Then
            MsgBox("Unable to process your request. You can not delete Phone Book Entry created by others.")
            Exit Sub
        End If
        msgLength = txtToName.Text.Length
        If msgLength > 50 Then msgLength = 50
        If MsgBox("Please confirm you want to delete the Phone Book Entry: " & vbCrLf & vbCrLf & txtToName.Text.Mid(1, msgLength) & "...", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        gSQLDeleteRecord("DELETE FROM PhoneBook Where ID = " & CType(ListBox1.SelectedItem, ValueDescription).Value)
        txtToName.Text = ""
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
        txtToName.ReadOnly = Not En
        txtPhoneNumber.Enabled = En
        ListBox1.Enabled = Not En
        cmdSelectEntry.Enabled = Not En

    End Sub

    Private OpMode As AddEditMode = AddEditMode.None

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        txtToName.Text = ""
        txtPhoneNumber.Text = ""
        txtToName.Focus()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        OpMode = AddEditMode.Edit
        Enable_Controls(True)
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ID As Long
        Dim NewIndex As Integer
        Try
            If txtToName.Text.Trim = "" Then
                MsgBox("Unable to update. The Phone Book Entry Name can not be empty.", MsgBoxStyle.Exclamation)
                txtToName.Focus()
                Exit Sub
            End If
            If txtPhoneNumber.MaskCompleted = False Then
                MsgBox("Unable to update. Invalid or missing Phone Book Entry Number.", MsgBoxStyle.Exclamation)
                txtPhoneNumber.Focus()
                Exit Sub
            End If

            If OpMode = AddEditMode.Edit Then
                ID = CType(ListBox1.SelectedItem, ValueDescription).Value
            Else
                ID = 0
            End If
            Dim TA As New SqlClient.SqlDataAdapter("SELECT     ID, ToName, Fax, InsertedBy FROM PhoneBook Where ID = " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("MessagePool")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("ToName") = StrConv(txtToName.Text.Trim, VbStrConv.ProperCase)
            TR("Fax") = txtPhoneNumber.Text.Trim
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
                ID = gSQLGetSingleValue("Select IDENT_CURRENT('MessagePool')")
                NewIndex = ListBox1.Items.Add(New ValueDescription(ID, txtToName.Text.Trim & " - " & txtPhoneNumber.Text, gCurrentEmployee.EmpID, txtToName.Text.Trim, txtPhoneNumber.Text))
                ListBox1.SelectedIndex = NewIndex
            Else
                Dim SavePos = ListBox1.SelectedIndex
                If SavePos = 0 Then SavePos = 1
                ListBox1.Items.Remove(ListBox1.SelectedItem)
                ListBox1.Items.Insert(SavePos - 1, New ValueDescription(ID, txtToName.Text.Trim & " - " & txtPhoneNumber.Text, gCurrentEmployee.EmpID, txtToName.Text.Trim, txtPhoneNumber.Text))
                ListBox1.SelectedIndex = SavePos - 1
                ListBox1.Refresh()
            End If
            Enable_Controls(False)
            OpMode = AddEditMode.None
            DataChanged = True
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

    Private Sub cmdSelectEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectEntry.Click
        If Not CalledForm Is Nothing And DataChanged Then
            If CalledForm.Name = "frmFAX" Then
                DirectCast(CalledForm, frmFAX).Load_Data()
            End If
        End If
        If Not cboTo Is Nothing And txtToName.Text <> "" Then
            cboTo.Text = txtToName.Text
        End If
        If Not txtToNumber Is Nothing And txtPhoneNumber.Text <> "" Then
            txtToNumber.Text = txtPhoneNumber.Text
        End If
        Me.Close()
    End Sub

End Class