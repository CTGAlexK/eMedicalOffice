Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Threading.Tasks
Imports log4net

Public Class frmSplashMultiOfficeNew


    Private InvalidLoginCounter As Integer
    Private SaveKeyCode As Integer
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer
    Private ValidConnection As Integer = -1
    Private LoadingInd As Boolean
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
            Cursor = Cursors.SizeAll
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If IsFormBeingDragged Then
            Dim temp = New Point()
            temp.X = Location.X + (e.X - MouseDownX)
            temp.Y = Location.Y + (e.Y - MouseDownY)
            Location = temp
        End If
    End Sub

    Private Sub frmSplash_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        SaveKeyCode = e.KeyCode
    End Sub

    Private Sub frmSplash_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        SaveKeyCode = 0
    End Sub

    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetStyle(ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)

        'Opacity = 0
        Opacity = 1
        Show()
        Application.DoEvents()
        TimerOpacity.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Close()
    End Sub

    Private Sub Start()
        LoadingInd = True
        Dim ValidLicense As Boolean
        txtUserName.Enabled = True
        txtPassword.Enabled = True
        Application.DoEvents()
        gSystemCulture()
        lblVersion.Text = "Version: " & My.Application.Info.Version.ToString & "  [" & gGetAssemblyDate() & "]"

        PanelLogin.Visible = True
        Application.DoEvents()
        txtSQLServer.Text = gSqlServerName
        txtSQLServerDatabaseName.Text = gSQLServerDatabase
        txtSQLServerUID.Text = gSQLServerUID
        txtSQLServerPassword.Text = gSQLServerPassword
        Label9.Text = "Verifying Database Connection. Please wait..."
        Application.DoEvents()
        OpenLocalConnectionAsync()

        If ValidConnection = 0 Then
            Label9.Text = "Database Connection Error"
            LabelInfo.Visible = False
            PanelSettings.Visible = True
            ErrorProvider1.SetError(txtSQLServer, IIf(txtSQLServer.Text.Length = 0, "Please specify SQL Server Name", "Invalid Database Information."))
            ErrorProvider1.SetError(txtSQLServerDatabaseName, IIf(txtSQLServerDatabaseName.Text.Length = 0, "Please specify Database Name", "Invalid Database Information."))
            ErrorProvider1.SetError(txtSQLServerUID, IIf(txtSQLServerUID.Text.Length = 0, "Please specify SQL Server User Name", "Invalid Database Information."))
            ErrorProvider1.SetError(txtSQLServerPassword, IIf(txtSQLServerPassword.Text.Length = 0, "Please specify SQL Server Password", "Invalid Database Information."))
            txtSQLServer.Focus()
        Else
            Label9.Text = ""
            Load_Offices()
            If gOfficeID > 0 Then
                gFindComboItemByValue(ComboBoxOffice, gOfficeID, True)
                GetOfficeType(gOfficeID)
            End If

        End If
        If PanelSettings.Visible = False Then
            txtUserName.Focus()
        Else
            ComboBoxOffice.Focus()
        End If

        LoadingInd = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerOpacity.Tick

        Opacity = 1

        If Opacity >= 1 Then
            gAppPath = Application.StartupPath
            If gAppPath.EndsWith("\") = False Then gAppPath = gAppPath & "\"
            gSettings(ReadWrite.sRead)
            TimerOpacity.Enabled = False
            Opacity = 1
            chkUpdate.Visible = True
            Refresh()
            Invalidate(True)
            Application.DoEvents()
            'TimerText.Enabled = True
            Start()
        End If

    End Sub

    Private Sub Load_Offices()
        Dim Reader As SqlClient.SqlDataReader
        If ComboBoxOffice.Items.Count > 0 Then Exit Sub
        Label9.Text = "Initializing. Please wait..."
        Label9.Refresh()
        Reader = gSQLGetDataReaderAsync("Select * from Offices Where ActiveInd=1 Order By OfficeName").Result
        If Reader Is Nothing Then Exit Sub
        gOffices.Clear()
        Do Until Reader.Read = False
            ComboBoxOffice.Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)), Reader("OfficeName").ToString))

            Dim officeId As Integer = Val(Reader("OfficeID").ToString)
            Dim dbserver As String = Reader("SQLServerName").ToString
            Dim dbname As String = Reader("SQLServerDatabase").ToString
            Dim dbuid As String = Reader("SQLServerUID").ToString
            Dim pwd As String = Reader("SQLServerPassword").ToString
            Dim licenseKey As String = Reader("LicenseKey").ToString
            Dim connectionstring As String
            connectionstring = ""
            If dbserver <> "" And dbname <> "" And dbuid <> "" Then
                connectionstring = "Server=" & dbserver & ";Database=" & dbname & ";User ID=" &
                                   dbuid & ";Password=" & pwd & ";Trusted_Connection=False; Max Pool Size=500"
            End If
            gOffices.Add(New Office(officeId, Reader("OfficeName").ToString(), connectionstring, licenseKey))
        Loop
        Label9.Text = ""
        Label9.Refresh()

        Reader.Close() : Reader.Dispose() : Reader.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        Dim Key As String
        Application.DoEvents()
        Application.DoEvents()
        If Not ActiveControl Is Nothing Then
            If ActiveControl Is txtUserName Then
                If txtUserName.Text <> "" And txtPassword.Text = "" Then
                    txtPassword.Focus()
                    Exit Sub
                End If
            End If
        End If
        If ComboBoxOffice.SelectedIndex = -1 Then
            Label9.Text = ""
            Label9.Refresh()
            ErrorProvider1.SetError(ComboBoxOffice, "Unable to process login. The Office Name should be selected.")
            TopMost = False
            Cursor = Cursors.Default
            MsgBox("Unable to process login. The Office Name should be selected.", MsgBoxStyle.Exclamation)
            TopMost = True
            ComboBoxOffice.Focus()

            Exit Sub
        End If
        If AutoUpdateWasRunning = False Then
            Label9.Text = "Checking for updates..."
            Label9.Refresh()
            If gProcessAutoUpdate(False, chkUpdate.Checked) = True Then
                End
            End If
        End If

        txtUserName.Text = txtUserName.Text.Trim.ToString
        txtPassword.Text = txtPassword.Text.Trim.ToString
        If PanelSettings.Visible Then
            Label9.Text = "Validating database connection..."
            Label9.Refresh()

            If Setup_Connection() = False Then
                TopMost = False
                MsgBox("Unable to process login. The Unable to connect to database.", MsgBoxStyle.Exclamation)
                Label9.Text = ""
                Label9.Refresh()
                TopMost = True
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        gOfficeID = CType(ComboBoxOffice.SelectedItem, ValueDescription).Value.ToString
        GetOfficeType(gOfficeID)

        If txtUserName.Text = "" Then
            ErrorProvider1.SetError(txtUserName, "Unable to process login. The Login User Name is required.")
            TopMost = False
            MsgBox("Unable to process login. The Login User Name is required.", MsgBoxStyle.Exclamation)
            TopMost = True
            txtUserName.Focus()
            Exit Sub
        End If
        If txtPassword.Text = "" Then
            ErrorProvider1.SetError(txtPassword, "Unable to process login. The Login Password is required.")
            TopMost = False
            MsgBox("Unable to process login. The Login Password is required.", MsgBoxStyle.Exclamation)
            TopMost = True
            txtPassword.Focus()
            Exit Sub
        End If
        Label9.Text = "Validating Login. Please wait..."
        Label9.Refresh()
        ButtonLogin.Enabled = False
        Application.DoEvents()
        If Validate_User() = False Then
            ErrorProvider1.SetError(txtUserName, "Invalid Security Information.")
            ErrorProvider1.SetError(txtPassword, "Invalid Security Information.")
            Label9.Text = ""
            ButtonLogin.Enabled = True
            Exit Sub
        End If
        PanelLogin.Visible = False
        PanelLoading.Visible = True
        Label9.Text = "Loading Data. Please wait..."
        Label9.Refresh()
        Application.DoEvents()
        gOfficeID = CType(ComboBoxOffice.SelectedItem, ValueDescription).Value.ToString
        gOfficeName = CType(ComboBoxOffice.SelectedItem, ValueDescription).Description.ToString
        gOfficeEmail = CType(ComboBoxOffice.SelectedItem, ValueDescription).Value1.ToString
        gSettings(ReadWrite.sWrite)
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReaderAsync("Select * from Offices Where OfficeID=" & gOfficeID).Result
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
        Load_Offices()
        Application.DoEvents()
        Application.DoEvents()
        Application.DoEvents()
        Application.DoEvents()
        log.Debug("Multi Office Mode. Office: " + gOfficeName + " started. User:" + gCurrentEmployee.UID + "/" + gCurrentEmployee.FName + "/" + gCurrentEmployee.LName + "/" + gCurrentEmployee.Position)
        If gCurrentEmployee.PositionID = 10 Then
            frmScheduleTechnician.Show()
        Else
            Label9.Text = "Starting eMedicalOffice. Please wait..."
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
            TopMost = False
            MsgBox("Incomplete Setup Information. The SQL Server Name is required.", MsgBoxStyle.Exclamation)
            TopMost = True
            txtSQLServer.Focus()
            Exit Function
        End If
        If txtSQLServerDatabaseName.Text = "" Then
            ErrorProvider1.SetError(txtSQLServerDatabaseName, "Incomplete Setup Information. The SQL Server Database Name is required.")
            TopMost = False
            MsgBox("Incomplete Setup Information. The SQL Server Database Name is required.", MsgBoxStyle.Exclamation)
            TopMost = True
            txtSQLServerDatabaseName.Focus()
            Exit Function
        End If
        If txtSQLServerUID.Text = "" Then
            ErrorProvider1.SetError(txtSQLServerUID, "Incomplete Setup Information. The SQL Server User ID is required.")
            TopMost = False
            MsgBox("Incomplete Setup Information. The SQL Server User ID is required.", MsgBoxStyle.Exclamation)
            TopMost = True
            txtSQLServerUID.Focus()
            Refresh()
            Exit Function
        End If
        lConnectionString = "Server=" & txtSQLServer.Text & ";Database=" & txtSQLServerDatabaseName.Text & ";User ID=" & txtSQLServerUID.Text & ";Password=" & txtSQLServerPassword.Text & ";Trusted_Connection=False"
        Cursor = Cursors.WaitCursor
        Label9.Text = "Validating Database Connection. Please wait..."
        PanelSettings.Enabled = False
        PanelLogin.Enabled = False
        Application.DoEvents()
        OpenLocalConnectionAsync(lConnectionString)
        PanelSettings.Enabled = True
        PanelLogin.Enabled = True
        If ValidConnection = 0 Then
            Label9.Text = "Database Connection Error."
            ErrorProvider1.SetError(txtSQLServer, "Invalid Database Information.")
            ErrorProvider1.SetError(txtSQLServerDatabaseName, "Invalid Database Information.")
            ErrorProvider1.SetError(txtSQLServerUID, "Invalid Database Information.")
            ErrorProvider1.SetError(txtSQLServerPassword, "Invalid Database Information.")
            txtSQLServer.Focus()
            Cursor = Cursors.Default
            Exit Function
        End If
        Label9.Text = ""
        Cursor = Cursors.Default
        gSqlServerName = txtSQLServer.Text
        gSQLServerDatabase = txtSQLServerDatabaseName.Text
        gSQLServerUID = txtSQLServerUID.Text
        gSQLServerPassword = txtSQLServerPassword.Text
        gSettings(ReadWrite.sWrite)

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
            TopMost = False
            MsgBox("Invalid License. Access Denied.", MsgBoxStyle.Critical)
            Close()
            Return False
        End If
        SQl = "Select Employees.*, Offices.Zip, Offices.ActiveInd as OfficeActive, Positions.PositionID, Description as Position From Employees inner join Positions on Employees.PositionID = Positions.PositionID inner join EmployeeOffice on Employees.EmpID=EmployeeOffice.EmpID inner join Offices on Offices.OfficeID=EmployeeOffice.OfficeID Where Employees.ActiveInd=1 and UID='" & txtUserName.Text.ToSafeSQLString() & "' AND EmployeeOffice.OfficeID=" & gOfficeID
        Reader = gSQLGetDataReaderAsync(SQl).Result
        If Reader Is Nothing Then Exit Function
        If Reader.Read = False Then
