Imports System.Reflection
Imports log4net

Public Class frmTransportationCompaniesMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode

    Private Sub Load_Companies()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Reader = gSQLGetDataReader("Select * from TransportationCompanies Order by CompanyName")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("CompanyName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
            LI.Tag = "" & Reader("CompanyID").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
            cmdEdit.Enabled = True
            cmdDelete.Enabled = True
        End If
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim ComboText As String() = {""}
        Dim ComboValue As String() = {""}
        Reader = gSQLGetDataReader("Select DISTINCT State, ShowOrder from States Order by ShowOrder")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxState.Items.Add(Reader("State").ToString)
            ComboBoxMailingState.Items.Add(Reader("State").ToString)
        Loop
        Reader.Close() : Reader.Dispose()

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
        cmdDelete.Enabled = True
        ID = CLng(ListView1.SelectedItems(0).Tag)
        SaveSelectedItem = ListView1.SelectedItems(0)
        Reader = gSQLGetDataReader("Select * from TransportationCompanies Where CompanyID=" & ID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            CheckBoxActiveInd.Checked = CBool(Val("" & Reader("ActiveInd").ToString))
            txtCompanyName.Text = "" & Reader("CompanyName").ToString
            txtLIC.Text = "" & Reader("LIC").ToString
            txtAddress1.Text = "" & Reader("Address1").ToString
            txtAddress2.Text = "" & Reader("Address2").ToString
            txtCity.Text = "" & Reader("City").ToString
            ComboBoxState.Text = "" & Reader("State").ToString
            txtZip.Text = "" & Reader("Zip").ToString
            txtPhone1.Text = "" & Reader("Phone1").ToString
            txtPhone2.Text = "" & Reader("Phone2").ToString
            txtPhone3.Text = "" & Reader("Phone3").ToString
            txtFax1.Text = "" & Reader("Fax1").ToString
            txtFax2.Text = "" & Reader("Fax2").ToString
            txtEmail.Text = "" & Reader("eMail").ToString
            txtComments.Text = "" & Reader("Comments").ToString
            txtMailingAddress1.Text = "" & Reader("MailingAddress1").ToString
            txtMailingAddress2.Text = "" & Reader("MailingAddress2").ToString
            txtMailingCity.Text = "" & Reader("MailingCity").ToString
            txtMailingZip.Text = "" & Reader("MailingZip").ToString
            ComboBoxMailingState.Text = "" & Reader("MailingState").ToString
            txtContact1.Text = "" & Reader("Contact1").ToString
            txtContact2.Text = "" & Reader("Contact2").ToString
            txtContact1Phone.Text = "" & Reader("Contact1Phone").ToString
            txtContact2Phone.Text = "" & Reader("Contact2Phone").ToString
            txtQuantityVoyage.Text = Reader("QuantityVoyage").ToString
            txtRate.Text = Format(Val(Reader("Rate").ToString), "##.00")
        Loop
        Reader.Close() : Reader.Dispose()
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
        gSetup_GotFocus(Me)
        ComboBoxState.Text = gDefaultState
        CheckBoxActiveInd.Checked = True
        TabControl1.SelectedIndex = 0
        txtCompanyName.Focus()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        OpMode = AddEditMode.None
        Enable_Controls(False)
        gLoop_ResetErrors_Controls(ErrorProvider1, Me)
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
        gSetup_GotFocus(Me)
        If TabControl1.SelectedIndex = 0 Then
            txtCompanyName.Focus()
            txtCompanyName.SelectAll()
        Else
            txtMailingAddress1.Focus()
            txtMailingAddress1.SelectAll()
        End If
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ID As Long
        Dim LI As ListViewItem
        Dim ProcCount As Integer = 0
        Dim Reader As SqlClient.SqlDataReader
        Try
            If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
                Exit Sub
            End If
            gLoop_Trim_Controls(Me)
            gLoop_Text_PropperCase(Me, txtLIC)
            If txtCompanyName.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtCompanyName, "Unable to process update. The Transportation Company Name is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Transportation Company Name is required.", MsgBoxStyle.Exclamation)
                txtCompanyName.Focus()
                Exit Sub
            End If
            If txtPhone1.MaskCompleted = False Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtPhone1, "Unable to process update. Missing or Incomplete Phone 1")
                MsgBox("Unable to process update." & vbCrLf & "Missing or Incomplete Phone 1", MsgBoxStyle.Exclamation)
                txtPhone1.Focus()
                Exit Sub
            End If

            If txtEmail.Text <> "" AndAlso gEmailCheck(txtEmail.Text) = False Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtEmail, "Unable to process update. Invalid Email address specified.")
                MsgBox("Unable to process update." & vbCrLf & "Invalid Email address specified.", MsgBoxStyle.Exclamation)
                txtEmail.Focus()
                Exit Sub
            End If
            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
                Reader = gSQLGetDataReader("Select * from TransportationCompanies Where CompanyID<>" & ID & " and CompanyName='" & txtCompanyName.Text.ToSafeSQLString() & "'")
            Else
                ID = -1
                Reader = gSQLGetDataReader("Select * from TransportationCompanies Where CompanyName='" & txtCompanyName.Text.ToSafeSQLString() & "'")
            End If
            If Reader.Read() = True Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtCompanyName, "Unable to process update. The Company Name is already inuse.")
                MsgBox("Unable to process update." & vbCrLf & "The Company Name is already inuse.", MsgBoxStyle.Exclamation)
                txtCompanyName.Focus()
                txtCompanyName.SelectAll()
                Exit Sub
            End If
            If txtQuantityVoyage.Text = "" Then txtQuantityVoyage.Text = "0"
            If txtRate.Text = "" Then txtRate.Text = "0"

            If IsNumeric(txtQuantityVoyage.Text) = False Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtQuantityVoyage, "Unable to process update. Invalid Quantity Voyage. The Quantity Voyage should be numeric value.")
                MsgBox("Unable to process update." & vbCrLf & "Invalid Quantity Voyage. The Quantity Voyage should be numeric value.", MsgBoxStyle.Exclamation)
                txtQuantityVoyage.Focus()
                Exit Sub
            End If
            If IsNumeric(txtRate.Text) = False Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtRate, "Unable to process update. Invalid Rate. The Rate should be numeric value.")
                MsgBox("Unable to process update." & vbCrLf & "Invalid Rate. The Rate should be numeric value.", MsgBoxStyle.Exclamation)
                txtRate.Focus()
                Exit Sub
            End If

            Reader.Close() : Reader.Dispose()

            Dim TA As New SqlClient.SqlDataAdapter("SELECT * FROM TransportationCompanies Where CompanyID= " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("TransportationCompanies")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("CompanyName") = txtCompanyName.Text
            TR("LIC") = txtLIC.Text
            TR("Address1") = txtAddress1.Text
            TR("Address2") = txtAddress2.Text
            TR("City") = txtCity.Text
            TR("State") = ComboBoxState.Text
            If txtZip.MaskCompleted Then TR("Zip") = txtZip.Text Else TR("Zip") = ""
            If txtPhone1.MaskCompleted Then TR("Phone1") = txtPhone1.Text Else TR("Phone1") = ""
            If txtPhone2.MaskCompleted Then TR("Phone2") = txtPhone2.Text Else TR("Phone2") = ""
            If txtPhone3.MaskCompleted Then TR("Phone3") = txtPhone3.Text Else TR("Phone3") = ""
            If txtFax1.MaskCompleted Then TR("Fax1") = txtFax1.Text Else TR("Fax1") = ""
            If txtFax2.MaskCompleted Then TR("Fax2") = txtFax2.Text Else TR("Fax2") = ""
            TR("eMail") = txtEmail.Text
            TR("ActiveInd") = IIf(CheckBoxActiveInd.Checked, 1, 0)
            TR("Comments") = txtComments.Text
            TR("QuantityVoyage") = Val(txtQuantityVoyage.Text)
            TR("Rate") = Val(txtRate.Text)

            TR("Contact1") = txtContact1.Text
            TR("Contact2") = txtContact2.Text
            If txtContact1Phone.MaskCompleted Then TR("Contact1Phone") = txtContact1Phone.Text Else TR("Contact1Phone") = ""
            If txtContact2Phone.MaskCompleted Then TR("Contact2Phone") = txtContact2Phone.Text Else TR("Contact2Phone") = ""

            TR("MailingAddress1") = txtMailingAddress1.Text
            TR("MailingAddress2") = txtMailingAddress2.Text
            TR("MailingCity") = txtMailingCity.Text
            If txtMailingZip.MaskCompleted Then TR("MailingZip") = txtMailingZip.Text Else TR("MailingZip") = ""
            TR("MailingState") = ComboBoxMailingState.Text

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
                Reader = gSQLGetDataReader("Select * from TransportationCompanies Where CompanyID = IDENT_CURRENT('TransportationCompanies')")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListView1.Items.Add(Reader("CompanyName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                    LI.Tag = "" & Reader("CompanyID").ToString
                    If ListView1.SelectedItems.Count > 0 Then ListView1.SelectedItems(0).Selected = False
                    LI.Selected = True
                    LI.EnsureVisible()
                    ListView1_SelectedIndexChanged(Nothing, Nothing)
                    ID = CLng(Val(Reader("CompanyID").ToString))
                    SaveSelectedItem = LI
                Loop
                Reader.Close() : Reader.Dispose()
            Else
                If CheckBoxActiveInd.Checked = True Then
                    SaveSelectedItem.ImageIndex = 1
                Else
                    SaveSelectedItem.ImageIndex = 0
                End If
                SaveSelectedItem.Text = txtCompanyName.Text
            End If
            OpMode = AddEditMode.None
            Enable_Controls(False)
            gLoop_ResetErrors_Controls(ErrorProvider1, Me)
            If ListView1.SelectedItems.Count > 0 Then
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim ID As Long
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete. No Company selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to delete the Transportation Company " & ListView1.SelectedItems(0).Text & "?" & vbCrLf & vbCrLf & "It is highly recommended to use the Active Indicator to disable profile.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ID = CLng(ListView1.SelectedItems(0).Tag)
        If gSQLDeleteRecord("DELETE FROM TransportationCompanies WHERE CompanyID=" & ID) Then
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

    Private Sub frmTransportationCompaniesMaintenance_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmOfficeMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        gSetup_GotFocus(Me)
        Load_Data()
        Load_Companies()
        Cursor = Cursors.Default
        Application.DoEvents()
        txtAddress1.AutoCompleteCustomSource = gAutocompleteAddress
        txtCity.AutoCompleteCustomSource = gAutocompleteCity
        txtCompanyName.AutoCompleteCustomSource = gAutocompleteTransportationCompanyName
        txtMailingAddress1.AutoCompleteCustomSource = gAutocompleteAddress
        txtMailingCity.AutoCompleteCustomSource = gAutocompleteCity

    End Sub

    Private Sub frmAdjusterMaintenance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cmdUpdate.Enabled Then
            If MsgBox("You have unsaved data. Discard changes?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()

    End Sub

    Private Sub txtCompanyName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompanyName.TextChanged
        ErrorProvider1.SetError(txtCompanyName, "")
    End Sub

    Private Sub txtAddress1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress1.TextChanged
        ErrorProvider1.SetError(txtAddress1, "")
    End Sub

    Private Sub txtAddress2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress2.TextChanged
        ErrorProvider1.SetError(txtAddress2, "")
    End Sub

    Private Sub txtCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCity.TextChanged
        ErrorProvider1.SetError(txtCity, "")
    End Sub

    Private Sub ComboBoxState_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxState.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxState, "")
    End Sub

    Private Sub txtQuantityVoyage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantityVoyage.KeyPress
        e.Handled = gNumbersOnly(e.KeyChar, txtQuantityVoyage)
    End Sub

    Private Sub txtQuantityVoyage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantityVoyage.TextChanged
        ErrorProvider1.SetError(txtQuantityVoyage, "")
    End Sub

    Private Sub txtRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate.KeyPress
        e.Handled = gNumbersOnly(e.KeyChar, txtRate)
    End Sub

    Private Sub txtRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRate.TextChanged
        ErrorProvider1.SetError(txtRate, "")
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        gSearchListView(ListView1, TextBoxSearch)
    End Sub

    Private Sub txtPhone1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhone1.TextChanged
        ErrorProvider1.SetError(txtPhone1, "")
    End Sub

End Class