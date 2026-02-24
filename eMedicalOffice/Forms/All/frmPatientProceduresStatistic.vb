Imports System.Reflection
Imports log4net

Public Class frmPatientProceduresStatistic
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private m_SortingColumn As ColumnHeader
    Private Loading As Boolean

    Private Sub frmPatientProceduresStatistic_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)
        gListview_Settings(Me, ListView2, ReadWrite.sWrite)
        SaveSetting(My.Application.Info.ProductName, "Settings", "ProcedureStatisticHighlight", ComboBoxHighLight.SelectedIndex)

        SaveSetting(My.Application.Info.ProductName, "Settings", "PatientProcedureStatisticsReportFld0", ListView3.Items(0).Checked)
        SaveSetting(My.Application.Info.ProductName, "Settings", "PatientProcedureStatisticsReportFld1", ListView3.Items(1).Checked)
        SaveSetting(My.Application.Info.ProductName, "Settings", "PatientProcedureStatisticsReportFld2", ListView3.Items(2).Checked)
        SaveSetting(My.Application.Info.ProductName, "Settings", "PatientProcedureStatisticsReportFld3", ListView3.Items(3).Checked)
        SaveSetting(My.Application.Info.ProductName, "Settings", "PatientProcedureStatisticsReportFld4", ListView3.Items(4).Checked)
        SaveSetting(My.Application.Info.ProductName, "Settings", "PatientProcedureStatisticsReportFld5", ListView3.Items(5).Checked)

    End Sub

    Private Sub frmPatientProceduresStatistic_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = 13 Then
            Find_Data()
        End If
    End Sub

    Private Sub frmPatientProceduresStatistic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
        gListview_Settings(Me, ListView2, ReadWrite.sRead)

        Load_Data()
    End Sub

    Private Sub Load_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim Sql As String
        Dim LI As ListViewItem

        ComboBoxCaseStatus.Items.Add(New ValueDescription(0, "All"))
        ComboBoxCaseStatus.Items.Add(New ValueDescription(1, "All Active"))
        ComboBoxCaseStatus.Items.Add(New ValueDescription(2, "All Not Active"))

        Sql = "SELECT     DiagID, DiagName, DiagTypeID FROM Diagnostics WHERE     (ActiveInd = 1) AND (OfficeID = 1) AND (ForBillingOnlyInd = 0) ORDER BY DiagTypeID, DiagName"
        Reader = gSQLGetDataReader(Sql)
        If Reader Is Nothing Then Exit Sub
        Do Until Reader.Read = False
            LI = ListView1.Items.Add(Reader("DiagName").ToString.Trim)
            LI.UseItemStyleForSubItems = True
            LI.Tag = Reader("DiagID").ToString
            If Val(Reader("DiagID").ToString) = 3 Then
                LI.ForeColor = Color.Blue
                LI.ToolTipText = "Outsourced Procedure"
            End If
        Loop
        Dim I As Integer
        For I = 0 To 50
            ComboBoxHighLight.Items.Add(I)
        Next
        DoNotLoad = True
        ComboBoxHighLight.SelectedIndex = GetSetting(My.Application.Info.ProductName, "Settings", "ProcedureStatisticHighlight", 0)
        ComboBoxCaseStatus.SelectedIndex = 1

        ListView3.Items.Add("Patient Name", "Patient Name", "").Checked = GetSetting(My.Application.Info.ProductName, "Settings", "PatientProcedureStatisticsReportFld0", True)
        ListView3.Items.Add("DOB", "DOB", "").Checked = GetSetting(My.Application.Info.ProductName, "Settings", "PatientProcedureStatisticsReportFld1", True)
        ListView3.Items.Add("Sex", "Sex", "").Checked = GetSetting(My.Application.Info.ProductName, "Settings", "PatientProcedureStatisticsReportFld2", True)
        ListView3.Items.Add("Inserted Date", "Inserted Date", "").Checked = GetSetting(My.Application.Info.ProductName, "Settings", "PatientProcedureStatisticsReportFld3", True)
        ListView3.Items.Add("DOA", "DOA", "").Checked = GetSetting(My.Application.Info.ProductName, "Settings", "PatientProcedureStatisticsReportFld4", True)
        ListView3.Items.Add("Attorney", "Attorney", "").Checked = GetSetting(My.Application.Info.ProductName, "Settings", "PatientProcedureStatisticsReportFld5", True)

        DoNotLoad = False
    End Sub

    Private Sub ListView1_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView1.ItemChecked
        Find_Data()
    End Sub

    Private Sub ShowPatientsProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowPatientsProfileToolStripMenuItem.Click
        ToolStripButton1_Click(Nothing, Nothing)
    End Sub

    Private Sub Find_Data()
        If DoNotLoad Then Exit Sub
        Dim IDs As String
        Dim LC As ColumnHeader
        Dim Reader As SqlClient.SqlDataReader
        Dim Sql As String
        Dim LI As ListViewItem
        Dim SI As ListViewItem.ListViewSubItem
        Dim I As Integer
        Dim Tp As Integer
        Dim PName() As String
        Dim Red As Integer
        Dim RedCount As Integer
        gListview_Settings(Me, ListView2, ReadWrite.sWrite)
        ListView2.Items.Clear()
        ListView2.Columns.Clear()
        ListView2.View = View.List
        ListView2.SuspendLayout()
        ListView2.BeginUpdate()
        Me.UseWaitCursor = True
        ToolStripStatusLabel1.Text = "Loading Data. Please Wait..."
        ToolStripStatusLabelRed.Text = ""
        ToolStripStatusLabel2.Text = ""
        Application.DoEvents()
        If ListView1.CheckedItems.Count = 0 Then GoTo ExitProc
        DoNotCheck = True
        For Each LI In ListView1.CheckedItems
            IDs = IDs & ", " & LI.Tag
        Next
        IDs = IDs.Mid(3)
        Sql = " DECLARE @query  VARCHAR(8000) "
        Sql &= " DECLARE @Procs VARCHAR(8000) "
        Sql &= " SELECT  @Procs = STUFF(( SELECT DISTINCT '],[' + rtrim(DiagName)FROM Diagnostics "
        Sql &= " WHERE DiagID in (" & IDs & ") "
        Sql &= " FOR XML PATH('')), 1, 2, '') + ']' "

        Sql &= " SET @query ='SELECT * FROM "
        Sql &= " ( "

        'ListView3.Items.Add("Patient Name", "Patient Name").Checked = True
        'ListView3.Items.Add("Inserted Date", "Inserted Date").Checked = True
        'ListView3.Items.Add("DOA", "DOA").Checked = True
        'ListView3.Items.Add("Attorney", "Attorney").Checked = True

        Sql &= "     SELECT Patients.PatientID '+CHAR(39)+'Pat #'+CHAR(39)+', "
        If ListView3.Items("Patient Name").Checked Then Sql &= "Patients.FName +'+CHAR(39)+' ' + CHAR(39) + '+ Patients.LName as '+CHAR(39)+'Patient Name'+CHAR(39)+', "
        If ListView3.Items("DOB").Checked Then Sql &= "DOB, "
        If ListView3.Items("Sex").Checked Then Sql &= "Sex, "
        If ListView3.Items("Inserted Date").Checked Then Sql &= "Patients.InsertedDT as Inserted, "
        If ListView3.Items("DOA").Checked Then Sql &= "DOA, "
        If ListView3.Items("Attorney").Checked Then Sql &= "Patients.Attorney, "

        Sql &= " DiagName,PatientProcedures.DiagID "
        Sql &= "     FROM Diagnostics inner join PatientProcedures on PatientProcedures.DiagID = Diagnostics.DiagID inner join Patients on PatientProcedures.PatientID = Patients.PatientID "
        Sql &= "         Where (ProcedureStatusID = 2) "
        If ComboBoxCaseStatus.SelectedIndex > 0 Then
            If CType(ComboBoxCaseStatus.SelectedItem, ValueDescription).Value = 1 Then
                Sql &= " AND Patients.CaseStatusID=1 "
            Else
                Sql &= " AND Patients.CaseStatusID <>1 "
            End If
        End If

        If txtPatient.Text.Trim <> "" Then
            If IsNumeric(txtPatient.Text) Then
                Sql &= " AND Patients.PatientID = " & Val(txtPatient.Text) & " "
            Else
                PName = Split(txtPatient.Text.ToSafeSQLString(), " ")
                Select Case PName.Length
                    Case 1
                        If PName(0).Trim = "*" Then PName(0) = ""
                        Sql &= " and (Patients.FName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+' or Patients.LName Like '+CHAR(39)+'" & PName(0) & "%'+CHAR(39)+') "
                    Case 2
                        Sql &= " and ("
                        Sql &= " (Patients.FName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+' and Patients.LName Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+') "
                        Sql &= " OR (Patients.FName Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+' and Patients.LName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+')"
                        Sql &= " )"
                    Case 3
                        Sql &= " and ("
                        Sql &= " (Patients.FName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+' and Patients.MI Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+' and  Patients.LName Like '+CHAR(39)+'" & PName(2).Trim & "%'+CHAR(39)+') "
                        Sql &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '+CHAR(39)+'" & PName(2).Trim & "%'+CHAR(39)+' and  Patients.LName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+') "
                        Sql &= " OR (Patients.FName Like '+CHAR(39)+'" & PName(2).Trim & "%'+CHAR(39)+' and Patients.MI Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+' and  Patients.LName Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+') "
                        Sql &= " OR (Patients.FName Like '+CHAR(39)+'" & PName(2).Trim & "%'+CHAR(39)+' and Patients.MI Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+' and  Patients.LName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+') "
                        Sql &= " OR (Patients.FName Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+' and Patients.MI Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+' and  Patients.LName Like '+CHAR(39)+'" & PName(2).Trim & "%'+CHAR(39)+') "
                        Sql &= " OR (Patients.FName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+' and Patients.MI Like '+CHAR(39)+'" & PName(2).Trim & "%'+CHAR(39)+' and  Patients.LName Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+') "

                        Sql &= " )"
                End Select
            End If
        End If

        If DateTimePickerFrom.Checked Then
            Sql &= " and DATEDIFF(d, Patients.DOA, '+CHAR(39)+'" & DateTimePickerFrom.Value.Date & "'+CHAR(39)+')<=0  "
        End If
        If DateTimePickerTo.Checked Then
            Sql &= " and DATEDIFF(d, Patients.DOA, '+CHAR(39)+'" & DateTimePickerTo.Value.Date & "'+CHAR(39)+')>=0 "
        End If

        Sql &= " )t "
        Sql &= " PIVOT (COUNT(DiagID) FOR DiagName "
        Sql &= " IN ('+@Procs+')) AS pvt "

        Sql &= " UNION "    ' Get All which do not have completted procedures + no scheduled procedures.
        Sql &= "     SELECT Patients.PatientID '+CHAR(39)+'Pat #'+CHAR(39)+', "
        If ListView3.Items("Patient Name").Checked Then Sql &= "Patients.FName +'+CHAR(39)+' ' + CHAR(39) + '+ Patients.LName as '+CHAR(39)+'Patient Name'+CHAR(39)+', "
        If ListView3.Items("DOB").Checked Then Sql &= "DOB, "
        If ListView3.Items("Sex").Checked Then Sql &= "Sex, "
        If ListView3.Items("Inserted Date").Checked Then Sql &= "Patients.InsertedDT as Inserted, "
        If ListView3.Items("DOA").Checked Then Sql &= "DOA, "
        If ListView3.Items("Attorney").Checked Then Sql &= "Patients.Attorney, "

        ' Number of columns should match
        For Each LI In ListView1.CheckedItems
            Sql &= "0, "
        Next
        Sql = Sql.Left(Len(Sql) - 2)
        Sql &= " FROM Patients Where PatientID not in (select PatientID from dbo.PatientProcedures Where ProcedureStatusID = 2)"
        If ComboBoxCaseStatus.SelectedIndex > 0 Then
            If CType(ComboBoxCaseStatus.SelectedItem, ValueDescription).Value = 1 Then
                Sql &= " AND Patients.CaseStatusID=1 "
            Else
                Sql &= " AND Patients.CaseStatusID <>1"
            End If
        End If

        If txtPatient.Text.Trim <> "" Then
            If IsNumeric(txtPatient.Text) Then
                Sql &= " AND Patients.PatientID = " & Val(txtPatient.Text) & " "
            Else
                PName = Split(txtPatient.Text.ToSafeSQLString(), " ")
                Select Case PName.Length
                    Case 1
                        If PName(0).Trim = "*" Then PName(0) = ""
                        Sql &= " and (Patients.FName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+' or Patients.LName Like '+CHAR(39)+'" & PName(0) & "%'+CHAR(39)+') "
                    Case 2
                        Sql &= " and ("
                        Sql &= " (Patients.FName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+' and Patients.LName Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+') "
                        Sql &= " OR (Patients.FName Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+' and Patients.LName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+')"
                        Sql &= " )"
                    Case 3
                        Sql &= " and ("
                        Sql &= " (Patients.FName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+' and Patients.MI Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+' and  Patients.LName Like '+CHAR(39)+'" & PName(2).Trim & "%'+CHAR(39)+') "
                        Sql &= " OR (Patients.FName Like '" & PName(1).Trim & "%' and Patients.MI Like '+CHAR(39)+'" & PName(2).Trim & "%'+CHAR(39)+' and  Patients.LName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+') "
                        Sql &= " OR (Patients.FName Like '+CHAR(39)+'" & PName(2).Trim & "%'+CHAR(39)+' and Patients.MI Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+' and  Patients.LName Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+') "
                        Sql &= " OR (Patients.FName Like '+CHAR(39)+'" & PName(2).Trim & "%'+CHAR(39)+' and Patients.MI Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+' and  Patients.LName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+') "
                        Sql &= " OR (Patients.FName Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+' and Patients.MI Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+' and  Patients.LName Like '+CHAR(39)+'" & PName(2).Trim & "%'+CHAR(39)+') "
                        Sql &= " OR (Patients.FName Like '+CHAR(39)+'" & PName(0).Trim & "%'+CHAR(39)+' and Patients.MI Like '+CHAR(39)+'" & PName(2).Trim & "%'+CHAR(39)+' and  Patients.LName Like '+CHAR(39)+'" & PName(1).Trim & "%'+CHAR(39)+') "

                        Sql &= " )"
                End Select
            End If
        End If
        If DateTimePickerFrom.Checked Then
            Sql &= " and DATEDIFF(d, Patients.DOA, '+CHAR(39)+'" & DateTimePickerFrom.Value.Date & "'+CHAR(39)+')<=0  "
        End If
        If DateTimePickerTo.Checked Then
            Sql &= " and DATEDIFF(d, Patients.DOA, '+CHAR(39)+'" & DateTimePickerTo.Value.Date & "'+CHAR(39)+')>=0 "
        End If

        Sql &= "' "

        Sql &= " EXECUTE (@query) "

        Reader = gSQLGetDataReader(Sql)

        If Reader Is Nothing Then GoTo ExitProc
        ListView2.View = View.Details
        For I = 0 To Reader.FieldCount - 1
            If Reader.GetFieldType(I).Name = "String" Then
                LC = ListView2.Columns.Add(Reader.GetName(I).ToString, 200, HorizontalAlignment.Left)
            Else
                LC = ListView2.Columns.Add(Reader.GetName(I).ToString, 100, HorizontalAlignment.Right)
            End If
            LC.ImageKey = "SORT0"
        Next
        m_SortingColumn = ListView2.Columns(0)
        Do Until Reader.Read = False
            'LI = ListView2.Items.Add(Reader(0).ToString)
            'LI.SubItems.Add(Reader(1).ToString)
            'If IsDate(Reader("Inserted").ToString) Then
            '    LI.SubItems.Add(CDate(Reader("Inserted").ToString).ToString(("MM/dd/yyyy")))
            'Else
            '    LI.SubItems.Add("")
            'End If
            'If IsDate(Reader("DOA").ToString) Then
            '    LI.SubItems.Add(CDate(Reader("DOA").ToString).ToString(("MM/dd/yyyy")))
            'Else
            '    LI.SubItems.Add("")
            'End If
            'LI.SubItems.Add(Reader("Attorney").ToString)
            LI = ListView2.Items.Add(Reader(0).ToString)
            LI.UseItemStyleForSubItems = False
            Red = 1
            'For I = Reader.FieldCount - ListView1.CheckedItems.Count To Reader.FieldCount - 1
            For I = 1 To Reader.FieldCount - 1
                If IsDate(Reader(I).ToString) Then
                    LI.SubItems.Add(CDate(Reader(I).ToString).ToString(("MM/dd/yyyy")))
                ElseIf IsNumeric(Reader(I).ToString) Then
                    SI = LI.SubItems.Add(Reader(I).ToString)
                    If Val(Reader(I).ToString) < Val(ComboBoxHighLight.SelectedIndex) Then
                        SI.BackColor = Color.LightSalmon
                    Else
                        Red = 0
                    End If
                Else
                    LI.SubItems.Add(Reader(I).ToString)
                End If

                'If Reader.GetFieldType(I).Name <> "String" Then
                '    If Val(Reader(I).ToString) < Val(ComboBoxHighLight.SelectedIndex) Then
                '        SI.BackColor = Color.LightSalmon
                '    Else
                '        Red = 0
                '    End If
                'End If
            Next
            If Red = 1 Then
                LI.BackColor = Color.LightSalmon
                RedCount += 1
            End If
            LI.Tag = Val(Reader(0).ToString)
        Loop
