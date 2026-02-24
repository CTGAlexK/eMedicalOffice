Imports System.Configuration
Imports System.IO

Public Class AppConfig
    private ReadOnly ProductName as String
    Public ReadOnly SettingPath as String
    private ReadOnly ExeConfigFileMap = New ExeConfigurationFileMap()
    private ReadOnly MyAppConfig as Configuration
    public Sub New()
        Try
            ProductName = "eMedical Office"
            SettingPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), productName, productName & ".config")
            ExeConfigFileMap.ExeConfigFilename = SettingPath
            MyAppConfig = ConfigurationManager.OpenMappedExeConfiguration(ExeConfigFileMap, ConfigurationUserLevel.None)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            gProcess_Log(ex.Message, ex.StackTrace, False)
        End Try

    End Sub


    Public Function GetValueStr(Key As String, optional DefaultValue As String = "") As String
        Try
            dim ret as String = "" & MyAppConfig.AppSettings.Settings.AllKeys.FirstOrDefault(Function(x) x.Equals(key))
            If ret.Length > 0 Then
                return MyAppConfig.AppSettings.Settings(Key).Value
            Else
                Return DefaultValue
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            gProcess_Log(ex.Message, ex.StackTrace, False)
            Return DefaultValue
        End Try
    End Function
    Public Function GetValueInt(Key As String, optional DefaultValue As Integer? = 0) As Integer?
        Try
            dim ret as String = "" & MyAppConfig.AppSettings.Settings.AllKeys.FirstOrDefault(Function(x) x.Equals(key))
            If ret.Length > 0 Then
                Dim retValue as Integer
                If Integer.TryParse(MyAppConfig.AppSettings.Settings(Key).Value, retValue) Then
                    return retValue
                else
                    Return DefaultValue
                end If
            Else
                Return DefaultValue
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            gProcess_Log(ex.Message, ex.StackTrace, False)
            Return DefaultValue
        End Try
    End Function
    Public Function GetValueBool(Key As String, optional DefaultValue As Boolean? = false) As Boolean?
        Try
            dim ret as String = "" & MyAppConfig.AppSettings.Settings.AllKeys.FirstOrDefault(Function(x) x.Equals(key))
            If ret.Length > 0 Then
                Dim retIntValue as Boolean
                Dim retBoolValue as Boolean
                If Integer.TryParse(MyAppConfig.AppSettings.Settings(Key).Value, retIntValue) Then
                    return Convert.ToBoolean(retIntValue)
                End If
                If Boolean.TryParse(MyAppConfig.AppSettings.Settings(Key).Value, retBoolValue) Then
                    return retBoolValue
                else
                    Return DefaultValue
                end If
            Else
                Return DefaultValue
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            gProcess_Log(ex.Message, ex.StackTrace, False)
            Return DefaultValue

        End Try
    End Function
    Public Function GetValueDbl(Key As String, optional DefaultValue as Double? = Nothing) as Double?
        Try
            dim ret as String = "" & MyAppConfig.AppSettings.Settings.AllKeys.FirstOrDefault(Function(x) x.Equals(key))
            If ret.Length > 0 Then
                Dim retValue as Double
                If Double.TryParse(MyAppConfig.AppSettings.Settings(Key).Value, retValue) Then
                    return retValue
                else
                    Return DefaultValue
                end If
            Else
                Return DefaultValue
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            gProcess_Log(ex.Message, ex.StackTrace, False)
            Return DefaultValue

        End Try
    End Function

    public Function SaveSetting(Key As String, value As String) As Boolean
        Try
            dim ret as String = "" & MyAppConfig.AppSettings.Settings.AllKeys.FirstOrDefault(Function(x) x.Equals(key))
            if ret.Length = 0 Then
                MyAppConfig.AppSettings.Settings.Add(key, value)
            else
                MyAppConfig.AppSettings.Settings.Item(key).Value = value
            end If
            MyAppConfig.Save(ConfigurationSaveMode.Modified)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            gProcess_Log(ex.Message, ex.StackTrace, False)
            return False
        End Try
    End Function
    public Function DeleteAllSetting() As Boolean
        Try
            dim ret as String() = MyAppConfig.AppSettings.Settings.AllKeys
            For Each s As String In ret
                MyAppConfig.AppSettings.Settings.Remove(s)
            Next
            MyAppConfig.Save(ConfigurationSaveMode.Modified)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            gProcess_Log(ex.Message, ex.StackTrace, False)
            return False
        End Try
    End Function
    public Function DeleteSetting(Key) As Boolean
        Try
            dim ret as String = "" & MyAppConfig.AppSettings.Settings.AllKeys.FirstOrDefault(Function(x) x.Equals(key))
            if ret.Length > 0 Then
                MyAppConfig.AppSettings.Settings.Remove(ret)
            end If
            MyAppConfig.Save(ConfigurationSaveMode.Modified)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            gProcess_Log(ex.Message, ex.StackTrace, False)
            return False
        End Try
    End Function
End Class
