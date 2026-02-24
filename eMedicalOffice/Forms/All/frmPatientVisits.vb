Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmPatientVisits
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private m_SortingColumn As ColumnHeader
    Private Loading As Boolean

    Private Sub Print_Listview()
        'ListViewPatients.UseCompatibleStateImageBehavior = False
        'ListViewPatients.View = System.Windows.Forms.View.List

        If FpSpread1.ActiveSheet.Rows.Count = 0 Then
            MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        Printinfo.Printer = gPrinterOtherDocuments
        Dim PS As New System.Drawing.Printing.PaperSize("Letter", 850, 1100)
        Printinfo.PaperSize = PS
        Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape

        Printinfo.Header = "/fb PATIENT STATISTICS REPORT AS OF " & Now & vbCrLf & vbCrLf
        Printinfo.Footer = "/rPage /p of /pc"
        Printinfo.ShowShadows = False
        Printinfo.JobName = "eMedical Office"
        Printinfo.PrintType = FarPoint.Win.Spread.PrintType.All
        Printinfo.ShowColor = False
        Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        'Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.ShowBorder = False
        Printinfo.ShowGrid = True
        Printinfo.ShowPrintDialog = True
        Printinfo.Preview = False
        Printinfo.BestFitRows = False
        Printinfo.BestFitCols = True
        Printinfo.Margin = New FarPoint.Win.Spread.PrintMargin(40, 20, 20, 10, 0, 0)
        Printinfo.SmartPrintPagesWide = 1
        Printinfo.SmartPrintPagesTall = 50
        Dim printrules As New FarPoint.Win.Spread.SmartPrintRulesCollection

        'printrules.Add(New FarPoint.Win.Spread.BestFitColumnRule(FarPoint.Win.Spread.ResetOption.None))
        'printrules.Add(New FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.None))
        printrules.Add(New FarPoint.Win.Spread.ScaleRule(FarPoint.Win.Spread.ResetOption.All, 1, 0.4, 0.02))
        Printinfo.SmartPrintRules = printrules
        Printinfo.UseSmartPrint = True
        Printinfo.UseMax = False
        FpSpread1.ActiveSheet.PrintInfo = Printinfo
        'FpSpread1.PrintSheet(FpSpread1.ActiveSheet)
        FpSpread1.SafePrint(FpSpread1, 0)
    End Sub

    Private Sub Export_Listview()
        Dim strFileName As String
        Application.DoEvents()

        If FpSpread1.ActiveSheet.Rows.Count = 0 Then
            MsgBox("Unable to process your request. No records checked.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        SaveFD.Title = "Export Patient Statistics To Excel."
        SaveFD.Filter = "MS Excel File (*.xls)|*.xls"
        Dim DidWork As Integer = SaveFD.ShowDialog()
        If DidWork = DialogResult.OK Then
            strFileName = SaveFD.FileName
        Else
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        FpSpread1.ActiveSheet.Protect = False
        Try
            FpSpread1.SaveExcel(strFileName)
        Catch ex As Exception
            MsgBox("Unable to save file. the file may be in use by another application or drive is full or write protected.", MsgBoxStyle.Critical)
        End Try
        FpSpread1.ActiveSheet.RowCount = 0
        FpSpread1.ResumeLayout()
        SaveFD.Reset()
        System.Diagnostics.Process.Start(strFileName)
        FpSpread1.ActiveSheet.Protect = True
        Cursor = Cursors.Default
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmPatient_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
    End Sub

    Private Sub frmPatient_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            ButtonFind_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmPatient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        gWindow_Settings(Me, ReadWrite.sRead)

        Application.DoEvents()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    End Sub

    Private Sub Load_Data()
        Dim reader As SqlClient.SqlDataReader
        Dim SQL As String
        SQL = "SELECT     DiagID, DiagAbbreviation, DiagTypeID FROM Diagnostics WHERE OfficeID = " & gOfficeID & " ORDER BY DiagTypeID, DiagID"

        'SQL = "SELECT DiagTypeID,  Diagnostics.DiagID,  Diagnostics.DiagName "
        'SQL &= " FROM Diagnostics  "
        'SQL &= " WHERE Diagnostics.OfficeID = " & gOfficeID & " ORDER BY DiagTypeID, DiagID "

        reader = gSQLGetDataReader(SQL)
        If reader Is Nothing Then Exit Sub
        ComboBoxProcedures.Items.Clear()
        ComboBoxProcedures.Items.Add(New ValueDescription(-1, "All"))
        Do Until reader.Read = False
            ComboBoxProcedures.Items.Add(New ValueDescription(CLng(reader("DiagID").ToString), reader("DiagAbbreviation").ToString, Val(reader("DiagTypeID").ToString)))
        Loop
        ComboBoxProcedures.SelectedIndex = 0
        reader.Close() : reader.Dispose()

        ComboBoxProcedureStatus.Items.Add("All")
        ComboBoxProcedureStatus.Items.Add("With Procedures")
        ComboBoxProcedureStatus.Items.Add("No Procedures")
        ComboBoxProcedureStatus.SelectedIndex = 0
    End Sub

    Private Sub Format_Spread()
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim C As Integer = 6
        Dim columnHeaderRenderer As New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer
        If ComboBoxProcedures.SelectedIndex > 0 Then
            SQL = "SELECT     DiagID, DiagAbbreviation FROM Diagnostics WHERE DiagID= " & CType(ComboBoxProcedures.SelectedItem, ValueDescription).Value & " and OfficeID = " & gOfficeID & " ORDER BY DiagTypeID, DiagID"
        Else
            SQL = "SELECT     DiagID, DiagAbbreviation FROM Diagnostics WHERE OfficeID = " & gOfficeID & " ORDER BY DiagTypeID, DiagID"
        End If

        With FpSpread1.ActiveSheet
            .Columns.Count = 6
            .ColumnHeader.Rows(0).Height = 100
            .ColumnHeader.Cells(0, 0).Text = "PAT #"
            .ColumnHeader.Cells(0, 1).Text = "NAME"
            .ColumnHeader.Cells(0, 2).Text = "DOA"
            .ColumnHeader.Cells(0, 3).Text = "INSURANCE"
            .ColumnHeader.Cells(0, 4).Text = "CONTACT"
            .ColumnHeader.Cells(0, 5).Text = "LAST SVC DT"
            .ColumnHeader.Columns(0).Width = 40
            .ColumnHeader.Columns(1).Width = 200
            .ColumnHeader.Columns(2).Width = 70
            .ColumnHeader.Columns(3).Width = 200
            .ColumnHeader.Columns(4).Width = 200
            .ColumnHeader.Columns(5).Width = 70
            .Columns(0).Locked = True
            .Columns(1).Locked = True
            .Columns(2).Locked = True
            .Columns(3).Locked = True
            .Columns(4).Locked = True
            .Columns(5).Locked = True
            .Columns(0).AllowAutoSort = True : .Columns(0).ShowSortIndicator = True
            .Columns(1).AllowAutoSort = True : .Columns(1).ShowSortIndicator = True
            .Columns(2).AllowAutoSort = True : .Columns(2).ShowSortIndicator = True
            .Columns(3).AllowAutoSort = True : .Columns(2).ShowSortIndicator = True

            columnHeaderRenderer.TextOrientation = FarPoint.Win.TextOrientation.TextVerticalFlipped
            Reader = gSQLGetDataReader(SQL)
            Do Until Reader.Read = False
                .Columns.Count = C + 1
                .ColumnHeader.Cells(0, C).Renderer = columnHeaderRenderer
                .ColumnHeader.Cells(0, C).Text = Reader("DiagAbbreviation").ToString.ToUpper
                .ColumnHeader.Columns(C).Width = 30
                .Columns(C).Locked = True
                C = C + 1
            Loop
            .Rows.Count = 0
        End With

    End Sub

    Private Sub Count_Selected()
        ToolStripStatusLabelFound.Text = " Found: " & FpSpread1.ActiveSheet.Rows.Count & "   "
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        TextBoxSearch.Text = ""
        DateTimePickerServicesFrom.Checked = False
        DateTimePickerServicesTo.Checked = False
    End Sub

    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = Cursors.WaitCursor
        gShowWait(True, PanelWait, Me)
        Find_Patients()
        gShowWait(False, PanelWait)
        Cursor = Cursors.Default
    End Sub

    Private Sub Find_Patients()
        Dim SQL As String
        Dim Reader As SqlClient.SqlDataReader
        Dim C As Integer = 3
        Dim R As Integer
        Dim PName() As String
        FpSpread1.ActiveSheet.Rows.Count = 0
        Application.DoEvents()
        FpSpread1.SuspendLayout()
        If ComboBoxProcedures.SelectedIndex > 0 Then
            SQL = "SELECT     DiagID, DiagAbbreviation FROM Diagnostics WHERE DiagID= " & CType(ComboBoxProcedures.SelectedItem, ValueDescription).Value & " and OfficeID = " & gOfficeID & " ORDER BY DiagTypeID, DiagID"
        Else
            SQL = "SELECT     DiagID, DiagAbbreviation FROM Diagnostics WHERE OfficeID = " & gOfficeID & " ORDER BY DiagTypeID, DiagID"
        End If
        Reader = gSQLGetDataReader(SQL)

        SQL = "SELECT  rtrim(isnull(Patients.Phone1,'')+' '+isnull(Patients.Phone2,'')+' '+isnull(Patients.CellPhone,'')) as Contact,    PatientID, FName+' '+isnull(MI,'')+' '+LName+' '+isnull(Suffix,'') as PatName, InsuranceCompanies.CompanyName, DOA, "
        If ComboBoxProcedures.SelectedIndex > 0 Then
            SQL &= " (SELECT MAX(Schedule.ScheduleDateTime) FROM PatientProcedures  INNER JOIN Diagnostics ON PatientProcedures.DiagID = Diagnostics.DiagID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID WHERE (PatientProcedures.ProcedureStatusID = 2) AND ((Diagnostics.CountByVisitInd=1 and Procedures.ProcedureTypeID=0) or Diagnostics.CountByVisitInd=0)  AND PatientProcedures.PatientID = Patients.PatientID AND Diagnostics.DiagID= " & CType(ComboBoxProcedures.SelectedItem, ValueDescription).Value & IIf(DateTimePickerServicesFrom.Checked, " AND Schedule.ScheduleDateTime >='" & DateTimePickerServicesFrom.Value.Date & "'", "") & IIf(DateTimePickerServicesTo.Checked, "  AND Schedule.ScheduleDateTime <='" & DateAdd(DateInterval.Day, 1, DateTimePickerServicesTo.Value.Date) & "'", "") & ") as 'LatestVisit', "
        Else
            SQL &= " (SELECT MAX(Schedule.ScheduleDateTime) FROM PatientProcedures  INNER JOIN Diagnostics ON PatientProcedures.DiagID = Diagnostics.DiagID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID WHERE (PatientProcedures.ProcedureStatusID = 2) AND ((Diagnostics.CountByVisitInd=1 and Procedures.ProcedureTypeID=0) or Diagnostics.CountByVisitInd=0)  AND PatientProcedures.PatientID = Patients.PatientID) as 'LatestVisit', "
        End If

        Do Until Reader.Read = False
            SQL &= " (SELECT COUNT(*) FROM PatientProcedures INNER JOIN Diagnostics ON PatientProcedures.DiagID = Diagnostics.DiagID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID WHERE (PatientProcedures.ProcedureStatusID = 2) AND PatientProcedures.PatientID = Patients.PatientID AND ((Diagnostics.CountByVisitInd=1 and Procedures.ProcedureTypeID=0) or Diagnostics.CountByVisitInd=0)  AND Diagnostics.DiagID= " & Reader("DiagID").ToString & IIf(DateTimePickerServicesFrom.Checked, " AND Schedule.ScheduleDateTime >='" & DateTimePickerServicesFrom.Value.Date & "'", "") & IIf(DateTimePickerServicesTo.Checked, "  AND Schedule.ScheduleDateTime <='" & DateAdd(DateInterval.Day, 1, DateTimePickerServicesTo.Value.Date) & "'", "") & ") AS 'Col" & C & "', "
            C = C + 1
        Loop
        SQL = SQL.Left(Len(SQL) - 2)
        SQL &= " FROM Patients LEFT OUTER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID = InsuranceCompanies.CompanyID  Where Patients.OfficeID =2 and CaseStatusID=1 "

        ''''''''''''''   Status
        If ComboBoxProcedures.SelectedIndex > 0 Then
            If ComboBoxProcedureStatus.SelectedIndex = 1 Then
                SQL &= " AND (SELECT count(*) FROM PatientProcedures  INNER JOIN Diagnostics ON PatientProcedures.DiagID = Diagnostics.DiagID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID WHERE (PatientProcedures.ProcedureStatusID = 2)   AND Diagnostics.DiagID= " & CType(ComboBoxProcedures.SelectedItem, ValueDescription).Value & " AND ((Diagnostics.CountByVisitInd=1 and Procedures.ProcedureTypeID=0) or Diagnostics.CountByVisitInd=0)  AND PatientProcedures.PatientID = Patients.PatientID " & IIf(DateTimePickerServicesFrom.Checked, " AND Schedule.ScheduleDateTime >='" & DateTimePickerServicesFrom.Value.Date & "'", "") & IIf(DateTimePickerServicesTo.Checked, " AND Schedule.ScheduleDateTime <='" & DateAdd(DateInterval.Day, 1, DateTimePickerServicesTo.Value.Date) & "'", "") & ") > 0 "
            ElseIf ComboBoxProcedureStatus.SelectedIndex = 2 Then
                SQL &= " AND (SELECT count(*) FROM PatientProcedures  INNER JOIN Diagnostics ON PatientProcedures.DiagID = Diagnostics.DiagID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID WHERE (PatientProcedures.ProcedureStatusID = 2)   AND Diagnostics.DiagID= " & CType(ComboBoxProcedures.SelectedItem, ValueDescription).Value & " AND ((Diagnostics.CountByVisitInd=1 and Procedures.ProcedureTypeID=0) or Diagnostics.CountByVisitInd=0)  AND PatientProcedures.PatientID = Patients.PatientID " & IIf(DateTimePickerServicesFrom.Checked, " AND Schedule.ScheduleDateTime >='" & DateTimePickerServicesFrom.Value.Date & "'", "") & IIf(DateTimePickerServicesTo.Checked, "  AND Schedule.ScheduleDateTime <='" & DateAdd(DateInterval.Day, 1, DateTimePickerServicesTo.Value.Date) & "'", "") & ") = 0 "
            End If
        Else
            If ComboBoxProcedureStatus.SelectedIndex = 1 Then
                SQL &= " AND (SELECT count(*) FROM PatientProcedures  INNER JOIN Diagnostics ON PatientProcedures.DiagID = Diagnostics.DiagID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID WHERE (PatientProcedures.ProcedureStatusID = 2)  AND ((Diagnostics.CountByVisitInd=1 and Procedures.ProcedureTypeID=0) or Diagnostics.CountByVisitInd=0)  AND PatientProcedures.PatientID = Patients.PatientID " & IIf(DateTimePickerServicesFrom.Checked, " AND Schedule.ScheduleDateTime >='" & DateTimePickerServicesFrom.Value.Date & "'", "") & IIf(DateTimePickerServicesTo.Checked, "  AND Schedule.ScheduleDateTime <='" & DateAdd(DateInterval.Day, 1, DateTimePickerServicesTo.Value.Date) & "'", "") & ") > 0 "
            ElseIf ComboBoxProcedureStatus.SelectedIndex = 2 Then
                SQL &= " AND (SELECT count(*) FROM PatientProcedures  INNER JOIN Diagnostics ON PatientProcedures.DiagID = Diagnostics.DiagID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID WHERE (PatientProcedures.ProcedureStatusID = 2)  AND ((Diagnostics.CountByVisitInd=1 and Procedures.ProcedureTypeID=0) or Diagnostics.CountByVisitInd=0)  AND PatientProcedures.PatientID = Patients.PatientID " & IIf(DateTimePickerServicesFrom.Checked, " AND Schedule.ScheduleDateTime >='" & DateTimePickerServicesFrom.Value.Date & "'", "") & IIf(DateTimePickerServicesTo.Checked, "  AND Schedule.ScheduleDateTime <='" & DateAdd(DateInterval.Day, 1, DateTimePickerServicesTo.Value.Date) & "'", "") & ") = 0 "
            End If
        End If
        '''  Patient Name
        If TextBoxSearch.Text.Trim <> "" Then
            If IsNumeric(TextBoxSearch.Text) Then
                SQL &= " AND Patients.PatientID = " & Val(TextBoxSearch.Text.Trim) & " "
            Else
                PName = Split(TextBoxSearch.Text.Trim.ToSafeSQLString(), " ")
                Select Case PName.Length
                    Case 1
                        If PName(0).Trim = "*" Then PName(0) = ""
                        SQL &= " and (Patients.FName Like '" & PName(0).Trim & "%' or Patients.LName Like '" & PName(0) & "%') "
                    Case 2
                        SQL &= " and ("
                        SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.LName Like '" & PName(1).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.LName Like '" & PName(0).Trim & "%')"
                        SQL &= " ) "
                    Case 3
                        SQL &= " and ("
                        SQL &= " (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" & PName(1).Trim & "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" & PName(2).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" & PName(0).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(2).Trim & "%' and Patients.MI Like '" & PName(1).Trim & "%' and  Patients.LName Like '" & PName(0).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '" & PName(0).Trim & "%' and  Patients.LName Like '" & PName(2).Trim & "%') "
                        SQL &= " OR (Patients.FName Like '" & PName(0).Trim & "%' and Patients.MI Like '" & PName(2).Trim & "%' and  Patients.LName Like '" & PName(1).Trim & "%') "

                        SQL &= " ) "
                End Select
            End If
        End If
        SQL &= " ORDER BY PATNAME "
        ''''''''''''''
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        C = 6
        With FpSpread1.ActiveSheet
            .Rows.Count = 0
            Do Until Reader.Read = False
                R = R + 1
                Application.DoEvents()
                .Rows.Count = R
                .Cells(R - 1, 0).Text = Reader("PatientID").ToString
                .Cells(R - 1, 1).Text = Reader("PatName").ToString
                If IsDate(Reader("DOA").ToString) Then
                    .Cells(R - 1, 2).Text = CDate(Reader("DOA").ToString).ToShortDateString
                    .Cells(R - 1, 2).BackColor = Color.White
                Else
                    .Cells(R - 1, 2).Text = ""
                    .Cells(R - 1, 2).BackColor = Color.MistyRose
                End If
                .Cells(R - 1, 3).Text = Reader("CompanyName").ToString
                .Cells(R - 1, 4).Text = Reader("Contact").ToString
                If IsDate(Reader("LatestVisit").ToString) Then
                    .Cells(R - 1, 5).Text = CDate(Reader("LatestVisit").ToString).ToShortDateString
                    .Cells(R - 1, 5).BackColor = Color.White
                Else
                    .Cells(R - 1, 5).Text = ""
                    .Cells(R - 1, 5).BackColor = Color.MistyRose
                End If
                For C = 6 To Reader.FieldCount - 1
                    .Cells(R - 1, C).Text = Reader(C).ToString
                    If Val(Reader(C).ToString) = 0 Then
                        .Cells(R - 1, C).BackColor = Color.MistyRose
                    Else
                        .Cells(R - 1, C).BackColor = Color.White
                    End If
                Next
            Loop
            .Columns(0).SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None
            .Columns(1).SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.Ascending
            .Columns(2).SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None
            .Columns(3).SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None
        End With
        FpSpread1.ResumeLayout()
        Count_Selected()
    End Sub

    Private Sub ExportAllToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportAllToExcelToolStripMenuItem.Click
        Export_Listview()
    End Sub

    Private Sub PrintResultListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintResultListToolStripMenuItem.Click
        Print_Listview()
    End Sub

    Private Sub PrintCheckedSelectedNF23ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCheckedSelectedNF23ToolStripMenuItem.Click
        Try
            Application.DoEvents()
            If FpSpread1.ActiveSheet.ActiveRowIndex = -1 Then
                MsgBox("Unable to print Patient's information. No record selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim PatID(0) As Long
            PatID(0) = Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text)
            Cursor = Cursors.WaitCursor

            frmPatientInformationReport.Setup_report(PatID)
            Cursor = Cursors.Default
            frmPatientInformationReport.MinimizeBox = False
            frmPatientInformationReport.MaximizeBox = False

            frmPatientInformationReport.ShowDialog(Me)
            frmPatientInformationReport.Dispose()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Application.DoEvents()
        If FpSpread1.ActiveSheet.ActiveRowIndex = -1 Then
            MsgBox("Unable to open patient's information. No record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Using Frm As New frmPatient

            Frm.InitialTab = 0
            Frm.InitialPatientName = Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text)
            Cursor = Cursors.Default
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            Frm.ShowDialog(Me)
        End Using
        'Dim frm As Form = FormsCollection.FindForm("frmPatient")
        'If Not frm Is Nothing Then
        '    MsgBox("The Patient's information window is already opened." & vbCrLf & vbCrLf & "Please close the previous patient information window before opening a new one.", MsgBoxStyle.Exclamation)
        '    If frm.WindowState = FormWindowState.Minimized Then frm.WindowState = FormWindowState.Normal
        '    frm.BringToFront()
        '    Cursor = Cursors.Default
        '    Exit Sub
        'Else
        '    frmPatient.InitialTab = 0
        '    frmPatient.InitialPatientName = Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text)
        '    Cursor = Cursors.Default
        '    frmPatient.ShowDialog(Me)
        'End If
    End Sub

    Private Sub FpSpread1_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread1.CellDoubleClick
        ToolStripMenuItem2_Click(Nothing, Nothing)
    End Sub

    Private Sub FpSpread1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpread1.DoubleClick

    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Export_Listview()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Print_Listview()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        ToolStripMenuItem2_Click(Nothing, Nothing)
    End Sub

    Private Sub PrintPatientScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPatientScheduleToolStripMenuItem.Click
        Application.DoEvents()
        If FpSpread1.ActiveSheet.ActiveRowIndex = -1 Then
            MsgBox("Unable to print Patient's schedule. No record selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        frmReportSchedule.ByPatient = True
        frmReportSchedule.ScheduleDate = Nothing
        frmReportSchedule.CheckBox1.Visible = True
        frmReportSchedule.PatientID = Val(FpSpread1.ActiveSheet.Cells(FpSpread1.ActiveSheet.ActiveRowIndex, 0).Text)
        frmReportSchedule.MinimizeBox = False
        frmReportSchedule.MaximizeBox = False

        frmReportSchedule.ShowDialog(Me)
        frmReportSchedule.Dispose()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        PrintCheckedSelectedNF23ToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        PrintPatientScheduleToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Load_Data()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim i As Integer
        With FpSpread1.ActiveSheet
            .ColumnHeader.Columns(0).Width = 40
            .ColumnHeader.Columns(1).Width = 200
            .ColumnHeader.Columns(2).Width = 70
            .ColumnHeader.Columns(3).Width = 200
            .ColumnHeader.Columns(4).Width = 70
            For i = 5 To .Columns.Count - 1
                .ColumnHeader.Columns(i).Width = 30
            Next
        End With
    End Sub

    Private Sub ComboBoxProcedures_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxProcedures.SelectedIndexChanged
        Format_Spread()
    End Sub

    Private Sub ComboBoxProcedureStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxProcedureStatus.SelectedIndexChanged
        'If ComboBoxProcedureStatus.SelectedIndex > 0 Then
        '    DateTimePickerServicesFrom.Enabled = False
        '    DateTimePickerServicesTo.Enabled = False
        '    DateTimePickerServicesFrom.Checked = False
        '    DateTimePickerServicesTo.Checked = False
        'Else
        '    DateTimePickerServicesFrom.Enabled = True
        '    DateTimePickerServicesTo.Enabled = True
        'End If
    End Sub

    Private Sub FpSpread1_CellClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread1.CellClick

    End Sub

End Class