Public Class frmPatientProcedureInformation
    Public NoDefaultDates As Boolean
    Private Sub frmPatientProcedureInformation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gSpread_Settings(Me, FpSpreadResults, ReadWrite.sWrite)
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub

    Private Sub frmPatientProcedureInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gSetup_GotFocus(Me)
        gSpread_Settings(Me, FpSpreadResults, ReadWrite.sRead)
        If NoDefaultDates = False Then
            gWindow_Settings(Me, ReadWrite.sRead)
            DateTimePickerFrom.Value = "1/1/2010"
            DateTimePickerTo.Value = Now
            'DateTimePickerFrom.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerFrom", DateAdd("M", -1, Now))
            'DateTimePickerTo.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerTo", Now)

            FpSpreadResults.ActiveSheet.RowCount = 0
        End If
        gSQLUpdateData("update PatientProcedures set ProcedureInformationID = 0 WHERE (ProcedureInformationID IS NULL)")
        'Setup_SearchComboBoxes()
    End Sub
    Public Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader

        cboInsuranceCompanyID.Items.Add(New ValueDescription(-1, "All Problem Procedures"))
        cboInsuranceCompanyID.Items.Add(New ValueDescription(-2, "All Warning"))
        cboInsuranceCompanyID.Items.Add(New ValueDescription(-3, "All Rejected"))
        cboInsuranceCompanyID.Items.Add(New ValueDescription(-4, "All Dropped Cases"))
        cboInsuranceCompanyID.Items.Add(New ValueDescription(-5, "All Denied"))
        cboInsuranceCompanyID.DropDownHeight = 106

        Reader = gSQLGetDataReader("SELECT     InsuranceCompanies.CompanyID, InsuranceCompanies.CaseTypeID, InsuranceCompanies.CompanyName , InsuranceCompanyAcceptance.Description AS Acceptance FROM InsuranceCompanies LEFT OUTER JOIN  InsuranceCompanyAcceptance ON InsuranceCompanies.AcceptanceID = InsuranceCompanyAcceptance.AcceptanceID WHERE (InsuranceCompanies.CaseTypeID = 1) AND (InsuranceCompanies.AcceptanceID > 0) ORDER BY InsuranceCompanies.CompanyName")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboInsuranceCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString & "  -  " & UCase(Reader("Acceptance")).ToString))
        Loop

        cboReferringCompanyID.Items.Add(New ValueDescription(-1, "All"))
        Reader = gSQLGetDataReader("Select OfficeID, OfficeName from ReferringOffices Where ActiveInd=1 order by OfficeName ")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboReferringCompanyID.Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)), Reader("OfficeName").ToString))
        Loop
        Reader.Close()

        cboInformationStatus.Items.Add(New ValueDescription(-1, "All"))
        Reader = gSQLGetDataReader("Select  ProcedureInformationID, Description from PatientProcedureInformation")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboInformationStatus.Items.Add(New ValueDescription(CLng(Val(Reader("ProcedureInformationID").ToString)), Reader("Description").ToString))
        Loop
        Reader.Close()


        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim Arlst As New ArrayList
        Dim ArlstData As New ArrayList

        Reader = gSQLGetDataReader("SELECT     ProcedureInformationID, Description FROM         PatientProcedureInformation")

        Do Until Reader.Read = False
            Arlst.Add(Reader("Description").ToString)
            ArlstData.Add(Reader("ProcedureInformationID").ToString)
        Loop

        cmbocell.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
        cmbocell.Items = Arlst.ToArray(GetType(String))
        cmbocell.ItemData = ArlstData.ToArray(GetType(String))
        cmbocell.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter
        cmbocell.Editable = False
        cmbocell.MaxDrop = 5
        FpSpreadResults.ActiveSheet.Columns(11).CellType = cmbocell
        ButtonClear_Click(Nothing, Nothing)
    End Sub
    Private Sub Setup_SearchComboBoxes()
        AddHandler cboInsuranceCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboInsuranceCompanyID.Leave, AddressOf sSearchComboBox_Leave
        AddHandler cboInformationStatus.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboInformationStatus.Leave, AddressOf sSearchComboBox_Leave
        AddHandler cboReferringCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboReferringCompanyID.Leave, AddressOf sSearchComboBox_Leave
    End Sub
    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        txtSearch.Text = ""
        cboInsuranceCompanyID.SelectedIndex = 0
        cboReferringCompanyID.SelectedIndex = 0
        cboInformationStatus.SelectedIndex = 0
        txtSearch.Focus()
        Clear_Details()
        FpSpreadResults.ActiveSheet.RowCount = 0
    End Sub

    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        Find_Data()
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
    Public Sub Find_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim I As Integer
        Dim SearchBox As String
        SearchBox = txtSearch.Text.Trim
        Clear_Details()
        FpSpreadResults.ActiveSheet.RowCount = 0
        SQL = "SELECT PatientProcedures.DenialBackInd, PatientProcedures.DeniedInd, PatientProcedures.DenialDate, CaseTypes.Description as CaseType, Patients.CaseTypeID, Patients.CaseStatusID, CaseStatuses.Description as CaseStatus, ProcedureInformationDT, PatientProcedures.PatientProcedureID,  InsuranceCompanies.AcceptanceID,  Patients.PatientID, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS PName, Procedures.ProcName, PatientProcedureStatuses.Description AS Status, "
        SQL &= "                      Schedule.ScheduleDateTime, PatientProcedureReadings.ReadingDate, InsuranceCompanies.CompanyName AS InsuranceCompanyName, "
        SQL &= "                      InsuranceCompanyAcceptance.Description, ReferringOffices.OfficeName, PatientProcedureInformation.Description AS Information, PatientProcedures.ProcedureInformationID "

        SQL &= " FROM         PatientProcedureReadings RIGHT OUTER JOIN "
        SQL &= "                       Patients LEFT OUTER JOIN "
        SQL &= "                       PatientProcedures ON Patients.PatientID = PatientProcedures.PatientID LEFT OUTER JOIN "
        SQL &= "                       PatientProcedureStatuses ON PatientProcedures.ProcedureStatusID = PatientProcedureStatuses.ProcedureStatusID RIGHT OUTER JOIN "
        SQL &= "                       Procedures ON PatientProcedures.ProcID = Procedures.ProcID LEFT OUTER JOIN "
        SQL &= "                       InsuranceCompanies LEFT OUTER JOIN "
        SQL &= "                       InsuranceCompanyAcceptance ON InsuranceCompanies.AcceptanceID = InsuranceCompanyAcceptance.AcceptanceID ON  "
        SQL &= "                       Patients.InsuranceCompanyID = InsuranceCompanies.CompanyID LEFT OUTER JOIN "
        SQL &= "                       ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID ON "
        SQL &= "                       PatientProcedureReadings.PatientProcedureID = PatientProcedures.PatientProcedureID LEFT OUTER JOIN "
        SQL &= "                       Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID LEFT OUTER JOIN "
        SQL &= "                       CaseStatuses ON Patients.CaseStatusID = CaseStatuses.CaseStatusID LEFT OUTER JOIN "
        SQL &= "                       CaseTypes ON Patients.CaseTypeID = CaseTypes.CaseTypeID LEFT OUTER JOIN "
        SQL &= "                       PatientProcedureInformation ON PatientProcedures.ProcedureInformationID = PatientProcedureInformation.ProcedureInformationID "


        ' Patients.CaseStatusID =3  ' Dropped
        'cboInsuranceCompanyID.Items.Add(New ValueDescription(-1, "All Warning & Rejected & Dropped"))
        'cboInsuranceCompanyID.Items.Add(New ValueDescription(-2, "All Warning"))
        'cboInsuranceCompanyID.Items.Add(New ValueDescription(-3, "All Rejected"))
        'cboInsuranceCompanyID.Items.Add(New ValueDescription(-4, "All Dropped Cases"))
        'cboInsuranceCompanyID.Items.Add(New ValueDescription(-4, "All Denied"))
        If cboInsuranceCompanyID.SelectedItem Is Nothing Then
            SQL &= " WHERE PatientProcedures.ProcedureStatusID=2 and   ((InsuranceCompanies.AcceptanceID=1 and ReferringOffices.IgnoreInsuranceWarnings=0) or InsuranceCompanies.AcceptanceID=2 or Patients.CaseStatusID =3 or Patients.CaseTypeID=2 or Patients.CaseTypeID=5  or (PatientProcedures.DeniedInd>0 and PatientProcedures.DenialBackInd>0)) "
        Else
            Select Case CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value
                Case -1
                    SQL &= " WHERE PatientProcedures.ProcedureStatusID=2 and   ((InsuranceCompanies.AcceptanceID=1 and ReferringOffices.IgnoreInsuranceWarnings=0) or InsuranceCompanies.AcceptanceID=2 or Patients.CaseStatusID =3 or Patients.CaseTypeID=2 or Patients.CaseTypeID=5  or (PatientProcedures.DeniedInd>0 and PatientProcedures.DenialBackInd>0)) "
                Case -2
                    SQL &= " WHERE PatientProcedures.ProcedureStatusID=2 and   (InsuranceCompanies.AcceptanceID=1 and ReferringOffices.IgnoreInsuranceWarnings=0)"
                Case -3
                    SQL &= " WHERE PatientProcedures.ProcedureStatusID=2 and   (InsuranceCompanies.AcceptanceID=2 ) "
                Case -4
                    SQL &= " WHERE PatientProcedures.ProcedureStatusID=2 and   (Patients.CaseStatusID =3 ) "
                Case -5
                    SQL &= " WHERE PatientProcedures.ProcedureStatusID=2 and   (PatientProcedures.DeniedInd>0 and PatientProcedures.DenialBackInd>0) "
                Case Else
                    SQL &= " WHERE PatientProcedures.ProcedureStatusID=2 and   (Patients.InsuranceCompanyID=" & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value & "  or Patients.CaseStatusID =2) "
            End Select
        End If
        SQL &= " and DATEDIFF(d, '" & DateTimePickerFrom.Value.Date & "', Schedule.ScheduleDateTime ) >= 0 "
        SQL &= " and DATEDIFF(d, Schedule.ScheduleDateTime, '" & DateTimePickerTo.Value.Date & "') >= 0 "

        If cboReferringCompanyID.SelectedIndex > 0 Then
            SQL &= " AND Patients.ReferringCompanyID=" & CType(cboReferringCompanyID.SelectedItem, ValueDescription).Value
        End If

        If cboInformationStatus.SelectedIndex > 0 Then
            SQL &= " AND PatientProcedures.ProcedureInformationID=" & CType(cboInformationStatus.SelectedItem, ValueDescription).Value
        End If
        If SearchBox <> "" Then
            If IsNumeric(SearchBox) Then
                SQL &= " AND Patients.PatientID = " & Val(SearchBox)
            Else
                SQL &= " AND (Patients.Lname like '" & SearchBox & "%'  or Patients.Fname like '" & SearchBox & "%' )"
            End If
        End If

        SQL &= " ORDER BY Patients.PatientID "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        FpSpreadResults.SuspendLayout()
        I = 0
        With FpSpreadResults.ActiveSheet
            .RowCount = 0
            Do Until Reader.Read = False

                .RowCount = I + 1
                .SetText(I, 0, Reader("PatientID").ToString)
                .Cells(I, 0).Tag = Reader("PatientProcedureID").ToString
                .SetText(I, 1, Reader("PName").ToString)
                .SetText(I, 2, Reader("CaseStatus").ToString)
                .SetText(I, 3, Reader("CaseType").ToString)
                .SetText(I, 4, Reader("ProcName").ToString)
                If IsDate(Reader("DenialDate").ToString) Then
                    .SetText(I, 5, FormatDateTime(Reader("DenialDate").ToString, 2))
                    If Val(Reader("DeniedBackInd").ToString) > 0 Then
                        .Cells(I, 5).ForeColor = Color.Red
                    End If
                End If

                If IsDate(Reader("ScheduleDateTime").ToString) Then .SetText(I, 6, FormatDateTime(Reader("ScheduleDateTime").ToString, 2))
                If IsDate(Reader("ReadingDate").ToString) Then .SetText(I, 7, FormatDateTime(Reader("ReadingDate").ToString, 2))
                .SetText(I, 8, Reader("InsuranceCompanyName").ToString)
                .SetText(I, 9, Reader("Description").ToString)
                .SetText(I, 10, Reader("OfficeName").ToString)
                '.SetText(I, 11, Reader("Information").ToString)
                .Cells(I, 11).Value = Val(Reader("ProcedureInformationID").ToString)
                '.Cells(I, 11).Value = 3
                If Val(Reader("ProcedureInformationID").ToString) > 0 Then
                    If Val(Reader("DeniedBackInd").ToString) > 0 Then
                        If IsDate(Reader("ProcedureInformationDT").ToString) Then .SetText(I, 12, FormatDateTime(Reader("ProcedureInformationDT").ToString, 2))
                    Else
                        If IsDate(Reader("ProcedureInformationDT").ToString) Then .SetText(I, 12, FormatDateTime(Reader("ProcedureInformationDT").ToString, 2) & " R")
                    End If
                End If
                Application.DoEvents()
                If Val(Reader("AcceptanceID").ToString) = 2 Or Val(Reader("CaseStatusID").ToString) = 3 Or Val(Reader("CaseTypeID").ToString) = 5 Or (Val(Reader("DeniedInd").ToString) > 0 And Val(Reader("DeniedBackInd").ToString) = 0) Then ' Case Status 3 - Dropped
                    .Rows(I).BackColor = Color.LightPink
                End If
                If Val(Reader("AcceptanceID").ToString) = 2 Or Val(Reader("CaseStatusID").ToString) = 3 Or Val(Reader("CaseTypeID").ToString) = 5 Or (Val(Reader("DeniedInd").ToString) > 0 And Val(Reader("DeniedBackInd").ToString) > 0) Then ' Case Status 3 - Dropped
                    .Rows(I).BackColor = Color.Red
                End If
                If Val(Reader("CaseStatusID").ToString) = 3 Then ' Case Status 3 - Dropped
                    .Cells(I, 2).ForeColor = Color.Red
                End If
                If Val(Reader("AcceptanceID").ToString) = 2 Then ' Rejected
                    .Cells(I, 9).ForeColor = Color.Red
                End If
                If Val(Reader("CaseTypeID").ToString) = 5 Then ' LIEN
                    .Cells(I, 3).ForeColor = Color.Red
                End If
                If Val(Reader("CaseTypeID").ToString) = 2 Then ' WC
                    .Cells(I, 3).ForeColor = Color.Red
                End If
                I += 1
            Loop
        End With
        FpSpreadResults.ResumeLayout()
        If FpSpreadResults.ActiveSheet.RowCount > 0 Then
            FpSpreadResults.ActiveSheet.ActiveRowIndex = 0
            FpSpreadResults.ActiveSheet.AddSelection(0, 0, 1, 1)
            FpSpreadResults.Focus()
            Show_Details(CLng(FpSpreadResults.ActiveSheet.Cells(0, 0).Text.ToString))
        Else
            Clear_Details()
        End If
        FpSpreadResults.Visible = True
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to Print. No Data has been loaded. Please specify the search criteria an click the Load button.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Printinfo.SmartPrintPagesWide = 1
        Printinfo.BestFitRows = True
        Printinfo.Preview = True
        Printinfo.ShowShadows = False
        Printinfo.JobName = "Patient Procedure Information"
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
    Private SaveInfo As Long
    Private SaveInfoText As String
    Private Sub FpSpreadResults_ComboCloseUp(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpreadResults.ComboCloseUp
        Dim ProcID As Long
        Dim Ret As Long
        Dim RetText As String
        Dim RetPatient As String
        Dim RetProcedure As String
        Dim SaveColor As System.Drawing.Color
        Ret = Val(FpSpreadResults.ActiveSheet.Cells(e.Row, e.Column).Value)
        ProcID = Val(FpSpreadResults.ActiveSheet.Cells(e.Row, 0).Tag)
        RetText = FpSpreadResults.ActiveSheet.Cells(e.Row, e.Column).Text
        RetPatient = FpSpreadResults.ActiveSheet.Cells(e.Row, 1).Text
        RetProcedure = FpSpreadResults.ActiveSheet.Cells(e.Row, 4).Text
        SaveColor = FpSpreadResults.ActiveSheet.Cells(e.Row, e.Column).BackColor
        If Ret = SaveInfo Then Exit Sub
        FpSpreadResults.ActiveSheet.Cells(e.Row, e.Column).BackColor = Color.Orange
        If MsgBox("Please confirm the Patient information status change " & vbCrLf & vbCrLf & "From:  [" & SaveInfoText & "]  To  [" & RetText & "]" & vbCrLf & vbCrLf & "Patient Information: " & RetPatient & " - " & RetProcedure, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            FpSpreadResults.ActiveSheet.Cells(e.Row, e.Column).Value = SaveInfo
            FpSpreadResults.ActiveSheet.Cells(e.Row, e.Column).BackColor = SaveColor
            Exit Sub
        End If
        FpSpreadResults.ActiveSheet.Cells(e.Row, e.Column).BackColor = SaveColor
        If Val(Ret) = 0 Then
            gSQLUpdateData("Update PatientProcedures Set ProcedureInformationDT=Null, ProcedureInformationID = 0 Where PatientProcedureID = " & ProcID)
            FpSpreadResults.ActiveSheet.Cells(e.Row, e.Column + 1).Text = ""
        Else
            gSQLUpdateData("Update PatientProcedures Set ProcedureInformationDT='" & Now.Date & "', ProcedureInformationID = " & Val(Ret) & " Where PatientProcedureID = " & ProcID)
            FpSpreadResults.ActiveSheet.Cells(e.Row, e.Column + 1).Text = Now.Date
        End If
        '.Cells(I - 1, 0).Tag = Reader("PatientProcedureID").ToString
    End Sub

    Private Sub FpSpreadResults_ComboDropDown(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs) Handles FpSpreadResults.ComboDropDown
        SaveInfo = Val(FpSpreadResults.ActiveSheet.Cells(e.Row, e.Column).Value)
        SaveInfoText = FpSpreadResults.ActiveSheet.Cells(e.Row, e.Column).Text
    End Sub

    Private Sub FpSpread1_EnterCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.EnterCellEventArgs) Handles FpSpreadResults.EnterCell
        PanelSearch.SuspendLayout()
        If Not FpSpreadResults.ActiveSheet.ActiveCell Is Nothing Then
            If FpSpreadResults.ActiveSheet.ActiveCell Is Nothing Then Exit Sub
            If Val(FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 0).Text.ToString) <> 0 Then
                Show_Details(Val(FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 0).Text.ToString))
            Else
                Clear_Details()
            End If
        Else
            Clear_Details()
        End If
        PanelSearch.ResumeLayout()

    End Sub
    Public Sub Show_Details(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim lCell As String
        Dim I As Integer
        Dim SPHeight As Integer
        Clear_Details()
        SQL = "SELECT CaseTypes.Description as CaseType, Patients.NoMoreAppointmentsInd, Patients.CaseTypeID,  Patients.DOA, Patients.ParentsRequiredInd, Patients.PatientID,  Patients.FName, Patients.MI, Patients.LName, Patients.DOB, Patients.Phone1, Patients.Phone2, Patients.CellPhone, Patients.Address1, Patients.Address2, Patients.City, Patients.State, Patients.Zip, InsuranceCompanies_1.CompanyName AS Insurance1, InsuranceCompanies.CompanyName AS Insurance2, "
        SQL = SQL & " Patients.ReferringDoctor, ReferringOffices.OfficeName AS ReferringCompany, ReferringOffices.Phone1 AS RefPhone1, ReferringOffices.Phone2 AS RefPhone2, ReferringOffices.Phone3 AS RefPhone3, "
        SQL = SQL & " TransportationCompanies.CompanyName AS Transportation, TransportationCompanies.Phone1 AS TransPhone1, TransportationCompanies.Phone2 AS TransPhone2, TransportationCompanies.Phone3 AS TransPhone3, Patients.Comments "
        SQL = SQL & " FROM Patients LEFT OUTER JOIN TransportationCompanies ON Patients.TransportationCompanyID = TransportationCompanies.CompanyID LEFT OUTER JOIN ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID LEFT OUTER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID1 = InsuranceCompanies.CompanyID LEFT OUTER JOIN InsuranceCompanies AS InsuranceCompanies_1 ON Patients.InsuranceCompanyID = InsuranceCompanies_1.CompanyID LEFT OUTER JOIN  CaseTypes on Patients.CaseTypeID = CaseTypes.CaseTypeID"
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
        SQL = SQL & " FROM         PatientProcedures LEFT OUTER JOIN  Procedures ON PatientProcedures.ProcID = Procedures.ProcID LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID "
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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Load_Data()
        FpSpreadResults.Visible = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strFileName As String
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to process Procedure Information Data Export." & vbCrLf & "No data loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        SaveFD.Title = "Export To Excel."
        SaveFD.Filter = "MS Excel File (*.xls)|*.xls"
        Dim DidWork As Integer = SaveFD.ShowDialog()
        If DidWork = DialogResult.OK Then
            strFileName = SaveFD.FileName
            FpSpreadResults.SuspendLayout()
            FpSpreadResults.ActiveSheet.Rows.Add(0, 1)
            Dim I As Integer
            For I = 0 To FpSpreadResults.ActiveSheet.Columns.Count - 1
                FpSpreadResults.ActiveSheet.SetText(0, I, FpSpreadResults.ActiveSheet.ColumnHeader.Columns(I).Label)
            Next
            FpSpreadResults.SaveExcel(strFileName)
            FpSpreadResults.ActiveSheet.Rows.Remove(0, 1)
            FpSpreadResults.ResumeLayout()
            SaveFD.Reset()
            System.Diagnostics.Process.Start(strFileName)
        End If
    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to Email. No Data has been loaded. Please specify the search criteria an click the Load button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Procedure Information Report " & DateTimePickerFrom.Value.Date & " - " & DateTimePickerTo.Value.Date & " / Attached: Data Excel File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName("Procedure Information " & DateTimePickerFrom.Value.Date & " - " & DateTimePickerTo.Value.Date) & ".xls"
Recheck:
        If System.IO.File.Exists(Fname) Then
            Try
                System.IO.File.Delete(Fname)
            Catch ex As Exception
                Fname = System.IO.Path.GetTempFileName
                Fname.Replace(".tmp", ".xls")
                GoTo Recheck
            End Try
        End If
        Try
            FpSpreadResults.SuspendLayout()
            FpSpreadResults.ActiveSheet.Rows.Add(0, 1)
            Dim I As Integer
            For I = 0 To FpSpreadResults.ActiveSheet.Columns.Count - 1
                FpSpreadResults.ActiveSheet.SetText(0, I, FpSpreadResults.ActiveSheet.ColumnHeader.Columns(I).Label)
            Next
            FpSpreadResults.SaveExcel(Fname)
            FpSpreadResults.ActiveSheet.Rows.Remove(0, 1)
            FpSpreadResults.ResumeLayout()
            Msg.SendMail(Fname.ToString, Subject, Subject)
        Catch ex As Exception
            gProcess_Log("Error Sending Email", ex.StackTrace, True)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to Email. No Data has been loaded. Please specify the search criteria an click the Load button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Procedure Information Report " & DateTimePickerFrom.Value.Date & " - " & DateTimePickerTo.Value.Date & " / Attached: Data Excel File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName("Procedure Information " & DateTimePickerFrom.Value.Date & " - " & DateTimePickerTo.Value.Date) & ".xls"
Recheck:
        If System.IO.File.Exists(Fname) Then
            Try
                System.IO.File.Delete(Fname)
            Catch ex As Exception
                Fname = System.IO.Path.GetTempFileName
                Fname.Replace(".tmp", ".xls")
                GoTo Recheck
            End Try
        End If
        Try
            FpSpreadResults.SuspendLayout()
            FpSpreadResults.ActiveSheet.Rows.Add(0, 1)
            Dim I As Integer
            For I = 0 To FpSpreadResults.ActiveSheet.Columns.Count - 1
                FpSpreadResults.ActiveSheet.SetText(0, I, FpSpreadResults.ActiveSheet.ColumnHeader.Columns(I).Label)
            Next
            FpSpreadResults.SaveExcel(Fname)
            FpSpreadResults.ActiveSheet.Rows.Remove(0, 1)
            FpSpreadResults.ResumeLayout()
            gFax(Me, "", Subject, Fname.ToString, gOfficeFax)
        Catch ex As Exception
            gProcess_Log("Error Sending Fax", ex.StackTrace, True)
        End Try
    End Sub

    Private Sub FpSpreadResults_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadResults.CellClick

    End Sub

    Private Sub cboInformationStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInformationStatus.SelectedIndexChanged

    End Sub

    Private Sub cboInsuranceCompanyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInsuranceCompanyID.SelectedIndexChanged

    End Sub

    Private Sub cboReferringCompanyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReferringCompanyID.SelectedIndexChanged

    End Sub

    Private Sub FpSpreadResults_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FpSpreadResults.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If FpSpreadResults.ActiveSheet.ActiveCell.Column.Index < 0 Or FpSpreadResults.ActiveSheet.ActiveCell.Row.Index < 0 Then
                ShowPatientsInformationToolStripMenuItem.Visible = False
            Else
                ShowPatientsInformationToolStripMenuItem.Visible = True
            End If
        End If
    End Sub

    Private Sub ShowPatientsInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowPatientsInformationToolStripMenuItem.Click
        Dim frm As Form = FormsCollection.FindForm("frmPatient")
        If Not frm Is Nothing Then
            MsgBox("The Patient's information window is already opened." & vbCrLf & vbCrLf & "Please close the previous patient information window before opening a new one.", MsgBoxStyle.Exclamation)
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else
            frmPatient.InitialTab = 0
            frmPatient.InitialPatientName = FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 1).Text
            frmPatient.Width = 1000
            frmPatient.WindowState = FormWindowState.Normal
            frmPatient.Location = New Point(Me.Left + ((Width - frmPatient.Size.Width) \ 2), Me.Top + ((Height - frmPatient.Size.Height) \ 2))
            frmPatient.Show(Me)
            frmPatient.BringToFront()
        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class