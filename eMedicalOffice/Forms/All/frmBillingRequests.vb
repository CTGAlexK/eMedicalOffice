Public Class frmBillingRequests
    Public BillID As Long
    Public PatientID As Long
    Public BillAttorney As String
    Public BillInsurance As String

    Private Sub frmBillingAddRequest_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ChangesMade = True And FpSpreadRequests.ActiveSheet.RowCount > 1 Then
            If MsgBox("Discard Changes?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        gSpread_Settings(Me, FpSpreadRequests, ReadWrite.sWrite)
        gWindow_Settings(Me, ReadWrite.sWrite)
        If Update = True Then Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmBillingRequests_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            ButtonFind_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmBillingRequests_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmBillingAddRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        FpSpreadRequests.ActiveSheet.RowCount = 0

        Button1.Enabled = gCurrentEmployee.PositionID < 3
        gSpread_Settings(Me, FpSpreadRequests, ReadWrite.sRead)
        Timer1.Enabled = True
    End Sub

    Private LoadingFlag As Boolean

    Private Sub Load_Data()
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        cmbocell = New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim Arlst As New ArrayList
        Dim ArlstData As New ArrayList
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        ''''''''''''''''''''''''''''''''''''
        LoadingFlag = True
        SQL = "SELECT     EmpID, Fname + ' ' + Lname AS EmpName  FROM Employees WHERE PositionID <> 5 and EmpID in (select EmpID from EmployeeOffice where OfficeID=" & gOfficeID & ")  ORDER BY EmpName "
        Reader = gSQLGetDataReader(SQL)
        cboEmployee.Items.Clear()
        cboEmployee.Items.Add(New ValueDescription(0, "Show All"))
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboEmployee.Items.Add(New ValueDescription(Val(Reader("EmpID").ToString), Reader("EmpName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboEmployee.SelectedIndex = 0

        SQL = "SELECT     StatusID, Description   FROM BillingRequestStatuses ORDER BY StatusID "
        Reader = gSQLGetDataReader(SQL)
        cboStatus.Items.Clear()
        cboStatus.Items.Add(New ValueDescription(0, "Show All"))
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboStatus.Items.Add(New ValueDescription(Val(Reader("StatusID").ToString), Reader("Description").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        cboStatus.SelectedIndex = 1

        SQL = "SELECT     Description FROM BillingRequestTypes ORDER BY Description "
        Reader = gSQLGetDataReader(SQL)
        cboRequest.Items.Clear()
        cboRequest.Items.Add("")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboRequest.Items.Add(Reader("Description").ToString)
        Loop
        Reader.Close() : Reader.Dispose()
        cboRequest.SelectedIndex = 0

        SQL = "SELECT DISTINCT RequestFrom FROM BillingRequests ORDER BY RequestFrom "
        Reader = gSQLGetDataReader(SQL)
        cboRequestFrom.Items.Clear()
        cboRequestFrom.Items.Add("")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboRequestFrom.Items.Add(Reader("RequestFrom").ToString)
        Loop
        Reader.Close() : Reader.Dispose()
        cboRequestFrom.SelectedIndex = 0

        Arlst.Clear()
        ArlstData.Clear()
        SQL = "SELECT     StatusID, Description FROM         BillingRequestStatuses order by StatusID "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            Arlst.Add(Reader("Description").ToString)
            ArlstData.Add(Reader("StatusID").ToString)
        Loop

        cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
        cmbocell.Items = Arlst.Clone.ToArray(GetType(String))
        cmbocell.ItemData = ArlstData.Clone.ToArray(GetType(String))
        cmbocell.AutoSearch = FarPoint.Win.AutoSearch.MultipleCharacter
        cmbocell.Editable = False
        cmbocell.MaxDrop = 20
        FpSpreadRequests.ActiveSheet.Columns(7).CellType = cmbocell
        If gCurrentEmployee.PositionID > 2 Then
            FpSpreadRequests.ActiveSheet.Columns(7).Locked = True
            FpSpreadRequests.ActiveSheet.Columns(7).BackColor = Color.WhiteSmoke
        End If

        Load_Requests()
        LoadingFlag = False
        '''''''''''''''''''''''''
    End Sub

    Private Sub Load_Requests()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim PName() As String
        FpSpreadRequests.ActiveSheet.RowCount = 0

        SQL = "SELECT   Patients.FName, Patients.LName, Patients.MI,  BillingRequests.Priority, BillingRequests.CDProcedures, BillingRequests.RequestID, BillingRequests.BillID, BillingRequests.PatientID, "
        SQL &= "              BillingRequests.RequestDescription, BillingRequests.RequestFrom, BillingRequests.ResponsibleEmpID, BillingRequests.RequestDate, BillingRequests.RequestStatusID, "
        SQL &= "               BillingRequests.StatusDate, BillingRequestStatuses.Description AS Status, Employees.Fname +' '+ Employees.Lname as EmpName "
        SQL &= " FROM         BillingRequests INNER JOIN BillingRequestStatuses ON BillingRequests.RequestStatusID = BillingRequestStatuses.StatusID "
        SQL &= "               INNER JOIN  Employees ON BillingRequests.ResponsibleEmpID = Employees.EmpID"
        SQL &= "               INNER JOIN  Patients ON BillingRequests.PatientID = Patients.PatientID"
        SQL &= " WHERE 1=1 "

        If IsNumeric(txtPatient.Text.Trim) Then
            SQL &= " AND BillingRequests.PatientID = " & Val(txtPatient.Text.Trim)
        Else
            If IsNumeric(txtBillNo.Text.Trim) Then
                SQL &= " AND BillingRequests.BillID = " & Val(txtBillNo.Text.Trim)
            Else
                If cboStatus.SelectedIndex > 0 Then
                    SQL &= " AND RequestStatusID = " & CType(cboStatus.SelectedItem, ValueDescription).Value
                End If

                If cboEmployee.SelectedIndex > 0 Then
                    SQL &= " AND ResponsibleEmpID = " & CType(cboEmployee.SelectedItem, ValueDescription).Value
                End If

                If cboRequest.Text.Trim <> "" Then
                    SQL &= " AND RequestDescription like '%" & cboRequest.Text.ToSafeSQLString() & "%'"
                End If

                If txtPatient.Text.Trim <> "" Then

                    PName = Split(txtPatient.Text.Trim.ToSafeSQLString(), " ")
                    Select Case PName.Length
                        Case 1
                            If PName(0).Trim = "*" Then PName(0) = ""
                            SQL &= " and (Patients.FName Like '" & PName(0).Trim & "%' or Patients.LName Like '" & PName(0) & "%') "
                        Case 2
                            SQL &= " and ("
                            SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.LName Like '" & PName(1).Trim & "%') "
                            SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.LName Like '" & PName(0).Trim & "%')"
                            SQL &= " )"
                        Case 3
                            SQL &= " and ("
                            SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" & PName(1).Trim & "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                            SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" & PName(2).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                            SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" & PName(0).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "
                            SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" & PName(1).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                            SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" & PName(0).Trim & "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                            SQL &= " OR (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" & PName(2).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "

                            SQL &= " )"
                    End Select
                End If

                If cboRequestFrom.Text.Trim <> "" Then
                    SQL &= " AND RequestFrom like '%" & cboRequestFrom.Text.Trim.ToSafeSQLString() & "%'"
                End If
            End If
        End If

        SQL &= " ORDER BY RequestDate"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub

        Do Until Reader.Read = False
            R = R + 1
            FpSpreadRequests.ActiveSheet.RowCount = R
            'FpSpreadRequests.ActiveSheet.Cells(R - 1, 0).Text = FormatDateTime(Reader("RequestDate").ToString, DateFormat.GeneralDate)
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 0).Text = Reader("RequestDate").ToString
            If Val(Reader("RequestStatusID").ToString) = 1 Then
                If DateDiff(DateInterval.Day, CDate(Reader("RequestDate").ToString), Now.Date) > 2 Then
                    FpSpreadRequests.ActiveSheet.Cells(R - 1, 0).BackColor = Color.LightPink
                    FpSpreadRequests.ActiveSheet.Cells(R - 1, 7).BackColor = Color.LightPink
                    FpSpreadRequests.ActiveSheet.Rows(R - 1).BackColor = Color.LightPink
                End If
                If DateDiff(DateInterval.Day, CDate(Reader("RequestDate").ToString), Now.Date) > 5 Then
                    FpSpreadRequests.ActiveSheet.Cells(R - 1, 0).BackColor = Color.Red
                    FpSpreadRequests.ActiveSheet.Cells(R - 1, 0).ForeColor = Color.White
                    FpSpreadRequests.ActiveSheet.Cells(R - 1, 7).BackColor = Color.Red
                    FpSpreadRequests.ActiveSheet.Rows(R - 1).BackColor = Color.Red
                    FpSpreadRequests.ActiveSheet.Rows(R - 1).ForeColor = Color.White
                End If
            ElseIf Val(Reader("RequestStatusID").ToString) = 2 Then
                If DateDiff(DateInterval.Day, CDate(Reader("RequestDate").ToString), Now.Date) > 5 Then
                    FpSpreadRequests.ActiveSheet.Cells(R - 1, 0).BackColor = Color.LightPink
                    FpSpreadRequests.ActiveSheet.Cells(R - 1, 7).BackColor = Color.LightPink
                    FpSpreadRequests.ActiveSheet.Rows(R - 1).BackColor = Color.LightPink
                End If
            ElseIf Val(Reader("RequestStatusID").ToString) = 3 Then
                FpSpreadRequests.ActiveSheet.Cells(R - 1, 0).BackColor = Color.LightGreen
                FpSpreadRequests.ActiveSheet.Cells(R - 1, 7).BackColor = Color.LightGreen
                FpSpreadRequests.ActiveSheet.Rows(R - 1).BackColor = Color.LightGreen
            ElseIf Val(Reader("RequestStatusID").ToString) = 4 Then
                FpSpreadRequests.ActiveSheet.Cells(R - 1, 0).BackColor = Color.LightGray
                FpSpreadRequests.ActiveSheet.Cells(R - 1, 7).BackColor = Color.LightGray
                FpSpreadRequests.ActiveSheet.Rows(R - 1).BackColor = Color.LightGray
            End If
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 1).Text = Reader("RequestDescription").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 1).Tag = Reader("RequestID").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 2).Text = Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 2).Tag = Val(Reader("PatientID").ToString)
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 3).Text = Reader("BillID").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 4).Text = Reader("RequestFrom").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 5).Text = Reader("EmpName").ToString

            FpSpreadRequests.ActiveSheet.Cells(R - 1, 6).Text = Choose(Val(Reader("Priority").ToString) + 1, "Normal", "Urgent")
            If Val(Reader("Priority").ToString) = 1 Then
                FpSpreadRequests.ActiveSheet.Cells(R - 1, 6).BackColor = Color.Orchid
                FpSpreadRequests.ActiveSheet.Cells(R - 1, 6).ForeColor = Color.White
            Else

            End If
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 7).Value = Reader("RequestStatusID").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 7).Tag = Reader("RequestStatusID").ToString

            'FpSpreadRequests.ActiveSheet.Cells(R - 1, 8).Text = FormatDateTime(Reader("StatusDate").ToString, DateFormat.GeneralDate)
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 8).Text = Reader("StatusDate").ToString
            FpSpreadRequests.ActiveSheet.Cells(R - 1, 9).Text = Reader("CDProcedures").ToString
        Loop
        ChangesMade = False
    End Sub

    Private ChangesMade As Boolean
    Private Update As Boolean

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SQL As String
        Dim RowIndex As Integer
        Dim RequestDescription As String
        Dim RequestTypeID As Integer
        Dim RequestFrom As String
        Dim ResponsibleEmpID As Long
        Dim RequestStatusID As Long
        Dim Priority As Long
        Dim CDProcedures As String
        Dim RequestID As Long
        Dim Reader As SqlClient.SqlDataReader
        Dim SaveRequestStatusID As Long
        For RowIndex = 0 To FpSpreadRequests.ActiveSheet.RowCount - 1
            RequestID = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 1).Tag)
            RequestStatusID = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 7).Value)
            SaveRequestStatusID = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 7).Tag)

            If Val(RequestStatusID) <> 0 Then
                If RequestStatusID <> SaveRequestStatusID Then
                    FpSpreadRequests.ActiveSheet.Cells(RowIndex, 8).Text = Now
                    FpSpreadRequests.ActiveSheet.Cells(RowIndex, 7).BackColor = Color.White
                    FpSpreadRequests.ActiveSheet.Cells(RowIndex, 7).Tag = Val(RequestStatusID)
                    gSQLUpdateData("Update BillingRequests Set RequestStatusID = " & Val(RequestStatusID) & ", StatusDate = getdate() Where RequestID = " & Val(RequestID))
                    Select Case Val(RequestStatusID)
                        Case 1  'New
                            gUpdate_Profile_Log(PatientID, PatientLogTypes.tRequestCreated, "Request Status Change Request Created")
                        Case 2  'Inprogress
                            gUpdate_Profile_Log(PatientID, PatientLogTypes.tRequestInProgress, "Request Status Change Request In Progress")
                        Case 3  'Complete
                            gUpdate_Profile_Log(PatientID, PatientLogTypes.tRequestCompleted, "Request Status Change Request Completed")
                        Case 4  'Canceled
                            gUpdate_Profile_Log(PatientID, PatientLogTypes.tScheduleCanceled, "Request Status Change Schedule Canceled")
                    End Select

                End If
            ElseIf (RequestDescription.Trim <> "" Or RequestFrom <> "" Or Val(ResponsibleEmpID) <> 0 Or Val(RequestStatusID) <> 0) And (RequestDescription.Trim = "" Or RequestFrom = "" Or Val(ResponsibleEmpID) = 0 Or Val(RequestStatusID) = 0) Then
                MsgBox("Unable to process your request. Incomplete Request Information.", MsgBoxStyle.Exclamation)
                gSpreadActivateCell(FpSpreadRequests, RowIndex, 8)
                Exit Sub
            End If
        Next
        ChangesMade = False
        Update = True
        'Me.Close()
    End Sub

    Private Sub FpSpreadRequests_ComboCloseUp(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpreadRequests.ComboCloseUp

        Dim I As Integer

        If Val(FpSpreadRequests.ActiveSheet.Cells(e.Row, e.Column).Tag) <> Val(FpSpreadRequests.ActiveSheet.Cells(e.Row, e.Column).Value) Then
            FpSpreadRequests.ActiveSheet.Cells(e.Row, e.Column).BackColor = Color.Orange
        Else
            FpSpreadRequests.ActiveSheet.Cells(e.Row, e.Column).BackColor = Color.White
        End If
        ChangesMade = False
        For I = 0 To FpSpreadRequests.ActiveSheet.RowCount - 1
            If Val(FpSpreadRequests.ActiveSheet.Cells(I, e.Column).Tag) <> Val(FpSpreadRequests.ActiveSheet.Cells(I, e.Column).Value) Then
                ChangesMade = True
                Exit For
            End If
        Next
    End Sub

    Private Sub FpSpreadRequests_EnterCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EnterCellEventArgs) Handles FpSpreadRequests.EnterCell
        Dim RequestID As Long
        Dim RowIndex = e.Row
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        Clear_Details()
        ListViewActions.Items.Clear()
        RequestID = Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 1).Tag)
        If RequestID = 0 Then Exit Sub
        SQL = "SELECT Fname+' '+Fname as EmpName, RequestActionID, RequestID, Description, RequestActionDate FROM BillingRequestActions inner join Employees on BillingRequestActions.CreatedBy = Employees.EmpID where RequestID = " & RequestID
        Reader = gSQLGetDataReader(SQL)
        ListViewActions.Items.Clear()
        If Reader Is Nothing Then Exit Sub
        If Reader.HasRows Then
            Do Until Reader.Read = False
                LI = ListViewActions.Items.Add(FormatDateTime(Reader("RequestActionDate").ToString, DateFormat.ShortDate))
                LI.Tag = Reader("RequestActionID").ToString
                LI.SubItems.Add(Reader("Description").ToString)
                LI.SubItems.Add(Reader("EmpName").ToString)
                LI.ToolTipText = Reader("Description").ToString
            Loop
        End If
        Reader.Close() : Reader.Dispose()
        Show_Details(Val(FpSpreadRequests.ActiveSheet.Cells(RowIndex, 2).Tag))

    End Sub

    Public Sub Show_Details(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim lCell As String
        Dim I As Integer
        Dim SPHeight As Integer

        SQL = "SELECT ClaimEffectiveDT, CaseTypes.Description as CaseType, Patients.NoMoreAppointmentsInd, Patients.CaseTypeID,   Patients.DOA, Patients.ParentsRequiredInd, Patients.PatientID,  Patients.FName, Patients.MI, Patients.LName, Patients.DOB, Patients.Phone1, Patients.Phone2, Patients.CellPhone, Patients.Address1, Patients.Address2, Patients.City, Patients.State, Patients.Zip, InsuranceCompanies_1.CompanyName AS Insurance1, InsuranceCompanies.CompanyName AS Insurance2, "
        SQL = SQL & " Patients.ReferringDoctor, ReferringOffices.OfficeName AS ReferringCompany, ReferringOffices.Phone1 AS RefPhone1, ReferringOffices.Phone2 AS RefPhone2, ReferringOffices.Phone3 AS RefPhone3, "
        SQL = SQL & " TransportationCompanies.CompanyName AS Transportation, TransportationCompanies.Phone1 AS TransPhone1, TransportationCompanies.Phone2 AS TransPhone2, TransportationCompanies.Phone3 AS TransPhone3, Patients.Comments "
        SQL = SQL & " FROM Patients LEFT OUTER JOIN TransportationCompanies ON Patients.TransportationCompanyID = TransportationCompanies.CompanyID LEFT OUTER JOIN ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID LEFT OUTER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID1 = InsuranceCompanies.CompanyID LEFT OUTER JOIN InsuranceCompanies AS InsuranceCompanies_1 ON Patients.InsuranceCompanyID = InsuranceCompanies_1.CompanyID Inner Join CaseTypes on Patients.CaseTypeID = CaseTypes.CaseTypeID "
        SQL = SQL & " WHERE Patients.PatientID = " & ID
        Reader = gSQLGetDataReader(SQL.ToString())
        SPHeight = FpSpreadDetails.Height
        If Reader Is Nothing Then Exit Sub
        Panel3.SuspendLayout()
        FpSpreadDetails.ShowRow(FpSpreadDetails.GetActiveRowViewportIndex, 0, FarPoint.Win.Spread.VerticalPosition.Top)
        FpSpreadProcedures.ShowRow(FpSpreadDetails.GetActiveRowViewportIndex, 0, FarPoint.Win.Spread.VerticalPosition.Top)
        With FpSpreadDetails_Sheet1

            Do Until Reader.Read = False
                If Val(Reader("CaseTypeID").ToString) = 4 Then
                    .SetText(0, 1, Reader("PatientID").ToString & " / " & Reader("CaseType").ToString & " / Payment Required")
                    .Cells(0, 0).ForeColor = Color.Red
                    .Cells(0, 1).ForeColor = Color.Red
                Else
                    .SetText(0, 1, Reader("PatientID").ToString & " / " & Reader("CaseType").ToString)
                    .Cells(0, 0).ForeColor = Color.Black
                    .Cells(0, 1).ForeColor = Color.Black
                End If
                .Cells(0, 1).Tag = Val(Reader("CaseTypeID").ToString)
                .Cells(1, 0).ForeColor = Color.Black
                .Cells(1, 1).ForeColor = Color.Black

                If IsDate(Reader("DOA").ToString) Then
                    .SetText(1, 1, CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy"))
                    If Val(Reader("CaseTypeID").ToString) < 3 Then
                        If DateDiff(DateInterval.Day, CDate(Reader("DOA").ToString), Now) >= Val(gDOAAge) Then
                            .SetText(1, 1, CDate(Reader("DOA").ToString).ToString("MM/dd/yyyy") & "  " & "Insurance Verification Required!")
                            .Cells(1, 0).ForeColor = Color.Red
                            .Cells(1, 1).ForeColor = Color.Red
                        End If
                    End If
                End If

                If Reader("Phone1").ToString <> "" And Reader("Phone1").ToString <> "" Then .SetText(2, 1, Reader("Phone1").ToString)
                If Reader("CellPhone").ToString <> "" And Reader("CellPhone").ToString <> "" Then .SetText(3, 1, Reader("CellPhone").ToString)
                If Reader("Phone2").ToString <> "" And Reader("Phone2").ToString <> "" Then .SetText(4, 1, Reader("Phone2").ToString)
                .SetText(5, 1, Reader("Address1").ToString & " " & Reader("Address2").ToString & IIf(Reader("City").ToString <> "", ", " & Reader("City").ToString, "").ToString & IIf(Reader("State").ToString <> "", ", " & Reader("State").ToString, "").ToString & IIf(Replace(Reader("Zip").ToString, "_", "") <> "", ", " & Reader("Zip").ToString, "").ToString)
                lCell = Reader("ReferringCompany").ToString
                lCell = lCell & IIf(Reader("RefPhone1").ToString <> "" And Reader("RefPhone1").ToString <> "", vbCrLf & Reader("RefPhone1").ToString, "").ToString
                lCell = lCell & IIf(Reader("RefPhone2").ToString <> "" And Reader("RefPhone2").ToString <> "", vbCrLf & Reader("RefPhone2").ToString, "").ToString
                lCell = lCell & IIf(Reader("RefPhone3").ToString <> "" And Reader("RefPhone3").ToString <> "", vbCrLf & Reader("RefPhone3").ToString, "").ToString
                lCell = lCell & IIf(Reader("ReferringDoctor").ToString <> "", vbCrLf & Reader("ReferringDoctor").ToString, "").ToString
                .SetText(6, 1, lCell)
                lCell = Reader("Transportation").ToString
                lCell = lCell & IIf(Reader("TransPhone1").ToString <> "" And Reader("TransPhone1").ToString <> "", vbCrLf & Reader("TransPhone1").ToString, "").ToString
                lCell = lCell & IIf(Reader("TransPhone2").ToString <> "" And Reader("TransPhone2").ToString <> "", vbCrLf & Reader("TransPhone2").ToString, "").ToString
                lCell = lCell & IIf(Reader("TransPhone3").ToString <> "" And Reader("TransPhone3").ToString <> "", vbCrLf & Reader("TransPhone3").ToString, "").ToString
                .SetText(7, 1, lCell)
                .SetText(8, 1, Reader("Comments").ToString)
                .Cells(8, 1).ForeColor = Color.Chocolate
                If Val(Reader("ParentsRequiredInd").ToString) = 1 Then
                    .RowCount = .RowCount + 1
                    .SetText(.RowCount - 1, 0, "Attention")
                    .SetText(.RowCount - 1, 1, "Underage Patient - " & gYearsFromDate(Reader("DOB").ToString) & " years old. Parents presence required")
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
                SPHeight = 0
                For I = 0 To .RowCount - 1
                    .SetRowHeight(I, CInt(.Rows(I).GetPreferredHeight))
                    SPHeight = SPHeight + CInt(.Rows(I).GetPreferredHeight)
                Next

            Loop
        End With
        SPHeight = SPHeight
        If FpSpreadDetails.Height <> SPHeight Then FpSpreadDetails.Height = SPHeight
        SQL = "SELECT     PatientProcedures.PatientProcedureID, PatientProcedures.ProcID, PatientProcedures.DiagID, PatientProcedures.ProcedureStatusID, Procedures.ProcName, Schedule.ScheduleDateTime "
        SQL = SQL & " FROM  PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Patients on PatientProcedures.PatientID = Patients.PatientID"
        SQL = SQL & " WHERE PatientProcedures.PatientID = " & ID
        SQL = SQL & " Order by PatientProcedures.ProcID "
        Reader = gSQLGetDataReader(SQL.ToString())
        FpSpreadProcedures.ActiveSheet.RowCount = 0
        If Reader Is Nothing Then Panel3.ResumeLayout(True) : Exit Sub
        With FpSpreadProcedures.ActiveSheet
            .RowCount = 0
            Do Until Reader.Read = False
                .RowCount = .RowCount + 1
                .SetText(.RowCount - 1, 0, Val(Reader("ProcedureStatusID").ToString).ToString)
                .SetText(.RowCount - 1, 1, Reader("ProcName").ToString)
                If Reader("ScheduleDateTime").ToString <> "" Then
                    If Val(Reader("ProcedureStatusID").ToString) = 1 And DateDiff(DateInterval.Hour, CDate(Reader("ScheduleDateTime")), Now) > gNoShowHours Then
                        .SetText(.RowCount - 1, 2, "NS " & CDate(Reader("ScheduleDateTime")).ToString("MM/dd/yy hh:mm tt"))
                        .Cells(.RowCount - 1, 1).ForeColor = Color.DarkRed
                        .Cells(.RowCount - 1, 2).ForeColor = Color.DarkRed
                        .Cells(.RowCount - 1, 1).Font = New Font(FpSpreadProcedures.Font, FontStyle.Bold)
                        .Cells(.RowCount - 1, 2).Font = New Font(FpSpreadProcedures.Font, FontStyle.Bold)
                    Else
                        .SetText(.RowCount - 1, 2, CDate(Reader("ScheduleDateTime")).ToString("MM/dd/yy hh:mm tt"))
                    End If
                End If
                .SetRowHeight(.RowCount - 1, CInt(.Rows(.RowCount - 1).GetPreferredHeight + 2))
            Loop
        End With
        Panel3.ResumeLayout(True)
    End Sub

    Public Sub Clear_Details()
        Dim I As Integer
        Dim SPHeight As Integer
        FpSpreadDetails_Sheet1.RowCount = 9
        For I = 0 To FpSpreadDetails_Sheet1.RowCount - 1
            FpSpreadDetails_Sheet1.SetText(I, 1, "")
            FpSpreadDetails_Sheet1.SetRowHeight(I, CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight))
            SPHeight = SPHeight + CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight)
        Next
        If FpSpreadDetails.Height <> SPHeight Then FpSpreadDetails.Height = SPHeight
        If FpSpreadProcedures.ActiveSheet.RowCount <> 0 Then FpSpreadProcedures.ActiveSheet.RowCount = 0
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim LI As ListViewItem
        Application.DoEvents()
        If FpSpreadRequests.ActiveSheet.ActiveColumnIndex < 0 Or FpSpreadRequests.ActiveSheet.ActiveRowIndex < 0 Then
            MsgBox("Unable to show patient's information. No Request selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim PatientID As Long
        PatientID = Val(FpSpreadRequests.ActiveSheet.Cells(FpSpreadRequests.ActiveSheet.ActiveRowIndex, 2).Tag)
        Using NewFrm As New frmPatient

            NewFrm.Width = 1225
            NewFrm.WindowState = FormWindowState.Normal
            NewFrm.StartPosition = FormStartPosition.CenterParent
            NewFrm.InitialTab = 0
            'NewFrm.InitialPatientName = LI.SubItems(1).Text
            NewFrm.InitialPatientName = PatientID
            NewFrm.InitialEdit = False
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.ShowDialog(Me)
        End Using
        'Dim frm As Form = FormsCollection.FindForm("frmPatient")
        'If Not frm Is Nothing Then
        '    MsgBox("The Patient's information window is already opened." & vbCrLf & vbCrLf & "Please close the previous patient information window before opening a new one.", MsgBoxStyle.Exclamation)
        '    frm.WindowState = FormWindowState.Normal
        '    frm.BringToFront()
        '    Exit Sub
        'Else

        '    frmPatient.Width = 1225
        '    frmPatient.WindowState = FormWindowState.Normal
        '    frmPatient.StartPosition = FormStartPosition.CenterParent
        '    frmPatient.InitialTab = 0
        '    'frmPatient.InitialPatientName = LI.SubItems(1).Text
        '    frmPatient.InitialPatientName = PatientID
        '    frmPatient.InitialEdit = False
        '    frmPatient.ShowDialog(Me)
        'End If
    End Sub

    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        If ChangesMade Then
            If MsgBox("You have made some changes to the displayed requests. Discard changes?" & vbCrLf & vbCrLf & "To apply changes click the Update button.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Button1.Focus()
                Exit Sub
            End If
        End If
        Load_Requests()
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        cboStatus.SelectedIndex = 0
        cboEmployee.SelectedIndex = 0
        cboRequest.SelectedIndex = 0
        cboRequestFrom.SelectedIndex = 0
        txtBillNo.Text = ""
        txtPatient.Text = ""
    End Sub

    Private Sub ButtonPrintRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrintRequests.Click

        If FpSpreadRequests.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to process your request. Nothing to Print", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        Printinfo.SmartPrintPagesWide = 1
        Printinfo.Preview = True
        Printinfo.Header = "REQUESTS MANAGEMENTLIST AS OF " & Now & vbCrLf & vbCrLf
        Printinfo.BestFitRows = False
        Printinfo.BestFitCols = True
        Printinfo.ShowShadows = False
        Printinfo.JobName = "eMedical Office Requests Management"
        Printinfo.PrintType = FarPoint.Win.Spread.PrintType.All
        Printinfo.ShowColor = True
        Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.ShowBorder = False
        Printinfo.ShowGrid = True
        Printinfo.ShowPrintDialog = True
        Printinfo.Preview = False
        Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
        Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.All))
        Printinfo.SmartPrintRules.Add(New FarPoint.Win.Spread.BestFitColumnRule(FarPoint.Win.Spread.ResetOption.All))
        Printinfo.UseSmartPrint = True
        Printinfo.UseMax = True
        Printinfo.Printer = gPrinterOtherDocuments
        FpSpreadRequests.ActiveSheet.PrintInfo = Printinfo
        FpSpreadRequests.PrintSheet(FpSpreadRequests.ActiveSheet)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If FpSpreadRequests.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to process your request. Nothing to export to Excell", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim strFileName As String
        SaveFD.Title = "Export Billing To Excel."
        SaveFD.Filter = "MS Excel File (*.xls)|*.xls"
        Dim DidWork As Integer = SaveFD.ShowDialog()
        If DidWork = DialogResult.OK Then
            strFileName = SaveFD.FileName
        Else
            Exit Sub
        End If
        FpSpreadRequests.ActiveSheet.Protect = False
        Try
            FpSpreadRequests.SaveExcel(strFileName)
        Catch ex As Exception
            MsgBox("Unable to save file. the file may be in use by another application or drive is full or write protected.", MsgBoxStyle.Critical)
        End Try
        FpSpreadRequests.ActiveSheet.Protect = False
        SaveFD.Reset()
        System.Diagnostics.Process.Start(strFileName)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Load_Data()
    End Sub

    Private Sub FpSpreadRequests_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadRequests.CellClick

    End Sub

End Class