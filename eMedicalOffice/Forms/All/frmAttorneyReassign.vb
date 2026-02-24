Public Class frmAttorneyReassign
    Public bills As List(Of ListViewItem) = New List(Of ListViewItem)
    Private Sub frmAttorneyReassign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListViewBills, ReadWrite.sRead)
        Load_Data()
    End Sub
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim DisMsg As String
        With cboAttorneysCompanyID.Items
            .Clear()
            Reader = gSQLGetDataReader("Select ActiveInd, CompanyID, CompanyName, AttorneyFName+' '+AttorneyLName as AttorneyName from Attorneys INNER JOIN WebLogins ON Attorneys.CompanyID = WebLogins.UserID AND Attorneys.OfficeID = WebLogins.OfficeID Where UserTypeID = 6 and ActiveInd=1 and Attorneys.OfficeID=" & gOfficeID)
            If Reader Is Nothing Then Exit Sub
            Do Until Reader.Read = False
                .Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString & " - " & Reader("AttorneyName").ToString & DisMsg))
            Loop
        End With
        Reader.Close() : Reader.Dispose()
        For Each lvi As ListViewItem In bills
            ListViewBills.Items.Add(lvi)
        Next


    End Sub

    Private Sub frmAttorneyReassign_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gListview_Settings(Me, ListViewBills, ReadWrite.sWrite)
    End Sub
End Class