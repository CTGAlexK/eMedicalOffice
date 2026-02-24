
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices.WindowsRuntime
Imports log4net
Imports Microsoft.Win32

Public Class _Startup
    Private MouseDownX As Integer
    Private MouseDownY As Integer
    Private IsFormBeingDragged As Boolean = False
    Private ReadOnly productName As String = My.Application.Info.ProductName

    Private ReadOnly _
        settingpath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                                             productName, productName & ".config")

    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub _Startup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        log.Debug(settingpath)
        'execonfigfilemap.ExeConfigFilename = settingpath
        'MyAppConfig = ConfigurationManager.OpenMappedExeConfiguration(execonfigfilemap, ConfigurationUserLevel.None)


        'dim ret as String = "" &
        '                    MyAppConfig.AppSettings.Settings.AllKeys.FirstOrDefault(
        '                        Function (x) x.Equals("MultiOfficeMode"))
        'dim retValue
        'If ret.Length > 0 Then
        '    retValue = MyAppConfig.AppSettings.Settings("MultiOfficeMode").Value
        'End If
        If Not gMultiOfficeMode Is Nothing Then
            Dim frm As Form
            If gMultiOfficeMode Then
                frm = New frmSplashMultiOfficeNew
                frm.ShowDialog()
                frm.Dispose()
                frm = Nothing
            Else
                frm = New frmSplashNew
                frm.ShowDialog()
                frm.Dispose()
                frm = Nothing
            End If
            log.Debug("Application started in " & IIf(gMultiOfficeMode, " MultiOffice", "Single Office") & " mode")
            Close()
            Dispose()
        Else
            log.Debug("First Time Runnig. Config File: " + settingpath)
            My.Computer.Audio.Play(My.Resources.Welcome, AudioPlayMode.Background)
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Opacity = Me.Opacity + 0.04
        If Opacity >= 1 Then
            Timer1.Enabled = False
            PanelLogin.Visible = True

        End If
    End Sub

    Private Sub _Startup_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
            Cursor = Cursors.SizeAll
        End If
    End Sub

    Private Sub _Startup_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()
            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub _Startup_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        End
    End Sub

    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        dummy.Focus()
        Dim mode As String = "Multiple Office mode."
        gMultiOfficeMode = True
        If RadioButton1.Checked Then
            mode = " Sigle Office mode."
            gMultiOfficeMode = False
        End If
        If _
            MsgBox("Please confirm you want to setup eMedicalOffice in " & vbCrLf & vbCrLf & mode,
                   MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Welcome") = MsgBoxResult.No Then
            Return
        End If
        log.Debug("Application will run as " + mode + ".Config File: " + settingpath)
        gAppConfig.SaveSetting("MultiOfficeMode", gMultiOfficeMode)
        'MyAppConfig.AppSettings.Settings.Add("MultiOfficeMode", gMultiOfficeMode)
        'MyAppConfig.Save(ConfigurationSaveMode.Modified)
        Opacity = 0
        Dim frm As Form
        If gMultiOfficeMode Then
            frm = New frmSplashMultiOfficeNew
            frm.ShowDialog()
            frm.Dispose()
            frm = Nothing
        Else
            frm = New frmSplashNew
            frm.ShowDialog()
            frm.Dispose()
            frm = Nothing
        End If
        Close()
        Dispose()
    End Sub
End Class