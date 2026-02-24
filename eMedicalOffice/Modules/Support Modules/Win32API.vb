Option Strict On

Imports System.Runtime.InteropServices
Imports System.Text

' Class to wrap up Windows 32 API constants and functions.
Public Module Win32API

    <StructLayout(LayoutKind.Sequential)>
    Public Structure OSVersionInfo
        Public OSVersionInfoSize As Integer
        Public majorVersion As Integer
        Public minorVersion As Integer
        Public buildNumber As Integer
        Public platformId As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)> Public versionString As String
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure SECURITY_ATTRIBUTES
        Public nLength As Integer
        Public lpSecurityDescriptor As Integer
        Public bInheritHandle As Integer
    End Structure

    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    Private Structure POINT
        Public x As Long
        Public y As Long
    End Structure

    'Public Structure TVITEM
    '    Public mask As Integer
    '    Public hItem As IntPtr
    '    Public state As Integer
    '    Public stateMask As Integer
    '    Public lpszText As String
    '    Public cchTextMax As Integer
    '    Public iImage As Integer
    '    Public iSelectedImage As Integer
    '    Public cChildren As Integer
    '    Public lParam As IntPtr
    'End Structure

    Public Const TVIF_STATE = 8
    Public Const TVIS_STATEIMAGEMASK = 61440
    Public Const TV_FIRST = 4352
    Public Const TVM_SETITEM = TV_FIRST + 63

    Public Const AW_HOR_POSITIVE = &H1 'Animates the window from left to right. This flag can be used with roll or slide animation.
    Public Const AW_HOR_NEGATIVE = &H2 'Animates the window from right to left. This flag can be used with roll or slide animation.
    Public Const AW_VER_POSITIVE = &H4 'Animates the window from top to bottom. This flag can be used with roll or slide animation.
    Public Const AW_VER_NEGATIVE = &H8 'Animates the window from bottom to top. This flag can be used with roll or slide animation.
    Public Const AW_CENTER = &H10 'Makes the window appear to collapse inward if AW_HIDE is used or expand outward if the AW_HIDE is not used.
    Public Const AW_HIDE = &H10000 'Hides the window. By default, the window is shown.
    Public Const AW_ACTIVATE = &H20000 'Activates the window.
    Public Const AW_SLIDE = &H40000 'Uses slide animation. By default, roll animation is used.
    Public Const AW_BLEND = &H80000 'Uses a fade effect. This flag can be used only if hwnd is a top-level window.
    Public Const GWL_STYLE As Integer = (-16)
    Public Const GCL_STYLE As Integer = (-26)
    Public Const WS_BORDER As Integer = &H80000020
    Public Const CS_DBLCLKS As UInteger = &H80
    Public Const GWL_EXSTYLE As Integer = (-20)
    Public Const GW_OWNER As Integer = 4
    Public Const SW_RESTORE As Integer = 9
    Public Const SW_SHOW As Integer = 5
    Public Const WS_EX_TOOLWINDOW As Integer = &H80
    Public Const WS_EX_APPWINDOW As Integer = &H40000
    Public Const WM_SYSCOMMAND As Long = &H112&
    Public Const SC_SCREENSAVE As Long = &HF140&
    Public Const WS_EX_CLIENTEDGE As Long = &H200
    Public Const WM_SETREDRAW As Long = &HB
    Public Const BUFFER_SIZE As Long = 4096
    'Public Const TVIF_STATE As Integer = &H8
    'Public Const TVIS_STATEIMAGEMASK As Integer = &HF000
    'Public Const TV_FIRST As Integer = &H1100
    'Public Const TVM_SETITEM As Integer = TV_FIRST + 63

    Public Declare Function CreateDirectory Lib "kernel32" Alias "CreateDirectoryA" (lpPathName As String, lpSecurityAttributes As SECURITY_ATTRIBUTES) As Boolean

    Public Delegate Function EnumWindowsCallback(hWnd As Integer, lParam As Integer) As Boolean

    Public Declare Function EnumWindows Lib "user32.dll" Alias "EnumWindows" (callback As EnumWindowsCallback, lParam As Integer) As Integer

    <DllImport("user32.dll", EntryPoint:="EnumWindows", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Function EnumWindowsDllImport(callback As EnumWindowsCallback, lParam As Integer) As Integer
    End Function

    Public Declare Auto Function FindWindow Lib "user32.dll" Alias "FindWindow" (lpClassName As String, lpWindowName As String) As Integer
    Public Declare Auto Function FindWindowAny Lib "user32.dll" Alias "FindWindow" (lpClassName As Integer, lpWindowName As Integer) As Integer
    Public Declare Auto Function FindWindowNullClassName Lib "user32.dll" Alias "FindWindow" (lpClassName As Integer, lpWindowName As String) As Integer
    Public Declare Auto Function FindWindowNullWindowCaption Lib "user32.dll" Alias "FindWindow" (lpClassName As String, lpWindowName As Integer) As Integer
    Public Declare Function GetClassName Lib "user32.dll" Alias "GetClassNameA" (hwnd As Integer, lpClassName As StringBuilder, cch As Integer) As Integer
    Public Declare Function GetDiskFreeSpace Lib "kernel32" Alias "GetDiskFreeSpaceA" (lpRootPathName As String, ByRef lpSectorsPerCluster As Integer, ByRef lpBytesPerSector As Integer, ByRef lpNumberOfFreeClusters As Integer, ByRef lpTotalNumberOfClusters As Integer) As Integer
    Public Declare Function GetDriveType Lib "kernel32" Alias "GetDriveTypeA" (nDrive As String) As Integer
    Public Declare Function GetParent Lib "user32.dll" Alias "GetParent" (hwnd As Integer) As Integer
    Public Declare Ansi Function GetVersionEx Lib "kernel32.dll" Alias "GetVersionExA" (ByRef osvi As OSVersionInfo) As Boolean
    Public Declare Function GetWindow Lib "user32.dll" Alias "GetWindow" (hwnd As Integer, wCmd As Integer) As Integer
    Public Declare Function GetWindowLong Lib "user32.dll" Alias "GetWindowLongA" (hwnd As Integer, nIndex As Integer) As Integer
    Public Declare Sub GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (hWnd As Integer, lpString As StringBuilder, nMaxCount As Integer)
    Public Declare Function IsIconic Lib "user32.dll" Alias "IsIconic" (hwnd As Integer) As Boolean
    Public Declare Function IsPwrHibernateAllowed Lib "Powrprof.dll" Alias "IsPwrHibernateAllowed" () As Integer
    Public Declare Function IsWindowVisible Lib "user32.dll" Alias "IsWindowVisible" (hwnd As Integer) As Boolean
    Public Declare Function SetForegroundWindow Lib "user32.dll" Alias "SetForegroundWindow" (hwnd As Integer) As Integer
    Public Declare Function SetSuspendState Lib "Powrprof.dll" Alias "SetSuspendState" (Hibernate As Integer, ForceCritical As Integer, DisableWakeEvent As Integer) As Integer
    Public Declare Function ShowWindow Lib "user32.dll" Alias "ShowWindow" (hwnd As Integer, nCmdShow As Integer) As Integer
    Public Declare Function SwapMouseButton Lib "user32.dll" Alias "SwapMouseButton" (bSwap As Integer) As Integer
    Public Declare Function DeleteFile Lib "kernel32" Alias "DeleteFileA" (lpFileName As String) As Long
    Public Declare Function InvalidateRect Lib "user32" (hWnd As IntPtr, lpRect As RECT, bErase As Boolean) As Boolean

    Public Enum InternetConnection As UInt32
        None = 0
        Configured = &H40
        Lan = &H2
        Modem = &H1
        ModemBusy = &H8
        Offline = &H20
        Proxy = &H4
        RasInstalled = &H10
    End Enum

    Public Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef dwflags As InternetConnection, dwReserved As UInt32) As Boolean
    Public Declare Function ReleaseDC Lib "user32" (hwnd As Long, hdc As Long) As Long
    Public Declare Function GetDC Lib "user32" Alias "GetDC" (hwnd As Long) As Long
    Public Declare Function LockWindowUpdate Lib "user32" (hWnd As IntPtr) As Boolean
    Public Declare Auto Function GetWindowLong Lib "user32" (hWnd As IntPtr, nIndex As Integer) As Integer
    Public Declare Auto Function SetWindowLong Lib "user32" (hWnd As IntPtr, nIndex As Integer, dwNewLong As IntPtr) As Integer
    Public Declare Auto Function SendMessageLong Lib "user32" Alias "SendMessageA" (hwnd As Long, msg As Long, wParam As Long, lParam As Long) As Long
    Public Declare Auto Function ShowCursor Lib "user32" (lShow As Long) As Long
    Public Declare Auto Function GetDesktopWindow Lib "user32" () As Long
    Public Declare Function AnimateWindow Lib "user32" (hwnd As Int32, dwTime As Int32, dwFlags As Int32) As Boolean
    Public Declare Auto Function GetClassLong Lib "user32" (hWnd As IntPtr, index As Integer) As UInteger
    Public Declare Auto Function SetClassLong Lib "user32" (hWnd As IntPtr, index As Integer, newLong As UInteger) As UInteger
    Public Declare Auto Function SendMessageTVITEM Lib "user32.dll" Alias "SendMessage" (hWnd As IntPtr, Msg As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    'Public Declare Auto Function SendMessage Lib "user32" Alias "SendMessageA"(hwnd As Long, wMsg As Long,wParam As Integer,ByRef lParam As String) As Long
End Module