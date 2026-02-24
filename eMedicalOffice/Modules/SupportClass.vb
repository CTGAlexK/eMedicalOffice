Public Class ToolStripOverride
    Inherits ToolStripProfessionalRenderer
    Public Sub New()
    End Sub

    Protected Overrides Sub OnRenderToolStripBorder(ByVal e As ToolStripRenderEventArgs)
    End Sub
End Class
Public Class DocInfo
    Public DocumentID As Integer
    Public DocumentProfileID As Integer
    Public DocumentName As String
    Public WebDocID As Integer
    Public Sub New(ByVal pDocumentID As Integer, ByVal pDocumentProfileID As Integer, ByVal pDocumentName As String, ByVal pWebDocID As Integer)
        DocumentID = pDocumentID
        DocumentProfileID = pDocumentProfileID
        DocumentName = pDocumentName
        WebDocID = pWebDocID
    End Sub
    Public Sub New(ByVal pDocumentID As Integer, ByVal pDocumentProfileID As Integer, ByVal pDocumentName As String)
        DocumentID = DocumentID
        DocumentProfileID = DocumentProfileID
        DocumentName = pDocumentName
    End Sub
    Public Sub New(ByVal pDocumentID As Integer, ByVal pDocumentProfileID As Integer)
        DocumentID = DocumentID
        DocumentProfileID = DocumentProfileID
    End Sub
End Class
Public Class RTFDocument
    Public ID As Integer
    Public PatientID As Integer
    Public DocName As String
    Public Data As String
    Public DocDate As DateTime

End Class
Public Class ValueDescription
    Public Value As Double
    Public Value1 As String
    Public Description As String
    Public Fld1 As String
    Public Fld2 As String
    Public Fld3 As String
    Public Fld4 As String
    Public Fld5 As String
    Public Fld6 As String
    Public Fld7 As String
    Public Fld8 As String
    Public Fld9 As String
    Public Fld10 As String

    Public Sub New(ByVal NewValue As Double, ByVal NewDescription As String, Optional ByVal NewValue1 As String = "", Optional ByVal NewFld1 As String = "", Optional ByVal NewFld2 As String = "", Optional ByVal NewFld3 As String = "", Optional ByVal NewFld4 As String = "", Optional ByVal NewFld5 As String = "", Optional ByVal NewFld6 As String = "", Optional ByVal NewFld7 As String = "", Optional ByVal NewFld8 As String = "", Optional ByVal NewFld9 As String = "", Optional ByVal NewFld10 As String = "")
        Value = NewValue
        Description = NewDescription
        Value1 = NewValue1
        Fld1 = NewFld1
        Fld2 = NewFld2
        Fld3 = NewFld3
        Fld4 = NewFld4
        Fld5 = NewFld5
        Fld6 = NewFld6
        Fld7 = NewFld7
        Fld8 = NewFld8
        Fld9 = NewFld9
        Fld10 = NewFld10
    End Sub

    Public Overrides Function ToString() As String
        Return Description
    End Function
End Class
Public Class EmailerAddressInfo
    Public AddressID As Double
    Public CompanyName As String
    Public ContactName As String
    Public EmailAddress As String
    Public Status As Integer = 0
    Public Address1 As String
    Public Address2 As String
    Public City As String
    Public State As String
    Public Zip As String
    Public Sub New(ByVal NewAddressID As Double, ByVal NewCompanyName As String, Optional ByVal NewContactName As String = "", Optional ByVal NewEmailAddress As String = "", Optional ByVal NewStatus As Integer = 0, Optional ByVal NewAddress1 As String = "", Optional ByVal NewAddress2 As String = "", Optional ByVal NewCity As String = "", Optional ByVal NewState As String = "", Optional ByVal NewZip As String = "")
        AddressID = NewAddressID
        CompanyName = NewCompanyName
        ContactName = NewContactName
        EmailAddress = NewEmailAddress
        Status = NewStatus
        Address1 = NewAddress1
        Address2 = NewAddress2
        City = NewCity
        State = NewState
        Zip = NewZip

    End Sub
