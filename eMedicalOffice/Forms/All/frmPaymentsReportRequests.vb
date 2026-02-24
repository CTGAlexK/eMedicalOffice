Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmPaymentsReportRequests
    Private log As ILog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Private m_SortingColumnReadings As ColumnHeader
    Private CR As ReportDocument

    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        Find_Data()
    End Sub

    Private Sub Find_Data()
        Dim Reader As SqlClient.SqlDataReader
        Dim LI As ListViewItem
        Dim SI As ListViewItem.ListViewSubItem
        Dim SQL As String
        CR = Nothing
        ListView1.Items.Clear()
        Application.DoEvents()
        If Not m_SortingColumnReadings Is Nothing Then m_SortingColumnReadings.ImageKey = "SORT0"
        m_SortingColumnReadings = ListView1.Columns(1)
        'ListViewReadings.Columns(0).ImageKey = "SORT1"
        Cursor = Cursors.WaitCursor
        SQL =
            " SELECT Patients.PatientID, RTRIM(Patients.FName) + ' ' + RTRIM(Patients.LName) +' ' + RTRIM(Patients.MI) AS PatName, PaymentDate, PaidAmount,  description, Recepient  "
        SQL &=
            " from ImageDiskRequests inner join BillingRequestTypes on ImageDiskRequests.RequestTypeID =  BillingRequestTypes.RequestTypeID inner join Patients on ImageDiskRequests.patientid = Patients.patientid "
        SQL &=
            " Where PaidAmount > 0 "
        Dim PName() As String
        If txtSearch.Text.Trim <> "" Then
            If IsNumeric(txtSearch.Text) Then
                SQL &= " AND Patients.PatientID = " & Val(txtSearch.Text) & " "
            Else
                PName = Split(txtSearch.Text.ToSafeSQLString(), " ")
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

        If DateTimePickerFrom.Checked Then
            SQL &= " AND datediff(d,PaymentDate,'" & DateTimePickerFrom.Value.ToShortDateString & "') <= 0 "
        End If
        If DateTimePickerTo.Checked Then
            SQL &= " AND datediff(d,PaymentDate,'" & DateTimePickerTo.Value.ToShortDateString & "') >= 0 "
        End If

        SQL = SQL & " ORDER BY Patients.PatientID, PaymentDate"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ListView1.Items.Clear()
        FpSpreadForPrint.ActiveSheet.RowCount = 0
        Dim i As Integer
        Dim c As Double
        ListView1.SuspendLayout()
        ListView1.BeginUpdate()
        ListView1.ListViewItemSorter = Nothing
        Dim LV As List(Of ListViewItem) = New List(Of ListViewItem)
        Do Until Reader.Read = False
            LI = New ListViewItem(Reader("PatientID").ToString)
            LI.SubItems.Add(Reader("PatName").ToString)
            LI.SubItems.Add(Reader("description").ToString)
            LI.SubItems.Add(Reader("Recepient").ToString)
            If IsDate(Reader("PaymentDate").ToString) Then
                LI.SubItems.Add(CDate(Reader("PaymentDate").ToString).ToString("MM/dd/yyyy"))
            Else
                LI.SubItems.Add("")
            End If
            LI.SubItems.Add(Val(Reader("PaidAmount")).ToString("c"))
            LV.Add(LI)
            c = c + Reader("PaidAmount")
        Loop
        ListView1.Items.AddRange(LV.ToArray())
        ListView1.EndUpdate()
        ListView1.ResumeLayout(True)
        gListViewRestoreDefaultColumnWidth(ListView1)
        Reader.Close()
        Reader.Dispose()
        If ListView1.Items.Count > 0 Then
            ListView1.Items(0).Selected = True
            ListView1.Items(0).EnsureVisible()
        End If
        LabelCount.Text = ListView1.Items.Count & " Payments Found. Total: " & c.ToString("C")
        Cursor = Cursors.Default
    End Sub

    Private Function FillSpread() As Boolean
        Dim i As Integer
        If ListView1.Items.Count = 0 Then
            Return False
        End If
        If FpSpreadForPrint.ActiveSheet.RowCount > 0 Then
            Return True
        End If
        FpSpreadForPrint.SuspendLayout()
        FpSpreadForPrint.ActiveSheet.RowCount = ListView1.Items.Count
        For Each li As ListViewItem In ListView1.Items
            With FpSpreadForPrint.ActiveSheet
                .SetText(i, 0, li.SubItems(0).Text)
                .SetText(i, 1, li.SubItems(1).Text)
                .SetText(i, 2, li.SubItems(2).Text)
                .SetText(i, 3, li.SubItems(3).Text)
                .SetText(i, 4, li.SubItems(4).Text)
                .SetText(i, 5, li.SubItems(5).Text)
                i = i + 1
            End With
        Next
        Return True
        'Do Until Reader.Read = False
        '    FpSpreadForPrint.ActiveSheet.RowCount += 1

        '    LI = ListView1.Items.Add(Reader("PatientID").ToString)
        '    FpSpreadForPrint.ActiveSheet.SetText(i, 0, Reader("PatientID").ToString)
        '    LI.SubItems.Add(Reader("PatName").ToString)
        '    FpSpreadForPrint.ActiveSheet.SetText(i, 1, Reader("PatName").ToString)
        '    LI.SubItems.Add(Reader("BillId").ToString)
        '    FpSpreadForPrint.ActiveSheet.SetText(i, 2, Reader("BillId").ToString)
        '    If IsDate(Reader("BillDate").ToString) Then
        '        LI.SubItems.Add(CDate(Reader("BillDate").ToString).ToString("MM/dd/yyyy"))
        '        FpSpreadForPrint.ActiveSheet.SetText(i, 3, CDate(Reader("BillDate").ToString).ToString("MM/dd/yyyy"))
        '    Else
        '        LI.SubItems.Add("")
        '        FpSpreadForPrint.ActiveSheet.SetText(i, 3, "")
        '    End If
        '    LI.SubItems.Add(Reader("CompanyName").ToString)
        '    FpSpreadForPrint.ActiveSheet.SetText(i, 4, Reader("CompanyName").ToString)
        '    If IsDate(Reader("PostedDate").ToString) Then
        '        LI.SubItems.Add(CDate(Reader("PostedDate").ToString).ToString("MM/dd/yyyy"))
        '        FpSpreadForPrint.ActiveSheet.SetText(i, 5, CDate(Reader("PostedDate").ToString).ToString("MM/dd/yyyy"))
        '    Else
        '        LI.SubItems.Add("")
        '        FpSpreadForPrint.ActiveSheet.SetText(i, 5, "")
        '    End If
        '    If IsDate(Reader("CheckDate").ToString) Then
        '        LI.SubItems.Add(CDate(Reader("CheckDate").ToString).ToString("MM/dd/yyyy"))
        '        FpSpreadForPrint.ActiveSheet.SetText(i, 5, CDate(Reader("CheckDate").ToString).ToString("MM/dd/yyyy"))
        '    Else
        '        LI.SubItems.Add("")
        '        FpSpreadForPrint.ActiveSheet.SetText(i, 6, "")
        '    End If
        '    LI.SubItems.Add(Reader("CheckNumber").ToString)
        '    FpSpreadForPrint.ActiveSheet.SetText(i, 7, Reader("CheckNumber").ToString)
        '    LI.SubItems.Add(Convert.ToDecimal(Reader("PaymentAmount")).ToString("C"))
        '    FpSpreadForPrint.ActiveSheet.SetText(i, 8, Convert.ToDecimal(Reader("PaymentAmount")).ToString("C"))
        '    i += 1
        'Loop
    End Function

    Private Sub ListViewReadings_ColumnClick(ByVal sender As Object,
                                             ByVal e As System.Windows.Forms.ColumnClickEventArgs) _
        Handles ListView1.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListView1.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumnReadings Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumnReadings) Then
                ' Same column. Switch the sort order.

                'If m_SortingColumnReadings.Text.StartsWith("> ") Then
                'sort_order = SortOrder.Descending
                'Else
                'sort_order = SortOrder.Ascending
                'End If
                If m_SortingColumnReadings.ImageKey = "SORT1" Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'm_SortingColumnReadings.Text =             m_SortingColumnReadings.Text.Mid(2)
            m_SortingColumnReadings.ImageKey = "SORT0"
            m_SortingColumnReadings.ImageKey = "SORT0"
        End If

        ' Display the new sort order.
        m_SortingColumnReadings = new_sorting_column
        'If sort_order = SortOrder.Ascending Then
        'm_SortingColumnReadings.Text = "> " & m_SortingColumnReadings.Text
        'Else
        'm_SortingColumnReadings.Text = "< " & m_SortingColumnReadings.Text
        'End If
        If sort_order = SortOrder.Ascending Then
            m_SortingColumnReadings.ImageKey = "SORT1"
        Else
            m_SortingColumnReadings.ImageKey = "SORT2"
        End If

        ' Create a comparer.
        ListView1.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListView1.Sort()
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        Loading = True
        txtSearch.Text = ""
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        Loading = False
    End Sub

    Private Sub frmReadings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) _
        Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        gListview_Settings(Me, ListView1, ReadWrite.sWrite)
    End Sub

    Private Loading As Boolean

    Private Sub frmReadings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Reader As SqlClient.SqlDataReader
        gWindow_Settings(Me, ReadWrite.sRead)
        gListview_Settings(Me, ListView1, ReadWrite.sRead)
        ListView1.Items.Clear()
        Opacity = 1
        Loading = True
        DateTimePickerFrom.Value = DateAdd(DateInterval.Month, -1, Now)
        DateTimePickerTo.Value = Now
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        Loading = False
        'Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim LI As ListViewItem
        Dim VD As ValueDescription
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox(
                "Unable to Add / Update reading. No procedure selected." & vbCrLf &
                "Add / Update Reading is allowed for the completted procedures only.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListView1.SelectedItems(0)
        VD = CType(LI.Tag, ValueDescription)
        With frmAddReading
            .txtResultDescription.Text = VD.Fld1
            .txtResultDescription2.Text = VD.Fld2
            .PatientProcedureID = VD.Value
            .PatientID = VD.Fld3
            .ReadingID = Val(VD.Fld4)
            .ListViewReadings = ListView1
            .txtProcedure.Text = LI.SubItems(1).Text
            .DoctorID = Val(LI.SubItems(3).Tag)
            .ScheduleDate = LI.Text
            .lblAuth.Visible = Val(VD.Fld4) > 0
            'LI.Tag = New ValueDescription(Reader("PatientProcedureID").ToString, "", "", Reader("ResultDescription").ToString, Reader("ResultDescription2").ToString, ListView1.SelectedItems(0).Tag, Reader("ResultID").ToString)
            .ShowDialog(Me)
            .Dispose()
        End With
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim LI As ListViewItem
        Dim VD As ValueDescription
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to produce the procedure reading report. No procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListView1.SelectedItems(0)
        VD = CType(LI.Tag, ValueDescription)

        If Val(VD.Fld4) = 0 Then
            MsgBox("Unable to produce the procedure reading report. The selected procedure does not have a reading.",
                   MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim PatientProcedureID(0) As Long
        PatientProcedureID(0) = Val(VD.Value)

        Dim PatientID As Integer
        If ListView1.SelectedItems.Count > 0 Then PatientID = Val(ListView1.SelectedItems(0).Text)

        frmReadingReport.Setup_report(PatientProcedureID, PatientID)
        frmReadingReport.ShowDialog(Me)
        frmReadingReport.Dispose()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        txtSearch.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim LI As ListViewItem
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No Procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        LI = ListView1.SelectedItems(0)

        Dim frm As Form = FormsCollection.FindForm("frmPatient")
        If Not frm Is Nothing Then
            MsgBox(
                "The Patient's information window is already opened." & vbCrLf & vbCrLf &
                "Please close the previous patient information window before opening a new one.",
                MsgBoxStyle.Exclamation)
            frm.WindowState = FormWindowState.Normal
            frm.BringToFront()
            Exit Sub
        Else

            frmPatient.InitialTab = 0
            frmPatient.InitialPatientName = CType(LI.Tag, ValueDescription).Fld3

            frmPatient.Width = 1225
            frmPatient.WindowState = FormWindowState.Normal
            frmPatient.Location = New Point(Me.Left + ((Width - frmPatient.Size.Width) \ 2),
                                            Me.Top + ((Height - frmPatient.Size.Height) \ 2))
            frmPatient.Show(Me)
            frmPatient.BringToFront()

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim LI As ListViewItem
        Dim VD As ValueDescription
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Unable to Unlock reading. No procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListView1.SelectedItems(0).SubItems(6).Text.ToUpper = "UNLOCKED" Then
            MsgBox("Unable to Unlock reading. The selected procedure has not been locked.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListView1.SelectedItems(0)
        VD = CType(LI.Tag, ValueDescription)
        Dim ApprovedByID As Long
        Dim ApprovedByName As String
        If gCurrentEmployee.PositionID > 3 Then
            frmSupervisorApproval.LabelMsg.Text = "Unlock Procedure Reading." & vbCrLf & "Patient: " & LI.Text
            If ListView1.SelectedItems(0).SubItems(6).Text.ToUpper = "BILLED" Then
                frmSupervisorApproval.LabelMsg.Text &= " Procedure Billed!"
            End If

            If frmSupervisorApproval.ShowDialog <> Windows.Forms.DialogResult.OK Then
                frmSupervisorApproval.Dispose()
                Exit Sub
            End If
            ApprovedByID = frmSupervisorApproval.SupervisorID
            ApprovedByName = frmSupervisorApproval.SupervisorName
            frmSupervisorApproval.Dispose()
        Else
            If ListView1.SelectedItems(0).SubItems(6).Text.ToUpper = "BILLED" Then
                If _
                    MsgBox(
                        "Please confirm you want to unlock the procedure reading " & vbCrLf & "Patient: " & LI.Text &
                        vbCrLf & vbCrLf & "Attention: The selected procedure is already has been Billed!",
                        MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                If _
                    MsgBox(
                        "Please confirm you want to unlock the procedure reading " & vbCrLf & "Patient: " & LI.Text &
                        "?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Supervisor Approval") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            ApprovedByID = gCurrentEmployee.EmpID
            ApprovedByName = gCurrentEmployee.FName & " " & gCurrentEmployee.LName
        End If
        gUpdate_Profile_Log(VD.Fld3, PatientLogTypes.tProcedureReadingUpdated,
                            "Procedure Reading Has Been Unlocked on " & Now, ApprovedByName)
        gSQLUpdateData("UPDATE PatientProcedureReadings SET EditInd=1 WHERE resultid=" & Val(VD.Fld4))
        LI.SubItems(6).ForeColor = Color.Green
        LI.SubItems(6).Text = "UnLocked"
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtSearch.TextChanged
    End Sub

    Private Sub cboTreatingProvider_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Loading = False Then Timer1.Enabled = True
    End Sub

    Private Sub cboReadingStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Loading = False Then Timer1.Enabled = True
    End Sub

    Private Sub DateTimePickerFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles DateTimePickerFrom.ValueChanged
        If Loading = False Then Timer1.Enabled = True
    End Sub

    Private Sub DateTimePickerTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles DateTimePickerTo.ValueChanged
        If Loading = False Then Timer1.Enabled = True
    End Sub

    Private Sub cboCaseStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Loading = False Then Timer1.Enabled = True
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        If ListView1.Items.Count = 0 Then
            MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try
            If FillSpread() = False Then Exit Sub
            Dim printrules As New FarPoint.Win.Spread.SmartPrintRulesCollection
            printrules.Add(New FarPoint.Win.Spread.BestFitColumnRule(FarPoint.Win.Spread.ResetOption.All))
            ' Create a PrintInfo object and set the properties.
            Dim printset As New FarPoint.Win.Spread.PrintInfo()
            printset.Header = "PAYMENTS REPORT"
            printset.BestFitCols = True
            printset.SmartPrintRules = printrules
            printset.UseSmartPrint = True
            FpSpreadForPrint.Sheets(0).PrintInfo = printset

            FpSpreadForPrint.PrintSheet(0)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Print_Listview(Optional ByVal All As Boolean = True)
        Dim CH As ColumnHeader = Nothing
        Dim LI As ListViewItem
        Dim I As Integer
        Dim C As Integer
        Dim C1
        Dim Printinfo As New FarPoint.Win.Spread.PrintInfo
        With FpSpreadForPrint
            If ListView1.Items.Count = 0 Then
                MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            .ActiveSheet.ColumnCount = ListView1.Columns.Count
            For C = 0 To ListView1.Columns.Count - 1
                For C1 = 0 To ListView1.Columns.Count - 1
                    If ListView1.Columns(C1).DisplayIndex = C Then
                        CH = ListView1.Columns(C1)
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
                    Case "Patient #"
                        .ActiveSheet.Columns(I - 1).Label = "##"
                    Case "Amt $"
                        .ActiveSheet.Columns(I - 1).Label = "Amt"
                    Case "Paid Amt $"
                        .ActiveSheet.Columns(I - 1).Label = "Paid"
                    Case "Balance $"
                        .ActiveSheet.Columns(I - 1).Label = "Balance"
                    Case Else
                        .ActiveSheet.Columns(I - 1).Label = CH.Text
                End Select

            Next
            I = 0
            .ActiveSheet.RowCount = 0
            For Each LI In ListView1.Items
                If All = True Or LI.Checked = True Then
                    I += 1
                    .ActiveSheet.RowCount = I
                    For C = 0 To .ActiveSheet.ColumnCount - 1
                        .ActiveSheet.SetText(I - 1, C, LI.SubItems(.ActiveSheet.Columns(C).Tag).Text)
                    Next
                End If
            Next
            Printinfo.SmartPrintPagesWide = 1
            Printinfo.Preview = True
            Printinfo.Header = "PAYMENTS REPORT RESULT AS OF " & Now & vbCrLf & vbCrLf
            Printinfo.BestFitRows = False
            Printinfo.BestFitCols = True
            Printinfo.ShowShadows = False
            Printinfo.JobName = "eMedical Office Payments Report"
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
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        If ListView1.Items.Count = 0 Then
            MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If FillSpread() = False Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Subject = "Message From " & gOfficeName & " Attached: Payments Report."
        Fname = System.IO.Path.GetTempPath & "\PaymentsReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".xls"
Recheck:
        If System.IO.File.Exists(Fname) Then
            Try
                System.IO.File.Delete(Fname)
            Catch ex As Exception
                Fname = System.IO.Path.GetTempFileName
                Fname = Fname.Replace(".tmp", ".xls")
                GoTo Recheck
            End Try
        End If
        Try
            FpSpreadForPrint.ActiveSheet.Protect = False
            FpSpreadForPrint.SaveExcel(Fname, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders)
            FpSpreadForPrint.ActiveSheet.Protect = True
            Msg.SendMail(Fname.ToString, Subject, Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
        Application.DoEvents()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ListView1.Items.Count = 0 Then
            MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Subject = "Message From " & gOfficeName & " Transcription Report"
        Fname = System.IO.Path.GetTempPath & "\TranscriptionReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
Recheck:
        If System.IO.File.Exists(Fname) Then
            Try
                System.IO.File.Delete(Fname)
            Catch ex As Exception
                Fname = System.IO.Path.GetTempFileName
                Fname.Replace(".tmp", ".pdf")
                GoTo Recheck
            End Try
        End If
        Try
            Dim printset As New FarPoint.Win.Spread.PrintInfo()
            Dim printrules As New FarPoint.Win.Spread.SmartPrintRulesCollection
            printrules.Add(New FarPoint.Win.Spread.BestFitColumnRule(FarPoint.Win.Spread.ResetOption.None))
            printrules.Add(New FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.None))
            printrules.Add(New FarPoint.Win.Spread.ScaleRule(FarPoint.Win.Spread.ResetOption.All, 1.0F, 0.4F, 0.2F))
            ' Create a PrintInfo object and set the properties.
            printset.SmartPrintRules = printrules
            printset.UseSmartPrint = True
            printset.PrintToPdf = True
            printset.PdfFileName = Fname
            FpSpreadForPrint.Sheets(0).PrintInfo = printset
            FpSpreadForPrint.PrintSheet(0)
            gFax(Me, "", Subject, Fname.ToString, gOfficeFax)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
        Application.DoEvents()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        gListViewRestoreDefaultColumnWidth(ListView1)
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim FName As String
        SaveFD.Title = "Export To Excel."
        SaveFD.Filter = "MS Excel File (*.xls)|*.xls"
        SaveFD.DefaultExt = "xls"
        Dim DidWork As Integer = SaveFD.ShowDialog()
        If DidWork = DialogResult.OK Then
            FName = SaveFD.FileName
        Else
            Exit Sub
        End If
        If FillSpread() = False Then Exit Sub
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try
            FpSpreadForPrint.ActiveSheet.Protect = False
            FpSpreadForPrint.SaveExcel(FName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders)
            FpSpreadForPrint.ActiveSheet.Protect = True
            SaveFD.Reset()
            System.Diagnostics.Process.Start(FName)
            Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub frmPaymentsReport_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            Find_Data()
        End If
    End Sub

End Class