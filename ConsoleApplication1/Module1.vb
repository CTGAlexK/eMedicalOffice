Imports System.IO


Module Module1
    Private WithEvents T As New Timers.Timer
    Public Sub Main()
        Dim CopyFrom As String
        Dim CopyTo As String
        Dim OldVersion As String
        Dim NewVersion As String
        Dim RunOnce As String
        Dim I As Integer
        Dim spinChars() As String = Split("|,/,-,\", ",")
        Dim spinChar As String
        Dim spinnerPosition As Integer = 35
        Dim SysAdminUID As String
        Dim SysAdminPWD As String
        RunOnce = GetSetting("eMedicalOffice", "AutoUpdate", "RunOnce", "")
        SaveSetting("eMedicalOffice", "AutoUpdate", "RunOnce", "")
        System.Console.Title = "eMedical Office Auto Update"
        If RunOnce = "" Then
            System.Console.ForegroundColor = ConsoleColor.Red
            System.Console.Write("Welcome to eMedical Office Auto Update" & vbCrLf & vbCrLf)
            System.Console.Write("The AutoUpdate system can not be run manually." & vbCrLf)
            System.Console.Write("This file is required by eMedical Office to process system updates." & vbCrLf & vbCrLf)
            System.Console.Write("Press any key to exit.")
            System.Console.Beep(800, 1000)
            System.Console.ReadKey()
            Exit Sub
        End If
        SysAdminUID = GetSetting("eMedicalOffice", "AutoUpdate", "SysAdminUID", "")
        SysAdminPWD = GetSetting("eMedicalOffice", "AutoUpdate", "SysAdminPWD", "")

        CopyFrom = GetSetting("eMedicalOffice", "AutoUpdate", "CopyFrom", "")
        CopyTo = GetSetting("eMedicalOffice", "AutoUpdate", "CopyTo", "")
        OldVersion = GetSetting("eMedicalOffice", "AutoUpdate", "OldVersion", "")
        NewVersion = GetSetting("eMedicalOffice", "AutoUpdate", "NewVersion", "")


        System.Console.Write("Welcome to eMedical Office Auto Update" & vbCrLf & vbCrLf)
        If CopyFrom = "" Then
            System.Console.ForegroundColor = ConsoleColor.Red
            System.Console.Write(vbCrLf & vbCrLf & "Error: Parameter [CopyFrom] is missing")
            System.Console.Write(vbCrLf & vbCrLf & "Press any key to exit.")
            System.Console.Beep(800, 1000)
            System.Console.ReadKey()
            Exit Sub
        End If
        If File.Exists(CopyFrom) = False Then
            System.Console.ForegroundColor = ConsoleColor.Red
            System.Console.Write(vbCrLf & vbCrLf & "Error: The Update File " & CopyFrom & vbCrLf & " does not exist or not accessible.")
            System.Console.Write(vbCrLf & vbCrLf & "Press any key to exit.")
            System.Console.Beep(800, 1000)
            System.Console.ReadKey()
            Exit Sub
        End If

        If CopyTo = "" Then
            System.Console.ForegroundColor = ConsoleColor.Red
            System.Console.Write(vbCrLf & vbCrLf & "Error: Parameter [CopyTo] is missing")
            System.Console.Write(vbCrLf & vbCrLf & "Press any key to exit.")
            System.Console.Beep(800, 1000)
            System.Console.ReadKey()
            Exit Sub
        End If
        If File.Exists(CopyTo) = False Then
            System.Console.ForegroundColor = ConsoleColor.Red
            System.Console.Write(vbCrLf & vbCrLf & "Error: The File " & CopyTo & vbCrLf & " does not exist or not accessible.")
            System.Console.Write(vbCrLf & vbCrLf & "Press any key to exit.")
            System.Console.Beep(800, 1000)
            System.Console.ReadKey()
            Exit Sub
        End If

        System.Console.ForegroundColor = ConsoleColor.White
        System.Console.Write("The New version of eMedical has been released." & vbCrLf & vbCrLf & vbCrLf)
        System.Console.Write("Current Version:  " & OldVersion & vbCrLf & vbCrLf)
        System.Console.Write("New Version:  " & NewVersion & vbCrLf & vbCrLf)
        System.Console.Write("Processing Update. Please wait...")
        System.Console.Beep(1000, 200)
        System.Console.Beep(800, 200)

        For I = 0 To 20
            For Each spinChar In spinChars
                Console.CursorLeft = spinnerPosition
                Console.Write(spinChar)
                System.Threading.Thread.Sleep(30)
            Next
        Next

        Dim TryCount As Integer = 0
        Do Until File.Exists(CopyTo) = False
            Try
                File.Delete(CopyTo)
            Catch ex As Exception
                TryCount = TryCount + 1
                If TryCount >= 50 Then
                    Console.CursorLeft = spinnerPosition
                    Console.Write(" ")
                    System.Console.ForegroundColor = ConsoleColor.Red
                    System.Console.Beep(800, 1000)
                    System.Console.Write(vbCrLf & vbCrLf & "Attempt To Delete File:" & vbCrLf & CopyTo & vbCrLf & " Failed.")
                    System.Console.Write(vbCrLf & vbCrLf & "Error" & vbCrLf & ex.Message)
                    System.Console.Write(vbCrLf & vbCrLf & "Press any key to exit.")
                    System.Console.ReadKey()
                    Exit Sub
                End If
                System.Threading.Thread.Sleep(200)
            End Try
        Loop
        TryCount = 0
        Do Until File.Exists(CopyTo) = True
            Try
                File.Copy(CopyFrom, CopyTo, True)
            Catch ex As Exception
                TryCount = TryCount + 1
                If TryCount >= 50 Then
                    Console.CursorLeft = spinnerPosition
                    Console.Write(" ")
                    System.Console.ForegroundColor = ConsoleColor.Red
                    System.Console.Beep(800, 1000)
                    System.Console.Write(vbCrLf & vbCrLf & "Attempt To Copy File:" & vbCrLf & CopyFrom & vbCrLf & "To Location: " & vbCrLf & CopyTo & vbCrLf & " Failed.")
                    System.Console.Write(vbCrLf & vbCrLf & "Error" & vbCrLf & ex.Message)
                    System.Console.Write(vbCrLf & vbCrLf & "Press any key to exit.")
                    System.Console.ReadKey()
                    Exit Sub
                End If
                System.Threading.Thread.Sleep(200)
            End Try
        Loop


        Console.CursorLeft = spinnerPosition
        Console.Write(" ")
        System.Console.Beep(1000, 200)
        System.Console.Beep(800, 200)
        System.Console.ForegroundColor = ConsoleColor.Green
        System.Console.Write(vbCrLf & vbCrLf & "Update Complete." & vbCrLf)
        For I = 0 To 40 Step 2
            Console.Write("* ")
            System.Threading.Thread.Sleep(5)
        Next
        System.Diagnostics.Process.Start(CopyTo)


    End Sub

    Private Sub T_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles T.Elapsed


    End Sub
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
