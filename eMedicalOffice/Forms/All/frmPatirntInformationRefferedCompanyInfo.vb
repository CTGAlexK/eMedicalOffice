Public Class frmPatirntInformationRefferedCompanyInfo
    Public Function Show_CompanyInformation(ByVal ID As Long) As Boolean
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        SQL = "SELECT     * FROM ReferringOffices WHERE ReferringOffices.OfficeID = " & ID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Function
        If Reader.HasRows = False Then Exit Function
        Reader.Read()
        ListViewInfo.Items(0).SubItems.Add(Reader("OfficeName").ToString)
        ListViewInfo.Items(1).SubItems.Add(Reader("Address1").ToString)
        ListViewInfo.Items(2).SubItems.Add(Reader("Address2").ToString)
        ListViewInfo.Items(3).SubItems.Add(Reader("City").ToString)
        ListViewInfo.Items(4).SubItems.Add(Reader("State").ToString)
        ListViewInfo.Items(5).SubItems.Add(Reader("Zip").ToString)
        For i = 1 To gReferringOfficeDoctors
            ListViewInfo.Items(i + 5).SubItems.Add(Reader("Doctor" & i).ToString.Trim)
        Next

        ListViewInfo.Items(126).SubItems.Add(Reader("Phone1").ToString)
        ListViewInfo.Items(127).SubItems.Add(Reader("Phone2").ToString)
        ListViewInfo.Items(128).SubItems.Add(Reader("Phone3").ToString)
        ListViewInfo.Items(129).SubItems.Add(Reader("Fax1").ToString)
        Reader.Close() : Reader.Dispose()
        Show_CompanyInformation = True
    End Function
    Private Sub frmPatirntInformationRefferedCompanyInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class