ExitProc:
        'gListViewRestoreDefaultColumnWidth(ListView2)
        gListview_Settings(Me, ListView2, ReadWrite.sRead)
        ToolStripStatusLabel1.Text = "Total Found: " & ListView2.Items.Count & "   "
        ToolStripStatusLabelRed.Text = "Warning Patients: " & RedCount & "   "
        ToolStripStatusLabel2.Text = "Checked: 0   "
        ListView2.ResumeLayout()
        ListView2.EndUpdate()
        Me.UseWaitCursor = False
        DoNotCheck = False
    End Sub

    Private Sub ListView2_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView2.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListView2.Columns(e.Column)
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
        ListView2.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListView2.Sort()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        If ListView1.CheckedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No Procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Find_Data()
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        txtPatient.Text = ""
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Print_Listview(Optional ByVal All As Boolean = True)
        Dim CH As ColumnHeader = Nothing
        Dim LI As ListViewItem
        Dim I As Integer
        Dim C As Integer
        Dim C1
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo

        With FpSpreadForPrint
            If ListView2.Items.Count = 0 Then
                MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ToolStripStatusProgress.Text = "Preparing Data. Please Wait..."
            Application.DoEvents()
            .ActiveSheet.ColumnCount = ListView2.Columns.Count
            For C = 0 To ListView2.Columns.Count - 1
                For C1 = 0 To ListView2.Columns.Count - 1
                    If ListView2.Columns(C1).DisplayIndex = C Then
                        CH = ListView2.Columns(C1)
                        Exit For
                    End If
                Next
                I += 1
                'FpSpread1.ActiveSheet.Columns(I - 1).CellType = CT
                .ActiveSheet.ColumnHeader.Rows(0).Height = 32
                Select Case CH.TextAlign
                    Case HorizontalAlignment.Left
                        .ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                    Case HorizontalAlignment.Right
                        .ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                    Case HorizontalAlignment.Center
                        .ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                End Select
                .ActiveSheet.Columns(I - 1).Tag = CH.Index
                .ActiveSheet.Columns(I - 1).Width = CH.Width
                Select Case CH.Text
                    Case "Pat #"
                        .ActiveSheet.Columns(I - 1).Label = "##"
                    Case "Patient Name"
                        .ActiveSheet.Columns(I - 1).Label = "Patient"
                    Case Else
                        .ActiveSheet.Columns(I - 1).Label = CH.Text
                End Select

            Next
            I = 0
            .ActiveSheet.RowCount = 0
            For Each LI In ListView2.Items
                If All = True Or LI.Checked = True Then
                    I += 1
                    .ActiveSheet.RowCount = I
                    For C = 0 To .ActiveSheet.ColumnCount - 1
                        .ActiveSheet.SetText(I - 1, C, LI.SubItems(.ActiveSheet.Columns(C).Tag).Text)
                        .ActiveSheet.Cells(I - 1, C).BackColor = LI.SubItems(.ActiveSheet.Columns(C).Tag).BackColor
                    Next
                End If
            Next
            Printinfo.SmartPrintPagesWide = 1
            Printinfo.Preview = True
            Printinfo.Header = "PROCEDURE STATISTICS AS OF " & Now & vbCrLf & vbCrLf
            Printinfo.BestFitRows = False
            Printinfo.BestFitCols = True
            Printinfo.ShowShadows = False
            Printinfo.JobName = "eMedical Office Procedure Statistics"
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
            .ActiveSheet.PrintInfo = Printinfo
            .PrintSheet(.ActiveSheet)
        End With
        ToolStripStatusProgress.Text = "   "
    End Sub

    Private DoNotLoad As Boolean

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim LI As ListViewItem
        ListView2.BeginUpdate()
        DoNotLoad = True
        DoNotCheck = True
        For Each LI In ListView2.Items
            LI.Checked = True
        Next
        DoNotCheck = False
        ListView2.EndUpdate()
        DoNotLoad = False
        ToolStripStatusLabel2.Text = "Checked: " & ListView2.CheckedItems.Count & "   "
    End Sub

    Private Sub SelectNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNoneToolStripMenuItem.Click
        Dim LI As ListViewItem
        ListView2.BeginUpdate()
        DoNotLoad = True
        DoNotCheck = True
        For Each LI In ListView2.CheckedItems
            LI.Checked = False
        Next
        DoNotCheck = False
        DoNotLoad = False
        ListView2.EndUpdate()
        ToolStripStatusLabel2.Text = "Checked: 0   "
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        DoNotCheck = True
        DoNotLoad = True
        Dim LI As ListViewItem
        ListView1.BeginUpdate()
        For Each LI In ListView1.Items
            LI.Checked = True
        Next
        ListView1.EndUpdate()
        DoNotCheck = False
        DoNotLoad = False
        Find_Data()
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        DoNotCheck = True
        DoNotLoad = True
        Dim LI As ListViewItem
        ListView1.BeginUpdate()
        For Each LI In ListView1.CheckedItems
            LI.Checked = False
        Next
        ListView1.EndUpdate()
        DoNotCheck = False
        DoNotLoad = False
        Find_Data()
    End Sub

    Private Sub ExportCheckedToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Export_Listview(False)
    End Sub

    Private Sub ExportAllToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Export_Listview(True)
    End Sub

    Private Sub mnuPrintAll1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Print_Listview(True)
    End Sub

    Private Sub mnuPrintCheckedOnly1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Print_Listview(False)
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Print_Listview(True)
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Print_Listview(False)
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Export_Listview(True)
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Export_Listview(False)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If ListView2.SelectedItems.Count = 0 Then
            MsgBox("Unable to process your request." & vbCrLf & "No Patient selected", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Using NewFrm As New frmPatient

            NewFrm.InitialTab = 0
            NewFrm.InitialPatientName = Val(ListView2.SelectedItems(0).Tag)
            NewFrm.MinimizeBox = False
            NewFrm.MaximizeBox = False
            NewFrm.ShowDialog(Me)
            NewFrm.Dispose()
        End Using
    End Sub

    Private Sub ContextMenuStripPrint_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Print_Listview(True)
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        Print_Listview(False)
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        Export_Listview(True)
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        Export_Listview(False)
    End Sub

    Dim DoNotCheck As Boolean

    Private Sub ListView2_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView2.ItemChecked
        If DoNotCheck = True Then Exit Sub
        ToolStripStatusLabel2.Text = "Checked: " & ListView2.CheckedItems.Count & "   "
    End Sub

    Private Sub frmPatientProceduresStatistic_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ToolStripButtonCloseForm.Visible = Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmPatientProceduresStatistic_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ToolStripButtonCloseForm.Visible = Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripButtonCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCloseForm.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        gListViewRestoreDefaultColumnWidth(ListView1)
        gListViewRestoreDefaultColumnWidth(ListView2)
    End Sub

    Private Sub ComboBoxHighLight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxHighLight.SelectedIndexChanged
        Find_Data()
    End Sub

    Private Sub CheckBoxAttorney_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Find_Data()
    End Sub

    Private Sub ListView3_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView3.ItemChecked
        Find_Data()
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        DoNotCheck = True
        DoNotLoad = True
        Dim LI As ListViewItem
        ListView3.BeginUpdate()
        For Each LI In ListView3.Items
            LI.Checked = True
        Next
        ListView3.EndUpdate()
        DoNotCheck = False
        DoNotLoad = False
        Find_Data()
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        DoNotCheck = True
        DoNotLoad = True
        Dim LI As ListViewItem
        ListView3.BeginUpdate()
        For Each LI In ListView3.CheckedItems
            LI.Checked = False
        Next
        ListView3.EndUpdate()
        DoNotCheck = False
        DoNotLoad = False
        Find_Data()
    End Sub

    Private Sub Email_Report()
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
            'FpSpreadResults.SuspendLayout()
            'FpSpreadResults.ActiveSheet.Rows.Add(0, 1)
            'Dim I As Integer
            'For I = 0 To FpSpreadResults.ActiveSheet.Columns.Count - 1
            '    FpSpreadResults.ActiveSheet.SetText(0, I, FpSpreadResults.ActiveSheet.ColumnHeader.Columns(I).Label)
            'Next
            'FpSpreadResults.SaveExcel(Fname)
            'FpSpreadResults.ActiveSheet.Rows.Remove(0, 1)
            'FpSpreadResults.ResumeLayout()
            If Export_Listview(True, Fname) = False Then Exit Sub
            Msg.SendMail(Fname.ToString, Subject, Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Sub Fax_Report()
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
            If Export_Listview(True, Fname) = False Then Exit Sub
            gFax(Me, "", Subject, Fname.ToString, gOfficeFax)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
    End Sub

    Private Function Export_Listview(Optional ByVal All As Boolean = True, Optional ByVal FileName As String = "") As Boolean
        Dim CH As ColumnHeader = Nothing
        Dim LI As ListViewItem
        Dim I As Integer
        Dim C As Integer
        Dim C1
        Dim strFileName As String
        Application.DoEvents()
        If All = False Then
            If ListView2.CheckedItems.Count = 0 Then
                MsgBox("Unable to process your request. No records checked.", MsgBoxStyle.Exclamation)
                Exit Function
            End If
        Else
            If ListView2.Items.Count = 0 Then
                MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
                Exit Function
            End If
        End If
        If FileName = "" Then
            SaveFD.Title = "Export Procedure Statistics To Excel."
            SaveFD.Filter = "MS Excel File (*.xls)|*.xls"
            Dim DidWork As Integer = SaveFD.ShowDialog()
            If DidWork = DialogResult.OK Then
                strFileName = SaveFD.FileName
            Else
                Exit Function
            End If
        Else
            strFileName = FileName
        End If
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        FpSpreadForPrint.Visible = False
        FpSpreadForPrint.SuspendLayout()
        ToolStripStatusProgress.Text = "Preparing Data. Please Wait..."
        Application.DoEvents()
        With FpSpreadForPrint
            .ActiveSheet.RowCount = 0
            .ActiveSheet.RowCount = 1
            .ActiveSheet.ColumnCount = ListView2.Columns.Count
            For C = 0 To ListView2.Columns.Count - 1
                For C1 = 0 To ListView2.Columns.Count - 1
                    If ListView2.Columns(C1).DisplayIndex = C Then
                        CH = ListView2.Columns(C1)
                        Exit For
                    End If
                Next
                I += 1
                .ActiveSheet.ColumnHeader.Rows(0).Height = 32
                Select Case CH.TextAlign
                    Case HorizontalAlignment.Left
                        .ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                    Case HorizontalAlignment.Right
                        .ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                    Case HorizontalAlignment.Center
                        .ActiveSheet.Columns(I - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                End Select
                .ActiveSheet.Columns(I - 1).Tag = CH.Index
                .ActiveSheet.Columns(I - 1).Width = CH.Width
                .ActiveSheet.Columns(I - 1).Locked = False
                .ActiveSheet.SetText(0, I - 1, CH.Text)
            Next
            I = 1

            For Each LI In ListView2.Items
                If All = True Or LI.Checked = True Then
                    I += 1
                    .ActiveSheet.RowCount = I
                    For C = 0 To .ActiveSheet.ColumnCount - 1
                        .ActiveSheet.SetText(I - 1, C, LI.SubItems(.ActiveSheet.Columns(C).Tag).Text.ToString)
                        .ActiveSheet.Cells(I - 1, C).BackColor = LI.SubItems(.ActiveSheet.Columns(C).Tag).BackColor
                    Next
                End If
            Next
            .ActiveSheet.Protect = False
            Try
                .SaveExcel(strFileName)
            Catch ex As Exception
                MsgBox("Unable to save file. the file may be in use by another application or drive is full or write protected.", MsgBoxStyle.Critical)
            End Try
            .ActiveSheet.RowCount = 0
            .ResumeLayout()
            SaveFD.Reset()
            If FileName = "" Then System.Diagnostics.Process.Start(strFileName)
            Export_Listview = True
            Cursor = Cursors.Default
        End With
        ToolStripStatusProgress.Text = "   "
    End Function

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Email_Report()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Fax_Report()
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub ComboBoxCaseStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxCaseStatus.SelectedIndexChanged
        Find_Data()
    End Sub

End Class