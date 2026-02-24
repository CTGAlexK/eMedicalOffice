
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim source As String = "D:\Desktop\e-Files\14-20221023.csv"
        Dim destination As String = "upload"
        Dim host As String = "demo.wftpserver.com"
        Dim username As String = "demo"
        Dim password As String = "demo"
        Dim port As Integer = 2222
        Sftp.UploadSFTPFile(host, username, password, source, destination, port)
    End Sub
End Class
