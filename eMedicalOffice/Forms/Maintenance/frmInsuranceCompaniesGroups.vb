Public Class frmInsuranceCompaniesGroups
    Public RetGroupName
    Private Sub txtgroupName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGroupName.TextChanged
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        ListBoxgGoups.Items.Clear()
        SQL = "SELECT     Description FROM InsuranceCompaniesGroups "
        SQL &= " WHERE Description like '%" & txtGroupName.Text.ToSafeSQLString() & "%'"
        SQL &= " order by Description "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ListBoxgGoups.Items.Add(Reader("Description").ToString)
        Loop
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim Sql As String
        If txtGroupName.Text.Trim = "" Then
            MsgBox("Unable to process update. Please specify a group name.")
            txtGroupName.Focus()
            Exit Sub
        End If
        Sql = "INSERT INTO InsuranceCompaniesGroups (Description, InsertedBy) Values('" & txtGroupName.Text.ToSafeSQLString() & "', " & gCurrentEmployee.EmpID & ")"
        gSQLUpdateData(Sql)
        RetGroupName = txtGroupName.Text
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmInsuranceCompaniesGroups_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
        txtGroupName.Focus()
    End Sub

    Private Sub frmInsuranceCompaniesGroups_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtgroupName_TextChanged(Nothing, Nothing)
    End Sub
End Class