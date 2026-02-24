Imports System.Reflection
Imports log4net

Public Class frmCariskPayersMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode
    Private Loading As Boolean
    Private ListViews() As ListView
    Private Sub frmInjuryTypesMaintenance_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Load_Offices
        Load_Data()
        Load_Payers()
        ListView1.Columns(0).Width = ListView1.Width - 30
        Cursor = Cursors.Default
        Application.DoEvents()
        gSetup_GotFocus(Me)
        lblMultipleOffices.Visible = True
        Dim OfficesMsg As String = ""
        If gOffices.Count > 0 Then
            For Each item As Office In gOffices
                OfficesMsg &= item.OfficeName & vbCrLf
            Next
            lblMultipleOffices.Text = "Update All " & gOffices.Count & " Offices"
            ToolTip1.SetToolTip(lblMultipleOffices, OfficesMsg)
        Else
            lblMultipleOffices.Text = "Update " & gOfficeName & " Office"
            ToolTip1.SetToolTip(lblMultipleOffices, gOfficeName)
        End If
        TimerCheckedCount.Enabled = True
    End Sub
    Private Sub Load_Offices()
        Dim I As Integer = 0
        Loading = True
        TabControlInsurances.TabPages.Clear()

        If gOffices.Count > 1 Then
            For Each soffice In gOffices

                Dim tp As New TabPage(soffice.OfficeName)
                tp.Tag = soffice.ConnectionString
                TabControlInsurances.TabPages.Add(tp)
                ReDim Preserve ListViews(I)
                ListViews(I) = New System.Windows.Forms.ListView()
                Dim ColumnHeader As ColumnHeader = New ColumnHeader()
                ColumnHeader.Text = "Insurance"
                ColumnHeader.Width = 440
                ListViews(I).Columns.Add(ColumnHeader)
                ListViews(I).Dock = DockStyle.Fill
                ListViews(I).CheckBoxes = True
                ListViews(I).FullRowSelect = True
                ListViews(I).GridLines = True
                ListViews(I).HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
                ListViews(I).HideSelection = True
                ListViews(I).Location = New System.Drawing.Point(3, 75)
                ListViews(I).MultiSelect = False
                ListViews(I).Name = "ListViewOffices" & soffice.OfficeID
                ListViews(I).Size = New System.Drawing.Size(450, 312)
                ListViews(I).TabIndex = 1
                ListViews(I).UseCompatibleStateImageBehavior = False
                ListViews(I).View = System.Windows.Forms.View.Details
                ListViews(I).Tag = soffice.ConnectionString
                AddHandler ListViews(I).SelectedIndexChanged, AddressOf ListViewOffices_SelectedIndexChanged
                AddHandler ListViews(I).ItemCheck, AddressOf ListView_ItemCheck
                tp.Controls.Add(ListViews(I))
                I = I + 1
            Next
        Else
            Dim tp As New TabPage(gOfficeName)
            tp.Tag = gConnectionString
            TabControlInsurances.TabPages.Add(tp)
            ReDim Preserve ListViews(I)
            ListViews(I) = New System.Windows.Forms.ListView()
            Dim ColumnHeader As ColumnHeader = New ColumnHeader()
            ColumnHeader.Text = "Insurance"
            ColumnHeader.Width = 440
            ListViews(I).Columns.Add(ColumnHeader)
            ListViews(I).CheckBoxes = True
            ListViews(I).Dock = DockStyle.Fill
            ListViews(I).FullRowSelect = True
            ListViews(I).GridLines = True
            ListViews(I).HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            ListViews(I).HideSelection = True
            ListViews(I).Location = New System.Drawing.Point(3, 75)
            ListViews(I).MultiSelect = False
            ListViews(I).Name = "ListViewOffices" & 1
            ListViews(I).Size = New System.Drawing.Size(450, 312)
            ListViews(I).TabIndex = 1
            ListViews(I).UseCompatibleStateImageBehavior = False
            ListViews(I).View = System.Windows.Forms.View.Details
            ListViews(I).Tag = gConnectionString
            AddHandler ListViews(I).SelectedIndexChanged, AddressOf ListViewOffices_SelectedIndexChanged
            AddHandler ListViews(I).ItemCheck, AddressOf ListView_ItemCheck

            tp.Controls.Add(ListViews(I))
        End If
        Loading = False
    End Sub
    Private Sub Load_Data()
        Loading = True
        Dim i As Integer
        For Each lv As ListView In ListViews
            Dim reader As SqlClient.SqlDataReader = gSQLGetDataReader("select CompanyID, CompanyName, PayerId from InsuranceCompanies where CaseTypeID=1 or CaseTypeID=2 order by CompanyName", lv.Tag.ToString)
            lv.Items.Clear()
            Do Until reader.Read = False
                Dim lvi As ListViewItem = lv.Items.Add(reader("CompanyName"))
                lvi.Tag = New ValueDescription(reader("CompanyID"), reader("PayerId").ToString())
            Loop
        Next
        Loading = False
    End Sub
    Private Sub TimerCheckedCount_Tick(sender As Object, e As EventArgs) Handles TimerCheckedCount.Tick
        If Loading Then Return
        lblCheckedCount.Text = TabControlInsurances.SelectedTab.Text & " - " & CType(ListViews(TabControlInsurances.SelectedIndex), ListView).CheckedItems.Count & " selected"
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtSearchInsurances.TextChanged
        For Each lv As ListView In ListViews
            gSearchListView(lv, txtSearchInsurances, False, -1, True)
            gHighlightListviewItem(lv, False, False, SystemColors.Highlight)
        Next
    End Sub

    Private Sub TabControlInsurances_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlInsurances.SelectedIndexChanged

    End Sub
    Public Sub ListViewOffices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gHighlightListviewItem(CType(sender, ListView), False, False, SystemColors.Highlight)
    End Sub
    Private Sub frmAdjusterMaintenance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cmdUpdate.Enabled Then
            If MsgBox("You have unsaved data. Discard changes?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Load_Payers()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Reader = gSQLGetDataReader("SELECT [Payer Name], [PayerId] from [CariskPayers] Order by [Payer Name]")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("Payer Name").ToString)
            LI.ToolTipText = "" & Reader("Payer Name").ToString
            LI.Tag = "" & Reader("PayerId").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
            ListView1_SelectedIndexChanged(Nothing, Nothing)
            cmdEdit.Enabled = True
        End If
    End Sub



    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        cmdEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim ID As String
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Clear_Controls()
        cmdEdit.Enabled = True
        ID = ListView1.SelectedItems(0).Tag
        SaveSelectedItem = ListView1.SelectedItems(0)
        Dim reader As SqlClient.SqlDataReader = gSQLGetDataReader("SELECT [Payer Name],[PayerId],[States],[Professional],[Institutional],[PharmacyRx],[WorkComp],[Automotive] ,[835/EOB] FROM [CariskPayers] WHERE PayerId = '" & ID.Replace("'", "''") & "'")
        If reader.HasRows = False Then Return
        reader.Read()
        txtPayerId.Text = reader("PayerId").ToString
        txtPayerName.Text = reader("Payer Name").ToString
        txtStates.Text = reader("States").ToString
        chkProfessional.Checked = If(reader("Professional").ToString = "Y", True, False)
        chkInstitutional.Checked = If(reader("Institutional").ToString = "Y", True, False)
        chkPharmacyRx.Checked = If(reader("PharmacyRx").ToString = "Y", True, False)
        chkWorkComp.Checked = If(reader("WorkComp").ToString = "Y", True, False)
        chkAutomotive.Checked = If(reader("Automotive").ToString = "Y", True, False)
        chk835EOB.Checked = If(reader("835/EOB").ToString = "Y", True, False)
        Cursor = Cursors.Default
        gHighlightListviewItem(ListView1, False, False, SystemColors.Highlight)
    End Sub

    Private Sub Clear_Controls()
        gLoop_Clear_Controls(Me, TextBoxSearch, txtUserName, txtPassword)
        For Each lv As ListView In ListViews
            For Each lvi As ListViewItem In lv.CheckedItems
                lvi.Checked = False
            Next

        Next
    End Sub

    Private Sub Enable_Controls(ByVal En As Boolean)
        gLoop_Enable_Controls(Me, En, txtUserName, txtPassword)
        txtSearchInsurances.Enabled = True
        TextBoxSearch.Enabled = Not En
        ListView1.Enabled = Not En
        cmdAddNew.Enabled = Not En
        cmdLoad.Enabled = Not En
        PanelMsg.Visible = En
        cmdUpdate.Enabled = En
        cmdCancel.Enabled = En
        chkProfessional.Enabled = En
        chkInstitutional.Enabled = En
        chkPharmacyRx.Enabled = En
        chk835EOB.Enabled = En
        chkWorkComp.Enabled = En
        chkAutomotive.Enabled = En
        'For Each lv As ListView In ListViews
        '    lv.CheckBoxes = En
        'Next
        If En = False Then
            If ListView1.Items.Count > 0 Then
                cmdEdit.Enabled = True
            Else
                cmdEdit.Enabled = False
            End If
        Else
            cmdEdit.Enabled = False
        End If

    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
        If Suppervisor.SupervisorName = "" Then Exit Sub
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        Clear_Controls()
        txtPayerId.Focus()
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
        ListView1.Focus()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
        If Suppervisor.SupervisorName = "" Then Exit Sub
        OpMode = AddEditMode.Edit
        Enable_Controls(True)
        txtPayerName.Focus()
        txtPayerId.Enabled = False
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ID As String
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
        If Suppervisor.SupervisorName = "" Then Exit Sub
        gLoop_Trim_Controls(Me)
        gLoop_Text_PropperCase(Me)
        Try
            If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
            End If
            gLoop_Trim_Controls(Me)
            If txtPayerId.Text = "" Then
                ErrorProvider1.SetError(txtPayerId, "Unable to process update. The Payer Id is required.")
                MsgBox("Unable to process update. The Payer Id is required.", MsgBoxStyle.Exclamation)
                txtPayerId.Focus()
                Exit Sub
            End If
            If txtPayerName.Text = "" Then
                ErrorProvider1.SetError(txtPayerId, "Unable to process update. The Payer Name is required.")
                MsgBox("Unable to process update. The Payer Name is required.", MsgBoxStyle.Exclamation)
                txtPayerName.Focus()
                Exit Sub
            End If
            If txtStates.Text.Trim.Length = 0 Then txtStates.Text = "All States"
            If OpMode = AddEditMode.Edit Then
                ID = SaveSelectedItem.Tag
                If gSQLGetSingleValue("Select count(*) from CariskPayers Where PayerId<>'" & ID & "' and [Payer Name]='" & txtPayerName.Text.ToSafeSQLString() & "'") > 0 Then
                    ErrorProvider1.SetError(txtPayerName, "Unable to process update. Duplicate Payer Name.")
                    MsgBox("Unable to process update. Duplicate Payer Name.", MsgBoxStyle.Exclamation)
                    txtPayerName.Focus()
                    txtPayerName.SelectAll()
                    Return
                End If
            Else
                ID = "-1"
                If gSQLGetSingleValue("Select count(*) from CariskPayers Where [Payer Name]='" & txtPayerName.Text.ToSafeSQLString() & "'") > 0 Then
                    ErrorProvider1.SetError(txtPayerName, "Unable to process update. Duplicate Payer Name.")
                    MsgBox("Unable to process update. Duplicate Payer Name.", MsgBoxStyle.Exclamation)
                    txtPayerId.Focus()
                    txtPayerId.SelectAll()
                    Return
                End If
                If gSQLGetSingleValue("Select count(*) from CariskPayers Where PayerId='" & txtPayerId.Text.ToSafeSQLString() & "'") > 0 Then
                    ErrorProvider1.SetError(txtPayerId, "Unable to process update. Duplicate Payer ID.")
                    MsgBox("Unable to process update. Duplicate Payer ID.", MsgBoxStyle.Exclamation)
                    txtPayerName.Focus()
                    txtPayerName.SelectAll()
                    Return
                End If
            End If
            If gOffices.Count > 1 Then
                Dim AssignedFound As Boolean
                For Each lv As ListView In ListViews
                    If lv.CheckedItems.Count > 0 Then
                        AssignedFound = True
                        Exit For
                    End If
                Next
                Dim tp As Integer
                If AssignedFound Then
                    For Each lv As ListView In ListViews
                        If lv.CheckedItems.Count = 0 Then
                            MsgBox("Unable to process update." & vbCrLf & vbCrLf & "You have not assigned payer to insurance company for " & TabControlInsurances.TabPages(tp).Text & " office." & vbCrLf & "Please make proper assignment ahd try again.")
                            TabControlInsurances.SelectedIndex = tp
                            Return
                        End If
                        tp = tp + 1
                    Next
                    For Each lv As ListView In ListViews
                        If ListViews(0).CheckedItems.Count <> lv.CheckedItems.Count Then
                            MsgBox("Unable to process update." & vbCrLf & vbCrLf & "The number of assigned insurance companies should be the same for all offices." & vbCrLf & "Please make proper assignment ahd try again.")
                            Return
                        End If
                    Next
                Else
                    If MsgBox("You have not assigned the current payer to an insurance company." & vbCrLf & "Not asigning payer to insurance company will prevent e-Filing auto payer selection." & vbCrLf & vbCrLf & "Continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Return
                    End If
                End If
                For Each soffice In gOffices
                    UpdatePayer(ID, soffice.ConnectionString)
                Next
            Else
                If ListViews(0).CheckedItems.Count = 0 Then
                    If MsgBox("You have not assigned the current payer to an insurance company." & vbCrLf & "Not asigning payer to insurance company will prevent e-Filing auto payer selection." & vbCrLf & vbCrLf & "Continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Return
                    End If
                End If
                UpdatePayer(ID, gConnectionString)
            End If

            If OpMode = AddEditMode.AddNew Then
                LI = ListView1.Items.Add(txtPayerName.Text.Trim)
                LI.Tag = txtPayerId.Text.Trim
                LI.ToolTipText = txtPayerName.Text.Trim
                LI.Selected = True
                LI.EnsureVisible()
                SaveSelectedItem = LI
            Else
                SaveSelectedItem.Text = txtPayerName.Text
                SaveSelectedItem.ToolTipText = txtPayerName.Text
            End If
            OpMode = AddEditMode.None
            Enable_Controls(False)
            gLoop_ResetErrors_Controls(ErrorProvider1, Me)
            ListView1.Focus()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub
    Private Sub UpdatePayer(id As String, ConnectionString As String)
        Dim TA As New SqlClient.SqlDataAdapter("Select * from [CariskPayers] Where [PayerId] = '" & id & "'", ConnectionString)
        Dim CB As New SqlClient.SqlCommandBuilder(TA)
        CB.ConflictOption = ConflictOption.OverwriteChanges
        Dim TR As DataRow
        Dim dTab As New DataTable("CariskPayers")

        TA.Fill(dTab)

        If OpMode = AddEditMode.AddNew Then
            TR = dTab.NewRow
        Else
            TR = dTab.Rows(0)
        End If
        TR("PayerId") = txtPayerId.Text.Trim
        TR("Payer Name") = txtPayerName.Text.Trim
        TR("States") = txtStates.Text.Trim

        TR("Professional") = If(chkProfessional.Checked, "Y", "N")
        TR("Institutional") = If(chkInstitutional.Checked, "Y", "N")
        TR("PharmacyRx") = If(chkPharmacyRx.Checked, "Y", "N")
        TR("WorkComp") = If(chkWorkComp.Checked, "Y", "N")
        TR("Automotive") = If(chkAutomotive.Checked, "Y", "N")
        TR("835/EOB") = If(chk835EOB.Checked, "Y", "N")

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

    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub txtInjuryName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPayerId.TextChanged
        ErrorProvider1.SetError(txtPayerId, "")
    End Sub

    Private Sub txtInjuryDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPayerName.TextChanged
        ErrorProvider1.SetError(txtPayerName, "")
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        gSearchListView(ListView1, TextBoxSearch, False, -1, True)
        gHighlightListviewItem(ListView1, False, False, SystemColors.Highlight)
    End Sub

    Private Sub txtStates_TextChanged(sender As Object, e As EventArgs) Handles txtStates.TextChanged
        ErrorProvider1.SetError(txtStates, "")
    End Sub

    Private Sub ListView2_ItemCheck(sender As Object, e As ItemCheckEventArgs)
        If Loading = True Then Return
        If OpMode = AddEditMode.None Then
            e.NewValue = e.CurrentValue
        End If

    End Sub

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click
        Dim Suppervisor As SupperApproval = Validate_Supervisor(txtUserName, txtPassword)
        If Suppervisor.SupervisorName = "" Then Exit Sub
        Dim frm As New frmCariskPayersMaintenanceImport
        frm.Location = Location
        frm.Size = Size
        frm.ParentWindow = Me
        If frm.ShowDialog() = DialogResult.OK Then
            Clear_Controls()
            Load_Payers()
        End If
        frm.Dispose()
    End Sub

    Private Sub ListView_ItemCheck(sender As Object, e As ItemCheckEventArgs)
        If Loading Then Return
        If cmdAddNew.Enabled Then e.NewValue = e.CurrentValue
    End Sub
End Class