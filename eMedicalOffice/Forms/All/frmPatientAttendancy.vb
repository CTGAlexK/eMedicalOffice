Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmPatientAttendancy
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private m_SortingColumn As ColumnHeader
    Private Loading As Boolean

    Private Sub Print_Listview(Optional ByVal All As Boolean = True, Optional ByVal Quik As Boolean = False)
        Dim CH As ColumnHeader = Nothing
        Dim LI As ListViewItem
        Dim I As Integer
        Dim C As Integer
        Dim C1
        Dim ColumnsCount As Integer = ListViewPatients.Columns.Count - 1
        If Quik Then
            ColumnsCount = 5
        End If
        FpSpreadForPrint.SuspendAnimations = True
        FpSpreadForPrint.SuspendLayout()
        'ListViewPatients.UseCompatibleStateImageBehavior = False
        'ListViewPatients.View = System.Windows.Forms.View.List

        If ListViewPatients.Items.Count = 0 Then
            MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        FpSpreadForPrint.ActiveSheet.ColumnCount = ColumnsCount + 1
        For C = 0 To ColumnsCount
            For C1 = 0 To ColumnsCount
                If ListViewPatients.Columns(C1).DisplayIndex = C Then
                    CH = ListViewPatients.Columns(C1)
                    Exit For
                End If
            Next
            I += 1
            'FpSpreadForPrint.ActiveSheet.Columns(I - 1).CellType = CT
            'FpSpreadForPrint.ActiveSheet.ColumnHeader.Rows(0).Height = 32
            Select Case CH.TextAlign
                Case HorizontalAlignment.Left
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                Case HorizontalAlignment.Right
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                Case HorizontalAlignment.Center
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            End Select
            FpSpreadForPrint.ActiveSheet.Columns(I - 1).Tag = CH.Index
            'FpSpreadForPrint.ActiveSheet.Columns(I - 1).Width = CH.Width
            Select Case CH.Text
                Case "Patient #"
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).Label = "##"
                Case "Amt $"
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).Label = "Amt"
                Case "Paid Amt $"
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).Label = "Paid"
                Case "Balance $"
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).Label = "Balance"
                Case "Status"
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).Label = "Stat"
                Case Else
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).Label = CH.Text
            End Select

        Next
        I = 0
        FpSpreadForPrint.ActiveSheet.RowCount = 0
        For Each LI In ListViewPatients.Items
            If All = True Or LI.Checked = True Then
                I += 1
                FpSpreadForPrint.ActiveSheet.RowCount = I
                For C = 0 To FpSpreadForPrint.ActiveSheet.ColumnCount - 1
                    FpSpreadForPrint.ActiveSheet.SetText(I - 1, C, LI.SubItems(FpSpreadForPrint.ActiveSheet.Columns(C).Tag).Text)
                Next
                Application.DoEvents()
            End If
        Next
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        Printinfo.Printer = gPrinterOtherDocuments
        Dim PS As New System.Drawing.Printing.PaperSize("Letter", 850, 1100)
        Printinfo.PaperSize = PS
        Printinfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape

        Printinfo.Header = "/fb PATIENT STATISTICS SEARCH RESULT AS OF " & Now & vbCrLf & vbCrLf
        Printinfo.Footer = "/rPage /p of /pc"
        Printinfo.ShowShadows = False
        Printinfo.JobName = "eMedical Office Billing Management"
        Printinfo.PrintType = FarPoint.Win.Spread.PrintType.All
        Printinfo.ShowColor = False
        Printinfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Show
        Printinfo.ShowBorder = False
        Printinfo.ShowGrid = True
        Printinfo.ShowPrintDialog = True
        Printinfo.Preview = False
        If Quik = False Then
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
        End If
        FpSpreadForPrint.ActiveSheet.PrintInfo = Printinfo
        'FpSpreadForPrint.PrintSheet(FpSpreadForPrint.ActiveSheet)
        FpSpreadForPrint.SafePrint(FpSpreadForPrint, 0)
    End Sub

    Private Sub Fax_Listview(Optional ByVal All As Boolean = True)
        Dim CH As ColumnHeader = Nothing
        Dim LI As ListViewItem
        Dim I As Integer
        Dim C As Integer
        Dim C1
        Dim strFileName As String
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Application.DoEvents()

        If All = False Then
            If ListViewPatients.CheckedItems.Count = 0 Then
                MsgBox("Unable to process your request. No records checked.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Else
            If ListViewPatients.Items.Count = 0 Then
                MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        Subject = "Message From " & gOfficeName & " / Patients Search Result Report / Attached: Report XLS File"
        Fname = System.IO.Path.GetTempPath & "\PatientsSearchResult " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".xls"
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

        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        FpSpreadForPrint.SuspendLayout()
        FpSpreadForPrint.ActiveSheet.RowCount = 0
        FpSpreadForPrint.ActiveSheet.RowCount = 1
        FpSpreadForPrint.ActiveSheet.ColumnCount = ListViewPatients.Columns.Count
        For C = 0 To ListViewPatients.Columns.Count - 1
            For C1 = 0 To ListViewPatients.Columns.Count - 1
                If ListViewPatients.Columns(C1).DisplayIndex = C Then
                    CH = ListViewPatients.Columns(C1)
                    Exit For
                End If
            Next
            I += 1
            FpSpreadForPrint.ActiveSheet.ColumnHeader.Rows(0).Height = 32
            Select Case CH.TextAlign
                Case HorizontalAlignment.Left
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                Case HorizontalAlignment.Right
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                Case HorizontalAlignment.Center
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            End Select
            FpSpreadForPrint.ActiveSheet.Columns(I - 1).Tag = CH.Index
            FpSpreadForPrint.ActiveSheet.Columns(I - 1).Width = CH.Width
            FpSpreadForPrint.ActiveSheet.Columns(I - 1).Locked = False
            FpSpreadForPrint.ActiveSheet.SetText(0, I - 1, CH.Text)
        Next
        I = 1

        For Each LI In ListViewPatients.Items
            If All = True Or LI.Checked = True Then
                I += 1
                FpSpreadForPrint.ActiveSheet.RowCount = I
                For C = 0 To FpSpreadForPrint.ActiveSheet.ColumnCount - 1
                    FpSpreadForPrint.ActiveSheet.SetText(I - 1, C, LI.SubItems(FpSpreadForPrint.ActiveSheet.Columns(C).Tag).Text.ToString)
                    FpSpreadForPrint.ActiveSheet.Cells(I - 1, C).BackColor = LI.SubItems(FpSpreadForPrint.ActiveSheet.Columns(C).Tag).BackColor
                    FpSpreadForPrint.ActiveSheet.Cells(I - 1, C).ForeColor = LI.SubItems(FpSpreadForPrint.ActiveSheet.Columns(C).Tag).forecolor
                Next
            End If
        Next
        FpSpreadForPrint.ResumeLayout()
        FpSpreadForPrint.ActiveSheet.Protect = False
        Try
            FpSpreadForPrint.SaveExcel(Fname)

            gFax(Me, "", Subject, Fname.ToString, gOfficeFax)
        Catch ex As Exception
            MsgBox("Unable to email report. The file may be in use by another application or drive is full or write protected.", MsgBoxStyle.Critical)
        End Try
        FpSpreadForPrint.ActiveSheet.RowCount = 0
        FpSpreadForPrint.ResumeLayout()

        Cursor = Cursors.Default
    End Sub

    Private Sub Export_Listview(Optional ByVal All As Boolean = True)
        Dim CH As ColumnHeader = Nothing
        Dim LI As ListViewItem
        Dim I As Integer
        Dim C As Integer
        Dim C1
        Dim strFileName As String
        Application.DoEvents()

        If All = False Then
            If ListViewPatients.CheckedItems.Count = 0 Then
                MsgBox("Unable to process your request. No records checked.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Else
            If ListViewPatients.Items.Count = 0 Then
                MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        SaveFD.Title = "Export Billing To Excel."
        SaveFD.Filter = "MS Excel File (*.xls)|*.xls"
        Dim DidWork As Integer = SaveFD.ShowDialog()
        If DidWork = DialogResult.OK Then
            strFileName = SaveFD.FileName
        Else
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        FpSpreadForPrint.SuspendLayout()
        FpSpreadForPrint.ActiveSheet.RowCount = 0
        FpSpreadForPrint.ActiveSheet.RowCount = 1
        FpSpreadForPrint.ActiveSheet.ColumnCount = ListViewPatients.Columns.Count
        For C = 0 To ListViewPatients.Columns.Count - 1
            For C1 = 0 To ListViewPatients.Columns.Count - 1
                If ListViewPatients.Columns(C1).DisplayIndex = C Then
                    CH = ListViewPatients.Columns(C1)
                    Exit For
                End If
            Next
            I += 1
            FpSpreadForPrint.ActiveSheet.ColumnHeader.Rows(0).Height = 32
            Select Case CH.TextAlign
                Case HorizontalAlignment.Left
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                Case HorizontalAlignment.Right
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                Case HorizontalAlignment.Center
                    FpSpreadForPrint.ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            End Select
            FpSpreadForPrint.ActiveSheet.Columns(I - 1).Tag = CH.Index
            FpSpreadForPrint.ActiveSheet.Columns(I - 1).Width = CH.Width
            FpSpreadForPrint.ActiveSheet.Columns(I - 1).Locked = False
            FpSpreadForPrint.ActiveSheet.SetText(0, I - 1, CH.Text)
        Next
        I = 1

        For Each LI In ListViewPatients.Items
            If All = True Or LI.Checked = True Then
                I += 1
                FpSpreadForPrint.ActiveSheet.RowCount = I
                For C = 0 To FpSpreadForPrint.ActiveSheet.ColumnCount - 1
                    FpSpreadForPrint.ActiveSheet.SetText(I - 1, C, LI.SubItems(FpSpreadForPrint.ActiveSheet.Columns(C).Tag).Text.ToString)
                    FpSpreadForPrint.ActiveSheet.Cells(I - 1, C).BackColor = LI.SubItems(FpSpreadForPrint.ActiveSheet.Columns(C).Tag).BackColor
                    FpSpreadForPrint.ActiveSheet.Cells(I - 1, C).ForeColor = LI.SubItems(FpSpreadForPrint.ActiveSheet.Columns(C).Tag).forecolor
                Next
            End If
        Next
        FpSpreadForPrint.ResumeLayout()
        FpSpreadForPrint.ActiveSheet.Protect = False
        Try
            FpSpreadForPrint.SaveExcel(strFileName)
        Catch ex As Exception
            MsgBox("Unable to save file. the file may be in use by another application or drive is full or write protected.", MsgBoxStyle.Critical)
        End Try
        FpSpreadForPrint.ActiveSheet.RowCount = 0
        FpSpreadForPrint.ResumeLayout()
        SaveFD.Reset()
        System.Diagnostics.Process.Start(strFileName)
        Cursor = Cursors.Default
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub RestoreColumnWidthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gListViewRestoreDefaultColumnWidth(ListViewPatients)
    End Sub

    Private Sub ExportAllToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportAllToExcelToolStripMenuItem.Click
        Export_Listview()
    End Sub

    Private Sub ExportCheckedToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportCheckedToExcelToolStripMenuItem.Click
        Export_Listview(True)
    End Sub

    Private Sub mnuPrintAll1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintAll1.Click
        PanelWait.Visible = True
        Application.DoEvents()
        Try
            Print_Listview(True)
        Catch ex As Exception

        End Try
        PanelWait.Visible = False
    End Sub

    Private Sub mnuPrintCheckedOnly1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintCheckedOnly1.Click
        PanelWait.Visible = True
        Application.DoEvents()
        Try
            Print_Listview(False)
        Catch ex As Exception

        End Try
        PanelWait.Visible = False
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim LI As ListViewItem
        CheckUncheck = True
        ListViewPatients.BeginUpdate()
        For Each LI In ListViewPatients.Items
            LI.Checked = True
        Next
        ListViewPatients.EndUpdate()
        CheckUncheck = False
        Count_Selected()
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNoneToolStripMenuItem.Click
        Dim LI As ListViewItem
        CheckUncheck = True
        ListViewPatients.BeginUpdate()
        For Each LI In ListViewPatients.Items
            LI.Checked = False
        Next
        ListViewPatients.EndUpdate()
        CheckUncheck = False
        Count_Selected()
    End Sub

    Private Sub mnuShowSelectedPatientInfo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowSelectedPatientInfo1.Click
        Dim LI As ListViewItem
        Dim SaveIndex As Integer
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No Patient selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        Using Frm As New frmPatient

            Cursor = Cursors.WaitCursor
            Application.DoEvents()
            SaveIndex = LI.Index
            Frm.InitialTab = 0
            Frm.InitialPatientName = LI.Text
            Frm.MinimizeBox = False
            Frm.MaximizeBox = False
            If Frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ListViewPatients.SuspendLayout()
                Find_Patients()
                ListViewPatients.Items(SaveIndex).Selected = True
                ListViewPatients.Items(SaveIndex).EnsureVisible()
                ListViewPatients.ResumeLayout()
            End If
        End Using
        Cursor = Cursors.Default

        'Dim frm As Form = FormsCollection.FindForm("frmPatient")
        'If Not frm Is Nothing Then
        '    MsgBox("The Patient's information window is already opened." & vbCrLf & vbCrLf & "Please close the previous patient information window before opening a new one.", MsgBoxStyle.Exclamation)
        '    frm.WindowState = FormWindowState.Normal
        '    frm.BringToFront()
        '    Exit Sub
        'Else
        '    Cursor = Cursors.WaitCursor
        '    Application.DoEvents()
        '    SaveIndex = LI.Index
        '    frmPatient.InitialTab = 0
        '    frmPatient.InitialPatientName = LI.Text
        '    If frmPatient.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '        ListViewPatients.SuspendLayout()
        '        Find_Patients()
        '        ListViewPatients.Items(SaveIndex).Selected = True
        '        ListViewPatients.Items(SaveIndex).EnsureVisible()
        '        ListViewPatients.ResumeLayout()
        '    End If
        '    Cursor = Cursors.Default
        'End If
    End Sub

    Private Sub mnuPrinting1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrinting1.Click
        Try
            Dim ID As Long
            Dim PAtID() As Long
            Dim I As Integer
            If ListViewPatients.SelectedItems.Count = 0 And ListViewPatients.CheckedItems.Count = 0 Then
                MsgBox("Unable to print the Patient's information. No patient checked / selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim LI As ListViewItem
            If ListViewPatients.CheckedItems.Count = 0 Then
                ReDim Preserve PAtID(0)
                PAtID(I) = ListViewPatients.SelectedItems(0).Tag
            Else
                For Each LI In ListViewPatients.CheckedItems
                    ReDim Preserve PAtID(I)
                    PAtID(I) = LI.Tag
                    I = I + 1
                Next
            End If

            ID = ListViewPatients.SelectedItems(0).Tag
            Cursor = Cursors.WaitCursor

            frmPatientInformationReport.Setup_report(PAtID)
            Cursor = Cursors.Default
            frmPatientInformationReport.ShowDialog(Me)
            frmPatientInformationReport.Dispose()
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private CheckUncheck As Boolean

    Private Sub frmPatient_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gListview_Settings(Me, ListViewPatients, ReadWrite.sWrite)
        gWindow_Settings(Me, ReadWrite.sWrite)

        MDIForm1Win8.TimerRefresh_Tick(Nothing, Nothing)
    End Sub

    Private Sub frmPatient_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            ButtonFind_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub SetFont(Optional incr As Integer = 0)
        Dim BaseSize = 8
        If BaseSize + My.Settings.FontSize + incr < 8 Or BaseSize + My.Settings.FontSize + incr > 15 Then Return
        My.Settings.FontSize = My.Settings.FontSize + incr
        My.Settings.Save()
        Dim F = New Font(Font.FontFamily, BaseSize + My.Settings.FontSize, FontStyle.Regular)

        ListViewPatients.Font = F
        ListViewSchedule.Font = F
        ListViewProcedures.Font = F
        ListViewServices.Font = F
        TreeViewBills.Font = F
        ListViewRequests.Font = F
    End Sub

    Private Sub frmPatient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        If gCurrentEmployee.PositionID > 3 Then ToolStrip2.ContextMenuStrip = Nothing
        gToolStripSettings(Me, ToolStrip2, ReadWrite.sRead)
        'Me.Location = New Point((MDIForm1Win8.Width - Width) / 2, (MDIForm1Win8.Height - Height) / 2)
        Me.Location = New Point(0, 0)
        gWindow_Settings(Me, ReadWrite.sRead)
        Application.DoEvents()
        Me.Refresh()
        Loading = True
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Application.DoEvents()
        m_SortingColumn = ListViewPatients.Columns(1)
        gListview_Settings(Me, ListViewPatients, ReadWrite.sRead)
        Count_Selected()
        Loading = False

        If gOfficeTypeID = 1 Or gOfficeTypeID = 3 Then
            ButtonDetails.Parent = Panel3
            TableLayoutPanel1.RowStyles(0).SizeType = SizeType.Absolute
            TableLayoutPanel1.RowStyles(0).Height = 0
            TableLayoutPanel1.RowStyles(2).SizeType = SizeType.Absolute
            TableLayoutPanel1.RowStyles(2).Height = 0
            ToolStripSeparator4.Visible = False
        End If
        If gCurrentEmployee.PositionID = 4 Or gCurrentEmployee.PositionID = 10 Then ' FronDesk / Tec
            TableLayoutPanel1.RowStyles(3).SizeType = SizeType.Absolute
            TableLayoutPanel1.RowStyles(3).Height = 0
        End If
        SetFont()

    End Sub

    Private Sub Load_Attorney_AutoComplete()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String = ""
        Dim AutocompletePatientAttorney As New AutoCompleteStringCollection()
        SQL = "SELECT DISTINCT Attorney FROM Patients WHERE OfficeID = " & gOfficeID & " AND (LEN(Attorney) > 10) ORDER BY Attorney"
        Reader = gSQLGetDataReader(SQL)
        Do Until Reader.Read = False
            AutocompletePatientAttorney.Add(Reader("Attorney").ToString.Trim)
            Application.DoEvents()
        Loop
        txtPatientAttorney.AutoCompleteCustomSource = AutocompletePatientAttorney
        Reader.Close()
        Reader = Nothing
    End Sub

    Private Sub Count_Selected()
        Dim T As Double
        Dim Tc As Double
        Dim I As Integer
        Dim P As Double
        Dim PC As Double
        If CheckUncheck Then Exit Sub
        ToolStripStatusLabelFound.Text = " Found: " & ListViewPatients.Items.Count & "   "
        ToolStripStatusLabelChecked.Text = " Checked: " & ListViewPatients.CheckedItems.Count & "   "
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim cmbocell As New FarPoint.Win.Spread.CellType.ComboBoxCellType
        Dim ComboText As String() = {""}
        Dim ComboValue As String() = {""}
        Dim Items() As String = {""}
        Dim I As Integer = 0
        Dim SQL As String
        ComboBoxSearchCaseStatus.Items.Clear()
        Reader = gSQLGetDataReader("SELECT CaseStatusID, Description FROM CaseStatuses Order By ShowOrder")
        If Reader Is Nothing Then Exit Sub
        ComboBoxSearchCaseStatus.Items.Add(New ValueDescription(0, "All Statuses"))
        Do Until Reader.Read = False
            ComboBoxSearchCaseStatus.Items.Add(New ValueDescription(CLng(Val(Reader("CaseStatusID").ToString)), Reader("Description").ToString))
        Loop

        Reader.Close() : Reader.Dispose()

        ComboBoxSearchCaseType.Items.Clear()
        ComboBoxSearchCaseType.Items.Add(New ValueDescription(0, "All Types"))
        Reader = gSQLGetDataReader("Select CaseTypeID, Description from CaseTypes Where CaseTypeID = 1 or CaseTypeID = 2  or CaseTypeID = 5 ")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            ComboBoxSearchCaseType.Items.Add(New ValueDescription(CLng(Val(Reader("CaseTypeID").ToString)), Reader("Description").ToString))
        Loop
        Reader.Close() : Reader.Dispose()

        SQL = "SELECT     Diagnostics.DiagID, Diagnostics.DiagName+' / ' +OTCompanies.CompanyName as Diag FROM Diagnostics INNER JOIN OTCompanies ON Diagnostics.OTCompanyID = OTCompanies.CompanyID WHERE Diagnostics.OfficeID = " & gOfficeID & " ORDER BY OTCompanies.CompanyName, Diagnostics.DiagName "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ComboBoxFilter.Items.Clear()
        ComboBoxFilter.Items.Add(New ValueDescription(0, "All Patients"))
        ComboBoxFilter.Items.Add(New ValueDescription(9999, "---------------------------------------------------------------------------------------------------------------------"))
        ComboBoxFilter.Items.Add(New ValueDescription(-1, "Completed Procedures"))
        ComboBoxFilter.Items.Add(New ValueDescription(-2, "No Procedures"))
        If gOfficeTypeID = 2 Then
            ComboBoxFilter.Items.Add(New ValueDescription(9999, "---------------------------------------------------------------------------------------------------------------------"))
            ComboBoxFilter.Items.Add(New ValueDescription(-5, "NF2 Printed"))
            ComboBoxFilter.Items.Add(New ValueDescription(-6, "NF2 Not Printed"))
        End If
        ComboBoxFilter.Items.Add(New ValueDescription(9999, "---------------------------------------------------------------------------------------------------------------------"))
        ComboBoxFilter.Items.Add(New ValueDescription(-7, "Billed"))
        ComboBoxFilter.Items.Add(New ValueDescription(-8, "Not Billed"))
        If gOfficeTypeID = 2 Then
            ComboBoxFilter.Items.Add(New ValueDescription(9999, "---------------------------------------------------------------------------------------------------------------------"))
            ComboBoxFilter.Items.Add(New ValueDescription(-3, "Outsource Services"))
            ComboBoxFilter.Items.Add(New ValueDescription(-4, "No Outsource Services"))

            ComboBoxFilter.Items.Add(New ValueDescription(9999, "-------------------------------------------OUTSOURCE SERVICES-------------------------------------------"))

            Do Until Reader.Read = False
                ComboBoxFilter.Items.Add(New ValueDescription(Reader("DiagID").ToString, Reader("Diag").ToString))
            Loop
            Reader.Close() : Reader.Dispose()
        End If
        cboBillingProvider.Items.Clear()
        cboBillingProvider.Items.Add(New ValueDescription("0", "All"))
        Reader = gSQLGetDataReader("SELECT     EmpID, Fname+' '+Lname+' '+ Alias as DName From Employees WHERE (BillingPrv = 1) and EmpID in (select EmpID from EmployeeOffice where OfficeID=" & gOfficeID & ")")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboBillingProvider.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("DName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()

        cboTreatingProvider.Items.Clear()
        cboTreatingProvider.Items.Add(New ValueDescription("0", "All"))
        Reader = gSQLGetDataReader("SELECT     EmpID, Fname+' '+Lname+' '+ Alias as DName From Employees WHERE (TreatmentPrv = 1) and EmpID in (select EmpID from EmployeeOffice where OfficeID=" & gOfficeID & ")")
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            cboTreatingProvider.Items.Add(New ValueDescription(CLng(Val(Reader("EmpID").ToString)), Reader("DName").ToString))
        Loop
        Reader.Close() : Reader.Dispose()

        Load_InsuranceCompanies()
        cboTreatingProvider.SelectedIndex = 0
        ComboBoxFilter.SelectedIndex = 0
        cboBillingProvider.SelectedIndex = 0
        ComboBoxSearchCaseStatus.SelectedIndex = 0
        ComboBoxSearchCaseType.SelectedIndex = 0

    End Sub

    Private Sub Load_InsuranceCompanies()
        ComboBoxFilter.Items.Add(New ValueDescription(9999, "-------------------------------------------INSURANCE GROUPS-------------------------------------------"))
        ComboBoxFilter.SelectedIndex = 0
        ComboBoxFilter.DropDownHeight = 406
        Dim Reader As SqlClient.SqlDataReader
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Reader = gSQLGetDataReader("SELECT DISTINCT  GroupID, Description FROM InsuranceCompaniesGroups ORDER BY Description")
        If Reader Is Nothing Then GoTo ExitSub
        Do Until Reader.Read = False
            ComboBoxFilter.Items.Add(New ValueDescription(CLng(Val(Reader("GroupID").ToString)), Reader("Description").ToString & " - Group", "0"))
        Loop
        If ComboBoxFilter.Items.Count > 0 Then
            ComboBoxFilter.Items.Add(New ValueDescription(9999, "----------------------------------------INSURANCE COMPANIES----------------------------------------"))
        End If
        Reader = gSQLGetDataReader("Select CompanyID, CompanyName from InsuranceCompanies ORDER BY CompanyName")
        If Reader Is Nothing Then GoTo ExitSub
        Do Until Reader.Read = False
            ComboBoxFilter.Items.Add(New ValueDescription(CLng(Val(Reader("CompanyID").ToString)), Reader("CompanyName").ToString, "1"))
        Loop
        If ComboBoxFilter.Items.Count = 0 Then
            ComboBoxFilter.DropDownHeight = 20
        End If
        Reader.Close() : Reader.Dispose()
ExitSub:
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        txtPACSAltNumber.Text = ""
        TextBoxSearch.Text = ""
        txtBillNumber.Text = ""
        ComboBoxFilter.SelectedIndex = 0
        txtPatientAttorney.Text = ""
        ComboBoxSearchCaseStatus.SelectedIndex = 0
        ComboBoxSearchCaseType.SelectedIndex = 0
        cboTreatingProvider.SelectedIndex = 0
        cboBillingProvider.SelectedIndex = 0
        DateTimePickerDOAFrom.Checked = False
        DateTimePickerDOATo.Checked = False
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        DateTimePickerServicesFrom.Checked = False
        DateTimePickerServicesTo.Checked = False
    End Sub

    Private Sub ListViewPatients_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewPatients.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewPatients.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumn.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumn.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumn.Text =             m_SortingColumn.Text.Mid(2)
            m_SortingColumn.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumn.Text = "> " & m_SortingColumn.Text
        'Else
        'm_SortingColumn.Text = "< " & m_SortingColumn.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.ImageKey = "SORT1"
        Else
            m_SortingColumn.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListViewPatients.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewPatients.Sort()
    End Sub

    Private Sub ListViewPatients_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles ListViewPatients.ColumnWidthChanged
        If ListViewPatients.Columns(e.ColumnIndex).Width < 60 Then
            ListViewPatients.Columns(e.ColumnIndex).Width = 60
        End If
    End Sub

    Private Sub ListViewPatients_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPatients.DoubleClick
        mnuShowSelectedPatientInfo1_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewPatients_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListViewPatients.ItemChecked
        If Loading Then Exit Sub

        Count_Selected()
    End Sub

    Private Sub ListViewPatients_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewPatients.MouseDown
        Application.DoEvents()
        Dim HI As ListViewHitTestInfo
        HI = ListViewPatients.HitTest(e.X, e.Y)

        If Not HI.Item Is Nothing Then
            HI.Item.Selected = True
            HI.Item.EnsureVisible()
        End If
    End Sub

    Private Sub ListViewPatients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewPatients.SelectedIndexChanged

        'gHighlightListviewItem(ListViewPatients, False, True)
        If PanelDetails.Visible Then
            PanelDetails.SuspendLayout()
            Load_PatientProcedures()
            If gOfficeTypeID = 2 Then Load_PatientServices()
            If gOfficeTypeID = 2 Then Load_PatientSchedule()
            If gCurrentEmployee.PositionID <> 4 And gCurrentEmployee.PositionID <> 10 Then ' FronDesk / Tec
                Load_Patient_Bills()
            End If
            Load_Requests()
            Load_RelatedPatients()
            PanelDetails.ResumeLayout()
        End If
    End Sub

    Private Sub Load_PatientSchedule()
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim SaverequestID As Long
        ListViewRequests.Items.Clear()
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        ListViewSchedule.Items.Clear()

        SQL = "SELECT     SchedulePT.ID, SchedulePT.ScheduleDate, SchedulePT.ConfirmedBy, Diagnostics.DiagName FROM SchedulePT INNER JOIN Diagnostics ON SchedulePT.DiagID = Diagnostics.DiagID  Where PatientID = " & Val(ListViewPatients.SelectedItems(0).Text) & "ORDER BY SchedulePT.ScheduleDate DESC"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False

            If IsDate(Reader("ScheduleDate").ToString) Then
                LI = ListViewSchedule.Items.Add(CDate(Reader("ScheduleDate").ToString).ToString("MM/dd/yy"))
            Else
                LI.SubItems.Add("")
            End If
            LI.Tag = Reader("ID").ToString
            LI.SubItems.Add(Reader("DiagName").ToString)
            If Val(Reader("ConfirmedBy").ToString) Then
                LI.BackColor = Color.LightGreen
            End If

            If CDate(Reader("ScheduleDate").ToString) < Now Then
                LI.ForeColor = Color.Gray
            End If
        Loop

    End Sub

    Private Sub Load_Requests()
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim SaverequestID As Long
        ListViewRequests.Items.Clear()
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        ListViewRequests.Items.Clear()
        SQL = "SELECT BillID, BillingRequests.RequestStatusID,   BillingRequests.RequestID, BillingRequests.RequestDate, BillingRequestStatuses.Description AS Status, BillingRequestStatuses.StatusID, BillingRequests.RequestDescription FROM BillingRequests INNER JOIN BillingRequestStatuses ON BillingRequests.RequestStatusID = BillingRequestStatuses.StatusID  Where PatientID = " & Val(ListViewPatients.SelectedItems(0).Text) & " order by RequestDate desc"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False

            LI = ListViewRequests.Items.Add(Reader("BillID").ToString)
            If IsDate(Reader("RequestDate").ToString) Then
                LI.SubItems.Add(CDate(Reader("RequestDate").ToString).ToString("MM/dd/yy"))
            Else
                LI.SubItems.Add("")
            End If
            LI.Tag = Reader("RequestID").ToString
            LI.SubItems.Add(Reader("Status").ToString)
            LI.SubItems.Add(Reader("RequestDescription").ToString)
            LI.ToolTipText = Reader("RequestDescription").ToString
            If Val(Reader("RequestStatusID").ToString) < 3 Then
                If DateDiff(DateInterval.Day, CDate(Reader("RequestDate").ToString), Now) > 3 Then
                    LI.ForeColor = Color.Red
                    LI.SubItems(1).Text = LI.SubItems(1).Text & " " & DateDiff(DateInterval.Day, CDate(Reader("RequestDate").ToString), Now)
                End If
            End If
        Loop
    End Sub

    Private Sub Load_Patient_Bills()
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String = ""
        Dim ParentNode As TreeNode = Nothing
        Dim ChildNode As TreeNode = Nothing
        Dim DiagNode As TreeNode = Nothing
        Dim Icn As String = ""
        Dim SaveBillID As Long = 0
        Dim SaveProcedureID As Long = 0
        Dim BS As String
        TreeViewBills.Nodes.Clear()
        If ListViewPatients.SelectedItems.Count = 0 Then Exit Sub
        SQL = "SELECT  Bills.CaseTypeID,  BillProcedures.PatientProcedureID,    Bills.CopyFromBillID, Bills.SplitBillID, Bills.BillDate, BillProcedures.BillID, Bills.BillAmount, Bills.BillStatusID, BillStatus.Description AS BillStatus,  BillDiagnosis.ICDCode, BillDiagnosis.ICDDescription, BillProcedures.ProcName "
        SQL &= " FROM            Bills INNER JOIN BillProcedures ON Bills.BillID = BillProcedures.BillID LEFT OUTER JOIN BillStatus ON Bills.BillStatusID = BillStatus.BillStatusID LEFT OUTER JOIN BillDiagnosis ON BillProcedures.BillID = BillDiagnosis.BillID  "
        SQL &= " WHERE Bills.PatientID = " & Val(ListViewPatients.SelectedItems(0).Text)
        SQL &= " ORDER BY Bills.BillID "

        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        TreeViewBills.Nodes.Clear()
        Do Until Reader.Read = False
            If SaveBillID <> Reader("BillID").ToString Then
                SaveBillID = Reader("BillID").ToString
                SaveProcedureID = 0
                Icn = Reader("BillStatusID").ToString
                BS = Reader("BillStatus").ToString
                If InStr(BS, "Attorney") Then
                    BS = "Attorney"
                End If
                If IsNumeric(Reader("CopyFromBillID").ToString) Then
                    Icn = Icn & "1"
                End If
                ParentNode = TreeViewBills.Nodes.Add("K" & Reader("BillID").ToString, Reader("BillID").ToString & "      " & CDate(Reader("BillDate")).ToString("MM/dd/yyyy") & "      " & CDbl(Reader("BillAmount")).ToString("c") & "      " & BS, Icn, Icn)
                ParentNode.Checked = True
                If Val(Reader("SplitBillID").ToString) > 0 Then
                    ParentNode.ForeColor = Color.BlueViolet
                End If
                ParentNode.Tag = New ValueDescription(Reader("BillID").ToString, "", Val(Reader("SplitBillID").ToString), Val(Reader("CaseTypeID").ToString))
                ParentNode.ToolTipText = "Bill Status: " & Reader("BillStatus").ToString
            End If
            If SaveProcedureID <> Reader("PatientProcedureID").ToString Then
                SaveProcedureID = Reader("PatientProcedureID").ToString
                ChildNode = ParentNode.Nodes.Add("", Reader("ProcName").ToString, "PROC", "PROC")
                ChildNode.Tag = Reader("PatientProcedureID").ToString
                TreeNode_SetStateImageIndex(ChildNode, 0)
            End If
        Loop
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub Load_PatientProcedures()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        Dim SI As ListViewItem.ListViewSubItem
        ListViewProcedures.Items.Clear()
        If ListViewPatients.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        SQL = "SELECT     PatientProcedures.PatientID, Procedures.ProcName, BillProcedures.BillID, PatientProcedures.PatientProcedureID, Schedule.ScheduleDateTime, Diagnostics.DiagName FROM PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Diagnostics ON PatientProcedures.DiagID = Diagnostics.DiagID LEFT OUTER JOIN BillProcedures ON PatientProcedures.PatientProcedureID = BillProcedures.PatientProcedureID  WHERE PatientProcedures.PatientID = " & Val(ListViewPatients.SelectedItems(0).Text) & " ORDER BY PatientProcedures.PatientProcedureID "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Dim PriceFieldName As String
        Do Until Reader.Read = False
            If IsDate(Reader("ScheduleDateTime").ToString) Then
                LI = ListViewProcedures.Items.Add(CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yyyy"), 0)
            Else
                LI = ListViewProcedures.Items.Add("", 0)
            End If
            LI.Tag = Reader("PatientProcedureID").ToString
            LI.SubItems.Add(Reader("DiagName").ToString)
            LI.SubItems.Add(Reader("ProcName").ToString)
            LI.UseItemStyleForSubItems = True
            If Val(Reader("BillID").ToString) = 0 Then
                LI.ForeColor = Color.Black
                LI.BackColor = Color.White
                LI.ToolTipText = "Billed"
            Else
                LI.ForeColor = Color.White
                LI.BackColor = Color.Green
                LI.ToolTipText = "Billed"
            End If
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewProcedures.Items.Count > 0 Then
            ListViewProcedures.Items(0).Selected = True
            ListViewProcedures.Items(0).EnsureVisible()
        End If
    End Sub

    Private Sub Load_PatientServices()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SQL As String
        Dim SI As ListViewItem.ListViewSubItem
        ListViewServices.Items.Clear()
        If ListViewPatients.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        SQL = "SELECT     PatientProcedures.PatientID, Procedures.ProcName, BillProcedures.BillID, PatientProcedures.PatientProcedureID, Schedule.ScheduleDateTime, Diagnostics.DiagName FROM PatientProcedures INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Diagnostics ON PatientProcedures.DiagID = Diagnostics.DiagID LEFT OUTER JOIN BillProcedures ON PatientProcedures.PatientProcedureID = BillProcedures.PatientProcedureID  WHERE PatientProcedures.PatientID = " & Val(ListViewPatients.SelectedItems(0).Text) & "  AND ((Diagnostics.CountByVisitInd=1 and Procedures.ProcedureTypeID=0) or Diagnostics.CountByVisitInd=0) AND (Diagnostics.DiagTypeID = 3) ORDER BY PatientProcedures.PatientProcedureID "
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        Dim PriceFieldName As String
        Do Until Reader.Read = False
            LI = ListViewServices.Items.Add(Reader("DiagName").ToString, 0)
            LI.Tag = Reader("PatientProcedureID").ToString
            LI.SubItems.Add(Reader("ProcName").ToString)
        Loop
        Reader.Close() : Reader.Dispose()
        If ListViewProcedures.Items.Count > 0 Then
            ListViewProcedures.Items(0).Selected = True
            ListViewProcedures.Items(0).EnsureVisible()
        End If
    End Sub

    Public Sub Show_Details(ByVal ID As Long)
        'Dim Reader As SqlClient.SqlDataReader
        'Dim SQL As String
        'Dim lCell As String
        'Dim I As Integer
        'Dim SPHeight As Integer
        'If PanelDetails.Visible = False Then Exit Sub
        'Clear_Details()
        'SQL = "SELECT StateOfAccident, PlaceOfAccident, Patients.CaseTypeID, Patients.CaseStatusID, ClaimNumber, PolicyNumber, PolicyHolderFName+' '+PolicyHolderLName as PolHolder, AdjusterPhone, AdjusterName, SSN, InsertedDT, CaseStatuses.Description AS CaseStatus, CaseTypes.Description as CaseType, Patients.NoMoreAppointmentsInd, Patients.CaseTypeID,  Patients.DOA, Patients.ParentsRequiredInd, Patients.PatientID,  Patients.FName, Patients.MI, Patients.LName, Patients.DOB, Patients.Phone1, Patients.Phone2, Patients.CellPhone, Patients.Address1, Patients.Address2, Patients.City, Patients.State, Patients.Zip, InsuranceCompanies_1.CompanyName AS Insurance1, InsuranceCompanies.CompanyName AS Insurance2, "
        'SQL = SQL & " Patients.ReferringDoctor, ReferringOffices.OfficeName AS ReferringCompany, ReferringOffices.Phone1 AS RefPhone1, ReferringOffices.Phone2 AS RefPhone2, ReferringOffices.Phone3 AS RefPhone3, "
        'SQL = SQL & " TransportationCompanies.CompanyName AS Transportation, TransportationCompanies.Phone1 AS TransPhone1, TransportationCompanies.Phone2 AS TransPhone2, TransportationCompanies.Phone3 AS TransPhone3, Patients.Comments "
        'SQL = SQL & " FROM Patients LEFT OUTER JOIN TransportationCompanies ON Patients.TransportationCompanyID = TransportationCompanies.CompanyID LEFT OUTER JOIN ReferringOffices ON Patients.ReferringCompanyID = ReferringOffices.OfficeID LEFT OUTER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID1 = InsuranceCompanies.CompanyID LEFT OUTER JOIN InsuranceCompanies AS InsuranceCompanies_1 ON Patients.InsuranceCompanyID = InsuranceCompanies_1.CompanyID Inner Join CaseTypes on Patients.CaseTypeID = CaseTypes.CaseTypeID INNER JOIN CaseStatuses ON Patients.CaseStatusID = CaseStatuses.CaseStatusID "
        'SQL = SQL & " WHERE Patients.PatientID = " & ID
        'Reader = gSQLGetDataReader(SQL.ToString())
        'If Reader Is Nothing Then Exit Sub
        'FpSpreadDetails.ShowRow(FpSpreadDetails.GetActiveRowViewportIndex, 0, FarPoint.Win.Spread.VerticalPosition.Top)
        'With FpSpreadDetails_Sheet1
        '    Do Until Reader.Read = False
        '        .SetText(0, 1, Reader("PatientID").ToString & " / " & Reader("CaseType").ToString)
        '        .Cells(0, 1).Tag = Val(Reader("CaseTypeID").ToString)
        '        Select Case Val(Reader("CaseTypeID").ToString)
        '            Case 1
        '                .Cells(0, 1).ForeColor = Color.Black
        '            Case 2
        '                .Cells(0, 1).ForeColor = Color.Chocolate
        '            Case 5
        '                .Cells(0, 1).ForeColor = Color.MediumVioletRed
        '        End Select
        '        .SetText(1, 1, Reader("CaseStatus").ToString)
        '        Select Case Val(Reader("CaseStatusID").ToString)
        '            Case 1
        '                .Cells(1, 1).ForeColor = Color.Black
        '            Case 3, 4
        '                .Cells(1, 1).ForeColor = Color.Red
        '            Case 5
        '                .Cells(1, 1).ForeColor = Color.Green
        '        End Select
        '        .SetText(2, 1, FormatDateTime(Reader("InsertedDT").ToString, DateFormat.ShortDate))
        '        If IsDate(Reader("DOA").ToString) Then
        '            .SetText(3, 1, FormatDateTime(Reader("DOA").ToString, DateFormat.ShortDate))
        '        End If
        '        .SetText(4, 1, Reader("Fname").ToString & " " & Reader("MI").ToString & " " & Reader("Lname").ToString)
        '        If IsDate(Reader("DOB").ToString) Then
        '            .SetText(5, 1, FormatDateTime(Reader("DOB").ToString, DateFormat.ShortDate))
        '        End If
        '        .SetText(6, 1, Reader("SSN").ToString)
        '        .SetText(7, 1, Reader("Phone1").ToString)
        '        .SetText(8, 1, Reader("Phone2").ToString)
        '        .SetText(9, 1, Reader("CellPhone").ToString)
        '        .SetText(10, 1, Reader("Address1").ToString & " " & Reader("Address2").ToString & IIf(Reader("City").ToString <> "", ", " & Reader("City").ToString, "").ToString & IIf(Reader("State").ToString <> "", ", " & Reader("State").ToString, "").ToString & IIf(Replace(Reader("Zip").ToString, "_", "") <> "", ", " & Reader("Zip").ToString, "").ToString)
        '        .SetText(11, 1, Reader("Insurance1").ToString)
        '        .SetText(12, 1, Reader("AdjusterName").ToString)
        '        If Reader("AdjusterPhone").ToString <> "(___) ___-____ Ext. _____" Then .SetText(13, 1, Reader("AdjusterPhone").ToString)
        '        .SetText(14, 1, Reader("StateOfAccident").ToString)
        '        .SetText(15, 1, Reader("PlaceOfAccident").ToString)
        '        .SetText(16, 1, Reader("PolHolder").ToString)
        '        .SetText(17, 1, Reader("PolicyNumber").ToString)
        '        .SetText(18, 1, Reader("ClaimNumber").ToString)
        '        .SetText(19, 1, Reader("Comments").ToString.Trim)
        '        .Cells(19, 1).ForeColor = Color.Chocolate
        '        If Val(Reader("ParentsRequiredInd").ToString) = 1 Then
        '            .RowCount = .RowCount + 1
        '            .SetText(.RowCount - 1, 0, "Attention")
        '            .SetText(.RowCount - 1, 1, "Underage Patient!")
        '            .Cells(.RowCount - 1, 0).ForeColor = Color.Red
        '            .Cells(.RowCount - 1, 1).ForeColor = Color.Red
        '        End If
        '        If Val(Reader("NoMoreAppointmentsInd").ToString) > 0 Then
        '            .RowCount = .RowCount + 1
        '            .SetText(.RowCount - 1, 0, "Attention")
        '            .SetText(.RowCount - 1, 1, "No More Appointments!")
        '            .Cells(.RowCount - 1, 0).ForeColor = Color.Red
        '            .Cells(.RowCount - 1, 1).ForeColor = Color.Red
        '        End If

        '    Loop
        '    For I = 0 To .RowCount - 1
        '        .SetRowHeight(I, CInt(.Rows(I).GetPreferredHeight))
        '        SPHeight = SPHeight + CInt(.Rows(I).GetPreferredHeight)
        '    Next
        'End With
    End Sub

    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor = Cursors.WaitCursor
        Find_Patients()
        Cursor = Cursors.Default
    End Sub

    Private Sub Find_Patients()
        Loading = True
        Dim LI As ListViewItem
        Dim Reader As SqlClient.SqlDataReader
        Dim SQL As String
        Dim R As Integer
        Dim PatientID As Long
        Dim tMSG As String
        Dim PName() As String
        Dim SI As ListViewItem.ListViewSubItem
        Dim ProblemColor As Color = Color.DarkSalmon
        Dim WarningColor As Color = Color.FromArgb(255, 255, 192)
        Dim I As Integer
        Dim NoInsOk As Boolean

        'If gOfficeTypeID <> 2 Then
        'PanelNF2.Visible = False
        'Exit Sub
        'End If
        ListViewPatients.BeginUpdate()
        ListViewPatients.Items.Clear()
        Application.DoEvents()
        SQL = "SELECT Patients.InsertedDT, Patients.NF2Date, Patients.Attorney, Patients.CaseTypeID , AdjusterPhone, Patients.AdjusterName,  Patients.ClaimNumber, Patients.PatientID, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS PName, Patients.DOA, SSN, Patients.InsuranceCompanyID, Patients.ClaimAddressID, Patients.PolicyNumber, "
        SQL &= " CaseTypes.Description AS CaseType, CaseStatuses.Description AS CaseStatus, InsuranceCompanies.CompanyName AS Insurance "
        SQL &= " FROM         Patients INNER JOIN CaseTypes ON Patients.CaseTypeID = CaseTypes.CaseTypeID INNER JOIN CaseStatuses ON Patients.CaseStatusID = CaseStatuses.CaseStatusID LEFT OUTER JOIN InsuranceCompanies ON Patients.InsuranceCompanyID = InsuranceCompanies.CompanyID "
        SQL &= " WHERE    Patients.OfficeID = " & gOfficeID

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
        End If

        If txtBillNumber.Text.Trim <> "" Then
            SQL &= " and "
            SQL &= "( Patients.ClaimNumber like '" & txtBillNumber.Text.Trim.ToSafeSQLString() & "%' or "
            SQL &= " Patients.PolicyNumber like '" & txtBillNumber.Text.Trim.ToSafeSQLString() & "%' )"
        End If
        If txtPatientAttorney.Text.Trim <> "" Then
            SQL &= " and Patients.Attorney like '%" & txtPatientAttorney.Text.ToSafeSQLString() & "%'"
        End If
        If CType(ComboBoxSearchCaseStatus.SelectedItem, ValueDescription).Value > 0 Then
            SQL &= " AND Patients.CaseStatusID=" & CType(ComboBoxSearchCaseStatus.SelectedItem, ValueDescription).Value
        End If

        If CType(ComboBoxSearchCaseType.SelectedItem, ValueDescription).Value > 0 Then
            SQL &= " AND Patients.CaseTypeID=" & CType(ComboBoxSearchCaseType.SelectedItem, ValueDescription).Value
        End If

        If DateTimePickerFrom.Checked Then
            SQL &= " and DATEDIFF(d, Patients.InsertedDT, '" & DateTimePickerFrom.Value.Date & "')<=0  "
        End If
        If DateTimePickerTo.Checked Then
            SQL &= " and DATEDIFF(d, Patients.InsertedDT, '" & DateTimePickerTo.Value.Date & "')>=0 "
        End If

        If DateTimePickerDOAFrom.Checked Then
            SQL &= " and DATEDIFF(d, Patients.DOA, '" & DateTimePickerDOAFrom.Value.Date & "')<=0  "
        End If
        If DateTimePickerDOATo.Checked Then
            SQL &= " and DATEDIFF(d, Patients.DOA, '" & DateTimePickerDOATo.Value.Date & "')>=0 "
        End If

        If cboBillingProvider.SelectedIndex > 0 Then
            SQL &= " and PatientID in (select PatientID from PatientProcedures Where BillingProviderID = " & CType(cboBillingProvider.SelectedItem, ValueDescription).Value & ")"
        End If
        If cboTreatingProvider.SelectedIndex > 0 Then
            SQL &= " and PatientID in (select PatientID from PatientProcedures Where TreatingProviderID = " & CType(cboTreatingProvider.SelectedItem, ValueDescription).Value & ")"
        End If
        If DateTimePickerServicesFrom.Checked Then
            SQL &= " and (PatientID in (SELECT PatientProcedures.PatientID FROM PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID WHERE DATEDIFF(d, Schedule.ScheduleDateTime, '" & DateTimePickerServicesFrom.Value.Date & "')<=0) "
            SQL &= " or PatientID in (SELECT PatientID FROM PatientServices WHERE DATEDIFF(d, InsertedDT, '" & DateTimePickerServicesFrom.Value.Date & "')<=0)) "
        End If
        If DateTimePickerServicesTo.Checked Then
            SQL &= " and (PatientID in (SELECT PatientProcedures.PatientID FROM PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID WHERE DATEDIFF(d, Schedule.ScheduleDateTime, '" & DateTimePickerServicesTo.Value.Date & "')>=0) "
            SQL &= " or PatientID in (SELECT PatientID FROM PatientServices WHERE DATEDIFF(d, InsertedDT, '" & DateTimePickerServicesFrom.Value.Date & "')>=0)) "
        End If
        If txtPACSAltNumber.Text.Trim <> "" Then
            SQL &= " AND Patients.PatientID IN (SELECT PatientID FROM PatientProcedures WHERE  PatientProcedures.PACSAltNumber like '" & txtPACSAltNumber.Text.Trim.ToSafeSQLString() & "%')"
        End If

        ''''''''''''''''''''''''''''
        'ComboBoxFilter.Items.Add(New ValueDescription(0, "All Patients"))
        'ComboBoxFilter.Items.Add(New ValueDescription(9999, "----------------------------------------------"))
        'ComboBoxFilter.Items.Add(New ValueDescription(-1, "Completed Procedures"))
        'ComboBoxFilter.Items.Add(New ValueDescription(-2, "No Procedures"))
        'ComboBoxFilter.Items.Add(New ValueDescription(9999, "----------------------------------------------"))
        'ComboBoxFilter.Items.Add(New ValueDescription(-3, "Outsource Services"))
        'ComboBoxFilter.Items.Add(New ValueDescription(-4, "No Outsource Services"))
        'ComboBoxFilter.Items.Add(New ValueDescription(9999, "----------------------------------------------"))
        'ComboBoxFilter.Items.Add(New ValueDescription(-5, "NF2 Printed"))
        'ComboBoxFilter.Items.Add(New ValueDescription(-6, "NF2 Not Printed"))
        'ComboBoxFilter.Items.Add(New ValueDescription(9999, "----------------------------------------------"))
        'ComboBoxFilter.Items.Add(New ValueDescription(-7, "Billed"))
        'ComboBoxFilter.Items.Add(New ValueDescription(-8, "Not Billed"))
        'ComboBoxFilter.Items.Add(New ValueDescription(9999, "----------------------------------------------"))

        'Do Until Reader.Read = False
        ' ComboBoxFilter.Items.Add(New ValueDescription(Reader("DiagID").ToString, Reader("Diag").ToString))
        'Loop
        If ComboBoxFilter.SelectedIndex > 0 Then
            Select Case CType(ComboBoxFilter.SelectedItem, ValueDescription).Value
                Case -1
                    SQL &= " and "
                    SQL &= " Patients.PatientID in (select distinct PatientID from PatientProcedures where OfficeID=" & gOfficeID & ") "
                Case -2
                    SQL &= " and "
                    SQL &= " Patients.PatientID not in (select distinct PatientID from PatientProcedures where OfficeID=" & gOfficeID & ") "
                Case -3
                    SQL &= " and "
                    SQL &= " Patients.PatientID in (select distinct PatientID from PatientServices where OfficeID=" & gOfficeID & ") "
                Case -4
                    SQL &= " and "
                    SQL &= " Patients.PatientID not in (select distinct PatientID from PatientServices where OfficeID=" & gOfficeID & ") "
                Case -5
                    SQL &= " AND NF2Date IS NOT NULL "
                Case -6
                    SQL &= " AND NF2Date IS NULL "
                    'Case -7
                    '    SQL &= " and "
                    '    SQL &= " Patients.PatientID in (select distinct PatientID from Bills where OfficeID=" & gOfficeID & ") "
                    'Case -8
                    '    SQL &= " and "
                    '    SQL &= " Patients.PatientID not in (select distinct PatientID from Bills where OfficeID=" & gOfficeID & ") "
                Case -7
                    SQL &= " and Patients.PatientID in (select PatientProcedures.PatientID from PatientProcedures left outer join BillProcedures on PatientProcedures.PatientProcedureID = BillProcedures.PatientProcedureID where BillProcedures.BillID is not null group by PatientProcedures.PatientID) "
                Case -8
                    SQL &= " and Patients.PatientID in (select PatientProcedures.PatientID from PatientProcedures left outer join BillProcedures on PatientProcedures.PatientProcedureID = BillProcedures.PatientProcedureID where BillProcedures.BillID is null group by PatientProcedures.PatientID) "

                Case Else
                    If CType(ComboBoxFilter.SelectedItem, ValueDescription).Value1 = "" Then
                        SQL &= " and "
                        SQL &= " Patients.PatientID in (select distinct PatientID from PatientServices where DiagID=" & CType(ComboBoxFilter.SelectedItem, ValueDescription).Value & " and OfficeID=" & gOfficeID & ") "
                    ElseIf CType(ComboBoxFilter.SelectedItem, ValueDescription).Value1 = "0" Then
                        SQL &= " AND Patients.InsuranceCompanyID in (Select CompanyID From InsuranceCompanies Where GroupID = " & CType(ComboBoxFilter.SelectedItem, ValueDescription).Value & ") "
                    ElseIf CType(ComboBoxFilter.SelectedItem, ValueDescription).Value1 = "1" Then
                        SQL &= " AND Patients.InsuranceCompanyID = " & CType(ComboBoxFilter.SelectedItem, ValueDescription).Value & " "
                    End If

            End Select
        End If

        SQL &= " ORDER BY PatientID"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ListViewPatients.ListViewItemSorter = Nothing
        Do Until Reader.Read = False
            NoInsOk = False
            If Val(Reader("InsuranceCompanyID").ToString) = 0 Or Val(Reader("ClaimAddressID").ToString) = 0 Or Reader("DOA").ToString = "" Or Reader("PolicyNumber").ToString = "" Then
                tMSG = Reader("PName").ToString & vbCrLf & vbCrLf & "Incomplete Profile. " & vbCrLf & vbCrLf
                If Val(Reader("InsuranceCompanyID").ToString) = 0 Then
                    tMSG &= "Insurance company is missing." & vbCrLf
                End If
                If Val(Reader("ClaimAddressID").ToString) = 0 Then
                    tMSG &= "Claim Address is missing." & vbCrLf
                End If
                If Val(Reader("DOA").ToString) = 0 Then
                    tMSG &= "DOA is missing." & vbCrLf
                End If
                If Reader("PolicyNumber").ToString = "" Then
                    tMSG &= "PolicyNumber is missing." & vbCrLf
                End If
                tMSG &= vbCrLf
                LI = ListViewPatients.Items.Add(Reader("PatientID").ToString, 1)
                LI.ToolTipText = tMSG
            Else
                LI = ListViewPatients.Items.Add(Reader("PatientID").ToString, 0)
                LI.ToolTipText = Reader("PName").ToString
            End If

            LI.UseItemStyleForSubItems = False
            LI.Tag = Reader("PatientID").ToString

            LI.SubItems.Add(Reader("PName").ToString)
            SI = LI.SubItems.Add(Reader("SSN").ToString)
            If Reader("SSN").ToString.Trim = "" Then SI.BackColor = ProblemColor
            If IsDate(Reader("DOA").ToString) Then
                SI = LI.SubItems.Add(FormatDateTime(Reader("DOA").ToString, DateFormat.ShortDate))
            Else
                SI = LI.SubItems.Add("")
                SI.BackColor = ProblemColor
            End If
            SI = LI.SubItems.Add(Reader("CaseType").ToString)
            If Reader("CaseType").ToString.Trim = "" Then SI.BackColor = ProblemColor
            Select Case Val(Reader("CaseTypeID").ToString)
                Case 1
                    SI.ForeColor = Color.Black
                Case 2
                    SI.ForeColor = Color.Chocolate
                Case 3
                    SI.ForeColor = Color.Blue
                    NoInsOk = True
                Case 4
                    NoInsOk = True
                Case 5
                    SI.ForeColor = Color.MediumVioletRed
                    NoInsOk = True
            End Select
            SI = LI.SubItems.Add(Reader("CaseStatus").ToString)
            If Reader("CaseStatus").ToString.Trim = "" Then SI.BackColor = ProblemColor
            SI = LI.SubItems.Add(Reader("Insurance").ToString)
            SI.Tag = Val(Reader("InsuranceCompanyID").ToString)

            If Val(Reader("CaseTypeID").ToString) = 1 Or Val(Reader("CaseTypeID").ToString) = 3 Then If Reader("Insurance").ToString.Trim = "" Then SI.BackColor = ProblemColor
            SI = LI.SubItems.Add(Reader("PolicyNumber").ToString)
            If NoInsOk = False Then If Reader("PolicyNumber").ToString.Trim = "" Then SI.BackColor = ProblemColor
            SI = LI.SubItems.Add(Reader("ClaimNumber").ToString)
            If NoInsOk = False Then If Reader("ClaimNumber").ToString.Trim = "" Then SI.BackColor = ProblemColor
            SI = LI.SubItems.Add(Reader("AdjusterName").ToString)
            If NoInsOk = False Then If Reader("AdjusterName").ToString.Trim = "" Then SI.BackColor = WarningColor
            SI = LI.SubItems.Add(Reader("Attorney").ToString)
            If Val(Reader("CaseTypeID").ToString) = 5 Then ' Lien
                If Reader("Attorney").ToString.Trim = "" Then SI.BackColor = ProblemColor
            ElseIf Val(Reader("CaseTypeID").ToString) = 3 Then ' Private
                If NoInsOk = False Then If Reader("Attorney").ToString.Trim = "" Then SI.BackColor = WarningColor
            Else
                If NoInsOk = False Then If Reader("Attorney").ToString.Trim = "" Then SI.BackColor = WarningColor
            End If
            If IsDate(Reader("NF2Date").ToString) Then
                SI = LI.SubItems.Add(FormatDateTime(Reader("NF2Date").ToString, DateFormat.ShortDate))
            Else
                SI = LI.SubItems.Add("")
                If IsDate(Reader("DOA").ToString) Then
                    If CDate(Reader("DOA").ToString) < DateAdd(DateInterval.Day, -gNF2MaxAge, Now.Date).ToString("MM/dd/yyyy 00:00") Then
                        If NoInsOk = False Then SI.BackColor = WarningColor
                    End If
                End If
            End If
            SI = LI.SubItems.Add(FormatDateTime(Reader("InsertedDT").ToString, DateFormat.ShortDate))

            If Val(Reader("PatientID").ToString) = PatientID Then
                LI.Selected = True
            End If
        Loop
        m_SortingColumn = ListViewPatients.Columns(0)
        For Each CLMN As ColumnHeader In ListViewPatients.Columns
            CLMN.ImageKey = "SORT0"
        Next
        ListViewPatients.Columns(0).ImageKey = "SORT1"
        ListViewPatients.ListViewItemSorter = New ListViewComparer(0, SortOrder.Ascending)

        ListViewPatients.Sort()
        Count_Selected()
        ListViewPatients.EndUpdate()
        If ListViewPatients.Items.Count > 0 Then
            ListViewPatients.Items(0).Selected = True
            ListViewPatients.Items(0).EnsureVisible()
            ListViewPatients_SelectedIndexChanged(Nothing, Nothing)
        End If
        Loading = False
    End Sub

    Private Sub PrintCheckedSelectedNF23ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCheckedSelectedNF23ToolStripMenuItem.Click
        mnuPrinting1_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        SelectAllToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        SelectNoneToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        mnuShowSelectedPatientInfo1_Click(Nothing, Nothing)
    End Sub

    Private Sub ListViewProcedures_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewProcedures.SelectedIndexChanged
        'gHighlightListviewItem(ListViewProcedures)
    End Sub

    Private Sub ListViewServices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewServices.SelectedIndexChanged
        gHighlightListviewItem(ListViewServices)
    End Sub

    Private Sub ListViewRequests_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewRequests.SelectedIndexChanged
        gHighlightListviewItem(ListViewRequests)
    End Sub

    Private Sub FindDuplicatePatientsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindDuplicatePatientsToolStripMenuItem.Click
        frmPatientsFindDuplicates.Load_Data()
        frmPatientsFindDuplicates.Show(Me)
    End Sub

    Private Sub ComboBoxFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxFilter.SelectedIndexChanged
        If ComboBoxFilter.SelectedIndex = -1 Then Exit Sub
        If CType(ComboBoxFilter.SelectedItem, ValueDescription).Value = 9999 Then
            ComboBoxFilter.SelectedIndex = 0
        End If
    End Sub

    Private Sub Load_RelatedPatients()
        Dim SQL As String
        Dim PatientID As Long
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim PName() As String
        Dim SQLPNAME As String = ""
        ListViewPatientsRelated.BeginUpdate()
        ListViewPatientsRelated.Items.Clear()
        If ListViewPatients.SelectedItems.Count = 0 Then
            ListViewPatientsRelated.EndUpdate()
            Exit Sub
        End If
        PatientID = ListViewPatients.SelectedItems(0).Text
        SQL = " SELECT DISTINCT    Patients.PatientID, Patients.FName, Patients.LName, Patients.MI, Patients.CaseStatusID, Patients.NoMoreAppointmentsInd,  Patients.Suffix "
        SQL &= " FROM         PatientAccidentGroups INNER JOIN PatientAccidentGroups AS PatientAccidentGroups_1 ON PatientAccidentGroups.GroupID = PatientAccidentGroups_1.GroupID INNER JOIN Patients ON PatientAccidentGroups.PatientID = Patients.PatientID "
        SQL &= " WHERE PatientAccidentGroups_1.PatientID = " & PatientID & " AND PatientAccidentGroups.PatientID <> " & PatientID
        SQL &= " Order by Patients.FName, Patients.LName"
        Reader = gSQLGetDataReader(SQL)

        If Reader Is Nothing Then ListViewPatientsRelated.EndUpdate() : Exit Sub
        If Reader.HasRows Then
            Do Until Reader.Read = False

                LI = ListViewPatientsRelated.Items.Add(Reader("PatientID").ToString, CInt(Val(Reader("CaseStatusID").ToString) - 1))
                If Reader("Suffix").ToString <> "" Then
                    LI.SubItems.Add(Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString & " " & Reader("Suffix").ToString)
                Else
                    LI.SubItems.Add(Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString)
                End If
                LI.ToolTipText = Reader("FName").ToString & " " & Reader("MI").ToString & " " & Reader("LName").ToString & " " & Reader("Suffix").ToString
                LI.Tag = "" & Reader("PatientID").ToString
                If Val(Reader("NoMoreAppointmentsInd").ToString) <> 0 Then
                    LI.ForeColor = Color.Red
                Else
                    LI.ForeColor = Color.Black
                End If
            Loop
            ListViewPatientsRelated.EndUpdate()
        Else
            ListViewPatientsRelated.EndUpdate()
        End If
        Reader.Close() : Reader.Dispose()
    End Sub

    Private Sub ShowAccidentRelatedPatientsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAccidentRelatedPatientsToolStripMenuItem.Click
        Dim ID As Long
        Dim LI As ListViewItem
        If ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to show Accident related Patients. No Patient selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewPatients.SelectedItems(0)
        ID = ListViewPatients.SelectedItems(0).Tag
        frmAccidentPatients.PatientID = ID
        If IsDate(LI.SubItems(3).Text) Then frmAccidentPatients.DOA = LI.SubItems(3).Text
        frmAccidentPatients.PolicyNumber = LI.SubItems(7).Text
        If Val(LI.SubItems(6).Tag) > 0 Then
            frmAccidentPatients.InsuranceCompanyID = LI.SubItems(6).Tag
        End If
        frmAccidentPatients.lblPatient.Text = LI.SubItems(1).Text.ToUpper
        frmAccidentPatients.lblPatient1.Text = "INSURANCE: " & LI.SubItems(6).Text
        frmAccidentPatients.lblPatient2.Text = UCase(IIf(LI.SubItems(7).Text <> "", "POLICY #:" & LI.SubItems(7).Text, "") & IIf(LI.SubItems(8).Text <> "", "   CLAIM#:" & LI.SubItems(8).Text, "") & IIf(LI.SubItems(3).Text <> "", "   DOA:" & LI.SubItems(3).Text, ""))
        frmAccidentPatients.Load_Data()
        frmAccidentPatients.ShowDialog(Me)
        Load_RelatedPatients()
        frmAccidentPatients.Dispose()
    End Sub

    Private Sub Print_Label(ByVal PatientID As Long)
        Dim intCounter As Integer
        Dim CR As ReportDocument
        Dim ConInfo As New TableLogOnInfo
        CR = New eMedicalOffice.rptPatientFileLabel
        ''gShowWait(True, PanelWait, Me)
        'ConInfo.ConnectionInfo.UserID = gSQLServerUID
        'ConInfo.ConnectionInfo.Password = gSQLServerPassword
        'ConInfo.ConnectionInfo.ServerName = gSQLServerName
        'ConInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase

        'For intCounter = 0 To CR.Database.Tables.Count - 1
        '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.UserID = gSQLServerUID
        '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.Password = gSQLServerPassword
        '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.ServerName = gSQLServerName
        '    CR.Database.Tables(intCounter).LogOnInfo.ConnectionInfo.DatabaseName = gSQLServerDatabase
        '    Application.DoEvents()
        '    CR.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
        '    Application.DoEvents()
        'Next
        'CR.Refresh()
        If SetupCrystalSecurityInfo(CR) = False Then Exit Sub
        CR.SetParameterValue("PatientID", PatientID.ToString)
        If gPrinterFileLabel <> "" Then CR.PrintOptions.PrinterName = gPrinterFileLabel
        CR.PrintOptions.ApplyPageMargins(New PageMargins(0, 0, 0, 0))
        CR.PrintToPrinter(1, False, 0, 0)

    End Sub

    Private Sub PrintPatientsFileLabelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPatientsFileLabelToolStripMenuItem.Click
        Try
            Dim ID As Long
            If ListViewPatients.SelectedItems.Count = 0 Then
                MsgBox("Unable to print the Patient's File Label. No patient selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ID = ListViewPatients.SelectedItems(0).Tag
            Cursor = Cursors.WaitCursor
            Print_Label(ID)
            Cursor = Cursors.Default
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub ListViewPatientsRelated_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPatientsRelated.DoubleClick
        Dim PatID As Long
        If ListViewPatientsRelated.SelectedItems.Count > 0 Then
            PatID = ListViewPatientsRelated.SelectedItems(0).Tag
            ButtonClear_Click(Nothing, Nothing)
            TextBoxSearch.Text = PatID
            Find_Patients()
        End If
    End Sub

    Private Sub ListViewPatientsRelated_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewPatientsRelated.MouseDown
        Dim LI As ListViewItem
        Dim H As ListViewHitTestInfo
        If e.Button = Windows.Forms.MouseButtons.Right Then
            H = ListViewPatientsRelated.HitTest(New Point(e.X, e.Y))
            If H.Item Is Nothing Then
                ListViewPatientsRelated.ContextMenuStrip = Nothing
            Else
                H.Item.Selected = True
                H.Item.EnsureVisible()
                ListViewPatientsRelated.ContextMenuStrip = ContextMenuStrip3
            End If
        End If
    End Sub

    Private Sub ListViewPatientsRelated_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewPatientsRelated.SelectedIndexChanged

    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        ListViewPatientsRelated_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ButtonDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDetails.Click
        PanelDetails.Visible = False
        PanelShowDetails.Visible = True
        ListViewPatients.BringToFront()
    End Sub

    Private Sub PanelShowDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelShowDetails.Click
        If ListViewPatients.SelectedItems.Count > 0 Then
            PanelDetails.SuspendLayout()
            Load_PatientProcedures()
            If gOfficeTypeID = 2 Then Load_PatientServices()
            Load_Patient_Bills()
            Load_Requests()
            Load_RelatedPatients()
            PanelDetails.ResumeLayout()
        End If
        PanelDetails.Visible = True
        PanelShowDetails.Visible = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LockWindowUpdate(TableLayoutPanel2.Handle)
        Timer1.Enabled = False
        Load_Attorney_AutoComplete()
        Load_Data()
        LockWindowUpdate(0)
    End Sub

    Private Sub TableLayoutPanel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub

    Private Sub TableLayoutPanel2_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableLayoutPanel2.SizeChanged
        TableLayoutPanel2.Refresh()
    End Sub

    Private Sub PrintPatientScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPatientScheduleToolStripMenuItem.Click
        If ListViewPatients.SelectedItems.Count > 0 Then
            frmReportSchedule.ByPatient = True
            'frmReportSchedule.ScheduleDate = DateTimePicker1.Value.Date
            frmReportSchedule.CheckBox1.Visible = True
            frmReportSchedule.PatientID = Val(ListViewPatients.SelectedItems(0).Tag)
            frmReportSchedule.ShowDialog(Me)
            frmReportSchedule.Dispose()
        Else
            MsgBox("Unable to print patient's schedule. No Patient selected.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        PrintPatientScheduleToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub QuickPrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuickPrintToolStripMenuItem.Click
        Print_Listview(True, True)
    End Sub

    Private Sub mnuPrintCheckedEnvelopes1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintCheckedEnvelopes1.Click
        Dim PatientID() As String = Nothing
        Dim I As Integer = 0
        If ListViewPatients.CheckedItems.Count = 0 And ListViewPatients.SelectedItems.Count = 0 Then
            MsgBox("Unable to print envelope(s). No Patient(s) checked/selected. Please check the Patient(s) and try again.", MsgBoxStyle.Critical)
            ListViewPatients.Focus()
            Exit Sub
        End If

        Dim LI As ListViewItem
        If ListViewPatients.CheckedItems.Count = 0 Then
            ReDim Preserve PatientID(0)
            PatientID(I) = Val(ListViewPatients.SelectedItems(0).Text)
        Else
            For Each LI In ListViewPatients.CheckedItems
                ReDim Preserve PatientID(I)
                PatientID(I) = Val(LI.Text)
                I = I + 1
            Next
        End If
        frmBillingEnvelops.Setup_report(PatientID, 0, False)
        frmBillingEnvelops.ShowDialog(Me)
        frmBillingEnvelops.Dispose()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        mnuPrintCheckedEnvelopes1_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        gListViewRestoreDefaultColumnWidth(ListViewPatients)
    End Sub

    Private Sub EmailAllRecordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailAllRecordsToolStripMenuItem.Click
        Fax_Listview(True)
    End Sub

    Private Sub EmailCheckedOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailCheckedOnlyToolStripMenuItem.Click
        Fax_Listview(False)
    End Sub

    Private Sub ToolStripButtonCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCloseForm.Click
        Me.Close()
    End Sub

    Private Sub frmPatientAttendancy_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ToolStripButtonCloseForm.Visible = Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmPatientAttendancy_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ToolStripButtonCloseForm.Visible = Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStrip2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStrip2.DoubleClick
        gCustomizeToolStrip(ToolStrip2, Me)
    End Sub

    Private Sub ToolStrip2_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub

    Private Sub CustomizeToolbarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomizeToolbarToolStripMenuItem.Click
        gCustomizeToolStrip(ToolStrip2, Me)
        gToolStripSettings(Me, ToolStrip2, ReadWrite.sWrite)
    End Sub

    Private Sub ContextMenuStripCustomizeToolStrip_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripCustomizeToolStrip.Opening

    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click, ToolStripButton12.DoubleClick
        SetFont(1)
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click, ToolStripButton13.DoubleClick
        SetFont(-1)
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        For Each TSi In ToolStrip2.Items
            TSi.Visible = True
        Next
        gToolStripSettings(Me, ToolStrip2, ReadWrite.sWrite)
    End Sub

End Class