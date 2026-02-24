Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Threading
Imports System.Threading.Tasks
Imports log4net

Public Module DbModule
    Public Property gSqlServerName As String
    Public Property gSQLServerDatabase As String
    Public Property gSQLServerUID As String
    Public Property gSQLServerPassword As String
    Public Property gPACSSQLServerName As String
    Public Property gPACSSQLServerDatabase As String
    Public Property gPACSSQLServerUID As String
    Public Property gPACSSQLServerPassword As String
    Public Property gPACSPatientIDPadded As Integer
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    'Public Sub SetDBStatus(Status As DBStatus)
    '    If MDILoaded Then
    '        Select Case Status
    '            Case DBStatus.stNone
    '                MDIForm1Win8.DBStatusLabel.Text = ""
    '                MDIForm1Win8.DBStatusLabel.ToolTipText = $"Status Unknown"
    '                If Not MDIForm1Win8.DBStatusLabel.Image Is My.Resources.DBStatus0 Then _
    '                    MDIForm1Win8.DBStatusLabel.Image = My.Resources.DBStatus0
    '            Case DBStatus.stOk
    '                MDIForm1Win8.DBStatusLabel.Text = ""
    '                MDIForm1Win8.DBStatusLabel.ToolTipText = $"Status Database Connection OK"
    '                If Not MDIForm1Win8.DBStatusLabel.Image Is My.Resources.DBStatus1 Then _
    '                    MDIForm1Win8.DBStatusLabel.Image = My.Resources.DBStatus1
    '            Case DBStatus.stWarning
    '                MDIForm1Win8.DBStatusLabel.Text = ""
    '                MDIForm1Win8.DBStatusLabel.ToolTipText = $"Status Database Connection Problems"
    '                If Not MDIForm1Win8.DBStatusLabel.Image Is My.Resources.DBStatus2 Then _
    '                    MDIForm1Win8.DBStatusLabel.Image = My.Resources.DBStatus2
    '            Case DBStatus.stError
    '                MDIForm1Win8.DBStatusLabel.Text = ""
    '                MDIForm1Win8.DBStatusLabel.ToolTipText = $"Status Database Connection Error"
    '                If Not MDIForm1Win8.DBStatusLabel.Image Is My.Resources.DBStatus3 Then _
    '                    MDIForm1Win8.DBStatusLabel.Image = My.Resources.DBStatus3
    '        End Select
    '        'If Not MDIForm1Win8.DBStatusLabel.Image Is MDIForm1Win8.ImageListDBStatus.Images(Status) Then MDIForm1Win8.DBStatusLabel.Image = MDIForm1Win8.ImageListDBStatus.Images(Status)
    '        Application.DoEvents()
    '    End If
    'End Sub

    'Public Enum DBStatus
    '    stNone = 0
    '    stOk = 1
    '    stWarning = 2
    '    stError = 3
    'End Enum
    Private Function OpenSQLConnection(Optional ConnectionString As String = "") As SqlConnection
        Dim Cnn As SqlConnection
        Dim ErrorMsg As String
        If String.IsNullOrEmpty(ConnectionString) Then
            ConnectionString = gConnectionString
        End If
        If ConnectionString = "" Then
            Return Nothing
        End If
        For i = 0 To 10
            Try
                Cnn = New SqlConnection(ConnectionString)
                Cnn.Open()
                Return Cnn
            Catch ex As Exception
                log.Error(ex)
                ErrorMsg = gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & ConnectionString
                If InStr(ex.ToString, "transport-level") Then
                    SqlConnection.ClearPool(Cnn)
                    SqlConnection.ClearAllPools()
                    CloseSQLConnection(Cnn)
                End If
                Thread.Sleep(500)
            End Try
        Next
        If (ErrorMsg.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
            gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", ErrorMsg, Nothing, Net.Mail.MailPriority.High, False, True)
        End If
        Return Nothing
    End Function

    Private Sub CloseSQLConnection(ByRef Cnn As SqlConnection)
        Try
            If Cnn Is Nothing Then Exit Sub
            If Cnn.State <> ConnectionState.Closed Then
                Cnn.Close()
            End If
            Cnn.Dispose()
            Cnn = Nothing
        Catch

        End Try
    End Sub

    Private Sub ResetSQLConnection(ByRef Cnn)
        Try
            If Cnn Is Nothing Then Exit Sub
            SqlConnection.ClearPool(Cnn)
            SqlConnection.ClearAllPools()
            CloseSQLConnection(Cnn)
            Thread.Sleep(500)
        Catch
        End Try
    End Sub

    Public Async Function gSQLGetDataReaderAsync(SQL As String) As Task(Of SqlDataReader)
        Dim result As SqlDataReader = Nothing
        Dim worker As New Task(Sub()
                                   result = gSQLGetDataReader(SQL)
                               End Sub)
        worker.Start()
        worker.Wait()
        Return result
    End Function

    Public Function gSQLGetDataReader(SQL As String) As SqlDataReader
Er:
        Dim Cnn As SqlConnection = OpenSQLConnection()
        If Cnn Is Nothing Then
            Return Nothing
        End If
        Dim Reader As SqlDataReader
        Dim Cmd As New SqlCommand(SQL, Cnn)
        Dim ErrorCount As Integer

        Cmd.CommandTimeout = 300
        Try
            Reader = Cmd.ExecuteReader
        Catch ex As Exception
            ErrorCount = ErrorCount + 1
            If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                ResetSQLConnection(Cnn)
                GoTo Er
            End If
            log.Error(ex.Message, ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
            If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & gConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
            End If
            Cnn.Dispose()
            Return Nothing

        End Try

        gSQLGetDataReader = Reader
    End Function

    Public Function gSQLGetDataReader(SQL As String, connectionString As String) As SqlDataReader
        'Dim Cnn As New SqlConnection(connectionString)
Er:
        Dim Cnn As SqlConnection = OpenSQLConnection(connectionString)
        If Cnn Is Nothing Then
            Return Nothing
        End If
        Dim Reader As SqlDataReader
        Dim Cmd As New SqlCommand(SQL, Cnn)
        Dim ErrorCount As Integer

        'Try
        '    Cnn.Open()
        'Catch ex As Exception
        '    ErrorCount = ErrorCount + 1
        '    If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
        '        SqlConnection.ClearPool(Cnn)
        '        SqlConnection.ClearAllPools()
        '        If Cnn.State = ConnectionState.Open Then
        '            Cnn.Close()
        '        End If
        '        Thread.Sleep(500)
        '        GoTo Er
        '    End If
        '    log.Error(ex.Message, ex)
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
        '    If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
        '        gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & connectionString, Nothing, Net.Mail.MailPriority.High, False, True)
        '    End If
        '    Return Nothing

        'End Try
        Cmd.CommandTimeout = 300
        Try
            Reader = Cmd.ExecuteReader
        Catch ex As Exception
            ErrorCount = ErrorCount + 1
            If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                ResetSQLConnection(Cnn)
                GoTo Er
            End If
            log.Error(ex.Message, ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
            If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & connectionString, Nothing, Net.Mail.MailPriority.High, False, True)
            End If
            Cnn.Dispose()
            Return Nothing
        End Try

        gSQLGetDataReader = Reader
    End Function

    Public Function gSQLGetDataSet(SQL As String) As DataSet
        'Dim Cnn As New SqlConnection(gConnectionString)
Er:
        Dim Cnn As SqlConnection = OpenSQLConnection()
        If Cnn Is Nothing Then
            Return Nothing
        End If
        Dim lDS As DataSet = Nothing
        Dim ErrorCount As Integer

        'Try
        '    Cnn.Open()
        'Catch ex As Exception
        '    ErrorCount = ErrorCount + 1
        '    If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
        '        SqlConnection.ClearPool(Cnn)
        '        SqlConnection.ClearAllPools()
        '        If Cnn.State = ConnectionState.Open Then
        '            Cnn.Close()
        '        End If
        '        Thread.Sleep(500)
        '        GoTo Er
        '    End If
        '    log.Error(ex.Message, ex)
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
        '    If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
        '        gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & gConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
        '    End If
        '    Return Nothing

        'End Try
        Dim adapter As New SqlDataAdapter()
        adapter.SelectCommand = New SqlCommand(SQL, Cnn)
        Try
            lDS = New DataSet
            adapter.Fill(lDS)
        Catch ex As Exception
            ErrorCount = ErrorCount + 1
            If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                ResetSQLConnection(Cnn)
                GoTo Er
            End If
            log.Error(ex.Message, ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
            lDS = Nothing
            If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & gConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
            End If
        End Try
        CloseSQLConnection(Cnn)
        Return lDS
    End Function

    Public Function gSQLGetDataSet(SQL As String, connectionString As String) As DataSet
        'Dim Cnn As New SqlConnection(ConnectionString)
er:
        Dim Cnn As SqlConnection = OpenSQLConnection(connectionString)
        If Cnn Is Nothing Then
            Return Nothing
        End If
        Dim lDS As DataSet = Nothing
        Dim ErrorCount As Integer

        'Try
        '    Cnn.Open()
        'Catch ex As Exception
        '    ErrorCount = ErrorCount + 1
        '    If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
        '        SqlConnection.ClearPool(Cnn)
        '        SqlConnection.ClearAllPools()
        '        If Cnn.State = ConnectionState.Open Then
        '            Cnn.Close()
        '        End If
        '        Thread.Sleep(500)
        '        GoTo er
        '    End If
        '    log.Error(ex.Message, ex)
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
        '    If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
        '        gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & ConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
        '    End If
        '    Return Nothing

        'End Try

        Dim adapter As New SqlDataAdapter()
        adapter.SelectCommand = New SqlCommand(SQL, Cnn)
        Try
            lDS = New DataSet
            adapter.Fill(lDS)
        Catch ex As Exception
            ErrorCount = ErrorCount + 1
            If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                ResetSQLConnection(Cnn)
                GoTo er
            End If
            log.Error(ex.Message, ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
            If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & connectionString, Nothing, Net.Mail.MailPriority.High, False, True)
            End If
            lDS = Nothing
        End Try
        CloseSQLConnection(Cnn)
        Return lDS
    End Function

    Public Function gSQLDeleteRecord(SQL As String) As Boolean
        Dim ErrorCount As Integer
        Dim Ret As Boolean = False
er:
        Dim Cnn As SqlConnection = OpenSQLConnection()
        If Cnn Is Nothing Then
            Return False
        End If

        Using Cmd As New SqlCommand(SQL, Cnn)
            Try
                Cmd.ExecuteNonQuery()
                Ret = True
            Catch ex As Exception
                ErrorCount = ErrorCount + 1
                If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                    ResetSQLConnection(Cnn)
                    GoTo er
                End If
                log.Error(ex.Message, ex)
                MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
                If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                    gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & gConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
                End If
            End Try
        End Using
        CloseSQLConnection(Cnn)
        Return Ret
    End Function

    Public Function gSQLDeleteRecord(SQL As String, connectionString As String) As Boolean
        Dim ErrorCount As Long = 0
        Dim Ret As Boolean = False
Er:
        Dim Cnn As SqlConnection = OpenSQLConnection(connectionString)
        If Cnn Is Nothing Then
            Return False
        End If

        'Using Cnn As New SqlConnection(connectionString)
        '    Try

        '        Cnn.Open()
        '    Catch ex As Exception
        '        ErrorCount = ErrorCount + 1
        '        If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
        '            SqlConnection.ClearPool(Cnn)
        '            SqlConnection.ClearAllPools()
        '            If Cnn.State = ConnectionState.Open Then
        '                Cnn.Close()
        '            End If
        '            Thread.Sleep(500)
        '            GoTo Er
        '        End If
        '        log.Error(ex.Message, ex)
        '        MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
        '        If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
        '            gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & connectionString, Nothing, Net.Mail.MailPriority.High, False, True)
        '        End If
        '        Return False
        '    End Try

        Using Cmd As New SqlCommand(SQL, Cnn)
            Try
                Cmd.ExecuteNonQuery()
                Ret = True
            Catch ex As Exception
                ErrorCount = ErrorCount + 1
                If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                    ResetSQLConnection(Cnn)
                    GoTo Er
                End If
                log.Error(ex.Message, ex)
                MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
                If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                    gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & connectionString, Nothing, Net.Mail.MailPriority.High, False, True)
                End If
            End Try

        End Using
        'End Using
        CloseSQLConnection(Cnn)
        Return Ret
    End Function

    Public Function gSQLUpdateData(SQL As String) As Boolean
        Dim ErrorCount = 0
        Dim Ret As Boolean = False
er:
        Dim Cnn As SqlConnection = OpenSQLConnection()
        If Cnn Is Nothing Then
            Return False
        End If

        'Using Cnn As New SqlConnection(gConnectionString)
        '    Try
        '        Cnn.Open()
        '    Catch ex As Exception
        '        ErrorCount = ErrorCount + 1
        '        If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
        '            SqlConnection.ClearPool(Cnn)
        '            SqlConnection.ClearAllPools()
        '            If Cnn.State = ConnectionState.Open Then
        '                Cnn.Close()
        '            End If
        '            Thread.Sleep(500)
        '            GoTo er
        '        End If
        '        log.Error(ex.Message, ex)
        '        MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
        '        If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
        '            gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & gConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
        '        End If
        '        Return False
        '    End Try
        Using Cmd As New SqlCommand(SQL, Cnn)
            Try
                Cmd.ExecuteNonQuery()
                Ret = True
            Catch ex As Exception
                ErrorCount = ErrorCount + 1
                If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                    ResetSQLConnection(Cnn)
                    GoTo er
                End If
                log.Error(ex.Message, ex)
                MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
                If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                    gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & gConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
                End If
            End Try

        End Using
        CloseSQLConnection(Cnn)
        Return Ret
        'End Using
    End Function

    Public Function gSQLUpdateData(SQL As String, connectionString As String) As Boolean
        Dim ErrorCount = 0
        Dim Ret As Boolean = False
er:
        Dim Cnn As SqlConnection = OpenSQLConnection(connectionString)
        If Cnn Is Nothing Then
            Return False
        End If

        'Using Cnn As New SqlConnection(ConnectionString)
        '    Try
        '        Cnn.Open()
        '    Catch ex As Exception
        '        ErrorCount = ErrorCount + 1
        '        If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
        '            SqlConnection.ClearPool(Cnn)
        '            SqlConnection.ClearAllPools()
        '            If Cnn.State = ConnectionState.Open Then
        '                Cnn.Close()
        '            End If
        '            Thread.Sleep(500)
        '            GoTo er
        '        End If
        '        log.Error(ex.Message, ex)
        '        MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
        '        If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
        '            gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & ConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
        '        End If
        '        Return False
        '    End Try
        Using Cmd As New SqlCommand(SQL, Cnn)
            Try
                Cmd.ExecuteNonQuery()
                Ret = True
            Catch ex As Exception
                ErrorCount = ErrorCount + 1
                If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                    ResetSQLConnection(Cnn)
                    GoTo er
                End If
                log.Error(ex.Message, ex)
                MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
                If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                    gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & connectionString, Nothing, Net.Mail.MailPriority.High, False, True)
                End If
            End Try

        End Using
        'End Using
        CloseSQLConnection(Cnn)
        Return Ret
    End Function

    Public Function gSQLGetValue(SQL As String, Optional ConnectionString As String = "") As Object
        Dim ErrorCount = 0
        Dim Ret
        Dim RetValue
er:
        Dim Cnn As SqlConnection = OpenSQLConnection(ConnectionString)
        If Cnn Is Nothing Then
            Return ""
        End If

        Using Cmd As New SqlCommand(SQL, Cnn)
            Try
                RetValue = Cmd.ExecuteScalar()
            Catch ex As Exception
                ErrorCount = ErrorCount + 1
                If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                    ResetSQLConnection(Cnn)
                    GoTo er
                End If
                log.Error(ex.Message, ex)
                MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
                If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                    gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & gConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
                End If
            End Try
        End Using
        'End Using
        CloseSQLConnection(Cnn)
        Return RetValue
    End Function

    Public Function gSQLGetSingleValueString(SQL As String, connectionString As String) As String
        Dim ErrorCount = 0
        Dim Ret
        Dim RetValue As String = ""
Er:
        Dim Cnn As SqlConnection = OpenSQLConnection(connectionString)
        If Cnn Is Nothing Then
            Return ""
        End If

        'Using Cnn As New SqlConnection(ConnectionString)
        '    Try
        '        Cnn.Open()
        '    Catch ex As Exception
        '        ErrorCount = ErrorCount + 1
        '        If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
        '            SqlConnection.ClearPool(Cnn)
        '            SqlConnection.ClearAllPools()
        '            If Cnn.State = ConnectionState.Open Then
        '                Cnn.Close()
        '            End If
        '            Thread.Sleep(500)
        '            GoTo Er
        '        End If
        '        log.Error(ex.Message, ex)
        '        MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
        '        If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
        '            gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & ConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
        '        End If
        '        Return ""
        '    End Try
        Using Cmd As New SqlCommand(SQL, Cnn)
            Try
                Ret = Cmd.ExecuteScalar()
                If Ret Is Nothing Then
                    RetValue = ""
                Else
                    If Ret Is Nothing OrElse Ret Is DBNull.Value Then
                        RetValue = ""
                    Else
                        RetValue = Ret
                    End If
                End If
            Catch ex As Exception
                ErrorCount = ErrorCount + 1
                If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                    ResetSQLConnection(Cnn)
                    GoTo Er
                End If
                log.Error(ex.Message, ex)
                MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
                If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                    gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & connectionString, Nothing, Net.Mail.MailPriority.High, False, True)
                End If
            End Try
        End Using
        'End Using
        CloseSQLConnection(Cnn)
        Return RetValue
    End Function

    Public Function gSQLGetSingleValueString(SQL As String) As String
        Dim ErrorCount = 0
        Dim Ret
        Dim RetValue As String = ""
