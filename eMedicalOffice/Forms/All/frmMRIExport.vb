Imports System.Reflection
Imports log4net

Public Class frmMRIExport
    Private log as ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private Sub frmMRIExport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim I As Integer
        gWindow_Settings(Me, ReadWrite.sWrite)
        SaveSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerFrom", DateTimePickerFrom.Value)
        SaveSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerTo", DateTimePickerTo.Value)
        gSpread_Settings(Me, FpSpreadResults, ReadWrite.sWrite)
        SaveSetting(My.Application.Info.ProductName, "Settings", Me.Name & "LastTreatingProvider", ComboBoxTreatingProviderID.SelectedIndex)
        SaveSetting(My.Application.Info.ProductName, "Settings", Me.Name & "LastNameDisplay", ComboBoxNames.SelectedIndex)

        For I = 0 To ListView1.Items.Count - 1
            SaveSetting(My.Application.Info.ProductName, "Settings", Me.Name & "ColumnDisplay" & I, ListView1.Items(I).Checked)
        Next
    End Sub
    Private Sub Load_Columns()
        Dim I As Integer
        For I = 0 To FpSpreadResults.ActiveSheet.Columns.Count - 1
            ListView1.Items.Add(FpSpreadResults.ActiveSheet.ColumnHeader.Cells(0, I).Text)
        Next
    End Sub
    Dim Loading As Boolean
    Private Sub frmMRIExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim I As Integer
        Load_Data()

        gWindow_Settings(Me, ReadWrite.sRead)
        DateTimePickerFrom.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerFrom", DateAdd("M", -1, Now))
        DateTimePickerTo.Value = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "DateTimePickerTo", Now)
        gSpread_Settings(Me, FpSpreadResults, ReadWrite.sRead)
        FpSpreadResults.ActiveSheet.RowCount = 0
        Loading = True
        Load_Columns()
        For I = 0 To ListView1.Items.Count - 1
            ListView1.Items(I).Checked = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "ColumnDisplay" & I, 1)
        Next
        Loading = False
        Timer1.Enabled = True
    End Sub
    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        ComboBoxTreatingProviderID.Items.Clear()
        Reader = gSQLGetDataReader("SELECT   Employees.EmpID,   Employees.Fname, Employees.Lname, Employees.Alias, Employees.BillingPrv, Employees.TreatmentPrv FROM Employees INNER JOIN EmployeeOffice ON Employees.EmpID = EmployeeOffice.EmpID WHERE  TreatmentPrv=1 and Employees.ActiveInd = 1 and   (Employees.PositionID = 5) AND (EmployeeOffice.OfficeID = " & gOfficeID & ")")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxTreatingProviderID.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("FName").ToString & " " & Reader("LName").ToString & " " & Reader("Alias").ToString))
        Loop
        Reader.Close() : Reader.Dispose()
        If ComboBoxTreatingProviderID.Items.Count > 0 Then
            Try
                ComboBoxTreatingProviderID.SelectedIndex = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "LastTreatingProvider", -1)
            Catch ex As Exception

            End Try
        End If

        ComboBoxNames.Items.Add("First MI Last Suffix")
        ComboBoxNames.Items.Add("First, MI, Last, Suffix")
        ComboBoxNames.Items.Add("Last MI First Suffix")
        ComboBoxNames.Items.Add("Last, MI, First, Suffix")
        ComboBoxNames.Items.Add("Last, First MI Suffix")
        ComboBoxNames.Items.Add("First, Last MI Suffix")
        Dim Ind As Integer = GetSetting(My.Application.Info.ProductName, "Settings", Me.Name & "LastNameDisplay", 0)
        ComboBoxNames.SelectedIndex = Ind

    End Sub
    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        Dim Rs As SqlClient.SqlDataReader
        Dim SQL As String
        Dim I As Integer = 0
        If ComboBoxTreatingProviderID.SelectedIndex = -1 Then
            MsgBox("Unable to load data. Please select a treating Provider.", MsgBoxStyle.Exclamation)
            ComboBoxTreatingProviderID.Focus()
            Exit Sub
        End If
        LabelCount.Text = "Loading. Please Wait..."
        FpSpreadResults.ActiveSheet.RowCount = 0
        SQL = "SELECT Patients.InsertedDT, Patients.PatientID, Patients.Sex, Patients.DOB, Patients.DOA, Patients.Injury,  Patients.LName , Patients.MI , Patients.FName , Patients.Suffix , Procedures.ProcName, Schedule.ScheduleDateTime, Patients.ReferringDoctor "
        SQL &= " FROM         Patients INNER JOIN PatientProcedures ON Patients.PatientID = PatientProcedures.PatientID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID "
        SQL &= " WHERE PatientProcedures.ProcedureStatusID = 2 and PatientProcedures.OfficeID=" & gOfficeID
        SQL &= " and PatientProcedures. TreatingProviderID = " & CType(ComboBoxTreatingProviderID.SelectedItem, ValueDescription).Value
        If DateTimePickerFrom.Checked Then
            SQL &= " and DATEDIFF(d, '" & DateTimePickerFrom.Text & "', Schedule.ScheduleDateTime ) >= 0 "
        End If
        If DateTimePickerTo.Checked Then
            SQL &= " and DATEDIFF(d, Schedule.ScheduleDateTime, '" & DateTimePickerTo.Text & "') >= 0 "
        End If
        SQL &= " ORDER BY Schedule.ScheduleDateTime "

        Rs = gSQLGetDataReader(SQL)
        If Rs Is Nothing Then
            LabelCount.Text = "Error."
            Exit Sub
        End If

        Do Until Rs.Read = False
            With FpSpreadResults.ActiveSheet
                .RowCount = .RowCount + 1
                .SetText(I, 0, Rs("PatientID").ToString)
                Select Case ComboBoxNames.SelectedIndex
                    Case 0
                        .SetText(I, 1, Rs("FName").ToString & IIf(Rs("MI").ToString <> "", " " & Rs("MI").ToString, "") & IIf(Rs("LName").ToString <> "", " " & Rs("LName").ToString, "") & IIf(Rs("Suffix").ToString <> "", " " & Rs("Suffix").ToString, ""))
                    Case 1
                        .SetText(I, 1, Rs("FName").ToString & IIf(Rs("MI").ToString <> "", ", " & Rs("MI").ToString, "") & IIf(Rs("LName").ToString <> "", ", " & Rs("LName").ToString, "") & IIf(Rs("Suffix").ToString <> "", ", " & Rs("Suffix").ToString, ""))
                    Case 2
                        .SetText(I, 1, Rs("LName").ToString & IIf(Rs("MI").ToString <> "", " " & Rs("MI").ToString, "") & IIf(Rs("FName").ToString <> "", " " & Rs("FName").ToString, "") & IIf(Rs("Suffix").ToString <> "", " " & Rs("Suffix").ToString, ""))
                    Case 3
                        .SetText(I, 1, Rs("LName").ToString & IIf(Rs("MI").ToString <> "", ", " & Rs("MI").ToString, "") & IIf(Rs("FName").ToString <> "", ", " & Rs("FName").ToString, "") & IIf(Rs("Suffix").ToString <> "", ", " & Rs("Suffix").ToString, ""))
                    Case 4
                        .SetText(I, 1, Rs("LName").ToString & IIf(Rs("FName").ToString <> "", ", " & Rs("FName").ToString, "") & IIf(Rs("MI").ToString <> "", " " & Rs("MI").ToString, "") & IIf(Rs("Suffix").ToString <> "", " " & Rs("Suffix").ToString, ""))
                    Case 5
                        .SetText(I, 1, Rs("FName").ToString & IIf(Rs("LName").ToString <> "", ", " & Rs("LName").ToString, "") & IIf(Rs("MI").ToString <> "", " " & Rs("MI").ToString, "") & IIf(Rs("Suffix").ToString <> "", " " & Rs("Suffix").ToString, ""))
                End Select
                If IsDate(Rs("DOB").ToString) Then
                    .SetText(I, 2, CDate(Rs("DOB").ToString).ToString("MM/dd/yyyy"))
                Else
                    .SetText(I, 2, "")
                End If
                .SetText(I, 3, Rs("Sex").ToString)
                If IsDate(Rs("DOA").ToString) Then
                    .SetText(I, 4, CDate(Rs("DOA").ToString).ToString("MM/dd/yyyy"))
                Else
                    .SetText(I, 4, "")
                End If
                If IsDate(Rs("InsertedDT").ToString) Then
                    .SetText(I, 5, CDate(Rs("InsertedDT").ToString).ToString("MM/dd/yyyy"))
                Else
                    .SetText(I, 5, "")
                End If
                .SetText(I, 6, Rs("ProcName").ToString)
                .SetText(I, 7, CDate(Rs("ScheduleDateTime")).ToString("MM/dd/yyyy"))
                .SetText(I, 8, Rs("ReferringDoctor").ToString)
                .SetText(I, 9, Rs("Injury").ToString)
                I = I + 1
            End With
        Loop
        LabelCount.Text = FpSpreadResults.ActiveSheet.RowCount & " Records Found"
    End Sub
    Private Sub Export_Excell()
        Dim strFileName As String
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to process Data Export." & vbCrLf & "No data loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("Unable to process Data Export." & vbCrLf & "No data columns selected to be shown.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
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
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("Unable to print." & vbCrLf & "No data columns selected to be shown.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
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
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("Unable to Email." & vbCrLf & "No data columns selected to be shown.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
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
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Fax_Report()
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to Fax. No Data has been loaded. Please specify the search criteria an click the Load button.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("Unable to Fax." & vbCrLf & "No data columns selected to be shown.", MsgBoxStyle.Exclamation)
            ListView1.Focus()
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
            TopMost=False
            msgbox (ex.Message,MsgBoxStyle.Critical,"Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ListView1_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListView1.ItemCheck
        If Loading Then Exit Sub
        FpSpreadResults.ActiveSheet.Columns(e.Index).Visible = e.NewValue
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim i As Integer
        Timer1.Enabled = False
        For I = 0 To ListView1.Items.Count - 1
            FpSpreadResults.ActiveSheet.Columns(i).Visible = ListView1.Items(i).Checked
        Next
        'FpSpreadResults.Dock = DockStyle.None
        'FpSpreadResults.Width = Me.Width - 213
        'FpSpreadResults.Height = Me.Height - 68
        'FpSpreadResults.Left = 213
        'FpSpreadResults.Dock = DockStyle.Fill
        FpSpreadResults.Visible = True
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

    Private Sub ToolStripButtonCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCloseForm.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        gSpreadAutoColumnWidth(FpSpreadResults)
    End Sub
End Class