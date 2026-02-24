Imports System.IO
Imports System.Threading.Tasks

Module AutoUpdateModule
    Public CopyFrom As String
    Public CopyTo As String
    Public OldVersion As String
    Public NewVersion As String
    Public RunOnce As String
    Public SysAdminUID As String
    Public SysAdminPWD As String
    Public gAppPath As String
    Public gAppConfig As AppConfig = New AppConfig()
    Private WithEvents T As New Timers.Timer
    Public Function RightVB6(ByVal SomeStr As String, ByVal pLen As Integer) As String
        If pLen > SomeStr.Length Then
            RightVB6 = SomeStr
        Else
            RightVB6 = SomeStr.Substring(SomeStr.Length - pLen, pLen)
        End If

    End Function
    Public Sub gProcess_Log(ByVal Message As String, ByVal StackTrace As String, ByVal ShowDialog As Boolean)
        On Error Resume Next
        If Not System.IO.Directory.Exists(gAppPath & "Errors\") Then
            System.IO.Directory.CreateDirectory(gAppPath & "Errors\")
        End If
        Using fs As System.IO.FileStream = New System.IO.FileStream(gAppPath & "Errors\Errlog.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write)
            Using sr As System.IO.StreamWriter = New System.IO.StreamWriter(fs)
                sr.WriteLine(DateTime.Now.ToString())
                sr.WriteLine(Message)
                sr.WriteLine(StackTrace)
                sr.WriteLine("================================================================================================")
                sr.Close()
                fs.Close()
                If ShowDialog = True Then
                    For Each frm As Form In My.Application.OpenForms
                        frm.TopMost = False
                    Next
                    MsgBox(Message, MsgBoxStyle.Exclamation)
                End If
            End Using
        End Using
    End Sub
    Public Function StartProcess() As Boolean
        frmMain.lblProgress.Text = "Processing Update"
        Dim TryCount As Integer = 0

        TryCount = 0
        Dim TempFileName As String = Path.GetTempFileName()
        Dim success As Boolean
        Do Until success = True

            Application.DoEvents()
            Try
                TryCount = TryCount + 1
                Dim fi1 As FileVersionInfo = FileVersionInfo.GetVersionInfo(CopyFrom)
                Dim finfo1 As FileInfo = New FileInfo(CopyFrom)
                frmMain.lblProgress.Text = "Download from server. " & finfo1.Length / 1024 & "KB. Please wait...  #" & TryCount
                frmMain.lblProgress.Refresh()
                File.Copy(CopyFrom, TempFileName, True)

                Dim fi2 As FileVersionInfo = FileVersionInfo.GetVersionInfo(TempFileName)
                Dim finfo2 As FileInfo = New FileInfo(TempFileName)
                frmMain.lblProgress.Text = "Validate download. Please wait... #" & TryCount
                frmMain.lblProgress.Refresh()
                ' Verify that file is not corrupted
                If fi1.ProductName = fi2.ProductName And
                    fi1.FileMajorPart = fi2.FileMajorPart And
                    fi1.FileMinorPart = fi2.FileMinorPart And
                    fi1.FileBuildPart = fi2.FileBuildPart And
                    fi1.FilePrivatePart = fi2.FilePrivatePart And
                    fi1.FileDescription = fi2.FileDescription And
                    finfo1.Length = finfo2.Length Then
                    frmMain.lblProgress.Text = "Delete destination file. Please wait... #" & TryCount
                    frmMain.lblProgress.Refresh()
                    If KillProcess() = False Then
                        Return False
                    End If
                    frmMain.lblProgress.Text = "Copy to destination. Please wait... #" & TryCount
                    frmMain.lblProgress.Refresh()
                    File.Copy(TempFileName, CopyTo, True)
                    frmMain.lblProgress.Text = "Validate application file. Please wait... #" & TryCount
                    frmMain.lblProgress.Refresh()

                    fi2 = FileVersionInfo.GetVersionInfo(CopyTo)
                    finfo2 = New FileInfo(CopyTo)
                    If fi1.ProductName = fi2.ProductName And
                        fi1.FileMajorPart = fi2.FileMajorPart And
                        fi1.FileMinorPart = fi2.FileMinorPart And
                        fi1.FileBuildPart = fi2.FileBuildPart And
                        fi1.FilePrivatePart = fi2.FilePrivatePart And
                        fi1.FileDescription = fi2.FileDescription And
                        finfo1.Length = finfo2.Length Then
                        fi2 = Nothing
                        KillTempFile(TempFileName)
                        success = True
                    Else
                        Threading.Thread.Sleep(1000)
                        If TryCount >= 20 Then
                            MsgBox("Unable to process autoupdate." & vbCrLf & "Attempt to copy file:" & vbCrLf & TempFileName & vbCrLf & "to location: " & vbCrLf & CopyTo & vbCrLf & " failed.")
                            gProcess_Log("Unable to process autoupdate." & vbCrLf & "Attempt to copy file:" & vbCrLf & TempFileName & vbCrLf & "to location: " & vbCrLf & CopyTo & vbCrLf & " failed.", "Destination File Corrupted", False)
                            frmMain.lblProgress.Text = "Update Error."
                            frmMain.lblProgress.ForeColor = Color.Red
                            Return False
                            Exit Function
                        End If
                    End If

                Else

                    Threading.Thread.Sleep(1000)
                    If TryCount >= 20 Then
                        MsgBox("Unable to process autoupdate." & vbCrLf & "Attempt to copy file:" & vbCrLf & CopyFrom & vbCrLf & "to location: " & vbCrLf & CopyTo & vbCrLf & " failed.")
                        gProcess_Log("Unable to process autoupdate." & vbCrLf & "Attempt to copy file:" & vbCrLf & CopyFrom & vbCrLf & "to location: " & vbCrLf & CopyTo & vbCrLf & " failed.", "Destination File Corrupted", False)
                        frmMain.lblProgress.Text = "Update Error."
                        frmMain.lblProgress.ForeColor = Color.Red
                        Return False
                    End If
                End If



            Catch ex As Exception
                TryCount = TryCount + 1
                Threading.Thread.Sleep(1000)
                If TryCount >= 20 Then
                    MsgBox("Unable to process autoupdate." & vbCrLf & "Attempt to copy file:" & vbCrLf & CopyFrom & vbCrLf & "to location: " & vbCrLf & CopyTo & vbCrLf & " failed." & vbCrLf & vbCrLf & ex.Message)
                    gProcess_Log("Unable to process autoupdate." & vbCrLf & "Attempt to copy file:" & vbCrLf & CopyFrom & vbCrLf & "to location: " & vbCrLf & CopyTo & vbCrLf & " failed.", ex.Message, False)
                    frmMain.lblProgress.Text = "Update Error."
                    frmMain.lblProgress.ForeColor = Color.Red
                    Return False
                End If
            End Try
        Loop
        gProcess_Log("Update Complete.", "", False)
        frmMain.lblProgress.Text = "Update complete."
        frmMain.lblProgress.Refresh()
        Application.DoEvents()
        Application.DoEvents()
        Return True
    End Function
    Private Sub KillTempFile(fileName As String)
        Dim TryCount As Integer = 0
        Do Until File.Exists(fileName) = True
            frmMain.lblProgress.Text = "Cleanup auto-update files. Please wait... #" & TryCount + 1
            frmMain.lblProgress.Refresh()
            Try
                File.Delete(fileName)
            Catch ex As Exception
                TryCount = TryCount + 1
                Threading.Thread.Sleep(1000)
                If TryCount >= 20 Then
                    Exit Sub
                End If
            End Try
        Loop
    End Sub
    Private Function KillProcess()
        Dim TryCount As Integer = 0
        Do Until File.Exists(CopyTo) = False
            frmMain.lblProgress.Text = "Terminate application. Please wait... #" & TryCount + 1
            frmMain.lblProgress.Refresh()
            Application.DoEvents()
            Try
                Dim ret = Process.GetProcessesByName("eMedicalOffice")
                For Each pr As Process In ret
                    Try
                        pr.Kill()
                    Catch exkill As Exception
                        gProcess_Log("Unable to process autoupdate." & vbCrLf & "Attempt To Kill Process eMedicalOffice failed." & vbCrLf & vbCrLf & exkill.Message, exkill.StackTrace, True)
                    End Try
                Next
                File.Delete(CopyTo)
            Catch ex As Exception
                TryCount = TryCount + 1
                Threading.Thread.Sleep(1000)
                If TryCount >= 20 Then
                    Dim ret = Process.GetProcessesByName("eMedicalOffice")
                    For Each pr As Process In ret
                        Try
                            pr.Kill()
                        Catch exkill As Exception
                            gProcess_Log("Unable to process autoupdate." & vbCrLf & "Attempt To Kill Process eMedicalOffice failed." & vbCrLf & vbCrLf & exkill.Message, exkill.StackTrace, True)
                            MsgBox("Unable to process autoupdate." & vbCrLf & "Attempt To Kill Process eMedicalOffice failed." & vbCrLf & vbCrLf & ex.Message)
                            Return False
                            Exit Function
                        End Try
                    Next
                    MsgBox("Unable to process autoupdate." & vbCrLf & "Attempt to delete file:" & vbCrLf & CopyTo & vbCrLf & " failed." & vbCrLf & vbCrLf & ex.Message)
                    gProcess_Log("Unable to process autoupdate." & vbCrLf & "Attempt fo felete file:" & vbCrLf & CopyTo & vbCrLf & " failed.", ex.Message, False)
                    frmMain.lblProgress.Text = "Update error."
                    frmMain.lblProgress.ForeColor = Color.Red
                    Return False
                    Exit Function
                End If
            End Try
        Loop
        Return True
    End Function
    Public Function gGetEmbeddedResourceSound(ByVal strName As String) As Stream
        Return System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(GetResourceName(strName))
    End Function
    Private Function GetResourceName(ByVal strName As String) As String
        Dim Ret As String
        For Each Ret In System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceNames()
            If InStr(Ret, strName, CompareMethod.Text) Then
                Return Ret
            End If
        Next
        Return ""
    End Function
    Public Class AliasAccount
        Private _username, _password, _domainname As String
        Private _tokenHandle As New IntPtr(0)
        Private _dupeTokenHandle As New IntPtr(0)
        Private _impersonatedUser As System.Security.Principal.WindowsImpersonationContext


        Public Sub New(ByVal username As String, ByVal password As String)
            Dim nameparts() As String = username.Split("\")
            If nameparts.Length > 1 Then
                _domainname = nameparts(0)
                _username = nameparts(1)
            Else
                _username = username
            End If
            _password = password
        End Sub

        Public Sub New(ByVal username As String, ByVal password As String, ByVal domainname As String)
            _username = username
            _password = password
            _domainname = domainname
        End Sub


        Public Sub BeginImpersonation()
            Const LOGON32_PROVIDER_DEFAULT As Integer = 0
            Const LOGON32_LOGON_INTERACTIVE As Integer = 2
            Const SecurityImpersonation As Integer = 2

            Dim win32ErrorNumber As Integer

            _tokenHandle = IntPtr.Zero
            _dupeTokenHandle = IntPtr.Zero

            If Not LogonUser(_username, _domainname, _password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, _tokenHandle) Then
                win32ErrorNumber = System.Runtime.InteropServices.Marshal.GetLastWin32Error()
                Throw New ImpersonationException(win32ErrorNumber, GetErrorMessage(win32ErrorNumber), _username, _domainname)
            End If

            If Not DuplicateToken(_tokenHandle, SecurityImpersonation, _dupeTokenHandle) Then
                win32ErrorNumber = System.Runtime.InteropServices.Marshal.GetLastWin32Error()
                CloseHandle(_tokenHandle)
                Throw New ImpersonationException(win32ErrorNumber, "Unableto duplicate token!", _username, _domainname)
            End If

            Dim newId As New System.Security.Principal.WindowsIdentity(_dupeTokenHandle)
            _impersonatedUser = newId.Impersonate()
        End Sub


        Public Sub EndImpersonation()
            If Not _impersonatedUser Is Nothing Then
                _impersonatedUser.Undo()
                _impersonatedUser = Nothing

                If Not System.IntPtr.op_Equality(_tokenHandle, IntPtr.Zero) Then
                    CloseHandle(_tokenHandle)
                End If
                If Not System.IntPtr.op_Equality(_dupeTokenHandle, IntPtr.Zero) Then
                    CloseHandle(_dupeTokenHandle)
                End If
            End If
        End Sub



        Public ReadOnly Property username() As String
            Get
                Return _username
            End Get
        End Property

        Public ReadOnly Property domainname() As String
            Get
                Return _domainname
            End Get
        End Property


        Public ReadOnly Property currentWindowsUsername() As String
            Get
                Return System.Security.Principal.WindowsIdentity.GetCurrent().Name()
            End Get
        End Property


        Public Class ImpersonationException
            Inherits System.Exception

            Public ReadOnly win32ErrorNumber As Integer

            Public Sub New(ByVal win32ErrorNumber As Integer, ByVal msg As String, ByVal username As String, ByVal domainname As String)
                MyBase.New(String.Format("Impersonation of {1}\{0} failed![{2}] {3}", username, domainname, win32ErrorNumber, msg))
                Me.win32ErrorNumber = win32ErrorNumber
            End Sub
        End Class


        Private Declare Auto Function LogonUser Lib "advapi32.dll" (ByVal lpszUsername As [String], ByVal lpszDomain As [String], ByVal lpszPassword As [String], ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, ByRef phToken As IntPtr) As Boolean
        Private Declare Auto Function DuplicateToken Lib "advapi32.dll" (ByVal ExistingTokenHandle As IntPtr, ByVal SECURITY_IMPERSONATION_LEVEL As Integer, ByRef DuplicateTokenHandle As IntPtr) As Boolean
        Private Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal handle As IntPtr) As Boolean
        Private Shared Function FormatMessage(ByVal dwFlags As Integer, ByRef lpSource As IntPtr, ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, ByRef lpBuffer As [String], ByVal nSize As Integer, ByRef Arguments As IntPtr) As Integer
        End Function


        Private Function GetErrorMessage(ByVal errorCode As Integer) As String
            Dim FORMAT_MESSAGE_ALLOCATE_BUFFER As Integer = &H100
            Dim FORMAT_MESSAGE_IGNORE_INSERTS As Integer = &H200
            Dim FORMAT_MESSAGE_FROM_SYSTEM As Integer = &H1000

            Dim messageSize As Integer = 255
            Dim lpMsgBuf As String = ""
            Dim dwFlags As Integer = FORMAT_MESSAGE_ALLOCATE_BUFFER Or FORMAT_MESSAGE_FROM_SYSTEM Or FORMAT_MESSAGE_IGNORE_INSERTS

            Dim ptrlpSource As IntPtr = IntPtr.Zero
            Dim prtArguments As IntPtr = IntPtr.Zero

            Dim retVal As Integer = FormatMessage(dwFlags, ptrlpSource, errorCode, 0, lpMsgBuf, messageSize, prtArguments)
            If 0 = retVal Then
                Throw New System.Exception("Failed to format message for error code " + errorCode.ToString() + ". ")
            End If

            Return lpMsgBuf
        End Function
    End Class
End Module
