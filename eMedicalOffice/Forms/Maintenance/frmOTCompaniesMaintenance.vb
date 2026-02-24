Public Class frmOTCompaniesMaintenance
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode
    Private Sub Load_Companies()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Reader = gSQLGetDataReader("Select * from OTCompanies Where OfficeID = " & gOfficeID & " Order by CompanyName")
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
        Loop
        Reader.Close() : Reader.Dispose()

        Dim LI As ListViewItem
        Reader = gSQLGetDataReader("SELECT DiagID, DiagName FROM Diagnostics WHERE (DiagTypeID = 3) ORDER BY DiagName")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewServices.Items.Add(Reader("DiagName").ToString)
            LI.Tag = Val(Reader("DiagID").ToString)
        Loop
        Reader.Close() : Reader.Dispose()




    End Sub
    Private Sub ClearServices()
        For Each LI As ListViewItem In ListViewServices.CheckedItems
            LI.Checked = False
        Next
    End Sub
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        cmdEdit_Click(Nothing, Nothing)
    End Sub
    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim ID As Long
        Dim Reader As SqlClient.SqlDataReader
        Clear_Controls()
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Try
            Application.DoEvents()
            Clear_Controls()
            cmdEdit.Enabled = True
            cmdDelete.Enabled = True
            ID = CLng(ListView1.SelectedItems(0).Tag)
            SaveSelectedItem = ListView1.SelectedItems(0)
            Reader = gSQLGetDataReader("Select * from OTCompanies Where CompanyID=" & ID)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                CheckBoxActiveInd.Checked = CBool(Val("" & Reader("ActiveInd").ToString))
                txtCompanyName.Text = "" & Reader("CompanyName").ToString
                txtTaxID.Text = "" & Reader("TaxID").ToString
                txtRegID.Text = "" & Reader("RegID").ToString
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
                txtContact1.Text = "" & Reader("Contact1").ToString
                txtContact2.Text = "" & Reader("Contact2").ToString
                txtContact1Phone.Text = "" & Reader("Contact1Phone").ToString
                txtContact2Phone.Text = "" & Reader("Contact2Phone").ToString
            Loop
            Reader.Close() : Reader.Dispose()
            ClearServices()
            Dim I As Integer
            Reader = gSQLGetDataReader("SELECT DiagID FROM OTCompanyDiagnostics WHERE CompanyID = " & ID)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                For Each LI As ListViewItem In ListViewServices.Items
                    If Val(Reader("DiagID")) = Val(LI.Tag) Then
                        LI.Checked = True
                    End If
                Next
            Loop
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            gProcess_Log(ex.Message, ex.StackTrace, True)
        End Try
    End Sub
    Private Sub Clear_Controls()
        gLoop_Clear_Controls(Me, TextBoxSearch)
        ClearServices()
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
        ListViewServices.Enabled = En
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
            gLoop_Text_PropperCase(Me)

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
            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
                Reader = gSQLGetDataReader("Select * from OTCompanies Where CompanyID<>" & ID & " and CompanyName='" & RBC(txtCompanyName.Text) & "'")
            Else
                ID = -1
                Reader = gSQLGetDataReader("Select * from OTCompanies Where CompanyName='" & RBC(txtCompanyName.Text) & "'")
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

            Dim TA As New SqlClient.SqlDataAdapter("SELECT * FROM OTCompanies Where CompanyID= " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            Dim TR As DataRow
            Dim dTab As New DataTable("OTCompanies")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("CompanyName") = txtCompanyName.Text
            TR("TaxID") = txtTaxID.Text
            TR("RegID") = txtRegID.Text
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
                gProcess_Log(ex.Message, ex.StackTrace, True)
                Exit Sub
            End Try
            dTab.Dispose()
            CB.Dispose()
            TA.Dispose()




            If OpMode = AddEditMode.AddNew Then
                Reader = gSQLGetDataReader("Select * from OTCompanies Where CompanyID = (Select MAX(CompanyID) from OTCompanies)")
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

            gSQLUpdateData("DELETE FROM OTCompanyDiagnostics Where CompanyID = " & ID)
            If Reader Is Nothing Then Exit Sub
            For Each LI In ListViewServices.CheckedItems
                gSQLUpdateData("INSERT INTO OTCompanyDiagnostics (CompanyID, DiagID) Values(" & ID & ", " & Val(LI.Tag) & ")")
            Next
            OpMode = AddEditMode.None
            Enable_Controls(False)
            gLoop_ResetErrors_Controls(ErrorProvider1, Me)
            If ListView1.SelectedItems.Count > 0 Then
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            gProcess_Log(ex.Message, ex.StackTrace, True)
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
        If gSQLDeleteRecord("DELETE FROM OTCompanies WHERE CompanyID=" & ID) Then
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
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        gSetup_GotFocus(Me)
        Load_Data()
        Load_Companies()
        Me.Cursor = Cursors.Default
        Application.DoEvents()
        txtCompanyName.AutoCompleteCustomSource = gAutocompleteAttorneyOffice
        txtTaxID.AutoCompleteCustomSource = gAutocompleteFname
        txtRegID.AutoCompleteCustomSource = gAutocompleteLName
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

    Private Sub txtTaxID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTaxID.TextChanged
        ErrorProvider1.SetError(txtTaxID, "")
    End Sub

    Private Sub txtRegID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegID.TextChanged
        ErrorProvider1.SetError(txtRegID, "")
    End Sub

    Private Sub txtContact1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContact1.TextChanged

    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        gSearchListView(ListView1, TextBoxSearch)
    End Sub
End Class