Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Reflection
Imports log4net

Module Email
    Dim SmtpServer As New SmtpClient()
    Private ReadOnly log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public Function gSendEmail(ToAddress As String, Subject As String, Body As String, Attachements() As String, Optional ByVal Priority As MailPriority = MailPriority.Normal, Optional ByVal IsBodyHtml As Boolean = False, Optional ByVal Silent As Boolean = False) As Boolean
        Try
            If ToAddress.ToUpper() = "KOLOMEYERA@GMAIL.COM" And Body.ToUpper().Contains("A NETWORK-RELATED OR INSTANCE-SPECIFIC ERROR") = True Then
                Return True
            End If


            If ToAddress = "" Then
                Return False
            End If
            If gSMTPUID = "" Then
                If Silent = False Then MsgBox("Unable to send Email. The SMTP User Name is not specified." & vbCrLf & "Please use the Office Maintenance Function to fix tis problem.", MsgBoxStyle.Critical)
                Return False
            End If
            If gSMTPPWD = "" Then
                If Silent = False Then MsgBox("Unable to send Email. The SMTP User Password is not specified." & vbCrLf & "Please use the Office Maintenance Function to fix tis problem.", MsgBoxStyle.Critical)
                Return False
            End If
            If gSMTPHost = "" Then
                If Silent = False Then MsgBox("Unable to send Email. The SMTP Host is not specified." & vbCrLf & "Please use the Emailer Office Function to fix tis problem.", MsgBoxStyle.Critical)
                Return False
            End If
            If gSMTPFromAddress = "" Then
                If Silent = False Then MsgBox("Unable to send Email. The From Email Address is not specified." & vbCrLf & "Please use the Office Maintenance Function to fix tis problem.", MsgBoxStyle.Critical)
                Return False
            End If
            If gEmailCheck(ToAddress) = False Then
                Return False
            End If


            SmtpServer = New SmtpClient()
            '''' TEST            
            'gSMTPUID = "kolomeyera@gmail.com"
            'gSMTPPWD = "koloal3055"
            SmtpServer.UseDefaultCredentials = False
            SmtpServer.Credentials = New NetworkCredential(gSMTPUID, gSMTPPWD)
            If gSMTPPort <> 0 Then SmtpServer.Port = gSMTPPort
            SmtpServer.Host = gSMTPHost
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network
            If gSMTPPort = 25 Then
                SmtpServer.EnableSsl = False
            Else
                SmtpServer.EnableSsl = True
            End If
            'SmtpServer.Credentials = New NetworkCredential(gSMTPUID, gSMTPPWD)

            Dim mail = New MailMessage()
            'TEST
            mail.From = New MailAddress(gSMTPFromAddress)
            mail.To.Add(New MailAddress(ToAddress))
            mail.Subject = Subject
            mail.IsBodyHtml = IsBodyHtml
            mail.Body = Body
            Dim userState As String = ToAddress.ToString


            mail.Priority = Priority
            If (Not Attachements Is Nothing) Then
                For Each strFile As String In Attachements
                    If File.Exists(strFile) Then mail.Attachments.Add(New Attachment(strFile))
                Next
            End If
            MDIForm1Win8.lblStatus.Text = ""
            SmtpServer.Timeout = 30000
            If CInt(Val(gSMTPAsync)) = 1 Then
                If gDebugMode Then
                    log.Debug("Email System Email: Async, SMTPHost: " & gSMTPHost & " SMTPPort: " & gSMTPPort & " SMTPUID: " & gSMTPUID & " SMTPPWD: " & gSMTPPWD & " has been sent on " & Now & ".")
                End If
                AddHandler SmtpServer.SendCompleted, AddressOf EmailAsyncCompleteEvent
                MDIForm1Win8.lblStatus.Text = $"   Message / Fax In Progress..."
                SmtpServer.SendAsync(mail, userState)
            Else
                log.Debug("Email System Email: SMTPHost: " & gSMTPHost & " SMTPPort: " & gSMTPPort & " SMTPUID: " & gSMTPUID & " SMTPPWD: " & gSMTPPWD & " has been sent on " & Now & ".")
                MDIForm1Win8.lblStatus.Text = $"   Message / Fax In Progress..."
                SmtpServer.Send(mail)
                mail.Attachments.Clear()
                SmtpServer = Nothing
                MDIForm1Win8.lblStatus.Text = $"   Message / Fax Sent"
            End If
            Return True
        Catch ex As Exception
            SmtpServer = Nothing
            log.Debug("Email System Email: SMTPHost: " & gSMTPHost & " SMTPPort: " & gSMTPPort & " SMTPUID: " & gSMTPUID & " SMTPPWD: " & gSMTPPWD & " failed on " & Now & ".")
            Return False
        End Try
    End Function
    Private Sub EmailAsyncCompleteEvent(sender As Object, e As AsyncCompletedEventArgs)
        Dim UserState = CStr(e.UserState)
        If e.Error IsNot Nothing Then
            MsgBox("Email / Fax to " & UserState & " failed." & vbCrLf & vbCrLf & vbCrLf & e.Error.ToString(),
                   MsgBoxStyle.Exclamation)
            log.Error(
                UserState & " " & e.Error.ToString() & "Email System Email: SMTPHost: " & gSMTPHost & " SMTPPort: " &
                gSMTPPort & " SMTPUID: " &
                gSMTPUID & " SMTPPWD: " & gSMTPPWD & " Failed on " & Now & ".")
            MDIForm1Win8.lblStatus.Text = $"   Message / Fax Failed"
        Else
            MDIForm1Win8.lblStatus.Text = $"   Message / Fax Sent"
        End If
        SmtpServer = Nothing
    End Sub
End Module
