
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Module WebNavigator
    Public Enum NWMF
        NWMF_UNLOADING = &H1&
        NWMF_USERINITED = &H2&
        NWMF_FIRST_USERINITED = &H4&
        NWMF_OVERRIDEKEY = &H8&
        NWMF_SHOWHELP = &H10&
        NWMF_HTMLDIALOG = &H20&
        NWMF_FROMPROXY = &H40&
    End Enum

    'First define a new EventArgs class to contain the newly exposed data
    Public Class WebBrowserNavigatingExtendedEventArgs
        Inherits CancelEventArgs

        Private m_Url As String
        Private m_Frame As String
        Private m_Postdata() As Byte
        Private m_Headers As String

        Public ReadOnly Property Url() As String
            Get
                Return m_Url
            End Get
        End Property

        Public ReadOnly Property Frame() As String
            Get
                Return m_Frame
            End Get
        End Property

        Public ReadOnly Property Headers() As String
            Get
                Return m_Headers
            End Get
        End Property

        Public ReadOnly Property Postdata() As String
            Get
                Return PostdataToString(m_Postdata)
            End Get
        End Property

        Public ReadOnly Property PostdataByte() As Byte()
            Get
                Return m_Postdata
            End Get
        End Property

        Public Sub New(ByVal url As String, ByVal frame As String, ByVal postdata As Byte(), ByVal headers As String)
            m_Url = url
            m_Frame = frame
            m_Postdata = postdata
            m_Headers = headers
        End Sub

        Private Function PostdataToString(ByVal p() As Byte) As String
            'not sexy but it works...
            Dim tabpd() As Byte, stmp As String = "", i As Integer = 0
            tabpd = p
            If tabpd Is Nothing OrElse tabpd.Length = 0 Then
                Return ""
            Else
                For i = 0 To tabpd.Length - 1
                    stmp += ChrW(tabpd(i))
                Next
                stmp = Replace(stmp, ChrW(13), "")
                stmp = Replace(stmp, ChrW(10), "")
                stmp = Replace(stmp, ChrW(0), "")
            End If
            If stmp = Nothing Then
                Return ""
            Else
                Return stmp
            End If
        End Function

    End Class

    Public Class WebBrowserNewWindowExtendedEventArgs
        Inherits CancelEventArgs

        Private m_Url As String
        Private m_UrlContext As String
        Private m_Flags As NWMF

        Public ReadOnly Property Url() As String
            Get
                Return m_Url
            End Get
        End Property

        Public ReadOnly Property UrlContext() As String
            Get
                Return m_UrlContext
            End Get
        End Property

        Public ReadOnly Property Flags() As NWMF
            Get
                Return m_Flags
            End Get
        End Property

        Public Sub New(ByVal url As String, ByVal urlcontext As String, ByVal flags As NWMF)
            m_Url = url
            m_UrlContext = urlcontext
            m_Flags = flags
        End Sub

    End Class

    Public Class ExtendedWebBrowser
        Inherits WebBrowser

        Private cookie As AxHost.ConnectionPointCookie
        Private wevents As WebBrowserExtendedEvents

        'This method will be called to give you a chance to create your own event sink
        Protected Overrides Sub CreateSink()
            'MAKE SURE TO CALL THE BASE or the normal events won't fire
            MyBase.CreateSink()
            wevents = New WebBrowserExtendedEvents(Me)
            cookie = New AxHost.ConnectionPointCookie(ActiveXInstance, wevents, GetType(DWebBrowserEvents2))
        End Sub

        Protected Overrides Sub DetachSink()
            If Not cookie Is Nothing Then
                cookie.Disconnect()
                cookie = Nothing
            End If
            MyBase.DetachSink()
        End Sub

        'This new event will fire when the page is navigating
        Public Delegate Sub WebBrowserNavigatingExtendedEventHandler(ByVal sender As Object, ByVal e As WebBrowserNavigatingExtendedEventArgs)
        Public Event NavigatingExtended As WebBrowserNavigatingExtendedEventHandler

        'This event will fire when a new window is about to be opened
        Public Delegate Sub WebBrowserNewWindowExtendedEventHandler(ByVal sender As Object, ByVal e As WebBrowserNewWindowExtendedEventArgs)
        Public Event NewWindowExtended As WebBrowserNewWindowExtendedEventHandler

        Protected Friend Sub OnNavigatingExtended(ByVal Url As String, ByVal Frame As String, ByVal Postdata As Byte(), ByVal Headers As String, ByRef Cancel As Boolean)
            Dim e As WebBrowserNavigatingExtendedEventArgs = New WebBrowserNavigatingExtendedEventArgs(Url, Frame, Postdata, Headers)
            RaiseEvent NavigatingExtended(Me, e)
            Cancel = e.Cancel
        End Sub

        Protected Friend Sub OnNewWindowExtended(ByVal Url As String, ByRef Cancel As Boolean, ByVal Flags As NWMF, ByVal UrlContext As String)
            Dim e As WebBrowserNewWindowExtendedEventArgs = New WebBrowserNewWindowExtendedEventArgs(Url, UrlContext, Flags)
            RaiseEvent NewWindowExtended(Me, e)
            Cancel = e.Cancel
        End Sub

    End Class

    'This class will capture events from the WebBrowser
    Class WebBrowserExtendedEvents
        Inherits System.Runtime.InteropServices.StandardOleMarshalObject
        Implements DWebBrowserEvents2

        Private m_Browser As ExtendedWebBrowser

        Public Sub New(ByVal browser As ExtendedWebBrowser)
            m_Browser = browser
        End Sub

        'Implement whichever events you wish
        Public Sub BeforeNavigate2(ByVal pDisp As Object, ByRef URL As String, ByRef flags As Object, ByRef targetFrameName As String, ByRef postData As Object, ByRef headers As String, ByRef cancel As Boolean) Implements DWebBrowserEvents2.BeforeNavigate2

            m_Browser.OnNavigatingExtended(URL, targetFrameName, CType(postData, Byte()), headers, cancel)

        End Sub

        Public Sub NewWindow3(ByVal pDisp As Object, ByRef Cancel As Boolean, ByRef Flags As Object, ByRef UrlContext As String, ByRef Url As String) Implements DWebBrowserEvents2.NewWindow3

            m_Browser.OnNewWindowExtended(Url, Cancel, CType(Flags, NWMF), UrlContext)

        End Sub

    End Class

    <ComImport(), _
    Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"), _
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch), _
    TypeLibType(TypeLibTypeFlags.FHidden)> _
    Public Interface DWebBrowserEvents2

        <DispId(250)> _
        Sub BeforeNavigate2(<[In](), MarshalAs(UnmanagedType.IDispatch)> ByVal pDisp As Object, _
        <InAttribute(), MarshalAs(UnmanagedType.BStr)> ByRef URL As String, _
        <InAttribute()> ByRef flags As Object, _
        <InAttribute(), MarshalAs(UnmanagedType.BStr)> ByRef targetFrameName As String, _
        <InAttribute()> ByRef postdata As Object, _
        <InAttribute(), MarshalAs(UnmanagedType.BStr)> ByRef headers As String, _
        <InAttribute(), OutAttribute()> ByRef cancel As Boolean)

        'Note: Postdata is a SafeArray but for some reason, if I do a proper declaration, the event will not be raised:
        '<[In](), MarshalAs(UnmanagedType.SafeArray, safearraysubtype:=VarEnum.VT_UI1)> ByRef postdata() As Byte, _

        <DispId(273)> _
        Sub NewWindow3(<InAttribute(), MarshalAs(UnmanagedType.IDispatch)> ByVal pDisp As Object, _
        <InAttribute(), OutAttribute()> ByRef cancel As Boolean, _
        <InAttribute()> ByRef Flags As Object, _
        <InAttribute(), MarshalAs(UnmanagedType.BStr)> ByRef UrlContext As String, _
        <InAttribute(), MarshalAs(UnmanagedType.BStr)> ByRef Url As String)

    End Interface

End Module

