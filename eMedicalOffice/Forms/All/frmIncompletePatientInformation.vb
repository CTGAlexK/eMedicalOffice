Imports System.Reflection
Imports log4net

Public Class frmIncompletePatientInformation
    Private log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private Sub frmPatientProcedureInformation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gSpread_Settings(Me, FpSpreadResults, ReadWrite.sWrite)
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub

    Private Sub frmIncompletePatientInformation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            ButtonFind_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmPatientProcedureInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gWindow_Settings(Me, ReadWrite.sRead)
        gSetup_GotFocus(Me)
        gSpread_Settings(Me, FpSpreadResults, ReadWrite.sRead)
        DateTimePickerFrom.Value = DateAdd(DateInterval.Day, -30, Now)
        DateTimePickerTo.Value = Now
        'Setup_SearchComboBoxes()
        FpSpreadResults.ActiveSheet.RowCount = 0

    End Sub
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader

        cboInsuranceCompanyID.Items.Add(New ValueDescription(-1, "All"))
        Reader = gSQLGetDataReader("SELECT     InsuranceCompanies.CompanyID, InsuranceCompanies.CaseTypeID, InsuranceCompanies.CompanyName , InsuranceCompanyAcceptance.Description AS Acceptance FROM InsuranceCompanies INNER JOIN InsuranceCompanyAcceptance ON InsuranceCompanies.AcceptanceID = InsuranceCompanyAcceptance.AcceptanceID WHERE (InsuranceCompanies.CaseTypeID = 1) AND (InsuranceCompanies.AcceptanceID > 0) ORDER BY InsuranceCompanies.CompanyName")
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
        Reader.Close() : Reader.Dispose()
        ButtonClear_Click(Nothing, Nothing)
    End Sub
    Private Sub Setup_SearchComboBoxes()
        AddHandler cboInsuranceCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboInsuranceCompanyID.Leave, AddressOf sSearchComboBox_Leave
        AddHandler cboReferringCompanyID.KeyUp, AddressOf sSearchComboBox_KeyUp
        AddHandler cboReferringCompanyID.Leave, AddressOf sSearchComboBox_Leave
    End Sub
    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        txtSearch.Text = ""
        cboInsuranceCompanyID.SelectedIndex = 0
        cboReferringCompanyID.SelectedIndex = 0
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
    Private Sub Find_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim I As Integer
        Dim SearchBox As String
        SearchBox = txtSearch.Text.Trim.ToSafeSQLString()
        Clear_Details()
        FpSpreadResults.ActiveSheet.RowCount = 0
        SQL = "SELECT DISTINCT Patients.DOA,   Patients.PatientID, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS PName, InsuranceCompanies.CompanyName, ReferringOffices.OfficeName, Patients.ClaimNumber, Patients.InitialReportReceived, Patients.PoliceReportReceived "
        SQL &= "FROM  Patients LEFT OUTER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID = InsuranceCompanies.CompanyID INNER JOIN ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID INNER JOIN PatientProcedures ON Patients.PatientID = PatientProcedures.PatientID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID "
        SQL &= " WHERE Patients.CaseTypeID = 1 and PatientProcedures.ProcedureStatusID = 2 and Patients.CaseStatusID = 1 and ((Patients.ClaimNumber is null or Patients.ClaimNumber='') or Patients.InitialReportReceived=0 or PoliceReportReceived=0)"

        If cboInsuranceCompanyID.SelectedIndex > 0 Then
            SQL &= " AND Patients.InsuranceCompanyID=" & CType(cboInsuranceCompanyID.SelectedItem, ValueDescription).Value
        End If

        SQL &= " and DATEDIFF(d, '" & DateTimePickerFrom.Value.Date & "', Schedule.ScheduleDateTime ) >= 0 "
        SQL &= " and DATEDIFF(d, Schedule.ScheduleDateTime, '" & DateTimePickerTo.Value.Date & "') >= 0 "

        If cboReferringCompanyID.SelectedIndex > 0 Then
            SQL &= " AND Patients.ReferringCompanyID=" & CType(cboReferringCompanyID.SelectedItem, ValueDescription).Value
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
        With FpSpreadResults.ActiveSheet
            Do Until Reader.Read = False
                I += 1
                .RowCount = I
                .SetText(I - 1, 0, Reader("PatientID").ToString)
                .SetText(I - 1, 1, Reader("PName").ToString)
                If IsDate(Reader("DOA").ToString) Then .SetText(I - 1, 2, FormatDateTime(Reader("DOA").ToString, 2))
                .SetText(I - 1, 3, Reader("CompanyName").ToString)
                .SetText(I - 1, 4, Reader("OfficeName").ToString)
                .SetText(I - 1, 5, Reader("ClaimNumber").ToString)
                If Reader("ClaimNumber").ToString <> "" Then
                    .Cells(I - 1, 5).Locked = True
                    .Cells(I - 1, 5).BackColor = Color.Gainsboro
                Else
                    .Cells(I - 1, 5).Locked = False
                    .Cells(I - 1, 5).BackColor = Color.LightPink
                End If
                .SetText(I - 1, 6, IIf(Val(Reader("InitialReportReceived").ToString), True, False))
                If Val(Reader("InitialReportReceived").ToString) Then
                    .Cells(I - 1, 6).Locked = True
                    .Cells(I - 1, 6).BackColor = Color.Gainsboro
                Else
                    .Cells(I - 1, 6).Locked = False
                    .Cells(I - 1, 6).BackColor = Color.LightPink
                End If
                .SetText(I - 1, 7, IIf(Val(Reader("PoliceReportReceived").ToString), True, False))
                If Val(Reader("PoliceReportReceived").ToString) Then
                    .Cells(I - 1, 7).Locked = True
                    .Cells(I - 1, 7).BackColor = Color.Gainsboro
                Else
                    .Cells(I - 1, 7).Locked = False
                    .Cells(I - 1, 7).BackColor = Color.LightPink
                End If

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
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
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
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub FpSpreadResults_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadResults.CellClick

    End Sub

    Private Sub FpSpreadResults_EditModeOff(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpreadResults.EditModeOff
        Dim RetPatient As String
        Dim CL As FarPoint.Win.Spread.Cell = FpSpreadResults.ActiveSheet.ActiveCell
        If CL Is Nothing Then Exit Sub
        Dim Row As Long = CL.Row.Index
        Dim Column As Long = CL.Column.Index
        RetPatient = FpSpreadResults.ActiveSheet.Cells(Row, 1).Text
        Dim ClaimNumber As String = FpSpreadResults.ActiveSheet.Cells(Row, 5).Text
        Dim Initialreport As String = FpSpreadResults.ActiveSheet.Cells(Row, 6).Text
        Dim Policereport As String = FpSpreadResults.ActiveSheet.Cells(Row, 7).Text
        Dim PatientID As Long = Val(FpSpreadResults.ActiveSheet.Cells(Row, 0).Text)

        Select Case CL.Column.Index
            Case 5
                If ClaimNumber = "" Then Exit Sub
                If MsgBox("Please confirm the patient " & RetPatient & " Claim Number is " & ClaimNumber & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    FpSpreadResults.ActiveSheet.SetActiveCell(Row, Column)
                    FpSpreadResults.ActiveSheet.ActiveCell.Text = ""
                    Exit Sub
                End If
                gSQLUpdateData("Update Patients Set ClaimNumber='" & ClaimNumber.ToSafeSQLString() & "' Where PatientID = " & PatientID)
                gUpdate_Profile_Log(PatientID, PatientLogTypes.tUpdated, "Claim Number " & ClaimNumber.ToSafeSQLString() & " received ")
            Case 6
                If Initialreport <> "True" Then Exit Sub
                If MsgBox("Please confirm you have received the Initial Report for the patient " & RetPatient & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    FpSpreadResults.ActiveSheet.SetActiveCell(Row, Column)
                    FpSpreadResults.ActiveSheet.ActiveCell.Text = "False"
                    Exit Sub
                End If
                gSQLUpdateData("Update Patients Set InitialReportReceived=1 Where PatientID = " & PatientID)
                gUpdate_Profile_Log(PatientID, PatientLogTypes.tUpdated, "Initial Report received ")
            Case 7
                If Policereport <> "True" Then Exit Sub
                If MsgBox("Please confirm you have received the Police Report for the patient " & RetPatient & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    FpSpreadResults.ActiveSheet.SetActiveCell(Row, Column)
                    FpSpreadResults.ActiveSheet.ActiveCell.Text = "False"
                    Exit Sub
                End If
                gSQLUpdateData("Update Patients Set PoliceReportReceived=1 Where PatientID = " & PatientID)
                gUpdate_Profile_Log(PatientID, PatientLogTypes.tUpdated, "Police Report received ")
            Case Else
                Exit Sub
        End Select
        CL.Locked = True
        CL.BackColor = Color.Gainsboro
    End Sub
End Class