er:
        Dim Cnn As SqlConnection = OpenSQLConnection()
        If Cnn Is Nothing Then
            Return ""
        End If

        'Using Cnn As New SqlConnection(gConnectionString)
        '    Try
        '        Cnn.Open()
        '    Catch ex As Exception
        '        ErrorCount = ErrorCount + 1
        '        If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
        '            SqlConnection.ClearPool(Cnn)
        '            SqlConnection.ClearAllPools()
        '            If Cnn.State = ConnectionState.Open Then
        '                Cnn.Close()
        '            End If
        '            Thread.Sleep(500)
        '            GoTo er
        '        End If
        '        log.Error(ex.Message, ex)
        '        MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
        '        If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
        '            gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & gConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
        '        End If
        '        Return ""
        '    End Try
        Using Cmd As New SqlCommand(SQL, Cnn)
            Try
                Ret = Cmd.ExecuteScalar()
                If Ret Is Nothing Then
                    RetValue = ""
                Else
                    If Ret Is Nothing OrElse Ret Is DBNull.Value Then
                        RetValue = ""
                    Else
                        RetValue = Ret
                    End If
                End If
            Catch ex As Exception
                ErrorCount = ErrorCount + 1
                If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                    ResetSQLConnection(Cnn)
                    GoTo er
                End If
                log.Error(ex.Message, ex)
                MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
                If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                    gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & gConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
                End If
            End Try
        End Using
        'End Using
        CloseSQLConnection(Cnn)
        Return RetValue
    End Function

    Public Function gSQLGetSingleValue(SQL As String) As Double
        Dim ErrorCount = 0
        Dim Ret
        Dim RetValue As Double = 0
