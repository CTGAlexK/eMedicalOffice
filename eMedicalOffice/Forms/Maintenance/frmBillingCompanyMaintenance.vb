Imports System.Reflection
Imports log4net

Public Class frmBillingCompanyMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode

    Private Sub Load_Companies()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Try
            Reader = gSQLGetDataReader("Select * from BillingCompanies Order by CompanyName ")  ' 1 - Inhouse Billing Company
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                LI = ListView1.Items.Add(Reader("CompanyName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                LI.Tag = "" & Reader("BillingCompanyID").ToString
            Loop
            Reader.Close() : Reader.Dispose()
            If ListView1.Items.Count > 0 Then
                ListView1.Items(0).Selected = True
                ListView1.Items(0).EnsureVisible()
                ' ListView1_SelectedIndexChanged(Nothing, Nothing)
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
        Dim Reader As SqlClient.SqlDataReader
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim ComboText As String() = {""}
        Dim ComboValue As String() = {""}
        Try
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

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        cmdEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim ID As Long
        Dim Reader As SqlClient.SqlDataReader

        cmdDelete.Enabled = False
        cmdEdit.Enabled = False
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Clear_Controls()
        cmdEdit.Enabled = True
        cmdDelete.Enabled = True
        ID = CLng(ListView1.SelectedItems(0).Tag)
        SaveSelectedItem = ListView1.SelectedItems(0)
        Reader = gSQLGetDataReader("Select * from BillingCompanies Where BillingCompanyID=" & ID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            CheckBoxActiveInd.Checked = CBool(Val("" & Reader("ActiveInd").ToString))
            txtCompanyName.Text = "" & Reader("CompanyName").ToString
            txtTaxID.Text = "" & Reader("TaxID").ToString
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
            txtEmployee1.Text = "" & Reader("Employee1").ToString
            txtEmployeePhone1.Text = "" & Reader("EmployeePhone1").ToString
            txtEmployee2.Text = "" & Reader("Employee2").ToString
            txtEmployeePhone2.Text = "" & Reader("EmployeePhone2").ToString
            txtEmployee3.Text = "" & Reader("Employee3").ToString
            txtEmployeePhone3.Text = "" & Reader("EmployeePhone3").ToString
            txtEmployee4.Text = "" & Reader("Employee4").ToString
            txtEmployeePhone4.Text = "" & Reader("EmployeePhone4").ToString
        Loop
        Reader.Close() : Reader.Dispose()

        Reader = gSQLGetDataReader("SELECT SecID,  UserID, UserName, Password FROM WebLogins WHERE  OfficeID = " & ID & " AND   UserTypeID = 4 ORDER BY UserID")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            Select Case Reader("UserID")
                Case 1
                    TextBoxWebAccess1UID.Text = "" & Reader("UserName").ToString
                    TextBoxWebAccess1PWD.Text = "" & Reader("Password").ToString
                    TextBoxWebAccess1PWD.Tag = Reader("SecID").ToString
                Case 2
                    TextBoxWebAccess2UID.Text = "" & Reader("UserName").ToString
                    TextBoxWebAccess2PWD.Text = "" & Reader("Password").ToString
                    TextBoxWebAccess2PWD.Tag = Reader("SecID").ToString
                Case 3
                    TextBoxWebAccess3UID.Text = "" & Reader("UserName").ToString
                    TextBoxWebAccess3PWD.Text = "" & Reader("Password").ToString
                    TextBoxWebAccess3PWD.Tag = Reader("SecID").ToString
                Case 4
                    TextBoxWebAccess4UID.Text = "" & Reader("UserName").ToString
                    TextBoxWebAccess4PWD.Text = "" & Reader("Password").ToString
                    TextBoxWebAccess4PWD.Tag = Reader("SecID").ToString
            End Select
        Loop
        Reader.Close() : Reader.Dispose()
        Cursor = Cursors.Default
        If CLng(ListView1.SelectedItems(0).Tag) = 1 Then
            cmdDelete.Enabled = False
            CheckBoxActiveInd.Enabled = False
        Else
            cmdDelete.Enabled = True
            CheckBoxActiveInd.Enabled = True
        End If
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
        ButtonWebRefresh1.Enabled = En
        ButtonWebRefresh2.Enabled = En
        ButtonWebRefresh3.Enabled = En
        ButtonWebRefresh4.Enabled = En
        cmdEdit.Enabled = En
        If ListView1.SelectedItems.Count > 0 Then
            If CLng(ListView1.SelectedItems(0).Tag) = 1 Then
                CheckBoxActiveInd.Enabled = False
                CheckBoxActiveInd.Checked = True
                cmdDelete.Enabled = False
            Else
                CheckBoxActiveInd.Enabled = True
                cmdDelete.Enabled = En
            End If
        Else
            cmdDelete.Enabled = False
            cmdEdit.Enabled = False
        End If
    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        Clear_Controls()
        ComboBoxState.Text = gDefaultState
        CheckBoxActiveInd.Checked = True
        TabControl1.SelectedIndex = 0
        txtCompanyName.Focus()
        Produce_WebUserName()
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
        txtCompanyName.Focus()
        txtCompanyName.SelectAll()
        Produce_WebUserName()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ID As Long
        Dim LI As ListViewItem
        Dim ProcCount As Integer = 0
        Dim Reader As SqlClient.SqlDataReader
        gLoop_Trim_Controls(Me)
        gLoop_Text_PropperCase(Me)

        Try
            If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
                Exit Sub
            End If
            If txtCompanyName.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtCompanyName, "Unable to process update. The Office Name is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Office Name is required.", MsgBoxStyle.Exclamation)
                txtCompanyName.Focus()
                Exit Sub
            End If
            If txtEmail.Text <> "" AndAlso gEmailCheck(txtEmail.Text) = False Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtEmail, "Unable to process update. Invalid Email address specified.")
                MsgBox("Unable to process update." & vbCrLf & "Invalid Email address specified.", MsgBoxStyle.Exclamation)
                txtEmail.Focus()
                Exit Sub
            End If
            If InStr(TextBoxWebAccess1UID.Text, "'") Then
                TabControl1.SelectedIndex = 1
                MsgBox("Unable to process update." & vbCrLf & "Invalid character in the Employee 1 Web Access User Name.", MsgBoxStyle.Exclamation)
                TextBoxWebAccess1UID.Focus()
                Exit Sub
            End If

            If InStr(TextBoxWebAccess1PWD.Text, "'") Then
                TabControl1.SelectedIndex = 1
                MsgBox("Unable to process update." & vbCrLf & "Invalid character in the Employee 1 Web Access Password.", MsgBoxStyle.Exclamation)
                TextBoxWebAccess1PWD.Focus()
                Exit Sub
            End If

            If InStr(TextBoxWebAccess2UID.Text, "'") Then
                TabControl1.SelectedIndex = 1
                MsgBox("Unable to process update." & vbCrLf & "Invalid character in the Employee 2 Web Access User Name.", MsgBoxStyle.Exclamation)
                TextBoxWebAccess2UID.Focus()
                Exit Sub
            End If

            If InStr(TextBoxWebAccess2PWD.Text, "'") Then
                TabControl1.SelectedIndex = 1
                MsgBox("Unable to process update." & vbCrLf & "Invalid character in the Employee 2 Web Access Password.", MsgBoxStyle.Exclamation)
                TextBoxWebAccess2PWD.Focus()
                Exit Sub
            End If

            If InStr(TextBoxWebAccess3UID.Text, "'") Then
                TabControl1.SelectedIndex = 1
                MsgBox("Unable to process update." & vbCrLf & "Invalid character in the Employee 3 Web Access User Name.", MsgBoxStyle.Exclamation)
                TextBoxWebAccess2UID.Focus()
                Exit Sub
            End If

            If InStr(TextBoxWebAccess3PWD.Text, "'") Then
                TabControl1.SelectedIndex = 1
                MsgBox("Unable to process update." & vbCrLf & "Invalid character in the Employee 3 Web Access Password.", MsgBoxStyle.Exclamation)
                TextBoxWebAccess3PWD.Focus()
                Exit Sub
            End If

            If InStr(TextBoxWebAccess4UID.Text, "'") Then
                TabControl1.SelectedIndex = 1
                MsgBox("Unable to process update." & vbCrLf & "Invalid character in the Employee 4 Web Access User Name.", MsgBoxStyle.Exclamation)
                TextBoxWebAccess4UID.Focus()
                Exit Sub
            End If

            If InStr(TextBoxWebAccess4PWD.Text, "'") Then
                TabControl1.SelectedIndex = 1
                MsgBox("Unable to process update." & vbCrLf & "Invalid character in the Employee 4 Web Access Password.", MsgBoxStyle.Exclamation)
                TextBoxWebAccess4PWD.Focus()
                Exit Sub
            End If

            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
                Reader = gSQLGetDataReader("Select * from BillingCompanies Where BillingCompanyID<>" & ID & " and CompanyName='" & txtCompanyName.Text.ToSafeSQLString() & "'")
            Else
                ID = -1
                Reader = gSQLGetDataReader("Select * from BillingCompanies Where CompanyName='" & txtCompanyName.Text.ToSafeSQLString() & "'")
            End If
            If Reader.HasRows = True Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtCompanyName, "Unable to process update. The Billing Company Name is already exist.")
                MsgBox("Unable to process update." & vbCrLf & "The Billing Company Name is already exist.", MsgBoxStyle.Exclamation)
                txtCompanyName.Focus()
                txtCompanyName.SelectAll()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()

            Dim TA As New SqlClient.SqlDataAdapter("SELECT * FROM BillingCompanies Where BillingCompanyID= " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("BillingCompanies")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("CompanyName") = txtCompanyName.Text
            TR("TaxID") = txtTaxID.Text
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
            TR("Comments") = txtComments.Text.Trim
            TR("Employee1") = txtEmployee1.Text.Trim
            TR("EmployeePhone1") = txtEmployeePhone1.Text.Trim
            TR("Employee2") = txtEmployee2.Text.Trim
            TR("EmployeePhone2") = txtEmployeePhone2.Text.Trim
            TR("Employee3") = txtEmployee3.Text.Trim
            TR("EmployeePhone3") = txtEmployeePhone3.Text.Trim
            TR("Employee4") = txtEmployee4.Text.Trim
            TR("EmployeePhone4") = txtEmployeePhone4.Text.Trim

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
                Reader = gSQLGetDataReader("Select * from BillingCompanies Where BillingCompanyID = IDENT_CURRENT('BillingCompanies')")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListView1.Items.Add(Reader("CompanyName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                    LI.Tag = "" & Reader("BillingCompanyID").ToString
                    If ListView1.SelectedItems.Count > 0 Then ListView1.SelectedItems(0).Selected = False
                    LI.Selected = True
                    LI.EnsureVisible()
                    ListView1_SelectedIndexChanged(Nothing, Nothing)
                    ID = CLng(Val(Reader("BillingCompanyID").ToString))
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

            If txtEmployee1.Text <> "" Then
                If IsNumeric(TextBoxWebAccess1PWD.Tag) = False Then
                    gSQLUpdateData("INSERT INTO WebLogins ( UserID, OfficeID, UserName, Password, UserTypeID) VALUES(1, " & ID & ", '" & TextBoxWebAccess1UID.Text.ToSafeSQLString() & "', '" & TextBoxWebAccess1PWD.Text.ToSafeSQLString() & "', 4)")
                Else
                    gSQLUpdateData("UPDATE WebLogins SET UserName = '" & TextBoxWebAccess1UID.Text.ToSafeSQLString() & "', Password = '" & TextBoxWebAccess1PWD.Text.ToSafeSQLString() & "' WHERE SecID = " & Val(TextBoxWebAccess1PWD.Tag))
                End If
            Else
                If IsNumeric(TextBoxWebAccess1PWD.Tag) = True Then
                    gSQLUpdateData("DELETE FROM WebLogins WHERE SecID = " & Val(TextBoxWebAccess1PWD.Tag))
                End If
            End If

            If txtEmployee2.Text <> "" Then
                If IsNumeric(TextBoxWebAccess2PWD.Tag) = False Then
                    gSQLUpdateData("INSERT INTO WebLogins ( UserID, OfficeID, UserName, Password, UserTypeID) VALUES(2, " & ID & ", '" & TextBoxWebAccess2UID.Text.ToSafeSQLString() & "', '" & TextBoxWebAccess2PWD.Text.ToSafeSQLString() & "', 4)")
                Else
                    gSQLUpdateData("UPDATE WebLogins SET UserName = '" & TextBoxWebAccess2UID.Text.ToSafeSQLString() & "', Password = '" & TextBoxWebAccess2PWD.Text.ToSafeSQLString() & "' WHERE SecID = " & Val(TextBoxWebAccess2PWD.Tag))
                End If
            Else
                If IsNumeric(TextBoxWebAccess2PWD.Tag) = True Then
                    gSQLUpdateData("DELETE FROM WebLogins WHERE SecID = " & Val(TextBoxWebAccess2PWD.Tag))
                End If
            End If

            If txtEmployee3.Text <> "" Then
                If IsNumeric(TextBoxWebAccess3PWD.Tag) = False Then
                    gSQLUpdateData("INSERT INTO WebLogins ( UserID, OfficeID, UserName, Password, UserTypeID) VALUES(3, " & ID & ", '" & TextBoxWebAccess3UID.Text.ToSafeSQLString() & "', '" & TextBoxWebAccess3PWD.Text.ToSafeSQLString() & "', 4)")
                Else
                    gSQLUpdateData("UPDATE WebLogins SET UserName = '" & TextBoxWebAccess3UID.Text.ToSafeSQLString() & "', Password = '" & TextBoxWebAccess3PWD.Text.ToSafeSQLString() & "' WHERE SecID = " & Val(TextBoxWebAccess3PWD.Tag))
                End If
            Else
                If IsNumeric(TextBoxWebAccess3PWD.Tag) = True Then
                    gSQLUpdateData("DELETE FROM WebLogins WHERE SecID = " & Val(TextBoxWebAccess3PWD.Tag))
                End If
            End If

            If txtEmployee4.Text <> "" Then
                If IsNumeric(TextBoxWebAccess4PWD.Tag) = False Then
                    gSQLUpdateData("INSERT INTO WebLogins ( UserID, OfficeID, UserName, Password, UserTypeID) VALUES(4, " & ID & ", '" & TextBoxWebAccess4UID.Text.ToSafeSQLString() & "', '" & TextBoxWebAccess4PWD.Text.ToSafeSQLString() & "', 4)")
                Else
                    gSQLUpdateData("UPDATE WebLogins SET UserName = '" & TextBoxWebAccess4UID.Text.ToSafeSQLString() & "', Password = '" & TextBoxWebAccess4PWD.Text.ToSafeSQLString() & "' WHERE SecID = " & Val(TextBoxWebAccess4PWD.Tag))
                End If
            Else
                If IsNumeric(TextBoxWebAccess4PWD.Tag) = True Then
                    gSQLUpdateData("DELETE FROM WebLogins WHERE SecID = " & Val(TextBoxWebAccess4PWD.Tag))
                End If
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
            MsgBox("Unable to delete. No Office selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to delete the office " & ListView1.SelectedItems(0).Text & "?" & vbCrLf & vbCrLf & "It is highly recommended to use the Active Indicator to disable an Office.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ID = CLng(ListView1.SelectedItems(0).Tag)
        If gSQLDeleteRecord("DELETE FROM BillingCompanies WHERE BillingCompanyID=" & ID) Then
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

    Private Sub frmBilling_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmBilling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        gSetup_GotFocus(Me)
        Load_Data()
        Load_Companies()
        Cursor = Cursors.Default
        Application.DoEvents()
        txtAddress1.AutoCompleteCustomSource = gAutocompleteAddress
        txtCity.AutoCompleteCustomSource = gAutocompleteCity
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

    Private Sub txtContact1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        gSearchListView(ListView1, TextBoxSearch)
    End Sub

    Private Sub Produce_WebUserName(Optional ByVal Force As Integer = 0)
        Dim KeyGen As RandomKeyGenerator = New RandomKeyGenerator
        KeyGen.KeyLetters = "abcdefghkmnpqrstuvwxyz".ToUpper
        KeyGen.KeyNumbers = "123456789"
        KeyGen.KeyChars = 4
        If TextBoxWebAccess1UID.Text = "" Or Force = 1 Then TextBoxWebAccess1UID.Text = gSQLGetSingleValue("SELECT IDENT_CURRENT('WebLogins')") + 1 & "R" & KeyGen.Generate
        If TextBoxWebAccess2UID.Text = "" Or Force = 2 Then TextBoxWebAccess2UID.Text = gSQLGetSingleValue("SELECT IDENT_CURRENT('WebLogins')") + 2 & "R" & KeyGen.Generate
        If TextBoxWebAccess3UID.Text = "" Or Force = 3 Then TextBoxWebAccess3UID.Text = gSQLGetSingleValue("SELECT IDENT_CURRENT('WebLogins')") + 3 & "R" & KeyGen.Generate
        If TextBoxWebAccess4UID.Text = "" Or Force = 4 Then TextBoxWebAccess4UID.Text = gSQLGetSingleValue("SELECT IDENT_CURRENT('WebLogins')") + 4 & "R" & KeyGen.Generate
        KeyGen.KeyChars = 5
        If TextBoxWebAccess1PWD.Text = "" Or Force = 1 Then TextBoxWebAccess1PWD.Text = "P" & KeyGen.Generate
        If TextBoxWebAccess2PWD.Text = "" Or Force = 2 Then TextBoxWebAccess2PWD.Text = "P" & KeyGen.Generate
        If TextBoxWebAccess3PWD.Text = "" Or Force = 3 Then TextBoxWebAccess3PWD.Text = "P" & KeyGen.Generate
        If TextBoxWebAccess4PWD.Text = "" Or Force = 4 Then TextBoxWebAccess4PWD.Text = "P" & KeyGen.Generate
    End Sub

    Private Sub ButtonWebRefresh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWebRefresh1.Click
        Produce_WebUserName(1)
    End Sub

    Private Sub ButtonWebRefresh2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWebRefresh2.Click
        Produce_WebUserName(2)
    End Sub

    Private Sub ButtonWebRefresh3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWebRefresh3.Click
        Produce_WebUserName(3)
    End Sub

    Private Sub ButtonWebRefresh4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWebRefresh4.Click
        Produce_WebUserName(4)
    End Sub

End Class