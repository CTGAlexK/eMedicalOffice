Public Class frmPatirntInformationRefferedCompanyInfo
    Public Function Show_CompanyInformation(ByVal ID As Long) As Boolean
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        SQL = "SELECT     OfficeName, Address1, Address2, City, State, Zip, Doctor1, Doctor2, Doctor3, Doctor4, Phone1, Phone2, Phone3, Fax1, OfficeID FROM ReferringOffices WHERE OfficeID = " & ID
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
        ListViewInfo.Items(6).SubItems.Add(Reader("Doctor1").ToString)
        ListViewInfo.Items(7).SubItems.Add(Reader("Doctor2").ToString)
        ListViewInfo.Items(8).SubItems.Add(Reader("Doctor3").ToString)
        ListViewInfo.Items(9).SubItems.Add(Reader("Doctor4").ToString)
        ListViewInfo.Items(10).SubItems.Add(Reader("Phone1").ToString)
        ListViewInfo.Items(11).SubItems.Add(Reader("Phone2").ToString)
        ListViewInfo.Items(12).SubItems.Add(Reader("Phone3").ToString)
        ListViewInfo.Items(13).SubItems.Add(Reader("Fax1").ToString)
        Reader.Close()
        Show_CompanyInformation = True
    End Function
    Private Sub frmPatirntInformationRefferedCompanyInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class