Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports log4net

<Assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum, All:="HKEY_LOCAL_MACHINE")> 
Module InstallFont
    Private log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    <DllImport("gdi32")> _
      Private Function AddFontResource(ByVal lpFileName As String) As Integer
    End Function
    <DllImport("user32.dll")> _
    Private Function SendMessage(ByVal hWnd As Integer, ByVal Msg As UInteger, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Function WriteProfileString(ByVal lpszSection As String, ByVal lpszKeyName As String, ByVal lpszString As String) As Integer
    End Function
    Private Const WM_FONTCHANGE As Integer = &H1D
    Private Const HWND_BROADCAST As Integer = &HFFFF
    Private Declare Auto Function AddFontMemResourceEx Lib "Gdi32.dll" _
    (ByVal pbFont As IntPtr, ByVal cbFont As Integer, _
    ByVal pdv As Integer, ByRef pcFonts As Integer) As IntPtr
    Public Sub gInstall_BarCode_Font()
        Dim fnt As Byte()
        Dim TempFolder As String = Path.GetTempPath
        Dim FontName As String = "IDAutomationHC39M"
        Dim FontPath As String = TempFolder & FontName & ".ttf"
        Dim testFont = New Font(FontName, 8)
        Dim Ret As Integer
        Dim Res As Integer
        Dim InstalledFontPath As String = Path.Combine(Path.Combine(Environment.GetEnvironmentVariable("windir"), "Fonts"), FontName & ".ttf")
        If FontName.ToUpper = testFont.Name.ToUpper Then
            ' Font Installed 
            Exit Sub
        End If
        Try
            If (File.Exists(FontPath)) Then
                File.Delete(FontPath)
            End If

            Dim fStream As New FileStream(FontPath, System.IO.FileMode.CreateNew)
            Dim bw As New BinaryWriter(fStream)
            fnt = My.Resources.IDAutomationHC39M
            bw.Write(fnt)
            bw.Close()
            fStream.Close()
            If (File.Exists(InstalledFontPath) = False) Then
                File.Copy(FontPath, InstalledFontPath, False)
            End If
            Ret = AddFontResource(InstalledFontPath)
            If Ret Then
                Ret = WriteProfileString("fonts", FontName & " (TrueType)", InstalledFontPath)
                If Ret Then
                    Res = SendMessage(HWND_BROADCAST, WM_FONTCHANGE, 0, 0&)
                End If
            End If
            System.IO.File.Delete(FontPath)
        Catch ex As Exception

            log.Error(ex.Message, ex)
        End Try
    End Sub
End Module
