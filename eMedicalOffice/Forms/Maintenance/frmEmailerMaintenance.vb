Imports System.Reflection
Imports log4net

Public Class frmEmailerMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedTemplate As ListViewItem
    Private SaveSelectedAddress As ListViewItem
    Private OpModeTemplate As AddEditMode
    Private OpModeAddress As AddEditMode
    Private m_SortingColumn As ColumnHeader
    Private LastControl As Object

    Private Sub frmDocumentsMaintenance_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmEmployeeMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        gSetup_GotFocus(Me)
        Application.DoEvents()
        gListview_Settings(Me, ListViewLog, ReadWrite.sRead)
        Load_Data()
        Load_Templates()
        Load_Addresses()
        Cursor = Cursors.Default
        Application.DoEvents()
        m_SortingColumn = ListViewLog.Columns(0)
    End Sub

    Private Sub frmAdjusterMaintenance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewLog, ReadWrite.sWrite)
        If cmdUpdate.Enabled Or cmdUpdate1.Enabled Then
            If MsgBox("You have unsaved data. Discard changes?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                If cmdUpdate.Enabled Then
                    TabControl1.SelectedIndex = 0
                Else
                    TabControl1.SelectedIndex = 1
                End If
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Load_Addresses()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String = ""
        SQL = "SELECT     AddressID, CompanyName, ActiveInd FROM         EmailerAddressBook "
        If txtCompanyNameSearch.Text <> "" Then
            SQL &= " Where CompanyName like '" & txtCompanyNameSearch.Text.ToSafeSQLString() & "%'"
        End If
        SQL &= " ORDER BY CompanyName"
        Reader = gSQLGetDataReader(SQL)
        ListViewAddresses.Items.Clear()
        ListViewAddresses.BeginUpdate()
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewAddresses.Items.Add(Reader("CompanyName").ToString, CInt(Val(Reader("ActiveInd").ToString)))
            LI.Tag = "" & Reader("AddressID").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        ListViewAddresses.EndUpdate()
        If ListViewAddresses.Items.Count > 0 Then
            ListViewAddresses.Items(0).Selected = True
            ListViewAddresses.Items(0).EnsureVisible()
            ListViewAddresses_SelectedIndexChanged(Nothing, Nothing)
            cmdEdit.Enabled = True
        End If

    End Sub

    Private Sub Load_Templates()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String = ""
        Try
            SQL = "SELECT     TempID, TemplateName FROM         EmailerTemplates "
            If txtTemplateNameSearch.Text <> "" Then
                SQL &= " Where TemplateName like '" & txtTemplateNameSearch.Text.ToSafeSQLString() & "%'"
            End If
            SQL &= " ORDER BY TemplateName "
            Reader = gSQLGetDataReader(SQL)
            ListViewTempLates.Items.Clear()
            ListViewTempLates.BeginUpdate()

            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                LI = ListViewTempLates.Items.Add(Reader("TemplateName").ToString, 1)
                LI.Tag = "" & Reader("TempID").ToString
            Loop
            Reader.Close() : Reader.Dispose()
            ListViewTempLates.EndUpdate()
            If ListViewTempLates.Items.Count > 0 Then
                ListViewTempLates.Items(0).Selected = True
                ListViewTempLates.Items(0).EnsureVisible()
                ListViewTempLates_SelectedIndexChanged(Nothing, Nothing)
                cmdEdit.Enabled = True
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
    End Sub

    Private Loading As Boolean

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Try
            Reader = gSQLGetDataReader("SELECT RWID, RWValue, RWDescription FROM EmailerReservedWords Order By RWDescription")
            Loading = True
            ComboBox1.Items.Clear()
            Do Until Reader.Read = False
                ComboBox1.Items.Add(New ValueDescription(Val(Reader("RWID").ToString), Reader("RWDescription").ToString, Reader("RWValue").ToString))
            Loop
            ComboBox1.SelectedIndex = -1

            cboPriority.Items.Add("Normal")
            cboPriority.Items.Add("Low")
            cboPriority.Items.Add("High")
            cboPriority.SelectedIndex = 0
            cboStatus.Items.Add("All")
            cboStatus.Items.Add("Ok")
            cboStatus.Items.Add("Failed")
            cboStatus.SelectedIndex = 0

            cboType.Items.Add("All")
            cboType.Items.Add("Letter")
            cboType.Items.Add("eMail")
            cboType.SelectedIndex = 0

            Reader = gSQLGetDataReader("Select DISTINCT State, ShowOrder from States Order by ShowOrder")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxState.Items.Add(Reader("State").ToString)
            Loop
            Reader.Close() : Reader.Dispose()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
        Loading = False
        Load_Log()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        cmdEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Clear_Controls()
        gLoop_Clear_Controls(Me)
        ComboBox1.SelectedIndex = -1
        CheckBoxActiveInd.Checked = True
        cboPriority.SelectedIndex = 0
    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        OpModeTemplate = AddEditMode.AddNew
        ListViewTempLates.Enabled = False
        txtTemplateName.Enabled = True
        cboPriority.Enabled = True
        txtSubject.Enabled = True
        ComboBox1.Enabled = True
        txtBody.ReadOnly = False
        cmdSelectAttachment.Enabled = True
        ButtonRemoveAttachement.Enabled = True
        txtTemplateName.Text = ""
        txtSubject.Text = ""
        txtBody.Text = ""
        txtAttachement.Text = ""
        cboPriority.SelectedIndex = 0

        cmdAddNew.Enabled = False
        cmdEdit.Enabled = False
        cmdUpdate.Enabled = True
        cmdCancel.Enabled = True
        cmdDelete.Enabled = False

        txtTemplateName.Focus()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        OpModeTemplate = AddEditMode.None
        ListViewTempLates.Enabled = True
        txtTemplateName.Enabled = False
        cboPriority.Enabled = False
        txtSubject.Enabled = False
        ComboBox1.Enabled = False
        txtBody.ReadOnly = True
        cmdSelectAttachment.Enabled = False
        ButtonRemoveAttachement.Enabled = False
        cmdAddNew.Enabled = True
        cmdEdit.Enabled = True
        cmdUpdate.Enabled = False
        cmdCancel.Enabled = False
        cmdDelete.Enabled = True
        If Not SaveSelectedTemplate Is Nothing Then
            ListViewTempLates_SelectedIndexChanged(Nothing, Nothing)
        Else
            If ListViewTempLates.Items.Count > 0 Then
                ListViewTempLates.Items(0).Selected = True
                ListViewTempLates.Items(0).EnsureVisible()
                ListViewTempLates_SelectedIndexChanged(Nothing, Nothing)
            Else
                txtTemplateName.Text = ""
                txtSubject.Text = ""
                txtBody.Text = ""
                txtAttachement.Text = ""
                cboPriority.SelectedIndex = -1
            End If
        End If
        gLoop_ResetErrors_Controls(ErrorProvider1, Me)

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If ListViewTempLates.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. No Template selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        SaveSelectedTemplate = ListViewTempLates.SelectedItems(0)
        OpModeTemplate = AddEditMode.Edit
        ListViewTempLates.Enabled = False
        txtTemplateName.Enabled = True
        cboPriority.Enabled = True
        txtSubject.Enabled = True
        ComboBox1.Enabled = True
        txtBody.ReadOnly = False
        cmdSelectAttachment.Enabled = True
        ButtonRemoveAttachement.Enabled = True
        cmdAddNew.Enabled = False
        cmdEdit.Enabled = False
        cmdUpdate.Enabled = True
        cmdCancel.Enabled = True
        cmdDelete.Enabled = False
        txtTemplateName.Focus()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ID As Long
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Try
            If SaveSelectedTemplate Is Nothing And OpModeTemplate = AddEditMode.Edit Then
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
                Exit Sub
            End If
            If txtTemplateName.Text = "" Then
                ErrorProvider1.SetError(txtTemplateName, "Unable to process update. The Template Name is required.")
                MsgBox("Unable to process update. The Template Name is required.", MsgBoxStyle.Exclamation)
                txtTemplateName.Focus()
                Exit Sub
            End If
            If cboPriority.SelectedIndex = -1 Then
                cboPriority.SelectedIndex = 0
            End If

            If txtBody.Text = "" Then
                ErrorProvider1.SetError(txtBody, "Unable to process update. The Template Body is required.")
                MsgBox("Unable to process update. The Template Body is required.", MsgBoxStyle.Exclamation)
                txtBody.Focus()
                Exit Sub
            End If

            If txtAttachement.Text <> "" And IO.File.Exists(txtAttachement.Text) = False Then
                ErrorProvider1.SetError(txtAttachement, "Unable to process update. The Attachement file does not exists.")
                MsgBox("Unable to process update. The Attachement file does not exists.", MsgBoxStyle.Exclamation)
                txtAttachement.Focus()
                Exit Sub
            End If
            If OpModeTemplate = AddEditMode.Edit Then
                ID = SaveSelectedTemplate.Tag
            Else
                ID = 0
            End If

            Dim TA As New SqlClient.SqlDataAdapter("Select * from EmailerTemplates Where TempID = " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("EmailerTemplates")

            TA.Fill(dTab)

            If OpModeTemplate = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("TemplateName") = txtTemplateName.Text
            TR("Subject") = txtSubject.Text
            TR("Body") = txtBody.Text
            TR("Priority") = cboPriority.SelectedIndex
            TR("Attachement") = txtAttachement.Text

            If OpModeTemplate = AddEditMode.AddNew Then
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
            If OpModeTemplate = AddEditMode.AddNew Then

                Reader = gSQLGetDataReader("Select * from EmailerTemplates Where TempID = IDENT_CURRENT('EmailerTemplates')")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListViewTempLates.Items.Add(Reader("TemplateName").ToString, 1)
                    LI.Tag = "" & Reader("TempID").ToString
                    If ListViewTempLates.SelectedItems.Count > 0 Then ListViewTempLates.SelectedItems(0).Selected = False
                    LI.Selected = True
                    LI.EnsureVisible()
                    ListViewTempLates_SelectedIndexChanged(Nothing, Nothing)
                    ID = CLng(Val(Reader("TempID").ToString))
                    SaveSelectedTemplate = LI
                Loop
                Reader.Close() : Reader.Dispose()
            Else
                SaveSelectedTemplate.Text = txtTemplateName.Text
            End If
            OpModeTemplate = AddEditMode.None
            ListViewTempLates.Enabled = True
            txtTemplateName.Enabled = False
            cboPriority.Enabled = False
            txtSubject.Enabled = False
            ComboBox1.Enabled = False
            txtBody.ReadOnly = True
            cmdSelectAttachment.Enabled = False
            ButtonRemoveAttachement.Enabled = False
            cmdAddNew.Enabled = True
            cmdEdit.Enabled = True
            cmdUpdate.Enabled = False
            cmdCancel.Enabled = False
            cmdDelete.Enabled = True
            gLoop_ResetErrors_Controls(ErrorProvider1, Me)
            If ListViewTempLates.SelectedItems.Count > 0 Then
                ListViewTempLates_SelectedIndexChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim ID As Long
        If ListViewTempLates.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete. No Template selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to delete the Template " & ListViewTempLates.SelectedItems(0).Text & "?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Try
            ID = CLng(ListViewTempLates.SelectedItems(0).Tag)
            If gSQLDeleteRecord("DELETE FROM EmailerTemplates WHERE TempID=" & ID) Then
                ListViewTempLates.Items.Remove(ListViewTempLates.SelectedItems(0))
                SaveSelectedTemplate = Nothing
                If ListViewTempLates.SelectedItems.Count > 0 Then
                    ListViewTempLates_SelectedIndexChanged(Nothing, Nothing)
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

    Private Sub ListViewTempLates_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewTempLates.SelectedIndexChanged
        Dim ID As Long
        Dim Reader As SqlClient.SqlDataReader
        txtTemplateName.Text = ""
        txtSubject.Text = ""
        txtAttachement.Text = ""
        txtBody.Text = ""
        txtSubject.Text = ""
        cboPriority.SelectedIndex = -1

        If ListViewTempLates.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        cmdEdit.Enabled = True
        Try
            ID = CLng(ListViewTempLates.SelectedItems(0).Tag)
            SaveSelectedTemplate = ListViewTempLates.SelectedItems(0)
            Reader = gSQLGetDataReader("SELECT TempID, TemplateName, Subject, Attachement, Priority, Body FROM         EmailerTemplates Where TempID=" & ID)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False

                txtTemplateName.Text = "" & Reader("TemplateName").ToString
                txtSubject.Text = Reader("Subject").ToString
                txtAttachement.Text = Reader("Attachement").ToString
                txtBody.Text = Reader("Body").ToString
                txtSubject.Text = Reader("Subject").ToString
                cboPriority.SelectedIndex = Val(Reader("Priority").ToString)

            Loop
            Reader.Close() : Reader.Dispose()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ListViewAddresses_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewAddresses.ParentChanged

    End Sub

    Private Sub ListViewAddresses_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewAddresses.SelectedIndexChanged
        Dim ID As Long
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        CheckBoxActiveInd.Checked = False
        txtCompanyName.Text = ""
        txtContactName.Text = ""
        txtEmailAddress1.Text = ""
        ListViewEmailLog.Items.Clear()
        If ListViewAddresses.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try
            cmdEdit.Enabled = True
            ID = CLng(ListViewAddresses.SelectedItems(0).Tag)
            cmdEdit1.Enabled = True
            SaveSelectedAddress = ListViewAddresses.SelectedItems(0)
            Reader = gSQLGetDataReader("SELECT Address1, Address2, City, State, Zip,    AddressID, CompanyName, ActiveInd, ContactName, EmailAddress1 FROM EmailerAddressBook Where AddressID=" & ID)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                CheckBoxActiveInd.Checked = CBool(Val("" & Reader("ActiveInd").ToString))
                txtCompanyName.Text = "" & Reader("CompanyName").ToString
                txtContactName.Text = Reader("ContactName").ToString
                txtEmailAddress1.Text = Reader("EmailAddress1").ToString
                txtAddress1.Text = Reader("Address1").ToString
                txtAddress2.Text = Reader("Address2").ToString
                txtCity.Text = Reader("City").ToString
                txtZip.Text = Reader("Zip").ToString
                ComboBoxState.Text = Reader("State").ToString
            Loop
            Reader.Close() : Reader.Dispose()
            Reader = gSQLGetDataReader("SELECT EmailerLog.Comments, EmailerType.Description as ProcessType, EmailerAddressBook.CompanyName, EmailerAddressBook.EmailAddress1, EmailerLog.SendDate, EmailerLog.Result FROM EmailerLog INNER JOIN EmailerType on EmailerType.TypeID=EmailerLog.TypeID INNER JOIN EmailerAddressBook ON EmailerLog.AddressID = EmailerAddressBook.AddressID Where EmailerLog.AddressID=" & ID & " ORDER BY SendDate")
            ListViewEmailLog.Items.Clear()
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                LI = ListViewEmailLog.Items.Add(CDate(Reader("SendDate").ToString).ToShortDateString, CInt(Val(Reader("Result").ToString) + 3))
                LI.SubItems.Add(Reader("ProcessType").ToString)
                LI.UseItemStyleForSubItems = True
                Select Case Val(Reader("Result").ToString)
                    Case 0
                        LI.SubItems.Add("")
                    Case 1
                        LI.SubItems.Add("Ok")
                    Case 2
                        LI.SubItems.Add("Failed")
                        LI.ForeColor = Color.Red
                End Select
                LI.SubItems.Add(Reader("Comments").ToString)
            Loop
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try

        Cursor = Cursors.Default

    End Sub

    Private Sub Load_Log()
        If Loading Then Exit Sub
        Dim reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        Try
            SQL = "SELECT EmailerLog.Comments, EmailerType.Description as ProcessType, EmailerAddressBook.CompanyName, EmailerAddressBook.EmailAddress1, EmailerLog.SendDate, EmailerLog.Result FROM EmailerLog INNER JOIN EmailerType on EmailerType.TypeID=EmailerLog.TypeID INNER JOIN EmailerAddressBook ON EmailerLog.AddressID = EmailerAddressBook.AddressID Where 1=1 "
            If txtCompanyNameLogSearch.Text <> "" Then
                SQL &= " AND CompanyName like '" & txtCompanyNameLogSearch.Text.ToSafeSQLString() & "%'"
            End If
            If cboStatus.SelectedIndex > 0 Then
                SQL &= " AND EmailerLog.Result = " & cboStatus.SelectedIndex
            End If
            If cboType.SelectedIndex > 0 Then
                SQL &= " AND EmailerLog.TypeID = " & cboType.SelectedIndex
            End If

            SQL &= " ORDER BY CompanyName, SendDate"
            reader = gSQLGetDataReader(SQL)
            ListViewLog.Items.Clear()
            If reader Is Nothing Then Exit Sub
            Do Until reader.Read = False
                LI = ListViewLog.Items.Add(reader("CompanyName").ToString, CInt(Val(reader("Result").ToString) + 3))
                LI.SubItems.Add(CDate(reader("SendDate").ToString).ToShortDateString)
                LI.SubItems.Add(reader("ProcessType").ToString)

                LI.UseItemStyleForSubItems = True
                Select Case Val(reader("Result").ToString)
                    Case 0
                        LI.SubItems.Add("")
                    Case 1
                        LI.SubItems.Add("Ok")
                    Case 2
                        LI.SubItems.Add("Failed")
                        LI.ForeColor = Color.Red
                End Select
                LI.SubItems.Add(reader("Comments").ToString)
            Loop
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
        lblCountLog.Text = ListViewLog.Items.Count & " Records Found"
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub txtTemplateName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTemplateName.TextChanged
        ErrorProvider1.SetError(txtTemplateName, "")
    End Sub

    Private Sub txtSubject_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubject.GotFocus
        LastControl = txtSubject
    End Sub

    Private Sub txtSubject_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubject.TextChanged
        ErrorProvider1.SetError(txtSubject, "")
    End Sub

    Private Sub txtBody_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBody.GotFocus
        LastControl = txtBody
    End Sub

    Private Sub txtBody_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBody.TextChanged
        ErrorProvider1.SetError(txtBody, "")
    End Sub

    Private Sub txtAttachement_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAttachement.TextChanged
        ErrorProvider1.SetError(txtAttachement, "")
    End Sub

    Private Sub cmdSelectAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAttachment.Click
        ErrorProvider1.SetError(txtAttachement, "")
        Dim filenameOnly As String

        If IO.File.Exists(txtAttachement.Text) Then
            FD.FileName = txtAttachement.Text
        End If
        If FD.ShowDialog = Windows.Forms.DialogResult.OK Then
            Select Case FD.FileName.Right(3).ToUpper()
                Case "ADE", "ADP", "APP", "BAS", "BAT", "CHM", "CMD", "COM", "CPL", "CRT", "CSH", "EXE", "FXP", "HLP", "HTA", "INF", "INS", "ISP", "JS", "JSE", "KSH", "LNK", "MDB", "MDE", "MDT", "MDW", "MSC", "MSI", "MSP", "MST", "OPS", "PCD", "PIF", "PRG", "REG", "SCR", "SCT", "SHB", "SHS", "URL", "VB", "VBE", "VBS", "WSC", "WSF", "WSH"
                    filenameOnly = IO.Path.GetFileName(FD.FileName)

                    If MsgBox("Attention!" & vbCrLf & "In accordance with Microsoft's list of dangerous file extensions," & vbCrLf & "the selected file: " & filenameOnly & " most likely will be blocked by the customer's firewall." & vbCrLf & vbCrLf & "Do you want to continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        txtAttachement.Text = ""
                        Exit Sub
                    End If
            End Select
            txtAttachement.Text = FD.FileName
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = -1 Then Exit Sub
        If LastControl Is Nothing Then LastControl = txtBody
        If LastControl.Text = "" Then
            LastControl.Text = CType(ComboBox1.SelectedItem, ValueDescription).Value1 & " "
        Else
            LastControl.Text = LastControl.Text & " " & CType(ComboBox1.SelectedItem, ValueDescription).Value1 & " "
        End If
        ComboBox1.SelectedIndex = -1
        LastControl.SelectionStart = txtBody.Text.Length
        LastControl.Focus()
    End Sub

    Private Sub cmdAddNew1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew1.Click
        OpModeAddress = AddEditMode.AddNew
        ListViewAddresses.Enabled = False
        txtCompanyName.Enabled = True
        txtContactName.Enabled = True
        txtEmailAddress1.Enabled = True
        CheckBoxActiveInd.Enabled = True
        txtCompanyNameSearch.Enabled = False
        ListViewEmailLog.Items.Clear()
        txtCompanyName.Text = ""
        txtContactName.Text = ""
        txtEmailAddress1.Text = ""
        CheckBoxActiveInd.Checked = True
        ComboBoxState.Text = "NY"
        cmdAddNew1.Enabled = False
        cmdEdit1.Enabled = False
        cmdUpdate1.Enabled = True
        cmdCancel1.Enabled = True
        cmdDelete1.Enabled = False
        txtAddress1.Text = ""
        txtAddress2.Text = ""
        txtCity.Text = ""
        txtZip.Text = ""
        txtAddress1.Enabled = True
        txtAddress2.Enabled = True
        txtCity.Enabled = True
        ComboBoxState.Enabled = True
        txtZip.Enabled = True

        txtCompanyName.Focus()
    End Sub

    Private Sub cmdEdit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit1.Click
        If ListViewAddresses.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request. no Address selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        SaveSelectedAddress = ListViewAddresses.SelectedItems(0)
        OpModeAddress = AddEditMode.Edit

        ListViewAddresses.Enabled = False
        txtCompanyName.Enabled = True
        txtContactName.Enabled = True
        txtEmailAddress1.Enabled = True
        CheckBoxActiveInd.Enabled = True
        txtCompanyNameSearch.Enabled = False

        txtAddress1.Enabled = True
        txtAddress2.Enabled = True
        txtCity.Enabled = True
        ComboBoxState.Enabled = True
        txtZip.Enabled = True

        cmdAddNew1.Enabled = False
        cmdEdit1.Enabled = False
        cmdUpdate1.Enabled = True
        cmdCancel1.Enabled = True
        cmdDelete1.Enabled = False
        txtCompanyName.Focus()
    End Sub

    Private Sub cmdCancel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel1.Click
        OpModeAddress = AddEditMode.None
        ListViewAddresses.Enabled = True
        txtCompanyName.Enabled = False
        txtContactName.Enabled = False
        txtEmailAddress1.Enabled = False
        CheckBoxActiveInd.Enabled = False
        txtCompanyNameSearch.Enabled = True
        cmdAddNew1.Enabled = True
        cmdEdit1.Enabled = True
        cmdUpdate1.Enabled = False
        cmdCancel1.Enabled = False
        cmdDelete1.Enabled = True
        txtAddress1.Enabled = False
        txtAddress2.Enabled = False
        txtCity.Enabled = False
        ComboBoxState.Enabled = False
        txtZip.Enabled = True
        If Not SaveSelectedAddress Is Nothing Then
            ListViewAddresses_SelectedIndexChanged(Nothing, Nothing)
        Else
            If ListViewAddresses.Items.Count > 0 Then
                ListViewAddresses.Items(0).Selected = True
                ListViewAddresses.Items(0).EnsureVisible()
                ListViewAddresses_SelectedIndexChanged(Nothing, Nothing)
            Else
                txtCompanyName.Text = ""
                txtContactName.Text = ""
                txtEmailAddress1.Text = ""
                CheckBoxActiveInd.Checked = False
            End If
        End If
        gLoop_ResetErrors_Controls(ErrorProvider1, Me)

    End Sub

    Private Sub txtCompanyName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompanyName.TextChanged
        ErrorProvider1.SetError(txtCompanyName, "")
    End Sub

    Private Sub txtContactName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContactName.TextChanged
        ErrorProvider1.SetError(txtContactName, "")
    End Sub

    Private Sub txtEmailAddress1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmailAddress1.TextChanged
        ErrorProvider1.SetError(txtEmailAddress1, "")
    End Sub

    Private Sub cmdDelete1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete1.Click
        Dim ID As Long
        If ListViewAddresses.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete. No Address Record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to delete the Address Record " & ListViewTempLates.SelectedItems(0).Text & "?" & vbCrLf & vbCrLf & "It is highly recommended to use the Active Indicator instead of deleting record.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Try
            ID = CLng(ListViewAddresses.SelectedItems(0).Tag)
            If gSQLDeleteRecord("DELETE FROM EmailerAddressBook  WHERE AddressID=" & ID) Then
                ListViewEmailLog.Items.Clear()
                ListViewAddresses.Items.Remove(ListViewAddresses.SelectedItems(0))
                SaveSelectedAddress = Nothing
                If ListViewAddresses.SelectedItems.Count > 0 Then
                    ListViewAddresses_SelectedIndexChanged(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try
    End Sub

    Private Sub cmdUpdate1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate1.Click
        Dim ID As Long
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Try
            If SaveSelectedAddress Is Nothing And OpModeAddress = AddEditMode.Edit Then
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
                Exit Sub
            End If
            If txtCompanyName.Text = "" Then
                ErrorProvider1.SetError(txtCompanyName, "Unable to process update. The Address Company Name is required.")
                MsgBox("Unable to process update. The Address Company Name is required.", MsgBoxStyle.Exclamation)
                txtCompanyName.Focus()
                Exit Sub
            End If
            If txtAddress1.Text.Trim <> "" Or txtAddress2.Text.Trim <> "" Or txtCity.Text.Trim <> "" Then
                If txtAddress1.Text.Trim = "" Then
                    MsgBox("Unable to process update. Incomplete Address Information. Address is required.", MsgBoxStyle.Exclamation)
                    txtAddress1.Focus()
                    Exit Sub
                End If
                If txtCity.Text.Trim = "" Then
                    MsgBox("Unable to process update. Incomplete Address Information. City is required.", MsgBoxStyle.Exclamation)
                    txtCity.Focus()
                    Exit Sub
                End If
                If ComboBoxState.SelectedIndex = -1 Then
                    MsgBox("Unable to process update. Incomplete Address Information. State is required.", MsgBoxStyle.Exclamation)
                    ComboBoxState.Focus()
                    Exit Sub
                End If
                If txtZip.MaskCompleted = False Then
                    MsgBox("Unable to process update. Incomplete Address Information. Zip Code is required.", MsgBoxStyle.Exclamation)
                    txtZip.Focus()
                    Exit Sub
                End If
            End If

            'If txtEmailAddress1.Text = "" Then
            '    ErrorProvider1.SetError(txtEmailAddress1, "Unable to process update. The Email Address required.")
            '    MsgBox("Unable to process update. The Email Address is required.", MsgBoxStyle.Exclamation)
            '    txtEmailAddress1.Focus()
            '    Exit Sub
            'End If

            If gEmailCheck(txtEmailAddress1.Text) = False Then
                ErrorProvider1.SetError(txtEmailAddress1, "Unable to process update. Invalid Email Address.")
                MsgBox("Unable to process update. Invalid Email Address.", MsgBoxStyle.Exclamation)
                txtEmailAddress1.Focus()
                Exit Sub
            End If
            If OpModeAddress = AddEditMode.Edit Then
                ID = SaveSelectedAddress.Tag
            Else
                ID = 0
            End If

            Dim TA As New SqlClient.SqlDataAdapter("Select * from EmailerAddressBook  Where AddressID = " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("EmailerAddressBook")

            TA.Fill(dTab)

            If OpModeAddress = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("CompanyName") = txtCompanyName.Text.Trim
            TR("ContactName") = txtContactName.Text.Trim
            TR("EmailAddress1") = txtEmailAddress1.Text.Trim
            TR("ActiveInd") = IIf(CheckBoxActiveInd.Checked, 1, 0)

            TR("Address1") = txtAddress1.Text.Trim
            TR("Address2") = txtAddress2.Text.Trim
            TR("City") = txtCity.Text.Trim
            TR("Zip") = txtZip.Text.Trim
            TR("State") = ComboBoxState.Text.Trim

            If OpModeAddress = AddEditMode.AddNew Then
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
            If OpModeAddress = AddEditMode.AddNew Then

                Reader = gSQLGetDataReader("Select * from EmailerAddressBook  Where AddressID = IDENT_CURRENT('EmailerAddressBook')")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListViewAddresses.Items.Add(Reader("CompanyName").ToString, CInt(Val(Reader("ActiveInd").ToString)))
                    LI.Tag = "" & Reader("AddressID").ToString
                    If ListViewAddresses.SelectedItems.Count > 0 Then ListViewAddresses.SelectedItems(0).Selected = False
                    LI.Selected = True
                    LI.EnsureVisible()
                    ListViewAddresses_SelectedIndexChanged(Nothing, Nothing)
                    ID = CLng(Val(Reader("AddressID").ToString))
                    SaveSelectedAddress = LI
                Loop
                Reader.Close() : Reader.Dispose()
            Else
                SaveSelectedAddress.Text = txtContactName.Text
                SaveSelectedAddress.ImageIndex = IIf(CheckBoxActiveInd.Checked, 1, 0)

            End If
            OpModeAddress = AddEditMode.None
            ListViewAddresses.Enabled = True
            txtCompanyName.Enabled = False
            txtContactName.Enabled = False
            txtEmailAddress1.Enabled = False
            CheckBoxActiveInd.Enabled = False
            txtCompanyNameSearch.Enabled = True
            cmdAddNew1.Enabled = True
            cmdEdit1.Enabled = True
            cmdUpdate1.Enabled = False
            cmdCancel1.Enabled = False
            cmdDelete1.Enabled = True
            txtAddress1.Enabled = False
            txtAddress2.Enabled = False
            txtCity.Enabled = False
            ComboBoxState.Enabled = False
            txtZip.Enabled = False

            gLoop_ResetErrors_Controls(ErrorProvider1, Me)
            If ListViewAddresses.SelectedItems.Count > 0 Then
                ListViewAddresses_SelectedIndexChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub txtTemplateNameSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTemplateNameSearch.TextChanged
        Load_Templates()
    End Sub

    Private Sub txtCompanyNameSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompanyNameSearch.TextChanged
        Load_Addresses()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRemoveAttachement.Click
        txtAttachement.Text = ""
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub ListViewLog_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewLog.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewLog.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumn.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumn.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumn.Text =             m_SortingColumn.Text.Mid(2)
            m_SortingColumn.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumn.Text = "> " & m_SortingColumn.Text
        'Else
        'm_SortingColumn.Text = "< " & m_SortingColumn.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.ImageKey = "SORT1"
        Else
            m_SortingColumn.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewLog.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewLog.Sort()
    End Sub

    Private Sub ListViewLog_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewLog.DoubleClick
        If ListViewLog.SelectedItems.Count = 0 Then Exit Sub
        txtCompanyNameSearch.Text = ListViewLog.SelectedItems(0).Text
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub ListViewLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewLog.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompanyNameLogSearch.TextChanged
        Load_Log()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        Load_Log()
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        Load_Log()
    End Sub

End Class