Imports System.Reflection
Imports log4net

Public Class frmAttorneyMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode

    Private Sub Load_Companies()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Try
            Reader = gSQLGetDataReader("Select * from Attorneys Where OfficeID = " & gOfficeID & " Order by CompanyName")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                LI = ListView1.Items.Add(Reader("CompanyName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                LI.Tag = "" & Reader("CompanyID").ToString
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
        gHighlightListviewItem(ListView1, False, False, Color.FromKnownColor(KnownColor.Highlight), Color.FromKnownColor(KnownColor.HighlightText))

        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Try
            Application.DoEvents()
            Clear_Controls()
            cmdEdit.Enabled = True
            cmdDelete.Enabled = True
            ID = CLng(ListView1.SelectedItems(0).Tag)
            SaveSelectedItem = ListView1.SelectedItems(0)
            Reader = gSQLGetDataReader("Select * from Attorneys Where CompanyID=" & ID)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                CheckBoxActiveInd.Checked = CBool(Val("" & Reader("ActiveInd").ToString))
                txtCompanyName.Text = "" & Reader("CompanyName").ToString
                txtAttorneyFName.Text = "" & Reader("AttorneyFName").ToString
                txtAttorneyLName.Text = "" & Reader("AttorneyLName").ToString
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
                txtContact1.Text = "" & Reader("Contact1").ToString
                txtContact2.Text = "" & Reader("Contact2").ToString
                txtContact1Phone.Text = "" & Reader("Contact1Phone").ToString
                txtContact2Phone.Text = "" & Reader("Contact2Phone").ToString
            Loop
            Load_Web_Settings(ID)
            Reader.Close() : Reader.Dispose()
            Cursor = Cursors.Default
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Load_Web_Settings(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        txtWebAdminUID.Text = ""
        txtWebAdminPWD.Text = ""
        txtWebAdminPWD.Tag = ""
        Reader = gSQLGetDataReader("SELECT  UserTypeID, SecID,  UserName, Password FROM WebLogins WHERE  UserTypeID = 6 AND OfficeID = " & gOfficeID & " AND UserID = " & ID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            txtWebAdminUID.Text = Reader("UserName").ToString
            txtWebAdminPWD.Text = Reader("Password").ToString
            txtWebAdminPWD.Tag = Reader("SecID").ToString
        Loop
        If txtWebAdminUID.Text <> "" Then CheckBox1.Checked = True
        Reader.Close() : Reader.Dispose()
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
        ButtonWebAdminRefresh.Enabled = En
        CheckBox1.Enabled = En
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
        txtWebAdminUID.Enabled = False
        txtWebAdminPWD.Enabled = False
        ButtonWebAdminRefresh.Enabled = False
        If CheckBox1.Checked Then
            txtWebAdminUID.Enabled = En
            txtWebAdminPWD.Enabled = En
            ButtonWebAdminRefresh.Enabled = En
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
    End Sub

    Private Function Validate_WebLogin(ByVal ID As Integer, ByVal UID As String, ByVal PWD As String) As Boolean
        If gSQLGetSingleValue("SELECT COUNT(*) FROM WebLogins WHERE (UserID <> " & ID & ") AND (UserName = '" & UID.ToSafeSQLString() & "')") > 0 Then
            Validate_WebLogin = False
        Else
            Validate_WebLogin = True
        End If

    End Function

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
            If txtAttorneyFName.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtAttorneyFName, "Unable to process update. The Attorney First Name is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Attorney First Name is required.", MsgBoxStyle.Exclamation)
                txtAttorneyFName.Focus()
                Exit Sub
            End If
            If txtAttorneyLName.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtAttorneyLName, "Unable to process update. The Attorney Last Name is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Attorney Last Name is required.", MsgBoxStyle.Exclamation)
                txtAttorneyLName.Focus()
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
                Reader = gSQLGetDataReader("Select * from Attorneys Where CompanyID<>" & ID & " and CompanyName='" & txtCompanyName.Text.ToSafeSQLString() & "'")
            Else
                ID = -1
                Reader = gSQLGetDataReader("Select * from Attorneys Where CompanyName='" & txtCompanyName.Text.ToSafeSQLString() & "'")
            End If
            If Reader.Read() = True Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtCompanyName, "Unable to process update. The The Office Name is already inuse.")
                MsgBox("Unable to process update." & vbCrLf & "The Company Name is already inuse.", MsgBoxStyle.Exclamation)
                txtCompanyName.Focus()
                txtCompanyName.SelectAll()
                Exit Sub
            End If
            Reader.Close() : Reader.Dispose()

            ''''    Web Security '''''''''''''''''''''''''''''''''''''
            Dim WebUserTypeID = 6
            If CheckBox1.Checked Then
                If txtWebAdminUID.Text.Trim = "" Then
                    TabControl1.SelectedIndex = 1
                    ErrorProvider1.SetError(txtWebAdminPWD, "Unable to process update. The Web User Name is required.")
                    MsgBox("Unable to process update." & vbCrLf & "The Web User Name is required.", MsgBoxStyle.Exclamation)
                    txtWebAdminUID.Focus()
                    Exit Sub
                End If

                If txtWebAdminUID.Text.Trim <> "" And txtWebAdminPWD.Text.Trim = "" Then
                    TabControl1.SelectedIndex = 1
                    ErrorProvider1.SetError(txtWebAdminPWD, "Unable to process update. You have specified Web User Name. The Web Password should be specified.")
                    MsgBox("Unable to process update." & vbCrLf & "You have specified Web User Name. The Web Password should be specified.", MsgBoxStyle.Exclamation)
                    txtWebAdminUID.Focus()
                    Exit Sub
                End If
                If txtWebAdminUID.Text.Trim = "" And txtWebAdminPWD.Text.Trim <> "" Then
                    TabControl1.SelectedIndex = 1
                    ErrorProvider1.SetError(txtWebAdminUID, "Unable to process update. You have specified Web Password. The Web User Name should be specified.")
                    MsgBox("Unable to process update." & vbCrLf & "You have specified Web Password. The Web User Name should be specified.", MsgBoxStyle.Exclamation)
                    txtWebAdminUID.Focus()
                    Exit Sub
                End If

                If Validate_WebLogin(ID, txtWebAdminUID.Text.ToSafeSQLString(), txtWebAdminPWD.Text.ToSafeSQLString()) = False Then
                    TabControl1.SelectedIndex = 1
                    ErrorProvider1.SetError(txtWebAdminUID, "Unable to process update. The Web Web User Name is already in use.")
                    MsgBox("Unable to process update." & vbCrLf & "The Web User Name is already in use." & vbCrLf & "Please choose another Web User Name.", MsgBoxStyle.Exclamation)
                    txtWebAdminUID.Focus()
                    txtWebAdminUID.SelectAll()
                    Exit Sub
                End If

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim TA As New SqlClient.SqlDataAdapter("SELECT * FROM Attorneys Where CompanyID= " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("Attorneys")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("CompanyName") = txtCompanyName.Text
            TR("AttorneyFName") = txtAttorneyFName.Text
            TR("AttorneyLName") = txtAttorneyLName.Text
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
            TR("Contact1") = txtContact1.Text
            TR("Contact2") = txtContact2.Text
            TR("OfficeID") = gOfficeID

            If txtContact1Phone.MaskCompleted Then TR("Contact1Phone") = txtContact1Phone.Text Else TR("Contact1Phone") = ""
            If txtContact2Phone.MaskCompleted Then TR("Contact2Phone") = txtContact2Phone.Text Else TR("Contact2Phone") = ""

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
                Reader = gSQLGetDataReader("Select * from Attorneys Where CompanyID = IDENT_CURRENT('Attorneys')")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListView1.Items.Add(Reader("CompanyName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                    LI.Tag = "" & Reader("CompanyID").ToString
                    ID = CLng(Val(Reader("CompanyID").ToString))
                    SaveSelectedItem = LI
                Loop
                Reader.Close() : Reader.Dispose()
                ''''''''''''    WebLogin
                If CheckBox1.Checked Then
                    gSQLUpdateData("INSERT INTO WebLogins ( UserID, OfficeID, UserName, Password, UserTypeID) VALUES(" & ID & ", " & gOfficeID & ", '" & txtWebAdminUID.Text.ToSafeSQLString() & "', '" & txtWebAdminUID.Text.ToSafeSQLString() & "', " & WebUserTypeID & ")")
                Else
                    gSQLUpdateData("DELETE FROM WebLogins WHERE UserID = " & ID & " and OfficeID = " & gOfficeID & " and UserTypeID = " & WebUserTypeID)

                End If
                If Not SaveSelectedItem Is Nothing Then
                    SaveSelectedItem.Selected = True
                    SaveSelectedItem.EnsureVisible()
                    ListView1_SelectedIndexChanged(Nothing, Nothing)
                End If
            Else
                If CheckBoxActiveInd.Checked = True Then
                    SaveSelectedItem.ImageIndex = 1
                Else
                    SaveSelectedItem.ImageIndex = 0
                End If
                SaveSelectedItem.Text = txtCompanyName.Text
                '''''''''''   Web Login
                If txtWebAdminUID.Visible Then
                    If txtWebAdminUID.Text <> "" Then
                        If IsNumeric(txtWebAdminPWD.Tag) = False Then
                            gSQLUpdateData("INSERT INTO WebLogins ( UserID, OfficeID, UserName, Password, UserTypeID) VALUES(" & ID & ", " & gOfficeID & ", '" & txtWebAdminUID.Text.ToSafeSQLString() & "', '" & txtWebAdminUID.Text.ToSafeSQLString() & "', " & WebUserTypeID & ")")
                        Else
                            gSQLUpdateData("UPDATE WebLogins SET UserTypeID=" & WebUserTypeID & ", UserName = '" & txtWebAdminUID.Text.ToSafeSQLString() & "', Password = '" & txtWebAdminPWD.Text.ToSafeSQLString() & "' Where SecID=" & Val(txtWebAdminPWD.Tag))
                        End If
                    Else
                        gSQLUpdateData("DELETE FROM WebLogins Where SecID=" & Val(txtWebAdminPWD.Tag))
                    End If
                Else
                    gSQLUpdateData("DELETE FROM WebLogins Where SecID=" & Val(txtWebAdminPWD.Tag))
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
        If gSQLDeleteRecord("DELETE FROM Attorneys WHERE CompanyID=" & ID) Then
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

    Private Sub frmAttorneyMaintenance_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
        txtCompanyName.AutoCompleteCustomSource = gAutocompleteAttorneyOffice
        txtAttorneyFName.AutoCompleteCustomSource = gAutocompleteFname
        txtAttorneyLName.AutoCompleteCustomSource = gAutocompleteLName
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

    Private Sub txtAttorneyFName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAttorneyFName.TextChanged
        ErrorProvider1.SetError(txtAttorneyFName, "")
    End Sub

    Private Sub txtAttorneyLName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAttorneyLName.TextChanged
        ErrorProvider1.SetError(txtAttorneyLName, "")
    End Sub

    Private Sub txtContact1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContact1.TextChanged

    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        gSearchListView(ListView1, TextBoxSearch)
    End Sub

    Private Sub ButtonWebAdminRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWebAdminRefresh.Click
        Produce_WebUserName(2)
    End Sub

    Private Sub Produce_WebUserName(Optional ByVal Force As Integer = 0)
        Dim KeyGen As RandomKeyGenerator = New RandomKeyGenerator
        KeyGen.KeyLetters = "abcdefghkmnpqrstuvwxyz".ToUpper
        KeyGen.KeyNumbers = "123456789"
        KeyGen.KeyChars = 4
        If txtWebAdminUID.Text = "" Or Force = 2 Then txtWebAdminUID.Text = gSQLGetSingleValue("SELECT IDENT_CURRENT('WebLogins')") + 1 & "A" & KeyGen.Generate
        KeyGen.KeyChars = 5
        If txtWebAdminPWD.Text = "" Or Force = 2 Then txtWebAdminPWD.Text = "P" & KeyGen.Generate
    End Sub

    Private Sub txtWebAdminUID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWebAdminUID.TextChanged
        ErrorProvider1.SetError(txtWebAdminUID, "")
    End Sub

    Private Sub txtWebAdminPWD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWebAdminPWD.TextChanged
        ErrorProvider1.SetError(txtWebAdminPWD, "")
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If OpMode = AddEditMode.None Then Exit Sub
        If CheckBox1.Checked Then
            txtWebAdminUID.Enabled = True
            txtWebAdminPWD.Enabled = True
            ButtonWebAdminRefresh.Enabled = True
            ButtonWebAdminRefresh_Click(Nothing, Nothing)
        Else
            txtWebAdminUID.Enabled = False
            txtWebAdminPWD.Enabled = False
            txtWebAdminUID.Text = ""
            txtWebAdminPWD.Text = ""
            ButtonWebAdminRefresh.Enabled = False
        End If
    End Sub

End Class