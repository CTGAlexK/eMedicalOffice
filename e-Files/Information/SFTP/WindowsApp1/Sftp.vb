Imports Renci.SshNet
Imports System.IO
Public Class Sftp
    Public Shared Sub UploadSFTPFile(ByVal host As String, ByVal username As String, ByVal password As String, ByVal sourcefile As String, ByVal destinationpath As String, ByVal port As Integer)
        Using client As SftpClient = New SftpClient(host, port, username, password)
            client.Connect()
            client.ChangeDirectory(destinationpath)
            Using fs As FileStream = New FileStream(sourcefile, FileMode.Open)
                client.BufferSize = 4 * 1024
                client.UploadFile(fs, Path.GetFileName(sourcefile))
            End Using
        End Using
    End Sub
End Class
