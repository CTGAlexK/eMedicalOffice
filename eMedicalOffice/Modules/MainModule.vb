Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports CrystalDecisions.Windows.Forms
Imports FarPoint.Win.Spread
Imports log4net
Imports log4net.Appender
Imports log4net.Config
Imports log4net.Repository
Imports Twilio.Clients
Imports System.Management

Module MainModule

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public gMultiOfficeMode As Boolean? = True

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public PayersList As List(Of Payer) = New List(Of Payer)
    Public AutoUpdateWasRunning As Boolean
    Public SaveSuppervisorApprovalBorBillAmountChange As Boolean
    Public TurnOffAutoUpdateTimer As Boolean

#Region "Declarations"
    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Public Function CreateRoundRectRgn(ByVal nLeftRect As Integer, ByVal nTopRect As Integer, ByVal nRightRect As Integer, ByVal nBottomRect As Integer, ByVal nWidthEllipse As Integer, ByVal nHeightEllipse As Integer) As IntPtr
    End Function
    Public Enum eNumSysFunctions
        PatientMaintenance = 1
        Schedule = 2
        Billing = 3
        BillingManagement = 4
        CDRecording = 5
        Web = 6
        WebMobile = 7
        WebPDF = 8
        WebPackImaging = 9
        WebTranscription = 10
        WebReadingReports = 11
    End Enum

    Public Structure SysFunctions
        Public PatientMaintenance As Boolean
        Public Schedule As Boolean
        Public Billing As Boolean
        Public BillingManagement As Boolean
        Public CDRecording As Boolean
        Public Web As Boolean
        Public WebMobile As Boolean
        Public WebPDF As Boolean
        Public WebPackImaging As Boolean
        Public WebTranscription As Boolean
        Public WebReadingReports As Boolean
        Public WebAttorneyDocuments As Boolean
    End Structure

    Public Structure TVITEM
        Public mask As Integer
        Public hItem As IntPtr
        Public state As Integer
        Public stateMask As Integer
        <MarshalAs(UnmanagedType.LPTStr)> Public lpszText As String
        Public cchTextMax As Integer
        Public iImage As Integer
        Public iSelectedImage As Integer
        Public cChildren As Integer
        Public lParam As IntPtr
    End Structure

    Public Structure Address
        Public AddressType As String
        Public FormattedAddress As String
        Public StreetAddress As String
        Public City As String
        Public State As String
        Public Zip As String
        Public Adjusted As Boolean
    End Structure

    Public WithEvents Tmr As New System.Windows.Forms.Timer
    Private RestoreSearchTextBox As TextBox

    Public Structure tEmployee
        Public EmpID As Integer
        Public FName As String
        Public LName As String
        Public UID As String
        Public Password As String
        Public Position As String
        Public PositionID As Long
        Public SC As Boolean
        Public ComputerInfo As IpInfo
    End Structure

    Public Enum PatientLogTypes
        tRead = 1
        tCreateNew = 2
        tUpdated = 3
        tStatusChange = 4
        tProceduresAdded = 5
        tProceduresRemoved = 6
        tScheduleCreated = 7
        tScheduleCanceled = 8
        tScheduleChanged = 9
        tNoMoreSchedules = 10
        tTransportationRequested = 11
        tTransportationCanceled = 12
        tScheduleCompleted = 13
        tSuppervisorApproval = 14
        tCashPaymentReceived = 15
        tNoMoreSchedulesRemoved = 16
        tDocumentAdded = 17
        tDocumentDeleted = 18
        tBillCreated = 19
        tBillDeleted = 20
        tBillPaid = 21
        ImageDiskRequested = 22
        ImageDiskRequestRemoved = 23
        tBillReproduced = 24
        tBillStatusChanged = 25
        tAttorneyAssigned = 26
        tAttorneyRemoved = 27
        tProcedureReadingUpdated = 28
        tRequestCreated = 29
        tRequestInProgress = 30
        tRequestCompleted = 31
        tRequestCanceled = 32
        tRequestCanceledAll = 33
        tProcedureUndone = 34
        tServiceAdded = 35
        tServiceRemoved = 36
        tServiceScheduled = 37
        tServiceScheduleDateChanged = 38
        tServiceComplete = 39
        tServiceCompleteDateChanged = 40
        tServiceResultReceived = 41
        tServiceResultReceivedDateChanged = 42
        tProcedureDoNotBill = 43
        tBillChanged = 44
        tBillPaymentChanged = 45
        tOther = 46
        tInsuranceExaminationScheduled = 47
        tInsuranceExaminationConfirmed = 48
        tInsuranceExaminationComplete = 49
        tInsuranceExaminationNoShow = 50
        tInsuranceExaminationCanceledRescheduled = 51
        tScheduleNoShow = 52
        tPaymentDeleted = 53
        tScheduleConfirmed = 54
        tSchedulePresent = 55
        tScheduleNotPresent = 56
        tScheduleNotCompleted = 57
        tScheduleCouponPrinted = 58
        tScheduleTransportationChanged = 59
        tPreCertificationComplete = 60
        tPreCertificationRemoved = 61
        tEmailSent = 62
        tFaxSent = 63
    End Enum

    Public Structure ScheduleInfo
        Public PatientID As Long
        Public ScheduleID As Long
        Public PickupTransportation As Integer
        Public DestinationTransportation As Integer
        Public PickupTransportationOther As String
        Public DestinationTransportationOther As String
        Public ToolTip As String
        Public ShowUpDateTime As Date
        Public CaseTypeID As Integer
        Public ConfirmedBy As String
        Public ScheduleDateTime As Date
        Public PatientPhone As String
        Public ProcName As String
        Public PreCertificationDT As String
        Public ProcedurePaid As Integer
        Public SchedulkeBlockID As Integer
    End Structure

    Public Enum AddEditMode
        None = 0
        AddNew = 1
        Edit = 2
    End Enum


    Public gReferringOfficeDoctors As Integer = 120
    Public gTwilioFromPhoneNumber As String
    Public gTwilioAccountSid As String
    Public gTwilioAuthToken As String
    Public gTwilioMessageTypeId As Integer
    Public gTwilioBin As String
    Public gLicenseKeyValidated As Boolean
    Public gCurrentEmployee As tEmployee
    Public gConnectionString As String
    Public gPacsConnectionString As String
    Public gDefaultState As String
    Public gOfficeID As String
    Public gOfficeName As String
    Public gOfficeTypeID As Long
    Public gEnableElectronicBillFiling As Integer
    Public gOfficeTypeIDName As String
    Public gOfficeEmail As String
    Public gOfficeFax As String
    Public gOfficeURL As String
    Public gOfficeActive As Boolean
    Public gOffices As New List(Of Office)
    Public gLocalIPAddress As String
    Public gLocalHostName As String
    Public gSimplifiedBilling As Integer
    Public gPACSAltNumberRequired As Integer
    Public gPACSPath As String
    Public gQuikSearch As Boolean
    Public gMemoPad As Boolean
    Public gFullScreen As Boolean

    'Public gAutocompleteAttorneys As New AutoCompleteStringCollection()
    Public gAutocompleteFname As New AutoCompleteStringCollection()

    Public gAutocompleteLName As New AutoCompleteStringCollection()
    Public gAutocompleteAddress As New AutoCompleteStringCollection()
    Public gAutocompleteCity As New AutoCompleteStringCollection()
    Public gAutocompleteOccupation As New AutoCompleteStringCollection()
    Public gAutocompleteAdjusterName As New AutoCompleteStringCollection()
    Public gAutocompleteEmployerName As New AutoCompleteStringCollection()
    Public gAutocompleteProcName As New AutoCompleteStringCollection()
    Public gAutocompleteInsuranceCompanies As New AutoCompleteStringCollection()
    Public gAutocompleteRefferingOfficeName As New AutoCompleteStringCollection()
    Public gAutocompleteTransportationCompanyName As New AutoCompleteStringCollection
    Public gAutocompleteAttorneyOffice As New AutoCompleteStringCollection
    Public preLoadCaseStatuses As List(Of ValueDescription) = New List(Of ValueDescription)
    Public preLoadStates As List(Of String) = New List(Of String)
    Public preLoadCaseTypes As List(Of ValueDescription) = New List(Of ValueDescription)
    Public preLoadMaritalStatuses As List(Of ValueDescription) = New List(Of ValueDescription)
    Public preLoadEmploymentStatuses As List(Of ValueDescription) = New List(Of ValueDescription)
    Public preLoadInjuryTypes As List(Of ValueDescription) = New List(Of ValueDescription)
    Public preLoadTransportationCompanies As List(Of ValueDescription) = New List(Of ValueDescription)
    Public preLoadPatientTypes As List(Of ValueDescription) = New List(Of ValueDescription)
    Public preLoadRelationships As List(Of ValueDescription) = New List(Of ValueDescription)
    Public preLoadSymptoms As List(Of ValueDescription) = New List(Of ValueDescription)
    Public preLoadBillingCompanies As List(Of ValueDescription) = New List(Of ValueDescription)

    Public gProcsPerVisit As Integer
    Public gfrmPatientLoaded As Boolean
    Public gfrmScheduleLoaded As Boolean
    Public gMinAge As Integer
    Public gUnderAge As Integer
    Public gMinNoFaultDays As Integer
    Public gNFBetweenMRIDays As Integer
    Public gDOAAge As Integer
    Public gNoShowHours As Integer
    Public gCashDiscountPct As Decimal
    Public gCaseTypes() As ValueDescription
    Public gPrintPatientLabel As Integer
    Public gPrinterFileLabel As String
    Public gCDLabelPrinter As String
    Public gPrinterNF3 As String
    Public gPrinterBillingEnvelope As String
    Public gCDEnvelopeLabelType As Integer
    Public gEnvelopPaperType As Integer
    Public gEnvelopShiftToCenter As Boolean
    Public gEnvelopNoPageSize As Boolean
    Public gSystemIdleTime As Long
    Public gIdleTimeCurrent As Long
    Public gRestart As Boolean

    Public gPrinterOtherDocuments As String
    Public gBillingMinDays As Integer
    Public gBillingMaxDays As Integer
    Public gAttorneyNoConfirmationAge As Integer
    Public gBillingRequestWarningAge As Integer

    Public gImageDiskPriceForInsuranceCompany As Double
    Public gImageDiskPriceForMedicalOffice As Double
    Public gImageDiskPriceCash As Double
    Public gWebFaxAddress As String
    Public gWebFaxLeadingOne As Boolean

    Public gBillingNFDefaultBillingCompany As Integer
    Public gBillingWCDefaultBillingCompany As Integer
    Public gBillingPrivateDefaultBillingCompany As Integer

    Public gBillingNFDefaultBillingCompanyAllowChange As Integer
    Public gBillingWCDefaultBillingCompanyAllowChange As Integer
    Public gBillingPrivateDefaultBillingCompanyAllowChange As Integer
    Public gCancelationWarning As Integer
    Public gCancelationDrop As Integer
    Public gNF2MainBillingProviderID As Integer
    Public gCheckAddress As Boolean

    Public gNF2MinAge As Integer
    Public gNF2MaxAge As Integer
    Public gNF3Template As Integer
    Public gScannerImageIndex As Integer = -1
    Public gScannerMode As Integer
    Public gScannerFolder As String
    Public gSystemAutoUpdatePath As String
    Public gSystemLibraryPath As String
    Public gSysAdminUID As String
    Public gSysAdminPWD As String
    Public gAppPath As String
    Public gAddressVerificationAddress As String
    Public gShowIntakeFormButton As Boolean
    Public PaymentScanCheck As Boolean
    Public gSMTPUID As String 'username@gmail.com'
    Public gSMTPPWD As String
    Public gSMTPHost As String
    Public gSMTPPort As Integer
    Public gSMTPFromAddress As String
    Public gSMTPAsync As Integer
    Public gCollectionFunction As Boolean
    Public SystemFunctions As SysFunctions
    Public gDebugMode As Boolean
    Public gIdleShutDown As Integer
    Public MDILoaded As Boolean
    Private ReadOnly Spar As String = "HjTdDassEDEer2341209uNtGeeRFtGRDeSMMnBDSuTYyTYDBXb772iNFTyUFD"
    Public LastSelectedDocExportFolder As String
    Public frmBillingManagementInstance As frmBillingManagement
    Public frmBillingCollectionInstance As frmBillingCollection
    Public frmProceduresReportInstance As frmProceduresReport
    Public frmScheduleInstance As frmSchedule
    Public frmMDIParent As MDIForm1Win8
    Private twilioClient As TwilioRestClient
    Public gAppConfig As AppConfig = New AppConfig()
    'Public gAppSettings As SettingsDB = New SettingsDB()
    Public gCapturePhoto As frmCapturePhoto
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public PatientsFindDuplicatesOpened As Boolean

