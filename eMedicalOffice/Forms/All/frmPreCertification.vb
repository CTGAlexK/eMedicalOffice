Imports System.Reflection
Imports System.Text
Imports log4net

Public Class frmPreCertification
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private Sub frmMRIExport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim I As Integer
        If VerifyDataChanged() > 0 Then
            If MsgBox("You have unsaved data. Discard changes?" & vbCrLf & "Click the Update button to complete verification process.", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        gWindow_Settings(Me, ReadWrite.sWrite)
        gSpread_Settings(Me, FpSpreadResults, ReadWrite.sWrite)
    End Sub

    Dim Loading As Boolean

    Private Sub frmMRIExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim I As Integer
        gWindow_Settings(Me, ReadWrite.sRead)
        gSpread_Settings(Me, FpSpreadResults, ReadWrite.sRead)
        Loading = True
        Load_Data()
        'FpSpreadResults.ActiveSheet.RowCount = 0
        Loading = False
        Timer1.Enabled = True
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        ComboBoxRefOffice.Items.Clear()
        ComboBoxRefOffice.Items.Add(New ValueDescription("0", "All"))
        Reader = gSQLGetDataReader("SELECT OfficeID, OfficeName FROM ReferringOffices WHERE sysOfficeID = " & gOfficeID & " ORDER BY OfficeName")

        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxRefOffice.Items.Add(New ValueDescription(CLng(Val(Reader("OfficeID").ToString)), Reader("OfficeName").ToString))
        Loop
        ComboBoxRefOffice.SelectedIndex = 0
        Reader.Close() : Reader.Dispose()
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
            MsgBox("Unable to Email. No data loaded.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Dim RecAddress As String
        Subject = "Message From " & gOfficeName & " / Data Report / Attached: Pre-Certification Data Excel File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName("PreCertificationData.xls")
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
            'RecAddress = gSQLGetSingleValueString("Select eMail from Employees where EmpID = " & CType(ComboBoxInsuranceCompany.SelectedItem, ValueDescription).Value)
            Msg.SendMail(Fname.ToString, Subject, Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Fax_Report()
        If FpSpreadResults.ActiveSheet.RowCount = 0 Then
            MsgBox("Unable to Fax. No data loaded.", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Subject = "Message From " & gOfficeName & " / Data Report / Attached: Pre-Certification Data Excel File"
        Fname = System.IO.Path.GetTempPath & "\" & gFixFileName("PreCertificationData.xls")
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
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
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

    Private Sub ToolStripButtonCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim SQL As String = ""
        Dim I As Integer = 0
        Timer1.Enabled = False
        Dim Rs As SqlClient.SqlDataReader
        Dim pName As New StringBuilder
        Dim Contact1 As New StringBuilder
        Dim Contact2 As New StringBuilder
        Clear_Details()
        Application.DoEvents()
        SQL = "SELECT   Patients.CaseStatusID,   Patients.NoMoreAppointmentsInd,  PatientProcedures.ProcedureStatusID, PatientProcedures.PatientProcedureID, PatientProcedures.PatientID, ISNULL(Patients.FName, '') AS Fname, ISNULL(Patients.MI, '') AS MI, ISNULL(Patients.LName, '') " & vbCrLf
        SQL &= "                      AS Lname, ISNULL(Patients.Suffix, '') AS Suffix, Procedures.ProcName, InsuranceCompanies_1.CompanyID AS CompanyID1, " & vbCrLf
        SQL &= "                      InsuranceCompanies_1.CompanyName AS CompanyName1, InsuranceCompanies_1.Contact1 AS Contact11, " & vbCrLf
        SQL &= "                      InsuranceCompanies_1.Contact1Phone AS Contact1Phone1, InsuranceCompanies_1.Contact2 AS Contact21, " & vbCrLf
        SQL &= "                      InsuranceCompanies_1.Contact2Phone AS Contact2Phone1, InsuranceCompanies_1.Phone1 AS Phone11, InsuranceCompanies_1.Phone2 AS Phone21, " & vbCrLf
        SQL &= "                      InsuranceCompanies_2.CompanyID AS CompanyID2, InsuranceCompanies_2.CompanyName AS CompanyName2, InsuranceCompanies_2.Contact1 AS Contact12, " & vbCrLf
        SQL &= "                      InsuranceCompanies_2.Contact1Phone AS Contact1Phone2, InsuranceCompanies_2.Contact2 AS Contact22, " & vbCrLf
        SQL &= "                      InsuranceCompanies_2.Contact2Phone AS Contact2Phone2, InsuranceCompanies_2.Phone1 AS Phone12, InsuranceCompanies_2.Phone2 AS Phone22" & vbCrLf
        SQL &= "FROM         PatientProcedures INNER JOIN" & vbCrLf
        SQL &= "                      Patients ON PatientProcedures.PatientID = Patients.PatientID INNER JOIN " & vbCrLf
        SQL &= "                      Procedures ON PatientProcedures.ProcID = Procedures.ProcID LEFT OUTER JOIN " & vbCrLf
        SQL &= "                      InsuranceCompanies AS InsuranceCompanies_2 ON Patients.InsuranceCompanyID1 = InsuranceCompanies_2.CompanyID LEFT OUTER JOIN " & vbCrLf
        SQL &= "                      InsuranceCompanies AS InsuranceCompanies_1 ON Patients.InsuranceCompanyID = InsuranceCompanies_1.CompanyID " & vbCrLf
        SQL &= "        WHERE (PatientProcedures.PreCertificationDT Is NULL) " & vbCrLf
        If CheckBoxActiveCases.Checked Then
            SQL &= " AND Patients.CaseStatusID=1 "
        End If
        If CheckBoxNotCompletedProceduresOnly.Checked Then
            SQL &= " AND PatientProcedures.ProcedureStatusID<>2 "
        End If

        If ComboBoxRefOffice.SelectedIndex > 0 Then
            SQL &= " AND Patients.ReferringCompanyID = " & CType(ComboBoxRefOffice.SelectedItem, ValueDescription).Value & " "
        End If
        Rs = gSQLGetDataReader(SQL)
        If Rs Is Nothing Then
            LabelCount.Text = "Error."
            Exit Sub
        End If
        FpSpreadResults.Visible = False
        FpSpreadResults.SuspendLayout()
        FpSpreadResults.ActiveSheet.RowCount = 0
        FpSpreadResults.ActiveSheet.Columns(0).ResetSortIndicator()
        FpSpreadResults.ActiveSheet.Columns(1).ResetSortIndicator()
        FpSpreadResults.ActiveSheet.Columns(2).ResetSortIndicator()
        FpSpreadResults.ActiveSheet.Columns(3).ResetSortIndicator()
        FpSpreadResults.ActiveSheet.Columns(4).ResetSortIndicator()
        FpSpreadResults.ActiveSheet.Columns(5).ResetSortIndicator()
        FpSpreadResults.ActiveSheet.Columns(6).ResetSortIndicator()
        FpSpreadResults.ActiveSheet.Columns(7).ResetSortIndicator()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Do Until Rs.Read = False
            With FpSpreadResults.ActiveSheet
                .RowCount = .RowCount + 1
                If Val(Rs("CaseStatusID").ToString) <> 1 Or Val(Rs("NoMoreAppointmentsInd").ToString) = 1 Then
                    .Rows(I).ForeColor = Color.Red
                End If

                pName.Remove(0, pName.Length)
                Contact1.Remove(0, Contact1.Length)
                Contact2.Remove(0, Contact2.Length)

                pName.Append(Rs("FName").ToString)
                If Rs("MI").ToString.Trim.Length > 0 Then pName.Append(" " & Rs("MI").ToString.Trim)
                If Rs("LName").ToString.Trim.Length > 0 Then pName.Append(" " & Rs("LName").ToString.Trim)
                If Rs("Suffix").ToString.Trim.Length > 0 Then pName.Append(" " & Rs("Suffix").ToString.Trim)
                If (Rs("Phone11").ToString <> "(___) ___-____" And Rs("Phone11").ToString.Length > 0) Then Contact1.Append(Replace(Rs("Phone11").ToString, "_", ""))
                If (Rs("Phone21").ToString <> "(___) ___-____" And Rs("Phone21").ToString.Length > 0) Then Contact2.Append(" " & Replace(Rs("Phone21").ToString, "_", ""))
                If (Rs("Contact1Phone1").ToString <> "(___) ___-____ Ext. _____" And Rs("Contact1Phone1").ToString.Length > 0) Then Contact1.Append(" " & Replace(Rs("Contact1Phone1").ToString, "Ext. _____", ""))
                If (Rs("Contact2Phone1").ToString <> "(___) ___-____ Ext. _____" And Rs("Contact2Phone1").ToString.Length > 0) Then Contact1.Append(" " & Replace(Rs("Contact2Phone1").ToString, "Ext. _____", ""))

                .SetTag(I, 0, Rs("PatientProcedureID").ToString)
                .SetTag(I, 1, Rs("PatientID").ToString)
                .SetText(I, 0, "")
                .SetText(I, 1, Rs("PatientID").ToString)
                .SetText(I, 2, pName.ToString)
                .SetText(I, 3, Rs("ProcName").ToString)
                .SetText(I, 4, Rs("CompanyName1").ToString)
                .SetText(I, 5, Contact1.ToString)
                .SetText(I, 6, Rs("CompanyName2").ToString)
                .SetText(I, 7, Contact2.ToString)
                Select Case Val(Rs("ProcedureStatusID").ToString)
                    Case 0

                    Case 1
                        FpSpreadResults.ActiveSheet.Cells(I, 3).BackColor = Color.Khaki
                    Case 2
                        FpSpreadResults.ActiveSheet.Cells(I, 3).BackColor = Color.DarkSeaGreen
                End Select
                ' Test
                If I = 20 Then Exit Do
                I = I + 1
            End With
        Loop
        If FpSpreadResults.ActiveSheet.RowCount > 0 Then FpSpreadResults.ActiveSheet.Cells(0, 0, FpSpreadResults.ActiveSheet.RowCount - 1, 0).BackColor = Color.DarkRed
        FpSpreadResults.Visible = True
        FpSpreadResults.ResumeLayout()
        If FpSpreadResults.ActiveSheet.RowCount > 0 Then
            Dim ID As Integer
            FpSpreadDetails.ShowRow(FpSpreadDetails.GetActiveRowViewportIndex, 0, FarPoint.Win.Spread.VerticalPosition.Top)
            ID = Val(FpSpreadResults.ActiveSheet.Cells(0, 1).Text)
            Clear_Details()
            Show_Details(ID)
        End If
        LabelCount.Text = FpSpreadResults.ActiveSheet.RowCount & " Records Found"
        Cursor = Cursors.Default
    End Sub

    Public Sub Clear_Details()
        Dim I As Integer
        Dim SPHeight As Integer
        For I = 0 To FpSpreadDetails_Sheet1.RowCount - 1
            FpSpreadDetails_Sheet1.SetText(I, 1, "")

            'FpSpreadDetails_Sheet1.SetRowHeight(I, CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight))
            'SPHeight = SPHeight + CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight)
        Next
        'If FpSpreadDetails.Height <> SPHeight Then FpSpreadDetails.Height = SPHeight
        FpSpreadDetails_Sheet1.Cells(0, 1).ForeColor = Color.Black
        If FpSpreadProcedures.ActiveSheet.RowCount <> 0 Then FpSpreadProcedures.ActiveSheet.RowCount = 0
    End Sub

    Public Sub Show_Details(ByVal ID As Long)
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim lCell As String
        Dim I As Integer

        SQL = " SELECT  Patients.CaseStatusID,   Patients.NoMoreAppointmentsInd, Patients.PatientID, Patients.FName, Patients.MI, Patients.LName, Patients.Suffix, Patients.DOB, Patients.Sex, Patients.SSN,  "
        SQL &= "                      Patients.Address1, Patients.Address2, Patients.City, Patients.State, Patients.Zip, InsuranceCompanies_1.CompanyName AS CompanyName1, "
        SQL &= "                      InsuranceCompanies_2.CompanyName AS CompanyName2, Patients.PolicyNumber AS PolicyNumber1, Patients.ClaimNumber AS ClaimNumber1, "
        SQL &= "                      Patients.PolicyNumber1 AS PolicyNumber2, Patients.ClaimNumber1 AS ClaimNumber2, ReferringOffices.OfficeName, Patients.Attorney, CaseStatuses.Description as Status "
        SQL &= " FROM         Patients INNER JOIN "
        SQL &= "                      CaseStatuses ON Patients.CaseStatusID = CaseStatuses.CaseStatusID LEFT OUTER JOIN "
        SQL &= "                      ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID LEFT OUTER JOIN "
        SQL &= "                      InsuranceCompanies AS InsuranceCompanies_2 ON Patients.InsuranceCompanyID1 = InsuranceCompanies_2.CompanyID LEFT OUTER JOIN "
        SQL &= "                      InsuranceCompanies AS InsuranceCompanies_1 ON Patients.InsuranceCompanyID = InsuranceCompanies_1.CompanyID "
        SQL &= " WHERE Patients.PatientID = " & ID
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Panel3.SuspendLayout()
        FpSpreadDetails.ShowRow(FpSpreadDetails.GetActiveRowViewportIndex, 0, FarPoint.Win.Spread.VerticalPosition.Top)
        FpSpreadProcedures.ShowRow(FpSpreadDetails.GetActiveRowViewportIndex, 0, FarPoint.Win.Spread.VerticalPosition.Top)
        Dim StatusText
        With FpSpreadDetails_Sheet1

            Do Until Reader.Read = False
                StatusText = Reader("Status").ToString.Trim
                If Val(Reader("CaseStatusID")) <> 1 Then
                    FpSpreadDetails_Sheet1.Cells(0, 1).ForeColor = Color.Red
                End If
                If Val(Reader("NoMoreAppointmentsInd").ToString) = 1 Then
                    StatusText &= ", No More Appointments"
                    FpSpreadDetails_Sheet1.Cells(0, 1).ForeColor = Color.Red
                End If
                .SetText(0, 1, StatusText)
                .SetText(1, 1, Reader("PatientID").ToString)
                .SetText(2, 1, Reader("FName").ToString & IIf(Reader("MI").ToString <> "", " " & Reader("MI").ToString, "") & IIf(Reader("LName").ToString <> "", " " & Reader("LName").ToString, "") & IIf(Reader("Suffix").ToString <> "", " " & Reader("Suffix").ToString, ""))
                If IsDate(Reader("DOB").ToString) Then
                    .SetText(3, 1, CDate(Reader("DOB").ToString).ToString("MM/dd/yyyy"))
                End If
                .SetText(4, 1, Reader("SSN").ToString)
                .SetText(5, 1, Reader("Sex").ToString)
                .SetText(6, 1, Reader("Address1").ToString & IIf(Reader("Address2").ToString <> "", " " & Reader("Address2").ToString, "") & IIf(Reader("City").ToString <> "", ", " & Reader("City").ToString, "") & IIf(Reader("State").ToString <> "", ", " & Reader("State").ToString, "") & IIf(Reader("Zip").ToString <> "", ", " & Reader("Zip").ToString, ""))
                .SetText(7, 1, Reader("CompanyName1").ToString)
                .SetText(8, 1, Reader("PolicyNumber1").ToString)
                .SetText(9, 1, Reader("ClaimNumber1").ToString)
                .SetText(10, 1, Reader("CompanyName2").ToString)
                .SetText(11, 1, Reader("PolicyNumber2").ToString)
                .SetText(12, 1, Reader("ClaimNumber2").ToString)
                .SetText(13, 1, Reader("OfficeName").ToString)
                .SetText(14, 1, Reader("Attorney").ToString)
            Loop
        End With
        Dim SPHeight As Integer
        For I = 0 To FpSpreadDetails_Sheet1.RowCount - 1
            FpSpreadDetails_Sheet1.SetRowHeight(I, CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight))
            SPHeight = SPHeight + CInt(FpSpreadDetails_Sheet1.Rows(I).GetPreferredHeight)
        Next
        If FpSpreadDetails.Height <> SPHeight + 20 Then FpSpreadDetails.Height = SPHeight + 20

        SQL = "SELECT     PatientProcedures.PatientProcedureID, PatientProcedures.ProcID, PatientProcedures.DiagID, PatientProcedures.ProcedureStatusID, Procedures.ProcName, Schedule.ScheduleDateTime "
        SQL = SQL & " FROM  PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID LEFT OUTER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Patients on PatientProcedures.PatientID = Patients.PatientID"
        SQL = SQL & " WHERE PatientProcedures.PatientID = " & ID
        SQL = SQL & " Order by PatientProcedures.ProcID "
        Reader = gSQLGetDataReader(SQL.ToString)
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

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        gSpreadAutoColumnWidth(FpSpreadResults)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If VerifyDataChanged() > 0 Then
            If MsgBox("You have unsaved data. Discard changes?" & vbCrLf & "Click the Update button to complete verification process.", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub FpSpreadResults_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadResults.CellDoubleClick
        Dim Ret As String
        Dim Proc As String
        Dim Pat As String

        Ret = FpSpreadResults.ActiveSheet.Cells(e.Row, 0).Text
        Pat = FpSpreadResults.ActiveSheet.Cells(e.Row, 2).Text
        Proc = FpSpreadResults.ActiveSheet.Cells(e.Row, 3).Text
        If Ret = "" Then
            If MsgBox("Please confirnm the procedure " & Proc & " for the patient " & Pat & " Pre-Certification has been verified?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pre-Certification has been verified") = MsgBoxResult.No Then Exit Sub
            FpSpreadResults.ActiveSheet.Cells(e.Row, 0).Text = Now.ToShortDateString
            FpSpreadResults.ActiveSheet.Cells(e.Row, 0).BackColor = Color.White
        Else
            If MsgBox("Please confirnm the procedure " & Proc & " for the patient " & Pat & " Pre-Certification has NOT been verified?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Pre-Certification has NOT been verified") = MsgBoxResult.No Then Exit Sub
            FpSpreadResults.ActiveSheet.Cells(e.Row, 0).Text = ""
            FpSpreadResults.ActiveSheet.Cells(e.Row, 0).BackColor = Color.DarkRed
        End If
        ToolStripLabelDataChanged.Visible = VerifyDataChanged()
    End Sub

    Private Function VerifyDataChanged() As Integer
        Dim I As Integer
        Dim C As Integer
        For I = 0 To FpSpreadResults.ActiveSheet.RowCount - 1
            If FpSpreadResults.ActiveSheet.Cells(I, 0).Text <> "" Then
                C = C + 1
            End If
        Next
        ToolStripLabelDataChanged.Visible = CBool(C)
        Return C
    End Function

    Private Sub FpSpreadResults_SelectionChanged(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.SelectionChangedEventArgs) Handles FpSpreadResults.SelectionChanged
        Dim ID As Integer
        If e.Range.Row = -1 Then Exit Sub
        ID = Val(FpSpreadResults.ActiveSheet.Cells(e.Range.Row, 1).Text)
        Clear_Details()
        Show_Details(ID)
    End Sub

    Private Sub ContextMenuStrip_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip.Opening
        Dim Ret As String
        Dim Proc As String
        Dim Pat As String
        Ret = FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 0).Text
        If Ret = "" Then
            PreCertificationCompleteToolStripMenuItem.Visible = True
            PreCertificationNotCompleteToolStripMenuItem.Visible = False
        Else
            PreCertificationCompleteToolStripMenuItem.Visible = False
            PreCertificationNotCompleteToolStripMenuItem.Visible = True
        End If

    End Sub

    Private Sub PreCertificationCompleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreCertificationCompleteToolStripMenuItem.Click
        Dim Ret As String
        Dim Proc As String
        Dim Pat As String
        Ret = FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 0).Text
        Pat = FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 2).Text
        Proc = FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 3).Text
        If MsgBox("Please confirnm the procedure " & Proc & " for the patient " & Pat & " Pre-Certification has been verified?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pre-Certification has been verified") = MsgBoxResult.No Then Exit Sub
        FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 0).Text = Now.ToShortDateString
        FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 0).BackColor = Color.White
        ToolStripLabelDataChanged.Visible = VerifyDataChanged()
    End Sub

    Private Sub PreCertificationNotCompleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreCertificationNotCompleteToolStripMenuItem.Click
        Dim Ret As String
        Dim Proc As String
        Dim Pat As String
        Ret = FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 0).Text
        Pat = FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 2).Text
        Proc = FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 3).Text
        If MsgBox("Please confirnm the procedure " & Proc & " for the patient " & Pat & " Pre-Certification has NOT been verified?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Pre-Certification has NOT been verified") = MsgBoxResult.No Then Exit Sub
        FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 0).Text = ""
        FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 0).BackColor = Color.DarkRed
        ToolStripLabelDataChanged.Visible = VerifyDataChanged()
    End Sub

    Private Sub mnuShowSelectedPatientInfo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowSelectedPatientInfo1.Click
        Dim RetID As Integer
        RetID = Val(FpSpreadResults.ActiveSheet.Cells(FpSpreadResults.ActiveSheet.ActiveRowIndex, 1).Text)
        Using NewFrm As New frmPatient

            NewFrm.Width = 1225
            NewFrm.WindowState = FormWindowState.Normal
            NewFrm.StartPosition = FormStartPosition.CenterParent
            NewFrm.InitialTab = 0
            NewFrm.InitialPatientName = RetID
            NewFrm.InitialEdit = False
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub CheckBoxActiveCases_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxActiveCases.CheckedChanged
        If Loading Then Exit Sub
        If VerifyDataChanged() > 0 Then
            If MsgBox("You have unsaved data. Discard changes?" & vbCrLf & "Click the Update button to complete verification process.", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Loading = True
                CheckBoxActiveCases.Checked = Not CheckBoxActiveCases.Checked
                Loading = False
                Exit Sub
            End If
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub CheckBoxNotCompletedProceduresOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxNotCompletedProceduresOnly.CheckedChanged
        If Loading Then Exit Sub
        If VerifyDataChanged() > 0 Then
            If MsgBox("You have unsaved data. Discard changes?" & vbCrLf & "Click the Update button to complete verification process.", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Loading = True
                CheckBoxNotCompletedProceduresOnly.Checked = Not CheckBoxNotCompletedProceduresOnly.Checked
                Loading = False
                Exit Sub
            End If
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub FpSpreadResults_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpreadResults.CellClick

    End Sub

    Private Sub FpSpreadResults_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FpSpreadResults.MouseDown
        Dim Row As Integer
        Dim HT As FarPoint.Win.Spread.HitTestInformation
        Dim ID As Integer
        If e.Button = Windows.Forms.MouseButtons.Right Then
            HT = FpSpreadResults.HitTest(e.X, e.Y)
            Row = HT.ViewportInfo.Row
            FpSpreadResults.ActiveSheet.ActiveRowIndex = Row
            ID = Val(FpSpreadResults.ActiveSheet.Cells(Row, 1).Text)
            Clear_Details()
            Show_Details(ID)
        End If
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        Dim C As Integer
        Dim I As Integer
        Dim Ret As String
        Dim ID As Integer

        C = VerifyDataChanged()
        If C = 0 Then
            MsgBox("Unable to process your request. No data changed.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("Please confirm you want to update " & C & " records?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        For I = 0 To FpSpreadResults.ActiveSheet.RowCount - 1
            Ret = FpSpreadResults.ActiveSheet.Cells(I, 0).Text
            If Ret <> "" Then
                ID = Val(FpSpreadResults.ActiveSheet.GetTag(I, 0))
                gSQLUpdateData("UPDATE PatientProcedures set PreCertificationDT='" & Now.ToShortDateString & "' WHERE PatientProcedureID = " & ID)
            End If
            Timer1.Enabled = True
        Next
        ToolStripLabelDataChanged.Visible = False
    End Sub

    Private Saveindex As Integer = 0

    Private Sub ComboBoxRefOffice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxRefOffice.SelectedIndexChanged
        If Loading Then Exit Sub
        If ComboBoxRefOffice.SelectedIndex < 0 Then Exit Sub
        If VerifyDataChanged() > 0 Then
            If MsgBox("You have unsaved data. Discard changes?" & vbCrLf & "Click the Update button to complete verification process.", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Loading = True
                ComboBoxRefOffice.SelectedIndex = Saveindex
                Loading = False
                Exit Sub
            End If
        End If
        Saveindex = ComboBoxRefOffice.SelectedIndex
        Timer1.Enabled = True
    End Sub

End Class