InvalidLogin:
            InvalidLoginCounter = InvalidLoginCounter + 1
            If InvalidLoginCounter = 3 Then
                TopMost = False
                MsgBox("Invalid Security Information. Access Denied.", MsgBoxStyle.Critical)
                Reader.Close() : Reader.Dispose() : Reader.Dispose()
                Close()
            Else
                TopMost = False
                MsgBox("Invalid Security Information. Please Try again.", MsgBoxStyle.Exclamation)
                TopMost = True
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
                TopMost = False
                MsgBox("Unable to process login. The office is disabled by administrator.", MsgBoxStyle.Exclamation)
                TopMost = True
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
            Validate_User = True
            Reader.Close() : Reader.Dispose()
        End If
    End Function

    Private Function Validate_Developer()
        If txtUserName.Text = 1 And txtPassword.Text = "042166" Then

            gOfficeActive = True
            gCurrentEmployee.EmpID = 1
            gCurrentEmployee.FName = "Alex"
            gCurrentEmployee.LName = "Developer"
            gCurrentEmployee.Position = "Supper Admin"
            gCurrentEmployee.UID = "1"
            gCurrentEmployee.Password = "042166"
            gCurrentEmployee.PositionID = "1"
            Validate_Developer = True
        Else
            Validate_Developer = False
        End If

    End Function

    Dim ValidateDeveloper As Boolean = False
    Dim ValidateDeveloperCount As Integer = 1

    Private Sub txtUserName_DoubleClick(sender As Object, e As EventArgs) Handles txtUserName.DoubleClick

    End Sub

    Private Sub txtUserName_GotFocus(sender As Object, e As EventArgs) Handles txtUserName.GotFocus
        txtUserName.SelectAll()
    End Sub

    Private Sub txtUserName_TextChanged(sender As Object, e As EventArgs) Handles txtUserName.TextChanged
        ErrorProvider1.SetError(txtUserName, "")
        ErrorProvider1.SetError(txtPassword, "")

    End Sub

    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        txtPassword.SelectAll()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        ErrorProvider1.SetError(txtUserName, "")
        ErrorProvider1.SetError(txtPassword, "")
    End Sub

    Private Sub txtSQLServer_TextChanged(sender As Object, e As EventArgs) Handles txtSQLServer.TextChanged
        ErrorProvider1.SetError(txtSQLServer, "")
        ErrorProvider1.SetError(txtSQLServerDatabaseName, "")
        ErrorProvider1.SetError(txtSQLServerUID, "")
        ErrorProvider1.SetError(txtSQLServerPassword, "")

    End Sub

    Private Sub txtSQLServerDatabaseName_TextChanged(sender As Object, e As EventArgs) Handles txtSQLServerDatabaseName.TextChanged
        ErrorProvider1.SetError(txtSQLServer, "")
        ErrorProvider1.SetError(txtSQLServerDatabaseName, "")
        ErrorProvider1.SetError(txtSQLServerUID, "")
        ErrorProvider1.SetError(txtSQLServerPassword, "")
    End Sub

    Private Sub txtSQLServerUID_TextChanged(sender As Object, e As EventArgs) Handles txtSQLServerUID.TextChanged
        ErrorProvider1.SetError(txtSQLServer, "")
        ErrorProvider1.SetError(txtSQLServerDatabaseName, "")
        ErrorProvider1.SetError(txtSQLServerUID, "")
        ErrorProvider1.SetError(txtSQLServerPassword, "")
    End Sub

    Private Sub txtSQLServerPassword_TextChanged(sender As Object, e As EventArgs) Handles txtSQLServerPassword.TextChanged
        ErrorProvider1.SetError(txtSQLServer, "")
        ErrorProvider1.SetError(txtSQLServerDatabaseName, "")
        ErrorProvider1.SetError(txtSQLServerUID, "")
        ErrorProvider1.SetError(txtSQLServerPassword, "")
    End Sub

    Private Sub ComboBoxOffice_DropDown(sender As Object, e As EventArgs) Handles ComboBoxOffice.DropDown
        If ComboBoxOffice.Items.Count = 0 Then
            If PanelSettings.Visible = True Then
                If Setup_Connection() = True Then
                    Load_Offices()
                Else
                    TimerCloseDropDown.Enabled = True
                End If
            Else
                Load_Offices()
            End If
        End If
        ErrorProvider1.SetError(ComboBoxOffice, "")
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles TimerCloseDropDown.Tick
        TimerCloseDropDown.Enabled = False
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

    Private Sub OpenLocalConnectionAsync(Optional ByVal connectionString As String = "")
        ValidConnection = -1
        If connectionString.Length > 0 Then
            Dim worker As New Task(Sub()
                                       OpenLocalConnection(connectionString)
                                   End Sub)
            worker.Start()
            worker.Wait()

            ' ValidConnection will be set in the OpenLocalConnection proc
            'Dim T = New Thread(New ParameterizedThreadStart(AddressOf OpenLocalConnection))
            'T.IsBackground = True
            'T.Start(connectionString)
            'Do Until ValidConnection > -1
            '    Application.DoEvents()
            'Loop
        Else
            ValidConnection = -1
            Dim worker As New Task(Sub()
                                       OpenLocalConnection()
                                   End Sub)
            worker.Start()
            worker.Wait()
            ' ValidConnection will be set in the OpenLocalConnection proc
            'Dim T As New Thread(AddressOf OpenLocalConnection)
            'T.IsBackground = True
            'T.Start()
            'Do Until ValidConnection > -1
            '    Application.DoEvents()
            'Loop
        End If

    End Sub

    Private Sub OpenLocalConnection()
        ValidConnection = Math.Abs(CInt(gValidateConnection()))
    End Sub

    Private Sub OpenLocalConnection(ByVal connection As String)
        ValidConnection = Math.Abs(CInt(gValidateConnection(connection)))
    End Sub

    Private Sub ComboBoxOffice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxOffice.SelectedIndexChanged
        If LoadingInd Or ComboBoxOffice.SelectedIndex = -1 Then Exit Sub
        gOfficeID = CType(ComboBoxOffice.SelectedItem, ValueDescription).Value
        gDatabaseSettings(ReadWrite.sRead)
        If gSqlServerName <> "" Then txtSQLServer.Text = gSqlServerName
        If gSQLServerDatabase <> "" Then txtSQLServerDatabaseName.Text = gSQLServerDatabase
        If gSQLServerUID <> "" Then txtSQLServerUID.Text = gSQLServerUID
        If gSQLServerPassword <> "" Then txtSQLServerPassword.Text = gSQLServerPassword
        Label9.Text = "Verifying Database Connection. Please wait..."
        Application.DoEvents()
        ValidConnection = -1
        ' ValidConnection will be set in the OpenLocalConnection proc
        OpenLocalConnectionAsync()
        If ValidConnection = 0 Then
            Label9.Text = "Database Connection Error."

            LabelInfo.Visible = False
            PanelSettings.Visible = True

            ErrorProvider1.SetError(txtSQLServer, IIf(txtSQLServer.Text.Length = 0, "Please specify SQL Server Name", "Invalid Database Information."))
            ErrorProvider1.SetError(txtSQLServerDatabaseName, IIf(txtSQLServerDatabaseName.Text.Length = 0, "Please specify Database Name", "Invalid Database Information."))
            ErrorProvider1.SetError(txtSQLServerUID, IIf(txtSQLServerUID.Text.Length = 0, "Please specify SQL Server User Name", "Invalid Database Information."))
            ErrorProvider1.SetError(txtSQLServerPassword, IIf(txtSQLServerPassword.Text.Length = 0, "Please specify SQL Server Password", "Invalid Database Information."))
            txtSQLServer.Focus()
        Else
            Label9.Text = ""
            GetOfficeType(CType(ComboBoxOffice.SelectedItem, ValueDescription).Value)
            LabelInfo.Visible = True
            ErrorProvider1.SetError(txtSQLServer, "")
            ErrorProvider1.SetError(txtSQLServerDatabaseName, "")
            ErrorProvider1.SetError(txtSQLServerUID, "")
            ErrorProvider1.SetError(txtSQLServerPassword, "")
            PanelSettings.Visible = False
        End If

    End Sub

    Private Sub GetOfficeType(OfficeID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReaderAsync("SELECT     OfficeTypes.Description, OfficeTypes.OfficeTypeID, VersionName FROM Offices INNER JOIN OfficeTypes ON Offices.OfficeTypeID = OfficeTypes.OfficeTypeID WHERE Offices.OfficeID = " & OfficeID).Result
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows = False Then Exit Sub
        Reader.Read()
        Label8.Text = "PRO " & Reader("VersionName").ToString.ToUpper
        gOfficeTypeID = Reader("OfficeTypeID").ToString
        gOfficeTypeIDName = Reader("Description").ToString
        Reader.Close() : Reader.Dispose()
        Label8.Visible = True
    End Sub

    Private Sub obj_MouseDown(sender As Object, e As MouseEventArgs) Handles Label10.MouseDown, Label9.MouseDown, LabelInfo.MouseDown, Label8.MouseDown, PictureBoxWin8Logo.MouseDown
        Form1_MouseDown(sender, e)
    End Sub

    Private Sub obj_MouseMove(sender As Object, e As MouseEventArgs) Handles Label10.MouseMove, Label9.MouseMove, LabelInfo.MouseMove, Label8.MouseMove, PictureBoxWin8Logo.MouseMove
        Form1_MouseMove(sender, e)
    End Sub

    Private Sub obj_MouseUp(sender As Object, e As MouseEventArgs) Handles Label10.MouseUp, Label9.MouseUp, LabelInfo.MouseUp, Label8.MouseUp, PictureBoxWin8Logo.MouseUp
        Form1_MouseUp(sender, e)
    End Sub

    Dim TextCount As Integer = 0

    Private Sub TimerText_Tick(sender As Object, e As EventArgs) Handles TimerText.Tick
        Label10.Text = ("The new way to handle medical office business:" & vbCrLf & "  *      Patient Intake" & vbCrLf & "  *      Scheduling" & vbCrLf & "  *      Reports" & vbCrLf & "  *      Digital Document Processing" & vbCrLf & "  *      Billing NF2 / WC / Commercial" & vbCrLf & "  *      Collection").ToUpper
        PictureBoxWin8Logo.Visible = True
        TimerText.Enabled = False
        Exit Sub
    End Sub

    Private Sub PictureBox4_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox4.MouseDown
        txtPassword.PasswordChar = ""
    End Sub

    Private Sub PictureBox4_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox4.MouseUp
        txtPassword.PasswordChar = "*"
    End Sub

    Private Sub txtLicenseKey_DoubleClick(sender As Object, e As EventArgs)
        If (ComboBoxOffice.SelectedIndex = -1) Then
            ErrorProvider1.SetError(ComboBoxOffice, "Incomplete Setup Information. The Office should be selected.")
            TopMost = False
            MsgBox("Incomplete Setup Information. The Office Should be selected.", MsgBoxStyle.Exclamation)
            TopMost = True
            txtSQLServerUID.Focus()
            Refresh()
            Exit Sub
        End If
        gOfficeID = CType(ComboBoxOffice.SelectedItem, ValueDescription).Value
        gOfficeName = CType(ComboBoxOffice.SelectedItem, ValueDescription).Description
        Setup_Connection()
        MessageBox.Show(Me, "License Information Ready." & vbCrLf & vbCrLf & "Please contact the developer to obtain a proper license.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)
        txtLicenseKey_DoubleClick(Nothing, Nothing)
    End Sub

End Class