Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Security.AccessControl
Imports System.Threading
Imports log4net

Module IOModule
    ' A system restart is not required.
    Private Const RmRebootReasonNone As Integer = 0
    ' maximum character count of application friendly name.
    Private Const CCH_RM_MAX_APP_NAME As Integer = 255
    ' maximum character count of service short name.
    Private Const CCH_RM_MAX_SVC_NAME As Integer = 63
    Private Delegate Sub AddTreeNode(node As TreeNode)
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    ''' <summary>
    ''' Uniquely identifies a process by its PID and the time the process began. 
    ''' An array of RM_UNIQUE_PROCESS structures can be passed
    ''' to the RmRegisterResources function.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)>
    Private Structure RM_UNIQUE_PROCESS
        ' The product identifier (PID).
        Public dwProcessId As Integer
        ' The creation time of the process.
        Public ProcessStartTime As System.Runtime.InteropServices.ComTypes.FILETIME
    End Structure

    ''' <summary>
    ''' Describes an application that is to be registered with the Restart Manager.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Private Structure RM_PROCESS_INFO
        ' Contains an RM_UNIQUE_PROCESS structure that uniquely identifies the
        ' application by its PID and the time the process began.
        Public Process As RM_UNIQUE_PROCESS
        ' If the process is a service, this parameter returns the 
        ' long name for the service.
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=CCH_RM_MAX_APP_NAME + 1)>
        Public strAppName As String
        ' If the process is a service, this is the short name for the service.
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=CCH_RM_MAX_SVC_NAME + 1)>
        Public strServiceShortName As String
        ' Contains an RM_APP_TYPE enumeration value.
        Public ApplicationType As RM_APP_TYPE
        ' Contains a bit mask that describes the current status of the application.
        Public AppStatus As UInteger
        ' Contains the Terminal Services session ID of the process.
        Public TSSessionId As UInteger
        ' TRUE if the application can be restarted by the 
        ' Restart Manager; otherwise, FALSE.
        <MarshalAs(UnmanagedType.Bool)>
        Public bRestartable As Boolean
    End Structure

    ''' <summary>
    ''' Specifies the type of application that is described by
    ''' the RM_PROCESS_INFO structure.
    ''' </summary>
    Private Enum RM_APP_TYPE
        ' The application cannot be classified as any other type.
        RmUnknownApp = 0
        ' A Windows application run as a stand-alone process that
        ' displays a top-level window.
        RmMainWindow = 1
        ' A Windows application that does not run as a stand-alone
        ' process and does not display a top-level window.
        RmOtherWindow = 2
        ' The application is a Windows service.
        RmService = 3
        ' The application is Windows Explorer.
        RmExplorer = 4
        ' The application is a stand-alone console application.
        RmConsole = 5
        ' A system restart is required to complete the installation because
        ' a process cannot be shut down.
        RmCritical = 1000
    End Enum

    ''' <summary>
    ''' Registers resources to a Restart Manager session. The Restart Manager uses 
    ''' the list of resources registered with the session to determine which 
    ''' applications and services must be shut down and restarted. Resources can be 
    ''' identified by filenames, service short names, or RM_UNIQUE_PROCESS structures
    ''' that describe running applications.
    ''' </summary>
    ''' <param name="pSessionHandle">
    ''' A handle to an existing Restart Manager session.
    ''' </param>
    ''' <param name="nFiles">The number of files being registered</param>
    ''' <param name="rgsFilenames">
    ''' An array of null-terminated strings of full filename paths.
    ''' </param>
    ''' <param name="nApplications">The number of processes being registered</param>
    ''' <param name="rgApplications">An array of RM_UNIQUE_PROCESS structures</param>
    ''' <param name="nServices">The number of services to be registered</param>
    ''' <param name="rgsServiceNames">
    ''' An array of null-terminated strings of service short names.
    ''' </param>
    ''' <returns>The function can return one of the system error codes that 
    ''' are defined in Winerror.h
    ''' </returns>
    <DllImport("rstrtmgr.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Function RmRegisterResources(pSessionHandle As UInteger, nFiles As UInt32, rgsFilenames As String(), nApplications As UInt32, <[In]> rgApplications As RM_UNIQUE_PROCESS(), nServices As UInt32, rgsServiceNames As String()) As Integer
    End Function

    ''' <summary>
    ''' Starts a new Restart Manager session. A maximum of 64 Restart Manager 
    ''' sessions per user session can be open on the system at the same time. 
    ''' When this function starts a session, it returns a session handle and 
    ''' session key that can be used in subsequent calls to the Restart Manager API.
    ''' </summary>
    ''' <param name="pSessionHandle">
    ''' A pointer to the handle of a Restart Manager session.
    ''' </param>
    ''' <param name="dwSessionFlags">Reserved. This parameter should be 0.</param>
    ''' <param name="strSessionKey">
    ''' A null-terminated string that contains the session key to the new session.
    ''' </param>
    ''' <returns></returns>
    <DllImport("rstrtmgr.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Function RmStartSession(ByRef pSessionHandle As UInteger, dwSessionFlags As Integer, strSessionKey As String) As Integer
    End Function

    ''' <summary>
    ''' Ends the Restart Manager session. This function should be called by the 
    ''' primary installer that has previously started the session by calling the 
    ''' RmStartSession function. The RmEndSession function can be called by a 
    ''' secondary installer that is joined to the session once no more resources 
    ''' need to be registered by the secondary installer.
    ''' </summary>
    ''' <param name="pSessionHandle">
    ''' A handle to an existing Restart Manager session.
    ''' </param>
    ''' <returns>
    ''' The function can return one of the system error codes
    ''' that are defined in Winerror.h.
    ''' </returns>
    <DllImport("rstrtmgr.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Function RmEndSession(pSessionHandle As UInteger) As Integer
    End Function

    ''' <summary>
    ''' Gets a list of all applications and services that are currently using 
    ''' resources that have been registered with the Restart Manager session.
    ''' </summary>
    ''' <param name="dwSessionHandle">
    ''' A handle to an existing Restart Manager session.
    ''' </param>
    ''' <param name="pnProcInfoNeeded">A pointer to an array size necessary to 
    ''' receive RM_PROCESS_INFO structures required to return information for 
    ''' all affected applications and services.
    ''' </param>
    ''' <param name="pnProcInfo">
    ''' A pointer to the total number of RM_PROCESS_INFO structures in an array
    ''' and number of structures filled.
    ''' </param>
    ''' <param name="rgAffectedApps">
    ''' An array of RM_PROCESS_INFO structures that list the applications and 
    ''' services using resources that have been registered with the session.
    ''' </param>
    ''' <param name="lpdwRebootReasons">
    ''' Pointer to location that receives a value of the RM_REBOOT_REASON
    ''' enumeration that describes the reason a system restart is needed.
    ''' </param>
    ''' <returns></returns>
    <DllImport("rstrtmgr.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Function RmGetList(dwSessionHandle As UInteger, ByRef pnProcInfoNeeded As UInteger, ByRef pnProcInfo As UInteger, <[In], Out> rgAffectedApps As RM_PROCESS_INFO(), ByRef lpdwRebootReasons As UInteger) As Integer
    End Function

    ' Return a list of processes that have locks on a file.
    Public Function FindLockers(filename As String) As List(Of Process)
        ' Start a new Restart Manager session.
        Dim session_handle As UInteger
        Dim session_key As String = Guid.NewGuid().ToString()
        Dim result As Integer = RmStartSession(session_handle, 0, session_key)
        If result <> 0 Then
            Throw New Exception("Error " + result + " starting a Restart Manager session.")
        End If

        Dim processes As New List(Of Process)()
        Try
            Const ERROR_MORE_DATA As Integer = 234
            Dim pnProcInfoNeeded As UInteger = 0, num_procs As UInteger = 0, lpdwRebootReasons As UInteger = RmRebootReasonNone
            Dim resources As String() = New String() {filename}
            result = RmRegisterResources(session_handle, CUInt(resources.Length), resources, 0, Nothing, 0,
                                         Nothing)
            If result <> 0 Then
                Throw New Exception("Could not register resource.")
            End If

            ' There's a race around condition here. The first call to RmGetList()
            ' returns the total number of process. However, when we call RmGetList()
            ' again to get the actual processes this number may have increased.
            result = RmGetList(session_handle, pnProcInfoNeeded, num_procs, Nothing, lpdwRebootReasons)
            If result = ERROR_MORE_DATA Then
                ' Create an array to store the process results.
                Dim processInfo As RM_PROCESS_INFO() = New RM_PROCESS_INFO(pnProcInfoNeeded - 1) {}
                num_procs = pnProcInfoNeeded

                ' Get the list.
                result = RmGetList(session_handle, pnProcInfoNeeded, num_procs, processInfo, lpdwRebootReasons)
                If result <> 0 Then
                    Throw New Exception("Error " + result + " listing lock processes")
                End If

                ' Add the results to the list.
                For i As Integer = 0 To num_procs - 1
                    Try
                        processes.Add(Process.GetProcessById(processInfo(i).Process.dwProcessId))
                        ' Catch the error in case the process is no longer running.
                    Catch generatedExceptionName As ArgumentException
                    End Try
                Next
            ElseIf result <> 0 Then
                Throw New Exception("Error " + result + " getting the size of the result.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            RmEndSession(session_handle)
        End Try

        Return processes
    End Function
    Public Function KillProcess(proc As Process) As Boolean
        Try
            If proc.ProcessName = Process.GetCurrentProcess().ProcessName Then Return False
            For Each process As Process In Process.GetProcesses().Where(Function(p) p.ProcessName.Contains(proc.ProcessName))
                Try
                    If process.ProcessName = Process.GetCurrentProcess().ProcessName Then Continue For
                    process.Kill()
                    process.WaitForExit(1000)
                Catch ex As Exception
                End Try
            Next
            Try
                proc.Kill()
                proc.WaitForExit(1000)
            Catch ex As Exception
            End Try

            Return True
        Catch ex As Exception
            log.Error(ex.Message, ex)
        End Try
        Return False
    End Function
    Public Function gDeleteFile(fName As String) As Boolean
        Dim rretryCount As Integer
        Do Until rretryCount >= 5
            Try
                File.Delete(fName)
                Return True
            Catch ex As Exception
                rretryCount = rretryCount + 1
                log.Error(ex.Message, ex)
            End Try
            Thread.Sleep(1000)
        Loop
        Return False
    End Function
    Public Function gDeleteAllFiles(folderSpec As String, Optional ByVal pattern As String = "*.*",
                                    Optional killBadProcess As Boolean = True, Optional silent As Boolean = False) _
        As Boolean
        Dim status As Boolean
        Dim retryCount = 0
        Dim currentFile As String
        If Not Directory.Exists(folderSpec) Then
            status = False
            log.Error("DirectoryNotFoundException " & folderSpec)
        Else
            Do Until retryCount >= 5
                retryCount = retryCount + 1
                Try
                    Dim names As String() = Directory.GetFiles(folderSpec, pattern)
                    For Each file As String In names
                        currentFile = file
                        IO.File.Delete(file)
                    Next
                    Return True
                Catch ex As Exception
                    Dim lockers As List(Of Process) = FindLockers(currentFile)
                    Dim msg As String
                    If lockers.Count > 0 Then
                        msg = "Unable to delete file: " & currentFile & "." & vbCrLf & "The file it is locked by:" &
                              vbCrLf & vbCrLf
                        For Each item As Process In lockers
                            msg = msg & item.ProcessName & vbCrLf
                            If killBadProcess Then KillProcess(item)
                        Next
                    Else
                        msg = ex.Message
                    End If
                    If silent = False Then
                        MsgBox(msg, MsgBoxStyle.Critical)
                    End If
                    log.Error("Retry: " & retryCount & "  " & ex.Message & vbCrLf & msg, ex)
                    status = False
                End Try
            Loop
        End If
        Return status
    End Function

    Public Function gFixFileName(fname As String) As String
        fname = Replace(fname, "\", "-")
        fname = Replace(fname, "/", "-")
        fname = Replace(fname, ":", " ")
        fname = Replace(fname, "?", " ")
        fname = Replace(fname, "*", " ")
        fname = Replace(fname, "<", " ")
        fname = Replace(fname, "<", " ")
        fname = Replace(fname, "#", " ")
        Return fname
    End Function

    Private Function GetEncoder(format As ImageFormat) _
        As ImageCodecInfo

        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing
    End Function

    Public Function gSaveImageToFile(img As Image, fName As String, Optional ByVal Quality As Long = 95) _
        As Boolean
        Try
            Dim eps = New EncoderParameters(1)
            eps.Param(0) = New EncoderParameter(Encoder.Quality, Quality)
            Dim ici As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
            Try
                img.Save(fName, ici, eps)
                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                log.Error("Error Saving File", ex)
                Return False
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Function
    Public Function gNumeric2Bytes(b As Double) As String
        Dim bSize(8) As String
        Dim i As Integer
        Dim ret As String = ""
        bSize(0) = "Bytes"
        bSize(1) = "KB" 'Kilobytes
        bSize(2) = "MB" 'Megabytes
        bSize(3) = "GB" 'Gigabytes
        bSize(4) = "TB" 'Terabytes
        bSize(5) = "PB" 'Petabytes
        bSize(6) = "EB" 'Exabytes
        bSize(7) = "ZB" 'Zettabytes
        bSize(8) = "YB" 'Yottabytes

        b = CDbl(b) ' Make sure var is a Double (not just
        ' variant)
        For i = UBound(bSize) To 0 Step -1
            If b >= (1024 ^ i) Then
                ret = ThreeNonZeroDigits(b / (1024 ^ i)) & " " & bSize(i)
                Exit For
            End If
        Next
        Return ret
    End Function
    Public Function gCanRead(path As String) As Boolean
        Dim readAllow = False
        Dim readDeny = False
        If path = "" Then Return False
        Dim accessControlList = Directory.GetAccessControl(path)
        If accessControlList Is Nothing Then
            Return False
        End If
        Dim accessRules = accessControlList.GetAccessRules(True, True, GetType(System.Security.Principal.SecurityIdentifier))
        If accessRules Is Nothing Then
            Return False
        End If

        For Each rule As FileSystemAccessRule In accessRules
            If (FileSystemRights.Read And rule.FileSystemRights) <> FileSystemRights.Read Then
                Continue For
            End If

            If rule.AccessControlType = AccessControlType.Allow Then
                readAllow = True
            ElseIf rule.AccessControlType = AccessControlType.Deny Then
                readDeny = True
            End If
        Next

        Return readAllow AndAlso Not readDeny
    End Function
    Private Function ThreeNonZeroDigits(value As Double) _
        As String
        If value >= 100 Then
            ' No digits after the decimal.
            Return Format$(CInt(value))
        ElseIf value >= 10 Then
            ' One digit after the decimal.
            Return Format$(value, "0.0")
        Else
            ' Two digits after the decimal.
            Return Format$(value, "0.00")
        End If
    End Function

    Public Declare Function WNetConnectionDialog Lib "mpr.dll" (hwnd As Integer, dwType As Integer) As Integer
    Public Sub DeleteTempFiles(Optional donotprocess = True)
        On Error Resume Next
        If donotprocess Then Exit Sub
        Dim MYTEMPFOLDER As String = System.IO.Path.GetTempPath
        For Each file As IO.FileInfo In New IO.DirectoryInfo(MYTEMPFOLDER).GetFiles("*.*")
            file.Delete()
        Next
        For Each folder As IO.DirectoryInfo In New IO.DirectoryInfo(MYTEMPFOLDER).GetDirectories("*.*")
            folder.Delete()
        Next

    End Sub
End Module
