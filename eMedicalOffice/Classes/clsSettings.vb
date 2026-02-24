Imports System.Reflection
Imports log4net

Public Class SettingsDB
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public ReadOnly HardwareIdentifier As String
    Private ReadOnly PCName As String
    Private _settingsConnection As String = My.Settings.SettingsConnectionString
    Private _cacheSettings As Hashtable
    Private SyncRoot As Object = New Object()

    Public Enum DeleteSettingType
        Database = 0
        Cache = 1
        Both = 2
    End Enum

    Public Sub New()
        Try
            PCName = gGetIPInfo.HostName.ToString().ToSafeSQLString()
            HardwareIdentifier = GetHardwareIDentifier()
            _cacheSettings = New Hashtable()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
        End Try
    End Sub

#Region "Assistance Methods"

    Private Function _checkConnection(methodName As String) As Boolean
        If String.IsNullOrWhiteSpace(_settingsConnection) Then
            MsgBox("Unable to load system settings. The Database ConnectionString is not set.", MsgBoxStyle.Exclamation)
            log.Error(methodName + ": Unable to load system settings. The Database ConnectionString is not set.")
            Return False
        Else
            Return True
        End If
    End Function

    Public Function _getSettingFromDB(Of T)(Key As String, defaultValue As T) As T
        If _checkConnection("GetValueStr") = False Then Return defaultValue
        Dim Ret
        Try
            Dim SQL As String = "SELECT SettingValue from SystemSettings Where IDentifier = '" & HardwareIdentifier & "' and SettingName = '" & Key.ToSafeSQLString() & "'"
            Ret = gSQLGetValue(SQL, _settingsConnection)
            If Ret Is Nothing Then
                Return defaultValue
            Else
                If Ret Is Nothing OrElse Ret Is DBNull.Value Then
                    Return defaultValue
                Else
                    Return DirectCast(Ret, T)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
            Return defaultValue
        End Try
    End Function

    Private Function _saveSettingToDB(Key As String, Value As String) As Boolean
        If _checkConnection("GetValueStr") = False Then Return False
        Dim SQL As String
        SQL = "IF EXISTS(select * from SystemSettings Where IDentifier = '" & HardwareIdentifier & "' and SettingName = '" & Key.ToSafeSQLString() & "') " & vbCrLf
        SQL &= "BEGIN " & vbCrLf
        SQL &= "    UPDATE SystemSettings set SettingValue  = '" & Value.ToString().ToSafeSQLString() & "', SettingDateTime = GetDate(), PCName = '" & PCName.ToSafeSQLString() & "' Where IDentifier = '" & HardwareIdentifier & "' and SettingName = '" & Key.ToSafeSQLString() & "' "
        SQL &= "END " & vbCrLf
        SQL &= "ELSE " & vbCrLf
        SQL &= "BEGIN " & vbCrLf
        SQL &= "   INSERT INTO SystemSettings (IDentifier, SettingName, SettingValue, SettingDateTime,PCName) VALUES ('" & HardwareIdentifier.ToSafeSQLString() & "','" & Key.ToSafeSQLString() & "','" & Value.ToString().ToSafeSQLString() & "',GetDate(),'" & PCName.ToSafeSQLString() & "') "
        SQL &= "END " & vbCrLf
        Try
            Return gSQLUpdateData(SQL, _settingsConnection)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
            Return False
        End Try
    End Function

    Private Function _saveSetting(Key As String, value As String) As Boolean
        SyncLock SyncRoot
            _cacheSettings(Key) = value.ToString()
        End SyncLock
        If My.Settings.SettingsDBRealTimeSync = True Then
            _saveSettingToDB(Key, value.ToString)
        End If
        Return True
    End Function

