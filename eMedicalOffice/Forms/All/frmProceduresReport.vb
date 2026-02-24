Imports System.Reflection
Imports log4net

Public Class frmProceduresReport
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private Sub frmMRIExport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim I As Integer
        gWindow_Settings(Me, ReadWrite.sWrite)

        gSpread_Settings(Me, FpSpreadResults, ReadWrite.sWrite)
        SaveSetting(My.Application.Info.ProductName, "Settings", Me.Name & "LastTreatingProvider", ComboBoxTreatingProviderID.SelectedIndex)

    End Sub
    Dim Loading As Boolean
    Private Sub frmMRIExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim I As Integer
        Dim C As Integer
        Load_Data()

        ' gWindow_Settings(Me, ReadWrite.sRead)
        gSpread_Settings(Me, FpSpreadResults, ReadWrite.sRead)
        gSetSpreadCustomSortIndicator(FpSpreadResults)

        For C = 0 To FpSpreadResults.ActiveSheet.ColumnCount - 1
            FpSpreadResults.ActiveSheet.Columns(C).ShowSortIndicator = True
            FpSpreadResults.ActiveSheet.Columns(C).AllowAutoSort = True

        Next
        FpSpreadResults.ActiveSheet.Columns(2).AllowAutoFilter = True
        FpSpreadResults.ActiveSheet.Columns(3).AllowAutoFilter = True
        FpSpreadResults.ActiveSheet.Columns(4).AllowAutoFilter = True
        FpSpreadResults.ActiveSheet.Columns(5).AllowAutoFilter = True
        FpSpreadResults.ActiveSheet.Columns(6).AllowAutoFilter = True
        FpSpreadResults.ActiveSheet.Columns(7).AllowAutoFilter = True
        FpSpreadResults.ActiveSheet.Columns(8).AllowAutoFilter = True
        FpSpreadResults.ActiveSheet.Columns(10).AllowAutoFilter = True


        FpSpreadResults.ActiveSheet.RowCount = 0
        Loading = True
        Loading = False
    End Sub
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        ComboBoxTreatingProviderID.Items.Clear()
        ComboBoxTreatingProviderID.Items.Add("All")
        Reader = gSQLGetDataReader("SELECT   Employees.EmpID,   Employees.Fname, Employees.Lname, Employees.Alias, Employees.BillingPrv, Employees.TreatmentPrv FROM Employees INNER JOIN EmployeeOffice ON Employees.EmpID = EmployeeOffice.EmpID WHERE  TreatmentPrv=1 and Employees.ActiveInd = 1 and   (Employees.PositionID = 5) AND (EmployeeOffice.OfficeID = " & gOfficeID & ")")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxTreatingProviderID.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("FName").ToString & " " & Reader("LName").ToString & " " & Reader("Alias").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        ComboBoxTreatmentType.Items.Clear()
        ComboBoxTreatmentType.Items.Add("All")
        Reader = gSQLGetDataReader("Select OfficeDiagnostics.DiagID, Diagnostics.DiagName From OfficeDiagnostics INNER Join Diagnostics On OfficeDiagnostics.DiagID = Diagnostics.DiagID Where OfficeDiagnostics.OfficeID = " & gOfficeID)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxTreatmentType.Items.Add(New ValueDescription(CLng(Val(Reader("DiagID").ToString)), Reader("DiagName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        ComboBoxCaseType.Items.Clear()
        ComboBoxCaseType.Items.Add("All")
        Reader = gSQLGetDataReader("Select CaseTypeID, Description FROM CaseTypes ORDER BY ShowOrder")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxCaseType.Items.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)), Reader("Description").ToString))
        Loop
        Reader.Close() : Reader.Dispose()

        ComboBoxProcedureStatus.Items.Clear()
        ComboBoxProcedureStatus.Items.Add("All")
        Reader = gSQLGetDataReader("SELECT        ProcedureStatusID, Description FROM  PatientProcedureStatuses")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxProcedureStatus.Items.Add(New ValueDescription(CLng(Val(Reader("ProcedureStatusID").ToString)), Reader("Description").ToString))
        Loop
        Reader.Close() : Reader.Dispose()


        ComboBoxCaseStatus.Items.Clear()
        ComboBoxCaseStatus.Items.Add("All")
        Reader = gSQLGetDataReader("SELECT CaseStatusID, Description, ShowOrder FROM CaseStatuses order by ShowOrder")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxCaseStatus.Items.Add(New ValueDescription(CLng(Val(Reader("CaseStatusID").ToString)), Reader("Description").ToString))
        Loop
        ComboBoxCaseStatus.Items.Add(New ValueDescription(-2, "No More App"))
        Reader.Close() : Reader.Dispose()


        cboBillStatus.Items.Clear()
        cboBillStatus.Items.Add("All")
        cboBillStatus.Items.Add("Billed")
        cboBillStatus.Items.Add("Not Billed")
        DateTimePickerFrom.Value = DateAdd(DateInterval.Month, -1, Now.Date)
        DateTimePickerTo.Value = Now.Date
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        ComboBoxTreatingProviderID.SelectedIndex = 0
        ComboBoxCaseStatus.SelectedIndex = 0
        ComboBoxProcedureStatus.SelectedIndex = 0
        cboBillStatus.SelectedIndex = 0
        ComboBoxCaseType.SelectedIndex = 0
        ComboBoxTreatmentType.SelectedIndex = 0
    End Sub
    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        Dim Rs As SqlClient.SqlDataReader
        Dim SQL As String
        Dim I As Integer = 0
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        LabelCount.Text = "Loading. Please Wait..."
        FpSpreadResults.ActiveSheet.RowCount = 0
        SQL &= " Select Patients.PatientID, RTRIM(Patients.FName) + ' ' + RTRIM(Patients.MI) + ' ' + RTRIM(Patients.LName) +' '+ rtrim(Suffix) AS PatName, CaseTypes.Description as CaseType, Diagnostics.DiagName, "
        SQL &= "                  Procedures.ProcName, RTrim(Employees.Fname) + ' ' + RTRIM(Employees.MI) + ' ' + RTRIM(Employees.Lname) AS TrName,  "
        SQL &= "                  PatientProcedureStatuses.Description As ProcStatus, BillProcedures.BillID, CaseStatuses.Description As CaseStatus, Schedule.ScheduleDateTime, "
        SQL &= "                  Patients.ReferringDoctor "
        SQL &= " From Patients INNER Join "
        SQL &= "       CaseTypes On Patients.CaseTypeID = CaseTypes.CaseTypeID INNER Join "
        SQL &= "       PatientProcedures On Patients.PatientID = PatientProcedures.PatientID INNER Join "
        SQL &= "       PatientProcedureStatuses On PatientProcedures.ProcedureStatusID = PatientProcedureStatuses.ProcedureStatusID INNER Join "
        SQL &= "       Diagnostics On PatientProcedures.DiagID = Diagnostics.DiagID INNER Join "
        SQL &= "       Employees On PatientProcedures.TreatingProviderID = Employees.EmpID INNER Join "
        SQL &= "       Procedures On PatientProcedures.ProcID = Procedures.ProcID INNER Join "
        SQL &= "       CaseStatuses On Patients.CaseStatusID = CaseStatuses.CaseStatusID LEFT OUTER Join "
        SQL &= "       Schedule On PatientProcedures.ScheduleID = Schedule.ScheduleID LEFT OUTER Join "
        SQL &= "       BillProcedures On PatientProcedures.PatientProcedureID = BillProcedures.PatientProcedureID "
        SQL &= " WHERE PatientProcedures.OfficeID=" & gOfficeID

        If ComboBoxTreatingProviderID.SelectedIndex > 0 Then
            SQL &= " And PatientProcedures.TreatingProviderID = " & CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Value
        End If
        If DateTimePickerFrom.Checked Then
            SQL &= " And DATEDIFF(d, '" & DateTimePickerFrom.Text & "', PatientProcedures.InsertedDT ) >= 0 "
        End If
        If DateTimePickerTo.Checked Then
            SQL &= " and DATEDIFF(d, PatientProcedures.InsertedDT, '" & DateTimePickerTo.Text & "') >= 0 "
        End If
        If DateTimePickerSvcFrom.Checked Then
            SQL &= " And DATEDIFF(d, '" & DateTimePickerSvcFrom.Text & "', Schedule.ScheduleDateTime ) >= 0 "
        End If
        If DateTimePickerSvcTo.Checked Then
            SQL &= " and DATEDIFF(d, Schedule.ScheduleDateTime, '" & DateTimePickerSvcTo.Text & "') >= 0 "
        End If


        If ComboBoxProcedureStatus.SelectedIndex > 0 Then
            SQL &= " And PatientProcedures.ProcedureStatusID = " & CType(ComboBoxProcedureStatus.SelectedItem, ValueDescription).Value
        End If
        If ComboBoxTreatmentType.SelectedIndex > 0 Then
            SQL &= " And PatientProcedures.DiagID = " & CType(ComboBoxTreatmentType.SelectedItem, ValueDescription).Value
        End If


        If ComboBoxCaseStatus.SelectedIndex > 0 Then
            If CType(ComboBoxTreatmentType.SelectedItem, ValueDescription).Value = -2 Then
                SQL &= " And Patients.NoMoreAppointmentsInd = 1 "
            Else
                SQL &= " And Patients.CaseStatusID = " & CType(ComboBoxCaseStatus.SelectedItem, ValueDescription).Value
            End If
        End If

        If ComboBoxCaseType.SelectedIndex > 0 Then
            SQL &= " And Patients.CaseTypeID = " & CType(ComboBoxCaseType.SelectedItem, ValueDescription).Value
        End If
        If cboBillStatus.SelectedIndex = 1 Then
            SQL &= " And BillProcedures.BillID is not null "
        ElseIf cboBillStatus.SelectedIndex = 2 Then
            SQL &= " And BillProcedures.BillID is null "

        End If



        SQL &= " ORDER BY Schedule.ScheduleDateTime "

        Rs = gSQLGetDataReader(SQL)
        If Rs Is Nothing Then
            LabelCount.Text = "Error."
            Cursor = Cursors.Default
            Application.DoEvents()

            Exit Sub
        End If
        FpSpreadResults.SuspendLayout()
        FpSpreadResults.ActiveSheet.AutoFilterReset(2)
        FpSpreadResults.ActiveSheet.AutoFilterReset(3)
        FpSpreadResults.ActiveSheet.AutoFilterReset(4)
        FpSpreadResults.ActiveSheet.AutoFilterReset(5)
        FpSpreadResults.ActiveSheet.AutoFilterReset(6)
        FpSpreadResults.ActiveSheet.AutoFilterReset(7)
        FpSpreadResults.ActiveSheet.AutoFilterReset(8)
        FpSpreadResults.ActiveSheet.AutoFilterReset(10)

        Do Until Rs.Read = False
            With FpSpreadResults.ActiveSheet
                .RowCount = .RowCount + 1
                .SetText(I, 0, Rs("PatientID").ToString)
                .SetText(I, 1, Rs("PatName").ToString)
                .SetText(I, 2, Rs("CaseType").ToString)
                .SetText(I, 3, Rs("DiagName").ToString)
                .SetText(I, 4, Rs("ProcName").ToString)
                .SetText(I, 5, Rs("TrName").ToString)
                .SetText(I, 6, Rs("ProcStatus").ToString)
                .SetText(I, 7, Rs("BillID").ToString)
                .SetText(I, 8, Rs("CaseStatus").ToString)
                If IsDate(Rs("ScheduleDateTime").ToString) Then
                    .SetText(I, 9, CDate(Rs("ScheduleDateTime").ToString).ToString("MM/dd/yyyy"))
                Else
                    .SetText(I, 9, "")
                End If
                .SetText(I, 10, Rs("ReferringDoctor").ToString)
                LabelCount.Text = "Loading " & I & " record. Please wait..."
                If I Mod 10 = 0 Then
                    Application.DoEvents()
                End If
                I = I + 1
            End With
        Loop
        FpSpreadResults.ResumeLayout()
        Cursor = Cursors.Default
        Application.DoEvents()

        LabelCount.Text = FpSpreadResults.ActiveSheet.RowCount & " Records Found"
    End Sub
    Private Sub Export_Excell()
        Dim strFileName As String
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to process Data Export." & vbCrLf & "No data loaded.", MsgBoxStyle.Exclamation)
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

    Private Sub Print_Report()
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to print." & vbCrLf & "No data loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Printinfo.SmartPrintPagesWide = 1
        Printinfo.BestFitRows = True
        Printinfo.Preview = True
        Printinfo.ShowShadows = False
        Printinfo.JobName = "eMedical Office"
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
    Private Sub Email_Report()
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to Email. No Data has been loaded. Please specify the search criteria an click the Load button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Dim RecAddress As String
        Subject = "Message From " & gOfficeName & " / Data Report " & DateTimePickerFrom.Value.Date & " - " & DateTimePickerTo.Value.Date & " / Attached: Data Excel File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(" Data " & DateTimePickerFrom.Value.Date & " - " & DateTimePickerTo.Value.Date) & ".xls"
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
            RecAddress = gSQLGetSingleValueString("Select eMail from Employees where EmpID = " & CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Value)

            Msg.SendMail(Fname.ToString, Subject, Subject, RecAddress)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Fax_Report()
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to Fax. No Data has been loaded. Please specify the search criteria an click the Load button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Data Report " & DateTimePickerFrom.Value.Date & " - " & DateTimePickerTo.Value.Date & " / Attached: Data Excel File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName(" Data " & DateTimePickerFrom.Value.Date & " - " & DateTimePickerTo.Value.Date) & ".xls"
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
            gFax(Me, "", Subject, Fname.ToString, gOfficeFax, CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Value)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ListView1_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs)
        If Loading Then Exit Sub
        FpSpreadResults.ActiveSheet.Columns(e.Index).Visible = e.NewValue
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Print_Report()
    End Sub

    Private Sub ToolStripDropDownButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton1.Click
        Export_Excell()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Email_Report()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Fax_Report()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripButtonCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        ToolStripButton3.Enabled = False
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        gSpreadAutoColumnWidth(FpSpreadResults, 20)
        Cursor = Cursors.Default
        ToolStripButton3.Enabled = True
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        ComboBoxTreatingProviderID.SelectedIndex = 0
        ComboBoxCaseStatus.SelectedIndex = 0
        ComboBoxProcedureStatus.SelectedIndex = 0
        cboBillStatus.SelectedIndex = 0
        ComboBoxCaseType.SelectedIndex = 0
        ComboBoxTreatmentType.SelectedIndex = 0
        DateTimePickerFrom.Value = DateAdd(DateInterval.Month, -1, Now.Date)
        DateTimePickerTo.Value = Now.Date
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        DateTimePickerFrom.Focus()
        DateTimePickerSvcFrom.Value = DateAdd(DateInterval.Month, -1, Now.Date)
        DateTimePickerSvcTo.Value = Now.Date
        DateTimePickerSvcFrom.Checked = False
        DateTimePickerSvcTo.Checked = False
    End Sub

    Private Sub ClearFilters_Click(sender As Object, e As EventArgs) Handles ClearFilters.Click
        FpSpreadResults.ActiveSheet.AutoFilterReset(2)
        FpSpreadResults.ActiveSheet.AutoFilterReset(3)
        FpSpreadResults.ActiveSheet.AutoFilterReset(4)
        FpSpreadResults.ActiveSheet.AutoFilterReset(5)
        FpSpreadResults.ActiveSheet.AutoFilterReset(6)
        FpSpreadResults.ActiveSheet.AutoFilterReset(7)
        FpSpreadResults.ActiveSheet.AutoFilterReset(8)
        FpSpreadResults.ActiveSheet.AutoFilterReset(10)
    End Sub

    Private Sub ComboBoxProcedureStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxProcedureStatus.SelectedIndexChanged
        If ComboBoxProcedureStatus.SelectedIndex < 2 Then
            DateTimePickerSvcFrom.Checked = False
            DateTimePickerSvcTo.Checked = False
            DateTimePickerSvcFrom.Enabled = False
            DateTimePickerSvcTo.Enabled = False
        Else
            DateTimePickerSvcFrom.Enabled = True
            DateTimePickerSvcTo.Enabled = True
        End If
    End Sub
End Class