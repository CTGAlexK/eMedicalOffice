Imports System.ComponentModel
Imports System.IO
Public Class frmMain

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity = 1
        If Me.Opacity >= 1 Then
            Timer1.Enabled = False
            TimerStartProcess.Enabled = True
        End If
    End Sub
    Public Function RightVB6(ByVal SomeStr As String, ByVal pLen As Integer) As String
        If pLen > SomeStr.Length Then
            RightVB6 = SomeStr
        Else
            RightVB6 = SomeStr.Substring(SomeStr.Length - pLen, pLen)
        End If

    End Function
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'RunOnce = GetSetting("eMedical Office", "AutoUpdate", "RunOnce", "")
       

        'If RunOnce = "" Then
        '    MsgBox("The AutoUpdate system can not be run manually." & vbCrLf & "This file is required by eMedical Office to process system updates.", MsgBoxStyle.Critical)
        '    gProcess_Log("The AutoUpdate system can not be run manually." & vbCrLf & "This file is required by eMedical Office to process system updates.", "", False)
        '    End
        'End If
        SysAdminUID = GetSetting("eMedical Office", "AutoUpdate", "SysAdminUID", "")
        SysAdminPWD = GetSetting("eMedical Office", "AutoUpdate", "SysAdminPWD", "")
        gAppPath = Application.StartupPath
        If gAppPath.EndsWith("\")=False Then gAppPath = gAppPath & "\"
        CopyFrom = GetSetting("eMedical Office", "AutoUpdate", "CopyFrom", "")
        'CopyFrom = "\\192.168.112.15\Updates\eMedicalOffice.exe"
        CopyTo = GetSetting("eMedical Office", "AutoUpdate", "CopyTo", "")
        'CopyTo = "D:\DESKTOP\eMedicalOffice.exe"
        OldVersion = GetSetting("eMedical Office", "AutoUpdate", "OldVersion", "")
        NewVersion = GetSetting("eMedical Office", "AutoUpdate", "NewVersion", "")

        If SysAdminUID.Trim()="" then SysAdminUID=gAppConfig.GetValueStr("SysAdminUID","")
        If SysAdminPWD.Trim() = "" Then SysAdminPWD = gAppConfig.GetValueStr("SysAdminPWD", "")
        If CopyFrom.Trim() = "" Then CopyFrom = gAppConfig.GetValueStr("CopyFrom", "")
        If CopyTo.Trim() = "" Then CopyTo = gAppConfig.GetValueStr("CopyTo", "")
        If OldVersion.Trim() = "" Then OldVersion = gAppConfig.GetValueStr("OldVersion", "")
        If NewVersion.Trim() = "" Then NewVersion = gAppConfig.GetValueStr("NewVersion", "")


        Application.DoEvents



        lblMsg.Text = "The new version of eMedical Office has been released." & vbCrLf & vbCrLf & "Current Version:  " & OldVersion & vbCrLf & "New Version:  " & NewVersion & vbCrLf & vbCrLf & vbCrLf & "Processing Update. Please wait..." & vbCrLf & vbCrLf & "eMedical Office will be restarted...."
        lblMsg.Refresh()
        lblProgress.Text = "Initializing Update Engine..."
        Application.DoEvents()
        Application.DoEvents()
        Timer1.Enabled = True
    End Sub

    Private Sub lblMsg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMsg.Click
    End Sub
    Private Updated As Boolean
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        SaveSetting("eMedical Office", "AutoUpdate", "RunOnce", "")
        gAppConfig.SaveSetting("RunOnce","")
        If Updated Then
            'My.Computer.Audio.Play(My.Resources.UpdateComplete, AudioPlayMode.WaitToComplete)
           
            System.Diagnostics.Process.Start(CopyTo)
        End If
        Application.DoEvents()
        Me.Close()
        End
    End Sub

    Private Sub TimerStartProcess_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerStartProcess.Tick
        TimerStartProcess.Enabled = False
        If CopyFrom = "" Then
            MsgBox("Unable to process autoupdate." & vbCrLf & "Error: The required parameter [CopyFrom] is missing", MsgBoxStyle.Critical)
            gProcess_Log("Unable to process autoupdate." & vbCrLf & "Error: Parameter [CopyFrom] is missing", "", False)
            End
        End If
        lblProgress.Text = "Validate source file. Please wait..."
        lblProgress.Refresh()
        If File.Exists(CopyFrom) = False Then
            MsgBox("Unable to process autoupdate." & vbCrLf & "Error: The Update File " & CopyFrom & vbCrLf & " does not exist or not accessible.", MsgBoxStyle.Critical)
            gProcess_Log("Unable to process autoupdate." & vbCrLf & "Error: The Update File " & CopyFrom & vbCrLf & " does not exist or not accessible.", "", False)
            End
        End If

        If CopyTo = "" Then
            MsgBox("Unable to process autoupdate." & vbCrLf & "Error: The required parameter [CopyTo] is missing", MsgBoxStyle.Critical)
            gProcess_Log("Unable to process autoupdate." & vbCrLf & "Error: Parameter [CopyTo] is missing", "", False)
            End
        End If
        lblProgress.Text = "Validate destination file. Please wait..."
        lblProgress.Refresh()
        If File.Exists(CopyTo) = False Then
            MsgBox("Unable to process autoupdate." & vbCrLf & "Error: The File " & CopyTo & vbCrLf & " does not exist or not accessible.", MsgBoxStyle.Critical)
            gProcess_Log("Unable to process autoupdate." & vbCrLf & "Error: The File " & CopyTo & " does not exist or not accessible.", "", False)
            End
        End If

        My.Computer.Audio.Play(My.Resources.AutoUpdate, AudioPlayMode.Background)
        Updated = StartProcess()
        Timer2.Enabled = True
    End Sub

    
End Class