End Class
Public Class ProcedureInfo
    Public ProcID As Integer = 0
    Public ProcName As String = ""
    Public DiagID As Integer = 0
    Public DiagName As String = ""
    Public NFCost As Double = 0
    Public WCCost As Double = 0
    Public PRCost As Double = 0
    Public Price As Double = 0
    Public ProcedureTypeID As Integer = 0
    Public ProcedureTypeName As String = ""
    Public BillingProviderID As Integer = 0
    Public BillingProviderName As String = ""
    Public TreatingProviderID As Integer = 0
    Public TreatingProviderName As String = ""
    Public PrescribedByProcID As Integer = 0
    Public PrescribedByProcName As String = ""
    Public PatientProcedureID As Integer = 0
    Public ScheduleDateTime As Date = Nothing
    Public BillID As Integer = 0
    Public BillDate As Date = Nothing
    Public SourcePatientProcedureID As Integer
    Public Sub New()

    End Sub
    Public Sub New(ByVal NewProcID As Integer, ByVal NewProcName As String, ByVal NewProcedureTypeID As Integer, ByVal NewProcedureTypeName As String, ByVal NewDiagID As Integer, ByVal NewDiagName As String, Optional ByVal NewNFCost As Double = 0, Optional ByVal NewWCCost As Double = 0, Optional ByVal NewPRCost As Double = 0, Optional ByVal NewBillingProviderID As Integer = 0, Optional ByVal NewBillingProviderName As String = "", Optional ByVal NewTreatingProviderID As Integer = 0, Optional ByVal NewTreatingProviderName As String = "", Optional ByVal NewPrescribedByProcID As Integer = 0, Optional ByVal NewPrescribedByProcName As String = "", Optional ByVal NewPatientProcedureID As Integer = 0, Optional ByVal NewScheduleDateTime As Date = Nothing, Optional ByVal NewBillID As Integer = 0, Optional ByVal NewBillDate As Object = Nothing, Optional ByVal NewSourcePatientProcedureID As Integer = 0)
        ProcID = NewProcID
        ProcName = NewProcName
        DiagID = NewDiagID
        DiagName = NewDiagName
        NFCost = NewNFCost
        WCCost = NewWCCost
        PRCost = NewPRCost
        ProcedureTypeID = NewProcedureTypeID
        ProcedureTypeName = NewProcedureTypeName
        BillingProviderID = NewBillingProviderID
        BillingProviderName = NewBillingProviderName
        TreatingProviderID = NewTreatingProviderID
        TreatingProviderName = NewTreatingProviderName
        PrescribedByProcID = NewPrescribedByProcID
        PrescribedByProcName = NewPrescribedByProcName
        PatientProcedureID = NewPatientProcedureID
        ScheduleDateTime = NewScheduleDateTime
        BillID = NewBillID
        SourcePatientProcedureID = NewSourcePatientProcedureID
        If IsDate(NewBillDate) Then
            BillDate = NewBillDate
        End If
    End Sub
    Public Sub New(ByVal PI As ProcedureInfo)
        With PI
            ProcID = .ProcID
            ProcName = .ProcName
            DiagID = .DiagID
            DiagName = .DiagName
            NFCost = .NFCost
            WCCost = .WCCost
            PRCost = .PRCost
            Price = .Price
            ProcedureTypeID = .ProcedureTypeID
            ProcedureTypeName = .ProcedureTypeName
            BillingProviderID = .BillingProviderID
            BillingProviderName = .BillingProviderName
            TreatingProviderID = .TreatingProviderID
            TreatingProviderName = .TreatingProviderName
            PrescribedByProcID = .PrescribedByProcID
            PrescribedByProcName = .PrescribedByProcName
            PatientProcedureID = .PatientProcedureID
            ScheduleDateTime = .ScheduleDateTime
            SourcePatientProcedureID = .SourcePatientProcedureID
            BillID = .BillID
            If IsDate(.BillDate) Then
                BillDate = .BillDate
            End If
        End With
    End Sub
