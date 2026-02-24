Imports System.Reflection
Imports log4net
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My

    ' The following events are available for MyApplication:
    '
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active.
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        ' Catch an unhandled exception.
        Private log As ILog

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup

            'gAppSettings.LoadAll()
            'gAppSettings.GetValueInt("OfficeID333") = 11212

            'gAppSettings.SaveAll()

            'gMultiOfficeMode = gAppConfigDB.GetValueBool("MultiOfficeMode", Nothing)
            'gAppConfigDB.SaveSetting("MultiOfficeMode", 1)

            gMultiOfficeMode = gAppConfig.GetValueBool("MultiOfficeMode", Nothing)
            Dim processNames As Process() = Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName)
            If gMultiOfficeMode = False And processNames.Length > 1 Then
                MsgBox("Another instance of eMedicalOffice is already running." & vbCrLf & vbCrLf & "Only one instance of eMedicalOffice allowed in the current conconfiguration.", MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal, "Oops")
                Dim handle As IntPtr
                For Each p As Process In processNames
                    If p.MainWindowHandle <> 0 Then
                        handle = p.MainWindowHandle
                        Exit For
                    End If
                Next
                SetForegroundWindow(handle)
                If IsIconic(handle) Then
                    ShowWindow(handle, SW_RESTORE)
                End If
                End
            End If
            ActivateLog4Net()
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
            log.Debug("Starting...")
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Dim msg As String
            Dim EmailMsg As String
            msg &= "Unexpected application error." & vbCrLf
            msg &= "Please inform the developer company about this error." & vbCrLf & vbCrLf
            msg &= "Information for developer:" & vbCrLf
            msg &= e.Exception.Message
            log.Error(e)
            MsgBox(msg, MessageBoxIcon.Error, "Oops...")
            EmailMsg = e.Exception.Message & vbCrLf
            If Not e.Exception.InnerException Is Nothing Then
                EmailMsg &= e.Exception.InnerException.Message & vbCrLf
            End If
            EmailMsg &= e.Exception.StackTrace.ToString & vbCrLf
            If (e.Exception.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", My.Application.Info.Version.ToString() & vbCrLf & gOfficeName & vbCrLf & Now & vbCrLf & vbCrLf & EmailMsg, Nothing, Net.Mail.MailPriority.High, False, True)
            End If
            e.ExitApplication = False
        End Sub

        Private Sub NetworkChange_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
            If e.IsNetworkAvailable = False Then
                Dim msg As String
                If e.IsNetworkAvailable = False Then
                    msg &= "Network Communication Error Detected." & vbCrLf
                    msg &= "The Server Connection Lost!" & vbCrLf & vbCrLf
                    msg &= "The eMedicalOffice will not crash and will try to reestablish network connection." & vbCrLf & vbCrLf
                    msg &= "Please inform yout IT specialist about this status." & vbCrLf & vbCrLf
                    log.Error("The network connection lost!")
                    MsgBox(msg, MessageBoxIcon.Error, "Network Error")
                End If
            End If
        End Sub

    End Class

End Namespace