#End Region

    Public Function GetFirstWeekDateDates(FromDate As Date) As Date
        Dim offset As Double = 0
        Select Case FromDate.DayOfWeek
            Case DayOfWeek.Monday : offset = 0
            Case DayOfWeek.Tuesday : offset = -1
            Case DayOfWeek.Wednesday : offset = -2
            Case DayOfWeek.Thursday : offset = -3
            Case DayOfWeek.Friday : offset = -4
            Case DayOfWeek.Saturday : offset = -5
            Case DayOfWeek.Sunday : offset = -6
        End Select
        GetFirstWeekDateDates = DateAdd(DateInterval.Day, offset, FromDate)
    End Function

    Public Function gYearsFromDate(dob) As Integer
        If dob = "" Or IsDate(dob) = False Then
            Return 0
        End If
        dob = CDate(dob)
        Dim years As Integer, months As Integer
        months = 12 * (DateTime.Now.Year - dob.Year) + (DateTime.Now.Month - dob.Month)

        If DateTime.Now.Day < dob.Day Then
            months -= 1
        End If
        years = Math.Floor(months / 12)
        'months -= years * 12
        Return years
    End Function

    Public Function GetHardwareIDentifier() As String
        Dim id As String = ""
        Dim DriveLetter As String = ""
        'Dim hw As New clsComputerInfo
        ''Decalre variables
        'Dim hdd, cpu, mb, mac As String
        ''Get all the values
        'cpu = hw.GetProcessorId()
        'hdd = hw.GetVolumeSerial("C")
        'mb = hw.GetMotherBoardID()
        'mac = hw.GetMACAddress()
        ''Generate the hash
        'Dim hwid As String = GenerateSHA512String(cpu & hdd & mb & mac)
        'Return hwid
        DriveLetter = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System))
        id = GetDriveSerialNumber(DriveLetter).ToString()

        Try
            Dim moc As ManagementObjectCollection = New ManagementClass("win32_processor").GetInstances()

            For Each mo As ManagementObject In moc
                Return (id & mo("ProcessorId")).ToString().ToSafeSQLString()
            Next
        Catch ex As Exception
            log.Error(ex)
            Return id.ToSafeSQLString()
        End Try
    End Function

    Public Sub gLoadSystemFunctions()
        Dim Reader As SqlDataReader
        SystemFunctions.Billing = True
        SystemFunctions.BillingManagement = True
        SystemFunctions.CDRecording = True
        SystemFunctions.PatientMaintenance = True
        SystemFunctions.Schedule = True
        SystemFunctions.Web = True
        SystemFunctions.WebMobile = True
        SystemFunctions.WebPackImaging = True
        SystemFunctions.WebPDF = True
        SystemFunctions.WebTranscription = True
        SystemFunctions.WebReadingReports = True
        SystemFunctions.WebAttorneyDocuments = True
        Return
        'Reader = gSQLGetDataReader("Select * from SysFunctions Where OfficeID=" & gOfficeID)
        'Do Until Reader.Read = False
        '    Select Case Reader("FunctionName").ToString
        '        Case "Billing"
        '            SystemFunctions.Billing = CBool(Val(Reader("Enabled").ToString))
        '        Case "Billing Management"
        '            SystemFunctions.BillingManagement = CBool(Val(Reader("Enabled").ToString))
        '        Case "CD Recording"
        '            SystemFunctions.CDRecording = CBool(Val(Reader("Enabled").ToString))
        '        Case "PatientMaintenance"
        '            SystemFunctions.PatientMaintenance = CBool(Val(Reader("Enabled").ToString))
        '        Case "Schedule"
        '            SystemFunctions.Schedule = CBool(Val(Reader("Enabled").ToString))
        '        Case "Web"
        '            SystemFunctions.Web = CBool(Val(Reader("Enabled").ToString))
        '        Case "WebMobile"
        '            SystemFunctions.WebMobile = CBool(Val(Reader("Enabled").ToString))
        '        Case "WebPackImaging"
        '            SystemFunctions.WebPackImaging = CBool(Val(Reader("Enabled").ToString))
        '        Case "WebPDF"
        '            SystemFunctions.WebPDF = CBool(Val(Reader("Enabled").ToString))
        '        Case "WebTranscription"
        '            SystemFunctions.WebTranscription = CBool(Val(Reader("Enabled").ToString))
        '        Case "WebReadingReports"
        '            SystemFunctions.WebReadingReports = CBool(Val(Reader("Enabled").ToString))
        '        Case "WebAttorneyDocuments"
        '            SystemFunctions.WebAttorneyDocuments = CBool(Val(Reader("Enabled").ToString))
        '    End Select
        'Loop
    End Sub

    Public Sub DisplayMapDriveDialog(Hwnd As Integer)
        Const RESOURCETYPE_DISK = &H1
        Try
            WNetConnectionDialog(Hwnd, RESOURCETYPE_DISK)
        Catch ex As Exception

        End Try
    End Sub

    Public Function gDeleteFolder(UserHomeDir As String) As Boolean
        Dim Folder As String
        Dim File As String
        Try
            For Each Folder In Directory.GetDirectories(UserHomeDir)
                If gDeleteFolder(Folder) = False Then Exit Function
                For Each File In Directory.GetFiles(Folder)
                    Try
                        IO.File.Delete(File)
                        Application.DoEvents()
                        Directory.Delete(Folder & "\DICOM", True)
                    Catch ex As Exception
                        log.Error(ex.Message, ex)
                    End Try
                Next
            Next
            For Each File In Directory.GetFiles(UserHomeDir)
                Try
                    IO.File.Delete(File)
                    Application.DoEvents()
                Catch ex As Exception
                    log.Error(ex.Message, ex)
                End Try
            Next
        Catch ex As Exception
            log.Error(ex.Message, ex)
        End Try
        Return True
    End Function

    'Public gfrmPatient As frmPatient
    Public Function gProcessAutoUpdate(NotificationOnly As Boolean, ForceUpdateAgain As Boolean) As Boolean
        Dim Reader As SqlDataReader
        Dim LastUpdate As String
        Dim CurrentUpdate As String
        ''' RUN ONCE A DAY
        Dim curDate As Date = CDate(Now.ToShortDateString)
        Dim lastUpdateDateSetting As String = GetSetting("eMedical Office", "AutoUpdate", "LastUpdateDate", "")
        If lastUpdateDateSetting.Length = 0 Or IsDate(lastUpdateDateSetting) = False Then
            lastUpdateDateSetting = gAppConfig.GetValueStr("LastUpdateDate", "")
        End If
        SaveSetting("eMedical Office", "AutoUpdate", "LastUpdateDate", curDate.ToString())
        gAppConfig.SaveSetting("LastUpdateDate", curDate.ToString())
        If ForceUpdateAgain = False Then
            If lastUpdateDateSetting.Length > 0 AndAlso IsDate(lastUpdateDateSetting) Then
                If CDate(lastUpdateDateSetting) >= curDate Then
                    log.Debug("Autoupdate skip. Already was running on: " + lastUpdateDateSetting)
                    Return False
                End If
            End If
        End If
        AutoUpdateWasRunning = True

        ''''''''''''''''''''''''''''''''''''''''''

        If gSystemAutoUpdatePath = "" Then
            Reader = gSQLGetDataReader("Select * from Offices Where OfficeID=" & Val(gOfficeID))
            If Reader Is Nothing Then Exit Function
            If Reader.HasRows Then
                Reader.Read()
                gSystemAutoUpdatePath = Reader("SystemAutoUpdatePath").ToString
                gSysAdminUID = Reader("SysAdminUID").ToString
                gSysAdminPWD = Reader("SysAdminPWD").ToString
                If gSystemAutoUpdatePath <> "" Then
                    If gSystemAutoUpdatePath.EndsWith("\") = False Then
                        gSystemAutoUpdatePath = gSystemAutoUpdatePath & "\"
                    End If
                End If
            End If
            Reader.Close()
            Reader.Dispose()
            Reader.Dispose()
        End If
        If gSystemAutoUpdatePath = "" Then
            log.Debug("Autoupdate path is not set.")
            Exit Function
        End If

        If Directory.Exists(gSystemAutoUpdatePath) = False Then
            log.Debug("Autoupdate path: " + gSystemAutoUpdatePath + " is not accessible.")
            Exit Function
        End If

        Dim FileNameFull As String = Assembly.GetExecutingAssembly().Location
        Dim FileName As String
        Dim LocalFile As New FileInfo(FileNameFull)
        Dim StartUpPath As String = LocalFile.Directory.FullName
        If StartUpPath.EndsWith("\") = False Then StartUpPath = StartUpPath & "\"
        Dim LocalFileVersion As FileVersionInfo
        Dim RemoteFileVersion As FileVersionInfo
        LocalFileVersion = FileVersionInfo.GetVersionInfo(FileNameFull)
        FileName = LocalFile.Name
        Dim result As Boolean = False
        Dim worker As New Task(Sub()
                                   result = CheckForNewSetup()
                               End Sub)
        worker.Start()
        worker.Wait()

        If result = True Then
            MsgBox(
                "The New Updated Version of the eMedicalOffice has been released." & vbCrLf &
                "System ReInstallation is required." & vbCrLf & vbCrLf &
                "Setup process will install the new version of eMedicalOfficeon." & vbCrLf & vbCrLf &
                "Please follow the OnScreen instructions." & vbCrLf & vbCrLf & vbCrLf & vbCrLf &
                "The setup process may require administrative privileges to run." & vbCrLf &
                "For more information, please contact your system administrator.", MsgBoxStyle.Information,
                "eMedicalOffice System Update")
            Dim objProcess As New Process
            objProcess.StartInfo.FileName = StartUpPath & "eMedicalOffice.msi"
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            Try
                objProcess.Start()
                gProcessAutoUpdate = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If Not (objProcess Is Nothing) Then
                    objProcess.Dispose()
                End If

            End Try

            'gProcessAutoUpdate = True
            'Diagnostics.Process.Start(StartUpPath & "eMedicalOffice.msi")
            Exit Function
        End If

        If File.Exists(gSystemAutoUpdatePath & FileName) = False Then Exit Function

        Dim workerFileVersion As New Task(Sub()
                                              RemoteFileVersion = FileVersionInfo.GetVersionInfo(gSystemAutoUpdatePath & FileName)
                                          End Sub)
        workerFileVersion.Start()
        workerFileVersion.Wait()

        If _
            (LocalFileVersion.FileMajorPart < RemoteFileVersion.FileMajorPart) Or
            (LocalFileVersion.FileMinorPart < RemoteFileVersion.FileMinorPart) Or
            (LocalFileVersion.FileBuildPart < RemoteFileVersion.FileBuildPart) Or
            (LocalFileVersion.FileBuildPart = RemoteFileVersion.FileBuildPart And
             LocalFileVersion.FilePrivatePart < RemoteFileVersion.FilePrivatePart) Then
            If NotificationOnly = False Then
                If CreateUpdater() = False Then
                    MsgBox(
                        "The New Updated Version of the eMedicalOffice has been released." & vbCrLf & vbCrLf &
                        "The Current Version: " & LocalFileVersion.FileVersion & vbCrLf & "The New Version: " &
                        RemoteFileVersion.FileVersion & vbCrLf & vbCrLf &
                        "It is highly recommended to get the latest version of the " & vbCrLf & vbCrLf &
                        "The last Auto Update process has Failed. Msg 1001" & vbCrLf &
                        "Please call your systesystem administrator to fix the Auto Update problem.",
                        MsgBoxStyle.Information, "eMedicalOffice System Update")
                    Exit Function

                End If
            End If
            If NotificationOnly Then
                If MsgBox(
                    "The New Updated Version of the eMedicalOffice has been released." & vbCrLf & vbCrLf &
                    "The Current Version: " & LocalFileVersion.FileVersion & vbCrLf & "The New Version: " &
                    RemoteFileVersion.FileVersion & vbCrLf & vbCrLf &
                    "It is highly recommended to get the latest version of the " & vbCrLf & vbCrLf &
                    "Please save all unsaved data and restart the eMedicalOffice to get updated versaion. Msg 1002" &
                    vbCrLf & vbCrLf &
                    "Do you want the Autoupdate to re-process update now?",
                    MsgBoxStyle.Information + MsgBoxStyle.YesNo, "eMedicalOffice System Update") = MsgBoxResult.No Then
                    Exit Function
                End If
            End If
            ' Prevent Autoupdate from Running second time with the same version and the same date even if the first attempt to update failed
            CurrentUpdate = Date.Today.ToString("MMddyyyy") & RemoteFileVersion.ProductVersion.ToString
            LastUpdate = GetSetting("eMedicalOffice", "AutoUpdate", "LastUpdate", "")
            If LastUpdate = "" Then gAppConfig.GetValueStr("LastUpdate", "")
            If CurrentUpdate = LastUpdate Then
                MsgBox(
                    "The New Updated Version of the eMedicalOffice has been released." & vbCrLf & vbCrLf &
                    "The Current Version: " & LocalFileVersion.FileVersion & vbCrLf & "The New Version: " &
                    RemoteFileVersion.FileVersion & vbCrLf & vbCrLf &
                    "It is highly recommended to get the latest version of the " & vbCrLf & vbCrLf &
                    "The last Auto Update process has Failed. Msg 1003" & vbCrLf &
                    "Please call your systesystem administrator to fix the Auto Update problem. Msg 1003",
                    MsgBoxStyle.Information, "eMedicalOffice System Update")
                Exit Function
            End If

            SaveSetting("eMedical Office", "AutoUpdate", "LastUpdate", CurrentUpdate)

            log.Info(
                "Starting System Update. OldVersion: " & LocalFileVersion.FileVersion & vbCrLf & "New Version: " &
                RemoteFileVersion.FileVersion & vbCrLf & "Update From: " & gSystemAutoUpdatePath & FileName)
            SaveSetting("eMedical Office", "AutoUpdate", "RunOnce", "1")
            SaveSetting("eMedical Office", "AutoUpdate", "OldVersion", LocalFileVersion.FileVersion)
            SaveSetting("eMedical Office", "AutoUpdate", "NewVersion", RemoteFileVersion.FileVersion)
            SaveSetting("eMedical Office", "AutoUpdate", "CopyFrom", gSystemAutoUpdatePath & FileName)
            SaveSetting("eMedical Office", "AutoUpdate", "CopyTo", FileNameFull)
            SaveSetting("eMedical Office", "AutoUpdate", "SysAdminUID", gSysAdminUID)
            SaveSetting("eMedical Office", "AutoUpdate", "SysAdminPWD", gSysAdminPWD)

            gAppConfig.SaveSetting("LastUpdate", CurrentUpdate, True)
            gAppConfig.SaveSetting("RunOnce", "1", True)
            gAppConfig.SaveSetting("OldVersion", LocalFileVersion.FileVersion, True)
            gAppConfig.SaveSetting("NewVersion", RemoteFileVersion.FileVersion, True)
            gAppConfig.SaveSetting("CopyFrom", gSystemAutoUpdatePath & FileName, True)
            gAppConfig.SaveSetting("CopyTo", FileNameFull, True)
            gAppConfig.SaveSetting("SysAdminUID", gSysAdminUID, True)
            gAppConfig.SaveSetting("SysAdminPWD", gSysAdminPWD, True)
            gAppConfig.SaveSettingToFile()
            Application.DoEvents()
            '**** End Start IE as Admin ***********
            'Dim p As New Process
            'p.StartInfo.UseShellExecute=False
            'p.StartInfo.FileName = StartUpPath & "eMedicalOfficeUpdater.exe"
            'p.StartInfo.UserName = gSysAdminUID
            'dim passwordChars  As Char()
            'dim password As system.Security.SecureString = New system.Security.SecureString()
            'passwordChars = gSysAdminPWD.ToCharArray
            'For Each letter As Char In passwordChars
            '    password.AppendChar(letter)
            'Next
            'p.StartInfo.Password = password
            'Try
            '    p.Start
            'Catch ex As Exception
            '    log.Error(ex.Message,ex)
            Try
                Process.Start(StartUpPath & "eMedicalOfficeUpdater.exe")
            Catch exin As Exception
                log.Error(exin.Message, exin)
                gProcessAutoUpdate = False
            End Try
            'End Try

            'MsgBox("The new version of the eMedical Office has been released." & vbCrLf & vbCrLf & "The current version:  " & LocalFileVersion.FileVersion & vbCrLf & "The new version:  " & RemoteFileVersion.FileVersion & vbCrLf & vbCrLf & "eMedical Office will restart now to update to the new version.", MsgBoxStyle.Information)

            gProcessAutoUpdate = True
        End If
    End Function

    Private Function CheckForNewSetup() As Boolean
        Dim FileNameFull As String = Assembly.GetExecutingAssembly().Location
        Dim LocalFile As New FileInfo(FileNameFull)
        Dim StartUpPath As String = LocalFile.Directory.FullName
        If StartUpPath.EndsWith("\") = False Then StartUpPath = StartUpPath & "\"

        If File.Exists(gSystemAutoUpdatePath & "eMedicalOffice.msi") Then
            If File.Exists(StartUpPath & "eMedicalOffice.msi") Then
                If _
                    gCompareIfFilesDifferent(StartUpPath & "eMedicalOffice.msi",
                                             gSystemAutoUpdatePath & "eMedicalOffice.msi") = True Then
                    Try
                        File.Delete(gAppPath & "eMedicalOffice.msi")
                        Application.DoEvents()
                        File.Copy(gSystemAutoUpdatePath & "eMedicalOffice.msi", StartUpPath & "eMedicalOffice.msi",
                                  True)

                        CheckForNewSetup = True
                    Catch ex As Exception
                        Exit Function
                    End Try
                End If
            Else
                Try
                    File.Copy(gSystemAutoUpdatePath & "eMedicalOffice.msi", StartUpPath & "eMedicalOffice.msi", True)
                    CheckForNewSetup = True
                Catch ex As Exception

                End Try
            End If
        End If
    End Function

    Public Function gCompareIfFilesDifferent(FileFullPath1 As String, FileFullPath2 As String) As Boolean

        'returns true if two files passed to is are identical, false
        'otherwise

        'does byte comparison; works for both text and binary files

        'Throws exception on errors; you can change to just return
        'false if you prefer
        Try
            Dim LocalFile As New FileInfo(FileFullPath1)
            Dim RemoteFile As New FileInfo(FileFullPath2)

            If LocalFile.Length <> RemoteFile.Length Then
                Return True
            End If

            If LocalFile.LastWriteTime <> RemoteFile.LastWriteTime Then
                Return True
            End If

            Dim numBytes1 As Long = LocalFile.Length
            Dim fStream1 As New FileStream(FileFullPath1, FileMode.Open, FileAccess.Read)
            Dim br1 As New BinaryReader(fStream1)
            Dim data1 As Byte() = br1.ReadBytes(CInt(numBytes1))

            Dim numBytes2 As Long = RemoteFile.Length
            Dim fStream2 As New FileStream(FileFullPath1, FileMode.Open, FileAccess.Read)
            Dim br2 As New BinaryReader(fStream2)
            Dim data2 As Byte() = br2.ReadBytes(CInt(numBytes2))

            For i = 1 To data1.Length - 1
                If data1(i) <> data2(i) Then
                    Return True
                End If
            Next
            fStream1.Close()
            fStream2.Close()
            fStream1 = Nothing
            fStream2 = Nothing
            br1.Close()
            br2.Close()
            br1 = Nothing
            br2 = Nothing
            data1 = Nothing
            data2 = Nothing
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return False
    End Function

    Private Function CreateUpdater() As Boolean

        If File.Exists(gSystemAutoUpdatePath & "eMedicalOfficeUpdater.exe") Then
            Try
                If File.Exists(gAppPath & "eMedicalOfficeUpdater.exe") Then
                    File.Delete(gAppPath & "eMedicalOfficeUpdater.exe")
                    Application.DoEvents()
                End If
                File.Copy(gSystemAutoUpdatePath & "eMedicalOfficeUpdater.exe", gAppPath & "eMedicalOfficeUpdater.exe",
                          True)
                CreateUpdater = True
            Catch ex As Exception
                log.Error(ex.Message, ex)
                CreateUpdater = False
            End Try
        Else
            CreateUpdater = True
        End If
    End Function

    Function GetEmbeddedIcon(strName As String) As Icon
        Try
            Return New Icon(Assembly.GetExecutingAssembly.GetManifestResourceStream(strName))
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return Nothing
    End Function

    Public Sub gLockWindowUpdate(ObgHwnd As Long, Redraw As Boolean)
        Exit Sub
        SendMessageLong(ObgHwnd, WM_SETREDRAW, Redraw, 0)
    End Sub

    Public Sub gLoad_Autocompletes()
        Try
            Dim worker As New Task(Sub()
                                       gLoad_Autocomplete_Async()
                                   End Sub)
            worker.Start()
        Catch ex As Exception
            log.Error(ex)
        End Try
        'worker.Wait()
        'gLoad_Autocomplete_Async()

    End Sub

    Dim vox

    Public Sub gSpeak(pSTR As String)
        Try
            Dim RateOfSpeech = 3
            'Dim vox As New SpeechLib.SpVoice
            If IsNothing(vox) = False Then
                If vox.Status.RunningState = 2 Then
                    vox.Pause()
                    Application.DoEvents()
                End If
            Else
                vox = CreateObject("Sapi.SpVoice")
                If vox.GetVoices.Count = 0 Then Exit Sub
                vox.Voice = vox.GetVoices().Item(0)
                vox.Rate = RateOfSpeech
            End If
            ' clear your throat

            'SpeechLib.SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak - 2
            vox.Speak("".ToString, 2)
            vox.Rate = 2
            vox.Volume = 100
            'SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync - 1
            vox.Speak(pSTR, 1)
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Public Sub gCrystalViewerTabs(viewer As CrystalReportViewer,
                                  visible As Boolean)
        Try
            For Each C As Control In viewer.Controls
                If TypeOf (C) Is PageView Then
                    Dim tab As TabControl = C.Controls(0)
                    If visible = False Then
                        tab.ItemSize = New Size(0, 1)
                        tab.SizeMode = TabSizeMode.Fixed
                        tab.Appearance = TabAppearance.Buttons
                    Else
                        tab.ItemSize = New Size(67, 18)
                        tab.SizeMode = TabSizeMode.Normal
                        tab.Appearance = TabAppearance.Normal
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Public Sub gLoad_Autocomplete_Async()
        Dim SQL As String
        Dim Reader As SqlDataReader
        Try
            gAutocompleteFname.Clear()
            gAutocompleteLName.Clear()
            gAutocompleteAddress.Clear()
            gAutocompleteCity.Clear()
            gAutocompleteOccupation.Clear()
            gAutocompleteAdjusterName.Clear()
            gAutocompleteEmployerName.Clear()
            gAutocompleteProcName.Clear()
            gAutocompleteInsuranceCompanies.Clear()
            gAutocompleteRefferingOfficeName.Clear()
            gAutocompleteTransportationCompanyName.Clear()
            gAutocompleteAttorneyOffice.Clear()
            SQL = "SELECT DISTINCT Fname FROM Patients Order by Fname"
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                gAutocompleteFname.Add(Reader("Fname").ToString.Trim)
                Application.DoEvents()
            Loop
            SQL = "SELECT DISTINCT Lname FROM Patients Order by Lname"
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                gAutocompleteLName.Add(Reader("LName").ToString.Trim)
                Application.DoEvents()
            Loop
            Reader.Close()
            Reader.Dispose()
            SQL = "SELECT DISTINCT Address1 FROM Patients Order by Address1"
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                gAutocompleteAddress.Add(Reader("Address1").ToString.Trim)
                Application.DoEvents()
            Loop
            Reader.Close()
            Reader.Dispose()
            SQL = "SELECT DISTINCT City FROM Patients Order by City"
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                gAutocompleteCity.Add(Reader("City").ToString.Trim)
                Application.DoEvents()
            Loop
            Reader.Close()
            Reader.Dispose()
            SQL = "SELECT DISTINCT Occupation FROM Patients Order by Occupation"
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                gAutocompleteOccupation.Add(Reader("Occupation").ToString.Trim)
                Application.DoEvents()
            Loop
            SQL =
            "SELECT DISTINCT AdjusterName as Adjuster FROM Patients UNION SELECT DISTINCT AdjusterName1 as Adjuster FROM Patients Order by Adjuster"

            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                gAutocompleteAdjusterName.Add(Reader("Adjuster").ToString.Trim)
                Application.DoEvents()
            Loop
            Reader.Close()
            Reader.Dispose()
            SQL = "SELECT DISTINCT EmployerName FROM Patients Order by EmployerName"
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                gAutocompleteEmployerName.Add(Reader("EmployerName").ToString.Trim)
                Application.DoEvents()
            Loop
            Reader.Close()
            Reader.Dispose()
            SQL = "SELECT DISTINCT ProcName FROM Procedures Order by ProcName"
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                gAutocompleteProcName.Add(Reader("ProcName").ToString.Trim)
                Application.DoEvents()
            Loop
            Reader.Close()
            Reader.Dispose()
            SQL = "SELECT DISTINCT CompanyName FROM InsuranceCompanies Order by CompanyName"
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                gAutocompleteInsuranceCompanies.Add(Reader("CompanyName").ToString.Trim)
                Application.DoEvents()
            Loop
            Reader.Close()
            Reader.Dispose()
            SQL = "SELECT   DISTINCT   OfficeName FROM         ReferringOffices ORDER BY OfficeName"
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                gAutocompleteRefferingOfficeName.Add(Reader("OfficeName").ToString.Trim)
                Application.DoEvents()
            Loop
            Reader.Close()
            Reader.Dispose()
            SQL = "SELECT    DISTINCT CompanyName FROM         TransportationCompanies ORDER BY CompanyName"
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                gAutocompleteTransportationCompanyName.Add(Reader("CompanyName").ToString.Trim)
                Application.DoEvents()
            Loop
            Reader.Close()
            Reader.Dispose()
            SQL = "SELECT  DISTINCT  CompanyName FROM         Attorneys Where OfficeID = " & gOfficeID &
              "  ORDER BY CompanyName"
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                gAutocompleteAttorneyOffice.Add(Reader("CompanyName").ToString.Trim)
                Application.DoEvents()
            Loop
            Reader.Close()
            Reader.Dispose()

            Reader = gSQLGetDataReader("Select CaseTypeID, Description from CaseTypes")
            If Reader Is Nothing Then Exit Sub
            ReDim gCaseTypes(0)
            gCaseTypes(0) = New ValueDescription(0, "All")
            Do Until Reader.Read = False
                ReDim Preserve gCaseTypes(gCaseTypes.Length)
                gCaseTypes(gCaseTypes.Length - 1) = New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)),
                                                                     Reader("Description").ToString)
            Loop
            Reader.Close()
            Reader.Dispose()

            ' PreLoads
            preLoadCaseStatuses.Clear()
            preLoadStates.Clear()
            preLoadCaseTypes.Clear()
            preLoadMaritalStatuses.Clear()
            preLoadEmploymentStatuses.Clear()
            preLoadInjuryTypes.Clear()
            preLoadTransportationCompanies.Clear()
            preLoadPatientTypes.Clear()
            preLoadRelationships.Clear()
            preLoadSymptoms.Clear()
            preLoadBillingCompanies.Clear()
            Reader = gSQLGetDataReaderAsync("SELECT CaseStatusID, Description FROM CaseStatuses Order By ShowOrder").Result
            If Not Reader Is Nothing Then
                preLoadCaseStatuses.Add(New ValueDescription(0, "All Statuses"))
                Do Until Reader.Read = False
                    preLoadCaseStatuses.Add(New ValueDescription(CLng(Val(Reader("CaseStatusID").ToString)), Reader("Description").ToString))
                Loop
                Reader.Close()
                Reader.Dispose()
            End If

            Reader = gSQLGetDataReaderAsync("Select State, ShowOrder from States Order by ShowOrder").Result
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    preLoadStates.Add(Reader("State").ToString)
                Loop
                Reader.Close()
                Reader.Dispose()
            End If

            Reader = gSQLGetDataReaderAsync("Select MaritalStatusID, Description from MaritalStatuses").Result
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    preLoadMaritalStatuses.Add(New ValueDescription(CLng(Val(Reader("MaritalStatusID").ToString)),
                                                                           Reader("Description").ToString))
                Loop
                Reader.Close()
                Reader.Dispose()
            End If
            Reader = gSQLGetDataReaderAsync("Select EmploymentStatusID, Description from EmploymentStatuses").Result
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    preLoadEmploymentStatuses.Add(New ValueDescription(CLng(Val(Reader("EmploymentStatusID").ToString)), Reader("Description").ToString))
                Loop
                Reader.Close()
                Reader.Dispose()
            End If
            Reader = gSQLGetDataReaderAsync("Select InjuryID, InjuryName from InjuryTypes Where ActiveInd=1").Result
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    preLoadInjuryTypes.Add(New ValueDescription(CLng(Val(Reader("InjuryID").ToString)),
                                                                    Reader("InjuryName").ToString))
                Loop
                Reader.Close()
                Reader.Dispose()
            End If
            Reader = gSQLGetDataReaderAsync("Select CompanyID, CompanyName from TransportationCompanies Where ActiveInd=1").Result
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    preLoadTransportationCompanies.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString))
                Loop
                Reader.Close()
                Reader.Dispose()
            End If
            Reader = gSQLGetDataReaderAsync("Select PatientTypeID, Description from PatientTypes").Result
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    preLoadPatientTypes.Add(New ValueDescription(CLng(Val(Reader("PatientTypeID").ToString)),
                                                                         Reader("Description").ToString))
                Loop
                Reader.Close()
                Reader.Dispose()
            End If
            Reader = gSQLGetDataReaderAsync("Select CaseTypeID, Description from CaseTypes order by ShowOrder").Result
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    preLoadCaseTypes.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)),
                                                                      Reader("Description").ToString))
                Loop
                Reader.Close()
                Reader.Dispose()
            End If
            Reader = gSQLGetDataReaderAsync("Select RelationshipID, Description from Relationships").Result
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    preLoadRelationships.Add(New ValueDescription(CLng(Val(Reader("RelationshipID").ToString)),
                                                                           Reader("Description").ToString))
                Loop
                Reader.Close()
                Reader.Dispose()
            End If

            Reader = gSQLGetDataReaderAsync("Select ID, Description from Symptoms").Result
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    preLoadSymptoms.Add(New ValueDescription(CLng(Val(Reader("ID").ToString)),
                                                             Reader("Description").ToString))
                Loop
                Reader.Close()
                Reader.Dispose()
            End If

            Reader = gSQLGetDataReaderAsync("SELECT     BillingCompanyID, CompanyName FROM BillingCompanies ORDER BY CompanyName").Result
            If Not Reader Is Nothing Then
                Do Until Reader.Read = False
                    preLoadBillingCompanies.Add(New ValueDescription(CLng(Val(Reader("BillingCompanyID").ToString)),
                                                                     Reader("CompanyName").ToString))
                Loop
                Reader.Close()
                Reader.Dispose()
            End If
        Catch ex As Exception
            log.Error(ex)
        End Try
        Reader = Nothing
    End Sub

    Public Function gValidateLicenseKey(pLicenseKey As String) As Boolean
        'Error on change payment infor
        'return True
        If gLicenseKeyValidated Then Return True
        Dim Reader As SqlDataReader
        Dim lLicenseKey As String
        Dim OfficeName As String
        If pLicenseKey = "" Or gSQLServerDatabase = "" Then Exit Function
        Try
            Reader = gSQLGetDataReader("SELECT OfficeName FROM Offices Where OfficeID=" & gOfficeID)
            If Reader Is Nothing Then Exit Function
            If Reader.HasRows Then
                Reader.Read()
                OfficeName = Replace(Reader("OfficeName").ToString.Trim, " ", "").ToUpper
                lLicenseKey = OfficeName.Mid(2, 1).ToUpper().Trim() & OfficeName.Mid(4, 1).ToUpper().Trim() &
                         OfficeName.Mid(6, 1).ToUpper().Trim()
            Else
                Exit Function
            End If

            Reader.Close()
            Reader = gSQLGetDataReader("EXEC xp_msver")
            Do Until Reader.Read = False
                Select Case Reader("Name")
                    Case "ProcessorCount"
                        lLicenseKey &= Reader("Internal_Value") & OfficeName.Right(1)
                    Case "ProcessorType"
                        lLicenseKey &= Reader("Internal_Value")
                    Case "PhysicalMemory"
                        lLicenseKey &= Reader("Internal_Value")
                End Select
            Loop
            Reader.Close()
            If pLicenseKey = lLicenseKey Then
                '    If gValidateOffice(OfficeName) = False Then
                '        MsgBox("The System License was Not found Or suspanded. Please contact the developer.",
                '               MsgBoxStyle.Exclamation)
                '        Exit Function
                '    End If
                SaveSetting(My.Application.Info.ProductName, "Settings", "ManualScanMode", True)
                gLicenseKeyValidated = True
                gValidateLicenseKey = True
            End If
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Function

    Public Sub gLoop_Controls_Backcolor(Obj As Object, C As Color)
        'Loop Through all controls on the form to enable or disable. Used for Add Edit functions
        Exit Sub
        Dim Cntl As Control
        Try
            For Each Cntl In Obj.Controls
                If Cntl.HasChildren Then
                    gLoop_Controls_Backcolor(Cntl, C)
                Else
                    If _
                    TypeOf Cntl Is TextBox Or TypeOf Cntl Is MaskedTextBox Or TypeOf Cntl Is CheckBox Or
                    TypeOf Cntl Is ComboBox Then
                        Cntl.BackColor = C
                        Cntl.ForeColor = Color.Red
                    End If
                End If
            Next
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Public Sub gLoop_Enable_Controls(Obj As Object, en As Boolean,
                                     Optional ByVal SkipControl1 As Control = Nothing,
                                     Optional ByVal SkipControl2 As Control = Nothing)
        'Loop Through all controls on the form to eenable or disable. Used for Add Edit functions
        Try
            Dim Cntl As Control
            For Each Cntl In Obj.Controls
                If Cntl.HasChildren Then
                    gLoop_Enable_Controls(Cntl, en, SkipControl1, SkipControl2)
                Else
                    If Not Cntl Is SkipControl1 And Not Cntl Is SkipControl2 Then
                        If _
                        TypeOf Cntl Is TextBox Or TypeOf Cntl Is MaskedTextBox Or TypeOf Cntl Is CheckBox Or
                        TypeOf Cntl Is ComboBox Then
                            Cntl.Enabled = en
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Public Sub gLoop_Clear_Controls(Obj As Object, Optional ByVal SkipControl1 As Object = Nothing,
                                    Optional ByVal SkipControl2 As Object = Nothing,
                                    Optional ByVal SkipControl3 As Object = Nothing,
                                    Optional ByVal SkipControl4 As Object = Nothing,
                                    Optional ByVal SkipControl5 As Object = Nothing,
                                    Optional ByVal SkipControl6 As Object = Nothing,
                                    Optional ByVal SkipControl7 As Object = Nothing)
        'Loop Through all controls to clear. Used for Add Edit functions
        Dim Cntl As Control
        On Error GoTo Er
        For Each Cntl In Obj.Controls
            Application.DoEvents()
            If Cntl.HasChildren Then
                gLoop_Clear_Controls(Cntl, SkipControl1, SkipControl2, SkipControl3, SkipControl4, SkipControl5,
                                     SkipControl6, SkipControl7)
            Else
                If _
                    Not Cntl Is SkipControl1 And Not Cntl Is SkipControl2 And Not Cntl Is SkipControl3 And
                    Not Cntl Is SkipControl4 And Not Cntl Is SkipControl5 And Not Cntl Is SkipControl6 And
                    Not Cntl Is SkipControl7 Then
                    If TypeOf Cntl Is TextBox Then
                        CType(Cntl, TextBox).Text = ""
                    End If
                    If TypeOf Cntl Is MaskedTextBox Then
                        CType(Cntl, MaskedTextBox).Text = ""
                    End If
                    If TypeOf Cntl Is CheckBox Then
                        CType(Cntl, CheckBox).Checked = False
                    End If
                    If TypeOf Cntl Is ComboBox Then
                        CType(Cntl, ComboBox).SelectedIndex = -1
                        If CType(Cntl, ComboBox).DropDownStyle = ComboBoxStyle.DropDown Then
                            CType(Cntl, ComboBox).Text = ""
                            CType(Cntl, ComboBox).Text = ""
                        End If
                    End If
                End If
            End If
        Next
        Exit Sub

Er:
    End Sub

    Public Sub gSearchListView(LV As ListView, SearchTextBox As TextBox,
                               Optional ByVal SearchExectly As Boolean = False,
                               Optional ByVal AlsoSearchColumn As Integer = -1, Optional SearchTag As Boolean = False)
        Dim LI As ListViewItem = Nothing
        Try
            With LV
                If .Items.Count = 0 Then
                    SearchTextBox.Text = ""
                    Exit Sub
                End If
                If SearchTextBox.Text = "" Then
                    .Items(0).Selected = True
                    .Items(0).EnsureVisible()
                    Exit Sub
                End If
                'LI = ListView1.FindItemWithText(TextBox1.Text)
                If SearchExectly Then
                    .FindItemWithText(SearchTextBox.Text)
                    If LI Is Nothing Then
                        If AlsoSearchColumn <> -1 Then
                            .FindItemWithText(SearchTextBox.Text, True, AlsoSearchColumn)
                        End If
                    End If
                Else
                    For Each LIs As ListViewItem In .Items
                        If InStr(LIs.Text, SearchTextBox.Text, CompareMethod.Text) > 0 Then
                            LI = LIs
                            Exit For
                        End If
                        If AlsoSearchColumn <> -1 Then
                            If InStr(LIs.SubItems(AlsoSearchColumn).Text, SearchTextBox.Text, CompareMethod.Text) > 0 Then
                                LI = LIs
                                Exit For
                            End If
                        End If
                        If SearchTag Then
                            If LIs.Tag?.ToString?.ToUpper?.Contains(SearchTextBox.Text.ToUpper) Then
                                LI = LIs
                                Exit For
                            End If
                        End If

                    Next
                End If
                If Not LI Is Nothing Then
                    LV.TopItem = LI
                    LI.Selected = True
                    LI.EnsureVisible()
                Else
                    'LV.Items(0).Selected = True
                    'LV.Items(0).EnsureVisible()
                    SearchTextBox.BackColor = Color.LightCoral
                    SearchTextBox.Text = SearchTextBox.Text.Mid(1, SearchTextBox.Text.Length - 1)
                    SearchTextBox.SelectionStart = SearchTextBox.Text.Length
                    RestoreSearchTextBox = SearchTextBox
                    Tmr.Interval = 250
                    Tmr.Enabled = True
                End If
            End With
        Catch ex As Exception
            log.Error(ex)
        End Try
        LI = Nothing
    End Sub

    Public Sub gLoop_Trim_Controls(Obj As Object)
        'Loop Through all controls to clear. Used for Add Edit functions
        Dim Cntl As Control
        Exit Sub
        Try
            For Each Cntl In Obj.Controls
                If Cntl.HasChildren Then
                    gLoop_Trim_Controls(Cntl)
                Else
                    If TypeOf Cntl Is TextBox Then
                        If Cntl.Enabled And CType(Cntl, TextBox).ReadOnly = False Then
                            CType(Cntl, TextBox).Text = CType(Cntl, TextBox).Text.Trim
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Public Sub gLoop_Text_PropperCase(Obj As Object, Optional ByVal Skeep1 As Object = Nothing,
                                      Optional ByVal Skeep2 As Object = Nothing,
                                      Optional ByVal Skeep3 As Object = Nothing,
                                      Optional ByVal Skeep4 As Object = Nothing,
                                      Optional ByVal Skeep5 As Object = Nothing)
        'Loop Through all controls to clear. Used for Add Edit functions
        Return
        Dim Cntl As Control
        Exit Sub
        For Each Cntl In Obj.Controls
            If Cntl.HasChildren Then
                gLoop_Text_PropperCase(Cntl, Skeep1, Skeep2, Skeep3, Skeep4, Skeep5)
            Else
                If TypeOf Cntl Is TextBox Then
                    If Cntl.Enabled And CType(Cntl, TextBox).ReadOnly = False Then
                        If _
                            (Not Cntl Is Skeep1) And (Not Cntl Is Skeep2) And (Not Cntl Is Skeep3) And
                            (Not Cntl Is Skeep4) And (Not Cntl Is Skeep5) Then
                            CType(Cntl, TextBox).Text = StrConv(CType(Cntl, TextBox).Text, VbStrConv.ProperCase)
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Public Sub gLoop_ResetErrors_Controls(ErObject As ErrorProvider, Obj As Object)
        'Loop Through all controls to Reset Errors. Used for Add Edit functions
        On Error Resume Next
        Dim Cntl As Control
        For Each Cntl In Obj.Controls
            If Cntl.HasChildren Then
                gLoop_ResetErrors_Controls(ErObject, Cntl)
            Else
                ErObject.SetError(Cntl, "")
            End If
        Next
    End Sub

    Public Sub gSetup_GotFocus(Obj As Object)
        'Loop Through all controls to clear. Used for Add Edit functions
        'Function disabled because NOT GOOD to always select text
        Exit Sub
        Dim Cntl As Control
        Try
            For Each Cntl In Obj.Controls
                If Cntl.HasChildren Then
                    gSetup_GotFocus(Cntl)
                Else
                    If TypeOf Cntl Is TextBox Or TypeOf Cntl Is MaskedTextBox Or TypeOf Cntl Is ComboBox Then
                        AddHandler Cntl.GotFocus, AddressOf SelectAll
                        AddHandler Cntl.MouseClick, AddressOf SelectAll
                    End If
                End If
            Next
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Public Sub SelectAll(sender As Object, e As EventArgs)
        Try
            sender.selectall()
        Catch ex As Exception
            log.Error(ex)
        End Try

    End Sub

    Public Function gFax(CallerForm As Form, FaxNumber As String, FaxText As String,
                         FaxAttachement As String, FromName As String,
                         Optional ByVal TreatingProviderID As Long = 0, Optional ByVal ToFaxName As String = "",
                         Optional ByVal BachProcess As Boolean = False) As Boolean
        Try
            If gWebFaxAddress = "" Then
                MsgBox("Unable to send a Fax. No Fax Server specified. Please call your System Administrator.",
                       MsgBoxStyle.Critical)
                gFax = False
                Exit Function
            End If
            gFax = True
            With frmFAX

                .TreatingProviderID = TreatingProviderID
                .txtFaxNumber.Text = FaxNumber
                .txtText.Text = FaxText
                .txtFaxAttachement.Text = FaxAttachement
                .txtFrom.Text = FromName
                .Load_Data()
                If ToFaxName <> "" Then
                    .cboTo.Text = ToFaxName
                    'gComboboxAutoComplete(.cboTo, Nothing, False)
                    If .txtFaxNumber.Text <> "" Then FaxNumber = .txtFaxNumber.Text
                End If
                If BachProcess Then
                    If FaxNumber <> "" Then .txtFaxNumber.Text = FaxNumber
                    .BatchProcess = True
                    .cmdStartFax_Click(Nothing, Nothing)
                    .Close()
                    GoTo ExitProc
                End If
                If .ShowDialog(CallerForm) = DialogResult.No Then
                    gFax = False
                End If
            End With
ExitProc:
            frmFAX.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Function
    Public SentFaxNumber As String
    Public Function gFax(CallerForm As Form, FaxNumber As String, FaxText As String,
                         FaxAttachements() As String, FromName As String,
                         Optional ByVal TreatingProviderID As Long = 0, Optional ByVal ToFaxName As String = "",
                         Optional ByVal BachProcess As Boolean = False) As Boolean
        Try
            If gWebFaxAddress = "" Then
                MsgBox("Unable to send a Fax. No Fax Server specified. Please call your System Administrator.",
                       MsgBoxStyle.Critical)
                gFax = False
                Exit Function
            End If
            gFax = True
            With frmFAX

                .TreatingProviderID = TreatingProviderID
                .txtFaxNumber.Text = FaxNumber
                .txtText.Text = FaxText
                If Not FaxAttachements Is Nothing Then
                    For Each attachement As String In FaxAttachements
                        .txtFaxAttachement.Text = .txtFaxAttachement.Text + attachement + "; "
                    Next
                    .txtFaxAttachement.Text = Left(.txtFaxAttachement.Text, Len(.txtFaxAttachement.Text) - 2)
                    If FaxAttachements.Length = 1 Then
                        .ToolStripButton3.Visible = True
                    Else
                        .ToolStripButton3.Visible = False
                        .txtFaxAttachement.Width = .txtFaxAttachement.Width + .ToolStripButton3.Width

                    End If
                End If
                .FaxAttachements = FaxAttachements
                .txtFrom.Text = FromName
                .Load_Data()
                If ToFaxName <> "" Then
                    .cboTo.Text = ToFaxName
                    'gComboboxAutoComplete(.cboTo, Nothing, False)
                    If .txtFaxNumber.Text <> "" Then FaxNumber = .txtFaxNumber.Text
                End If
                If BachProcess Then
                    If FaxNumber <> "" Then .txtFaxNumber.Text = FaxNumber
                    .BatchProcess = True
                    .cmdStartFax_Click(Nothing, Nothing)
                    .Close()
                    GoTo ExitProc
                End If
                If .ShowDialog(CallerForm) = DialogResult.No Then
                    gFax = False
                End If
            End With
ExitProc:
            frmFAX.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Function

    Public Function gEmailCheckBack(emailAddress As String) As Boolean
        Try
            Dim pattern =
                "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
            Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
            If emailAddressMatch.Success Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return False
    End Function

    Public Function gEmailCheck(strIn As String) As Boolean
        If String.IsNullOrEmpty(strIn) Then Return False
        Try
            Dim pattern =
                "^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$"
            'Regular expression object
            Dim check As New Regex(pattern, RegexOptions.IgnorePatternWhitespace)
            'boolean variable to return to calling method
            Dim valid = False
            Return check.IsMatch(strIn)
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return False
    End Function

    Public Sub gDeleteFutureAppointments(PatientID As Long)
        Try
            gSQLUpdateData(
            "DELETE FROM SCHEDULE WHERE SCHEDULEID in (SELECT ScheduleID FROM PatientProcedures WHERE PatientID = " &
            PatientID & " AND (ProcedureStatusID <> 2))")
            gSQLUpdateData(
            "UPDATE PatientProcedures set ProcedureStatusID = 0 Where PatientID = " & PatientID &
            " AND ProcedureStatusID = 1")
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Private WithEvents Cnn As SqlConnection

    Public Function gGetAssemblyDate() As String
        Dim A As Assembly = Assembly.GetExecutingAssembly()
        Dim version As String = A.GetName().Version.ToString()
        Try
            Dim buildDate As String = File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToString("MM/dd/yyyy hh:mm")
            gGetAssemblyDate = buildDate
            'gGetAssemblyDate = Replace(gGetAssemblyDate, "/", ".")
            Return gGetAssemblyDate
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return ""
    End Function

    Public Sub gSystemCulture()
        ' Put the following code before InitializeComponent()
        Try
            Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
            Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-US")
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Public Sub gSetSpreadCustomSortIndicator(SP As FpSpread)
        Dim wrkbk As SpreadView = SP.GetRootWorkbook()
        Try
            wrkbk.SetImage(SpreadView.SortAscendingImage, My.Resources.ArrowUp)
            wrkbk.SetImage(SpreadView.SortAscendingImageDisabled, My.Resources.ArrowUpDes)
            wrkbk.SetImage(SpreadView.SortDescendingImage, My.Resources.ArrowDown)
            wrkbk.SetImage(SpreadView.SortDescendingImageDisabled, My.Resources.ArrowDownDes)
            wrkbk.SetImage(SpreadView.SortUnsortedImage, My.Resources.ArrowNone)
            wrkbk.SetImage(SpreadView.SortUnsortedImageDisabled, My.Resources.ArrowNoneDes)
            wrkbk.SetImage(SpreadView.FilterActive, My.Resources.Filter)
            wrkbk.SetImage(SpreadView.FilterActiveDisabled, My.Resources.FilterDes)
            wrkbk.SetImage(SpreadView.FilterInactive, My.Resources.FilterDes)
            wrkbk.SetImage(SpreadView.FilterInactiveDisabled, My.Resources.FilterDes)
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub
    Public Function gFindComboItemByDescription(cb As ComboBox, Description As String, Autoselect As Boolean) As Long
        Dim I As Integer
        Dim Ret As Integer = -1
        If cb.Items.Count = 0 Then Exit Function
        Try
            For I = 0 To cb.Items.Count - 1
                If CType(cb.Items(I), ValueDescription).Description.Trim.ToUpper = Description.Trim.ToUpper Then
                    If Autoselect Then
                        cb.SelectedIndex = I
                        Ret = I
                    End If
                End If
            Next
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return Ret
    End Function
    Public Function gFindComboItemByText(cb As ComboBox, Description As String, Autoselect As Boolean) As Long
        Dim I As Integer
        Dim Ret As Integer = -1
        If cb.Items.Count = 0 Then Return Ret
        Try
            For I = 0 To cb.Items.Count - 1
                If CType(cb.Items(I), ValueDescription).Description.Trim.ToUpper = Description.Trim.ToUpper Then
                    If Autoselect Then
                        cb.SelectedIndex = I
                        Ret = I
                    End If
                End If
            Next
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return Ret
    End Function
    Public Function gFindComboItemByValue(cb As ComboBox, V As Double, Autoselect As Boolean) As Long
        Dim I As Integer
        If cb.Items.Count = 0 Then Exit Function
        Try
            For I = 0 To cb.Items.Count - 1
                If CType(cb.Items(I), ValueDescription).Value = V Then
                    If Autoselect Then
                        cb.SelectedIndex = I
                    End If
                    Return I
                End If
            Next
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Function
    Public Function gFindPayerbyPayerId(cb As ComboBox, PayerId As String) As Long
        Dim I As Integer = -1
        If cb.Items.Count = 0 Then Exit Function
        Try
            For I = 0 To cb.Items.Count - 1
                If CType(cb.Items(I), ValueDescription).Value1 <> "" And CType(cb.Items(I), ValueDescription).Value1 = PayerId Then
                    cb.SelectedIndex = I
                    Return I
                End If
            Next
            cb.SelectedIndex = -1
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return -1
    End Function
    Public Function gFindComboItemByValue(cb As ComboBox, V As Long) As Long
        Dim I As Integer
        Try
            For I = 0 To cb.Items.Count - 1
                If CType(cb.Items(I), ValueDescription).Value = V Then
                    Return I
                End If
            Next
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return -1
    End Function

    Public Function gNumbersOnly(pstrChar As Char, oTextBox As TextBox,
                                 Optional ByVal Decimals As Boolean = True) As Boolean
        'validate the entry for a textbox limiting it to only numeric values and the decimal point
        Try
            If (Convert.ToString(pstrChar) = "." = True) And Decimals = False Then Return True 'no decimals
            If ((Convert.ToString(pstrChar) = "." = True) And InStr(oTextBox.Text, ".") > 0) Then Return True _
            'accept only one instance of the decimal point
        If Convert.ToString(pstrChar) <> "." And pstrChar <> vbBack Then
                Return CBool(IIf(IsNumeric(pstrChar) = True, False, True)) 'check if numeric is returned
            End If
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return False 'for backspace
    End Function

    Public Function gFormatFileSize(FileSizeBytes As Long) As String
        Dim sizeTypes() As String = {" Bt", " Kb", " Mb", " Gb"}
        Dim Len As Decimal = FileSizeBytes
        Dim sizeType = 0
        Try
            Do While Len > 1024
                Len = Decimal.Round(Len / 1024, 2)
                sizeType += 1
                If sizeType >= sizeTypes.Length - 1 Then Exit Do
            Loop

            Dim Resp As String = Len.ToString & " " & sizeTypes(sizeType)
            Return Resp
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return ""
    End Function

    Public Sub ActivateLog4Net()
        Try
            Dim log4NetConfigFile = New FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Log4Net.config")
            XmlConfigurator.ConfigureAndWatch(log4NetConfigFile)

            Dim info = New DriveInfo(AppDomain.CurrentDomain.BaseDirectory)
            If Not Directory.Exists(info.Name + "\Logs\" + My.Application.Info.ProductName) Then
                Directory.CreateDirectory(info.Name + "\Logs\" + My.Application.Info.ProductName)
            End If

            Dim repository As ILoggerRepository = LogManager.GetRepository()
            Dim appenders As IAppender() = repository.GetAppenders()
            For Each appender As IAppender In (From iAppender In appenders Where TypeOf iAppender Is FileAppender)
                Dim fileAppender = TryCast(appender, FileAppender)
                If fileAppender IsNot Nothing Then
                    fileAppender.File =
                        String.Format(info.Name + "\Logs\" + My.Application.Info.ProductName + "\AppLog.log")
                    fileAppender.ActivateOptions()
                End If
            Next
        Catch generatedExceptionName As Exception
            MsgBox(generatedExceptionName.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'Public Sub gProcess_Log(ByVal Message As String, ByVal StackTrace As String, ByVal ShowDialog As Boolean)
    '    On Error Resume Next
    '    If Not IO.Directory.Exists(gAppPath & "Errors\") Then
    '        IO.Directory.CreateDirectory(gAppPath & "Errors\")
    '    End If
    '    Using _
    '        fs As IO.FileStream =
    '            New IO.FileStream(gAppPath & "Errors\Errlog.txt", IO.FileMode.Append,
    '                                     IO.FileAccess.Write)
    '        Using sr As IO.StreamWriter = New IO.StreamWriter(fs)
    '            sr.WriteLine(DateTime.Now.ToString())
    '            sr.WriteLine(Message)
    '            sr.WriteLine(StackTrace)
    '            sr.WriteLine(
    '                "================================================================================================")
    '            sr.Close()
    '            fs.Close()
    '            If ShowDialog = True Then
    '                For Each frm As Form In My.Application.OpenForms
    '                    frm.TopMost = False
    '                Next
    '                MsgBox(Message, MsgBoxStyle.Exclamation)
    '            End If
    '        End Using
    '    End Using
    'End Sub

    Public Sub gSpread_Settings(FRM As Form, SP As FpSpread,
                                RW As ReadWrite)
        Dim C As Integer
        Dim cWidth As Integer
        Try
            If RW = ReadWrite.sWrite Then
                For C = 0 To SP.ActiveSheet.ColumnCount - 1
                    If SP.ActiveSheet.Columns(C).Visible Then
                        SaveSetting(My.Application.Info.ProductName,
                                "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name) & "\" &
                                UCase("Spread_" & SP.Name), "COL" & C, SP.ActiveSheet.Columns(C).Width.ToString)
                    End If
                Next
            Else
                For C = 0 To SP.ActiveSheet.ColumnCount - 1
                    cWidth = CInt(GetSetting(My.Application.Info.ProductName,
                                         "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name) & "\" &
                                         UCase("Spread_" & SP.Name), "COL" & C, "-1"))
                    If cWidth > 0 And SP.ActiveSheet.Columns(C).Visible Then
                        SP.ActiveSheet.SetColumnWidth(C, cWidth)
                    End If
                Next
            End If
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Public Sub gListview_Settings(FRM As Form, LV As ListView, RW As ReadWrite,
                                  Optional ByVal SkipreadPosition As Boolean = False)
        On Error GoTo er
        If RW = ReadWrite.sWrite Then
            ListViewExtendedFunctions.saveSettigs(FRM, LV)
            'For C = 0 To LV.Columns.Count - 1
            '    SaveSetting(My.Application.Info.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name) & "\" & UCase("LVread_" & LV.Name), "COL" & C, LV.Columns(C).Width.ToString)
            '    SaveSetting(My.Application.Info.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name) & "\" & UCase("LVread_" & LV.Name), "COLDINDX" & C, LV.Columns(C).DisplayIndex)
            'Next
        Else
            ListViewExtendedFunctions.loadSettings(FRM, LV)
            'For C = 0 To LV.Columns.Count - 1
            '    cWidth = CInt(GetSetting(My.Application.Info.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name) & "\" & UCase("LVread_" & LV.Name), "COL" & C, "-1"))
            '    If cWidth > 0 Then
            '        LV.Columns(C).Width = cWidth
            '    End If
            '    If SkipreadPosition = False Then LV.Columns(C).DisplayIndex = CInt(GetSetting(My.Application.Info.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name) & "\" & UCase("LVread_" & LV.Name), "COLDINDX" & C, LV.Columns(C).DisplayIndex))
            'Next
        End If
er:
    End Sub

    Public Sub gWindow_Settings(FRM As Form, RW As ReadWrite,
                                Optional ByVal NoMove As Boolean = False)
        Try
            With My.Application.Info
                If RW = ReadWrite.sWrite Then
                    SaveSetting(.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name), "WindowState",
                            FRM.WindowState)
                    If FRM.WindowState = FormWindowState.Normal Then
                        SaveSetting(.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name), "Width",
                                FRM.Width.ToString)
                        SaveSetting(.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name), "Height",
                                FRM.Height.ToString)
                        SaveSetting(.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name), "Top",
                                FRM.Top.ToString)
                        SaveSetting(.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name), "Left",
                                FRM.Left.ToString)
                    End If
                Else
                    FRM.WindowState = GetSetting(.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name),
                                             "WindowState", FRM.WindowState)
                    If FRM.MinimizeBox = False And FRM.MaximizeBox = False Then
                        FRM.WindowState = FormWindowState.Normal
                    End If
                    If FRM.WindowState = FormWindowState.Normal Then
                        FRM.Width = CInt(GetSetting(.ProductName,
                                                "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name), "Width",
                                                FRM.Width.ToString))
                        FRM.Height = CInt(GetSetting(.ProductName,
                                                 "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name), "Height",
                                                 FRM.Height.ToString))
                        If NoMove = False Then _
                        FRM.Top = CInt(GetSetting(.ProductName,
                                                  "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name), "Top",
                                                  FRM.Top.ToString))
                        If NoMove = False Then _
                        FRM.Left = CInt(GetSetting(.ProductName,
                                                   "GUI\USER-" & gCurrentEmployee.EmpID & "\" & UCase(FRM.Name), "Left",
                                                   FRM.Left.ToString))
                        If FRM.Top < 0 Then FRM.Top = 0
                        If FRM.Left < 0 Then FRM.Left = 0
                    End If
                End If
            End With
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub
    Public Sub gOneSettingSave(SettingName As String, SettingValue As String)
        Try
            With My.Application.Info
                SaveSetting(.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\", SettingName, SettingValue)
            End With
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub
    Public Function gOneSettingRead(SettingName As String) As String
        Try
            With My.Application.Info
                Return GetSetting(.ProductName, "GUI\USER-" & gCurrentEmployee.EmpID & "\", SettingName, "")
            End With
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Function


    Public Function gEncrypt(InString As String) As String
        Dim c1 As Integer
        Dim NewEncryptString As String
        Dim EncryptSeed As Integer
        Dim EncryptChar As String
        Dim InSeed = 17
        Try
            NewEncryptString = ""
            EncryptSeed = InSeed
            For c1 = 1 To Len(InString)
                EncryptChar = InString.Mid(c1, 1)
                EncryptChar = Chr(Asc(EncryptChar) Xor EncryptSeed)
                EncryptSeed = EncryptSeed Xor c1
                NewEncryptString = NewEncryptString & EncryptChar
            Next
        Catch ex As Exception
            log.Error(ex)
        End Try
        gEncrypt = NewEncryptString
    End Function

    Public Function ConvertBytes(Bytes As Long) As String
        ' Converts bytes into a readable "1.44 MB", etc. string
        If Bytes >= 1073741824 Then
            Return Format(Bytes / 1024 / 1024 / 1024, "#0.00") _
                   & " GB"
        ElseIf Bytes >= 1048576 Then
            Return Format(Bytes / 1024 / 1024, "#0.00") & " MB"
        ElseIf Bytes >= 1024 Then
            Return Format(Bytes / 1024, "#0.00") & " KB"
        ElseIf Bytes > 0 And Bytes < 1024 Then
            Return Fix(Bytes) & " Bytes"
        Else
            Return "0 Bytes"
        End If
    End Function

    Private Sub Tmr_Tick(sender As Object, e As EventArgs) Handles Tmr.Tick
        Tmr.Enabled = False
        RestoreSearchTextBox.BackColor = Color.White
    End Sub

    Public Sub gUpdate_Profile_Log(PatientID As Long, AccessType As PatientLogTypes,
                                   Optional ByVal Comments As String = "", Optional ByVal ApprovedBy As String = "")
        Try
            gSQLUpdateData(
            "INSERT INTO PatientLog (AccessDT, OfficeID, PatientID, ParentLogTypeID, AccessByUserID, Comments, ApprovedBy) VALUES('" & DateTime.Now & "', " & gOfficeID & ", " & PatientID & ", " & AccessType & ", " & gCurrentEmployee.EmpID.ToString & ", '" & Comments.ToSafeSQLString() & vbCrLf & "  |  Computer: " & Environment.MachineName & "', '" & ApprovedBy.ToSafeSQLString().Left(250) & "')")
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Public Sub gSpreadActivateCell(SP As FpSpread, Optional ByVal Row As Long = 0,
                                   Optional ByVal Column As Long = 0,
                                   Optional ByVal ScrollButNotActivate As Boolean = False)
        On Error Resume Next
        With SP
            .ActiveSheetIndex = 0
            .SetViewportTopRow(0, Row)
            .SetViewportLeftColumn(0, Column)
            If ScrollButNotActivate = False Then .ActiveSheet.SetActiveCell(Row, Column)
        End With
    End Sub

    Public Sub gSpreadAutoColumnWidth(SP As FpSpread, Optional shift As Integer = 0)
        On Error Resume Next
        Dim C As Integer
        SP.SuspendLayout()
        Dim WidthHeader As Double
        Dim WidthData As Double
        Dim g As Graphics = SP.CreateGraphics
        With SP.ActiveSheet
            For C = 0 To .ColumnCount - 1
                WidthHeader = g.MeasureString(SP.ActiveSheet.ColumnHeader.Columns(C).Label.ToString, SP.Font).Width + 20
                WidthData = .Columns(C).GetPreferredWidth
                If WidthHeader < WidthData Then
                    .Columns(C).Width = WidthData + shift
                Else
                    .Columns(C).Width = WidthHeader + shift
                End If

            Next
        End With
        SP.ResumeLayout()
    End Sub

    Public Sub gSpreadAutoColumnHeight(SP As FpSpread)
        On Error Resume Next
        Dim C As Integer
        SP.SuspendLayout()
        Dim Height As Double
        Dim g As Graphics = SP.CreateGraphics
        With SP.ActiveSheet
            Height = g.MeasureString(SP.ActiveSheet.ColumnHeader.Columns(C).Label.ToString, SP.Font).Height + 2
            .ColumnHeader.Rows(0).Height = Height
            For C = 0 To .RowCount - 1
                SP.ActiveSheet.SetRowHeight(C, Height)
            Next
        End With
        SP.ResumeLayout()
    End Sub

    Public Sub sSearchComboBox_Leave(cbo As ComboBox, Optional ByVal e As EventArgs = Nothing)
        Dim iFoundIndex As Integer
        With cbo
            iFoundIndex = .FindStringExact(cbo.Text)
            'If iFoundIndex > 0 Then
            .SelectedIndex = iFoundIndex
            'Else
            'If .Items.Count > 0 Then
            '.SelectedIndex = 0
            'Else
            '.SelectedIndex = -1
            'End If
            'End If
        End With
    End Sub

    Private SaveCbo As ComboBox
    Public ResetSearchComboTimer As New System.Windows.Forms.Timer

    Public Sub sSearchComboBox_KeyUp(cbo As ComboBox, e As KeyEventArgs,
                                     Optional ByVal MustExist As Boolean = True)
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
                Case Keys.Back, Keys.Left, Keys.Right, Keys.Up, Keys.Delete, Keys.Down, Keys.Tab, Keys.Home, Keys.End,
                    Keys.Shift, Keys.ShiftKey
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

    Public Sub ResetComboSearchObjject()
        ResetSearchComboTimer.Enabled = False
        If Not SaveCbo Is Nothing Then SaveCbo.BackColor = Color.White
    End Sub

    Public Function gIsOnline() As Boolean
        Dim LFlags As InternetConnection
        On Error Resume Next
        gIsOnline = True
        gIsOnline = InternetGetConnectedState(LFlags, 0&)
    End Function

    Public Function IsColumnExist(Reader As SqlDataReader, ColumnName As String) As Boolean

        For Each row As DataRow In Reader.GetSchemaTable().Rows
            If row("ColumnName").ToString().ToUpper() = ColumnName.ToUpper() Then Return True
        Next

        'Still here? Column not found.
        Return False
    End Function
    Private Function SafeChars(QPar) As String
        QPar = Replace(QPar, "&", "%26")
        QPar = Replace(QPar, "#", "%23")
        QPar = Replace(QPar, "?", "%3F")

        QPar = Replace(QPar, "$", "%24")
        QPar = Replace(QPar, "+", "%2B")
        QPar = Replace(QPar, ",", "%2C")
        QPar = Replace(QPar, "/", "%2F")
        QPar = Replace(QPar, ":", "%3A")
        QPar = Replace(QPar, ";", "%3B")
        QPar = Replace(QPar, "=", "%3D")
        QPar = Replace(QPar, "@", "%40")
        '
        'QPar = Replace(QPar, "<", "%3C")
        'QPar = Replace(QPar, ">", "%3E")
        'QPar = Replace(QPar, "%", "%25")
        'QPar = Replace(QPar, "{", "%7B")
        'QPar = Replace(QPar, "}", "%7D")
        'QPar = Replace(QPar, "|", "%7C")
        'QPar = Replace(QPar, "\", "%5C")
        'QPar = Replace(QPar, "^", "%5E")
        'QPar = Replace(QPar, "~", "%7E")
        '
        'QPar = Replace(QPar, "[", "%5B")
        'QPar = Replace(QPar, "]", "%5D")
        'QPar = Replace(QPar, "`", "%60")
        SafeChars = QPar
    End Function

    Public Function gPing(lAddress As String) As Boolean
        Dim ping = New Ping()

        Dim pingreply As PingReply
        Try
            pingreply = ping.Send(lAddress)
            If pingreply.Status = IPStatus.Success Then
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Structure IpInfo
        Public HostName As String
        Public HostIP As String
    End Structure
    Public Function GetDriveSerialNumber(drive As String) As String
        Try
            Dim driveSerialnumber = String.Empty
            Dim pathRoot = Path.GetPathRoot(drive)
            If pathRoot Is Nothing Then
                Return driveSerialnumber
            End If
            Dim driveFixed = pathRoot.Replace("\", "")
            If driveFixed.Length = 1 Then
                driveFixed = driveFixed + ":"
            End If
            Dim wmiQuery = String.Format("SELECT VolumeSerialNumber FROM Win32_LogicalDisk Where Name = '{0}'", driveFixed)
            Using driveSearcher = New ManagementObjectSearcher(wmiQuery)
                Using driveCollection = driveSearcher.Get()
                    For Each moItem In driveCollection.Cast(Of ManagementObject)()
                        driveSerialnumber = (moItem("VolumeSerialNumber")).ToString()
                    Next
                End Using
            End Using
            Return driveSerialnumber
        Catch ex As Exception
            'handle the error your way
            Return String.Empty
        End Try
    End Function

    Public Function gGetIPInfo() As IpInfo
        gGetIPInfo = New IpInfo
        Try
            If NetworkInterface.GetIsNetworkAvailable() = False Then
                Return Nothing
            End If
            Dim hostname As String = Dns.GetHostName
            'Dim ip As IPAddress() = Dns.GetHostAddresses(hostname)
            Dim host As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName)
            For Each ip As IPAddress In host.AddressList
                If (ip.AddressFamily = AddressFamily.InterNetwork) Then
                    gGetIPInfo.HostIP = ip.ToString
                End If
            Next
            gGetIPInfo.HostName = hostname
            'gGetIPInfo.HostIP = ip(0).ToString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)

        End Try
    End Function

    Public Function gProcessPing(IpStrIn As String, DomainName As String) As String
        gProcessPing = ""
        Try

            If IpStrIn.Length > 10 Then
                Return _
                    ((Val(IpStrIn) - Asc(Mid(DomainName, 1, 1)) - Asc(Mid(DomainName, 2, 1)) -
                      Asc(Mid(DomainName, 3, 1))) / DomainName.Length).ToString
            Else
                Return _
                    UCase(Mid(DomainName, 2, 1)) &
                    (Val(IpStrIn) * DomainName.Length) + Asc(Mid(DomainName, 1, 1)) + Asc(Mid(DomainName, 2, 1)) +
                    Asc(Mid(DomainName, 3, 1)) & "-" & System.Guid.NewGuid.ToString.ToUpper
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Function

    Public Sub gShowWait(pShow As Boolean, PanelObject As Panel,
                         Optional ByVal ParentObject As Control = Nothing)
        Try
            Application.DoEvents()
            Application.DoEvents()
            Application.DoEvents()
            Application.DoEvents()
            Application.DoEvents()
            If pShow Then
                PanelObject.Left = (ParentObject.Width - PanelObject.Width) / 2
                PanelObject.Top = (ParentObject.Height - PanelObject.Height) / 2
                PanelObject.Parent = ParentObject
                PanelObject.Visible = True
                PanelObject.BringToFront()
                PanelObject.Refresh()
            Else
                PanelObject.Visible = False
            End If
            Application.DoEvents()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Public Function gSQLReadFileToArray(SourceLoc As String) As Byte()
        gSQLReadFileToArray = Nothing
        Try
            Dim Fs = New FileStream(SourceLoc, FileMode.Open, FileAccess.Read)
            Dim ImageData As Byte()
            ReDim ImageData(Fs.Length)

            'Read block of bytes from stream into the byte array
            Fs.Read(ImageData, 0, Convert.ToInt32(Fs.Length))
            'Close the File Stream
            Fs.Close()
            gSQLReadFileToArray = ImageData
        Catch ex As Exception
            MsgBox(ex.Message)
            log.Error(ex.Message, ex)
        End Try
    End Function

    Public Function gSQLWriteFileFromArray(byteData As Byte(), Ext As String, FilePrefix As String) As String
        gSQLWriteFileFromArray = ""
        Dim CheckExt
        Dim I As Integer
        Try
            Dim ArraySize = New Integer()
            Dim DestinationLoc As String = Path.GetTempFileName.ToString
            Dim LStr = ""
            For I = 0 To 100
                CheckExt = CheckExt & Chr(byteData(I))
            Next
            If InStr(CheckExt.ToString.ToUpper, "%PDF") Then
                Ext = "PDF"
            Else
                Ext = "JPG"
            End If
            DestinationLoc = DestinationLoc.Replace("tmp", Ext)
            If FilePrefix <> "" Then
                FilePrefix = String.Concat(FilePrefix.Split(Path.GetInvalidFileNameChars()))
                FilePrefix = FilePrefix.Replace(".", "")
                FilePrefix = FilePrefix.Replace(",", " ")
                Dim FileName As String = Path.GetFileName(DestinationLoc)
                Dim FilePath As String = Path.GetDirectoryName(DestinationLoc)
                DestinationLoc = Path.Combine(FilePath, FilePrefix + "_" + FileName)
            End If


            If File.Exists(DestinationLoc) Then

                Try
                    File.Delete(DestinationLoc)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    log.Error(ex.Message, ex)
                End Try

            End If
            ArraySize = byteData.GetUpperBound(0)
            ' Write the Blob data fetched from database to the filesystem at
            ' the destination location
            Dim fs1 = New FileStream(DestinationLoc, FileMode.OpenOrCreate, FileAccess.Write)
            fs1.Write(byteData, 0, ArraySize)
            fs1.Close()
            gSQLWriteFileFromArray = DestinationLoc
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Function

    Public Sub gHighlightListviewItem(LV As ListView, Optional ByVal NoForeColor As Boolean = False,
                                      Optional ByVal NoBackColor As Boolean = False, Optional bcColor As Color = Nothing, Optional fColor As Color = Nothing)
        If bcColor = Nothing Then bcColor = SystemColors.MenuHighlight
        If fColor = Nothing Then fColor = SystemColors.HighlightText

        LV.SuspendLayout()
        Try
            Dim listviewItem As ListViewItem
            For Each listviewItem In LV.Items
                If NoBackColor = False Then listviewItem.BackColor = Nothing
                If NoForeColor = False Then listviewItem.ForeColor = Nothing
            Next
            For Each listviewItem In LV.SelectedItems
                If NoBackColor = False Then listviewItem.BackColor = bcColor
                If NoForeColor = False Then listviewItem.ForeColor = fColor
            Next
        Catch ex As Exception
            log.Error(ex)
        End Try
        LV.ResumeLayout()
    End Sub

    Public Function gGetEmbeddedResourceSound(strName As String) As Stream
        Try
            Return Assembly.GetExecutingAssembly.GetManifestResourceStream(GetResourceName(strName))
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return Nothing
    End Function

    Public Function gGetEmbeddedResourceBitmap(strName As String) As Bitmap
        Try
            Return New Bitmap(Assembly.GetExecutingAssembly.GetManifestResourceStream(GetResourceName(strName)))
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return Nothing
    End Function

    Private Function GetResourceName(strName As String) As String
        Dim Ret As String
        Try
            For Each Ret In Assembly.GetExecutingAssembly.GetManifestResourceNames()
                If InStr(Ret, strName, CompareMethod.Text) Then
                    Return Ret
                End If
            Next
        Catch ex As Exception
            log.Error(ex)
        End Try
        Return ""
    End Function

    Public Sub gSetListItemColor(LI As ListViewItem, C As Color)
        Try
            LI.UseItemStyleForSubItems = False
            Dim SI As ListViewItem.ListViewSubItem
            LI.BackColor = C
            For Each SI In LI.SubItems
                SI.BackColor = C
            Next
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Public Sub gSetListItemForeColor(LI As ListViewItem, C As Color)
        Try
            LI.UseItemStyleForSubItems = False
            Dim SI As ListViewItem.ListViewSubItem
            For Each SI In LI.SubItems
                SI.ForeColor = C
            Next
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Public Sub gComboboxAutoComplete(cbo As ComboBox, e As KeyEventArgs,
                                     Optional ByVal MastExist As Boolean = True)
        ' Call this from your form passing in the name
        ' of your combobox and the event arg:
        ' AutoComplete(cboState, e)
        Dim iIndex As Integer
        Dim sActual As String
        Dim sFound As String
        Dim bMatchFound As Boolean
        Dim newtext = cbo.Text & Chr(e.KeyValue)
        'check if the text is blank or not, if not then only proceed
        If Not cbo.Text = "" Then 'if the text is not blank then only proceed
            Try
                ' If backspace then remove the last character
                ' that was typed in and try to find
                ' a match. note that the selected text from the
                ' last character typed in to the
                ' end of the combo text field will also be deleted.
                If Not e Is Nothing Then

                    If e.KeyCode = Keys.Back Then
                        cbo.Text = cbo.Text.Mid(1, Len(cbo.Text) - 1)
                    End If

                    ' Do nothing for some keys such as navigation keys...
                    If ((e.KeyCode = Keys.Left) Or
                    (e.KeyCode = Keys.Right) Or
                    (e.KeyCode = 16) Or
                    (e.KeyCode = Keys.Shift) Or
                    (e.KeyCode = Keys.Alt) Or
                    (e.KeyCode = Keys.Control) Or
                    (e.KeyCode = Keys.Escape) Or
                    (e.KeyCode = Keys.CapsLock) Or
                    (e.KeyCode = Keys.Tab) Or
                    (e.KeyCode = Keys.Up) Or
                    (e.KeyCode = Keys.Down) Or
                    (e.KeyCode = Keys.PageUp) Or
                    (e.KeyCode = Keys.PageDown) Or
                    (e.KeyCode = Keys.Home) Or
                    (e.KeyCode = Keys.End)) Then
                        Return
                    End If
                End If

                Do
                    ' Store the actual text that has been typed.
                    sActual = cbo.Text
                    ' Find the first match for the typed value.
                    iIndex = cbo.FindString(sActual)
                    ' Get the text of the first match.
                    ' if index > -1 then a match was found.

                    If (iIndex > -1) Then '** FOUND SECTION **
                        sFound = cbo.Items(iIndex).ToString()
                        ' Select this item from the list.
                        cbo.SelectedIndex = iIndex
                        cbo.SelectionStart = sActual.Length
                        cbo.SelectionLength = sFound.Length
                        bMatchFound = True
                    Else '** NOT FOUND SECTION **

                        If sActual.Length = 1 Or sActual.Length = 0 Then
                            If MastExist Then
                                cbo.SelectedIndex = 0
                                cbo.SelectionStart = 0
                                cbo.SelectionLength = Len(cbo.Text)
                            End If
                            bMatchFound = True
                        Else
                            If MastExist Then
                                cbo.SelectionStart = sActual.Length - 1
                                cbo.SelectionLength = sActual.Length - 1
                                cbo.Text = cbo.Text.Mid(1, Len(cbo.Text) - 1)
                                bMatchFound = False
                            Else
                                bMatchFound = True
                            End If
                        End If

                    End If

                Loop Until bMatchFound
            Catch ex As Exception
                log.Error(ex)
            End Try

        End If
    End Sub

    Public Sub Track_Noshows()
        Dim SQL As String
        Try
            If gDebugMode Then log.Debug("Track_Noshows Started on " & Now)
            SQL = "INSERT INTO PatientNoShow (ProcedureID, DiagID, PatientID, ScheduleDateTime) "
            SQL = SQL &
              " SELECT PatientProcedures.ProcID, PatientProcedures.DiagID, PatientProcedures.PatientID, Schedule.ScheduleDateTime"
            SQL = SQL & " FROM PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID "
            SQL = SQL & " WHERE (DATEDIFF(hh, Schedule.ScheduleDateTime, GETDATE()) > " & gNoShowHours &
              ") AND (PatientProcedures.ProcedureStatusID = 1) AND (NOT EXISTS(SELECT * FROM PatientNoShow WHERE PatientID = PatientProcedures.PatientID AND ScheduleDateTime = Schedule.ScheduleDateTime AND ProcID = PatientProcedures.ProcID)) "
            gSQLUpdateData(SQL)
            SQL =
            "Update Schedule set  ShowUpDatetime = null where ShowUpDatetime IS NOT NULL and DATEDIFF(hh, ShowUpDatetime, GETDATE()) > " &
            gNoShowHours
            gSQLUpdateData(SQL)
            SQL =
            "Update PatientProcedures set PatientSignature=null, TechSignature = null FROM PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID where ProcedureStatusID=1 and DATEDIFF(hh, ShowUpDatetime, GETDATE()) >" &
            gNoShowHours
            gSQLUpdateData(SQL)
            SQL =
            "Update Schedule set  ShowUpDatetime = null where ShowUpDatetime IS NOT NULL and DATEDIFF(hh, ShowUpDatetime, GETDATE()) > " &
            gNoShowHours
            gSQLUpdateData(SQL)
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Public Structure SupperApproval
        Public SupervisorID As Long
        Public SupervisorName As String
    End Structure

    Public Function Validate_Supervisor(ByVal UIDControl As TextBox, ByVal PwdControl As TextBox) As SupperApproval
        Dim SQl As String
        Dim Reader As SqlClient.SqlDataReader
        Validate_Supervisor.SupervisorName = ""
        Validate_Supervisor.SupervisorID = 0

        Try
            If UIDControl.Text = "" Then
                MsgBox("The Supervisor User Name is required.", MsgBoxStyle.Exclamation)
                UIDControl.Focus()
                Exit Function
            End If
            If PwdControl.Text = "" Then
                MsgBox("The Supervisor  Password is required.", MsgBoxStyle.Exclamation)
                PwdControl.Focus()
                Exit Function
            End If
            SQl =
            "Select Fname, Lname , Employees.EmpID, Password, PositionID From Employees inner join EmployeeOffice on Employees.EmpID=EmployeeOffice.EmpID inner join Offices on Offices.OfficeID=EmployeeOffice.OfficeID Where Employees.ActiveInd=1 and UID='" &
            UIDControl.Text.ToSafeSQLString() & "' AND EmployeeOffice.OfficeID=" & gOfficeID
            Reader = gSQLGetDataReader(SQl)
            If Reader Is Nothing Then Exit Function
            If Reader.Read = False Then
                MsgBox("Invalid Security Information.", MsgBoxStyle.Exclamation)
                UIDControl.Focus()
                Reader.Close()
                Reader.Dispose()
                Exit Function
            Else
                If PwdControl.Text <> gEncrypt(Reader("Password").ToString) Then
                    MsgBox("Invalid Security Information.", MsgBoxStyle.Exclamation)
                    UIDControl.Focus()
                    Reader.Close()
                    Reader.Dispose()
                    Exit Function
                End If
                If Val(Reader("PositionID").ToString) > 3 Then
                    MsgBox("Not authorized to approve this transaction.", MsgBoxStyle.Exclamation)
                    UIDControl.Focus()
                    Reader.Close()
                    Reader.Dispose()
                    Exit Function
                End If
                Validate_Supervisor.SupervisorName = Reader("Fname").ToString.Trim & " " & Reader("Lname").ToString.Trim
                Validate_Supervisor.SupervisorID = Val(Reader("EmpID").ToString)

                Reader.Close()
                Reader.Dispose()
            End If
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Function

    Public Sub Clear_Web_Document(WebViewer As WebBrowser)
        Try
            If WebViewer.Tag <> "" Then
                WebViewer.NavigateURL("about:blank")
                WebViewer.Tag = ""
            End If
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

    Public Sub gCustomizeToolStrip(TS As ToolStrip, pForm As Form)
        Try
            If gCurrentEmployee.PositionID > 3 Then Exit Sub
            frmToolStripCustomizer.LoadToolStrip(TS)
            frmToolStripCustomizer.ShowDialog(pForm)
            frmToolStripCustomizer.Dispose()
        Catch ex As Exception
            log.Error(ex)
        End Try
    End Sub

End Module