End Class


Public Class FormsCollection
    Public Shared Forms As ArrayList = New ArrayList
    Public Shared Function FindForm(ByVal frmName As String) As Form
        Dim frm As Form = Nothing
        For Each frm In Forms
            If frm.Name = frmName Then
                Return frm
            End If
        Next
        Return Nothing
    End Function
End Class
Class ListViewComparer
    Implements IComparer

    Private m_ColumnNumber As Integer
    Private m_SortOrder As SortOrder

    Public Sub New(ByVal column_number As Integer, ByVal _
        sort_order As SortOrder)
        m_ColumnNumber = column_number
        m_SortOrder = sort_order
    End Sub

    ' Compare the items in the appropriate column
    ' for objects x and y.
    Public Function Compare(ByVal x As Object, ByVal y As _
        Object) As Integer Implements _
        System.Collections.IComparer.Compare
        Dim item_x As ListViewItem = DirectCast(x,
            ListViewItem)
        Dim item_y As ListViewItem = DirectCast(y,
            ListViewItem)

        ' Get the sub-item values.
        Dim string_x As String
        If item_x.SubItems.Count <= m_ColumnNumber Then
            string_x = ""
        Else
            string_x = item_x.SubItems(m_ColumnNumber).Text
        End If

        Dim string_y As String
        If item_y.SubItems.Count <= m_ColumnNumber Then
            string_y = ""
        Else
            string_y = item_y.SubItems(m_ColumnNumber).Text
        End If

        ' Compare them.
        If m_SortOrder = SortOrder.Ascending Then
            If IsNumeric(string_x) And IsNumeric(string_y) _
                Then
                Return Val(string_x).CompareTo(Val(string_y))
            ElseIf IsDate(string_x) And IsDate(string_y) _
                Then
                Return DateTime.Parse(string_x).CompareTo(DateTime.Parse(string_y))
            Else
                Return String.Compare(string_x, string_y)
            End If
        Else
            If IsNumeric(string_x) And IsNumeric(string_y) _
                Then
                Return Val(string_y).CompareTo(Val(string_x))
            ElseIf IsDate(string_x) And IsDate(string_y) _
                Then
                Return DateTime.Parse(string_y).CompareTo(DateTime.Parse(string_x))
            Else
                Return String.Compare(string_y, string_x)
            End If
        End If
    End Function