#End Region

    Public Property DefaultConnection() As String
        Get
            Return _settingsConnection
        End Get
        Set(ByVal value As String)
            _settingsConnection = value
        End Set
    End Property

    Public Function GetSetting(Key As String, defaultValue As Object) As String
        SyncLock SyncRoot
            If Not _cacheSettings.ContainsKey(Key) Then
                Dim val = _getSettingFromDB(Key, defaultValue)
                _cacheSettings(Key) = val.ToString()
                Return val
            End If
            Return _cacheSettings(Key).ToString()
        End SyncLock
    End Function

    Public Property StrValue(Key As String, Optional DefaultValue As String = Nothing) As String
        Get
            Return GetSetting(Key, DefaultValue)
        End Get
        Set(ByVal Value As String)
            _saveSetting(Key, Value)
        End Set
    End Property

    Public Property IntValue(Key As String, Optional DefaultValue As Integer? = Nothing) As Integer?
        Get

            Dim ret = GetSetting(Key, DefaultValue.ToString())
            Dim ValOut
            If Integer.TryParse(ret, ValOut) Then
                Return ValOut
            Else
                Return DefaultValue
            End If
        End Get
        Set(ByVal Value As Integer?)
            _saveSetting(Key, Value.ToString())
        End Set
    End Property

    Public Property BoolValue(Key As String, Optional DefaultValue As Boolean? = Nothing) As Boolean?
        Get
            Dim ret = GetSetting(Key, DefaultValue)
            Dim ValOut
            If Boolean.TryParse(ret, ValOut) Then
                Return ValOut
            Else
                Return DefaultValue
            End If
        End Get
        Set(ByVal Value As Boolean?)
            _saveSetting(Key, Value.ToString())
        End Set
    End Property

    Public Property DblValue(Key As String, Optional DefaultValue As Double? = Nothing) As Double?
        Get
            Dim ret = GetSetting(Key, DefaultValue)
            Dim ValOut
            If Double.TryParse(ret, ValOut) Then
                Return ValOut
            Else
                Return DefaultValue
            End If
        End Get
        Set(ByVal Value As Double?)
            _saveSetting(Key, Value)
        End Set
    End Property

    Public Function SaveAll() As Boolean
        If _checkConnection("GetValueStr") = False Then Return False
        Try
            Dim Enumerator As IDictionaryEnumerator
            Enumerator = _cacheSettings.GetEnumerator()
            If _cacheSettings.Count = 0 Then Return True
            While Enumerator.MoveNext
                _saveSettingToDB(Enumerator.Key.ToString(), Enumerator.Value.ToString)
            End While
            'For Each entry In Data
            '    _saveSettingToDB(entry.Key.ToString(), entry.Value.ToString)
            'Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
            Return False
        End Try
    End Function

    Public Function DeleteSettings(Optional Type As DeleteSettingType = DeleteSettingType.Both, Optional Key As String = "") As Boolean
        Try
            If Type = DeleteSettingType.Cache Or Type = DeleteSettingType.Both Then
                If String.IsNullOrWhiteSpace(Key) = True Then
                    _cacheSettings.Clear()
                Else
                    If _cacheSettings.ContainsKey(Key) Then
                        _cacheSettings.Remove(Key)
                    End If
                End If
            End If
            If Type = DeleteSettingType.Database Or Type = DeleteSettingType.Both Then
                Dim SQL As String
                If _checkConnection("GetValueStr") = False Then Return False
                If String.IsNullOrWhiteSpace(Key) = True Then
                    SQL = " DELETE FROM SystemSettings Where IDentifier = '" & HardwareIdentifier & "' "
                Else
                    SQL = " DELETE FROM SystemSettings Where IDentifier = '" & HardwareIdentifier & "' and SettingName = '" & Key.ToSafeSQLString() & "' "
                End If
                Return gSQLDeleteRecord(SQL, _settingsConnection)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
            Return False
        End Try
    End Function

    Public Function LoadAll() As Boolean
        Dim Reader As SqlClient.SqlDataReader
        If _checkConnection("GetValueStr") = False Then Return False
        Dim Sql As String = "SELECT SettingName, SettingValue from SystemSettings Where IDentifier = '" & HardwareIdentifier & "'"
        Try
            _cacheSettings.Clear()
            Reader = gSQLGetDataReader(Sql, _settingsConnection)
            If Reader Is Nothing Then Return False
            Do Until Reader.Read = False
                _cacheSettings(Reader("SettingName").ToString()) = Reader("SettingValue").ToString()
            Loop
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
            Return False
        End Try
    End Function

End Class