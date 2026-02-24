Imports System.Data.SqlClient
Imports System.Threading

Public Class Office
    Public OfficeID As Integer = 0
    Public OfficeName As String = ""
    Public ConnectionString As String = ""
    Public LicenseKey As String = ""
    Public Updated As Boolean
    Public LicenseKeyValidated As Boolean = False

    Public Sub New(OfficeID As Integer, OfficeName As String, ConnectionString As String, LicenseKey As String)
        Me.OfficeID = OfficeID
        Me.OfficeName = OfficeName
        Me.ConnectionString = ConnectionString
        Me.LicenseKey = LicenseKey
    End Sub

    Public Function ValidateLicenseKey() As Boolean
        'Error on change payment infor
        'return True
        Dim ErCount As Integer
        Dim ErrorCount As Integer
        Dim Reader As SqlDataReader = Nothing
        Dim lLicenseKey As String
        Dim lofficename As String
        If LicenseKey = "" Or ConnectionString = "" Then Exit Function
        lofficename = Replace(OfficeName.Trim, " ", "").ToUpper
        lLicenseKey = lofficename.Mid(2, 1).ToUpper.Trim & lofficename.Mid(4, 1).ToUpper.Trim &
                      lofficename.Mid(6, 1).ToUpper.Trim

        Reader = gSQLGetDataReader("EXEC xp_msver", ConnectionString)
        If Reader Is Nothing Then
            LicenseKeyValidated = False
            Return False
        End If
        Do Until Reader.Read = False
            Select Case Reader("Name")
                Case "ProcessorCount"
                    lLicenseKey &= Reader("Internal_Value") & lofficename.Right(1)
                Case "ProcessorType"
                    lLicenseKey &= Reader("Internal_Value")
                Case "PhysicalMemory"
                    lLicenseKey &= Reader("Internal_Value")
            End Select
        Loop
        Reader.Close()

        If LicenseKey = lLicenseKey Then
            LicenseKeyValidated = True
            Return True
        End If
    End Function

    Public Sub New()
    End Sub

End Class