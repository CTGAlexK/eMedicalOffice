Imports System

Imports System.Runtime.InteropServices

Imports System.IO
Imports System.Reflection
Imports log4net

Class SendFileTo
    Private log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private Const SWP_NOSIZE = &H1
    Private Const SWP_NOMOVE = &H2
    Private Const HWND_TOPMOST = -1
    Private Const MAPI_LOGON_UI As Integer = &H1

    Private Const MAPI_DIALOG As Integer = &H8
    Private lAttachmentFileNames() As String, lSubject As String, lBody As String, lRecepient As String
    Public Declare Function SetWindowPos Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As Long) As Boolean

    Public Function SendMail(ByVal strAttachmentFileName As String, ByVal strSubject As String, ByVal Body As String, Optional ByVal Recepient As String = "", Optional ByVal Async As Boolean = True) As Boolean
            Dim stringArray(0) as String 
            stringArray(0) = strAttachmentFileName
            Return SendMail(stringArray, strSubject, Body , Recepient , Async)
    End Function
    Public Function SendMail(ByVal strArrayAttachmentFileNames() As String, ByVal strSubject As String, ByVal Body As String, Optional ByVal Recepient As String = "", Optional ByVal Async As Boolean = True) As Boolean
        lAttachmentFileNames=strArrayAttachmentFileNames

        lSubject = strSubject
        lBody = Body
        lRecepient = Recepient

        If gSendEmail(lRecepient, lSubject, lBody, lAttachmentFileNames, Net.Mail.MailPriority.High, True, True) = True Then
            Return True
        End If

        Dim T As New Threading.Thread(AddressOf Process_Email)

        T.Start()
        Application.DoEvents()
        Dim WH As IntPtr

        If Async = False Then
            Do Until T.IsAlive = False
                If WH = IntPtr.Zero Then
                    WH = FindWindowNullClassName(0, strSubject)
                    If WH <> IntPtr.Zero Then
                        SetWindowPos(WH, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
                    End If
                End If
                Application.DoEvents()
                Application.DoEvents()
                Application.DoEvents()
                Application.DoEvents()
            Loop
        Else
           
        End If
        Return True
    End Function
    Private Sub Process_Email()
        Dim session As IntPtr = New IntPtr(0)

        Dim winhandle As IntPtr = New IntPtr(0)

        Dim msg As MapiMessage = New MapiMessage
        Dim size As Integer = Marshal.SizeOf(GetType(MapiRecipDesc))
        Dim intPtr As IntPtr = Marshal.AllocHGlobal(size)
        Dim ptr As Integer = CType(intPtr, Integer)
        Dim mapiDesc As New MapiRecipDesc

        If lRecepient <> "" Then
            mapiDesc.address = lRecepient
            mapiDesc.recipClass = 1
            mapiDesc.name = lRecepient
            Marshal.StructureToPtr(mapiDesc, CType(ptr, IntPtr), False)
            msg.recips = ptr
            msg.recipCount = 1
        End If
        msg.subject = lSubject
        msg.noteText = lBody

        Dim sizeofMapiDesc As Integer = Marshal.SizeOf(GetType(MapiFileDesc))

        Marshal.AllocHGlobal(sizeofMapiDesc)

        Dim fileDesc As MapiFileDesc = New MapiFileDesc

        fileDesc.position = -1

      
        msg.files = GetAttachments(msg.fileCount, lAttachmentFileNames)
        Dim Ret as Integer 
        Ret = MAPISendMail(session, winhandle, msg, MAPI_LOGON_UI Or MAPI_DIALOG, 0)
        If Ret <> 0 Then
            ' try to use outlook
            SendOutlookEmail()
            
        End If
    End Sub
    Private Sub SendOutlookEmail()
        Try
            Dim objApp As Object = CreateObject("Outlook.Application")
            Dim objEmail As Object=objApp.CreateItem(0)
            With objEmail
                .BodyFormat = 2 ' HTML
                .To = lRecepient
                .Subject = lSubject
                .body = lBody   
                If (Not lAttachmentFileNames Is Nothing) Then
                    For Each strFile As String In lAttachmentFileNames
                        strFile = strFile.Trim()
                        If File.Exists(strFile) Then
                            .Attachments.Add(strFile.Trim())
                        End If
                    Next
                End If
                For Each frm As Form In My.Application.OpenForms
                    SetTopmost(frm,False)
                Next
                Dim inspector = .GetInspector
                .Display(false)
                inspector.Activate()
                Return
            End With
               
        Catch ex As Exception
            log.Error(ex.Message, ex)
        End Try
        Return
    End Sub
    Private Delegate Sub SetTopmostMethod(form As Form, topmost as boolean )
    Private Shared Sub SetTopmost(form As Form, topmost as boolean )
	    If Not form.IsDisposed Then
		    If form.InvokeRequired Then
			    Dim method As New SetTopmostMethod(AddressOf SetTopmost)
			    form.Invoke(method, New Object() {form, topmost})
		    Else
			    form.TopMost=topmost
                form.AccessibleDefaultActionDescription = topmost.ToString
		    End If
	    End If
    End Sub
Private Function GetAttachments(ByRef fileCount As Integer, m_attachments() As String ) As IntPtr
	fileCount = 0
	If m_attachments Is Nothing Then
		Return IntPtr.Zero
	End If

	If (m_attachments.Count <= 0) OrElse (m_attachments.Count > 20) Then
		Return IntPtr.Zero
	End If

	Dim size As Integer = Marshal.SizeOf(GetType(MapiFileDesc))
	Dim intPtr__1 As IntPtr = Marshal.AllocHGlobal(m_attachments.Count * size)

	Dim mapiFileDesc As New MapiFileDesc()
	mapiFileDesc.position = -1
	Dim ptr As Integer = CInt(intPtr__1)

        
	For Each strAttachment As String In m_attachments
		mapiFileDesc.name = Path.GetFileName(strAttachment)
		mapiFileDesc.path = strAttachment
		Marshal.StructureToPtr(mapiFileDesc, new IntPtr(ptr), False)
		ptr += size
	Next

	fileCount = m_attachments.Count
	Return intPtr__1
End Function

    <DllImport("MAPI32.DLL")> Private Shared Function MAPISendMail(ByVal sess As IntPtr, ByVal hwnd As IntPtr, ByVal message As MapiMessage, ByVal flg As Integer, ByVal rsv As Integer) As Integer

    End Function

End Class

<StructLayout(LayoutKind.Sequential)> Public Class MapiMessage

    Public reserved As Integer

    Public subject As String

    Public noteText As String

    Public messageType As String

    Public dateReceived As String

    Public conversationID As String

    Public flags As Integer

    Public originator As IntPtr

    Public recipCount As Integer

    Public recips As IntPtr

    Public fileCount As Integer

    Public files As IntPtr

End Class

<StructLayout(LayoutKind.Sequential)> Public Class MapiFileDesc

    Public reserved As Integer

    Public flags As Integer

    Public position As Integer

    Public path As String

    Public name As String

    Public type As IntPtr
End Class
<StructLayout(LayoutKind.Sequential)> Public Class MapiRecipDesc
    Public reserved As Integer
    Public recipClass As Integer
    Public name As String
    Public address As String
    Public eIDSize As Integer
    Public enTryID As IntPtr
End Class