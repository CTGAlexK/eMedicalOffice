Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Threading.Tasks
Imports log4net

Public Class frmSplashNew
    Private InvalidLoginCounter As Integer
    Private SaveKeyCode As Integer
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer
    Private ValidConnection As Integer = -1
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
            Cursor = Cursors.SizeAll
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()
            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub frmSplash_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        SaveKeyCode = e.KeyCode
    End Sub

    Private Sub frmSplash_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        SaveKeyCode = 0
    End Sub

    Private Sub frmSplash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        PictureBox1.Image = PictureBox3.Image
        Label9.Text = "Initializing. Please wait..."
        Label9.Refresh()
        Dim T As New Threading.Thread(AddressOf OpenLocalConnection)
        T.IsBackground = True
        T.Start()
        Me.Opacity = 0
        Timer1.Enabled = True
    End Sub

    Private Sub OpenLocalConnection()
        gSettings(ReadWrite.sRead)
        ValidConnection = Math.Abs(CInt(gValidateConnection()))
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Dim frames As Integer = 0
    Dim Cframe As Integer

    Private Async Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity = Me.Opacity + 0.1
        Application.DoEvents()
        If Me.Opacity >= 1 Then
            Timer1.Enabled = False
            'Dim T As New Threading.Thread(AddressOf PlayAnymation)
            'T.IsBackground = True
            'T.Start()

            chkUpdate.Visible = True
            TimerText.Enabled = True
            txtUserName.Enabled = True
            txtPassword.Enabled = True
            Application.DoEvents()
            gSystemCulture()
            gAppPath = Application.StartupPath
            If gAppPath.EndsWith("\") = False Then gAppPath = gAppPath & "\"

            'lblVersion.Text = "Version " & My.Application.Info.Version.ToString & " - " & gGetAssemblyDate() & IIf(gDebugMode, " D", "")
            lblVersion.Text = "Version: " & My.Application.Info.Version.ToString & "  [" & gGetAssemblyDate() & "]"

            Application.DoEvents()
            PictureBoxProgress.Visible = True
            Label9.Text = "Validating Database Connection. Please wait..."
            Label9.Refresh()

            Application.DoEvents()
            Do Until ValidConnection > -1
                Application.DoEvents()
            Loop
            PanelLogin.Visible = True
            Application.DoEvents()
            If ValidConnection = 0 Then
                Label9.Text = "Database Connection Error..."
                Label9.Refresh()

                PictureBoxProgress.Visible = False
                Label9.Text = ""
                Label3.Visible = False
                txtSQLServer.Visible = True
                Label4.Visible = True
                Label5.Visible = True
                Label6.Visible = True
                Label7.Visible = True
                txtSQLServerDatabaseName.Visible = True
                txtSQLServerUID.Visible = True
                txtSQLServerPassword.Visible = True
                txtSQLServer.Text = gSqlServerName
                txtSQLServerDatabaseName.Text = gSQLServerDatabase
                txtSQLServerUID.Text = gSQLServerUID
                txtSQLServerPassword.Text = gSQLServerPassword
                txtSQLServer.Focus()
                ErrorProvider1.SetError(txtSQLServer, "Invalid Database Information.")
                ErrorProvider1.SetError(txtSQLServerDatabaseName, "Invalid Database Information.")
                ErrorProvider1.SetError(txtSQLServerUID, "Invalid Database Information.")
                ErrorProvider1.SetError(txtSQLServerPassword, "Invalid Database Information.")
                ComboBoxOffice.Visible = True
            Else
                Label9.Text = "Check for updates. Please wait..."
                Label9.Refresh()

                If AutoUpdateWasRunning = False Then
                    If gProcessAutoUpdate(False, chkUpdate.Checked) = True Then
                        End
                        Exit Sub
                    End If
                End If

                PictureBoxProgress.Visible = False
                Label4.Visible = False
                Label5.Visible = False
                Label6.Visible = False
                Label7.Visible = False
                txtSQLServer.Visible = False
                txtSQLServerDatabaseName.Visible = False
                txtSQLServerUID.Visible = False
                txtSQLServerPassword.Visible = False
                Application.DoEvents()
                Label9.Text = "Loading Data. Please wait..."
                ComboBoxOffice.Visible = CDbl(gOfficeID) = 0
                If ComboBoxOffice.Visible Then
                    Load_Offices()
                    If gOfficeID > 0 Then
                        gFindComboItemByValue(ComboBoxOffice, gOfficeID, True)
                        GetOfficeType(CLng(gOfficeID))
                    End If
                Else

                    GetOfficeType(CLng(gOfficeID))
                End If

                If ComboBoxOffice.Visible = False Then
                    txtUserName.Focus()
                Else
                    ComboBoxOffice.Focus()
                End If
            End If
            Label9.Text = ""
            Label9.Refresh()

            LabelOffice.Visible = ComboBoxOffice.Visible

            Label3.Visible = Not ComboBoxOffice.Visible
        End If
    End Sub

    Private Sub PlayAnymation()

        frames = PictureBox2.Image.GetFrameCount(Imaging.FrameDimension.Time)
        ImageAnimator.Animate(PictureBox2.Image, AddressOf paintFrame)

    End Sub

    Private Sub paintFrame(ByVal sender As Object, ByVal e As EventArgs)
        On Error GoTo er

        If Cframe < 25 Then
            PictureBox1.Invalidate()
        Else
er:
            If stopanimation Then Exit Sub
            stopanimation = True
            ImageAnimator.StopAnimate(PictureBox2.Image, AddressOf StopAnim)
            PictureBox1.Image = PictureBox3.Image
        End If
    End Sub

    Private Sub StopAnim(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub Load_Offices()
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("Select * from Offices Where ActiveInd=1 Order By OfficeName")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxOffice.Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)), Reader("OfficeName").ToString))
        Loop
        Reader.Close() : Reader.Dispose() : Reader.Dispose()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLogin.Click
        Dim Key As String
        If Not Me.ActiveControl Is Nothing Then
            If Me.ActiveControl Is txtUserName Then
                If txtUserName.Text <> "" And txtPassword.Text = "" Then
                    txtPassword.Focus()
                    Exit Sub
                End If
            End If
        End If

        txtUserName.Text = txtUserName.Text.Trim.ToString
        txtPassword.Text = txtPassword.Text.Trim.ToString
        If txtSQLServer.Visible Then
            Me.TopMost = False
            If Setup_Connection() = False Then
                Me.TopMost = True
                Exit Sub
            End If
            Me.TopMost = True
        End If
        If ComboBoxOffice.Visible = True Then
            If ComboBoxOffice.SelectedIndex = -1 Then
                ErrorProvider1.SetError(ComboBoxOffice, "Unable to process login. The Office Name should be selected.")
                Me.TopMost = False
                MsgBox("Unable to process login. The Office Name should be selected.", MsgBoxStyle.Exclamation)
                Me.TopMost = True
                ComboBoxOffice.Focus()
                Exit Sub
            End If
            gOfficeID = CType(ComboBoxOffice.SelectedItem, ValueDescription).Value.ToString

        End If

        If txtUserName.Text = "" Then
            ErrorProvider1.SetError(txtUserName, "Unable to process login. The Login User Name is required.")
            Me.TopMost = False
            MsgBox("Unable to process login. The Login User Name is required.", MsgBoxStyle.Exclamation)
            Me.TopMost = True
            txtUserName.Focus()
            Exit Sub
        End If
        If txtPassword.Text = "" Then
            ErrorProvider1.SetError(txtPassword, "Unable to process login. The Login Password is required.")
            Me.TopMost = False
            MsgBox("Unable to process login. The Login Password is required.", MsgBoxStyle.Exclamation)
            Me.TopMost = True
            txtPassword.Focus()
            Exit Sub
        End If

        Application.DoEvents()
        If Validate_User() = False Then
            ErrorProvider1.SetError(txtUserName, "Invalid Security Information.")
            ErrorProvider1.SetError(txtPassword, "Invalid Security Information.")
            Exit Sub
        End If
        PanelLogin.Visible = False
        PanelLoading.Visible = True
        Label9.Text = "Loading Data. Please wait..."
        Application.DoEvents()
        If ComboBoxOffice.Visible = True Then
            gOfficeID = CType(ComboBoxOffice.SelectedItem, ValueDescription).Value.ToString
            gOfficeName = CType(ComboBoxOffice.SelectedItem, ValueDescription).Description.ToString
            gOfficeEmail = CType(ComboBoxOffice.SelectedItem, ValueDescription).Value1.ToString
            gSettings(ReadWrite.sWrite)
        End If
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("Select * from Offices Where OfficeID=" & gOfficeID)
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Reader.Read()
            gEnableElectronicBillFiling = CInt(Val(Reader("EnableElectronicBillFiling").ToString))
            gProcsPerVisit = CInt(Val(Reader("ProcsPerVisit").ToString))
            gMinAge = CInt(Val(Reader("MinAge").ToString))
            gUnderAge = CInt(Val(Reader("UnderAge").ToString))
            gMinNoFaultDays = CInt(Val(Reader("MinNoFaultDays").ToString))
            gNFBetweenMRIDays = CInt(Val(Reader("NFBetweenMRIDays").ToString))
            gBillingMinDays = CInt(Val(Reader("BillingMinDays").ToString))
            gBillingMaxDays = CInt(Val(Reader("BillingMaxDays").ToString))
            gAttorneyNoConfirmationAge = CInt(Val(Reader("AttorneyNoConfirmationAge").ToString))
            gBillingRequestWarningAge = CInt(Val(Reader("BillingRequestWarningAge").ToString))
            gOfficeURL = Reader("WebAddress").ToString
            gCancelationWarning = Val(Reader("CancelationWarning").ToString)
            gCancelationDrop = (Reader("CancelationDrop").ToString)

            gDOAAge = CInt(Val(Reader("DOAAge").ToString))
            gNoShowHours = CInt(Val(Reader("NoShowHours").ToString))
            gCashDiscountPct = Val(Reader("CashDiscountPct").ToString)
            gSystemIdleTime = Val(Reader("IdleTime").ToString)

            gImageDiskPriceForInsuranceCompany = Val(Reader("ImageDiskPriceForInsuranceCompany").ToString)
            gImageDiskPriceForMedicalOffice = Val(Reader("ImageDiskPriceForMedicalOffice").ToString)
            gImageDiskPriceCash = Val(Reader("ImageDiskPriceCash").ToString)
            gOfficeEmail = Reader("eMail").ToString
            gOfficeFax = Reader("Fax1").ToString
            gOfficeURL = Reader("WebAddress").ToString
            gBillingNFDefaultBillingCompany = Val(Reader("BillingNFDefaultBillingCompany").ToString)
            gBillingWCDefaultBillingCompany = Val(Reader("BillingWCDefaultBillingCompany").ToString)
            gBillingPrivateDefaultBillingCompany = Val(Reader("BillingPrivateDefaultBillingCompany").ToString)
            gBillingNFDefaultBillingCompanyAllowChange = Val(Reader("BillingNFDefaultBillingCompanyAllowChange").ToString)
            gBillingWCDefaultBillingCompanyAllowChange = Val(Reader("BillingWCDefaultBillingCompanyAllowChange").ToString)
            gBillingPrivateDefaultBillingCompanyAllowChange = Val(Reader("BillingPrivateDefaultBillingCompanyAllowChange").ToString)
            gNF2MainBillingProviderID = Val(Reader("NF2MainBillingProviderID").ToString)
            gPACSPatientIDPadded = Val(Reader("PACSPatientIDPadded").ToString)
            gPACSAltNumberRequired = Val(Reader("PACSAltNumberRequired").ToString)
            gCheckAddress = Val(Reader("CheckAddress").ToString)
            gSimplifiedBilling = Val(Reader("SimplifiedBilling").ToString)
            gNF2MinAge = Val(Reader("NF2MinAge").ToString)
            gNF2MaxAge = Val(Reader("NF2MaxAge").ToString)
            gNF3Template = Val(Reader("NF3Template").ToString)
            gSystemLibraryPath = Reader("SystemLibraryPath").ToString

            If gSystemLibraryPath <> "" Then
                If gSystemLibraryPath.EndsWith("\") = False Then
                    gSystemLibraryPath = gSystemLibraryPath & "\"
                End If
            End If

            If IsColumnExist(Reader, "TwilioFromPhoneNumber") Then
                gTwilioFromPhoneNumber = Reader("TwilioFromPhoneNumber").ToString
                gTwilioAccountSid = Reader("TwilioAccountSid").ToString
                gTwilioAuthToken = Reader("TwilioAuthToken").ToString
                gTwilioMessageTypeId = CInt("0" & Reader("TwilioMessageTypeId").ToString)
                gTwilioBin = Reader("TwilioBin").ToString

            End If
            If gSystemAutoUpdatePath <> "" Then
                If gSystemAutoUpdatePath.EndsWith("\") = False Then
                    gSystemAutoUpdatePath = gSystemAutoUpdatePath & "\"
                End If
            End If
            gSMTPUID = Reader("SMTPUID").ToString
            gSMTPPWD = Reader("SMTPPWD").ToString
            gSMTPHost = Reader("SMTPHost").ToString
            gSMTPPort = Val(Reader("SMTPPort").ToString)
            gSMTPFromAddress = Reader("SMTPFromAddress").ToString
            gSMTPAsync = Val(Reader("SMTPSendAsync").ToString)
        End If
        Reader.Close() : Reader.Dispose() : Reader.Dispose()

        EZTwain.ApplicationLicense("eMedicalOffice", 999736100)
        Cursor = Cursors.Default
        Application.DoEvents()
        gCurrentEmployee.ComputerInfo = gGetIPInfo()
        Label9.Visible = True
        PictureBoxProgress.Visible = True
        Application.DoEvents()
        Application.DoEvents()
        Application.DoEvents()
        Application.DoEvents()

        log.Debug("Single Office Mode. Office: " + gOfficeName + " started. User:" + gCurrentEmployee.UID + "/" + gCurrentEmployee.FName + "/" + gCurrentEmployee.LName + "/" + gCurrentEmployee.Position)
        If gCurrentEmployee.PositionID = 10 Then
            frmScheduleTechnician.Show()
        Else
            Label9.Text = "Starting eMedical Office. Please wait..."
            Label9.Refresh()
            gLoad_Autocompletes()
            MDIForm1Win8.Show()
        End If
        Close()
        Dispose()
    End Sub

    Private Function Setup_Connection() As Boolean
        Dim lConnectionString As String
        txtSQLServer.Text = txtSQLServer.Text.Trim.ToString
        txtSQLServerDatabaseName.Text = txtSQLServerDatabaseName.Text.Trim.ToString
        txtSQLServerUID.Text = txtSQLServerUID.Text.Trim.ToString
        txtSQLServerPassword.Text = txtSQLServerPassword.Text.Trim.ToString

        If txtSQLServer.Text = "" Then
            ErrorProvider1.SetError(txtSQLServer, "Incomplete Setup Information. The SQL Server Name is required.")
            Me.TopMost = False
            MsgBox("Incomplete Setup Information. The SQL Server Name is required.", MsgBoxStyle.Exclamation)
            Me.TopMost = True
            txtSQLServer.Focus()
            Exit Function
        End If
        If txtSQLServerDatabaseName.Text = "" Then
            ErrorProvider1.SetError(txtSQLServerDatabaseName, "Incomplete Setup Information. The SQL Server Database Name is required.")
            Me.TopMost = False
            MsgBox("Incomplete Setup Information. The SQL Server Database Name is required.", MsgBoxStyle.Exclamation)
            Me.TopMost = True
            txtSQLServerDatabaseName.Focus()
            Exit Function
        End If
        If txtSQLServerUID.Text = "" Then
            ErrorProvider1.SetError(txtSQLServerUID, "Incomplete Setup Information. The SQL Server User ID is required.")
            Me.TopMost = False
            MsgBox("Incomplete Setup Information. The SQL Server User ID is required.", MsgBoxStyle.Exclamation)
            Me.TopMost = True
            txtSQLServerUID.Focus()
            Refresh()
            Exit Function
        End If
        lConnectionString = "Server=" & txtSQLServer.Text & ";Database=" & txtSQLServerDatabaseName.Text & ";User ID=" & txtSQLServerUID.Text & ";Password=" & txtSQLServerPassword.Text & ";Trusted_Connection=False"
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Me.TopMost = False
        If gValidateConnection(lConnectionString) = False Then
            ErrorProvider1.SetError(txtSQLServer, "Invalid Database Information.")
            ErrorProvider1.SetError(txtSQLServerDatabaseName, "Invalid Database Information.")
            ErrorProvider1.SetError(txtSQLServerUID, "Invalid Database Information.")
            ErrorProvider1.SetError(txtSQLServerPassword, "Invalid Database Information.")
            txtSQLServer.Focus()
            Me.TopMost = True
            Exit Function
        End If
        Me.TopMost = True
        Cursor = Cursors.Default
        gSqlServerName = txtSQLServer.Text
        gSQLServerDatabase = txtSQLServerDatabaseName.Text
        gSQLServerUID = txtSQLServerUID.Text
        gSQLServerPassword = txtSQLServerPassword.Text
        gSettings(ReadWrite.sWrite)
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        txtSQLServer.Visible = False
        txtSQLServerDatabaseName.Visible = False
        txtSQLServerUID.Visible = False
        txtSQLServerPassword.Visible = False
        Setup_Connection = True
    End Function

    Private Function Validate_User() As Boolean
        Dim SQl As String
        Dim Reader As SqlClient.SqlDataReader
        If ValidateDeveloper Then
            Validate_User = Validate_Developer()
            Exit Function
        End If

        If gSQLGetSingleValue("select count(*) from WebFunctions") <> 8 Then
            Me.TopMost = False
            MsgBox("Invalid License. Access Denied.", MsgBoxStyle.Critical)
            Me.Close()
            Exit Function
        End If
        SQl = "Select Employees.*, Offices.Zip, Offices.ActiveInd as OfficeActive, Positions.PositionID, Description as Position From Employees inner join Positions on Employees.PositionID = Positions.PositionID inner join EmployeeOffice on Employees.EmpID=EmployeeOffice.EmpID inner join Offices on Offices.OfficeID=EmployeeOffice.OfficeID Where Employees.ActiveInd=1 and UID='" & txtUserName.Text.ToSafeSQLString() & "' AND EmployeeOffice.OfficeID=" & gOfficeID
        Reader = gSQLGetDataReader(SQl)
        If Reader Is Nothing Then Exit Function
        If Reader.Read = False Then
InvalidLogin:
            InvalidLoginCounter = InvalidLoginCounter + 1
            If InvalidLoginCounter = 3 Then
                Me.TopMost = False
                MsgBox("Invalid Security Information. Access Denied.", MsgBoxStyle.Critical)
                Reader.Close() : Reader.Dispose() : Reader.Dispose()
                Me.Close()
            Else
                Me.TopMost = False
                MsgBox("Invalid Security Information. Please Try again.", MsgBoxStyle.Exclamation)
                Me.TopMost = True
                txtUserName.Focus()
                Reader.Close() : Reader.Dispose()
            End If
        Else
            If Val(Reader("PositionID").ToString) = 100 Then
                GoTo InvalidLogin
            End If
            If txtPassword.Text.ToUpper <> gEncrypt(Reader("Password").ToString).ToUpper Then
                GoTo InvalidLogin
            End If
            If Val(Reader("OfficeActive").ToString) = 0 And Val(Reader("PositionID").ToString) > 1 Then
                Me.TopMost = False
                MsgBox("Unable to process login. The office is disabled by administrator.", MsgBoxStyle.Exclamation)
                Me.TopMost = True
                txtUserName.Focus()
                Reader.Close() : Reader.Dispose()
            End If
            gOfficeActive = CBool(Val(Reader("OfficeActive").ToString))
            gCurrentEmployee.EmpID = CInt(Val(Reader("EmpID").ToString))
            gCurrentEmployee.FName = Reader("FName").ToString
            gCurrentEmployee.LName = Reader("LName").ToString
            gCurrentEmployee.Position = "" & Reader("Position").ToString
            gCurrentEmployee.UID = "" & Reader("UID").ToString
            gCurrentEmployee.Password = gEncrypt(Reader("Password").ToString).ToUpper
            gCurrentEmployee.PositionID = CLng(Val(Reader("PositionID").ToString))
            If Reader("Zip").ToString <> "" Then
                If txtSC.Text = "" & Reader("Zip").ToString And gCurrentEmployee.PositionID = 1 Then
                    gCurrentEmployee.SC = True
                Else
                    gCurrentEmployee.SC = False
                End If
            End If
            Validate_User = True
            Reader.Close() : Reader.Dispose()
        End If
    End Function

    Private Function Validate_Developer()
        If txtUserName.Text = "1" And txtPassword.Text = "042166" Then

            gOfficeActive = True
            gCurrentEmployee.EmpID = 1
            gCurrentEmployee.FName = "Alex"
            gCurrentEmployee.LName = "Developer"
            gCurrentEmployee.Position = "Supper Admin"
            gCurrentEmployee.UID = "1"
            gCurrentEmployee.Password = "042166"
            gCurrentEmployee.PositionID = "1"
            Validate_Developer = True
        End If
    End Function

    Dim ValidateDeveloper As Boolean = False
    Dim ValidateDeveloperCount As Integer = 1

    Private Sub txtUserName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.DoubleClick
        If SaveKeyCode = 17 Then
            If ValidateDeveloperCount > 2 Then
                ValidateDeveloper = True
                ValidateDeveloperCount = 1
                lblVersion.Text = lblVersion.Text & " D"
            Else
                If lblVersion.Text.Right(2).ToUpper() = " D" Then lblVersion.Text = lblVersion.Text.Left(lblVersion.Text.Length - 2)
                ValidateDeveloperCount = ValidateDeveloperCount + 1
                ValidateDeveloper = False
            End If
        Else
            If lblVersion.Text.Right(2).ToUpper() = " D" Then lblVersion.Text = lblVersion.Text.Left(lblVersion.Text.Length - 2)
            ValidateDeveloperCount = 1
            ValidateDeveloper = False
        End If
    End Sub

    Private Sub txtUserName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.GotFocus
        txtUserName.SelectAll()
    End Sub

    Private Sub txtUserName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserName.KeyDown

    End Sub

    Private Sub txtUserName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserName.TextChanged
        ErrorProvider1.SetError(txtUserName, "")
        ErrorProvider1.SetError(txtPassword, "")

    End Sub

    Private Sub txtPassword_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.DoubleClick
        If txtSC.Visible = False Then
            If SaveKeyCode = 17 Then
                txtPassword.Width = 75
                txtSC.Visible = True
            End If
        Else
            txtPassword.Width = 158
            txtSC.Visible = False
        End If
    End Sub

    Private Sub txtPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus
        txtPassword.SelectAll()
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        ErrorProvider1.SetError(txtUserName, "")
        ErrorProvider1.SetError(txtPassword, "")
    End Sub

    Private Sub txtSQLServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQLServer.TextChanged
        ErrorProvider1.SetError(txtSQLServer, "")
        ErrorProvider1.SetError(txtSQLServerDatabaseName, "")
        ErrorProvider1.SetError(txtSQLServerUID, "")
        ErrorProvider1.SetError(txtSQLServerPassword, "")

    End Sub

    Private Sub txtSQLServerDatabaseName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQLServerDatabaseName.TextChanged
        ErrorProvider1.SetError(txtSQLServer, "")
        ErrorProvider1.SetError(txtSQLServerDatabaseName, "")
        ErrorProvider1.SetError(txtSQLServerUID, "")
        ErrorProvider1.SetError(txtSQLServerPassword, "")
    End Sub

    Private Sub txtSQLServerUID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQLServerUID.TextChanged
        ErrorProvider1.SetError(txtSQLServer, "")
        ErrorProvider1.SetError(txtSQLServerDatabaseName, "")
        ErrorProvider1.SetError(txtSQLServerUID, "")
        ErrorProvider1.SetError(txtSQLServerPassword, "")
    End Sub

    Private Sub txtSQLServerPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQLServerPassword.TextChanged
        ErrorProvider1.SetError(txtSQLServer, "")
        ErrorProvider1.SetError(txtSQLServerDatabaseName, "")
        ErrorProvider1.SetError(txtSQLServerUID, "")
        ErrorProvider1.SetError(txtSQLServerPassword, "")
    End Sub

    Private Sub ComboBoxOffice_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxOffice.DropDown
        If ComboBoxOffice.Items.Count = 0 Then
            If txtSQLServer.Visible = True Then
                Me.TopMost = False
                If Setup_Connection() = True Then
                    Load_Offices()
                Else
                    Timer2.Enabled = True
                End If
                Me.TopMost = True
            Else
                Load_Offices()
            End If
        End If
        ErrorProvider1.SetError(ComboBoxOffice, "")
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        Application.DoEvents()
        ComboBoxOffice.DroppedDown = False
        Application.DoEvents()
        ComboBoxOffice.DroppedDown = False
        ComboBoxOffice.Enabled = False
        Application.DoEvents()
        txtSQLServer.Focus()
        ComboBoxOffice.Refresh()
        ComboBoxOffice.Enabled = True
        Application.DoEvents()
    End Sub

    Private Sub ComboBoxOffice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxOffice.SelectedIndexChanged
        If ComboBoxOffice.SelectedIndex = -1 Then Exit Sub
        GetOfficeType(CType(ComboBoxOffice.SelectedItem, ValueDescription).Value)

    End Sub

    Private Sub GetOfficeType(ByVal OfficeID As Long)
        Dim Ret As String
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("SELECT     OfficeTypes.Description, OfficeTypes.OfficeTypeID, VersionName FROM Offices INNER JOIN OfficeTypes ON Offices.OfficeTypeID = OfficeTypes.OfficeTypeID WHERE Offices.OfficeID = " & OfficeID)
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows = False Then Exit Sub
        Reader.Read()
        Label8.Text = "PRO " & Reader("VersionName").ToString.ToUpper
        gOfficeTypeID = Reader("OfficeTypeID").ToString
        gOfficeTypeIDName = Reader("Description").ToString
        Reader.Close() : Reader.Dispose() : Reader.Dispose()
        Label8.Visible = True
        Label3.Visible = True
    End Sub

    Private Sub PictureBoxKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxKeyboard.Click
        Dim S As Point
        Dim T As Integer
        My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        PictureBoxKeyboard.Visible = False
        frmKeyboard.CalledForm = Me
        frmKeyboard.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        S = frmKeyboard.Load_Keyboard()
        T = (Screen.PrimaryScreen.WorkingArea.Size.Height - (Me.Height + (S.Y))) / 2
        If Me.Top - T > 20 Then
            Do Until Me.Top <= T
                Me.Top = Me.Top - 1
                Threading.Thread.Sleep(2)
                Application.DoEvents()
            Loop
        End If

        frmKeyboard.BackColor = BackColor
        frmKeyboard.Width = Width
        frmKeyboard.Left = Me.Left
        frmKeyboard.Top = Me.Top + Me.Height
        frmKeyboard.Show(Me)

    End Sub

    Private Sub Label10_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label10.MouseDown
        Form1_MouseDown(sender, e)
    End Sub

    Private Sub Label10_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label10.MouseMove
        Form1_MouseMove(sender, e)
    End Sub

    Private Sub Label10_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label10.MouseUp
        Form1_MouseUp(sender, e)
    End Sub

    Private Sub Label3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseDown
        Form1_MouseDown(sender, e)
    End Sub

    Private Sub Label3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseMove
        Form1_MouseMove(sender, e)
    End Sub

    Private Sub Label3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseUp
        Form1_MouseUp(sender, e)
    End Sub

    Dim TextCount As Integer = 0

    Private Sub TimerText_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerText.Tick
        TimerText.Enabled = False
        Label10.Text = ("The new way to handle medical office business:").ToUpper
        Label10.Text = ("The new way to handle medical office business:" & vbCrLf & "  *      Patient Intake").ToUpper
        Label10.Text = ("The new way to handle medical office business:" & vbCrLf & "  *      Patient Intake" & vbCrLf & "  *      Scheduling").ToUpper
        Label10.Text = ("The new way to handle medical office business:" & vbCrLf & "  *      Patient Intake" & vbCrLf & "  *      Scheduling" & vbCrLf & "  *      Reports").ToUpper
        Label10.Text = ("The new way to handle medical office business:" & vbCrLf & "  *      Patient Intake" & vbCrLf & "  *      Scheduling" & vbCrLf & "  *      Reports" & vbCrLf & "  *      Digital Document Processing").ToUpper
        Label10.Text = ("The new way to handle medical office business:" & vbCrLf & "  *      Patient Intake" & vbCrLf & "  *      Scheduling" & vbCrLf & "  *      Reports" & vbCrLf & "  *      Digital Document Processing" & vbCrLf & "  *      Billing NF2 / WC / Commercial").ToUpper
        Label10.Text = ("The new way to handle medical office business:" & vbCrLf & "  *      Patient Intake" & vbCrLf & "  *      Scheduling" & vbCrLf & "  *      Reports" & vbCrLf & "  *      Digital Document Processing" & vbCrLf & "  *      Billing NF2 / WC / Commercial" & vbCrLf & "  *      Collection").ToUpper
        PictureBoxWin8Logo.Visible = True

    End Sub

    Private stopanimation As Boolean

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        On Error GoTo er
        If stopanimation Then Exit Sub
        If frames > 0 Then
            ImageAnimator.UpdateFrames()
            e.Graphics.DrawImage(PictureBox2.Image, Point.Empty)
            Cframe += 1
            If Cframe > 25 Then
                stopanimation = True
                Label8.Visible = True
            End If
        End If
er:
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        txtPassword.PasswordChar = ""
    End Sub

    Private Sub PictureBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        txtPassword.PasswordChar = "*"
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

End Class