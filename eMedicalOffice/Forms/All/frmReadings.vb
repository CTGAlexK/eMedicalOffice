Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports log4net

Public Class frmReadings
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
        ListViewReadings.Items.Clear()
        Application.DoEvents()
        If Not m_SortingColumnReadings Is Nothing Then m_SortingColumnReadings.ImageKey = "SORT0"
        m_SortingColumnReadings = ListViewReadings.Columns(1)
        'ListViewReadings.Columns(0).ImageKey = "SORT1"
        ButtonAddUpdate.Enabled = False
        ButtonUnlock.Enabled = False
        ButtonShowReport.Enabled = False
        ButtonShowPatientInfo.Enabled = False
        Cursor = Cursors.WaitCursor
        SQL =
            " SELECT BillProcedures.BillID, PatientProcedures.DictationDate, PatientProcedureReadings.EditInd, PatientProcedures.ReferringDoctor, Employees.EmpID, Employees.Fname+' '+Employees.Lname+' '+Employees.Alias as TRName, Patients.PatientID,   PatientProcedures.PatientProcedureID, Schedule.ScheduleDateTime, Procedures.ProcName, PatientProcedureReadings.ResultID, PatientProcedureReadings.ReadingDate, PatientProcedureReadings.ResultDescription, PatientProcedureReadings.ResultDescription2, Patients.FName + ' ' + Patients.MI + ' ' + Patients.LName AS Pname  "
        SQL &=
            " FROM PatientProcedures INNER JOIN Schedule ON PatientProcedures.ScheduleID = Schedule.ScheduleID INNER JOIN Procedures ON PatientProcedures.ProcID = Procedures.ProcID INNER JOIN Patients ON PatientProcedures.PatientID = Patients.PatientID LEFT OUTER JOIN PatientProcedureReadings ON PatientProcedures.PatientProcedureID = PatientProcedureReadings.PatientProcedureID  "
        SQL &= " LEFT OUTER JOIN Employees on  PatientProcedures.TreatingProviderID = Employees.EmpID "
        SQL &=
            " LEFT OUTER JOIN BillProcedures ON PatientProcedures.PatientProcedureID = BillProcedures.PatientProcedureID "
        SQL &= " LEFT OUTER JOIN Bills ON BillProcedures.BillID = Bills.BillID "
        ' Prevent readings from the replicated bills
        SQL &=
            " WHERE (PatientProcedures.ProcedureStatusID = 2) and (Bills.BillStatusID<>13 or Bills.BillStatusID is null) "
        If cboCaseStatus.SelectedIndex = 0 Then
            SQL &= " and (Patients.CaseStatusID=1) "
        End If

        If IsNumeric(txtSearch.Text.Trim) Then
            SQL &= " AND Patients.PatientID = " & Val(txtSearch.Text.Trim)
        Else
            If txtSearch.Text.Trim <> "" And txtSearch.Text.Trim <> "*" Then
                SQL &= " AND (Patients.Fname like '" & txtSearch.Text.Trim & "%' "
                SQL &= " OR Patients.Lname like '" & txtSearch.Text.Trim & "%') "
            End If
            If DateTimeReadingFrom.Checked Then
                SQL &= " AND datediff(d,ReadingDate,'" & DateTimeReadingFrom.Value.ToShortDateString & "') <= 0 "
            End If
            If DateTimeReadingTo.Checked Then
                SQL &= " AND datediff(d,ReadingDate,'" & DateTimeReadingTo.Value.ToShortDateString & "') >= 0 "
            End If

            If DateTimePickerFrom.Checked Then
                SQL &= " AND datediff(d,ScheduleDateTime,'" & DateTimePickerFrom.Value.ToShortDateString & "') <= 0 "
            End If
            If DateTimePickerTo.Checked Then
                SQL &= " AND datediff(d,ScheduleDateTime,'" & DateTimePickerTo.Value.ToShortDateString & "') >= 0 "
            End If
            Select Case cboReadingStatus.SelectedIndex
                Case 1 'No Dictation
                    SQL &= " AND PatientProcedures.DictationDate is null "
                Case 2 'No Reading
                    SQL &= " AND PatientProcedureReadings.PatientProcedureID is null "
                Case 3 'Complete
                    SQL &= " AND PatientProcedureReadings.PatientProcedureID  IS NOT NULL "
            End Select
            If cboTreatingProvider.SelectedIndex > 0 Then
                SQL &= " AND PatientProcedures.TreatingProviderID =  " &
                       CType(cboTreatingProvider.SelectedItem, ValueDescription).Value
            End If
        End If

        SQL = SQL & " ORDER BY Schedule.ScheduleDateTime DESC"
        Reader = gSQLGetDataReader(SQL)
        If Reader Is Nothing Then Exit Sub
        ListViewReadings.SuspendLayout()
        ListViewReadings.BeginUpdate()
        ListViewReadings.ListViewItemSorter = Nothing
        Do Until Reader.Read = False

            LI = ListViewReadings.Items.Add(Reader("PName").ToString)
            If IsDate(Reader("ScheduleDateTime").ToString) Then
                SI = LI.SubItems.Add(CDate(Reader("ScheduleDateTime").ToString).ToString("MM/dd/yyyy"))
            Else
                SI = LI.SubItems.Add("")
            End If
            SI = LI.SubItems.Add(Reader("ProcName").ToString)
            SI.Tag = Reader("ResultDescription").ToString & vbCrLf & Reader("ResultDescription2").ToString
            SI = LI.SubItems.Add(Reader("TRName").ToString)
            SI.Tag = Reader("EmpID").ToString
            If IsDate(Reader("DictationDate").ToString) Then
                SI = LI.SubItems.Add(CDate(Reader("DictationDate").ToString).ToString("MM/dd/yyyy"))
                SI.ForeColor = Color.Black
            Else
                LI.SubItems.Add("")
            End If

            If IsDate(Reader("ReadingDate").ToString) Then
                LI.SubItems.Add(CDate(Reader("ReadingDate").ToString).ToString("MM/dd/yyyy"))
                If Val(Reader("EditInd").ToString) = 0 Then
                    LI.ForeColor = Color.Black
                    gSetListItemForeColor(LI, Color.Black)
                Else
                    LI.ForeColor = Color.Magenta
                    gSetListItemForeColor(LI, Color.Magenta)
                End If
            Else
                LI.SubItems.Add("")
                LI.ForeColor = Color.Red
                gSetListItemForeColor(LI, Color.Red)
            End If
            LI.Tag = New ValueDescription(Reader("PatientProcedureID").ToString, "", "",
                                          Reader("ResultDescription").ToString, Reader("ResultDescription2").ToString,
                                          Reader("PatientID").ToString, Reader("ResultID").ToString)

            If Val(Reader("EditInd").ToString) = 1 Or Reader("BillID").ToString = "" Then
                SI = LI.SubItems.Add("UnLocked")
                SI.ForeColor = Color.Green
            Else
                If Val(Reader("BillID").ToString) > 0 Then
                    SI = LI.SubItems.Add("Billed")
                    SI.ForeColor = Color.Red
                Else
                    SI = LI.SubItems.Add("Locked")
                    SI.ForeColor = Color.Red
                End If

            End If
        Loop
        ListViewReadings.EndUpdate()
        ListViewReadings.ResumeLayout(True)
        Reader.Close()
        Reader.Dispose()
        If ListViewReadings.Items.Count > 0 Then
            ListViewReadings.Items(0).Selected = True
            ListViewReadings.Items(0).EnsureVisible()
        End If
        LabelCount.Text = ListViewReadings.Items.Count & " Records Found"
        Cursor = Cursors.Default
    End Sub

    Private Sub ListViewReadings_ColumnClick(ByVal sender As Object,
                                             ByVal e As System.Windows.Forms.ColumnClickEventArgs) _
        Handles ListViewReadings.ColumnClick
        Dim new_sorting_column As ColumnHeader = ListViewReadings.Columns(e.Column)
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
        ListViewReadings.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListViewReadings.Sort()
    End Sub

    Private Sub ListViewReadings_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ListViewReadings.DoubleClick
        Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        Loading = True
        txtSearch.Text = ""
        cboReadingStatus.SelectedIndex = 0
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        If cboTreatingProvider.Items.Count > 0 Then cboTreatingProvider.SelectedIndex = 0
        Loading = False
    End Sub

    Private Sub frmReadings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) _
        Handles Me.FormClosing
        gWindow_Settings(Me, ReadWrite.sWrite)
        gListview_Settings(Me, ListViewReadings, ReadWrite.sWrite)
    End Sub

    Private Loading As Boolean

    Private Sub frmReadings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Reader As SqlClient.SqlDataReader
        gWindow_Settings(Me, ReadWrite.sRead)
        gListview_Settings(Me, ListViewReadings, ReadWrite.sRead)
        ListViewReadings.Items.Clear()
        Loading = True
        DateTimePickerFrom.Value = DateAdd(DateInterval.Month, -1, Now)
        DateTimePickerTo.Value = Now
        DateTimePickerFrom.Checked = False
        DateTimePickerTo.Checked = False
        cboReadingStatus.Items.Add("All")
        cboReadingStatus.Items.Add("No Dictation")
        cboReadingStatus.Items.Add("No Reading")
        cboReadingStatus.Items.Add("Complete")
        cboReadingStatus.SelectedIndex = 1
        cboTreatingProvider.Items.Add(New ValueDescription(0, "All"))
        Reader =
            gSQLGetDataReader(
                "SELECT   Employees.EmpID,   Employees.Fname, Employees.Lname, Employees.Alias FROM Employees INNER JOIN EmployeeOffice ON Employees.EmpID = EmployeeOffice.EmpID WHERE  TreatmentPrv=1 and Employees.ActiveInd = 1 and Employees.PositionID = 5 AND EmployeeOffice.OfficeID = " &
                gOfficeID)
        If Not Reader Is Nothing Then
            Do Until Reader.Read = False
                cboTreatingProvider.Items.Add(New ValueDescription(Reader("EmpID").ToString,
                                                                   Reader("Fname").ToString & " " &
                                                                   Reader("Lname").ToString & " " &
                                                                   Reader("Alias").ToString))
            Loop
        End If
        cboTreatingProvider.SelectedIndex = 0
        cboCaseStatus.Items.Add("Active")
        cboCaseStatus.Items.Add("All")
        cboCaseStatus.SelectedIndex = 0
        Loading = False
        'Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonAddUpdate.Click, AddUpdateReadingReportToolStripMenuItem.Click
        Dim LI As ListViewItem
        Dim VD As ValueDescription
        If ListViewReadings.SelectedItems.Count = 0 Then
            MsgBox(
                "Unable to Add / Update reading. No procedure selected." & vbCrLf &
                "Add / Update Reading is allowed for the completted procedures only.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewReadings.SelectedItems(0)
        VD = CType(LI.Tag, ValueDescription)
        With frmAddReading
            .txtResultDescription.Text = VD.Fld1
            .txtResultDescription2.Text = VD.Fld2
            .PatientProcedureID = VD.Value
            .PatientID = VD.Fld3
            .ReadingID = Val(VD.Fld4)
            .ListViewReadings = ListViewReadings
            .txtProcedure.Text = LI.SubItems(1).Text
            .DoctorID = Val(LI.SubItems(3).Tag)
            .ScheduleDate = LI.Text
            .lblAuth.Visible = Val(VD.Fld4) > 0
            'LI.Tag = New ValueDescription(Reader("PatientProcedureID").ToString, "", "", Reader("ResultDescription").ToString, Reader("ResultDescription2").ToString, ListViewPatients.SelectedItems(0).Tag, Reader("ResultID").ToString)
            .ShowDialog(Me)
            .Dispose()
        End With
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonShowReport.Click, ShowReadingReportToolStripMenuItem.Click
        Dim LI As ListViewItem
        Dim VD As ValueDescription
        If ListViewReadings.SelectedItems.Count = 0 Then
            MsgBox("Unable to produce the procedure reading report. No procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewReadings.SelectedItems(0)
        VD = CType(LI.Tag, ValueDescription)

        If Val(VD.Fld4) = 0 Then
            MsgBox("Unable to produce the procedure reading report. The selected procedure does not have a reading.",
                   MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim PatientProcedureID(0) As Long
        PatientProcedureID(0) = Val(VD.Value)
        Dim PatientID As Integer
        PatientID = Val(VD.Fld3)
        frmReadingReport.Setup_report(PatientProcedureID, PatientID)
        frmReadingReport.ShowDialog(Me)
        frmReadingReport.Dispose()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Find_Data()
    End Sub

    Private Sub ListViewReadings_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles ListViewReadings.MouseDown
        Dim LI As ListViewHitTestInfo
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LI = ListViewReadings.HitTest(New Point(e.X, e.Y))
            If LI.Item Is Nothing Then
                ListViewReadings.ContextMenuStrip = Nothing
            Else
                ListViewReadings.ContextMenuStrip = ContextMenuStrip1
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonShowPatientInfo.Click, mnuShowSelectedPatientInfo1.Click
        Dim LI As ListViewItem
        If ListViewReadings.SelectedItems.Count = 0 Then
            MsgBox("Unable to open patient's information. No Procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        LI = ListViewReadings.SelectedItems(0)

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

    Private Sub ListViewReadings_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ListViewReadings.SelectedIndexChanged
        If ListViewReadings.SelectedItems.Count = 0 Then
            ButtonAddUpdate.Enabled = False
            ButtonUnlock.Enabled = False
            ButtonShowReport.Enabled = False
            ButtonShowPatientInfo.Enabled = False
            Exit Sub
        End If
        ButtonAddUpdate.Enabled = True
        ButtonShowReport.Enabled = True
        ButtonShowPatientInfo.Enabled = True

        If ListViewReadings.SelectedItems(0).SubItems(3).Text <> "" Then
            ButtonUnlock.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUnlock.Click
        Dim LI As ListViewItem
        Dim VD As ValueDescription
        If ListViewReadings.SelectedItems.Count = 0 Then
            MsgBox("Unable to Unlock reading. No procedure selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If ListViewReadings.SelectedItems(0).SubItems(6).Text.ToUpper = "UNLOCKED" Then
            MsgBox("Unable to Unlock reading. The selected procedure has not been locked.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LI = ListViewReadings.SelectedItems(0)
        VD = CType(LI.Tag, ValueDescription)
        Dim ApprovedByID As Long
        Dim ApprovedByName As String
        If gCurrentEmployee.PositionID > 3 Then
            frmSupervisorApproval.LabelMsg.Text = "Unlock Procedure Reading." & vbCrLf & "Patient: " & LI.Text
            If ListViewReadings.SelectedItems(0).SubItems(6).Text.ToUpper = "BILLED" Then
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
            If ListViewReadings.SelectedItems(0).SubItems(6).Text.ToUpper = "BILLED" Then
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
        Loading = True
        If txtSearch.Text <> "" And IsNumeric(txtSearch.Text) Then
            cboTreatingProvider.Enabled = False
            cboReadingStatus.Enabled = False
            DateTimePickerFrom.Enabled = False
            DateTimePickerTo.Enabled = False
            cboReadingStatus.SelectedIndex = 0
            cboTreatingProvider.SelectedIndex = 0
            DateTimePickerFrom.Checked = False
            DateTimePickerTo.Checked = False
        Else
            cboTreatingProvider.Enabled = True
            cboReadingStatus.Enabled = True
            DateTimePickerFrom.Enabled = True
            DateTimePickerTo.Enabled = True
        End If
        Loading = False
        If txtSearch.Text = "" Then
            Exit Sub
        End If
        Find_Data()
    End Sub

    Private Sub cboTreatingProvider_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cboTreatingProvider.SelectedIndexChanged
        If Loading = False Then Timer1.Enabled = True
    End Sub

    Private Sub cboReadingStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cboReadingStatus.SelectedIndexChanged
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

    Private Sub cboCaseStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cboCaseStatus.SelectedIndexChanged
        If Loading = False Then Timer1.Enabled = True
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        If ListViewReadings.Items.Count = 0 Then
            MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try
            If SetupReport() = False Then Exit Sub
            If gPrinterOtherDocuments <> "" Then CR.PrintOptions.PrinterName = gPrinterOtherDocuments
            CR.PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Function SetupReport() As Boolean
        Dim intCounter As Integer
        Dim ConInfo As New TableLogOnInfo
        Dim SF As String
        If Not CR Is Nothing Then
            Return True
        End If
        Try
            CR = New rptTranscription

            If SetupCrystalSecurityInfo(CR) = False Then Exit Function
            Application.DoEvents()
            SF = "{Patients.OfficeID}=" & gOfficeID & " "
            SF &= " and {PatientProcedures.ProcedureStatusID}=2 "
            If cboCaseStatus.SelectedIndex = 0 Then
                SF &= " and {Patients.CaseStatusID}=1 "
            End If

            If IsNumeric(txtSearch.Text.Trim) Then
                SF &= " and {Patients.PatientID}= " & Val(txtSearch.Text.Trim)
            Else
                If txtSearch.Text.Trim <> "" And txtSearch.Text.Trim <> "*" Then
                    SF &= " AND ({Patients.Fname} like '" & txtSearch.Text.Trim & "*' "
                    SF &= " OR {Patients.Lname} like '" & txtSearch.Text.Trim & "*') "
                End If
                If DateTimeReadingFrom.Checked Then
                    SF &= " and {PatientProcedureReadings.ReadingDate} >= #" &
                          DateTimeReadingFrom.Value.ToString("yyyy,MM,dd") & "# "
                End If
                If DateTimeReadingTo.Checked Then
                    SF &= " and {PatientProcedureReadings.ReadingDate} <= #" & DateTimeReadingTo.Value.ToString("yyyy,MM,dd") & "# "
                End If

                If DateTimePickerFrom.Checked Then
                    SF &= " and {Schedule.ScheduleDateTime} >= #" & DateTimePickerFrom.Value.ToString("yyyy,MM,dd") &
                          "# "
                End If
                If DateTimePickerTo.Checked Then
                    SF &= " and {Schedule.ScheduleDateTime} <= #" & DateTimePickerTo.Value.ToString("yyyy,MM,dd") & "# "
                End If

                Select Case cboReadingStatus.SelectedIndex
                    Case 1 'No Dictation
                        SF &= " and isnull({PatientProcedures.DictationDate})=true "
                    Case 2 'No Reading
                        SF &= " and isnull({PatientProcedureReadings.PatientProcedureID})=true"
                    Case 3 'Complete
                        SF &= " and isnull({PatientProcedureReadings.PatientProcedureID})=false"
                End Select

                If cboTreatingProvider.SelectedIndex > 0 Then
                    SF &= " and {PatientProcedures.TreatingProviderID}= " &
                          CType(cboTreatingProvider.SelectedItem, ValueDescription).Value
                End If
            End If
            CR.RecordSelectionFormula = SF
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
            Return False
        End Try
        Cursor = Cursors.Default
        Return True
    End Function

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MessageFrom As String = gOfficeEmail
        Dim Msg As New SendFileTo
        Dim Subject As String
        Dim Fname As String
        If ListViewReadings.Items.Count = 0 Then
            MsgBox("Unable to process your request. No data loaded.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Subject = "Message From " & gOfficeName & " Attached: Transcription Report."
        Fname = System.IO.Path.GetTempPath & "\TranscriptionReport " & Now.ToString("MM-dd-yyyy HH-mm-ss") & ".pdf"
Recheck:
        If System.IO.File.Exists(Fname) Then
            Try
                System.IO.File.Delete(Fname)
            Catch ex As Exception
                Fname = System.IO.Path.GetTempFileName
                Fname = Fname.Replace(".tmp", ".pdf")
                GoTo Recheck
            End Try
        End If
        Try
            If SetupReport() = False Then Exit Sub
            CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)

            Msg.SendMail(Fname.ToString, Subject, Subject)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
        Application.DoEvents()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListViewReadings.Items.Count = 0 Then
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
            If SetupReport() = False Then Exit Sub
            CR.ExportToDisk(ExportFormatType.PortableDocFormat, Fname)
            gFax(Me, "", Subject, Fname.ToString, gOfficeFax)
        Catch ex As Exception
            TopMost = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            log.Error(ex.Message, ex)
        End Try
        Cursor = Cursors.Default
        Application.DoEvents()
    End Sub

End Class