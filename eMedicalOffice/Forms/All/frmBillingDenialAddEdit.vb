Public Class frmBillingDenialAddEdit
    Public LV As ListView
    Public LI As ListViewItem
    Public frm As frmBillingDenial
    Private Sub frmBillingDenialAddEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
        gFindComboItemByValue(ComboBoxDenialReasons, CType(LI.SubItems(3).Tag, ValueDescription).Value, True)
        If ComboBoxDenialReasons.SelectedIndex = -1 Then ComboBoxDenialReasons.SelectedIndex = 0

    End Sub
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim IDs As String = ""
        Dim SQL As String
        Dim LI As ListViewItem
        Reader = gSQLGetDataReader("SELECT ID, Description, DenialBackInd, NoMoreCollectionInd FROM BillDenialReasons ORDER BY SortOrder, Description")
        If Reader Is Nothing Then Exit Sub
        ComboBoxDenialReasons.Items.Add(New ValueDescription(0, "", 0))
        Do Until Reader.Read = False
            ComboBoxDenialReasons.Items.Add(New ValueDescription(Reader("ID").ToString, Reader("Description").ToString, Val(Reader("DenialBackInd").ToString), Val(Reader("NoMoreCollectionInd").ToString)))
        Loop
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If ComboBoxDenialReasons.SelectedIndex = -1 Then ComboBoxDenialReasons.SelectedIndex = 0

        If txtOther.Visible And txtOther.Text.Trim = "" Then
            MsgBox("Unable to update. The Denial reason 'Other' is not specified.", MsgBoxStyle.Exclamation)
            txtOther.Focus()
            Exit Sub
        End If
        If LI.SubItems(3).Text.Trim = CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Description Then
            MsgBox("Unable to update. Nothing changed.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If LI.SubItems(3).Text <> "" Then
            If ComboBoxDenialReasons.SelectedIndex < 1 Then
                If MsgBox("Please confirm you want to remove the Denial from the following procedure: " & vbCrLf & vbCrLf & LI.SubItems(1).Text & "?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                If MsgBox("Please confirm you want to update the Denial Reason for the following procedure:" & vbCrLf & vbCrLf & LI.SubItems(1).Text & vbCrLf & vbCrLf & "Existing Denial Reason: " & vbCrLf & LI.SubItems(3).Text & vbCrLf & vbCrLf & "New Denial reason " & vbCrLf & ComboBoxDenialReasons.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        End If
        LI.UseItemStyleForSubItems = True
        If ComboBoxDenialReasons.SelectedIndex = 0 Then
            LI.SubItems(2).Text = ""
        Else
            LI.SubItems(2).Text = Now.ToShortDateString
        End If
        If txtOther.Visible = False Then
            LI.SubItems(3).Text = CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Description
            LI.SubItems(3).Tag = New ValueDescription(CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Value, CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Description, CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Value1)
        Else
            LI.SubItems(3).Text = txtOther.Text
            LI.SubItems(3).Tag = New ValueDescription(CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Value1, txtOther.Text.Trim, CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Value1)
        End If
        LI.ForeColor = Color.OrangeRed
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim lLI As ListViewItem
        Dim Procs As String
        Dim Dcount As Integer = 0
        Dim ChangeFoound As Integer
        If txtOther.Visible And txtOther.Text.Trim = "" Then
            MsgBox("Unable to update. The Denial reason 'Other' is not specified.", MsgBoxStyle.Exclamation)
            txtOther.Focus()
            Exit Sub
        End If
        For Each lLI In LV.Items
            If lLI.SubItems(3).Text <> CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Description Then
                ChangeFoound = ChangeFoound + 1
            End If
            If lLI.SubItems(3).Text <> "" Then
                If lLI.SubItems(3).Text <> CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Description Then
                    Procs = Procs & lLI.SubItems(1).Text & " - " & lLI.SubItems(3).Text & vbCrLf
                    Dcount = Dcount + 1
                End If
            End If
        Next
        If ChangeFoound = False Then
            MsgBox("Unable to update. Nothing changed.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ComboBoxDenialReasons.SelectedIndex < 1 Then
            If Dcount > 0 Then
                If MsgBox("Please confirm you want to remove denial from the following procedure(s)" & vbCrLf & vbCrLf & Procs, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                MsgBox("Unable to update. No denial reason selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Else
            If Dcount > 0 Then
                If MsgBox("Please confirm you want to set denial reason for all " & LV.Items.Count & " procedure(s)?" & vbCrLf & vbCrLf & "This action will update the following procedures denial reasons:" & vbCrLf & vbCrLf & Procs, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                If ChangeFoound = 1 Then
                    If MsgBox("Please confirm you want to set denial reason for " & ChangeFoound & " procedure?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                Else
                    If MsgBox("Please confirm you want to set denial reason for all " & ChangeFoound & " procedures?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If
        End If
        For Each lLI In LV.Items
            LI.UseItemStyleForSubItems = True

            If lLI.SubItems(3).Text <> CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Description Then
                lLI.ForeColor = Color.OrangeRed
                If ComboBoxDenialReasons.SelectedIndex = 0 Then
                    lLI.SubItems(2).Text = ""
                Else
                    lLI.SubItems(2).Text = Now.ToShortDateString
                End If
                If txtOther.Visible = False Then
                    lLI.SubItems(3).Text = CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Description
                    lLI.SubItems(3).Tag = New ValueDescription(CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Value, CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Description, CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Value1)
                Else
                    lLI.SubItems(3).Text = txtOther.Text.Trim
                    lLI.SubItems(3).Tag = New ValueDescription(CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Value1, txtOther.Text.Trim, CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Value1)
                End If
            End If
        Next
        If Not frm Is Nothing Then
            If Val(CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Fld1) = 1 Then
                frm.CheckBox3.Checked = True
            Else
                frm.CheckBox3.Checked = False
            End If
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ComboBoxDenialReasons_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDenialReasons.SelectedIndexChanged
        cmdUpdate.Enabled = True
        Label2.Visible = False
        If ComboBoxDenialReasons.SelectedIndex = -1 Then
            ComboBoxDenialReasons.SelectedIndex = 0
            LabelOther.Visible = False
            txtOther.Visible = False
            Exit Sub
        End If
        If CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Description.ToUpper = "OTHER" Then
            LabelOther.Visible = True
            txtOther.Visible = True
            txtOther.Focus()
        Else
            LabelOther.Visible = False
            txtOther.Visible = False
        End If
        If Val(CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Fld1) = 1 Then
            Label2.Text = "The denial reason [" & CType(ComboBoxDenialReasons.SelectedItem, ValueDescription).Description & "] must be applied to all procedures in the current bill."
            cmdUpdate.Enabled = False
            Label2.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ComboBoxDenialReasons.SelectedIndex = 0
    End Sub
End Class