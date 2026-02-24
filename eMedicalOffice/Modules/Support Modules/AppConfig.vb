Imports System.Configuration
Imports System.IO
Imports System.Reflection
Imports log4net

Public Class AppConfig
    Private ReadOnly ProductName As String
    Public ReadOnly SettingPath As String
    Private ReadOnly ExeConfigFileMap = New ExeConfigurationFileMap()
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private MyAppConfig As Configuration
    Public Sub New()
        Try
            ProductName = My.Application.Info.ProductName
            SettingPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), ProductName, ProductName & ".config")
            ExeConfigFileMap.ExeConfigFilename = SettingPath
            MyAppConfig = GetConfiguration()
            'MyAppConfig = ConfigurationManager.OpenMappedExeConfiguration(ExeConfigFileMap, ConfigurationUserLevel.None)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
        End Try

    End Sub

    Public Function GetValueStr(Key As String, Optional DefaultValue As String = "") As String
        Dim RetValue As String
        'Dim MyAppConfig As Configuration = GetConfiguration()
        Try
            Dim ret As String = "" & MyAppConfig.AppSettings.Settings.AllKeys.FirstOrDefault(Function(x) x.Equals(Key))
            If ret.Length > 0 Then
                RetValue = MyAppConfig.AppSettings.Settings(Key).Value
            Else
                RetValue = DefaultValue
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
            RetValue = DefaultValue
        End Try
        Return RetValue
    End Function

    Public Function GetValueInt(Key As String, Optional DefaultValue As Integer? = 0) As Integer?
        Dim RetValue As Integer
        'Dim MyAppConfig As Configuration = GetConfiguration()

        Try
            Dim ret As String = "" & MyAppConfig.AppSettings.Settings.AllKeys.FirstOrDefault(Function(x) x.Equals(Key))
            If ret.Length > 0 Then
                Dim retIntValue As Integer
                If Integer.TryParse(MyAppConfig.AppSettings.Settings(Key).Value, retIntValue) Then
                    RetValue = retIntValue
                Else
                    RetValue = DefaultValue
                End If
            Else
                RetValue = DefaultValue
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
            RetValue = DefaultValue
        End Try
        Return RetValue
    End Function

    Public Function BackupConfiguration() As Configuration
        Try
            'Dim MyAppConfig As Configuration = ConfigurationManager.OpenMappedExeConfiguration(ExeConfigFileMap, ConfigurationUserLevel.None)
            Dim fName As String
            Dim BackupFile As String
            If MyAppConfig.AppSettings.Settings.AllKeys.Count() = 0 Then
                Throw New System.Exception("AppSettings is Corrupted: " & ExeConfigFileMap.ExeConfigFilename)
            End If
            fName = ExeConfigFileMap.ExeConfigFilename
            BackupFile = Replace(fName, "config", "backup")
            File.Copy(fName, BackupFile, True)
            log.Debug("Config file backup complete: " & BackupFile)
        Catch ex As Exception
            log.Error("BackupConfiguration", ex)
        End Try
    End Function

    Public Function RecoverConfiguration() As Boolean
        Try
            Dim fName As String
            Dim BackupFile As String
            log.Debug("RecoverConfiguration")
            fName = ExeConfigFileMap.ExeConfigFilename
            BackupFile = Replace(fName, "config", "backup")
            If File.Exists(BackupFile) Then
                If File.Exists(fName) Then
                    File.Copy(fName, fName & " corrupted. " & Now.Month & "-" & Now.Day & "-" & Now.Year & " " & Now.Hour & "-" & Now.Minute)
                    File.Delete(fName)
                End If
                File.Copy(BackupFile, fName, True)
                log.Debug("RecoverConfiguration: File Recovered: " & BackupFile)
                Dim MyAppConfig As Configuration = ConfigurationManager.OpenMappedExeConfiguration(ExeConfigFileMap, ConfigurationUserLevel.None)
                Return True
            Else
                If File.Exists(ExeConfigFileMap.ExeConfigFilename) = True Then
                    log.Debug("RecoverConfiguration: Backup File not exists: " & BackupFile)
                    MsgBox("The Application config file not exists or has been corrupted. Auto recovery is not possible. Please contact system administrator.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Critical, "Critical Error")
                    Return False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Critical Error.")
            log.Error("RecoverConfiguration", ex)
            Return False
        End Try
    End Function

    Public Function GetConfiguration() As Configuration
        Try
            If File.Exists(ExeConfigFileMap.ExeConfigFilename) = False Then
                Throw New System.Exception("AppSettings File Is missing: " & ExeConfigFileMap.ExeConfigFilename)
            End If
            Dim MyAppConfig As Configuration = ConfigurationManager.OpenMappedExeConfiguration(ExeConfigFileMap, ConfigurationUserLevel.None)
            If MyAppConfig.AppSettings.Settings.AllKeys.Count() = 0 Then
                Throw New System.Exception("AppSettings is Corrupted: " & ExeConfigFileMap.ExeConfigFilename)
            End If
            Return MyAppConfig
        Catch ex As Exception
            log.Error("GetConfiguration", ex)
            RecoverConfiguration()
            ' Create a new config even if recovery not succesfull
            Dim MyAppConfig As Configuration = ConfigurationManager.OpenMappedExeConfiguration(ExeConfigFileMap, ConfigurationUserLevel.None)
            Return MyAppConfig
            'If RecoverConfiguration() Then
            '    Dim MyAppConfig As Configuration = ConfigurationManager.OpenMappedExeConfiguration(ExeConfigFileMap, ConfigurationUserLevel.None)
            '    Return MyAppConfig
            'Else
            '    End
            'End If

        End Try
    End Function

    Public Function GetValueBool(Key As String, Optional DefaultValue As Boolean? = False) As Boolean?
        Dim RetValue As Boolean?
        'Dim MyAppConfig As Configuration = GetConfiguration()

        Try
            Dim ret As String = "" & MyAppConfig.AppSettings.Settings.AllKeys.FirstOrDefault(Function(x) x.Equals(Key))
            If ret.Length > 0 Then
                Dim retIntValue As Boolean
                Dim retBoolValue As Boolean
                If Integer.TryParse(MyAppConfig.AppSettings.Settings(Key).Value, retIntValue) Then
                    RetValue = Convert.ToBoolean(retIntValue)
                ElseIf Boolean.TryParse(MyAppConfig.AppSettings.Settings(Key).Value, retBoolValue) Then
                    RetValue = retBoolValue
                Else
                    RetValue = DefaultValue
                End If
            Else
                RetValue = DefaultValue
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
            RetValue = DefaultValue
        End Try
        Return RetValue
    End Function

    Public Function GetValueDbl(Key As String, Optional DefaultValue As Double? = Nothing) As Double?
        Dim RetValue As Double
        'Dim MyAppConfig As Configuration = GetConfiguration()

        Try
            Dim ret As String = "" & MyAppConfig.AppSettings.Settings.AllKeys.FirstOrDefault(Function(x) x.Equals(Key))
            If ret.Length > 0 Then
                Dim retDblValue As Double
                If Double.TryParse(MyAppConfig.AppSettings.Settings(Key).Value, retDblValue) Then
                    RetValue = retDblValue
                Else
                    RetValue = DefaultValue
                End If
            Else
                RetValue = DefaultValue
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
            RetValue = DefaultValue

        End Try
        Return RetValue
    End Function

    Public Function SaveSetting(Key As String, value As String, Optional ContinueSaving As Boolean = False) As Boolean
        Dim RetValue As Boolean

        Try

            Dim ret As String = "" & MyAppConfig.AppSettings.Settings.AllKeys.FirstOrDefault(Function(x) x.Equals(Key))
            If ret.Length = 0 Then
                MyAppConfig.AppSettings.Settings.Add(Key, value)
            Else
                MyAppConfig.AppSettings.Settings.Item(Key).Value = value
            End If
            If Not ContinueSaving Then MyAppConfig.Save(ConfigurationSaveMode.Modified)
            Application.DoEvents()
            RetValue = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
            RetValue = False
        End Try
        Return RetValue
    End Function
    Public Function SaveSettingToFile() As Boolean
        Dim RetValue As Boolean
        'Dim MyAppConfig As Configuration = GetConfiguration()
        Try
            MyAppConfig.Save(ConfigurationSaveMode.Modified)
            RetValue = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
            RetValue = False
        End Try
        Return RetValue
    End Function

    Public Function DeleteAllSetting() As Boolean
        Dim RetValue As Boolean
        'Dim MyAppConfig As Configuration = GetConfiguration()
        Try
            Dim ret As String() = MyAppConfig.AppSettings.Settings.AllKeys
            For Each s As String In ret
                MyAppConfig.AppSettings.Settings.Remove(s)
            Next
            MyAppConfig.Save(ConfigurationSaveMode.Modified)
            RetValue = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
            RetValue = False
        End Try
        Return RetValue
    End Function

    Public Function DeleteSetting(Key) As Boolean
        Dim RetValue As Boolean
        'Dim MyAppConfig As Configuration = GetConfiguration()
        Try
            Dim ret As String = "" & MyAppConfig.AppSettings.Settings.AllKeys.FirstOrDefault(Function(x) x.Equals(Key))
            If ret.Length > 0 Then
                MyAppConfig.AppSettings.Settings.Remove(ret)
            End If
            MyAppConfig.Save(ConfigurationSaveMode.Modified)
            RetValue = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            log.Error(ex)
            RetValue = False
        End Try
        Return RetValue
    End Function

End Class