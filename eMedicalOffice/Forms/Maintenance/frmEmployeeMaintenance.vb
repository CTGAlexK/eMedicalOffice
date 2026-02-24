Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Reflection
Imports log4net
Imports Newtonsoft.Json.Linq

Public Class frmEmployeeMaintenance
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private SaveSelectedItem As ListViewItem
    Private OpMode As AddEditMode
    Private DoctorsTab As TabPage
    Private DoctorsNPITab As TabPage
    Private EmailPageTab As TabPage

    Private Sub frmEmployeeMaintenance_FormClosed(ByVal sender As Object, ByVal e As Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub frmEmployeeMaintenance_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    End Sub

    Private Sub frmEmployeeMaintenance_KeyUp(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    End Sub

    Private Sub frmEmployeeMaintenance_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim ToolTip As String
        Application.DoEvents()
        gSetup_GotFocus(Me)
        DoctorsTab = DoctorInfo
        DoctorsNPITab = DoctorNPI
        EmailPageTab = EmailTab
        txtFname.AutoCompleteCustomSource = gAutocompleteFname
        txtLname.AutoCompleteCustomSource = gAutocompleteLName
        txtAddress1.AutoCompleteCustomSource = gAutocompleteAddress
        txtCity.AutoCompleteCustomSource = gAutocompleteCity
        ToolTip = "Used to differentiate multiple employees with the same name." & vbCrLf & vbCrLf
        ToolTip &= "Common use: When Doctor has multiple P.C." & vbCrLf
        ToolTip &= "more than one profile will be created for the same doctor." & vbCrLf & vbCrLf
        ToolTip &= "This Field will not come to the bill."
        ToolTip1.SetToolTip(PictureBoxAlias, ToolTip)
        AddHandler ComboBoxAbbreviation.Leave, AddressOf sSearchComboBox_Leave
        PictureBoxPassword.Visible = gCurrentEmployee.PositionID < 2
        txtCorporationAddress1.AutoCompleteCustomSource = gAutocompleteAddress
        txtCorporationCity.AutoCompleteCustomSource = gAutocompleteCity
        load_treatment_providers()
        Load_Data()
        Load_Users()
        Cursor = Cursors.Default
        Application.DoEvents()
        Dim H As ToolStripControlHost
        H = New ToolStripControlHost(MonthCalendarPopUp)
        ContextMenuPopUpCalendar.Items.Insert(0, H)
        ContextMenuPopUpCalendar.Show()
        ContextMenuPopUpCalendar.Hide()
        If gSMTPUID = "" Or gSMTPHost = "" Then
            PanelEmailWarning.Visible = True
        Else
            PanelEmailWarning.Visible = False
        End If
        ButtonDistribute.Visible = False
        MultiOfficeProcess()
    End Sub

    Private Sub MultiOfficeProcess()
        If gOffices.Count = 0 Then Exit Sub
        ButtonDistribute.Visible = False
        ContextMenuStripOffices.Items.Clear()
        For Each office As Office In gOffices
            If office.OfficeID <> gOfficeID Then
                Dim mnu = New ToolStripMenuItem()
                mnu.Text = "Copy to " & office.OfficeName
                mnu.Tag = office
                mnu.Image = My.Resources.CopyEmployee
                mnu.ImageScaling = ToolStripItemImageScaling.None
                ContextMenuStripOffices.Items.Add(mnu)
                AddHandler mnu.Click, AddressOf mnu_Click
            End If

        Next
    End Sub

    Private Sub mnu_Click(sender As Object, e As EventArgs)
        ' Function created but never tested!
        Return
        Dim office As Office = CType(sender.Tag, Office)
        If ListViewEmployees.SelectedItems.Count = 0 Then
            MsgBox("Unable to distribute employee profile. No Employee selected.", MsgBoxStyle.Exclamation)
            Return
        End If
        If MessageBox.Show("Please confirm you want to copy employee profile: " + ListViewEmployees.SelectedItems(0).Text & vbCrLf & "To the office " & office.OfficeName & "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If
        If CopyProfile(ListViewEmployees.SelectedItems(0).Tag, office) Then
            MessageBox.Show("Employee profile: " & ListViewEmployees.SelectedItems(0).Text & " has been copied to the " & office.OfficeName & " office successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function CopyProfile(ID As Long, o As Office) As Boolean
        Dim sql As String
        Dim Reader As SqlDataReader
        Dim ReaderDest As SqlDataReader
        Dim WebUserTypeID As Integer
        sql = "select Fname,Lname, MI, UID  from Employees where EmpId=" & ID
        Reader = gSQLGetDataReader(sql)
        If Reader Is Nothing Then Return False
        If Reader.HasRows = False Then Return False
        Reader.Read()
        sql = "select count(*) from Employees where Fname = '" & Reader("Fname").ToString().Trim().ToSafeSQLString() & "' and Lname = '" & Reader("Lname").ToString().Trim().ToSafeSQLString() & "' and MI = '" & Reader("MI").ToString().Trim().ToSafeSQLString() & "'"
        If gSQLGetSingleValue(sql, o.ConnectionString) > 0 Then
            MsgBox("Duplicate record." & vbCrLf & vbCrLf & "Unable to copy selected employee to the " & o.OfficeName & " office." & vbCrLf & "The employee name: " & Reader("Fname").ToString().Trim() & " " & Reader("MI").ToString().Trim() & " " & Reader("Lname").ToString().Trim() & " is already exists.")
            Return False
        End If
        sql = "select count(*) from Employees where UID='" & Reader("UID").ToString().Trim().ToSafeSQLString() & "'"
        If gSQLGetSingleValue(sql, o.ConnectionString) > 0 Then
            MsgBox("Unable to copy selected employee to the " & o.OfficeName & " office." & vbCrLf & "The employee User Name: " & Reader("UID").ToString().Trim() & " is already exists.")
            Return False
        End If

        If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 1 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 2 Then
            WebUserTypeID = 3
        ElseIf CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 5 Then
            WebUserTypeID = 1
        ElseIf CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100 Then
            WebUserTypeID = 5
        End If
        sql = "select UserName from WebLogins where UserID = " & ID & " and UserTypeID = " & WebUserTypeID & ""
        Dim WebUserName As String = gSQLGetSingleValueString(sql)
        If WebUserName.Trim().Length > 0 Then
            sql = "select count(*) from WebLogins where UserName='" & WebUserName & "'"
            If gSQLGetSingleValue(sql, o.ConnectionString) > 0 Then
                MsgBox("Unable to copy selected employee to the " & o.OfficeName & " office." & vbCrLf & "The employee Web User Name: " & WebUserName & " is already exists.")
                Return False
            End If
        End If
        Dim TA As New SqlClient.SqlDataAdapter("SELECT * FROM Employees", o.ConnectionString)
        Dim CB As New SqlClient.SqlCommandBuilder(TA)
        CB.ConflictOption = ConflictOption.OverwriteChanges
        Dim TR As DataRow
        Dim dTab As New DataTable("Employees")
        TA.Fill(dTab)
        TR = dTab.NewRow

        TR("Fname") = txtFname.Text
        TR("Lname") = txtLname.Text
        TR("MI") = TextBoxMI.Text
        TR("Alias") = txtAlias.Text
        If IsDate(txtDOB.Text) Then TR("DOB") = txtDOB.Text
        TR("SSN") = txtSSN.Text
        TR("Address1") = txtAddress1.Text
        TR("Address2") = txtAddress2.Text
        TR("City") = txtCity.Text
        TR("State") = ComboBoxState.Text
        If txtZip.MaskCompleted Then TR("Zip") = txtZip.Text Else TR("Zip") = ""
        If txtPhone1.MaskCompleted Then TR("Phone1") = txtPhone1.Text Else TR("Phone1") = ""
        'If txtPhone2.MaskCompleted Then TR("Phone2") = txtPhone2.Text Else TR("Phone2") = ""
        If txtCellPhone.MaskCompleted Then TR("CellPhone") = txtCellPhone.Text Else TR("CellPhone") = ""
        TR("eMail") = txtEmail.Text
        TR("PositionID") = CType(ComboBoxPosition.SelectedItem, ValueDescription).Value
        If IsDate(txtDateHired.Text) Then TR("DateHired") = txtDateHired.Text
        TR("UID") = txtUID.Text
        TR("Password") = gEncrypt(txtPassword.Text)
        TR("ActiveInd") = IIf(CheckBoxActiveInd.Checked, 1, 0)
        TR("LICNumber") = txtLICNumber.Text
        TR("Comments") = txtComments.Text

        If TabControl1.TabPages.ContainsKey("DoctorInfo") Then

            If txtCorporatePhone.MaskCompleted Then TR("CorporationPhone") = txtCorporatePhone.Text Else TR("CorporationPhone") = ""
            If txtCorporateFax.MaskCompleted Then TR("CorporationFax") = txtCorporateFax.Text Else TR("CorporationFax") = ""
            TR("LICNumber") = txtLICNumber.Text
            TR("CorporationName") = txtCorporationName.Text
            TR("CorporationDBA") = txtCorporationDBA.Text
            TR("CheckingAccountNumber") = txtAccountNumber.Text.Trim
            TR("CorporationAddress1") = txtCorporationAddress1.Text
            TR("CorporationAddress2") = txtCorporationAddress2.Text
            TR("CorporationCity") = txtCorporationCity.Text
            TR("CorporationState") = ComboBoxCorporationState.Text
            If txtCorporationZip.MaskCompleted Then TR("CorporationZip") = txtCorporationZip.Text Else TR("CorporationZip") = ""
            TR("BillingPrv") = IIf(CheckBoxBillingPrv.Checked, 1, 0)
            TR("TreatmentPrv") = IIf(CheckBoxTreatmentPrv.Checked, 1, 0)
            TR("CorporationTaxID") = txtCorporationTaxID.Text
            TR("DoctorTitle") = txtDoctorTitle.Text
            TR("DoctorTitle1") = txtDoctorTitle1.Text
            TR("Abbreviation") = ComboBoxAbbreviation.Text

            TR("NoFaultInd") = IIf(CheckBoxNoFault.Checked, 1, 0)
            TR("PrivateInd") = IIf(CheckBoxPrivate.Checked, 1, 0)
            TR("ReferralColor") = CType(ComboBoxreferralColor.SelectedItem, ValueDescription).Value
            TR("WCBAuthorizationNumber") = txtWCBAuthorizationNumber.Text
            TR("WCBRatingCode") = txtWCBRatingCode.Text
            TR("WCProviderNPI") = txtWCProviderNPI.Text
        Else
            TR("DoctorID") = ""
            TR("LICNumber") = ""
            TR("CorporationName") = ""
            TR("CheckingAccountNumber") = ""
            TR("CorporationAddress1") = ""
            TR("CorporationAddress2") = ""
            TR("CorporationCity") = ""
            TR("CorporationState") = ""
            TR("CorporationZip") = ""
            TR("BillingPrv") = 0
            TR("TreatmentPrv") = 0
            TR("CorporationTaxID") = ""
            TR("DoctorTitle") = ""
            TR("NoFaultInd") = 0
            TR("PrivateInd") = 0
            TR("ReferralColor") = 0
            TR("WCBAuthorizationNumber") = ""
            TR("WCBRatingCode") = ""
            TR("WCProviderNPI") = ""
            TR("CorporationPhone") = ""
            TR("CorporationFax") = ""

        End If
        If TabControl1.TabPages.Contains(EmailTab) Then
            TR("EmailMessage1") = IIf(CheckBoxEmail1.Checked, 1, 0)
            TR("EmailMessage2") = IIf(CheckBoxEmail2.Checked, 1, 0)
            TR("EmailMessage3") = IIf(CheckBoxEmail3.Checked, 1, 0)
            TR("EmailMessage4") = IIf(CheckBoxEmail4.Checked, 1, 0)
            TR("EmailMessage5") = IIf(CheckBoxEmail5.Checked, 1, 0)
            TR("EmailMessage6") = IIf(CheckBoxEmail6.Checked, 1, 0)
            TR("EmailMessage7") = IIf(CheckBoxEmail7.Checked, 1, 0)
            TR("EmailMessage8") = IIf(CheckBoxEmail8.Checked, 1, 0)
            TR("EmailMessage9") = IIf(CheckBoxEmail9.Checked, 1, 0)
            TR("EmailMessage10") = IIf(CheckBoxEmail10.Checked, 1, 0)
        Else
            TR("EmailMessage1") = 0
            TR("EmailMessage2") = 0
            TR("EmailMessage3") = 0
            TR("EmailMessage4") = 0
            TR("EmailMessage5") = 0
            TR("EmailMessage6") = 0
            TR("EmailMessage7") = 0
            TR("EmailMessage8") = 0
            TR("EmailMessage9") = 0
            TR("EmailMessage10") = 0
        End If

        ''' Update Logo
        If PictureBoxDoctorSignature.Image Is Nothing Then
            TR("EmployeeSignature") = DBNull.Value
            TR("EmployeeSignatureInd") = 0
        Else
            Dim ms As New IO.MemoryStream
            PictureBoxDoctorSignature.Image.Save(ms, Imaging.ImageFormat.Png)
            Dim arrImage() As Byte = ms.GetBuffer
            TR("EmployeeSignature") = arrImage
            TR("EmployeeSignatureInd") = 1
            ms.Close()

        End If

        ''' Update PC Logo
        If PictureBoxPCLogo.Image Is Nothing Then
            TR("PCLogo") = DBNull.Value
            TR("PCLogoInd") = 0
        Else
            Dim ms As New IO.MemoryStream
            PictureBoxPCLogo.Image.Save(ms, Imaging.ImageFormat.Png)
            Dim arrImage() As Byte = ms.GetBuffer
            TR("PCLogo") = arrImage
            TR("PCLogoInd") = 1
            ms.Close()

        End If

        ''''''''''''''''
        dTab.Rows.Add(TR)
        TA.UpdateCommand = CB.GetUpdateCommand(True)
        Try
            TA.Update(dTab)
            dTab.AcceptChanges()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            Return False
        End Try
        dTab.Dispose()
        CB.Dispose()
        TA.Dispose()
        If txtWebAdminUID.Text <> "" And (CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 1 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 2 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 5 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100) Then
            gSQLUpdateData("INSERT INTO WebLogins ( UserID, OfficeID, UserName, Password, UserTypeID) VALUES(" & ID & ", " & gOfficeID & ", '" & txtWebAdminUID.Text.ToSafeSQLString() & "', '" & txtWebAdminPWD.Text.ToSafeSQLString() & "', " & WebUserTypeID & ")", o.ConnectionString)
        End If

        TA = New SqlClient.SqlDataAdapter("SELECT EmpID, OfficeID FROM EmployeeOffice Where 1=2", o.ConnectionString)
        CB = New SqlCommandBuilder(TA)
        CB.ConflictOption = ConflictOption.OverwriteChanges
        dTab = New DataTable("EmployeeOffice")
        TA.Fill(dTab)
        For Each office As Office In gOffices
            TR = dTab.NewRow
            TR("EmpID") = ID
            TR("OfficeID") = office.OfficeID
            dTab.Rows.Add(TR)
        Next
        TA.UpdateCommand = CB.GetUpdateCommand(True)
        Try
            TA.Update(dTab)
            dTab.AcceptChanges()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            Return False
        End Try
        dTab.Dispose() : CB.Dispose() : TA.Dispose()
        gSQLDeleteRecord("Delete from DoctorDiagnostics Where EmpID=" & ID, o.ConnectionString)
        If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value1 = 1 Then
            TA = New SqlDataAdapter("SELECT ID, EmpID, DiagID FROM DoctorDiagnostics Where 1=2", o.ConnectionString)
            CB = New SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            dTab = New DataTable("DoctorDiagnostics")
            TA.Fill(dTab)
            For Each LI In ListViewDoctorDiagnostics.Items
                If LI.Checked Then
                    TR = dTab.NewRow
                    TR("EmpID") = ID
                    TR("DiagID") = CType(LI.Tag, Integer)
                    dTab.Rows.Add(TR)
                End If
            Next
            TA.UpdateCommand = CB.GetUpdateCommand(True)
            Try
                TA.Update(dTab)
                dTab.AcceptChanges()
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
                Return False
            End Try
        End If
        gSQLDeleteRecord("DELETE FROM DoctorInsuranceNPI Where EmpID = " & ID, o.ConnectionString)
        TA = New SqlClient.SqlDataAdapter("SELECT  * FROM DoctorInsuranceNPI Where 1=2", o.ConnectionString)
        CB = New SqlClient.SqlCommandBuilder(TA)
        CB.ConflictOption = ConflictOption.OverwriteChanges
        dTab = New DataTable("DoctorInsuranceNPI")

        TA.Fill(dTab)
        For Each LI In ListViewNPI.Items
            TR = dTab.NewRow
            TR("CompanyID") = LI.Tag
            TR("EmpID") = ID
            TR("NPI") = LI.SubItems(1).Text
            dTab.Rows.Add(TR)
        Next
        TA.UpdateCommand = CB.GetUpdateCommand(True)
        Try
            TA.Update(dTab)
            dTab.AcceptChanges()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            Return False
        End Try
        dTab.Dispose() : CB.Dispose() : TA.Dispose()
    End Function

    Dim SaveCbo As ComboBox

    Private Sub SearchComboBox_KeyUp(ByVal cbo As ComboBox, ByVal e As KeyEventArgs, Optional ByVal MustExist As Boolean = True)
        Dim sTypedText As String
        Dim iFoundIndex As Integer
        Dim oFoundItem As Object
        Dim sFoundText As String
        Dim sAppendText As String
        Dim iPos As Integer
        If Not SaveCbo Is Nothing Then If SaveCbo.BackColor <> Color.White Then SaveCbo.BackColor = Color.White
        'Allow select keys without Autocompleting
        Try

            Select Case e.KeyCode
                Case Keys.Back, Keys.Left, Keys.Right, Keys.Up, Keys.Delete, Keys.Down, Keys.Tab, Keys.Home, Keys.End, Keys.Shift, Keys.ShiftKey
                    Return
            End Select
Recheck:
            'Get the Typed Text and Find it in the list
            sTypedText = cbo.Text
            iFoundIndex = cbo.FindString(sTypedText)

            'If we found the Typed Text in the list then Autocomplete
            If iFoundIndex >= 0 Then

                'Get the Item from the list (Return Type depends if Datasource was bound
                ' or List Created)
                oFoundItem = cbo.Items(iFoundIndex)

                'Use the ListControl.GetItemText to resolve the Name in case the Combo
                ' was Data bound
                sFoundText = cbo.GetItemText(oFoundItem)

                'Append then found text to the typed text to preserve case
                sAppendText = sFoundText.Mid(sTypedText.Length + 1)
                cbo.Text = sTypedText & sAppendText

                'Select the Appended Text
                cbo.SelectionStart = sTypedText.Length
                cbo.SelectionLength = sAppendText.Length
            Else
                If MustExist = False Then Exit Sub
                iPos = cbo.SelectionStart
                e.SuppressKeyPress = True
                cbo.Text = cbo.Text.Left(Len(cbo.Text) - 1)
                cbo.SelectionStart = iPos - 1
                e.Handled = True
                SaveCbo = cbo
                cbo.BackColor = Color.LightCoral
                Application.DoEvents()
                ResetSearchComboTimer.Enabled = True
                If Len(cbo.Text) = 0 Then Exit Sub
                GoTo Recheck
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmAdjusterMaintenance_FormClosing(ByVal sender As Object, ByVal e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cmdUpdate.Enabled Then
            If MsgBox("You have unsaved data. Discard changes?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Load_Users()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Reader = gSQLGetDataReader("Select * from Employees Order by FName, LName")
        If Reader Is Nothing Then Exit Sub
        Dim img As Integer
        Do Until Reader.Read = False
            img = CInt(Val("" & Reader("ActiveInd").ToString))
            If img > 0 Then
                If CInt(Val("" & Reader("PositionID").ToString)) = 5 Then
                    img = 2
                End If
            End If
            LI = ListViewEmployees.Items.Add(Reader("FName").ToString & " " & Reader("LName").ToString, img)
            LI.Tag = "" & Reader("EmpID").ToString
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewEmployees.Items.Count > 0 Then
            ListViewEmployees.Items(0).Selected = True
            ListViewEmployees.Items(0).EnsureVisible()
            ListView1_SelectedIndexChanged(Nothing, Nothing)
            cmdEdit.Enabled = True
            cmdDelete.Enabled = True
        End If
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim lAutoCompleteCustomSource As New AutoCompleteStringCollection
        Dim lAutoCompleteCustomSourceDBA As New AutoCompleteStringCollection
        Try
            Reader = gSQLGetDataReader("SELECT DISTINCT Employees.CorporationName From Employees INNER JOIN EmployeeOffice ON Employees.EmpID = EmployeeOffice.EmpID WHERE     (EmployeeOffice.OfficeID = " & gOfficeID & " ) ORDER BY Employees.CorporationName")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                lAutoCompleteCustomSource.Add(Reader("CorporationName").ToString)
            Loop
            Reader.Close() : Reader.Dispose()
            txtCorporationName.AutoCompleteCustomSource = lAutoCompleteCustomSource

            Reader = gSQLGetDataReader("SELECT DISTINCT CorporationDBA From Employees ORDER BY Employees.CorporationDBA")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                lAutoCompleteCustomSourceDBA.Add(Reader("CorporationDBA").ToString)
            Loop
            Reader.Close() : Reader.Dispose()
            txtCorporationDBA.AutoCompleteCustomSource = lAutoCompleteCustomSourceDBA

            Reader = gSQLGetDataReader("Select DISTINCT State, ShowOrder from States Order by ShowOrder")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxState.Items.Add(Reader("State").ToString)
                ComboBoxCorporationState.Items.Add(Reader("State").ToString)
            Loop
            Reader.Close() : Reader.Dispose()
            Application.DoEvents()
            Reader = gSQLGetDataReader("Select * from Positions Order by PositionID")
            If Reader Is Nothing Then Exit Sub

            Do Until Reader.Read = False
                ComboBoxPosition.Items.Add(New ValueDescription(CLng(Val(Reader("PositionID").ToString)), Reader("Description").ToString, CLng(Val(Reader("ShowLicences").ToString))))
            Loop
            Reader.Close() : Reader.Dispose()
            Application.DoEvents()

            'if gMultiOfficeMode then
            '    Reader = gSQLGetDataReader("Select OfficeID, OfficeName from Offices")
            '    If Reader Is Nothing Then Exit Sub

            '    Do Until Reader.Read = False
            '        LI = ListViewOfficess.Items.Add(Reader("OfficeName").ToString)
            '        LI.Tag = "" & Reader("OfficeID").ToString
            '        LI.ToolTipText = "" & Reader("OfficeName").ToString
            '    Loop
            '    Reader.Close() : Reader.Dispose()
            'else
            '    LI = ListViewOfficess.Items.Add(gOfficeName)
            '    LI.Tag = gofficeid
            '    LI.ToolTipText = gOfficeName
            '    LI.Checked=true
            'end if

            Application.DoEvents()
            Reader = gSQLGetDataReader("SELECT DiagID, DiagName FROM Diagnostics  Where ActiveInd=1 Order by DiagName")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                LI = ListViewDoctorDiagnostics.Items.Add(Reader("DiagName").ToString)
                LI.Tag = "" & Reader("DiagID").ToString
            Loop
            Reader.Close() : Reader.Dispose()
            Application.DoEvents()
            ComboBoxAbbreviation.Items.Add("")
            Reader = gSQLGetDataReader("SELECT Abbreviation FROM EmployeesDoctorSpecialties order by Abbreviation")
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                ComboBoxAbbreviation.Items.Add(Reader("Abbreviation").ToString)
            Loop
            Reader.Close() : Reader.Dispose()

            ComboBoxreferralColor.Items.Add(New ValueDescription(Color.Black.ToArgb, "Black"))
            ComboBoxreferralColor.Items.Add(New ValueDescription(Color.DarkOrange.ToArgb, "Orange"))
            ComboBoxreferralColor.Items.Add(New ValueDescription(Color.Red.ToArgb, "Red"))
            ComboBoxreferralColor.Items.Add(New ValueDescription(Color.Green.ToArgb, "Green"))
            ComboBoxreferralColor.Items.Add(New ValueDescription(Color.Blue.ToArgb, "Blue"))
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewEmployees.DoubleClick
        cmdEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewEmployees.SelectedIndexChanged
        Dim ID As Long
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        gHighlightListviewItem(ListViewEmployees, False, False, Color.FromKnownColor(KnownColor.Highlight), Color.FromKnownColor(KnownColor.HighlightText))
        If ListViewEmployees.SelectedItems.Count = 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Clear_Controls()
        cmdEdit.Enabled = True
        cmdDelete.Enabled = True
        ID = CLng(ListViewEmployees.SelectedItems(0).Tag)
        SaveSelectedItem = ListViewEmployees.SelectedItems(0)
        Reader = gSQLGetDataReader("SELECT     Employees.* FROM Employees Where Employees.EmpID=" & ID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            txtDateHired.Text = CType(Reader("DateHired").ToString, Date).ToString("MM/dd/yyyy")
            CheckBoxActiveInd.Checked = CBool(Val(Reader("ActiveInd").ToString))
            txtFname.Text = Reader("Fname").ToString
            txtLname.Text = Reader("Lname").ToString
            If IsDate(Reader("DOB").ToString) Then txtDOB.Text = CType((Reader("DOB").ToString), Date).ToString("MM/dd/yyyy")
            txtSSN.Text = Reader("SSN").ToString
            txtAddress1.Text = Reader("Address1").ToString
            txtAddress2.Text = Reader("Address2").ToString
            txtCity.Text = Reader("City").ToString
            ComboBoxState.Text = Reader("State").ToString
            txtZip.Text = Reader("Zip").ToString
            txtPhone1.Text = Reader("Phone1").ToString
            'txtPhone2.Text = Reader("Phone2").ToString
            txtCellPhone.Text = Reader("CellPhone").ToString
            txtEmail.Text = Reader("eMail").ToString
            gFindComboItemByValue(ComboBoxPosition, CLng(Val(Reader("PositionID").ToString)), True)
            gFindComboItemByValue(ComboBoxTreatingProvider, CLng(Val(Reader("TreatingProviderId").ToString)), True)

            txtUID.Text = Reader("UID").ToString
            txtPassword.Text = gEncrypt(Reader("Password").ToString)
            txtComments.Text = Reader("Comments").ToString
            'ComboBoxMaritalStatus.SelectedValue = Reader("MaritalStatus").ToString
            TextBoxMI.Text = Reader("MI").ToString
            txtLICNumber.Text = Reader("LICNumber").ToString
            txtCorporationName.Text = Reader("CorporationName").ToString
            txtCorporationDBA.Text = Reader("CorporationDBA").ToString
            txtAccountNumber.Text = Reader("CheckingAccountNumber").ToString
            txtCorporationTaxID.Text = Reader("CorporationTaxID").ToString
            txtCorporationAddress1.Text = Reader("CorporationAddress1").ToString
            txtCorporationAddress2.Text = Reader("CorporationAddress2").ToString
            txtCorporationCity.Text = Reader("CorporationCity").ToString
            ComboBoxCorporationState.Text = Reader("CorporationState").ToString
            txtCorporationZip.Text = Reader("CorporationZip").ToString
            txtCorporatePhone.Text = Reader("CorporationPhone").ToString
            txtCorporateFax.Text = Reader("CorporationFax").ToString
            CheckBoxBillingPrv.Checked = CBool(Val(Reader("BillingPrv").ToString))
            CheckBoxTreatmentPrv.Checked = CBool(Val(Reader("TreatmentPrv").ToString))
            CheckBoxNoFault.Checked = CBool(Val(Reader("NoFaultInd").ToString))
            CheckBoxPrivate.Checked = CBool(Val(Reader("PrivateInd").ToString))
            txtAlias.Text = Reader("Alias").ToString
            txtWCBAuthorizationNumber.Text = Reader("WCBAuthorizationNumber").ToString
            txtWCBRatingCode.Text = Reader("WCBRatingCode").ToString
            txtWCProviderNPI.Text = Reader("WCProviderNPI").ToString
            'CheckBoxReadingInd.Checked = CBool(Val(Reader("ReadingInd").ToString))
            txtDoctorTitle.Text = Reader("DoctorTitle").ToString
            txtDoctorTitle1.Text = Reader("DoctorTitle1").ToString
            ComboBoxAbbreviation.Text = Reader("Abbreviation").ToString
            gFindComboItemByValue(ComboBoxreferralColor, Val(Reader("ReferralColor").ToString), True)
            If ComboBoxreferralColor.SelectedIndex = -1 Then
                ComboBoxreferralColor.SelectedIndex = 0
            End If
            If Reader("EmployeeSignature") Is DBNull.Value Then
                PictureBoxDoctorSignature.Image = Nothing
            Else
                Dim arrayImage() As Byte = CType(Reader("EmployeeSignature"), Byte())
                Dim ms As New IO.MemoryStream(arrayImage)
                PictureBoxDoctorSignature.Image = Image.FromStream(ms)
                PictureBoxDoctorSignature.Refresh()
            End If
            If Reader("PCLogo") Is DBNull.Value Then
                PictureBoxPCLogo.Image = Nothing
            Else
                Dim arrayImage() As Byte = CType(Reader("PCLogo"), Byte())
                Dim ms As New IO.MemoryStream(arrayImage)
                PictureBoxPCLogo.Image = Image.FromStream(ms)
                PictureBoxPCLogo.Refresh()
            End If

            CheckBoxEmail1.Checked = CBool(Val(Reader("EmailMessage1").ToString))
            CheckBoxEmail2.Checked = CBool(Val(Reader("EmailMessage2").ToString))
            CheckBoxEmail3.Checked = CBool(Val(Reader("EmailMessage3").ToString))
            CheckBoxEmail4.Checked = CBool(Val(Reader("EmailMessage4").ToString))
            CheckBoxEmail5.Checked = CBool(Val(Reader("EmailMessage5").ToString))
            CheckBoxEmail6.Checked = CBool(Val(Reader("EmailMessage6").ToString))
            CheckBoxEmail7.Checked = CBool(Val(Reader("EmailMessage7").ToString))
            CheckBoxEmail8.Checked = CBool(Val(Reader("EmailMessage8").ToString))
            CheckBoxEmail9.Checked = CBool(Val(Reader("EmailMessage9").ToString))
            CheckBoxEmail10.Checked = CBool(Val(Reader("EmailMessage10").ToString))

        Loop
        Reader.Close() : Reader.Dispose()
        'Dim LI As ListViewItem
        'Reader = gSQLGetDataReader("Select * from EmployeeOffice Where EmpID=" & ID)
        'Do Until Reader.Read = False
        '    For Each LI In ListViewOfficess.Items
        '        If LI.Tag = Reader("OfficeID").ToString Then
        '            LI.Checked = True
        '            Exit For
        '        End If
        '    Next
        'Loop
        'Reader.Close() : Reader.Dispose()
        Reader = gSQLGetDataReader("Select DiagID from DoctorDiagnostics Where EmpID=" & ID)
        Do Until Reader.Read = False
            For Each LI In ListViewDoctorDiagnostics.Items
                If LI.Tag = Reader("DiagID").ToString Then
                    LI.Checked = True
                    Exit For
                End If
            Next
        Loop
        Reader.Close() : Reader.Dispose()

        Application.DoEvents()
        Reader = gSQLGetDataReader("SELECT     DoctorInsuranceNPI.EmpID, DoctorInsuranceNPI.NPI, DoctorInsuranceNPI.CompanyID, InsuranceCompanies.CompanyName FROM DoctorInsuranceNPI INNER JOIN InsuranceCompanies ON DoctorInsuranceNPI.CompanyID = InsuranceCompanies.CompanyID WHERE DoctorInsuranceNPI.EmpID = " & ID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListViewNPI.Items.Add(Reader("CompanyName").ToString)
            LI.SubItems.Add(Reader("NPI").ToString)
            LI.Tag = Reader("CompanyID").ToString
        Loop
        Load_Web_Settings(ID)
        Reader.Close() : Reader.Dispose()
        Cursor = Cursors.Default
    End Sub

    Private Sub Load_Web_Settings(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        txtWebAdminUID.Text = ""
        txtWebAdminPWD.Text = ""
        txtWebAdminPWD.Tag = ""
        Reader = gSQLGetDataReader("SELECT  UserTypeID, SecID,  UserName, Password FROM WebLogins WHERE  (UserTypeID = 1 or UserTypeID = 3 or UserTypeID = 5) AND OfficeID = " & gOfficeID & " AND   UserID = " & ID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            txtWebAdminUID.Text = Reader("UserName").ToString
            txtWebAdminPWD.Text = Reader("Password").ToString
            txtWebAdminPWD.Tag = Reader("SecID").ToString
        Loop
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub Clear_Controls()
        gLoop_Clear_Controls(Me, TextBoxSearch)
        'For Each Li As ListViewItem In ListViewOfficess.Items
        '    Li.Checked = False
        'Next
        For Each LI In ListViewDoctorDiagnostics.Items
            LI.Checked = False
        Next
        ListViewNPI.Items.Clear()
        PictureBoxDoctorSignature.Image = Nothing
        PictureBoxPCLogo.Image = Nothing

        ComboBoxState.SelectedIndex = -1
        lblWebAdminUID.Visible = False
        lblWebAdminPWD.Visible = False
        GroupBoxWeb.Visible = False
        txtWebAdminUID.Text = ""
        txtWebAdminPWD.Text = ""
        CheckBoxBillingPrv.Checked = False
        CheckBoxTreatmentPrv.Checked = False
    End Sub

    Private Sub Enable_Controls(ByVal En As Boolean)

        gLoop_Enable_Controls(DoctorsTab, En)
        gLoop_Enable_Controls(DoctorsNPITab, En)
        gLoop_Enable_Controls(EmailPageTab, En)

        gLoop_Enable_Controls(Me, En)
        ListViewNPI.BackColor = IIf(En, Color.White, Color.WhiteSmoke)
        ButtonDeleteNPI.Enabled = En
        ButtonAddNPI.Enabled = En
        PictureBoxDoctorSignature.Enabled = En
        PictureBoxPCLogo.Enabled = En

        PictureBoxDoctorSignature.BackColor = IIf(En, Color.White, Color.WhiteSmoke)
        PictureBoxPCLogo.BackColor = IIf(En, Color.White, Color.WhiteSmoke)

        cmdSelectPicturePCLogo.Enabled = En
        cmdRemovePCLogo.Enabled = En

        cmdRemovePicture.Enabled = En
        cmdSelectPicture.Enabled = En
        cmdSelectPictureFile.Enabled = En
        'ListViewOfficess.Enabled = En
        ListViewEmployees.Enabled = Not En
        ListViewDoctorDiagnostics.Enabled = En
        CheckBoxEmail1.Enabled = En
        CheckBoxEmail2.Enabled = En
        CheckBoxEmail3.Enabled = En
        CheckBoxEmail4.Enabled = En
        CheckBoxEmail5.Enabled = En
        CheckBoxEmail6.Enabled = En
        CheckBoxEmail7.Enabled = En
        CheckBoxEmail8.Enabled = En
        CheckBoxEmail9.Enabled = En
        CheckBoxEmail10.Enabled = En
        ButtonDistribute.Enabled = Not En
        cmdAddNew.Enabled = Not En
        cmdUpdate.Enabled = En
        cmdCancel.Enabled = En
        ButtonWebAdminRefresh.Enabled = En
        TextBoxSearch.Enabled = Not En
        If En = False Then
            If ListViewEmployees.Items.Count > 0 Then
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

    Private Sub cmdAddNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddNew.Click
        OpMode = AddEditMode.AddNew
        'If TabControl1.TabCount = 2 Then
        ' TabControl1.TabPages.Insert(2, DoctorsTab)
        'End If
        Enable_Controls(True)
        Clear_Controls()
        If TabControl1.TabCount = 2 Then
            TabControl1.TabPages.Insert(2, DoctorsTab)
            'Doctors
            TabControl1.TabPages.RemoveAt(2)
        End If
        txtDateHired.Text = Now.ToString("MM/dd/yyyy")
        ComboBoxState.Text = gDefaultState
        ComboBoxCorporationState.Text = gDefaultState
        CheckBoxActiveInd.Checked = True
        TabControl1.SelectedIndex = 0
        ComboBoxreferralColor.SelectedIndex = 0
        ComboBoxAbbreviation.SelectedIndex = 0
        lblAbbreviationDescription.Text = ""
        Produce_Login(2)
        txtFname.Focus()
    End Sub
    Private Sub load_treatment_providers()
        Dim Reader As SqlDataReader
        Application.DoEvents()
        Reader = gSQLGetDataReader("SELECT EmpID, isnull(Fname,'') +' ' + isnull(Lname,'') as docname FROM Employees WHERE        (TreatmentPrv = 1)")
        If Reader Is Nothing Then Exit Sub
        ComboBoxTreatingProvider.Items.Clear()
        Do Until Reader.Read = False
            ComboBoxTreatingProvider.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("docname").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        Application.DoEvents()

    End Sub
    Private Sub Produce_WebLogin(Optional ByVal Force As Integer = 0)
        Dim KeyGen As RandomKeyGenerator = New RandomKeyGenerator
        KeyGen.KeyLetters = "abcdefghkmnpqrstuvwxyz".ToUpper
        KeyGen.KeyNumbers = "123456789"
        KeyGen.KeyChars = 4
        If txtWebAdminUID.Text = "" Or Force = 2 Then txtWebAdminUID.Text = gSQLGetSingleValue("SELECT IDENT_CURRENT('WebLogins')") + 1 & "A" & KeyGen.Generate
        KeyGen.KeyChars = 5
        If txtWebAdminPWD.Text = "" Or Force = 2 Then txtWebAdminPWD.Text = "P" & KeyGen.Generate
    End Sub

    Private Sub Produce_Login(Optional ByVal Force As Integer = 0)
        Dim KeyGen As RandomKeyGenerator = New RandomKeyGenerator
        KeyGen.KeyLetters = "abcdefghkmnpqrstuvwxyz".ToUpper
        KeyGen.KeyNumbers = "123456789"
        KeyGen.KeyChars = 5
        Dim k As String
retry:
        k = "U" & KeyGen.Generate
        If gMultiOfficeMode And 1 = 2 Then
            For Each office As Office In gOffices
                If gSQLGetSingleValue("SELECT count(*) FROM Employees where UID = '" & k & "'", office.ConnectionString) > 0 Then
                    GoTo retry
                End If
            Next
        Else
            If gSQLGetSingleValue("SELECT count(*) FROM Employees where UID = '" & k & "'") > 0 Then
                GoTo retry
            End If
        End If
        If txtUID.Text = "" Or Force = 2 Then txtUID.Text = k
        KeyGen.KeyChars = 5
        If txtPassword.Text = "" Or Force = 2 Then txtPassword.Text = "P" & KeyGen.Generate
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
        OpMode = AddEditMode.None
        Enable_Controls(False)
        If Not SaveSelectedItem Is Nothing Then
            ListView1_SelectedIndexChanged(Nothing, Nothing)
        Else
            If ListViewEmployees.Items.Count > 0 Then
                ListViewEmployees.Items(0).Selected = True
                ListViewEmployees.Items(0).EnsureVisible()
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            End If
        End If
        gLoop_ResetErrors_Controls(ErrorProvider1, Me)
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEdit.Click
        OpMode = AddEditMode.Edit
        Enable_Controls(True)
        If TabControl1.SelectedIndex = 0 Then
            txtFname.Focus()
            txtFname.SelectAll()
        Else
            txtDateHired.Focus()
            txtDateHired.SelectAll()
        End If
        For Each office As Office In gOffices
            office.Updated = False
        Next

        'Produce_WebUserName()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
        Dim lMultiOfficeModeUpdate As Boolean
        lMultiOfficeModeUpdate = False
        If ValidateData() = False Then Exit Sub
        If ValidateCredentials(lMultiOfficeModeUpdate) = False Then Exit Sub
        If lMultiOfficeModeUpdate Then
            For Each office As Office In gOffices
                If office.ConnectionString <> "" Then
                    UpdateEmployee(office.ConnectionString, office.OfficeName)
                End If
            Next
        Else
            UpdateEmployee(gConnectionString, gOfficeName)
        End If

    End Sub

    Private Function ValidateData() As Boolean
        If SaveSelectedItem Is Nothing And OpMode = AddEditMode.Edit Then
            MsgBox("Unexpected Error. Please try again.")
            cmdCancel_Click(Nothing, Nothing)
            Return False
        End If
        gLoop_Trim_Controls(Me)

        If txtFname.Text = "" Then
            TabControl1.SelectedIndex = 0
            ErrorProvider1.SetError(txtFname, "Unable to process update. The Employee's First Name is required.")
            MsgBox("Unable to process update." & vbCrLf & "The Employee's First Name is required.", MsgBoxStyle.Exclamation)
            txtFname.Focus()
            Return False
        End If
        If txtLname.Text = "" Then
            TabControl1.SelectedIndex = 0
            ErrorProvider1.SetError(txtLname, "Unable to process update. The Employee's Last Name is required.")
            MsgBox("Unable to process update." & vbCrLf & "The Employee's Last Name is required.", MsgBoxStyle.Exclamation)
            txtLname.Focus()
            Return False
        End If

        'Work Information
        If ComboBoxPosition.SelectedItem Is Nothing Then
            TabControl1.SelectedIndex = 1
            ErrorProvider1.SetError(ComboBoxPosition, "Unable to process update. The employee position should be specified.")
            MsgBox("Unable to process update." & vbCrLf & "The employee position should be specified.", MsgBoxStyle.Exclamation)
            ComboBoxPosition.Focus()
            Return False
        Else
            If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 1 And CheckBoxActiveInd.Checked = False Then
                TabControl1.SelectedIndex = 1
                ErrorProvider1.SetError(CheckBoxActiveInd, "Unable to process update. Can Not to set Administrator Profile as Inactive.")
                ErrorProvider1.SetError(ComboBoxPosition, "Unable to process update. Can Not to set Administrator Profile as Inactive.")
                MsgBox("Unable to process update." & vbCrLf & "Can Not to set Administrator Profile as Inactive.", MsgBoxStyle.Exclamation)
                ComboBoxPosition.Focus()
                Return False
            End If
        End If


        If txtDateHired.MaskCompleted = False Then
            TabControl1.SelectedIndex = 1
            ErrorProvider1.SetError(txtDateHired, "Unable to process update. The Employee's Hire Date is required.")
            MsgBox("Unable to process update." & vbCrLf & "The Employee's Hire Date is required.", MsgBoxStyle.Exclamation)
            txtDateHired.Focus()

            Return False
        End If
        If IsDate(txtDateHired.Text) = False Then
            TabControl1.SelectedIndex = 1
            ErrorProvider1.SetError(txtDateHired, "Unable to process update. Invalid Hire Date specified.")
            MsgBox("Unable to process update." & vbCrLf & "Invalid Hire Date specified.", MsgBoxStyle.Exclamation)
            txtDateHired.Focus()
            txtDateHired.SelectAll()
            Return False
        End If
        If CDate(txtDateHired.Text) < CDate("1/1/2000") Then
            TabControl1.SelectedIndex = 1
            ErrorProvider1.SetError(txtDateHired, "Unable to process update. Invalid Hire Date specified. The Hire Date should be grater then 1/1/2000")
            MsgBox("Unable to process update." & vbCrLf & "Invalid Hire Date specified. The Hire Date should be grater then 1/1/2000", MsgBoxStyle.Exclamation)
            txtDateHired.Focus()
            txtDateHired.SelectAll()
            Return False
        End If

        If ComboBoxPosition.SelectedIndex = -1 Then
            TabControl1.SelectedIndex = 1
            ErrorProvider1.SetError(ComboBoxPosition, "Unable to process update. The Employee's Position should be selected.")
            MsgBox("Unable to process update." & vbCrLf & "The Employee's Position should be selected.", MsgBoxStyle.Exclamation)
            ComboBoxPosition.Focus()
            Return False
        End If
        If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100 Then
            If ComboBoxTreatingProvider.SelectedItem Is Nothing Then
                TabControl1.SelectedIndex = 1
                ErrorProvider1.SetError(ComboBoxTreatingProvider, "Unable to process update. The Transcriptionist Treating provider should be selected.")
                MsgBox("Unable to process update." & vbCrLf & "The Transcriptionist Treating provider should be selected.", MsgBoxStyle.Exclamation)
                ComboBoxTreatingProvider.Focus()
                Return False
            End If

        End If
        If txtUID.Text = "" Then
            TabControl1.SelectedIndex = 1
            ErrorProvider1.SetError(txtUID, "Unable to process update. The Employee's User Name is required.")
            MsgBox("Unable to process update." & vbCrLf & "The Employee's User Name is required.", MsgBoxStyle.Exclamation)
            txtUID.Focus()
            Return False
        End If
        If txtPassword.Text = "" Then
            TabControl1.SelectedIndex = 1
            ErrorProvider1.SetError(txtPassword, "Unable to process update. The Employee's Password is required.")
            MsgBox("Unable to process update." & vbCrLf & "The Employee's Password is required.", MsgBoxStyle.Exclamation)
            txtPassword.Focus()
            Return False
        End If

        If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 1 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 2 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 5 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100 Then
            If txtWebAdminUID.Text.Trim <> "" And txtWebAdminPWD.Text.Trim = "" Then
                TabControl1.SelectedIndex = 1
                ErrorProvider1.SetError(txtWebAdminPWD, "Unable to process update. You have specified Web User Name. The Web Password should be specified.")
                MsgBox("Unable to process update." & vbCrLf & "You have specified Web User Name. The Web Password should be specified.", MsgBoxStyle.Exclamation)
                txtWebAdminUID.Focus()
                Return False
            End If
            If txtWebAdminUID.Text.Trim = "" And txtWebAdminPWD.Text.Trim <> "" Then
                TabControl1.SelectedIndex = 1
                ErrorProvider1.SetError(txtWebAdminUID, "Unable to process update. You have specified Web Password. The Web User Name should be specified.")
                MsgBox("Unable to process update." & vbCrLf & "You have specified Web Password. The Web User Name should be specified.", MsgBoxStyle.Exclamation)
                txtWebAdminUID.Focus()
                Return False
            End If

        End If

        If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value1 = 1 Then  ' Doctor
            If txtLICNumber.Text = "" Then
                TabControl1.SelectedIndex = 2
                ErrorProvider1.SetError(txtLICNumber, "Unable to process update. The Doctor's License Number is required.")
                MsgBox("Unable to process update." & vbCrLf & "The Doctor's License Number is required.", MsgBoxStyle.Exclamation)
                txtLICNumber.Focus()
                Return False
            End If

            If CheckBoxBillingPrv.Checked = False And CheckBoxTreatmentPrv.Checked = False Then

                TabControl1.SelectedIndex = 2
                ErrorProvider1.SetError(CheckBoxBillingPrv, "The Doctor is Billing Provider or Treatment Provider or Procedure Reading should be specified.")
                ErrorProvider1.SetError(CheckBoxTreatmentPrv, "The Doctor is Billing Provider or Treatment Provider or Procedure Reading should be specified.")
                MsgBox("Unable to process update." & vbCrLf & "The Doctor is Billing Provider or Treatment Provider or Procedure Reading should be specified.", MsgBoxStyle.Exclamation)
                CheckBoxBillingPrv.Select()
                Return False
            End If
            If CheckBoxNoFault.Checked = False And CheckBoxPrivate.Checked = False Then
                TabControl1.SelectedIndex = 2
                ErrorProvider1.SetError(CheckBoxNoFault, "The Doctor NoFault or Private should be specified.")
                ErrorProvider1.SetError(CheckBoxPrivate, "The Doctor NoFault or Private should be specified.")
                MsgBox("Unable to process update." & vbCrLf & "The Doctor NoFault or Private should be specified.", MsgBoxStyle.Exclamation)
                CheckBoxNoFault.Select()
                Return False
            End If
            If ComboBoxreferralColor.SelectedIndex = -1 Then
                TabControl1.SelectedIndex = 2
                ErrorProvider1.SetError(ComboBoxreferralColor, "The Doctor Referral Color should be specified.")
                MsgBox("Unable to process update." & vbCrLf & "The Doctor Referral Color should be specified.", MsgBoxStyle.Exclamation)
                ComboBoxreferralColor.Select()
                Return False
            End If
            If txtCorporationName.Text <> "" Then
                If txtCorporationAddress1.Text = "" Then
                    TabControl1.SelectedIndex = 2
                    ErrorProvider1.SetError(txtCorporationAddress1, "Unable to process update. The Corporation Address is required.")
                    MsgBox("Unable to process update." & vbCrLf & "The Corporation Address is required.", MsgBoxStyle.Exclamation)
                    txtCorporationAddress1.Focus()
                    Return False
                End If
                If txtCorporationCity.Text = "" Then
                    TabControl1.SelectedIndex = 2
                    ErrorProvider1.SetError(txtCorporationCity, "Unable to process update. The Corporation Address City is required.")
                    MsgBox("Unable to process update." & vbCrLf & "The Corporation Address City is required.", MsgBoxStyle.Exclamation)
                    txtCorporationCity.Focus()
                    Return False
                End If
                If ComboBoxCorporationState.SelectedIndex = -1 Then
                    TabControl1.SelectedIndex = 2
                    ErrorProvider1.SetError(ComboBoxCorporationState, "Unable to process update. The Corporation Address State is required.")
                    MsgBox("Unable to process update." & vbCrLf & "The Corporation Address State is required.", MsgBoxStyle.Exclamation)
                    ComboBoxCorporationState.Focus()
                    Return False
                End If
                If txtCorporationZip.MaskCompleted = False Then
                    TabControl1.SelectedIndex = 2
                    ErrorProvider1.SetError(txtCorporationZip, "Unable to process update. Invalid or Incomplete Corporation Address Zip Code.")
                    MsgBox("Unable to process update." & vbCrLf & "Invalid or Incomplete Corporation Address Zip Code.", MsgBoxStyle.Exclamation)
                    txtCorporationZip.Focus()
                    Return False
                End If
                If txtCorporatePhone.MaskCompleted = False Then
                    TabControl1.SelectedIndex = 2
                    ErrorProvider1.SetError(txtCorporationZip, "Unable to process update. Invalid or Incomplete Corporation Phone.")
                    MsgBox("Unable to process update." & vbCrLf & "Invalid or Incomplete Corporation Phone.", MsgBoxStyle.Exclamation)
                    txtCorporatePhone.Focus()
                    Return False
                End If
                If txtCorporateFax.MaskCompleted = False Then
                    TabControl1.SelectedIndex = 2
                    ErrorProvider1.SetError(txtCorporationZip, "Unable to process update. Invalid or Incomplete Corporation Fax.")
                    MsgBox("Unable to process update." & vbCrLf & "Invalid or Incomplete Corporation Fax.", MsgBoxStyle.Exclamation)
                    txtCorporateFax.Focus()
                    Return False
                End If

                If ListViewDoctorDiagnostics.CheckedItems.Count = 0 Then
                    TabControl1.SelectedIndex = 2
                    ErrorProvider1.SetError(ListViewDoctorDiagnostics, "The Doctor's Specialisation / Diagnostics should be checked")
                    MsgBox("Unable to process update." & vbCrLf & "The Doctor's Specialisation / Diagnostics should be checked.", MsgBoxStyle.Exclamation)
                    ListViewDoctorDiagnostics.Select()
                    ListViewDoctorDiagnostics.Focus()
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Function ValidateCredentials(MultiOfficeMode As Boolean) As Boolean
        Dim ID As Long
        Dim Reader As SqlDataReader
        If MultiOfficeMode Then
            For Each office As Office In gOffices
                If OpMode = AddEditMode.Edit Then
                    ID = CLng(SaveSelectedItem.Tag)
                    Reader = gSQLGetDataReader("Select * from Employees Where EmpID<>" & ID & " and UID='" & txtUID.Text.ToSafeSQLString() & "'", office.ConnectionString)
                Else
                    ID = -1
                    Reader = gSQLGetDataReader("Select * from Employees Where UID='" & txtUID.Text.ToSafeSQLString() & "'", office.ConnectionString)
                End If
                If Reader.Read() = True Then
                    TabControl1.SelectedIndex = 1
                    ErrorProvider1.SetError(txtUID, "Unable to process update. The User Name is already in use in the office " & office.OfficeName)
                    MsgBox("Unable to process update." & vbCrLf & "The User Name is already in use in the office " & office.OfficeName & vbCrLf & "Please choose another User Name.", MsgBoxStyle.Exclamation)
                    TabControl1.SelectedIndex = 1
                    txtUID.Focus()
                    txtUID.SelectAll()
                    Return False
                End If
                Reader.Close() : Reader.Dispose()
                If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 1 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 2 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 5 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100 Then
                    If Validate_WebLogin(ID, txtWebAdminUID.Text.ToSafeSQLString(), office.ConnectionString) = False Then
                        TabControl1.SelectedIndex = 1
                        ErrorProvider1.SetError(txtWebAdminUID, "Unable to process update. The Web Web User Name is already in use in the office OfficeName")
                        MsgBox("Unable to process update." & vbCrLf & "The Web User Name is already in use in the office " & office.OfficeName & vbCrLf & "Please choose another Web User Name.", MsgBoxStyle.Exclamation)
                        TabControl1.SelectedIndex = 1
                        txtWebAdminUID.Focus()
                        txtWebAdminUID.SelectAll()
                        Return False
                    End If
                End If
            Next
        Else
            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
                Reader = gSQLGetDataReader("Select * from Employees Where EmpID<>" & ID & " and UID='" & txtUID.Text.ToSafeSQLString() & "'", gConnectionString)
            Else
                ID = -1
                Reader = gSQLGetDataReader("Select * from Employees Where UID='" & txtUID.Text.ToSafeSQLString() & "'", gConnectionString)
            End If
            If Reader.Read() = True Then
                TabControl1.SelectedIndex = 1
                ErrorProvider1.SetError(txtUID, "Unable to process update. The User Name is already in use in the office " & gOfficeName)
                MsgBox("Unable to process update." & vbCrLf & "The User Name is already in use in the office " & gOfficeName & vbCrLf & "Please choose another User Name.", MsgBoxStyle.Exclamation)
                TabControl1.SelectedIndex = 1
                txtUID.Focus()
                txtUID.SelectAll()
                Return False
            End If
            Reader.Close() : Reader.Dispose()
            If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 1 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 2 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 5 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100 Then
                If Validate_WebLogin(ID, txtWebAdminUID.Text.ToSafeSQLString(), gConnectionString) = False Then
                    TabControl1.SelectedIndex = 1
                    ErrorProvider1.SetError(txtWebAdminUID, "Unable to process update. The Web Web User Name is already in use in the office OfficeName")
                    MsgBox("Unable to process update." & vbCrLf & "The Web User Name is already in use in the office " & gOfficeName & vbCrLf & "Please choose another Web User Name.", MsgBoxStyle.Exclamation)
                    TabControl1.SelectedIndex = 1
                    txtWebAdminUID.Focus()
                    txtWebAdminUID.SelectAll()
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Function CopyValidateCredentials(UID As String, WebUID As String, ConnectionString As String) As Boolean
        Dim ID As Long
        Dim Reader As SqlDataReader
        If gSQLGetSingleValue("Select count(*) from Employees Where UID='" & UID.ToSafeSQLString() & "'", ConnectionString) > 0 Then
            Return False
        End If
        Reader.Close() : Reader.Dispose()
        If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 1 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 2 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 5 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100 Then
            If Validate_WebLogin(ID, txtWebAdminUID.Text.ToSafeSQLString(), gConnectionString) = False Then
                TabControl1.SelectedIndex = 1
                ErrorProvider1.SetError(txtWebAdminUID, "Unable to process update. The Web Web User Name is already in use in the office OfficeName")
                MsgBox("Unable to process update." & vbCrLf & "The Web User Name is already in use in the office " & gOfficeName & vbCrLf & "Please choose another Web User Name.", MsgBoxStyle.Exclamation)
                TabControl1.SelectedIndex = 1
                txtWebAdminUID.Focus()
                txtWebAdminUID.SelectAll()
                Return False
            End If
        End If
        Return True
    End Function

    Private Function UpdateEmployee(ConnectionString As String, OfficeName As String) As Boolean
        Dim ID As Long
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader

        Dim WebUserTypeID As Integer
        Try
            If OpMode = AddEditMode.Edit Then
                ID = CLng(SaveSelectedItem.Tag)
            Else
                ID = -1
            End If

            Dim TA As New SqlClient.SqlDataAdapter("SELECT * FROM Employees Where EmpID = " & ID, ConnectionString)
            Dim CB As New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            Dim TR As DataRow
            Dim dTab As New DataTable("Employees")

            TA.Fill(dTab)

            If OpMode = AddEditMode.AddNew Then
                TR = dTab.NewRow
            Else
                TR = dTab.Rows(0)
            End If
            TR("Fname") = txtFname.Text
            TR("Lname") = txtLname.Text
            TR("MI") = TextBoxMI.Text
            TR("Alias") = txtAlias.Text
            If IsDate(txtDOB.Text) Then TR("DOB") = txtDOB.Text
            TR("SSN") = txtSSN.Text
            TR("Address1") = txtAddress1.Text
            TR("Address2") = txtAddress2.Text
            TR("City") = txtCity.Text
            TR("State") = ComboBoxState.Text
            If txtZip.MaskCompleted Then TR("Zip") = txtZip.Text Else TR("Zip") = ""
            If txtPhone1.MaskCompleted Then TR("Phone1") = txtPhone1.Text Else TR("Phone1") = ""
            'If txtPhone2.MaskCompleted Then TR("Phone2") = txtPhone2.Text Else TR("Phone2") = ""
            If txtCellPhone.MaskCompleted Then TR("CellPhone") = txtCellPhone.Text Else TR("CellPhone") = ""
            TR("eMail") = txtEmail.Text
            TR("PositionID") = CType(ComboBoxPosition.SelectedItem, ValueDescription).Value
            If IsDate(txtDateHired.Text) Then TR("DateHired") = txtDateHired.Text
            TR("UID") = txtUID.Text
            TR("Password") = gEncrypt(txtPassword.Text)
            TR("ActiveInd") = IIf(CheckBoxActiveInd.Checked, 1, 0)
            TR("LICNumber") = txtLICNumber.Text
            TR("Comments") = txtComments.Text
            TR("TreatingProviderId") = 0
            If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100 Then
                If Not ComboBoxTreatingProvider.SelectedItem Is Nothing Then
                    TR("TreatingProviderId") = CType(ComboBoxTreatingProvider.SelectedItem, ValueDescription).Value
                End If
            End If

            If TabControl1.TabPages.ContainsKey("DoctorInfo") Then

                If txtCorporatePhone.MaskCompleted Then TR("CorporationPhone") = txtCorporatePhone.Text Else TR("CorporationPhone") = ""
                If txtCorporateFax.MaskCompleted Then TR("CorporationFax") = txtCorporateFax.Text Else TR("CorporationFax") = ""
                TR("LICNumber") = txtLICNumber.Text
                TR("CorporationName") = txtCorporationName.Text
                TR("CorporationDBA") = txtCorporationDBA.Text
                TR("CheckingAccountNumber") = txtAccountNumber.Text.Trim
                TR("CorporationAddress1") = txtCorporationAddress1.Text
                TR("CorporationAddress2") = txtCorporationAddress2.Text
                TR("CorporationCity") = txtCorporationCity.Text
                TR("CorporationState") = ComboBoxCorporationState.Text
                If txtCorporationZip.MaskCompleted Then TR("CorporationZip") = txtCorporationZip.Text Else TR("CorporationZip") = ""
                TR("BillingPrv") = IIf(CheckBoxBillingPrv.Checked, 1, 0)
                TR("TreatmentPrv") = IIf(CheckBoxTreatmentPrv.Checked, 1, 0)
                TR("CorporationTaxID") = txtCorporationTaxID.Text
                TR("DoctorTitle") = txtDoctorTitle.Text
                TR("DoctorTitle1") = txtDoctorTitle1.Text
                TR("Abbreviation") = ComboBoxAbbreviation.Text

                TR("NoFaultInd") = IIf(CheckBoxNoFault.Checked, 1, 0)
                TR("PrivateInd") = IIf(CheckBoxPrivate.Checked, 1, 0)
                TR("ReferralColor") = CType(ComboBoxreferralColor.SelectedItem, ValueDescription).Value
                TR("WCBAuthorizationNumber") = txtWCBAuthorizationNumber.Text
                TR("WCBRatingCode") = txtWCBRatingCode.Text
                TR("WCProviderNPI") = txtWCProviderNPI.Text
            Else
                TR("DoctorID") = ""
                TR("LICNumber") = ""
                TR("CorporationName") = ""
                TR("CheckingAccountNumber") = ""
                TR("CorporationAddress1") = ""
                TR("CorporationAddress2") = ""
                TR("CorporationCity") = ""
                TR("CorporationState") = ""
                TR("CorporationZip") = ""
                TR("BillingPrv") = 0
                TR("TreatmentPrv") = 0
                TR("CorporationTaxID") = ""
                TR("DoctorTitle") = ""
                TR("NoFaultInd") = 0
                TR("PrivateInd") = 0
                TR("ReferralColor") = 0
                TR("WCBAuthorizationNumber") = ""
                TR("WCBRatingCode") = ""
                TR("WCProviderNPI") = ""
                TR("CorporationPhone") = ""
                TR("CorporationFax") = ""

            End If
            If TabControl1.TabPages.Contains(EmailTab) Then
                TR("EmailMessage1") = IIf(CheckBoxEmail1.Checked, 1, 0)
                TR("EmailMessage2") = IIf(CheckBoxEmail2.Checked, 1, 0)
                TR("EmailMessage3") = IIf(CheckBoxEmail3.Checked, 1, 0)
                TR("EmailMessage4") = IIf(CheckBoxEmail4.Checked, 1, 0)
                TR("EmailMessage5") = IIf(CheckBoxEmail5.Checked, 1, 0)
                TR("EmailMessage6") = IIf(CheckBoxEmail6.Checked, 1, 0)
                TR("EmailMessage7") = IIf(CheckBoxEmail7.Checked, 1, 0)
                TR("EmailMessage8") = IIf(CheckBoxEmail8.Checked, 1, 0)
                TR("EmailMessage9") = IIf(CheckBoxEmail9.Checked, 1, 0)
                TR("EmailMessage10") = IIf(CheckBoxEmail10.Checked, 1, 0)
            Else
                TR("EmailMessage1") = 0
                TR("EmailMessage2") = 0
                TR("EmailMessage3") = 0
                TR("EmailMessage4") = 0
                TR("EmailMessage5") = 0
                TR("EmailMessage6") = 0
                TR("EmailMessage7") = 0
                TR("EmailMessage8") = 0
                TR("EmailMessage9") = 0
                TR("EmailMessage10") = 0
            End If

            ''' Update Logo
            If PictureBoxDoctorSignature.Image Is Nothing Then
                TR("EmployeeSignature") = DBNull.Value
                TR("EmployeeSignatureInd") = 0
            Else
                Dim ms As New IO.MemoryStream
                PictureBoxDoctorSignature.Image.Save(ms, Imaging.ImageFormat.Png)
                Dim arrImage() As Byte = ms.GetBuffer
                TR("EmployeeSignature") = arrImage
                TR("EmployeeSignatureInd") = 1
                ms.Close()

            End If

            ''' Update PC Logo
            If PictureBoxPCLogo.Image Is Nothing Then
                TR("PCLogo") = DBNull.Value
                TR("PCLogoInd") = 0
            Else
                Dim ms As New IO.MemoryStream
                PictureBoxPCLogo.Image.Save(ms, Imaging.ImageFormat.Png)
                Dim arrImage() As Byte = ms.GetBuffer
                TR("PCLogo") = arrImage
                TR("PCLogoInd") = 1
                ms.Close()

            End If

            ''''''''''''''''
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
                Return False
            End Try
            dTab.Dispose()
            CB.Dispose()
            TA.Dispose()

            If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 1 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 2 Then
                WebUserTypeID = 3
            ElseIf CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 5 Then
                WebUserTypeID = 1
            ElseIf CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100 Then
                WebUserTypeID = 5
            End If
            load_treatment_providers()
            If OpMode = AddEditMode.AddNew Then

                Reader = gSQLGetDataReader("Select * from Employees Where EmpID = IDENT_CURRENT('Employees')", ConnectionString)
                If Reader Is Nothing Then Return False
                Do Until Reader.Read = False
                    LI = ListViewEmployees.Items.Add(Reader("FName").ToString & " " & Reader("LName").ToString, CInt(Val("" & Reader("ActiveInd").ToString)))
                    LI.Tag = "" & Reader("EmpID").ToString
                    If ListViewEmployees.SelectedItems.Count > 0 Then ListViewEmployees.SelectedItems(0).Selected = False

                    ID = CLng(Val(Reader("EmpID").ToString))
                    SaveSelectedItem = LI
                Loop
                Reader.Close() : Reader.Dispose()
                'Validate_WebLogin()
                If txtWebAdminUID.Text <> "" And (CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 1 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 2 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 5 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100) Then
                    gSQLUpdateData("INSERT INTO WebLogins ( UserID, OfficeID, UserName, Password, UserTypeID) VALUES(" & ID & ", " & gOfficeID & ", '" & txtWebAdminUID.Text.ToSafeSQLString() & "', '" & txtWebAdminPWD.Text.ToSafeSQLString() & "', " & WebUserTypeID & ")", ConnectionString)
                End If
            Else
                If txtWebAdminUID.Text <> "" And (CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 1 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 2 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 5 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100) Then
                    If IsNumeric(txtWebAdminPWD.Tag) = False Then
                        gSQLUpdateData("INSERT INTO WebLogins ( UserID, OfficeID, UserName, Password, UserTypeID) VALUES(" & ID & ", " & gOfficeID & ", '" & txtWebAdminUID.Text.ToSafeSQLString() & "', '" & txtWebAdminPWD.Text.ToSafeSQLString() & "', " & WebUserTypeID & ")", ConnectionString)
                    Else
                        gSQLUpdateData("UPDATE WebLogins SET UserTypeID=" & WebUserTypeID & ", UserName = '" & txtWebAdminUID.Text.ToSafeSQLString() & "', Password = '" & txtWebAdminPWD.Text.ToSafeSQLString() & "' Where SecID=" & Val(txtWebAdminPWD.Tag), ConnectionString)
                    End If
                Else
                    gSQLUpdateData("DELETE FROM WebLogins Where SecID=" & Val(txtWebAdminPWD.Tag), ConnectionString)
                End If
                gSQLDeleteRecord("Delete from EmployeeOffice Where EmpID=" & ID, ConnectionString)
                SaveSelectedItem.Text = txtFname.Text & " " & txtLname.Text
            End If
            If CheckBoxActiveInd.Checked = True Then
                SaveSelectedItem.ImageIndex = 1
            Else
                SaveSelectedItem.ImageIndex = 0
            End If

            TA = New SqlClient.SqlDataAdapter("SELECT EmpID, OfficeID FROM EmployeeOffice Where 1=2", ConnectionString)
            CB = New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            dTab = New DataTable("EmployeeOffice")
            TA.Fill(dTab)
            If gMultiOfficeMode Then
                For Each office As Office In gOffices
                    TR = dTab.NewRow
                    TR("EmpID") = ID
                    TR("OfficeID") = office.OfficeID
                    dTab.Rows.Add(TR)
                Next
            Else
                TR = dTab.NewRow
                TR("EmpID") = ID
                TR("OfficeID") = gOfficeID
                dTab.Rows.Add(TR)
            End If

            'For Each LI In ListViewOfficess.Items
            '    If LI.Checked Then
            '        TR = dTab.NewRow
            '        TR("EmpID") = ID
            '        TR("OfficeID") = CType(LI.Tag, Integer)
            '        dTab.Rows.Add(TR)
            '    End If
            'Next
            TA.UpdateCommand = CB.GetUpdateCommand(True)
            Try
                TA.Update(dTab)
                dTab.AcceptChanges()
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
                Return False
            End Try
            dTab.Dispose() : CB.Dispose() : TA.Dispose()

            gSQLDeleteRecord("Delete from DoctorDiagnostics Where EmpID=" & ID, ConnectionString)
            If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value1 = 1 Then
                TA = New SqlClient.SqlDataAdapter("SELECT ID, EmpID, DiagID FROM DoctorDiagnostics Where 1=2", ConnectionString)
                CB = New SqlClient.SqlCommandBuilder(TA)
                CB.ConflictOption = ConflictOption.OverwriteChanges
                dTab = New DataTable("DoctorDiagnostics")
                TA.Fill(dTab)
                For Each LI In ListViewDoctorDiagnostics.Items
                    If LI.Checked Then
                        TR = dTab.NewRow
                        TR("EmpID") = ID
                        TR("DiagID") = CType(LI.Tag, Integer)
                        dTab.Rows.Add(TR)
                    End If
                Next
                TA.UpdateCommand = CB.GetUpdateCommand(True)
                Try
                    TA.Update(dTab)
                    dTab.AcceptChanges()
                Catch ex As Exception
                    TopMost = False
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    log.Error(ex.Message, ex)
                    Return False
                End Try
            End If

            gSQLDeleteRecord("DELETE FROM DoctorInsuranceNPI Where EmpID = " & ID, ConnectionString)
            TA = New SqlClient.SqlDataAdapter("SELECT  * FROM DoctorInsuranceNPI Where 1=2", ConnectionString)
            CB = New SqlClient.SqlCommandBuilder(TA)
            CB.ConflictOption = ConflictOption.OverwriteChanges
            dTab = New DataTable("DoctorInsuranceNPI")

            TA.Fill(dTab)
            For Each LI In ListViewNPI.Items
                TR = dTab.NewRow
                TR("CompanyID") = LI.Tag
                TR("EmpID") = ID
                TR("NPI") = LI.SubItems(1).Text
                dTab.Rows.Add(TR)
            Next
            TA.UpdateCommand = CB.GetUpdateCommand(True)
            Try
                TA.Update(dTab)
                dTab.AcceptChanges()
            Catch ex As Exception
                TopMost = False
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error(ex.Message, ex)
                Return False
            End Try
            dTab.Dispose() : CB.Dispose() : TA.Dispose()

            OpMode = AddEditMode.None
            Enable_Controls(False)
            gLoop_ResetErrors_Controls(ErrorProvider1, Me)
            If ListViewEmployees.SelectedItems.Count > 0 Then
                If SaveSelectedItem Is Nothing Then SaveSelectedItem.Selected = True
                If SaveSelectedItem Is Nothing Then SaveSelectedItem.EnsureVisible()
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            End If
            Return True
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            Return False
        End Try

    End Function

    Private Function Validate_WebLogin(ByVal ID As Integer, ByVal UID As String, connectionString As String) As Boolean
        If gSQLGetSingleValue("SELECT COUNT(*) FROM WebLogins WHERE (UserID <> " & ID & ") AND (UserName = '" & UID.ToSafeSQLString() & "')", connectionString) > 0 Then
            Validate_WebLogin = False
        Else
            Validate_WebLogin = True
        End If

    End Function

    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
        Dim ID As Long
        If ListViewEmployees.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete. No Employee selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to delete the employee " & ListViewEmployees.SelectedItems(0).Text & "?" & vbCrLf & vbCrLf & "It is highly recommended to use the Active Indicator to disable Employee.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ID = CLng(ListViewEmployees.SelectedItems(0).Tag)
        If gSQLDeleteRecord("DELETE FROM EMPLOYEES WHERE EmpID=" & ID) Then
            ListViewEmployees.Items.Remove(ListViewEmployees.SelectedItems(0))
            SaveSelectedItem = Nothing
            If ListViewEmployees.SelectedItems.Count > 0 Then
                ListView1_SelectedIndexChanged(Nothing, Nothing)
            Else
                Clear_Controls()
                cmdEdit.Enabled = False
                cmdDelete.Enabled = False
            End If
        End If

    End Sub

    Private Sub txtDateHired_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDateHired.TextChanged
        ErrorProvider1.SetError(txtDateHired, "")
    End Sub

    Private Sub txtFname_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtFname.TextChanged
        ErrorProvider1.SetError(txtFname, "")
    End Sub

    Private Sub txtLname_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtLname.TextChanged
        ErrorProvider1.SetError(txtLname, "")
    End Sub

    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub

    Private Sub txtUID_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtUID.TextChanged
        ErrorProvider1.SetError(txtUID, "")
    End Sub

    Private Sub ComboBoxPosition_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxPosition.SelectedIndexChanged
        On Error GoTo er
        ErrorProvider1.SetError(CheckBoxActiveInd, "")
        ErrorProvider1.SetError(ComboBoxPosition, "")

        If TabControl1.TabPages.Contains(EmailPageTab) = True Then
            TabControl1.TabPages.Remove(EmailPageTab)
        End If
        If TabControl1.TabPages.Contains(DoctorsTab) Then
            TabControl1.TabPages.Remove(DoctorsTab)
        End If
        If TabControl1.TabPages.Contains(DoctorsNPITab) Then
            TabControl1.TabPages.Remove(DoctorsNPITab)
        End If
        lblWebAdminUID.Visible = False
        lblWebAdminPWD.Visible = False
        GroupBoxWeb.Visible = False
        If ComboBoxPosition.SelectedIndex = -1 Then Exit Sub

        If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value < 3 Then
            If TabControl1.TabPages.Contains(EmailPageTab) = False Then
                TabControl1.TabPages.Add(EmailPageTab)
            End If
        End If
        If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value1 < 2 Then
            If TabControl1.TabPages.Contains(DoctorsTab) = False Then
                TabControl1.TabPages.Insert(2, DoctorsTab)
            End If
            If TabControl1.TabPages.Contains(DoctorsNPITab) = False Then
                TabControl1.TabPages.Insert(3, DoctorsNPITab)
            End If
            'For Each item As ListViewItem In ListViewOfficess.Items
            '    item.Checked=true
            'Next
        End If
        If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100 Then
            Label12.Visible = True
            ComboBoxTreatingProvider.Visible = True
            GroupBoxWeb.Height = 130
        Else
            Label12.Visible = False
            ComboBoxTreatingProvider.Visible = False
            ComboBoxTreatingProvider.SelectedIndex = -1
            GroupBoxWeb.Height = 75
        End If

        If CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 1 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 2 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 5 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100 Then
            lblWebAdminUID.Visible = True
            lblWebAdminPWD.Visible = True
            GroupBoxWeb.Visible = True
            Produce_WebLogin()
        Else
            lblWebAdminUID.Visible = False
            lblWebAdminPWD.Visible = False
            GroupBoxWeb.Visible = False
        End If
        Exit Sub
er:

    End Sub

    'Private Sub ListView2_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    ErrorProvider1.SetError(ListViewOfficess, "")
    'End Sub

    Private Sub txtDOB_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDOB.TextChanged
        ErrorProvider1.SetError(txtDOB, "")
    End Sub

    Private Sub CheckBoxActiveInd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxActiveInd.Click
        ErrorProvider1.SetError(CheckBoxActiveInd, "")
        ErrorProvider1.SetError(ComboBoxPosition, "")
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBoxSearch.TextChanged
        gSearchListView(ListViewEmployees, TextBoxSearch)
    End Sub

    Private Sub txtLICNumber_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtLICNumber.TextChanged
        ErrorProvider1.SetError(txtLICNumber, "")
    End Sub

    Private Sub ListViewDoctorDiagnostics_ItemChecked(ByVal sender As Object, ByVal e As Windows.Forms.ItemCheckedEventArgs) Handles ListViewDoctorDiagnostics.ItemChecked
        ErrorProvider1.SetError(ListViewDoctorDiagnostics, "")
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPassword.TextChanged
        ErrorProvider1.SetError(txtPassword, "")
    End Sub

    Private Sub CheckBoxBillingPrv_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxBillingPrv.CheckedChanged
        ErrorProvider1.SetError(CheckBoxBillingPrv, "")
        ErrorProvider1.SetError(CheckBoxTreatmentPrv, "")
    End Sub

    Private Sub CheckBoxTreatmentPrv_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxTreatmentPrv.CheckedChanged
        ErrorProvider1.SetError(CheckBoxBillingPrv, "")
        ErrorProvider1.SetError(CheckBoxTreatmentPrv, "")
    End Sub

    Private Sub txtCorporationName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCorporationName.TextChanged
        ErrorProvider1.SetError(txtCorporationName, "")
    End Sub

    Private Sub txtCorporationAddress1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCorporationAddress1.TextChanged
        ErrorProvider1.SetError(txtCorporationAddress1, "")
    End Sub

    Private Sub txtCorporationCity_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCorporationCity.TextChanged
        ErrorProvider1.SetError(txtCorporationCity, "")
    End Sub

    Private Sub ComboBoxCorporationState_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxCorporationState.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxCorporationState, "")
    End Sub

    Private Sub txtCorporationZip_MaskInputRejected(ByVal sender As Object, ByVal e As Windows.Forms.MaskInputRejectedEventArgs) Handles txtCorporationZip.MaskInputRejected

    End Sub

    Private Sub txtCorporationZip_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCorporationZip.TextChanged
        ErrorProvider1.SetError(txtCorporationZip, "")
    End Sub

    Private Sub CheckBoxNoFaulct_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxNoFault.CheckedChanged
        ErrorProvider1.SetError(CheckBoxNoFault, "")
        ErrorProvider1.SetError(CheckBoxPrivate, "")
    End Sub

    Private Sub CheckBoxPrivate_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxPrivate.CheckedChanged
        ErrorProvider1.SetError(CheckBoxNoFault, "")
        ErrorProvider1.SetError(CheckBoxPrivate, "")
        If CheckBoxPrivate.Checked Then
            If TabControl1.TabPages.Contains(DoctorsNPITab) = False Then TabControl1.TabPages.Insert(3, DoctorsNPITab)
            If OpMode <> AddEditMode.None Then Enable_Controls(True)
        Else
            If TabControl1.TabPages.Contains(DoctorsNPITab) Then
                TabControl1.TabPages.Remove(DoctorsNPITab)
            End If
        End If
    End Sub

    Private Sub PictureBoxDoctorSignature_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles PictureBoxDoctorSignature.DoubleClick
        'frmSignaturePad.OutputPictureBox = PictureBoxDoctorSignature
        'frmSignaturePad.ShowDialog()
        'frmSignaturePad.Dispose()
    End Sub

    Private Sub PictureBoxDoctorSignature_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PictureBoxDoctorSignature.Click

    End Sub

    Private Sub cmdSelectPicture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSelectPicture.Click
        PictureBoxDoctorSignature_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub cmdRemovePicture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRemovePicture.Click
        If Not PictureBoxDoctorSignature.Image Is Nothing Then
            If MsgBox("Are you sure you want to remove doctor's signature?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        PictureBoxDoctorSignature.Image = Nothing
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAddNPI.Click
        If OpMode = AddEditMode.Edit Then
            frmAddNPI.ID = CLng(ListViewEmployees.SelectedItems(0).Tag)
        Else
            frmAddNPI.ID = 0
        End If
        frmAddNPI.ShowDialog()
        frmAddNPI.Dispose()
    End Sub

    Private Sub ButtonDeleteNPI_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonDeleteNPI.Click
        Dim LI As ListViewItem
        If ListViewNPI.SelectedItems.Count = 0 Then
            MsgBox("Unable to delete NPI. No NPI record selected.", MsgBoxStyle.Information)
            ListViewNPI.Focus()
            Exit Sub
        End If
        LI = ListViewNPI.SelectedItems(0)
        If MsgBox("Please confirm you want to remove NPI " & LI.Text & " - " & LI.SubItems(1).Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        ListViewNPI.Items.Remove(LI)
    End Sub

    Private Sub ButtonWebAdminRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonWebAdminRefresh.Click
        Produce_WebLogin(2)
    End Sub

    Private Sub cmdSelectPictureFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSelectPictureFile.Click
        Dim strFileName As String
        If Not PictureBoxDoctorSignature.Image Is Nothing Then
            If MsgBox("Please confirm you want to ov erwrite the existing signature?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        'openFD.InitialDirectory = "C:\"
        openFD.Title = "Select Signature File."
        openFD.Filter = "Picture Files (*.jpg;*.gif;*.bmp;*.png)|*.jpg;*.gif;*.bmp;*.png"
        Dim DidWork As Integer = openFD.ShowDialog()
        If DidWork = DialogResult.OK Then
            strFileName = openFD.FileName
            PictureBoxDoctorSignature.Image = Image.FromFile(strFileName)
            openFD.Reset()
        End If
    End Sub

    Private Sub ComboBoxreferralColor_DrawItem(ByVal sender As Object, ByVal e As Windows.Forms.DrawItemEventArgs) Handles ComboBoxreferralColor.DrawItem
        If e.Index < 0 Then
            e.DrawBackground()
            e.DrawFocusRectangle()
            Exit Sub
        End If
        Dim CurrentColor As Color
        CurrentColor = Color.FromArgb(CType(ComboBoxreferralColor.Items(e.Index), ValueDescription).Value)
        Dim SizeRect As Rectangle = New Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height)
        Dim ComboBrush As Brush
        e.DrawBackground()
        e.DrawFocusRectangle()
        e.Graphics.FillRectangle(New SolidBrush(CurrentColor), SizeRect)
        ' change brush color if item is selected
        ComboBrush = Brushes.White
        e.Graphics.DrawString(CType(ComboBoxreferralColor.Items(e.Index), ValueDescription).Description, ComboBoxreferralColor.Font, ComboBrush, e.Bounds.Left, ((e.Bounds.Height - ComboBoxreferralColor.Font.Height) \ 2) + e.Bounds.Top)
    End Sub

    Private Sub ComboBoxreferralColor_MeasureItem(ByVal sender As Object, ByVal e As Windows.Forms.MeasureItemEventArgs) Handles ComboBoxreferralColor.MeasureItem

    End Sub

    Private Sub ComboBoxreferralColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxreferralColor.SelectedIndexChanged
        If ComboBoxreferralColor.SelectedIndex = -1 Then
            ComboBoxreferralColor.BackColor = Color.White
        Else
            ComboBoxreferralColor.BackColor = Color.FromArgb(CType(ComboBoxreferralColor.SelectedItem, ValueDescription).Value)
        End If

    End Sub

    Private Sub TabPage1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub ComboBoxAbbreviation_DropDownStyleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxAbbreviation.DropDownStyleChanged

    End Sub

    Private Sub ComboBoxAbbreviation_KeyUp(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles ComboBoxAbbreviation.KeyUp
        SearchComboBox_KeyUp(ComboBoxAbbreviation, e, False)
    End Sub

    Private Sub ComboBoxAbbreviation_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxAbbreviation.SelectedIndexChanged
        Dim Reader As SqlClient.SqlDataReader

        If ComboBoxAbbreviation.SelectedIndex > 0 Then
            Reader = gSQLGetDataReader("SELECT Description FROM EmployeesDoctorSpecialties WHERE Abbreviation = '" & ComboBoxAbbreviation.Text.ToSafeSQLString() & "'")
            If Reader.HasRows Then
                Reader.Read()
                lblAbbreviationDescription.Text = Reader("Description").ToString
            Else
                lblAbbreviationDescription.Text = ""
            End If
        Else
            lblAbbreviationDescription.Text = ""

        End If
    End Sub

    Private Sub Label19_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label31_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label31.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSelectPicturePCLogo.Click
        Dim strFileName As String
        If Not PictureBoxPCLogo.Image Is Nothing Then
            If MsgBox("Please confirm you want to overwrite the existing PC Logo?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        'openFD.InitialDirectory = "C:\"
        openFD.Title = "Select PC Logo File."
        openFD.Filter = "Picture Files (*.jpg;*.gif;*.bmp;*.png)|*.jpg;*.gif;*.bmp;*.png"
        Dim DidWork As Integer = openFD.ShowDialog()
        If DidWork = DialogResult.OK Then
            strFileName = openFD.FileName
            PictureBoxPCLogo.Image = Image.FromFile(strFileName)
            openFD.Reset()
        End If
    End Sub

    Private Sub PictureBoxPCLogo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PictureBoxPCLogo.Click
    End Sub

    Private Sub cmdRemovePCLogo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRemovePCLogo.Click
        If Not PictureBoxPCLogo.Image Is Nothing Then
            If MsgBox("Are you sure you want to remove the PC Logo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        PictureBoxPCLogo.Image = Nothing
    End Sub

    Private Sub MonthCalendar1_DateChanged(ByVal sender As Object, ByVal e As Windows.Forms.DateRangeEventArgs) Handles MonthCalendarPopUp.DateChanged

    End Sub

    Private Sub MonthCalendarPopUp_DateSelected(ByVal sender As Object, ByVal e As Windows.Forms.DateRangeEventArgs) Handles MonthCalendarPopUp.DateSelected
        ContextMenuPopUpCalendar.SourceControl.Text = MonthCalendarPopUp.SelectionStart.ToString("MM/dd/yyyy")
        ContextMenuPopUpCalendar.Hide()
    End Sub

    Private Sub txtWebAdminUID_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtWebAdminUID.TextChanged
        ErrorProvider1.SetError(txtWebAdminUID, "")
    End Sub

    Private Sub txtWebAdminPWD_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtWebAdminPWD.TextChanged
        ErrorProvider1.SetError(txtWebAdminPWD, "")
    End Sub

    Private Sub txtUID_Validated(sender As Object, e As EventArgs) Handles txtUID.Validated
        If (Not ComboBoxPosition.SelectedItem Is Nothing) Then
            If txtWebAdminUID.Text <> "" And txtWebAdminUID.Text = "" And (CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 1 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 2 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 5 Or CType(ComboBoxPosition.SelectedItem, ValueDescription).Value = 100) Then
                txtWebAdminUID.Text = txtWebAdminUID.Text
            End If
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Produce_Login(2)
    End Sub

    Private Sub ButtonDistribute_Click(sender As Object, e As EventArgs) Handles ButtonDistribute.Click

    End Sub

    Private Sub ButtonDistribute_MouseDown(sender As Object, e As MouseEventArgs) Handles ButtonDistribute.MouseDown
        ContextMenuStripOffices.Show(ButtonDistribute, 0, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Produce_WebLogin(2)
    End Sub

    Private Sub ComboBoxTreatingProvider_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxTreatingProvider.SelectedIndexChanged
        ErrorProvider1.SetError(ComboBoxTreatingProvider, "")
        ErrorProvider1.SetError(ComboBoxTreatingProvider, "")

    End Sub

    Private Sub PictureBoxPassword_Click(sender As Object, e As EventArgs) Handles PictureBoxPassword.Click
        If CLng(ListViewEmployees.SelectedItems(0).Tag) = 1 Then
            MsgBox("Not authorized.", MsgBoxStyle.Exclamation, "Oops")
        Else
            MsgBox(txtPassword.Text)
        End If

    End Sub
End Class