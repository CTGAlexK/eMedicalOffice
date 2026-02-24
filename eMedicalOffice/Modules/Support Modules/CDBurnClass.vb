Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Reflection
Imports IMAPI_CDBurner
Imports log4net

Public Class CDBurnClass
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private ReadOnly imapiCD As ICDBurn
    Private ReadOnly mbHasCDBurner As Boolean = False
    Public mstrBurnPath As String

    <DllImport("shell32.dll", EntryPoint:="SHGetFolderPathW",
           CallingConvention:=CallingConvention.StdCall)>
    Private Shared Function SHGetFolderPath(ByVal hWnd As Integer,
                              ByVal nFolder As Integer, ByVal nToken As Integer,
                              ByVal dwFlags As Integer,
                              <MarshalAs(UnmanagedType.LPTStr)> ByVal lpszPath As String) As Boolean
    End Function

    Public Sub New()
        Const CSIDL_CDBURN_AREA = &H3B

        Dim os As OperatingSystem

        os = Environment.OSVersion

        If os.Platform <> PlatformID.Win32NT And os.Version.Major < 5 _
            And os.Version.Minor < 1 Then
            Throw New Exception("Unsupported Operating System")
        End If

        Dim strPath As String = Space(260)
        If SHGetFolderPath(0, CSIDL_CDBURN_AREA, 0, 0, strPath) = 0 Then
            strPath = strPath.Trim
            strPath = strPath.Mid(1, strPath.Length - 1)
            mstrBurnPath = strPath + "\"
        End If

        imapiCD = New IMAPI_CDBurner.CDBurnClass
        Dim intDrives As Integer

        imapiCD.HasRecordableDrive(intDrives)
        mbHasCDBurner = intDrives > 0

        If Not mbHasCDBurner Then
            mstrBurnPath = ""
            Throw New Exception("No CD Burner")
        End If

    End Sub

    Public Function AddFileToBurn(ByVal strFile As String, Optional ByVal Path As String = "") As Boolean
        Dim fl As FileInfo
        Dim strPath As String

        Try
            fl = New FileInfo(strFile)

            If Path <> "" Then
                Directory.CreateDirectory(mstrBurnPath & Path)
                strPath = mstrBurnPath & Path
                If Right(strPath, 1) <> "\" Then strPath &= "\"
                strPath &= fl.Name
            Else
                strPath = mstrBurnPath + fl.Name
            End If
            File.Copy(strFile, strPath)
        Catch ex As Exception
            log.Error(ex)
            Return False
        End Try

        Return True
    End Function

    Public Function AddFolderToBurn(ByVal SourcePath As String, ByVal DestPath As String, Optional ByVal Overwrite As Boolean = True) As Boolean
        Dim SourceDir As DirectoryInfo = New DirectoryInfo(SourcePath)
        Dim DestDir As DirectoryInfo = New DirectoryInfo(DestPath)
        ' the source directory must exist, otherwise throw an exception
        Try
            If SourceDir.Exists Then
                ' if destination SubDir's parent SubDir does not exist throw an exception
                If Not DestDir.Parent.Exists Then
                    Exit Function
                End If

                If Not DestDir.Exists Then
                    DestDir.Create()
                End If

                ' copy all the files of the current directory
                Dim ChildFile As FileInfo
                For Each ChildFile In SourceDir.GetFiles()
                    If Overwrite Then
                        ChildFile.CopyTo(Path.Combine(DestDir.FullName, ChildFile.Name), True)
                        Application.DoEvents()
                    Else
                        ' if Overwrite = false, copy the file only if it does not exist
                        ' this is done to avoid an IOException if a file already exists
                        ' this way the other files can be copied anyway...
                        If Not File.Exists(Path.Combine(DestDir.FullName, ChildFile.Name)) Then
                            ChildFile.CopyTo(Path.Combine(DestDir.FullName, ChildFile.Name), False)
                            Application.DoEvents()
                        End If
                    End If
                Next

                ' copy all the sub-directories by recursively calling this same routine
                Dim SubDir As DirectoryInfo
                For Each SubDir In SourceDir.GetDirectories()
                    AddFolderToBurn(SubDir.FullName, Path.Combine(DestDir.FullName, SubDir.Name), Overwrite)
                    Application.DoEvents()
                Next
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            log.Error(ex)
            Return False
        End Try
    End Function

    Public Function Check_CDBurner() As String
        'Const CSIDL_CDBURN_AREA = &H3B
        Dim _imapiCD As ICDBurn
        Dim os As OperatingSystem
        Dim _mbHasCDBurner As Integer
        os = Environment.OSVersion

        If os.Platform <> PlatformID.Win32NT And os.Version.Major < 5 And os.Version.Minor < 1 Then
            Return "Unsupported Operating System"
        End If
        Try
            _imapiCD = New IMAPI_CDBurner.CDBurnClass
            Dim intDrives As Integer
            _imapiCD.HasRecordableDrive(intDrives)
            _mbHasCDBurner = intDrives > 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex)
        End Try

        If Not _mbHasCDBurner Then
            Return "No CD Burner Detected."
        End If
        Return ""
    End Function

    Public Sub Burn(ByVal hWnd As IntPtr)
        imapiCD.Burn(UInt32.Parse(hWnd.ToString))
    End Sub

End Class