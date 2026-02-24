Public Class CheckPatientExist
    Public Fname As String
    Public Lname As String
    Public Event ThreadComplete(ByVal ResultListView As ListView)

    Public Sub Check_Patient_Exist()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim LI As ListViewItem = Nothing
        Dim LV As New ListView
        SyncLock GetType(CheckPatientExist)
            SQL = "SELECT Patients.PatientID, CaseTypes.Description AS CaseType, Patients.FName, Patients.LName, Patients.DOB, Patients.Sex, Patients.SSN, Patients.Address1, CaseStatuses.Description AS Status, Patients.CaseStatusDate "
            SQL &= " FROM Patients INNER JOIN CaseStatuses ON Patients.CaseStatusID = CaseStatuses.CaseStatusID INNER JOIN CaseTypes ON Patients.CaseTypeID = CaseTypes.CaseTypeID "
            SQL &= " WHERE DIFFERENCE(fname, '" & Fname.Trim.ToSafeSQLString() & "') = 4 AND DIFFERENCE(lname, '" & Lname.Trim.ToSafeSQLString() & "') = 4 "
            SQL &= " ORDER BY  Patients.FName, Patients.LName"
            Reader = gSQLGetDataReader(SQL)
            If Reader Is Nothing Then Exit Sub
            If Reader.HasRows Then
                Do Until Reader.Read = False
                    LI = LV.Items.Add(Reader("PatientID").ToString.Trim)
                    LI.Tag = Reader("PatientID").ToString.Trim
                    LI.SubItems.Add(Reader("CaseType").ToString.Trim)
                    LI.SubItems.Add(Reader("FName").ToString.Trim)
                    LI.SubItems.Add(Reader("LName").ToString.Trim)
                    If IsDate(Reader("DOB").ToString.Trim) Then LI.SubItems.Add(CDate(Reader("DOB").ToString.Trim).ToString("MM/dd/yyyy"))
                    LI.SubItems.Add(Reader("Sex").ToString.Trim)
                    LI.SubItems.Add(Reader("SSN").ToString.Trim)
                    LI.SubItems.Add(Reader("Address1").ToString.Trim)
                    LI.SubItems.Add(Reader("Status").ToString.Trim)
                    If IsDate(Reader("CaseStatusDate").ToString.Trim) Then LI.SubItems.Add(CDate(Reader("CaseStatusDate").ToString.Trim).ToString("MM/dd/yyyy"))
                Loop
                RaiseEvent ThreadComplete(LV)
            Else
                RaiseEvent ThreadComplete(Nothing)
            End If
        End SyncLock
    End Sub

End Class