Er:
        Dim Cnn As SqlConnection = OpenSQLConnection()
        If Cnn Is Nothing Then
            Return 0
        End If

        'Using Cnn As New SqlConnection(gConnectionString)
        '    Try
        '        Cnn.Open()
        '    Catch ex As Exception
        '        ErrorCount = ErrorCount + 1
        '        If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
        '            SqlConnection.ClearPool(Cnn)
        '            SqlConnection.ClearAllPools()
        '            If Cnn.State = ConnectionState.Open Then
        '                Cnn.Close()
        '            End If
        '            Thread.Sleep(500)
        '            GoTo Er
        '        End If
        '        log.Error(ex.Message, ex)
        '        MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
        '        If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
        '            gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & gConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
        '        End If
        '        Return 0
        '    End Try
        Using Cmd As New SqlCommand(SQL, Cnn)
            Try
                Ret = Cmd.ExecuteScalar()
                If Ret Is Nothing OrElse Ret Is DBNull.Value OrElse IsNumeric(Ret) = False Then
                    RetValue = 0
                Else
                    RetValue = Val(Ret)
                End If
            Catch ex As Exception
                ErrorCount = ErrorCount + 1
                If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                    ResetSQLConnection(Cnn)
                    GoTo Er
                End If
                log.Error(ex.Message, ex)
                MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
                If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                    gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & gConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
                End If
            End Try
        End Using
        'End Using
        CloseSQLConnection(Cnn)
        Return RetValue
    End Function

    Public Function gSQLGetSingleValue(SQL As String, connectionString As String) As Double
        Dim ErrorCount = 0
        Dim Ret
        Dim RetValue As Double = 0
