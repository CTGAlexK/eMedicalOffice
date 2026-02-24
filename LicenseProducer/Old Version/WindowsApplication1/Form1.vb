Imports System.Threading
Public Class Form1
    Public gSQLServerName As String
    Public gSQLServerDatabase As String
    Public gSQLServerUID As String
    Public gSQLServerPassword As String
    Public gConnectionString As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gSQLServerName = gEncrypt(GetSetting(My.Application.Info.ProductName, "Settings", "SQLServerName", ""))
        gSQLServerDatabase = gEncrypt(GetSetting(My.Application.Info.ProductName, "Settings", "SQLServerDatabase", ""))
        gSQLServerUID = gEncrypt(GetSetting(My.Application.Info.ProductName, "Settings", "SQLServerUID", ""))
        gSQLServerPassword = gEncrypt(GetSetting(My.Application.Info.ProductName, "Settings", "SQLServerPassword", ""))
        If gSQLServerName <> "" And gSQLServerDatabase <> "" And gSQLServerUID <> "" Then
            gConnectionString = "Server=" & gSQLServerName & ";Database=" & gSQLServerDatabase & ";User ID=" & gSQLServerUID & ";Password=" & gSQLServerPassword & ";Trusted_Connection=False; Max Pool Size=500"
        End If
        If gConnectionString = "" Then
            Label4.ForeColor = Color.Red
            Label4.Text = "INVALID SETUP"
            TextBox1.Enabled = False
        Else
            If gValidateConnection(gConnectionString) = False Then
                Label4.ForeColor = Color.Red
                Label4.Text = "INVALID CONNECTION"
                TextBox1.Enabled = False
            Else
                Load_Offices()
                Label4.ForeColor = Color.Black
                Label4.Text = "SERVER: " & gSQLServerName

            End If
        End If
    End Sub
    Public Function gEncrypt(ByVal InString As String) As String
        Dim c1 As Integer
        Dim NewEncryptString As String
        Dim EncryptSeed As Integer
        Dim EncryptChar As String
        Dim InSeed As Integer = 17
        NewEncryptString = ""
        EncryptSeed = InSeed
        For c1 = 1 To Len(InString)
            EncryptChar = Mid(InString, c1, 1)
            EncryptChar = Chr(Asc(EncryptChar) Xor EncryptSeed)
            EncryptSeed = EncryptSeed Xor c1
            NewEncryptString = NewEncryptString & EncryptChar
        Next

        gEncrypt = NewEncryptString
    End Function
    Public Function gValidateConnection(ByVal TestString As String) As Boolean
        Using Cnn As New SqlClient.SqlConnection()
            If TestString = "" Then Exit Function
            Cnn.ConnectionString = TestString
            gValidateConnection = True
            Try
                Cnn.Open()
                gConnectionString = TestString
            Catch ex As Exception
                gValidateConnection = False
            End Try
        End Using
    End Function

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        Dim OfficeName As String = ""
        TextBox3.Text = ""
        TextBox2.Text = ""
        ComboBoxOffice.SelectedIndex = -1
        ComboBoxOffice.Enabled = False
        If TextBox1.Text = "042166" Then
            ComboBoxOffice.Enabled = True
            If ComboBoxOffice.Items.Count = 1 Then
                ComboBoxOffice.SelectedIndex = 0
            End If

        End If
    End Sub
    Public Function RightVB6(ByVal SomeStr As String, ByVal pLen As Integer) As String
        If pLen > SomeStr.Length Then
            RightVB6 = SomeStr
        Else
            RightVB6 = SomeStr.Substring(SomeStr.Length - pLen, pLen)
        End If

    End Function
    Public Function gSQLGetDataReader(ByVal SQL As String) As SqlClient.SqlDataReader
        Dim Cnn As New SqlClient.SqlConnection(gConnectionString)
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim Cmd As New SqlClient.SqlCommand(SQL, Cnn)
        Dim ErCount As Integer
        Dim ErrorCount As Integer
Er:
        ErCount = ErCount + 1
        Try
            Cnn.Open()
        Catch ex As Exception
            Thread.Sleep(200)
            SqlClient.SqlConnection.ClearPool(Cnn)
            SqlClient.SqlConnection.ClearAllPools()
            Cnn.Open()
        End Try
        Cmd.CommandTimeout = 300
        Try
            Reader = Cmd.ExecuteReader
        Catch ex As Exception
            ErrorCount = ErrorCount + 1
            If InStr(ex.ToString, "transport-level") And ErrorCount < 20 Then
                SqlClient.SqlConnection.ClearPool(Cnn)
                SqlClient.SqlConnection.ClearAllPools()
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()
                End If
                Thread.Sleep(200)
                GoTo Er
            End If
        End Try

        gSQLGetDataReader = Reader
    End Function

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
    Private Sub Load_Offices()
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("Select * from Offices Where ActiveInd=1 Order By OfficeName")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxOffice.Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)), Reader("OfficeName").ToString))
        Loop
        Reader.Close() : Reader.Dispose() : Reader.Dispose()
    End Sub
    Private Sub ComboBoxOffice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxOffice.SelectedIndexChanged
        Dim Reader As SqlClient.SqlDataReader
        Dim OfficeName As String
        If ComboBoxOffice.SelectedIndex = -1 Then
            TextBox3.Text = ""
            TextBox2.Text = ""
        Else
            OfficeName = CType(ComboBoxOffice.SelectedItem, ValueDescription).Description
            OfficeName = Replace(OfficeName.ToString.Trim, " ", "").ToUpper
            TextBox2.Text = Mid(OfficeName, 2, 1).ToUpper.Trim & Mid(OfficeName, 4, 1).ToUpper.Trim & Mid(OfficeName, 6, 1).ToUpper.Trim
            Reader = gSQLGetDataReader("EXEC xp_msver")
            Do Until Reader.Read = False
                Select Case Reader("Name")
                    Case "ProcessorCount"
                        TextBox2.Text &= Reader("Internal_Value") & RightVB6(OfficeName, 1)
                    Case "ProcessorType"
                        TextBox2.Text &= Reader("Internal_Value")
                    Case "PhysicalMemory"
                        TextBox2.Text &= Reader("Internal_Value")
                End Select
            Loop
            TextBox3.Text = gEncrypt(TextBox2.Text)
        End If
    End Sub
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