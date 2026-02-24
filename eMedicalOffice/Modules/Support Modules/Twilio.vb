Imports System.Reflection
Imports System.Web
Imports log4net
imports Twilio
imports Twilio.Rest.Api.V2010.Account
imports Twilio.Types

Module Twilio
    private readonly log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Public Function gSendSMSMessage(DestPhoneNumber As String, msg As String) As String
        DestPhoneNumber = DestPhoneNumber.Trim()
        If DestPhoneNumber.Length = 0 Then Return False
        DestPhoneNumber = CleanUpPhoneNumber(DestPhoneNumber)
        Dim message As MessageResource
        If DestPhoneNumber = "" Or gTwilioFromPhoneNumber = "" Or gTwilioAccountSid = "" Or gTwilioAuthToken = "" Then
            return "Incomplete SMS Information."
        End If
      
        Try
            TwilioClient.Init(gTwilioAccountSid, gTwilioAuthToken)
            dim toNumber = New PhoneNumber(DestPhoneNumber)
            Dim fromNumber = New PhoneNumber(gTwilioFromPhoneNumber)
            message = MessageResource.Create([to] := toNumber,  from := fromNumber, body := msg)

            If message Is Nothing Then
                log.Error("Twilio Error. Failed to send twilio message")
                Return "Twilio Error. Failed to send twilio message"
            End If
            If Not message.ErrorCode Is Nothing Then

                log.Error("Twilio Error. " + message.ErrorMessage)
                Return message.ErrorMessage
            End If

        Catch ex As Exception
            log.Error(ex.Message,ex)
            Return ex.Message
        End Try
        Return ""
    End Function
    Public Function gSendVoiceMessage(DestPhoneNumber As String, msg As String) As String
        DestPhoneNumber = DestPhoneNumber.Trim()
        If DestPhoneNumber.Length = 0 Then Return False
        DestPhoneNumber = CleanUpPhoneNumber(DestPhoneNumber)
        Dim message As MessageResource
        If DestPhoneNumber = "" Or gTwilioFromPhoneNumber = "" Or gTwilioAccountSid = "" Or gTwilioAuthToken = "" or gTwilioBin="" Then
            return "Incomplete Voice Message Information."
        End If
        ' Before using this code, the Bin should be created on
         ' https://www.twilio.com/console/dev-tools/twiml-bins
        ' After login in to  the registered account

        Try
            TwilioClient.Init(gTwilioAccountSid, gTwilioAuthToken)
            dim toNumber = New PhoneNumber(DestPhoneNumber)
            Dim fromNumber = New PhoneNumber(gTwilioFromPhoneNumber)
            Dim url = gTwilioBin + "?message=" + msg
            dim twimlUri = new Uri(url)
            CallResource.Create(toNumber, fromNumber, url : = twimlUri)
        Catch ex As Exception
            log.Error(ex.Message,ex)
            Return ex.Message
        End Try
        Return ""
    End Function
    Private Function CleanUpPhoneNumber(strPhoneNumber As String) As String
        Dim tempString As String
        tempString = Replace(strPhoneNumber, ")", "")
        tempString = Replace(tempString, "(", "")
        tempString = Replace(tempString, "-", "")
        tempString = Replace(tempString, ".", "")
        tempString = Replace(tempString, "X", "")
        tempString = Replace(tempString, "x", "")
        tempString = Replace(tempString, " ", "")
        Return tempString
    End Function

End Module