End Class
Public Class AliasAccount
    Private _username, _password, _domainname As String
    Private _tokenHandle As New IntPtr(0)
    Private _dupeTokenHandle As New IntPtr(0)
    Private _impersonatedUser As System.Security.Principal.WindowsImpersonationContext


    Public Sub New(ByVal username As String, ByVal password As String)
        Dim nameparts() As String = username.Split("\")
        If nameparts.Length > 1 Then
            _domainname = nameparts(0)
            _username = nameparts(1)
        Else
            _username = username
        End If
        _password = password
    End Sub

    Public Sub New(ByVal username As String, ByVal password As String, ByVal domainname As String)
        _username = username
        _password = password
        _domainname = domainname
    End Sub


    Public Sub BeginImpersonation()
        Const LOGON32_PROVIDER_DEFAULT As Integer = 0
        Const LOGON32_LOGON_INTERACTIVE As Integer = 2
        Const SecurityImpersonation As Integer = 2

        Dim win32ErrorNumber As Integer

        _tokenHandle = IntPtr.Zero
        _dupeTokenHandle = IntPtr.Zero

        If Not LogonUser(_username, _domainname, _password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, _tokenHandle) Then
            win32ErrorNumber = System.Runtime.InteropServices.Marshal.GetLastWin32Error()
            Throw New ImpersonationException(win32ErrorNumber, GetErrorMessage(win32ErrorNumber), _username, _domainname)
        End If

        If Not DuplicateToken(_tokenHandle, SecurityImpersonation, _dupeTokenHandle) Then
            win32ErrorNumber = System.Runtime.InteropServices.Marshal.GetLastWin32Error()
            CloseHandle(_tokenHandle)
            Throw New ImpersonationException(win32ErrorNumber, "Unableto duplicate token!", _username, _domainname)
        End If

        Dim newId As New System.Security.Principal.WindowsIdentity(_dupeTokenHandle)
        _impersonatedUser = newId.Impersonate()
    End Sub


    Public Sub EndImpersonation()
        If Not _impersonatedUser Is Nothing Then
            _impersonatedUser.Undo()
            _impersonatedUser = Nothing

            If Not System.IntPtr.op_Equality(_tokenHandle, IntPtr.Zero) Then
                CloseHandle(_tokenHandle)
            End If
            If Not System.IntPtr.op_Equality(_dupeTokenHandle, IntPtr.Zero) Then
                CloseHandle(_dupeTokenHandle)
            End If
        End If
    End Sub



    Public ReadOnly Property username() As String
        Get
            Return _username
        End Get
    End Property

    Public ReadOnly Property domainname() As String
        Get
            Return _domainname
        End Get
    End Property


    Public ReadOnly Property currentWindowsUsername() As String
        Get
            Return System.Security.Principal.WindowsIdentity.GetCurrent().Name()
        End Get
    End Property


    Public Class ImpersonationException
        Inherits System.Exception

        Public ReadOnly win32ErrorNumber As Integer

        Public Sub New(ByVal win32ErrorNumber As Integer, ByVal msg As String, ByVal username As String, ByVal domainname As String)
            MyBase.New(String.Format("Impersonation of {1}\{0} failed![{2}] {3}", username, domainname, win32ErrorNumber, msg))
            Me.win32ErrorNumber = win32ErrorNumber
        End Sub
    End Class


    Private Declare Auto Function LogonUser Lib "advapi32.dll" (ByVal lpszUsername As [String], ByVal lpszDomain As [String], ByVal lpszPassword As [String], ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, ByRef phToken As IntPtr) As Boolean
    Private Declare Auto Function DuplicateToken Lib "advapi32.dll" (ByVal ExistingTokenHandle As IntPtr, ByVal SECURITY_IMPERSONATION_LEVEL As Integer, ByRef DuplicateTokenHandle As IntPtr) As Boolean
    Private Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal handle As IntPtr) As Boolean
    Private Shared Function FormatMessage(ByVal dwFlags As Integer, ByRef lpSource As IntPtr, ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, ByRef lpBuffer As [String], ByVal nSize As Integer, ByRef Arguments As IntPtr) As Integer
    End Function


    Private Function GetErrorMessage(ByVal errorCode As Integer) As String
        Dim FORMAT_MESSAGE_ALLOCATE_BUFFER As Integer = &H100
        Dim FORMAT_MESSAGE_IGNORE_INSERTS As Integer = &H200
        Dim FORMAT_MESSAGE_FROM_SYSTEM As Integer = &H1000

        Dim messageSize As Integer = 255
        Dim lpMsgBuf As String = ""
        Dim dwFlags As Integer = FORMAT_MESSAGE_ALLOCATE_BUFFER Or FORMAT_MESSAGE_FROM_SYSTEM Or FORMAT_MESSAGE_IGNORE_INSERTS

        Dim ptrlpSource As IntPtr = IntPtr.Zero
        Dim prtArguments As IntPtr = IntPtr.Zero

        Dim retVal As Integer = FormatMessage(dwFlags, ptrlpSource, errorCode, 0, lpMsgBuf, messageSize, prtArguments)
        If 0 = retVal Then
            Throw New System.Exception("Failed to format message for error code " + errorCode.ToString() + ". ")
        End If

        Return lpMsgBuf
    End Function
End Class
Public Class clsListView
    Inherits ListView

    Public Sub New()
        MyBase.New()
        Me.DoubleBuffered = True
    End Sub
End Class
