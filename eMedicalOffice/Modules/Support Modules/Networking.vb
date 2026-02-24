Module Networking

    Public Function GetLocalIPAddress() As String
        Dim strHostName As String = ""
        Dim strIPAddress As String = ""
        If Not String.IsNullOrEmpty(gLocalIPAddress) Then
            Return gLocalIPAddress
        End If
        Try
            strHostName = Net.Dns.GetHostName()
            strIPAddress = Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        Catch
        End Try
        gLocalIPAddress = strIPAddress
        Return strIPAddress
    End Function

    Public Function GetLocalHostName() As String
        Dim strHostName As String = ""
        If Not String.IsNullOrEmpty(gLocalHostName) Then
            Return gLocalIPAddress
        End If

        Try
            strHostName = Net.Dns.GetHostName()
        Catch
        End Try
        gLocalHostName = strHostName
        Return strHostName
    End Function

End Module