er:
        Dim Cnn As SqlConnection = OpenSQLConnection(connectionString)
        If Cnn Is Nothing Then
            Return 0
        End If
        'Using Cnn As New SqlConnection(ConnectionString)
        '    Try
        '        Cnn.Open()
        '    Catch ex As Exception
        '        ErrorCount = ErrorCount + 1
        '        If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
        '            SqlConnection.ClearPool(Cnn)
        '            SqlConnection.ClearAllPools()
        '            If Cnn.State = ConnectionState.Open Then
        '                Cnn.Close()
        '            End If
        '            Thread.Sleep(500)
        '            GoTo er
        '        End If
        '        log.Error(ex.Message, ex)
        '        MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
        '        If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
        '            gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & ConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
        '        End If
        '        Return 0
        '    End Try
        Using Cmd As New SqlCommand(SQL, Cnn)
            Try
                Ret = Cmd.ExecuteScalar()
                If Ret Is Nothing OrElse Ret Is DBNull.Value OrElse IsNumeric(Ret) = False Then
                    RetValue = 0
                Else
                    RetValue = Val(Ret)
                End If
            Catch ex As Exception
                ErrorCount = ErrorCount + 1
                If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                    ResetSQLConnection(Cnn)
                    GoTo er
                End If
                log.Error(ex.Message, ex)
                MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Error")
                If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                    gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & SQL & vbCrLf & connectionString, Nothing, Net.Mail.MailPriority.High, False, True)
                End If
            End Try
        End Using
        'End Using
        CloseSQLConnection(Cnn)
        Return RetValue
    End Function

    Public Function gValidateConnection() As Boolean
        If gConnectionString = "" Then Exit Function
        Using Cnn As New SqlConnection()

            If gConnectionString = "" Then Exit Function
            Cnn.ConnectionString = gConnectionString & "; Connection Timeout=5"
            gValidateConnection = True
            Try
                Cnn.Open()
                CloseSQLConnection(Cnn)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, "Error")
                log.Error(ex.Message, ex)
                If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                    gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & gConnectionString, Nothing, Net.Mail.MailPriority.High, False, True)
                End If
                gValidateConnection = False
            End Try
        End Using
    End Function

    Public Function gValidateConnection(TestString As String) As Boolean
        Using Cnn As New SqlConnection()
            If TestString = "" Then Exit Function
            Cnn.ConnectionString = TestString
            Try
                Cnn.Open()
                CloseSQLConnection(Cnn)
                gConnectionString = TestString
                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, "Error")
                log.Error(ex.Message, ex)
                If (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server.") = False) Then
                    gSendEmail("kolomeyera@gmail.com", "eMedicalOffice Auto Error Handler", gOfficeName & " | " & GetLocalIPAddress() & " | " & GetLocalHostName() & vbCrLf & Now & vbCrLf & ex.Message & vbCrLf & ex.StackTrace.ToString & vbCrLf & TestString, Nothing, Net.Mail.MailPriority.High, False, True)
                End If
                Return False
            End Try
        End Using
    End Function

End Module