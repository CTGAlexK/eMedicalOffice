Imports System.Data.SqlClient
Imports System.Threading

Public Class Office
    public OfficeID As Integer = 0
    public OfficeName As String = ""
    public ConnectionString As String = ""
    public LicenseKey As String = ""
    public LicenseKeyValidated As Boolean = False

    Public Sub New(OfficeID as integer, OfficeName As String, ConnectionString As String, LicenseKey As String)
        Me.OfficeID = OfficeID
        Me.OfficeName = OfficeName
        Me.ConnectionString = ConnectionString
    end Sub

   Public Sub New()
    End Sub
End Class
