Imports System.Reflection
Imports log4net

Public Class frmReferringOfficesMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode
    Public RefOffice As String
    Private Sub Load_ReferringOffices()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Reader = gSQLGetDataReader("Select * from ReferringOffices Order by OfficeName")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("OfficeName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
            LI.Tag = "" & Reader("OfficeID").ToString
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
    Private Sub Load_Doctors()
        Dim i As Integer
        Dim H = 10
        For i = 2 To gReferringOfficeDoctors
            Dim lblPrev As Label = CType(Me.Controls.Find("lblWeb" & i - 1, True).FirstOrDefault(), Label)
            Dim lblUserNamePrev As Label = CType(Me.Controls.Find("lblUserName" & i - 1, True).FirstOrDefault(), Label)
            Dim lblPasswordPrev As Label = CType(Me.Controls.Find("lblPassword" & i - 1, True).FirstOrDefault(), Label)
            Dim lblNPIPrev As Label = CType(Me.Controls.Find("lblNPI" & i - 1, True).FirstOrDefault(), Label)
            Dim txtDoctorPrev = CType(Me.Controls.Find("txtDoctor" & i - 1, True).FirstOrDefault(), TextBox)
            Dim txtWebAccessUIDPrev = CType(Me.Controls.Find("txtWebAccess" & i - 1 & "UID", True).FirstOrDefault(), TextBox)
            Dim txtWebAccessPWDPrev = CType(Me.Controls.Find("txtWebAccess" & i - 1 & "PWD", True).FirstOrDefault(), TextBox)
            Dim btnPrev = CType(Me.Controls.Find("ButtonWebRefresh" & i - 1, True).FirstOrDefault(), Button)
            Dim txtNPIPrev = CType(Me.Controls.Find("txtNPI" & i - 1, True).FirstOrDefault(), TextBox)

            Dim lblWeb As New Label
            lblWeb.Name = "lblWeb" & i
            lblWeb.Text = i
            lblWeb.Top = txtDoctorPrev.Top + txtDoctorPrev.Height + H + 2
            lblWeb.Left = lblPrev.Left
            lblWeb.Width = 40
            lblWeb.Height = lblPrev.Height
            lblWeb.Font = lblPrev.Font


            Dim lblUserName As New Label
            lblUserName.Name = "lblUserName" & i
            lblUserName.Text = "User Name"
            lblUserName.Top = txtDoctorPrev.Top + txtDoctorPrev.Height + H + 2
            lblUserName.Left = lblUserNamePrev.Left
            lblUserName.Width = lblUserNamePrev.Width
            lblUserName.Height = lblUserNamePrev.Height
            lblUserName.Font = lblUserNamePrev.Font

            Dim lblNPI As New Label
            lblNPI.Name = "lblNPI" & i
            lblNPI.Text = "NPI"
            lblNPI.Top = txtNPIPrev.Top + txtNPIPrev.Height + H + 2
            lblNPI.Left = lblNPIPrev.Left
            lblNPI.Width = lblNPIPrev.Width
            lblNPI.Height = lblNPIPrev.Height
            lblNPI.Font = lblNPIPrev.Font




            Dim lblPassword As New Label
            lblPassword.Name = "lblPassword" & i
            lblPassword.Text = "Pwd"
            lblPassword.Top = txtDoctorPrev.Top + txtDoctorPrev.Height + H + 2
            lblPassword.Left = lblPasswordPrev.Left
            lblPassword.Width = lblPasswordPrev.Width
            lblPassword.Height = lblPasswordPrev.Height
            lblPassword.Font = lblPasswordPrev.Font




            Dim txtDoctor As New TextBox
            txtDoctor.Name = "txtDoctor" & i
            txtDoctor.Top = txtDoctorPrev.Top + txtDoctorPrev.Height + H
            txtDoctor.Left = txtDoctorPrev.Left
            txtDoctor.Width = txtDoctorPrev.Width
            txtDoctor.Height = txtDoctorPrev.Height
            txtDoctor.Font = txtDoctorPrev.Font
            txtDoctor.Enabled = False

            Dim txtNPI As New TextBox
            txtNPI.Name = "txtNPI" & i
            txtNPI.Top = txtNPIPrev.Top + txtNPIPrev.Height + H
            txtNPI.Left = txtNPIPrev.Left
            txtNPI.Width = txtNPIPrev.Width
            txtNPI.Height = txtNPIPrev.Height
            txtNPI.Font = txtNPIPrev.Font
            txtNPI.Enabled = False
            txtNPI.MaxLength = 20


            Dim txtWebAccessUID As New TextBox
            txtWebAccessUID.Name = "txtWebAccess" & i & "UID"
            txtWebAccessUID.Top = txtWebAccessUIDPrev.Top + txtWebAccessUIDPrev.Height + H
            txtWebAccessUID.Left = txtWebAccessUIDPrev.Left
            txtWebAccessUID.Width = txtWebAccessUIDPrev.Width
            txtWebAccessUID.Height = txtWebAccessUIDPrev.Height
            txtWebAccessUID.Font = txtWebAccessUIDPrev.Font
            txtWebAccessUID.Enabled = False
            txtWebAccessUID.MaxLength = 20

            Dim txtWebAccessPWD As New TextBox
            txtWebAccessPWD.Name = "txtWebAccess" & i & "PWD"
            txtWebAccessPWD.Top = txtWebAccessPWDPrev.Top + txtWebAccessPWDPrev.Height + H
            txtWebAccessPWD.Left = txtWebAccessPWDPrev.Left
            txtWebAccessPWD.Width = txtWebAccessPWDPrev.Width
            txtWebAccessPWD.Height = txtWebAccessPWDPrev.Height
            txtWebAccessPWD.Font = txtWebAccessPWDPrev.Font
            txtWebAccessPWD.Enabled = False
            txtWebAccessPWD.MaxLength = 20

            Dim btn As New Button
            btn.Name = "ButtonWebRefresh" & i
            btn.Top = txtDoctorPrev.Top + txtDoctorPrev.Height + (H - 2)
            btn.Left = btnPrev.Left
            btn.Width = btnPrev.Width
            btn.Height = btnPrev.Height
            btn.Font = btnPrev.Font
            btn.Enabled = False

            btn.Image = btnPrev.Image
            btn.BackColor = btnPrev.BackColor
            btn.FlatAppearance.BorderColor = Color.Empty
            btn.FlatAppearance.BorderSize = 0
            btn.FlatAppearance.MouseOverBackColor = Color.Empty
            btn.FlatAppearance.MouseDownBackColor = Color.Empty
            btn.FlatStyle = FlatStyle.Flat
            AddHandler btn.Click, AddressOf ButtonWebRefresh_Click

            Panel1.Controls.Add(lblUserName)
            Panel1.Controls.Add(lblPassword)
            Panel1.Controls.Add(lblWeb)
            Panel1.Controls.Add(txtDoctor)
            Panel1.Controls.Add(txtWebAccessUID)
            Panel1.Controls.Add(txtWebAccessPWD)
            Panel1.Controls.Add(btn)
            Panel1.Controls.Add(lblNPI)
            Panel1.Controls.Add(txtNPI)
            lblWeb.Visible = True
            txtDoctor.Visible = True
            txtWebAccessUID.Visible = True
            txtWebAccessPWD.Visible = True
            btn.Visible = True
            lblUserName.SendToBack()
            lblPassword.SendToBack()
            lblWeb.SendToBack()
        Next



    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim Reader1 As SqlClient.SqlDataReader
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Reader = gSQLGetDataReader("Select DISTINCT State, ShowOrder from States Order by ShowOrder")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxState.Items.Add(Reader("State").ToString)
        Loop
        Reader.Close() : Reader.Dispose()
        Dim I As Integer
        Dim Arlst As ArrayList
        Dim ArlstData As ArrayList
        Dim CT As FarPoint.Win.Spread.CellType.ComboBoxCellType
        Reader = gSQLGetDataReader("SELECT DiagID, DiagName FROM [Diagnostics]")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            FpSpreadPreferredProviders.ActiveSheet.RowCount = FpSpreadPreferredProviders.ActiveSheet.RowCount + 1
            FpSpreadPreferredProviders.ActiveSheet.Cells(I, 0).Text = Reader("DiagName").ToString
            FpSpreadPreferredProviders.ActiveSheet.Cells(I, 0).Tag = Reader("DiagID").ToString
            CT = New FarPoint.Win.Spread.CellType.ComboBoxCellType
            Arlst = New ArrayList
            ArlstData = New ArrayList
            CT.Editable = False
            CT.AutoSearch = FarPoint.Win.AutoSearch.MultipleCharacter
            CT.ListAlignment = FarPoint.Win.ListAlignment.Left
            Reader1 = gSQLGetDataReader("SELECT     Employees.EmpID, Employees.Fname, Employees.Lname, Employees.Alias FROM EmployeeOffice INNER JOIN Employees ON EmployeeOffice.EmpID = Employees.EmpID INNER JOIN DoctorDiagnostics ON EmployeeOffice.EmpID = DoctorDiagnostics.EmpID WHERE DoctorDiagnostics.DiagID = " & Reader("DiagID") & " AND EmployeeOffice.OfficeID = " & gOfficeID & " AND Employees.TreatmentPrv = 1")
            Arlst.Add("None")
            ArlstData.Add("-1")
            Do Until Reader1.Read = False
                Arlst.Add(Reader1("Fname").ToString & " " & Reader1("Lname").ToString & " " & Reader1("Alias").ToString)
                ArlstData.Add(Reader1("EmpID").ToString)
            Loop
            CT.Items = Arlst.ToArray(GetType(String))
            CT.ItemData = ArlstData.ToArray(GetType(String))
            CT.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
            FpSpreadPreferredProviders.ActiveSheet.Cells(I, 1).CellType = CT
            FpSpreadPreferredProviders.ActiveSheet.Rows(I).BackColor = Color.WhiteSmoke
            I += 1
        Loop
        Reader.Close() : Reader.Dispose()

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        cmdEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim ID As Long
        Dim Reader As SqlClient.SqlDataReader
        Dim I As Integer
        gHighlightListviewItem(ListView1, False, False, Color.FromKnownColor(KnownColor.Highlight), Color.FromKnownColor(KnownColor.HighlightText))
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Clear_Controls()
        cmdEdit.Enabled = True
        cmdDelete.Enabled = True
        ID = CLng(ListView1.SelectedItems(0).Tag)
        SaveSelectedItem = ListView1.SelectedItems(0)
        Reader = gSQLGetDataReader("Select * from ReferringOffices Where OfficeID=" & ID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            CheckBoxActiveInd.Checked = CBool(Val("" & Reader("ActiveInd").ToString))
            txtOfficeName.Text = "" & Reader("OfficeName").ToString
            If Reader("OfficeGUID").ToString <> "" Then
                If Val(Mid(Reader("OfficeGUID").ToString(), 2)) > 0 Then
                    txtCode.Text = gProcessPing(Mid(Reader("OfficeGUID").ToString(), 2), Reader("OfficeName").ToString)
                End If
            End If
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

            For D As Integer = 1 To gReferringOfficeDoctors
                Dim txtDoctor = CType(Me.Controls.Find("txtDoctor" & D, True).FirstOrDefault(), TextBox)
                txtDoctor.Text = "" & Reader("Doctor" & D).ToString.Trim
                Dim txtNPI = CType(Me.Controls.Find("txtNPI" & D, True).FirstOrDefault(), TextBox)
                '"Doctor" & I & "Phone" used to store Workers Comp NPI
                txtNPI.Text = "" & Reader("Doctor" & D & "Phone").ToString.Trim
            Next

            'txtDoctor4Phone.Text = "" & Reader("Doctor4Phone").ToString
            CheckBoxPatientInformationShared.Checked = CBool(Val("" & Reader("PatientInformationShared").ToString))
            CheckBoxIgnoreInsuranceWarnings.Checked = CBool(Val("" & Reader("IgnoreInsuranceWarnings").ToString))

        Loop
        Reader.Close() : Reader.Dispose()
        Reader = gSQLGetDataReader("SELECT DoctorID, DiagID FROM ReferringOfficesPrefferedDoctors WHERE     OfficeID = " & ID)
        Do Until Reader.Read = False
            With FpSpreadPreferredProviders.ActiveSheet
                For I = 0 To .RowCount - 1
                    If .Cells(I, 0).Tag = Reader("DiagID").ToString Then
                        .Cells(I, 1).Value = Reader("DoctorID").ToString
                    End If
                Next
            End With
        Loop
        For C As Integer = 1 To gReferringOfficeDoctors
            Dim txtWebAccessUID = CType(Me.Controls.Find("txtWebAccess" & C & "UID", True).FirstOrDefault(), TextBox)
            txtWebAccessUID.Text = ""
            Dim txtWebAccessPwd = CType(Me.Controls.Find("txtWebAccess" & C & "PWD", True).FirstOrDefault(), TextBox)
            txtWebAccessPwd.Text = ""
            txtWebAccessPwd.Tag = ""
        Next
        Reader = gSQLGetDataReader("SELECT SecID,  UserID, UserName, Password FROM WebLogins WHERE  OfficeID = " & ID & " AND   UserTypeID = 2 ORDER BY UserID")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            Dim txtDoctor = CType(Me.Controls.Find("txtDoctor" & Val(Reader("UserID")), True).FirstOrDefault(), TextBox)
            Dim txtWebAccessUID = CType(Me.Controls.Find("txtWebAccess" & Val(Reader("UserID")) & "UID", True).FirstOrDefault(), TextBox)
            Dim txtWebAccessPWD = CType(Me.Controls.Find("txtWebAccess" & Val(Reader("UserID")) & "PWD", True).FirstOrDefault(), TextBox)
            If txtDoctor.Text.Length > 0 Then
                txtWebAccessUID.Text = "" & Reader("UserName").ToString
                txtWebAccessPWD.Text = "" & Reader("Password").ToString
                txtWebAccessPWD.Tag = Reader("SecID").ToString
            End If
        Loop
        Reader.Close() : Reader.Dispose()

        Cursor = Cursors.Default
    End Sub

    Private Sub Clear_Controls()
        Dim I As Integer
        gLoop_Clear_Controls(Me, TextBoxSearch)
        CheckBoxPatientInformationShared.Checked = False
        For I = 0 To FpSpreadPreferredProviders.ActiveSheet.RowCount - 1
            FpSpreadPreferredProviders.ActiveSheet.Cells(I, 1).Value = "-1"
        Next

        For I = 1 To gReferringOfficeDoctors
            Dim txtDoctor = CType(Me.Controls.Find("txtDoctor" & I, True).FirstOrDefault(), TextBox)
            txtDoctor.Text = ""
            Dim txtWebAccessUID = CType(Me.Controls.Find("txtWebAccess" & I & "UID", True).FirstOrDefault(), TextBox)
            txtWebAccessUID.Text = ""
            Dim txtWebAccessPwd = CType(Me.Controls.Find("txtWebAccess" & I & "PWD", True).FirstOrDefault(), TextBox)
            txtWebAccessPwd.Text = ""
            txtWebAccessPwd.Tag = ""
            Dim txtNPI = CType(Me.Controls.Find("txtNPI" & I, True).FirstOrDefault(), TextBox)
            txtNPI.Text = ""
        Next
    End Sub

    Private Sub Enable_Controls(ByVal En As Boolean)
        Dim I As Integer
        gLoop_Enable_Controls(Me, En)
        TextBoxSearch.Enabled = Not En
        ListView1.Enabled = Not En
        cmdAddNew.Enabled = Not En
        cmdUpdate.Enabled = En
        cmdCancel.Enabled = En
        CheckBoxIgnoreInsuranceWarnings.Enabled = En
        FpSpreadPreferredProviders.Enabled = En
        For I = 0 To FpSpreadPreferredProviders.ActiveSheet.Rows.Count - 1
            FpSpreadPreferredProviders.ActiveSheet.Rows(I).BackColor = IIf(En, Color.White, Color.WhiteSmoke)
        Next
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

        For I = 1 To gReferringOfficeDoctors
            Dim btn = CType(Me.Controls.Find("ButtonWebRefresh" & I, True).FirstOrDefault(), Button)
            btn.Enabled = En
        Next
    End Sub

    Public Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        OpMode = AddEditMode.AddNew
        Enable_Controls(True)
        Clear_Controls()
        ComboBoxState.Text = gDefaultState
        CheckBoxActiveInd.Checked = True
        TabControl1.SelectedIndex = 0
        txtOfficeName.Focus()
        Produce_WebUserName()
    End Sub

    Private Sub Produce_WebUserName(Optional ByVal Force As Integer = 0)
        Dim KeyGen As RandomKeyGenerator = New RandomKeyGenerator
        KeyGen.KeyLetters = "abcdefghkmnpqrstuvwxyz".ToUpper
        KeyGen.KeyNumbers = "123456789"
        KeyGen.KeyChars = 4
        For i As Integer = 1 To gReferringOfficeDoctors
            Dim txtWebAccessUID = CType(Me.Controls.Find("txtWebAccess" & i & "UID", True).FirstOrDefault(), TextBox)
            If txtWebAccessUID.Text = "" Or Force = i Then txtWebAccessUID.Text = gSQLGetSingleValue("SELECT IDENT_CURRENT('WebLogins')") + i & "R" & KeyGen.Generate
        Next

        KeyGen.KeyChars = 5
        For i As Integer = 1 To gReferringOfficeDoctors
            Dim txtWebAccessPWD = CType(Me.Controls.Find("txtWebAccess" & i & "PWD", True).FirstOrDefault(), TextBox)
            If txtWebAccessPWD.Text = "" Or Force = i Then txtWebAccessPWD.Text = "P" & KeyGen.Generate
        Next
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
            Else
                Clear_Controls()
            End If
        End If
    End Sub

    Public Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        OpMode = AddEditMode.Edit
        Enable_Controls(True)
        If TabControl1.SelectedIndex = 0 Then
            txtOfficeName.Focus()
        Else
            txtDoctor1.Focus()
        End If
        Produce_WebUserName()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim ID As Long
        Dim LI As ListViewItem
        Dim ProcCount As Integer = 0
        Dim Reader As SqlClient.SqlDataReader
        Dim I As Integer
        Try
            If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
                MsgBox("Unexpected Error. Please try again.")
                cmdCancel_Click(Nothing, Nothing)
                Exit Sub
            End If
            'gLoop_Trim_Controls(Me)
            'gLoop_Text_PropperCase(Me)

            If txtOfficeName.Text = "" Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtOfficeName, "Unable to process update. The Office Name is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Office Name is required.", MsgBoxStyle.Exclamation)
                txtOfficeName.Focus()
                Exit Sub
            End If
            If txtOfficeName.Text.Length < 3 Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtOfficeName, "Unable to process update. Invalid Office Name. Minimum 3 Characters length required.")
                MsgBox("Unable to process update." & vbCrLf & "Invalid Office Name. Minimum 3 Characters length required.", MsgBoxStyle.Exclamation)
                txtOfficeName.Focus()
                Exit Sub
            End If
            If txtCode.Text <> "" And txtCode.Visible = True Then
                If IsNumeric(txtCode.Text) = False Then
                    TabControl1.SelectedIndex = 0
                    ErrorProvider1.SetError(txtCode, "Unable to process update. Invalid Office Code.")
                    MsgBox("Unable to process update." & vbCrLf & "Invalid Office Code.", MsgBoxStyle.Exclamation)
                    txtCode.Focus()
                    Exit Sub
                End If
            End If
            If txtEmail.Text <> "" AndAlso gEmailCheck(txtEmail.Text) = False Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtOfficeName, "Unable to process update. Invalid Email address specified.")
                MsgBox("Unable to process update." & vbCrLf & "Invalid Email address specified.", MsgBoxStyle.Exclamation)
                txtOfficeName.Focus()
                Exit Sub
            End If
            If CheckBoxIgnoreInsuranceWarnings.Checked = True Then
                If MsgBox("You have marked this Office as Ignore Insurance Warnings. Is it correct?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    CheckBoxIgnoreInsuranceWarnings.Focus()
                    Exit Sub
                End If
            End If

            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
                Reader = gSQLGetDataReader("Select * from ReferringOffices Where OfficeID<>" & ID & " and OfficeName='" & txtOfficeName.Text.ToSafeSQLString() & "'")
            Else
                ID = -1
                Reader = gSQLGetDataReader("Select * from ReferringOffices Where OfficeName='" & txtOfficeName.Text.ToSafeSQLString() & "'")
            End If
            If Reader.Read() = True Then
                TabControl1.SelectedIndex = 0
                ErrorProvider1.SetError(txtOfficeName, "Unable to process update. The The Office Name is already inuse.")
                MsgBox("Unable to process update." & vbCrLf & "The Office Name is already inuse.", MsgBoxStyle.Exclamation)
                txtOfficeName.Focus()
                txtOfficeName.SelectAll()
                Exit Sub
            End If

            Dim TA As New SqlClient.SqlDataAdapter("SELECT * FROM ReferringOffices Where OfficeID= " & ID, gConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("ReferringOffices")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("OfficeName") = txtOfficeName.Text

            If txtOfficeName.Visible Then
                TR("OfficeGUID") = gProcessPing(txtCode.Text, txtOfficeName.Text)
            End If
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
            For I = 1 To gReferringOfficeDoctors
                Dim txtDoctor = CType(Me.Controls.Find("txtDoctor" & I, True).FirstOrDefault(), TextBox)
                TR("Doctor" & I) = txtDoctor.Text.Trim
                Dim txtNPI = CType(Me.Controls.Find("txtNPI" & I, True).FirstOrDefault(), TextBox)
                '"Doctor" & I & "Phone" used to store Workers Comp NPI
                TR("Doctor" & I & "Phone") = txtNPI.Text
            Next



            TR("sysOfficeID") = gOfficeID

            TR("PatientInformationShared") = IIf(CheckBoxPatientInformationShared.Checked, 1, 0)
            TR("IgnoreInsuranceWarnings") = IIf(CheckBoxIgnoreInsuranceWarnings.Checked, 1, 0)

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

            LI = SaveSelectedItem

            If OpMode = AddEditMode.AddNew Then
                Reader = gSQLGetDataReader("Select * from ReferringOffices Where OfficeID = IDENT_CURRENT('ReferringOffices')")
                If Reader Is Nothing Then Exit Sub
                Do Until Reader.Read = False
                    LI = ListView1.Items.Add(Reader("OfficeName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                    LI.Tag = "" & Reader("OfficeID").ToString
                    If ListView1.SelectedItems.Count > 0 Then ListView1.SelectedItems(0).Selected = False

                    ListView1_SelectedIndexChanged(Nothing, Nothing)
                    ID = CLng(Val(Reader("OfficeID").ToString))
                    SaveSelectedItem = LI
                Loop
                Reader.Close() : Reader.Dispose()
            Else
                If CheckBoxActiveInd.Checked = True Then
                    SaveSelectedItem.ImageIndex = 1
                Else
                    SaveSelectedItem.ImageIndex = 0
                End If
                SaveSelectedItem.Text = txtOfficeName.Text
            End If
            For I = 1 To gReferringOfficeDoctors
                Dim txtDoctor = CType(Me.Controls.Find("txtDoctor" & I, True).FirstOrDefault(), TextBox)
                Dim txtWebAccessUID = CType(Me.Controls.Find("txtWebAccess" & I & "UID", True).FirstOrDefault(), TextBox)
                Dim txtWebAccessPwd = CType(Me.Controls.Find("txtWebAccess" & I & "PWD", True).FirstOrDefault(), TextBox)
                If txtDoctor.Text.Length > 0 Then
                    If IsNumeric(txtWebAccess1PWD.Tag) = False Then
                        gSQLUpdateData("INSERT INTO WebLogins ( UserID, OfficeID, UserName, Password, UserTypeID) VALUES(1, " & ID & ", '" & txtWebAccessUID.Text.ToSafeSQLString() & "', '" & txtWebAccessPwd.Text.ToSafeSQLString() & "', 2)")
                    Else
                        gSQLUpdateData("UPDATE WebLogins SET UserName = '" & txtWebAccessUID.Text.ToSafeSQLString() & "', Password = '" & txtWebAccessPwd.Text.ToSafeSQLString() & "' WHERE SecID = " & Val(txtWebAccessPwd.Tag))
                    End If
                Else
                    If IsNumeric(txtWebAccessPwd.Tag) = True Then
                        gSQLUpdateData("DELETE FROM WebLogins WHERE SecID = " & Val(txtWebAccessPwd.Tag))
                    End If
                End If
            Next




            gSQLDeleteRecord("DELETE FROM ReferringOfficesPrefferedDoctors Where OfficeID=" & ID)
            TA = New SqlClient.SqlDataAdapter("SELECT * FROM ReferringOfficesPrefferedDoctors Where 1=2", gConnectionString)
            CB = New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            dTab = New DataTable("ReferringOfficesPrefferedDoctors")

            TA.Fill(dTab)
            With FpSpreadPreferredProviders.ActiveSheet
                For I = 0 To .RowCount - 1
                    TR = dTab.NewRow
                    TR("OfficeID") = ID
                    If .Cells(I, 1).Value = "" Then
                        TR("DoctorID") = -1
                    Else
                        TR("DoctorID") = .Cells(I, 1).Value
                    End If
                    TR("DiagID") = .Cells(I, 0).Tag
                    dTab.Rows.Add(TR)
                Next
            End With
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
            If Not LI Is Nothing Then
                LI.Selected = True
                LI.EnsureVisible()
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
        If gSQLDeleteRecord("DELETE FROM ReferringOffices WHERE OfficeID=" & ID) Then
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

    Private Sub frmReferringOfficesMaintenance_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmOfficeMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        gSetup_GotFocus(Me)
        Load_Data()
        Load_Doctors()
        Load_ReferringOffices()
        Set_TabStops(Panel1)
        Cursor = Cursors.Default
        Application.DoEvents()
        If gCurrentEmployee.SC Then
            txtOfficeName.Width = 558
            txtCode.Visible = True
        Else
            txtOfficeName.Width = 657
            txtCode.Visible = False
        End If
        txtOfficeName.AutoCompleteCustomSource = gAutocompleteRefferingOfficeName
        txtAddress1.AutoCompleteCustomSource = gAutocompleteAddress
        txtCity.AutoCompleteCustomSource = gAutocompleteCity
        If String.IsNullOrEmpty(RefOffice) = False Then
            TextBoxSearch.Text = RefOffice
        End If
    End Sub

    Private Sub Set_TabStops(container As Control)
        Dim TabIndex As Integer
        TabIndex = 0
        Dim ctrl As Control
        Dim ret As Control()
        Dim match As Integer
        For i = 1 To gReferringOfficeDoctors
            match = 0
            ret = container.Controls.Find("txtDoctor" & i, False)
            If (Not ret Is Nothing AndAlso ret.Count > 0) Then
                match = match + 1
                ctrl = ret(0)
                ctrl.TabIndex = TabIndex
            End If
            ret = container.Controls.Find("txtWebAccess" & i & "UID", False)
            If (Not ret Is Nothing AndAlso ret.Count > 0) Then
                match = match + 1
                ctrl = ret(0)
                ctrl.TabIndex = TabIndex + 1
            End If
            ret = container.Controls.Find("txtWebAccess" & i & "PWD", False)
            If (Not ret Is Nothing AndAlso ret.Count > 0) Then
                match = match + 1
                ctrl = ret(0)
                ctrl.TabIndex = TabIndex + 2
            End If
            ret = container.Controls.Find("ButtonWebRefresh" & i, False)
            If (Not ret Is Nothing AndAlso ret.Count > 0) Then
                match = match + 1
                ctrl = ret(0)
                ctrl.TabIndex = TabIndex + 3
            End If
            TabIndex = TabIndex + match
        Next

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

    Private Sub txtOfficeName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOfficeName.TextChanged
        ErrorProvider1.SetError(txtOfficeName, "")
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

    Private Sub txtZip_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtZip.MaskInputRejected

    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        gSearchListView(ListView1, TextBoxSearch)
    End Sub

    Private Sub ResetError(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWebAccess1UID.TextChanged, txtDoctor1.TextChanged, txtWebAccess1PWD.TextChanged
        ErrorProvider1.SetError(sender, "")
    End Sub

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged
        ErrorProvider1.SetError(txtCode, "")
    End Sub

    Private Sub ButtonWebRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWebRefresh1.Click
        Dim returnVal As String = String.Empty
        Dim myChars() As Char = CType(sender, Button).Name.ToCharArray()
        For Each ch As Char In myChars
            If Char.IsDigit(ch) Then
                returnVal += ch.ToString()
            End If
        Next
        Produce_WebUserName(Val(returnVal))
    End Sub


End Class