Imports System.Text
Public Class frmSearch
    Private ForceExit As Boolean
    Private Sub ScheduleSearchPopup_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            txtSearch.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Setup_ColumnsHeaders()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As New StringBuilder
        FpSpreadResults.SuspendLayout()
        SQL.Append("SELECT     Patients.InsertedDT, Patients.PatientID, CaseTypes.Description AS [Type], CaseStatuses.Description AS [Status], Patients.CaseStatusDate as [Status DT], InjuryTypes.InjuryName AS [Injury], Patients.DOA, PatientTypes.Description AS [Patient Type], Patients.NoMoreAppointmentsInd as [NoMoreApp], ")
        SQL.Append(" (SELECT COUNT(*) FROM PatientProcedures WHERE PatientID = Patients.PatientID) AS [Total Procs],   ")
        SQL.Append(" (SELECT COUNT(*) FROM PatientProcedures WHERE ProcedureStatusID = 2 AND PatientID = Patients.PatientID) AS [Cmpl Procs],   ")
        SQL.Append(" Patients.FName , Patients.MI , Patients.LName , Patients.Suffix , Patients.DOB, Patients.ParentsRequiredInd AS [Underage],  ")
        SQL.Append(" Patients.Sex, Patients.SSN, Patients.Address1, Patients.Address2, Patients.City, Patients.State, Patients.Zip, Patients.Phone1, Patients.Phone2,  ")
        SQL.Append(" Patients.CellPhone as CPhone, Patients.eMail, MaritalStatuses.Description AS [Martl Status], EmploymentStatuses.Description AS [Emp Status], Patients.Occupation, Patients.EmployerName as [Employer],  ")
        SQL.Append(" Patients.EmployerAddress as [Emp Address], Patients.EmployerPhone as [Emp Phone], InsuranceCompanies_1.CompanyName AS [Ins Company1], PolicyNumber as [Policy #], InsuranceCompanies_1.CompanyName AS [Ins Company2], PolicyNumber1 as [Policy #2],  ")
        SQL.Append(" Patients.ClaimEffectiveDT as [Claim1 Eff DT], Patients.ClaimNumber as [Claim1 #],  ")
        SQL.Append(" InsuranceCompanyAddresses_1.Address+' '+InsuranceCompanyAddresses_1.City+' '+InsuranceCompanyAddresses_1.State+' '+InsuranceCompanyAddresses_1.Zip as [Claim1 Address],  ")
        SQL.Append(" Patients.ClaimEffectiveDT1 as [Claim2 Eff DT], Patients.ClaimNumber as [Claim2 #],  ")
        SQL.Append(" InsuranceCompanyAddresses_2.Address+' '+InsuranceCompanyAddresses_2.City+' '+InsuranceCompanyAddresses_2.State+' '+InsuranceCompanyAddresses_2.Zip as [Claim2 Address],  ")
        SQL.Append(" ReferringOffices.OfficeName AS [Ref Office], Patients.ReferringDoctor as [Ref Doctor], Patients.Attorney, TransportationCompanies.CompanyName AS [Transport Company], Patients.Comments   ")
        SQL.Append("         FROM Patients ")
        SQL.Append(" LEFT OUTER JOIN CaseTypes ON Patients.CaseTypeID = CaseTypes.CaseTypeID   ")
        SQL.Append(" LEFT OUTER JOIN CaseStatuses ON Patients.CaseStatusID = CaseStatuses.CaseStatusID   ")
        SQL.Append(" LEFT OUTER JOIN PatientTypes ON Patients.PatientTypeID = PatientTypes.PatientTypeID   ")
        SQL.Append(" LEFT OUTER JOIN TransportationCompanies ON Patients.TransportationCompanyID = TransportationCompanies.CompanyID   ")
        SQL.Append(" LEFT OUTER JOIN InsuranceCompanyAddresses InsuranceCompanyAddresses_1 ON Patients.ClaimAddressID = InsuranceCompanyAddresses_1.AddressID   ")
        SQL.Append(" LEFT OUTER JOIN InsuranceCompanyAddresses InsuranceCompanyAddresses_2 ON Patients.ClaimAddressID1 = InsuranceCompanyAddresses_2.AddressID   ")
        SQL.Append(" LEFT OUTER JOIN ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID   ")
        SQL.Append(" LEFT OUTER JOIN InjuryTypes ON Patients.InjuryID = InjuryTypes.InjuryID   ")
        SQL.Append(" LEFT OUTER JOIN InsuranceCompanies InsuranceCompanies_1 ON Patients.InsuranceCompanyID1 = InsuranceCompanies_1.CompanyID   ")
        SQL.Append(" LEFT OUTER JOIN InsuranceCompanies InsuranceCompanies_2 ON Patients.InsuranceCompanyID = InsuranceCompanies_2.CompanyID   ")
        SQL.Append(" LEFT OUTER JOIN EmploymentStatuses ON Patients.EmploymentStatusID = EmploymentStatuses.EmploymentStatusID   ")
        SQL.Append(" LEFT OUTER JOIN MaritalStatuses ON Patients.MaritalStatusID = MaritalStatuses.MaritalStatusID  ")
        SQL.Append("         WHERE(1 = 2) ")

        Reader = gSQLGetDataReader(SQL.ToString)
        If Reader Is Nothing Then Exit Sub
        FpSpreadResults.ActiveSheet.ColumnCount = Reader.FieldCount
        FpSpreadResults.ActiveSheet.RowCount = 0
        Application.DoEvents()
        Dim C As Integer
        For C = 0 To Reader.FieldCount - 1
            FpSpreadResults.ActiveSheet.ColumnHeader.Columns(C).Label = Reader.GetName(C).ToString
            FpSpreadResults.ActiveSheet.Columns(C).Width = FpSpreadResults.ActiveSheet.Columns(C).GetPreferredWidth + 1
            FpSpreadResults.ActiveSheet.ColumnHeader.Columns(C).Tag = Reader.GetName(C).ToString
            ListBoxSpreadColumns.Items.Add(Reader.GetName(C).ToString)
        Next
        FpSpreadResults.ResumeLayout()
        Reader.Close() : Reader.Dispose()
    End Sub

    Public Sub Find_Patients()
        Dim SQL As New StringBuilder
        Dim Reader As SqlClient.SqlDataReader
        Dim rStr As String = ""
        FpSpreadResults.ActiveSheet.RowCount = 0
        Dim SearchBox As New String("")
        Dim SearchDoctor As New String("")
        Application.DoEvents()
        If txtSearch.Text = "First / Last Name / Patient #" Then
            SearchBox = ""
        Else
            SearchBox = txtSearch.Text.Trim
        End If
        SearchBox = SearchBox.ToSafeSQLString().ToString
        If cboReferringDoctor.Text = "" Then
            SearchDoctor = ""
        Else
            SearchDoctor = cboReferringDoctor.Text.Trim
        End If
        SearchDoctor = SearchDoctor.ToSafeSQLString().ToString
        SearchBox = SearchBox.ToSafeSQLString()
        On Error Resume Next
        If (TypeOf FpSpreadResults.ActiveSheet.Models.Data Is FarPoint.Win.Spread.Model.GroupDataModel) Then
            FpSpreadResults.ActiveSheet.Models.Data = CType(FpSpreadResults.ActiveSheet.Models.Data, FarPoint.Win.Spread.Model.GroupDataModel).TargetModel
        End If
        On Error GoTo 0


        SQL.Append("SELECT     Patients.InsertedDT, Patients.PatientID, CaseTypes.Description AS [Type], CaseStatuses.Description AS [Status], Patients.CaseStatusDate as [Status DT], InjuryTypes.InjuryName AS [Injury], Patients.DOA, PatientTypes.Description AS [Patient Type], Patients.NoMoreAppointmentsInd as [NoMoreApp], ")
        SQL.Append(" (SELECT COUNT(*) FROM PatientProcedures WHERE PatientID = Patients.PatientID) AS [Total Procs],   ")
        SQL.Append(" (SELECT COUNT(*) FROM PatientProcedures WHERE ProcedureStatusID = 2 AND PatientID = Patients.PatientID) AS [Cmpl Procs],   ")
        SQL.Append(" Patients.FName , Patients.MI , Patients.LName , Patients.Suffix , Patients.DOB, Patients.ParentsRequiredInd AS [Underage],  ")
        SQL.Append(" Patients.Sex, Patients.SSN, Patients.Address1, Patients.Address2, Patients.City, Patients.State, Patients.Zip, Patients.Phone1, Patients.Phone2,  ")
        SQL.Append(" Patients.CellPhone as CPhone, Patients.eMail, MaritalStatuses.Description AS [Martl Status], EmploymentStatuses.Description AS [Emp Status], Patients.Occupation, Patients.EmployerName as [Employer],  ")
        SQL.Append(" Patients.EmployerAddress as [Emp Address], Patients.EmployerPhone as [Emp Phone], InsuranceCompanies_1.CompanyName AS [Ins Company1], PolicyNumber as [Policy #], InsuranceCompanies_2.CompanyName AS [Ins Company2], PolicyNumber1 as [Policy #2],  ")
        SQL.Append(" Patients.ClaimEffectiveDT as [Claim1 Eff DT], Patients.ClaimNumber as [Claim1 #],  ")
        SQL.Append(" InsuranceCompanyAddresses_1.Address+' '+InsuranceCompanyAddresses_1.City+' '+InsuranceCompanyAddresses_1.State+' '+InsuranceCompanyAddresses_1.Zip as [Claim1 Address],  ")
        SQL.Append(" Patients.ClaimEffectiveDT1 as [Claim2 Eff DT], Patients.ClaimNumber as [Claim2 #],  ")
        SQL.Append(" InsuranceCompanyAddresses_2.Address+' '+InsuranceCompanyAddresses_2.City+' '+InsuranceCompanyAddresses_2.State+' '+InsuranceCompanyAddresses_2.Zip as [Claim2 Address],  ")
        SQL.Append(" ReferringOffices.OfficeName AS [Ref Office], Patients.ReferringDoctor as [Ref Doctor], Patients.Attorney, TransportationCompanies.CompanyName AS [Transport Company], Patients.Comments   ")
        SQL.Append("         FROM Patients ")
        SQL.Append(" LEFT OUTER JOIN CaseTypes ON Patients.CaseTypeID = CaseTypes.CaseTypeID   ")
        SQL.Append(" LEFT OUTER JOIN CaseStatuses ON Patients.CaseStatusID = CaseStatuses.CaseStatusID   ")
        SQL.Append(" LEFT OUTER JOIN PatientTypes ON Patients.PatientTypeID = PatientTypes.PatientTypeID   ")
        SQL.Append(" LEFT OUTER JOIN TransportationCompanies ON Patients.TransportationCompanyID = TransportationCompanies.CompanyID   ")
        SQL.Append(" LEFT OUTER JOIN InsuranceCompanyAddresses InsuranceCompanyAddresses_1 ON Patients.ClaimAddressID = InsuranceCompanyAddresses_1.AddressID   ")
        SQL.Append(" LEFT OUTER JOIN InsuranceCompanyAddresses InsuranceCompanyAddresses_2 ON Patients.ClaimAddressID1 = InsuranceCompanyAddresses_2.AddressID   ")
        SQL.Append(" LEFT OUTER JOIN ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID   ")
        SQL.Append(" LEFT OUTER JOIN InjuryTypes ON Patients.InjuryID = InjuryTypes.InjuryID   ")
        SQL.Append(" LEFT OUTER JOIN InsuranceCompanies InsuranceCompanies_1 ON Patients.InsuranceCompanyID = InsuranceCompanies_1.CompanyID   ")
        SQL.Append(" LEFT OUTER JOIN InsuranceCompanies InsuranceCompanies_2 ON Patients.InsuranceCompanyID1 = InsuranceCompanies_2.CompanyID   ")
        SQL.Append(" LEFT OUTER JOIN EmploymentStatuses ON Patients.EmploymentStatusID = EmploymentStatuses.EmploymentStatusID   ")
        SQL.Append(" LEFT OUTER JOIN MaritalStatuses ON Patients.MaritalStatusID = MaritalStatuses.MaritalStatusID  ")

        SQL.Append(" WHERE(Patients.OfficeID = " & gOfficeID & ") ")
        If SearchBox <> "" Then
            If IsNumeric(SearchBox) Then
                SQL.Append(" AND Patients.PatientID = " & Val(SearchBox))
            Else
                SQL.Append(" AND (Patients.Lname like '" & SearchBox & "%'  or Patients.Fname like '" & SearchBox & "%' )")
            End If
        End If

        If cboCaseStatusID.SelectedIndex > 0 Then
            SQL.Append(" AND Patients.CaseStatusID=" & CType(cboCaseStatusID.SelectedItem, ValueDescription).Value)
        End If
        If cboCaseTypeID.SelectedIndex > 0 AndAlso cboCaseTypeID.SelectedIndex <> 99 Then
            SQL.Append(" AND Patients.CaseTypeID=" & CType(cboCaseTypeID.SelectedItem, ValueDescription).Value)
        ElseIf cboCaseTypeID.SelectedIndex = 99 Then
            SQL.Append(" AND Patients.NoMoreAppointmentsInd=1")
        End If
        If cboInsuranceCompanyID.SelectedIndex > 0 Then
            SQL.Append(" AND (Patients.InsuranceCompanyID=" & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value.ToString & " or Patients.InsuranceCompanyID1=" & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value.ToString & ") ")
        End If
        If cboReferringCompanyID.SelectedIndex > 0 Then
            SQL.Append(" AND Patients.ReferringCompanyID=" & CType(cboReferringCompanyID.SelectedItem, ValueDescription).Value)
        End If

        If cboTransportationCompanyID.SelectedIndex > 0 Then
            SQL.Append(" AND Patients.TransportationCompanyID=" & CType(cboTransportationCompanyID.SelectedItem, ValueDescription).Value)
        End If
        If SearchDoctor <> "" Then
            SQL.Append(" AND Patients.ReferringDoctor LIKE '" & SearchDoctor & "%'")
        End If


        FpSpreadResults.SuspendLayout()
        FpSpreadResults.ActiveSheet.RowCount = 0
        Dim R As Integer = 0
        Dim DS As DataSet
        Reader = gSQLGetDataReader(SQL.ToString)
        DS = gSQLGetDataSet(SQL.ToString)
        If Reader Is Nothing Then Exit Sub
        Dim C As Integer
        Setup_Columns(False)
        FpSpreadResults.ActiveSheet.ColumnCount = 0
        FpSpreadResults.ActiveSheet.RowCount = 0
        Application.DoEvents()
        FpSpreadResults.ActiveSheet.AutoGenerateColumns = True
        FpSpreadResults.ActiveSheet.DataAutoSizeColumns = True
        FpSpreadResults.ActiveSheet.DataAutoCellTypes = False
        FpSpreadResults.ActiveSheet.DataMember = DS.Tables(0).TableName.ToString
        FpSpreadResults.ActiveSheet.DataSource = DS
        Dim ColWidth As Integer = 0
        Dim NewColWidth As Integer = 0
        For C = 0 To FpSpreadResults.ActiveSheet.ColumnCount - 1
            FpSpreadResults.ActiveSheet.ColumnHeader.Columns(C).Tag = Reader.GetName(C).ToString
        Next
        Format_Cells()
        For C = 0 To FpSpreadResults.ActiveSheet.ColumnCount - 1
            ColWidth = FpSpreadResults.ActiveSheet.Columns(C).Width
            NewColWidth = FpSpreadResults.ActiveSheet.Columns(C).GetPreferredWidth + 1
            FpSpreadResults.ActiveSheet.Columns(C).Width = NewColWidth
            FpSpreadResults.ActiveSheet.ColumnHeader.Columns(C).Tag = Reader.GetName(C).ToString
            FpSpreadResults.ActiveSheet.ColumnHeader.Columns(C).AllowAutoSort = True
        Next
        Setup_Columns(True)
        For C = 0 To FpSpreadResults.ActiveSheet.ColumnCount - 1
            FpSpreadResults.ActiveSheet.Columns(C).Width = FpSpreadResults.ActiveSheet.Columns(C).GetPreferredWidth + 1
        Next
        FpSpreadResults.ResumeLayout(True)
        If FpSpreadResults.ActiveSheet.RowCount > 0 Then
            FpSpreadResults.ActiveSheet.ActiveRowIndex = 0
            FpSpreadResults.ActiveSheet.AddSelection(0, 0, 1, 1)
            FpSpreadResults.Focus()
            If IsNumeric(FpSpreadResults.ActiveSheet.Cells(0, FpSpreadResults.ActiveSheet.Columns("PatientID").Index).Text.ToString) Then
                Show_Details(CLng(FpSpreadResults.ActiveSheet.Cells(0, FpSpreadResults.ActiveSheet.Columns("PatientID").Index).Text.ToString))
                btnPrint.Enabled = True
            Else
                btnPrint.Enabled = False
                Clear_Details()
            End If
        Else
            btnPrint.Enabled = False
            Clear_Details()
        End If
        FpSpreadResults.ResumeLayout(True)
        FpSpreadResults.Focus()
    End Sub
    Private Sub Setup_Columns(ByVal Read As Boolean)
        Dim C As FarPoint.Win.Spread.Column
        Dim I As Integer
        'Dim ColPos As Integer
        On Error Resume Next
        I = 0
        For Each C In FpSpreadResults.ActiveSheet.Columns
            If Read = True Then
                ListBoxSpreadColumns.SetItemChecked(I, GetSetting(My.Application.Info.ProductName, "GUI\" & UCase(Name) & "\FpSpreadResults_ColVisible", C.Tag, C.Visible))
                C.Visible = GetSetting(My.Application.Info.ProductName, "GUI\" & UCase(Name) & "\FpSpreadResults_ColVisible", C.Tag, C.Visible)
            Else
                SaveSetting(My.Application.Info.ProductName, "GUI\" & UCase(Name) & "\FpSpreadResults_ColVisible", C.Tag, C.Visible)
            End If
            I = I + 1
        Next
        Dim ColTag As String
        For I = 0 To FpSpreadResults.ActiveSheet.ColumnCount - 1
            If Read = True Then
                ColTag = GetSetting(My.Application.Info.ProductName, "GUI\" & UCase(Name) & "\FpSpreadResults_ColPosition", I, FpSpreadResults.ActiveSheet.Columns(I).Tag)
                FpSpreadResults.ActiveSheet.MoveColumn(FpSpreadResults.ActiveSheet.Columns(ColTag).Index, I, True)
            Else
                SaveSetting(My.Application.Info.ProductName, "GUI\" & UCase(Name) & "\FpSpreadResults_ColPosition", I, FpSpreadResults.ActiveSheet.Columns(I).Tag)
            End If
        Next
    End Sub
    Private Sub Format_Cells()
        Dim numberct As New FarPoint.Win.Spread.CellType.NumberCellType()
        numberct.DecimalPlaces = 0
        Dim dtct As New FarPoint.Win.Spread.CellType.DateTimeCellType()
        dtct.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate
        FpSpreadResults.ActiveSheet.Columns("InsertedDT").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        FpSpreadResults.ActiveSheet.Columns("InsertedDT").CellType = dtct
        FpSpreadResults.ActiveSheet.Columns("PatientID").CellType = numberct
        FpSpreadResults.ActiveSheet.Columns("DOB").CellType = dtct
        FpSpreadResults.ActiveSheet.Columns("DOA").CellType = dtct
        FpSpreadResults.ActiveSheet.Columns("Status DT").CellType = dtct
        FpSpreadResults.ActiveSheet.Columns("Status DT").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        FpSpreadResults.ActiveSheet.Columns("Claim1 Eff DT").CellType = dtct
        FpSpreadResults.ActiveSheet.Columns("Claim2 Eff DT").CellType = dtct
        FpSpreadResults.ActiveSheet.Columns("DOA").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        FpSpreadResults.ActiveSheet.Columns("NoMoreApp").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        FpSpreadResults.ActiveSheet.Columns("Total Procs").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        FpSpreadResults.ActiveSheet.Columns("Cmpl Procs").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right

    End Sub
    Private Sub Clear_Details()
        Dim I As Integer
        Dim SPHeight As Integer
        FpSpreadDetails_Sheet1.RowCount = 12
        For I = 0 To FpSpreadDetails_Sheet1.RowCount - 1
            FpSpreadDetails_Sheet1.SetText(I, 1, "")
            FpSpreadDetails_Sheet1.SetRowHeight(I, CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight))
            SPHeight = SPHeight + CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight)
        Next
        If FpSpreadDetails.Height <> SPHeight Then FpSpreadDetails.Height = SPHeight
        If FpSpreadProcedures.ActiveSheet.RowCount <> 0 Then FpSpreadProcedures.ActiveSheet.RowCount = 0
    End Sub
    Public Sub Find_Patient(ByVal ID As Long)
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        If ID = 0 Then Exit Sub
        txtSearch.Text = ""
        FpSpreadResults.ActiveSheet.RowCount = 0
        SQL = "SELECT PatientID, Fname, LName FROM Patients WHERE PatientID=" & ID.ToString
        Reader = gSQLGetDataReader(SQL)
        Do Until Reader.Read = False
            FpSpreadResults.ActiveSheet.RowCount = 1
            FpSpreadResults.ActiveSheet.SetText(1, 0, Reader("PatientID").ToString)
            FpSpreadResults.ActiveSheet.SetText(1, 1, Reader("Fname").ToString & " " & Reader("Lname").ToString)

            FpSpreadResults.ActiveSheet.Cells(1, 0).Tag = Val(Reader("PatientID").ToString)
        Loop
        If FpSpreadResults.ActiveSheet.RowCount > 0 Then
            FpSpreadResults.ActiveSheet.SetActiveCell(0, 0)
            btnPrint.Enabled = True
        Else
            btnPrint.Enabled = False
            Clear_Details()
        End If
        FpSpreadResults.Focus()
    End Sub




    Public Sub Show_Details(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim lCell As String
        Dim I As Integer
        Dim SPHeight As Integer
        If PanelDetails.Visible = False Then Exit Sub
        Clear_Details()
        SQL = "SELECT CaseTypes.Description as CaseType, Patients.NoMoreAppointmentsInd, Patients.CaseTypeID,  Patients.DOA, Patients.ParentsRequiredInd, Patients.PatientID,  Patients.FName, Patients.MI, Patients.LName, Patients.DOB, Patients.Phone1, Patients.Phone2, Patients.CellPhone, Patients.Address1, Patients.Address2, Patients.City, Patients.State, Patients.Zip, InsuranceCompanies_1.CompanyName AS Insurance1, InsuranceCompanies.CompanyName AS Insurance2, "
        SQL = SQL & " Patients.ReferringDoctor, ReferringOffices.OfficeName AS ReferringCompany, ReferringOffices.Phone1 AS RefPhone1, ReferringOffices.Phone2 AS RefPhone2, ReferringOffices.Phone3 AS RefPhone3, "
        SQL = SQL & " TransportationCompanies.CompanyName AS Transportation, TransportationCompanies.Phone1 AS TransPhone1, TransportationCompanies.Phone2 AS TransPhone2, TransportationCompanies.Phone3 AS TransPhone3, Patients.Comments "
        SQL = SQL & " FROM Patients LEFT OUTER JOIN TransportationCompanies ON Patients.TransportationCompanyID = TransportationCompanies.CompanyID LEFT OUTER JOIN ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID LEFT OUTER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID1 = InsuranceCompanies.CompanyID LEFT OUTER JOIN InsuranceCompanies AS InsuranceCompanies_1 ON Patients.InsuranceCompanyID = InsuranceCompanies_1.CompanyID Inner Join CaseTypes on Patients.CaseTypeID = CaseTypes.CaseTypeID"
        SQL = SQL & " WHERE Patients.PatientID = " & ID
        Reader = gSQLGetDataReader(SQL.ToString())
        If Reader Is Nothing Then Exit Sub
        FpSpreadDetails.ShowRow(FpSpreadDetails.GetActiveRowViewportIndex, 0, FarPoint.Win.Spread.VerticalPosition.Top)
        FpSpreadProcedures.ShowRow(FpSpreadDetails.GetActiveRowViewportIndex, 0, FarPoint.Win.Spread.VerticalPosition.Top)
        With FpSpreadDetails_Sheet1
            Do Until Reader.Read = False
                .SetText(0, 1, Reader("PatientID").ToString & " / " & Reader("CaseType").ToString)
                .Cells(0, 1).Tag = Val(Reader("CaseTypeID").ToString)
                .Cells(1, 0).ForeColor = Color.Black
                .Cells(1, 1).ForeColor = Color.Black
                If IsDate(Reader("DOA").ToString) Then
                    .SetText(1, 1, CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy"))
                    If Val(Reader("CaseTypeID").ToString) < 3 Then
                        If DateDiff(DateInterval.Day, CDate(Reader("DOA").ToString), Now) >= Val(gDOAAge) Then
                            .SetText(1, 1, CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy"))
                            .Cells(1, 0).ForeColor = Color.Red
                            .Cells(1, 1).ForeColor = Color.Red
                        End If
                    End If
                End If

                .SetText(2, 1, Reader("Fname").ToString & " " & Reader("MI").ToString & " " & Reader("Lname").ToString)
                If Reader("Phone1").ToString <> "" And Reader("Phone1").ToString <> "" Then .SetText(3, 1, Reader("Phone1").ToString)
                If Reader("CellPhone").ToString <> "" And Reader("CellPhone").ToString <> "" Then .SetText(4, 1, Reader("CellPhone").ToString)
                If Reader("Phone2").ToString <> "" And Reader("Phone2").ToString <> "" Then .SetText(5, 1, Reader("Phone2").ToString)
                .SetText(6, 1, Reader("Address1").ToString & " " & Reader("Address2").ToString & IIf(Reader("City").ToString <> "", ", " & Reader("City").ToString, "").ToString & IIf(Reader("State").ToString <> "", ", " & Reader("State").ToString, "").ToString & IIf(Replace(Reader("Zip").ToString, "_", "") <> "", ", " & Reader("Zip").ToString, "").ToString)
                .SetText(7, 1, Reader("Insurance1").ToString)
                .SetText(8, 1, Reader("Insurance2").ToString)
                lCell = Reader("ReferringCompany").ToString
                lCell = lCell & IIf(Reader("RefPhone1").ToString <> "" And Reader("RefPhone1").ToString <> "", vbCrLf & Reader("RefPhone1").ToString, "").ToString
                lCell = lCell & IIf(Reader("RefPhone2").ToString <> "" And Reader("RefPhone2").ToString <> "", vbCrLf & Reader("RefPhone2").ToString, "").ToString
                lCell = lCell & IIf(Reader("RefPhone3").ToString <> "" And Reader("RefPhone3").ToString <> "", vbCrLf & Reader("RefPhone3").ToString, "").ToString
                lCell = lCell & IIf(Reader("ReferringDoctor").ToString <> "", vbCrLf & Reader("ReferringDoctor").ToString, "").ToString
                .SetText(9, 1, lCell)
                lCell = Reader("Transportation").ToString
                lCell = lCell & IIf(Reader("TransPhone1").ToString <> "" And Reader("TransPhone1").ToString <> "", vbCrLf & Reader("TransPhone1").ToString, "").ToString
                lCell = lCell & IIf(Reader("TransPhone2").ToString <> "" And Reader("TransPhone2").ToString <> "", vbCrLf & Reader("TransPhone2").ToString, "").ToString
                lCell = lCell & IIf(Reader("TransPhone3").ToString <> "" And Reader("TransPhone3").ToString <> "", vbCrLf & Reader("TransPhone3").ToString, "").ToString
                .SetText(10, 1, lCell)
                .SetText(11, 1, Reader("Comments").ToString.Trim)
                .Cells(11, 1).ForeColor = Color.Chocolate
                If Val(Reader("ParentsRequiredInd").ToString) = 1 Then
                    .RowCount = .RowCount + 1
                    .SetText(.RowCount - 1, 0, "Attention")
                    .SetText(.RowCount - 1, 1, "Underage Patient!")
                    .Cells(.RowCount - 1, 0).ForeColor = Color.Red
                    .Cells(.RowCount - 1, 1).ForeColor = Color.Red
                End If
                If Val(Reader("NoMoreAppointmentsInd").ToString) > 0 Then
                    .RowCount = .RowCount + 1
                    .SetText(.RowCount - 1, 0, "Attention")
                    .SetText(.RowCount - 1, 1, "No More Appointments!")
                    .Cells(.RowCount - 1, 0).ForeColor = Color.Red
                    .Cells(.RowCount - 1, 1).ForeColor = Color.Red
                End If

            Loop
            For I = 0 To .RowCount - 1
                .SetRowHeight(I, CInt(.Rows(I).GetPreferredHeight))
                SPHeight = SPHeight + CInt(.Rows(I).GetPreferredHeight)
            Next
        End With
        FpSpreadDetails.Height = SPHeight
        SQL = "SELECT     PatientProcedures.PatientProcedureID, PatientProcedures.ProcID, PatientProcedures.DiagID, PatientProcedures.ProcedureStatusID, Procedures.ProcName, Schedule.ScheduleDateTime "
        SQL = SQL & " FROM         PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID "
        SQL = SQL & " WHERE PatientProcedures.PatientID = " & ID
        SQL = SQL & " Order by PatientProcedures.ProcID "
        Reader = gSQLGetDataReader(SQL.ToString())
        FpSpreadProcedures.ActiveSheet.RowCount = 0
        SPHeight = 0
        If Reader Is Nothing Then Exit Sub
        With FpSpreadProcedures.ActiveSheet
            Do Until Reader.Read = False
                .RowCount = .RowCount + 1
                .SetText(.RowCount - 1, 0, Reader("ProcedureStatusID").ToString)
                .SetText(.RowCount - 1, 1, Reader("ProcName").ToString)
                If Reader("ScheduleDateTime").ToString <> "" Then
                    If Val(Reader("ProcedureStatusID").ToString) = 1 And DateDiff(DateInterval.Hour, CDate(Reader("ScheduleDateTime")), Now) > gNoShowHours Then
                        .Cells(.RowCount - 1, 1).ForeColor = Color.DarkRed
                        .Cells(.RowCount - 1, 1).Font = New Font(FpSpreadProcedures.Font, FontStyle.Bold)
                    End If
                End If
                '.SetRowHeight(.RowCount - 1, CInt(.Rows(.RowCount - 1).GetPreferredHeight + 2))
                'SPHeight = SPHeight + CInt(.Rows(.RowCount - 1).GetPreferredHeight)
            Loop
        End With

    End Sub

    Private Sub frmScheduleSearchPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting(My.Application.Info.ProductName, "Settings", "SearchAdvancedPanel", ShowAdvancedSearchToolStripMenuItem.Checked)
        SaveSetting(My.Application.Info.ProductName, "Settings", "SearchPatientDetails", PatientDetailsToolStripMenuItem.Checked)

        gSpread_Settings(Me, FpSpreadResults, ReadWrite.sWrite)
        Setup_Columns(False)
        If ForceExit = False Then
            If e.CloseReason = CloseReason.UserClosing Then
                e.Cancel = True
                Me.Hide()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub frmSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        ' If e.KeyValue = 13 Then
        'ButtonFind_Click(Nothing, Nothing)
        'End If
    End Sub
    Private Sub frmScheduleSearchPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowAdvancedSearchToolStripMenuItem.Checked = GetSetting(My.Application.Info.ProductName, "Settings", "SearchAdvancedPanel", True)
        PatientDetailsToolStripMenuItem.Checked = GetSetting(My.Application.Info.ProductName, "Settings", "SearchPatientDetails", True)
        PanelDetails.Visible = PatientDetailsToolStripMenuItem.Checked
        If ShowAdvancedSearchToolStripMenuItem.Checked Then
            PanelSearch.Height = 128
        Else
            PanelSearch.Height = 48
        End If
        gSetup_GotFocus(Me)
        'gSpread_Settings(Me, FpSpreadResults, ReadWrite.sRead)
        Load_Data()
        Setup_ColumnsHeaders()
        Setup_Columns(True)
        FpSpreadProcedures.ActiveSheet.RowCount = 0
        Setup_SearchComboBoxes()
        Application.DoEvents()
        FpSpreadResults.GetRootWorkbook.SetImage(FarPoint.Win.Spread.SpreadView.SortAscendingImage, PicAcsending.Image)
        FpSpreadResults.GetRootWorkbook.SetImage(FarPoint.Win.Spread.SpreadView.SortDescendingImage, picDesc.Image)
        FpSpreadResults.GetRootWorkbook.SetImage(FarPoint.Win.Spread.SpreadView.SortUnsortedImage, PicNone.Image)

    End Sub
    Private Sub Setup_SearchComboBoxes()
        AddHandler cboInsuranceCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboInsuranceCompanyID.Leave, AddressOf sSearchComboBox_Leave
        AddHandler cboCaseStatusID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboCaseStatusID.Leave, AddressOf sSearchComboBox_Leave
        AddHandler cboCaseTypeID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboCaseTypeID.Leave, AddressOf sSearchComboBox_Leave
        AddHandler cboReferringCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboReferringCompanyID.Leave, AddressOf sSearchComboBox_Leave
        AddHandler cboTransportationCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboTransportationCompanyID.Leave, AddressOf sSearchComboBox_Leave
        AddHandler cboReferringDoctor.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboReferringDoctor.Leave, AddressOf sSearchComboBox_Leave

    End Sub
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Reader = gSQLGetDataReader("SELECT CaseStatusID, Description FROM CaseStatuses Order By ShowOrder")
        If Reader Is Nothing Then Exit Sub
        cboCaseStatusID.Items.Add(New ValueDescription(0, "Case Status"))
        Do Until Reader.Read = False
            cboCaseStatusID.Items.Add(New ValueDescription(CLng(Val(Reader("CaseStatusID").ToString)), Reader("Description").ToString))
        Loop
        cboCaseStatusID.Items.Add(New ValueDescription(99, "No More Appointments"))

        Reader.Close() : Reader.Dispose()
        cboReferringCompanyID.Items.Add(New ValueDescription(0, "Referring Company"))
        Reader = gSQLGetDataReader("Select OfficeID, OfficeName from ReferringOffices Where ActiveInd=1")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboReferringCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)), Reader("OfficeName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboAttorneysCompanyID.Items.Add(New ValueDescription(0, "Attorney"))
        Reader = gSQLGetDataReader("Select CompanyID, CompanyName, AttorneyFName+' '+AttorneyLName as AttorneyName from Attorneys where OfficeID = " & gOfficeID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboAttorneysCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString & " - " & Reader("AttorneyName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboCaseTypeID.Items.Add(New ValueDescription(0, "Case Type"))
        Reader = gSQLGetDataReader("Select CaseTypeID, Description from CaseTypes")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboCaseTypeID.Items.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)), Reader("Description").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboTransportationCompanyID.Items.Add(New ValueDescription(0, "Transportation Company"))
        Reader = gSQLGetDataReader("Select CompanyID, CompanyName from TransportationCompanies Where ActiveInd=1")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboTransportationCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboProcedureStatus.Items.Add(New ValueDescription(0, "Procedure Status"))
        Reader = gSQLGetDataReader("SELECT     ProcedureStatusID, Description FROM         PatientProcedureStatuses")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboProcedureStatus.Items.Add(New ValueDescription(CLng(Val(Reader("ProcedureStatusID").ToString)), Reader("Description").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboDiags.Items.Add(New ValueDescription(0, "Diagnostic"))
        Reader = gSQLGetDataReader("SELECT     DiagID, DiagName FROM         [Diagnostics]")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboDiags.Items.Add(New ValueDescription(CLng(Val(Reader("DiagID").ToString)), Reader("DiagName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboBillStatus.Items.Add(New ValueDescription(0, "Bill Status"))
        Reader = gSQLGetDataReader("SELECT     BillStatusID, Description FROM         BillStatus")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboBillStatus.Items.Add(New ValueDescription(CLng(Val(Reader("BillStatusID").ToString)), Reader("Description").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        Clear_SearchCriteria()
    End Sub
    Private Sub Clear_SearchCriteria()
        txtSearch.Text = "First / Last Name / Patient #"
        cboReferringDoctor.Items.Clear()
        cboCaseStatusID.SelectedIndex = 0
        cboReferringCompanyID.SelectedIndex = 0
        cboAttorneysCompanyID.SelectedIndex = 0
        cboCaseTypeID.SelectedIndex = 0
        cboInsuranceCompanyID.SelectedIndex = 0
        cboTransportationCompanyID.SelectedIndex = 0
        cboBillStatus.SelectedIndex = 0
        cboProcedureStatus.SelectedIndex = 0
        cboDiags.SelectedIndex = 0
        DTPFrom.Checked = False
        DTPTo.Checked = False
        txtPolicyNumber.Text = ""


    End Sub
    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        ButtonFind.Enabled = False
        Cursor = Cursors.WaitCursor
        PanelSearch.SuspendLayout()
        Application.DoEvents()
        Find_Patients()
        PanelSearch.ResumeLayout(True)
        ButtonFind.Enabled = True
        Cursor = Cursors.Default
    End Sub


    Private Sub ComboBoxCaseTypeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaseTypeID.SelectedIndexChanged
        cboInsuranceCompanyID.Items.Clear()
        If CType(cboCaseTypeID.SelectedItem, ValueDescription).Value = 0 Then
            cboInsuranceCompanyID.Items.Add(New ValueDescription(0, "Select Case Type First"))
            cboInsuranceCompanyID.SelectedIndex = 0
            cboInsuranceCompanyID.DropDownHeight = 20
            Exit Sub
        End If
        cboInsuranceCompanyID.Items.Add(New ValueDescription(0, "Insurance Company"))
        cboInsuranceCompanyID.SelectedIndex = 0
        cboInsuranceCompanyID.DropDownHeight = 106
        Dim Reader As SqlClient.SqlDataReader
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Reader = gSQLGetDataReader("Select CompanyID, CompanyName from InsuranceCompanies Where CaseTypeID =" & CType(cboCaseTypeID.SelectedItem, ValueDescription).Value & " ORDER BY CompanyName")
        If Reader Is Nothing Then GoTo ExitSub
        Do Until Reader.Read = False
            cboInsuranceCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString))
            'ComboBoxInsuranceCompanyID.AutoCompleteCustomSource.Add(Reader("CompanyName").ToString)
        Loop
        If cboInsuranceCompanyID.Items.Count = 0 Then
            cboInsuranceCompanyID.DropDownHeight = 20
        End If
        Reader.Close() : Reader.Dispose()
ExitSub:
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        Clear_SearchCriteria()
    End Sub

    Private Sub FpSpread1_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadResults.CellClick
        If e.Row = 0 Then
            Dim C As Integer = e.Column
            ListBoxSpreadColumns.Text = FpSpreadResults.ActiveSheet.Columns(C).Label
            Exit Sub
        End If
        FpSpread1_EnterCell(sender, Nothing)
    End Sub

    Private Sub FpSpread1_EnterCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EnterCellEventArgs) Handles FpSpreadResults.EnterCell
        PanelSearch.SuspendLayout()
        If Not FpSpreadResults.ActiveSheet.ActiveCell Is Nothing Then
            If PanelDetails.Visible = True And IsNumeric(FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, FpSpreadResults.ActiveSheet.Columns("PatientID").Index).Text.ToString) Then
                If FpSpreadResults.ActiveSheet.ActiveCell Is Nothing Then Exit Sub
                If Val(FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, FpSpreadResults.ActiveSheet.Columns("PatientID").Index).Text.ToString) <> 0 Then
                    Show_Details(Val(FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, FpSpreadResults.ActiveSheet.Columns("PatientID").Index).Text.ToString))
                Else
                    Clear_Details()
                End If
            Else
                Clear_Details()
            End If
        Else
            Clear_Details()
        End If
        PanelSearch.ResumeLayout()

    End Sub

    Private Sub ComboBoxReferringCompanyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReferringCompanyID.SelectedIndexChanged
        cboReferringDoctor.Items.Clear()
        cboReferringDoctor.Text = ""
        If cboReferringCompanyID.SelectedIndex = -1 Or cboReferringCompanyID.SelectedIndex = 0 Then
            Exit Sub
        End If
        Dim Reader As SqlClient.SqlDataReader
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Reader = gSQLGetDataReader("Select * from ReferringOffices Where OfficeID =" & CType(cboReferringCompanyID.SelectedItem, ValueDescription).Value.ToString)
        If Reader Is Nothing Then GoTo ExitSub
        Do Until Reader.Read = False
            For d As Integer = 1 To gReferringOfficeDoctors
                If Reader("Doctor" + d.ToString()).ToString.Trim <> "" Then cboReferringDoctor.Items.Add(Reader("Doctor" + d.ToString()).ToString.Trim)
            Next
        Loop
        Reader.Close() : Reader.Dispose()
        If cboReferringDoctor.Items.Count = 1 Then
            cboReferringDoctor.SelectedIndex = 0
        End If
ExitSub:
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDetails.Click
        PanelDetails.Visible = False
        PatientDetailsToolStripMenuItem.Checked = False
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        Printinfo.SmartPrintPagesWide = 1
        Printinfo.BestFitRows = True
        Printinfo.Preview = True
        Printinfo.ShowShadows = False
        Printinfo.JobName = "eMedical Office Schedule"
        Printinfo.PrintType = FarPoint.Win.Spread.PrintType.All
        Printinfo.ShowColor = True
        Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.ShowBorder = False
        Printinfo.ShowGrid = True
        Printinfo.ShowPrintDialog = True
        Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
        Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.All))
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.BestFitColumnRule(FarPoint.Win.Spread.ResetOption.None))
        Printinfo.UseSmartPrint = True
        Printinfo.UseMax = True
        FpSpreadResults.ActiveSheet.PrintInfo = Printinfo
        FpSpreadResults.PrintSheet(FpSpreadResults.ActiveSheet)
    End Sub
    Private Sub ButtonSpreadColumnsHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSpreadColumnsHide.Click
        PanelSpreadColumns.Visible = False
        CustomiseColumnsToolStripMenuItem.Checked = False
    End Sub
    Private Sub ListBoxSpreadColumns_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListBoxSpreadColumns.ItemCheck
        If e.NewValue = CheckState.Checked Then
            FpSpreadResults.ActiveSheet.Columns(ListBoxSpreadColumns.Items(e.Index).ToString).Visible = True
        Else
            FpSpreadResults.ActiveSheet.Columns(ListBoxSpreadColumns.Items(e.Index).ToString).Visible = False
        End If
    End Sub

    Private Sub FpSpreadResults_LeftChange(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.LeftChangeEventArgs) Handles FpSpreadResults.LeftChange
        Dim C As Integer = e.NewLeft
        ListBoxSpreadColumns.Text = FpSpreadResults.ActiveSheet.Columns(C).Label
    End Sub
    Private Sub PatientDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatientDetailsToolStripMenuItem.Click
        PanelDetails.Visible = PatientDetailsToolStripMenuItem.Checked
    End Sub

    Private Sub CustomiseColumnsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomiseColumnsToolStripMenuItem.Click
        PanelSpreadColumns.Visible = CustomiseColumnsToolStripMenuItem.Checked
    End Sub
    Private Sub GroupResultsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupResultsToolStripMenuItem.Click
        If GroupResultsToolStripMenuItem.Checked Then
            FpSpreadResults.ActiveSheet.AllowGroup = True
            FpSpreadResults.ActiveSheet.GroupBarVisible = True
        Else
            FpSpreadResults.ActiveSheet.AllowGroup = False
            FpSpreadResults.ActiveSheet.GroupBarVisible = False
            If (TypeOf FpSpreadResults.ActiveSheet.Models.Data Is FarPoint.Win.Spread.Model.GroupDataModel) Then
                FpSpreadResults.ActiveSheet.Models.Data = CType(FpSpreadResults.ActiveSheet.Models.Data, FarPoint.Win.Spread.Model.GroupDataModel).TargetModel
            End If

        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAdvancedSearchToolStripMenuItem.Click
        If ShowAdvancedSearchToolStripMenuItem.Checked Then
            PanelSearch.Height = 168
        Else
            PanelSearch.Height = 48
        End If
    End Sub

    Private Sub CloseSearchWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseSearchWindowToolStripMenuItem.Click
        ForceExit = True
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub cboInsuranceCompanyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInsuranceCompanyID.SelectedIndexChanged

    End Sub

    Private Sub FpSpreadDetails_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadDetails.CellClick

    End Sub
End Class